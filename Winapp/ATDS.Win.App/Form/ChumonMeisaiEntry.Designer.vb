Imports ATDS.Win.App

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChumonMeisaiEntry
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

        lblTitle = New MSELabel()
        btnClose = New MSEButton()
        btnClear = New MSEButton()
        btnDelete = New MSEButton()
        btnSave = New MSEButton()
 
        '　ChumonMeisaiId
        Me.lblChumonMeisaiId = New MSELabel
        Me.numChumonMeisaiId = New MSEEdit()
        '　ChumonId
        Me.lblChumonId = New MSELabel
        Me.numChumonId = New MSEEdit()
        '　ChumonMeisaiNo
        Me.lblChumonMeisaiNo = New MSELabel
        Me.txtChumonMeisaiNo = New MSEEdit()
        '　ShohinCode
        Me.lblShohinCode = New MSELabel
        Me.txtShohinCode = New MSEEdit()
        '　ShohinName
        Me.lblShohinName = New MSELabel
        Me.txtShohinName = New MSEEdit()
        '　Suryo
        Me.lblSuryo = New MSELabel
        Me.numSuryo = New MSEEdit()
        '　Tanka
        Me.lblTanka = New MSELabel
        Me.numTanka = New MSEEdit()
        '　Kingaku
        Me.lblKingaku = New MSELabel
        Me.numKingaku = New MSEEdit()
        '　Soryo
        Me.lblSoryo = New MSELabel
        Me.numSoryo = New MSEEdit()
        '　ZeiRitsu
        Me.lblZeiRitsu = New MSELabel
        Me.numZeiRitsu = New MSEEdit()
        '　GokeiKingaku
        Me.lblGokeiKingaku = New MSELabel
        Me.numGokeiKingaku = New MSEEdit()
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
        lblTitle.Text = "ChumonMeisai検索"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        'Generaete Init control
        Me.Controls.Add(Me.lblChumonMeisaiId)
Me.Controls.Add(Me.numChumonMeisaiId)
Me.Controls.Add(Me.lblChumonId)
Me.Controls.Add(Me.numChumonId)
Me.Controls.Add(Me.lblChumonMeisaiNo)
Me.Controls.Add(Me.txtChumonMeisaiNo)
Me.Controls.Add(Me.lblShohinCode)
Me.Controls.Add(Me.txtShohinCode)
Me.Controls.Add(Me.lblShohinName)
Me.Controls.Add(Me.txtShohinName)
Me.Controls.Add(Me.lblSuryo)
Me.Controls.Add(Me.numSuryo)
Me.Controls.Add(Me.lblTanka)
Me.Controls.Add(Me.numTanka)
Me.Controls.Add(Me.lblKingaku)
Me.Controls.Add(Me.numKingaku)
Me.Controls.Add(Me.lblSoryo)
Me.Controls.Add(Me.numSoryo)
Me.Controls.Add(Me.lblZeiRitsu)
Me.Controls.Add(Me.numZeiRitsu)
Me.Controls.Add(Me.lblGokeiKingaku)
Me.Controls.Add(Me.numGokeiKingaku)
Me.Controls.Add(Me.lblYukoFlag)
Me.Controls.Add(Me.numYukoFlag)
Me.Controls.Add(Me.lblLastUpdateUser)
Me.Controls.Add(Me.txtLastUpdateUser)
Me.Controls.Add(Me.lblLastUpdate)
Me.Controls.Add(Me.dteLastUpdate)
Me.Controls.Add(Me.lblLastUpdateProgram)
Me.Controls.Add(Me.txtLastUpdateProgram)
'
'lblChumonMeisaiId
'
Me.lblChumonMeisaiId.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblChumonMeisaiId.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblChumonMeisaiId.ForeColor = System.Drawing.Color.White
Me.lblChumonMeisaiId.Location = New System.Drawing.Point(20, 60)
Me.lblChumonMeisaiId.Name = "lblChumonMeisaiId"
Me.lblChumonMeisaiId.Size = New System.Drawing.Size(170, 24)
Me.lblChumonMeisaiId.Text = "chumon_meisai_id"
Me.lblChumonMeisaiId.Enabled = True
'
'numChumonMeisaiId
'
Me.numChumonMeisaiId.BackColor = System.Drawing.Color.White
Me.numChumonMeisaiId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numChumonMeisaiId.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numChumonMeisaiId.IsNextControl = True
Me.numChumonMeisaiId.IsUseFunctionKey = False
Me.numChumonMeisaiId.Location = New System.Drawing.Point(190, 60)
Me.numChumonMeisaiId.Size = New System.Drawing.Size(200, 24)
Me.numChumonMeisaiId.Name = "numChumonMeisaiId"
Me.numChumonMeisaiId.TabIndex = 0
Me.numChumonMeisaiId.Enabled = True
'
'lblChumonId
'
Me.lblChumonId.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblChumonId.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblChumonId.ForeColor = System.Drawing.Color.White
Me.lblChumonId.Location = New System.Drawing.Point(430, 60)
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
Me.numChumonId.Location = New System.Drawing.Point(600, 60)
Me.numChumonId.Size = New System.Drawing.Size(200, 24)
Me.numChumonId.Name = "numChumonId"
Me.numChumonId.TabIndex = 1
Me.numChumonId.Enabled = True
'
'lblChumonMeisaiNo
'
Me.lblChumonMeisaiNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblChumonMeisaiNo.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblChumonMeisaiNo.ForeColor = System.Drawing.Color.White
Me.lblChumonMeisaiNo.Location = New System.Drawing.Point(840, 60)
Me.lblChumonMeisaiNo.Name = "lblChumonMeisaiNo"
Me.lblChumonMeisaiNo.Size = New System.Drawing.Size(170, 24)
Me.lblChumonMeisaiNo.Text = "chumon_meisai_no"
Me.lblChumonMeisaiNo.Enabled = True
'
'txtChumonMeisaiNo
'
Me.txtChumonMeisaiNo.BackColor = System.Drawing.Color.White
Me.txtChumonMeisaiNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtChumonMeisaiNo.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtChumonMeisaiNo.IsNextControl = True
Me.txtChumonMeisaiNo.IsUseFunctionKey = False
Me.txtChumonMeisaiNo.Location = New System.Drawing.Point(1010, 60)
Me.txtChumonMeisaiNo.Size = New System.Drawing.Size(200, 24)
Me.txtChumonMeisaiNo.Name = "txtChumonMeisaiNo"
Me.txtChumonMeisaiNo.TabIndex = 2
Me.txtChumonMeisaiNo.Enabled = True
'
'lblShohinCode
'
Me.lblShohinCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblShohinCode.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblShohinCode.ForeColor = System.Drawing.Color.White
Me.lblShohinCode.Location = New System.Drawing.Point(20, 94)
Me.lblShohinCode.Name = "lblShohinCode"
Me.lblShohinCode.Size = New System.Drawing.Size(170, 24)
Me.lblShohinCode.Text = "shohin_code"
Me.lblShohinCode.Enabled = True
'
'txtShohinCode
'
Me.txtShohinCode.BackColor = System.Drawing.Color.White
Me.txtShohinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtShohinCode.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtShohinCode.IsNextControl = True
Me.txtShohinCode.IsUseFunctionKey = False
Me.txtShohinCode.Location = New System.Drawing.Point(190, 94)
Me.txtShohinCode.Size = New System.Drawing.Size(200, 24)
Me.txtShohinCode.Name = "txtShohinCode"
Me.txtShohinCode.TabIndex = 3
Me.txtShohinCode.Enabled = True
'
'lblShohinName
'
Me.lblShohinName.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblShohinName.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblShohinName.ForeColor = System.Drawing.Color.White
Me.lblShohinName.Location = New System.Drawing.Point(430, 94)
Me.lblShohinName.Name = "lblShohinName"
Me.lblShohinName.Size = New System.Drawing.Size(170, 24)
Me.lblShohinName.Text = "shohin_name"
Me.lblShohinName.Enabled = True
'
'txtShohinName
'
Me.txtShohinName.BackColor = System.Drawing.Color.White
Me.txtShohinName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtShohinName.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.txtShohinName.IsNextControl = True
Me.txtShohinName.IsUseFunctionKey = False
Me.txtShohinName.Location = New System.Drawing.Point(600, 94)
Me.txtShohinName.Size = New System.Drawing.Size(200, 24)
Me.txtShohinName.Name = "txtShohinName"
Me.txtShohinName.TabIndex = 4
Me.txtShohinName.Enabled = True
'
'lblSuryo
'
Me.lblSuryo.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSuryo.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSuryo.ForeColor = System.Drawing.Color.White
Me.lblSuryo.Location = New System.Drawing.Point(840, 94)
Me.lblSuryo.Name = "lblSuryo"
Me.lblSuryo.Size = New System.Drawing.Size(170, 24)
Me.lblSuryo.Text = "suryo"
Me.lblSuryo.Enabled = True
'
'numSuryo
'
Me.numSuryo.BackColor = System.Drawing.Color.White
Me.numSuryo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numSuryo.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numSuryo.IsNextControl = True
Me.numSuryo.IsUseFunctionKey = False
Me.numSuryo.Location = New System.Drawing.Point(1010, 94)
Me.numSuryo.Size = New System.Drawing.Size(200, 24)
Me.numSuryo.Name = "numSuryo"
Me.numSuryo.TabIndex = 5
Me.numSuryo.Enabled = True
'
'lblTanka
'
Me.lblTanka.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblTanka.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblTanka.ForeColor = System.Drawing.Color.White
Me.lblTanka.Location = New System.Drawing.Point(20, 128)
Me.lblTanka.Name = "lblTanka"
Me.lblTanka.Size = New System.Drawing.Size(170, 24)
Me.lblTanka.Text = "tanka"
Me.lblTanka.Enabled = True
'
'numTanka
'
Me.numTanka.BackColor = System.Drawing.Color.White
Me.numTanka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numTanka.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numTanka.IsNextControl = True
Me.numTanka.IsUseFunctionKey = False
Me.numTanka.Location = New System.Drawing.Point(190, 128)
Me.numTanka.Size = New System.Drawing.Size(200, 24)
Me.numTanka.Name = "numTanka"
Me.numTanka.TabIndex = 6
Me.numTanka.Enabled = True
'
'lblKingaku
'
Me.lblKingaku.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblKingaku.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblKingaku.ForeColor = System.Drawing.Color.White
Me.lblKingaku.Location = New System.Drawing.Point(430, 128)
Me.lblKingaku.Name = "lblKingaku"
Me.lblKingaku.Size = New System.Drawing.Size(170, 24)
Me.lblKingaku.Text = "kingaku"
Me.lblKingaku.Enabled = True
'
'numKingaku
'
Me.numKingaku.BackColor = System.Drawing.Color.White
Me.numKingaku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numKingaku.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numKingaku.IsNextControl = True
Me.numKingaku.IsUseFunctionKey = False
Me.numKingaku.Location = New System.Drawing.Point(600, 128)
Me.numKingaku.Size = New System.Drawing.Size(200, 24)
Me.numKingaku.Name = "numKingaku"
Me.numKingaku.TabIndex = 7
Me.numKingaku.Enabled = True
'
'lblSoryo
'
Me.lblSoryo.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblSoryo.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblSoryo.ForeColor = System.Drawing.Color.White
Me.lblSoryo.Location = New System.Drawing.Point(840, 128)
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
Me.numSoryo.Location = New System.Drawing.Point(1010, 128)
Me.numSoryo.Size = New System.Drawing.Size(200, 24)
Me.numSoryo.Name = "numSoryo"
Me.numSoryo.TabIndex = 8
Me.numSoryo.Enabled = True
'
'lblZeiRitsu
'
Me.lblZeiRitsu.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblZeiRitsu.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblZeiRitsu.ForeColor = System.Drawing.Color.White
Me.lblZeiRitsu.Location = New System.Drawing.Point(20, 162)
Me.lblZeiRitsu.Name = "lblZeiRitsu"
Me.lblZeiRitsu.Size = New System.Drawing.Size(170, 24)
Me.lblZeiRitsu.Text = "zei_ritsu"
Me.lblZeiRitsu.Enabled = True
'
'numZeiRitsu
'
Me.numZeiRitsu.BackColor = System.Drawing.Color.White
Me.numZeiRitsu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.numZeiRitsu.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
Me.numZeiRitsu.IsNextControl = True
Me.numZeiRitsu.IsUseFunctionKey = False
Me.numZeiRitsu.Location = New System.Drawing.Point(190, 162)
Me.numZeiRitsu.Size = New System.Drawing.Size(200, 24)
Me.numZeiRitsu.Name = "numZeiRitsu"
Me.numZeiRitsu.TabIndex = 9
Me.numZeiRitsu.Enabled = True
'
'lblGokeiKingaku
'
Me.lblGokeiKingaku.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblGokeiKingaku.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblGokeiKingaku.ForeColor = System.Drawing.Color.White
Me.lblGokeiKingaku.Location = New System.Drawing.Point(430, 162)
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
Me.numGokeiKingaku.Location = New System.Drawing.Point(600, 162)
Me.numGokeiKingaku.Size = New System.Drawing.Size(200, 24)
Me.numGokeiKingaku.Name = "numGokeiKingaku"
Me.numGokeiKingaku.TabIndex = 10
Me.numGokeiKingaku.Enabled = True
'
'lblYukoFlag
'
Me.lblYukoFlag.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblYukoFlag.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblYukoFlag.ForeColor = System.Drawing.Color.White
Me.lblYukoFlag.Location = New System.Drawing.Point(840, 162)
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
Me.numYukoFlag.Location = New System.Drawing.Point(1010, 162)
Me.numYukoFlag.Size = New System.Drawing.Size(200, 24)
Me.numYukoFlag.Name = "numYukoFlag"
Me.numYukoFlag.TabIndex = 11
Me.numYukoFlag.Enabled = True
'
'lblLastUpdateUser
'
Me.lblLastUpdateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdateUser.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdateUser.ForeColor = System.Drawing.Color.White
Me.lblLastUpdateUser.Location = New System.Drawing.Point(20, 196)
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
Me.txtLastUpdateUser.Location = New System.Drawing.Point(190, 196)
Me.txtLastUpdateUser.Size = New System.Drawing.Size(200, 24)
Me.txtLastUpdateUser.Name = "txtLastUpdateUser"
Me.txtLastUpdateUser.TabIndex = 12
Me.txtLastUpdateUser.Enabled = True
'
'lblLastUpdate
'
Me.lblLastUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdate.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdate.ForeColor = System.Drawing.Color.White
Me.lblLastUpdate.Location = New System.Drawing.Point(430, 196)
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
Me.dteLastUpdate.Location = New System.Drawing.Point(600, 196)
Me.dteLastUpdate.Size = New System.Drawing.Size(200, 24)
Me.dteLastUpdate.Name = "dteLastUpdate"
Me.dteLastUpdate.TabIndex = 13
Me.dteLastUpdate.Enabled = True
'
'lblLastUpdateProgram
'
Me.lblLastUpdateProgram.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
Me.lblLastUpdateProgram.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.lblLastUpdateProgram.ForeColor = System.Drawing.Color.White
Me.lblLastUpdateProgram.Location = New System.Drawing.Point(840, 196)
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
Me.txtLastUpdateProgram.Location = New System.Drawing.Point(1010, 196)
Me.txtLastUpdateProgram.Size = New System.Drawing.Size(200, 24)
Me.txtLastUpdateProgram.Name = "txtLastUpdateProgram"
Me.txtLastUpdateProgram.TabIndex = 14
Me.txtLastUpdateProgram.Enabled = True
'
'btnSave
'
Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnSave.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnSave.Location = New System.Drawing.Point(660, 264)
Me.btnSave.Name = "btnSave"
Me.btnSave.Size = New System.Drawing.Size(120, 38)
Me.btnSave.TabIndex = 15
Me.btnSave.Text = "F9:登録"
Me.btnSave.UseVisualStyleBackColor = False
'
'btnDelete
'
Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnDelete.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnDelete.Location = New System.Drawing.Point(786, 264)
Me.btnDelete.Name = "btnDelete"
Me.btnDelete.Size = New System.Drawing.Size(120, 38)
Me.btnDelete.TabIndex = 16
Me.btnDelete.Text = "F10:削除"
Me.btnDelete.UseVisualStyleBackColor = False
'
'btnClear
'
Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnClear.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnClear.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnClear.Location = New System.Drawing.Point(912, 264)
Me.btnClear.Name = "btnClear"
Me.btnClear.Size = New System.Drawing.Size(120, 38)
Me.btnClear.TabIndex = 17
Me.btnClear.Text = "F11:クリア"
Me.btnClear.UseVisualStyleBackColor = False
'
'btnClose
'
Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
Me.btnClose.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
Me.btnClose.Location = New System.Drawing.Point(1038, 264)
Me.btnClose.Name = "btnClose"
Me.btnClose.Size = New System.Drawing.Size(120, 38)
Me.btnClose.TabIndex = 18
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

        KeyPreview = True
        Margin = New Padding(4, 4, 4, 4)
        Name = "ChumonMeisaiEntry"
        Text = "ChumonMeisaiEntry"
 
        ResumeLayout(False)
        PerformLayout()

    End Sub

    'Delare Control
   
    
        Friend WithEvents lblTitle As MSELabel
        Friend WithEvents btnSave As MSEButton
        Friend WithEvents btnDelete As MSEButton
        Friend WithEvents btnClear As MSEButton
        Friend WithEvents btnClose As MSEButton'　ChumonMeisaiId      
        Friend WithEvents lblChumonMeisaiId As MSELabel
        Friend WithEvents numChumonMeisaiId As MSEEdit'　ChumonId      
        Friend WithEvents lblChumonId As MSELabel
        Friend WithEvents numChumonId As MSEEdit'　ChumonMeisaiNo      
        Friend WithEvents lblChumonMeisaiNo As MSELabel
        Friend WithEvents txtChumonMeisaiNo As MSEEdit'　ShohinCode      
        Friend WithEvents lblShohinCode As MSELabel
        Friend WithEvents txtShohinCode As MSEEdit'　ShohinName      
        Friend WithEvents lblShohinName As MSELabel
        Friend WithEvents txtShohinName As MSEEdit'　Suryo      
        Friend WithEvents lblSuryo As MSELabel
        Friend WithEvents numSuryo As MSEEdit'　Tanka      
        Friend WithEvents lblTanka As MSELabel
        Friend WithEvents numTanka As MSEEdit'　Kingaku      
        Friend WithEvents lblKingaku As MSELabel
        Friend WithEvents numKingaku As MSEEdit'　Soryo      
        Friend WithEvents lblSoryo As MSELabel
        Friend WithEvents numSoryo As MSEEdit'　ZeiRitsu      
        Friend WithEvents lblZeiRitsu As MSELabel
        Friend WithEvents numZeiRitsu As MSEEdit'　GokeiKingaku      
        Friend WithEvents lblGokeiKingaku As MSELabel
        Friend WithEvents numGokeiKingaku As MSEEdit'　YukoFlag      
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
