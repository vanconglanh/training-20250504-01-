Imports System.Drawing
Imports System.Windows.Forms

Public Class MKLabel
    Inherits System.Windows.Forms.Label
    ''' <summary>
    ''' If don't want auto padding top, set this parameter = False 
    ''' </summary>
    Private _allowAutoTopPadding As Boolean = True

    Public Sub New()
        initializeCollections()
    End Sub

    ' フィールドなどを初期化します。
    Private Sub initializeCollections()

    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        ' Call the OnPaint method of the base class.
        If Not Enabled Then
            Using temp As Label = New Label()
                Using bitmap As Bitmap = New Bitmap(Width, Height)
                    temp.BackColor = BackColor
                    temp.AutoSize = AutoSize
                    temp.Font = Font
                    temp.Size = Size
                    temp.Location = Location
                    temp.Text = Text
                    temp.TextAlign = TextAlign
                    temp.ForeColor = ForeColor
                    temp.DrawToBitmap(bitmap, temp.ClientRectangle)

                    If AllowAutoTopPadding = False Then
                        pe.Graphics.DrawImage(bitmap, New Point(-1, Me.Padding.Top))
                    Else
                        pe.Graphics.DrawImage(bitmap, New Point(-1, 2))
                    End If

                End Using
            End Using
        Else
            MyBase.OnPaint(pe)
        End If

        'Layout
        If AllowAutoTopPadding = True AndAlso Me.Padding.Left = 0 AndAlso Me.Padding.Right = 0 AndAlso Me.Padding.Top = 0 AndAlso Me.Padding.Bottom = 0 Then
            Me.Padding = New Windows.Forms.Padding(Me.Padding.Left, 2, Me.Padding.Right, Me.Padding.Bottom)
        Else
            Me.Padding = New Windows.Forms.Padding(Me.Padding.Left, Me.Padding.Top, Me.Padding.Right, Me.Padding.Bottom)
        End If
    End Sub

    ''' <summary>
    ''' Set Appearance according to old source : TODO
    ''' </summary>
    Private _appearance As Short
    Public Property Appearance As Short
        Get
            Return _appearance
        End Get
        Set(ByVal value As Short)
            _appearance = value
            Me.FlatStyle = value
        End Set
    End Property


    ''' <summary>
    ''' If don't want auto padding top, set this parameter = False 
    ''' </summary>
    ''' <returns></returns>
    Public Property AllowAutoTopPadding As Boolean
        Get
            Return _allowAutoTopPadding
        End Get
        Set(ByVal value As Boolean)
            _allowAutoTopPadding = value
        End Set
    End Property
End Class
