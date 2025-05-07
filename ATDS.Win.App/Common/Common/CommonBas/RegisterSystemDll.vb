Option Strict Off
Option Explicit On
Imports MKOra.Core
Imports Common
Friend Class clsRegisterSystemDll
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : RegisterSystemDll.cls
    ' 内    容    : ＭＫシステムＤＬＬ レジストリ 登録 クラス モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   DBConnect              (ＤＢ接続)
    '                   DBObjectSet            (ＤＢオブジェクト設定)
    '                   RegisterDLL            (ＭＫシステムＤＬＬ レジストリ 登録)
    '               <Private>
    '                   msubRegistServer       (レジストリ 登録処理)
    '                   msubUnRegistServer     (レジストリ 登録解除処理)
    '               <Property>
    '                   SystemName             I  (ＤＬＬ登録対象 システム名)
    '               <Events>
    '                   Class_Initialize       (クラス初期設定)
    '                   Class_Terminate        (ＤＢ切断)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const MC_CMD_REGSVR32 As String = "regsvr32"
    Private Const MC_PRAM_REGSVR As String = "/RegServer"
    Private Const MC_PRAM_UN_REGSVR As String = "/UnRegServer"

    Private Const MC_EXECUTE_OTHER As Short = 0
    Private Const MC_EXECUTE_DLL As Short = 1
    Private Const MC_EXECUTE_EXE As Short = 2

    '==============================================================================
    ' 変数
    '==============================================================================
    Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)
    Private mblnDBObject As Boolean ' DB接続オブジェクト設定フラグ(True：設定)
    Private mstrSystemName As String ' DLL識別
    '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
    'Private mobjOraSession As Object
    Private mobjOraSession As OraSession
    '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年05月27:MK（ツール）- OR_002 VB→VB.NET変換
    'Private mobjOraDatabase As Object
    Private mobjOraDatabase As OraDatabase
    '--修正終了　2021年05月27:MK（ツール）- OR_002 VB→VB.NET変換
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' イベント
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : Class_Initialize
    ' スコープ  : Public
    ' 処理内容  : ＭＫシステムＤＬＬ レジストリ 登録 クラス 初期設定
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Initialize"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Initialize"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mblnDBConnect = False

            mblnDBObject = False

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:040bb9da-76d9-4560-bccc-ce073f358789
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:040bb9da-76d9-4560-bccc-ce073f358789
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
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
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Terminate"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Terminate"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9c033dea-e61b-4ac7-86d6-964d68ee7521

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
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
    ' 返 り 値  :
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
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBConnect"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBConnect"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()

            '--修正終了　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4a972f61-d1fe-4382-ae01-3523db60591d
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4a972f61-d1fe-4382-ae01-3523db60591d

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4a972f61-d1fe-4382-ae01-3523db60591d
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4a972f61-d1fe-4382-ae01-3523db60591d
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : DBObjectSet
    ' スコープ  : Public
    ' 処理内容  : ＤＢオブジェクト設定
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDataBase
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBObjectSet"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBObjectSet"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4a972f61-d1fe-4382-ae01-3523db60591d
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4a972f61-d1fe-4382-ae01-3523db60591d
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6affe531-11f4-4232-84f4-1bf63794a246
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6affe531-11f4-4232-84f4-1bf63794a246

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6affe531-11f4-4232-84f4-1bf63794a246
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6affe531-11f4-4232-84f4-1bf63794a246
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : RegisterDLL
    ' スコープ  : Public
    ' 処理内容  : ＭＫシステムＤＬＬ レジストリ 登録
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrProgId          String            I     プログラムＩＤ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function RegisterDLL(Optional ByVal pstrProgId As String = "") As Boolean


        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_LoadLogin"
        Dim strSQL As String
        '++修正開始　2021年09月11日:MK（手）- VB→VB.NET変換
        'Dim objDysDLL登録テーブル As Object
        Dim objDysDLL登録テーブル As OraDynaset
        '--修正開始　2021年09月11日:MK（手）- VB→VB.NET変換
        Dim strFilePathReg As String ' レジストリに登録されているファイルパス
        Dim strFilePath As String ' 登録対象となるファイルパス
        Dim strVersionReg As String ' レジストリに登録されているファイルのバージョン
        Dim strVersion As String ' 登録対象となるファイルのバージョン
        Dim vntClsid As Object
        Dim intExecuteKbn As Short ' 拡張子区分(0:DLL,1:EXE)
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            If Len(mstrSystemName) = 0 Then
                Exit Function
            End If

            '2022/08/22↓　実行しないよう修正：TSS千住
            Exit Function
            '2022/08/22↑

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ＰＡＴＨ名 "
            strSQL = strSQL & Chr(10) & "  , ＤＬＬ名   "
            strSQL = strSQL & Chr(10) & "  , PROGID     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "   ＤＬＬ登録テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "   ＤＬＬ識別 = '" & mstrSystemName & "' "

            If pstrProgId <> "" Then

                strSQL = strSQL & Chr(10) & "AND PROGID     = '" & pstrProgId & "' "

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysDLL登録テーブル = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysDLL登録テーブル

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    '------------------------------------------------------------------
                    ' 登録対象 ファイルパス 取得
                    '------------------------------------------------------------------
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysDLL登録テーブル.Fields(ＤＬＬ名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strFilePath = gfncFieldVal(.Fields("ＰＡＴＨ名").Value) & gfncFieldVal(.Fields("ＤＬＬ名").Value)

                    '------------------------------------------------------------------
                    ' 拡張子区分 設定
                    '------------------------------------------------------------------
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                    'If InStr(StrConv(gfncFieldVal(.Fields("ＤＬＬ名").Value), VbStrConv.UpperCase), ".DLL") <> 0 Then
                    If InStr(Utils.StrConv(gfncFieldVal(.Fields("ＤＬＬ名").Value), VbStrConv.Uppercase), ".DLL") <> 0 Then
                        '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

                        intExecuteKbn = MC_EXECUTE_DLL

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                        'ElseIf InStr(StrConv(gfncFieldVal(.Fields("ＤＬＬ名").Value), VbStrConv.UpperCase), ".EXE") <> 0 Then
                    ElseIf InStr(Utils.StrConv(gfncFieldVal(.Fields("ＤＬＬ名").Value), VbStrConv.Uppercase), ".EXE") <> 0 Then
                        '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

                        intExecuteKbn = MC_EXECUTE_EXE

                    Else

                        intExecuteKbn = MC_EXECUTE_OTHER

                    End If

                    '------------------------------------------------------------------
                    ' レジストリ ファイルパス 取得
                    '------------------------------------------------------------------
                    strFilePathReg = ""

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysDLL登録テーブル.Fields(PROGID).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gfncFieldVal(.Fields("PROGID").Value) <> "" Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        vntClsid = gfncGetRegValue(basGetRegValue.hKeyConstants.HKEY_LOCAL_MACHINE, "SOFTWARE\Classes\" & gfncFieldVal(.Fields("PROGID").Value) & "\Clsid", "", basGetRegValue.RegTypeConstants.REG_SZ, "")

                        'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If vntClsid <> "" Then

                            If intExecuteKbn = MC_EXECUTE_DLL Then

                                'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                strFilePathReg = gfncGetRegValue(basGetRegValue.hKeyConstants.HKEY_LOCAL_MACHINE, "SOFTWARE\Classes\CLSID\" & vntClsid & "\InprocServer32", "", basGetRegValue.RegTypeConstants.REG_SZ, "")

                            ElseIf intExecuteKbn = MC_EXECUTE_EXE Then

                                'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                strFilePathReg = gfncGetRegValue(basGetRegValue.hKeyConstants.HKEY_LOCAL_MACHINE, "SOFTWARE\Classes\CLSID\" & vntClsid & "\LocalServer32", "", basGetRegValue.RegTypeConstants.REG_SZ, "")

                            Else

                                ' 処理なし

                            End If

                        End If

                    End If

                    '------------------------------------------------------------------
                    ' 登録対象 ファイルパス 取得
                    '------------------------------------------------------------------
                    ' レジストリに登録されていない場合
                    If strFilePathReg = "" Then

                        ' レジストリに登録
                        Call msubRegistServer(intExecuteKbn, strFilePath)

                        ' レジストリに登録されている場合
                    Else

                        ' レジストリに登録されているファイルパスと
                        ' 登録対象となるファイルパスが一致しない場合
                        '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                        'If StrConv(strFilePathReg, VbStrConv.UpperCase) <> StrConv(strFilePath, VbStrConv.UpperCase) Then
                        If Utils.StrConv(strFilePathReg, VbStrConv.Uppercase) <> Utils.StrConv(strFilePath, VbStrConv.Uppercase) Then
                            '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

                            ' 現在, レジストリに登録されている情報を削除
                            Call msubUnRegistServer(intExecuteKbn, strFilePathReg)

                            ' レジストリに登録
                            Call msubRegistServer(intExecuteKbn, strFilePath)

                            ' レジストリに登録されているファイルパスと
                            ' 登録対象となるファイルパスが一致する場合
                        Else

                            ' 登録対象プログラムＩＤが指定されている場合
                            If pstrProgId <> "" Then

                                ' 現在, レジストリに登録されている情報を削除
                                Call msubUnRegistServer(intExecuteKbn, strFilePathReg)

                                ' レジストリに登録
                                Call msubRegistServer(intExecuteKbn, strFilePath)

                            End If

                        End If

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL登録テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            ' 戻り値を設定（正常終了）
            RegisterDLL = False

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6affe531-11f4-4232-84f4-1bf63794a246
            'PROC_END:

            'Call gsubClearObject(objDysDLL登録テーブル)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6affe531-11f4-4232-84f4-1bf63794a246
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
PROC_FINALLY_END:
        Call gsubClearObject(objDysDLL登録テーブル)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : msubRegistServer
    ' スコープ  : Public
    ' 処理内容  : レジストリ 登録処理
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintExecuteKbn      Integer           I     拡張子区分(0:DLL,1:EXE)
    '   pstrRegFilePath     String            I     ファイルパス
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Private Sub msubRegistServer(ByVal pintExecuteKbn As Short, ByVal pstrRegFilePath As String)

        '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubRegistServer"
        Dim strCommandLine As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        'Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubRegistServer"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

        Try

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strCommandLine As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 登録対象となるファイルが存在しない場合
            If gfncCheckFileExists(pstrRegFilePath) = False Then

                '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
                'GoTo PROC_END
                Exit Sub
                '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

            End If

            ' 拡張子がＤＬＬの場合
            If pintExecuteKbn = MC_EXECUTE_DLL Then

                '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
                strCommandLine = MC_CMD_REGSVR32 & " /s " & pstrRegFilePath
                'strCommandLine = MC_CMD_REGSVR32 & " " & pstrRegFilePath
                '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

                ' 拡張子がＥＸＥの場合
            ElseIf pintExecuteKbn = MC_EXECUTE_EXE Then

                strCommandLine = pstrRegFilePath & " " & MC_PRAM_REGSVR

                ' 上記以外の場合
            Else

                '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
                'GoTo PROC_END
                Exit Sub
                '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

            End If

            Debug.Print(strCommandLine)

            ' レジストリに登録
            If gfncExecWait(strCommandLine, AppWinStyle.Hide) = False Then

                '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
                'GoTo PROC_END
                Exit Sub
                '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

            End If

        Catch ex As Exception
            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

    End Sub
    '******************************************************************************
    ' 関 数 名  : msubUnRegistServer
    ' スコープ  : Public
    ' 処理内容  : レジストリ 登録解除処理
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintExecuteKbn      Integer           I     拡張子区分(0:DLL,1:EXE)
    '   pstrRegFilePath     String            I     ファイルパス
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Private Sub msubUnRegistServer(ByVal pintExecuteKbn As Short, ByVal pstrRegFilePath As String)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubUnRegistServer"
        Dim strCommandLine As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubUnRegistServer"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strCommandLine As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 登録対象となるファイルが存在しない場合
            If gfncCheckFileExists(pstrRegFilePath) = False Then

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            ' 拡張子がＤＬＬの場合
            If pintExecuteKbn = MC_EXECUTE_DLL Then

                strCommandLine = MC_CMD_REGSVR32 & " /u /s " & pstrRegFilePath

                ' 拡張子がＥＸＥの場合
            ElseIf pintExecuteKbn = MC_EXECUTE_EXE Then

                strCommandLine = pstrRegFilePath & " " & MC_PRAM_UN_REGSVR

                ' 上記以外の場合
            Else

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            Debug.Print(strCommandLine)

            ' レジストリに登録
            If gfncExecWait(strCommandLine, AppWinStyle.Hide) = False Then

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1a00ea25-bb11-4192-9149-f43bb085bedb
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3fd7d54-76eb-48f1-9259-e26a42691f60

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' プロパティ
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : SystemName
    ' スコープ  : Public
    ' 処理内容  : ＤＬＬ登録対象 システム名 設定
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ＤＬＬ登録対象 システム名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public WriteOnly Property SystemName() As String
        Set(ByVal Value As String)

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsRegisterDLL_Let_SystemName"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Let_SystemName"
                '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

                mstrSystemName = Value

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
                'PROC_END:

                'Exit Property

                '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
            Catch ex As Exception
                '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:481479b9-ce09-4364-99b5-5c21d21ecafb
                'Resume PROC_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:481479b9-ce09-4364-99b5-5c21d21ecafb

                '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:481479b9-ce09-4364-99b5-5c21d21ecafb
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:481479b9-ce09-4364-99b5-5c21d21ecafb
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Set
    End Property
End Class

