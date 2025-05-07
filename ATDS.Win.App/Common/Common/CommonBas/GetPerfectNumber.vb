Option Strict Off
Option Explicit On
Module basGetPerfectNumber
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
	' ファイル名  : GetPerfectNumber.bas
	' 内    容    : パーフェクト番号 取得 モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'                   gfncGetPerfectNumber         (パーフェクト番号取得)
	'               <Private>
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : gfncGetPerfectNumber
	' スコープ  : Public
	' 処理内容  : パーフェクト番号取得
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrTableName       String            I     テーブル名
	'   pstrPerfectNumber   String            O     パーフェクト番号
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetPerfectNumber(ByVal pstrTableName As String, ByRef pstrPerfectNumber As String) As Boolean
		
	'++修正開始　2021年06月05:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月05:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetPerfectNumber"
		Dim strSQL As String
		Dim objDysパーフェクトテーブル As Object
'--修正終了　2021年06月05:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月05:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		
		' 戻り値を初期化（異常終了）
		gfncGetPerfectNumber = True
		
		pstrPerfectNumber = ""
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    入金先口座番号 "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    " & pstrTableName & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    (入金先口座番号,履歴番号) IN "
		strSQL = strSQL & Chr(10) & "    ( "
		strSQL = strSQL & Chr(10) & "        SELECT "
		strSQL = strSQL & Chr(10) & "            入金先口座番号, "
		strSQL = strSQL & Chr(10) & "            MAX(履歴番号)   "
		strSQL = strSQL & Chr(10) & "        FROM "
		strSQL = strSQL & Chr(10) & "            " & pstrTableName & " "
		strSQL = strSQL & Chr(10) & "        WHERE "
		strSQL = strSQL & Chr(10) & "            (自動採番対象区分 IS NULL OR "
		strSQL = strSQL & Chr(10) & "             自動採番対象区分 <> 1    )  "
		strSQL = strSQL & Chr(10) & "        GROUP BY "
		strSQL = strSQL & Chr(10) & "            入金先口座番号 "
		strSQL = strSQL & Chr(10) & "        HAVING "
		strSQL = strSQL & Chr(10) & "            SUM(使用区分) = 0 "
		strSQL = strSQL & Chr(10) & "    ) "
		strSQL = strSQL & Chr(10) & "ORDER BY "
		strSQL = strSQL & Chr(10) & "    入金先口座番号 "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysパーフェクトテーブル = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysパーフェクトテーブル
			
			' 該当するデータが存在する場合
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysパーフェクトテーブル.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				'戻り値を設定（正常終了）
				gfncGetPerfectNumber = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysパーフェクトテーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				pstrPerfectNumber = gfncFieldVal(.Fields("入金先口座番号").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysパーフェクトテーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
'++修正開始　2021年06月05:MK（ツール）- VB_523 VB→VB.NET変換	T:84504f24-bf06-482b-b54c-f196d8c493f4
'PROC_END:
		
	'Call gsubClearObject(objDysパーフェクトテーブル)
		
	'Exit Function
		
	'++修正開始　2021年06月05:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月05:MK（ツール）- VB_523 VB→VB.NET変換	T:84504f24-bf06-482b-b54c-f196d8c493f4
	Catch ex As Exception
	'--修正終了　2021年06月05:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月05:MK（ツール）- VB_523 VB→VB.NET変換	T:651abb5f-fd2d-42cb-b076-30cd857464dc
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月05:MK（ツール）- VB_523 VB→VB.NET変換	T:651abb5f-fd2d-42cb-b076-30cd857464dc
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月05:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月05:MK（ツール）- VB_523 VB→VB.NET変換	T:651abb5f-fd2d-42cb-b076-30cd857464dc
	PROC_FINALLY_END:
		Call gsubClearObject(objDysパーフェクトテーブル)
		Exit Function
	'--修正終了　2021年06月05:MK（ツール）- VB_523 VB→VB.NET変換	T:651abb5f-fd2d-42cb-b076-30cd857464dc
	'--修正終了　2021年06月05:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
End Module
