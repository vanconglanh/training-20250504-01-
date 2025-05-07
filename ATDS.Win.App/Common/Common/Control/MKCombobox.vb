Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class MKCombobox
    Inherits System.Windows.Forms.ComboBox

    ''' <summary>
    ''' ReadOnly Control
    ''' </summary>
    Private _bReadOnly As Boolean = False
    Private _bActiveEditData As Boolean = False
    Private _strCurrentValue As String
    Private _iSelectedIndex As Integer

    Public Sub New()
        initializeCollections()
    End Sub

    ' フィールドなどを初期化します。
    Private Sub initializeCollections()

    End Sub

    ''' <summary>
    ''' Set Selected Text to memory and active not edit 
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnEnter(e As EventArgs)
        _bActiveEditData = True
        _strCurrentValue = Me.Text
        _iSelectedIndex = Me.SelectedIndex
        MyBase.OnEnter(e)
    End Sub

    ''' <summary>
    ''' When have change text:
    ''' 1/ Is ReadOnly = true AND Actived Not edit control => reset data from memory
    ''' 2/ If Not: Change data
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        If _bReadOnly And _bActiveEditData Then
            MyBase.SelectedIndex = _iSelectedIndex
            MyBase.Text = _strCurrentValue
        End If
    End Sub

    ''' <summary>
    ''' When Leave, Inactive Not Edit mode (can edit data from source)
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnLeave(e As EventArgs)
        MyBase.OnLeave(e)
        _bActiveEditData = False
    End Sub

    ''' <summary>
    '''  ReadOnly Properties
    ''' </summary>
    Public Property CustomizeReadOnly As Boolean
        Get
            Return _bReadOnly
        End Get
        Set(ByVal value As Boolean)
            _bReadOnly = value
        End Set
    End Property


End Class
