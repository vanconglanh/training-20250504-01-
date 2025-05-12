Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChumonMeisaiSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChumonMeisaiSearch))
        Me.lblTitle = New MSELabel()
        Me.btnClose = New MSEButton()
        Me.btnClear = New MSEButton()
        Me.btnSelect = New MSEButton()
        Me.btnDataOutput = New MSEButton()
        Me.btnSearch = New MSEButton()
        Me.MseDataGrid = New MSEDataGrid()
        '　ChumonMeisaiId
        Me.lblChumonMeisaiId = New MSELabel
        Me.numChumonMeisaiId = New MSEEdit()
        Me.ColumnChumonMeisaiId = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ChumonId
        Me.lblChumonId = New MSELabel
        Me.numChumonId = New MSEEdit()
        Me.ColumnChumonId = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ChumonMeisaiNo
        Me.lblChumonMeisaiNo = New MSELabel
        Me.txtChumonMeisaiNo = New MSEEdit()
        Me.ColumnChumonMeisaiNo = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ShohinCode
        Me.lblShohinCode = New MSELabel
        Me.txtShohinCode = New MSEEdit()
        Me.ColumnShohinCode = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ShohinName
        Me.lblShohinName = New MSELabel
        Me.txtShohinName = New MSEEdit()
        Me.ColumnShohinName = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Suryo
        Me.lblSuryo = New MSELabel
        Me.numSuryo = New MSEEdit()
        Me.ColumnSuryo = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Tanka
        Me.lblTanka = New MSELabel
        Me.numTanka = New MSEEdit()
        Me.ColumnTanka = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Kingaku
        Me.lblKingaku = New MSELabel
        Me.numKingaku = New MSEEdit()
        Me.ColumnKingaku = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Soryo
        Me.lblSoryo = New MSELabel
        Me.numSoryo = New MSEEdit()
        Me.ColumnSoryo = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ZeiRitsu
        Me.lblZeiRitsu = New MSELabel
        Me.numZeiRitsu = New MSEEdit()
        Me.ColumnZeiRitsu = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　GokeiKingaku
        Me.lblGokeiKingaku = New MSELabel
        Me.numGokeiKingaku = New MSEEdit()
        Me.ColumnGokeiKingaku = New System.Windows.Forms.DataGridViewTextBoxColumn()

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
        Me.lblTitle.Text = "ChumonMeisai検索"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        
        'Generaete Init control
        Me.Controls.Add(Me.lblCHUMONMEISAIID)
Me.Controls.Add(Me.numCHUMONMEISAIID)
Me.Controls.Add(Me.lblCHUMONID)
Me.Controls.Add(Me.numCHUMONID)
Me.Controls.Add(Me.lblCHUMONMEISAINO)
Me.Controls.Add(Me.txtCHUMONMEISAINO)
Me.Controls.Add(Me.lblSHOHINCODE)
Me.Controls.Add(Me.txtSHOHINCODE)
Me.Controls.Add(Me.lblSHOHINNAME)
Me.Controls.Add(Me.txtSHOHINNAME)
Me.Controls.Add(Me.lblSURYO)
Me.Controls.Add(Me.numSURYO)
Me.Controls.Add(Me.lblTANKA)
Me.Controls.Add(Me.numTANKA)
Me.Controls.Add(Me.lblKINGAKU)
Me.Controls.Add(Me.numKINGAKU)
Me.Controls.Add(Me.lblSORYO)
Me.Controls.Add(Me.numSORYO)
Me.Controls.Add(Me.lblZEIRITSU)
Me.Controls.Add(Me.numZEIRITSU)
Me.Controls.Add(Me.lblGOKEIKINGAKU)
Me.Controls.Add(Me.numGOKEIKINGAKU)
Me.Controls.Add(Me.lblYUKOFLAG)
Me.Controls.Add(Me.numYUKOFLAG)
Me.Controls.Add(Me.lblLASTUPDATEUSER)
Me.Controls.Add(Me.txtLASTUPDATEUSER)
Me.Controls.Add(Me.lblLASTUPDATE)
Me.Controls.Add(Me.dteLASTUPDATE)
Me.Controls.Add(Me.lblLASTUPDATEPROGRAM)
Me.Controls.Add(Me.txtLASTUPDATEPROGRAM)
'
'lblCHUMONMEISAIID
'
Me.lblCHUMONMEISAIID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCHUMONMEISAIID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCHUMONMEISAIID.ForeColor = System.Drawing.Color.White
Me.lblCHUMONMEISAIID.Location = New System.Drawing.Point(20, 60)
Me.lblCHUMONMEISAIID.Name = "lblCHUMONMEISAIID"
Me.lblCHUMONMEISAIID.Size = New System.Drawing.Size(170, 24)
Me.lblCHUMONMEISAIID.Text = "CHUMON_MEISAI_ID"
Me.lblCHUMONMEISAIID.Enabled = True
'
'numCHUMONMEISAIID
'
Me.numCHUMONMEISAIID.BackColor = System.Drawing.Color.White
Me.numCHUMONMEISAIID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numCHUMONMEISAIID.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numCHUMONMEISAIID.IsNextControl = True
Me.numCHUMONMEISAIID.IsUseFunctionKey = False
Me.numCHUMONMEISAIID.Location = New System.Drawing.Point(190, 60)
Me.numCHUMONMEISAIID.Size = New System.Drawing.Size(200, 24)
Me.numCHUMONMEISAIID.Name = "numCHUMONMEISAIID"
Me.numCHUMONMEISAIID.TabIndex = 0
Me.numCHUMONMEISAIID.Enabled = True
'
'lblCHUMONID
'
Me.lblCHUMONID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCHUMONID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCHUMONID.ForeColor = System.Drawing.Color.White
Me.lblCHUMONID.Location = New System.Drawing.Point(430, 60)
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
Me.numCHUMONID.Location = New System.Drawing.Point(600, 60)
Me.numCHUMONID.Size = New System.Drawing.Size(200, 24)
Me.numCHUMONID.Name = "numCHUMONID"
Me.numCHUMONID.TabIndex = 1
Me.numCHUMONID.Enabled = True
'
'lblCHUMONMEISAINO
'
Me.lblCHUMONMEISAINO.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCHUMONMEISAINO.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCHUMONMEISAINO.ForeColor = System.Drawing.Color.White
Me.lblCHUMONMEISAINO.Location = New System.Drawing.Point(840, 60)
Me.lblCHUMONMEISAINO.Name = "lblCHUMONMEISAINO"
Me.lblCHUMONMEISAINO.Size = New System.Drawing.Size(170, 24)
Me.lblCHUMONMEISAINO.Text = "CHUMON_MEISAI_NO"
Me.lblCHUMONMEISAINO.Enabled = True
'
'txtCHUMONMEISAINO
'
Me.txtCHUMONMEISAINO.BackColor = System.Drawing.Color.White
Me.txtCHUMONMEISAINO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtCHUMONMEISAINO.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtCHUMONMEISAINO.IsNextControl = True
Me.txtCHUMONMEISAINO.IsUseFunctionKey = False
Me.txtCHUMONMEISAINO.Location = New System.Drawing.Point(1010, 60)
Me.txtCHUMONMEISAINO.Size = New System.Drawing.Size(200, 24)
Me.txtCHUMONMEISAINO.Name = "txtCHUMONMEISAINO"
Me.txtCHUMONMEISAINO.TabIndex = 2
Me.txtCHUMONMEISAINO.Enabled = True
'
'lblSHOHINCODE
'
Me.lblSHOHINCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSHOHINCODE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSHOHINCODE.ForeColor = System.Drawing.Color.White
Me.lblSHOHINCODE.Location = New System.Drawing.Point(20, 94)
Me.lblSHOHINCODE.Name = "lblSHOHINCODE"
Me.lblSHOHINCODE.Size = New System.Drawing.Size(170, 24)
Me.lblSHOHINCODE.Text = "SHOHIN_CODE"
Me.lblSHOHINCODE.Enabled = True
'
'txtSHOHINCODE
'
Me.txtSHOHINCODE.BackColor = System.Drawing.Color.White
Me.txtSHOHINCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtSHOHINCODE.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtSHOHINCODE.IsNextControl = True
Me.txtSHOHINCODE.IsUseFunctionKey = False
Me.txtSHOHINCODE.Location = New System.Drawing.Point(190, 94)
Me.txtSHOHINCODE.Size = New System.Drawing.Size(200, 24)
Me.txtSHOHINCODE.Name = "txtSHOHINCODE"
Me.txtSHOHINCODE.TabIndex = 3
Me.txtSHOHINCODE.Enabled = True
'
'lblSHOHINNAME
'
Me.lblSHOHINNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSHOHINNAME.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSHOHINNAME.ForeColor = System.Drawing.Color.White
Me.lblSHOHINNAME.Location = New System.Drawing.Point(430, 94)
Me.lblSHOHINNAME.Name = "lblSHOHINNAME"
Me.lblSHOHINNAME.Size = New System.Drawing.Size(170, 24)
Me.lblSHOHINNAME.Text = "SHOHIN_NAME"
Me.lblSHOHINNAME.Enabled = True
'
'txtSHOHINNAME
'
Me.txtSHOHINNAME.BackColor = System.Drawing.Color.White
Me.txtSHOHINNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtSHOHINNAME.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtSHOHINNAME.IsNextControl = True
Me.txtSHOHINNAME.IsUseFunctionKey = False
Me.txtSHOHINNAME.Location = New System.Drawing.Point(600, 94)
Me.txtSHOHINNAME.Size = New System.Drawing.Size(200, 24)
Me.txtSHOHINNAME.Name = "txtSHOHINNAME"
Me.txtSHOHINNAME.TabIndex = 4
Me.txtSHOHINNAME.Enabled = True
'
'lblSURYO
'
Me.lblSURYO.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSURYO.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSURYO.ForeColor = System.Drawing.Color.White
Me.lblSURYO.Location = New System.Drawing.Point(840, 94)
Me.lblSURYO.Name = "lblSURYO"
Me.lblSURYO.Size = New System.Drawing.Size(170, 24)
Me.lblSURYO.Text = "SURYO"
Me.lblSURYO.Enabled = True
'
'numSURYO
'
Me.numSURYO.BackColor = System.Drawing.Color.White
Me.numSURYO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numSURYO.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numSURYO.IsNextControl = True
Me.numSURYO.IsUseFunctionKey = False
Me.numSURYO.Location = New System.Drawing.Point(1010, 94)
Me.numSURYO.Size = New System.Drawing.Size(200, 24)
Me.numSURYO.Name = "numSURYO"
Me.numSURYO.TabIndex = 5
Me.numSURYO.Enabled = True
'
'lblTANKA
'
Me.lblTANKA.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblTANKA.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblTANKA.ForeColor = System.Drawing.Color.White
Me.lblTANKA.Location = New System.Drawing.Point(20, 128)
Me.lblTANKA.Name = "lblTANKA"
Me.lblTANKA.Size = New System.Drawing.Size(170, 24)
Me.lblTANKA.Text = "TANKA"
Me.lblTANKA.Enabled = True
'
'numTANKA
'
Me.numTANKA.BackColor = System.Drawing.Color.White
Me.numTANKA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numTANKA.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numTANKA.IsNextControl = True
Me.numTANKA.IsUseFunctionKey = False
Me.numTANKA.Location = New System.Drawing.Point(190, 128)
Me.numTANKA.Size = New System.Drawing.Size(200, 24)
Me.numTANKA.Name = "numTANKA"
Me.numTANKA.TabIndex = 6
Me.numTANKA.Enabled = True
'
'lblKINGAKU
'
Me.lblKINGAKU.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKINGAKU.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKINGAKU.ForeColor = System.Drawing.Color.White
Me.lblKINGAKU.Location = New System.Drawing.Point(430, 128)
Me.lblKINGAKU.Name = "lblKINGAKU"
Me.lblKINGAKU.Size = New System.Drawing.Size(170, 24)
Me.lblKINGAKU.Text = "KINGAKU"
Me.lblKINGAKU.Enabled = True
'
'numKINGAKU
'
Me.numKINGAKU.BackColor = System.Drawing.Color.White
Me.numKINGAKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKINGAKU.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKINGAKU.IsNextControl = True
Me.numKINGAKU.IsUseFunctionKey = False
Me.numKINGAKU.Location = New System.Drawing.Point(600, 128)
Me.numKINGAKU.Size = New System.Drawing.Size(200, 24)
Me.numKINGAKU.Name = "numKINGAKU"
Me.numKINGAKU.TabIndex = 7
Me.numKINGAKU.Enabled = True
'
'lblSORYO
'
Me.lblSORYO.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSORYO.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSORYO.ForeColor = System.Drawing.Color.White
Me.lblSORYO.Location = New System.Drawing.Point(840, 128)
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
Me.numSORYO.Location = New System.Drawing.Point(1010, 128)
Me.numSORYO.Size = New System.Drawing.Size(200, 24)
Me.numSORYO.Name = "numSORYO"
Me.numSORYO.TabIndex = 8
Me.numSORYO.Enabled = True
'
'lblZEIRITSU
'
Me.lblZEIRITSU.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZEIRITSU.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZEIRITSU.ForeColor = System.Drawing.Color.White
Me.lblZEIRITSU.Location = New System.Drawing.Point(20, 162)
Me.lblZEIRITSU.Name = "lblZEIRITSU"
Me.lblZEIRITSU.Size = New System.Drawing.Size(170, 24)
Me.lblZEIRITSU.Text = "ZEI_RITSU"
Me.lblZEIRITSU.Enabled = True
'
'numZEIRITSU
'
Me.numZEIRITSU.BackColor = System.Drawing.Color.White
Me.numZEIRITSU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZEIRITSU.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZEIRITSU.IsNextControl = True
Me.numZEIRITSU.IsUseFunctionKey = False
Me.numZEIRITSU.Location = New System.Drawing.Point(190, 162)
Me.numZEIRITSU.Size = New System.Drawing.Size(200, 24)
Me.numZEIRITSU.Name = "numZEIRITSU"
Me.numZEIRITSU.TabIndex = 9
Me.numZEIRITSU.Enabled = True
'
'lblGOKEIKINGAKU
'
Me.lblGOKEIKINGAKU.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblGOKEIKINGAKU.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblGOKEIKINGAKU.ForeColor = System.Drawing.Color.White
Me.lblGOKEIKINGAKU.Location = New System.Drawing.Point(430, 162)
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
Me.numGOKEIKINGAKU.Location = New System.Drawing.Point(600, 162)
Me.numGOKEIKINGAKU.Size = New System.Drawing.Size(200, 24)
Me.numGOKEIKINGAKU.Name = "numGOKEIKINGAKU"
Me.numGOKEIKINGAKU.TabIndex = 10
Me.numGOKEIKINGAKU.Enabled = True
'
'lblYUKOFLAG
'
Me.lblYUKOFLAG.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblYUKOFLAG.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblYUKOFLAG.ForeColor = System.Drawing.Color.White
Me.lblYUKOFLAG.Location = New System.Drawing.Point(840, 162)
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
Me.numYUKOFLAG.Location = New System.Drawing.Point(1010, 162)
Me.numYUKOFLAG.Size = New System.Drawing.Size(200, 24)
Me.numYUKOFLAG.Name = "numYUKOFLAG"
Me.numYUKOFLAG.TabIndex = 11
Me.numYUKOFLAG.Enabled = True
'
'lblLASTUPDATEUSER
'
Me.lblLASTUPDATEUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEUSER.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEUSER.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEUSER.Location = New System.Drawing.Point(20, 196)
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
Me.txtLASTUPDATEUSER.Location = New System.Drawing.Point(190, 196)
Me.txtLASTUPDATEUSER.Size = New System.Drawing.Size(200, 24)
Me.txtLASTUPDATEUSER.Name = "txtLASTUPDATEUSER"
Me.txtLASTUPDATEUSER.TabIndex = 12
Me.txtLASTUPDATEUSER.Enabled = True
'
'lblLASTUPDATE
'
Me.lblLASTUPDATE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATE.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATE.Location = New System.Drawing.Point(430, 196)
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
Me.dteLASTUPDATE.Location = New System.Drawing.Point(600, 196)
Me.dteLASTUPDATE.Size = New System.Drawing.Size(200, 24)
Me.dteLASTUPDATE.Name = "dteLASTUPDATE"
Me.dteLASTUPDATE.TabIndex = 13
Me.dteLASTUPDATE.Enabled = True
'
'lblLASTUPDATEPROGRAM
'
Me.lblLASTUPDATEPROGRAM.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEPROGRAM.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEPROGRAM.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEPROGRAM.Location = New System.Drawing.Point(840, 196)
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
Me.txtLASTUPDATEPROGRAM.Location = New System.Drawing.Point(1010, 196)
Me.txtLASTUPDATEPROGRAM.Size = New System.Drawing.Size(200, 24)
Me.txtLASTUPDATEPROGRAM.Name = "txtLASTUPDATEPROGRAM"
Me.txtLASTUPDATEPROGRAM.TabIndex = 14
Me.txtLASTUPDATEPROGRAM.Enabled = True
'
'ColumnCHUMONMEISAIID
'
Me.ColumnCHUMONMEISAIID.HeaderText = "CHUMON_MEISAI_ID"
Me.ColumnCHUMONMEISAIID.Name = "CHUMONMEISAIID"
Me.ColumnCHUMONMEISAIID.ReadOnly = True
Me.ColumnCHUMONMEISAIID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCHUMONMEISAIID.Width = 150
'
'ColumnCHUMONID
'
Me.ColumnCHUMONID.HeaderText = "CHUMON_ID"
Me.ColumnCHUMONID.Name = "CHUMONID"
Me.ColumnCHUMONID.ReadOnly = True
Me.ColumnCHUMONID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCHUMONID.Width = 150
'
'ColumnCHUMONMEISAINO
'
Me.ColumnCHUMONMEISAINO.HeaderText = "CHUMON_MEISAI_NO"
Me.ColumnCHUMONMEISAINO.Name = "CHUMONMEISAINO"
Me.ColumnCHUMONMEISAINO.ReadOnly = True
Me.ColumnCHUMONMEISAINO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCHUMONMEISAINO.Width = 150
'
'ColumnSHOHINCODE
'
Me.ColumnSHOHINCODE.HeaderText = "SHOHIN_CODE"
Me.ColumnSHOHINCODE.Name = "SHOHINCODE"
Me.ColumnSHOHINCODE.ReadOnly = True
Me.ColumnSHOHINCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSHOHINCODE.Width = 150
'
'ColumnSHOHINNAME
'
Me.ColumnSHOHINNAME.HeaderText = "SHOHIN_NAME"
Me.ColumnSHOHINNAME.Name = "SHOHINNAME"
Me.ColumnSHOHINNAME.ReadOnly = True
Me.ColumnSHOHINNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSHOHINNAME.Width = 150
'
'ColumnSURYO
'
Me.ColumnSURYO.HeaderText = "SURYO"
Me.ColumnSURYO.Name = "SURYO"
Me.ColumnSURYO.ReadOnly = True
Me.ColumnSURYO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSURYO.Width = 150
'
'ColumnTANKA
'
Me.ColumnTANKA.HeaderText = "TANKA"
Me.ColumnTANKA.Name = "TANKA"
Me.ColumnTANKA.ReadOnly = True
Me.ColumnTANKA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnTANKA.Width = 150
'
'ColumnKINGAKU
'
Me.ColumnKINGAKU.HeaderText = "KINGAKU"
Me.ColumnKINGAKU.Name = "KINGAKU"
Me.ColumnKINGAKU.ReadOnly = True
Me.ColumnKINGAKU.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKINGAKU.Width = 150
'
'ColumnSORYO
'
Me.ColumnSORYO.HeaderText = "SORYO"
Me.ColumnSORYO.Name = "SORYO"
Me.ColumnSORYO.ReadOnly = True
Me.ColumnSORYO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSORYO.Width = 150
'
'ColumnZEIRITSU
'
Me.ColumnZEIRITSU.HeaderText = "ZEI_RITSU"
Me.ColumnZEIRITSU.Name = "ZEIRITSU"
Me.ColumnZEIRITSU.ReadOnly = True
Me.ColumnZEIRITSU.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZEIRITSU.Width = 150
'
'ColumnGOKEIKINGAKU
'
Me.ColumnGOKEIKINGAKU.HeaderText = "GOKEI_KINGAKU"
Me.ColumnGOKEIKINGAKU.Name = "GOKEIKINGAKU"
Me.ColumnGOKEIKINGAKU.ReadOnly = True
Me.ColumnGOKEIKINGAKU.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnGOKEIKINGAKU.Width = 150
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
Me.MseDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ColumnCHUMONMEISAIID,ColumnCHUMONID,ColumnCHUMONMEISAINO,ColumnSHOHINCODE,ColumnSHOHINNAME,ColumnSURYO,ColumnTANKA,ColumnKINGAKU,ColumnSORYO,ColumnZEIRITSU,ColumnGOKEIKINGAKU,ColumnYUKOFLAG,ColumnLASTUPDATEUSER,ColumnLASTUPDATE,ColumnLASTUPDATEPROGRAM})
Me.MseDataGrid.DefaultActiveColLeft = 0
Me.MseDataGrid.DefaultActiveColRight = 2
Me.MseDataGrid.DefaultActiveRowBottom = 0
Me.MseDataGrid.DefaultActiveRowTop = 0
Me.MseDataGrid.EnableHeadersVisualStyles = False
Me.MseDataGrid.Location = New System.Drawing.Point(20, 230)
Me.MseDataGrid.MultiSelect = False
Me.MseDataGrid.Name = "MseDataGrid"
Me.MseDataGrid.ReadOnly = True
Me.MseDataGrid.RowHeadersWidth = 35
Me.MseDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
Me.MseDataGrid.RowTemplate.Height = 30
Me.MseDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.MseDataGrid.SheetMode = UI.Control.SheetMode.Display
Me.MseDataGrid.Size = New System.Drawing.Size(1190, 200)
Me.MseDataGrid.TabIndex = 15
'
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearch.Location = New System.Drawing.Point(24, 464)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 38)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = "F5：検　索"
        Me.btnSearch.UseVisualStyleBackColor = False
'
        'btnDataOutput
        '
        Me.btnDataOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnDataOutput.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnDataOutput.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnDataOutput.Location = New System.Drawing.Point(411, 464)
        Me.btnDataOutput.Name = "btnDataOutput"
        Me.btnDataOutput.Size = New System.Drawing.Size(120, 38)
        Me.btnDataOutput.TabIndex = 17
        Me.btnDataOutput.Text = "F7：データ出力"
        Me.btnDataOutput.UseVisualStyleBackColor = False
'
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnSelect.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSelect.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSelect.Location = New System.Drawing.Point(537, 464)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(120, 38)
        Me.btnSelect.TabIndex =  18
        Me.btnSelect.Text = "F9：選　択"
        Me.btnSelect.UseVisualStyleBackColor = False
'
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClear.Location = New System.Drawing.Point(663, 464)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 38)
        Me.btnClear.TabIndex = 19
        Me.btnClear.Text = "F11:クリア"
        Me.btnClear.UseVisualStyleBackColor = False
'
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Location = New System.Drawing.Point(789, 464)
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
        Me.Name = "ChumonMeisaiSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChumonMeisai検索"
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
        '　ChumonMeisaiId      
        Friend WithEvents lblChumonMeisaiId As MSELabel
        Friend WithEvents numChumonMeisaiId As MSEEdit
        Friend WithEvents ColumnChumonMeisaiId As DataGridViewTextBoxColumn

        '　ChumonId      
        Friend WithEvents lblChumonId As MSELabel
        Friend WithEvents numChumonId As MSEEdit
        Friend WithEvents ColumnChumonId As DataGridViewTextBoxColumn

        '　ChumonMeisaiNo      
        Friend WithEvents lblChumonMeisaiNo As MSELabel
        Friend WithEvents txtChumonMeisaiNo As MSEEdit
        Friend WithEvents ColumnChumonMeisaiNo As DataGridViewTextBoxColumn

        '　ShohinCode      
        Friend WithEvents lblShohinCode As MSELabel
        Friend WithEvents txtShohinCode As MSEEdit
        Friend WithEvents ColumnShohinCode As DataGridViewTextBoxColumn

        '　ShohinName      
        Friend WithEvents lblShohinName As MSELabel
        Friend WithEvents txtShohinName As MSEEdit
        Friend WithEvents ColumnShohinName As DataGridViewTextBoxColumn

        '　Suryo      
        Friend WithEvents lblSuryo As MSELabel
        Friend WithEvents numSuryo As MSEEdit
        Friend WithEvents ColumnSuryo As DataGridViewTextBoxColumn

        '　Tanka      
        Friend WithEvents lblTanka As MSELabel
        Friend WithEvents numTanka As MSEEdit
        Friend WithEvents ColumnTanka As DataGridViewTextBoxColumn

        '　Kingaku      
        Friend WithEvents lblKingaku As MSELabel
        Friend WithEvents numKingaku As MSEEdit
        Friend WithEvents ColumnKingaku As DataGridViewTextBoxColumn

        '　Soryo      
        Friend WithEvents lblSoryo As MSELabel
        Friend WithEvents numSoryo As MSEEdit
        Friend WithEvents ColumnSoryo As DataGridViewTextBoxColumn

        '　ZeiRitsu      
        Friend WithEvents lblZeiRitsu As MSELabel
        Friend WithEvents numZeiRitsu As MSEEdit
        Friend WithEvents ColumnZeiRitsu As DataGridViewTextBoxColumn

        '　GokeiKingaku      
        Friend WithEvents lblGokeiKingaku As MSELabel
        Friend WithEvents numGokeiKingaku As MSEEdit
        Friend WithEvents ColumnGokeiKingaku As DataGridViewTextBoxColumn

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
