Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("EntDeTab_NET.AxEntDeTab")> Public Class AxEntDeTab
	Inherits System.Windows.Forms.UserControl
	'-------------------------------------------------------------------------------
	'  << Enter DE Tab (VB5.0(SP3) >>
	'
	' Enter�L�[�ŁA�t�H�[�J�X�ړ�����Ƃ����AWindows �� GUI �K������͂��ꂽ�v�]��
	' ���\�����悤�ȋC�����܂��B
	'
	' �����ŁA���̋@�\���AActiveX �R���g���[���ɂ��āA�\��t���邾���Ŏ����ł����
	' �����ȂƎv���A����Č��܂����B
	'
	' ���̃v���O�����������N�������Q�ɂ��āA��҂́A��؂̐ӔC�𕉂�Ȃ����̂Ƃ�
	' �܂��B
	'
	' �o�O�񍐂͑劽�}�ł��B
	' ��Q�̋N���������ł��邾���ڂ��������āAE-Mail: komurak@mail.interq.or.jp
	' �܂ŁA����񂢂���������A�Ђ���Ƃ��đ΍􂷂邩������܂���B
	'-------------------------------------------------------------------------------
	Private WithEvents frmParent As System.Windows.Forms.Form ' �e�t�H�[���̃C�x���g���󂯎��I�u�W�F�N�g

    '--�C���J�n�@2021�N06��03��:MK�i��j- VB��VB.NET�ϊ�

    Private Const WM_KEYDOWN As Integer = &H100
	Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

	Private Sub frmParent_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles frmParent.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        'Enter �L�[�������ꂽ��ATAB �L�[���t�H�[���ɑ����āAKeyAscii ���[���ɂ���
        If KeyAscii = System.Windows.Forms.Keys.Return Then
			Call SendTab()
			KeyAscii = 0
		End If

		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

	'++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
	'Private Sub frmParent_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	Private Sub frmParent_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles frmParent.FormClosed
		'--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

		'++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
		'If Cancel = False Then
		If eventArgs.CloseReason = CloseReason.UserClosing Then
			'--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
			'UPGRADE_NOTE: Object frmParent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			frmParent = Nothing
		End If

	End Sub

	'UPGRADE_ISSUE: VBRUN.PropertyBag type was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
	'UPGRADE_WARNING: UserControl event ReadProperties is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92F3B58C-F772-4151-BE90-09F4A232AEAD"'
	Private Sub UserControl_ReadProperties(ByRef PropBag As Object)

		'���s���ŁA�I�u�W�F�N�g�ւ̎Q�Ƃ��Ȃ���΁A�e�t�H�[���ւ̎Q�Ƃ��Z�b�g
		'�����ɁAKeyPreview �v���p�e�B���ATrue �ɂ��A�L�[������t�H�[���Ŏ󂯎���悤�ɂ���

		If Not DesignMode Then
			If frmParent Is Nothing Then
				'UPGRADE_ISSUE: UserControl property EntDeTab.Extender was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Extender.Parent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
				'frmParent = Extender.Parent
				frmParent = Me.Parent
				'--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
				frmParent.KeyPreview = True
			End If
		End If

	End Sub

	Private Sub EntDeTab_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

		'�T�C�Y�ύX���ꂽ��A���Ƃ̑傫���ɖ߂�
		SetBounds(Top, Left, VB6.TwipsToPixelsX(VB6.TwipsPerPixelX * 32), VB6.TwipsToPixelsY(VB6.TwipsPerPixelY * 32))

	End Sub

	Private Sub UserControl_Terminate()

		'�e�t�H�[���ւ̎Q�Ƃ�j��
		'UPGRADE_NOTE: Object frmParent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		frmParent = Nothing

	End Sub

	Private Sub SendTab()

		'�e�t�H�[���� TAB �L�[�𑗂�܂��B

		PostMessage(frmParent.Handle.ToInt32, WM_KEYDOWN, System.Windows.Forms.Keys.Tab, &HF021)

	End Sub

End Class