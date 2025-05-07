Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstZipCode
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : UnitMstZipCode.cls
    ' ��    �e    : �X�֔ԍ��}�X�^ ��� �i�[ �N���X ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '               <Private>
    '               <Property>
    '                   �S���n�������c�̃R�[�h I/O
    '                   ���X�֔ԍ�             I/O
    '                   �X�֔ԍ�               I/O
    '                   �s���{�����J�i         I/O
    '                   �s�撬�����J�i         I/O
    '                   ���於�J�i             I/O
    '                   �s���{����             I/O
    '                   �s�撬����             I/O
    '                   ���於                 I/O
    '                   �꒬�敡���ԍ�         I/O
    '                   �Ԓn��ԕ\��           I/O
    '                   ���ڕ\��               I/O
    '                   ��ԍ���������         I/O
    '                   �X�V�\��               I/O
    '                   �ύX���R               I/O
    '               <Events>
    '                   Class_Initialize       (�N���X�����ݒ�)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Private Const MC_TABLE_�X�֔ԍ��}�X�^ As String = "�X�֔ԍ��}�X�^"
    Private Const MC_TABLE_������Ə����ʗX�֔ԍ��}�X�^ As String = "������Ə����ʗX�֔ԍ��}�X�^"

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    '++�C���J�n�@2021�N06��08:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
    'Private mobjOraSession As Object ' Oracle
    Private mobjOraSession As OraSession ' Oracle
    '--�C���I���@2021�N06��08:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��08:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    'Private mobjOraDatabase As Object ' Oracle
    Private mobjOraDatabase As OraDatabase ' Oracle
    '--�C���I���@2021�N06��08:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    Private mblnDBConnect As Boolean ' DB�ڑ��t���O(True�F�ڑ�)
    Private mblnDBObject As Boolean ' DB�ڑ��I�u�W�F�N�g�ݒ�t���O(True�F�ݒ�)

    Private mstr�S���n�������c�̃R�[�h As String
    Private mstr���X�֔ԍ� As String
    Private mstr�X�֔ԍ� As String
    Private mstr�s���{�����J�i As String
    Private mstr�s�撬�����J�i As String
    Private mstr���於�J�i As String
    Private mstr�s���{���� As String
    Private mstr�s�撬���� As String
    Private mstr���於 As String
    Private mstr�꒬�敡���ԍ� As String
    Private mstr�Ԓn��ԕ\�� As String
    Private mstr���ڕ\�� As String
    Private mstr��ԍ��������� As String
    Private mstr�X�V�\�� As String
    Private mstr�ύX���R As String
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' �C�x���g
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : Class_Initialize
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ��}�X�^ ��� �i�[ �N���X �����ݒ�
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

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_Class_Initialize"
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            mblnDBConnect = False

            mblnDBObject = False

            mstr�S���n�������c�̃R�[�h = ""
            mstr���X�֔ԍ� = ""
            mstr�X�֔ԍ� = ""
            mstr�s���{�����J�i = ""
            mstr�s�撬�����J�i = ""
            mstr���於�J�i = ""
            mstr�s���{���� = ""
            mstr�s�撬���� = ""
            mstr���於 = ""
            mstr�꒬�敡���ԍ� = ""
            mstr�Ԓn��ԕ\�� = ""
            mstr���ڕ\�� = ""
            mstr��ԍ��������� = ""
            mstr�X�V�\�� = ""
            mstr�ύX���R = ""

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:16c1dff7-e424-42ea-a497-b58ade5310c2
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:16c1dff7-e424-42ea-a497-b58ade5310c2
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
    'UPGRADE_NOTE: Class_Terminate was upgraded to
    '. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_Class_Terminate"
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
    '   01.00       2008/04/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_DBConnect"
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()
            '--�C���I���@2021�N06��08:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:333a73df-4e06-4126-a016-5b0270e23c74
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:333a73df-4e06-4126-a016-5b0270e23c74
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:333a73df-4e06-4126-a016-5b0270e23c74
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:333a73df-4e06-4126-a016-5b0270e23c74
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
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
    '   01.00       2008/04/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_DBObjectSet"
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:333a73df-4e06-4126-a016-5b0270e23c74
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:333a73df-4e06-4126-a016-5b0270e23c74
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : CheckZIPCode
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ����݃`�F�b�N
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     �X�֔ԍ��P
    '   pstrZipCode2        String            I     �X�֔ԍ��Q
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function CheckZIPCode(ByVal pstrZIPCode1 As String, ByVal pstrZIPCode2 As String) As Boolean

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_CheckZIPCode"
        Dim objDysYB_M As Object ' �X�֔ԍ��}�X�^��OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            CheckZIPCode = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' �����v�|�C���^��ݒ�
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '�X�֔ԍ��}�X�^
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �X�֔ԍ� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_�X�֔ԍ��}�X�^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �X�֔ԍ� = '" & pstrZIPCode1 & pstrZIPCode2 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            '������Ə����ʗX�֔ԍ��}�X�^
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ������Ə��ʔԍ� AS �X�֔ԍ� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_������Ə����ʗX�֔ԍ��}�X�^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ������Ə��ʔԍ� = '" & pstrZIPCode1 & pstrZIPCode2 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' �߂�l��ݒ�(����I��)
                    CheckZIPCode = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : CheckZIPParentCode
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ��}�X�^�i�e�R�[�h�j �`�F�b�N
    ' ��    �l  : �X�֔ԍ��̏�3��(�e�R�[�h)�ŗX�֔ԍ��}�X�^������
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     �X�֔ԍ��P
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function CheckZIPParentCode(ByVal pstrZIPCode1 As String) As Boolean

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_CheckZIPParentCode"
        Dim objDysYB_M As Object ' �X�֔ԍ��}�X�^��OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            CheckZIPParentCode = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' �����v�|�C���^��ݒ�
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '�X�֔ԍ��}�X�^
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �X�֔ԍ� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_�X�֔ԍ��}�X�^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �X�֔ԍ�1 = '" & pstrZIPCode1 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            '������Ə����ʗX�֔ԍ��}�X�^
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ������Ə��ʔԍ� AS �X�֔ԍ� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_������Ə����ʗX�֔ԍ��}�X�^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ������Ə��ʔԍ�1 = '" & pstrZIPCode1 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' �߂�l��ݒ�(����I��)
                    CheckZIPParentCode = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : SetZIPInfo
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ��}�X�^ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     �X�֔ԍ��P
    '   pstrZipCode2        String            I     �X�֔ԍ��Q
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function SetZIPInfo(ByVal pstrZIPCode1 As String, ByVal pstrZIPCode2 As String) As Boolean

        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_SetZIPInfo"
        Dim objDysYB_M As Object ' �X�֔ԍ��}�X�^��OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            SetZIPInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' �����v�|�C���^��ݒ�
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '�X�֔ԍ��}�X�^
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �S���n�������c�̃R�[�h , "
            strSQL = strSQL & Chr(10) & "    ���X�֔ԍ�             , "
            strSQL = strSQL & Chr(10) & "    �X�֔ԍ�               , "
            strSQL = strSQL & Chr(10) & "    �s���{�����J�i         , "
            strSQL = strSQL & Chr(10) & "    �s�撬�����J�i         , "
            strSQL = strSQL & Chr(10) & "    ���於�J�i             , "
            strSQL = strSQL & Chr(10) & "    �s���{����             , "
            strSQL = strSQL & Chr(10) & "    �s�撬����             , "
            strSQL = strSQL & Chr(10) & "    ���於                 , "
            strSQL = strSQL & Chr(10) & "    �꒬�敡���ԍ�         , "
            strSQL = strSQL & Chr(10) & "    �Ԓn��ԕ\��           , "
            strSQL = strSQL & Chr(10) & "    ���ڕ\��               , "
            strSQL = strSQL & Chr(10) & "    ��ԍ���������         , "
            strSQL = strSQL & Chr(10) & "    �X�V�\��               , "
            strSQL = strSQL & Chr(10) & "    �ύX���R                 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_�X�֔ԍ��}�X�^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �X�֔ԍ� = '" & pstrZIPCode1 & pstrZIPCode2 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            '������Ə����ʗX�֔ԍ��}�X�^
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NULL                   �S���n�������c�̃R�[�h, "
            strSQL = strSQL & Chr(10) & "    ���X�֔ԍ�             , "
            strSQL = strSQL & Chr(10) & "    ������Ə��ʔԍ�     �X�֔ԍ�              , "
            strSQL = strSQL & Chr(10) & "    NULL                   �s���{�����J�i        , "
            strSQL = strSQL & Chr(10) & "    NULL                   �s�撬�����J�i        , "
            strSQL = strSQL & Chr(10) & "    NULL                   ���於�J�i            , "
            strSQL = strSQL & Chr(10) & "    �s���{����             , "
            strSQL = strSQL & Chr(10) & "    �s�撬����             , "
            strSQL = strSQL & Chr(10) & "    ���於 || �������ڔԒn ���於                , "
            strSQL = strSQL & Chr(10) & "    NULL                   �꒬�敡���ԍ�        , "
            strSQL = strSQL & Chr(10) & "    NULL                   �Ԓn��ԕ\��          , "
            strSQL = strSQL & Chr(10) & "    NULL                   ���ڕ\��              , "
            strSQL = strSQL & Chr(10) & "    NULL                   ��ԍ���������        , "
            strSQL = strSQL & Chr(10) & "    NULL                   �X�V�\��              , "
            strSQL = strSQL & Chr(10) & "    NULL                   �ύX���R                "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_������Ə����ʗX�֔ԍ��}�X�^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ������Ə��ʔԍ� = '" & pstrZIPCode1 & pstrZIPCode2 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' �߂�l��ݒ�(����I��)
                    SetZIPInfo = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�S���n�������c�̃R�[�h = gfncFieldVal(.Fields("�S���n�������c�̃R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���X�֔ԍ� = gfncFieldVal(.Fields("���X�֔ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�X�֔ԍ� = gfncFieldVal(.Fields("�X�֔ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�s���{�����J�i = gfncFieldVal(.Fields("�s���{�����J�i").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�s�撬�����J�i = gfncFieldVal(.Fields("�s�撬�����J�i").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���於�J�i = gfncFieldVal(.Fields("���於�J�i").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�s���{���� = gfncFieldVal(.Fields("�s���{����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�s�撬���� = gfncFieldVal(.Fields("�s�撬����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���於 = gfncFieldVal(.Fields("���於").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�꒬�敡���ԍ� = gfncFieldVal(.Fields("�꒬�敡���ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ԓn��ԕ\�� = gfncFieldVal(.Fields("�Ԓn��ԕ\��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���ڕ\�� = gfncFieldVal(.Fields("���ڕ\��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��ԍ��������� = gfncFieldVal(.Fields("��ԍ���������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�X�V�\�� = gfncFieldVal(.Fields("�X�V�\��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ύX���R = gfncFieldVal(.Fields("�ύX���R").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
        Catch ex As Exception
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
            '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
        '--�C���I���@2021�N06��08:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' �v���p�e�B
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : �S���n�������c�̃R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �S���n�������c�̃R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �S���n�������c�̃R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �S���n�������c�̃R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �S���n�������c�̃R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �S���n�������c�̃R�[�h
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
    Public Property �S���n�������c�̃R�[�h() As String
        Get
            �S���n�������c�̃R�[�h = mstr�S���n�������c�̃R�[�h
        End Get
        Set(ByVal Value As String)
            mstr�S���n�������c�̃R�[�h = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���X�֔ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : ���X�֔ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String         I     ���X�֔ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���X�֔ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : ���X�֔ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : ���X�֔ԍ�
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
    Public Property ���X�֔ԍ�() As String
        Get
            ���X�֔ԍ� = mstr���X�֔ԍ�
        End Get
        Set(ByVal Value As String)
            mstr���X�֔ԍ� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �X�֔ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �X�֔ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �X�֔ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �X�֔ԍ�
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
    Public Property �X�֔ԍ�() As String
        Get
            �X�֔ԍ� = mstr�X�֔ԍ�
        End Get
        Set(ByVal Value As String)
            mstr�X�֔ԍ� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �s���{�����J�i
    ' �X�R�[�v  : Public
    ' �������e  : �s���{�����J�i �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �s���{�����J�i
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �s���{�����J�i
    ' �X�R�[�v  : Public
    ' �������e  : �s���{�����J�i �擾
    ' ��    �l  :
    ' �� �� �l  : �s���{�����J�i
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
    Public Property �s���{�����J�i() As String
        Get
            �s���{�����J�i = mstr�s���{�����J�i
        End Get
        Set(ByVal Value As String)
            mstr�s���{�����J�i = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �s�撬�����J�i
    ' �X�R�[�v  : Public
    ' �������e  : �s�撬�����J�i �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �s�撬�����J�i
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �s�撬�����J�i
    ' �X�R�[�v  : Public
    ' �������e  : �s�撬�����J�i �擾
    ' ��    �l  :
    ' �� �� �l  : �s�撬�����J�i
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
    Public Property �s�撬�����J�i() As String
        Get
            �s�撬�����J�i = mstr�s�撬�����J�i
        End Get
        Set(ByVal Value As String)
            mstr�s�撬�����J�i = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���於�J�i
    ' �X�R�[�v  : Public
    ' �������e  : ���於�J�i �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���於�J�i
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���於�J�i
    ' �X�R�[�v  : Public
    ' �������e  : ���於�J�i �擾
    ' ��    �l  :
    ' �� �� �l  : ���於�J�i
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
    Public Property ���於�J�i() As String
        Get
            ���於�J�i = mstr���於�J�i
        End Get
        Set(ByVal Value As String)
            mstr���於�J�i = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �s���{����
    ' �X�R�[�v  : Public
    ' �������e  : �s���{���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �s���{����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �s���{����
    ' �X�R�[�v  : Public
    ' �������e  : �s���{���� �擾
    ' ��    �l  :
    ' �� �� �l  : �s���{����
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
    Public Property �s���{����() As String
        Get
            �s���{���� = mstr�s���{����
        End Get
        Set(ByVal Value As String)
            mstr�s���{���� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �s�撬����
    ' �X�R�[�v  : Public
    ' �������e  : �s�撬���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �s�撬����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �s�撬����
    ' �X�R�[�v  : Public
    ' �������e  : �s�撬���� �擾
    ' ��    �l  :
    ' �� �� �l  : �s�撬����
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
    Public Property �s�撬����() As String
        Get
            �s�撬���� = mstr�s�撬����
        End Get
        Set(ByVal Value As String)
            mstr�s�撬���� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���於
    ' �X�R�[�v  : Public
    ' �������e  : ���於 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���於
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���於
    ' �X�R�[�v  : Public
    ' �������e  : ���於 �擾
    ' ��    �l  :
    ' �� �� �l  : ���於
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
    Public Property ���於() As String
        Get
            ���於 = mstr���於
        End Get
        Set(ByVal Value As String)
            mstr���於 = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �꒬�敡���ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �꒬�敡���ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �꒬�敡���ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �꒬�敡���ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �꒬�敡���ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �꒬�敡���ԍ�
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
    Public Property �꒬�敡���ԍ�() As String
        Get
            �꒬�敡���ԍ� = mstr�꒬�敡���ԍ�
        End Get
        Set(ByVal Value As String)
            mstr�꒬�敡���ԍ� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ԓn��ԕ\��
    ' �X�R�[�v  : Public
    ' �������e  : �Ԓn��ԕ\�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �Ԓn��ԕ\��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ԓn��ԕ\��
    ' �X�R�[�v  : Public
    ' �������e  : �Ԓn��ԕ\�� �擾
    ' ��    �l  :
    ' �� �� �l  : �Ԓn��ԕ\��
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
    Public Property �Ԓn��ԕ\��() As String
        Get
            �Ԓn��ԕ\�� = mstr�Ԓn��ԕ\��
        End Get
        Set(ByVal Value As String)
            mstr�Ԓn��ԕ\�� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ڕ\��
    ' �X�R�[�v  : Public
    ' �������e  : ���ڕ\�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ڕ\��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ڕ\��
    ' �X�R�[�v  : Public
    ' �������e  : ���ڕ\�� �擾
    ' ��    �l  :
    ' �� �� �l  : ���ڕ\��
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
    Public Property ���ڕ\��() As String
        Get
            ���ڕ\�� = mstr���ڕ\��
        End Get
        Set(ByVal Value As String)
            mstr���ڕ\�� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��ԍ���������
    ' �X�R�[�v  : Public
    ' �������e  : ��ԍ��������� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��ԍ���������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��ԍ���������
    ' �X�R�[�v  : Public
    ' �������e  : ��ԍ��������� �擾
    ' ��    �l  :
    ' �� �� �l  : ��ԍ���������
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
    Public Property ��ԍ���������() As String
        Get
            ��ԍ��������� = mstr��ԍ���������
        End Get
        Set(ByVal Value As String)
            mstr��ԍ��������� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �X�V�\��
    ' �X�R�[�v  : Public
    ' �������e  : �X�V�\�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �X�V�\��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �X�V�\��
    ' �X�R�[�v  : Public
    ' �������e  : �X�V�\�� �擾
    ' ��    �l  :
    ' �� �� �l  : �X�V�\��
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
    Public Property �X�V�\��() As String
        Get
            �X�V�\�� = mstr�X�V�\��
        End Get
        Set(ByVal Value As String)
            mstr�X�V�\�� = Value
        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ύX���R
    ' �X�R�[�v  : Public
    ' �������e  : �ύX���R �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ύX���R
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ύX���R
    ' �X�R�[�v  : Public
    ' �������e  : �ύX���R �擾
    ' ��    �l  :
    ' �� �� �l  : �ύX���R
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
    Public Property �ύX���R() As String
        Get
            �ύX���R = mstr�ύX���R
        End Get
        Set(ByVal Value As String)
            mstr�ύX���R = Value
        End Set
    End Property
End Class
