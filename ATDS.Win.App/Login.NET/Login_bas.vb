Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basLogin
	
	'++修正開始　2021年05月31:MK（ツール）- OR_005 VB→VB.NET変換
	'Public gobjOraSession As Object ' Oracle
	Public gobjOraSession As OraSession ' Oracle
	'--修正終了　2021年05月31:MK（ツール）- OR_005 VB→VB.NET変換
	'++修正開始　2021年05月31:MK（ツール）- OR_002 VB→VB.NET変換
	'Public gobjOraDatabase As Object ' Oracle
	Public gobjOraDatabase As OraDatabase ' Oracle
	'--修正終了　2021年05月31:MK（ツール）- OR_002 VB→VB.NET変換
	Public gvntLoginDate As Object ' ログイン日付
	Public gstrCompanyCode As String ' 会社コード
	Public gstrPostCode As String ' 部署コード
	Public gstrEmployeeCode As String ' 従業員コード
	Public gstrEmployeeName As String ' 従業員名
	Public gintSystemAuthority As Short ' システム権限
	Public gstrRank As String ' ランク
	Public gintOfficialPosition As Short ' 役職位
	Public gintOkCancel As Short
End Module
