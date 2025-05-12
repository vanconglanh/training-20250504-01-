Imports System.Text.RegularExpressions
Imports ATDS.Business
Imports ATDS.Business.Entity
Imports ATDS.Common

Public Class ChumonMeisaiEntry

#Region "【フォーム上で使用する変数・定数】"
    Public Enum MODE
        INIT
        ADD
        UPDATE
    End Enum


#End Region
#Region "Private変数"
    Private _Mode As MODE = MODE.INIT
    Private _ChumonMeisaiSearchForm As New ChumonMeisaiSearch()
    Private _chumonMeisaiUIInfo As New ChumonMeisaiUIInfo
    Private _IsCancelValidate As Boolean = False
    Private _LastActiveControl As Control
    Private _CurPostCode As String
#End Region

#Region "WndProc"
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CLOSE As Integer = &H10

        If m.Msg = WM_CLOSE Then
            'TODO
            ' If Me.ActiveControl Is txtChumonMeisaiNo Or
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
            With numChumonMeisaiId
                .IsNeed = True
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "ChumonMeisaiId"
            End With

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
            
            With txtChumonMeisaiNo
                .MaxLength = 20
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "ChumonMeisaiNo"
            End With
            
            With txtShohinCode
                .MaxLength = 20
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "ShohinCode"
            End With
            
            With txtShohinName
                .MaxLength = 100
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "ShohinName"
            End With

            With numSuryo
                .IsNeed = True
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Suryo"
            End With

            With numTanka
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Tanka"
            End With

            With numKingaku
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Kingaku"
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

            With numZeiRitsu
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "ZeiRitsu"
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
            With numChumonMeisaiId
                .Clear()
            End With

            With numChumonId
                .Clear()
            End With
            
            With txtChumonMeisaiNo
                .Text = String.Empty
            End With
            
            With txtShohinCode
                .Text = String.Empty
            End With
            
            With txtShohinName
                .Text = String.Empty
            End With

            With numSuryo
                .Clear()
            End With

            With numTanka
                .Clear()
            End With

            With numKingaku
                .Clear()
            End With

            With numSoryo
                .Clear()
            End With

            With numZeiRitsu
                .Clear()
            End With

            With numGokeiKingaku
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



            'Set default column
            If (Not vboolModeNewFlag) Then

           
            With numChumonMeisaiId

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
            If String.IsNullOrEmpty(numChumonMeisaiId.Text) Then   
                MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonMeisaiId.MsgTitle),
                                My.Resources.UI_Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                numChumonMeisaiId.Focus()
                Return False
            End If      


            If (Not vBoolDelFlag) Then
                '--- ChumonMeisaiId
                If String.IsNullOrEmpty(numChumonMeisaiId.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonMeisaiId.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numChumonMeisaiId.Focus()
                    Return False
                End If      

                '--- ChumonId
                If String.IsNullOrEmpty(numChumonId.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonId.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numChumonId.Focus()
                    Return False
                End If      

                '--- ChumonMeisaiNo
                If String.IsNullOrEmpty(txtChumonMeisaiNo.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtChumonMeisaiNo.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtChumonMeisaiNo.Focus()
                    Return False
                End If      

                '--- ShohinCode
                If String.IsNullOrEmpty(txtShohinCode.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtShohinCode.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtShohinCode.Focus()
                    Return False
                End If      

                '--- ShohinName
                If String.IsNullOrEmpty(txtShohinName.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtShohinName.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtShohinName.Focus()
                    Return False
                End If      

                '--- Suryo
                If String.IsNullOrEmpty(numSuryo.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numSuryo.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numSuryo.Focus()
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
        'Check ChumonMeisaiId code value
        If (String.IsNullOrEmpty(numChumonMeisaiId.Text)) Then
            Return False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 CheckDeletedByKey"
    Private Function CheckDeletedByKey() As Boolean
        Dim business As New ChumonMeisaiSearchBusiness
        Dim bResult As Boolean = True

        Dim entity = business.SearchByKey(numChumonMeisaiId.Text)
        If entity IsNot Nothing and entity.YukoFlag = 9 Then
            bResult = True
        Else
            bResult = False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 GeyDataByKey"
    Private Function GeyDataByKey() As ChumonMeisaiUIInfo
        Dim business As New ChumonMeisaiEntryBusiness
        Dim cls As New ChumonMeisaiUIInfo

        cls = business.GetData(numChumonMeisaiId.Text)
        Return cls
    End Function
#End Region

#Region "【メソッド】 CheckChanged"
    Private Function CheckChanged() As Boolean
        If ( 
                Me._chumonMeisaiUIInfo.ChumonMeisaiId <> CDbl(IIF(String.IsNullOrEmpty(numChumonMeisaiId.Text),0,numChumonMeisaiId.Text))  OrElse
                Me._chumonMeisaiUIInfo.ChumonId <> CDbl(IIF(String.IsNullOrEmpty(numChumonId.Text),0,numChumonId.Text))  OrElse
                Me._chumonMeisaiUIInfo.ChumonMeisaiNo <> txtChumonMeisaiNo.Text  OrElse
                Me._chumonMeisaiUIInfo.ShohinCode <> txtShohinCode.Text  OrElse
                Me._chumonMeisaiUIInfo.ShohinName <> txtShohinName.Text  OrElse
                Me._chumonMeisaiUIInfo.Suryo <> CDbl(IIF(String.IsNullOrEmpty(numSuryo.Text),0,numSuryo.Text))  OrElse
                Me._chumonMeisaiUIInfo.Tanka <> CDbl(IIF(String.IsNullOrEmpty(numTanka.Text),0,numTanka.Text))  OrElse
                Me._chumonMeisaiUIInfo.Kingaku <> CDbl(IIF(String.IsNullOrEmpty(numKingaku.Text),0,numKingaku.Text))  OrElse
                Me._chumonMeisaiUIInfo.Soryo <> CDbl(IIF(String.IsNullOrEmpty(numSoryo.Text),0,numSoryo.Text))  OrElse
                Me._chumonMeisaiUIInfo.ZeiRitsu <> CDbl(IIF(String.IsNullOrEmpty(numZeiRitsu.Text),0,numZeiRitsu.Text))  OrElse
                Me._chumonMeisaiUIInfo.GokeiKingaku <> CDbl(IIF(String.IsNullOrEmpty(numGokeiKingaku.Text),0,numGokeiKingaku.Text))  OrElse
                Me._chumonMeisaiUIInfo.YukoFlag <> CDbl(IIF(String.IsNullOrEmpty(numYukoFlag.Text),0,numYukoFlag.Text))  OrElse
                Me._chumonMeisaiUIInfo.LastUpdateUser <> txtLastUpdateUser.Text  OrElse
                (Me._chumonMeisaiUIInfo.LastUpdate = Nothing AndAlso dteLastUpdate.Text <> "") OrElse (Me._ChumonMeisaiUIInfo.LastUpdate <> Nothing AndAlso Me._ChumonMeisaiUIInfo.LastUpdate <> dteLastUpdate.Text)  OrElse
                Me._chumonMeisaiUIInfo.LastUpdateProgram <> txtLastUpdateProgram.Text  OrElse 1 <> 0) Then
            Return True
        End If

        Return False
    End Function
#End Region

#Region "【メソッド】 SetIEnableItems"
    Private Sub SetIEnableItems()
        Select Case Me._Mode
            Case MODE.INIT
                numChumonMeisaiId.Enabled = True
            Case MODE.ADD
                numChumonMeisaiId.Enabled = True
                btnSave.Enabled = True
                btnDelete.Enabled = False
                btnClear.Enabled = True
                btnClose.Enabled = True
            Case MODE.UPDATE
                numChumonMeisaiId.Enabled = False
                btnClear.Enabled = True
                btnSave.Enabled = True
                btnDelete.Enabled = True
                btnClose.Enabled = True
        End Select
    End Sub
#End Region

#Region "【メソッド】 SaveBtnClick"
    Private Sub SaveBtnClick()
        Dim business As New ChumonMeisaiEntryBusiness
        Dim updateConfirm As DialogResult
        Dim ret As ReturnInfo
        Dim cls As New ChumonMeisaiUIInfo

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
            .ChumonMeisaiId = numChumonMeisaiId.Text
            .ChumonId = numChumonId.Text
            .ChumonMeisaiNo = txtChumonMeisaiNo.Text
            .ShohinCode = txtShohinCode.Text
            .ShohinName = txtShohinName.Text
            .Suryo = numSuryo.Text
            .Tanka = numTanka.Text
            .Kingaku = numKingaku.Text
            .Soryo = numSoryo.Text
            .ZeiRitsu = numZeiRitsu.Text
            .GokeiKingaku = numGokeiKingaku.Text
            .YukoFlag = numYukoFlag.Text
            .LastUpdateUser = txtLastUpdateUser.Text
            .LastUpdate = dteLastUpdate.Text
            .LastUpdateProgram = txtLastUpdateProgram.Text
        End With




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
        Me._chumonMeisaiUIInfo = cls

        '--- Set enabled items
        SetIEnableItems()

    End Sub
#End Region

#Region "【メソッド】 DeleteBtnClick"
    Private Sub DeleteBtnClick()
        Dim business As New ChumonMeisaiEntryBusiness
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
        ret = business.Delete(numChumonMeisaiId.Text,UIProcess.OSUser, UIProcess.Terminal)

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
            numChumonMeisaiId.Focus() 
 


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
            numChumonMeisaiId.Focus() 


    End Sub
#End Region

#Region "【メソッド】 CloseBtnClick"
    Private Sub CloseBtnClick()
        '--- Close windows
        Me.Close()
    End Sub
#End Region

#Region "【メソッド】 ChumonMeisaiEntry_Load"
    Private Sub ChumonMeisaiEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            numChumonMeisaiId.Focus() 



        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 ChumonMeisaiEntry_Closing"
    Private Sub ChumonMeisaiEntry_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
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

                Me._ChumonMeisaiSearchForm.Dispose()
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

    
#Region "【メソッド】 numChumonMeisaiIdKeyDown"
    Private Sub numChumonMeisaiId_KeyDown(sender As Object, e As KeyEventArgs) Handles numChumonMeisaiId.KeyDown

        Try
            If e.KeyCode = Keys.F3 Then             'F3: Event
                '--- Show search dialog
                Me._ChumonMeisaiSearchForm.ShowDialog()

                If (Not IsNothing(Me._ChumonMeisaiSearchForm.SelectData)) Then
                    '--- Clear current data
                    Init()

                    '--- Set code
                    numChumonMeisaiId.Text = CType(Me._ChumonMeisaiSearchForm.SelectData, ChumonMeisaiUIInfo).ChumonMeisaiId

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

#Region "【メソッド】 numChumonMeisaiId_Validating"
    Private Sub numChumonMeisaiId_Validating(sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numChumonMeisaiId.Validating
        Try
            If Me._IsCancelValidate Then Exit Try

            '--- Check value
             If (String.IsNullOrEmpty(numChumonMeisaiId.Text)) Then
                MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numChumonMeisaiId.MsgTitle), My.Resources.UI_Error,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 numChumonMeisaiId_Validated"
    Private Sub numChumonMeisaiId_Validated(sender As Object, ByVal e As EventArgs) Handles numChumonMeisaiId.Validated
        'Dim business As New ChumonMeisaiEntryBusiness
        Dim boolDel As New Boolean
        Dim cls As New ChumonMeisaiUIInfo

        Try
            'If key control is not input -> do nothing
            If CheckAllKeysInput() = False Then Return

            ' Check deleted Key 
            boolDel = CheckDeletedByKey()
            If (boolDel) Then
                '--- Show error message
                MessageBox.Show(String.Format(My.Resources.ERR_ExistedError, numChumonMeisaiId.MsgTitle),
                                My.Resources.UI_Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                '--- Set mode
                Me._Mode = MODE.INIT

                '--- init data
                Init()

                '--- Init focus
                numChumonMeisaiId.Focus()

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
                Me._chumonMeisaiUIInfo = cls

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

#Region "【メソッド】 ChumonMeisaiEntry_KeyDown"
    Private Sub ChumonMeisaiEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub SetEntryInfoToControl(ByVal info As ChumonMeisaiUIInfo)



        numChumonMeisaiId.Text = info.ChumonMeisaiId
        numChumonId.Text = info.ChumonId
        txtChumonMeisaiNo.Text = info.ChumonMeisaiNo
        txtShohinCode.Text = info.ShohinCode
        txtShohinName.Text = info.ShohinName
        numSuryo.Text = info.Suryo
        numTanka.Text = info.Tanka
        numKingaku.Text = info.Kingaku
        numSoryo.Text = info.Soryo
        numZeiRitsu.Text = info.ZeiRitsu
        numGokeiKingaku.Text = info.GokeiKingaku
        numYukoFlag.Text = info.YukoFlag
        txtLastUpdateUser.Text = info.LastUpdateUser
        dteLastUpdate.Text = info.LastUpdate
        txtLastUpdateProgram.Text = info.LastUpdateProgram

        'Set data for grid


    End Sub
#End Region
    
End Class