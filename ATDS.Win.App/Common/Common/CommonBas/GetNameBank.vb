Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basGetNameBank
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
	' ファイル名  : GetNameBank.bas
	' 内    容    : 銀行マスタ 名称 取得 モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'                   gfncGetNameBank               (銀行マスタ 名称 取得)
	'               <Private>
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/02/01  廣井  芳明         新規作成
	'
	'******************************************************************************
	'==============================================================================
	' 定数
	'==============================================================================
	Private Const MC_TABLE_銀行マスタ As String = "銀行マスタ"
	'******************************************************************************
	' 関 数 名  : gfncGetNameBank
	' スコープ  : Public
	' 処理内容  : 銀行マスタ 名称 取得
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     銀行コード
	'   pstrBankName        String            O     銀行名漢字
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/02/01  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetNameBank(ByVal pstrBankCode As String, ByRef pstrBankName As String) As Boolean
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetNameBank"
		Dim objDysGK_M As OraDynaset ' 銀行マスタのOradynaset
		Dim strSQL As String
'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Const C_NAME_FUNCTION As String = "gfncGetNameBank"
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		
		'++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
		'Dim objDysGK_M As Object ' 銀行マスタのOradynaset
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim objDysGK_M As OraDynaset ' 銀行マスタのOradynaset
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		'--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim strSQL As String
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		
		' 戻り値を初期化（異常終了）
		gfncGetNameBank = True
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    銀行名漢字 "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "   " & MC_TABLE_銀行マスタ & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    銀行コード = '" & pstrBankCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysGK_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysGK_M
			
			' 該当するデータが見つかった場合
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysGK_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' 戻り値を設定（正常終了）
				gfncGetNameBank = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysGK_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				pstrBankName = gfncFieldVal(.Fields("銀行名漢字").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysGK_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Close()
			
		End With
		
'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:025ab725-d710-40ac-84b8-3021bd80d377
'PROC_END:
		
	'Call gsubClearObject(objDysGK_M)
		
	'Exit Function
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:025ab725-d710-40ac-84b8-3021bd80d377
	Catch ex As Exception
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
	'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b5b7a20d-c682-44df-aceb-5cede829d49e
	'Resume PROC_END
	'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b5b7a20d-c682-44df-aceb-5cede829d49e
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b5b7a20d-c682-44df-aceb-5cede829d49e
	PROC_FINALLY_END:
		Call gsubClearObject(objDysGK_M)
		Exit Function
	'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b5b7a20d-c682-44df-aceb-5cede829d49e
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
End Module
