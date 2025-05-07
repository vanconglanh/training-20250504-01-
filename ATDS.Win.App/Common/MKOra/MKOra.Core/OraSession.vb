Option Strict Off
Option Explicit On
Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client

Public Class OraSession
    Implements IDisposable

    Private m_OracleConnection As OracleConnection = Nothing
    Private m_Transaction As OracleTransaction = Nothing
    Private m_OracleException As OracleException = Nothing
    Public Sub New()
    End Sub

    Public Function DbOpenDatabase(ByVal dbname As String, ByVal connect As String, ByVal options As Integer) As OraDatabase
        Try


            Dim arg() As String = connect.Split("/")

            m_OracleConnection = New OracleConnection()
            Dim builder As OracleConnectionStringBuilder = New OracleConnectionStringBuilder()

            'For developing ONLY
            '#If DEBUG Then
            '            Dim settings As OraSetting = New OraSetting()

            '            If settings Is Nothing Then
            '                Throw New Exception("Not found OracleCredentialInSetting.txt in MKOra.Settings")
            '            End If
            '            'If settings.UseSetting = True Then
            '            If settings IsNot Nothing Then
            '                Try

            '                    If settings.Database Is Nothing Then
            '                        Throw New Exception("Not found Database in settings")
            '                    End If
            '                    If settings.UserName Is Nothing Then
            '                        Throw New Exception("Not found UserId in settings")
            '                    End If
            '                    If settings.Password Is Nothing Then
            '                        Throw New Exception("Not found Password in settings")
            '                    End If

            '                    builder.DataSource = settings.Database
            '                    builder.UserID = settings.UserName
            '                    builder.Password = settings.Password
            '                Catch ex As Exception
            '                    Throw
            '                End Try
            '            Else
            '                builder.DataSource = dbname
            '                builder.UserID = arg(0)
            '                builder.Password = arg(1)
            '            End If
            '#Else
            '                          'Use arg, database from registry
            '                        builder.DataSource = dbname
            '                        builder.UserID = arg(0)
            '                        builder.Password = arg(1)
            '#End If


            'Use arg, database from registry as the old system
            'builder.DataSource = dbname
            'TODO: use IP first , will install oracle client later
            'builder.DataSource = "172.16.16.15:1521/" + dbname
            'builder.UserID = arg(0)
            'builder.Password = arg(1)

            'm_OracleConnection.ConnectionString = builder.ConnectionString

            'Use in text setting
            Dim settingPath As String = AppDomain.CurrentDomain.BaseDirectory + "\" + dbname.ToLower() + "connection.txt"
            Dim connectionString As String = System.IO.File.ReadAllText(settingPath)
            m_OracleConnection.ConnectionString = connectionString
            'builder.DataSource = dbname
            'builder.UserID = arg(0)
            'builder.Password = arg(1)
            'm_OracleConnection.ConnectionString = builder.ConnectionString

            '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
            'To fix ORA-03135：接続が失われました
            m_OracleConnection.KeepAlive = True  'https://docs.oracle.com/en/database/oracle/oracle-data-access-components/19.3/odpnt/ConnectionKeepAlive.html#GUID-6C24C49B-5E89-4E62-BEB8-828D3B1B47D7
            '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
            m_OracleConnection.Open()

            '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
            'Fix ORA-03135：接続が失われました
            If m_OracleConnection.State <> ConnectionState.Open Then
                'connection pool returns a disconnected / stale connection
                '=> wait for a little and try to connect
                System.Threading.Thread.Sleep(60000)
                m_OracleConnection.Open()
            End If
            '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
            DbOpenDatabase = New OraDatabase(Me, connect, dbname)
        Catch ex As OracleException
            KeepLastException(ex)
            Throw
        End Try

    End Function
    Public Function OpenDatabase(ByVal dbname As String, ByVal connect As String, ByVal options As Integer) As OraDatabase
        Return DbOpenDatabase(dbname, connect, options)

    End Function

    Friend Sub KeepLastException(ByRef ex As OracleException)
        m_OracleException = ex
        'If m_Transaction IsNot Nothing Then
        '    m_Transaction.Rollback()
        '    m_Transaction = Nothing
        'End If
    End Sub
    'Public Function DbOpenDatabase(ByVal dbname As String, ByVal userId As String, ByVal password As String) As OraDatabase

    '    m_OracleConnection = New OracleConnection()
    '    Dim builder As OracleConnectionStringBuilder = New OracleConnectionStringBuilder()
    '    builder.DataSource = dbname
    '    builder.UserID = userId
    '    builder.Password = password

    '    'con.ConnectionString = builder.ConnectionString
    '    'con.Open()
    '    'DbOpenDatabase = New OraDatabase(con)
    '    m_OracleConnection.ConnectionString = builder.ConnectionString
    '    m_OracleConnection.Open()
    '    DbOpenDatabase = New OraDatabase(m_OracleConnection, Me)
    'End Function
    Public Sub DbBeginTrans()
        'g_objSession.DbBeginTrans()
        Try
            m_Transaction = m_OracleConnection.BeginTransaction()
        Catch ex As OracleException
            KeepLastException(ex)
            Throw
        End Try

    End Sub
    Public Sub BeginTrans()
        DbBeginTrans()
    End Sub



    ''' <summary>
    ''' Make method DbCommitTrans to follow the existing code
    ''' </summary>
    Public Sub DbCommitTrans()
        Try
            'g_objSession.DbCommitTrans() 
            m_Transaction.Commit()
            ResetTrans()
        Catch ex As OracleException
            KeepLastException(ex)
            Throw
        End Try

    End Sub
    Public Sub CommitTrans()
        DbCommitTrans()
    End Sub

    ''' <summary>
    ''' Make method DbRollBack to follow the existing code
    ''' </summary>
    Public Sub DbRollBack()
        'g_objSession.DbRollBack()
        Try
            If m_Transaction IsNot Nothing Then
                m_Transaction.Rollback()
                ResetTrans()
            End If

        Catch ex As OracleException
            KeepLastException(ex)
            Throw
        End Try

    End Sub

    Public Sub RollBack()
        DbRollBack()
    End Sub

    Public Sub ResetTrans()
        If m_Transaction IsNot Nothing Then
            m_Transaction.Dispose()
            m_Transaction = Nothing
        End If
    End Sub


    Friend Property OracleException As OracleException
        Get
            Return m_OracleException

        End Get
        Set(ByVal value As OracleException)
            m_OracleException = value
        End Set

    End Property

    Public ReadOnly Property OracleConnection As OracleConnection
        Get
            Return m_OracleConnection

        End Get

    End Property
    Public Sub Dispose() Implements System.IDisposable.Dispose

        If m_OracleConnection IsNot Nothing Then
            m_OracleConnection.Dispose()
            m_OracleConnection = Nothing
        End If

        GC.SuppressFinalize(Me)
    End Sub

    '++修正　2020年12月24:Unitec（手）-  VB→VB.NET変換
    Public ReadOnly Property HasTransaction() As Boolean
        Get
            If m_Transaction Is Nothing Then
                Return False
            Else
                Return True
            End If

        End Get
    End Property
    '--修正　2020年12月24:Unitec（手）-  VB→VB.NET変換

    Public Function IsAlive() As Boolean
        If m_OracleConnection IsNot Nothing Then
            Return True
        Else
            Return False
        End If

    End Function

    '++修正開始　2023年04月19日:MK（手）- VB→VB.NET変換
    Public Sub ReConnect()
        'To fix ORA-03135：接続が失われました
        If m_OracleConnection IsNot Nothing Then
            Try

                If m_OracleConnection.State <> ConnectionState.Open Then
                    'connection pool returns a disconnected / stale connection
                    '=> wait for a little and try to connect
                    System.Threading.Thread.Sleep(60000)
                    m_OracleConnection.Open()
                End If
            Catch ex As Exception
                KeepLastException(ex)
                Throw
            End Try
        End If
    End Sub
    '--修正開始　2023年04月19日:MK（手）- VB→VB.NET変換

End Class
