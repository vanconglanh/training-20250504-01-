Option Strict Off
Option Explicit On
Imports MKOra.Core

Module basCommonModule
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : CommonModule.bas
    ' ��    �e    : ���� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    '==============================================================================
    ' �ϐ�
    '==============================================================================
    '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
    'Public gobjOraSession As Object ' Oracle Object For Ole
    Public gobjOraSession As OraSession ' Oracle Object For Ole
    '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
    '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    'Public gobjOraDatabase As Object ' Oracle Object For Ole
    Public gobjOraDatabase As OraDatabase ' Oracle Object For Ole
    '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�

    Public gclsLoginInfo As New clsUnitLoginInfo

    'Maruo 2006.12.21 INSERT START:�v�Z�ۃ��j���[�g�ݍ��ݑΉ�
    Public gstrLocalIP As String
    'Maruo 2006.12.21 INSERT END  :�v�Z�ۃ��j���[�g�ݍ��ݑΉ�
End Module
