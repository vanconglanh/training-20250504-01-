Option Strict Off
Option Explicit On
Module basGetNameBranch
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
	' ファイル名  : GetMstBranch.bas
	' 内    容    : 支店マスタ 情報 取得 モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'                   gfncGetNameBranch             (支店マスタ取得)
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
	Private Const MC_TABLE_支店マスタ As String = "支店マスタ"
	'******************************************************************************
	' 関 数 名  : gfncGetNameBranch
	' スコープ  : Public
	' 処理内容  : 支店マスタ取得
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     銀行コード
	'   pstrBranchCode      String            I     支店コード
	'   pstrBranckName      String            O     支店名漢字
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/02/01  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetNameBranch(ByVal pstrBankCode As String, ByVal pstrBranchCode As String, ByRef pstrBranckName As String) As Boolean
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetNameBranch"
		Dim objDysST_M As Object ' 支店マスタのOradynaset
		Dim strSQL As String
'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Const C_NAME_FUNCTION As String = "gfncGetNameBranch"
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim objDysST_M As Object ' 支店マスタのOradynaset
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim strSQL As String
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		
		' 戻り値を初期化（異常終了）
		gfncGetNameBranch = True
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    支店名漢字 "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "   " & MC_TABLE_支店マスタ & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    銀行コード = '" & pstrBankCode & "' "
		strSQL = strSQL & Chr(10) & "AND 支店コード = '" & pstrBranchCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysST_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysST_M
			
			' 該当するデータが見つかった場合
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysST_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' 戻り値を設定（正常終了）
				gfncGetNameBranch = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysST_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				pstrBranckName = gfncFieldVal(.Fields("支店名漢字").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysST_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Close()
			
		End With
		
'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:42bdf1bb-7c68-4fe3-b9d2-59662370db5e
'PROC_END:
		
	'Call gsubClearObject(objDysST_M)
		
	'Exit Function
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:42bdf1bb-7c68-4fe3-b9d2-59662370db5e
	Catch ex As Exception
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
	'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e57a3f43-e8d4-440e-854b-91da49f679c6
	'Resume PROC_END
	'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e57a3f43-e8d4-440e-854b-91da49f679c6
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e57a3f43-e8d4-440e-854b-91da49f679c6
	PROC_FINALLY_END:
		Call gsubClearObject(objDysST_M)
		Exit Function
	'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e57a3f43-e8d4-440e-854b-91da49f679c6
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
End Module
