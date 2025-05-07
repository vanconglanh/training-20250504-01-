Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("EntDeTab_NET.AxEntDeTab")> Public Class AxEntDeTab
	Inherits System.Windows.Forms.UserControl
	'-------------------------------------------------------------------------------
	'  << Enter DE Tab (VB5.0(SP3) >>
	'
	' Enterキーで、フォーカス移動するという、Windows の GUI 規則からはずれた要望が
	' 結構多いような気がします。
	'
	' そこで、この機能を、ActiveX コントロールにして、貼り付けるだけで実現できると
	' いいなと思い、作って見ました。
	'
	' このプログラムが巻き起こす損害について、作者は、一切の責任を負わないものとし
	' ます。
	'
	' バグ報告は大歓迎です。
	' 障害の起きた環境をできるだけ詳しく書いて、E-Mail: komurak@mail.interq.or.jp
	' まで、ご一報いただけたら、ひょっとして対策するかもしれません。
	'-------------------------------------------------------------------------------
	Private WithEvents frmParent As System.Windows.Forms.Form ' 親フォームのイベントを受け取るオブジェクト

    '--修正開始　2021年06月03日:MK（手）- VB→VB.NET変換

    Private Const WM_KEYDOWN As Integer = &H100
	Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

	Private Sub frmParent_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles frmParent.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        'Enter キーが押されたら、TAB キーをフォームに送って、KeyAscii をゼロにする
        If KeyAscii = System.Windows.Forms.Keys.Return Then
			Call SendTab()
			KeyAscii = 0
		End If

		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub

	'++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
	'Private Sub frmParent_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	Private Sub frmParent_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles frmParent.FormClosed
		'--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

		'++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
		'If Cancel = False Then
		If eventArgs.CloseReason = CloseReason.UserClosing Then
			'--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
			'UPGRADE_NOTE: Object frmParent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			frmParent = Nothing
		End If

	End Sub

	'UPGRADE_ISSUE: VBRUN.PropertyBag type was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
	'UPGRADE_WARNING: UserControl event ReadProperties is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="92F3B58C-F772-4151-BE90-09F4A232AEAD"'
	Private Sub UserControl_ReadProperties(ByRef PropBag As Object)

		'実行時で、オブジェクトへの参照がなければ、親フォームへの参照をセット
		'同時に、KeyPreview プロパティを、True にし、キー操作をフォームで受け取れるようにする

		If Not DesignMode Then
			If frmParent Is Nothing Then
				'UPGRADE_ISSUE: UserControl property EntDeTab.Extender was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Extender.Parent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
				'frmParent = Extender.Parent
				frmParent = Me.Parent
				'--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
				frmParent.KeyPreview = True
			End If
		End If

	End Sub

	Private Sub EntDeTab_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

		'サイズ変更されたら、もとの大きさに戻す
		SetBounds(Top, Left, VB6.TwipsToPixelsX(VB6.TwipsPerPixelX * 32), VB6.TwipsToPixelsY(VB6.TwipsPerPixelY * 32))

	End Sub

	Private Sub UserControl_Terminate()

		'親フォームへの参照を破棄
		'UPGRADE_NOTE: Object frmParent may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		frmParent = Nothing

	End Sub

	Private Sub SendTab()

		'親フォームに TAB キーを送ります。

		PostMessage(frmParent.Handle.ToInt32, WM_KEYDOWN, System.Windows.Forms.Keys.Tab, &HF021)

	End Sub

End Class