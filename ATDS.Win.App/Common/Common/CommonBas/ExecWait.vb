Option Strict Off
Option Explicit On
Module basExecWait
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : ExecWait.bas
    ' ��    �e    : �O���v���O���� �N�� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncExecWait                 (�O���v���O�����N������)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Private Const PROCESS_QUERY_INFORMATION As Integer = &H400

    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    ' �����v���Z�X�I�u�W�F�N�g�̃n���h���擾
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer

    ' �����v���Z�X�I�u�W�F�N�g�̃n���h���J��
    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer

    ' �v���Z�X�̏I���X�e�[�^�X�擾
    Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As Integer, ByRef lpExitCode As Integer) As Integer

    ' ���s��~
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    '******************************************************************************
    ' �� �� ��  : gfncExecWait
    ' �X�R�[�v  :
    ' �������e  : �O���v���O�����N������
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrPathName        String            I     ���s�t�@�C���ւ̃p�X
    '   pintStyle           String            I     ���s���̕\���X�^�C��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncExecWait(ByVal pstrPathName As String, ByVal pintStyle As Short) As Boolean

        Dim lngPID As Integer ' �v���Z�XID
        Dim lngPrcHdl As Integer ' �v���Z�X�n���h��
        Dim lngEndCd As Integer ' �I���R�[�h
        Dim lngRet As Integer ' �߂�l

        ' ���A���ݒ�(�ُ�I��)
        gfncExecWait = False

        '--------------------------------------------------------------------------
        ' �����N��
        '--------------------------------------------------------------------------

        '++�C���J�n�@2022�N01��15��:MK�i��j- VB��VB.NET�ϊ�
        Dim intExe As Int16 = pstrPathName.IndexOf(".exe")
        If intExe > 0 Then
            Dim strFilePath As String = "C:\"
            Try
                Dim intLastPath As Int16 = InStrRev(pstrPathName, "\", intExe)
                '++�C���J�n�@2022�N01��24��:MK�i��j- VB��VB.NET�ϊ�
                'strFilePath = pstrPathName.Substring(0, intLastPath)
                '--�C���J�n�@2022�N01��24��:MK�i��j- VB��VB.NET�ϊ�
            Catch ex As Exception

            End Try

            If Not IO.Directory.Exists(strFilePath) Then
                Throw New Exception("�p�X��������܂���B")
            End If
        End If
        '--�C���J�n�@2022�N01��15��:MK�i��j- VB��VB.NET�ϊ�
        lngPID = Shell(pstrPathName, pintStyle)
        ' �O�����s�`���̋N���Ɏ��s������
        If lngPID = 0 Then

            ' �I��
            Exit Function

        End If

        lngPrcHdl = OpenProcess(PROCESS_QUERY_INFORMATION, True, lngPID)

        '--------------------------------------------------------------------------
        ' ��~�҂�
        '--------------------------------------------------------------------------
        Do

            lngRet = GetExitCodeProcess(lngPrcHdl, lngEndCd)

            Debug.Print("lngEndCd : " & lngEndCd)

            '        If lngEndCd <> 259 Then

            Exit Do

            '        End If

            Call Sleep(100)

            System.Windows.Forms.Application.DoEvents()

        Loop While lngEndCd

        CloseHandle(lngPrcHdl)

        ' ����I��
        gfncExecWait = True

    End Function
End Module