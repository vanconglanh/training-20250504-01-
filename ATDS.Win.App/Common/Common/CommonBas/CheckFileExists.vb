Option Strict Off
Option Explicit On
Module basCheckFileExists
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : CheckFileExists.bas
    ' ��    �e    : �t�@�C�����݃`�F�b�N����
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncCheckFileExists    (�t�@�C�����݃`�F�b�N����)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2004/08/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    ' �t�@�C���̑��݃`�F�b�N
    '++�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�
    'Private Declare Function PathFileExists Lib "SHLWAPI.DLL"  Alias "PathFileExistsA"(ByVal pszPath As String) As Integer
    '--�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�
    '******************************************************************************
    ' �� �� ��  : gfncCheckFileExists
    ' �X�R�[�v  : Public
    ' �������e  : �t�@�C�����݃`�F�b�N����
    ' ��    �l  :
    ' �� �� �l  : True �i�t�@�C������j
    '             False�i�t�@�C���Ȃ��j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrFilePath        String            I     �����Ώۃt�@�C��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2004/08/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncCheckFileExists(ByVal pstrFilePath As String) As Boolean

        Dim lngRet As Integer

        '++�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�
        'lngRet = PathFileExists(pstrFilePath)
        If Len(pstrFilePath) > 0 Then
            If pstrFilePath(pstrFilePath.Length - 1) = "\" Then
                lngRet = System.IO.Directory.Exists(pstrFilePath)
            Else
                lngRet = System.IO.File.Exists(pstrFilePath)
            End If
        End If

        '--�C���J�n�@2021�N05��29��:MK�i��j- VB��VB.NET�ϊ�

        gfncCheckFileExists = Not (lngRet = 0)

    End Function
End Module