Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basGetSyoteiRoudouHour
	'******************************************************************************
	' 関 数 名  : gFNC_GET_SyoteiRoudouHour
	' スコープ  : Public
	' 処理内容  : 所定労働時間取得
	' 備    考  :
	' 返 り 値  :
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2019/10/03  ＫＳＲ        　　 新規作成
	'
	'******************************************************************************
	Public Function gFNC_GET_SyoteiRoudouHour(ByVal pstr年月日 As String, ByVal pstr所属コード As String, ByVal pstrファースト As String, ByVal pstrシフト区分 As String) As Decimal
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gFNC_GET_SyoteiRoudouHour"
		Dim CurRet As Decimal
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		Dim strYear As String '//2019/10/03
		Dim strMonth As String '//2019/10/03
'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Const C_NAME_FUNCTION As String = "gFNC_GET_SyoteiRoudouHour"
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim CurRet As Decimal
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim strSQL As String
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		'++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
		'Dim objDysTemp As Object
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim objDysTemp As OraDynaset
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		'--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
		
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim strYear As String '//2019/10/03
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
	'Dim strMonth As String '//2019/10/03
	'--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
		strYear = gfncGetFiscalYear(pstr年月日)
		strMonth = Right(gfncGetFiscalYearMonth(pstr年月日), 2)
		
		CurRet = 0
		
		' SQL文 作成
		strSQL = strSQL & vbCrLf & "select "
		strSQL = strSQL & vbCrLf & "基準労働時間" & strMonth & "月 AS 所定労働時間"
		strSQL = strSQL & vbCrLf & "from 規定公休日数マスタ"
		strSQL = strSQL & vbCrLf & "WHERE 1 = 1"
		strSQL = strSQL & vbCrLf & "AND 年度 = " & strYear
		strSQL = strSQL & vbCrLf & "AND 所属コード = '" & pstr所属コード & "'"
		strSQL = strSQL & vbCrLf & "AND ファースト = '" & pstrファースト & "'"
		strSQL = strSQL & vbCrLf & "AND シフト区分 = '" & pstrシフト区分 & "'"
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysTemp
			
			' 該当するデータが存在しない場合
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .EOF = True Then
				
				CurRet = 0
				
				' 該当するデータが存在する場合
			Else
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CurRet = gfncFieldCur(.Fields("所定労働時間").Value)
				
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ed36c9b6-ba66-4974-b0d1-594a2e56e801
'PROC_END:
		
	'gFNC_GET_SyoteiRoudouHour = CurRet
		
	'Exit Function
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ed36c9b6-ba66-4974-b0d1-594a2e56e801
	Catch ex As Exception
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
	'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:583b106a-3339-40d9-ae0b-1aef6edaad54
	'Resume PROC_END
	'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:583b106a-3339-40d9-ae0b-1aef6edaad54
		
	'++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:583b106a-3339-40d9-ae0b-1aef6edaad54
	PROC_FINALLY_END:
		gFNC_GET_SyoteiRoudouHour = CurRet
		Exit Function
	'--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:583b106a-3339-40d9-ae0b-1aef6edaad54
	'--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
End Module
