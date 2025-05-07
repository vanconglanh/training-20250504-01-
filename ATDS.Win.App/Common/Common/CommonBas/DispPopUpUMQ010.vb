Option Strict Off
Option Explicit On
Public Module basDispPopUpUMQ010
    '******************************************************************************
    ' ��ۼު�Ė�  : ������� �|�b�v�A�b�v �\�����䃂�W���[��
    ' �t�@�C����  : DispPopUpUMQ010.bas
    ' ��    �e    : �l�j�V�X�e���Ŏg�p����|�b�v�A�b�v�̕\������
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncDispPopUpUMQ010     (�������       �|�b�v�A�b�v �\��)
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/01/15  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    ' ������� �|�b�v�A�b�v
    '++�C���J�n�@2021�N07��11��:MK�i��j- VB��VB.NET�ϊ�
    'Private Const MC_POPUP_OBJECT_UMQ010 As String = "prjUMQ010.clsUMQ010"
    Private Const MC_POPUP_OBJECT_UMQ010 As String = "UMQ010.clsUMQ010"
    '--�C���J�n�@2021�N07��11��:MK�i��j- VB��VB.NET�ϊ�
    '******************************************************************************
    ' �� �� ��  : gfncDispPopUpUMQ010
    ' �X�R�[�v  : Public
    ' �������e  : ������� �|�b�v�A�b�v �\�����䏈��
    ' ��    �l  :
    ' �� �� �l  : True �i�|�b�v�A�b�v�őI���j
    '             False�i�|�b�v�A�b�v�Ŗ��I���j
    ' �� �� ��  :
    '   ���Ұ���             �ް�����          I/O   �� ��
    '   --------------------+-----------------+-----+------------------------------
    '   ptxtMemberCode       TextBox           O     ����R�[�h�e�L�X�g
    '   pobjDatabase         Object            I     �c�a�I�u�W�F�N�g
    '   pintBusinessMode     Integer           I     �Ɩ����[�h(0:����,1:�������)
    '   pintSearchMode       Integer           I     �������[�h(0:�ʏ�,1:�c���\��)
    '   pstrRefundFiscalYear String            I     �ҕt�����N�x
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/01/15  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncDispPopUpUMQ010(ByRef ptxtMemberCode As System.Windows.Forms.TextBox, ByVal pobjDatabase As Object, Optional ByVal pintBusinessMode As Short = GC_MODE_BUSINESS_CLAIM, Optional ByVal pintSearchMode As Short = GC_MODE_SEARCH_NORMAL, Optional ByVal pstrRefundFiscalYear As String = "") As Boolean

        '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDispPopUpUMQ010"
        '++�C���J�n�@2021�N08��13��:MK�i��j- VB��VB.NET�ϊ�
        'Dim objUMQ010 As Object
        Dim objUMQ010 As UMQ010.clsUMQ010
        '--�C���J�n�@2021�N08��13��:MK�i��j- VB��VB.NET�ϊ�
        Dim lngRet As Integer
        '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            ' �߂�l���������i���I���j
            gfncDispPopUpUMQ010 = False

            '++�C���J�n�@2021�N08��13��:MK�i��j- VB��VB.NET�ϊ�
            'lngRet = gfncCreateObject(objUMQ010, MC_POPUP_OBJECT_UMQ010)
            '--�C���J�n�@2021�N08��13��:MK�i��j- VB��VB.NET�ϊ�

            ' ����ɉ��������ʂ𐶐��ł��Ȃ������ꍇ
            If lngRet <> 0 Then

                Exit Function

            End If

            '++�C���J�n�@2021�N07��11��:MK�i��j- VB��VB.NET�ϊ�
            objUMQ010 = New UMQ010.clsUMQ010
            '--�C���J�n�@2021�N07��11��:MK�i��j- VB��VB.NET�ϊ�

            With objUMQ010

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.BusinessMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .BusinessMode = pintBusinessMode

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.SearchMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .SearchMode = pintSearchMode

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.RefundFiscalYear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .RefundFiscalYear = pstrRefundFiscalYear

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.MemberCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtMemberCode.Text = .MemberCode

                    Call ptxtMemberCode.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    '++�C���J�n�@2021�N08��22��:MK�i��j- VB��VB.NET�ϊ�
                    'Call gsubKeyEventSet(System.Windows.Forms.Keys.Tab)
                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Enter)
                    '--�C���J�n�@2021�N08��22��:MK�i��j- VB��VB.NET�ϊ�

                Else

                    Call ptxtMemberCode.Focus()

                End If

                ' �߂�l��ݒ�
                'UPGRADE_WARNING: Couldn't resolve default property of object objUMQ010.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpUMQ010 = .SelectFlg

            End With

            '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f3af51ec-4b86-4623-8dff-1bb25ce49190
            'PROC_END:

            'Call gsubClearObject(objUMQ010)

            'Exit Function

            '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f3af51ec-4b86-4623-8dff-1bb25ce49190
        Catch ex As Exception
            '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
            'Resume PROC_END
            '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:544471f3-7073-4249-ab18-f81f2c5db9fa
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:544471f3-7073-4249-ab18-f81f2c5db9fa
            '--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:544471f3-7073-4249-ab18-f81f2c5db9fa
PROC_FINALLY_END:
        Call gsubClearObject(objUMQ010)
        Exit Function
        '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:544471f3-7073-4249-ab18-f81f2c5db9fa
        '--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module

