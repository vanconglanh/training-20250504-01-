Option Strict Off
Option Explicit On
Friend Class clsUnitMstAccount
	'******************************************************************************
	' ��ۼު�Ė�  : �G���P�C�V�X�e������
	' �t�@�C����  : UnitMstAccount.cls
	' ��    �e    : �����ԍ��}�X�^ ��� �i�[ �N���X ���W���[��
	' ��    �l    : �g�p����ۂɂ�, ConstMstAccount.bas���v���W�F�N�g�ɒǉ�
	' �֐��ꗗ    : <Public>
	'                   DBConnect              (�c�a�ڑ�)
	'                   DBObjectSet            (�c�a�I�u�W�F�N�g�ݒ�)
	'                   SetAccountInfo         (�����ԍ��}�X�^  ��� �ݒ�)
	'                   SetComboItem           (�����ԍ��R���{  �ݒ�)
	'                   SetComboListIndex      (�����ԍ��R���{ ���X�g�C���f�b�N�X �ݒ�)
	'               <Private>
	'               <Property>
	'                   ����                   O
	'                   ��s�R�[�h             O
	'                   ��s��                 O
	'                   �x�X�R�[�h             O
	'                   �x�X��                 O
	'                   �������               O
	'                   ������ʖ�             O
	'                   �����ԍ�               O
	'                   �p�[�t�F�N�g����       O
	'                   �R���{�\���t���O       O
	'                   �U�����ЃR�[�h       O
	'               <Events>
	'                   Class_Initialize       (�N���X�����ݒ�)
	'                   Class_Terminate        (�c�a�ؒf)
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'   01.01       2008/04/21  �A��  �F��         �@�p�[�t�F�N�g�����̑Ή�
	'                                              �A�U�����ЃR�[�h�̒ǉ�
	'   01.02       2008/05/21  �A��  �F��         �V�X�e���敪��ǉ�(���|�����Ǘ��V�X�e���ł��g�p�����)
	'   01.03       2008/07/22  �A��  �F��         �R���{�\���t���O��ǉ�
	'
	'******************************************************************************
	'==============================================================================
	' �񋓑�
	'==============================================================================
	Public Enum SystemKbn
		���w�� = -1
		�^�s�Ǘ� = 0
		���|�����Ǘ� = 1
		�ݕt���Ǘ� = 2
	End Enum
	
	'==============================================================================
	' �\����
	'==============================================================================
	'----------------------------------
	Private Structure TAG_AccountInfo ' �U������
		'----------------------------------
		Dim mTstr�A�� As String
		Dim mTstr��s�R�[�h As String
		Dim mTstr��s�� As String
		Dim mTstr�x�X�R�[�h As String
		Dim mTstr�x�X�� As String
		Dim mTstr������� As String
		Dim mTstr������ʖ� As String
		Dim mTstr�����ԍ� As String
		Dim mTint�p�[�t�F�N�g���� As Short
		Dim mTint�R���{�\���t���O As Short
		Dim mTstr�U�����ЃR�[�h As String
	End Structure
	
	'==============================================================================
	' �ϐ�
	'==============================================================================
	Private marecAccountInfo() As TAG_AccountInfo ' �������
	Private mobjOraSession As Object ' Oracle
	Private mobjOraDatabase As Object ' Oracle
	Private mblnDBConnect As Boolean ' DB�ڑ��t���O(True�F�ڑ�)
	Private mblnDBObject As Boolean ' DB�ڑ��I�u�W�F�N�g�ݒ�t���O(True�F�ݒ�)
	Private mblnDataSet As Boolean ' ���ݒ�t���O(True�F�ݒ�)
	Private mintAccountCount As Short ' �f�[�^����
	Private mint�V�X�e���敪 As Short ' �^�ǂƔ��|������ؑւ�敪(0:�^��,1:���|����)
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' �C�x���g
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' �� �� ��  : Class_Initialize
	' �X�R�[�v  : Public
	' �������e  : ������ �� ��Џ�� �N���X �����ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Class_Initialize"
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		' �z��Ē�`
		'UPGRADE_WARNING: Lower bound of array marecAccountInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim marecAccountInfo(99)
		
		mblnDBConnect = False
		mblnDBObject = False
		mblnDataSet = False
		mintAccountCount = 0
		
		mint�V�X�e���敪 = SystemKbn.�^�s�Ǘ�
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:01e98535-789f-4668-a13e-e4bee50028a0
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:01e98535-789f-4668-a13e-e4bee50028a0
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7d37542-bd56-4c3f-a251-65bdd693b854
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Class_Terminate"
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		Erase marecAccountInfo
		
		If mblnDBConnect = True Then
			
			Call gsubClearObject(mobjOraSession)
			
			Call gsubClearObject(mobjOraDatabase)
			
		End If
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7d37542-bd56-4c3f-a251-65bdd693b854
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7d37542-bd56-4c3f-a251-65bdd693b854
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBConnect"
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)
		
		mblnDBConnect = True
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4c0101ac-267c-4086-85be-3ea8cfd969d9
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'******************************************************************************
	' �� �� ��  : DBObjectClear
	' �X�R�[�v  : Public
	' �������e  : �c�a�I�u�W�F�N�g�J��
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2009/01/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub DBObjectClear()
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBObjectClear"
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		'UPGRADE_NOTE: Object mobjOraSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mobjOraSession = Nothing
		
		'UPGRADE_NOTE: Object mobjOraDatabase may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mobjOraDatabase = Nothing
		
		mblnDBObject = False
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bfd336c9-e44d-469a-8d65-47de1f5cd517
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_DBObjectSet"
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		mobjOraSession = pobjSession
		
		mobjOraDatabase = pobjDatabase
		
		mblnDBObject = True
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f25ba698-e8a7-4ec3-9e60-f6e0f2d735ba
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'******************************************************************************
	' �� �� ��  : SetAccountInfo
	' �X�R�[�v  : Public
	' �������e  : �����ԍ��}�X�^ ��� �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub SetAccountInfo()
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_SetAccountInfo"
		Dim objDysKZB_M As Object ' �����ԍ��}�X�^��OraDynaset
		Dim strSQL As String
		Dim intIdx As Short
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		
		If mblnDBConnect = False And mblnDBObject = False Then
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Lower bound of array marecAccountInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
		ReDim marecAccountInfo(99)
		
		mblnDataSet = False
		mintAccountCount = 0
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    KZB_M.��s�R�[�h      , "
		strSQL = strSQL & Chr(10) & "    GK_M.��s������       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.�x�X�R�[�h      , "
		strSQL = strSQL & Chr(10) & "    ST_M.�x�X������       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.�������        , "
		strSQL = strSQL & Chr(10) & "    MS_M.������ʖ�       , "
		strSQL = strSQL & Chr(10) & "    KZB_M.�����ԍ�        , "
		strSQL = strSQL & Chr(10) & "    KZB_M.�p�[�t�F�N�g����, "
		strSQL = strSQL & Chr(10) & "    KZB_M.�R���{�\���t���O, "
		strSQL = strSQL & Chr(10) & "    KZB_M.�U�����ЃR�[�h  "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    �����ԍ��}�X�^ KZB_M, "
		strSQL = strSQL & Chr(10) & "    ��s�}�X�^     GK_M , "
		strSQL = strSQL & Chr(10) & "    �x�X�}�X�^     ST_M , "
		strSQL = strSQL & Chr(10) & "    ( "
		strSQL = strSQL & Chr(10) & "        SELECT "
		strSQL = strSQL & Chr(10) & "            �R�[�h     �������  , "
		strSQL = strSQL & Chr(10) & "            ���̊���   ������ʖ�  "
		strSQL = strSQL & Chr(10) & "        FROM "
		strSQL = strSQL & Chr(10) & "            ���̃}�X�^ "
		strSQL = strSQL & Chr(10) & "        WHERE "
		strSQL = strSQL & Chr(10) & "            ���� = '�������' "
		strSQL = strSQL & Chr(10) & "    ) MS_M "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    KZB_M.��s�R�[�h   = GK_M.��s�R�[�h(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.��s�R�[�h   = ST_M.��s�R�[�h(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.�x�X�R�[�h   = ST_M.�x�X�R�[�h(+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.�������     = MS_M.�������  (+) "
		strSQL = strSQL & Chr(10) & "AND KZB_M.�V�X�e���敪 = '" & CStr(mint�V�X�e���敪) & "' "
		strSQL = strSQL & Chr(10) & "ORDER BY "
		strSQL = strSQL & Chr(10) & "    KZB_M.�\����    , "
		strSQL = strSQL & Chr(10) & "    KZB_M.��s�R�[�h, "
		strSQL = strSQL & Chr(10) & "    KZB_M.�x�X�R�[�h, "
		strSQL = strSQL & Chr(10) & "    KZB_M.�������  , "
		strSQL = strSQL & Chr(10) & "    KZB_M.�����ԍ�    "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysKZB_M = mobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysKZB_M
			
			intIdx = 1
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Do Until .EOF = True
				
				If intIdx <= 99 Then
					
					marecAccountInfo(intIdx).mTstr�A�� = VB6.Format(CStr(intIdx), "00")
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr��s�R�[�h = gfncFieldVal(.Fields("��s�R�[�h").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr��s�� = gfncFieldVal(.Fields("��s������").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr�x�X�R�[�h = gfncFieldVal(.Fields("�x�X�R�[�h").Value)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(�x�X�R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If gfncFieldVal(.Fields("�x�X�R�[�h").Value) <> "" Then
						
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(�x�X������).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If gfncFieldVal(.Fields("�x�X������").Value) = "�{�X" Then
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							marecAccountInfo(intIdx).mTstr�x�X�� = gfncFieldVal(.Fields("�x�X������").Value)
							
						Else
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							marecAccountInfo(intIdx).mTstr�x�X�� = gfncFieldVal(.Fields("�x�X������").Value) & "�x�X"
							
						End If
						
					End If
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr������� = gfncFieldVal(.Fields("�������").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr������ʖ� = gfncFieldVal(.Fields("������ʖ�").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr�����ԍ� = gfncFieldVal(.Fields("�����ԍ�").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTint�p�[�t�F�N�g���� = gfncFieldCur(.Fields("�p�[�t�F�N�g����").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTint�R���{�\���t���O = gfncFieldCur(.Fields("�R���{�\���t���O").Value)
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					marecAccountInfo(intIdx).mTstr�U�����ЃR�[�h = gfncFieldVal(.Fields("�U�����ЃR�[�h").Value)
					
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Select Case Right(.Fields("��s������").Value, 2)
						
						Case "����", "�M��", "�M��", "�g��", "�_��"
							
							' �����Ȃ�
							
						Case Else
							
							'UPGRADE_WARNING: Couldn't resolve default property of object objDysKZB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysKZB_M.Fields(�x�X�R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If gfncFieldVal(.Fields("�x�X�R�[�h").Value) <> "" Then
								
								marecAccountInfo(intIdx).mTstr��s�� = marecAccountInfo(intIdx).mTstr��s�� & "��s"
								
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
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
'PROC_END:
		
	'Call gsubClearObject(objDysKZB_M)
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b263367-5ed0-42eb-ba45-94f16dd912e5
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	PROC_FINALLY_END:
		Call gsubClearObject(objDysKZB_M)
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'******************************************************************************
	' �� �� ��  : SetComboItem
	' �X�R�[�v  : Public
	' �������e  : �����ԍ��R���{  �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pcboTarget          ComboBox          O     �U�������R���{
	'   pintComboSetOff     Integer           I     �R���{�\���t���O����(0:����Ȃ�, 1:���肠��)
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/05/24  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub SetComboItem(ByRef pcboTarget As System.Windows.Forms.ComboBox, Optional ByVal pintComboSetOff As Short = GC_FLG_OFF)
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "clsUnitMstAccount_SetComboItem"
		Dim intIdx As Short
		Dim strNumber As String
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
            '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            Call pcboTarget.Items.Clear()
            '++�C���J�n�@2021�N09��30��:MK�i��j- VB��VB.NET�ϊ�
            pcboTarget.Text = ""
            '--�C���J�n�@2021�N09��30��:MK�i��j- VB��VB.NET�ϊ�

            For intIdx = 1 To mintAccountCount
			
			strNumber = VB6.Format(CStr(intIdx), "00")
			
			With marecAccountInfo(intIdx)
				
				' ����Ȃ��̏ꍇ
				If pintComboSetOff = GC_FLG_OFF Then
					
					Call pcboTarget.Items.Add(strNumber & " : " & .mTstr��s�� & "  " & .mTstr�x�X�� & "  " & .mTstr������ʖ� & "  " & .mTstr�����ԍ�)
					
					' ���肠��̏ꍇ
				Else
					
					' �R���{�\���t���O��0(�\������)�̏ꍇ
					If .mTint�R���{�\���t���O = 0 Then
						
						Call pcboTarget.Items.Add(strNumber & " : " & .mTstr��s�� & "  " & .mTstr�x�X�� & "  " & .mTstr������ʖ� & "  " & .mTstr�����ԍ�)
						
					End If
					
				End If
				
			End With
			
		Next intIdx
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb9a45e2-e4b5-49b9-b22f-ded5e46007e4
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'******************************************************************************
	' �� �� ��  : SetComboListIndex
	' �X�R�[�v  : Public
	' �������e  : �����ԍ��R���{ ���X�g�C���f�b�N�X �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     ��s�R�[�h
	'   pstrBranchCode      String            I     �x�X�R�[�h
	'   pstrAccountKind     String            I     �������
	'   pstrAccountNo       String            I     �����ԍ�
	'   pcboTarget          ComboBox          I     �U�������R���{
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/05/24  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Sub SetComboListIndex(ByVal pstrBankCode As String, ByVal pstrBranchCode As String, ByVal pstrAccountKind As String, ByVal pstrAccountNo As String, ByRef pcboTarget As System.Windows.Forms.ComboBox)
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "SetComboListIndex"
		Dim intIdx As Short
		Dim strRecNum As String
		Dim blnSearchHit As Boolean
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		
		If Len(pstrBankCode) = 0 And Len(pstrBranchCode) = 0 And Len(pstrAccountKind) = 0 And Len(pstrAccountNo) = 0 Then
			
			pcboTarget.SelectedIndex = -1
			
			Exit Sub
			
		End If
		
		blnSearchHit = False
		
		For intIdx = 1 To mintAccountCount
			
			strRecNum = VB6.Format(intIdx, "00")
			
			With marecAccountInfo(intIdx)
				
				' �Y������f�[�^���������ꍇ
				If .mTstr��s�R�[�h = pstrBankCode And .mTstr�x�X�R�[�h = pstrBranchCode And .mTstr������� = pstrAccountKind And .mTstr�����ԍ� = pstrAccountNo Then
					
					Call gsubSetComboListIndex(pcboTarget, strRecNum, GC_LEN_PAY_ACCOUNT)
					
					blnSearchHit = True
					
					Exit For
					
				End If
				
			End With
			
		Next intIdx
		
		If blnSearchHit = False Then
			
			pcboTarget.Text = ""
			
		End If
		
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
'PROC_END:
		
	'Exit Sub
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:40d19162-5a5e-4b8f-a02d-9e793daad0cc
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	PROC_FINALLY_END:
		Exit Sub
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	' �v���p�e�B
	'_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	'******************************************************************************
	' �� �� ��  : �V�X�e���敪
	' �X�R�[�v  : Public
	' �������e  : �V�X�e���敪 �ݒ�
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pintValue           Integer           I     �V�X�e������
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/05/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public WriteOnly Property �V�X�e���敪() As Short
		Set(ByVal Value As Short)
			
			mint�V�X�e���敪 = Value
			
		End Set
	End Property
	'******************************************************************************
	' �� �� ��  : ����
	' �X�R�[�v  : Public
	' �������e  : �����ԍ� ��� ���� �擾
	' ��    �l  :
	' �� �� �l  : �����ԍ� ��� ����
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property ����() As Short
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_����"
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			���� = mintAccountCount
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:48404db1-4ee0-45b0-aa67-5f94d1f9685e
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : ��s�R�[�h
	' �X�R�[�v  : Public
	' �������e  : ��s�R�[�h �擾
	' ��    �l  :
	' �� �� �l  : ��s�R�[�h
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property ��s�R�[�h(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_��s�R�[�h"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			��s�R�[�h = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					��s�R�[�h = marecAccountInfo(intIdx).mTstr��s�R�[�h
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1e1e36e0-460e-4bbd-b160-a117b51c8ddd
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88cabacc-f477-48e5-8347-377f07469a29
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88cabacc-f477-48e5-8347-377f07469a29
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88cabacc-f477-48e5-8347-377f07469a29
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88cabacc-f477-48e5-8347-377f07469a29
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : ��s��
	' �X�R�[�v  : Public
	' �������e  : ��s�� �擾
	' ��    �l  :
	' �� �� �l  : ��s��
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property ��s��(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_��s��"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			��s�� = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					��s�� = marecAccountInfo(intIdx).mTstr��s��
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88cabacc-f477-48e5-8347-377f07469a29
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88cabacc-f477-48e5-8347-377f07469a29
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b35cc457-241e-45fd-884c-d7949c79b0e3
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : �x�X�R�[�h
	' �X�R�[�v  : Public
	' �������e  : �x�X�R�[�h �擾
	' ��    �l  :
	' �� �� �l  : �x�X�R�[�h
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property �x�X�R�[�h(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_�x�X�R�[�h"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			�x�X�R�[�h = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					�x�X�R�[�h = marecAccountInfo(intIdx).mTstr�x�X�R�[�h
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b35cc457-241e-45fd-884c-d7949c79b0e3
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b35cc457-241e-45fd-884c-d7949c79b0e3
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3a48f317-960a-4c3e-882a-91f8527a5140
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3a48f317-960a-4c3e-882a-91f8527a5140
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3a48f317-960a-4c3e-882a-91f8527a5140
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3a48f317-960a-4c3e-882a-91f8527a5140
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : �x�X��
	' �X�R�[�v  : Public
	' �������e  : �x�X�� �擾
	' ��    �l  :
	' �� �� �l  : �x�X��
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property �x�X��(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_�x�X��"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			�x�X�� = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					�x�X�� = marecAccountInfo(intIdx).mTstr�x�X��
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3a48f317-960a-4c3e-882a-91f8527a5140
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3a48f317-960a-4c3e-882a-91f8527a5140
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd239302-b018-49f8-96b5-71689c5cee46
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd239302-b018-49f8-96b5-71689c5cee46
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd239302-b018-49f8-96b5-71689c5cee46
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd239302-b018-49f8-96b5-71689c5cee46
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : �������
	' �X�R�[�v  : Public
	' �������e  : ������� �擾
	' ��    �l  :
	' �� �� �l  : �������
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property �������(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_�������"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			������� = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					������� = marecAccountInfo(intIdx).mTstr�������
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd239302-b018-49f8-96b5-71689c5cee46
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd239302-b018-49f8-96b5-71689c5cee46
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : ������ʖ�
	' �X�R�[�v  : Public
	' �������e  : ������ʖ� �擾
	' ��    �l  :
	' �� �� �l  : ������ʖ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property ������ʖ�(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_������ʖ�"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			������ʖ� = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					������ʖ� = marecAccountInfo(intIdx).mTstr������ʖ�
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:766da1f7-6e36-4c1c-be77-c8ae0f777da3
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87a172f1-40ed-463a-a50a-7842fdd71447
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87a172f1-40ed-463a-a50a-7842fdd71447
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87a172f1-40ed-463a-a50a-7842fdd71447
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87a172f1-40ed-463a-a50a-7842fdd71447
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : �����ԍ�
	' �X�R�[�v  : Public
	' �������e  : �����ԍ� �擾
	' ��    �l  :
	' �� �� �l  : �����ԍ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/06/18  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property �����ԍ�(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_�����ԍ�"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			�����ԍ� = ""
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					�����ԍ� = marecAccountInfo(intIdx).mTstr�����ԍ�
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87a172f1-40ed-463a-a50a-7842fdd71447
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87a172f1-40ed-463a-a50a-7842fdd71447
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : �p�[�t�F�N�g����
	' �X�R�[�v  : Public
	' �������e  : �p�[�t�F�N�g���� �擾
	' ��    �l  :
	' �� �� �l  : �p�[�t�F�N�g����
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property �p�[�t�F�N�g����(ByVal pstrIndex As String) As Short
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_�p�[�t�F�N�g����"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			�p�[�t�F�N�g���� = GC_FLG_OFF
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					�p�[�t�F�N�g���� = marecAccountInfo(intIdx).mTint�p�[�t�F�N�g����
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7f44afe-dcfc-464b-ba06-c89f2895dc79
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
	'******************************************************************************
	' �� �� ��  : �U�����ЃR�[�h
	' �X�R�[�v  : Public
	' �������e  : �U�����ЃR�[�h �擾
	' ��    �l  :
	' �� �� �l  : �U�����ЃR�[�h
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrIndex           String            I     �����ԍ����̃C���f�b�N�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public ReadOnly Property �U�����ЃR�[�h(ByVal pstrIndex As String) As String
		Get
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
			Const C_NAME_FUNCTION As String = "clsUnitMstAccount_Get_�U�����ЃR�[�h"
			Dim intIdx As Short
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			
			
			�U�����ЃR�[�h = CStr(GC_FLG_OFF)
			
			If mblnDataSet = False Then
				Exit Property
			End If
			
			For intIdx = 1 To mintAccountCount
				
				If marecAccountInfo(intIdx).mTstr�A�� = pstrIndex Then
					
					�U�����ЃR�[�h = marecAccountInfo(intIdx).mTstr�U�����ЃR�[�h
					
					Exit For
					
				End If
				
			Next intIdx
			
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
'PROC_END:
			
		'Exit Property
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'PROC_ERROR:
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eb432346-19b9-4e4d-a902-3b0ebdca7f5f
		Catch ex As Exception
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			
			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			
			'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			'Resume PROC_END
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		'GoTo PROC_END
		GoTo PROC_FINALLY_END
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
			'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
			
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			End Try
		'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		PROC_FINALLY_END:
			Exit Property
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3ac739db-3cbc-4c50-98ad-d81fd40451e0
		'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Get
	End Property
End Class
