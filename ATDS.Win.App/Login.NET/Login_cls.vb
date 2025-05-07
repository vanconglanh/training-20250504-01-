Option Strict Off
Option Explicit On
Imports MKOra.Core

<System.Runtime.InteropServices.ProgId("clsLogin_NET.clsLogin")> Public Class clsLogin

    Private mblnDBConnect As Boolean ' DB�ڑ��t���O(True�F�ڑ�)

    Public ReadOnly Property LoginDate() As String
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_LoginDate"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_LoginDate"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                'UPGRADE_WARNING: �I�u�W�F�N�g gvntLoginDate �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                LoginDate = gvntLoginDate

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a9404e86-7d28-4c41-855b-8ddb99e1b57e
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a9404e86-7d28-4c41-855b-8ddb99e1b57e
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property CompanyCode() As String
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_CompanyCode"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_CompanyCode"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                CompanyCode = gstrCompanyCode

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ad99f4ea-d48c-411a-8e37-e9c81c4756f0
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property PostCode() As String
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_PostCode"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_PostCode"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                PostCode = gstrPostCode

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:22f5b98d-3d3f-4ee1-aa3e-9062cc23f749
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0e09c1e-46c5-4634-b92d-5857912408db
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0e09c1e-46c5-4634-b92d-5857912408db

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0e09c1e-46c5-4634-b92d-5857912408db
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0e09c1e-46c5-4634-b92d-5857912408db
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property EmployeeCode() As String
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeCode"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeCode"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                EmployeeCode = gstrEmployeeCode

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0e09c1e-46c5-4634-b92d-5857912408db
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0e09c1e-46c5-4634-b92d-5857912408db
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1fe9fd9b-24c5-46db-82c3-107364da7846
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1fe9fd9b-24c5-46db-82c3-107364da7846

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1fe9fd9b-24c5-46db-82c3-107364da7846
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1fe9fd9b-24c5-46db-82c3-107364da7846
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property EmployeeName() As String
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeName"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_EmployeeName"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                EmployeeName = gstrEmployeeName

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1fe9fd9b-24c5-46db-82c3-107364da7846
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1fe9fd9b-24c5-46db-82c3-107364da7846
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property SystemAuthority() As Short
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_SystemAuthority"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_SystemAuthority"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                SystemAuthority = gintSystemAuthority

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e0b276bc-ba45-4e39-90d3-d8f740b95bbb
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d7614a64-aaf7-4d65-987b-4fe3982d1486

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property Rank() As String
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_Rank"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_Rank"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                Rank = gstrRank

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d7614a64-aaf7-4d65-987b-4fe3982d1486
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bc98f997-99ad-47f1-a126-412c77cc0e89
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bc98f997-99ad-47f1-a126-412c77cc0e89

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bc98f997-99ad-47f1-a126-412c77cc0e89
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bc98f997-99ad-47f1-a126-412c77cc0e89
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property OfficialPosition() As Short
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_OfficialPosition"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_OfficialPosition"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                OfficialPosition = gintOfficialPosition

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bc98f997-99ad-47f1-a126-412c77cc0e89
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:bc98f997-99ad-47f1-a126-412c77cc0e89
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:893b79d8-f190-4e49-8325-b32fbc0a189b
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:893b79d8-f190-4e49-8325-b32fbc0a189b

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:893b79d8-f190-4e49-8325-b32fbc0a189b
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:893b79d8-f190-4e49-8325-b32fbc0a189b
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    Public ReadOnly Property OkCancel() As Short
        Get

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'On Error GoTo PROC_ERROR
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Const C_NAME_FUNCTION As String = "clsLogin_Get_OkCancel"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            Try
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
                'Const C_NAME_FUNCTION As String = "clsLogin_Get_OkCancel"
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

                OkCancel = gintOkCancel

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:893b79d8-f190-4e49-8325-b32fbc0a189b
                'PROC_END:

                'Exit Property

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
                'PROC_ERROR:
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:893b79d8-f190-4e49-8325-b32fbc0a189b
            Catch ex As Exception
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
                'Resume PROC_END
                '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5

                '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            End Try
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
PROC_FINALLY_END:
            Exit Property
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Get
    End Property

    'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
    Private Sub Class_Initialize_Renamed()

        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsLogin_Class_Initialize"
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsLogin_Class_Initialize"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            gstrPostCode = ""
            gstrEmployeeCode = ""
            gintSystemAuthority = 1
            gintOkCancel = MsgBoxResult.Cancel

            mblnDBConnect = False

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d95154ae-c4d7-4732-8212-ea5beba1e9f5
        Catch ex As Exception
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
            'Resume PROC_END
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsLogin_DBConnect"
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsLogin_DBConnect"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
            'gobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            gobjOraSession = New OraSession()
            '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

            'UPGRADE_WARNING: �I�u�W�F�N�g gobjOraSession.OpenDatabase �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            gobjOraDatabase = gobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1faea6aa-14ff-4ea9-a2d3-86acf42cb1cf
        Catch ex As Exception
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
            'Resume PROC_END
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub

    Public Sub LoadLogin()

        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsLogin_LoadLogin"
        Dim frm As frmLogin = New frmLogin
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsLogin_LoadLogin"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            If mblnDBConnect = False Then
                Exit Sub
            End If
            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
            'frmLogin.ShowDialog()
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim frm As frmLogin = New frmLogin
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            frm.ShowDialog()
            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c6a791d-bf11-47ed-a603-bb3bf15e4579
        Catch ex As Exception
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e7002bc-0e1f-432f-8db7-4d0521b59862
            'Resume PROC_END
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e7002bc-0e1f-432f-8db7-4d0521b59862

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e7002bc-0e1f-432f-8db7-4d0521b59862
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3e7002bc-0e1f-432f-8db7-4d0521b59862
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
End Class
