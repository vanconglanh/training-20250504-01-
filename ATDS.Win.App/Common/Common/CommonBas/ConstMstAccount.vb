Option Strict Off
Option Explicit On
Module basConstMstAccount
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : エムケイシステム共通
	' ファイル名  : ConstMstAccount.cls
	' 内    容    : 口座番号マスタ 情報 定数宣言 モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'               <Private>
	'               <Property>
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/30  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Const GC_LEN_ACCOUNT_SYSTEM_KBN As Short = 1
	
	'----------------------------------
	' システム区分
	'----------------------------------
	Public Const GC_SYSTEM_KBN_NO As Short = -1 ' 未指定
	Public Const GC_SYSTEM_KBN_UNKAN As Short = 0 ' 運行管理システム
	Public Const GC_SYSTEM_KBN_URIKAKE As Short = 1 ' 売掛請求管理システム
	Public Const GC_SYSTEM_KBN_KASHITUKE As Short = 2 ' 貸付金管理システム
End Module