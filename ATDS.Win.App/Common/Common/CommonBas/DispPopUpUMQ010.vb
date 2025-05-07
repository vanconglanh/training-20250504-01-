Option Strict Off
Option Explicit On
Public Module basDispPopUpUMQ010
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : 会員検索 ポップアップ 表示制御モジュール
    ' ファイル名  : DispPopUpUMQ010.bas
    ' 内    容    : ＭＫシステムで使用するポップアップの表示制御
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncDispPopUpUMQ010     (会員検索       ポップアップ 表示)
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/01/15  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    ' 会員検索 ポップアップ
    '++修正開始　2021年07月11日:MK（手）- VB→VB.NET変換
    'Private Const MC_POPUP_OBJECT_UMQ010 As String = "prjUMQ010.clsUMQ010"
    Private Const MC_POPUP_OBJECT_UMQ010 As String = "UMQ010.clsUMQ010"
    '--修正開始　2021年07月11日:MK（手）- VB→VB.NET変換
    '******************************************************************************
    ' 関 数 名  : gfncDispPopUpUMQ010
    ' スコープ  : Public
    ' 処理内容  : 会員検索 ポップアップ 表示制御処理
    ' 備    考  :
    ' 返 り 値  : True （ポップアップで選択）
    '             False（ポップアップで未選択）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   --------------------+-----------------+-----+------------------------------
    '   ptxtMemberCode       TextBox           O     会員コードテキスト
    '   pobjDatabase         Object            I     ＤＢオブジェクト
    '   pintBusinessMode     Integer           I     業務モード(0:請求,1:日報入力)
    '   pintSearchMode       Integer           I     検索モード(0:通常,1:残高表示)
    '   pstrRefundFiscalYear String            I     還付処理年度
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/01/15  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncDispPopUpUMQ010(ByRef ptxtMemberCode As System.Windows.Forms.TextBox, ByVal pobjDatabase As Object, Optional ByVal pintBusinessMode As Short = GC_MODE_BUSINESS_CLAIM, Optional ByVal pintSearchMode As Short = GC_MODE_SEARCH_NORMAL, Optional ByVal pstrRefundFiscalYear As String = "") As Boolean

        '++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDispPopUpUMQ010"
        '++修正開始　2021年08月13日:MK（手）- VB→VB.NET変換
        'Dim objUMQ010 As Object
        Dim objUMQ010 As UMQ010.clsUMQ010
        '--修正開始　2021年08月13日:MK（手）- VB→VB.NET変換
        Dim lngRet As Integer
        '--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（未選択）
            gfncDispPopUpUMQ010 = False

            '++修正開始　2021年08月13日:MK（手）- VB→VB.NET変換
            'lngRet = gfncCreateObject(objUMQ010, MC_POPUP_OBJECT_UMQ010)
            '--修正開始　2021年08月13日:MK（手）- VB→VB.NET変換

            ' 正常に会員検索画面を生成できなかった場合
            If lngRet <> 0 Then

                Exit Function

            End If

            '++修正開始　2021年07月11日:MK（手）- VB→VB.NET変換
            objUMQ010 = New UMQ010.clsUMQ010
            '--修正開始　2021年07月11日:MK（手）- VB→VB.NET変換

            With objUMQ010

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.BusinessMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .BusinessMode = pintBusinessMode

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.SearchMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .SearchMode = pintSearchMode

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.RefundFiscalYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .RefundFiscalYear = pstrRefundFiscalYear

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.MemberCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtMemberCode.Text = .MemberCode

                    Call ptxtMemberCode.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    '++修正開始　2021年08月22日:MK（手）- VB→VB.NET変換
                    'Call gsubKeyEventSet(System.Windows.Forms.Keys.Tab)
                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Enter)
                    '--修正開始　2021年08月22日:MK（手）- VB→VB.NET変換

                Else

                    Call ptxtMemberCode.Focus()

                End If

                ' 戻り値を設定
                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpUMQ010 = .SelectFlg

            End With

            '++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f3af51ec-4b86-4623-8dff-1bb25ce49190
            'PROC_END:

            'Call gsubClearObject(objUMQ010)

            'Exit Function

            '++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:f3af51ec-4b86-4623-8dff-1bb25ce49190
        Catch ex As Exception
            '--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:544471f3-7073-4249-ab18-f81f2c5db9fa
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:544471f3-7073-4249-ab18-f81f2c5db9fa
            '--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:544471f3-7073-4249-ab18-f81f2c5db9fa
PROC_FINALLY_END:
        Call gsubClearObject(objUMQ010)
        Exit Function
        '--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:544471f3-7073-4249-ab18-f81f2c5db9fa
        '--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module

