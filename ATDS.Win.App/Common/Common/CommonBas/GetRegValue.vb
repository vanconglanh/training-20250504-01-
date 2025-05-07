Option Strict Off
Option Explicit On
Imports Common
Imports Microsoft.Win32

Module basGetRegValue
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetPerfectNumber.bas
    ' 内    容    : レジストリ値 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetRegValue              (レジストリ値 取得)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/24  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const ERROR_SUCCESS As Integer = 0
    Private Const REG_OPTION_NON_VOLATILE As Integer = &H0

    Private Const KEY_QUERY_VALUE As Integer = &H1 ' サブキーデータの問い合わせを許可｡
    Private Const KEY_ENUMERATE_SUB_KEYS As Integer = &H8 ' サブキーの列挙を許可。
    Private Const KEY_NOTIFY As Integer = &H10 ' 変更の通知を許可｡
    Private Const KEY_CREATE_SUB_KEY As Integer = &H4 ' サブキーの作成を許可｡
    Private Const KEY_CREATE_LINK As Integer = &H20 ' シンボリックリンクの作成を許可｡
    Private Const KEY_SET_VALUE As Integer = &H2 ' サブキーデータの設定を許可｡
    Private Const KEY_ALL_ACCESS As Integer = KEY_QUERY_VALUE Or KEY_ENUMERATE_SUB_KEYS Or KEY_NOTIFY Or KEY_CREATE_SUB_KEY Or KEY_CREATE_LINK Or KEY_SET_VALUE
    Private Const KEY_READ As Integer = KEY_QUERY_VALUE Or KEY_ENUMERATE_SUB_KEYS Or KEY_NOTIFY
    Private Const KEY_WRITE As Integer = KEY_SET_VALUE Or KEY_CREATE_SUB_KEY

    '==============================================================================
    ' 列挙型
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

    ' DWORD型のタイプ
    Public Enum RegTypeConstants
        '=  REG_NONE = (0)                                              ' 定義されていない種類
        REG_SZ = (1) ' NULL で終わる文字列
        '=  REG_EXPAND_SZ = (2)                                         ' 展開前の環境変数への参照 が入った NULL で終わる文字列
        '=  REG_BINARY = (3)                                            ' 任意の形式のバイナリデータ
        REG_DWORD = (4) ' 32 ビット値
        REG_DWORD_LITTLE_ENDIAN = (4) ' リトルエンディアン形式の 32 ビット値
        '=  REG_DWORD_BIG_ENDIAN = (5)                                  ' ビッグエンディアン形式の 32 ビット値
        '=  REG_LINK = (6)                                              ' Unicode のシンボリックリンク
        '=  REG_MULTI_SZ = (7)                                          ' NULL で終わる文字列の配列
        '=  REG_RESOURCE_LIST = (8)                                     ' デバイスドライバのリソースリスト
    End Enum

    '==============================================================================
    ' 構造体
    '==============================================================================
    Private Structure SECURITY_ATTRIBUTES
        Dim nLength As Integer
        Dim lpSecurityDescriptor As Integer
        Dim bInheritHandle As Integer
    End Structure

    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    ' 指定されたレジストリキーを作成する。キーがすでに存在している場合は、そのキーをオープンする。
    'UPGRADE_WARNING: Structure SECURITY_ATTRIBUTES may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function RegCreateKeyEx Lib "advapi32" Alias "RegCreateKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal Reserved As Integer, ByVal lpClass As String, ByVal dwOptions As Integer, ByVal samDesired As Integer, ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByRef phkResult As Integer, ByRef lpdwDisposition As Integer) As Integer

    ' オープンしているレジストリキーの値フィールドに、データを格納する。
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    'Private Declare Function RegSetValueEx Lib "advapi32" Alias "RegSetValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByRef szData As Any, ByVal cbData As Integer) As Integer
    Private Declare Function RegSetValueEx Lib "advapi32" Alias "RegSetValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByRef szData As String, ByVal cbData As Integer) As Integer
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    ' 指定されたキーをオープンする。
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    'Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    ' オープンされたキーに関連付けられている指定された値を取得する。
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    'Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByRef lpData As Any, ByRef lpcbData As Integer) As Integer
    Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByRef lpData As String, ByRef lpcbData As Integer) As Integer
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    ' 指定されたキーのハンドルを閉じる。
    Private Declare Function RegCloseKey Lib "advapi32" (ByVal hKey As Integer) As Integer
    '******************************************************************************
    ' 関 数 名  : gfncGetRegValue
    ' スコープ  : Public
    ' 処理内容  : レジストリ値 取得
    ' 備    考  :
    ' 返 り 値  : レジストリの値
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   plnghInKey          hKeyConstants     I     キー
    '   pstrSubKey          String            I     サブキー
    '   pstrValName         String            I     値
    '   plngType            RegTypeConstants  I     データタイプ
    '   pvntDefault         Variant           I     デフォルトの値
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/24  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetRegValue(ByVal plnghInKey As hKeyConstants, ByVal pstrSubKey As String, ByVal pstrValName As String, ByRef plngType As RegTypeConstants, ByVal pvntDefault As Object) As Object

        '++修正開始　2021年05月29日:MK（手）- VB→VB.NET変換
        'Dim iStartChar As Integer = pstrSubKey.LastIndexOf("\")
        'Dim keyName As String = pstrSubKey.Substring(iStartChar + 1, pstrSubKey.Length - iStartChar - 1)
        Return RegQueryValueEx(plnghInKey, pstrSubKey, "", plngType, pstrValName)


        '++修正開始　2021年05月29日:MK（手）- VB→VB.NET変換
        'On Error GoTo PROC_ERROR

        'Const C_NAME_FUNCTION As String = "gfncGetRegValue"

        'Dim vntRetVal As Object
        'Dim lnghSubKey As Integer
        'Dim lngBuffer As Integer
        'Dim strBuffer As String
        'Dim lngResult As Integer

        ''UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'gfncGetRegValue = ""

        '' デフォルトの値を代入。
        ''UPGRADE_WARNING: Couldn't resolve default property of object pvntDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object vntRetVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'vntRetVal = pvntDefault

        '' レジストリの指定したキーをオープンする。
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

        '            ' バッファを確保
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
        '--修正開始　2021年05月29日:MK（手）- VB→VB.NET変換

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