Option Strict Off
Option Explicit On
Public Module basCommonConst
    '*******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : Message.bas
    ' ��    �e    : �V�X�e�����ʒ萔��`
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+---------------------------------
    '   02.00.00    2007/11/29  �A��  �F��         �V�K�쐬
    '   02.01.00    2009/07/22  �A��  �F��         �l�ʔ��㌴���v�Z�����c�Ə�, �v�Z��, �c�ƕ�,
    '                                              ����ьv�Z�ۂ̈ꕔ�ɂĎg�p�����, �萔��ǉ�.
    '   02.02.00    2009/12/07  �A��  �F��         �Ζ��V�t�g��ǉ�
    '   02.03.00    2009/12/11  �A��  �F��         �Ζ��t�@�[�X�g��ǉ�
    '   02.04.00    2010/04/07  �A��  �F��         ���i�R�[�h�̒�����ǉ�
    '   02.98.00    2015/11/10  �j�r�q             �ݐؖ��׋敪�̒�����ǉ�
    '   02.98.00    2017/01/23  �j�r�q             �t�@�[�X�g�̌���1��2�ɕύX
    '
    '*******************************************************************************
    ' ���O�C����� �|�b�v�A�b�v
    '++�C���J�n�@2021�N07��06��:MK�i��j- VB��VB.NET�ϊ�
    'Public Const GC_POPUP_OBJECT_LOGIN As String = "prjLogin.clsLogin"
    Public Const GC_POPUP_OBJECT_LOGIN As String = "Login.clsLogin"
    '--�C���J�n�@2021�N07��06��:MK�i��j- VB��VB.NET�ϊ�
    ' �}�X�^������� �|�b�v�A�b�v
    '++�C���J�n�@2021�N06��28��:MK�i��j- VB��VB.NET�ϊ�
    'Public Const GC_POPUP_OBJECT_MSTPOP As String = "prjMstPop.clsMstPop"
    Public Const GC_POPUP_OBJECT_MSTPOP As String = "MstPop.clsMstPop"
    '--�C���J�n�@2021�N06��28��:MK�i��j- VB��VB.NET�ϊ�

    Public Enum genYear
        �{�N
        �O�N
        �O�X�N
    End Enum

    '++�C���J�n�@2024�N04��05��:MK�i��j- VB��VB.NET�ϊ�
    Public Enum genRideShare
        �܂� = 1
        ���� = 2
        �̂� = 3
    End Enum
    '--�C���J�n�@2024�N04��05��:MK�i��j- VB��VB.NET�ϊ�

    '=Public Const GC_MAX_HONMU_NUM                   As Integer = 3
    Public Const GC_MAX_HONMU_NUM As Short = 2

    Public Const GC_DEF_SYSTEM_PATH As String = "\\172.31.1.103\MkSystem"
    Public Const GC_DEF_COMMON_DIR As String = "Common"
    Public Const GC_DEF_BAT_CONNECT As String = "�v���ڑ�.bat"

    Public Const GC_INI_FILE_ZS0470 As String = "ZS0470.INI"
    Public Const GC_EXE_FILE_ZS0470 As String = "ZS0470.EXE"
    Public Const GC_DEF_ZSO470_PATH_LOCAL As String = "C:\NC_OFFICE\program\execute\"
    Public Const GC_DEF_ZSO470_PATH_SERVER As String = "\\192.168.1.205\e\CDRom\�V������\NC_OFFICE\program\execute\"

    Public Const GC_PRAM_IDX_ORA_SYSDATE As Short = 0
    Public Const GC_PRAM_IDX_COMPANY_CODE As Short = 1
    Public Const GC_PRAM_IDX_POST_CODE As Short = 2
    Public Const GC_PRAM_IDX_EMPLOYEE_CODE As Short = 3
    Public Const GC_PRAM_IDX_RANK As Short = 4
    Public Const GC_PRAM_IDX_SYSTEM_AUTHORITY As Short = 5
    Public Const GC_PRAM_IDX_OFFICIAL_POSITION As Short = 6

    Public Const GC_PRAM_MAX As Short = GC_PRAM_IDX_SYSTEM_AUTHORITY
    Public Const GC_PRAM_MAX2 As Short = GC_PRAM_IDX_OFFICIAL_POSITION

    Public Const GC_MODE_GET As Short = 1
    Public Const GC_MODE_CHECK As Short = 2

    Public Const GC_STR_SELECT_NONE As String = "*---------------- <�w���������> ----------------*"
    Public Const GC_STR_SELECT_NONE_CAR_KBN As String = "*-------- <�w���������> ---------*"
    Public Const GC_STR_SELECT_NONE_SFT_KBN As String = "*- <�w���������> -*"
    Public Const GC_STR_SELECT_NONE_FST_KBN As String = "* <�w���������> *"

    Public Const GC_COMBO_SPLIT As String = " : "

    Public Const GC_LEN_COMPANY_CODE As Short = 2 ' ��ЃR�[�h�̒���
    Public Const GC_LEN_CARTYPE_CODE As Short = 8 ' �Ԏ�R�[�h�̒���
    Public Const GC_LEN_POST_CODE As Short = 6 ' �����R�[�h�̒���
    Public Const GC_LEN_CAR_KBN As Short = 2 ' ���q�敪�̒���
    Public Const GC_LEN_CAR_TYPE_CODE As Short = 2 ' �Ԏ�R�[�h�̒���
    Public Const GC_LEN_SHIFT_KBN As Short = 2 ' �V�t�g�敪�̒���
    Public Const GC_LEN_YMD As Short = 8 ' �N�����̒���
    Public Const GC_LEN_BANK_CODE As Short = 4 ' ��s�R�[�h�̒���
    Public Const GC_LEN_BRANCH_CODE As Short = 3 ' �x�X�R�[�h�̒���
    Public Const GC_LEN_CAR_DISTRICT_CODE As Short = 3 ' ���q�ԍ��n��R�[�h�̒���
    Public Const GC_LEN_FIRST_KBN As Short = 2 ' �t�@�[�X�g�敪�̒��� '//**�����ύX 1��2 2017/01/23
    Public Const GC_LEN_STATUS_KBN As Short = 1 ' ��ԋ敪�̒���
    Public Const GC_LEN_WORK_KBN As Short = 2 ' �ΑӋ敪�̒���
    Public Const GC_LEN_SYSTEM_KBN As Short = 2 ' �V�X�e���敪�̒���
    Public Const GC_LEN_EMPLOYEE_CODE As Short = 7 ' �]�ƈ��R�[�h�̒���
    Public Const GC_LEN_CONTRACT_TYPE As Short = 2 ' �_��`�Ԃ̒���
    Public Const GC_LEN_RESIGNATION_CODE As Short = 2 ' �ސE�R�[�h�̒���
    Public Const GC_LEN_UK_CUSTOMER_CODE_COMPANY As Short = 7 ' �^�s�Ǘ������Ӑ�R�[�h(���)
    Public Const GC_LEN_UK_CUSTOMER_CODE_POST As Short = 2 ' �^�s�Ǘ������Ӑ�R�[�h(����)
    Public Const GC_LEN_PAYING_KIND As Short = 2 ' ������ʂ̒���
    Public Const GC_LEN_DAY As Short = 2 ' ���t���ڂ̒���
    Public Const GC_LEN_CLAIM_CLOSING_DAY As Short = 2 ' ���������̒���
    Public Const GC_LEN_COMMODITY_BIG_GROUP As Short = 2 ' ���i�啪�ރR�[�h�̒���
    Public Const GC_LEN_COUPON_KBN As Short = 2 ' �N�[�|���敪�̒���
    Public Const GC_LEN_UK_CUSTOMER_KBN As Short = 1 ' �^�Ǔ��Ӑ�敪�̒���
    Public Const GC_LEN_OFFICIAL_POSITION As Short = 2 ' ��E�ʂ̒���
    Public Const GC_LEN_PAY_ACCOUNT As Short = 2 ' �U�������A�Ԃ̒���
    Public Const GC_LEN_ZIP_NO_1 As Short = 3 ' �X�֔ԍ��P�̒���
    Public Const GC_LEN_ZIP_NO_2 As Short = 4 ' �X�֔ԍ��Q�̒���
    Public Const GC_LEN_CONTRACT_NO As Short = 3 ' �_��ԍ��̒���
    Public Const GC_LEN_COMMODITY_CODE As Short = 6 ' ���i�R�[�h�̒���
    Public Const GC_LEN_RD_UKNO As Short = 7 ' ��t�ԍ�(�y�X����)�̒���
    Public Const GC_LEN_UK_REVENUE_NO As Short = 8 ' ����ԍ��̒���
    Public Const GC_LEN_UK_PAYING_NO As Short = 8 ' �����ԍ��̒���
    Public Const GC_LEN_ACCOUNT_KIND As Short = 1 ' ������ʂ̒���
    Public Const GC_LEN_MEMBER_CODE_PARENT As Short = 7 ' ����R�[�h�̒���
    Public Const GC_LEN_MEMBER_CODE_BRANCH As Short = 4 ' ����}�R�[�h�̒���
    Public Const GC_LEN_HOSPITAL_CODE As Short = 3 ' �a�@�R�[�h�̒���
    Public Const GC_LEN_KINJIRO_BUMON As Short = 2 ' �Ύ��Y����R�[�h�̒���
    ' �Ύ��Y����R�[�h(�S��)�̒���
    Public Const GC_LEN_KINJIRO_BUMON_ALL As Short = GC_LEN_KINJIRO_BUMON * 3
    Public Const GC_LEN_ZD_KIND As Short = 1 ' �y�c��ʂ̒���
    Public Const GC_LEN_MISYUU_KBN As Short = 2 ' �����敪�̒���
    Public Const GC_LEN_TICKET_PRINT_KBN As Short = 2 ' �`�P�b�g���s�敪�̒���
    Public Const GC_LEN_TDFK As Short = 10 ' �s���{���̒���
    Public Const GC_LEN_PERFECT_NO As Short = 10 ' �p�[�t�F�N�g�ԍ��̒���
    Public Const GC_LEN_FUEL_KBN As Short = 2 ' �R���敪�̒���
    Public Const GC_LEN_USED_KBN As Short = 1 ' �p�r�敪�̒���
    Public Const GC_LEN_NYUUKIN_KBN As Short = 1 ' �����敪�̒���
    Public Const GC_LEN_AIRPORT_CODE As Short = 1 ' ��`�R�[�h�̒���
    Public Const GC_LEN_DISCOUNT_KIND As Short = 3 ' ������ʂ̒���
    Public Const GC_LEN_IKI_KAERI_KBN As Short = 1 ' �s�A�敪�̒���
    Public Const GC_LEN_ACCIDENT_KIND As Short = 2 ' ���̎�ނ̒���
    Public Const GC_LEN_HAN As Short = 3 ' �ǂ̒���
    Public Const GC_LEN_HOLIDAY_GROUP As Short = 3 ' ���x�O���[�v�̒���
    Public Const GC_LEN_CHARGE_STATION As Short = 2 ' �[�U���R�[�h�̒���
    Public Const GC_LEN_IKISAKI_CODE As Short = 2 ' �s��R�[�h�̒���
    Public Const GC_LEN_KASHITUKE_KOUMOKU_CODE As Short = 2 ' �ݕt���ڃR�[�h�̒���
    Public Const GC_LEN_LECTURE_CODE As Short = 3 ' �u�`�R�[�h�̒���
    Public Const GC_LEN_TICKET_NUMBER As Short = 11 ' �����ԍ��̒���
    Public Const GC_LEN_SITE_CODE As Short = 6 ' �w���ꏊ�R�[�h�̒���
    Public Const GC_LEN_SHIKAKU_CODE As Short = 2 ' ���i�R�[�h�̒���
    Public Const GC_LEN_SHIDO_KANTOKU_BUNRUI As Short = 2 ' �w���ē��ނ̒���
    Public Const GC_LEN_JITSUMU_SHIKAKU_CODE As Short = 5
    Public Const GC_LEN_JITSUMU_RANK As Short = 5
    Public Const GC_LEN_KAS_MEIKBN As Short = 2 ' �ݐؖ��׋敪�̒���
    Public Const GC_LEN_���񂻂̑�_MEIKBN As Short = 2 ' ���񂻂̑��敪�̒���

    '------------------------------
    ' �c�a�ڑ��ݒ�
    '------------------------------
    Public Const GC_DEF_USER_NAME As String = "MK"
    Public Const GC_DEF_PASS_WORD As String = "MK"
    Public Const GC_DEF_TNS_NAME As String = "MK"

    '------------------------------
    ' �|�b�v�A�b�v�ďo���x��
    '------------------------------
    '++�C���J�n�@2021�N06��15��:MK�i��j- VB��VB.NET�ϊ�
    'Public Const GC_APPEARANCE_POPUP_CALL_3D As Short = 1
    Public Const GC_APPEARANCE_POPUP_CALL_3D As Short = 2
    '--�C���J�n�@2021�N06��15��:MK�i��j- VB��VB.NET�ϊ�
    Public Const GC_BACK_COLOR_POPUP_CALL_OFF As Integer = &H800000
    Public Const GC_FORE_COLOR_POPUP_CALL_OFF As Integer = &HFFFFFF

    '++�C���J�n�@2021�N06��15��:MK�i��j- VB��VB.NET�ϊ�
    'Public Const GC_APPEARANCE_POPUP_CALL_FLAT As Short = 0
    Public Const GC_APPEARANCE_POPUP_CALL_FLAT As Short = 1
    '--�C���J�n�@2021�N06��15��:MK�i��j- VB��VB.NET�ϊ�
    'UPGRADE_NOTE: GC_BACK_COLOR_POPUP_CALL_ON was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    'Public GC_BACK_COLOR_POPUP_CALL_ON As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
    Public Const GC_BACK_COLOR_POPUP_CALL_ON As Integer = &HFF0000
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    Public Const GC_FORE_COLOR_POPUP_CALL_ON As Integer = &HFFFFFF

    '------------------------------
    ' ���
    '------------------------------
    Public Const GC_DEF_��� As String = "21"

    '------------------------------
    ' �|�b�v�A�b�v�h�c
    '------------------------------
    Public Const GC_POP_MODE_�Ȃ� As Short = 0
    Public Const GC_POP_MODE_�]�ƈ��}�X�^ As Short = 1
    Public Const GC_POP_MODE_�ΑӃ}�X�^ As Short = 2
    Public Const GC_POP_MODE_�a�@�}�X�^ As Short = 3
    Public Const GC_POP_MODE_����ڋq�}�X�^ As Short = 4
    Public Const GC_POP_MODE_�����敪�}�X�^ As Short = 5
    Public Const GC_POP_MODE_�u�`�}�X�^ As Short = 6
    Public Const GC_POP_MODE_LPG�[�U���}�X�^ As Short = 9

    '------------------------------
    ' �|�b�v�A�b�v�������[�h
    '------------------------------
    Public Const GC_POP_SEARCH_MODE_NORMAL As Short = 0 ' �ʏ팟��
    Public Const GC_POP_SEARCH_MODE_RETIRED As Short = 1 ' �ސE�Ҍ���

    '------------------------------
    ' �i���j�`�i���j
    '------------------------------
    Public Const GC_IDX_STA As Short = 0
    Public Const GC_IDX_END As Short = 1
    Public Const GC_IDX_NOW As Short = 2 ' �����_

    '------------------------------
    ' ����E�G���[�E�Y���f�[�^�Ȃ�
    '------------------------------
    Public Const GC_CODE_ERR As Short = -1 ' �G���[
    Public Const GC_CODE_SUC As Short = 0 ' ����
    Public Const GC_CODE_NONE As Short = 1 ' �Y���f�[�^�Ȃ�

    '------------------------------
    ' ������䃂�[�h
    '------------------------------
    Public Const GC_PRINT_MODE_PREVIEW As Short = 1 ' �v���r��
    Public Const GC_PRINT_MODE_PRINT As Short = 2 ' ���

    '------------------------------
    ' �t���O
    '------------------------------
    Public Const GC_FLG_OFF As Short = 0
    Public Const GC_FLG_ON As Short = 1


    '++�C���J�n�@2023�N11��22��:MK�i��j- VB��VB.NET�ϊ�
    '------------------------------
    ' �������
    '------------------------------
    Public Const GC_KBN_�������_�Ȃ� As Short = 0
    Public Const GC_KBN_�������_�Ώ� As Short = 1
    Public Const GC_KBN_�������_���� As Short = 2

    '--�C���J�n�@2023�N11��22��:MK�i��j- VB��VB.NET�ϊ�

    '------------------------------
    ' ��ʐ��䃂�[�h
    '------------------------------
    Public Const GC_CONTROL_MODE_NO As Short = 0 ' �Ȃ�
    Public Const GC_CONTROL_MODE_NEW As Short = 1 ' �V�K
    Public Const GC_CONTROL_MODE_UPDATE As Short = 2 ' �X�V
    Public Const GC_CONTROL_MODE_DELETE As Short = 3 ' �폜
    Public Const GC_CONTROL_MODE_CANCEL As Short = 1 ' �L�����Z��
    Public Const GC_CONTROL_MODE_REDRAW As Short = 3 ' �ĕ`��
    Public Const GC_CONTROL_MODE_INIT As Short = 4 ' �����\��

    '------------------------------
    ' ��ʐ��䃂�[�h
    '------------------------------
    Public Const GC_CONTROL_MODE_PRINT As Short = 1 ' ���
    Public Const GC_CONTROL_MODE_SEARCH As Short = 1 ' ����
    Public Const GC_CONTROL_MODE_BODY As Short = 2 ' ����

    '------------------------------
    ' �o��񍐏�(ZSP070)
    '------------------------------
    Public Const GC_ZSP070_PRINT_BUTTON_TRUE As Short = 0 ' ����{�^���g�p��
    Public Const GC_ZSP070_PRINT_BUTTON_FALSE As Short = 1 ' ����{�^���g�p�s��

    Public Const GC_KBN_����U��_���� As Short = 1
    Public Const GC_KBN_����U��_���֕t�ѕ� As Short = 2
    Public Const GC_KBN_����U��_���� As Short = 3
    Public Const GC_KBN_����U��_���̑� As Short = 4
    '++�C���J�n�@2023�N09��12��:MK�i��j- VB��VB.NET�ϊ�
    Public Const GC_KBN_����U��_�d�� As Short = 5
    Public Const GC_KBN_����U��_�d���t�ѕ� As Short = 6
    '--�C���J�n�@2023�N09��12��:MK�i��j- VB��VB.NET�ϊ�

    Public Const GC_KBN_����_���� As Short = 1
    Public Const GC_KBN_����_���O As Short = 2

    Public Const GC_DEF_�σo�X_��� As String = "10"
    Public Const GC_DEF_�σo�X_���� As String = "0"
    Public Const GC_DEF_�^��_��� As String = "0"
    Public Const GC_DEF_�^��_���� As String = "720"

    Public Const GC_DEF_MK���[�X_��� As String = "11"
    Public Const GC_DEF_MK���[�X_���� As String = "79998"

    '------------------------------
    ' IT���i���̏����R�[�h
    '------------------------------
    ' 2019/03/21 �z�[���f�B�C���O�X�ɔ��������ύX
    'Public Const GC_CODE_BM_IT As String = "030"
    Public Const GC_CODE_BM_IT As String = "78030"

    '------------------------------
    ' �����̏����R�[�h
    '------------------------------
    ' 2019/03/21 �z�[���f�B�C���O�X�ɔ��������ύX
    'Public Const GC_CODE_BM_ZAIMU As String = "020"
    Public Const GC_CODE_BM_ZAIMU As String = "78020"

    '------------------------------
    ' �����̏����R�[�h
    '------------------------------
    ' 2019/03/21 �z�[���f�B�C���O�X�ɔ��������ύX
    'Public Const GC_CODE_BM_SOUMU As String = "010"
    Public Const GC_CODE_BM_SOUMU As String = "78010"

    '------------------------------
    ' �l���̏����R�[�h
    '------------------------------
    Public Const GC_CODE_BM_JINJI As String = "78050"

    '------------------------------
    ' �o�c��掺�̏����R�[�h
    '------------------------------
    ' 2019/03/21 �z�[���f�B�C���O�X�ɔ��������ύX
    'Public Const GC_CODE_BM_KIKAKU As String = "100"
    Public Const GC_CODE_BM_KIKAKU As String = "78100"

    '------------------------------
    ' �c�ƕ��̏����R�[�h
    '------------------------------
    Public Const GC_CODE_BM_EIGYOBU As String = "200"

    '------------------------------
    ' �������̏����R�[�h
    '------------------------------
    ' 2019/03/21 �z�[���f�B�C���O�X�ɔ��������ύX
    'Public Const GC_CODE_BM_YAKUIN As String = "018"
    Public Const GC_CODE_BM_YAKUIN As String = "78018"

    '------------------------------
    ' �Ζ��敪
    '------------------------------
    Public Const GC_KBN_�Ζ�_�Ј� As Short = 0
    Public Const GC_KBN_�Ζ�_�E�� As Short = 1

    '------------------------------
    ' �o���敪
    '------------------------------
    Public Const GC_KBN_�o��_�o�� As Short = 0
    Public Const GC_KBN_�o��_���� As Short = 1

    '------------------------------
    ' ���͋敪
    '------------------------------
    Public Const GC_KBN_DAILY_REPORT_INPUT_ADD As Short = 0 ' �ǉ�
    Public Const GC_KBN_DAILY_REPORT_INPUT_UPDATE As Short = 1 ' �X�V�i�o�n�r or ����j
    Public Const GC_KBN_DAILY_REPORT_INPUT_HOLIDAY As Short = 2 ' �x��
    Public Const GC_KBN_DAILY_REPORT_INPUT_TRAINING As Short = 3 ' ���K
    '++�C���J�n�@2024�N09��06��:MK�i��j- VB��VB.NET�ϊ�
    Public Const GC_KBN_DAILY_REPORT_INPUT_ERROR As Short = 4 ' �G���[
    '--�C���J�n�@2024�N09��06��:MK�i��j- VB��VB.NET�ϊ�

    '------------------------------
    ' �m��敪
    '------------------------------
    Public Const GC_KBN_�m��_���m�� As Short = 0
    Public Const GC_KBN_�m��_�m�� As Short = 1
    Public Const GC_KBN_�m��_�m���X�V As Short = 2

    '------------------------------
    ' �ۂߒP��
    '------------------------------
    Public Const GC_�ۂߒP��_��~ As Short = 0
    Public Const GC_�ۂߒP��_��~ As Short = 1
    Public Const GC_�ۂߒP��_�\�~ As Short = 2

    '------------------------------
    ' �����R�[�h�敪
    '------------------------------
    Public Const GC_KBN_�����R�[�h_���͕s�� As Short = 0 ' ���͕s��
    Public Const GC_KBN_�����R�[�h_���͉� As Short = 1 ' ���͉�

    '------------------------------
    ' ���֋��敪
    '------------------------------
    Public Const GC_KBN_���֋�_���͕s�� As Short = 0 ' ���͕s��
    Public Const GC_KBN_���֋�_���͉� As Short = 1 ' ���͉�

    '------------------------------
    ' �O�����敪
    '------------------------------
    Public Const GC_KBN_�O�����_���͕s�� As Short = 0 ' ���͕s��
    Public Const GC_KBN_�O�����_���͉� As Short = 1 ' ���͉�

    '------------------------------
    ' �p�K�C�h�敪
    '------------------------------
    Public Const GC_KBN_�p�K�C�h_���͕s�� As Short = 0 ' ���͕s��
    Public Const GC_KBN_�p�K�C�h_���͉� As Short = 1 ' ���͉�

    '------------------------------
    ' �萔�����ݒ��
    '------------------------------
    Public Const GC_�萔�����ݒ��_MK��� As Short = 0 ' �l�j����}�X�^
    Public Const GC_�萔�����ݒ��_�]�ƈ� As Short = 1 ' �]�ƈ��}�X�^

    '------------------------------
    ' �n�C���[�`�F�b�N
    '------------------------------
    Public Const GC_�n�C���[�`�F�b�N_���Ȃ� As Short = 0
    Public Const GC_�n�C���[�`�F�b�N_���� As Short = 1

    '------------------------------
    ' �����ԍ����͋敪
    '------------------------------
    Public Const GC_KBN_�����ԍ�����_�s�� As Short = 0
    Public Const GC_KBN_�����ԍ�����_�� As Short = 1

    '------------------------------
    ' �萔���v�Z�敪
    '------------------------------
    Public Const GC_KBN_�萔���v�Z_�ʏ� As Short = 0
    Public Const GC_KBN_�萔���v�Z_�Ŕ� As Short = 1

    '------------------------------
    ' �Q�Ƌ敪
    '------------------------------
    Public Const GC_KBN_REFERENCE_REPORT As Short = 0 ' �c�Ɠ���e�[�u��
    Public Const GC_KBN_REFERENCE_POS As Short = 1 ' �o�n�r����e�[�u��

    '------------------------------
    ' �U���敪
    '------------------------------
    Public Const GC_KBN_�U��_�`�P�b�g As Short = 0
    Public Const GC_KBN_�U��_���� As Short = 1
    Public Const GC_KBN_�U��_������ As Short = 2
    Public Const GC_KBN_�U��_�����񐔌� As Short = 3
    Public Const GC_KBN_�U��_�g��Ҋ����� As Short = 4
    Public Const GC_KBN_�U��_��Q�ҏ�Ԍ� As Short = 5
    Public Const GC_KBN_�U��_���Ј� As Short = 6
    Public Const GC_KBN_�U��_���̑� As Short = 7
    Public Const GC_KBN_�U��_�v���y�C�h As Short = 8
    Public Const GC_KBN_�U��_�|�C���g As Short = 9

    Public Const GC_KBN_�U��_MAX As Short = GC_KBN_�U��_�|�C���g

    '------------------------------
    ' �t�@�[�X�g
    '------------------------------
    Public Const gClngFstKbn_Driver As Integer = 0 ' �斱��
    Public Const gClngFstKbn_Hire As Integer = 1 ' �n�C���[
    Public Const gClngFstKbn_SemiHire As Integer = 2 ' �Z�~�n�C���[
    Public Const gClngFstKbn_Haken As Integer = 3 ' �h��
    Public Const gClngFstKbn_Jumbo As Integer = 4 ' �W�����{
    Public Const gClngFstKbn_SemiJumbo As Integer = 5 ' �Z�~�W�����{
    '--2013/07/16
    Public Const gClngFstKbn_Woman As Integer = 6 ' �����Z�~

    '------------------------------
    ' �\�����[�h
    '------------------------------
    Public Const GC_DISP_MODE_SEARCH As Short = 0 ' �������[�h
    Public Const GC_DISP_MODE_DIALOG As Short = 1 ' �_�C�A���O���[�h

    '------------------------------
    ' �\���敪
    '------------------------------
    Public Const GC_KBN_DISP_ALL As Short = 0 ' �S��
    Public Const GC_KBN_DISP_USE As Short = 1 ' �g�p���̂�
    Public Const GC_KBN_DISP_NOT_USE As Short = 2 ' ���g�p�̂�

    '------------------------------
    ' �Ɩ����[�h
    ' (����}�X�^�����e����щ�������ɂĎg�p)
    '------------------------------
    Public Const GC_MODE_BUSINESS_CLAIM As Short = 0 ' �����Ɩ����[�h
    Public Const GC_MODE_BUSINESS_REAPORT_INPUT As Short = 1 ' ������͋Ɩ����[�h

    '------------------------------
    ' �������[�h
    ' (��������ɂĎg�p)
    '------------------------------
    Public Const GC_MODE_SEARCH_NORMAL As Short = 0 ' �ʏ탂�[�h
    Public Const GC_MODE_SEARCH_ZANDAKA As Short = 1 ' �c���\�����[�h

    '------------------------------
    ' ��ʂ̊�{�T�C�Y
    '------------------------------
    Public Const GC_DEF_DISPLY_WIDTH As Integer = 1024
    Public Const GC_DEF_DISPLY_HEIGHT As Integer = 768


    Public Const gCstrNMMstDST_AirPort As String = "��`"


    Public Enum genYoto                             ' �p�r�敪
        '------------------------------
        Taxi                                        ' �^�N�V�[
        Hire                                        ' �n�C���[
        Jumbo                                       ' �W�����{
    End Enum

    '------------------------------
    ' �T�C�Y�敪
    '------------------------------
    Public Const GC_KBN_SIZE_SML As Short = 0 ' ���^
    Public Const GC_KBN_SIZE_MID As Short = 1 ' ���^
    Public Const GC_KBN_SIZE_LAR As Short = 2 ' ��^
    Public Const GC_KBN_SIZE_LAR_S As Short = 3 ' �����^

    '------------------------------
    ' ���敪
    '------------------------------
    Public Const GC_KBN_DAIJYO_NASI As Short = 0 ' ���Ȃ�
    Public Const GC_KBN_DAIJYO_ARI As Short = 1 ' ��悠��

    '------------------------------
    ' �Ɖ��� �������[�h
    '------------------------------
    Public Const GC_PROC_MODE_REFER As Short = 0 ' �Ɖ�[�h
    Public Const GC_PROC_MODE_SEARCH As Short = 1 ' �������[�h

    '------------------------------
    ' �V�t�g�敪
    '------------------------------
    Public Enum genShiftKbn
        ���� = 1
        ��� = 2
        ��� = 3
        �u�� = 4
    End Enum
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    Public Enum GC_KBN_SHIFT
        ���� = 1
        ��� = 2
        ��� = 3
        �u�� = 4
    End Enum

    Public Const GC_KBN_SHIFT_���� As String = "1"
    Public Const GC_KBN_SHIFT_��� As String = "2"
    Public Const GC_KBN_SHIFT_��� As String = "3"
    Public Const GC_KBN_SHIFT_�u�� As String = "4"
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    '------------------------------
    ' �Ζ��V�t�g�i�K����x�����̃`�F�b�N�Ɏg�p�j
    '------------------------------
    Public Const GC_WORK_SHIFT_���� As String = "12"
    Public Const GC_WORK_SHIFT_�u�� As String = "04"
    Public Const GC_WORK_SHIFT_���� As String = "99"

    '------------------------------
    ' �斱�敪�i�K����x�����̃`�F�b�N�Ɏg�p�j
    '------------------------------
    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    'Public Const GC_WORK_CREW_�^�N�V As String = GC_KBN_YOUTO_TAXI
    'Public Const GC_WORK_CREW_�n�C�� As String = GC_KBN_YOUTO_HIRE
    Public Const GC_WORK_CREW_�^�N�V As String = "0"
    Public Const GC_WORK_CREW_�n�C�� As String = "1"
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    Public Const GC_WORK_CREW_���� As String = "9"

    '------------------------------
    ' ���̋敪
    '------------------------------
    Public Const GC_KBN_ACCIDENT_NO1_CAUSE As Short = 1 ' ��P����
    Public Const GC_KBN_ACCIDENT_NO2_CAUSE As Short = 2 ' ��Q����
    Public Const GC_KBN_ACCIDENT_ONE_CAR As Short = 3 ' ����
    Public Const GC_KBN_ACCIDENT_ONE_CAR_SD As Short = 4 ' �����r�c

    Public Const GC_MAX_MONITOR_ITME_NUM As Short = 20 ' ���j�^�[���ʍ��ڍő吔

    '------------------------------
    ' �V�X�e���敪
    '------------------------------
    Public Const GC_KBN_SYSTEM_KYOUSYUU As String = "01" ' ���K�Ǘ�
    Public Const GC_KBN_SYSTEM_JIKO As String = "02" ' ���̊Ǘ�
    Public Const GC_KBN_SYSTEM_ZDSD As String = "03" ' �y�c�r�c�Ǘ�
    Public Const GC_KBN_SYSTEM_SOUMU As String = "04" ' �����Ǘ�

    '------------------------------
    ' �V�X�e���敪
    '------------------------------
    Public Const GC_MODE_LICENCE_INFO_NORMAL As Short = 0
    Public Const GC_MODE_LICENCE_INFO_KYOUSYUU As Short = 1

    '------------------------------
    ' ���ʋ��敪
    '------------------------------
    Public Const GC_KBN_���ʋ�_���� As Short = 0
    Public Const GC_KBN_���ʋ�_�ʋ� As Short = 1

    '------------------------------
    ' ����
    '------------------------------
    Public Const GC_����_�j As Short = 0
    Public Const GC_����_�� As Short = 1

    '------------------------------
    ' ���ʎ蓖�敪
    '------------------------------
    Public Const GC_KBN_���ʎ蓖�x��_�Ȃ� As Short = 0
    Public Const GC_KBN_���ʎ蓖�x��_���� As Short = 1

    '------------------------------
    ' ���R�[�h�敪
    '------------------------------
    Public Const GC_KBN_�{�R�[�h As Short = 0
    Public Const GC_KBN_���R�[�h As Short = 1

    '------------------------------
    ' �ΑӃ}�X�^ ����
    '------------------------------
    Public Const GC_WORK_CODE_GROUP_�o�� As Short = 0
    Public Const GC_WORK_CODE_GROUP_���x As Short = 1
    Public Const GC_WORK_CODE_GROUP_���� As Short = 2
    Public Const GC_WORK_CODE_GROUP_�c�� As Short = 3
    Public Const GC_WORK_CODE_GROUP_�x�� As Short = 4
    Public Const GC_WORK_CODE_GROUP_���� As Short = 5
    Public Const GC_WORK_CODE_GROUP_���� As Short = 6
    Public Const GC_WORK_CODE_GROUP_�L�x As Short = 7
    Public Const GC_WORK_CODE_GROUP_���o As Short = 8
    Public Const GC_WORK_CODE_GROUP_�L���\�� As Short = 51
    Public Const GC_WORK_CODE_GROUP_���o�\�� As Short = 52

    '------------------------------
    ' ��ЃR�[�h
    '------------------------------
    Public Const GC_COMPANY_CODE_KYOTO As String = "0" ' �G���P�C�������
    Public Const GC_COMPANY_CODE_TRACEN As String = "8" ' �G���P�C�������(�g���[�j���O�Z���^�[)
    Public Const GC_COMPANY_CODE_KOBE As String = "5" ' �_�˃G���P�C�������
    Public Const GC_COMPANY_CODE_OSAKA As String = "6" ' ���G���P�C�������
    Public Const GC_COMPANY_CODE_NAGOYA As String = "7" ' ���É��G���P�C�������
    Public Const GC_COMPANY_CODE_FUKUOKA As String = "30" ' �����G���P�C�������
    Public Const GC_COMPANY_CODE_SHIGA As String = "40" ' ����G���P�C�������
    Public Const GC_COMPANY_CODE_SAPPORO As String = "50" ' �D�y�G���P�C�������
    Public Const GC_COMPANY_CODE_KANKU As String = "60" ' �֋�G���P�C������� '//2018/10/04
    Public Const GC_COMPANY_CODE_TOKYO As String = "20" ' �����G���P�C�������
    Public Const GC_COMPANY_CODE_CITY As String = "21" ' �����V�e�B�G�X�R�[�g

    Public Const GC_�@�x�Œ蕶�� As String = "�y�@�z" '//2018/02
    Public Const GC_���x�Œ蕶�� As String = "(���x)" '//2019/08/13
    Public Const GC_�U�֗L���Œ蕶�� As String = "*�U" '//2019/08/13
End Module