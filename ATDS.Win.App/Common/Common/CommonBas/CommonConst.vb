Option Strict Off
Option Explicit On
Public Module basCommonConst
    '*******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : Message.bas
    ' 内    容    : システム共通定数定義
    ' 備    考    :
    ' 関数一覧    : <Public>
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+---------------------------------
    '   02.00.00    2007/11/29  廣井  芳明         新規作成
    '   02.01.00    2009/07/22  廣井  芳明         個人別売上原価計算書を営業所, 計算課, 営業部,
    '                                              および計算課の一部にて使用する為, 定数を追加.
    '   02.02.00    2009/12/07  廣井  芳明         勤務シフトを追加
    '   02.03.00    2009/12/11  廣井  芳明         勤務ファーストを追加
    '   02.04.00    2010/04/07  廣井  芳明         資格コードの長さを追加
    '   02.98.00    2015/11/10  ＫＳＲ             貸切明細区分の長さを追加
    '   02.98.00    2017/01/23  ＫＳＲ             ファーストの桁数1→2に変更
    '
    '*******************************************************************************
    ' ログイン画面 ポップアップ
    '++修正開始　2021年07月06日:MK（手）- VB→VB.NET変換
    'Public Const GC_POPUP_OBJECT_LOGIN As String = "prjLogin.clsLogin"
    Public Const GC_POPUP_OBJECT_LOGIN As String = "Login.clsLogin"
    '--修正開始　2021年07月06日:MK（手）- VB→VB.NET変換
    ' マスタ検索画面 ポップアップ
    '++修正開始　2021年06月28日:MK（手）- VB→VB.NET変換
    'Public Const GC_POPUP_OBJECT_MSTPOP As String = "prjMstPop.clsMstPop"
    Public Const GC_POPUP_OBJECT_MSTPOP As String = "MstPop.clsMstPop"
    '--修正開始　2021年06月28日:MK（手）- VB→VB.NET変換

    Public Enum genYear
        本年
        前年
        前々年
    End Enum

    '++修正開始　2024年04月05日:MK（手）- VB→VB.NET変換
    Public Enum genRideShare
        含む = 1
        除く = 2
        のみ = 3
    End Enum
    '--修正開始　2024年04月05日:MK（手）- VB→VB.NET変換

    '=Public Const GC_MAX_HONMU_NUM                   As Integer = 3
    Public Const GC_MAX_HONMU_NUM As Short = 2

    Public Const GC_DEF_SYSTEM_PATH As String = "\\172.31.1.103\MkSystem"
    Public Const GC_DEF_COMMON_DIR As String = "Common"
    Public Const GC_DEF_BAT_CONNECT As String = "プレ接続.bat"

    Public Const GC_INI_FILE_ZS0470 As String = "ZS0470.INI"
    Public Const GC_EXE_FILE_ZS0470 As String = "ZS0470.EXE"
    Public Const GC_DEF_ZSO470_PATH_LOCAL As String = "C:\NC_OFFICE\program\execute\"
    Public Const GC_DEF_ZSO470_PATH_SERVER As String = "\\192.168.1.205\e\CDRom\新給くん\NC_OFFICE\program\execute\"

    Public Const GC_PRAM_IDX_ORA_SYSDATE As Short = 0
    Public Const GC_PRAM_IDX_COMPANY_CODE As Short = 1
    Public Const GC_PRAM_IDX_POST_CODE As Short = 2
    Public Const GC_PRAM_IDX_EMPLOYEE_CODE As Short = 3
    Public Const GC_PRAM_IDX_RANK As Short = 4
    Public Const GC_PRAM_IDX_SYSTEM_AUTHORITY As Short = 5
    Public Const GC_PRAM_IDX_OFFICIAL_POSITION As Short = 6

    Public Const GC_PRAM_MAX As Short = GC_PRAM_IDX_SYSTEM_AUTHORITY
    Public Const GC_PRAM_MAX2 As Short = GC_PRAM_IDX_OFFICIAL_POSITION

    Public Const GC_MODE_GET As Short = 1
    Public Const GC_MODE_CHECK As Short = 2

    Public Const GC_STR_SELECT_NONE As String = "*---------------- <指定条件無し> ----------------*"
    Public Const GC_STR_SELECT_NONE_CAR_KBN As String = "*-------- <指定条件無し> ---------*"
    Public Const GC_STR_SELECT_NONE_SFT_KBN As String = "*- <指定条件無し> -*"
    Public Const GC_STR_SELECT_NONE_FST_KBN As String = "* <指定条件無し> *"

    Public Const GC_COMBO_SPLIT As String = " : "

    Public Const GC_LEN_COMPANY_CODE As Short = 2 ' 会社コードの長さ
    Public Const GC_LEN_CARTYPE_CODE As Short = 8 ' 車種コードの長さ
    Public Const GC_LEN_POST_CODE As Short = 6 ' 所属コードの長さ
    Public Const GC_LEN_CAR_KBN As Short = 2 ' 車輌区分の長さ
    Public Const GC_LEN_CAR_TYPE_CODE As Short = 2 ' 車種コードの長さ
    Public Const GC_LEN_SHIFT_KBN As Short = 2 ' シフト区分の長さ
    Public Const GC_LEN_YMD As Short = 8 ' 年月日の長さ
    Public Const GC_LEN_BANK_CODE As Short = 4 ' 銀行コードの長さ
    Public Const GC_LEN_BRANCH_CODE As Short = 3 ' 支店コードの長さ
    Public Const GC_LEN_CAR_DISTRICT_CODE As Short = 3 ' 車輌番号地区コードの長さ
    Public Const GC_LEN_FIRST_KBN As Short = 2 ' ファースト区分の長さ '//**桁数変更 1→2 2017/01/23
    Public Const GC_LEN_STATUS_KBN As Short = 1 ' 状態区分の長さ
    Public Const GC_LEN_WORK_KBN As Short = 2 ' 勤怠区分の長さ
    Public Const GC_LEN_SYSTEM_KBN As Short = 2 ' システム区分の長さ
    Public Const GC_LEN_EMPLOYEE_CODE As Short = 7 ' 従業員コードの長さ
    Public Const GC_LEN_CONTRACT_TYPE As Short = 2 ' 契約形態の長さ
    Public Const GC_LEN_RESIGNATION_CODE As Short = 2 ' 退職コードの長さ
    Public Const GC_LEN_UK_CUSTOMER_CODE_COMPANY As Short = 7 ' 運行管理部得意先コード(会社)
    Public Const GC_LEN_UK_CUSTOMER_CODE_POST As Short = 2 ' 運行管理部得意先コード(部門)
    Public Const GC_LEN_PAYING_KIND As Short = 2 ' 入金種別の長さ
    Public Const GC_LEN_DAY As Short = 2 ' 日付項目の長さ
    Public Const GC_LEN_CLAIM_CLOSING_DAY As Short = 2 ' 請求締日の長さ
    Public Const GC_LEN_COMMODITY_BIG_GROUP As Short = 2 ' 商品大分類コードの長さ
    Public Const GC_LEN_COUPON_KBN As Short = 2 ' クーポン区分の長さ
    Public Const GC_LEN_UK_CUSTOMER_KBN As Short = 1 ' 運管得意先区分の長さ
    Public Const GC_LEN_OFFICIAL_POSITION As Short = 2 ' 役職位の長さ
    Public Const GC_LEN_PAY_ACCOUNT As Short = 2 ' 振込口座連番の長さ
    Public Const GC_LEN_ZIP_NO_1 As Short = 3 ' 郵便番号１の長さ
    Public Const GC_LEN_ZIP_NO_2 As Short = 4 ' 郵便番号２の長さ
    Public Const GC_LEN_CONTRACT_NO As Short = 3 ' 契約番号の長さ
    Public Const GC_LEN_COMMODITY_CODE As Short = 6 ' 商品コードの長さ
    Public Const GC_LEN_RD_UKNO As Short = 7 ' 受付番号(楽々道中)の長さ
    Public Const GC_LEN_UK_REVENUE_NO As Short = 8 ' 売上番号の長さ
    Public Const GC_LEN_UK_PAYING_NO As Short = 8 ' 入金番号の長さ
    Public Const GC_LEN_ACCOUNT_KIND As Short = 1 ' 口座種別の長さ
    Public Const GC_LEN_MEMBER_CODE_PARENT As Short = 7 ' 会員コードの長さ
    Public Const GC_LEN_MEMBER_CODE_BRANCH As Short = 4 ' 会員枝コードの長さ
    Public Const GC_LEN_HOSPITAL_CODE As Short = 3 ' 病院コードの長さ
    Public Const GC_LEN_KINJIRO_BUMON As Short = 2 ' 勤次郎部門コードの長さ
    ' 勤次郎部門コード(全て)の長さ
    Public Const GC_LEN_KINJIRO_BUMON_ALL As Short = GC_LEN_KINJIRO_BUMON * 3
    Public Const GC_LEN_ZD_KIND As Short = 1 ' ＺＤ種別の長さ
    Public Const GC_LEN_MISYUU_KBN As Short = 2 ' 未収区分の長さ
    Public Const GC_LEN_TICKET_PRINT_KBN As Short = 2 ' チケット発行区分の長さ
    Public Const GC_LEN_TDFK As Short = 10 ' 都道府県の長さ
    Public Const GC_LEN_PERFECT_NO As Short = 10 ' パーフェクト番号の長さ
    Public Const GC_LEN_FUEL_KBN As Short = 2 ' 燃料区分の長さ
    Public Const GC_LEN_USED_KBN As Short = 1 ' 用途区分の長さ
    Public Const GC_LEN_NYUUKIN_KBN As Short = 1 ' 入金区分の長さ
    Public Const GC_LEN_AIRPORT_CODE As Short = 1 ' 空港コードの長さ
    Public Const GC_LEN_DISCOUNT_KIND As Short = 3 ' 割引種別の長さ
    Public Const GC_LEN_IKI_KAERI_KBN As Short = 1 ' 行帰区分の長さ
    Public Const GC_LEN_ACCIDENT_KIND As Short = 2 ' 事故種類の長さ
    Public Const GC_LEN_HAN As Short = 3 ' 班の長さ
    Public Const GC_LEN_HOLIDAY_GROUP As Short = 3 ' 公休グループの長さ
    Public Const GC_LEN_CHARGE_STATION As Short = 2 ' 充填所コードの長さ
    Public Const GC_LEN_IKISAKI_CODE As Short = 2 ' 行先コードの長さ
    Public Const GC_LEN_KASHITUKE_KOUMOKU_CODE As Short = 2 ' 貸付項目コードの長さ
    Public Const GC_LEN_LECTURE_CODE As Short = 3 ' 講義コードの長さ
    Public Const GC_LEN_TICKET_NUMBER As Short = 11 ' 整理番号の長さ
    Public Const GC_LEN_SITE_CODE As Short = 6 ' 指導場所コードの長さ
    Public Const GC_LEN_SHIKAKU_CODE As Short = 2 ' 資格コードの長さ
    Public Const GC_LEN_SHIDO_KANTOKU_BUNRUI As Short = 2 ' 指導監督分類の長さ
    Public Const GC_LEN_JITSUMU_SHIKAKU_CODE As Short = 5
    Public Const GC_LEN_JITSUMU_RANK As Short = 5
    Public Const GC_LEN_KAS_MEIKBN As Short = 2 ' 貸切明細区分の長さ
    Public Const GC_LEN_日報その他_MEIKBN As Short = 2 ' 日報その他区分の長さ

    '------------------------------
    ' ＤＢ接続設定
    '------------------------------
    Public Const GC_DEF_USER_NAME As String = "MK"
    Public Const GC_DEF_PASS_WORD As String = "MK"
    Public Const GC_DEF_TNS_NAME As String = "MK"

    '------------------------------
    ' ポップアップ呼出ラベル
    '------------------------------
    '++修正開始　2021年06月15日:MK（手）- VB→VB.NET変換
    'Public Const GC_APPEARANCE_POPUP_CALL_3D As Short = 1
    Public Const GC_APPEARANCE_POPUP_CALL_3D As Short = 2
    '--修正開始　2021年06月15日:MK（手）- VB→VB.NET変換
    Public Const GC_BACK_COLOR_POPUP_CALL_OFF As Integer = &H800000
    Public Const GC_FORE_COLOR_POPUP_CALL_OFF As Integer = &HFFFFFF

    '++修正開始　2021年06月15日:MK（手）- VB→VB.NET変換
    'Public Const GC_APPEARANCE_POPUP_CALL_FLAT As Short = 0
    Public Const GC_APPEARANCE_POPUP_CALL_FLAT As Short = 1
    '--修正開始　2021年06月15日:MK（手）- VB→VB.NET変換
    'UPGRADE_NOTE: GC_BACK_COLOR_POPUP_CALL_ON was changed from a Constant to a Variable. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"'
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    'Public GC_BACK_COLOR_POPUP_CALL_ON As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
    Public Const GC_BACK_COLOR_POPUP_CALL_ON As Integer = &HFF0000
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    Public Const GC_FORE_COLOR_POPUP_CALL_ON As Integer = &HFFFFFF

    '------------------------------
    ' 基準日
    '------------------------------
    Public Const GC_DEF_基準日 As String = "21"

    '------------------------------
    ' ポップアップＩＤ
    '------------------------------
    Public Const GC_POP_MODE_なし As Short = 0
    Public Const GC_POP_MODE_従業員マスタ As Short = 1
    Public Const GC_POP_MODE_勤怠マスタ As Short = 2
    Public Const GC_POP_MODE_病院マスタ As Short = 3
    Public Const GC_POP_MODE_統一顧客マスタ As Short = 4
    Public Const GC_POP_MODE_未収区分マスタ As Short = 5
    Public Const GC_POP_MODE_講義マスタ As Short = 6
    Public Const GC_POP_MODE_LPG充填所マスタ As Short = 9

    '------------------------------
    ' ポップアップ検索モード
    '------------------------------
    Public Const GC_POP_SEARCH_MODE_NORMAL As Short = 0 ' 通常検索
    Public Const GC_POP_SEARCH_MODE_RETIRED As Short = 1 ' 退職者検索

    '------------------------------
    ' （自）～（至）
    '------------------------------
    Public Const GC_IDX_STA As Short = 0
    Public Const GC_IDX_END As Short = 1
    Public Const GC_IDX_NOW As Short = 2 ' 現時点

    '------------------------------
    ' 正常・エラー・該当データなし
    '------------------------------
    Public Const GC_CODE_ERR As Short = -1 ' エラー
    Public Const GC_CODE_SUC As Short = 0 ' 正常
    Public Const GC_CODE_NONE As Short = 1 ' 該当データなし

    '------------------------------
    ' 印刷制御モード
    '------------------------------
    Public Const GC_PRINT_MODE_PREVIEW As Short = 1 ' プレビュ
    Public Const GC_PRINT_MODE_PRINT As Short = 2 ' 印刷

    '------------------------------
    ' フラグ
    '------------------------------
    Public Const GC_FLG_OFF As Short = 0
    Public Const GC_FLG_ON As Short = 1


    '++修正開始　2023年11月22日:MK（手）- VB→VB.NET変換
    '------------------------------
    ' 大口割引
    '------------------------------
    Public Const GC_KBN_大口割引_なし As Short = 0
    Public Const GC_KBN_大口割引_対象 As Short = 1
    Public Const GC_KBN_大口割引_特別 As Short = 2

    '--修正開始　2023年11月22日:MK（手）- VB→VB.NET変換

    '------------------------------
    ' 画面制御モード
    '------------------------------
    Public Const GC_CONTROL_MODE_NO As Short = 0 ' なし
    Public Const GC_CONTROL_MODE_NEW As Short = 1 ' 新規
    Public Const GC_CONTROL_MODE_UPDATE As Short = 2 ' 更新
    Public Const GC_CONTROL_MODE_DELETE As Short = 3 ' 削除
    Public Const GC_CONTROL_MODE_CANCEL As Short = 1 ' キャンセル
    Public Const GC_CONTROL_MODE_REDRAW As Short = 3 ' 再描画
    Public Const GC_CONTROL_MODE_INIT As Short = 4 ' 初期表示

    '------------------------------
    ' 画面制御モード
    '------------------------------
    Public Const GC_CONTROL_MODE_PRINT As Short = 1 ' 印刷
    Public Const GC_CONTROL_MODE_SEARCH As Short = 1 ' 検索
    Public Const GC_CONTROL_MODE_BODY As Short = 2 ' 明細

    '------------------------------
    ' 経歴報告書(ZSP070)
    '------------------------------
    Public Const GC_ZSP070_PRINT_BUTTON_TRUE As Short = 0 ' 印刷ボタン使用可
    Public Const GC_ZSP070_PRINT_BUTTON_FALSE As Short = 1 ' 印刷ボタン使用不可

    Public Const GC_KBN_売上振分_売上 As Short = 1
    Public Const GC_KBN_売上振分_立替付帯分 As Short = 2
    Public Const GC_KBN_売上振分_立替 As Short = 3
    Public Const GC_KBN_売上振分_その他 As Short = 4
    '++修正開始　2023年09月12日:MK（手）- VB→VB.NET変換
    Public Const GC_KBN_売上振分_仕入 As Short = 5
    Public Const GC_KBN_売上振分_仕入付帯分 As Short = 6
    '--修正開始　2023年09月12日:MK（手）- VB→VB.NET変換

    Public Const GC_KBN_売上_事後 As Short = 1
    Public Const GC_KBN_売上_事前 As Short = 2

    Public Const GC_DEF_観バス_会社 As String = "10"
    Public Const GC_DEF_観バス_所属 As String = "0"
    Public Const GC_DEF_運管_会社 As String = "0"
    Public Const GC_DEF_運管_所属 As String = "720"

    Public Const GC_DEF_MKリース_会社 As String = "11"
    Public Const GC_DEF_MKリース_所属 As String = "79998"

    '------------------------------
    ' IT推進室の所属コード
    '------------------------------
    ' 2019/03/21 ホールディイングスに伴う所属変更
    'Public Const GC_CODE_BM_IT As String = "030"
    Public Const GC_CODE_BM_IT As String = "78030"

    '------------------------------
    ' 財務の所属コード
    '------------------------------
    ' 2019/03/21 ホールディイングスに伴う所属変更
    'Public Const GC_CODE_BM_ZAIMU As String = "020"
    Public Const GC_CODE_BM_ZAIMU As String = "78020"

    '------------------------------
    ' 総務の所属コード
    '------------------------------
    ' 2019/03/21 ホールディイングスに伴う所属変更
    'Public Const GC_CODE_BM_SOUMU As String = "010"
    Public Const GC_CODE_BM_SOUMU As String = "78010"

    '------------------------------
    ' 人事の所属コード
    '------------------------------
    Public Const GC_CODE_BM_JINJI As String = "78050"

    '------------------------------
    ' 経営企画室の所属コード
    '------------------------------
    ' 2019/03/21 ホールディイングスに伴う所属変更
    'Public Const GC_CODE_BM_KIKAKU As String = "100"
    Public Const GC_CODE_BM_KIKAKU As String = "78100"

    '------------------------------
    ' 営業部の所属コード
    '------------------------------
    Public Const GC_CODE_BM_EIGYOBU As String = "200"

    '------------------------------
    ' 役員室の所属コード
    '------------------------------
    ' 2019/03/21 ホールディイングスに伴う所属変更
    'Public Const GC_CODE_BM_YAKUIN As String = "018"
    Public Const GC_CODE_BM_YAKUIN As String = "78018"

    '------------------------------
    ' 勤務区分
    '------------------------------
    Public Const GC_KBN_勤務_社員 As Short = 0
    Public Const GC_KBN_勤務_職員 As Short = 1

    '------------------------------
    ' 出欠区分
    '------------------------------
    Public Const GC_KBN_出欠_出勤 As Short = 0
    Public Const GC_KBN_出欠_欠勤 As Short = 1

    '------------------------------
    ' 入力区分
    '------------------------------
    Public Const GC_KBN_DAILY_REPORT_INPUT_ADD As Short = 0 ' 追加
    Public Const GC_KBN_DAILY_REPORT_INPUT_UPDATE As Short = 1 ' 更新（ＰＯＳ or 日報）
    Public Const GC_KBN_DAILY_REPORT_INPUT_HOLIDAY As Short = 2 ' 休務
    Public Const GC_KBN_DAILY_REPORT_INPUT_TRAINING As Short = 3 ' 教習
    '++修正開始　2024年09月06日:MK（手）- VB→VB.NET変換
    Public Const GC_KBN_DAILY_REPORT_INPUT_ERROR As Short = 4 ' エラー
    '--修正開始　2024年09月06日:MK（手）- VB→VB.NET変換

    '------------------------------
    ' 確定区分
    '------------------------------
    Public Const GC_KBN_確定_未確定 As Short = 0
    Public Const GC_KBN_確定_確定 As Short = 1
    Public Const GC_KBN_確定_確定後更新 As Short = 2

    '------------------------------
    ' 丸め単位
    '------------------------------
    Public Const GC_丸め単位_零円 As Short = 0
    Public Const GC_丸め単位_一円 As Short = 1
    Public Const GC_丸め単位_十円 As Short = 2

    '------------------------------
    ' 未収コード区分
    '------------------------------
    Public Const GC_KBN_未収コード_入力不可 As Short = 0 ' 入力不可
    Public Const GC_KBN_未収コード_入力可 As Short = 1 ' 入力可

    '------------------------------
    ' 立替金区分
    '------------------------------
    Public Const GC_KBN_立替金_入力不可 As Short = 0 ' 入力不可
    Public Const GC_KBN_立替金_入力可 As Short = 1 ' 入力可

    '------------------------------
    ' 外商企画区分
    '------------------------------
    Public Const GC_KBN_外商企画_入力不可 As Short = 0 ' 入力不可
    Public Const GC_KBN_外商企画_入力可 As Short = 1 ' 入力可

    '------------------------------
    ' 英ガイド区分
    '------------------------------
    Public Const GC_KBN_英ガイド_入力不可 As Short = 0 ' 入力不可
    Public Const GC_KBN_英ガイド_入力可 As Short = 1 ' 入力可

    '------------------------------
    ' 手数料率設定先
    '------------------------------
    Public Const GC_手数料率設定先_MK会員 As Short = 0 ' ＭＫ会員マスタ
    Public Const GC_手数料率設定先_従業員 As Short = 1 ' 従業員マスタ

    '------------------------------
    ' ハイヤーチェック
    '------------------------------
    Public Const GC_ハイヤーチェック_しない As Short = 0
    Public Const GC_ハイヤーチェック_する As Short = 1

    '------------------------------
    ' 整理番号入力区分
    '------------------------------
    Public Const GC_KBN_整理番号入力_不可 As Short = 0
    Public Const GC_KBN_整理番号入力_可 As Short = 1

    '------------------------------
    ' 手数料計算区分
    '------------------------------
    Public Const GC_KBN_手数料計算_通常 As Short = 0
    Public Const GC_KBN_手数料計算_税抜 As Short = 1

    '------------------------------
    ' 参照区分
    '------------------------------
    Public Const GC_KBN_REFERENCE_REPORT As Short = 0 ' 営業日報テーブル
    Public Const GC_KBN_REFERENCE_POS As Short = 1 ' ＰＯＳ日報テーブル

    '------------------------------
    ' 振分区分
    '------------------------------
    Public Const GC_KBN_振分_チケット As Short = 0
    Public Const GC_KBN_振分_金券 As Short = 1
    Public Const GC_KBN_振分_高速代 As Short = 2
    Public Const GC_KBN_振分_割引回数券 As Short = 3
    Public Const GC_KBN_振分_身障者割引券 As Short = 4
    Public Const GC_KBN_振分_障害者乗車券 As Short = 5
    Public Const GC_KBN_振分_他社員 As Short = 6
    Public Const GC_KBN_振分_その他 As Short = 7
    Public Const GC_KBN_振分_プリペイド As Short = 8
    Public Const GC_KBN_振分_ポイント As Short = 9

    Public Const GC_KBN_振分_MAX As Short = GC_KBN_振分_ポイント

    '------------------------------
    ' ファースト
    '------------------------------
    Public Const gClngFstKbn_Driver As Integer = 0 ' 乗務員
    Public Const gClngFstKbn_Hire As Integer = 1 ' ハイヤー
    Public Const gClngFstKbn_SemiHire As Integer = 2 ' セミハイヤー
    Public Const gClngFstKbn_Haken As Integer = 3 ' 派遣
    Public Const gClngFstKbn_Jumbo As Integer = 4 ' ジャンボ
    Public Const gClngFstKbn_SemiJumbo As Integer = 5 ' セミジャンボ
    '--2013/07/16
    Public Const gClngFstKbn_Woman As Integer = 6 ' 女性セミ

    '------------------------------
    ' 表示モード
    '------------------------------
    Public Const GC_DISP_MODE_SEARCH As Short = 0 ' 検索モード
    Public Const GC_DISP_MODE_DIALOG As Short = 1 ' ダイアログモード

    '------------------------------
    ' 表示区分
    '------------------------------
    Public Const GC_KBN_DISP_ALL As Short = 0 ' 全件
    Public Const GC_KBN_DISP_USE As Short = 1 ' 使用中のみ
    Public Const GC_KBN_DISP_NOT_USE As Short = 2 ' 未使用のみ

    '------------------------------
    ' 業務モード
    ' (会員マスタメンテおよび会員検索にて使用)
    '------------------------------
    Public Const GC_MODE_BUSINESS_CLAIM As Short = 0 ' 請求業務モード
    Public Const GC_MODE_BUSINESS_REAPORT_INPUT As Short = 1 ' 日報入力業務モード

    '------------------------------
    ' 検索モード
    ' (会員検索にて使用)
    '------------------------------
    Public Const GC_MODE_SEARCH_NORMAL As Short = 0 ' 通常モード
    Public Const GC_MODE_SEARCH_ZANDAKA As Short = 1 ' 残高表示モード

    '------------------------------
    ' 画面の基本サイズ
    '------------------------------
    Public Const GC_DEF_DISPLY_WIDTH As Integer = 1024
    Public Const GC_DEF_DISPLY_HEIGHT As Integer = 768


    Public Const gCstrNMMstDST_AirPort As String = "空港"


    Public Enum genYoto                             ' 用途区分
        '------------------------------
        Taxi                                        ' タクシー
        Hire                                        ' ハイヤー
        Jumbo                                       ' ジャンボ
    End Enum

    '------------------------------
    ' サイズ区分
    '------------------------------
    Public Const GC_KBN_SIZE_SML As Short = 0 ' 小型
    Public Const GC_KBN_SIZE_MID As Short = 1 ' 中型
    Public Const GC_KBN_SIZE_LAR As Short = 2 ' 大型
    Public Const GC_KBN_SIZE_LAR_S As Short = 3 ' 特定大型

    '------------------------------
    ' 代乗区分
    '------------------------------
    Public Const GC_KBN_DAIJYO_NASI As Short = 0 ' 代乗なし
    Public Const GC_KBN_DAIJYO_ARI As Short = 1 ' 代乗あり

    '------------------------------
    ' 照会画面 処理モード
    '------------------------------
    Public Const GC_PROC_MODE_REFER As Short = 0 ' 照会モード
    Public Const GC_PROC_MODE_SEARCH As Short = 1 ' 検索モード

    '------------------------------
    ' シフト区分
    '------------------------------
    Public Enum genShiftKbn
        昼勤 = 1
        夜勤 = 2
        交代 = 3
        隔勤 = 4
    End Enum
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    Public Enum GC_KBN_SHIFT
        昼勤 = 1
        夜勤 = 2
        交代 = 3
        隔勤 = 4
    End Enum

    Public Const GC_KBN_SHIFT_昼勤 As String = "1"
    Public Const GC_KBN_SHIFT_夜勤 As String = "2"
    Public Const GC_KBN_SHIFT_交代 As String = "3"
    Public Const GC_KBN_SHIFT_隔勤 As String = "4"
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

    '------------------------------
    ' 勤務シフト（規定公休日数のチェックに使用）
    '------------------------------
    Public Const GC_WORK_SHIFT_昼夜 As String = "12"
    Public Const GC_WORK_SHIFT_隔勤 As String = "04"
    Public Const GC_WORK_SHIFT_混在 As String = "99"

    '------------------------------
    ' 乗務区分（規定公休日数のチェックに使用）
    '------------------------------
    '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
    'Public Const GC_WORK_CREW_タクシ As String = GC_KBN_YOUTO_TAXI
    'Public Const GC_WORK_CREW_ハイヤ As String = GC_KBN_YOUTO_HIRE
    Public Const GC_WORK_CREW_タクシ As String = "0"
    Public Const GC_WORK_CREW_ハイヤ As String = "1"
    '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
    Public Const GC_WORK_CREW_混在 As String = "9"

    '------------------------------
    ' 事故区分
    '------------------------------
    Public Const GC_KBN_ACCIDENT_NO1_CAUSE As Short = 1 ' 第１原因
    Public Const GC_KBN_ACCIDENT_NO2_CAUSE As Short = 2 ' 第２原因
    Public Const GC_KBN_ACCIDENT_ONE_CAR As Short = 3 ' 自損
    Public Const GC_KBN_ACCIDENT_ONE_CAR_SD As Short = 4 ' 自損ＳＤ

    Public Const GC_MAX_MONITOR_ITME_NUM As Short = 20 ' モニター結果項目最大数

    '------------------------------
    ' システム区分
    '------------------------------
    Public Const GC_KBN_SYSTEM_KYOUSYUU As String = "01" ' 教習管理
    Public Const GC_KBN_SYSTEM_JIKO As String = "02" ' 事故管理
    Public Const GC_KBN_SYSTEM_ZDSD As String = "03" ' ＺＤＳＤ管理
    Public Const GC_KBN_SYSTEM_SOUMU As String = "04" ' 総務管理

    '------------------------------
    ' システム区分
    '------------------------------
    Public Const GC_MODE_LICENCE_INFO_NORMAL As Short = 0
    Public Const GC_MODE_LICENCE_INFO_KYOUSYUU As Short = 1

    '------------------------------
    ' 同別居区分
    '------------------------------
    Public Const GC_KBN_同別居_同居 As Short = 0
    Public Const GC_KBN_同別居_別居 As Short = 1

    '------------------------------
    ' 性別
    '------------------------------
    Public Const GC_性別_男 As Short = 0
    Public Const GC_性別_女 As Short = 1

    '------------------------------
    ' 特別手当区分
    '------------------------------
    Public Const GC_KBN_特別手当支給_なし As Short = 0
    Public Const GC_KBN_特別手当支給_あり As Short = 1

    '------------------------------
    ' 仮コード区分
    '------------------------------
    Public Const GC_KBN_本コード As Short = 0
    Public Const GC_KBN_仮コード As Short = 1

    '------------------------------
    ' 勤怠マスタ 分類
    '------------------------------
    Public Const GC_WORK_CODE_GROUP_出勤 As Short = 0
    Public Const GC_WORK_CODE_GROUP_公休 As Short = 1
    Public Const GC_WORK_CODE_GROUP_欠勤 As Short = 2
    Public Const GC_WORK_CODE_GROUP_慶弔 As Short = 3
    Public Const GC_WORK_CODE_GROUP_遅刻 As Short = 4
    Public Const GC_WORK_CODE_GROUP_早退 As Short = 5
    Public Const GC_WORK_CODE_GROUP_長欠 As Short = 6
    Public Const GC_WORK_CODE_GROUP_有休 As Short = 7
    Public Const GC_WORK_CODE_GROUP_公出 As Short = 8
    Public Const GC_WORK_CODE_GROUP_有給予約 As Short = 51
    Public Const GC_WORK_CODE_GROUP_公出予約 As Short = 52

    '------------------------------
    ' 会社コード
    '------------------------------
    Public Const GC_COMPANY_CODE_KYOTO As String = "0" ' エムケイ株式会社
    Public Const GC_COMPANY_CODE_TRACEN As String = "8" ' エムケイ株式会社(トレーニングセンター)
    Public Const GC_COMPANY_CODE_KOBE As String = "5" ' 神戸エムケイ株式会社
    Public Const GC_COMPANY_CODE_OSAKA As String = "6" ' 大阪エムケイ株式会社
    Public Const GC_COMPANY_CODE_NAGOYA As String = "7" ' 名古屋エムケイ株式会社
    Public Const GC_COMPANY_CODE_FUKUOKA As String = "30" ' 福岡エムケイ株式会社
    Public Const GC_COMPANY_CODE_SHIGA As String = "40" ' 滋賀エムケイ株式会社
    Public Const GC_COMPANY_CODE_SAPPORO As String = "50" ' 札幌エムケイ株式会社
    Public Const GC_COMPANY_CODE_KANKU As String = "60" ' 関空エムケイ株式会社 '//2018/10/04
    Public Const GC_COMPANY_CODE_TOKYO As String = "20" ' 東京エムケイ株式会社
    Public Const GC_COMPANY_CODE_CITY As String = "21" ' 東京シティエスコート

    Public Const GC_法休固定文字 As String = "【法】" '//2018/02
    Public Const GC_半休固定文字 As String = "(半休)" '//2019/08/13
    Public Const GC_振替有無固定文字 As String = "*振" '//2019/08/13
End Module