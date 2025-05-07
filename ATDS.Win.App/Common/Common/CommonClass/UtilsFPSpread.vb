Imports System.Drawing
Imports System.Windows.Forms
Imports FarPoint.Win.Spread
Imports FarPoint.Win.Spread.CellType

Public Module UtilsFPSpread

    Dim lstColumn As List(Of ColumnProperties)

    Enum FPSpreadCellType
        BaseCellType
        ButtonCellType
        CheckBoxCellType
        ColorPickerCellType
        ComboBoxCellType
        CurrencyCellType
        DateTimeCellType
        EmptyCellType
        HyperLinkCellType
        ImageCellType
        ListBoxCellType
        MaskCellType
        NumberCellType
        PercentCellType
        ProgressCellType
        TextCellType
    End Enum

    Structure ColumnProperties
        Public ColumnIndex As Integer
        Public Width As Integer
        Public CellType As FPSpreadCellType
        Public Text As String
        Public Visible As Boolean
        Public CellReadOnly As Boolean
        Public MaxLength As Integer
        Public DecimalNum As Integer
        Public lstDisplayText As String()
        Public lstValue As String()
        Public CellText As String 'Button or Checkbox use
        Public CellHorizontalAlignment As CellHorizontalAlignment
        Public WordWrap As Boolean

        ''' <summary>
        ''' Init properites value of column
        ''' </summary>
        ''' <param name="pColumnIndex"></param>
        ''' <param name="pText"></param>
        ''' <param name="pWidth"></param>
        ''' <param name="pHeight"></param>
        ''' <param name="pMaxLength"></param>
        ''' <param name="pDecimalNum"></param>
        ''' <param name="plstDisplayText"></param>
        ''' <param name="plstValue"></param>
        ''' <param name="pCellType"></param>
        ''' <param name="pVisible"></param>
        ''' <param name="pCellReadOnly"></param>
        ''' <param name="cellText">Button or Checkbox use</param>
        Public Sub New(pColumnIndex As Integer,
                        Optional pText As String = " ",
                        Optional pWidth As Integer = 40,
                        Optional pMaxLength As Integer = 0,
                        Optional pDecimalNum As Integer = 0,
                        Optional plstDisplayText As String() = Nothing,
                        Optional plstValue As String() = Nothing,
                        Optional pCellType As FPSpreadCellType = FPSpreadCellType.TextCellType,
                        Optional pVisible As Boolean = True,
                        Optional pCellReadOnly As Boolean = False,
                        Optional pCellHorizontalAlignment As CellHorizontalAlignment = CellHorizontalAlignment.General,
                        Optional pcellText As String = "",
                        Optional pwordWrap As Boolean = False)
            ColumnIndex = pColumnIndex
            Text = pText
            Width = pWidth
            MaxLength = pMaxLength
            DecimalNum = pDecimalNum
            lstDisplayText = plstDisplayText
            lstValue = plstValue
            CellType = pCellType
            Visible = pVisible
            CellReadOnly = pCellReadOnly
            WordWrap = pwordWrap
            If CellHorizontalAlignment.General Then
                Select Case CellType
                    Case FPSpreadCellType.TextCellType
                        CellHorizontalAlignment = CellHorizontalAlignment.Left
                    Case FPSpreadCellType.DateTimeCellType
                        CellHorizontalAlignment = CellHorizontalAlignment.Center
                    Case FPSpreadCellType.NumberCellType
                        CellHorizontalAlignment = CellHorizontalAlignment.Right
                    Case FPSpreadCellType.EmptyCellType
                        CellHorizontalAlignment = CellHorizontalAlignment.Left
                End Select
            Else
                CellHorizontalAlignment = pCellHorizontalAlignment
            End If
            CellText = pcellText
        End Sub
    End Structure

    Public Sub SetWordWrapForColumn(ByRef col As ColumnProperties)
        col.WordWrap = True
    End Sub
    Public Sub SetInitFPSperad(ByRef spd As CustomizeFPSpread, Optional pLstColumn As List(Of ColumnProperties) = Nothing,
                               Optional iColumnHeaderHeight As Integer = 15)
        'set list column
        If pLstColumn IsNot Nothing Then
            lstColumn = pLstColumn
        End If

        SetStyleFPSPreadBlackStyle(spd,,,,, iColumnHeaderHeight,)
        spd.ActiveSheet.Rows.Default.Height = 17
        For Each columnProperties As ColumnProperties In lstColumn
            SetColStyle(spd, columnProperties)
        Next

        'ヘッダのハイライト表示を無効 Spread
        'spd.PaintSelectionHeader = False
    End Sub

    ''' <summary>
    ''' Set Black Style for FPSPread
    ''' </summary>
    ''' <param name="spd">FPSpread want to apply stype</param>
    ''' <param name="iRowCount">Set number row of spread</param>
    ''' <param name="iColumnCount">set number column of spread</param>
    ''' <param name="isShowRowHeader">show header of row or not</param>
    ''' <param name="isShowColumnHeader">show column header or not</param>
    ''' <param name="iColumnHeaderSize">height of column header</param>
    ''' <param name="iRowHeaderSize">width of Row Header</param>
    Public Sub SetStyleFPSPreadBlackStyle(ByRef spd As CustomizeFPSpread,
                                Optional iRowCount As Integer = 0,
                                Optional iColumnCount As Integer = 0,
                                Optional isShowRowHeader As Boolean = True,
                                Optional isShowColumnHeader As Boolean = True,
                                Optional iColumnHeaderSize As Integer = 15,
                                Optional iRowHeaderSize As Integer = 20)
        If spd.ActiveSheet IsNot Nothing Then
            spd.ActiveSheet.AutoCalculation = False
            'spd.ActiveSheet.ColumnCount = 0
            spd.ActiveSheet.DataAutoCellTypes = False
            'spd.ActiveSheet.RowCount = 0
            'spd.ActiveSheet.RowHeaderAutoText = HeaderAutoText
            spd.ActiveSheet.SheetName = "sheet"
        End If
        spd.AutoClipboard = False
        spd.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded
        spd.HorizontalScrollBarMode = FarPoint.Win.HorizontalScrollMode.Column
        spd.TabStripPolicy = TabStripPolicy.Never
        spd.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded
        spd.AllowDragDrop = False
        spd.AllowDragFill = False
        spd.AllowDrop = False
        spd.AllowRowMove = False
        spd.AllowDragFill = False
        spd.ColumnSplitBoxPolicy = SplitBoxPolicy.Never
        spd.RowSplitBoxPolicy = SplitBoxPolicy.Never

        spd.HorizontalScrollBarHeight = 21
        spd.VerticalScrollBarWidth = 20

        '全ての行の行高変更を禁止
        spd.ActiveSheet.Rows.Default.Resizable = False

        'Show RowHeader
        spd.ActiveSheet.RowHeaderVisible = isShowRowHeader

        'Show ColumnHeader
        spd.ActiveSheet.ColumnHeaderVisible = isShowColumnHeader

        'Set Headder size
        If iRowHeaderSize <> 0 Then
            spd.ActiveSheet.RowHeader.Columns(0).Width = iRowHeaderSize
        End If

        'Set Headder size
        If iColumnHeaderSize <> 0 Then
            spd.ActiveSheet.ColumnHeader.Rows(0).Height = iColumnHeaderSize
            If iColumnHeaderSize <= 20 Then
                spd.ActiveSheet.ColumnHeader.Rows(0).VerticalAlignment = CellVerticalAlignment.Top
            End If
        End If

        'Set Rows
        If iRowCount <> 0 Then
            spd.ActiveSheet.RowCount = iRowCount
        End If

        'Set Columns
        If iColumnCount <> 0 Then
            spd.ActiveSheet.ColumnCount = iColumnCount
        End If

        SetHeaderFormat(spd)

        spd.LegacyBehaviors = LegacyBehaviors.All
        spd.ActiveSheet.Protect = True

        spd.Font = DefineStatic.FPSPREAD_FONT


    End Sub

    Public Sub SetColStyle(ByRef spd As CustomizeFPSpread, columnProperties As ColumnProperties)

        Select Case columnProperties.CellType
            Case FPSpreadCellType.EmptyCellType
                Dim labelCellTyle As New EmptyCellType
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = labelCellTyle
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CanFocus = False
            Case FPSpreadCellType.TextCellType
                Dim textCellTyle As New TextCellType
                If columnProperties.CellReadOnly Then
                    textCellTyle.ReadOnly = True
                End If
                If columnProperties.MaxLength <> 0 Then
                    textCellTyle.MaxLength = columnProperties.MaxLength
                End If
                If columnProperties.WordWrap Then
                    textCellTyle.WordWrap = columnProperties.WordWrap
                    textCellTyle.Multiline = True
                End If
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = textCellTyle
            Case FPSpreadCellType.CheckBoxCellType
                Dim checkboxCellTyle As New CheckBoxCellType
                If columnProperties.cellText <> "" Then checkboxCellTyle.Caption = columnProperties.cellText
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = checkboxCellTyle
            Case FPSpreadCellType.ButtonCellType
                Dim buttonCellType As New ButtonCellType
                If columnProperties.cellText <> "" Then buttonCellType.Text = columnProperties.CellText
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = buttonCellType
            Case FPSpreadCellType.CurrencyCellType
                Dim currencycell As New FarPoint.Win.Spread.CellType.CurrencyCellType()
                currencycell.DecimalPlaces = columnProperties.DecimalNum
                currencycell.ShowCurrencySymbol = True
                currencycell.CurrencySymbol = "\"
                currencycell.ShowSeparator = True
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = currencycell
            Case FPSpreadCellType.NumberCellType
                Dim numberCellTyle As New NumberCellType
                numberCellTyle.DecimalPlaces = columnProperties.DecimalNum
                numberCellTyle.ShowSeparator = True
                If columnProperties.CellReadOnly Then
                    numberCellTyle.ReadOnly = True
                End If
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = numberCellTyle
                DirectCast(spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = columnProperties.DecimalNum
            Case FPSpreadCellType.ComboBoxCellType
                '++修正開始　2021年06月26日:MK（手）- VB→VB.NET変換
                'Dim combo As New ComboBoxCellType()
                'combo.Items = columnProperties.lstDisplayText
                'combo.ItemData = columnProperties.lstValue
                'combo.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData
                'spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = combo
                Dim combobox As New ComboBoxCellType
                If columnProperties.lstDisplayText IsNot Nothing Then
                    combobox.Items = columnProperties.lstDisplayText
                    combobox.DropDownOptions = FarPoint.Win.DropDownOptions.ButtonAndText
                    combobox.AutoCompleteMode = AutoCompleteMode.None
                    combobox.Editable = False
                End If
                spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CellType = combobox
                Try
                    spd.ActiveSheet.Cells(0, columnProperties.ColumnIndex).CellType = combobox
                Catch ex As Exception

                End Try
                '--修正開始　2021年06月26日:MK（手）- VB→VB.NET変換
        End Select

        'Set column title text
        spd.ActiveSheet.ColumnHeader.Cells(0, columnProperties.ColumnIndex).Value = columnProperties.Text & "　"

        'Set column width
        spd.ActiveSheet.Columns(columnProperties.ColumnIndex).Width = columnProperties.Width

        'Locked Column
        If columnProperties.CellReadOnly Then
            spd.ActiveSheet.Columns(columnProperties.ColumnIndex).CanFocus = False
            spd.ActiveSheet.Columns(columnProperties.ColumnIndex).Locked = True
        Else
            spd.ActiveSheet.Columns(columnProperties.ColumnIndex).Locked = False
        End If


        'Inactive click header
        spd.ActiveSheet.Columns(columnProperties.ColumnIndex).AllowAutoSort = False

        'set Visible column
        If columnProperties.Visible = False Then
            spd.ActiveSheet.Columns(columnProperties.ColumnIndex).Visible = columnProperties.Visible
            spd.ActiveSheet.Columns(columnProperties.ColumnIndex).Resizable = False
        End If

        'CellHorizontalAlignment
        spd.ActiveSheet.Columns(columnProperties.ColumnIndex).HorizontalAlignment = columnProperties.CellHorizontalAlignment
        spd.ActiveSheet.ColumnHeader.Columns(columnProperties.ColumnIndex).HorizontalAlignment = CellHorizontalAlignment.Center

    End Sub

    Public Sub SetColumHeaderProperties(ByRef spd As CustomizeFPSpread,
                                         ByVal col As Short,
                                         Optional headerBackgroundColor As Color = Nothing,
                                         Optional headerForeColor As Color = Nothing,
                                         Optional cellBackgroundColor As Color = Nothing,
                                         Optional cellForeColor As Color = Nothing)
        'Set Header color
        If headerBackgroundColor <> Nothing Then
            spd.ActiveSheet.ColumnHeader.Columns(col).BackColor = headerBackgroundColor
            spd.ActiveSheet.ColumnHeader.Columns(col).ForeColor = headerForeColor
            'spd.ActiveSheet.ColumnHeader.Columns(col).Locked = True
        End If

        'Set Detail color
        If cellBackgroundColor <> Nothing Then
            spd.ActiveSheet.Columns(col).BackColor = cellBackgroundColor
        End If
        If cellBackgroundColor <> Nothing Then
            spd.ActiveSheet.Columns(col).ForeColor = cellForeColor
        End If
    End Sub

    Private Sub SetHeaderFormat(ByRef spd As CustomizeFPSpread)

        For i As Integer = 0 To spd.ActiveSheet.RowHeader.Columns.Count - 1
            spd.ActiveSheet.RowHeader.Columns(i).Font = DefineStatic.FPSPREAD_HEADER_FONT
            spd.ActiveSheet.RowHeader.Columns(i).BackColor = System.Drawing.ColorTranslator.FromHtml("#7D7D7D")
            spd.ActiveSheet.RowHeader.Columns(i).ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")
        Next

        For i As Integer = 0 To spd.ActiveSheet.ColumnHeader.Rows.Count - 1
            spd.ActiveSheet.ColumnHeader.Rows(i).Font = DefineStatic.FPSPREAD_HEADER_FONT
            spd.ActiveSheet.ColumnHeader.Rows(i).BackColor = System.Drawing.ColorTranslator.FromHtml("#7D7D7D")
            spd.ActiveSheet.ColumnHeader.Rows(i).ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF")
            spd.ActiveSheet.ColumnHeader.Rows(i).CellPadding = New CellPadding(10, 10, 10, 10)
        Next

        'Conor Color
        spd.ActiveSheet.SheetCornerStyle.BackColor = ColorTranslator.FromHtml("#7D7D7D")

        'Background when don't have cell
        spd.ActiveSheet.GrayAreaBackColor = Common.DefineStatic.HeaderBlackColor

        ''DEFAULT SETING
        spd.ActiveSheet.SelectionBackColor = SystemColors.InactiveCaption
        spd.ActiveSheet.SelectionForeColor = SystemColors.InactiveCaption
    End Sub

    Public Sub SetRowHeaderWidth(ByRef spd As CustomizeFPSpread,
                                  width As Integer)
        spd.ActiveSheet.RowHeader.Columns(0).Width = width
    End Sub

    Public Sub SetHiddenScrollBar(ByRef spd As CustomizeFPSpread,
                                  Optional HScrollBarPolicy As ScrollBarPolicy = ScrollBarPolicy.AsNeeded,
                                  Optional VScrollBarPolicy As ScrollBarPolicy = ScrollBarPolicy.AsNeeded)
        spd.HorizontalScrollBarPolicy = HScrollBarPolicy
        spd.VerticalScrollBarPolicy = VScrollBarPolicy
    End Sub

    ''' <summary>
    ''' Active Enter Key to move next control
    ''' </summary>
    ''' <param name="fpSPread"></param>
    Public Sub SpreadMoveToNextCellWhenEnter(ByRef fpSPread As FarPoint.Win.Spread.FpSpread)
        Dim im As FarPoint.Win.Spread.InputMap

        ' Define the operation of pressing Enter key in cells not being edited as "Move to the next row". 
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextCellThenControl)

        ' Define the operation of pressing Enter key in cells being edited as "Move to the next row".
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextCellThenControl)
    End Sub

    ''' <summary>
    ''' Active Enter Key to move next control
    ''' </summary>
    ''' <param name="fpSPread"></param>
    Public Sub SpreadMoveToNexRowWhenEnter(ByRef fpSPread As FarPoint.Win.Spread.FpSpread)
        Dim im As FarPoint.Win.Spread.InputMap

        ' Define the operation of pressing Enter key in cells not being edited as "Move to the next row". 
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRow)

        ' Define the operation of pressing Enter key in cells being edited as "Move to the next row".
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRow)
    End Sub

    ''' <summary>
    ''' Active tab key to move to next control
    ''' </summary>
    ''' <param name="fpSPread"></param>
    Public Sub SpreadMoveToNextControlWithTab(ByRef fpSPread As FarPoint.Win.Spread.FpSpread)
        Dim im As FarPoint.Win.Spread.InputMap

        ' Define the operation of pressing Enter key in cells not being edited as "Move to the next row". 
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None)

        ' Define the operation of pressing Enter key in cells being edited as "Move to the next row".
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
    End Sub

    Public Sub SpreadArrowKeyToScroll(ByRef fpSPread As FarPoint.Win.Spread.FpSpread)
        Dim im As FarPoint.Win.Spread.InputMap

        'Right Key
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Right, Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToNextColumn)

        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Right, Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToNextColumn)

        'Left Key
        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Left, Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToPreviousColumn)

        im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Left, Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToPreviousColumn)
    End Sub


    ''' <summary>
    ''' Inactive key in Fpspread
    ''' </summary>
    ''' <param name="fpSPread"></param>
    Public Sub InactiveKey(ByRef fpSPread As FarPoint.Win.Spread.FpSpread, key As Keys, Optional selectRow As Boolean = True)
        Dim im As FarPoint.Win.Spread.InputMap

        If key = Keys.Right AndAlso selectRow = True Then
            ' Define the operation of pressing Enter key in cells not being edited as "nothing to do". 
            im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
            im.Put(New FarPoint.Win.Spread.Keystroke(key, Keys.None), FarPoint.Win.Spread.SpreadActions.SelectRow)

            ' Define the operation of pressing Enter key in cells being edited as "nothing to do". 
            im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
            im.Put(New FarPoint.Win.Spread.Keystroke(key, Keys.None), FarPoint.Win.Spread.SpreadActions.SelectRow)
        Else
            ' Define the operation of pressing Enter key in cells not being edited as "nothing to do". 
            im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
            im.Put(New FarPoint.Win.Spread.Keystroke(key, Keys.None), FarPoint.Win.Spread.SpreadActions.None)

            ' Define the operation of pressing Enter key in cells being edited as "nothing to do". 
            im = fpSPread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
            im.Put(New FarPoint.Win.Spread.Keystroke(key, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        End If
    End Sub

    Public Sub SetAlwaysShowValue(ByRef fpSPread As CustomizeFPSpread, iCol As Int32, value As String)
        Dim numberCellType As FarPoint.Win.Spread.CellType.NumberCellType = CType(fpSPread.ActiveSheet.Columns(iCol).CellType, FarPoint.Win.Spread.CellType.NumberCellType)
        If numberCellType IsNot Nothing Then

            numberCellType.NullDisplay = value
        End If
    End Sub

End Module
