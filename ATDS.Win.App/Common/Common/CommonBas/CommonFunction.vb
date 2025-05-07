Option Strict Off
Option Explicit On


Imports Common
Imports MKOra.Core
Imports Microsoft.VisualBasic.Compatibility
Imports System.Collections.Generic

Module basCommonFunction
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : CommonFunction.bas
    ' 内    容    : システム共通関数モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncCheckControlData     (コントロール チェック処理)
    '                   gfncCheckDate            (日付項目チェック)
    '                   gfncCheckMemberCode      (会員コード チェック 処理)
    '                   gfncCheckNumeric         (数値項目チェック)
    '                   gfncCheckTime            (時間項目チェック)
    '                   gfncCnvCutValue          (数値丸め変換)
    '                   gfncCnvMinutesToTime     (分から時間へ変換)
    '                   gfncCnvTimeToMinutes     (時間から分へ変換)
    '                   gfncFieldCur             (ヌル制御（数値）)
    '                   gfncFieldVal             (ヌル制御（文字列）)
    '                   gfncGetCodeToControl     (コントロールからコードを抜き出す)
    '                   gfncGetCompanyCode       (会社コンボから会社コードを抜き出す)
    '                   gfncGetRecordDate        (基準日取得)
    '                   gfncGetINCompanyCode     (コンボに表示されているデータより会社コードを取得する)
    '                   gfncGetTaxRate           (税率取得)
    '                   gfncLinkCompanyToCarKbn  (会社コンボと車輌区分コンボのリンクを行う)
    '                   gfncLinkCompanyToCarType (会社コンボと車種コードコンボのリンクを行う)
    '                   gfncLinkCompanyToEnwari  (会社コンボと遠割設定コンボのリンクを行う)
    '                   gfncLinkCompanyToPost    (会社コンボと所属コンボのリンクを行う)
    '                   gsubClearObject          (オブジェクト 開放)
    '                   gsubControlGotFocus      (コントロール 選択)
    '                   gsubDispErrMsg           (エラーメッセージ表示)
    '                   gsubGetFiscalYear        (現在日時より年度を取得)
    '                   gsubGetFiscalYearMonth   (現在日時より年月度を取得)
    '                   gsubSetComboBusho        (会社コードに対応する部署コンボリストを設定する)
    '                   gsubSetComboCarKbn       (会社コードに対応する車輌区分コンボリストを設定する)
    '                   gsubSetComboCarType      (会社コードに対応する車種コードコンボリストを設定する)
    '                   gsubSetComboEnwari       (会社コードに対応する遠割設定コンボリストを設定する)
    '                   gsubSetComboListIndex    (指定されたコードに該当するデータを表示する)
    '                   gsubSetComboNameMaster   (指定された識別の名称マスタをコンボに表示)
    '                   gsubSetFocus             (フォーカスセット)
    '                   Qt                       (フィールドにシングルクオーテーションを付加する)
    '                   gfncGetNameToControl     (コントロールから名称を抜き出す)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  廣井  芳明         新規作成
    '   02.01       2008/04/09  廣井  芳明         遠割設定コンボの表示異常に対応
    '   02.02       2008/06/21  廣井  芳明         事故コントロールマスタの会社コード付加対応
    '                                              ⇒会社毎に本人負担額が異なる為,
    '                                                管理コードを会社コードとして本人負担額を取得
    '   02.03       2009/11/11  KSR                コントロールから名称を抜き出す関数追加
    '   02.04       2010/07/21  廣井  芳明         コントロールロック状態設定処理を追加
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Public Const GC_CHECK_NUMERIC As Short = 0 ' 数値チェック
    Public Const GC_CHECK_NUMERIC_LEN As Short = 1 ' 数値&桁チェック
    Public Const GC_CHECK_LEN As Short = 2 ' 桁数チェック
    Public Const GC_CHECK_YMD As Short = 3 ' 日付(年月日)チェック
    Public Const GC_CHECK_YM As Short = 4 ' 日付(年月)チェック
    Public Const GC_CHECK_MD As Short = 5 ' 日付(月日)チェック
    Public Const GC_CHECK_TIME As Short = 6 ' 時刻チェック
    Public Const GC_CHECK_COMBO As Short = 7 ' コンボチェック

    Public Const GC_CNV_MODE_TRUNC As Short = 0 ' 切り捨て
    Public Const GC_CNV_MODE_CEILING As Short = 1 ' 切り上げ
    Public Const GC_CNV_MODE_ROUND As Short = 2 ' 四捨五入

    '==============================================================================
    '変数
    '==============================================================================
    Public gstrDate As String ' 日付編集前(入力値)
    Public gstrEditDate As String ' 日付編集後の値(yyyy(年号)mm/dd)
    Public gstrTime As String ' 時刻編集前(入力値)
    Public gstrEditTime As String ' 時刻編集後の値(h:mm)
    Public gstrSpcFrst() As String ' 特別ファースト
    Public gstrSpcFrstNm() As String ' 特別ファースト名

    '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
    Public gctlActiveControl As Control
    '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

    Public Structure TAG_Zeiritu ' 税率
        Dim mTstr税率コード As String
        Dim mTstr税率 As String
    End Structure

    '******************************************************************************
    ' 関 数 名  : gfncCheckControlData
    ' スコープ  : Public
    ' 処理内容  : コントロール チェック処理
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintChktype         Integer           I     チェックタイプ
    '   pintLength          Integer           I     項目長
    '   pintDecimal         Integer           I     少数桁
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCheckControlData(ByVal pintChktype As Short, Optional ByVal pintLength As Short = 0, Optional ByVal pintDecimal As Short = 0) As Object

        Dim lngIdx As Short
        Dim intErrFlg As Short

        ' 戻り値を初期化（異常終了）
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gfncCheckControlData = True

        '++修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
        'If not set value of active control, this function will return nothing
        'please set value for ActiveControl before use this function
        If gctlActiveControl Is Nothing Then
            Return Nothing
        End If
        '--修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
        Select Case pintChktype
            '--------------------------------------------------------------------------
            '数値ﾁｪｯｸ①
            '--------------------------------------------------------------------------
            Case GC_CHECK_NUMERIC

                '数値のﾁｪｯｸを行います。
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If IsNumeric(VB6.GetActiveControl()) = False Then
                If IsNumeric(gctlActiveControl.Text) = False Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    ' エラーメッセージを表示
                    Call MsgBox(GC_ERR_MSG_9003, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                'ﾌｫｰﾏｯﾄしてｺﾝﾄﾛｰﾙにｾｯﾄする
                'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'VB6.GetActiveControl = Right(CStr(CDbl("0000000000") + CDbl(VB6.GetActiveControl())), pintLength)
                Utils.SetValueControl(gctlActiveControl, Right(Utils.getValueControl(gctlActiveControl), pintLength).PadLeft(pintLength, "0"))
                '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                '--------------------------------------------------------------------------
                '数値ﾁｪｯｸ②
                '--------------------------------------------------------------------------
            Case GC_CHECK_NUMERIC_LEN

                '数値のﾁｪｯｸを行います。
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If IsNumeric(VB6.GetActiveControl()) = False Then
                If IsNumeric(gctlActiveControl.Text) = False Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    ' エラーメッセージを表示
                    Call MsgBox(GC_ERR_MSG_9003, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)


                    Exit Function

                    'gfncCheckNumeric関数(数値項目のﾁｪｯｸ)
                    'ﾕｰｻﾞｰ関数 引数1(ｺﾝﾄﾛｰﾙの値),引数2(ﾏｲﾅｽでもOK･･･True) ,引数3(最大桁数) ,引数4(小数点桁数)
                    '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    'ElseIf gfncCheckNumeric(CStr(VB6.GetActiveControl()), True, pintLength, pintDecimal) = True Then
                ElseIf gfncCheckNumeric(Utils.getValueControl(gctlActiveControl), True, pintLength, pintDecimal) = True Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    '小数点桁数により出力するﾒｯｾｰｼﾞを判断する。
                    If pintDecimal = 0 Then

                        ' エラーメッセージを表示
                        Call MsgBox("整数" & pintLength & "桁以内で入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Else

                        ' エラーメッセージを表示
                        Call MsgBox("整数" & pintLength & "桁以内, 小数点以下" & pintDecimal & "桁以内で入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)
                    End If

                    Exit Function

                End If

                '小数点桁数毎にﾌｫｰﾏｯﾄしてｺﾝﾄﾛｰﾙにｾｯﾄする
                Select Case pintDecimal
                    Case 0
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0"))
                        '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    Case 1
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.0")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.0"))
                        '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    Case 2
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.00")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.00"))
                       '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    Case 3
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.000")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.000"))
                       '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    Case 4
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.0000")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.0000"))
                       '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    Case 5
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.00000")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.00000"))
                        '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                End Select

                '--------------------------------------------------------------------------
                '桁数ﾁｪｯｸ
                '--------------------------------------------------------------------------
            Case GC_CHECK_LEN

                'UnicodeをAsciicodeに変換してﾊﾞｲﾄ数を求め, 所定文字のﾊﾞｲﾄ数と比較
                'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                'If LenB(StrConv(VB6.GetActiveControl().ToString(), vbFromUnicode)) > pintLength Then
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If Utils.LenB(Utils.StrConv(VB6.GetActiveControl().ToString(), vbFromUniCode)) > pintLength Then
                If Utils.LenB(Utils.StrConv(Utils.getValueControl(gctlActiveControl), vbFromUniCode)) > pintLength Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

                    ' エラーメッセージを表示
                    Call MsgBox("半角" & pintLength & "桁, 全角" & pintLength / 2 & "桁以内で文字を入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '--------------------------------------------------------------------------
                '日付ﾁｪｯｸ
                '--------------------------------------------------------------------------
            Case GC_CHECK_YMD

                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If gfncCheckDate(activeControl, GC_CHECK_YMD) = True Then
                If gfncCheckDate(gctlActiveControl, GC_CHECK_YMD) = True Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    Call MsgBox("日付(年月日)を入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'VB6.GetActiveControl = VB6.Format(VB6.Format(gstrDate, "0000/00/00"), "yyyy(gggee)/mm/dd")
                Utils.SetValueControl(gctlActiveControl, VB6.Format(VB6.Format(gstrDate, "0000/00/00"), "yyyy(gggee)/mm/dd"))
                '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                '--------------------------------------------------------------------------
                '年月ﾁｪｯｸ
                '--------------------------------------------------------------------------
            Case GC_CHECK_YM

                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If gfncCheckDate(activeControl, GC_CHECK_YM) = True Then
                If gfncCheckDate(gctlActiveControl, GC_CHECK_YM) = True Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    ' エラーメッセージを表示
                    Call MsgBox("日付(年月)を入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                'ﾌｫｰﾏｯﾄしてｺﾝﾄﾛｰﾙにｾｯﾄする
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'VB6.GetActiveControl = VB6.Format(VB6.Format(gstrDate, "0000/00"), "yyyy(gggee)/mm")
                Utils.SetValueControl(gctlActiveControl, VB6.Format(VB6.Format(gstrDate, "0000/00"), "yyyy(gggee)/mm"))
'--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                '--------------------------------------------------------------------------
                '月日ﾁｪｯｸ
                '--------------------------------------------------------------------------
            Case GC_CHECK_MD

                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If gfncCheckDate(VB6.GetActiveControl(), GC_CHECK_MD) = True Then
                If gfncCheckDate(gctlActiveControl, GC_CHECK_MD) = True Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    ' エラーメッセージを表示
                    Call MsgBox("日付(月日)を入力して下さい。", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                'ﾌｫｰﾏｯﾄしてｺﾝﾄﾛｰﾙにｾｯﾄする
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'VB6.GetActiveControl = VB6.Format(VB6.Format(gstrDate, "00/00"), "mm/dd")
                Utils.SetValueControl(gctlActiveControl, VB6.Format(VB6.Format(gstrDate, "00/00"), "mm/dd"))
'--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                '--------------------------------------------------------------------------
                '時刻ﾁｪｯｸ
                '--------------------------------------------------------------------------
            Case GC_CHECK_TIME

                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'If gfncCheckTime(VB6.GetActiveControl()) = True Then
                If gfncCheckTime(gctlActiveControl) = True Then
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    ' エラーメッセージを表示
                    Call MsgBox(GC_ERR_MSG_9029, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '--------------------------------------------------------------------------
                'ｺﾝﾎﾞﾁｪｯｸ
                '--------------------------------------------------------------------------
            Case GC_CHECK_COMBO

                ' フラグをOFFに設定
                intErrFlg = GC_FLG_OFF

                'UPGRADE_ISSUE: Control ListCount could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                'For lngIdx = 0 To VB6.GetActiveControl().ListCount - 1
                For lngIdx = 0 To CType(gctlActiveControl, ComboBox).Items.Count - 1
                    '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                    'ｺﾝﾎﾞﾎﾞｯｸｽの内容と入力した1桁目をﾁｪｯｸする
                    'UPGRADE_ISSUE: Control List could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                    '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                    'If RTrim(Mid(VB6.GetActiveControl() & Space(pintLength), 1, pintLength)) = RTrim(Mid(VB6.GetActiveControl().List(lngIdx), 1, pintLength)) Then
                    If RTrim(Mid(Utils.getValueControl(gctlActiveControl) & Space(pintLength), 1, pintLength)) = RTrim(Mid(CType(gctlActiveControl, ComboBox).Items(lngIdx), 1, pintLength)) Then
                        '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                        'ｺﾝﾎﾞﾎﾞｯｸｽの内容を表示する
                        'UPGRADE_ISSUE: Control ListIndex could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
                        'VB6.GetActiveControl().ListIndex = lngIdx
                        CType(gctlActiveControl, ComboBox).SelectedIndex = lngIdx
                        '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換

                        ' フラグをONに設定
                        intErrFlg = GC_FLG_ON

                        Exit For

                    End If

                Next lngIdx

                ' 一致する内容がコンボボックスになかった場合
                If intErrFlg = GC_FLG_OFF Then

                    ' エラーメッセージを表示
                    Call MsgBox(GC_ERR_MSG_9002, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

        End Select

        ' 戻り値を設定（正常終了）
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gfncCheckControlData = False

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCheckDate
    ' スコープ  : Public
    ' 処理内容  : 日付項目チェック
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlFiled           String            O     チェック対象
    '   pintMode            Integer           I     チェックモード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCheckDate(ByRef pctlFiled As System.Windows.Forms.Control, ByVal pintMode As Short) As Boolean

        gfncCheckDate = False
        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
        'gstrEditDate = pctlFiled.ToString()
        gstrEditDate = pctlFiled.Text
        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換

        '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
        'If IsNumeric(pctlFiled) Then
        If IsNumeric(pctlFiled.Text) Then
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換

            Select Case pintMode
                '----------------------------------------------------------------------
                ' 年月日
                '----------------------------------------------------------------------
                Case GC_CHECK_YMD

                    '入力桁数により日付型に変換する
                    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                    'Select Case Len(pctlFiled)
                    Select Case Len(Utils.getValueControl(pctlFiled))
                    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case 1 To 2
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                            'gstrEditDate = VB6.Format(Now, "yyyy/mm") & "/" & VB6.Format(pctlFiled, "00")
                            gstrEditDate = VB6.Format(Now, "yyyy/mm") & "/" & VB6.Format(Utils.getValueControl(pctlFiled), "00")
                            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case 3 To 4
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                            'gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(pctlFiled, "00/00")
                            gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(Utils.getValueControl(pctlFiled), "00/00")
                            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case 5 To 6
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                            'gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(pctlFiled, "00/00/00")
                            gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(Utils.getValueControl(pctlFiled), "00/00/00")
                            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case Else
                            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                            '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                            'If LenB(StrConv(pctlFiled.ToString(), vbFromUnicode)) > 8 Then
                            If Utils.LenB(Utils.StrConv(Utils.getValueControl(pctlFiled), vbFromUniCode)) > 8 Then
                                '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                                gfncCheckDate = True
                                Exit Function
                            Else
                                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                                'gstrEditDate = VB6.Format(pctlFiled, "0000/00/00")
                                gstrEditDate = VB6.Format(Utils.getValueControl(pctlFiled), "0000/00/00")
                                '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                            End If
                    End Select
                    '----------------------------------------------------------------------
                    ' 年月
                    '----------------------------------------------------------------------
                Case GC_CHECK_YM

                    '入力桁数により日付型に変換する
                    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                    'Select Case Len(pctlFiled)
                    Select Case Len(Utils.getValueControl(pctlFiled))
                    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case 1 To 2
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                            'gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(pctlFiled, "00")
                            gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(Utils.getValueControl(pctlFiled), "00")
                            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case 3 To 4
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                            'gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(pctlFiled, "00/00")
                            gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(Utils.getValueControl(pctlFiled), "00/00")
                            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                        Case Else
                            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                            '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                            'If LenB(StrConv(pctlFiled.ToString(), vbFromUnicode)) > 6 Then
                            If Utils.LenB(Utils.StrConv(Utils.getValueControl(pctlFiled), vbFromUniCode)) > 6 Then
                                '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                                gfncCheckDate = True
                                Exit Function
                            Else
                                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'gstrEditDate = VB6.Format(pctlFiled, "0000/00")
                                gstrEditDate = VB6.Format(Utils.getValueControl(pctlFiled), "0000/00")
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                    End Select
            End Select

        Else

            Select Case pintMode
                '----------------------------------------------------------------------
                ' 年月日
                '----------------------------------------------------------------------
                Case GC_CHECK_YMD

                    '日付の妥当性ﾁｪｯｸ
                    If Not IsDate(gstrEditDate) Then
                        'yyyy(和暦)/mm/ddの時, 再分解する。
                        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                        'gstrEditDate = CStr(Mid(pctlFiled.ToString(), 1, 4) & "/" & Mid(Right(pctlFiled.ToString(), 5), 1, 3) & Right(pctlFiled.ToString(), 2))
                        gstrEditDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & "/" & Mid(Right(Utils.getValueControl(pctlFiled), 5), 1, 2) & "/" & Right(Utils.getValueControl(pctlFiled), 2))
                        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                    End If

                    '----------------------------------------------------------------------
                    ' 年月
                    '----------------------------------------------------------------------
                Case GC_CHECK_YM
                    '日付の妥当性ﾁｪｯｸ
                    If Not IsDate(gstrEditDate) Then
                        'yyyy(和暦)/mm/ddの時, 再分解する。
                        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                        'gstrEditDate = CStr(Mid(pctlFiled.ToString(), 1, 4) & "/" & Right(pctlFiled.ToString(), 2))
                        gstrEditDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & "/" & Right(Utils.getValueControl(pctlFiled), 2))
                        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                    End If

            End Select

        End If

        '--------------------------------------------------------------------------
        ' 日付の妥当性ﾁｪｯｸ
        '--------------------------------------------------------------------------
        If Not IsDate(gstrEditDate) Then
            gfncCheckDate = True
            Exit Function
        End If

        Select Case pintMode
            '--------------------------------------------------------------------------
            ' 年月日
            '--------------------------------------------------------------------------
            Case GC_CHECK_YMD

                If Len(gstrEditDate) = Len("yyyy/mm/dd") Then

                    If gstrEditDate > "2087/12/31" Then

                        gstrEditDate = "2087/12/31"

                    End If

                    If gstrEditDate < "1868/10/23" Then

                        gstrEditDate = "1868/10/23"

                    End If

                End If

                '編集後再表示
                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                'pctlFiled = VB6.Format(gstrEditDate, "yyyy(gggee)/mm/dd")
                Utils.SetValueControl(pctlFiled, VB6.Format(gstrEditDate, "yyyy(gggee)/mm/dd"))
                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                '日付の入力値を待避(yyyymmdd)
                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                gstrDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & Mid(Right(Utils.getValueControl(pctlFiled), 5), 1, 2) & Right(Utils.getValueControl(pctlFiled), 2))
                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

                '--------------------------------------------------------------------------
                ' 年月
                '--------------------------------------------------------------------------
            Case GC_CHECK_YM

                If Len(gstrEditDate) = Len("yyyy/mm") Then

                    If gstrEditDate > "2087/12" Then

                        gstrEditDate = "2087/12"

                    End If

                    If gstrEditDate < "1868/11" Then

                        gstrEditDate = "1868/11"

                    End If

                End If

                '編集後再表示
                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                'pctlFiled = VB6.Format(gstrEditDate, "yyyy(gggee)/mm")
                Utils.SetValueControl(pctlFiled, VB6.Format(gstrEditDate, "yyyy(gggee)/mm"))
                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

                '日付の入力値を待避(yyyymm)
                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                'gstrDate = CStr(Mid(pctlFiled.ToString(), 1, 4) & Right(pctlFiled.ToString(), 2))
                gstrDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & Right(Utils.getValueControl(pctlFiled), 2))
                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
        End Select

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCheckMemberCode
    ' スコープ  : Public
    ' 処理内容  : 会員コード チェック 処理
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   --------------------+-----------------+-----+------------------------------
    '   pstrTarget           String            I     チェック対象
    '   pstrMemberParentCode String            I/O   会員コード
    '   pstrMemberBranchCode String            I/O   会員枝コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncCheckMemberCode(ByVal pstrTarget As String, ByRef pstrMemberParentCode As String, ByRef pstrMemberBranchCode As String) As Boolean

        Dim intIdx As Short

        gfncCheckMemberCode = False

        pstrMemberParentCode = Trim(pstrTarget)

        '--------------------------------------------------------------------------
        ' コード入力形式チェック
        '--------------------------------------------------------------------------
        If IsNumeric(pstrMemberParentCode) Then

            gfncCheckMemberCode = True

            '----------------------------------------------------------------------
            ' 会員コードのみの入力（枝コードは'0000'に設定）
            '----------------------------------------------------------------------
            If Len(pstrMemberParentCode) = 7 Then

                pstrMemberBranchCode = "0000"
                gfncCheckMemberCode = False

            End If

            ' 会員コード＋枝コードの入力

            If Len(pstrMemberParentCode) = 11 Then

                pstrMemberBranchCode = Right(pstrMemberParentCode, GC_LEN_MEMBER_CODE_BRANCH)

                pstrMemberParentCode = Left(pstrMemberParentCode, GC_LEN_MEMBER_CODE_PARENT)

                gfncCheckMemberCode = False

            End If

            ' 会員コード・枝コードの区切りがあるとき
        Else

            For intIdx = 1 To Len(pstrMemberParentCode)

                If Not IsNumeric(Mid(pstrMemberParentCode, intIdx, 1)) Then

                    pstrMemberBranchCode = Right(pstrMemberParentCode, Len(pstrMemberParentCode) - intIdx)

                    pstrMemberParentCode = Left(pstrMemberParentCode, intIdx - 1)

                    Exit For

                End If

            Next

            ' 会員コード桁エラー
            If intIdx = 0 Or intIdx > 8 Then

                gfncCheckMemberCode = True

            Else

                If IsNumeric(pstrMemberParentCode) And IsNumeric(pstrMemberBranchCode) Then

                    pstrMemberParentCode = VB6.Format(Val(pstrMemberParentCode), New String("0", GC_LEN_MEMBER_CODE_PARENT))

                    pstrMemberBranchCode = VB6.Format(Val(pstrMemberBranchCode), New String("0", GC_LEN_MEMBER_CODE_BRANCH))

                Else

                    gfncCheckMemberCode = True

                End If

            End If

        End If

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCheckNumeric
    ' スコープ  : Public
    ' 処理内容  : 数値項目チェック
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrNum             String            I     チェック対象
    '   pblnMinus           Boolean           I     数値の範囲にマイナスあり(-1)
    '   pintMaxFigure       Integer           I     最大桁数
    '   pintDecimalNum      Integer           I     小数点桁数
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCheckNumeric(ByVal pstrNum As String, ByVal pblnMinus As Boolean, ByVal pintMaxFigure As Short, ByVal pintDecimalNum As Short) As Boolean

        gfncCheckNumeric = False

        '***********************
        ' 項目が範囲内にあるかﾁｪｯｸ
        '***********************
        '項目の値の制限事項が正,0,負のとき
        If pblnMinus Then

            'ﾏｲﾅｽがOKでも項目入力可能数が1の場合はｴﾗｰとする。
            If pintMaxFigure - 1 = 0 Then

                'ｴﾗｰを表示します
                Call MsgBox("1桁の項目に負を入力できません。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, GC_ERR_TITLE)

                Exit Function

            End If

            '項目の範囲ﾁｪｯｸ
            If CDec(pstrNum) <= CDec("-1" & New String("0", pintMaxFigure)) Or CDec(pstrNum) >= CDec("1" & New String("0", pintMaxFigure)) Then

                gfncCheckNumeric = True

                Exit Function

            End If

            ' 項目の値の制限事項が正のとき
        Else

            If CDec(pstrNum) < 0 Or CDec(pstrNum) >= CDec("1" & New String("0", pintMaxFigure)) Then

                gfncCheckNumeric = True

                Exit Function

            End If

        End If

        '***********************
        '項目の小数点ﾁｪｯｸ
        '***********************
        '小数点の右からの位置と小数点桁数を比較
        If InStr(pstrNum, ".") = 0 Then

        Else

            If Len(pstrNum) - InStr(pstrNum, ".") > pintDecimalNum Then

                gfncCheckNumeric = True

                Exit Function

            End If

        End If

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCheckTime
    ' スコープ  : Public
    ' 処理内容  : 時間項目チェック
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlFiled           String            O     チェック対象
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCheckTime(ByRef pctlField As System.Windows.Forms.Control) As Boolean

        Dim intDecimal As Short

        gfncCheckTime = False
        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
        'gstrEditTime = pctlField.ToString()
        gstrEditTime = pctlField.Text
        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換

        '":" を "." に変換
        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
        intDecimal = InStr(pctlField.Text, ":")
        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
        If intDecimal <> 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object pctlField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
            'pctlField = Left(gstrEditTime, intDecimal - 1) & "." & Mid(gstrEditTime, intDecimal + 1)
            Utils.SetValueControl(pctlField, Left(gstrEditTime, intDecimal - 1) & "." & Mid(gstrEditTime, intDecimal + 1))
            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

        End If

        '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
        'If IsNumeric(pctlField) Then
        If IsNumeric(pctlField.Text) Then
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            '"." の位置を検索
            '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
            'intDecimal = InStr(pctlField.ToString(), ".")
            intDecimal = InStr(pctlField.Text, ".")
            '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換

            If intDecimal <> 0 Then
                '桁数のﾁｪｯｸ (時間) & （分）
                'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                'If LenB(StrConv(Left(pctlField.ToString(), intDecimal - 1), vbFromUnicode)) > 2 Or LenB(StrConv(Mid(pctlField.ToString(), intDecimal + 1), vbFromUnicode)) > 2 Then
                If Utils.LenB(Utils.StrConv(Left(pctlField.Text, intDecimal - 1), vbFromUniCode)) > 2 Or Utils.LenB(Utils.StrConv(Mid(pctlField.Text, intDecimal + 1), vbFromUniCode)) > 2 Then
                    '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                    gfncCheckTime = True
                    Exit Function
                End If
            Else
                'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                'If LenB(StrConv(pctlField.ToString(), vbFromUnicode)) > 2 Then
                If Utils.LenB(Utils.StrConv(pctlField.Text, vbFromUniCode)) > 2 Then
                    '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                    gfncCheckTime = True
                    Exit Function
                End If
            End If

            '入力桁数により時間形式に変換する
            Select Case intDecimal
                Case 0
                    'UPGRADE_WARNING: Couldn't resolve default property of object pctlField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年06月24日:MK（手）- VB→VB.NET変換
                    'gstrEditTime = VB6.Format(pctlField, "00") & ":" & "00"
                    gstrEditTime = VB6.Format(pctlField.Text, "00") & ":" & "00"
                    '--修正開始　2021年06月24日:MK（手）- VB→VB.NET変換
                Case 1
                    '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    'gstrEditTime = "00" & ":" & VB6.Format(Mid(pctlField.ToString(), 2), "00")
                    gstrEditTime = "00" & ":" & VB6.Format(Mid(pctlField.Text, 2), "00")
                    '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                Case 2
                    '"h." の入力形式のとき後ろに"00" をつける。
                    '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    'If Mid(pctlField.ToString(), 3) <> "" Then
                    If Mid(pctlField.Text, 3) <> "" Then
                        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 1), "00") & ":" & VB6.Format(Mid(pctlField.ToString(), 3), "00")
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 1), "00") & ":" & VB6.Format(Mid(pctlField.Text, 3), "00")
                        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    Else
                        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 1), "00") & ":" & "00"
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 1), "00") & ":" & "00"
                        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    End If
                Case 3
                    '"hh." の入力形式のとき後ろに"00" をつける。
                    '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    'If Mid(pctlField.ToString(), 4) <> "" Then
                    If Mid(pctlField.Text, 4) <> "" Then
                        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 2), "00") & ":" & VB6.Format(Mid(pctlField.ToString(), 4), "00")
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 2), "00") & ":" & VB6.Format(Mid(pctlField.Text, 4), "00")
                        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    Else
                        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 2), "00") & ":" & "00"
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 2), "00") & ":" & "00"
                        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    End If
                Case Else
                    gfncCheckTime = True
                    Exit Function
            End Select
        Else
            gfncCheckTime = True
            Exit Function
        End If

        '時刻のﾁｪｯｸ
        '++修正開始　2021年06月24日:MK（手）- VB→VB.NET変換
        'If CShort(Left(gstrEditTime, 2)) > 99 Then
        If CShort(Left(gstrEditTime, 2)) > 24 Then
            '--修正開始　2021年06月24日:MK（手）- VB→VB.NET変換
            gfncCheckTime = True
            Exit Function
        End If

        If CShort(Right(gstrEditTime, 2)) > 59 Then
            gfncCheckTime = True
            Exit Function
        End If

        '編集後再表示
        'UPGRADE_WARNING: Couldn't resolve default property of object pctlField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
        'pctlField = VB6.Format(gstrEditTime, "hh:mm")
        Utils.SetValueControl(pctlField, VB6.Format(gstrEditTime, "hh:mm"))
        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換


        '時刻の入力値を待避(hhmm)
        gstrTime = Left(gstrEditTime, 2) & Right(gstrEditTime, 2)

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCnvCutValue
    ' スコープ  : Public
    ' 処理内容  : 数値丸め変換
    ' 備    考  :
    ' 返 り 値  : 丸めた値
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcurValue           Currency          I     変換対象
    '   pintPosi            Integer           I     小数点を基準とした丸める桁
    '   pintMode            Integer           I     0(切り捨て),1(切り上げ),2(四捨五入)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/24  廣井  芳明         新規作成
    '   01.01       2007/05/31  廣井  芳明         負の値での丸めに対応
    '
    '******************************************************************************
    Public Function gfncCnvCutValue(ByVal pcurValue As Decimal, ByVal pintPosi As Short, ByVal pintMode As Short) As Decimal

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncCnvCutValue"
        Dim lngWork As Integer
        Dim curWork As Decimal
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            lngWork = 10 ^ System.Math.Abs(pintPosi)

            ' 0未満
            If pcurValue < 0 Then

                ' 正の値に変換し，ワークにセット
                curWork = pcurValue * -1

            Else

                ' ワークにセット
                curWork = pcurValue

            End If

            If pintPosi < 0 Then


                Select Case pintMode
                    Case GC_CNV_MODE_TRUNC ' 切り捨て

                        curWork = CDec(Fix(curWork * lngWork) / lngWork)

                    Case GC_CNV_MODE_CEILING ' 切り上げ

                        curWork = CDec(Fix(curWork * lngWork + 0.9) / lngWork)

                    Case GC_CNV_MODE_ROUND ' 四捨五入

                        curWork = CDec(Fix(curWork * lngWork + 0.5) / lngWork)

                End Select

            Else

                Select Case pintMode
                    Case GC_CNV_MODE_TRUNC ' 切り捨て

                        curWork = CDec(Fix(curWork / lngWork) * lngWork)

                    Case GC_CNV_MODE_CEILING ' 切り上げ

                        curWork = CDec(Fix(curWork / lngWork + 0.9) * lngWork)

                    Case GC_CNV_MODE_ROUND ' 四捨五入

                        curWork = CDec(Fix(curWork / lngWork + 0.5) * lngWork)

                End Select

            End If

            ' 0未満
            If pcurValue < 0 Then

                ' 負の値に変換し，戻り値にセット
                gfncCnvCutValue = curWork * -1

            Else

                gfncCnvCutValue = curWork

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4de04ae0-a789-48d6-93b2-8a3983a6722b
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:4de04ae0-a789-48d6-93b2-8a3983a6722b
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCnvMinutesToTime
    ' スコープ  : Public
    ' 処理内容  : 分から時間へ変換
    ' 備    考  :
    ' 返 り 値  : 分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pdblTime            Double            I     60進時間
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncCnvMinutesToTime(ByVal plngMinutes As Integer, Optional ByVal pstrFormat As String = "00", Optional ByVal pstrSplit As String = ":") As String

        gfncCnvMinutesToTime = ""

        If plngMinutes <> 0 Then

            gfncCnvMinutesToTime = VB6.Format(plngMinutes \ 60, pstrFormat) & pstrSplit & VB6.Format(plngMinutes Mod 60, "00")

        End If

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCnvTimeToMinutes
    ' スコープ  : Public
    ' 処理内容  : 時間から分へ変換
    ' 備    考  :
    ' 返 り 値  : 分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pdblTime            Double            I     60進時間
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncCnvTimeToMinutes(ByVal pdblTime As Double) As Integer

        gfncCnvTimeToMinutes = ((pdblTime - Fix(pdblTime)) * 100) + Fix(pdblTime) * 60

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncFieldCur
    ' スコープ  : Public
    ' 処理内容  : ヌル制御（数値）
    ' 備    考  :
    ' 返 り 値  : 変換数値
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pvntFieldVal        Variant           I     制御対象データ
    '   pcurRep             Currency          I     NULLの場合の置換数値
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncFieldCur(ByVal pvntFieldVal As Object, Optional ByVal pcurRep As Object = 0) As Decimal

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
        'If DBUtils.IsDBNull(pvntFieldVal) OrElse Len(pvntFieldVal) = 0 Then
        If pvntFieldVal Is Nothing OrElse "null".Equals(pvntFieldVal) OrElse
            pvntFieldVal.GetType().Name <> "OracleString" AndAlso TypeOf pvntFieldVal IsNot Common.MKTextBox AndAlso
           (DBUtils.IsDBNull(pvntFieldVal) OrElse String.IsNullOrEmpty(pvntFieldVal) OrElse Len(pvntFieldVal) = 0) Then
            '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object pcurRep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gfncFieldCur = pcurRep

        Else
            '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
            Dim strValue As String = ""
            If pvntFieldVal.GetType().Name = "OracleString" Then
                If pvntFieldVal.IsNull Then
                    strValue = ""
                Else
                    strValue = pvntFieldVal.Value
                End If
            ElseIf TypeOf pvntFieldVal Is Common.MKTextBox Then
                strValue = DirectCast(pvntFieldVal, Common.MKTextBox).Text
                '++修正開始　2021年10月11日:MK（手）- VB→VB.NET変換
                If String.IsNullOrEmpty(strValue) Or Len(strValue) = 0 Then
                    gfncFieldCur = pcurRep
                    Exit Function
                End If
                '--修正開始　2021年10月11日:MK（手）- VB→VB.NET変換
            Else
                strValue = pvntFieldVal
            End If
            '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換\

            '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
            'If IsNumeric(pvntFieldVal) Then
            If IsNumeric(strValue) AndAlso strValue <> "NaN" Then
                '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換

                'UPGRADE_WARNING: Couldn't resolve default property of object pvntFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
                'gfncFieldCur = CDec(pvntFieldVal)
                gfncFieldCur = CDec(strValue)
                '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換

            Else

                Call MsgBox("数字項目に数字以外の値が入っています。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, GC_ERR_TITLE)

            End If

        End If

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncFieldVal
    ' スコープ  : Public
    ' 処理内容  : ヌル制御（文字列）
    ' 備    考  :
    ' 返 り 値  : 変換文字列
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pvntFieldVal        Variant           I     制御対象データ
    '   pvntRep             Variant           I     NULLの場合の置換文字
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncFieldVal(ByVal pvntFieldVal As Object, Optional ByVal pvntRep As Object = "") As Object

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
        'If DBUtils.IsDBNull(pvntFieldVal) = True Then
        If pvntFieldVal Is Nothing OrElse "null".Equals(pvntFieldVal) OrElse
           pvntFieldVal.GetType().Name <> "OracleString" AndAlso TypeOf pvntFieldVal IsNot Common.MKTextBox AndAlso
           pvntFieldVal.GetType().Name <> "TextBox" AndAlso
           (DBUtils.IsDBNull(pvntFieldVal) OrElse String.IsNullOrEmpty(pvntFieldVal) OrElse Len(pvntFieldVal) = 0) Then
            '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object pvntRep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gfncFieldVal = pvntRep

        Else

            'UPGRADE_WARNING: Couldn't resolve default property of object pvntFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
            'gfncFieldVal = CStr(pvntFieldVal)
            If pvntFieldVal.GetType().Name = "OracleString" Then
                If pvntFieldVal.IsNull Then
                    gfncFieldVal = ""
                Else
                    gfncFieldVal = pvntFieldVal.Value
                End If
            ElseIf TypeOf pvntFieldVal Is Common.MKTextBox Then
                gfncFieldVal = DirectCast(pvntFieldVal, Common.MKTextBox).Text
            ElseIf pvntFieldVal.GetType().Name = "TextBox" Then
                gfncFieldVal = pvntFieldVal.Text
            Else
                gfncFieldVal = CStr(pvntFieldVal)
            End If
            '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換

        End If

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetCodeToControl
    ' スコープ  : Public
    ' 処理内容  : コントロールからコードを抜き出す
    ' 備    考  :
    ' 返 り 値  : コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrControlText     String            I     コントロールのテキスト
    '   pintCodeLen         Integer           I     コード長
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/09/27  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetCodeToControl(ByVal pstrControlText As String, ByVal pintCodeLen As Short) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetCodeToControl"
        Dim strCode As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            strCode = Trim(Mid(pstrControlText & Space(pintCodeLen), 1, pintCodeLen))

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
            'PROC_END:

            'gfncGetCodeToControl = strCode

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21ecaecb-0197-401b-a498-210389b830f9
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21ecaecb-0197-401b-a498-210389b830f9

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21ecaecb-0197-401b-a498-210389b830f9
PROC_FINALLY_END:
        gfncGetCodeToControl = strCode
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21ecaecb-0197-401b-a498-210389b830f9
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetMstCompanyCode
    ' スコープ  : Public
    ' 処理内容  : 所属コードより会社コードを取得
    ' 備    考  : 東京エムケイにて, 会社コード付加対応を行うまでの暫定関数
    ' 返 り 値  : 会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrPostCode        String            I     所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/07/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetMstCompanyCode(ByVal pstrPostCode As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetMstCompanyCode"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strRet As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            strRet = ""

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT  "
            strSQL = strSQL & Chr(10) & "    会社コード "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    部署マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    所属コード = '" & pstrPostCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strRet = .Fields("会社コード").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21ecaecb-0197-401b-a498-210389b830f9
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'gfncGetMstCompanyCode = strRet

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21ecaecb-0197-401b-a498-210389b830f9
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:70b58a47-73b1-4e12-ae68-c166a10eb24c

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        gfncGetMstCompanyCode = strRet
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    'Nakai 2007.04.25 会社コード付加対応 INSERT START:会社コンボと部署コンボの連携処理追加
    '******************************************************************************
    ' 関 数 名  : gfncGetCompanyCode
    ' スコープ  : Public
    ' 処理内容  : 会社コンボから会社コードを抜き出す
    ' 備    考  : gfncGetCompanyCodeは使用禁止！！gfncGetCodeToControlを使用
    ' 返 り 値  : 会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCodeData        String            I     会社コンボテキスト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/25  Nakai              新規作成
    '
    '******************************************************************************
    Public Function gfncGetCompanyCode(ByVal pstrCodeData As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetCompanyCode"
        Dim strCode As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            strCode = RTrim(Mid(pstrCodeData, 1, GC_LEN_COMPANY_CODE))

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
            'PROC_END:

            'gfncGetCompanyCode = strCode

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:223a03ef-190b-452c-a69f-2bb5527b96f3
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:223a03ef-190b-452c-a69f-2bb5527b96f3

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:223a03ef-190b-452c-a69f-2bb5527b96f3
PROC_FINALLY_END:
        gfncGetCompanyCode = strCode
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:223a03ef-190b-452c-a69f-2bb5527b96f3
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetRecordDate
    ' スコープ  : Public
    ' 処理内容  : 基準日取得
    ' 備    考  :
    ' 返 り 値  : 基準日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pstrPostCode        String            I     所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/09/20  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetRecordDate(ByVal pstrCompanyCode As String, ByVal pstrPostCode As String) As Short

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetRecordDate"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            gfncGetRecordDate = CShort(GC_DEF_基準日)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NVL(基準日,'" & GC_DEF_基準日 & "') AS 基準日 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    コントロールマスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    所属コード = '" & pstrPostCode & "' "
            strSQL = strSQL & Chr(10) & "AND 会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND 種別       = 'M' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    gfncGetRecordDate = .Fields("基準日").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:223a03ef-190b-452c-a69f-2bb5527b96f3
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:223a03ef-190b-452c-a69f-2bb5527b96f3
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetINCompanyCode
    ' スコープ  : Public
    ' 処理内容  : コンボに表示されているデータより会社コードを取得する
    ' 備    考  : '0'または'8'の会社コードを返す場合は'0,8'と返す
    ' 返 り 値  : 会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCodeData        String            I/O   コンボ表示文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/06/25  Nakai              新規作成
    '
    '******************************************************************************
    Public Function gfncGetINCompanyCode(ByVal pstrCodeData As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetINCompanyCode"
        Dim strCode As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            strCode = RTrim(Mid(pstrCodeData, 1, GC_LEN_COMPANY_CODE))

            If strCode = GC_COMPANY_CODE_KYOTO Or strCode = GC_COMPANY_CODE_TRACEN Then

                strCode = GC_COMPANY_CODE_KYOTO & "','" & GC_COMPANY_CODE_TRACEN

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
            'PROC_END:

            'gfncGetINCompanyCode = strCode

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:68526fbe-5b21-498d-a7c8-f35455348cc8
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:68526fbe-5b21-498d-a7c8-f35455348cc8

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:68526fbe-5b21-498d-a7c8-f35455348cc8
PROC_FINALLY_END:
        gfncGetINCompanyCode = strCode
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:68526fbe-5b21-498d-a7c8-f35455348cc8
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetStringByteLen
    ' スコープ  : Public
    ' 処理内容  : 文字列のバイト長を取得
    ' 備    考  :
    ' 返 り 値  : バイト長
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     取得対象文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/25  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetStringByteLen(ByVal pstrTarget As String) As Integer

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetTaxRate"
        Dim abytTemp() As Byte
        Dim lngRet As Integer
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            lngRet = GC_CODE_ERR

            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
            '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
            'abytTemp = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pstrTarget, vbFromUnicode))
            abytTemp = System.Text.UTF8Encoding.UTF8.GetBytes(Utils.StrConv(pstrTarget, vbFromUniCode))
            '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

            ' ０オリジンの為, ＋１
            lngRet = UBound(abytTemp) + 1

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:68526fbe-5b21-498d-a7c8-f35455348cc8
            'PROC_END:

            'On Error Resume Next

            'Erase abytTemp

            'gfncGetStringByteLen = lngRet

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:68526fbe-5b21-498d-a7c8-f35455348cc8
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:87bc0f42-ba15-485b-a87a-00c0174bcd15

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
PROC_FINALLY_END:
        '        On Error Resume Next
        Try
            Erase abytTemp
        Catch ex1 As Exception
        End Try
        Try
            gfncGetStringByteLen = lngRet
        Catch ex1 As Exception
        End Try
        Try
            Exit Function
        Catch ex1 As Exception
        End Try
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetTaxRate
    ' スコープ  : Public
    ' 処理内容  : 税率取得
    ' 備    考  :
    ' 返 り 値  : 税率
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I/O   営業日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/23  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetTaxRate(ByVal pstrDate As String) As Double

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetTaxRate"
        Dim dblRet As Double
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            dblRet = 0.05

            ' SQL文 作成
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    税率     "
            strSQL = strSQL & Chr(10) & "   ,前税率   "
            strSQL = strSQL & Chr(10) & "   ,適用日付 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    税率マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    税率コード = '01' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在しない場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then

                    ' 処理なし

                    ' 該当するデータが存在する場合
                Else

                    ' 適用日付で計算に使用する税率を判定
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If pstrDate >= VB6.Format(gfncFieldVal(.Fields("適用日付").Value), "00000000") Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        dblRet = gfncFieldCur(.Fields("税率").Value)

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        dblRet = gfncFieldCur(.Fields("前税率").Value)

                    End If

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
            'PROC_END:

            'gfncGetTaxRate = dblRet

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
PROC_FINALLY_END:
        gfncGetTaxRate = dblRet
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncLinkCompanyToCarKbn
    ' スコープ  : Public
    ' 処理内容  : 会社コンボと車輌区分コンボのリンクを行う。
    ' 備    考  :
    ' 返 り 値  : True （正常終了）
    '             False（異常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   会社コンボ
    '   pcboCarKbn          ComboBox          I/O   車輌区分コンボ
    '   pblnCancel          Boolean           O     キャンセルフラグ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '   pintDefSet          Integer           I     デフォルトのListIndex
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/07/22  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToCarKbn(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToCarKbn"
        Dim blnRet As Boolean
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            blnRet = False

            pblnCancel = False

            Call pcboCarKbn.Items.Clear()

            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else

                    '------------------
                    '   車輌区分をセット
                    '------------------
                    Call gsubSetComboCarKbn(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboCarKbn, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboCarKbn.Items.Count > 0 Then

                pcboCarKbn.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToCarKbn = blnRet

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d1143865-38b8-4a1b-befe-18397c33652d
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d1143865-38b8-4a1b-befe-18397c33652d

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d1143865-38b8-4a1b-befe-18397c33652d
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d1143865-38b8-4a1b-befe-18397c33652d
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncLinkCompanyToCarType
    ' スコープ  : Public
    ' 処理内容  : 会社コンボおよび車輌区分コンボと車種コードコンボのリンクを行う。
    ' 備    考  :
    ' 返 り 値  : True （正常終了）
    '             False（異常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pcboCarKbn          ComboBox          I/O   車輌区分コンボ
    '   pcboCarType         ComboBox          I/O   車種コンボ
    '   pblnCancel          Boolean           O     キャンセルフラグ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '   pintDefSet          Integer           I     デフォルトのListIndex
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/01/22  廣井  芳明         新規作成
    '   01.01       2008/07/21  廣井  芳明         車輌区分の各項目を車種マスタに移行
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToCarType(ByRef pstrCompanyCode As String, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, ByRef pcboCarType As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToCarType"
        Dim blnRet As Boolean
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncLinkCompanyToCarType"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim blnRet As Boolean
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            blnRet = False

            pblnCancel = False

            Call pcboCarType.Items.Clear()
            '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
            pcboCarType.Text = String.Empty
            '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
            If Len(pcboCarKbn.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_CAR_KBN). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_CAR_KBN) = True Then

                    pblnCancel = True

                Else
                    '------------------
                    '   車種コードをセット
                    '------------------
                    Call gsubSetComboCarType(pstrCompanyCode, gfncGetCodeToControl(pcboCarKbn.Text, GC_LEN_CAR_KBN), pcboCarType, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboCarType.Items.Count > 0 Then

                pcboCarType.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToCarType = blnRet

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d1143865-38b8-4a1b-befe-18397c33652d
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d1143865-38b8-4a1b-befe-18397c33652d
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:652cae6e-e1cc-4434-9604-b198e87bd806
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:652cae6e-e1cc-4434-9604-b198e87bd806

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:652cae6e-e1cc-4434-9604-b198e87bd806
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:652cae6e-e1cc-4434-9604-b198e87bd806
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncLinkCompanyToEnwari
    ' スコープ  : Public
    ' 処理内容  : 会社コンボと遠割設定コンボのリンクを行う。
    ' 備    考  :
    ' 返 り 値  : True （正常終了）
    '             False（異常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   会社コンボ
    '   pcboEnwari          ComboBox          I/O   遠割設定コンボ
    '   pblnCancel          Boolean           O     キャンセルフラグ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '   pintDefSet          Integer           I     デフォルトのListIndex
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/09  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToEnwari(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboEnwari As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToEnwari"
        Dim blnRet As Boolean
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            blnRet = False

            pblnCancel = False

            Call pcboEnwari.Items.Clear()
            '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
            pcboEnwari.Text = String.Empty
            '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else
                    '------------------
                    '   遠割設定をセット
                    '------------------
                    Call gsubSetComboEnwari(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboEnwari, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboEnwari.Items.Count > 0 Then

                pcboEnwari.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToEnwari = blnRet

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:652cae6e-e1cc-4434-9604-b198e87bd806
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:652cae6e-e1cc-4434-9604-b198e87bd806
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e5400792-7d53-4ce1-9534-77936defaa58
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e5400792-7d53-4ce1-9534-77936defaa58

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e5400792-7d53-4ce1-9534-77936defaa58
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e5400792-7d53-4ce1-9534-77936defaa58
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncLinkCompanyToPost
    ' スコープ  : Public
    ' 処理内容  : 会社コンボと所属コンボのリンクを行う。
    ' 備    考  :
    ' 返 り 値  : True （正常終了）
    '             False（異常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   会社コンボ
    '   pcboPost            ComboBox          I/O   所属コンボ
    '   pblnCancel          Boolean           O     キャンセルフラグ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '   pintDefSet          Integer           I     デフォルトのListIndex
    '   pblnFlgEigyoKbn     Boolean           I     営業区分判定フラグ(False:判定なし)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/25  Nakai              新規作成
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToPost(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboPost As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0, Optional ByVal pblnFlgEigyoKbn As Boolean = False) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToPost"
        Dim blnRet As Boolean
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            pblnCancel = False

            blnRet = False

            Call pcboPost.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboPost.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換

            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else

                    '------------------
                    '   部署をセット
                    '------------------
                    Call gsubSetComboBusho(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboPost, pstrAllSelect, pblnFlgEigyoKbn)

                    blnRet = True

                End If

            End If

            If pcboPost.Items.Count > 0 Then

                pcboPost.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToPost = blnRet

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e5400792-7d53-4ce1-9534-77936defaa58
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e5400792-7d53-4ce1-9534-77936defaa58
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:19639e96-bc4b-46d3-be79-41e5fe05b33b

            'Resume

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gsubClearObject
    ' スコープ  : Public
    ' 処理内容  : オブジェクト開放
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTar             Object            O     対象オブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubClearObject(ByRef pobjTarget As Object)

        On Error Resume Next

        If pobjTarget Is Nothing = False Then

            'UPGRADE_NOTE: Object pobjTarget may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            pobjTarget = Nothing

        End If

    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubControlGotFocus
    ' スコープ  : Public
    ' 処理内容  : コントロール 選択
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlTar             Control           O     処理対象コントロール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubControlGotFocus(ByRef pctlTar As System.Windows.Forms.Control)
        System.Windows.Forms.Application.DoEvents()

        'UPGRADE_WARNING: Couldn't resolve default property of object pctlTar.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++修正開始　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
        'pctlTar.SelStart = 0
        Utils.setSelectStartControl(pctlTar, 0)
        '--修正終了　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
        'UPGRADE_WARNING: Couldn't resolve default property of object pctlTar.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++修正開始　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
        'pctlTar.SelLength = Len(pctlTar.Text)
        Utils.setSelectLengthControl(pctlTar, Len(pctlTar.Text))
        '--修正終了　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換

    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubDispErrMsg
    ' スコープ  : Public
    ' 処理内容  : エラーメッセージ表示
    ' 備    考  : 新規の機能での使用禁止！！
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrErrDescription  String            I     エラー内容
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubDispErrMsg(ByVal pstrErrDescription As String)

        'MsgBox関数の引数、内容を変数化
        Dim strMsg As String
        Dim intStyle As Short
        Dim strTitle As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo gsubDispErrMsg_Err
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            ' OLEのｴﾗｰ内容かどうか判定
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErrText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.LastServerErr <> 0 And gobjOraDatabase.LastServerErrText <> "" Then

                'OLEのﾒｯｾｰｼﾞ内容取得
                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErrText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strMsg = gobjOraDatabase.LastServerErrText

                'OLEのｴﾗｰ内容のｸﾘｱ
                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErrReset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gobjOraDatabase.LastServerErrReset()

                ' VBのｴﾗｰ
            Else

                'ﾒｯｾｰｼﾞ内容取得
                strMsg = pstrErrDescription

            End If

            ' MsgBox用の引数を定義します
            'ﾎﾞﾀﾝの種類、個数、ｱｲｺﾝのｽﾀｲﾙなどを表す値の合計値を取得
            intStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical

            'ﾀｲﾄﾙﾊﾞｰに表示する名前を取得
            strTitle = GC_ERR_TITLE

            ' ｴﾗｰﾒｯｾｰｼﾞを表示します。
            Call MsgBox(strMsg, MsgBoxStyle.Critical, strTitle)


            '++修正開始　2021年05月28:MK（手）- VB_522 VB→VB.NET変換
            'gsubDispErrMsg_Exit:

            '        Exit Sub
            '++修正開始　2021年05月28:MK（手）- VB_523 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'gsubDispErrMsg_Err:
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            'ﾒｯｾｰｼﾞ内容取得
            strMsg = "ﾓｼﾞｭｰﾙ名･･･共通ﾓｼﾞｭｰﾙ" & Chr(13) & Chr(10) & "ｴﾗｰ発生場所･･･gsubDispErrMsg" & Chr(13) & Chr(10) & "でｴﾗｰが発生しました。"

            'ﾎﾞﾀﾝの種類、個数、ｱｲｺﾝのｽﾀｲﾙなどを表す値の合計値を取得
            intStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton1

            'ﾀｲﾄﾙﾊﾞｰに表示する名前を取得
            strTitle = "異常終了"

            Call MsgBox(strMsg, MsgBoxStyle.Critical, strTitle)

            'Resume gsubDispErrMsg_Exit

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年05月28:MK（手）- VB_522 VB→VB.NET変換
gsubDispErrMsg_Exit:

        Exit Sub
        '++修正開始　2021年05月28:MK（手）- VB_523 VB→VB.NET変換

        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubGetFiscalYear
    ' スコープ  : Public
    ' 処理内容  : 現在日時より年度を取得
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   ptxtFiscalYear      TextBox           O     年度テキスト
    '   pstrFiscalYear      String            O     年度ワーク
    '   pstrPostCode        String            I     所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubGetFiscalYear(ByRef ptxtFiscalYear As System.Windows.Forms.TextBox, ByRef pstrFiscalYear As String, ByVal pstrPostCode As String)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubGetFiscalYear"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strBeginPeriod As String
        Dim strFiscalYear As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            '期首月日の初期値
            strBeginPeriod = "03" & GC_DEF_基準日

            '部署マスタの基準日を入力
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NVL(期首月日,'" & strBeginPeriod & "') 年度開始月日 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    コントロールマスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    所属コード = '" & pstrPostCode & "' "
            strSQL = strSQL & Chr(10) & "AND 種別       = 'M' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strBeginPeriod = .Fields("年度開始月日").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            strFiscalYear = VB6.Format(Now, "yyyy")

            '今日の月日が期首月日より小さいとき－１年
            If VB6.Format(Now, "mmdd") < strBeginPeriod Then
                strFiscalYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(Now, "yyyy/mm/dd"))), "yyyy")
            End If

            '年度編集
            pstrFiscalYear = strFiscalYear
            ptxtFiscalYear.Text = VB6.Format(strFiscalYear & "/01/01", "yyyy(ggge)")

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:15bbeb02-76e1-44af-aab8-b8815a762fac
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:15bbeb02-76e1-44af-aab8-b8815a762fac

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:15bbeb02-76e1-44af-aab8-b8815a762fac
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:15bbeb02-76e1-44af-aab8-b8815a762fac
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubGetFiscalYearMonth
    ' スコープ  : Public
    ' 処理内容  : 現在日時より年月度を取得
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   ptxtYearMonth       TextBox           O     年月度テキスト
    '   pstrYearMonth       String            O     年月度ワーク
    '   pstrCompanyCode     String            I     会社コード
    '   pstrPostCode        String            I     所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '   02.00       2007/05/08  Nakai              会社コード付加対応
    '
    '******************************************************************************
    '++修正開始　2021年07月23日:MK（手）- VB→VB.NET変換
    'Public Sub gsubGetFiscalYearMonth(ByRef ptxtYearMonth As System.Windows.Forms.TextBox, ByRef pstrYearMonth As String, ByVal pstrCompanyCode As String, ByVal pstrPostCode As String)
    Public Sub gsubGetFiscalYearMonth(ByRef ptxtYearMonth As System.Windows.Forms.Control, ByRef pstrYearMonth As String, ByVal pstrCompanyCode As String, ByVal pstrPostCode As String)
        '--修正開始　2021年07月23日:MK（手）- VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubGetFiscalYearMonth"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim int基準日 As Short
        Dim str年月 As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            '基準日の初期値
            int基準日 = CShort(GC_DEF_基準日)

            '部署マスタの基準日を入力
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NVL(基準日,'" & GC_DEF_基準日 & "') AS 基準日 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    コントロールマスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    所属コード = '" & pstrPostCode & "' "
            strSQL = strSQL & Chr(10) & "AND 会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND 種別       = 'M' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    int基準日 = .Fields("基準日").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '今日の年月を採用
            str年月 = VB6.Format(Now, "yyyy/mm")

            '今日の日が基準日以上のとき＋１ヶ月
            If CDbl(VB6.Format(Now, "d")) >= int基準日 Then

                str年月 = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(VB6.Format(Now, "yyyy/mm/dd"))), "yyyy/mm")

            End If

            '年月編集
            pstrYearMonth = VB6.Format(str年月, "yyyymm")

            '++修正開始　2021年07月23日:MK（手）- VB→VB.NET変換
            'ptxtYearMonth.Text = VB6.Format(str年月, "yyyy(ggge)/mm")
            If TypeOf ptxtYearMonth Is TextBox OrElse TypeOf ptxtYearMonth Is MKTextBox Then
                ptxtYearMonth.Text = VB6.Format(str年月, "yyyy(ggge)/mm")
            ElseIf TypeOf ptxtYearMonth Is ComboBox Then
                ptxtYearMonth.Text = VB6.Format(str年月, "yyyy(ggge)/mm")
            End If
            '--修正開始　2021年07月23日:MK（手）- VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:15bbeb02-76e1-44af-aab8-b8815a762fac
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:15bbeb02-76e1-44af-aab8-b8815a762fac
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3c589bd8-4147-4957-a8f2-5142fb135db0
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3c589bd8-4147-4957-a8f2-5142fb135db0

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3c589bd8-4147-4957-a8f2-5142fb135db0
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3c589bd8-4147-4957-a8f2-5142fb135db0
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboBusho
    ' スコープ  : Public
    ' 処理内容  : 会社コードに対応する部署コンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pcboPost            ComboBox          I/O   所属コンボ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '   pblnFlgEigyoKbn     Boolean           I     営業区分判定フラグ(False:判定なし)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/25  Nakai              新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboBusho(ByVal pstrCompanyCode As String, ByRef pcboPost As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "", Optional ByVal pblnFlgEigyoKbn As Boolean = False)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboBusho"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call pcboPost.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            'pcboPost.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換

            If Len(pstrAllSelect) > 0 Then
                pcboPost.Items.Add(pstrAllSelect)
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT  "
            strSQL = strSQL & Chr(10) & "    所属コード "
            strSQL = strSQL & Chr(10) & "   ,部署名     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    部署マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "

            If pblnFlgEigyoKbn <> False And pstrCompanyCode <> "78" Then
                'If pblnFlgEigyoKbn <> False Then

                strSQL = strSQL & Chr(10) & "AND 営業区分 = '1' "

            End If

            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    所属コード "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboPost.Items.Add(CStr(Mid(.Fields("所属コード").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("部署名").Value))
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3c589bd8-4147-4957-a8f2-5142fb135db0
            'PROC_END:

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysTemp = Nothing

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3c589bd8-4147-4957-a8f2-5142fb135db0
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:da63b1f5-7629-4a14-a6b6-b590ab271e34

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
PROC_FINALLY_END:
        objDysTemp = Nothing
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboCarKbn
    ' スコープ  : Public
    ' 処理内容  : 会社コードに対応する車輌区分コンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pcboCarKbn          ComboBox          I/O   車輌区分コンボ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/07/22  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboCarKbn(ByVal pstrCompanyCode As String, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboCarKbn"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            Call pcboCarKbn.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboCarKbn.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換

            If Len(pstrAllSelect) > 0 Then

                pcboCarKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    車輌区分   "
            strSQL = strSQL & Chr(10) & "   ,車輌区分名 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    車輌区分マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    車輌区分 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboCarKbn.Items.Add(CStr(Mid(.Fields("車輌区分").Value & Space(GC_LEN_CAR_KBN), 1, GC_LEN_CAR_KBN) & GC_COMBO_SPLIT & .Fields("車輌区分名").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8ecd4e68-9120-4001-8195-284a7031c196
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8ecd4e68-9120-4001-8195-284a7031c196

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8ecd4e68-9120-4001-8195-284a7031c196
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8ecd4e68-9120-4001-8195-284a7031c196
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboCarType
    ' スコープ  : Public
    ' 処理内容  : 会社コードに対応する車種コードコンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pstrCarKbn          String            I     車輌区分
    '   pcboCarType         ComboBox          I/O   車種コードコンボ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/01/22  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboCarType(ByVal pstrCompanyCode As String, ByVal pstrCarKbn As String, ByRef pcboCarType As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboCarType"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            Call pcboCarType.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboCarType.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            If Len(pstrAllSelect) > 0 Then

                pcboCarType.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    車種コード "
            strSQL = strSQL & Chr(10) & "   ,車種名     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    車種マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND 車輌区分   = '" & pstrCarKbn & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    車種コード "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboCarType.Items.Add(CStr(Mid(.Fields("車種コード").Value & Space(GC_LEN_CAR_TYPE_CODE), 1, GC_LEN_CAR_TYPE_CODE) & GC_COMBO_SPLIT & .Fields("車種名").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8ecd4e68-9120-4001-8195-284a7031c196
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8ecd4e68-9120-4001-8195-284a7031c196
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:269abf87-0a0a-491e-8989-d2831e84a85a
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:269abf87-0a0a-491e-8989-d2831e84a85a

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:269abf87-0a0a-491e-8989-d2831e84a85a
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:269abf87-0a0a-491e-8989-d2831e84a85a
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboShift
    ' スコープ  : Public
    ' 処理内容  : 会社・所属コードに対応するシフト区分コンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboShiftKbn        ComboBox          I/O   シフト区分コンボ
    '   pstrCompanyCode     String            I     会社コード
    '   pstrPostCode        String            I     所属コード
    '   pstrWorkKbn         String            I     勤務区分
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/06/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboShift(ByRef pcboShiftKbn As System.Windows.Forms.ComboBox, ByVal pstrCompanyCode As String, ByVal pstrPostCode As String, Optional ByVal pstrWorkKbn As String = "", Optional ByVal pstrAllSelect As String = "")

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboShift"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            Call pcboShiftKbn.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboShiftKbn.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            If Len(pstrAllSelect) > 0 Then

                Call pcboShiftKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    シフト区分 "
            strSQL = strSQL & Chr(10) & "   ,シフト名   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    シフトマスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND 所属コード = '" & pstrPostCode & "' "

            If pstrWorkKbn <> "" Then

                strSQL = strSQL & Chr(10) & "AND 勤務開始時間 IS NOT NULL "
                strSQL = strSQL & Chr(10) & "AND 勤務終了時間 IS NOT NULL "
                strSQL = strSQL & Chr(10) & "AND 勤務区分   = '" & pstrWorkKbn & "' "

            End If

            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    シフト区分 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboShiftKbn.Items.Add(CStr(Mid(.Fields("シフト区分").Value & Space(GC_LEN_SHIFT_KBN), 1, GC_LEN_SHIFT_KBN) & GC_COMBO_SPLIT & .Fields("シフト名").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:269abf87-0a0a-491e-8989-d2831e84a85a
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:269abf87-0a0a-491e-8989-d2831e84a85a
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:fec82163-9143-4416-9d54-5476872f36df
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:fec82163-9143-4416-9d54-5476872f36df

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:fec82163-9143-4416-9d54-5476872f36df
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:fec82163-9143-4416-9d54-5476872f36df
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboEnwari
    ' スコープ  : Public
    ' 処理内容  : 会社コードに対応する遠割設定コンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pcboEnwari          ComboBox          I/O   遠割設定コンボ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/09  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboEnwari(ByVal pstrCompanyCode As String, ByRef pcboEnwari As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboEnwari"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            Call pcboEnwari.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboEnwari.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            If Len(pstrAllSelect) > 0 Then
                pcboEnwari.Items.Add(pstrAllSelect)
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    遠割設定コード "
            strSQL = strSQL & Chr(10) & "   ,遠割設定名称   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    遠割設定マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    遠割設定コード "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboEnwari.Items.Add(CStr(Mid(.Fields("遠割設定コード").Value & Space(1), 1, 1) & GC_COMBO_SPLIT & .Fields("遠割設定名称").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:fec82163-9143-4416-9d54-5476872f36df
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:fec82163-9143-4416-9d54-5476872f36df
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c295e374-42f5-47ed-b1ab-83b09394d17b
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c295e374-42f5-47ed-b1ab-83b09394d17b

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c295e374-42f5-47ed-b1ab-83b09394d17b
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c295e374-42f5-47ed-b1ab-83b09394d17b
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboListIndex
    ' スコープ  : Public
    ' 処理内容  : 指定されたコードに該当するデータを表示する。
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   --------------------+-----------------+-----+------------------------------
    '   pctlCombo            ComboBox          I/O   処理対象
    '   pstrCode             String            I     指定コード
    '   plngLength           Long              I     指定コード長
    '   pblnFlgJudgAuthority Integer           I     権限判定フラグ(True:判定あり)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubSetComboListIndex(ByRef pctlCombo As System.Windows.Forms.ComboBox,
                                     ByVal pstrCode As String, ByVal plngLength As Integer,
                                     Optional ByVal pblnFlgJudgAuthority As Boolean = False,
                                     Optional ByVal pblnConvert As Boolean = False,
                                     Optional ByVal pstrObjectCode As String = GC_COMPANY_CODE_TRACEN,
                                     Optional ByVal pstrConvertCode As String = GC_COMPANY_CODE_KYOTO)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboListIndex"
        Dim intIdx As Short
        Dim strCode As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            '会社コードが'8'の場合'0'に変換
            If pblnConvert = True Then
                strCode = IIf(pstrCode = pstrObjectCode, pstrConvertCode, pstrCode)
            Else
                strCode = pstrCode
            End If

            '++修正開始　2021年11月28日:MK（手）- VB→VB.NET変換
            'can not set code to Text -> deleted
            '20211231: Fixbug in skype -> cannot clear data when code blank
            If strCode = "" Then
                pctlCombo.Text = strCode
            End If
            '--修正開始　2021年11月28日:MK（手）- VB→VB.NET変換

            For intIdx = 0 To (pctlCombo.Items.Count - 1)

                If RTrim(Mid(VB6.GetItemString(pctlCombo, intIdx), 1, plngLength)) = strCode Then

                    '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
                    'pctlCombo.SelectedIndex = intIdx
                    pctlCombo.Text = VB6.GetItemString(pctlCombo, intIdx)
                    '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換

                    ' ログイン情報の権限判定フラグがTrue（判定あり）の場合
                    If pblnFlgJudgAuthority = True Then

                        ' システム権限が０（権限なし）の場合
                        If gclsLoginInfo.SystemAuthority = 0 Then

                            ' ランクがＥランクの場合
                            If gclsLoginInfo.Rank = "E" Then

                                ' コントロールを使用不可
                                pctlCombo.Enabled = False

                            End If

                        End If

                    End If

                    Exit For

                End If

            Next intIdx

            '++修正開始　2021年12月18日:MK（手）- VB→VB.NET変換
            If (strCode IsNot Nothing) Then
                If pctlCombo.Text.Contains(strCode) = False Then
                    pctlCombo.Text = strCode
                End If
            End If
            '--修正開始　2021年12月18日:MK（手）- VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c295e374-42f5-47ed-b1ab-83b09394d17b
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c295e374-42f5-47ed-b1ab-83b09394d17b
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetComboNameMaster
    ' スコープ  : Public
    ' 処理内容  : 指定された識別の名称マスタをコンボに表示
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlCombo           ComboBox          I/O   処理対象
    '   pstrIdentification  String            I     識別
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubSetComboNameMaster(ByRef pctlCombo As System.Windows.Forms.ComboBox, ByVal pstrIdentification As String, ByVal plngLength As Integer, Optional ByVal pstrOrder As String = "TO_NUMBER(コード)")

        Dim strSQL As String
        '++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
        'Dim objDysTemp As Object
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換

        Call pctlCombo.Items.Clear()
        '++修正開始　2021年06月06日:MK（手）- VB→VB.NET変換
        pctlCombo.Text = String.Empty
        '--修正開始　2021年06月06日:MK（手）- VB→VB.NET変換

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    コード   "
        strSQL = strSQL & Chr(10) & "   ,名称漢字 "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    名称マスタ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    識別 = '" & pstrIdentification & "' "
        strSQL = strSQL & Chr(10) & "ORDER BY "
        strSQL = strSQL & Chr(10) & "    " & pstrOrder & " "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        With objDysTemp

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Do Until .EOF = True

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pctlCombo.Items.Add(CStr(Mid(.Fields("コード").Value & Space(plngLength), 1, plngLength) & GC_COMBO_SPLIT & .Fields("名称漢字").Value))

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .MoveNext()

            Loop

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .Close()

        End With

        Call gsubClearObject(objDysTemp)

    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetFocus
    ' スコープ  : Public
    ' 処理内容  : フォーカスセット
    ' 備    考  : EnableがFalseの場合にフォーカスセットしてもエラーが発生しない
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTar             Object            O     対象オブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubSetFocus(ByRef pobjTar As Object)

        On Error Resume Next

        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTar.SetFocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++修正開始　2021年07月10日:MK（手）- VB→VB.NET変換
        'Call pobjTar.SetFocus()
        Call pobjTar.Focus()
        '--修正開始　2021年07月10日:MK（手）- VB→VB.NET変換

        Call Err.Clear()

    End Sub
    '******************************************************************************
    ' 関 数 名  : gsubSetFormPosition
    ' スコープ  : Public
    ' 処理内容  : 画面の表示位置を設定
    ' 備    考  :
    ' 返 り 値  : シングルクォーテーション付加文字列
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pfrmTarget          Form              I     設定対象
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/29  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetFormPosition(ByRef pfrmTarget As Object, Optional ByVal plngHeight As Integer = 0, Optional ByVal plngWidth As Integer = 0)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncCheckDisplaySize"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            ' 現在使用中の端末の画面サイズが, システムの基本画面サイズを超える場合
            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
            'If VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / VB6.TwipsPerPixelX > GC_DEF_DISPLY_WIDTH And VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / VB6.TwipsPerPixelY > GC_DEF_DISPLY_HEIGHT Then
            If VB6.PixelsToTwipsX(Utils.GetScreenWidth()) / VB6.TwipsPerPixelX > GC_DEF_DISPLY_WIDTH And VB6.PixelsToTwipsY(Utils.GetScreenHeight()) / VB6.TwipsPerPixelY > GC_DEF_DISPLY_HEIGHT Then
                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換
                'pfrmTarget.Top = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ 2) - (pfrmTarget.Height \ 2)
                pfrmTarget.Top = (Utils.GetScreenHeight() \ 2) - (pfrmTarget.Height \ 2)
                '--修正終了　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換
                'pfrmTarget.Left = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ 2) - (pfrmTarget.Width \ 2)
                pfrmTarget.Left = (Utils.GetScreenWidth() \ 2) - (pfrmTarget.Width \ 2)
                '--修正終了　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換

                ' 現在使用中の端末の画面サイズが, システムの基本画面サイズより小さい場合
            Else

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If pfrmTarget.Width / VB6.TwipsPerPixelX >= GC_DEF_DISPLY_WIDTH Or pfrmTarget.Height / VB6.TwipsPerPixelY >= GC_DEF_DISPLY_HEIGHT Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pfrmTarget.Top = 0
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pfrmTarget.Left = 0

                Else

                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換
                    'pfrmTarget.Top = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ 2) - (pfrmTarget.Height \ 2)
                    pfrmTarget.Top = (Utils.GetScreenHeight() \ 2) - (pfrmTarget.Height \ 2)
                    '--修正終了　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換
                    'pfrmTarget.Left = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ 2) - (pfrmTarget.Width \ 2)
                    pfrmTarget.Left = (Utils.GetScreenWidth() \ 2) - (pfrmTarget.Width \ 2)
                    '--修正終了　2021年04月09:OneTech（ツール）- Common_PrimaryScreen VB→VB.NET変換

                End If

            End If

            If plngHeight <> 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pfrmTarget.Height = plngHeight

            End If

            If plngWidth <> 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pfrmTarget.Width = plngWidth

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : Qt
    ' スコープ  : Public
    ' 処理内容  : フィールドにシングルクオーテーションを付加する
    ' 備    考  : 可読性が悪くなる為, 新規の機能での使用は禁止
    ' 返 り 値  : シングルクォーテーション付加文字列
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrFieldName       String            I     変換対象
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function Qt(ByVal pstrFieldName As String) As String

        Qt = "'" & pstrFieldName & "' "

    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCheckCashFeeCalCancel
    ' スコープ  : Public
    ' 処理内容  : 現金手数料計算 解除 チェック
    ' 備    考  :
    ' 返 り 値  : True （現金手数料計算 解除）
    '             False（現金手数料計算 対象）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrMishuuCode      String            I     未収コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/05/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCheckCashFeeCalCancel(ByVal pstrMishuuCode As String) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncCheckCashFeeCalCancel"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値に初期値を設定(現金手数料計算 対象)
            gfncCheckCashFeeCalCancel = False

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    * "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    名称マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    識別   = '現手解除' "
            strSQL = strSQL & Chr(10) & "AND コード = '" & pstrMishuuCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' 戻り値を設定（現金手数料計算 解除）
                    gfncCheckCashFeeCalCancel = True

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
            'PROC_END:

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysTemp = Nothing

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:abfb9e67-e159-4dc4-b766-9d7915075086
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:abfb9e67-e159-4dc4-b766-9d7915075086

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:abfb9e67-e159-4dc4-b766-9d7915075086
PROC_FINALLY_END:
        objDysTemp = Nothing
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:abfb9e67-e159-4dc4-b766-9d7915075086
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetMaxMoneyHonninFutan
    ' スコープ  : Public
    ' 処理内容  : 本人負担額 取得処理
    ' 備    考  :
    ' 返 り 値  : 本人負担額
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   --------------------+-----------------+-----+------------------------------
    '   pstrCompanyCode      String            I     会社コード
    '   gstrDate             String            I     営業日
    '   pstrEmployeeCode     String            I     従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/06/21  廣井  芳明         新規作成
    '   02.01       2008/07/21  廣井  芳明         入社Ｘヶ月未満の本人負担額免除 対応
    '
    '******************************************************************************
    Public Function gfncGetMaxMoneyHonninFutan(ByVal pstrCompanyCode As String, Optional ByVal gstrDate As String = "", Optional ByVal pstrEmployeeCode As String = "") As Decimal

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetMaxMoneyHonninFutan"
        Const C_DEF_負担額 As Decimal = 50000
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim lng選任月数 As Integer
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            ' 初期値を設定
            gfncGetMaxMoneyHonninFutan = C_DEF_負担額

            lng選任月数 = 99

            ' 日報日付が指定されている かつ
            ' 従業員コードが指定されている場合
            If gstrDate <> "" And pstrEmployeeCode <> "" Then

                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    TRUNC( "
                strSQL = strSQL & Chr(10) & "        MONTHS_BETWEEN( "
                strSQL = strSQL & Chr(10) & "            TO_DATE( "
                strSQL = strSQL & Chr(10) & "                '" & gstrDate & "' "
                strSQL = strSQL & Chr(10) & "            ), "
                strSQL = strSQL & Chr(10) & "            TO_DATE( "
                strSQL = strSQL & Chr(10) & "                DECODE(選任日付      ,NULL, "
                strSQL = strSQL & Chr(10) & "                DECODE(入社年月日    ,NULL, "
                strSQL = strSQL & Chr(10) & "                       '11111111',  "
                strSQL = strSQL & Chr(10) & "                       入社年月日    ), "
                strSQL = strSQL & Chr(10) & "                       選任日付      )  "
                strSQL = strSQL & Chr(10) & "            ) "
                strSQL = strSQL & Chr(10) & "        ) "
                strSQL = strSQL & Chr(10) & "    ) AS 選任月数 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    従業員マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrEmployeeCode & "' "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysTemp

                    ' 該当するデータが存在する場合
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .EOF = False Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lng選任月数 = gfncFieldCur(.Fields("選任月数").Value)

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                objDysTemp = Nothing

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    本人負担額      , "
            strSQL = strSQL & Chr(10) & "    負担額免除月数01, "
            strSQL = strSQL & Chr(10) & "    免除後負担額01    "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    事故コントロールマスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    管理コード = '" & pstrCompanyCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' 日報日付が指定されている かつ
                    ' 従業員コードが指定されている場合
                    If gstrDate <> "" And pstrEmployeeCode <> "" Then

                        ' 負担額免除月数が未設定または，NULLの場合
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If gfncFieldCur(.Fields("負担額免除月数01").Value) = 0 Then

                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("本人負担額").Value)

                            ' 負担額免除月数が設定されている場合
                        Else

                            ' 選任月数が負担額免除月数 未満 の場合
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            If lng選任月数 < gfncFieldCur(.Fields("負担額免除月数01").Value) Then

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("免除後負担額01").Value)

                                ' 選任月数が負担額免除月数 以上 の場合
                            Else

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("本人負担額").Value)

                            End If

                        End If

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("本人負担額").Value)

                    End If

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:abfb9e67-e159-4dc4-b766-9d7915075086
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:abfb9e67-e159-4dc4-b766-9d7915075086
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetCarKbnSQL
    ' スコープ  : Public
    ' 処理内容  : 車輌区分 判定用 ＳＱＬ文 取得
    ' 備    考  : 将来的(東京に車種マスタが導入されるタイミング)には，
    '             車種マスタに用途区分を移行する(現在は，車両区分マスタを参照)
    ' 返 り 値  : 車輌区分 判定用 ＳＱＬ文
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pintYoutoKbn        String            I     用途区分(0:タクシー,1:ハイヤー,2:ジャンボ)
    '   pstrSizeKbn         String            I     サイズ区分
    '   pstrSizeKbnJudg     String            I     サイズ区分判定
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00.00    2008/06/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetCarKbnSQL(ByVal pstrCompanyCode As String, ByVal pintYoutoKbn As basCommonConst.genYoto, Optional ByVal pstrSizeKbn As String = "", Optional ByVal pstrSizeKbnJudg As String = "") As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetCarKbnSQL"
        Dim strRet As String
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            gfncGetCarKbnSQL = ""

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    車輌区分 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    車輌区分マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード  = '" & pstrCompanyCode & "' "

            Select Case pintYoutoKbn
            '--------------------------------------------------------------------------
            ' タクシー
            '--------------------------------------------------------------------------
                Case basCommonConst.genYoto.Taxi

                    strSQL = strSQL & Chr(10) & "AND 用途区分    = '" & CStr(basCommonConst.genYoto.Taxi) & "' "

                '--------------------------------------------------------------------------
                ' ハイヤー
                '--------------------------------------------------------------------------
                Case basCommonConst.genYoto.Hire

                    ' 用途区分が２（ジャンボ）以外の車輌区分を参照
                    strSQL = strSQL & Chr(10) & "AND 用途区分   <> '" & CStr(basCommonConst.genYoto.Jumbo) & "' "

                '--------------------------------------------------------------------------
                ' ジャンボ
                '--------------------------------------------------------------------------
                Case basCommonConst.genYoto.Jumbo

                    ' 用途区分が２（ジャンボ）の車輌区分を参照
                    strSQL = strSQL & Chr(10) & "AND 用途区分    = '" & CStr(basCommonConst.genYoto.Jumbo) & "' "

            End Select

            ' サイズ区分が指定されている場合
            If pstrSizeKbn <> "" Then

                strSQL = strSQL & Chr(10) & "AND サイズ区分 " & pstrSizeKbnJudg & " '" & pstrSizeKbn & "' "

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                strRet = ""

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strRet = strRet & "'" & gfncFieldVal(.Fields("車輌区分").Value) & "',"

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            If strRet <> "" Then

                gfncGetCarKbnSQL = Mid(strRet, 1, Len(strRet) - 1)

            End If


            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:baa0fb0b-4d72-48a8-b517-36df6603a09a

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gsubSetComboFuelKbn
    ' スコープ  : Public
    ' 処理内容  : 会社コードに対応する燃料区分コンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pcboFuelKbn         ComboBox          I/O   燃料区分コンボ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboFuelKbn(ByVal pstrCompanyCode As String, ByRef pcboFuelKbn As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboFuelKbn"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call pcboFuelKbn.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboFuelKbn.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            If Len(pstrAllSelect) > 0 Then

                pcboFuelKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    燃料区分 "
            strSQL = strSQL & Chr(10) & "   ,燃料名   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    燃料区分マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    燃料区分 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboFuelKbn.Items.Add(CStr(Mid(.Fields("燃料区分").Value & Space(GC_LEN_FUEL_KBN), 1, GC_LEN_FUEL_KBN) & GC_COMBO_SPLIT & .Fields("燃料名").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5ad6ebc0-a306-444a-b9de-64689775b24e
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5ad6ebc0-a306-444a-b9de-64689775b24e

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5ad6ebc0-a306-444a-b9de-64689775b24e
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5ad6ebc0-a306-444a-b9de-64689775b24e
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gfncFormatDateString
    ' スコープ  : Public
    ' 処理内容  : 日付文字列をフォーマット
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     日付文字列[yyyymmdd]
    '   pintMode            Integer           I     モード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/09/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncFormatDateString(ByVal pstrTarget As String, ByVal pintMode As Short) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncFormatDateString"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月08日:MK（手）- VB→VB.NET変換
            If String.IsNullOrEmpty(pstrTarget) Then
                Return String.Empty
            End If
            '--修正開始　2021年06月08日:MK（手）- VB→VB.NET変換

            Select Case pintMode
            '--------------------------------------------------------------------------
            ' 年月日
            '--------------------------------------------------------------------------
                Case GC_CHECK_YMD

                    gfncFormatDateString = VB6.Format(VB6.Format(pstrTarget, "0000/00/00"), "yyyy(gggee)/mm/dd")

                '--------------------------------------------------------------------------
                ' 年月
                '--------------------------------------------------------------------------
                Case GC_CHECK_YM

                    gfncFormatDateString = VB6.Format(VB6.Format(pstrTarget, "0000/00"), "yyyy(gggee)/mm")

                '--------------------------------------------------------------------------
                ' 月日
                '--------------------------------------------------------------------------
                Case GC_CHECK_MD

                    gfncFormatDateString = VB6.Format(VB6.Format(pstrTarget, "00/00"), "mm/dd")

            End Select

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5ad6ebc0-a306-444a-b9de-64689775b24e
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5ad6ebc0-a306-444a-b9de-64689775b24e
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b2da5e8c-5631-4124-b3ad-2fa816a68130

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetFiscalYearMonth
    ' スコープ  : Public
    ' 処理内容  : 年月日より年月度を取得
    ' 備    考  :
    ' 返 り 値  : 年月度
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I     年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/09/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetFiscalYearMonth(ByRef pstrDate As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetFiscalYearMonth"
        Dim strYearMonth As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            ' 年月日の年月を採用
            strYearMonth = VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "yyyy/mm")

            ' 今日の日が基準日以上のとき＋１ヶ月
            If CShort(VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "d")) >= CShort(GC_DEF_基準日) Then

                strYearMonth = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(VB6.Format(pstrDate, "0000/00/00"))), "yyyy/mm")

            End If

            '年月編集
            gfncGetFiscalYearMonth = VB6.Format(strYearMonth, "yyyymm")

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1880a654-19d4-4849-abba-75554f5ef857
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1880a654-19d4-4849-abba-75554f5ef857

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1880a654-19d4-4849-abba-75554f5ef857
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1880a654-19d4-4849-abba-75554f5ef857
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetFiscalYear
    ' スコープ  : Public
    ' 処理内容  : 年月日より年度を取得
    ' 備    考  :
    ' 返 り 値  : 年度
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I     年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/09/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetFiscalYear(ByRef pstrDate As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetFiscalYear"
        Dim strYear As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            ' 年月日の年を採用
            strYear = VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "yyyy")

            ' 今日の日が基準日未満のとき－１年
            If CShort(VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "mmdd")) < CShort("03" & GC_DEF_基準日) Then

                strYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(pstrDate, "0000/00/00"))), "yyyy")

            End If

            ' 年月編集
            gfncGetFiscalYear = strYear

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1880a654-19d4-4849-abba-75554f5ef857
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1880a654-19d4-4849-abba-75554f5ef857
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetDateOfPreviousYear
    ' スコープ  : Public
    ' 処理内容  : 前年日付取得処理
    ' 備    考  :
    ' 返 り 値  : 前年日付(YYYYMMDD)
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I     日付(YYYYMMDD)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/09/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetDateOfPreviousYear(ByVal pstrDate As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetDateOfPreviousYear"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            If Mid(pstrDate, Len("yyyy") + 1, Len("mmdd")) = "0229" Then

                gfncGetDateOfPreviousYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(Mid(pstrDate, 1, Len("yyyy")) & "/02/28")), "yyyy") & "0229"

            Else

                gfncGetDateOfPreviousYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(pstrDate, "0000/00/00"))), "yyyymmdd")

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:732b9b99-75d7-48d8-8667-d1f4769fd680
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:732b9b99-75d7-48d8-8667-d1f4769fd680

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:732b9b99-75d7-48d8-8667-d1f4769fd680
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:732b9b99-75d7-48d8-8667-d1f4769fd680
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCatString
    ' スコープ  : Public
    ' 処理内容  : 文字列 切出し
    ' 備    考  :
    ' 返 り 値  : 変換後 文字列
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     切出し対象文字列
    '   plngLen             Long              I     切出し長
    '   pblnNarrow          Boolean           I     半角変換(True:あり)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/05/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCatString(ByVal pstrTarget As String, ByVal plngLen As Integer, Optional ByVal pblnNarrow As Boolean = False) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncCatString"
        Dim lngIdx As Integer
        Dim strTemp As String
        Dim strRet As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            gfncCatString = ""

            ' 両端のスペースを除去
            strTemp = Trim(pstrTarget)

            If pblnNarrow = True Then

                ' 半角に変換
                '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                'strTemp = StrConv(strTemp, VbStrConv.Narrow)
                strTemp = Utils.StrConv(strTemp, VbStrConv.Narrow)
                '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

            End If

            ' Ⅹバイト以下の場合
            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
            '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
            'If LenB(StrConv(strTemp, vbFromUnicode)) <= plngLen Then
            If Utils.LenB(Utils.StrConv(strTemp, vbFromUniCode)) <= plngLen Then
                '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

                strRet = strTemp

                ' (Ⅹ＋１)バイト以上の場合
            Else

                strRet = ""

                For lngIdx = 1 To Len(strTemp)

                    strRet = strRet & Mid(strTemp, lngIdx, 1)

                    ' (Ⅹ＋１)バイト以上の場合
                    'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                    'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                    '++修正開始　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換
                    'If LenB(StrConv(strRet, vbFromUnicode)) >= (plngLen + 1) Then
                    If Utils.LenB(Utils.StrConv(strRet, vbFromUniCode)) >= (plngLen + 1) Then
                        '--修正終了　2021年04月09:OneTech（ツール）- VB_002 VB→VB.NET変換

                        strRet = Mid(strRet, 1, Len(strRet) - 1)

                        Exit For

                    End If

                Next lngIdx

            End If

            gfncCatString = strRet

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:732b9b99-75d7-48d8-8667-d1f4769fd680
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:732b9b99-75d7-48d8-8667-d1f4769fd680
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    Public Function 項目エラー処理(ByRef errmsg As String, ByRef dsp As String, ByRef Title As String) As Short
        '++修正開始　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
        'With VB6.GetActiveControl()

        '++修正開始　2021年07月06日:MK（手）- VB→VB.NET変換
        If gctlActiveControl Is Nothing Then
            項目エラー処理 = MsgBox(errmsg, MsgBoxStyle.Exclamation, Title)
            Return Nothing
        End If
        '--修正開始　2021年07月06日:MK（手）- VB→VB.NET変換
        With gctlActiveControl
            '--修正終了　2021年04月11:OneTech（ツール）- Common_ActiveControl VB→VB.NET変換
            errmsg = IIf(errmsg = "", Replace(.Name, "txt", "") & "が不正です。", errmsg)
            Title = IIf(Title = "", Replace(.Name, "txt", "") & "エラー", Title)
            errmsg = IIf(errmsg = "", Replace(.Name, "cbo", "") & "が不正です。", errmsg)
            Title = IIf(Title = "", Replace(.Name, "cbo", "") & "エラー", Title)
            Select Case dsp
                Case "1"
                    項目エラー処理 = MsgBox(errmsg, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, Title)
                Case "2"
                    項目エラー処理 = MsgBox(errmsg, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, Title)
                Case Else
                    項目エラー処理 = MsgBox(errmsg, MsgBoxStyle.Exclamation, Title)
            End Select
            On Error Resume Next
            'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveControl.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
            '.SelStart = 0
            Utils.setSelectStartControl(gctlActiveControl, 0)
            '--修正終了　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
            'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveControl.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
            '.SelLength = Len(.Text)
            Utils.setSelectLengthControl(gctlActiveControl, Len(.Text))
            '--修正終了　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
            On Error GoTo 0
        End With
    End Function
    '******************************************************************************
    ' 関 数 名  : gsubSetComboRikujiCarKbn
    ' スコープ  : Public
    ' 処理内容  : 会社コードに対応する陸事車輌区分コンボリストを設定する
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     会社コード
    '   pcboCarKbn          ComboBox          I/O   車輌区分コンボ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2009/09/03  KSR                 新規作成
    '
    '******************************************************************************
    Public Sub gsubSetComboRikujiCarKbn(ByVal pstrCompanyCode As String, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetComboRikujiCarKbn"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            Call pcboCarKbn.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboCarKbn.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            If Len(pstrAllSelect) > 0 Then

                pcboCarKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    車輌区分   "
            strSQL = strSQL & Chr(10) & "   ,車輌区分名 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    陸事車輌区分マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    会社コード = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    車輌区分 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboCarKbn.Items.Add(CStr(Mid(.Fields("車輌区分").Value & Space(GC_LEN_CAR_KBN), 1, GC_LEN_CAR_KBN) & GC_COMBO_SPLIT & .Fields("車輌区分名").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gfncLinkCompanyToRikujiCarKbn
    ' スコープ  : Public
    ' 処理内容  : 会社コンボと陸事車輌区分コンボのリンクを行う。
    ' 備    考  :
    ' 返 り 値  : True （正常終了）
    '             False（異常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   会社コンボ
    '   pcboCarKbn          ComboBox          I/O   陸事車輌区分コンボ
    '   pblnCancel          Boolean           O     キャンセルフラグ
    '   pstrAllSelect       String            I     指定条件なしを表す文字列
    '   pintDefSet          Integer           I     デフォルトのListIndex
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2009/09/03  ＫＳＲ  　         新規作成
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToRikujiCarKbn(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToRikujiCarKbn"
        Dim blnRet As Boolean
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            blnRet = False

            pblnCancel = False

            Call pcboCarKbn.Items.Clear()
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            pcboCarKbn.Text = String.Empty
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換

            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else
                    '------------------
                    '   陸事車輌区分をセット
                    '------------------
                    Call gsubSetComboRikujiCarKbn(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboCarKbn, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboCarKbn.Items.Count > 0 Then

                pcboCarKbn.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToRikujiCarKbn = blnRet

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dda15d16-20e2-415a-91c2-a253f31097b8
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dda15d16-20e2-415a-91c2-a253f31097b8

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dda15d16-20e2-415a-91c2-a253f31097b8
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dda15d16-20e2-415a-91c2-a253f31097b8
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetNameToControl
    ' スコープ  : Public
    ' 処理内容  : コントロールから名称を抜き出す
    ' 備    考  :
    ' 返 り 値  : コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrControlText     String            I     コントロールのテキスト
    '   pintCodeLen         Integer           I     コード長
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/11  KSR                新規作成
    '
    '******************************************************************************
    Public Function gfncGetNameToControl(ByVal pstrControlText As String, ByVal pintCodeLen As Short) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetNameToControl"
        Dim strCode As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            strCode = RTrim(Mid(pstrControlText & Space(pintCodeLen + 4), pintCodeLen + 4))

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dda15d16-20e2-415a-91c2-a253f31097b8
            'PROC_END:

            'gfncGetNameToControl = strCode

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:dda15d16-20e2-415a-91c2-a253f31097b8
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
PROC_FINALLY_END:
        gfncGetNameToControl = strCode
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncEditNameBank
    ' スコープ  : Public
    ' 処理内容  : 銀行名  編集
    ' 備    考  :
    ' 返 り 値  : 銀行名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     銀行名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/01/08  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncEditNameBank(ByVal pstrTarget As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetNameToControl"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            Select Case Right(pstrTarget, 2)
                Case "金庫", "信託", "信金", "組合", "農協"

                    gfncEditNameBank = pstrTarget

                Case Else

                    gfncEditNameBank = pstrTarget & "銀行"

            End Select

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncEditNameBankBranch
    ' スコープ  : Public
    ' 処理内容  : 銀行支店名  編集
    ' 備    考  :
    ' 返 り 値  : 銀行支店名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     銀行名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/01/08  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncEditNameBankBranch(ByVal pstrTarget As String) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncEditNameBankBranch"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            ' 本店
            If pstrTarget = "本店" Then

                gfncEditNameBankBranch = Trim(pstrTarget)

                ' 出張所
            ElseIf Right(pstrTarget, 3) = "出張所" Then

                gfncEditNameBankBranch = Trim(pstrTarget)

                ' 営業部
            ElseIf Right(pstrTarget, 3) = "営業部" Then

                gfncEditNameBankBranch = Trim(pstrTarget)

                ' 上記以外
            Else

                gfncEditNameBankBranch = Trim(pstrTarget) & "支店"

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3b119d2c-7091-4c5a-80e4-4b4baa167035

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncCnvWideToHalf
    ' スコープ  : Public
    ' 処理内容  : 全角⇒半角 変換
    ' 備    考  :
    ' 返 り 値  : 半角変換後 文字列
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     チェックタイプ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/06/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCnvWideToHalf(ByVal pstrTarget As String) As String

        Dim strRet As String

        strRet = pstrTarget

        strRet = Replace(strRet, "０", "0")
        strRet = Replace(strRet, "１", "1")
        strRet = Replace(strRet, "２", "2")
        strRet = Replace(strRet, "３", "3")
        strRet = Replace(strRet, "４", "4")
        strRet = Replace(strRet, "５", "5")
        strRet = Replace(strRet, "６", "6")
        strRet = Replace(strRet, "７", "7")
        strRet = Replace(strRet, "８", "8")
        strRet = Replace(strRet, "９", "9")

        strRet = Replace(strRet, "－", "-")
        strRet = Replace(strRet, "＋", "+")
        strRet = Replace(strRet, "＊", "*")
        strRet = Replace(strRet, "／", "/")
        strRet = Replace(strRet, "・", "･")
        strRet = Replace(strRet, "　", " ")
        strRet = Replace(strRet, "（", "(")
        strRet = Replace(strRet, "）", ")")
        strRet = Replace(strRet, "￥", "\")
        strRet = Replace(strRet, "％", "%")
        strRet = Replace(strRet, "＄", "$")
        strRet = Replace(strRet, "＃", "#")
        strRet = Replace(strRet, "！", "!")
        strRet = Replace(strRet, "？", "?")
        strRet = Replace(strRet, "＆", "&")
        strRet = Replace(strRet, "～", "~")
        strRet = Replace(strRet, "＠", "@")

        strRet = Replace(strRet, "ア", "ｱ")
        strRet = Replace(strRet, "イ", "ｲ")
        strRet = Replace(strRet, "ウ", "ｳ")
        strRet = Replace(strRet, "エ", "ｴ")
        strRet = Replace(strRet, "オ", "ｵ")

        strRet = Replace(strRet, "ァ", "ｧ")
        strRet = Replace(strRet, "ィ", "ｨ")
        strRet = Replace(strRet, "ゥ", "ｩ")
        strRet = Replace(strRet, "ェ", "ｪ")
        strRet = Replace(strRet, "ォ", "ｫ")

        strRet = Replace(strRet, "ヴ", "ｳﾞ")

        strRet = Replace(strRet, "ガ", "ｶﾞ")
        strRet = Replace(strRet, "ギ", "ｷﾞ")
        strRet = Replace(strRet, "グ", "ｸﾞ")
        strRet = Replace(strRet, "ゲ", "ｹﾞ")
        strRet = Replace(strRet, "ゴ", "ｺﾞ")

        strRet = Replace(strRet, "カ", "ｶ")
        strRet = Replace(strRet, "キ", "ｷ")
        strRet = Replace(strRet, "ク", "ｸ")
        strRet = Replace(strRet, "ケ", "ｹ")
        strRet = Replace(strRet, "コ", "ｺ")

        strRet = Replace(strRet, "サ", "ｻ")
        strRet = Replace(strRet, "シ", "ｼ")
        strRet = Replace(strRet, "ス", "ｽ")
        strRet = Replace(strRet, "セ", "ｾ")
        strRet = Replace(strRet, "ソ", "ｿ")

        strRet = Replace(strRet, "ザ", "ｻﾞ")
        strRet = Replace(strRet, "ジ", "ｼﾞ")
        strRet = Replace(strRet, "ズ", "ｽﾞ")
        strRet = Replace(strRet, "ゼ", "ｾﾞ")
        strRet = Replace(strRet, "ゾ", "ｿﾞ")

        strRet = Replace(strRet, "タ", "ﾀ")
        strRet = Replace(strRet, "チ", "ﾁ")
        strRet = Replace(strRet, "ツ", "ﾂ")
        strRet = Replace(strRet, "テ", "ﾃ")
        strRet = Replace(strRet, "ト", "ﾄ")

        strRet = Replace(strRet, "ッ", "ｯ")

        strRet = Replace(strRet, "ダ", "ﾀﾞ")
        strRet = Replace(strRet, "ヂ", "ﾁﾞ")
        strRet = Replace(strRet, "ヅ", "ﾂﾞ")
        strRet = Replace(strRet, "デ", "ﾃﾞ")
        strRet = Replace(strRet, "ド", "ﾄﾞ")

        strRet = Replace(strRet, "ナ", "ﾅ")
        strRet = Replace(strRet, "ニ", "ﾆ")
        strRet = Replace(strRet, "ヌ", "ﾇ")
        strRet = Replace(strRet, "ネ", "ﾈ")
        strRet = Replace(strRet, "ノ", "ﾉ")

        strRet = Replace(strRet, "ハ", "ﾊ")
        strRet = Replace(strRet, "ヒ", "ﾋ")
        strRet = Replace(strRet, "フ", "ﾌ")
        strRet = Replace(strRet, "ヘ", "ﾍ")
        strRet = Replace(strRet, "ホ", "ﾎ")

        strRet = Replace(strRet, "バ", "ﾊﾞ")
        strRet = Replace(strRet, "ビ", "ﾋﾞ")
        strRet = Replace(strRet, "ブ", "ﾌﾞ")
        strRet = Replace(strRet, "ベ", "ﾍﾞ")
        strRet = Replace(strRet, "ボ", "ﾎﾞ")

        strRet = Replace(strRet, "パ", "ﾊﾟ")
        strRet = Replace(strRet, "ピ", "ﾋﾟ")
        strRet = Replace(strRet, "プ", "ﾌﾟ")
        strRet = Replace(strRet, "ペ", "ﾍﾟ")
        strRet = Replace(strRet, "ポ", "ﾎﾟ")

        strRet = Replace(strRet, "マ", "ﾏ")
        strRet = Replace(strRet, "ミ", "ﾐ")
        strRet = Replace(strRet, "ム", "ﾑ")
        strRet = Replace(strRet, "メ", "ﾒ")
        strRet = Replace(strRet, "モ", "ﾓ")

        strRet = Replace(strRet, "ヤ", "ﾔ")
        strRet = Replace(strRet, "ユ", "ﾕ")
        strRet = Replace(strRet, "ヨ", "ﾖ")

        strRet = Replace(strRet, "ャ", "ｬ")
        strRet = Replace(strRet, "ュ", "ｭ")
        strRet = Replace(strRet, "ョ", "ｮ")

        strRet = Replace(strRet, "ラ", "ﾗ")
        strRet = Replace(strRet, "リ", "ﾘ")
        strRet = Replace(strRet, "ル", "ﾙ")
        strRet = Replace(strRet, "レ", "ﾚ")
        strRet = Replace(strRet, "ロ", "ﾛ")

        strRet = Replace(strRet, "ワ", "ﾜ")
        strRet = Replace(strRet, "ヲ", "ｦ")
        strRet = Replace(strRet, "ン", "ﾝ")

        strRet = Replace(strRet, "ー", "ｰ")
        strRet = Replace(strRet, "―", "-")

        strRet = Replace(strRet, "Ａ", "A")
        strRet = Replace(strRet, "Ｂ", "B")
        strRet = Replace(strRet, "Ｃ", "C")
        strRet = Replace(strRet, "Ｄ", "D")
        strRet = Replace(strRet, "Ｅ", "E")
        strRet = Replace(strRet, "Ｆ", "F")
        strRet = Replace(strRet, "Ｇ", "G")
        strRet = Replace(strRet, "Ｈ", "H")
        strRet = Replace(strRet, "Ｉ", "I")
        strRet = Replace(strRet, "Ｊ", "J")
        strRet = Replace(strRet, "Ｋ", "K")
        strRet = Replace(strRet, "Ｌ", "L")
        strRet = Replace(strRet, "Ｍ", "M")
        strRet = Replace(strRet, "Ｎ", "N")
        strRet = Replace(strRet, "Ｏ", "O")
        strRet = Replace(strRet, "Ｐ", "P")
        strRet = Replace(strRet, "Ｑ", "Q")
        strRet = Replace(strRet, "Ｒ", "R")
        strRet = Replace(strRet, "Ｓ", "S")
        strRet = Replace(strRet, "Ｔ", "T")
        strRet = Replace(strRet, "Ｕ", "U")
        strRet = Replace(strRet, "Ｖ", "V")
        strRet = Replace(strRet, "Ｗ", "W")
        strRet = Replace(strRet, "Ｘ", "X")
        strRet = Replace(strRet, "Ｙ", "Y")
        strRet = Replace(strRet, "Ｚ", "Z")
        strRet = Replace(strRet, "ａ", "a")
        strRet = Replace(strRet, "ｂ", "b")
        strRet = Replace(strRet, "ｃ", "c")
        strRet = Replace(strRet, "ｄ", "d")
        strRet = Replace(strRet, "ｅ", "e")
        strRet = Replace(strRet, "ｆ", "f")
        strRet = Replace(strRet, "ｇ", "g")
        strRet = Replace(strRet, "ｈ", "h")
        strRet = Replace(strRet, "ｉ", "i")
        strRet = Replace(strRet, "ｊ", "j")
        strRet = Replace(strRet, "ｋ", "k")
        strRet = Replace(strRet, "ｌ", "l")
        strRet = Replace(strRet, "ｍ", "m")
        strRet = Replace(strRet, "ｎ", "n")
        strRet = Replace(strRet, "ｏ", "o")
        strRet = Replace(strRet, "ｐ", "p")
        strRet = Replace(strRet, "ｑ", "q")
        strRet = Replace(strRet, "ｒ", "r")
        strRet = Replace(strRet, "ｓ", "s")
        strRet = Replace(strRet, "ｔ", "t")
        strRet = Replace(strRet, "ｕ", "u")
        strRet = Replace(strRet, "ｖ", "v")
        strRet = Replace(strRet, "ｗ", "w")
        strRet = Replace(strRet, "ｘ", "x")
        strRet = Replace(strRet, "ｙ", "y")
        strRet = Replace(strRet, "ｚ", "z")

        strRet = Replace(strRet, "㈲", "(有)")
        strRet = Replace(strRet, "㈱", "(株)")

        strRet = Replace(strRet, "有限会社", "(有)")
        strRet = Replace(strRet, "株式会社", "(株)")
        strRet = Replace(strRet, "財団法人", "(財)")
        strRet = Replace(strRet, "社団法人", "(社)")

        gfncCnvWideToHalf = strRet

    End Function
    '******************************************************************************
    ' 関 数 名  : gsubSetControlLocked
    ' スコープ  : Public
    ' 処理内容  : コントロールロック状態設定処理
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTarget          Object            I     ロック対象コントロール
    '   pblnLocked          Boolean           I     ロックフラグ(True：ロック)
    '   pblnTabStop         Boolean           I     タブストップ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/07/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubSetControlLocked(ByRef pobjTarget As Object, ByVal pblnLocked As Boolean, Optional ByVal pblnTabStop As Boolean = True)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR

        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetControlLocked"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_BACK_COLOR_LOCK As Integer = &H8000000F
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_BACK_COLOR_UN_LOCK As Integer = &H80000005
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            With pobjTarget

                If pblnLocked = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.Locked. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'


                    '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    '  .Locked = True
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).ReadOnly = True
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).ReadOnly = True
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = False
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = True
                        CType(pobjTarget, Common.MKCombobox).CustomizeReadOnly = True
                    Else
                        .Locked = True
                    End If
                    '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.BackColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    '.BackColor = C_BACK_COLOR_LOCK
                    .BackColor = System.Drawing.ColorTranslator.FromOle(C_BACK_COLOR_LOCK)
                    '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.TabStop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .TabStop = False
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.MousePointer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    '.MousePointer = System.Windows.Forms.Cursors.Arrow
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    Else
                        '++修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
                        '.MousePointer = System.Windows.Forms.Cursors.Arrow
                        '--修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
                    End If
                    '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換

                Else

                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.Locked. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    '  .Locked = False
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).ReadOnly = False
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).ReadOnly = False
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = True
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = True
                        CType(pobjTarget, Common.MKCombobox).CustomizeReadOnly = False
                    Else
                        '++修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
                        '.Locked = False
                        '--修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
                    End If
                    '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.BackColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    '.BackColor = C_BACK_COLOR_UN_LOCK
                    .BackColor = System.Drawing.ColorTranslator.FromOle(C_BACK_COLOR_UN_LOCK)
                    '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.TabStop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .TabStop = pblnTabStop
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.MousePointer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
                    '.MousePointer = System.Windows.Forms.Cursors.Default
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).Cursor = System.Windows.Forms.Cursors.Default
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).Cursor = System.Windows.Forms.Cursors.Default
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Default
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Default
                    Else
                        '++修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
                        '.MousePointer = System.Windows.Forms.Cursors.Default
                        '--修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
                    End If
                    '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換

                End If

                '--修正終了　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換

                '++修正開始　2021年05月28:MK（手）- VB_522 VB→VB.NET変換

                'On Error Resume Next

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年04月09:OneTech（ツール）- VB_570 VB→VB.NET変換
                '.SelLength = 0
                '.SelectionLength = 0
                '  On Error GoTo PROC_ERROR
                Try

                    .SelectionLength = 0
                Catch ex1 As Exception

                End Try
                '++修正開始　2021年05月28:MK（手）- VB_523 VB→VB.NET変換


            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7334c903-6075-4d07-843b-df8b4f6b6979
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7334c903-6075-4d07-843b-df8b4f6b6979

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7334c903-6075-4d07-843b-df8b4f6b6979
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7334c903-6075-4d07-843b-df8b4f6b6979
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : gfncCnvColumnNumToColumnName
    ' スコープ  : Public
    ' 処理内容  : カラム番号からカラム名 変換
    ' 備    考  :
    ' 返 り 値  : カラム名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjXlsSheets       Object            I/O   シート
    '   pintColNum          Integer           I     カラム番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/09/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncCnvColumnNumToColumnName(ByRef pobjXlsSheets As Object, ByVal pintColNum As Short) As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncCnvColumnNumToColumnName"
        Dim strColName As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            ' 列の範囲チェック（存在しない列番号の場合は、UnKnownを返す）
            If pintColNum >= 1 And pintColNum <= 256 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjXlsSheets.Cells. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strColName = Mid(pobjXlsSheets.Cells(1, pintColNum).Address, 2, InStr(pobjXlsSheets.Cells(1, pintColNum).Address, "1") - 3)

            Else

                strColName = "UnKnown"

            End If

            gfncCnvColumnNumToColumnName = strColName

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7334c903-6075-4d07-843b-df8b4f6b6979
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7334c903-6075-4d07-843b-df8b4f6b6979
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:44dcf758-3379-4ded-9248-43b4dabc1d34
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:44dcf758-3379-4ded-9248-43b4dabc1d34

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:44dcf758-3379-4ded-9248-43b4dabc1d34
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:44dcf758-3379-4ded-9248-43b4dabc1d34
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncGetDays
    ' スコープ  : Private
    ' 処理内容  : 日数取得
    ' 備    考  :
    ' 返 り 値  : 日数
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDateFrom        String            I     日付(自)
    '   pstrDateTo          String            I     日付(至)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   03.06.00    2010/04/26  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetDays(ByVal pstrDateFrom As String, ByVal pstrDateTo As String) As Short

        Dim strDateFrom As String
        Dim strDateTo As String

        gfncGetDays = 0

        strDateFrom = pstrDateFrom

        strDateTo = pstrDateTo

        If IsDate(VB6.Format(strDateFrom, "0000/00/00")) = False Then

            If Mid(strDateFrom, Len("yyyy") + 1, Len("mmdd")) = "0229" Then

                strDateFrom = Mid(strDateFrom, 1, Len("yyyy")) & "0301"

            Else

                Exit Function

            End If

        End If

        If IsDate(VB6.Format(strDateTo, "0000/00/00")) = False Then

            If Mid(strDateTo, Len("yyyy") + 1, Len("mmdd")) = "0229" Then

                strDateTo = Mid(strDateFrom, 1, Len("yyyy")) & "0228"

            Else

                Exit Function

            End If

        End If

        'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        gfncGetDays = CInt(DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(strDateFrom, "0000/00/00")), CDate(VB6.Format(strDateTo, "0000/00/00")))) + 1

    End Function

    '******************************************************************************
    ' 関 数 名  : gFNC_GET_TAXRATE
    ' スコープ  : Public
    ' 処理内容  : 税率取得
    ' 備    考  :
    ' 返 り 値  : 税率
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I/O   税率を取得する基準日(YYYYMMDD形式)
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2014/03/19  ＫＳＲ        　　 新規作成
    '
    '******************************************************************************
    Public Function gFNC_GET_TAXRATE(ByVal pstrDate As String) As Double

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gFNC_GET_TAXRATE"
        Dim dblRet As Double
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            dblRet = 0

            ' SQL文 作成
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    FNC_GET_TAXRATE('" & pstrDate & "') AS 税率 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    DUAL "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在しない場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then

                    ' 処理なし

                    ' 該当するデータが存在する場合
                Else

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    dblRet = gfncFieldCur(.Fields("税率").Value)


                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:44dcf758-3379-4ded-9248-43b4dabc1d34
            'PROC_END:

            'gFNC_GET_TAXRATE = dblRet

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:44dcf758-3379-4ded-9248-43b4dabc1d34
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7883e405-739a-4d9e-8755-c3ff9394bcd1

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
PROC_FINALLY_END:
        gFNC_GET_TAXRATE = dblRet
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function


    '******************************************************************************
    ' 関 数 名  : gFNC_GET_SPECIALFIRST
    ' スコープ  : Public
    ' 処理内容  : 特殊ファーストの取得
    ' 備    考  : 特殊ファーストは、ファーストマスタ.営業実績個別区分 = 1で判断する.
    '             ＜gFNC_GET_SPECIALFIRSTにセットする値について＞
    '               0行目はブランク.実データは1行目以降にセットする.
    ' 返 り 値  : リスト
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2017/01/24  ＫＳＲ        　　 新規作成
    '
    '******************************************************************************
    Public Function gFNC_GET_SPECIALFIRST() As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gFNC_GET_SPECIALFIRST"
        Dim dblRet As Double
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            ' SQL文 作成
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ファースト,ファースト名 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ファーストマスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    営業実績個別区分 = 1 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then

                    ReDim gstrSpcFrst(0)
                    ReDim gstrSpcFrstNm(0)

                Else
                    dblRet = 1

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ReDim gstrSpcFrst(.RecordCount)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ReDim gstrSpcFrstNm(.RecordCount)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gstrSpcFrst(dblRet) = .Fields("ファースト").Value
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gstrSpcFrstNm(dblRet) = .Fields("ファースト名").Value '//帳票表示用
                        dblRet = dblRet + 1

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()
            End With

            gFNC_GET_SPECIALFIRST = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:857c18d9-395d-40b5-9152-145440c800e5
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:857c18d9-395d-40b5-9152-145440c800e5

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:857c18d9-395d-40b5-9152-145440c800e5
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:857c18d9-395d-40b5-9152-145440c800e5
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function

    '//2018/10/05 追加
    Public Function gGetSystemDate() As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsSysDate_gGetSystemDate"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            ' 初期値を設定(異常終了)
            gGetSystemDate = ""

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    TO_CHAR(sysdate,'YYYY/MM/DD HH24:MI:SS') SystemDate "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    DUAL "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gGetSystemDate = objDysTemp.Fields("SystemDate").Value

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call objDysTemp.Close()

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:857c18d9-395d-40b5-9152-145440c800e5
            'PROC_END:

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysTemp = Nothing

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:857c18d9-395d-40b5-9152-145440c800e5
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02a7f3ba-04a5-429b-bccc-69d0d205b746
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02a7f3ba-04a5-429b-bccc-69d0d205b746


            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02a7f3ba-04a5-429b-bccc-69d0d205b746
PROC_FINALLY_END:
        objDysTemp = Nothing
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02a7f3ba-04a5-429b-bccc-69d0d205b746
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function



    '++修正開始　2023年09月23日:MK（手）- VB→VB.NET変換
    Public Function gGetZeikinByShohinCode(strShohinCode As String, dtShukeiDate As String) As TAG_Zeiritu

        Const C_NAME_FUNCTION As String = "gGetZeikinFromShohin"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset

        ' 初期値を設定(異常終了)
        gGetZeikinByShohinCode = New TAG_Zeiritu

        Try

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT CASE WHEN " & dtShukeiDate & " >= UK.適用日付 THEN UK.税率"
            strSQL = strSQL & Chr(10) & "       ELSE UK.前税率"
            strSQL = strSQL & Chr(10) & "       END AS 税率"
            strSQL = strSQL & Chr(10) & "      ,SM.仕入税率コード"
            strSQL = strSQL & Chr(10) & "FROM 商品マスタ SM "
            strSQL = strSQL & Chr(10) & "INNER JOIN  運管仕入税率マスタ UK ON  SM.仕入税率コード = UK.仕入税率コード "
            strSQL = strSQL & Chr(10) & "WHERE SM.商品コード = " & strShohinCode

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            If objDysTemp.EOF = False Then

                gGetZeikinByShohinCode.mTstr税率 = objDysTemp.Fields("税率").Value
                gGetZeikinByShohinCode.mTstr税率コード = objDysTemp.Fields("仕入税率コード").Value

            End If

            Call objDysTemp.Close()
            objDysTemp = Nothing

        Catch ex As Exception

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

        Return gGetZeikinByShohinCode
    End Function

    Public Function gGetZeikinCodeByZeiritu(strZeuritsu As String, dtShukeiDate As String) As String

        Const C_NAME_FUNCTION As String = "gGetZeikinFromShohin"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset

        ' 初期値を設定(異常終了)
        gGetZeikinCodeByZeiritu = ""

        Try

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT 仕入税率コード "
            strSQL = strSQL & Chr(10) & "FROM 運管仕入税率マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    " & strZeuritsu & " = (CASE WHEN '" & dtShukeiDate & "' >= 適用日付 THEN 税率 "
            strSQL = strSQL & Chr(10) & "                                ELSE 前税率 "
            strSQL = strSQL & Chr(10) & "                           END) "

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            If objDysTemp.EOF = False Then

                gGetZeikinCodeByZeiritu = objDysTemp.Fields("仕入税率コード").Value

            End If

            Call objDysTemp.Close()
            objDysTemp = Nothing

        Catch ex As Exception

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

        Return gGetZeikinCodeByZeiritu
    End Function

    Public Function gGet運管仕入税率マスタ(dtShukeiDate As String) As List(Of TAG_Zeiritu)

        Const C_NAME_FUNCTION As String = "gGet運管仕入税率マスタ"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        Dim zeiritu As TAG_Zeiritu
        ' 初期値を設定(異常終了)
        gGet運管仕入税率マスタ = New List(Of TAG_Zeiritu)

        Try

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT CASE WHEN " & dtShukeiDate & " >= 適用日付 THEN 税率"
            strSQL = strSQL & Chr(10) & "       ELSE 前税率"
            strSQL = strSQL & Chr(10) & "       END AS 税率"
            strSQL = strSQL & Chr(10) & "      ,仕入税率コード"
            strSQL = strSQL & Chr(10) & "FROM 運管仕入税率マスタ"

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            Do Until objDysTemp.EOF = True

                zeiritu = New TAG_Zeiritu
                zeiritu.mTstr税率 = objDysTemp.Fields("税率").Value
                zeiritu.mTstr税率コード = objDysTemp.Fields("仕入税率コード").Value
                gGet運管仕入税率マスタ.Add(zeiritu)
                Call objDysTemp.MoveNext()

            Loop

            Call objDysTemp.Close()
            objDysTemp = Nothing

        Catch ex As Exception

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

        Return gGet運管仕入税率マスタ
    End Function
    '--修正開始　2023年09月23日:MK（手）- VB→VB.NET変換
    '******************************************************************************
    ' 関 数 名  : gsubGetPathMaster
    ' スコープ  :
    ' 処理内容  : パス管理マスタのパス１を取得
    ' 備    考  :
    ' 返 り 値  :文字列（iniファイルのパス）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pPathType          String            O     パス識別
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   00.00.01    2024/05/30  HUYTQ              作成
    '
    '******************************************************************************
    Public Function gfncGetPathMaster(ByVal pPathType As String) As String
        Dim strSQL As String
        Dim objDysTemp As Object

        ' 初期値を設定(異常終了)
        gfncGetPathMaster = ""

        '取得
        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    パス１ "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    パス管理マスタ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    パス識別 = '" & pPathType & "' "

        objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        If objDysTemp.EOF = False Then
            gfncGetPathMaster = gfncFieldVal(objDysTemp.Fields("パス１").Value)
        End If

        Call objDysTemp.Close()
        objDysTemp = Nothing

    End Function

End Module

