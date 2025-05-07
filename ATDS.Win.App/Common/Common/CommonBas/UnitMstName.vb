Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstName
	'******************************************************************************
	' ��ۼު�Ė�  : �l�j�V�X�e������
	' �t�@�C����  : UnitMstName.cls
	' ��    �e    : ���̃}�X�^ ��� �i�[ �N���X ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'                   DBConnect              (�c�a�ڑ�)
	'                   DBObjectSet            (�c�a�I�u�W�F�N�g�ݒ�)
	'                   SetNameInfo            (���̃}�X�^ �ݒ�)
	'               <Private>
	'               <Property>
	'                   ����                   I/O
	'                   �R�[�h                 I/O
	'                   ���̊���               I/O
	'                   ���̃J�i               I/O
	'                   ����                   I/O
	'                   �W���P                 I/O
	'                   �W���Q                 I/O
	'               <Events>
	'                   Class_Initialize       (�N���X�����ݒ�)
	'                   Class_Terminate        (�c�a�ؒf)
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'==============================================================================
	' �萔
	'==============================================================================
	Private Const MC_TABLE_���̃}�X�^ As String = "���̃}�X�^"
	
	'==============================================================================
	' �ϐ�
	'==============================================================================
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
	'Private mobjOraSession As Object ' Oracle
	Private mobjOraSession As OraSession ' Oracle
	'--�C���I���@2021�N06��20:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
	'Private mobjOraDatabase As Object ' Oracle
	Private mobjOraDatabase As OraDatabase ' Oracle
	'--�C���I���@2021�N06��20:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
	Private mblnDBConnect As Boolean ' DB�ڑ��t���O(True�F�ڑ�)
	Private mblnDBObject As Boolean ' DB�ڑ��I�u�W�F�N�g�ݒ�t���O(True�F�ݒ�)
	
	Private mstr���� As String
	Private mstr�R�[�h As String
	Private mstr���̊��� As String
	Private mstr���̃J�i As String
	Private mstr���� As String
	Private mcur�W��1 As Decimal
	Private mcur�W��2 As Decimal
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' �C�x���g
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' �� �� ��  : Class_Initialize
	' �X�R�[�v  : Public
	' �������e  : ���̃}�X�^ ��� �i�[ �N���X �����ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstName_Class_Initialize"
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		mblnDBConnect = False
		
		mblnDBObject = False
		
		mstr���� = ""
		mstr�R�[�h = ""
		mstr���̊��� = ""
		mstr���̃J�i = ""
		mstr���� = ""
		mcur�W��1 = 0
		mcur�W��2 = 0
		
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6983b1b2-bfd5-425f-8f56-edaa9c2b95c5
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6983b1b2-bfd5-425f-8f56-edaa9c2b95c5
	Catch ex As Exception
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
		'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	'******************************************************************************
	' �� �� ��  : Class_Terminate
	' �X�R�[�v  : Public
	' �������e  : �c�a�ؒf
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstName_Class_Terminate"
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		If mblnDBConnect = True Then
			
			Call gsubClearObject(mobjOraDatabase)
			
			Call gsubClearObject(mobjOraSession)
			
		End If
		
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fbb361e9-cb21-4d20-907d-f318e93fbad2
	Catch ex As Exception
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
		'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' ���\�b�h
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' �� �� ��  : DBConnect
	' �X�R�[�v  : Public
	' �������e  : �c�a�ڑ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrUserName        String            I     ���[�U��
	'   pstrPassWord        String            I     �p�X���[�h
	'   pstrTNS             String            I     �s�m�r��
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstName_DBConnect"
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
		'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
		mobjOraSession = New OraSession() 
		'--�C���I���@2021�N06��20:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)
		
		mblnDBConnect = True
		
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c6d246d6-0c91-428e-b350-6ea737c9ef96
	Catch ex As Exception
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
		'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'******************************************************************************
	' �� �� ��  : DBObjectSet
	' �X�R�[�v  : Public
	' �������e  : �c�a�I�u�W�F�N�g�ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pobjSession         Object            I     OraSession
	'   pobjDatabase        Object            I     OraDatabase
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstName_DBObjectSet"
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		mobjOraSession = pobjSession
		
		mobjOraDatabase = pobjDatabase
		
		mblnDBObject = True
		
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bd89bebd-b2a1-4b50-852f-ebb94095a7f0
	Catch ex As Exception
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:169b835d-dc84-421e-aabc-40b9113c379e
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:169b835d-dc84-421e-aabc-40b9113c379e
		'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:169b835d-dc84-421e-aabc-40b9113c379e
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:169b835d-dc84-421e-aabc-40b9113c379e
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'******************************************************************************
	' �� �� ��  : SetNameInfo
	' �X�R�[�v  : Public
	' �������e  : ���̃}�X�^ �ݒ�
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrShikibetu       String            I     ����
	'   pstrCode            String            I     �R�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function SetNameInfo(ByVal pstrShikibetu As String, ByVal pstrCode As String) As Boolean
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstName_SetNameInfo"
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		'Dim objDysTemp As Object
		Dim objDysTemp As OraDynaset
		'--�C���I���@2021�N06��20:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		Dim strSQL As String
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		
		' �߂�l���������i�ُ�I���j
		SetNameInfo = True
		
		If mblnDBConnect = False And mblnDBObject = False Then
			Exit Function
		End If
		
		'�����v�|�C���^��ݒ�
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    ����    , "
		strSQL = strSQL & Chr(10) & "    �R�[�h  , "
		strSQL = strSQL & Chr(10) & "    ���̊���, "
		strSQL = strSQL & Chr(10) & "    ���̃J�i, "
		strSQL = strSQL & Chr(10) & "    ����    , "
		strSQL = strSQL & Chr(10) & "    �W���P  , "
		strSQL = strSQL & Chr(10) & "    �W���Q    "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "   " & MC_TABLE_���̃}�X�^ & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    ����   = '" & pstrShikibetu & "' "
		strSQL = strSQL & Chr(10) & "AND �R�[�h = '" & pstrCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysTemp
			
			' �Y������f�[�^�����݂���ꍇ
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' �߂�l��ݒ�i����I���j
				SetNameInfo = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr���� = gfncFieldVal(.Fields("����").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr�R�[�h = gfncFieldVal(.Fields("�R�[�h").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr���̊��� = gfncFieldVal(.Fields("���̊���").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr���̃J�i = gfncFieldVal(.Fields("���̃J�i").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mstr���� = gfncFieldVal(.Fields("����").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mcur�W��1 = gfncFieldCur(.Fields("�W���P").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mcur�W��2 = gfncFieldCur(.Fields("�W���Q").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
		
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:169b835d-dc84-421e-aabc-40b9113c379e
'PROC_END:
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	'Call gsubClearObject(objDysTemp)
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:169b835d-dc84-421e-aabc-40b9113c379e
	Catch ex As Exception
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:984e7777-4119-4dab-ac90-d9f38910362f
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:984e7777-4119-4dab-ac90-d9f38910362f
		'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:984e7777-4119-4dab-ac90-d9f38910362f
	PROC_FINALLY_END:
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		Call gsubClearObject(objDysTemp)
		Exit Function
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:984e7777-4119-4dab-ac90-d9f38910362f
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' �v���p�e�B
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' �� �� ��  : ����
	' �X�R�[�v  : Public
	' �������e  : ���� �擾
	' ��    �l  :
	' �� �� �l  : ����
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : ����
	' �X�R�[�v  : Public
	' �������e  : ���� �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     ����
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property ����() As String
		Get
			
			���� = mstr����
			
		End Get
		Set(ByVal Value As String)
			
			mstr���� = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : �R�[�h
	' �X�R�[�v  : Public
	' �������e  : �R�[�h �擾
	' ��    �l  :
	' �� �� �l  : �R�[�h
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : �R�[�h
	' �X�R�[�v  : Public
	' �������e  : �R�[�h �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     �R�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property �R�[�h() As String
		Get
			
			�R�[�h = mstr�R�[�h
			
		End Get
		Set(ByVal Value As String)
			
			mstr�R�[�h = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : ���̊���
	' �X�R�[�v  : Public
	' �������e  : ���̊��� �擾
	' ��    �l  :
	' �� �� �l  : ���̊���
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : ���̊���
	' �X�R�[�v  : Public
	' �������e  : ���̊��� �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     ���̊���
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property ���̊���() As String
		Get
			
			���̊��� = mstr���̊���
			
		End Get
		Set(ByVal Value As String)
			
			mstr���̊��� = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : ���̃J�i
	' �X�R�[�v  : Public
	' �������e  : ���̃J�i �擾
	' ��    �l  :
	' �� �� �l  : ���̃J�i
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : ���̃J�i
	' �X�R�[�v  : Public
	' �������e  : ���̃J�i �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     ���̃J�i
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property ���̃J�i() As String
		Get
			
			���̃J�i = mstr���̃J�i
			
		End Get
		Set(ByVal Value As String)
			
			mstr���̃J�i = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : ����
	' �X�R�[�v  : Public
	' �������e  : ���� �擾
	' ��    �l  :
	' �� �� �l  : ����
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : ����
	' �X�R�[�v  : Public
	' �������e  : ���� �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrValue           String            I     ����
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property ����() As String
		Get
			
			���� = mstr����
			
		End Get
		Set(ByVal Value As String)
			
			mstr���� = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : �W���P
	' �X�R�[�v  : Public
	' �������e  : �W���P �擾
	' ��    �l  :
	' �� �� �l  : �W���P
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : �W���P
	' �X�R�[�v  : Public
	' �������e  : �W���P �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pcurValue           Currency          I     �W���P
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property �W��1() As Decimal
		Get
			
			�W��1 = mcur�W��1
			
		End Get
		Set(ByVal Value As Decimal)
			
			mcur�W��1 = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : �W���Q
	' �X�R�[�v  : Public
	' �������e  : �W���Q �擾
	' ��    �l  :
	' �� �� �l  : �W���Q
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : �W���Q
	' �X�R�[�v  : Public
	' �������e  : �W���Q �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pcurValue           Currency          I     �W���Q
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Property �W��2() As Decimal
		Get
			
			�W��2 = mcur�W��2
			
		End Get
		Set(ByVal Value As Decimal)
			
			mcur�W��2 = Value
			
		End Set
	End Property
End Class
