Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Public Class OraDynasetReader
    Implements IDisposable

    Private m_Fields As OraFieldsReader
    'Private m_DataSet As DataSet
    Private m_OraDatabase As OraDatabase

    Private m_Reader As OracleDataReader
    Private m_HasData As Boolean
    Friend Sub New(ByRef reader As OracleDataReader,
                    ByRef database As OraDatabase, ByVal dynOption As Integer)
        m_Reader = reader
        m_OraDatabase = database
        MoveFirst()
    End Sub


    Public ReadOnly Property Fields As OraFieldsReader
        Get
            Return m_Fields
        End Get
    End Property

    'Public ReadOnly Property FieldCount As Integer
    '    Get
    '        Return m_Reader.FieldCount
    '    End Get
    'End Property


    Public Sub MoveFirst()


        m_HasData = m_Reader.Read()
        'Dim fields As Dictionary(Of String, String) = New Dictionary(Of String, String)()

        'If m_Reader.HasRows Then

        '    For index As Integer = 0 To m_Reader.FieldCount - 1
        '        fields(m_Reader.GetName(index)) = m_Reader.GetString(index)
        '    Next
        'End If
        m_Fields = New OraFieldsReader(m_Reader)
    End Sub
    Public Sub DbMoveFirst()
        MoveFirst()
    End Sub
    Public Sub MoveNext()
        m_HasData = m_Reader.Read()

    End Sub
    Public Sub DbMoveNext()
        MoveNext()
    End Sub

    Public ReadOnly Property EOF As Boolean
        Get
            Return Not m_HasData
        End Get
    End Property

    Public Sub Close()
        Me.Dispose()
    End Sub



    Default Public ReadOnly Property Item(ByVal name As String) As OraFieldReader
        Get
            Return m_Fields(name)
        End Get
    End Property
    Default Public ReadOnly Property Item(ByVal index As Integer) As OraFieldReader
        Get

            Return m_Fields(index)
        End Get
    End Property


    'Public ReadOnly Property HasPrimaryKey As Boolean
    '    Get
    '        Return m_DataTable.PrimaryKey.Count > 0
    '    End Get
    'End Property
    'Public ReadOnly Property DynOption As Integer
    '    Get
    '        Return m_DynOption

    '    End Get

    'End Property

    'Public Function GetColumnName(ByVal idx As Integer) As String
    '    Return m_Reader.GetName(idx)
    'End Function

    'Public Function GetColumnType(ByVal idx As Integer) As Type
    '    Return m_Reader.GetFieldType(idx)
    'End Function
    Public Sub Dispose() Implements System.IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub




End Class
