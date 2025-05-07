Option Strict Off
Option Explicit On
Module basGetSpreadText
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetSpreadText.bas
    ' ��    �e    : �X�v���b�h�R���g���[�� �e�L�X�g �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetSpreadText            (�X�v���b�h�R���g���[���̃e�L�X�g �擾)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : gfncGetSpreadText
    ' �X�R�[�v  : Public
    ' �������e  : �X�v���b�h�R���g���[���̃e�L�X�g �擾
    ' ��    �l  : ���l�^�͉c�Ɠ������
    ' �� �� �l  : �擾�����f�[�^
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   psprTar             vaSpread          I/O   �X�v���b�h�R���g���[��
    '   plngCol             Long              I/O   �擾����Z���̗�
    '   plngRow             Long              I/O   �擾����Z���̍s
    '   pvntConv            Variant           I/O   �u�����N�̏ꍇ�̕ϊ��f�[�^
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '++�C���J�n�@2021�N04��21:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Function gfncGetSpreadText(ByRef psprTar As AxFPSpread.AxvaSpread, ByVal plngCol As Integer, ByVal plngRow As Integer, Optional ByVal pvntConv As Object = "") As Object
    Public Function gfncGetSpreadText(ByRef psprTar As Common.CustomizeFPSpread, ByVal plngCol As Integer, ByVal plngRow As Integer, Optional ByVal pvntConv As Object = "") As Object
        '--�C���I���@2021�N04��21:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetSpreadText"
        Dim vntTemp As Object
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�
            'vntTemp = System.DBNull.Value
            vntTemp = Nothing
            '--�C���J�n�@2021�N06��05��:MK�i��j- VB��VB.NET�ϊ�

            Call psprTar.GetText(plngCol, plngRow, vntTemp)

            'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            vntTemp = (gfncFieldVal(vntTemp))

            If Len(vntTemp) = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object pvntConv. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                vntTemp = pvntConv
            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21123112-89c7-4897-8cf8-c974a0d11bf7
            'PROC_END:

            'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetSpreadText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gfncGetSpreadText = vntTemp

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21123112-89c7-4897-8cf8-c974a0d11bf7
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0
PROC_FINALLY_END:
        gfncGetSpreadText = vntTemp
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module

