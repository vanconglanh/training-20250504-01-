Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserSearch))
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

        '　Code
        Me.lblCode = New MSELabel
        Me.txtCode = New MSEEdit()
        Me.ColumnCode = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Name
        Me.lblName = New MSELabel
        Me.txtName = New MSEEdit()
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Email
        Me.lblEmail = New MSELabel
        Me.txtEmail = New MSEEdit()
        Me.ColumnEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　UserName
        Me.lblUserName = New MSELabel
        Me.txtUserName = New MSEEdit()
        Me.ColumnUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Language
        Me.lblLanguage = New MSELabel
        Me.txtLanguage = New MSEEdit()
        Me.ColumnLanguage = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　Password
        Me.lblPassword = New MSELabel
        Me.txtPassword = New MSEEdit()
        Me.ColumnPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　PasswordHash
        Me.lblPasswordHash = New MSELabel
        Me.txtPasswordHash = New MSEEdit()
        Me.ColumnPasswordHash = New System.Windows.Forms.DataGridViewTextBoxColumn()

        '　RoleId
        Me.lblRoleId = New MSELabel
        Me.numRoleId = New MSEEdit()
        Me.ColumnRoleId = New System.Windows.Forms.DataGridViewTextBoxColumn()

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
        Me.lblTitle.Text = "User検索"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        
        'Generaete Init control
        Me.Controls.Add(Me.lblID)
Me.Controls.Add(Me.numID)
Me.Controls.Add(Me.lblCODE)
Me.Controls.Add(Me.txtCODE)
Me.Controls.Add(Me.lblNAME)
Me.Controls.Add(Me.txtNAME)
Me.Controls.Add(Me.lblEMAIL)
Me.Controls.Add(Me.txtEMAIL)
Me.Controls.Add(Me.lblUSERNAME)
Me.Controls.Add(Me.txtUSERNAME)
Me.Controls.Add(Me.lblLANGUAGE)
Me.Controls.Add(Me.txtLANGUAGE)
Me.Controls.Add(Me.lblPASSWORD)
Me.Controls.Add(Me.txtPASSWORD)
Me.Controls.Add(Me.lblPASSWORDHASH)
Me.Controls.Add(Me.txtPASSWORDHASH)
Me.Controls.Add(Me.lblROLEID)
Me.Controls.Add(Me.numROLEID)
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
'lblCODE
'
Me.lblCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCODE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCODE.ForeColor = System.Drawing.Color.White
Me.lblCODE.Location = New System.Drawing.Point(430, 60)
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
Me.txtCODE.Location = New System.Drawing.Point(600, 60)
Me.txtCODE.Size = New System.Drawing.Size(200, 24)
Me.txtCODE.Name = "txtCODE"
Me.txtCODE.TabIndex = 1
Me.txtCODE.Enabled = True
'
'lblNAME
'
Me.lblNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblNAME.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblNAME.ForeColor = System.Drawing.Color.White
Me.lblNAME.Location = New System.Drawing.Point(840, 60)
Me.lblNAME.Name = "lblNAME"
Me.lblNAME.Size = New System.Drawing.Size(170, 24)
Me.lblNAME.Text = "NAME"
Me.lblNAME.Enabled = True
'
'txtNAME
'
Me.txtNAME.BackColor = System.Drawing.Color.White
Me.txtNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtNAME.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtNAME.IsNextControl = True
Me.txtNAME.IsUseFunctionKey = False
Me.txtNAME.Location = New System.Drawing.Point(1010, 60)
Me.txtNAME.Size = New System.Drawing.Size(200, 24)
Me.txtNAME.Name = "txtNAME"
Me.txtNAME.TabIndex = 2
Me.txtNAME.Enabled = True
'
'lblEMAIL
'
Me.lblEMAIL.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblEMAIL.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblEMAIL.ForeColor = System.Drawing.Color.White
Me.lblEMAIL.Location = New System.Drawing.Point(20, 94)
Me.lblEMAIL.Name = "lblEMAIL"
Me.lblEMAIL.Size = New System.Drawing.Size(170, 24)
Me.lblEMAIL.Text = "EMAIL"
Me.lblEMAIL.Enabled = True
'
'txtEMAIL
'
Me.txtEMAIL.BackColor = System.Drawing.Color.White
Me.txtEMAIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtEMAIL.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtEMAIL.IsNextControl = True
Me.txtEMAIL.IsUseFunctionKey = False
Me.txtEMAIL.Location = New System.Drawing.Point(190, 94)
Me.txtEMAIL.Size = New System.Drawing.Size(200, 24)
Me.txtEMAIL.Name = "txtEMAIL"
Me.txtEMAIL.TabIndex = 3
Me.txtEMAIL.Enabled = True
'
'lblUSERNAME
'
Me.lblUSERNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblUSERNAME.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblUSERNAME.ForeColor = System.Drawing.Color.White
Me.lblUSERNAME.Location = New System.Drawing.Point(430, 94)
Me.lblUSERNAME.Name = "lblUSERNAME"
Me.lblUSERNAME.Size = New System.Drawing.Size(170, 24)
Me.lblUSERNAME.Text = "USER_NAME"
Me.lblUSERNAME.Enabled = True
'
'txtUSERNAME
'
Me.txtUSERNAME.BackColor = System.Drawing.Color.White
Me.txtUSERNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtUSERNAME.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtUSERNAME.IsNextControl = True
Me.txtUSERNAME.IsUseFunctionKey = False
Me.txtUSERNAME.Location = New System.Drawing.Point(600, 94)
Me.txtUSERNAME.Size = New System.Drawing.Size(200, 24)
Me.txtUSERNAME.Name = "txtUSERNAME"
Me.txtUSERNAME.TabIndex = 4
Me.txtUSERNAME.Enabled = True
'
'lblLANGUAGE
'
Me.lblLANGUAGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLANGUAGE.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLANGUAGE.ForeColor = System.Drawing.Color.White
Me.lblLANGUAGE.Location = New System.Drawing.Point(840, 94)
Me.lblLANGUAGE.Name = "lblLANGUAGE"
Me.lblLANGUAGE.Size = New System.Drawing.Size(170, 24)
Me.lblLANGUAGE.Text = "LANGUAGE"
Me.lblLANGUAGE.Enabled = True
'
'txtLANGUAGE
'
Me.txtLANGUAGE.BackColor = System.Drawing.Color.White
Me.txtLANGUAGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtLANGUAGE.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtLANGUAGE.IsNextControl = True
Me.txtLANGUAGE.IsUseFunctionKey = False
Me.txtLANGUAGE.Location = New System.Drawing.Point(1010, 94)
Me.txtLANGUAGE.Size = New System.Drawing.Size(200, 24)
Me.txtLANGUAGE.Name = "txtLANGUAGE"
Me.txtLANGUAGE.TabIndex = 5
Me.txtLANGUAGE.Enabled = True
'
'lblPASSWORD
'
Me.lblPASSWORD.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblPASSWORD.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblPASSWORD.ForeColor = System.Drawing.Color.White
Me.lblPASSWORD.Location = New System.Drawing.Point(20, 128)
Me.lblPASSWORD.Name = "lblPASSWORD"
Me.lblPASSWORD.Size = New System.Drawing.Size(170, 24)
Me.lblPASSWORD.Text = "PASSWORD"
Me.lblPASSWORD.Enabled = True
'
'txtPASSWORD
'
Me.txtPASSWORD.BackColor = System.Drawing.Color.White
Me.txtPASSWORD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtPASSWORD.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtPASSWORD.IsNextControl = True
Me.txtPASSWORD.IsUseFunctionKey = False
Me.txtPASSWORD.Location = New System.Drawing.Point(190, 128)
Me.txtPASSWORD.Size = New System.Drawing.Size(200, 24)
Me.txtPASSWORD.Name = "txtPASSWORD"
Me.txtPASSWORD.TabIndex = 6
Me.txtPASSWORD.Enabled = True
'
'lblPASSWORDHASH
'
Me.lblPASSWORDHASH.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblPASSWORDHASH.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblPASSWORDHASH.ForeColor = System.Drawing.Color.White
Me.lblPASSWORDHASH.Location = New System.Drawing.Point(430, 128)
Me.lblPASSWORDHASH.Name = "lblPASSWORDHASH"
Me.lblPASSWORDHASH.Size = New System.Drawing.Size(170, 24)
Me.lblPASSWORDHASH.Text = "PASSWORD_HASH"
Me.lblPASSWORDHASH.Enabled = True
'
'txtPASSWORDHASH
'
Me.txtPASSWORDHASH.BackColor = System.Drawing.Color.White
Me.txtPASSWORDHASH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtPASSWORDHASH.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtPASSWORDHASH.IsNextControl = True
Me.txtPASSWORDHASH.IsUseFunctionKey = False
Me.txtPASSWORDHASH.Location = New System.Drawing.Point(600, 128)
Me.txtPASSWORDHASH.Size = New System.Drawing.Size(200, 24)
Me.txtPASSWORDHASH.Name = "txtPASSWORDHASH"
Me.txtPASSWORDHASH.TabIndex = 7
Me.txtPASSWORDHASH.Enabled = True
'
'lblROLEID
'
Me.lblROLEID.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblROLEID.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblROLEID.ForeColor = System.Drawing.Color.White
Me.lblROLEID.Location = New System.Drawing.Point(840, 128)
Me.lblROLEID.Name = "lblROLEID"
Me.lblROLEID.Size = New System.Drawing.Size(170, 24)
Me.lblROLEID.Text = "ROLE_ID"
Me.lblROLEID.Enabled = True
'
'numROLEID
'
Me.numROLEID.BackColor = System.Drawing.Color.White
Me.numROLEID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numROLEID.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numROLEID.IsNextControl = True
Me.numROLEID.IsUseFunctionKey = False
Me.numROLEID.Location = New System.Drawing.Point(1010, 128)
Me.numROLEID.Size = New System.Drawing.Size(200, 24)
Me.numROLEID.Name = "numROLEID"
Me.numROLEID.TabIndex = 8
Me.numROLEID.Enabled = True
'
'lblCREATEDAT
'
Me.lblCREATEDAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCREATEDAT.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCREATEDAT.ForeColor = System.Drawing.Color.White
Me.lblCREATEDAT.Location = New System.Drawing.Point(20, 162)
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
Me.dteCREATEDAT.Location = New System.Drawing.Point(190, 162)
Me.dteCREATEDAT.Size = New System.Drawing.Size(200, 24)
Me.dteCREATEDAT.Name = "dteCREATEDAT"
Me.dteCREATEDAT.TabIndex = 9
Me.dteCREATEDAT.Enabled = True
'
'lblUPDATEDAT
'
Me.lblUPDATEDAT.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblUPDATEDAT.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblUPDATEDAT.ForeColor = System.Drawing.Color.White
Me.lblUPDATEDAT.Location = New System.Drawing.Point(430, 162)
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
Me.dteUPDATEDAT.Location = New System.Drawing.Point(600, 162)
Me.dteUPDATEDAT.Size = New System.Drawing.Size(200, 24)
Me.dteUPDATEDAT.Name = "dteUPDATEDAT"
Me.dteUPDATEDAT.TabIndex = 10
Me.dteUPDATEDAT.Enabled = True
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
'txtYUKOFLAG
'
Me.txtYUKOFLAG.BackColor = System.Drawing.Color.White
Me.txtYUKOFLAG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtYUKOFLAG.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtYUKOFLAG.IsNextControl = True
Me.txtYUKOFLAG.IsUseFunctionKey = False
Me.txtYUKOFLAG.Location = New System.Drawing.Point(1010, 162)
Me.txtYUKOFLAG.Size = New System.Drawing.Size(200, 24)
Me.txtYUKOFLAG.Name = "txtYUKOFLAG"
Me.txtYUKOFLAG.TabIndex = 11
Me.txtYUKOFLAG.Enabled = True
'
'lblCREATEDUSER
'
Me.lblCREATEDUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCREATEDUSER.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCREATEDUSER.ForeColor = System.Drawing.Color.White
Me.lblCREATEDUSER.Location = New System.Drawing.Point(20, 196)
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
Me.numCREATEDUSER.Location = New System.Drawing.Point(190, 196)
Me.numCREATEDUSER.Size = New System.Drawing.Size(200, 24)
Me.numCREATEDUSER.Name = "numCREATEDUSER"
Me.numCREATEDUSER.TabIndex = 12
Me.numCREATEDUSER.Enabled = True
'
'lblLASTUPDATEUSER
'
Me.lblLASTUPDATEUSER.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLASTUPDATEUSER.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLASTUPDATEUSER.ForeColor = System.Drawing.Color.White
Me.lblLASTUPDATEUSER.Location = New System.Drawing.Point(430, 196)
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
Me.numLASTUPDATEUSER.Location = New System.Drawing.Point(600, 196)
Me.numLASTUPDATEUSER.Size = New System.Drawing.Size(200, 24)
Me.numLASTUPDATEUSER.Name = "numLASTUPDATEUSER"
Me.numLASTUPDATEUSER.TabIndex = 13
Me.numLASTUPDATEUSER.Enabled = True
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
'ColumnID
'
Me.ColumnID.HeaderText = "ID"
Me.ColumnID.Name = "ID"
Me.ColumnID.ReadOnly = True
Me.ColumnID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnID.Width = 150
'
'ColumnCODE
'
Me.ColumnCODE.HeaderText = "CODE"
Me.ColumnCODE.Name = "CODE"
Me.ColumnCODE.ReadOnly = True
Me.ColumnCODE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCODE.Width = 150
'
'ColumnNAME
'
Me.ColumnNAME.HeaderText = "NAME"
Me.ColumnNAME.Name = "NAME"
Me.ColumnNAME.ReadOnly = True
Me.ColumnNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnNAME.Width = 150
'
'ColumnEMAIL
'
Me.ColumnEMAIL.HeaderText = "EMAIL"
Me.ColumnEMAIL.Name = "EMAIL"
Me.ColumnEMAIL.ReadOnly = True
Me.ColumnEMAIL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnEMAIL.Width = 150
'
'ColumnUSERNAME
'
Me.ColumnUSERNAME.HeaderText = "USER_NAME"
Me.ColumnUSERNAME.Name = "USERNAME"
Me.ColumnUSERNAME.ReadOnly = True
Me.ColumnUSERNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnUSERNAME.Width = 150
'
'ColumnLANGUAGE
'
Me.ColumnLANGUAGE.HeaderText = "LANGUAGE"
Me.ColumnLANGUAGE.Name = "LANGUAGE"
Me.ColumnLANGUAGE.ReadOnly = True
Me.ColumnLANGUAGE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLANGUAGE.Width = 150
'
'ColumnPASSWORD
'
Me.ColumnPASSWORD.HeaderText = "PASSWORD"
Me.ColumnPASSWORD.Name = "PASSWORD"
Me.ColumnPASSWORD.ReadOnly = True
Me.ColumnPASSWORD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnPASSWORD.Width = 150
'
'ColumnPASSWORDHASH
'
Me.ColumnPASSWORDHASH.HeaderText = "PASSWORD_HASH"
Me.ColumnPASSWORDHASH.Name = "PASSWORDHASH"
Me.ColumnPASSWORDHASH.ReadOnly = True
Me.ColumnPASSWORDHASH.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnPASSWORDHASH.Width = 150
'
'ColumnROLEID
'
Me.ColumnROLEID.HeaderText = "ROLE_ID"
Me.ColumnROLEID.Name = "ROLEID"
Me.ColumnROLEID.ReadOnly = True
Me.ColumnROLEID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnROLEID.Width = 150
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
Me.MseDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ColumnID,ColumnCODE,ColumnNAME,ColumnEMAIL,ColumnUSERNAME,ColumnLANGUAGE,ColumnPASSWORD,ColumnPASSWORDHASH,ColumnROLEID,ColumnCREATEDAT,ColumnUPDATEDAT,ColumnYUKOFLAG,ColumnCREATEDUSER,ColumnLASTUPDATEUSER,ColumnLASTUPDATEPROGRAM})
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
        Me.Name = "UserSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User検索"
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

        '　Code      
        Friend WithEvents lblCode As MSELabel
        Friend WithEvents txtCode As MSEEdit
        Friend WithEvents ColumnCode As DataGridViewTextBoxColumn

        '　Name      
        Friend WithEvents lblName As MSELabel
        Friend WithEvents txtName As MSEEdit
        Friend WithEvents ColumnName As DataGridViewTextBoxColumn

        '　Email      
        Friend WithEvents lblEmail As MSELabel
        Friend WithEvents txtEmail As MSEEdit
        Friend WithEvents ColumnEmail As DataGridViewTextBoxColumn

        '　UserName      
        Friend WithEvents lblUserName As MSELabel
        Friend WithEvents txtUserName As MSEEdit
        Friend WithEvents ColumnUserName As DataGridViewTextBoxColumn

        '　Language      
        Friend WithEvents lblLanguage As MSELabel
        Friend WithEvents txtLanguage As MSEEdit
        Friend WithEvents ColumnLanguage As DataGridViewTextBoxColumn

        '　Password      
        Friend WithEvents lblPassword As MSELabel
        Friend WithEvents txtPassword As MSEEdit
        Friend WithEvents ColumnPassword As DataGridViewTextBoxColumn

        '　PasswordHash      
        Friend WithEvents lblPasswordHash As MSELabel
        Friend WithEvents txtPasswordHash As MSEEdit
        Friend WithEvents ColumnPasswordHash As DataGridViewTextBoxColumn

        '　RoleId      
        Friend WithEvents lblRoleId As MSELabel
        Friend WithEvents numRoleId As MSEEdit
        Friend WithEvents ColumnRoleId As DataGridViewTextBoxColumn

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
