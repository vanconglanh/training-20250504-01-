Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PermissionScreenSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PermissionScreenSearch))
        Me.lblTitle = New MSELabel()
        Me.btnClose = New MSEButton()
        Me.btnClear = New MSEButton()
        Me.btnSelect = New MSEButton()
        Me.btnDataOutput = New MSEButton()
        Me.btnSearch = New MSEButton()
        Me.MseDataGrid = New MSEDataGrid()
        '　Id
        Me.lblId = New MSELabel
        Me.numId = New MSEEdit()
        Me.ColumnId = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　PermissionId
        Me.lblPermissionId = New MSELabel
        Me.numPermissionId = New MSEEdit()
        Me.ColumnPermissionId = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　ScreenId
        Me.lblScreenId = New MSELabel
        Me.numScreenId = New MSEEdit()
        Me.ColumnScreenId = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Code
        Me.lblCode = New MSELabel
        Me.txtCode = New MSEEdit()
        Me.ColumnCode = New System.Windows.Forms.DataGridViewTextBoxColumn()

         '　CreatedAt
        Me.lblCreatedAt = New MSELabel
        Me.dteCreatedAt = New MSEDate()
        Me.ColumnCreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()

         '　UpdatedAt
        Me.lblUpdatedAt = New MSELabel
        Me.dteUpdatedAt = New MSEDate()
        Me.ColumnUpdatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　YukoFlag
        Me.lblYukoFlag = New MSELabel
        Me.txtYukoFlag = New MSEEdit()
        Me.ColumnYukoFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　CreatedUser
        Me.lblCreatedUser = New MSELabel
        Me.numCreatedUser = New MSEEdit()
        Me.ColumnCreatedUser = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　LastUpdateUser
        Me.lblLastUpdateUser = New MSELabel
        Me.numLastUpdateUser = New MSEEdit()
        Me.ColumnLastUpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()

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
        Me.lblTitle.Text = "PermissionScreen検索"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        
        'Generaete Init control
        Me.Controls.Add(Me.lblID)
Me.Controls.Add(Me.numID)
Me.Controls.Add(Me.lblPERMISSIONID)
Me.Controls.Add(Me.numPERMISSIONID)
Me.Controls.Add(Me.lblSCREENID)
Me.Controls.Add(Me.numSCREENID)
Me.Controls.Add(Me.lblCODE)
Me.Controls.Add(Me.txtCODE)
Me.Controls.Add(Me.lblCREATEDAT)
Me.Controls.Add(Me.dteCREATEDAT)
Me.Controls.Add(Me.lblUPDATEDAT)
Me.Controls.Add(Me.dteUPDATEDAT)
Me.Controls.Add(Me.lblYUKOFLAG)
Me.Controls.Add(Me.txtYUKOFLAG)
Me.Controls.Add(Me.lblCREATEDUSER)
Me.Controls.Add(Me.numCREATEDUSER)
Me.Controls.Add(Me.lblLASTUPDATEUSER)
Me.Controls.Add(Me.numLASTUPDATEUSER)
Me.Controls.Add(Me.lblLASTUPDATEPROGRAM)
Me.Controls.Add(Me.txtLASTUPDATEPROGRAM)
'
'lblID
'
Me.lblID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblID.ForeColor = System.Drawing.Color.White
Me.lblID.Location = New System.Drawing.Point(20, 60)
Me.lblID.Name = "lblID"
Me.lblID.Size = New System.Drawing.Size(170, 24)
Me.lblID.Text = "ID"
Me.lblID.Enabled = True
'
'numID
'
Me.numID.BackColor = System.Drawing.Color.White
Me.numID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numID.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numID.IsNextControl = True
Me.numID.IsUseFunctionKey = False
Me.numID.Location = New System.Drawing.Point(190, 60)
Me.numID.Size = New System.Drawing.Size(200, 24)
Me.numID.Name = "numID"
Me.numID.TabIndex = 0
Me.numID.Enabled = True
'
'lblPERMISSIONID
'
Me.lblPERMISSIONID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblPERMISSIONID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblPERMISSIONID.ForeColor = System.Drawing.Color.White
Me.lblPERMISSIONID.Location = New System.Drawing.Point(430, 60)
Me.lblPERMISSIONID.Name = "lblPERMISSIONID"
Me.lblPERMISSIONID.Size = New System.Drawing.Size(170, 24)
Me.lblPERMISSIONID.Text = "PERMISSION_ID"
Me.lblPERMISSIONID.Enabled = True
'
'numPERMISSIONID
'
Me.numPERMISSIONID.BackColor = System.Drawing.Color.White
Me.numPERMISSIONID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numPERMISSIONID.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numPERMISSIONID.IsNextControl = True
Me.numPERMISSIONID.IsUseFunctionKey = False
Me.numPERMISSIONID.Location = New System.Drawing.Point(600, 60)
Me.numPERMISSIONID.Size = New System.Drawing.Size(200, 24)
Me.numPERMISSIONID.Name = "numPERMISSIONID"
Me.numPERMISSIONID.TabIndex = 1
Me.numPERMISSIONID.Enabled = True
'
'lblSCREENID
'
Me.lblSCREENID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSCREENID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSCREENID.ForeColor = System.Drawing.Color.White
Me.lblSCREENID.Location = New System.Drawing.Point(840, 60)
Me.lblSCREENID.Name = "lblSCREENID"
Me.lblSCREENID.Size = New System.Drawing.Size(170, 24)
Me.lblSCREENID.Text = "SCREEN_ID"
Me.lblSCREENID.Enabled = True
'
'numSCREENID
'
Me.numSCREENID.BackColor = System.Drawing.Color.White
Me.numSCREENID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numSCREENID.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numSCREENID.IsNextControl = True
Me.numSCREENID.IsUseFunctionKey = False
Me.numSCREENID.Location = New System.Drawing.Point(1010, 60)
Me.numSCREENID.Size = New System.Drawing.Size(200, 24)
Me.numSCREENID.Name = "numSCREENID"
Me.numSCREENID.TabIndex = 2
Me.numSCREENID.Enabled = True
'
'lblCODE
'
Me.lblCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCODE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCODE.ForeColor = System.Drawing.Color.White
Me.lblCODE.Location = New System.Drawing.Point(20, 94)
Me.lblCODE.Name = "lblCODE"
Me.lblCODE.Size = New System.Drawing.Size(170, 24)
Me.lblCODE.Text = "CODE"
Me.lblCODE.Enabled = True
'
'txtCODE
'
Me.txtCODE.BackColor = System.Drawing.Color.White
Me.txtCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtCODE.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtCODE.IsNextControl = True
Me.txtCODE.IsUseFunctionKey = False
Me.txtCODE.Location = New System.Drawing.Point(190, 94)
Me.txtCODE.Size = New System.Drawing.Size(200, 24)
Me.txtCODE.Name = "txtCODE"
Me.txtCODE.TabIndex = 3
Me.txtCODE.Enabled = True
'
'lblCREATEDAT
'
Me.lblCREATEDAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCREATEDAT.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCREATEDAT.ForeColor = System.Drawing.Color.White
Me.lblCREATEDAT.Location = New System.Drawing.Point(430, 94)
Me.lblCREATEDAT.Name = "lblCREATEDAT"
Me.lblCREATEDAT.Size = New System.Drawing.Size(170, 24)
Me.lblCREATEDAT.Text = "CREATED_AT"
Me.lblCREATEDAT.Enabled = True
'
'dteCREATEDAT
'
Me.dteCREATEDAT.BackColor = System.Drawing.Color.White
Me.dteCREATEDAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteCREATEDAT.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteCREATEDAT.IsNextControl = True
Me.dteCREATEDAT.IsUseFunctionKey = False
Me.dteCREATEDAT.Location = New System.Drawing.Point(600, 94)
Me.dteCREATEDAT.Size = New System.Drawing.Size(200, 24)
Me.dteCREATEDAT.Name = "dteCREATEDAT"
Me.dteCREATEDAT.TabIndex = 4
Me.dteCREATEDAT.Enabled = True
'
'lblUPDATEDAT
'
Me.lblUPDATEDAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblUPDATEDAT.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblUPDATEDAT.ForeColor = System.Drawing.Color.White
Me.lblUPDATEDAT.Location = New System.Drawing.Point(840, 94)
Me.lblUPDATEDAT.Name = "lblUPDATEDAT"
Me.lblUPDATEDAT.Size = New System.Drawing.Size(170, 24)
Me.lblUPDATEDAT.Text = "UPDATED_AT"
Me.lblUPDATEDAT.Enabled = True
'
'dteUPDATEDAT
'
Me.dteUPDATEDAT.BackColor = System.Drawing.Color.White
Me.dteUPDATEDAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteUPDATEDAT.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteUPDATEDAT.IsNextControl = True
Me.dteUPDATEDAT.IsUseFunctionKey = False
Me.dteUPDATEDAT.Location = New System.Drawing.Point(1010, 94)
Me.dteUPDATEDAT.Size = New System.Drawing.Size(200, 24)
Me.dteUPDATEDAT.Name = "dteUPDATEDAT"
Me.dteUPDATEDAT.TabIndex = 5
Me.dteUPDATEDAT.Enabled = True
'
'lblYUKOFLAG
'
Me.lblYUKOFLAG.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblYUKOFLAG.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblYUKOFLAG.ForeColor = System.Drawing.Color.White
Me.lblYUKOFLAG.Location = New System.Drawing.Point(20, 128)
Me.lblYUKOFLAG.Name = "lblYUKOFLAG"
Me.lblYUKOFLAG.Size = New System.Drawing.Size(170, 24)
Me.lblYUKOFLAG.Text = "YUKO_FLAG"
Me.lblYUKOFLAG.Enabled = True
'
'txtYUKOFLAG
'
Me.txtYUKOFLAG.BackColor = System.Drawing.Color.White
Me.txtYUKOFLAG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtYUKOFLAG.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtYUKOFLAG.IsNextControl = True
Me.txtYUKOFLAG.IsUseFunctionKey = False
Me.txtYUKOFLAG.Location = New System.Drawing.Point(190, 128)
Me.txtYUKOFLAG.Size = New System.Drawing.Size(200, 24)
Me.txtYUKOFLAG.Name = "txtYUKOFLAG"
Me.txtYUKOFLAG.TabIndex = 6
Me.txtYUKOFLAG.Enabled = True
'
'lblCREATEDUSER
'
Me.lblCREATEDUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCREATEDUSER.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCREATEDUSER.ForeColor = System.Drawing.Color.White
Me.lblCREATEDUSER.Location = New System.Drawing.Point(430, 128)
Me.lblCREATEDUSER.Name = "lblCREATEDUSER"
Me.lblCREATEDUSER.Size = New System.Drawing.Size(170, 24)
Me.lblCREATEDUSER.Text = "CREATED_USER"
Me.lblCREATEDUSER.Enabled = True
'
'numCREATEDUSER
'
Me.numCREATEDUSER.BackColor = System.Drawing.Color.White
Me.numCREATEDUSER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numCREATEDUSER.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numCREATEDUSER.IsNextControl = True
Me.numCREATEDUSER.IsUseFunctionKey = False
Me.numCREATEDUSER.Location = New System.Drawing.Point(600, 128)
Me.numCREATEDUSER.Size = New System.Drawing.Size(200, 24)
Me.numCREATEDUSER.Name = "numCREATEDUSER"
Me.numCREATEDUSER.TabIndex = 7
Me.numCREATEDUSER.Enabled = True
'
'lblLASTUPDATEUSER
'
Me.lblLASTUPDATEUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEUSER.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEUSER.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEUSER.Location = New System.Drawing.Point(840, 128)
Me.lblLASTUPDATEUSER.Name = "lblLASTUPDATEUSER"
Me.lblLASTUPDATEUSER.Size = New System.Drawing.Size(170, 24)
Me.lblLASTUPDATEUSER.Text = "LAST_UPDATE_USER"
Me.lblLASTUPDATEUSER.Enabled = True
'
'numLASTUPDATEUSER
'
Me.numLASTUPDATEUSER.BackColor = System.Drawing.Color.White
Me.numLASTUPDATEUSER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numLASTUPDATEUSER.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numLASTUPDATEUSER.IsNextControl = True
Me.numLASTUPDATEUSER.IsUseFunctionKey = False
Me.numLASTUPDATEUSER.Location = New System.Drawing.Point(1010, 128)
Me.numLASTUPDATEUSER.Size = New System.Drawing.Size(200, 24)
Me.numLASTUPDATEUSER.Name = "numLASTUPDATEUSER"
Me.numLASTUPDATEUSER.TabIndex = 8
Me.numLASTUPDATEUSER.Enabled = True
'
'lblLASTUPDATEPROGRAM
'
Me.lblLASTUPDATEPROGRAM.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEPROGRAM.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEPROGRAM.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEPROGRAM.Location = New System.Drawing.Point(20, 162)
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
Me.txtLASTUPDATEPROGRAM.Location = New System.Drawing.Point(190, 162)
Me.txtLASTUPDATEPROGRAM.Size = New System.Drawing.Size(200, 24)
Me.txtLASTUPDATEPROGRAM.Name = "txtLASTUPDATEPROGRAM"
Me.txtLASTUPDATEPROGRAM.TabIndex = 9
Me.txtLASTUPDATEPROGRAM.Enabled = True
'
'ColumnID
'
Me.ColumnID.HeaderText = "ID"
Me.ColumnID.Name = "ID"
Me.ColumnID.ReadOnly = True
Me.ColumnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnID.Width = 150
'
'ColumnPERMISSIONID
'
Me.ColumnPERMISSIONID.HeaderText = "PERMISSION_ID"
Me.ColumnPERMISSIONID.Name = "PERMISSIONID"
Me.ColumnPERMISSIONID.ReadOnly = True
Me.ColumnPERMISSIONID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnPERMISSIONID.Width = 150
'
'ColumnSCREENID
'
Me.ColumnSCREENID.HeaderText = "SCREEN_ID"
Me.ColumnSCREENID.Name = "SCREENID"
Me.ColumnSCREENID.ReadOnly = True
Me.ColumnSCREENID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSCREENID.Width = 150
'
'ColumnCODE
'
Me.ColumnCODE.HeaderText = "CODE"
Me.ColumnCODE.Name = "CODE"
Me.ColumnCODE.ReadOnly = True
Me.ColumnCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCODE.Width = 150
'
'ColumnCREATEDAT
'
Me.ColumnCREATEDAT.HeaderText = "CREATED_AT"
Me.ColumnCREATEDAT.Name = "CREATEDAT"
Me.ColumnCREATEDAT.ReadOnly = True
Me.ColumnCREATEDAT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCREATEDAT.Width = 150
'
'ColumnUPDATEDAT
'
Me.ColumnUPDATEDAT.HeaderText = "UPDATED_AT"
Me.ColumnUPDATEDAT.Name = "UPDATEDAT"
Me.ColumnUPDATEDAT.ReadOnly = True
Me.ColumnUPDATEDAT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnUPDATEDAT.Width = 150
'
'ColumnYUKOFLAG
'
Me.ColumnYUKOFLAG.HeaderText = "YUKO_FLAG"
Me.ColumnYUKOFLAG.Name = "YUKOFLAG"
Me.ColumnYUKOFLAG.ReadOnly = True
Me.ColumnYUKOFLAG.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnYUKOFLAG.Width = 150
'
'ColumnCREATEDUSER
'
Me.ColumnCREATEDUSER.HeaderText = "CREATED_USER"
Me.ColumnCREATEDUSER.Name = "CREATEDUSER"
Me.ColumnCREATEDUSER.ReadOnly = True
Me.ColumnCREATEDUSER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCREATEDUSER.Width = 150
'
'ColumnLASTUPDATEUSER
'
Me.ColumnLASTUPDATEUSER.HeaderText = "LAST_UPDATE_USER"
Me.ColumnLASTUPDATEUSER.Name = "LASTUPDATEUSER"
Me.ColumnLASTUPDATEUSER.ReadOnly = True
Me.ColumnLASTUPDATEUSER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLASTUPDATEUSER.Width = 150
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
Me.MseDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ColumnID,ColumnPERMISSIONID,ColumnSCREENID,ColumnCODE,ColumnCREATEDAT,ColumnUPDATEDAT,ColumnYUKOFLAG,ColumnCREATEDUSER,ColumnLASTUPDATEUSER,ColumnLASTUPDATEPROGRAM})
Me.MseDataGrid.DefaultActiveColLeft = 0
Me.MseDataGrid.DefaultActiveColRight = 2
Me.MseDataGrid.DefaultActiveRowBottom = 0
Me.MseDataGrid.DefaultActiveRowTop = 0
Me.MseDataGrid.EnableHeadersVisualStyles = False
Me.MseDataGrid.Location = New System.Drawing.Point(20, 196)
Me.MseDataGrid.MultiSelect = False
Me.MseDataGrid.Name = "MseDataGrid"
Me.MseDataGrid.ReadOnly = True
Me.MseDataGrid.RowHeadersWidth = 35
Me.MseDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
Me.MseDataGrid.RowTemplate.Height = 30
Me.MseDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.MseDataGrid.SheetMode = UI.Control.SheetMode.Display
Me.MseDataGrid.Size = New System.Drawing.Size(1190, 200)
Me.MseDataGrid.TabIndex = 10
'
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearch.Location = New System.Drawing.Point(24, 430)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 38)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "F5：検　索"
        Me.btnSearch.UseVisualStyleBackColor = False
'
        'btnDataOutput
        '
        Me.btnDataOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnDataOutput.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnDataOutput.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnDataOutput.Location = New System.Drawing.Point(411, 430)
        Me.btnDataOutput.Name = "btnDataOutput"
        Me.btnDataOutput.Size = New System.Drawing.Size(120, 38)
        Me.btnDataOutput.TabIndex = 12
        Me.btnDataOutput.Text = "F7：データ出力"
        Me.btnDataOutput.UseVisualStyleBackColor = False
'
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnSelect.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSelect.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSelect.Location = New System.Drawing.Point(537, 430)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(120, 38)
        Me.btnSelect.TabIndex =  13
        Me.btnSelect.Text = "F9：選　択"
        Me.btnSelect.UseVisualStyleBackColor = False
'
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClear.Location = New System.Drawing.Point(663, 430)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 38)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "F11:クリア"
        Me.btnClear.UseVisualStyleBackColor = False
'
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Location = New System.Drawing.Point(789, 430)
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
        Me.Name = "PermissionScreenSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PermissionScreen検索"
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
        '　Id      
        Friend WithEvents lblId As MSELabel
        Friend WithEvents numId As MSEEdit
        Friend WithEvents ColumnId As DataGridViewTextBoxColumn

        '　PermissionId      
        Friend WithEvents lblPermissionId As MSELabel
        Friend WithEvents numPermissionId As MSEEdit
        Friend WithEvents ColumnPermissionId As DataGridViewTextBoxColumn

        '　ScreenId      
        Friend WithEvents lblScreenId As MSELabel
        Friend WithEvents numScreenId As MSEEdit
        Friend WithEvents ColumnScreenId As DataGridViewTextBoxColumn

        '　Code      
        Friend WithEvents lblCode As MSELabel
        Friend WithEvents txtCode As MSEEdit
        Friend WithEvents ColumnCode As DataGridViewTextBoxColumn

        '　CreatedAt        
        Friend WithEvents lblCreatedAt As MSELabel
        Friend WithEvents dteCreatedAt As MSEDate
        Friend WithEvents ColumnCreatedAt As DataGridViewTextBoxColumn

        '　UpdatedAt        
        Friend WithEvents lblUpdatedAt As MSELabel
        Friend WithEvents dteUpdatedAt As MSEDate
        Friend WithEvents ColumnUpdatedAt As DataGridViewTextBoxColumn

        '　YukoFlag      
        Friend WithEvents lblYukoFlag As MSELabel
        Friend WithEvents txtYukoFlag As MSEEdit
        Friend WithEvents ColumnYukoFlag As DataGridViewTextBoxColumn

        '　CreatedUser      
        Friend WithEvents lblCreatedUser As MSELabel
        Friend WithEvents numCreatedUser As MSEEdit
        Friend WithEvents ColumnCreatedUser As DataGridViewTextBoxColumn

        '　LastUpdateUser      
        Friend WithEvents lblLastUpdateUser As MSELabel
        Friend WithEvents numLastUpdateUser As MSEEdit
        Friend WithEvents ColumnLastUpdateUser As DataGridViewTextBoxColumn

        '　LastUpdateProgram      
        Friend WithEvents lblLastUpdateProgram As MSELabel
        Friend WithEvents txtLastUpdateProgram As MSEEdit
        Friend WithEvents ColumnLastUpdateProgram As DataGridViewTextBoxColumn


End Class
