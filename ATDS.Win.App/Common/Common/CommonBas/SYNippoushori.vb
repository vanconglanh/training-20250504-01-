Option Strict Off
Option Explicit On
Module basSYNippoushori
    '******************************************************************************
    ' ��ۼު�Ė�  : ���q�Ǘ��V�X�e��
    ' �t�@�C����  : basSYNippoushori.bas
    ' ��    �e    : ����m�莞�Ɏ��q�Ǘ��̏������s��
    ' ��    �l    : HEB110��ALB120����g�p�����
    ' �֐��ꗗ    : <Public>
    '                   gsubUpdateCarTransfer           (����m�莞�̎��q�̃��C������)
    '                   gfncOldChangeDate               (�Ώە����ŋΖ��\����͊m�菈�����I�����Ă��邩�ǂ����̃`�F�b�N����)
    '               <Private>
    '                   msubUpdate����                  (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑��ԏ���)
    '                   msubUpdate����                  (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̌��ԏ���)
    '                   msubUpdate���                  (��֏����̃��C������)
    '                   msubUpdate���1                 (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���)
    '                   msubUpdate���2                 (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���)
    '                   msubUpdate���3                 (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���)
    '                   msubUpdate���4                 (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���)
    '                   msubUpdate�c�Ə���              (�c�Ə��Ԉړ��̃��C������)
    '                   msubUpdate�c�Ə���1             (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉c�Ə��ړ�����)
    '                   msubUpdate�c�Ə���2             (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉c�Ə��ړ�����)
    '                   msubUpdate��ЊԌ���            (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉�ЊԈړ����ԏ���)
    '                   msubUpdate��Њԑ���            (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉�ЊԈړ����ԏ���)
    '                   msubUpdate�Зp�Ԑؑ�            (���q�}�X�^�̎Зp�Ԑؑ֏���)
    '                   msubUpdate�p��                  (���q�}�X�^�̔p�Ԑؑ֏���)
    '                   msubUpdate���p                  (���q�}�X�^�̔��p�ؑ֏���)
    '                   msubUpdate�ۗ��Ԑؑ�            (���q�}�X�^�̎Зp�Ԃ�ۗ��ɐؑ֏���)
    '                   msubUpdate�ۗ�����              (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�ۗ̕����ԏ���)
    '                   msubUpdate�}�X�^�����e          (�c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̒��ڃ����e����)
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   1.0.0       2009/09/04  �j�r�q             �V�K�쐬
    '   1.0.2       2009/09/30  �j�r�q             ���ʃ��W���[���t�@�C�����ρE���\�b�h���C��
    '   1.0.3       2009/09/30  �j�r�q             ��ւ̍X�V���ɁA��֌��̎��q�ɋ����q�ԍ����X�V���Ă����悤�ɂ���
    '   1.0.4       2009/10/06  �j�r�q             ��ւŎ��q�ԍ����ύX���ꂽ�ꍇ�ɉc�Ǝ��q�̔p�ԓ��ɐؑ֓���]������B
    '                                              �����q�}�X�^�X�V���̂�
    '   1.0.5       2010/03/09  �j�r�q             gsubUpdateCarTransfer�̎w�����e�敪='11'(�ۗ�����)���̔�����@�̕s��Ή�
    '   1.0.6       2010/03/24  �j�r�q             msubUpdate���ԂɍŏI�����ԍ���]�����鏈����ǉ�
    '   1.0.7       2010/05/31  �j�r�q             �{���җ����e�[�u���Ɏ��q�}�X�^���f�敪��ǉ����āA��ԏ������ɂ��̋敪������q�}�X�^�ɖ{���҂�]������悤�ɕύX����
    '   1.0.8       2010/09/24  �j�r�q             �{���җ����e�[�u��������q�}�X�^�ɖ{���҂𔽉f������ۂɁA�ؑ֓��̏����ɏ������s���悤�ɂ���
    '                           �j�r�q             �Ζ��\����͊m�菈�����I�����Ă��邩�ǂ����̃`�F�b�N�����̒ǉ�
    '******************************************************************************

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    Private Structure ���q���
        Dim m�ԑ̔ԍ� As String
        Dim m�w�����e�敪 As String
        Dim m���q�ԍ��n��R�[�h As String
        Dim m���q�ԍ�1 As String
        Dim m���q�ԍ�2 As String
        Dim m���q�ԍ�3 As String
        Dim m�Ԗ� As String
        Dim m�N�� As String
        Dim m�G���W���^�� As String
        Dim m�^�� As String
        Dim m�敪 As String
        Dim m���q�敪 As String
        Dim m�R���R�[�h As String
        Dim m�t�@�[�X�g As String
        Dim m�o�^�N���� As String
        Dim m���q�{�̉��i As String
        Dim m�擾�� As String
        Dim m�G�A�R�����i As String
        Dim m�������[�^�[���i As String
        Dim m�^�R���[�^�[���i As String
        Dim m���̑���p As String
        Dim m��ԋ敪 As String
        Dim m�����R�[�h As String
        Dim m���q�o�^�����R�[�h As String
        Dim m�����ԍ� As String
        Dim m�{���҃R�[�h1 As String
        Dim m���p���z1 As String
        Dim m���p����1 As String
        Dim m���p�݌v�z1 As String
        Dim mAT���p��1 As String
        Dim m���p�c����1 As String
        Dim m�{���҃R�[�h2 As String
        Dim m���p���z2 As String
        Dim m���p����2 As String
        Dim m���p�݌v�z2 As String
        Dim mAT���p��2 As String
        Dim m���p�c����2 As String
        Dim m���p���z As String
        Dim m�d�b�ԍ� As String
        Dim m�����ԍ� As String
        Dim m�ی���� As String '// ���q�}�X�^�̓R�[�h
        Dim m�ی���Ж� As String '// 2010/03/26 �c�Ǝ��q�}�X�^���ꍀ�ڂŖ��̂ł����Ă��邽��
        Dim m�����ԕی������� As String
        Dim m�ی��\���Җ����� As String
        Dim m�ی��\���Җ��J�i As String
        Dim m�ی��\���җX�֔ԍ�1 As String
        Dim m�ی��\���җX�֔ԍ�2 As String
        Dim m�ی��\���ғs���{������ As String
        Dim m�ی��\���Ҏs��S���� As String
        Dim m�ی��\���Ғ����Ԓn���� As String
        Dim m�ی��\���ҍ������� As String
        Dim m�ی��\���ғs���{���J�i As String
        Dim m�ی��\���Ҏs��S�J�i As String
        Dim m�ی��\���Ғ����Ԓn�J�i As String
        Dim m�ی��\���ҍ����J�i As String
        Dim m�������_���� As String
        Dim m����Ԍ��� As String
        Dim m��֗\��� As String
        Dim m�c�Ə��o�ɓ� As String
        Dim m�������ɓ� As String
        Dim m�c�Ə����ɗ\��� As String
        Dim m���������� As String
        Dim m�c�Ə����ɓ� As String
        Dim m�p�ԓ� As String
        Dim m�����ӓo�^�ԍ� As String
        Dim m�����ӕی��� As String
        Dim m�d�ʐ� As String
        Dim m�����Ԑ� As String
        Dim m�����ԓo�^�ԍ� As String
        Dim m�����ؗL������ As String
        Dim m���l As String
        Dim m�R�� As String
        Dim m��㎞�� As String
        Dim m�ŏI�����ԍ� As String
        Dim m��ЃR�[�h As String
        Dim m�Ԏ�R�[�h As String
        Dim m���q�o�^��ЃR�[�h As String
        Dim m���p���z�匎 As String
        Dim m���p���z���� As String
        Dim m���p���z3�� As String
        Dim m�R���敪 As String
        Dim m�p�r�敪 As String
        Dim m���p���z�[�� As String
        Dim m���͔ԍ� As String
        Dim m�����q�ԍ��n��R�[�h As String
        Dim m�����q�ԍ�1 As String
        Dim m�����q�ԍ�2 As String
        Dim m�����q�ԍ�3 As String
        Dim m�^��1 As String
        Dim m�^��2 As String
        Dim m�^��3 As String
        Dim m�R�� As String
        Dim m�������q�敪 As String
        Dim m�C�ӕی��ԍ� As String
        Dim m�g�p�҃R�[�h As String
        Dim m�Ԍ��g�p�҃R�[�h As String
        Dim m�Ԍ����L�҃R�[�h As String
        Dim m�ؑ֓� As String
        Dim m�A���ؑ֓� As String
        Dim m��Ԓ�� As String
        Dim m��̕񍐓��t As String
        Dim m�ړ��񍐔ԍ� As String
        Dim m���͏�� As String
        Dim m���ԑ�֋敪 As String
        Dim m�ؑ֋敪 As String
        Dim m���q��� As String
        Dim m���q�v�揈��SEQ As String
        Dim m���q�o�^�t���O As String
        Dim m����m����� As String
        Dim m���p���� As String
        Dim m����ЃR�[�h As String
        Dim m�������R�[�h As String
        Dim m���c�Ǝ��q�敪 As String
        Dim m���������q�敪 As String
        Dim m���ؑ֓� As String
        Dim m���Ԏ�R�[�h As String
        Dim m���ԑ̔ԍ� As String
        Dim m���q�}�X�^�X�V�敪���� As String
        Dim m���q�}�X�^�X�V�敪��� As String
        Dim m���q�}�X�^�X�V�敪�c�ƈړ� As String
        Dim m���q�}�X�^�X�V�敪��Јړ� As String
        Dim m���q�}�X�^�X�V�敪���q�����e As String
        Dim m���ԍς݃t���O As String
        Dim m�����Ώۃt���O As String '// 1:�c�Ǝ��q�}�X�^�X�V�Ώ� 2:���q�}�X�^�X�V�Ώ�
        Dim m�i���o�[�F�敪 As String
        Dim m���[�J�[�R�[�h As String
        Dim m���L�敪 As String
        Dim m���[�X��ЃR�[�h As String
        Dim m����o�^�N���� As String
        Dim m���T�C�N������ As String
    End Structure

    '******************************************************************************
    ' �� �� ��  : gsubUpdateCarTransfer
    ' �X�R�[�v  : Private
    ' �������e  : ���q�Ǘ����Ă���A���q�}�X�^�Ɖc�Ǝ��q�}�X�^�����q�ٓ��e�[�u�����ǉ��E�X�V�E�폜���s��
    ' ���@�@�l  : ���q�}�X�^�ɂ��ẮA���s�����ȑO�̐ؑ֓���Ώ�
    '           : �c�Ǝ��q�}�X�^�ɂ��ẮA�c�Ɠ�������ȑO�̐ؑ֓���Ώ�
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstr���             String        �@   I     ���񏈗����s���Ώۂ̉�ЃR�[�h
    '   pstr����             String        �@   I     ���񏈗����s���Ώۂ̕����R�[�h
    '   pstr�c�Ɠ����       String             I     ���񏈗����s���Ώۂ̉c�Ɠ����(yyyymmdd�`��)
    '   pstr���s�t���O       String             I     1:���q�}�X�^�̂ݍX�V 2:�c�Ǝ��q�}�X�^�̂ݍX�V 3:�ǂ�����X�V
    '   pstr�X�e�[�^�X       String            I/O    �ǂ̒i�K�܂ŏ�����������ł��邩���Z�b�g
    '   pstrSEQ              String             I     ���q�v�����SEQ(�Z�b�g����Ă���ꍇ�͉�ʂ���̋N���Ƃ���)
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/04  �j�r�q             �V�K�쐬
    '               2009/09/28  �j�r�q             �t�@���N�V��������gsubUpdateCarTransfer�ɕύX����
    '               2010/03/09  �j�r�q             ���q�}�X�^�A�c�Ǝ��q�}�X�^�𔽉f����������Ɏw�����e�敪=11(�ۗ����Ԃ̔��f�s��̏C��)
    '               2010/05/31  �j�r�q             �{���җ����e�[�u��������q�}�X�^�ɔ��f������敪��ؑ֋敪������q�}�X�^���f�敪�ɕύX����
    '******************************************************************************
    Public Function gsubUpdateCarTransfer(ByVal pstr��� As String, ByVal pstr���� As String, ByVal pstr�c�Ɠ���� As String, ByVal pstr���s�t���O As String, ByRef pstr�X�e�[�^�X As String, ByVal pstrSEQ As String) As Object

        Dim strSQL As String
        Dim objDynaset As Object
        Dim objUpdataParam As ���q���

        pstr�X�e�[�^�X = "���q�ٓ��e�[�u������Ώۃf�[�^���o"
        strSQL = ""
        If pstr���s�t���O = "1" Or pstr���s�t���O = "3" Then
            '// ���q�}�X�^�̍X�V�̏I����Ă��Ȃ����q�ٓ��e�[�u��
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.�ԑ̔ԍ�                               ,CPT.�w�����e�敪                           ,CPT.���q�ԍ��n��R�[�h                     ,CPT.���q�ԍ��P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�ԍ��Q                             ,CPT.���q�ԍ��R                             ,CPT.�Ԗ�                                   ,CPT.�N��                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�G���W���^��                           ,CPT.�^��                                   ,CPT.�敪                                   ,CPT.���q�敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�R���R�[�h                             ,CPT.�t�@�[�X�g                             ,CPT.�o�^�N����                             ,CPT.���q�{�̉��i                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�擾��                                 ,CPT.�G�A�R�����i                           ,CPT.�������[�^�[���i                       ,CPT.�^�R���[�^�[���i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.���̑���p                             ,CPT.��ԋ敪                               ,CPT.�����R�[�h                             ,CPT.���q�o�^�����R�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ԍ�                               ,CPT.�{���҃R�[�h�P                         ,CPT.���p���z�P                             ,CPT.���p�����P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�݌v�z�P                           ,CPT.�`�s���p��P                           ,CPT.���p�c�����P                           ,CPT.�{���҃R�[�h�Q                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�Q                             ,CPT.���p�����Q                             ,CPT.���p�݌v�z�Q                           ,CPT.�`�s���p��Q                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�c�����Q                           ,CPT.���p���z                               ,CPT.�d�b�ԍ�                               ,CPT.�����ԍ�                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی����                               ,CPT.�����ԕی�������                       ,CPT.�ی��\���Җ�����                       ,CPT.�ی��\���Җ��J�i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���җX�֔ԍ��P                   ,CPT.�ی��\���җX�֔ԍ��Q                   ,CPT.�ی��\���ғs���{������                 ,CPT.�ی��\���Ҏs��S����                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn����                 ,CPT.�ی��\���ҍ�������                     ,CPT.�ی��\���ғs���{���J�i                 ,CPT.�ی��\���Ҏs��S�J�i                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn�J�i                 ,CPT.�ی��\���ҍ����J�i                     ,CPT.�������_����                         ,CPT.����Ԍ���                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.��֗\���                             ,CPT.�c�Ə��o�ɓ�                           ,CPT.�������ɓ�                             ,CPT.�c�Ə����ɗ\���                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.����������                             ,CPT.�c�Ə����ɓ�                           ,CPT.�p�ԓ�                                 ,CPT.�����ӓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ӕی���                           ,CPT.�d�ʐ�                                 ,CPT.�����Ԑ�                               ,CPT.�����ԓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ؗL������                         ,CPT.���l                                   ,CPT.�R��                                   ,CPT.��㎞��                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ŏI�����ԍ�                           ,CPT.��ЃR�[�h                             ,CPT.�Ԏ�R�[�h                             ,CPT.���q�o�^��ЃR�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�匎                           ,CPT.���p���z����                           ,CPT.���p���z�R��                           ,CPT.�R���敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�p�r�敪                               ,CPT.���p���z�[��                           ,CPT.���͔ԍ�                               ,CPT.�����q�ԍ��n��R�[�h                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����q�ԍ��P                           ,CPT.�����q�ԍ��Q                           ,CPT.�����q�ԍ��R                           ,CPT.�^���P                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.�^���Q                                 ,CPT.�^���R                                 ,CPT.�R��                                   ,CPT.�������q�敪                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�C�ӕی��ԍ�                           ,CPT.�g�p�҃R�[�h                           ,CPT.�Ԍ��g�p�҃R�[�h                       ,CPT.�Ԍ����L�҃R�[�h                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ؑ֓�                                 ,CPT.�A���ؑ֓�                             ,CPT.��Ԓ��                               ,CPT.��̕񍐓��t                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ړ��񍐔ԍ�                           ,CPT.���͏��                               ,CPT.���ԑ�֋敪                           ,CPT.�ؑ֋敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q���                               ,CPT.���q�v�揈��SEQ                        ,CPT.���q�o�^�t���O                         ,CPT.����m�����                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p����                             ,CPT.����ЃR�[�h                           ,CPT.�������R�[�h                           ,CPT.���c�Ǝ��q�敪                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���������q�敪                         ,CPT.���ؑ֓�                               ,CPT.���Ԏ�R�[�h                           ,CPT.���ԑ̔ԍ�                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪����                 ,CPT.���q�}�X�^�X�V�敪���                 ,CPT.���q�}�X�^�X�V�敪�c�ƈړ�             ,CPT.���q�}�X�^�X�V�敪��Јړ�          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪���q�����e           ,CPL.���葤���q�v�揈��SEQ                  ,PT2.���q�v�揈��SEQ CSEQ                   ,PT2.�ؑ֓� C�ؑ֓�                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.����m����� ���ԍς݃t���O         "
            strSQL = strSQL & Chr(10) & "   ,'2' AS �����Ώۃt���O " '// 1:�c�Ǝ��q�}�X�^�X�V�Ώ�    2:���q�}�X�^�X�V�Ώ�
            strSQL = strSQL & Chr(10) & "   ,CPT.�i���o�[�F�敪 ,CPT.���[�J�[�R�[�h ,CPT.���L�敪 "
            strSQL = strSQL & Chr(10) & "   ,CPT.���[�X��ЃR�[�h ,CPT.����o�^�N���� ,CPT.���T�C�N������ "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    ���q�ٓ��e�[�u�� CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�v����̓e�[�u�� CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.���q�v�揈��SEQ = CPL.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�ٓ��e�[�u�� PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.���葤���q�v�揈��SEQ = PT2.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN �����}�X�^ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.��ЃR�[�h = BMM.��ЃR�[�h"
            strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = BMM.�����R�[�h"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.���q�o�^�t���O = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.���q�}�X�^����m����� IS NULL"
            '// ���ԁA��ցA�c�ƈړ��A��ЊԈړ����ԁA�ۗ����Ԃɂ��Ă͖����ԍ��Ɛ����ԍ�<>NULL ��ǉ�
            strSQL = strSQL & Chr(10) & "AND ((CPT.�w�����e�敪 IN ('0','2','3','5','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL ) "
            '// ��L�ȊO�̎w�����e�敪�ɂ��Ă͖����ԍ��Ɛ����ԍ�<>NULL�݂͂Ȃ�
            strSQL = strSQL & Chr(10) & "OR   (CPT.�w�����e�敪 IN ('1','4','6','7','8','9','10'))) " '// 2010/03/09  11:�ۗ����Ԃ͂����ł݂͂Ȃ�
            '// ��ʂ��璼�ڋN������ꍇ�͓��t�̏������݂��Ɏ��q�v�揈��SEQ�Ń��R�[�h��1���ɓ��肵�ď������s��
            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.���q�v�揈��SEQ = '" & pstrSEQ & "'"
            Else
                '// ���Ԃ�1���ɏI��莞�_�Ŕ��f�����邽�� SYSDATE -1 ����ȊO��1���̊J�n���甽�f�����邽�� SYSDATE
                strSQL = strSQL & Chr(10) & "AND ((CPT.�w�����e�敪 IN ('1','4') "
                strSQL = strSQL & Chr(10) & "     AND CPT.�ؑ֓� <= TO_CHAR(SYSDATE - 1, 'YYYYMMDD')) "
                strSQL = strSQL & Chr(10) & "     OR (CPT.�w�����e�敪 NOT IN ('1','4') "
                strSQL = strSQL & Chr(10) & "     AND CPT.�ؑ֓� <= TO_CHAR(SYSDATE, 'YYYYMMDD'))) "
                '// ��ԃo�b�`���́A�S��Ђ�Ώۂɂ���
                If pstr��� <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.��ЃR�[�h = '" & gfncGetCodeToControl(pstr���, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = '" & gfncGetCodeToControl(pstr����, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.�c�Ƌ敪 = '0'))"
                End If
            End If

        End If

        If pstr���s�t���O = "3" Then
            strSQL = strSQL & Chr(10) & "UNION ALL ( "
        End If

        If pstr���s�t���O = "2" Or pstr���s�t���O = "3" Then
            '// �c�Ǝ��q�}�X�^�̍X�V�̏I����Ă��Ȃ����q�ٓ��e�[�u��
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.�ԑ̔ԍ�                               ,CPT.�w�����e�敪                           ,CPT.���q�ԍ��n��R�[�h                     ,CPT.���q�ԍ��P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�ԍ��Q                             ,CPT.���q�ԍ��R                             ,CPT.�Ԗ�                                   ,CPT.�N��                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�G���W���^��                           ,CPT.�^��                                   ,CPT.�敪                                   ,CPT.���q�敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�R���R�[�h                             ,CPT.�t�@�[�X�g                             ,CPT.�o�^�N����                             ,CPT.���q�{�̉��i                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�擾��                                 ,CPT.�G�A�R�����i                           ,CPT.�������[�^�[���i                       ,CPT.�^�R���[�^�[���i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.���̑���p                             ,CPT.��ԋ敪                               ,CPT.�����R�[�h                             ,CPT.���q�o�^�����R�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ԍ�                               ,CPT.�{���҃R�[�h�P                         ,CPT.���p���z�P                             ,CPT.���p�����P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�݌v�z�P                           ,CPT.�`�s���p��P                           ,CPT.���p�c�����P                           ,CPT.�{���҃R�[�h�Q                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�Q                             ,CPT.���p�����Q                             ,CPT.���p�݌v�z�Q                           ,CPT.�`�s���p��Q                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�c�����Q                           ,CPT.���p���z                               ,CPT.�d�b�ԍ�                               ,CPT.�����ԍ�                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی����                               ,CPT.�����ԕی�������                       ,CPT.�ی��\���Җ�����                       ,CPT.�ی��\���Җ��J�i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���җX�֔ԍ��P                   ,CPT.�ی��\���җX�֔ԍ��Q                   ,CPT.�ی��\���ғs���{������                 ,CPT.�ی��\���Ҏs��S����                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn����                 ,CPT.�ی��\���ҍ�������                     ,CPT.�ی��\���ғs���{���J�i                 ,CPT.�ی��\���Ҏs��S�J�i                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn�J�i                 ,CPT.�ی��\���ҍ����J�i                     ,CPT.�������_����                         ,CPT.����Ԍ���                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.��֗\���                             ,CPT.�c�Ə��o�ɓ�                           ,CPT.�������ɓ�                             ,CPT.�c�Ə����ɗ\���                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.����������                             ,CPT.�c�Ə����ɓ�                           ,CPT.�p�ԓ�                                 ,CPT.�����ӓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ӕی���                           ,CPT.�d�ʐ�                                 ,CPT.�����Ԑ�                               ,CPT.�����ԓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ؗL������                         ,CPT.���l                                   ,CPT.�R��                                   ,CPT.��㎞��                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ŏI�����ԍ�                           ,CPT.��ЃR�[�h                             ,CPT.�Ԏ�R�[�h                             ,CPT.���q�o�^��ЃR�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�匎                           ,CPT.���p���z����                           ,CPT.���p���z�R��                           ,CPT.�R���敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�p�r�敪                               ,CPT.���p���z�[��                           ,CPT.���͔ԍ�                               ,CPT.�����q�ԍ��n��R�[�h                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����q�ԍ��P                           ,CPT.�����q�ԍ��Q                           ,CPT.�����q�ԍ��R                           ,CPT.�^���P                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.�^���Q                                 ,CPT.�^���R                                 ,CPT.�R��                                   ,CPT.�������q�敪                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�C�ӕی��ԍ�                           ,CPT.�g�p�҃R�[�h                           ,CPT.�Ԍ��g�p�҃R�[�h                       ,CPT.�Ԍ����L�҃R�[�h                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ؑ֓�                                 ,CPT.�A���ؑ֓�                             ,CPT.��Ԓ��                               ,CPT.��̕񍐓��t                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ړ��񍐔ԍ�                           ,CPT.���͏��                               ,CPT.���ԑ�֋敪                           ,CPT.�ؑ֋敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q���                               ,CPT.���q�v�揈��SEQ                        ,CPT.���q�o�^�t���O                         ,CPT.����m�����                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p����                             ,CPT.����ЃR�[�h                           ,CPT.�������R�[�h                           ,CPT.���c�Ǝ��q�敪                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���������q�敪                         ,CPT.���ؑ֓�                               ,CPT.���Ԏ�R�[�h                           ,CPT.���ԑ̔ԍ�                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪����                 ,CPT.���q�}�X�^�X�V�敪���                 ,CPT.���q�}�X�^�X�V�敪�c�ƈړ�             ,CPT.���q�}�X�^�X�V�敪��Јړ�          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪���q�����e           ,CPL.���葤���q�v�揈��SEQ                  ,PT2.���q�v�揈��SEQ CSEQ                   ,PT2.�ؑ֓� C�ؑ֓�                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.����m����� ���ԍς݃t���O         "
            strSQL = strSQL & Chr(10) & "   ,'1' AS �����Ώۃt���O " '// 1:�c�Ǝ��q�}�X�^�X�V�Ώ�    2:���q�}�X�^�X�V�Ώ�
            strSQL = strSQL & Chr(10) & "   ,CPT.�i���o�[�F�敪 ,CPT.���[�J�[�R�[�h ,CPT.���L�敪 "
            strSQL = strSQL & Chr(10) & "   ,CPT.���[�X��ЃR�[�h ,CPT.����o�^�N���� ,CPT.���T�C�N������ "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    ���q�ٓ��e�[�u�� CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�v����̓e�[�u�� CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.���q�v�揈��SEQ = CPL.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�ٓ��e�[�u�� PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.���葤���q�v�揈��SEQ = PT2.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN �����}�X�^ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.��ЃR�[�h = BMM.��ЃR�[�h"
            strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = BMM.�����R�[�h"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.���q�o�^�t���O = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.����m����� IS NULL"
            '// ���ԁA��ցA�c�ƈړ��A��ЊԈړ����ԁA�ۗ����Ԃɂ��Ă͖����ԍ��Ɛ����ԍ�<>NULL ��ǉ�
            strSQL = strSQL & Chr(10) & "AND ((CPT.�w�����e�敪 IN ('0','2','3','5','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL ) "
            '// ��L�ȊO�̎w�����e�敪�ɂ��Ă͖����ԍ��Ɛ����ԍ�<>NULL�݂͂Ȃ�
            strSQL = strSQL & Chr(10) & "OR   (CPT.�w�����e�敪 IN ('1','4','6','7','8','9','10'))) " '// 2010/03/09  11:�ۗ����Ԃ͂����ł݂͂Ȃ�
            '// ��ʂ��璼�ڋN������ꍇ�͓��t�̏������݂��Ɏ��q�v�揈��SEQ�Ń��R�[�h��1���ɓ��肵�ď������s��
            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.���q�v�揈��SEQ = '" & pstrSEQ & "'"
            Else
                '// ���Ԃ�1���ɏI��莞�_�Ŕ��f�����邽�� SYSDATE -1 ����ȊO��1���̊J�n���甽�f�����邽�� SYSDATE
                strSQL = strSQL & Chr(10) & "AND ((CPT.�w�����e�敪 IN ('1','4') "
                strSQL = strSQL & Chr(10) & "      AND CPT.�ؑ֓� <= '" & pstr�c�Ɠ���� & "') "
                strSQL = strSQL & Chr(10) & "      OR (CPT.�w�����e�敪 NOT IN ('1','4') "
                strSQL = strSQL & Chr(10) & "      AND CPT.�ؑ֓� <= '" & VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, CDate(VB6.Format(pstr�c�Ɠ����, "0000/00/00"))), "yyyymmdd") & "')) "
                '// ��ԃo�b�`���́A�S��Ђ�Ώۂɂ���
                If pstr��� <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.��ЃR�[�h = '" & gfncGetCodeToControl(pstr���, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = '" & gfncGetCodeToControl(pstr����, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.�c�Ƌ敪 = '0'))"
                End If
            End If
        End If

        If pstr���s�t���O = "3" Then
            strSQL = strSQL & Chr(10) & " ) "
        End If

        strSQL = strSQL & Chr(10) & "ORDER BY"
        strSQL = strSQL & Chr(10) & "    �w�����e�敪,�ԑ̔ԍ� "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDynaset = gobjOraDatabase.CreateDynaset(strSQL, &H1)

        With objDynaset

            'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF = True Then
                pstr�X�e�[�^�X = "���q�Ǘ��@����m��Y���Ȃ�"
                GoTo HONMUTUKEKOMI
                '            Exit Function
            End If

            Do

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstr�X�e�[�^�X = "���q�ٓ��e�[�u���@�Y��SEQ�F" & gfncFieldVal(.Fields("���q�v�揈��SEQ").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ԑ̔ԍ� = gfncFieldVal(.Fields("�ԑ̔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�w�����e�敪 = gfncFieldVal(.Fields("�w�����e�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ��n��R�[�h = gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ�1 = gfncFieldVal(.Fields("���q�ԍ��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ�2 = gfncFieldVal(.Fields("���q�ԍ��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ�3 = gfncFieldVal(.Fields("���q�ԍ��R").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԗ� = gfncFieldVal(.Fields("�Ԗ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�N�� = gfncFieldVal(.Fields("�N��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�G���W���^�� = gfncFieldVal(.Fields("�G���W���^��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^�� = gfncFieldVal(.Fields("�^��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�敪 = gfncFieldVal(.Fields("�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�敪 = gfncFieldVal(.Fields("���q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R���R�[�h = gfncFieldVal(.Fields("�R���R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�t�@�[�X�g = gfncFieldVal(.Fields("�t�@�[�X�g").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�o�^�N���� = gfncFieldVal(.Fields("�o�^�N����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�{�̉��i = gfncFieldVal(.Fields("���q�{�̉��i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�擾�� = gfncFieldVal(.Fields("�擾��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�G�A�R�����i = gfncFieldVal(.Fields("�G�A�R�����i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������[�^�[���i = gfncFieldVal(.Fields("�������[�^�[���i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^�R���[�^�[���i = gfncFieldVal(.Fields("�^�R���[�^�[���i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���̑���p = gfncFieldVal(.Fields("���̑���p").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��ԋ敪 = gfncFieldVal(.Fields("��ԋ敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����R�[�h = gfncFieldVal(.Fields("�����R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�o�^�����R�[�h = gfncFieldVal(.Fields("���q�o�^�����R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԍ� = gfncFieldVal(.Fields("�����ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�{���҃R�[�h1 = gfncFieldVal(.Fields("�{���҃R�[�h�P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z1 = gfncFieldVal(.Fields("���p���z�P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p����1 = gfncFieldVal(.Fields("���p�����P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�݌v�z1 = gfncFieldVal(.Fields("���p�݌v�z�P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT���p��1 = gfncFieldVal(.Fields("�`�s���p��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�c����1 = gfncFieldVal(.Fields("���p�c�����P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�{���҃R�[�h2 = gfncFieldVal(.Fields("�{���҃R�[�h�Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z2 = gfncFieldVal(.Fields("���p���z�Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p����2 = gfncFieldVal(.Fields("���p�����Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�݌v�z2 = gfncFieldVal(.Fields("���p�݌v�z�Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT���p��2 = gfncFieldVal(.Fields("�`�s���p��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�c����2 = gfncFieldVal(.Fields("���p�c�����Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z = gfncFieldVal(.Fields("���p���z").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�d�b�ԍ� = gfncFieldVal(.Fields("�d�b�ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԍ� = gfncFieldVal(.Fields("�����ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی���� = gfncFieldVal(.Fields("�ی����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی���Ж� = mfncGetHokenName(gfncFieldVal(.Fields("�ی����").Value)) '// 2010/03/26 �ی���Ж��̎擾��ǉ�
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԕی������� = gfncFieldVal(.Fields("�����ԕی�������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Җ����� = gfncFieldVal(.Fields("�ی��\���Җ�����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Җ��J�i = gfncFieldVal(.Fields("�ی��\���Җ��J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���җX�֔ԍ�1 = gfncFieldVal(.Fields("�ی��\���җX�֔ԍ��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���җX�֔ԍ�2 = gfncFieldVal(.Fields("�ی��\���җX�֔ԍ��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ғs���{������ = gfncFieldVal(.Fields("�ی��\���ғs���{������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ҏs��S���� = gfncFieldVal(.Fields("�ی��\���Ҏs��S����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ғ����Ԓn���� = gfncFieldVal(.Fields("�ی��\���Ғ����Ԓn����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ҍ������� = gfncFieldVal(.Fields("�ی��\���ҍ�������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ғs���{���J�i = gfncFieldVal(.Fields("�ی��\���ғs���{���J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ҏs��S�J�i = gfncFieldVal(.Fields("�ی��\���Ҏs��S�J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ғ����Ԓn�J�i = gfncFieldVal(.Fields("�ی��\���Ғ����Ԓn�J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ҍ����J�i = gfncFieldVal(.Fields("�ی��\���ҍ����J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������_���� = gfncFieldVal(.Fields("�������_����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����Ԍ��� = gfncFieldVal(.Fields("����Ԍ���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��֗\��� = gfncFieldVal(.Fields("��֗\���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�c�Ə��o�ɓ� = gfncFieldVal(.Fields("�c�Ə��o�ɓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������ɓ� = gfncFieldVal(.Fields("�������ɓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�c�Ə����ɗ\��� = gfncFieldVal(.Fields("�c�Ə����ɗ\���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���������� = gfncFieldVal(.Fields("����������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�c�Ə����ɓ� = gfncFieldVal(.Fields("�c�Ə����ɓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�p�ԓ� = gfncFieldVal(.Fields("�p�ԓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ӓo�^�ԍ� = gfncFieldVal(.Fields("�����ӓo�^�ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ӕی��� = gfncFieldVal(.Fields("�����ӕی���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�d�ʐ� = gfncFieldVal(.Fields("�d�ʐ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����Ԑ� = gfncFieldVal(.Fields("�����Ԑ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԓo�^�ԍ� = gfncFieldVal(.Fields("�����ԓo�^�ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ؗL������ = gfncFieldVal(.Fields("�����ؗL������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���l = gfncFieldVal(.Fields("���l").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R�� = gfncFieldVal(.Fields("�R��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��㎞�� = gfncFieldVal(.Fields("��㎞��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ŏI�����ԍ� = gfncFieldVal(.Fields("�ŏI�����ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��ЃR�[�h = gfncFieldVal(.Fields("��ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԏ�R�[�h = gfncFieldVal(.Fields("�Ԏ�R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�o�^��ЃR�[�h = gfncFieldVal(.Fields("���q�o�^��ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z�匎 = gfncFieldVal(.Fields("���p���z�匎").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z���� = gfncFieldVal(.Fields("���p���z����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z3�� = gfncFieldVal(.Fields("���p���z�R��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R���敪 = gfncFieldVal(.Fields("�R���敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�p�r�敪 = gfncFieldVal(.Fields("�p�r�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z�[�� = gfncFieldVal(.Fields("���p���z�[��").Value)
                'objUpdataParam.m���͔ԍ� = gfncFieldVal(.Fields("���͔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���͔ԍ� = gfncFieldVal(.Fields("���͔ԍ�").Value, "1")
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ��n��R�[�h = gfncFieldVal(.Fields("�����q�ԍ��n��R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ�1 = gfncFieldVal(.Fields("�����q�ԍ��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ�2 = gfncFieldVal(.Fields("�����q�ԍ��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ�3 = gfncFieldVal(.Fields("�����q�ԍ��R").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^��1 = gfncFieldVal(.Fields("�^���P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^��2 = gfncFieldVal(.Fields("�^���Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^��3 = gfncFieldVal(.Fields("�^���R").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R�� = gfncFieldVal(.Fields("�R��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������q�敪 = gfncFieldVal(.Fields("�������q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�C�ӕی��ԍ� = gfncFieldVal(.Fields("�C�ӕی��ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�g�p�҃R�[�h = gfncFieldVal(.Fields("�g�p�҃R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԍ��g�p�҃R�[�h = gfncFieldVal(.Fields("�Ԍ��g�p�҃R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԍ����L�҃R�[�h = gfncFieldVal(.Fields("�Ԍ����L�҃R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ؑ֓� = gfncFieldVal(.Fields("�ؑ֓�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�A���ؑ֓� = gfncFieldVal(.Fields("�A���ؑ֓�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��Ԓ�� = gfncFieldVal(.Fields("��Ԓ��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��̕񍐓��t = gfncFieldVal(.Fields("��̕񍐓��t").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ړ��񍐔ԍ� = gfncFieldVal(.Fields("�ړ��񍐔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���͏�� = gfncFieldVal(.Fields("���͏��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ԑ�֋敪 = gfncFieldVal(.Fields("���ԑ�֋敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ؑ֋敪 = gfncFieldVal(.Fields("�ؑ֋敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q��� = gfncFieldVal(.Fields("���q���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�v�揈��SEQ = gfncFieldVal(.Fields("���q�v�揈��SEQ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�o�^�t���O = gfncFieldVal(.Fields("���q�o�^�t���O").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����m����� = gfncFieldVal(.Fields("����m�����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���� = gfncFieldVal(.Fields("���p����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����ЃR�[�h = gfncFieldVal(.Fields("����ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������R�[�h = gfncFieldVal(.Fields("�������R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���c�Ǝ��q�敪 = gfncFieldVal(.Fields("���c�Ǝ��q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���������q�敪 = gfncFieldVal(.Fields("���������q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ؑ֓� = gfncFieldVal(.Fields("���ؑ֓�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���Ԏ�R�[�h = gfncFieldVal(.Fields("���Ԏ�R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ԑ̔ԍ� = gfncFieldVal(.Fields("���ԑ̔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪���� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪��� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪�c�ƈړ� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪�c�ƈړ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪��Јړ� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪��Јړ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪���q�����e = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪���q�����e").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ԍς݃t���O = gfncFieldVal(.Fields("���ԍς݃t���O").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����Ώۃt���O = gfncFieldVal(.Fields("�����Ώۃt���O").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�i���o�[�F�敪 = gfncFieldVal(.Fields("�i���o�[�F�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���[�J�[�R�[�h = gfncFieldVal(.Fields("���[�J�[�R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���L�敪 = gfncFieldVal(.Fields("���L�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���[�X��ЃR�[�h = gfncFieldVal(.Fields("���[�X��ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����o�^�N���� = gfncFieldVal(.Fields("����o�^�N����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���T�C�N������ = gfncFieldVal(.Fields("���T�C�N������").Value)

                '// ��ЊԈړ��̌��Ƒ��ɂ��Ă͏������@����U�ۗ�
                '            If gfncFieldVal(.Fields("���葤���q�v�揈��SEQ").Value) <> "" Then
                '                If gfncFieldVal(.Fields("CSEQ").Value) = "" Then
                '                    GoTo NEXT_
                '                End If
                '                If gfncFieldVal(.Fields("C�ؑ֓�").Value) > gfncFieldVal(.Fields("CDATE").Value) Then
                '                    GoTo NEXT_
                '                End If
                '            End If


                Select Case objUpdataParam.m�w�����e�敪

                    Case "0"

                        pstr�X�e�[�^�X = "���ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate����(objUpdataParam)

                    Case "1"

                        pstr�X�e�[�^�X = "���ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate����(objUpdataParam)

                    Case "2"

                        pstr�X�e�[�^�X = "��ց@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate���(objUpdataParam, pstr���s�t���O)

                    Case "3"

                        pstr�X�e�[�^�X = "�c�Ə��ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�c�Ə���(objUpdataParam)

                    Case "4"

                        pstr�X�e�[�^�X = "��ЊԌ��ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate��ЊԌ���(objUpdataParam)

                    Case "5"

                        pstr�X�e�[�^�X = "��Њԑ��ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate��Њԑ���(objUpdataParam)

                    Case "6"

                        pstr�X�e�[�^�X = "�Зp�Ԑؑց@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�Зp�Ԑؑ�(objUpdataParam)

                    Case "7"

                        pstr�X�e�[�^�X = "�p�ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�p��(objUpdataParam)

                    Case "8"

                        pstr�X�e�[�^�X = "���p�@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate���p(objUpdataParam)

                    Case "9"

                        pstr�X�e�[�^�X = "�ۗ��Ԑؑց@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�ۗ��Ԑؑ�(objUpdataParam)

                    Case "10"

                        pstr�X�e�[�^�X = "���ڃ����e�i���X�@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�}�X�^�����e(objUpdataParam)

                    Case "11"

                        pstr�X�e�[�^�X = "�ۗ����ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�ۗ�����(objUpdataParam)

                End Select

                '// �t���O�̏�ԂōX�V�������m������̍X�V���ύX����
                If objUpdataParam.m�����Ώۃt���O = "1" Then

                    pstr�X�e�[�^�X = "����m������̍X�V�@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                    '// �c�Ǝ��q�}�X�^
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�ٓ��e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�v����̓e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                Else
                    pstr�X�e�[�^�X = "���q�}�X�^����m������̍X�V�@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                    '// ���q�}�X�^
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�ٓ��e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ���q�}�X�^����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�v����̓e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ���q�}�X�^����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

NEXT_:

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .MoveNext()

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Loop While .EOF = False

        End With

HONMUTUKEKOMI:

        Dim objDys�{���җ����e�[�u�� As Object
        Dim objDys���q�����e�[�u�� As Object
        If pstr���s�t���O = "1" Or pstr���s�t���O = "3" Then
            '// �{���㖱�����e�[�u��������q�}�X�^�ɖ{���҂P�Ɩ{���҂Q�̏���Ђ�����

            pstr�X�e�[�^�X = "�{���җ����e�[�u��������q�}�X�^�̖{���ҏ��𔽉f�F"
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    HRT.���q�ԍ��n��R�[�h "
            strSQL = strSQL & Chr(10) & "   ,HRT.���q�ԍ��P         "
            strSQL = strSQL & Chr(10) & "   ,HRT.���q�ԍ��Q         "
            strSQL = strSQL & Chr(10) & "   ,HRT.���q�ԍ��R         "
            strSQL = strSQL & Chr(10) & "   ,ESM.�����ԍ�           "
            strSQL = strSQL & Chr(10) & "   ,HRT.�ؑ֓�             "
            strSQL = strSQL & Chr(10) & "   ,HRT.�V�{���҃R�[�h�P   "
            strSQL = strSQL & Chr(10) & "   ,HRT.�V�{���҃R�[�h�Q   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �{���җ����e�[�u�� HRT "
            strSQL = strSQL & Chr(10) & "   ,�c�Ǝ��q�}�X�^     ESM "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    HRT.���q�ԍ��n��R�[�h = ESM.���q�ԍ��n��R�[�h(+) "
            strSQL = strSQL & Chr(10) & "AND HRT.���q�ԍ��P         = ESM.���q�ԍ��P        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.���q�ԍ��Q         = ESM.���q�ԍ��Q        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.���q�ԍ��R         = ESM.���q�ԍ��R        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.�ؑ֓�            <= TO_CHAR(SYSDATE,'YYYYMMDD') "
            strSQL = strSQL & Chr(10) & "AND NVL(HRT.���q�}�X�^���f�敪,'0') = '0' " '// 2010/05/31
            '        strSQL = strSQL & Chr(10) & "AND HRT.�ؑ֋敪           =  0 "
            strSQL = strSQL & Chr(10) & "ORDER BY HRT.�ؑ֓� " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys�{���җ����e�[�u�� = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys�{���җ����e�[�u��

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        pstr�X�e�[�^�X = "�{���ҕt���݁F���q�ԍ�:" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "-" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "-" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "-" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & ""
                        ' ���q�}�X�^���X�V
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(�V�{���҃R�[�h�P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET �{���҃R�[�h�P     = '" & gfncFieldVal(.Fields("�V�{���҃R�[�h�P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(�V�{���҃R�[�h�Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q     = '" & gfncFieldVal(.Fields("�V�{���҃R�[�h�Q").Value) & "' "
                        '// 2009/09/23 START �X�V�ǉ�
                        strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��n��R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P         = '" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q         = '" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R         = '" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)


                        '// ���q�}�X�^���f�敪���X�V(�ؑ֋敪 = 1)  2010/05/31
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE �{���җ����e�[�u�� SET"
                        strSQL = strSQL & Chr(10) & "   ���q�}�X�^���f�敪  = 1 "
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��n��R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P         = '" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q         = '" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R         = '" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(�ؑ֓�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND �ؑ֓�             = '" & gfncFieldVal(.Fields("�ؑ֓�").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            'UPGRADE_NOTE: Object objDys�{���җ����e�[�u�� may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDys�{���җ����e�[�u�� = Nothing

            '// 2009/09/23 START ���q�����e�[�u��������q�}�X�^���X�V���鏈����ǉ�
            '----------------------------------------------------------------------
            ' ���q�����e�[�u��  �f�[�^���f����
            '----------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h   "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P           "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q           "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R           "
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓�               "
            strSQL = strSQL & Chr(10) & "   ,�V��ЃR�[�h         "
            strSQL = strSQL & Chr(10) & "   ,�V�����R�[�h         "
            strSQL = strSQL & Chr(10) & "   ,�V�����ԍ�           "
            strSQL = strSQL & Chr(10) & "   ,�V���q�敪           "
            strSQL = strSQL & Chr(10) & "   ,�V���q�o�^��ЃR�[�h "
            strSQL = strSQL & Chr(10) & "   ,�V���q�o�^�����R�[�h "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ���q�����e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND �ؑ֓�       <= TO_CHAR(SYSDATE,'YYYYMMDD')"
            strSQL = strSQL & Chr(10) & "AND �ؑ֋敪      =  0 "
            strSQL = strSQL & Chr(10) & "ORDER BY �ؑ֓� " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys���q�����e�[�u�� = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys���q�����e�[�u��

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        '// ���q�}�X�^�̍X�V(�������t�Ŏ��q�ύX���͂��ꂽ���e�𔽉f)
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V�����R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET �����R�[�h         = '" & gfncFieldVal(.Fields("�V�����R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V��ЃR�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h         = '" & gfncFieldVal(.Fields("�V��ЃR�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V�����ԍ�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,�����ԍ�           = '" & gfncFieldVal(.Fields("�V�����ԍ�").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V���q�敪).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,���q�敪           = '" & gfncFieldVal(.Fields("�V���q�敪").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V���q�o�^��ЃR�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & gfncFieldVal(.Fields("�V���q�o�^��ЃR�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V���q�o�^�����R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & gfncFieldVal(.Fields("�V���q�o�^�����R�[�h").Value) & "' "
                        '// 2009/09/23 START �X�V�ǉ�
                        strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��n��R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P         = '" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q         = '" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R         = '" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '// 2009/09/23 END
            Call gsubClearObject(objDynaset)
            Call gsubClearObject(objDys�{���җ����e�[�u��)
            Call gsubClearObject(objDys���q�����e�[�u��)
        End If

    End Function

    '******************************************************************************
    ' �� �� ��  : msubUpdate����
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑��ԏ���
    ' ���@�@�l  : ���Ԃ̑ΏۂɂȂ������q�́A���ꂼ��̃}�X�^��INSERT���s����
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate����(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & " �Ԗ�= '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & ",�N��= '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & ",�G���W���^��= '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & ",�ԑ̔ԍ�= '" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�^��= '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & ",�敪= '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���q�敪= '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�t�@�[�X�g= '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & ",�o�^�N����= '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & ",���q�{�̉��i= '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & ",�擾��= '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & ",�G�A�R�����i= '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & ",�������[�^�[���i= '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & ",�^�R���[�^�[���i= '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & ",���̑���p= '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & ",��ԋ敪= '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & ",�����R�[�h= '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���q�o�^�����R�[�h= '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�����ԍ�= '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�{���҃R�[�h�P= '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�P= '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & ",���p�����P= '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & ",���p�݌v�z�P= '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & ",�`�s���p��P= '" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & ",�{���҃R�[�h�Q= '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�Q= '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & ",���p�����Q= '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & ",���p�݌v�z�Q= '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & ",�`�s���p��Q= '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z= '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & ",�d�b�ԍ�= '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԍ�= '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�ی����= '" & objUpdate.m�ی���Ж� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԕی�������= '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���Җ�����= '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���Җ��J�i= '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���җX�֔ԍ��P= '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���җX�֔ԍ��Q= '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���ғs���{������= '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���Ҏs��S����= '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���Ғ����Ԓn����= '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���ҍ�������= '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���ғs���{���J�i= '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���Ҏs��S�J�i= '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���Ғ����Ԓn�J�i= '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & ",�ی��\���ҍ����J�i= '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & ",�������_����= '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & ",����Ԍ���= '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & ",��֗\���= '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & ",�c�Ə��o�ɓ�= '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & ",�������ɓ�= '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & ",�c�Ə����ɗ\���= '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & ",����������= '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & ",�c�Ə����ɓ�= '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & ",�p�ԓ�= '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ӓo�^�ԍ�= '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ӕی���= '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & ",�d�ʐ�= '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & ",�����Ԑ�= '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԓo�^�ԍ�= '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ؗL������= '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & ",���l= '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & ",�R��= '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & ",�X�V�]�ƈ��R�[�h= '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & ",�X�V���t����= SYSDATE"
            strSQL = strSQL & Chr(10) & ",��㎞��= '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & ",�ŏI�����ԍ�= '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",��ЃR�[�h= '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���q�o�^��ЃR�[�h= '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�匎= '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z����= '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�R��= '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & ",�R���敪= '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & ",�p�r�敪= '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�[��= '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��n��R�[�h= '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��P= '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��Q= '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��R= '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & ",���ԑ̔ԍ�= '" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",���Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�V�Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�V�������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���͏��= '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & ",�^���P= '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & ",�^���Q= '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & ",�^���R= '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & ",�R��= '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & ",�������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�C�ӕی��ԍ�= '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�g�p�҃R�[�h= '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԍ��g�p�҃R�[�h= '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԍ����L�҃R�[�h= '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�A���ؑ֓�= '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & ",��Ԓ��= '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��P         = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��Q         = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��R         = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�ԓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = "" : strValSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO ���q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

            strSQL = strSQL & strValSQL

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate����
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̌��ԏ���
    ' ���@�@�l  : ���Ԃ̑ΏۂɂȂ������q�́A�����ԍ��Ɩ����ԍ���NULL�ɂȂ�
    '             ���q�}�X�^�ɂ��Ă�NO�v���[�g��NULL�ɂȂ�A�c�Ǝ��q�}�X�^�ɂ��Ă͔p�ԓ��ɐؑ֓����Z�b�g�����
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  �j�r�q             �ŏI�����ԍ��̓]����ǉ�
    '******************************************************************************
    Private Sub msubUpdate����(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�Ɍ��Ԃ�����q�ŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '3'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '1'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub
    Private Sub msubUpdate���(ByRef objUpdate As ���q���, ByVal pstr���s�t���O As String)

        Dim strSQL As String
        Dim strValSQL As String

        Select Case objUpdate.m���q�}�X�^�X�V�敪���

            Case "1"

                Call msubUpdate���1(objUpdate)


            Case "2"

                Call msubUpdate���2(objUpdate)


            Case "3"

                Call msubUpdate���3(objUpdate, pstr���s�t���O)


            Case "4"

                Call msubUpdate���4(objUpdate, pstr���s�t���O)

        End Select

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate���1
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���
    ' ���@�@�l  : �V�E�����q�ԍ��������ŁA�ԑ̔ԍ����ύX�ɂȂ�ꍇ�̑��
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  �j�r�q             ���q�}�X�^�̑�֌��̎��q�ɋ����q�ԍ����X�V���Ă���
    '               2010/03/24  �j�r�q             ���q�ԍ����ύX����Ȃ��ꍇ�͍ŏI�����ԍ��͓]������NULL�X�V���s���B�����̍��ڂ�NULL�X�V���~�߂�
    '******************************************************************************
    Private Sub msubUpdate���1(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "    �N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���Ж� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�Ɏ��q�ԍ��̕ύX�Ȃ��̑�ւŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "' "
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "' "
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = "" : strValSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO ���q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q��� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p����":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

            strSQL = strSQL & strValSQL

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL"
            '// 2009/09/30 ��֌��̎��q�ɋ����q�ԍ����X�V���Ă���
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h   = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P           = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q           = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R           = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '1'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '3'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate���2
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���
    ' ���@�@�l  : �V�E�����q�ԍ��������ŁA�ԑ̂������̏ꍇ�̑��
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  �j�r�q             ���q�}�X�^�̑�֌��̎��q�ɋ����q�ԍ����X�V���Ă���
    '               2010/03/24  �j�r�q             ���q�ԍ����ύX����Ȃ��ꍇ�͍ŏI�����ԍ��͓]������NULL�X�V���s���B�����̍��ڂ�NULL�X�V���~�߂�
    '******************************************************************************
    Private Sub msubUpdate���2(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "    �N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            'strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���Ж� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ��P & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ��Q & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ��R & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�Ɏ��q�ԍ��̕ύX�Ȃ��̑�ւŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "' "
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "' "
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL"
            '// 2009/09/30 ��֌��̎��q�ɋ����q�ԍ����X�V���Ă���
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h   = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P           = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q           = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R           = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '1'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '3'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = NULL "
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"

            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate���3
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���
    ' ���@�@�l  : �V�E�����q�ԍ����Ⴂ�ŁA�ԑ̂��V�Ԃ̏ꍇ�̑��
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  �j�r�q             ���q�}�X�^�̑�֌��̎��q�ɋ����q�ԍ����X�V���Ă���
    '               2010/03/24  �j�r�q             ���q�ԍ����ύX�����ꍇ�͌����q�̍ŏI�����ԍ��ɖ����ԍ���]�����Ă���
    '                                              �����̍��ڂ�NULL�X�V���~�߂�
    '******************************************************************************
    Private Sub msubUpdate���3(ByRef objUpdate As ���q���, ByVal pstr���s�t���O As String)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then
            '// NO�ύX���ꂽ��֐�̉c�Ǝ��q�}�X�^�̍X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & " �Ԗ�= '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & " �N��= '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & ",�G���W���^��= '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & ",�ԑ̔ԍ�= '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & ",�^��= '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & ",�敪= '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���q�敪= '" & objUpdate.m���q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & ",�t�@�[�X�g= '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & ",�o�^�N����= '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & ",���q�{�̉��i= '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & ",�擾��= '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & ",�G�A�R�����i= '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & ",�������[�^�[���i= '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & ",�^�R���[�^�[���i= '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & ",���̑���p= '" & objUpdate.m���̑���p & "'"
            '        strSQL = strSQL & Chr(10) & ",��ԋ敪= '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & ",�����R�[�h= '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���q�o�^�����R�[�h= '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�����ԍ�= '" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & ",�{���҃R�[�h�P= '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�P= '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & ",���p�����P= '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & ",���p�݌v�z�P= '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & ",�`�s���p��P= '" & objUpdate.mAT���p��1 & "'"
            ''        strSQL = strSQL & Chr(10) & ",�{���҃R�[�h�Q= '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�Q= '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & ",���p�����Q= '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & ",���p�݌v�z�Q= '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & ",�`�s���p��Q= '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z= '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & ",�d�b�ԍ�= '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԍ�= '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�ی����= '" & objUpdate.m�ی���Ж� & "'"
            '        strSQL = strSQL & Chr(10) & ",�����ԕی�������= '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Җ�����= '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Җ��J�i= '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���җX�֔ԍ��P= '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���җX�֔ԍ��Q= '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ғs���{������= '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ҏs��S����= '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ғ����Ԓn����= '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ҍ�������= '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ғs���{���J�i= '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ҏs��S�J�i= '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ғ����Ԓn�J�i= '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ҍ����J�i= '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�������_����= '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & ",����Ԍ���= '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & ",��֗\���= '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & ",�c�Ə��o�ɓ�= '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & ",�������ɓ�= '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & ",�c�Ə����ɗ\���= '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & ",����������= '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & ",�c�Ə����ɓ�= '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & ",�p�ԓ�= '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ӓo�^�ԍ�= '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ӕی���= '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & ",�d�ʐ�= '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & ",�����Ԑ�= '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԓo�^�ԍ�= '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ؗL������= '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & ",���l= '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & ",�R��= '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & ",�X�V�]�ƈ��R�[�h= '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & ",�X�V���t����= SYSDATE"
            strSQL = strSQL & Chr(10) & ",��㎞��= '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & ",�ŏI�����ԍ�= NULL "
            strSQL = strSQL & Chr(10) & ",��ЃR�[�h= '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���q�o�^��ЃR�[�h= '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�匎= '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z����= '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�R��= '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & ",�R���敪= '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & ",�p�r�敪= '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�[��= '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��n��R�[�h= '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��P= '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��Q= '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��R= '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & ",���ԑ̔ԍ�= '" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",���Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�V�Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�V�������q�敪= '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & ",���͏��= '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & ",�^���P= '" & objUpdate.m�^��1 & "'"
            '        strSQL = strSQL & Chr(10) & ",�^���Q= '" & objUpdate.m�^��2 & "'"
            '        strSQL = strSQL & Chr(10) & ",�^���R= '" & objUpdate.m�^��3 & "'"
            '        strSQL = strSQL & Chr(10) & ",�R��= '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & ",�������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�C�ӕی��ԍ�= '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�g�p�҃R�[�h= '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԍ��g�p�҃R�[�h= '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԍ����L�҃R�[�h= '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            '        strSQL = strSQL & Chr(10) & ",�A���ؑ֓�= '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & ",��Ԓ��= '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��P         = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��Q         = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��R         = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ���q�ԍ��̕ύX����ŐV�Ԃ̏ꍇ�̑�ւ͉c�Ǝ��q�}�X�^�����݂��Ȃ��̂ł����ŁA�c�Ǝ��q�}�X�^�͍쐬�����
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// NO�ύX���ꂽ��֌��̉c�Ǝ��q�}�X�^�̍X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET "
            strSQL = strSQL & Chr(10) & "    �{���҃R�[�h�P = NULL "
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL "
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�ؑ֓� & "' "
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE "
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "' "
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "' "
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "' "
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "' "
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "' "
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "' "
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�ɑ�֌��ŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = "" : strValSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO ���q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q��� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p����":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���T�C�N������ & "'"

            strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

            strSQL = strSQL & strValSQL

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL"
            '// 2009/09/30 ��֌��̎��q�ɋ����q�ԍ����X�V���Ă���
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h   = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P           = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q           = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R           = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '1'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '3'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

        ''** Add-Start 2009/10/06 KSR ********************��
        ''** ���q�}�X�^�̂ݍX�V���ɉc�Ǝ��q�̔p�ԓ��ɐؑ֓���]��
        If pstr���s�t���O = "1" Then
            ''** �c�Ǝ��q�}�X�^�p�ԓ��X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET "
            strSQL = strSQL & Chr(10) & "    �p�ԓ� = '" & objUpdate.m�ؑ֓� & "' "
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE "
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"

            ''** SQL���s
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If
        ''** Add-End   2009/10/06 KSR ********************��

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate���4
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̑�֏���
    ' ���@�@�l  : �V�E�����q�ԍ����Ⴂ�ŁA�ԑ̂������̑��
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  �j�r�q             ���q�}�X�^�̑�֌��̎��q�ɋ����q�ԍ����X�V���Ă���
    '               2010/03/24  �j�r�q             ���q�ԍ����ύX�����ꍇ�͌����q�̍ŏI�����ԍ��ɖ����ԍ���]�����Ă���
    '                                              �����̍��ڂ�NULL�X�V���~�߂�
    '******************************************************************************
    Private Sub msubUpdate���4(ByRef objUpdate As ���q���, ByVal pstr���s�t���O As String)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then
            '// NO�ύX���ꂽ��֐�̉c�Ǝ��q�}�X�^�̍X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "    �N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            'strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���Ж� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ��P & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ��Q & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ��R & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ���q�ԍ��̕ύX����ŕۗ����q����̑�ւ̏ꍇ�̑�ւ͉c�Ǝ��q�}�X�^�����݂��Ă���̂ł����ŁA�c�Ǝ��q�}�X�^�͊�{�I�ɍ쐬����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// NO�ύX���ꂽ��֌��̉c�Ǝ��q�}�X�^�̍X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�ɑ�֌��ŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL"
            '// 2009/09/30 ��֌��̎��q�ɋ����q�ԍ����X�V���Ă���
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h   = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P           = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q           = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R           = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '1'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '3'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = NULL "
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

        ''** Add-Start 2009/10/06 KSR ********************��
        ''** ���q�}�X�^�̂ݍX�V���ɉc�Ǝ��q�̔p�ԓ��ɐؑ֓���]��
        If pstr���s�t���O = "1" Then
            ''** �c�Ǝ��q�}�X�^�p�ԓ��X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET "
            strSQL = strSQL & Chr(10) & "    �p�ԓ� = '" & objUpdate.m�ؑ֓� & "' "
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE "
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"

            ''** SQL���s
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If
        ''** Add-End   2009/10/06 KSR ********************��

    End Sub
    Private Sub msubUpdate�c�Ə���(ByRef objUpdate As ���q���)

        Select Case objUpdate.m���q�}�X�^�X�V�敪�c�ƈړ�

            Case "1"

                Call msubUpdate�c�Ə���1(objUpdate)

            Case "2"

                Call msubUpdate�c�Ə���2(objUpdate)

        End Select

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate�c�Ə���1
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉c�Ə��Ԉړ�����
    ' ���@�@�l  : �ړ��̑ΏۂɂȂ������q�́A�����ԍ��Ɩ����ԍ���NULL�ɂȂ�
    '           : �V�E�����q�ԍ�������
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  �j�r�q             ���q�ԍ����ύX����Ȃ��ꍇ�͍ŏI�����ԍ��͓]������NULL�X�V���s���B�����̍��ڂ�NULL�X�V���~�߂�
    '******************************************************************************
    Private Sub msubUpdate�c�Ə���1(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "    �N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���Ж� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ��P & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ��Q & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ��R & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�Ɏ��q�ԍ��̕ύX�Ȃ��̉c�Ə��ړ��ŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub
    '******************************************************************************
    ' �� �� ��  : msubUpdate�c�Ə���2
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉c�Ə��Ԉړ�����
    ' ���@�@�l  : �ړ��̑ΏۂɂȂ������q�́A�����ԍ��Ɩ����ԍ���NULL�ɂȂ�
    '           : �V�E�����q�ԍ����Ⴄ
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  �j�r�q             ���q�ԍ����ύX�����ꍇ�͌����q�̍ŏI�����ԍ��ɖ����ԍ���]�����Ă���
    '                                              �����̍��ڂ�NULL�X�V���~�߂�
    '******************************************************************************
    Private Sub msubUpdate�c�Ə���2(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            '// NO�ύX���ꂽ�ړ���̉c�Ǝ��q�}�X�^�̍X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "    �N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���Ж� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ���q�ԍ��̕ύX����̏ꍇ�̉c�Ə��ړ��͉c�Ǝ��q�}�X�^�����݂��Ȃ��̂ł����ŁA�c�Ǝ��q�}�X�^�͍쐬�����
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "' " '// 2010/03/26
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "' " '// 2010/03/26
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If
            '// NO�ύX���ꂽ�ړ����̉c�Ǝ��q�}�X�^�̍X�V
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�ɉc�Ə��ړ��ŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub
    '******************************************************************************
    ' �� �� ��  : msubUpdate��ЊԌ���
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉�ЊԈړ����ԏ���
    ' ���@�@�l  : ���Ԃ̑ΏۂɂȂ������q�́A�����ԍ��Ɩ����ԍ���NULL�ɂȂ�
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  �j�r�q             �ŏI�����ԍ��̓]����ǉ�
    '******************************************************************************
    Private Sub msubUpdate��ЊԌ���(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = NULL"
            strSQL = strSQL & Chr(10) & "   ,���l     = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// ��{�I�Ɍ��Ԃ�����q�ŉc�Ǝ��q�}�X�^�����݂��Ȃ��P�[�X�͂��肦�Ȃ��̂ł�����INSERT�͎��s����邱�Ƃ͂Ȃ�
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        If objUpdate.m���ԍς݃t���O <> "" Then
            Exit Sub
        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = NULL "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL "
            strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = NULL "
            '        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '3'"
            '    strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate��Њԑ���
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�̉�ЊԈړ����ԏ���
    ' ���@�@�l  : ���Ԃ̑ΏۂɂȂ������q�́A�����ԍ��Ɩ����ԍ���NULL�ɂȂ�
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  �j�r�q             ��ЊԈړ����Ԃ��ꂽ�ۂɁA�ŏI�����ԍ����]������Ă��邽�߁A���Ԏ���NULL�ɂ���
    '******************************************************************************
    Private Sub msubUpdate��Њԑ���(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        strSQL = strSQL & strValSQL

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & " �Ԗ�= '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & " �N��= '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & ",�G���W���^��= '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & ",�ԑ̔ԍ�= '" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�^��= '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & ",�敪= '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���q�敪= '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�t�@�[�X�g= '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & ",�o�^�N����= '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & ",���q�{�̉��i= '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & ",�擾��= '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & ",�G�A�R�����i= '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & ",�������[�^�[���i= '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & ",�^�R���[�^�[���i= '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & ",���̑���p= '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & ",��ԋ敪= '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & ",�����R�[�h= '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���q�o�^�����R�[�h= '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�����ԍ�= '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�{���҃R�[�h�P= '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�P= '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & ",���p�����P= '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & ",���p�݌v�z�P= '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & ",�`�s���p��P= '" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & ",�{���҃R�[�h�Q= '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�Q= '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & ",���p�����Q= '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & ",���p�݌v�z�Q= '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & ",�`�s���p��Q= '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z= '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & ",�d�b�ԍ�= '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԍ�= '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�ی����= '" & objUpdate.m�ی���Ж� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԕی�������= '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Җ�����= '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Җ��J�i= '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���җX�֔ԍ��P= '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���җX�֔ԍ��Q= '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ғs���{������= '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ҏs��S����= '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ғ����Ԓn����= '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ҍ�������= '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ғs���{���J�i= '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ҏs��S�J�i= '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���Ғ����Ԓn�J�i= '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�ی��\���ҍ����J�i= '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & ",�������_����= '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & ",����Ԍ���= '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & ",��֗\���= '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & ",�c�Ə��o�ɓ�= '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & ",�������ɓ�= '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & ",�c�Ə����ɗ\���= '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & ",����������= '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & ",�c�Ə����ɓ�= '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & ",�p�ԓ�= NULL "
            strSQL = strSQL & Chr(10) & ",�����ӓo�^�ԍ�= '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ӕی���= '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & ",�d�ʐ�= '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & ",�����Ԑ�= '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ԓo�^�ԍ�= '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�����ؗL������= '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & ",���l= '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & ",�R��= '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & ",�X�V�]�ƈ��R�[�h= '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & ",�X�V���t����= SYSDATE"
            strSQL = strSQL & Chr(10) & ",��㎞��= '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & ",�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & ",��ЃR�[�h= '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���q�o�^��ЃR�[�h= '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�匎= '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z����= '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�R��= '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & ",�R���敪= '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & ",�p�r�敪= '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���p���z�[��= '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��n��R�[�h= '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��P= '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��Q= '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & ",�V���q�ԍ��R= '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & ",���ԑ̔ԍ�= '" & objUpdate.m�ԑ̔ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",���Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�V�Ԏ�R�[�h= '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",���������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�V�������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",���͏��= '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & ",�^���P= '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & ",�^���Q= '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & ",�^���R= '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & ",�R��= '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & ",�������q�敪= '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & ",�C�ӕی��ԍ�= '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & ",�g�p�҃R�[�h= '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԍ��g�p�҃R�[�h= '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�Ԍ����L�҃R�[�h= '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & ",�A���ؑ֓�= '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & ",��Ԓ��= '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��P         = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��Q         = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & " AND ���q�ԍ��R         = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            If objUpdate.m���q�}�X�^�X�V�敪��Јړ� = "1" Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
                '            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
                strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                    strSQL = "" : strValSQL = ""
                    strSQL = strSQL & Chr(10) & "INSERT INTO ���q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                    strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                    strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                    strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                    strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                    strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                    strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                    strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                    strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                    '                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���͔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��̕񍐓��t & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ړ��񍐔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�w�����e�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֋敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q��� & "'"
                    'strSQL = strSQL & Chr(10) & "   ,���p����":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                    strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�i���o�[�F�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�J�[�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���L�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���L�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�X��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,����o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����o�^�N���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���T�C�N������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���T�C�N������ & "'"
                    strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                    strSQL = strSQL & strValSQL

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

            Else

                strSQL = ""
                strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
                '            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
                strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                    strSQL = "" : strValSQL = ""
                    strSQL = strSQL & Chr(10) & "INSERT INTO ���q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                    strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                    strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                    strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                    strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                    strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                    strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                    strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                    strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                    '                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���͔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��̕񍐓��t & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ړ��񍐔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�w�����e�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֋敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q��� & "'"
                    'strSQL = strSQL & Chr(10) & "   ,���p����":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                    strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�i���o�[�F�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�J�[�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���L�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���L�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�X��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,����o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����o�^�N���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���T�C�N������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���T�C�N������ & "'"
                    strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                    strSQL = strSQL & strValSQL

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

            End If

            '        Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate�Зp�Ԑؑ�
    ' �X�R�[�v  : Private
    ' �������e  : �ۗ����q����Зp�Ԃɐ؂�ւ��鏈��(���q���="2"�ɂȂ�܂�)
    ' ���@�@�l  : �c�Ǝ��q�}�X�^�̍X�V�͔������܂���
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate�Зp�Ԑؑ�(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL "
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            'strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL "
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            'strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            'strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO ���q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�ԓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��̕񍐓��t & "'"
                strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ړ��񍐔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�w�����e�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ؑ֋敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�i���o�[�F�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�J�[�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���L�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���L�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���[�X��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,����o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���T�C�N������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���T�C�N������ & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate�p��
    ' �X�R�[�v  : Private
    ' �������e  : �ۗ����q����p�Ԃɐ؂�ւ��鏈��(���q���="5"�ɂȂ�܂�)
    ' ���@�@�l  : �c�Ǝ��q�}�X�^�̍X�V�͔������܂���
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate�p��(ByRef objUpdate As ���q���)

        Dim strSQL As String

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate���p
    ' �X�R�[�v  : Private
    ' �������e  : �ۗ����q���甄�p�ɐ؂�ւ��鏈��(���q���="4"�ɂȂ�܂�)
    ' ���@�@�l  : �c�Ǝ��q�}�X�^�̍X�V�͔������܂���
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate���p(ByRef objUpdate As ���q���)

        Dim strSQL As String

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���� = '" & objUpdate.m���p���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate�ۗ��Ԑؑ�
    ' �X�R�[�v  : Private
    ' �������e  : �Зp�Ԃ���ۗ��Ԃɐ؂�ւ��鏈��(���q���="3"�ɂȂ�܂�)
    ' ���@�@�l  : �c�Ǝ��q�}�X�^�̍X�V�͔������܂���
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate�ۗ��Ԑؑ�(ByRef objUpdate As ���q���)

        Dim strSQL As String

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    �p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��n��R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = ���q�ԍ��n��R�[�h"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = ���q�ԍ��P"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = ���q�ԍ��Q"
            strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = ���q�ԍ��R"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = NULL"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = NULL"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '�c�Ǝ��q�}�X�^�Ɏԑ̔ԍ��ōX�V���鏈����ǉ�����K�v�L�H

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : msubUpdate�}�X�^�����e
    ' �X�R�[�v  : Private
    ' �������e  : ���q�}�X�^�Ɖc�Ǝ��q�}�X�^�̍X�V����
    ' ���@�@�l  : ���q�}�X�^�X�V�敪���q�����e="1"�̏ꍇ�́A�����I�ȍ폜�������s���܂�
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate�}�X�^�����e(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String

        '// ���q�}�X�^�Ɖc�Ǝ��q�}�X�^�̕����I�ȍ폜
        If objUpdate.m���q�}�X�^�X�V�敪���q�����e = "1" Then

            '// ���q�}�X�^�̍폜
            If objUpdate.m�����Ώۃt���O = "1" Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "DELETE FROM ���q�}�X�^"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// �c�Ǝ��q�}�X�^�̍폜
            If objUpdate.m�����Ώۃt���O = "2" Then

                If objUpdate.m���q��� = "1" Then

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "DELETE FROM �c�Ǝ��q�}�X�^"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

            End If

        Else
            '// ���q�}�X�^�Ɖc�Ǝ��q�}�X�^�̍X�V����
            '// ���q�}�X�^�̍X�V
            If objUpdate.m�����Ώۃt���O = "1" Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
                strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
                strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '" & objUpdate.m�ؑ֋敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q��� = '" & objUpdate.m���q��� & "'"
                'strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// �c�Ǝ��q�}�X�^�̍X�V
            If objUpdate.m�����Ώۃt���O = "2" Then

                If objUpdate.m���q��� = "1" Then

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
                    strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
                    strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
                    strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
                    strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
                    strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = '" & objUpdate.m�p�ԓ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
                    strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ��P & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ��Q & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ��R & "'"
                    strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
                    strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
                    strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
                    strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                    strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
                    strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
                    strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                        strSQL = "" : strValSQL = ""
                        strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                        strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                        strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                        strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                        strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                        strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                        strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                        strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�ԓ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                        strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                        strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                        strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                        strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���Ԏ�R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,���������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������q�敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�V�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,���͏��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���͏�� & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                        strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                        strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                        strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                        strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                        strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                        strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                        strSQL = strSQL & strValSQL

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                    End If

                End If

            End If

        End If

    End Sub
    '******************************************************************************
    ' �� �� ��  : msubUpdate�ۗ�����
    ' �X�R�[�v  : Private
    ' �������e  : �c�Ǝ��q�}�X�^�Ǝ��q�}�X�^�ۗ̕��Ԃ���̑��ԏ���
    ' ���@�@�l  : ���Ԃ̑ΏۂɂȂ������q�́A���ꂼ��̃}�X�^��UPDATE���s����
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           �@I     ���q�ٓ��e�[�u�����擾�����l
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate�ۗ�����(ByRef objUpdate As ���q���)

        Dim strSQL As String
        Dim strValSQL As String
        Dim intRet As Short

        '// �c�Ǝ��q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE �c�Ǝ��q�}�X�^ SET"
            '        strSQL = strSQL & Chr(10) & "    �Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "    �N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���Ж� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = NULL "
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P = '" & objUpdate.m�����q�ԍ��P & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q = '" & objUpdate.m�����q�ԍ��Q & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R = '" & objUpdate.m�����q�ԍ��R & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ� = '" & objUpdate.m���ԑ̔ԍ� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h = '" & objUpdate.m���Ԏ�R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���������q�敪 = '" & objUpdate.m���������q�敪 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�V�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            '        strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            intRet = gobjOraDatabase.ExecuteSQL(strSQL)

            If intRet = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO �c�Ǝ��q�}�X�^ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ�3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԗ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԗ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�N��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�N�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G���W���^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G���W���^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ԑ̔ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ԑ̔ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�^��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�t�@�[�X�g & "'"
                strSQL = strSQL & Chr(10) & "   ,�o�^�N����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�o�^�N���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�{�̉��i & "'"
                strSQL = strSQL & Chr(10) & "   ,�擾��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�擾�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�G�A�R�����i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^�R���[�^�[���i & "'"
                strSQL = strSQL & Chr(10) & "   ,���̑���p" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���̑���p & "'"
                strSQL = strSQL & Chr(10) & "   ,��ԋ敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ԋ敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^�����R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����1 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��1 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,���p�c�����P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����P & "'"
                strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�{���҃R�[�h2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�����Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p����2 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�݌v�z2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT���p��2 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,���p�c�����Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p�c�����Q & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�b�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی���Ж� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԕی�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԕی������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ�����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ����� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Җ��J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{������ & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ�������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ғs���{���J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ی��\���ҍ����J�i & "'"
                strSQL = strSQL & Chr(10) & "   ,�������_����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������_���� & "'"
                strSQL = strSQL & Chr(10) & "   ,����Ԍ���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m����Ԍ��� & "'"
                strSQL = strSQL & Chr(10) & "   ,��֗\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��֗\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə��o�ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɗ\��� & "'"
                strSQL = strSQL & Chr(10) & "   ,����������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���������� & "'"
                strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�c�Ə����ɓ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�ԓ�" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ӕی���" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ӕی��� & "'"
                strSQL = strSQL & Chr(10) & "   ,�d�ʐ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�d�ʐ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����Ԑ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����Ԑ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ԓo�^�ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�����ؗL������" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�����ؗL������ & "'"
                strSQL = strSQL & Chr(10) & "   ,���l" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���l & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,�X�V���t����" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,��㎞��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��㎞�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�ŏI�����ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�o�^��ЃR�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�匎" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�匎 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z����" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z���� & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z3�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�R���敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R���敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�p�r�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�p�r�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,���p���z�[��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���p���z�[�� & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��n��R�[�h":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��n��R�[�h & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��P":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��P & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��Q":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��Q & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�V���q�ԍ��R":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���q�ԍ��R & "'"
                '        strSQL = strSQL & Chr(10) & "   ,���ԑ̔ԍ�":                   strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m���ԑ̔ԍ� & "'"
                '        strSQL = strSQL & Chr(10) & "   ,���Ԏ�R�[�h":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�V�Ԏ�R�[�h":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԏ�R�[�h & "'"
                '        strSQL = strSQL & Chr(10) & "   ,���������q�敪":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�V�������q�敪":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,���͏��":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '        strSQL = strSQL & Chr(10) & "   ,�ύX���":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���P" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��1 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���Q" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��2 & "'"
                strSQL = strSQL & Chr(10) & "   ,�^���R" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�^��3 & "'"
                strSQL = strSQL & Chr(10) & "   ,�R��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�R�� & "'"
                strSQL = strSQL & Chr(10) & "   ,�������q�敪" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�������q�敪 & "'"
                strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�C�ӕی��ԍ� & "'"
                strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
                strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓�" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m�A���ؑ֓� & "'"
                strSQL = strSQL & Chr(10) & "   ,��Ԓ��" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m��Ԓ�� & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// ���q�}�X�^�݂̂̍X�V
        If objUpdate.m�����Ώۃt���O = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ SET"
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & objUpdate.m���q�ԍ��n��R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P = '" & objUpdate.m���q�ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q = '" & objUpdate.m���q�ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R = '" & objUpdate.m���q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԗ� = '" & objUpdate.m�Ԗ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�N�� = '" & objUpdate.m�N�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G���W���^�� = '" & objUpdate.m�G���W���^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�� = '" & objUpdate.m�^�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�敪 = '" & objUpdate.m�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�敪 = '" & objUpdate.m���q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g = '" & objUpdate.m�t�@�[�X�g & "'"
            strSQL = strSQL & Chr(10) & "   ,�o�^�N���� = '" & objUpdate.m�o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�{�̉��i = '" & objUpdate.m���q�{�̉��i & "'"
            strSQL = strSQL & Chr(10) & "   ,�擾�� = '" & objUpdate.m�擾�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�G�A�R�����i = '" & objUpdate.m�G�A�R�����i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������[�^�[���i = '" & objUpdate.m�������[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,�^�R���[�^�[���i = '" & objUpdate.m�^�R���[�^�[���i & "'"
            strSQL = strSQL & Chr(10) & "   ,���̑���p = '" & objUpdate.m���̑���p & "'"
            strSQL = strSQL & Chr(10) & "   ,��ԋ敪 = '" & objUpdate.m��ԋ敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�����R�[�h = '" & objUpdate.m�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & objUpdate.m���q�o�^�����R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�P = '" & objUpdate.m�{���҃R�[�h1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�P = '" & objUpdate.m���p���z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����P = '" & objUpdate.m���p����1 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�P = '" & objUpdate.m���p�݌v�z1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��P = '" & objUpdate.mAT���p��1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����P = '" & objUpdate.m���p�c�����P & "'"
            strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q = '" & objUpdate.m�{���҃R�[�h2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�Q = '" & objUpdate.m���p���z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�����Q = '" & objUpdate.m���p����2 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p�݌v�z�Q = '" & objUpdate.m���p�݌v�z2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�`�s���p��Q = '" & objUpdate.mAT���p��2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,���p�c�����Q = '" & objUpdate.m���p�c�����Q & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z = '" & objUpdate.m���p���z & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�b�ԍ� = '" & objUpdate.m�d�b�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԍ� = '" & objUpdate.m�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی���� = '" & objUpdate.m�ی���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԕی������� = '" & objUpdate.m�����ԕی������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ����� = '" & objUpdate.m�ی��\���Җ����� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Җ��J�i = '" & objUpdate.m�ی��\���Җ��J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��P = '" & objUpdate.m�ی��\���җX�֔ԍ�1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���җX�֔ԍ��Q = '" & objUpdate.m�ی��\���җX�֔ԍ�2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{������ = '" & objUpdate.m�ی��\���ғs���{������ & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S���� = '" & objUpdate.m�ی��\���Ҏs��S���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn���� = '" & objUpdate.m�ی��\���Ғ����Ԓn���� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ������� = '" & objUpdate.m�ی��\���ҍ������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ғs���{���J�i = '" & objUpdate.m�ی��\���ғs���{���J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ҏs��S�J�i = '" & objUpdate.m�ی��\���Ҏs��S�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���Ғ����Ԓn�J�i = '" & objUpdate.m�ی��\���Ғ����Ԓn�J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�ی��\���ҍ����J�i = '" & objUpdate.m�ی��\���ҍ����J�i & "'"
            strSQL = strSQL & Chr(10) & "   ,�������_���� = '" & objUpdate.m�������_���� & "'"
            strSQL = strSQL & Chr(10) & "   ,����Ԍ��� = '" & objUpdate.m����Ԍ��� & "'"
            strSQL = strSQL & Chr(10) & "   ,��֗\��� = '" & objUpdate.m��֗\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə��o�ɓ� = '" & objUpdate.m�c�Ə��o�ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������ɓ� = '" & objUpdate.m�������ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɗ\��� = '" & objUpdate.m�c�Ə����ɗ\��� & "'"
            strSQL = strSQL & Chr(10) & "   ,���������� = '" & objUpdate.m���������� & "'"
            strSQL = strSQL & Chr(10) & "   ,�c�Ə����ɓ� = '" & objUpdate.m�c�Ə����ɓ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�ԓ� = NULL"
            strSQL = strSQL & Chr(10) & "   ,�����ӓo�^�ԍ� = '" & objUpdate.m�����ӓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ӕی��� = '" & objUpdate.m�����ӕی��� & "'"
            strSQL = strSQL & Chr(10) & "   ,�d�ʐ� = '" & objUpdate.m�d�ʐ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����Ԑ� = '" & objUpdate.m�����Ԑ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ԓo�^�ԍ� = '" & objUpdate.m�����ԓo�^�ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�����ؗL������ = '" & objUpdate.m�����ؗL������ & "'"
            strSQL = strSQL & Chr(10) & "   ,���l = '" & objUpdate.m���l & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,��㎞�� = '" & objUpdate.m��㎞�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�ŏI�����ԍ� = '" & objUpdate.m�ŏI�����ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h = '" & objUpdate.m��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԏ�R�[�h = '" & objUpdate.m�Ԏ�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & objUpdate.m���q�o�^��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�匎 = '" & objUpdate.m���p���z�匎 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z���� = '" & objUpdate.m���p���z���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�R�� = '" & objUpdate.m���p���z3�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�R���敪 = '" & objUpdate.m�R���敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�p�r�敪 = '" & objUpdate.m�p�r�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���p���z�[�� = '" & objUpdate.m���p���z�[�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͔ԍ� = '" & objUpdate.m���͔ԍ� & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��n��R�[�h = '" & objUpdate.m�����q�ԍ��n��R�[�h & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��P = '" & objUpdate.m�����q�ԍ�1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��Q = '" & objUpdate.m�����q�ԍ�2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,�����q�ԍ��R = '" & objUpdate.m�����q�ԍ�3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���P = '" & objUpdate.m�^��1 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���Q = '" & objUpdate.m�^��2 & "'"
            strSQL = strSQL & Chr(10) & "   ,�^���R = '" & objUpdate.m�^��3 & "'"
            strSQL = strSQL & Chr(10) & "   ,�R�� = '" & objUpdate.m�R�� & "'"
            strSQL = strSQL & Chr(10) & "   ,�������q�敪 = '" & objUpdate.m�������q�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�C�ӕی��ԍ� = '" & objUpdate.m�C�ӕی��ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,�g�p�҃R�[�h = '" & objUpdate.m�g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ��g�p�҃R�[�h = '" & objUpdate.m�Ԍ��g�p�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�Ԍ����L�҃R�[�h = '" & objUpdate.m�Ԍ����L�҃R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓� = '" & objUpdate.m�ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,�A���ؑ֓� = '" & objUpdate.m�A���ؑ֓� & "'"
            strSQL = strSQL & Chr(10) & "   ,��Ԓ�� = '" & objUpdate.m��Ԓ�� & "'"
            strSQL = strSQL & Chr(10) & "   ,��̕񍐓��t = '" & objUpdate.m��̕񍐓��t & "'"
            strSQL = strSQL & Chr(10) & "   ,�ړ��񍐔ԍ� = '" & objUpdate.m�ړ��񍐔ԍ� & "'"
            strSQL = strSQL & Chr(10) & "   ,���͏�� = '" & objUpdate.m���͏�� & "'"
            strSQL = strSQL & Chr(10) & "   ,���ԑ�֋敪 = '" & objUpdate.m�w�����e�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,�ؑ֋敪 = '1'"
            strSQL = strSQL & Chr(10) & "   ,���q��� = '1'"
            '    strSQL = strSQL & Chr(10) & "   ,���p���� = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,�i���o�[�F�敪 = '" & objUpdate.m�i���o�[�F�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�J�[�R�[�h = '" & objUpdate.m���[�J�[�R�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,���L�敪 = '" & objUpdate.m���L�敪 & "'"
            strSQL = strSQL & Chr(10) & "   ,���[�X��ЃR�[�h = '" & objUpdate.m���[�X��ЃR�[�h & "'"
            strSQL = strSQL & Chr(10) & "   ,����o�^�N���� = '" & objUpdate.m����o�^�N���� & "'"
            strSQL = strSQL & Chr(10) & "   ,���T�C�N������ = '" & objUpdate.m���T�C�N������ & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    �ԑ̔ԍ� = '" & objUpdate.m�ԑ̔ԍ� & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' �� �� ��  : gsubUpdateNewShopCarTransfer
    ' �X�R�[�v  : Private
    ' �������e  : �V�������쐬���ꂽ�ꍇ�ɁA���Ԃ���Ă�����q�̎��q�}�X�^�Ɖc�Ǝ��q�}�X�^���쐬����
    '             �ׂ̏���
    ' ���@�@�l  : ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstr���             String        �@   I     ���񏈗����s���Ώۂ̉�ЃR�[�h
    '   pstr����             String        �@   I     ���񏈗����s���Ώۂ̕����R�[�h
    '   pstr�c�Ɠ����       String             I     ���񏈗����s���Ώۂ̉c�Ɠ����(yyyymmdd�`��)
    '   pstr���s�t���O       String             I     1:���q�}�X�^�̂ݍX�V 2:�c�Ǝ��q�}�X�^�̂ݍX�V 3:�ǂ�����X�V
    '   pstr�X�e�[�^�X       String            I/O    �ǂ̒i�K�܂ŏ�����������ł��邩���Z�b�g
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2009/10/22  �j�r�q             �V�K�쐬
    '               2010/05/31  �j�r�q             �{���җ����e�[�u������Q�Ƃ���敪��ؑ֋敪������q�}�X�^���f�敪�ɕύX����
    '******************************************************************************
    Public Function gsubUpdateNewShopCarTransfer(ByVal pstr��� As String, ByVal pstr���� As String, ByVal pstr�c�Ɠ���� As String, ByVal pstr���s�t���O As String, ByRef pstr�X�e�[�^�X As String, ByVal pstrSEQ As String) As Object

        Dim strSQL As String
        Dim objDynaset As Object
        Dim objUpdataParam As ���q���

        pstr�X�e�[�^�X = "���q�ٓ��e�[�u������Ώۃf�[�^���o"
        strSQL = ""
        If pstr���s�t���O = "1" Or pstr���s�t���O = "3" Then
            '// ���q�}�X�^�̍X�V�̏I����Ă��Ȃ����q�ٓ��e�[�u��
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.�ԑ̔ԍ�                               ,CPT.�w�����e�敪                           ,CPT.���q�ԍ��n��R�[�h                     ,CPT.���q�ԍ��P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�ԍ��Q                             ,CPT.���q�ԍ��R                             ,CPT.�Ԗ�                                   ,CPT.�N��                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�G���W���^��                           ,CPT.�^��                                   ,CPT.�敪                                   ,CPT.���q�敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�R���R�[�h                             ,CPT.�t�@�[�X�g                             ,CPT.�o�^�N����                             ,CPT.���q�{�̉��i                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�擾��                                 ,CPT.�G�A�R�����i                           ,CPT.�������[�^�[���i                       ,CPT.�^�R���[�^�[���i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.���̑���p                             ,CPT.��ԋ敪                               ,CPT.�����R�[�h                             ,CPT.���q�o�^�����R�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ԍ�                               ,CPT.�{���҃R�[�h�P                         ,CPT.���p���z�P                             ,CPT.���p�����P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�݌v�z�P                           ,CPT.�`�s���p��P                           ,CPT.���p�c�����P                           ,CPT.�{���҃R�[�h�Q                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�Q                             ,CPT.���p�����Q                             ,CPT.���p�݌v�z�Q                           ,CPT.�`�s���p��Q                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�c�����Q                           ,CPT.���p���z                               ,CPT.�d�b�ԍ�                               ,CPT.�����ԍ�                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی����                               ,CPT.�����ԕی�������                       ,CPT.�ی��\���Җ�����                       ,CPT.�ی��\���Җ��J�i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���җX�֔ԍ��P                   ,CPT.�ی��\���җX�֔ԍ��Q                   ,CPT.�ی��\���ғs���{������                 ,CPT.�ی��\���Ҏs��S����                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn����                 ,CPT.�ی��\���ҍ�������                     ,CPT.�ی��\���ғs���{���J�i                 ,CPT.�ی��\���Ҏs��S�J�i                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn�J�i                 ,CPT.�ی��\���ҍ����J�i                     ,CPT.�������_����                         ,CPT.����Ԍ���                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.��֗\���                             ,CPT.�c�Ə��o�ɓ�                           ,CPT.�������ɓ�                             ,CPT.�c�Ə����ɗ\���                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.����������                             ,CPT.�c�Ə����ɓ�                           ,CPT.�p�ԓ�                                 ,CPT.�����ӓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ӕی���                           ,CPT.�d�ʐ�                                 ,CPT.�����Ԑ�                               ,CPT.�����ԓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ؗL������                         ,CPT.���l                                   ,CPT.�R��                                   ,CPT.��㎞��                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ŏI�����ԍ�                           ,CPT.��ЃR�[�h                             ,CPT.�Ԏ�R�[�h                             ,CPT.���q�o�^��ЃR�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�匎                           ,CPT.���p���z����                           ,CPT.���p���z�R��                           ,CPT.�R���敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�p�r�敪                               ,CPT.���p���z�[��                           ,CPT.���͔ԍ�                               ,CPT.�����q�ԍ��n��R�[�h                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����q�ԍ��P                           ,CPT.�����q�ԍ��Q                           ,CPT.�����q�ԍ��R                           ,CPT.�^���P                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.�^���Q                                 ,CPT.�^���R                                 ,CPT.�R��                                   ,CPT.�������q�敪                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�C�ӕی��ԍ�                           ,CPT.�g�p�҃R�[�h                           ,CPT.�Ԍ��g�p�҃R�[�h                       ,CPT.�Ԍ����L�҃R�[�h                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ؑ֓�                                 ,CPT.�A���ؑ֓�                             ,CPT.��Ԓ��                               ,CPT.��̕񍐓��t                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ړ��񍐔ԍ�                           ,CPT.���͏��                               ,CPT.���ԑ�֋敪                           ,CPT.�ؑ֋敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q���                               ,CPT.���q�v�揈��SEQ                        ,CPT.���q�o�^�t���O                         ,CPT.����m�����                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p����                             ,CPT.����ЃR�[�h                           ,CPT.�������R�[�h                           ,CPT.���c�Ǝ��q�敪                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���������q�敪                         ,CPT.���ؑ֓�                               ,CPT.���Ԏ�R�[�h                           ,CPT.���ԑ̔ԍ�                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪����                 ,CPT.���q�}�X�^�X�V�敪���                 ,CPT.���q�}�X�^�X�V�敪�c�ƈړ�             ,CPT.���q�}�X�^�X�V�敪��Јړ�          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪���q�����e           ,CPL.���葤���q�v�揈��SEQ                  ,PT2.���q�v�揈��SEQ CSEQ                   ,PT2.�ؑ֓� C�ؑ֓�                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.����m����� ���ԍς݃t���O         "
            strSQL = strSQL & Chr(10) & "   ,'2' AS �����Ώۃt���O " '// 1:�c�Ǝ��q�}�X�^�X�V�Ώ�    2:���q�}�X�^�X�V�Ώ�
            strSQL = strSQL & Chr(10) & "   ,CPT.�i���o�[�F�敪 ,CPT.���[�J�[�R�[�h ,CPT.���L�敪 "
            strSQL = strSQL & Chr(10) & "   ,CPT.���[�X��ЃR�[�h ,CPT.����o�^�N���� ,CPT.���T�C�N������ "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    ���q�ٓ��e�[�u�� CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�v����̓e�[�u�� CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.���q�v�揈��SEQ = CPL.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�ٓ��e�[�u�� PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.���葤���q�v�揈��SEQ = PT2.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN �����}�X�^ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.��ЃR�[�h = BMM.��ЃR�[�h"
            strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = BMM.�����R�[�h"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.���q�o�^�t���O = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.���q�}�X�^����m����� IS NULL"
            '// ���ԁA�ۗ����Ԃɂ��Ă͖����ԍ��Ɛ����ԍ�<>NULL ��ǉ�
            strSQL = strSQL & Chr(10) & "AND  (CPT.�w�����e�敪 IN ('0','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL ) "

            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.���q�v�揈��SEQ = '" & pstrSEQ & "'"
            Else
                strSQL = strSQL & Chr(10) & "AND CPT.�ؑ֓� <= ('" & pstr�c�Ɠ���� & "') "
                '// ��ԃo�b�`���́A�S��Ђ�Ώۂɂ���
                If pstr��� <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.��ЃR�[�h = '" & gfncGetCodeToControl(pstr���, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = '" & gfncGetCodeToControl(pstr����, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.�c�Ƌ敪 = '0'))"
                End If

            End If

        End If

        If pstr���s�t���O = "3" Then
            strSQL = strSQL & Chr(10) & "UNION ALL ( "
        End If

        If pstr���s�t���O = "2" Or pstr���s�t���O = "3" Then
            '// �c�Ǝ��q�}�X�^�̍X�V�̏I����Ă��Ȃ����q�ٓ��e�[�u��
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.�ԑ̔ԍ�                               ,CPT.�w�����e�敪                           ,CPT.���q�ԍ��n��R�[�h                     ,CPT.���q�ԍ��P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�ԍ��Q                             ,CPT.���q�ԍ��R                             ,CPT.�Ԗ�                                   ,CPT.�N��                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�G���W���^��                           ,CPT.�^��                                   ,CPT.�敪                                   ,CPT.���q�敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�R���R�[�h                             ,CPT.�t�@�[�X�g                             ,CPT.�o�^�N����                             ,CPT.���q�{�̉��i                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�擾��                                 ,CPT.�G�A�R�����i                           ,CPT.�������[�^�[���i                       ,CPT.�^�R���[�^�[���i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.���̑���p                             ,CPT.��ԋ敪                               ,CPT.�����R�[�h                             ,CPT.���q�o�^�����R�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ԍ�                               ,CPT.�{���҃R�[�h�P                         ,CPT.���p���z�P                             ,CPT.���p�����P                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�݌v�z�P                           ,CPT.�`�s���p��P                           ,CPT.���p�c�����P                           ,CPT.�{���҃R�[�h�Q                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�Q                             ,CPT.���p�����Q                             ,CPT.���p�݌v�z�Q                           ,CPT.�`�s���p��Q                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p�c�����Q                           ,CPT.���p���z                               ,CPT.�d�b�ԍ�                               ,CPT.�����ԍ�                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی����                               ,CPT.�����ԕی�������                       ,CPT.�ی��\���Җ�����                       ,CPT.�ی��\���Җ��J�i                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���җX�֔ԍ��P                   ,CPT.�ی��\���җX�֔ԍ��Q                   ,CPT.�ی��\���ғs���{������                 ,CPT.�ی��\���Ҏs��S����                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn����                 ,CPT.�ی��\���ҍ�������                     ,CPT.�ی��\���ғs���{���J�i                 ,CPT.�ی��\���Ҏs��S�J�i                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ی��\���Ғ����Ԓn�J�i                 ,CPT.�ی��\���ҍ����J�i                     ,CPT.�������_����                         ,CPT.����Ԍ���                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.��֗\���                             ,CPT.�c�Ə��o�ɓ�                           ,CPT.�������ɓ�                             ,CPT.�c�Ə����ɗ\���                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.����������                             ,CPT.�c�Ə����ɓ�                           ,CPT.�p�ԓ�                                 ,CPT.�����ӓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ӕی���                           ,CPT.�d�ʐ�                                 ,CPT.�����Ԑ�                               ,CPT.�����ԓo�^�ԍ�                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����ؗL������                         ,CPT.���l                                   ,CPT.�R��                                   ,CPT.��㎞��                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ŏI�����ԍ�                           ,CPT.��ЃR�[�h                             ,CPT.�Ԏ�R�[�h                             ,CPT.���q�o�^��ЃR�[�h                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p���z�匎                           ,CPT.���p���z����                           ,CPT.���p���z�R��                           ,CPT.�R���敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.�p�r�敪                               ,CPT.���p���z�[��                           ,CPT.���͔ԍ�                               ,CPT.�����q�ԍ��n��R�[�h                "
            strSQL = strSQL & Chr(10) & "   ,CPT.�����q�ԍ��P                           ,CPT.�����q�ԍ��Q                           ,CPT.�����q�ԍ��R                           ,CPT.�^���P                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.�^���Q                                 ,CPT.�^���R                                 ,CPT.�R��                                   ,CPT.�������q�敪                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�C�ӕی��ԍ�                           ,CPT.�g�p�҃R�[�h                           ,CPT.�Ԍ��g�p�҃R�[�h                       ,CPT.�Ԍ����L�҃R�[�h                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ؑ֓�                                 ,CPT.�A���ؑ֓�                             ,CPT.��Ԓ��                               ,CPT.��̕񍐓��t                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.�ړ��񍐔ԍ�                           ,CPT.���͏��                               ,CPT.���ԑ�֋敪                           ,CPT.�ؑ֋敪                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q���                               ,CPT.���q�v�揈��SEQ                        ,CPT.���q�o�^�t���O                         ,CPT.����m�����                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.���p����                             ,CPT.����ЃR�[�h                           ,CPT.�������R�[�h                           ,CPT.���c�Ǝ��q�敪                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.���������q�敪                         ,CPT.���ؑ֓�                               ,CPT.���Ԏ�R�[�h                           ,CPT.���ԑ̔ԍ�                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪����                 ,CPT.���q�}�X�^�X�V�敪���                 ,CPT.���q�}�X�^�X�V�敪�c�ƈړ�             ,CPT.���q�}�X�^�X�V�敪��Јړ�          "
            strSQL = strSQL & Chr(10) & "   ,CPT.���q�}�X�^�X�V�敪���q�����e           ,CPL.���葤���q�v�揈��SEQ                  ,PT2.���q�v�揈��SEQ CSEQ                   ,PT2.�ؑ֓� C�ؑ֓�                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.����m����� ���ԍς݃t���O         "
            strSQL = strSQL & Chr(10) & "   ,'1' AS �����Ώۃt���O " '// 1:�c�Ǝ��q�}�X�^�X�V�Ώ�    2:���q�}�X�^�X�V�Ώ�
            strSQL = strSQL & Chr(10) & "   ,CPT.�i���o�[�F�敪 ,CPT.���[�J�[�R�[�h ,CPT.���L�敪 "
            strSQL = strSQL & Chr(10) & "   ,CPT.���[�X��ЃR�[�h ,CPT.����o�^�N���� ,CPT.���T�C�N������ "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    ���q�ٓ��e�[�u�� CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�v����̓e�[�u�� CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.���q�v�揈��SEQ = CPL.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN ���q�ٓ��e�[�u�� PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.���葤���q�v�揈��SEQ = PT2.���q�v�揈��SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN �����}�X�^ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.��ЃR�[�h = BMM.��ЃR�[�h"
            strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = BMM.�����R�[�h"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.���q�o�^�t���O = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.����m����� IS NULL"
            '// ���ԁA�ۗ����Ԃɂ��Ă͖����ԍ��Ɛ����ԍ�<>NULL ��ǉ�
            strSQL = strSQL & Chr(10) & "AND  (CPT.�w�����e�敪 IN ('0','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.�����ԍ� IS NOT NULL ) "
            '// ��ʂ��璼�ڋN������ꍇ�͓��t�̏������݂��Ɏ��q�v�揈��SEQ�Ń��R�[�h��1���ɓ��肵�ď������s��
            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.���q�v�揈��SEQ = '" & pstrSEQ & "'"
            Else
                strSQL = strSQL & Chr(10) & "AND CPT.�ؑ֓� <= ('" & pstr�c�Ɠ���� & "') "
                '// ��ԃo�b�`���́A�S��Ђ�Ώۂɂ���
                If pstr��� <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.��ЃR�[�h = '" & gfncGetCodeToControl(pstr���, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.�����R�[�h = '" & gfncGetCodeToControl(pstr����, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.�c�Ƌ敪 = '0'))"
                End If
            End If
        End If

        If pstr���s�t���O = "3" Then
            strSQL = strSQL & Chr(10) & " ) "
        End If

        strSQL = strSQL & Chr(10) & "ORDER BY"
        strSQL = strSQL & Chr(10) & "    �w�����e�敪,�ԑ̔ԍ� "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDynaset = gobjOraDatabase.CreateDynaset(strSQL, &H1)

        With objDynaset

            'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF = True Then
                pstr�X�e�[�^�X = "���q�Ǘ��@����m��Y���Ȃ�"
                GoTo HONMUTUKEKOMI
            End If

            Do

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstr�X�e�[�^�X = "���q�ٓ��e�[�u���@�Y��SEQ�F" & gfncFieldVal(.Fields("���q�v�揈��SEQ").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ԑ̔ԍ� = gfncFieldVal(.Fields("�ԑ̔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�w�����e�敪 = gfncFieldVal(.Fields("�w�����e�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ��n��R�[�h = gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ�1 = gfncFieldVal(.Fields("���q�ԍ��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ�2 = gfncFieldVal(.Fields("���q�ԍ��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�ԍ�3 = gfncFieldVal(.Fields("���q�ԍ��R").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԗ� = gfncFieldVal(.Fields("�Ԗ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�N�� = gfncFieldVal(.Fields("�N��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�G���W���^�� = gfncFieldVal(.Fields("�G���W���^��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^�� = gfncFieldVal(.Fields("�^��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�敪 = gfncFieldVal(.Fields("�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�敪 = gfncFieldVal(.Fields("���q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R���R�[�h = gfncFieldVal(.Fields("�R���R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�t�@�[�X�g = gfncFieldVal(.Fields("�t�@�[�X�g").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�o�^�N���� = gfncFieldVal(.Fields("�o�^�N����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�{�̉��i = gfncFieldVal(.Fields("���q�{�̉��i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�擾�� = gfncFieldVal(.Fields("�擾��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�G�A�R�����i = gfncFieldVal(.Fields("�G�A�R�����i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������[�^�[���i = gfncFieldVal(.Fields("�������[�^�[���i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^�R���[�^�[���i = gfncFieldVal(.Fields("�^�R���[�^�[���i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���̑���p = gfncFieldVal(.Fields("���̑���p").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��ԋ敪 = gfncFieldVal(.Fields("��ԋ敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����R�[�h = gfncFieldVal(.Fields("�����R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�o�^�����R�[�h = gfncFieldVal(.Fields("���q�o�^�����R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԍ� = gfncFieldVal(.Fields("�����ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�{���҃R�[�h1 = gfncFieldVal(.Fields("�{���҃R�[�h�P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z1 = gfncFieldVal(.Fields("���p���z�P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p����1 = gfncFieldVal(.Fields("���p�����P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�݌v�z1 = gfncFieldVal(.Fields("���p�݌v�z�P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT���p��1 = gfncFieldVal(.Fields("�`�s���p��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�c����1 = gfncFieldVal(.Fields("���p�c�����P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�{���҃R�[�h2 = gfncFieldVal(.Fields("�{���҃R�[�h�Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z2 = gfncFieldVal(.Fields("���p���z�Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p����2 = gfncFieldVal(.Fields("���p�����Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�݌v�z2 = gfncFieldVal(.Fields("���p�݌v�z�Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT���p��2 = gfncFieldVal(.Fields("�`�s���p��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p�c����2 = gfncFieldVal(.Fields("���p�c�����Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z = gfncFieldVal(.Fields("���p���z").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�d�b�ԍ� = gfncFieldVal(.Fields("�d�b�ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԍ� = gfncFieldVal(.Fields("�����ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی���� = gfncFieldVal(.Fields("�ی����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی���Ж� = mfncGetHokenName(gfncFieldVal(.Fields("�ی����").Value)) '// 2010/03/26 �ی���Ж��̎擾��ǉ�
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԕی������� = gfncFieldVal(.Fields("�����ԕی�������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Җ����� = gfncFieldVal(.Fields("�ی��\���Җ�����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Җ��J�i = gfncFieldVal(.Fields("�ی��\���Җ��J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���җX�֔ԍ�1 = gfncFieldVal(.Fields("�ی��\���җX�֔ԍ��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���җX�֔ԍ�2 = gfncFieldVal(.Fields("�ی��\���җX�֔ԍ��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ғs���{������ = gfncFieldVal(.Fields("�ی��\���ғs���{������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ҏs��S���� = gfncFieldVal(.Fields("�ی��\���Ҏs��S����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ғ����Ԓn���� = gfncFieldVal(.Fields("�ی��\���Ғ����Ԓn����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ҍ������� = gfncFieldVal(.Fields("�ی��\���ҍ�������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ғs���{���J�i = gfncFieldVal(.Fields("�ی��\���ғs���{���J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ҏs��S�J�i = gfncFieldVal(.Fields("�ی��\���Ҏs��S�J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���Ғ����Ԓn�J�i = gfncFieldVal(.Fields("�ی��\���Ғ����Ԓn�J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ی��\���ҍ����J�i = gfncFieldVal(.Fields("�ی��\���ҍ����J�i").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������_���� = gfncFieldVal(.Fields("�������_����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����Ԍ��� = gfncFieldVal(.Fields("����Ԍ���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��֗\��� = gfncFieldVal(.Fields("��֗\���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�c�Ə��o�ɓ� = gfncFieldVal(.Fields("�c�Ə��o�ɓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������ɓ� = gfncFieldVal(.Fields("�������ɓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�c�Ə����ɗ\��� = gfncFieldVal(.Fields("�c�Ə����ɗ\���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���������� = gfncFieldVal(.Fields("����������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�c�Ə����ɓ� = gfncFieldVal(.Fields("�c�Ə����ɓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�p�ԓ� = gfncFieldVal(.Fields("�p�ԓ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ӓo�^�ԍ� = gfncFieldVal(.Fields("�����ӓo�^�ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ӕی��� = gfncFieldVal(.Fields("�����ӕی���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�d�ʐ� = gfncFieldVal(.Fields("�d�ʐ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����Ԑ� = gfncFieldVal(.Fields("�����Ԑ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ԓo�^�ԍ� = gfncFieldVal(.Fields("�����ԓo�^�ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����ؗL������ = gfncFieldVal(.Fields("�����ؗL������").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���l = gfncFieldVal(.Fields("���l").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R�� = gfncFieldVal(.Fields("�R��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��㎞�� = gfncFieldVal(.Fields("��㎞��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ŏI�����ԍ� = gfncFieldVal(.Fields("�ŏI�����ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��ЃR�[�h = gfncFieldVal(.Fields("��ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԏ�R�[�h = gfncFieldVal(.Fields("�Ԏ�R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�o�^��ЃR�[�h = gfncFieldVal(.Fields("���q�o�^��ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z�匎 = gfncFieldVal(.Fields("���p���z�匎").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z���� = gfncFieldVal(.Fields("���p���z����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z3�� = gfncFieldVal(.Fields("���p���z�R��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R���敪 = gfncFieldVal(.Fields("�R���敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�p�r�敪 = gfncFieldVal(.Fields("�p�r�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���z�[�� = gfncFieldVal(.Fields("���p���z�[��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���͔ԍ� = gfncFieldVal(.Fields("���͔ԍ�").Value, "1")
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ��n��R�[�h = gfncFieldVal(.Fields("�����q�ԍ��n��R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ�1 = gfncFieldVal(.Fields("�����q�ԍ��P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ�2 = gfncFieldVal(.Fields("�����q�ԍ��Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����q�ԍ�3 = gfncFieldVal(.Fields("�����q�ԍ��R").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^��1 = gfncFieldVal(.Fields("�^���P").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^��2 = gfncFieldVal(.Fields("�^���Q").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�^��3 = gfncFieldVal(.Fields("�^���R").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�R�� = gfncFieldVal(.Fields("�R��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������q�敪 = gfncFieldVal(.Fields("�������q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�C�ӕی��ԍ� = gfncFieldVal(.Fields("�C�ӕی��ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�g�p�҃R�[�h = gfncFieldVal(.Fields("�g�p�҃R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԍ��g�p�҃R�[�h = gfncFieldVal(.Fields("�Ԍ��g�p�҃R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�Ԍ����L�҃R�[�h = gfncFieldVal(.Fields("�Ԍ����L�҃R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ؑ֓� = gfncFieldVal(.Fields("�ؑ֓�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�A���ؑ֓� = gfncFieldVal(.Fields("�A���ؑ֓�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��Ԓ�� = gfncFieldVal(.Fields("��Ԓ��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m��̕񍐓��t = gfncFieldVal(.Fields("��̕񍐓��t").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ړ��񍐔ԍ� = gfncFieldVal(.Fields("�ړ��񍐔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���͏�� = gfncFieldVal(.Fields("���͏��").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ԑ�֋敪 = gfncFieldVal(.Fields("���ԑ�֋敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�ؑ֋敪 = gfncFieldVal(.Fields("�ؑ֋敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q��� = gfncFieldVal(.Fields("���q���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�v�揈��SEQ = gfncFieldVal(.Fields("���q�v�揈��SEQ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�o�^�t���O = gfncFieldVal(.Fields("���q�o�^�t���O").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����m����� = gfncFieldVal(.Fields("����m�����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���p���� = gfncFieldVal(.Fields("���p����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����ЃR�[�h = gfncFieldVal(.Fields("����ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�������R�[�h = gfncFieldVal(.Fields("�������R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���c�Ǝ��q�敪 = gfncFieldVal(.Fields("���c�Ǝ��q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���������q�敪 = gfncFieldVal(.Fields("���������q�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ؑ֓� = gfncFieldVal(.Fields("���ؑ֓�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���Ԏ�R�[�h = gfncFieldVal(.Fields("���Ԏ�R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ԑ̔ԍ� = gfncFieldVal(.Fields("���ԑ̔ԍ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪���� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪��� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪���").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪�c�ƈړ� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪�c�ƈړ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪��Јړ� = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪��Јړ�").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���q�}�X�^�X�V�敪���q�����e = gfncFieldVal(.Fields("���q�}�X�^�X�V�敪���q�����e").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���ԍς݃t���O = gfncFieldVal(.Fields("���ԍς݃t���O").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�����Ώۃt���O = gfncFieldVal(.Fields("�����Ώۃt���O").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m�i���o�[�F�敪 = gfncFieldVal(.Fields("�i���o�[�F�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���[�J�[�R�[�h = gfncFieldVal(.Fields("���[�J�[�R�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���L�敪 = gfncFieldVal(.Fields("���L�敪").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���[�X��ЃR�[�h = gfncFieldVal(.Fields("���[�X��ЃR�[�h").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m����o�^�N���� = gfncFieldVal(.Fields("����o�^�N����").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m���T�C�N������ = gfncFieldVal(.Fields("���T�C�N������").Value)

                Select Case objUpdataParam.m�w�����e�敪

                    Case "0"

                        pstr�X�e�[�^�X = "���ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate����(objUpdataParam)

                    Case "11"

                        pstr�X�e�[�^�X = "�ۗ����ԁ@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                        Call msubUpdate�ۗ�����(objUpdataParam)

                End Select

                '// �t���O�̏�ԂōX�V�������m������̍X�V���ύX����
                If objUpdataParam.m�����Ώۃt���O = "1" Then

                    pstr�X�e�[�^�X = "����m������̍X�V�@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                    '// �c�Ǝ��q�}�X�^
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�ٓ��e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�v����̓e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                Else
                    pstr�X�e�[�^�X = "���q�}�X�^����m������̍X�V�@�Y��SEQ�F" & objUpdataParam.m���q�v�揈��SEQ
                    '// ���q�}�X�^
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�ٓ��e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ���q�}�X�^����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE ���q�v����̓e�[�u�� SET"
                    strSQL = strSQL & Chr(10) & "    ���q�}�X�^����m����� = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    ���q�v�揈��SEQ = " & objUpdataParam.m���q�v�揈��SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

NEXT_:

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .MoveNext()

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Loop While .EOF = False

        End With

HONMUTUKEKOMI:

        Dim objDys�{���җ����e�[�u�� As Object
        Dim objDys���q�����e�[�u�� As Object
        If pstr���s�t���O = "1" Or pstr���s�t���O = "3" Then
            '// �{���㖱�����e�[�u��������q�}�X�^�ɖ{���҂P�Ɩ{���҂Q�̏���Ђ�����

            pstr�X�e�[�^�X = "�{���җ����e�[�u��������q�}�X�^�̖{���ҏ��𔽉f�F"
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    HRT.���q�ԍ��n��R�[�h "
            strSQL = strSQL & Chr(10) & "   ,HRT.���q�ԍ��P         "
            strSQL = strSQL & Chr(10) & "   ,HRT.���q�ԍ��Q         "
            strSQL = strSQL & Chr(10) & "   ,HRT.���q�ԍ��R         "
            strSQL = strSQL & Chr(10) & "   ,ESM.�����ԍ�           "
            strSQL = strSQL & Chr(10) & "   ,HRT.�ؑ֓�             "
            strSQL = strSQL & Chr(10) & "   ,HRT.�V�{���҃R�[�h�P   "
            strSQL = strSQL & Chr(10) & "   ,HRT.�V�{���҃R�[�h�Q   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �{���җ����e�[�u�� HRT "
            strSQL = strSQL & Chr(10) & "   ,�c�Ǝ��q�}�X�^     ESM "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    HRT.���q�ԍ��n��R�[�h = ESM.���q�ԍ��n��R�[�h(+) "
            strSQL = strSQL & Chr(10) & "AND HRT.���q�ԍ��P         = ESM.���q�ԍ��P        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.���q�ԍ��Q         = ESM.���q�ԍ��Q        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.���q�ԍ��R         = ESM.���q�ԍ��R        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.�ؑ֓�            <= ('" & pstr�c�Ɠ���� & "') "
            strSQL = strSQL & Chr(10) & "AND NVL(HRT.���q�}�X�^���f�敪,'0') =  '0' " '// 2010/05/31
            '        strSQL = strSQL & Chr(10) & "AND HRT.�ؑ֋敪           =  0 "
            strSQL = strSQL & Chr(10) & "AND HRT.�����R�[�h         =  '" & gfncGetCodeToControl(pstr����, GC_LEN_POST_CODE) & "'"
            strSQL = strSQL & Chr(10) & "ORDER BY HRT.�ؑ֓� " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys�{���җ����e�[�u�� = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys�{���җ����e�[�u��

                ' �Y������f�[�^�����݂���ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        pstr�X�e�[�^�X = "�{���ҕt���݁F���q�ԍ�:" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "-" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "-" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "-" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & ""
                        ' ���q�}�X�^���X�V
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(�V�{���҃R�[�h�P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET �{���҃R�[�h�P     = '" & gfncFieldVal(.Fields("�V�{���҃R�[�h�P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(�V�{���҃R�[�h�Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,�{���҃R�[�h�Q     = '" & gfncFieldVal(.Fields("�V�{���҃R�[�h�Q").Value) & "' "
                        '// 2009/09/23 START �X�V�ǉ�
                        strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��n��R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P         = '" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q         = '" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R         = '" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        '// ���q�}�X�^���f�敪���X�V(�ؑ֋敪 = 1)  2010/05/31
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE �{���җ����e�[�u�� SET"
                        strSQL = strSQL & Chr(10) & "   ���q�}�X�^���f�敪  = 1 "
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��n��R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P         = '" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q         = '" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R         = '" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys�{���җ����e�[�u��.Fields(�ؑ֓�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND �ؑ֓�             = '" & gfncFieldVal(.Fields("�ؑ֓�").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�{���җ����e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            'UPGRADE_NOTE: Object objDys�{���җ����e�[�u�� may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDys�{���җ����e�[�u�� = Nothing

            '// 2009/09/23 START ���q�����e�[�u��������q�}�X�^���X�V���鏈����ǉ�
            '----------------------------------------------------------------------
            ' ���q�����e�[�u��  �f�[�^���f����
            '----------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h   "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��P           "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��Q           "
            strSQL = strSQL & Chr(10) & "   ,���q�ԍ��R           "
            strSQL = strSQL & Chr(10) & "   ,�ؑ֓�               "
            strSQL = strSQL & Chr(10) & "   ,�V��ЃR�[�h         "
            strSQL = strSQL & Chr(10) & "   ,�V�����R�[�h         "
            strSQL = strSQL & Chr(10) & "   ,�V�����ԍ�           "
            strSQL = strSQL & Chr(10) & "   ,�V���q�敪           "
            strSQL = strSQL & Chr(10) & "   ,�V���q�o�^��ЃR�[�h "
            strSQL = strSQL & Chr(10) & "   ,�V���q�o�^�����R�[�h "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    ���q�����e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND �ؑ֓�       <= ('" & pstr�c�Ɠ���� & "')"
            strSQL = strSQL & Chr(10) & "AND �ؑ֋敪      =  0 "
            strSQL = strSQL & Chr(10) & "AND �V�����R�[�h  =  '" & gfncGetCodeToControl(pstr����, GC_LEN_POST_CODE) & "'"
            strSQL = strSQL & Chr(10) & "ORDER BY �ؑ֓� " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys���q�����e�[�u�� = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys���q�����e�[�u��

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        '// ���q�}�X�^�̍X�V(�������t�Ŏ��q�ύX���͂��ꂽ���e�𔽉f)
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE ���q�}�X�^ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V�����R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET �����R�[�h         = '" & gfncFieldVal(.Fields("�V�����R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V��ЃR�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,��ЃR�[�h         = '" & gfncFieldVal(.Fields("�V��ЃR�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V�����ԍ�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,�����ԍ�           = '" & gfncFieldVal(.Fields("�V�����ԍ�").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V���q�敪).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,���q�敪           = '" & gfncFieldVal(.Fields("�V���q�敪").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V���q�o�^��ЃR�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,���q�o�^��ЃR�[�h = '" & gfncFieldVal(.Fields("�V���q�o�^��ЃR�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(�V���q�o�^�����R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,���q�o�^�����R�[�h = '" & gfncFieldVal(.Fields("�V���q�o�^�����R�[�h").Value) & "' "
                        '// 2009/09/23 START �X�V�ǉ�
                        strSQL = strSQL & Chr(10) & "   ,�X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,�X�V���t���� = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��n��R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    ���q�ԍ��n��R�[�h = '" & gfncFieldVal(.Fields("���q�ԍ��n��R�[�h").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��P         = '" & gfncFieldVal(.Fields("���q�ԍ��P").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��Q).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��Q         = '" & gfncFieldVal(.Fields("���q�ԍ��Q").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys���q�����e�[�u��.Fields(���q�ԍ��R).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND ���q�ԍ��R         = '" & gfncFieldVal(.Fields("���q�ԍ��R").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys���q�����e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '// 2009/09/23 END
            Call gsubClearObject(objDynaset)
            Call gsubClearObject(objDys�{���җ����e�[�u��)
            Call gsubClearObject(objDys���q�����e�[�u��)
        End If

        '// �I�����O�̂͂�����
        Call gfncRegistTraceLog(gfncGetDBUserName, gfncGetDBPassWord, gfncGetDBTNS, GC_PROGRAM_NAME, GC_PROGRAM_ID, "����I��", pstr�X�e�[�^�X, "", GC_LOG_TARGET_���q�Ǘ����O, False)


    End Function

    '******************************************************************************
    ' �� �� ��  : mfncGetHokenName
    ' �X�R�[�v  : Private
    ' �������e  : �ی���ЃR�[�h���ی���Ж����擾����
    '             �Ώۂ��Ȃ��ꍇ�͂��當����Ԃ�
    ' ���@�@�l  :
    ' �� �� �l  : string
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstr�ی����        String        �@   I    �ی���ЃR�[�h
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/26  �j�r�q             �V�K�쐬
    '******************************************************************************
    Public Function mfncGetHokenName(ByVal pstr�ی���� As String) As String
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo mfncGetHokenName_Err
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Dim strSQL As String
        Dim objDynaset As Object
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDynaset As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            mfncGetHokenName = ""

            If pstr�ی���� = "" Then
                GoTo mfncGetHokenName_Exit
            End If

            strSQL = ""
            strSQL = strSQL & "SELECT MM.�R�[�h AS �R�[�h, "
            strSQL = strSQL & "       MM.���̊��� AS ���� "
            strSQL = strSQL & "  FROM ���̃}�X�^ MM "
            strSQL = strSQL & " WHERE MM.����    = '�ی����' "
            strSQL = strSQL & " AND   MM.�R�[�h  = '" & pstr�ی���� & "'"
            strSQL = strSQL & " ORDER BY MM.�R�[�h "
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDynaset = gobjOraDatabase.CreateDynaset(strSQL, &H1)
            'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDynaset.EOF Then
                GoTo mfncGetHokenName_Exit
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                mfncGetHokenName = gfncFieldVal(objDynaset.Fields("����").Value)
            End If

            '++�C���J�n�@2021�N06��17��:MK�i��j- VB��VB.NET�ϊ�
mfncGetHokenName_Exit:
            'Call gsubClearObject(objDynaset)
            'Exit Function
            '--�C���J�n�@2021�N06��17��:MK�i��j- VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'mfncGetHokenName_Err:
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'Resume mfncGetHokenName_Exit
            Call gsubClearObject(objDynaset)
            Exit Function
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncOldChangeDate
    ' �X�R�[�v  : Private
    ' �������e  : �����̉�ЃR�[�h�Ə����R�[�h�Ɛؑ֓��œ���m�肪�I������Ă��邩�ǂ������`�F�b�N����
    ' ���@�@�l  :
    ' �� �� �l  : Boolean
    ' �� �� ��  :
    '   ���Ұ���                �ް�����            I/O     �� ��
    '   -----------------------+-------------------+-------+-------------------------------
    '   pKaisyaCode             STRING              I       ���q�̏������Ă����ЃR�[�h
    '   pBusyoCode              STRING              I       ���q�̏������Ă��镔���R�[�h
    '   pKirikaebi              STRING              I       ���񏈗����s���ؑ֓�
    ' �ύX����  :
    '   Version     ���@�t      ���@��        �@�@ �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '               2010/09/24  �j�r�q
    '******************************************************************************
    Public Function gfncOldChangeDate(ByRef pKaisyaCode As String, ByRef pBusyoCode As String, ByRef pKirikaebi As String) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ABEND
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Dim Sql_s As String
        Dim obj_Nippou As Object
        Dim strBushoname As String
        Dim strChangeday As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim Sql_s As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim obj_Nippou As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strBushoname As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strChangeday As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            gfncOldChangeDate = False

            strChangeday = "99999999"

            '// �������̎擾
            Sql_s = ""
            Sql_s = Sql_s & "   SELECT "
            Sql_s = Sql_s & "       BSM.������"
            Sql_s = Sql_s & "   FROM �����}�X�^ BSM"
            Sql_s = Sql_s & "   WHERE 1 = 1"
            Sql_s = Sql_s & "   AND BSM.��ЃR�[�h   = '" & pKaisyaCode & "' "
            Sql_s = Sql_s & "   AND BSM.�����R�[�h   = '" & pBusyoCode & "' "
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou = gobjOraDatabase.CreateDynaset(Sql_s, &H4)
            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If obj_Nippou.EOF Then
                strBushoname = ""
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strBushoname = gfncFieldVal(obj_Nippou.Fields("������").Value, "")
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou.Close()
            'UPGRADE_NOTE: Object obj_Nippou may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            obj_Nippou = Nothing

            '// ������͊m��e�[�u�����A�Ώۉ�ЁA�����A�ōő�c�Ɠ����擾���āA�����̐ؑ֓��Ŋm�菈����������Ă��邩�ǂ����`�F�b�N
            Sql_s = ""
            Sql_s = Sql_s & Chr(10) & "SELECT "
            Sql_s = Sql_s & Chr(10) & "     MAX(�c�Ɠ�) AS �c�Ɠ� "
            Sql_s = Sql_s & Chr(10) & "FROM ������͊m��e�[�u��"
            Sql_s = Sql_s & Chr(10) & "WHERE 1 = 1"
            Sql_s = Sql_s & Chr(10) & "AND    ��ЃR�[�h = '" & pKaisyaCode & "' "
            Sql_s = Sql_s & Chr(10) & "AND    �����R�[�h = '" & pBusyoCode & "' "
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou = gobjOraDatabase.CreateDynaset(Sql_s, &H4)
            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If obj_Nippou.EOF Then
                '// ������͊m��e�[�u�������݂��Ȃ��ꍇ�́A�m�[�`�F�b�N�ŏ�����ʂ�
                gfncOldChangeDate = True
                GoTo PROC_EXIT
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strChangeday = gfncFieldVal(obj_Nippou.Fields("�c�Ɠ�").Value, "")
            End If

            '// �擾�����ؑ֓��ȑO�̐ؑ֓�����ʂɓ��͂���Ă���ꍇ�̓G���[
            If strChangeday >= pKirikaebi Then
                '++�C���J�n�@2021�N09��05��:MK�i��j- VB��VB.NET�ϊ�
                'MsgBox("����" & strBushoname & "��" & vbCrLf & "�Ζ��\����͊m�菈�����I�����Ă���ׁA" & VB6.Format(CDate(VB6.Format(strChangeday, "0000/00/00")), "yyyy(ggge)/mm/dd") & "�ȑO�̐ؑ֓��͓��͂ł��܂���B", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                MsgBox("����" & strBushoname & "��" & vbCrLf & "�Ζ��\����͊m�菈�����I�����Ă���ׁA" & VB6.Format(CDate(VB6.Format(strChangeday, "0000/00/00")), "yyyy(gggee)/mm/dd") & "�ȑO�̐ؑ֓��͓��͂ł��܂���B", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                '--�C���J�n�@2021�N09��05��:MK�i��j- VB��VB.NET�ϊ�
                GoTo PROC_EXIT
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou.Close()
            'UPGRADE_NOTE: Object obj_Nippou may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            obj_Nippou = Nothing

            gfncOldChangeDate = True

            ''** �I�����ʏ���
            '++�C���J�n�@2021�N06��17��:MK�i��j- VB��VB.NET�ϊ�
            'PROC_EXIT:
            '''** �����I��
           ' Exit Function
            '--�C���J�n�@2021�N06��17��:MK�i��j- VB��VB.NET�ϊ�

            ''** ��O�������ʏ���
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ABEND:
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            ''** �G���[���b�Z�[�W�\��
            Call MsgBox(Err.Description, MsgBoxStyle.Critical, "gfncOldChangeDate")
            Exit Function
            ''** �I�����ʏ������{
            '++�C���J�n�@2021�N06��17��:MK�i��j- VB��VB.NET�ϊ�
            'Resume PROC_EXIT
            '--�C���J�n�@2021�N06��17��:MK�i��j- VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
PROC_EXIT:
        '''** �����I��
        Exit Function
    End Function

End Module
