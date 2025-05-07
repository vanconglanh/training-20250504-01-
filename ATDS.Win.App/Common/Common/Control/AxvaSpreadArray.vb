'UPGRADE_WARNING: The entire project must be compiled once before a form with an ActiveX Control Array can be displayed

Imports System.ComponentModel
Imports System.Windows.Forms
Imports Common
Imports FarPoint.Win.Spread

'++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
'<ProvideProperty("Index",GetType(AxFPSpread.AxvaSpread))> Public Class AxvaSpreadArray
<ProvideProperty("Index", GetType(CustomizeFPSpread))> Public Class AxvaSpreadArray
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseControlArray
    Implements IExtenderProvider

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Container As IContainer)
        MyBase.New(Container)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [Advance] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_AdvanceEvent)
    Public Shadows Event [Advance](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.AdvanceEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [BlockSelected](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_BlockSelectedEvent)
    Public Shadows Event [BlockSelected](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.SelectionChangedEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [ButtonClicked] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ButtonClickedEvent)
    Public Shadows Event [ButtonClicked](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [Change](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ChangeEvent)
    Public Shadows Event [Change](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [ClickEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ClickEvent)
    Public Shadows Event [ClickEvent](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [ColWidthChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ColWidthChangeEvent)
    Public Shadows Event [ColWidthChange](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.ColumnWidthChangedEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [CustomFunction](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_CustomFunctionEvent)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [DataColConfig](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataColConfigEvent)
    Public Shadows Event [DataColConfig](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.DataColumnConfigureEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [DataFill](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataFillEvent)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [DblClick] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DblClickEvent)
    Public Shadows Event [DblClick](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [DragDropBlock](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DragDropBlockEvent)
    Public Shadows Event [DragDropBlock](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.DragDropBlockEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [DrawItem](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DrawItemEvent)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    Public Shadows Event [EditError](ByVal sender As System.Object, ByVal e As EditErrorEventArgs)
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [EditModeEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditModeEvent)
    Public Shadows Event [EditModeEvent](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [EnterRow](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EnterRowEvent)
    Public Shadows Event [EnterRow](ByVal sender As System.Object, ByVal e As EnterCellEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [LeaveCell] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveCellEvent)
    Public Shadows Event [LeaveCell](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [LeaveRow](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveRowEvent)
    Public Shadows Event [LeaveRow](ByVal sender As System.Object, ByVal e As LeaveCellEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [PrintAbort](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintAbortEvent)
    Public Shadows Event [PrintAbort](ByVal sender As System.Object, ByVal e As PrintAbortEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [QueryAdvance](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryAdvanceEvent)
    Public Shadows Event [QueryAdvance](ByVal sender As System.Object, ByVal e As AdvanceEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [QueryData](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryDataEvent)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [RightClick](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RightClickEvent)
    Public Shadows Event [RightClick](ByVal sender As System.Object, ByVal e As CellClickEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [RowHeightChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RowHeightChangeEvent)
    Public Shadows Event [RowHeightChange](ByVal sender As System.Object, ByVal e As RowHeightChangedEventArgs)
    '--修正開始　2021年06月13日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [SelChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_SelChangeEvent)
    Public Shadows Event [SelChange](ByVal sender As System.Object, ByVal e As SelectionChangedEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [TopLeftChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TopLeftChangeEvent)
    Public Shadows Event [TopChange](ByVal sender As System.Object, ByVal e As TopChangeEventArgs)
    Public Shadows Event [LeftChange](ByVal sender As System.Object, ByVal e As LeftChangeEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [UserFormulaEntered](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_UserFormulaEnteredEvent)
    Public Shadows Event [UserFormulaEntered](ByVal sender As System.Object, ByVal e As UserFormulaEnteredEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [VirtualClearData](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_VirtualClearDataEvent)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [PrintMsgBox](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintMsgBoxEvent)
    Public Shadows Event [PrintMsgBox](ByVal sender As System.Object, ByVal e As PrintMessageBoxEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [ComboCloseUp](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboCloseUpEvent)
    Public Shadows Event [ComboCloseUp](ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [ComboDropDown](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboDropDownEvent)
    Public Shadows Event [ComboDropDown](ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [ComboSelChange] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboSelChangeEvent)
    Public Shadows Event [ComboSelChange](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [TextTipFetch](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TextTipFetchEvent)
    Public Shadows Event [TextTipFetch](ByVal sender As System.Object, ByVal e As TextTipFetchEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [EditChange] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditChangeEvent)
    Public Shadows Event [EditChange](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [OLECompleteDrag](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLECompleteDragEvent)
    'Public Shadows Event [OLEDragDrop](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEDragDropEvent)
    'Public Shadows Event [OLEDragOver](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEDragOverEvent)
    'Public Shadows Event [OLEGiveFeedback](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEGiveFeedbackEvent)
    'Public Shadows Event [OLESetData](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLESetDataEvent)
    'Public Shadows Event [OLEStartDrag](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEStartDragEvent)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [KeyDownEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyDownEvent)
    Public Shadows Event [KeyDownEvent](ByVal sender As System.Object, ByVal e As KeyEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Shadows Event [KeyPressEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyPressEvent)
    Public Shadows Event [KeyPressEvent](ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
    '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [KeyUpEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyUpEvent)
    Public Shadows Event [KeyUpEvent](ByVal sender As System.Object, ByVal e As KeyEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [MouseDownEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseDownEvent)
    Public Shadows Event [MouseDownEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [MouseMoveEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseMoveEvent)
    Public Shadows Event [MouseMoveEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Public Shadows Event [MouseUpEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseUpEvent)
    Public Shadows Event [MouseUpEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
        If TypeOf target Is CustomizeFPSpread Then
            Return BaseCanExtend(target)
        End If
    End Function

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Function GetIndex(ByVal o As AxFPSpread.AxvaSpread) As Short
    Public Function GetIndex(ByVal o As Common.CustomizeFPSpread) As Short
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        Return BaseGetIndex(o)
    End Function

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxFPSpread.AxvaSpread, ByVal Index As Short)
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As Common.CustomizeFPSpread, ByVal Index As Short)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        BaseSetIndex(o, Index)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxFPSpread.AxvaSpread) As Boolean
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As Common.CustomizeFPSpread) As Boolean
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        Return BaseShouldSerializeIndex(o)
    End Function

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxFPSpread.AxvaSpread)
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As Common.CustomizeFPSpread)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        BaseResetIndex(o)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Default Public ReadOnly Property Item(ByVal Index As Short) As AxFPSpread.AxvaSpread
    Default Public ReadOnly Property Item(ByVal Index As Short) As Common.CustomizeFPSpread
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        Get
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'Item = CType(BaseGetItem(Index), AxFPSpread.AxvaSpread)
            Item = CType(BaseGetItem(Index), CustomizeFPSpread)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End Get
    End Property

    Protected Overrides Function GetControlInstanceType() As System.Type
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'Return GetType(AxFPSpread.AxvaSpread)
        Return GetType(CustomizeFPSpread)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    End Function

    Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
        '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        'Dim ctl As AxFPSpread.AxvaSpread = CType(o, AxFPSpread.AxvaSpread)
        Dim ctl As Common.CustomizeFPSpread = CType(o, Common.CustomizeFPSpread)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        'MyBase.HookUpControlEvents(o)

        If Not AdvanceEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.Advance, New AxFPSpread._DSpreadEvents_AdvanceEventHandler(AddressOf HandleAdvance)
            AddHandler ctl.Advance, New FarPoint.Win.Spread.AdvanceEventHandler(AddressOf HandleAdvance)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not BlockSelectedEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.BlockSelected, New AxFPSpread._DSpreadEvents_BlockSelectedEventHandler(AddressOf HandleBlockSelected)
            AddHandler ctl.SelectionChanged, New FarPoint.Win.Spread.SelectionChangedEventHandler(AddressOf HandleBlockSelected)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not ButtonClickedEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.ButtonClicked, New AxFPSpread._DSpreadEvents_ButtonClickedEventHandler(AddressOf HandleButtonClicked)
            AddHandler ctl.ButtonClicked, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleButtonClicked)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not ChangeEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.Change, New AxFPSpread._DSpreadEvents_ChangeEventHandler(AddressOf HandleChange)
            AddHandler ctl.Change, New FarPoint.Win.Spread.ChangeEventHandler(AddressOf HandleChange)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not ClickEventEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxMSFlexGrid VB→VB.NET変換
            'AddHandler ctl.ClickEvent, New AxFPSpread._DSpreadEvents_ClickEventHandler(AddressOf HandleClickEvent)
            AddHandler ctl.CellClick, New FarPoint.Win.Spread.CellClickEventHandler(AddressOf HandleClickEvent)
            '--修正終了　2021年06月05:MK（ツール）- AxMSFlexGrid VB→VB.NET変換
        End If
        If Not ColWidthChangeEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.ColWidthChange, New AxFPSpread._DSpreadEvents_ColWidthChangeEventHandler(AddressOf HandleColWidthChange)
            AddHandler ctl.ColumnWidthChanged, New FarPoint.Win.Spread.ColumnWidthChangedEventHandler(AddressOf HandleColWidthChange)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not CustomFunctionEvent Is Nothing Then
        '    AddHandler ctl.CustomFunction, New AxFPSpread._DSpreadEvents_CustomFunctionEventHandler(AddressOf HandleCustomFunction)
        'End If
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not DataColConfigEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.DataColConfig, New AxFPSpread._DSpreadEvents_DataColConfigEventHandler(AddressOf HandleDataColConfig)
            AddHandler ctl.DataColumnConfigure, New FarPoint.Win.Spread.DataColumnConfigureEventHandler(AddressOf HandleDataColConfig)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not DataFillEvent Is Nothing Then
        '    AddHandler ctl.DataFill, New AxFPSpread._DSpreadEvents_DataFillEventHandler(AddressOf HandleDataFill)
        'End If
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not DblClickEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxMSFlexGrid VB→VB.NET変換
            'AddHandler ctl.DblClick, New AxFPSpread._DSpreadEvents_DblClickEventHandler(AddressOf HandleDblClick)
            AddHandler ctl.CellDoubleClick, New FarPoint.Win.Spread.CellClickEventHandler(AddressOf HandleDblClick)
            '--修正終了　2021年06月05:MK（ツール）- AxMSFlexGrid VB→VB.NET変換
        End If
        If Not DragDropBlockEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.DragDropBlock, New AxFPSpread._DSpreadEvents_DragDropBlockEventHandler(AddressOf HandleDragDropBlock)
            AddHandler ctl.DragDropBlock, New FarPoint.Win.Spread.DragDropBlockEventHandler(AddressOf HandleDragDropBlock)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not DrawItemEvent Is Nothing Then
        '    AddHandler ctl.DrawItem, New AxFPSpread._DSpreadEvents_DrawItemEventHandler(AddressOf HandleDrawItem)
        'End If
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not EditErrorEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.EditError, New AxFPSpread._DSpreadEvents_EditErrorEventHandler(AddressOf HandleEditError)
            AddHandler ctl.EditError, New FarPoint.Win.Spread.EditErrorEventHandler(AddressOf HandleEditError)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not EditModeEventEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.EditModeEvent, New AxFPSpread._DSpreadEvents_EditModeEventHandler(AddressOf HandleEditModeEvent)
            AddHandler ctl.EditChange, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleEditModeEvent)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not EnterRowEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.EnterRow, New AxFPSpread._DSpreadEvents_EnterRowEventHandler(AddressOf HandleEnterRow)
            AddHandler ctl.EnterCell, New EnterCellEventHandler(AddressOf HandleEnterRow)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not LeaveCellEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.LeaveCell, New AxFPSpread._DSpreadEvents_LeaveCellEventHandler(AddressOf HandleLeaveCell)
            AddHandler ctl.LeaveCell, New FarPoint.Win.Spread.LeaveCellEventHandler(AddressOf HandleLeaveCell)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not LeaveRowEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.LeaveRow, New AxFPSpread._DSpreadEvents_LeaveRowEventHandler(AddressOf HandleLeaveRow)
            AddHandler ctl.LeaveCell, New FarPoint.Win.Spread.LeaveCellEventHandler(AddressOf HandleLeaveRow)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not PrintAbortEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.PrintAbort, New AxFPSpread._DSpreadEvents_PrintAbortEventHandler(AddressOf HandlePrintAbort)
            AddHandler ctl.PrintAbort, New FarPoint.Win.Spread.PrintAbortEventHandler(AddressOf HandlePrintAbort)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not QueryAdvanceEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.QueryAdvance, New AxFPSpread._DSpreadEvents_QueryAdvanceEventHandler(AddressOf HandleQueryAdvance)
            AddHandler ctl.Advance, New FarPoint.Win.Spread.AdvanceEventHandler(AddressOf HandleQueryAdvance)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not QueryDataEvent Is Nothing Then
        '    AddHandler ctl.QueryData, New AxFPSpread._DSpreadEvents_QueryDataEventHandler(AddressOf HandleQueryData)
        'End If
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not RightClickEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.RightClick, New AxFPSpread._DSpreadEvents_RightClickEventHandler(AddressOf HandleRightClick)
            AddHandler ctl.CellClick, New FarPoint.Win.Spread.CellClickEventHandler(AddressOf HandleRightClick)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not RowHeightChangeEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.RowHeightChange, New AxFPSpread._DSpreadEvents_RowHeightChangeEventHandler(AddressOf HandleRowHeightChange)
            AddHandler ctl.RowHeightChanged, New FarPoint.Win.Spread.RowHeightChangedEventHandler(AddressOf HandleRowHeightChange)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not SelChangeEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.SelChange, New AxFPSpread._DSpreadEvents_SelChangeEventHandler(AddressOf HandleSelChange)
            AddHandler ctl.SelectionChanged, New FarPoint.Win.Spread.SelectionChangedEventHandler(AddressOf HandleSelChange)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not TopLeftChangeEvent Is Nothing Then
        '    AddHandler ctl.TopLeftChange, New AxFPSpread._DSpreadEvents_TopLeftChangeEventHandler(AddressOf HandleTopLeftChange)
        'End If
        If Not TopChangeEvent Is Nothing Then
            AddHandler ctl.TopChange, New FarPoint.Win.Spread.TopChangeEventHandler(AddressOf HandleTopChange)
        End If

        If Not LeftChangeEvent Is Nothing Then
            AddHandler ctl.LeftChange, New FarPoint.Win.Spread.LeftChangeEventHandler(AddressOf HandleLeftChange)
        End If
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not UserFormulaEnteredEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.UserFormulaEntered, New AxFPSpread._DSpreadEvents_UserFormulaEnteredEventHandler(AddressOf HandleUserFormulaEntered)
            AddHandler ctl.UserFormulaEntered, New FarPoint.Win.Spread.UserFormulaEnteredEventHandler(AddressOf HandleUserFormulaEntered)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not VirtualClearDataEvent Is Nothing Then
        '    AddHandler ctl.VirtualClearData, New AxFPSpread._DSpreadEvents_VirtualClearDataEventHandler(AddressOf HandleVirtualClearData)
        'End Ifs
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not PrintMsgBoxEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.PrintMsgBox, New AxFPSpread._DSpreadEvents_PrintMsgBoxEventHandler(AddressOf HandlePrintMsgBox)
            AddHandler ctl.PrintMessageBox, New FarPoint.Win.Spread.PrintMessageBoxEventHandler(AddressOf HandlePrintMsgBox)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not ComboCloseUpEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.ComboCloseUp, New AxFPSpread._DSpreadEvents_ComboCloseUpEventHandler(AddressOf HandleComboCloseUp)
            AddHandler ctl.ComboCloseUp, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleComboCloseUp)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not ComboDropDownEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.ComboDropDown, New AxFPSpread._DSpreadEvents_ComboDropDownEventHandler(AddressOf HandleComboDropDown)
            AddHandler ctl.ComboDropDown, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleComboDropDown)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not ComboSelChangeEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.ComboSelChange, New AxFPSpread._DSpreadEvents_ComboSelChangeEventHandler(AddressOf HandleComboSelChange)
            AddHandler ctl.ComboSelChange, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleComboSelChange)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not TextTipFetchEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.TextTipFetch, New AxFPSpread._DSpreadEvents_TextTipFetchEventHandler(AddressOf HandleTextTipFetch)
            AddHandler ctl.TextTipFetch, New FarPoint.Win.Spread.TextTipFetchEventHandler(AddressOf HandleTextTipFetch)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not EditChangeEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.EditChange, New AxFPSpread._DSpreadEvents_EditChangeEventHandler(AddressOf HandleEditChange)
            AddHandler ctl.EditChange, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleEditChange)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        'If Not OLECompleteDragEvent Is Nothing Then
        '    AddHandler ctl.OLECompleteDrag, New AxFPSpread._DSpreadEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
        'End If
        'If Not OLEDragDropEvent Is Nothing Then
        '    AddHandler ctl.OLEDragDrop, New AxFPSpread._DSpreadEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
        'End If
        'If Not OLEDragOverEvent Is Nothing Then
        '    AddHandler ctl.OLEDragOver, New AxFPSpread._DSpreadEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
        'End If
        'If Not OLEGiveFeedbackEvent Is Nothing Then
        '    AddHandler ctl.OLEGiveFeedback, New AxFPSpread._DSpreadEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
        'End If
        'If Not OLESetDataEvent Is Nothing Then
        '    AddHandler ctl.OLESetData, New AxFPSpread._DSpreadEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
        'End If
        'If Not OLEStartDragEvent Is Nothing Then
        '    AddHandler ctl.OLEStartDrag, New AxFPSpread._DSpreadEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
        'End If
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        If Not KeyDownEventEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.KeyDownEvent, New AxFPSpread._DSpreadEvents_KeyDownEventHandler(AddressOf HandleKeyDownEvent)
            AddHandler ctl.KeyDown, New KeyEventHandler(AddressOf HandleKeyDownEvent)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not KeyPressEventEvent Is Nothing Then
            '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
            'AddHandler ctl.KeyPressEvent, New AxFPSpread._DSpreadEvents_KeyPressEventHandler(AddressOf HandleKeyPressEvent)
            AddHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf HandleKeyPressEvent)
            '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        End If
        If Not KeyUpEventEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.KeyUpEvent, New AxFPSpread._DSpreadEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
            AddHandler ctl.KeyUp, New KeyEventHandler(AddressOf HandleKeyUpEvent)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not MouseDownEventEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.MouseDownEvent, New AxFPSpread._DSpreadEvents_MouseDownEventHandler(AddressOf HandleMouseDownEvent)
            AddHandler ctl.MouseDown, New MouseEventHandler(AddressOf HandleMouseDownEvent)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not MouseMoveEventEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.MouseMoveEvent, New AxFPSpread._DSpreadEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
            AddHandler ctl.MouseMove, New MouseEventHandler(AddressOf HandleMouseMoveEvent)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
        If Not MouseUpEventEvent Is Nothing Then
            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
            'AddHandler ctl.MouseUpEvent, New AxFPSpread._DSpreadEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
            AddHandler ctl.MouseUp, New MouseEventHandler(AddressOf HandleMouseUpEvent)
            '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        End If
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleAdvance (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_AdvanceEvent)
    Private Sub HandleAdvance(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.AdvanceEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [Advance](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleBlockSelected(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_BlockSelectedEvent)
    Private Sub HandleBlockSelected(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.SelectionChangedEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [BlockSelected](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleButtonClicked (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ButtonClickedEvent)
    Private Sub HandleButtonClicked(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [ButtonClicked](sender, e)
    End Sub

    Private Sub HandleChange(ByVal sender As System.Object, ByVal e As ChangeEventArgs)
        RaiseEvent [Change](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleClickEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ClickEvent)
    Private Sub HandleClickEvent(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [ClickEvent](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleColWidthChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ColWidthChangeEvent)
    Private Sub HandleColWidthChange(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.ColumnWidthChangedEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [ColWidthChange](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleCustomFunction(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_CustomFunctionEvent)
    '    RaiseEvent [CustomFunction](sender, e)
    'End Sub
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleDataColConfig(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataColConfigEvent)
    Private Sub HandleDataColConfig(ByVal sender As System.Object, ByVal e As DataColumnConfigureEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [DataColConfig](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleDataFill(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataFillEvent)
    '    RaiseEvent [DataFill](sender, e)
    'End Sub
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleDblClick (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DblClickEvent)
    Private Sub HandleDblClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [DblClick](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleDragDropBlock(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DragDropBlockEvent)
    Private Sub HandleDragDropBlock(ByVal sender As System.Object, ByVal e As DragDropBlockEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [DragDropBlock](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleDrawItem(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DrawItemEvent)
    '    RaiseEvent [DrawItem](sender, e)
    'End Sub
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    'Private Sub HandleEditError(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditErrorEvent)

    Private Sub HandleEditError(ByVal sender As System.Object, ByVal e As EditErrorEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [EditError](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleEditModeEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditModeEvent)
    Private Sub HandleEditModeEvent(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [EditModeEvent](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleEnterRow(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EnterRowEvent)
    Private Sub HandleEnterRow(ByVal sender As System.Object, ByVal e As EnterCellEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [EnterRow](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleLeaveCell (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveCellEvent)
    Private Sub HandleLeaveCell(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [LeaveCell](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleLeaveRow(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveRowEvent)
    Private Sub HandleLeaveRow(ByVal sender As System.Object, ByVal e As LeaveCellEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [LeaveRow](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandlePrintAbort(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintAbortEvent)
    Private Sub HandlePrintAbort(ByVal sender As System.Object, ByVal e As PrintAbortEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [PrintAbort](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleQueryAdvance(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryAdvanceEvent)
    Private Sub HandleQueryAdvance(ByVal sender As System.Object, ByVal e As AdvanceEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [QueryAdvance](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleQueryData(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryDataEvent)
    '    RaiseEvent [QueryData](sender, e)
    'End Sub
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleRightClick(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RightClickEvent)
    Private Sub HandleRightClick(ByVal sender As System.Object, ByVal e As CellClickEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [RightClick](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleRowHeightChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RowHeightChangeEvent)
    Private Sub HandleRowHeightChange(ByVal sender As System.Object, ByVal e As RowHeightChangedEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [RowHeightChange](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleSelChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_SelChangeEvent)
    Private Sub HandleSelChange(ByVal sender As System.Object, ByVal e As SelectionChangedEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [SelChange](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleTopLeftChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TopLeftChangeEvent)
    Private Sub HandleTopChange(ByVal sender As System.Object, ByVal e As TopChangeEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [TopChange](sender, e)
    End Sub

    Private Sub HandleLeftChange(ByVal sender As System.Object, ByVal e As LeftChangeEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [LeftChange](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleUserFormulaEntered(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_UserFormulaEnteredEvent)
    Private Sub HandleUserFormulaEntered(ByVal sender As System.Object, ByVal e As UserFormulaEnteredEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [UserFormulaEntered](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleVirtualClearData(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_VirtualClearDataEvent)
    '    RaiseEvent [VirtualClearData](sender, e)
    'End Sub
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandlePrintMsgBox(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintMsgBoxEvent)
    Private Sub HandlePrintMsgBox(ByVal sender As System.Object, ByVal e As PrintMessageBoxEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [PrintMsgBox](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleComboCloseUp(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboCloseUpEvent)
    Private Sub HandleComboCloseUp(ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [ComboCloseUp](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleComboDropDown(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboDropDownEvent)
    Private Sub HandleComboDropDown(ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [ComboDropDown](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleComboSelChange (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboSelChangeEvent)
    Private Sub HandleComboSelChange(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [ComboSelChange](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleTextTipFetch(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TextTipFetchEvent)
    Private Sub HandleTextTipFetch(ByVal sender As System.Object, ByVal e As TextTipFetchEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [TextTipFetch](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleEditChange (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditChangeEvent)
    Private Sub HandleEditChange(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [EditChange](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleOLECompleteDrag(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLECompleteDragEvent)
    '    RaiseEvent [OLECompleteDrag](sender, e)
    'End Sub

    'Private Sub HandleOLEDragDrop(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEDragDropEvent)
    '    RaiseEvent [OLEDragDrop](sender, e)
    'End Sub

    'Private Sub HandleOLEDragOver(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEDragOverEvent)
    '    RaiseEvent [OLEDragOver](sender, e)
    'End Sub

    'Private Sub HandleOLEGiveFeedback(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEGiveFeedbackEvent)
    '    RaiseEvent [OLEGiveFeedback](sender, e)
    'End Sub

    'Private Sub HandleOLESetData(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLESetDataEvent)
    '    RaiseEvent [OLESetData](sender, e)
    'End Sub

    'Private Sub HandleOLEStartDrag(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEStartDragEvent)
    '    RaiseEvent [OLEStartDrag](sender, e)
    'End Sub
    '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleKeyDownEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyDownEvent)
    Private Sub HandleKeyDownEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [KeyDownEvent](sender, e)
    End Sub

    '++修正開始　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Private Sub HandleKeyPressEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyPressEvent)
    Private Sub HandleKeyPressEvent(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '--修正終了　2021年06月05:MK（ツール）- AxFPSpread VB→VB.NET変換
        RaiseEvent [KeyPressEvent](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyUpEvent)
    Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [KeyUpEvent](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseDownEvent)
    Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [MouseDownEvent](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseMoveEvent)
    Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [MouseMoveEvent](sender, e)
    End Sub

    '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
    'Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseUpEvent)
    Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
        RaiseEvent [MouseUpEvent](sender, e)
    End Sub

End Class

