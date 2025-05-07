Option Strict Off
Option Explicit On


Imports Common
Imports MKOra.Core
Imports Microsoft.VisualBasic.Compatibility
Imports System.Collections.Generic

Module basCommonFunction
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : CommonFunction.bas
    ' ��    �e    : �V�X�e�����ʊ֐����W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncCheckControlData     (�R���g���[�� �`�F�b�N����)
    '                   gfncCheckDate            (���t���ڃ`�F�b�N)
    '                   gfncCheckMemberCode      (����R�[�h �`�F�b�N ����)
    '                   gfncCheckNumeric         (���l���ڃ`�F�b�N)
    '                   gfncCheckTime            (���ԍ��ڃ`�F�b�N)
    '                   gfncCnvCutValue          (���l�ۂߕϊ�)
    '                   gfncCnvMinutesToTime     (�����玞�Ԃ֕ϊ�)
    '                   gfncCnvTimeToMinutes     (���Ԃ��番�֕ϊ�)
    '                   gfncFieldCur             (�k������i���l�j)
    '                   gfncFieldVal             (�k������i������j)
    '                   gfncGetCodeToControl     (�R���g���[������R�[�h�𔲂��o��)
    '                   gfncGetCompanyCode       (��ЃR���{�����ЃR�[�h�𔲂��o��)
    '                   gfncGetRecordDate        (����擾)
    '                   gfncGetINCompanyCode     (�R���{�ɕ\������Ă���f�[�^����ЃR�[�h���擾����)
    '                   gfncGetTaxRate           (�ŗ��擾)
    '                   gfncLinkCompanyToCarKbn  (��ЃR���{�Ǝ��q�敪�R���{�̃����N���s��)
    '                   gfncLinkCompanyToCarType (��ЃR���{�ƎԎ�R�[�h�R���{�̃����N���s��)
    '                   gfncLinkCompanyToEnwari  (��ЃR���{�Ɖ����ݒ�R���{�̃����N���s��)
    '                   gfncLinkCompanyToPost    (��ЃR���{�Ə����R���{�̃����N���s��)
    '                   gsubClearObject          (�I�u�W�F�N�g �J��)
    '                   gsubControlGotFocus      (�R���g���[�� �I��)
    '                   gsubDispErrMsg           (�G���[���b�Z�[�W�\��)
    '                   gsubGetFiscalYear        (���ݓ������N�x���擾)
    '                   gsubGetFiscalYearMonth   (���ݓ������N���x���擾)
    '                   gsubSetComboBusho        (��ЃR�[�h�ɑΉ����镔���R���{���X�g��ݒ肷��)
    '                   gsubSetComboCarKbn       (��ЃR�[�h�ɑΉ�������q�敪�R���{���X�g��ݒ肷��)
    '                   gsubSetComboCarType      (��ЃR�[�h�ɑΉ�����Ԏ�R�[�h�R���{���X�g��ݒ肷��)
    '                   gsubSetComboEnwari       (��ЃR�[�h�ɑΉ����鉓���ݒ�R���{���X�g��ݒ肷��)
    '                   gsubSetComboListIndex    (�w�肳�ꂽ�R�[�h�ɊY������f�[�^��\������)
    '                   gsubSetComboNameMaster   (�w�肳�ꂽ���ʂ̖��̃}�X�^���R���{�ɕ\��)
    '                   gsubSetFocus             (�t�H�[�J�X�Z�b�g)
    '                   Qt                       (�t�B�[���h�ɃV���O���N�I�[�e�[�V������t������)
    '                   gfncGetNameToControl     (�R���g���[�����疼�̂𔲂��o��)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  �A��  �F��         �V�K�쐬
    '   02.01       2008/04/09  �A��  �F��         �����ݒ�R���{�̕\���ُ�ɑΉ�
    '   02.02       2008/06/21  �A��  �F��         ���̃R���g���[���}�X�^�̉�ЃR�[�h�t���Ή�
    '                                              �ˉ�Ж��ɖ{�l���S�z���قȂ��,
    '                                                �Ǘ��R�[�h����ЃR�[�h�Ƃ��Ė{�l���S�z���擾
    '   02.03       2009/11/11  KSR                �R���g���[�����疼�̂𔲂��o���֐��ǉ�
    '   02.04       2010/07/21  �A��  �F��         �R���g���[�����b�N��Ԑݒ菈����ǉ�
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Public Const GC_CHECK_NUMERIC As Short = 0 ' ���l�`�F�b�N
    Public Const GC_CHECK_NUMERIC_LEN As Short = 1 ' ���l&���`�F�b�N
    Public Const GC_CHECK_LEN As Short = 2 ' �����`�F�b�N
    Public Const GC_CHECK_YMD As Short = 3 ' ���t(�N����)�`�F�b�N
    Public Const GC_CHECK_YM As Short = 4 ' ���t(�N��)�`�F�b�N
    Public Const GC_CHECK_MD As Short = 5 ' ���t(����)�`�F�b�N
    Public Const GC_CHECK_TIME As Short = 6 ' �����`�F�b�N
    Public Const GC_CHECK_COMBO As Short = 7 ' �R���{�`�F�b�N

    Public Const GC_CNV_MODE_TRUNC As Short = 0 ' �؂�̂�
    Public Const GC_CNV_MODE_CEILING As Short = 1 ' �؂�グ
    Public Const GC_CNV_MODE_ROUND As Short = 2 ' �l�̌ܓ�

    '==============================================================================
    '�ϐ�
    '==============================================================================
    Public gstrDate As String ' ���t�ҏW�O(���͒l)
    Public gstrEditDate As String ' ���t�ҏW��̒l(yyyy(�N��)mm/dd)
    Public gstrTime As String ' �����ҏW�O(���͒l)
    Public gstrEditTime As String ' �����ҏW��̒l(h:mm)
    Public gstrSpcFrst() As String ' ���ʃt�@�[�X�g
    Public gstrSpcFrstNm() As String ' ���ʃt�@�[�X�g��

    '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
    Public gctlActiveControl As Control
    '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

    Public Structure TAG_Zeiritu ' �ŗ�
        Dim mTstr�ŗ��R�[�h As String
        Dim mTstr�ŗ� As String
    End Structure

    '******************************************************************************
    ' �� �� ��  : gfncCheckControlData
    ' �X�R�[�v  : Public
    ' �������e  : �R���g���[�� �`�F�b�N����
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintChktype         Integer           I     �`�F�b�N�^�C�v
    '   pintLength          Integer           I     ���ڒ�
    '   pintDecimal         Integer           I     ������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCheckControlData(ByVal pintChktype As Short, Optional ByVal pintLength As Short = 0, Optional ByVal pintDecimal As Short = 0) As Object

        Dim lngIdx As Short
        Dim intErrFlg As Short

        ' �߂�l���������i�ُ�I���j
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gfncCheckControlData = True

        '++�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
        'If not set value of active control, this function will return nothing
        'please set value for ActiveControl before use this function
        If gctlActiveControl Is Nothing Then
            Return Nothing
        End If
        '--�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
        Select Case pintChktype
            '--------------------------------------------------------------------------
            '���l�����@
            '--------------------------------------------------------------------------
            Case GC_CHECK_NUMERIC

                '���l���������s���܂��B
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If IsNumeric(VB6.GetActiveControl()) = False Then
                If IsNumeric(gctlActiveControl.Text) = False Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox(GC_ERR_MSG_9003, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '̫�ϯĂ��ĺ��۰قɾ�Ă���
                'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'VB6.GetActiveControl = Right(CStr(CDbl("0000000000") + CDbl(VB6.GetActiveControl())), pintLength)
                Utils.SetValueControl(gctlActiveControl, Right(Utils.getValueControl(gctlActiveControl), pintLength).PadLeft(pintLength, "0"))
                '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                '���l�����A
                '--------------------------------------------------------------------------
            Case GC_CHECK_NUMERIC_LEN

                '���l���������s���܂��B
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If IsNumeric(VB6.GetActiveControl()) = False Then
                If IsNumeric(gctlActiveControl.Text) = False Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox(GC_ERR_MSG_9003, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)


                    Exit Function

                    'gfncCheckNumeric�֐�(���l���ڂ�����)
                    'հ�ް�֐� ����1(���۰ق̒l),����2(ϲŽ�ł�OK���True) ,����3(�ő包��) ,����4(�����_����)
                    '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    'ElseIf gfncCheckNumeric(CStr(VB6.GetActiveControl()), True, pintLength, pintDecimal) = True Then
                ElseIf gfncCheckNumeric(Utils.getValueControl(gctlActiveControl), True, pintLength, pintDecimal) = True Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    '�����_�����ɂ��o�͂���ү���ނ𔻒f����B
                    If pintDecimal = 0 Then

                        ' �G���[���b�Z�[�W��\��
                        Call MsgBox("����" & pintLength & "���ȓ��œ��͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Else

                        ' �G���[���b�Z�[�W��\��
                        Call MsgBox("����" & pintLength & "���ȓ�, �����_�ȉ�" & pintDecimal & "���ȓ��œ��͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)
                    End If

                    Exit Function

                End If

                '�����_��������̫�ϯĂ��ĺ��۰قɾ�Ă���
                Select Case pintDecimal
                    Case 0
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0"))
                        '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    Case 1
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.0")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.0"))
                        '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    Case 2
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.00")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.00"))
                       '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    Case 3
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.000")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.000"))
                       '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    Case 4
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.0000")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.0000"))
                       '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    Case 5
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl = VB6.Format(VB6.GetActiveControl(), "#,##0.00000")
                        Utils.SetValueControl(gctlActiveControl, VB6.Format(Utils.getValueControl(gctlActiveControl), "#,##0.00000"))
                        '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                End Select

                '--------------------------------------------------------------------------
                '��������
                '--------------------------------------------------------------------------
            Case GC_CHECK_LEN

                'Unicode��Asciicode�ɕϊ������޲Đ�������, ���蕶�����޲Đ��Ɣ�r
                'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                'If LenB(StrConv(VB6.GetActiveControl().ToString(), vbFromUnicode)) > pintLength Then
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If Utils.LenB(Utils.StrConv(VB6.GetActiveControl().ToString(), vbFromUniCode)) > pintLength Then
                If Utils.LenB(Utils.StrConv(Utils.getValueControl(gctlActiveControl), vbFromUniCode)) > pintLength Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox("���p" & pintLength & "��, �S�p" & pintLength / 2 & "���ȓ��ŕ�������͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '--------------------------------------------------------------------------
                '���t����
                '--------------------------------------------------------------------------
            Case GC_CHECK_YMD

                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If gfncCheckDate(activeControl, GC_CHECK_YMD) = True Then
                If gfncCheckDate(gctlActiveControl, GC_CHECK_YMD) = True Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    Call MsgBox("���t(�N����)����͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'VB6.GetActiveControl = VB6.Format(VB6.Format(gstrDate, "0000/00/00"), "yyyy(gggee)/mm/dd")
                Utils.SetValueControl(gctlActiveControl, VB6.Format(VB6.Format(gstrDate, "0000/00/00"), "yyyy(gggee)/mm/dd"))
                '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                '�N������
                '--------------------------------------------------------------------------
            Case GC_CHECK_YM

                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If gfncCheckDate(activeControl, GC_CHECK_YM) = True Then
                If gfncCheckDate(gctlActiveControl, GC_CHECK_YM) = True Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox("���t(�N��)����͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '̫�ϯĂ��ĺ��۰قɾ�Ă���
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'VB6.GetActiveControl = VB6.Format(VB6.Format(gstrDate, "0000/00"), "yyyy(gggee)/mm")
                Utils.SetValueControl(gctlActiveControl, VB6.Format(VB6.Format(gstrDate, "0000/00"), "yyyy(gggee)/mm"))
'--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                '��������
                '--------------------------------------------------------------------------
            Case GC_CHECK_MD

                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If gfncCheckDate(VB6.GetActiveControl(), GC_CHECK_MD) = True Then
                If gfncCheckDate(gctlActiveControl, GC_CHECK_MD) = True Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox("���t(����)����͂��ĉ������B", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '̫�ϯĂ��ĺ��۰قɾ�Ă���
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'VB6.GetActiveControl = VB6.Format(VB6.Format(gstrDate, "00/00"), "mm/dd")
                Utils.SetValueControl(gctlActiveControl, VB6.Format(VB6.Format(gstrDate, "00/00"), "mm/dd"))
'--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                '��������
                '--------------------------------------------------------------------------
            Case GC_CHECK_TIME

                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'If gfncCheckTime(VB6.GetActiveControl()) = True Then
                If gfncCheckTime(gctlActiveControl) = True Then
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox(GC_ERR_MSG_9029, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                '--------------------------------------------------------------------------
                '��������
                '--------------------------------------------------------------------------
            Case GC_CHECK_COMBO

                ' �t���O��OFF�ɐݒ�
                intErrFlg = GC_FLG_OFF

                'UPGRADE_ISSUE: Control ListCount could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                'For lngIdx = 0 To VB6.GetActiveControl().ListCount - 1
                For lngIdx = 0 To CType(gctlActiveControl, ComboBox).Items.Count - 1
                    '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                    '�����ޯ���̓��e�Ɠ��͂���1���ڂ���������
                    'UPGRADE_ISSUE: Control List could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                    '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                    'If RTrim(Mid(VB6.GetActiveControl() & Space(pintLength), 1, pintLength)) = RTrim(Mid(VB6.GetActiveControl().List(lngIdx), 1, pintLength)) Then
                    If RTrim(Mid(Utils.getValueControl(gctlActiveControl) & Space(pintLength), 1, pintLength)) = RTrim(Mid(CType(gctlActiveControl, ComboBox).Items(lngIdx), 1, pintLength)) Then
                        '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                        '�����ޯ���̓��e��\������
                        'UPGRADE_ISSUE: Control ListIndex could not be resolved because it was within the generic namespace ActiveControl. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
                        'VB6.GetActiveControl().ListIndex = lngIdx
                        CType(gctlActiveControl, ComboBox).SelectedIndex = lngIdx
                        '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�

                        ' �t���O��ON�ɐݒ�
                        intErrFlg = GC_FLG_ON

                        Exit For

                    End If

                Next lngIdx

                ' ��v������e���R���{�{�b�N�X�ɂȂ������ꍇ
                If intErrFlg = GC_FLG_OFF Then

                    ' �G���[���b�Z�[�W��\��
                    Call MsgBox(GC_ERR_MSG_9002, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

        End Select

        ' �߂�l��ݒ�i����I���j
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        gfncCheckControlData = False

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCheckDate
    ' �X�R�[�v  : Public
    ' �������e  : ���t���ڃ`�F�b�N
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlFiled           String            O     �`�F�b�N�Ώ�
    '   pintMode            Integer           I     �`�F�b�N���[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCheckDate(ByRef pctlFiled As System.Windows.Forms.Control, ByVal pintMode As Short) As Boolean

        gfncCheckDate = False
        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
        'gstrEditDate = pctlFiled.ToString()
        gstrEditDate = pctlFiled.Text
        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
        'If IsNumeric(pctlFiled) Then
        If IsNumeric(pctlFiled.Text) Then
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�

            Select Case pintMode
                '----------------------------------------------------------------------
                ' �N����
                '----------------------------------------------------------------------
                Case GC_CHECK_YMD

                    '���͌����ɂ����t�^�ɕϊ�����
                    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                    'Select Case Len(pctlFiled)
                    Select Case Len(Utils.getValueControl(pctlFiled))
                    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case 1 To 2
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            'gstrEditDate = VB6.Format(Now, "yyyy/mm") & "/" & VB6.Format(pctlFiled, "00")
                            gstrEditDate = VB6.Format(Now, "yyyy/mm") & "/" & VB6.Format(Utils.getValueControl(pctlFiled), "00")
                            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case 3 To 4
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            'gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(pctlFiled, "00/00")
                            gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(Utils.getValueControl(pctlFiled), "00/00")
                            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case 5 To 6
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            'gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(pctlFiled, "00/00/00")
                            gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(Utils.getValueControl(pctlFiled), "00/00/00")
                            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case Else
                            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                            'If LenB(StrConv(pctlFiled.ToString(), vbFromUnicode)) > 8 Then
                            If Utils.LenB(Utils.StrConv(Utils.getValueControl(pctlFiled), vbFromUniCode)) > 8 Then
                                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                                gfncCheckDate = True
                                Exit Function
                            Else
                                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                                'gstrEditDate = VB6.Format(pctlFiled, "0000/00/00")
                                gstrEditDate = VB6.Format(Utils.getValueControl(pctlFiled), "0000/00/00")
                                '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                            End If
                    End Select
                    '----------------------------------------------------------------------
                    ' �N��
                    '----------------------------------------------------------------------
                Case GC_CHECK_YM

                    '���͌����ɂ����t�^�ɕϊ�����
                    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                    'Select Case Len(pctlFiled)
                    Select Case Len(Utils.getValueControl(pctlFiled))
                    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case 1 To 2
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            'gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(pctlFiled, "00")
                            gstrEditDate = VB6.Format(Now, "yyyy") & "/" & VB6.Format(Utils.getValueControl(pctlFiled), "00")
                            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case 3 To 4
                            'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            'gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(pctlFiled, "00/00")
                            gstrEditDate = Mid(VB6.Format(Now, "yyyy"), 1, 2) & VB6.Format(Utils.getValueControl(pctlFiled), "00/00")
                            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        Case Else
                            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                            'If LenB(StrConv(pctlFiled.ToString(), vbFromUnicode)) > 6 Then
                            If Utils.LenB(Utils.StrConv(Utils.getValueControl(pctlFiled), vbFromUniCode)) > 6 Then
                                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                                gfncCheckDate = True
                                Exit Function
                            Else
                                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'gstrEditDate = VB6.Format(pctlFiled, "0000/00")
                                gstrEditDate = VB6.Format(Utils.getValueControl(pctlFiled), "0000/00")
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                    End Select
            End Select

        Else

            Select Case pintMode
                '----------------------------------------------------------------------
                ' �N����
                '----------------------------------------------------------------------
                Case GC_CHECK_YMD

                    '���t�̑Ó�������
                    If Not IsDate(gstrEditDate) Then
                        'yyyy(�a��)/mm/dd�̎�, �ĕ�������B
                        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        'gstrEditDate = CStr(Mid(pctlFiled.ToString(), 1, 4) & "/" & Mid(Right(pctlFiled.ToString(), 5), 1, 3) & Right(pctlFiled.ToString(), 2))
                        gstrEditDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & "/" & Mid(Right(Utils.getValueControl(pctlFiled), 5), 1, 2) & "/" & Right(Utils.getValueControl(pctlFiled), 2))
                        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                    End If

                    '----------------------------------------------------------------------
                    ' �N��
                    '----------------------------------------------------------------------
                Case GC_CHECK_YM
                    '���t�̑Ó�������
                    If Not IsDate(gstrEditDate) Then
                        'yyyy(�a��)/mm/dd�̎�, �ĕ�������B
                        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                        'gstrEditDate = CStr(Mid(pctlFiled.ToString(), 1, 4) & "/" & Right(pctlFiled.ToString(), 2))
                        gstrEditDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & "/" & Right(Utils.getValueControl(pctlFiled), 2))
                        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                    End If

            End Select

        End If

        '--------------------------------------------------------------------------
        ' ���t�̑Ó�������
        '--------------------------------------------------------------------------
        If Not IsDate(gstrEditDate) Then
            gfncCheckDate = True
            Exit Function
        End If

        Select Case pintMode
            '--------------------------------------------------------------------------
            ' �N����
            '--------------------------------------------------------------------------
            Case GC_CHECK_YMD

                If Len(gstrEditDate) = Len("yyyy/mm/dd") Then

                    If gstrEditDate > "2087/12/31" Then

                        gstrEditDate = "2087/12/31"

                    End If

                    If gstrEditDate < "1868/10/23" Then

                        gstrEditDate = "1868/10/23"

                    End If

                End If

                '�ҏW��ĕ\��
                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                'pctlFiled = VB6.Format(gstrEditDate, "yyyy(gggee)/mm/dd")
                Utils.SetValueControl(pctlFiled, VB6.Format(gstrEditDate, "yyyy(gggee)/mm/dd"))
                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                '���t�̓��͒l��Ҕ�(yyyymmdd)
                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                gstrDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & Mid(Right(Utils.getValueControl(pctlFiled), 5), 1, 2) & Right(Utils.getValueControl(pctlFiled), 2))
                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                ' �N��
                '--------------------------------------------------------------------------
            Case GC_CHECK_YM

                If Len(gstrEditDate) = Len("yyyy/mm") Then

                    If gstrEditDate > "2087/12" Then

                        gstrEditDate = "2087/12"

                    End If

                    If gstrEditDate < "1868/11" Then

                        gstrEditDate = "1868/11"

                    End If

                End If

                '�ҏW��ĕ\��
                'UPGRADE_WARNING: Couldn't resolve default property of object pctlFiled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                'pctlFiled = VB6.Format(gstrEditDate, "yyyy(gggee)/mm")
                Utils.SetValueControl(pctlFiled, VB6.Format(gstrEditDate, "yyyy(gggee)/mm"))
                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

                '���t�̓��͒l��Ҕ�(yyyymm)
                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                'gstrDate = CStr(Mid(pctlFiled.ToString(), 1, 4) & Right(pctlFiled.ToString(), 2))
                gstrDate = CStr(Mid(Utils.getValueControl(pctlFiled), 1, 4) & Right(Utils.getValueControl(pctlFiled), 2))
                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        End Select

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCheckMemberCode
    ' �X�R�[�v  : Public
    ' �������e  : ����R�[�h �`�F�b�N ����
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���             �ް�����          I/O   �� ��
    '   --------------------+-----------------+-----+------------------------------
    '   pstrTarget           String            I     �`�F�b�N�Ώ�
    '   pstrMemberParentCode String            I/O   ����R�[�h
    '   pstrMemberBranchCode String            I/O   ����}�R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncCheckMemberCode(ByVal pstrTarget As String, ByRef pstrMemberParentCode As String, ByRef pstrMemberBranchCode As String) As Boolean

        Dim intIdx As Short

        gfncCheckMemberCode = False

        pstrMemberParentCode = Trim(pstrTarget)

        '--------------------------------------------------------------------------
        ' �R�[�h���͌`���`�F�b�N
        '--------------------------------------------------------------------------
        If IsNumeric(pstrMemberParentCode) Then

            gfncCheckMemberCode = True

            '----------------------------------------------------------------------
            ' ����R�[�h�݂̂̓��́i�}�R�[�h��'0000'�ɐݒ�j
            '----------------------------------------------------------------------
            If Len(pstrMemberParentCode) = 7 Then

                pstrMemberBranchCode = "0000"
                gfncCheckMemberCode = False

            End If

            ' ����R�[�h�{�}�R�[�h�̓���

            If Len(pstrMemberParentCode) = 11 Then

                pstrMemberBranchCode = Right(pstrMemberParentCode, GC_LEN_MEMBER_CODE_BRANCH)

                pstrMemberParentCode = Left(pstrMemberParentCode, GC_LEN_MEMBER_CODE_PARENT)

                gfncCheckMemberCode = False

            End If

            ' ����R�[�h�E�}�R�[�h�̋�؂肪����Ƃ�
        Else

            For intIdx = 1 To Len(pstrMemberParentCode)

                If Not IsNumeric(Mid(pstrMemberParentCode, intIdx, 1)) Then

                    pstrMemberBranchCode = Right(pstrMemberParentCode, Len(pstrMemberParentCode) - intIdx)

                    pstrMemberParentCode = Left(pstrMemberParentCode, intIdx - 1)

                    Exit For

                End If

            Next

            ' ����R�[�h���G���[
            If intIdx = 0 Or intIdx > 8 Then

                gfncCheckMemberCode = True

            Else

                If IsNumeric(pstrMemberParentCode) And IsNumeric(pstrMemberBranchCode) Then

                    pstrMemberParentCode = VB6.Format(Val(pstrMemberParentCode), New String("0", GC_LEN_MEMBER_CODE_PARENT))

                    pstrMemberBranchCode = VB6.Format(Val(pstrMemberBranchCode), New String("0", GC_LEN_MEMBER_CODE_BRANCH))

                Else

                    gfncCheckMemberCode = True

                End If

            End If

        End If

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCheckNumeric
    ' �X�R�[�v  : Public
    ' �������e  : ���l���ڃ`�F�b�N
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrNum             String            I     �`�F�b�N�Ώ�
    '   pblnMinus           Boolean           I     ���l�͈̔͂Ƀ}�C�i�X����(-1)
    '   pintMaxFigure       Integer           I     �ő包��
    '   pintDecimalNum      Integer           I     �����_����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCheckNumeric(ByVal pstrNum As String, ByVal pblnMinus As Boolean, ByVal pintMaxFigure As Short, ByVal pintDecimalNum As Short) As Boolean

        gfncCheckNumeric = False

        '***********************
        ' ���ڂ��͈͓��ɂ��邩����
        '***********************
        '���ڂ̒l�̐�����������,0,���̂Ƃ�
        If pblnMinus Then

            'ϲŽ��OK�ł����ړ��͉\����1�̏ꍇ�ʹװ�Ƃ���B
            If pintMaxFigure - 1 = 0 Then

                '�װ��\�����܂�
                Call MsgBox("1���̍��ڂɕ�����͂ł��܂���B", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, GC_ERR_TITLE)

                Exit Function

            End If

            '���ڂ͈̔�����
            If CDec(pstrNum) <= CDec("-1" & New String("0", pintMaxFigure)) Or CDec(pstrNum) >= CDec("1" & New String("0", pintMaxFigure)) Then

                gfncCheckNumeric = True

                Exit Function

            End If

            ' ���ڂ̒l�̐������������̂Ƃ�
        Else

            If CDec(pstrNum) < 0 Or CDec(pstrNum) >= CDec("1" & New String("0", pintMaxFigure)) Then

                gfncCheckNumeric = True

                Exit Function

            End If

        End If

        '***********************
        '���ڂ̏����_����
        '***********************
        '�����_�̉E����̈ʒu�Ə����_�������r
        If InStr(pstrNum, ".") = 0 Then

        Else

            If Len(pstrNum) - InStr(pstrNum, ".") > pintDecimalNum Then

                gfncCheckNumeric = True

                Exit Function

            End If

        End If

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCheckTime
    ' �X�R�[�v  : Public
    ' �������e  : ���ԍ��ڃ`�F�b�N
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlFiled           String            O     �`�F�b�N�Ώ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCheckTime(ByRef pctlField As System.Windows.Forms.Control) As Boolean

        Dim intDecimal As Short

        gfncCheckTime = False
        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
        'gstrEditTime = pctlField.ToString()
        gstrEditTime = pctlField.Text
        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�

        '":" �� "." �ɕϊ�
        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
        intDecimal = InStr(pctlField.Text, ":")
        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
        If intDecimal <> 0 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object pctlField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
            'pctlField = Left(gstrEditTime, intDecimal - 1) & "." & Mid(gstrEditTime, intDecimal + 1)
            Utils.SetValueControl(pctlField, Left(gstrEditTime, intDecimal - 1) & "." & Mid(gstrEditTime, intDecimal + 1))
            '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

        End If

        '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
        'If IsNumeric(pctlField) Then
        If IsNumeric(pctlField.Text) Then
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            '"." �̈ʒu������
            '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
            'intDecimal = InStr(pctlField.ToString(), ".")
            intDecimal = InStr(pctlField.Text, ".")
            '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�

            If intDecimal <> 0 Then
                '���������� (����) & �i���j
                'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                'If LenB(StrConv(Left(pctlField.ToString(), intDecimal - 1), vbFromUnicode)) > 2 Or LenB(StrConv(Mid(pctlField.ToString(), intDecimal + 1), vbFromUnicode)) > 2 Then
                If Utils.LenB(Utils.StrConv(Left(pctlField.Text, intDecimal - 1), vbFromUniCode)) > 2 Or Utils.LenB(Utils.StrConv(Mid(pctlField.Text, intDecimal + 1), vbFromUniCode)) > 2 Then
                    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                    gfncCheckTime = True
                    Exit Function
                End If
            Else
                'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                'If LenB(StrConv(pctlField.ToString(), vbFromUnicode)) > 2 Then
                If Utils.LenB(Utils.StrConv(pctlField.Text, vbFromUniCode)) > 2 Then
                    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                    gfncCheckTime = True
                    Exit Function
                End If
            End If

            '���͌����ɂ�莞�Ԍ`���ɕϊ�����
            Select Case intDecimal
                Case 0
                    'UPGRADE_WARNING: Couldn't resolve default property of object pctlField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N06��24��:MK�i��j- VB��VB.NET�ϊ�
                    'gstrEditTime = VB6.Format(pctlField, "00") & ":" & "00"
                    gstrEditTime = VB6.Format(pctlField.Text, "00") & ":" & "00"
                    '--�C���J�n�@2021�N06��24��:MK�i��j- VB��VB.NET�ϊ�
                Case 1
                    '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    'gstrEditTime = "00" & ":" & VB6.Format(Mid(pctlField.ToString(), 2), "00")
                    gstrEditTime = "00" & ":" & VB6.Format(Mid(pctlField.Text, 2), "00")
                    '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                Case 2
                    '"h." �̓��͌`���̂Ƃ�����"00" ������B
                    '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    'If Mid(pctlField.ToString(), 3) <> "" Then
                    If Mid(pctlField.Text, 3) <> "" Then
                        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 1), "00") & ":" & VB6.Format(Mid(pctlField.ToString(), 3), "00")
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 1), "00") & ":" & VB6.Format(Mid(pctlField.Text, 3), "00")
                        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    Else
                        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 1), "00") & ":" & "00"
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 1), "00") & ":" & "00"
                        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    End If
                Case 3
                    '"hh." �̓��͌`���̂Ƃ�����"00" ������B
                    '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    'If Mid(pctlField.ToString(), 4) <> "" Then
                    If Mid(pctlField.Text, 4) <> "" Then
                        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 2), "00") & ":" & VB6.Format(Mid(pctlField.ToString(), 4), "00")
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 2), "00") & ":" & VB6.Format(Mid(pctlField.Text, 4), "00")
                        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    Else
                        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                        'gstrEditTime = VB6.Format(Left(pctlField.ToString(), 2), "00") & ":" & "00"
                        gstrEditTime = VB6.Format(Left(pctlField.Text, 2), "00") & ":" & "00"
                        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    End If
                Case Else
                    gfncCheckTime = True
                    Exit Function
            End Select
        Else
            gfncCheckTime = True
            Exit Function
        End If

        '����������
        '++�C���J�n�@2021�N06��24��:MK�i��j- VB��VB.NET�ϊ�
        'If CShort(Left(gstrEditTime, 2)) > 99 Then
        If CShort(Left(gstrEditTime, 2)) > 24 Then
            '--�C���J�n�@2021�N06��24��:MK�i��j- VB��VB.NET�ϊ�
            gfncCheckTime = True
            Exit Function
        End If

        If CShort(Right(gstrEditTime, 2)) > 59 Then
            gfncCheckTime = True
            Exit Function
        End If

        '�ҏW��ĕ\��
        'UPGRADE_WARNING: Couldn't resolve default property of object pctlField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        'pctlField = VB6.Format(gstrEditTime, "hh:mm")
        Utils.SetValueControl(pctlField, VB6.Format(gstrEditTime, "hh:mm"))
        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�


        '�����̓��͒l��Ҕ�(hhmm)
        gstrTime = Left(gstrEditTime, 2) & Right(gstrEditTime, 2)

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCnvCutValue
    ' �X�R�[�v  : Public
    ' �������e  : ���l�ۂߕϊ�
    ' ��    �l  :
    ' �� �� �l  : �ۂ߂��l
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcurValue           Currency          I     �ϊ��Ώ�
    '   pintPosi            Integer           I     �����_����Ƃ����ۂ߂錅
    '   pintMode            Integer           I     0(�؂�̂�),1(�؂�グ),2(�l�̌ܓ�)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/24  �A��  �F��         �V�K�쐬
    '   01.01       2007/05/31  �A��  �F��         ���̒l�ł̊ۂ߂ɑΉ�
    '
    '******************************************************************************
    Public Function gfncCnvCutValue(ByVal pcurValue As Decimal, ByVal pintPosi As Short, ByVal pintMode As Short) As Decimal

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncCnvCutValue"
        Dim lngWork As Integer
        Dim curWork As Decimal
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            lngWork = 10 ^ System.Math.Abs(pintPosi)

            ' 0����
            If pcurValue < 0 Then

                ' ���̒l�ɕϊ����C���[�N�ɃZ�b�g
                curWork = pcurValue * -1

            Else

                ' ���[�N�ɃZ�b�g
                curWork = pcurValue

            End If

            If pintPosi < 0 Then


                Select Case pintMode
                    Case GC_CNV_MODE_TRUNC ' �؂�̂�

                        curWork = CDec(Fix(curWork * lngWork) / lngWork)

                    Case GC_CNV_MODE_CEILING ' �؂�グ

                        curWork = CDec(Fix(curWork * lngWork + 0.9) / lngWork)

                    Case GC_CNV_MODE_ROUND ' �l�̌ܓ�

                        curWork = CDec(Fix(curWork * lngWork + 0.5) / lngWork)

                End Select

            Else

                Select Case pintMode
                    Case GC_CNV_MODE_TRUNC ' �؂�̂�

                        curWork = CDec(Fix(curWork / lngWork) * lngWork)

                    Case GC_CNV_MODE_CEILING ' �؂�グ

                        curWork = CDec(Fix(curWork / lngWork + 0.9) * lngWork)

                    Case GC_CNV_MODE_ROUND ' �l�̌ܓ�

                        curWork = CDec(Fix(curWork / lngWork + 0.5) * lngWork)

                End Select

            End If

            ' 0����
            If pcurValue < 0 Then

                ' ���̒l�ɕϊ����C�߂�l�ɃZ�b�g
                gfncCnvCutValue = curWork * -1

            Else

                gfncCnvCutValue = curWork

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4de04ae0-a789-48d6-93b2-8a3983a6722b
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4de04ae0-a789-48d6-93b2-8a3983a6722b
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCnvMinutesToTime
    ' �X�R�[�v  : Public
    ' �������e  : �����玞�Ԃ֕ϊ�
    ' ��    �l  :
    ' �� �� �l  : ��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pdblTime            Double            I     60�i����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncCnvMinutesToTime(ByVal plngMinutes As Integer, Optional ByVal pstrFormat As String = "00", Optional ByVal pstrSplit As String = ":") As String

        gfncCnvMinutesToTime = ""

        If plngMinutes <> 0 Then

            gfncCnvMinutesToTime = VB6.Format(plngMinutes \ 60, pstrFormat) & pstrSplit & VB6.Format(plngMinutes Mod 60, "00")

        End If

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCnvTimeToMinutes
    ' �X�R�[�v  : Public
    ' �������e  : ���Ԃ��番�֕ϊ�
    ' ��    �l  :
    ' �� �� �l  : ��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pdblTime            Double            I     60�i����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncCnvTimeToMinutes(ByVal pdblTime As Double) As Integer

        gfncCnvTimeToMinutes = ((pdblTime - Fix(pdblTime)) * 100) + Fix(pdblTime) * 60

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncFieldCur
    ' �X�R�[�v  : Public
    ' �������e  : �k������i���l�j
    ' ��    �l  :
    ' �� �� �l  : �ϊ����l
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pvntFieldVal        Variant           I     ����Ώۃf�[�^
    '   pcurRep             Currency          I     NULL�̏ꍇ�̒u�����l
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncFieldCur(ByVal pvntFieldVal As Object, Optional ByVal pcurRep As Object = 0) As Decimal

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
        'If DBUtils.IsDBNull(pvntFieldVal) OrElse Len(pvntFieldVal) = 0 Then
        If pvntFieldVal Is Nothing OrElse "null".Equals(pvntFieldVal) OrElse
            pvntFieldVal.GetType().Name <> "OracleString" AndAlso TypeOf pvntFieldVal IsNot Common.MKTextBox AndAlso
           (DBUtils.IsDBNull(pvntFieldVal) OrElse String.IsNullOrEmpty(pvntFieldVal) OrElse Len(pvntFieldVal) = 0) Then
            '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object pcurRep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gfncFieldCur = pcurRep

        Else
            '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
            Dim strValue As String = ""
            If pvntFieldVal.GetType().Name = "OracleString" Then
                If pvntFieldVal.IsNull Then
                    strValue = ""
                Else
                    strValue = pvntFieldVal.Value
                End If
            ElseIf TypeOf pvntFieldVal Is Common.MKTextBox Then
                strValue = DirectCast(pvntFieldVal, Common.MKTextBox).Text
                '++�C���J�n�@2021�N10��11��:MK�i��j- VB��VB.NET�ϊ�
                If String.IsNullOrEmpty(strValue) Or Len(strValue) = 0 Then
                    gfncFieldCur = pcurRep
                    Exit Function
                End If
                '--�C���J�n�@2021�N10��11��:MK�i��j- VB��VB.NET�ϊ�
            Else
                strValue = pvntFieldVal
            End If
            '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�\

            '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
            'If IsNumeric(pvntFieldVal) Then
            If IsNumeric(strValue) AndAlso strValue <> "NaN" Then
                '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�

                'UPGRADE_WARNING: Couldn't resolve default property of object pvntFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
                'gfncFieldCur = CDec(pvntFieldVal)
                gfncFieldCur = CDec(strValue)
                '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�

            Else

                Call MsgBox("�������ڂɐ����ȊO�̒l�������Ă��܂��B", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, GC_ERR_TITLE)

            End If

        End If

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncFieldVal
    ' �X�R�[�v  : Public
    ' �������e  : �k������i������j
    ' ��    �l  :
    ' �� �� �l  : �ϊ�������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pvntFieldVal        Variant           I     ����Ώۃf�[�^
    '   pvntRep             Variant           I     NULL�̏ꍇ�̒u������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Function gfncFieldVal(ByVal pvntFieldVal As Object, Optional ByVal pvntRep As Object = "") As Object

        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
        'If DBUtils.IsDBNull(pvntFieldVal) = True Then
        If pvntFieldVal Is Nothing OrElse "null".Equals(pvntFieldVal) OrElse
           pvntFieldVal.GetType().Name <> "OracleString" AndAlso TypeOf pvntFieldVal IsNot Common.MKTextBox AndAlso
           pvntFieldVal.GetType().Name <> "TextBox" AndAlso
           (DBUtils.IsDBNull(pvntFieldVal) OrElse String.IsNullOrEmpty(pvntFieldVal) OrElse Len(pvntFieldVal) = 0) Then
            '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object pvntRep. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            gfncFieldVal = pvntRep

        Else

            'UPGRADE_WARNING: Couldn't resolve default property of object pvntFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
            'gfncFieldVal = CStr(pvntFieldVal)
            If pvntFieldVal.GetType().Name = "OracleString" Then
                If pvntFieldVal.IsNull Then
                    gfncFieldVal = ""
                Else
                    gfncFieldVal = pvntFieldVal.Value
                End If
            ElseIf TypeOf pvntFieldVal Is Common.MKTextBox Then
                gfncFieldVal = DirectCast(pvntFieldVal, Common.MKTextBox).Text
            ElseIf pvntFieldVal.GetType().Name = "TextBox" Then
                gfncFieldVal = pvntFieldVal.Text
            Else
                gfncFieldVal = CStr(pvntFieldVal)
            End If
            '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�

        End If

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetCodeToControl
    ' �X�R�[�v  : Public
    ' �������e  : �R���g���[������R�[�h�𔲂��o��
    ' ��    �l  :
    ' �� �� �l  : �R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrControlText     String            I     �R���g���[���̃e�L�X�g
    '   pintCodeLen         Integer           I     �R�[�h��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/09/27  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetCodeToControl(ByVal pstrControlText As String, ByVal pintCodeLen As Short) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetCodeToControl"
        Dim strCode As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            strCode = Trim(Mid(pstrControlText & Space(pintCodeLen), 1, pintCodeLen))

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
            'PROC_END:

            'gfncGetCodeToControl = strCode

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dddb230e-8f71-4ac1-88e2-c6fcae9432c2
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21ecaecb-0197-401b-a498-210389b830f9
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21ecaecb-0197-401b-a498-210389b830f9

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21ecaecb-0197-401b-a498-210389b830f9
PROC_FINALLY_END:
        gfncGetCodeToControl = strCode
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21ecaecb-0197-401b-a498-210389b830f9
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetMstCompanyCode
    ' �X�R�[�v  : Public
    ' �������e  : �����R�[�h����ЃR�[�h���擾
    ' ��    �l  : �����G���P�C�ɂ�, ��ЃR�[�h�t���Ή����s���܂ł̎b��֐�
    ' �� �� �l  : ��ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrPostCode        String            I     �����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/07/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetMstCompanyCode(ByVal pstrPostCode As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetMstCompanyCode"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strRet As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            strRet = ""

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT  "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �����}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �����R�[�h = '" & pstrPostCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strRet = .Fields("��ЃR�[�h").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21ecaecb-0197-401b-a498-210389b830f9
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'gfncGetMstCompanyCode = strRet

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21ecaecb-0197-401b-a498-210389b830f9
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:70b58a47-73b1-4e12-ae68-c166a10eb24c

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        gfncGetMstCompanyCode = strRet
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    'Nakai 2007.04.25 ��ЃR�[�h�t���Ή� INSERT START:��ЃR���{�ƕ����R���{�̘A�g�����ǉ�
    '******************************************************************************
    ' �� �� ��  : gfncGetCompanyCode
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR���{�����ЃR�[�h�𔲂��o��
    ' ��    �l  : gfncGetCompanyCode�͎g�p�֎~�I�IgfncGetCodeToControl���g�p
    ' �� �� �l  : ��ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCodeData        String            I     ��ЃR���{�e�L�X�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/25  Nakai              �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetCompanyCode(ByVal pstrCodeData As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetCompanyCode"
        Dim strCode As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            strCode = RTrim(Mid(pstrCodeData, 1, GC_LEN_COMPANY_CODE))

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
            'PROC_END:

            'gfncGetCompanyCode = strCode

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:70b58a47-73b1-4e12-ae68-c166a10eb24c
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:223a03ef-190b-452c-a69f-2bb5527b96f3
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:223a03ef-190b-452c-a69f-2bb5527b96f3

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:223a03ef-190b-452c-a69f-2bb5527b96f3
PROC_FINALLY_END:
        gfncGetCompanyCode = strCode
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:223a03ef-190b-452c-a69f-2bb5527b96f3
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetRecordDate
    ' �X�R�[�v  : Public
    ' �������e  : ����擾
    ' ��    �l  :
    ' �� �� �l  : ���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pstrPostCode        String            I     �����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/09/20  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetRecordDate(ByVal pstrCompanyCode As String, ByVal pstrPostCode As String) As Short

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetRecordDate"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            gfncGetRecordDate = CShort(GC_DEF_���)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NVL(���,'" & GC_DEF_��� & "') AS ��� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �R���g���[���}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �����R�[�h = '" & pstrPostCode & "' "
            strSQL = strSQL & Chr(10) & "AND ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND ���       = 'M' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    gfncGetRecordDate = .Fields("���").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:223a03ef-190b-452c-a69f-2bb5527b96f3
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:223a03ef-190b-452c-a69f-2bb5527b96f3
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetINCompanyCode
    ' �X�R�[�v  : Public
    ' �������e  : �R���{�ɕ\������Ă���f�[�^����ЃR�[�h���擾����
    ' ��    �l  : '0'�܂���'8'�̉�ЃR�[�h��Ԃ��ꍇ��'0,8'�ƕԂ�
    ' �� �� �l  : ��ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCodeData        String            I/O   �R���{�\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/06/25  Nakai              �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetINCompanyCode(ByVal pstrCodeData As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetINCompanyCode"
        Dim strCode As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            strCode = RTrim(Mid(pstrCodeData, 1, GC_LEN_COMPANY_CODE))

            If strCode = GC_COMPANY_CODE_KYOTO Or strCode = GC_COMPANY_CODE_TRACEN Then

                strCode = GC_COMPANY_CODE_KYOTO & "','" & GC_COMPANY_CODE_TRACEN

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
            'PROC_END:

            'gfncGetINCompanyCode = strCode

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:762fe6c4-a4cb-42b8-a970-3cddd397fdb7
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:68526fbe-5b21-498d-a7c8-f35455348cc8
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:68526fbe-5b21-498d-a7c8-f35455348cc8

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:68526fbe-5b21-498d-a7c8-f35455348cc8
PROC_FINALLY_END:
        gfncGetINCompanyCode = strCode
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:68526fbe-5b21-498d-a7c8-f35455348cc8
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetStringByteLen
    ' �X�R�[�v  : Public
    ' �������e  : ������̃o�C�g�����擾
    ' ��    �l  :
    ' �� �� �l  : �o�C�g��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     �擾�Ώە�����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/25  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetStringByteLen(ByVal pstrTarget As String) As Integer

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetTaxRate"
        Dim abytTemp() As Byte
        Dim lngRet As Integer
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            lngRet = GC_CODE_ERR

            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_TODO: Code was upgraded to use System.Text.UnicodeEncoding.Unicode.GetBytes() which may not have the same behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"'
            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
            'abytTemp = System.Text.UnicodeEncoding.Unicode.GetBytes(StrConv(pstrTarget, vbFromUnicode))
            abytTemp = System.Text.UTF8Encoding.UTF8.GetBytes(Utils.StrConv(pstrTarget, vbFromUniCode))
            '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

            ' �O�I���W���̈�, �{�P
            lngRet = UBound(abytTemp) + 1

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:68526fbe-5b21-498d-a7c8-f35455348cc8
            'PROC_END:

            'On Error Resume Next

            'Erase abytTemp

            'gfncGetStringByteLen = lngRet

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:68526fbe-5b21-498d-a7c8-f35455348cc8
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87bc0f42-ba15-485b-a87a-00c0174bcd15

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
PROC_FINALLY_END:
        '        On Error Resume Next
        Try
            Erase abytTemp
        Catch ex1 As Exception
        End Try
        Try
            gfncGetStringByteLen = lngRet
        Catch ex1 As Exception
        End Try
        Try
            Exit Function
        Catch ex1 As Exception
        End Try
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetTaxRate
    ' �X�R�[�v  : Public
    ' �������e  : �ŗ��擾
    ' ��    �l  :
    ' �� �� �l  : �ŗ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I/O   �c�Ɠ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/23  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetTaxRate(ByVal pstrDate As String) As Double

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetTaxRate"
        Dim dblRet As Double
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            dblRet = 0.05

            ' SQL�� �쐬
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �ŗ�     "
            strSQL = strSQL & Chr(10) & "   ,�O�ŗ�   "
            strSQL = strSQL & Chr(10) & "   ,�K�p���t "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �ŗ��}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �ŗ��R�[�h = '01' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂��Ȃ��ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then

                    ' �����Ȃ�

                    ' �Y������f�[�^�����݂���ꍇ
                Else

                    ' �K�p���t�Ōv�Z�Ɏg�p����ŗ��𔻒�
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If pstrDate >= VB6.Format(gfncFieldVal(.Fields("�K�p���t").Value), "00000000") Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        dblRet = gfncFieldCur(.Fields("�ŗ�").Value)

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        dblRet = gfncFieldCur(.Fields("�O�ŗ�").Value)

                    End If

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
            'PROC_END:

            'gfncGetTaxRate = dblRet

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:87bc0f42-ba15-485b-a87a-00c0174bcd15
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
PROC_FINALLY_END:
        gfncGetTaxRate = dblRet
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncLinkCompanyToCarKbn
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR���{�Ǝ��q�敪�R���{�̃����N���s���B
    ' ��    �l  :
    ' �� �� �l  : True �i����I���j
    '             False�i�ُ�I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   ��ЃR���{
    '   pcboCarKbn          ComboBox          I/O   ���q�敪�R���{
    '   pblnCancel          Boolean           O     �L�����Z���t���O
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '   pintDefSet          Integer           I     �f�t�H���g��ListIndex
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/07/22  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToCarKbn(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToCarKbn"
        Dim blnRet As Boolean
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            blnRet = False

            pblnCancel = False

            Call pcboCarKbn.Items.Clear()

            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else

                    '------------------
                    '   ���q�敪���Z�b�g
                    '------------------
                    Call gsubSetComboCarKbn(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboCarKbn, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboCarKbn.Items.Count > 0 Then

                pcboCarKbn.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToCarKbn = blnRet

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b06d8e6e-f27c-492d-8179-ca4146eeb1af
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d1143865-38b8-4a1b-befe-18397c33652d
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d1143865-38b8-4a1b-befe-18397c33652d

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d1143865-38b8-4a1b-befe-18397c33652d
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d1143865-38b8-4a1b-befe-18397c33652d
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncLinkCompanyToCarType
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR���{����ю��q�敪�R���{�ƎԎ�R�[�h�R���{�̃����N���s���B
    ' ��    �l  :
    ' �� �� �l  : True �i����I���j
    '             False�i�ُ�I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pcboCarKbn          ComboBox          I/O   ���q�敪�R���{
    '   pcboCarType         ComboBox          I/O   �Ԏ�R���{
    '   pblnCancel          Boolean           O     �L�����Z���t���O
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '   pintDefSet          Integer           I     �f�t�H���g��ListIndex
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/01/22  �A��  �F��         �V�K�쐬
    '   01.01       2008/07/21  �A��  �F��         ���q�敪�̊e���ڂ��Ԏ�}�X�^�Ɉڍs
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToCarType(ByRef pstrCompanyCode As String, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, ByRef pcboCarType As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToCarType"
        Dim blnRet As Boolean
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncLinkCompanyToCarType"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim blnRet As Boolean
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            blnRet = False

            pblnCancel = False

            Call pcboCarType.Items.Clear()
            '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
            pcboCarType.Text = String.Empty
            '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pcboCarKbn.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_CAR_KBN). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_CAR_KBN) = True Then

                    pblnCancel = True

                Else
                    '------------------
                    '   �Ԏ�R�[�h���Z�b�g
                    '------------------
                    Call gsubSetComboCarType(pstrCompanyCode, gfncGetCodeToControl(pcboCarKbn.Text, GC_LEN_CAR_KBN), pcboCarType, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboCarType.Items.Count > 0 Then

                pcboCarType.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToCarType = blnRet

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d1143865-38b8-4a1b-befe-18397c33652d
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d1143865-38b8-4a1b-befe-18397c33652d
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:652cae6e-e1cc-4434-9604-b198e87bd806
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:652cae6e-e1cc-4434-9604-b198e87bd806

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:652cae6e-e1cc-4434-9604-b198e87bd806
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:652cae6e-e1cc-4434-9604-b198e87bd806
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncLinkCompanyToEnwari
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR���{�Ɖ����ݒ�R���{�̃����N���s���B
    ' ��    �l  :
    ' �� �� �l  : True �i����I���j
    '             False�i�ُ�I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   ��ЃR���{
    '   pcboEnwari          ComboBox          I/O   �����ݒ�R���{
    '   pblnCancel          Boolean           O     �L�����Z���t���O
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '   pintDefSet          Integer           I     �f�t�H���g��ListIndex
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/09  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToEnwari(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboEnwari As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToEnwari"
        Dim blnRet As Boolean
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            blnRet = False

            pblnCancel = False

            Call pcboEnwari.Items.Clear()
            '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
            pcboEnwari.Text = String.Empty
            '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else
                    '------------------
                    '   �����ݒ���Z�b�g
                    '------------------
                    Call gsubSetComboEnwari(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboEnwari, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboEnwari.Items.Count > 0 Then

                pcboEnwari.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToEnwari = blnRet

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:652cae6e-e1cc-4434-9604-b198e87bd806
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:652cae6e-e1cc-4434-9604-b198e87bd806
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e5400792-7d53-4ce1-9534-77936defaa58
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e5400792-7d53-4ce1-9534-77936defaa58

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e5400792-7d53-4ce1-9534-77936defaa58
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e5400792-7d53-4ce1-9534-77936defaa58
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncLinkCompanyToPost
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR���{�Ə����R���{�̃����N���s���B
    ' ��    �l  :
    ' �� �� �l  : True �i����I���j
    '             False�i�ُ�I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   ��ЃR���{
    '   pcboPost            ComboBox          I/O   �����R���{
    '   pblnCancel          Boolean           O     �L�����Z���t���O
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '   pintDefSet          Integer           I     �f�t�H���g��ListIndex
    '   pblnFlgEigyoKbn     Boolean           I     �c�Ƌ敪����t���O(False:����Ȃ�)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/25  Nakai              �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToPost(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboPost As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0, Optional ByVal pblnFlgEigyoKbn As Boolean = False) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToPost"
        Dim blnRet As Boolean
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            pblnCancel = False

            blnRet = False

            Call pcboPost.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboPost.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�

            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else

                    '------------------
                    '   �������Z�b�g
                    '------------------
                    Call gsubSetComboBusho(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboPost, pstrAllSelect, pblnFlgEigyoKbn)

                    blnRet = True

                End If

            End If

            If pcboPost.Items.Count > 0 Then

                pcboPost.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToPost = blnRet

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e5400792-7d53-4ce1-9534-77936defaa58
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e5400792-7d53-4ce1-9534-77936defaa58
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:19639e96-bc4b-46d3-be79-41e5fe05b33b

            'Resume

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gsubClearObject
    ' �X�R�[�v  : Public
    ' �������e  : �I�u�W�F�N�g�J��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTar             Object            O     �ΏۃI�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubClearObject(ByRef pobjTarget As Object)

        On Error Resume Next

        If pobjTarget Is Nothing = False Then

            'UPGRADE_NOTE: Object pobjTarget may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            pobjTarget = Nothing

        End If

    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubControlGotFocus
    ' �X�R�[�v  : Public
    ' �������e  : �R���g���[�� �I��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlTar             Control           O     �����ΏۃR���g���[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubControlGotFocus(ByRef pctlTar As System.Windows.Forms.Control)
        System.Windows.Forms.Application.DoEvents()

        'UPGRADE_WARNING: Couldn't resolve default property of object pctlTar.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
        'pctlTar.SelStart = 0
        Utils.setSelectStartControl(pctlTar, 0)
        '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
        'UPGRADE_WARNING: Couldn't resolve default property of object pctlTar.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
        'pctlTar.SelLength = Len(pctlTar.Text)
        Utils.setSelectLengthControl(pctlTar, Len(pctlTar.Text))
        '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�

    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubDispErrMsg
    ' �X�R�[�v  : Public
    ' �������e  : �G���[���b�Z�[�W�\��
    ' ��    �l  : �V�K�̋@�\�ł̎g�p�֎~�I�I
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrErrDescription  String            I     �G���[���e
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubDispErrMsg(ByVal pstrErrDescription As String)

        'MsgBox�֐��̈����A���e��ϐ���
        Dim strMsg As String
        Dim intStyle As Short
        Dim strTitle As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo gsubDispErrMsg_Err
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            ' OLE�̴װ���e���ǂ�������
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErrText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErr. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.LastServerErr <> 0 And gobjOraDatabase.LastServerErrText <> "" Then

                'OLE��ү���ޓ��e�擾
                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErrText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strMsg = gobjOraDatabase.LastServerErrText

                'OLE�̴װ���e�̸ر
                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.LastServerErrReset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gobjOraDatabase.LastServerErrReset()

                ' VB�̴װ
            Else

                'ү���ޓ��e�擾
                strMsg = pstrErrDescription

            End If

            ' MsgBox�p�̈������`���܂�
            '���݂̎�ށA���A���݂̽��قȂǂ�\���l�̍��v�l���擾
            intStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical

            '�����ް�ɕ\�����閼�O���擾
            strTitle = GC_ERR_TITLE

            ' �װү���ނ�\�����܂��B
            Call MsgBox(strMsg, MsgBoxStyle.Critical, strTitle)


            '++�C���J�n�@2021�N05��28:MK�i��j- VB_522 VB��VB.NET�ϊ�
            'gsubDispErrMsg_Exit:

            '        Exit Sub
            '++�C���J�n�@2021�N05��28:MK�i��j- VB_523 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'gsubDispErrMsg_Err:
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            'ү���ޓ��e�擾
            strMsg = "Ӽޭ�ٖ��������Ӽޭ��" & Chr(13) & Chr(10) & "�װ�����ꏊ���gsubDispErrMsg" & Chr(13) & Chr(10) & "�Ŵװ���������܂����B"

            '���݂̎�ށA���A���݂̽��قȂǂ�\���l�̍��v�l���擾
            intStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton1

            '�����ް�ɕ\�����閼�O���擾
            strTitle = "�ُ�I��"

            Call MsgBox(strMsg, MsgBoxStyle.Critical, strTitle)

            'Resume gsubDispErrMsg_Exit

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N05��28:MK�i��j- VB_522 VB��VB.NET�ϊ�
gsubDispErrMsg_Exit:

        Exit Sub
        '++�C���J�n�@2021�N05��28:MK�i��j- VB_523 VB��VB.NET�ϊ�

        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubGetFiscalYear
    ' �X�R�[�v  : Public
    ' �������e  : ���ݓ������N�x���擾
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   ptxtFiscalYear      TextBox           O     �N�x�e�L�X�g
    '   pstrFiscalYear      String            O     �N�x���[�N
    '   pstrPostCode        String            I     �����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubGetFiscalYear(ByRef ptxtFiscalYear As System.Windows.Forms.TextBox, ByRef pstrFiscalYear As String, ByVal pstrPostCode As String)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubGetFiscalYear"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strBeginPeriod As String
        Dim strFiscalYear As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            '���񌎓��̏����l
            strBeginPeriod = "03" & GC_DEF_���

            '�����}�X�^�̊�������
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NVL(���񌎓�,'" & strBeginPeriod & "') �N�x�J�n���� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �R���g���[���}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �����R�[�h = '" & pstrPostCode & "' "
            strSQL = strSQL & Chr(10) & "AND ���       = 'M' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strBeginPeriod = .Fields("�N�x�J�n����").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            strFiscalYear = VB6.Format(Now, "yyyy")

            '�����̌��������񌎓���菬�����Ƃ��|�P�N
            If VB6.Format(Now, "mmdd") < strBeginPeriod Then
                strFiscalYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(Now, "yyyy/mm/dd"))), "yyyy")
            End If

            '�N�x�ҏW
            pstrFiscalYear = strFiscalYear
            ptxtFiscalYear.Text = VB6.Format(strFiscalYear & "/01/01", "yyyy(ggge)")

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:19639e96-bc4b-46d3-be79-41e5fe05b33b
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:15bbeb02-76e1-44af-aab8-b8815a762fac
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:15bbeb02-76e1-44af-aab8-b8815a762fac

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:15bbeb02-76e1-44af-aab8-b8815a762fac
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:15bbeb02-76e1-44af-aab8-b8815a762fac
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubGetFiscalYearMonth
    ' �X�R�[�v  : Public
    ' �������e  : ���ݓ������N���x���擾
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   ptxtYearMonth       TextBox           O     �N���x�e�L�X�g
    '   pstrYearMonth       String            O     �N���x���[�N
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pstrPostCode        String            I     �����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  �A��  �F��         �V�K�쐬
    '   02.00       2007/05/08  Nakai              ��ЃR�[�h�t���Ή�
    '
    '******************************************************************************
    '++�C���J�n�@2021�N07��23��:MK�i��j- VB��VB.NET�ϊ�
    'Public Sub gsubGetFiscalYearMonth(ByRef ptxtYearMonth As System.Windows.Forms.TextBox, ByRef pstrYearMonth As String, ByVal pstrCompanyCode As String, ByVal pstrPostCode As String)
    Public Sub gsubGetFiscalYearMonth(ByRef ptxtYearMonth As System.Windows.Forms.Control, ByRef pstrYearMonth As String, ByVal pstrCompanyCode As String, ByVal pstrPostCode As String)
        '--�C���J�n�@2021�N07��23��:MK�i��j- VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubGetFiscalYearMonth"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim int��� As Short
        Dim str�N�� As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            '����̏����l
            int��� = CShort(GC_DEF_���)

            '�����}�X�^�̊�������
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    NVL(���,'" & GC_DEF_��� & "') AS ��� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �R���g���[���}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �����R�[�h = '" & pstrPostCode & "' "
            strSQL = strSQL & Chr(10) & "AND ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND ���       = 'M' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    int��� = .Fields("���").Value

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '�����̔N�����̗p
            str�N�� = VB6.Format(Now, "yyyy/mm")

            '�����̓�������ȏ�̂Ƃ��{�P����
            If CDbl(VB6.Format(Now, "d")) >= int��� Then

                str�N�� = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(VB6.Format(Now, "yyyy/mm/dd"))), "yyyy/mm")

            End If

            '�N���ҏW
            pstrYearMonth = VB6.Format(str�N��, "yyyymm")

            '++�C���J�n�@2021�N07��23��:MK�i��j- VB��VB.NET�ϊ�
            'ptxtYearMonth.Text = VB6.Format(str�N��, "yyyy(ggge)/mm")
            If TypeOf ptxtYearMonth Is TextBox OrElse TypeOf ptxtYearMonth Is MKTextBox Then
                ptxtYearMonth.Text = VB6.Format(str�N��, "yyyy(ggge)/mm")
            ElseIf TypeOf ptxtYearMonth Is ComboBox Then
                ptxtYearMonth.Text = VB6.Format(str�N��, "yyyy(ggge)/mm")
            End If
            '--�C���J�n�@2021�N07��23��:MK�i��j- VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:15bbeb02-76e1-44af-aab8-b8815a762fac
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:15bbeb02-76e1-44af-aab8-b8815a762fac
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3c589bd8-4147-4957-a8f2-5142fb135db0
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3c589bd8-4147-4957-a8f2-5142fb135db0

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3c589bd8-4147-4957-a8f2-5142fb135db0
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3c589bd8-4147-4957-a8f2-5142fb135db0
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboBusho
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h�ɑΉ����镔���R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pcboPost            ComboBox          I/O   �����R���{
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '   pblnFlgEigyoKbn     Boolean           I     �c�Ƌ敪����t���O(False:����Ȃ�)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/25  Nakai              �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboBusho(ByVal pstrCompanyCode As String, ByRef pcboPost As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "", Optional ByVal pblnFlgEigyoKbn As Boolean = False)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboBusho"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call pcboPost.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            'pcboPost.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�

            If Len(pstrAllSelect) > 0 Then
                pcboPost.Items.Add(pstrAllSelect)
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT  "
            strSQL = strSQL & Chr(10) & "    �����R�[�h "
            strSQL = strSQL & Chr(10) & "   ,������     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �����}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "

            If pblnFlgEigyoKbn <> False And pstrCompanyCode <> "78" Then
                'If pblnFlgEigyoKbn <> False Then

                strSQL = strSQL & Chr(10) & "AND �c�Ƌ敪 = '1' "

            End If

            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    �����R�[�h "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboPost.Items.Add(CStr(Mid(.Fields("�����R�[�h").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("������").Value))
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3c589bd8-4147-4957-a8f2-5142fb135db0
            'PROC_END:

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysTemp = Nothing

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3c589bd8-4147-4957-a8f2-5142fb135db0
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:da63b1f5-7629-4a14-a6b6-b590ab271e34

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
PROC_FINALLY_END:
        objDysTemp = Nothing
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboCarKbn
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h�ɑΉ�������q�敪�R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pcboCarKbn          ComboBox          I/O   ���q�敪�R���{
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/07/22  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboCarKbn(ByVal pstrCompanyCode As String, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboCarKbn"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            Call pcboCarKbn.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboCarKbn.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�

            If Len(pstrAllSelect) > 0 Then

                pcboCarKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ���q�敪   "
            strSQL = strSQL & Chr(10) & "   ,���q�敪�� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ���q�敪�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    ���q�敪 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboCarKbn.Items.Add(CStr(Mid(.Fields("���q�敪").Value & Space(GC_LEN_CAR_KBN), 1, GC_LEN_CAR_KBN) & GC_COMBO_SPLIT & .Fields("���q�敪��").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:da63b1f5-7629-4a14-a6b6-b590ab271e34
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8ecd4e68-9120-4001-8195-284a7031c196
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8ecd4e68-9120-4001-8195-284a7031c196

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8ecd4e68-9120-4001-8195-284a7031c196
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8ecd4e68-9120-4001-8195-284a7031c196
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboCarType
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h�ɑΉ�����Ԏ�R�[�h�R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pstrCarKbn          String            I     ���q�敪
    '   pcboCarType         ComboBox          I/O   �Ԏ�R�[�h�R���{
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/01/22  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboCarType(ByVal pstrCompanyCode As String, ByVal pstrCarKbn As String, ByRef pcboCarType As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboCarType"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            Call pcboCarType.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboCarType.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pstrAllSelect) > 0 Then

                pcboCarType.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �Ԏ�R�[�h "
            strSQL = strSQL & Chr(10) & "   ,�Ԏ햼     "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �Ԏ�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND ���q�敪   = '" & pstrCarKbn & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    �Ԏ�R�[�h "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboCarType.Items.Add(CStr(Mid(.Fields("�Ԏ�R�[�h").Value & Space(GC_LEN_CAR_TYPE_CODE), 1, GC_LEN_CAR_TYPE_CODE) & GC_COMBO_SPLIT & .Fields("�Ԏ햼").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8ecd4e68-9120-4001-8195-284a7031c196
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8ecd4e68-9120-4001-8195-284a7031c196
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:269abf87-0a0a-491e-8989-d2831e84a85a
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:269abf87-0a0a-491e-8989-d2831e84a85a

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:269abf87-0a0a-491e-8989-d2831e84a85a
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:269abf87-0a0a-491e-8989-d2831e84a85a
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboShift
    ' �X�R�[�v  : Public
    ' �������e  : ��ЁE�����R�[�h�ɑΉ�����V�t�g�敪�R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboShiftKbn        ComboBox          I/O   �V�t�g�敪�R���{
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pstrPostCode        String            I     �����R�[�h
    '   pstrWorkKbn         String            I     �Ζ��敪
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/06/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboShift(ByRef pcboShiftKbn As System.Windows.Forms.ComboBox, ByVal pstrCompanyCode As String, ByVal pstrPostCode As String, Optional ByVal pstrWorkKbn As String = "", Optional ByVal pstrAllSelect As String = "")

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboShift"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            Call pcboShiftKbn.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboShiftKbn.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pstrAllSelect) > 0 Then

                Call pcboShiftKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �V�t�g�敪 "
            strSQL = strSQL & Chr(10) & "   ,�V�t�g��   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �V�t�g�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "AND �����R�[�h = '" & pstrPostCode & "' "

            If pstrWorkKbn <> "" Then

                strSQL = strSQL & Chr(10) & "AND �Ζ��J�n���� IS NOT NULL "
                strSQL = strSQL & Chr(10) & "AND �Ζ��I������ IS NOT NULL "
                strSQL = strSQL & Chr(10) & "AND �Ζ��敪   = '" & pstrWorkKbn & "' "

            End If

            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    �V�t�g�敪 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboShiftKbn.Items.Add(CStr(Mid(.Fields("�V�t�g�敪").Value & Space(GC_LEN_SHIFT_KBN), 1, GC_LEN_SHIFT_KBN) & GC_COMBO_SPLIT & .Fields("�V�t�g��").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:269abf87-0a0a-491e-8989-d2831e84a85a
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:269abf87-0a0a-491e-8989-d2831e84a85a
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fec82163-9143-4416-9d54-5476872f36df
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fec82163-9143-4416-9d54-5476872f36df

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fec82163-9143-4416-9d54-5476872f36df
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fec82163-9143-4416-9d54-5476872f36df
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboEnwari
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h�ɑΉ����鉓���ݒ�R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pcboEnwari          ComboBox          I/O   �����ݒ�R���{
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/04/09  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboEnwari(ByVal pstrCompanyCode As String, ByRef pcboEnwari As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboEnwari"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            Call pcboEnwari.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboEnwari.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pstrAllSelect) > 0 Then
                pcboEnwari.Items.Add(pstrAllSelect)
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �����ݒ�R�[�h "
            strSQL = strSQL & Chr(10) & "   ,�����ݒ薼��   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �����ݒ�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    �����ݒ�R�[�h "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboEnwari.Items.Add(CStr(Mid(.Fields("�����ݒ�R�[�h").Value & Space(1), 1, 1) & GC_COMBO_SPLIT & .Fields("�����ݒ薼��").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fec82163-9143-4416-9d54-5476872f36df
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:fec82163-9143-4416-9d54-5476872f36df
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c295e374-42f5-47ed-b1ab-83b09394d17b
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c295e374-42f5-47ed-b1ab-83b09394d17b

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c295e374-42f5-47ed-b1ab-83b09394d17b
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c295e374-42f5-47ed-b1ab-83b09394d17b
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboListIndex
    ' �X�R�[�v  : Public
    ' �������e  : �w�肳�ꂽ�R�[�h�ɊY������f�[�^��\������B
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���             �ް�����          I/O   �� ��
    '   --------------------+-----------------+-----+------------------------------
    '   pctlCombo            ComboBox          I/O   �����Ώ�
    '   pstrCode             String            I     �w��R�[�h
    '   plngLength           Long              I     �w��R�[�h��
    '   pblnFlgJudgAuthority Integer           I     ��������t���O(True:���肠��)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubSetComboListIndex(ByRef pctlCombo As System.Windows.Forms.ComboBox,
                                     ByVal pstrCode As String, ByVal plngLength As Integer,
                                     Optional ByVal pblnFlgJudgAuthority As Boolean = False,
                                     Optional ByVal pblnConvert As Boolean = False,
                                     Optional ByVal pstrObjectCode As String = GC_COMPANY_CODE_TRACEN,
                                     Optional ByVal pstrConvertCode As String = GC_COMPANY_CODE_KYOTO)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboListIndex"
        Dim intIdx As Short
        Dim strCode As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            '��ЃR�[�h��'8'�̏ꍇ'0'�ɕϊ�
            If pblnConvert = True Then
                strCode = IIf(pstrCode = pstrObjectCode, pstrConvertCode, pstrCode)
            Else
                strCode = pstrCode
            End If

            '++�C���J�n�@2021�N11��28��:MK�i��j- VB��VB.NET�ϊ�
            'can not set code to Text -> deleted
            '20211231: Fixbug in skype -> cannot clear data when code blank
            If strCode = "" Then
                pctlCombo.Text = strCode
            End If
            '--�C���J�n�@2021�N11��28��:MK�i��j- VB��VB.NET�ϊ�

            For intIdx = 0 To (pctlCombo.Items.Count - 1)

                If RTrim(Mid(VB6.GetItemString(pctlCombo, intIdx), 1, plngLength)) = strCode Then

                    '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
                    'pctlCombo.SelectedIndex = intIdx
                    pctlCombo.Text = VB6.GetItemString(pctlCombo, intIdx)
                    '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�

                    ' ���O�C�����̌�������t���O��True�i���肠��j�̏ꍇ
                    If pblnFlgJudgAuthority = True Then

                        ' �V�X�e���������O�i�����Ȃ��j�̏ꍇ
                        If gclsLoginInfo.SystemAuthority = 0 Then

                            ' �����N���d�����N�̏ꍇ
                            If gclsLoginInfo.Rank = "E" Then

                                ' �R���g���[�����g�p�s��
                                pctlCombo.Enabled = False

                            End If

                        End If

                    End If

                    Exit For

                End If

            Next intIdx

            '++�C���J�n�@2021�N12��18��:MK�i��j- VB��VB.NET�ϊ�
            If (strCode IsNot Nothing) Then
                If pctlCombo.Text.Contains(strCode) = False Then
                    pctlCombo.Text = strCode
                End If
            End If
            '--�C���J�n�@2021�N12��18��:MK�i��j- VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c295e374-42f5-47ed-b1ab-83b09394d17b
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c295e374-42f5-47ed-b1ab-83b09394d17b
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetComboNameMaster
    ' �X�R�[�v  : Public
    ' �������e  : �w�肳�ꂽ���ʂ̖��̃}�X�^���R���{�ɕ\��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pctlCombo           ComboBox          I/O   �����Ώ�
    '   pstrIdentification  String            I     ����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubSetComboNameMaster(ByRef pctlCombo As System.Windows.Forms.ComboBox, ByVal pstrIdentification As String, ByVal plngLength As Integer, Optional ByVal pstrOrder As String = "TO_NUMBER(�R�[�h)")

        Dim strSQL As String
        '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
        'Dim objDysTemp As Object
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

        Call pctlCombo.Items.Clear()
        '++�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�
        pctlCombo.Text = String.Empty
        '--�C���J�n�@2021�N06��06��:MK�i��j- VB��VB.NET�ϊ�

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    �R�[�h   "
        strSQL = strSQL & Chr(10) & "   ,���̊��� "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    ���� = '" & pstrIdentification & "' "
        strSQL = strSQL & Chr(10) & "ORDER BY "
        strSQL = strSQL & Chr(10) & "    " & pstrOrder & " "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        With objDysTemp

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Do Until .EOF = True

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pctlCombo.Items.Add(CStr(Mid(.Fields("�R�[�h").Value & Space(plngLength), 1, plngLength) & GC_COMBO_SPLIT & .Fields("���̊���").Value))

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .MoveNext()

            Loop

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .Close()

        End With

        Call gsubClearObject(objDysTemp)

    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetFocus
    ' �X�R�[�v  : Public
    ' �������e  : �t�H�[�J�X�Z�b�g
    ' ��    �l  : Enable��False�̏ꍇ�Ƀt�H�[�J�X�Z�b�g���Ă��G���[���������Ȃ�
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTar             Object            O     �ΏۃI�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Public Sub gsubSetFocus(ByRef pobjTar As Object)

        On Error Resume Next

        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTar.SetFocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++�C���J�n�@2021�N07��10��:MK�i��j- VB��VB.NET�ϊ�
        'Call pobjTar.SetFocus()
        Call pobjTar.Focus()
        '--�C���J�n�@2021�N07��10��:MK�i��j- VB��VB.NET�ϊ�

        Call Err.Clear()

    End Sub
    '******************************************************************************
    ' �� �� ��  : gsubSetFormPosition
    ' �X�R�[�v  : Public
    ' �������e  : ��ʂ̕\���ʒu��ݒ�
    ' ��    �l  :
    ' �� �� �l  : �V���O���N�H�[�e�[�V�����t��������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pfrmTarget          Form              I     �ݒ�Ώ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/04/29  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetFormPosition(ByRef pfrmTarget As Object, Optional ByVal plngHeight As Integer = 0, Optional ByVal plngWidth As Integer = 0)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncCheckDisplaySize"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            ' ���ݎg�p���̒[���̉�ʃT�C�Y��, �V�X�e���̊�{��ʃT�C�Y�𒴂���ꍇ
            '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
            'If VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / VB6.TwipsPerPixelX > GC_DEF_DISPLY_WIDTH And VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / VB6.TwipsPerPixelY > GC_DEF_DISPLY_HEIGHT Then
            If VB6.PixelsToTwipsX(Utils.GetScreenWidth()) / VB6.TwipsPerPixelX > GC_DEF_DISPLY_WIDTH And VB6.PixelsToTwipsY(Utils.GetScreenHeight()) / VB6.TwipsPerPixelY > GC_DEF_DISPLY_HEIGHT Then
                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�
                'pfrmTarget.Top = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ 2) - (pfrmTarget.Height \ 2)
                pfrmTarget.Top = (Utils.GetScreenHeight() \ 2) - (pfrmTarget.Height \ 2)
                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�
                'pfrmTarget.Left = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ 2) - (pfrmTarget.Width \ 2)
                pfrmTarget.Left = (Utils.GetScreenWidth() \ 2) - (pfrmTarget.Width \ 2)
                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�

                ' ���ݎg�p���̒[���̉�ʃT�C�Y��, �V�X�e���̊�{��ʃT�C�Y��菬�����ꍇ
            Else

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If pfrmTarget.Width / VB6.TwipsPerPixelX >= GC_DEF_DISPLY_WIDTH Or pfrmTarget.Height / VB6.TwipsPerPixelY >= GC_DEF_DISPLY_HEIGHT Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pfrmTarget.Top = 0
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pfrmTarget.Left = 0

                Else

                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Top. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�
                    'pfrmTarget.Top = (VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) \ 2) - (pfrmTarget.Height \ 2)
                    pfrmTarget.Top = (Utils.GetScreenHeight() \ 2) - (pfrmTarget.Height \ 2)
                    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Left. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�
                    'pfrmTarget.Left = (VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) \ 2) - (pfrmTarget.Width \ 2)
                    pfrmTarget.Left = (Utils.GetScreenWidth() \ 2) - (pfrmTarget.Width \ 2)
                    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- Common_PrimaryScreen VB��VB.NET�ϊ�

                End If

            End If

            If plngHeight <> 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Height. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pfrmTarget.Height = plngHeight

            End If

            If plngWidth <> 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object pfrmTarget.Width. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pfrmTarget.Width = plngWidth

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:082edf7b-fb6b-431d-8f88-74cc6ac49d1f
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : Qt
    ' �X�R�[�v  : Public
    ' �������e  : �t�B�[���h�ɃV���O���N�I�[�e�[�V������t������
    ' ��    �l  : �ǐ��������Ȃ��, �V�K�̋@�\�ł̎g�p�͋֎~
    ' �� �� �l  : �V���O���N�H�[�e�[�V�����t��������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrFieldName       String            I     �ϊ��Ώ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/03/06  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function Qt(ByVal pstrFieldName As String) As String

        Qt = "'" & pstrFieldName & "' "

    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCheckCashFeeCalCancel
    ' �X�R�[�v  : Public
    ' �������e  : �����萔���v�Z ���� �`�F�b�N
    ' ��    �l  :
    ' �� �� �l  : True �i�����萔���v�Z �����j
    '             False�i�����萔���v�Z �Ώہj
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrMishuuCode      String            I     �����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/05/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCheckCashFeeCalCancel(ByVal pstrMishuuCode As String) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncCheckCashFeeCalCancel"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l�ɏ����l��ݒ�(�����萔���v�Z �Ώ�)
            gfncCheckCashFeeCalCancel = False

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    * "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ����   = '�������' "
            strSQL = strSQL & Chr(10) & "AND �R�[�h = '" & pstrMishuuCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' �߂�l��ݒ�i�����萔���v�Z �����j
                    gfncCheckCashFeeCalCancel = True

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
            'PROC_END:

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysTemp = Nothing

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d3c8c692-1a10-456f-b92f-3193ed6faa3d
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:abfb9e67-e159-4dc4-b766-9d7915075086
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:abfb9e67-e159-4dc4-b766-9d7915075086

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:abfb9e67-e159-4dc4-b766-9d7915075086
PROC_FINALLY_END:
        objDysTemp = Nothing
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:abfb9e67-e159-4dc4-b766-9d7915075086
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetMaxMoneyHonninFutan
    ' �X�R�[�v  : Public
    ' �������e  : �{�l���S�z �擾����
    ' ��    �l  :
    ' �� �� �l  : �{�l���S�z
    ' �� �� ��  :
    '   ���Ұ���             �ް�����          I/O   �� ��
    '   --------------------+-----------------+-----+------------------------------
    '   pstrCompanyCode      String            I     ��ЃR�[�h
    '   gstrDate             String            I     �c�Ɠ�
    '   pstrEmployeeCode     String            I     �]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2008/06/21  �A��  �F��         �V�K�쐬
    '   02.01       2008/07/21  �A��  �F��         ���Ђw���������̖{�l���S�z�Ə� �Ή�
    '
    '******************************************************************************
    Public Function gfncGetMaxMoneyHonninFutan(ByVal pstrCompanyCode As String, Optional ByVal gstrDate As String = "", Optional ByVal pstrEmployeeCode As String = "") As Decimal

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetMaxMoneyHonninFutan"
        Const C_DEF_���S�z As Decimal = 50000
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim lng�I�C���� As Integer
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            ' �����l��ݒ�
            gfncGetMaxMoneyHonninFutan = C_DEF_���S�z

            lng�I�C���� = 99

            ' ������t���w�肳��Ă��� ����
            ' �]�ƈ��R�[�h���w�肳��Ă���ꍇ
            If gstrDate <> "" And pstrEmployeeCode <> "" Then

                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    TRUNC( "
                strSQL = strSQL & Chr(10) & "        MONTHS_BETWEEN( "
                strSQL = strSQL & Chr(10) & "            TO_DATE( "
                strSQL = strSQL & Chr(10) & "                '" & gstrDate & "' "
                strSQL = strSQL & Chr(10) & "            ), "
                strSQL = strSQL & Chr(10) & "            TO_DATE( "
                strSQL = strSQL & Chr(10) & "                DECODE(�I�C���t      ,NULL, "
                strSQL = strSQL & Chr(10) & "                DECODE(���ДN����    ,NULL, "
                strSQL = strSQL & Chr(10) & "                       '11111111',  "
                strSQL = strSQL & Chr(10) & "                       ���ДN����    ), "
                strSQL = strSQL & Chr(10) & "                       �I�C���t      )  "
                strSQL = strSQL & Chr(10) & "            ) "
                strSQL = strSQL & Chr(10) & "        ) "
                strSQL = strSQL & Chr(10) & "    ) AS �I�C���� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrEmployeeCode & "' "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysTemp

                    ' �Y������f�[�^�����݂���ꍇ
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .EOF = False Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        lng�I�C���� = gfncFieldCur(.Fields("�I�C����").Value)

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                objDysTemp = Nothing

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �{�l���S�z      , "
            strSQL = strSQL & Chr(10) & "    ���S�z�Ə�����01, "
            strSQL = strSQL & Chr(10) & "    �Ə��㕉�S�z01    "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ���̃R���g���[���}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �Ǘ��R�[�h = '" & pstrCompanyCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' ������t���w�肳��Ă��� ����
                    ' �]�ƈ��R�[�h���w�肳��Ă���ꍇ
                    If gstrDate <> "" And pstrEmployeeCode <> "" Then

                        ' ���S�z�Ə����������ݒ�܂��́CNULL�̏ꍇ
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If gfncFieldCur(.Fields("���S�z�Ə�����01").Value) = 0 Then

                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("�{�l���S�z").Value)

                            ' ���S�z�Ə��������ݒ肳��Ă���ꍇ
                        Else

                            ' �I�C���������S�z�Ə����� ���� �̏ꍇ
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            If lng�I�C���� < gfncFieldCur(.Fields("���S�z�Ə�����01").Value) Then

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("�Ə��㕉�S�z01").Value)

                                ' �I�C���������S�z�Ə����� �ȏ� �̏ꍇ
                            Else

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("�{�l���S�z").Value)

                            End If

                        End If

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gfncGetMaxMoneyHonninFutan = gfncFieldCur(.Fields("�{�l���S�z").Value)

                    End If

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:abfb9e67-e159-4dc4-b766-9d7915075086
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:abfb9e67-e159-4dc4-b766-9d7915075086
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetCarKbnSQL
    ' �X�R�[�v  : Public
    ' �������e  : ���q�敪 ����p �r�p�k�� �擾
    ' ��    �l  : �����I(�����ɎԎ�}�X�^�����������^�C�~���O)�ɂ́C
    '             �Ԏ�}�X�^�ɗp�r�敪���ڍs����(���݂́C�ԗ��敪�}�X�^���Q��)
    ' �� �� �l  : ���q�敪 ����p �r�p�k��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pintYoutoKbn        String            I     �p�r�敪(0:�^�N�V�[,1:�n�C���[,2:�W�����{)
    '   pstrSizeKbn         String            I     �T�C�Y�敪
    '   pstrSizeKbnJudg     String            I     �T�C�Y�敪����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00.00    2008/06/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetCarKbnSQL(ByVal pstrCompanyCode As String, ByVal pintYoutoKbn As basCommonConst.genYoto, Optional ByVal pstrSizeKbn As String = "", Optional ByVal pstrSizeKbnJudg As String = "") As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetCarKbnSQL"
        Dim strRet As String
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            gfncGetCarKbnSQL = ""

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ���q�敪 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ���q�敪�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h  = '" & pstrCompanyCode & "' "

            Select Case pintYoutoKbn
            '--------------------------------------------------------------------------
            ' �^�N�V�[
            '--------------------------------------------------------------------------
                Case basCommonConst.genYoto.Taxi

                    strSQL = strSQL & Chr(10) & "AND �p�r�敪    = '" & CStr(basCommonConst.genYoto.Taxi) & "' "

                '--------------------------------------------------------------------------
                ' �n�C���[
                '--------------------------------------------------------------------------
                Case basCommonConst.genYoto.Hire

                    ' �p�r�敪���Q�i�W�����{�j�ȊO�̎��q�敪���Q��
                    strSQL = strSQL & Chr(10) & "AND �p�r�敪   <> '" & CStr(basCommonConst.genYoto.Jumbo) & "' "

                '--------------------------------------------------------------------------
                ' �W�����{
                '--------------------------------------------------------------------------
                Case basCommonConst.genYoto.Jumbo

                    ' �p�r�敪���Q�i�W�����{�j�̎��q�敪���Q��
                    strSQL = strSQL & Chr(10) & "AND �p�r�敪    = '" & CStr(basCommonConst.genYoto.Jumbo) & "' "

            End Select

            ' �T�C�Y�敪���w�肳��Ă���ꍇ
            If pstrSizeKbn <> "" Then

                strSQL = strSQL & Chr(10) & "AND �T�C�Y�敪 " & pstrSizeKbnJudg & " '" & pstrSizeKbn & "' "

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                strRet = ""

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    strRet = strRet & "'" & gfncFieldVal(.Fields("���q�敪").Value) & "',"

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            If strRet <> "" Then

                gfncGetCarKbnSQL = Mid(strRet, 1, Len(strRet) - 1)

            End If


            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:83cf7922-779b-4b19-b29b-b1f4eccbfc3a
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:baa0fb0b-4d72-48a8-b517-36df6603a09a

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gsubSetComboFuelKbn
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h�ɑΉ�����R���敪�R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pcboFuelKbn         ComboBox          I/O   �R���敪�R���{
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboFuelKbn(ByVal pstrCompanyCode As String, ByRef pcboFuelKbn As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboFuelKbn"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call pcboFuelKbn.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboFuelKbn.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pstrAllSelect) > 0 Then

                pcboFuelKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �R���敪 "
            strSQL = strSQL & Chr(10) & "   ,�R����   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �R���敪�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    �R���敪 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboFuelKbn.Items.Add(CStr(Mid(.Fields("�R���敪").Value & Space(GC_LEN_FUEL_KBN), 1, GC_LEN_FUEL_KBN) & GC_COMBO_SPLIT & .Fields("�R����").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:baa0fb0b-4d72-48a8-b517-36df6603a09a
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5ad6ebc0-a306-444a-b9de-64689775b24e
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5ad6ebc0-a306-444a-b9de-64689775b24e

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5ad6ebc0-a306-444a-b9de-64689775b24e
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5ad6ebc0-a306-444a-b9de-64689775b24e
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gfncFormatDateString
    ' �X�R�[�v  : Public
    ' �������e  : ���t��������t�H�[�}�b�g
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     ���t������[yyyymmdd]
    '   pintMode            Integer           I     ���[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/09/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncFormatDateString(ByVal pstrTarget As String, ByVal pintMode As Short) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncFormatDateString"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��08��:MK�i��j- VB��VB.NET�ϊ�
            If String.IsNullOrEmpty(pstrTarget) Then
                Return String.Empty
            End If
            '--�C���J�n�@2021�N06��08��:MK�i��j- VB��VB.NET�ϊ�

            Select Case pintMode
            '--------------------------------------------------------------------------
            ' �N����
            '--------------------------------------------------------------------------
                Case GC_CHECK_YMD

                    gfncFormatDateString = VB6.Format(VB6.Format(pstrTarget, "0000/00/00"), "yyyy(gggee)/mm/dd")

                '--------------------------------------------------------------------------
                ' �N��
                '--------------------------------------------------------------------------
                Case GC_CHECK_YM

                    gfncFormatDateString = VB6.Format(VB6.Format(pstrTarget, "0000/00"), "yyyy(gggee)/mm")

                '--------------------------------------------------------------------------
                ' ����
                '--------------------------------------------------------------------------
                Case GC_CHECK_MD

                    gfncFormatDateString = VB6.Format(VB6.Format(pstrTarget, "00/00"), "mm/dd")

            End Select

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5ad6ebc0-a306-444a-b9de-64689775b24e
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:5ad6ebc0-a306-444a-b9de-64689775b24e
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b2da5e8c-5631-4124-b3ad-2fa816a68130

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetFiscalYearMonth
    ' �X�R�[�v  : Public
    ' �������e  : �N�������N���x���擾
    ' ��    �l  :
    ' �� �� �l  : �N���x
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I     �N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/09/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetFiscalYearMonth(ByRef pstrDate As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetFiscalYearMonth"
        Dim strYearMonth As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �N�����̔N�����̗p
            strYearMonth = VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "yyyy/mm")

            ' �����̓�������ȏ�̂Ƃ��{�P����
            If CShort(VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "d")) >= CShort(GC_DEF_���) Then

                strYearMonth = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(VB6.Format(pstrDate, "0000/00/00"))), "yyyy/mm")

            End If

            '�N���ҏW
            gfncGetFiscalYearMonth = VB6.Format(strYearMonth, "yyyymm")

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b2da5e8c-5631-4124-b3ad-2fa816a68130
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1880a654-19d4-4849-abba-75554f5ef857
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1880a654-19d4-4849-abba-75554f5ef857

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1880a654-19d4-4849-abba-75554f5ef857
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1880a654-19d4-4849-abba-75554f5ef857
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetFiscalYear
    ' �X�R�[�v  : Public
    ' �������e  : �N�������N�x���擾
    ' ��    �l  :
    ' �� �� �l  : �N�x
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I     �N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/09/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetFiscalYear(ByRef pstrDate As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetFiscalYear"
        Dim strYear As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �N�����̔N���̗p
            strYear = VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "yyyy")

            ' �����̓�����������̂Ƃ��|�P�N
            If CShort(VB6.Format(VB6.Format(pstrDate, "0000/00/00"), "mmdd")) < CShort("03" & GC_DEF_���) Then

                strYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(pstrDate, "0000/00/00"))), "yyyy")

            End If

            ' �N���ҏW
            gfncGetFiscalYear = strYear

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1880a654-19d4-4849-abba-75554f5ef857
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1880a654-19d4-4849-abba-75554f5ef857
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetDateOfPreviousYear
    ' �X�R�[�v  : Public
    ' �������e  : �O�N���t�擾����
    ' ��    �l  :
    ' �� �� �l  : �O�N���t(YYYYMMDD)
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I     ���t(YYYYMMDD)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/09/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetDateOfPreviousYear(ByVal pstrDate As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetDateOfPreviousYear"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            If Mid(pstrDate, Len("yyyy") + 1, Len("mmdd")) = "0229" Then

                gfncGetDateOfPreviousYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(Mid(pstrDate, 1, Len("yyyy")) & "/02/28")), "yyyy") & "0229"

            Else

                gfncGetDateOfPreviousYear = VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, CDate(VB6.Format(pstrDate, "0000/00/00"))), "yyyymmdd")

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f90cb6e-78f1-4c63-a614-cff4f8c893d0
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:732b9b99-75d7-48d8-8667-d1f4769fd680
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:732b9b99-75d7-48d8-8667-d1f4769fd680

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:732b9b99-75d7-48d8-8667-d1f4769fd680
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:732b9b99-75d7-48d8-8667-d1f4769fd680
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCatString
    ' �X�R�[�v  : Public
    ' �������e  : ������ �؏o��
    ' ��    �l  :
    ' �� �� �l  : �ϊ��� ������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     �؏o���Ώە�����
    '   plngLen             Long              I     �؏o����
    '   pblnNarrow          Boolean           I     ���p�ϊ�(True:����)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/05/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCatString(ByVal pstrTarget As String, ByVal plngLen As Integer, Optional ByVal pblnNarrow As Boolean = False) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncCatString"
        Dim lngIdx As Integer
        Dim strTemp As String
        Dim strRet As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            gfncCatString = ""

            ' ���[�̃X�y�[�X������
            strTemp = Trim(pstrTarget)

            If pblnNarrow = True Then

                ' ���p�ɕϊ�
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                'strTemp = StrConv(strTemp, VbStrConv.Narrow)
                strTemp = Utils.StrConv(strTemp, VbStrConv.Narrow)
                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

            End If

            ' �]�o�C�g�ȉ��̏ꍇ
            'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
            'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
            'If LenB(StrConv(strTemp, vbFromUnicode)) <= plngLen Then
            If Utils.LenB(Utils.StrConv(strTemp, vbFromUniCode)) <= plngLen Then
                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

                strRet = strTemp

                ' (�]�{�P)�o�C�g�ȏ�̏ꍇ
            Else

                strRet = ""

                For lngIdx = 1 To Len(strTemp)

                    strRet = strRet & Mid(strTemp, lngIdx, 1)

                    ' (�]�{�P)�o�C�g�ȏ�̏ꍇ
                    'UPGRADE_ISSUE: Constant vbFromUnicode was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
                    'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�
                    'If LenB(StrConv(strRet, vbFromUnicode)) >= (plngLen + 1) Then
                    If Utils.LenB(Utils.StrConv(strRet, vbFromUniCode)) >= (plngLen + 1) Then
                        '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_002 VB��VB.NET�ϊ�

                        strRet = Mid(strRet, 1, Len(strRet) - 1)

                        Exit For

                    End If

                Next lngIdx

            End If

            gfncCatString = strRet

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:732b9b99-75d7-48d8-8667-d1f4769fd680
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:732b9b99-75d7-48d8-8667-d1f4769fd680
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    Public Function ���ڃG���[����(ByRef errmsg As String, ByRef dsp As String, ByRef Title As String) As Short
        '++�C���J�n�@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
        'With VB6.GetActiveControl()

        '++�C���J�n�@2021�N07��06��:MK�i��j- VB��VB.NET�ϊ�
        If gctlActiveControl Is Nothing Then
            ���ڃG���[���� = MsgBox(errmsg, MsgBoxStyle.Exclamation, Title)
            Return Nothing
        End If
        '--�C���J�n�@2021�N07��06��:MK�i��j- VB��VB.NET�ϊ�
        With gctlActiveControl
            '--�C���I���@2021�N04��11:OneTech�i�c�[���j- Common_ActiveControl VB��VB.NET�ϊ�
            errmsg = IIf(errmsg = "", Replace(.Name, "txt", "") & "���s���ł��B", errmsg)
            Title = IIf(Title = "", Replace(.Name, "txt", "") & "�G���[", Title)
            errmsg = IIf(errmsg = "", Replace(.Name, "cbo", "") & "���s���ł��B", errmsg)
            Title = IIf(Title = "", Replace(.Name, "cbo", "") & "�G���[", Title)
            Select Case dsp
                Case "1"
                    ���ڃG���[���� = MsgBox(errmsg, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, Title)
                Case "2"
                    ���ڃG���[���� = MsgBox(errmsg, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, Title)
                Case Else
                    ���ڃG���[���� = MsgBox(errmsg, MsgBoxStyle.Exclamation, Title)
            End Select
            On Error Resume Next
            'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveControl.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
            '.SelStart = 0
            Utils.setSelectStartControl(gctlActiveControl, 0)
            '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
            'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveControl.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
            '.SelLength = Len(.Text)
            Utils.setSelectLengthControl(gctlActiveControl, Len(.Text))
            '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
            On Error GoTo 0
        End With
    End Function
    '******************************************************************************
    ' �� �� ��  : gsubSetComboRikujiCarKbn
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h�ɑΉ����闤�����q�敪�R���{���X�g��ݒ肷��
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrCompanyCode     String            I     ��ЃR�[�h
    '   pcboCarKbn          ComboBox          I/O   ���q�敪�R���{
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2009/09/03  KSR                 �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetComboRikujiCarKbn(ByVal pstrCompanyCode As String, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, Optional ByVal pstrAllSelect As String = "")

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetComboRikujiCarKbn"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            Call pcboCarKbn.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboCarKbn.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            If Len(pstrAllSelect) > 0 Then

                pcboCarKbn.Items.Add(pstrAllSelect)

            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ���q�敪   "
            strSQL = strSQL & Chr(10) & "   ,���q�敪�� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �������q�敪�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ��ЃR�[�h = '" & pstrCompanyCode & "' "
            strSQL = strSQL & Chr(10) & "ORDER BY "
            strSQL = strSQL & Chr(10) & "    ���q�敪 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Do Until .EOF = True

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call pcboCarKbn.Items.Add(CStr(Mid(.Fields("���q�敪").Value & Space(GC_LEN_CAR_KBN), 1, GC_LEN_CAR_KBN) & GC_COMBO_SPLIT & .Fields("���q�敪��").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ac4abd29-c5b4-4cc6-9e55-ee224e35fce5
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gfncLinkCompanyToRikujiCarKbn
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR���{�Ɨ������q�敪�R���{�̃����N���s���B
    ' ��    �l  :
    ' �� �� �l  : True �i����I���j
    '             False�i�ُ�I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCompany         ComboBox          I/O   ��ЃR���{
    '   pcboCarKbn          ComboBox          I/O   �������q�敪�R���{
    '   pblnCancel          Boolean           O     �L�����Z���t���O
    '   pstrAllSelect       String            I     �w������Ȃ���\��������
    '   pintDefSet          Integer           I     �f�t�H���g��ListIndex
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2009/09/03  �j�r�q  �@         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncLinkCompanyToRikujiCarKbn(ByRef pcboCompany As System.Windows.Forms.ComboBox, ByRef pcboCarKbn As System.Windows.Forms.ComboBox, ByRef pblnCancel As Boolean, Optional ByVal pstrAllSelect As String = "", Optional ByVal pintDefSet As Short = 0) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncLinkCompanyToRikujiCarKbn"
        Dim blnRet As Boolean
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            blnRet = False

            pblnCancel = False

            Call pcboCarKbn.Items.Clear()
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            pcboCarKbn.Text = String.Empty
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�

            If Len(pcboCompany.Text) > 0 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncCheckControlData(GC_CHECK_COMBO, GC_LEN_COMPANY_CODE) = True Then

                    pblnCancel = True

                Else
                    '------------------
                    '   �������q�敪���Z�b�g
                    '------------------
                    Call gsubSetComboRikujiCarKbn(gfncGetCodeToControl(pcboCompany.Text, GC_LEN_COMPANY_CODE), pcboCarKbn, pstrAllSelect)

                    blnRet = True

                End If

            End If

            If pcboCarKbn.Items.Count > 0 Then

                pcboCarKbn.SelectedIndex = pintDefSet

            End If

            gfncLinkCompanyToRikujiCarKbn = blnRet

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9e4b9bdf-f4df-4bbe-94e2-9d100c6b7a39
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dda15d16-20e2-415a-91c2-a253f31097b8
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dda15d16-20e2-415a-91c2-a253f31097b8

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dda15d16-20e2-415a-91c2-a253f31097b8
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dda15d16-20e2-415a-91c2-a253f31097b8
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetNameToControl
    ' �X�R�[�v  : Public
    ' �������e  : �R���g���[�����疼�̂𔲂��o��
    ' ��    �l  :
    ' �� �� �l  : �R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrControlText     String            I     �R���g���[���̃e�L�X�g
    '   pintCodeLen         Integer           I     �R�[�h��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/11  KSR                �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetNameToControl(ByVal pstrControlText As String, ByVal pintCodeLen As Short) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetNameToControl"
        Dim strCode As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            strCode = RTrim(Mid(pstrControlText & Space(pintCodeLen + 4), pintCodeLen + 4))

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dda15d16-20e2-415a-91c2-a253f31097b8
            'PROC_END:

            'gfncGetNameToControl = strCode

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:dda15d16-20e2-415a-91c2-a253f31097b8
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
PROC_FINALLY_END:
        gfncGetNameToControl = strCode
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncEditNameBank
    ' �X�R�[�v  : Public
    ' �������e  : ��s��  �ҏW
    ' ��    �l  :
    ' �� �� �l  : ��s��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     ��s��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/01/08  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncEditNameBank(ByVal pstrTarget As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetNameToControl"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            Select Case Right(pstrTarget, 2)
                Case "����", "�M��", "�M��", "�g��", "�_��"

                    gfncEditNameBank = pstrTarget

                Case Else

                    gfncEditNameBank = pstrTarget & "��s"

            End Select

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b2a1e0-7894-45cc-9783-d1ec08e6b871
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncEditNameBankBranch
    ' �X�R�[�v  : Public
    ' �������e  : ��s�x�X��  �ҏW
    ' ��    �l  :
    ' �� �� �l  : ��s�x�X��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     ��s��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/01/08  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncEditNameBankBranch(ByVal pstrTarget As String) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncEditNameBankBranch"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �{�X
            If pstrTarget = "�{�X" Then

                gfncEditNameBankBranch = Trim(pstrTarget)

                ' �o����
            ElseIf Right(pstrTarget, 3) = "�o����" Then

                gfncEditNameBankBranch = Trim(pstrTarget)

                ' �c�ƕ�
            ElseIf Right(pstrTarget, 3) = "�c�ƕ�" Then

                gfncEditNameBankBranch = Trim(pstrTarget)

                ' ��L�ȊO
            Else

                gfncEditNameBankBranch = Trim(pstrTarget) & "�x�X"

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:949f8af0-170a-4a8f-93ab-aed0a6a3aa23
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3b119d2c-7091-4c5a-80e4-4b4baa167035

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncCnvWideToHalf
    ' �X�R�[�v  : Public
    ' �������e  : �S�p�˔��p �ϊ�
    ' ��    �l  :
    ' �� �� �l  : ���p�ϊ��� ������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrTarget          String            I     �`�F�b�N�^�C�v
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/06/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCnvWideToHalf(ByVal pstrTarget As String) As String

        Dim strRet As String

        strRet = pstrTarget

        strRet = Replace(strRet, "�O", "0")
        strRet = Replace(strRet, "�P", "1")
        strRet = Replace(strRet, "�Q", "2")
        strRet = Replace(strRet, "�R", "3")
        strRet = Replace(strRet, "�S", "4")
        strRet = Replace(strRet, "�T", "5")
        strRet = Replace(strRet, "�U", "6")
        strRet = Replace(strRet, "�V", "7")
        strRet = Replace(strRet, "�W", "8")
        strRet = Replace(strRet, "�X", "9")

        strRet = Replace(strRet, "�|", "-")
        strRet = Replace(strRet, "�{", "+")
        strRet = Replace(strRet, "��", "*")
        strRet = Replace(strRet, "�^", "/")
        strRet = Replace(strRet, "�E", "�")
        strRet = Replace(strRet, "�@", " ")
        strRet = Replace(strRet, "�i", "(")
        strRet = Replace(strRet, "�j", ")")
        strRet = Replace(strRet, "��", "\")
        strRet = Replace(strRet, "��", "%")
        strRet = Replace(strRet, "��", "$")
        strRet = Replace(strRet, "��", "#")
        strRet = Replace(strRet, "�I", "!")
        strRet = Replace(strRet, "�H", "?")
        strRet = Replace(strRet, "��", "&")
        strRet = Replace(strRet, "�`", "~")
        strRet = Replace(strRet, "��", "@")

        strRet = Replace(strRet, "�A", "�")
        strRet = Replace(strRet, "�C", "�")
        strRet = Replace(strRet, "�E", "�")
        strRet = Replace(strRet, "�G", "�")
        strRet = Replace(strRet, "�I", "�")

        strRet = Replace(strRet, "�@", "�")
        strRet = Replace(strRet, "�B", "�")
        strRet = Replace(strRet, "�D", "�")
        strRet = Replace(strRet, "�F", "�")
        strRet = Replace(strRet, "�H", "�")

        strRet = Replace(strRet, "��", "��")

        strRet = Replace(strRet, "�K", "��")
        strRet = Replace(strRet, "�M", "��")
        strRet = Replace(strRet, "�O", "��")
        strRet = Replace(strRet, "�Q", "��")
        strRet = Replace(strRet, "�S", "��")

        strRet = Replace(strRet, "�J", "�")
        strRet = Replace(strRet, "�L", "�")
        strRet = Replace(strRet, "�N", "�")
        strRet = Replace(strRet, "�P", "�")
        strRet = Replace(strRet, "�R", "�")

        strRet = Replace(strRet, "�T", "�")
        strRet = Replace(strRet, "�V", "�")
        strRet = Replace(strRet, "�X", "�")
        strRet = Replace(strRet, "�Z", "�")
        strRet = Replace(strRet, "�\", "�")

        strRet = Replace(strRet, "�U", "��")
        strRet = Replace(strRet, "�W", "��")
        strRet = Replace(strRet, "�Y", "��")
        strRet = Replace(strRet, "�[", "��")
        strRet = Replace(strRet, "�]", "��")

        strRet = Replace(strRet, "�^", "�")
        strRet = Replace(strRet, "�`", "�")
        strRet = Replace(strRet, "�c", "�")
        strRet = Replace(strRet, "�e", "�")
        strRet = Replace(strRet, "�g", "�")

        strRet = Replace(strRet, "�b", "�")

        strRet = Replace(strRet, "�_", "��")
        strRet = Replace(strRet, "�a", "��")
        strRet = Replace(strRet, "�d", "��")
        strRet = Replace(strRet, "�f", "��")
        strRet = Replace(strRet, "�h", "��")

        strRet = Replace(strRet, "�i", "�")
        strRet = Replace(strRet, "�j", "�")
        strRet = Replace(strRet, "�k", "�")
        strRet = Replace(strRet, "�l", "�")
        strRet = Replace(strRet, "�m", "�")

        strRet = Replace(strRet, "�n", "�")
        strRet = Replace(strRet, "�q", "�")
        strRet = Replace(strRet, "�t", "�")
        strRet = Replace(strRet, "�w", "�")
        strRet = Replace(strRet, "�z", "�")

        strRet = Replace(strRet, "�o", "��")
        strRet = Replace(strRet, "�r", "��")
        strRet = Replace(strRet, "�u", "��")
        strRet = Replace(strRet, "�x", "��")
        strRet = Replace(strRet, "�{", "��")

        strRet = Replace(strRet, "�p", "��")
        strRet = Replace(strRet, "�s", "��")
        strRet = Replace(strRet, "�v", "��")
        strRet = Replace(strRet, "�y", "��")
        strRet = Replace(strRet, "�|", "��")

        strRet = Replace(strRet, "�}", "�")
        strRet = Replace(strRet, "�~", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")

        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")

        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")

        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")

        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")
        strRet = Replace(strRet, "��", "�")

        strRet = Replace(strRet, "�[", "�")
        strRet = Replace(strRet, "�\", "-")

        strRet = Replace(strRet, "�`", "A")
        strRet = Replace(strRet, "�a", "B")
        strRet = Replace(strRet, "�b", "C")
        strRet = Replace(strRet, "�c", "D")
        strRet = Replace(strRet, "�d", "E")
        strRet = Replace(strRet, "�e", "F")
        strRet = Replace(strRet, "�f", "G")
        strRet = Replace(strRet, "�g", "H")
        strRet = Replace(strRet, "�h", "I")
        strRet = Replace(strRet, "�i", "J")
        strRet = Replace(strRet, "�j", "K")
        strRet = Replace(strRet, "�k", "L")
        strRet = Replace(strRet, "�l", "M")
        strRet = Replace(strRet, "�m", "N")
        strRet = Replace(strRet, "�n", "O")
        strRet = Replace(strRet, "�o", "P")
        strRet = Replace(strRet, "�p", "Q")
        strRet = Replace(strRet, "�q", "R")
        strRet = Replace(strRet, "�r", "S")
        strRet = Replace(strRet, "�s", "T")
        strRet = Replace(strRet, "�t", "U")
        strRet = Replace(strRet, "�u", "V")
        strRet = Replace(strRet, "�v", "W")
        strRet = Replace(strRet, "�w", "X")
        strRet = Replace(strRet, "�x", "Y")
        strRet = Replace(strRet, "�y", "Z")
        strRet = Replace(strRet, "��", "a")
        strRet = Replace(strRet, "��", "b")
        strRet = Replace(strRet, "��", "c")
        strRet = Replace(strRet, "��", "d")
        strRet = Replace(strRet, "��", "e")
        strRet = Replace(strRet, "��", "f")
        strRet = Replace(strRet, "��", "g")
        strRet = Replace(strRet, "��", "h")
        strRet = Replace(strRet, "��", "i")
        strRet = Replace(strRet, "��", "j")
        strRet = Replace(strRet, "��", "k")
        strRet = Replace(strRet, "��", "l")
        strRet = Replace(strRet, "��", "m")
        strRet = Replace(strRet, "��", "n")
        strRet = Replace(strRet, "��", "o")
        strRet = Replace(strRet, "��", "p")
        strRet = Replace(strRet, "��", "q")
        strRet = Replace(strRet, "��", "r")
        strRet = Replace(strRet, "��", "s")
        strRet = Replace(strRet, "��", "t")
        strRet = Replace(strRet, "��", "u")
        strRet = Replace(strRet, "��", "v")
        strRet = Replace(strRet, "��", "w")
        strRet = Replace(strRet, "��", "x")
        strRet = Replace(strRet, "��", "y")
        strRet = Replace(strRet, "��", "z")

        strRet = Replace(strRet, "��", "(�L)")
        strRet = Replace(strRet, "��", "(��)")

        strRet = Replace(strRet, "�L�����", "(�L)")
        strRet = Replace(strRet, "�������", "(��)")
        strRet = Replace(strRet, "���c�@�l", "(��)")
        strRet = Replace(strRet, "�Вc�@�l", "(��)")

        gfncCnvWideToHalf = strRet

    End Function
    '******************************************************************************
    ' �� �� ��  : gsubSetControlLocked
    ' �X�R�[�v  : Public
    ' �������e  : �R���g���[�����b�N��Ԑݒ菈��
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTarget          Object            I     ���b�N�ΏۃR���g���[��
    '   pblnLocked          Boolean           I     ���b�N�t���O(True�F���b�N)
    '   pblnTabStop         Boolean           I     �^�u�X�g�b�v
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/07/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubSetControlLocked(ByRef pobjTarget As Object, ByVal pblnLocked As Boolean, Optional ByVal pblnTabStop As Boolean = True)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetControlLocked"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_BACK_COLOR_LOCK As Integer = &H8000000F
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_BACK_COLOR_UN_LOCK As Integer = &H80000005
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            With pobjTarget

                If pblnLocked = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.Locked. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'


                    '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    '  .Locked = True
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).ReadOnly = True
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).ReadOnly = True
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = False
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = True
                        CType(pobjTarget, Common.MKCombobox).CustomizeReadOnly = True
                    Else
                        .Locked = True
                    End If
                    '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.BackColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    '.BackColor = C_BACK_COLOR_LOCK
                    .BackColor = System.Drawing.ColorTranslator.FromOle(C_BACK_COLOR_LOCK)
                    '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.TabStop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .TabStop = False
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.MousePointer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    '.MousePointer = System.Windows.Forms.Cursors.Arrow
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Arrow
                    Else
                        '++�C���J�n�@2021�N06��27��:MK�i��j- VB��VB.NET�ϊ�
                        '.MousePointer = System.Windows.Forms.Cursors.Arrow
                        '--�C���J�n�@2021�N06��27��:MK�i��j- VB��VB.NET�ϊ�
                    End If
                    '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�

                Else

                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.Locked. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    '  .Locked = False
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).ReadOnly = False
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).ReadOnly = False
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = True
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Enabled = True
                        CType(pobjTarget, Common.MKCombobox).CustomizeReadOnly = False
                    Else
                        '++�C���J�n�@2021�N06��27��:MK�i��j- VB��VB.NET�ϊ�
                        '.Locked = False
                        '--�C���J�n�@2021�N06��27��:MK�i��j- VB��VB.NET�ϊ�
                    End If
                    '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.BackColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    '.BackColor = C_BACK_COLOR_UN_LOCK
                    .BackColor = System.Drawing.ColorTranslator.FromOle(C_BACK_COLOR_UN_LOCK)
                    '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.TabStop. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .TabStop = pblnTabStop
                    'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.MousePointer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�
                    '.MousePointer = System.Windows.Forms.Cursors.Default
                    If pobjTarget.GetType().ToString() = "System.Windows.Forms.TextBox" Then
                        CType(pobjTarget, System.Windows.Forms.TextBox).Cursor = System.Windows.Forms.Cursors.Default
                    ElseIf pobjTarget.GetType().ToString().Contains("MKTextBox") Then
                        CType(pobjTarget, Common.MKTextBox).Cursor = System.Windows.Forms.Cursors.Default
                    ElseIf pobjTarget.GetType().ToString() = "System.Windows.Forms.ComboBox" Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Default
                    ElseIf pobjTarget.GetType().ToString().Contains("MKCombobox") Then
                        CType(pobjTarget, System.Windows.Forms.ComboBox).Cursor = System.Windows.Forms.Cursors.Default
                    Else
                        '++�C���J�n�@2021�N06��27��:MK�i��j- VB��VB.NET�ϊ�
                        '.MousePointer = System.Windows.Forms.Cursors.Default
                        '--�C���J�n�@2021�N06��27��:MK�i��j- VB��VB.NET�ϊ�
                    End If
                    '--�C���J�n�@2021�N06��10��:MK�i��j- VB��VB.NET�ϊ�

                End If

                '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�

                '++�C���J�n�@2021�N05��28:MK�i��j- VB_522 VB��VB.NET�ϊ�

                'On Error Resume Next

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.SelLength. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_570 VB��VB.NET�ϊ�
                '.SelLength = 0
                '.SelectionLength = 0
                '  On Error GoTo PROC_ERROR
                Try

                    .SelectionLength = 0
                Catch ex1 As Exception

                End Try
                '++�C���J�n�@2021�N05��28:MK�i��j- VB_523 VB��VB.NET�ϊ�


            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:3b119d2c-7091-4c5a-80e4-4b4baa167035
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7334c903-6075-4d07-843b-df8b4f6b6979
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7334c903-6075-4d07-843b-df8b4f6b6979

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7334c903-6075-4d07-843b-df8b4f6b6979
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7334c903-6075-4d07-843b-df8b4f6b6979
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : gfncCnvColumnNumToColumnName
    ' �X�R�[�v  : Public
    ' �������e  : �J�����ԍ�����J������ �ϊ�
    ' ��    �l  :
    ' �� �� �l  : �J������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjXlsSheets       Object            I/O   �V�[�g
    '   pintColNum          Integer           I     �J�����ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/09/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCnvColumnNumToColumnName(ByRef pobjXlsSheets As Object, ByVal pintColNum As Short) As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncCnvColumnNumToColumnName"
        Dim strColName As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' ��͈̔̓`�F�b�N�i���݂��Ȃ���ԍ��̏ꍇ�́AUnKnown��Ԃ��j
            If pintColNum >= 1 And pintColNum <= 256 Then

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjXlsSheets.Cells. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strColName = Mid(pobjXlsSheets.Cells(1, pintColNum).Address, 2, InStr(pobjXlsSheets.Cells(1, pintColNum).Address, "1") - 3)

            Else

                strColName = "UnKnown"

            End If

            gfncCnvColumnNumToColumnName = strColName

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7334c903-6075-4d07-843b-df8b4f6b6979
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7334c903-6075-4d07-843b-df8b4f6b6979
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:44dcf758-3379-4ded-9248-43b4dabc1d34
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:44dcf758-3379-4ded-9248-43b4dabc1d34

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:44dcf758-3379-4ded-9248-43b4dabc1d34
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:44dcf758-3379-4ded-9248-43b4dabc1d34
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncGetDays
    ' �X�R�[�v  : Private
    ' �������e  : �����擾
    ' ��    �l  :
    ' �� �� �l  : ����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDateFrom        String            I     ���t(��)
    '   pstrDateTo          String            I     ���t(��)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   03.06.00    2010/04/26  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetDays(ByVal pstrDateFrom As String, ByVal pstrDateTo As String) As Short

        Dim strDateFrom As String
        Dim strDateTo As String

        gfncGetDays = 0

        strDateFrom = pstrDateFrom

        strDateTo = pstrDateTo

        If IsDate(VB6.Format(strDateFrom, "0000/00/00")) = False Then

            If Mid(strDateFrom, Len("yyyy") + 1, Len("mmdd")) = "0229" Then

                strDateFrom = Mid(strDateFrom, 1, Len("yyyy")) & "0301"

            Else

                Exit Function

            End If

        End If

        If IsDate(VB6.Format(strDateTo, "0000/00/00")) = False Then

            If Mid(strDateTo, Len("yyyy") + 1, Len("mmdd")) = "0229" Then

                strDateTo = Mid(strDateFrom, 1, Len("yyyy")) & "0228"

            Else

                Exit Function

            End If

        End If

        'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        gfncGetDays = CInt(DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(VB6.Format(strDateFrom, "0000/00/00")), CDate(VB6.Format(strDateTo, "0000/00/00")))) + 1

    End Function

    '******************************************************************************
    ' �� �� ��  : gFNC_GET_TAXRATE
    ' �X�R�[�v  : Public
    ' �������e  : �ŗ��擾
    ' ��    �l  :
    ' �� �� �l  : �ŗ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrDate            String            I/O   �ŗ����擾������(YYYYMMDD�`��)
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2014/03/19  �j�r�q        �@�@ �V�K�쐬
    '
    '******************************************************************************
    Public Function gFNC_GET_TAXRATE(ByVal pstrDate As String) As Double

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gFNC_GET_TAXRATE"
        Dim dblRet As Double
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            dblRet = 0

            ' SQL�� �쐬
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    FNC_GET_TAXRATE('" & pstrDate & "') AS �ŗ� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    DUAL "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂��Ȃ��ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then

                    ' �����Ȃ�

                    ' �Y������f�[�^�����݂���ꍇ
                Else

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    dblRet = gfncFieldCur(.Fields("�ŗ�").Value)


                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:44dcf758-3379-4ded-9248-43b4dabc1d34
            'PROC_END:

            'gFNC_GET_TAXRATE = dblRet

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:44dcf758-3379-4ded-9248-43b4dabc1d34
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7883e405-739a-4d9e-8755-c3ff9394bcd1

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
PROC_FINALLY_END:
        gFNC_GET_TAXRATE = dblRet
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function


    '******************************************************************************
    ' �� �� ��  : gFNC_GET_SPECIALFIRST
    ' �X�R�[�v  : Public
    ' �������e  : ����t�@�[�X�g�̎擾
    ' ��    �l  : ����t�@�[�X�g�́A�t�@�[�X�g�}�X�^.�c�Ǝ��ьʋ敪 = 1�Ŕ��f����.
    '             ��gFNC_GET_SPECIALFIRST�ɃZ�b�g����l�ɂ��ā�
    '               0�s�ڂ̓u�����N.���f�[�^��1�s�ڈȍ~�ɃZ�b�g����.
    ' �� �� �l  : ���X�g
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2017/01/24  �j�r�q        �@�@ �V�K�쐬
    '
    '******************************************************************************
    Public Function gFNC_GET_SPECIALFIRST() As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gFNC_GET_SPECIALFIRST"
        Dim dblRet As Double
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' SQL�� �쐬
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �t�@�[�X�g,�t�@�[�X�g�� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �t�@�[�X�g�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �c�Ǝ��ьʋ敪 = 1 "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then

                    ReDim gstrSpcFrst(0)
                    ReDim gstrSpcFrstNm(0)

                Else
                    dblRet = 1

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ReDim gstrSpcFrst(.RecordCount)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ReDim gstrSpcFrstNm(.RecordCount)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gstrSpcFrst(dblRet) = .Fields("�t�@�[�X�g").Value
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        gstrSpcFrstNm(dblRet) = .Fields("�t�@�[�X�g��").Value '//���[�\���p
                        dblRet = dblRet + 1

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()
            End With

            gFNC_GET_SPECIALFIRST = True

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:7883e405-739a-4d9e-8755-c3ff9394bcd1
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:857c18d9-395d-40b5-9152-145440c800e5
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:857c18d9-395d-40b5-9152-145440c800e5

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:857c18d9-395d-40b5-9152-145440c800e5
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:857c18d9-395d-40b5-9152-145440c800e5
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function

    '//2018/10/05 �ǉ�
    Public Function gGetSystemDate() As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsSysDate_gGetSystemDate"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            ' �����l��ݒ�(�ُ�I��)
            gGetSystemDate = ""

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    TO_CHAR(sysdate,'YYYY/MM/DD HH24:MI:SS') SystemDate "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    DUAL "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gGetSystemDate = objDysTemp.Fields("SystemDate").Value

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call objDysTemp.Close()

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:857c18d9-395d-40b5-9152-145440c800e5
            'PROC_END:

            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objDysTemp = Nothing

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:857c18d9-395d-40b5-9152-145440c800e5
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02a7f3ba-04a5-429b-bccc-69d0d205b746
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02a7f3ba-04a5-429b-bccc-69d0d205b746


            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02a7f3ba-04a5-429b-bccc-69d0d205b746
PROC_FINALLY_END:
        objDysTemp = Nothing
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02a7f3ba-04a5-429b-bccc-69d0d205b746
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function



    '++�C���J�n�@2023�N09��23��:MK�i��j- VB��VB.NET�ϊ�
    Public Function gGetZeikinByShohinCode(strShohinCode As String, dtShukeiDate As String) As TAG_Zeiritu

        Const C_NAME_FUNCTION As String = "gGetZeikinFromShohin"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset

        ' �����l��ݒ�(�ُ�I��)
        gGetZeikinByShohinCode = New TAG_Zeiritu

        Try

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT CASE WHEN " & dtShukeiDate & " >= UK.�K�p���t THEN UK.�ŗ�"
            strSQL = strSQL & Chr(10) & "       ELSE UK.�O�ŗ�"
            strSQL = strSQL & Chr(10) & "       END AS �ŗ�"
            strSQL = strSQL & Chr(10) & "      ,SM.�d���ŗ��R�[�h"
            strSQL = strSQL & Chr(10) & "FROM ���i�}�X�^ SM "
            strSQL = strSQL & Chr(10) & "INNER JOIN  �^�ǎd���ŗ��}�X�^ UK ON  SM.�d���ŗ��R�[�h = UK.�d���ŗ��R�[�h "
            strSQL = strSQL & Chr(10) & "WHERE SM.���i�R�[�h = " & strShohinCode

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            If objDysTemp.EOF = False Then

                gGetZeikinByShohinCode.mTstr�ŗ� = objDysTemp.Fields("�ŗ�").Value
                gGetZeikinByShohinCode.mTstr�ŗ��R�[�h = objDysTemp.Fields("�d���ŗ��R�[�h").Value

            End If

            Call objDysTemp.Close()
            objDysTemp = Nothing

        Catch ex As Exception

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

        Return gGetZeikinByShohinCode
    End Function

    Public Function gGetZeikinCodeByZeiritu(strZeuritsu As String, dtShukeiDate As String) As String

        Const C_NAME_FUNCTION As String = "gGetZeikinFromShohin"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset

        ' �����l��ݒ�(�ُ�I��)
        gGetZeikinCodeByZeiritu = ""

        Try

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT �d���ŗ��R�[�h "
            strSQL = strSQL & Chr(10) & "FROM �^�ǎd���ŗ��}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    " & strZeuritsu & " = (CASE WHEN '" & dtShukeiDate & "' >= �K�p���t THEN �ŗ� "
            strSQL = strSQL & Chr(10) & "                                ELSE �O�ŗ� "
            strSQL = strSQL & Chr(10) & "                           END) "

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            If objDysTemp.EOF = False Then

                gGetZeikinCodeByZeiritu = objDysTemp.Fields("�d���ŗ��R�[�h").Value

            End If

            Call objDysTemp.Close()
            objDysTemp = Nothing

        Catch ex As Exception

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

        Return gGetZeikinCodeByZeiritu
    End Function

    Public Function gGet�^�ǎd���ŗ��}�X�^(dtShukeiDate As String) As List(Of TAG_Zeiritu)

        Const C_NAME_FUNCTION As String = "gGet�^�ǎd���ŗ��}�X�^"
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        Dim zeiritu As TAG_Zeiritu
        ' �����l��ݒ�(�ُ�I��)
        gGet�^�ǎd���ŗ��}�X�^ = New List(Of TAG_Zeiritu)

        Try

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT CASE WHEN " & dtShukeiDate & " >= �K�p���t THEN �ŗ�"
            strSQL = strSQL & Chr(10) & "       ELSE �O�ŗ�"
            strSQL = strSQL & Chr(10) & "       END AS �ŗ�"
            strSQL = strSQL & Chr(10) & "      ,�d���ŗ��R�[�h"
            strSQL = strSQL & Chr(10) & "FROM �^�ǎd���ŗ��}�X�^"

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            Do Until objDysTemp.EOF = True

                zeiritu = New TAG_Zeiritu
                zeiritu.mTstr�ŗ� = objDysTemp.Fields("�ŗ�").Value
                zeiritu.mTstr�ŗ��R�[�h = objDysTemp.Fields("�d���ŗ��R�[�h").Value
                gGet�^�ǎd���ŗ��}�X�^.Add(zeiritu)
                Call objDysTemp.MoveNext()

            Loop

            Call objDysTemp.Close()
            objDysTemp = Nothing

        Catch ex As Exception

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
        End Try

        Return gGet�^�ǎd���ŗ��}�X�^
    End Function
    '--�C���J�n�@2023�N09��23��:MK�i��j- VB��VB.NET�ϊ�
    '******************************************************************************
    ' �� �� ��  : gsubGetPathMaster
    ' �X�R�[�v  :
    ' �������e  : �p�X�Ǘ��}�X�^�̃p�X�P���擾
    ' ��    �l  :
    ' �� �� �l  :������iini�t�@�C���̃p�X�j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pPathType          String            O     �p�X����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   00.00.01    2024/05/30  HUYTQ              �쐬
    '
    '******************************************************************************
    Public Function gfncGetPathMaster(ByVal pPathType As String) As String
        Dim strSQL As String
        Dim objDysTemp As Object

        ' �����l��ݒ�(�ُ�I��)
        gfncGetPathMaster = ""

        '�擾
        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    �p�X�P "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    �p�X�Ǘ��}�X�^ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    �p�X���� = '" & pPathType & "' "

        objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        If objDysTemp.EOF = False Then
            gfncGetPathMaster = gfncFieldVal(objDysTemp.Fields("�p�X�P").Value)
        End If

        Call objDysTemp.Close()
        objDysTemp = Nothing

    End Function

End Module

