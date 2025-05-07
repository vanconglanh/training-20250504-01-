Option Strict Off
Option Explicit On
Module basGetNameAccountCompany
	'******************************************************************************
	' 関 数 名  : gfncGetNameAccountCompany
	' スコープ  : Public
	' 処理内容  : 振込先会社名 取得
	' 備    考  :
	' 返 り 値  : 振込先会社名
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrCompanyCode     String            I     会社コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetNameAccountCompany(ByVal pstrCompanyCode As String) As String
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetNameAccountCompany"
		Dim strSQL As String
		Dim objDys会社マスタ As Object
'--修正終了　2021年06月20:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		
		' 戻り値を初期化
		gfncGetNameAccountCompany = GC_DEF_運管_口座名義
		
		' SQL文 作成
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    振込先名義 "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    会社マスタ "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    会社コード= '" & pstrCompanyCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDys会社マスタ = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDys会社マスタ
			
			' 該当するデータが存在する場合
			'UPGRADE_WARNING: Couldn't resolve default property of object objDys会社マスタ.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' 戻り値を設定
				'UPGRADE_WARNING: Couldn't resolve default property of object objDys会社マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gfncGetNameAccountCompany = gfncFieldVal(.Fields("振込先名義").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDys会社マスタ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Close()
			
		End With
		
'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:1814c2b4-43e2-45b8-b151-78a992010f34
'PROC_END:
		
	'Call gsubClearObject(objDys会社マスタ)
		
	'Exit Function
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:1814c2b4-43e2-45b8-b151-78a992010f34
	Catch ex As Exception
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:4e040c9a-e7e2-4175-a187-851572b12a3a
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:4e040c9a-e7e2-4175-a187-851572b12a3a
		'--修正終了　2021年06月20:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:4e040c9a-e7e2-4175-a187-851572b12a3a
	PROC_FINALLY_END:
		Call gsubClearObject(objDys会社マスタ)
		Exit Function
	'--修正終了　2021年06月20:MK（ツール）- VB_523 VB→VB.NET変換	T:4e040c9a-e7e2-4175-a187-851572b12a3a
	'--修正終了　2021年06月20:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
End Module
