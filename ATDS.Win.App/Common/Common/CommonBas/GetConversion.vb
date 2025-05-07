Option Strict Off
Option Explicit On
Imports Common
Imports OneTechConvertUtils
Module basGetConversion
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetConversion.bas
    ' ��    �e    : ��݉��� �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetConversion            (��݉��� �擾 ����)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Const GCL_CONVERSION As Short = 1 '�\�[�X�͓ǂݕ�����
    Const GCL_REVERSECONVERSION As Short = 2 '�\�[�X�͕ϊ�����(����)

    Const VER_PLATFORM_WIN32_WINDOWS As Short = 1 'OS��Win9X�n
    Const VER_PLATFORM_WIN32_NT As Short = 2 'OS��WinNT�n

    '==============================================================================
    ' �\����
    '==============================================================================
    'IME �֘A
    Private Structure CANDIDATELIST
        Dim dwSize As Integer
        Dim dwStyle As Integer
        Dim dwCount As Integer
        Dim dwSelection As Integer
        Dim dwPageStart As Integer
        Dim dwPageSize As Integer
        <VBFixedArray(0)> Dim dwOffset() As Integer

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim dwOffset(0)
        End Sub
    End Structure

    'OS �o�[�W�����擾
    Private Structure OSVERSIONINFO
        Dim dwOSVersionInfoSize As Integer
        Dim dwMajorVersion As Integer
        Dim dwMinorVersion As Integer
        Dim dwBuildNumber As Integer
        Dim dwPlatformId As Integer
        <VBFixedArray(127)> Dim szCSDVersion() As Byte

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
        Public Sub Initialize()
            ReDim szCSDVersion(127)
        End Sub
    End Structure

    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    '���̓R���e�L�X�g�n���h���擾
    Private Declare Function ImmGetContext Lib "imm32" (ByVal hWnd As Integer) As Integer

    '���̓R���e�L�X�g�n���h���J��
    Private Declare Function ImmReleaseContext Lib "imm32" (ByVal hWnd As Integer, ByVal hIMC As Integer) As Integer

    '�ϊ����擾
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    'Private Declare Function ImmGetConversionList Lib "imm32" Alias "ImmGetConversionListW" (ByVal hKL As Integer, ByVal hIMC As Integer, ByRef lpSrc As Byte, ByRef lpDst As Any, ByVal dwBufLen As Integer, ByVal uFlag As Integer) As Integer
    Private Declare Function ImmGetConversionList Lib "imm32" Alias "ImmGetConversionListW" (ByVal hKL As Integer, ByVal hIMC As Integer, ByRef lpSrc As Byte, ByRef lpDst As String, ByVal dwBufLen As Integer, ByVal uFlag As Integer) As Integer
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    '���̓��P�[�����ʎq(�L�[�{�[�h���C�A�E�g�n���h��)�擾
    Private Declare Function GetKeyboardLayout Lib "user32" (ByVal idThread As Integer) As Integer

    'Unicode�����񒷎擾
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_003 VB��VB.NET�ϊ�
    'Private Declare Function lstrlen Lib "kernel32"  Alias "lstrlenW"(ByRef strString As Any) As Integer
    Private Declare Function lstrlen Lib "kernel32" Alias "lstrlenW" (ByRef strString As String) As Integer
    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_003 VB��VB.NET�ϊ�

    'OS �o�[�W�����擾
    'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function GetVersionEx Lib "kernel32" Alias "GetVersionExA" (ByRef VersionInfo As OSVERSIONINFO) As Integer

    '�������ړ�
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_003 VB��VB.NET�ϊ�
    'Private Declare Sub MoveMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
    Private Declare Sub MoveMemory Lib "kernel32" Alias "RtlMoveMemory" (ByRef Destination As basGetConversion.CANDIDATELIST, ByRef Source As String, ByVal Length As Integer)
    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_003 VB��VB.NET�ϊ�
    '******************************************************************************
    ' �� �� ��  : gfncGetConversion
    ' �X�R�[�v  : Private
    ' �������e  : ��݂��� �擾
    ' ��    �l  :
    ' �� �� �l  : ��݂��ȁi�S�p�Ђ炪�ȁj
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrText            String            I     �ϊ��Ώۃe�L�X�g
    '   phWndIMEOwner       Long              I     �E�B���h�E�n���h��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/03/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetConversion(ByRef pstrText As String, ByRef phWndIMEOwner As Integer) As String

        Dim abytText() As Byte '�O�ϊ��p
        Dim lnghIMC As Integer '���̓R���e�L�X�g�n���h��
        Dim lnghKL As Integer '�L�[�{�[�h���C�A�E�g�n���h��
        Dim lngSize As Integer '�ϊ���o�b�t�@�T�C�Y
        Dim lngOffset As Integer '�ϊ���������I�t�Z�b�g�A�h���X

        Dim abytCandiateArray() As Byte '�ϊ����ʃo�b�t�@
        Dim lngRet As Integer

        'UPGRADE_WARNING: Arrays in structure typCandiateList may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim typCandiateList As CANDIDATELIST
        'UPGRADE_WARNING: Arrays in structure typOSVersion may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim typOSVersion As OSVERSIONINFO

        '�󕶎���̏ꍇ�͏������Ȃ�
        If pstrText = "" Then

            Exit Function

        End If

        'OS�o�[�W��������
        '++�C���J�n�@2021�N07��27��:MK�i��j- VB��VB.NET�ϊ�
        'typOSVersion.dwOSVersionInfoSize = Len(typOSVersion)
        'lngRet = GetVersionEx(typOSVersion)
        '--�C���J�n�@2021�N07��27��:MK�i��j- VB��VB.NET�ϊ�

        'WinNT�n=>Unicode�̂܂�
        '++�C���J�n�@2021�N07��27��:MK�i��j- VB��VB.NET�ϊ�
        'If typOSVersion.dwPlatformId = VER_PLATFORM_WIN32_NT Then

        '    'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
        '    abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(pstrText)

        '    'Null�I�[��t��
        '    ReDim Preserve abytText(UBound(abytText) + 2)

        '    'Win9X�n=>S-JIS�ɕϊ�
        'Else

        '    'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
        '    'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
        '    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
        '    'abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pstrText, vbFromUnicode))
        '    abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(Utils.StrConv(pstrText, vbFromUniCode))
        '    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

        '    'Null�I�[��t��
        '    ReDim Preserve abytText(UBound(abytText) + 1)

        'End If
        abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(Utils.StrConv(pstrText, vbFromUniCode))
        '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

        'Null�I�[��t��
        ReDim Preserve abytText(UBound(abytText) + 1)
        '--�C���J�n�@2021�N07��27��:MK�i��j- VB��VB.NET�ϊ�

        'IME�̓��̓R���e�L�X�g�ƃL�[�{�[�h���C�A�E�g�R���e�L�X�g�擾
        lnghIMC = ImmGetContext(phWndIMEOwner)

        lnghKL = GetKeyboardLayout(0)

        '�ϊ����ʂ��󂯎��o�b�t�@�T�C�Y���擾
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        'lngSize = ImmGetConversionList(lnghKL, lnghIMC, abytText(0), System.DBNull.Value, 0, GCL_REVERSECONVERSION)
        lngSize = ImmGetConversionList(lnghKL, lnghIMC, abytText(0), String.Empty, 0, GCL_REVERSECONVERSION)
        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

        If lngSize > 0 Then

            '�o�b�t�@�T�C�Y���o�C�g�z��𓮓I�Ɏ擾
            ReDim abytCandiateArray(lngSize)

            '�ϊ����ʂ��擾
            lngSize = ImmGetConversionList(hKL:=lnghKL, hIMC:=lnghIMC, lpSrc:=abytText(0), lpDst:=abytCandiateArray(0), dwBufLen:=lngSize, uFlag:=GCL_REVERSECONVERSION)

            '�o�b�t�@���e���Q�Ƃ��邽�ߍ\���̂ɃR�s�[
            'UPGRADE_WARNING: Couldn't resolve default property of object typCandiateList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
            'MoveMemory(typCandiateList, abytCandiateArray(0), Len(typCandiateList))
            MoveMemory(typCandiateList, abytCandiateArray(0), Len(typCandiateList))
            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

            If typCandiateList.dwCount > 0 Then

                '�擪���̃I�t�Z�b�g�擾
                lngOffset = typCandiateList.dwOffset(0)

                '�ӂ肪�Ȏ擾
                'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                'gfncGetConversion = MidB(abytCandiateArray, lngOffset + 1, lstrlen(abytCandiateArray(lngOffset)) * 2)
                gfncGetConversion = Utils.MidB(abytCandiateArray, lngOffset + 1, lstrlen(abytCandiateArray(lngOffset)) * 2)
                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

            End If

        End If

        '���̓R���e�L�X�g�̉��
        lngRet = ImmReleaseContext(phWndIMEOwner, lnghIMC)

    End Function
End Module
