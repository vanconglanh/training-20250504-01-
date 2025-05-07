Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Imports Newtonsoft.Json

Public Class OraParameters
    Implements IEnumerable, IEnumerable(Of OraParameter)

    Private m_Count As Integer
    Private m_Dictionary As Dictionary(Of String, OraParameter)
    Private m_List As List(Of OraParameter)

    Public Sub New()
        m_Dictionary = New Dictionary(Of String, OraParameter)()
        m_List = New List(Of OraParameter)()
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            If m_Dictionary Is Nothing Then
                Return 0
            Else
                Return m_Dictionary.Count()
            End If
        End Get
    End Property

    Public Function GetEnumerator() As IEnumerator _
            Implements IEnumerable.GetEnumerator
        Return m_List.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As IEnumerator(Of OraParameter) _
            Implements IEnumerable(Of OraParameter).GetEnumerator
        'https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/control-flow/walkthrough-implementing-ienumerable-of-t
        Return m_List.GetEnumerator()
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As OraParameter
        Get
            Return m_List(index)
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal name As String) As OraParameter
        Get
            Dim f As OraParameter

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
    Public Sub Add(ByVal name As String, ByVal value As Object, ByVal ioType As Integer)
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod002.htm#OOFOL426
        If m_Dictionary.ContainsKey(name) Then
            Remove(name)
        End If

        Dim param As OraParameter = New OraParameter(name, value, ioType)
        'Advance: Auto detect server type
        'If value IsNot Nothing Then
        '    If value.GetType().Name = "String" Then
        '        param.ServerType = ORATYPE_STRING
        '    ElseIf value.GetType().Name.StartsWith("Int") Then
        '        param.ServerType = ORATYPE_NUMBER
        '    ElseIf value.GetType().Name.StartsWith("Double") Then
        '        param.ServerType = ORATYPE_NUMBER
        '    ElseIf value.GetType().Name.StartsWith("DateTime") Then
        '        param.ServerType = ORATYPE_DATE
        '    Else
        '        param.ServerType = ORATYPE_STRING 'Default
        '    End If
        'End If
        'https://docs.oracle.com/cd/E63277_01/win.121/e63268/OracleParameterClass.htm#BABCAFIB => If neither OracleDbType nor DbType are set, their values can be inferred by Value.
        m_Dictionary.Add(name, param)
        m_List.Add(param)
    End Sub
    Public Sub Add(ByVal name As String, ByVal value As Object, ByVal ioType As Integer, ByVal serverType As Short, Optional ByVal objName As String = Nothing)
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod002.htm#OOFOL426
        If m_Dictionary.ContainsKey(name) Then
            Remove(name)
        End If
        Dim param As OraParameter = New OraParameter(name, value, ioType, serverType, objName)
        m_Dictionary.Add(name, param)
        m_List.Add(param)
    End Sub

    Public Function AddTable(ByVal name As String, ByVal ioType As Short, ByVal serverType As Short, ByVal arraySize As Integer,
                        Optional ByVal elementSize As Integer = 0) As Object()
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod010.htm#OOFOL439
        'If m_Dictionary.ContainsKey(name) Then
        '    Throw New Exception($"{name} is already existing")
        'End If
        If m_Dictionary.ContainsKey(name) Then
            Remove(name)
        End If
        Dim param As OraParameter = New OraParameter(name, Nothing,
                                                     True, ioType, serverType, arraySize, elementSize)
        m_Dictionary.Add(name, param)
        m_List.Add(param)
        Return CType(param.Value, Object())
    End Function

    Public Sub Remove(ByVal name As String)
        If m_Dictionary IsNot Nothing Then
            m_Dictionary.Remove(name)
        End If
        'Remove from List 
        Dim idx As Integer = -1
        For i As Integer = 0 To m_List.Count - 1
            Dim f = m_List(i)
            If String.Compare(name, f.Name, True) = 0 Then
                idx = i
            End If
        Next

        If idx >= 0 Then
            m_List.RemoveAt(idx)
        End If
    End Sub

    Friend Function GetOracleParameters() As List(Of OracleParameter)
        Dim oracleParams As New List(Of OracleParameter)
        If m_List IsNot Nothing And m_List.Count > 0 Then
            For Each item As OraParameter In m_List
                oracleParams.Add(item.OracleParameter)
            Next
        End If
        Return oracleParams
    End Function

    Public ReadOnly Property ArrayBindCount As Integer
        Get
            'OracleCommand in ODP.NET requires this information
            If m_List.Count > 0 Then
                For Each item As OraParameter In m_List
                    If item.IsArray Then
                        Return item.ArraySize
                    End If
                Next
            End If
            Return 0
        End Get
    End Property



End Class
