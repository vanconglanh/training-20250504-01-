Imports System.Text.RegularExpressions
Imports ATDS.Business
Imports ATDS.Business.Entity
Imports ATDS.Common

Public Class ChumonEntry

#Region "【フォーム上で使用する変数・定数】"
    Public Enum MODE
        INIT
        ADD
        UPDATE
    End Enum


#End Region
#Region "Private変数"
    Private _Mode As MODE = MODE.INIT
    Private _ChumonSearchForm As New ChumonSearch()
    Private _chumonUIInfo As New ChumonUIInfo
    Private _IsCancelValidate As Boolean = False
    Private _LastActiveControl As Control
    Private _CurPostCode As String
#End Region

#Region "WndProc"
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CLOSE As Integer = &H10

        If m.Msg = WM_CLOSE Then
            'TODO
            ' If Me.ActiveControl Is txtChumonNo Or
            '    Me.ActiveControl Is txtLastName Or
            '    Me.ActiveControl Is txtFirstName Or
            '    Me.ActiveControl Is txtMailAddress Or
            '    Me.ActiveControl Is dteBirthday Then
            '     Me._LastActiveControl = Me.ActiveControl
            ' End If
            Me._LastActiveControl = Me.ActiveControl
            MyBase.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        End If

        MyBase.WndProc(m)
    End Sub
#End Region

#Region "【メソッド】 ProcessCmdKey"
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keydata As Keys) As Boolean

        If keydata = Keys.F9 Or keydata = Keys.F10 Or
           keydata = Keys.F11 Or keydata = Keys.F12 Then
            OnKeyDown(New KeyEventArgs(keydata))
            ProcessCmdKey = True
        Else
            ProcessCmdKey = MyBase.ProcessCmdKey(msg, keydata)
        End If

    End Function
#End Region

#Region "【メソッド】 項目デザイン初期化"
    Private Sub InitDesign()

        Try
            With numChumonId
                .IsNeed = True
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "ChumonId"
            End With
            
            With txtChumonNo
                .MaxLength = 20
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "ChumonNo"
            End With

            With dteChumonDate
                .ImeMode = ImeMode.Off
                .IsNeed = True
                .MsgTitle = "ChumonDate"
            End With
            
            With txtHojinCode
                .MaxLength = 20
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "HojinCode"
            End With
            
            With txtKonyuName
                .MaxLength = 100
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "KonyuName"
            End With
            
            With txtKonyuMailAddress
                .MaxLength = 100
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "KonyuMailAddress"
            End With
            
            With txtKonyuTantosha
                .MaxLength = 30
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "KonyuTantosha"
            End With

            With numKonyuKingaku1
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "KonyuKingaku1"
            End With

            With numKonyuKingaku2
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "KonyuKingaku2"
            End With

            With numKonyuKingaku3
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "KonyuKingaku3"
            End With

            With numNebiki
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Nebiki"
            End With

            With numSoryo
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Soryo"
            End With

            With numZei1
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Zei1"
            End With

            With numZeiRitsu1
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "ZeiRitsu1"
            End With

            With numZei2
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Zei2"
            End With

            With numZeiRitsu2
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "ZeiRitsu2"
            End With

            With numZei3
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Zei3"
            End With

            With numZeiRitsu3
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "ZeiRitsu3"
            End With

            With numGokeiKingaku
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "GokeiKingaku"
            End With

            With numStatus
                .IsNeed = True
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Status"
            End With

            With numYukoFlag
                .IsNeed = True
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "YukoFlag"
            End With
            
            With txtLastUpdateUser
                .MaxLength = 20
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "LastUpdateUser"
            End With

            With dteLastUpdate
                .ImeMode = ImeMode.Off
                .IsNeed = True
                .MsgTitle = "LastUpdate"
            End With
            
            With txtLastUpdateProgram
                .MaxLength = 60
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "LastUpdateProgram"
            End With


            btnClose.CausesValidation = False
            btnClear.CausesValidation = False

            Me.KeyPreview = True
            Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        Catch ex As Exception
            Throw
        Finally

        End Try

    End Sub
#End Region

#Region "【メソッド】 項目初期化"
    Private Sub Init(Optional ByVal vboolModeNewFlag As Boolean = False)
        Try
            With numChumonId
                .Clear()
            End With
            
            With txtChumonNo
                .Text = String.Empty
            End With

            With dteChumonDate
                .Text = String.Empty
            End With
            
            With txtHojinCode
                .Text = String.Empty
            End With
            
            With txtKonyuName
                .Text = String.Empty
            End With
            
            With txtKonyuMailAddress
                .Text = String.Empty
            End With
            
            With txtKonyuTantosha
                .Text = String.Empty
            End With

            With numKonyuKingaku1
                .Clear()
            End With

            With numKonyuKingaku2
                .Clear()
            End With

            With numKonyuKingaku3
                .Clear()
            End With

            With numNebiki
                .Clear()
            End With

            With numSoryo
                .Clear()
            End With

            With numZei1
                .Clear()
            End With

            With numZeiRitsu1
                .Clear()
            End With

            With numZei2
                .Clear()
            End With

            With numZeiRitsu2
                .Clear()
            End With

            With numZei3
                .Clear()
            End With

            With numZeiRitsu3
                .Clear()
            End With

            With numGokeiKingaku
                .Clear()
            End With

            With numStatus
                .Clear()
            End With

            With numYukoFlag
                .Clear()
            End With
            
            With txtLastUpdateUser
                .Text = String.Empty
            End With

            With dteLastUpdate
                .Text = String.Empty
            End With
            
            With txtLastUpdateProgram
                .Text = String.Empty
            End With


            With MseDataGridChumonMeisai
                .Rows.Clear()
                .DataSource = Nothing
                .ReadOnly = False
                .AllowUserToAddRows = True
                .Columns(CHUMON_MEISAI_COL.CHUMON_ID).Visible = False
                .Columns(CHUMON_MEISAI_COL.CHUMON_MEISAI_ID).Visible = False
            End With


            'Set default column
            If (Not vboolModeNewFlag) Then

           
            With numChumonId

                    .Text = String.Empty
                    .Select()
                End With
            End If

            Me._LastActiveControl = Nothing
            Me._IsCancelValidate = False
        Catch ex As Exception
            Throw
        Finally

        End Try
    End Sub
#End Region

#Region "【メソッド】 CheckItems"
    Private Function CheckItems(ByVal Optional vBoolDelFlag As Boolean = False) As Boolean

        Try
            '--- 
            If String.IsNullOrEmpty(numChumonId.Text) Then   
                MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonId.MsgTitle),
                                My.Resources.UI_Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                numChumonId.Focus()
                Return False
            End If      


            If (Not vBoolDelFlag) Then
                '--- ChumonId
                If String.IsNullOrEmpty(numChumonId.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonId.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numChumonId.Focus()
                    Return False
                End If      

                '--- ChumonNo
                If String.IsNullOrEmpty(txtChumonNo.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtChumonNo.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtChumonNo.Focus()
                    Return False
                End If      

                '--- ChumonDate
                If String.IsNullOrEmpty(dteChumonDate.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, dteChumonDate.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    dteChumonDate.Focus()
                    Return False
                End If      

                '--- HojinCode
                If String.IsNullOrEmpty(txtHojinCode.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtHojinCode.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtHojinCode.Focus()
                    Return False
                End If      

                '--- KonyuName
                If String.IsNullOrEmpty(txtKonyuName.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtKonyuName.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtKonyuName.Focus()
                    Return False
                End If      

                '--- KonyuMailAddress
                If String.IsNullOrEmpty(txtKonyuMailAddress.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtKonyuMailAddress.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtKonyuMailAddress.Focus()
                    Return False
                End If      

                '--- KonyuTantosha
                If String.IsNullOrEmpty(txtKonyuTantosha.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtKonyuTantosha.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtKonyuTantosha.Focus()
                    Return False
                End If      

                '--- Status
                If String.IsNullOrEmpty(numStatus.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numStatus.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numStatus.Focus()
                    Return False
                End If      

                '--- YukoFlag
                If String.IsNullOrEmpty(numYukoFlag.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numYukoFlag.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numYukoFlag.Focus()
                    Return False
                End If      

                '--- LastUpdateUser
                If String.IsNullOrEmpty(txtLastUpdateUser.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtLastUpdateUser.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtLastUpdateUser.Focus()
                    Return False
                End If      

                '--- LastUpdate
                If String.IsNullOrEmpty(dteLastUpdate.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, dteLastUpdate.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    dteLastUpdate.Focus()
                    Return False
                End If      

                '--- LastUpdateProgram
                If String.IsNullOrEmpty(txtLastUpdateProgram.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtLastUpdateProgram.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtLastUpdateProgram.Focus()
                    Return False
                End If      


                '--- Check Detail (Only First Table)

            For iRow = 1 To MseDataGridChumonMeisai.Rows.Count - 1
                With MseDataGridChumonMeisai.Rows(iRow - 1)
            
                    If String.IsNullOrEmpty(.Cells(CHUMON_MEISAI_COL.CHUMON_ID).Value) Then
                        MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, "ChumonMeisai - ChumonId"),
                        My.Resources.UI_Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Return False
                    End If                       

                    If String.IsNullOrEmpty(.Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_NO).Value) Then
                        MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, "ChumonMeisai - ChumonMeisaiNo"),
                        My.Resources.UI_Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Return False
                    End If                       

                    If String.IsNullOrEmpty(.Cells(CHUMON_MEISAI_COL.SHOHIN_CODE).Value) Then
                        MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, "ChumonMeisai - ShohinCode"),
                        My.Resources.UI_Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Return False
                    End If                       

                    If String.IsNullOrEmpty(.Cells(CHUMON_MEISAI_COL.SHOHIN_NAME).Value) Then
                        MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, "ChumonMeisai - ShohinName"),
                        My.Resources.UI_Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Return False
                    End If                       

                    If String.IsNullOrEmpty(.Cells(CHUMON_MEISAI_COL.SURYO).Value) Then
                        MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, "ChumonMeisai - Suryo"),
                        My.Resources.UI_Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Return False
                    End If                       

                    If String.IsNullOrEmpty(.Cells(CHUMON_MEISAI_COL.YUKO_FLAG).Value) Then
                        MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, "ChumonMeisai - YukoFlag"),
                        My.Resources.UI_Error,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                        Return False
                    End If                       
            
                End With
            Next            


            End If

            Return True

        Catch ex As Exception
            Throw
        End Try

    End Function
#End Region

#Region "【メソッド】 CheckAllKeysInput"
    Private Function CheckAllKeysInput() As Boolean
        Dim bResult As Boolean = True
        'Check ChumonId code value
        If (String.IsNullOrEmpty(numChumonId.Text)) Then
            Return False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 CheckDeletedByKey"
    Private Function CheckDeletedByKey() As Boolean
        Dim business As New ChumonSearchBusiness
        Dim bResult As Boolean = True

        Dim entity = business.SearchByKey(numChumonId.Text)
        If entity IsNot Nothing and entity.YukoFlag = 9 Then
            bResult = True
        Else
            bResult = False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 GeyDataByKey"
    Private Function GeyDataByKey() As ChumonUIInfo
        Dim business As New ChumonEntryBusiness
        Dim cls As New ChumonUIInfo

        cls = business.GetData(numChumonId.Text)
        Return cls
    End Function
#End Region

#Region "【メソッド】 CheckChanged"
    Private Function CheckChanged() As Boolean
        If ( 
                Me._chumonUIInfo.ChumonId <> CDbl(IIF(String.IsNullOrEmpty(numChumonId.Text),0,numChumonId.Text))  OrElse
                Me._chumonUIInfo.ChumonNo <> txtChumonNo.Text  OrElse
                (Me._chumonUIInfo.ChumonDate = Nothing AndAlso dteChumonDate.Text <> "") OrElse (Me._ChumonUIInfo.ChumonDate <> Nothing AndAlso Me._ChumonUIInfo.ChumonDate <> dteChumonDate.Text)  OrElse
                Me._chumonUIInfo.HojinCode <> txtHojinCode.Text  OrElse
                Me._chumonUIInfo.KonyuName <> txtKonyuName.Text  OrElse
                Me._chumonUIInfo.KonyuMailAddress <> txtKonyuMailAddress.Text  OrElse
                Me._chumonUIInfo.KonyuTantosha <> txtKonyuTantosha.Text  OrElse
                Me._chumonUIInfo.KonyuKingaku1 <> CDbl(IIF(String.IsNullOrEmpty(numKonyuKingaku1.Text),0,numKonyuKingaku1.Text))  OrElse
                Me._chumonUIInfo.KonyuKingaku2 <> CDbl(IIF(String.IsNullOrEmpty(numKonyuKingaku2.Text),0,numKonyuKingaku2.Text))  OrElse
                Me._chumonUIInfo.KonyuKingaku3 <> CDbl(IIF(String.IsNullOrEmpty(numKonyuKingaku3.Text),0,numKonyuKingaku3.Text))  OrElse
                Me._chumonUIInfo.Nebiki <> CDbl(IIF(String.IsNullOrEmpty(numNebiki.Text),0,numNebiki.Text))  OrElse
                Me._chumonUIInfo.Soryo <> CDbl(IIF(String.IsNullOrEmpty(numSoryo.Text),0,numSoryo.Text))  OrElse
                Me._chumonUIInfo.Zei1 <> CDbl(IIF(String.IsNullOrEmpty(numZei1.Text),0,numZei1.Text))  OrElse
                Me._chumonUIInfo.ZeiRitsu1 <> CDbl(IIF(String.IsNullOrEmpty(numZeiRitsu1.Text),0,numZeiRitsu1.Text))  OrElse
                Me._chumonUIInfo.Zei2 <> CDbl(IIF(String.IsNullOrEmpty(numZei2.Text),0,numZei2.Text))  OrElse
                Me._chumonUIInfo.ZeiRitsu2 <> CDbl(IIF(String.IsNullOrEmpty(numZeiRitsu2.Text),0,numZeiRitsu2.Text))  OrElse
                Me._chumonUIInfo.Zei3 <> CDbl(IIF(String.IsNullOrEmpty(numZei3.Text),0,numZei3.Text))  OrElse
                Me._chumonUIInfo.ZeiRitsu3 <> CDbl(IIF(String.IsNullOrEmpty(numZeiRitsu3.Text),0,numZeiRitsu3.Text))  OrElse
                Me._chumonUIInfo.GokeiKingaku <> CDbl(IIF(String.IsNullOrEmpty(numGokeiKingaku.Text),0,numGokeiKingaku.Text))  OrElse
                Me._chumonUIInfo.Status <> CDbl(IIF(String.IsNullOrEmpty(numStatus.Text),0,numStatus.Text))  OrElse
                Me._chumonUIInfo.YukoFlag <> CDbl(IIF(String.IsNullOrEmpty(numYukoFlag.Text),0,numYukoFlag.Text))  OrElse
                Me._chumonUIInfo.LastUpdateUser <> txtLastUpdateUser.Text  OrElse
                (Me._chumonUIInfo.LastUpdate = Nothing AndAlso dteLastUpdate.Text <> "") OrElse (Me._ChumonUIInfo.LastUpdate <> Nothing AndAlso Me._ChumonUIInfo.LastUpdate <> dteLastUpdate.Text)  OrElse
                Me._chumonUIInfo.LastUpdateProgram <> txtLastUpdateProgram.Text  OrElse 1 <> 0) Then
            Return True
        End If

        Return False
    End Function
#End Region

#Region "【メソッド】 SetIEnableItems"
    Private Sub SetIEnableItems()
        Select Case Me._Mode
            Case MODE.INIT
                numChumonId.Enabled = True
            Case MODE.ADD
                numChumonId.Enabled = True
                btnSave.Enabled = True
                btnDelete.Enabled = False
                btnClear.Enabled = True
                btnClose.Enabled = True
            Case MODE.UPDATE
                numChumonId.Enabled = False
                btnClear.Enabled = True
                btnSave.Enabled = True
                btnDelete.Enabled = True
                btnClose.Enabled = True
        End Select
    End Sub
#End Region

#Region "【メソッド】 SaveBtnClick"
    Private Sub SaveBtnClick()
        Dim business As New ChumonEntryBusiness
        Dim updateConfirm As DialogResult
        Dim ret As ReturnInfo
        Dim cls As New ChumonUIInfo
        Dim chumonMeisaiUIInfo As ChumonMeisaiUIInfo


        '--- Validate values
        If (Not CheckItems()) Then
            Return
        End If

        '--- Show update confirm message   
        updateConfirm = MessageBox.Show(My.Resources.MSG_RegistrationConfirm, My.Resources.UI_Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If (updateConfirm = DialogResult.Cancel) Then
            Return
        End If

        With cls
            .ChumonId = numChumonId.Text
            .ChumonNo = txtChumonNo.Text
            .ChumonDate = dteChumonDate.Text
            .HojinCode = txtHojinCode.Text
            .KonyuName = txtKonyuName.Text
            .KonyuMailAddress = txtKonyuMailAddress.Text
            .KonyuTantosha = txtKonyuTantosha.Text
            .KonyuKingaku1 = numKonyuKingaku1.Text
            .KonyuKingaku2 = numKonyuKingaku2.Text
            .KonyuKingaku3 = numKonyuKingaku3.Text
            .Nebiki = numNebiki.Text
            .Soryo = numSoryo.Text
            .Zei1 = numZei1.Text
            .ZeiRitsu1 = numZeiRitsu1.Text
            .Zei2 = numZei2.Text
            .ZeiRitsu2 = numZeiRitsu2.Text
            .Zei3 = numZei3.Text
            .ZeiRitsu3 = numZeiRitsu3.Text
            .GokeiKingaku = numGokeiKingaku.Text
            .Status = numStatus.Text
            .YukoFlag = numYukoFlag.Text
            .LastUpdateUser = txtLastUpdateUser.Text
            .LastUpdate = dteLastUpdate.Text
            .LastUpdateProgram = txtLastUpdateProgram.Text
        End With


        For iRow = 0 To MseDataGridChumonMeisai.Rows.Count - 2
                 chumonMeisaiUIInfo = New ChumonMeisaiUIInfo()
            With chumonMeisaiUIInfo
            
                    .ChumonMeisaiId = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_ID).Value
                    .ChumonId = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.CHUMON_ID).Value
                    .ChumonMeisaiNo = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_NO).Value
                    .ShohinCode = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.SHOHIN_CODE).Value
                    .ShohinName = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.SHOHIN_NAME).Value
                    .Suryo = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.SURYO).Value
                    .Tanka = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.TANKA).Value
                    .Kingaku = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.KINGAKU).Value
                    .Soryo = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.SORYO).Value
                    .ZeiRitsu = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.ZEI_RITSU).Value
                    .GokeiKingaku = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.GOKEI_KINGAKU).Value
                    .YukoFlag = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.YUKO_FLAG).Value
                    .LastUpdateUser = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.LAST_UPDATE_USER).Value
                    .LastUpdate = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.LAST_UPDATE).Value
                    .LastUpdateProgram = MseDataGridChumonMeisai.Rows(iRow).Cells(CHUMON_MEISAI_COL.LAST_UPDATE_PROGRAM).Value             
                    cls.ChumonMeisaiList.Add(chumonMeisaiUIInfo)
            End With
        Next           



        '--- DB process
        If (Me._Mode = MODE.ADD) Then
            ret = business.Add(cls, UIProcess.OSUser, UIProcess.Terminal)
        Else
            ret = business.Update(cls, UIProcess.OSUser, UIProcess.Terminal)
        End If

        '--- Check return
        If (Not ret.State) Then
            '--- Show error message
            MessageBox.Show(ret.Message, My.Resources.UI_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            '--- Show delete completed message 
            MessageBox.Show(My.Resources.MSG_RegistrationCompleted, My.Resources.UI_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        '--- Set screen data
        Me._Mode = MODE.UPDATE
        Me._chumonUIInfo = cls

        '--- Set enabled items
        SetIEnableItems()

    End Sub
#End Region

#Region "【メソッド】 DeleteBtnClick"
    Private Sub DeleteBtnClick()
        Dim business As New ChumonEntryBusiness
        Dim delConfirm As DialogResult
        Dim ret As ATDS.Common.ReturnInfo

        '--- Validate values
        If (Not CheckItems(True)) Then
            Return
        End If

        '--- Show message confirm delete 
        delConfirm = MessageBox.Show(My.Resources.MSG_DeleteConfirm, My.Resources.UI_Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If (delConfirm = DialogResult.Cancel) Then
            Return
        End If
        '--- Delete process
        ret = business.Delete(numChumonId.Text,UIProcess.OSUser, UIProcess.Terminal)

        '--- Check return
        If (Not ret.State) Then
            '--- Show error message
            MessageBox.Show(ret.Message, My.Resources.UI_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            '--- Show delete completed message 
            MessageBox.Show(My.Resources.MSG_DeleteCompleted, My.Resources.UI_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        '--- Set screen data
        Me._Mode = MODE.INIT
        Me._CurPostCode = String.Empty

        '--- Init
        Init()

        '--- Set enabled items
        SetIEnableItems()

        '--- Set focus
            numChumonId.Focus() 
 


    End Sub
#End Region

#Region "【メソッド】 ClearBtnClick"
    Private Sub ClearBtnClick()
        '--- Init screen data
        Me._Mode = MODE.INIT
        Me._CurPostCode = String.Empty

        '--- Init
        Init()

        '---
        SetIEnableItems()

        '--- Set focus
            numChumonId.Focus() 


    End Sub
#End Region

#Region "【メソッド】 CloseBtnClick"
    Private Sub CloseBtnClick()
        '--- Close windows
        Me.Close()
    End Sub
#End Region

#Region "【メソッド】 ChumonEntry_Load"
    Private Sub ChumonEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '---
            Me._Mode = MODE.INIT

            '--- Init layout
            InitDesign()

            '--- init this screen
            Init()

            '--- set active for control
            SetIEnableItems()

            '--- Set focus for control
            numChumonId.Focus() 



        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 ChumonEntry_Closing"
    Private Sub ChumonEntry_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        Dim confirmResult As DialogResult

        Try
            If e.CloseReason = CloseReason.UserClosing Then
                '--- Cancel all control's validate
                Me._IsCancelValidate = True

                If ((Me._Mode = MODE.ADD Or Me._Mode = MODE.UPDATE) And CheckChanged()) Then
                    '--- Show message confirm clear
                    confirmResult = MessageBox.Show(My.Resources.MSG_CloseConfirm, My.Resources.UI_Confirmation,
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                    '--- Clear confirm
                    If (confirmResult = DialogResult.Cancel) Then
                        If Not IsNothing(Me._LastActiveControl) Then
                            Me._LastActiveControl.Focus()
                        End If
                        '--- Enable all control's validate
                        Me._IsCancelValidate = False
                        Me.AutoValidate = AutoValidate.EnablePreventFocusChange
                        e.Cancel = True
                        Return
                    End If
                End If

                Me._ChumonSearchForm.Dispose()
            End If

        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 btnSave_Click"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            SaveBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 btnDelete_Click"
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If (Me._Mode = MODE.UPDATE) Then
                DeleteBtnClick()
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 btnClear_Click"
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim confirmResult As DialogResult

        Try
            '--- Cancel all control's validate
            Me._IsCancelValidate = True

            If ((Me._Mode = MODE.ADD Or Me._Mode = MODE.UPDATE) And CheckChanged()) Then
                '--- Show message confirm clear
                confirmResult = MessageBox.Show(My.Resources.MSG_ClearConfirm, My.Resources.UI_Confirmation,
                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                '--- Clear confirm
                If (confirmResult = DialogResult.Cancel) Then
                    If Not IsNothing(Me._LastActiveControl) Then
                        Me._LastActiveControl.Focus()
                    End If
                    '--- Enable all control's validate
                    Me._IsCancelValidate = False
                    Return
                End If
            End If

            ClearBtnClick()

            '--- Enable all control's validate
            Me._IsCancelValidate = False
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 btnClose_Click"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Try
            ''--- Cancel all control's validate
            'Me._IsCancelValidate = True

            'If ((Me._Mode = MODE.ADD Or Me._Mode = MODE.UPDATE) And CheckChanged()) Then
            '    '--- Show message confirm clear
            '    confirmResult = MessageBox.Show(My.Resources.MSG_ClearConfirm, My.Resources.UI_Confirmation,
            '                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            '    '--- Clear confirm
            '    If (confirmResult = DialogResult.Cancel) Then
            '        If Not IsNothing(Me._LastActiveControl) Then
            '            Me._LastActiveControl.Focus()
            '        End If
            '        '--- Enable all control's validate
            '        Me._IsCancelValidate = False
            '        Return
            '    End If
            'End If

            CloseBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    
#Region "【メソッド】 numChumonIdKeyDown"
    Private Sub numChumonId_KeyDown(sender As Object, e As KeyEventArgs) Handles numChumonId.KeyDown

        Try
            If e.KeyCode = Keys.F3 Then             'F3: Event
                '--- Show search dialog
                Me._ChumonSearchForm.ShowDialog()

                If (Not IsNothing(Me._ChumonSearchForm.SelectData)) Then
                    '--- Clear current data
                    Init()

                    '--- Set code
                    numChumonId.Text = CType(Me._ChumonSearchForm.SelectData, ChumonUIInfo).ChumonId

                    '--- Tab to next control
                    SendKeys.Send("{TAB}")
                End If
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 numChumonId_Validating"
    Private Sub numChumonId_Validating(sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numChumonId.Validating
        Try
            If Me._IsCancelValidate Then Exit Try

            '--- Check value
             If (String.IsNullOrEmpty(numChumonId.Text)) Then
                MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonId.MsgTitle), My.Resources.UI_Error,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 numChumonId_Validated"
    Private Sub numChumonId_Validated(sender As Object, ByVal e As EventArgs) Handles numChumonId.Validated
        'Dim business As New ChumonEntryBusiness
        Dim boolDel As New Boolean
        Dim cls As New ChumonUIInfo

        Try
            'If key control is not input -> do nothing
            If CheckAllKeysInput() = False Then Return

            ' Check deleted Key 
            boolDel = CheckDeletedByKey()
            If (boolDel) Then
                '--- Show error message
                MessageBox.Show(String.Format(My.Resources.ERR_ExistedError, numChumonId.MsgTitle),
                                My.Resources.UI_Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                '--- Set mode
                Me._Mode = MODE.INIT

                '--- init data
                Init()

                '--- Init focus
                numChumonId.Focus()

                Return
            End If

            ' Get data by Key
            cls = GeyDataByKey()

            '--- 
            Init(True)

            ' Check exist
            If (IsNothing(cls)) Then
                '--- Set entry mode
                Me._Mode = MODE.ADD

                '--- Save screen data
                Me._CurPostCode = String.Empty

            Else
                '--- Set entry mode
                Me._Mode = MODE.UPDATE

                '--- Set data
                SetEntryInfoToControl(cls)

                '--- Save screen data
                Me._chumonUIInfo = cls

                '--- Get 
                'TO_DO
            End If

            '---
            SetIEnableItems()

        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 ChumonEntry_KeyDown"
    Private Sub ChumonEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F9 Then             'F9: Key event
                If (Not btnSave.Enabled) Then
                    Return
                End If

                '--- Save process
                SaveBtnClick()
            ElseIf e.KeyCode = Keys.F10 Then        'F10: Key event
                If (Not btnDelete.Enabled) Then
                    Return
                End If

                '--- Delete process
                DeleteBtnClick()

            ElseIf e.KeyCode = Keys.F11 Then        'F11: Key event
                ClearBtnClick()

            ElseIf e.KeyCode = Keys.F12 Then        'F12: Key event
                CloseBtnClick()

            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region



#Region "Set EntryInfo to control"
    Private Sub SetEntryInfoToControl(ByVal info As ChumonUIInfo)


        '--- Remove old data
        With MseDataGridChumonMeisai
            .Rows.Clear()
            .HorizontalScrollingOffset = 0
        End With


        numChumonId.Text = info.ChumonId
        txtChumonNo.Text = info.ChumonNo
        dteChumonDate.Text = info.ChumonDate
        txtHojinCode.Text = info.HojinCode
        txtKonyuName.Text = info.KonyuName
        txtKonyuMailAddress.Text = info.KonyuMailAddress
        txtKonyuTantosha.Text = info.KonyuTantosha
        numKonyuKingaku1.Text = info.KonyuKingaku1
        numKonyuKingaku2.Text = info.KonyuKingaku2
        numKonyuKingaku3.Text = info.KonyuKingaku3
        numNebiki.Text = info.Nebiki
        numSoryo.Text = info.Soryo
        numZei1.Text = info.Zei1
        numZeiRitsu1.Text = info.ZeiRitsu1
        numZei2.Text = info.Zei2
        numZeiRitsu2.Text = info.ZeiRitsu2
        numZei3.Text = info.Zei3
        numZeiRitsu3.Text = info.ZeiRitsu3
        numGokeiKingaku.Text = info.GokeiKingaku
        numStatus.Text = info.Status
        numYukoFlag.Text = info.YukoFlag
        txtLastUpdateUser.Text = info.LastUpdateUser
        dteLastUpdate.Text = info.LastUpdate
        txtLastUpdateProgram.Text = info.LastUpdateProgram

        'Set data for grid

        With MseDataGridChumonMeisai
            '--- Add new data
            For Each chumonMeisai In info.ChumonMeisaiList
                .Rows.Add()                
                .Rows(.RowCount - 2).Tag = chumonMeisai
        
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_ID).Value = chumonMeisai.ChumonMeisaiId
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.CHUMON_ID).Value = chumonMeisai.ChumonId
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_NO).Value = chumonMeisai.ChumonMeisaiNo
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.SHOHIN_CODE).Value = chumonMeisai.ShohinCode
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.SHOHIN_NAME).Value = chumonMeisai.ShohinName
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.SURYO).Value = chumonMeisai.Suryo
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.TANKA).Value = chumonMeisai.Tanka
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.KINGAKU).Value = chumonMeisai.Kingaku
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.SORYO).Value = chumonMeisai.Soryo
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.ZEI_RITSU).Value = chumonMeisai.ZeiRitsu
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.GOKEI_KINGAKU).Value = chumonMeisai.GokeiKingaku
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.YUKO_FLAG).Value = chumonMeisai.YukoFlag
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.LAST_UPDATE_USER).Value = chumonMeisai.LastUpdateUser
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.LAST_UPDATE).Value = chumonMeisai.LastUpdate
                .Rows(.RowCount - 2).Cells(CHUMON_MEISAI_COL.LAST_UPDATE_PROGRAM).Value = chumonMeisai.LastUpdateProgram             
            Next
            .Refresh()
            .ClearSelection()
        End With      


    End Sub
#End Region
    
End Class