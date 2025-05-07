Option Strict Off
Option Explicit On
Module basDispPopUpUNQ090
    '******************************************************************************
    ' ��ۼު�Ė�  : �x�X���̌��� �|�b�v�A�b�v �\�����䃂�W���[��
    ' �t�@�C����  : DispPopUpUNQ090.bas
    ' ��    �e    : �l�j�V�X�e���Ŏg�p����|�b�v�A�b�v�̕\������
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncDispPopUpUNQ090     (�x�X���̌���       �|�b�v�A�b�v �\��)
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
    ' �x�X���̌��� �|�b�v�A�b�v
    Private Const MC_POPUP_OBJECT_UNQ090 As String = "prjUNQ090.clsUNQ090"
    '******************************************************************************
    ' �� �� ��  : gfncDispPopUpUNQ090
    ' �X�R�[�v  : Public
    ' �������e  : �x�X���̌��� �|�b�v�A�b�v �\�����䏈��
    ' ��    �l  :
    ' �� �� �l  : True �i�|�b�v�A�b�v�őI���j
    '             False�i�|�b�v�A�b�v�Ŗ��I���j
    ' �� �� ��  :
    '   ���Ұ���             �ް�����          I/O   �� ��
    '   --------------------+-----------------+-----+------------------------------
    '   ptxtBankCode         TextBox           O     ��s�R�[�h�e�L�X�g
    '   ptxtBranchCode       TextBox           O     �x�X�R�[�h�e�L�X�g
    '   pobjDatabase         String            I     �c�a�I�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/01/15  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncDispPopUpUNQ090(ByRef ptxtBankCode As System.Windows.Forms.TextBox, ByRef ptxtBranchCode As System.Windows.Forms.TextBox, ByRef pobjDatabase As Object) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDispPopUpUNQ090"
        Dim objUNQ090 As Object
        Dim lngRet As Integer
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncDispPopUpUNQ090"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objUNQ090 As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim lngRet As Integer
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i���I���j
            gfncDispPopUpUNQ090 = False

            lngRet = gfncCreateObject(objUNQ090, MC_POPUP_OBJECT_UNQ090)

            ' ����ɃI�u�W�F�N�g�𐶐��ł��Ȃ������ꍇ
            If lngRet <> 0 Then

                Exit Function

            End If

            '++�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
            objUNQ090 = New UNQ090.clsUNQ090
            '--�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
            With objUNQ090

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.BankCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .BankCode = ptxtBankCode.Text

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    If Len(ptxtBankCode.Text) = 0 Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.BankCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ptxtBankCode.Text = .BankCode

                        Call ptxtBankCode.Focus()

                        System.Windows.Forms.Application.DoEvents()

                        Call gsubKeyEventSet(System.Windows.Forms.Keys.Tab)

                        System.Windows.Forms.Application.DoEvents()

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.BranchCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtBranchCode.Text = .BranchCode

                    Call ptxtBranchCode.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Tab)

                    System.Windows.Forms.Application.DoEvents()

                Else

                    Call ptxtBranchCode.Focus()

                End If

                ' �߂�l��ݒ�
                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpUNQ090 = .SelectFlg

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:71e482f5-5f05-4e77-92bb-71951d0d9546
            'PROC_END:

            'Call gsubClearObject(objUNQ090)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:71e482f5-5f05-4e77-92bb-71951d0d9546
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd244e48-b1e7-43cf-a229-028ca902d9d9
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd244e48-b1e7-43cf-a229-028ca902d9d9

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd244e48-b1e7-43cf-a229-028ca902d9d9
PROC_FINALLY_END:
        Call gsubClearObject(objUNQ090)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:cd244e48-b1e7-43cf-a229-028ca902d9d9
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module

