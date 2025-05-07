Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RoleEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RoleEntry))
        lblTitle = New MSELabel()
        btnClose = New MSEButton()
        btnClear = New MSEButton()
        btnDelete = New MSEButton()
        btnSave = New MSEButton()
 
        Me.MseDataGridRolePermission = New MSEDataGrid()
        '　Id
        Me.lblId = New MSELabel
        Me.numId = New MSEEdit()
        '　Code
        Me.lblCode = New MSELabel
        Me.txtCode = New MSEEdit()
        '　Name
        Me.lblName = New MSELabel
        Me.txtName = New MSEEdit()
        '　IsSystem
        Me.lblIsSystem = New MSELabel
        Me.numIsSystem = New MSEEdit()
         '　CreatedAt
        Me.lblCreatedAt = New MSELabel
        Me.dteCreatedAt = New MSEDate()
         '　UpdatedAt
        Me.lblUpdatedAt = New MSELabel
        Me.dteUpdatedAt = New MSEDate()
        '　YukoFlag
        Me.lblYukoFlag = New MSELabel
        Me.txtYukoFlag = New MSEEdit()
        '　CreatedUser
        Me.lblCreatedUser = New MSELabel
        Me.numCreatedUser = New MSEEdit()
        '　LastUpdateUser
        Me.lblLastUpdateUser = New MSELabel
        Me.numLastUpdateUser = New MSEEdit()
        '　LastUpdateProgram
        Me.lblLastUpdateProgram = New MSELabel
        Me.txtLastUpdateProgram = New MSEEdit()
        
                        '　RoleId      
                Me.ColumnRoleId = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　PermissionScreenId      
                Me.ColumnPermissionScreenId = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　Code      
                Me.ColumnCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　CreatedAt        
                Me.ColumnCreatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　UpdatedAt        
                Me.ColumnUpdatedAt = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　YukoFlag      
                Me.ColumnYukoFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　CreatedUser      
                Me.ColumnCreatedUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　LastUpdateUser      
                Me.ColumnLastUpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　LastUpdateProgram      
                Me.ColumnLastUpdateProgram = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MseDataGridRolePermission, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.FromArgb(CByte(165), CByte(0), CByte(130))
        lblTitle.Font = New Font("Meiryo UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(128))
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(23, 25)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(432, 38)
        lblTitle.TabIndex = 24
        lblTitle.Text = "Role検索"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        'Generaete Init control
        Me.Controls.Add(Me.lblId)
Me.Controls.Add(Me.numId)
Me.Controls.Add(Me.lblCode)
Me.Controls.Add(Me.txtCode)
Me.Controls.Add(Me.lblName)
Me.Controls.Add(Me.txtName)
Me.Controls.Add(Me.lblIsSystem)
Me.Controls.Add(Me.numIsSystem)
Me.Controls.Add(Me.lblCreatedAt)
Me.Controls.Add(Me.dteCreatedAt)
Me.Controls.Add(Me.lblUpdatedAt)
Me.Controls.Add(Me.dteUpdatedAt)
Me.Controls.Add(Me.lblYukoFlag)
Me.Controls.Add(Me.txtYukoFlag)
Me.Controls.Add(Me.lblCreatedUser)
Me.Controls.Add(Me.numCreatedUser)
Me.Controls.Add(Me.lblLastUpdateUser)
Me.Controls.Add(Me.numLastUpdateUser)
Me.Controls.Add(Me.lblLastUpdateProgram)
Me.Controls.Add(Me.txtLastUpdateProgram)
Me.Controls.Add(Me.lblId)
Me.Controls.Add(Me.numId)
Me.Controls.Add(Me.lblCode)
Me.Controls.Add(Me.txtCode)
Me.Controls.Add(Me.lblName)
Me.Controls.Add(Me.txtName)
Me.Controls.Add(Me.lblIsSystem)
Me.Controls.Add(Me.numIsSystem)
Me.Controls.Add(Me.lblCreatedAt)
Me.Controls.Add(Me.dteCreatedAt)
Me.Controls.Add(Me.lblUpdatedAt)
Me.Controls.Add(Me.dteUpdatedAt)
Me.Controls.Add(Me.lblYukoFlag)
Me.Controls.Add(Me.txtYukoFlag)
Me.Controls.Add(Me.lblCreatedUser)
Me.Controls.Add(Me.numCreatedUser)
Me.Controls.Add(Me.lblLastUpdateUser)
Me.Controls.Add(Me.numLastUpdateUser)
Me.Controls.Add(Me.lblLastUpdateProgram)
Me.Controls.Add(Me.txtLastUpdateProgram)
'
'lblId
'
Me.lblId.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblId.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblId.ForeColor = System.Drawing.Color.White
Me.lblId.Location = New System.Drawing.Point(20, 60)
Me.lblId.Name = "lblId"
Me.lblId.Size = New System.Drawing.Size(170, 24)
Me.lblId.Text = "id"
Me.lblId.Enabled = True
'
'numId
'
Me.numId.BackColor = System.Drawing.Color.White
Me.numId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numId.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numId.IsNextControl = True
Me.numId.IsUseFunctionKey = False
Me.numId.Location = New System.Drawing.Point(190, 60)
Me.numId.Size = New System.Drawing.Size(200, 24)
Me.numId.Name = "numId"
Me.numId.TabIndex = 0
Me.numId.Enabled = True
'
'lblCode
'
Me.lblCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCode.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCode.ForeColor = System.Drawing.Color.White
Me.lblCode.Location = New System.Drawing.Point(430, 60)
Me.lblCode.Name = "lblCode"
Me.lblCode.Size = New System.Drawing.Size(170, 24)
Me.lblCode.Text = "code"
Me.lblCode.Enabled = True
'
'txtCode
'
Me.txtCode.BackColor = System.Drawing.Color.White
Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtCode.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtCode.IsNextControl = True
Me.txtCode.IsUseFunctionKey = False
Me.txtCode.Location = New System.Drawing.Point(600, 60)
Me.txtCode.Size = New System.Drawing.Size(200, 24)
Me.txtCode.Name = "txtCode"
Me.txtCode.TabIndex = 1
Me.txtCode.Enabled = True
'
'lblName
'
Me.lblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblName.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblName.ForeColor = System.Drawing.Color.White
Me.lblName.Location = New System.Drawing.Point(840, 60)
Me.lblName.Name = "lblName"
Me.lblName.Size = New System.Drawing.Size(170, 24)
Me.lblName.Text = "name"
Me.lblName.Enabled = True
'
'txtName
'
Me.txtName.BackColor = System.Drawing.Color.White
Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtName.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtName.IsNextControl = True
Me.txtName.IsUseFunctionKey = False
Me.txtName.Location = New System.Drawing.Point(1010, 60)
Me.txtName.Size = New System.Drawing.Size(200, 24)
Me.txtName.Name = "txtName"
Me.txtName.TabIndex = 2
Me.txtName.Enabled = True
'
'lblIsSystem
'
Me.lblIsSystem.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblIsSystem.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblIsSystem.ForeColor = System.Drawing.Color.White
Me.lblIsSystem.Location = New System.Drawing.Point(20, 94)
Me.lblIsSystem.Name = "lblIsSystem"
Me.lblIsSystem.Size = New System.Drawing.Size(170, 24)
Me.lblIsSystem.Text = "is_system"
Me.lblIsSystem.Enabled = True
'
'numIsSystem
'
Me.numIsSystem.BackColor = System.Drawing.Color.White
Me.numIsSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numIsSystem.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numIsSystem.IsNextControl = True
Me.numIsSystem.IsUseFunctionKey = False
Me.numIsSystem.Location = New System.Drawing.Point(190, 94)
Me.numIsSystem.Size = New System.Drawing.Size(200, 24)
Me.numIsSystem.Name = "numIsSystem"
Me.numIsSystem.TabIndex = 3
Me.numIsSystem.Enabled = True
'
'lblCreatedAt
'
Me.lblCreatedAt.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCreatedAt.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCreatedAt.ForeColor = System.Drawing.Color.White
Me.lblCreatedAt.Location = New System.Drawing.Point(430, 94)
Me.lblCreatedAt.Name = "lblCreatedAt"
Me.lblCreatedAt.Size = New System.Drawing.Size(170, 24)
Me.lblCreatedAt.Text = "created_at"
Me.lblCreatedAt.Enabled = True
'
'dteCreatedAt
'
Me.dteCreatedAt.BackColor = System.Drawing.Color.White
Me.dteCreatedAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteCreatedAt.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteCreatedAt.IsNextControl = True
Me.dteCreatedAt.IsUseFunctionKey = False
Me.dteCreatedAt.Location = New System.Drawing.Point(600, 94)
Me.dteCreatedAt.Size = New System.Drawing.Size(200, 24)
Me.dteCreatedAt.Name = "dteCreatedAt"
Me.dteCreatedAt.TabIndex = 4
Me.dteCreatedAt.Enabled = True
'
'lblUpdatedAt
'
Me.lblUpdatedAt.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblUpdatedAt.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblUpdatedAt.ForeColor = System.Drawing.Color.White
Me.lblUpdatedAt.Location = New System.Drawing.Point(840, 94)
Me.lblUpdatedAt.Name = "lblUpdatedAt"
Me.lblUpdatedAt.Size = New System.Drawing.Size(170, 24)
Me.lblUpdatedAt.Text = "updated_at"
Me.lblUpdatedAt.Enabled = True
'
'dteUpdatedAt
'
Me.dteUpdatedAt.BackColor = System.Drawing.Color.White
Me.dteUpdatedAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteUpdatedAt.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteUpdatedAt.IsNextControl = True
Me.dteUpdatedAt.IsUseFunctionKey = False
Me.dteUpdatedAt.Location = New System.Drawing.Point(1010, 94)
Me.dteUpdatedAt.Size = New System.Drawing.Size(200, 24)
Me.dteUpdatedAt.Name = "dteUpdatedAt"
Me.dteUpdatedAt.TabIndex = 5
Me.dteUpdatedAt.Enabled = True
'
'lblYukoFlag
'
Me.lblYukoFlag.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblYukoFlag.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblYukoFlag.ForeColor = System.Drawing.Color.White
Me.lblYukoFlag.Location = New System.Drawing.Point(20, 128)
Me.lblYukoFlag.Name = "lblYukoFlag"
Me.lblYukoFlag.Size = New System.Drawing.Size(170, 24)
Me.lblYukoFlag.Text = "yuko_flag"
Me.lblYukoFlag.Enabled = True
'
'txtYukoFlag
'
Me.txtYukoFlag.BackColor = System.Drawing.Color.White
Me.txtYukoFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtYukoFlag.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtYukoFlag.IsNextControl = True
Me.txtYukoFlag.IsUseFunctionKey = False
Me.txtYukoFlag.Location = New System.Drawing.Point(190, 128)
Me.txtYukoFlag.Size = New System.Drawing.Size(200, 24)
Me.txtYukoFlag.Name = "txtYukoFlag"
Me.txtYukoFlag.TabIndex = 6
Me.txtYukoFlag.Enabled = True
'
'lblCreatedUser
'
Me.lblCreatedUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblCreatedUser.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblCreatedUser.ForeColor = System.Drawing.Color.White
Me.lblCreatedUser.Location = New System.Drawing.Point(430, 128)
Me.lblCreatedUser.Name = "lblCreatedUser"
Me.lblCreatedUser.Size = New System.Drawing.Size(170, 24)
Me.lblCreatedUser.Text = "created_user"
Me.lblCreatedUser.Enabled = True
'
'numCreatedUser
'
Me.numCreatedUser.BackColor = System.Drawing.Color.White
Me.numCreatedUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numCreatedUser.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numCreatedUser.IsNextControl = True
Me.numCreatedUser.IsUseFunctionKey = False
Me.numCreatedUser.Location = New System.Drawing.Point(600, 128)
Me.numCreatedUser.Size = New System.Drawing.Size(200, 24)
Me.numCreatedUser.Name = "numCreatedUser"
Me.numCreatedUser.TabIndex = 7
Me.numCreatedUser.Enabled = True
'
'lblLastUpdateUser
'
Me.lblLastUpdateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdateUser.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdateUser.ForeColor = System.Drawing.Color.White
Me.lblLastUpdateUser.Location = New System.Drawing.Point(840, 128)
Me.lblLastUpdateUser.Name = "lblLastUpdateUser"
Me.lblLastUpdateUser.Size = New System.Drawing.Size(170, 24)
Me.lblLastUpdateUser.Text = "last_update_user"
Me.lblLastUpdateUser.Enabled = True
'
'numLastUpdateUser
'
Me.numLastUpdateUser.BackColor = System.Drawing.Color.White
Me.numLastUpdateUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numLastUpdateUser.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numLastUpdateUser.IsNextControl = True
Me.numLastUpdateUser.IsUseFunctionKey = False
Me.numLastUpdateUser.Location = New System.Drawing.Point(1010, 128)
Me.numLastUpdateUser.Size = New System.Drawing.Size(200, 24)
Me.numLastUpdateUser.Name = "numLastUpdateUser"
Me.numLastUpdateUser.TabIndex = 8
Me.numLastUpdateUser.Enabled = True
'
'lblLastUpdateProgram
'
Me.lblLastUpdateProgram.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdateProgram.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdateProgram.ForeColor = System.Drawing.Color.White
Me.lblLastUpdateProgram.Location = New System.Drawing.Point(20, 162)
Me.lblLastUpdateProgram.Name = "lblLastUpdateProgram"
Me.lblLastUpdateProgram.Size = New System.Drawing.Size(170, 24)
Me.lblLastUpdateProgram.Text = "last_update_program"
Me.lblLastUpdateProgram.Enabled = True
'
'txtLastUpdateProgram
'
Me.txtLastUpdateProgram.BackColor = System.Drawing.Color.White
Me.txtLastUpdateProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtLastUpdateProgram.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtLastUpdateProgram.IsNextControl = True
Me.txtLastUpdateProgram.IsUseFunctionKey = False
Me.txtLastUpdateProgram.Location = New System.Drawing.Point(190, 162)
Me.txtLastUpdateProgram.Size = New System.Drawing.Size(200, 24)
Me.txtLastUpdateProgram.Name = "txtLastUpdateProgram"
Me.txtLastUpdateProgram.TabIndex = 9
Me.txtLastUpdateProgram.Enabled = True
'
'ColumnRoleId
'
Me.ColumnRoleId.HeaderText = "role_id"
Me.ColumnRoleId.Name = "RoleId"
Me.ColumnRoleId.ReadOnly = True
Me.ColumnRoleId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnRoleId.Width = 150
'
'ColumnPermissionScreenId
'
Me.ColumnPermissionScreenId.HeaderText = "permission_screen_id"
Me.ColumnPermissionScreenId.Name = "PermissionScreenId"
Me.ColumnPermissionScreenId.ReadOnly = True
Me.ColumnPermissionScreenId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnPermissionScreenId.Width = 150
'
'ColumnCode
'
Me.ColumnCode.HeaderText = "code"
Me.ColumnCode.Name = "Code"
Me.ColumnCode.ReadOnly = True
Me.ColumnCode.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCode.Width = 150
'
'ColumnCreatedAt
'
Me.ColumnCreatedAt.HeaderText = "created_at"
Me.ColumnCreatedAt.Name = "CreatedAt"
Me.ColumnCreatedAt.ReadOnly = True
Me.ColumnCreatedAt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCreatedAt.Width = 150
'
'ColumnUpdatedAt
'
Me.ColumnUpdatedAt.HeaderText = "updated_at"
Me.ColumnUpdatedAt.Name = "UpdatedAt"
Me.ColumnUpdatedAt.ReadOnly = True
Me.ColumnUpdatedAt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnUpdatedAt.Width = 150
'
'ColumnYukoFlag
'
Me.ColumnYukoFlag.HeaderText = "yuko_flag"
Me.ColumnYukoFlag.Name = "YukoFlag"
Me.ColumnYukoFlag.ReadOnly = True
Me.ColumnYukoFlag.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnYukoFlag.Width = 150
'
'ColumnCreatedUser
'
Me.ColumnCreatedUser.HeaderText = "created_user"
Me.ColumnCreatedUser.Name = "CreatedUser"
Me.ColumnCreatedUser.ReadOnly = True
Me.ColumnCreatedUser.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnCreatedUser.Width = 150
'
'ColumnLastUpdateUser
'
Me.ColumnLastUpdateUser.HeaderText = "last_update_user"
Me.ColumnLastUpdateUser.Name = "LastUpdateUser"
Me.ColumnLastUpdateUser.ReadOnly = True
Me.ColumnLastUpdateUser.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLastUpdateUser.Width = 150
'
'ColumnLastUpdateProgram
'
Me.ColumnLastUpdateProgram.HeaderText = "last_update_program"
Me.ColumnLastUpdateProgram.Name = "LastUpdateProgram"
Me.ColumnLastUpdateProgram.ReadOnly = True
Me.ColumnLastUpdateProgram.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLastUpdateProgram.Width = 150
'
'MseDataGridRolePermission
'
Me.MseDataGridRolePermission.AllowUserToAddRows = False
Me.MseDataGridRolePermission.AllowUserToDeleteRows = False
Me.MseDataGridRolePermission.AllowUserToResizeRows = False
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.MseDataGridRolePermission.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.MseDataGridRolePermission.ColumnHeadersHeight = 30
Me.MseDataGridRolePermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
Me.MseDataGridRolePermission.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ColumnRoleId,ColumnPermissionScreenId,ColumnCode,ColumnCreatedAt,ColumnUpdatedAt,ColumnYukoFlag,ColumnCreatedUser,ColumnLastUpdateUser,ColumnLastUpdateProgram})
Me.MseDataGridRolePermission.DefaultActiveColLeft = 0
Me.MseDataGridRolePermission.DefaultActiveColRight = 2
Me.MseDataGridRolePermission.DefaultActiveRowBottom = 0
Me.MseDataGridRolePermission.DefaultActiveRowTop = 0
Me.MseDataGridRolePermission.EnableHeadersVisualStyles = False
Me.MseDataGridRolePermission.Location = New System.Drawing.Point(20, 196)
Me.MseDataGridRolePermission.MultiSelect = False
Me.MseDataGridRolePermission.Name = "MseDataGridRolePermission"
Me.MseDataGridRolePermission.ReadOnly = True
Me.MseDataGridRolePermission.RowHeadersWidth = 35
Me.MseDataGridRolePermission.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
Me.MseDataGridRolePermission.RowTemplate.Height = 30
Me.MseDataGridRolePermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.MseDataGridRolePermission.SheetMode = UI.Control.SheetMode.Display
Me.MseDataGridRolePermission.Size = New System.Drawing.Size(1190, 200)
Me.MseDataGridRolePermission.TabIndex = 10
'
'btnSave
'
Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnSave.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnSave.Location = New System.Drawing.Point(660, 430)
Me.btnSave.Name = "btnSave"
Me.btnSave.Size = New System.Drawing.Size(120, 38)
Me.btnSave.TabIndex = 11
Me.btnSave.Text = "F9:登録"
Me.btnSave.UseVisualStyleBackColor = False
'
'btnDelete
'
Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnDelete.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnDelete.Location = New System.Drawing.Point(786, 430)
Me.btnDelete.Name = "btnDelete"
Me.btnDelete.Size = New System.Drawing.Size(120, 38)
Me.btnDelete.TabIndex = 12
Me.btnDelete.Text = "F10:削除"
Me.btnDelete.UseVisualStyleBackColor = False
'
'btnClear
'
Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnClear.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnClear.Location = New System.Drawing.Point(912, 430)
Me.btnClear.Name = "btnClear"
Me.btnClear.Size = New System.Drawing.Size(120, 38)
Me.btnClear.TabIndex = 13
Me.btnClear.Text = "F11:クリア"
Me.btnClear.UseVisualStyleBackColor = False
'
'btnClose
'
Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnClose.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnClose.Location = New System.Drawing.Point(1038, 430)
Me.btnClose.Name = "btnClose"
Me.btnClose.Size = New System.Drawing.Size(120, 38)
Me.btnClose.TabIndex = 14
Me.btnClose.Text = "F12:終了"
Me.btnClose.UseVisualStyleBackColor = False


        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1447, 765)

        Controls.Add(btnSave)
        Controls.Add(btnDelete)
        Controls.Add(btnClear)
        Controls.Add(btnClose)
        Controls.Add(lblTitle)

        Me.Controls.Add(Me.MseDataGridRolePermission)
        KeyPreview = True
        Margin = New Padding(4, 4, 4, 4)
        Name = "RoleEntry"
        Text = "RoleEntry"

         CType(Me.MseDataGridRolePermission, System.ComponentModel.ISupportInitialize).EndInit()    
        ResumeLayout(False)
        PerformLayout()

    End Sub

    'Delare Control

        Friend WithEvents MseDataGridRolePermission As MSEDataGrid   
    
        Friend WithEvents lblTitle As MSELabel
        Friend WithEvents btnSave As MSEButton
        Friend WithEvents btnDelete As MSEButton
        Friend WithEvents btnClear As MSEButton
        Friend WithEvents btnClose As MSEButton'　Id      
        Friend WithEvents lblId As MSELabel
        Friend WithEvents numId As MSEEdit'　Code      
        Friend WithEvents lblCode As MSELabel
        Friend WithEvents txtCode As MSEEdit'　Name      
        Friend WithEvents lblName As MSELabel
        Friend WithEvents txtName As MSEEdit'　IsSystem      
        Friend WithEvents lblIsSystem As MSELabel
        Friend WithEvents numIsSystem As MSEEdit'　CreatedAt        
        Friend WithEvents lblCreatedAt As MSELabel
        Friend WithEvents dteCreatedAt As MSEDate'　UpdatedAt        
        Friend WithEvents lblUpdatedAt As MSELabel
        Friend WithEvents dteUpdatedAt As MSEDate'　YukoFlag      
        Friend WithEvents lblYukoFlag As MSELabel
        Friend WithEvents txtYukoFlag As MSEEdit'　CreatedUser      
        Friend WithEvents lblCreatedUser As MSELabel
        Friend WithEvents numCreatedUser As MSEEdit'　LastUpdateUser      
        Friend WithEvents lblLastUpdateUser As MSELabel
        Friend WithEvents numLastUpdateUser As MSEEdit'　LastUpdateProgram      
        Friend WithEvents lblLastUpdateProgram As MSELabel
        Friend WithEvents txtLastUpdateProgram As MSEEdit
'　RoleId      
        Friend WithEvents ColumnRoleId As DataGridViewTextBoxColumn'　PermissionScreenId      
        Friend WithEvents ColumnPermissionScreenId As DataGridViewTextBoxColumn'　Code      
        Friend WithEvents ColumnCode As DataGridViewTextBoxColumn'　CreatedAt        
        Friend WithEvents ColumnCreatedAt As DataGridViewTextBoxColumn'　UpdatedAt        
        Friend WithEvents ColumnUpdatedAt As DataGridViewTextBoxColumn'　YukoFlag      
        Friend WithEvents ColumnYukoFlag As DataGridViewTextBoxColumn'　CreatedUser      
        Friend WithEvents ColumnCreatedUser As DataGridViewTextBoxColumn'　LastUpdateUser      
        Friend WithEvents ColumnLastUpdateUser As DataGridViewTextBoxColumn'　LastUpdateProgram      
        Friend WithEvents ColumnLastUpdateProgram As DataGridViewTextBoxColumn

End Class
