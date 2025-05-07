Imports System.Drawing
Imports System.Windows.Forms


Public Class MKGroupBox
    Inherits System.Windows.Forms.GroupBox

    Private _disableForeColor As Color

    Public Sub New()
        MyBase.New
        initializeCollections()
    End Sub

    ' フィールドなどを初期化します。
    Private Sub initializeCollections()

    End Sub

    Public Property DisableForeColor As Color
        Get
            Return _disableForeColor
        End Get
        Set
            _disableForeColor = Value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ' Call the OnPaint method of the base class.
        If Not Enabled Then
            Dim tSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
            Dim borderRect As Rectangle = e.ClipRectangle
            borderRect.Y = (borderRect.Y + (tSize.Height / 2))
            borderRect.Height = (borderRect.Height - (tSize.Height / 2))
            ControlPaint.DrawBorder(e.Graphics, borderRect, SystemColors.ActiveBorder, ButtonBorderStyle.Solid)
            Dim textRect As Rectangle = e.ClipRectangle
            textRect.X = (textRect.X + 6)
            textRect.Width = tSize.Width
            textRect.Height = tSize.Height
            e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRect)
        Else
            MyBase.OnPaint(e)
        End If

    End Sub
End Class
