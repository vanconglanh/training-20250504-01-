Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstZipCode
    '******************************************************************************
    ' ĖßÛžÞŠļÄž  : ljVXeĪĘ
    ' t@Cž  : UnitMstZipCode.cls
    ' ā    e    : XÖÔ}X^ îņ i[ NX W[
    ' õ    l    :
    ' Öę    : <Public>
    '               <Private>
    '               <Property>
    '                   SnûöĪcĖR[h I/O
    '                   XÖÔ             I/O
    '                   XÖÔ               I/O
    '                   sđ{§žJi         I/O
    '                   sæŽšžJi         I/O
    '                   ŽæžJi             I/O
    '                   sđ{§ž             I/O
    '                   sæŽšž             I/O
    '                   Žæž                 I/O
    '                   ęŽæĄÔ         I/O
    '                   ÔnîÔ\Ķ           I/O
    '                   Ú\Ķ               I/O
    '                   ęÔĄŽæ         I/O
    '                   XV\Ķ               I/O
    '                   ÏXR               I/O
    '               <Events>
    '                   Class_Initialize       (NXúÝč)
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '==============================================================================
    ' č
    '==============================================================================
    Private Const MC_TABLE_XÖÔ}X^ As String = "XÖÔ}X^"
    Private Const MC_TABLE_åûÆÂĘXÖÔ}X^ As String = "åûÆÂĘXÖÔ}X^"

    '==============================================================================
    ' Ï
    '==============================================================================
    '++CģJn@2021N0608:MKic[j- OR_005 VBĻVB.NETÏ·
    'Private mobjOraSession As Object ' Oracle
    Private mobjOraSession As OraSession ' Oracle
    '--CģIđ@2021N0608:MKic[j- OR_005 VBĻVB.NETÏ·
    '++CģJn@2021N0608:MKic[j- OR_002 VBĻVB.NETÏ·
    'Private mobjOraDatabase As Object ' Oracle
    Private mobjOraDatabase As OraDatabase ' Oracle
    '--CģIđ@2021N0608:MKic[j- OR_002 VBĻVB.NETÏ·
    Private mblnDBConnect As Boolean ' DBÚątO(TrueFÚą)
    Private mblnDBObject As Boolean ' DBÚąIuWFNgÝčtO(TrueFÝč)

    Private mstrSnûöĪcĖR[h As String
    Private mstrXÖÔ As String
    Private mstrXÖÔ As String
    Private mstrsđ{§žJi As String
    Private mstrsæŽšžJi As String
    Private mstrŽæžJi As String
    Private mstrsđ{§ž As String
    Private mstrsæŽšž As String
    Private mstrŽæž As String
    Private mstręŽæĄÔ As String
    Private mstrÔnîÔ\Ķ As String
    Private mstrÚ\Ķ As String
    Private mstręÔĄŽæ As String
    Private mstrXV\Ķ As String
    Private mstrÏXR As String
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' Cxg
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' Ö  ž  : Class_Initialize
    ' XR[v  : Public
    ' āe  : XÖÔ}X^ îņ i[ NX úÝč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_Class_Initialize"
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·


            mblnDBConnect = False

            mblnDBObject = False

            mstrSnûöĪcĖR[h = ""
            mstrXÖÔ = ""
            mstrXÖÔ = ""
            mstrsđ{§žJi = ""
            mstrsæŽšžJi = ""
            mstrŽæžJi = ""
            mstrsđ{§ž = ""
            mstrsæŽšž = ""
            mstrŽæž = ""
            mstręŽæĄÔ = ""
            mstrÔnîÔ\Ķ = ""
            mstrÚ\Ķ = ""
            mstręÔĄŽæ = ""
            mstrXV\Ķ = ""
            mstrÏXR = ""

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:16c1dff7-e424-42ea-a497-b58ade5310c2
            'PROC_END:

            'Exit Sub

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:16c1dff7-e424-42ea-a497-b58ade5310c2
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
PROC_FINALLY_END:
        Exit Sub
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    '******************************************************************************
    ' Ö  ž  : Class_Terminate
    ' XR[v  : Public
    ' āe  : caØf
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to
    '. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_Class_Terminate"
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·


            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
            'PROC_END:

            'Exit Sub

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ca10fedb-1d9a-481b-b565-cec4dc8cfd68
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
PROC_FINALLY_END:
        Exit Sub
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' \bh
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' Ö  ž  : DBConnect
    ' XR[v  : Public
    ' āe  : caÚą
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrUserName        String            I     [Už
    '   pstrPassWord        String            I     pX[h
    '   pstrTNS             String            I     smrž
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_DBConnect"
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·


            '++CģJn@2021N0608:MKic[j- OR_005 VBĻVB.NETÏ·
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()
            '--CģIđ@2021N0608:MKic[j- OR_005 VBĻVB.NETÏ·

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
            'PROC_END:

            'Exit Sub

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:a1ba0692-61fa-48e3-b47a-a52ff8c55cee
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:333a73df-4e06-4126-a016-5b0270e23c74
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:333a73df-4e06-4126-a016-5b0270e23c74
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:333a73df-4e06-4126-a016-5b0270e23c74
PROC_FINALLY_END:
        Exit Sub
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:333a73df-4e06-4126-a016-5b0270e23c74
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Sub
    '******************************************************************************
    ' Ö  ž  : DBObjectSet
    ' XR[v  : Public
    ' āe  : caIuWFNgÝč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDatabase
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_DBObjectSet"
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·


            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:333a73df-4e06-4126-a016-5b0270e23c74
            'PROC_END:

            'Exit Sub

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:333a73df-4e06-4126-a016-5b0270e23c74
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
PROC_FINALLY_END:
        Exit Sub
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Sub
    '******************************************************************************
    ' Ö  ž  : CheckZIPCode
    ' XR[v  : Public
    ' āe  : XÖÔķÝ`FbN
    ' õ    l  :
    ' Ô č l  : True iŲíIđj
    '             FalseiģíIđj
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     XÖÔP
    '   pstrZipCode2        String            I     XÖÔQ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Function CheckZIPCode(ByVal pstrZIPCode1 As String, ByVal pstrZIPCode2 As String) As Boolean

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_CheckZIPCode"
        Dim objDysYB_M As Object ' XÖÔ}X^ĖOraDynaset
        Dim strSQL As String
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·



            ' ßčlðúŧiŲíIđj
            CheckZIPCode = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' ŧv|C^ðÝč
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            'XÖÔ}X^
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    XÖÔ "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_XÖÔ}X^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    XÖÔ = '" & pstrZIPCode1 & pstrZIPCode2 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            'åûÆÂĘXÖÔ}X^
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    åûÆÂĘÔ AS XÖÔ "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_åûÆÂĘXÖÔ}X^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    åûÆÂĘÔ = '" & pstrZIPCode1 & pstrZIPCode2 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' ßčlðÝč(ģíIđ)
                    CheckZIPCode = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:6bc7843b-7d98-47c5-8287-3668f3ad77ae
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Function
    '******************************************************************************
    ' Ö  ž  : CheckZIPParentCode
    ' XR[v  : Public
    ' āe  : XÖÔ}X^ieR[hj `FbN
    ' õ    l  : XÖÔĖã3(eR[h)ÅXÖÔ}X^ðõ
    ' Ô č l  : True iŲíIđj
    '             FalseiģíIđj
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     XÖÔP
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Function CheckZIPParentCode(ByVal pstrZIPCode1 As String) As Boolean

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_CheckZIPParentCode"
        Dim objDysYB_M As Object ' XÖÔ}X^ĖOraDynaset
        Dim strSQL As String
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·



            ' ßčlðúŧiŲíIđj
            CheckZIPParentCode = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' ŧv|C^ðÝč
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            'XÖÔ}X^
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    XÖÔ "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_XÖÔ}X^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    XÖÔ1 = '" & pstrZIPCode1 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            'åûÆÂĘXÖÔ}X^
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    åûÆÂĘÔ AS XÖÔ "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_åûÆÂĘXÖÔ}X^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    åûÆÂĘÔ1 = '" & pstrZIPCode1 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' ßčlðÝč(ģíIđ)
                    CheckZIPParentCode = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:cbe9dcf1-9c3a-4901-bbc7-124f32deea90
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Function
    '******************************************************************************
    ' Ö  ž  : SetZIPInfo
    ' XR[v  : Public
    ' āe  : XÖÔ}X^ Ýč
    ' õ    l  :
    ' Ô č l  : True iŲíIđj
    '             FalseiģíIđj
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrZipCode1        String            I     XÖÔP
    '   pstrZipCode2        String            I     XÖÔQ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/04/21  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Function SetZIPInfo(ByVal pstrZIPCode1 As String, ByVal pstrZIPCode2 As String) As Boolean

        '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        'On Error GoTo PROC_ERROR
        '++CģJn@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Const C_NAME_FUNCTION As String = "clsUnitMstZipCode_SetZIPInfo"
        Dim objDysYB_M As Object ' XÖÔ}X^ĖOraDynaset
        Dim strSQL As String
        '--CģIđ@2021N0608:MKic[j- VB_530 VBĻVB.NETÏ·
        Try
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·



            ' ßčlðúŧiŲíIđj
            SetZIPInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            ' ŧv|C^ðÝč
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            'XÖÔ}X^
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    SnûöĪcĖR[h , "
            strSQL = strSQL & Chr(10) & "    XÖÔ             , "
            strSQL = strSQL & Chr(10) & "    XÖÔ               , "
            strSQL = strSQL & Chr(10) & "    sđ{§žJi         , "
            strSQL = strSQL & Chr(10) & "    sæŽšžJi         , "
            strSQL = strSQL & Chr(10) & "    ŽæžJi             , "
            strSQL = strSQL & Chr(10) & "    sđ{§ž             , "
            strSQL = strSQL & Chr(10) & "    sæŽšž             , "
            strSQL = strSQL & Chr(10) & "    Žæž                 , "
            strSQL = strSQL & Chr(10) & "    ęŽæĄÔ         , "
            strSQL = strSQL & Chr(10) & "    ÔnîÔ\Ķ           , "
            strSQL = strSQL & Chr(10) & "    Ú\Ķ               , "
            strSQL = strSQL & Chr(10) & "    ęÔĄŽæ         , "
            strSQL = strSQL & Chr(10) & "    XV\Ķ               , "
            strSQL = strSQL & Chr(10) & "    ÏXR                 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_XÖÔ}X^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    XÖÔ = '" & pstrZIPCode1 & pstrZIPCode2 & "' "
            strSQL = strSQL & Chr(10) & "UNION ALL "
            'åûÆÂĘXÖÔ}X^
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NULL                   SnûöĪcĖR[h, "
            strSQL = strSQL & Chr(10) & "    XÖÔ             , "
            strSQL = strSQL & Chr(10) & "    åûÆÂĘÔ     XÖÔ              , "
            strSQL = strSQL & Chr(10) & "    NULL                   sđ{§žJi        , "
            strSQL = strSQL & Chr(10) & "    NULL                   sæŽšžJi        , "
            strSQL = strSQL & Chr(10) & "    NULL                   ŽæžJi            , "
            strSQL = strSQL & Chr(10) & "    sđ{§ž             , "
            strSQL = strSQL & Chr(10) & "    sæŽšž             , "
            strSQL = strSQL & Chr(10) & "    Žæž || ŽÚÔn Žæž                , "
            strSQL = strSQL & Chr(10) & "    NULL                   ęŽæĄÔ        , "
            strSQL = strSQL & Chr(10) & "    NULL                   ÔnîÔ\Ķ          , "
            strSQL = strSQL & Chr(10) & "    NULL                   Ú\Ķ              , "
            strSQL = strSQL & Chr(10) & "    NULL                   ęÔĄŽæ        , "
            strSQL = strSQL & Chr(10) & "    NULL                   XV\Ķ              , "
            strSQL = strSQL & Chr(10) & "    NULL                   ÏXR                "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & MC_TABLE_åûÆÂĘXÖÔ}X^ & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    åûÆÂĘÔ = '" & pstrZIPCode1 & pstrZIPCode2 & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysYB_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysYB_M

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' ßčlðÝč(ģíIđ)
                    SetZIPInfo = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrSnûöĪcĖR[h = gfncFieldVal(.Fields("SnûöĪcĖR[h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrXÖÔ = gfncFieldVal(.Fields("XÖÔ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrXÖÔ = gfncFieldVal(.Fields("XÖÔ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrsđ{§žJi = gfncFieldVal(.Fields("sđ{§žJi").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrsæŽšžJi = gfncFieldVal(.Fields("sæŽšžJi").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrŽæžJi = gfncFieldVal(.Fields("ŽæžJi").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrsđ{§ž = gfncFieldVal(.Fields("sđ{§ž").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrsæŽšž = gfncFieldVal(.Fields("sæŽšž").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrŽæž = gfncFieldVal(.Fields("Žæž").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstręŽæĄÔ = gfncFieldVal(.Fields("ęŽæĄÔ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrÔnîÔ\Ķ = gfncFieldVal(.Fields("ÔnîÔ\Ķ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrÚ\Ķ = gfncFieldVal(.Fields("Ú\Ķ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstręÔĄŽæ = gfncFieldVal(.Fields("ęÔĄŽæ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrXV\Ķ = gfncFieldVal(.Fields("XV\Ķ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrÏXR = gfncFieldVal(.Fields("ÏXR").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysYB_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysYB_M)

            'Exit Function

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
            'PROC_ERROR:
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:3e2a637c-ff8e-48b4-927c-11651d80b71f
        Catch ex As Exception
            '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++CģJn@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·
            'Resume PROC_END
            '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
            '--CģIđ@2021N0608:MKic[j- VB_003 VBĻVB.NETÏ·

            '++CģJn@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
        End Try
        '++CģJn@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysYB_M)
        Exit Function
        '--CģIđ@2021N0608:MKic[j- VB_523 VBĻVB.NETÏ·	T:ae8529b9-88e0-41b9-b60a-d27d14291efe
        '--CģIđ@2021N0608:MKic[j- VB_522 VBĻVB.NETÏ·
    End Function
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' vpeB
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' Ö  ž  : SnûöĪcĖR[h
    ' XR[v  : Public
    ' āe  : SnûöĪcĖR[h Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     SnûöĪcĖR[h
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : SnûöĪcĖR[h
    ' XR[v  : Public
    ' āe  : SnûöĪcĖR[h æū
    ' õ    l  :
    ' Ô č l  : SnûöĪcĖR[h
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property SnûöĪcĖR[h() As String
        Get
            SnûöĪcĖR[h = mstrSnûöĪcĖR[h
        End Get
        Set(ByVal Value As String)
            mstrSnûöĪcĖR[h = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : XÖÔ
    ' XR[v  : Public
    ' āe  : XÖÔ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String         I     XÖÔ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : XÖÔ
    ' XR[v  : Public
    ' āe  : XÖÔ æū
    ' õ    l  :
    ' Ô č l  : XÖÔ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property XÖÔ() As String
        Get
            XÖÔ = mstrXÖÔ
        End Get
        Set(ByVal Value As String)
            mstrXÖÔ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : XÖÔ
    ' XR[v  : Public
    ' āe  : XÖÔ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     XÖÔ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : XÖÔ
    ' XR[v  : Public
    ' āe  : XÖÔ æū
    ' õ    l  :
    ' Ô č l  : XÖÔ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property XÖÔ() As String
        Get
            XÖÔ = mstrXÖÔ
        End Get
        Set(ByVal Value As String)
            mstrXÖÔ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : sđ{§žJi
    ' XR[v  : Public
    ' āe  : sđ{§žJi Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     sđ{§žJi
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : sđ{§žJi
    ' XR[v  : Public
    ' āe  : sđ{§žJi æū
    ' õ    l  :
    ' Ô č l  : sđ{§žJi
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property sđ{§žJi() As String
        Get
            sđ{§žJi = mstrsđ{§žJi
        End Get
        Set(ByVal Value As String)
            mstrsđ{§žJi = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : sæŽšžJi
    ' XR[v  : Public
    ' āe  : sæŽšžJi Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     sæŽšžJi
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : sæŽšžJi
    ' XR[v  : Public
    ' āe  : sæŽšžJi æū
    ' õ    l  :
    ' Ô č l  : sæŽšžJi
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property sæŽšžJi() As String
        Get
            sæŽšžJi = mstrsæŽšžJi
        End Get
        Set(ByVal Value As String)
            mstrsæŽšžJi = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : ŽæžJi
    ' XR[v  : Public
    ' āe  : ŽæžJi Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ŽæžJi
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : ŽæžJi
    ' XR[v  : Public
    ' āe  : ŽæžJi æū
    ' õ    l  :
    ' Ô č l  : ŽæžJi
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property ŽæžJi() As String
        Get
            ŽæžJi = mstrŽæžJi
        End Get
        Set(ByVal Value As String)
            mstrŽæžJi = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : sđ{§ž
    ' XR[v  : Public
    ' āe  : sđ{§ž Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     sđ{§ž
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : sđ{§ž
    ' XR[v  : Public
    ' āe  : sđ{§ž æū
    ' õ    l  :
    ' Ô č l  : sđ{§ž
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property sđ{§ž() As String
        Get
            sđ{§ž = mstrsđ{§ž
        End Get
        Set(ByVal Value As String)
            mstrsđ{§ž = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : sæŽšž
    ' XR[v  : Public
    ' āe  : sæŽšž Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     sæŽšž
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : sæŽšž
    ' XR[v  : Public
    ' āe  : sæŽšž æū
    ' õ    l  :
    ' Ô č l  : sæŽšž
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property sæŽšž() As String
        Get
            sæŽšž = mstrsæŽšž
        End Get
        Set(ByVal Value As String)
            mstrsæŽšž = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : Žæž
    ' XR[v  : Public
    ' āe  : Žæž Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     Žæž
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : Žæž
    ' XR[v  : Public
    ' āe  : Žæž æū
    ' õ    l  :
    ' Ô č l  : Žæž
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property Žæž() As String
        Get
            Žæž = mstrŽæž
        End Get
        Set(ByVal Value As String)
            mstrŽæž = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : ęŽæĄÔ
    ' XR[v  : Public
    ' āe  : ęŽæĄÔ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ęŽæĄÔ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : ęŽæĄÔ
    ' XR[v  : Public
    ' āe  : ęŽæĄÔ æū
    ' õ    l  :
    ' Ô č l  : ęŽæĄÔ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property ęŽæĄÔ() As String
        Get
            ęŽæĄÔ = mstręŽæĄÔ
        End Get
        Set(ByVal Value As String)
            mstręŽæĄÔ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : ÔnîÔ\Ķ
    ' XR[v  : Public
    ' āe  : ÔnîÔ\Ķ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ÔnîÔ\Ķ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : ÔnîÔ\Ķ
    ' XR[v  : Public
    ' āe  : ÔnîÔ\Ķ æū
    ' õ    l  :
    ' Ô č l  : ÔnîÔ\Ķ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property ÔnîÔ\Ķ() As String
        Get
            ÔnîÔ\Ķ = mstrÔnîÔ\Ķ
        End Get
        Set(ByVal Value As String)
            mstrÔnîÔ\Ķ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : Ú\Ķ
    ' XR[v  : Public
    ' āe  : Ú\Ķ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     Ú\Ķ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : Ú\Ķ
    ' XR[v  : Public
    ' āe  : Ú\Ķ æū
    ' õ    l  :
    ' Ô č l  : Ú\Ķ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property Ú\Ķ() As String
        Get
            Ú\Ķ = mstrÚ\Ķ
        End Get
        Set(ByVal Value As String)
            mstrÚ\Ķ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : ęÔĄŽæ
    ' XR[v  : Public
    ' āe  : ęÔĄŽæ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ęÔĄŽæ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : ęÔĄŽæ
    ' XR[v  : Public
    ' āe  : ęÔĄŽæ æū
    ' õ    l  :
    ' Ô č l  : ęÔĄŽæ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property ęÔĄŽæ() As String
        Get
            ęÔĄŽæ = mstręÔĄŽæ
        End Get
        Set(ByVal Value As String)
            mstręÔĄŽæ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : XV\Ķ
    ' XR[v  : Public
    ' āe  : XV\Ķ Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     XV\Ķ
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : XV\Ķ
    ' XR[v  : Public
    ' āe  : XV\Ķ æū
    ' õ    l  :
    ' Ô č l  : XV\Ķ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property XV\Ķ() As String
        Get
            XV\Ķ = mstrXV\Ķ
        End Get
        Set(ByVal Value As String)
            mstrXV\Ķ = Value
        End Set
    End Property
    '******************************************************************************
    ' Ö  ž  : ÏXR
    ' XR[v  : Public
    ' āe  : ÏXR Ýč
    ' õ    l  :
    ' Ô č l  : Čĩ
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ÏXR
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    '******************************************************************************
    ' Ö  ž  : ÏXR
    ' XR[v  : Public
    ' āe  : ÏXR æū
    ' õ    l  :
    ' Ô č l  : ÏXR
    ' ø Ŧ   :
    '   ĘßŨŌ°Āž            ÃÞ°ĀĀēĖß          I/O   ā ū
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' ÏXð  :
    '   Version     ú  t        ž             Cģāe
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/06/18  Aä  Fū         VKėŽ
    '
    '******************************************************************************
    Public Property ÏXR() As String
        Get
            ÏXR = mstrÏXR
        End Get
        Set(ByVal Value As String)
            mstrÏXR = Value
        End Set
    End Property
End Class
