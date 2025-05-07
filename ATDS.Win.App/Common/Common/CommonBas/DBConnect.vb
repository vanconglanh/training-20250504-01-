Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basDBConnect
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : DBConnect.bas
    ' ��    �e    : �f�[�^�x�[�X�ڑ� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncDBConnect                (�c�a�ڑ�)
    '                   gsubDBDisConnect             (�c�a�ؒf)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/05/28  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : gfncDBConnect
    ' �X�R�[�v  : Public
    ' �������e  : �c�a�ڑ�
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            O     Oracle Session  �I�u�W�F�N�g
    '   pobjDatabase        Object            O     Oracle Database �I�u�W�F�N�g
    '   pstrUserName        String            I     ���[�U��
    '   pstrPassWord        String            I     �p�X���[�h
    '   pstrTNS             String            I     �s�m�r��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/05/28  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************

    '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
    'Public Function gfncDBConnect(ByRef pobjSession As Object, ByRef pobjDatabase As Object, ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String) As Boolean
    Public Function gfncDBConnect(ByRef pobjSession As OraSession, ByRef pobjDatabase As OraDatabase, ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String) As Boolean
        '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncDBConnect"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncDBConnect"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            gfncDBConnect = True

            '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
            'pobjSession = CreateObject("OracleInProcServer.XOraSession")
            pobjSession = New OraSession()
            '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            pobjDatabase = pobjSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            gfncDBConnect = False

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:91d82f1d-a44b-4541-8830-8fbe6cfa659d
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:91d82f1d-a44b-4541-8830-8fbe6cfa659d
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af56b682-5e89-4b72-93ca-1c78436f6f4c

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function

    '******************************************************************************
    ' �� �� ��  : gsubDBDisConnect
    ' �X�R�[�v  : Public
    ' �������e  : �c�a�ؒf
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            O     Oracle Session  �I�u�W�F�N�g
    '   pobjDatabase        Object            O     Oracle Database �I�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/05/28  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubDBDisConnect(ByRef pobjSession As Object, ByRef pobjDatabase As Object)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubDBDisConnect"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gsubDBDisConnect"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            If pobjDatabase Is Nothing = False Then

                'UPGRADE_NOTE: Object pobjDatabase may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                pobjDatabase = Nothing

            End If

            If pobjSession Is Nothing = False Then

                'UPGRADE_NOTE: Object pobjSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                pobjSession = Nothing

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af56b682-5e89-4b72-93ca-1c78436f6f4c
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af01fbce-a12b-48d1-8712-4419a7adb531
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af01fbce-a12b-48d1-8712-4419a7adb531

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af01fbce-a12b-48d1-8712-4419a7adb531
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:af01fbce-a12b-48d1-8712-4419a7adb531
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
End Module
