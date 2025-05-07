Option Strict Off
Option Explicit On
Module basSetWinPos
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : SetWinPos.bas
    ' ��    �e    : �E�B���h�E�\���ʒu �ݒ� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Private>
    '                   gfncSetWinTop                (�E�B���h�E�\���ʒu �ݒ�)
    '               <Private>
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Public Const GC_FRONT_DISP_OFF As Short = 0
    Public Const GC_FRONT_DISP_ON As Short = 1

    Private Const HWND_TOP As Short = 0 '��O�ɃZ�b�g
    Private Const HWND_BOTTOM As Short = 1 '���ɃZ�b�g
    Private Const HWND_TOPMOST As Short = -1 '��Ɏ�O�ɃZ�b�g
    Private Const HWND_NOTOPMOST As Short = -2 '��Ɏ�O�A����

    Private Const SWP_SHOWWINDOW As Integer = &H40 '�\������
    Private Const SWP_NOSIZE As Integer = &H1 '�T�C�Y��ݒ肵�Ȃ�
    Private Const SWP_NOMOVE As Integer = &H2 '�ʒu��ݒ肵�Ȃ�

    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    'Window�̈ʒu��T�C�Y�A�\����ݒ肷��API
    '++�C���J�n�@2022�N12��08��:MK�i��j- VB��VB.NET�ϊ�
    'Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Long, ByVal hWndInsertAfter As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Long
    '--�C���J�n�@2022�N12��08��:MK�i��j- VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N09��12��:MK�i��j- VB��VB.NET�ϊ�
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As Long
    Private Declare Function GetActiveWindow Lib "user32.dll" () As Long
    '--�C���J�n�@2021�N09��12��:MK�i��j- VB��VB.NET�ϊ�
    '******************************************************************************
    ' �� �� ��  : gfncSetWinTop
    ' �X�R�[�v  : Public
    ' �������e  : �E�B���h�E�\���ʒu �ݒ�
    ' ��    �l  :
    ' �� �� �l  : True �i����I���j
    '             False�i�ُ�I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjForm            Object            I/O   �\���ʒu�ݒ�Ώۃt�H�[��
    '   pintFlg             Integer           I     �\���t���O
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '++�C���J�n�@2022�N12��08��:MK�i��j- VB��VB.NET�ϊ�
    'Public Function gfncSetWinTop(ByRef pobjForm As Object, ByVal pintFlg As Short) As Integer
    Public Function gfncSetWinTop(ByRef pobjForm As Object, ByVal pintFlg As Short) As Long
        '--�C���J�n�@2022�N12��08��:MK�i��j- VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncSetWinTop"
        '++�C���J�n�@2022�N12��08��:MK�i��j- VB��VB.NET�ϊ�
        'Dim mHwnd As Integer
        Dim mHwnd As Long
        '--�C���J�n�@2022�N12��08��:MK�i��j- VB��VB.NET�ϊ�
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncSetWinTop"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            'pintFlg�̒l��0���� 1�Z�b�g
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim mHwnd As Integer
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjForm.hwnd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++�C���J�n�@2021�N09��12��:MK�i��j- VB��VB.NET�ϊ�
            'mHwnd = pobjForm.hwnd
            mHwnd = GetActiveWindow
            '--�C���J�n�@2021�N09��12��:MK�i��j- VB��VB.NET�ϊ�

            If pintFlg = GC_FRONT_DISP_OFF Then

                '������0���Z�b�g����Ă����ꍇ
                '�u��Ɏ�O�ɕ\���v������
                '++�C���J�n�@2022�N12��11��:MK�i��j- VB��VB.NET�ϊ�
                'gfncSetWinTop = SetWindowPos(mHwnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW Or SWP_NOMOVE Or SWP_NOSIZE)
                DirectCast(pobjForm, Form).TopMost = False
                '--�C���J�n�@2022�N12��11��:MK�i��j- VB��VB.NET�ϊ�

            ElseIf pintFlg = GC_FRONT_DISP_ON Then

                '������1���Z�b�g����Ă����ꍇ
                '�u��Ɏ�O�ɕ\���v�ɃZ�b�g
                '++�C���J�n�@2022�N12��11��:MK�i��j- VB��VB.NET�ϊ�
                'gfncSetWinTop = SetWindowPos(mHwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_SHOWWINDOW Or SWP_NOMOVE Or SWP_NOSIZE)
                DirectCast(pobjForm, Form).TopMost = True
                '--�C���J�n�@2022�N12��11��:MK�i��j- VB��VB.NET�ϊ�

            Else
                ' �����Ȃ�
            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:301486db-6c25-4cdc-a0c8-f0be1d5e02f7
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:301486db-6c25-4cdc-a0c8-f0be1d5e02f7
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b987ef-a63d-4570-a589-dc0ec39454b5
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b987ef-a63d-4570-a589-dc0ec39454b5


            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b987ef-a63d-4570-a589-dc0ec39454b5
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:94b987ef-a63d-4570-a589-dc0ec39454b5
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
