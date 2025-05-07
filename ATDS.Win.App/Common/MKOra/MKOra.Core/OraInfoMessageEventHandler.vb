Option Explicit On
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Public Class OraInfoMessageEventHandler
    Private m_OracleErrorCollection As OracleErrorCollection = Nothing
    Private m_Message As String = Nothing
    Public Sub Handler(ByVal src As Object, ByVal args As OracleInfoMessageEventArgs)
        m_OracleErrorCollection = args.Errors
        m_Message = args.Message
    End Sub
    Public ReadOnly Property Errors() As OracleErrorCollection
        Get
            Return m_OracleErrorCollection
        End Get

    End Property

    Public ReadOnly Property Message() As String
        Get
            Return m_Message
        End Get

    End Property

End Class
