Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.Compatibility
Imports MKOra.Core
Friend Class clsSystemDate

    Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)
    Private mblnDBObject As Boolean ' DB接続オブジェクト設定フラグ(True：設定)
    Private mOraSession As Object ' Oracle
    Private mOraDatabase As Object ' Oracle
    Private mdteSystemDate As Date
    Public ReadOnly Property SystemDate() As Date
        Get

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsSystemDate_Get_SystemDate"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsSystemDate_Get_SystemDate"
                '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

                If mblnDBConnect = False And mblnDBObject = False Then
                    Exit Property
                End If

                SystemDate = mdteSystemDate

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8793b787-53ab-42c7-abae-12083e15e4ee
                'PROC_END:

                'Exit Property

                '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8793b787-53ab-42c7-abae-12083e15e4ee
            Catch ex As Exception
                '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:72bfe0e8-b34a-4e90-8a03-31d50e11e8b5
                'Resume PROC_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:72bfe0e8-b34a-4e90-8a03-31d50e11e8b5

                '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:72bfe0e8-b34a-4e90-8a03-31d50e11e8b5
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:72bfe0e8-b34a-4e90-8a03-31d50e11e8b5
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property SystemDateFormat(ByVal pstrFormat As String) As String
        Get

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsSystemDate_Get_SystemDate"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsSystemDate_Get_SystemDate"
                '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

                If mblnDBConnect = False And mblnDBObject = False Then
                    Exit Property
                End If

                SystemDateFormat = VB6.Format(mdteSystemDate, pstrFormat)

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:72bfe0e8-b34a-4e90-8a03-31d50e11e8b5
                'PROC_END:

                'Exit Property

                '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:72bfe0e8-b34a-4e90-8a03-31d50e11e8b5
            Catch ex As Exception
                '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:80fde658-b953-4bde-ae49-71047de345dd
                'Resume PROC_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:80fde658-b953-4bde-ae49-71047de345dd

                '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:80fde658-b953-4bde-ae49-71047de345dd
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:80fde658-b953-4bde-ae49-71047de345dd
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public Function GetSystemDate() As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsSysDate_GetSystemDate"
        Dim strSql As String
        Dim objDysDual As Object
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsSysDate_GetSystemDate"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSql As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDysDual As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 初期値を設定(異常終了)
            GetSystemDate = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            strSql = ""
            strSql = strSql & Chr(10) & "SELECT "
            strSql = strSql & Chr(10) & "    TO_CHAR(sysdate,'YYYY/MM/DD HH24:MI:SS') SystemDate "
            '    strSql = strSql & Chr(10) & "    TO_CHAR(sysdate,'yyyy/mm/dd hh:mm:ss') SystemDate "
            strSql = strSql & Chr(10) & "FROM "
            strSql = strSql & Chr(10) & "    DUAL "

            'UPGRADE_WARNING: Couldn't resolve default property of object mOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysDual = mOraDatabase.CreateDynaset(strSql, &H4)

            With objDysDual

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDual.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' 戻り値を設定(正常終了)
                    GetSystemDate = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysDual.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mdteSystemDate = CDate(.Fields("SystemDate").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysDual.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:80fde658-b953-4bde-ae49-71047de345dd
            'PROC_END:

            'UPGRADE_NOTE: Object objDysDual may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysDual = Nothing

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:80fde658-b953-4bde-ae49-71047de345dd
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ef81d95-3393-4daf-ba3c-7d1dfcd314ff
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ef81d95-3393-4daf-ba3c-7d1dfcd314ff


            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ef81d95-3393-4daf-ba3c-7d1dfcd314ff
PROC_FINALLY_END:
        objDysDual = Nothing
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ef81d95-3393-4daf-ba3c-7d1dfcd314ff
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsSysDate_Class_Initialize"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsSysDate_Class_Initialize"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mblnDBConnect = False

            mblnDBObject = False

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ef81d95-3393-4daf-ba3c-7d1dfcd314ff
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ef81d95-3393-4daf-ba3c-7d1dfcd314ff
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7073260a-eb7e-42f5-a8f8-e32fe7a95470
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7073260a-eb7e-42f5-a8f8-e32fe7a95470

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7073260a-eb7e-42f5-a8f8-e32fe7a95470
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7073260a-eb7e-42f5-a8f8-e32fe7a95470
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsSysDate_DBConnect"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsSysDate_DBConnect"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
            'mOraSession = CreateObject("OracleInProcServer.XOraSession")
            mOraSession = New OraSession()
            '--修正終了　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object mOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mOraDatabase = mOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7073260a-eb7e-42f5-a8f8-e32fe7a95470
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7073260a-eb7e-42f5-a8f8-e32fe7a95470
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:0904491d-c1c3-4af8-8e6f-deec99d3791b
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:0904491d-c1c3-4af8-8e6f-deec99d3791b

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:0904491d-c1c3-4af8-8e6f-deec99d3791b
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:0904491d-c1c3-4af8-8e6f-deec99d3791b
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub

    Public Sub DBObjectSet(ByVal pobjDatabase As Object)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsSysDate_DBObjectSet"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsSysDate_DBObjectSet"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mOraDatabase = pobjDatabase

            mblnDBObject = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:0904491d-c1c3-4af8-8e6f-deec99d3791b
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:0904491d-c1c3-4af8-8e6f-deec99d3791b
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2f0f1a2d-d0f2-404f-af20-f74935b0005a
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2f0f1a2d-d0f2-404f-af20-f74935b0005a

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2f0f1a2d-d0f2-404f-af20-f74935b0005a
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2f0f1a2d-d0f2-404f-af20-f74935b0005a
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub

    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsSysDate_Class_Terminate"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsSysDate_Class_Terminate"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            If mblnDBConnect = True Then

                'UPGRADE_NOTE: Object mOraSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                mOraSession = Nothing

                'UPGRADE_NOTE: Object mOraDatabase may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                mOraDatabase = Nothing

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2f0f1a2d-d0f2-404f-af20-f74935b0005a
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2f0f1a2d-d0f2-404f-af20-f74935b0005a
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5b58e9b0-bfc4-4b70-87c6-2364c1918320
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5b58e9b0-bfc4-4b70-87c6-2364c1918320

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5b58e9b0-bfc4-4b70-87c6-2364c1918320
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:5b58e9b0-bfc4-4b70-87c6-2364c1918320
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
End Class
