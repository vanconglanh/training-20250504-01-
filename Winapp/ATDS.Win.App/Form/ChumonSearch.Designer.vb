Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChumonSearch
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChumonSearch))
        Me.lblTitle = New MSELabel()
        Me.btnClose = New MSEButton()
        Me.btnClear = New MSEButton()
        Me.btnSelect = New MSEButton()
        Me.btnDataOutput = New MSEButton()
        Me.btnSearch = New MSEButton()
        Me.MseDataGrid = New MSEDataGrid()
        '　ChumonId
        Me.lblChumonId = New MSELabel
        Me.numChumonId = New MSEEdit()
        Me.ColumnChumonId = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ChumonNo
        Me.lblChumonNo = New MSELabel
        Me.txtChumonNo = New MSEEdit()
        Me.ColumnChumonNo = New System.Windows.Forms.DataGridViewTextBoxColumn()

         '　ChumonDate
        Me.lblChumonDate = New MSELabel
        Me.dteChumonDate = New MSEDate()
        Me.ColumnChumonDate = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　HojinCode
        Me.lblHojinCode = New MSELabel
        Me.txtHojinCode = New MSEEdit()
        Me.ColumnHojinCode = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　KonyuName
        Me.lblKonyuName = New MSELabel
        Me.txtKonyuName = New MSEEdit()
        Me.ColumnKonyuName = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　KonyuMailAddress
        Me.lblKonyuMailAddress = New MSELabel
        Me.txtKonyuMailAddress = New MSEEdit()
        Me.ColumnKonyuMailAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　KonyuTantosha
        Me.lblKonyuTantosha = New MSELabel
        Me.txtKonyuTantosha = New MSEEdit()
        Me.ColumnKonyuTantosha = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　KonyuKingaku1
        Me.lblKonyuKingaku1 = New MSELabel
        Me.numKonyuKingaku1 = New MSEEdit()
        Me.ColumnKonyuKingaku1 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　KonyuKingaku2
        Me.lblKonyuKingaku2 = New MSELabel
        Me.numKonyuKingaku2 = New MSEEdit()
        Me.ColumnKonyuKingaku2 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　KonyuKingaku3
        Me.lblKonyuKingaku3 = New MSELabel
        Me.numKonyuKingaku3 = New MSEEdit()
        Me.ColumnKonyuKingaku3 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Nebiki
        Me.lblNebiki = New MSELabel
        Me.numNebiki = New MSEEdit()
        Me.ColumnNebiki = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Soryo
        Me.lblSoryo = New MSELabel
        Me.numSoryo = New MSEEdit()
        Me.ColumnSoryo = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Zei1
        Me.lblZei1 = New MSELabel
        Me.numZei1 = New MSEEdit()
        Me.ColumnZei1 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ZeiRitsu1
        Me.lblZeiRitsu1 = New MSELabel
        Me.numZeiRitsu1 = New MSEEdit()
        Me.ColumnZeiRitsu1 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Zei2
        Me.lblZei2 = New MSELabel
        Me.numZei2 = New MSEEdit()
        Me.ColumnZei2 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ZeiRitsu2
        Me.lblZeiRitsu2 = New MSELabel
        Me.numZeiRitsu2 = New MSEEdit()
        Me.ColumnZeiRitsu2 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Zei3
        Me.lblZei3 = New MSELabel
        Me.numZei3 = New MSEEdit()
        Me.ColumnZei3 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ZeiRitsu3
        Me.lblZeiRitsu3 = New MSELabel
        Me.numZeiRitsu3 = New MSEEdit()
        Me.ColumnZeiRitsu3 = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　GokeiKingaku
        Me.lblGokeiKingaku = New MSELabel
        Me.numGokeiKingaku = New MSEEdit()
        Me.ColumnGokeiKingaku = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Status
        Me.lblStatus = New MSELabel
        Me.numStatus = New MSEEdit()
        Me.ColumnStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　YukoFlag
        Me.lblYukoFlag = New MSELabel
        Me.numYukoFlag = New MSEEdit()
        Me.ColumnYukoFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　LastUpdateUser
        Me.lblLastUpdateUser = New MSELabel
        Me.txtLastUpdateUser = New MSEEdit()
        Me.ColumnLastUpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()

         '　LastUpdate
        Me.lblLastUpdate = New MSELabel
        Me.dteLastUpdate = New MSEDate()
        Me.ColumnLastUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　LastUpdateProgram
        Me.lblLastUpdateProgram = New MSELabel
        Me.txtLastUpdateProgram = New MSEEdit()
        Me.ColumnLastUpdateProgram = New System.Windows.Forms.DataGridViewTextBoxColumn()

        CType(Me.MseDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.lblTitle.Font = New System.Drawing.Font("Meiryo UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(370, 30)
        Me.lblTitle.TabIndex = 24
        Me.lblTitle.Text = "Chumon検索"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        
        'Generaete Init control
        Me.Controls.Add(Me.lblCHUMONID)
Me.Controls.Add(Me.numCHUMONID)
Me.Controls.Add(Me.lblCHUMONNO)
Me.Controls.Add(Me.txtCHUMONNO)
Me.Controls.Add(Me.lblCHUMONDATE)
Me.Controls.Add(Me.dteCHUMONDATE)
Me.Controls.Add(Me.lblHOJINCODE)
Me.Controls.Add(Me.txtHOJINCODE)
Me.Controls.Add(Me.lblKONYUNAME)
Me.Controls.Add(Me.txtKONYUNAME)
Me.Controls.Add(Me.lblKONYUMAILADDRESS)
Me.Controls.Add(Me.txtKONYUMAILADDRESS)
Me.Controls.Add(Me.lblKONYUTANTOSHA)
Me.Controls.Add(Me.txtKONYUTANTOSHA)
Me.Controls.Add(Me.lblKONYUKINGAKU1)
Me.Controls.Add(Me.numKONYUKINGAKU1)
Me.Controls.Add(Me.lblKONYUKINGAKU2)
Me.Controls.Add(Me.numKONYUKINGAKU2)
Me.Controls.Add(Me.lblKONYUKINGAKU3)
Me.Controls.Add(Me.numKONYUKINGAKU3)
Me.Controls.Add(Me.lblNEBIKI)
Me.Controls.Add(Me.numNEBIKI)
Me.Controls.Add(Me.lblSORYO)
Me.Controls.Add(Me.numSORYO)
Me.Controls.Add(Me.lblZEI1)
Me.Controls.Add(Me.numZEI1)
Me.Controls.Add(Me.lblZEIRITSU1)
Me.Controls.Add(Me.numZEIRITSU1)
Me.Controls.Add(Me.lblZEI2)
Me.Controls.Add(Me.numZEI2)
Me.Controls.Add(Me.lblZEIRITSU2)
Me.Controls.Add(Me.numZEIRITSU2)
Me.Controls.Add(Me.lblZEI3)
Me.Controls.Add(Me.numZEI3)
Me.Controls.Add(Me.lblZEIRITSU3)
Me.Controls.Add(Me.numZEIRITSU3)
Me.Controls.Add(Me.lblGOKEIKINGAKU)
Me.Controls.Add(Me.numGOKEIKINGAKU)
Me.Controls.Add(Me.lblSTATUS)
Me.Controls.Add(Me.numSTATUS)
Me.Controls.Add(Me.lblYUKOFLAG)
Me.Controls.Add(Me.numYUKOFLAG)
Me.Controls.Add(Me.lblLASTUPDATEUSER)
Me.Controls.Add(Me.txtLASTUPDATEUSER)
Me.Controls.Add(Me.lblLASTUPDATE)
Me.Controls.Add(Me.dteLASTUPDATE)
Me.Controls.Add(Me.lblLASTUPDATEPROGRAM)
Me.Controls.Add(Me.txtLASTUPDATEPROGRAM)
'
'lblCHUMONID
'
Me.lblCHUMONID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCHUMONID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCHUMONID.ForeColor = System.Drawing.Color.White
Me.lblCHUMONID.Location = New System.Drawing.Point(20, 60)
Me.lblCHUMONID.Name = "lblCHUMONID"
Me.lblCHUMONID.Size = New System.Drawing.Size(170, 24)
Me.lblCHUMONID.Text = "CHUMON_ID"
Me.lblCHUMONID.Enabled = True
'
'numCHUMONID
'
Me.numCHUMONID.BackColor = System.Drawing.Color.White
Me.numCHUMONID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numCHUMONID.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numCHUMONID.IsNextControl = True
Me.numCHUMONID.IsUseFunctionKey = False
Me.numCHUMONID.Location = New System.Drawing.Point(190, 60)
Me.numCHUMONID.Size = New System.Drawing.Size(200, 24)
Me.numCHUMONID.Name = "numCHUMONID"
Me.numCHUMONID.TabIndex = 0
Me.numCHUMONID.Enabled = True
'
'lblCHUMONNO
'
Me.lblCHUMONNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCHUMONNO.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCHUMONNO.ForeColor = System.Drawing.Color.White
Me.lblCHUMONNO.Location = New System.Drawing.Point(430, 60)
Me.lblCHUMONNO.Name = "lblCHUMONNO"
Me.lblCHUMONNO.Size = New System.Drawing.Size(170, 24)
Me.lblCHUMONNO.Text = "CHUMON_NO"
Me.lblCHUMONNO.Enabled = True
'
'txtCHUMONNO
'
Me.txtCHUMONNO.BackColor = System.Drawing.Color.White
Me.txtCHUMONNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtCHUMONNO.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtCHUMONNO.IsNextControl = True
Me.txtCHUMONNO.IsUseFunctionKey = False
Me.txtCHUMONNO.Location = New System.Drawing.Point(600, 60)
Me.txtCHUMONNO.Size = New System.Drawing.Size(200, 24)
Me.txtCHUMONNO.Name = "txtCHUMONNO"
Me.txtCHUMONNO.TabIndex = 1
Me.txtCHUMONNO.Enabled = True
'
'lblCHUMONDATE
'
Me.lblCHUMONDATE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCHUMONDATE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCHUMONDATE.ForeColor = System.Drawing.Color.White
Me.lblCHUMONDATE.Location = New System.Drawing.Point(840, 60)
Me.lblCHUMONDATE.Name = "lblCHUMONDATE"
Me.lblCHUMONDATE.Size = New System.Drawing.Size(170, 24)
Me.lblCHUMONDATE.Text = "CHUMON_DATE"
Me.lblCHUMONDATE.Enabled = True
'
'dteCHUMONDATE
'
Me.dteCHUMONDATE.BackColor = System.Drawing.Color.White
Me.dteCHUMONDATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteCHUMONDATE.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteCHUMONDATE.IsNextControl = True
Me.dteCHUMONDATE.IsUseFunctionKey = False
Me.dteCHUMONDATE.Location = New System.Drawing.Point(1010, 60)
Me.dteCHUMONDATE.Size = New System.Drawing.Size(200, 24)
Me.dteCHUMONDATE.Name = "dteCHUMONDATE"
Me.dteCHUMONDATE.TabIndex = 2
Me.dteCHUMONDATE.Enabled = True
'
'lblHOJINCODE
'
Me.lblHOJINCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblHOJINCODE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblHOJINCODE.ForeColor = System.Drawing.Color.White
Me.lblHOJINCODE.Location = New System.Drawing.Point(20, 94)
Me.lblHOJINCODE.Name = "lblHOJINCODE"
Me.lblHOJINCODE.Size = New System.Drawing.Size(170, 24)
Me.lblHOJINCODE.Text = "HOJIN_CODE"
Me.lblHOJINCODE.Enabled = True
'
'txtHOJINCODE
'
Me.txtHOJINCODE.BackColor = System.Drawing.Color.White
Me.txtHOJINCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtHOJINCODE.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtHOJINCODE.IsNextControl = True
Me.txtHOJINCODE.IsUseFunctionKey = False
Me.txtHOJINCODE.Location = New System.Drawing.Point(190, 94)
Me.txtHOJINCODE.Size = New System.Drawing.Size(200, 24)
Me.txtHOJINCODE.Name = "txtHOJINCODE"
Me.txtHOJINCODE.TabIndex = 3
Me.txtHOJINCODE.Enabled = True
'
'lblKONYUNAME
'
Me.lblKONYUNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKONYUNAME.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKONYUNAME.ForeColor = System.Drawing.Color.White
Me.lblKONYUNAME.Location = New System.Drawing.Point(430, 94)
Me.lblKONYUNAME.Name = "lblKONYUNAME"
Me.lblKONYUNAME.Size = New System.Drawing.Size(170, 24)
Me.lblKONYUNAME.Text = "KONYU_NAME"
Me.lblKONYUNAME.Enabled = True
'
'txtKONYUNAME
'
Me.txtKONYUNAME.BackColor = System.Drawing.Color.White
Me.txtKONYUNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtKONYUNAME.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtKONYUNAME.IsNextControl = True
Me.txtKONYUNAME.IsUseFunctionKey = False
Me.txtKONYUNAME.Location = New System.Drawing.Point(600, 94)
Me.txtKONYUNAME.Size = New System.Drawing.Size(200, 24)
Me.txtKONYUNAME.Name = "txtKONYUNAME"
Me.txtKONYUNAME.TabIndex = 4
Me.txtKONYUNAME.Enabled = True
'
'lblKONYUMAILADDRESS
'
Me.lblKONYUMAILADDRESS.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKONYUMAILADDRESS.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKONYUMAILADDRESS.ForeColor = System.Drawing.Color.White
Me.lblKONYUMAILADDRESS.Location = New System.Drawing.Point(840, 94)
Me.lblKONYUMAILADDRESS.Name = "lblKONYUMAILADDRESS"
Me.lblKONYUMAILADDRESS.Size = New System.Drawing.Size(170, 24)
Me.lblKONYUMAILADDRESS.Text = "KONYU_MAIL_ADDRESS"
Me.lblKONYUMAILADDRESS.Enabled = True
'
'txtKONYUMAILADDRESS
'
Me.txtKONYUMAILADDRESS.BackColor = System.Drawing.Color.White
Me.txtKONYUMAILADDRESS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtKONYUMAILADDRESS.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtKONYUMAILADDRESS.IsNextControl = True
Me.txtKONYUMAILADDRESS.IsUseFunctionKey = False
Me.txtKONYUMAILADDRESS.Location = New System.Drawing.Point(1010, 94)
Me.txtKONYUMAILADDRESS.Size = New System.Drawing.Size(200, 24)
Me.txtKONYUMAILADDRESS.Name = "txtKONYUMAILADDRESS"
Me.txtKONYUMAILADDRESS.TabIndex = 5
Me.txtKONYUMAILADDRESS.Enabled = True
'
'lblKONYUTANTOSHA
'
Me.lblKONYUTANTOSHA.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKONYUTANTOSHA.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKONYUTANTOSHA.ForeColor = System.Drawing.Color.White
Me.lblKONYUTANTOSHA.Location = New System.Drawing.Point(20, 128)
Me.lblKONYUTANTOSHA.Name = "lblKONYUTANTOSHA"
Me.lblKONYUTANTOSHA.Size = New System.Drawing.Size(170, 24)
Me.lblKONYUTANTOSHA.Text = "KONYU_TANTOSHA"
Me.lblKONYUTANTOSHA.Enabled = True
'
'txtKONYUTANTOSHA
'
Me.txtKONYUTANTOSHA.BackColor = System.Drawing.Color.White
Me.txtKONYUTANTOSHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtKONYUTANTOSHA.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtKONYUTANTOSHA.IsNextControl = True
Me.txtKONYUTANTOSHA.IsUseFunctionKey = False
Me.txtKONYUTANTOSHA.Location = New System.Drawing.Point(190, 128)
Me.txtKONYUTANTOSHA.Size = New System.Drawing.Size(200, 24)
Me.txtKONYUTANTOSHA.Name = "txtKONYUTANTOSHA"
Me.txtKONYUTANTOSHA.TabIndex = 6
Me.txtKONYUTANTOSHA.Enabled = True
'
'lblKONYUKINGAKU1
'
Me.lblKONYUKINGAKU1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKONYUKINGAKU1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKONYUKINGAKU1.ForeColor = System.Drawing.Color.White
Me.lblKONYUKINGAKU1.Location = New System.Drawing.Point(430, 128)
Me.lblKONYUKINGAKU1.Name = "lblKONYUKINGAKU1"
Me.lblKONYUKINGAKU1.Size = New System.Drawing.Size(170, 24)
Me.lblKONYUKINGAKU1.Text = "KONYU_KINGAKU1"
Me.lblKONYUKINGAKU1.Enabled = True
'
'numKONYUKINGAKU1
'
Me.numKONYUKINGAKU1.BackColor = System.Drawing.Color.White
Me.numKONYUKINGAKU1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKONYUKINGAKU1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKONYUKINGAKU1.IsNextControl = True
Me.numKONYUKINGAKU1.IsUseFunctionKey = False
Me.numKONYUKINGAKU1.Location = New System.Drawing.Point(600, 128)
Me.numKONYUKINGAKU1.Size = New System.Drawing.Size(200, 24)
Me.numKONYUKINGAKU1.Name = "numKONYUKINGAKU1"
Me.numKONYUKINGAKU1.TabIndex = 7
Me.numKONYUKINGAKU1.Enabled = True
'
'lblKONYUKINGAKU2
'
Me.lblKONYUKINGAKU2.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKONYUKINGAKU2.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKONYUKINGAKU2.ForeColor = System.Drawing.Color.White
Me.lblKONYUKINGAKU2.Location = New System.Drawing.Point(840, 128)
Me.lblKONYUKINGAKU2.Name = "lblKONYUKINGAKU2"
Me.lblKONYUKINGAKU2.Size = New System.Drawing.Size(170, 24)
Me.lblKONYUKINGAKU2.Text = "KONYU_KINGAKU2"
Me.lblKONYUKINGAKU2.Enabled = True
'
'numKONYUKINGAKU2
'
Me.numKONYUKINGAKU2.BackColor = System.Drawing.Color.White
Me.numKONYUKINGAKU2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKONYUKINGAKU2.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKONYUKINGAKU2.IsNextControl = True
Me.numKONYUKINGAKU2.IsUseFunctionKey = False
Me.numKONYUKINGAKU2.Location = New System.Drawing.Point(1010, 128)
Me.numKONYUKINGAKU2.Size = New System.Drawing.Size(200, 24)
Me.numKONYUKINGAKU2.Name = "numKONYUKINGAKU2"
Me.numKONYUKINGAKU2.TabIndex = 8
Me.numKONYUKINGAKU2.Enabled = True
'
'lblKONYUKINGAKU3
'
Me.lblKONYUKINGAKU3.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKONYUKINGAKU3.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKONYUKINGAKU3.ForeColor = System.Drawing.Color.White
Me.lblKONYUKINGAKU3.Location = New System.Drawing.Point(20, 162)
Me.lblKONYUKINGAKU3.Name = "lblKONYUKINGAKU3"
Me.lblKONYUKINGAKU3.Size = New System.Drawing.Size(170, 24)
Me.lblKONYUKINGAKU3.Text = "KONYU_KINGAKU3"
Me.lblKONYUKINGAKU3.Enabled = True
'
'numKONYUKINGAKU3
'
Me.numKONYUKINGAKU3.BackColor = System.Drawing.Color.White
Me.numKONYUKINGAKU3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKONYUKINGAKU3.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKONYUKINGAKU3.IsNextControl = True
Me.numKONYUKINGAKU3.IsUseFunctionKey = False
Me.numKONYUKINGAKU3.Location = New System.Drawing.Point(190, 162)
Me.numKONYUKINGAKU3.Size = New System.Drawing.Size(200, 24)
Me.numKONYUKINGAKU3.Name = "numKONYUKINGAKU3"
Me.numKONYUKINGAKU3.TabIndex = 9
Me.numKONYUKINGAKU3.Enabled = True
'
'lblNEBIKI
'
Me.lblNEBIKI.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblNEBIKI.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblNEBIKI.ForeColor = System.Drawing.Color.White
Me.lblNEBIKI.Location = New System.Drawing.Point(430, 162)
Me.lblNEBIKI.Name = "lblNEBIKI"
Me.lblNEBIKI.Size = New System.Drawing.Size(170, 24)
Me.lblNEBIKI.Text = "NEBIKI"
Me.lblNEBIKI.Enabled = True
'
'numNEBIKI
'
Me.numNEBIKI.BackColor = System.Drawing.Color.White
Me.numNEBIKI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numNEBIKI.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numNEBIKI.IsNextControl = True
Me.numNEBIKI.IsUseFunctionKey = False
Me.numNEBIKI.Location = New System.Drawing.Point(600, 162)
Me.numNEBIKI.Size = New System.Drawing.Size(200, 24)
Me.numNEBIKI.Name = "numNEBIKI"
Me.numNEBIKI.TabIndex = 10
Me.numNEBIKI.Enabled = True
'
'lblSORYO
'
Me.lblSORYO.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSORYO.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSORYO.ForeColor = System.Drawing.Color.White
Me.lblSORYO.Location = New System.Drawing.Point(840, 162)
Me.lblSORYO.Name = "lblSORYO"
Me.lblSORYO.Size = New System.Drawing.Size(170, 24)
Me.lblSORYO.Text = "SORYO"
Me.lblSORYO.Enabled = True
'
'numSORYO
'
Me.numSORYO.BackColor = System.Drawing.Color.White
Me.numSORYO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numSORYO.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numSORYO.IsNextControl = True
Me.numSORYO.IsUseFunctionKey = False
Me.numSORYO.Location = New System.Drawing.Point(1010, 162)
Me.numSORYO.Size = New System.Drawing.Size(200, 24)
Me.numSORYO.Name = "numSORYO"
Me.numSORYO.TabIndex = 11
Me.numSORYO.Enabled = True
'
'lblZEI1
'
Me.lblZEI1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEI1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEI1.ForeColor = System.Drawing.Color.White
Me.lblZEI1.Location = New System.Drawing.Point(20, 196)
Me.lblZEI1.Name = "lblZEI1"
Me.lblZEI1.Size = New System.Drawing.Size(170, 24)
Me.lblZEI1.Text = "ZEI1"
Me.lblZEI1.Enabled = True
'
'numZEI1
'
Me.numZEI1.BackColor = System.Drawing.Color.White
Me.numZEI1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEI1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEI1.IsNextControl = True
Me.numZEI1.IsUseFunctionKey = False
Me.numZEI1.Location = New System.Drawing.Point(190, 196)
Me.numZEI1.Size = New System.Drawing.Size(200, 24)
Me.numZEI1.Name = "numZEI1"
Me.numZEI1.TabIndex = 12
Me.numZEI1.Enabled = True
'
'lblZEIRITSU1
'
Me.lblZEIRITSU1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEIRITSU1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEIRITSU1.ForeColor = System.Drawing.Color.White
Me.lblZEIRITSU1.Location = New System.Drawing.Point(430, 196)
Me.lblZEIRITSU1.Name = "lblZEIRITSU1"
Me.lblZEIRITSU1.Size = New System.Drawing.Size(170, 24)
Me.lblZEIRITSU1.Text = "ZEI_RITSU1"
Me.lblZEIRITSU1.Enabled = True
'
'numZEIRITSU1
'
Me.numZEIRITSU1.BackColor = System.Drawing.Color.White
Me.numZEIRITSU1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEIRITSU1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEIRITSU1.IsNextControl = True
Me.numZEIRITSU1.IsUseFunctionKey = False
Me.numZEIRITSU1.Location = New System.Drawing.Point(600, 196)
Me.numZEIRITSU1.Size = New System.Drawing.Size(200, 24)
Me.numZEIRITSU1.Name = "numZEIRITSU1"
Me.numZEIRITSU1.TabIndex = 13
Me.numZEIRITSU1.Enabled = True
'
'lblZEI2
'
Me.lblZEI2.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEI2.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEI2.ForeColor = System.Drawing.Color.White
Me.lblZEI2.Location = New System.Drawing.Point(840, 196)
Me.lblZEI2.Name = "lblZEI2"
Me.lblZEI2.Size = New System.Drawing.Size(170, 24)
Me.lblZEI2.Text = "ZEI2"
Me.lblZEI2.Enabled = True
'
'numZEI2
'
Me.numZEI2.BackColor = System.Drawing.Color.White
Me.numZEI2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEI2.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEI2.IsNextControl = True
Me.numZEI2.IsUseFunctionKey = False
Me.numZEI2.Location = New System.Drawing.Point(1010, 196)
Me.numZEI2.Size = New System.Drawing.Size(200, 24)
Me.numZEI2.Name = "numZEI2"
Me.numZEI2.TabIndex = 14
Me.numZEI2.Enabled = True
'
'lblZEIRITSU2
'
Me.lblZEIRITSU2.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEIRITSU2.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEIRITSU2.ForeColor = System.Drawing.Color.White
Me.lblZEIRITSU2.Location = New System.Drawing.Point(20, 230)
Me.lblZEIRITSU2.Name = "lblZEIRITSU2"
Me.lblZEIRITSU2.Size = New System.Drawing.Size(170, 24)
Me.lblZEIRITSU2.Text = "ZEI_RITSU2"
Me.lblZEIRITSU2.Enabled = True
'
'numZEIRITSU2
'
Me.numZEIRITSU2.BackColor = System.Drawing.Color.White
Me.numZEIRITSU2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEIRITSU2.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEIRITSU2.IsNextControl = True
Me.numZEIRITSU2.IsUseFunctionKey = False
Me.numZEIRITSU2.Location = New System.Drawing.Point(190, 230)
Me.numZEIRITSU2.Size = New System.Drawing.Size(200, 24)
Me.numZEIRITSU2.Name = "numZEIRITSU2"
Me.numZEIRITSU2.TabIndex = 15
Me.numZEIRITSU2.Enabled = True
'
'lblZEI3
'
Me.lblZEI3.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEI3.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEI3.ForeColor = System.Drawing.Color.White
Me.lblZEI3.Location = New System.Drawing.Point(430, 230)
Me.lblZEI3.Name = "lblZEI3"
Me.lblZEI3.Size = New System.Drawing.Size(170, 24)
Me.lblZEI3.Text = "ZEI3"
Me.lblZEI3.Enabled = True
'
'numZEI3
'
Me.numZEI3.BackColor = System.Drawing.Color.White
Me.numZEI3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEI3.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEI3.IsNextControl = True
Me.numZEI3.IsUseFunctionKey = False
Me.numZEI3.Location = New System.Drawing.Point(600, 230)
Me.numZEI3.Size = New System.Drawing.Size(200, 24)
Me.numZEI3.Name = "numZEI3"
Me.numZEI3.TabIndex = 16
Me.numZEI3.Enabled = True
'
'lblZEIRITSU3
'
Me.lblZEIRITSU3.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEIRITSU3.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEIRITSU3.ForeColor = System.Drawing.Color.White
Me.lblZEIRITSU3.Location = New System.Drawing.Point(840, 230)
Me.lblZEIRITSU3.Name = "lblZEIRITSU3"
Me.lblZEIRITSU3.Size = New System.Drawing.Size(170, 24)
Me.lblZEIRITSU3.Text = "ZEI_RITSU3"
Me.lblZEIRITSU3.Enabled = True
'
'numZEIRITSU3
'
Me.numZEIRITSU3.BackColor = System.Drawing.Color.White
Me.numZEIRITSU3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEIRITSU3.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEIRITSU3.IsNextControl = True
Me.numZEIRITSU3.IsUseFunctionKey = False
Me.numZEIRITSU3.Location = New System.Drawing.Point(1010, 230)
Me.numZEIRITSU3.Size = New System.Drawing.Size(200, 24)
Me.numZEIRITSU3.Name = "numZEIRITSU3"
Me.numZEIRITSU3.TabIndex = 17
Me.numZEIRITSU3.Enabled = True
'
'lblGOKEIKINGAKU
'
Me.lblGOKEIKINGAKU.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblGOKEIKINGAKU.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblGOKEIKINGAKU.ForeColor = System.Drawing.Color.White
Me.lblGOKEIKINGAKU.Location = New System.Drawing.Point(20, 264)
Me.lblGOKEIKINGAKU.Name = "lblGOKEIKINGAKU"
Me.lblGOKEIKINGAKU.Size = New System.Drawing.Size(170, 24)
Me.lblGOKEIKINGAKU.Text = "GOKEI_KINGAKU"
Me.lblGOKEIKINGAKU.Enabled = True
'
'numGOKEIKINGAKU
'
Me.numGOKEIKINGAKU.BackColor = System.Drawing.Color.White
Me.numGOKEIKINGAKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numGOKEIKINGAKU.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numGOKEIKINGAKU.IsNextControl = True
Me.numGOKEIKINGAKU.IsUseFunctionKey = False
Me.numGOKEIKINGAKU.Location = New System.Drawing.Point(190, 264)
Me.numGOKEIKINGAKU.Size = New System.Drawing.Size(200, 24)
Me.numGOKEIKINGAKU.Name = "numGOKEIKINGAKU"
Me.numGOKEIKINGAKU.TabIndex = 18
Me.numGOKEIKINGAKU.Enabled = True
'
'lblSTATUS
'
Me.lblSTATUS.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSTATUS.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSTATUS.ForeColor = System.Drawing.Color.White
Me.lblSTATUS.Location = New System.Drawing.Point(430, 264)
Me.lblSTATUS.Name = "lblSTATUS"
Me.lblSTATUS.Size = New System.Drawing.Size(170, 24)
Me.lblSTATUS.Text = "STATUS"
Me.lblSTATUS.Enabled = True
'
'numSTATUS
'
Me.numSTATUS.BackColor = System.Drawing.Color.White
Me.numSTATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numSTATUS.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numSTATUS.IsNextControl = True
Me.numSTATUS.IsUseFunctionKey = False
Me.numSTATUS.Location = New System.Drawing.Point(600, 264)
Me.numSTATUS.Size = New System.Drawing.Size(200, 24)
Me.numSTATUS.Name = "numSTATUS"
Me.numSTATUS.TabIndex = 19
Me.numSTATUS.Enabled = True
'
'lblYUKOFLAG
'
Me.lblYUKOFLAG.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblYUKOFLAG.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblYUKOFLAG.ForeColor = System.Drawing.Color.White
Me.lblYUKOFLAG.Location = New System.Drawing.Point(840, 264)
Me.lblYUKOFLAG.Name = "lblYUKOFLAG"
Me.lblYUKOFLAG.Size = New System.Drawing.Size(170, 24)
Me.lblYUKOFLAG.Text = "YUKO_FLAG"
Me.lblYUKOFLAG.Enabled = True
'
'numYUKOFLAG
'
Me.numYUKOFLAG.BackColor = System.Drawing.Color.White
Me.numYUKOFLAG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numYUKOFLAG.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numYUKOFLAG.IsNextControl = True
Me.numYUKOFLAG.IsUseFunctionKey = False
Me.numYUKOFLAG.Location = New System.Drawing.Point(1010, 264)
Me.numYUKOFLAG.Size = New System.Drawing.Size(200, 24)
Me.numYUKOFLAG.Name = "numYUKOFLAG"
Me.numYUKOFLAG.TabIndex = 20
Me.numYUKOFLAG.Enabled = True
'
'lblLASTUPDATEUSER
'
Me.lblLASTUPDATEUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEUSER.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEUSER.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEUSER.Location = New System.Drawing.Point(20, 298)
Me.lblLASTUPDATEUSER.Name = "lblLASTUPDATEUSER"
Me.lblLASTUPDATEUSER.Size = New System.Drawing.Size(170, 24)
Me.lblLASTUPDATEUSER.Text = "LAST_UPDATE_USER"
Me.lblLASTUPDATEUSER.Enabled = True
'
'txtLASTUPDATEUSER
'
Me.txtLASTUPDATEUSER.BackColor = System.Drawing.Color.White
Me.txtLASTUPDATEUSER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtLASTUPDATEUSER.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtLASTUPDATEUSER.IsNextControl = True
Me.txtLASTUPDATEUSER.IsUseFunctionKey = False
Me.txtLASTUPDATEUSER.Location = New System.Drawing.Point(190, 298)
Me.txtLASTUPDATEUSER.Size = New System.Drawing.Size(200, 24)
Me.txtLASTUPDATEUSER.Name = "txtLASTUPDATEUSER"
Me.txtLASTUPDATEUSER.TabIndex = 21
Me.txtLASTUPDATEUSER.Enabled = True
'
'lblLASTUPDATE
'
Me.lblLASTUPDATE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATE.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATE.Location = New System.Drawing.Point(430, 298)
Me.lblLASTUPDATE.Name = "lblLASTUPDATE"
Me.lblLASTUPDATE.Size = New System.Drawing.Size(170, 24)
Me.lblLASTUPDATE.Text = "LAST_UPDATE"
Me.lblLASTUPDATE.Enabled = True
'
'dteLASTUPDATE
'
Me.dteLASTUPDATE.BackColor = System.Drawing.Color.White
Me.dteLASTUPDATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteLASTUPDATE.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteLASTUPDATE.IsNextControl = True
Me.dteLASTUPDATE.IsUseFunctionKey = False
Me.dteLASTUPDATE.Location = New System.Drawing.Point(600, 298)
Me.dteLASTUPDATE.Size = New System.Drawing.Size(200, 24)
Me.dteLASTUPDATE.Name = "dteLASTUPDATE"
Me.dteLASTUPDATE.TabIndex = 22
Me.dteLASTUPDATE.Enabled = True
'
'lblLASTUPDATEPROGRAM
'
Me.lblLASTUPDATEPROGRAM.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEPROGRAM.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEPROGRAM.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEPROGRAM.Location = New System.Drawing.Point(840, 298)
Me.lblLASTUPDATEPROGRAM.Name = "lblLASTUPDATEPROGRAM"
Me.lblLASTUPDATEPROGRAM.Size = New System.Drawing.Size(170, 24)
Me.lblLASTUPDATEPROGRAM.Text = "LAST_UPDATE_PROGRAM"
Me.lblLASTUPDATEPROGRAM.Enabled = True
'
'txtLASTUPDATEPROGRAM
'
Me.txtLASTUPDATEPROGRAM.BackColor = System.Drawing.Color.White
Me.txtLASTUPDATEPROGRAM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtLASTUPDATEPROGRAM.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtLASTUPDATEPROGRAM.IsNextControl = True
Me.txtLASTUPDATEPROGRAM.IsUseFunctionKey = False
Me.txtLASTUPDATEPROGRAM.Location = New System.Drawing.Point(1010, 298)
Me.txtLASTUPDATEPROGRAM.Size = New System.Drawing.Size(200, 24)
Me.txtLASTUPDATEPROGRAM.Name = "txtLASTUPDATEPROGRAM"
Me.txtLASTUPDATEPROGRAM.TabIndex = 23
Me.txtLASTUPDATEPROGRAM.Enabled = True
'
'ColumnCHUMONID
'
Me.ColumnCHUMONID.HeaderText = "CHUMON_ID"
Me.ColumnCHUMONID.Name = "CHUMONID"
Me.ColumnCHUMONID.ReadOnly = True
Me.ColumnCHUMONID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCHUMONID.Width = 150
'
'ColumnCHUMONNO
'
Me.ColumnCHUMONNO.HeaderText = "CHUMON_NO"
Me.ColumnCHUMONNO.Name = "CHUMONNO"
Me.ColumnCHUMONNO.ReadOnly = True
Me.ColumnCHUMONNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCHUMONNO.Width = 150
'
'ColumnCHUMONDATE
'
Me.ColumnCHUMONDATE.HeaderText = "CHUMON_DATE"
Me.ColumnCHUMONDATE.Name = "CHUMONDATE"
Me.ColumnCHUMONDATE.ReadOnly = True
Me.ColumnCHUMONDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCHUMONDATE.Width = 150
'
'ColumnHOJINCODE
'
Me.ColumnHOJINCODE.HeaderText = "HOJIN_CODE"
Me.ColumnHOJINCODE.Name = "HOJINCODE"
Me.ColumnHOJINCODE.ReadOnly = True
Me.ColumnHOJINCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnHOJINCODE.Width = 150
'
'ColumnKONYUNAME
'
Me.ColumnKONYUNAME.HeaderText = "KONYU_NAME"
Me.ColumnKONYUNAME.Name = "KONYUNAME"
Me.ColumnKONYUNAME.ReadOnly = True
Me.ColumnKONYUNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKONYUNAME.Width = 150
'
'ColumnKONYUMAILADDRESS
'
Me.ColumnKONYUMAILADDRESS.HeaderText = "KONYU_MAIL_ADDRESS"
Me.ColumnKONYUMAILADDRESS.Name = "KONYUMAILADDRESS"
Me.ColumnKONYUMAILADDRESS.ReadOnly = True
Me.ColumnKONYUMAILADDRESS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKONYUMAILADDRESS.Width = 150
'
'ColumnKONYUTANTOSHA
'
Me.ColumnKONYUTANTOSHA.HeaderText = "KONYU_TANTOSHA"
Me.ColumnKONYUTANTOSHA.Name = "KONYUTANTOSHA"
Me.ColumnKONYUTANTOSHA.ReadOnly = True
Me.ColumnKONYUTANTOSHA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKONYUTANTOSHA.Width = 150
'
'ColumnKONYUKINGAKU1
'
Me.ColumnKONYUKINGAKU1.HeaderText = "KONYU_KINGAKU1"
Me.ColumnKONYUKINGAKU1.Name = "KONYUKINGAKU1"
Me.ColumnKONYUKINGAKU1.ReadOnly = True
Me.ColumnKONYUKINGAKU1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKONYUKINGAKU1.Width = 150
'
'ColumnKONYUKINGAKU2
'
Me.ColumnKONYUKINGAKU2.HeaderText = "KONYU_KINGAKU2"
Me.ColumnKONYUKINGAKU2.Name = "KONYUKINGAKU2"
Me.ColumnKONYUKINGAKU2.ReadOnly = True
Me.ColumnKONYUKINGAKU2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKONYUKINGAKU2.Width = 150
'
'ColumnKONYUKINGAKU3
'
Me.ColumnKONYUKINGAKU3.HeaderText = "KONYU_KINGAKU3"
Me.ColumnKONYUKINGAKU3.Name = "KONYUKINGAKU3"
Me.ColumnKONYUKINGAKU3.ReadOnly = True
Me.ColumnKONYUKINGAKU3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKONYUKINGAKU3.Width = 150
'
'ColumnNEBIKI
'
Me.ColumnNEBIKI.HeaderText = "NEBIKI"
Me.ColumnNEBIKI.Name = "NEBIKI"
Me.ColumnNEBIKI.ReadOnly = True
Me.ColumnNEBIKI.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnNEBIKI.Width = 150
'
'ColumnSORYO
'
Me.ColumnSORYO.HeaderText = "SORYO"
Me.ColumnSORYO.Name = "SORYO"
Me.ColumnSORYO.ReadOnly = True
Me.ColumnSORYO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSORYO.Width = 150
'
'ColumnZEI1
'
Me.ColumnZEI1.HeaderText = "ZEI1"
Me.ColumnZEI1.Name = "ZEI1"
Me.ColumnZEI1.ReadOnly = True
Me.ColumnZEI1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEI1.Width = 150
'
'ColumnZEIRITSU1
'
Me.ColumnZEIRITSU1.HeaderText = "ZEI_RITSU1"
Me.ColumnZEIRITSU1.Name = "ZEIRITSU1"
Me.ColumnZEIRITSU1.ReadOnly = True
Me.ColumnZEIRITSU1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEIRITSU1.Width = 150
'
'ColumnZEI2
'
Me.ColumnZEI2.HeaderText = "ZEI2"
Me.ColumnZEI2.Name = "ZEI2"
Me.ColumnZEI2.ReadOnly = True
Me.ColumnZEI2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEI2.Width = 150
'
'ColumnZEIRITSU2
'
Me.ColumnZEIRITSU2.HeaderText = "ZEI_RITSU2"
Me.ColumnZEIRITSU2.Name = "ZEIRITSU2"
Me.ColumnZEIRITSU2.ReadOnly = True
Me.ColumnZEIRITSU2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEIRITSU2.Width = 150
'
'ColumnZEI3
'
Me.ColumnZEI3.HeaderText = "ZEI3"
Me.ColumnZEI3.Name = "ZEI3"
Me.ColumnZEI3.ReadOnly = True
Me.ColumnZEI3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEI3.Width = 150
'
'ColumnZEIRITSU3
'
Me.ColumnZEIRITSU3.HeaderText = "ZEI_RITSU3"
Me.ColumnZEIRITSU3.Name = "ZEIRITSU3"
Me.ColumnZEIRITSU3.ReadOnly = True
Me.ColumnZEIRITSU3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEIRITSU3.Width = 150
'
'ColumnGOKEIKINGAKU
'
Me.ColumnGOKEIKINGAKU.HeaderText = "GOKEI_KINGAKU"
Me.ColumnGOKEIKINGAKU.Name = "GOKEIKINGAKU"
Me.ColumnGOKEIKINGAKU.ReadOnly = True
Me.ColumnGOKEIKINGAKU.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnGOKEIKINGAKU.Width = 150
'
'ColumnSTATUS
'
Me.ColumnSTATUS.HeaderText = "STATUS"
Me.ColumnSTATUS.Name = "STATUS"
Me.ColumnSTATUS.ReadOnly = True
Me.ColumnSTATUS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSTATUS.Width = 150
'
'ColumnYUKOFLAG
'
Me.ColumnYUKOFLAG.HeaderText = "YUKO_FLAG"
Me.ColumnYUKOFLAG.Name = "YUKOFLAG"
Me.ColumnYUKOFLAG.ReadOnly = True
Me.ColumnYUKOFLAG.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnYUKOFLAG.Width = 150
'
'ColumnLASTUPDATEUSER
'
Me.ColumnLASTUPDATEUSER.HeaderText = "LAST_UPDATE_USER"
Me.ColumnLASTUPDATEUSER.Name = "LASTUPDATEUSER"
Me.ColumnLASTUPDATEUSER.ReadOnly = True
Me.ColumnLASTUPDATEUSER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLASTUPDATEUSER.Width = 150
'
'ColumnLASTUPDATE
'
Me.ColumnLASTUPDATE.HeaderText = "LAST_UPDATE"
Me.ColumnLASTUPDATE.Name = "LASTUPDATE"
Me.ColumnLASTUPDATE.ReadOnly = True
Me.ColumnLASTUPDATE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLASTUPDATE.Width = 150
'
'ColumnLASTUPDATEPROGRAM
'
Me.ColumnLASTUPDATEPROGRAM.HeaderText = "LAST_UPDATE_PROGRAM"
Me.ColumnLASTUPDATEPROGRAM.Name = "LASTUPDATEPROGRAM"
Me.ColumnLASTUPDATEPROGRAM.ReadOnly = True
Me.ColumnLASTUPDATEPROGRAM.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLASTUPDATEPROGRAM.Width = 150
'
'MseDataGrid
'
Me.MseDataGrid.AllowUserToAddRows = False
Me.MseDataGrid.AllowUserToDeleteRows = False
Me.MseDataGrid.AllowUserToResizeRows = False
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.MseDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.MseDataGrid.ColumnHeadersHeight = 30
Me.MseDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
Me.MseDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ColumnCHUMONID,ColumnCHUMONNO,ColumnCHUMONDATE,ColumnHOJINCODE,ColumnKONYUNAME,ColumnKONYUMAILADDRESS,ColumnKONYUTANTOSHA,ColumnKONYUKINGAKU1,ColumnKONYUKINGAKU2,ColumnKONYUKINGAKU3,ColumnNEBIKI,ColumnSORYO,ColumnZEI1,ColumnZEIRITSU1,ColumnZEI2,ColumnZEIRITSU2,ColumnZEI3,ColumnZEIRITSU3,ColumnGOKEIKINGAKU,ColumnSTATUS,ColumnYUKOFLAG,ColumnLASTUPDATEUSER,ColumnLASTUPDATE,ColumnLASTUPDATEPROGRAM})
Me.MseDataGrid.DefaultActiveColLeft = 0
Me.MseDataGrid.DefaultActiveColRight = 2
Me.MseDataGrid.DefaultActiveRowBottom = 0
Me.MseDataGrid.DefaultActiveRowTop = 0
Me.MseDataGrid.EnableHeadersVisualStyles = False
Me.MseDataGrid.Location = New System.Drawing.Point(20, 332)
Me.MseDataGrid.MultiSelect = False
Me.MseDataGrid.Name = "MseDataGrid"
Me.MseDataGrid.ReadOnly = True
Me.MseDataGrid.RowHeadersWidth = 35
Me.MseDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
Me.MseDataGrid.RowTemplate.Height = 30
Me.MseDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.MseDataGrid.SheetMode = UI.Control.SheetMode.Display
Me.MseDataGrid.Size = New System.Drawing.Size(1190, 200)
Me.MseDataGrid.TabIndex = 24
'
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearch.Location = New System.Drawing.Point(24, 566)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 38)
        Me.btnSearch.TabIndex = 25
        Me.btnSearch.Text = "F5：検　索"
        Me.btnSearch.UseVisualStyleBackColor = False
'
        'btnDataOutput
        '
        Me.btnDataOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnDataOutput.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnDataOutput.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnDataOutput.Location = New System.Drawing.Point(411, 566)
        Me.btnDataOutput.Name = "btnDataOutput"
        Me.btnDataOutput.Size = New System.Drawing.Size(120, 38)
        Me.btnDataOutput.TabIndex = 26
        Me.btnDataOutput.Text = "F7：データ出力"
        Me.btnDataOutput.UseVisualStyleBackColor = False
'
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnSelect.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSelect.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSelect.Location = New System.Drawing.Point(537, 566)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(120, 38)
        Me.btnSelect.TabIndex =  27
        Me.btnSelect.Text = "F9：選　択"
        Me.btnSelect.UseVisualStyleBackColor = False
'
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClear.Location = New System.Drawing.Point(663, 566)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 38)
        Me.btnClear.TabIndex = 28
        Me.btnClear.Text = "F11:クリア"
        Me.btnClear.UseVisualStyleBackColor = False
'
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Location = New System.Drawing.Point(789, 566)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 38)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "F12:終了"
        Me.btnClose.UseVisualStyleBackColor = False


        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1240, 740)
        
        Me.Controls.Add(Me.MseDataGrid)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnDataOutput)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ChumonSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chumon検索"
        CType(Me.MseDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

        Friend WithEvents lblTitle As MSELabel
        Friend WithEvents btnClose As MSEButton
        Friend WithEvents btnClear As MSEButton
        Friend WithEvents btnSelect As MSEButton
        Friend WithEvents btnDataOutput As MSEButton
        Friend WithEvents btnSearch As MSEButton
        Friend WithEvents MseDataGrid As MSEDataGrid
        '　ChumonId      
        Friend WithEvents lblChumonId As MSELabel
        Friend WithEvents numChumonId As MSEEdit
        Friend WithEvents ColumnChumonId As DataGridViewTextBoxColumn

        '　ChumonNo      
        Friend WithEvents lblChumonNo As MSELabel
        Friend WithEvents txtChumonNo As MSEEdit
        Friend WithEvents ColumnChumonNo As DataGridViewTextBoxColumn

        '　ChumonDate        
        Friend WithEvents lblChumonDate As MSELabel
        Friend WithEvents dteChumonDate As MSEDate
        Friend WithEvents ColumnChumonDate As DataGridViewTextBoxColumn

        '　HojinCode      
        Friend WithEvents lblHojinCode As MSELabel
        Friend WithEvents txtHojinCode As MSEEdit
        Friend WithEvents ColumnHojinCode As DataGridViewTextBoxColumn

        '　KonyuName      
        Friend WithEvents lblKonyuName As MSELabel
        Friend WithEvents txtKonyuName As MSEEdit
        Friend WithEvents ColumnKonyuName As DataGridViewTextBoxColumn

        '　KonyuMailAddress      
        Friend WithEvents lblKonyuMailAddress As MSELabel
        Friend WithEvents txtKonyuMailAddress As MSEEdit
        Friend WithEvents ColumnKonyuMailAddress As DataGridViewTextBoxColumn

        '　KonyuTantosha      
        Friend WithEvents lblKonyuTantosha As MSELabel
        Friend WithEvents txtKonyuTantosha As MSEEdit
        Friend WithEvents ColumnKonyuTantosha As DataGridViewTextBoxColumn

        '　KonyuKingaku1      
        Friend WithEvents lblKonyuKingaku1 As MSELabel
        Friend WithEvents numKonyuKingaku1 As MSEEdit
        Friend WithEvents ColumnKonyuKingaku1 As DataGridViewTextBoxColumn

        '　KonyuKingaku2      
        Friend WithEvents lblKonyuKingaku2 As MSELabel
        Friend WithEvents numKonyuKingaku2 As MSEEdit
        Friend WithEvents ColumnKonyuKingaku2 As DataGridViewTextBoxColumn

        '　KonyuKingaku3      
        Friend WithEvents lblKonyuKingaku3 As MSELabel
        Friend WithEvents numKonyuKingaku3 As MSEEdit
        Friend WithEvents ColumnKonyuKingaku3 As DataGridViewTextBoxColumn

        '　Nebiki      
        Friend WithEvents lblNebiki As MSELabel
        Friend WithEvents numNebiki As MSEEdit
        Friend WithEvents ColumnNebiki As DataGridViewTextBoxColumn

        '　Soryo      
        Friend WithEvents lblSoryo As MSELabel
        Friend WithEvents numSoryo As MSEEdit
        Friend WithEvents ColumnSoryo As DataGridViewTextBoxColumn

        '　Zei1      
        Friend WithEvents lblZei1 As MSELabel
        Friend WithEvents numZei1 As MSEEdit
        Friend WithEvents ColumnZei1 As DataGridViewTextBoxColumn

        '　ZeiRitsu1      
        Friend WithEvents lblZeiRitsu1 As MSELabel
        Friend WithEvents numZeiRitsu1 As MSEEdit
        Friend WithEvents ColumnZeiRitsu1 As DataGridViewTextBoxColumn

        '　Zei2      
        Friend WithEvents lblZei2 As MSELabel
        Friend WithEvents numZei2 As MSEEdit
        Friend WithEvents ColumnZei2 As DataGridViewTextBoxColumn

        '　ZeiRitsu2      
        Friend WithEvents lblZeiRitsu2 As MSELabel
        Friend WithEvents numZeiRitsu2 As MSEEdit
        Friend WithEvents ColumnZeiRitsu2 As DataGridViewTextBoxColumn

        '　Zei3      
        Friend WithEvents lblZei3 As MSELabel
        Friend WithEvents numZei3 As MSEEdit
        Friend WithEvents ColumnZei3 As DataGridViewTextBoxColumn

        '　ZeiRitsu3      
        Friend WithEvents lblZeiRitsu3 As MSELabel
        Friend WithEvents numZeiRitsu3 As MSEEdit
        Friend WithEvents ColumnZeiRitsu3 As DataGridViewTextBoxColumn

        '　GokeiKingaku      
        Friend WithEvents lblGokeiKingaku As MSELabel
        Friend WithEvents numGokeiKingaku As MSEEdit
        Friend WithEvents ColumnGokeiKingaku As DataGridViewTextBoxColumn

        '　Status      
        Friend WithEvents lblStatus As MSELabel
        Friend WithEvents numStatus As MSEEdit
        Friend WithEvents ColumnStatus As DataGridViewTextBoxColumn

        '　YukoFlag      
        Friend WithEvents lblYukoFlag As MSELabel
        Friend WithEvents numYukoFlag As MSEEdit
        Friend WithEvents ColumnYukoFlag As DataGridViewTextBoxColumn

        '　LastUpdateUser      
        Friend WithEvents lblLastUpdateUser As MSELabel
        Friend WithEvents txtLastUpdateUser As MSEEdit
        Friend WithEvents ColumnLastUpdateUser As DataGridViewTextBoxColumn

        '　LastUpdate        
        Friend WithEvents lblLastUpdate As MSELabel
        Friend WithEvents dteLastUpdate As MSEDate
        Friend WithEvents ColumnLastUpdate As DataGridViewTextBoxColumn

        '　LastUpdateProgram      
        Friend WithEvents lblLastUpdateProgram As MSELabel
        Friend WithEvents txtLastUpdateProgram As MSEEdit
        Friend WithEvents ColumnLastUpdateProgram As DataGridViewTextBoxColumn


End Class
