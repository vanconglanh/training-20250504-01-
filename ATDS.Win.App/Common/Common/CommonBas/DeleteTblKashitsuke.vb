Option Strict Off
Option Explicit On
Module basDeleteTblKashitsuke
    '******************************************************************************
    ' �� �� ��  : gfncRegisterTblLoanDelete
    ' �X�R�[�v  : Public
    ' �������e  : �ݕt�폜�e�[�u�� �o�^
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX�폜  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncRegisterTblLoanDelete(ByVal pstrJyugyoinCode As String) As Boolean

        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncRegisterTblLoanDelete"
        Dim strSQL As String
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            gfncRegisterTblLoanDelete = True

            '--------------------------------------------------------------------------
            ' �ݕt�폜�e�[�u�� �o�^
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO �ݕt�폜�e�[�u�� "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        ��ЃR�[�h       "
            strSQL = strSQL & Chr(10) & "      , �����R�[�h       "
            strSQL = strSQL & Chr(10) & "      , �]�ƈ��R�[�h     "
            strSQL = strSQL & Chr(10) & "      , ���]�ƈ��R�[�h   "
            strSQL = strSQL & Chr(10) & "      , �X�V�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "      , �X�V���t����     "
            strSQL = strSQL & Chr(10) & "      , �X�V�v���O����ID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h       "
            strSQL = strSQL & Chr(10) & "  , �����R�[�h       "
            strSQL = strSQL & Chr(10) & "  , �]�ƈ��R�[�h     "
            strSQL = strSQL & Chr(10) & "  , ���]�ƈ��R�[�h   "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �ݕt�e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' �ݕt���׍폜�e�[�u�� �o�^
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO �ݕt���׍폜�e�[�u�� "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        �]�ƈ��R�[�h     "
            strSQL = strSQL & Chr(10) & "      , �}��             "
            strSQL = strSQL & Chr(10) & "      , �ݕt���ڃR�[�h   "
            strSQL = strSQL & Chr(10) & "      , �ݕt��           "
            strSQL = strSQL & Chr(10) & "      , �Ə���           "
            strSQL = strSQL & Chr(10) & "      , �ݕt���z         "
            strSQL = strSQL & Chr(10) & "      , ���l             "
            strSQL = strSQL & Chr(10) & "      , ���^�T���L��     "
            strSQL = strSQL & Chr(10) & "      , �X�V�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "      , �X�V���t����     "
            strSQL = strSQL & Chr(10) & "      , �X�V�v���O����ID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h     "
            strSQL = strSQL & Chr(10) & "  , �}��             "
            strSQL = strSQL & Chr(10) & "  , �ݕt���ڃR�[�h   "
            strSQL = strSQL & Chr(10) & "  , �ݕt��           "
            strSQL = strSQL & Chr(10) & "  , �Ə���           "
            strSQL = strSQL & Chr(10) & "  , �ݕt���z         "
            strSQL = strSQL & Chr(10) & "  , ���l             "
            strSQL = strSQL & Chr(10) & "  , ���^�T���L��     "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �ݕt���׃e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' �߂�l��ݒ�i����I���j
            gfncRegisterTblLoanDelete = False

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:620dc761-0e26-4f55-86bb-2d4e9f1d9905
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:620dc761-0e26-4f55-86bb-2d4e9f1d9905
        Catch ex As Exception
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncDeleteTblLoan
    ' �X�R�[�v  : Public
    ' �������e  : �ݕt�e�[�u�� �폜
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrJyugyoinCode    String            I     �]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncDeleteTblLoan(ByVal pstrJyugyoinCode As String) As Boolean

        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDeleteTblLoan"
        Dim strSQL As String
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            gfncDeleteTblLoan = True

            '--------------------------------------------------------------------------
            ' �ݕt�����e�[�u�� �폜
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE �ݕt�e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' �ݕt���ח����e�[�u�� �폜
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE �ݕt���׃e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' �߂�l��ݒ�i����I���j
            gfncDeleteTblLoan = False

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
        Catch ex As Exception
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:db287213-0954-4d0f-a70e-b03753d90d75
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:db287213-0954-4d0f-a70e-b03753d90d75
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:db287213-0954-4d0f-a70e-b03753d90d75
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:db287213-0954-4d0f-a70e-b03753d90d75
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncRegisterTblLoanLogDmy
    ' �X�R�[�v  : Public
    ' �������e  : �ݕt�������e�[�u�� �o�^
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrJyugyoinCodeDmy String            I     ���]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncRegisterTblLoanLogDmy(ByVal pstrJyugyoinCodeDmy As String) As Boolean

        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncRegisterTblLoanLogDmy"
        Dim strSQL As String
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            gfncRegisterTblLoanLogDmy = True

            '--------------------------------------------------------------------------
            ' �ݕt�����e�[�u�� �o�^
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO �ݕt�������e�[�u�� "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        ��ЃR�[�h       "
            strSQL = strSQL & Chr(10) & "      , �����R�[�h       "
            strSQL = strSQL & Chr(10) & "      , ���]�ƈ��R�[�h   "
            strSQL = strSQL & Chr(10) & "      , ���]�ƈ�������   "
            strSQL = strSQL & Chr(10) & "      , �U�֏]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "      , �X�V�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "      , �X�V���t����     "
            strSQL = strSQL & Chr(10) & "      , �X�V�v���O����ID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h       "
            strSQL = strSQL & Chr(10) & "  , �����R�[�h       "
            strSQL = strSQL & Chr(10) & "  , ���]�ƈ��R�[�h   "
            strSQL = strSQL & Chr(10) & "  , ���]�ƈ�������   "
            strSQL = strSQL & Chr(10) & "  , �U�֏]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �ݕt���e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ���]�ƈ��R�[�h = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' �ݕt���ח����e�[�u�� �o�^
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO �ݕt�����ח����e�[�u�� "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        ���]�ƈ��R�[�h   "
            strSQL = strSQL & Chr(10) & "      , �}��             "
            strSQL = strSQL & Chr(10) & "      , �ݕt���ڃR�[�h   "
            strSQL = strSQL & Chr(10) & "      , �x����           "
            strSQL = strSQL & Chr(10) & "      , �ݕt��           "
            strSQL = strSQL & Chr(10) & "      , �Ə���           "
            strSQL = strSQL & Chr(10) & "      , �ݕt���z         "
            strSQL = strSQL & Chr(10) & "      , ���l             "
            strSQL = strSQL & Chr(10) & "      , ���^�T���L��     "
            strSQL = strSQL & Chr(10) & "      , �X�V�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "      , �X�V���t����     "
            strSQL = strSQL & Chr(10) & "      , �X�V�v���O����ID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ���]�ƈ��R�[�h   "
            strSQL = strSQL & Chr(10) & "  , �}��             "
            strSQL = strSQL & Chr(10) & "  , �ݕt���ڃR�[�h   "
            strSQL = strSQL & Chr(10) & "  , �x����           "
            strSQL = strSQL & Chr(10) & "  , �ݕt��           "
            strSQL = strSQL & Chr(10) & "  , �Ə���           "
            strSQL = strSQL & Chr(10) & "  , �ݕt���z         "
            strSQL = strSQL & Chr(10) & "  , ���l             "
            strSQL = strSQL & Chr(10) & "  , ���^�T���L��     "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �ݕt�����׃e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ���]�ƈ��R�[�h = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' �߂�l��ݒ�i����I���j
            gfncRegisterTblLoanLogDmy = False

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:db287213-0954-4d0f-a70e-b03753d90d75
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:db287213-0954-4d0f-a70e-b03753d90d75
        Catch ex As Exception
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncDeleteTblLoanDmy
    ' �X�R�[�v  : Public
    ' �������e  : �ݕt���e�[�u�� �폜
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrJyugyoinCodeDmy String            I     ���]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncDeleteTblLoanDmy(ByVal pstrJyugyoinCodeDmy As String) As Boolean

        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDeleteTblLoanDmy"
        Dim strSQL As String
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i�ُ�I���j
            gfncDeleteTblLoanDmy = True

            '--------------------------------------------------------------------------
            ' �ݕt�����e�[�u�� �폜
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE �ݕt���e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ���]�ƈ��R�[�h = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' �ݕt���ח����e�[�u�� �폜
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE �ݕt�����׃e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ���]�ƈ��R�[�h = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' �߂�l��ݒ�i����I���j
            gfncDeleteTblLoanDmy = False

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
        Catch ex As Exception
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
            '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
        '--�C���I���@2021�N06��23:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
