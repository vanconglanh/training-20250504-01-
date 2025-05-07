Option Strict Off
Option Explicit On
Imports Common
Imports Microsoft.VisualBasic.Compatibility
Imports OneTechConvertUtils
Module basGetIniInfo
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetIniInfo.bas
    ' ��    �e    : �h�m�h�t�@�C�� �ݒ��� �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetIniInteger            (�h�m�h�ݒ���擾(���l))
    '                   gfncGetIniString             (�h�m�h�ݒ���擾(����))
    '               <Private>
    '                   mfncGetOS                    (�n�r���擾)
    '                   mfncGetPrivateProfileString  (�h�m�h�ݒ���擾(OS���ɐؑ�))
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
    Private Const VER_PLATFORM_WIN32_WINDOWS As Short = 1
    Private Const VER_PLATFORM_WIN32_NT As Short = 2

    Private Const MC_BUFF_SIZE As Integer = 255

    '==============================================================================
    ' �\����
    '==============================================================================
    Private Structure OSVERSIONINFO
        Dim dwOSVersionInfoSize As Integer
        Dim dwMajorVersion As Integer
        Dim dwMinorVersion As Integer
        Dim dwBuildNumber As Integer
        Dim dwPlatformId As Integer
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(128), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=128)> Public szCSDVersion() As Char
    End Structure

    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function GetVersionExA Lib "kernel32" (ByRef verinfo As OSVERSIONINFO) As Integer

    'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function GetVersionExW Lib "kernel32" (ByRef verinfo As OSVERSIONINFO) As Integer

    ' INI�t�@�C���Ǎ���(String�^)�֐�
    Private Declare Function GetPrivateProfileStringA Lib "kernel32" (ByVal section As String, ByVal entry As String, ByVal def As String, ByVal buf As String, ByVal size As Integer, ByVal ininm As String) As Integer

    Private Declare Function GetPrivateProfileStringW Lib "kernel32" (ByVal section As String, ByVal entry As String, ByVal def As String, ByVal buf As String, ByVal size As Integer, ByVal ininm As String) As Integer

    ' INI�t�@�C���Ǎ���(Integer�^)�֐�
    Private Declare Function GetPrivateProfileInt Lib "kernel32" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
    '******************************************************************************
    ' �� �� ��  : gfncGetIniString
    ' �X�R�[�v  : Public
    ' �������e  : INI�t�@�C�����ݒ���(������)�擾
    ' ��    �l  :
    ' �� �� �l  : �擾�����f�[�^
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrSection         String            I     �Z�N�V������
    '   pstrKey             String            I     �L�[��
    '   pstrFileName        String            I     INI�t�@�C�����i�p�X�܂ށj
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetIniString(ByVal pstrSection As String, ByVal pstrKey As String, ByVal pstrFileName As String) As String

        Dim lngDatLng As Integer
        Dim strBuff As New VB6.FixedLengthString(MC_BUFF_SIZE)
        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        'If mfncGetOS() = VER_PLATFORM_WIN32_NT Then

        '    lngDatLng = GetPrivateProfileStringW(pstrSection, pstrKey, "", strBuff.Value, MC_BUFF_SIZE, pstrFileName)

        'Else

        '    lngDatLng = GetPrivateProfileStringA(pstrSection, pstrKey, "", strBuff.Value, MC_BUFF_SIZE, pstrFileName)

        'End If
        lngDatLng = GetPrivateProfileStringA(pstrSection, pstrKey, "", strBuff.Value, MC_BUFF_SIZE, pstrFileName)
        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

        gfncGetIniString = Left(strBuff.Value, InStr(strBuff.Value, vbNullChar) - 1)

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetIniInteger
    ' �X�R�[�v  : Public
    ' �������e  : INI�t�@�C�����ݒ���(���l)�擾
    ' ��    �l  :
    ' �� �� �l  : �擾�����f�[�^
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrSection         String            I     �Z�N�V������
    '   pstrKey             String            I     �L�[��
    '   pstrFileName        String            I     INI�t�@�C�����i�p�X�܂ށj
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetIniInteger(ByVal pstrSection As String, ByVal pstrKey As String, ByVal pstrFileName As String) As Short

        gfncGetIniInteger = GetPrivateProfileInt(pstrSection, pstrKey, GC_CODE_ERR, pstrFileName)

    End Function
    '******************************************************************************
    ' �� �� ��  : mfncGetOS
    ' �X�R�[�v  : Private
    ' �������e  : OS �o�[�W���������擾���āA�v���b�g�t�H�[������Ԃ��B
    ' ��    �l  :
    ' �� �� �l  : OS �v���b�g�t�H�[�����
    '             VER_PLATFORM_WIN32_WINDOWS = Windows 95�A98
    '             VER_PLATFORM_WIN32_NT      = Windows NT
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Function mfncGetOS() As Integer

        Static osinfo As OSVERSIONINFO
        Static blnInit As Boolean

        Dim lngRcd As Integer

        '** OS �o�[�W�������擾
        If blnInit = False Then

            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
            'osinfo.dwOSVersionInfoSize = LenB(osinfo)
            osinfo.dwOSVersionInfoSize = Utils.LenB(osinfo)
            '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

            On Error Resume Next

            If GetVersionExA(osinfo) = False Then osinfo.dwPlatformId = VER_PLATFORM_WIN32_WINDOWS

            lngRcd = Err.Number

            On Error GoTo 0

            If lngRcd <> 0 Then
                If GetVersionExW(osinfo) = False Then osinfo.dwPlatformId = VER_PLATFORM_WIN32_WINDOWS
            End If

            blnInit = True

        End If

        '** OS �v���b�g�t�H�[�����Z�b�g
        mfncGetOS = osinfo.dwPlatformId

    End Function
End Module
