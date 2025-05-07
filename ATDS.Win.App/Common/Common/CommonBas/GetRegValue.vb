Option Strict Off
Option Explicit On
Imports Common
Imports Microsoft.Win32

Module basGetRegValue
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetPerfectNumber.bas
    ' ��    �e    : ���W�X�g���l �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetRegValue              (���W�X�g���l �擾)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/24  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Private Const ERROR_SUCCESS As Integer = 0
    Private Const REG_OPTION_NON_VOLATILE As Integer = &H0

    Private Const KEY_QUERY_VALUE As Integer = &H1 ' �T�u�L�[�f�[�^�̖₢���킹�����¡
    Private Const KEY_ENUMERATE_SUB_KEYS As Integer = &H8 ' �T�u�L�[�̗񋓂����B
    Private Const KEY_NOTIFY As Integer = &H10 ' �ύX�̒ʒm�����¡
    Private Const KEY_CREATE_SUB_KEY As Integer = &H4 ' �T�u�L�[�̍쐬�����¡
    Private Const KEY_CREATE_LINK As Integer = &H20 ' �V���{���b�N�����N�̍쐬�����¡
    Private Const KEY_SET_VALUE As Integer = &H2 ' �T�u�L�[�f�[�^�̐ݒ�����¡
    Private Const KEY_ALL_ACCESS As Integer = KEY_QUERY_VALUE Or KEY_ENUMERATE_SUB_KEYS Or KEY_NOTIFY Or KEY_CREATE_SUB_KEY Or KEY_CREATE_LINK Or KEY_SET_VALUE
    Private Const KEY_READ As Integer = KEY_QUERY_VALUE Or KEY_ENUMERATE_SUB_KEYS Or KEY_NOTIFY
    Private Const KEY_WRITE As Integer = KEY_SET_VALUE Or KEY_CREATE_SUB_KEY

    '==============================================================================
    ' �񋓌^
    '==============================================================================
    Public Enum hKeyConstants
        HKEY_CLASSES_ROOT = &H80000000
        HKEY_CURRENT_USER = &H80000001
        HKEY_LOCAL_MACHINE = &H80000002
        HKEY_USERS = &H80000003
        HKEY_PERFORMANCE_DATA = &H80000004
        HKEY_CURRENT_CONFIG = &H80000005
        HKEY_DYN_DATA = &H80000006
    End Enum

    ' DWORD�^�̃^�C�v
    Public Enum RegTypeConstants
        '=  REG_NONE = (0)                                              ' ��`����Ă��Ȃ����
        REG_SZ = (1) ' NULL �ŏI��镶����
        '=  REG_EXPAND_SZ = (2)                                         ' �W�J�O�̊��ϐ��ւ̎Q�� �������� NULL �ŏI��镶����
        '=  REG_BINARY = (3)                                            ' �C�ӂ̌`���̃o�C�i���f�[�^
        REG_DWORD = (4) ' 32 �r�b�g�l
        REG_DWORD_LITTLE_ENDIAN = (4) ' ���g���G���f�B�A���`���� 32 �r�b�g�l
        '=  REG_DWORD_BIG_ENDIAN = (5)                                  ' �r�b�O�G���f�B�A���`���� 32 �r�b�g�l
        '=  REG_LINK = (6)                                              ' Unicode �̃V���{���b�N�����N
        '=  REG_MULTI_SZ = (7)                                          ' NULL �ŏI��镶����̔z��
        '=  REG_RESOURCE_LIST = (8)                                     ' �f�o�C�X�h���C�o�̃��\�[�X���X�g
    End Enum

    '==============================================================================
    ' �\����
    '==============================================================================
    Private Structure SECURITY_ATTRIBUTES
        Dim nLength As Integer
        Dim lpSecurityDescriptor As Integer
        Dim bInheritHandle As Integer
    End Structure

    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    ' �w�肳�ꂽ���W�X�g���L�[���쐬����B�L�[�����łɑ��݂��Ă���ꍇ�́A���̃L�[���I�[�v������B
    'UPGRADE_WARNING: Structure SECURITY_ATTRIBUTES may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function RegCreateKeyEx Lib "advapi32" Alias "RegCreateKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal Reserved As Integer, ByVal lpClass As String, ByVal dwOptions As Integer, ByVal samDesired As Integer, ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByRef phkResult As Integer, ByRef lpdwDisposition As Integer) As Integer

    ' �I�[�v�����Ă��郌�W�X�g���L�[�̒l�t�B�[���h�ɁA�f�[�^���i�[����B
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    'Private Declare Function RegSetValueEx Lib "advapi32" Alias "RegSetValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByRef szData As Any, ByVal cbData As Integer) As Integer
    Private Declare Function RegSetValueEx Lib "advapi32" Alias "RegSetValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByRef szData As String, ByVal cbData As Integer) As Integer
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    ' �w�肳�ꂽ�L�[���I�[�v������B
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    'Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    ' �I�[�v�����ꂽ�L�[�Ɋ֘A�t�����Ă���w�肳�ꂽ�l���擾����B
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    'Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByRef lpData As Any, ByRef lpcbData As Integer) As Integer
    Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByRef lpData As String, ByRef lpcbData As Integer) As Integer
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    ' �w�肳�ꂽ�L�[�̃n���h�������B
    Private Declare Function RegCloseKey Lib "advapi32" (ByVal hKey As Integer) As Integer
    '******************************************************************************
    ' �� �� ��  : gfncGetRegValue
    ' �X�R�[�v  : Public
    ' �������e  : ���W�X�g���l �擾
    ' ��    �l  :
    ' �� �� �l  : ���W�X�g���̒l
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   plnghInKey          hKeyConstants     I     �L�[
    '   pstrSubKey          String            I     �T�u�L�[
    '   pstrValName         String            I     �l
    '   plngType            RegTypeConstants  I     �f�[�^�^�C�v
    '   pvntDefault         Variant           I     �f�t�H���g�̒l
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/24  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetRegValue(ByVal plnghInKey As hKeyConstants, ByVal pstrSubKey As String, ByVal pstrValName As String, ByRef plngType As RegTypeConstants, ByVal pvntDefault As Object) As Object

        '++�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�
        'Dim iStartChar As Integer = pstrSubKey.LastIndexOf("\")
        'Dim keyName As String = pstrSubKey.Substring(iStartChar + 1, pstrSubKey.Length - iStartChar - 1)
        Return RegQueryValueEx(plnghInKey, pstrSubKey, "", plngType, pstrValName)


        '++�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR

        'Const C_NAME_FUNCTION As String = "gfncGetRegValue"

        'Dim vntRetVal As Object
        'Dim lnghSubKey As Integer
        'Dim lngBuffer As Integer
        'Dim strBuffer As String
        'Dim lngResult As Integer

        ''UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'gfncGetRegValue = ""

        '' �f�t�H���g�̒l�����B
        ''UPGRADE_WARNING: Couldn't resolve default property of object pvntDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object vntRetVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'vntRetVal = pvntDefault

        '' ���W�X�g���̎w�肵���L�[���I�[�v������B
        'lngResult = RegOpenKeyEx(plnghInKey, pstrSubKey, 0, KEY_ALL_ACCESS, lnghSubKey)

        'If lngResult = ERROR_SUCCESS Then

        '    Select Case plngType
        '        Case RegTypeConstants.REG_DWORD, RegTypeConstants.REG_DWORD_LITTLE_ENDIAN

        '            lngBuffer = 0

        '            lngResult = RegQueryValueEx(lnghSubKey, pstrValName, 0, RegTypeConstants.REG_DWORD, lngBuffer, Len(lngBuffer))

        '            If lngResult = ERROR_SUCCESS Then

        '                'UPGRADE_WARNING: Couldn't resolve default property of object vntRetVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                vntRetVal = lngBuffer

        '            End If

        '        Case RegTypeConstants.REG_SZ

        '            ' �o�b�t�@���m��
        '            strBuffer = New String(vbNullChar, 256)

        '            lngResult = RegQueryValueEx(lnghSubKey, pstrValName, 0, RegTypeConstants.REG_SZ, strBuffer, Len(strBuffer))

        '            If lngResult = ERROR_SUCCESS Then

        '                'UPGRADE_WARNING: Couldn't resolve default property of object vntRetVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                vntRetVal = Left(strBuffer, InStr(strBuffer, vbNullChar) - 1)

        '            End If

        '    End Select

        '    lngResult = RegCloseKey(lnghSubKey)

        'End If

        ''UPGRADE_WARNING: Couldn't resolve default property of object vntRetVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'gfncGetRegValue = vntRetVal

PROC_END:

        'Exit Function

PROC_ERROR:

        'Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

        'Resume PROC_END
        '--�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�

    End Function



#Region "Registry"
    ''' <summary>
    ''' Get key type and key value of registry
    ''' </summary>
    ''' <param name="hKey"></param>
    ''' <param name="SubKeyName"></param>
    ''' <param name="KeyName">Registry key</param>
    ''' <param name="keyType">Key type</param>
    ''' <param name="keyValue">Key value</param>
    ''' <returns></returns>
    Public Function RegQueryValueEx(ByVal hKey As hKeyConstants,
                                    ByVal SubKeyName As String,
                                    ByVal KeyName As String,
                                    Optional ByRef keyType As Short = -1,
                                    Optional ByRef keyValue As String = "") As String

        Try

            Dim subKey As RegistryKey = Nothing

            Select Case hKey
                Case hKeyConstants.HKEY_CLASSES_ROOT
                    keyValue = My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.ClassesRoot.OpenSubKey(SubKeyName)
                Case hKeyConstants.HKEY_CURRENT_CONFIG
                    keyValue = My.Computer.Registry.GetValue("HKEY_CURRENT_CONFIG\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.CurrentConfig.OpenSubKey(SubKeyName)
                Case hKeyConstants.HKEY_CURRENT_USER
                    keyValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.CurrentUser.OpenSubKey(SubKeyName)
                Case hKeyConstants.HKEY_DYN_DATA
                    keyValue = My.Computer.Registry.GetValue("HKEY_DYN_DATA\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.DynData.OpenSubKey(SubKeyName)
                Case hKeyConstants.HKEY_LOCAL_MACHINE
                    keyValue = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.LocalMachine.OpenSubKey(SubKeyName)
                Case hKeyConstants.HKEY_PERFORMANCE_DATA
                    keyValue = My.Computer.Registry.GetValue("HKEY_PERFORMANCE_DATA\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.PerformanceData.OpenSubKey(SubKeyName)
                Case hKeyConstants.HKEY_USERS
                    keyValue = My.Computer.Registry.GetValue("HKEY_USERS\" & SubKeyName, KeyName, "")
                    subKey = My.Computer.Registry.Users.OpenSubKey(SubKeyName)
            End Select


            Dim type As RegistryValueKind = subKey.GetValueKind(KeyName)
            Select Case type
                Case RegistryValueKind.String
                    keyType = 1
                Case RegistryValueKind.Binary
                    keyType = 3
                Case RegistryValueKind.DWord
                    keyType = 4
            End Select

            RegQueryValueEx = keyValue

            'If keyValue = "" Then
            '    Return -1
            'Else
            '    Return 0
            'End If

        Catch ex As Exception
            RegQueryValueEx = ""
        End Try
    End Function


    ''' <summary>
    ''' Get key type and key value of registry
    ''' </summary>
    ''' <param name="KeyName">Registry key</param>
    ''' <param name="keyValue">Key value</param>
    ''' <returns></returns>
    Public Function RegSetValueEx(ByVal KeyName As String, keyValue As String) As Integer

        Try

            'Add sub key
            Dim subKey As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(CommonConst.SUBKEY_ROOT)
            If subKey Is Nothing Then
                subKey = My.Computer.Registry.CurrentUser.CreateSubKey(CommonConst.SUBKEY_ROOT)
            End If

            'Add registry value
            subKey.SetValue(KeyName, keyValue)
            subKey.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

End Module