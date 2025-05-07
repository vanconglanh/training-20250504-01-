Option Strict Off
Option Explicit On
Module basKeyEventSet
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : KeyEventSet.bas
    ' 内    容    : キーイベント セット モジュール
    ' 備    考    : ウィルスバスター2008にて, SendKeyが使用できない為, 作成
    ' 関数一覧    : <Public>
    '                   gsubKeyEventSet              (キーイベントセット処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const KEYEVENTF_KEYUP As Integer = &H2 'キーアップ
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1 'スキャンコードは拡張コード

    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    '仮想キーコード・ASCII値・スキャンコード間でコードを変換する(P1067)
    Private Declare Function MapVirtualKey Lib "user32" Alias "MapVirtualKeyA" (ByVal wCode As Integer, ByVal wMapType As Integer) As Integer

    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    'メモリブロックをコピーする(P1008)
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++修正開始　2021年04月09:OneTech（ツール）- VB_003 VB→VB.NET変換
    'Private Declare Sub CopyMemory Lib "kernel32.dll"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
    Private Declare Sub CopyMemory Lib "kernel32.dll" Alias "RtlMoveMemory" (ByRef Destination As Object, ByRef Source As String, ByVal Length As Integer)
    '--修正終了　2021年04月09:OneTech（ツール）- VB_003 VB→VB.NET変換
    '******************************************************************************
    ' 関 数 名  : gsubKeyEventSet
    ' スコープ  : Public
    ' 処理内容  : キーイベント セット 処理
    ' 備    考  :
    ' 返 り 値  : キーイベントを合成する
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintKeyCode1        String            I     キーコード１
    '   pintKeyCode2        String            I     キーコード２
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubKeyEventSet(ByVal pintKeyCode1 As Short, Optional ByVal pintKeyCode2 As Short = 0)

        ' キーを１個だけ送る場合
        If pintKeyCode2 = 0 Then

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or 0, 0)

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

            ' キーの複合操作([Alt] + [E] 等)の場合
        Else

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or 0, 0)

            Call keybd_event(CByte(pintKeyCode2), MapVirtualKey(CByte(pintKeyCode2), 0), KEYEVENTF_EXTENDEDKEY Or 0, 0)

            Call keybd_event(CByte(pintKeyCode2), MapVirtualKey(CByte(pintKeyCode2), 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

        End If

    End Sub
End Module

