Option Strict Off
Option Explicit On
Module basConstMstAccount
	'******************************************************************************
	' ��ۼު�Ė�  : �G���P�C�V�X�e������
	' �t�@�C����  : ConstMstAccount.cls
	' ��    �e    : �����ԍ��}�X�^ ��� �萔�錾 ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'               <Private>
	'               <Property>
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/30  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Const GC_LEN_ACCOUNT_SYSTEM_KBN As Short = 1
	
	'----------------------------------
	' �V�X�e���敪
	'----------------------------------
	Public Const GC_SYSTEM_KBN_NO As Short = -1 ' ���w��
	Public Const GC_SYSTEM_KBN_UNKAN As Short = 0 ' �^�s�Ǘ��V�X�e��
	Public Const GC_SYSTEM_KBN_URIKAKE As Short = 1 ' ���|�����Ǘ��V�X�e��
	Public Const GC_SYSTEM_KBN_KASHITUKE As Short = 2 ' �ݕt���Ǘ��V�X�e��
End Module