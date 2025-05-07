Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client

Public Class OraFieldsReader
    Implements IEnumerable, IEnumerable(Of OraFieldReader)

    Private m_Count As Integer
    Private m_Dictionary As Dictionary(Of String, OraFieldReader)
    Private m_List As List(Of OraFieldReader)

    Friend Sub New(ByRef reader As OracleDataReader)
        m_Count = reader.FieldCount
        m_Dictionary = New Dictionary(Of String, OraFieldReader)()
        m_List = New List(Of OraFieldReader)()

        'For i As Integer = 0 To m_Count - 1
        '    Dim dc As DataColumn = dataColumCol(i)
        '    Dim f As OraField = New OraField(dyn, dc.ColumnName, i, dc.DataType.Name)
        '    m_Dictionary.Add(dc.ColumnName, f)
        '    m_List.Add(f)
        'Next

        For i As Integer = 0 To m_Count - 1

            'Dim f As OraFieldReader = New OraFieldReader(dyn, dyn.GetColumnName(i), i, dyn.GetColumnType(i).Name)
            'm_Dictionary.Add(dyn.GetColumnName(i), f)
            Dim f As OraFieldReader = New OraFieldReader(reader, reader.GetName(i), i, reader.GetFieldType(i).Name)
            m_Dictionary.Add(reader.GetName(i), f)
            m_List.Add(f)
        Next


    End Sub

    Public ReadOnly Property Count As Integer
        Get
            Return m_Count
        End Get
    End Property

    Public Function GetEnumerator() As IEnumerator _
            Implements IEnumerable.GetEnumerator
        Return m_List.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As IEnumerator(Of OraFieldReader) _
            Implements IEnumerable(Of OraFieldReader).GetEnumerator
        'https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/control-flow/walkthrough-implementing-ienumerable-of-t
        Return m_List.GetEnumerator()
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As OraFieldReader
        Get
            Return m_List(index)
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal name As String) As OraFieldReader
        Get
            Dim f As OraFieldReader

            If m_Dictionary.TryGetValue(name, f) Then
                Return f
            End If

            For i As Integer = 0 To m_List.Count - 1
                f = m_List(i)

                If String.Compare(name, f.Name, True) = 0 Then
                    Return f
                End If
            Next

            Throw New IndexOutOfRangeException()
        End Get
    End Property
End Class
