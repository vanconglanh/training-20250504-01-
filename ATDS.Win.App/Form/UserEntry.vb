Imports System.Text.RegularExpressions
Imports ATDS.Business
Imports ATDS.Business.Info
Imports ATDS.Common

Public Class UserEntry

#Region "【フォーム上で使用する変数・定数】"
    Public Enum MODE
        INIT
        ADD
        UPDATE
    End Enum


#End Region
#Region "Private変数"
    Private _Mode As MODE = MODE.INIT
    Private _UserSearchForm As New UserSearch()
    Private _userUIInfo As New UserUIInfo
    Private _IsCancelValidate As Boolean = False
    Private _LastActiveControl As Control
    Private _CurPostCode As String
#End Region

#Region "WndProc"
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CLOSE As Integer = &H10

        If m.Msg = WM_CLOSE Then
            'TODO
            ' If Me.ActiveControl Is txtUserNo Or
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
            With numId
                .IsNeed = True
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "Id"
            End With
            
            With txtCode
                .MaxLength = 32
                .ImeMode = ImeMode.On
                .IsNeed = False
                .MsgTitle = "Code"
            End With
            
            With txtName
                .MaxLength = 255
                .ImeMode = ImeMode.Hiragana
                .IsNeed = True
                .MsgTitle = "Name"
            End With
            
            With txtEmail
                .MaxLength = 255
                .ImeMode = ImeMode.Hiragana
                .IsNeed = True
                .MsgTitle = "Email"
            End With
            
            With txtUserName
                .MaxLength = 255
                .ImeMode = ImeMode.Hiragana
                .IsNeed = True
                .MsgTitle = "UserName"
            End With
            
            With txtLanguage
                .MaxLength = 20
                .ImeMode = ImeMode.On
                .IsNeed = False
                .MsgTitle = "Language"
            End With
            
            With txtPassword
                .MaxLength = 255
                .ImeMode = ImeMode.Hiragana
                .IsNeed = True
                .MsgTitle = "Password"
            End With
            
            With txtPasswordHash
                .MaxLength = 255
                .ImeMode = ImeMode.Hiragana
                .IsNeed = True
                .MsgTitle = "PasswordHash"
            End With

            With numRoleId
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "RoleId"
            End With

            With dteCreatedAt
                .ImeMode = ImeMode.Off
                .IsNeed = False
                .MsgTitle = "CreatedAt"
            End With

            With dteUpdatedAt
                .ImeMode = ImeMode.Off
                .IsNeed = False
                .MsgTitle = "UpdatedAt"
            End With
            
            With txtYukoFlag
                .MaxLength = 1
                .ImeMode = ImeMode.On
                .IsNeed = False
                .MsgTitle = "YukoFlag"
            End With

            With numCreatedUser
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "CreatedUser"
            End With

            With numLastUpdateUser
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "LastUpdateUser"
            End With
            
            With txtLastUpdateProgram
                .MaxLength = 100
                .ImeMode = ImeMode.On
                .IsNeed = False
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
            With numId
                .Clear()
            End With
            
            With txtCode
                .Text = String.Empty
            End With
            
            With txtName
                .Text = String.Empty
            End With
            
            With txtEmail
                .Text = String.Empty
            End With
            
            With txtUserName
                .Text = String.Empty
            End With
            
            With txtLanguage
                .Text = String.Empty
            End With
            
            With txtPassword
                .Text = String.Empty
            End With
            
            With txtPasswordHash
                .Text = String.Empty
            End With

            With numRoleId
                .Clear()
            End With

            With dteCreatedAt
                .Text = String.Empty
            End With

            With dteUpdatedAt
                .Text = String.Empty
            End With
            
            With txtYukoFlag
                .Text = String.Empty
            End With

            With numCreatedUser
                .Clear()
            End With

            With numLastUpdateUser
                .Clear()
            End With
            
            With txtLastUpdateProgram
                .Text = String.Empty
            End With



            'Set default column
            If (Not vboolModeNewFlag) Then

           
            With numId

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
            If String.IsNullOrEmpty(numId.Text) Then   
                MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numId.MsgTitle),
                                My.Resources.UI_Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                numId.Focus()
                Return False
            End If      


            If (Not vBoolDelFlag) Then
                '--- Id
                If String.IsNullOrEmpty(numId.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numId.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    numId.Focus()
                    Return False
                End If      

                '--- Name
                If String.IsNullOrEmpty(txtName.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtName.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtName.Focus()
                    Return False
                End If      

                '--- Email
                If String.IsNullOrEmpty(txtEmail.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtEmail.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtEmail.Focus()
                    Return False
                End If      

                '--- UserName
                If String.IsNullOrEmpty(txtUserName.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtUserName.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtUserName.Focus()
                    Return False
                End If      

                '--- Password
                If String.IsNullOrEmpty(txtPassword.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtPassword.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtPassword.Focus()
                    Return False
                End If      

                '--- PasswordHash
                If String.IsNullOrEmpty(txtPasswordHash.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtPasswordHash.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtPasswordHash.Focus()
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
        'Check Id code value
        If (String.IsNullOrEmpty(numId.Text)) Then
            Return False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 CheckDeletedByKey"
    Private Function CheckDeletedByKey() As Boolean
        Dim business As New UserSearchBusiness
        Dim bResult As Boolean = True

        Dim entity = business.SearchByKey(numId.Text)
        If entity IsNot Nothing and entity.YukoFlag = 9 Then
            bResult = True
        Else
            bResult = False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 GeyDataByKey"
    Private Function GeyDataByKey() As UserUIInfo
        Dim business As New UserEntryBusiness
        Dim cls As New UserUIInfo

        cls = business.GetData(numId.Text)
        Return cls
    End Function
#End Region

#Region "【メソッド】 CheckChanged"
    Private Function CheckChanged() As Boolean
        If ( 
                Me._userUIInfo.Id <> CDbl(IIF(String.IsNullOrEmpty(numId.Text),0,numId.Text))  OrElse
                Me._userUIInfo.Code <> txtCode.Text  OrElse
                Me._userUIInfo.Name <> txtName.Text  OrElse
                Me._userUIInfo.Email <> txtEmail.Text  OrElse
                Me._userUIInfo.UserName <> txtUserName.Text  OrElse
                Me._userUIInfo.Language <> txtLanguage.Text  OrElse
                Me._userUIInfo.Password <> txtPassword.Text  OrElse
                Me._userUIInfo.PasswordHash <> txtPasswordHash.Text  OrElse
                Me._userUIInfo.RoleId <> CDbl(IIF(String.IsNullOrEmpty(numRoleId.Text),0,numRoleId.Text))  OrElse
                (Me._userUIInfo.CreatedAt Is Nothing AndAlso dteCreatedAt.Text <> "") OrElse (Me._UserUIInfo.CreatedAt IsNot Nothing AndAlso Me._UserUIInfo.CreatedAt <> dteCreatedAt.Text)  OrElse
                (Me._userUIInfo.UpdatedAt Is Nothing AndAlso dteUpdatedAt.Text <> "") OrElse (Me._UserUIInfo.UpdatedAt IsNot Nothing AndAlso Me._UserUIInfo.UpdatedAt <> dteUpdatedAt.Text)  OrElse
                Me._userUIInfo.YukoFlag <> txtYukoFlag.Text  OrElse
                Me._userUIInfo.CreatedUser <> CDbl(IIF(String.IsNullOrEmpty(numCreatedUser.Text),0,numCreatedUser.Text))  OrElse
                Me._userUIInfo.LastUpdateUser <> CDbl(IIF(String.IsNullOrEmpty(numLastUpdateUser.Text),0,numLastUpdateUser.Text))  OrElse
                Me._userUIInfo.LastUpdateProgram <> txtLastUpdateProgram.Text  OrElse 1 <> 0) Then
            Return True
        End If

        Return False
    End Function
#End Region

#Region "【メソッド】 SetIEnableItems"
    Private Sub SetIEnableItems()
        Select Case Me._Mode
            Case MODE.INIT
                numId.Enabled = True
            Case MODE.ADD
                numId.Enabled = True
                btnSave.Enabled = True
                btnDelete.Enabled = False
                btnClear.Enabled = True
                btnClose.Enabled = True
            Case MODE.UPDATE
                numId.Enabled = False
                btnClear.Enabled = True
                btnSave.Enabled = True
                btnDelete.Enabled = True
                btnClose.Enabled = True
        End Select
    End Sub
#End Region

#Region "【メソッド】 SaveBtnClick"
    Private Sub SaveBtnClick()
        Dim business As New UserEntryBusiness
        Dim updateConfirm As DialogResult
        Dim ret As ReturnInfo
        Dim cls As New UserUIInfo

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
            .Id = numId.Text
            .Code = txtCode.Text
            .Name = txtName.Text
            .Email = txtEmail.Text
            .UserName = txtUserName.Text
            .Language = txtLanguage.Text
            .Password = txtPassword.Text
            .PasswordHash = txtPasswordHash.Text
            .RoleId = numRoleId.Text
            .CreatedAt = dteCreatedAt.Text
            .UpdatedAt = dteUpdatedAt.Text
            .YukoFlag = txtYukoFlag.Text
            .CreatedUser = numCreatedUser.Text
            .LastUpdateUser = numLastUpdateUser.Text
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
        Me._userUIInfo = cls

        '--- Set enabled items
        SetIEnableItems()

    End Sub
#End Region

#Region "【メソッド】 DeleteBtnClick"
    Private Sub DeleteBtnClick()
        Dim business As New UserEntryBusiness
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
        ret = business.Delete(numId.Text,UIProcess.OSUser, UIProcess.Terminal)

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
            numId.Focus() 
 


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
            numId.Focus() 


    End Sub
#End Region

#Region "【メソッド】 CloseBtnClick"
    Private Sub CloseBtnClick()
        '--- Close windows
        Me.Close()
    End Sub
#End Region

#Region "【メソッド】 UserEntry_Load"
    Private Sub UserEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            numId.Focus() 



        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 UserEntry_Closing"
    Private Sub UserEntry_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
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

                Me._UserSearchForm.Dispose()
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

    
#Region "【メソッド】 numIdKeyDown"
    Private Sub numId_KeyDown(sender As Object, e As KeyEventArgs) Handles numId.KeyDown

        Try
            If e.KeyCode = Keys.F3 Then             'F3: Event
                '--- Show search dialog
                Me._UserSearchForm.ShowDialog()

                If (Not IsNothing(Me._UserSearchForm.SelectData)) Then
                    '--- Clear current data
                    Init()

                    '--- Set code
                    numId.Text = CType(Me._UserSearchForm.SelectData, UserUIInfo).Id

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

#Region "【メソッド】 numUserId_Validating"
    Private Sub numId_Validating(sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles numId.Validating
        Try
            If Me._IsCancelValidate Then Exit Try

            '--- Check value
             If (String.IsNullOrEmpty(numId.Text)) Then
                MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, numId.MsgTitle), My.Resources.UI_Error,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 numId_Validated"
    Private Sub numId_Validated(sender As Object, ByVal e As EventArgs) Handles numId.Validated
        'Dim business As New UserEntryBusiness
        Dim boolDel As New Boolean
        Dim cls As New UserUIInfo

        Try
            'If key control is not input -> do nothing
            If CheckAllKeysInput() = False Then Return

            ' Check deleted Key 
            boolDel = CheckDeletedByKey()
            If (boolDel) Then
                '--- Show error message
                MessageBox.Show(String.Format(My.Resources.ERR_ExistedError, numId.MsgTitle),
                                My.Resources.UI_Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                '--- Set mode
                Me._Mode = MODE.INIT

                '--- init data
                Init()

                '--- Init focus
                numId.Focus()

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
                Me._userUIInfo = cls

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

#Region "【メソッド】 UserEntry_KeyDown"
    Private Sub UserEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub SetEntryInfoToControl(ByVal info As UserUIInfo)



        numId.Text = info.Id
        txtCode.Text = info.Code
        txtName.Text = info.Name
        txtEmail.Text = info.Email
        txtUserName.Text = info.UserName
        txtLanguage.Text = info.Language
        txtPassword.Text = info.Password
        txtPasswordHash.Text = info.PasswordHash
        numRoleId.Text = info.RoleId
        dteCreatedAt.Text = info.CreatedAt
        dteUpdatedAt.Text = info.UpdatedAt
        txtYukoFlag.Text = info.YukoFlag
        numCreatedUser.Text = info.CreatedUser
        numLastUpdateUser.Text = info.LastUpdateUser
        txtLastUpdateProgram.Text = info.LastUpdateProgram

        'Set data for grid


    End Sub
#End Region
    
End Class