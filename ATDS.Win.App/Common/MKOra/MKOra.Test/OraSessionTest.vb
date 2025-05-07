Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MKOra.Core

<TestClass()> Public Class OraSessionTest

    <TestMethod()> Public Sub DbOpenDatabase_OK()

        Dim database = New TestingFactory().CreateDatabase()
        Assert.IsNotNull(database)
    End Sub

End Class