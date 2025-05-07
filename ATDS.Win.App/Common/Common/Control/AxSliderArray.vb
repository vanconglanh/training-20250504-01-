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
    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
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
    '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
        '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        'If TypeOf target Is AxComctlLib.AxSlider Then
        If TypeOf target Is MKSlider Then
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            Return BaseCanExtend(target)
        End If
    End Function

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Public Function GetIndex(ByVal o As AxComctlLib.AxSlider) As Short
    Public Function GetIndex(ByVal o As MKSlider) As Short
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        Return BaseGetIndex(o)
    End Function
    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�

    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxComctlLib.AxSlider, ByVal Index As Short)

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As MKSlider, ByVal Index As Short)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        BaseSetIndex(o, Index)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxComctlLib.AxSlider) As Boolean
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As MKSlider) As Boolean
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        Return BaseShouldSerializeIndex(o)
    End Function

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxComctlLib.AxSlider)
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As MKSlider)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        BaseResetIndex(o)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Default Public ReadOnly Property Item(ByVal Index As Short) As AxComctlLib.AxSlider
    Default Public ReadOnly Property Item(ByVal Index As Short) As MKSlider
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        Get
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'Item = CType(BaseGetItem(Index), AxComctlLib.AxSlider)
            Item = CType(BaseGetItem(Index), MKSlider)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End Get
    End Property

    Protected Overrides Function GetControlInstanceType() As System.Type
        '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        'Return GetType(AxComctlLib.AxSlider)
        Return GetType(MKSlider)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    End Function

    Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
        '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        'Dim ctl As AxComctlLib.AxSlider = CType(o, AxComctlLib.AxSlider)
        Dim ctl As MKSlider = CType(o, MKSlider)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        MyBase.HookUpControlEvents(o)
        If Not ClickEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��08:MK�i�c�[���j- AxMSFlexGrid VB��VB.NET�ϊ�
            'AddHandler ctl.ClickEvent, New System.EventHandler(AddressOf HandleClickEvent)
            AddHandler ctl.Click, New System.EventHandler(AddressOf HandleClickEvent)
            '--�C���I���@2021�N06��08:MK�i�c�[���j- AxMSFlexGrid VB��VB.NET�ϊ�
        End If
        If Not KeyDownEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.KeyDownEvent, New AxComctlLib.ISliderEvents_KeyDownEventHandler(AddressOf HandleKeyDownEvent)
            AddHandler ctl.KeyDown, New KeyEventHandler(AddressOf HandleKeyDownEvent)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        'If Not KeyPressEventEvent Is Nothing Then
        '    AddHandler ctl.KeyPressEvent, New AxComctlLib.ISliderEvents_KeyPressEventHandler(AddressOf HandleKeyPressEvent)
        'End If
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        If Not KeyUpEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.KeyUpEvent, New AxComctlLib.ISliderEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
            AddHandler ctl.KeyUp, New KeyEventHandler(AddressOf HandleKeyUpEvent)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not MouseDownEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.MouseDownEvent, New AxComctlLib.ISliderEvents_MouseDownEventHandler(AddressOf HandleMouseDownEvent)
            AddHandler ctl.MouseDown, New MouseEventHandler(AddressOf HandleMouseDownEvent)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not MouseMoveEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.MouseMoveEvent, New AxComctlLib.ISliderEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
            AddHandler ctl.MouseMove, New MouseEventHandler(AddressOf HandleMouseMoveEvent)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not MouseUpEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.MouseUpEvent, New AxComctlLib.ISliderEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
            AddHandler ctl.MouseUp, New MouseEventHandler(AddressOf HandleMouseUpEvent)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not ScrollEvent Is Nothing Then
            AddHandler ctl.Scroll, New System.EventHandler(AddressOf HandleScroll)
        End If
        If Not ChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.Change, New System.EventHandler(AddressOf HandleChange)
            AddHandler ctl.ValueChanged, New System.EventHandler(AddressOf HandleChange)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not OLEStartDragEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.OLEStartDrag, New AxComctlLib.ISliderEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
            AddHandler ctl.DragEnter, New DragEventHandler(AddressOf HandleOLEStartDrag)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not OLEGiveFeedbackEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.OLEGiveFeedback, New AxComctlLib.ISliderEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
            AddHandler ctl.GiveFeedback, New GiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not OLESetDataEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.OLESetData, New AxComctlLib.ISliderEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
            AddHandler ctl.ValueChanged, New EventHandler(AddressOf HandleOLESetData)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not OLECompleteDragEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.OLECompleteDrag, New AxComctlLib.ISliderEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
            AddHandler ctl.DragLeave, New EventHandler(AddressOf HandleOLECompleteDrag)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not OLEDragOverEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.OLEDragOver, New AxComctlLib.ISliderEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
            AddHandler ctl.DragOver, New DragEventHandler(AddressOf HandleOLEDragOver)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not OLEDragDropEvent Is Nothing Then
            '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.OLEDragDrop, New AxComctlLib.ISliderEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
            AddHandler ctl.DragDrop, New DragEventHandler(AddressOf HandleOLEDragDrop)
            '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        End If
    End Sub

    Private Sub HandleClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent [ClickEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleKeyDownEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyDownEvent)
    Private Sub HandleKeyDownEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [KeyDownEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleKeyPressEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyPressEvent)
    '    RaiseEvent [KeyPressEvent](sender, e)
    'End Sub
    '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_KeyUpEvent)
    Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [KeyUpEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseDownEvent)
    Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [MouseDownEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseMoveEvent)
    Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [MouseMoveEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_MouseUpEvent)
    Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [MouseUpEvent](sender, e)
    End Sub

    Private Sub HandleScroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent [Scroll](sender, e)
    End Sub

    Private Sub HandleChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent [Change](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleOLEStartDrag(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEStartDragEvent)
    Private Sub HandleOLEStartDrag(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [OLEStartDrag](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleOLEGiveFeedback(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEGiveFeedbackEvent)
    Private Sub HandleOLEGiveFeedback(ByVal sender As System.Object, ByVal e As GiveFeedbackEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [OLEGiveFeedback](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleOLESetData(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLESetDataEvent)
    Private Sub HandleOLESetData(ByVal sender As System.Object, ByVal e As EventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [OLESetData](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleOLECompleteDrag(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLECompleteDragEvent)
    Private Sub HandleOLECompleteDrag(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [OLECompleteDrag](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleOLEDragOver(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEDragOverEvent)
    Private Sub HandleOLEDragOver(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [OLEDragOver](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleOLEDragDrop(ByVal sender As System.Object, ByVal e As AxComctlLib.ISliderEvents_OLEDragDropEvent)
    Private Sub HandleOLEDragDrop(ByVal sender As System.Object, ByVal e As DragEventArgs)
        '--�C���J�n�@2021�N06��19��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [OLEDragDrop](sender, e)
    End Sub

End Class

