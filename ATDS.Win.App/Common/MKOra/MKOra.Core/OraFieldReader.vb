Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types

Public Class OraFieldReader
    Private m_Dynaset As OracleDataReader
    Private m_Name As String
    Private m_Index As Integer
    Private m_OracleDataType As String


    Friend Sub New(ByVal reader As OracleDataReader, ByVal name As String, ByVal index As Integer,
                   ByVal oracleDataType As String
                   )
        m_Dynaset = reader
        m_Name = name
        m_Index = index
        m_OracleDataType = oracleDataType
    End Sub

    Public ReadOnly Property OraIDataType As Short
        Get
            'Map with the old data type which VB.6 is using 
            If m_OracleDataType = "Int16" Or m_OracleDataType = "UInt16" Or m_OracleDataType = "Int32" Or m_OracleDataType = "UInt32" Or m_OracleDataType = "Int64" Or m_OracleDataType = "UInt64" Then
                Return ORATYPE_NUMBER
            ElseIf m_OracleDataType = "Single" Then
                Return ORATYPE_NUMBER
            ElseIf m_OracleDataType = "Double" Then
                Return ORATYPE_NUMBER
            ElseIf m_OracleDataType = "Decimal" Then
                Return ORATYPE_NUMBER
            ElseIf m_OracleDataType = "int" Then
                Return ORATYPE_NUMBER
            ElseIf m_OracleDataType = "String" Then
                Return ORATYPE_CHAR
            ElseIf m_OracleDataType = "Char" Then
                Return ORATYPE_CHAR
            ElseIf m_OracleDataType = "DateTime" Then
                Return ORATYPE_DATE
            ElseIf m_OracleDataType = "Byte[]" Then
                Return ORATYPE_LONG_RAW

            End If
            Throw New Exception("Undefine DataType: " + m_OracleDataType)
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return m_Name
        End Get
    End Property
    Public ReadOnly Property Value As Object
        Get

            Return m_Dynaset(m_Name)

        End Get

    End Property

    'Public ReadOnly Property Type As Short
    '    Get
    '        'To map with SKU580 ( old system uses )
    '        If m_OracleDataType = "Double" Then
    '            Return ORADB_DOUBLE
    '        ElseIf m_OracleDataType = "Decimal" Then
    '            Return ORADB_DOUBLE
    '        ElseIf m_OracleDataType = "String" Or m_OracleDataType = "Char" Then
    '            Return ORADB_TEXT
    '        ElseIf m_OracleDataType = "Int16" Or m_OracleDataType = "UInt16" Then
    '            Return ORADB_SINGLE
    '        ElseIf m_OracleDataType = "Int32" Or m_OracleDataType = "UInt32" Then
    '            Return ORADB_INTEGER
    '        ElseIf m_OracleDataType = "Int64" Or m_OracleDataType = "UInt64" Then
    '            Return ORADB_LONG
    '        ElseIf m_OracleDataType = "Single" Then
    '            Return ORADB_SINGLE
    '        ElseIf m_OracleDataType = "String" Or m_OracleDataType = "Char" Then
    '            Return ORADB_TEXT
    '        ElseIf m_OracleDataType = "Byte" Then
    '            Return ORADB_BYTE
    '        ElseIf m_OracleDataType = "Boolean" Then
    '            Return ORADB_BOOLEAN
    '            'ElseIf m_OracleDataType = "OracleBlob" Then
    '            '    Return ORADB_BYTE
    '        ElseIf m_OracleDataType = "DateTime" Then
    '            Return ORADB_DATE
    '        ElseIf m_OracleDataType = "Byte[]" Then
    '            Return ORADB_LONGBINARY
    '        End If

    '        Throw New Exception("Undefine DataType: " + m_OracleDataType)
    '    End Get
    'End Property


    'Public ReadOnly Property Size As Long
    '    Get

    '        If m_OracleDataType = "String" Then
    '            If Value Is Nothing Then
    '                Return 0
    '            Else
    '                Return Value.ToString().Length
    '            End If
    '        End If

    '    End Get
    'End Property
End Class
