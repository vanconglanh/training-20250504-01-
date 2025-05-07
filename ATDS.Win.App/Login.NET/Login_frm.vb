Option Strict Off
Option Explicit On

Imports Common

Friend Class frmLogin
    '++�C���J�n�@2021�N06��03��:MK�i��j- VB��VB.NET�ϊ�
    'Inherits System.Windows.Forms.Form
    Inherits MKForm
    '--�C���J�n�@2021�N06��03��:MK�i��j- VB��VB.NET�ϊ�

    '�ϐ�
    Private mstrPassword As String ' �p�X���[�h

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click

        If txtPassword.Text <> mstrPassword Then

            Call MsgBox(GC_ERR_MSG_8000, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

            Call txtPassword.Focus()

            Exit Sub

        End If

        gintOkCancel = MsgBoxResult.OK

        ' �t�H�[�������
        Me.Close()

        ' �������ォ�犮�S�ɏ���
        'UPGRADE_NOTE: �I�u�W�F�N�g frmLogin ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        'Me = Nothing
        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        gintOkCancel = MsgBoxResult.Cancel

        Me.Close()

        'UPGRADE_NOTE: �I�u�W�F�N�g frmLogin ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        'Me = Nothing
        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    End Sub
    Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter

        txtPassword.SelectionStart = 0
        txtPassword.SelectionLength = Len(txtPassword.Text)

    End Sub
    Private Sub txtEmployeeCode_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtEmployeeCode.Enter

        txtEmployeeCode.SelectionStart = 0
        txtEmployeeCode.SelectionLength = Len(txtEmployeeCode.Text)

    End Sub
    Private Sub txtEmployeeCode_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtEmployeeCode.Validating
        Dim Cancel As Boolean = eventArgs.Cancel

        Dim objDys�]�ƈ��}�X�^ As Object
        Dim strSQL As String

        '--------------------------------------------------------------------------
        ' SQL�� �쐬
        '--------------------------------------------------------------------------
        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    JM.��ЃR�[�h  , "
        strSQL = strSQL & Chr(10) & "    JM.�����R�[�h  , "
        strSQL = strSQL & Chr(10) & "    JM.�]�ƈ��R�[�h, "
        strSQL = strSQL & Chr(10) & "    JM.�]�ƈ�������, "
        strSQL = strSQL & Chr(10) & "    JM.�p�X���[�h  , "
        strSQL = strSQL & Chr(10) & "    JM.��E�ʃR�[�h, "
        strSQL = strSQL & Chr(10) & "    JM.�����N      , "
        strSQL = strSQL & Chr(10) & "    NVL(JM.�ގЗ\���,'99999999') AS �ގЗ\���, "
        strSQL = strSQL & Chr(10) & "    MM.�W���P      , "
        strSQL = strSQL & Chr(10) & "    BM.�V�X�e������, "
        strSQL = strSQL & Chr(10) & "    TO_CHAR(SYSDATE,'YYYYMMDD') AS �V�X�e�����t "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    �]�ƈ��}�X�^ JM, "
        strSQL = strSQL & Chr(10) & "    �����}�X�^   BM, "
        strSQL = strSQL & Chr(10) & "    ���̃}�X�^   MM  "
        strSQL = strSQL & Chr(10) & " WHERE JM.�]�ƈ��R�[�h = '" & txtEmployeeCode.Text & "' "
        strSQL = strSQL & Chr(10) & "   AND JM.�����R�[�h   = BM.�����R�[�h(+) "
        strSQL = strSQL & Chr(10) & "   AND JM.��E�ʃR�[�h = MM.�R�[�h    (+) "
        strSQL = strSQL & Chr(10) & "   AND '��E��'        = MM.����      (+) "

        'UPGRADE_WARNING: �I�u�W�F�N�g gobjOraDatabase.CreateDynaset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        objDys�]�ƈ��}�X�^ = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        With objDys�]�ƈ��}�X�^

            'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If .EOF = True Then

                Cancel = True

                Call MsgBox(GC_ERR_MSG_0003, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                txtEmployeeCode.SelectionStart = 0
                txtEmployeeCode.SelectionLength = Len(txtEmployeeCode.Text)

                GoTo EventExitSub

            Else

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If .Fields("�ގЗ\���").Value < VB6.Format(Now, "YYYYMMDD") Then

                    Cancel = True

                    Call MsgBox(GC_ERR_MSG_0019, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                    txtEmployeeCode.SelectionStart = 0
                    txtEmployeeCode.SelectionLength = Len(txtEmployeeCode.Text)

                    GoTo EventExitSub

                End If

                '            If mfncFieldVal(.Fields("�����N").Value) <> "A" And _
                ''               mfncFieldVal(.Fields("�����N").Value) <> "B" Then
                '
                '                Cancel = True
                '
                '                Call MsgBox("�V�X�e�����g�p���錠��������܂���B", _
                ''                            vbOKOnly + vbCritical, _
                ''                            GC_ERR_TITLE)
                '
                '                txtEmployeeCode.SelStart = 0
                '                txtEmployeeCode.SelLength = Len(txtEmployeeCode.Text)
                '
                '                Exit Sub
                '
                '            End If

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gstrCompanyCode = mfncFieldVal(.Fields("��ЃR�[�h").Value)
                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gstrPostCode = mfncFieldVal(.Fields("�����R�[�h").Value)
                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gstrEmployeeCode = mfncFieldVal(.Fields("�]�ƈ��R�[�h").Value)

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gintSystemAuthority = mfncFieldCur(.Fields("�V�X�e������").Value)
                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If mfncFieldCur(.Fields("�W���P").Value) <> 0 Then

                    'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    gintSystemAuthority = mfncFieldCur(.Fields("�W���P").Value)

                End If

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gstrRank = mfncFieldVal(.Fields("�����N").Value)

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gstrEmployeeName = mfncFieldVal(.Fields("�]�ƈ�������").Value)

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gintOfficialPosition = mfncFieldCur(.Fields("��E�ʃR�[�h").Value)

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                mstrPassword = mfncFieldVal(.Fields("�p�X���[�h").Value)

                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g gvntLoginDate �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                gvntLoginDate = mfncFieldVal(.Fields("�V�X�e�����t").Value)

            End If

            'UPGRADE_WARNING: �I�u�W�F�N�g objDys�]�ƈ��}�X�^.Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call .Close()

        End With

        'UPGRADE_NOTE: �I�u�W�F�N�g objDys�]�ƈ��}�X�^ ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        objDys�]�ƈ��}�X�^ = Nothing

        '�����N���擾�̏ꍇ�͍ŉ��ʃ����N���擾
        If Len(gstrRank) = 0 Then

            If mfncGetLowRank(gobjOraDatabase, gstrRank) = True Then

                Cancel = True

                Call MsgBox(GC_ERR_MSG_0017, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                txtEmployeeCode.SelectionStart = 0
                txtEmployeeCode.SelectionLength = Len(txtPassword.Text)

                GoTo EventExitSub

            End If

        End If

EventExitSub:
        eventArgs.Cancel = Cancel
    End Sub

    Private Function mfncFieldVal(ByVal pvntTar As Object) As Object

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDbNull(pvntTar) = True Then
            'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            mfncFieldVal = vbNullString
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g pvntTar �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            mfncFieldVal = CStr(pvntTar)
        End If

    End Function

    Public Function mfncFieldCur(ByVal pvntTar As Object) As Decimal

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDbNull(pvntTar) = True Or Len(pvntTar) = 0 Then

            mfncFieldCur = 0

        Else

            If IsNumeric(pvntTar) = True Then

                'UPGRADE_WARNING: �I�u�W�F�N�g pvntTar �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                mfncFieldCur = CDec(pvntTar)

            Else

                Call MsgBox("�������ڂɐ����ȊO�̒l�������Ă��܂��B", MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, GC_ERR_TITLE)

            End If

        End If

    End Function
    '******************************************************************************
    ' �� �� ��  : mfncGetLowRank
    ' �X�R�[�v  : Private
    ' �������e  : �ŉ��ʃ����N �擾
    ' ���@�@�l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjDB              Object            O     �f�[�^�x�[�X
    '   pstrRank            String            O     �����N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  �A��@�F��     �@�@�V�K�쐬
    '
    '******************************************************************************
    Private Function mfncGetLowRank(ByRef pobjDB As Object, ByRef pstrRank As String) As Boolean

        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "mfncGetLowRank"
        Dim strSQL As String
        Dim objDys�����ݒ�e�[�u�� As Object
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "mfncGetLowRank"
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDys�����ݒ�e�[�u�� As Object
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i�ُ�I��)
            mfncGetLowRank = True

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    MAX(�����N) AS �����N "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �����ݒ�e�[�u�� "

            'UPGRADE_WARNING: �I�u�W�F�N�g pobjDB.CreateDynaset �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            objDys�����ݒ�e�[�u�� = pobjDB.CreateDynaset(strSQL, &H4)

            With objDys�����ݒ�e�[�u��

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: �I�u�W�F�N�g objDys�����ݒ�e�[�u��.EOF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If .EOF = False Then

                    ' �߂�l��ݒ�i����I��)
                    mfncGetLowRank = False

                    'UPGRADE_WARNING: �I�u�W�F�N�g objDys�����ݒ�e�[�u��.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g mfncFieldVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    pstrRank = mfncFieldVal(.Fields("�����N").Value)

                    'UPGRADE_WARNING: �I�u�W�F�N�g objDys�����ݒ�e�[�u��.Close �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call .Close()

                End If

            End With

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:08373125-1912-42ee-b05a-045cfe5f44a7
            'PROC_END:

            'UPGRADE_NOTE: �I�u�W�F�N�g objDys�����ݒ�e�[�u�� ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
            'objDys�����ݒ�e�[�u�� = Nothing

            'Exit Function

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:08373125-1912-42ee-b05a-045cfe5f44a7
        Catch ex As Exception
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e
            'Resume PROC_END
            '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e

            '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e
PROC_FINALLY_END:
        objDys�����ݒ�e�[�u�� = Nothing
        Exit Function
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b5de635-bfeb-4fb5-a94f-b5bccfc0900e
        '--�C���I���@2021�N05��31:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Class

