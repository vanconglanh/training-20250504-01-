Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basDBConnect
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : DBConnect.bas
    ' 内    容    : データベース接続 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncDBConnect                (ＤＢ接続)
    '                   gsubDBDisConnect             (ＤＢ切断)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/05/28  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : gfncDBConnect
    ' スコープ  : Public
    ' 処理内容  : ＤＢ接続
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            O     Oracle Session  オブジェクト
    '   pobjDatabase        Object            O     Oracle Database オブジェクト
    '   pstrUserName        String            I     ユーザ名
    '   pstrPassWord        String            I     パスワード
    '   pstrTNS             String            I     ＴＮＳ名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/05/28  廣井  芳明         新規作成
    '
    '******************************************************************************

    '++修正開始　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
    'Public Function gfncDBConnect(ByRef pobjSession As Object, ByRef pobjDatabase As Object, ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String) As Boolean
    Public Function gfncDBConnect(ByRef pobjSession As OraSession, ByRef pobjDatabase As OraDatabase, ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String) As Boolean
        '--修正終了　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDBConnect"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncDBConnect"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            gfncDBConnect = True

            '++修正開始　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
            'pobjSession = CreateObject("OracleInProcServer.XOraSession")
            pobjSession = New OraSession()
            '--修正終了　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            pobjDatabase = pobjSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            gfncDBConnect = False

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:91d82f1d-a44b-4541-8830-8fbe6cfa659d
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:91d82f1d-a44b-4541-8830-8fbe6cfa659d
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af56b682-5e89-4b72-93ca-1c78436f6f4c

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function

    '******************************************************************************
    ' 関 数 名  : gsubDBDisConnect
    ' スコープ  : Public
    ' 処理内容  : ＤＢ切断
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            O     Oracle Session  オブジェクト
    '   pobjDatabase        Object            O     Oracle Database オブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/05/28  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubDBDisConnect(ByRef pobjSession As Object, ByRef pobjDatabase As Object)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubDBDisConnect"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gsubDBDisConnect"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            If pobjDatabase Is Nothing = False Then

                'UPGRADE_NOTE: Object pobjDatabase may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                pobjDatabase = Nothing

            End If

            If pobjSession Is Nothing = False Then

                'UPGRADE_NOTE: Object pobjSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                pobjSession = Nothing

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af01fbce-a12b-48d1-8712-4419a7adb531
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af01fbce-a12b-48d1-8712-4419a7adb531

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af01fbce-a12b-48d1-8712-4419a7adb531
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:af01fbce-a12b-48d1-8712-4419a7adb531
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
End Module
