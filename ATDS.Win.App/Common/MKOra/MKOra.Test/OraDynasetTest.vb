Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MKOra.Core
<TestClass()> Public Class OraDynasetTest

    <TestMethod()> Public Sub AddNew_OK()

        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, 10, 50)
            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For I = 0 To 9
                achar = "Description" + Str(I)
                PartNoArray(I) = 1000 + I
                DescArray(I) = achar
            Next I
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)

            Assert.AreEqual(10, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos FOR UPDATE ", 0)

            'Add new

            objDynaset.AddNew()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            objDynaset("partno").Value = 1100D
            objDynaset("description").Value = "Description 11"
            objDynaset.Update()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, 11)



        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Update_Table_Has_Key_OK()

        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, 10, 50)
            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For I = 0 To 9
                achar = "Description" + Str(I)
                PartNoArray(I) = 1000 + I
                DescArray(I) = achar
            Next I
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)
            Assert.AreEqual(10, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos FOR UPDATE ", 0)

            'Update new

            objDynaset.Edit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            'Update the first record 
            objDynaset("description").Value = "Description -1000"
            objDynaset.Update()

            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, 10)

            Assert.AreEqual("Description -1000", CType(objDynaset2("description").Value, String).Trim())



        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            'Drop the table 
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Update_Table_Has_No_Key_Use_RowID_OK()

        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, 10, 50)
            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For I = 0 To 9
                achar = "Description" + Str(I)
                PartNoArray(I) = 1000 + I
                DescArray(I) = achar
            Next I
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)
            Assert.AreEqual(10, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description ,ROWIDTONCHAR(ROWID) ""ROWID""  FROM part_nos FOR UPDATE ", 0)

            'Update new

            objDynaset.Edit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            'Update the first record 
            objDynaset("description").Value = "Description -1000"
            objDynaset.Update() 'Update the first rown 

            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, 10)

            Assert.AreEqual("Description -1000", CType(objDynaset2("description").Value, String).Trim())

            'Check other records, make sure them are not updated
            For I = 1 To 9
                objDynaset2.MoveNext()
                Assert.AreEqual("Description" + Str(I), CType(objDynaset2("description").Value, String).Trim())
            Next I
        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            'Drop the table 
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub AddNew_UpdateWithoutKey_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            strSQL = "SELECT Z20100, Z20110, Z20120, Z20130, Z20140, Z20150, " & "Z20160, Z20163, Z20165, Z20170, Z20180, Z20190, Z20200, " & "Z20300, Z20310, " & "Z20320, Z20330, Z20340, Z20350, Z20360, Z20370, Z20380, Z20390, Z20400, " & "Z20210, Z20220 " & "FROM SKFZ20 "


            strSQL = strSQL & "FOR UPDATE"
            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)
            objDyna.AddNew()
            objDyna("Z20100").Value = -100D
            objDyna.Update()
            Dim objDyna2 As OraDynaset = database.CreateDynaset(strSQL, 0)
            Assert.AreEqual(objDyna.RecordCount, objDyna2.RecordCount)


        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try



    End Sub

    <TestMethod()> Public Sub Check_Primary_Key_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            strSQL = "SELECT A10100, A10110, A10120, A10130 FROM SKFA10 where rownum = 1 "


            strSQL = strSQL & "FOR UPDATE"
            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)
            Assert.IsTrue(objDyna.HasPrimaryKey)


        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try



    End Sub
    <TestMethod()> Public Sub Check_ReadOnly_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Dim expectedEx As System.Exception
        Try
            Dim strSQL As String

            strSQL = "SELECT A10100, A10110, A10120, A10130 FROM SKFA10 where rownum = 1 "


            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 4)
            Assert.IsNotNull(objDyna)
            Assert.IsTrue(objDyna.HasPrimaryKey)
            'Try to update primary key
            objDyna("A10110").Value = 9999

        Catch ex As Exception
            expectedEx = ex
        Finally
            Assert.AreEqual(expectedEx.Message, "A10110 is read only.")
            database.Session.RollBack()
        End Try



    End Sub

    <TestMethod()> Public Sub Ref_ReadOnly_Error_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Dim expectedEx As System.Exception
        Try
            Dim strSQL As String

            strSQL = "SELECT B30110,B30140,B30500,J20120,B30330,B30210,CstName
                    ,B30B00 
                    ,B30C00,B30C10, B30C20 ,B30C30 
                      FROM
                          (SELECT B30110,B30140,B30500,J20120,B30330,B30210,B30B00,
                                  B30C00, B30C10, B30C20, B30C30, 
                                  ConCat(ConCat(B30100,B30110),B30140) Key
                             FROM Skfb30,Skfj20
                            WHERE B30100 = '00144'
                              AND B30150 = '2020/02/01'
                              AND B30210 <= '2020/07/22'          AND B30160 = 2 AND B30110 = J20100
                     and B30C00=4 
                          ) SKFB30,
                          (SELECT DECODE( E10100,2,A10140,3,'倉庫移動',6,'製造受入',9,A10140,10,'製品受入',14,A10140,91,'ユーティリティ',99,'棚卸調整') CstName,
                                  ConCat(ConCat(E10140,E10150),E10180) Key
                             FROM SKFE10,SKFA10
                            WHERE E10140 = '00144'
                              AND E10100 in (2,3,9,6,10,14,91) AND E10300 = 0
                              AND E10130 = A10100(+)
                            Group By e10100,a10140,e10140,e10150,e10180,A10140
                          ) SKFE10
                     WHERE SKFB30.Key = SKFE10.Key(+)
                     and ROWNUM=1
                    ORDER BY  B30110 ASC,B30210 ASC,B30140 ASC,B30B00 ASC "


            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)
            Try
                'objDyna("B30140").Value = "9999999"
                RefStr(objDyna("B30140").Value) 'Exception here:  Column 'B30140' is read only
            Catch ex1 As Exception
                expectedEx = ex1
            Finally
                Assert.AreEqual(expectedEx.Message, "Column 'B30140' is read only.")
            End Try

            Try
                'objDyna("B30140").Value = "9999999"
                Dim str As String = objDyna("B30140").Value
                RefStr(str) 'NO Exception 
                expectedEx = Nothing
            Catch ex1 As Exception
                expectedEx = ex1
            Finally
                Assert.IsNull(expectedEx)
            End Try

        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try



    End Sub

    Private Sub RefStr(ByRef str As String)
    End Sub
    <TestMethod()> Public Sub AddNew_Without_Column_Default_OK()

        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim OraPArray() As Object
        Dim i As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table Table_Test_01(" &
                         "D11140 DATE,D11100 NUMBER(10,0) DEFAULT 0,D11110 NUMBER(3,0) DEFAULT 0,D11130 NUMBER(1,0) DEFAULT 0, D11820 DATE, D11F31 NUMBER(12,3) DEFAULT 0, PRIMARY KEY (D11140, D11100, D11110, D11130))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("D11140_ARR", ORAPARM_INPUT, ORATYPE_DATE, 1, 0)
            OraDatabase.Parameters.AddTable("D11100_ARR", ORAPARM_INPUT,
                                    ORATYPE_NUMBER, 1, 0)
            OraDatabase.Parameters.AddTable("D11110_ARR", ORAPARM_INPUT,
                                    ORATYPE_NUMBER, 1, 0)
            OraDatabase.Parameters.AddTable("D11130_ARR", ORAPARM_INPUT,
                                    ORATYPE_NUMBER, 1, 0)
            OraDatabase.Parameters.AddTable("D11820_ARR", ORAPARM_INPUT,
                                    ORATYPE_DATE, 1, 0)
            'OraDatabase.Parameters.AddTable("D11F31_ARR", ORAPARM_INPUT,ORATYPE_NUMBER, 1, 0)
            '
            ReDim OraPArray(6)
            OraPArray(0) = OraDatabase.Parameters("D11140_ARR")
            OraPArray(1) = OraDatabase.Parameters("D11100_ARR")
            OraPArray(2) = OraDatabase.Parameters("D11110_ARR")
            OraPArray(3) = OraDatabase.Parameters("D11130_ARR")
            OraPArray(4) = OraDatabase.Parameters("D11820_ARR")
            'OraPArray(5) = OraDatabase.Parameters("D11F31_ARR")

            Dim date1 = New Date(2020, 6, 20)
            Dim date2 = Date.Today

            OraPArray(0).Put_Value(date1, 0)
            OraPArray(1).Put_Value(2757497, 0)
            OraPArray(2).Put_Value(1, 0)
            OraPArray(3).Put_Value(0, 0)
            OraPArray(4).Put_Value(date2, 0)
            'OraPArray(5).Put_Value(0, 0)'Let default value 



            'result = OraDatabase.CreateSql("insert into Table_Test_01(D11140, D11100,D11110,D11130,D11820,D11F31) values(:D11140_ARR, :D11100_ARR,:D11110_ARR,:D11130_ARR,:D11820_ARR,:D11F31_ARR)", 0&)
            result = OraDatabase.CreateSql("insert into Table_Test_01(D11140, D11100,D11110,D11130,D11820) values(:D11140_ARR, :D11100_ARR,:D11110_ARR,:D11130_ARR,:D11820_ARR)", 0&) ' Not include the column then the column will be default

            Assert.AreEqual(1, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT D11140, D11100,D11110,D11130,D11820,D11F31 FROM Table_Test_01 ", 0)
            Assert.AreEqual(1, objDynaset.RecordCount)
            Assert.AreEqual(0D, objDynaset("D11F31").Value) 'The default value 

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table Table_Test_01")
            OraDatabase.Rollback()
        End Try


    End Sub
    <TestMethod()> Public Sub AddNew_With_Column_Default_OK()

        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim OraPArray() As Object
        Dim i As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table Table_Test_01(" &
                         "D11140 DATE,D11100 NUMBER(10,0) DEFAULT 0,D11110 NUMBER(3,0) DEFAULT 0,D11130 NUMBER(1,0) DEFAULT 0, D11820 DATE DEFAULT SYSDATE, D11F31 NUMBER(12,3) DEFAULT 0, PRIMARY KEY (D11140, D11100, D11110, D11130))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("D11140_ARR", ORAPARM_INPUT, ORATYPE_DATE, 1, 0)
            OraDatabase.Parameters.AddTable("D11100_ARR", ORAPARM_INPUT,
                                    ORATYPE_NUMBER, 1, 0)
            OraDatabase.Parameters.AddTable("D11110_ARR", ORAPARM_INPUT,
                                    ORATYPE_NUMBER, 1, 0)
            OraDatabase.Parameters.AddTable("D11130_ARR", ORAPARM_INPUT,
                                    ORATYPE_NUMBER, 1, 0)
            OraDatabase.Parameters.AddTable("D11820_ARR", ORAPARM_INPUT,
                                    ORATYPE_DATE, 1, 0)
            OraDatabase.Parameters.AddTable("D11F31_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, 1, 0)

            ReDim OraPArray(6)
            OraPArray(0) = OraDatabase.Parameters("D11140_ARR")
            OraPArray(1) = OraDatabase.Parameters("D11100_ARR")
            OraPArray(2) = OraDatabase.Parameters("D11110_ARR")
            OraPArray(3) = OraDatabase.Parameters("D11130_ARR")
            OraPArray(4) = OraDatabase.Parameters("D11820_ARR")
            OraPArray(5) = OraDatabase.Parameters("D11F31_ARR")

            Dim date1 = New Date(2020, 6, 20)
            Dim date2 = Date.Today

            OraPArray(0).Put_Value(date1, 0)
            OraPArray(1).Put_Value(2757497, 0)
            OraPArray(2).Put_Value(1, 0)
            OraPArray(3).Put_Value(0, 0)
            'OraPArray(4).Put_Value(date2, 0)'Let default value 
            'OraPArray(5).Put_Value(0, 0)'Let default value 



            Dim dicColDefaultValue = OraDatabase.GeColumnDefaultValue("Table_Test_01")
            OraDatabase.SetDefaultValue("Table_Test_01")
            result = OraDatabase.CreateSql("insert into Table_Test_01(D11140, D11100,D11110,D11130,D11820,D11F31) values(:D11140_ARR, :D11100_ARR,:D11110_ARR,:D11130_ARR,:D11820_ARR,:D11F31_ARR)", 0&)

            Assert.AreEqual(1, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT D11140, D11100,D11110,D11130,D11820,D11F31 FROM Table_Test_01 ", 0)
            Assert.AreEqual(1, objDynaset.RecordCount)
            Assert.AreEqual(0D, objDynaset("D11F31").Value) 'The default value 

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table Table_Test_01")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub AddNew_UpdateWithoutSelectingKey_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            'strSQL = "SELECT J50Z10,J50Z20,J50Z30 FROM SKFJ50 WHERE J50100 = 'L1' "
            'strSQL = "SELECT J50Z10,J50Z20,J50Z30,J50100 FROM SKFJ50 WHERE J50100 = 'L1' " '=> Need to select column Key J50100 to enable ODP.NET update ( OR_015 )
            strSQL = "SELECT J50Z10,J50Z20,J50Z30,J50100 FROM SKFJ50 WHERE ROWNUM = 1" '=> Need to select column Key J50100 to enable ODP.NET update ( OR_015 )  ( Select a row to test, not L1 )

            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)
            objDyna.DbEdit()
            objDyna("J50Z10").Value = Today
            objDyna.Update()


        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try



    End Sub

    <TestMethod()> Public Sub Sytem_Db_Null_OK()

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
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50),DateCol Date, primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, countItem, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, countItem, 50)
            OraDatabase.Parameters.AddTable("DATECOL", ORAPARM_INPUT,
                                    ORATYPE_DATE, countItem, 50)

            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value
            DateArray = OraDatabase.Parameters("DATECOL").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For i = 0 To countItem - 1
                achar = "Description" + Str(i)
                PartNoArray(i) = 1000 + i
                DescArray(i) = achar
            Next i
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)

            Assert.AreEqual(countItem, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description,DateCol FROM part_nos FOR UPDATE ", 0)

            'Add new

            objDynaset.AddNew()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            objDynaset("partno").Value = 1100D
            objDynaset("description").Value = System.DBNull.Value
            objDynaset("DateCol").Value = System.DBNull.Value
            objDynaset.Update()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description,DateCol FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, countItem + 1)
            'Check null 
            Dim objDynaset3 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description,DateCol FROM part_nos WHERE partno=1100", 0)
            Assert.IsNull(objDynaset3("description").Value)
            Assert.IsTrue(DBUtils.IsDBNull(objDynaset3("description")))
            Assert.IsTrue(DBUtils.IsDBNull(objDynaset3("DateCol")))
        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Delete_OK()

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
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, countItem, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, countItem, 50)


            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For i = 0 To countItem - 1
                achar = "Description" + Str(i)
                PartNoArray(i) = 1000 + i
                DescArray(i) = achar
            Next i
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)

            Assert.AreEqual(countItem, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos ", 0)

            'Add new

            objDynaset.DbEdit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            objDynaset.DbDelete()

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, countItem - 1)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Delete_Then_Insert_No_Exception()

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
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, countItem, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, countItem, 50)


            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For i = 0 To countItem - 1
                achar = "Description" + Str(i)
                PartNoArray(i) = 1000 + i
                DescArray(i) = achar
            Next i
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)

            Assert.AreEqual(countItem, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos ", 0)

            'Add new

            'objDynaset.DbEdit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            objDynaset.DbDelete()

            'Try to insert data which has been deleted
            Dim PartNoArray2() As Object
            Dim DescArray2() As Object
            OraDatabase.Parameters = New OraParameters()
            OraDatabase.Parameters.AddTable("PARTNO2", ORAPARM_INPUT, ORATYPE_NUMBER, 1, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION2", ORAPARM_INPUT,
                                    ORATYPE_CHAR, 1, 50)


            PartNoArray2 = OraDatabase.Parameters("PARTNO2").Value
            DescArray2 = OraDatabase.Parameters("DESCRIPTION2").Value
            PartNoArray2(0) = 1000
            DescArray2(0) = "TEST"

            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO2,:DESCRIPTION2)", 0&)

            'Try to select
            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, countItem)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub
    <ExpectedException(GetType(System.Data.ConstraintException))>
    <TestMethod()> Public Sub Select_Then_Delete_Then_Insert_Exception()

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
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, countItem, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, countItem, 50)


            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For i = 0 To countItem - 1
                achar = "Description" + Str(i)
                PartNoArray(i) = 1000 + i
                DescArray(i) = achar
            Next i

            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)
            Dim dataSet As OraDynaset
            dataSet = OraDatabase.CreateDynaset("SELECT * FROM part_nos", 0)
            Assert.AreEqual(countItem, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos ", 0)


            'objDynaset.DbEdit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            objDynaset.DbDelete()

            'Try to insert data which has been deleted
            'Dim dataSet As OraDynaset
            'dataSet = OraDatabase.CreateDynaset("SELECT * FROM part_nos", 0)  'Executing select here will not throw exception => Move the select to the above delete 
            dataSet.AddNew()
            dataSet.Fields("partno").Value = 1000 ' which as been deleted 

            dataSet.Fields("description").Value = "TEST"
            dataSet.Update()
            'Try to select
            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, countItem)

        Catch ex As Exception
            Dim s = ex.Message ' Message will be Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.
            Assert.AreEqual(s, "Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.")
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Select_Then_Mark_Delete_Then_Insert_NoException()

        'To fix for Select_Then_Delete_Then_Insert_Exception
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim DateArray() As Object
        Dim i As Integer
        Dim countItem As Integer = 2
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, countItem, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, countItem, 50)


            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For i = 0 To countItem - 1
                achar = "Description" + Str(i)
                PartNoArray(i) = 1000 + i
                DescArray(i) = achar
            Next i

            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)
            Dim dataSet As OraDynaset
            dataSet = OraDatabase.CreateDynaset("SELECT * FROM part_nos", 0)
            Assert.AreEqual(countItem, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos ", 0)


            'objDynaset.DbEdit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            objDynaset.DbDelete() 'Delete row 1000 

            'Try to insert data which has been deleted
            'Dim dataSet As OraDynaset
            'DataSet = OraDatabase.CreateDynaset("SELECT * FROM part_nos", 0)  'Executing select here will not throw exception => Move the select to the above delete 
            'Mark delete record 1000 
            dataSet.MoveFirst()
            While dataSet.EOF <> True
                If dataSet.Fields("partno").Value = 1000 Then
                    'dataSet.Delete()
                    dataSet.MarkDelete()  'Mark delete row 1000 which has been dedleted before 
                End If
                dataSet.MoveNext()
            End While

            dataSet.AddNew()
            dataSet.Fields("partno").Value = 1000 ' try to add again row 1000 which as been deleted 

            dataSet.Fields("description").Value = "TEST"
            dataSet.Update()
            'Try to select
            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, countItem)

        Catch ex As Exception
            Dim s = ex.Message ' Message will be Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.
            Assert.AreEqual(s, "Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.")
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub
    <TestMethod()> Public Sub Parameters_NonArray_OK()

        Dim OraDatabase = New TestingFactory().CreateDatabase()

        Dim TCode As String = ""
        OraDatabase.Parameters.Add("SEIKYU", TCode, ORAPARM_INPUT) 'SKI100
        OraDatabase.Parameters(0).ServerType = ORATYPE_STRING
        Assert.AreEqual(ORATYPE_STRING, OraDatabase.Parameters("SEIKYU").ServerType) 'Should auto detect type String
        OraDatabase.Parameters(0).ServerType = ORATYPE_CHAR
        Assert.AreEqual(TCode, OraDatabase.Parameters("SEIKYU").Value)

        Dim type As String
        Dim int As Integer = 0
        OraDatabase.Parameters.Add("int", int, ORAPARM_INPUT)
        OraDatabase.Parameters("int").ServerType = ORATYPE_NUMBER
        Assert.AreEqual(ORATYPE_NUMBER, OraDatabase.Parameters("int").ServerType)
        Assert.AreEqual(int, OraDatabase.Parameters("int").Value)

        Dim dbl As Double = 0
        type = dbl.GetType().Name
        OraDatabase.Parameters.Add("dbl", dbl, ORAPARM_INPUT)
        OraDatabase.Parameters("dbl").ServerType = ORATYPE_NUMBER
        Assert.AreEqual(ORATYPE_NUMBER, OraDatabase.Parameters("dbl").ServerType)

        Dim dt As DateTime = DateTime.Now
        type = dbl.GetType().Name
        OraDatabase.Parameters.Add("dt", dt, ORAPARM_INPUT)
        OraDatabase.Parameters("dt").ServerType = ORATYPE_DATE
        Assert.AreEqual(ORATYPE_DATE, OraDatabase.Parameters("dt").ServerType)
        Assert.AreEqual(dt, OraDatabase.Parameters("dt").Value)
    End Sub

    <TestMethod()> Public Sub Delete_Real_Table_No_Keys_Use_RowID_OK()

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
        Try
            OraDatabase.BeginTrans()


            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("select  D32120, D32100, D32110,rowid from SKFD32 where D32100=4417 and D32110 = 1 ", 0)

            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            objDynaset.DbDelete()


        Catch ex As Exception
            Dim s = ex.Message
            OraDatabase.Rollback()
            Throw
        Finally
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Delete_Memory_Table_No_Keys_Use_RowID_OK()

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
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, countItem, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, countItem, 50)


            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For i = 0 To countItem - 1
                achar = "Description" + Str(i)
                PartNoArray(i) = 1000 + i
                DescArray(i) = achar
            Next i
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)

            Assert.AreEqual(countItem, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description,ROWID FROM part_nos ", 0)

            'Add new

            objDynaset.DbEdit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            objDynaset.DbDelete() 'Delete the first row

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description,ROWID FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, countItem - 1)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub Delete_Table_Has_No_Key_Use_RowID_OK()

        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION", ORAPARM_INPUT,
                                    ORATYPE_CHAR, 10, 50)
            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For I = 0 To 9
                achar = "Description" + Str(I)
                PartNoArray(I) = 1000 + I
                DescArray(I) = achar
            Next I
            result = OraDatabase.CreateSql("insert into part_nos(partno, description) values(:PARTNO,:DESCRIPTION)", 0&)
            Assert.AreEqual(10, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description ,ROWIDTONCHAR(ROWID) ""ROWID""  FROM part_nos FOR UPDATE ", 0)

            'Update new

            objDynaset.Edit()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            'Delete the first record 
            objDynaset.Delete()

            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Assert.AreEqual(9, objDynaset2.RecordCount) 'There are now 9 records, 1 has been deleted

            'Check other records, make sure them are not updated
            For I = 2 To 9
                objDynaset2.MoveNext()
                Assert.AreEqual("Description" + Str(I), CType(objDynaset2("description").Value, String).Trim())
            Next I
        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            'Drop the table 
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

    <TestMethod()> Public Sub GetChunkByte_OK()

        'To fix for Select_Then_Delete_Then_Insert_Exception
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            OraDatabase.BeginTrans()
            Dim abytReadBuff() As Byte
            Const MC_TEMP_BUFF_SIZE As Integer = 10240
            Dim lngReadPosi As Integer
            Dim dblReadSize As Double
            'SELECT 顔写真 FROM 従業員顔写真マスタ where 従業員コード = 0600077 
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT * FROM 従業員顔写真マスタ where 従業員コード = 0600077 ", &H1)
            Dim res1 As Object = objDynaset.Fields("顔写真").Value
            Dim fieldSize As Integer = objDynaset.Fields("顔写真").FieldSize
            Dim intFileNum As Short
            Dim mstrTempPath As String = "C:\_work\temp\"
            If (Not System.IO.Directory.Exists(mstrTempPath)) Then
                Throw New Exception(mstrTempPath & " does not exist")
            End If

            Dim pstrOldEmployeeCD As String = "0600077_" + Guid.NewGuid().ToString()
            Dim MC_TEMP_FILE As String = ".JPG"
            If (System.IO.File.Exists(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)) Then
                System.IO.File.Delete(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)
            End If
            If (fieldSize > 0) Then
                ReDim abytReadBuff(MC_TEMP_BUFF_SIZE - 1)

                lngReadPosi = 0
                intFileNum = FreeFile()
                FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)


                Do
                    '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    'dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                    dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                    '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    ' 読込んだデータサイズが0の時
                    If dblReadSize = 0 Then

                        ' ループを抜ける
                        Exit Do
                    End If
                    If dblReadSize < MC_TEMP_BUFF_SIZE Then

                        ' 実際の読込みサイズに，読込みバッファを再定義
                        ReDim abytReadBuff(dblReadSize - 1)

                        '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                        'dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                        dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                        '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    End If

                    FilePut(intFileNum, abytReadBuff)
                    ' 顔写真データの読込み位置を更新
                    lngReadPosi = lngReadPosi + 1

                Loop Until dblReadSize < MC_TEMP_BUFF_SIZE
                'Dim byteArrayIn As Byte()
                'byteArrayIn = objDynaset.Fields("顔写真").Value
                'FilePut(intFileNum, byteArrayIn)

                FileClose(intFileNum)

                Dim fileContent() As Byte
                fileContent = System.IO.File.ReadAllBytes(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)
                Dim fieldData() As Byte
                fieldData = CType(objDynaset.Fields("顔写真").Value, Byte())
                Assert.AreEqual(fileContent.Length, fieldData.Length)
                For i As Integer = 0 To fileContent.Length - 1
                    Assert.AreEqual(fileContent(i), fieldData(i))
                Next

            End If

        Catch ex As Exception
            'Dim s = ex.Message ' Message will be Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.
            'Assert.AreEqual(s, "Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.")
            Throw
        Finally
            OraDatabase.Rollback()
        End Try




    End Sub

    <TestMethod()> Public Sub AppendChunkByte_OK()

        'To fix for Select_Then_Delete_Then_Insert_Exception
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            OraDatabase.BeginTrans()
            Dim abytReadBuff() As Byte
            Const MC_TEMP_BUFF_SIZE As Integer = 10240
            Dim lngReadPosi As Integer
            Dim dblReadSize As Double
            'SELECT 顔写真 FROM 従業員顔写真マスタ where 従業員コード = 0600077 
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT * FROM 従業員顔写真マスタ where 従業員コード = 0600077 ", &H1)
            Dim res1 As Object = objDynaset.Fields("顔写真").Value
            Dim fieldSize As Integer = objDynaset.Fields("顔写真").FieldSize
            Dim intFileNum As Short
            Dim mstrTempPath As String = "C:\_work\temp\"
            If (Not System.IO.Directory.Exists(mstrTempPath)) Then
                Throw New Exception(mstrTempPath & " does not exist")
            End If

            Dim pstrOldEmployeeCD As String = "0600077_" + Guid.NewGuid().ToString()
            Dim MC_TEMP_FILE As String = ".JPG"
            If (System.IO.File.Exists(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)) Then
                System.IO.File.Delete(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)
            End If
            If (fieldSize > 0) Then
                ReDim abytReadBuff(MC_TEMP_BUFF_SIZE - 1)

                lngReadPosi = 0
                intFileNum = FreeFile()
                FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)


                Do
                    '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    'dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                    dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                    '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    ' 読込んだデータサイズが0の時
                    If dblReadSize = 0 Then

                        ' ループを抜ける
                        Exit Do
                    End If
                    If dblReadSize < MC_TEMP_BUFF_SIZE Then

                        ' 実際の読込みサイズに，読込みバッファを再定義
                        ReDim abytReadBuff(dblReadSize - 1)

                        '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                        'dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                        dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                        '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    End If

                    FilePut(intFileNum, abytReadBuff)
                    ' 顔写真データの読込み位置を更新
                    lngReadPosi = lngReadPosi + 1

                Loop Until dblReadSize < MC_TEMP_BUFF_SIZE
                'Dim byteArrayIn As Byte()
                'byteArrayIn = objDynaset.Fields("顔写真").Value
                'FilePut(intFileNum, byteArrayIn)

                FileClose(intFileNum)

                Dim fileContent() As Byte
                fileContent = System.IO.File.ReadAllBytes(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)
                Dim fieldData() As Byte
                fieldData = CType(objDynaset.Fields("顔写真").Value, Byte())
                Assert.AreEqual(fileContent.Length, fieldData.Length)
                For i As Integer = 0 To fileContent.Length - 1
                    Assert.AreEqual(fileContent(i), fieldData(i))
                Next

                'Add new
                objDynaset.AddNew()
                Dim pstrNewEmployeeCD2 As String
                Dim lngTotalSize As Long
                pstrNewEmployeeCD2 = "9999999" 'TESTING
                Dim intNumChunks As Int64
                Dim dblWriteSize As Int64
                Dim abytWriteBuff() As Byte

                With objDynaset
                    .Fields("従業員コード").Value = pstrNewEmployeeCD2 'For tesing 
                    .Fields("写真撮影日").Value = pstrNewEmployeeCD2
                    .Fields("更新従業員コード").Value = pstrNewEmployeeCD2
                    .Fields("更新日付時刻").Value = Date.Now.ToString("yyyy/MM/dd hh:mm:ss")


                    intFileNum = FreeFile()

                    FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)

                    lngTotalSize = LOF(intFileNum)

                    intNumChunks = lngTotalSize \ MC_TEMP_BUFF_SIZE

                    For intWritePosi = 0 To intNumChunks

                        If intWritePosi = intNumChunks Then
                            dblWriteSize = lngTotalSize Mod MC_TEMP_BUFF_SIZE

                        Else
                            dblWriteSize = MC_TEMP_BUFF_SIZE
                        End If

                        If dblWriteSize = 0 Then
                            Exit For
                        End If

                        ReDim abytWriteBuff(dblWriteSize - 1)

                        FileGet(intFileNum, abytWriteBuff)

                        Call .Fields("顔写真").AppendChunkByte(abytWriteBuff, dblWriteSize)
                    Next intWritePosi

                    FileClose(intFileNum)
                End With
                objDynaset.Update() 'Save to database 
                'Get data to check

                Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT * FROM 従業員顔写真マスタ where 従業員コード = 9999999 ", &H1)

                fieldData = CType(objDynaset2.Fields("顔写真").Value, Byte())
                Assert.AreEqual(fileContent.Length, fieldData.Length)
                For i As Integer = 0 To fileContent.Length - 1
                    If fileContent(i) <> fieldData(i) Then
                        Throw New Exception("Error at " + i.ToString())
                    End If
                    'Assert.AreEqual(fileContent(i), fieldData(i))
                Next





            End If

        Catch ex As Exception
            If OraDatabase.Session.HasTransaction Then
                OraDatabase.Rollback()
            End If
            Throw
        Finally
            If OraDatabase.Session.HasTransaction Then
                OraDatabase.Rollback()
            End If
        End Try


    End Sub

    <TestMethod()> Public Sub CreateLongRawReader_OK()

        'To fix for Select_Then_Delete_Then_Insert_Exception
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            OraDatabase.BeginTrans()
            Dim abytReadBuff() As Byte
            Const MC_TEMP_BUFF_SIZE As Integer = 10240
            Dim lngReadPosi As Integer
            Dim dblReadSize As Double
            'SELECT 顔写真 FROM 従業員顔写真マスタ where 従業員コード = 0600077 
            Dim sql As String = ""
            sql = "
                   SELECT
                      D_IMG.利用チケット画像
                     FROM
                       利用チケット画像テーブル  D_IMG
                     WHERE
                         営業日               = '20210724'
                     AND 利用チケット読込番号 = 3948336"
            'Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset(sql, &H10)
            Dim objDynaset As OraLongRawReader = OraDatabase.CreateLongRawReader(sql, &H10)
            Dim res1 As Object = objDynaset.Fields("利用チケット画像").Value
            Dim data As Byte()
            data = CType(res1, Byte())
            Assert.IsTrue(data.Length > 0)


        Catch ex As Exception
            'Dim s = ex.Message ' Message will be Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.
            'Assert.AreEqual(s, "Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.")
            Throw
        Finally
            OraDatabase.Rollback()
        End Try




    End Sub

    <TestMethod()> Public Sub GetChunkByte_NoData_NoException()

        'To fix for Select_Then_Delete_Then_Insert_Exception
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            OraDatabase.BeginTrans()
            Dim abytReadBuff() As Byte
            Const MC_TEMP_BUFF_SIZE As Integer = 10240
            Dim lngReadPosi As Integer
            Dim dblReadSize As Double
            'SELECT 顔写真 FROM 従業員顔写真マスタ where 従業員コード = 0600077 
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT * FROM 従業員顔写真マスタ where 従業員コード = 0600077000 ", &H1)
            Dim res1 As Object = objDynaset.Fields("顔写真").Value
            Dim fieldSize As Integer = objDynaset.Fields("顔写真").FieldSize

            ReDim abytReadBuff(MC_TEMP_BUFF_SIZE - 1)
            objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)

            Dim intFileNum As Short
            Dim mstrTempPath As String = "C:\_work\temp\"
            If (Not System.IO.Directory.Exists(mstrTempPath)) Then
                Throw New Exception(mstrTempPath & " does not exist")
            End If

            Dim pstrOldEmployeeCD As String = "0600077_" + Guid.NewGuid().ToString()
            Dim MC_TEMP_FILE As String = ".JPG"
            If (System.IO.File.Exists(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)) Then
                System.IO.File.Delete(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)
            End If
            If (fieldSize > 0) Then
                ReDim abytReadBuff(MC_TEMP_BUFF_SIZE - 1)

                lngReadPosi = 0
                intFileNum = FreeFile()
                FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)


                Do
                    '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    'dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                    dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                    '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    ' 読込んだデータサイズが0の時
                    If dblReadSize = 0 Then

                        ' ループを抜ける
                        Exit Do
                    End If
                    If dblReadSize < MC_TEMP_BUFF_SIZE Then

                        ' 実際の読込みサイズに，読込みバッファを再定義
                        ReDim abytReadBuff(dblReadSize - 1)

                        '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                        'dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                        dblReadSize = objDynaset.Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                        '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                    End If

                    FilePut(intFileNum, abytReadBuff)
                    ' 顔写真データの読込み位置を更新
                    lngReadPosi = lngReadPosi + 1

                Loop Until dblReadSize < MC_TEMP_BUFF_SIZE
                'Dim byteArrayIn As Byte()
                'byteArrayIn = objDynaset.Fields("顔写真").Value
                'FilePut(intFileNum, byteArrayIn)

                FileClose(intFileNum)

                Dim fileContent() As Byte
                fileContent = System.IO.File.ReadAllBytes(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)
                Dim fieldData() As Byte
                fieldData = CType(objDynaset.Fields("顔写真").Value, Byte())
                Assert.AreEqual(fileContent.Length, fieldData.Length)
                For i As Integer = 0 To fileContent.Length - 1
                    Assert.AreEqual(fileContent(i), fieldData(i))
                Next

            End If

        Catch ex As Exception
            'Dim s = ex.Message ' Message will be Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.
            'Assert.AreEqual(s, "Column 'PARTNO' is constrained to be unique.  Value '1000' is already present.")
            Throw
        Finally
            OraDatabase.Rollback()
        End Try




    End Sub

    <TestMethod()> Public Sub AddNew_With_ROWID_OK()

        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim PartNoArray() As Object
        Dim DescArray() As Object
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                         "description char(50), primary key(partno))")


            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)




            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT ROWID, partno, description FROM part_nos ", 0)

            'Add new
            'Dim reader As OraDynasetReader
            'reader = OraDatabase.CreateDynasetReader("Select ROWID AS AA from dual ")
            'reader.DbMoveFirst()
            Dim objDynasetTmp As OraDynaset = OraDatabase.CreateDynaset("Select ROWID  from dual  ", &H1)
            Dim rowID As String
            rowID = objDynasetTmp.Fields("ROWID").Value

            objDynaset.AddNew()


            objDynaset("partno").Value = 1100D
            objDynaset("description").Value = "Description 11"
            'objDynaset("ROWID").Value = reader("AA").Value
            'objDynaset("ROWID").Value = ""
            objDynaset.Update()
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            Dim objDynaset2 As OraDynaset = OraDatabase.CreateDynaset("SELECT partno, description FROM part_nos", 0)
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Assert.AreEqual(objDynaset2.RecordCount, 1)



        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try


    End Sub

End Class