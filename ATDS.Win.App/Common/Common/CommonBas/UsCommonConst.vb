Option Strict Off
Option Explicit On
Module basUsCommonConst
	
	'==============================================================================
	' �萔
	'==============================================================================
	Public Const GC_IDX_PG_WORK_TABLE_HEAD As Short = 0
	Public Const GC_IDX_PG_WORK_TABLE_BODY As Short = 1
	'++�C���J�n�@2023�N10��15��:MK�i��j- VB��VB.NET�ϊ�
	Public Const GC_IDX_PG_WORK_TABLE_BODY_OTHER As Short = 2
	'--�C���J�n�@2023�N10��15��:MK�i��j- VB��VB.NET�ϊ�
	
	Public Const GC_QUANTITY_DISCOUNT_MONEY As Integer = 10000 ' ��������K�����z
	
	' ���������ԍ��J�n
	Public Const GC_ZUIJI_BILL_NUMBER_START As Decimal = 9000000000#
	
	Public Const GC_KBN_�C��_���� As Short = 0
	Public Const GC_KBN_�C��_���� As Short = 1
	
	'----------------------------------
	' ��s�R�[�h
	'----------------------------------
	Public Const GC_BANK_MK_KARIUKE As String = "8000" ' ������z
	Public Const GC_BANK_MK_NYUUKIN_KYOTO As String = "9998" ' ��  �s�l�j����
	Public Const GC_BANK_MK_HENKIN As String = "9999" ' �l�j�ԋ�
	
	'----------------------------------
	' ��s�敪
	'----------------------------------
	Public Const GC_BANK_KBN_MK_NORMAL As Short = 0 ' �ʏ�
	Public Const GC_BANK_KBN_MK_NYUUKIN As Short = 1 ' �l�j����
	Public Const GC_BANK_KBN_MK_HENKIN As Short = 2 ' �l�j�ԋ�
	Public Const GC_BANK_KBN_MK_KARIUKE As Short = 3 ' ����
	
	'----------------------------------
	' �����敪
	'----------------------------------
	Public Const GC_NYUUKIN_KBN_FURIKOMI As String = "2" ' �U��
	Public Const GC_NYUUKIN_KBN_MK_NYUUKIN As String = "4" ' �l�j����
	Public Const GC_NYUUKIN_KBN_MK_HENKIN As String = "5" ' �l�j�ԋ�
	
	'----------------------------------
	' �Վ��Œ蕶�� 2016/02/04 ��03/25
	'----------------------------------
	Public Const GC_TEMP_INFORMATION_A As String = "" ' �P�s��
	Public Const GC_TEMP_INFORMATION_B As String = "" ' �Q�s��
	Public Const GC_TEMP_INFORMATION_SETFLUG As Boolean = False '//�ʏ��FALSE�ɂ��Ă���
	
	
	
	'20160330 ADD START
	'------------------------------
	' �|�b�v�A�b�v����
	'------------------------------
	' �`�P�b�g���ח���
	Public Const GC_PRAM_SKP090_���t As Short = 0
	Public Const GC_PRAM_SKP090_���tTO As Short = 1
	
	'20160330 ADD END
	
	'----------------------------------
	' �� �U������ ���[�h
	'----------------------------------
	Public Const GC_PRINT_ACCOUNT_MODE_NORMAL As String = "1" ' �ʏ�
	Public Const GC_PRINT_ACCOUNT_MODE_PERFECT As String = "2" ' �p�[�t�F�N�g
	
	'----------------------------------
	' �N���W�b�g�������l���敪
	'----------------------------------
	Public Const GC_KBN_BILL_FMT_NORMAL As String = "0" ' �ʏ�
	Public Const GC_KBN_BILL_FMT_MEMO As String = "1" ' ���l����
	Public Const GC_KBN_BILL_FMT_NORMAL_DISP_OFF As String = "2" ' �ʏ�     (�c���\���Ȃ�)
	Public Const GC_KBN_BILL_FMT_MEMO_DISP_OFF As String = "3" ' ���l���� (�c���\���Ȃ�)
	Public Const GC_KBN_BILL_FMT_NORMAL_DISP_ON As String = "4" ' �ʏ�     (�c���\������)
	Public Const GC_KBN_BILL_FMT_MEMO_DISP_ON As String = "5" ' ���l���� (�c���\������)
End Module