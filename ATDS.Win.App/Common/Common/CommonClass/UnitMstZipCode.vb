Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstZipCode
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : UnitMstZipCode.cls
    ' 内    容    : 郵便番号マスタ 情報 格納 クラス モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '               <Private>
    '               <Property>
    '                   全国地方公共団体コード I/O
    '                   旧郵便番号             I/O
    '                   郵便番号               I/O
    '                   都道府県名カナ         I/O
    '                   市区町村名カナ         I/O
    '                   町域名カナ             I/O
    '                   都道府県名             I/O
    '                   市区町村名             I/O
    '                   町域名                 I/O
    '                   一町域複数番号         I/O
    '                   番地基番表示           I/O
    '                   丁目表示               I/O
    '                   一番号複数町域         I/O
    '                   更新表示               I/O
    '                   変更理由               I/O
    '               <Events>
    '                   Class_Initialize       (クラス初期設定)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const MC_TABLE_郵便番号マスタ As String = "郵便番号マスタ"
    Private Const MC_TABLE_大口事業所等個別郵便番号マスタ As String = "大口事業所等個別郵便番号マスタ"

    '==============================================================================
    ' 変数
    '==============================================================================
    '++修正開始　2021年06月08:MK（ツール）- OR_005 VB→VB.NET変換
    'Private mobjOraSession As Object ' Oracle
    Private mobjOraSession As OraSession ' Oracle
    '--修正終了　2021年06月08:MK（ツール）- OR_005 VB→VB.NET変換
    '++修正開始　2021年06月08:MK（ツール）- OR_002 VB→VB.NET変換
    'Private mobjOraDatabase As Object ' Oracle
    Private mobjOraDatabase As OraDatabase ' Oracle
    '--修正終了　2021年06月08:MK（ツール）- OR_002 VB→VB.NET変換
    Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)
    Private mblnDBObject As Boolean ' DB接続オブジェクト設定フラグ(True：設定)

    Private mstr全国地方公共団体コード As String
    Private mstr旧郵便番号 As String
    Private mstr郵便番号 As String
    Private mstr都道府県名カナ As String
    Private mstr市区町村名カナ As String
    Private mstr町域名カナ As String
    Private mstr都道府県名 As String
    Private mstr市区町村名 As String
    Private mstr町域名 As String
    Private mstr一町域複数番号 As String
    Private mstr番地基番表示 As String
    Private mstr丁目表示 As String
    Private mstr一番号複数町域 As String
    Private mstr更新表示 As String
    Private mstr変更理由 As String
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' イベント
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : Class_Initialize
    ' スコープ  : Public
    ' 処理内容  : 郵便番号マスタ 情報 格納 クラス 初期設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_Class_Initialize"
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換


            mblnDBConnect = False

            mblnDBObject = False

            mstr全国地方公共団体コード = ""
            mstr旧郵便番号 = ""
            mstr郵便番号 = ""
            mstr都道府県名カナ = ""
            mstr市区町村名カナ = ""
            mstr町域名カナ = ""
            mstr都道府県名 = ""
            mstr市区町村名 = ""
            mstr町域名 = ""
            mstr一町域複数番号 = ""
            mstr番地基番表示 = ""
            mstr丁目表示 = ""
            mstr一番号複数町域 = ""
            mstr更新表示 = ""
            mstr変更理由 = ""

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:16c1dff7-e424-42ea-a497-b58ade5310c2
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:16c1dff7-e424-42ea-a497-b58ade5310c2
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    '******************************************************************************
    ' 関 数 名  : Class_Terminate
    ' スコープ  : Public
    ' 処理内容  : ＤＢ切断
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to
    '. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_Class_Terminate"
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換


            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' メソッド
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : DBConnect
    ' スコープ  : Public
    ' 処理内容  : ＤＢ接続
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrUserName        String            I     ユーザ名
    '   pstrPassWord        String            I     パスワード
    '   pstrTNS             String            I     ＴＮＳ名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_DBConnect"
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換


            '++修正開始　2021年06月08:MK（ツール）- OR_005 VB→VB.NET変換
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()
            '--修正終了　2021年06月08:MK（ツール）- OR_005 VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:333a73df-4e06-4126-a016-5b0270e23c74
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:333a73df-4e06-4126-a016-5b0270e23c74
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:333a73df-4e06-4126-a016-5b0270e23c74
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:333a73df-4e06-4126-a016-5b0270e23c74
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : DBObjectSet
    ' スコープ  : Public
    ' 処理内容  : ＤＢオブジェクト設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDatabase
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_DBObjectSet"
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換


            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:333a73df-4e06-4126-a016-5b0270e23c74
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:333a73df-4e06-4126-a016-5b0270e23c74
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : CheckZIPCode
    ' スコープ  : Public
    ' 処理内容  : 郵便番号存在チェック
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     郵便番号１
    '   pstrZipCode2        String            I     郵便番号２
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function CheckZIPCode(ByVal pstrZIPCode1 As String, ByVal pstrZIPCode2 As String) As Boolean

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_CheckZIPCode"
        Dim objDysYB_M As Object ' 郵便番号マスタのOraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            CheckZIPCode = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' 砂時計ポインタを設定
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '郵便番号マスタ
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    郵便番号 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_郵便番号マスタ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    郵便番号 = '" & pstrZIPCode1 & pstrZIPCode2 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            '大口事業所等個別郵便番号マスタ
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    大口事業所個別番号 AS 郵便番号 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_大口事業所等個別郵便番号マスタ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    大口事業所個別番号 = '" & pstrZIPCode1 & pstrZIPCode2 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' 戻り値を設定(正常終了)
                    CheckZIPCode = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : CheckZIPParentCode
    ' スコープ  : Public
    ' 処理内容  : 郵便番号マスタ（親コード） チェック
    ' 備    考  : 郵便番号の上3桁(親コード)で郵便番号マスタを検索
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     郵便番号１
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function CheckZIPParentCode(ByVal pstrZIPCode1 As String) As Boolean

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_CheckZIPParentCode"
        Dim objDysYB_M As Object ' 郵便番号マスタのOraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            CheckZIPParentCode = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' 砂時計ポインタを設定
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '郵便番号マスタ
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    郵便番号 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_郵便番号マスタ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    郵便番号1 = '" & pstrZIPCode1 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            '大口事業所等個別郵便番号マスタ
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    大口事業所個別番号 AS 郵便番号 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_大口事業所等個別郵便番号マスタ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    大口事業所個別番号1 = '" & pstrZIPCode1 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' 戻り値を設定(正常終了)
                    CheckZIPParentCode = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : SetZIPInfo
    ' スコープ  : Public
    ' 処理内容  : 郵便番号マスタ 設定
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     郵便番号１
    '   pstrZipCode2        String            I     郵便番号２
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function SetZIPInfo(ByVal pstrZIPCode1 As String, ByVal pstrZIPCode2 As String) As Boolean

        '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_SetZIPInfo"
        Dim objDysYB_M As Object ' 郵便番号マスタのOraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月08:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            SetZIPInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' 砂時計ポインタを設定
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '郵便番号マスタ
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    全国地方公共団体コード , "
            strSQL = strSQL & Chr(10) & "    旧郵便番号             , "
            strSQL = strSQL & Chr(10) & "    郵便番号               , "
            strSQL = strSQL & Chr(10) & "    都道府県名カナ         , "
            strSQL = strSQL & Chr(10) & "    市区町村名カナ         , "
            strSQL = strSQL & Chr(10) & "    町域名カナ             , "
            strSQL = strSQL & Chr(10) & "    都道府県名             , "
            strSQL = strSQL & Chr(10) & "    市区町村名             , "
            strSQL = strSQL & Chr(10) & "    町域名                 , "
            strSQL = strSQL & Chr(10) & "    一町域複数番号         , "
            strSQL = strSQL & Chr(10) & "    番地基番表示           , "
            strSQL = strSQL & Chr(10) & "    丁目表示               , "
            strSQL = strSQL & Chr(10) & "    一番号複数町域         , "
            strSQL = strSQL & Chr(10) & "    更新表示               , "
            strSQL = strSQL & Chr(10) & "    変更理由                 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_郵便番号マスタ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    郵便番号 = '" & pstrZIPCode1 & pstrZIPCode2 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            '大口事業所等個別郵便番号マスタ
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NULL                   全国地方公共団体コード, "
            strSQL = strSQL & Chr(10) & "    旧郵便番号             , "
            strSQL = strSQL & Chr(10) & "    大口事業所個別番号     郵便番号              , "
            strSQL = strSQL & Chr(10) & "    NULL                   都道府県名カナ        , "
            strSQL = strSQL & Chr(10) & "    NULL                   市区町村名カナ        , "
            strSQL = strSQL & Chr(10) & "    NULL                   町域名カナ            , "
            strSQL = strSQL & Chr(10) & "    都道府県名             , "
            strSQL = strSQL & Chr(10) & "    市区町村名             , "
            strSQL = strSQL & Chr(10) & "    町域名 || 小字丁目番地 町域名                , "
            strSQL = strSQL & Chr(10) & "    NULL                   一町域複数番号        , "
            strSQL = strSQL & Chr(10) & "    NULL                   番地基番表示          , "
            strSQL = strSQL & Chr(10) & "    NULL                   丁目表示              , "
            strSQL = strSQL & Chr(10) & "    NULL                   一番号複数町域        , "
            strSQL = strSQL & Chr(10) & "    NULL                   更新表示              , "
            strSQL = strSQL & Chr(10) & "    NULL                   変更理由                "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_大口事業所等個別郵便番号マスタ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    大口事業所個別番号 = '" & pstrZIPCode1 & pstrZIPCode2 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' 戻り値を設定(正常終了)
                    SetZIPInfo = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr全国地方公共団体コード = gfncFieldVal(.Fields("全国地方公共団体コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr旧郵便番号 = gfncFieldVal(.Fields("旧郵便番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr郵便番号 = gfncFieldVal(.Fields("郵便番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr都道府県名カナ = gfncFieldVal(.Fields("都道府県名カナ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr市区町村名カナ = gfncFieldVal(.Fields("市区町村名カナ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr町域名カナ = gfncFieldVal(.Fields("町域名カナ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr都道府県名 = gfncFieldVal(.Fields("都道府県名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr市区町村名 = gfncFieldVal(.Fields("市区町村名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr町域名 = gfncFieldVal(.Fields("町域名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr一町域複数番号 = gfncFieldVal(.Fields("一町域複数番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr番地基番表示 = gfncFieldVal(.Fields("番地基番表示").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr丁目表示 = gfncFieldVal(.Fields("丁目表示").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr一番号複数町域 = gfncFieldVal(.Fields("一番号複数町域").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr更新表示 = gfncFieldVal(.Fields("更新表示").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr変更理由 = gfncFieldVal(.Fields("変更理由").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
        Catch ex As Exception
            '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
            '--修正終了　2021年06月08:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--修正終了　2021年06月08:MK（ツール）- VB_523 VB→VB.NET変換	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
        '--修正終了　2021年06月08:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' プロパティ
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : 全国地方公共団体コード
    ' スコープ  : Public
    ' 処理内容  : 全国地方公共団体コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     全国地方公共団体コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 全国地方公共団体コード
    ' スコープ  : Public
    ' 処理内容  : 全国地方公共団体コード 取得
    ' 備    考  :
    ' 返 り 値  : 全国地方公共団体コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 全国地方公共団体コード() As String
        Get
            全国地方公共団体コード = mstr全国地方公共団体コード
        End Get
        Set(ByVal Value As String)
            mstr全国地方公共団体コード = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 旧郵便番号
    ' スコープ  : Public
    ' 処理内容  : 旧郵便番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String         I     旧郵便番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 旧郵便番号
    ' スコープ  : Public
    ' 処理内容  : 旧郵便番号 取得
    ' 備    考  :
    ' 返 り 値  : 旧郵便番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 旧郵便番号() As String
        Get
            旧郵便番号 = mstr旧郵便番号
        End Get
        Set(ByVal Value As String)
            mstr旧郵便番号 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 郵便番号
    ' スコープ  : Public
    ' 処理内容  : 郵便番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     郵便番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 郵便番号
    ' スコープ  : Public
    ' 処理内容  : 郵便番号 取得
    ' 備    考  :
    ' 返 り 値  : 郵便番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 郵便番号() As String
        Get
            郵便番号 = mstr郵便番号
        End Get
        Set(ByVal Value As String)
            mstr郵便番号 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 都道府県名カナ
    ' スコープ  : Public
    ' 処理内容  : 都道府県名カナ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     都道府県名カナ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 都道府県名カナ
    ' スコープ  : Public
    ' 処理内容  : 都道府県名カナ 取得
    ' 備    考  :
    ' 返 り 値  : 都道府県名カナ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 都道府県名カナ() As String
        Get
            都道府県名カナ = mstr都道府県名カナ
        End Get
        Set(ByVal Value As String)
            mstr都道府県名カナ = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 市区町村名カナ
    ' スコープ  : Public
    ' 処理内容  : 市区町村名カナ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     市区町村名カナ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 市区町村名カナ
    ' スコープ  : Public
    ' 処理内容  : 市区町村名カナ 取得
    ' 備    考  :
    ' 返 り 値  : 市区町村名カナ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 市区町村名カナ() As String
        Get
            市区町村名カナ = mstr市区町村名カナ
        End Get
        Set(ByVal Value As String)
            mstr市区町村名カナ = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 町域名カナ
    ' スコープ  : Public
    ' 処理内容  : 町域名カナ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     町域名カナ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 町域名カナ
    ' スコープ  : Public
    ' 処理内容  : 町域名カナ 取得
    ' 備    考  :
    ' 返 り 値  : 町域名カナ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 町域名カナ() As String
        Get
            町域名カナ = mstr町域名カナ
        End Get
        Set(ByVal Value As String)
            mstr町域名カナ = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 都道府県名
    ' スコープ  : Public
    ' 処理内容  : 都道府県名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     都道府県名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 都道府県名
    ' スコープ  : Public
    ' 処理内容  : 都道府県名 取得
    ' 備    考  :
    ' 返 り 値  : 都道府県名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 都道府県名() As String
        Get
            都道府県名 = mstr都道府県名
        End Get
        Set(ByVal Value As String)
            mstr都道府県名 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 市区町村名
    ' スコープ  : Public
    ' 処理内容  : 市区町村名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     市区町村名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 市区町村名
    ' スコープ  : Public
    ' 処理内容  : 市区町村名 取得
    ' 備    考  :
    ' 返 り 値  : 市区町村名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 市区町村名() As String
        Get
            市区町村名 = mstr市区町村名
        End Get
        Set(ByVal Value As String)
            mstr市区町村名 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 町域名
    ' スコープ  : Public
    ' 処理内容  : 町域名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     町域名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 町域名
    ' スコープ  : Public
    ' 処理内容  : 町域名 取得
    ' 備    考  :
    ' 返 り 値  : 町域名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 町域名() As String
        Get
            町域名 = mstr町域名
        End Get
        Set(ByVal Value As String)
            mstr町域名 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 一町域複数番号
    ' スコープ  : Public
    ' 処理内容  : 一町域複数番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     一町域複数番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 一町域複数番号
    ' スコープ  : Public
    ' 処理内容  : 一町域複数番号 取得
    ' 備    考  :
    ' 返 り 値  : 一町域複数番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 一町域複数番号() As String
        Get
            一町域複数番号 = mstr一町域複数番号
        End Get
        Set(ByVal Value As String)
            mstr一町域複数番号 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 番地基番表示
    ' スコープ  : Public
    ' 処理内容  : 番地基番表示 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     番地基番表示
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 番地基番表示
    ' スコープ  : Public
    ' 処理内容  : 番地基番表示 取得
    ' 備    考  :
    ' 返 り 値  : 番地基番表示
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 番地基番表示() As String
        Get
            番地基番表示 = mstr番地基番表示
        End Get
        Set(ByVal Value As String)
            mstr番地基番表示 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 丁目表示
    ' スコープ  : Public
    ' 処理内容  : 丁目表示 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     丁目表示
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 丁目表示
    ' スコープ  : Public
    ' 処理内容  : 丁目表示 取得
    ' 備    考  :
    ' 返 り 値  : 丁目表示
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 丁目表示() As String
        Get
            丁目表示 = mstr丁目表示
        End Get
        Set(ByVal Value As String)
            mstr丁目表示 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 一番号複数町域
    ' スコープ  : Public
    ' 処理内容  : 一番号複数町域 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     一番号複数町域
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 一番号複数町域
    ' スコープ  : Public
    ' 処理内容  : 一番号複数町域 取得
    ' 備    考  :
    ' 返 り 値  : 一番号複数町域
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 一番号複数町域() As String
        Get
            一番号複数町域 = mstr一番号複数町域
        End Get
        Set(ByVal Value As String)
            mstr一番号複数町域 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 更新表示
    ' スコープ  : Public
    ' 処理内容  : 更新表示 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     更新表示
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 更新表示
    ' スコープ  : Public
    ' 処理内容  : 更新表示 取得
    ' 備    考  :
    ' 返 り 値  : 更新表示
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 更新表示() As String
        Get
            更新表示 = mstr更新表示
        End Get
        Set(ByVal Value As String)
            mstr更新表示 = Value
        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 変更理由
    ' スコープ  : Public
    ' 処理内容  : 変更理由 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     変更理由
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 変更理由
    ' スコープ  : Public
    ' 処理内容  : 変更理由 取得
    ' 備    考  :
    ' 返 り 値  : 変更理由
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 変更理由() As String
        Get
            変更理由 = mstr変更理由
        End Get
        Set(ByVal Value As String)
            mstr変更理由 = Value
        End Set
    End Property
End Class
