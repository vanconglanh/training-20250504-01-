Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports Newtonsoft.Json

Public Class OraParameter
    Implements IDisposable

    Private m_Name As String
    Private m_ServerType As Short
    'Private m_Value As Object
    Private m_IsArray As Boolean
    Private m_ArraySize As Integer
    Private m_OracleParameter As OracleParameter
    Private m_ValueOrg As Object
    Friend Sub New(ByVal name As String,
                     ByVal value As Object,
                   ByVal isArray As Boolean,
                   ByVal ioType As Short,
                   ByVal serverType As Short,
                   ByVal arraySize As Integer,
                   Optional ByVal elementSize As Integer = 0)
        m_Name = name
        m_IsArray = isArray
        m_OracleParameter = New OracleParameter()
        m_OracleParameter.ParameterName = name
        MapIOType(m_OracleParameter, ioType)

        m_ArraySize = arraySize
        m_ServerType = serverType
        MapServerType(m_OracleParameter, m_ServerType)

        If m_IsArray Then
            'm_OracleParameter.Size = m_ArraySize
            'Init array

            'Dim array() As Object
            m_OracleParameter.Value = New Object() {}
            'ReDim m_OracleParameter.Value(m_ArraySize)
            Array.Resize(m_OracleParameter.Value, m_ArraySize)
        End If
    End Sub

    Friend Sub New(ByVal name As String,
                   ByVal value As Object,
                   ByVal ioType As Short,
                   ByVal serverType As Short,
                    Optional ByVal objName As String = Nothing)
        m_Name = name
        m_IsArray = False
        'm_OracleParameter = New OracleParameter()
        'm_OracleParameter.Value = value
        'm_OracleParameter.ParameterName = name
        m_OracleParameter = New OracleParameter(name, value)
        MapIOType(m_OracleParameter, ioType)
        m_ServerType = serverType
        MapServerType(m_OracleParameter, m_ServerType)


    End Sub
    Friend Sub New(ByVal name As String,
                   ByVal value As Object,
                   ByVal ioType As Short)

        m_Name = name
        m_IsArray = False
        'm_OracleParameter = New OracleParameter()
        'm_OracleParameter.Value = value
        'm_OracleParameter.ParameterName = name
        m_OracleParameter = New OracleParameter(name, value)
        MapIOType(m_OracleParameter, ioType)

    End Sub
    Public Sub New()
        'For JSON
        m_OracleParameter = New OracleParameter()

    End Sub

    Private Sub MapIOType(ByRef oracleParam As OracleParameter, ByVal ioType As Short)
        If ioType = ORAPARM_INPUT Then
            oracleParam.Direction = ParameterDirection.Input
        ElseIf ioType = ORAPARM_OUTPUT Then
            oracleParam.Direction = ParameterDirection.Output
        ElseIf ioType = ORAPARM_BOTH Then
            oracleParam.Direction = ParameterDirection.InputOutput
        End If
    End Sub
    Private Sub MapServerType(ByRef oracleParam As OracleParameter, ByVal serverType As Short)
        If serverType = ORATYPE_CHAR Then
            oracleParam.OracleDbType = OracleDbType.Char
        ElseIf serverType = ORATYPE_NUMBER Then
            oracleParam.OracleDbType = OracleDbType.Decimal
        ElseIf serverType = ORATYPE_SINT Then
            oracleParam.OracleDbType = OracleDbType.Single
        ElseIf serverType = ORATYPE_FLOAT Then
            oracleParam.OracleDbType = OracleDbType.Double
        ElseIf serverType = ORATYPE_STRING Then
            oracleParam.OracleDbType = OracleDbType.NVarchar2
        ElseIf serverType = ORATYPE_VARCHAR Then
            oracleParam.OracleDbType = OracleDbType.Varchar2
        ElseIf serverType = ORATYPE_VARCHAR2 Then
            oracleParam.OracleDbType = OracleDbType.Varchar2
        ElseIf serverType = ORATYPE_DATE Then
            oracleParam.OracleDbType = OracleDbType.Date
        ElseIf serverType = ORATYPE_UINT Then
            oracleParam.OracleDbType = OracleDbType.Int32
        ElseIf serverType = ORATYPE_CHAR Then
            oracleParam.OracleDbType = OracleDbType.Char
        ElseIf serverType = ORATYPE_CHARZ Then
            oracleParam.OracleDbType = OracleDbType.NChar
        ElseIf serverType = ORATYPE_CURSOR Then
            oracleParam.OracleDbType = OracleDbType.RefCursor
        End If
    End Sub
    Public Property Name As String
        Get
            Return m_Name

        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property
    Public Property ServerType As Short
        Get
            Return m_ServerType

        End Get
        Set(ByVal value As Short)
            m_ServerType = value
            MapServerType(m_OracleParameter, m_ServerType)
        End Set
    End Property


    Public Property Value As Object
        Get
            'Return m_OracleParameter.Value
            If m_OracleParameter.Value Is Nothing Then
                Return Nothing
            End If
            If m_IsArray Then
                Return CType(m_OracleParameter.Value, Object())
            End If
            'Old system uses
            'If m_ServerType = ORATYPE_NUMBER Then
            '    Return CType(CType(m_OracleParameter.Value, OracleDecimal).Value, Decimal)

            'ElseIf m_ServerType = ORATYPE_CHAR Or m_ServerType = ORATYPE_STRING Then
            '    ' Return CType(CType(m_OracleParameter.Value, OracleString).Value, String)
            '    Return m_OracleParameter.Value 'No Cast more
            'ElseIf m_ServerType = ORATYPE_DATE Then
            '    Return CType(CType(m_OracleParameter.Value, OracleDate).Value, Date)
            'Else
            '    Return m_OracleParameter.Value
            'End If
            If m_OracleParameter.Value Is Nothing Then
                Return m_OracleParameter.Value
            End If
            If m_OracleParameter.Value.GetType().FullName.StartsWith("Oracle.ManagedDataAccess.Types") Then
                'Return m_OracleParameter.Value.Value
                'Advanced: Try to return value with correct type
                If m_ServerType = ORATYPE_NUMBER Then
                    Return CType(m_OracleParameter.Value.Value, Decimal)
                ElseIf m_ServerType = ORATYPE_CHAR Or m_ServerType = ORATYPE_STRING Then
                    Return CType(m_OracleParameter.Value.Value, String)
                ElseIf m_ServerType = ORATYPE_DATE Then
                    Return CType(m_OracleParameter.Value.Value, Date)
                Else
                    Return m_OracleParameter.Value.Value
                End If
            Else
                Return m_OracleParameter.Value
            End If
        End Get
        Set(ByVal value As Object)
            m_OracleParameter.Value = value
            'TEsting with JSON
            'If value IsNot Nothing Then
            '    If value.GetType().Name = "JArray" Then
            '        m_IsArray = True
            '        Dim arrayVal As Newtonsoft.Json.Linq.JArray = CType(value, Newtonsoft.Json.Linq.JArray)
            '        m_ArraySize = arrayVal.Count
            '        m_OracleParameter.Value = New Object() {}
            '        Array.Resize(m_OracleParameter.Value, m_ArraySize)
            '        For i As Integer = 0 To m_ArraySize - 1
            '            Dim jVal As Newtonsoft.Json.Linq.JValue = arrayVal(i)
            '            Put_Value(jVal.Value, i)
            '        Next

            '    End If
            'End If
            m_ValueOrg = value
        End Set
    End Property




    Public Sub Dispose() Implements System.IDisposable.Dispose

        GC.SuppressFinalize(Me)
    End Sub


    Public Sub Put_Value(ByVal value As Object, ByVal index As Integer)
        'Convert of oo4o : https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod145.htm#OOFOL614
        'Inserts values into the table parameter.
        If m_IsArray = False Then
            Throw New Exception("Invalid Array")
        End If

        Dim array() As Object = CType(m_OracleParameter.Value, Object())



        'Check constrain type 
        'If value IsNot Nothing Then
        '    If m_ServerType = ORATYPE_NUMBER Then
        '        If value.GetType().Name = "Int16" Or value.GetType().Name = "Int32" _
        '            Or value.GetType().Name = "Int64" Or value.GetType().Name = "Decimal" _
        '             Or value.GetType().Name = "Double" Or value.GetType().Name = "float" _
        '                                Or value.GetType().Name = "int" Or value.GetType().Name = "long" _
        '            Or value.GetType().Name = "short" Or value.GetType().Name = "Single" _
        '            Or value.GetType().Name = "uint" Or value.GetType().Name = "Uint16" _
        '            Or value.GetType().Name = "Uint32" Or value.GetType().Name = "Uint64" _
        '            Or value.GetType().Name = "ulong" Or value.GetType().Name = "ushort" _
        '            Or value.GetType().Name = "CheckState" Then
        '            array(index) = value
        '        Else
        '            If value.GetType().Name = "DBNull" Then
        '                array(index) = value
        '            Else
        '                Throw New Exception($"{m_Name} is Number,while {value} is string, it must be casted like  Decimal.Parse() or CNumber")
        '                Try
        '                    Dim d = Decimal.Parse(value)
        '                Catch ex As Exception
        '                    Throw New Exception($"{value} is not valid for {m_Name}({index})")
        '                End Try
        '            End If


        '        End If

        '    ElseIf m_ServerType = ORATYPE_CHAR Then
        '        'If value.GetType().Name = "String" Or value.GetType().Name = "Char" Then
        '        '    array(index) = value
        '        'Else
        '        '    Throw New Exception($"{value} is not valid for {m_Name}({index})")
        '        'End If
        '        'CHAR is ok for many types => NO NEED TO CHECK
        '        array(index) = value
        '    ElseIf m_ServerType = ORATYPE_DATE Then
        '        If value.GetType().Name = "DateTime" Then
        '            array(index) = value
        '        Else
        '            Throw New Exception($"{m_Name} is Date,while {value} is string, it must be casted like  CDate(VB6.Format([THE_VARIABLE], ""yyyy-mm-dd""))")
        '            Try
        '                Dim d = Date.Parse(value)
        '            Catch ex As Exception
        '                Throw New Exception($"{value} is not valid for {m_Name}({index})")
        '            End Try

        '        End If

        '    Else
        '        array(index) = value
        '    End If
        'Else
        '    array(index) = value
        'End If

        array(index) = value 
    End Sub

    '<JsonIgnore>
    Friend ReadOnly Property OracleParameter As OracleParameter
        Get
            Return m_OracleParameter

        End Get
    End Property

    Friend ReadOnly Property IsArray As Boolean
        Get
            Return m_IsArray

        End Get
    End Property
    Public ReadOnly Property ArraySize As Integer
        Get
            Return m_ArraySize

        End Get
    End Property

    Friend Sub SetPLSQLAssociativeArray()
        m_OracleParameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray
    End Sub
    Friend ReadOnly Property ValueOrg As Object
        Get
            Return m_ValueOrg

        End Get
    End Property

    Public Sub Remove_At(ByVal index As Integer)
        'Convert of oo4o : https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod145.htm#OOFOL614
        'Inserts values into the table parameter.
        If m_IsArray = False Then
            Throw New Exception("Invalid Array")
        End If

        Dim tmp As Object = New Object() {}
        Array.Resize(tmp, m_ArraySize - 1)

        'Copy value to 
        Dim idx As Integer = 0
        Dim idxNew As Integer = 0
        While idx < Value.Length
            If idx <> index Then
                tmp(idxNew) = Value(idx)
                idxNew = idxNew + 1
            End If
            idx = idx + 1
        End While
        m_ArraySize = m_ArraySize - 1
        m_OracleParameter.Value = tmp
        'ReDim m_OracleParameter.Value(m_ArraySize)


        'Dim array() As Object = CType(m_OracleParameter.Value, Object())
        'array.RemoveAt(index)
    End Sub


End Class
