'UPGRADE_WARNING: The entire project must be compiled once before a form with an ActiveX Control Array can be displayed

Imports System.ComponentModel
Imports System.Windows.Forms

<ProvideProperty("Index", GetType(MKSlider))> Public Class AxSliderArray
    Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray
    Implements IExtenderProvider

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Container As IContainer)
        MyBase.New(Container)
    End Sub

    Public Shadows Event [ClickEvent](ByVal sender As System.Object, ByVal e As System.EventArgs)
    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [KeyDownEvent] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyDownEvent)
    'Public Shadows Event [KeyPressEvent] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyPressEvent)
    'Public Shadows Event [KeyUpEvent] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyUpEvent)
    'Public Shadows Event [MouseDownEvent] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseDownEvent)
    'Public Shadows Event [MouseMoveEvent] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseMoveEvent)
    'Public Shadows Event [MouseUpEvent] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseUpEvent)
    'Public Shadows Event [Scroll] (ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Public Shadows Event [Change] (ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Public Shadows Event [OLEStartDrag] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEStartDragEvent)
    'Public Shadows Event [OLEGiveFeedback] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEGiveFeedbackEvent)
    'Public Shadows Event [OLESetData] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLESetDataEvent)
    'Public Shadows Event [OLECompleteDrag] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLECompleteDragEvent)
    'Public Shadows Event [OLEDragOver] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEDragOverEvent)
    'Public Shadows Event [OLEDragDrop] (ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEDragDropEvent)
    Public Shadows Event [KeyDownEvent](ByVal sender As System.Object, ByVal e As KeyEventArgs)
    'Public Shadows Event [KeyPressEvent](ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyPressEvent)
    Public Shadows Event [KeyUpEvent](ByVal sender As System.Object, ByVal e As KeyEventArgs)
    Public Shadows Event [MouseDownEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    Public Shadows Event [MouseMoveEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    Public Shadows Event [MouseUpEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    Public Shadows Event [Scroll](ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event [Change](ByVal sender As System.Object, ByVal e As System.EventArgs)
    'DragEnter
    Public Shadows Event [OLEStartDrag](ByVal sender As System.Object, ByVal e As DragEventArgs)
    'GiveFeedback
    Public Shadows Event [OLEGiveFeedback](ByVal sender As System.Object, ByVal e As GiveFeedbackEventArgs)
    'TextInput
    Public Shadows Event [OLESetData](ByVal sender As System.Object, ByVal e As EventArgs)
    'DragLeave
    Public Shadows Event [OLECompleteDrag](ByVal sender As System.Object, ByVal e As DragEventArgs)
    Public Shadows Event [OLEDragOver](ByVal sender As System.Object, ByVal e As DragEventArgs)
    'Drop
    Public Shadows Event [OLEDragDrop](ByVal sender As System.Object, ByVal e As DragEventArgs)
    '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
        '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        'If TypeOf target Is AxComctlLib.AxSlider Then
        If TypeOf target Is MKSlider Then
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            Return BaseCanExtend(target)
        End If
    End Function

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Public Function GetIndex(ByVal o As AxComctlLib.AxSlider) As Short
    Public Function GetIndex(ByVal o As MKSlider) As Short
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        Return BaseGetIndex(o)
    End Function
    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換

    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxComctlLib.AxSlider, ByVal Index As Short)

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As MKSlider, ByVal Index As Short)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        BaseSetIndex(o, Index)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxComctlLib.AxSlider) As Boolean
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As MKSlider) As Boolean
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        Return BaseShouldSerializeIndex(o)
    End Function

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxComctlLib.AxSlider)
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As MKSlider)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        BaseResetIndex(o)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Default Public ReadOnly Property Item(ByVal Index As Short) As AxComctlLib.AxSlider
    Default Public ReadOnly Property Item(ByVal Index As Short) As MKSlider
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        Get
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'Item = CType(BaseGetItem(Index), AxComctlLib.AxSlider)
            Item = CType(BaseGetItem(Index), MKSlider)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End Get
    End Property

    Protected Overrides Function GetControlInstanceType() As System.Type
        '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        'Return GetType(AxComctlLib.AxSlider)
        Return GetType(MKSlider)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    End Function

    Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
        '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        'Dim ctl As AxComctlLib.AxSlider = CType(o, AxComctlLib.AxSlider)
        Dim ctl As MKSlider = CType(o, MKSlider)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        MyBase.HookUpControlEvents(o)
        If Not ClickEventEvent Is Nothing Then
            '++修正開始　2021年06月08:MK（ツール）- AxMSFlexGrid VB→VB.NET変換
            'AddHandler ctl.ClickEvent, New System.EventHandler(AddressOf HandleClickEvent)
            AddHandler ctl.Click, New System.EventHandler(AddressOf HandleClickEvent)
            '--修正終了　2021年06月08:MK（ツール）- AxMSFlexGrid VB→VB.NET変換
        End If
        If Not KeyDownEventEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.KeyDownEvent, New AxComctlLib.ISliderEvents_KeyDownEventHandler(AddressOf HandleKeyDownEvent)
            AddHandler ctl.KeyDown, New KeyEventHandler(AddressOf HandleKeyDownEvent)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        'If Not KeyPressEventEvent Is Nothing Then
        '    AddHandler ctl.KeyPressEvent, New AxComctlLib.ISliderEvents_KeyPressEventHandler(AddressOf HandleKeyPressEvent)
        'End If
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        If Not KeyUpEventEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.KeyUpEvent, New AxComctlLib.ISliderEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
            AddHandler ctl.KeyUp, New KeyEventHandler(AddressOf HandleKeyUpEvent)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not MouseDownEventEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.MouseDownEvent, New AxComctlLib.ISliderEvents_MouseDownEventHandler(AddressOf HandleMouseDownEvent)
            AddHandler ctl.MouseDown, New MouseEventHandler(AddressOf HandleMouseDownEvent)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not MouseMoveEventEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.MouseMoveEvent, New AxComctlLib.ISliderEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
            AddHandler ctl.MouseMove, New MouseEventHandler(AddressOf HandleMouseMoveEvent)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not MouseUpEventEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.MouseUpEvent, New AxComctlLib.ISliderEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
            AddHandler ctl.MouseUp, New MouseEventHandler(AddressOf HandleMouseUpEvent)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not ScrollEvent Is Nothing Then
            AddHandler ctl.Scroll, New System.EventHandler(AddressOf HandleScroll)
        End If
        If Not ChangeEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.Change, New System.EventHandler(AddressOf HandleChange)
            AddHandler ctl.ValueChanged, New System.EventHandler(AddressOf HandleChange)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not OLEStartDragEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.OLEStartDrag, New AxComctlLib.ISliderEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
            AddHandler ctl.DragEnter, New DragEventHandler(AddressOf HandleOLEStartDrag)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not OLEGiveFeedbackEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.OLEGiveFeedback, New AxComctlLib.ISliderEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
            AddHandler ctl.GiveFeedback, New GiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not OLESetDataEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.OLESetData, New AxComctlLib.ISliderEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
            AddHandler ctl.ValueChanged, New EventHandler(AddressOf HandleOLESetData)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not OLECompleteDragEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.OLECompleteDrag, New AxComctlLib.ISliderEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
            AddHandler ctl.DragLeave, New EventHandler(AddressOf HandleOLECompleteDrag)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not OLEDragOverEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.OLEDragOver, New AxComctlLib.ISliderEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
            AddHandler ctl.DragOver, New DragEventHandler(AddressOf HandleOLEDragOver)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
        If Not OLEDragDropEvent Is Nothing Then
            '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.OLEDragDrop, New AxComctlLib.ISliderEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
            AddHandler ctl.DragDrop, New DragEventHandler(AddressOf HandleOLEDragDrop)
            '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        End If
    End Sub

    Private Sub HandleClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent [ClickEvent](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleKeyDownEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyDownEvent)
    Private Sub HandleKeyDownEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [KeyDownEvent](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleKeyPressEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyPressEvent)
    '    RaiseEvent [KeyPressEvent](sender, e)
    'End Sub
    '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyUpEvent)
    Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [KeyUpEvent](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseDownEvent)
    Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [MouseDownEvent](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseMoveEvent)
    Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [MouseMoveEvent](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseUpEvent)
    Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [MouseUpEvent](sender, e)
    End Sub

    Private Sub HandleScroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent [Scroll](sender, e)
    End Sub

    Private Sub HandleChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent [Change](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLEStartDrag(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEStartDragEvent)
    Private Sub HandleOLEStartDrag(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [OLEStartDrag](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLEGiveFeedback(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEGiveFeedbackEvent)
    Private Sub HandleOLEGiveFeedback(ByVal sender As System.Object, ByVal e As GiveFeedbackEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [OLEGiveFeedback](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLESetData(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLESetDataEvent)
    Private Sub HandleOLESetData(ByVal sender As System.Object, ByVal e As EventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [OLESetData](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLECompleteDrag(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLECompleteDragEvent)
    Private Sub HandleOLECompleteDrag(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [OLECompleteDrag](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLEDragOver(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEDragOverEvent)
    Private Sub HandleOLEDragOver(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [OLEDragOver](sender, e)
    End Sub

    '++修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLEDragDrop(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEDragDropEvent)
    Private Sub HandleOLEDragDrop(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--修正開始　2021年06月19日:MK（手）- VB→VB.NET変換
        RaiseEvent [OLEDragDrop](sender, e)
    End Sub

End Class

