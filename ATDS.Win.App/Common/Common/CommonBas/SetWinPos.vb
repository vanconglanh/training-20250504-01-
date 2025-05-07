Option Strict Off
Option Explicit On
Module basSetWinPos
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : SetWinPos.bas
    ' 内    容    : ウィンドウ表示位置 設定 モジュール
    ' 備    考    :
    ' 関数一覧    : <Private>
    '                   gfncSetWinTop                (ウィンドウ表示位置 設定)
    '               <Private>
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Public Const GC_FRONT_DISP_OFF As Short = 0
    Public Const GC_FRONT_DISP_ON As Short = 1

    Private Const HWND_TOP As Short = 0 '手前にセット
    Private Const HWND_BOTTOM As Short = 1 '後ろにセット
    Private Const HWND_TOPMOST As Short = -1 '常に手前にセット
    Private Const HWND_NOTOPMOST As Short = -2 '常に手前、解除

    Private Const SWP_SHOWWINDOW As Integer = &H40 '表示する
    Private Const SWP_NOSIZE As Integer = &H1 'サイズを設定しない
    Private Const SWP_NOMOVE As Integer = &H2 '位置を設定しない

    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    'Windowの位置やサイズ、表示を設定するAPI
    '++修正開始　2022年12月08日:MK（手）- VB→VB.NET変換
    'Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Long, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Long
    '--修正開始　2022年12月08日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年09月12日:MK（手）- VB→VB.NET変換
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As Long
    Private Declare Function GetActiveWindow Lib "user32.dll" () As Long
    '--修正開始　2021年09月12日:MK（手）- VB→VB.NET変換
    '******************************************************************************
    ' 関 数 名  : gfncSetWinTop
    ' スコープ  : Public
    ' 処理内容  : ウィンドウ表示位置 設定
    ' 備    考  :
    ' 返 り 値  : True （正常終了）
    '             False（異常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjForm            Object            I/O   表示位置設定対象フォーム
    '   pintFlg             Integer           I     表示フラグ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '++修正開始　2022年12月08日:MK（手）- VB→VB.NET変換
    'Public Function gfncSetWinTop(ByRef pobjForm As Object, ByVal pintFlg As Short) As Integer
    Public Function gfncSetWinTop(ByRef pobjForm As Object, ByVal pintFlg As Short) As Long
        '--修正開始　2022年12月08日:MK（手）- VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncSetWinTop"
        '++修正開始　2022年12月08日:MK（手）- VB→VB.NET変換
        'Dim mHwnd As Integer
        Dim mHwnd As Long
        '--修正開始　2022年12月08日:MK（手）- VB→VB.NET変換
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncSetWinTop"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            'pintFlgの値は0解除 1セット
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim mHwnd As Integer
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjForm.hwnd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年09月12日:MK（手）- VB→VB.NET変換
            'mHwnd = pobjForm.hwnd
            mHwnd = GetActiveWindow
            '--修正開始　2021年09月12日:MK（手）- VB→VB.NET変換

            If pintFlg = GC_FRONT_DISP_OFF Then

                '引数に0がセットされていた場合
                '「常に手前に表示」を解除
                '++修正開始　2022年12月11日:MK（手）- VB→VB.NET変換
                'gfncSetWinTop = SetWindowPos(mHwnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW Or SWP_NOMOVE Or SWP_NOSIZE)
                DirectCast(pobjForm, Form).TopMost = False
                '--修正開始　2022年12月11日:MK（手）- VB→VB.NET変換

            ElseIf pintFlg = GC_FRONT_DISP_ON Then

                '引数に1がセットされていた場合
                '「常に手前に表示」にセット
                '++修正開始　2022年12月11日:MK（手）- VB→VB.NET変換
                'gfncSetWinTop = SetWindowPos(mHwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW Or SWP_NOMOVE Or SWP_NOSIZE)
                DirectCast(pobjForm, Form).TopMost = True
                '--修正開始　2022年12月11日:MK（手）- VB→VB.NET変換

            Else
                ' 処理なし
            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:301486db-6c25-4cdc-a0c8-f0be1d5e02f7
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:301486db-6c25-4cdc-a0c8-f0be1d5e02f7
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b987ef-a63d-4570-a589-dc0ec39454b5
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b987ef-a63d-4570-a589-dc0ec39454b5


            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b987ef-a63d-4570-a589-dc0ec39454b5
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b987ef-a63d-4570-a589-dc0ec39454b5
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
