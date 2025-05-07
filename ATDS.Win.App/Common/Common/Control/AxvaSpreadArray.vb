'UPGRADE_WARNING: The entire project must be compiled once before a form with an ActiveX Control Array can be displayed

Imports System.ComponentModel
Imports System.Windows.Forms
Imports Common
Imports FarPoint.Win.Spread

'++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
'<ProvideProperty("Index",GetType(AxFPSpread.AxvaSpread))> Public Class AxvaSpreadArray
<ProvideProperty("Index", GetType(CustomizeFPSpread))> Public Class AxvaSpreadArray
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseControlArray
    Implements IExtenderProvider

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Container As IContainer)
        MyBase.New(Container)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [Advance] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_AdvanceEvent)
    Public Shadows Event [Advance](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.AdvanceEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [BlockSelected](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_BlockSelectedEvent)
    Public Shadows Event [BlockSelected](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.SelectionChangedEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [ButtonClicked] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ButtonClickedEvent)
    Public Shadows Event [ButtonClicked](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [Change](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ChangeEvent)
    Public Shadows Event [Change](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.ChangeEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [ClickEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ClickEvent)
    Public Shadows Event [ClickEvent](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [ColWidthChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ColWidthChangeEvent)
    Public Shadows Event [ColWidthChange](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.ColumnWidthChangedEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [CustomFunction](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_CustomFunctionEvent)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [DataColConfig](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataColConfigEvent)
    Public Shadows Event [DataColConfig](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.DataColumnConfigureEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [DataFill](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataFillEvent)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [DblClick] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DblClickEvent)
    Public Shadows Event [DblClick](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [DragDropBlock](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DragDropBlockEvent)
    Public Shadows Event [DragDropBlock](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.DragDropBlockEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [DrawItem](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DrawItemEvent)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    Public Shadows Event [EditError](ByVal sender As System.Object, ByVal e As EditErrorEventArgs)
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [EditModeEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditModeEvent)
    Public Shadows Event [EditModeEvent](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [EnterRow](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EnterRowEvent)
    Public Shadows Event [EnterRow](ByVal sender As System.Object, ByVal e As EnterCellEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [LeaveCell] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveCellEvent)
    Public Shadows Event [LeaveCell](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [LeaveRow](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveRowEvent)
    Public Shadows Event [LeaveRow](ByVal sender As System.Object, ByVal e As LeaveCellEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [PrintAbort](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintAbortEvent)
    Public Shadows Event [PrintAbort](ByVal sender As System.Object, ByVal e As PrintAbortEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [QueryAdvance](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryAdvanceEvent)
    Public Shadows Event [QueryAdvance](ByVal sender As System.Object, ByVal e As AdvanceEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [QueryData](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryDataEvent)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [RightClick](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RightClickEvent)
    Public Shadows Event [RightClick](ByVal sender As System.Object, ByVal e As CellClickEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [RowHeightChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RowHeightChangeEvent)
    Public Shadows Event [RowHeightChange](ByVal sender As System.Object, ByVal e As RowHeightChangedEventArgs)
    '--�C���J�n�@2021�N06��13��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [SelChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_SelChangeEvent)
    Public Shadows Event [SelChange](ByVal sender As System.Object, ByVal e As SelectionChangedEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [TopLeftChange](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TopLeftChangeEvent)
    Public Shadows Event [TopChange](ByVal sender As System.Object, ByVal e As TopChangeEventArgs)
    Public Shadows Event [LeftChange](ByVal sender As System.Object, ByVal e As LeftChangeEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [UserFormulaEntered](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_UserFormulaEnteredEvent)
    Public Shadows Event [UserFormulaEntered](ByVal sender As System.Object, ByVal e As UserFormulaEnteredEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [VirtualClearData](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_VirtualClearDataEvent)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [PrintMsgBox](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintMsgBoxEvent)
    Public Shadows Event [PrintMsgBox](ByVal sender As System.Object, ByVal e As PrintMessageBoxEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [ComboCloseUp](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboCloseUpEvent)
    Public Shadows Event [ComboCloseUp](ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [ComboDropDown](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboDropDownEvent)
    Public Shadows Event [ComboDropDown](ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [ComboSelChange] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboSelChangeEvent)
    Public Shadows Event [ComboSelChange](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [TextTipFetch](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TextTipFetchEvent)
    Public Shadows Event [TextTipFetch](ByVal sender As System.Object, ByVal e As TextTipFetchEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [EditChange] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditChangeEvent)
    Public Shadows Event [EditChange](ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [OLECompleteDrag](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLECompleteDragEvent)
    'Public Shadows Event [OLEDragDrop](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEDragDropEvent)
    'Public Shadows Event [OLEDragOver](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEDragOverEvent)
    'Public Shadows Event [OLEGiveFeedback](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEGiveFeedbackEvent)
    'Public Shadows Event [OLESetData](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLESetDataEvent)
    'Public Shadows Event [OLEStartDrag](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_OLEStartDragEvent)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [KeyDownEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyDownEvent)
    Public Shadows Event [KeyDownEvent](ByVal sender As System.Object, ByVal e As KeyEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Shadows Event [KeyPressEvent] (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyPressEvent)
    Public Shadows Event [KeyPressEvent](ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
    '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [KeyUpEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyUpEvent)
    Public Shadows Event [KeyUpEvent](ByVal sender As System.Object, ByVal e As KeyEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [MouseDownEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseDownEvent)
    Public Shadows Event [MouseDownEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [MouseMoveEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseMoveEvent)
    Public Shadows Event [MouseMoveEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Public Shadows Event [MouseUpEvent](ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseUpEvent)
    Public Shadows Event [MouseUpEvent](ByVal sender As System.Object, ByVal e As MouseEventArgs)
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
        If TypeOf target Is CustomizeFPSpread Then
            Return BaseCanExtend(target)
        End If
    End Function

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Function GetIndex(ByVal o As AxFPSpread.AxvaSpread) As Short
    Public Function GetIndex(ByVal o As Common.CustomizeFPSpread) As Short
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        Return BaseGetIndex(o)
    End Function

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxFPSpread.AxvaSpread, ByVal Index As Short)
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As Common.CustomizeFPSpread, ByVal Index As Short)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        BaseSetIndex(o, Index)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxFPSpread.AxvaSpread) As Boolean
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As Common.CustomizeFPSpread) As Boolean
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        Return BaseShouldSerializeIndex(o)
    End Function

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    '<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxFPSpread.AxvaSpread)
    <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As Common.CustomizeFPSpread)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        BaseResetIndex(o)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Default Public ReadOnly Property Item(ByVal Index As Short) As AxFPSpread.AxvaSpread
    Default Public ReadOnly Property Item(ByVal Index As Short) As Common.CustomizeFPSpread
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        Get
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'Item = CType(BaseGetItem(Index), AxFPSpread.AxvaSpread)
            Item = CType(BaseGetItem(Index), CustomizeFPSpread)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End Get
    End Property

    Protected Overrides Function GetControlInstanceType() As System.Type
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'Return GetType(AxFPSpread.AxvaSpread)
        Return GetType(CustomizeFPSpread)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    End Function

    Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
        '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        'Dim ctl As AxFPSpread.AxvaSpread = CType(o, AxFPSpread.AxvaSpread)
        Dim ctl As Common.CustomizeFPSpread = CType(o, Common.CustomizeFPSpread)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        'MyBase.HookUpControlEvents(o)

        If Not AdvanceEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.Advance, New AxFPSpread._DSpreadEvents_AdvanceEventHandler(AddressOf HandleAdvance)
            AddHandler ctl.Advance, New FarPoint.Win.Spread.AdvanceEventHandler(AddressOf HandleAdvance)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not BlockSelectedEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.BlockSelected, New AxFPSpread._DSpreadEvents_BlockSelectedEventHandler(AddressOf HandleBlockSelected)
            AddHandler ctl.SelectionChanged, New FarPoint.Win.Spread.SelectionChangedEventHandler(AddressOf HandleBlockSelected)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not ButtonClickedEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.ButtonClicked, New AxFPSpread._DSpreadEvents_ButtonClickedEventHandler(AddressOf HandleButtonClicked)
            AddHandler ctl.ButtonClicked, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleButtonClicked)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not ChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.Change, New AxFPSpread._DSpreadEvents_ChangeEventHandler(AddressOf HandleChange)
            AddHandler ctl.Change, New FarPoint.Win.Spread.ChangeEventHandler(AddressOf HandleChange)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not ClickEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxMSFlexGrid VB��VB.NET�ϊ�
            'AddHandler ctl.ClickEvent, New AxFPSpread._DSpreadEvents_ClickEventHandler(AddressOf HandleClickEvent)
            AddHandler ctl.CellClick, New FarPoint.Win.Spread.CellClickEventHandler(AddressOf HandleClickEvent)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxMSFlexGrid VB��VB.NET�ϊ�
        End If
        If Not ColWidthChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.ColWidthChange, New AxFPSpread._DSpreadEvents_ColWidthChangeEventHandler(AddressOf HandleColWidthChange)
            AddHandler ctl.ColumnWidthChanged, New FarPoint.Win.Spread.ColumnWidthChangedEventHandler(AddressOf HandleColWidthChange)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'If Not CustomFunctionEvent Is Nothing Then
        '    AddHandler ctl.CustomFunction, New AxFPSpread._DSpreadEvents_CustomFunctionEventHandler(AddressOf HandleCustomFunction)
        'End If
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not DataColConfigEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.DataColConfig, New AxFPSpread._DSpreadEvents_DataColConfigEventHandler(AddressOf HandleDataColConfig)
            AddHandler ctl.DataColumnConfigure, New FarPoint.Win.Spread.DataColumnConfigureEventHandler(AddressOf HandleDataColConfig)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'If Not DataFillEvent Is Nothing Then
        '    AddHandler ctl.DataFill, New AxFPSpread._DSpreadEvents_DataFillEventHandler(AddressOf HandleDataFill)
        'End If
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not DblClickEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxMSFlexGrid VB��VB.NET�ϊ�
            'AddHandler ctl.DblClick, New AxFPSpread._DSpreadEvents_DblClickEventHandler(AddressOf HandleDblClick)
            AddHandler ctl.CellDoubleClick, New FarPoint.Win.Spread.CellClickEventHandler(AddressOf HandleDblClick)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxMSFlexGrid VB��VB.NET�ϊ�
        End If
        If Not DragDropBlockEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.DragDropBlock, New AxFPSpread._DSpreadEvents_DragDropBlockEventHandler(AddressOf HandleDragDropBlock)
            AddHandler ctl.DragDropBlock, New FarPoint.Win.Spread.DragDropBlockEventHandler(AddressOf HandleDragDropBlock)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'If Not DrawItemEvent Is Nothing Then
        '    AddHandler ctl.DrawItem, New AxFPSpread._DSpreadEvents_DrawItemEventHandler(AddressOf HandleDrawItem)
        'End If
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not EditErrorEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.EditError, New AxFPSpread._DSpreadEvents_EditErrorEventHandler(AddressOf HandleEditError)
            AddHandler ctl.EditError, New FarPoint.Win.Spread.EditErrorEventHandler(AddressOf HandleEditError)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not EditModeEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.EditModeEvent, New AxFPSpread._DSpreadEvents_EditModeEventHandler(AddressOf HandleEditModeEvent)
            AddHandler ctl.EditChange, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleEditModeEvent)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not EnterRowEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.EnterRow, New AxFPSpread._DSpreadEvents_EnterRowEventHandler(AddressOf HandleEnterRow)
            AddHandler ctl.EnterCell, New EnterCellEventHandler(AddressOf HandleEnterRow)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not LeaveCellEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.LeaveCell, New AxFPSpread._DSpreadEvents_LeaveCellEventHandler(AddressOf HandleLeaveCell)
            AddHandler ctl.LeaveCell, New FarPoint.Win.Spread.LeaveCellEventHandler(AddressOf HandleLeaveCell)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not LeaveRowEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.LeaveRow, New AxFPSpread._DSpreadEvents_LeaveRowEventHandler(AddressOf HandleLeaveRow)
            AddHandler ctl.LeaveCell, New FarPoint.Win.Spread.LeaveCellEventHandler(AddressOf HandleLeaveRow)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not PrintAbortEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.PrintAbort, New AxFPSpread._DSpreadEvents_PrintAbortEventHandler(AddressOf HandlePrintAbort)
            AddHandler ctl.PrintAbort, New FarPoint.Win.Spread.PrintAbortEventHandler(AddressOf HandlePrintAbort)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not QueryAdvanceEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.QueryAdvance, New AxFPSpread._DSpreadEvents_QueryAdvanceEventHandler(AddressOf HandleQueryAdvance)
            AddHandler ctl.Advance, New FarPoint.Win.Spread.AdvanceEventHandler(AddressOf HandleQueryAdvance)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'If Not QueryDataEvent Is Nothing Then
        '    AddHandler ctl.QueryData, New AxFPSpread._DSpreadEvents_QueryDataEventHandler(AddressOf HandleQueryData)
        'End If
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not RightClickEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.RightClick, New AxFPSpread._DSpreadEvents_RightClickEventHandler(AddressOf HandleRightClick)
            AddHandler ctl.CellClick, New FarPoint.Win.Spread.CellClickEventHandler(AddressOf HandleRightClick)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not RowHeightChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.RowHeightChange, New AxFPSpread._DSpreadEvents_RowHeightChangeEventHandler(AddressOf HandleRowHeightChange)
            AddHandler ctl.RowHeightChanged, New FarPoint.Win.Spread.RowHeightChangedEventHandler(AddressOf HandleRowHeightChange)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not SelChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.SelChange, New AxFPSpread._DSpreadEvents_SelChangeEventHandler(AddressOf HandleSelChange)
            AddHandler ctl.SelectionChanged, New FarPoint.Win.Spread.SelectionChangedEventHandler(AddressOf HandleSelChange)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'If Not TopLeftChangeEvent Is Nothing Then
        '    AddHandler ctl.TopLeftChange, New AxFPSpread._DSpreadEvents_TopLeftChangeEventHandler(AddressOf HandleTopLeftChange)
        'End If
        If Not TopChangeEvent Is Nothing Then
            AddHandler ctl.TopChange, New FarPoint.Win.Spread.TopChangeEventHandler(AddressOf HandleTopChange)
        End If

        If Not LeftChangeEvent Is Nothing Then
            AddHandler ctl.LeftChange, New FarPoint.Win.Spread.LeftChangeEventHandler(AddressOf HandleLeftChange)
        End If
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not UserFormulaEnteredEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.UserFormulaEntered, New AxFPSpread._DSpreadEvents_UserFormulaEnteredEventHandler(AddressOf HandleUserFormulaEntered)
            AddHandler ctl.UserFormulaEntered, New FarPoint.Win.Spread.UserFormulaEnteredEventHandler(AddressOf HandleUserFormulaEntered)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        'If Not VirtualClearDataEvent Is Nothing Then
        '    AddHandler ctl.VirtualClearData, New AxFPSpread._DSpreadEvents_VirtualClearDataEventHandler(AddressOf HandleVirtualClearData)
        'End Ifs
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not PrintMsgBoxEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.PrintMsgBox, New AxFPSpread._DSpreadEvents_PrintMsgBoxEventHandler(AddressOf HandlePrintMsgBox)
            AddHandler ctl.PrintMessageBox, New FarPoint.Win.Spread.PrintMessageBoxEventHandler(AddressOf HandlePrintMsgBox)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not ComboCloseUpEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.ComboCloseUp, New AxFPSpread._DSpreadEvents_ComboCloseUpEventHandler(AddressOf HandleComboCloseUp)
            AddHandler ctl.ComboCloseUp, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleComboCloseUp)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not ComboDropDownEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.ComboDropDown, New AxFPSpread._DSpreadEvents_ComboDropDownEventHandler(AddressOf HandleComboDropDown)
            AddHandler ctl.ComboDropDown, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleComboDropDown)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not ComboSelChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.ComboSelChange, New AxFPSpread._DSpreadEvents_ComboSelChangeEventHandler(AddressOf HandleComboSelChange)
            AddHandler ctl.ComboSelChange, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleComboSelChange)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not TextTipFetchEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.TextTipFetch, New AxFPSpread._DSpreadEvents_TextTipFetchEventHandler(AddressOf HandleTextTipFetch)
            AddHandler ctl.TextTipFetch, New FarPoint.Win.Spread.TextTipFetchEventHandler(AddressOf HandleTextTipFetch)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not EditChangeEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.EditChange, New AxFPSpread._DSpreadEvents_EditChangeEventHandler(AddressOf HandleEditChange)
            AddHandler ctl.EditChange, New FarPoint.Win.Spread.EditorNotifyEventHandler(AddressOf HandleEditChange)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
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
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        If Not KeyDownEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.KeyDownEvent, New AxFPSpread._DSpreadEvents_KeyDownEventHandler(AddressOf HandleKeyDownEvent)
            AddHandler ctl.KeyDown, New KeyEventHandler(AddressOf HandleKeyDownEvent)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not KeyPressEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
            'AddHandler ctl.KeyPressEvent, New AxFPSpread._DSpreadEvents_KeyPressEventHandler(AddressOf HandleKeyPressEvent)
            AddHandler ctl.KeyPress, New KeyPressEventHandler(AddressOf HandleKeyPressEvent)
            '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        End If
        If Not KeyUpEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.KeyUpEvent, New AxFPSpread._DSpreadEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
            AddHandler ctl.KeyUp, New KeyEventHandler(AddressOf HandleKeyUpEvent)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not MouseDownEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.MouseDownEvent, New AxFPSpread._DSpreadEvents_MouseDownEventHandler(AddressOf HandleMouseDownEvent)
            AddHandler ctl.MouseDown, New MouseEventHandler(AddressOf HandleMouseDownEvent)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not MouseMoveEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.MouseMoveEvent, New AxFPSpread._DSpreadEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
            AddHandler ctl.MouseMove, New MouseEventHandler(AddressOf HandleMouseMoveEvent)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
        If Not MouseUpEventEvent Is Nothing Then
            '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
            'AddHandler ctl.MouseUpEvent, New AxFPSpread._DSpreadEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
            AddHandler ctl.MouseUp, New MouseEventHandler(AddressOf HandleMouseUpEvent)
            '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        End If
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleAdvance (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_AdvanceEvent)
    Private Sub HandleAdvance(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.AdvanceEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [Advance](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleBlockSelected(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_BlockSelectedEvent)
    Private Sub HandleBlockSelected(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.SelectionChangedEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [BlockSelected](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleButtonClicked (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ButtonClickedEvent)
    Private Sub HandleButtonClicked(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [ButtonClicked](sender, e)
    End Sub

    Private Sub HandleChange(ByVal sender As System.Object, ByVal e As ChangeEventArgs)
        RaiseEvent [Change](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleClickEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ClickEvent)
    Private Sub HandleClickEvent(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [ClickEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleColWidthChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ColWidthChangeEvent)
    Private Sub HandleColWidthChange(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.ColumnWidthChangedEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [ColWidthChange](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleCustomFunction(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_CustomFunctionEvent)
    '    RaiseEvent [CustomFunction](sender, e)
    'End Sub
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleDataColConfig(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataColConfigEvent)
    Private Sub HandleDataColConfig(ByVal sender As System.Object, ByVal e As DataColumnConfigureEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [DataColConfig](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleDataFill(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DataFillEvent)
    '    RaiseEvent [DataFill](sender, e)
    'End Sub
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleDblClick (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DblClickEvent)
    Private Sub HandleDblClick(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.CellClickEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [DblClick](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleDragDropBlock(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DragDropBlockEvent)
    Private Sub HandleDragDropBlock(ByVal sender As System.Object, ByVal e As DragDropBlockEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [DragDropBlock](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleDrawItem(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_DrawItemEvent)
    '    RaiseEvent [DrawItem](sender, e)
    'End Sub
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    'Private Sub HandleEditError(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditErrorEvent)

    Private Sub HandleEditError(ByVal sender As System.Object, ByVal e As EditErrorEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [EditError](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleEditModeEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditModeEvent)
    Private Sub HandleEditModeEvent(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [EditModeEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleEnterRow(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EnterRowEvent)
    Private Sub HandleEnterRow(ByVal sender As System.Object, ByVal e As EnterCellEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [EnterRow](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleLeaveCell (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveCellEvent)
    Private Sub HandleLeaveCell(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.LeaveCellEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [LeaveCell](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleLeaveRow(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_LeaveRowEvent)
    Private Sub HandleLeaveRow(ByVal sender As System.Object, ByVal e As LeaveCellEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [LeaveRow](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandlePrintAbort(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintAbortEvent)
    Private Sub HandlePrintAbort(ByVal sender As System.Object, ByVal e As PrintAbortEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [PrintAbort](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleQueryAdvance(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryAdvanceEvent)
    Private Sub HandleQueryAdvance(ByVal sender As System.Object, ByVal e As AdvanceEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [QueryAdvance](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleQueryData(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_QueryDataEvent)
    '    RaiseEvent [QueryData](sender, e)
    'End Sub
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleRightClick(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RightClickEvent)
    Private Sub HandleRightClick(ByVal sender As System.Object, ByVal e As CellClickEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [RightClick](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleRowHeightChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_RowHeightChangeEvent)
    Private Sub HandleRowHeightChange(ByVal sender As System.Object, ByVal e As RowHeightChangedEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [RowHeightChange](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleSelChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_SelChangeEvent)
    Private Sub HandleSelChange(ByVal sender As System.Object, ByVal e As SelectionChangedEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [SelChange](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleTopLeftChange(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TopLeftChangeEvent)
    Private Sub HandleTopChange(ByVal sender As System.Object, ByVal e As TopChangeEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [TopChange](sender, e)
    End Sub

    Private Sub HandleLeftChange(ByVal sender As System.Object, ByVal e As LeftChangeEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [LeftChange](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleUserFormulaEntered(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_UserFormulaEnteredEvent)
    Private Sub HandleUserFormulaEntered(ByVal sender As System.Object, ByVal e As UserFormulaEnteredEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [UserFormulaEntered](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleVirtualClearData(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_VirtualClearDataEvent)
    '    RaiseEvent [VirtualClearData](sender, e)
    'End Sub
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandlePrintMsgBox(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_PrintMsgBoxEvent)
    Private Sub HandlePrintMsgBox(ByVal sender As System.Object, ByVal e As PrintMessageBoxEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [PrintMsgBox](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleComboCloseUp(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboCloseUpEvent)
    Private Sub HandleComboCloseUp(ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [ComboCloseUp](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleComboDropDown(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboDropDownEvent)
    Private Sub HandleComboDropDown(ByVal sender As System.Object, ByVal e As EditorNotifyEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [ComboDropDown](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleComboSelChange (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_ComboSelChangeEvent)
    Private Sub HandleComboSelChange(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [ComboSelChange](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleTextTipFetch(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_TextTipFetchEvent)
    Private Sub HandleTextTipFetch(ByVal sender As System.Object, ByVal e As TextTipFetchEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [TextTipFetch](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleEditChange (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_EditChangeEvent)
    Private Sub HandleEditChange(ByVal sender As System.Object, ByVal e As FarPoint.Win.Spread.EditorNotifyEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [EditChange](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
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
    '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleKeyDownEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyDownEvent)
    Private Sub HandleKeyDownEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [KeyDownEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Private Sub HandleKeyPressEvent (ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyPressEvent)
    Private Sub HandleKeyPressEvent(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '--�C���I���@2021�N06��05:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
        RaiseEvent [KeyPressEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_KeyUpEvent)
    Private Sub HandleKeyUpEvent(ByVal sender As System.Object, ByVal e As KeyEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [KeyUpEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseDownEvent)
    Private Sub HandleMouseDownEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [MouseDownEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseMoveEvent)
    Private Sub HandleMouseMoveEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [MouseMoveEvent](sender, e)
    End Sub

    '++�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
    'Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As AxFPSpread._DSpreadEvents_MouseUpEvent)
    Private Sub HandleMouseUpEvent(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        '--�C���J�n�@2021�N06��14��:MK�i��j- VB��VB.NET�ϊ�
        RaiseEvent [MouseUpEvent](sender, e)
    End Sub

End Class

