<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLogin
#Region "Windows �t�H�[�� �f�U�C�i�ɂ���Đ������ꂽ�R�[�h "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
		InitializeComponent()
	End Sub
	'Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents txtPassword As System.Windows.Forms.TextBox
	Public WithEvents txtEmployeeCode As System.Windows.Forms.TextBox
	Public WithEvents lbl�p�X���[�h As System.Windows.Forms.Label
	Public WithEvents lbl�]�ƈ��R�[�h As System.Windows.Forms.Label
	'����: �ȉ��̃v���V�[�W���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
	'Windows �t�H�[�� �f�U�C�i���g���ĕύX�ł��܂��B
	'�R�[�h �G�f�B�^���g�p���āA�ύX���Ȃ��ł��������B
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.lbl�p�X���[�h = New System.Windows.Forms.Label()
        Me.lbl�]�ƈ��R�[�h = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 8.75!)
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(116, 100)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(47, 24)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "�n�j"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.CausesValidation = False
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 8.75!)
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(164, 100)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(59, 24)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.TabStop = False
        Me.cmdCancel.Text = "��ݾ�"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.Font = New System.Drawing.Font("�l�r �S�V�b�N", 9.0!)
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
        Me.txtEmployeeCode.Font = New System.Drawing.Font("�l�r �S�V�b�N", 9.0!)
        Me.txtEmployeeCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmployeeCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtEmployeeCode.Location = New System.Drawing.Point(120, 28)
        Me.txtEmployeeCode.MaxLength = 8
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmployeeCode.Size = New System.Drawing.Size(69, 19)
        Me.txtEmployeeCode.TabIndex = 1
        '
        'lbl�p�X���[�h
        '
        Me.lbl�p�X���[�h.BackColor = System.Drawing.Color.Transparent
        Me.lbl�p�X���[�h.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl�p�X���[�h.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lbl�p�X���[�h.ForeColor = System.Drawing.Color.White
        Me.lbl�p�X���[�h.Location = New System.Drawing.Point(24, 61)
        Me.lbl�p�X���[�h.Name = "lbl�p�X���[�h"
        Me.lbl�p�X���[�h.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl�p�X���[�h.Size = New System.Drawing.Size(88, 18)
        Me.lbl�p�X���[�h.TabIndex = 0
        Me.lbl�p�X���[�h.Text = "�p�X���[�h"
        '
        'lbl�]�ƈ��R�[�h
        '
        Me.lbl�]�ƈ��R�[�h.BackColor = System.Drawing.Color.Transparent
        Me.lbl�]�ƈ��R�[�h.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl�]�ƈ��R�[�h.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 8.75!, System.Drawing.FontStyle.Bold)
        Me.lbl�]�ƈ��R�[�h.ForeColor = System.Drawing.Color.White
        Me.lbl�]�ƈ��R�[�h.Location = New System.Drawing.Point(24, 29)
        Me.lbl�]�ƈ��R�[�h.Name = "lbl�]�ƈ��R�[�h"
        Me.lbl�]�ƈ��R�[�h.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl�]�ƈ��R�[�h.Size = New System.Drawing.Size(96, 18)
        Me.lbl�]�ƈ��R�[�h.TabIndex = 5
        Me.lbl�]�ƈ��R�[�h.Text = "�]�ƈ��R�[�h"
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
        Me.Controls.Add(Me.lbl�p�X���[�h)
        Me.Controls.Add(Me.lbl�]�ƈ��R�[�h)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���O�C��"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class