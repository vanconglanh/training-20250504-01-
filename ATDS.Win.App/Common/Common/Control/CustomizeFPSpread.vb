Imports System.ComponentModel
Imports FarPoint.Win.Spread
Imports System.Runtime.CompilerServices
Imports System.Drawing
Imports FarPoint.Win.Spread.CellType
Imports System.Windows.Forms

Public Class CustomizeFPSpread
    Inherits FpSpread

    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    Public Class DottedIndicator
        Implements FarPoint.Win.Spread.IFocusIndicatorRenderer
        Public Sub Paint(ByVal g As System.Drawing.Graphics,
                         ByVal x As Integer, ByVal y As Integer,
                         ByVal width As Integer, ByVal height As Integer,
                         ByVal left As Boolean, ByVal top As Boolean,
                         ByVal right As Boolean, ByVal bottom As Boolean) Implements FarPoint.Win.Spread.IFocusIndicatorRenderer.Paint

            Dim dottedPen = New Pen(Color.Black, width:=1) With {
                .DashPattern = {1.0F, 1.0F}
            }

            g.DrawLine(dottedPen, New PointF(x, y), New PointF(x + width, y))
            g.DrawLine(dottedPen, New PointF(x + width, y), New PointF(x + width, y + height))
            g.DrawLine(dottedPen, New PointF(x + width, y + height), New PointF(x, y + height))
            g.DrawLine(dottedPen, New PointF(x, y + height), New PointF(x, y))
        End Sub
    End Class
    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    Public Class BorderColorIndicator
        Implements FarPoint.Win.Spread.IFocusIndicatorRenderer
        Dim drawColor As Color = Color.Black
        Dim drawBorderWidth As Int16 = 2

        Public Sub New(customColor As Color, Optional customBorderWidth As Int16 = 2)
            drawColor = customColor
            drawBorderWidth = customBorderWidth
        End Sub

        Public Sub Paint(ByVal g As System.Drawing.Graphics,
                         ByVal x As Integer, ByVal y As Integer,
                         ByVal width As Integer, ByVal height As Integer,
                         ByVal left As Boolean, ByVal top As Boolean,
                         ByVal right As Boolean, ByVal bottom As Boolean) Implements FarPoint.Win.Spread.IFocusIndicatorRenderer.Paint

            Dim dottedPen = New Pen(drawColor, width:=drawBorderWidth)
            'Top Left→Right
            g.DrawLine(dottedPen, New PointF(x - 1, y - 1), New PointF(x - 1 + width - 1, y - 1))
            'Right Top→Bottom
            g.DrawLine(dottedPen, New PointF(x + width - 1, y - 1), New PointF(x + width - 1, y - 1 + height))
            'Bottom Right→Left
            g.DrawLine(dottedPen, New PointF(x + width - 1, y - 1 + height), New PointF(x - 1, y - 1 + height))
            'Left Bottom→Top
            g.DrawLine(dottedPen, New PointF(x - 1, y - 1 + height), New PointF(x - 1, y - 1))
        End Sub
    End Class
    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換

    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    Public Class BorderAroundColorIndicator
        Implements FarPoint.Win.Spread.IFocusIndicatorRenderer
        Dim drawColor As Color = Color.Black
        Dim borderColor As Color = Color.Black
        Dim drawBorderWidth As Int16 = 2

        Public Sub New(customColor As Color, gridBorderColor As Color, Optional customBorderWidth As Int16 = 2)
            drawColor = customColor
            borderColor = gridBorderColor
            drawBorderWidth = customBorderWidth
        End Sub

        Public Sub Paint(ByVal g As System.Drawing.Graphics,
                         ByVal x As Integer, ByVal y As Integer,
                         ByVal width As Integer, ByVal height As Integer,
                         ByVal left As Boolean, ByVal top As Boolean,
                         ByVal right As Boolean, ByVal bottom As Boolean) Implements FarPoint.Win.Spread.IFocusIndicatorRenderer.Paint

            Dim dottedPen = New Pen(borderColor, width:=drawBorderWidth)
            Dim borderPen = New Pen(drawColor, width:=1)



            'Top Left→Right
            g.DrawLine(dottedPen, New PointF(x + 1, y + 1), New PointF(x - 1 + width - 2, y + 1))
            'Right Top→Bottom
            g.DrawLine(dottedPen, New PointF(x - 1 + width - 2, y + 1), New PointF(x - 1 + width - 2, y + height - 2))
            'Bottom Right→Left
            g.DrawLine(dottedPen, New PointF(x - 1 + width - 2, y + height - 2), New PointF(x + 1, y + height - 2))
            'Left Bottom→Top
            g.DrawLine(dottedPen, New PointF(x + 1, y + height - 2), New PointF(x + 1, y + 1))

            'Top Left→Right
            g.DrawLine(dottedPen, New PointF(x - 1, y - 2), New PointF(x + width, y - 2))
            'Right Top→Bottom
            g.DrawLine(dottedPen, New PointF(x + width, y - 1), New PointF(x + width, y + height))
            'Bottom Right→Left
            g.DrawLine(dottedPen, New PointF(x + width, y + height), New PointF(x - 1, y + height))
            'Left Bottom→Top
            g.DrawLine(dottedPen, New PointF(x - 2, y + height), New PointF(x - 2, y - 2))

            g.DrawLine(borderPen, New PointF(x - 1, y - 1), New PointF(x - 1 + width, y - 1))
            g.DrawLine(borderPen, New PointF(x - 1 + width, y - 1), New PointF(x - 1 + width, y - 1 + height))
            g.DrawLine(borderPen, New PointF(x - 1 + width, y - 1 + height), New PointF(x - 1, y - 1 + height))
            g.DrawLine(borderPen, New PointF(x - 1, y - 1 + height), New PointF(x - 1, y - 1))

        End Sub
    End Class
    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換

    Dim isShowRowHeader As Boolean = False
    Dim isShowColumnHeader As Boolean = True
    Dim iRowHeaderSize As Integer = 0
    Dim headerAutoText As HeaderAutoText = HeaderAutoText.Blank
    Dim _Row As Int32 = -1
    Dim _Col As Int32 = -1
    Dim _Row2 As Int32 = -1
    Dim _Col2 As Int32 = -1
    Dim _ProcessTab As Boolean = True
    Dim _TypeComboBoxIndex As Integer
    Dim _bSelModeSelected As Boolean = True
    Dim _bCanTouch As Boolean = True
    Dim _blockMode As Boolean = False

    Public NothingColumnColor As Color = System.Drawing.ColorTranslator.FromHtml("#C0FFFF")
    Public NewColumnColor As Color = System.Drawing.ColorTranslator.FromHtml("#FFFF80")
    Public NotInputColor As Color = System.Drawing.ColorTranslator.FromHtml("#F0F0F0")
    Public MinusColor As Color = System.Drawing.ColorTranslator.FromHtml("#F0F0F0")

    Public Sub New(ByVal LegacyBehaviors As Short, ByRef stream As System.IO.MemoryStream)
        MyBase.New(LegacyBehaviors, stream)
        ' フィールドなどを初期化します。
        initializeCollections()
    End Sub
    Public Sub New()

        ' フィールドなどを初期化します。
        initializeCollections()
    End Sub

    ' フィールドなどを初期化します。
    Private Sub initializeCollections()
        '++修正開始　2021年06月26日:MK（手）- VB→VB.NET変換
        'InitGrid()
        SetCursor(CursorType.Normal, Cursors.Arrow)
        SetCursor(CursorType.LockedCell, Cursors.Arrow)
        '--修正開始　2021年06月26日:MK（手）- VB→VB.NET変換
    End Sub

    Public Shadows Property ActiveSheet As SheetView
        Get
            If Me.Sheets.Count = 0 Then
                Return New SheetView
            Else
                Return MyBase.ActiveSheet
            End If
        End Get
        Set(ByVal value As SheetView)
            MyBase.ActiveSheet = value
        End Set
    End Property


#Region "MSFlexGrid"
#Region "追加プロパティ"
    ''' <summary>
    ''' Gets or sets whether the grid should paint its contents.
    ''' </summary>
    ''' <returns></returns>
    Public Property Redraw As Boolean
        Get
            Return True 'Not have same properties
        End Get
        Set(ByVal value As Boolean)
            If value Then
                MyBase.ResumeLayout()
            Else
                MyBase.SuspendLayout()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Selected Column Index
    ''' </summary>
    ''' <returns></returns>
    Public Property Col As Short
        Get
            If Me.ActiveSheet Is Nothing Then
                Return -1
            Else
                Return Me.ActiveSheet.ActiveColumnIndex
            End If

        End Get
        Set(ByVal value As Short)
            _Col = value
            Me.ActiveSheet.ActiveColumnIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Selected Number of column
    ''' </summary>
    ''' <returns></returns>
    Public Property Cols As Short
        Get
            Return Me.ActiveSheet.ColumnCount
        End Get
        Set(ByVal value As Short)
            Me.ActiveSheet.ColumnCount = value
        End Set
    End Property

    ''' <summary>
    ''' Selected Row Index
    ''' </summary>
    ''' <returns></returns>
    Public Property RowSel As Short
        Get
            Return Me.ActiveSheet.ActiveRowIndex
        End Get
        Set(ByVal value As Short)
            _Col = value
            Me.ActiveSheet.ActiveRowIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Selected Column Index
    ''' </summary>
    ''' <returns></returns>
    Public Property ColSel As Short
        Get
            Return Me.ActiveSheet.ActiveColumnIndex
        End Get
        Set(ByVal value As Short)
            _Col = value
            Me.ActiveSheet.ActiveColumnIndex = value
        End Set
    End Property


    ''' <summary>
    ''' Selected Row Index
    ''' </summary>
    ''' <returns></returns>
    Public Property Row As Integer
        Get
            Return Me.ActiveSheet.ActiveRowIndex
        End Get
        Set(ByVal value As Integer)
            _Row = value
            Me.ActiveSheet.ActiveRowIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Num row of spread
    ''' </summary>
    ''' <returns></returns>
    Public Property Rows As Integer
        Get
            Return Me.ActiveSheet.RowCount
        End Get
        Set(ByVal value As Integer)
            Me.ActiveSheet.RowCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the number of frozen rows of the sheet.
    ''' </summary>
    ''' <returns></returns>
    Public Property FixedRows As Short
        Get
            Return Me.ActiveSheet.FrozenRowCount
        End Get
        Set(ByVal value As Short)
            Me.ActiveSheet.FrozenRowCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the number of frozen column of the sheet.
    ''' </summary>
    ''' <returns></returns>
    Public Property FixedCols As Short

        Get
            Return Me.ActiveSheet.FrozenColumnCount
        End Get
        Set(ByVal value As Short)
            Me.ActiveSheet.FrozenColumnCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the number of frozen column of the sheet.
    ''' </summary>
    ''' <returns></returns>
    Public Property SelectionMode As Short

        Get
            Select Case Me.ActiveSheet.SelectionUnit
                Case Model.SelectionUnit.Cell
                    Return MSFlexGridLib_SelectionModeSettings_flexSelectionByCell
                Case Model.SelectionUnit.Row
                    Return MSFlexGridLib_SelectionModeSettings_flexSelectionByRow
                Case Model.SelectionUnit.Column
                    Return MSFlexGridLib_SelectionModeSettings_flexSelectionByColumn
                Case Else
                    ' Not have value
                    Return MSFlexGridLib_SelectionModeSettings_flexSelectionFree
            End Select
        End Get

        Set(ByVal value As Short)
            Select Case value
                Case MSFlexGridLib_SelectionModeSettings_flexSelectionByCell
                    Me.ActiveSheet.SelectionUnit = Model.SelectionUnit.Cell
                Case MSFlexGridLib_SelectionModeSettings_flexSelectionByRow
                    Me.ActiveSheet.SelectionUnit = Model.SelectionUnit.Row
                Case MSFlexGridLib_SelectionModeSettings_flexSelectionByColumn
                    Me.ActiveSheet.SelectionUnit = Model.SelectionUnit.Column
                Case MSFlexGridLib_SelectionModeSettings_flexSelectionFree
                    Me.ActiveSheet.SelectionUnit = Model.SelectionUnit.Cell
            End Select
        End Set

    End Property
#End Region

#Region "追加関数"

    ''' <summary>
    ''' Set width of column
    ''' </summary>
    ''' <param name="col">column id start at 0</param>
    ''' <param name="width">width of column</param>
    Public Sub set_ColWidth(ByVal col As Short, ByVal width As Integer)
        Me.ActiveSheet.ColumnHeader.Columns(col).Width = width
    End Sub


    ''' <summary>
    ''' Set hidden of column
    ''' </summary>
    Public Sub SetColunmHidden(ByVal col As Short)
        Me.ActiveSheet.SetColumnVisible(col, False)
    End Sub

    ''' <summary>
    ''' Set hidden of column
    ''' </summary>
    Public Sub SetRowHidden(ByVal row As Short)
        Me.ActiveSheet.SetRowVisible(row, False)
    End Sub

    ''' <summary>
    ''' Set Column Aligment
    ''' </summary>
    ''' <returns></returns>
    Public Property CellAlignment As Short
        Get
            Return Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment
        End Get

        Set(ByVal value As Short)
            Select Case value
                Case MSFlexGridLib_AlignmentSettings_flexAlignCenterCenter
                    Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                    Me.ActiveSheet.ColumnHeader.Columns(Col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Case MSFlexGridLib_AlignmentSettings_flexAlignLeftCenter
                    Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                    Me.ActiveSheet.ColumnHeader.Columns(Col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Case MSFlexGridLib_AlignmentSettings_flexAlignRightCenter
                    Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                    Me.ActiveSheet.ColumnHeader.Columns(Col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            End Select
        End Set
    End Property

    ''' <summary>
    ''' Set back color of active cell
    ''' </summary>
    ''' <returns></returns>
    Public Property CellBackColor As System.Drawing.Color
        Get
            Return Me.ActiveSheet.ActiveCell.BackColor
        End Get

        Set(ByVal value As System.Drawing.Color)
            If Me.ActiveSheet.ActiveCell IsNot Nothing Then
                Me.ActiveSheet.ActiveCell.BackColor = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Set fore color of active cell
    ''' </summary>
    ''' <returns></returns>
    'Public Property CellForeColor As System.Drawing.Color
    '    Get
    '        Return Me.ActiveSheet.ActiveCell.ForeColor
    '    End Get

    '    Set(ByVal value As System.Drawing.Color)
    '        Me.ActiveSheet.ActiveCell.ForeColor = value
    '    End Set
    'End Property

    '''' <summary>
    '''' Set font size of active cell
    '''' </summary>
    '''' <returns></returns>
    'Public Property CellFontSize As Single
    '    Get
    '        Return Me.ActiveSheet.ActiveCell.Font.Size
    '    End Get

    '    Set(ByVal value As Single)
    '        Me.ActiveSheet.ActiveCell.Font = New Font(Me.ActiveSheet.ActiveCell.Font.Size, value)
    '    End Set
    'End Property

    ''' <summary>
    ''' Set font bold of active cell
    ''' </summary>
    ''' <returns></returns>
    'Public Property CellFontBold As Boolean
    '    Get
    '        Return Me.ActiveSheet.ActiveCell.Font.Bold
    '    End Get

    '    Set(ByVal value As Boolean)
    '        Me.ActiveSheet.ActiveCell.Font = New Font(Me.ActiveSheet.ActiveCell.Font.Bold, value)
    '    End Set
    'End Property



    ''' <summary>
    ''' Set value for cell by RowIndex and Column Index
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    Public Sub set_TextMatrix(ByVal row As Integer, ByVal col As Short, ByVal value As String, Optional isHeaderRow As Boolean = False)
        If row = -1 OrElse isHeaderRow Then
            If isHeaderRow Then
                Me.ActiveSheet.ColumnHeader.Cells(row, col).Value = value
            Else
                Me.ActiveSheet.ColumnHeader.Cells(row + 1, col).Value = value

            End If
        Else
            Me.ActiveSheet.Cells(row, col).Value = value

        End If
    End Sub


    ''' <summary>
    ''' Get value of cell by RowIndex and Column Index
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="col"></param>
    ''' <returns></returns>
    Public Function get_TextMatrix(ByVal row As Integer, ByVal col As Short, Optional isHeaderRow As Boolean = False) As String
        Try
            If row = -1 OrElse isHeaderRow Then
                If isHeaderRow Then
                    Return Me.ActiveSheet.ColumnHeader.Cells(row, col).Value
                End If
            Else
                Return Me.ActiveSheet.Cells(row, col).Value
            End If
        Catch ex As Exception
            Return ""
        End Try
        'Return Me.ActiveSheet.Cells(row, col + 1).Value
    End Function

    ''' <summary>
    ''' Set Height of row by RowIndex
    ''' </summary>
    ''' <param name="rowIdx">Row Index</param>
    ''' <param name="height"></param>
    Public Sub set_RowHeight(ByVal rowIdx As Integer, ByVal height As Integer)
        Me.ActiveSheet.Rows(rowIdx).Height = height
    End Sub
    ''' <summary>
    ''' Add new row
    ''' </summary>
    Public Sub AddItem(ByVal id As String, ByVal NumberRecord As Integer)
        'id is not use
        Me.ActiveSheet.Rows.Add(Me.ActiveSheet.Rows.Count, 1)
    End Sub

    ''' <summary>
    ''' Remove row index
    ''' </summary>
    Public Sub RemoveItem(ByVal row As Integer)
        'id is not use
        Me.ActiveSheet.Rows.Remove(row, 1)
    End Sub


    ''' <summary>
    ''' Set Alignment for control
    ''' </summary>
    ''' <param name="col"></param>
    ''' <param name="mode"></param>
    Public Sub set_ColAlignment(ByVal col As Short, ByVal mode As Short)
        Select Case mode
            Case MSFlexGridLib_AlignmentSettings_flexAlignCenterCenter
                Me.ActiveSheet.ColumnHeader.Columns(col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Me.ActiveSheet.ColumnHeader.Columns(col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                '++修正開始　2021年07月09日:MK（手）- VB→VB.NET変換
                Me.ActiveSheet.Columns(col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Me.ActiveSheet.Columns(col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                '--修正開始　2021年07月09日:MK（手）- VB→VB.NET変換
            Case MSFlexGridLib_AlignmentSettings_flexAlignLeftCenter
                Me.ActiveSheet.ColumnHeader.Columns(col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Me.ActiveSheet.ColumnHeader.Columns(col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                '++修正開始　2021年07月09日:MK（手）- VB→VB.NET変換
                Me.ActiveSheet.Columns(col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Me.ActiveSheet.Columns(col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                '--修正開始　2021年07月09日:MK（手）- VB→VB.NET変換
            Case MSFlexGridLib_AlignmentSettings_flexAlignRightCenter
                Me.ActiveSheet.ColumnHeader.Columns(col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Me.ActiveSheet.ColumnHeader.Columns(col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                '++修正開始　2021年07月09日:MK（手）- VB→VB.NET変換
                Me.ActiveSheet.Columns(col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Me.ActiveSheet.Columns(col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                '--修正開始　2021年07月09日:MK（手）- VB→VB.NET変換
        End Select
    End Sub

    ''' <summary>
    ''' FPSpread clear data, Row, Col
    ''' </summary>
    Public Sub Clear()
        Me.Row = 0
        Me.Col = 0
    End Sub

    ''' <summary>
    ''' FPSpread Refresh
    ''' </summary>
    Public Sub CtlRefresh()
        Me.Refresh()
    End Sub

    ''' <summary>
    ''' Returns the width of the widest text string in the specified column.
    ''' </summary>
    Public Function get_MaxTextColWidth(rowIndex As Integer) As Integer
        Dim maxLengthCol As Integer = -1
        Dim maxLength As Integer = 0
        For iCol As Integer = 0 To Col
            If Me.ActiveSheet.Cells(rowIndex, iCol).Text.Length > maxLength Then
                maxLengthCol = iCol
            End If
        Next
        Return maxLengthCol
    End Function

#End Region

#End Region

#Region "FPSpread"
#Region "追加プロパティ"
    ''' <summary>
    ''' Num row of spread
    ''' </summary>
    ''' <returns></returns>
    Public Property MaxRows As Integer
        Get
            Return Me.ActiveSheet.RowCount
        End Get
        Set(ByVal value As Integer)
            Me.ActiveSheet.RowCount = value
        End Set
    End Property

    ''' <summary>
    ''' Sets or returns the row to position as the topmost row in the displayed sheet. This property is available at run time only.
    ''' http://help.grapecity.com/spread/SpreadNet9/WF/FarPoint.Win.Spread~FarPoint.Win.Spread.FpSpread~GetViewportTopRow(Int32).html
    ''' </summary>
    ''' <returns></returns>
    ''' 
    Public Property TopRow As Integer
        Get
            '++修正開始　2021年07月31日:MK（手）- VB→VB.NET変換
            Return Me.GetViewportTopRow(0)
            '--修正開始　2021年07月31日:MK（手）- VB→VB.NET変換
        End Get
        Set(ByVal value As Integer)
            'Me.ActiveSheet.ActiveRowIndex = value
            Me.ShowRow(0, value, VerticalPosition.Top)
        End Set
    End Property

    ''' <summary>
    ''' Returns the row number of the bottom row of a selected block of cells. This property is available at run time only.
    ''' </summary>
    ''' <returns></returns>
    Public Property SelBlockRow2 As Integer
        Get
            Return Me.ActiveSheet.RowCount - Me.Row
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    ''' <summary>
    ''' properties hidden of active column 
    ''' </summary>
    ''' <returns></returns>
    Public Property ColHidden As Boolean
        Get
            Return Me.ActiveSheet.ActiveColumn.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.ActiveSheet.ActiveColumn.Visible = value
            Me.ActiveSheet.ActiveColumn.Resizable = value
        End Set
    End Property

    ''' <summary>
    ''' Selected Row Index
    ''' </summary>
    ''' <returns></returns>
    Public Property ActiveRow As Short
        Get
            Return Me.ActiveSheet.ActiveRowIndex
        End Get
        Set(ByVal value As Short)
            _Row = value
            Me.ActiveSheet.ActiveRowIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Selected Column Index
    ''' </summary>
    ''' <returns></returns>
    Public Property ActiveCol As Short
        Get
            Return Me.ActiveSheet.ActiveColumnIndex
        End Get
        Set(ByVal value As Short)
            _Col = value
            Me.ActiveSheet.ActiveColumnIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether cells on this sheet that are marked as locked are not editable.
    ''' </summary>
    ''' <returns></returns>
    Public Property Protect As Boolean
        Get
            Return Me.ActiveSheet.Protect
        End Get
        Set(ByVal value As Boolean)
            Me.ActiveSheet.Protect = value
        End Set
    End Property

    ''' <summary>
    ''' Locked property of active cell
    ''' </summary>
    ''' <returns></returns>
    Public Property Lock As Boolean
        'Get
        '    'If not set value of range
        '    If _Col2 = -1 Or _Row2 = -1 Then
        '        Return Me.ActiveSheet.Cells(Row, Col).Locked
        '    Else
        '        Return Me.ActiveSheet.Cells(Row, Col, _Row2, _Col2).Locked
        '    End If
        'End Get
        'Set(ByVal value As Boolean)
        '    If _Col2 = -1 Or _Row2 = -1 Then
        '        Me.ActiveSheet.Cells(Row, Col).Locked = value
        '    Else
        '        Me.ActiveSheet.Cells(Row, Col, _Row2, _Col2).Locked = value
        '    End If
        'End Set

        Get
            'If not set value of range
            Return Me.ActiveSheet.Columns(Col).Locked
        End Get
        '++修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
        Set(ByVal value As Boolean)
            If _Col2 = -1 Then
                If _Row2 = -1 Then
                    '++修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
                    Me.ActiveSheet.Cells(Row, Col).Locked = value
                    If value = True Then
                        Me.ActiveSheet.Cells(Row, Col).BackColor = NotInputColor
                        Me.ActiveSheet.Cells(Row, Col).LockBackColor = NotInputColor
                        'Else
                        '    Me.ActiveSheet.Cells(Row, Col).BackColor = NothingColumnColor
                        '    Me.ActiveSheet.Cells(Row, Col).LockBackColor = NothingColumnColor
                    End If
                    '--修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
                Else
                    '++修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
                    'Me.ActiveSheet.Columns(Col).Locked = value
                    '--修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
                    For iRow As Integer = Row To Row2
                        '++修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
                        Me.ActiveSheet.Cells(iRow, Col).Locked = value
                        '--修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
                        If value = True Then

                            Me.ActiveSheet.Cells(iRow, Col).BackColor = NotInputColor
                            Me.ActiveSheet.Cells(iRow, Col).LockBackColor = NotInputColor
                            'Else
                            '    Me.ActiveSheet.Cells(iRow, Col).BackColor = NothingColumnColor
                            '    Me.ActiveSheet.Cells(iRow, Col).LockBackColor = NothingColumnColor
                        End If
                    Next
                End If
            Else
                For iCol As Integer = Col To Col2
                    For iRow As Integer = Row To Row2
                        Me.ActiveSheet.Cells(iRow, iCol).Locked = value
                        If value = True Then
                            Me.ActiveSheet.Cells(iRow, iCol).BackColor = NotInputColor
                            Me.ActiveSheet.Cells(iRow, iCol).LockBackColor = NotInputColor
                            'Else
                            '    Me.ActiveSheet.Cells(iRow, iCol).BackColor = NothingColumnColor
                            '    Me.ActiveSheet.Cells(iRow, iCol).LockBackColor = NothingColumnColor
                        End If
                    Next
                Next
            End If
        End Set

        '--修正開始　2021年07月24日:MK（手）- VB→VB.NET変換
    End Property

    ''' <summary>
    ''' Value of active cell
    ''' </summary>
    ''' <returns></returns>
    Public Property Value As String
        Get

            '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
            'Return Me.ActiveSheet.Cells(Row, Col).Value
            If Me.ActiveSheet.Cells(Row, Col).Value Is Nothing Then
                Return ""
            Else
                Return Me.ActiveSheet.Cells(Row, Col).Value
            End If
            '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
        End Get
        Set(ByVal value As String)
            Me.ActiveSheet.Cells(Row, Col).Value = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the number of frozen column of the sheet.
    ''' </summary>
    ''' <returns></returns>
    Public Property OperationMode As Short

        Get
            Return Me.ActiveSheet.OperationMode
        End Get

        Set(ByVal value As Short)
            Me.ActiveSheet.OperationMode = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the HorizontalAlignment of column or all column
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeHAlign As Short
        Get
            Return Me.ActiveSheet.ColumnHeader.Columns(Me.Col).HorizontalAlignment
        End Get

        Set(ByVal value As Short)
            '//全部を右寄せにする (If Row = -1 and Col = -1)
            '++修正開始　2021年07月04日:MK（手）- VB→VB.NET変換
            'If Me.Row = -1 Then
            '    If Me.Col = -1 Then
            If _Row = -1 Then
                If _Col = -1 Then
                    '--修正開始　2021年07月04日:MK（手）- VB→VB.NET変換
                    For Each column In Me.ActiveSheet.Columns
                        column.HorizontalAlignment = value
                    Next
                Else '別列を設定
                    Me.ActiveSheet.ColumnHeader.Columns(Me.Col).HorizontalAlignment = value
                End If
            Else 'Set Align for cell 

            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the HorizontalAlignment of column or all column
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeVAlign As Short
        Get
            Return Me.ActiveSheet.RowHeader.Rows(Me.Row).VerticalAlignment
        End Get

        Set(ByVal value As Short)
            '//全部を右寄せにする (If Row = -1 and Col = -1)
            '++修正開始　2021年07月04日:MK（手）- VB→VB.NET変換
            'If Me.Row = -1 Then
            '    If Me.Col = -1 Then
            If _Col = -1 Then
                If _Row = -1 Then
                    '--修正開始　2021年07月04日:MK（手）- VB→VB.NET変換
                    For Each iRow As FarPoint.Win.Spread.Row In Me.ActiveSheet.Rows
                        iRow.VerticalAlignment = value
                    Next
                Else '別列を設定
                    Me.ActiveSheet.RowHeader.Rows(Me.Row).VerticalAlignment = value
                End If
            Else 'Set Align for cell 

            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets parameter name Row2 
    ''' -----------------------------------------
    ''' Row2: setvalue and next property will use
    ''' Sample: .Col = enmColKuu.金額
    '''         .Col2 = enmColKuu.金額
    '''         .Row = plngRow
    '''         .Row2 = plngRow
    '''         .Lock = True ← This properties will use Col2 and Row 2
    ''' </summary>
    ''' <returns></returns>
    Public Property Row2 As Int32
        Get
            Return _Row2
        End Get

        Set(ByVal value As Int32)
            _Row2 = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets parameter name Col2 
    ''' -----------------------------------------
    ''' Row2: setvalue and next property will use
    ''' Sample: .Col = enmColKuu.金額
    '''         .Col2 = enmColKuu.金額
    '''         .Row = plngRow
    '''         .Row2 = plngRow
    '''         .Lock = True ← This properties will use Col2 and Row 2
    ''' </summary>
    ''' <returns></returns>
    Public Property Col2 As Int32
        Get
            Return _Col2
        End Get

        Set(ByVal value As Int32)
            _Col2 = value
        End Set
    End Property

    ''' <summary>
    ''' [TODO]Gets or sets BlockMode
    ''' http://help.grapecity.com/spread/SpreadNet9/WF/FarPoint.Win.Spread~FarPoint.Win.Spread.SelectionBlockOptions.html
    ''' </summary>
    ''' <returns></returns>
    Public Property BlockMode As Short
        Get
            Return _blockMode
        End Get

        Set(ByVal value As Short)
            If value = 0 Then
                _blockMode = False
            Else
                _blockMode = True
            End If
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets Row2
    ''' </summary>
    ''' <returns></returns>
    Public Property MaxCols As Int32
        Get
            Return Me.ActiveSheet.Columns.Count
        End Get

        Set(ByVal value As Int32)
            Me.ActiveSheet.Columns.Count = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets LockBackColor(ロックセルの背景色)
    ''' </summary>
    ''' <returns></returns>
    Public Property LockBackColor As Color
        Get
            Return Me.ActiveSheet.LockBackColor
        End Get

        Set(ByVal value As Color)
            Me.ActiveSheet.LockBackColor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets TypeComboBoxList(Set datatype and data of control)
    ''' ActiveRow = -1: Set for all Cell of column
    ''' ActiveRow >= 0: Set for active cell
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeComboBoxList As String
        Get
            'Nothing event
            Return String.Empty
        End Get

        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) = False Then
                'Set for all column
                'Dim comboBoxCellType = New FarPoint.Win.Spread.CellType.ComboBoxCellType()
                'Dim itemList = Split(value, vbTab)
                'comboBoxCellType.Items = itemList
                'Me.ActiveSheet.Columns(Me.Col).CellType = comboBoxCellType
                'Me.ActiveSheet.Cells(0, Me.Col).CellType = comboBoxCellType

                Dim combobox As New ComboBoxCellType
                Dim itemList = Split(value, vbTab)
                combobox.Items = itemList
                combobox.DropDownOptions = FarPoint.Win.DropDownOptions.ButtonAndText
                combobox.AutoCompleteMode = AutoCompleteMode.None
                combobox.Editable = True
                Me.ActiveSheet.Columns(Me.Col).CellType = combobox
                Me.ActiveSheet.Cells(0, Me.Col).CellType = combobox
            End If
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets Selected index
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeComboBoxCurSel As Integer
        Get
            Try

                If String.IsNullOrEmpty(Value) = False Then
                    Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(Row, Col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
                    For index As Integer = 0 To comboBoxCellType.Items.Count - 1
                        If comboBoxCellType.Items(index) = Me.ActiveSheet.ActiveCell.Value Then
                            Return index
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try
            Return -1
        End Get

        Set(ByVal value As Integer)
            Try

                If String.IsNullOrEmpty(value) = False Then
                    Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(Row, Col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
                    If comboBoxCellType IsNot Nothing Then
                        Me.ActiveSheet.ActiveCell.Value = comboBoxCellType.Items(value)
                    End If
                End If
            Catch ex As Exception

            End Try
        End Set
    End Property

    ''' <summary>
    '''Gets or sets Count of dropdownList Cell     
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property TypeComboBoxCount As Integer
        Get
            '++修正開始　2021年06月26日:MK（手）- VB→VB.NET変換
            'Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = Me.ActiveSheet.ActiveCell.CellType
            Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(0, Col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
            '--修正開始　2021年06月26日:MK（手）- VB→VB.NET変換
            Return comboBoxCellType.Items.Count
        End Get
    End Property

    ''' <summary>
    ''' Set index for get Combobox
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeComboBoxIndex As Integer
        Get
            Return _TypeComboBoxIndex
        End Get
        Set(value As Integer)
            _TypeComboBoxIndex = value
        End Set
    End Property
    ''' <summary>
    ''' Set, Get Item Count of dropdownList Cell     
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeComboBoxString As Integer
        Get
            'Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(Row, Col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
            'For index As Integer = 0 To comboBoxCellType.Items.Count - 1
            '    If comboBoxCellType.Items(index).Contains(Value & " : ") Then
            'Me.ActiveSheet.ActiveCell.Value = comboBoxCellType.Items(index)
            '        Exit Sub
            '    End If
            'Next

            '++修正開始　2021年06月27日:MK（手）- VB→VB.NET変換
            'Dim value As String = Me.ActiveSheet.ActiveCell.Value
            'If value Is Nothing Then  Return 0

            'Return IIf(String.IsNullOrEmpty(value), 0, value.Substring(0, value.IndexOf(" : ")))

            'Dim value As String = Me.ActiveSheet.ActiveCell.Value
            'If value Is Nothing Then Return 0
            '--修正開始　2021年06月27日:MK（手）- VB→VB.NET変換

            Try

                Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(0, Col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
                If comboBoxCellType IsNot Nothing Then
                    Dim value As String = comboBoxCellType.Items(_TypeComboBoxIndex)
                    If value Is Nothing Then Return 0
                    Return IIf(String.IsNullOrEmpty(value), 0, value.Substring(0, value.IndexOf(" : ")))
                End If
            Catch ex As Exception

            End Try

            Return -1
        End Get
        Set(ByVal value As Integer)

            Try
                'Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = Me.ActiveSheet.ActiveCell.CellType
                'comboBoxCellType.EditorValue = value
                Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(0, Col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
                If comboBoxCellType IsNot Nothing Then
                    'For index As Integer = 0 To comboBoxCellType.Items.Count - 1
                    '    If comboBoxCellType.Items(index).Contains(value & " : ") Then
                    '        Me.ActiveSheet.ActiveCell.Value = comboBoxCellType.Items(index)
                    '        Exit Property
                    '    End If
                    'Next
                    '++修正開始　2022年05月14日:MK（手）- VB→VB.NET変換
                    'Me.ActiveSheet.Cells(Me.Row, Me.Col).Text = comboBoxCellType.Items(value)
                    Me.ActiveSheet.SetText(Me.Row, Me.Col, comboBoxCellType.Items(value))
                    '--修正開始　2022年05月14日:MK（手）- VB→VB.NET変換
                End If
            Catch ex As Exception

            End Try
        End Set
    End Property


    ''' <summary>
    ''' Sets or returns formatted data into or from a column, a row, or a block of cells. This property is available at run time only.
    ''' http://helpcentral.componentone.com/NetHelp/Spread8/WebSiteHelp/prop2.html
    ''' </summary>
    ''' <returns></returns>
    Public Property Clip As String
        Get
            'Nothing event
            Dim strValue As String = ""
            For iCol As Int16 = Me.Col To Me.Col2
                strValue = strValue & Me.ActiveSheet.Cells(Me.Row, iCol).Value & vbTab
            Next

            Return strValue
        End Get

        Set(ByVal value As String)
            Try
                Dim strValueList = value.Split(vbTab)
                Dim index As Integer = 0
                For iCol As Int16 = Me.Col To Me.Col2
                    Me.ActiveSheet.Cells(Me.Row, iCol).Value = strValueList(index)
                    index += 1
                Next
            Catch ex As Exception

            End Try
        End Set
    End Property

    Public Sub SetClip(row As Int32, row2 As Int32, col As Int32, col2 As Int32, value As String)
        Try
            Dim strValueList = value.Split(vbTab)
            Dim index As Integer = 0
            For iCol As Int16 = col To col2
                Me.ActiveSheet.Cells(row, iCol).Value = strValueList(index)
                index += 1
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Sets or returns type of cell
    ''' </summary>
    ''' <returns></returns>
    Public Property CellType As ICellType
        Get
            Return Me.ActiveSheet.ActiveCell.CellType
        End Get

        Set(ByVal value As ICellType)
            Me.ActiveSheet.ActiveCell.CellType = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether the active cell in the component is in edit mode.
    ''' </summary>
    ''' <returns></returns>
    Public Property CtlEditMode As Boolean
        Get
            Return Me.EditMode
        End Get

        Set(ByVal value As Boolean)
            Me.EditMode = value
        End Set
    End Property

    ''' <summary>]
    ''' if have selected row
    ''' </summary>
    ''' <returns></returns>
    Public Property SelModeSelected As Boolean
        Get
            Return _bSelModeSelected
        End Get

        Set(ByVal value As Boolean)
            _bSelModeSelected = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets Border color
    ''' http://help.grapecity.com/spread/SpreadNet10/WF/spwin-cellborder.html
    ''' </summary>
    ''' <returns></returns>
    Public Property CellBorderColor As Color
        Get

        End Get

        Set(ByVal value As Color)
            ' Create the bevel border.
            Dim border As New FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, value, value)

            'http://helpcentral.componentone.com/NetHelp/Spread8/WebSiteHelp/funct339.html
            'Change style of line
            'Me.ActiveSheet.Cells(0, 0, row, col).Border = New FarPoint.Win.ComplexBorderSide(System.Drawing.Color.Black, 2, Drawing2D.DashStyle.Solid)
            If _Row2 = -1 OrElse _Col2 = -1 Then
                'Me.ActiveSheet.Cells(Row, Col, Rows - 1, Cols - 1).Border = border
            Else
                Me.ActiveSheet.Cells(Row, Col, _Row2, _Col2).Border = border
            End If
        End Set
    End Property

    ''' <summary>
    ''' [Tab]キーはデフォルトの設定でアクティブセルを横方向に移動するアクションが割り当てられています。
    ''' このSPREADのアクションを無効にする（Noneを割り当てる）ことで、次のコントロールに移動するようになります。
    ''' </summary>
    ''' <returns></returns>
    Public Property ProcessTab As Boolean
        Get
            Return _ProcessTab
        End Get

        Set(ByVal value As Boolean)
            Dim im As FarPoint.Win.Spread.InputMap
            If value = False Then
                ' 非編集セルでの[Tab]キーを「無効」とします
                im = Me.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
                im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
                ' 編集中セルでの[Tab]キーを「無効」とします
                im = Me.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
                im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
            Else
                ' 非編集セルでの[Tab]キーを「無効」とします
                im = Me.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
                im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.Tab), FarPoint.Win.Spread.SpreadActions.None)
                ' 編集中セルでの[Tab]キーを「無効」とします
                im = Me.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
                im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Tab, Keys.Tab), FarPoint.Win.Spread.SpreadActions.None)
            End If
            _ProcessTab = value
        End Set
    End Property

    ''' <summary>
    ''' Set Cell Type of column 
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property TypeEditMultiLine As Boolean
        Get
            Return Nothing
        End Get

        Set(ByVal value As Boolean)
            Dim text As New FarPoint.Win.Spread.CellType.TextCellType
            text.Multiline = value
            Me.ActiveSheet.Cells(0, 0).CellType = text
        End Set
    End Property


    ''' <summary>
    ''' Sets or returns the action that occurs when the user presses the Enter key.
    ''' http://help.grapecity.com/spread/Spread8/WebSiteHelp/prop323.html
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property EditEnterAction As Int16
        Get
            Return Nothing
        End Get

        Set(ByVal value As Int16)
            Dim im As New FarPoint.Win.Spread.InputMap
            ' Deactivate F2 key in cells not being edited. 
            im = Me.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
            Select Case value
                Case FPSpread_EditEnterActionConstants_EditEnterActionNone
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.None)
                Case FPSpread_EditEnterActionConstants_EditEnterActionUp
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveChildUp)
                Case FPSpread_EditEnterActionConstants_EditEnterActionDown
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveChildDown)
                Case FPSpread_EditEnterActionConstants_EditEnterActionLeft
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveChildLeft)
                Case FPSpread_EditEnterActionConstants_EditEnterActionRight
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveChildRight)
                Case FPSpread_EditEnterActionConstants_EditEnterActionNext
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveToNextItem)
                Case FPSpread_EditEnterActionConstants_EditEnterActionPrevious
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveToPreviousItem)
                Case FPSpread_EditEnterActionConstants_EditEnterActionSame
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
                Case FPSpread_EditEnterActionConstants_EditEnterActionNextRow
                    im.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.Enter), FarPoint.Win.Spread.SpreadActions.MoveToNextRow)
            End Select
        End Set
    End Property

    ''' <summary>
    ''' Sets or returns whether users can resize individual rows. This property is available at run time only.
    ''' http://help.grapecity.com/spread/Spread8/WebSiteHelp/prop323.html
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property UserResizeRow As Boolean
        Get
            Return Me.ActiveSheet.Rows.Default.Resizable
        End Get

        Set(ByVal value As Boolean)
            '全ての行の行高変更を禁止
            Me.ActiveSheet.Rows.Default.Resizable = False
        End Set
    End Property

    ''' <summary>
    ''' Sets or returns the number of nonscrolling rows.
    ''' http://help.grapecity.com/spread/Spread8/WebSiteHelp/prop643.html
    ''' https://docs.grapecity.com/help/spread-winforms-8/#FarPoint.Win.SpreadJ~FarPoint.Win.Spread.SheetView~FrozenRowCount.html
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property RowsFrozen As Integer
        Get
            Return Me.ActiveSheet.FrozenRowCount
        End Get

        Set(ByVal value As Integer)
            Me.ActiveSheet.FrozenRowCount = False
        End Set
    End Property


    Public Overrides Property BackColor As Color
        Get
            '++修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
            'Return Me.ActiveSheet.ActiveCell.BackColor
            If Me.ActiveSheet Is Nothing Then
                Return NothingColumnColor
            Else
                If Me.ActiveSheet.ActiveCell Is Nothing Then
                    Return Me.ActiveSheet.NullBackColor
                Else
                    Return Me.ActiveSheet.ActiveCell.BackColor
                End If
            End If
            '--修正開始　2021年06月10日:MK（手）- VB→VB.NET変換
        End Get

        Set(ByVal value As Color)
            If _Col2 = -1 Then
                If _Col = -1 Then
                    For iCol As Integer = 0 To Cols - 1
                        Me.ActiveSheet.Cells(_Row, iCol).BackColor = value
                    Next
                Else
                    If _Row >= 0 Then
                        Me.ActiveSheet.Cells(_Row, _Col).BackColor = value
                    Else
                        For i As Integer = _Row To Row2
                            Me.ActiveSheet.Columns(i, _Col).BackColor = value
                        Next
                    End If
                End If
            Else
                If Me.ActiveSheet IsNot Nothing Then
                    If Row2 = -1 Then
                        If _Row >= 0 Then
                            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
                            'For i As Integer = Col To Col2
                            For i As Integer = _Col To Col2
                                '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
                                Me.ActiveSheet.Cells(Row, i).BackColor = value
                            Next
                        Else
                            '++修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
                            'For i As Integer = Col To Col2
                            For i As Integer = _Col To Col2
                                '--修正開始　2021年06月14日:MK（手）- VB→VB.NET変換
                                Me.ActiveSheet.Columns(i).BackColor = value
                            Next
                        End If
                    Else
                        For iRow As Integer = _Row To Row2
                            For iCol As Integer = _Col To Col2
                                Me.ActiveSheet.Cells(iRow, iCol).BackColor = value
                            Next
                        Next
                    End If
                End If
            End If
        End Set
    End Property

#End Region

#Region "追加関数"

    ''' <summary>
    ''' Set value for cell by RowIndex and Column Index
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    Public Sub SetText(ByVal col As Short, ByVal row As Integer, ByVal value As String)
        If row = -1 Then
            Me.ActiveSheet.ColumnHeader.Cells(0, col).Text = value
        ElseIf col = -1 Then
            Me.ActiveSheet.RowHeader.Cells(row, 0).Text = value
        ElseIf col = -1 Then
        Else
            If TypeOf Me.ActiveSheet.Cells(row, col).CellType Is ComboBoxCellType Then
                Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Cells(0, col).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
                For index As Integer = 0 To comboBoxCellType.Items.Count - 1
                    If value <> "" AndAlso comboBoxCellType.Items(index).Contains(value & " : ") Then
                        Me.ActiveSheet.ActiveCell.Value = comboBoxCellType.Items(index)
                        Exit Sub
                    End If
                Next
            Else
                Me.ActiveSheet.Cells(row, col).Value = value
            End If
        End If
    End Sub

    ''' <summary>
    ''' Set value for Header by RowIndex and Column Index
    ''' </summary>
    ''' <param name="row"></param>
    ''' <param name="col"></param>
    ''' <param name="value"></param>
    Public Sub SetHeaderText(ByVal col As Short, ByVal row As Integer, ByVal value As String)
        Me.ActiveSheet.ColumnHeader.Cells(row, col).Value = value
    End Sub

    ''' <summary>
    ''' Get value of cell by RowIndex and Column Index
    ''' </summary>
    ''' <param name="row">=-1: Return Header Text</param>
    ''' <param name="col"></param>
    ''' <param name="value">use when CALL GetText</param>
    ''' <returns></returns>
    Public Function GetText(ByVal col As Short, ByVal row As Integer, Optional ByRef value As String = "") As String
        If row = -1 Then
            value = Me.ActiveSheet.ColumnHeader.Cells(0, col).Value
            Return Me.ActiveSheet.ColumnHeader.Cells(0, col).Value
        Else
            value = Me.ActiveSheet.Cells(row, col).Value
            Return Me.ActiveSheet.Cells(row, col).Value
        End If
        'Return Me.ActiveSheet.Cells(row, col + 1).Value
    End Function

    ''' <summary>
    ''' Set column stype of spread
    ''' 
    ''' </summary>
    ''' <param name="mode">Type of control</param>
    ''' <param name="maxLength">Max Length of textbox</param>
    ''' <param name="decimalNum">If control type of Number set disable number</param>
    ''' <param name="sort">Set display or not sort icon in column</param>
    ''' <param name="headerBackgroundColor">Customize background color of column</param>
    ''' <param name="headerForeColor">Customize forecolor of column</param>
    ''' <param name="cellBackgroundColor">Customize background color of cell</param>
    ''' <param name="cellForeColor">Customize fore color of cell</param>
    ''' <param name="cellReadOnly">Set readonly column</param>
    Public Sub SetIntputStyle(ByVal mode As Short,
                               Optional maxLength As Short = 0,
                               Optional decimalNum As Short = 0,
                               Optional sort As Boolean = False,
                               Optional headerBackgroundColor As Color = Nothing,
                               Optional headerForeColor As Color = Nothing,
                               Optional cellBackgroundColor As Color = Nothing,
                               Optional cellForeColor As Color = Nothing,
                               Optional cellReadOnly As Boolean = False,
                               Optional iCol As Int16 = -9)
        '全てカラムの形式を設定
        If iCol = -1 Then
            For i As Integer = 0 To Cols - 1
                SetColStyle(i, mode, maxLength, decimalNum, sort, headerBackgroundColor, headerForeColor, cellBackgroundColor, cellForeColor, cellReadOnly)
            Next
        ElseIf iCol > 0 Then
            SetColStyle(iCol, mode, maxLength, decimalNum, sort, headerBackgroundColor, headerForeColor, cellBackgroundColor, cellForeColor, cellReadOnly)
        End If
    End Sub


    ''' <summary>
    ''' Set column stype of spread
    ''' 
    ''' </summary>
    ''' <param name="mode">Type of control</param>
    ''' <param name="maxLength">Max Length of textbox</param>
    ''' <param name="decimalNum">If control type of Number set disable number</param>
    ''' <param name="sort">Set display or not sort icon in column</param>
    ''' <param name="headerBackgroundColor">Customize background color of column</param>
    ''' <param name="headerForeColor">Customize forecolor of column</param>
    ''' <param name="cellBackgroundColor">Customize background color of cell</param>
    ''' <param name="cellForeColor">Customize fore color of cell</param>
    ''' <param name="cellReadOnly">Set readonly column</param>
    Public Sub SetRowIntputStyle(ByVal mode As Short,
                               Optional maxLength As Short = 0,
                               Optional decimalNum As Short = 0,
                               Optional sort As Boolean = False,
                               Optional headerBackgroundColor As Color = Nothing,
                               Optional headerForeColor As Color = Nothing,
                               Optional cellBackgroundColor As Color = Nothing,
                               Optional cellForeColor As Color = Nothing,
                               Optional cellReadOnly As Boolean = False,
                               Optional iRow As Int16 = -9)
        '全てカラムの形式を設定
        If iRow = -1 Then
            For i As Integer = 0 To Rows - 1
                SetRowStyle(i, mode, maxLength, decimalNum, sort, headerBackgroundColor, headerForeColor, cellBackgroundColor, cellForeColor, cellReadOnly)
            Next
        ElseIf iRow > 0 Then
            SetRowStyle(iRow, mode, maxLength, decimalNum, sort, headerBackgroundColor, headerForeColor, cellBackgroundColor, cellForeColor, cellReadOnly)
        End If
    End Sub

    ''' <summary>
    ''' Set Color button for active cell
    ''' </summary>
    ''' <param name="text">Text of button</param>
    ''' <param name="color">background color of button</param>
    Public Sub SetActiveSheetButtonColor(text As String, color As System.Drawing.Color)
        Dim btncell As New FarPoint.Win.Spread.CellType.ButtonCellType()
        '--修正開始　2022年01月19日:MK（手）- VB→VB.NET変換
        btncell.ButtonColor = color
        btncell.Text = text
        btncell.UseVisualStyleBackColor = False
        Me.ActiveSheet.ActiveCell.CellType = btncell
        '++修正開始　2022年01月19日:MK（手）- VB→VB.NET変換
    End Sub

    ''' <summary>
    ''' Set Color button for active cell
    ''' </summary>
    ''' <param name="text">Text of button</param>
    ''' <param name="color">background color of button</param>
    Public Sub SetColumnButtonColor(text As String, color As System.Drawing.Color, iColumn As Integer)
        Dim btncell As New FarPoint.Win.Spread.CellType.ButtonCellType()
        '--修正開始　2022年01月19日:MK（手）- VB→VB.NET変換
        btncell.ButtonColor = color
        btncell.Text = text
        btncell.UseVisualStyleBackColor = False
        Me.ActiveSheet.Columns(iColumn).CellType = btncell
        '++修正開始　2022年01月19日:MK（手）- VB→VB.NET変換
    End Sub

    ''' <summary>
    ''' Set FontBold for active cell
    ''' </summary>
    ''' <param name="bBold"></param>
    Public Sub SetActiveCellFontBold(bBold As Boolean)
        Dim fs As FontStyle
        Dim defFont As Font = Me.Font
        If bBold = False Then
            fs = fs Or FontStyle.Regular
            If defFont.Italic = True And defFont.Underline = True Then
                fs = fs Or FontStyle.Italic Or FontStyle.Underline
            End If
            If defFont.Italic = True And defFont.Underline = False Then
                fs = fs Or FontStyle.Italic
            End If
            If defFont.Italic = False And defFont.Underline = True Then
                fs = fs Or FontStyle.Underline
            End If
        Else
            fs = fs Or FontStyle.Bold
            If defFont.Italic = True And defFont.Underline = True Then
                fs = fs Or FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
            End If
            If defFont.Italic = True And defFont.Underline = False Then
                fs = fs Or FontStyle.Bold Or FontStyle.Italic
            End If
            If defFont.Italic = False And defFont.Underline = True Then
                fs = fs Or FontStyle.Bold Or FontStyle.Underline
            End If
        End If
        Me.ActiveSheet.ActiveCell.Font = New Font(defFont, fs)
    End Sub

    ''' <summary>
    ''' Set font size of Active Cell
    ''' </summary>
    ''' <param name="size"></param>
    Public Sub SetActiveCellFontSize(size As Single)
        Dim fs As FontStyle
        Dim defFont As Font = Me.Font
        If defFont.Bold = False Then
            fs = fs Or FontStyle.Regular
            If defFont.Italic = True And defFont.Underline = True Then
                fs = fs Or FontStyle.Italic Or FontStyle.Underline
            End If
            If defFont.Italic = True And defFont.Underline = False Then
                fs = fs Or FontStyle.Italic
            End If
            If defFont.Italic = False And defFont.Underline = True Then
                fs = fs Or FontStyle.Underline
            End If
        Else
            fs = fs Or FontStyle.Bold
            If defFont.Italic = True And defFont.Underline = True Then
                fs = fs Or FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
            End If
            If defFont.Italic = True And defFont.Underline = False Then
                fs = fs Or FontStyle.Bold Or FontStyle.Italic
            End If
            If defFont.Italic = False And defFont.Underline = True Then
                fs = fs Or FontStyle.Bold Or FontStyle.Underline
            End If
        End If

        Me.ActiveSheet.ActiveCell.Font = New Font(Me.Font.FontFamily, size, fs)
    End Sub


    ''' <summary>
    ''' Return text box button type
    ''' </summary>
    ''' <returns></returns>
    Public Function GetTextOfTypeButton() As String
        Try
            If Convert.ToString(Me.ActiveSheet.GetCellType(Row, Col)) = "ButtonCellType" Then
                Return DirectCast(Me.ActiveSheet.GetCellType(Row, Col), FarPoint.Win.Spread.CellType.ButtonCellType).[Text]
            Else
                Return ""
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' check is selection or not
    ''' </summary>
    ''' <param name="iRowIndex"></param>
    ''' <returns></returns>
    Public Function IsSelectedRow(ByVal iRowIndex As Int16) As Boolean

        Dim s As String
        Dim selections, j As Integer
        Dim cr As FarPoint.Win.Spread.Model.CellRange

        selections = Me.ActiveSheet.SelectionCount
        For j = 0 To selections - 1
            cr = Me.ActiveSheet.GetSelection(j)
            If cr.Row = iRowIndex Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Set Get value of active cell
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Property Text As String
        Get
            If Me.ActiveSheet.ActiveCell IsNot Nothing Then
                Return Me.ActiveSheet.ActiveCell.Text
            Else
                Return ""
            End If
        End Get

        Set(ByVal value As String)
            Me.ActiveSheet.ActiveCell.Text = value
        End Set
    End Property
#End Region

#Region "Common function"
    Private Sub InitGrid()
        If Me.Sheets.Count = 0 Then
            Me.Sheets.Add(New SheetView())
        End If
    End Sub

    Public Sub Load()
        'Public Sub SetFPSpreadStyle(ByRef spread As FpSpread,
        '                        Optional ByRef sheet As SheetView = Nothing,
        '                        Optional ByVal isShowRowHeader As Boolean = False,
        '                        Optional isShowColumnHeader As Boolean = True,
        '                        Optional ByVal iRowHeaderSize As Integer = 0,
        '                        Optional ByVal headerAutoText As HeaderAutoText = HeaderAutoText.Blank)

        If Me.ActiveSheet IsNot Nothing Then
            Me.ActiveSheet.AutoCalculation = False
            Me.ActiveSheet.ColumnCount = 0
            Me.ActiveSheet.DataAutoCellTypes = False
            Me.ActiveSheet.RowCount = 0
            Me.ActiveSheet.RowHeaderAutoText = headerAutoText
            Me.ActiveSheet.SheetName = "sheet"
        End If
        Me.AutoClipboard = False
        Me.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded
        Me.HorizontalScrollBarMode = FarPoint.Win.HorizontalScrollMode.Pixel
        Me.LegacyBehaviors = LegacyBehaviors.None
        Me.TabStripPolicy = TabStripPolicy.Never
        Me.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded
        Me.AllowDragDrop = False
        Me.AllowDragFill = False
        Me.AllowDrop = False
        Me.AllowRowMove = False
        Me.AllowDragFill = False
        Me.ColumnSplitBoxPolicy = SplitBoxPolicy.Never
        Me.RowSplitBoxPolicy = SplitBoxPolicy.Never

        Me.ActiveSheet.RowHeader.Columns(0).Font = DefineStatic.FPSPREAD_HEADER_FONT

        '全ての行の行高変更を禁止
        Me.ActiveSheet.Rows.Default.Resizable = False

        'Show RowHeader
        Me.ActiveSheet.RowHeaderVisible = isShowRowHeader

        'Show ColumnHeader
        Me.ActiveSheet.ColumnHeaderVisible = isShowColumnHeader

        If iRowHeaderSize <> 0 Then
            Me.ActiveSheet.RowHeader.Columns(0).Width = iRowHeaderSize
        End If
    End Sub

    ''' <summary>
    ''' Set Column Style
    ''' </summary>
    ''' <param name="columnIndex">Column Index</param>
    ''' <param name="width">width of column</param>
    ''' <param name="sort">active or not sort function column</param>
    ''' <param name="minWidth">set minimize width of column</param>
    ''' <param name="textAlign">set text align of column</param>
    ''' <param name="font">set font of column</param>
    Public Sub SetFPSpreadColumnStyle(columnIndex As Integer,
                                     Optional width As Integer = 0,
                                     Optional sort As Boolean = True,
                                     Optional minWidth As Integer = 0,
                                     Optional textAlign As Short = MSFlexGridLib_AlignmentSettings_flexAlignLeftCenter,
                                     Optional font As Font = Nothing)

        Dim sheet = Me.ActiveSheet

        ' Set Cell data Type
        If sort = False Then
            Dim wrapoff As New CellType.EditBaseCellType
            wrapoff.WordWrap = False
            sheet.ColumnHeader.Columns(columnIndex).CellType = wrapoff
            Dim bevelbrdr As New FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered, SystemColors.ControlDark, SystemColors.ControlDark)
            sheet.ColumnHeader.Columns(columnIndex).Border = bevelbrdr
        End If

        ' Set Foint
        sheet.ColumnHeader.Columns(columnIndex).Font = DefineStatic.FPSPREAD_FONT
        If font Is Nothing Then
            sheet.Columns(columnIndex).Font = DefineStatic.FPSPREAD_FONT
        Else
            sheet.Columns(columnIndex).Font = font
        End If

        ' Set Alignment
        Select Case textAlign
            Case MSFlexGridLib_AlignmentSettings_flexAlignCenterCenter
                Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                Me.ActiveSheet.ColumnHeader.Columns(Col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            Case MSFlexGridLib_AlignmentSettings_flexAlignLeftCenter
                Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                Me.ActiveSheet.ColumnHeader.Columns(Col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            Case MSFlexGridLib_AlignmentSettings_flexAlignRightCenter
                Me.ActiveSheet.ColumnHeader.Columns(Col).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                Me.ActiveSheet.ColumnHeader.Columns(Col).VerticalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
        End Select

        ' Set Sort
        sheet.SetColumnAllowAutoSort(columnIndex, sort)

        ' Set column width
        If width > 0 Then
            sheet.Columns(columnIndex).Width = width
        Else
            If minWidth < sheet.Columns(columnIndex).GetPreferredWidth Then
                sheet.Columns(columnIndex).Width = sheet.Columns(columnIndex).GetPreferredWidth
            Else
                sheet.Columns(columnIndex).Width = minWidth
            End If
        End If

    End Sub

    Public Sub ClearActiveRowSpread()
        Me.SetViewportTopRow(0, 0)
        Me.Row = -1
        Me.Col = -1
        Me.Row2 = -1
        Me.Col2 = -1
    End Sub

    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    Public Sub SetDottedBorderActiveCell()
        Me.FocusRenderer = New Common.CustomizeFPSpread.DottedIndicator()
    End Sub
    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    Public Sub SetColorBorderActiveCell(customColor As Color, Optional customBorderWidth As Integer = 2)
        Me.FocusRenderer = New Common.CustomizeFPSpread.BorderColorIndicator(customColor, customBorderWidth)
    End Sub
    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
    Public Sub SetColorBorderAroundActiveCell(customColor As Color, border As Color, Optional customBorderWidth As Integer = 2)
        Me.FocusRenderer = New Common.CustomizeFPSpread.BorderAroundColorIndicator(customColor, border, customBorderWidth)
    End Sub
    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
#End Region
#End Region


    '++修正開始　2022年10月06日:MK（手）- VB→VB.NET変換
    Public Sub ClearText()

        If _Col2 = -1 Then
            If _Row2 = -1 Then
                Me.ActiveSheet.Cells(Row, Col).Text = ""
            Else
                For iRow As Integer = Row To Row2
                    Me.ActiveSheet.Cells(iRow, Col).Text = ""
                Next
            End If
        Else
            For iCol As Integer = Col To Col2
                For iRow As Integer = Row To Row2
                    Me.ActiveSheet.Cells(iRow, iCol).Text = ""
                Next
            Next
        End If
    End Sub

    Public Sub ClearText(iStartRow As Integer, iEndRow As Integer, iStartCol As Integer, iEndCol As Integer)

        If Cols > 0 AndAlso Rows > 0 Then

            For iCol As Integer = iStartCol To iEndCol
                For iRow As Integer = iStartRow To iEndRow
                    Me.ActiveSheet.Cells(iRow, iCol).Text = ""
                Next
            Next

        End If
    End Sub
    '--修正開始　2022年10月06日:MK（手）- VB→VB.NET変換

    '++修正開始　2022年12月24日:MK（手）- VB→VB.NET変換
    Public Sub SetComboboxColumn(colIndex As Integer, strValue As String)
        If String.IsNullOrEmpty(strValue) = False Then


            Dim combobox As New ComboBoxCellType
            Dim itemList = Split(strValue, vbTab)
            combobox.Items = itemList
            combobox.DropDownOptions = FarPoint.Win.DropDownOptions.ButtonAndText
            combobox.AutoCompleteMode = AutoCompleteMode.None
            combobox.Editable = True
            Me.ActiveSheet.Columns(colIndex).CellType = combobox
            If Me.ActiveSheet.RowCount > 0 Then
                Me.ActiveSheet.Cells(0, colIndex).CellType = combobox
            End If
        End If
    End Sub

    Public Function GetTypeComboBoxCount(colIndex As Integer) As Integer
        Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Columns(colIndex).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
        Return comboBoxCellType.Items.Count
    End Function

    Public Function GetTypeComboBoxString(colIndex As Integer, itemIndex As Integer) As String
        Try

            Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Columns(colIndex).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
            If comboBoxCellType IsNot Nothing Then
                Dim value As String = comboBoxCellType.Items(itemIndex)
                If value Is Nothing Then Return 0
                Return IIf(String.IsNullOrEmpty(value), 0, value.Substring(0, value.IndexOf(" : ")))
            End If
        Catch ex As Exception

        End Try

        Return -1
    End Function

    Public Sub SetTypeComboBoxString(iRow As Integer, iCol As Integer, valueIndex As Integer)
        Try
            Dim comboBoxCellType As FarPoint.Win.Spread.CellType.ComboBoxCellType = CType(Me.ActiveSheet.Columns(iCol).CellType, FarPoint.Win.Spread.CellType.ComboBoxCellType)
            If comboBoxCellType IsNot Nothing Then
                Try

                    Me.ActiveSheet.SetText(iRow, iCol, comboBoxCellType.Items(valueIndex))
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--修正開始　2022年12月24日:MK（手）- VB→VB.NET変換
#Region "Private Function"
    ''' <summary>
    ''' Set one column stype
    ''' </summary>
    ''' <param name="col">Column index: column want to set set style</param>
    ''' <param name="mode">Type of control</param>
    ''' <param name="maxLength">Max Length of textbox</param>
    ''' <param name="decimalNum">If control type of Number set disable number</param>
    ''' <param name="sort">Set display or not sort icon in column</param>
    ''' <param name="headerBackgroundColor">Customize background color of column</param>
    ''' <param name="headerForeColor">Customize forecolor of column</param>
    ''' <param name="cellBackgroundColor">Customize background color of cell</param>
    ''' <param name="cellForeColor">Customize fore color of cell</param>
    ''' <param name="cellReadOnly">Set readonly column</param>
    Public Sub SetColStyle(ByVal col As Short,
                           ByVal mode As Short,
                           Optional maxLength As Short = 0,
                           Optional decimalNum As Short = 0,
                           Optional sort As Boolean = False,
                           Optional headerBackgroundColor As Color = Nothing,
                           Optional headerForeColor As Color = Nothing,
                           Optional cellBackgroundColor As Color = Nothing,
                           Optional cellForeColor As Color = Nothing,
                           Optional cellReadOnly As Boolean = False)
        Select Case mode
            Case PGRIDLib_ColStyleConstants_pgcs_ラベル
                Dim labelCellTyle As New EmptyCellType
                Me.ActiveSheet.Columns(col).CellType = labelCellTyle
            Case PGRIDLib_ColStyleConstants_pgcs_テキスト
                Dim textCellTyle As New TextCellType
                If cellReadOnly Then
                    textCellTyle.ReadOnly = True
                End If
                If maxLength <> 0 Then
                    textCellTyle.MaxLength = maxLength
                End If
                Me.ActiveSheet.Columns(col).CellType = textCellTyle
            Case PGRIDLib_ColStyleConstants_pgcs_チェックボックス
                Dim checkboxCellTyle As New CheckBoxCellType
                Me.ActiveSheet.Columns(col).CellType = checkboxCellTyle
            Case PGRIDLib_ColStyleConstants_pgcs_数字
                Dim numberCellTyle As New NumberCellType
                numberCellTyle.DecimalPlaces = decimalNum
                numberCellTyle.ShowSeparator = True
                If cellReadOnly Then
                    numberCellTyle.ReadOnly = True
                End If
                Me.ActiveSheet.Columns(col).CellType = numberCellTyle
                DirectCast(Me.ActiveSheet.Columns(col).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = decimalNum
        End Select

        'Set Header color
        If headerBackgroundColor <> Nothing Then
            Me.ActiveSheet.ColumnHeader.Columns(col).BackColor = headerBackgroundColor
            Me.ActiveSheet.ColumnHeader.Columns(col).ForeColor = headerForeColor
            Me.ActiveSheet.ColumnHeader.Columns(col).Locked = True
        End If

        'Set Detail color
        If cellBackgroundColor <> Nothing Then
            Me.ActiveSheet.Columns(col).BackColor = cellBackgroundColor
        End If
        If cellBackgroundColor <> Nothing Then
            Me.ActiveSheet.Columns(col).ForeColor = cellForeColor
        End If
    End Sub


    ''' <summary>
    ''' Set one Row stype
    ''' </summary>
    ''' <param name="row">Row index: column want to set set style</param>
    ''' <param name="mode">Type of control</param>
    ''' <param name="maxLength">Max Length of textbox</param>
    ''' <param name="decimalNum">If control type of Number set disable number</param>
    ''' <param name="sort">Set display or not sort icon in column</param>
    ''' <param name="headerBackgroundColor">Customize background color of column</param>
    ''' <param name="headerForeColor">Customize forecolor of column</param>
    ''' <param name="cellBackgroundColor">Customize background color of cell</param>
    ''' <param name="cellForeColor">Customize fore color of cell</param>
    ''' <param name="cellReadOnly">Set readonly column</param>
    Public Sub SetRowStyle(ByVal row As Short,
                           ByVal mode As Short,
                           Optional maxLength As Short = 0,
                           Optional decimalNum As Short = 0,
                           Optional sort As Boolean = False,
                           Optional headerBackgroundColor As Color = Nothing,
                           Optional headerForeColor As Color = Nothing,
                           Optional cellBackgroundColor As Color = Nothing,
                           Optional cellForeColor As Color = Nothing,
                           Optional cellReadOnly As Boolean = False)
        Select Case mode
            Case PGRIDLib_ColStyleConstants_pgcs_ラベル
                Dim labelCellTyle As New EmptyCellType
                Me.ActiveSheet.Rows(row).CellType = labelCellTyle
            Case PGRIDLib_ColStyleConstants_pgcs_テキスト
                Dim textCellTyle As New TextCellType
                If cellReadOnly Then
                    textCellTyle.ReadOnly = True
                End If
                If maxLength <> 0 Then
                    textCellTyle.MaxLength = maxLength
                End If
                Me.ActiveSheet.Rows(row).CellType = textCellTyle
            Case PGRIDLib_ColStyleConstants_pgcs_チェックボックス
                Dim checkboxCellTyle As New CheckBoxCellType
                Me.ActiveSheet.Rows(row).CellType = checkboxCellTyle
            Case PGRIDLib_ColStyleConstants_pgcs_数字
                Dim numberCellTyle As New NumberCellType
                numberCellTyle.DecimalPlaces = decimalNum
                numberCellTyle.ShowSeparator = True
                If cellReadOnly Then
                    numberCellTyle.ReadOnly = True
                End If
                Me.ActiveSheet.Rows(row).CellType = numberCellTyle
                DirectCast(Me.ActiveSheet.Rows(row).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = decimalNum
        End Select

        'Set Header color
        If headerBackgroundColor <> Nothing Then
            Me.ActiveSheet.ColumnHeader.Rows(row).BackColor = headerBackgroundColor
            Me.ActiveSheet.ColumnHeader.Rows(row).ForeColor = headerForeColor
            Me.ActiveSheet.ColumnHeader.Rows(row).Locked = True
        End If

        'Set Detail color
        If cellBackgroundColor <> Nothing Then
            Me.ActiveSheet.Rows(row).BackColor = cellBackgroundColor
        End If
        If cellBackgroundColor <> Nothing Then
            Me.ActiveSheet.Rows(row).ForeColor = cellForeColor
        End If
    End Sub

    ''' <summary>
    ''' Set value for cell by RowIndex and Column Index
    ''' </summary>
    ''' <param name="colCount">The number of the first columns which are frozen</param>
    Public Sub FrozenColumns(ByVal colCount As Short, Optional ByVal showHorizontalScrollBar As Boolean = True)
        If Me.ActiveSheet.RowCount > 0 Then
            Me.HorizontalScrollBar.Buttons = FarPoint.Win.Spread.ScrollBarButtons.HomeEnd Or FarPoint.Win.Spread.ScrollBarButtons.LineUpDown Or FarPoint.Win.Spread.ScrollBarButtons.PageUpDown Or FarPoint.Win.Spread.ScrollBarButtons.Thumb
            Me.ActiveSheet.FrozenColumnCount = colCount
            If showHorizontalScrollBar = True Then
                Me.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
            End If

            'High light the right border  of the last Frozen column to make user impressed
            ' Dim frozenColumns As New FarPoint.Win.Spread.DrawingSpace.LineShape()
            'FrozenColumns.Thickness = 1
            'FrozenColumns.ShapeOutlineColor = Color.IndianRed

            'FrozenColumns.SetBounds(0, 0, 0, Me.ActiveSheet.Rows.Count * Me.ActiveSheet.Rows(0, 0).Height)

            'Me.ActiveSheet.AddShape(frozenColumns, 0, Me.ActiveSheet.FrozenColumnCount)
        End If
    End Sub
#End Region


End Class

Module FpSpreadExtensions

    '<Extension()>
    'Public Sub Print(cell As FarPoint.Win.Spread.Cell, ByVal col As Integer)
    'End Sub

End Module
