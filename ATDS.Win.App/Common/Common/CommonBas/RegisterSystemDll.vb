Option Strict Off
Option Explicit On
Imports MKOra.Core
Imports Common
Friend Class clsRegisterSystemDll
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : RegisterSystemDll.cls
    ' ��    �e    : �l�j�V�X�e���c�k�k ���W�X�g�� �o�^ �N���X ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   DBConnect              (�c�a�ڑ�)
    '                   DBObjectSet            (�c�a�I�u�W�F�N�g�ݒ�)
    '                   RegisterDLL            (�l�j�V�X�e���c�k�k ���W�X�g�� �o�^)
    '               <Private>
    '                   msubRegistServer       (���W�X�g�� �o�^����)
    '                   msubUnRegistServer     (���W�X�g�� �o�^��������)
    '               <Property>
    '                   SystemName             I  (�c�k�k�o�^�Ώ� �V�X�e����)
    '               <Events>
    '                   Class_Initialize       (�N���X�����ݒ�)
    '                   Class_Terminate        (�c�a�ؒf)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Private Const MC_CMD_REGSVR32 As String = "regsvr32"
    Private Const MC_PRAM_REGSVR As String = "/RegServer"
    Private Const MC_PRAM_UN_REGSVR As String = "/UnRegServer"

    Private Const MC_EXECUTE_OTHER As Short = 0
    Private Const MC_EXECUTE_DLL As Short = 1
    Private Const MC_EXECUTE_EXE As Short = 2

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    Private mblnDBConnect As Boolean ' DB�ڑ��t���O(True�F�ڑ�)
    Private mblnDBObject As Boolean ' DB�ڑ��I�u�W�F�N�g�ݒ�t���O(True�F�ݒ�)
    Private mstrSystemName As String ' DLL����
    '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
    'Private mobjOraSession As Object
    Private mobjOraSession As OraSession
    '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    'Private mobjOraDatabase As Object
    Private mobjOraDatabase As OraDatabase
    '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' �C�x���g
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : Class_Initialize
    ' �X�R�[�v  : Public
    ' �������e  : �l�j�V�X�e���c�k�k ���W�X�g�� �o�^ �N���X �����ݒ�
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Initialize"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Initialize"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            mblnDBConnect = False

            mblnDBObject = False

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:040bb9da-76d9-4560-bccc-ce073f358789
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:040bb9da-76d9-4560-bccc-ce073f358789
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Terminate"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Terminate"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9c033dea-e61b-4ac7-86d6-964d68ee7521

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
    ' �� �� �l  :
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
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBConnect"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBConnect"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()

            '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4a972f61-d1fe-4382-ae01-3523db60591d
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4a972f61-d1fe-4382-ae01-3523db60591d

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4a972f61-d1fe-4382-ae01-3523db60591d
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4a972f61-d1fe-4382-ae01-3523db60591d
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : DBObjectSet
    ' �X�R�[�v  : Public
    ' �������e  : �c�a�I�u�W�F�N�g�ݒ�
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDataBase
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBObjectSet"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBObjectSet"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4a972f61-d1fe-4382-ae01-3523db60591d
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4a972f61-d1fe-4382-ae01-3523db60591d
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6affe531-11f4-4232-84f4-1bf63794a246
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6affe531-11f4-4232-84f4-1bf63794a246

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6affe531-11f4-4232-84f4-1bf63794a246
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6affe531-11f4-4232-84f4-1bf63794a246
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : RegisterDLL
    ' �X�R�[�v  : Public
    ' �������e  : �l�j�V�X�e���c�k�k ���W�X�g�� �o�^
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrProgId          String            I     �v���O�����h�c
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function RegisterDLL(Optional ByVal pstrProgId As String = "") As Boolean


        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_LoadLogin"
        Dim strSQL As String
        '++�C���J�n�@2021�N09��11��:MK�i��j- VB��VB.NET�ϊ�
        'Dim objDysDLL�o�^�e�[�u�� As Object
        Dim objDysDLL�o�^�e�[�u�� As OraDynaset
        '--�C���J�n�@2021�N09��11��:MK�i��j- VB��VB.NET�ϊ�
        Dim strFilePathReg As String ' ���W�X�g���ɓo�^����Ă���t�@�C���p�X
        Dim strFilePath As String ' �o�^�ΏۂƂȂ�t�@�C���p�X
        Dim strVersionReg As String ' ���W�X�g���ɓo�^����Ă���t�@�C���̃o�[�W����
        Dim strVersion As String ' �o�^�ΏۂƂȂ�t�@�C���̃o�[�W����
        Dim vntClsid As Object
        Dim intExecuteKbn As Short ' �g���q�敪(0:DLL,1:EXE)
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            If Len(mstrSystemName) = 0 Then
                Exit Function
            End If

            '2022/08/22���@���s���Ȃ��悤�C���FTSS��Z
            Exit Function
            '2022/08/22��

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �o�`�s�g�� "
            strSQL = strSQL & Chr(10) & "  , �c�k�k��   "
            strSQL = strSQL & Chr(10) & "  , PROGID     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "   �c�k�k�o�^�e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "   �c�k�k���� = '" & mstrSystemName & "' "

            If pstrProgId <> "" Then

                strSQL = strSQL & Chr(10) & "AND PROGID     = '" & pstrProgId & "' "

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysDLL�o�^�e�[�u�� = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysDLL�o�^�e�[�u��

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    '------------------------------------------------------------------
                    ' �o�^�Ώ� �t�@�C���p�X �擾
                    '------------------------------------------------------------------
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysDLL�o�^�e�[�u��.Fields(�c�k�k��).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strFilePath = gfncFieldVal(.Fields("�o�`�s�g��").Value) & gfncFieldVal(.Fields("�c�k�k��").Value)

                    '------------------------------------------------------------------
                    ' �g���q�敪 �ݒ�
                    '------------------------------------------------------------------
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                    'If InStr(StrConv(gfncFieldVal(.Fields("�c�k�k��").Value), VbStrConv.UpperCase), ".DLL") <> 0 Then
                    If InStr(Utils.StrConv(gfncFieldVal(.Fields("�c�k�k��").Value), VbStrConv.Uppercase), ".DLL") <> 0 Then
                        '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

                        intExecuteKbn = MC_EXECUTE_DLL

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                        'ElseIf InStr(StrConv(gfncFieldVal(.Fields("�c�k�k��").Value), VbStrConv.UpperCase), ".EXE") <> 0 Then
                    ElseIf InStr(Utils.StrConv(gfncFieldVal(.Fields("�c�k�k��").Value), VbStrConv.Uppercase), ".EXE") <> 0 Then
                        '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

                        intExecuteKbn = MC_EXECUTE_EXE

                    Else

                        intExecuteKbn = MC_EXECUTE_OTHER

                    End If

                    '------------------------------------------------------------------
                    ' ���W�X�g�� �t�@�C���p�X �擾
                    '------------------------------------------------------------------
                    strFilePathReg = ""

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysDLL�o�^�e�[�u��.Fields(PROGID).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gfncFieldVal(.Fields("PROGID").Value) <> "" Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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

                                ' �����Ȃ�

                            End If

                        End If

                    End If

                    '------------------------------------------------------------------
                    ' �o�^�Ώ� �t�@�C���p�X �擾
                    '------------------------------------------------------------------
                    ' ���W�X�g���ɓo�^����Ă��Ȃ��ꍇ
                    If strFilePathReg = "" Then

                        ' ���W�X�g���ɓo�^
                        Call msubRegistServer(intExecuteKbn, strFilePath)

                        ' ���W�X�g���ɓo�^����Ă���ꍇ
                    Else

                        ' ���W�X�g���ɓo�^����Ă���t�@�C���p�X��
                        ' �o�^�ΏۂƂȂ�t�@�C���p�X����v���Ȃ��ꍇ
                        '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                        'If StrConv(strFilePathReg, VbStrConv.UpperCase) <> StrConv(strFilePath, VbStrConv.UpperCase) Then
                        If Utils.StrConv(strFilePathReg, VbStrConv.Uppercase) <> Utils.StrConv(strFilePath, VbStrConv.Uppercase) Then
                            '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

                            ' ����, ���W�X�g���ɓo�^����Ă�������폜
                            Call msubUnRegistServer(intExecuteKbn, strFilePathReg)

                            ' ���W�X�g���ɓo�^
                            Call msubRegistServer(intExecuteKbn, strFilePath)

                            ' ���W�X�g���ɓo�^����Ă���t�@�C���p�X��
                            ' �o�^�ΏۂƂȂ�t�@�C���p�X����v����ꍇ
                        Else

                            ' �o�^�Ώۃv���O�����h�c���w�肳��Ă���ꍇ
                            If pstrProgId <> "" Then

                                ' ����, ���W�X�g���ɓo�^����Ă�������폜
                                Call msubUnRegistServer(intExecuteKbn, strFilePathReg)

                                ' ���W�X�g���ɓo�^
                                Call msubRegistServer(intExecuteKbn, strFilePath)

                            End If

                        End If

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLL�o�^�e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            ' �߂�l��ݒ�i����I���j
            RegisterDLL = False

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6affe531-11f4-4232-84f4-1bf63794a246
            'PROC_END:

            'Call gsubClearObject(objDysDLL�o�^�e�[�u��)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6affe531-11f4-4232-84f4-1bf63794a246
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
PROC_FINALLY_END:
        Call gsubClearObject(objDysDLL�o�^�e�[�u��)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : msubRegistServer
    ' �X�R�[�v  : Public
    ' �������e  : ���W�X�g�� �o�^����
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintExecuteKbn      Integer           I     �g���q�敪(0:DLL,1:EXE)
    '   pstrRegFilePath     String            I     �t�@�C���p�X
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Private Sub msubRegistServer(ByVal pintExecuteKbn As Short, ByVal pstrRegFilePath As String)

        '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubRegistServer"
        Dim strCommandLine As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        'Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubRegistServer"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

        Try

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strCommandLine As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �o�^�ΏۂƂȂ�t�@�C�������݂��Ȃ��ꍇ
            If gfncCheckFileExists(pstrRegFilePath) = False Then

                '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
                'GoTo PROC_END
                Exit Sub
                '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

            End If

            ' �g���q���c�k�k�̏ꍇ
            If pintExecuteKbn = MC_EXECUTE_DLL Then

                '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
                strCommandLine = MC_CMD_REGSVR32 & " /s " & pstrRegFilePath
                'strCommandLine = MC_CMD_REGSVR32 & " " & pstrRegFilePath
                '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

                ' �g���q���d�w�d�̏ꍇ
            ElseIf pintExecuteKbn = MC_EXECUTE_EXE Then

                strCommandLine = pstrRegFilePath & " " & MC_PRAM_REGSVR

                ' ��L�ȊO�̏ꍇ
            Else

                '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
                'GoTo PROC_END
                Exit Sub
                '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

            End If

            Debug.Print(strCommandLine)

            ' ���W�X�g���ɓo�^
            If gfncExecWait(strCommandLine, AppWinStyle.Hide) = False Then

                '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
                'GoTo PROC_END
                Exit Sub
                '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

            End If

        Catch ex As Exception
            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

    End Sub
    '******************************************************************************
    ' �� �� ��  : msubUnRegistServer
    ' �X�R�[�v  : Public
    ' �������e  : ���W�X�g�� �o�^��������
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintExecuteKbn      Integer           I     �g���q�敪(0:DLL,1:EXE)
    '   pstrRegFilePath     String            I     �t�@�C���p�X
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Private Sub msubUnRegistServer(ByVal pintExecuteKbn As Short, ByVal pstrRegFilePath As String)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubUnRegistServer"
        Dim strCommandLine As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubUnRegistServer"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strCommandLine As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �o�^�ΏۂƂȂ�t�@�C�������݂��Ȃ��ꍇ
            If gfncCheckFileExists(pstrRegFilePath) = False Then

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            ' �g���q���c�k�k�̏ꍇ
            If pintExecuteKbn = MC_EXECUTE_DLL Then

                strCommandLine = MC_CMD_REGSVR32 & " /u /s " & pstrRegFilePath

                ' �g���q���d�w�d�̏ꍇ
            ElseIf pintExecuteKbn = MC_EXECUTE_EXE Then

                strCommandLine = pstrRegFilePath & " " & MC_PRAM_UN_REGSVR

                ' ��L�ȊO�̏ꍇ
            Else

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            Debug.Print(strCommandLine)

            ' ���W�X�g���ɓo�^
            If gfncExecWait(strCommandLine, AppWinStyle.Hide) = False Then

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1a00ea25-bb11-4192-9149-f43bb085bedb
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3fd7d54-76eb-48f1-9259-e26a42691f60

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' �v���p�e�B
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : SystemName
    ' �X�R�[�v  : Public
    ' �������e  : �c�k�k�o�^�Ώ� �V�X�e���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �c�k�k�o�^�Ώ� �V�X�e����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public WriteOnly Property SystemName() As String
        Set(ByVal Value As String)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsRegisterDLL_Let_SystemName"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Let_SystemName"
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                mstrSystemName = Value

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
            Catch ex As Exception
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:481479b9-ce09-4364-99b5-5c21d21ecafb
                'Resume PROC_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:481479b9-ce09-4364-99b5-5c21d21ecafb

                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:481479b9-ce09-4364-99b5-5c21d21ecafb
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:481479b9-ce09-4364-99b5-5c21d21ecafb
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Set
    End Property
End Class

