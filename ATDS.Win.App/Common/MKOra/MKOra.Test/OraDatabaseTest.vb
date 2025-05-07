Imports System.Text
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Newtonsoft.Json
Imports System.IO
Imports MKOra.Core
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types

<TestClass()> Public Class OraDatabaseTest

    <TestMethod()> Public Sub DbOpenDatabase_OK()

        Dim database = New TestingFactory().CreateDatabase()

    End Sub

    <TestMethod()> Public Sub CreateDynaset_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Dim strSQL As String

        strSQL = "SELECT Z20100, Z20110, Z20120, Z20130, Z20140, Z20150, " & "Z20160, Z20163, Z20165, Z20170, Z20180, Z20190, Z20200, " & "Z20300, Z20310, " & "Z20320, Z20330, Z20340, Z20350, Z20360, Z20370, Z20380, Z20390, Z20400, " & "Z20210, Z20220 " & "FROM SKFZ20 "


        '2001/06/06 (A) GAKU
        strSQL = strSQL & "FOR UPDATE"
        Dim objDyna As OraDynaset
        objDyna = database.CreateDynaset(strSQL, 0)
        Assert.IsNotNull(objDyna)
        Dim lngRecCnt As Integer
        lngRecCnt = objDyna.RecordCount
        Assert.IsTrue(lngRecCnt > 0)

        Dim lngItemCnt As Integer = objDyna.Fields.Count
        Dim g_objFields() As OraField
        ReDim g_objFields(lngItemCnt)

        Assert.IsTrue(lngItemCnt > 0)

        For i = 0 To lngItemCnt - 1
            g_objFields(i) = objDyna.Fields(i)
        Next i


        Dim dblZ20100 As Double
        dblZ20100 = -100
        Dim dblZ20110 As Double
        dblZ20110 = -100

        Dim existingDblZ20100 As Double = g_objFields(0).Value
        Dim existingDblZ20110 As Double = g_objFields(1).Value
        Assert.IsTrue(existingDblZ20100 > 0)
        Assert.IsTrue(existingDblZ20110 > 0)




    End Sub


    <TestMethod()> Public Sub UpdateWithoutKey_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String

            strSQL = "SELECT Z20100, Z20110, Z20120, Z20130, Z20140, Z20150, " & "Z20160, Z20163, Z20165, Z20170, Z20180, Z20190, Z20200, " & "Z20300, Z20310, " & "Z20320, Z20330, Z20340, Z20350, Z20360, Z20370, Z20380, Z20390, Z20400, " & "Z20210, Z20220 " & "FROM SKFZ20 "


            '2001/06/06 (A) GAKU
            strSQL = strSQL & "FOR UPDATE"
            Dim objDyna As OraDynaset
            database.Session.BeginTrans()


            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)
            Dim lngRecCnt As Integer
            lngRecCnt = objDyna.RecordCount
            Assert.IsTrue(lngRecCnt > 0)

            Dim lngItemCnt As Integer = objDyna.Fields.Count
            Dim g_objFields() As OraField
            ReDim g_objFields(lngItemCnt)

            Assert.IsTrue(lngItemCnt > 0)

            For i = 0 To lngItemCnt - 1
                g_objFields(i) = objDyna.Fields(i)
            Next i


            Dim dblZ20100 As Decimal
            dblZ20100 = -100
            Dim dblZ20110 As Decimal
            dblZ20110 = -1000

            Dim existingDblZ20100 As Decimal = g_objFields(0).Value
            Dim existingDblZ20110 As Decimal = g_objFields(1).Value

            objDyna.DbEdit()

            g_objFields(0).Value = dblZ20100

            g_objFields(1).Value = dblZ20110




            objDyna.UpdateWithoutKey("SKFZ20")
            Dim lastError As Integer = database.LastServerErr
            Assert.AreEqual(lastError, 0)
            'Recover old value
            objDyna = Nothing
            objDyna = database.CreateDynaset(strSQL, 0)
            ReDim g_objFields(lngItemCnt)

            Assert.IsTrue(lngItemCnt > 0)

            For i = 0 To lngItemCnt - 1
                g_objFields(i) = objDyna.Fields(i)
            Next i
            Assert.AreEqual(dblZ20100, g_objFields(0).Value)

            Assert.AreEqual(dblZ20110, g_objFields(1).Value)

            objDyna.DbEdit()
            g_objFields(0).Value = existingDblZ20100

            g_objFields(1).Value = existingDblZ20110
            objDyna.UpdateWithoutKey("SKFZ20")

        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try



    End Sub

    <TestMethod()> Public Sub LastServerErr_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Dim objSession As OraSession
        Try
            objSession = database.Session()
            objSession.DbBeginTrans()
            Dim strSQL As String
            'Try to get non-existing column Z20100XXX => Cause error
            strSQL = "SELECT Z20100XXX, FROM SKFZ20 "

            Dim objDyna As OraDynaset
            objDyna = database.CreateDynaset(strSQL, 0)

            objSession.DbCommitTrans()



        Catch ex As Exception
            objSession.DbRollBack()
            Dim lasError As Integer = database.LastServerErr
            Assert.IsTrue(lasError > 0)
            If Err.Number = 440 Then
                If lasError <> 0 Or database.LastServerErrText <> "" Then
                End If
            Else
            End If
        Finally
            database.Rollback()
        End Try






    End Sub

    <TestMethod()> Public Sub Paremeters_AddTable_Simple_OK()
        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String
            Dim result As OraSqlStmt
            Dim data2 As OraDynaset
            Dim PartNoArray() As Object
            Dim DescArray() As Object
            Dim I As Integer

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

            'Update the newly created part_nos table 
            For I = 0 To 9
                achar = "Description" + Str(1000 + I)
                DescArray(I) = achar
            Next I

            'Update table 
            'Dim recordCount As Integer = OraDatabase.ExecuteSQL("update part_nos set DESCRIPTION" &
            '                            "=:DESCRIPTION where PARTNO = :PARTNO")
            'Make sure there's no error
            'Assert.AreEqual(OraDatabase.LastServerErr, 0)

            'Assert.AreEqual(10, recordCount)

            'Deleting rows 
            'OraDatabase.ExecuteSQL("delete  from  part_nos where" &
            '                            "DESCRIPTION=: Description ")

            'Drop the table 

        Catch ex As Exception
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try

    End Sub

    <TestMethod()> Public Sub Paremeters_AddTable_SKD100_OK()
        'Follow Skd100 > frmOutKeihiMeisai
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String
            Dim GyoCnt As Short
            OraDatabase.Session.BeginTrans()
            GyoCnt = 1
            OraDatabase.Parameters.AddTable("D13100_ARR", ORAPARM_INPUT, ORATYPE_DATE, GyoCnt)
            OraDatabase.Parameters.AddTable("D13200_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13300_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F11_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F12_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F13_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F14_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F15_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F16_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F21_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F22_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F23_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F24_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F25_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)
            OraDatabase.Parameters.AddTable("D13F26_ARR", ORAPARM_INPUT, ORATYPE_NUMBER, GyoCnt)

            Dim OraPArrayD11 As Object
            OraPArrayD11 = New Object()
            ReDim OraPArrayD11(14)

            OraPArrayD11(0) = OraDatabase.Parameters("D13100_ARR")
            OraPArrayD11(1) = OraDatabase.Parameters("D13200_ARR")
            OraPArrayD11(2) = OraDatabase.Parameters("D13300_ARR")
            OraPArrayD11(3) = OraDatabase.Parameters("D13F11_ARR")
            OraPArrayD11(4) = OraDatabase.Parameters("D13F12_ARR")
            OraPArrayD11(5) = OraDatabase.Parameters("D13F13_ARR")
            OraPArrayD11(6) = OraDatabase.Parameters("D13F14_ARR")
            OraPArrayD11(7) = OraDatabase.Parameters("D13F15_ARR")
            OraPArrayD11(8) = OraDatabase.Parameters("D13F16_ARR")
            OraPArrayD11(9) = OraDatabase.Parameters("D13F21_ARR")
            OraPArrayD11(10) = OraDatabase.Parameters("D13F22_ARR")
            OraPArrayD11(11) = OraDatabase.Parameters("D13F23_ARR")
            OraPArrayD11(12) = OraDatabase.Parameters("D13F24_ARR")
            OraPArrayD11(13) = OraDatabase.Parameters("D13F25_ARR")
            OraPArrayD11(14) = OraDatabase.Parameters("D13F26_ARR")



            Dim MeisaiCnt As Integer = 0
            Dim g_UriDate As DateTime = DateTime.Now
            OraPArrayD11(0).Put_Value(g_UriDate, MeisaiCnt)
            OraPArrayD11(1).Put_Value(1, MeisaiCnt)
            OraPArrayD11(2).Put_Value(100, MeisaiCnt)
            OraPArrayD11(3).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(4).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(5).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(6).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(7).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(8).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(9).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(10).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(11).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(12).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(13).Put_Value(10D, MeisaiCnt)
            OraPArrayD11(14).Put_Value(10D, MeisaiCnt)


            Dim SkfD13Add1 As String = "INSERT INTO SKFD13" '売上明細情報SQL1
            Dim SkfD13Add2 As String = " (D13100,D13200,D13300,D13F11,D13F12,D13F13,D13F14,D13F15,D13F16,D13F21,D13F22,D13F23,D13F24,D13F25,D13F26)" '売上明細情報SQL2
            Dim SkfD13Add3 As String = " VALUES(:D13100_ARR,:D13200_ARR,:D13300_ARR,:D13F11_ARR,:D13F12_ARR,:D13F13_ARR,:D13F14_ARR,:D13F15_ARR,:D13F16_ARR, " '売上明細情報SQL3
            Dim SkfD13Add4 As String = " :D13F21_ARR,:D13F22_ARR,:D13F23_ARR,:D13F24_ARR,:D13F25_ARR,:D13F26_ARR) "

            Dim OraSqlStmtD11 As OraSqlStmt
            OraSqlStmtD11 = OraDatabase.CreateSql(SkfD13Add1 & SkfD13Add2 & SkfD13Add3 & SkfD13Add4, 0)
            Assert.AreEqual(1, OraSqlStmtD11.ExecuteNonQueryResult)

        Catch ex As Exception
            Throw
        Finally
            OraDatabase.Session.RollBack()
        End Try

    End Sub
    <TestMethod()> Public Sub Filter_Date_OK()
        'Follow MDSKFZ20
        Dim database = New TestingFactory().CreateDatabase()
        Try
            database.Session.BeginTrans()
            Dim strSQL As String
            Dim d As Date = New Date(2020, 2, 29)
            Dim DenpyoNo As Short = 1
            Dim Sql As String = "select D10110 from skfd10 " & "where D10110 = '" & VB6.Format(d, "yyyy/mm/dd") & "' and D10120 = " & CStr(DenpyoNo) & " and D10140 = 0"
            'strSQL = "select D10110 from skfd10 where D10110 = '2020/02/29' and D10120 = 1 and D10140 = 0 "
            strSQL = "select D10110 from skfd10 where to_char(D10110,'yyyy/mm/dd') = '2020/02/29' and D10120 = 1 and D10140 = 0 "


            Dim objDyna As OraDynaset
            objDyna = database.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)

        Catch ex As Exception
            Throw
        Finally
            database.Session.RollBack()
        End Try


    End Sub

    <TestMethod()> Public Sub Filter_Compare_Date_OK()
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim idArray() As Object
        Dim dateArray() As Object
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table SKUT10_Test(ID NUMBER(12,3) DEFAULT 0," &
                         " UT0130 DATE, primary key(ID))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("ID_Param", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("UT0130_Param", ORAPARM_INPUT,
                                    ORATYPE_DATE, 10, 50)
            idArray = OraDatabase.Parameters("ID_Param").Value
            dateArray = OraDatabase.Parameters("UT0130_Param").Value

            'Initialize arrays 
            For I = 0 To 9
                idArray(I) = I + 1
                dateArray(I) = Date.Now.AddDays(I)
            Next I
            result = OraDatabase.CreateSql("insert into SKUT10_Test(ID, UT0130) values(:ID_Param,:UT0130_Param)", 0&)

            Assert.AreEqual(10, result.ExecuteNonQueryResult)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT ID, UT0130 FROM SKUT10_Test FOR UPDATE ", 0)

            Assert.IsNotNull(objDynaset)

            Dim d As Date = Date.Now.AddDays(2)
            strSQL = "select * from SKUT10_Test where to_char(UT0130,'YYYY/MM/DD') <= '" & VB6.Format(d, "YYYY/MM/DD") & "' " & vbCrLf


            Dim objDyna As OraDynaset
            objDyna = OraDatabase.CreateDynaset(strSQL, 0)
            Assert.IsNotNull(objDyna)
            Assert.AreEqual(3, objDyna.RecordCount)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table SKUT10_Test")
            OraDatabase.Rollback()
        End Try



    End Sub

    <TestMethod()> Public Sub Parameter_Output_Number_OK()
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim I As Integer
        Try
            OraDatabase.BeginTrans()
            strSQL = "BEGIN SetB10B20_Teiki.SetB10B20_Teiki_Main(0,'06086',0,'2019-12-22','2019-12-22',31,0,-14800,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-14800,-1184,0,0,0,0,0,0, :rc); END;"
            OraDatabase.Parameters.Add("rc", 0, ORAPARM_OUTPUT)
            OraDatabase.Parameters("rc").ServerType = ORATYPE_NUMBER
            Dim lngOra As Integer
            lngOra = OraDatabase.DbExecuteSQL(strSQL)
            Dim rc As Short
            rc = OraDatabase.Parameters("rc").Value
            Assert.IsTrue(rc = 0)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.Rollback()
        End Try



    End Sub

    <TestMethod()> Public Sub Parameter_Insert_TimeOfDate__OK()
        'Unit Test SKD100 > Insert_D10
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim id_Arr As OraParameter
        Dim date_arr As OraParameter
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table skfd10_unittest (ID NUMBER(12,3) DEFAULT 0," &
                         " D10Z15 DATE, primary key(ID))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("ID_Param", ORAPARM_INPUT, ORATYPE_NUMBER, 1)
            OraDatabase.Parameters.AddTable("D10Z15_Param", ORAPARM_INPUT,
                                    ORATYPE_DATE, 1)
            id_Arr = OraDatabase.Parameters("ID_Param")
            date_arr = OraDatabase.Parameters("D10Z15_Param")
            id_Arr.Put_Value(1, 0)
            date_arr.Put_Value(TimeOfDay, 0) 'Will be 01/01/0001
            'Dim paramJSON As String = OraDatabase.GetParametersJSON()
            result = OraDatabase.CreateSql("insert into skfd10_unittest(ID, D10Z15) values(:ID_Param,:D10Z15_Param)", 0&)

            Assert.AreEqual(1, result.ExecuteNonQueryResult)


        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table skfd10_unittest")
            OraDatabase.Rollback()
        End Try



    End Sub

    '<TestMethod()> Public Sub Parameter_Insert_skfd10_OK()
    '    'Unit Test SKD100 > Insert_D10
    '    Dim OraDatabase = New TestingFactory().CreateDatabase()
    '    Dim strSQL As String
    '    Dim result As OraSqlStmt
    '    Dim data2 As OraDynaset
    '    Dim id_Arr As OraParameter
    '    Dim date_arr As OraParameter
    '    Try
    '        OraDatabase.BeginTrans()
    '        strSQL = "insert into skfd10 (D10100,D10110,D10120,D10130,D10140,D10150,D10160,D10170,D10180,D10190,D10200,D10210,D10220,D10230,D10240,D10250,D10260,D10270,D10280,D10290,D10300,D10310,D10400,D10410,D10420,D10430,D10500,D10510,D10520,D10530,D10540,D10550,D10560,D10570,D10600,D10610,D10620,D10630,D10640,D10700,D10710,D10720,D10730,D10740,D10750,D10760,D10800,D10810,D10820,D10900,D10910,D10920,D10A00,D10A10,D10B00,D10B10,D10B20,D10Z00,D10Z05,D10Z10,D10Z15,D10Z20,D10Z30,D10A20,D10B30,D10615,D10D00,D10D10,D10E00,D10E10,D10E20,D10F00,D10F10,D10F20,D10F25,D10G10,D10G20) values(:D10100_ARR,:D10110_ARR,:D10120_ARR,:D10130_ARR,:D10140_ARR,:D10150_ARR,:D10160_ARR,:D10170_ARR,:D10180_ARR,:D10190_ARR,:D10200_ARR,:D10210_ARR,:D10220_ARR,:D10230_ARR,:D10240_ARR,:D10250_ARR,:D10260_ARR,:D10270_ARR,:D10280_ARR,:D10290_ARR,:D10300_ARR,:D10310_ARR,:D10400_ARR,:D10410_ARR,:D10420_ARR,:D10430_ARR,:D10500_ARR,:D10510_ARR,:D10520_ARR,:D10530_ARR,:D10540_ARR,:D10550_ARR,:D10560_ARR,:D10570_ARR,:D10600_ARR,:D10610_ARR,:D10620_ARR,:D10630_ARR,:D10640_ARR,:D10700_ARR,:D10710_ARR,:D10720_ARR,:D10730_ARR,:D10740_ARR,:D10750_ARR,:D10760_ARR,:D10800_ARR,:D10810_ARR,:D10820_ARR,:D10900_ARR,:D10910_ARR,:D10920_ARR,:D10A00_ARR,:D10A10_ARR,:D10B00_ARR,:D10B10_ARR,:D10B20_ARR,:D10Z00_ARR,:D10Z05_ARR,:D10Z10_ARR,:D10Z15_ARR,:D10Z20_ARR,:D10Z30_ARR,:D10A20_ARR,:D10B30_ARR,:D10615_ARR,:D10D00_ARR,:D10D10_ARR,:D10E00_ARR,:D10E10_ARR,:D10E20_ARR,:D10F00_ARR,:D10F10_ARR,:D10F20_ARR,:D10F25_ARR,:D10G10_ARR,:D10G20_ARR)"

    '        Dim paramJSON As String
    '        paramJSON = " [{""Name"":""D10100_ARR"",""ServerType"":96,""Value"":[""06086""]},{""Name"":""D10110_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10120_ARR"",""ServerType"":2,""Value"":[2651450.0]},{""Name"":""D10130_ARR"",""ServerType"":2,""Value"":[4]},{""Name"":""D10140_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10150_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10160_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10170_ARR"",""ServerType"":2,""Value"":[""07""]},{""Name"":""D10180_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10190_ARR"",""ServerType"":96,""Value"":[""06086""]},{""Name"":""D10200_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10210_ARR"",""ServerType"":2,""Value"":[31]},{""Name"":""D10220_ARR"",""ServerType"":2,""Value"":[2]},{""Name"":""D10230_ARR"",""ServerType"":12,""Value"":[""2020-05-11T00:00:00""]},{""Name"":""D10240_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10250_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10260_ARR"",""ServerType"":2,""Value"":[131]},{""Name"":""D10270_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10280_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10290_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10300_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10310_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10400_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10410_ARR"",""ServerType"":2,""Value"":[8.0]},{""Name"":""D10420_ARR"",""ServerType"":2,""Value"":[1]},{""Name"":""D10430_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10500_ARR"",""ServerType"":2,""Value"":[1]},{""Name"":""D10510_ARR"",""ServerType"":2,""Value"":[14800.0]},{""Name"":""D10520_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10530_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10540_ARR"",""ServerType"":2,""Value"":[14800.0]},{""Name"":""D10550_ARR"",""ServerType"":2,""Value"":[1184.0]},{""Name"":""D10560_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10570_ARR"",""ServerType"":2,""Value"":[2060.0]},{""Name"":""D10600_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10610_ARR"",""ServerType"":96,""Value"":[""御中""]},{""Name"":""D10615_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10620_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10630_ARR"",""ServerType"":96,""Value"":[""01 ""]},{""Name"":""D10640_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10700_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10710_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10720_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10730_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10740_ARR"",""ServerType"":96,""Value"":[""30""]},{""Name"":""D10750_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10760_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10800_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10810_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10820_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10900_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10910_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10920_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10A00_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10A10_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10A20_ARR"",""ServerType"":2,""Value"":[null]},{""Name"":""D10B00_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10B10_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10B20_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10B30_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10Z00_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10Z05_ARR"",""ServerType"":12,""Value"":[""1899-12-30T09:43:31""]},{""Name"":""D10Z10_ARR"",""ServerType"":12,""Value"":[""2020-07-17T00:00:00+09:00""]},{""Name"":""D10Z15_ARR"",""ServerType"":12,""Value"":[""0001-01-01T16:21:37""]},{""Name"":""D10Z20_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10Z30_ARR"",""ServerType"":96,""Value"":[""UNITEC01""]},{""Name"":""D10D00_ARR"",""ServerType"":12,""Value"":[null]},{""Name"":""D10D10_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10E00_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10E10_ARR"",""ServerType"":2,""Value"":[910012]},{""Name"":""D10E20_ARR"",""ServerType"":2,""Value"":[910015]},{""Name"":""D10F00_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F10_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F20_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F25_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10G10_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10G20_ARR"",""ServerType"":2,""Value"":[0.0]}]"

    '        'JSON Deserialize 
    '        Dim params As OraParameter() = JsonConvert.DeserializeObject(Of OraParameter())(paramJSON)
    '        Assert.AreEqual(77, params.Length)
    '        For Each item As OraParameter In params
    '            OraDatabase.Parameters.AddTable(item.Name, ORAPARM_INPUT, item.ServerType, 1)
    '            If item.Value IsNot Nothing Then
    '                If item.Value.GetType().IsArray Then
    '                    OraDatabase.Parameters(item.Name).Put_Value(CType(item.Value, Object())(0), 0)
    '                Else
    '                    OraDatabase.Parameters(item.Name).Put_Value(item.Value, 0)
    '                End If
    '            Else
    '                OraDatabase.Parameters(item.Name).Put_Value(item.Value, 0)
    '            End If

    '        Next
    '        Assert.AreEqual(77, OraDatabase.Parameters.Count)

    '        Dim str1 As String = "D10100,D10110,D10120,D10130,D10140,D10150,D10160,D10170,D10180,D10190,D10200,D10210,D10220,D10230,D10240,D10250,D10260,D10270,D10280,D10290,D10300,D10310,D10400,D10410,D10420,D10430,D10500,D10510,D10520,D10530,D10540,D10550,D10560,D10570,D10600,D10610,D10620,D10630,D10640,D10700,D10710,D10720,D10730,D10740,D10750,D10760,D10800,D10810,D10820,D10900,D10910,D10920,D10A00,D10A10,D10B00,D10B10,D10B20,D10Z00,D10Z05,D10Z10,D10Z15,D10Z20,D10Z30,D10A20,D10B30,D10615,D10D00,D10D10,D10E00,D10E10,D10E20,D10F00,D10F10,D10F20,D10F25,D10G10,D10G20"
    '        Dim str2 As String = ":D10100_ARR,:D10110_ARR,:D10120_ARR,:D10130_ARR,:D10140_ARR,:D10150_ARR,:D10160_ARR,:D10170_ARR,:D10180_ARR,:D10190_ARR,:D10200_ARR,:D10210_ARR,:D10220_ARR,:D10230_ARR,:D10240_ARR,:D10250_ARR,:D10260_ARR,:D10270_ARR,:D10280_ARR,:D10290_ARR,:D10300_ARR,:D10310_ARR,:D10400_ARR,:D10410_ARR,:D10420_ARR,:D10430_ARR,:D10500_ARR,:D10510_ARR,:D10520_ARR,:D10530_ARR,:D10540_ARR,:D10550_ARR,:D10560_ARR,:D10570_ARR,:D10600_ARR,:D10610_ARR,:D10620_ARR,:D10630_ARR,:D10640_ARR,:D10700_ARR,:D10710_ARR,:D10720_ARR,:D10730_ARR,:D10740_ARR,:D10750_ARR,:D10760_ARR,:D10800_ARR,:D10810_ARR,:D10820_ARR,:D10900_ARR,:D10910_ARR,:D10920_ARR,:D10A00_ARR,:D10A10_ARR,:D10B00_ARR,:D10B10_ARR,:D10B20_ARR,:D10Z00_ARR,:D10Z05_ARR,:D10Z10_ARR,:D10Z15_ARR,:D10Z20_ARR,:D10Z30_ARR,:D10A20_ARR,:D10B30_ARR,:D10615_ARR,:D10D00_ARR,:D10D10_ARR,:D10E00_ARR,:D10E10_ARR,:D10E20_ARR,:D10F00_ARR,:D10F10_ARR,:D10F20_ARR,:D10F25_ARR,:D10G10_ARR,:D10G20_ARR"
    '        Dim str1Array As String() = str1.Split(",")
    '        Dim str2Array As String() = str2.Split(",")
    '        Dim checkCol As String = String.Empty
    '        For i As Integer = 0 To str1Array.Length - 1
    '            If str2Array(i).Replace("_ARR", "").Replace(":", "") <> str1Array(i) Then
    '                checkCol = checkCol & str1Array(i)
    '            End If
    '        Next

    '        Assert.AreEqual(0, checkCol.Length)

    '        'GEt schema of table
    '        Dim oraDynaset As OraDynaset = OraDatabase.CreateDynaset("SELECT * FROM skfd10 WHERE ROWNUM=1", 0)
    '        'Check DataType
    '        For i As Integer = 0 To oraDynaset.Fields.Count - 1
    '            For Each item As OraParameter In OraDatabase.Parameters
    '                If oraDynaset.Fields(i).Name = item.Name.Replace("_ARR", "") Then
    '                    If item.ServerType <> oraDynaset.Fields(i).OraIDataType Then
    '                        checkCol = checkCol & item.Name & ","
    '                    End If
    '                End If
    '            Next

    '        Next
    '        Assert.AreEqual(0, checkCol.Length)
    '        OraDatabase.Parameters("D10110_ARR").Put_Value(Date.Now.AddDays(1), 0)
    '        Dim OraSqlStmt As OraSqlStmt = OraDatabase.CreateSql(strSQL, 0)
    '        Assert.AreEqual(1, OraSqlStmt.ExecuteNonQueryResult)



    '    Catch ex As Exception
    '        Dim s = ex.Message
    '        Throw
    '    Finally
    '        OraDatabase.Rollback()
    '    End Try


    'End Sub

    '<TestMethod()> Public Sub Parameter_Insert_skfd10_Wrong_Parameters_Columns_Use_BindByName_OK()
    '    'Unit Test SKD100 > Insert_D10
    '    Dim OraDatabase = New TestingFactory().CreateDatabase()
    '    Dim strSQL As String
    '    Dim result As OraSqlStmt
    '    Dim data2 As OraDynaset
    '    Dim id_Arr As OraParameter
    '    Dim date_arr As OraParameter
    '    Try
    '        OraDatabase.BeginTrans()
    '        'Dim insertedCol As List(Of String) = "D10110,D10120,D10140".Split(",").ToList() 'Not NUllable data
    '        'Dim insertedCol As List(Of String) = "D10100,D10110,D10120,D10140".Split(",").ToList() 'No Error
    '        'Dim insertedCol As List(Of String) = "D10110,D10120,D10140,D10100".Split(",").ToList() '=> There will be error when D10100 in the last  
    '        'strSQL = "insert into skfd10 (D10110,D10120,D10140) values(:D10110_ARR,:D10120_ARR,:D10140_ARR)"
    '        Dim insertedCol As List(Of String) = "D10100,D10110,D10120,D10130,D10140,D10150,D10160,D10170,D10180,D10190,D10200,D10210,D10220,D10230,D10240,D10250,D10260,D10270,D10280,D10290,D10300,D10310,D10400,D10410,D10420,D10430,D10500,D10510,D10520,D10530,D10540,D10550,D10560,D10570,D10600,D10610,D10620,D10630,D10640,D10700,D10710,D10720,D10730,D10740,D10750,D10760,D10800,D10810,D10820,D10900,D10910,D10920,D10A00,D10A10,D10B00,D10B10,D10B20,D10Z00,D10Z05,D10Z10,D10Z15,D10Z20,D10Z30,D10A20,D10B30,D10615,D10D00,D10D10,D10E00,D10E10,D10E20,D10F00,D10F10,D10F20,D10F25,D10G10,D10G20".Split(",").ToList()
    '        strSQL = "insert into skfd10 ("
    '        For Each item As String In insertedCol
    '            'Generate the insert statement 
    '            strSQL = strSQL & item & ","
    '        Next
    '        strSQL = strSQL & ")"
    '        strSQL = strSQL & " values("
    '        For Each item As String In insertedCol
    '            'Generate the insert statement 
    '            strSQL = strSQL & ":" & item & "_ARR,"
    '        Next
    '        strSQL = strSQL & ")"

    '        strSQL = strSQL.Replace(",)", ")")
    '        Dim paramJSON As String
    '        paramJSON = " [{""Name"":""D10100_ARR"",""ServerType"":96,""Value"":[""06086""]},{""Name"":""D10110_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10120_ARR"",""ServerType"":2,""Value"":[2651450.0]},{""Name"":""D10130_ARR"",""ServerType"":2,""Value"":[4]},{""Name"":""D10140_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10150_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10160_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10170_ARR"",""ServerType"":2,""Value"":[""07""]},{""Name"":""D10180_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10190_ARR"",""ServerType"":96,""Value"":[""06086""]},{""Name"":""D10200_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10210_ARR"",""ServerType"":2,""Value"":[31]},{""Name"":""D10220_ARR"",""ServerType"":2,""Value"":[2]},{""Name"":""D10230_ARR"",""ServerType"":12,""Value"":[""2020-05-11T00:00:00""]},{""Name"":""D10240_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10250_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10260_ARR"",""ServerType"":2,""Value"":[131]},{""Name"":""D10270_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10280_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10290_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10300_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10310_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10400_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10410_ARR"",""ServerType"":2,""Value"":[8.0]},{""Name"":""D10420_ARR"",""ServerType"":2,""Value"":[1]},{""Name"":""D10430_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10500_ARR"",""ServerType"":2,""Value"":[1]},{""Name"":""D10510_ARR"",""ServerType"":2,""Value"":[14800.0]},{""Name"":""D10520_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10530_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10540_ARR"",""ServerType"":2,""Value"":[14800.0]},{""Name"":""D10550_ARR"",""ServerType"":2,""Value"":[1184.0]},{""Name"":""D10560_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10570_ARR"",""ServerType"":2,""Value"":[2060.0]},{""Name"":""D10600_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10610_ARR"",""ServerType"":96,""Value"":[""御中""]},{""Name"":""D10615_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10620_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10630_ARR"",""ServerType"":96,""Value"":[""01 ""]},{""Name"":""D10640_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10700_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10710_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10720_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10730_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10740_ARR"",""ServerType"":96,""Value"":[""30""]},{""Name"":""D10750_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10760_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10800_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10810_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10820_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10900_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10910_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10920_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10A00_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10A10_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10A20_ARR"",""ServerType"":2,""Value"":[null]},{""Name"":""D10B00_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10B10_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10B20_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10B30_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10Z00_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10Z05_ARR"",""ServerType"":12,""Value"":[""1899-12-30T09:43:31""]},{""Name"":""D10Z10_ARR"",""ServerType"":12,""Value"":[""2020-07-17T00:00:00+09:00""]},{""Name"":""D10Z15_ARR"",""ServerType"":12,""Value"":[""0001-01-01T16:21:37""]},{""Name"":""D10Z20_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10Z30_ARR"",""ServerType"":96,""Value"":[""UNITEC01""]},{""Name"":""D10D00_ARR"",""ServerType"":12,""Value"":[null]},{""Name"":""D10D10_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10E00_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10E10_ARR"",""ServerType"":2,""Value"":[910012]},{""Name"":""D10E20_ARR"",""ServerType"":2,""Value"":[910015]},{""Name"":""D10F00_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F10_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F20_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F25_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10G10_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10G20_ARR"",""ServerType"":2,""Value"":[0.0]}]"

    '        'JSON Deserialize 
    '        Dim params As OraParameter() = JsonConvert.DeserializeObject(Of OraParameter())(paramJSON)
    '        Assert.AreEqual(77, params.Length)
    '        'Check order
    '        Dim wrongOrderColumns As String = String.Empty
    '        For i As Integer = 0 To params.Count - 1
    '            If insertedCol(i) <> params(i).Name.Replace("_ARR", "") Then
    '                wrongOrderColumns = wrongOrderColumns & insertedCol(i) & ","
    '            End If
    '        Next
    '        Assert.IsTrue(wrongOrderColumns.Length > 0)

    '        For Each item As OraParameter In params
    '            If insertedCol.Contains(item.Name.Replace("_ARR", "")) Then
    '                OraDatabase.Parameters.AddTable(item.Name, ORAPARM_INPUT, item.ServerType, 1)
    '                If item.Value IsNot Nothing Then
    '                    If item.Value.GetType().IsArray Then
    '                        OraDatabase.Parameters(item.Name).Put_Value(CType(item.Value, Object())(0), 0)
    '                    Else
    '                        OraDatabase.Parameters(item.Name).Put_Value(item.Value, 0)
    '                    End If
    '                Else
    '                    OraDatabase.Parameters(item.Name).Put_Value(item.Value, 0)
    '                End If
    '            End If
    '        Next
    '        Assert.AreEqual(insertedCol.Count, OraDatabase.Parameters.Count)

    '        OraDatabase.Parameters("D10110_ARR").Put_Value(Date.Now.AddDays(2), 0)
    '        OraDatabase.Parameters("D10100_ARR").Put_Value("06086", 0)
    '        Dim OraSqlStmt As OraSqlStmt = OraDatabase.CreateSql(strSQL, 0)
    '        Assert.AreEqual(1, OraSqlStmt.ExecuteNonQueryResult)



    '    Catch ex As Exception
    '        Dim s = ex.Message
    '        Throw
    '    Finally
    '        OraDatabase.Rollback()
    '    End Try


    'End Sub
    '<TestMethod()> Public Sub Parameter_Insert_skfd10_Wrong_Order_Params_Has_Error()
    '    'Unit Test SKD100 > Insert_D10
    '    Dim OraDatabase = New TestingFactory().CreateDatabase()
    '    Dim strSQL As String
    '    Dim result As OraSqlStmt
    '    Dim data2 As OraDynaset
    '    Dim id_Arr As OraParameter
    '    Dim date_arr As OraParameter
    '    Dim hasError As Boolean = False
    '    Try
    '        OraDatabase.BeginTrans()
    '        'Dim insertedCol As List(Of String) = "D10110,D10120,D10140".Split(",").ToList() 'Not NUllable data
    '        'Dim insertedCol As List(Of String) = "D10100,D10110,D10120,D10140".Split(",").ToList() 'No Error
    '        Dim insertedCol As List(Of String) = "D10110,D10120,D10140,D10100".Split(",").ToList() '=> There will be error when D10100 in the last  
    '        'strSQL = "insert into skfd10 (D10110,D10120,D10140) values(:D10110_ARR,:D10120_ARR,:D10140_ARR)"
    '        strSQL = "insert into skfd10 ("
    '        For Each item As String In insertedCol
    '            'Generate the insert statement 
    '            strSQL = strSQL & item & ","
    '        Next
    '        strSQL = strSQL & ")"
    '        strSQL = strSQL & " values("

    '        For Each item As String In insertedCol
    '            'Generate the insert statement 
    '            strSQL = strSQL & ":" & item & "_ARR,"
    '        Next
    '        strSQL = strSQL & ")"

    '        strSQL = strSQL.Replace(",)", ")")
    '        Dim paramJSON As String
    '        paramJSON = " [{""Name"":""D10100_ARR"",""ServerType"":96,""Value"":[""06086""]},{""Name"":""D10110_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10120_ARR"",""ServerType"":2,""Value"":[2651450.0]},{""Name"":""D10130_ARR"",""ServerType"":2,""Value"":[4]},{""Name"":""D10140_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10150_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10160_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10170_ARR"",""ServerType"":2,""Value"":[""07""]},{""Name"":""D10180_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10190_ARR"",""ServerType"":96,""Value"":[""06086""]},{""Name"":""D10200_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10210_ARR"",""ServerType"":2,""Value"":[31]},{""Name"":""D10220_ARR"",""ServerType"":2,""Value"":[2]},{""Name"":""D10230_ARR"",""ServerType"":12,""Value"":[""2020-05-11T00:00:00""]},{""Name"":""D10240_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10250_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10260_ARR"",""ServerType"":2,""Value"":[131]},{""Name"":""D10270_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10280_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10290_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10300_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10310_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10400_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10410_ARR"",""ServerType"":2,""Value"":[8.0]},{""Name"":""D10420_ARR"",""ServerType"":2,""Value"":[1]},{""Name"":""D10430_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10500_ARR"",""ServerType"":2,""Value"":[1]},{""Name"":""D10510_ARR"",""ServerType"":2,""Value"":[14800.0]},{""Name"":""D10520_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10530_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10540_ARR"",""ServerType"":2,""Value"":[14800.0]},{""Name"":""D10550_ARR"",""ServerType"":2,""Value"":[1184.0]},{""Name"":""D10560_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10570_ARR"",""ServerType"":2,""Value"":[2060.0]},{""Name"":""D10600_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10610_ARR"",""ServerType"":96,""Value"":[""御中""]},{""Name"":""D10615_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10620_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10630_ARR"",""ServerType"":96,""Value"":[""01 ""]},{""Name"":""D10640_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10700_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10710_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10720_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10730_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10740_ARR"",""ServerType"":96,""Value"":[""30""]},{""Name"":""D10750_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10760_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10800_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10810_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10820_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10900_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10910_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10920_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10A00_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10A10_ARR"",""ServerType"":96,""Value"":[null]},{""Name"":""D10A20_ARR"",""ServerType"":2,""Value"":[null]},{""Name"":""D10B00_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10B10_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10B20_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10B30_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10Z00_ARR"",""ServerType"":12,""Value"":[""2019-12-22T00:00:00""]},{""Name"":""D10Z05_ARR"",""ServerType"":12,""Value"":[""1899-12-30T09:43:31""]},{""Name"":""D10Z10_ARR"",""ServerType"":12,""Value"":[""2020-07-17T00:00:00+09:00""]},{""Name"":""D10Z15_ARR"",""ServerType"":12,""Value"":[""0001-01-01T16:21:37""]},{""Name"":""D10Z20_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10Z30_ARR"",""ServerType"":96,""Value"":[""UNITEC01""]},{""Name"":""D10D00_ARR"",""ServerType"":12,""Value"":[null]},{""Name"":""D10D10_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10E00_ARR"",""ServerType"":2,""Value"":[0]},{""Name"":""D10E10_ARR"",""ServerType"":2,""Value"":[910012]},{""Name"":""D10E20_ARR"",""ServerType"":2,""Value"":[910015]},{""Name"":""D10F00_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F10_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F20_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10F25_ARR"",""ServerType"":96,""Value"":[""""]},{""Name"":""D10G10_ARR"",""ServerType"":2,""Value"":[0.0]},{""Name"":""D10G20_ARR"",""ServerType"":2,""Value"":[0.0]}]"

    '        'JSON Deserialize 
    '        Dim params As OraParameter() = JsonConvert.DeserializeObject(Of OraParameter())(paramJSON)
    '        Assert.AreEqual(77, params.Length)


    '        For Each item As OraParameter In params
    '            If insertedCol.Contains(item.Name.Replace("_ARR", "")) Then
    '                OraDatabase.Parameters.AddTable(item.Name, ORAPARM_INPUT, item.ServerType, 1)
    '                If item.Value IsNot Nothing Then
    '                    If item.Value.GetType().IsArray Then
    '                        OraDatabase.Parameters(item.Name).Put_Value(CType(item.Value, Object())(0), 0)
    '                    Else
    '                        OraDatabase.Parameters(item.Name).Put_Value(item.Value, 0)
    '                    End If
    '                Else
    '                    OraDatabase.Parameters(item.Name).Put_Value(item.Value, 0)
    '                End If
    '            End If
    '        Next
    '        Assert.AreEqual(insertedCol.Count, OraDatabase.Parameters.Count)

    '        OraDatabase.Parameters("D10110_ARR").Put_Value(Date.Now, 0)
    '        OraDatabase.Parameters("D10100_ARR").Put_Value("06086", 0)
    '        Dim OraSqlStmt As OraSqlStmt = OraDatabase.CreateSql(strSQL, 0)
    '        Assert.AreEqual(1, OraSqlStmt.ExecuteNonQueryResult)



    '    Catch ex As Exception
    '        Dim s = ex.Message
    '        hasError = True
    '    Finally
    '        OraDatabase.Rollback()
    '        Assert.IsTrue(Not hasError) 'Use BindByName  of OracleCommand will NOT raise error 
    '    End Try


    'End Sub

    <TestMethod()>
    <ExpectedException(GetType(System.FormatException))>
    Public Sub Parameter_Insert_DateString_Error__OK()
        'Unit Test SKD100 > Insert_D10
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim id_Arr As OraParameter
        Dim date_arr As OraParameter
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table skfd10_unittest (ID NUMBER(12,3) DEFAULT 0," &
                         " D10Z15 DATE, primary key(ID))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("ID_Param", ORAPARM_INPUT, ORATYPE_NUMBER, 1)
            OraDatabase.Parameters.AddTable("D10Z15_Param", ORAPARM_INPUT,
                                    ORATYPE_DATE, 1)
            id_Arr = OraDatabase.Parameters("ID_Param")
            date_arr = OraDatabase.Parameters("D10Z15_Param")
            id_Arr.Put_Value(1, 0)
            'date_arr.Put_Value(TimeOfDay, 0) 'Will be 01/01/0001
            date_arr.Put_Value("2020/07/20", 0)
            'Dim paramJSON As String = OraDatabase.GetParametersJSON()
            result = OraDatabase.CreateSql("insert into skfd10_unittest(ID, D10Z15) values(:ID_Param,:D10Z15_Param)", 0&)

            Assert.AreEqual(1, result.ExecuteNonQueryResult)


        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table skfd10_unittest")
            OraDatabase.Rollback()
        End Try



    End Sub

    <TestMethod()>
    Public Sub Insert_Blob_OK()
        'Unit Test SKD100 > Insert_D10
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim id_Arr As OraParameter
        Dim date_arr As OraParameter
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table table_long_raw_unit_test  (ID NUMBER(12,3) DEFAULT 0," &
                         " col01 long raw, primary key(ID))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim fs As FileStream = New FileStream("DataTest\\rose_01.jpg", FileMode.Open, FileAccess.Read)
            Dim data() As Byte
            ReDim data(fs.Length)
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length))
            fs.Close()

            'OraDatabase.Parameters.AddTable("ID_Param", ORAPARM_INPUT, ORATYPE_NUMBER, 1)
            'OraDatabase.Parameters.AddTable("Col01_Param", ORAPARM_INPUT,
            '                        ORATYPE_BINARY, 1)
            'id_Arr = OraDatabase.Parameters("ID_Param")
            'date_arr = OraDatabase.Parameters("Col01_Param")
            'id_Arr.Put_Value(1, 0)
            'date_arr.Put_Value(data, 0)
            ''Dim paramJSON As String = OraDatabase.GetParametersJSON()
            'result = OraDatabase.CreateSql("insert into table_long_raw_unit_test(ID, col01) values(:ID_Param,:Col01_Param)", 0&)

            'Assert.AreEqual(1, result.ExecuteNonQueryResult)

            Dim stmt As OracleCommand = New OracleCommand()
            stmt.CommandText = "insert into table_long_raw_unit_test values(:id, :col01)"
            stmt.Connection = OraDatabase.Session.OracleConnection
            stmt.CommandType = CommandType.Text

            stmt.Parameters.Add("id", OracleDbType.Int32).Value = 1
            stmt.Parameters.Add("col01", OracleDbType.LongRaw).Value = data

            stmt.ExecuteNonQuery()

            'Read to test 
            Dim stmt2 As OracleCommand = New OracleCommand()
            stmt2.CommandText = "select col01 from table_long_raw_unit_test where id = :id"
            stmt2.Connection = OraDatabase.Session.OracleConnection
            stmt2.CommandType = CommandType.Text

            stmt2.Parameters.Add("id", OracleDbType.Int32).Value = 1

            stmt2.InitialLONGFetchSize = -1 'Read all

            Dim reader As OracleDataReader = stmt2.ExecuteReader()

            reader.Read()
            Dim col01Data As OracleBinary = reader.GetOracleBinary(0)
            'Assert.AreEqual(col01Data.Value, data) 'Exception
            Assert.AreEqual(col01Data.Value.Length, data.Length)
            Dim data2() As Byte
            data2 = CType(col01Data.Value, Byte())


            For i As Integer = 0 To data.Length - 1
                Assert.AreEqual(data2(i), data(i))
            Next
        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table table_long_raw_unit_test")
            OraDatabase.Rollback()
        End Try



    End Sub

    <TestMethod()>
    <ExpectedException(GetType(Oracle.ManagedDataAccess.Client.OracleException))> 'ORA-22835: buffer too small for CLOB to CHAR or BLOB to RAW conversio
    Public Sub Insert_Blob_With_Chunk_Exception()
        'Unit Test SKD100 > Insert_D10
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Dim strSQL As String
        Dim result As OraSqlStmt
        Dim data2 As OraDynaset
        Dim id_Arr As OraParameter
        Dim date_arr As OraParameter
        Try
            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table table_long_raw_unit_test  (ID NUMBER(12,3) DEFAULT 0," &
                         " col01 long raw, primary key(ID))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            Dim fs As FileStream = New FileStream("DataTest\\rose_01.jpg", FileMode.Open, FileAccess.Read)
            Dim data() As Byte
            ReDim data(fs.Length)
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length))
            fs.Close()

            'OraDatabase.Parameters.AddTable("ID_Param", ORAPARM_INPUT, ORATYPE_NUMBER, 1)
            'OraDatabase.Parameters.AddTable("Col01_Param", ORAPARM_INPUT,
            '                        ORATYPE_BINARY, 1)
            'id_Arr = OraDatabase.Parameters("ID_Param")
            'date_arr = OraDatabase.Parameters("Col01_Param")
            'id_Arr.Put_Value(1, 0)
            'date_arr.Put_Value(data, 0)
            ''Dim paramJSON As String = OraDatabase.GetParametersJSON()
            'result = OraDatabase.CreateSql("insert into table_long_raw_unit_test(ID, col01) values(:ID_Param,:Col01_Param)", 0&)

            'Assert.AreEqual(1, result.ExecuteNonQueryResult)
            Dim blob As OracleBlob = New OracleBlob(OraDatabase.Session.OracleConnection, OracleDbType.Blob)
            Dim streamLength As Int32 = data.Length

            Dim intNumChunks As Int32
            Dim MC_TEMP_BUFF_SIZE As Int32 = 2000
            intNumChunks = streamLength \ MC_TEMP_BUFF_SIZE

            Dim dblWriteSize As Int32
            Dim lngTotalSize As Int32 = streamLength
            Dim abytWriteBuff() As Byte

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

                'FileGet(intFileNum, abytWriteBuff) 'Read from file 

                blob.Write(data, intWritePosi * MC_TEMP_BUFF_SIZE, dblWriteSize)
            Next intWritePosi




            Dim stmt As OracleCommand = New OracleCommand()
            stmt.CommandText = "insert into table_long_raw_unit_test values(:id, :col01)"
            stmt.Connection = OraDatabase.Session.OracleConnection
            stmt.CommandType = CommandType.Text

            stmt.Parameters.Add("id", OracleDbType.Int32).Value = 1
            stmt.Parameters.Add("col01", OracleDbType.Blob).Value = blob

            stmt.ExecuteNonQuery() 'Will have exception ORA-22835: buffer too small for CLOB to CHAR or BLOB to RAW conversio

            'Read to test 
            Dim stmt2 As OracleCommand = New OracleCommand()
            stmt2.CommandText = "select col01 from table_long_raw_unit_test where id = :id"
            stmt2.Connection = OraDatabase.Session.OracleConnection
            stmt2.CommandType = CommandType.Text

            stmt2.Parameters.Add("id", OracleDbType.Int32).Value = 1

            stmt2.InitialLONGFetchSize = -1 'Read all

            Dim reader As OracleDataReader = stmt2.ExecuteReader()

            reader.Read()
            Dim col01Data As OracleBinary = reader.GetOracleBinary(0)
            Assert.AreEqual(col01Data.Value, data)

        Catch ex As Exception
            Dim s = ex.Message
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table table_long_raw_unit_test")
            OraDatabase.Rollback()
        End Try



    End Sub

    <TestMethod()> Public Sub CreateDynasetLongRaw_OK()

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
            Dim objDynaset As OraDynaset = OraDatabase.CreateDynasetLongRaw(sql, &H10)
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

    <TestMethod()> Public Sub ExecuteSQL_With_Array_Parameter_In_SQL_Text()
        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String
            Dim result As Integer
            Dim data2 As OraDynaset
            Dim PartNoArray() As Object
            Dim DescArray() As Object
            Dim I As Integer

            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos2(partno number," &
                             "description char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION2", ORAPARM_INPUT,
                                        ORATYPE_CHAR, 10, 50)
            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION2").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For I = 0 To 9
                achar = "Description" + Str(I)
                PartNoArray(I) = 1000 + I
                DescArray(I) = achar
            Next I

            Dim intData() As Int64 = {12, 16, 20, 24, 28, 32}

            Dim countData As Integer
            countData = intData.Length
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DECLARE  "
            strSQL = strSQL & Chr(10) & "  IDX            NUMBER(5); "
            strSQL = strSQL & Chr(10) & "BEGIN  "
            'strSQL = strSQL & Chr(10) & "  CNT := 0; "
            'strSQL = strSQL & Chr(10) & "  FOR IDX IN 1.." & VB6.Format(countData, "#") & " LOOP "
            strSQL = strSQL & Chr(10) & "  FOR IDX IN 1.." & VB6.Format(countData, "#") & " LOOP "
            strSQL = strSQL & Chr(10) & "      IF :PARTNO(IDX) IS NOT NULL THEN "
            strSQL = strSQL & Chr(10) & "            INSERT INTO part_nos2 "
            strSQL = strSQL & Chr(10) & "               VALUES ("
            strSQL = strSQL & Chr(10) & "                :PARTNO(IDX),"
            'strSQL = strSQL & Chr(10) & "                ':DESCRIPTION2(IDX)'"
            strSQL = strSQL & Chr(10) & "                'AAAA'"
            strSQL = strSQL & Chr(10) & "                 );  "
            strSQL = strSQL & Chr(10) & "      END IF; "
            strSQL = strSQL & Chr(10) & "  END LOOP;"
            strSQL = strSQL & Chr(10) & " END; "
            'result = OraDatabase.ExecuteSQL2(strSQL)

            Dim stmt As OracleCommand = New OracleCommand()
            stmt.CommandText = strSQL
            stmt.Connection = OraDatabase.Session.OracleConnection
            stmt.CommandType = CommandType.Text
            'stmt.Parameters.Add("PARTNO", PartNoArray)
            'stmt.ArrayBindCount = PartNoArray.Length
            Dim Param1 As OracleParameter = stmt.Parameters.Add("PARTNO", OracleDbType.Int64) ' https : //docs.oracle.com/cd/E14435_01/win.111/e10927/featOraCommand.htm#i1007222
            Param1.Direction = ParameterDirection.Input
            Param1.CollectionType = OracleCollectionType.PLSQLAssociativeArray

            Dim prm As OracleParameter = New OracleParameter("PARTNO", OracleDbType.Int64)

            prm.Direction = ParameterDirection.Input

            'prm.Value = PartNoArray

            prm.Value = intData
            'stmt.Parameters.Add(prm)
            Param1.Value = intData
            stmt.ExecuteNonQuery()

            Dim dynaData As OraDynaset
            dynaData = OraDatabase.CreateDynaset("SELECT * FROM part_nos2", 0)
            Assert.AreEqual(intData.Length, dynaData.RecordCount)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            'OraDatabase.ExecuteSQL("drop table part_nos2")


        Catch ex As Exception
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos2")
            OraDatabase.Rollback()
        End Try

    End Sub

    <TestMethod()> Public Sub ExecuteSQLTextWithArrayParameter_OK()
        'Follow https://docs.oracle.com/cd/E11882_01/win.112/e17727/serobjch019.htm#OOFOL398
        Dim OraDatabase = New TestingFactory().CreateDatabase()
        Try
            Dim strSQL As String
            Dim result As Integer
            Dim data2 As OraDynaset
            Dim PartNoArray() As Object
            Dim DescArray() As Object
            Dim I As Integer

            OraDatabase.BeginTrans()
            OraDatabase.ExecuteSQL("create table part_nos(partno number," &
                             "description2 char(50), primary key(partno))")

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)

            OraDatabase.Parameters.AddTable("PARTNO", ORAPARM_INPUT, ORATYPE_NUMBER, 10, 22)
            OraDatabase.Parameters.AddTable("DESCRIPTION2", ORAPARM_INPUT,
                                        ORATYPE_CHAR, 10, 50)
            PartNoArray = OraDatabase.Parameters("PARTNO").Value
            DescArray = OraDatabase.Parameters("DESCRIPTION2").Value

            Dim achar As String = String.Empty
            'Initialize arrays 
            For I = 0 To 9
                achar = "Description" + Str(I)
                PartNoArray(I) = 1000 + I
                DescArray(I) = achar
            Next I

            Dim countData As Integer
            countData = PartNoArray.Length

            strSQL = ""
            strSQL = strSQL & Chr(10) & "DECLARE  "
            strSQL = strSQL & Chr(10) & "  IDX            NUMBER(5); "
            strSQL = strSQL & Chr(10) & "BEGIN  "
            'strSQL = strSQL & Chr(10) & "  CNT := 0; "
            'strSQL = strSQL & Chr(10) & "  FOR IDX IN 1.." & VB6.Format(countData, "#") & " LOOP "
            strSQL = strSQL & Chr(10) & "  FOR IDX IN 1.." & VB6.Format(countData, "#") & " LOOP "
            strSQL = strSQL & Chr(10) & "      IF :PARTNO(IDX) IS NOT NULL THEN "
            strSQL = strSQL & Chr(10) & "            INSERT INTO part_nos "
            strSQL = strSQL & Chr(10) & "               VALUES ("
            strSQL = strSQL & Chr(10) & "                :PARTNO(IDX),"
            strSQL = strSQL & Chr(10) & "                ':DESCRIPTION2(IDX)'"
            'strSQL = strSQL & Chr(10) & "                'AAAA'"
            strSQL = strSQL & Chr(10) & "                 );  "
            strSQL = strSQL & Chr(10) & "      END IF; "
            strSQL = strSQL & Chr(10) & "  END LOOP;"
            strSQL = strSQL & Chr(10) & " END; "
            result = OraDatabase.ExecuteSQLTextWithArrayParameter(strSQL)

            Dim dynaData As OraDynaset
            dynaData = OraDatabase.CreateDynaset("SELECT * FROM part_nos", 0)
            Assert.AreEqual(PartNoArray.Length, dynaData.RecordCount)

            'Make sure there's no error
            Assert.AreEqual(OraDatabase.LastServerErr, 0)
            'OraDatabase.ExecuteSQL("drop table part_nos2")


        Catch ex As Exception
            Throw
        Finally
            OraDatabase.ExecuteSQL("drop table part_nos")
            OraDatabase.Rollback()
        End Try

    End Sub


End Class