Option Strict Off
Option Explicit On
Module basSetSpreadBackColor
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetSpreadText.bas
    ' ��    �e    : �X�v���b�h�R���g���[�� �e�L�X�g �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gsubSetSpreadBackColor       (�X�v���b�h�w�i�F  �ݒ�)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/09  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : gsubSetSpreadBackColor
    ' �X�R�[�v  : Public
    ' �������e  : �X�v���b�h�w�i�F  �ݒ�
    ' ��    �l  : �X�v���b�h�V�[�g�̔w�i�F��ݒ�
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   psprTar             vaSpread          I     �ݒ�Ώ�
    '   plngRow             Long              I     �s
    '   plngBgColor         Long              I     �w�i�F
    '   plngFrColor         Long              I     �����F
    '   plngCol             Long              I     ��i���j
    '   plngCol2            Long              I     ��i���j
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '++�C���J�n�@2021�N05��07:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�
    'Public Sub gsubSetSpreadBackColor(ByRef psprTar As AxFPSpread.AxvaSpread, ByVal plngRow As Integer, ByVal plngBgColor As Integer, ByVal plngFrColor As Integer, Optional ByVal plngCol As Integer = -1, Optional ByVal plngCol2 As Integer = -1)
    Public Sub gsubSetSpreadBackColor(ByRef psprTar As Common.CustomizeFPSpread, ByVal plngRow As Integer, ByVal plngBgColor As Integer, ByVal plngFrColor As Integer, Optional ByVal plngCol As Integer = -1, Optional ByVal plngCol2 As Integer = -1)
        '--�C���I���@2021�N05��07:MK�i�c�[���j- AxFPSpread VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubSetSpreadBackColor"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gsubSetSpreadBackColor"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            With psprTar

                .BlockMode = True

                .Row = plngRow
                .Row2 = plngRow

                If plngCol = -1 Then

                    '++�C���J�n�@2021�N06��12��:MK�i��j- VB��VB.NET�ϊ�
                    '.Col = 1
                    '.Col2 = .MaxCols
                    .Col = 0
                    .Col2 = .MaxCols - 1
                    '--�C���J�n�@2021�N06��12��:MK�i��j- VB��VB.NET�ϊ�

                Else

                    .Col = plngCol

                    If plngCol2 = -1 Then

                        .Col2 = plngCol

                    Else

                        .Col2 = plngCol2

                    End If

                End If

                '++�C���J�n�@2021�N07��13��:MK�i��j- VB��VB.NET�ϊ�
                '.BackColor = System.Drawing.ColorTranslator.FromOle(plngBgColor)
                '.ForeColor = System.Drawing.ColorTranslator.FromOle(plngFrColor)
                .ActiveSheet.Cells(.Row, .Col, .Row2, .Col2).BackColor = System.Drawing.ColorTranslator.FromOle(plngBgColor)
                .ActiveSheet.Cells(.Row, .Col, .Row2, .Col2).ForeColor = System.Drawing.ColorTranslator.FromOle(plngFrColor)

                '--�C���J�n�@2021�N07��13��:MK�i��j- VB��VB.NET�ϊ�
                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                '.CellBorderColor = System.Drawing.Color.Black
                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                .BlockMode = False

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6be398dc-ef91-4ae1-8c00-f235a42e3554
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6be398dc-ef91-4ae1-8c00-f235a42e3554
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:37d833b1-5e14-47af-9968-d4477a597083
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:37d833b1-5e14-47af-9968-d4477a597083

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:37d833b1-5e14-47af-9968-d4477a597083
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:37d833b1-5e14-47af-9968-d4477a597083
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
End Module

