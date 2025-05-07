Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types

Public Class OraField
    Private m_Dynaset As OraDynaset
    Private m_Name As String
    Private m_Index As Integer
    Private m_OracleDataType As String


    Friend Sub New(ByVal dyn As OraDynaset, ByVal name As String, ByVal index As Integer,
                   ByVal oracleDataType As String
                   )
        m_Dynaset = dyn
        m_Name = name
        m_Index = index
        m_OracleDataType = oracleDataType
    End Sub

    Public ReadOnly Property OraIDataType As Short
        Get
            'ORATYPE_NUMBER,ORATYPE_STRING,.. are defined in old system => Must follow 
            'https://docs.oracle.com/cd/E48297_01/doc/win.121/e41125/intro003.htm
            If m_OracleDataType = "OracleDecimal" Then
                Return ORATYPE_NUMBER
            ElseIf m_OracleDataType = "OracleString" Then
                Return ORATYPE_CHAR
            ElseIf m_OracleDataType = "OracleDate" Then
                Return ORATYPE_DATE
            ElseIf m_OracleDataType = "OracleBinary" Then
                Return ORATYPE_BINARY
            End If
            Throw New Exception("Undefine DataType")
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return m_Name
        End Get
    End Property
    Public Property Value As Object
        Get
            If m_Dynaset.CurrentRow Is Nothing Then
                Return Nothing
            End If
            'Old system uses
            If OraIDataType = ORATYPE_NUMBER Then
                If IsDBNull(m_Dynaset.CurrentRow.ItemArray(m_Index)) Then
                    Return Nothing
                ElseIf m_Dynaset.CurrentRow.ItemArray(m_Index).IsNull Then
                    Return Nothing
                Else
                    Return CType(CType(m_Dynaset.CurrentRow(m_Index), OracleDecimal).Value, Decimal)
                End If

            ElseIf OraIDataType = ORATYPE_CHAR Then
                If m_Dynaset.CurrentRow.ItemArray(m_Index).IsNull Then
                    'Return Nothing
                    Return vbNullString
                Else
                    Return CType(CType(m_Dynaset.CurrentRow(m_Index), OracleString).Value, String)
                End If

            ElseIf OraIDataType = ORATYPE_DATE Then
                If m_Dynaset.CurrentRow.ItemArray(m_Index).IsNull Then
                    Return Nothing
                Else
                    Return CType(CType(m_Dynaset.CurrentRow(m_Index), OracleDate).Value, Date)
                End If
            ElseIf OraIDataType = ORATYPE_BINARY Then
                'If m_Dynaset.CurrentRow.ItemArray(m_Index).IsNull Then
                If IsDBNull(m_Dynaset.CurrentRow.ItemArray(m_Index)) Then
                    Return Nothing
                Else
                    Try
                        If m_Dynaset.CurrentRow.ItemArray(m_Index).IsNull Then
                            Return Nothing
                        End If
                    Catch ex As Exception
                        Return CType(CType(m_Dynaset.CurrentRow(m_Index), OracleBinary).Value, Byte())
                    End Try
                    Return CType(CType(m_Dynaset.CurrentRow(m_Index), OracleBinary).Value, Byte())
                End If
            Else
                Return m_Dynaset.CurrentRow(m_Index).Value
            End If
        End Get
        Set(ByVal value As Object)
            If m_Dynaset.CurrentRow Is Nothing Then
                Return
            End If
            If m_Dynaset.DynOption = ORADYN_READONLY Then
                Throw New Exception($"{Name} is read only.")
            End If
            If value Is System.DBNull.Value Then
                m_Dynaset.CurrentRow(m_Index) = System.DBNull.Value
            Else
                'Old system uses
                If OraIDataType = ORATYPE_NUMBER Then
                    If value IsNot Nothing AndAlso value.GetType().ToString() = "System.String" AndAlso value = "" Then
                        'm_Dynaset.CurrentRow(m_Index) = New OracleDecimal(CType(value, Decimal)) 'Not process
                        'm_Dynaset.CurrentRow(m_Index) = New OracleDecimal()
                        m_Dynaset.CurrentRow(m_Index) = DBNull.Value
                    Else
                        m_Dynaset.CurrentRow(m_Index) = New OracleDecimal(CType(value, Decimal))
                    End If

                ElseIf OraIDataType = ORATYPE_CHAR Then
                    m_Dynaset.CurrentRow(m_Index) = New OracleString(CType(value, String))
                ElseIf OraIDataType = ORATYPE_DATE Then

                    If value IsNot Nothing AndAlso value.GetType().ToString() = "System.String" AndAlso value = "" Then
                        m_Dynaset.CurrentRow(m_Index) = DBNull.Value
                    Else
                        m_Dynaset.CurrentRow(m_Index) = New OracleDate(CType(value, DateTime))
                    End If

                ElseIf OraIDataType = ORATYPE_BINARY Then
                    m_Dynaset.CurrentRow(m_Index) = New OracleBinary(CType(value, Byte()))
                Else
                    m_Dynaset.CurrentRow(m_Index).Value = value
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property Type As Short
        Get
            'To map with SKU700
            'ORATYPE_NUMBER,ORATYPE_STRING,.. are defined in old system => Must follow 
            'https://docs.oracle.com/cd/E48297_01/doc/win.121/e41125/intro003.htm
            If m_OracleDataType = "OracleDecimal" Then
                Return ORADB_DOUBLE
            ElseIf m_OracleDataType = "OracleString" Then
                Return ORADB_TEXT
            ElseIf m_OracleDataType = "OracleBinary" Then
                Return ORADB_BYTE
            ElseIf m_OracleDataType = "OracleBoolean" Then
                Return ORADB_BOOLEAN
                'ElseIf m_OracleDataType = "OracleBlob" Then
                '    Return ORADB_BYTE
            ElseIf m_OracleDataType = "OracleDate" Then
                Return ORADB_DATE
            End If

            Throw New Exception("Undefine DataType")
        End Get
    End Property

    Public ReadOnly Property Size As Long
        Get
            'USed in SKU700
            'https://docs.oracle.com/cd/E11882_01/win.112/e17727/serprop118.htm#OOFOL782

            If m_OracleDataType = "OracleString" Then
                If Value Is Nothing Then
                    Return 0
                Else
                    Return Value.ToString().Length
                End If
            End If

        End Get
    End Property
    Public ReadOnly Property FieldSize As Long
        Get
            'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod090.htm#OOFOL551

            If m_OracleDataType = "OracleBinary" Then
                If Value Is Nothing Then
                    Return 0
                Else
                    If IsDBNull(Value) Then
                        Return 0
                    End If
                    Dim byteArrValue = CType(Value, Byte())

                    If byteArrValue.Length > 65536 Then
                        Return -1
                    Else
                        Return byteArrValue.Length
                    End If
                End If
            End If

        End Get
    End Property

    'Public Function GetChunkByte(ByVal offset As Long, ByVal numbytes As Long) As String
    '    'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod096.htm#OOFOL557
    '    'TODO
    '    Try
    '        If m_OracleDataType = "OracleBinary" Then
    '            If Value Is Nothing Then
    '                Return Nothing
    '            Else
    '                Return Encoding.UTF8.GetString(Value, offset, numbytes)
    '            End If
    '        Else
    '            Throw New Exception("Undefine DataType")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return Nothing
    'End Function

    Public Function GetChunkByte(ByVal bytes() As Byte, ByVal offset As Long, ByVal chunkSize As Long) As Double
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod095.htm#OOFOL556
        'TODO
        Try
            If m_OracleDataType = "OracleBinary" Then
                If Value Is Nothing Then
                    Return 0
                Else
                    Dim byteArrValue = CType(Value, Byte())
                    If offset + chunkSize > byteArrValue.Length Then
                        'Reach the last chunk
                        Array.Copy(Value, offset, bytes, 0, byteArrValue.Length - offset)
                        Return byteArrValue.Length - offset
                    Else
                        Array.Copy(Value, offset, bytes, 0, chunkSize)
                        Return chunkSize
                    End If

                End If
            End If
            Throw New Exception("Undefine DataType")
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function
    Public Function DbGetChunkByte(ByVal bytes() As Byte, ByVal offset As Long, ByVal chunkSize As Long) As Double
        Return GetChunkByte(bytes, offset, chunkSize)
    End Function

    Public Sub AppendChunkByte(ByVal bytes() As Byte, ByVal size As Long)
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod095.htm#OOFOL556
        Try
            If m_OracleDataType = "OracleBinary" Then
                If Value Is Nothing Then 'The first time
                    Dim byteArrValue() As Byte
                    ReDim byteArrValue(size - 1)
                    Array.Copy(bytes, 0, byteArrValue, 0, size)
                    Value = byteArrValue
                Else
                    Dim byteArrValue() As Byte
                    byteArrValue = CType(Value, Byte())

                    Dim newByteArrValue() As Byte
                    ReDim newByteArrValue(byteArrValue.Length + size - 1)
                    Array.Copy(byteArrValue, 0, newByteArrValue, 0, byteArrValue.Length)
                    Array.Copy(bytes, 0, newByteArrValue, byteArrValue.Length, size)
                    Value = newByteArrValue
                End If
            Else
                Throw New Exception("Undefine DataType")
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DbAppendChunkByte(ByVal bytes() As Byte, ByVal size As Long)
        AppendChunkByte(bytes, size)
    End Sub

End Class
