Option Strict Off
Option Explicit On
Module basGetDriveFreeSpace
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
	' ファイル名  : GetDriveFreeSpace.bas
	' 内    容    : ドライブ空き領域 取得 モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'                   gfncGetDriveFreeSpace        (ドライブ空き領域 取得)
	'               <Private>
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00       2008/09/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	'******************************************************************************
	' 関 数 名  : gfncGetDriveFreeSpace
	' スコープ  : Public
	' 処理内容  : ドライブ空き領域 取得
	' 備    考  :
	' 返 り 値  : ドライブ空き領域
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrDrvPath         String            I     ドライブパス
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00       2008/09/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetDriveFreeSpace(ByVal pstrDrvPath As String) As Decimal
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'On Error GoTo PROC_ERROR
'++修正開始　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetDriveFreeSpace"
		Dim objFso As Object
		Dim objDrive As Object
'--修正終了　2021年06月13:MK（ツール）- VB_530 VB→VB.NET変換
	Try
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		
		
		gfncGetDriveFreeSpace = 0
		
		objFso = CreateObject("Scripting.FileSystemObject")
		'UPGRADE_WARNING: Couldn't resolve default property of object objFso.GetDriveName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object objFso.GetDrive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDrive = objFso.GetDrive(objFso.GetDriveName(pstrDrvPath))
		
		'UPGRADE_WARNING: Couldn't resolve default property of object objDrive.FreeSpace. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gfncGetDriveFreeSpace = CDec(FormatNumber(objDrive.FreeSpace, 0))
		
'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:c14e8343-3226-49a4-8b54-6be5f69eca95
'PROC_END:
		
	'Exit Function
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	'PROC_ERROR:
'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:c14e8343-3226-49a4-8b54-6be5f69eca95
	Catch ex As Exception
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++修正開始　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		'Resume PROC_END
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
		'--修正終了　2021年06月05:MK（ツール）- VB_003 VB→VB.NET変換
		
	'++修正開始　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
	'++修正開始　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
	PROC_FINALLY_END:
		Exit Function
	'--修正終了　2021年06月13:MK（ツール）- VB_523 VB→VB.NET変換	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
	'--修正終了　2021年06月13:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
End Module
