Option Strict Off
Option Explicit On
Module basCreateObject
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : CreateObject.bas
    ' 内    容    : オブジェクト 生成 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncCreateObject              (オブジェクト 生成)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/10/26  廣井  芳明         新規作成
    '   02.01       2009/09/20  廣井  芳明         システム名を引数で取得
    '   02.02       2009/11/02  廣井  芳明         ＤＢが接続されていない場合に対応
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : gfncCreateObject
    ' スコープ  : Public
    ' 処理内容  : オブジェクト 生成
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjModule          Object            O     オブジェクトモジュール
    '   pstrObjctName       String            I     オブジェクト名
    '   pstrSystemName      String            I     システム名
    '   pstrUserName        String            I     ユーザ名
    '   pstrPassWord        String            I     パスワード
    '   pstrTNS             String            I     ＴＮＳ名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/10/26  廣井  芳明         新規作成
    '   02.01       2009/09/20  廣井  芳明         システム名を引数で取得
    '   02.02       2009/11/02  廣井  芳明         ＤＢが接続されていない場合に対応
    '
    '******************************************************************************
    Public Function gfncCreateObject(ByRef pobjModule As Object, ByVal pstrObjectName As String, Optional ByVal pstrSystemName As String = "", Optional ByVal pstrUserName As String = GC_DEF_USER_NAME, Optional ByVal pstrPassWord As String = GC_DEF_PASS_WORD, Optional ByVal pstrTNS As String = GC_DEF_TNS_NAME) As Integer

        '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
        'On Error Resume Next
        '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
        Try

            Dim clsRegisterDLL As clsRegisterSystemDll
            Dim strSystemName As String

            ' 戻り値を初期化(正常終了)
            gfncCreateObject = GC_CODE_SUC

            If pstrSystemName = "" Then

                strSystemName = GC_PROGRAM_NAME

            Else

                strSystemName = pstrSystemName

            End If

            pobjModule = CreateObject(pstrObjectName)

            ' エラーが発生していない場合
            If Err.Number = 0 Then

                Exit Function

            End If

            '----------------------------------------------------------------------
            ' ＤＬＬ登録
            '----------------------------------------------------------------------
            clsRegisterDLL = New clsRegisterSystemDll

            ' ＤＢオブジェクトが設定されていない場合
            If gobjOraSession Is Nothing = True Then

                Call clsRegisterDLL.DBConnect(pstrUserName, pstrPassWord, pstrTNS)

            Else

                Call clsRegisterDLL.DBObjectSet(gobjOraSession, gobjOraDatabase)

            End If

            clsRegisterDLL.SystemName = strSystemName

            Call clsRegisterDLL.RegisterDLL(pstrObjectName)

            Call gsubClearObject(clsRegisterDLL)

            pobjModule = CreateObject(pstrObjectName)

        Catch ex As Exception

            ' エラーが発生した場合
            '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
            'If Err.Number <> 0 Then
            '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

            ' 戻り値を設定(異常終了)
            '++修正開始　2021年06月03日:MK（手）- VB→VB.NET変換
            'gfncCreateObject = GC_CODE_ERR
            gfncCreateObject = 0
            '--修正開始　2021年06月03日:MK（手）- VB→VB.NET変換

            '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
            pobjModule = New Login.clsLogin()
            '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

            '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
            'Exit Function

            'End If
            '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

        End Try
    End Function

End Module