Option Strict Off
Option Explicit On
Module basDispPopUpSYQ080
    '******************************************************************************
    ' ��ۼު�Ė�  : ���q�ꗗ�Ɖ� �|�b�v�A�b�v �\�����䃂�W���[��
    ' �t�@�C����  : DispPopUpSYQ080.bas
    ' ��    �e    : �l�j�V�X�e���Ŏg�p����|�b�v�A�b�v�̕\������
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncDispPopUpSYQ080     (���q�ꗗ�Ɖ�       �|�b�v�A�b�v �\��)
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00.00    2007/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    ' ���q�ꗗ�Ɖ� �|�b�v�A�b�v
    Private Const MC_POPUP_OBJECT_SYQ080 As String = "prjSYQ080.clsSYQ080"
    '******************************************************************************
    ' �� �� ��  : gfncDispPopUpSYQ080
    ' �X�R�[�v  : Public
    ' �������e  : ���q�ꗗ�Ɖ� �|�b�v�A�b�v �\�����䏈��
    ' ��    �l  :
    ' �� �� �l  : True �i�|�b�v�A�b�v�őI���j
    '             False�i�|�b�v�A�b�v�Ŗ��I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCarDistrictCode ComboBox          O     ���q�ԍ��n��R�[�h�R���{
    '   ptxtCarNo1          TextBox           O     ���q�ԍ��P�e�L�X�g
    '   ptxtCarNo2          TextBox           O     ���q�ԍ��Q�e�L�X�g
    '   ptxtCarNo3          TextBox           O     ���q�ԍ��R�e�L�X�g
    '   pclsLoginInfo       clsUnitLoginInfo  I     ���O�C�����
    '   pobjDatabase        String            I     �c�a�I�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00.00    2007/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncDispPopUpSYQ080(ByRef pcboCarDistrictCode As System.Windows.Forms.ComboBox, ByRef ptxtCarNo1 As System.Windows.Forms.TextBox, ByRef ptxtCarNo2 As System.Windows.Forms.TextBox, ByRef ptxtCarNo3 As System.Windows.Forms.TextBox, ByVal pclsLoginInfo As clsUnitLoginInfo, ByVal pobjDatabase As Object) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDispPopUpSYQ080"
        Dim objSYQ080 As Object
        Dim lngRet As Integer
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            '�߂�l���������i���I���j
            gfncDispPopUpSYQ080 = False

            '++�C���J�n�@2021�N09��11��:MK�i��j- VB��VB.NET�ϊ�
            'lngRet = gfncCreateObject(objSYQ080, MC_POPUP_OBJECT_SYQ080)
            objSYQ080 = New SYQ080.clsSYQ080
            '--�C���J�n�@2021�N09��11��:MK�i��j- VB��VB.NET�ϊ�

            ' ����ɉ^�s�Ǘ����Ӑ�Ɖ��ʂ𐶐��ł��Ȃ������ꍇ
            If lngRet <> 0 Then

                Exit Function

            End If
            '++�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�
            objSYQ080 = New SYQ080.clsSYQ080
            '--�C���J�n�@2021�N06��07��:MK�i��j- VB��VB.NET�ϊ�


            With objSYQ080

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CompanyCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .CompanyCode = pclsLoginInfo.CompanyCode

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.PostCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .PostCode = pclsLoginInfo.PostCode

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.SystemAuthority. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .SystemAuthority = pclsLoginInfo.SystemAuthority

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarDistrictCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gsubSetComboListIndex(pcboCarDistrictCode, .CarDistrictCode, GC_LEN_CAR_DISTRICT_CODE)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarNo1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtCarNo1.Text = .CarNo1

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarNo2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtCarNo2.Text = .CarNo2

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarNo3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtCarNo3.Text = .CarNo3

                    Call ptxtCarNo3.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Return)

                Else

                    Call ptxtCarNo3.Focus()



                End If

                ' �߂�l��ݒ�
                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpSYQ080 = .SelectFlg

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c40788a-8b99-4149-bbb5-2c8f4be4eb15
            'PROC_END:

            'Call gsubClearObject(objSYQ080)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2c40788a-8b99-4149-bbb5-2c8f4be4eb15
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d
PROC_FINALLY_END:
        Call gsubClearObject(objSYQ080)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module

