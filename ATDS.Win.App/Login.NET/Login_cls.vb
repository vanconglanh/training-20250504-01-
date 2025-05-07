Option Strict Off
Option Explicit On
Imports MKOra.Core

<System.Runtime.InteropServices.ProgId("clsLogin_NET.clsLogin")> Public Class clsLogin

    Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)

    Public ReadOnly Property LoginDate() As String
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_LoginDate"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_LoginDate"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                'UPGRADE_WARNING: オブジェクト gvntLoginDate の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                LoginDate = gvntLoginDate

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:a9404e86-7d28-4c41-855b-8ddb99e1b57e
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:a9404e86-7d28-4c41-855b-8ddb99e1b57e
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property CompanyCode() As String
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_CompanyCode"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_CompanyCode"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                CompanyCode = gstrCompanyCode

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property PostCode() As String
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_PostCode"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_PostCode"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                PostCode = gstrPostCode

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0e09c1e-46c5-4634-b92d-5857912408db
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0e09c1e-46c5-4634-b92d-5857912408db

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0e09c1e-46c5-4634-b92d-5857912408db
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0e09c1e-46c5-4634-b92d-5857912408db
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property EmployeeCode() As String
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeCode"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeCode"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                EmployeeCode = gstrEmployeeCode

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0e09c1e-46c5-4634-b92d-5857912408db
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0e09c1e-46c5-4634-b92d-5857912408db
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1fe9fd9b-24c5-46db-82c3-107364da7846
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1fe9fd9b-24c5-46db-82c3-107364da7846

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1fe9fd9b-24c5-46db-82c3-107364da7846
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1fe9fd9b-24c5-46db-82c3-107364da7846
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property EmployeeName() As String
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeName"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeName"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                EmployeeName = gstrEmployeeName

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1fe9fd9b-24c5-46db-82c3-107364da7846
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1fe9fd9b-24c5-46db-82c3-107364da7846
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property SystemAuthority() As Short
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_SystemAuthority"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_SystemAuthority"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                SystemAuthority = gintSystemAuthority

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d7614a64-aaf7-4d65-987b-4fe3982d1486

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property Rank() As String
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_Rank"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_Rank"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                Rank = gstrRank

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:bc98f997-99ad-47f1-a126-412c77cc0e89
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:bc98f997-99ad-47f1-a126-412c77cc0e89

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:bc98f997-99ad-47f1-a126-412c77cc0e89
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:bc98f997-99ad-47f1-a126-412c77cc0e89
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property OfficialPosition() As Short
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_OfficialPosition"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_OfficialPosition"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                OfficialPosition = gintOfficialPosition

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:bc98f997-99ad-47f1-a126-412c77cc0e89
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:bc98f997-99ad-47f1-a126-412c77cc0e89
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:893b79d8-f190-4e49-8325-b32fbc0a189b
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:893b79d8-f190-4e49-8325-b32fbc0a189b

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:893b79d8-f190-4e49-8325-b32fbc0a189b
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:893b79d8-f190-4e49-8325-b32fbc0a189b
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    Public ReadOnly Property OkCancel() As Short
        Get

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'On Error GoTo PROC_ERROR
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Const C_NAME_FUNCTION As String = "clsLogin_Get_OkCancel"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            Try
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_OkCancel"
                '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

                OkCancel = gintOkCancel

                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:893b79d8-f190-4e49-8325-b32fbc0a189b
                'PROC_END:

                'Exit Property

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
                'PROC_ERROR:
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:893b79d8-f190-4e49-8325-b32fbc0a189b
            Catch ex As Exception
                '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
                'Resume PROC_END
                '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5

                '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            End Try
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
PROC_FINALLY_END:
            Exit Property
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Get
    End Property

    'UPGRADE_NOTE: Class_Initialize は Class_Initialize_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
    Private Sub Class_Initialize_Renamed()

        '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsLogin_Class_Initialize"
        '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsLogin_Class_Initialize"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

            gstrPostCode = ""
            gstrEmployeeCode = ""
            gintSystemAuthority = 1
            gintOkCancel = MsgBoxResult.Cancel

            mblnDBConnect = False

            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
        Catch ex As Exception
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
            'Resume PROC_END
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
        '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsLogin_DBConnect"
        '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsLogin_DBConnect"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
            'gobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            gobjOraSession = New OraSession()
            '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

            'UPGRADE_WARNING: オブジェクト gobjOraSession.OpenDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            gobjOraDatabase = gobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
        Catch ex As Exception
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
            'Resume PROC_END
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
        '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub

    Public Sub LoadLogin()

        '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsLogin_LoadLogin"
        Dim frm As frmLogin = New frmLogin
        '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsLogin_LoadLogin"
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換

            If mblnDBConnect = False Then
                Exit Sub
            End If
            '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
            'frmLogin.ShowDialog()
            '++修正開始　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim frm As frmLogin = New frmLogin
            '--修正終了　2021年05月31:MK（ツール）- VB_530 VB→VB.NET変換
            frm.ShowDialog()
            '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
        Catch ex As Exception
            '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:3e7002bc-0e1f-432f-8db7-4d0521b59862
            'Resume PROC_END
            '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:3e7002bc-0e1f-432f-8db7-4d0521b59862

            '++修正開始　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:3e7002bc-0e1f-432f-8db7-4d0521b59862
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年05月31:MK（ツール）- VB_523 VB→VB.NET変換	T:3e7002bc-0e1f-432f-8db7-4d0521b59862
        '--修正終了　2021年05月31:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
End Class
