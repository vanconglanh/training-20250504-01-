Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basUsCommonFunction
	'******************************************************************************
	' ﾌﾟﾛｼﾞｪｸﾄ名  : 売掛請求管理システム
	' ファイル名  : UsCommonFunction.bas
	' 内    容    : 売掛請求管理 共通 モジュール
	' 備    考    :
	' 関数一覧    : <Public>
	'               <Private>
	'
	' 変更履歴    :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  廣井  芳明         新規作成
	'   02.26.00    2010/03/11  廣井  芳明         ＭＫ会員マスタのパーフェクト固定についても開放するように修正。
	'   02.32.00    2010/03/23  廣井  芳明         ＳＱＬ文の不具合修正。
	'   02.33.00    2010/03/24  廣井  芳明         前回の締日請求データが存在しない場合に,
	'                                              請求済請求事務手数料が取得できなくなる不具合に対応。
	'   02.33.00    2015/12/18  ＫＳＲ             入金検索時は請求修正テーブルのワーク作成に15秒ほどかかるため、
	'                                              入金検索時の請求修正テーブルの更新日・件数が変わった時のみ処理が走るように修正。
	'   02.34.00    2016/03/30  ＫＳＲ             チケット明細テーブル履歴保存用の処理を追加
	'                                              PopUP制御用変数の追加
	'
	'******************************************************************************
	'==============================================================================
	' ＡＰＩ宣言
	'==============================================================================
	' システムを立ち上げてからの経過時間を高精度に取得する（デバッグ用）
	Private Declare Function timeGetTime Lib "winmm.dll" () As Integer
	'==============================================================================
	' ＡＰＩ関数
	'==============================================================================
	Public Const VK_SHIFT As Integer = &H10

	'==============================================================================
	' 定数
	'==============================================================================
	Private Const MC_TBL_請求テーブル As String = "請求テーブル"

	'20160330 ADD START
	'==============================================================================
	' 変数
	'==============================================================================
	'Public gclsSKP090                           As clsUnitUsPopUpInfo       'PopUP制御（チケット明細履歴） 2018/08/06 SKP090を修正するとき、個別にする
	'20160330 ADD END


	' 仮想キーの押下状態取得
	Public Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Integer) As Short

	'******************************************************************************
	' 関 数 名  : gfncUpdateTblPerfectAuto
	' スコープ  : Public
	' 処理内容  : パーフェクトテーブル 自動削除
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日　付      氏　名        　　 修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2008/10/21  廣井　芳明      　 新規作成
	'   02.26.00    2010/03/11  廣井  芳明         ＭＫ会員マスタのパーフェクト固定についても開放するように修正。
	'   02.32.00    2010/03/23  廣井  芳明         ＳＱＬ文の不具合修正。
	'
	'******************************************************************************
	Public Function gfncUpdateTblPerfectAuto(ByVal pstrYearMonth As String) As Boolean

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncUpdateTblPerfectAuto"
		Dim strSQL As String
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換



			' 戻り値を初期化（異常終了）
			gfncUpdateTblPerfectAuto = True

			strSQL = ""
			strSQL = strSQL & Chr(10) & "UPDATE パーフェクトテーブル "
			strSQL = strSQL & Chr(10) & "SET 使用区分         = '0' "
			strSQL = strSQL & Chr(10) & ",   更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "' "
			strSQL = strSQL & Chr(10) & ",   更新日付時刻     = SYSDATE "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    使用区分           = '1' "
			strSQL = strSQL & Chr(10) & "AND (自動採番対象区分 IS NULL OR "
			strSQL = strSQL & Chr(10) & "     自動採番対象区分 <> 1    )  "
			strSQL = strSQL & Chr(10) & "AND (会員コード, 会員枝コード) IN "
			strSQL = strSQL & Chr(10) & "    ( "
			strSQL = strSQL & Chr(10) & "        SELECT "
			strSQL = strSQL & Chr(10) & "            PFT.会員コード   "
			strSQL = strSQL & Chr(10) & "           ,PFT.会員枝コード "
			strSQL = strSQL & Chr(10) & "        FROM "
			strSQL = strSQL & Chr(10) & "            ＭＫ請求会員マスタ   KM  "
			strSQL = strSQL & Chr(10) & "           ,パーフェクトテーブル PFT "
			strSQL = strSQL & Chr(10) & "           ,( "
			strSQL = strSQL & Chr(10) & "                SELECT "
			strSQL = strSQL & Chr(10) & "                    顧客コード            "
			strSQL = strSQL & Chr(10) & "                   ,顧客枝コード          "
			strSQL = strSQL & Chr(10) & "                   ,MAX(処理年月) AS 年月 "
			strSQL = strSQL & Chr(10) & "                FROM "
			strSQL = strSQL & Chr(10) & "                    売掛管理テーブル "
			strSQL = strSQL & Chr(10) & "                WHERE "
			strSQL = strSQL & Chr(10) & "                    当月残高  = 0 "
			strSQL = strSQL & Chr(10) & "                AND 処理年月 <= '" & pstrYearMonth & "' "
			strSQL = strSQL & Chr(10) & "                GROUP BY "
			strSQL = strSQL & Chr(10) & "                    顧客コード   "
			strSQL = strSQL & Chr(10) & "                   ,顧客枝コード "
			strSQL = strSQL & Chr(10) & "            ) UKT "
			strSQL = strSQL & Chr(10) & "        WHERE "
			strSQL = strSQL & Chr(10) & "            KM.会員コード          = PFT.会員コード   "
			strSQL = strSQL & Chr(10) & "        AND KM.会員枝コード        = PFT.会員枝コード "
			strSQL = strSQL & Chr(10) & "        AND KM.会員コード          = UKT.顧客コード   "
			strSQL = strSQL & Chr(10) & "        AND KM.会員枝コード        = UKT.顧客枝コード "
			strSQL = strSQL & Chr(10) & "        AND KM.利用区分            = '02' "
			strSQL = strSQL & Chr(10) & "        AND PFT.使用区分           = '1' "
			strSQL = strSQL & Chr(10) & "        AND ( "
			strSQL = strSQL & Chr(10) & "                PFT.自動採番対象区分 IS NULL "
			strSQL = strSQL & Chr(10) & "             OR PFT.自動採番対象区分 <> 1    "
			strSQL = strSQL & Chr(10) & "            ) "
			strSQL = strSQL & Chr(10) & "    ) "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			strSQL = ""
			strSQL = strSQL & Chr(10) & "UPDATE ＭＫ会員マスタ "
			strSQL = strSQL & Chr(10) & "SET 入金先口座番号       = NULL      "
			strSQL = strSQL & Chr(10) & ",   パーフェクト使用区分 = 0         "
			strSQL = strSQL & Chr(10) & ",   パーフェクト固定     = 0         "
			strSQL = strSQL & Chr(10) & ",   更新従業員コード     = '" & gclsLoginInfo.EmployeeCode & "' "
			strSQL = strSQL & Chr(10) & ",   更新日付時刻         = SYSDATE   "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    入金先口座番号 IS NOT NULL"
			strSQL = strSQL & Chr(10) & "AND (会員コード, 会員枝コード) IN "
			strSQL = strSQL & Chr(10) & "    ( "
			strSQL = strSQL & Chr(10) & "        SELECT "
			strSQL = strSQL & Chr(10) & "            UKT.顧客コード   "
			strSQL = strSQL & Chr(10) & "           ,UKT.顧客枝コード "
			strSQL = strSQL & Chr(10) & "        FROM "
			strSQL = strSQL & Chr(10) & "            ＭＫ請求会員マスタ KM "
			strSQL = strSQL & Chr(10) & "           ,( "
			strSQL = strSQL & Chr(10) & "                SELECT "
			strSQL = strSQL & Chr(10) & "                    顧客コード            "
			strSQL = strSQL & Chr(10) & "                   ,顧客枝コード          "
			strSQL = strSQL & Chr(10) & "                   ,MAX(処理年月) AS 年月 "
			strSQL = strSQL & Chr(10) & "                FROM "
			strSQL = strSQL & Chr(10) & "                    売掛管理テーブル "
			strSQL = strSQL & Chr(10) & "                WHERE "
			strSQL = strSQL & Chr(10) & "                    当月残高  = 0 "
			strSQL = strSQL & Chr(10) & "                AND 処理年月 <= '" & pstrYearMonth & "' "
			strSQL = strSQL & Chr(10) & "                GROUP BY "
			strSQL = strSQL & Chr(10) & "                    顧客コード  , "
			strSQL = strSQL & Chr(10) & "                    顧客枝コード  "
			strSQL = strSQL & Chr(10) & "            ) UKT  "
			strSQL = strSQL & Chr(10) & "        WHERE "
			strSQL = strSQL & Chr(10) & "            KM.会員コード   = UKT.顧客コード "
			strSQL = strSQL & Chr(10) & "        AND KM.会員枝コード = UKT.顧客枝コード "
			strSQL = strSQL & Chr(10) & "        AND KM.利用区分     = '02' "
			strSQL = strSQL & Chr(10) & "    ) "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			' 戻り値を設定（正常終了）
			gfncUpdateTblPerfectAuto = False

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:6760f4c8-f377-42e4-871b-2f5b58d66afc
			'PROC_END:

			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:6760f4c8-f377-42e4-871b-2f5b58d66afc
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
PROC_FINALLY_END:
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'******************************************************************************
	' 関 数 名  : gfncGetCntBlankPerfectNum
	' スコープ  : Public
	' 処理内容  : パーフェクト番号空き件数 取得
	' 備    考  :
	' 返 り 値  : パーフェクト番号空き件数
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'
	' 変更履歴  :
	'   Version     日　付      氏　名        　　 修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/05/14  廣井　芳明      　 新規作成
	'
	'******************************************************************************
	Public Function gfncGetCntBlankPerfectNum() As Integer

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetCntBlankPerfectNum"
		Dim strSQL As String
		Dim lngRet As Integer
		Dim objDysTemp As OraDynaset
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			lngRet = 0

			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    COUNT(入金先口座番号) AS 空き件数 "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    パーフェクトテーブル "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    (入金先口座番号,履歴番号) IN "
			strSQL = strSQL & Chr(10) & "    ( "
			strSQL = strSQL & Chr(10) & "        SELECT "
			strSQL = strSQL & Chr(10) & "            入金先口座番号, "
			strSQL = strSQL & Chr(10) & "            MAX(履歴番号)   "
			strSQL = strSQL & Chr(10) & "        FROM "
			strSQL = strSQL & Chr(10) & "            パーフェクトテーブル "
			strSQL = strSQL & Chr(10) & "        WHERE "
			strSQL = strSQL & Chr(10) & "            (自動採番対象区分 IS NULL OR "
			strSQL = strSQL & Chr(10) & "             自動採番対象区分 <> 1    )  "
			strSQL = strSQL & Chr(10) & "        GROUP BY "
			strSQL = strSQL & Chr(10) & "            入金先口座番号 "
			strSQL = strSQL & Chr(10) & "        HAVING "
			strSQL = strSQL & Chr(10) & "            SUM(使用区分) = 0 "
			strSQL = strSQL & Chr(10) & "    ) "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				' 該当するデータが存在する場合
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .eof = False Then

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lngRet = gfncFieldCur(.Fields("空き件数").Value)

				End If

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objDysTemp = Nothing

			gfncGetCntBlankPerfectNum = lngRet

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
			'PROC_END:

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
PROC_FINALLY_END:
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'******************************************************************************
	' 関 数 名  : gfncRegisterTblNyuukinPGWork
	' スコープ  : Public
	' 処理内容  : 入金プログラムワーク 登録処理
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   --------------------+-----------------+-----+------------------------------
	'   pstrTableName        String            I     プログラムワーク名
	'   pstrMemberParentCode String            I     会員コード
	'   pstrMemberBranchCode String            I     会員枝コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncRegisterTblNyuukinPGWork(ByVal pstrTableName As String, Optional ByVal pstrMemberParentCode As String = "", Optional ByVal pstrMemberBranchCode As String = "", Optional ByVal pblnCommit As Boolean = True) As Boolean

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncRegisterTblNyuukinPGWork"
		Dim strSQL As String
		Dim lngStartTime As Integer
		Dim objDysTemp As OraDynaset
		Dim strLoginInfo As String
		Dim bln入金検索 As String
		Dim intFileNum As Integer
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			If gclsLoginInfo.EmployeeCode = "" Then
				strLoginInfo = "0000000"
			Else
				strLoginInfo = gclsLoginInfo.EmployeeCode
			End If

			If pstrTableName = "PG_WORK_USQ110" Then
				bln入金検索 = CStr(True)
			Else
				bln入金検索 = CStr(False)
			End If

			lngStartTime = timeGetTime()

			'//呼出し元が入金検索の場合

			If CBool(bln入金検索) = True Then
				'//請求修正テーブルの更新時刻が変わっていないか確認 2015/12/18
				strSQL = ""
				strSQL = strSQL & Chr(10) & " SELECT "
				strSQL = strSQL & Chr(10) & "   to_char(SEI.更新日付時刻,'yyyymmddhh24miss') 更新日付時刻 "
				strSQL = strSQL & Chr(10) & "   ,to_char(WK.出力元更新日付時刻,'yyyymmddhh24miss') 出力元更新日付時刻    "
				strSQL = strSQL & Chr(10) & "   ,SEI.件数       "
				strSQL = strSQL & Chr(10) & "   ,WK.出力元件数 "
				strSQL = strSQL & Chr(10) & "   ,WK.作成中フラグ   "
				strSQL = strSQL & Chr(10) & " FROM   "
				strSQL = strSQL & Chr(10) & "   ワーク作成状況テーブル WK "
				strSQL = strSQL & Chr(10) & "   ,(SELECT "
				strSQL = strSQL & Chr(10) & "       MAX(更新日付時刻) 更新日付時刻"
				strSQL = strSQL & Chr(10) & "       ,COUNT(1) 件数"
				strSQL = strSQL & Chr(10) & "     FROM 請求修正テーブル"
				strSQL = strSQL & Chr(10) & "     ) SEI"
				strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
				strSQL = strSQL & Chr(10) & " AND WK.ワークテーブル名 = '" & pstrTableName & "' "
				strSQL = strSQL & Chr(10) & " AND WK.更新従業員コード = '" & strLoginInfo & "' "

				'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

				With objDysTemp

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .eof = True Then
						'//該当データなし→ワーク作成状況テーブルに挿入

						strSQL = ""
						strSQL = strSQL & Chr(10) & "INSERT INTO ワーク作成状況テーブル "
						strSQL = strSQL & Chr(10) & " ("
						strSQL = strSQL & Chr(10) & "    ワークテーブル名 "
						strSQL = strSQL & Chr(10) & "    ,出力元更新日付時刻 "
						strSQL = strSQL & Chr(10) & "    ,出力元件数 "
						strSQL = strSQL & Chr(10) & "    ,更新日付時刻 "
						strSQL = strSQL & Chr(10) & "    ,更新従業員コード "
						strSQL = strSQL & Chr(10) & "    ,作成中フラグ "
						strSQL = strSQL & Chr(10) & "    ,備考 "
						strSQL = strSQL & Chr(10) & " ) VALUES ("
						strSQL = strSQL & Chr(10) & "'" & pstrTableName & "' "
						strSQL = strSQL & Chr(10) & "  , NULL"
						strSQL = strSQL & Chr(10) & "  , NULL"
						strSQL = strSQL & Chr(10) & "  , SYSDATE"
						strSQL = strSQL & Chr(10) & "  , '" & strLoginInfo & "' "
						strSQL = strSQL & Chr(10) & "  , 1"
						strSQL = strSQL & Chr(10) & "  , '従業員" & strLoginInfo & "で' || " & "to_CHAR(SYSDATE,'yy/mm/dd')" & " || 'に作成' "
						strSQL = strSQL & Chr(10) & " )"
						'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call gobjOraDatabase.ExecuteSQL(strSQL)


						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf .Fields("出力元更新日付時刻").Value = .Fields("更新日付時刻").Value And .Fields("出力元件数").Value = .Fields("件数").Value Then  '過去更新時刻 OR 過去件数に差異がない

						' 戻り値を設定（正常終了）
						gfncRegisterTblNyuukinPGWork = False
						'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
						'GoTo PROC_END
						GoTo PROC_FINALLY_END
						'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf .Fields("出力元件数").Value = "1" Then  ' 現在作成処理中

						' 戻り値を設定（正常終了）
						gfncRegisterTblNyuukinPGWork = False
						'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
						'GoTo PROC_END
						GoTo PROC_FINALLY_END
						'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed

					ElseIf 1 = 1 Then  ' 変更有

						'//該当データあり→作成中フラグ１にして、件数や更新時刻を保持する
						strSQL = ""
						strSQL = strSQL & Chr(10) & "UPDATE ワーク作成状況テーブル "
						strSQL = strSQL & Chr(10) & "SET 作成中フラグ = 1 "
						strSQL = strSQL & Chr(10) & "  , 更新従業員コード = '" & strLoginInfo & "' "
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						strSQL = strSQL & Chr(10) & "  , 出力元更新日付時刻 = to_date('" & .Fields("更新日付時刻").Value & "','yyyymmddhh24miss') "
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						strSQL = strSQL & Chr(10) & "  , 出力元件数 = " & .Fields("件数").Value
						strSQL = strSQL & Chr(10) & "  , 更新日付時刻 = SYSDATE "
						strSQL = strSQL & Chr(10) & "WHERE 1 = 1 "
						strSQL = strSQL & Chr(10) & "AND ワークテーブル名 = '" & pstrTableName & "' "
						strSQL = strSQL & Chr(10) & "AND 更新従業員コード = '" & strLoginInfo & "' "
						strSQL = strSQL & Chr(10) & "AND 作成中フラグ <> 1 "
						'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call gobjOraDatabase.ExecuteSQL(strSQL)

					End If
				End With

			End If

			' 戻り値を初期化（異常終了）
			gfncRegisterTblNyuukinPGWork = True

			'==========================================================================
			' 入金入力ワーク（修正分データ） 作成
			'==========================================================================
			strSQL = ""
			strSQL = strSQL & Chr(10) & "DECLARE "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "    CURSOR curSyuusei IS "
			strSQL = strSQL & Chr(10) & "    SELECT "
			strSQL = strSQL & Chr(10) & "        顧客コード   "
			strSQL = strSQL & Chr(10) & "       ,顧客枝コード "
			strSQL = strSQL & Chr(10) & "       ,修正区分     "
			strSQL = strSQL & Chr(10) & "       ,発生日       "
			strSQL = strSQL & Chr(10) & "       ,金額１       "
			strSQL = strSQL & Chr(10) & "    FROM "
			strSQL = strSQL & Chr(10) & "        請求修正テーブル "

			If pstrMemberParentCode <> "" Then

				strSQL = strSQL & Chr(10) & "    WHERE "
				strSQL = strSQL & Chr(10) & "        顧客コード   = '" & pstrMemberParentCode & "' "

				If pstrMemberBranchCode <> "" Then

					strSQL = strSQL & Chr(10) & "    AND 顧客枝コード = '" & pstrMemberBranchCode & "' "

				End If

			End If

			strSQL = strSQL & Chr(10) & "    ORDER BY "
			strSQL = strSQL & Chr(10) & "        発生日; "
			strSQL = strSQL & Chr(10)

			strSQL = strSQL & Chr(10) & "    varShimebi VARCHAR2(8); " ' 請求締日
			strSQL = strSQL & Chr(10) & "    numUriage  NUMBER  (9); " ' 売上額
			strSQL = strSQL & Chr(10) & "    numNyuukin NUMBER  (9); " ' 入金額
			strSQL = strSQL & Chr(10) & "    numRecCnt  NUMBER  (4); " ' 件数
			strSQL = strSQL & Chr(10)

			strSQL = strSQL & Chr(10) & "BEGIN "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     -- プログラムワークを一旦削除 "
			strSQL = strSQL & Chr(10) & "     DELETE " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "     WHERE "
			strSQL = strSQL & Chr(10) & "         更新従業員コード = '" & strLoginInfo & "'; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     numUriage := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     numNyuukin := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     FOR recSyuusei IN curSyuusei LOOP "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         SELECT "
			strSQL = strSQL & Chr(10) & "             MIN(請求締日) "
			strSQL = strSQL & Chr(10) & "         INTO "
			strSQL = strSQL & Chr(10) & "             varShimebi "
			strSQL = strSQL & Chr(10) & "         FROM "
			strSQL = strSQL & Chr(10) & "             " & MC_TBL_請求テーブル & " "
			strSQL = strSQL & Chr(10) & "         WHERE "
			strSQL = strSQL & Chr(10) & "             顧客コード   = recSyuusei.顧客コード "
			strSQL = strSQL & Chr(10) & "         AND 顧客枝コード = recSyuusei.顧客枝コード "
			strSQL = strSQL & Chr(10) & "         AND 請求締日    >= recSyuusei.発生日; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         SELECT "
			strSQL = strSQL & Chr(10) & "             COUNT(*) "
			strSQL = strSQL & Chr(10) & "         INTO "
			strSQL = strSQL & Chr(10) & "             numRecCnt "
			strSQL = strSQL & Chr(10) & "         FROM "
			strSQL = strSQL & Chr(10) & "             " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "         WHERE "
			strSQL = strSQL & Chr(10) & "             顧客コード       = recSyuusei.顧客コード "
			strSQL = strSQL & Chr(10) & "         AND 顧客枝コード     = recSyuusei.顧客枝コード "
			strSQL = strSQL & Chr(10) & "         AND 請求締日         = varShimebi "
			strSQL = strSQL & Chr(10) & "         AND 更新従業員コード = '" & strLoginInfo & "' "
			strSQL = strSQL & Chr(10) & "             ; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         IF recSyuusei.修正区分 = 0 THEN "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numUriage := recSyuusei.金額１; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numNyuukin := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         ELSE "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numUriage := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numNyuukin := recSyuusei.金額１; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         END IF; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         IF numRecCnt = 0 THEN  "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "            INSERT INTO " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "                ( "
			strSQL = strSQL & Chr(10) & "                    顧客コード       "
			strSQL = strSQL & Chr(10) & "                   ,顧客枝コード     "
			strSQL = strSQL & Chr(10) & "                   ,請求締日         "
			strSQL = strSQL & Chr(10) & "                   ,売上修正額       "
			strSQL = strSQL & Chr(10) & "                   ,入金修正額       "
			strSQL = strSQL & Chr(10) & "                   ,更新従業員コード "
			strSQL = strSQL & Chr(10) & "                   ,更新日付時刻     "
			strSQL = strSQL & Chr(10) & "                ) "
			strSQL = strSQL & Chr(10) & "            VALUES "
			strSQL = strSQL & Chr(10) & "                ( "
			strSQL = strSQL & Chr(10) & "                    recSyuusei.顧客コード   "
			strSQL = strSQL & Chr(10) & "                   ,recSyuusei.顧客枝コード "
			strSQL = strSQL & Chr(10) & "                   ,varShimebi              "
			strSQL = strSQL & Chr(10) & "                   ,numUriage               "
			strSQL = strSQL & Chr(10) & "                   ,numNyuukin              "
			strSQL = strSQL & Chr(10) & "                   ,'" & strLoginInfo & "'  "
			strSQL = strSQL & Chr(10) & "                   ,SYSDATE                 "
			strSQL = strSQL & Chr(10) & "                ); "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         ELSE "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             UPDATE " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "             SET 売上修正額       = 売上修正額 + numUriage "
			strSQL = strSQL & Chr(10) & "                ,入金修正額       = 入金修正額 + numNyuukin "
			strSQL = strSQL & Chr(10) & "             WHERE "
			strSQL = strSQL & Chr(10) & "                 顧客コード       = recSyuusei.顧客コード "
			strSQL = strSQL & Chr(10) & "             AND 顧客枝コード     = recSyuusei.顧客枝コード "
			strSQL = strSQL & Chr(10) & "             AND 請求締日         = varShimebi "
			strSQL = strSQL & Chr(10) & "             AND 更新従業員コード = '" & strLoginInfo & "' "
			strSQL = strSQL & Chr(10) & "                 ; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         END IF; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "    END LOOP; "
			strSQL = strSQL & Chr(10)

			If CBool(bln入金検索) = True Then
				'//フラグを元に戻す
				strSQL = strSQL & Chr(10) & "UPDATE ワーク作成状況テーブル "
				strSQL = strSQL & Chr(10) & "SET 作成中フラグ = 0 "
				strSQL = strSQL & Chr(10) & "WHERE ワークテーブル名 = '" & pstrTableName & "' "
				strSQL = strSQL & Chr(10) & "  AND 更新従業員コード = '" & strLoginInfo & "'; "

			End If

			'//コミットするかどうかの選択肢を追加。USB01（請求締処理）0のときは、コミットしない '//2018/08/15
			If pblnCommit = True Then
				strSQL = strSQL & Chr(10) & "    COMMIT; "
			End If
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "END; "

			' デバッグモードが１（デバッグ）の場合
#If DebugMode = 1 Then
		'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression DebugMode = 1 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
		
		
		intFileNum = FreeFile
		
		Open "C:\UsCommonFunction.SQL" For Output As #intFileNum
		Print #intFileNum, "--◎-----------------------------------------------------------------------◎--"
		Print #intFileNum, "--◎ gfncRegisterTblNyuukinPGWork                                          ◎--"
		Print #intFileNum, "--◎-----------------------------------------------------------------------◎--"
		Print #intFileNum, strSQL
		Close #intFileNum
		
#End If

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			Debug.Print(C_NAME_FUNCTION & ":" & (timeGetTime - lngStartTime) / 1000)

			' 戻り値を設定（正常終了）
			gfncRegisterTblNyuukinPGWork = False

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
			'PROC_END:

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
PROC_FINALLY_END:
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'******************************************************************************
	' 関 数 名  : gfncUpdateTblSeikyuu_ProcessingFee
	' スコープ  : Public
	' 処理内容  : 請求テーブル 更新(請求済請求事務手数料)
	' 備    考  :
	' 返 り 値  : True （異常終了）
	'             False（正常終了）
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   --------------------+-----------------+-----+------------------------------
	'   pstrSeikyuuShimebi   String            I     請求締日
	'   pstrMemberParentCode String            I     会員コード
	'   pstrMemberBranchCode String            I     会員枝コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncUpdateTblSeikyuu_ProcessingFee(ByVal pstrSeikyuuShimebi As String, ByVal pstrMemberParentCode As String, ByVal pstrMemberBranchCode As String) As Boolean

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncUpdateTblSeikyuu_ProcessingFee"
		Dim curProcessingFee As Decimal ' 請求済請求事務手数料
		Dim objDysTemp As OraDynaset
		Dim strSQL As String
		Dim lngStartTime As Integer
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			lngStartTime = timeGetTime()

			' 戻り値を初期化（異常終了）
			gfncUpdateTblSeikyuu_ProcessingFee = True

			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    顧客コード   "
			strSQL = strSQL & Chr(10) & "   ,顧客枝コード "
			strSQL = strSQL & Chr(10) & "   ,請求締日     "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    " & MC_TBL_請求テーブル & " "

			If (Trim(pstrSeikyuuShimebi) <> "") Then

				strSQL = strSQL & Chr(10) & "WHERE "
				strSQL = strSQL & Chr(10) & "    請求締日     = '" & pstrSeikyuuShimebi & "' "

				If (Trim(pstrMemberParentCode) <> "") Then

					strSQL = strSQL & Chr(10) & "AND 顧客コード   = '" & pstrMemberParentCode & "' "

					If (Trim(pstrMemberBranchCode) <> "") Then

						strSQL = strSQL & Chr(10) & "AND 顧客枝コード = '" & pstrMemberBranchCode & "' "

					End If

				End If

			End If

			strSQL = strSQL & Chr(10) & "ORDER BY "
			strSQL = strSQL & Chr(10) & "    顧客コード   "
			strSQL = strSQL & Chr(10) & "   ,顧客枝コード "
			strSQL = strSQL & Chr(10) & "   ,請求締日     "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Do Until .eof = True

					'------------------------------------------------------------------
					' 請求済事務手数料 計算
					'------------------------------------------------------------------
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(顧客枝コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(顧客コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					curProcessingFee = mfncCalProcessingFee(gfncFieldVal(.Fields("請求締日").Value), gfncFieldVal(.Fields("顧客コード").Value), gfncFieldVal(.Fields("顧客枝コード").Value))

					'------------------------------------------------------------------
					' 請求済事務手数料 更新
					'------------------------------------------------------------------
					strSQL = ""
					strSQL = strSQL & Chr(10) & "UPDATE " & MC_TBL_請求テーブル & " "
					strSQL = strSQL & Chr(10) & "SET 請求済請求事務手数料 = " & curProcessingFee & " "
					strSQL = strSQL & Chr(10) & "WHERE "
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(顧客コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSQL = strSQL & Chr(10) & "    顧客コード           = '" & gfncFieldVal(.Fields("顧客コード").Value) & "' "
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(顧客枝コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSQL = strSQL & Chr(10) & "AND 顧客枝コード         = '" & gfncFieldVal(.Fields("顧客枝コード").Value) & "' "
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(請求締日).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSQL = strSQL & Chr(10) & "AND 請求締日             = '" & gfncFieldVal(.Fields("請求締日").Value) & "' "

					'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call gobjOraDatabase.ExecuteSQL(strSQL)

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call .MoveNext()

				Loop

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			Debug.Print(C_NAME_FUNCTION & ":" & (timeGetTime - lngStartTime) / 1000)

			' 戻り値を設定（正常終了）
			gfncUpdateTblSeikyuu_ProcessingFee = False

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
			'PROC_END:

			'Call gsubClearObject(objDysTemp)

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'******************************************************************************
	' 関 数 名  : mfncCalProcessingFee
	' スコープ  : Private
	' 処理内容  : 請求済事務手数料 計算
	' 備    考  :
	' 返 り 値  : 請求済事務手数料
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   --------------------+-----------------+-----+------------------------------
	'   pstrSeikyuuShimebi   String            I     請求締日
	'   pstrMemberParentCode String            I     会員コード
	'   pstrMemberBranchCode String            I     会員枝コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  廣井  芳明         新規作成
	'   02.33.00    2010/03/24  廣井  芳明         前回の締日請求データが存在しない場合に,
	'                                              請求済請求事務手数料が取得できなくなる不具合に対応。
	'
	'******************************************************************************
	Private Function mfncCalProcessingFee(ByVal pstrSeikyuuShimebi As String, ByVal pstrMemberParentCode As String, ByVal pstrMemberBranchCode As String) As Decimal

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "mfncCalProcessingFee"
		Dim curRet As Decimal
		Dim strStartDate As String ' 開始日付
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			' 戻り値を初期化
			curRet = 0

			'--------------------------------------------------------------------------
			' 開始日付 取得
			'--------------------------------------------------------------------------
			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    TO_CHAR( "
			strSQL = strSQL & Chr(10) & "        TO_DATE( "
			strSQL = strSQL & Chr(10) & "            MAX(請求締日) "
			strSQL = strSQL & Chr(10) & "           ,'YYYYMMDD'    "
			strSQL = strSQL & Chr(10) & "        ) + 1 "
			strSQL = strSQL & Chr(10) & "       ,'YYYYMMDD' "
			strSQL = strSQL & Chr(10) & "    ) AS 開始日 "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    " & MC_TBL_請求テーブル & " "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    顧客コード   = '" & pstrMemberParentCode & "' "
			strSQL = strSQL & Chr(10) & "AND 顧客枝コード = '" & pstrMemberBranchCode & "' "
			strSQL = strSQL & Chr(10) & "AND 請求締日     < '" & pstrSeikyuuShimebi & "' "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				' 該当するデータが存在する場合
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .eof = False Then

                    ' 開始日がブランク以外の場合
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(開始日)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gfncFieldVal(.Fields("開始日").Value) <> "" Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strStartDate = gfncFieldVal(.Fields("開始日").Value)

                        ' 開始日がブランクの場合
                    Else

                        strStartDate = "00000000"

					End If

				End If

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objDysTemp = Nothing

			'--------------------------------------------------------------------------
			' 請求済 事務手数料 算出
			'--------------------------------------------------------------------------
			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
			strSQL = strSQL & Chr(10) & "    請求番号 "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    随時明細テーブル "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    顧客コード   = '" & pstrMemberParentCode & "' "
			strSQL = strSQL & Chr(10) & "AND 顧客枝コード = '" & pstrMemberBranchCode & "' "
			strSQL = strSQL & Chr(10) & "AND 営業日      >= '" & strStartDate & "' "
			strSQL = strSQL & Chr(10) & "AND 営業日      <= '" & pstrSeikyuuShimebi & "' "
			strSQL = strSQL & Chr(10) & "AND 請求番号    IS NOT NULL "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Do Until .eof = True

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					curRet = curRet + mfncGetProcessingFee(pstrSeikyuuShimebi, strStartDate, gfncFieldVal(.Fields("請求番号").Value))

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call .MoveNext()

				Loop
			End With
			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
			'PROC_END:

			'End With

			'Call gsubClearObject(objDysTemp)

			'mfncCalProcessingFee = curRet

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a2076f46-8f74-4813-91c9-5dbb043ebe18

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try

		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
PROC_FINALLY_END:

		Call gsubClearObject(objDysTemp)
		mfncCalProcessingFee = curRet
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

	End Function
	'******************************************************************************
	' 関 数 名  : mfncGetProcessingFee
	' スコープ  : Private
	' 処理内容  : 請求済事務手数料 取得
	' 備    考  :
	' 返 り 値  : 請求済事務手数料
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   --------------------+-----------------+-----+------------------------------
	'   pstrSeikyuuShimebi   String            I     請求締日
	'   pstrStartDate        String            I     開始日付
	'   pstrBillNum          String            I     請求番号
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  廣井  芳明         新規作成
	'
	'******************************************************************************
	Private Function mfncGetProcessingFee(ByVal pstrSeikyuuShimebi As String, ByVal pstrStartDate As String, ByVal pstrBillNum As String) As Decimal

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "mfncGetProcessingFee"
		Dim curRet As Decimal
		Dim astrWorkDate(GC_IDX_END) As String ' 営業日（自～至）
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'UPGRADE_WARNING: Lower bound of array astrWorkDate was changed from GC_IDX_STA to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			' 戻り値を初期化
			curRet = 0

			'--------------------------------------------------------------------------
			' 営業日（自～至）取得
			'--------------------------------------------------------------------------
			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    MIN(営業日)   AS WorkDateSta "
			strSQL = strSQL & Chr(10) & "   ,MAX(営業日)   AS WorkDateEnd "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    随時請求書テーブル"
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    請求番号 = " & pstrBillNum & " "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				astrWorkDate(GC_IDX_STA) = gfncFieldVal(.Fields("WorkDateSta").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				astrWorkDate(GC_IDX_END) = gfncFieldVal(.Fields("WorkDateEnd").Value)

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objDysTemp = Nothing

			'--------------------------------------------------------------------------
			' 請求済事務手数料 取得
			'--------------------------------------------------------------------------
			' 請求締日 ≧ 営業日（至）の場合
			If (pstrSeikyuuShimebi >= astrWorkDate(GC_IDX_END)) Then

				'----------------------------------------------------------------------
				' 対象随時明細が, すべて１締日請求に含まれている場合
				'----------------------------------------------------------------------
				If (astrWorkDate(GC_IDX_STA) >= pstrStartDate) Then

					strSQL = ""
					strSQL = strSQL & Chr(10) & "SELECT "
					strSQL = strSQL & Chr(10) & "    ZST.請求事務手数料                       "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料率                         "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料                           "
					strSQL = strSQL & Chr(10) & "   ,TRUNC( "
					strSQL = strSQL & Chr(10) & "        SUM( "
					strSQL = strSQL & Chr(10) & "            ZSST.乗務員金額     + "
					strSQL = strSQL & Chr(10) & "            ZSST.立替金額       + "
					strSQL = strSQL & Chr(10) & "            ZSST.英会話ガイド料   "
					strSQL = strSQL & Chr(10) & "        ) * "
					strSQL = strSQL & Chr(10) & "        ZST.事務手数料率 / "
					strSQL = strSQL & Chr(10) & "        100 "
					strSQL = strSQL & Chr(10) & "    )                  AS 部分請求事務手数料 "
					strSQL = strSQL & Chr(10) & "FROM "
					strSQL = strSQL & Chr(10) & "    随時請求テーブル   ZST  "
					strSQL = strSQL & Chr(10) & "   ,随時請求書テーブル ZSST "
					strSQL = strSQL & Chr(10) & "WHERE "
					strSQL = strSQL & Chr(10) & "    ZST.請求番号  = ZSST.請求番号 "
					strSQL = strSQL & Chr(10) & "AND ZST.請求番号  = " & pstrBillNum & " "
					strSQL = strSQL & Chr(10) & "AND ZSST.営業日  >= '" & pstrStartDate & "' "
					strSQL = strSQL & Chr(10) & "GROUP BY "
					strSQL = strSQL & Chr(10) & "    ZST.請求事務手数料 "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料率   "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料     "

					'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

					With objDysTemp

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						curRet = gfncFieldCur(.Fields("請求事務手数料").Value)

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call .Close()

					End With

					'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					objDysTemp = Nothing

					'----------------------------------------------------------------------
					' 指定締日請求以前の随時明細が存在する場合
					'----------------------------------------------------------------------
				Else

					strSQL = ""
					strSQL = strSQL & Chr(10) & " SELECT"
					strSQL = strSQL & Chr(10) & "    ZST.請求事務手数料                       "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料率                         "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料                           "
					strSQL = strSQL & Chr(10) & "   ,TRUNC( "
					strSQL = strSQL & Chr(10) & "        SUM( "
					strSQL = strSQL & Chr(10) & "            ZSST.乗務員金額     + "
					strSQL = strSQL & Chr(10) & "            ZSST.立替金額       + "
					strSQL = strSQL & Chr(10) & "            ZSST.英会話ガイド料   "
					strSQL = strSQL & Chr(10) & "        ) * "
					strSQL = strSQL & Chr(10) & "        ZST.事務手数料率 / "
					strSQL = strSQL & Chr(10) & "        100 "
					strSQL = strSQL & Chr(10) & "    )                  AS 部分請求事務手数料 "
					strSQL = strSQL & Chr(10) & "FROM "
					strSQL = strSQL & Chr(10) & "    随時請求テーブル   ZST  "
					strSQL = strSQL & Chr(10) & "   ,随時請求書テーブル ZSST "
					strSQL = strSQL & Chr(10) & "WHERE "
					strSQL = strSQL & Chr(10) & "    ZST.請求番号  = ZSST.請求番号 "
					strSQL = strSQL & Chr(10) & "AND ZST.請求番号  = " & pstrBillNum & " "
					strSQL = strSQL & Chr(10) & "AND ZSST.営業日  <  '" & pstrStartDate & "' "
					strSQL = strSQL & Chr(10) & "GROUP BY "
					strSQL = strSQL & Chr(10) & "    ZST.請求事務手数料 "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料率   "
					strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料     "

					'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

					With objDysTemp

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If (gfncFieldCur(.Fields("事務手数料率").Value) <> 0) Then

							'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							curRet = gfncFieldCur(.Fields("請求事務手数料").Value) - gfncFieldCur(.Fields("部分請求事務手数料").Value)

						End If

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call .Close()

					End With

					'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					objDysTemp = Nothing

				End If

				' 請求締日 ＜ 営業日（至）の場合
			Else

				strSQL = ""
				strSQL = strSQL & Chr(10) & "SELECT "
				strSQL = strSQL & Chr(10) & "    ZST.請求事務手数料                       "
				strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料率                         "
				strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料                           "
				strSQL = strSQL & Chr(10) & "   ,TRUNC( "
				strSQL = strSQL & Chr(10) & "        SUM( "
				strSQL = strSQL & Chr(10) & "            ZSST.乗務員金額     + "
				strSQL = strSQL & Chr(10) & "            ZSST.立替金額       + "
				strSQL = strSQL & Chr(10) & "            ZSST.英会話ガイド料   "
				strSQL = strSQL & Chr(10) & "        ) * "
				strSQL = strSQL & Chr(10) & "        ZST.事務手数料率 / "
				strSQL = strSQL & Chr(10) & "        100 "
				strSQL = strSQL & Chr(10) & "    )                  AS 部分請求事務手数料 "
				strSQL = strSQL & Chr(10) & "FROM "
				strSQL = strSQL & Chr(10) & "    随時請求テーブル   ZST  "
				strSQL = strSQL & Chr(10) & "   ,随時請求書テーブル ZSST "
				strSQL = strSQL & Chr(10) & "WHERE "
				strSQL = strSQL & Chr(10) & "    ZST.請求番号  = ZSST.請求番号 "
				strSQL = strSQL & Chr(10) & "AND ZST.請求番号  = " & pstrBillNum & " "
				strSQL = strSQL & Chr(10) & "AND ZSST.営業日  >= '" & pstrStartDate & "' "
				strSQL = strSQL & Chr(10) & "AND ZSST.営業日  <= '" & pstrSeikyuuShimebi & "' "
				strSQL = strSQL & Chr(10) & "GROUP BY "
				strSQL = strSQL & Chr(10) & "    ZST.請求事務手数料 "
				strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料率   "
				strSQL = strSQL & Chr(10) & "   ,ZST.事務手数料     "

				'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

				With objDysTemp

					' 事務手数料が０円の場合
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If (gfncFieldCur(.Fields("事務手数料率").Value) <> 0) Then

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						curRet = gfncFieldCur(.Fields("部分請求事務手数料").Value)

						' 事務手数料が０円以外の場合
					Else

						' 営業日（自）≧ 開始日付の場合
						If (astrWorkDate(GC_IDX_STA) >= pstrStartDate) Then

							'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							curRet = gfncFieldCur(.Fields("請求事務手数料").Value)

						End If

					End If

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call .Close()

				End With

				'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				objDysTemp = Nothing

			End If

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
			'PROC_END:

			'Call gsubClearObject(objDysTemp)

			' 戻り値を設定
			'mfncGetProcessingFee = curRet

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		mfncGetProcessingFee = curRet
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'******************************************************************************
	' 関 数 名  : gfncGetEndMonthDate
	' スコープ  : Public
	' 処理内容  : 月末日付 取得
	' 備    考  :
	' 返 り 値  : 月末日付
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrDate            String            I     日付
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/09/24  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetEndMonthDate(ByVal pstrDate As String) As String

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetEndMonthDate"
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			gfncGetEndMonthDate = CStr(System.Date.FromOADate(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(VB6.Format(Left(pstrDate, 6), "0000\/00\/") & "01")).ToOADate - 1))

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
			'PROC_END:

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
PROC_FINALLY_END:
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function
	'******************************************************************************
	' 関 数 名  : gfncGetBankKbn
	' スコープ  : Public
	' 処理内容  : 銀行区分 取得
	' 備    考  :
	' 返 り 値  : 銀行区分
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     銀行コード
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00.00    2008/09/24  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetBankKbn(ByVal pstrBankCode As String) As Short

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gfncGetBankKbn"
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			gfncGetBankKbn = GC_BANK_KBN_MK_NORMAL

			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    銀行区分 "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    銀行マスタ "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    銀行コード = '" & pstrBankCode & "' "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				' 該当するデータが存在する場合
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .eof = False Then

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					gfncGetBankKbn = CShort(gfncFieldCur(.Fields("銀行区分").Value))

				End If

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
			'PROC_END:

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			'objDysTemp = Nothing

			'Exit Function

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:702b7f02-6377-45af-9bd9-96b14c668846
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:702b7f02-6377-45af-9bd9-96b14c668846

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:702b7f02-6377-45af-9bd9-96b14c668846
PROC_FINALLY_END:
		objDysTemp = Nothing
		Exit Function
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:702b7f02-6377-45af-9bd9-96b14c668846
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Function

	Public Function gfncGetStrJifuriAccount(ByVal pstrGinkoCode As String, ByVal pstrShitenCode As String, ByVal pstrKozaKind As String, ByVal pstrKozaNum As String, ByVal pstrKozaName As String) As String

		'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
		'Dim objDysTemp As Object
		Dim objDysTemp As OraDynaset
		'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
		Dim strBankName As String
		Dim strBranchName As String
		Dim strSQL As String
		Dim strRet As String

		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    GM.銀行名漢字 "
		strSQL = strSQL & Chr(10) & "  , SM.支店名漢字 "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    銀行マスタ GM "
		strSQL = strSQL & Chr(10) & "  , 支店マスタ SM "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    GM.銀行コード = SM.銀行コード(+) "
		strSQL = strSQL & Chr(10) & "AND GM.銀行コード = '" & pstrGinkoCode & "' "
		strSQL = strSQL & Chr(10) & "AND SM.支店コード = '" & pstrShitenCode & "' "

		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

		With objDysTemp

			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strBankName = gfncFieldVal(.Fields("銀行名漢字").Value)

			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strBranchName = gfncFieldVal(.Fields("支店名漢字").Value)

			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()

		End With

		'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		objDysTemp = Nothing

		Select Case Right(strBankName, 2)
			Case "金庫", "信託", "信金", "組合", "農協"

				' 処理なし

			Case Else

				strBankName = strBankName & "銀行"

		End Select

		If strBranchName = "本店" Then

			' 処理なし

		ElseIf Right(strBranchName, 3) = "出張所" Then

			' 処理なし

		ElseIf Right(strBranchName, 3) = "営業部" Then

			' 処理なし

		Else

			strBranchName = strBranchName & "支店"

		End If

		strRet = ""
		strRet = strRet & strBankName & " "
		strRet = strRet & strBranchName & " "

		If pstrKozaKind <> "" Then

			If CDbl(pstrKozaKind) = 1 Then

				strRet = strRet & "普通 "

			Else

				strRet = strRet & "当座 "

			End If

		End If

		strRet = strRet & pstrKozaNum & "  "
		strRet = strRet & pstrKozaName

		'=Debug.Print strRet

		gfncGetStrJifuriAccount = strRet

	End Function
	'******************************************************************************
	' 関 数 名  : gfncGetGinkoKoza
	' スコープ  : Public
	' 処理内容  : 銀行口座設定処理
	' 備    考  :
	' 返 り 値  : なし
	' 引 き 数  :
	'   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
	'   -------------------+-----------------+-----+-------------------------------
	'   pblnFlgJifuri       Boolean           I     自動振替フラグ
	'   pstrGinkoName       String            I     銀行名
	'   pstrSitenName       String            I     支店名
	'   pstrYokinKind       String            I     預金種目
	'   pstrKozaNumber      String            I     口座番号
	'   pstrKozaMeigi       String            I     口座名義
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   02.17.00    2009/01/08  廣井  芳明         新規作成
	'
	'******************************************************************************
	Public Function gfncGetGinkoKoza(ByVal pblnFlgJifuri As Boolean, ByVal pstrGinkoName As String, ByVal pstrSitenName As String, ByVal pstrYokinKind As String, ByVal pstrKozaNumber As String, ByVal pstrKozaMeigi As String) As String

		Const C_HIDE_CHAR As String = "*"
		Const C_HIDE_CHAR_LEN As Short = 3

		Dim strRet As String

		strRet = ""
		strRet = strRet & gfncEditNameBank(pstrGinkoName)
		strRet = strRet & "  "
		strRet = strRet & gfncEditNameBankBranch(pstrSitenName)
		strRet = strRet & "  "

		If pstrYokinKind <> "" Then

			If pstrYokinKind = "1" Then

				strRet = strRet & "普通"

			Else

				strRet = strRet & "当座"

			End If

			strRet = strRet & " "

		End If

		' 自動振替フラグがFalse(自振以外)の場合
		If pblnFlgJifuri = False Then

			strRet = strRet & pstrKozaNumber
			strRet = strRet & "  "
			strRet = strRet & pstrKozaMeigi

			' 自動振替フラグがTrue(自振)の場合
			' (会員の口座番号の為, アスタリスクで口座番号を伏せる)
		Else

			' 口座番号が取得できている場合
			If pstrKozaNumber <> "" Then

				' 口座番号が３桁以下の場合
				If Len(pstrKozaNumber) <= C_HIDE_CHAR_LEN Then

					strRet = strRet & "00000**"
					strRet = strRet & "  "
					strRet = strRet & pstrKozaMeigi

					' 口座番号が４桁以上の場合
				Else

					strRet = strRet & Mid(pstrKozaNumber, 1, Len(pstrKozaNumber) - C_HIDE_CHAR_LEN)
					strRet = strRet & New String(C_HIDE_CHAR, C_HIDE_CHAR_LEN)
					strRet = strRet & "  "
					strRet = strRet & pstrKozaMeigi

				End If

				' 口座番号が取得できていない場合
			Else

				strRet = strRet & "  "
				strRet = strRet & pstrKozaMeigi

			End If

		End If

		gfncGetGinkoKoza = strRet

	End Function

	'******************************************************************************
	' 関 数 名  : gsubInsTicketMeisaiRireki
	' スコープ  : Public
	' 処理内容  : チケット明細履歴の作成
	' 備    考  : bln修正前フラグ = Trueで、削除前情報を挿入した後は、
	'             更新処理後に必ずbln修正前フラグ = Falseで削除後データも作成すること
	'             使用場所…BeginTranの直後に変更前を、CommitTranの直後に変更後を実行する
	' 返 り 値  : なし
	' 引 き 数  :
	'
	'// bln修正前フラグ    : true:修正前 False:修正後
	'// str処理日付時刻    ：作成キー
	'// str処理プログラム名：作成キー
	'// str処理従業員コード：作成キー
	'// str営業日          ：データ取得キー
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00.00    2016/03/30  ＫＳＲ             新規作成
	'
	'******************************************************************************
	Public Sub gsubInsTicketMeisaiRireki(ByVal bln修正前フラグ As Boolean, ByVal str処理日付時刻 As String, ByVal str処理プログラム名 As String, ByVal str処理従業員コード As String, ByVal str営業日 As String)

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gsubInsTicketMeisaiRireki"
		Dim objDysTemp As OraDynaset
		Dim strSQL As String
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			strSQL = ""
			strSQL = strSQL & Chr(10) & " INSERT INTO チケット明細履歴テーブル "
			strSQL = strSQL & Chr(10) & "   ( "
			strSQL = strSQL & Chr(10) & "     処理区分           "
			strSQL = strSQL & Chr(10) & "    ,処理日付時刻       "
			strSQL = strSQL & Chr(10) & "    ,処理プログラム     "
			strSQL = strSQL & Chr(10) & "    ,処理従業員コード   "
			strSQL = strSQL & Chr(10) & "    ,営業日             "
			strSQL = strSQL & Chr(10) & "    ,行番号             "
			strSQL = strSQL & Chr(10) & "    ,発生日             "
			strSQL = strSQL & Chr(10) & "    ,所属コード         "
			strSQL = strSQL & Chr(10) & "    ,シフト区分         "
			strSQL = strSQL & Chr(10) & "    ,無線番号           "
			strSQL = strSQL & Chr(10) & "    ,枚数               "
			strSQL = strSQL & Chr(10) & "    ,枝番               "
			strSQL = strSQL & Chr(10) & "    ,車輌区分           "
			strSQL = strSQL & Chr(10) & "    ,従業員コード       "
			strSQL = strSQL & Chr(10) & "    ,未収区分           "
			strSQL = strSQL & Chr(10) & "    ,未収コード         "
			strSQL = strSQL & Chr(10) & "    ,未収枝コード       "
			strSQL = strSQL & Chr(10) & "    ,カード番号         "
			strSQL = strSQL & Chr(10) & "    ,未収金額           "
			strSQL = strSQL & Chr(10) & "    ,乗務員金額         "
			strSQL = strSQL & Chr(10) & "    ,外商企画料         "
			strSQL = strSQL & Chr(10) & "    ,英会話ガイド料     "
			strSQL = strSQL & Chr(10) & "    ,立替金額           "
			strSQL = strSQL & Chr(10) & "    ,手数料             "
			strSQL = strSQL & Chr(10) & "    ,手数料税抜         "
			strSQL = strSQL & Chr(10) & "    ,身障者現収額       "
			strSQL = strSQL & Chr(10) & "    ,更新従業員コード   "
			strSQL = strSQL & Chr(10) & "    ,更新日付時刻       "
			strSQL = strSQL & Chr(10) & "    ,集計済みフラグ     "
			strSQL = strSQL & Chr(10) & "    ,更新端末ＩＰ       "
			strSQL = strSQL & Chr(10) & "    ,会社コード         "
			strSQL = strSQL & Chr(10) & "    ,整理番号           "
			strSQL = strSQL & Chr(10) & "    ,高速代             "
			strSQL = strSQL & Chr(10) & "    ,備考               "
			strSQL = strSQL & Chr(10) & "   ) "
			strSQL = strSQL & Chr(10) & "   SELECT "
			If bln修正前フラグ = True Then
				strSQL = strSQL & Chr(10) & " 1 AS 処理区分 "
			Else
				strSQL = strSQL & Chr(10) & " 0 AS 処理区分 "
			End If
			strSQL = strSQL & Chr(10) & "    , TO_DATE('" & str処理日付時刻 & "','YYYY/MM/DD HH24:MI:SS') AS 処理日付時刻 "
			strSQL = strSQL & Chr(10) & "    , '" & str処理プログラム名 & "' AS 処理プログラム "
			strSQL = strSQL & Chr(10) & "    , '" & str処理従業員コード & "' AS 処理従業員コード "
			strSQL = strSQL & Chr(10) & "    ,営業日             "
			strSQL = strSQL & Chr(10) & "    ,行番号             "
			strSQL = strSQL & Chr(10) & "    ,発生日             "
			strSQL = strSQL & Chr(10) & "    ,所属コード         "
			strSQL = strSQL & Chr(10) & "    ,シフト区分         "
			strSQL = strSQL & Chr(10) & "    ,無線番号           "
			strSQL = strSQL & Chr(10) & "    ,枚数               "
			strSQL = strSQL & Chr(10) & "    ,枝番               "
			strSQL = strSQL & Chr(10) & "    ,車輌区分           "
			strSQL = strSQL & Chr(10) & "    ,従業員コード       "
			strSQL = strSQL & Chr(10) & "    ,未収区分           "
			strSQL = strSQL & Chr(10) & "    ,未収コード         "
			strSQL = strSQL & Chr(10) & "    ,未収枝コード       "
			strSQL = strSQL & Chr(10) & "    ,カード番号         "
			strSQL = strSQL & Chr(10) & "    ,未収金額           "
			strSQL = strSQL & Chr(10) & "    ,乗務員金額         "
			strSQL = strSQL & Chr(10) & "    ,外商企画料         "
			strSQL = strSQL & Chr(10) & "    ,英会話ガイド料     "
			strSQL = strSQL & Chr(10) & "    ,立替金額           "
			strSQL = strSQL & Chr(10) & "    ,手数料             "
			strSQL = strSQL & Chr(10) & "    ,手数料税抜         "
			strSQL = strSQL & Chr(10) & "    ,身障者現収額       "
			strSQL = strSQL & Chr(10) & "    ,更新従業員コード   "
			strSQL = strSQL & Chr(10) & "    ,更新日付時刻       "
			strSQL = strSQL & Chr(10) & "    ,集計済みフラグ     "
			strSQL = strSQL & Chr(10) & "    ,更新端末ＩＰ       "
			strSQL = strSQL & Chr(10) & "    ,会社コード         "
			strSQL = strSQL & Chr(10) & "    ,整理番号           "
			strSQL = strSQL & Chr(10) & "    ,高速代             "
			strSQL = strSQL & Chr(10) & "    ,備考               "
			strSQL = strSQL & Chr(10) & "   FROM チケット明細テーブル "
			strSQL = strSQL & Chr(10) & "   WHERE 1 = 1 "
			strSQL = strSQL & Chr(10) & "     AND 営業日 = '" & str営業日 & "' "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			If bln修正前フラグ = False Then
				'//修正後の場合、重複履歴の削除
				gsubDelTicketMeisaiRireki((str処理日付時刻))
			End If

			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:702b7f02-6377-45af-9bd9-96b14c668846
			'PROC_END:

			'Call gsubClearObject(objDysTemp)
			'Exit Sub

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:702b7f02-6377-45af-9bd9-96b14c668846
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		Exit Sub
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub

	'******************************************************************************
	' 関 数 名  : gsubDelTicketMeisaiRireki
	' スコープ  : Public
	' 処理内容  : チケット明細履歴の削除
	' 備    考  : 修正前・修正後で変化がなかった行に対して、更新履歴を削除する
	' 返 り 値  : なし
	' 引 き 数  : str処理日付時刻
	'
	' 変更履歴  :
	'   Version     日  付      氏  名             修正内容
	'   -----------+-----------+------------------+--------------------------------
	'   01.00.00    2016/03/30  ＫＳＲ             新規作成
	'
	'******************************************************************************
	Public Sub gsubDelTicketMeisaiRireki(ByVal str処理日付時刻 As String)

		'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		'On Error GoTo PROC_ERROR
		'++修正開始　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Const C_NAME_FUNCTION As String = "gsubDelTicketMeisaiRireki"
		Dim objDysTemp As OraDynaset
		Dim strSQL As String
		'--修正終了　2021年06月03:MK（ツール）- VB_530 VB→VB.NET変換
		Try
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換


			'++修正開始　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換
			'Dim objDysTemp As Object
			'--修正終了　2021年06月03:MK（ツール）- OR_003 VB→VB.NET変換

			strSQL = ""
			strSQL = strSQL & Chr(10) & " DELETE FROM チケット明細履歴テーブル T1   "
			strSQL = strSQL & Chr(10) & " WHERE 1 = 1   "
			strSQL = strSQL & Chr(10) & " AND TO_CHAR(処理日付時刻,'YYYY/MM/DD HH24:MI:SS') >= '" & str処理日付時刻 & "'   "
			strSQL = strSQL & Chr(10) & " AND (   "
			strSQL = strSQL & Chr(10) & "    T1.処理日付時刻        "
			strSQL = strSQL & Chr(10) & "   ,T1.処理従業員コード    "
			strSQL = strSQL & Chr(10) & "   ,T1.営業日              "
			strSQL = strSQL & Chr(10) & "   ,T1.行番号              "
			strSQL = strSQL & Chr(10) & " ) IN    "
			strSQL = strSQL & Chr(10) & " (" '-- 処理区分・更新従業員コード・更新日付時刻・更新端末ＩＰを除く項目全てでGrop化して、2件あるもの（＝更新前・更新後に変化が無いもの）を抽出
			strSQL = strSQL & Chr(10) & "   SELECT   "
			strSQL = strSQL & Chr(10) & "        処理日付時刻       "
			strSQL = strSQL & Chr(10) & "       ,処理従業員コード   "
			strSQL = strSQL & Chr(10) & "       ,営業日             "
			strSQL = strSQL & Chr(10) & "       ,行番号             "
			strSQL = strSQL & Chr(10) & "   FROM   "
			strSQL = strSQL & Chr(10) & "       チケット明細履歴テーブル TMR   "
			strSQL = strSQL & Chr(10) & "   WHERE TO_CHAR(処理日付時刻,'YYYY/MM/DD HH24:MI:SS') >= '" & str処理日付時刻 & "'   "
			strSQL = strSQL & Chr(10) & "   GROUP BY   "
			strSQL = strSQL & Chr(10) & "        処理日付時刻       "
			strSQL = strSQL & Chr(10) & "       ,処理従業員コード   "
			strSQL = strSQL & Chr(10) & "       ,従業員コード       "
			strSQL = strSQL & Chr(10) & "       ,営業日             "
			strSQL = strSQL & Chr(10) & "       ,行番号             "
			strSQL = strSQL & Chr(10) & "       ,発生日             "
			strSQL = strSQL & Chr(10) & "       ,所属コード         "
			strSQL = strSQL & Chr(10) & "       ,シフト区分         "
			strSQL = strSQL & Chr(10) & "       ,無線番号           "
			strSQL = strSQL & Chr(10) & "       ,NVL(枚数,0)        "
			strSQL = strSQL & Chr(10) & "       ,NVL(枝番,0)        "
			strSQL = strSQL & Chr(10) & "       ,車輌区分           "
			strSQL = strSQL & Chr(10) & "       ,従業員コード       "
			strSQL = strSQL & Chr(10) & "       ,未収区分           "
			strSQL = strSQL & Chr(10) & "       ,未収コード         "
			strSQL = strSQL & Chr(10) & "       ,未収枝コード       "
			strSQL = strSQL & Chr(10) & "       ,カード番号         "
			strSQL = strSQL & Chr(10) & "       ,NVL(未収金額,0)       "
			strSQL = strSQL & Chr(10) & "       ,NVL(乗務員金額,0)     "
			strSQL = strSQL & Chr(10) & "       ,NVL(外商企画料,0)     "
			strSQL = strSQL & Chr(10) & "       ,NVL(英会話ガイド料,0) "
			strSQL = strSQL & Chr(10) & "       ,NVL(立替金額,0)       "
			strSQL = strSQL & Chr(10) & "       ,NVL(手数料,0)         "
			strSQL = strSQL & Chr(10) & "       ,NVL(手数料税抜,0)     "
			strSQL = strSQL & Chr(10) & "       ,NVL(身障者現収額,0)   "
			'strSQL = strSQL & Chr(10) & "       ,更新従業員コード   "
			'strSQL = strSQL & Chr(10) & "       ,更新日付時刻       "
			strSQL = strSQL & Chr(10) & "       ,集計済みフラグ     "
			'strSQL = strSQL & Chr(10) & "       ,更新端末ＩＰ       "
			strSQL = strSQL & Chr(10) & "       ,会社コード         "
			strSQL = strSQL & Chr(10) & "       ,整理番号           "
			strSQL = strSQL & Chr(10) & "       ,NVL(高速代,0)      "
			strSQL = strSQL & Chr(10) & "       ,備考               "
			strSQL = strSQL & Chr(10) & "   HAVING COUNT(1) = 2   " '変化がなければ必ず２件ある
			strSQL = strSQL & Chr(10) & " )    "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)


			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
			'PROC_END:

			'Call gsubClearObject(objDysTemp)
			'Exit Sub

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
			'PROC_ERROR:
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
		Catch ex As Exception
			'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7
			'Resume PROC_END
			'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7

			'++修正開始　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
		End Try
		'++修正開始　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		Exit Sub
		'--修正終了　2021年06月03:MK（ツール）- VB_523 VB→VB.NET変換	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7
		'--修正終了　2021年06月03:MK（ツール）- VB_522 VB→VB.NET変換
	End Sub

    ''' <summary>
    ''' 請求そのたテーブルの登録関数
    ''' </summary>
    ''' <param name="strTableName"></param>
    ''' <param name="strInvoiceNo"></param>
    ''' <param name="請求履歴連番"></param>
    ''' <param name="税１売上合計"></param>
    ''' <param name="税１税計"></param>
    ''' <param name="税２売上合計"></param>
    ''' <param name="税２税計"></param>
    ''' <param name="不課税売上合計"></param>
    ''' <returns></returns>
    Public Function InsertInvoiceOther(strTableName As String,
                                  strInvoiceNo As String,
                                  請求履歴連番 As Int64,
                                  税１税金合計 As Double, '８％対象
                                  税１税計 As Double, '８％税額
                                  税２税金合計 As Double,'10％対象
                                  税２税計 As Double,'10％税額
                                  不課税売上合計 As Double '0％対象
                                  ) As Boolean
        Dim strSQL As String

        Try

            '----------------------------------------------------------
            '請求その他テーブル 削除
            '----------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE " & strTableName & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    請求番号   = '" & strInvoiceNo & "' "
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '----------------------------------------------------------
            '請求その他テーブル 登録
            '----------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO " & strTableName & " "
            strSQL = strSQL & Chr(10) & "   ( "
            strSQL = strSQL & Chr(10) & "      請求番号"
            strSQL = strSQL & Chr(10) & "     ,請求履歴連番"
            strSQL = strSQL & Chr(10) & "     ,税１売上合計"
            strSQL = strSQL & Chr(10) & "     ,税１税率"
            strSQL = strSQL & Chr(10) & "     ,税１税計"
            strSQL = strSQL & Chr(10) & "     ,税２売上合計"
            strSQL = strSQL & Chr(10) & "     ,税２税率"
            strSQL = strSQL & Chr(10) & "     ,税２税計"
            strSQL = strSQL & Chr(10) & "     ,不課税売上合計"
            strSQL = strSQL & Chr(10) & "     ,更新従業員コード"
            strSQL = strSQL & Chr(10) & "     ,更新日付時刻"
            strSQL = strSQL & Chr(10) & "   ) "
            strSQL = strSQL & Chr(10) & "   VALUES "
            strSQL = strSQL & Chr(10) & "   ( "
            strSQL = strSQL & Chr(10) & "     " & strInvoiceNo
            strSQL = strSQL & Chr(10) & "     ," & 請求履歴連番
            strSQL = strSQL & Chr(10) & "     ," & 税１税金合計
            strSQL = strSQL & Chr(10) & "     ," & 8.0
            strSQL = strSQL & Chr(10) & "     ," & 税１税計
            strSQL = strSQL & Chr(10) & "     ," & 税２税金合計
            strSQL = strSQL & Chr(10) & "     ," & 10.0
            strSQL = strSQL & Chr(10) & "     ," & 税２税計
            strSQL = strSQL & Chr(10) & "     ," & 不課税売上合計
            strSQL = strSQL & Chr(10) & "     ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "     ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ) "
            Call gobjOraDatabase.ExecuteSQL(strSQL)
            Return False

        Catch ex As Exception
            Return True
        End Try
    End Function
End Module
