Option Strict Off
Option Explicit On
Module basTraceLog
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : TraceLog.cls
    ' ��    �e    : �g���[�X���O�@���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncRegistTraceLog       (���O�o�͏���)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/07/01  �j�r�q             �V�K�쐬
    '
    '******************************************************************************

    '==============================================================================
    ' �萔
    '==============================================================================
    Public Const GC_LOG_TARGET_�V�X�e�����O As String = "�l�j�V�X�e�����O�e�[�u��"
    Public Const GC_LOG_TARGET_���q�Ǘ����O As String = "�l�j���q�Ǘ����O�e�[�u��"
    Public Const GC_LOG_TARGET_�����l�����O As String = "�l�j�����l�����O�e�[�u��"

    '******************************************************************************
    ' �� �� ��  : gfncRegistTraceLog
    ' �X�R�[�v  : Public
    ' �������e  : ���O�o�͏���
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   strDbUserName       String            I     �f�[�^�x�[�X�ڑ����
    '   strDbPassword       String            I     �f�[�^�x�[�X�ڑ����
    '   strDbTns            String            I     �f�[�^�x�[�X�ڑ����
    '   strProgram          String            I     �v���O������
    '   strId               String            I     �v���O�����h�c
    '   strStatus           String            I     ���O�X�e�[�^�X
    '   strProcessStatus    String            I     �����X�e�[�^�X
    '   strDescription      String            I     ���O�ڍ�
    '   strLogTarget        String            I     �Ώۃ��O�e�[�u��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  KSR                �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncRegistTraceLog(ByVal strDbUserName As String, ByVal strDbPassword As String, ByVal strDbTns As String, ByVal strProgram As String, ByVal strId As String, ByVal strStatus As String, ByVal strProcessStatus As String, ByVal strDescription As String, ByVal strLogTarget As String, Optional ByVal blnWithTrans As Boolean = True) As Boolean
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncRegistTraceLog"
        Dim strSQL As String
        Dim objLogSession As Object
        Dim blnLogTrans As Boolean
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncRegistTraceLog"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            gfncRegistTraceLog = False

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objLogSession As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim blnLogTrans As Boolean
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            If blnWithTrans = True Then
                '���O�o�^�p�Z�b�V����
                Call gfncDBConnect(objLogSession, gobjOraDatabase, strDbUserName, strDbPassword, strDbTns)

                'UPGRADE_WARNING: Couldn't resolve default property of object objLogSession.BeginTrans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call objLogSession.BeginTrans()
                blnLogTrans = True
            End If

            Select Case strLogTarget

                Case GC_LOG_TARGET_�V�X�e�����O

                    strSQL = ""
                    strSQL = strSQL & "INSERT INTO �l�j�V�X�e�����O�e�[�u�� ( "
                    strSQL = strSQL & "    ���OSEQ "
                    strSQL = strSQL & "   ,�T�u���j���[�� "
                    strSQL = strSQL & "   ,�v���O����ID "
                    strSQL = strSQL & "   ,��� "
                    strSQL = strSQL & "   ,�����X�e�[�^�X "
                    strSQL = strSQL & "   ,���O���e "
                    strSQL = strSQL & "   ,�X�V�]�ƈ��R�[�h "
                    strSQL = strSQL & "   ,�X�V���t���� "
                    strSQL = strSQL & "   ,�[��ID "
                    strSQL = strSQL & "   ,IP�A�h���X "
                    strSQL = strSQL & ") VALUES ( "
                    strSQL = strSQL & "    SEQ_�l�j�V�X�e�����O�e�[�u��.NEXTVAL "
                    strSQL = strSQL & "   ,'" & strProgram & "' "
                    strSQL = strSQL & "   ,'" & strId & "' "
                    strSQL = strSQL & "   ,'" & strStatus & "' "
                    strSQL = strSQL & "   ,'" & strProcessStatus & "' "
                    strSQL = strSQL & "   ,'" & strDescription & "' "
                    strSQL = strSQL & "   ,'" & gclsLoginInfo.EmployeeCode & "' "
                    strSQL = strSQL & "   ,SYSDATE "
                    strSQL = strSQL & "   ,'" & gfncGetComputerName() & "' "
                    strSQL = strSQL & "   ,'" & gfncGetIpAddress() & "' "
                    strSQL = strSQL & ") "

                Case GC_LOG_TARGET_���q�Ǘ����O

                    strSQL = ""
                    strSQL = strSQL & "INSERT INTO �l�j���q�Ǘ����O�e�[�u�� ( "
                    strSQL = strSQL & "    ���OSEQ "
                    strSQL = strSQL & "   ,�T�u���j���[�� "
                    strSQL = strSQL & "   ,�v���O����ID "
                    strSQL = strSQL & "   ,��� "
                    strSQL = strSQL & "   ,�����X�e�[�^�X "
                    strSQL = strSQL & "   ,���O���e "
                    strSQL = strSQL & "   ,�X�V�]�ƈ��R�[�h "
                    strSQL = strSQL & "   ,�X�V���t���� "
                    strSQL = strSQL & "   ,�[��ID "
                    strSQL = strSQL & "   ,IP�A�h���X "
                    strSQL = strSQL & ") VALUES ( "
                    strSQL = strSQL & "    SEQ_�l�j���q�Ǘ����O�e�[�u��.NEXTVAL "
                    strSQL = strSQL & "   ,'" & strProgram & "' "
                    strSQL = strSQL & "   ,'" & strId & "' "
                    strSQL = strSQL & "   ,'" & strStatus & "' "
                    strSQL = strSQL & "   ,'" & strProcessStatus & "' "
                    strSQL = strSQL & "   ,'" & strDescription & "' "
                    strSQL = strSQL & "   ,'" & gclsLoginInfo.EmployeeCode & "' "
                    strSQL = strSQL & "   ,SYSDATE "
                    strSQL = strSQL & "   ,'" & gfncGetComputerName() & "' "
                    strSQL = strSQL & "   ,'" & gfncGetIpAddress() & "' "
                    strSQL = strSQL & ") "

                Case GC_LOG_TARGET_�����l�����O

                    strSQL = ""
                    strSQL = strSQL & "INSERT INTO �l�j�����l�����O�e�[�u�� ( "
                    strSQL = strSQL & "    ���OSEQ "
                    strSQL = strSQL & "   ,�T�u���j���[�� "
                    strSQL = strSQL & "   ,�v���O����ID "
                    strSQL = strSQL & "   ,��� "
                    strSQL = strSQL & "   ,�����X�e�[�^�X "
                    strSQL = strSQL & "   ,���O���e "
                    strSQL = strSQL & "   ,�X�V�]�ƈ��R�[�h "
                    strSQL = strSQL & "   ,�X�V���t���� "
                    strSQL = strSQL & "   ,�[��ID "
                    strSQL = strSQL & "   ,IP�A�h���X "
                    strSQL = strSQL & ") VALUES ( "
                    strSQL = strSQL & "    SEQ_�l�j�����l�����O�e�[�u��.NEXTVAL "
                    strSQL = strSQL & "   ,'" & strProgram & "' "
                    strSQL = strSQL & "   ,'" & strId & "' "
                    strSQL = strSQL & "   ,'" & strStatus & "' "
                    strSQL = strSQL & "   ,'" & strProcessStatus & "' "
                    strSQL = strSQL & "   ,'" & strDescription & "' "
                    strSQL = strSQL & "   ,'" & gclsLoginInfo.EmployeeCode & "' "
                    strSQL = strSQL & "   ,SYSDATE "
                    strSQL = strSQL & "   ,'" & gfncGetComputerName() & "' "
                    strSQL = strSQL & "   ,'" & gfncGetIpAddress() & "' "
                    strSQL = strSQL & ") "

            End Select

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            If blnWithTrans = True Then
                'UPGRADE_WARNING: Couldn't resolve default property of object objLogSession.CommitTrans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call objLogSession.CommitTrans()
                blnLogTrans = False
            End If

            gfncRegistTraceLog = True

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7ed78775-84d9-414c-a9b7-acb3fdb3b056
            'PROC_END:

            'On Error Resume Next

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'If blnWithTrans = True Then
            ' �g�����U�N�V�������̃G���[������
            'If blnLogTrans = True Then

            ' �g�����U�N�V�������I����, �ύX���e���L�����Z��
            'UPGRADE_WARNING: Couldn't resolve default property of object objLogSession.Rollback. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Call objLogSession.Rollback()

            'End If
            'UPGRADE_NOTE: Object objLogSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objLogSession = Nothing
            'End If

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7ed78775-84d9-414c-a9b7-acb3fdb3b056
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f1055231-7a75-4e64-8245-2f59cb440363
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f1055231-7a75-4e64-8245-2f59cb440363

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f1055231-7a75-4e64-8245-2f59cb440363
PROC_FINALLY_END:
        '		On Error Resume Next
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex1 As Exception
        End Try
        Try
            If blnWithTrans = True Then
                Try
                    If blnLogTrans = True Then
                        Call objLogSession.Rollback()
                    End If
                Catch ex1 As Exception
                End Try
                objLogSession = Nothing
            End If
        Catch ex1 As Exception
        End Try
        Try
            Exit Function
        Catch ex1 As Exception
        End Try
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f1055231-7a75-4e64-8245-2f59cb440363
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
