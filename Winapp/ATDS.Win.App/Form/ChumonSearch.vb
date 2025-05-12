Imports ATDS
Imports ATDS.Business
Imports ATDS.Business.Entity
Imports ATDS.Common


Public Class ChumonSearch

#Region "【Enum】"
    
#End Region

#Region "Private properties"
    Private _SelectData As New ChumonUIInfo
#End Region

#Region "【プロパティ】 選択情報 "
    Public ReadOnly Property SelectData() As ChumonUIInfo
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
    End Sub
#End Region

#Region "【メソッド】 項目初期化"

    Private Sub Init()
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
        With MseDataGrid
            .Rows.Clear()
            .DataSource = Nothing
        End With

        Me._SelectData = Nothing
    End Sub
#End Region

#Region "【メソッド】 "
    Private Function GetDataFromScreen() As ChumonUIFilterInfo
        Try
            Dim chumonSearchInfo As New ChumonUIFilterInfo
            If String.IsNullOrEmpty(numChumonId.Text) = False Then chumonSearchInfo.ChumonId = numChumonId.Text
            If String.IsNullOrEmpty(txtChumonNo.Text) = False Then chumonSearchInfo.ChumonNo = txtChumonNo.Text
            If String.IsNullOrEmpty(dteChumonDate.Text) = False Then chumonSearchInfo.ChumonDate = dteChumonDate.Text
            If String.IsNullOrEmpty(txtHojinCode.Text) = False Then chumonSearchInfo.HojinCode = txtHojinCode.Text
            If String.IsNullOrEmpty(txtKonyuName.Text) = False Then chumonSearchInfo.KonyuName = txtKonyuName.Text
            If String.IsNullOrEmpty(txtKonyuMailAddress.Text) = False Then chumonSearchInfo.KonyuMailAddress = txtKonyuMailAddress.Text
            If String.IsNullOrEmpty(txtKonyuTantosha.Text) = False Then chumonSearchInfo.KonyuTantosha = txtKonyuTantosha.Text
            If String.IsNullOrEmpty(numKonyuKingaku1.Text) = False Then chumonSearchInfo.KonyuKingaku1 = numKonyuKingaku1.Text
            If String.IsNullOrEmpty(numKonyuKingaku2.Text) = False Then chumonSearchInfo.KonyuKingaku2 = numKonyuKingaku2.Text
            If String.IsNullOrEmpty(numKonyuKingaku3.Text) = False Then chumonSearchInfo.KonyuKingaku3 = numKonyuKingaku3.Text
            If String.IsNullOrEmpty(numNebiki.Text) = False Then chumonSearchInfo.Nebiki = numNebiki.Text
            If String.IsNullOrEmpty(numSoryo.Text) = False Then chumonSearchInfo.Soryo = numSoryo.Text
            If String.IsNullOrEmpty(numZei1.Text) = False Then chumonSearchInfo.Zei1 = numZei1.Text
            If String.IsNullOrEmpty(numZeiRitsu1.Text) = False Then chumonSearchInfo.ZeiRitsu1 = numZeiRitsu1.Text
            If String.IsNullOrEmpty(numZei2.Text) = False Then chumonSearchInfo.Zei2 = numZei2.Text
            If String.IsNullOrEmpty(numZeiRitsu2.Text) = False Then chumonSearchInfo.ZeiRitsu2 = numZeiRitsu2.Text
            If String.IsNullOrEmpty(numZei3.Text) = False Then chumonSearchInfo.Zei3 = numZei3.Text
            If String.IsNullOrEmpty(numZeiRitsu3.Text) = False Then chumonSearchInfo.ZeiRitsu3 = numZeiRitsu3.Text
            If String.IsNullOrEmpty(numGokeiKingaku.Text) = False Then chumonSearchInfo.GokeiKingaku = numGokeiKingaku.Text
            If String.IsNullOrEmpty(numStatus.Text) = False Then chumonSearchInfo.Status = numStatus.Text
            If String.IsNullOrEmpty(numYukoFlag.Text) = False Then chumonSearchInfo.YukoFlag = numYukoFlag.Text
            If String.IsNullOrEmpty(txtLastUpdateUser.Text) = False Then chumonSearchInfo.LastUpdateUser = txtLastUpdateUser.Text
            If String.IsNullOrEmpty(dteLastUpdate.Text) = False Then chumonSearchInfo.LastUpdate = dteLastUpdate.Text
            If String.IsNullOrEmpty(txtLastUpdateProgram.Text) = False Then chumonSearchInfo.LastUpdateProgram = txtLastUpdateProgram.Text
            Return chumonSearchInfo
        Catch ex As Exception
            NLogHelper.LogError(ex.ToString())
        End Try
    End Function
#End Region

#Region "【メソッド】 SearchBtnClick"
    Private Sub SearchBtnClick()
        Dim business As New ChumonSearchBusiness
        Dim cls As New ChumonUIFilterInfo
        Dim lst As New List(Of ChumonUIInfo)

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

                For Each row As ChumonUIInfo In lst
                    .Rows.Add()
                    .Rows(MseDataGrid.RowCount - 1).Tag = row
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.CHUMON_ID).Value = row.ChumonId
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.CHUMON_NO).Value = row.ChumonNo
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.CHUMON_DATE).Value = row.ChumonDate
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.HOJIN_CODE).Value = row.HojinCode
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.KONYU_NAME).Value = row.KonyuName
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.KONYU_MAIL_ADDRESS).Value = row.KonyuMailAddress
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.KONYU_TANTOSHA).Value = row.KonyuTantosha
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.KONYU_KINGAKU1).Value = row.KonyuKingaku1
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.KONYU_KINGAKU2).Value = row.KonyuKingaku2
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.KONYU_KINGAKU3).Value = row.KonyuKingaku3
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.NEBIKI).Value = row.Nebiki
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.SORYO).Value = row.Soryo
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.ZEI1).Value = row.Zei1
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.ZEI_RITSU1).Value = row.ZeiRitsu1
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.ZEI2).Value = row.Zei2
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.ZEI_RITSU2).Value = row.ZeiRitsu2
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.ZEI3).Value = row.Zei3
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.ZEI_RITSU3).Value = row.ZeiRitsu3
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.GOKEI_KINGAKU).Value = row.GokeiKingaku
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.STATUS).Value = row.Status
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.YUKO_FLAG).Value = row.YukoFlag
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.LAST_UPDATE_USER).Value = row.LastUpdateUser
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.LAST_UPDATE).Value = row.LastUpdate
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_COL.LAST_UPDATE_PROGRAM).Value = row.LastUpdateProgram
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
        Dim business As New ChumonSearchBusiness
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
                    Me._SelectData = CType(.Rows(.SelectedRows(0).Index).Tag, ChumonUIInfo)
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

#Region "【Event】 ChumonSearch_Load"
    Private Sub ChumonSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

#Region "【Event】 ChumonSearch_KeyDown"
    Private Sub ChumonSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                    Me._SelectData = CType(MseDataGrid.Rows(e.RowIndex).Tag, ChumonUIInfo)
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
                    Me._SelectData = CType(MseDataGrid.Rows(e.RowIndex).Tag, ChumonUIInfo)
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