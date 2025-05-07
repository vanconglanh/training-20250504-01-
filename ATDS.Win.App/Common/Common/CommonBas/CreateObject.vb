Option Strict Off
Option Explicit On
Module basCreateObject
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : CreateObject.bas
    ' ��    �e    : �I�u�W�F�N�g ���� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncCreateObject              (�I�u�W�F�N�g ����)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/10/26  �A��  �F��         �V�K�쐬
    '   02.01       2009/09/20  �A��  �F��         �V�X�e�����������Ŏ擾
    '   02.02       2009/11/02  �A��  �F��         �c�a���ڑ�����Ă��Ȃ��ꍇ�ɑΉ�
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : gfncCreateObject
    ' �X�R�[�v  : Public
    ' �������e  : �I�u�W�F�N�g ����
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjModule          Object            O     �I�u�W�F�N�g���W���[��
    '   pstrObjctName       String            I     �I�u�W�F�N�g��
    '   pstrSystemName      String            I     �V�X�e����
    '   pstrUserName        String            I     ���[�U��
    '   pstrPassWord        String            I     �p�X���[�h
    '   pstrTNS             String            I     �s�m�r��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/10/26  �A��  �F��         �V�K�쐬
    '   02.01       2009/09/20  �A��  �F��         �V�X�e�����������Ŏ擾
    '   02.02       2009/11/02  �A��  �F��         �c�a���ڑ�����Ă��Ȃ��ꍇ�ɑΉ�
    '
    '******************************************************************************
    Public Function gfncCreateObject(ByRef pobjModule As Object, ByVal pstrObjectName As String, Optional ByVal pstrSystemName As String = "", Optional ByVal pstrUserName As String = GC_DEF_USER_NAME, Optional ByVal pstrPassWord As String = GC_DEF_PASS_WORD, Optional ByVal pstrTNS As String = GC_DEF_TNS_NAME) As Integer

        '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
        'On Error Resume Next
        '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
        Try

            Dim clsRegisterDLL As clsRegisterSystemDll
            Dim strSystemName As String

            ' �߂�l��������(����I��)
            gfncCreateObject = GC_CODE_SUC

            If pstrSystemName = "" Then

                strSystemName = GC_PROGRAM_NAME

            Else

                strSystemName = pstrSystemName

            End If

            pobjModule = CreateObject(pstrObjectName)

            ' �G���[���������Ă��Ȃ��ꍇ
            If Err.Number = 0 Then

                Exit Function

            End If

            '----------------------------------------------------------------------
            ' �c�k�k�o�^
            '----------------------------------------------------------------------
            clsRegisterDLL = New clsRegisterSystemDll

            ' �c�a�I�u�W�F�N�g���ݒ肳��Ă��Ȃ��ꍇ
            If gobjOraSession Is Nothing = True Then

                Call clsRegisterDLL.DBConnect(pstrUserName, pstrPassWord, pstrTNS)

            Else

                Call clsRegisterDLL.DBObjectSet(gobjOraSession, gobjOraDatabase)

            End If

            clsRegisterDLL.SystemName = strSystemName

            Call clsRegisterDLL.RegisterDLL(pstrObjectName)

            Call gsubClearObject(clsRegisterDLL)

            pobjModule = CreateObject(pstrObjectName)

        Catch ex As Exception

            ' �G���[�����������ꍇ
            '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
            'If Err.Number <> 0 Then
            '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

            ' �߂�l��ݒ�(�ُ�I��)
            '++�C���J�n�@2021�N06��03��:MK�i��j- VB��VB.NET�ϊ�
            'gfncCreateObject = GC_CODE_ERR
            gfncCreateObject = 0
            '--�C���J�n�@2021�N06��03��:MK�i��j- VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
            pobjModule = New Login.clsLogin()
            '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
            'Exit Function

            'End If
            '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

        End Try
    End Function

End Module