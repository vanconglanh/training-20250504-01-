Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Public Class OraDatabase
    Implements IDisposable

    'Private m_OracleConnection As OracleConnection
    'Private m_Transaction As OracleTransaction = Nothing
    Private m_OraInfoMessageEventHandler As OraInfoMessageEventHandler = Nothing
    Private m_OraSession As OraSession

    Private m_Connect As String
    Private m_Database As String
    'Private m_DynOption As Integer
    Private m_Parameters As OraParameters



    Public Sub StaticInfoMessageEventHandler(ByVal src As Object, ByVal args As OracleInfoMessageEventArgs)
        Dim error1 As OracleInfoMessageEventArgs = args
    End Sub

    Friend Sub New(ByRef session As OraSession, ByVal connect As String, ByVal database As String)
        m_OraSession = session
        'AddHandler m_OracleConnection.InfoMessage,
        'New OracleInfoMessageEventHandler(AddressOf StaticInfoMessageEventHandler)
        'm_OraInfoMessageEventHandler = New OraInfoMessageEventHandler()

        'AddHandler m_OracleConnection.InfoMessage,
        'New OracleInfoMessageEventHandler(AddressOf m_OraInfoMessageEventHandler.Handler)
        'Dim dep As OracleDependency = New OracleDependency()' Only command level
        m_Connect = connect
        m_Database = database
        m_Parameters = New OraParameters()


    End Sub
    Public ReadOnly Property Connect As String
        Get
            'm_oDataBase.Connect
            Return m_Connect

        End Get

    End Property

    Public ReadOnly Property DatabaseName As String
        Get
            'm_oDataBase.DatabaseName
            Return m_Database

        End Get

    End Property
    Public Function CreateDynaset(ByVal sqlStmt As String, ByVal dynOption As Integer) As OraDynaset
        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If

        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Dim dt As DataTable = New DataTable()
        Try
            'm_DynOption = dynOption
            'Using adapter As OracleDataAdapter = New OracleDataAdapter(sqlStmt.Replace(vbCrLf, vbLf), m_OracleConnection) ' Keep adapter for updating
            'Dim adapter As OracleDataAdapter = New OracleDataAdapter(sqlStmt.Replace(vbCrLf, vbLf),
            'm_OraSession.OracleConnection)

            Dim cmd As OracleCommand = New OracleCommand(sqlStmt.Replace(vbCrLf, vbLf), m_OraSession.OracleConnection)

            cmd.InitialLONGFetchSize = -1
            'cmd.AddRowid = True; 


            'Dim adapter As OracleDataAdapter = New OracleDataAdapter(sqlStmt.Replace(vbCrLf, vbLf),
            '                                                       m_OraSession.OracleConnection)

            Dim adapter As OracleDataAdapter = New OracleDataAdapter(cmd)

            adapter.ReturnProviderSpecificTypes = True
            If m_Parameters IsNot Nothing And m_Parameters.Count > 0 Then
                adapter.SelectCommand.Parameters.AddRange(m_Parameters.GetOracleParameters().ToArray())
            End If
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey 'Get Primary Key from Table


            adapter.Fill(dt)
            Return New OraDynaset(dt, adapter, Me, dynOption)

            'Dim ds As DataSet = New DataSet()
            'adapter.Fill(ds)
            'Return New OraDynaset(ds, adapter)
            'End Using

        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function

    Public Function ExecuteSQL(ByVal sqlStmt As String) As Integer
        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If
        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Try
            Using cmd As OracleCommand = m_OraSession.OracleConnection.CreateCommand()
                cmd.CommandText = sqlStmt.Replace(vbCrLf, vbLf)
                If m_Parameters IsNot Nothing And m_Parameters.Count > 0 Then
                    cmd.Parameters.AddRange(m_Parameters.GetOracleParameters().ToArray())
                    If m_Parameters.ArrayBindCount > 0 Then
                        cmd.ArrayBindCount = m_Parameters.ArrayBindCount
                    End If
                    cmd.BindByName = True 'This project always binds parameter by name
                End If
                Return cmd.ExecuteNonQuery()
            End Using
        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function

    Public Sub BeginTrans()
        Try
            m_OraSession.BeginTrans()
        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Sub

    Public Sub CommitTrans()
        Try
            m_OraSession.CommitTrans()
        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Sub

    Public Sub Rollback()
        Try
            m_OraSession.RollBack()
        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Sub



    Public Sub Dispose() Implements System.IDisposable.Dispose

        m_OraSession.Dispose()

        GC.SuppressFinalize(Me)
    End Sub
    Public Sub Close()
        Me.Dispose()
    End Sub

    Public Function DbCreateDynaset(ByVal sqlStmt As String, ByVal dynOption As Integer) As OraDynaset
        Return CreateDynaset(sqlStmt, dynOption)
    End Function

    Public ReadOnly Property LastServerErr As Integer
        Get
            'g_objDataBase.LastServerEr

            'If (m_OraInfoMessageEventHandler.Errors IsNot Nothing) Then
            'Return m_OraInfoMessageEventHandler.Errors(m_OraInfoMessageEventHandler.Errors.Count - 1).Number

            'Else
            'Return 0
            'End If
            If m_OraSession.OracleException IsNot Nothing Then
                Return m_OraSession.OracleException.Errors(m_OraSession.OracleException.Errors.Count - 1).Number
            Else
                Return 0
            End If

        End Get

    End Property

    Public ReadOnly Property LastServerErrText As String
        Get
            'g_objDataBase.LastServerEr
            'If (m_OraInfoMessageEventHandler.Errors IsNot Nothing) Then
            'Return m_OraInfoMessageEventHandler.Errors(m_OraInfoMessageEventHandler.Errors.Count - 1).Message

            'Else
            'Return String.Empty
            'End If
            If m_OraSession.OracleException IsNot Nothing Then
                Return m_OraSession.OracleException.Errors(m_OraSession.OracleException.Errors.Count - 1).Message
            Else
                Return String.Empty
            End If
        End Get

    End Property

    Public ReadOnly Property Session As OraSession
        Get
            Return m_OraSession
        End Get

    End Property

    Public Function DbExecuteSQL(ByVal sqlStmt As String) As Integer
        Return ExecuteSQL(sqlStmt)
    End Function

    'Public ReadOnly Property DynOption As Integer
    '    Get
    '        Return m_DynOption

    '    End Get

    'End Property

    Public Sub LastServerErrReset()
        m_OraSession.OracleException = Nothing
    End Sub
    Public Function CreateSql(ByVal sqlStmt As String, ByVal dynOption As Integer) As OraSqlStmt

        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If
        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Try
            'g_OraDatabase.CreateSql
            'oo4o => https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod066.htm#OOFOL512
            Dim result As Integer
            If dynOption = 0 Then
                'Execute 
                Using cmd As OracleCommand = m_OraSession.OracleConnection.CreateCommand()
                    cmd.CommandText = sqlStmt.Replace(vbCrLf, vbLf)

                    If m_Parameters IsNot Nothing And m_Parameters.Count > 0 Then
                        cmd.Parameters.AddRange(m_Parameters.GetOracleParameters().ToArray())
                        If m_Parameters.ArrayBindCount > 0 Then
                            cmd.ArrayBindCount = m_Parameters.ArrayBindCount
                            For i As Integer = 0 To cmd.Parameters.Count - 1

                                If cmd.Parameters(i) IsNot Nothing Then
                                    For j As Integer = 0 To cmd.Parameters(i).Value.Length - 1
                                        If cmd.Parameters(i).Value(j) Is Nothing Then
                                            cmd.Parameters(i).Value(j) = System.DBNull.Value
                                        End If

                                    Next


                                End If
                            Next
                            For Each param As OracleParameter In cmd.Parameters
                                For Each item As Object In param.Value 'Array
                                    If item Is Nothing Then
                                        item = System.DBNull.Value
                                    End If
                                Next
                            Next
                        End If
                        cmd.BindByName = True 'This project always binds parameter by name

                    End If
                    result = cmd.ExecuteNonQuery()
                End Using
            End If
            Return New OraSqlStmt(m_OraSession.OracleConnection, m_OraSession, result)
        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function

    Public Property Parameters As OraParameters
        Get
            Return m_Parameters

        End Get
        Set(ByVal value As OraParameters)
            m_Parameters = value
        End Set
    End Property

    'Testing or debugging 
    'Public Function GetParametersJSON() As String
    '    Try
    '        Dim strserialize As String = JsonConvert.SerializeObject(m_Parameters)
    '        Return strserialize
    '    Catch ex As OracleException
    '        m_OraSession.KeepLastException(ex)
    '        Throw
    '    End Try

    'End Function

    Public Function GeColumnDefaultValue(ByVal tableName As String) As Dictionary(Of String, Object)
        Dim dicColDefaultValue = New Dictionary(Of String, Object)()

        Dim sqlStmt As String = "
                select col.owner as schema_name,
                       col.table_name,       
                       col.column_name,
                       col.column_id,
                       col.data_default as default_definition
                from sys.all_tab_columns col
                where col.table_name = '" + tableName.ToUpper() + "'"
        Dim adapter As OracleDataAdapter = New OracleDataAdapter(sqlStmt.Replace(vbCrLf, vbLf),
                                                                 m_OraSession.OracleConnection)
        adapter.ReturnProviderSpecificTypes = True

        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey 'Get Primary Key from Table
        adapter.SelectCommand.InitialLONGFetchSize = -1 'Must set this value
        Dim dt As DataTable = New DataTable()

        adapter.Fill(dt)
        'Dim cmd As OracleCommand = New OracleCommand(sqlStmt, m_OraSession.OracleConnection)
        'cmd.InitialLONGFetchSize = -1
        'Dim rows As OracleDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        'If rows.HasRows() Then
        '    While rows.Read()
        '        If rows("DEFAULT_DEFINITION") IsNot Nothing Then
        '            Dim s As Object = rows("DEFAULT_DEFINITION")
        '        End If
        '    End While

        'End If

        For Each row As DataRow In dt.Rows
            If row("DEFAULT_DEFINITION").IsNull Then
                dicColDefaultValue.Add(row("COLUMN_NAME").Value.ToString().ToUpper(), Nothing)
            Else
                dicColDefaultValue.Add(row("COLUMN_NAME").Value.ToString().ToUpper(), row("DEFAULT_DEFINITION").Value)
            End If

        Next

        Return dicColDefaultValue


    End Function

    Public Sub SetDefaultValue(ByVal tableName As String)
        Dim dicColDefaultValue = GeColumnDefaultValue(tableName)
        If m_Parameters.Count > 0 Then
            For index As Integer = 0 To m_Parameters.Count - 1
                Dim paraName = m_Parameters(index).Name.ToUpper()
                paraName = paraName.Replace("_ARR", "")
                If m_Parameters(index).IsArray Then
                    For i As Integer = 0 To m_Parameters(index).ArraySize - 1
                        If m_Parameters(index).Value(i) Is Nothing Then
                            If m_Parameters(index).ServerType = ORATYPE_DATE Then
                                If dicColDefaultValue(paraName) = "SYSDATE" Then
                                    m_Parameters(index).Value(i) = DateTime.Now
                                End If
                            Else
                                m_Parameters(index).Value(i) = dicColDefaultValue(paraName)
                            End If

                        End If
                    Next
                Else
                    If m_Parameters(index).Value Is Nothing Then
                        If m_Parameters(index).ServerType = ORATYPE_DATE Then
                            If dicColDefaultValue(paraName) = "SYSDATE" Then
                                m_Parameters(index).Value = DateTime.Now
                            End If
                        Else
                            m_Parameters(index).Value = dicColDefaultValue(paraName)
                        End If
                    End If
                End If
            Next
        End If

    End Sub

    Public Function CreateDynasetReader(ByVal sqlStmt As String) As OraDynasetReader
        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If
        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Try
            'Use DataReader not Adapter 
            Dim cmd As OracleCommand = New OracleCommand(sqlStmt.Replace(vbCrLf, vbLf), m_OraSession.OracleConnection)

            Dim reader As OracleDataReader = cmd.ExecuteReader()
            Return New OraDynasetReader(reader, Me, 0)

        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function


    ''' <summary>
    ''' Create a reader for LONG RAW ( https://docs.oracle.com/database/121/ODPNT/featData.htm#ODPNT284 )
    ''' </summary>
    ''' <param name="sqlStmt">statement to read LONG RAW column only,  must include ROWID or PRIMARY KEY </param>
    ''' <param name="InitialLONGFetchSize">size of buffer</param>
    ''' <returns></returns>


    Public Function CreateLongRawReader(ByVal sqlStmt As String, ByVal initialLONGFetchSize As Int32) As OraLongRawReader
        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If
        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Try
            'https://docs.oracle.com/database/121/ODPNT/featData.htm#ODPNT284
            Dim cmd As OracleCommand = New OracleCommand(sqlStmt.Replace(vbCrLf, vbLf), m_OraSession.OracleConnection)
            cmd.CommandType = CommandType.Text
            cmd.InitialLONGFetchSize = initialLONGFetchSize
            Dim reader As OracleDataReader = cmd.ExecuteReader()
            Return New OraLongRawReader(reader, Me, 0)

        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function

    Public Function CreateDynasetLongRaw(ByVal sqlStmt As String, ByVal dynOption As Integer) As OraDynaset
        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If
        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Try
            'm_DynOption = dynOption
            'Using adapter As OracleDataAdapter = New OracleDataAdapter(sqlStmt.Replace(vbCrLf, vbLf), m_OracleConnection) ' Keep adapter for updating
            Dim cmd As OracleCommand = New OracleCommand(sqlStmt.Replace(vbCrLf, vbLf), m_OraSession.OracleConnection)

            cmd.InitialLONGFetchSize = -1
            'cmd.AddRowid = True; 


            'Dim adapter As OracleDataAdapter = New OracleDataAdapter(sqlStmt.Replace(vbCrLf, vbLf),
            '                                                       m_OraSession.OracleConnection)

            Dim adapter As OracleDataAdapter = New OracleDataAdapter(cmd)
            adapter.ReturnProviderSpecificTypes = True
            If m_Parameters IsNot Nothing And m_Parameters.Count > 0 Then
                adapter.SelectCommand.Parameters.AddRange(m_Parameters.GetOracleParameters().ToArray())
            End If
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey 'Get Primary Key from Table

            Dim dt As DataTable = New DataTable()
            adapter.Fill(dt)
            Return New OraDynaset(dt, adapter, Me, dynOption)

            'Dim ds As DataSet = New DataSet()
            'adapter.Fill(ds)
            'Return New OraDynaset(ds, adapter)
            'End Using

        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function

    Public Function ExecuteSQLTextWithArrayParameter(ByVal sqlStmt As String) As Integer
        If m_OraSession.OracleConnection Is Nothing Then
            Throw New Exception("There is no connection")
        End If
        '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        m_OraSession.ReConnect()
        '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
        Try
            Using cmd As OracleCommand = m_OraSession.OracleConnection.CreateCommand()
                cmd.CommandText = sqlStmt.Replace(vbCrLf, vbLf)
                cmd.CommandType = CommandType.Text
                If m_Parameters IsNot Nothing And m_Parameters.Count > 0 Then
                    'cmd.Parameters.AddRange(m_Parameters.GetOracleParameters().ToArray())
                    'If m_Parameters.ArrayBindCount > 0 Then
                    '    cmd.ArrayBindCount = m_Parameters.ArrayBindCount
                    'End If
                    'cmd.BindByName = True 'This project always binds parameter by name
                    'For i As Integer = 0 To m_Parameters.Count - 1
                    '    If m_Parameters(i).IsArray Then
                    '        m_Parameters(i).SetPLSQLAssociativeArray()

                    '    End If
                    'Next
                    cmd.BindByName = True 'This project always binds parameter by name
                    For i As Integer = 0 To m_Parameters.Count - 1
                        Dim param As OracleParameter = cmd.Parameters.Add(m_Parameters(i).Name, m_Parameters(i).OracleParameter.OracleDbType)
                        param.Direction = m_Parameters(i).OracleParameter.Direction
                        param.CollectionType = OracleCollectionType.PLSQLAssociativeArray
                        If m_Parameters(i).IsArray Then
                            param.CollectionType = OracleCollectionType.PLSQLAssociativeArray
                        End If

                        'param.Value = m_Parameters(i).ValueOrg
                        param.Value = m_Parameters(i).Value
                    Next


                End If
                Return cmd.ExecuteNonQuery()
            End Using
        Catch ex As OracleException
            m_OraSession.KeepLastException(ex)
            Throw
        End Try

    End Function
End Class
