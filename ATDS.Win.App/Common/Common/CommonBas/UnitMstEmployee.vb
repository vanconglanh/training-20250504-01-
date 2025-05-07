Option Strict Off
Option Explicit On
Imports MKOra.Core
Friend Class clsUnitMstEmployee
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : UnitMstEmployee.cls
    ' 内    容    : 従業員マスタ 情報 格納 クラス モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   DBConnect                  (ＤＢ接続)
    '                   DBObjectSet                (ＤＢオブジェクト設定)
    '                   CheckEmployeeInfo          (従業員マスタ 存在チェック)
    '                   SetEmployeeInfo            (従業員マスタ 設定)
    '               <Private>
    '               <Property>
    '                   従業員コード               I/O
    '                   所属コード                 I/O
    '                   部署名                     I/O
    '                   部署名略称                 I/O
    '                   営業別社員コード           I/O
    '                   勤務区分                   I/O
    '                   勤務区分名                 I/O
    '                   役職位コード               I/O
    '                   資格コード                 I/O
    '                   性別                       I/O
    '                   血液型                     I/O
    '                   従業員名漢字               I/O
    '                   従業員名カナ               I/O
    '                   京都在住開始年月           I/O
    '                   郵便番号1                  I/O
    '                   郵便番号2                  I/O
    '                   都道府県                   I/O
    '                   市区郡                     I/O
    '                   町村番地                   I/O
    '                   号棟                       I/O
    '                   電話番号                   I/O
    '                   携帯電話番号               I/O
    '                   家賃先取番号               I/O
    '                   入社予定年月日             I/O
    '                   入社年月日                 I/O
    '                   最新異動年月日             I/O
    '                   最新出向年月日             I/O
    '                   出向先所属コード           I/O
    '                   退社予定日                 I/O
    '                   退社年月日                 I/O
    '                   退職コード                 I/O
    '                   長欠区分                   I/O
    '                   長欠勤怠コード             I/O
    '                   休務開始日                 I/O
    '                   復帰予定日                 I/O
    '                   復帰年月日                 I/O
    '                   マイカー通勤区分           I/O
    '                   健康保険番号               I/O
    '                   厚生年金番号               I/O
    '                   雇用保険番号               I/O
    '                   雇用保険徴収有無           I/O
    '                   税区分                     I/O
    '                   充員会社コード             I/O
    '                   充員所属コード             I/O
    '                   充員会社名                 I/O
    '                   充員部署名                 I/O
    '                   教習時会社コード           I/O
    '                   教習時所属コード           I/O
    '                   教習時会社名               I/O
    '                   教習時部署名               I/O
    '                   教習センター入所予定日     I/O
    '                   教習センター入所日         I/O
    '                   教習区分                   I/O
    '                   選任日付                   I/O
    '                   教習卒業日                 I/O
    '                   実動予定年月日             I/O
    '                   実動年月日                 I/O
    '                   プレートNO                 I/O
    '                   ファースト                 I/O
    '                   ファースト名               I/O
    '                   本務代務区分               I/O
    '                   本務番号                   I/O
    '                   本務車輌区分               I/O
    '                   本務車輌区分名             I/O
    '                   本務車種コード             I/O
    '                   所属班                     I/O
    '                   公休グループ               I/O
    '                   シフト区分                 I/O
    '                   カード枚数                 I/O
    '                   カードパンチNO             I/O
    '                   班長手当区分               I/O
    '                   障害者等級                 I/O
    '                   障害種類                   I/O
    '                   観光ランク                 I/O
    '                   観光ランク変更日           I/O
    '                   語学能力英語               I/O
    '                   語学能力韓国語             I/O
    '                   語学能力独語               I/O
    '                   語学能力仏語               I/O
    '                   語学能力中国語             I/O
    '                   語学能力その他             I/O
    '                   生年月日                   I/O
    '                   前回健診年月度             I/O
    '                   病歴                       I/O
    '                   特記事項                   I/O
    '                   削除日                     I/O
    '                   乗務員証発行日             I/O
    '                   運転免許更新日             I/O
    '                   身分証明書発行日           I/O
    '                   入力ランク                 I/O
    '                   パスワード                 I/O
    '                   本籍地                     I/O
    '                   出身地                     I/O
    '                   最終学校名                 I/O
    '                   最終学校学部名             I/O
    '                   最終学校学科名             I/O
    '                   最終卒業年度               I/O
    '                   最終学校卒業区分           I/O
    '                   乗務経験                   I/O
    '                   経験地                     I/O
    '                   経験年                     I/O
    '                   経験月                     I/O
    '                   取得資格                   I/O
    '                   取得年月                   I/O
    '                   職歴                       I/O
    '                   入社年月                   I/O
    '                   退職年月                   I/O
    '                   応募経路                   I/O
    '                   更新従業員コード           I/O
    '                   更新日付時刻               I/O
    '                   入社区分                   I/O
    '                   入社所属コード             I/O
    '                   退社所属コード             I/O
    '                   登録日                     I/O
    '                   特別手当区分               I/O
    '                   ランク                     I/O
    '                   入社取消日                 I/O
    '                   自家用車有無区分           I/O
    '                   車輌保険徴収区分           I/O
    '                   ETC                        I/O
    '                   出社時間昼                 I/O
    '                   出社時間夜                 I/O
    '                   出社時間隔勤               I/O
    '                   会社コード                 I/O
    '                   会社名                     I/O
    '                   会社名略称                 I/O
    '                   事業所コード               I/O
    '                   契約期間自                 I/O
    '                   契約期間至                 I/O
    '                   出向先会社コード           I/O
    '                   入社会社コード             I/O
    '                   退社会社コード             I/O
    '                   勤次郎部門コード１         I/O
    '                   勤次郎部門コード２         I/O
    '                   勤次郎部門コード３         I/O
    '                   前回更新者名               I/O
    '                   前回更新日時               I/O
    '                   二種合格日                 I/O
    '                   免許種別                   I/O
    '                   勤次郎部門コード３         I/O
    '                   有給残数                   I/O
    '                   会社負担フラグ             I/O
    '                   社内個人タクシー対象者     I/O
    '                   一車三人制対象者           I/O
    '               <Events>
    '                   Class_Initialize           (クラス初期設定)
    '                   Class_Terminate            (ＤＢ切断)
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '   01.01.00    2009/10/21  廣井  芳明         勤務区分名およびファースト名を追加
    '   01.02.00    2010/04/30  廣井  芳明         充員, および教習時の会社コード, 所属コード, 会社名, 部署名 を追加
    '   01.03.00    2010/06/14  廣井  芳明         会社負担フラグを追加
    '   01.04.00    2011/03/17  廣井  芳明         社内個人タクシー対象者, 一車三人制対象者を追加
    '   01.05.00    2011/10/11  廣井  芳明         携帯メール, 帰省先携帯電話, 帰省先メール, 帰省先携帯メール を追加
    '   01.06.00    2011/10/12  廣井  芳明         身元保証人の項目を追加
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const MC_MIN_語学能力その他 As Short = 1
    Private Const MC_MAX_語学能力その他 As Short = 5
    Private Const MC_MIN_病歴 As Short = 1
    Private Const MC_MAX_病歴 As Short = 10
    Private Const MC_MIN_特記事項 As Short = 1
    Private Const MC_MAX_特記事項 As Short = 10
    Private Const MC_MIN_取得資格 As Short = 1
    Private Const MC_MAX_取得資格 As Short = 5
    Private Const MC_MIN_取得年月 As Short = 1
    Private Const MC_MAX_取得年月 As Short = 5
    Private Const MC_MIN_職歴 As Short = 1
    Private Const MC_MAX_職歴 As Short = 10
    Private Const MC_MIN_入社年月 As Short = 1
    Private Const MC_MAX_入社年月 As Short = 10
    Private Const MC_MIN_退職年月 As Short = 1
    Private Const MC_MAX_退職年月 As Short = 10
    Private Const MC_MIN_趣味スポーツ As Short = 1
    Private Const MC_MAX_趣味スポーツ As Short = 4
    Private Const MC_MIN_趣味スポーツ以外 As Short = 1
    Private Const MC_MAX_趣味スポーツ以外 As Short = 10

    '==============================================================================
    ' 変数
    '==============================================================================
    Private mobjOraSession As Object ' Oracle
    '++修正開始　2021年05月27:MK（ツール）- OR_002 VB→VB.NET変換
    'Private mobjOraDatabase As Object ' Oracle
    Private mobjOraDatabase As OraDatabase ' Oracle
    '--修正終了　2021年05月27:MK（ツール）- OR_002 VB→VB.NET変換
    Private mblnDBConnect As Boolean ' DB接続フラグ(True：接続)
    Private mblnDBObject As Boolean ' DB接続オブジェクト設定フラグ(True：設定)

    Private mstr従業員コード As String
    Private mstr所属コード As String
    Private mstr部署名 As String
    Private mstr部署名略称 As String
    Private mstr営業別社員コード As String
    Private mint勤務区分 As Short
    Private mstr勤務区分名 As String
    Private mint役職位コード As Short
    Private mint資格コード As Short
    Private mint性別 As Short
    Private mint血液型 As Short
    Private mstr従業員名漢字 As String
    Private mstr従業員名カナ As String
    Private mstr京都在住開始年月 As String
    Private mstr郵便番号1 As String
    Private mstr郵便番号2 As String
    Private mstr都道府県 As String
    Private mstr市区郡 As String
    Private mstr町村番地 As String
    Private mstr号棟 As String
    Private mstr電話番号 As String
    Private mstr携帯電話番号 As String
    Private mint家賃先取番号 As Short
    Private mstr入社予定年月日 As String
    Private mstr入社年月日 As String
    Private mstr最新異動年月日 As String
    Private mstr最新出向年月日 As String
    Private mstr出向先所属コード As String
    Private mstr退社予定日 As String
    Private mstr退社年月日 As String
    Private mstr退職コード As String
    Private mint長欠区分 As Short
    Private mstr長欠勤怠コード As String
    Private mstr休務開始日 As String
    Private mstr復帰予定日 As String
    Private mstr復帰年月日 As String
    Private mintマイカー通勤区分 As Short
    Private mstr健康保険番号 As String
    Private mstr厚生年金番号 As String
    Private mstr雇用保険番号 As String
    Private mint雇用保険徴収有無 As Short
    Private mint税区分 As Short
    Private mstr充員会社コード As String
    Private mstr充員会社名 As String
    Private mstr充員所属コード As String
    Private mstr充員部署名 As String
    Private mstr教習時会社コード As String
    Private mstr教習時会社名 As String
    Private mstr教習時所属コード As String
    Private mstr教習時部署名 As String
    Private mstr教習センター入所予定日 As String
    Private mstr教習センター入所日 As String
    Private mint教習区分 As Short
    Private mstr選任日付 As String
    Private mstr教習卒業日 As String
    Private mstr実動予定年月日 As String
    Private mstr実動年月日 As String
    Private mstrプレートNO As String
    Private mintファースト As Short
    Private mstrファースト名 As String
    Private mint本務代務区分 As Short
    Private mstr本務番号 As String
    Private mstr本務車輌区分 As String
    Private mstr本務車輌区分名 As String
    Private mstr本務車種コード As String
    Private mstr所属班 As String
    Private mstr公休グループ As String
    Private mstrシフト区分 As String
    Private mcurカード枚数 As Decimal
    Private mstrカードパンチNO As String
    Private mint班長手当区分 As Short
    Private mstr障害者等級 As String
    Private mstr障害種類 As String
    Private mint観光ランク As Short
    Private mstr観光ランク変更日 As String
    Private mint語学能力英語 As Short
    Private mint語学能力韓国語 As Short
    Private mint語学能力独語 As Short
    Private mint語学能力仏語 As Short
    Private mint語学能力中国語 As Short
    'UPGRADE_WARNING: Lower bound of array maint語学能力その他 was changed from MC_MIN_語学能力その他 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private maint語学能力その他(MC_MAX_語学能力その他) As Short
    Private mstr生年月日 As String
    Private mstr前回健診年月度 As String
    'UPGRADE_WARNING: Lower bound of array mastr病歴 was changed from MC_MIN_病歴 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr病歴(MC_MAX_病歴) As String
    'UPGRADE_WARNING: Lower bound of array mastr病歴年月開始 was changed from MC_MIN_病歴 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr病歴年月開始(MC_MAX_病歴) As String
    'UPGRADE_WARNING: Lower bound of array mastr病歴年月終了 was changed from MC_MIN_病歴 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr病歴年月終了(MC_MAX_病歴) As String
    'UPGRADE_WARNING: Lower bound of array mastr特記事項 was changed from MC_MIN_特記事項 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr特記事項(MC_MAX_特記事項) As String
    Private mstr削除日 As String
    Private mstr乗務員証発行日 As String
    Private mstr運転免許更新日 As String
    Private mstr身分証明書発行日 As String
    Private mint入力ランク As Short
    Private mstrパスワード As String
    Private mstr本籍地 As String
    Private mstr出身地 As String
    Private mstr最終学校名 As String
    Private mstr最終学校学部名 As String
    Private mstr最終学校学科名 As String
    Private mstr最終卒業年度 As String
    Private mint最終学校卒業区分 As Short
    Private mint乗務経験 As Short
    Private mstr経験地 As String
    Private mstr経験年 As String
    Private mstr経験月 As String
    'UPGRADE_WARNING: Lower bound of array mastr取得資格 was changed from MC_MIN_取得資格 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr取得資格(MC_MAX_取得資格) As String
    'UPGRADE_WARNING: Lower bound of array mastr取得年月 was changed from MC_MIN_取得年月 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr取得年月(MC_MAX_取得年月) As String
    'UPGRADE_WARNING: Lower bound of array mastr職歴 was changed from MC_MIN_職歴 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr職歴(MC_MAX_職歴) As String
    'UPGRADE_WARNING: Lower bound of array mastr入社年月 was changed from MC_MIN_入社年月 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr入社年月(MC_MAX_入社年月) As String
    'UPGRADE_WARNING: Lower bound of array mastr退職年月 was changed from MC_MIN_退職年月 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr退職年月(MC_MAX_退職年月) As String
    Private mstr応募経路 As String
    Private mstr更新従業員コード As String
    Private mdte更新日付時刻 As Date
    Private mint入社区分 As Short
    Private mstr入社所属コード As String
    Private mstr退社所属コード As String
    Private mstr登録日 As String
    Private mint特別手当区分 As Short
    Private mstrランク As String
    Private mstr入社取消日 As String
    Private mint自家用車有無区分 As Short
    Private mint車輌保険徴収区分 As Short
    Private mstrETC As String
    Private mstr出社時間昼 As String
    Private mstr出社時間夜 As String
    Private mstr出社時間隔勤 As String
    Private mstr会社コード As String
    Private mstr会社名 As String
    Private mstr会社名略称 As String
    Private mstr事業所コード As String
    Private mstr契約期間自 As String
    Private mstr契約期間至 As String
    Private mstr出向先会社コード As String
    Private mstr入社会社コード As String
    Private mstr退社会社コード As String
    Private mstr勤次郎部門コード1 As String
    Private mstr勤次郎部門コード2 As String
    Private mstr勤次郎部門コード3 As String
    Private mstr二種合格日 As String
    Private mstr免許種別 As String
    Private mstr前回更新者名 As String
    Private mstr前回更新日時 As String
    Private mcur有給残日数 As Decimal
    Private mint会社負担フラグ As Short
    Private mint社内個人タクシー対象者 As Short
    Private mint一車三人制対象者 As Short

    Private mstr備考 As String

    Private mstrメール As String
    Private mstr携帯メール As String

    Private mstr帰省先郵便番号1 As String
    Private mstr帰省先郵便番号2 As String
    Private mstr帰省先都道府県 As String
    Private mstr帰省先市区郡 As String
    Private mstr帰省先町村番地 As String
    Private mstr帰省先号棟 As String
    Private mstr帰省先電話番号 As String
    Private mstr帰省先携帯電話番号 As String
    Private mstr帰省先メール As String
    Private mstr帰省先携帯メール As String
    Private mstr帰省先氏名 As String
    Private mstr帰省先続柄 As String

    Private mstr身元保証人名漢字 As String
    Private mstr身元保証人名カナ As String
    Private mint身元保証人性別 As Short
    Private mstr身元保証人生年月日 As String
    Private mstr身元保証人登録日 As String
    Private mstr身元保証人職業 As String
    Private mstr身元保証人続柄 As String
    Private mstr身元保証人郵便番号1 As String
    Private mstr身元保証人郵便番号2 As String
    Private mstr身元保証人都道府県 As String
    Private mstr身元保証人市区郡 As String
    Private mstr身元保証人町村番地 As String
    Private mstr身元保証人号棟 As String
    Private mstr身元保証人電話番号 As String
    Private mstr身元保証人携帯電話番号 As String
    Private mstr身元保証人メール As String
    Private mstr身元保証人携帯メール As String

    Private mint趣味有無スポーツ As Short
    Private mint趣味有無スポーツ以外 As Short

    'UPGRADE_WARNING: Lower bound of array mastr趣味スポーツ was changed from MC_MIN_趣味スポーツ to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr趣味スポーツ(MC_MAX_趣味スポーツ) As String

    'UPGRADE_WARNING: Lower bound of array mastr趣味スポーツ以外 was changed from MC_MIN_趣味スポーツ以外 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
    Private mastr趣味スポーツ以外(MC_MAX_趣味スポーツ以外) As String
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' イベント
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : Class_Initialize
    ' スコープ  : Public
    ' 処理内容  : 従業員マスタ 情報 格納 クラス 初期設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Initialize"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Initialize"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mblnDBConnect = False

            mblnDBObject = False

            Call ClearInfo()

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:073e0e13-e442-4978-8014-7b006e01c770
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:073e0e13-e442-4978-8014-7b006e01c770
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02740da1-3350-4c7b-89fd-6af1815f1bb0

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    '******************************************************************************
    ' 関 数 名  : Class_Terminate
    ' スコープ  : Public
    ' 処理内容  : ＤＢ切断
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Terminate"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_Class_Terminate"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            If mblnDBConnect = True Then

                Call gsubClearObject(mobjOraDatabase)

                Call gsubClearObject(mobjOraSession)

            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:02740da1-3350-4c7b-89fd-6af1815f1bb0
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b399e114-7d8e-49a3-9c0e-47946b4c160f

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' メソッド
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : ClearInfo
    ' スコープ  : Public
    ' 処理内容  : 従業員マスタ 情報  クリア
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/12/21  廣井  芳明         新規作成
    '   01.02.00    2010/04/30  廣井  芳明         充員会社コード, 充員所属コード, 教習時会社コード, および教習時所属コードを追加
    '
    '******************************************************************************
    Public Sub ClearInfo()

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_ClearInfo"
        Dim intIdx As Short
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_ClearInfo"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intIdx As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mstr従業員コード = ""
            mstr所属コード = ""
            mstr部署名 = ""
            mstr部署名略称 = ""
            mstr営業別社員コード = ""
            mint勤務区分 = -1
            mstr勤務区分名 = ""
            mint役職位コード = -1
            mint資格コード = -1
            mint性別 = -1
            mint血液型 = -1
            mstr従業員名漢字 = ""
            mstr従業員名カナ = ""
            mstr京都在住開始年月 = ""
            mstr郵便番号1 = ""
            mstr郵便番号2 = ""
            mstr都道府県 = ""
            mstr市区郡 = ""
            mstr町村番地 = ""
            mstr号棟 = ""
            mstr電話番号 = ""
            mstr携帯電話番号 = ""
            mint家賃先取番号 = -1
            mstr入社予定年月日 = ""
            mstr入社年月日 = ""
            mstr最新異動年月日 = ""
            mstr最新出向年月日 = ""
            mstr出向先所属コード = ""
            mstr退社予定日 = ""
            mstr退社年月日 = ""
            mstr退職コード = ""
            mint長欠区分 = -1
            mstr長欠勤怠コード = ""
            mstr休務開始日 = ""
            mstr復帰予定日 = ""
            mstr復帰年月日 = ""
            mintマイカー通勤区分 = -1
            mstr健康保険番号 = ""
            mstr厚生年金番号 = ""
            mstr雇用保険番号 = ""
            mint雇用保険徴収有無 = -1
            mint税区分 = -1
            mstr充員会社コード = ""
            mstr充員会社名 = ""
            mstr充員所属コード = ""
            mstr充員部署名 = ""
            mstr教習時会社コード = ""
            mstr教習時会社名 = ""
            mstr教習時所属コード = ""
            mstr教習時部署名 = ""
            mstr教習センター入所予定日 = ""
            mstr教習センター入所日 = ""
            mint教習区分 = -1
            mstr選任日付 = ""
            mstr教習卒業日 = ""
            mstr実動予定年月日 = ""
            mstr実動年月日 = ""
            mstrプレートNO = ""
            mintファースト = -1
            mstrファースト名 = ""
            mint本務代務区分 = -1
            mstr本務番号 = ""
            mstr本務車輌区分 = ""
            mstr本務車輌区分名 = ""
            mstr本務車種コード = ""
            mstr所属班 = ""
            mstr公休グループ = ""
            mstrシフト区分 = ""
            mcurカード枚数 = 0
            mstrカードパンチNO = ""
            mint班長手当区分 = -1
            mstr障害者等級 = ""
            mstr障害種類 = ""
            mint観光ランク = -1
            mstr観光ランク変更日 = ""
            mint語学能力英語 = -1
            mint語学能力韓国語 = -1
            mint語学能力独語 = -1
            mint語学能力仏語 = -1
            mint語学能力中国語 = -1

            For intIdx = MC_MIN_語学能力その他 To MC_MAX_語学能力その他

                maint語学能力その他(intIdx) = -1

            Next intIdx

            mstr生年月日 = ""
            mstr前回健診年月度 = ""

            For intIdx = MC_MIN_病歴 To MC_MAX_病歴

                mastr病歴(intIdx) = ""
                mastr病歴年月開始(intIdx) = ""
                mastr病歴年月終了(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_特記事項 To MC_MAX_特記事項

                mastr特記事項(intIdx) = ""

            Next intIdx

            mstr削除日 = ""
            mstr乗務員証発行日 = ""
            mstr運転免許更新日 = ""
            mstr身分証明書発行日 = ""
            mint入力ランク = -1
            mstrパスワード = ""
            mstr本籍地 = ""
            mstr出身地 = ""
            mstr最終学校名 = ""
            mstr最終学校学部名 = ""
            mstr最終学校学科名 = ""
            mstr最終卒業年度 = ""
            mint最終学校卒業区分 = -1
            mint乗務経験 = -1
            mstr経験地 = ""
            mstr経験年 = ""
            mstr経験月 = ""

            For intIdx = MC_MIN_取得資格 To MC_MAX_取得資格

                mastr取得資格(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_取得年月 To MC_MAX_取得年月

                mastr取得年月(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_職歴 To MC_MAX_職歴

                mastr職歴(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_入社年月 To MC_MAX_入社年月

                mastr入社年月(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_退職年月 To MC_MAX_退職年月

                mastr退職年月(intIdx) = ""

            Next intIdx

            mstr応募経路 = ""
            mstr更新従業員コード = ""
            mdte更新日付時刻 = Now
            mint入社区分 = -1
            mstr入社所属コード = ""
            mstr退社所属コード = ""
            mstr登録日 = ""
            mint特別手当区分 = -1
            mstrランク = ""
            mstr入社取消日 = ""
            mint自家用車有無区分 = -1
            mint車輌保険徴収区分 = -1
            mstrETC = ""
            mstr出社時間昼 = ""
            mstr出社時間夜 = ""
            mstr出社時間隔勤 = ""
            mstr会社コード = ""
            mstr会社名 = ""
            mstr会社名略称 = ""
            mstr事業所コード = ""
            mstr契約期間自 = ""
            mstr契約期間至 = ""
            mstr出向先会社コード = ""
            mstr入社会社コード = ""
            mstr退社会社コード = ""
            mstr勤次郎部門コード1 = ""
            mstr勤次郎部門コード2 = ""
            mstr勤次郎部門コード3 = ""

            mstr二種合格日 = ""
            mstr免許種別 = ""

            mstr前回更新者名 = ""
            mstr前回更新日時 = ""
            mcur有給残日数 = 0

            mint会社負担フラグ = 0

            mint社内個人タクシー対象者 = 0
            mint一車三人制対象者 = 0

            mstr備考 = ""

            mstrメール = ""
            mstr携帯メール = ""

            mstr帰省先郵便番号1 = ""
            mstr帰省先郵便番号2 = ""
            mstr帰省先都道府県 = ""
            mstr帰省先市区郡 = ""
            mstr帰省先町村番地 = ""
            mstr帰省先号棟 = ""
            mstr帰省先電話番号 = ""
            mstr帰省先携帯電話番号 = ""
            mstr帰省先メール = ""
            mstr帰省先携帯メール = ""
            mstr帰省先氏名 = ""
            mstr帰省先続柄 = ""

            mstr身元保証人名漢字 = ""
            mstr身元保証人名カナ = ""
            mint身元保証人性別 = -1
            mstr身元保証人生年月日 = ""
            mstr身元保証人登録日 = ""
            mstr身元保証人職業 = ""
            mstr身元保証人続柄 = ""
            mstr身元保証人郵便番号1 = ""
            mstr身元保証人郵便番号2 = ""
            mstr身元保証人都道府県 = ""
            mstr身元保証人市区郡 = ""
            mstr身元保証人町村番地 = ""
            mstr身元保証人号棟 = ""
            mstr身元保証人電話番号 = ""
            mstr身元保証人携帯電話番号 = ""
            mstr身元保証人メール = ""
            mstr身元保証人携帯メール = ""

            mint趣味有無スポーツ = -1
            mint趣味有無スポーツ以外 = -1

            For intIdx = MC_MIN_趣味スポーツ To MC_MAX_趣味スポーツ

                mastr趣味スポーツ(intIdx) = ""

            Next intIdx

            For intIdx = MC_MIN_趣味スポーツ以外 To MC_MAX_趣味スポーツ以外

                mastr趣味スポーツ以外(intIdx) = ""

            Next intIdx

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b399e114-7d8e-49a3-9c0e-47946b4c160f
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d5426e1a-9968-4741-bab1-3fdff0d51455
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d5426e1a-9968-4741-bab1-3fdff0d51455

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d5426e1a-9968-4741-bab1-3fdff0d51455
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d5426e1a-9968-4741-bab1-3fdff0d51455
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : DBConnect
    ' スコープ  : Public
    ' 処理内容  : ＤＢ接続
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrUserName        String            I     ユーザ名
    '   pstrPassWord        String            I     パスワード
    '   pstrTNS             String            I     ＴＮＳ名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub DBConnect(ByVal pstrUserName As String, ByVal pstrPassWord As String, ByVal pstrTNS As String)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBConnect"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBConnect"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換
            'mobjOraSession = CreateObject("OracleInProcServer.XOraSession")
            mobjOraSession = New OraSession()
            '--修正終了　2021年05月27:MK（ツール）- OR_005 VB→VB.NET変換

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            mobjOraDatabase = mobjOraSession.OpenDatabase(pstrTNS, pstrUserName & "/" & pstrPassWord, &H1)

            mblnDBConnect = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d5426e1a-9968-4741-bab1-3fdff0d51455
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:d5426e1a-9968-4741-bab1-3fdff0d51455
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:81141d37-b937-4056-a8cf-f559b1bb477a
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:81141d37-b937-4056-a8cf-f559b1bb477a

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:81141d37-b937-4056-a8cf-f559b1bb477a
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:81141d37-b937-4056-a8cf-f559b1bb477a
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : DBObjectSet
    ' スコープ  : Public
    ' 処理内容  : ＤＢオブジェクト設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjSession         Object            I     OraSession
    '   pobjDatabase        Object            I     OraDatabase
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub DBObjectSet(ByVal pobjSession As Object, ByVal pobjDatabase As Object)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBObjectSet"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_DBObjectSet"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mobjOraSession = pobjSession

            mobjOraDatabase = pobjDatabase

            mblnDBObject = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:81141d37-b937-4056-a8cf-f559b1bb477a
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:81141d37-b937-4056-a8cf-f559b1bb477a
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
    '******************************************************************************
    ' 関 数 名  : CheckEmployeeInfo
    ' スコープ  : Public
    ' 処理内容  : 従業員マスタ 存在チェック
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function CheckEmployeeInfo(ByVal pstrEmployeeCode As String) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_CheckEmployeeInfo"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_CheckEmployeeInfo"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
            'Dim objDysTemp As Object
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDysTemp As OraDynaset
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（異常終了）
            CheckEmployeeInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            '砂時計ポインタを設定
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    従業員コード "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    従業員マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    従業員コード   = '" & pstrEmployeeCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' 戻り値を設定(正常終了)
                    CheckEmployeeInfo = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
            'PROC_END:

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f4a4edbf-0a3b-4c33-b4d1-2e18ee299617
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b9b93079-970c-47b2-b760-b36208259d04
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b9b93079-970c-47b2-b760-b36208259d04

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b9b93079-970c-47b2-b760-b36208259d04
PROC_FINALLY_END:
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b9b93079-970c-47b2-b760-b36208259d04
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : SetEmployeeInfo
    ' スコープ  : Public
    ' 処理内容  : 従業員マスタ 設定
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '   01.02.00    2010/04/30  廣井  芳明         充員会社コード, 充員所属コード, 教習時会社コード, および教習時所属コードを追加
    '
    '******************************************************************************
    Public Function SetEmployeeInfo(ByVal pstrEmployeeCode As String, Optional ByVal pstrDate As String = "") As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfo"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strDate As String
        Dim strIdx As String
        Dim intIdx As Short
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfo"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
            'Dim objDysTemp As Object
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDysTemp As OraDynaset
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strDate As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strIdx As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intIdx As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（異常終了）
            SetEmployeeInfo = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    JGM1.従業員コード                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.所属コード                              "
            strSQL = strSQL & Chr(10) & "  , BSM1.部署名                                  "
            strSQL = strSQL & Chr(10) & "  , BSM1.部署名略称                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.営業別社員コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.勤務区分                                "
            strSQL = strSQL & Chr(10) & "  , MSM1.勤務区分名                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.役職位コード                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.資格コード                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.性別                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.血液型                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.従業員名漢字                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.従業員名カナ                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.京都在住開始年月                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.郵便番号１                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.郵便番号２                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.都道府県                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.市区郡                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.町村番地                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.号棟                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.電話番号                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.携帯電話番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.家賃先取番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社予定年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.最新異動年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.最新出向年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.出向先所属コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社予定日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職コード                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.長欠区分                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.長欠勤怠コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.休務開始日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.復帰予定日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.復帰年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.マイカー通勤区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.健康保険番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.厚生年金番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.雇用保険番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.雇用保険徴収有無                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.税区分                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.充員会社コード                          "
            strSQL = strSQL & Chr(10) & "  , KSM2.会社名                 AS 充員会社名    "
            strSQL = strSQL & Chr(10) & "  , JGM1.充員所属コード                          "
            strSQL = strSQL & Chr(10) & "  , BSM2.部署名                 AS 充員部署名    "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習時会社コード                        "
            strSQL = strSQL & Chr(10) & "  , KSM3.会社名                 AS 教習時会社名  "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習時所属コード                        "
            strSQL = strSQL & Chr(10) & "  , BSM3.部署名                 AS 教習時部署名  "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習センター入所予定日                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習センター入所日                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習区分                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.選任日付                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習卒業日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.実動予定年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.実動年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.プレートＮＯ                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.ファースト                              "
            strSQL = strSQL & Chr(10) & "  , FSM.ファースト名                             "
            strSQL = strSQL & Chr(10) & "  , JGM1.本務代務区分                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.本務番号                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.本務車輌区分                            "
            strSQL = strSQL & Chr(10) & "  , SKM.車輌区分名              AS 本務車輌区分名"
            strSQL = strSQL & Chr(10) & "  , JGM1.本務車種コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.所属班                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.公休グループ                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.シフト区分                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.カード枚数                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.カードパンチＮＯ                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.班長手当区分                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.障害者等級                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.障害種類                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.観光ランク                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.観光ランク変更日                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力英語                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力韓国語                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力独語                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力仏語                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力中国語                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他１                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他２                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他３                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他４                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他５                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.生年月日                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.前回健診年月度                          "

            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始１""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始２""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始３""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始４""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始５""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始６""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始７""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始８""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始９""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始１０""                        "

            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了１""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了２""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了３""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了４""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了５""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了６""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了７""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了８""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了９""                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了１０""                        "

            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴１""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴２""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴３""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴４""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴５""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴６""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴７""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴８""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴９""                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.""病歴１０""                                "

            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項１""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項２""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項３""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項４""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項５""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項６""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項７""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項８""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項９""                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項１０""                            "

            strSQL = strSQL & Chr(10) & "  , JGM1.削除日                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.乗務員証発行日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.運転免許更新日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.身分証明書発行日                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.入力ランク                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.パスワード                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.本籍地                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.出身地                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.最終学校名                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.最終学校学部名                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.最終学校学科名                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.最終卒業年度                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.最終学校卒業区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.乗務経験                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.経験地                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.経験年                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.経験月                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得資格１                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得資格２                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得資格３                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得資格４                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得資格５                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得年月１                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得年月２                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得年月３                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得年月４                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.取得年月５                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴１                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月１                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月１                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴２                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月２                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月２                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴３                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月３                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月３                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴４                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月４                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月４                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴５                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月５                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月５                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴６                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月６                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月６                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴７                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月７                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月７                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴８                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月８                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月８                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴９                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月９                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月９                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.職歴１０                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月１０                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職年月１０                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.応募経路                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.更新従業員コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM2.従業員名漢字           AS 前回更新者名  "
            strSQL = strSQL & Chr(10) & "  , JGM1.更新日付時刻                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社区分                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社所属コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社所属コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.登録日                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.特別手当区分                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.ランク                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社取消日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.自家用車有無区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.車輌保険徴収区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.ＥＴＣ                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.出社時間昼                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.出社時間夜                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.出社時間隔勤                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.会社コード                              "
            strSQL = strSQL & Chr(10) & "  , KSM1.会社名                                  "
            strSQL = strSQL & Chr(10) & "  , KSM1.略称                   AS 会社名略称    "
            strSQL = strSQL & Chr(10) & "  , JGM1.事業所コード                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.契約期間自                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.契約期間至                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.出向先会社コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社会社コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社会社コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.勤次郎部門コード１                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.勤次郎部門コード２                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.勤次郎部門コード３                      "
            strSQL = strSQL & Chr(10) & "  , MRW.二種合格日                               "
            strSQL = strSQL & Chr(10) & "  , MRW.免許種別                                 "
            strSQL = strSQL & Chr(10) & "  , NVL(KJN.UQ_ZENZ_1, 0)                        "
            strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_TOUZ_1, 0)                        "
            strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_ZENZ_3, 0)       AS 有給残日数    "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.会社負担フラグ,0)  AS 会社負担フラグ "

            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.社内個人タクシー対象者,0) AS 社内個人タクシー対象者 "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.一車三人制対象者      ,0) AS 一車三人制対象者       "

            strSQL = strSQL & Chr(10) & "  , JGM1.メール                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.携帯メール                              "

            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先郵便番号１                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先郵便番号２                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先都道府県                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先市区郡                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先町村番地                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先号棟                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先電話番号                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先携帯電話番号                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先メール                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先携帯メール                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先氏名                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.帰省先続柄                              "

            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人名漢字                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人名カナ                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人性別                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人生年月日                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人登録日                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人職業                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人続柄                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人郵便番号１                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人郵便番号２                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人都道府県                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人市区郡                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人町村番地                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人号棟                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人電話番号                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人携帯電話番号                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人メール                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人携帯メール                    "

            strSQL = strSQL & Chr(10) & "  , JGM1.趣味有無スポーツ                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.趣味有無スポーツ以外                    "

            For intIdx = MC_MIN_趣味スポーツ To MC_MAX_趣味スポーツ

                strIdx = VB6.Format(intIdx, "00")

                strSQL = strSQL & Chr(10) & "  , JGM1.趣味スポーツ" & strIdx & "                          "

            Next intIdx

            For intIdx = MC_MIN_趣味スポーツ以外 To MC_MAX_趣味スポーツ以外

                strIdx = VB6.Format(intIdx, "00")

                strSQL = strSQL & Chr(10) & "  , JGM1.趣味スポーツ以外" & strIdx & "                      "

            Next intIdx

            strSQL = strSQL & Chr(10) & "  , JGM1.備考                                    "

            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    従業員マスタ     JGM1 "
            strSQL = strSQL & Chr(10) & "  , 従業員マスタ     JGM2 "
            strSQL = strSQL & Chr(10) & "  , 会社マスタ       KSM1 "
            strSQL = strSQL & Chr(10) & "  , 部署マスタ       BSM1 "

            strSQL = strSQL & Chr(10) & "  , 会社マスタ       KSM2 "
            strSQL = strSQL & Chr(10) & "  , 部署マスタ       BSM2 "

            strSQL = strSQL & Chr(10) & "  , 会社マスタ       KSM3 "
            strSQL = strSQL & Chr(10) & "  , 部署マスタ       BSM3 "

            strSQL = strSQL & Chr(10) & "  , ファーストマスタ FSM "
            strSQL = strSQL & Chr(10) & "  , 車輌区分マスタ   SKM "
            strSQL = strSQL & Chr(10) & "  , KYUYO.KOJIN      KJN "
            strSQL = strSQL & Chr(10) & "  , ( "
            strSQL = strSQL & Chr(10) & "        SELECT "
            strSQL = strSQL & Chr(10) & "            コード   AS 勤務区分   "
            strSQL = strSQL & Chr(10) & "          , 名称漢字 AS 勤務区分名 "
            strSQL = strSQL & Chr(10) & "        FROM "
            strSQL = strSQL & Chr(10) & "            名称マスタ "
            strSQL = strSQL & Chr(10) & "        WHERE "
            strSQL = strSQL & Chr(10) & "            識別 = '勤務区分' "
            strSQL = strSQL & Chr(10) & "    ) MSM1 "

            strSQL = strSQL & Chr(10) & "  , ( "
            strSQL = strSQL & Chr(10) & "        SELECT "
            strSQL = strSQL & Chr(10) & "            WRK.従業員コード "
            strSQL = strSQL & Chr(10) & "          , MRT.二種合格日   "
            strSQL = strSQL & Chr(10) & "          , DECODE(MRT.大型二,1,'大２', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.中型二,1,'中２', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.普通二,1,'普２', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.大型  ,1,'大１', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.中型  ,1,'中１', "
            strSQL = strSQL & Chr(10) & "            DECODE(MRT.普通  ,1,'普１', 'なし')))))) AS 免許種別 "
            strSQL = strSQL & Chr(10) & "        FROM "
            strSQL = strSQL & Chr(10) & "            免許証履歴テーブル MRT "
            strSQL = strSQL & Chr(10) & "          , ( "
            strSQL = strSQL & Chr(10) & "                SELECT "
            strSQL = strSQL & Chr(10) & "                    従業員コード         "
            strSQL = strSQL & Chr(10) & "                  , MAX(枝番)    AS 枝番 "
            strSQL = strSQL & Chr(10) & "                FROM "
            strSQL = strSQL & Chr(10) & "                    免許証履歴テーブル "

            If pstrDate <> "" Then

                strSQL = strSQL & Chr(10) & "                WHERE "
                strSQL = strSQL & Chr(10) & "                    交付日 <= '" & pstrDate & "' "

            End If

            strSQL = strSQL & Chr(10) & "                GROUP BY "
            strSQL = strSQL & Chr(10) & "                    従業員コード "
            strSQL = strSQL & Chr(10) & "            ) WRK "
            strSQL = strSQL & Chr(10) & "        WHERE "
            strSQL = strSQL & Chr(10) & "            WRK.従業員コード = MRT.従業員コード(+) "
            strSQL = strSQL & Chr(10) & "        AND WRK.枝番         = MRT.枝番        (+) "
            strSQL = strSQL & Chr(10) & "    ) MRW "

            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    JGM1.従業員コード     = '" & pstrEmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "AND JGM1.更新従業員コード = JGM2.従業員コード(+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.会社コード       = KSM1.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.会社コード       = BSM1.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.所属コード       = BSM1.所属コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.充員会社コード   = KSM2.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.充員会社コード   = BSM2.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.充員所属コード   = BSM2.所属コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.教習時会社コード = KSM3.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.教習時会社コード = BSM3.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.教習時所属コード = BSM3.所属コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.従業員コード     = MRW.従業員コード (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.会社コード       = SKM.会社コード   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.本務車輌区分     = SKM.車輌区分     (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.ファースト       = FSM.ファースト   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.勤務区分         = MSM1.勤務区分    (+) "
            strSQL = strSQL & Chr(10) & "AND TO_CHAR( "
            strSQL = strSQL & Chr(10) & "        JGM1.従業員コード "
            strSQL = strSQL & Chr(10) & "      , 'FM0000000000'   "
            strSQL = strSQL & Chr(10) & "    )                    = KJN.SHAIN_CODE    (+) "

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' 戻り値を設定(正常終了)
                    SetEmployeeInfo = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr従業員コード = gfncFieldVal(.Fields("従業員コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr所属コード = gfncFieldVal(.Fields("所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr部署名 = gfncFieldVal(.Fields("部署名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr部署名略称 = gfncFieldVal(.Fields("部署名略称").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr営業別社員コード = gfncFieldVal(.Fields("営業別社員コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint勤務区分 = gfncFieldCur(.Fields("勤務区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr勤務区分名 = gfncFieldVal(.Fields("勤務区分名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint役職位コード = gfncFieldCur(.Fields("役職位コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint資格コード = gfncFieldCur(.Fields("資格コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint性別 = gfncFieldCur(.Fields("性別").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint血液型 = gfncFieldCur(.Fields("血液型").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr従業員名漢字 = gfncFieldVal(.Fields("従業員名漢字").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr従業員名カナ = gfncFieldVal(.Fields("従業員名カナ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr京都在住開始年月 = gfncFieldVal(.Fields("京都在住開始年月").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr郵便番号1 = gfncFieldVal(.Fields("郵便番号１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr郵便番号2 = gfncFieldVal(.Fields("郵便番号２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr都道府県 = gfncFieldVal(.Fields("都道府県").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr市区郡 = gfncFieldVal(.Fields("市区郡").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr町村番地 = gfncFieldVal(.Fields("町村番地").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr号棟 = gfncFieldVal(.Fields("号棟").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr電話番号 = gfncFieldVal(.Fields("電話番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr携帯電話番号 = gfncFieldVal(.Fields("携帯電話番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint家賃先取番号 = gfncFieldCur(.Fields("家賃先取番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr入社予定年月日 = gfncFieldVal(.Fields("入社予定年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr入社年月日 = gfncFieldVal(.Fields("入社年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr最新異動年月日 = gfncFieldVal(.Fields("最新異動年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr最新出向年月日 = gfncFieldVal(.Fields("最新出向年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr出向先所属コード = gfncFieldVal(.Fields("出向先所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退社予定日 = gfncFieldVal(.Fields("退社予定日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退社年月日 = gfncFieldVal(.Fields("退社年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退職コード = gfncFieldVal(.Fields("退職コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint長欠区分 = gfncFieldCur(.Fields("長欠区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr長欠勤怠コード = gfncFieldVal(.Fields("長欠勤怠コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr休務開始日 = gfncFieldVal(.Fields("休務開始日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr復帰予定日 = gfncFieldVal(.Fields("復帰予定日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr復帰年月日 = gfncFieldVal(.Fields("復帰年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mintマイカー通勤区分 = gfncFieldCur(.Fields("マイカー通勤区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr健康保険番号 = gfncFieldVal(.Fields("健康保険番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr厚生年金番号 = gfncFieldVal(.Fields("厚生年金番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr雇用保険番号 = gfncFieldVal(.Fields("雇用保険番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint雇用保険徴収有無 = gfncFieldCur(.Fields("雇用保険徴収有無").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint税区分 = gfncFieldCur(.Fields("税区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr充員会社コード = gfncFieldVal(.Fields("充員会社コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr充員会社名 = gfncFieldVal(.Fields("充員会社名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr充員所属コード = gfncFieldVal(.Fields("充員所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr充員部署名 = gfncFieldVal(.Fields("充員部署名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習時会社コード = gfncFieldVal(.Fields("教習時会社コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習時会社名 = gfncFieldVal(.Fields("教習時会社名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習時所属コード = gfncFieldVal(.Fields("教習時所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習時部署名 = gfncFieldVal(.Fields("教習時部署名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習センター入所予定日 = gfncFieldVal(.Fields("教習センター入所予定日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習センター入所日 = gfncFieldVal(.Fields("教習センター入所日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint教習区分 = gfncFieldCur(.Fields("教習区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr選任日付 = gfncFieldVal(.Fields("選任日付").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習卒業日 = gfncFieldVal(.Fields("教習卒業日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr実動予定年月日 = gfncFieldVal(.Fields("実動予定年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr実動年月日 = gfncFieldVal(.Fields("実動年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrプレートNO = gfncFieldVal(.Fields("プレートＮＯ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mintファースト = gfncFieldCur(.Fields("ファースト").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrファースト名 = gfncFieldVal(.Fields("ファースト名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint本務代務区分 = gfncFieldCur(.Fields("本務代務区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務番号 = gfncFieldVal(.Fields("本務番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務車輌区分 = gfncFieldVal(.Fields("本務車輌区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務車輌区分名 = gfncFieldVal(.Fields("本務車輌区分名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務車種コード = gfncFieldVal(.Fields("本務車種コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr所属班 = gfncFieldVal(.Fields("所属班").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr公休グループ = gfncFieldVal(.Fields("公休グループ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrシフト区分 = gfncFieldVal(.Fields("シフト区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mcurカード枚数 = gfncFieldCur(.Fields("カード枚数").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrカードパンチNO = gfncFieldVal(.Fields("カードパンチＮＯ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint班長手当区分 = gfncFieldCur(.Fields("班長手当区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr障害者等級 = gfncFieldVal(.Fields("障害者等級").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr障害種類 = gfncFieldVal(.Fields("障害種類").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint観光ランク = gfncFieldCur(.Fields("観光ランク").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr観光ランク変更日 = gfncFieldVal(.Fields("観光ランク変更日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint語学能力英語 = gfncFieldCur(.Fields("語学能力英語").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint語学能力韓国語 = gfncFieldCur(.Fields("語学能力韓国語").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint語学能力独語 = gfncFieldCur(.Fields("語学能力独語").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint語学能力仏語 = gfncFieldCur(.Fields("語学能力仏語").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint語学能力中国語 = gfncFieldCur(.Fields("語学能力中国語").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint語学能力その他(1) = gfncFieldCur(.Fields("語学能力その他１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint語学能力その他(2) = gfncFieldCur(.Fields("語学能力その他２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint語学能力その他(3) = gfncFieldCur(.Fields("語学能力その他３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint語学能力その他(4) = gfncFieldCur(.Fields("語学能力その他４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    maint語学能力その他(5) = gfncFieldCur(.Fields("語学能力その他５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr生年月日 = gfncFieldVal(.Fields("生年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr前回健診年月度 = gfncFieldVal(.Fields("前回健診年月度").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(1) = gfncFieldVal(.Fields("病歴年月開始１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(2) = gfncFieldVal(.Fields("病歴年月開始２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(3) = gfncFieldVal(.Fields("病歴年月開始３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(4) = gfncFieldVal(.Fields("病歴年月開始４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(5) = gfncFieldVal(.Fields("病歴年月開始５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(6) = gfncFieldVal(.Fields("病歴年月開始６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(7) = gfncFieldVal(.Fields("病歴年月開始７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(8) = gfncFieldVal(.Fields("病歴年月開始８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(9) = gfncFieldVal(.Fields("病歴年月開始９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月開始(10) = gfncFieldVal(.Fields("病歴年月開始１０").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(1) = gfncFieldVal(.Fields("病歴年月終了１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(2) = gfncFieldVal(.Fields("病歴年月終了２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(3) = gfncFieldVal(.Fields("病歴年月終了３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(4) = gfncFieldVal(.Fields("病歴年月終了４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(5) = gfncFieldVal(.Fields("病歴年月終了５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(6) = gfncFieldVal(.Fields("病歴年月終了６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(7) = gfncFieldVal(.Fields("病歴年月終了７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(8) = gfncFieldVal(.Fields("病歴年月終了８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(9) = gfncFieldVal(.Fields("病歴年月終了９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴年月終了(10) = gfncFieldVal(.Fields("病歴年月終了１０").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(1) = gfncFieldVal(.Fields("病歴１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(2) = gfncFieldVal(.Fields("病歴２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(3) = gfncFieldVal(.Fields("病歴３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(4) = gfncFieldVal(.Fields("病歴４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(5) = gfncFieldVal(.Fields("病歴５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(6) = gfncFieldVal(.Fields("病歴６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(7) = gfncFieldVal(.Fields("病歴７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(8) = gfncFieldVal(.Fields("病歴８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(9) = gfncFieldVal(.Fields("病歴９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr病歴(10) = gfncFieldVal(.Fields("病歴１０").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(1) = gfncFieldVal(.Fields("特記事項１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(2) = gfncFieldVal(.Fields("特記事項２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(3) = gfncFieldVal(.Fields("特記事項３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(4) = gfncFieldVal(.Fields("特記事項４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(5) = gfncFieldVal(.Fields("特記事項５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(6) = gfncFieldVal(.Fields("特記事項６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(7) = gfncFieldVal(.Fields("特記事項７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(8) = gfncFieldVal(.Fields("特記事項８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(9) = gfncFieldVal(.Fields("特記事項９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr特記事項(10) = gfncFieldVal(.Fields("特記事項１０").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr削除日 = gfncFieldVal(.Fields("削除日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr乗務員証発行日 = gfncFieldVal(.Fields("乗務員証発行日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr運転免許更新日 = gfncFieldVal(.Fields("運転免許更新日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身分証明書発行日 = gfncFieldVal(.Fields("身分証明書発行日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint入力ランク = gfncFieldCur(.Fields("入力ランク").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrパスワード = gfncFieldVal(.Fields("パスワード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本籍地 = gfncFieldVal(.Fields("本籍地").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr出身地 = gfncFieldVal(.Fields("出身地").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr最終学校名 = gfncFieldVal(.Fields("最終学校名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr最終学校学部名 = gfncFieldVal(.Fields("最終学校学部名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr最終学校学科名 = gfncFieldVal(.Fields("最終学校学科名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr最終卒業年度 = gfncFieldVal(.Fields("最終卒業年度").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint最終学校卒業区分 = gfncFieldCur(.Fields("最終学校卒業区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint乗務経験 = gfncFieldCur(.Fields("乗務経験").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr経験地 = gfncFieldVal(.Fields("経験地").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr経験年 = gfncFieldVal(.Fields("経験年").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr経験月 = gfncFieldVal(.Fields("経験月").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得資格(1) = gfncFieldVal(.Fields("取得資格１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得資格(2) = gfncFieldVal(.Fields("取得資格２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得資格(3) = gfncFieldVal(.Fields("取得資格３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得資格(4) = gfncFieldVal(.Fields("取得資格４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得資格(5) = gfncFieldVal(.Fields("取得資格５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得年月(1) = gfncFieldVal(.Fields("取得年月１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得年月(2) = gfncFieldVal(.Fields("取得年月２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得年月(3) = gfncFieldVal(.Fields("取得年月３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得年月(4) = gfncFieldVal(.Fields("取得年月４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr取得年月(5) = gfncFieldVal(.Fields("取得年月５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(1) = gfncFieldVal(.Fields("職歴１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(2) = gfncFieldVal(.Fields("職歴２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(3) = gfncFieldVal(.Fields("職歴３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(4) = gfncFieldVal(.Fields("職歴４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(5) = gfncFieldVal(.Fields("職歴５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(6) = gfncFieldVal(.Fields("職歴６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(7) = gfncFieldVal(.Fields("職歴７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(8) = gfncFieldVal(.Fields("職歴８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(9) = gfncFieldVal(.Fields("職歴９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr職歴(10) = gfncFieldVal(.Fields("職歴１０").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(1) = gfncFieldVal(.Fields("入社年月１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(2) = gfncFieldVal(.Fields("入社年月２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(3) = gfncFieldVal(.Fields("入社年月３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(4) = gfncFieldVal(.Fields("入社年月４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(5) = gfncFieldVal(.Fields("入社年月５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(6) = gfncFieldVal(.Fields("入社年月６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(7) = gfncFieldVal(.Fields("入社年月７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(8) = gfncFieldVal(.Fields("入社年月８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(9) = gfncFieldVal(.Fields("入社年月９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr入社年月(10) = gfncFieldVal(.Fields("入社年月１０").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(1) = gfncFieldVal(.Fields("退職年月１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(2) = gfncFieldVal(.Fields("退職年月２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(3) = gfncFieldVal(.Fields("退職年月３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(4) = gfncFieldVal(.Fields("退職年月４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(5) = gfncFieldVal(.Fields("退職年月５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(6) = gfncFieldVal(.Fields("退職年月６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(7) = gfncFieldVal(.Fields("退職年月７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(8) = gfncFieldVal(.Fields("退職年月８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(9) = gfncFieldVal(.Fields("退職年月９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mastr退職年月(10) = gfncFieldVal(.Fields("退職年月１０").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr応募経路 = gfncFieldVal(.Fields("応募経路").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr更新従業員コード = gfncFieldVal(.Fields("更新従業員コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr前回更新者名 = gfncFieldVal(.Fields("前回更新者名").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("更新日付時刻").Value)) = True Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mdte更新日付時刻 = gfncFieldVal(.Fields("更新日付時刻").Value)

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint入社区分 = gfncFieldCur(.Fields("入社区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr入社所属コード = gfncFieldVal(.Fields("入社所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退社所属コード = gfncFieldVal(.Fields("退社所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr登録日 = gfncFieldVal(.Fields("登録日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint特別手当区分 = gfncFieldCur(.Fields("特別手当区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrランク = gfncFieldVal(.Fields("ランク").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr入社取消日 = gfncFieldVal(.Fields("入社取消日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint自家用車有無区分 = gfncFieldCur(.Fields("自家用車有無区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint車輌保険徴収区分 = gfncFieldCur(.Fields("車輌保険徴収区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrETC = gfncFieldVal(.Fields("ＥＴＣ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr出社時間昼 = gfncFieldVal(.Fields("出社時間昼").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr出社時間夜 = gfncFieldVal(.Fields("出社時間夜").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr出社時間隔勤 = gfncFieldVal(.Fields("出社時間隔勤").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr会社コード = gfncFieldVal(.Fields("会社コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr会社名 = gfncFieldVal(.Fields("会社名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr会社名略称 = gfncFieldVal(.Fields("会社名略称").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr事業所コード = gfncFieldVal(.Fields("事業所コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr契約期間自 = gfncFieldVal(.Fields("契約期間自").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr契約期間至 = gfncFieldVal(.Fields("契約期間至").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr出向先会社コード = gfncFieldVal(.Fields("出向先会社コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr入社会社コード = gfncFieldVal(.Fields("入社会社コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退社会社コード = gfncFieldVal(.Fields("退社会社コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr勤次郎部門コード1 = gfncFieldVal(.Fields("勤次郎部門コード１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr勤次郎部門コード2 = gfncFieldVal(.Fields("勤次郎部門コード２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr勤次郎部門コード3 = gfncFieldVal(.Fields("勤次郎部門コード３").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr二種合格日 = gfncFieldVal(.Fields("二種合格日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr免許種別 = gfncFieldVal(.Fields("免許種別").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("更新日付時刻").Value)) = False Then

                        mstr前回更新日時 = ""

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mstr前回更新日時 = VB6.Format(gfncFieldVal(.Fields("更新日付時刻").Value), "yyyy/mm/dd hh:mm:ss")

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mcur有給残日数 = gfncFieldCur(.Fields("有給残日数").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint会社負担フラグ = CShort(gfncFieldCur(.Fields("会社負担フラグ").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint社内個人タクシー対象者 = CShort(gfncFieldCur(.Fields("社内個人タクシー対象者").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint一車三人制対象者 = CShort(gfncFieldCur(.Fields("一車三人制対象者").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrメール = gfncFieldVal(.Fields("メール").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr携帯メール = gfncFieldVal(.Fields("携帯メール").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先郵便番号1 = gfncFieldVal(.Fields("帰省先郵便番号１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先郵便番号2 = gfncFieldVal(.Fields("帰省先郵便番号２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先都道府県 = gfncFieldVal(.Fields("帰省先都道府県").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先市区郡 = gfncFieldVal(.Fields("帰省先市区郡").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先町村番地 = gfncFieldVal(.Fields("帰省先町村番地").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先号棟 = gfncFieldVal(.Fields("帰省先号棟").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先電話番号 = gfncFieldVal(.Fields("帰省先電話番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先携帯電話番号 = gfncFieldVal(.Fields("帰省先携帯電話番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先メール = gfncFieldVal(.Fields("帰省先メール").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先携帯メール = gfncFieldVal(.Fields("帰省先携帯メール").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先氏名 = gfncFieldVal(.Fields("帰省先氏名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr帰省先続柄 = gfncFieldVal(.Fields("帰省先続柄").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人名漢字 = gfncFieldVal(.Fields("身元保証人名漢字").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人名カナ = gfncFieldVal(.Fields("身元保証人名カナ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint身元保証人性別 = CShort(gfncFieldCur(.Fields("身元保証人性別").Value))
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人生年月日 = gfncFieldVal(.Fields("身元保証人生年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人登録日 = gfncFieldVal(.Fields("身元保証人登録日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人職業 = gfncFieldVal(.Fields("身元保証人職業").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人続柄 = gfncFieldVal(.Fields("身元保証人続柄").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人郵便番号1 = gfncFieldVal(.Fields("身元保証人郵便番号１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人郵便番号2 = gfncFieldVal(.Fields("身元保証人郵便番号２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人都道府県 = gfncFieldVal(.Fields("身元保証人都道府県").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人市区郡 = gfncFieldVal(.Fields("身元保証人市区郡").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人町村番地 = gfncFieldVal(.Fields("身元保証人町村番地").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人号棟 = gfncFieldVal(.Fields("身元保証人号棟").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人電話番号 = gfncFieldVal(.Fields("身元保証人電話番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人携帯電話番号 = gfncFieldVal(.Fields("身元保証人携帯電話番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人メール = gfncFieldVal(.Fields("身元保証人メール").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr身元保証人携帯メール = gfncFieldVal(.Fields("身元保証人携帯メール").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint趣味有無スポーツ = gfncFieldCur(.Fields("趣味有無スポーツ").Value)

                    For intIdx = MC_MIN_趣味スポーツ To MC_MAX_趣味スポーツ

                        strIdx = VB6.Format(intIdx, "00")

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mastr趣味スポーツ(intIdx) = gfncFieldVal(.Fields("趣味スポーツ" & strIdx).Value)

                    Next intIdx

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint趣味有無スポーツ以外 = gfncFieldCur(.Fields("趣味有無スポーツ以外").Value)

                    For intIdx = MC_MIN_趣味スポーツ以外 To MC_MAX_趣味スポーツ以外

                        strIdx = VB6.Format(intIdx, "00")

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mastr趣味スポーツ以外(intIdx) = gfncFieldVal(.Fields("趣味スポーツ以外" & strIdx).Value)

                    Next intIdx

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr備考 = gfncFieldVal(.Fields("備考").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b9b93079-970c-47b2-b760-b36208259d04
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b9b93079-970c-47b2-b760-b36208259d04
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : SetEmployeeInfoMini
    ' スコープ  : Public
    ' 処理内容  : 従業員マスタ 設定
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2018/08/07  KSR                不要な個人情報を取得しない
    '
    '******************************************************************************
    Public Function SetEmployeeInfoMini(ByVal pstrEmployeeCode As String) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfoMini"
        Dim objDysTemp As OraDynaset
        Dim strSQL As String
        Dim strDate As String
        Dim strIdx As String
        Dim intIdx As Short
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "clsUnitMstEmployee_SetEmployeeInfoMini"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
            'Dim objDysTemp As Object
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDysTemp As OraDynaset
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strDate As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strIdx As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intIdx As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（異常終了）
            SetEmployeeInfoMini = True

            If mblnDBConnect = False And mblnDBObject = False Then
                Exit Function
            End If

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    JGM1.従業員コード                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.所属コード                              "
            strSQL = strSQL & Chr(10) & "  , BSM1.部署名                                  "
            strSQL = strSQL & Chr(10) & "  , BSM1.部署名略称                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.営業別社員コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.勤務区分                                "
            strSQL = strSQL & Chr(10) & "  , MSM1.勤務区分名                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.役職位コード                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.資格コード                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.性別                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.血液型                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.従業員名漢字                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.従業員名カナ                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.京都在住開始年月                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.郵便番号１                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.郵便番号２                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.都道府県                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.市区郡                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.町村番地                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.号棟                                    "
            strSQL = strSQL & Chr(10) & "  , JGM1.電話番号                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.携帯電話番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.家賃先取番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社予定年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.最新異動年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.最新出向年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.出向先所属コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社予定日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.退職コード                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.長欠区分                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.長欠勤怠コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.休務開始日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.復帰予定日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.復帰年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.マイカー通勤区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.健康保険番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.厚生年金番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.雇用保険番号                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.雇用保険徴収有無                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.税区分                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.充員会社コード                          "
            strSQL = strSQL & Chr(10) & "  , KSM2.会社名                 AS 充員会社名    "
            strSQL = strSQL & Chr(10) & "  , JGM1.充員所属コード                          "
            strSQL = strSQL & Chr(10) & "  , BSM2.部署名                 AS 充員部署名    "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習時会社コード                        "
            strSQL = strSQL & Chr(10) & "  , KSM3.会社名                 AS 教習時会社名  "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習時所属コード                        "
            strSQL = strSQL & Chr(10) & "  , BSM3.部署名                 AS 教習時部署名  "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習センター入所予定日                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習センター入所日                      "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習区分                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.選任日付                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.教習卒業日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.実動予定年月日                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.実動年月日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.プレートＮＯ                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.ファースト                              "
            strSQL = strSQL & Chr(10) & "  , FSM.ファースト名                             "
            strSQL = strSQL & Chr(10) & "  , JGM1.本務代務区分                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.本務番号                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.本務車輌区分                            "
            strSQL = strSQL & Chr(10) & "  , SKM.車輌区分名              AS 本務車輌区分名"
            strSQL = strSQL & Chr(10) & "  , JGM1.本務車種コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.所属班                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.公休グループ                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.シフト区分                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.カード枚数                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.カードパンチＮＯ                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.班長手当区分                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.障害者等級                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.障害種類                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.観光ランク                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.観光ランク変更日                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力英語                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力韓国語                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力独語                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力仏語                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力中国語                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他１                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他２                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他３                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他４                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.語学能力その他５                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.生年月日                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.前回健診年月度                          "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始１""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始２""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始３""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始４""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始５""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始６""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始７""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始８""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始９""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月開始１０""                        "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了１""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了２""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了３""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了４""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了５""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了６""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了７""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了８""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了９""                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴年月終了１０""                        "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴１""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴２""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴３""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴４""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴５""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴６""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴７""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴８""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴９""                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""病歴１０""                                "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項１""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項２""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項３""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項４""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項５""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項６""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項７""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項８""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項９""                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.""特記事項１０""                            "

            '    strSQL = strSQL & Chr(10) & "  , JGM1.削除日                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.乗務員証発行日                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.運転免許更新日                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身分証明書発行日                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入力ランク                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.パスワード                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.本籍地                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.出身地                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.最終学校名                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.最終学校学部名                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.最終学校学科名                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.最終卒業年度                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.最終学校卒業区分                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.乗務経験                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.経験地                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.経験年                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.経験月                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得資格１                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得資格２                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得資格３                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得資格４                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得資格５                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得年月１                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得年月２                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得年月３                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得年月４                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.取得年月５                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴１                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月１                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月１                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴２                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月２                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月２                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴３                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月３                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月３                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴４                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月４                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月４                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴５                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月５                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月５                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴６                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月６                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月６                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴７                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月７                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月７                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴８                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月８                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月８                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴９                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月９                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月９                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.職歴１０                                "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.入社年月１０                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.退職年月１０                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.応募経路                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.更新従業員コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM2.従業員名漢字           AS 前回更新者名  "
            strSQL = strSQL & Chr(10) & "  , JGM1.更新日付時刻                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社区分                                "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社所属コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社所属コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.登録日                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.特別手当区分                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.ランク                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社取消日                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.自家用車有無区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.車輌保険徴収区分                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.ＥＴＣ                                  "
            strSQL = strSQL & Chr(10) & "  , JGM1.出社時間昼                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.出社時間夜                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.出社時間隔勤                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.会社コード                              "
            strSQL = strSQL & Chr(10) & "  , KSM1.会社名                                  "
            strSQL = strSQL & Chr(10) & "  , KSM1.略称                   AS 会社名略称    "
            strSQL = strSQL & Chr(10) & "  , JGM1.事業所コード                            "
            strSQL = strSQL & Chr(10) & "  , JGM1.契約期間自                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.契約期間至                              "
            strSQL = strSQL & Chr(10) & "  , JGM1.出向先会社コード                        "
            strSQL = strSQL & Chr(10) & "  , JGM1.入社会社コード                          "
            strSQL = strSQL & Chr(10) & "  , JGM1.退社会社コード                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.勤次郎部門コード１                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.勤次郎部門コード２                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.勤次郎部門コード３                      "
            '    strSQL = strSQL & Chr(10) & "  , MRW.二種合格日                               "
            '    strSQL = strSQL & Chr(10) & "  , MRW.免許種別                                 "
            '    strSQL = strSQL & Chr(10) & "  , NVL(KJN.UQ_ZENZ_1, 0)                        "
            '    strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_TOUZ_1, 0)                        "
            '    strSQL = strSQL & Chr(10) & "  + NVL(KJN.UQ_ZENZ_3, 0)       AS 有給残日数    "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.会社負担フラグ,0)  AS 会社負担フラグ "

            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.社内個人タクシー対象者,0) AS 社内個人タクシー対象者 "
            strSQL = strSQL & Chr(10) & "  , NVL(JGM1.一車三人制対象者      ,0) AS 一車三人制対象者       "

            '    strSQL = strSQL & Chr(10) & "  , JGM1.メール                                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.携帯メール                              "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先郵便番号１                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先郵便番号２                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先都道府県                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先市区郡                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先町村番地                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先号棟                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先電話番号                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先携帯電話番号                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先メール                            "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先携帯メール                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先氏名                              "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.帰省先続柄                              "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人名漢字                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人名カナ                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人性別                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人生年月日                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人登録日                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人職業                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人続柄                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人郵便番号１                    "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人郵便番号２                    "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人都道府県                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人市区郡                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人町村番地                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人号棟                          "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人電話番号                      "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人携帯電話番号                  "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人メール                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.身元保証人携帯メール                    "
            '
            '    strSQL = strSQL & Chr(10) & "  , JGM1.趣味有無スポーツ                        "
            '    strSQL = strSQL & Chr(10) & "  , JGM1.趣味有無スポーツ以外                    "
            '
            '    For intIdx = MC_MIN_趣味スポーツ To MC_MAX_趣味スポーツ
            '
            '        strIdx = Format(intIdx, "00")
            '
            '        strSQL = strSQL & Chr(10) & "  , JGM1.趣味スポーツ" & strIdx & "                          "
            '
            '    Next intIdx
            '
            '    For intIdx = MC_MIN_趣味スポーツ以外 To MC_MAX_趣味スポーツ以外
            '
            '        strIdx = Format(intIdx, "00")
            '
            '        strSQL = strSQL & Chr(10) & "  , JGM1.趣味スポーツ以外" & strIdx & "                      "
            '
            '    Next intIdx

            strSQL = strSQL & Chr(10) & "  , JGM1.備考                                    "

            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    従業員マスタ     JGM1 "
            strSQL = strSQL & Chr(10) & "  , 従業員マスタ     JGM2 "
            strSQL = strSQL & Chr(10) & "  , 会社マスタ       KSM1 "
            strSQL = strSQL & Chr(10) & "  , 部署マスタ       BSM1 "

            strSQL = strSQL & Chr(10) & "  , 会社マスタ       KSM2 "
            strSQL = strSQL & Chr(10) & "  , 部署マスタ       BSM2 "

            strSQL = strSQL & Chr(10) & "  , 会社マスタ       KSM3 "
            strSQL = strSQL & Chr(10) & "  , 部署マスタ       BSM3 "

            strSQL = strSQL & Chr(10) & "  , ファーストマスタ FSM "
            strSQL = strSQL & Chr(10) & "  , 車輌区分マスタ   SKM "
            '    strSQL = strSQL & Chr(10) & "  , KYUYO.KOJIN      KJN "
            strSQL = strSQL & Chr(10) & "  , ( "
            strSQL = strSQL & Chr(10) & "        SELECT "
            strSQL = strSQL & Chr(10) & "            コード   AS 勤務区分   "
            strSQL = strSQL & Chr(10) & "          , 名称漢字 AS 勤務区分名 "
            strSQL = strSQL & Chr(10) & "        FROM "
            strSQL = strSQL & Chr(10) & "            名称マスタ "
            strSQL = strSQL & Chr(10) & "        WHERE "
            strSQL = strSQL & Chr(10) & "            識別 = '勤務区分' "
            strSQL = strSQL & Chr(10) & "    ) MSM1 "

            '    strSQL = strSQL & Chr(10) & "  , ( "
            '    strSQL = strSQL & Chr(10) & "        SELECT "
            '    strSQL = strSQL & Chr(10) & "            WRK.従業員コード "
            '    strSQL = strSQL & Chr(10) & "          , MRT.二種合格日   "
            '    strSQL = strSQL & Chr(10) & "          , DECODE(MRT.大型二,1,'大２', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.中型二,1,'中２', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.普通二,1,'普２', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.大型  ,1,'大１', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.中型  ,1,'中１', "
            '    strSQL = strSQL & Chr(10) & "            DECODE(MRT.普通  ,1,'普１', 'なし')))))) AS 免許種別 "
            '    strSQL = strSQL & Chr(10) & "        FROM "
            '    strSQL = strSQL & Chr(10) & "            免許証履歴テーブル MRT "
            '    strSQL = strSQL & Chr(10) & "          , ( "
            '    strSQL = strSQL & Chr(10) & "                SELECT "
            '    strSQL = strSQL & Chr(10) & "                    従業員コード         "
            '    strSQL = strSQL & Chr(10) & "                  , MAX(枝番)    AS 枝番 "
            '    strSQL = strSQL & Chr(10) & "                FROM "
            '    strSQL = strSQL & Chr(10) & "                    免許証履歴テーブル "
            ''
            ''    If pstrDate <> "" Then
            ''
            ''        strSQL = strSQL & Chr(10) & "                WHERE "
            ''        strSQL = strSQL & Chr(10) & "                    交付日 <= '" & pstrDate & "' "
            ''
            ''    End If
            '
            '    strSQL = strSQL & Chr(10) & "                GROUP BY "
            '    strSQL = strSQL & Chr(10) & "                    従業員コード "
            '    strSQL = strSQL & Chr(10) & "            ) WRK "
            '    strSQL = strSQL & Chr(10) & "        WHERE "
            '    strSQL = strSQL & Chr(10) & "            WRK.従業員コード = MRT.従業員コード(+) "
            '    strSQL = strSQL & Chr(10) & "        AND WRK.枝番         = MRT.枝番        (+) "
            '    strSQL = strSQL & Chr(10) & "    ) MRW "

            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    JGM1.従業員コード     = '" & pstrEmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "AND JGM1.更新従業員コード = JGM2.従業員コード(+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.会社コード       = KSM1.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.会社コード       = BSM1.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.所属コード       = BSM1.所属コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.充員会社コード   = KSM2.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.充員会社コード   = BSM2.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.充員所属コード   = BSM2.所属コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.教習時会社コード = KSM3.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.教習時会社コード = BSM3.会社コード  (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.教習時所属コード = BSM3.所属コード  (+) "
            '    strSQL = strSQL & Chr(10) & "AND JGM1.従業員コード     = MRW.従業員コード (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.会社コード       = SKM.会社コード   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.本務車輌区分     = SKM.車輌区分     (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.ファースト       = FSM.ファースト   (+) "
            strSQL = strSQL & Chr(10) & "AND JGM1.勤務区分         = MSM1.勤務区分    (+) "
            '    strSQL = strSQL & Chr(10) & "AND TO_CHAR( "
            '    strSQL = strSQL & Chr(10) & "        JGM1.従業員コード "
            '    strSQL = strSQL & Chr(10) & "      , 'FM0000000000'   "
            '    strSQL = strSQL & Chr(10) & "    )                    = KJN.SHAIN_CODE    (+) "

            'UPGRADE_WARNING: Couldn't resolve default property of object mobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = mobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    ' 戻り値を設定(正常終了)
                    SetEmployeeInfoMini = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr従業員コード = gfncFieldVal(.Fields("従業員コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr所属コード = gfncFieldVal(.Fields("所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr部署名 = gfncFieldVal(.Fields("部署名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr部署名略称 = gfncFieldVal(.Fields("部署名略称").Value)
                    '            mstr営業別社員コード = gfncFieldVal(.Fields("営業別社員コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint勤務区分 = gfncFieldCur(.Fields("勤務区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr勤務区分名 = gfncFieldVal(.Fields("勤務区分名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint役職位コード = gfncFieldCur(.Fields("役職位コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint資格コード = gfncFieldCur(.Fields("資格コード").Value)
                    '            mint性別 = gfncFieldCur(.Fields("性別").Value)
                    '            mint血液型 = gfncFieldCur(.Fields("血液型").Value)
                    '            mstr従業員名漢字 = gfncFieldVal(.Fields("従業員名漢字").Value)
                    '            mstr従業員名カナ = gfncFieldVal(.Fields("従業員名カナ").Value)
                    '            mstr京都在住開始年月 = gfncFieldVal(.Fields("京都在住開始年月").Value)
                    '            mstr郵便番号1 = gfncFieldVal(.Fields("郵便番号１").Value)
                    '            mstr郵便番号2 = gfncFieldVal(.Fields("郵便番号２").Value)
                    '            mstr都道府県 = gfncFieldVal(.Fields("都道府県").Value)
                    '            mstr市区郡 = gfncFieldVal(.Fields("市区郡").Value)
                    '            mstr町村番地 = gfncFieldVal(.Fields("町村番地").Value)
                    '            mstr号棟 = gfncFieldVal(.Fields("号棟").Value)
                    '            mstr電話番号 = gfncFieldVal(.Fields("電話番号").Value)
                    '            mstr携帯電話番号 = gfncFieldVal(.Fields("携帯電話番号").Value)
                    '            mint家賃先取番号 = gfncFieldCur(.Fields("家賃先取番号").Value)
                    '            mstr入社予定年月日 = gfncFieldVal(.Fields("入社予定年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr入社年月日 = gfncFieldVal(.Fields("入社年月日").Value)
                    '            mstr最新異動年月日 = gfncFieldVal(.Fields("最新異動年月日").Value)
                    '            mstr最新出向年月日 = gfncFieldVal(.Fields("最新出向年月日").Value)
                    '            mstr出向先所属コード = gfncFieldVal(.Fields("出向先所属コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退社予定日 = gfncFieldVal(.Fields("退社予定日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退社年月日 = gfncFieldVal(.Fields("退社年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr退職コード = gfncFieldVal(.Fields("退職コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint長欠区分 = gfncFieldCur(.Fields("長欠区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr長欠勤怠コード = gfncFieldVal(.Fields("長欠勤怠コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr休務開始日 = gfncFieldVal(.Fields("休務開始日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr復帰予定日 = gfncFieldVal(.Fields("復帰予定日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr復帰年月日 = gfncFieldVal(.Fields("復帰年月日").Value)
                    '            mintマイカー通勤区分 = gfncFieldCur(.Fields("マイカー通勤区分").Value)
                    '            mstr健康保険番号 = gfncFieldVal(.Fields("健康保険番号").Value)
                    '            mstr厚生年金番号 = gfncFieldVal(.Fields("厚生年金番号").Value)
                    '            mstr雇用保険番号 = gfncFieldVal(.Fields("雇用保険番号").Value)
                    '            mint雇用保険徴収有無 = gfncFieldCur(.Fields("雇用保険徴収有無").Value)
                    '            mint税区分 = gfncFieldCur(.Fields("税区分").Value)
                    '            mstr充員会社コード = gfncFieldVal(.Fields("充員会社コード").Value)
                    '            mstr充員会社名 = gfncFieldVal(.Fields("充員会社名").Value)
                    '            mstr充員所属コード = gfncFieldVal(.Fields("充員所属コード").Value)
                    '            mstr充員部署名 = gfncFieldVal(.Fields("充員部署名").Value)
                    '            mstr教習時会社コード = gfncFieldVal(.Fields("教習時会社コード").Value)
                    '            mstr教習時会社名 = gfncFieldVal(.Fields("教習時会社名").Value)
                    '            mstr教習時所属コード = gfncFieldVal(.Fields("教習時所属コード").Value)
                    '            mstr教習時部署名 = gfncFieldVal(.Fields("教習時部署名").Value)
                    '            mstr教習センター入所予定日 = gfncFieldVal(.Fields("教習センター入所予定日").Value)
                    '            mstr教習センター入所日 = gfncFieldVal(.Fields("教習センター入所日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint教習区分 = gfncFieldCur(.Fields("教習区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr選任日付 = gfncFieldVal(.Fields("選任日付").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr教習卒業日 = gfncFieldVal(.Fields("教習卒業日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr実動予定年月日 = gfncFieldVal(.Fields("実動予定年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr実動年月日 = gfncFieldVal(.Fields("実動年月日").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrプレートNO = gfncFieldVal(.Fields("プレートＮＯ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mintファースト = gfncFieldCur(.Fields("ファースト").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrファースト名 = gfncFieldVal(.Fields("ファースト名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint本務代務区分 = gfncFieldCur(.Fields("本務代務区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務番号 = gfncFieldVal(.Fields("本務番号").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務車輌区分 = gfncFieldVal(.Fields("本務車輌区分").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務車輌区分名 = gfncFieldVal(.Fields("本務車輌区分名").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr本務車種コード = gfncFieldVal(.Fields("本務車種コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr所属班 = gfncFieldVal(.Fields("所属班").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr公休グループ = gfncFieldVal(.Fields("公休グループ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstrシフト区分 = gfncFieldVal(.Fields("シフト区分").Value)
                    '            mcurカード枚数 = gfncFieldCur(.Fields("カード枚数").Value)
                    '            mstrカードパンチNO = gfncFieldVal(.Fields("カードパンチＮＯ").Value)
                    '            mint班長手当区分 = gfncFieldCur(.Fields("班長手当区分").Value)
                    '            mstr障害者等級 = gfncFieldVal(.Fields("障害者等級").Value)
                    '            mstr障害種類 = gfncFieldVal(.Fields("障害種類").Value)
                    '            mint観光ランク = gfncFieldCur(.Fields("観光ランク").Value)
                    '            mstr観光ランク変更日 = gfncFieldVal(.Fields("観光ランク変更日").Value)
                    '            mint語学能力英語 = gfncFieldCur(.Fields("語学能力英語").Value)
                    '            mint語学能力韓国語 = gfncFieldCur(.Fields("語学能力韓国語").Value)
                    '            mint語学能力独語 = gfncFieldCur(.Fields("語学能力独語").Value)
                    '            mint語学能力仏語 = gfncFieldCur(.Fields("語学能力仏語").Value)
                    '            mint語学能力中国語 = gfncFieldCur(.Fields("語学能力中国語").Value)
                    '            maint語学能力その他(1) = gfncFieldCur(.Fields("語学能力その他１").Value)
                    '            maint語学能力その他(2) = gfncFieldCur(.Fields("語学能力その他２").Value)
                    '            maint語学能力その他(3) = gfncFieldCur(.Fields("語学能力その他３").Value)
                    '            maint語学能力その他(4) = gfncFieldCur(.Fields("語学能力その他４").Value)
                    '            maint語学能力その他(5) = gfncFieldCur(.Fields("語学能力その他５").Value)
                    '            mstr生年月日 = gfncFieldVal(.Fields("生年月日").Value)
                    '            mstr前回健診年月度 = gfncFieldVal(.Fields("前回健診年月度").Value)
                    '
                    '            mastr病歴年月開始(1) = gfncFieldVal(.Fields("病歴年月開始１").Value)
                    '            mastr病歴年月開始(2) = gfncFieldVal(.Fields("病歴年月開始２").Value)
                    '            mastr病歴年月開始(3) = gfncFieldVal(.Fields("病歴年月開始３").Value)
                    '            mastr病歴年月開始(4) = gfncFieldVal(.Fields("病歴年月開始４").Value)
                    '            mastr病歴年月開始(5) = gfncFieldVal(.Fields("病歴年月開始５").Value)
                    '            mastr病歴年月開始(6) = gfncFieldVal(.Fields("病歴年月開始６").Value)
                    '            mastr病歴年月開始(7) = gfncFieldVal(.Fields("病歴年月開始７").Value)
                    '            mastr病歴年月開始(8) = gfncFieldVal(.Fields("病歴年月開始８").Value)
                    '            mastr病歴年月開始(9) = gfncFieldVal(.Fields("病歴年月開始９").Value)
                    '            mastr病歴年月開始(10) = gfncFieldVal(.Fields("病歴年月開始１０").Value)
                    '
                    '            mastr病歴年月終了(1) = gfncFieldVal(.Fields("病歴年月終了１").Value)
                    '            mastr病歴年月終了(2) = gfncFieldVal(.Fields("病歴年月終了２").Value)
                    '            mastr病歴年月終了(3) = gfncFieldVal(.Fields("病歴年月終了３").Value)
                    '            mastr病歴年月終了(4) = gfncFieldVal(.Fields("病歴年月終了４").Value)
                    '            mastr病歴年月終了(5) = gfncFieldVal(.Fields("病歴年月終了５").Value)
                    '            mastr病歴年月終了(6) = gfncFieldVal(.Fields("病歴年月終了６").Value)
                    '            mastr病歴年月終了(7) = gfncFieldVal(.Fields("病歴年月終了７").Value)
                    '            mastr病歴年月終了(8) = gfncFieldVal(.Fields("病歴年月終了８").Value)
                    '            mastr病歴年月終了(9) = gfncFieldVal(.Fields("病歴年月終了９").Value)
                    '            mastr病歴年月終了(10) = gfncFieldVal(.Fields("病歴年月終了１０").Value)
                    '
                    '            mastr病歴(1) = gfncFieldVal(.Fields("病歴１").Value)
                    '            mastr病歴(2) = gfncFieldVal(.Fields("病歴２").Value)
                    '            mastr病歴(3) = gfncFieldVal(.Fields("病歴３").Value)
                    '            mastr病歴(4) = gfncFieldVal(.Fields("病歴４").Value)
                    '            mastr病歴(5) = gfncFieldVal(.Fields("病歴５").Value)
                    '            mastr病歴(6) = gfncFieldVal(.Fields("病歴６").Value)
                    '            mastr病歴(7) = gfncFieldVal(.Fields("病歴７").Value)
                    '            mastr病歴(8) = gfncFieldVal(.Fields("病歴８").Value)
                    '            mastr病歴(9) = gfncFieldVal(.Fields("病歴９").Value)
                    '            mastr病歴(10) = gfncFieldVal(.Fields("病歴１０").Value)
                    '
                    '            mastr特記事項(1) = gfncFieldVal(.Fields("特記事項１").Value)
                    '            mastr特記事項(2) = gfncFieldVal(.Fields("特記事項２").Value)
                    '            mastr特記事項(3) = gfncFieldVal(.Fields("特記事項３").Value)
                    '            mastr特記事項(4) = gfncFieldVal(.Fields("特記事項４").Value)
                    '            mastr特記事項(5) = gfncFieldVal(.Fields("特記事項５").Value)
                    '            mastr特記事項(6) = gfncFieldVal(.Fields("特記事項６").Value)
                    '            mastr特記事項(7) = gfncFieldVal(.Fields("特記事項７").Value)
                    '            mastr特記事項(8) = gfncFieldVal(.Fields("特記事項８").Value)
                    '            mastr特記事項(9) = gfncFieldVal(.Fields("特記事項９").Value)
                    '            mastr特記事項(10) = gfncFieldVal(.Fields("特記事項１０").Value)
                    '
                    '            mstr削除日 = gfncFieldVal(.Fields("削除日").Value)
                    '            mstr乗務員証発行日 = gfncFieldVal(.Fields("乗務員証発行日").Value)
                    '            mstr運転免許更新日 = gfncFieldVal(.Fields("運転免許更新日").Value)
                    '            mstr身分証明書発行日 = gfncFieldVal(.Fields("身分証明書発行日").Value)
                    '            mint入力ランク = gfncFieldCur(.Fields("入力ランク").Value)
                    '            mstrパスワード = gfncFieldVal(.Fields("パスワード").Value)
                    '            mstr本籍地 = gfncFieldVal(.Fields("本籍地").Value)
                    '            mstr出身地 = gfncFieldVal(.Fields("出身地").Value)
                    '            mstr最終学校名 = gfncFieldVal(.Fields("最終学校名").Value)
                    '            mstr最終学校学部名 = gfncFieldVal(.Fields("最終学校学部名").Value)
                    '            mstr最終学校学科名 = gfncFieldVal(.Fields("最終学校学科名").Value)
                    '            mstr最終卒業年度 = gfncFieldVal(.Fields("最終卒業年度").Value)
                    '            mint最終学校卒業区分 = gfncFieldCur(.Fields("最終学校卒業区分").Value)
                    '            mint乗務経験 = gfncFieldCur(.Fields("乗務経験").Value)
                    '            mstr経験地 = gfncFieldVal(.Fields("経験地").Value)
                    '            mstr経験年 = gfncFieldVal(.Fields("経験年").Value)
                    '            mstr経験月 = gfncFieldVal(.Fields("経験月").Value)
                    '            mastr取得資格(1) = gfncFieldVal(.Fields("取得資格１").Value)
                    '            mastr取得資格(2) = gfncFieldVal(.Fields("取得資格２").Value)
                    '            mastr取得資格(3) = gfncFieldVal(.Fields("取得資格３").Value)
                    '            mastr取得資格(4) = gfncFieldVal(.Fields("取得資格４").Value)
                    '            mastr取得資格(5) = gfncFieldVal(.Fields("取得資格５").Value)
                    '            mastr取得年月(1) = gfncFieldVal(.Fields("取得年月１").Value)
                    '            mastr取得年月(2) = gfncFieldVal(.Fields("取得年月２").Value)
                    '            mastr取得年月(3) = gfncFieldVal(.Fields("取得年月３").Value)
                    '            mastr取得年月(4) = gfncFieldVal(.Fields("取得年月４").Value)
                    '            mastr取得年月(5) = gfncFieldVal(.Fields("取得年月５").Value)
                    '            mastr職歴(1) = gfncFieldVal(.Fields("職歴１").Value)
                    '            mastr職歴(2) = gfncFieldVal(.Fields("職歴２").Value)
                    '            mastr職歴(3) = gfncFieldVal(.Fields("職歴３").Value)
                    '            mastr職歴(4) = gfncFieldVal(.Fields("職歴４").Value)
                    '            mastr職歴(5) = gfncFieldVal(.Fields("職歴５").Value)
                    '            mastr職歴(6) = gfncFieldVal(.Fields("職歴６").Value)
                    '            mastr職歴(7) = gfncFieldVal(.Fields("職歴７").Value)
                    '            mastr職歴(8) = gfncFieldVal(.Fields("職歴８").Value)
                    '            mastr職歴(9) = gfncFieldVal(.Fields("職歴９").Value)
                    '            mastr職歴(10) = gfncFieldVal(.Fields("職歴１０").Value)
                    '            mastr入社年月(1) = gfncFieldVal(.Fields("入社年月１").Value)
                    '            mastr入社年月(2) = gfncFieldVal(.Fields("入社年月２").Value)
                    '            mastr入社年月(3) = gfncFieldVal(.Fields("入社年月３").Value)
                    '            mastr入社年月(4) = gfncFieldVal(.Fields("入社年月４").Value)
                    '            mastr入社年月(5) = gfncFieldVal(.Fields("入社年月５").Value)
                    '            mastr入社年月(6) = gfncFieldVal(.Fields("入社年月６").Value)
                    '            mastr入社年月(7) = gfncFieldVal(.Fields("入社年月７").Value)
                    '            mastr入社年月(8) = gfncFieldVal(.Fields("入社年月８").Value)
                    '            mastr入社年月(9) = gfncFieldVal(.Fields("入社年月９").Value)
                    '            mastr入社年月(10) = gfncFieldVal(.Fields("入社年月１０").Value)
                    '            mastr退職年月(1) = gfncFieldVal(.Fields("退職年月１").Value)
                    '            mastr退職年月(2) = gfncFieldVal(.Fields("退職年月２").Value)
                    '            mastr退職年月(3) = gfncFieldVal(.Fields("退職年月３").Value)
                    '            mastr退職年月(4) = gfncFieldVal(.Fields("退職年月４").Value)
                    '            mastr退職年月(5) = gfncFieldVal(.Fields("退職年月５").Value)
                    '            mastr退職年月(6) = gfncFieldVal(.Fields("退職年月６").Value)
                    '            mastr退職年月(7) = gfncFieldVal(.Fields("退職年月７").Value)
                    '            mastr退職年月(8) = gfncFieldVal(.Fields("退職年月８").Value)
                    '            mastr退職年月(9) = gfncFieldVal(.Fields("退職年月９").Value)
                    '            mastr退職年月(10) = gfncFieldVal(.Fields("退職年月１０").Value)
                    '            mstr応募経路 = gfncFieldVal(.Fields("応募経路").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr更新従業員コード = gfncFieldVal(.Fields("更新従業員コード").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mstr前回更新者名 = gfncFieldVal(.Fields("前回更新者名").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("更新日付時刻").Value)) = True Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mdte更新日付時刻 = gfncFieldVal(.Fields("更新日付時刻").Value)

                    End If

                    '            mint入社区分 = gfncFieldCur(.Fields("入社区分").Value)
                    '            mstr入社所属コード = gfncFieldVal(.Fields("入社所属コード").Value)
                    '            mstr退社所属コード = gfncFieldVal(.Fields("退社所属コード").Value)
                    '            mstr登録日 = gfncFieldVal(.Fields("登録日").Value)
                    '            mint特別手当区分 = gfncFieldCur(.Fields("特別手当区分").Value)
                    '            mstrランク = gfncFieldVal(.Fields("ランク").Value)
                    '            mstr入社取消日 = gfncFieldVal(.Fields("入社取消日").Value)
                    '            mint自家用車有無区分 = gfncFieldCur(.Fields("自家用車有無区分").Value)
                    '            mint車輌保険徴収区分 = gfncFieldCur(.Fields("車輌保険徴収区分").Value)
                    '            mstrETC = gfncFieldVal(.Fields("ＥＴＣ").Value)
                    '            mstr出社時間昼 = gfncFieldVal(.Fields("出社時間昼").Value)
                    '            mstr出社時間夜 = gfncFieldVal(.Fields("出社時間夜").Value)
                    '            mstr出社時間隔勤 = gfncFieldVal(.Fields("出社時間隔勤").Value)
                    '            mstr会社コード = gfncFieldVal(.Fields("会社コード").Value)
                    '            mstr会社名 = gfncFieldVal(.Fields("会社名").Value)
                    '            mstr会社名略称 = gfncFieldVal(.Fields("会社名略称").Value)
                    '            mstr事業所コード = gfncFieldVal(.Fields("事業所コード").Value)
                    '            mstr契約期間自 = gfncFieldVal(.Fields("契約期間自").Value)
                    '            mstr契約期間至 = gfncFieldVal(.Fields("契約期間至").Value)
                    '            mstr出向先会社コード = gfncFieldVal(.Fields("出向先会社コード").Value)
                    '            mstr入社会社コード = gfncFieldVal(.Fields("入社会社コード").Value)
                    '            mstr退社会社コード = gfncFieldVal(.Fields("退社会社コード").Value)
                    '            mstr勤次郎部門コード1 = gfncFieldVal(.Fields("勤次郎部門コード１").Value)
                    '            mstr勤次郎部門コード2 = gfncFieldVal(.Fields("勤次郎部門コード２").Value)
                    '            mstr勤次郎部門コード3 = gfncFieldVal(.Fields("勤次郎部門コード３").Value)
                    '
                    '            mstr二種合格日 = gfncFieldVal(.Fields("二種合格日").Value)
                    '            mstr免許種別 = gfncFieldVal(.Fields("免許種別").Value)
                    '
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If IsDate(gfncFieldVal(.Fields("更新日付時刻").Value)) = False Then

                        mstr前回更新日時 = ""

                    Else

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        mstr前回更新日時 = VB6.Format(gfncFieldVal(.Fields("更新日付時刻").Value), "yyyy/mm/dd hh:mm:ss")

                    End If

                    '            mcur有給残日数 = gfncFieldCur(.Fields("有給残日数").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint会社負担フラグ = CShort(gfncFieldCur(.Fields("会社負担フラグ").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint社内個人タクシー対象者 = CShort(gfncFieldCur(.Fields("社内個人タクシー対象者").Value))

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mint一車三人制対象者 = CShort(gfncFieldCur(.Fields("一車三人制対象者").Value))

                    '            mstrメール = gfncFieldVal(.Fields("メール").Value)
                    '            mstr携帯メール = gfncFieldVal(.Fields("携帯メール").Value)
                    '
                    '            mstr帰省先郵便番号1 = gfncFieldVal(.Fields("帰省先郵便番号１").Value)
                    '            mstr帰省先郵便番号2 = gfncFieldVal(.Fields("帰省先郵便番号２").Value)
                    '            mstr帰省先都道府県 = gfncFieldVal(.Fields("帰省先都道府県").Value)
                    '            mstr帰省先市区郡 = gfncFieldVal(.Fields("帰省先市区郡").Value)
                    '            mstr帰省先町村番地 = gfncFieldVal(.Fields("帰省先町村番地").Value)
                    '            mstr帰省先号棟 = gfncFieldVal(.Fields("帰省先号棟").Value)
                    '            mstr帰省先電話番号 = gfncFieldVal(.Fields("帰省先電話番号").Value)
                    '            mstr帰省先携帯電話番号 = gfncFieldVal(.Fields("帰省先携帯電話番号").Value)
                    '            mstr帰省先メール = gfncFieldVal(.Fields("帰省先メール").Value)
                    '            mstr帰省先携帯メール = gfncFieldVal(.Fields("帰省先携帯メール").Value)
                    '            mstr帰省先氏名 = gfncFieldVal(.Fields("帰省先氏名").Value)
                    '            mstr帰省先続柄 = gfncFieldVal(.Fields("帰省先続柄").Value)
                    '
                    '            mstr身元保証人名漢字 = gfncFieldVal(.Fields("身元保証人名漢字").Value)
                    '            mstr身元保証人名カナ = gfncFieldVal(.Fields("身元保証人名カナ").Value)
                    '            mint身元保証人性別 = CInt(gfncFieldCur(.Fields("身元保証人性別").Value))
                    '            mstr身元保証人生年月日 = gfncFieldVal(.Fields("身元保証人生年月日").Value)
                    '            mstr身元保証人登録日 = gfncFieldVal(.Fields("身元保証人登録日").Value)
                    '            mstr身元保証人職業 = gfncFieldVal(.Fields("身元保証人職業").Value)
                    '            mstr身元保証人続柄 = gfncFieldVal(.Fields("身元保証人続柄").Value)
                    '            mstr身元保証人郵便番号1 = gfncFieldVal(.Fields("身元保証人郵便番号１").Value)
                    '            mstr身元保証人郵便番号2 = gfncFieldVal(.Fields("身元保証人郵便番号２").Value)
                    '            mstr身元保証人都道府県 = gfncFieldVal(.Fields("身元保証人都道府県").Value)
                    '            mstr身元保証人市区郡 = gfncFieldVal(.Fields("身元保証人市区郡").Value)
                    '            mstr身元保証人町村番地 = gfncFieldVal(.Fields("身元保証人町村番地").Value)
                    '            mstr身元保証人号棟 = gfncFieldVal(.Fields("身元保証人号棟").Value)
                    '            mstr身元保証人電話番号 = gfncFieldVal(.Fields("身元保証人電話番号").Value)
                    '            mstr身元保証人携帯電話番号 = gfncFieldVal(.Fields("身元保証人携帯電話番号").Value)
                    '            mstr身元保証人メール = gfncFieldVal(.Fields("身元保証人メール").Value)
                    '            mstr身元保証人携帯メール = gfncFieldVal(.Fields("身元保証人携帯メール").Value)
                    '
                    '            mint趣味有無スポーツ = gfncFieldCur(.Fields("趣味有無スポーツ").Value)
                    '
                    '            For intIdx = MC_MIN_趣味スポーツ To MC_MAX_趣味スポーツ
                    '
                    '                strIdx = Format(intIdx, "00")
                    '
                    '                mastr趣味スポーツ(intIdx) = gfncFieldVal(.Fields("趣味スポーツ" & strIdx).Value)
                    '
                    '            Next intIdx
                    '
                    '            mint趣味有無スポーツ以外 = gfncFieldCur(.Fields("趣味有無スポーツ以外").Value)
                    '
                    '            For intIdx = MC_MIN_趣味スポーツ以外 To MC_MAX_趣味スポーツ以外
                    '
                    '                strIdx = Format(intIdx, "00")
                    '
                    '                mastr趣味スポーツ以外(intIdx) = gfncFieldVal(.Fields("趣味スポーツ以外" & strIdx).Value)
                    '
                    '            Next intIdx
                    '
                    '            mstr備考 = gfncFieldVal(.Fields("備考").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
            'PROC_END:

            'Call gsubClearObject(objDysTemp)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2521f6b6-2163-41c5-ad0f-c094f7d4c8dc
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096
PROC_FINALLY_END:
        Call gsubClearObject(objDysTemp)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9f2c05ac-0164-4aa6-b29f-e3e4817f4096
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function



    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    ' プロパティ
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '******************************************************************************
    ' 関 数 名  : 従業員コード
    ' スコープ  : Public
    ' 処理内容  : 従業員コード 取得
    ' 備    考  :
    ' 返 り 値  : 従業員コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 従業員コード
    ' スコープ  : Public
    ' 処理内容  : 従業員コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 従業員コード() As String
        Get

            従業員コード = mstr従業員コード

        End Get
        Set(ByVal Value As String)

            mstr従業員コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 所属コード
    ' スコープ  : Public
    ' 処理内容  : 所属コード 取得
    ' 備    考  :
    ' 返 り 値  : 所属コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 所属コード
    ' スコープ  : Public
    ' 処理内容  : 所属コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 所属コード() As String
        Get

            所属コード = mstr所属コード

        End Get
        Set(ByVal Value As String)

            mstr所属コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 部署名
    ' スコープ  : Public
    ' 処理内容  : 部署名 取得
    ' 備    考  :
    ' 返 り 値  : 部署名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 部署名
    ' スコープ  : Public
    ' 処理内容  : 部署名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     部署名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 部署名() As String
        Get

            部署名 = mstr部署名

        End Get
        Set(ByVal Value As String)

            mstr部署名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 部署名略称
    ' スコープ  : Public
    ' 処理内容  : 部署名略称 取得
    ' 備    考  :
    ' 返 り 値  : 部署名略称
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/12/20  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 部署名略称
    ' スコープ  : Public
    ' 処理内容  : 部署名略称 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     部署名略称
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/12/20  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 部署名略称() As String
        Get

            部署名略称 = mstr部署名略称

        End Get
        Set(ByVal Value As String)

            mstr部署名略称 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 営業別社員コード
    ' スコープ  : Public
    ' 処理内容  : 営業別社員コード 取得
    ' 備    考  :
    ' 返 り 値  : 営業別社員コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 営業別社員コード
    ' スコープ  : Public
    ' 処理内容  : 営業別社員コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     営業別社員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 営業別社員コード() As String
        Get

            営業別社員コード = mstr営業別社員コード

        End Get
        Set(ByVal Value As String)

            mstr営業別社員コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 勤務区分
    ' スコープ  : Public
    ' 処理内容  : 勤務区分 取得
    ' 備    考  :
    ' 返 り 値  : 勤務区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 勤務区分
    ' スコープ  : Public
    ' 処理内容  : 勤務区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     勤務区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 勤務区分() As Short
        Get

            勤務区分 = mint勤務区分

        End Get
        Set(ByVal Value As Short)

            mint勤務区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 勤務区分名
    ' スコープ  : Public
    ' 処理内容  : 勤務区分名 取得
    ' 備    考  :
    ' 返 り 値  : 勤務区分名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 勤務区分名
    ' スコープ  : Public
    ' 処理内容  : 勤務区分名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     勤務区分名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 勤務区分名() As String
        Get

            勤務区分名 = mstr勤務区分名

        End Get
        Set(ByVal Value As String)

            mstr勤務区分名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 役職位コード
    ' スコープ  : Public
    ' 処理内容  : 役職位コード 取得
    ' 備    考  :
    ' 返 り 値  : 役職位コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 役職位コード
    ' スコープ  : Public
    ' 処理内容  : 役職位コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     役職位コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 役職位コード() As Short
        Get

            役職位コード = mint役職位コード

        End Get
        Set(ByVal Value As Short)

            mint役職位コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 資格コード
    ' スコープ  : Public
    ' 処理内容  : 資格コード  取得
    ' 備    考  :
    ' 返 り 値  : 資格コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 資格コード
    ' スコープ  : Public
    ' 処理内容  : 資格コード  設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     資格コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 資格コード() As Short
        Get

            資格コード = mint資格コード

        End Get
        Set(ByVal Value As Short)

            mint資格コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 性別
    ' スコープ  : Public
    ' 処理内容  : 性別 取得
    ' 備    考  :
    ' 返 り 値  : 性別
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 性別
    ' スコープ  : Public
    ' 処理内容  : 性別 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     性別
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 性別() As Short
        Get

            性別 = mint性別

        End Get
        Set(ByVal Value As Short)

            mint性別 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 血液型
    ' スコープ  : Public
    ' 処理内容  : 血液型 取得
    ' 備    考  :
    ' 返 り 値  : 血液型
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 血液型
    ' スコープ  : Public
    ' 処理内容  : 血液型 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     血液型
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 血液型() As Short
        Get

            血液型 = mint血液型

        End Get
        Set(ByVal Value As Short)

            mint血液型 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 従業員名漢字
    ' スコープ  : Public
    ' 処理内容  : 従業員名漢字 取得
    ' 備    考  :
    ' 返 り 値  : 従業員名漢字
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 従業員名漢字
    ' スコープ  : Public
    ' 処理内容  : 従業員名漢字 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     従業員名漢字
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 従業員名漢字() As String
        Get

            従業員名漢字 = mstr従業員名漢字

        End Get
        Set(ByVal Value As String)

            mstr従業員名漢字 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 従業員名カナ
    ' スコープ  : Public
    ' 処理内容  : 従業員名カナ 取得
    ' 備    考  :
    ' 返 り 値  : 従業員名カナ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 従業員名カナ
    ' スコープ  : Public
    ' 処理内容  : 従業員名カナ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     従業員名カナ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 従業員名カナ() As String
        Get

            従業員名カナ = mstr従業員名カナ

        End Get
        Set(ByVal Value As String)

            mstr従業員名カナ = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 京都在住開始年月
    ' スコープ  : Public
    ' 処理内容  : 京都在住開始年月 取得
    ' 備    考  :
    ' 返 り 値  : 京都在住開始年月
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 京都在住開始年月
    ' スコープ  : Public
    ' 処理内容  : 京都在住開始年月 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     京都在住開始年月
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 京都在住開始年月() As String
        Get

            京都在住開始年月 = mstr京都在住開始年月

        End Get
        Set(ByVal Value As String)

            mstr京都在住開始年月 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 郵便番号1
    ' スコープ  : Public
    ' 処理内容  : 郵便番号1 取得
    ' 備    考  :
    ' 返 り 値  : 郵便番号1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 郵便番号1
    ' スコープ  : Public
    ' 処理内容  : 郵便番号1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     郵便番号1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 郵便番号1() As String
        Get

            郵便番号1 = mstr郵便番号1

        End Get
        Set(ByVal Value As String)

            mstr郵便番号1 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 郵便番号2
    ' スコープ  : Public
    ' 処理内容  : 郵便番号2 取得
    ' 備    考  :
    ' 返 り 値  : 郵便番号2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 郵便番号2
    ' スコープ  : Public
    ' 処理内容  : 郵便番号2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     郵便番号2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 郵便番号2() As String
        Get

            郵便番号2 = mstr郵便番号2

        End Get
        Set(ByVal Value As String)

            mstr郵便番号2 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 都道府県
    ' スコープ  : Public
    ' 処理内容  : 都道府県 取得
    ' 備    考  :
    ' 返 り 値  : 都道府県
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 都道府県
    ' スコープ  : Public
    ' 処理内容  : 都道府県 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     都道府県
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 都道府県() As String
        Get

            都道府県 = mstr都道府県

        End Get
        Set(ByVal Value As String)

            mstr都道府県 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 市区郡
    ' スコープ  : Public
    ' 処理内容  : 市区郡 取得
    ' 備    考  :
    ' 返 り 値  : 市区郡
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 市区郡
    ' スコープ  : Public
    ' 処理内容  : 市区郡 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     市区郡
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 市区郡() As String
        Get

            市区郡 = mstr市区郡

        End Get
        Set(ByVal Value As String)

            mstr市区郡 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 町村番地
    ' スコープ  : Public
    ' 処理内容  : 町村番地 取得
    ' 備    考  :
    ' 返 り 値  : 町村番地
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 町村番地
    ' スコープ  : Public
    ' 処理内容  : 町村番地 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     町村番地
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 町村番地() As String
        Get

            町村番地 = mstr町村番地

        End Get
        Set(ByVal Value As String)

            mstr町村番地 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 号棟
    ' スコープ  : Public
    ' 処理内容  : 号棟 取得
    ' 備    考  :
    ' 返 り 値  : 号棟
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 号棟
    ' スコープ  : Public
    ' 処理内容  : 号棟 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     号棟
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 号棟() As String
        Get

            号棟 = mstr号棟

        End Get
        Set(ByVal Value As String)

            mstr号棟 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 電話番号
    ' スコープ  : Public
    ' 処理内容  : 電話番号 取得
    ' 備    考  :
    ' 返 り 値  : 電話番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 電話番号
    ' スコープ  : Public
    ' 処理内容  : 電話番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     電話番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 電話番号() As String
        Get

            電話番号 = mstr電話番号

        End Get
        Set(ByVal Value As String)

            mstr電話番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 携帯電話番号
    ' スコープ  : Public
    ' 処理内容  : 携帯電話番号 取得
    ' 備    考  :
    ' 返 り 値  : 携帯電話番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 携帯電話番号
    ' スコープ  : Public
    ' 処理内容  : 携帯電話番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     携帯電話番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 携帯電話番号() As String
        Get

            携帯電話番号 = mstr携帯電話番号

        End Get
        Set(ByVal Value As String)

            mstr携帯電話番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : メール
    ' スコープ  : Public
    ' 処理内容  : メール 取得
    ' 備    考  :
    ' 返 り 値  : メール
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : メール
    ' スコープ  : Public
    ' 処理内容  : メール 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     メール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property メール() As String
        Get

            メール = mstrメール

        End Get
        Set(ByVal Value As String)

            mstrメール = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 携帯メール
    ' スコープ  : Public
    ' 処理内容  : 携帯メール 取得
    ' 備    考  :
    ' 返 り 値  : 携帯メール
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 携帯メール
    ' スコープ  : Public
    ' 処理内容  : 携帯メール 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     携帯メール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 携帯メール() As String
        Get

            携帯メール = mstr携帯メール

        End Get
        Set(ByVal Value As String)

            mstr携帯メール = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 家賃先取番号
    ' スコープ  : Public
    ' 処理内容  : 家賃先取番号 取得
    ' 備    考  :
    ' 返 り 値  : 家賃先取番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 家賃先取番号
    ' スコープ  : Public
    ' 処理内容  : 家賃先取番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     家賃先取番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 家賃先取番号() As Short
        Get

            家賃先取番号 = mint家賃先取番号

        End Get
        Set(ByVal Value As Short)

            mint家賃先取番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社予定年月日
    ' スコープ  : Public
    ' 処理内容  : 入社予定年月日 取得
    ' 備    考  :
    ' 返 り 値  : 入社予定年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社予定年月日
    ' スコープ  : Public
    ' 処理内容  : 入社予定年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社予定年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社予定年月日() As String
        Get

            入社予定年月日 = mstr入社予定年月日

        End Get
        Set(ByVal Value As String)

            mstr入社予定年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月日
    ' スコープ  : Public
    ' 処理内容  : 入社年月日 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月日
    ' スコープ  : Public
    ' 処理内容  : 入社年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月日() As String
        Get

            入社年月日 = mstr入社年月日

        End Get
        Set(ByVal Value As String)

            mstr入社年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最新異動年月日
    ' スコープ  : Public
    ' 処理内容  : 最新異動年月日 取得
    ' 備    考  :
    ' 返 り 値  : 最新異動年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最新異動年月日
    ' スコープ  : Public
    ' 処理内容  : 最新異動年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     最新異動年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最新異動年月日() As String
        Get

            最新異動年月日 = mstr最新異動年月日

        End Get
        Set(ByVal Value As String)

            mstr最新異動年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最新出向年月日
    ' スコープ  : Public
    ' 処理内容  : 最新出向年月日 取得
    ' 備    考  :
    ' 返 り 値  : 最新出向年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最新出向年月日
    ' スコープ  : Public
    ' 処理内容  : 最新出向年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     最新出向年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最新出向年月日() As String
        Get

            最新出向年月日 = mstr最新出向年月日

        End Get
        Set(ByVal Value As String)

            mstr最新出向年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 出向先所属コード
    ' スコープ  : Public
    ' 処理内容  : 出向先所属コード 取得
    ' 備    考  :
    ' 返 り 値  : 出向先所属コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 出向先所属コード
    ' スコープ  : Public
    ' 処理内容  : 出向先所属コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     出向先所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 出向先所属コード() As String
        Get

            出向先所属コード = mstr出向先所属コード

        End Get
        Set(ByVal Value As String)

            mstr出向先所属コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退社予定日
    ' スコープ  : Public
    ' 処理内容  : 退社予定日 取得
    ' 備    考  :
    ' 返 り 値  : 退社予定日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退社予定日
    ' スコープ  : Public
    ' 処理内容  : 退社予定日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退社予定日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退社予定日() As String
        Get

            退社予定日 = mstr退社予定日

        End Get
        Set(ByVal Value As String)

            mstr退社予定日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退社年月日
    ' スコープ  : Public
    ' 処理内容  : 退社年月日 取得
    ' 備    考  :
    ' 返 り 値  : 退社年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退社年月日
    ' スコープ  : Public
    ' 処理内容  : 退社年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退社年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退社年月日() As String
        Get

            退社年月日 = mstr退社年月日

        End Get
        Set(ByVal Value As String)

            mstr退社年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職コード
    ' スコープ  : Public
    ' 処理内容  : 退職コード 取得
    ' 備    考  :
    ' 返 り 値  : 退職コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職コード
    ' スコープ  : Public
    ' 処理内容  : 退職コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職コード() As String
        Get

            退職コード = mstr退職コード

        End Get
        Set(ByVal Value As String)

            mstr退職コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 長欠区分
    ' スコープ  : Public
    ' 処理内容  : 長欠区分 取得
    ' 備    考  :
    ' 返 り 値  : 長欠区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 長欠区分
    ' スコープ  : Public
    ' 処理内容  : 長欠区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     長欠区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 長欠区分() As Short
        Get

            長欠区分 = mint長欠区分

        End Get
        Set(ByVal Value As Short)

            mint長欠区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 長欠勤怠コード
    ' スコープ  : Public
    ' 処理内容  : 長欠勤怠コード 取得
    ' 備    考  :
    ' 返 り 値  : 長欠勤怠コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 長欠勤怠コード
    ' スコープ  : Public
    ' 処理内容  : 長欠勤怠コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     長欠勤怠コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 長欠勤怠コード() As String
        Get

            長欠勤怠コード = mstr長欠勤怠コード

        End Get
        Set(ByVal Value As String)

            mstr長欠勤怠コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 休務開始日
    ' スコープ  : Public
    ' 処理内容  : 休務開始日 取得
    ' 備    考  :
    ' 返 り 値  : 休務開始日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 休務開始日
    ' スコープ  : Public
    ' 処理内容  : 休務開始日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     休務開始日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 休務開始日() As String
        Get

            休務開始日 = mstr休務開始日

        End Get
        Set(ByVal Value As String)

            mstr休務開始日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 復帰予定日
    ' スコープ  : Public
    ' 処理内容  : 復帰予定日 取得
    ' 備    考  :
    ' 返 り 値  : 復帰予定日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 復帰予定日
    ' スコープ  : Public
    ' 処理内容  : 復帰予定日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     復帰予定日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 復帰予定日() As String
        Get

            復帰予定日 = mstr復帰予定日

        End Get
        Set(ByVal Value As String)

            mstr復帰予定日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 復帰年月日
    ' スコープ  : Public
    ' 処理内容  : 復帰年月日 取得
    ' 備    考  :
    ' 返 り 値  : 復帰年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 復帰年月日
    ' スコープ  : Public
    ' 処理内容  : 復帰年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     復帰年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 復帰年月日() As String
        Get

            復帰年月日 = mstr復帰年月日

        End Get
        Set(ByVal Value As String)

            mstr復帰年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : マイカー通勤区分
    ' スコープ  : Public
    ' 処理内容  : マイカー通勤区分 取得
    ' 備    考  :
    ' 返 り 値  : マイカー通勤区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : マイカー通勤区分
    ' スコープ  : Public
    ' 処理内容  : マイカー通勤区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     マイカー通勤区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property マイカー通勤区分() As Short
        Get

            マイカー通勤区分 = mintマイカー通勤区分

        End Get
        Set(ByVal Value As Short)

            mintマイカー通勤区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 健康保険番号
    ' スコープ  : Public
    ' 処理内容  : 健康保険番号 取得
    ' 備    考  :
    ' 返 り 値  : 健康保険番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 健康保険番号
    ' スコープ  : Public
    ' 処理内容  : 健康保険番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     健康保険番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 健康保険番号() As String
        Get

            健康保険番号 = mstr健康保険番号

        End Get
        Set(ByVal Value As String)

            mstr健康保険番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 厚生年金番号
    ' スコープ  : Public
    ' 処理内容  : 厚生年金番号 取得
    ' 備    考  :
    ' 返 り 値  : 厚生年金番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 厚生年金番号
    ' スコープ  : Public
    ' 処理内容  : 厚生年金番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     厚生年金番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 厚生年金番号() As String
        Get

            厚生年金番号 = mstr厚生年金番号

        End Get
        Set(ByVal Value As String)

            mstr厚生年金番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 雇用保険番号
    ' スコープ  : Public
    ' 処理内容  : 雇用保険番号 取得
    ' 備    考  :
    ' 返 り 値  : 雇用保険番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 雇用保険番号
    ' スコープ  : Public
    ' 処理内容  : 雇用保険番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     雇用保険番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 雇用保険番号() As String
        Get

            雇用保険番号 = mstr雇用保険番号

        End Get
        Set(ByVal Value As String)

            mstr雇用保険番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 雇用保険徴収有無
    ' スコープ  : Public
    ' 処理内容  : 雇用保険徴収有無 取得
    ' 備    考  :
    ' 返 り 値  : 雇用保険徴収有無
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 雇用保険徴収有無
    ' スコープ  : Public
    ' 処理内容  : 雇用保険徴収有無 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     雇用保険徴収有無
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 雇用保険徴収有無() As Short
        Get

            雇用保険徴収有無 = mint雇用保険徴収有無

        End Get
        Set(ByVal Value As Short)

            mint雇用保険徴収有無 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 税区分
    ' スコープ  : Public
    ' 処理内容  : 税区分 取得
    ' 備    考  :
    ' 返 り 値  : 税区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 税区分
    ' スコープ  : Public
    ' 処理内容  : 税区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     税区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 税区分() As Short
        Get

            税区分 = mint税区分

        End Get
        Set(ByVal Value As Short)

            mint税区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 充員会社コード
    ' スコープ  : Public
    ' 処理内容  : 充員会社コード 取得
    ' 備    考  :
    ' 返 り 値  : 充員会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 充員会社コード
    ' スコープ  : Public
    ' 処理内容  : 充員会社コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     充員会社コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 充員会社コード() As String
        Get

            充員会社コード = mstr充員会社コード

        End Get
        Set(ByVal Value As String)

            mstr充員会社コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 充員会社名
    ' スコープ  : Public
    ' 処理内容  : 充員会社名 取得
    ' 備    考  :
    ' 返 り 値  : 充員会社名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 充員会社名
    ' スコープ  : Public
    ' 処理内容  : 充員会社名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     充員会社名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 充員会社名() As String
        Get

            充員会社名 = mstr充員会社名

        End Get
        Set(ByVal Value As String)

            mstr充員会社名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 充員部署名
    ' スコープ  : Public
    ' 処理内容  : 充員部署名 取得
    ' 備    考  :
    ' 返 り 値  : 充員部署名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 充員部署名
    ' スコープ  : Public
    ' 処理内容  : 充員部署名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     充員部署名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 充員部署名() As String
        Get

            充員部署名 = mstr充員部署名

        End Get
        Set(ByVal Value As String)

            mstr充員部署名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習時会社コード
    ' スコープ  : Public
    ' 処理内容  : 教習時会社コード 取得
    ' 備    考  :
    ' 返 り 値  : 教習時会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習時会社コード
    ' スコープ  : Public
    ' 処理内容  : 教習時会社コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習時会社コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習時会社コード() As String
        Get

            教習時会社コード = mstr教習時会社コード

        End Get
        Set(ByVal Value As String)

            mstr教習時会社コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習時会社名
    ' スコープ  : Public
    ' 処理内容  : 教習時会社名 取得
    ' 備    考  :
    ' 返 り 値  : 教習時会社名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習時会社名
    ' スコープ  : Public
    ' 処理内容  : 教習時会社名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習時会社名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習時会社名() As String
        Get

            教習時会社名 = mstr教習時会社名

        End Get
        Set(ByVal Value As String)

            mstr教習時会社名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習時所属コード
    ' スコープ  : Public
    ' 処理内容  : 教習時所属コード 取得
    ' 備    考  :
    ' 返 り 値  : 教習時所属コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習時所属コード
    ' スコープ  : Public
    ' 処理内容  : 教習時所属コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習時所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習時所属コード() As String
        Get

            教習時所属コード = mstr教習時所属コード

        End Get
        Set(ByVal Value As String)

            mstr教習時所属コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習時部署名
    ' スコープ  : Public
    ' 処理内容  : 教習時部署名 取得
    ' 備    考  :
    ' 返 り 値  : 教習時部署名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習時部署名
    ' スコープ  : Public
    ' 処理内容  : 教習時部署名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習時部署名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.02.00    2010/04/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習時部署名() As String
        Get

            教習時部署名 = mstr教習時部署名

        End Get
        Set(ByVal Value As String)

            mstr教習時部署名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習センター入所予定日
    ' スコープ  : Public
    ' 処理内容  : 教習センター入所予定日 取得
    ' 備    考  :
    ' 返 り 値  : 教習センター入所予定日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習センター入所予定日
    ' スコープ  : Public
    ' 処理内容  : 教習センター入所予定日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習センター入所予定日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習センター入所予定日() As String
        Get

            教習センター入所予定日 = mstr教習センター入所予定日

        End Get
        Set(ByVal Value As String)

            mstr教習センター入所予定日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習センター入所日
    ' スコープ  : Public
    ' 処理内容  : 教習センター入所日 取得
    ' 備    考  :
    ' 返 り 値  : 教習センター入所日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習センター入所日
    ' スコープ  : Public
    ' 処理内容  : 教習センター入所日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習センター入所日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習センター入所日() As String
        Get

            教習センター入所日 = mstr教習センター入所日

        End Get
        Set(ByVal Value As String)

            mstr教習センター入所日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習区分
    ' スコープ  : Public
    ' 処理内容  : 教習区分 取得
    ' 備    考  :
    ' 返 り 値  : 教習区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習区分
    ' スコープ  : Public
    ' 処理内容  : 教習区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     教習区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習区分() As Short
        Get

            教習区分 = mint教習区分

        End Get
        Set(ByVal Value As Short)

            mint教習区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 選任日付
    ' スコープ  : Public
    ' 処理内容  : 選任日付 取得
    ' 備    考  :
    ' 返 り 値  : 選任日付
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 選任日付
    ' スコープ  : Public
    ' 処理内容  : 選任日付 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     選任日付
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 選任日付() As String
        Get

            選任日付 = mstr選任日付

        End Get
        Set(ByVal Value As String)

            mstr選任日付 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 教習卒業日
    ' スコープ  : Public
    ' 処理内容  : 教習卒業日 取得
    ' 備    考  :
    ' 返 り 値  : 教習卒業日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 教習卒業日
    ' スコープ  : Public
    ' 処理内容  : 教習卒業日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     教習卒業日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 教習卒業日() As String
        Get

            教習卒業日 = mstr教習卒業日

        End Get
        Set(ByVal Value As String)

            mstr教習卒業日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 実動予定年月日
    ' スコープ  : Public
    ' 処理内容  : 実動予定年月日 取得
    ' 備    考  :
    ' 返 り 値  : 実動予定年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 実動予定年月日
    ' スコープ  : Public
    ' 処理内容  : 実動予定年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     実動予定年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 実動予定年月日() As String
        Get

            実動予定年月日 = mstr実動予定年月日

        End Get
        Set(ByVal Value As String)

            mstr実動予定年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 実動年月日
    ' スコープ  : Public
    ' 処理内容  : 実動年月日 取得
    ' 備    考  :
    ' 返 り 値  : 実動年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 実動年月日
    ' スコープ  : Public
    ' 処理内容  : 実動年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     実動年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 実動年月日() As String
        Get

            実動年月日 = mstr実動年月日

        End Get
        Set(ByVal Value As String)

            mstr実動年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : プレートNO
    ' スコープ  : Public
    ' 処理内容  : プレートNO 取得
    ' 備    考  :
    ' 返 り 値  : プレートNO
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : プレートNO
    ' スコープ  : Public
    ' 処理内容  : プレートNO 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     プレートNO
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property プレートNO() As String
        Get

            プレートNO = mstrプレートNO

        End Get
        Set(ByVal Value As String)

            mstrプレートNO = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : ファースト
    ' スコープ  : Public
    ' 処理内容  : ファースト 取得
    ' 備    考  :
    ' 返 り 値  : ファースト
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : ファースト
    ' スコープ  : Public
    ' 処理内容  : ファースト 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     ファースト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property ファースト() As Short
        Get

            ファースト = mintファースト

        End Get
        Set(ByVal Value As Short)

            mintファースト = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : ファースト名
    ' スコープ  : Public
    ' 処理内容  : ファースト名 取得
    ' 備    考  :
    ' 返 り 値  : ファースト名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : ファースト名
    ' スコープ  : Public
    ' 処理内容  : ファースト名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ファースト名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2009/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property ファースト名() As String
        Get

            ファースト名 = mstrファースト名

        End Get
        Set(ByVal Value As String)

            mstrファースト名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 本務代務区分
    ' スコープ  : Public
    ' 処理内容  : 本務代務区分 取得
    ' 備    考  :
    ' 返 り 値  : 本務代務区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 本務代務区分
    ' スコープ  : Public
    ' 処理内容  : 本務代務区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     本務代務区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 本務代務区分() As Short
        Get

            本務代務区分 = mint本務代務区分

        End Get
        Set(ByVal Value As Short)

            mint本務代務区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 本務番号
    ' スコープ  : Public
    ' 処理内容  : 本務番号 取得
    ' 備    考  :
    ' 返 り 値  : 本務番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 本務番号
    ' スコープ  : Public
    ' 処理内容  : 本務番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     本務番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 本務番号() As String
        Get

            本務番号 = mstr本務番号

        End Get
        Set(ByVal Value As String)

            mstr本務番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 本務車輌区分
    ' スコープ  : Public
    ' 処理内容  : 本務車輌区分 取得
    ' 備    考  :
    ' 返 り 値  : 本務車輌区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 本務車輌区分
    ' スコープ  : Public
    ' 処理内容  : 本務車輌区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     本務車輌区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 本務車輌区分() As String
        Get

            本務車輌区分 = mstr本務車輌区分

        End Get
        Set(ByVal Value As String)

            mstr本務車輌区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 本務車輌区分名
    ' スコープ  : Public
    ' 処理内容  : 本務車輌区分名 取得
    ' 備    考  :
    ' 返 り 値  : 本務車輌区分名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2013/01/25  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 本務車輌区分名
    ' スコープ  : Public
    ' 処理内容  : 本務車輌区分名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     本務車輌区分名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2013/01/25  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 本務車輌区分名() As String
        Get

            本務車輌区分名 = mstr本務車輌区分名

        End Get
        Set(ByVal Value As String)

            mstr本務車輌区分名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 本務車種コード
    ' スコープ  : Public
    ' 処理内容  : 本務車種コード 取得
    ' 備    考  :
    ' 返 り 値  : 本務車種コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/01/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 本務車種コード
    ' スコープ  : Public
    ' 処理内容  : 本務車種コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     本務車種コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/01/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 本務車種コード() As String
        Get

            本務車種コード = mstr本務車種コード

        End Get
        Set(ByVal Value As String)

            mstr本務車種コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 所属班
    ' スコープ  : Public
    ' 処理内容  : 所属班 取得
    ' 備    考  :
    ' 返 り 値  : 所属班
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 所属班
    ' スコープ  : Public
    ' 処理内容  : 所属班 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     所属班
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 所属班() As String
        Get

            所属班 = mstr所属班

        End Get
        Set(ByVal Value As String)

            mstr所属班 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 公休グループ
    ' スコープ  : Public
    ' 処理内容  : 公休グループ 取得
    ' 備    考  :
    ' 返 り 値  : 公休グループ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 公休グループ
    ' スコープ  : Public
    ' 処理内容  : 公休グループ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     公休グループ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 公休グループ() As String
        Get

            公休グループ = mstr公休グループ

        End Get
        Set(ByVal Value As String)

            mstr公休グループ = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : シフト区分
    ' スコープ  : Public
    ' 処理内容  : シフト区分 取得
    ' 備    考  :
    ' 返 り 値  : シフト区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : シフト区分
    ' スコープ  : Public
    ' 処理内容  : シフト区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     シフト区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property シフト区分() As String
        Get

            シフト区分 = mstrシフト区分

        End Get
        Set(ByVal Value As String)

            mstrシフト区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : カード枚数
    ' スコープ  : Public
    ' 処理内容  : カード枚数 取得
    ' 備    考  :
    ' 返 り 値  : カード枚数
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : カード枚数
    ' スコープ  : Public
    ' 処理内容  : カード枚数 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcurValue           Currency          I     カード枚数
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property カード枚数() As Decimal
        Get

            カード枚数 = mcurカード枚数

        End Get
        Set(ByVal Value As Decimal)

            mcurカード枚数 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : カードパンチNO
    ' スコープ  : Public
    ' 処理内容  : カードパンチNO 取得
    ' 備    考  :
    ' 返 り 値  : カードパンチNO
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : カードパンチNO
    ' スコープ  : Public
    ' 処理内容  : カードパンチNO 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     カードパンチNO
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property カードパンチNO() As String
        Get

            カードパンチNO = mstrカードパンチNO

        End Get
        Set(ByVal Value As String)

            mstrカードパンチNO = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 班長手当区分
    ' スコープ  : Public
    ' 処理内容  : 班長手当区分 取得
    ' 備    考  :
    ' 返 り 値  : 班長手当区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 班長手当区分
    ' スコープ  : Public
    ' 処理内容  : 班長手当区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     班長手当区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 班長手当区分() As Short
        Get

            班長手当区分 = mint班長手当区分

        End Get
        Set(ByVal Value As Short)

            mint班長手当区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 障害者等級
    ' スコープ  : Public
    ' 処理内容  : 障害者等級 取得
    ' 備    考  :
    ' 返 り 値  : 障害者等級
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 障害者等級
    ' スコープ  : Public
    ' 処理内容  : 障害者等級 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     障害者等級
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 障害者等級() As String
        Get

            障害者等級 = mstr障害者等級

        End Get
        Set(ByVal Value As String)

            mstr障害者等級 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 障害種類
    ' スコープ  : Public
    ' 処理内容  : 障害種類 取得
    ' 備    考  :
    ' 返 り 値  : 障害種類
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 障害種類
    ' スコープ  : Public
    ' 処理内容  : 障害種類 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     障害種類
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 障害種類() As String
        Get

            障害種類 = mstr障害種類

        End Get
        Set(ByVal Value As String)

            mstr障害種類 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 観光ランク
    ' スコープ  : Public
    ' 処理内容  : 観光ランク 取得
    ' 備    考  :
    ' 返 り 値  : 観光ランク
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 観光ランク
    ' スコープ  : Public
    ' 処理内容  : 観光ランク 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     観光ランク
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 観光ランク() As Short
        Get

            観光ランク = mint観光ランク

        End Get
        Set(ByVal Value As Short)

            mint観光ランク = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 観光ランク変更日
    ' スコープ  : Public
    ' 処理内容  : 観光ランク変更日 取得
    ' 備    考  :
    ' 返 り 値  : 観光ランク変更日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 観光ランク変更日
    ' スコープ  : Public
    ' 処理内容  : 観光ランク変更日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     観光ランク変更日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 観光ランク変更日() As String
        Get

            観光ランク変更日 = mstr観光ランク変更日

        End Get
        Set(ByVal Value As String)

            mstr観光ランク変更日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力英語
    ' スコープ  : Public
    ' 処理内容  : 語学能力英語 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力英語
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力英語
    ' スコープ  : Public
    ' 処理内容  : 語学能力英語 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力英語
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力英語() As Short
        Get

            語学能力英語 = mint語学能力英語

        End Get
        Set(ByVal Value As Short)

            mint語学能力英語 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力韓国語
    ' スコープ  : Public
    ' 処理内容  : 語学能力韓国語 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力韓国語
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力韓国語
    ' スコープ  : Public
    ' 処理内容  : 語学能力韓国語 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力韓国語
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力韓国語() As Short
        Get

            語学能力韓国語 = mint語学能力韓国語

        End Get
        Set(ByVal Value As Short)

            mint語学能力韓国語 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力独語
    ' スコープ  : Public
    ' 処理内容  : 語学能力独語 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力独語
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力独語
    ' スコープ  : Public
    ' 処理内容  : 語学能力独語 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力独語
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力独語() As Short
        Get

            語学能力独語 = mint語学能力独語

        End Get
        Set(ByVal Value As Short)

            mint語学能力独語 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力仏語
    ' スコープ  : Public
    ' 処理内容  : 語学能力仏語 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力仏語
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力仏語
    ' スコープ  : Public
    ' 処理内容  : 語学能力仏語 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力仏語
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力仏語() As Short
        Get

            語学能力仏語 = mint語学能力仏語

        End Get
        Set(ByVal Value As Short)

            mint語学能力仏語 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力中国語
    ' スコープ  : Public
    ' 処理内容  : 語学能力中国語 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力中国語
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力中国語
    ' スコープ  : Public
    ' 処理内容  : 語学能力中国語 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力中国語
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力中国語() As Short
        Get

            語学能力中国語 = mint語学能力中国語

        End Get
        Set(ByVal Value As Short)

            mint語学能力中国語 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力その他1
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他1 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力その他1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力その他1
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力その他1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力その他1() As Short
        Get

            語学能力その他1 = maint語学能力その他(1)

        End Get
        Set(ByVal Value As Short)

            maint語学能力その他(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力その他2
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他2 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力その他2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力その他2
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力その他2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力その他2() As Short
        Get

            語学能力その他2 = maint語学能力その他(2)

        End Get
        Set(ByVal Value As Short)

            maint語学能力その他(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力その他3
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他3 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力その他3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力その他3
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力その他3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力その他3() As Short
        Get

            語学能力その他3 = maint語学能力その他(3)

        End Get
        Set(ByVal Value As Short)

            maint語学能力その他(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力その他4
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他4 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力その他4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力その他4
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力その他4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力その他4() As Short
        Get

            語学能力その他4 = maint語学能力その他(4)

        End Get
        Set(ByVal Value As Short)

            maint語学能力その他(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 語学能力その他5
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他5 取得
    ' 備    考  :
    ' 返 り 値  : 語学能力その他5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 語学能力その他5
    ' スコープ  : Public
    ' 処理内容  : 語学能力その他5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     語学能力その他5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 語学能力その他5() As Short
        Get

            語学能力その他5 = maint語学能力その他(5)

        End Get
        Set(ByVal Value As Short)

            maint語学能力その他(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 生年月日
    ' スコープ  : Public
    ' 処理内容  : 生年月日 取得
    ' 備    考  :
    ' 返 り 値  : 生年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 生年月日
    ' スコープ  : Public
    ' 処理内容  : 生年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     生年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 生年月日() As String
        Get

            生年月日 = mstr生年月日

        End Get
        Set(ByVal Value As String)

            mstr生年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 前回健診年月度
    ' スコープ  : Public
    ' 処理内容  : 前回健診年月度 取得
    ' 備    考  :
    ' 返 り 値  : 前回健診年月度
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 前回健診年月度
    ' スコープ  : Public
    ' 処理内容  : 前回健診年月度 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     前回健診年月度
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 前回健診年月度() As String
        Get

            前回健診年月度 = mstr前回健診年月度

        End Get
        Set(ByVal Value As String)

            mstr前回健診年月度 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始1
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始1 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始1
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始1() As String
        Get

            病歴年月開始1 = mastr病歴年月開始(1)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始2
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始2 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始2
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始2() As String
        Get

            病歴年月開始2 = mastr病歴年月開始(2)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始3
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始3 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始3
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始3() As String
        Get

            病歴年月開始3 = mastr病歴年月開始(3)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始4
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始4 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始4
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始4() As String
        Get

            病歴年月開始4 = mastr病歴年月開始(4)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始5
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始5 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始5
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始5() As String
        Get

            病歴年月開始5 = mastr病歴年月開始(5)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始6
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始6 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始6
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始6() As String
        Get

            病歴年月開始6 = mastr病歴年月開始(6)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始7
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始7 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始7
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始7() As String
        Get

            病歴年月開始7 = mastr病歴年月開始(7)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始8
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始8 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始8
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始8() As String
        Get

            病歴年月開始8 = mastr病歴年月開始(8)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始9
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始9 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始9
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始9() As String
        Get

            病歴年月開始9 = mastr病歴年月開始(9)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始10
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始10 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月開始10
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月開始10
    ' スコープ  : Public
    ' 処理内容  : 病歴年月開始10 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月開始10
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月開始10() As String
        Get

            病歴年月開始10 = mastr病歴年月開始(10)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月開始(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了1
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了1 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了1
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了1() As String
        Get

            病歴年月終了1 = mastr病歴年月終了(1)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了2
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了2 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了2
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了2() As String
        Get

            病歴年月終了2 = mastr病歴年月終了(2)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了3
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了3 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了3
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了3() As String
        Get

            病歴年月終了3 = mastr病歴年月終了(3)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了4
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了4 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了4
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了4() As String
        Get

            病歴年月終了4 = mastr病歴年月終了(4)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了5
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了5 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了5
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了5() As String
        Get

            病歴年月終了5 = mastr病歴年月終了(5)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了6
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了6 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了6
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了6() As String
        Get

            病歴年月終了6 = mastr病歴年月終了(6)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了7
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了7 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了7
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了7() As String
        Get

            病歴年月終了7 = mastr病歴年月終了(7)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了8
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了8 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了8
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了8() As String
        Get

            病歴年月終了8 = mastr病歴年月終了(8)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了9
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了9 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了9
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了9() As String
        Get

            病歴年月終了9 = mastr病歴年月終了(9)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了10
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了10 取得
    ' 備    考  :
    ' 返 り 値  : 病歴年月終了10
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴年月終了10
    ' スコープ  : Public
    ' 処理内容  : 病歴年月終了10 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴年月終了10
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2012/05/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴年月終了10() As String
        Get

            病歴年月終了10 = mastr病歴年月終了(10)

        End Get
        Set(ByVal Value As String)

            mastr病歴年月終了(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴1
    ' スコープ  : Public
    ' 処理内容  : 病歴1 取得
    ' 備    考  :
    ' 返 り 値  : 病歴1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴1
    ' スコープ  : Public
    ' 処理内容  : 病歴1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴1() As String
        Get

            病歴1 = mastr病歴(1)

        End Get
        Set(ByVal Value As String)

            mastr病歴(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴2
    ' スコープ  : Public
    ' 処理内容  : 病歴2 取得
    ' 備    考  :
    ' 返 り 値  : 病歴2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴2
    ' スコープ  : Public
    ' 処理内容  : 病歴2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴2() As String
        Get

            病歴2 = mastr病歴(2)

        End Get
        Set(ByVal Value As String)

            mastr病歴(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴3
    ' スコープ  : Public
    ' 処理内容  : 病歴3 取得
    ' 備    考  :
    ' 返 り 値  : 病歴3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴3
    ' スコープ  : Public
    ' 処理内容  : 病歴3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴3() As String
        Get

            病歴3 = mastr病歴(3)

        End Get
        Set(ByVal Value As String)

            mastr病歴(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴4
    ' スコープ  : Public
    ' 処理内容  : 病歴4 取得
    ' 備    考  :
    ' 返 り 値  : 病歴4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴4
    ' スコープ  : Public
    ' 処理内容  : 病歴4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴4() As String
        Get

            病歴4 = mastr病歴(4)

        End Get
        Set(ByVal Value As String)

            mastr病歴(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴5
    ' スコープ  : Public
    ' 処理内容  : 病歴5 取得
    ' 備    考  :
    ' 返 り 値  : 病歴5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴5
    ' スコープ  : Public
    ' 処理内容  : 病歴5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴5() As String
        Get

            病歴5 = mastr病歴(5)

        End Get
        Set(ByVal Value As String)

            mastr病歴(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴6
    ' スコープ  : Public
    ' 処理内容  : 病歴6 取得
    ' 備    考  :
    ' 返 り 値  : 病歴6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴6
    ' スコープ  : Public
    ' 処理内容  : 病歴6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴6() As String
        Get

            病歴6 = mastr病歴(6)

        End Get
        Set(ByVal Value As String)

            mastr病歴(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴7
    ' スコープ  : Public
    ' 処理内容  : 病歴7 取得
    ' 備    考  :
    ' 返 り 値  : 病歴7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴7
    ' スコープ  : Public
    ' 処理内容  : 病歴7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴7() As String
        Get

            病歴7 = mastr病歴(7)

        End Get
        Set(ByVal Value As String)

            mastr病歴(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴8
    ' スコープ  : Public
    ' 処理内容  : 病歴8 取得
    ' 備    考  :
    ' 返 り 値  : 病歴8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴8
    ' スコープ  : Public
    ' 処理内容  : 病歴8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴8() As String
        Get

            病歴8 = mastr病歴(8)

        End Get
        Set(ByVal Value As String)

            mastr病歴(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴9
    ' スコープ  : Public
    ' 処理内容  : 病歴9 取得
    ' 備    考  :
    ' 返 り 値  : 病歴9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴9
    ' スコープ  : Public
    ' 処理内容  : 病歴9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴9() As String
        Get

            病歴9 = mastr病歴(9)

        End Get
        Set(ByVal Value As String)

            mastr病歴(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 病歴10
    ' スコープ  : Public
    ' 処理内容  : 病歴10 取得
    ' 備    考  :
    ' 返 り 値  : 病歴10
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 病歴10
    ' スコープ  : Public
    ' 処理内容  : 病歴10 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     病歴10
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 病歴10() As String
        Get

            病歴10 = mastr病歴(10)

        End Get
        Set(ByVal Value As String)

            mastr病歴(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項1
    ' スコープ  : Public
    ' 処理内容  : 特記事項1 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項1
    ' スコープ  : Public
    ' 処理内容  : 特記事項1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項1() As String
        Get

            特記事項1 = mastr特記事項(1)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項2
    ' スコープ  : Public
    ' 処理内容  : 特記事項2 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項2
    ' スコープ  : Public
    ' 処理内容  : 特記事項2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項2() As String
        Get

            特記事項2 = mastr特記事項(2)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項3
    ' スコープ  : Public
    ' 処理内容  : 特記事項3 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項3
    ' スコープ  : Public
    ' 処理内容  : 特記事項3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項3() As String
        Get

            特記事項3 = mastr特記事項(3)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項4
    ' スコープ  : Public
    ' 処理内容  : 特記事項4 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項4
    ' スコープ  : Public
    ' 処理内容  : 特記事項4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項4() As String
        Get

            特記事項4 = mastr特記事項(4)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項5
    ' スコープ  : Public
    ' 処理内容  : 特記事項5 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項5
    ' スコープ  : Public
    ' 処理内容  : 特記事項5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項5() As String
        Get

            特記事項5 = mastr特記事項(5)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項6
    ' スコープ  : Public
    ' 処理内容  : 特記事項6 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項6
    ' スコープ  : Public
    ' 処理内容  : 特記事項6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項6() As String
        Get

            特記事項6 = mastr特記事項(6)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項7
    ' スコープ  : Public
    ' 処理内容  : 特記事項7 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項7
    ' スコープ  : Public
    ' 処理内容  : 特記事項7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項7() As String
        Get

            特記事項7 = mastr特記事項(7)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項8
    ' スコープ  : Public
    ' 処理内容  : 特記事項8 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項8
    ' スコープ  : Public
    ' 処理内容  : 特記事項8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項8() As String
        Get

            特記事項8 = mastr特記事項(8)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項9
    ' スコープ  : Public
    ' 処理内容  : 特記事項9 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項9
    ' スコープ  : Public
    ' 処理内容  : 特記事項9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項9() As String
        Get

            特記事項9 = mastr特記事項(9)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特記事項10
    ' スコープ  : Public
    ' 処理内容  : 特記事項10 取得
    ' 備    考  :
    ' 返 り 値  : 特記事項10
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特記事項10
    ' スコープ  : Public
    ' 処理内容  : 特記事項10 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     特記事項10
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特記事項10() As String
        Get

            特記事項10 = mastr特記事項(10)

        End Get
        Set(ByVal Value As String)

            mastr特記事項(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 削除日
    ' スコープ  : Public
    ' 処理内容  : 削除日 取得
    ' 備    考  :
    ' 返 り 値  : 削除日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 削除日
    ' スコープ  : Public
    ' 処理内容  : 削除日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     削除日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 削除日() As String
        Get

            削除日 = mstr削除日

        End Get
        Set(ByVal Value As String)

            mstr削除日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 乗務員証発行日
    ' スコープ  : Public
    ' 処理内容  : 乗務員証発行日 取得
    ' 備    考  :
    ' 返 り 値  : 乗務員証発行日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 乗務員証発行日
    ' スコープ  : Public
    ' 処理内容  : 乗務員証発行日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     乗務員証発行日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 乗務員証発行日() As String
        Get

            乗務員証発行日 = mstr乗務員証発行日

        End Get
        Set(ByVal Value As String)

            mstr乗務員証発行日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 運転免許更新日
    ' スコープ  : Public
    ' 処理内容  : 運転免許更新日 取得
    ' 備    考  :
    ' 返 り 値  : 運転免許更新日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 運転免許更新日
    ' スコープ  : Public
    ' 処理内容  : 運転免許更新日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     運転免許更新日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 運転免許更新日() As String
        Get

            運転免許更新日 = mstr運転免許更新日

        End Get
        Set(ByVal Value As String)

            mstr運転免許更新日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身分証明書発行日
    ' スコープ  : Public
    ' 処理内容  : 身分証明書発行日 取得
    ' 備    考  :
    ' 返 り 値  : 身分証明書発行日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身分証明書発行日
    ' スコープ  : Public
    ' 処理内容  : 身分証明書発行日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身分証明書発行日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身分証明書発行日() As String
        Get

            身分証明書発行日 = mstr身分証明書発行日

        End Get
        Set(ByVal Value As String)

            mstr身分証明書発行日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入力ランク
    ' スコープ  : Public
    ' 処理内容  : 入力ランク 取得
    ' 備    考  :
    ' 返 り 値  : 入力ランク
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入力ランク
    ' スコープ  : Public
    ' 処理内容  : 入力ランク 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     入力ランク
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入力ランク() As Short
        Get

            入力ランク = mint入力ランク

        End Get
        Set(ByVal Value As Short)

            mint入力ランク = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : パスワード
    ' スコープ  : Public
    ' 処理内容  : パスワード 取得
    ' 備    考  :
    ' 返 り 値  : パスワード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : パスワード
    ' スコープ  : Public
    ' 処理内容  : パスワード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     パスワード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property パスワード() As String
        Get

            パスワード = mstrパスワード

        End Get
        Set(ByVal Value As String)

            mstrパスワード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 本籍地
    ' スコープ  : Public
    ' 処理内容  : 本籍地 取得
    ' 備    考  :
    ' 返 り 値  : 本籍地
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 本籍地
    ' スコープ  : Public
    ' 処理内容  : 本籍地 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     本籍地
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 本籍地() As String
        Get

            本籍地 = mstr本籍地

        End Get
        Set(ByVal Value As String)

            mstr本籍地 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 出身地
    ' スコープ  : Public
    ' 処理内容  : 出身地 取得
    ' 備    考  :
    ' 返 り 値  : 出身地
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 出身地
    ' スコープ  : Public
    ' 処理内容  : 出身地 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     出身地
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 出身地() As String
        Get

            出身地 = mstr出身地

        End Get
        Set(ByVal Value As String)

            mstr出身地 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最終学校名
    ' スコープ  : Public
    ' 処理内容  : 最終学校名 取得
    ' 備    考  :
    ' 返 り 値  : 最終学校名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最終学校名
    ' スコープ  : Public
    ' 処理内容  : 最終学校名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     最終学校名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最終学校名() As String
        Get

            最終学校名 = mstr最終学校名

        End Get
        Set(ByVal Value As String)

            mstr最終学校名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最終学校学部名
    ' スコープ  : Public
    ' 処理内容  : 最終学校学部名 取得
    ' 備    考  :
    ' 返 り 値  : 最終学校学部名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最終学校学部名
    ' スコープ  : Public
    ' 処理内容  : 最終学校学部名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     最終学校学部名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最終学校学部名() As String
        Get

            最終学校学部名 = mstr最終学校学部名

        End Get
        Set(ByVal Value As String)

            mstr最終学校学部名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最終学校学科名
    ' スコープ  : Public
    ' 処理内容  : 最終学校学科名 取得
    ' 備    考  :
    ' 返 り 値  : 最終学校学科名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最終学校学科名
    ' スコープ  : Public
    ' 処理内容  : 最終学校学科名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     最終学校学科名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最終学校学科名() As String
        Get

            最終学校学科名 = mstr最終学校学科名

        End Get
        Set(ByVal Value As String)

            mstr最終学校学科名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最終卒業年度
    ' スコープ  : Public
    ' 処理内容  : 最終卒業年度 取得
    ' 備    考  :
    ' 返 り 値  : 最終卒業年度
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最終卒業年度
    ' スコープ  : Public
    ' 処理内容  : 最終卒業年度 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     最終卒業年度
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最終卒業年度() As String
        Get

            最終卒業年度 = mstr最終卒業年度

        End Get
        Set(ByVal Value As String)

            mstr最終卒業年度 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 最終学校卒業区分
    ' スコープ  : Public
    ' 処理内容  : 最終学校卒業区分 取得
    ' 備    考  :
    ' 返 り 値  : 最終学校卒業区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 最終学校卒業区分
    ' スコープ  : Public
    ' 処理内容  : 最終学校卒業区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     最終学校卒業区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 最終学校卒業区分() As Short
        Get

            最終学校卒業区分 = mint最終学校卒業区分

        End Get
        Set(ByVal Value As Short)

            mint最終学校卒業区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 乗務経験
    ' スコープ  : Public
    ' 処理内容  : 乗務経験 取得
    ' 備    考  :
    ' 返 り 値  : 乗務経験
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 乗務経験
    ' スコープ  : Public
    ' 処理内容  : 乗務経験 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     乗務経験
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 乗務経験() As Short
        Get

            乗務経験 = mint乗務経験

        End Get
        Set(ByVal Value As Short)

            mint乗務経験 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 経験地
    ' スコープ  : Public
    ' 処理内容  : 経験地 取得
    ' 備    考  :
    ' 返 り 値  : 経験地
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 経験地
    ' スコープ  : Public
    ' 処理内容  : 経験地 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     経験地
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 経験地() As String
        Get

            経験地 = mstr経験地

        End Get
        Set(ByVal Value As String)

            mstr経験地 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 経験年
    ' スコープ  : Public
    ' 処理内容  : 経験年 取得
    ' 備    考  :
    ' 返 り 値  : 経験年
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 経験年
    ' スコープ  : Public
    ' 処理内容  : 経験年 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     経験年
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 経験年() As String
        Get

            経験年 = mstr経験年

        End Get
        Set(ByVal Value As String)

            mstr経験年 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 経験月
    ' スコープ  : Public
    ' 処理内容  : 経験月 取得
    ' 備    考  :
    ' 返 り 値  : 経験月
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 経験月
    ' スコープ  : Public
    ' 処理内容  : 経験月 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     経験月
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 経験月() As String
        Get

            経験月 = mstr経験月

        End Get
        Set(ByVal Value As String)

            mstr経験月 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得資格1
    ' スコープ  : Public
    ' 処理内容  : 取得資格1 取得
    ' 備    考  :
    ' 返 り 値  : 取得資格1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得資格1
    ' スコープ  : Public
    ' 処理内容  : 取得資格1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得資格1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得資格1() As String
        Get

            取得資格1 = mastr取得資格(1)

        End Get
        Set(ByVal Value As String)

            mastr取得資格(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得資格2
    ' スコープ  : Public
    ' 処理内容  : 取得資格2 取得
    ' 備    考  :
    ' 返 り 値  : 取得資格2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得資格2
    ' スコープ  : Public
    ' 処理内容  : 取得資格2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得資格2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得資格2() As String
        Get

            取得資格2 = mastr取得資格(2)

        End Get
        Set(ByVal Value As String)

            mastr取得資格(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得資格3
    ' スコープ  : Public
    ' 処理内容  : 取得資格3 取得
    ' 備    考  :
    ' 返 り 値  : 取得資格3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得資格3
    ' スコープ  : Public
    ' 処理内容  : 取得資格3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得資格3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得資格3() As String
        Get

            取得資格3 = mastr取得資格(3)

        End Get
        Set(ByVal Value As String)

            mastr取得資格(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得資格4
    ' スコープ  : Public
    ' 処理内容  : 取得資格4 取得
    ' 備    考  :
    ' 返 り 値  : 取得資格4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得資格4
    ' スコープ  : Public
    ' 処理内容  : 取得資格4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得資格4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得資格4() As String
        Get

            取得資格4 = mastr取得資格(4)

        End Get
        Set(ByVal Value As String)

            mastr取得資格(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得資格5
    ' スコープ  : Public
    ' 処理内容  : 取得資格5 取得
    ' 備    考  :
    ' 返 り 値  : 取得資格5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得資格5
    ' スコープ  : Public
    ' 処理内容  : 取得資格5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得資格5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得資格5() As String
        Get

            取得資格5 = mastr取得資格(5)

        End Get
        Set(ByVal Value As String)

            mastr取得資格(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得年月1
    ' スコープ  : Public
    ' 処理内容  : 取得年月1 取得
    ' 備    考  :
    ' 返 り 値  : 取得年月1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得年月1
    ' スコープ  : Public
    ' 処理内容  : 取得年月1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得年月1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得年月1() As String
        Get

            取得年月1 = mastr取得年月(1)

        End Get
        Set(ByVal Value As String)

            mastr取得年月(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得年月2
    ' スコープ  : Public
    ' 処理内容  : 取得年月2 取得
    ' 備    考  :
    ' 返 り 値  : 取得年月2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得年月2
    ' スコープ  : Public
    ' 処理内容  : 取得年月2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得年月2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得年月2() As String
        Get

            取得年月2 = mastr取得年月(2)

        End Get
        Set(ByVal Value As String)

            mastr取得年月(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得年月3
    ' スコープ  : Public
    ' 処理内容  : 取得年月3 取得
    ' 備    考  :
    ' 返 り 値  : 取得年月3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得年月3
    ' スコープ  : Public
    ' 処理内容  : 取得年月3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得年月3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得年月3() As String
        Get

            取得年月3 = mastr取得年月(3)

        End Get
        Set(ByVal Value As String)

            mastr取得年月(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得年月4
    ' スコープ  : Public
    ' 処理内容  : 取得年月4 取得
    ' 備    考  :
    ' 返 り 値  : 取得年月4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得年月4
    ' スコープ  : Public
    ' 処理内容  : 取得年月4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得年月4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得年月4() As String
        Get

            取得年月4 = mastr取得年月(4)

        End Get
        Set(ByVal Value As String)

            mastr取得年月(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 取得年月5
    ' スコープ  : Public
    ' 処理内容  : 取得年月5 取得
    ' 備    考  :
    ' 返 り 値  : 取得年月5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 取得年月5
    ' スコープ  : Public
    ' 処理内容  : 取得年月5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     取得年月5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 取得年月5() As String
        Get

            取得年月5 = mastr取得年月(5)

        End Get
        Set(ByVal Value As String)

            mastr取得年月(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴1
    ' スコープ  : Public
    ' 処理内容  : 職歴1 取得
    ' 備    考  :
    ' 返 り 値  : 職歴1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴1
    ' スコープ  : Public
    ' 処理内容  : 職歴1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴1() As String
        Get

            職歴1 = mastr職歴(1)

        End Get
        Set(ByVal Value As String)

            mastr職歴(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴2
    ' スコープ  : Public
    ' 処理内容  : 職歴2 取得
    ' 備    考  :
    ' 返 り 値  : 職歴2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴2
    ' スコープ  : Public
    ' 処理内容  : 職歴2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴2() As String
        Get

            職歴2 = mastr職歴(2)

        End Get
        Set(ByVal Value As String)

            mastr職歴(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴3
    ' スコープ  : Public
    ' 処理内容  : 職歴3 取得
    ' 備    考  :
    ' 返 り 値  : 職歴3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴3
    ' スコープ  : Public
    ' 処理内容  : 職歴3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴3() As String
        Get

            職歴3 = mastr職歴(3)

        End Get
        Set(ByVal Value As String)

            mastr職歴(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴4
    ' スコープ  : Public
    ' 処理内容  : 職歴4 取得
    ' 備    考  :
    ' 返 り 値  : 職歴4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴4
    ' スコープ  : Public
    ' 処理内容  : 職歴4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴4() As String
        Get

            職歴4 = mastr職歴(4)

        End Get
        Set(ByVal Value As String)

            mastr職歴(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴5
    ' スコープ  : Public
    ' 処理内容  : 職歴5 取得
    ' 備    考  :
    ' 返 り 値  : 職歴5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴5
    ' スコープ  : Public
    ' 処理内容  : 職歴5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴5() As String
        Get

            職歴5 = mastr職歴(5)

        End Get
        Set(ByVal Value As String)

            mastr職歴(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴6
    ' スコープ  : Public
    ' 処理内容  : 職歴6 取得
    ' 備    考  :
    ' 返 り 値  : 職歴6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴6
    ' スコープ  : Public
    ' 処理内容  : 職歴6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴6() As String
        Get

            職歴6 = mastr職歴(6)

        End Get
        Set(ByVal Value As String)

            mastr職歴(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴7
    ' スコープ  : Public
    ' 処理内容  : 職歴7 取得
    ' 備    考  :
    ' 返 り 値  : 職歴7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴7
    ' スコープ  : Public
    ' 処理内容  : 職歴7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴7() As String
        Get

            職歴7 = mastr職歴(7)

        End Get
        Set(ByVal Value As String)

            mastr職歴(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴8
    ' スコープ  : Public
    ' 処理内容  : 職歴8 取得
    ' 備    考  :
    ' 返 り 値  : 職歴8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴8
    ' スコープ  : Public
    ' 処理内容  : 職歴8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴8() As String
        Get

            職歴8 = mastr職歴(8)

        End Get
        Set(ByVal Value As String)

            mastr職歴(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴9
    ' スコープ  : Public
    ' 処理内容  : 職歴9 取得
    ' 備    考  :
    ' 返 り 値  : 職歴9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴9
    ' スコープ  : Public
    ' 処理内容  : 職歴9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴9() As String
        Get

            職歴9 = mastr職歴(9)

        End Get
        Set(ByVal Value As String)

            mastr職歴(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 職歴１０
    ' スコープ  : Public
    ' 処理内容  : 職歴１０ 取得
    ' 備    考  :
    ' 返 り 値  : 職歴１０
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 職歴１０
    ' スコープ  : Public
    ' 処理内容  : 職歴１０ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     職歴１０
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 職歴10() As String
        Get

            職歴10 = mastr職歴(10)

        End Get
        Set(ByVal Value As String)

            mastr職歴(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月1
    ' スコープ  : Public
    ' 処理内容  : 入社年月1 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月1
    ' スコープ  : Public
    ' 処理内容  : 入社年月1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月1() As String
        Get

            入社年月1 = mastr入社年月(1)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月2
    ' スコープ  : Public
    ' 処理内容  : 入社年月2 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月2
    ' スコープ  : Public
    ' 処理内容  : 入社年月2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月2() As String
        Get

            入社年月2 = mastr入社年月(2)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月3
    ' スコープ  : Public
    ' 処理内容  : 入社年月3 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月3
    ' スコープ  : Public
    ' 処理内容  : 入社年月3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月3() As String
        Get

            入社年月3 = mastr入社年月(3)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月4
    ' スコープ  : Public
    ' 処理内容  : 入社年月4 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月4
    ' スコープ  : Public
    ' 処理内容  : 入社年月4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月4() As String
        Get

            入社年月4 = mastr入社年月(4)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月5
    ' スコープ  : Public
    ' 処理内容  : 入社年月5 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月5
    ' スコープ  : Public
    ' 処理内容  : 入社年月5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月5() As String
        Get

            入社年月5 = mastr入社年月(5)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月6
    ' スコープ  : Public
    ' 処理内容  : 入社年月6 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月6
    ' スコープ  : Public
    ' 処理内容  : 入社年月6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月6() As String
        Get

            入社年月6 = mastr入社年月(6)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月7
    ' スコープ  : Public
    ' 処理内容  : 入社年月7 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月7
    ' スコープ  : Public
    ' 処理内容  : 入社年月7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月7() As String
        Get

            入社年月7 = mastr入社年月(7)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月8
    ' スコープ  : Public
    ' 処理内容  : 入社年月8 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月8
    ' スコープ  : Public
    ' 処理内容  : 入社年月8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月8() As String
        Get

            入社年月8 = mastr入社年月(8)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月9
    ' スコープ  : Public
    ' 処理内容  : 入社年月9 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月9
    ' スコープ  : Public
    ' 処理内容  : 入社年月9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月9() As String
        Get

            入社年月9 = mastr入社年月(9)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社年月１０
    ' スコープ  : Public
    ' 処理内容  : 入社年月１０ 取得
    ' 備    考  :
    ' 返 り 値  : 入社年月１０
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社年月１０
    ' スコープ  : Public
    ' 処理内容  : 入社年月１０ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社年月１０
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社年月10() As String
        Get

            入社年月10 = mastr入社年月(10)

        End Get
        Set(ByVal Value As String)

            mastr入社年月(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月1
    ' スコープ  : Public
    ' 処理内容  : 退職年月1 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月1
    ' スコープ  : Public
    ' 処理内容  : 退職年月1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月1() As String
        Get

            退職年月1 = mastr退職年月(1)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月2
    ' スコープ  : Public
    ' 処理内容  : 退職年月2 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月2
    ' スコープ  : Public
    ' 処理内容  : 退職年月2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月2() As String
        Get

            退職年月2 = mastr退職年月(2)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月3
    ' スコープ  : Public
    ' 処理内容  : 退職年月3 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月3
    ' スコープ  : Public
    ' 処理内容  : 退職年月3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月3() As String
        Get

            退職年月3 = mastr退職年月(3)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月4
    ' スコープ  : Public
    ' 処理内容  : 退職年月4 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月4
    ' スコープ  : Public
    ' 処理内容  : 退職年月4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月4() As String
        Get

            退職年月4 = mastr退職年月(4)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月5
    ' スコープ  : Public
    ' 処理内容  : 退職年月5 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月5
    ' スコープ  : Public
    ' 処理内容  : 退職年月5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月5() As String
        Get

            退職年月5 = mastr退職年月(5)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月6
    ' スコープ  : Public
    ' 処理内容  : 退職年月6 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月6
    ' スコープ  : Public
    ' 処理内容  : 退職年月6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月6() As String
        Get

            退職年月6 = mastr退職年月(6)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月7
    ' スコープ  : Public
    ' 処理内容  : 退職年月7 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月7
    ' スコープ  : Public
    ' 処理内容  : 退職年月7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月7() As String
        Get

            退職年月7 = mastr退職年月(7)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月8
    ' スコープ  : Public
    ' 処理内容  : 退職年月8 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月8
    ' スコープ  : Public
    ' 処理内容  : 退職年月8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月8() As String
        Get

            退職年月8 = mastr退職年月(8)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月9
    ' スコープ  : Public
    ' 処理内容  : 退職年月9 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月9
    ' スコープ  : Public
    ' 処理内容  : 退職年月9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月9() As String
        Get

            退職年月9 = mastr退職年月(9)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退職年月１０
    ' スコープ  : Public
    ' 処理内容  : 退職年月１０ 取得
    ' 備    考  :
    ' 返 り 値  : 退職年月１０
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退職年月１０
    ' スコープ  : Public
    ' 処理内容  : 退職年月１０ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退職年月１０
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退職年月10() As String
        Get

            退職年月10 = mastr退職年月(10)

        End Get
        Set(ByVal Value As String)

            mastr退職年月(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 応募経路
    ' スコープ  : Public
    ' 処理内容  : 応募経路 取得
    ' 備    考  :
    ' 返 り 値  : 応募経路
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 応募経路
    ' スコープ  : Public
    ' 処理内容  : 応募経路 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     応募経路
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 応募経路() As String
        Get

            応募経路 = mstr応募経路

        End Get
        Set(ByVal Value As String)

            mstr応募経路 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 更新従業員コード
    ' スコープ  : Public
    ' 処理内容  : 更新従業員コード 取得
    ' 備    考  :
    ' 返 り 値  : 更新従業員コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 更新従業員コード
    ' スコープ  : Public
    ' 処理内容  : 更新従業員コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     更新従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 更新従業員コード() As String
        Get

            更新従業員コード = mstr更新従業員コード

        End Get
        Set(ByVal Value As String)

            mstr更新従業員コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 更新日付時刻
    ' スコープ  : Public
    ' 処理内容  : 更新日付時刻 取得
    ' 備    考  :
    ' 返 り 値  : 更新日付時刻
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 更新日付時刻
    ' スコープ  : Public
    ' 処理内容  : 更新日付時刻 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pdteValue       Date              I     更新日付時刻
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 更新日付時刻() As Date
        Get

            更新日付時刻 = mdte更新日付時刻

        End Get
        Set(ByVal Value As Date)

            mdte更新日付時刻 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社区分
    ' スコープ  : Public
    ' 処理内容  : 入社区分 取得
    ' 備    考  :
    ' 返 り 値  : 入社区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社区分
    ' スコープ  : Public
    ' 処理内容  : 入社区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     入社区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社区分() As Short
        Get

            入社区分 = mint入社区分

        End Get
        Set(ByVal Value As Short)

            mint入社区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社所属コード
    ' スコープ  : Public
    ' 処理内容  : 入社所属コード 取得
    ' 備    考  :
    ' 返 り 値  : 入社所属コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社所属コード
    ' スコープ  : Public
    ' 処理内容  : 入社所属コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社所属コード() As String
        Get

            入社所属コード = mstr入社所属コード

        End Get
        Set(ByVal Value As String)

            mstr入社所属コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退社所属コード
    ' スコープ  : Public
    ' 処理内容  : 退社所属コード 取得
    ' 備    考  :
    ' 返 り 値  : 退社所属コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退社所属コード
    ' スコープ  : Public
    ' 処理内容  : 退社所属コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退社所属コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退社所属コード() As String
        Get

            退社所属コード = mstr退社所属コード

        End Get
        Set(ByVal Value As String)

            mstr退社所属コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 登録日
    ' スコープ  : Public
    ' 処理内容  : 登録日 取得
    ' 備    考  :
    ' 返 り 値  : 登録日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 登録日
    ' スコープ  : Public
    ' 処理内容  : 登録日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     登録日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 登録日() As String
        Get

            登録日 = mstr登録日

        End Get
        Set(ByVal Value As String)

            mstr登録日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 特別手当区分
    ' スコープ  : Public
    ' 処理内容  : 特別手当区分 取得
    ' 備    考  :
    ' 返 り 値  : 特別手当区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 特別手当区分
    ' スコープ  : Public
    ' 処理内容  : 特別手当区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     特別手当区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 特別手当区分() As Short
        Get

            特別手当区分 = mint特別手当区分

        End Get
        Set(ByVal Value As Short)

            mint特別手当区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : ランク
    ' スコープ  : Public
    ' 処理内容  : ランク 取得
    ' 備    考  :
    ' 返 り 値  : ランク
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : ランク
    ' スコープ  : Public
    ' 処理内容  : ランク 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ランク
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property ランク() As String
        Get

            ランク = mstrランク

        End Get
        Set(ByVal Value As String)

            mstrランク = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社取消日
    ' スコープ  : Public
    ' 処理内容  : 入社取消日 取得
    ' 備    考  :
    ' 返 り 値  : 入社取消日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社取消日
    ' スコープ  : Public
    ' 処理内容  : 入社取消日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社取消日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社取消日() As String
        Get

            入社取消日 = mstr入社取消日

        End Get
        Set(ByVal Value As String)

            mstr入社取消日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 自家用車有無区分
    ' スコープ  : Public
    ' 処理内容  : 自家用車有無区分 取得
    ' 備    考  :
    ' 返 り 値  : 自家用車有無区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 自家用車有無区分
    ' スコープ  : Public
    ' 処理内容  : 自家用車有無区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     自家用車有無区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 自家用車有無区分() As Short
        Get

            自家用車有無区分 = mint自家用車有無区分

        End Get
        Set(ByVal Value As Short)

            mint自家用車有無区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 車輌保険徴収区分
    ' スコープ  : Public
    ' 処理内容  : 車輌保険徴収区分 取得
    ' 備    考  :
    ' 返 り 値  : 車輌保険徴収区分
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 車輌保険徴収区分
    ' スコープ  : Public
    ' 処理内容  : 車輌保険徴収区分 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     車輌保険徴収区分
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 車輌保険徴収区分() As Short
        Get

            車輌保険徴収区分 = mint車輌保険徴収区分

        End Get
        Set(ByVal Value As Short)

            mint車輌保険徴収区分 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : ETC
    ' スコープ  : Public
    ' 処理内容  : ETC 取得
    ' 備    考  :
    ' 返 り 値  : ETC
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : ETC
    ' スコープ  : Public
    ' 処理内容  : ETC 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     ETC
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property ETC() As String
        Get

            ETC = mstrETC

        End Get
        Set(ByVal Value As String)

            mstrETC = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 出社時間昼
    ' スコープ  : Public
    ' 処理内容  : 出社時間昼 取得
    ' 備    考  :
    ' 返 り 値  : 出社時間昼
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 出社時間昼
    ' スコープ  : Public
    ' 処理内容  : 出社時間昼 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     出社時間昼
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 出社時間昼() As String
        Get

            出社時間昼 = mstr出社時間昼

        End Get
        Set(ByVal Value As String)

            mstr出社時間昼 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 出社時間夜
    ' スコープ  : Public
    ' 処理内容  : 出社時間夜 取得
    ' 備    考  :
    ' 返 り 値  : 出社時間夜
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 出社時間夜
    ' スコープ  : Public
    ' 処理内容  : 出社時間夜 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     出社時間夜
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 出社時間夜() As String
        Get

            出社時間夜 = mstr出社時間夜

        End Get
        Set(ByVal Value As String)

            mstr出社時間夜 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 出社時間隔勤
    ' スコープ  : Public
    ' 処理内容  : 出社時間隔勤 取得
    ' 備    考  :
    ' 返 り 値  : 出社時間隔勤
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 出社時間隔勤
    ' スコープ  : Public
    ' 処理内容  : 出社時間隔勤 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     出社時間隔勤
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 出社時間隔勤() As String
        Get

            出社時間隔勤 = mstr出社時間隔勤

        End Get
        Set(ByVal Value As String)

            mstr出社時間隔勤 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 会社コード
    ' スコープ  : Public
    ' 処理内容  : 会社コード 取得
    ' 備    考  :
    ' 返 り 値  : 会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 会社コード
    ' スコープ  : Public
    ' 処理内容  : 会社コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     会社コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 会社コード() As String
        Get

            会社コード = mstr会社コード

        End Get
        Set(ByVal Value As String)

            mstr会社コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 会社名
    ' スコープ  : Public
    ' 処理内容  : 会社名 取得
    ' 備    考  :
    ' 返 り 値  : 会社名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 会社名
    ' スコープ  : Public
    ' 処理内容  : 会社名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     会社名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 会社名() As String
        Get

            会社名 = mstr会社名

        End Get
        Set(ByVal Value As String)

            mstr会社名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 会社名略称
    ' スコープ  : Public
    ' 処理内容  : 会社名略称 取得
    ' 備    考  :
    ' 返 り 値  : 会社名略称
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 会社名略称
    ' スコープ  : Public
    ' 処理内容  : 会社名略称 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     会社名略称
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 会社名略称() As String
        Get

            会社名略称 = mstr会社名略称

        End Get
        Set(ByVal Value As String)

            mstr会社名略称 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 事業所コード
    ' スコープ  : Public
    ' 処理内容  : 事業所コード 取得
    ' 備    考  :
    ' 返 り 値  : 事業所コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 事業所コード
    ' スコープ  : Public
    ' 処理内容  : 事業所コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     事業所コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 事業所コード() As String
        Get

            事業所コード = mstr事業所コード

        End Get
        Set(ByVal Value As String)

            mstr事業所コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 契約期間自
    ' スコープ  : Public
    ' 処理内容  : 契約期間自 取得
    ' 備    考  :
    ' 返 り 値  : 契約期間自
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 契約期間自
    ' スコープ  : Public
    ' 処理内容  : 契約期間自 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     契約期間自
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 契約期間自() As String
        Get

            契約期間自 = mstr契約期間自

        End Get
        Set(ByVal Value As String)

            mstr契約期間自 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 契約期間至
    ' スコープ  : Public
    ' 処理内容  : 契約期間至 取得
    ' 備    考  :
    ' 返 り 値  : 契約期間至
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 契約期間至
    ' スコープ  : Public
    ' 処理内容  : 契約期間至 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     契約期間至
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 契約期間至() As String
        Get

            契約期間至 = mstr契約期間至

        End Get
        Set(ByVal Value As String)

            mstr契約期間至 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 出向先会社コード
    ' スコープ  : Public
    ' 処理内容  : 出向先会社コード 取得
    ' 備    考  :
    ' 返 り 値  : 出向先会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 出向先会社コード
    ' スコープ  : Public
    ' 処理内容  : 出向先会社コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     出向先会社コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 出向先会社コード() As String
        Get

            出向先会社コード = mstr出向先会社コード

        End Get
        Set(ByVal Value As String)

            mstr出向先会社コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 入社会社コード
    ' スコープ  : Public
    ' 処理内容  : 入社会社コード 取得
    ' 備    考  :
    ' 返 り 値  : 入社会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 入社会社コード
    ' スコープ  : Public
    ' 処理内容  : 入社会社コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     入社会社コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 入社会社コード() As String
        Get

            入社会社コード = mstr入社会社コード

        End Get
        Set(ByVal Value As String)

            mstr入社会社コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 退社会社コード
    ' スコープ  : Public
    ' 処理内容  : 退社会社コード 取得
    ' 備    考  :
    ' 返 り 値  : 退社会社コード
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 退社会社コード
    ' スコープ  : Public
    ' 処理内容  : 退社会社コード 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     退社会社コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 退社会社コード() As String
        Get

            退社会社コード = mstr退社会社コード

        End Get
        Set(ByVal Value As String)

            mstr退社会社コード = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 勤次郎部門コード１
    ' スコープ  : Public
    ' 処理内容  : 勤次郎部門コード１ 取得
    ' 備    考  :
    ' 返 り 値  : 勤次郎部門コード１
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 勤次郎部門コード１
    ' スコープ  : Public
    ' 処理内容  : 勤次郎部門コード１ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     勤次郎部門コード１
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 勤次郎部門コード1() As String
        Get

            勤次郎部門コード1 = mstr勤次郎部門コード1

        End Get
        Set(ByVal Value As String)

            mstr勤次郎部門コード1 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 勤次郎部門コード２
    ' スコープ  : Public
    ' 処理内容  : 勤次郎部門コード２ 取得
    ' 備    考  :
    ' 返 り 値  : 勤次郎部門コード２
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 勤次郎部門コード２
    ' スコープ  : Public
    ' 処理内容  : 勤次郎部門コード２ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     勤次郎部門コード２
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 勤次郎部門コード2() As String
        Get

            勤次郎部門コード2 = mstr勤次郎部門コード2

        End Get
        Set(ByVal Value As String)

            mstr勤次郎部門コード2 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 勤次郎部門コード３
    ' スコープ  : Public
    ' 処理内容  : 勤次郎部門コード３ 取得
    ' 備    考  :
    ' 返 り 値  : 勤次郎部門コード３
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 勤次郎部門コード３
    ' スコープ  : Public
    ' 処理内容  : 勤次郎部門コード３ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     勤次郎部門コード３
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 勤次郎部門コード3() As String
        Get

            勤次郎部門コード3 = mstr勤次郎部門コード3

        End Get
        Set(ByVal Value As String)

            mstr勤次郎部門コード3 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 前回更新者名
    ' スコープ  : Public
    ' 処理内容  : 前回更新者名 取得
    ' 備    考  :
    ' 返 り 値  : 前回更新者名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 前回更新者名
    ' スコープ  : Public
    ' 処理内容  : 前回更新者名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     前回更新者名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 前回更新者名() As String
        Get

            前回更新者名 = mstr前回更新者名

        End Get
        Set(ByVal Value As String)

            mstr前回更新者名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 前回更新日時
    ' スコープ  : Public
    ' 処理内容  : 前回更新日時 取得
    ' 備    考  :
    ' 返 り 値  : 前回更新日時
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 前回更新日時
    ' スコープ  : Public
    ' 処理内容  : 前回更新日時 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     前回更新日時
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 前回更新日時() As String
        Get

            前回更新日時 = mstr前回更新日時

        End Get
        Set(ByVal Value As String)

            mstr前回更新日時 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 有給残日数
    ' スコープ  : Public
    ' 処理内容  : 有給残日数 取得
    ' 備    考  :
    ' 返 り 値  : 有給残日数
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/02  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 有給残日数
    ' スコープ  : Public
    ' 処理内容  : 有給残日数 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcurValue           Currency          I     有給残日数
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/02  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 有給残日数() As Decimal
        Get

            有給残日数 = mcur有給残日数

        End Get
        Set(ByVal Value As Decimal)

            mcur有給残日数 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 二種合格日
    ' スコープ  : Public
    ' 処理内容  : 二種合格日 取得
    ' 備    考  :
    ' 返 り 値  : 二種合格日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 二種合格日
    ' スコープ  : Public
    ' 処理内容  : 二種合格日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     二種合格日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 二種合格日() As String
        Get

            二種合格日 = mstr二種合格日

        End Get
        Set(ByVal Value As String)

            mstr二種合格日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 免許種別
    ' スコープ  : Public
    ' 処理内容  : 免許種別 取得
    ' 備    考  :
    ' 返 り 値  : 免許種別
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 免許種別
    ' スコープ  : Public
    ' 処理内容  : 免許種別 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     免許種別
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 免許種別() As String
        Get

            免許種別 = mstr免許種別

        End Get
        Set(ByVal Value As String)

            mstr免許種別 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 会社負担フラグ
    ' スコープ  : Public
    ' 処理内容  : 会社負担フラグ 取得
    ' 備    考  :
    ' 返 り 値  : 会社負担フラグ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/06/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 会社負担フラグ
    ' スコープ  : Public
    ' 処理内容  : 会社負担フラグ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     会社負担フラグ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/06/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 会社負担フラグ() As Short
        Get

            会社負担フラグ = mint会社負担フラグ

        End Get
        Set(ByVal Value As Short)

            mint会社負担フラグ = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 社内個人タクシー対象者
    ' スコープ  : Public
    ' 処理内容  : 社内個人タクシー対象者 取得
    ' 備    考  :
    ' 返 り 値  : 社内個人タクシー対象者
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 社内個人タクシー対象者
    ' スコープ  : Public
    ' 処理内容  : 社内個人タクシー対象者 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     社内個人タクシー対象者
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 社内個人タクシー対象者() As Short
        Get

            社内個人タクシー対象者 = mint社内個人タクシー対象者

        End Get
        Set(ByVal Value As Short)

            mint社内個人タクシー対象者 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 一車三人制対象者
    ' スコープ  : Public
    ' 処理内容  : 一車三人制対象者 取得
    ' 備    考  :
    ' 返 り 値  : 一車三人制対象者
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 一車三人制対象者
    ' スコープ  : Public
    ' 処理内容  : 一車三人制対象者 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     一車三人制対象者
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/03/17  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 一車三人制対象者() As Short
        Get

            一車三人制対象者 = mint一車三人制対象者

        End Get
        Set(ByVal Value As Short)

            mint一車三人制対象者 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先郵便番号１
    ' スコープ  : Public
    ' 処理内容  : 帰省先郵便番号１ 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先郵便番号１
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先郵便番号１
    ' スコープ  : Public
    ' 処理内容  : 帰省先郵便番号１ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先郵便番号１
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先郵便番号1() As String
        Get

            帰省先郵便番号1 = mstr帰省先郵便番号1

        End Get
        Set(ByVal Value As String)

            mstr帰省先郵便番号1 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先郵便番号２
    ' スコープ  : Public
    ' 処理内容  : 帰省先郵便番号２ 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先郵便番号２
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先郵便番号２
    ' スコープ  : Public
    ' 処理内容  : 帰省先郵便番号２ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先郵便番号２
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先郵便番号2() As String
        Get

            帰省先郵便番号2 = mstr帰省先郵便番号2

        End Get
        Set(ByVal Value As String)

            mstr帰省先郵便番号2 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先都道府県
    ' スコープ  : Public
    ' 処理内容  : 帰省先都道府県 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先都道府県
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先都道府県
    ' スコープ  : Public
    ' 処理内容  : 帰省先都道府県 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先都道府県
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先都道府県() As String
        Get

            帰省先都道府県 = mstr帰省先都道府県

        End Get
        Set(ByVal Value As String)

            mstr帰省先都道府県 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先市区郡
    ' スコープ  : Public
    ' 処理内容  : 帰省先市区郡 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先市区郡
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先市区郡
    ' スコープ  : Public
    ' 処理内容  : 帰省先市区郡 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先市区郡
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先市区郡() As String
        Get

            帰省先市区郡 = mstr帰省先市区郡

        End Get
        Set(ByVal Value As String)

            mstr帰省先市区郡 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先町村番地
    ' スコープ  : Public
    ' 処理内容  : 帰省先町村番地 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先町村番地
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先町村番地
    ' スコープ  : Public
    ' 処理内容  : 帰省先町村番地 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先町村番地
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先町村番地() As String
        Get

            帰省先町村番地 = mstr帰省先町村番地

        End Get
        Set(ByVal Value As String)

            mstr帰省先町村番地 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先号棟
    ' スコープ  : Public
    ' 処理内容  : 帰省先号棟 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先号棟
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先号棟
    ' スコープ  : Public
    ' 処理内容  : 帰省先号棟 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先号棟
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先号棟() As String
        Get

            帰省先号棟 = mstr帰省先号棟

        End Get
        Set(ByVal Value As String)

            mstr帰省先号棟 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先電話番号
    ' スコープ  : Public
    ' 処理内容  : 帰省先電話番号 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先電話番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先電話番号
    ' スコープ  : Public
    ' 処理内容  : 帰省先電話番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先電話番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先電話番号() As String
        Get

            帰省先電話番号 = mstr帰省先電話番号

        End Get
        Set(ByVal Value As String)

            mstr帰省先電話番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先携帯電話番号
    ' スコープ  : Public
    ' 処理内容  : 帰省先携帯電話番号 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先携帯電話番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先携帯電話番号
    ' スコープ  : Public
    ' 処理内容  : 帰省先携帯電話番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先携帯電話番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先携帯電話番号() As String
        Get

            帰省先携帯電話番号 = mstr帰省先携帯電話番号

        End Get
        Set(ByVal Value As String)

            mstr帰省先携帯電話番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先メール
    ' スコープ  : Public
    ' 処理内容  : 帰省先メール 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先メール
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先メール
    ' スコープ  : Public
    ' 処理内容  : 帰省先メール 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先メール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先メール() As String
        Get

            帰省先メール = mstr帰省先メール

        End Get
        Set(ByVal Value As String)

            mstr帰省先メール = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先携帯メール
    ' スコープ  : Public
    ' 処理内容  : 帰省先携帯メール 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先携帯メール
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先携帯メール
    ' スコープ  : Public
    ' 処理内容  : 帰省先携帯メール 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先携帯メール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/11  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先携帯メール() As String
        Get

            帰省先携帯メール = mstr帰省先携帯メール

        End Get
        Set(ByVal Value As String)

            mstr帰省先携帯メール = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先氏名
    ' スコープ  : Public
    ' 処理内容  : 帰省先氏名 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先氏名
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先氏名
    ' スコープ  : Public
    ' 処理内容  : 帰省先氏名 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先氏名
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先氏名() As String
        Get

            帰省先氏名 = mstr帰省先氏名

        End Get
        Set(ByVal Value As String)

            mstr帰省先氏名 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 帰省先続柄
    ' スコープ  : Public
    ' 処理内容  : 帰省先続柄 取得
    ' 備    考  :
    ' 返 り 値  : 帰省先続柄
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 帰省先続柄
    ' スコープ  : Public
    ' 処理内容  : 帰省先続柄 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     帰省先続柄
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 帰省先続柄() As String
        Get

            帰省先続柄 = mstr帰省先続柄

        End Get
        Set(ByVal Value As String)

            mstr帰省先続柄 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人名漢字
    ' スコープ  : Public
    ' 処理内容  : 身元保証人名漢字 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人名漢字
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人名漢字
    ' スコープ  : Public
    ' 処理内容  : 身元保証人名漢字 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人名漢字
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人名漢字() As String
        Get

            身元保証人名漢字 = mstr身元保証人名漢字

        End Get
        Set(ByVal Value As String)

            mstr身元保証人名漢字 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人名カナ
    ' スコープ  : Public
    ' 処理内容  : 身元保証人名カナ 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人名カナ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人名カナ
    ' スコープ  : Public
    ' 処理内容  : 身元保証人名カナ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人名カナ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人名カナ() As String
        Get

            身元保証人名カナ = mstr身元保証人名カナ

        End Get
        Set(ByVal Value As String)

            mstr身元保証人名カナ = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人性別
    ' スコープ  : Public
    ' 処理内容  : 身元保証人性別 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人性別
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人性別
    ' スコープ  : Public
    ' 処理内容  : 身元保証人性別 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     身元保証人性別
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人性別() As Short
        Get

            身元保証人性別 = mint身元保証人性別

        End Get
        Set(ByVal Value As Short)

            mint身元保証人性別 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人生年月日
    ' スコープ  : Public
    ' 処理内容  : 身元保証人生年月日 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人生年月日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人生年月日
    ' スコープ  : Public
    ' 処理内容  : 身元保証人生年月日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人生年月日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人生年月日() As String
        Get

            身元保証人生年月日 = mstr身元保証人生年月日

        End Get
        Set(ByVal Value As String)

            mstr身元保証人生年月日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人登録日
    ' スコープ  : Public
    ' 処理内容  : 身元保証人登録日 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人登録日
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人登録日
    ' スコープ  : Public
    ' 処理内容  : 身元保証人登録日 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人登録日
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人登録日() As String
        Get

            身元保証人登録日 = mstr身元保証人登録日

        End Get
        Set(ByVal Value As String)

            mstr身元保証人登録日 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人職業
    ' スコープ  : Public
    ' 処理内容  : 身元保証人職業 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人職業
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人職業
    ' スコープ  : Public
    ' 処理内容  : 身元保証人職業 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人職業
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人職業() As String
        Get

            身元保証人職業 = mstr身元保証人職業

        End Get
        Set(ByVal Value As String)

            mstr身元保証人職業 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人続柄
    ' スコープ  : Public
    ' 処理内容  : 身元保証人続柄 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人続柄
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人続柄
    ' スコープ  : Public
    ' 処理内容  : 身元保証人続柄 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人続柄
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人続柄() As String
        Get

            身元保証人続柄 = mstr身元保証人続柄

        End Get
        Set(ByVal Value As String)

            mstr身元保証人続柄 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人郵便番号１
    ' スコープ  : Public
    ' 処理内容  : 身元保証人郵便番号１ 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人郵便番号１
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人郵便番号１
    ' スコープ  : Public
    ' 処理内容  : 身元保証人郵便番号１ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人郵便番号１
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人郵便番号1() As String
        Get

            身元保証人郵便番号1 = mstr身元保証人郵便番号1

        End Get
        Set(ByVal Value As String)

            mstr身元保証人郵便番号1 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人郵便番号２
    ' スコープ  : Public
    ' 処理内容  : 身元保証人郵便番号２ 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人郵便番号２
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人郵便番号２
    ' スコープ  : Public
    ' 処理内容  : 身元保証人郵便番号２ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人郵便番号２
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人郵便番号2() As String
        Get

            身元保証人郵便番号2 = mstr身元保証人郵便番号2

        End Get
        Set(ByVal Value As String)

            mstr身元保証人郵便番号2 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人都道府県
    ' スコープ  : Public
    ' 処理内容  : 身元保証人都道府県 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人都道府県
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人都道府県
    ' スコープ  : Public
    ' 処理内容  : 身元保証人都道府県 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人都道府県
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人都道府県() As String
        Get

            身元保証人都道府県 = mstr身元保証人都道府県

        End Get
        Set(ByVal Value As String)

            mstr身元保証人都道府県 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人市区郡
    ' スコープ  : Public
    ' 処理内容  : 身元保証人市区郡 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人市区郡
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人市区郡
    ' スコープ  : Public
    ' 処理内容  : 身元保証人市区郡 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人市区郡
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人市区郡() As String
        Get

            身元保証人市区郡 = mstr身元保証人市区郡

        End Get
        Set(ByVal Value As String)

            mstr身元保証人市区郡 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人町村番地
    ' スコープ  : Public
    ' 処理内容  : 身元保証人町村番地 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人町村番地
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人町村番地
    ' スコープ  : Public
    ' 処理内容  : 身元保証人町村番地 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人町村番地
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人町村番地() As String
        Get

            身元保証人町村番地 = mstr身元保証人町村番地

        End Get
        Set(ByVal Value As String)

            mstr身元保証人町村番地 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人号棟
    ' スコープ  : Public
    ' 処理内容  : 身元保証人号棟 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人号棟
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人号棟
    ' スコープ  : Public
    ' 処理内容  : 身元保証人号棟 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人号棟
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人号棟() As String
        Get

            身元保証人号棟 = mstr身元保証人号棟

        End Get
        Set(ByVal Value As String)

            mstr身元保証人号棟 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人電話番号
    ' スコープ  : Public
    ' 処理内容  : 身元保証人電話番号 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人電話番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人電話番号
    ' スコープ  : Public
    ' 処理内容  : 身元保証人電話番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人電話番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2007/11/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人電話番号() As String
        Get

            身元保証人電話番号 = mstr身元保証人電話番号

        End Get
        Set(ByVal Value As String)

            mstr身元保証人電話番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人携帯電話番号
    ' スコープ  : Public
    ' 処理内容  : 身元保証人携帯電話番号 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人携帯電話番号
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人携帯電話番号
    ' スコープ  : Public
    ' 処理内容  : 身元保証人携帯電話番号 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人携帯電話番号
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人携帯電話番号() As String
        Get

            身元保証人携帯電話番号 = mstr身元保証人携帯電話番号

        End Get
        Set(ByVal Value As String)

            mstr身元保証人携帯電話番号 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人メール
    ' スコープ  : Public
    ' 処理内容  : 身元保証人メール 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人メール
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人メール
    ' スコープ  : Public
    ' 処理内容  : 身元保証人メール 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人メール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人メール() As String
        Get

            身元保証人メール = mstr身元保証人メール

        End Get
        Set(ByVal Value As String)

            mstr身元保証人メール = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 身元保証人携帯メール
    ' スコープ  : Public
    ' 処理内容  : 身元保証人携帯メール 取得
    ' 備    考  :
    ' 返 り 値  : 身元保証人携帯メール
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 身元保証人携帯メール
    ' スコープ  : Public
    ' 処理内容  : 身元保証人携帯メール 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     身元保証人携帯メール
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 身元保証人携帯メール() As String
        Get

            身元保証人携帯メール = mstr身元保証人携帯メール

        End Get
        Set(ByVal Value As String)

            mstr身元保証人携帯メール = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味有無スポーツ
    ' スコープ  : Public
    ' 処理内容  : 趣味有無スポーツ 取得
    ' 備    考  :
    ' 返 り 値  : 趣味有無スポーツ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味有無スポーツ
    ' スコープ  : Public
    ' 処理内容  : 趣味有無スポーツ 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     趣味有無スポーツ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味有無スポーツ() As Short
        Get

            趣味有無スポーツ = mint趣味有無スポーツ

        End Get
        Set(ByVal Value As Short)

            mint趣味有無スポーツ = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ1
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ1 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ1
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ1() As String
        Get

            趣味スポーツ1 = mastr趣味スポーツ(1)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ2
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ2 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ2
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ2() As String
        Get

            趣味スポーツ2 = mastr趣味スポーツ(2)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ3
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ3 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ3
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ3() As String
        Get

            趣味スポーツ3 = mastr趣味スポーツ(3)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ4
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ4 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ4
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/14  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ4() As String
        Get

            趣味スポーツ4 = mastr趣味スポーツ(4)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味有無スポーツ以外
    ' スコープ  : Public
    ' 処理内容  : 趣味有無スポーツ以外 取得
    ' 備    考  :
    ' 返 り 値  : 趣味有無スポーツ以外
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味有無スポーツ以外
    ' スコープ  : Public
    ' 処理内容  : 趣味有無スポーツ以外 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pintValue           Integer           I     趣味有無スポーツ以外
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味有無スポーツ以外() As Short
        Get

            趣味有無スポーツ以外 = mint趣味有無スポーツ以外

        End Get
        Set(ByVal Value As Short)

            mint趣味有無スポーツ以外 = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外1
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外1 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外1
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外1
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外1 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外1
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外1() As String
        Get

            趣味スポーツ以外1 = mastr趣味スポーツ以外(1)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(1) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外2
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外2 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外2
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外2
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外2 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外2
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外2() As String
        Get

            趣味スポーツ以外2 = mastr趣味スポーツ以外(2)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(2) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外3
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外3 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外3
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外3
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外3 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外3
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外3() As String
        Get

            趣味スポーツ以外3 = mastr趣味スポーツ以外(3)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(3) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外4
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外4 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外4
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外4
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外4 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外4
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外4() As String
        Get

            趣味スポーツ以外4 = mastr趣味スポーツ以外(4)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(4) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外5
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外5 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外5
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外5
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外5 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外5
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外5() As String
        Get

            趣味スポーツ以外5 = mastr趣味スポーツ以外(5)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(5) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外6
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外6 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外6
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外6
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外6 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外6
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外6() As String
        Get

            趣味スポーツ以外6 = mastr趣味スポーツ以外(6)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(6) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外7
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外7 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外7
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外7
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外7 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外7
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外7() As String
        Get

            趣味スポーツ以外7 = mastr趣味スポーツ以外(7)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(7) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外8
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外8 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外8
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外8
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外8 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外8
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外8() As String
        Get

            趣味スポーツ以外8 = mastr趣味スポーツ以外(8)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(8) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外9
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外9 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外9
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外9
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外9 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外9
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外9() As String
        Get

            趣味スポーツ以外9 = mastr趣味スポーツ以外(9)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(9) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外10
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外10 取得
    ' 備    考  :
    ' 返 り 値  : 趣味スポーツ以外10
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 趣味スポーツ以外10
    ' スコープ  : Public
    ' 処理内容  : 趣味スポーツ以外10 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     趣味スポーツ以外10
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 趣味スポーツ以外10() As String
        Get

            趣味スポーツ以外10 = mastr趣味スポーツ以外(10)

        End Get
        Set(ByVal Value As String)

            mastr趣味スポーツ以外(10) = Value

        End Set
    End Property
    '******************************************************************************
    ' 関 数 名  : 備考
    ' スコープ  : Public
    ' 処理内容  : 備考 取得
    ' 備    考  :
    ' 返 り 値  : 備考
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : 備考
    ' スコープ  : Public
    ' 処理内容  : 備考 設定
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrValue           String            I     備考
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2011/10/13  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Property 備考() As String
        Get

            備考 = mstr備考

        End Get
        Set(ByVal Value As String)

            mstr備考 = Value

        End Set
    End Property
End Class
