Option Strict Off
Option Explicit On
Module basGetFurigana
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetFurigana.bas
    ' 内    容    : 振り仮名 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gsubStartWatchInput          (入力監視開始処理)
    '                   gsubEndWatchInput            (入力監視終了処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/08/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    'Ime制御
    Private Declare Function ImmGetContext Lib "imm32.dll" (ByVal hWnd As Integer) As Integer

    Private Declare Function ImmGetCompositionString Lib "imm32.dll" Alias "ImmGetCompositionStringA" (ByVal lnghImc As Integer, ByVal dw As Integer, ByVal lpv As String, ByVal dw2 As Integer) As Integer

    Private Declare Function ImmReleaseContext Lib "imm32.dll" (ByVal hWnd As Integer, ByVal lnghImc As Integer) As Integer

    Private Const GCS_COMPREADSTR As Integer = &H1
    Private Const GCS_COMPREADATTR As Integer = &H2
    Private Const GCS_COMPREADCLAUSE As Integer = &H4
    Private Const GCS_COMPSTR As Integer = &H8
    Private Const GCS_COMPATTR As Integer = &H10
    Private Const GCS_COMPCLAUSE As Integer = &H20
    Private Const GCS_CURSORPOS As Integer = &H80
    Private Const GCS_DELTASTART As Integer = &H100
    Private Const GCS_RESULTREADSTR As Integer = &H200
    Private Const GCS_RESULTREADCLAUSE As Integer = &H400
    Private Const GCS_RESULTSTR As Integer = &H800
    Private Const GCS_RESULTCLAUSE As Integer = &H1000

    'イベント処理関連
    Private Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Integer, ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    Private Delegate Function WindowProcCallback(ByVal hWnd As IntPtr, ByVal iMsg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    Private Const GWL_WNDPROC As Short = (-4)
    Private Const WM_IME_COMPOSITION As Integer = &H10F

    '==============================================================================
    ' 変数
    '==============================================================================
    Private mstrFurigana As String
    Private mlngWindow As Integer
    Private mlnghWnd As Integer

    Public Function GetFurigana(ByVal hWnd As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

        Dim lnghImc As Integer
        Dim lngLen As Integer
        Dim strTemp As String

        'IME文字確定後で文字が入力された場合
        If (uMsg = WM_IME_COMPOSITION) And ((lParam And GCS_RESULTREADSTR) <> 0) Then

            'フリガナを取得
            'コンテキスト取得
            lnghImc = ImmGetContext(hWnd)

            'バッフア確保のため入力した文字数を取得
            lngLen = ImmGetCompositionString(lnghImc, GCS_RESULTREADSTR, vbNullChar, 0)

            '入力文字数分バッファ確保
            strTemp = Space(lngLen + 1)

            '入力文字列取得
            Call ImmGetCompositionString(lnghImc, GCS_RESULTREADSTR, strTemp, lngLen + 1)

            'コンテキスト開放
            Call ImmReleaseContext(hWnd, lnghImc)

            mstrFurigana = mstrFurigana & RTrim(strTemp)

        End If

        GetFurigana = CallWindowProc(mlngWindow, hWnd, uMsg, wParam, lParam)

    End Function

    Public Sub gsubStartWatchInput(ByRef pctlWatchTarget As System.Windows.Forms.Control)

        'フリガナ監視スタート

        'GetFuriganaイベントをバインドしてます。
        'UPGRADE_WARNING: Add a delegate for AddressOf GetFurigana Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
        'mlngWindow = SetWindowLong(pctlWatchTarget.Handle.ToInt32, GWL_WNDPROC, AddressOf GetFurigana)
        Dim wpcallback = New WindowProcCallback(AddressOf GetFurigana) 'create the new callback delegate when this form loads
        mlngWindow = SetWindowLong(pctlWatchTarget.Handle.ToInt32, GWL_WNDPROC, wpcallback)
        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

        'ハンドル保存
        mlnghWnd = pctlWatchTarget.Handle.ToInt32

        'ふりがな文字列初期化
        mstrFurigana = ""

    End Sub

    Public Sub gsubEndWatchInput(ByRef pstrFurigana As String)

        'フリガナ監視終了

        'イベントのバンドルを解除
        Call SetWindowLong(mlnghWnd, GWL_WNDPROC, mlngWindow)

        pstrFurigana = mstrFurigana

    End Sub

    Public Function gfncGetFurigana(ByRef ptxtTarget As System.Windows.Forms.TextBox) As String

        Dim lngImeContext As Integer
        Dim strBuffer As New VB6.FixedLengthString(256)
        Dim strFurigana As String
        Dim lngResult As Integer

        ' 入力コンテキストを取得
        lngImeContext = ImmGetContext(ptxtTarget.Handle.ToInt32)

        ' 変換文字列に関する情報を取得
        lngResult = ImmGetCompositionString(lngImeContext, GCS_RESULTREADSTR, strBuffer.Value, Len(strBuffer.Value))

        ' 入力コンテキストを解放
        lngResult = ImmReleaseContext(ptxtTarget.Handle.ToInt32, lngImeContext)

        ' 取得した文字列からNull文字を削除
        strFurigana = Replace(strBuffer.Value, vbNullChar, "")

        gfncGetFurigana = strFurigana

    End Function

End Module