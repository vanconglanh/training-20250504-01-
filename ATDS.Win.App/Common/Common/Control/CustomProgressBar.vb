Imports System.Windows.Forms
Imports System.Drawing

Public Class CustomProgressBar
    Inherits ProgressBar

    Public Sub New()
    End Sub

    Public Property Max As Integer

        Get
            Return Me.Maximum
        End Get
        Set(ByVal value As Integer)
            Me.Maximum = value
        End Set
    End Property

    Public Property Min As Integer

        Get
            Return Me.Minimum
        End Get
        Set(ByVal value As Integer)
            Me.Minimum = value
        End Set
    End Property
End Class
