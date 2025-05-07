Imports System.Globalization
Imports System.Runtime.CompilerServices

Public Module MKOraExtensions
    Private m_sqlInjectBlackList As String() = {"--", ";--", ";", "/*", "*/", "@@",
                                           "@", "char", "nchar", "varchar", "nvarchar", "alter",
                                           "begin", "cast", "create", "cursor", "declare", "delete",
                                           "drop", "end", "exec", "execute", "fetch", "insert",
                                           "kill", "open", "select", "sys", "system", "sysobjects", "syscolumns", "table",
                                           "update"}

    <Extension()>
    Public Function ReplaceSQLInjectionCharacters(ByVal strQuery As String) As String
        If strQuery IsNot Nothing Then
            'https://docs.microsoft.com/en-us/sql/relational-databases/security/sql-injection?view=sql-server-ver15
            Return strQuery.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]").Replace(";", " ")
        End If
        Return strQuery
    End Function

    <Extension()>
    Public Function ContainsSQLInjectionCharacters(ByVal str As String) As Boolean
        If str IsNot Nothing Then
            Dim s As String = str.ToLower()
            For i As Integer = 0 To m_sqlInjectBlackList.Length - 1
                If s.Contains(" " & m_sqlInjectBlackList(i)) Or s.Contains(m_sqlInjectBlackList(i) & " ") Then
                    Return True
                End If
            Next

        End If
        Return False
    End Function
End Module
