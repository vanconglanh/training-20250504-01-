Option Strict Off
Option Explicit On
Module basGetSHFolderPath
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetSHFolderPath.bas
    ' 内    容    : 指定フォルダパス 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetSHFolderPath            (指定フォルダパス 取得)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/10/10  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    Public Const S_OK As Integer = &H0 ' 正常終了
    Public Const S_FALSE As Integer = &H1 ' 異常終了
    Public Const E_INVALIDARG As Integer = &H80070057 ' 無効なCSIDL値を指定

    '----------------------------------
    ' CSIDL値
    '----------------------------------
    Public Const CSIDL_DESKTOP As Integer = &H0 ' デスクトップ
    Public Const CSIDL_INTERNET As Integer = &H1 ' Internet Explorer
    Public Const CSIDL_PROGRAMS As Integer = &H2 ' スタートメニュー\プログラム
    Public Const CSIDL_CONTROLS As Integer = &H3 ' コントロール パネル
    Public Const CSIDL_PRINTERS As Integer = &H4 ' プリンタ
    Public Const CSIDL_PERSONAL As Integer = &H5 ' マイドキュメント
    Public Const CSIDL_FAVORITES As Integer = &H6 ' お気に入り
    Public Const CSIDL_STARTUP As Integer = &H7 ' スタートアップ
    Public Const CSIDL_RECENT As Integer = &H8 ' 最近使ったファイル
    Public Const CSIDL_SENDTO As Integer = &H9 ' 送る
    Public Const CSIDL_BITBUCKET As Integer = &HA ' ごみ箱
    Public Const CSIDL_STARTMENU As Integer = &HB ' スタートメニュー
    Public Const CSIDL_MYMUSIC As Integer = &HD ' マイミュージック
    Public Const CSIDL_MYVIDEO As Integer = &HE ' マイビデオ
    ' デスクトップディレクトリ
    Public Const CSIDL_DESKTOPDIRECTORY As Integer = &H10 ' デスクトップディレクトリ
    Public Const CSIDL_DRIVES As Integer = &H11 ' マイ コンピュータ
    Public Const CSIDL_NETWORK As Integer = &H12 ' マイネットワーク
    Public Const CSIDL_NETHOOD As Integer = &H13 ' ネットワーク
    Public Const CSIDL_FONTS As Integer = &H14 ' フォント
    Public Const CSIDL_TEMPLATES As Integer = &H15 ' テンプレート
    Public Const CSIDL_APPDATA As Integer = &H1A ' アプリケーションデータ
    Public Const CSIDL_PRINTHOOD As Integer = &H1B ' プリンタ
    Public Const CSIDL_LOCAL_APPDATA As Integer = &H1C ' ローカルアプリケーションデータ
    Public Const CSIDL_ALTSTARTUP As Integer = &H1D ' 非ローカライズスタートアップ
    Public Const CSIDL_INTERNET_CACHE As Integer = &H20 ' インターネットキャッシュ
    Public Const CSIDL_COOKIES As Integer = &H21 ' クッキー(IE)
    Public Const CSIDL_HISTORY As Integer = &H22 ' 履歴(IE)
    Public Const CSIDL_WINDOWS As Integer = &H24 ' Windowsディレクトリ
    Public Const CSIDL_SYSTEM As Integer = &H25 ' Systemディレクトリ
    Public Const CSIDL_PROGRAM_FILES As Integer = &H26 ' C:\Program Files
    Public Const CSIDL_MYPICTURES As Integer = &H27 ' マイピクチャ
    Public Const CSIDL_PROFILE As Integer = &H28 ' プロファイル
    Public Const CSIDL_ADMINTOOLS As Integer = &H30 ' 管理ツール
    Public Const CSIDL_CONNECTIONS As Integer = &H31 ' ネットワーク接続
    Public Const CSIDL_FLAG_CREATE As Integer = &H8000

    '----------------------------------
    ' 取得フラグ
    '----------------------------------
    Private Const SHGFP_TYPE_CURRENT As Short = 0 ' 現在のフォルダ
    Private Const SHGFP_TYPE_DEFAULT As Short = 1 ' 標準のフォルダ

    Private Const MAX_PATH As Short = 260 ' パス最大長

    ' CSIDL値から, 対応するフォルダのパス名を取得
    Private Declare Function SHGetFolderPath Lib "shfolder" Alias "SHGetFolderPathA" (ByVal hwndOwner As Integer, ByVal nFolder As Integer, ByVal hToken As Integer, ByVal dwFlags As Integer, ByVal pszPath As String) As Integer
    '******************************************************************************
    ' 関 数 名  : gfncGetSHFolderPath
    ' スコープ  :
    ' 処理内容  : 指定フォルダパス 取得
    ' 備    考  :
    ' 返 り 値  : 0x00000001 (S_FALSE)
    '             0x80000008 (E_FAIL)
    '             0x80000003 (E_INVALIDARG)
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   plngCSIDL           Long              I     CSIDL値
    '   pstrPath            String            O     フォルダパス
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/10/10  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetSHFolderPath(ByVal plngCSIDL As Integer, ByRef pstrPath As String) As Integer

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetSHFolderPath"
        Dim strTemp As String
        Dim lngRet As Integer
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncGetSHFolderPath"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strTemp As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim lngRet As Integer
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            strTemp = New String(Chr(0), MAX_PATH)

            gfncGetSHFolderPath = SHGetFolderPath(0, plngCSIDL, 0, SHGFP_TYPE_CURRENT, strTemp)

            pstrPath = Left(strTemp, InStr(strTemp, vbNullChar) - 1)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1c99ecad-6205-4a4c-9dea-4f06ec6e6f33
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1c99ecad-6205-4a4c-9dea-4f06ec6e6f33
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dfd80526-b786-41b4-940b-f9dd84f3ef93
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dfd80526-b786-41b4-940b-f9dd84f3ef93

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dfd80526-b786-41b4-940b-f9dd84f3ef93
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dfd80526-b786-41b4-940b-f9dd84f3ef93
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
