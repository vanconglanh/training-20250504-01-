Option Strict Off
Option Explicit On
Imports MKOra.Core
Imports Common
Friend Class clsRegisterSystemDll
    '******************************************************************************
    ' ÌßÛŒÞªžÄŒ  : ljVXe€Ê
    ' t@CŒ  : RegisterSystemDll.cls
    ' à    e    : ljVXeckk WXg o^ NX W[
    ' õ    l    :
    ' Öê    : <Public>
    '                   DBConnect              (caÚ±)
    '                   DBObjectSet            (caIuWFNgÝè)
    '                   RegisterDLL            (ljVXeckk WXg o^)
    '               <Private>
    '                   msubRegistServer       (WXg o^)
    '                   msubUnRegistServer     (WXg o^ð)
    '               <Property>
    '                   SystemName             I  (ckko^ÎÛ VXeŒ)
    '               <Events>
    '                   Class_Initialize       (NXúÝè)
    '                   Class_Terminate        (caØf)
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    '==============================================================================
    ' è
    '==============================================================================
    Private Const MC_CMD_REGSVR32 As String = "regsvr32"
    Private Const MC_PRAM_REGSVR As String = "/RegServer"
    Private Const MC_PRAM_UN_REGSVR As String = "/UnRegServer"

    Private Const MC_EXECUTE_OTHER As Short = 0
    Private Const MC_EXECUTE_DLL As Short = 1
    Private Const MC_EXECUTE_EXE As Short = 2

    '==============================================================================
    ' Ï
    '==============================================================================
    Private mblnDBConnect As Boolean ' DBÚ±tO(TrueFÚ±)
    Private mblnDBObject As Boolean ' DBÚ±IuWFNgÝètO(TrueFÝè)
    Private mstrSystemName As String ' DLL¯Ê
    '++C³Jn@2021N0918ú:MKièj- VBšVB.NETÏ·
    'Private mobjOraSession As Object
    Private mobjOraSession As OraSession
    '--C³Jn@2021N0918ú:MKièj- VBšVB.NETÏ·
    '++C³Jn@2021N0527:MKic[j- OR_002 VBšVB.NETÏ·
    'Private mobjOraDatabase As Object
    Private mobjOraDatabase As OraDatabase
    '--C³I¹@2021N0527:MKic[j- OR_002 VBšVB.NETÏ·
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' Cxg
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' Ö  Œ  : Class_Initialize
    ' XR[v  : Public
    ' àe  : ljVXeckk WXg o^ NX úÝè
    ' õ    l  :
    ' Ô è l  :
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Initialize"
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Try
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Initialize"
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            mblnDBConnect = False

            mblnDBObject = False

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:040bb9da-76d9-4560-bccc-ce073f358789
            'PROC_END:

            'Exit Sub

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'PROC_ERROR:
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:040bb9da-76d9-4560-bccc-ce073f358789
        Catch ex As Exception
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
            'Resume PROC_END
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Try
        '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
PROC_FINALLY_END:
        Exit Sub
        '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
        '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    '******************************************************************************
    ' Ö  Œ  : Class_Terminate
    ' XR[v  : Public
    ' àe  : caØf
    ' õ    l  :
    ' Ô è l  :
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Terminate"
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Try
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Class_Terminate"
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
            'PROC_END:

            'Exit Sub

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'PROC_ERROR:
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:5eaa803f-a989-4f7e-8c92-0bd02eff47c4
        Catch ex As Exception
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
            'Resume PROC_END
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:9c033dea-e61b-4ac7-86d6-964d68ee7521

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Try
        '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
PROC_FINALLY_END:
        Exit Sub
        '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
        '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' \bh
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' Ö  Œ  : DBConnect
    ' XR[v  : Public
    ' àe  : caÚ±
    ' õ    l  :
    ' Ô è l  :
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrUserName        String            I     [UŒ
    '   pstrPassWord        String            I     pX[h
    '   pstrTNS             String            I     smrŒ
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBConnect"
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Try
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBConnect"
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            '++C³Jn@2021N0527:MKic[j- OR_005 VBšVB.NETÏ·
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()

            '--C³I¹@2021N0527:MKic[j- OR_005 VBšVB.NETÏ·

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
            'PROC_END:

            'Exit Sub

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'PROC_ERROR:
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:9c033dea-e61b-4ac7-86d6-964d68ee7521
        Catch ex As Exception
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:4a972f61-d1fe-4382-ae01-3523db60591d
            'Resume PROC_END
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:4a972f61-d1fe-4382-ae01-3523db60591d

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Try
        '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:4a972f61-d1fe-4382-ae01-3523db60591d
PROC_FINALLY_END:
        Exit Sub
        '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:4a972f61-d1fe-4382-ae01-3523db60591d
        '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
    End Sub
    '******************************************************************************
    ' Ö  Œ  : DBObjectSet
    ' XR[v  : Public
    ' àe  : caIuWFNgÝè
    ' õ    l  :
    ' Ô è l  :
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDataBase
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBObjectSet"
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Try
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_DBObjectSet"
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:4a972f61-d1fe-4382-ae01-3523db60591d
            'PROC_END:

            'Exit Sub

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'PROC_ERROR:
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:4a972f61-d1fe-4382-ae01-3523db60591d
        Catch ex As Exception
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:6affe531-11f4-4232-84f4-1bf63794a246
            'Resume PROC_END
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:6affe531-11f4-4232-84f4-1bf63794a246

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Try
        '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:6affe531-11f4-4232-84f4-1bf63794a246
PROC_FINALLY_END:
        Exit Sub
        '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:6affe531-11f4-4232-84f4-1bf63794a246
        '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
    End Sub
    '******************************************************************************
    ' Ö  Œ  : RegisterDLL
    ' XR[v  : Public
    ' àe  : ljVXeckk WXg o^
    ' õ    l  :
    ' Ô è l  : True iÙíI¹j
    '             Falsei³íI¹j
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrProgId          String            I     vOhc
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    Public Function RegisterDLL(Optional ByVal pstrProgId As String = "") As Boolean


        '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_LoadLogin"
        Dim strSQL As String
        '++C³Jn@2021N0911ú:MKièj- VBšVB.NETÏ·
        'Dim objDysDLLo^e[u As Object
        Dim objDysDLLo^e[u As OraDynaset
        '--C³Jn@2021N0911ú:MKièj- VBšVB.NETÏ·
        Dim strFilePathReg As String ' WXgÉo^³êÄ¢ét@CpX
        Dim strFilePath As String ' o^ÎÛÆÈét@CpX
        Dim strVersionReg As String ' WXgÉo^³êÄ¢ét@CÌo[W
        Dim strVersion As String ' o^ÎÛÆÈét@CÌo[W
        Dim vntClsid As Object
        Dim intExecuteKbn As Short ' g£qæª(0:DLL,1:EXE)
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Try
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·


            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            If Len(mstrSystemName) = 0 Then
                Exit Function
            End If

            '2022/08/22«@ÀsµÈ¢æ€C³FTSSçZ
            Exit Function
            '2022/08/22ª

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    o`sgŒ "
            strSQL = strSQL & Chr(10) & "  , ckkŒ   "
            strSQL = strSQL & Chr(10) & "  , PROGID     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "   ckko^e[u "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "   ckk¯Ê = '" & mstrSystemName & "' "

            If pstrProgId <> "" Then

                strSQL = strSQL & Chr(10) & "AND PROGID     = '" & pstrProgId & "' "

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysDLLo^e[u = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysDLLo^e[u

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    '------------------------------------------------------------------
                    ' o^ÎÛ t@CpX æŸ
                    '------------------------------------------------------------------
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysDLLo^e[u.Fields(ckkŒ).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strFilePath = gfncFieldVal(.Fields("o`sgŒ").Value) & gfncFieldVal(.Fields("ckkŒ").Value)

                    '------------------------------------------------------------------
                    ' g£qæª Ýè
                    '------------------------------------------------------------------
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++C³Jn@2021N0409:OneTechic[j- VB_002 VBšVB.NETÏ·
                    'If InStr(StrConv(gfncFieldVal(.Fields("ckkŒ").Value), VbStrConv.UpperCase), ".DLL") <> 0 Then
                    If InStr(Utils.StrConv(gfncFieldVal(.Fields("ckkŒ").Value), VbStrConv.Uppercase), ".DLL") <> 0 Then
                        '--C³I¹@2021N0409:OneTechic[j- VB_002 VBšVB.NETÏ·

                        intExecuteKbn = MC_EXECUTE_DLL

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        '++C³Jn@2021N0409:OneTechic[j- VB_002 VBšVB.NETÏ·
                        'ElseIf InStr(StrConv(gfncFieldVal(.Fields("ckkŒ").Value), VbStrConv.UpperCase), ".EXE") <> 0 Then
                    ElseIf InStr(Utils.StrConv(gfncFieldVal(.Fields("ckkŒ").Value), VbStrConv.Uppercase), ".EXE") <> 0 Then
                        '--C³I¹@2021N0409:OneTechic[j- VB_002 VBšVB.NETÏ·

                        intExecuteKbn = MC_EXECUTE_EXE

                    Else

                        intExecuteKbn = MC_EXECUTE_OTHER

                    End If

                    '------------------------------------------------------------------
                    ' WXg t@CpX æŸ
                    '------------------------------------------------------------------
                    strFilePathReg = ""

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysDLLo^e[u.Fields(PROGID).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gfncFieldVal(.Fields("PROGID").Value) <> "" Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        vntClsid = gfncGetRegValue(basGetRegValue.hKeyConstants.HKEY_LOCAL_MACHINE, "SOFTWARE\Classes\" & gfncFieldVal(.Fields("PROGID").Value) & "\Clsid", "", basGetRegValue.RegTypeConstants.REG_SZ, "")

                        'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If vntClsid <> "" Then

                            If intExecuteKbn = MC_EXECUTE_DLL Then

                                'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                strFilePathReg = gfncGetRegValue(basGetRegValue.hKeyConstants.HKEY_LOCAL_MACHINE, "SOFTWARE\Classes\CLSID\" & vntClsid & "\InprocServer32", "", basGetRegValue.RegTypeConstants.REG_SZ, "")

                            ElseIf intExecuteKbn = MC_EXECUTE_EXE Then

                                'UPGRADE_WARNING: Couldn't resolve default property of object vntClsid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetRegValue(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                strFilePathReg = gfncGetRegValue(basGetRegValue.hKeyConstants.HKEY_LOCAL_MACHINE, "SOFTWARE\Classes\CLSID\" & vntClsid & "\LocalServer32", "", basGetRegValue.RegTypeConstants.REG_SZ, "")

                            Else

                                ' Èµ

                            End If

                        End If

                    End If

                    '------------------------------------------------------------------
                    ' o^ÎÛ t@CpX æŸ
                    '------------------------------------------------------------------
                    ' WXgÉo^³êÄ¢È¢ê
                    If strFilePathReg = "" Then

                        ' WXgÉo^
                        Call msubRegistServer(intExecuteKbn, strFilePath)

                        ' WXgÉo^³êÄ¢éê
                    Else

                        ' WXgÉo^³êÄ¢ét@CpXÆ
                        ' o^ÎÛÆÈét@CpXªêvµÈ¢ê
                        '++C³Jn@2021N0409:OneTechic[j- VB_002 VBšVB.NETÏ·
                        'If StrConv(strFilePathReg, VbStrConv.UpperCase) <> StrConv(strFilePath, VbStrConv.UpperCase) Then
                        If Utils.StrConv(strFilePathReg, VbStrConv.Uppercase) <> Utils.StrConv(strFilePath, VbStrConv.Uppercase) Then
                            '--C³I¹@2021N0409:OneTechic[j- VB_002 VBšVB.NETÏ·

                            ' »Ý, WXgÉo^³êÄ¢éîñðí
                            Call msubUnRegistServer(intExecuteKbn, strFilePathReg)

                            ' WXgÉo^
                            Call msubRegistServer(intExecuteKbn, strFilePath)

                            ' WXgÉo^³êÄ¢ét@CpXÆ
                            ' o^ÎÛÆÈét@CpXªêv·éê
                        Else

                            ' o^ÎÛvOhcªwè³êÄ¢éê
                            If pstrProgId <> "" Then

                                ' »Ý, WXgÉo^³êÄ¢éîñðí
                                Call msubUnRegistServer(intExecuteKbn, strFilePathReg)

                                ' WXgÉo^
                                Call msubRegistServer(intExecuteKbn, strFilePath)

                            End If

                        End If

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDLLo^e[u.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            ' ßèlðÝèi³íI¹j
            RegisterDLL = False

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:6affe531-11f4-4232-84f4-1bf63794a246
            'PROC_END:

            'Call gsubClearObject(objDysDLLo^e[u)

            'Exit Function

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'PROC_ERROR:
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:6affe531-11f4-4232-84f4-1bf63794a246
        Catch ex As Exception
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
            'Resume PROC_END
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Try
        '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
PROC_FINALLY_END:
        Call gsubClearObject(objDysDLLo^e[u)
        Exit Function
        '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
        '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
    End Function
    '******************************************************************************
    ' Ö  Œ  : msubRegistServer
    ' XR[v  : Public
    ' àe  : WXg o^
    ' õ    l  :
    ' Ô è l  : True iÙíI¹j
    '             Falsei³íI¹j
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '   pintExecuteKbn      Integer           I     g£qæª(0:DLL,1:EXE)
    '   pstrRegFilePath     String            I     t@CpX
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    Private Sub msubRegistServer(ByVal pintExecuteKbn As Short, ByVal pstrRegFilePath As String)

        '++C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubRegistServer"
        Dim strCommandLine As String
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        '--C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·

        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        'Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubRegistServer"
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

        Try

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Dim strCommandLine As String
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            ' o^ÎÛÆÈét@Cª¶ÝµÈ¢ê
            If gfncCheckFileExists(pstrRegFilePath) = False Then

                '++C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·
                'GoTo PROC_END
                Exit Sub
                '--C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·

            End If

            ' g£qªckkÌê
            If pintExecuteKbn = MC_EXECUTE_DLL Then

                '++C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·
                strCommandLine = MC_CMD_REGSVR32 & " /s " & pstrRegFilePath
                'strCommandLine = MC_CMD_REGSVR32 & " " & pstrRegFilePath
                '--C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·

                ' g£qªdwdÌê
            ElseIf pintExecuteKbn = MC_EXECUTE_EXE Then

                strCommandLine = pstrRegFilePath & " " & MC_PRAM_REGSVR

                ' ãLÈOÌê
            Else

                '++C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·
                'GoTo PROC_END
                Exit Sub
                '--C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·

            End If

            Debug.Print(strCommandLine)

            ' WXgÉo^
            If gfncExecWait(strCommandLine, AppWinStyle.Hide) = False Then

                '++C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·
                'GoTo PROC_END
                Exit Sub
                '--C³Jn@2021N0530ú:MKièj- VBšVB.NETÏ·

            End If

        Catch ex As Exception
            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

    End Sub
    '******************************************************************************
    ' Ö  Œ  : msubUnRegistServer
    ' XR[v  : Public
    ' àe  : WXg o^ð
    ' õ    l  :
    ' Ô è l  : True iÙíI¹j
    '             Falsei³íI¹j
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '   pintExecuteKbn      Integer           I     g£qæª(0:DLL,1:EXE)
    '   pstrRegFilePath     String            I     t@CpX
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    Private Sub msubUnRegistServer(ByVal pintExecuteKbn As Short, ByVal pstrRegFilePath As String)

        '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubUnRegistServer"
        Dim strCommandLine As String
        '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
        Try
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Const C_NAME_FUNCTION As String = "clsRegisterDLL_msubUnRegistServer"
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            'Dim strCommandLine As String
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

            ' o^ÎÛÆÈét@Cª¶ÝµÈ¢ê
            If gfncCheckFileExists(pstrRegFilePath) = False Then

                '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            ' g£qªckkÌê
            If pintExecuteKbn = MC_EXECUTE_DLL Then

                strCommandLine = MC_CMD_REGSVR32 & " /u /s " & pstrRegFilePath

                ' g£qªdwdÌê
            ElseIf pintExecuteKbn = MC_EXECUTE_EXE Then

                strCommandLine = pstrRegFilePath & " " & MC_PRAM_UN_REGSVR

                ' ãLÈOÌê
            Else

                '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            Debug.Print(strCommandLine)

            ' WXgÉo^
            If gfncExecWait(strCommandLine, AppWinStyle.Hide) = False Then

                '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb

            End If

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
            'PROC_END:

            'Exit Sub

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'PROC_ERROR:
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:1a00ea25-bb11-4192-9149-f43bb085bedb
        Catch ex As Exception
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
            'Resume PROC_END
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:d3fd7d54-76eb-48f1-9259-e26a42691f60

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Try
        '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
PROC_FINALLY_END:
        Exit Sub
        '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
        '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' vpeB
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' Ö  Œ  : SystemName
    ' XR[v  : Public
    ' àe  : ckko^ÎÛ VXeŒ Ýè
    ' õ    l  :
    ' Ô è l  :
    ' ø «   :
    '   Êß×Ò°ÀŒ            ÃÞ°ÀÀ²Ìß          I/O   à Ÿ
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ckko^ÎÛ VXeŒ
    '
    ' ÏXð  :
    '   Version     ú  t        Œ             C³àe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/06/18  Aä  FŸ         VKì¬
    '
    '******************************************************************************
    Public WriteOnly Property SystemName() As String
        Set(ByVal Value As String)

            '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            'On Error GoTo PROC_ERROR
            '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            Const C_NAME_FUNCTION As String = "clsRegisterDLL_Let_SystemName"
            '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
            Try
                '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

                '++C³Jn@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·
                'Const C_NAME_FUNCTION As String = "clsRegisterDLL_Let_SystemName"
                '--C³I¹@2021N0601:MKic[j- VB_530 VBšVB.NETÏ·

                mstrSystemName = Value

                '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
                'PROC_END:

                'Exit Property

                '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
                'PROC_ERROR:
                '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:d3fd7d54-76eb-48f1-9259-e26a42691f60
            Catch ex As Exception
                '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

                '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:481479b9-ce09-4364-99b5-5c21d21ecafb
                'Resume PROC_END
                '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:481479b9-ce09-4364-99b5-5c21d21ecafb

                '++C³Jn@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
            End Try
            '++C³Jn@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:481479b9-ce09-4364-99b5-5c21d21ecafb
PROC_FINALLY_END:
            Exit Property
            '--C³I¹@2021N0601:MKic[j- VB_523 VBšVB.NETÏ·	T:481479b9-ce09-4364-99b5-5c21d21ecafb
            '--C³I¹@2021N0601:MKic[j- VB_522 VBšVB.NETÏ·
        End Set
    End Property
End Class

