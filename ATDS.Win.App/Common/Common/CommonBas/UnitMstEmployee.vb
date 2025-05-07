Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstEmployee
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : UnitMstEmployee.cls
    ' ��    �e    : �]�ƈ��}�X�^ ��� �i�[ �N���X ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   DBConnect                  (�c�a�ڑ�)
    '                   DBObjectSet                (�c�a�I�u�W�F�N�g�ݒ�)
    '                   CheckEmployeeInfo          (�]�ƈ��}�X�^ ���݃`�F�b�N)
    '                   SetEmployeeInfo            (�]�ƈ��}�X�^ �ݒ�)
    '               <Private>
    '               <Property>
    '                   �]�ƈ��R�[�h               I/O
    '                   �����R�[�h                 I/O
    '                   ������                     I/O
    '                   ����������                 I/O
    '                   �c�ƕʎЈ��R�[�h           I/O
    '                   �Ζ��敪                   I/O
    '                   �Ζ��敪��                 I/O
    '                   ��E�ʃR�[�h               I/O
    '                   ���i�R�[�h                 I/O
    '                   ����                       I/O
    '                   ���t�^                     I/O
    '                   �]�ƈ�������               I/O
    '                   �]�ƈ����J�i               I/O
    '                   ���s�ݏZ�J�n�N��           I/O
    '                   �X�֔ԍ�1                  I/O
    '                   �X�֔ԍ�2                  I/O
    '                   �s���{��                   I/O
    '                   �s��S                     I/O
    '                   �����Ԓn                   I/O
    '                   ����                       I/O
    '                   �d�b�ԍ�                   I/O
    '                   �g�ѓd�b�ԍ�               I/O
    '                   �ƒ����ԍ�               I/O
    '                   ���З\��N����             I/O
    '                   ���ДN����                 I/O
    '                   �ŐV�ٓ��N����             I/O
    '                   �ŐV�o���N����             I/O
    '                   �o���揊���R�[�h           I/O
    '                   �ގЗ\���                 I/O
    '                   �ގДN����                 I/O
    '                   �ސE�R�[�h                 I/O
    '                   �����敪                   I/O
    '                   �����ΑӃR�[�h             I/O
    '                   �x���J�n��                 I/O
    '                   ���A�\���                 I/O
    '                   ���A�N����                 I/O
    '                   �}�C�J�[�ʋ΋敪           I/O
    '                   ���N�ی��ԍ�               I/O
    '                   �����N���ԍ�               I/O
    '                   �ٗp�ی��ԍ�               I/O
    '                   �ٗp�ی������L��           I/O
    '                   �ŋ敪                     I/O
    '                   �[����ЃR�[�h             I/O
    '                   �[�������R�[�h             I/O
    '                   �[����Ж�                 I/O
    '                   �[��������                 I/O
    '                   ���K����ЃR�[�h           I/O
    '                   ���K�������R�[�h           I/O
    '                   ���K����Ж�               I/O
    '                   ���K��������               I/O
    '                   ���K�Z���^�[�����\���     I/O
    '                   ���K�Z���^�[������         I/O
    '                   ���K�敪                   I/O
    '                   �I�C���t                   I/O
    '                   ���K���Ɠ�                 I/O
    '                   �����\��N����             I/O
    '                   �����N����                 I/O
    '                   �v���[�gNO                 I/O
    '                   �t�@�[�X�g                 I/O
    '                   �t�@�[�X�g��               I/O
    '                   �{���㖱�敪               I/O
    '                   �{���ԍ�                   I/O
    '                   �{�����q�敪               I/O
    '                   �{�����q�敪��             I/O
    '                   �{���Ԏ�R�[�h             I/O
    '                   ������                     I/O
    '                   ���x�O���[�v               I/O
    '                   �V�t�g�敪                 I/O
    '                   �J�[�h����                 I/O
    '                   �J�[�h�p���`NO             I/O
    '                   �ǒ��蓖�敪               I/O
    '                   ��Q�ғ���                 I/O
    '                   ��Q���                   I/O
    '                   �ό������N                 I/O
    '                   �ό������N�ύX��           I/O
    '                   ��w�\�͉p��               I/O
    '                   ��w�\�͊؍���             I/O
    '                   ��w�\�͓ƌ�               I/O
    '                   ��w�\�͕���               I/O
    '                   ��w�\�͒�����             I/O
    '                   ��w�\�͂��̑�             I/O
    '                   ���N����                   I/O
    '                   �O�񌒐f�N���x             I/O
    '                   �a��                       I/O
    '                   ���L����                   I/O
    '                   �폜��                     I/O
    '                   �斱���ؔ��s��             I/O
    '                   �^�]�Ƌ��X�V��             I/O
    '                   �g���ؖ������s��           I/O
    '                   ���̓����N                 I/O
    '                   �p�X���[�h                 I/O
    '                   �{�Вn                     I/O
    '                   �o�g�n                     I/O
    '                   �ŏI�w�Z��                 I/O
    '                   �ŏI�w�Z�w����             I/O
    '                   �ŏI�w�Z�w�Ȗ�             I/O
    '                   �ŏI���ƔN�x               I/O
    '                   �ŏI�w�Z���Ƌ敪           I/O
    '                   �斱�o��                   I/O
    '                   �o���n                     I/O
    '                   �o���N                     I/O
    '                   �o����                     I/O
    '                   �擾���i                   I/O
    '                   �擾�N��                   I/O
    '                   �E��                       I/O
    '                   ���ДN��                   I/O
    '                   �ސE�N��                   I/O
    '                   ����o�H                   I/O
    '                   �X�V�]�ƈ��R�[�h           I/O
    '                   �X�V���t����               I/O
    '                   ���Ћ敪                   I/O
    '                   ���Џ����R�[�h             I/O
    '                   �ގЏ����R�[�h             I/O
    '                   �o�^��                     I/O
    '                   ���ʎ蓖�敪               I/O
    '                   �����N                     I/O
    '                   ���Ў����                 I/O
    '                   ���Ɨp�ԗL���敪           I/O
    '                   ���q�ی������敪           I/O
    '                   ETC                        I/O
    '                   �o�Ў��Ԓ�                 I/O
    '                   �o�Ў��Ԗ�                 I/O
    '                   �o�Ў��Ԋu��               I/O
    '                   ��ЃR�[�h                 I/O
    '                   ��Ж�                     I/O
    '                   ��Ж�����                 I/O
    '                   ���Ə��R�[�h               I/O
    '                   �_����Ԏ�                 I/O
    '                   �_����Ԏ�                 I/O
    '                   �o�����ЃR�[�h           I/O
    '                   ���Љ�ЃR�[�h             I/O
    '                   �ގЉ�ЃR�[�h             I/O
    '                   �Ύ��Y����R�[�h�P         I/O
    '                   �Ύ��Y����R�[�h�Q         I/O
    '                   �Ύ��Y����R�[�h�R         I/O
    '                   �O��X�V�Җ�               I/O
    '                   �O��X�V����               I/O
    '                   ��퍇�i��                 I/O
    '                   �Ƌ����                   I/O
    '                   �Ύ��Y����R�[�h�R         I/O
    '                   �L���c��                   I/O
    '                   ��Е��S�t���O             I/O
    '                   �Г��l�^�N�V�[�Ώێ�     I/O
    '                   ��ԎO�l���Ώێ�           I/O
    '               <Events>
    '                   Class_Initialize           (�N���X�����ݒ�)
    '                   Class_Terminate            (�c�a�ؒf)
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '   01.01.00    2009/10/21  �A��  �F��         �Ζ��敪������уt�@�[�X�g����ǉ�
    '   01.02.00    2010/04/30  �A��  �F��         �[��, ����ы��K���̉�ЃR�[�h, �����R�[�h, ��Ж�, ������ ��ǉ�
    '   01.03.00    2010/06/14  �A��  �F��         ��Е��S�t���O��ǉ�
    '   01.04.00    2011/03/17  �A��  �F��         �Г��l�^�N�V�[�Ώێ�, ��ԎO�l���Ώێ҂�ǉ�
    '   01.05.00    2011/10/11  �A��  �F��         �g�у��[��, �A�Ȑ�g�ѓd�b, �A�Ȑ惁�[��, �A�Ȑ�g�у��[�� ��ǉ�
    '   01.06.00    2011/10/12  �A��  �F��         �g���ۏؐl�̍��ڂ�ǉ�
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Private Const MC_MIN_��w�\�͂��̑� As Short = 1
    Private Const MC_MAX_��w�\�͂��̑� As Short = 5
    Private Const MC_MIN_�a�� As Short = 1
    Private Const MC_MAX_�a�� As Short = 10
    Private Const MC_MIN_���L���� As Short = 1
    Private Const MC_MAX_���L���� As Short = 10
    Private Const MC_MIN_�擾���i As Short = 1
    Private Const MC_MAX_�擾���i As Short = 5
    Private Const MC_MIN_�擾�N�� As Short = 1
    Private Const MC_MAX_�擾�N�� As Short = 5
    Private Const MC_MIN_�E�� As Short = 1
    Private Const MC_MAX_�E�� As Short = 10
    Private Const MC_MIN_���ДN�� As Short = 1
    Private Const MC_MAX_���ДN�� As Short = 10
    Private Const MC_MIN_�ސE�N�� As Short = 1
    Private Const MC_MAX_�ސE�N�� As Short = 10
    Private Const MC_MIN_��X�|�[�c As Short = 1
    Private Const MC_MAX_��X�|�[�c As Short = 4
    Private Const MC_MIN_��X�|�[�c�ȊO As Short = 1
    Private Const MC_MAX_��X�|�[�c�ȊO As Short = 10

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    Private mobjOraSession As Object ' Oracle
    '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    'Private mobjOraDatabase As Object ' Oracle
    Private mobjOraDatabase As OraDatabase ' Oracle
    '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
    Private mblnDBConnect As Boolean ' DB�ڑ��t���O(True�F�ڑ�)
    Private mblnDBObject As Boolean ' DB�ڑ��I�u�W�F�N�g�ݒ�t���O(True�F�ݒ�)

    Private mstr�]�ƈ��R�[�h As String
    Private mstr�����R�[�h As String
    Private mstr������ As String
    Private mstr���������� As String
    Private mstr�c�ƕʎЈ��R�[�h As String
    Private mint�Ζ��敪 As Short
    Private mstr�Ζ��敪�� As String
    Private mint��E�ʃR�[�h As Short
    Private mint���i�R�[�h As Short
    Private mint���� As Short
    Private mint���t�^ As Short
    Private mstr�]�ƈ������� As String
    Private mstr�]�ƈ����J�i As String
    Private mstr���s�ݏZ�J�n�N�� As String
    Private mstr�X�֔ԍ�1 As String
    Private mstr�X�֔ԍ�2 As String
    Private mstr�s���{�� As String
    Private mstr�s��S As String
    Private mstr�����Ԓn As String
    Private mstr���� As String
    Private mstr�d�b�ԍ� As String
    Private mstr�g�ѓd�b�ԍ� As String
    Private mint�ƒ����ԍ� As Short
    Private mstr���З\��N���� As String
    Private mstr���ДN���� As String
    Private mstr�ŐV�ٓ��N���� As String
    Private mstr�ŐV�o���N���� As String
    Private mstr�o���揊���R�[�h As String
    Private mstr�ގЗ\��� As String
    Private mstr�ގДN���� As String
    Private mstr�ސE�R�[�h As String
    Private mint�����敪 As Short
    Private mstr�����ΑӃR�[�h As String
    Private mstr�x���J�n�� As String
    Private mstr���A�\��� As String
    Private mstr���A�N���� As String
    Private mint�}�C�J�[�ʋ΋敪 As Short
    Private mstr���N�ی��ԍ� As String
    Private mstr�����N���ԍ� As String
    Private mstr�ٗp�ی��ԍ� As String
    Private mint�ٗp�ی������L�� As Short
    Private mint�ŋ敪 As Short
    Private mstr�[����ЃR�[�h As String
    Private mstr�[����Ж� As String
    Private mstr�[�������R�[�h As String
    Private mstr�[�������� As String
    Private mstr���K����ЃR�[�h As String
    Private mstr���K����Ж� As String
    Private mstr���K�������R�[�h As String
    Private mstr���K�������� As String
    Private mstr���K�Z���^�[�����\��� As String
    Private mstr���K�Z���^�[������ As String
    Private mint���K�敪 As Short
    Private mstr�I�C���t As String
    Private mstr���K���Ɠ� As String
    Private mstr�����\��N���� As String
    Private mstr�����N���� As String
    Private mstr�v���[�gNO As String
    Private mint�t�@�[�X�g As Short
    Private mstr�t�@�[�X�g�� As String
    Private mint�{���㖱�敪 As Short
    Private mstr�{���ԍ� As String
    Private mstr�{�����q�敪 As String
    Private mstr�{�����q�敪�� As String
    Private mstr�{���Ԏ�R�[�h As String
    Private mstr������ As String
    Private mstr���x�O���[�v As String
    Private mstr�V�t�g�敪 As String
    Private mcur�J�[�h���� As Decimal
    Private mstr�J�[�h�p���`NO As String
    Private mint�ǒ��蓖�敪 As Short
    Private mstr��Q�ғ��� As String
    Private mstr��Q��� As String
    Private mint�ό������N As Short
    Private mstr�ό������N�ύX�� As String
    Private mint��w�\�͉p�� As Short
    Private mint��w�\�͊؍��� As Short
    Private mint��w�\�͓ƌ� As Short
    Private mint��w�\�͕��� As Short
    Private mint��w�\�͒����� As Short
    'UPGRADE_WARNING: Lower bound of array maint��w�\�͂��̑� was changed from MC_MIN_��w�\�͂��̑� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private maint��w�\�͂��̑�(MC_MAX_��w�\�͂��̑�) As Short
    Private mstr���N���� As String
    Private mstr�O�񌒐f�N���x As String
    'UPGRADE_WARNING: Lower bound of array mastr�a�� was changed from MC_MIN_�a�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�a��(MC_MAX_�a��) As String
    'UPGRADE_WARNING: Lower bound of array mastr�a��N���J�n was changed from MC_MIN_�a�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�a��N���J�n(MC_MAX_�a��) As String
    'UPGRADE_WARNING: Lower bound of array mastr�a��N���I�� was changed from MC_MIN_�a�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�a��N���I��(MC_MAX_�a��) As String
    'UPGRADE_WARNING: Lower bound of array mastr���L���� was changed from MC_MIN_���L���� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr���L����(MC_MAX_���L����) As String
    Private mstr�폜�� As String
    Private mstr�斱���ؔ��s�� As String
    Private mstr�^�]�Ƌ��X�V�� As String
    Private mstr�g���ؖ������s�� As String
    Private mint���̓����N As Short
    Private mstr�p�X���[�h As String
    Private mstr�{�Вn As String
    Private mstr�o�g�n As String
    Private mstr�ŏI�w�Z�� As String
    Private mstr�ŏI�w�Z�w���� As String
    Private mstr�ŏI�w�Z�w�Ȗ� As String
    Private mstr�ŏI���ƔN�x As String
    Private mint�ŏI�w�Z���Ƌ敪 As Short
    Private mint�斱�o�� As Short
    Private mstr�o���n As String
    Private mstr�o���N As String
    Private mstr�o���� As String
    'UPGRADE_WARNING: Lower bound of array mastr�擾���i was changed from MC_MIN_�擾���i to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�擾���i(MC_MAX_�擾���i) As String
    'UPGRADE_WARNING: Lower bound of array mastr�擾�N�� was changed from MC_MIN_�擾�N�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�擾�N��(MC_MAX_�擾�N��) As String
    'UPGRADE_WARNING: Lower bound of array mastr�E�� was changed from MC_MIN_�E�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�E��(MC_MAX_�E��) As String
    'UPGRADE_WARNING: Lower bound of array mastr���ДN�� was changed from MC_MIN_���ДN�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr���ДN��(MC_MAX_���ДN��) As String
    'UPGRADE_WARNING: Lower bound of array mastr�ސE�N�� was changed from MC_MIN_�ސE�N�� to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr�ސE�N��(MC_MAX_�ސE�N��) As String
    Private mstr����o�H As String
    Private mstr�X�V�]�ƈ��R�[�h As String
    Private mdte�X�V���t���� As Date
    Private mint���Ћ敪 As Short
    Private mstr���Џ����R�[�h As String
    Private mstr�ގЏ����R�[�h As String
    Private mstr�o�^�� As String
    Private mint���ʎ蓖�敪 As Short
    Private mstr�����N As String
    Private mstr���Ў���� As String
    Private mint���Ɨp�ԗL���敪 As Short
    Private mint���q�ی������敪 As Short
    Private mstrETC As String
    Private mstr�o�Ў��Ԓ� As String
    Private mstr�o�Ў��Ԗ� As String
    Private mstr�o�Ў��Ԋu�� As String
    Private mstr��ЃR�[�h As String
    Private mstr��Ж� As String
    Private mstr��Ж����� As String
    Private mstr���Ə��R�[�h As String
    Private mstr�_����Ԏ� As String
    Private mstr�_����Ԏ� As String
    Private mstr�o�����ЃR�[�h As String
    Private mstr���Љ�ЃR�[�h As String
    Private mstr�ގЉ�ЃR�[�h As String
    Private mstr�Ύ��Y����R�[�h1 As String
    Private mstr�Ύ��Y����R�[�h2 As String
    Private mstr�Ύ��Y����R�[�h3 As String
    Private mstr��퍇�i�� As String
    Private mstr�Ƌ���� As String
    Private mstr�O��X�V�Җ� As String
    Private mstr�O��X�V���� As String
    Private mcur�L���c���� As Decimal
    Private mint��Е��S�t���O As Short
    Private mint�Г��l�^�N�V�[�Ώێ� As Short
    Private mint��ԎO�l���Ώێ� As Short

    Private mstr���l As String

    Private mstr���[�� As String
    Private mstr�g�у��[�� As String

    Private mstr�A�Ȑ�X�֔ԍ�1 As String
    Private mstr�A�Ȑ�X�֔ԍ�2 As String
    Private mstr�A�Ȑ�s���{�� As String
    Private mstr�A�Ȑ�s��S As String
    Private mstr�A�Ȑ撬���Ԓn As String
    Private mstr�A�Ȑ捆�� As String
    Private mstr�A�Ȑ�d�b�ԍ� As String
    Private mstr�A�Ȑ�g�ѓd�b�ԍ� As String
    Private mstr�A�Ȑ惁�[�� As String
    Private mstr�A�Ȑ�g�у��[�� As String
    Private mstr�A�Ȑ掁�� As String
    Private mstr�A�Ȑ摱�� As String

    Private mstr�g���ۏؐl������ As String
    Private mstr�g���ۏؐl���J�i As String
    Private mint�g���ۏؐl���� As Short
    Private mstr�g���ۏؐl���N���� As String
    Private mstr�g���ۏؐl�o�^�� As String
    Private mstr�g���ۏؐl�E�� As String
    Private mstr�g���ۏؐl���� As String
    Private mstr�g���ۏؐl�X�֔ԍ�1 As String
    Private mstr�g���ۏؐl�X�֔ԍ�2 As String
    Private mstr�g���ۏؐl�s���{�� As String
    Private mstr�g���ۏؐl�s��S As String
    Private mstr�g���ۏؐl�����Ԓn As String
    Private mstr�g���ۏؐl���� As String
    Private mstr�g���ۏؐl�d�b�ԍ� As String
    Private mstr�g���ۏؐl�g�ѓd�b�ԍ� As String
    Private mstr�g���ۏؐl���[�� As String
    Private mstr�g���ۏؐl�g�у��[�� As String

    Private mint��L���X�|�[�c As Short
    Private mint��L���X�|�[�c�ȊO As Short

    'UPGRADE_WARNING: Lower bound of array mastr��X�|�[�c was changed from MC_MIN_��X�|�[�c to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr��X�|�[�c(MC_MAX_��X�|�[�c) As String

    'UPGRADE_WARNING: Lower bound of array mastr��X�|�[�c�ȊO was changed from MC_MIN_��X�|�[�c�ȊO to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr��X�|�[�c�ȊO(MC_MAX_��X�|�[�c�ȊO) As String
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' �C�x���g
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : Class_Initialize
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��}�X�^ ��� �i�[ �N���X �����ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Initialize"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Initialize"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            mblnDBConnect = False

            mblnDBObject = False

            Call ClearInfo()

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:073e0e13-e442-4978-8014-7b006e01c770
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:073e0e13-e442-4978-8014-7b006e01c770
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02740da1-3350-4c7b-89fd-6af1815f1bb0

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    '******************************************************************************
    ' �� �� ��  : Class_Terminate
    ' �X�R�[�v  : Public
    ' �������e  : �c�a�ؒf
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Terminate"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Terminate"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b399e114-7d8e-49a3-9c0e-47946b4c160f

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' ���\�b�h
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : ClearInfo
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��}�X�^ ���  �N���A
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/12/21  �A��  �F��         �V�K�쐬
    '   01.02.00    2010/04/30  �A��  �F��         �[����ЃR�[�h, �[�������R�[�h, ���K����ЃR�[�h, ����ы��K�������R�[�h��ǉ�
    '
    '******************************************************************************
    Public Sub ClearInfo()

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_ClearInfo"
        Dim intIdx As Short
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_ClearInfo"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intIdx As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            mstr�]�ƈ��R�[�h = ""
            mstr�����R�[�h = ""
            mstr������ = ""
            mstr���������� = ""
            mstr�c�ƕʎЈ��R�[�h = ""
            mint�Ζ��敪 = -1
            mstr�Ζ��敪�� = ""
            mint��E�ʃR�[�h = -1
            mint���i�R�[�h = -1
            mint���� = -1
            mint���t�^ = -1
            mstr�]�ƈ������� = ""
            mstr�]�ƈ����J�i = ""
            mstr���s�ݏZ�J�n�N�� = ""
            mstr�X�֔ԍ�1 = ""
            mstr�X�֔ԍ�2 = ""
            mstr�s���{�� = ""
            mstr�s��S = ""
            mstr�����Ԓn = ""
            mstr���� = ""
            mstr�d�b�ԍ� = ""
            mstr�g�ѓd�b�ԍ� = ""
            mint�ƒ����ԍ� = -1
            mstr���З\��N���� = ""
            mstr���ДN���� = ""
            mstr�ŐV�ٓ��N���� = ""
            mstr�ŐV�o���N���� = ""
            mstr�o���揊���R�[�h = ""
            mstr�ގЗ\��� = ""
            mstr�ގДN���� = ""
            mstr�ސE�R�[�h = ""
            mint�����敪 = -1
            mstr�����ΑӃR�[�h = ""
            mstr�x���J�n�� = ""
            mstr���A�\��� = ""
            mstr���A�N���� = ""
            mint�}�C�J�[�ʋ΋敪 = -1
            mstr���N�ی��ԍ� = ""
            mstr�����N���ԍ� = ""
            mstr�ٗp�ی��ԍ� = ""
            mint�ٗp�ی������L�� = -1
            mint�ŋ敪 = -1
            mstr�[����ЃR�[�h = ""
            mstr�[����Ж� = ""
            mstr�[�������R�[�h = ""
            mstr�[�������� = ""
            mstr���K����ЃR�[�h = ""
            mstr���K����Ж� = ""
            mstr���K�������R�[�h = ""
            mstr���K�������� = ""
            mstr���K�Z���^�[�����\��� = ""
            mstr���K�Z���^�[������ = ""
            mint���K�敪 = -1
            mstr�I�C���t = ""
            mstr���K���Ɠ� = ""
            mstr�����\��N���� = ""
            mstr�����N���� = ""
            mstr�v���[�gNO = ""
            mint�t�@�[�X�g = -1
            mstr�t�@�[�X�g�� = ""
            mint�{���㖱�敪 = -1
            mstr�{���ԍ� = ""
            mstr�{�����q�敪 = ""
            mstr�{�����q�敪�� = ""
            mstr�{���Ԏ�R�[�h = ""
            mstr������ = ""
            mstr���x�O���[�v = ""
            mstr�V�t�g�敪 = ""
            mcur�J�[�h���� = 0
            mstr�J�[�h�p���`NO = ""
            mint�ǒ��蓖�敪 = -1
            mstr��Q�ғ��� = ""
            mstr��Q��� = ""
            mint�ό������N = -1
            mstr�ό������N�ύX�� = ""
            mint��w�\�͉p�� = -1
            mint��w�\�͊؍��� = -1
            mint��w�\�͓ƌ� = -1
            mint��w�\�͕��� = -1
            mint��w�\�͒����� = -1

            For intIdx = MC_MIN_��w�\�͂��̑� To MC_MAX_��w�\�͂��̑�

                maint��w�\�͂��̑�(intIdx) = -1

            Next intIdx

            mstr���N���� = ""
            mstr�O�񌒐f�N���x = ""

            For intIdx = MC_MIN_�a�� To MC_MAX_�a��

                mastr�a��(intIdx) = ""
                mastr�a��N���J�n(intIdx) = ""
                mastr�a��N���I��(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_���L���� To MC_MAX_���L����

                mastr���L����(intIdx) = ""

            Next intIdx

            mstr�폜�� = ""
            mstr�斱���ؔ��s�� = ""
            mstr�^�]�Ƌ��X�V�� = ""
            mstr�g���ؖ������s�� = ""
            mint���̓����N = -1
            mstr�p�X���[�h = ""
            mstr�{�Вn = ""
            mstr�o�g�n = ""
            mstr�ŏI�w�Z�� = ""
            mstr�ŏI�w�Z�w���� = ""
            mstr�ŏI�w�Z�w�Ȗ� = ""
            mstr�ŏI���ƔN�x = ""
            mint�ŏI�w�Z���Ƌ敪 = -1
            mint�斱�o�� = -1
            mstr�o���n = ""
            mstr�o���N = ""
            mstr�o���� = ""

            For intIdx = MC_MIN_�擾���i To MC_MAX_�擾���i

                mastr�擾���i(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_�擾�N�� To MC_MAX_�擾�N��

                mastr�擾�N��(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_�E�� To MC_MAX_�E��

                mastr�E��(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_���ДN�� To MC_MAX_���ДN��

                mastr���ДN��(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_�ސE�N�� To MC_MAX_�ސE�N��

                mastr�ސE�N��(intIdx) = ""

            Next intIdx

            mstr����o�H = ""
            mstr�X�V�]�ƈ��R�[�h = ""
            mdte�X�V���t���� = Now
            mint���Ћ敪 = -1
            mstr���Џ����R�[�h = ""
            mstr�ގЏ����R�[�h = ""
            mstr�o�^�� = ""
            mint���ʎ蓖�敪 = -1
            mstr�����N = ""
            mstr���Ў���� = ""
            mint���Ɨp�ԗL���敪 = -1
            mint���q�ی������敪 = -1
            mstrETC = ""
            mstr�o�Ў��Ԓ� = ""
            mstr�o�Ў��Ԗ� = ""
            mstr�o�Ў��Ԋu�� = ""
            mstr��ЃR�[�h = ""
            mstr��Ж� = ""
            mstr��Ж����� = ""
            mstr���Ə��R�[�h = ""
            mstr�_����Ԏ� = ""
            mstr�_����Ԏ� = ""
            mstr�o�����ЃR�[�h = ""
            mstr���Љ�ЃR�[�h = ""
            mstr�ގЉ�ЃR�[�h = ""
            mstr�Ύ��Y����R�[�h1 = ""
            mstr�Ύ��Y����R�[�h2 = ""
            mstr�Ύ��Y����R�[�h3 = ""

            mstr��퍇�i�� = ""
            mstr�Ƌ���� = ""

            mstr�O��X�V�Җ� = ""
            mstr�O��X�V���� = ""
            mcur�L���c���� = 0

            mint��Е��S�t���O = 0

            mint�Г��l�^�N�V�[�Ώێ� = 0
            mint��ԎO�l���Ώێ� = 0

            mstr���l = ""

            mstr���[�� = ""
            mstr�g�у��[�� = ""

            mstr�A�Ȑ�X�֔ԍ�1 = ""
            mstr�A�Ȑ�X�֔ԍ�2 = ""
            mstr�A�Ȑ�s���{�� = ""
            mstr�A�Ȑ�s��S = ""
            mstr�A�Ȑ撬���Ԓn = ""
            mstr�A�Ȑ捆�� = ""
            mstr�A�Ȑ�d�b�ԍ� = ""
            mstr�A�Ȑ�g�ѓd�b�ԍ� = ""
            mstr�A�Ȑ惁�[�� = ""
            mstr�A�Ȑ�g�у��[�� = ""
            mstr�A�Ȑ掁�� = ""
            mstr�A�Ȑ摱�� = ""

            mstr�g���ۏؐl������ = ""
            mstr�g���ۏؐl���J�i = ""
            mint�g���ۏؐl���� = -1
            mstr�g���ۏؐl���N���� = ""
            mstr�g���ۏؐl�o�^�� = ""
            mstr�g���ۏؐl�E�� = ""
            mstr�g���ۏؐl���� = ""
            mstr�g���ۏؐl�X�֔ԍ�1 = ""
            mstr�g���ۏؐl�X�֔ԍ�2 = ""
            mstr�g���ۏؐl�s���{�� = ""
            mstr�g���ۏؐl�s��S = ""
            mstr�g���ۏؐl�����Ԓn = ""
            mstr�g���ۏؐl���� = ""
            mstr�g���ۏؐl�d�b�ԍ� = ""
            mstr�g���ۏؐl�g�ѓd�b�ԍ� = ""
            mstr�g���ۏؐl���[�� = ""
            mstr�g���ۏؐl�g�у��[�� = ""

            mint��L���X�|�[�c = -1
            mint��L���X�|�[�c�ȊO = -1

            For intIdx = MC_MIN_��X�|�[�c To MC_MAX_��X�|�[�c

                mastr��X�|�[�c(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_��X�|�[�c�ȊO To MC_MAX_��X�|�[�c�ȊO

                mastr��X�|�[�c�ȊO(intIdx) = ""

            Next intIdx

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d5426e1a-9968-4741-bab1-3fdff0d51455
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d5426e1a-9968-4741-bab1-3fdff0d51455

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d5426e1a-9968-4741-bab1-3fdff0d51455
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d5426e1a-9968-4741-bab1-3fdff0d51455
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : DBConnect
    ' �X�R�[�v  : Public
    ' �������e  : �c�a�ڑ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrUserName        String            I     ���[�U��
    '   pstrPassWord        String            I     �p�X���[�h
    '   pstrTNS             String            I     �s�m�r��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBConnect"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBConnect"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()
            '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d5426e1a-9968-4741-bab1-3fdff0d51455
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:d5426e1a-9968-4741-bab1-3fdff0d51455
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:81141d37-b937-4056-a8cf-f559b1bb477a
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:81141d37-b937-4056-a8cf-f559b1bb477a

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:81141d37-b937-4056-a8cf-f559b1bb477a
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:81141d37-b937-4056-a8cf-f559b1bb477a
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : DBObjectSet
    ' �X�R�[�v  : Public
    ' �������e  : �c�a�I�u�W�F�N�g�ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDatabase
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBObjectSet"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBObjectSet"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:81141d37-b937-4056-a8cf-f559b1bb477a
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:81141d37-b937-4056-a8cf-f559b1bb477a
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
    '******************************************************************************
    ' �� �� ��  : CheckEmployeeInfo
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��}�X�^ ���݃`�F�b�N
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     �]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function CheckEmployeeInfo(ByVal pstrEmployeeCode As String) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_CheckEmployeeInfo"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_CheckEmployeeInfo"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
            'Dim objDysTemp As Object
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDysTemp As OraDynaset
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i�ُ�I���j
            CheckEmployeeInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            '�����v�|�C���^��ݒ�
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h   = '" & pstrEmployeeCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' �߂�l��ݒ�(����I��)
                    CheckEmployeeInfo = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b9b93079-970c-47b2-b760-b36208259d04
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b9b93079-970c-47b2-b760-b36208259d04

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b9b93079-970c-47b2-b760-b36208259d04
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b9b93079-970c-47b2-b760-b36208259d04
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : SetEmployeeInfo
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��}�X�^ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     �]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '   01.02.00    2010/04/30  �A��  �F��         �[����ЃR�[�h, �[�������R�[�h, ���K����ЃR�[�h, ����ы��K�������R�[�h��ǉ�
    '
    '******************************************************************************
    Public Function SetEmployeeInfo(ByVal pstrEmployeeCode As String, Optional ByVal pstrDate As String = "") As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfo"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strDate As String
        Dim strIdx As String
        Dim intIdx As Short
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfo"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
            'Dim objDysTemp As Object
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDysTemp As OraDynaset
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strDate As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strIdx As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intIdx As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i�ُ�I���j
            SetEmployeeInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    JGM1.�]�ƈ��R�[�h                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����R�[�h                              "
            strSQL = strSQL & Chr(10) & "  , BSM1.������                                  "
            strSQL = strSQL & Chr(10) & "  , BSM1.����������                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�c�ƕʎЈ��R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�Ζ��敪                                "
            strSQL = strSQL & Chr(10) & "  , MSM1.�Ζ��敪��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.��E�ʃR�[�h                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���i�R�[�h                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.����                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.���t�^                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�]�ƈ�������                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�]�ƈ����J�i                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���s�ݏZ�J�n�N��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�֔ԍ��P                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�֔ԍ��Q                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�s���{��                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�s��S                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����Ԓn                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.����                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.�d�b�ԍ�                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g�ѓd�b�ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ƒ����ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���З\��N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŐV�ٓ��N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŐV�o���N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o���揊���R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގЗ\���                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގДN����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�R�[�h                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����敪                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����ΑӃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�x���J�n��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.���A�\���                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.���A�N����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�}�C�J�[�ʋ΋敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���N�ی��ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����N���ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ٗp�ی��ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ٗp�ی������L��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŋ敪                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�[����ЃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , KSM2.��Ж�                 AS �[����Ж�    "
            strSQL = strSQL & Chr(10) & "  , JGM1.�[�������R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , BSM2.������                 AS �[��������    "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K����ЃR�[�h                        "
            strSQL = strSQL & Chr(10) & "  , KSM3.��Ж�                 AS ���K����Ж�  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�������R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , BSM3.������                 AS ���K��������  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�Z���^�[�����\���                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�Z���^�[������                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�敪                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�I�C���t                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K���Ɠ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����\��N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����N����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�v���[�g�m�n                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�t�@�[�X�g                              "
            strSQL = strSQL & Chr(10) & "  , FSM.�t�@�[�X�g��                             "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{���㖱�敪                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{���ԍ�                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{�����q�敪                            "
            strSQL = strSQL & Chr(10) & "  , SKM.���q�敪��              AS �{�����q�敪��"
            strSQL = strSQL & Chr(10) & "  , JGM1.�{���Ԏ�R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.������                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���x�O���[�v                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�V�t�g�敪                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�J�[�h����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�J�[�h�p���`�m�n                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ǒ��蓖�敪                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.��Q�ғ���                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.��Q���                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ό������N                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ό������N�ύX��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͉p��                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͊؍���                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͓ƌ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͕���                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͒�����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��P                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��Q                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��R                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��S                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��T                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���N����                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�O�񌒐f�N���x                          "

            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�P""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�Q""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�R""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�S""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�T""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�U""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�V""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�W""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�X""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�P�O""                        "

            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���P""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���Q""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���R""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���S""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���T""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���U""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���V""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���W""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���X""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���P�O""                        "

            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���P""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���Q""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���R""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���S""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���T""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���U""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���V""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���W""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���X""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""�a���P�O""                                "

            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����P""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����Q""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����R""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����S""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����T""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����U""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����V""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����W""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����X""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����P�O""                            "

            strSQL = strSQL & Chr(10) & "  , JGM1.�폜��                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�斱���ؔ��s��                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�^�]�Ƌ��X�V��                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ؖ������s��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���̓����N                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�p�X���[�h                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{�Вn                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�g�n                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z�w����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z�w�Ȗ�                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI���ƔN�x                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z���Ƌ敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�斱�o��                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o���n                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o���N                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o����                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�P                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�Q                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�R                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�S                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�T                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���P                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���Q                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���R                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���S                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���T                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���P                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���P                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���P                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���Q                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���Q                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���Q                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���R                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���R                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���R                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���S                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���S                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���S                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���T                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���T                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���T                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���U                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���U                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���U                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���V                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���V                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���V                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���W                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���W                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���W                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���X                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���X                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���X                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�E���P�O                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���P�O                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���P�O                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.����o�H                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�V�]�ƈ��R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM2.�]�ƈ�������           AS �O��X�V�Җ�  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�V���t����                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ћ敪                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Џ����R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގЏ����R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�^��                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ʎ蓖�敪                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����N                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ў����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ɨp�ԗL���敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���q�ی������敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�d�s�b                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�Ў��Ԓ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�Ў��Ԗ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�Ў��Ԋu��                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.��ЃR�[�h                              "
            strSQL = strSQL & Chr(10) & "  , KSM1.��Ж�                                  "
            strSQL = strSQL & Chr(10) & "  , KSM1.����                   AS ��Ж�����    "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ə��R�[�h                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�_����Ԏ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�_����Ԏ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�����ЃR�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Љ�ЃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގЉ�ЃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�Ύ��Y����R�[�h�P                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�Ύ��Y����R�[�h�Q                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�Ύ��Y����R�[�h�R                      "
            strSQL = strSQL & Chr(10) & "  , MRW.��퍇�i��                               "
            strSQL = strSQL & Chr(10) & "  , MRW.�Ƌ����                                 "
            strSQL = strSQL & Chr(10) & "  , NVL(KJN.UQ_ZENZ_1, 0)                        "
            strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_TOUZ_1, 0)                        "
            strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_ZENZ_3, 0)       AS �L���c����    "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.��Е��S�t���O,0)  AS ��Е��S�t���O "

            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.�Г��l�^�N�V�[�Ώێ�,0) AS �Г��l�^�N�V�[�Ώێ� "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.��ԎO�l���Ώێ�      ,0) AS ��ԎO�l���Ώێ�       "

            strSQL = strSQL & Chr(10) & "  , JGM1.���[��                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g�у��[��                              "

            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�X�֔ԍ��P                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�X�֔ԍ��Q                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�s���{��                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�s��S                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ撬���Ԓn                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ捆��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�d�b�ԍ�                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�g�ѓd�b�ԍ�                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ惁�[��                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�g�у��[��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ掁��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ摱��                              "

            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl������                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl���J�i                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl���N����                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�o�^��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�E��                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�X�֔ԍ��P                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�X�֔ԍ��Q                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�s���{��                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�s��S                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�����Ԓn                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�d�b�ԍ�                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�g�ѓd�b�ԍ�                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl���[��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�g�у��[��                    "

            strSQL = strSQL & Chr(10) & "  , JGM1.��L���X�|�[�c                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.��L���X�|�[�c�ȊO                    "

            For intIdx = MC_MIN_��X�|�[�c To MC_MAX_��X�|�[�c

                strIdx = VB6.Format(intIdx, "00")

                strSQL = strSQL & Chr(10) & "  , JGM1.��X�|�[�c" & strIdx & "                          "

            Next intIdx

            For intIdx = MC_MIN_��X�|�[�c�ȊO To MC_MAX_��X�|�[�c�ȊO

                strIdx = VB6.Format(intIdx, "00")

                strSQL = strSQL & Chr(10) & "  , JGM1.��X�|�[�c�ȊO" & strIdx & "                      "

            Next intIdx

            strSQL = strSQL & Chr(10) & "  , JGM1.���l                                    "

            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��}�X�^     JGM1 "
            strSQL = strSQL & Chr(10) & "  , �]�ƈ��}�X�^     JGM2 "
            strSQL = strSQL & Chr(10) & "  , ��Ѓ}�X�^       KSM1 "
            strSQL = strSQL & Chr(10) & "  , �����}�X�^       BSM1 "

            strSQL = strSQL & Chr(10) & "  , ��Ѓ}�X�^       KSM2 "
            strSQL = strSQL & Chr(10) & "  , �����}�X�^       BSM2 "

            strSQL = strSQL & Chr(10) & "  , ��Ѓ}�X�^       KSM3 "
            strSQL = strSQL & Chr(10) & "  , �����}�X�^       BSM3 "

            strSQL = strSQL & Chr(10) & "  , �t�@�[�X�g�}�X�^ FSM "
            strSQL = strSQL & Chr(10) & "  , ���q�敪�}�X�^   SKM "
            strSQL = strSQL & Chr(10) & "  , KYUYO.KOJIN      KJN "
            strSQL = strSQL & Chr(10) & "  , ( "
            strSQL = strSQL & Chr(10) & "        SELECT "
            strSQL = strSQL & Chr(10) & "            �R�[�h   AS �Ζ��敪   "
            strSQL = strSQL & Chr(10) & "          , ���̊��� AS �Ζ��敪�� "
            strSQL = strSQL & Chr(10) & "        FROM "
            strSQL = strSQL & Chr(10) & "            ���̃}�X�^ "
            strSQL = strSQL & Chr(10) & "        WHERE "
            strSQL = strSQL & Chr(10) & "            ���� = '�Ζ��敪' "
            strSQL = strSQL & Chr(10) & "    ) MSM1 "

            strSQL = strSQL & Chr(10) & "  , ( "
            strSQL = strSQL & Chr(10) & "        SELECT "
            strSQL = strSQL & Chr(10) & "            WRK.�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "          , MRT.��퍇�i��   "
            strSQL = strSQL & Chr(10) & "          , DECODE(MRT.��^��,1,'��Q', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.���^��,1,'���Q', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.���ʓ�,1,'���Q', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.��^  ,1,'��P', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.���^  ,1,'���P', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.����  ,1,'���P', '�Ȃ�')))))) AS �Ƌ���� "
            strSQL = strSQL & Chr(10) & "        FROM "
            strSQL = strSQL & Chr(10) & "            �Ƌ��ؗ����e�[�u�� MRT "
            strSQL = strSQL & Chr(10) & "          , ( "
            strSQL = strSQL & Chr(10) & "                SELECT "
            strSQL = strSQL & Chr(10) & "                    �]�ƈ��R�[�h         "
            strSQL = strSQL & Chr(10) & "                  , MAX(�}��)    AS �}�� "
            strSQL = strSQL & Chr(10) & "                FROM "
            strSQL = strSQL & Chr(10) & "                    �Ƌ��ؗ����e�[�u�� "

            If pstrDate <> "" Then

                strSQL = strSQL & Chr(10) & "                WHERE "
                strSQL = strSQL & Chr(10) & "                    ��t�� <= '" & pstrDate & "' "

            End If

            strSQL = strSQL & Chr(10) & "                GROUP BY "
            strSQL = strSQL & Chr(10) & "                    �]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "            ) WRK "
            strSQL = strSQL & Chr(10) & "        WHERE "
            strSQL = strSQL & Chr(10) & "            WRK.�]�ƈ��R�[�h = MRT.�]�ƈ��R�[�h(+) "
            strSQL = strSQL & Chr(10) & "        AND WRK.�}��         = MRT.�}��        (+) "
            strSQL = strSQL & Chr(10) & "    ) MRW "

            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    JGM1.�]�ƈ��R�[�h     = '" & pstrEmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "AND JGM1.�X�V�]�ƈ��R�[�h = JGM2.�]�ƈ��R�[�h(+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.��ЃR�[�h       = KSM1.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.��ЃR�[�h       = BSM1.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�����R�[�h       = BSM1.�����R�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�[����ЃR�[�h   = KSM2.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�[����ЃR�[�h   = BSM2.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�[�������R�[�h   = BSM2.�����R�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.���K����ЃR�[�h = KSM3.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.���K����ЃR�[�h = BSM3.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.���K�������R�[�h = BSM3.�����R�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�]�ƈ��R�[�h     = MRW.�]�ƈ��R�[�h (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.��ЃR�[�h       = SKM.��ЃR�[�h   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�{�����q�敪     = SKM.���q�敪     (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�t�@�[�X�g       = FSM.�t�@�[�X�g   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�Ζ��敪         = MSM1.�Ζ��敪    (+) "
            strSQL = strSQL & Chr(10) & "AND TO_CHAR( "
            strSQL = strSQL & Chr(10) & "        JGM1.�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "      , 'FM0000000000'   "
            strSQL = strSQL & Chr(10) & "    )                    = KJN.SHAIN_CODE    (+) "

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' �߂�l��ݒ�(����I��)
                    SetEmployeeInfo = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�]�ƈ��R�[�h = gfncFieldVal(.Fields("�]�ƈ��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����R�[�h = gfncFieldVal(.Fields("�����R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr������ = gfncFieldVal(.Fields("������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���������� = gfncFieldVal(.Fields("����������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�c�ƕʎЈ��R�[�h = gfncFieldVal(.Fields("�c�ƕʎЈ��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�Ζ��敪 = gfncFieldCur(.Fields("�Ζ��敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ζ��敪�� = gfncFieldVal(.Fields("�Ζ��敪��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��E�ʃR�[�h = gfncFieldCur(.Fields("��E�ʃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���i�R�[�h = gfncFieldCur(.Fields("���i�R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���� = gfncFieldCur(.Fields("����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���t�^ = gfncFieldCur(.Fields("���t�^").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�]�ƈ������� = gfncFieldVal(.Fields("�]�ƈ�������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�]�ƈ����J�i = gfncFieldVal(.Fields("�]�ƈ����J�i").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���s�ݏZ�J�n�N�� = gfncFieldVal(.Fields("���s�ݏZ�J�n�N��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�X�֔ԍ�1 = gfncFieldVal(.Fields("�X�֔ԍ��P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�X�֔ԍ�2 = gfncFieldVal(.Fields("�X�֔ԍ��Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�s���{�� = gfncFieldVal(.Fields("�s���{��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�s��S = gfncFieldVal(.Fields("�s��S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����Ԓn = gfncFieldVal(.Fields("�����Ԓn").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���� = gfncFieldVal(.Fields("����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�d�b�ԍ� = gfncFieldVal(.Fields("�d�b�ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g�ѓd�b�ԍ� = gfncFieldVal(.Fields("�g�ѓd�b�ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�ƒ����ԍ� = gfncFieldCur(.Fields("�ƒ����ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���З\��N���� = gfncFieldVal(.Fields("���З\��N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���ДN���� = gfncFieldVal(.Fields("���ДN����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ŐV�ٓ��N���� = gfncFieldVal(.Fields("�ŐV�ٓ��N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ŐV�o���N���� = gfncFieldVal(.Fields("�ŐV�o���N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o���揊���R�[�h = gfncFieldVal(.Fields("�o���揊���R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ގЗ\��� = gfncFieldVal(.Fields("�ގЗ\���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ގДN���� = gfncFieldVal(.Fields("�ގДN����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ސE�R�[�h = gfncFieldVal(.Fields("�ސE�R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�����敪 = gfncFieldCur(.Fields("�����敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����ΑӃR�[�h = gfncFieldVal(.Fields("�����ΑӃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�x���J�n�� = gfncFieldVal(.Fields("�x���J�n��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���A�\��� = gfncFieldVal(.Fields("���A�\���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���A�N���� = gfncFieldVal(.Fields("���A�N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�}�C�J�[�ʋ΋敪 = gfncFieldCur(.Fields("�}�C�J�[�ʋ΋敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���N�ی��ԍ� = gfncFieldVal(.Fields("���N�ی��ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����N���ԍ� = gfncFieldVal(.Fields("�����N���ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ٗp�ی��ԍ� = gfncFieldVal(.Fields("�ٗp�ی��ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�ٗp�ی������L�� = gfncFieldCur(.Fields("�ٗp�ی������L��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�ŋ敪 = gfncFieldCur(.Fields("�ŋ敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�[����ЃR�[�h = gfncFieldVal(.Fields("�[����ЃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�[����Ж� = gfncFieldVal(.Fields("�[����Ж�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�[�������R�[�h = gfncFieldVal(.Fields("�[�������R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�[�������� = gfncFieldVal(.Fields("�[��������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K����ЃR�[�h = gfncFieldVal(.Fields("���K����ЃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K����Ж� = gfncFieldVal(.Fields("���K����Ж�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K�������R�[�h = gfncFieldVal(.Fields("���K�������R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K�������� = gfncFieldVal(.Fields("���K��������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K�Z���^�[�����\��� = gfncFieldVal(.Fields("���K�Z���^�[�����\���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K�Z���^�[������ = gfncFieldVal(.Fields("���K�Z���^�[������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���K�敪 = gfncFieldCur(.Fields("���K�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�I�C���t = gfncFieldVal(.Fields("�I�C���t").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K���Ɠ� = gfncFieldVal(.Fields("���K���Ɠ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����\��N���� = gfncFieldVal(.Fields("�����\��N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����N���� = gfncFieldVal(.Fields("�����N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�v���[�gNO = gfncFieldVal(.Fields("�v���[�g�m�n").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�t�@�[�X�g = gfncFieldCur(.Fields("�t�@�[�X�g").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�t�@�[�X�g�� = gfncFieldVal(.Fields("�t�@�[�X�g��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�{���㖱�敪 = gfncFieldCur(.Fields("�{���㖱�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{���ԍ� = gfncFieldVal(.Fields("�{���ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{�����q�敪 = gfncFieldVal(.Fields("�{�����q�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{�����q�敪�� = gfncFieldVal(.Fields("�{�����q�敪��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{���Ԏ�R�[�h = gfncFieldVal(.Fields("�{���Ԏ�R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr������ = gfncFieldVal(.Fields("������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���x�O���[�v = gfncFieldVal(.Fields("���x�O���[�v").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�V�t�g�敪 = gfncFieldVal(.Fields("�V�t�g�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mcur�J�[�h���� = gfncFieldCur(.Fields("�J�[�h����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�J�[�h�p���`NO = gfncFieldVal(.Fields("�J�[�h�p���`�m�n").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�ǒ��蓖�敪 = gfncFieldCur(.Fields("�ǒ��蓖�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��Q�ғ��� = gfncFieldVal(.Fields("��Q�ғ���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��Q��� = gfncFieldVal(.Fields("��Q���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�ό������N = gfncFieldCur(.Fields("�ό������N").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ό������N�ύX�� = gfncFieldVal(.Fields("�ό������N�ύX��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��w�\�͉p�� = gfncFieldCur(.Fields("��w�\�͉p��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��w�\�͊؍��� = gfncFieldCur(.Fields("��w�\�͊؍���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��w�\�͓ƌ� = gfncFieldCur(.Fields("��w�\�͓ƌ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��w�\�͕��� = gfncFieldCur(.Fields("��w�\�͕���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��w�\�͒����� = gfncFieldCur(.Fields("��w�\�͒�����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint��w�\�͂��̑�(1) = gfncFieldCur(.Fields("��w�\�͂��̑��P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint��w�\�͂��̑�(2) = gfncFieldCur(.Fields("��w�\�͂��̑��Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint��w�\�͂��̑�(3) = gfncFieldCur(.Fields("��w�\�͂��̑��R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint��w�\�͂��̑�(4) = gfncFieldCur(.Fields("��w�\�͂��̑��S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint��w�\�͂��̑�(5) = gfncFieldCur(.Fields("��w�\�͂��̑��T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���N���� = gfncFieldVal(.Fields("���N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�O�񌒐f�N���x = gfncFieldVal(.Fields("�O�񌒐f�N���x").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(1) = gfncFieldVal(.Fields("�a��N���J�n�P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(2) = gfncFieldVal(.Fields("�a��N���J�n�Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(3) = gfncFieldVal(.Fields("�a��N���J�n�R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(4) = gfncFieldVal(.Fields("�a��N���J�n�S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(5) = gfncFieldVal(.Fields("�a��N���J�n�T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(6) = gfncFieldVal(.Fields("�a��N���J�n�U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(7) = gfncFieldVal(.Fields("�a��N���J�n�V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(8) = gfncFieldVal(.Fields("�a��N���J�n�W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(9) = gfncFieldVal(.Fields("�a��N���J�n�X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���J�n(10) = gfncFieldVal(.Fields("�a��N���J�n�P�O").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(1) = gfncFieldVal(.Fields("�a��N���I���P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(2) = gfncFieldVal(.Fields("�a��N���I���Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(3) = gfncFieldVal(.Fields("�a��N���I���R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(4) = gfncFieldVal(.Fields("�a��N���I���S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(5) = gfncFieldVal(.Fields("�a��N���I���T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(6) = gfncFieldVal(.Fields("�a��N���I���U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(7) = gfncFieldVal(.Fields("�a��N���I���V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(8) = gfncFieldVal(.Fields("�a��N���I���W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(9) = gfncFieldVal(.Fields("�a��N���I���X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��N���I��(10) = gfncFieldVal(.Fields("�a��N���I���P�O").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(1) = gfncFieldVal(.Fields("�a���P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(2) = gfncFieldVal(.Fields("�a���Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(3) = gfncFieldVal(.Fields("�a���R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(4) = gfncFieldVal(.Fields("�a���S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(5) = gfncFieldVal(.Fields("�a���T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(6) = gfncFieldVal(.Fields("�a���U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(7) = gfncFieldVal(.Fields("�a���V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(8) = gfncFieldVal(.Fields("�a���W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(9) = gfncFieldVal(.Fields("�a���X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�a��(10) = gfncFieldVal(.Fields("�a���P�O").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(1) = gfncFieldVal(.Fields("���L�����P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(2) = gfncFieldVal(.Fields("���L�����Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(3) = gfncFieldVal(.Fields("���L�����R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(4) = gfncFieldVal(.Fields("���L�����S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(5) = gfncFieldVal(.Fields("���L�����T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(6) = gfncFieldVal(.Fields("���L�����U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(7) = gfncFieldVal(.Fields("���L�����V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(8) = gfncFieldVal(.Fields("���L�����W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(9) = gfncFieldVal(.Fields("���L�����X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���L����(10) = gfncFieldVal(.Fields("���L�����P�O").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�폜�� = gfncFieldVal(.Fields("�폜��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�斱���ؔ��s�� = gfncFieldVal(.Fields("�斱���ؔ��s��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�^�]�Ƌ��X�V�� = gfncFieldVal(.Fields("�^�]�Ƌ��X�V��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ؖ������s�� = gfncFieldVal(.Fields("�g���ؖ������s��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���̓����N = gfncFieldCur(.Fields("���̓����N").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�p�X���[�h = gfncFieldVal(.Fields("�p�X���[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{�Вn = gfncFieldVal(.Fields("�{�Вn").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o�g�n = gfncFieldVal(.Fields("�o�g�n").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ŏI�w�Z�� = gfncFieldVal(.Fields("�ŏI�w�Z��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ŏI�w�Z�w���� = gfncFieldVal(.Fields("�ŏI�w�Z�w����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ŏI�w�Z�w�Ȗ� = gfncFieldVal(.Fields("�ŏI�w�Z�w�Ȗ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ŏI���ƔN�x = gfncFieldVal(.Fields("�ŏI���ƔN�x").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�ŏI�w�Z���Ƌ敪 = gfncFieldCur(.Fields("�ŏI�w�Z���Ƌ敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�斱�o�� = gfncFieldCur(.Fields("�斱�o��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o���n = gfncFieldVal(.Fields("�o���n").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o���N = gfncFieldVal(.Fields("�o���N").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o���� = gfncFieldVal(.Fields("�o����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾���i(1) = gfncFieldVal(.Fields("�擾���i�P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾���i(2) = gfncFieldVal(.Fields("�擾���i�Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾���i(3) = gfncFieldVal(.Fields("�擾���i�R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾���i(4) = gfncFieldVal(.Fields("�擾���i�S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾���i(5) = gfncFieldVal(.Fields("�擾���i�T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾�N��(1) = gfncFieldVal(.Fields("�擾�N���P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾�N��(2) = gfncFieldVal(.Fields("�擾�N���Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾�N��(3) = gfncFieldVal(.Fields("�擾�N���R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾�N��(4) = gfncFieldVal(.Fields("�擾�N���S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�擾�N��(5) = gfncFieldVal(.Fields("�擾�N���T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(1) = gfncFieldVal(.Fields("�E���P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(2) = gfncFieldVal(.Fields("�E���Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(3) = gfncFieldVal(.Fields("�E���R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(4) = gfncFieldVal(.Fields("�E���S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(5) = gfncFieldVal(.Fields("�E���T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(6) = gfncFieldVal(.Fields("�E���U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(7) = gfncFieldVal(.Fields("�E���V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(8) = gfncFieldVal(.Fields("�E���W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(9) = gfncFieldVal(.Fields("�E���X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�E��(10) = gfncFieldVal(.Fields("�E���P�O").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(1) = gfncFieldVal(.Fields("���ДN���P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(2) = gfncFieldVal(.Fields("���ДN���Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(3) = gfncFieldVal(.Fields("���ДN���R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(4) = gfncFieldVal(.Fields("���ДN���S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(5) = gfncFieldVal(.Fields("���ДN���T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(6) = gfncFieldVal(.Fields("���ДN���U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(7) = gfncFieldVal(.Fields("���ДN���V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(8) = gfncFieldVal(.Fields("���ДN���W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(9) = gfncFieldVal(.Fields("���ДN���X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr���ДN��(10) = gfncFieldVal(.Fields("���ДN���P�O").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(1) = gfncFieldVal(.Fields("�ސE�N���P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(2) = gfncFieldVal(.Fields("�ސE�N���Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(3) = gfncFieldVal(.Fields("�ސE�N���R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(4) = gfncFieldVal(.Fields("�ސE�N���S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(5) = gfncFieldVal(.Fields("�ސE�N���T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(6) = gfncFieldVal(.Fields("�ސE�N���U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(7) = gfncFieldVal(.Fields("�ސE�N���V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(8) = gfncFieldVal(.Fields("�ސE�N���W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(9) = gfncFieldVal(.Fields("�ސE�N���X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr�ސE�N��(10) = gfncFieldVal(.Fields("�ސE�N���P�O").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr����o�H = gfncFieldVal(.Fields("����o�H").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�X�V�]�ƈ��R�[�h = gfncFieldVal(.Fields("�X�V�]�ƈ��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�O��X�V�Җ� = gfncFieldVal(.Fields("�O��X�V�Җ�").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("�X�V���t����").Value)) = True Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mdte�X�V���t���� = gfncFieldVal(.Fields("�X�V���t����").Value)

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���Ћ敪 = gfncFieldCur(.Fields("���Ћ敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���Џ����R�[�h = gfncFieldVal(.Fields("���Џ����R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ގЏ����R�[�h = gfncFieldVal(.Fields("�ގЏ����R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o�^�� = gfncFieldVal(.Fields("�o�^��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���ʎ蓖�敪 = gfncFieldCur(.Fields("���ʎ蓖�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����N = gfncFieldVal(.Fields("�����N").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���Ў���� = gfncFieldVal(.Fields("���Ў����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���Ɨp�ԗL���敪 = gfncFieldCur(.Fields("���Ɨp�ԗL���敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���q�ی������敪 = gfncFieldCur(.Fields("���q�ی������敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrETC = gfncFieldVal(.Fields("�d�s�b").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o�Ў��Ԓ� = gfncFieldVal(.Fields("�o�Ў��Ԓ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o�Ў��Ԗ� = gfncFieldVal(.Fields("�o�Ў��Ԗ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o�Ў��Ԋu�� = gfncFieldVal(.Fields("�o�Ў��Ԋu��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��ЃR�[�h = gfncFieldVal(.Fields("��ЃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��Ж� = gfncFieldVal(.Fields("��Ж�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��Ж����� = gfncFieldVal(.Fields("��Ж�����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���Ə��R�[�h = gfncFieldVal(.Fields("���Ə��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�_����Ԏ� = gfncFieldVal(.Fields("�_����Ԏ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�_����Ԏ� = gfncFieldVal(.Fields("�_����Ԏ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�o�����ЃR�[�h = gfncFieldVal(.Fields("�o�����ЃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���Љ�ЃR�[�h = gfncFieldVal(.Fields("���Љ�ЃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ގЉ�ЃR�[�h = gfncFieldVal(.Fields("�ގЉ�ЃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ύ��Y����R�[�h1 = gfncFieldVal(.Fields("�Ύ��Y����R�[�h�P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ύ��Y����R�[�h2 = gfncFieldVal(.Fields("�Ύ��Y����R�[�h�Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ύ��Y����R�[�h3 = gfncFieldVal(.Fields("�Ύ��Y����R�[�h�R").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr��퍇�i�� = gfncFieldVal(.Fields("��퍇�i��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ƌ���� = gfncFieldVal(.Fields("�Ƌ����").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("�X�V���t����").Value)) = False Then

                        mstr�O��X�V���� = ""

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mstr�O��X�V���� = VB6.Format(gfncFieldVal(.Fields("�X�V���t����").Value), "yyyy/mm/dd hh:mm:ss")

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mcur�L���c���� = gfncFieldCur(.Fields("�L���c����").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��Е��S�t���O = CShort(gfncFieldCur(.Fields("��Е��S�t���O").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�Г��l�^�N�V�[�Ώێ� = CShort(gfncFieldCur(.Fields("�Г��l�^�N�V�[�Ώێ�").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��ԎO�l���Ώێ� = CShort(gfncFieldCur(.Fields("��ԎO�l���Ώێ�").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���[�� = gfncFieldVal(.Fields("���[��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g�у��[�� = gfncFieldVal(.Fields("�g�у��[��").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�X�֔ԍ�1 = gfncFieldVal(.Fields("�A�Ȑ�X�֔ԍ��P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�X�֔ԍ�2 = gfncFieldVal(.Fields("�A�Ȑ�X�֔ԍ��Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�s���{�� = gfncFieldVal(.Fields("�A�Ȑ�s���{��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�s��S = gfncFieldVal(.Fields("�A�Ȑ�s��S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ撬���Ԓn = gfncFieldVal(.Fields("�A�Ȑ撬���Ԓn").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ捆�� = gfncFieldVal(.Fields("�A�Ȑ捆��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�d�b�ԍ� = gfncFieldVal(.Fields("�A�Ȑ�d�b�ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�g�ѓd�b�ԍ� = gfncFieldVal(.Fields("�A�Ȑ�g�ѓd�b�ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ惁�[�� = gfncFieldVal(.Fields("�A�Ȑ惁�[��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ�g�у��[�� = gfncFieldVal(.Fields("�A�Ȑ�g�у��[��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ掁�� = gfncFieldVal(.Fields("�A�Ȑ掁��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�A�Ȑ摱�� = gfncFieldVal(.Fields("�A�Ȑ摱��").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl������ = gfncFieldVal(.Fields("�g���ۏؐl������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl���J�i = gfncFieldVal(.Fields("�g���ۏؐl���J�i").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�g���ۏؐl���� = CShort(gfncFieldCur(.Fields("�g���ۏؐl����").Value))
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl���N���� = gfncFieldVal(.Fields("�g���ۏؐl���N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�o�^�� = gfncFieldVal(.Fields("�g���ۏؐl�o�^��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�E�� = gfncFieldVal(.Fields("�g���ۏؐl�E��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl���� = gfncFieldVal(.Fields("�g���ۏؐl����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�X�֔ԍ�1 = gfncFieldVal(.Fields("�g���ۏؐl�X�֔ԍ��P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�X�֔ԍ�2 = gfncFieldVal(.Fields("�g���ۏؐl�X�֔ԍ��Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�s���{�� = gfncFieldVal(.Fields("�g���ۏؐl�s���{��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�s��S = gfncFieldVal(.Fields("�g���ۏؐl�s��S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�����Ԓn = gfncFieldVal(.Fields("�g���ۏؐl�����Ԓn").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl���� = gfncFieldVal(.Fields("�g���ۏؐl����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�d�b�ԍ� = gfncFieldVal(.Fields("�g���ۏؐl�d�b�ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�g�ѓd�b�ԍ� = gfncFieldVal(.Fields("�g���ۏؐl�g�ѓd�b�ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl���[�� = gfncFieldVal(.Fields("�g���ۏؐl���[��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�g���ۏؐl�g�у��[�� = gfncFieldVal(.Fields("�g���ۏؐl�g�у��[��").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��L���X�|�[�c = gfncFieldCur(.Fields("��L���X�|�[�c").Value)

                    For intIdx = MC_MIN_��X�|�[�c To MC_MAX_��X�|�[�c

                        strIdx = VB6.Format(intIdx, "00")

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mastr��X�|�[�c(intIdx) = gfncFieldVal(.Fields("��X�|�[�c" & strIdx).Value)

                    Next intIdx

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��L���X�|�[�c�ȊO = gfncFieldCur(.Fields("��L���X�|�[�c�ȊO").Value)

                    For intIdx = MC_MIN_��X�|�[�c�ȊO To MC_MAX_��X�|�[�c�ȊO

                        strIdx = VB6.Format(intIdx, "00")

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mastr��X�|�[�c�ȊO(intIdx) = gfncFieldVal(.Fields("��X�|�[�c�ȊO" & strIdx).Value)

                    Next intIdx

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���l = gfncFieldVal(.Fields("���l").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b9b93079-970c-47b2-b760-b36208259d04
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b9b93079-970c-47b2-b760-b36208259d04
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : SetEmployeeInfoMini
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��}�X�^ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     �]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2018/08/07  KSR                �s�v�Ȍl�����擾���Ȃ�
    '
    '******************************************************************************
    Public Function SetEmployeeInfoMini(ByVal pstrEmployeeCode As String) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfoMini"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strDate As String
        Dim strIdx As String
        Dim intIdx As Short
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfoMini"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
            'Dim objDysTemp As Object
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDysTemp As OraDynaset
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strDate As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strIdx As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intIdx As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i�ُ�I���j
            SetEmployeeInfoMini = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    JGM1.�]�ƈ��R�[�h                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����R�[�h                              "
            strSQL = strSQL & Chr(10) & "  , BSM1.������                                  "
            strSQL = strSQL & Chr(10) & "  , BSM1.����������                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�c�ƕʎЈ��R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�Ζ��敪                                "
            strSQL = strSQL & Chr(10) & "  , MSM1.�Ζ��敪��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.��E�ʃR�[�h                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���i�R�[�h                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.����                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.���t�^                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�]�ƈ�������                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�]�ƈ����J�i                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���s�ݏZ�J�n�N��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�֔ԍ��P                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�֔ԍ��Q                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�s���{��                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�s��S                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����Ԓn                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.����                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.�d�b�ԍ�                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�g�ѓd�b�ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ƒ����ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���З\��N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ДN����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŐV�ٓ��N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŐV�o���N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o���揊���R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގЗ\���                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގДN����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�R�[�h                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����敪                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����ΑӃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�x���J�n��                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.���A�\���                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.���A�N����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�}�C�J�[�ʋ΋敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���N�ی��ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����N���ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ٗp�ی��ԍ�                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ٗp�ی������L��                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ŋ敪                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�[����ЃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , KSM2.��Ж�                 AS �[����Ж�    "
            strSQL = strSQL & Chr(10) & "  , JGM1.�[�������R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , BSM2.������                 AS �[��������    "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K����ЃR�[�h                        "
            strSQL = strSQL & Chr(10) & "  , KSM3.��Ж�                 AS ���K����Ж�  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�������R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , BSM3.������                 AS ���K��������  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�Z���^�[�����\���                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�Z���^�[������                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K�敪                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�I�C���t                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.���K���Ɠ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����\��N����                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����N����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�v���[�g�m�n                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�t�@�[�X�g                              "
            strSQL = strSQL & Chr(10) & "  , FSM.�t�@�[�X�g��                             "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{���㖱�敪                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{���ԍ�                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�{�����q�敪                            "
            strSQL = strSQL & Chr(10) & "  , SKM.���q�敪��              AS �{�����q�敪��"
            strSQL = strSQL & Chr(10) & "  , JGM1.�{���Ԏ�R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.������                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���x�O���[�v                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�V�t�g�敪                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�J�[�h����                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�J�[�h�p���`�m�n                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ǒ��蓖�敪                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��Q�ғ���                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��Q���                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ό������N                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ό������N�ύX��                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͉p��                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͊؍���                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͓ƌ�                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͕���                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͒�����                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��P                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��Q                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��R                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��S                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��w�\�͂��̑��T                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���N����                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�O�񌒐f�N���x                          "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�P""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�Q""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�R""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�S""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�T""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�U""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�V""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�W""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�X""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���J�n�P�O""                        "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���P""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���Q""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���R""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���S""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���T""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���U""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���V""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���W""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���X""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a��N���I���P�O""                        "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���P""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���Q""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���R""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���S""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���T""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���U""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���V""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���W""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���X""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""�a���P�O""                                "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����P""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����Q""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����R""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����S""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����T""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����U""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����V""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����W""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����X""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""���L�����P�O""                            "

            '    strSQL = strSQL & Chr(10) & "  , JGM1.�폜��                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�斱���ؔ��s��                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�^�]�Ƌ��X�V��                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ؖ������s��                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���̓����N                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�p�X���[�h                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�{�Вn                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�o�g�n                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z��                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z�w����                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z�w�Ȗ�                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI���ƔN�x                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ŏI�w�Z���Ƌ敪                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�斱�o��                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�o���n                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�o���N                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�o����                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�P                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�Q                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�R                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�S                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾���i�T                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���P                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���Q                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���R                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���S                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�擾�N���T                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���P                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���P                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���P                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���Q                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���Q                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���Q                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���R                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���R                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���R                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���S                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���S                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���S                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���T                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���T                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���T                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���U                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���U                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���U                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���V                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���V                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���V                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���W                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���W                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���W                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���X                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���X                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���X                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�E���P�O                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.���ДN���P�O                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�ސE�N���P�O                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.����o�H                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�V�]�ƈ��R�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM2.�]�ƈ�������           AS �O��X�V�Җ�  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�X�V���t����                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ћ敪                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Џ����R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގЏ����R�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�^��                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���ʎ蓖�敪                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�����N                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ў����                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ɨp�ԗL���敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���q�ی������敪                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.�d�s�b                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�Ў��Ԓ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�Ў��Ԗ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�Ў��Ԋu��                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.��ЃR�[�h                              "
            strSQL = strSQL & Chr(10) & "  , KSM1.��Ж�                                  "
            strSQL = strSQL & Chr(10) & "  , KSM1.����                   AS ��Ж�����    "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Ə��R�[�h                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.�_����Ԏ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�_����Ԏ�                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.�o�����ЃR�[�h                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.���Љ�ЃR�[�h                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.�ގЉ�ЃR�[�h                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�Ύ��Y����R�[�h�P                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�Ύ��Y����R�[�h�Q                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�Ύ��Y����R�[�h�R                      "
            '    strSQL = strSQL & Chr(10) & "  , MRW.��퍇�i��                               "
            '    strSQL = strSQL & Chr(10) & "  , MRW.�Ƌ����                                 "
            '    strSQL = strSQL & Chr(10) & "  , NVL(KJN.UQ_ZENZ_1, 0)                        "
            '    strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_TOUZ_1, 0)                        "
            '    strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_ZENZ_3, 0)       AS �L���c����    "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.��Е��S�t���O,0)  AS ��Е��S�t���O "

            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.�Г��l�^�N�V�[�Ώێ�,0) AS �Г��l�^�N�V�[�Ώێ� "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.��ԎO�l���Ώێ�      ,0) AS ��ԎO�l���Ώێ�       "

            '    strSQL = strSQL & Chr(10) & "  , JGM1.���[��                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g�у��[��                              "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�X�֔ԍ��P                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�X�֔ԍ��Q                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�s���{��                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�s��S                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ撬���Ԓn                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ捆��                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�d�b�ԍ�                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�g�ѓd�b�ԍ�                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ惁�[��                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ�g�у��[��                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ掁��                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�A�Ȑ摱��                              "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl������                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl���J�i                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl����                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl���N����                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�o�^��                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�E��                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl����                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�X�֔ԍ��P                    "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�X�֔ԍ��Q                    "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�s���{��                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�s��S                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�����Ԓn                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl����                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�d�b�ԍ�                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�g�ѓd�b�ԍ�                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl���[��                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.�g���ۏؐl�g�у��[��                    "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��L���X�|�[�c                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.��L���X�|�[�c�ȊO                    "
            '
            '    For intIdx = MC_MIN_��X�|�[�c To MC_MAX_��X�|�[�c
            '
            '        strIdx = Format(intIdx, "00")
            '
            '        strSQL = strSQL & Chr(10) & "  , JGM1.��X�|�[�c" & strIdx & "                          "
            '
            '    Next intIdx
            '
            '    For intIdx = MC_MIN_��X�|�[�c�ȊO To MC_MAX_��X�|�[�c�ȊO
            '
            '        strIdx = Format(intIdx, "00")
            '
            '        strSQL = strSQL & Chr(10) & "  , JGM1.��X�|�[�c�ȊO" & strIdx & "                      "
            '
            '    Next intIdx

            strSQL = strSQL & Chr(10) & "  , JGM1.���l                                    "

            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��}�X�^     JGM1 "
            strSQL = strSQL & Chr(10) & "  , �]�ƈ��}�X�^     JGM2 "
            strSQL = strSQL & Chr(10) & "  , ��Ѓ}�X�^       KSM1 "
            strSQL = strSQL & Chr(10) & "  , �����}�X�^       BSM1 "

            strSQL = strSQL & Chr(10) & "  , ��Ѓ}�X�^       KSM2 "
            strSQL = strSQL & Chr(10) & "  , �����}�X�^       BSM2 "

            strSQL = strSQL & Chr(10) & "  , ��Ѓ}�X�^       KSM3 "
            strSQL = strSQL & Chr(10) & "  , �����}�X�^       BSM3 "

            strSQL = strSQL & Chr(10) & "  , �t�@�[�X�g�}�X�^ FSM "
            strSQL = strSQL & Chr(10) & "  , ���q�敪�}�X�^   SKM "
            '    strSQL = strSQL & Chr(10) & "  , KYUYO.KOJIN      KJN "
            strSQL = strSQL & Chr(10) & "  , ( "
            strSQL = strSQL & Chr(10) & "        SELECT "
            strSQL = strSQL & Chr(10) & "            �R�[�h   AS �Ζ��敪   "
            strSQL = strSQL & Chr(10) & "          , ���̊��� AS �Ζ��敪�� "
            strSQL = strSQL & Chr(10) & "        FROM "
            strSQL = strSQL & Chr(10) & "            ���̃}�X�^ "
            strSQL = strSQL & Chr(10) & "        WHERE "
            strSQL = strSQL & Chr(10) & "            ���� = '�Ζ��敪' "
            strSQL = strSQL & Chr(10) & "    ) MSM1 "

            '    strSQL = strSQL & Chr(10) & "  , ( "
            '    strSQL = strSQL & Chr(10) & "        SELECT "
            '    strSQL = strSQL & Chr(10) & "            WRK.�]�ƈ��R�[�h "
            '    strSQL = strSQL & Chr(10) & "          , MRT.��퍇�i��   "
            '    strSQL = strSQL & Chr(10) & "          , DECODE(MRT.��^��,1,'��Q', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.���^��,1,'���Q', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.���ʓ�,1,'���Q', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.��^  ,1,'��P', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.���^  ,1,'���P', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.����  ,1,'���P', '�Ȃ�')))))) AS �Ƌ���� "
            '    strSQL = strSQL & Chr(10) & "        FROM "
            '    strSQL = strSQL & Chr(10) & "            �Ƌ��ؗ����e�[�u�� MRT "
            '    strSQL = strSQL & Chr(10) & "          , ( "
            '    strSQL = strSQL & Chr(10) & "                SELECT "
            '    strSQL = strSQL & Chr(10) & "                    �]�ƈ��R�[�h         "
            '    strSQL = strSQL & Chr(10) & "                  , MAX(�}��)    AS �}�� "
            '    strSQL = strSQL & Chr(10) & "                FROM "
            '    strSQL = strSQL & Chr(10) & "                    �Ƌ��ؗ����e�[�u�� "
            ''
            ''    If pstrDate <> "" Then
            ''
            ''        strSQL = strSQL & Chr(10) & "                WHERE "
            ''        strSQL = strSQL & Chr(10) & "                    ��t�� <= '" & pstrDate & "' "
            ''
            ''    End If
            '
            '    strSQL = strSQL & Chr(10) & "                GROUP BY "
            '    strSQL = strSQL & Chr(10) & "                    �]�ƈ��R�[�h "
            '    strSQL = strSQL & Chr(10) & "            ) WRK "
            '    strSQL = strSQL & Chr(10) & "        WHERE "
            '    strSQL = strSQL & Chr(10) & "            WRK.�]�ƈ��R�[�h = MRT.�]�ƈ��R�[�h(+) "
            '    strSQL = strSQL & Chr(10) & "        AND WRK.�}��         = MRT.�}��        (+) "
            '    strSQL = strSQL & Chr(10) & "    ) MRW "

            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    JGM1.�]�ƈ��R�[�h     = '" & pstrEmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "AND JGM1.�X�V�]�ƈ��R�[�h = JGM2.�]�ƈ��R�[�h(+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.��ЃR�[�h       = KSM1.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.��ЃR�[�h       = BSM1.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�����R�[�h       = BSM1.�����R�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�[����ЃR�[�h   = KSM2.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�[����ЃR�[�h   = BSM2.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�[�������R�[�h   = BSM2.�����R�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.���K����ЃR�[�h = KSM3.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.���K����ЃR�[�h = BSM3.��ЃR�[�h  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.���K�������R�[�h = BSM3.�����R�[�h  (+) "
            '    strSQL = strSQL & Chr(10) & "AND JGM1.�]�ƈ��R�[�h     = MRW.�]�ƈ��R�[�h (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.��ЃR�[�h       = SKM.��ЃR�[�h   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�{�����q�敪     = SKM.���q�敪     (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�t�@�[�X�g       = FSM.�t�@�[�X�g   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.�Ζ��敪         = MSM1.�Ζ��敪    (+) "
            '    strSQL = strSQL & Chr(10) & "AND TO_CHAR( "
            '    strSQL = strSQL & Chr(10) & "        JGM1.�]�ƈ��R�[�h "
            '    strSQL = strSQL & Chr(10) & "      , 'FM0000000000'   "
            '    strSQL = strSQL & Chr(10) & "    )                    = KJN.SHAIN_CODE    (+) "

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' �߂�l��ݒ�(����I��)
                    SetEmployeeInfoMini = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�]�ƈ��R�[�h = gfncFieldVal(.Fields("�]�ƈ��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����R�[�h = gfncFieldVal(.Fields("�����R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr������ = gfncFieldVal(.Fields("������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���������� = gfncFieldVal(.Fields("����������").Value)
                    '            mstr�c�ƕʎЈ��R�[�h = gfncFieldVal(.Fields("�c�ƕʎЈ��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�Ζ��敪 = gfncFieldCur(.Fields("�Ζ��敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�Ζ��敪�� = gfncFieldVal(.Fields("�Ζ��敪��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��E�ʃR�[�h = gfncFieldCur(.Fields("��E�ʃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���i�R�[�h = gfncFieldCur(.Fields("���i�R�[�h").Value)
                    '            mint���� = gfncFieldCur(.Fields("����").Value)
                    '            mint���t�^ = gfncFieldCur(.Fields("���t�^").Value)
                    '            mstr�]�ƈ������� = gfncFieldVal(.Fields("�]�ƈ�������").Value)
                    '            mstr�]�ƈ����J�i = gfncFieldVal(.Fields("�]�ƈ����J�i").Value)
                    '            mstr���s�ݏZ�J�n�N�� = gfncFieldVal(.Fields("���s�ݏZ�J�n�N��").Value)
                    '            mstr�X�֔ԍ�1 = gfncFieldVal(.Fields("�X�֔ԍ��P").Value)
                    '            mstr�X�֔ԍ�2 = gfncFieldVal(.Fields("�X�֔ԍ��Q").Value)
                    '            mstr�s���{�� = gfncFieldVal(.Fields("�s���{��").Value)
                    '            mstr�s��S = gfncFieldVal(.Fields("�s��S").Value)
                    '            mstr�����Ԓn = gfncFieldVal(.Fields("�����Ԓn").Value)
                    '            mstr���� = gfncFieldVal(.Fields("����").Value)
                    '            mstr�d�b�ԍ� = gfncFieldVal(.Fields("�d�b�ԍ�").Value)
                    '            mstr�g�ѓd�b�ԍ� = gfncFieldVal(.Fields("�g�ѓd�b�ԍ�").Value)
                    '            mint�ƒ����ԍ� = gfncFieldCur(.Fields("�ƒ����ԍ�").Value)
                    '            mstr���З\��N���� = gfncFieldVal(.Fields("���З\��N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���ДN���� = gfncFieldVal(.Fields("���ДN����").Value)
                    '            mstr�ŐV�ٓ��N���� = gfncFieldVal(.Fields("�ŐV�ٓ��N����").Value)
                    '            mstr�ŐV�o���N���� = gfncFieldVal(.Fields("�ŐV�o���N����").Value)
                    '            mstr�o���揊���R�[�h = gfncFieldVal(.Fields("�o���揊���R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ގЗ\��� = gfncFieldVal(.Fields("�ގЗ\���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ގДN���� = gfncFieldVal(.Fields("�ގДN����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�ސE�R�[�h = gfncFieldVal(.Fields("�ސE�R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�����敪 = gfncFieldCur(.Fields("�����敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����ΑӃR�[�h = gfncFieldVal(.Fields("�����ΑӃR�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�x���J�n�� = gfncFieldVal(.Fields("�x���J�n��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���A�\��� = gfncFieldVal(.Fields("���A�\���").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���A�N���� = gfncFieldVal(.Fields("���A�N����").Value)
                    '            mint�}�C�J�[�ʋ΋敪 = gfncFieldCur(.Fields("�}�C�J�[�ʋ΋敪").Value)
                    '            mstr���N�ی��ԍ� = gfncFieldVal(.Fields("���N�ی��ԍ�").Value)
                    '            mstr�����N���ԍ� = gfncFieldVal(.Fields("�����N���ԍ�").Value)
                    '            mstr�ٗp�ی��ԍ� = gfncFieldVal(.Fields("�ٗp�ی��ԍ�").Value)
                    '            mint�ٗp�ی������L�� = gfncFieldCur(.Fields("�ٗp�ی������L��").Value)
                    '            mint�ŋ敪 = gfncFieldCur(.Fields("�ŋ敪").Value)
                    '            mstr�[����ЃR�[�h = gfncFieldVal(.Fields("�[����ЃR�[�h").Value)
                    '            mstr�[����Ж� = gfncFieldVal(.Fields("�[����Ж�").Value)
                    '            mstr�[�������R�[�h = gfncFieldVal(.Fields("�[�������R�[�h").Value)
                    '            mstr�[�������� = gfncFieldVal(.Fields("�[��������").Value)
                    '            mstr���K����ЃR�[�h = gfncFieldVal(.Fields("���K����ЃR�[�h").Value)
                    '            mstr���K����Ж� = gfncFieldVal(.Fields("���K����Ж�").Value)
                    '            mstr���K�������R�[�h = gfncFieldVal(.Fields("���K�������R�[�h").Value)
                    '            mstr���K�������� = gfncFieldVal(.Fields("���K��������").Value)
                    '            mstr���K�Z���^�[�����\��� = gfncFieldVal(.Fields("���K�Z���^�[�����\���").Value)
                    '            mstr���K�Z���^�[������ = gfncFieldVal(.Fields("���K�Z���^�[������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint���K�敪 = gfncFieldCur(.Fields("���K�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�I�C���t = gfncFieldVal(.Fields("�I�C���t").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���K���Ɠ� = gfncFieldVal(.Fields("���K���Ɠ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����\��N���� = gfncFieldVal(.Fields("�����\��N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�����N���� = gfncFieldVal(.Fields("�����N����").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�v���[�gNO = gfncFieldVal(.Fields("�v���[�g�m�n").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�t�@�[�X�g = gfncFieldCur(.Fields("�t�@�[�X�g").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�t�@�[�X�g�� = gfncFieldVal(.Fields("�t�@�[�X�g��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�{���㖱�敪 = gfncFieldCur(.Fields("�{���㖱�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{���ԍ� = gfncFieldVal(.Fields("�{���ԍ�").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{�����q�敪 = gfncFieldVal(.Fields("�{�����q�敪").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{�����q�敪�� = gfncFieldVal(.Fields("�{�����q�敪��").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�{���Ԏ�R�[�h = gfncFieldVal(.Fields("�{���Ԏ�R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr������ = gfncFieldVal(.Fields("������").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr���x�O���[�v = gfncFieldVal(.Fields("���x�O���[�v").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�V�t�g�敪 = gfncFieldVal(.Fields("�V�t�g�敪").Value)
                    '            mcur�J�[�h���� = gfncFieldCur(.Fields("�J�[�h����").Value)
                    '            mstr�J�[�h�p���`NO = gfncFieldVal(.Fields("�J�[�h�p���`�m�n").Value)
                    '            mint�ǒ��蓖�敪 = gfncFieldCur(.Fields("�ǒ��蓖�敪").Value)
                    '            mstr��Q�ғ��� = gfncFieldVal(.Fields("��Q�ғ���").Value)
                    '            mstr��Q��� = gfncFieldVal(.Fields("��Q���").Value)
                    '            mint�ό������N = gfncFieldCur(.Fields("�ό������N").Value)
                    '            mstr�ό������N�ύX�� = gfncFieldVal(.Fields("�ό������N�ύX��").Value)
                    '            mint��w�\�͉p�� = gfncFieldCur(.Fields("��w�\�͉p��").Value)
                    '            mint��w�\�͊؍��� = gfncFieldCur(.Fields("��w�\�͊؍���").Value)
                    '            mint��w�\�͓ƌ� = gfncFieldCur(.Fields("��w�\�͓ƌ�").Value)
                    '            mint��w�\�͕��� = gfncFieldCur(.Fields("��w�\�͕���").Value)
                    '            mint��w�\�͒����� = gfncFieldCur(.Fields("��w�\�͒�����").Value)
                    '            maint��w�\�͂��̑�(1) = gfncFieldCur(.Fields("��w�\�͂��̑��P").Value)
                    '            maint��w�\�͂��̑�(2) = gfncFieldCur(.Fields("��w�\�͂��̑��Q").Value)
                    '            maint��w�\�͂��̑�(3) = gfncFieldCur(.Fields("��w�\�͂��̑��R").Value)
                    '            maint��w�\�͂��̑�(4) = gfncFieldCur(.Fields("��w�\�͂��̑��S").Value)
                    '            maint��w�\�͂��̑�(5) = gfncFieldCur(.Fields("��w�\�͂��̑��T").Value)
                    '            mstr���N���� = gfncFieldVal(.Fields("���N����").Value)
                    '            mstr�O�񌒐f�N���x = gfncFieldVal(.Fields("�O�񌒐f�N���x").Value)
                    '
                    '            mastr�a��N���J�n(1) = gfncFieldVal(.Fields("�a��N���J�n�P").Value)
                    '            mastr�a��N���J�n(2) = gfncFieldVal(.Fields("�a��N���J�n�Q").Value)
                    '            mastr�a��N���J�n(3) = gfncFieldVal(.Fields("�a��N���J�n�R").Value)
                    '            mastr�a��N���J�n(4) = gfncFieldVal(.Fields("�a��N���J�n�S").Value)
                    '            mastr�a��N���J�n(5) = gfncFieldVal(.Fields("�a��N���J�n�T").Value)
                    '            mastr�a��N���J�n(6) = gfncFieldVal(.Fields("�a��N���J�n�U").Value)
                    '            mastr�a��N���J�n(7) = gfncFieldVal(.Fields("�a��N���J�n�V").Value)
                    '            mastr�a��N���J�n(8) = gfncFieldVal(.Fields("�a��N���J�n�W").Value)
                    '            mastr�a��N���J�n(9) = gfncFieldVal(.Fields("�a��N���J�n�X").Value)
                    '            mastr�a��N���J�n(10) = gfncFieldVal(.Fields("�a��N���J�n�P�O").Value)
                    '
                    '            mastr�a��N���I��(1) = gfncFieldVal(.Fields("�a��N���I���P").Value)
                    '            mastr�a��N���I��(2) = gfncFieldVal(.Fields("�a��N���I���Q").Value)
                    '            mastr�a��N���I��(3) = gfncFieldVal(.Fields("�a��N���I���R").Value)
                    '            mastr�a��N���I��(4) = gfncFieldVal(.Fields("�a��N���I���S").Value)
                    '            mastr�a��N���I��(5) = gfncFieldVal(.Fields("�a��N���I���T").Value)
                    '            mastr�a��N���I��(6) = gfncFieldVal(.Fields("�a��N���I���U").Value)
                    '            mastr�a��N���I��(7) = gfncFieldVal(.Fields("�a��N���I���V").Value)
                    '            mastr�a��N���I��(8) = gfncFieldVal(.Fields("�a��N���I���W").Value)
                    '            mastr�a��N���I��(9) = gfncFieldVal(.Fields("�a��N���I���X").Value)
                    '            mastr�a��N���I��(10) = gfncFieldVal(.Fields("�a��N���I���P�O").Value)
                    '
                    '            mastr�a��(1) = gfncFieldVal(.Fields("�a���P").Value)
                    '            mastr�a��(2) = gfncFieldVal(.Fields("�a���Q").Value)
                    '            mastr�a��(3) = gfncFieldVal(.Fields("�a���R").Value)
                    '            mastr�a��(4) = gfncFieldVal(.Fields("�a���S").Value)
                    '            mastr�a��(5) = gfncFieldVal(.Fields("�a���T").Value)
                    '            mastr�a��(6) = gfncFieldVal(.Fields("�a���U").Value)
                    '            mastr�a��(7) = gfncFieldVal(.Fields("�a���V").Value)
                    '            mastr�a��(8) = gfncFieldVal(.Fields("�a���W").Value)
                    '            mastr�a��(9) = gfncFieldVal(.Fields("�a���X").Value)
                    '            mastr�a��(10) = gfncFieldVal(.Fields("�a���P�O").Value)
                    '
                    '            mastr���L����(1) = gfncFieldVal(.Fields("���L�����P").Value)
                    '            mastr���L����(2) = gfncFieldVal(.Fields("���L�����Q").Value)
                    '            mastr���L����(3) = gfncFieldVal(.Fields("���L�����R").Value)
                    '            mastr���L����(4) = gfncFieldVal(.Fields("���L�����S").Value)
                    '            mastr���L����(5) = gfncFieldVal(.Fields("���L�����T").Value)
                    '            mastr���L����(6) = gfncFieldVal(.Fields("���L�����U").Value)
                    '            mastr���L����(7) = gfncFieldVal(.Fields("���L�����V").Value)
                    '            mastr���L����(8) = gfncFieldVal(.Fields("���L�����W").Value)
                    '            mastr���L����(9) = gfncFieldVal(.Fields("���L�����X").Value)
                    '            mastr���L����(10) = gfncFieldVal(.Fields("���L�����P�O").Value)
                    '
                    '            mstr�폜�� = gfncFieldVal(.Fields("�폜��").Value)
                    '            mstr�斱���ؔ��s�� = gfncFieldVal(.Fields("�斱���ؔ��s��").Value)
                    '            mstr�^�]�Ƌ��X�V�� = gfncFieldVal(.Fields("�^�]�Ƌ��X�V��").Value)
                    '            mstr�g���ؖ������s�� = gfncFieldVal(.Fields("�g���ؖ������s��").Value)
                    '            mint���̓����N = gfncFieldCur(.Fields("���̓����N").Value)
                    '            mstr�p�X���[�h = gfncFieldVal(.Fields("�p�X���[�h").Value)
                    '            mstr�{�Вn = gfncFieldVal(.Fields("�{�Вn").Value)
                    '            mstr�o�g�n = gfncFieldVal(.Fields("�o�g�n").Value)
                    '            mstr�ŏI�w�Z�� = gfncFieldVal(.Fields("�ŏI�w�Z��").Value)
                    '            mstr�ŏI�w�Z�w���� = gfncFieldVal(.Fields("�ŏI�w�Z�w����").Value)
                    '            mstr�ŏI�w�Z�w�Ȗ� = gfncFieldVal(.Fields("�ŏI�w�Z�w�Ȗ�").Value)
                    '            mstr�ŏI���ƔN�x = gfncFieldVal(.Fields("�ŏI���ƔN�x").Value)
                    '            mint�ŏI�w�Z���Ƌ敪 = gfncFieldCur(.Fields("�ŏI�w�Z���Ƌ敪").Value)
                    '            mint�斱�o�� = gfncFieldCur(.Fields("�斱�o��").Value)
                    '            mstr�o���n = gfncFieldVal(.Fields("�o���n").Value)
                    '            mstr�o���N = gfncFieldVal(.Fields("�o���N").Value)
                    '            mstr�o���� = gfncFieldVal(.Fields("�o����").Value)
                    '            mastr�擾���i(1) = gfncFieldVal(.Fields("�擾���i�P").Value)
                    '            mastr�擾���i(2) = gfncFieldVal(.Fields("�擾���i�Q").Value)
                    '            mastr�擾���i(3) = gfncFieldVal(.Fields("�擾���i�R").Value)
                    '            mastr�擾���i(4) = gfncFieldVal(.Fields("�擾���i�S").Value)
                    '            mastr�擾���i(5) = gfncFieldVal(.Fields("�擾���i�T").Value)
                    '            mastr�擾�N��(1) = gfncFieldVal(.Fields("�擾�N���P").Value)
                    '            mastr�擾�N��(2) = gfncFieldVal(.Fields("�擾�N���Q").Value)
                    '            mastr�擾�N��(3) = gfncFieldVal(.Fields("�擾�N���R").Value)
                    '            mastr�擾�N��(4) = gfncFieldVal(.Fields("�擾�N���S").Value)
                    '            mastr�擾�N��(5) = gfncFieldVal(.Fields("�擾�N���T").Value)
                    '            mastr�E��(1) = gfncFieldVal(.Fields("�E���P").Value)
                    '            mastr�E��(2) = gfncFieldVal(.Fields("�E���Q").Value)
                    '            mastr�E��(3) = gfncFieldVal(.Fields("�E���R").Value)
                    '            mastr�E��(4) = gfncFieldVal(.Fields("�E���S").Value)
                    '            mastr�E��(5) = gfncFieldVal(.Fields("�E���T").Value)
                    '            mastr�E��(6) = gfncFieldVal(.Fields("�E���U").Value)
                    '            mastr�E��(7) = gfncFieldVal(.Fields("�E���V").Value)
                    '            mastr�E��(8) = gfncFieldVal(.Fields("�E���W").Value)
                    '            mastr�E��(9) = gfncFieldVal(.Fields("�E���X").Value)
                    '            mastr�E��(10) = gfncFieldVal(.Fields("�E���P�O").Value)
                    '            mastr���ДN��(1) = gfncFieldVal(.Fields("���ДN���P").Value)
                    '            mastr���ДN��(2) = gfncFieldVal(.Fields("���ДN���Q").Value)
                    '            mastr���ДN��(3) = gfncFieldVal(.Fields("���ДN���R").Value)
                    '            mastr���ДN��(4) = gfncFieldVal(.Fields("���ДN���S").Value)
                    '            mastr���ДN��(5) = gfncFieldVal(.Fields("���ДN���T").Value)
                    '            mastr���ДN��(6) = gfncFieldVal(.Fields("���ДN���U").Value)
                    '            mastr���ДN��(7) = gfncFieldVal(.Fields("���ДN���V").Value)
                    '            mastr���ДN��(8) = gfncFieldVal(.Fields("���ДN���W").Value)
                    '            mastr���ДN��(9) = gfncFieldVal(.Fields("���ДN���X").Value)
                    '            mastr���ДN��(10) = gfncFieldVal(.Fields("���ДN���P�O").Value)
                    '            mastr�ސE�N��(1) = gfncFieldVal(.Fields("�ސE�N���P").Value)
                    '            mastr�ސE�N��(2) = gfncFieldVal(.Fields("�ސE�N���Q").Value)
                    '            mastr�ސE�N��(3) = gfncFieldVal(.Fields("�ސE�N���R").Value)
                    '            mastr�ސE�N��(4) = gfncFieldVal(.Fields("�ސE�N���S").Value)
                    '            mastr�ސE�N��(5) = gfncFieldVal(.Fields("�ސE�N���T").Value)
                    '            mastr�ސE�N��(6) = gfncFieldVal(.Fields("�ސE�N���U").Value)
                    '            mastr�ސE�N��(7) = gfncFieldVal(.Fields("�ސE�N���V").Value)
                    '            mastr�ސE�N��(8) = gfncFieldVal(.Fields("�ސE�N���W").Value)
                    '            mastr�ސE�N��(9) = gfncFieldVal(.Fields("�ސE�N���X").Value)
                    '            mastr�ސE�N��(10) = gfncFieldVal(.Fields("�ސE�N���P�O").Value)
                    '            mstr����o�H = gfncFieldVal(.Fields("����o�H").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�X�V�]�ƈ��R�[�h = gfncFieldVal(.Fields("�X�V�]�ƈ��R�[�h").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr�O��X�V�Җ� = gfncFieldVal(.Fields("�O��X�V�Җ�").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("�X�V���t����").Value)) = True Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mdte�X�V���t���� = gfncFieldVal(.Fields("�X�V���t����").Value)

                    End If

                    '            mint���Ћ敪 = gfncFieldCur(.Fields("���Ћ敪").Value)
                    '            mstr���Џ����R�[�h = gfncFieldVal(.Fields("���Џ����R�[�h").Value)
                    '            mstr�ގЏ����R�[�h = gfncFieldVal(.Fields("�ގЏ����R�[�h").Value)
                    '            mstr�o�^�� = gfncFieldVal(.Fields("�o�^��").Value)
                    '            mint���ʎ蓖�敪 = gfncFieldCur(.Fields("���ʎ蓖�敪").Value)
                    '            mstr�����N = gfncFieldVal(.Fields("�����N").Value)
                    '            mstr���Ў���� = gfncFieldVal(.Fields("���Ў����").Value)
                    '            mint���Ɨp�ԗL���敪 = gfncFieldCur(.Fields("���Ɨp�ԗL���敪").Value)
                    '            mint���q�ی������敪 = gfncFieldCur(.Fields("���q�ی������敪").Value)
                    '            mstrETC = gfncFieldVal(.Fields("�d�s�b").Value)
                    '            mstr�o�Ў��Ԓ� = gfncFieldVal(.Fields("�o�Ў��Ԓ�").Value)
                    '            mstr�o�Ў��Ԗ� = gfncFieldVal(.Fields("�o�Ў��Ԗ�").Value)
                    '            mstr�o�Ў��Ԋu�� = gfncFieldVal(.Fields("�o�Ў��Ԋu��").Value)
                    '            mstr��ЃR�[�h = gfncFieldVal(.Fields("��ЃR�[�h").Value)
                    '            mstr��Ж� = gfncFieldVal(.Fields("��Ж�").Value)
                    '            mstr��Ж����� = gfncFieldVal(.Fields("��Ж�����").Value)
                    '            mstr���Ə��R�[�h = gfncFieldVal(.Fields("���Ə��R�[�h").Value)
                    '            mstr�_����Ԏ� = gfncFieldVal(.Fields("�_����Ԏ�").Value)
                    '            mstr�_����Ԏ� = gfncFieldVal(.Fields("�_����Ԏ�").Value)
                    '            mstr�o�����ЃR�[�h = gfncFieldVal(.Fields("�o�����ЃR�[�h").Value)
                    '            mstr���Љ�ЃR�[�h = gfncFieldVal(.Fields("���Љ�ЃR�[�h").Value)
                    '            mstr�ގЉ�ЃR�[�h = gfncFieldVal(.Fields("�ގЉ�ЃR�[�h").Value)
                    '            mstr�Ύ��Y����R�[�h1 = gfncFieldVal(.Fields("�Ύ��Y����R�[�h�P").Value)
                    '            mstr�Ύ��Y����R�[�h2 = gfncFieldVal(.Fields("�Ύ��Y����R�[�h�Q").Value)
                    '            mstr�Ύ��Y����R�[�h3 = gfncFieldVal(.Fields("�Ύ��Y����R�[�h�R").Value)
                    '
                    '            mstr��퍇�i�� = gfncFieldVal(.Fields("��퍇�i��").Value)
                    '            mstr�Ƌ���� = gfncFieldVal(.Fields("�Ƌ����").Value)
                    '
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("�X�V���t����").Value)) = False Then

                        mstr�O��X�V���� = ""

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mstr�O��X�V���� = VB6.Format(gfncFieldVal(.Fields("�X�V���t����").Value), "yyyy/mm/dd hh:mm:ss")

                    End If

                    '            mcur�L���c���� = gfncFieldCur(.Fields("�L���c����").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��Е��S�t���O = CShort(gfncFieldCur(.Fields("��Е��S�t���O").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint�Г��l�^�N�V�[�Ώێ� = CShort(gfncFieldCur(.Fields("�Г��l�^�N�V�[�Ώێ�").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint��ԎO�l���Ώێ� = CShort(gfncFieldCur(.Fields("��ԎO�l���Ώێ�").Value))

                    '            mstr���[�� = gfncFieldVal(.Fields("���[��").Value)
                    '            mstr�g�у��[�� = gfncFieldVal(.Fields("�g�у��[��").Value)
                    '
                    '            mstr�A�Ȑ�X�֔ԍ�1 = gfncFieldVal(.Fields("�A�Ȑ�X�֔ԍ��P").Value)
                    '            mstr�A�Ȑ�X�֔ԍ�2 = gfncFieldVal(.Fields("�A�Ȑ�X�֔ԍ��Q").Value)
                    '            mstr�A�Ȑ�s���{�� = gfncFieldVal(.Fields("�A�Ȑ�s���{��").Value)
                    '            mstr�A�Ȑ�s��S = gfncFieldVal(.Fields("�A�Ȑ�s��S").Value)
                    '            mstr�A�Ȑ撬���Ԓn = gfncFieldVal(.Fields("�A�Ȑ撬���Ԓn").Value)
                    '            mstr�A�Ȑ捆�� = gfncFieldVal(.Fields("�A�Ȑ捆��").Value)
                    '            mstr�A�Ȑ�d�b�ԍ� = gfncFieldVal(.Fields("�A�Ȑ�d�b�ԍ�").Value)
                    '            mstr�A�Ȑ�g�ѓd�b�ԍ� = gfncFieldVal(.Fields("�A�Ȑ�g�ѓd�b�ԍ�").Value)
                    '            mstr�A�Ȑ惁�[�� = gfncFieldVal(.Fields("�A�Ȑ惁�[��").Value)
                    '            mstr�A�Ȑ�g�у��[�� = gfncFieldVal(.Fields("�A�Ȑ�g�у��[��").Value)
                    '            mstr�A�Ȑ掁�� = gfncFieldVal(.Fields("�A�Ȑ掁��").Value)
                    '            mstr�A�Ȑ摱�� = gfncFieldVal(.Fields("�A�Ȑ摱��").Value)
                    '
                    '            mstr�g���ۏؐl������ = gfncFieldVal(.Fields("�g���ۏؐl������").Value)
                    '            mstr�g���ۏؐl���J�i = gfncFieldVal(.Fields("�g���ۏؐl���J�i").Value)
                    '            mint�g���ۏؐl���� = CInt(gfncFieldCur(.Fields("�g���ۏؐl����").Value))
                    '            mstr�g���ۏؐl���N���� = gfncFieldVal(.Fields("�g���ۏؐl���N����").Value)
                    '            mstr�g���ۏؐl�o�^�� = gfncFieldVal(.Fields("�g���ۏؐl�o�^��").Value)
                    '            mstr�g���ۏؐl�E�� = gfncFieldVal(.Fields("�g���ۏؐl�E��").Value)
                    '            mstr�g���ۏؐl���� = gfncFieldVal(.Fields("�g���ۏؐl����").Value)
                    '            mstr�g���ۏؐl�X�֔ԍ�1 = gfncFieldVal(.Fields("�g���ۏؐl�X�֔ԍ��P").Value)
                    '            mstr�g���ۏؐl�X�֔ԍ�2 = gfncFieldVal(.Fields("�g���ۏؐl�X�֔ԍ��Q").Value)
                    '            mstr�g���ۏؐl�s���{�� = gfncFieldVal(.Fields("�g���ۏؐl�s���{��").Value)
                    '            mstr�g���ۏؐl�s��S = gfncFieldVal(.Fields("�g���ۏؐl�s��S").Value)
                    '            mstr�g���ۏؐl�����Ԓn = gfncFieldVal(.Fields("�g���ۏؐl�����Ԓn").Value)
                    '            mstr�g���ۏؐl���� = gfncFieldVal(.Fields("�g���ۏؐl����").Value)
                    '            mstr�g���ۏؐl�d�b�ԍ� = gfncFieldVal(.Fields("�g���ۏؐl�d�b�ԍ�").Value)
                    '            mstr�g���ۏؐl�g�ѓd�b�ԍ� = gfncFieldVal(.Fields("�g���ۏؐl�g�ѓd�b�ԍ�").Value)
                    '            mstr�g���ۏؐl���[�� = gfncFieldVal(.Fields("�g���ۏؐl���[��").Value)
                    '            mstr�g���ۏؐl�g�у��[�� = gfncFieldVal(.Fields("�g���ۏؐl�g�у��[��").Value)
                    '
                    '            mint��L���X�|�[�c = gfncFieldCur(.Fields("��L���X�|�[�c").Value)
                    '
                    '            For intIdx = MC_MIN_��X�|�[�c To MC_MAX_��X�|�[�c
                    '
                    '                strIdx = Format(intIdx, "00")
                    '
                    '                mastr��X�|�[�c(intIdx) = gfncFieldVal(.Fields("��X�|�[�c" & strIdx).Value)
                    '
                    '            Next intIdx
                    '
                    '            mint��L���X�|�[�c�ȊO = gfncFieldCur(.Fields("��L���X�|�[�c�ȊO").Value)
                    '
                    '            For intIdx = MC_MIN_��X�|�[�c�ȊO To MC_MAX_��X�|�[�c�ȊO
                    '
                    '                strIdx = Format(intIdx, "00")
                    '
                    '                mastr��X�|�[�c�ȊO(intIdx) = gfncFieldVal(.Fields("��X�|�[�c�ȊO" & strIdx).Value)
                    '
                    '            Next intIdx
                    '
                    '            mstr���l = gfncFieldVal(.Fields("���l").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function



    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' �v���p�e�B
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' �� �� ��  : �]�ƈ��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �]�ƈ��R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �]�ƈ��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �]�ƈ��R�[�h() As String
        Get

            �]�ƈ��R�[�h = mstr�]�ƈ��R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�]�ƈ��R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �����R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �����R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �����R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����R�[�h() As String
        Get

            �����R�[�h = mstr�����R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�����R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ������
    ' �X�R�[�v  : Public
    ' �������e  : ������ �擾
    ' ��    �l  :
    ' �� �� �l  : ������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ������
    ' �X�R�[�v  : Public
    ' �������e  : ������ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ������() As String
        Get

            ������ = mstr������

        End Get
        Set(ByVal Value As String)

            mstr������ = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ����������
    ' �X�R�[�v  : Public
    ' �������e  : ���������� �擾
    ' ��    �l  :
    ' �� �� �l  : ����������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/12/20  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ����������
    ' �X�R�[�v  : Public
    ' �������e  : ���������� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ����������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/12/20  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ����������() As String
        Get

            ���������� = mstr����������

        End Get
        Set(ByVal Value As String)

            mstr���������� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �c�ƕʎЈ��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �c�ƕʎЈ��R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �c�ƕʎЈ��R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �c�ƕʎЈ��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �c�ƕʎЈ��R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �c�ƕʎЈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �c�ƕʎЈ��R�[�h() As String
        Get

            �c�ƕʎЈ��R�[�h = mstr�c�ƕʎЈ��R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�c�ƕʎЈ��R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ζ��敪
    ' �X�R�[�v  : Public
    ' �������e  : �Ζ��敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �Ζ��敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ζ��敪
    ' �X�R�[�v  : Public
    ' �������e  : �Ζ��敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �Ζ��敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Ζ��敪() As Short
        Get

            �Ζ��敪 = mint�Ζ��敪

        End Get
        Set(ByVal Value As Short)

            mint�Ζ��敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ζ��敪��
    ' �X�R�[�v  : Public
    ' �������e  : �Ζ��敪�� �擾
    ' ��    �l  :
    ' �� �� �l  : �Ζ��敪��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ζ��敪��
    ' �X�R�[�v  : Public
    ' �������e  : �Ζ��敪�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �Ζ��敪��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Ζ��敪��() As String
        Get

            �Ζ��敪�� = mstr�Ζ��敪��

        End Get
        Set(ByVal Value As String)

            mstr�Ζ��敪�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��E�ʃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ��E�ʃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ��E�ʃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��E�ʃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ��E�ʃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��E�ʃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��E�ʃR�[�h() As Short
        Get

            ��E�ʃR�[�h = mint��E�ʃR�[�h

        End Get
        Set(ByVal Value As Short)

            mint��E�ʃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���i�R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���i�R�[�h  �擾
    ' ��    �l  :
    ' �� �� �l  : ���i�R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���i�R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���i�R�[�h  �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���i�R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���i�R�[�h() As Short
        Get

            ���i�R�[�h = mint���i�R�[�h

        End Get
        Set(ByVal Value As Short)

            mint���i�R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ����
    ' �X�R�[�v  : Public
    ' �������e  : ���� �擾
    ' ��    �l  :
    ' �� �� �l  : ����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ����
    ' �X�R�[�v  : Public
    ' �������e  : ���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ����() As Short
        Get

            ���� = mint����

        End Get
        Set(ByVal Value As Short)

            mint���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���t�^
    ' �X�R�[�v  : Public
    ' �������e  : ���t�^ �擾
    ' ��    �l  :
    ' �� �� �l  : ���t�^
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���t�^
    ' �X�R�[�v  : Public
    ' �������e  : ���t�^ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���t�^
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���t�^() As Short
        Get

            ���t�^ = mint���t�^

        End Get
        Set(ByVal Value As Short)

            mint���t�^ = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �]�ƈ�������
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ������� �擾
    ' ��    �l  :
    ' �� �� �l  : �]�ƈ�������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �]�ƈ�������
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ������� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �]�ƈ�������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �]�ƈ�������() As String
        Get

            �]�ƈ������� = mstr�]�ƈ�������

        End Get
        Set(ByVal Value As String)

            mstr�]�ƈ������� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �]�ƈ����J�i
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ����J�i �擾
    ' ��    �l  :
    ' �� �� �l  : �]�ƈ����J�i
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �]�ƈ����J�i
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ����J�i �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �]�ƈ����J�i
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �]�ƈ����J�i() As String
        Get

            �]�ƈ����J�i = mstr�]�ƈ����J�i

        End Get
        Set(ByVal Value As String)

            mstr�]�ƈ����J�i = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���s�ݏZ�J�n�N��
    ' �X�R�[�v  : Public
    ' �������e  : ���s�ݏZ�J�n�N�� �擾
    ' ��    �l  :
    ' �� �� �l  : ���s�ݏZ�J�n�N��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���s�ݏZ�J�n�N��
    ' �X�R�[�v  : Public
    ' �������e  : ���s�ݏZ�J�n�N�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���s�ݏZ�J�n�N��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���s�ݏZ�J�n�N��() As String
        Get

            ���s�ݏZ�J�n�N�� = mstr���s�ݏZ�J�n�N��

        End Get
        Set(ByVal Value As String)

            mstr���s�ݏZ�J�n�N�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �X�֔ԍ�1
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ�1 �擾
    ' ��    �l  :
    ' �� �� �l  : �X�֔ԍ�1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �X�֔ԍ�1
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ�1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �X�֔ԍ�1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �X�֔ԍ�1() As String
        Get

            �X�֔ԍ�1 = mstr�X�֔ԍ�1

        End Get
        Set(ByVal Value As String)

            mstr�X�֔ԍ�1 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �X�֔ԍ�2
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ�2 �擾
    ' ��    �l  :
    ' �� �� �l  : �X�֔ԍ�2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �X�֔ԍ�2
    ' �X�R�[�v  : Public
    ' �������e  : �X�֔ԍ�2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �X�֔ԍ�2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �X�֔ԍ�2() As String
        Get

            �X�֔ԍ�2 = mstr�X�֔ԍ�2

        End Get
        Set(ByVal Value As String)

            mstr�X�֔ԍ�2 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �s���{��
    ' �X�R�[�v  : Public
    ' �������e  : �s���{�� �擾
    ' ��    �l  :
    ' �� �� �l  : �s���{��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �s���{��
    ' �X�R�[�v  : Public
    ' �������e  : �s���{�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �s���{��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �s���{��() As String
        Get

            �s���{�� = mstr�s���{��

        End Get
        Set(ByVal Value As String)

            mstr�s���{�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �s��S
    ' �X�R�[�v  : Public
    ' �������e  : �s��S �擾
    ' ��    �l  :
    ' �� �� �l  : �s��S
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �s��S
    ' �X�R�[�v  : Public
    ' �������e  : �s��S �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �s��S
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �s��S() As String
        Get

            �s��S = mstr�s��S

        End Get
        Set(ByVal Value As String)

            mstr�s��S = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����Ԓn
    ' �X�R�[�v  : Public
    ' �������e  : �����Ԓn �擾
    ' ��    �l  :
    ' �� �� �l  : �����Ԓn
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����Ԓn
    ' �X�R�[�v  : Public
    ' �������e  : �����Ԓn �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����Ԓn
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����Ԓn() As String
        Get

            �����Ԓn = mstr�����Ԓn

        End Get
        Set(ByVal Value As String)

            mstr�����Ԓn = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ����
    ' �X�R�[�v  : Public
    ' �������e  : ���� �擾
    ' ��    �l  :
    ' �� �� �l  : ����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ����
    ' �X�R�[�v  : Public
    ' �������e  : ���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ����() As String
        Get

            ���� = mstr����

        End Get
        Set(ByVal Value As String)

            mstr���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �d�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �d�b�ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �d�b�ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �d�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �d�b�ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �d�b�ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �d�b�ԍ�() As String
        Get

            �d�b�ԍ� = mstr�d�b�ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�d�b�ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g�ѓd�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �g�ѓd�b�ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �g�ѓd�b�ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g�ѓd�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �g�ѓd�b�ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g�ѓd�b�ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g�ѓd�b�ԍ�() As String
        Get

            �g�ѓd�b�ԍ� = mstr�g�ѓd�b�ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�g�ѓd�b�ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���[��
    ' �X�R�[�v  : Public
    ' �������e  : ���[�� �擾
    ' ��    �l  :
    ' �� �� �l  : ���[��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���[��
    ' �X�R�[�v  : Public
    ' �������e  : ���[�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���[��() As String
        Get

            ���[�� = mstr���[��

        End Get
        Set(ByVal Value As String)

            mstr���[�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g�у��[��
    ' �X�R�[�v  : Public
    ' �������e  : �g�у��[�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g�у��[��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g�у��[��
    ' �X�R�[�v  : Public
    ' �������e  : �g�у��[�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g�у��[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g�у��[��() As String
        Get

            �g�у��[�� = mstr�g�у��[��

        End Get
        Set(ByVal Value As String)

            mstr�g�у��[�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ƒ����ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �ƒ����ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �ƒ����ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ƒ����ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �ƒ����ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �ƒ����ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ƒ����ԍ�() As Short
        Get

            �ƒ����ԍ� = mint�ƒ����ԍ�

        End Get
        Set(ByVal Value As Short)

            mint�ƒ����ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���З\��N����
    ' �X�R�[�v  : Public
    ' �������e  : ���З\��N���� �擾
    ' ��    �l  :
    ' �� �� �l  : ���З\��N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���З\��N����
    ' �X�R�[�v  : Public
    ' �������e  : ���З\��N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���З\��N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���З\��N����() As String
        Get

            ���З\��N���� = mstr���З\��N����

        End Get
        Set(ByVal Value As String)

            mstr���З\��N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN����
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN���� �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN����
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN����() As String
        Get

            ���ДN���� = mstr���ДN����

        End Get
        Set(ByVal Value As String)

            mstr���ДN���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŐV�ٓ��N����
    ' �X�R�[�v  : Public
    ' �������e  : �ŐV�ٓ��N���� �擾
    ' ��    �l  :
    ' �� �� �l  : �ŐV�ٓ��N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŐV�ٓ��N����
    ' �X�R�[�v  : Public
    ' �������e  : �ŐV�ٓ��N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ŐV�ٓ��N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŐV�ٓ��N����() As String
        Get

            �ŐV�ٓ��N���� = mstr�ŐV�ٓ��N����

        End Get
        Set(ByVal Value As String)

            mstr�ŐV�ٓ��N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŐV�o���N����
    ' �X�R�[�v  : Public
    ' �������e  : �ŐV�o���N���� �擾
    ' ��    �l  :
    ' �� �� �l  : �ŐV�o���N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŐV�o���N����
    ' �X�R�[�v  : Public
    ' �������e  : �ŐV�o���N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ŐV�o���N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŐV�o���N����() As String
        Get

            �ŐV�o���N���� = mstr�ŐV�o���N����

        End Get
        Set(ByVal Value As String)

            mstr�ŐV�o���N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o���揊���R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �o���揊���R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �o���揊���R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o���揊���R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �o���揊���R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o���揊���R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o���揊���R�[�h() As String
        Get

            �o���揊���R�[�h = mstr�o���揊���R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�o���揊���R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ގЗ\���
    ' �X�R�[�v  : Public
    ' �������e  : �ގЗ\��� �擾
    ' ��    �l  :
    ' �� �� �l  : �ގЗ\���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ގЗ\���
    ' �X�R�[�v  : Public
    ' �������e  : �ގЗ\��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ގЗ\���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ގЗ\���() As String
        Get

            �ގЗ\��� = mstr�ގЗ\���

        End Get
        Set(ByVal Value As String)

            mstr�ގЗ\��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ގДN����
    ' �X�R�[�v  : Public
    ' �������e  : �ގДN���� �擾
    ' ��    �l  :
    ' �� �� �l  : �ގДN����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ގДN����
    ' �X�R�[�v  : Public
    ' �������e  : �ގДN���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ގДN����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ގДN����() As String
        Get

            �ގДN���� = mstr�ގДN����

        End Get
        Set(ByVal Value As String)

            mstr�ގДN���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�R�[�h() As String
        Get

            �ސE�R�[�h = mstr�ސE�R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�ސE�R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����敪
    ' �X�R�[�v  : Public
    ' �������e  : �����敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �����敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����敪
    ' �X�R�[�v  : Public
    ' �������e  : �����敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �����敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����敪() As Short
        Get

            �����敪 = mint�����敪

        End Get
        Set(ByVal Value As Short)

            mint�����敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����ΑӃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �����ΑӃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �����ΑӃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����ΑӃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �����ΑӃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����ΑӃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����ΑӃR�[�h() As String
        Get

            �����ΑӃR�[�h = mstr�����ΑӃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr�����ΑӃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �x���J�n��
    ' �X�R�[�v  : Public
    ' �������e  : �x���J�n�� �擾
    ' ��    �l  :
    ' �� �� �l  : �x���J�n��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �x���J�n��
    ' �X�R�[�v  : Public
    ' �������e  : �x���J�n�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �x���J�n��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �x���J�n��() As String
        Get

            �x���J�n�� = mstr�x���J�n��

        End Get
        Set(ByVal Value As String)

            mstr�x���J�n�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���A�\���
    ' �X�R�[�v  : Public
    ' �������e  : ���A�\��� �擾
    ' ��    �l  :
    ' �� �� �l  : ���A�\���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���A�\���
    ' �X�R�[�v  : Public
    ' �������e  : ���A�\��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���A�\���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���A�\���() As String
        Get

            ���A�\��� = mstr���A�\���

        End Get
        Set(ByVal Value As String)

            mstr���A�\��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���A�N����
    ' �X�R�[�v  : Public
    ' �������e  : ���A�N���� �擾
    ' ��    �l  :
    ' �� �� �l  : ���A�N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���A�N����
    ' �X�R�[�v  : Public
    ' �������e  : ���A�N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���A�N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���A�N����() As String
        Get

            ���A�N���� = mstr���A�N����

        End Get
        Set(ByVal Value As String)

            mstr���A�N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �}�C�J�[�ʋ΋敪
    ' �X�R�[�v  : Public
    ' �������e  : �}�C�J�[�ʋ΋敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �}�C�J�[�ʋ΋敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �}�C�J�[�ʋ΋敪
    ' �X�R�[�v  : Public
    ' �������e  : �}�C�J�[�ʋ΋敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �}�C�J�[�ʋ΋敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �}�C�J�[�ʋ΋敪() As Short
        Get

            �}�C�J�[�ʋ΋敪 = mint�}�C�J�[�ʋ΋敪

        End Get
        Set(ByVal Value As Short)

            mint�}�C�J�[�ʋ΋敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���N�ی��ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : ���N�ی��ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : ���N�ی��ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���N�ی��ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : ���N�ی��ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���N�ی��ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���N�ی��ԍ�() As String
        Get

            ���N�ی��ԍ� = mstr���N�ی��ԍ�

        End Get
        Set(ByVal Value As String)

            mstr���N�ی��ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����N���ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �����N���ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �����N���ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����N���ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �����N���ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����N���ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����N���ԍ�() As String
        Get

            �����N���ԍ� = mstr�����N���ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�����N���ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ٗp�ی��ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �ٗp�ی��ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �ٗp�ی��ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ٗp�ی��ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �ٗp�ی��ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ٗp�ی��ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ٗp�ی��ԍ�() As String
        Get

            �ٗp�ی��ԍ� = mstr�ٗp�ی��ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�ٗp�ی��ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ٗp�ی������L��
    ' �X�R�[�v  : Public
    ' �������e  : �ٗp�ی������L�� �擾
    ' ��    �l  :
    ' �� �� �l  : �ٗp�ی������L��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ٗp�ی������L��
    ' �X�R�[�v  : Public
    ' �������e  : �ٗp�ی������L�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �ٗp�ی������L��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ٗp�ی������L��() As Short
        Get

            �ٗp�ی������L�� = mint�ٗp�ی������L��

        End Get
        Set(ByVal Value As Short)

            mint�ٗp�ی������L�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŋ敪
    ' �X�R�[�v  : Public
    ' �������e  : �ŋ敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �ŋ敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŋ敪
    ' �X�R�[�v  : Public
    ' �������e  : �ŋ敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �ŋ敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŋ敪() As Short
        Get

            �ŋ敪 = mint�ŋ敪

        End Get
        Set(ByVal Value As Short)

            mint�ŋ敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �[����ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �[����ЃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �[����ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �[����ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �[����ЃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �[����ЃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �[����ЃR�[�h() As String
        Get

            �[����ЃR�[�h = mstr�[����ЃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr�[����ЃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �[����Ж�
    ' �X�R�[�v  : Public
    ' �������e  : �[����Ж� �擾
    ' ��    �l  :
    ' �� �� �l  : �[����Ж�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �[����Ж�
    ' �X�R�[�v  : Public
    ' �������e  : �[����Ж� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �[����Ж�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �[����Ж�() As String
        Get

            �[����Ж� = mstr�[����Ж�

        End Get
        Set(ByVal Value As String)

            mstr�[����Ж� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �[��������
    ' �X�R�[�v  : Public
    ' �������e  : �[�������� �擾
    ' ��    �l  :
    ' �� �� �l  : �[��������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �[��������
    ' �X�R�[�v  : Public
    ' �������e  : �[�������� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �[��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �[��������() As String
        Get

            �[�������� = mstr�[��������

        End Get
        Set(ByVal Value As String)

            mstr�[�������� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K����ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���K����ЃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ���K����ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K����ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���K����ЃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K����ЃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K����ЃR�[�h() As String
        Get

            ���K����ЃR�[�h = mstr���K����ЃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr���K����ЃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K����Ж�
    ' �X�R�[�v  : Public
    ' �������e  : ���K����Ж� �擾
    ' ��    �l  :
    ' �� �� �l  : ���K����Ж�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K����Ж�
    ' �X�R�[�v  : Public
    ' �������e  : ���K����Ж� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K����Ж�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K����Ж�() As String
        Get

            ���K����Ж� = mstr���K����Ж�

        End Get
        Set(ByVal Value As String)

            mstr���K����Ж� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K�������R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���K�������R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ���K�������R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K�������R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���K�������R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K�������R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K�������R�[�h() As String
        Get

            ���K�������R�[�h = mstr���K�������R�[�h

        End Get
        Set(ByVal Value As String)

            mstr���K�������R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K��������
    ' �X�R�[�v  : Public
    ' �������e  : ���K�������� �擾
    ' ��    �l  :
    ' �� �� �l  : ���K��������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K��������
    ' �X�R�[�v  : Public
    ' �������e  : ���K�������� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K��������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K��������() As String
        Get

            ���K�������� = mstr���K��������

        End Get
        Set(ByVal Value As String)

            mstr���K�������� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K�Z���^�[�����\���
    ' �X�R�[�v  : Public
    ' �������e  : ���K�Z���^�[�����\��� �擾
    ' ��    �l  :
    ' �� �� �l  : ���K�Z���^�[�����\���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K�Z���^�[�����\���
    ' �X�R�[�v  : Public
    ' �������e  : ���K�Z���^�[�����\��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K�Z���^�[�����\���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K�Z���^�[�����\���() As String
        Get

            ���K�Z���^�[�����\��� = mstr���K�Z���^�[�����\���

        End Get
        Set(ByVal Value As String)

            mstr���K�Z���^�[�����\��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K�Z���^�[������
    ' �X�R�[�v  : Public
    ' �������e  : ���K�Z���^�[������ �擾
    ' ��    �l  :
    ' �� �� �l  : ���K�Z���^�[������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K�Z���^�[������
    ' �X�R�[�v  : Public
    ' �������e  : ���K�Z���^�[������ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K�Z���^�[������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K�Z���^�[������() As String
        Get

            ���K�Z���^�[������ = mstr���K�Z���^�[������

        End Get
        Set(ByVal Value As String)

            mstr���K�Z���^�[������ = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K�敪
    ' �X�R�[�v  : Public
    ' �������e  : ���K�敪 �擾
    ' ��    �l  :
    ' �� �� �l  : ���K�敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K�敪
    ' �X�R�[�v  : Public
    ' �������e  : ���K�敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���K�敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K�敪() As Short
        Get

            ���K�敪 = mint���K�敪

        End Get
        Set(ByVal Value As Short)

            mint���K�敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �I�C���t
    ' �X�R�[�v  : Public
    ' �������e  : �I�C���t �擾
    ' ��    �l  :
    ' �� �� �l  : �I�C���t
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �I�C���t
    ' �X�R�[�v  : Public
    ' �������e  : �I�C���t �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �I�C���t
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �I�C���t() As String
        Get

            �I�C���t = mstr�I�C���t

        End Get
        Set(ByVal Value As String)

            mstr�I�C���t = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���K���Ɠ�
    ' �X�R�[�v  : Public
    ' �������e  : ���K���Ɠ� �擾
    ' ��    �l  :
    ' �� �� �l  : ���K���Ɠ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���K���Ɠ�
    ' �X�R�[�v  : Public
    ' �������e  : ���K���Ɠ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���K���Ɠ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���K���Ɠ�() As String
        Get

            ���K���Ɠ� = mstr���K���Ɠ�

        End Get
        Set(ByVal Value As String)

            mstr���K���Ɠ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����\��N����
    ' �X�R�[�v  : Public
    ' �������e  : �����\��N���� �擾
    ' ��    �l  :
    ' �� �� �l  : �����\��N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����\��N����
    ' �X�R�[�v  : Public
    ' �������e  : �����\��N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����\��N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����\��N����() As String
        Get

            �����\��N���� = mstr�����\��N����

        End Get
        Set(ByVal Value As String)

            mstr�����\��N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����N����
    ' �X�R�[�v  : Public
    ' �������e  : �����N���� �擾
    ' ��    �l  :
    ' �� �� �l  : �����N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����N����
    ' �X�R�[�v  : Public
    ' �������e  : �����N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����N����() As String
        Get

            �����N���� = mstr�����N����

        End Get
        Set(ByVal Value As String)

            mstr�����N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �v���[�gNO
    ' �X�R�[�v  : Public
    ' �������e  : �v���[�gNO �擾
    ' ��    �l  :
    ' �� �� �l  : �v���[�gNO
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �v���[�gNO
    ' �X�R�[�v  : Public
    ' �������e  : �v���[�gNO �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �v���[�gNO
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �v���[�gNO() As String
        Get

            �v���[�gNO = mstr�v���[�gNO

        End Get
        Set(ByVal Value As String)

            mstr�v���[�gNO = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �t�@�[�X�g
    ' �X�R�[�v  : Public
    ' �������e  : �t�@�[�X�g �擾
    ' ��    �l  :
    ' �� �� �l  : �t�@�[�X�g
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �t�@�[�X�g
    ' �X�R�[�v  : Public
    ' �������e  : �t�@�[�X�g �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �t�@�[�X�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �t�@�[�X�g() As Short
        Get

            �t�@�[�X�g = mint�t�@�[�X�g

        End Get
        Set(ByVal Value As Short)

            mint�t�@�[�X�g = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �t�@�[�X�g��
    ' �X�R�[�v  : Public
    ' �������e  : �t�@�[�X�g�� �擾
    ' ��    �l  :
    ' �� �� �l  : �t�@�[�X�g��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �t�@�[�X�g��
    ' �X�R�[�v  : Public
    ' �������e  : �t�@�[�X�g�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �t�@�[�X�g��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �t�@�[�X�g��() As String
        Get

            �t�@�[�X�g�� = mstr�t�@�[�X�g��

        End Get
        Set(ByVal Value As String)

            mstr�t�@�[�X�g�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �{���㖱�敪
    ' �X�R�[�v  : Public
    ' �������e  : �{���㖱�敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �{���㖱�敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �{���㖱�敪
    ' �X�R�[�v  : Public
    ' �������e  : �{���㖱�敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �{���㖱�敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �{���㖱�敪() As Short
        Get

            �{���㖱�敪 = mint�{���㖱�敪

        End Get
        Set(ByVal Value As Short)

            mint�{���㖱�敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �{���ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �{���ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �{���ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �{���ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �{���ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �{���ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �{���ԍ�() As String
        Get

            �{���ԍ� = mstr�{���ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�{���ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �{�����q�敪
    ' �X�R�[�v  : Public
    ' �������e  : �{�����q�敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �{�����q�敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �{�����q�敪
    ' �X�R�[�v  : Public
    ' �������e  : �{�����q�敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �{�����q�敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �{�����q�敪() As String
        Get

            �{�����q�敪 = mstr�{�����q�敪

        End Get
        Set(ByVal Value As String)

            mstr�{�����q�敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �{�����q�敪��
    ' �X�R�[�v  : Public
    ' �������e  : �{�����q�敪�� �擾
    ' ��    �l  :
    ' �� �� �l  : �{�����q�敪��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2013/01/25  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �{�����q�敪��
    ' �X�R�[�v  : Public
    ' �������e  : �{�����q�敪�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �{�����q�敪��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2013/01/25  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �{�����q�敪��() As String
        Get

            �{�����q�敪�� = mstr�{�����q�敪��

        End Get
        Set(ByVal Value As String)

            mstr�{�����q�敪�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �{���Ԏ�R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �{���Ԏ�R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �{���Ԏ�R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/01/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �{���Ԏ�R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �{���Ԏ�R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �{���Ԏ�R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/01/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �{���Ԏ�R�[�h() As String
        Get

            �{���Ԏ�R�[�h = mstr�{���Ԏ�R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�{���Ԏ�R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ������
    ' �X�R�[�v  : Public
    ' �������e  : ������ �擾
    ' ��    �l  :
    ' �� �� �l  : ������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ������
    ' �X�R�[�v  : Public
    ' �������e  : ������ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ������() As String
        Get

            ������ = mstr������

        End Get
        Set(ByVal Value As String)

            mstr������ = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���x�O���[�v
    ' �X�R�[�v  : Public
    ' �������e  : ���x�O���[�v �擾
    ' ��    �l  :
    ' �� �� �l  : ���x�O���[�v
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���x�O���[�v
    ' �X�R�[�v  : Public
    ' �������e  : ���x�O���[�v �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���x�O���[�v
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���x�O���[�v() As String
        Get

            ���x�O���[�v = mstr���x�O���[�v

        End Get
        Set(ByVal Value As String)

            mstr���x�O���[�v = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �V�t�g�敪
    ' �X�R�[�v  : Public
    ' �������e  : �V�t�g�敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �V�t�g�敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �V�t�g�敪
    ' �X�R�[�v  : Public
    ' �������e  : �V�t�g�敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �V�t�g�敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �V�t�g�敪() As String
        Get

            �V�t�g�敪 = mstr�V�t�g�敪

        End Get
        Set(ByVal Value As String)

            mstr�V�t�g�敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �J�[�h����
    ' �X�R�[�v  : Public
    ' �������e  : �J�[�h���� �擾
    ' ��    �l  :
    ' �� �� �l  : �J�[�h����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �J�[�h����
    ' �X�R�[�v  : Public
    ' �������e  : �J�[�h���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcurValue           Currency          I     �J�[�h����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �J�[�h����() As Decimal
        Get

            �J�[�h���� = mcur�J�[�h����

        End Get
        Set(ByVal Value As Decimal)

            mcur�J�[�h���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �J�[�h�p���`NO
    ' �X�R�[�v  : Public
    ' �������e  : �J�[�h�p���`NO �擾
    ' ��    �l  :
    ' �� �� �l  : �J�[�h�p���`NO
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �J�[�h�p���`NO
    ' �X�R�[�v  : Public
    ' �������e  : �J�[�h�p���`NO �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �J�[�h�p���`NO
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �J�[�h�p���`NO() As String
        Get

            �J�[�h�p���`NO = mstr�J�[�h�p���`NO

        End Get
        Set(ByVal Value As String)

            mstr�J�[�h�p���`NO = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ǒ��蓖�敪
    ' �X�R�[�v  : Public
    ' �������e  : �ǒ��蓖�敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �ǒ��蓖�敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ǒ��蓖�敪
    ' �X�R�[�v  : Public
    ' �������e  : �ǒ��蓖�敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �ǒ��蓖�敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ǒ��蓖�敪() As Short
        Get

            �ǒ��蓖�敪 = mint�ǒ��蓖�敪

        End Get
        Set(ByVal Value As Short)

            mint�ǒ��蓖�敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��Q�ғ���
    ' �X�R�[�v  : Public
    ' �������e  : ��Q�ғ��� �擾
    ' ��    �l  :
    ' �� �� �l  : ��Q�ғ���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��Q�ғ���
    ' �X�R�[�v  : Public
    ' �������e  : ��Q�ғ��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��Q�ғ���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��Q�ғ���() As String
        Get

            ��Q�ғ��� = mstr��Q�ғ���

        End Get
        Set(ByVal Value As String)

            mstr��Q�ғ��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��Q���
    ' �X�R�[�v  : Public
    ' �������e  : ��Q��� �擾
    ' ��    �l  :
    ' �� �� �l  : ��Q���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��Q���
    ' �X�R�[�v  : Public
    ' �������e  : ��Q��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��Q���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��Q���() As String
        Get

            ��Q��� = mstr��Q���

        End Get
        Set(ByVal Value As String)

            mstr��Q��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ό������N
    ' �X�R�[�v  : Public
    ' �������e  : �ό������N �擾
    ' ��    �l  :
    ' �� �� �l  : �ό������N
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ό������N
    ' �X�R�[�v  : Public
    ' �������e  : �ό������N �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �ό������N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ό������N() As Short
        Get

            �ό������N = mint�ό������N

        End Get
        Set(ByVal Value As Short)

            mint�ό������N = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ό������N�ύX��
    ' �X�R�[�v  : Public
    ' �������e  : �ό������N�ύX�� �擾
    ' ��    �l  :
    ' �� �� �l  : �ό������N�ύX��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ό������N�ύX��
    ' �X�R�[�v  : Public
    ' �������e  : �ό������N�ύX�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ό������N�ύX��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ό������N�ύX��() As String
        Get

            �ό������N�ύX�� = mstr�ό������N�ύX��

        End Get
        Set(ByVal Value As String)

            mstr�ό������N�ύX�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͉p��
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͉p�� �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͉p��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͉p��
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͉p�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͉p��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͉p��() As Short
        Get

            ��w�\�͉p�� = mint��w�\�͉p��

        End Get
        Set(ByVal Value As Short)

            mint��w�\�͉p�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͊؍���
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͊؍��� �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͊؍���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͊؍���
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͊؍��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͊؍���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͊؍���() As Short
        Get

            ��w�\�͊؍��� = mint��w�\�͊؍���

        End Get
        Set(ByVal Value As Short)

            mint��w�\�͊؍��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͓ƌ�
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͓ƌ� �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͓ƌ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͓ƌ�
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͓ƌ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͓ƌ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͓ƌ�() As Short
        Get

            ��w�\�͓ƌ� = mint��w�\�͓ƌ�

        End Get
        Set(ByVal Value As Short)

            mint��w�\�͓ƌ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͕���
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͕��� �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͕���
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͕���
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͕��� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͕���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͕���() As Short
        Get

            ��w�\�͕��� = mint��w�\�͕���

        End Get
        Set(ByVal Value As Short)

            mint��w�\�͕��� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͒�����
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͒����� �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͒�����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͒�����
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͒����� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͒�����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͒�����() As Short
        Get

            ��w�\�͒����� = mint��w�\�͒�����

        End Get
        Set(ByVal Value As Short)

            mint��w�\�͒����� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�1
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�1 �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͂��̑�1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�1
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͂��̑�1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͂��̑�1() As Short
        Get

            ��w�\�͂��̑�1 = maint��w�\�͂��̑�(1)

        End Get
        Set(ByVal Value As Short)

            maint��w�\�͂��̑�(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�2
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�2 �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͂��̑�2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�2
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͂��̑�2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͂��̑�2() As Short
        Get

            ��w�\�͂��̑�2 = maint��w�\�͂��̑�(2)

        End Get
        Set(ByVal Value As Short)

            maint��w�\�͂��̑�(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�3
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�3 �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͂��̑�3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�3
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͂��̑�3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͂��̑�3() As Short
        Get

            ��w�\�͂��̑�3 = maint��w�\�͂��̑�(3)

        End Get
        Set(ByVal Value As Short)

            maint��w�\�͂��̑�(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�4
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�4 �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͂��̑�4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�4
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͂��̑�4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͂��̑�4() As Short
        Get

            ��w�\�͂��̑�4 = maint��w�\�͂��̑�(4)

        End Get
        Set(ByVal Value As Short)

            maint��w�\�͂��̑�(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�5
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�5 �擾
    ' ��    �l  :
    ' �� �� �l  : ��w�\�͂��̑�5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��w�\�͂��̑�5
    ' �X�R�[�v  : Public
    ' �������e  : ��w�\�͂��̑�5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��w�\�͂��̑�5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��w�\�͂��̑�5() As Short
        Get

            ��w�\�͂��̑�5 = maint��w�\�͂��̑�(5)

        End Get
        Set(ByVal Value As Short)

            maint��w�\�͂��̑�(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���N����
    ' �X�R�[�v  : Public
    ' �������e  : ���N���� �擾
    ' ��    �l  :
    ' �� �� �l  : ���N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���N����
    ' �X�R�[�v  : Public
    ' �������e  : ���N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���N����() As String
        Get

            ���N���� = mstr���N����

        End Get
        Set(ByVal Value As String)

            mstr���N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �O�񌒐f�N���x
    ' �X�R�[�v  : Public
    ' �������e  : �O�񌒐f�N���x �擾
    ' ��    �l  :
    ' �� �� �l  : �O�񌒐f�N���x
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �O�񌒐f�N���x
    ' �X�R�[�v  : Public
    ' �������e  : �O�񌒐f�N���x �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �O�񌒐f�N���x
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �O�񌒐f�N���x() As String
        Get

            �O�񌒐f�N���x = mstr�O�񌒐f�N���x

        End Get
        Set(ByVal Value As String)

            mstr�O�񌒐f�N���x = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n1
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n1 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n1
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n1() As String
        Get

            �a��N���J�n1 = mastr�a��N���J�n(1)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n2
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n2 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n2
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n2() As String
        Get

            �a��N���J�n2 = mastr�a��N���J�n(2)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n3
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n3 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n3
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n3() As String
        Get

            �a��N���J�n3 = mastr�a��N���J�n(3)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n4
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n4 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n4
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n4() As String
        Get

            �a��N���J�n4 = mastr�a��N���J�n(4)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n5
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n5 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n5
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n5() As String
        Get

            �a��N���J�n5 = mastr�a��N���J�n(5)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n6
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n6 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n6
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n6() As String
        Get

            �a��N���J�n6 = mastr�a��N���J�n(6)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n7
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n7 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n7
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n7() As String
        Get

            �a��N���J�n7 = mastr�a��N���J�n(7)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n8
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n8 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n8
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n8() As String
        Get

            �a��N���J�n8 = mastr�a��N���J�n(8)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n9
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n9 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n9
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n9() As String
        Get

            �a��N���J�n9 = mastr�a��N���J�n(9)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n10
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n10 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���J�n10
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���J�n10
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���J�n10 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���J�n10
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���J�n10() As String
        Get

            �a��N���J�n10 = mastr�a��N���J�n(10)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���J�n(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��1
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��1 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��1
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��1() As String
        Get

            �a��N���I��1 = mastr�a��N���I��(1)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��2
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��2 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��2
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��2() As String
        Get

            �a��N���I��2 = mastr�a��N���I��(2)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��3
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��3 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��3
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��3() As String
        Get

            �a��N���I��3 = mastr�a��N���I��(3)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��4
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��4 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��4
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��4() As String
        Get

            �a��N���I��4 = mastr�a��N���I��(4)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��5
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��5 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��5
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��5() As String
        Get

            �a��N���I��5 = mastr�a��N���I��(5)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��6
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��6 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��6
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��6() As String
        Get

            �a��N���I��6 = mastr�a��N���I��(6)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��7
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��7 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��7
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��7() As String
        Get

            �a��N���I��7 = mastr�a��N���I��(7)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��8
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��8 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��8
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��8() As String
        Get

            �a��N���I��8 = mastr�a��N���I��(8)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��9
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��9 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��9
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��9() As String
        Get

            �a��N���I��9 = mastr�a��N���I��(9)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��N���I��10
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��10 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��N���I��10
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��N���I��10
    ' �X�R�[�v  : Public
    ' �������e  : �a��N���I��10 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��N���I��10
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��N���I��10() As String
        Get

            �a��N���I��10 = mastr�a��N���I��(10)

        End Get
        Set(ByVal Value As String)

            mastr�a��N���I��(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��1
    ' �X�R�[�v  : Public
    ' �������e  : �a��1 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��1
    ' �X�R�[�v  : Public
    ' �������e  : �a��1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��1() As String
        Get

            �a��1 = mastr�a��(1)

        End Get
        Set(ByVal Value As String)

            mastr�a��(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��2
    ' �X�R�[�v  : Public
    ' �������e  : �a��2 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��2
    ' �X�R�[�v  : Public
    ' �������e  : �a��2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��2() As String
        Get

            �a��2 = mastr�a��(2)

        End Get
        Set(ByVal Value As String)

            mastr�a��(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��3
    ' �X�R�[�v  : Public
    ' �������e  : �a��3 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��3
    ' �X�R�[�v  : Public
    ' �������e  : �a��3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��3() As String
        Get

            �a��3 = mastr�a��(3)

        End Get
        Set(ByVal Value As String)

            mastr�a��(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��4
    ' �X�R�[�v  : Public
    ' �������e  : �a��4 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��4
    ' �X�R�[�v  : Public
    ' �������e  : �a��4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��4() As String
        Get

            �a��4 = mastr�a��(4)

        End Get
        Set(ByVal Value As String)

            mastr�a��(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��5
    ' �X�R�[�v  : Public
    ' �������e  : �a��5 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��5
    ' �X�R�[�v  : Public
    ' �������e  : �a��5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��5() As String
        Get

            �a��5 = mastr�a��(5)

        End Get
        Set(ByVal Value As String)

            mastr�a��(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��6
    ' �X�R�[�v  : Public
    ' �������e  : �a��6 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��6
    ' �X�R�[�v  : Public
    ' �������e  : �a��6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��6() As String
        Get

            �a��6 = mastr�a��(6)

        End Get
        Set(ByVal Value As String)

            mastr�a��(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��7
    ' �X�R�[�v  : Public
    ' �������e  : �a��7 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��7
    ' �X�R�[�v  : Public
    ' �������e  : �a��7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��7() As String
        Get

            �a��7 = mastr�a��(7)

        End Get
        Set(ByVal Value As String)

            mastr�a��(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��8
    ' �X�R�[�v  : Public
    ' �������e  : �a��8 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��8
    ' �X�R�[�v  : Public
    ' �������e  : �a��8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��8() As String
        Get

            �a��8 = mastr�a��(8)

        End Get
        Set(ByVal Value As String)

            mastr�a��(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��9
    ' �X�R�[�v  : Public
    ' �������e  : �a��9 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��9
    ' �X�R�[�v  : Public
    ' �������e  : �a��9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��9() As String
        Get

            �a��9 = mastr�a��(9)

        End Get
        Set(ByVal Value As String)

            mastr�a��(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �a��10
    ' �X�R�[�v  : Public
    ' �������e  : �a��10 �擾
    ' ��    �l  :
    ' �� �� �l  : �a��10
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �a��10
    ' �X�R�[�v  : Public
    ' �������e  : �a��10 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �a��10
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �a��10() As String
        Get

            �a��10 = mastr�a��(10)

        End Get
        Set(ByVal Value As String)

            mastr�a��(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����1
    ' �X�R�[�v  : Public
    ' �������e  : ���L����1 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����1
    ' �X�R�[�v  : Public
    ' �������e  : ���L����1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����1() As String
        Get

            ���L����1 = mastr���L����(1)

        End Get
        Set(ByVal Value As String)

            mastr���L����(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����2
    ' �X�R�[�v  : Public
    ' �������e  : ���L����2 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����2
    ' �X�R�[�v  : Public
    ' �������e  : ���L����2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����2() As String
        Get

            ���L����2 = mastr���L����(2)

        End Get
        Set(ByVal Value As String)

            mastr���L����(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����3
    ' �X�R�[�v  : Public
    ' �������e  : ���L����3 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����3
    ' �X�R�[�v  : Public
    ' �������e  : ���L����3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����3() As String
        Get

            ���L����3 = mastr���L����(3)

        End Get
        Set(ByVal Value As String)

            mastr���L����(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����4
    ' �X�R�[�v  : Public
    ' �������e  : ���L����4 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����4
    ' �X�R�[�v  : Public
    ' �������e  : ���L����4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����4() As String
        Get

            ���L����4 = mastr���L����(4)

        End Get
        Set(ByVal Value As String)

            mastr���L����(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����5
    ' �X�R�[�v  : Public
    ' �������e  : ���L����5 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����5
    ' �X�R�[�v  : Public
    ' �������e  : ���L����5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����5() As String
        Get

            ���L����5 = mastr���L����(5)

        End Get
        Set(ByVal Value As String)

            mastr���L����(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����6
    ' �X�R�[�v  : Public
    ' �������e  : ���L����6 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����6
    ' �X�R�[�v  : Public
    ' �������e  : ���L����6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����6() As String
        Get

            ���L����6 = mastr���L����(6)

        End Get
        Set(ByVal Value As String)

            mastr���L����(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����7
    ' �X�R�[�v  : Public
    ' �������e  : ���L����7 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����7
    ' �X�R�[�v  : Public
    ' �������e  : ���L����7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����7() As String
        Get

            ���L����7 = mastr���L����(7)

        End Get
        Set(ByVal Value As String)

            mastr���L����(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����8
    ' �X�R�[�v  : Public
    ' �������e  : ���L����8 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����8
    ' �X�R�[�v  : Public
    ' �������e  : ���L����8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����8() As String
        Get

            ���L����8 = mastr���L����(8)

        End Get
        Set(ByVal Value As String)

            mastr���L����(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����9
    ' �X�R�[�v  : Public
    ' �������e  : ���L����9 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����9
    ' �X�R�[�v  : Public
    ' �������e  : ���L����9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����9() As String
        Get

            ���L����9 = mastr���L����(9)

        End Get
        Set(ByVal Value As String)

            mastr���L����(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���L����10
    ' �X�R�[�v  : Public
    ' �������e  : ���L����10 �擾
    ' ��    �l  :
    ' �� �� �l  : ���L����10
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���L����10
    ' �X�R�[�v  : Public
    ' �������e  : ���L����10 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���L����10
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���L����10() As String
        Get

            ���L����10 = mastr���L����(10)

        End Get
        Set(ByVal Value As String)

            mastr���L����(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �폜��
    ' �X�R�[�v  : Public
    ' �������e  : �폜�� �擾
    ' ��    �l  :
    ' �� �� �l  : �폜��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �폜��
    ' �X�R�[�v  : Public
    ' �������e  : �폜�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �폜��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �폜��() As String
        Get

            �폜�� = mstr�폜��

        End Get
        Set(ByVal Value As String)

            mstr�폜�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �斱���ؔ��s��
    ' �X�R�[�v  : Public
    ' �������e  : �斱���ؔ��s�� �擾
    ' ��    �l  :
    ' �� �� �l  : �斱���ؔ��s��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �斱���ؔ��s��
    ' �X�R�[�v  : Public
    ' �������e  : �斱���ؔ��s�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �斱���ؔ��s��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �斱���ؔ��s��() As String
        Get

            �斱���ؔ��s�� = mstr�斱���ؔ��s��

        End Get
        Set(ByVal Value As String)

            mstr�斱���ؔ��s�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �^�]�Ƌ��X�V��
    ' �X�R�[�v  : Public
    ' �������e  : �^�]�Ƌ��X�V�� �擾
    ' ��    �l  :
    ' �� �� �l  : �^�]�Ƌ��X�V��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �^�]�Ƌ��X�V��
    ' �X�R�[�v  : Public
    ' �������e  : �^�]�Ƌ��X�V�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �^�]�Ƌ��X�V��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �^�]�Ƌ��X�V��() As String
        Get

            �^�]�Ƌ��X�V�� = mstr�^�]�Ƌ��X�V��

        End Get
        Set(ByVal Value As String)

            mstr�^�]�Ƌ��X�V�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ؖ������s��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ؖ������s�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ؖ������s��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ؖ������s��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ؖ������s�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ؖ������s��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ؖ������s��() As String
        Get

            �g���ؖ������s�� = mstr�g���ؖ������s��

        End Get
        Set(ByVal Value As String)

            mstr�g���ؖ������s�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���̓����N
    ' �X�R�[�v  : Public
    ' �������e  : ���̓����N �擾
    ' ��    �l  :
    ' �� �� �l  : ���̓����N
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���̓����N
    ' �X�R�[�v  : Public
    ' �������e  : ���̓����N �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���̓����N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���̓����N() As Short
        Get

            ���̓����N = mint���̓����N

        End Get
        Set(ByVal Value As Short)

            mint���̓����N = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �p�X���[�h
    ' �X�R�[�v  : Public
    ' �������e  : �p�X���[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �p�X���[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �p�X���[�h
    ' �X�R�[�v  : Public
    ' �������e  : �p�X���[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �p�X���[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �p�X���[�h() As String
        Get

            �p�X���[�h = mstr�p�X���[�h

        End Get
        Set(ByVal Value As String)

            mstr�p�X���[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �{�Вn
    ' �X�R�[�v  : Public
    ' �������e  : �{�Вn �擾
    ' ��    �l  :
    ' �� �� �l  : �{�Вn
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �{�Вn
    ' �X�R�[�v  : Public
    ' �������e  : �{�Вn �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �{�Вn
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �{�Вn() As String
        Get

            �{�Вn = mstr�{�Вn

        End Get
        Set(ByVal Value As String)

            mstr�{�Вn = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o�g�n
    ' �X�R�[�v  : Public
    ' �������e  : �o�g�n �擾
    ' ��    �l  :
    ' �� �� �l  : �o�g�n
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o�g�n
    ' �X�R�[�v  : Public
    ' �������e  : �o�g�n �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o�g�n
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o�g�n() As String
        Get

            �o�g�n = mstr�o�g�n

        End Get
        Set(ByVal Value As String)

            mstr�o�g�n = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z��
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z�� �擾
    ' ��    �l  :
    ' �� �� �l  : �ŏI�w�Z��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z��
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ŏI�w�Z��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŏI�w�Z��() As String
        Get

            �ŏI�w�Z�� = mstr�ŏI�w�Z��

        End Get
        Set(ByVal Value As String)

            mstr�ŏI�w�Z�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z�w����
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z�w���� �擾
    ' ��    �l  :
    ' �� �� �l  : �ŏI�w�Z�w����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z�w����
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z�w���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ŏI�w�Z�w����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŏI�w�Z�w����() As String
        Get

            �ŏI�w�Z�w���� = mstr�ŏI�w�Z�w����

        End Get
        Set(ByVal Value As String)

            mstr�ŏI�w�Z�w���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z�w�Ȗ�
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z�w�Ȗ� �擾
    ' ��    �l  :
    ' �� �� �l  : �ŏI�w�Z�w�Ȗ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z�w�Ȗ�
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z�w�Ȗ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ŏI�w�Z�w�Ȗ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŏI�w�Z�w�Ȗ�() As String
        Get

            �ŏI�w�Z�w�Ȗ� = mstr�ŏI�w�Z�w�Ȗ�

        End Get
        Set(ByVal Value As String)

            mstr�ŏI�w�Z�w�Ȗ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŏI���ƔN�x
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI���ƔN�x �擾
    ' ��    �l  :
    ' �� �� �l  : �ŏI���ƔN�x
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŏI���ƔN�x
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI���ƔN�x �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ŏI���ƔN�x
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŏI���ƔN�x() As String
        Get

            �ŏI���ƔN�x = mstr�ŏI���ƔN�x

        End Get
        Set(ByVal Value As String)

            mstr�ŏI���ƔN�x = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z���Ƌ敪
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z���Ƌ敪 �擾
    ' ��    �l  :
    ' �� �� �l  : �ŏI�w�Z���Ƌ敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ŏI�w�Z���Ƌ敪
    ' �X�R�[�v  : Public
    ' �������e  : �ŏI�w�Z���Ƌ敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �ŏI�w�Z���Ƌ敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ŏI�w�Z���Ƌ敪() As Short
        Get

            �ŏI�w�Z���Ƌ敪 = mint�ŏI�w�Z���Ƌ敪

        End Get
        Set(ByVal Value As Short)

            mint�ŏI�w�Z���Ƌ敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �斱�o��
    ' �X�R�[�v  : Public
    ' �������e  : �斱�o�� �擾
    ' ��    �l  :
    ' �� �� �l  : �斱�o��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �斱�o��
    ' �X�R�[�v  : Public
    ' �������e  : �斱�o�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �斱�o��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �斱�o��() As Short
        Get

            �斱�o�� = mint�斱�o��

        End Get
        Set(ByVal Value As Short)

            mint�斱�o�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o���n
    ' �X�R�[�v  : Public
    ' �������e  : �o���n �擾
    ' ��    �l  :
    ' �� �� �l  : �o���n
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o���n
    ' �X�R�[�v  : Public
    ' �������e  : �o���n �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o���n
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o���n() As String
        Get

            �o���n = mstr�o���n

        End Get
        Set(ByVal Value As String)

            mstr�o���n = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o���N
    ' �X�R�[�v  : Public
    ' �������e  : �o���N �擾
    ' ��    �l  :
    ' �� �� �l  : �o���N
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o���N
    ' �X�R�[�v  : Public
    ' �������e  : �o���N �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o���N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o���N() As String
        Get

            �o���N = mstr�o���N

        End Get
        Set(ByVal Value As String)

            mstr�o���N = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o����
    ' �X�R�[�v  : Public
    ' �������e  : �o���� �擾
    ' ��    �l  :
    ' �� �� �l  : �o����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o����
    ' �X�R�[�v  : Public
    ' �������e  : �o���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o����() As String
        Get

            �o���� = mstr�o����

        End Get
        Set(ByVal Value As String)

            mstr�o���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾���i1
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i1 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾���i1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾���i1
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾���i1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾���i1() As String
        Get

            �擾���i1 = mastr�擾���i(1)

        End Get
        Set(ByVal Value As String)

            mastr�擾���i(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾���i2
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i2 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾���i2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾���i2
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾���i2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾���i2() As String
        Get

            �擾���i2 = mastr�擾���i(2)

        End Get
        Set(ByVal Value As String)

            mastr�擾���i(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾���i3
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i3 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾���i3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾���i3
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾���i3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾���i3() As String
        Get

            �擾���i3 = mastr�擾���i(3)

        End Get
        Set(ByVal Value As String)

            mastr�擾���i(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾���i4
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i4 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾���i4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾���i4
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾���i4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾���i4() As String
        Get

            �擾���i4 = mastr�擾���i(4)

        End Get
        Set(ByVal Value As String)

            mastr�擾���i(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾���i5
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i5 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾���i5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾���i5
    ' �X�R�[�v  : Public
    ' �������e  : �擾���i5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾���i5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾���i5() As String
        Get

            �擾���i5 = mastr�擾���i(5)

        End Get
        Set(ByVal Value As String)

            mastr�擾���i(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾�N��1
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��1 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾�N��1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾�N��1
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾�N��1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾�N��1() As String
        Get

            �擾�N��1 = mastr�擾�N��(1)

        End Get
        Set(ByVal Value As String)

            mastr�擾�N��(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾�N��2
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��2 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾�N��2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾�N��2
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾�N��2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾�N��2() As String
        Get

            �擾�N��2 = mastr�擾�N��(2)

        End Get
        Set(ByVal Value As String)

            mastr�擾�N��(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾�N��3
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��3 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾�N��3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾�N��3
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾�N��3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾�N��3() As String
        Get

            �擾�N��3 = mastr�擾�N��(3)

        End Get
        Set(ByVal Value As String)

            mastr�擾�N��(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾�N��4
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��4 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾�N��4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾�N��4
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾�N��4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾�N��4() As String
        Get

            �擾�N��4 = mastr�擾�N��(4)

        End Get
        Set(ByVal Value As String)

            mastr�擾�N��(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �擾�N��5
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��5 �擾
    ' ��    �l  :
    ' �� �� �l  : �擾�N��5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �擾�N��5
    ' �X�R�[�v  : Public
    ' �������e  : �擾�N��5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �擾�N��5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �擾�N��5() As String
        Get

            �擾�N��5 = mastr�擾�N��(5)

        End Get
        Set(ByVal Value As String)

            mastr�擾�N��(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��1
    ' �X�R�[�v  : Public
    ' �������e  : �E��1 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��1
    ' �X�R�[�v  : Public
    ' �������e  : �E��1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��1() As String
        Get

            �E��1 = mastr�E��(1)

        End Get
        Set(ByVal Value As String)

            mastr�E��(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��2
    ' �X�R�[�v  : Public
    ' �������e  : �E��2 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��2
    ' �X�R�[�v  : Public
    ' �������e  : �E��2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��2() As String
        Get

            �E��2 = mastr�E��(2)

        End Get
        Set(ByVal Value As String)

            mastr�E��(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��3
    ' �X�R�[�v  : Public
    ' �������e  : �E��3 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��3
    ' �X�R�[�v  : Public
    ' �������e  : �E��3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��3() As String
        Get

            �E��3 = mastr�E��(3)

        End Get
        Set(ByVal Value As String)

            mastr�E��(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��4
    ' �X�R�[�v  : Public
    ' �������e  : �E��4 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��4
    ' �X�R�[�v  : Public
    ' �������e  : �E��4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��4() As String
        Get

            �E��4 = mastr�E��(4)

        End Get
        Set(ByVal Value As String)

            mastr�E��(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��5
    ' �X�R�[�v  : Public
    ' �������e  : �E��5 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��5
    ' �X�R�[�v  : Public
    ' �������e  : �E��5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��5() As String
        Get

            �E��5 = mastr�E��(5)

        End Get
        Set(ByVal Value As String)

            mastr�E��(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��6
    ' �X�R�[�v  : Public
    ' �������e  : �E��6 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��6
    ' �X�R�[�v  : Public
    ' �������e  : �E��6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��6() As String
        Get

            �E��6 = mastr�E��(6)

        End Get
        Set(ByVal Value As String)

            mastr�E��(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��7
    ' �X�R�[�v  : Public
    ' �������e  : �E��7 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��7
    ' �X�R�[�v  : Public
    ' �������e  : �E��7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��7() As String
        Get

            �E��7 = mastr�E��(7)

        End Get
        Set(ByVal Value As String)

            mastr�E��(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��8
    ' �X�R�[�v  : Public
    ' �������e  : �E��8 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��8
    ' �X�R�[�v  : Public
    ' �������e  : �E��8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��8() As String
        Get

            �E��8 = mastr�E��(8)

        End Get
        Set(ByVal Value As String)

            mastr�E��(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E��9
    ' �X�R�[�v  : Public
    ' �������e  : �E��9 �擾
    ' ��    �l  :
    ' �� �� �l  : �E��9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E��9
    ' �X�R�[�v  : Public
    ' �������e  : �E��9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E��9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��9() As String
        Get

            �E��9 = mastr�E��(9)

        End Get
        Set(ByVal Value As String)

            mastr�E��(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �E���P�O
    ' �X�R�[�v  : Public
    ' �������e  : �E���P�O �擾
    ' ��    �l  :
    ' �� �� �l  : �E���P�O
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �E���P�O
    ' �X�R�[�v  : Public
    ' �������e  : �E���P�O �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �E���P�O
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �E��10() As String
        Get

            �E��10 = mastr�E��(10)

        End Get
        Set(ByVal Value As String)

            mastr�E��(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��1
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��1 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��1
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��1() As String
        Get

            ���ДN��1 = mastr���ДN��(1)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��2
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��2 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��2
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��2() As String
        Get

            ���ДN��2 = mastr���ДN��(2)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��3
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��3 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��3
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��3() As String
        Get

            ���ДN��3 = mastr���ДN��(3)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��4
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��4 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��4
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��4() As String
        Get

            ���ДN��4 = mastr���ДN��(4)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��5
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��5 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��5
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��5() As String
        Get

            ���ДN��5 = mastr���ДN��(5)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��6
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��6 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��6
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��6() As String
        Get

            ���ДN��6 = mastr���ДN��(6)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��7
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��7 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��7
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��7() As String
        Get

            ���ДN��7 = mastr���ДN��(7)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��8
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��8 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��8
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��8() As String
        Get

            ���ДN��8 = mastr���ДN��(8)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN��9
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��9 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN��9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN��9
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN��9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN��9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��9() As String
        Get

            ���ДN��9 = mastr���ДN��(9)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ДN���P�O
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN���P�O �擾
    ' ��    �l  :
    ' �� �� �l  : ���ДN���P�O
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ДN���P�O
    ' �X�R�[�v  : Public
    ' �������e  : ���ДN���P�O �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���ДN���P�O
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ДN��10() As String
        Get

            ���ДN��10 = mastr���ДN��(10)

        End Get
        Set(ByVal Value As String)

            mastr���ДN��(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��1
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��1 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��1
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��1() As String
        Get

            �ސE�N��1 = mastr�ސE�N��(1)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��2
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��2 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��2
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��2() As String
        Get

            �ސE�N��2 = mastr�ސE�N��(2)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��3
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��3 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��3
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��3() As String
        Get

            �ސE�N��3 = mastr�ސE�N��(3)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��4
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��4 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��4
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��4() As String
        Get

            �ސE�N��4 = mastr�ސE�N��(4)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��5
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��5 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��5
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��5() As String
        Get

            �ސE�N��5 = mastr�ސE�N��(5)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��6
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��6 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��6
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��6() As String
        Get

            �ސE�N��6 = mastr�ސE�N��(6)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��7
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��7 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��7
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��7() As String
        Get

            �ސE�N��7 = mastr�ސE�N��(7)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��8
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��8 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��8
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��8() As String
        Get

            �ސE�N��8 = mastr�ސE�N��(8)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N��9
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��9 �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N��9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N��9
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N��9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N��9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��9() As String
        Get

            �ސE�N��9 = mastr�ސE�N��(9)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ސE�N���P�O
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N���P�O �擾
    ' ��    �l  :
    ' �� �� �l  : �ސE�N���P�O
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ސE�N���P�O
    ' �X�R�[�v  : Public
    ' �������e  : �ސE�N���P�O �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ސE�N���P�O
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ސE�N��10() As String
        Get

            �ސE�N��10 = mastr�ސE�N��(10)

        End Get
        Set(ByVal Value As String)

            mastr�ސE�N��(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ����o�H
    ' �X�R�[�v  : Public
    ' �������e  : ����o�H �擾
    ' ��    �l  :
    ' �� �� �l  : ����o�H
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ����o�H
    ' �X�R�[�v  : Public
    ' �������e  : ����o�H �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ����o�H
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ����o�H() As String
        Get

            ����o�H = mstr����o�H

        End Get
        Set(ByVal Value As String)

            mstr����o�H = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �X�V�]�ƈ��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �X�V�]�ƈ��R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �X�V�]�ƈ��R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �X�V�]�ƈ��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �X�V�]�ƈ��R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �X�V�]�ƈ��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �X�V�]�ƈ��R�[�h() As String
        Get

            �X�V�]�ƈ��R�[�h = mstr�X�V�]�ƈ��R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�X�V�]�ƈ��R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �X�V���t����
    ' �X�R�[�v  : Public
    ' �������e  : �X�V���t���� �擾
    ' ��    �l  :
    ' �� �� �l  : �X�V���t����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �X�V���t����
    ' �X�R�[�v  : Public
    ' �������e  : �X�V���t���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pdteValue       Date              I     �X�V���t����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �X�V���t����() As Date
        Get

            �X�V���t���� = mdte�X�V���t����

        End Get
        Set(ByVal Value As Date)

            mdte�X�V���t���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���Ћ敪
    ' �X�R�[�v  : Public
    ' �������e  : ���Ћ敪 �擾
    ' ��    �l  :
    ' �� �� �l  : ���Ћ敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���Ћ敪
    ' �X�R�[�v  : Public
    ' �������e  : ���Ћ敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���Ћ敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���Ћ敪() As Short
        Get

            ���Ћ敪 = mint���Ћ敪

        End Get
        Set(ByVal Value As Short)

            mint���Ћ敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���Џ����R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���Џ����R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ���Џ����R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���Џ����R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���Џ����R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���Џ����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���Џ����R�[�h() As String
        Get

            ���Џ����R�[�h = mstr���Џ����R�[�h

        End Get
        Set(ByVal Value As String)

            mstr���Џ����R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ގЏ����R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �ގЏ����R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �ގЏ����R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ގЏ����R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �ގЏ����R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ގЏ����R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ގЏ����R�[�h() As String
        Get

            �ގЏ����R�[�h = mstr�ގЏ����R�[�h

        End Get
        Set(ByVal Value As String)

            mstr�ގЏ����R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o�^��
    ' �X�R�[�v  : Public
    ' �������e  : �o�^�� �擾
    ' ��    �l  :
    ' �� �� �l  : �o�^��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o�^��
    ' �X�R�[�v  : Public
    ' �������e  : �o�^�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o�^��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o�^��() As String
        Get

            �o�^�� = mstr�o�^��

        End Get
        Set(ByVal Value As String)

            mstr�o�^�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���ʎ蓖�敪
    ' �X�R�[�v  : Public
    ' �������e  : ���ʎ蓖�敪 �擾
    ' ��    �l  :
    ' �� �� �l  : ���ʎ蓖�敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���ʎ蓖�敪
    ' �X�R�[�v  : Public
    ' �������e  : ���ʎ蓖�敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���ʎ蓖�敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���ʎ蓖�敪() As Short
        Get

            ���ʎ蓖�敪 = mint���ʎ蓖�敪

        End Get
        Set(ByVal Value As Short)

            mint���ʎ蓖�敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �����N
    ' �X�R�[�v  : Public
    ' �������e  : �����N �擾
    ' ��    �l  :
    ' �� �� �l  : �����N
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �����N
    ' �X�R�[�v  : Public
    ' �������e  : �����N �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �����N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �����N() As String
        Get

            �����N = mstr�����N

        End Get
        Set(ByVal Value As String)

            mstr�����N = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���Ў����
    ' �X�R�[�v  : Public
    ' �������e  : ���Ў���� �擾
    ' ��    �l  :
    ' �� �� �l  : ���Ў����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���Ў����
    ' �X�R�[�v  : Public
    ' �������e  : ���Ў���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���Ў����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���Ў����() As String
        Get

            ���Ў���� = mstr���Ў����

        End Get
        Set(ByVal Value As String)

            mstr���Ў���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���Ɨp�ԗL���敪
    ' �X�R�[�v  : Public
    ' �������e  : ���Ɨp�ԗL���敪 �擾
    ' ��    �l  :
    ' �� �� �l  : ���Ɨp�ԗL���敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���Ɨp�ԗL���敪
    ' �X�R�[�v  : Public
    ' �������e  : ���Ɨp�ԗL���敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���Ɨp�ԗL���敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���Ɨp�ԗL���敪() As Short
        Get

            ���Ɨp�ԗL���敪 = mint���Ɨp�ԗL���敪

        End Get
        Set(ByVal Value As Short)

            mint���Ɨp�ԗL���敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���q�ی������敪
    ' �X�R�[�v  : Public
    ' �������e  : ���q�ی������敪 �擾
    ' ��    �l  :
    ' �� �� �l  : ���q�ی������敪
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���q�ی������敪
    ' �X�R�[�v  : Public
    ' �������e  : ���q�ی������敪 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ���q�ی������敪
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���q�ی������敪() As Short
        Get

            ���q�ی������敪 = mint���q�ی������敪

        End Get
        Set(ByVal Value As Short)

            mint���q�ی������敪 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ETC
    ' �X�R�[�v  : Public
    ' �������e  : ETC �擾
    ' ��    �l  :
    ' �� �� �l  : ETC
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ETC
    ' �X�R�[�v  : Public
    ' �������e  : ETC �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ETC
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ETC() As String
        Get

            ETC = mstrETC

        End Get
        Set(ByVal Value As String)

            mstrETC = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o�Ў��Ԓ�
    ' �X�R�[�v  : Public
    ' �������e  : �o�Ў��Ԓ� �擾
    ' ��    �l  :
    ' �� �� �l  : �o�Ў��Ԓ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o�Ў��Ԓ�
    ' �X�R�[�v  : Public
    ' �������e  : �o�Ў��Ԓ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o�Ў��Ԓ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o�Ў��Ԓ�() As String
        Get

            �o�Ў��Ԓ� = mstr�o�Ў��Ԓ�

        End Get
        Set(ByVal Value As String)

            mstr�o�Ў��Ԓ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o�Ў��Ԗ�
    ' �X�R�[�v  : Public
    ' �������e  : �o�Ў��Ԗ� �擾
    ' ��    �l  :
    ' �� �� �l  : �o�Ў��Ԗ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o�Ў��Ԗ�
    ' �X�R�[�v  : Public
    ' �������e  : �o�Ў��Ԗ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o�Ў��Ԗ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o�Ў��Ԗ�() As String
        Get

            �o�Ў��Ԗ� = mstr�o�Ў��Ԗ�

        End Get
        Set(ByVal Value As String)

            mstr�o�Ў��Ԗ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o�Ў��Ԋu��
    ' �X�R�[�v  : Public
    ' �������e  : �o�Ў��Ԋu�� �擾
    ' ��    �l  :
    ' �� �� �l  : �o�Ў��Ԋu��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o�Ў��Ԋu��
    ' �X�R�[�v  : Public
    ' �������e  : �o�Ў��Ԋu�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o�Ў��Ԋu��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o�Ў��Ԋu��() As String
        Get

            �o�Ў��Ԋu�� = mstr�o�Ў��Ԋu��

        End Get
        Set(ByVal Value As String)

            mstr�o�Ў��Ԋu�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ��ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ��ЃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��ЃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��ЃR�[�h() As String
        Get

            ��ЃR�[�h = mstr��ЃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr��ЃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��Ж�
    ' �X�R�[�v  : Public
    ' �������e  : ��Ж� �擾
    ' ��    �l  :
    ' �� �� �l  : ��Ж�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��Ж�
    ' �X�R�[�v  : Public
    ' �������e  : ��Ж� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��Ж�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��Ж�() As String
        Get

            ��Ж� = mstr��Ж�

        End Get
        Set(ByVal Value As String)

            mstr��Ж� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��Ж�����
    ' �X�R�[�v  : Public
    ' �������e  : ��Ж����� �擾
    ' ��    �l  :
    ' �� �� �l  : ��Ж�����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��Ж�����
    ' �X�R�[�v  : Public
    ' �������e  : ��Ж����� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��Ж�����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��Ж�����() As String
        Get

            ��Ж����� = mstr��Ж�����

        End Get
        Set(ByVal Value As String)

            mstr��Ж����� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���Ə��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���Ə��R�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ���Ə��R�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���Ə��R�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���Ə��R�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���Ə��R�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���Ə��R�[�h() As String
        Get

            ���Ə��R�[�h = mstr���Ə��R�[�h

        End Get
        Set(ByVal Value As String)

            mstr���Ə��R�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �_����Ԏ�
    ' �X�R�[�v  : Public
    ' �������e  : �_����Ԏ� �擾
    ' ��    �l  :
    ' �� �� �l  : �_����Ԏ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �_����Ԏ�
    ' �X�R�[�v  : Public
    ' �������e  : �_����Ԏ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �_����Ԏ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �_����Ԏ�() As String
        Get

            �_����Ԏ� = mstr�_����Ԏ�

        End Get
        Set(ByVal Value As String)

            mstr�_����Ԏ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �_����Ԏ�
    ' �X�R�[�v  : Public
    ' �������e  : �_����Ԏ� �擾
    ' ��    �l  :
    ' �� �� �l  : �_����Ԏ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �_����Ԏ�
    ' �X�R�[�v  : Public
    ' �������e  : �_����Ԏ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �_����Ԏ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �_����Ԏ�() As String
        Get

            �_����Ԏ� = mstr�_����Ԏ�

        End Get
        Set(ByVal Value As String)

            mstr�_����Ԏ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �o�����ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �o�����ЃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �o�����ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �o�����ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �o�����ЃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �o�����ЃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �o�����ЃR�[�h() As String
        Get

            �o�����ЃR�[�h = mstr�o�����ЃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr�o�����ЃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���Љ�ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���Љ�ЃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : ���Љ�ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���Љ�ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : ���Љ�ЃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���Љ�ЃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���Љ�ЃR�[�h() As String
        Get

            ���Љ�ЃR�[�h = mstr���Љ�ЃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr���Љ�ЃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �ގЉ�ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �ގЉ�ЃR�[�h �擾
    ' ��    �l  :
    ' �� �� �l  : �ގЉ�ЃR�[�h
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �ގЉ�ЃR�[�h
    ' �X�R�[�v  : Public
    ' �������e  : �ގЉ�ЃR�[�h �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �ގЉ�ЃR�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �ގЉ�ЃR�[�h() As String
        Get

            �ގЉ�ЃR�[�h = mstr�ގЉ�ЃR�[�h

        End Get
        Set(ByVal Value As String)

            mstr�ގЉ�ЃR�[�h = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ύ��Y����R�[�h�P
    ' �X�R�[�v  : Public
    ' �������e  : �Ύ��Y����R�[�h�P �擾
    ' ��    �l  :
    ' �� �� �l  : �Ύ��Y����R�[�h�P
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ύ��Y����R�[�h�P
    ' �X�R�[�v  : Public
    ' �������e  : �Ύ��Y����R�[�h�P �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �Ύ��Y����R�[�h�P
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Ύ��Y����R�[�h1() As String
        Get

            �Ύ��Y����R�[�h1 = mstr�Ύ��Y����R�[�h1

        End Get
        Set(ByVal Value As String)

            mstr�Ύ��Y����R�[�h1 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ύ��Y����R�[�h�Q
    ' �X�R�[�v  : Public
    ' �������e  : �Ύ��Y����R�[�h�Q �擾
    ' ��    �l  :
    ' �� �� �l  : �Ύ��Y����R�[�h�Q
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ύ��Y����R�[�h�Q
    ' �X�R�[�v  : Public
    ' �������e  : �Ύ��Y����R�[�h�Q �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �Ύ��Y����R�[�h�Q
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Ύ��Y����R�[�h2() As String
        Get

            �Ύ��Y����R�[�h2 = mstr�Ύ��Y����R�[�h2

        End Get
        Set(ByVal Value As String)

            mstr�Ύ��Y����R�[�h2 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ύ��Y����R�[�h�R
    ' �X�R�[�v  : Public
    ' �������e  : �Ύ��Y����R�[�h�R �擾
    ' ��    �l  :
    ' �� �� �l  : �Ύ��Y����R�[�h�R
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ύ��Y����R�[�h�R
    ' �X�R�[�v  : Public
    ' �������e  : �Ύ��Y����R�[�h�R �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �Ύ��Y����R�[�h�R
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Ύ��Y����R�[�h3() As String
        Get

            �Ύ��Y����R�[�h3 = mstr�Ύ��Y����R�[�h3

        End Get
        Set(ByVal Value As String)

            mstr�Ύ��Y����R�[�h3 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �O��X�V�Җ�
    ' �X�R�[�v  : Public
    ' �������e  : �O��X�V�Җ� �擾
    ' ��    �l  :
    ' �� �� �l  : �O��X�V�Җ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �O��X�V�Җ�
    ' �X�R�[�v  : Public
    ' �������e  : �O��X�V�Җ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �O��X�V�Җ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �O��X�V�Җ�() As String
        Get

            �O��X�V�Җ� = mstr�O��X�V�Җ�

        End Get
        Set(ByVal Value As String)

            mstr�O��X�V�Җ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �O��X�V����
    ' �X�R�[�v  : Public
    ' �������e  : �O��X�V���� �擾
    ' ��    �l  :
    ' �� �� �l  : �O��X�V����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �O��X�V����
    ' �X�R�[�v  : Public
    ' �������e  : �O��X�V���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �O��X�V����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �O��X�V����() As String
        Get

            �O��X�V���� = mstr�O��X�V����

        End Get
        Set(ByVal Value As String)

            mstr�O��X�V���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �L���c����
    ' �X�R�[�v  : Public
    ' �������e  : �L���c���� �擾
    ' ��    �l  :
    ' �� �� �l  : �L���c����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/02  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �L���c����
    ' �X�R�[�v  : Public
    ' �������e  : �L���c���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pcurValue           Currency          I     �L���c����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/02  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �L���c����() As Decimal
        Get

            �L���c���� = mcur�L���c����

        End Get
        Set(ByVal Value As Decimal)

            mcur�L���c���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��퍇�i��
    ' �X�R�[�v  : Public
    ' �������e  : ��퍇�i�� �擾
    ' ��    �l  :
    ' �� �� �l  : ��퍇�i��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��퍇�i��
    ' �X�R�[�v  : Public
    ' �������e  : ��퍇�i�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��퍇�i��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��퍇�i��() As String
        Get

            ��퍇�i�� = mstr��퍇�i��

        End Get
        Set(ByVal Value As String)

            mstr��퍇�i�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Ƌ����
    ' �X�R�[�v  : Public
    ' �������e  : �Ƌ���� �擾
    ' ��    �l  :
    ' �� �� �l  : �Ƌ����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Ƌ����
    ' �X�R�[�v  : Public
    ' �������e  : �Ƌ���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �Ƌ����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Ƌ����() As String
        Get

            �Ƌ���� = mstr�Ƌ����

        End Get
        Set(ByVal Value As String)

            mstr�Ƌ���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��Е��S�t���O
    ' �X�R�[�v  : Public
    ' �������e  : ��Е��S�t���O �擾
    ' ��    �l  :
    ' �� �� �l  : ��Е��S�t���O
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/06/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��Е��S�t���O
    ' �X�R�[�v  : Public
    ' �������e  : ��Е��S�t���O �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��Е��S�t���O
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/06/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��Е��S�t���O() As Short
        Get

            ��Е��S�t���O = mint��Е��S�t���O

        End Get
        Set(ByVal Value As Short)

            mint��Е��S�t���O = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �Г��l�^�N�V�[�Ώێ�
    ' �X�R�[�v  : Public
    ' �������e  : �Г��l�^�N�V�[�Ώێ� �擾
    ' ��    �l  :
    ' �� �� �l  : �Г��l�^�N�V�[�Ώێ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �Г��l�^�N�V�[�Ώێ�
    ' �X�R�[�v  : Public
    ' �������e  : �Г��l�^�N�V�[�Ώێ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �Г��l�^�N�V�[�Ώێ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �Г��l�^�N�V�[�Ώێ�() As Short
        Get

            �Г��l�^�N�V�[�Ώێ� = mint�Г��l�^�N�V�[�Ώێ�

        End Get
        Set(ByVal Value As Short)

            mint�Г��l�^�N�V�[�Ώێ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��ԎO�l���Ώێ�
    ' �X�R�[�v  : Public
    ' �������e  : ��ԎO�l���Ώێ� �擾
    ' ��    �l  :
    ' �� �� �l  : ��ԎO�l���Ώێ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��ԎO�l���Ώێ�
    ' �X�R�[�v  : Public
    ' �������e  : ��ԎO�l���Ώێ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��ԎO�l���Ώێ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��ԎO�l���Ώێ�() As Short
        Get

            ��ԎO�l���Ώێ� = mint��ԎO�l���Ώێ�

        End Get
        Set(ByVal Value As Short)

            mint��ԎO�l���Ώێ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�X�֔ԍ��P
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�X�֔ԍ��P �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�X�֔ԍ��P
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�X�֔ԍ��P
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�X�֔ԍ��P �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�X�֔ԍ��P
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�X�֔ԍ�1() As String
        Get

            �A�Ȑ�X�֔ԍ�1 = mstr�A�Ȑ�X�֔ԍ�1

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�X�֔ԍ�1 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�X�֔ԍ��Q
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�X�֔ԍ��Q �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�X�֔ԍ��Q
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�X�֔ԍ��Q
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�X�֔ԍ��Q �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�X�֔ԍ��Q
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�X�֔ԍ�2() As String
        Get

            �A�Ȑ�X�֔ԍ�2 = mstr�A�Ȑ�X�֔ԍ�2

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�X�֔ԍ�2 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�s���{��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�s���{�� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�s���{��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�s���{��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�s���{�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�s���{��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�s���{��() As String
        Get

            �A�Ȑ�s���{�� = mstr�A�Ȑ�s���{��

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�s���{�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�s��S
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�s��S �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�s��S
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�s��S
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�s��S �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�s��S
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�s��S() As String
        Get

            �A�Ȑ�s��S = mstr�A�Ȑ�s��S

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�s��S = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ撬���Ԓn
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ撬���Ԓn �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ撬���Ԓn
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ撬���Ԓn
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ撬���Ԓn �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ撬���Ԓn
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ撬���Ԓn() As String
        Get

            �A�Ȑ撬���Ԓn = mstr�A�Ȑ撬���Ԓn

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ撬���Ԓn = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ捆��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ捆�� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ捆��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ捆��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ捆�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ捆��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ捆��() As String
        Get

            �A�Ȑ捆�� = mstr�A�Ȑ捆��

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ捆�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�d�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�d�b�ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�d�b�ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�d�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�d�b�ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�d�b�ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�d�b�ԍ�() As String
        Get

            �A�Ȑ�d�b�ԍ� = mstr�A�Ȑ�d�b�ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�d�b�ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�g�ѓd�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�g�ѓd�b�ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�g�ѓd�b�ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�g�ѓd�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�g�ѓd�b�ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�g�ѓd�b�ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�g�ѓd�b�ԍ�() As String
        Get

            �A�Ȑ�g�ѓd�b�ԍ� = mstr�A�Ȑ�g�ѓd�b�ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�g�ѓd�b�ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ惁�[��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ惁�[�� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ惁�[��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ惁�[��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ惁�[�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ惁�[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ惁�[��() As String
        Get

            �A�Ȑ惁�[�� = mstr�A�Ȑ惁�[��

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ惁�[�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�g�у��[��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�g�у��[�� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ�g�у��[��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ�g�у��[��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ�g�у��[�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ�g�у��[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ�g�у��[��() As String
        Get

            �A�Ȑ�g�у��[�� = mstr�A�Ȑ�g�у��[��

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ�g�у��[�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ掁��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ掁�� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ掁��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ掁��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ掁�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ掁��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ掁��() As String
        Get

            �A�Ȑ掁�� = mstr�A�Ȑ掁��

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ掁�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ摱��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ摱�� �擾
    ' ��    �l  :
    ' �� �� �l  : �A�Ȑ摱��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �A�Ȑ摱��
    ' �X�R�[�v  : Public
    ' �������e  : �A�Ȑ摱�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �A�Ȑ摱��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �A�Ȑ摱��() As String
        Get

            �A�Ȑ摱�� = mstr�A�Ȑ摱��

        End Get
        Set(ByVal Value As String)

            mstr�A�Ȑ摱�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl������
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl������ �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl������
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl������ �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl������() As String
        Get

            �g���ۏؐl������ = mstr�g���ۏؐl������

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl������ = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl���J�i
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���J�i �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl���J�i
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl���J�i
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���J�i �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl���J�i
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl���J�i() As String
        Get

            �g���ۏؐl���J�i = mstr�g���ۏؐl���J�i

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl���J�i = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     �g���ۏؐl����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl����() As Short
        Get

            �g���ۏؐl���� = mint�g���ۏؐl����

        End Get
        Set(ByVal Value As Short)

            mint�g���ۏؐl���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl���N����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���N���� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl���N����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl���N����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���N���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl���N����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl���N����() As String
        Get

            �g���ۏؐl���N���� = mstr�g���ۏؐl���N����

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl���N���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�o�^��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�o�^�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�o�^��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�o�^��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�o�^�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�o�^��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�o�^��() As String
        Get

            �g���ۏؐl�o�^�� = mstr�g���ۏؐl�o�^��

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�o�^�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�E��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�E�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�E��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�E��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�E�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�E��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�E��() As String
        Get

            �g���ۏؐl�E�� = mstr�g���ۏؐl�E��

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�E�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl����() As String
        Get

            �g���ۏؐl���� = mstr�g���ۏؐl����

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�X�֔ԍ��P
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�X�֔ԍ��P �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�X�֔ԍ��P
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�X�֔ԍ��P
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�X�֔ԍ��P �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�X�֔ԍ��P
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�X�֔ԍ�1() As String
        Get

            �g���ۏؐl�X�֔ԍ�1 = mstr�g���ۏؐl�X�֔ԍ�1

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�X�֔ԍ�1 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�X�֔ԍ��Q
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�X�֔ԍ��Q �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�X�֔ԍ��Q
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�X�֔ԍ��Q
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�X�֔ԍ��Q �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�X�֔ԍ��Q
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�X�֔ԍ�2() As String
        Get

            �g���ۏؐl�X�֔ԍ�2 = mstr�g���ۏؐl�X�֔ԍ�2

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�X�֔ԍ�2 = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�s���{��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�s���{�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�s���{��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�s���{��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�s���{�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�s���{��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�s���{��() As String
        Get

            �g���ۏؐl�s���{�� = mstr�g���ۏؐl�s���{��

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�s���{�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�s��S
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�s��S �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�s��S
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�s��S
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�s��S �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�s��S
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�s��S() As String
        Get

            �g���ۏؐl�s��S = mstr�g���ۏؐl�s��S

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�s��S = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�����Ԓn
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�����Ԓn �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�����Ԓn
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�����Ԓn
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�����Ԓn �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�����Ԓn
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�����Ԓn() As String
        Get

            �g���ۏؐl�����Ԓn = mstr�g���ۏؐl�����Ԓn

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�����Ԓn = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl����
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl����
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl����
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl����() As String
        Get

            �g���ۏؐl���� = mstr�g���ۏؐl����

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl���� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�d�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�d�b�ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�d�b�ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�d�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�d�b�ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�d�b�ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�d�b�ԍ�() As String
        Get

            �g���ۏؐl�d�b�ԍ� = mstr�g���ۏؐl�d�b�ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�d�b�ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�g�ѓd�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�g�ѓd�b�ԍ� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�g�ѓd�b�ԍ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�g�ѓd�b�ԍ�
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�g�ѓd�b�ԍ� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�g�ѓd�b�ԍ�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�g�ѓd�b�ԍ�() As String
        Get

            �g���ۏؐl�g�ѓd�b�ԍ� = mstr�g���ۏؐl�g�ѓd�b�ԍ�

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�g�ѓd�b�ԍ� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl���[��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���[�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl���[��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl���[��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl���[�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl���[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl���[��() As String
        Get

            �g���ۏؐl���[�� = mstr�g���ۏؐl���[��

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl���[�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�g�у��[��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�g�у��[�� �擾
    ' ��    �l  :
    ' �� �� �l  : �g���ۏؐl�g�у��[��
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : �g���ۏؐl�g�у��[��
    ' �X�R�[�v  : Public
    ' �������e  : �g���ۏؐl�g�у��[�� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     �g���ۏؐl�g�у��[��
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property �g���ۏؐl�g�у��[��() As String
        Get

            �g���ۏؐl�g�у��[�� = mstr�g���ۏؐl�g�у��[��

        End Get
        Set(ByVal Value As String)

            mstr�g���ۏؐl�g�у��[�� = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��L���X�|�[�c
    ' �X�R�[�v  : Public
    ' �������e  : ��L���X�|�[�c �擾
    ' ��    �l  :
    ' �� �� �l  : ��L���X�|�[�c
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��L���X�|�[�c
    ' �X�R�[�v  : Public
    ' �������e  : ��L���X�|�[�c �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��L���X�|�[�c
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��L���X�|�[�c() As Short
        Get

            ��L���X�|�[�c = mint��L���X�|�[�c

        End Get
        Set(ByVal Value As Short)

            mint��L���X�|�[�c = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c1
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c1 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c1
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c1() As String
        Get

            ��X�|�[�c1 = mastr��X�|�[�c(1)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c2
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c2 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c2
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c2() As String
        Get

            ��X�|�[�c2 = mastr��X�|�[�c(2)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c3
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c3 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c3
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c3() As String
        Get

            ��X�|�[�c3 = mastr��X�|�[�c(3)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c4
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c4 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c4
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/14  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c4() As String
        Get

            ��X�|�[�c4 = mastr��X�|�[�c(4)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��L���X�|�[�c�ȊO
    ' �X�R�[�v  : Public
    ' �������e  : ��L���X�|�[�c�ȊO �擾
    ' ��    �l  :
    ' �� �� �l  : ��L���X�|�[�c�ȊO
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��L���X�|�[�c�ȊO
    ' �X�R�[�v  : Public
    ' �������e  : ��L���X�|�[�c�ȊO �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ��L���X�|�[�c�ȊO
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��L���X�|�[�c�ȊO() As Short
        Get

            ��L���X�|�[�c�ȊO = mint��L���X�|�[�c�ȊO

        End Get
        Set(ByVal Value As Short)

            mint��L���X�|�[�c�ȊO = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO1
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO1 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO1
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO1
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO1 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO1
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO1() As String
        Get

            ��X�|�[�c�ȊO1 = mastr��X�|�[�c�ȊO(1)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO2
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO2 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO2
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO2
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO2 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO2
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO2() As String
        Get

            ��X�|�[�c�ȊO2 = mastr��X�|�[�c�ȊO(2)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO3
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO3 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO3
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO3
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO3 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO3
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO3() As String
        Get

            ��X�|�[�c�ȊO3 = mastr��X�|�[�c�ȊO(3)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO4
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO4 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO4
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO4
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO4 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO4
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO4() As String
        Get

            ��X�|�[�c�ȊO4 = mastr��X�|�[�c�ȊO(4)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO5
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO5 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO5
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO5
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO5 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO5
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO5() As String
        Get

            ��X�|�[�c�ȊO5 = mastr��X�|�[�c�ȊO(5)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO6
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO6 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO6
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO6
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO6 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO6
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO6() As String
        Get

            ��X�|�[�c�ȊO6 = mastr��X�|�[�c�ȊO(6)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO7
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO7 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO7
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO7
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO7 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO7
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO7() As String
        Get

            ��X�|�[�c�ȊO7 = mastr��X�|�[�c�ȊO(7)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO8
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO8 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO8
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO8
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO8 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO8
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO8() As String
        Get

            ��X�|�[�c�ȊO8 = mastr��X�|�[�c�ȊO(8)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO9
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO9 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO9
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO9
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO9 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO9
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO9() As String
        Get

            ��X�|�[�c�ȊO9 = mastr��X�|�[�c�ȊO(9)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO10
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO10 �擾
    ' ��    �l  :
    ' �� �� �l  : ��X�|�[�c�ȊO10
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ��X�|�[�c�ȊO10
    ' �X�R�[�v  : Public
    ' �������e  : ��X�|�[�c�ȊO10 �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ��X�|�[�c�ȊO10
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ��X�|�[�c�ȊO10() As String
        Get

            ��X�|�[�c�ȊO10 = mastr��X�|�[�c�ȊO(10)

        End Get
        Set(ByVal Value As String)

            mastr��X�|�[�c�ȊO(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' �� �� ��  : ���l
    ' �X�R�[�v  : Public
    ' �������e  : ���l �擾
    ' ��    �l  :
    ' �� �� �l  : ���l
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '******************************************************************************
    ' �� �� ��  : ���l
    ' �X�R�[�v  : Public
    ' �������e  : ���l �ݒ�
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ���l
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Property ���l() As String
        Get

            ���l = mstr���l

        End Get
        Set(ByVal Value As String)

            mstr���l = Value

        End Set
    End Property
End Class
