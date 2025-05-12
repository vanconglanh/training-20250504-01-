Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChumonEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChumonEntry))
        lblTitle = New MSELabel()
        btnClose = New MSEButton()
        btnClear = New MSEButton()
        btnDelete = New MSEButton()
        btnSave = New MSEButton()
 
        Me.MseDataGridChumonMeisai = New MSEDataGrid()
        '　ChumonId
        Me.lblChumonId = New MSELabel
        Me.numChumonId = New MSEEdit()
        '　ChumonNo
        Me.lblChumonNo = New MSELabel
        Me.txtChumonNo = New MSEEdit()
         '　ChumonDate
        Me.lblChumonDate = New MSELabel
        Me.dteChumonDate = New MSEDate()
        '　HojinCode
        Me.lblHojinCode = New MSELabel
        Me.txtHojinCode = New MSEEdit()
        '　KonyuName
        Me.lblKonyuName = New MSELabel
        Me.txtKonyuName = New MSEEdit()
        '　KonyuMailAddress
        Me.lblKonyuMailAddress = New MSELabel
        Me.txtKonyuMailAddress = New MSEEdit()
        '　KonyuTantosha
        Me.lblKonyuTantosha = New MSELabel
        Me.txtKonyuTantosha = New MSEEdit()
        '　KonyuKingaku1
        Me.lblKonyuKingaku1 = New MSELabel
        Me.numKonyuKingaku1 = New MSEEdit()
        '　KonyuKingaku2
        Me.lblKonyuKingaku2 = New MSELabel
        Me.numKonyuKingaku2 = New MSEEdit()
        '　KonyuKingaku3
        Me.lblKonyuKingaku3 = New MSELabel
        Me.numKonyuKingaku3 = New MSEEdit()
        '　Nebiki
        Me.lblNebiki = New MSELabel
        Me.numNebiki = New MSEEdit()
        '　Soryo
        Me.lblSoryo = New MSELabel
        Me.numSoryo = New MSEEdit()
        '　Zei1
        Me.lblZei1 = New MSELabel
        Me.numZei1 = New MSEEdit()
        '　ZeiRitsu1
        Me.lblZeiRitsu1 = New MSELabel
        Me.numZeiRitsu1 = New MSEEdit()
        '　Zei2
        Me.lblZei2 = New MSELabel
        Me.numZei2 = New MSEEdit()
        '　ZeiRitsu2
        Me.lblZeiRitsu2 = New MSELabel
        Me.numZeiRitsu2 = New MSEEdit()
        '　Zei3
        Me.lblZei3 = New MSELabel
        Me.numZei3 = New MSEEdit()
        '　ZeiRitsu3
        Me.lblZeiRitsu3 = New MSELabel
        Me.numZeiRitsu3 = New MSEEdit()
        '　GokeiKingaku
        Me.lblGokeiKingaku = New MSELabel
        Me.numGokeiKingaku = New MSEEdit()
        '　Status
        Me.lblStatus = New MSELabel
        Me.numStatus = New MSEEdit()
        '　YukoFlag
        Me.lblYukoFlag = New MSELabel
        Me.numYukoFlag = New MSEEdit()
        '　LastUpdateUser
        Me.lblLastUpdateUser = New MSELabel
        Me.txtLastUpdateUser = New MSEEdit()
         '　LastUpdate
        Me.lblLastUpdate = New MSELabel
        Me.dteLastUpdate = New MSEDate()
        '　LastUpdateProgram
        Me.lblLastUpdateProgram = New MSELabel
        Me.txtLastUpdateProgram = New MSEEdit()
        
                        '　ChumonMeisaiId      
                Me.ColumnChumonMeisaiId = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　ChumonId      
                Me.ColumnChumonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　ChumonMeisaiNo      
                Me.ColumnChumonMeisaiNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　ShohinCode      
                Me.ColumnShohinCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　ShohinName      
                Me.ColumnShohinName = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　Suryo      
                Me.ColumnSuryo = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　Tanka      
                Me.ColumnTanka = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　Kingaku      
                Me.ColumnKingaku = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　Soryo      
                Me.ColumnSoryo = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　ZeiRitsu      
                Me.ColumnZeiRitsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　GokeiKingaku      
                Me.ColumnGokeiKingaku = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　YukoFlag      
                Me.ColumnYukoFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　LastUpdateUser      
                Me.ColumnLastUpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　LastUpdate        
                Me.ColumnLastUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
                '　LastUpdateProgram      
                Me.ColumnLastUpdateProgram = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MseDataGridChumonMeisai, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblTitle.Text = "Chumon検索"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        'Generaete Init control
        Me.Controls.Add(Me.lblChumonId)
Me.Controls.Add(Me.numChumonId)
Me.Controls.Add(Me.lblChumonNo)
Me.Controls.Add(Me.txtChumonNo)
Me.Controls.Add(Me.lblChumonDate)
Me.Controls.Add(Me.dteChumonDate)
Me.Controls.Add(Me.lblHojinCode)
Me.Controls.Add(Me.txtHojinCode)
Me.Controls.Add(Me.lblKonyuName)
Me.Controls.Add(Me.txtKonyuName)
Me.Controls.Add(Me.lblKonyuMailAddress)
Me.Controls.Add(Me.txtKonyuMailAddress)
Me.Controls.Add(Me.lblKonyuTantosha)
Me.Controls.Add(Me.txtKonyuTantosha)
Me.Controls.Add(Me.lblKonyuKingaku1)
Me.Controls.Add(Me.numKonyuKingaku1)
Me.Controls.Add(Me.lblKonyuKingaku2)
Me.Controls.Add(Me.numKonyuKingaku2)
Me.Controls.Add(Me.lblKonyuKingaku3)
Me.Controls.Add(Me.numKonyuKingaku3)
Me.Controls.Add(Me.lblNebiki)
Me.Controls.Add(Me.numNebiki)
Me.Controls.Add(Me.lblSoryo)
Me.Controls.Add(Me.numSoryo)
Me.Controls.Add(Me.lblZei1)
Me.Controls.Add(Me.numZei1)
Me.Controls.Add(Me.lblZeiRitsu1)
Me.Controls.Add(Me.numZeiRitsu1)
Me.Controls.Add(Me.lblZei2)
Me.Controls.Add(Me.numZei2)
Me.Controls.Add(Me.lblZeiRitsu2)
Me.Controls.Add(Me.numZeiRitsu2)
Me.Controls.Add(Me.lblZei3)
Me.Controls.Add(Me.numZei3)
Me.Controls.Add(Me.lblZeiRitsu3)
Me.Controls.Add(Me.numZeiRitsu3)
Me.Controls.Add(Me.lblGokeiKingaku)
Me.Controls.Add(Me.numGokeiKingaku)
Me.Controls.Add(Me.lblStatus)
Me.Controls.Add(Me.numStatus)
Me.Controls.Add(Me.lblYukoFlag)
Me.Controls.Add(Me.numYukoFlag)
Me.Controls.Add(Me.lblLastUpdateUser)
Me.Controls.Add(Me.txtLastUpdateUser)
Me.Controls.Add(Me.lblLastUpdate)
Me.Controls.Add(Me.dteLastUpdate)
Me.Controls.Add(Me.lblLastUpdateProgram)
Me.Controls.Add(Me.txtLastUpdateProgram)
Me.Controls.Add(Me.lblChumonId)
Me.Controls.Add(Me.numChumonId)
Me.Controls.Add(Me.lblChumonNo)
Me.Controls.Add(Me.txtChumonNo)
Me.Controls.Add(Me.lblChumonDate)
Me.Controls.Add(Me.dteChumonDate)
Me.Controls.Add(Me.lblHojinCode)
Me.Controls.Add(Me.txtHojinCode)
Me.Controls.Add(Me.lblKonyuName)
Me.Controls.Add(Me.txtKonyuName)
Me.Controls.Add(Me.lblKonyuMailAddress)
Me.Controls.Add(Me.txtKonyuMailAddress)
Me.Controls.Add(Me.lblKonyuTantosha)
Me.Controls.Add(Me.txtKonyuTantosha)
Me.Controls.Add(Me.lblKonyuKingaku1)
Me.Controls.Add(Me.numKonyuKingaku1)
Me.Controls.Add(Me.lblKonyuKingaku2)
Me.Controls.Add(Me.numKonyuKingaku2)
Me.Controls.Add(Me.lblKonyuKingaku3)
Me.Controls.Add(Me.numKonyuKingaku3)
Me.Controls.Add(Me.lblNebiki)
Me.Controls.Add(Me.numNebiki)
Me.Controls.Add(Me.lblSoryo)
Me.Controls.Add(Me.numSoryo)
Me.Controls.Add(Me.lblZei1)
Me.Controls.Add(Me.numZei1)
Me.Controls.Add(Me.lblZeiRitsu1)
Me.Controls.Add(Me.numZeiRitsu1)
Me.Controls.Add(Me.lblZei2)
Me.Controls.Add(Me.numZei2)
Me.Controls.Add(Me.lblZeiRitsu2)
Me.Controls.Add(Me.numZeiRitsu2)
Me.Controls.Add(Me.lblZei3)
Me.Controls.Add(Me.numZei3)
Me.Controls.Add(Me.lblZeiRitsu3)
Me.Controls.Add(Me.numZeiRitsu3)
Me.Controls.Add(Me.lblGokeiKingaku)
Me.Controls.Add(Me.numGokeiKingaku)
Me.Controls.Add(Me.lblStatus)
Me.Controls.Add(Me.numStatus)
Me.Controls.Add(Me.lblYukoFlag)
Me.Controls.Add(Me.numYukoFlag)
Me.Controls.Add(Me.lblLastUpdateUser)
Me.Controls.Add(Me.txtLastUpdateUser)
Me.Controls.Add(Me.lblLastUpdate)
Me.Controls.Add(Me.dteLastUpdate)
Me.Controls.Add(Me.lblLastUpdateProgram)
Me.Controls.Add(Me.txtLastUpdateProgram)
'
'lblChumonId
'
Me.lblChumonId.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblChumonId.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblChumonId.ForeColor = System.Drawing.Color.White
Me.lblChumonId.Location = New System.Drawing.Point(20, 60)
Me.lblChumonId.Name = "lblChumonId"
Me.lblChumonId.Size = New System.Drawing.Size(170, 24)
Me.lblChumonId.Text = "chumon_id"
Me.lblChumonId.Enabled = True
'
'numChumonId
'
Me.numChumonId.BackColor = System.Drawing.Color.White
Me.numChumonId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numChumonId.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numChumonId.IsNextControl = True
Me.numChumonId.IsUseFunctionKey = False
Me.numChumonId.Location = New System.Drawing.Point(190, 60)
Me.numChumonId.Size = New System.Drawing.Size(200, 24)
Me.numChumonId.Name = "numChumonId"
Me.numChumonId.TabIndex = 0
Me.numChumonId.Enabled = True
'
'lblChumonNo
'
Me.lblChumonNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblChumonNo.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblChumonNo.ForeColor = System.Drawing.Color.White
Me.lblChumonNo.Location = New System.Drawing.Point(430, 60)
Me.lblChumonNo.Name = "lblChumonNo"
Me.lblChumonNo.Size = New System.Drawing.Size(170, 24)
Me.lblChumonNo.Text = "chumon_no"
Me.lblChumonNo.Enabled = True
'
'txtChumonNo
'
Me.txtChumonNo.BackColor = System.Drawing.Color.White
Me.txtChumonNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtChumonNo.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtChumonNo.IsNextControl = True
Me.txtChumonNo.IsUseFunctionKey = False
Me.txtChumonNo.Location = New System.Drawing.Point(600, 60)
Me.txtChumonNo.Size = New System.Drawing.Size(200, 24)
Me.txtChumonNo.Name = "txtChumonNo"
Me.txtChumonNo.TabIndex = 1
Me.txtChumonNo.Enabled = True
'
'lblChumonDate
'
Me.lblChumonDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblChumonDate.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblChumonDate.ForeColor = System.Drawing.Color.White
Me.lblChumonDate.Location = New System.Drawing.Point(840, 60)
Me.lblChumonDate.Name = "lblChumonDate"
Me.lblChumonDate.Size = New System.Drawing.Size(170, 24)
Me.lblChumonDate.Text = "chumon_date"
Me.lblChumonDate.Enabled = True
'
'dteChumonDate
'
Me.dteChumonDate.BackColor = System.Drawing.Color.White
Me.dteChumonDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteChumonDate.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteChumonDate.IsNextControl = True
Me.dteChumonDate.IsUseFunctionKey = False
Me.dteChumonDate.Location = New System.Drawing.Point(1010, 60)
Me.dteChumonDate.Size = New System.Drawing.Size(200, 24)
Me.dteChumonDate.Name = "dteChumonDate"
Me.dteChumonDate.TabIndex = 2
Me.dteChumonDate.Enabled = True
'
'lblHojinCode
'
Me.lblHojinCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblHojinCode.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblHojinCode.ForeColor = System.Drawing.Color.White
Me.lblHojinCode.Location = New System.Drawing.Point(20, 94)
Me.lblHojinCode.Name = "lblHojinCode"
Me.lblHojinCode.Size = New System.Drawing.Size(170, 24)
Me.lblHojinCode.Text = "hojin_code"
Me.lblHojinCode.Enabled = True
'
'txtHojinCode
'
Me.txtHojinCode.BackColor = System.Drawing.Color.White
Me.txtHojinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtHojinCode.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtHojinCode.IsNextControl = True
Me.txtHojinCode.IsUseFunctionKey = False
Me.txtHojinCode.Location = New System.Drawing.Point(190, 94)
Me.txtHojinCode.Size = New System.Drawing.Size(200, 24)
Me.txtHojinCode.Name = "txtHojinCode"
Me.txtHojinCode.TabIndex = 3
Me.txtHojinCode.Enabled = True
'
'lblKonyuName
'
Me.lblKonyuName.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKonyuName.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKonyuName.ForeColor = System.Drawing.Color.White
Me.lblKonyuName.Location = New System.Drawing.Point(430, 94)
Me.lblKonyuName.Name = "lblKonyuName"
Me.lblKonyuName.Size = New System.Drawing.Size(170, 24)
Me.lblKonyuName.Text = "konyu_name"
Me.lblKonyuName.Enabled = True
'
'txtKonyuName
'
Me.txtKonyuName.BackColor = System.Drawing.Color.White
Me.txtKonyuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtKonyuName.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtKonyuName.IsNextControl = True
Me.txtKonyuName.IsUseFunctionKey = False
Me.txtKonyuName.Location = New System.Drawing.Point(600, 94)
Me.txtKonyuName.Size = New System.Drawing.Size(200, 24)
Me.txtKonyuName.Name = "txtKonyuName"
Me.txtKonyuName.TabIndex = 4
Me.txtKonyuName.Enabled = True
'
'lblKonyuMailAddress
'
Me.lblKonyuMailAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKonyuMailAddress.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKonyuMailAddress.ForeColor = System.Drawing.Color.White
Me.lblKonyuMailAddress.Location = New System.Drawing.Point(840, 94)
Me.lblKonyuMailAddress.Name = "lblKonyuMailAddress"
Me.lblKonyuMailAddress.Size = New System.Drawing.Size(170, 24)
Me.lblKonyuMailAddress.Text = "konyu_mail_address"
Me.lblKonyuMailAddress.Enabled = True
'
'txtKonyuMailAddress
'
Me.txtKonyuMailAddress.BackColor = System.Drawing.Color.White
Me.txtKonyuMailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtKonyuMailAddress.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtKonyuMailAddress.IsNextControl = True
Me.txtKonyuMailAddress.IsUseFunctionKey = False
Me.txtKonyuMailAddress.Location = New System.Drawing.Point(1010, 94)
Me.txtKonyuMailAddress.Size = New System.Drawing.Size(200, 24)
Me.txtKonyuMailAddress.Name = "txtKonyuMailAddress"
Me.txtKonyuMailAddress.TabIndex = 5
Me.txtKonyuMailAddress.Enabled = True
'
'lblKonyuTantosha
'
Me.lblKonyuTantosha.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKonyuTantosha.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKonyuTantosha.ForeColor = System.Drawing.Color.White
Me.lblKonyuTantosha.Location = New System.Drawing.Point(20, 128)
Me.lblKonyuTantosha.Name = "lblKonyuTantosha"
Me.lblKonyuTantosha.Size = New System.Drawing.Size(170, 24)
Me.lblKonyuTantosha.Text = "konyu_tantosha"
Me.lblKonyuTantosha.Enabled = True
'
'txtKonyuTantosha
'
Me.txtKonyuTantosha.BackColor = System.Drawing.Color.White
Me.txtKonyuTantosha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtKonyuTantosha.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtKonyuTantosha.IsNextControl = True
Me.txtKonyuTantosha.IsUseFunctionKey = False
Me.txtKonyuTantosha.Location = New System.Drawing.Point(190, 128)
Me.txtKonyuTantosha.Size = New System.Drawing.Size(200, 24)
Me.txtKonyuTantosha.Name = "txtKonyuTantosha"
Me.txtKonyuTantosha.TabIndex = 6
Me.txtKonyuTantosha.Enabled = True
'
'lblKonyuKingaku1
'
Me.lblKonyuKingaku1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKonyuKingaku1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKonyuKingaku1.ForeColor = System.Drawing.Color.White
Me.lblKonyuKingaku1.Location = New System.Drawing.Point(430, 128)
Me.lblKonyuKingaku1.Name = "lblKonyuKingaku1"
Me.lblKonyuKingaku1.Size = New System.Drawing.Size(170, 24)
Me.lblKonyuKingaku1.Text = "konyu_kingaku1"
Me.lblKonyuKingaku1.Enabled = True
'
'numKonyuKingaku1
'
Me.numKonyuKingaku1.BackColor = System.Drawing.Color.White
Me.numKonyuKingaku1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKonyuKingaku1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKonyuKingaku1.IsNextControl = True
Me.numKonyuKingaku1.IsUseFunctionKey = False
Me.numKonyuKingaku1.Location = New System.Drawing.Point(600, 128)
Me.numKonyuKingaku1.Size = New System.Drawing.Size(200, 24)
Me.numKonyuKingaku1.Name = "numKonyuKingaku1"
Me.numKonyuKingaku1.TabIndex = 7
Me.numKonyuKingaku1.Enabled = True
'
'lblKonyuKingaku2
'
Me.lblKonyuKingaku2.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKonyuKingaku2.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKonyuKingaku2.ForeColor = System.Drawing.Color.White
Me.lblKonyuKingaku2.Location = New System.Drawing.Point(840, 128)
Me.lblKonyuKingaku2.Name = "lblKonyuKingaku2"
Me.lblKonyuKingaku2.Size = New System.Drawing.Size(170, 24)
Me.lblKonyuKingaku2.Text = "konyu_kingaku2"
Me.lblKonyuKingaku2.Enabled = True
'
'numKonyuKingaku2
'
Me.numKonyuKingaku2.BackColor = System.Drawing.Color.White
Me.numKonyuKingaku2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKonyuKingaku2.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKonyuKingaku2.IsNextControl = True
Me.numKonyuKingaku2.IsUseFunctionKey = False
Me.numKonyuKingaku2.Location = New System.Drawing.Point(1010, 128)
Me.numKonyuKingaku2.Size = New System.Drawing.Size(200, 24)
Me.numKonyuKingaku2.Name = "numKonyuKingaku2"
Me.numKonyuKingaku2.TabIndex = 8
Me.numKonyuKingaku2.Enabled = True
'
'lblKonyuKingaku3
'
Me.lblKonyuKingaku3.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKonyuKingaku3.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKonyuKingaku3.ForeColor = System.Drawing.Color.White
Me.lblKonyuKingaku3.Location = New System.Drawing.Point(20, 162)
Me.lblKonyuKingaku3.Name = "lblKonyuKingaku3"
Me.lblKonyuKingaku3.Size = New System.Drawing.Size(170, 24)
Me.lblKonyuKingaku3.Text = "konyu_kingaku3"
Me.lblKonyuKingaku3.Enabled = True
'
'numKonyuKingaku3
'
Me.numKonyuKingaku3.BackColor = System.Drawing.Color.White
Me.numKonyuKingaku3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKonyuKingaku3.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKonyuKingaku3.IsNextControl = True
Me.numKonyuKingaku3.IsUseFunctionKey = False
Me.numKonyuKingaku3.Location = New System.Drawing.Point(190, 162)
Me.numKonyuKingaku3.Size = New System.Drawing.Size(200, 24)
Me.numKonyuKingaku3.Name = "numKonyuKingaku3"
Me.numKonyuKingaku3.TabIndex = 9
Me.numKonyuKingaku3.Enabled = True
'
'lblNebiki
'
Me.lblNebiki.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblNebiki.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblNebiki.ForeColor = System.Drawing.Color.White
Me.lblNebiki.Location = New System.Drawing.Point(430, 162)
Me.lblNebiki.Name = "lblNebiki"
Me.lblNebiki.Size = New System.Drawing.Size(170, 24)
Me.lblNebiki.Text = "nebiki"
Me.lblNebiki.Enabled = True
'
'numNebiki
'
Me.numNebiki.BackColor = System.Drawing.Color.White
Me.numNebiki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numNebiki.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numNebiki.IsNextControl = True
Me.numNebiki.IsUseFunctionKey = False
Me.numNebiki.Location = New System.Drawing.Point(600, 162)
Me.numNebiki.Size = New System.Drawing.Size(200, 24)
Me.numNebiki.Name = "numNebiki"
Me.numNebiki.TabIndex = 10
Me.numNebiki.Enabled = True
'
'lblSoryo
'
Me.lblSoryo.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSoryo.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSoryo.ForeColor = System.Drawing.Color.White
Me.lblSoryo.Location = New System.Drawing.Point(840, 162)
Me.lblSoryo.Name = "lblSoryo"
Me.lblSoryo.Size = New System.Drawing.Size(170, 24)
Me.lblSoryo.Text = "soryo"
Me.lblSoryo.Enabled = True
'
'numSoryo
'
Me.numSoryo.BackColor = System.Drawing.Color.White
Me.numSoryo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numSoryo.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numSoryo.IsNextControl = True
Me.numSoryo.IsUseFunctionKey = False
Me.numSoryo.Location = New System.Drawing.Point(1010, 162)
Me.numSoryo.Size = New System.Drawing.Size(200, 24)
Me.numSoryo.Name = "numSoryo"
Me.numSoryo.TabIndex = 11
Me.numSoryo.Enabled = True
'
'lblZei1
'
Me.lblZei1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZei1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZei1.ForeColor = System.Drawing.Color.White
Me.lblZei1.Location = New System.Drawing.Point(20, 196)
Me.lblZei1.Name = "lblZei1"
Me.lblZei1.Size = New System.Drawing.Size(170, 24)
Me.lblZei1.Text = "zei1"
Me.lblZei1.Enabled = True
'
'numZei1
'
Me.numZei1.BackColor = System.Drawing.Color.White
Me.numZei1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZei1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZei1.IsNextControl = True
Me.numZei1.IsUseFunctionKey = False
Me.numZei1.Location = New System.Drawing.Point(190, 196)
Me.numZei1.Size = New System.Drawing.Size(200, 24)
Me.numZei1.Name = "numZei1"
Me.numZei1.TabIndex = 12
Me.numZei1.Enabled = True
'
'lblZeiRitsu1
'
Me.lblZeiRitsu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZeiRitsu1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZeiRitsu1.ForeColor = System.Drawing.Color.White
Me.lblZeiRitsu1.Location = New System.Drawing.Point(430, 196)
Me.lblZeiRitsu1.Name = "lblZeiRitsu1"
Me.lblZeiRitsu1.Size = New System.Drawing.Size(170, 24)
Me.lblZeiRitsu1.Text = "zei_ritsu1"
Me.lblZeiRitsu1.Enabled = True
'
'numZeiRitsu1
'
Me.numZeiRitsu1.BackColor = System.Drawing.Color.White
Me.numZeiRitsu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZeiRitsu1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZeiRitsu1.IsNextControl = True
Me.numZeiRitsu1.IsUseFunctionKey = False
Me.numZeiRitsu1.Location = New System.Drawing.Point(600, 196)
Me.numZeiRitsu1.Size = New System.Drawing.Size(200, 24)
Me.numZeiRitsu1.Name = "numZeiRitsu1"
Me.numZeiRitsu1.TabIndex = 13
Me.numZeiRitsu1.Enabled = True
'
'lblZei2
'
Me.lblZei2.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZei2.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZei2.ForeColor = System.Drawing.Color.White
Me.lblZei2.Location = New System.Drawing.Point(840, 196)
Me.lblZei2.Name = "lblZei2"
Me.lblZei2.Size = New System.Drawing.Size(170, 24)
Me.lblZei2.Text = "zei2"
Me.lblZei2.Enabled = True
'
'numZei2
'
Me.numZei2.BackColor = System.Drawing.Color.White
Me.numZei2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZei2.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZei2.IsNextControl = True
Me.numZei2.IsUseFunctionKey = False
Me.numZei2.Location = New System.Drawing.Point(1010, 196)
Me.numZei2.Size = New System.Drawing.Size(200, 24)
Me.numZei2.Name = "numZei2"
Me.numZei2.TabIndex = 14
Me.numZei2.Enabled = True
'
'lblZeiRitsu2
'
Me.lblZeiRitsu2.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZeiRitsu2.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZeiRitsu2.ForeColor = System.Drawing.Color.White
Me.lblZeiRitsu2.Location = New System.Drawing.Point(20, 230)
Me.lblZeiRitsu2.Name = "lblZeiRitsu2"
Me.lblZeiRitsu2.Size = New System.Drawing.Size(170, 24)
Me.lblZeiRitsu2.Text = "zei_ritsu2"
Me.lblZeiRitsu2.Enabled = True
'
'numZeiRitsu2
'
Me.numZeiRitsu2.BackColor = System.Drawing.Color.White
Me.numZeiRitsu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZeiRitsu2.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZeiRitsu2.IsNextControl = True
Me.numZeiRitsu2.IsUseFunctionKey = False
Me.numZeiRitsu2.Location = New System.Drawing.Point(190, 230)
Me.numZeiRitsu2.Size = New System.Drawing.Size(200, 24)
Me.numZeiRitsu2.Name = "numZeiRitsu2"
Me.numZeiRitsu2.TabIndex = 15
Me.numZeiRitsu2.Enabled = True
'
'lblZei3
'
Me.lblZei3.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZei3.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZei3.ForeColor = System.Drawing.Color.White
Me.lblZei3.Location = New System.Drawing.Point(430, 230)
Me.lblZei3.Name = "lblZei3"
Me.lblZei3.Size = New System.Drawing.Size(170, 24)
Me.lblZei3.Text = "zei3"
Me.lblZei3.Enabled = True
'
'numZei3
'
Me.numZei3.BackColor = System.Drawing.Color.White
Me.numZei3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZei3.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZei3.IsNextControl = True
Me.numZei3.IsUseFunctionKey = False
Me.numZei3.Location = New System.Drawing.Point(600, 230)
Me.numZei3.Size = New System.Drawing.Size(200, 24)
Me.numZei3.Name = "numZei3"
Me.numZei3.TabIndex = 16
Me.numZei3.Enabled = True
'
'lblZeiRitsu3
'
Me.lblZeiRitsu3.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZeiRitsu3.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZeiRitsu3.ForeColor = System.Drawing.Color.White
Me.lblZeiRitsu3.Location = New System.Drawing.Point(840, 230)
Me.lblZeiRitsu3.Name = "lblZeiRitsu3"
Me.lblZeiRitsu3.Size = New System.Drawing.Size(170, 24)
Me.lblZeiRitsu3.Text = "zei_ritsu3"
Me.lblZeiRitsu3.Enabled = True
'
'numZeiRitsu3
'
Me.numZeiRitsu3.BackColor = System.Drawing.Color.White
Me.numZeiRitsu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZeiRitsu3.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZeiRitsu3.IsNextControl = True
Me.numZeiRitsu3.IsUseFunctionKey = False
Me.numZeiRitsu3.Location = New System.Drawing.Point(1010, 230)
Me.numZeiRitsu3.Size = New System.Drawing.Size(200, 24)
Me.numZeiRitsu3.Name = "numZeiRitsu3"
Me.numZeiRitsu3.TabIndex = 17
Me.numZeiRitsu3.Enabled = True
'
'lblGokeiKingaku
'
Me.lblGokeiKingaku.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblGokeiKingaku.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblGokeiKingaku.ForeColor = System.Drawing.Color.White
Me.lblGokeiKingaku.Location = New System.Drawing.Point(20, 264)
Me.lblGokeiKingaku.Name = "lblGokeiKingaku"
Me.lblGokeiKingaku.Size = New System.Drawing.Size(170, 24)
Me.lblGokeiKingaku.Text = "gokei_kingaku"
Me.lblGokeiKingaku.Enabled = True
'
'numGokeiKingaku
'
Me.numGokeiKingaku.BackColor = System.Drawing.Color.White
Me.numGokeiKingaku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numGokeiKingaku.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numGokeiKingaku.IsNextControl = True
Me.numGokeiKingaku.IsUseFunctionKey = False
Me.numGokeiKingaku.Location = New System.Drawing.Point(190, 264)
Me.numGokeiKingaku.Size = New System.Drawing.Size(200, 24)
Me.numGokeiKingaku.Name = "numGokeiKingaku"
Me.numGokeiKingaku.TabIndex = 18
Me.numGokeiKingaku.Enabled = True
'
'lblStatus
'
Me.lblStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblStatus.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblStatus.ForeColor = System.Drawing.Color.White
Me.lblStatus.Location = New System.Drawing.Point(430, 264)
Me.lblStatus.Name = "lblStatus"
Me.lblStatus.Size = New System.Drawing.Size(170, 24)
Me.lblStatus.Text = "status"
Me.lblStatus.Enabled = True
'
'numStatus
'
Me.numStatus.BackColor = System.Drawing.Color.White
Me.numStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numStatus.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numStatus.IsNextControl = True
Me.numStatus.IsUseFunctionKey = False
Me.numStatus.Location = New System.Drawing.Point(600, 264)
Me.numStatus.Size = New System.Drawing.Size(200, 24)
Me.numStatus.Name = "numStatus"
Me.numStatus.TabIndex = 19
Me.numStatus.Enabled = True
'
'lblYukoFlag
'
Me.lblYukoFlag.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblYukoFlag.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblYukoFlag.ForeColor = System.Drawing.Color.White
Me.lblYukoFlag.Location = New System.Drawing.Point(840, 264)
Me.lblYukoFlag.Name = "lblYukoFlag"
Me.lblYukoFlag.Size = New System.Drawing.Size(170, 24)
Me.lblYukoFlag.Text = "yuko_flag"
Me.lblYukoFlag.Enabled = True
'
'numYukoFlag
'
Me.numYukoFlag.BackColor = System.Drawing.Color.White
Me.numYukoFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numYukoFlag.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numYukoFlag.IsNextControl = True
Me.numYukoFlag.IsUseFunctionKey = False
Me.numYukoFlag.Location = New System.Drawing.Point(1010, 264)
Me.numYukoFlag.Size = New System.Drawing.Size(200, 24)
Me.numYukoFlag.Name = "numYukoFlag"
Me.numYukoFlag.TabIndex = 20
Me.numYukoFlag.Enabled = True
'
'lblLastUpdateUser
'
Me.lblLastUpdateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdateUser.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdateUser.ForeColor = System.Drawing.Color.White
Me.lblLastUpdateUser.Location = New System.Drawing.Point(20, 298)
Me.lblLastUpdateUser.Name = "lblLastUpdateUser"
Me.lblLastUpdateUser.Size = New System.Drawing.Size(170, 24)
Me.lblLastUpdateUser.Text = "last_update_user"
Me.lblLastUpdateUser.Enabled = True
'
'txtLastUpdateUser
'
Me.txtLastUpdateUser.BackColor = System.Drawing.Color.White
Me.txtLastUpdateUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtLastUpdateUser.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtLastUpdateUser.IsNextControl = True
Me.txtLastUpdateUser.IsUseFunctionKey = False
Me.txtLastUpdateUser.Location = New System.Drawing.Point(190, 298)
Me.txtLastUpdateUser.Size = New System.Drawing.Size(200, 24)
Me.txtLastUpdateUser.Name = "txtLastUpdateUser"
Me.txtLastUpdateUser.TabIndex = 21
Me.txtLastUpdateUser.Enabled = True
'
'lblLastUpdate
'
Me.lblLastUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdate.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdate.ForeColor = System.Drawing.Color.White
Me.lblLastUpdate.Location = New System.Drawing.Point(430, 298)
Me.lblLastUpdate.Name = "lblLastUpdate"
Me.lblLastUpdate.Size = New System.Drawing.Size(170, 24)
Me.lblLastUpdate.Text = "last_update"
Me.lblLastUpdate.Enabled = True
'
'dteLastUpdate
'
Me.dteLastUpdate.BackColor = System.Drawing.Color.White
Me.dteLastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.dteLastUpdate.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.dteLastUpdate.IsNextControl = True
Me.dteLastUpdate.IsUseFunctionKey = False
Me.dteLastUpdate.Location = New System.Drawing.Point(600, 298)
Me.dteLastUpdate.Size = New System.Drawing.Size(200, 24)
Me.dteLastUpdate.Name = "dteLastUpdate"
Me.dteLastUpdate.TabIndex = 22
Me.dteLastUpdate.Enabled = True
'
'lblLastUpdateProgram
'
Me.lblLastUpdateProgram.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdateProgram.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdateProgram.ForeColor = System.Drawing.Color.White
Me.lblLastUpdateProgram.Location = New System.Drawing.Point(840, 298)
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
Me.txtLastUpdateProgram.Location = New System.Drawing.Point(1010, 298)
Me.txtLastUpdateProgram.Size = New System.Drawing.Size(200, 24)
Me.txtLastUpdateProgram.Name = "txtLastUpdateProgram"
Me.txtLastUpdateProgram.TabIndex = 23
Me.txtLastUpdateProgram.Enabled = True
'
'ColumnChumonMeisaiId
'
Me.ColumnChumonMeisaiId.HeaderText = "chumon_meisai_id"
Me.ColumnChumonMeisaiId.Name = "ChumonMeisaiId"
Me.ColumnChumonMeisaiId.ReadOnly = True
Me.ColumnChumonMeisaiId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnChumonMeisaiId.Width = 150
'
'ColumnChumonId
'
Me.ColumnChumonId.HeaderText = "chumon_id"
Me.ColumnChumonId.Name = "ChumonId"
Me.ColumnChumonId.ReadOnly = True
Me.ColumnChumonId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnChumonId.Width = 150
'
'ColumnChumonMeisaiNo
'
Me.ColumnChumonMeisaiNo.HeaderText = "chumon_meisai_no"
Me.ColumnChumonMeisaiNo.Name = "ChumonMeisaiNo"
Me.ColumnChumonMeisaiNo.ReadOnly = True
Me.ColumnChumonMeisaiNo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnChumonMeisaiNo.Width = 150
'
'ColumnShohinCode
'
Me.ColumnShohinCode.HeaderText = "shohin_code"
Me.ColumnShohinCode.Name = "ShohinCode"
Me.ColumnShohinCode.ReadOnly = True
Me.ColumnShohinCode.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnShohinCode.Width = 150
'
'ColumnShohinName
'
Me.ColumnShohinName.HeaderText = "shohin_name"
Me.ColumnShohinName.Name = "ShohinName"
Me.ColumnShohinName.ReadOnly = True
Me.ColumnShohinName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnShohinName.Width = 150
'
'ColumnSuryo
'
Me.ColumnSuryo.HeaderText = "suryo"
Me.ColumnSuryo.Name = "Suryo"
Me.ColumnSuryo.ReadOnly = True
Me.ColumnSuryo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSuryo.Width = 150
'
'ColumnTanka
'
Me.ColumnTanka.HeaderText = "tanka"
Me.ColumnTanka.Name = "Tanka"
Me.ColumnTanka.ReadOnly = True
Me.ColumnTanka.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnTanka.Width = 150
'
'ColumnKingaku
'
Me.ColumnKingaku.HeaderText = "kingaku"
Me.ColumnKingaku.Name = "Kingaku"
Me.ColumnKingaku.ReadOnly = True
Me.ColumnKingaku.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnKingaku.Width = 150
'
'ColumnSoryo
'
Me.ColumnSoryo.HeaderText = "soryo"
Me.ColumnSoryo.Name = "Soryo"
Me.ColumnSoryo.ReadOnly = True
Me.ColumnSoryo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnSoryo.Width = 150
'
'ColumnZeiRitsu
'
Me.ColumnZeiRitsu.HeaderText = "zei_ritsu"
Me.ColumnZeiRitsu.Name = "ZeiRitsu"
Me.ColumnZeiRitsu.ReadOnly = True
Me.ColumnZeiRitsu.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnZeiRitsu.Width = 150
'
'ColumnGokeiKingaku
'
Me.ColumnGokeiKingaku.HeaderText = "gokei_kingaku"
Me.ColumnGokeiKingaku.Name = "GokeiKingaku"
Me.ColumnGokeiKingaku.ReadOnly = True
Me.ColumnGokeiKingaku.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnGokeiKingaku.Width = 150
'
'ColumnYukoFlag
'
Me.ColumnYukoFlag.HeaderText = "yuko_flag"
Me.ColumnYukoFlag.Name = "YukoFlag"
Me.ColumnYukoFlag.ReadOnly = True
Me.ColumnYukoFlag.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnYukoFlag.Width = 150
'
'ColumnLastUpdateUser
'
Me.ColumnLastUpdateUser.HeaderText = "last_update_user"
Me.ColumnLastUpdateUser.Name = "LastUpdateUser"
Me.ColumnLastUpdateUser.ReadOnly = True
Me.ColumnLastUpdateUser.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLastUpdateUser.Width = 150
'
'ColumnLastUpdate
'
Me.ColumnLastUpdate.HeaderText = "last_update"
Me.ColumnLastUpdate.Name = "LastUpdate"
Me.ColumnLastUpdate.ReadOnly = True
Me.ColumnLastUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLastUpdate.Width = 150
'
'ColumnLastUpdateProgram
'
Me.ColumnLastUpdateProgram.HeaderText = "last_update_program"
Me.ColumnLastUpdateProgram.Name = "LastUpdateProgram"
Me.ColumnLastUpdateProgram.ReadOnly = True
Me.ColumnLastUpdateProgram.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.ColumnLastUpdateProgram.Width = 150
'
'MseDataGridChumonMeisai
'
Me.MseDataGridChumonMeisai.AllowUserToAddRows = False
Me.MseDataGridChumonMeisai.AllowUserToDeleteRows = False
Me.MseDataGridChumonMeisai.AllowUserToResizeRows = False
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.MseDataGridChumonMeisai.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.MseDataGridChumonMeisai.ColumnHeadersHeight = 30
Me.MseDataGridChumonMeisai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
Me.MseDataGridChumonMeisai.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ColumnChumonMeisaiId,ColumnChumonId,ColumnChumonMeisaiNo,ColumnShohinCode,ColumnShohinName,ColumnSuryo,ColumnTanka,ColumnKingaku,ColumnSoryo,ColumnZeiRitsu,ColumnGokeiKingaku,ColumnYukoFlag,ColumnLastUpdateUser,ColumnLastUpdate,ColumnLastUpdateProgram})
Me.MseDataGridChumonMeisai.DefaultActiveColLeft = 0
Me.MseDataGridChumonMeisai.DefaultActiveColRight = 2
Me.MseDataGridChumonMeisai.DefaultActiveRowBottom = 0
Me.MseDataGridChumonMeisai.DefaultActiveRowTop = 0
Me.MseDataGridChumonMeisai.EnableHeadersVisualStyles = False
Me.MseDataGridChumonMeisai.Location = New System.Drawing.Point(20, 332)
Me.MseDataGridChumonMeisai.MultiSelect = False
Me.MseDataGridChumonMeisai.Name = "MseDataGridChumonMeisai"
Me.MseDataGridChumonMeisai.ReadOnly = True
Me.MseDataGridChumonMeisai.RowHeadersWidth = 35
Me.MseDataGridChumonMeisai.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
Me.MseDataGridChumonMeisai.RowTemplate.Height = 30
Me.MseDataGridChumonMeisai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.MseDataGridChumonMeisai.SheetMode = UI.Control.SheetMode.Display
Me.MseDataGridChumonMeisai.Size = New System.Drawing.Size(1190, 200)
Me.MseDataGridChumonMeisai.TabIndex = 24
'
'btnSave
'
Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnSave.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnSave.Location = New System.Drawing.Point(660, 566)
Me.btnSave.Name = "btnSave"
Me.btnSave.Size = New System.Drawing.Size(120, 38)
Me.btnSave.TabIndex = 25
Me.btnSave.Text = "F9:登録"
Me.btnSave.UseVisualStyleBackColor = False
'
'btnDelete
'
Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnDelete.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnDelete.Location = New System.Drawing.Point(786, 566)
Me.btnDelete.Name = "btnDelete"
Me.btnDelete.Size = New System.Drawing.Size(120, 38)
Me.btnDelete.TabIndex = 26
Me.btnDelete.Text = "F10:削除"
Me.btnDelete.UseVisualStyleBackColor = False
'
'btnClear
'
Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnClear.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnClear.Location = New System.Drawing.Point(912, 566)
Me.btnClear.Name = "btnClear"
Me.btnClear.Size = New System.Drawing.Size(120, 38)
Me.btnClear.TabIndex = 27
Me.btnClear.Text = "F11:クリア"
Me.btnClear.UseVisualStyleBackColor = False
'
'btnClose
'
Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnClose.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnClose.Location = New System.Drawing.Point(1038, 566)
Me.btnClose.Name = "btnClose"
Me.btnClose.Size = New System.Drawing.Size(120, 38)
Me.btnClose.TabIndex = 28
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

        Me.Controls.Add(Me.MseDataGridChumonMeisai)
        KeyPreview = True
        Margin = New Padding(4, 4, 4, 4)
        Name = "ChumonEntry"
        Text = "ChumonEntry"

         CType(Me.MseDataGridChumonMeisai, System.ComponentModel.ISupportInitialize).EndInit()    
        ResumeLayout(False)
        PerformLayout()

    End Sub

    'Delare Control

        Friend WithEvents MseDataGridChumonMeisai As MSEDataGrid   
    
        Friend WithEvents lblTitle As MSELabel
        Friend WithEvents btnSave As MSEButton
        Friend WithEvents btnDelete As MSEButton
        Friend WithEvents btnClear As MSEButton
        Friend WithEvents btnClose As MSEButton'　ChumonId      
        Friend WithEvents lblChumonId As MSELabel
        Friend WithEvents numChumonId As MSEEdit'　ChumonNo      
        Friend WithEvents lblChumonNo As MSELabel
        Friend WithEvents txtChumonNo As MSEEdit'　ChumonDate        
        Friend WithEvents lblChumonDate As MSELabel
        Friend WithEvents dteChumonDate As MSEDate'　HojinCode      
        Friend WithEvents lblHojinCode As MSELabel
        Friend WithEvents txtHojinCode As MSEEdit'　KonyuName      
        Friend WithEvents lblKonyuName As MSELabel
        Friend WithEvents txtKonyuName As MSEEdit'　KonyuMailAddress      
        Friend WithEvents lblKonyuMailAddress As MSELabel
        Friend WithEvents txtKonyuMailAddress As MSEEdit'　KonyuTantosha      
        Friend WithEvents lblKonyuTantosha As MSELabel
        Friend WithEvents txtKonyuTantosha As MSEEdit'　KonyuKingaku1      
        Friend WithEvents lblKonyuKingaku1 As MSELabel
        Friend WithEvents numKonyuKingaku1 As MSEEdit'　KonyuKingaku2      
        Friend WithEvents lblKonyuKingaku2 As MSELabel
        Friend WithEvents numKonyuKingaku2 As MSEEdit'　KonyuKingaku3      
        Friend WithEvents lblKonyuKingaku3 As MSELabel
        Friend WithEvents numKonyuKingaku3 As MSEEdit'　Nebiki      
        Friend WithEvents lblNebiki As MSELabel
        Friend WithEvents numNebiki As MSEEdit'　Soryo      
        Friend WithEvents lblSoryo As MSELabel
        Friend WithEvents numSoryo As MSEEdit'　Zei1      
        Friend WithEvents lblZei1 As MSELabel
        Friend WithEvents numZei1 As MSEEdit'　ZeiRitsu1      
        Friend WithEvents lblZeiRitsu1 As MSELabel
        Friend WithEvents numZeiRitsu1 As MSEEdit'　Zei2      
        Friend WithEvents lblZei2 As MSELabel
        Friend WithEvents numZei2 As MSEEdit'　ZeiRitsu2      
        Friend WithEvents lblZeiRitsu2 As MSELabel
        Friend WithEvents numZeiRitsu2 As MSEEdit'　Zei3      
        Friend WithEvents lblZei3 As MSELabel
        Friend WithEvents numZei3 As MSEEdit'　ZeiRitsu3      
        Friend WithEvents lblZeiRitsu3 As MSELabel
        Friend WithEvents numZeiRitsu3 As MSEEdit'　GokeiKingaku      
        Friend WithEvents lblGokeiKingaku As MSELabel
        Friend WithEvents numGokeiKingaku As MSEEdit'　Status      
        Friend WithEvents lblStatus As MSELabel
        Friend WithEvents numStatus As MSEEdit'　YukoFlag      
        Friend WithEvents lblYukoFlag As MSELabel
        Friend WithEvents numYukoFlag As MSEEdit'　LastUpdateUser      
        Friend WithEvents lblLastUpdateUser As MSELabel
        Friend WithEvents txtLastUpdateUser As MSEEdit'　LastUpdate        
        Friend WithEvents lblLastUpdate As MSELabel
        Friend WithEvents dteLastUpdate As MSEDate'　LastUpdateProgram      
        Friend WithEvents lblLastUpdateProgram As MSELabel
        Friend WithEvents txtLastUpdateProgram As MSEEdit
'　ChumonMeisaiId      
        Friend WithEvents ColumnChumonMeisaiId As DataGridViewTextBoxColumn'　ChumonId      
        Friend WithEvents ColumnChumonId As DataGridViewTextBoxColumn'　ChumonMeisaiNo      
        Friend WithEvents ColumnChumonMeisaiNo As DataGridViewTextBoxColumn'　ShohinCode      
        Friend WithEvents ColumnShohinCode As DataGridViewTextBoxColumn'　ShohinName      
        Friend WithEvents ColumnShohinName As DataGridViewTextBoxColumn'　Suryo      
        Friend WithEvents ColumnSuryo As DataGridViewTextBoxColumn'　Tanka      
        Friend WithEvents ColumnTanka As DataGridViewTextBoxColumn'　Kingaku      
        Friend WithEvents ColumnKingaku As DataGridViewTextBoxColumn'　Soryo      
        Friend WithEvents ColumnSoryo As DataGridViewTextBoxColumn'　ZeiRitsu      
        Friend WithEvents ColumnZeiRitsu As DataGridViewTextBoxColumn'　GokeiKingaku      
        Friend WithEvents ColumnGokeiKingaku As DataGridViewTextBoxColumn'　YukoFlag      
        Friend WithEvents ColumnYukoFlag As DataGridViewTextBoxColumn'　LastUpdateUser      
        Friend WithEvents ColumnLastUpdateUser As DataGridViewTextBoxColumn'　LastUpdate        
        Friend WithEvents ColumnLastUpdate As DataGridViewTextBoxColumn'　LastUpdateProgram      
        Friend WithEvents ColumnLastUpdateProgram As DataGridViewTextBoxColumn

End Class
