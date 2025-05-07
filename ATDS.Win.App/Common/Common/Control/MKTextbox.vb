Imports System.Windows.Forms

Public Class MKTextBox
    Inherits System.Windows.Forms.TextBox

    ' On focus on control or not
    Private isAlreadyFocused As Boolean

    ''' <summary>
    ''' Textbox not support AutoSize -> public this property
    ''' </summary>
    ''' <returns></returns>
    Public Property MKAutoSize As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(value As Boolean)
            MyBase.AutoSize = value
        End Set
    End Property

    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        MyBase.OnLeave(e)

        Me.isAlreadyFocused = False

    End Sub


    ''' <summary>
    ''' When focus to control set all text of control is selected
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        MyBase.OnGotFocus(e)

        ' Select all text only if the mouse isn't down.
        ' This makes tabbing to the textbox give focus.
        If MouseButtons = MouseButtons.None Then

            If Me.ReadOnly = False Then
                Me.SelectAll()
                Me.isAlreadyFocused = True
            End If

        End If

    End Sub

    ''' <summary>
    ''' When use mouse focus to control is also set all text of control is selected
    ''' </summary>
    ''' <param name="mevent"></param>
    Protected Overrides Sub OnMouseUp(ByVal mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)

        If Not Me.isAlreadyFocused AndAlso Me.SelectionLength = 0 Then

            If Me.ReadOnly = False Then
                Me.isAlreadyFocused = True
                Me.SelectAll()
            End If
        End If

    End Sub


End Class
