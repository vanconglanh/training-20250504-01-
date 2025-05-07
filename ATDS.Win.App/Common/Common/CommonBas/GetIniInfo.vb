Option Strict Off
Option Explicit On
Imports Common
Imports Microsoft.VisualBasic.Compatibility
Imports OneTechConvertUtils
Module basGetIniInfo
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetIniInfo.bas
    ' 内    容    : ＩＮＩファイル 設定情報 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetIniInteger            (ＩＮＩ設定情報取得(数値))
    '                   gfncGetIniString             (ＩＮＩ設定情報取得(文字))
    '               <Private>
    '                   mfncGetOS                    (ＯＳ情報取得)
    '                   mfncGetPrivateProfileString  (ＩＮＩ設定情報取得(OS毎に切替))
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const VER_PLATFORM_WIN32_WINDOWS As Short = 1
    Private Const VER_PLATFORM_WIN32_NT As Short = 2

    Private Const MC_BUFF_SIZE As Integer = 255

    '==============================================================================
    ' 構造体
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
    ' ＡＰＩ関数
    '==============================================================================
    'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function GetVersionExA Lib "kernel32" (ByRef verinfo As OSVERSIONINFO) As Integer

    'UPGRADE_WARNING: Structure OSVERSIONINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
    Private Declare Function GetVersionExW Lib "kernel32" (ByRef verinfo As OSVERSIONINFO) As Integer

    ' INIファイル読込み(String型)関数
    Private Declare Function GetPrivateProfileStringA Lib "kernel32" (ByVal section As String, ByVal entry As String, ByVal def As String, ByVal buf As String, ByVal size As Integer, ByVal ininm As String) As Integer

    Private Declare Function GetPrivateProfileStringW Lib "kernel32" (ByVal section As String, ByVal entry As String, ByVal def As String, ByVal buf As String, ByVal size As Integer, ByVal ininm As String) As Integer

    ' INIファイル読込み(Integer型)関数
    Private Declare Function GetPrivateProfileInt Lib "kernel32" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
    '******************************************************************************
    ' 関 数 名  : gfncGetIniString
    ' スコープ  : Public
    ' 処理内容  : INIファイルより設定情報(文字列)取得
    ' 備    考  :
    ' 返 り 値  : 取得したデータ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrSection         String            I     セクション名
    '   pstrKey             String            I     キー名
    '   pstrFileName        String            I     INIファイル名（パス含む）
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetIniString(ByVal pstrSection As String, ByVal pstrKey As String, ByVal pstrFileName As String) As String

        Dim lngDatLng As Integer
        Dim strBuff As New VB6.FixedLengthString(MC_BUFF_SIZE)
        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
        'If mfncGetOS() = VER_PLATFORM_WIN32_NT Then

        '    lngDatLng = GetPrivateProfileStringW(pstrSection, pstrKey, "", strBuff.Value, MC_BUFF_SIZE, pstrFileName)

        'Else

        '    lngDatLng = GetPrivateProfileStringA(pstrSection, pstrKey, "", strBuff.Value, MC_BUFF_SIZE, pstrFileName)

        'End If
        lngDatLng = GetPrivateProfileStringA(pstrSection, pstrKey, "", strBuff.Value, MC_BUFF_SIZE, pstrFileName)
        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

        gfncGetIniString = Left(strBuff.Value, InStr(strBuff.Value, vbNullChar) - 1)

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetIniInteger
    ' スコープ  : Public
    ' 処理内容  : INIファイルより設定情報(数値)取得
    ' 備    考  :
    ' 返 り 値  : 取得したデータ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrSection         String            I     セクション名
    '   pstrKey             String            I     キー名
    '   pstrFileName        String            I     INIファイル名（パス含む）
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetIniInteger(ByVal pstrSection As String, ByVal pstrKey As String, ByVal pstrFileName As String) As Short

        gfncGetIniInteger = GetPrivateProfileInt(pstrSection, pstrKey, GC_CODE_ERR, pstrFileName)

    End Function
    '******************************************************************************
    ' 関 数 名  : mfncGetOS
    ' スコープ  : Private
    ' 処理内容  : OS バージョン情報を取得して、プラットフォーム情報を返す。
    ' 備    考  :
    ' 返 り 値  : OS プラットフォーム情報
    '             VER_PLATFORM_WIN32_WINDOWS = Windows 95、98
    '             VER_PLATFORM_WIN32_NT      = Windows NT
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Function mfncGetOS() As Integer

        Static osinfo As OSVERSIONINFO
        Static blnInit As Boolean

        Dim lngRcd As Integer

        '** OS バージョン情報取得
        If blnInit = False Then

            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
            '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
            'osinfo.dwOSVersionInfoSize = LenB(osinfo)
            osinfo.dwOSVersionInfoSize = Utils.LenB(osinfo)
            '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

            On Error Resume Next

            If GetVersionExA(osinfo) = False Then osinfo.dwPlatformId = VER_PLATFORM_WIN32_WINDOWS

            lngRcd = Err.Number

            On Error GoTo 0

            If lngRcd <> 0 Then
                If GetVersionExW(osinfo) = False Then osinfo.dwPlatformId = VER_PLATFORM_WIN32_WINDOWS
            End If

            blnInit = True

        End If

        '** OS プラットフォーム情報セット
        mfncGetOS = osinfo.dwPlatformId

    End Function
End Module
