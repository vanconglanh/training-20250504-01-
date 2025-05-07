Imports Oracle.ManagedDataAccess.Client

Public Class OraSqlStmt
    Private m_OracleConnection As OracleConnection
    Private m_Transaction As OracleTransaction = Nothing
    Private m_OraSession As OraSession
    Private m_ExecuteNonQueryResult As Integer
    Friend Sub New(ByRef con As OracleConnection,
                   ByRef session As OraSession,
                   ByVal executeNonQueryResult As Integer)
        'For future usage, if any
        m_OracleConnection = con
        m_OraSession = session
        m_ExecuteNonQueryResult = executeNonQueryResult

    End Sub

    Public ReadOnly Property ExecuteNonQueryResult As Integer
        Get
            Return m_ExecuteNonQueryResult
        End Get
    End Property

    Public Sub Close()
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/sermthod039.htm#OOFOL475
    End Sub

    Public ReadOnly Property RecordCount As Integer
        'Create this properties as adapter to the projects
        Get
            Return m_ExecuteNonQueryResult
        End Get
    End Property
End Class
