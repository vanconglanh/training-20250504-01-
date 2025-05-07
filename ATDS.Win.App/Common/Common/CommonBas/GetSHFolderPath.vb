Option Strict Off
Option Explicit On
Module basGetSHFolderPath
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetSHFolderPath.bas
    ' ��    �e    : �w��t�H���_�p�X �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetSHFolderPath            (�w��t�H���_�p�X �擾)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/10/10  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    Public Const S_OK As Integer = &H0 ' ����I��
    Public Const S_FALSE As Integer = &H1 ' �ُ�I��
    Public Const E_INVALIDARG As Integer = &H80070057 ' ������CSIDL�l���w��

    '----------------------------------
    ' CSIDL�l
    '----------------------------------
    Public Const CSIDL_DESKTOP As Integer = &H0 ' �f�X�N�g�b�v
    Public Const CSIDL_INTERNET As Integer = &H1 ' Internet Explorer
    Public Const CSIDL_PROGRAMS As Integer = &H2 ' �X�^�[�g���j���[\�v���O����
    Public Const CSIDL_CONTROLS As Integer = &H3 ' �R���g���[�� �p�l��
    Public Const CSIDL_PRINTERS As Integer = &H4 ' �v�����^
    Public Const CSIDL_PERSONAL As Integer = &H5 ' �}�C�h�L�������g
    Public Const CSIDL_FAVORITES As Integer = &H6 ' ���C�ɓ���
    Public Const CSIDL_STARTUP As Integer = &H7 ' �X�^�[�g�A�b�v
    Public Const CSIDL_RECENT As Integer = &H8 ' �ŋߎg�����t�@�C��
    Public Const CSIDL_SENDTO As Integer = &H9 ' ����
    Public Const CSIDL_BITBUCKET As Integer = &HA ' ���ݔ�
    Public Const CSIDL_STARTMENU As Integer = &HB ' �X�^�[�g���j���[
    Public Const CSIDL_MYMUSIC As Integer = &HD ' �}�C�~���[�W�b�N
    Public Const CSIDL_MYVIDEO As Integer = &HE ' �}�C�r�f�I
    ' �f�X�N�g�b�v�f�B���N�g��
    Public Const CSIDL_DESKTOPDIRECTORY As Integer = &H10 ' �f�X�N�g�b�v�f�B���N�g��
    Public Const CSIDL_DRIVES As Integer = &H11 ' �}�C �R���s���[�^
    Public Const CSIDL_NETWORK As Integer = &H12 ' �}�C�l�b�g���[�N
    Public Const CSIDL_NETHOOD As Integer = &H13 ' �l�b�g���[�N
    Public Const CSIDL_FONTS As Integer = &H14 ' �t�H���g
    Public Const CSIDL_TEMPLATES As Integer = &H15 ' �e���v���[�g
    Public Const CSIDL_APPDATA As Integer = &H1A ' �A�v���P�[�V�����f�[�^
    Public Const CSIDL_PRINTHOOD As Integer = &H1B ' �v�����^
    Public Const CSIDL_LOCAL_APPDATA As Integer = &H1C ' ���[�J���A�v���P�[�V�����f�[�^
    Public Const CSIDL_ALTSTARTUP As Integer = &H1D ' �񃍁[�J���C�Y�X�^�[�g�A�b�v
    Public Const CSIDL_INTERNET_CACHE As Integer = &H20 ' �C���^�[�l�b�g�L���b�V��
    Public Const CSIDL_COOKIES As Integer = &H21 ' �N�b�L�[(IE)
    Public Const CSIDL_HISTORY As Integer = &H22 ' ����(IE)
    Public Const CSIDL_WINDOWS As Integer = &H24 ' Windows�f�B���N�g��
    Public Const CSIDL_SYSTEM As Integer = &H25 ' System�f�B���N�g��
    Public Const CSIDL_PROGRAM_FILES As Integer = &H26 ' C:\Program Files
    Public Const CSIDL_MYPICTURES As Integer = &H27 ' �}�C�s�N�`��
    Public Const CSIDL_PROFILE As Integer = &H28 ' �v���t�@�C��
    Public Const CSIDL_ADMINTOOLS As Integer = &H30 ' �Ǘ��c�[��
    Public Const CSIDL_CONNECTIONS As Integer = &H31 ' �l�b�g���[�N�ڑ�
    Public Const CSIDL_FLAG_CREATE As Integer = &H8000

    '----------------------------------
    ' �擾�t���O
    '----------------------------------
    Private Const SHGFP_TYPE_CURRENT As Short = 0 ' ���݂̃t�H���_
    Private Const SHGFP_TYPE_DEFAULT As Short = 1 ' �W���̃t�H���_

    Private Const MAX_PATH As Short = 260 ' �p�X�ő咷

    ' CSIDL�l����, �Ή�����t�H���_�̃p�X�����擾
    Private Declare Function SHGetFolderPath Lib "shfolder" Alias "SHGetFolderPathA" (ByVal hwndOwner As Integer, ByVal nFolder As Integer, ByVal hToken As Integer, ByVal dwFlags As Integer, ByVal pszPath As String) As Integer
    '******************************************************************************
    ' �� �� ��  : gfncGetSHFolderPath
    ' �X�R�[�v  :
    ' �������e  : �w��t�H���_�p�X �擾
    ' ��    �l  :
    ' �� �� �l  : 0x00000001 (S_FALSE)
    '             0x80000008 (E_FAIL)
    '             0x80000003 (E_INVALIDARG)
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   plngCSIDL           Long              I     CSIDL�l
    '   pstrPath            String            O     �t�H���_�p�X
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/10/10  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetSHFolderPath(ByVal plngCSIDL As Integer, ByRef pstrPath As String) As Integer

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetSHFolderPath"
        Dim strTemp As String
        Dim lngRet As Integer
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncGetSHFolderPath"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strTemp As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim lngRet As Integer
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            strTemp = New String(Chr(0), MAX_PATH)

            gfncGetSHFolderPath = SHGetFolderPath(0, plngCSIDL, 0, SHGFP_TYPE_CURRENT, strTemp)

            pstrPath = Left(strTemp, InStr(strTemp, vbNullChar) - 1)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1c99ecad-6205-4a4c-9dea-4f06ec6e6f33
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1c99ecad-6205-4a4c-9dea-4f06ec6e6f33
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dfd80526-b786-41b4-940b-f9dd84f3ef93
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dfd80526-b786-41b4-940b-f9dd84f3ef93

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dfd80526-b786-41b4-940b-f9dd84f3ef93
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dfd80526-b786-41b4-940b-f9dd84f3ef93
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
