Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MKOra.Core

<TestClass()> Public Class DBUtilsTest

    <TestMethod()> Public Sub IsDbNull_OK()
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            strSQL = "SELECT MSG120,MSG130,MSG140,MSG150,MSG160 FROM SKERRMSG WHERE MSG100 = 'D' AND MSG110 = '014'"

            Dim g_objDyna As OraDynaset
            database.Session.BeginTrans()


            g_objDyna = database.CreateDynaset(strSQL, 0)
            Dim isNull As Boolean = DBUtils.IsDBNull(g_objDyna(1).Value)

            Assert.IsTrue(Not isNull)
            Dim msg140 As String
            'msg140 = g_objDyna(2).Value
            'isNull = DBUtils.IsDBNull(msg140)
            'Assert.IsTrue(isNull)
            isNull = DBUtils.IsDBNull(g_objDyna(2).Value)
            Assert.IsTrue(isNull)

        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try
    End Sub

    <TestMethod()> Public Sub IsDbNull_Simple_OK()
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim str1 As String
            Assert.IsTrue(DBUtils.IsDBNull(str1))

            str1 = "Hello"
            Assert.IsTrue(Not DBUtils.IsDBNull(str1))

            Dim n1 As Decimal
            Assert.IsTrue(Not DBUtils.IsDBNull(n1))

            'Nullable type
            Dim b1 As Boolean?
            Assert.IsTrue(DBUtils.IsDBNull(b1))


        Catch ex As Exception
            Throw
        Finally
        End Try
    End Sub

    <TestMethod()> Public Sub IsDbNull_From_DataBase_OK()
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            strSQL = "SELECT  * From SKFA10 WHERE A10530 IS NULL and RowNum = 1 "


            strSQL = strSQL & "FOR UPDATE"
            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.AreEqual(1, objDyna.RecordCount)
            Assert.IsTrue(Not DBUtils.IsDBNull(objDyna("A10100")))
            Assert.IsTrue(Not DBUtils.IsDBNull(objDyna("A10100").Value))

            Assert.IsTrue(DBUtils.IsDBNull(objDyna("A10530"))) 'Number

            Assert.IsTrue(DBUtils.IsDBNull(objDyna("A10A00"))) 'CHAR

        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try

    End Sub

    <TestMethod()> Public Sub IsDbNull_From_DataBase_Empty_Dynset_OK()
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            strSQL = "SELECT A10J00,A10J10 FROM SKFA10 WHERE A10100 = '㈱三鮮商事　伊東広野店        '"


            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.AreEqual(0, objDyna.RecordCount)
            Assert.IsTrue(DBUtils.IsDBNull(objDyna("A10J00")))



        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try

    End Sub
    <TestMethod()> Public Sub For_Next_OK()
        Dim GyoCnt As Integer
        For GyoCnt = 1 To 99

        Next GyoCnt
        Assert.AreEqual(GyoCnt, 100)



    End Sub
End Class