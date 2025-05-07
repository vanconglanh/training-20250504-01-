Option Strict Off
Option Explicit On
Module basKeyEventSet
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : KeyEventSet.bas
    ' ��    �e    : �L�[�C�x���g �Z�b�g ���W���[��
    ' ��    �l    : �E�B���X�o�X�^�[2008�ɂ�, SendKey���g�p�ł��Ȃ���, �쐬
    ' �֐��ꗗ    : <Public>
    '                   gsubKeyEventSet              (�L�[�C�x���g�Z�b�g����)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Private Const KEYEVENTF_KEYUP As Integer = &H2 '�L�[�A�b�v
    Private Const KEYEVENTF_EXTENDEDKEY As Integer = &H1 '�X�L�����R�[�h�͊g���R�[�h

    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    '���z�L�[�R�[�h�EASCII�l�E�X�L�����R�[�h�ԂŃR�[�h��ϊ�����(P1067)
    Private Declare Function MapVirtualKey Lib "user32" Alias "MapVirtualKeyA" (ByVal wCode As Integer, ByVal wMapType As Integer) As Integer

    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    '�������u���b�N���R�s�[����(P1008)
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    'UPGRADE_ISSUE: Declaring a parameter 'As Any' is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"'
    '++�C���J�n�@2021�N04��09:OneTech�i�c�[���j- VB_003 VB��VB.NET�ϊ�
    'Private Declare Sub CopyMemory Lib "kernel32.dll"  Alias "RtlMoveMemory"(ByRef Destination As Any, ByRef Source As Any, ByVal Length As Integer)
    Private Declare Sub CopyMemory Lib "kernel32.dll" Alias "RtlMoveMemory" (ByRef Destination As Object, ByRef Source As String, ByVal Length As Integer)
    '--�C���I���@2021�N04��09:OneTech�i�c�[���j- VB_003 VB��VB.NET�ϊ�
    '******************************************************************************
    ' �� �� ��  : gsubKeyEventSet
    ' �X�R�[�v  : Public
    ' �������e  : �L�[�C�x���g �Z�b�g ����
    ' ��    �l  :
    ' �� �� �l  : �L�[�C�x���g����������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintKeyCode1        String            I     �L�[�R�[�h�P
    '   pintKeyCode2        String            I     �L�[�R�[�h�Q
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubKeyEventSet(ByVal pintKeyCode1 As Short, Optional ByVal pintKeyCode2 As Short = 0)

        ' �L�[���P��������ꍇ
        If pintKeyCode2 = 0 Then

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or 0, 0)

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

            ' �L�[�̕�������([Alt] + [E] ��)�̏ꍇ
        Else

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or 0, 0)

            Call keybd_event(CByte(pintKeyCode2), MapVirtualKey(CByte(pintKeyCode2), 0), KEYEVENTF_EXTENDEDKEY Or 0, 0)

            Call keybd_event(CByte(pintKeyCode2), MapVirtualKey(CByte(pintKeyCode2), 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

            Call keybd_event(CByte(pintKeyCode1), MapVirtualKey(CByte(pintKeyCode1), 0), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)

        End If

    End Sub
End Module

