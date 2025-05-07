<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLogin
#Region "Windows フォーム デザイナによって生成されたコード "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'この呼び出しは、Windows フォーム デザイナで必要です。
		InitializeComponent()
	End Sub
	'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows フォーム デザイナで必要です。
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
	Public WithEvents lblパスワード As System.Windows.Forms.Label
	Public WithEvents lbl従業員コード As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.lblパスワード = New System.Windows.Forms.Label()
        Me.lbl従業員コード = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.75!)
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(116, 100)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(47, 24)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "ＯＫ"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.CausesValidation = False
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.75!)
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(164, 100)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(59, 24)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "ｷｬﾝｾﾙ"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(120, 60)
        Me.txtPassword.MaxLength = 8
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(69, 19)
        Me.txtPassword.TabIndex = 2
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.AcceptsReturn = True
        Me.txtEmployeeCode.BackColor = System.Drawing.Color.White
        Me.txtEmployeeCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmployeeCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.txtEmployeeCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmployeeCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtEmployeeCode.Location = New System.Drawing.Point(120, 28)
        Me.txtEmployeeCode.MaxLength = 8
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmployeeCode.Size = New System.Drawing.Size(69, 19)
        Me.txtEmployeeCode.TabIndex = 1
        '
        'lblパスワード
        '
        Me.lblパスワード.BackColor = System.Drawing.Color.Transparent
        Me.lblパスワード.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblパスワード.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lblパスワード.ForeColor = System.Drawing.Color.White
        Me.lblパスワード.Location = New System.Drawing.Point(24, 61)
        Me.lblパスワード.Name = "lblパスワード"
        Me.lblパスワード.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblパスワード.Size = New System.Drawing.Size(88, 18)
        Me.lblパスワード.TabIndex = 0
        Me.lblパスワード.Text = "パスワード"
        '
        'lbl従業員コード
        '
        Me.lbl従業員コード.BackColor = System.Drawing.Color.Transparent
        Me.lbl従業員コード.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl従業員コード.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lbl従業員コード.ForeColor = System.Drawing.Color.White
        Me.lbl従業員コード.Location = New System.Drawing.Point(24, 29)
        Me.lbl従業員コード.Name = "lbl従業員コード"
        Me.lbl従業員コード.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl従業員コード.Size = New System.Drawing.Size(96, 18)
        Me.lbl従業員コード.TabIndex = 5
        Me.lbl従業員コード.Text = "従業員コード"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(235, 130)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.lblパスワード)
        Me.Controls.Add(Me.lbl従業員コード)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ログイン"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class