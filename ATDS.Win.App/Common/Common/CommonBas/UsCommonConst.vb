Option Strict Off
Option Explicit On
Module basUsCommonConst
	
	'==============================================================================
	' 定数
	'==============================================================================
	Public Const GC_IDX_PG_WORK_TABLE_HEAD As Short = 0
	Public Const GC_IDX_PG_WORK_TABLE_BODY As Short = 1
	'++修正開始　2023年10月15日:MK（手）- VB→VB.NET変換
	Public Const GC_IDX_PG_WORK_TABLE_BODY_OTHER As Short = 2
	'--修正開始　2023年10月15日:MK（手）- VB→VB.NET変換
	
	Public Const GC_QUANTITY_DISCOUNT_MONEY As Integer = 10000 ' 大口割引適応金額
	
	' 随時請求番号開始
	Public Const GC_ZUIJI_BILL_NUMBER_START As Decimal = 9000000000#
	
	Public Const GC_KBN_修正_売上 As Short = 0
	Public Const GC_KBN_修正_入金 As Short = 1
	
	'----------------------------------
	' 銀行コード
	'----------------------------------
	Public Const GC_BANK_MK_KARIUKE As String = "8000" ' 仮受金額
	Public Const GC_BANK_MK_NYUUKIN_KYOTO As String = "9998" ' 京  都ＭＫ入金
	Public Const GC_BANK_MK_HENKIN As String = "9999" ' ＭＫ返金
	
	'----------------------------------
	' 銀行区分
	'----------------------------------
	Public Const GC_BANK_KBN_MK_NORMAL As Short = 0 ' 通常
	Public Const GC_BANK_KBN_MK_NYUUKIN As Short = 1 ' ＭＫ入金
	Public Const GC_BANK_KBN_MK_HENKIN As Short = 2 ' ＭＫ返金
	Public Const GC_BANK_KBN_MK_KARIUKE As Short = 3 ' 仮受
	
	'----------------------------------
	' 入金区分
	'----------------------------------
	Public Const GC_NYUUKIN_KBN_FURIKOMI As String = "2" ' 振込
	Public Const GC_NYUUKIN_KBN_MK_NYUUKIN As String = "4" ' ＭＫ入金
	Public Const GC_NYUUKIN_KBN_MK_HENKIN As String = "5" ' ＭＫ返金
	
	'----------------------------------
	' 臨時固定文言 2016/02/04 →03/25
	'----------------------------------
	Public Const GC_TEMP_INFORMATION_A As String = "" ' １行目
	Public Const GC_TEMP_INFORMATION_B As String = "" ' ２行目
	Public Const GC_TEMP_INFORMATION_SETFLUG As Boolean = False '//通常はFALSEにしておく
	
	
	
	'20160330 ADD START
	'------------------------------
	' ポップアップ引数
	'------------------------------
	' チケット明細履歴
	Public Const GC_PRAM_SKP090_日付 As Short = 0
	Public Const GC_PRAM_SKP090_日付TO As Short = 1
	
	'20160330 ADD END
	
	'----------------------------------
	' 印字 振込口座 モード
	'----------------------------------
	Public Const GC_PRINT_ACCOUNT_MODE_NORMAL As String = "1" ' 通常
	Public Const GC_PRINT_ACCOUNT_MODE_PERFECT As String = "2" ' パーフェクト
	
	'----------------------------------
	' クレジット請求書様式区分
	'----------------------------------
	Public Const GC_KBN_BILL_FMT_NORMAL As String = "0" ' 通常
	Public Const GC_KBN_BILL_FMT_MEMO As String = "1" ' 備考あり
	Public Const GC_KBN_BILL_FMT_NORMAL_DISP_OFF As String = "2" ' 通常     (残高表示なし)
	Public Const GC_KBN_BILL_FMT_MEMO_DISP_OFF As String = "3" ' 備考あり (残高表示なし)
	Public Const GC_KBN_BILL_FMT_NORMAL_DISP_ON As String = "4" ' 通常     (残高表示あり)
	Public Const GC_KBN_BILL_FMT_MEMO_DISP_ON As String = "5" ' 備考あり (残高表示あり)
End Module