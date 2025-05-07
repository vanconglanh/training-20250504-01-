Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MKOra.Core
<TestClass()> Public Class OraDynasetReaderTest



    <TestMethod()> Public Sub Reader_Huge_Data_OK()

        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim DateArray() As Object
        Dim i As Integer
        Dim countItem As Integer = 2
        Dim reader As OraDynasetReader
        Try
            Dim sql As String = "Select * From SKFD12 Where(D12100, D12110) In (Select D10110,D10120 from skfd10 where D10240 <= '2018/09/30')"

            reader = OraDatabase.CreateDynasetReader(sql)

            Assert.IsNotNull(reader("D12050").Value)

            Assert.IsNotNull(reader.Fields("D12050").Value)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
        End Try


    End Sub
End Class