Option Strict Off
Option Explicit On
Friend Class clsUnitMstAccount
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : エムケイシステム共通
	' ファイル名  : UnitMstAccount.cls
	' 内    容    : 口座番号マスタ 情報 格納 クラス モジュール
	' 備    考    : 使用する際には, ConstMstAccount.basもプロジェクトに追加
	' 関数一覧    : <Public>
	'                   DBConnect              (ＤＢ接続)
	'                   DBObjectSet            (ＤＢオブジェクト設定)
	'                   SetAccountInfo         (口座番号マスタ  情報 設定)
	'                   SetComboItem           (口座番号コンボ  設定)
	'                   SetComboListIndex      (口座番号コンボ リストインデックス 設定)
	'               <Private>
	'               <Property>
	'                   件数                   O
	'                   銀行コード             O
	'                   銀行名                 O
	'                   支店コード             O
	'                   支店名                 O
	'                   口座種別               O
	'                   口座種別名             O
	'                   口座番号               O
	'                   パーフェクト口座       O
	'                   コンボ表示フラグ       O
	'                   振込先会社コード       O
	'               <Events>
	'                   Class_Initialize       (クラス初期設定)
	'                   Class_Terminate        (ＤＢ切断)
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'   01.01       2008/04/21  廣井  芳明         ①パーフェクト口座の対応
	'                                              ②振込先会社コードの追加
	'   01.02       2008/05/21  廣井  芳明         システム区分を追加(売掛請求管理システムでも使用する為)
	'   01.03       2008/07/22  廣井  芳明         コンボ表示フラグを追加
	'
	'******************************************************************************
	'==============================================================================
	' 列挙体
	'==============================================================================
	Public Enum SystemKbn
		未指定 = -1
		運行管理 = 0
		売掛請求管理 = 1
		貸付金管理 = 2
	End Enum
	
	'==============================================================================
	' 構造体
	'==============================================================================
	'----------------------------------
	Private Structure TAG_AccountInfo ' 振込先情報
		'----------------------------------
		Dim mTstr連番 As String
		Dim mTstr銀行コード As String
		Dim mTstr銀行名 As String
		Dim mTstr支店コード As String
		Dim mTstr支店名 As String
		Dim mTstr口座種別 As String
		Dim mTstr口座種別名 As String
		Dim mTstr口座番号 As String
		Dim mTintパーフェクト口座 As Short
		Dim mTintコンボ表示フラグ As Short
		Dim mTstr振込先会社コード As String
	End Structure
	
	'==============================================================================
	' 変数
	'==============================================================================
	Private marecAccountInfo() As TAG_AccountInfo ' 口座情報
	Private mobjOraSession As Object ' Oracle
	Private mobjOraDatabase As Object ' Oracle
	Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)
	Private mblnDBObject As Boolean ' DB接続オブジェクト設定フラグ(True：設定)
	Private mblnDataSet As Boolean ' 情報設定フラグ(True：設定)
	Private mintAccountCount As Short ' データ件数
	Private mintシステム区分 As Short ' 運管と売掛請求を切替る区分(0:運管,1:売掛請求)
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' イベント
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' 関 数 名  : Class_Initialize
	' スコープ  : Public
	' 処理内容  : 請求書 印字 会社情報 クラス 初期設定
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
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Class_Initialize"
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		' 配列再定義
		'UPGRADE_WARNING: Lower bound of array marecAccountInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim marecAccountInfo(99)
		
		mblnDBConnect = False
		mblnDBObject = False
		mblnDataSet = False
		mintAccountCount = 0
		
		mintシステム区分 = SystemKbn.運行管理
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:01e98535-789f-4668-a13e-e4bee50028a0
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:01e98535-789f-4668-a13e-e4bee50028a0
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7d37542-bd56-4c3f-a251-65bdd693b854
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
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
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Class_Terminate"
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		Erase marecAccountInfo
		
		If mblnDBConnect = True Then
			
			Call gsubClearObject(mobjOraSession)
			
			Call gsubClearObject(mobjOraDatabase)
			
		End If
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7d37542-bd56-4c3f-a251-65bdd693b854
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
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
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBConnect"
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)
		
		mblnDBConnect = True
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub
	'******************************************************************************
	' 関 数 名  : DBObjectClear
	' スコープ  : Public
	' 処理内容  : ＤＢオブジェクト開放
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2009/01/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub DBObjectClear()
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBObjectClear"
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		'UPGRADE_NOTE: Object mobjOraSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mobjOraSession = Nothing
		
		'UPGRADE_NOTE: Object mobjOraDatabase may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mobjOraDatabase = Nothing
		
		mblnDBObject = False
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
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
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBObjectSet"
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		mobjOraSession = pobjSession
		
		mobjOraDatabase = pobjDatabase
		
		mblnDBObject = True
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub
	'******************************************************************************
	' 関 数 名  : SetAccountInfo
	' スコープ  : Public
	' 処理内容  : 口座番号マスタ 情報 設定
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
	Public Sub SetAccountInfo()
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_SetAccountInfo"
		Dim objDysKZB_M As Object ' 口座番号マスタのOraDynaset
		Dim strSQL As String
		Dim intIdx As Short
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		
		If mblnDBConnect = False And mblnDBObject = False Then
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Lower bound of array marecAccountInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim marecAccountInfo(99)
		
		mblnDataSet = False
		mintAccountCount = 0
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    KZB_M.銀行コード      , "
		strSQL = strSQL & Chr(10) & "    GK_M.銀行名漢字       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.支店コード      , "
		strSQL = strSQL & Chr(10) & "    ST_M.支店名漢字       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.口座種別        , "
		strSQL = strSQL & Chr(10) & "    MS_M.口座種別名       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.口座番号        , "
		strSQL = strSQL & Chr(10) & "    KZB_M.パーフェクト口座, "
		strSQL = strSQL & Chr(10) & "    KZB_M.コンボ表示フラグ, "
		strSQL = strSQL & Chr(10) & "    KZB_M.振込先会社コード  "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    口座番号マスタ KZB_M, "
		strSQL = strSQL & Chr(10) & "    銀行マスタ     GK_M , "
		strSQL = strSQL & Chr(10) & "    支店マスタ     ST_M , "
		strSQL = strSQL & Chr(10) & "    ( "
		strSQL = strSQL & Chr(10) & "        SELECT "
		strSQL = strSQL & Chr(10) & "            コード     口座種別  , "
		strSQL = strSQL & Chr(10) & "            名称漢字   口座種別名  "
		strSQL = strSQL & Chr(10) & "        FROM "
		strSQL = strSQL & Chr(10) & "            名称マスタ "
		strSQL = strSQL & Chr(10) & "        WHERE "
		strSQL = strSQL & Chr(10) & "            識別 = '口座種別' "
		strSQL = strSQL & Chr(10) & "    ) MS_M "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    KZB_M.銀行コード   = GK_M.銀行コード(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.銀行コード   = ST_M.銀行コード(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.支店コード   = ST_M.支店コード(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.口座種別     = MS_M.口座種別  (+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.システム区分 = '" & CStr(mintシステム区分) & "' "
		strSQL = strSQL & Chr(10) & "ORDER BY "
		strSQL = strSQL & Chr(10) & "    KZB_M.表示順    , "
		strSQL = strSQL & Chr(10) & "    KZB_M.銀行コード, "
		strSQL = strSQL & Chr(10) & "    KZB_M.支店コード, "
		strSQL = strSQL & Chr(10) & "    KZB_M.口座種別  , "
		strSQL = strSQL & Chr(10) & "    KZB_M.口座番号    "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysKZB_M = mobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysKZB_M
			
			intIdx = 1
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Do Until .EOF = True
				
				If intIdx <= 99 Then
					
					marecAccountInfo(intIdx).mTstr連番 = VB6.Format(CStr(intIdx), "00")
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr銀行コード = gfncFieldVal(.Fields("銀行コード").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr銀行名 = gfncFieldVal(.Fields("銀行名漢字").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr支店コード = gfncFieldVal(.Fields("支店コード").Value)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(支店コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If gfncFieldVal(.Fields("支店コード").Value) <> "" Then
						
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(支店名漢字).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If gfncFieldVal(.Fields("支店名漢字").Value) = "本店" Then
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							marecAccountInfo(intIdx).mTstr支店名 = gfncFieldVal(.Fields("支店名漢字").Value)
							
						Else
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							marecAccountInfo(intIdx).mTstr支店名 = gfncFieldVal(.Fields("支店名漢字").Value) & "支店"
							
						End If
						
					End If
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr口座種別 = gfncFieldVal(.Fields("口座種別").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr口座種別名 = gfncFieldVal(.Fields("口座種別名").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr口座番号 = gfncFieldVal(.Fields("口座番号").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTintパーフェクト口座 = gfncFieldCur(.Fields("パーフェクト口座").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTintコンボ表示フラグ = gfncFieldCur(.Fields("コンボ表示フラグ").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr振込先会社コード = gfncFieldVal(.Fields("振込先会社コード").Value)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Select Case Right(.Fields("銀行名漢字").Value, 2)
						
						Case "金庫", "信託", "信金", "組合", "農協"
							
							' 処理なし
							
						Case Else
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(支店コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If gfncFieldVal(.Fields("支店コード").Value) <> "" Then
								
								marecAccountInfo(intIdx).mTstr銀行名 = marecAccountInfo(intIdx).mTstr銀行名 & "銀行"
								
							End If
							
					End Select
					
				End If
				
				intIdx = intIdx + 1
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .MoveNext()
				
			Loop 
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
		mblnDataSet = True
		mintAccountCount = (intIdx - 1)
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
'PROC_END:
		
	'Call gsubClearObject(objDysKZB_M)
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	PROC_FINALLY_END:
		Call gsubClearObject(objDysKZB_M)
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub
	'******************************************************************************
	' 関 数 名  : SetComboItem
	' スコープ  : Public
	' 処理内容  : 口座番号コンボ  設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pcboTarget          ComboBox          O     振込口座コンボ
	'   pintComboSetOff     Integer           I     コンボ表示フラグ判定(0:判定なし, 1:判定あり)
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/05/24  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub SetComboItem(ByRef pcboTarget As System.Windows.Forms.ComboBox, Optional ByVal pintComboSetOff As Short = GC_FLG_OFF)
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_SetComboItem"
		Dim intIdx As Short
		Dim strNumber As String
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
            '--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換



            Call pcboTarget.Items.Clear()
            '++修正開始　2021年09月30日:MK（手）- VB→VB.NET変換
            pcboTarget.Text = ""
            '--修正開始　2021年09月30日:MK（手）- VB→VB.NET変換

            For intIdx = 1 To mintAccountCount
			
			strNumber = VB6.Format(CStr(intIdx), "00")
			
			With marecAccountInfo(intIdx)
				
				' 判定なしの場合
				If pintComboSetOff = GC_FLG_OFF Then
					
					Call pcboTarget.Items.Add(strNumber & " : " & .mTstr銀行名 & "  " & .mTstr支店名 & "  " & .mTstr口座種別名 & "  " & .mTstr口座番号)
					
					' 判定ありの場合
				Else
					
					' コンボ表示フラグが0(表示あり)の場合
					If .mTintコンボ表示フラグ = 0 Then
						
						Call pcboTarget.Items.Add(strNumber & " : " & .mTstr銀行名 & "  " & .mTstr支店名 & "  " & .mTstr口座種別名 & "  " & .mTstr口座番号)
						
					End If
					
				End If
				
			End With
			
		Next intIdx
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub
	'******************************************************************************
	' 関 数 名  : SetComboListIndex
	' スコープ  : Public
	' 処理内容  : 口座番号コンボ リストインデックス 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     銀行コード
	'   pstrBranchCode      String            I     支店コード
	'   pstrAccountKind     String            I     口座種別
	'   pstrAccountNo       String            I     口座番号
	'   pcboTarget          ComboBox          I     振込口座コンボ
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/05/24  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Sub SetComboListIndex(ByVal pstrBankCode As String, ByVal pstrBranchCode As String, ByVal pstrAccountKind As String, ByVal pstrAccountNo As String, ByRef pcboTarget As System.Windows.Forms.ComboBox)
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "SetComboListIndex"
		Dim intIdx As Short
		Dim strRecNum As String
		Dim blnSearchHit As Boolean
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		
		If Len(pstrBankCode) = 0 And Len(pstrBranchCode) = 0 And Len(pstrAccountKind) = 0 And Len(pstrAccountNo) = 0 Then
			
			pcboTarget.SelectedIndex = -1
			
			Exit Sub
			
		End If
		
		blnSearchHit = False
		
		For intIdx = 1 To mintAccountCount
			
			strRecNum = VB6.Format(intIdx, "00")
			
			With marecAccountInfo(intIdx)
				
				' 該当するデータを見つけた場合
				If .mTstr銀行コード = pstrBankCode And .mTstr支店コード = pstrBranchCode And .mTstr口座種別 = pstrAccountKind And .mTstr口座番号 = pstrAccountNo Then
					
					Call gsubSetComboListIndex(pcboTarget, strRecNum, GC_LEN_PAY_ACCOUNT)
					
					blnSearchHit = True
					
					Exit For
					
				End If
				
			End With
			
		Next intIdx
		
		If blnSearchHit = False Then
			
			pcboTarget.Text = ""
			
		End If
		
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
'PROC_END:
		
	'Exit Sub
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	PROC_FINALLY_END:
		Exit Sub
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' プロパティ
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' 関 数 名  : システム区分
	' スコープ  : Public
	' 処理内容  : システム区分 設定
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pintValue           Integer           I     システム権限
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public WriteOnly Property システム区分() As Short
		Set(ByVal Value As Short)
			
			mintシステム区分 = Value
			
		End Set
	End Property
	'******************************************************************************
	' 関 数 名  : 件数
	' スコープ  : Public
	' 処理内容  : 口座番号 情報 件数 取得
	' 備    考  :
	' 返 り 値  : 口座番号 情報 件数
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
	Public ReadOnly Property 件数() As Short
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_件数"
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			件数 = mintAccountCount
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 銀行コード
	' スコープ  : Public
	' 処理内容  : 銀行コード 取得
	' 備    考  :
	' 返 り 値  : 銀行コード
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 銀行コード(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_銀行コード"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			銀行コード = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					銀行コード = marecAccountInfo(intIdx).mTstr銀行コード
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:88cabacc-f477-48e5-8347-377f07469a29
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:88cabacc-f477-48e5-8347-377f07469a29
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:88cabacc-f477-48e5-8347-377f07469a29
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:88cabacc-f477-48e5-8347-377f07469a29
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 銀行名
	' スコープ  : Public
	' 処理内容  : 銀行名 取得
	' 備    考  :
	' 返 り 値  : 銀行名
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 銀行名(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_銀行名"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			銀行名 = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					銀行名 = marecAccountInfo(intIdx).mTstr銀行名
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:88cabacc-f477-48e5-8347-377f07469a29
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:88cabacc-f477-48e5-8347-377f07469a29
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:b35cc457-241e-45fd-884c-d7949c79b0e3
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 支店コード
	' スコープ  : Public
	' 処理内容  : 支店コード 取得
	' 備    考  :
	' 返 り 値  : 支店コード
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 支店コード(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_支店コード"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			支店コード = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					支店コード = marecAccountInfo(intIdx).mTstr支店コード
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:b35cc457-241e-45fd-884c-d7949c79b0e3
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3a48f317-960a-4c3e-882a-91f8527a5140
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3a48f317-960a-4c3e-882a-91f8527a5140
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3a48f317-960a-4c3e-882a-91f8527a5140
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3a48f317-960a-4c3e-882a-91f8527a5140
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 支店名
	' スコープ  : Public
	' 処理内容  : 支店名 取得
	' 備    考  :
	' 返 り 値  : 支店名
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 支店名(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_支店名"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			支店名 = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					支店名 = marecAccountInfo(intIdx).mTstr支店名
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3a48f317-960a-4c3e-882a-91f8527a5140
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3a48f317-960a-4c3e-882a-91f8527a5140
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:cd239302-b018-49f8-96b5-71689c5cee46
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:cd239302-b018-49f8-96b5-71689c5cee46
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:cd239302-b018-49f8-96b5-71689c5cee46
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:cd239302-b018-49f8-96b5-71689c5cee46
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 口座種別
	' スコープ  : Public
	' 処理内容  : 口座種別 取得
	' 備    考  :
	' 返 り 値  : 口座種別
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 口座種別(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_口座種別"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			口座種別 = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					口座種別 = marecAccountInfo(intIdx).mTstr口座種別
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:cd239302-b018-49f8-96b5-71689c5cee46
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:cd239302-b018-49f8-96b5-71689c5cee46
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 口座種別名
	' スコープ  : Public
	' 処理内容  : 口座種別名 取得
	' 備    考  :
	' 返 り 値  : 口座種別名
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 口座種別名(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_口座種別名"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			口座種別名 = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					口座種別名 = marecAccountInfo(intIdx).mTstr口座種別名
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:87a172f1-40ed-463a-a50a-7842fdd71447
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:87a172f1-40ed-463a-a50a-7842fdd71447
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:87a172f1-40ed-463a-a50a-7842fdd71447
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:87a172f1-40ed-463a-a50a-7842fdd71447
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 口座番号
	' スコープ  : Public
	' 処理内容  : 口座番号 取得
	' 備    考  :
	' 返 り 値  : 口座番号
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 口座番号(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_口座番号"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			口座番号 = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					口座番号 = marecAccountInfo(intIdx).mTstr口座番号
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:87a172f1-40ed-463a-a50a-7842fdd71447
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:87a172f1-40ed-463a-a50a-7842fdd71447
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : パーフェクト口座
	' スコープ  : Public
	' 処理内容  : パーフェクト口座 取得
	' 備    考  :
	' 返 り 値  : パーフェクト口座
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property パーフェクト口座(ByVal pstrIndex As String) As Short
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_パーフェクト口座"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			パーフェクト口座 = GC_FLG_OFF
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					パーフェクト口座 = marecAccountInfo(intIdx).mTintパーフェクト口座
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
	'******************************************************************************
	' 関 数 名  : 振込先会社コード
	' スコープ  : Public
	' 処理内容  : 振込先会社コード 取得
	' 備    考  :
	' 返 り 値  : 振込先会社コード
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     口座番号情報のインデックス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public ReadOnly Property 振込先会社コード(ByVal pstrIndex As String) As String
		Get
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
	'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_振込先会社コード"
			Dim intIdx As Short
	'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Try
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			
			
			振込先会社コード = CStr(GC_FLG_OFF)
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr連番 = pstrIndex Then
					
					振込先会社コード = marecAccountInfo(intIdx).mTstr振込先会社コード
					
					Exit For
					
				End If
				
			Next intIdx
			
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
'PROC_END:
			
		'Exit Property
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		'PROC_ERROR:
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		Catch ex As Exception
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			'Resume PROC_END
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
			'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
			
		'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
			End Try
		'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		PROC_FINALLY_END:
			Exit Property
		'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Get
	End Property
End Class
