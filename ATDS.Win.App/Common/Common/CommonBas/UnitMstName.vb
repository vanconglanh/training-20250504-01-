Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstName
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
	' ファイル名  : UnitMstName.cls
	' 内    容    : 名称マスタ 情報 格納 クラス モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'                   DBConnect              (ＤＢ接続)
	'                   DBObjectSet            (ＤＢオブジェクト設定)
	'                   SetNameInfo            (名称マスタ 設定)
	'               <Private>
	'               <Property>
	'                   識別                   I/O
	'                   コード                 I/O
	'                   名称漢字               I/O
	'                   名称カナ               I/O
	'                   略称                   I/O
	'                   係数１                 I/O
	'                   係数２                 I/O
	'               <Events>
	'                   Class_Initialize       (クラス初期設定)
	'                   Class_Terminate        (ＤＢ切断)
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'==============================================================================
	' 定数
	'==============================================================================
	Private Const MC_TABLE_名称マスタ As String = "名称マスタ"
	
	'==============================================================================
	' 変数
	'==============================================================================
	'++修正開始　2021年06月20:MK（ツール）- OR_005 VB→VB.NET変換
	'Private mobjOraSession As Object ' Oracle
	Private mobjOraSession As OraSession ' Oracle
	'--修正終了　2021年06月20:MK（ツール）- OR_005 VB→VB.NET変換
	'++修正開始　2021年06月20:MK（ツール）- OR_002 VB→VB.NET変換
	'Private mobjOraDatabase As Object ' Oracle
	Private mobjOraDatabase As OraDatabase ' Oracle
	'--修正終了　2021年06月20:MK（ツール）- OR_002 VB→VB.NET変換
	Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)
	Private mblnDBObject As Boolean ' DB接続オブジェクト設定フラグ(True：設定)
	
	Private mstr識別 As String
	Private mstrコード As String
	Private mstr名称漢字 As String
	Private mstr名称カナ As String
	Private mstr略称 As String
	Private mcur係数1 As Decimal
	Private mcur係数2 As Decimal
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' イベント
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' 関 数 名  : Class_Initialize
	' スコープ  : Public
	' 処理内容  : 名称マスタ 情報 格納 クラス 初期設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstName_Class_Initialize"
'--修正終了　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		mblnDBConnect = False
		
		mblnDBObject = False
		
		mstr識別 = ""
		mstrコード = ""
		mstr名称漢字 = ""
		mstr名称カナ = ""
		mstr略称 = ""
		mcur係数1 = 0
		mcur係数2 = 0
		
'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:6983b1b2-bfd5-425f-8f56-edaa9c2b95c5
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:6983b1b2-bfd5-425f-8f56-edaa9c2b95c5
	Catch ex As Exception
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
		'--修正終了　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
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
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstName_Class_Terminate"
'--修正終了　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		If mblnDBConnect = True Then
			
			Call gsubClearObject(mobjOraDatabase)
			
			Call gsubClearObject(mobjOraSession)
			
		End If
		
'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	Catch ex As Exception
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
		'--修正終了　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
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
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstName_DBConnect"
'--修正終了　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		'++修正開始　2021年06月20:MK（ツール）- OR_005 VB→VB.NET変換
		'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
		mobjOraSession = New OraSession() 
		'--修正終了　2021年06月20:MK（ツール）- OR_005 VB→VB.NET変換
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)
		
		mblnDBConnect = True
		
'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	Catch ex As Exception
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
		'--修正終了　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
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
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstName_DBObjectSet"
'--修正終了　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		mobjOraSession = pobjSession
		
		mobjOraDatabase = pobjDatabase
		
		mblnDBObject = True
		
'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	Catch ex As Exception
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:169b835d-dc84-421e-aabc-40b9113c379e
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:169b835d-dc84-421e-aabc-40b9113c379e
		'--修正終了　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:169b835d-dc84-421e-aabc-40b9113c379e
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:169b835d-dc84-421e-aabc-40b9113c379e
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub
	'******************************************************************************
	' 関 数 名  : SetNameInfo
	' スコープ  : Public
	' 処理内容  : 名称マスタ 設定
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrShikibetu       String            I     識別
	'   pstrCode            String            I     コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function SetNameInfo(ByVal pstrShikibetu As String, ByVal pstrCode As String) As Boolean
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstName_SetNameInfo"
		'++修正開始　2021年06月20:MK（ツール）- OR_003 VB→VB.NET変換
		'Dim objDysTemp As Object
		Dim objDysTemp As OraDynaset
		'--修正終了　2021年06月20:MK（ツール）- OR_003 VB→VB.NET変換
		Dim strSQL As String
'--修正終了　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		
		' 戻り値を初期化（異常終了）
		SetNameInfo = True
		
		If mblnDBConnect = False And mblnDBObject = False Then
			Exit Function
		End If
		
		'砂時計ポインタを設定
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    識別    , "
		strSQL = strSQL & Chr(10) & "    コード  , "
		strSQL = strSQL & Chr(10) & "    名称漢字, "
		strSQL = strSQL & Chr(10) & "    名称カナ, "
		strSQL = strSQL & Chr(10) & "    略称    , "
		strSQL = strSQL & Chr(10) & "    係数１  , "
		strSQL = strSQL & Chr(10) & "    係数２    "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "   " & MC_TABLE_名称マスタ & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    識別   = '" & pstrShikibetu & "' "
		strSQL = strSQL & Chr(10) & "AND コード = '" & pstrCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysTemp
			
			' 該当するデータが存在する場合
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' 戻り値を設定（正常終了）
				SetNameInfo = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr識別 = gfncFieldVal(.Fields("識別").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstrコード = gfncFieldVal(.Fields("コード").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr名称漢字 = gfncFieldVal(.Fields("名称漢字").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr名称カナ = gfncFieldVal(.Fields("名称カナ").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr略称 = gfncFieldVal(.Fields("略称").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mcur係数1 = gfncFieldCur(.Fields("係数１").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mcur係数2 = gfncFieldCur(.Fields("係数２").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
		
'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:169b835d-dc84-421e-aabc-40b9113c379e
'PROC_END:
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	'Call gsubClearObject(objDysTemp)
		
	'Exit Function
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:169b835d-dc84-421e-aabc-40b9113c379e
	Catch ex As Exception
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:984e7777-4119-4dab-ac90-d9f38910362f
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:984e7777-4119-4dab-ac90-d9f38910362f
		'--修正終了　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:984e7777-4119-4dab-ac90-d9f38910362f
	PROC_FINALLY_END:
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		Call gsubClearObject(objDysTemp)
		Exit Function
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:984e7777-4119-4dab-ac90-d9f38910362f
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' プロパティ
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' 関 数 名  : 識別
	' スコープ  : Public
	' 処理内容  : 識別 取得
	' 備    考  :
	' 返 り 値  : 識別
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : 識別
	' スコープ  : Public
	' 処理内容  : 識別 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     識別
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property 識別() As String
		Get
			
			識別 = mstr識別
			
		End Get
		Set(ByVal Value As String)
			
			mstr識別 = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : コード
	' スコープ  : Public
	' 処理内容  : コード 取得
	' 備    考  :
	' 返 り 値  : コード
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : コード
	' スコープ  : Public
	' 処理内容  : コード 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property コード() As String
		Get
			
			コード = mstrコード
			
		End Get
		Set(ByVal Value As String)
			
			mstrコード = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : 名称漢字
	' スコープ  : Public
	' 処理内容  : 名称漢字 取得
	' 備    考  :
	' 返 り 値  : 名称漢字
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : 名称漢字
	' スコープ  : Public
	' 処理内容  : 名称漢字 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     名称漢字
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property 名称漢字() As String
		Get
			
			名称漢字 = mstr名称漢字
			
		End Get
		Set(ByVal Value As String)
			
			mstr名称漢字 = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : 名称カナ
	' スコープ  : Public
	' 処理内容  : 名称カナ 取得
	' 備    考  :
	' 返 り 値  : 名称カナ
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : 名称カナ
	' スコープ  : Public
	' 処理内容  : 名称カナ 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     名称カナ
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property 名称カナ() As String
		Get
			
			名称カナ = mstr名称カナ
			
		End Get
		Set(ByVal Value As String)
			
			mstr名称カナ = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : 略称
	' スコープ  : Public
	' 処理内容  : 略称 取得
	' 備    考  :
	' 返 り 値  : 略称
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : 略称
	' スコープ  : Public
	' 処理内容  : 略称 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     略称
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property 略称() As String
		Get
			
			略称 = mstr略称
			
		End Get
		Set(ByVal Value As String)
			
			mstr略称 = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : 係数１
	' スコープ  : Public
	' 処理内容  : 係数１ 取得
	' 備    考  :
	' 返 り 値  : 係数１
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : 係数１
	' スコープ  : Public
	' 処理内容  : 係数１ 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pcurValue           Currency          I     係数１
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property 係数1() As Decimal
		Get
			
			係数1 = mcur係数1
			
		End Get
		Set(ByVal Value As Decimal)
			
			mcur係数1 = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : 係数２
	' スコープ  : Public
	' 処理内容  : 係数２ 取得
	' 備    考  :
	' 返 り 値  : 係数２
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : 係数２
	' スコープ  : Public
	' 処理内容  : 係数２ 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pcurValue           Currency          I     係数２
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Property 係数2() As Decimal
		Get
			
			係数2 = mcur係数2
			
		End Get
		Set(ByVal Value As Decimal)
			
			mcur係数2 = Value
			
		End Set
	End Property
End Class
