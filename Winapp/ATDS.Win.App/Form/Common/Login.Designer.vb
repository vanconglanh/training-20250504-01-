<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtPassword = New ATDS.Win.App.MSEEdit()
        Me.txtUser = New ATDS.Win.App.MSEEdit()
        Me.Button1 = New ATDS.Win.App.MSEButton()
        Me.lblPassword = New ATDS.Win.App.MSELabel()
        Me.lblUser = New ATDS.Win.App.MSELabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ATDS.Win.App.My.Resources.Resources.yoko
        Me.PictureBox1.Location = New System.Drawing.Point(34, 27)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(343, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
        Me.txtPassword.IsNeed = True
        Me.txtPassword.IsNextControl = True
        Me.txtPassword.IsSearch_SpaceKey = False
        Me.txtPassword.IsUseFunctionKey = False
        Me.txtPassword.Location = New System.Drawing.Point(157, 170)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(215, 24)
        Me.txtPassword.TabIndex = 2
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.White
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
        Me.txtUser.IsNeed = True
        Me.txtUser.IsNextControl = True
        Me.txtUser.IsSearch_SpaceKey = False
        Me.txtUser.IsUseFunctionKey = False
        Me.txtUser.Location = New System.Drawing.Point(157, 122)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(215, 24)
        Me.txtUser.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Location = New System.Drawing.Point(34, 219)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(340, 40)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "ログイン"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.lblPassword.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.White
        Me.lblPassword.Location = New System.Drawing.Point(34, 170)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(120, 24)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "パスワード"
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.lblUser.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(34, 122)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(120, 24)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "ユーザー"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(415, 289)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ログイン"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblUser As MSELabel
    Friend WithEvents lblPassword As MSELabel
    Friend WithEvents Button1 As MSEButton
    Friend WithEvents txtUser As MSEEdit
    Friend WithEvents txtPassword As MSEEdit
End Class