Imports ATDS
Imports ATDS.Business
Imports ATDS.Business.Entity
Imports ATDS.Common


Public Class ChumonMeisaiSearch

#Region "【Enum】"
    
#End Region

#Region "Private properties"
    Private _SelectData As New ChumonMeisaiUIInfo
#End Region

#Region "【プロパティ】 選択情報 "
    Public ReadOnly Property SelectData() As ChumonMeisaiUIInfo
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
    End Sub
#End Region

#Region "【メソッド】 項目初期化"

    Private Sub Init()
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
        With MseDataGrid
            .Rows.Clear()
            .DataSource = Nothing
        End With

        Me._SelectData = Nothing
    End Sub
#End Region

#Region "【メソッド】 "
    Private Function GetDataFromScreen() As ChumonMeisaiUIFilterInfo
        Try
            Dim chumonSearchInfo As New ChumonMeisaiUIFilterInfo
            If String.IsNullOrEmpty(numChumonMeisaiId.Text) = False Then chumonSearchInfo.ChumonMeisaiId = numChumonMeisaiId.Text
            If String.IsNullOrEmpty(numChumonId.Text) = False Then chumonSearchInfo.ChumonId = numChumonId.Text
            If String.IsNullOrEmpty(txtChumonMeisaiNo.Text) = False Then chumonSearchInfo.ChumonMeisaiNo = txtChumonMeisaiNo.Text
            If String.IsNullOrEmpty(txtShohinCode.Text) = False Then chumonSearchInfo.ShohinCode = txtShohinCode.Text
            If String.IsNullOrEmpty(txtShohinName.Text) = False Then chumonSearchInfo.ShohinName = txtShohinName.Text
            If String.IsNullOrEmpty(numSuryo.Text) = False Then chumonSearchInfo.Suryo = numSuryo.Text
            If String.IsNullOrEmpty(numTanka.Text) = False Then chumonSearchInfo.Tanka = numTanka.Text
            If String.IsNullOrEmpty(numKingaku.Text) = False Then chumonSearchInfo.Kingaku = numKingaku.Text
            If String.IsNullOrEmpty(numSoryo.Text) = False Then chumonSearchInfo.Soryo = numSoryo.Text
            If String.IsNullOrEmpty(numZeiRitsu.Text) = False Then chumonSearchInfo.ZeiRitsu = numZeiRitsu.Text
            If String.IsNullOrEmpty(numGokeiKingaku.Text) = False Then chumonSearchInfo.GokeiKingaku = numGokeiKingaku.Text
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
        Dim business As New ChumonMeisaiSearchBusiness
        Dim cls As New ChumonMeisaiUIFilterInfo
        Dim lst As New List(Of ChumonMeisaiUIInfo)

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

                For Each row As ChumonMeisaiUIInfo In lst
                    .Rows.Add()
                    .Rows(MseDataGrid.RowCount - 1).Tag = row
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_ID).Value = row.ChumonMeisaiId
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.CHUMON_ID).Value = row.ChumonId
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.CHUMON_MEISAI_NO).Value = row.ChumonMeisaiNo
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.SHOHIN_CODE).Value = row.ShohinCode
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.SHOHIN_NAME).Value = row.ShohinName
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.SURYO).Value = row.Suryo
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.TANKA).Value = row.Tanka
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.KINGAKU).Value = row.Kingaku
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.SORYO).Value = row.Soryo
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.ZEI_RITSU).Value = row.ZeiRitsu
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.GOKEI_KINGAKU).Value = row.GokeiKingaku
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.YUKO_FLAG).Value = row.YukoFlag
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.LAST_UPDATE_USER).Value = row.LastUpdateUser
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.LAST_UPDATE).Value = row.LastUpdate
                    .Rows(MseDataGrid.RowCount - 1).Cells(CHUMON_MEISAI_COL.LAST_UPDATE_PROGRAM).Value = row.LastUpdateProgram
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
        Dim business As New ChumonMeisaiSearchBusiness
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
                    Me._SelectData = CType(.Rows(.SelectedRows(0).Index).Tag, ChumonMeisaiUIInfo)
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

#Region "【Event】 ChumonMeisaiSearch_Load"
    Private Sub ChumonMeisaiSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

#Region "【Event】 ChumonMeisaiSearch_KeyDown"
    Private Sub ChumonMeisaiSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                    Me._SelectData = CType(MseDataGrid.Rows(e.RowIndex).Tag, ChumonMeisaiUIInfo)
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
                    Me._SelectData = CType(MseDataGrid.Rows(e.RowIndex).Tag, ChumonMeisaiUIInfo)
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