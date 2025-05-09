Option Strict Off
Option Explicit On
Friend Class clsUnitMstAccount
	'******************************************************************************
	' ÌßÛ¼Þª¸Ä¼  : GPCVXe¤Ê
	' t@C¼  : UnitMstAccount.cls
	' à    e    : ûÀÔ}X^ îñ i[ NX W[
	' õ    l    : gp·éÛÉÍ, ConstMstAccount.basàvWFNgÉÇÁ
	' Öê    : <Public>
	'                   DBConnect              (caÚ±)
	'                   DBObjectSet            (caIuWFNgÝè)
	'                   SetAccountInfo         (ûÀÔ}X^  îñ Ýè)
	'                   SetComboItem           (ûÀÔR{  Ýè)
	'                   SetComboListIndex      (ûÀÔR{ XgCfbNX Ýè)
	'               <Private>
	'               <Property>
	'                                      O
	'                   âsR[h             O
	'                   âs¼                 O
	'                   xXR[h             O
	'                   xX¼                 O
	'                   ûÀíÊ               O
	'                   ûÀíÊ¼             O
	'                   ûÀÔ               O
	'                   p[tFNgûÀ       O
	'                   R{\¦tO       O
	'                   UæïÐR[h       O
	'               <Events>
	'                   Class_Initialize       (NXúÝè)
	'                   Class_Terminate        (caØf)
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'   01.01       2008/04/21  Aä  F¾         @p[tFNgûÀÌÎ
	'                                              AUæïÐR[hÌÇÁ
	'   01.02       2008/05/21  Aä  F¾         VXeæªðÇÁ(|¿ÇVXeÅàgp·é×)
	'   01.03       2008/07/22  Aä  F¾         R{\¦tOðÇÁ
	'
	'******************************************************************************
	'==============================================================================
	' ñÌ
	'==============================================================================
	Public Enum SystemKbn
		¢wè = -1
		^sÇ = 0
		|¿Ç = 1
		ÝtàÇ = 2
	End Enum
	
	'==============================================================================
	' \¢Ì
	'==============================================================================
	'----------------------------------
	Private Structure TAG_AccountInfo ' Uæîñ
		'----------------------------------
		Dim mTstrAÔ As String
		Dim mTstrâsR[h As String
		Dim mTstrâs¼ As String
		Dim mTstrxXR[h As String
		Dim mTstrxX¼ As String
		Dim mTstrûÀíÊ As String
		Dim mTstrûÀíÊ¼ As String
		Dim mTstrûÀÔ As String
		Dim mTintp[tFNgûÀ As Short
		Dim mTintR{\¦tO As Short
		Dim mTstrUæïÐR[h As String
	End Structure
	
	'==============================================================================
	' Ï
	'==============================================================================
	Private marecAccountInfo() As TAG_AccountInfo ' ûÀîñ
	Private mobjOraSession As Object ' Oracle
	Private mobjOraDatabase As Object ' Oracle
	Private mblnDBConnect As Boolean ' DBÚ±tO(TrueFÚ±)
	Private mblnDBObject As Boolean ' DBÚ±IuWFNgÝètO(TrueFÝè)
	Private mblnDataSet As Boolean ' îñÝètO(TrueFÝè)
	Private mintAccountCount As Short ' f[^
	Private mintVXeæª As Short ' ^ÇÆ|¿ðØÖéæª(0:^Ç,1:|¿)
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' Cxg
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' Ö  ¼  : Class_Initialize
	' XR[v  : Public
	' àe  : ¿ ó ïÐîñ NX úÝè
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Class_Initialize"
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		' zñÄè`
		'UPGRADE_WARNING: Lower bound of array marecAccountInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim marecAccountInfo(99)
		
		mblnDBConnect = False
		mblnDBObject = False
		mblnDataSet = False
		mintAccountCount = 0
		
		mintVXeæª = SystemKbn.^sÇ
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:01e98535-789f-4668-a13e-e4bee50028a0
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:01e98535-789f-4668-a13e-e4bee50028a0
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7d37542-bd56-4c3f-a251-65bdd693b854
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	'******************************************************************************
	' Ö  ¼  : Class_Terminate
	' XR[v  : Public
	' àe  : caØf
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Class_Terminate"
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		Erase marecAccountInfo
		
		If mblnDBConnect = True Then
			
			Call gsubClearObject(mobjOraSession)
			
			Call gsubClearObject(mobjOraDatabase)
			
		End If
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7d37542-bd56-4c3f-a251-65bdd693b854
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' \bh
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' Ö  ¼  : DBConnect
	' XR[v  : Public
	' àe  : caÚ±
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrUserName        String            I     [U¼
	'   pstrPassWord        String            I     pX[h
	'   pstrTNS             String            I     smr¼
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBConnect"
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)
		
		mblnDBConnect = True
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	'******************************************************************************
	' Ö  ¼  : DBObjectClear
	' XR[v  : Public
	' àe  : caIuWFNgJú
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2009/01/21  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public Sub DBObjectClear()
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBObjectClear"
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		'UPGRADE_NOTE: Object mobjOraSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mobjOraSession = Nothing
		
		'UPGRADE_NOTE: Object mobjOraDatabase may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mobjOraDatabase = Nothing
		
		mblnDBObject = False
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	'******************************************************************************
	' Ö  ¼  : DBObjectSet
	' XR[v  : Public
	' àe  : caIuWFNgÝè
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pobjSession         Object            I     OraSession
	'   pobjDatabase        Object            I     OraDatabase
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBObjectSet"
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		mobjOraSession = pobjSession
		
		mobjOraDatabase = pobjDatabase
		
		mblnDBObject = True
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	'******************************************************************************
	' Ö  ¼  : SetAccountInfo
	' XR[v  : Public
	' àe  : ûÀÔ}X^ îñ Ýè
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public Sub SetAccountInfo()
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_SetAccountInfo"
		Dim objDysKZB_M As Object ' ûÀÔ}X^ÌOraDynaset
		Dim strSQL As String
		Dim intIdx As Short
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		
		If mblnDBConnect = False And mblnDBObject = False Then
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Lower bound of array marecAccountInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim marecAccountInfo(99)
		
		mblnDataSet = False
		mintAccountCount = 0
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    KZB_M.âsR[h      , "
		strSQL = strSQL & Chr(10) & "    GK_M.âs¼¿       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.xXR[h      , "
		strSQL = strSQL & Chr(10) & "    ST_M.xX¼¿       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.ûÀíÊ        , "
		strSQL = strSQL & Chr(10) & "    MS_M.ûÀíÊ¼       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.ûÀÔ        , "
		strSQL = strSQL & Chr(10) & "    KZB_M.p[tFNgûÀ, "
		strSQL = strSQL & Chr(10) & "    KZB_M.R{\¦tO, "
		strSQL = strSQL & Chr(10) & "    KZB_M.UæïÐR[h  "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    ûÀÔ}X^ KZB_M, "
		strSQL = strSQL & Chr(10) & "    âs}X^     GK_M , "
		strSQL = strSQL & Chr(10) & "    xX}X^     ST_M , "
		strSQL = strSQL & Chr(10) & "    ( "
		strSQL = strSQL & Chr(10) & "        SELECT "
		strSQL = strSQL & Chr(10) & "            R[h     ûÀíÊ  , "
		strSQL = strSQL & Chr(10) & "            ¼Ì¿   ûÀíÊ¼  "
		strSQL = strSQL & Chr(10) & "        FROM "
		strSQL = strSQL & Chr(10) & "            ¼Ì}X^ "
		strSQL = strSQL & Chr(10) & "        WHERE "
		strSQL = strSQL & Chr(10) & "            ¯Ê = 'ûÀíÊ' "
		strSQL = strSQL & Chr(10) & "    ) MS_M "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    KZB_M.âsR[h   = GK_M.âsR[h(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.âsR[h   = ST_M.âsR[h(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.xXR[h   = ST_M.xXR[h(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.ûÀíÊ     = MS_M.ûÀíÊ  (+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.VXeæª = '" & CStr(mintVXeæª) & "' "
		strSQL = strSQL & Chr(10) & "ORDER BY "
		strSQL = strSQL & Chr(10) & "    KZB_M.\¦    , "
		strSQL = strSQL & Chr(10) & "    KZB_M.âsR[h, "
		strSQL = strSQL & Chr(10) & "    KZB_M.xXR[h, "
		strSQL = strSQL & Chr(10) & "    KZB_M.ûÀíÊ  , "
		strSQL = strSQL & Chr(10) & "    KZB_M.ûÀÔ    "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysKZB_M = mobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysKZB_M
			
			intIdx = 1
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Do Until .EOF = True
				
				If intIdx <= 99 Then
					
					marecAccountInfo(intIdx).mTstrAÔ = VB6.Format(CStr(intIdx), "00")
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrâsR[h = gfncFieldVal(.Fields("âsR[h").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrâs¼ = gfncFieldVal(.Fields("âs¼¿").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrxXR[h = gfncFieldVal(.Fields("xXR[h").Value)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(xXR[h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If gfncFieldVal(.Fields("xXR[h").Value) <> "" Then
						
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(xX¼¿).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If gfncFieldVal(.Fields("xX¼¿").Value) = "{X" Then
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							marecAccountInfo(intIdx).mTstrxX¼ = gfncFieldVal(.Fields("xX¼¿").Value)
							
						Else
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							marecAccountInfo(intIdx).mTstrxX¼ = gfncFieldVal(.Fields("xX¼¿").Value) & "xX"
							
						End If
						
					End If
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrûÀíÊ = gfncFieldVal(.Fields("ûÀíÊ").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrûÀíÊ¼ = gfncFieldVal(.Fields("ûÀíÊ¼").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrûÀÔ = gfncFieldVal(.Fields("ûÀÔ").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTintp[tFNgûÀ = gfncFieldCur(.Fields("p[tFNgûÀ").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTintR{\¦tO = gfncFieldCur(.Fields("R{\¦tO").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstrUæïÐR[h = gfncFieldVal(.Fields("UæïÐR[h").Value)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Select Case Right(.Fields("âs¼¿").Value, 2)
						
						Case "àÉ", "Mõ", "Mà", "g", "_¦"
							
							' Èµ
							
						Case Else
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(xXR[h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If gfncFieldVal(.Fields("xXR[h").Value) <> "" Then
								
								marecAccountInfo(intIdx).mTstrâs¼ = marecAccountInfo(intIdx).mTstrâs¼ & "âs"
								
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
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
'PROC_END:
		
	'Call gsubClearObject(objDysKZB_M)
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	PROC_FINALLY_END:
		Call gsubClearObject(objDysKZB_M)
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	'******************************************************************************
	' Ö  ¼  : SetComboItem
	' XR[v  : Public
	' àe  : ûÀÔR{  Ýè
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pcboTarget          ComboBox          O     UûÀR{
	'   pintComboSetOff     Integer           I     R{\¦tO»è(0:»èÈµ, 1:»è è)
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/05/24  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public Sub SetComboItem(ByRef pcboTarget As System.Windows.Forms.ComboBox, Optional ByVal pintComboSetOff As Short = GC_FLG_OFF)
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_SetComboItem"
		Dim intIdx As Short
		Dim strNumber As String
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
            '--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·



            Call pcboTarget.Items.Clear()
            '++C³Jn@2021N0930ú:MKièj- VB¨VB.NETÏ·
            pcboTarget.Text = ""
            '--C³Jn@2021N0930ú:MKièj- VB¨VB.NETÏ·

            For intIdx = 1 To mintAccountCount
			
			strNumber = VB6.Format(CStr(intIdx), "00")
			
			With marecAccountInfo(intIdx)
				
				' »èÈµÌê
				If pintComboSetOff = GC_FLG_OFF Then
					
					Call pcboTarget.Items.Add(strNumber & " : " & .mTstrâs¼ & "  " & .mTstrxX¼ & "  " & .mTstrûÀíÊ¼ & "  " & .mTstrûÀÔ)
					
					' »è èÌê
				Else
					
					' R{\¦tOª0(\¦ è)Ìê
					If .mTintR{\¦tO = 0 Then
						
						Call pcboTarget.Items.Add(strNumber & " : " & .mTstrâs¼ & "  " & .mTstrxX¼ & "  " & .mTstrûÀíÊ¼ & "  " & .mTstrûÀÔ)
						
					End If
					
				End If
				
			End With
			
		Next intIdx
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	'******************************************************************************
	' Ö  ¼  : SetComboListIndex
	' XR[v  : Public
	' àe  : ûÀÔR{ XgCfbNX Ýè
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     âsR[h
	'   pstrBranchCode      String            I     xXR[h
	'   pstrAccountKind     String            I     ûÀíÊ
	'   pstrAccountNo       String            I     ûÀÔ
	'   pcboTarget          ComboBox          I     UûÀR{
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/05/24  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public Sub SetComboListIndex(ByVal pstrBankCode As String, ByVal pstrBranchCode As String, ByVal pstrAccountKind As String, ByVal pstrAccountNo As String, ByRef pcboTarget As System.Windows.Forms.ComboBox)
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'On Error GoTo PROC_ERROR
'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Const C_NAME_FUNCTION As String = "SetComboListIndex"
		Dim intIdx As Short
		Dim strRecNum As String
		Dim blnSearchHit As Boolean
'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
	Try
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		
		
		If Len(pstrBankCode) = 0 And Len(pstrBranchCode) = 0 And Len(pstrAccountKind) = 0 And Len(pstrAccountNo) = 0 Then
			
			pcboTarget.SelectedIndex = -1
			
			Exit Sub
			
		End If
		
		blnSearchHit = False
		
		For intIdx = 1 To mintAccountCount
			
			strRecNum = VB6.Format(intIdx, "00")
			
			With marecAccountInfo(intIdx)
				
				' Y·éf[^ð©Â¯½ê
				If .mTstrâsR[h = pstrBankCode And .mTstrxXR[h = pstrBranchCode And .mTstrûÀíÊ = pstrAccountKind And .mTstrûÀÔ = pstrAccountNo Then
					
					Call gsubSetComboListIndex(pcboTarget, strRecNum, GC_LEN_PAY_ACCOUNT)
					
					blnSearchHit = True
					
					Exit For
					
				End If
				
			End With
			
		Next intIdx
		
		If blnSearchHit = False Then
			
			pcboTarget.Text = ""
			
		End If
		
		
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
'PROC_END:
		
	'Exit Sub
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	'PROC_ERROR:
'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	Catch ex As Exception
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		'Resume PROC_END
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
		'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
		
	'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Try
	'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	PROC_FINALLY_END:
		Exit Sub
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
	End Sub
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' vpeB
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' Ö  ¼  : VXeæª
	' XR[v  : Public
	' àe  : VXeæª Ýè
	' õ    l  :
	' Ô è l  : Èµ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pintValue           Integer           I     VXe À
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public WriteOnly Property VXeæª() As Short
		Set(ByVal Value As Short)
			
			mintVXeæª = Value
			
		End Set
	End Property
	'******************************************************************************
	' Ö  ¼  : 
	' XR[v  : Public
	' àe  : ûÀÔ îñ  æ¾
	' õ    l  :
	' Ô è l  : ûÀÔ îñ 
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property () As Short
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_"
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			 = mintAccountCount
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : âsR[h
	' XR[v  : Public
	' àe  : âsR[h æ¾
	' õ    l  :
	' Ô è l  : âsR[h
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property âsR[h(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_âsR[h"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			âsR[h = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					âsR[h = marecAccountInfo(intIdx).mTstrâsR[h
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:88cabacc-f477-48e5-8347-377f07469a29
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:88cabacc-f477-48e5-8347-377f07469a29
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:88cabacc-f477-48e5-8347-377f07469a29
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:88cabacc-f477-48e5-8347-377f07469a29
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : âs¼
	' XR[v  : Public
	' àe  : âs¼ æ¾
	' õ    l  :
	' Ô è l  : âs¼
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property âs¼(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_âs¼"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			âs¼ = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					âs¼ = marecAccountInfo(intIdx).mTstrâs¼
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:88cabacc-f477-48e5-8347-377f07469a29
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:88cabacc-f477-48e5-8347-377f07469a29
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:b35cc457-241e-45fd-884c-d7949c79b0e3
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : xXR[h
	' XR[v  : Public
	' àe  : xXR[h æ¾
	' õ    l  :
	' Ô è l  : xXR[h
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property xXR[h(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_xXR[h"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			xXR[h = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					xXR[h = marecAccountInfo(intIdx).mTstrxXR[h
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:b35cc457-241e-45fd-884c-d7949c79b0e3
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3a48f317-960a-4c3e-882a-91f8527a5140
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3a48f317-960a-4c3e-882a-91f8527a5140
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3a48f317-960a-4c3e-882a-91f8527a5140
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3a48f317-960a-4c3e-882a-91f8527a5140
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : xX¼
	' XR[v  : Public
	' àe  : xX¼ æ¾
	' õ    l  :
	' Ô è l  : xX¼
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property xX¼(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_xX¼"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			xX¼ = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					xX¼ = marecAccountInfo(intIdx).mTstrxX¼
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3a48f317-960a-4c3e-882a-91f8527a5140
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3a48f317-960a-4c3e-882a-91f8527a5140
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:cd239302-b018-49f8-96b5-71689c5cee46
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:cd239302-b018-49f8-96b5-71689c5cee46
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:cd239302-b018-49f8-96b5-71689c5cee46
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:cd239302-b018-49f8-96b5-71689c5cee46
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : ûÀíÊ
	' XR[v  : Public
	' àe  : ûÀíÊ æ¾
	' õ    l  :
	' Ô è l  : ûÀíÊ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property ûÀíÊ(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_ûÀíÊ"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			ûÀíÊ = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					ûÀíÊ = marecAccountInfo(intIdx).mTstrûÀíÊ
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:cd239302-b018-49f8-96b5-71689c5cee46
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:cd239302-b018-49f8-96b5-71689c5cee46
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : ûÀíÊ¼
	' XR[v  : Public
	' àe  : ûÀíÊ¼ æ¾
	' õ    l  :
	' Ô è l  : ûÀíÊ¼
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property ûÀíÊ¼(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_ûÀíÊ¼"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			ûÀíÊ¼ = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					ûÀíÊ¼ = marecAccountInfo(intIdx).mTstrûÀíÊ¼
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:87a172f1-40ed-463a-a50a-7842fdd71447
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:87a172f1-40ed-463a-a50a-7842fdd71447
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:87a172f1-40ed-463a-a50a-7842fdd71447
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:87a172f1-40ed-463a-a50a-7842fdd71447
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : ûÀÔ
	' XR[v  : Public
	' àe  : ûÀÔ æ¾
	' õ    l  :
	' Ô è l  : ûÀÔ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property ûÀÔ(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_ûÀÔ"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			ûÀÔ = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					ûÀÔ = marecAccountInfo(intIdx).mTstrûÀÔ
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:87a172f1-40ed-463a-a50a-7842fdd71447
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:87a172f1-40ed-463a-a50a-7842fdd71447
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : p[tFNgûÀ
	' XR[v  : Public
	' àe  : p[tFNgûÀ æ¾
	' õ    l  :
	' Ô è l  : p[tFNgûÀ
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property p[tFNgûÀ(ByVal pstrIndex As String) As Short
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_p[tFNgûÀ"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			p[tFNgûÀ = GC_FLG_OFF
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					p[tFNgûÀ = marecAccountInfo(intIdx).mTintp[tFNgûÀ
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
	'******************************************************************************
	' Ö  ¼  : UæïÐR[h
	' XR[v  : Public
	' àe  : UæïÐR[h æ¾
	' õ    l  :
	' Ô è l  : UæïÐR[h
	' ø «   :
	'   Êß×Ò°À¼            ÃÞ°ÀÀ²Ìß          I/O   à ¾
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     ûÀÔîñÌCfbNX
	'
	' ÏXð  :
	'   Version     ú  t        ¼             C³àe
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  Aä  F¾         VKì¬
	'
	'******************************************************************************
	Public ReadOnly Property UæïÐR[h(ByVal pstrIndex As String) As String
		Get
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'On Error GoTo PROC_ERROR
	'++C³Jn@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_UæïÐR[h"
			Dim intIdx As Short
	'--C³I¹@2021N0613:MKic[j- VB_530 VB¨VB.NETÏ·
		Try
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			
			
			UæïÐR[h = CStr(GC_FLG_OFF)
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstrAÔ = pstrIndex Then
					
					UæïÐR[h = marecAccountInfo(intIdx).mTstrUæïÐR[h
					
					Exit For
					
				End If
				
			Next intIdx
			
'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
'PROC_END:
			
		'Exit Property
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		'PROC_ERROR:
	'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		Catch ex As Exception
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++C³Jn@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			'Resume PROC_END
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
			'--C³I¹@2021N0605:MKic[j- VB_003 VB¨VB.NETÏ·
			
		'++C³Jn@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
			End Try
		'++C³Jn@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		PROC_FINALLY_END:
			Exit Property
		'--C³I¹@2021N0613:MKic[j- VB_523 VB¨VB.NETÏ·	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		'--C³I¹@2021N0613:MKic[j- VB_522 VB¨VB.NETÏ·
		End Get
	End Property
End Class
