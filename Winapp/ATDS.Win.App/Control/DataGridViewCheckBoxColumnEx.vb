Imports System.Windows.Forms
Imports System
Imports System.Drawing

Public Class DataGridViewCheckBoxColumnEx
    Inherits DataGridViewCheckBoxColumn
    Private labelField As String

    Public Property Label As String
        Get
            Return labelField
        End Get
        Set(ByVal value As String)
            labelField = value
        End Set
    End Property

    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return New DataGridViewCheckBoxCellEx()
        End Get
        Set(ByVal value As DataGridViewCell)
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class DataGridViewCheckBoxCellEx
    Inherits DataGridViewCheckBoxCell
    Private labelField As String

    Public Property Label As String
        Get
            Return labelField
        End Get
        Set(ByVal value As String)
            labelField = value
        End Set

    End Property

    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)

        ' the base Paint implementation paints the check box
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        ' Get the check box bounds: they are the content bounds
        Dim contentBounds As Rectangle = Me.GetContentBounds(rowIndex)

        ' Compute the location where we want to paint the string.
        Dim stringLocation As Point = New Point()

        ' Compute the Y.
        ' NOTE: the current logic does not take into account padding.
        stringLocation.Y = cellBounds.Y + 2


        ' Compute the X.
        ' Content bounds are computed relative to the cell bounds
        ' - not relative to the DataGridView control.
        stringLocation.X = cellBounds.X + contentBounds.Right + 2


        ' Paint the string.
        If Equals(Label, Nothing) Then
            Dim col As DataGridViewCheckBoxColumnEx = CType(Me.OwningColumn, DataGridViewCheckBoxColumnEx)
            labelField = col.Label
        End If

        graphics.DrawString(Label, Control.DefaultFont, Drawing.Brushes.Red, stringLocation)

    End Sub

End Class
