Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MKOra.Core

Public Class TestingFactory
    Public Function CreateDatabase() As OraDatabase

        Dim session = New OraSession()
        'To make it more secured, copy text file "OracleCredentialInSetting.txt" to bin directory when running test
        Dim database = session.DbOpenDatabase("MK", "MK/MK", 0)
        CreateDatabase = database
    End Function
End Class
