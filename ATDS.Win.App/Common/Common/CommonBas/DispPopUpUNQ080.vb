Option Strict Off
Option Explicit On
Module basDispPopUpUNQ080
    '******************************************************************************
    ' ��ۼު�Ė�  : ��s���̌��� �|�b�v�A�b�v �\�����䃂�W���[��
    ' �t�@�C����  : DispPopUpUNQ080.bas
    ' ��    �e    : �l�j�V�X�e���Ŏg�p����|�b�v�A�b�v�̕\������
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncDispPopUpUNQ080     (��s���̌���       �|�b�v�A�b�v �\��)
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/01/15  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    ' ��s���̌��� �|�b�v�A�b�v
    Private Const MC_POPUP_OBJECT_UNQ080 As String = "prjUNQ080.clsUNQ080"
    '******************************************************************************
    ' �� �� ��  : gfncDispPopUpUNQ080
    ' �X�R�[�v  : Public
    ' �������e  : ��s���̌��� �|�b�v�A�b�v �\�����䏈��
    ' ��    �l  :
    ' �� �� �l  : True �i�|�b�v�A�b�v�őI���j
    '             False�i�|�b�v�A�b�v�Ŗ��I���j
    ' �� �� ��  :
    '   ���Ұ���             �ް�����          I/O   �� ��
    '   --------------------+-----------------+-----+------------------------------
    '   ptxtBankCode         TextBox           O     ��s�R�[�h�e�L�X�g
    '   pobjDatabase         String            I     �c�a�I�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/01/15  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncDispPopUpUNQ080(ByRef ptxtBankCode As System.Windows.Forms.TextBox, ByRef pobjDatabase As Object) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDispPopUpUNQ080"
        Dim objUNQ080 As Object
        Dim lngRet As Integer
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            ' �߂�l���������i���I���j
            gfncDispPopUpUNQ080 = False

            lngRet = gfncCreateObject(objUNQ080, MC_POPUP_OBJECT_UNQ080)

            ' ����ɃI�u�W�F�N�g�𐶐��ł��Ȃ������ꍇ
            If lngRet <> 0 Then

                Exit Function

            End If

            '++�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
            objUNQ080 = New UNQ080.clsUNQ080
            '--�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
            With objUNQ080

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.BankCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtBankCode.Text = .BankCode

                    Call ptxtBankCode.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Return)

                Else

                    Call ptxtBankCode.Focus()

                End If

                ' �߂�l��ݒ�
                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpUNQ080 = .SelectFlg

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:635cb6e5-978f-4398-863b-f6ed621235c2
            'PROC_END:

            'Call gsubClearObject(objUNQ080)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:635cb6e5-978f-4398-863b-f6ed621235c2
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:63cd01bf-eb1d-4968-a99e-63eb546b255d
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:63cd01bf-eb1d-4968-a99e-63eb546b255d

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:63cd01bf-eb1d-4968-a99e-63eb546b255d
PROC_FINALLY_END:
        Call gsubClearObject(objUNQ080)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:63cd01bf-eb1d-4968-a99e-63eb546b255d
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module

