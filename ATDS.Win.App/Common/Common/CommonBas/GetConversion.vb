Option Strict Off
Option Explicit On
Imports Common
Imports OneTechConvertUtils
Module basGetConversion
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetConversion.bas
    ' 内    容    : よみ仮名 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetConversion            (よみ仮名 取得 処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Const GCL_CONVERSION As Short = 1 'ソースは読み文字列
    Const GCL_REVERSECONVERSION As Short = 2 'ソースは変換結果(漢字)

    Const VER_PLATFORM_WIN32_WINDOWS As Short = 1 'OSはWin9X系
    Const VER_PLATFORM_WIN32_NT As Short = 2 'OSはWinNT系

    '==============================================================================
    ' 構造体
    '==============================================================================
    'IME 関連
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

    'OS バージョン取得
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
    ' ＡＰＩ関数
    '==============================================================================
    '入力コンテキストハンドル取得
    Private Declare Function ImmGetContext Lib "imm32" (ByVal hWnd As Integer) As Integer

    '入力コンテキストハンドル開放
    Private Declare Function ImmReleaseContext Lib "imm32" (ByVal hWnd As Integer, ByVal hIMC As Integer) As Integer

    '変換候補取得
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    'Private Declare Function ImmGetConversionList Lib "imm32" Alias "ImmGetConversionListW" (ByVal hKL As Integer, ByVal hIMC As Integer, ByRef lpSrc As Byte, ByRef lpDst As Any, ByVal dwBufLen As Integer, ByVal uFlag As Integer) As Integer
    Private Declare Function ImmGetConversionList Lib "imm32" Alias "ImmGetConversionListW" (ByVal hKL As Integer, ByVal hIMC As Integer, ByRef lpSrc As Byte, ByRef lpDst As String, ByVal dwBufLen As Integer, ByVal uFlag As Integer) As Integer
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    '入力ロケール識別子(キーボードレイアウトハンドル)取得
    Private Declare Function GetKeyboardLayout Lib "user32" (ByVal idThread As Integer) As Integer

    'Unicode文字列長取得
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年04月09:OneTech（ツール）- VB_003 VB→VB.NET変換
    'Private Declare Function lstrlen Lib "kernel32"  Alias "lstrlenW"(ByRef strString As Any) As Integer
    Private Declare Function lstrlen Lib "kernel32" Alias "lstrlenW" (ByRef strString As String) As Integer
    '--修正終了　2021年04月09:OneTech（ツール）- VB_003 VB→VB.NET変換

    'OS バージョン取得
    'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function GetVersionEx Lib "kernel32" Alias "GetVersionExA" (ByRef VersionInfo As OSVERSIONINFO) As Integer

    'メモリ移動
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年04月09:OneTech（ツール）- VB_003 VB→VB.NET変換
    'Private Declare Sub MoveMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
    Private Declare Sub MoveMemory Lib "kernel32" Alias "RtlMoveMemory" (ByRef Destination As basGetConversion.CANDIDATELIST, ByRef Source As String, ByVal Length As Integer)
    '--修正終了　2021年04月09:OneTech（ツール）- VB_003 VB→VB.NET変換
    '******************************************************************************
    ' 関 数 名  : gfncGetConversion
    ' スコープ  : Private
    ' 処理内容  : よみがな 取得
    ' 備    考  :
    ' 返 り 値  : よみがな（全角ひらがな）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrText            String            I     変換対象テキスト
    '   phWndIMEOwner       Long              I     ウィンドウハンドル
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/03/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetConversion(ByRef pstrText As String, ByRef phWndIMEOwner As Integer) As String

        Dim abytText() As Byte '前変換用
        Dim lnghIMC As Integer '入力コンテキストハンドル
        Dim lnghKL As Integer 'キーボードレイアウトハンドル
        Dim lngSize As Integer '変換後バッファサイズ
        Dim lngOffset As Integer '変換文字列候補オフセットアドレス

        Dim abytCandiateArray() As Byte '変換結果バッファ
        Dim lngRet As Integer

        'UPGRADE_WARNING: Arrays in structure typCandiateList may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim typCandiateList As CANDIDATELIST
        'UPGRADE_WARNING: Arrays in structure typOSVersion may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        Dim typOSVersion As OSVERSIONINFO

        '空文字列の場合は処理しない
        If pstrText = "" Then

            Exit Function

        End If

        'OSバージョン判別
        '++修正開始　2021年07月27日:MK（手）- VB→VB.NET変換
        'typOSVersion.dwOSVersionInfoSize = Len(typOSVersion)
        'lngRet = GetVersionEx(typOSVersion)
        '--修正開始　2021年07月27日:MK（手）- VB→VB.NET変換

        'WinNT系=>Unicodeのまま
        '++修正開始　2021年07月27日:MK（手）- VB→VB.NET変換
        'If typOSVersion.dwPlatformId = VER_PLATFORM_WIN32_NT Then

        '    'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
        '    abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(pstrText)

        '    'Null終端を付加
        '    ReDim Preserve abytText(UBound(abytText) + 2)

        '    'Win9X系=>S-JISに変換
        'Else

        '    'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
        '    'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
        '    '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
        '    'abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pstrText, vbFromUnicode))
        '    abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(Utils.StrConv(pstrText, vbFromUniCode))
        '    '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

        '    'Null終端を付加
        '    ReDim Preserve abytText(UBound(abytText) + 1)

        'End If
        abytText = System.Text.UnicodeEncoding.Unicode.GetBytes(Utils.StrConv(pstrText, vbFromUniCode))
        '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

        'Null終端を付加
        ReDim Preserve abytText(UBound(abytText) + 1)
        '--修正開始　2021年07月27日:MK（手）- VB→VB.NET変換

        'IMEの入力コンテキストとキーボードレイアウトコンテキスト取得
        lnghIMC = ImmGetContext(phWndIMEOwner)

        lnghKL = GetKeyboardLayout(0)

        '変換結果を受け取るバッファサイズを取得
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
        'lngSize = ImmGetConversionList(lnghKL, lnghIMC, abytText(0), System.DBNull.Value, 0, GCL_REVERSECONVERSION)
        lngSize = ImmGetConversionList(lnghKL, lnghIMC, abytText(0), String.Empty, 0, GCL_REVERSECONVERSION)
        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

        If lngSize > 0 Then

            'バッファサイズ分バイト配列を動的に取得
            ReDim abytCandiateArray(lngSize)

            '変換結果を取得
            lngSize = ImmGetConversionList(hKL:=lnghKL, hIMC:=lnghIMC, lpSrc:=abytText(0), lpDst:=abytCandiateArray(0), dwBufLen:=lngSize, uFlag:=GCL_REVERSECONVERSION)

            'バッファ内容を参照するため構造体にコピー
            'UPGRADE_WARNING: Couldn't resolve default property of object typCandiateList. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
            'MoveMemory(typCandiateList, abytCandiateArray(0), Len(typCandiateList))
            MoveMemory(typCandiateList, abytCandiateArray(0), Len(typCandiateList))
            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

            If typCandiateList.dwCount > 0 Then

                '先頭候補のオフセット取得
                lngOffset = typCandiateList.dwOffset(0)

                'ふりがな取得
                'UPGRADE_ISSUE: MidB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                'gfncGetConversion = MidB(abytCandiateArray, lngOffset + 1, lstrlen(abytCandiateArray(lngOffset)) * 2)
                gfncGetConversion = Utils.MidB(abytCandiateArray, lngOffset + 1, lstrlen(abytCandiateArray(lngOffset)) * 2)
                '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

            End If

        End If

        '入力コンテキストの解放
        lngRet = ImmReleaseContext(phWndIMEOwner, lnghIMC)

    End Function
End Module
