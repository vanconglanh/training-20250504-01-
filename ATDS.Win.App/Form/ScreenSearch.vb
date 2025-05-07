Imports ATDS
Imports ATDS.Business
Imports ATDS.Business.Info
Imports ATDS.Common


Public Class ScreenSearch

#Region "【Enum】"
    
#End Region

#Region "Private properties"
    Private _SelectData As New ScreenUIInfo
#End Region

#Region "【プロパティ】 選択情報 "
    Public ReadOnly Property SelectData() As ScreenUIInfo
        Get
            Return _SelectData
        End Get
    End Property
#End Region

#Region "【メソッド】 ProcessCmdKey"
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keydata As Keys) As Boolean

        If keydata = Keys.F5 Or keydata = Keys.F7 Or
           keydata = Keys.F9 Or keydata = Keys.F11 Or keydata = Keys.F12 Then
            OnKeyDown(New KeyEventArgs(keydata))
            ProcessCmdKey = True
        Else
            ProcessCmdKey = MyBase.ProcessCmdKey(msg, keydata)
        End If

    End Function
#End Region

#Region "【メソッド】 項目デザイン初期化"

    Private Sub InitDesign()
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
                .MaxLength = 50
                .ImeMode = ImeMode.On
                .IsNeed = True
                .MsgTitle = "Name"
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
    End Sub
#End Region

#Region "【メソッド】 項目初期化"

    Private Sub Init()
            With numId
                .Clear()
            End With            
            With txtCode
                .Text = String.Empty
            End With            
            With txtName
                .Text = String.Empty
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
        With MseDataGrid
            .Rows.Clear()
            .DataSource = Nothing
        End With

        Me._SelectData = Nothing
    End Sub
#End Region

#Region "【メソッド】 "
    Private Function GetDataFromScreen() As ScreenUIFilterInfo
        Try
            Dim chumonSearchInfo As New ScreenUIFilterInfo
            If String.IsNullOrEmpty(numId.Text) = False Then chumonSearchInfo.Id = numId.Text
            If String.IsNullOrEmpty(txtCode.Text) = False Then chumonSearchInfo.Code = txtCode.Text
            If String.IsNullOrEmpty(txtName.Text) = False Then chumonSearchInfo.Name = txtName.Text
            If String.IsNullOrEmpty(dteCreatedAt.Text) = False Then chumonSearchInfo.CreatedAt = dteCreatedAt.Text
            If String.IsNullOrEmpty(dteUpdatedAt.Text) = False Then chumonSearchInfo.UpdatedAt = dteUpdatedAt.Text
            If String.IsNullOrEmpty(txtYukoFlag.Text) = False Then chumonSearchInfo.YukoFlag = txtYukoFlag.Text
            If String.IsNullOrEmpty(numCreatedUser.Text) = False Then chumonSearchInfo.CreatedUser = numCreatedUser.Text
            If String.IsNullOrEmpty(numLastUpdateUser.Text) = False Then chumonSearchInfo.LastUpdateUser = numLastUpdateUser.Text
            If String.IsNullOrEmpty(txtLastUpdateProgram.Text) = False Then chumonSearchInfo.LastUpdateProgram = txtLastUpdateProgram.Text
            Return chumonSearchInfo
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString())
        End Try
    End Function
#End Region

#Region "【メソッド】 SearchBtnClick"
    Private Sub SearchBtnClick()
        Dim business As New ScreenSearchBusiness
        Dim cls As New ScreenUIFilterInfo
        Dim lst As New List(Of ScreenUIInfo)

        Try
            '--- Remove old data
            With MseDataGrid
                .Rows.Clear()
                .DataSource = Nothing
                .HorizontalScrollingOffset = 0
            End With

            '--- Search data
            lst = business.Search(GetDataFromScreen())

            If (lst.Count = 0) Then
                MessageBox.Show(My.Resources.ERR_NoData, My.Resources.UI_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            '--- Show data
            With MseDataGrid

                For Each row As ScreenUIInfo In lst
                    .Rows.Add()
                    .Rows(MseDataGrid.RowCount - 1).Tag = row
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.ID).Value = row.Id
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.CODE).Value = row.Code
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.NAME).Value = row.Name
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.CREATED_AT).Value = row.CreatedAt
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.UPDATED_AT).Value = row.UpdatedAt
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.YUKO_FLAG).Value = row.YukoFlag
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.CREATED_USER).Value = row.CreatedUser
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.LAST_UPDATE_USER).Value = row.LastUpdateUser
                    .Rows(MseDataGrid.RowCount - 1).Cells(SCREEN_COL.LAST_UPDATE_PROGRAM).Value = row.LastUpdateProgram
                Next

                .ClearSelection()
            End With

        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【メソッド】 OutputDataBtnClick"
    Private Sub OutputDataBtnClick()
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = String.Empty
        Dim strPath As String = String.Empty
        Dim business As New ScreenSearchBusiness
        Dim csv As New CSVOutput
        Dim data As Data.DataSet

        strPath = AppDomain.CurrentDomain.BaseDirectory
        strFileName = "\Output.csv"

        '--- Search data
        data = business.SearchDt(GetDataFromScreen())

        If data.Tables(0).Rows.Count = 0 Then
            MessageBox.Show(My.Resources.ERR_NoData, My.Resources.UI_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        With fd
            .Title = "ファイルを開くダイアログ"
            .InitialDirectory = "C:\"
            .Filter = "CSV Files (*.csv)|*.csv"
            .FilterIndex = 2
            .RestoreDirectory = True
            .CheckFileExists = False
            If .ShowDialog() = DialogResult.OK Then
                strPath = System.IO.Path.GetDirectoryName(fd.FileName)
                strFileName = System.IO.Path.GetFileName(fd.FileName)

                If Not String.IsNullOrEmpty(strPath) And Not String.IsNullOrEmpty(strFileName) Then
                    csv.SVOutputPath = strPath
                    csv.SVOutputFileNM = strFileName
                    csv.HeadAddFLG = False
                    csv.OverWriteFLG = True
                    csv.MakeCSV(data)

                    MessageBox.Show(My.Resources.MSG_OutputFinished, My.Resources.UI_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End With
    End Sub
#End Region

#Region "【メソッド】 SelectBtnClick"
    Private Sub SelectBtnClick()

        With MseDataGrid
            If (.SelectedRows.Count > 0) Then
                '--- Get selected record
                If (Not IsNothing(.Rows(.SelectedRows(0).Index).Tag)) Then
                    Me._SelectData = CType(.Rows(.SelectedRows(0).Index).Tag, ScreenUIInfo)
                End If

                '--- Close dialog
                Me.Close()
            End If
        End With

    End Sub
#End Region

#Region "【メソッド】 btnClearClick"
    Private Sub ClearBtnClick()
        '--- Init
        Init()
        '--- Set focus
        'TODO
        ' txtKeyword.Focus()
    End Sub
#End Region

#Region "【メソッド】 btnCloseClick"
    Private Sub CloseBtnClick()
        '--- Close dialog
        Me.Close()
    End Sub
#End Region

#Region "【Event】 ScreenSearch_Load"
    Private Sub ScreenSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            '--- コントロールデザイン初期化
            InitDesign()

            '--- 初期化
            Init()

            'TODO
            ' txtKeyword.Select()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

#Region "【Event】 btnSearch_Click"
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Try
            SearchBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

#Region "【Event】 btnOutputData_Click"
    Private Sub btnOutputData_Click(sender As Object, e As EventArgs) Handles btnDataOutput.Click
        Try
            OutputDataBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【Event】 btnSelect_Click"
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            SelectBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【Event】 btnClear_Click"
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        Try
            ClearBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

#Region "【Event】 btnClose_Click"
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Try
            CloseBtnClick()
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region

#Region "【Event】 ScreenSearch_KeyDown"
    Private Sub ScreenSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F5 Then             'F5:検索ボタン押下時
                SearchBtnClick()
            ElseIf e.KeyCode = Keys.F7 Then         'F7:データ出力ボタン押下時
                OutputDataBtnClick()
            ElseIf e.KeyCode = Keys.F9 Then         'F9:選択ボタン押下時
                SelectBtnClick()
            ElseIf e.KeyCode = Keys.F11 Then        'F11:クリアボタン押下時
                ClearBtnClick()
            ElseIf e.KeyCode = Keys.F12 Then        'F12:終了ボタン押下時
                CloseBtnClick()
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【Event】 MseDataGrid_CelClick"
    Private Sub MseDataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MseDataGrid.CellClick

        Try
            If (e.RowIndex >= 0) Then
                If (Not IsNothing(MseDataGrid.Rows(e.RowIndex).Tag)) Then
                    Me._SelectData = CType(MseDataGrid.Rows(e.RowIndex).Tag, ScreenUIInfo)
                End If
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "【Event】 MseDataGrid_CellDoubleClick"
    Private Sub MseDataGrid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MseDataGrid.CellDoubleClick

        Try
            If (e.RowIndex >= 0) Then
                If (Not IsNothing(MseDataGrid.Rows(e.RowIndex).Tag)) Then
                    Me._SelectData = CType(MseDataGrid.Rows(e.RowIndex).Tag, ScreenUIInfo)
                End If

                '--- Close dialog
                Me.Close()
            End If
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString)
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

End Class