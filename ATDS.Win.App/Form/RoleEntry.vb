Imports System.Text.RegularExpressions
Imports ATDS.Business
Imports ATDS.Business.Info
Imports ATDS.Common

Public Class RoleEntry

#Region "【フォーム上で使用する変数・定数】"
    Public Enum MODE
        INIT
        ADD
        UPDATE
    End Enum


#End Region
#Region "Private変数"
    Private _Mode As MODE = MODE.INIT
    Private _RoleSearchForm As New RoleSearch()
    Private _roleUIInfo As New RoleUIInfo
    Private _IsCancelValidate As Boolean = False
    Private _LastActiveControl As Control
    Private _CurPostCode As String
#End Region

#Region "WndProc"
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CLOSE As Integer = &H10

        If m.Msg = WM_CLOSE Then
            'TODO
            ' If Me.ActiveControl Is txtRoleNo Or
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
                .MaxLength = 30
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "Code"
            End With
            
            With txtName
                .MaxLength = 30
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "Name"
            End With

            With numIsSystem
                .IsNeed = False
                .IsIndicate = True
                .ReadOnly = False
                ' .MaxValue = ###COLUMN_ITEM_VALUE_MAX###
                ' .MinValue = ###COLUMN_ITEM_VALUE_MIN###
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.LightGoldenrodYellow
                .MsgTitle = "IsSystem"
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

            With numIsSystem
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


            With MseDataGridUser
                .Rows.Clear()
                .DataSource = Nothing
                .ReadOnly = False
                .AllowUserToAddRows = True
                .Columns(USER_COL.ID).Visible = False
                .Columns(USER_COL.ID).Visible = False
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

                '--- Code
                If String.IsNullOrEmpty(txtCode.Text) Then   
                    MessageBox.Show(String.Format(My.Resources.ERR_RequiredCheck, txtCode.MsgTitle),
                                    My.Resources.UI_Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    txtCode.Focus()
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


                '--- Check Detail (Only First Table)

            For iRow = 1 To MseDataGridRolePermission.Rows.Count - 1
                With MseDataGridRolePermission.Rows(iRow - 1)
                        
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
        'Check Id code value
        If (String.IsNullOrEmpty(numId.Text)) Then
            Return False
        End If

        Return bResult
    End Function
#End Region

#Region "【メソッド】 CheckDeletedByKey"
    Private Function CheckDeletedByKey() As Boolean
        Dim business As New RoleSearchBusiness
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
    Private Function GeyDataByKey() As RoleUIInfo
        Dim business As New RoleEntryBusiness
        Dim cls As New RoleUIInfo

        cls = business.GetData(numId.Text)
        Return cls
    End Function
#End Region

#Region "【メソッド】 CheckChanged"
    Private Function CheckChanged() As Boolean
        If ( 
                Me._roleUIInfo.Id <> CDbl(IIF(String.IsNullOrEmpty(numId.Text),0,numId.Text))  OrElse
                Me._roleUIInfo.Code <> txtCode.Text  OrElse
                Me._roleUIInfo.Name <> txtName.Text  OrElse
                Me._roleUIInfo.IsSystem <> CDbl(IIF(String.IsNullOrEmpty(numIsSystem.Text),0,numIsSystem.Text))  OrElse
                (Me._roleUIInfo.CreatedAt Is Nothing AndAlso dteCreatedAt.Text <> "") OrElse (Me._RoleUIInfo.CreatedAt IsNot Nothing AndAlso Me._RoleUIInfo.CreatedAt <> dteCreatedAt.Text)  OrElse
                (Me._roleUIInfo.UpdatedAt Is Nothing AndAlso dteUpdatedAt.Text <> "") OrElse (Me._RoleUIInfo.UpdatedAt IsNot Nothing AndAlso Me._RoleUIInfo.UpdatedAt <> dteUpdatedAt.Text)  OrElse
                Me._roleUIInfo.YukoFlag <> txtYukoFlag.Text  OrElse
                Me._roleUIInfo.CreatedUser <> CDbl(IIF(String.IsNullOrEmpty(numCreatedUser.Text),0,numCreatedUser.Text))  OrElse
                Me._roleUIInfo.LastUpdateUser <> CDbl(IIF(String.IsNullOrEmpty(numLastUpdateUser.Text),0,numLastUpdateUser.Text))  OrElse
                Me._roleUIInfo.LastUpdateProgram <> txtLastUpdateProgram.Text  OrElse 1 <> 0) Then
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
        Dim business As New RoleEntryBusiness
        Dim updateConfirm As DialogResult
        Dim ret As ReturnInfo
        Dim cls As New RoleUIInfo
        Dim userUIInfo As UserUIInfo


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
            .IsSystem = numIsSystem.Text
            .CreatedAt = dteCreatedAt.Text
            .UpdatedAt = dteUpdatedAt.Text
            .YukoFlag = txtYukoFlag.Text
            .CreatedUser = numCreatedUser.Text
            .LastUpdateUser = numLastUpdateUser.Text
            .LastUpdateProgram = txtLastUpdateProgram.Text
        End With


        For iRow = 0 To MseDataGridRolePermission.Rows.Count - 2
                 rolePermissionUIInfo = New RolePermissionUIInfo()
            With rolePermissionUIInfo
            
                    .RoleId = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.ROLE_ID).Value
                    .PermissionScreenId = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.PERMISSION_SCREEN_ID).Value
                    .Code = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.CODE).Value
                    .CreatedAt = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.CREATED_AT).Value
                    .UpdatedAt = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.UPDATED_AT).Value
                    .YukoFlag = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.YUKO_FLAG).Value
                    .CreatedUser = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.CREATED_USER).Value
                    .LastUpdateUser = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.LAST_UPDATE_USER).Value
                    .LastUpdateProgram = MseDataGridRolePermission.Rows(iRow).Cells(ROLE_PERMISSION_COL.LAST_UPDATE_PROGRAM).Value             
                    cls.RolePermissionList.Add(rolePermissionUIInfo)
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
        Me._roleUIInfo = cls

        '--- Set enabled items
        SetIEnableItems()

    End Sub
#End Region

#Region "【メソッド】 DeleteBtnClick"
    Private Sub DeleteBtnClick()
        Dim business As New RoleEntryBusiness
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

#Region "【メソッド】 RoleEntry_Load"
    Private Sub RoleEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

#Region "【メソッド】 RoleEntry_Closing"
    Private Sub RoleEntry_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
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

                Me._RoleSearchForm.Dispose()
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
                Me._RoleSearchForm.ShowDialog()

                If (Not IsNothing(Me._RoleSearchForm.SelectData)) Then
                    '--- Clear current data
                    Init()

                    '--- Set code
                    numId.Text = CType(Me._RoleSearchForm.SelectData, RoleUIInfo).Id

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

#Region "【メソッド】 numRoleId_Validating"
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
        'Dim business As New RoleEntryBusiness
        Dim boolDel As New Boolean
        Dim cls As New RoleUIInfo

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
                Me._roleUIInfo = cls

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

#Region "【メソッド】 RoleEntry_KeyDown"
    Private Sub RoleEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub SetEntryInfoToControl(ByVal info As RoleUIInfo)


        '--- Remove old data
        With MseDataGridRolePermission
            .Rows.Clear()
            .HorizontalScrollingOffset = 0
        End With


        numId.Text = info.Id
        txtCode.Text = info.Code
        txtName.Text = info.Name
        numIsSystem.Text = info.IsSystem
        dteCreatedAt.Text = info.CreatedAt
        dteUpdatedAt.Text = info.UpdatedAt
        txtYukoFlag.Text = info.YukoFlag
        numCreatedUser.Text = info.CreatedUser
        numLastUpdateUser.Text = info.LastUpdateUser
        txtLastUpdateProgram.Text = info.LastUpdateProgram

        'Set data for grid

        With MseDataGridRolePermission
            '--- Add new data
            For Each rolePermission In info.RolePermissionList
                .Rows.Add()                
                .Rows(.RowCount - 2).Tag = rolePermission
        
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.ROLE_ID).Value = rolePermission.RoleId
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.PERMISSION_SCREEN_ID).Value = rolePermission.PermissionScreenId
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.CODE).Value = rolePermission.Code
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.CREATED_AT).Value = rolePermission.CreatedAt
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.UPDATED_AT).Value = rolePermission.UpdatedAt
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.YUKO_FLAG).Value = rolePermission.YukoFlag
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.CREATED_USER).Value = rolePermission.CreatedUser
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.LAST_UPDATE_USER).Value = rolePermission.LastUpdateUser
                .Rows(.RowCount - 2).Cells(ROLE_PERMISSION_COL.LAST_UPDATE_PROGRAM).Value = rolePermission.LastUpdateProgram             
            Next
            .Refresh()
            .ClearSelection()
        End With      


    End Sub
#End Region
    
End Class