Option Strict Off
Option Explicit On
Module basGetUserInfo
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetUserInfo.bas
    ' 内    容    : 端末情報取得モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetIpAddress         (IPアドレス取得)
    '                   gfncGetComputerName      (端末名取得)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/07/01  ＫＳＲ             新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 変数・配列
    '==============================================================================
    Private Structure WSADATA
        Dim wVersion As Short
        Dim wHighVersion As Short
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(257), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=257)> Public szDescription() As Char
        'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
        <VBFixedString(129), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=129)> Public szSystemStatus() As Char
        Dim iMaxSockets As Short
        Dim iMaxUdpDg As Short
        Dim lpVendorInfo As Integer
    End Structure

    Private Structure hostent
        Dim h_name As Integer
        Dim h_aliases As Integer
        Dim h_addrtype As Short
        Dim h_length As Short
        Dim h_addr_list As Integer
    End Structure

    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
    'Private Declare Sub vbMemMove1 Lib "kernel32"  Alias "RtlMoveMemory"(ByRef dst As Any, ByVal src As Integer, ByVal num As Integer)
    Private Declare Sub vbMemMove1 Lib "kernel32" Alias "RtlMoveMemory" (ByRef dst As Object, ByVal src As Integer, ByVal num As Integer)
    '--修正終了　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
    Private Declare Sub vbMemMove2 Lib "kernel32" Alias "RtlMoveMemory" (ByRef dst As Integer, ByVal src As Integer, ByVal num As Integer)

    Private Declare Function gethostname Lib "wsock32.dll" (ByVal Name As String, ByVal namelen As Integer) As Integer
    Private Declare Function gethostbyname Lib "wsock32.dll" (ByVal Name As String) As Integer
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
    'Private Declare Function WSAStartup Lib "wsock32.dll" (ByVal wVersionRequested As Short, ByRef lpWSAData As Any) As Integer
    Private Declare Function WSAStartup Lib "wsock32.dll" (ByVal wVersionRequested As Short, ByRef lpWSAData As Object) As Integer
    '--修正終了　2021年05月07:MK（ツール）- VB_003 VB→VB.NET変換
    Private Declare Function WSACleanup Lib "wsock32.dll" () As Integer
    Private Declare Function WSAGetLastError Lib "wsock32.dll" () As Short

    Private Declare Function GetComputerName Lib "kernel32" Alias "GetComputerNameA" (ByVal lpBuffer As String, ByRef nSize As Integer) As Integer

    '******************************************************************************
    ' 関 数 名  : gfncGetIpAddress
    ' スコープ  : Public
    ' 処理内容  : IPアドレス取得処理
    ' 備    考  :
    ' 返 り 値  : IPアドレス
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/07/01  ＫＳＲ             新規作成
    '
    '******************************************************************************
    Public Function gfncGetIpAddress() As String

        '++修正開始　2021年09月13日:MK（手）- VB→VB.NET変換
        'Dim wsa As WSADATA
        'Dim sName As New VB6.FixedLengthString(65)
        'Dim he As hostent
        'Dim p As Integer
        'Dim b(3) As Byte


        ''UPGRADE_WARNING: Couldn't resolve default property of object wsa. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If WSAStartup(&H101, wsa) <> 0 Then Exit Function

        'If gethostname(sName.Value, 64) = 0 Then
        '    p = gethostbyname(sName.Value)
        '    If p <> 0 Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object he. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        vbMemMove1(he, p, 16)
        '        vbMemMove2(p, he.h_addr_list, 4)
        '        vbMemMove1(b(0), p, 4)
        '        gfncGetIpAddress = b(0) & "." & b(1) & "." & b(2) & "." & b(3)
        '    End If
        'End If

        'WSACleanup()

        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        gfncGetIpAddress = strIPAddress

        '--修正開始　2021年09月13日:MK（手）- VB→VB.NET変換
    End Function

    '******************************************************************************
    ' 関 数 名  : gfncGetComputerName
    ' スコープ  : Public
    ' 処理内容  : 端末名取得処理
    ' 備    考  :
    ' 返 り 値  : 端末名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/07/01  ＫＳＲ             新規作成
    '
    '******************************************************************************
    Public Function gfncGetComputerName() As String

        Dim buf As New VB6.FixedLengthString(256)
        Dim size As Integer
        Dim r As Integer

        size = 256
        r = GetComputerName(buf.Value, size)
        gfncGetComputerName = Left(buf.Value, size)

    End Function
End Module
