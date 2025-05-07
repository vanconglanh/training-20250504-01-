Option Strict Off
Option Explicit On

Imports Common

Friend Class frmLogin
    '++修正開始　2021年06月03日:MK（手）- VB→VB.NET変換
    'Inherits System.Windows.Forms.Form
    Inherits MKForm
    '--修正開始　2021年06月03日:MK（手）- VB→VB.NET変換

    '変数
    Private mstrPassword As String ' パスワード

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click

        If txtPassword.Text <> mstrPassword Then

            Call MsgBox(GC_ERR_MSG_8000, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

            Call txtPassword.Focus()

            Exit Sub

        End If

        gintOkCancel = MsgBoxResult.OK

        ' フォームを閉じる
        Me.Close()

        ' メモリ上から完全に消去
        'UPGRADE_NOTE: オブジェクト frmLogin をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
        'Me = Nothing
        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        gintOkCancel = MsgBoxResult.Cancel

        Me.Close()

        'UPGRADE_NOTE: オブジェクト frmLogin をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
        'Me = Nothing
        '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    End Sub
    Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter

        txtPassword.SelectionStart = 0
        txtPassword.SelectionLength = Len(txtPassword.Text)

    End Sub
    Private Sub txtEmployeeCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEmployeeCode.Enter

        txtEmployeeCode.SelectionStart = 0
        txtEmployeeCode.SelectionLength = Len(txtEmployeeCode.Text)

    End Sub
    Private Sub txtEmployeeCode_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtEmployeeCode.Validating
        Dim Cancel As Boolean = eventArgs.Cancel

        Dim objDys従業員マスタ As Object
        Dim strSQL As String

        '--------------------------------------------------------------------------
        ' SQL文 作成
        '--------------------------------------------------------------------------
        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    JM.会社コード  , "
        strSQL = strSQL & Chr(10) & "    JM.所属コード  , "
        strSQL = strSQL & Chr(10) & "    JM.従業員コード, "
        strSQL = strSQL & Chr(10) & "    JM.従業員名漢字, "
        strSQL = strSQL & Chr(10) & "    JM.パスワード  , "
        strSQL = strSQL & Chr(10) & "    JM.役職位コード, "
        strSQL = strSQL & Chr(10) & "    JM.ランク      , "
        strSQL = strSQL & Chr(10) & "    NVL(JM.退社予定日,'99999999') AS 退社予定日, "
        strSQL = strSQL & Chr(10) & "    MM.係数１      , "
        strSQL = strSQL & Chr(10) & "    BM.システム権限, "
        strSQL = strSQL & Chr(10) & "    TO_CHAR(SYSDATE,'YYYYMMDD') AS システム日付 "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    従業員マスタ JM, "
        strSQL = strSQL & Chr(10) & "    部署マスタ   BM, "
        strSQL = strSQL & Chr(10) & "    名称マスタ   MM  "
        strSQL = strSQL & Chr(10) & " WHERE JM.従業員コード = '" & txtEmployeeCode.Text & "' "
        strSQL = strSQL & Chr(10) & "   AND JM.所属コード   = BM.所属コード(+) "
        strSQL = strSQL & Chr(10) & "   AND JM.役職位コード = MM.コード    (+) "
        strSQL = strSQL & Chr(10) & "   AND '役職位'        = MM.識別      (+) "

        'UPGRADE_WARNING: オブジェクト gobjOraDatabase.CreateDynaset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        objDys従業員マスタ = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        With objDys従業員マスタ

            'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.EOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If .EOF = True Then

                Cancel = True

                Call MsgBox(GC_ERR_MSG_0003, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                txtEmployeeCode.SelectionStart = 0
                txtEmployeeCode.SelectionLength = Len(txtEmployeeCode.Text)

                GoTo EventExitSub

            Else

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If .Fields("退社予定日").Value < VB6.Format(Now, "YYYYMMDD") Then

                    Cancel = True

                    Call MsgBox(GC_ERR_MSG_0019, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                    txtEmployeeCode.SelectionStart = 0
                    txtEmployeeCode.SelectionLength = Len(txtEmployeeCode.Text)

                    GoTo EventExitSub

                End If

                '            If mfncFieldVal(.Fields("ランク").Value) <> "A" And _
                ''               mfncFieldVal(.Fields("ランク").Value) <> "B" Then
                '
                '                Cancel = True
                '
                '                Call MsgBox("システムを使用する権限がありません。", _
                ''                            vbOKOnly + vbCritical, _
                ''                            GC_ERR_TITLE)
                '
                '                txtEmployeeCode.SelStart = 0
                '                txtEmployeeCode.SelLength = Len(txtEmployeeCode.Text)
                '
                '                Exit Sub
                '
                '            End If

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gstrCompanyCode = mfncFieldVal(.Fields("会社コード").Value)
                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gstrPostCode = mfncFieldVal(.Fields("所属コード").Value)
                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gstrEmployeeCode = mfncFieldVal(.Fields("従業員コード").Value)

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gintSystemAuthority = mfncFieldCur(.Fields("システム権限").Value)
                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If mfncFieldCur(.Fields("係数１").Value) <> 0 Then

                    'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    gintSystemAuthority = mfncFieldCur(.Fields("係数１").Value)

                End If

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gstrRank = mfncFieldVal(.Fields("ランク").Value)

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gstrEmployeeName = mfncFieldVal(.Fields("従業員名漢字").Value)

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gintOfficialPosition = mfncFieldCur(.Fields("役職位コード").Value)

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                mstrPassword = mfncFieldVal(.Fields("パスワード").Value)

                'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト gvntLoginDate の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                gvntLoginDate = mfncFieldVal(.Fields("システム日付").Value)

            End If

            'UPGRADE_WARNING: オブジェクト objDys従業員マスタ.Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call .Close()

        End With

        'UPGRADE_NOTE: オブジェクト objDys従業員マスタ をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        objDys従業員マスタ = Nothing

        'ランク未取得の場合は最下位ランクを取得
        If Len(gstrRank) = 0 Then

            If mfncGetLowRank(gobjOraDatabase, gstrRank) = True Then

                Cancel = True

                Call MsgBox(GC_ERR_MSG_0017, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                txtEmployeeCode.SelectionStart = 0
                txtEmployeeCode.SelectionLength = Len(txtPassword.Text)

                GoTo EventExitSub

            End If

        End If

EventExitSub:
        eventArgs.Cancel = Cancel
    End Sub

    Private Function mfncFieldVal(ByVal pvntTar As Object) As Object

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDbNull(pvntTar) = True Then
            'UPGRADE_WARNING: オブジェクト mfncFieldVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            mfncFieldVal = vbNullString
        Else
            'UPGRADE_WARNING: オブジェクト pvntTar の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト mfncFieldVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            mfncFieldVal = CStr(pvntTar)
        End If

    End Function

    Public Function mfncFieldCur(ByVal pvntTar As Object) As Decimal

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDbNull(pvntTar) = True Or Len(pvntTar) = 0 Then

            mfncFieldCur = 0

        Else

            If IsNumeric(pvntTar) = True Then

                'UPGRADE_WARNING: オブジェクト pvntTar の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                mfncFieldCur = CDec(pvntTar)

            Else

                Call MsgBox("数字項目に数字以外の値が入っています。", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, GC_ERR_TITLE)

            End If

        End If

    End Function
    '******************************************************************************
    ' 関 数 名  : mfncGetLowRank
    ' スコープ  : Private
    ' 処理内容  : 最下位ランク 取得
    ' 備　　考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjDB              Object            O     データベース
    '   pstrRank            String            O     ランク
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  廣井　芳明     　　新規作成
    '
    '******************************************************************************
    Private Function mfncGetLowRank(ByRef pobjDB As Object, ByRef pstrRank As String) As Boolean

        '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "mfncGetLowRank"
        Dim strSQL As String
        Dim objDys権限設定テーブル As Object
        '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "mfncGetLowRank"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDys権限設定テーブル As Object
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（異常終了)
            mfncGetLowRank = True

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    MAX(ランク) AS ランク "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    権限設定テーブル "

            'UPGRADE_WARNING: オブジェクト pobjDB.CreateDynaset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            objDys権限設定テーブル = pobjDB.CreateDynaset(strSQL, &H4)

            With objDys権限設定テーブル

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: オブジェクト objDys権限設定テーブル.EOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If .EOF = False Then

                    ' 戻り値を設定（正常終了)
                    mfncGetLowRank = False

                    'UPGRADE_WARNING: オブジェクト objDys権限設定テーブル.Fields の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト mfncFieldVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pstrRank = mfncFieldVal(.Fields("ランク").Value)

                    'UPGRADE_WARNING: オブジェクト objDys権限設定テーブル.Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call .Close()

                End If

            End With

            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:08373125-1912-42ee-b05a-045cfe5f44a7
            'PROC_END:

            'UPGRADE_NOTE: オブジェクト objDys権限設定テーブル をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
            'objDys権限設定テーブル = Nothing

            'Exit Function

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:08373125-1912-42ee-b05a-045cfe5f44a7
        Catch ex As Exception
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e
            'Resume PROC_END
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e
PROC_FINALLY_END:
        objDys権限設定テーブル = Nothing
        Exit Function
        '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e
        '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Class

