Option Strict Off
Option Explicit On
Module basSYNippoushori
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : 車輌管理システム
    ' ファイル名  : basSYNippoushori.bas
    ' 内    容    : 日報確定時に車輌管理の処理を行う
    ' 備    考    : HEB110とALB120から使用される
    ' 関数一覧    : <Public>
    '                   gsubUpdateCarTransfer           (日報確定時の車輌のメイン処理)
    '                   gfncOldChangeDate               (対象部署で勤務予定入力確定処理が終了しているかどうかのチェック処理)
    '               <Private>
    '                   msubUpdate増車                  (営業車輌マスタと車輌マスタの増車処理)
    '                   msubUpdate減車                  (営業車輌マスタと車輌マスタの減車処理)
    '                   msubUpdate代替                  (代替処理のメイン処理)
    '                   msubUpdate代替1                 (営業車輌マスタと車輌マスタの代替処理)
    '                   msubUpdate代替2                 (営業車輌マスタと車輌マスタの代替処理)
    '                   msubUpdate代替3                 (営業車輌マスタと車輌マスタの代替処理)
    '                   msubUpdate代替4                 (営業車輌マスタと車輌マスタの代替処理)
    '                   msubUpdate営業所間              (営業所間移動のメイン処理)
    '                   msubUpdate営業所間1             (営業車輌マスタと車輌マスタの営業所移動処理)
    '                   msubUpdate営業所間2             (営業車輌マスタと車輌マスタの営業所移動処理)
    '                   msubUpdate会社間減車            (営業車輌マスタと車輌マスタの会社間移動減車処理)
    '                   msubUpdate会社間増車            (営業車輌マスタと車輌マスタの会社間移動増車処理)
    '                   msubUpdate社用車切替            (車輌マスタの社用車切替処理)
    '                   msubUpdate廃車                  (車輌マスタの廃車切替処理)
    '                   msubUpdate売却                  (車輌マスタの売却切替処理)
    '                   msubUpdate保留車切替            (車輌マスタの社用車を保留に切替処理)
    '                   msubUpdate保留増車              (営業車輌マスタと車輌マスタの保留増車処理)
    '                   msubUpdateマスタメンテ          (営業車輌マスタと車輌マスタの直接メンテ処理)
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   1.0.0       2009/09/04  ＫＳＲ             新規作成
    '   1.0.2       2009/09/30  ＫＳＲ             共通モジュールファイル名変・メソッド名修正
    '   1.0.3       2009/09/30  ＫＳＲ             代替の更新時に、代替元の車輌に旧車輌番号を更新しておくようにする
    '   1.0.4       2009/10/06  ＫＳＲ             代替で車輌番号が変更された場合に営業車輌の廃車日に切替日を転送する。
    '                                              ※車輌マスタ更新時のみ
    '   1.0.5       2010/03/09  ＫＳＲ             gsubUpdateCarTransferの指示内容区分='11'(保留増車)分の判定方法の不具合対応
    '   1.0.6       2010/03/24  ＫＳＲ             msubUpdate減車に最終無線番号を転送する処理を追加
    '   1.0.7       2010/05/31  ＫＳＲ             本務者履歴テーブルに車輌マスタ反映区分を追加して、夜間処理時にこの区分から車輌マスタに本務者を転送するように変更する
    '   1.0.8       2010/09/24  ＫＳＲ             本務者履歴テーブルから車輌マスタに本務者を反映させる際に、切替日の昇順に処理を行うようにする
    '                           ＫＳＲ             勤務予定入力確定処理が終了しているかどうかのチェック処理の追加
    '******************************************************************************

    '==============================================================================
    ' 変数
    '==============================================================================
    Private Structure 車輌情報
        Dim m車体番号 As String
        Dim m指示内容区分 As String
        Dim m車輌番号地区コード As String
        Dim m車輌番号1 As String
        Dim m車輌番号2 As String
        Dim m車輌番号3 As String
        Dim m車名 As String
        Dim m年式 As String
        Dim mエンジン型式 As String
        Dim m型式 As String
        Dim m区分 As String
        Dim m車輌区分 As String
        Dim m燃料コード As String
        Dim mファースト As String
        Dim m登録年月日 As String
        Dim m車輌本体価格 As String
        Dim m取得税 As String
        Dim mエアコン価格 As String
        Dim m料金メーター価格 As String
        Dim mタコメーター価格 As String
        Dim mその他費用 As String
        Dim m状態区分 As String
        Dim m所属コード As String
        Dim m車輌登録所属コード As String
        Dim m整理番号 As String
        Dim m本務者コード1 As String
        Dim m償却日額1 As String
        Dim m償却利息1 As String
        Dim m償却累計額1 As String
        Dim mAT償却費1 As String
        Dim m償却残日数1 As String
        Dim m本務者コード2 As String
        Dim m償却日額2 As String
        Dim m償却利息2 As String
        Dim m償却累計額2 As String
        Dim mAT償却費2 As String
        Dim m償却残日数2 As String
        Dim m償却満額 As String
        Dim m電話番号 As String
        Dim m無線番号 As String
        Dim m保険会社 As String '// 車輌マスタはコード
        Dim m保険会社名 As String '// 2010/03/26 営業車輌マスタ同一項目で名称でもっているため
        Dim m自動車保険満期日 As String
        Dim m保険申込者名漢字 As String
        Dim m保険申込者名カナ As String
        Dim m保険申込者郵便番号1 As String
        Dim m保険申込者郵便番号2 As String
        Dim m保険申込者都道府県漢字 As String
        Dim m保険申込者市区郡漢字 As String
        Dim m保険申込者町村番地漢字 As String
        Dim m保険申込者号棟漢字 As String
        Dim m保険申込者都道府県カナ As String
        Dim m保険申込者市区郡カナ As String
        Dim m保険申込者町村番地カナ As String
        Dim m保険申込者号棟カナ As String
        Dim m次回定期点検日 As String
        Dim m次回車検日 As String
        Dim m代替予定日 As String
        Dim m営業所出庫日 As String
        Dim m整備入庫日 As String
        Dim m営業所入庫予定日 As String
        Dim m整備完了日 As String
        Dim m営業所入庫日 As String
        Dim m廃車日 As String
        Dim m自賠責登録番号 As String
        Dim m自賠責保険料 As String
        Dim m重量税 As String
        Dim m自動車税 As String
        Dim m自動車登録番号 As String
        Dim m検査証有効期限 As String
        Dim m備考 As String
        Dim m燃費 As String
        Dim m交代時間 As String
        Dim m最終無線番号 As String
        Dim m会社コード As String
        Dim m車種コード As String
        Dim m車輌登録会社コード As String
        Dim m償却日額大月 As String
        Dim m償却日額小月 As String
        Dim m償却日額3月 As String
        Dim m燃料区分 As String
        Dim m用途区分 As String
        Dim m償却日額閏月 As String
        Dim m入力番号 As String
        Dim m旧車輌番号地区コード As String
        Dim m旧車輌番号1 As String
        Dim m旧車輌番号2 As String
        Dim m旧車輌番号3 As String
        Dim m型式1 As String
        Dim m型式2 As String
        Dim m型式3 As String
        Dim m燃料 As String
        Dim m陸事車輌区分 As String
        Dim m任意保険番号 As String
        Dim m使用者コード As String
        Dim m車検使用者コード As String
        Dim m車検所有者コード As String
        Dim m切替日 As String
        Dim m輸送切替日 As String
        Dim m乗車定員 As String
        Dim m解体報告日付 As String
        Dim m移動報告番号 As String
        Dim m入力状態 As String
        Dim m増車代替区分 As String
        Dim m切替区分 As String
        Dim m車輌状態 As String
        Dim m車輌計画処理SEQ As String
        Dim m車輌登録フラグ As String
        Dim m日報確定日時 As String
        Dim m売却先情報 As String
        Dim m元会社コード As String
        Dim m元部署コード As String
        Dim m元営業車輌区分 As String
        Dim m元陸事車輌区分 As String
        Dim m元切替日 As String
        Dim m元車種コード As String
        Dim m元車体番号 As String
        Dim m車輌マスタ更新区分増車 As String
        Dim m車輌マスタ更新区分代替 As String
        Dim m車輌マスタ更新区分営業移動 As String
        Dim m車輌マスタ更新区分会社移動 As String
        Dim m車輌マスタ更新区分車輌メンテ As String
        Dim m増車済みフラグ As String
        Dim m処理対象フラグ As String '// 1:営業車輌マスタ更新対象 2:車輌マスタ更新対象
        Dim mナンバー色区分 As String
        Dim mメーカーコード As String
        Dim m所有区分 As String
        Dim mリース会社コード As String
        Dim m初回登録年月日 As String
        Dim mリサイクル料金 As String
    End Structure

    '******************************************************************************
    ' 関 数 名  : gsubUpdateCarTransfer
    ' スコープ  : Private
    ' 処理内容  : 車輌管理している、車輌マスタと営業車輌マスタを車輌異動テーブルより追加・更新・削除を行う
    ' 備　　考  : 車輌マスタについては、実行日時以前の切替日を対象
    '           : 営業車輌マスタについては、営業日報日時以前の切替日を対象
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstr会社             String        　   I     今回処理を行う対象の会社コード
    '   pstr部署             String        　   I     今回処理を行う対象の部署コード
    '   pstr営業日報日       String             I     今回処理を行う対象の営業日報日(yyyymmdd形式)
    '   pstr実行フラグ       String             I     1:車輌マスタのみ更新 2:営業車輌マスタのみ更新 3:どちらも更新
    '   pstrステータス       String            I/O    どの段階まで処理がすすんでいるかをセット
    '   pstrSEQ              String             I     車輌計画入力SEQ(セットされている場合は画面からの起動とする)
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/04  ＫＳＲ             新規作成
    '               2009/09/28  ＫＳＲ             ファンクション名をgsubUpdateCarTransferに変更する
    '               2010/03/09  ＫＳＲ             車輌マスタ、営業車輌マスタを反映させる条件に指示内容区分=11(保留増車の判断不具合の修正)
    '               2010/05/31  ＫＳＲ             本務者履歴テーブルから車輌マスタに反映させる区分を切替区分から車輌マスタ反映区分に変更する
    '******************************************************************************
    Public Function gsubUpdateCarTransfer(ByVal pstr会社 As String, ByVal pstr部署 As String, ByVal pstr営業日報日 As String, ByVal pstr実行フラグ As String, ByRef pstrステータス As String, ByVal pstrSEQ As String) As Object

        Dim strSQL As String
        Dim objDynaset As Object
        Dim objUpdataParam As 車輌情報

        pstrステータス = "車輌異動テーブルから対象データ抽出"
        strSQL = ""
        If pstr実行フラグ = "1" Or pstr実行フラグ = "3" Then
            '// 車輌マスタの更新の終わっていない車輌異動テーブル
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.車体番号                               ,CPT.指示内容区分                           ,CPT.車輌番号地区コード                     ,CPT.車輌番号１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌番号２                             ,CPT.車輌番号３                             ,CPT.車名                                   ,CPT.年式                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.エンジン型式                           ,CPT.型式                                   ,CPT.区分                                   ,CPT.車輌区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.燃料コード                             ,CPT.ファースト                             ,CPT.登録年月日                             ,CPT.車輌本体価格                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.取得税                                 ,CPT.エアコン価格                           ,CPT.料金メーター価格                       ,CPT.タコメーター価格                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.その他費用                             ,CPT.状態区分                               ,CPT.所属コード                             ,CPT.車輌登録所属コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.整理番号                               ,CPT.本務者コード１                         ,CPT.償却日額１                             ,CPT.償却利息１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却累計額１                           ,CPT.ＡＴ償却費１                           ,CPT.償却残日数１                           ,CPT.本務者コード２                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額２                             ,CPT.償却利息２                             ,CPT.償却累計額２                           ,CPT.ＡＴ償却費２                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却残日数２                           ,CPT.償却満額                               ,CPT.電話番号                               ,CPT.無線番号                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険会社                               ,CPT.自動車保険満期日                       ,CPT.保険申込者名漢字                       ,CPT.保険申込者名カナ                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者郵便番号１                   ,CPT.保険申込者郵便番号２                   ,CPT.保険申込者都道府県漢字                 ,CPT.保険申込者市区郡漢字                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地漢字                 ,CPT.保険申込者号棟漢字                     ,CPT.保険申込者都道府県カナ                 ,CPT.保険申込者市区郡カナ                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地カナ                 ,CPT.保険申込者号棟カナ                     ,CPT.次回定期点検日                         ,CPT.次回車検日                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.代替予定日                             ,CPT.営業所出庫日                           ,CPT.整備入庫日                             ,CPT.営業所入庫予定日                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.整備完了日                             ,CPT.営業所入庫日                           ,CPT.廃車日                                 ,CPT.自賠責登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.自賠責保険料                           ,CPT.重量税                                 ,CPT.自動車税                               ,CPT.自動車登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.検査証有効期限                         ,CPT.備考                                   ,CPT.燃費                                   ,CPT.交代時間                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.最終無線番号                           ,CPT.会社コード                             ,CPT.車種コード                             ,CPT.車輌登録会社コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額大月                           ,CPT.償却日額小月                           ,CPT.償却日額３月                           ,CPT.燃料区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.用途区分                               ,CPT.償却日額閏月                           ,CPT.入力番号                               ,CPT.旧車輌番号地区コード                "
            strSQL = strSQL & Chr(10) & "   ,CPT.旧車輌番号１                           ,CPT.旧車輌番号２                           ,CPT.旧車輌番号３                           ,CPT.型式１                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.型式２                                 ,CPT.型式３                                 ,CPT.燃料                                   ,CPT.陸事車輌区分                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.任意保険番号                           ,CPT.使用者コード                           ,CPT.車検使用者コード                       ,CPT.車検所有者コード                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.切替日                                 ,CPT.輸送切替日                             ,CPT.乗車定員                               ,CPT.解体報告日付                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.移動報告番号                           ,CPT.入力状態                               ,CPT.増車代替区分                           ,CPT.切替区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌状態                               ,CPT.車輌計画処理SEQ                        ,CPT.車輌登録フラグ                         ,CPT.日報確定日時                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.売却先情報                             ,CPT.元会社コード                           ,CPT.元部署コード                           ,CPT.元営業車輌区分                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.元陸事車輌区分                         ,CPT.元切替日                               ,CPT.元車種コード                           ,CPT.元車体番号                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分増車                 ,CPT.車輌マスタ更新区分代替                 ,CPT.車輌マスタ更新区分営業移動             ,CPT.車輌マスタ更新区分会社移動          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分車輌メンテ           ,CPL.相手側車輌計画処理SEQ                  ,PT2.車輌計画処理SEQ CSEQ                   ,PT2.切替日 C切替日                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.日報確定日時 増車済みフラグ         "
            strSQL = strSQL & Chr(10) & "   ,'2' AS 処理対象フラグ " '// 1:営業車輌マスタ更新対象    2:車輌マスタ更新対象
            strSQL = strSQL & Chr(10) & "   ,CPT.ナンバー色区分 ,CPT.メーカーコード ,CPT.所有区分 "
            strSQL = strSQL & Chr(10) & "   ,CPT.リース会社コード ,CPT.初回登録年月日 ,CPT.リサイクル料金 "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    車輌異動テーブル CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌計画入力テーブル CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.車輌計画処理SEQ = CPL.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌異動テーブル PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.相手側車輌計画処理SEQ = PT2.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN 部署マスタ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.会社コード = BMM.会社コード"
            strSQL = strSQL & Chr(10) & "AND CPT.所属コード = BMM.所属コード"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.車輌登録フラグ = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.車輌マスタ日報確定日時 IS NULL"
            '// 増車、代替、営業移動、会社間移動増車、保留増車については無線番号と整理番号<>NULL を追加
            strSQL = strSQL & Chr(10) & "AND ((CPT.指示内容区分 IN ('0','2','3','5','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.無線番号 IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.整理番号 IS NOT NULL ) "
            '// 上記以外の指示内容区分については無線番号と整理番号<>NULLはみない
            strSQL = strSQL & Chr(10) & "OR   (CPT.指示内容区分 IN ('1','4','6','7','8','9','10'))) " '// 2010/03/09  11:保留増車はここではみない
            '// 画面から直接起動する場合は日付の条件をみずに車輌計画処理SEQでレコードを1件に特定して処理を行う
            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.車輌計画処理SEQ = '" & pstrSEQ & "'"
            Else
                '// 減車は1日に終わり時点で反映させるため SYSDATE -1 それ以外は1日の開始から反映させるため SYSDATE
                strSQL = strSQL & Chr(10) & "AND ((CPT.指示内容区分 IN ('1','4') "
                strSQL = strSQL & Chr(10) & "     AND CPT.切替日 <= TO_CHAR(SYSDATE - 1, 'YYYYMMDD')) "
                strSQL = strSQL & Chr(10) & "     OR (CPT.指示内容区分 NOT IN ('1','4') "
                strSQL = strSQL & Chr(10) & "     AND CPT.切替日 <= TO_CHAR(SYSDATE, 'YYYYMMDD'))) "
                '// 夜間バッチ時は、全会社を対象にする
                If pstr会社 <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.会社コード = '" & gfncGetCodeToControl(pstr会社, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.所属コード = '" & gfncGetCodeToControl(pstr部署, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.営業区分 = '0'))"
                End If
            End If

        End If

        If pstr実行フラグ = "3" Then
            strSQL = strSQL & Chr(10) & "UNION ALL ( "
        End If

        If pstr実行フラグ = "2" Or pstr実行フラグ = "3" Then
            '// 営業車輌マスタの更新の終わっていない車輌異動テーブル
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.車体番号                               ,CPT.指示内容区分                           ,CPT.車輌番号地区コード                     ,CPT.車輌番号１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌番号２                             ,CPT.車輌番号３                             ,CPT.車名                                   ,CPT.年式                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.エンジン型式                           ,CPT.型式                                   ,CPT.区分                                   ,CPT.車輌区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.燃料コード                             ,CPT.ファースト                             ,CPT.登録年月日                             ,CPT.車輌本体価格                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.取得税                                 ,CPT.エアコン価格                           ,CPT.料金メーター価格                       ,CPT.タコメーター価格                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.その他費用                             ,CPT.状態区分                               ,CPT.所属コード                             ,CPT.車輌登録所属コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.整理番号                               ,CPT.本務者コード１                         ,CPT.償却日額１                             ,CPT.償却利息１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却累計額１                           ,CPT.ＡＴ償却費１                           ,CPT.償却残日数１                           ,CPT.本務者コード２                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額２                             ,CPT.償却利息２                             ,CPT.償却累計額２                           ,CPT.ＡＴ償却費２                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却残日数２                           ,CPT.償却満額                               ,CPT.電話番号                               ,CPT.無線番号                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険会社                               ,CPT.自動車保険満期日                       ,CPT.保険申込者名漢字                       ,CPT.保険申込者名カナ                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者郵便番号１                   ,CPT.保険申込者郵便番号２                   ,CPT.保険申込者都道府県漢字                 ,CPT.保険申込者市区郡漢字                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地漢字                 ,CPT.保険申込者号棟漢字                     ,CPT.保険申込者都道府県カナ                 ,CPT.保険申込者市区郡カナ                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地カナ                 ,CPT.保険申込者号棟カナ                     ,CPT.次回定期点検日                         ,CPT.次回車検日                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.代替予定日                             ,CPT.営業所出庫日                           ,CPT.整備入庫日                             ,CPT.営業所入庫予定日                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.整備完了日                             ,CPT.営業所入庫日                           ,CPT.廃車日                                 ,CPT.自賠責登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.自賠責保険料                           ,CPT.重量税                                 ,CPT.自動車税                               ,CPT.自動車登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.検査証有効期限                         ,CPT.備考                                   ,CPT.燃費                                   ,CPT.交代時間                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.最終無線番号                           ,CPT.会社コード                             ,CPT.車種コード                             ,CPT.車輌登録会社コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額大月                           ,CPT.償却日額小月                           ,CPT.償却日額３月                           ,CPT.燃料区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.用途区分                               ,CPT.償却日額閏月                           ,CPT.入力番号                               ,CPT.旧車輌番号地区コード                "
            strSQL = strSQL & Chr(10) & "   ,CPT.旧車輌番号１                           ,CPT.旧車輌番号２                           ,CPT.旧車輌番号３                           ,CPT.型式１                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.型式２                                 ,CPT.型式３                                 ,CPT.燃料                                   ,CPT.陸事車輌区分                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.任意保険番号                           ,CPT.使用者コード                           ,CPT.車検使用者コード                       ,CPT.車検所有者コード                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.切替日                                 ,CPT.輸送切替日                             ,CPT.乗車定員                               ,CPT.解体報告日付                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.移動報告番号                           ,CPT.入力状態                               ,CPT.増車代替区分                           ,CPT.切替区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌状態                               ,CPT.車輌計画処理SEQ                        ,CPT.車輌登録フラグ                         ,CPT.日報確定日時                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.売却先情報                             ,CPT.元会社コード                           ,CPT.元部署コード                           ,CPT.元営業車輌区分                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.元陸事車輌区分                         ,CPT.元切替日                               ,CPT.元車種コード                           ,CPT.元車体番号                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分増車                 ,CPT.車輌マスタ更新区分代替                 ,CPT.車輌マスタ更新区分営業移動             ,CPT.車輌マスタ更新区分会社移動          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分車輌メンテ           ,CPL.相手側車輌計画処理SEQ                  ,PT2.車輌計画処理SEQ CSEQ                   ,PT2.切替日 C切替日                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.日報確定日時 増車済みフラグ         "
            strSQL = strSQL & Chr(10) & "   ,'1' AS 処理対象フラグ " '// 1:営業車輌マスタ更新対象    2:車輌マスタ更新対象
            strSQL = strSQL & Chr(10) & "   ,CPT.ナンバー色区分 ,CPT.メーカーコード ,CPT.所有区分 "
            strSQL = strSQL & Chr(10) & "   ,CPT.リース会社コード ,CPT.初回登録年月日 ,CPT.リサイクル料金 "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    車輌異動テーブル CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌計画入力テーブル CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.車輌計画処理SEQ = CPL.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌異動テーブル PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.相手側車輌計画処理SEQ = PT2.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN 部署マスタ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.会社コード = BMM.会社コード"
            strSQL = strSQL & Chr(10) & "AND CPT.所属コード = BMM.所属コード"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.車輌登録フラグ = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.日報確定日時 IS NULL"
            '// 増車、代替、営業移動、会社間移動増車、保留増車については無線番号と整理番号<>NULL を追加
            strSQL = strSQL & Chr(10) & "AND ((CPT.指示内容区分 IN ('0','2','3','5','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.無線番号 IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.整理番号 IS NOT NULL ) "
            '// 上記以外の指示内容区分については無線番号と整理番号<>NULLはみない
            strSQL = strSQL & Chr(10) & "OR   (CPT.指示内容区分 IN ('1','4','6','7','8','9','10'))) " '// 2010/03/09  11:保留増車はここではみない
            '// 画面から直接起動する場合は日付の条件をみずに車輌計画処理SEQでレコードを1件に特定して処理を行う
            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.車輌計画処理SEQ = '" & pstrSEQ & "'"
            Else
                '// 減車は1日に終わり時点で反映させるため SYSDATE -1 それ以外は1日の開始から反映させるため SYSDATE
                strSQL = strSQL & Chr(10) & "AND ((CPT.指示内容区分 IN ('1','4') "
                strSQL = strSQL & Chr(10) & "      AND CPT.切替日 <= '" & pstr営業日報日 & "') "
                strSQL = strSQL & Chr(10) & "      OR (CPT.指示内容区分 NOT IN ('1','4') "
                strSQL = strSQL & Chr(10) & "      AND CPT.切替日 <= '" & VB6.Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, CDate(VB6.Format(pstr営業日報日, "0000/00/00"))), "yyyymmdd") & "')) "
                '// 夜間バッチ時は、全会社を対象にする
                If pstr会社 <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.会社コード = '" & gfncGetCodeToControl(pstr会社, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.所属コード = '" & gfncGetCodeToControl(pstr部署, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.営業区分 = '0'))"
                End If
            End If
        End If

        If pstr実行フラグ = "3" Then
            strSQL = strSQL & Chr(10) & " ) "
        End If

        strSQL = strSQL & Chr(10) & "ORDER BY"
        strSQL = strSQL & Chr(10) & "    指示内容区分,車体番号 "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDynaset = gobjOraDatabase.CreateDynaset(strSQL, &H1)

        With objDynaset

            'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF = True Then
                pstrステータス = "車輌管理　日報確定該当なし"
                GoTo HONMUTUKEKOMI
                '            Exit Function
            End If

            Do

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstrステータス = "車輌異動テーブル　該当SEQ：" & gfncFieldVal(.Fields("車輌計画処理SEQ").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車体番号 = gfncFieldVal(.Fields("車体番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m指示内容区分 = gfncFieldVal(.Fields("指示内容区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号地区コード = gfncFieldVal(.Fields("車輌番号地区コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号1 = gfncFieldVal(.Fields("車輌番号１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号2 = gfncFieldVal(.Fields("車輌番号２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号3 = gfncFieldVal(.Fields("車輌番号３").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車名 = gfncFieldVal(.Fields("車名").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m年式 = gfncFieldVal(.Fields("年式").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mエンジン型式 = gfncFieldVal(.Fields("エンジン型式").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式 = gfncFieldVal(.Fields("型式").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m区分 = gfncFieldVal(.Fields("区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌区分 = gfncFieldVal(.Fields("車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃料コード = gfncFieldVal(.Fields("燃料コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mファースト = gfncFieldVal(.Fields("ファースト").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m登録年月日 = gfncFieldVal(.Fields("登録年月日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌本体価格 = gfncFieldVal(.Fields("車輌本体価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m取得税 = gfncFieldVal(.Fields("取得税").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mエアコン価格 = gfncFieldVal(.Fields("エアコン価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m料金メーター価格 = gfncFieldVal(.Fields("料金メーター価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mタコメーター価格 = gfncFieldVal(.Fields("タコメーター価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mその他費用 = gfncFieldVal(.Fields("その他費用").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m状態区分 = gfncFieldVal(.Fields("状態区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m所属コード = gfncFieldVal(.Fields("所属コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌登録所属コード = gfncFieldVal(.Fields("車輌登録所属コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m整理番号 = gfncFieldVal(.Fields("整理番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m本務者コード1 = gfncFieldVal(.Fields("本務者コード１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額1 = gfncFieldVal(.Fields("償却日額１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却利息1 = gfncFieldVal(.Fields("償却利息１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却累計額1 = gfncFieldVal(.Fields("償却累計額１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT償却費1 = gfncFieldVal(.Fields("ＡＴ償却費１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却残日数1 = gfncFieldVal(.Fields("償却残日数１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m本務者コード2 = gfncFieldVal(.Fields("本務者コード２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額2 = gfncFieldVal(.Fields("償却日額２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却利息2 = gfncFieldVal(.Fields("償却利息２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却累計額2 = gfncFieldVal(.Fields("償却累計額２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT償却費2 = gfncFieldVal(.Fields("ＡＴ償却費２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却残日数2 = gfncFieldVal(.Fields("償却残日数２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却満額 = gfncFieldVal(.Fields("償却満額").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m電話番号 = gfncFieldVal(.Fields("電話番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m無線番号 = gfncFieldVal(.Fields("無線番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険会社 = gfncFieldVal(.Fields("保険会社").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険会社名 = mfncGetHokenName(gfncFieldVal(.Fields("保険会社").Value)) '// 2010/03/26 保険会社名の取得を追加
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自動車保険満期日 = gfncFieldVal(.Fields("自動車保険満期日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者名漢字 = gfncFieldVal(.Fields("保険申込者名漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者名カナ = gfncFieldVal(.Fields("保険申込者名カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者郵便番号1 = gfncFieldVal(.Fields("保険申込者郵便番号１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者郵便番号2 = gfncFieldVal(.Fields("保険申込者郵便番号２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者都道府県漢字 = gfncFieldVal(.Fields("保険申込者都道府県漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者市区郡漢字 = gfncFieldVal(.Fields("保険申込者市区郡漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者町村番地漢字 = gfncFieldVal(.Fields("保険申込者町村番地漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者号棟漢字 = gfncFieldVal(.Fields("保険申込者号棟漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者都道府県カナ = gfncFieldVal(.Fields("保険申込者都道府県カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者市区郡カナ = gfncFieldVal(.Fields("保険申込者市区郡カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者町村番地カナ = gfncFieldVal(.Fields("保険申込者町村番地カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者号棟カナ = gfncFieldVal(.Fields("保険申込者号棟カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m次回定期点検日 = gfncFieldVal(.Fields("次回定期点検日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m次回車検日 = gfncFieldVal(.Fields("次回車検日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m代替予定日 = gfncFieldVal(.Fields("代替予定日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m営業所出庫日 = gfncFieldVal(.Fields("営業所出庫日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m整備入庫日 = gfncFieldVal(.Fields("整備入庫日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m営業所入庫予定日 = gfncFieldVal(.Fields("営業所入庫予定日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m整備完了日 = gfncFieldVal(.Fields("整備完了日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m営業所入庫日 = gfncFieldVal(.Fields("営業所入庫日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m廃車日 = gfncFieldVal(.Fields("廃車日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自賠責登録番号 = gfncFieldVal(.Fields("自賠責登録番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自賠責保険料 = gfncFieldVal(.Fields("自賠責保険料").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m重量税 = gfncFieldVal(.Fields("重量税").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自動車税 = gfncFieldVal(.Fields("自動車税").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自動車登録番号 = gfncFieldVal(.Fields("自動車登録番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m検査証有効期限 = gfncFieldVal(.Fields("検査証有効期限").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m備考 = gfncFieldVal(.Fields("備考").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃費 = gfncFieldVal(.Fields("燃費").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m交代時間 = gfncFieldVal(.Fields("交代時間").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m最終無線番号 = gfncFieldVal(.Fields("最終無線番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m会社コード = gfncFieldVal(.Fields("会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車種コード = gfncFieldVal(.Fields("車種コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌登録会社コード = gfncFieldVal(.Fields("車輌登録会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額大月 = gfncFieldVal(.Fields("償却日額大月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額小月 = gfncFieldVal(.Fields("償却日額小月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額3月 = gfncFieldVal(.Fields("償却日額３月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃料区分 = gfncFieldVal(.Fields("燃料区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m用途区分 = gfncFieldVal(.Fields("用途区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額閏月 = gfncFieldVal(.Fields("償却日額閏月").Value)
                'objUpdataParam.m入力番号 = gfncFieldVal(.Fields("入力番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m入力番号 = gfncFieldVal(.Fields("入力番号").Value, "1")
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号地区コード = gfncFieldVal(.Fields("旧車輌番号地区コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号1 = gfncFieldVal(.Fields("旧車輌番号１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号2 = gfncFieldVal(.Fields("旧車輌番号２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号3 = gfncFieldVal(.Fields("旧車輌番号３").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式1 = gfncFieldVal(.Fields("型式１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式2 = gfncFieldVal(.Fields("型式２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式3 = gfncFieldVal(.Fields("型式３").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃料 = gfncFieldVal(.Fields("燃料").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m陸事車輌区分 = gfncFieldVal(.Fields("陸事車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m任意保険番号 = gfncFieldVal(.Fields("任意保険番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m使用者コード = gfncFieldVal(.Fields("使用者コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車検使用者コード = gfncFieldVal(.Fields("車検使用者コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車検所有者コード = gfncFieldVal(.Fields("車検所有者コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m切替日 = gfncFieldVal(.Fields("切替日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m輸送切替日 = gfncFieldVal(.Fields("輸送切替日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m乗車定員 = gfncFieldVal(.Fields("乗車定員").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m解体報告日付 = gfncFieldVal(.Fields("解体報告日付").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m移動報告番号 = gfncFieldVal(.Fields("移動報告番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m入力状態 = gfncFieldVal(.Fields("入力状態").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m増車代替区分 = gfncFieldVal(.Fields("増車代替区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m切替区分 = gfncFieldVal(.Fields("切替区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌状態 = gfncFieldVal(.Fields("車輌状態").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌計画処理SEQ = gfncFieldVal(.Fields("車輌計画処理SEQ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌登録フラグ = gfncFieldVal(.Fields("車輌登録フラグ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m日報確定日時 = gfncFieldVal(.Fields("日報確定日時").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m売却先情報 = gfncFieldVal(.Fields("売却先情報").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元会社コード = gfncFieldVal(.Fields("元会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元部署コード = gfncFieldVal(.Fields("元部署コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元営業車輌区分 = gfncFieldVal(.Fields("元営業車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元陸事車輌区分 = gfncFieldVal(.Fields("元陸事車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元切替日 = gfncFieldVal(.Fields("元切替日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元車種コード = gfncFieldVal(.Fields("元車種コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元車体番号 = gfncFieldVal(.Fields("元車体番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分増車 = gfncFieldVal(.Fields("車輌マスタ更新区分増車").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分代替 = gfncFieldVal(.Fields("車輌マスタ更新区分代替").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分営業移動 = gfncFieldVal(.Fields("車輌マスタ更新区分営業移動").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分会社移動 = gfncFieldVal(.Fields("車輌マスタ更新区分会社移動").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分車輌メンテ = gfncFieldVal(.Fields("車輌マスタ更新区分車輌メンテ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m増車済みフラグ = gfncFieldVal(.Fields("増車済みフラグ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m処理対象フラグ = gfncFieldVal(.Fields("処理対象フラグ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mナンバー色区分 = gfncFieldVal(.Fields("ナンバー色区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mメーカーコード = gfncFieldVal(.Fields("メーカーコード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m所有区分 = gfncFieldVal(.Fields("所有区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mリース会社コード = gfncFieldVal(.Fields("リース会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m初回登録年月日 = gfncFieldVal(.Fields("初回登録年月日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mリサイクル料金 = gfncFieldVal(.Fields("リサイクル料金").Value)

                '// 会社間移動の減と増については処理方法を一旦保留
                '            If gfncFieldVal(.Fields("相手側車輌計画処理SEQ").Value) <> "" Then
                '                If gfncFieldVal(.Fields("CSEQ").Value) = "" Then
                '                    GoTo NEXT_
                '                End If
                '                If gfncFieldVal(.Fields("C切替日").Value) > gfncFieldVal(.Fields("CDATE").Value) Then
                '                    GoTo NEXT_
                '                End If
                '            End If


                Select Case objUpdataParam.m指示内容区分

                    Case "0"

                        pstrステータス = "増車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate増車(objUpdataParam)

                    Case "1"

                        pstrステータス = "減車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate減車(objUpdataParam)

                    Case "2"

                        pstrステータス = "代替　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate代替(objUpdataParam, pstr実行フラグ)

                    Case "3"

                        pstrステータス = "営業所間　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate営業所間(objUpdataParam)

                    Case "4"

                        pstrステータス = "会社間減車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate会社間減車(objUpdataParam)

                    Case "5"

                        pstrステータス = "会社間増車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate会社間増車(objUpdataParam)

                    Case "6"

                        pstrステータス = "社用車切替　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate社用車切替(objUpdataParam)

                    Case "7"

                        pstrステータス = "廃車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate廃車(objUpdataParam)

                    Case "8"

                        pstrステータス = "売却　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate売却(objUpdataParam)

                    Case "9"

                        pstrステータス = "保留車切替　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate保留車切替(objUpdataParam)

                    Case "10"

                        pstrステータス = "直接メンテナンス　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdateマスタメンテ(objUpdataParam)

                    Case "11"

                        pstrステータス = "保留増車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate保留増車(objUpdataParam)

                End Select

                '// フラグの状態で更新する日報確定日時の更新先を変更する
                If objUpdataParam.m処理対象フラグ = "1" Then

                    pstrステータス = "日報確定日時の更新　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                    '// 営業車輌マスタ
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌異動テーブル SET"
                    strSQL = strSQL & Chr(10) & "    日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌計画入力テーブル SET"
                    strSQL = strSQL & Chr(10) & "    日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                Else
                    pstrステータス = "車輌マスタ日報確定日時の更新　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                    '// 車輌マスタ
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌異動テーブル SET"
                    strSQL = strSQL & Chr(10) & "    車輌マスタ日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌計画入力テーブル SET"
                    strSQL = strSQL & Chr(10) & "    車輌マスタ日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

NEXT_:

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .MoveNext()

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Loop While .EOF = False

        End With

HONMUTUKEKOMI:

        Dim objDys本務者履歴テーブル As Object
        Dim objDys車輌履歴テーブル As Object
        If pstr実行フラグ = "1" Or pstr実行フラグ = "3" Then
            '// 本務代務履歴テーブルから車輌マスタに本務者１と本務者２の情報を漬け込む

            pstrステータス = "本務者履歴テーブルから車輌マスタの本務者情報を反映："
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    HRT.車輌番号地区コード "
            strSQL = strSQL & Chr(10) & "   ,HRT.車輌番号１         "
            strSQL = strSQL & Chr(10) & "   ,HRT.車輌番号２         "
            strSQL = strSQL & Chr(10) & "   ,HRT.車輌番号３         "
            strSQL = strSQL & Chr(10) & "   ,ESM.無線番号           "
            strSQL = strSQL & Chr(10) & "   ,HRT.切替日             "
            strSQL = strSQL & Chr(10) & "   ,HRT.新本務者コード１   "
            strSQL = strSQL & Chr(10) & "   ,HRT.新本務者コード２   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    本務者履歴テーブル HRT "
            strSQL = strSQL & Chr(10) & "   ,営業車輌マスタ     ESM "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    HRT.車輌番号地区コード = ESM.車輌番号地区コード(+) "
            strSQL = strSQL & Chr(10) & "AND HRT.車輌番号１         = ESM.車輌番号１        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.車輌番号２         = ESM.車輌番号２        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.車輌番号３         = ESM.車輌番号３        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.切替日            <= TO_CHAR(SYSDATE,'YYYYMMDD') "
            strSQL = strSQL & Chr(10) & "AND NVL(HRT.車輌マスタ反映区分,'0') = '0' " '// 2010/05/31
            '        strSQL = strSQL & Chr(10) & "AND HRT.切替区分           =  0 "
            strSQL = strSQL & Chr(10) & "ORDER BY HRT.切替日 " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys本務者履歴テーブル = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys本務者履歴テーブル

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        pstrステータス = "本務者付込み：車輌番号:" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "-" & gfncFieldVal(.Fields("車輌番号１").Value) & "-" & gfncFieldVal(.Fields("車輌番号２").Value) & "-" & gfncFieldVal(.Fields("車輌番号３").Value) & ""
                        ' 車輌マスタを更新
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(新本務者コード１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET 本務者コード１     = '" & gfncFieldVal(.Fields("新本務者コード１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(新本務者コード２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,本務者コード２     = '" & gfncFieldVal(.Fields("新本務者コード２").Value) & "' "
                        '// 2009/09/23 START 更新追加
                        strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号地区コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号１         = '" & gfncFieldVal(.Fields("車輌番号１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号２         = '" & gfncFieldVal(.Fields("車輌番号２").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号３         = '" & gfncFieldVal(.Fields("車輌番号３").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)


                        '// 車輌マスタ反映区分を更新(切替区分 = 1)  2010/05/31
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE 本務者履歴テーブル SET"
                        strSQL = strSQL & Chr(10) & "   車輌マスタ反映区分  = 1 "
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号地区コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号１         = '" & gfncFieldVal(.Fields("車輌番号１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号２         = '" & gfncFieldVal(.Fields("車輌番号２").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号３         = '" & gfncFieldVal(.Fields("車輌番号３").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(切替日).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 切替日             = '" & gfncFieldVal(.Fields("切替日").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            'UPGRADE_NOTE: Object objDys本務者履歴テーブル may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDys本務者履歴テーブル = Nothing

            '// 2009/09/23 START 車輌履歴テーブルから車輌マスタを更新する処理を追加
            '----------------------------------------------------------------------
            ' 車輌履歴テーブル  データ反映処理
            '----------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード   "
            strSQL = strSQL & Chr(10) & "   ,車輌番号１           "
            strSQL = strSQL & Chr(10) & "   ,車輌番号２           "
            strSQL = strSQL & Chr(10) & "   ,車輌番号３           "
            strSQL = strSQL & Chr(10) & "   ,切替日               "
            strSQL = strSQL & Chr(10) & "   ,新会社コード         "
            strSQL = strSQL & Chr(10) & "   ,新所属コード         "
            strSQL = strSQL & Chr(10) & "   ,新整理番号           "
            strSQL = strSQL & Chr(10) & "   ,新車輌区分           "
            strSQL = strSQL & Chr(10) & "   ,新車輌登録会社コード "
            strSQL = strSQL & Chr(10) & "   ,新車輌登録所属コード "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    車輌履歴テーブル "
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND 切替日       <= TO_CHAR(SYSDATE,'YYYYMMDD')"
            strSQL = strSQL & Chr(10) & "AND 切替区分      =  0 "
            strSQL = strSQL & Chr(10) & "ORDER BY 切替日 " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys車輌履歴テーブル = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys車輌履歴テーブル

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        '// 車輌マスタの更新(未来日付で車輌変更入力された内容を反映)
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新所属コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET 所属コード         = '" & gfncFieldVal(.Fields("新所属コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新会社コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,会社コード         = '" & gfncFieldVal(.Fields("新会社コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新整理番号).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,整理番号           = '" & gfncFieldVal(.Fields("新整理番号").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新車輌区分).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,車輌区分           = '" & gfncFieldVal(.Fields("新車輌区分").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新車輌登録会社コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & gfncFieldVal(.Fields("新車輌登録会社コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新車輌登録所属コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & gfncFieldVal(.Fields("新車輌登録所属コード").Value) & "' "
                        '// 2009/09/23 START 更新追加
                        strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号地区コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号１         = '" & gfncFieldVal(.Fields("車輌番号１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号２         = '" & gfncFieldVal(.Fields("車輌番号２").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号３         = '" & gfncFieldVal(.Fields("車輌番号３").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '// 2009/09/23 END
            Call gsubClearObject(objDynaset)
            Call gsubClearObject(objDys本務者履歴テーブル)
            Call gsubClearObject(objDys車輌履歴テーブル)
        End If

    End Function

    '******************************************************************************
    ' 関 数 名  : msubUpdate増車
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの増車処理
    ' 備　　考  : 増車の対象になった車輌は、それぞれのマスタにINSERTが行われる
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate増車(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            strSQL = strSQL & Chr(10) & " 車名= '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & ",年式= '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & ",エンジン型式= '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & ",車体番号= '" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & ",型式= '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & ",区分= '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & ",車輌区分= '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",ファースト= '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & ",登録年月日= '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & ",車輌本体価格= '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & ",取得税= '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & ",エアコン価格= '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & ",料金メーター価格= '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & ",タコメーター価格= '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & ",その他費用= '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & ",状態区分= '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & ",所属コード= '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & ",車輌登録所属コード= '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & ",整理番号= '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & ",本務者コード１= '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額１= '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & ",償却利息１= '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & ",償却累計額１= '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & ",ＡＴ償却費１= '" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & ",本務者コード２= '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額２= '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & ",償却利息２= '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & ",償却累計額２= '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & ",ＡＴ償却費２= '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & ",償却満額= '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & ",電話番号= '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & ",無線番号= '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & ",保険会社= '" & objUpdate.m保険会社名 & "'"
            strSQL = strSQL & Chr(10) & ",自動車保険満期日= '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者名漢字= '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者名カナ= '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者郵便番号１= '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者郵便番号２= '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者都道府県漢字= '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者市区郡漢字= '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者町村番地漢字= '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者号棟漢字= '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者都道府県カナ= '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者市区郡カナ= '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者町村番地カナ= '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & ",保険申込者号棟カナ= '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & ",次回定期点検日= '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & ",次回車検日= '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & ",代替予定日= '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & ",営業所出庫日= '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & ",整備入庫日= '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & ",営業所入庫予定日= '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & ",整備完了日= '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & ",営業所入庫日= '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & ",廃車日= '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & ",自賠責登録番号= '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & ",自賠責保険料= '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & ",重量税= '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & ",自動車税= '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & ",自動車登録番号= '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & ",検査証有効期限= '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & ",備考= '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & ",燃費= '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & ",更新従業員コード= '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & ",更新日付時刻= SYSDATE"
            strSQL = strSQL & Chr(10) & ",交代時間= '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & ",最終無線番号= '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & ",会社コード= '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & ",車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",車輌登録会社コード= '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & ",償却日額大月= '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額小月= '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額３月= '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & ",燃料区分= '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & ",用途区分= '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額閏月= '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号地区コード= '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号１= '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号２= '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号３= '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & ",旧車体番号= '" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & ",旧車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",新車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",旧陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",新陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",入力状態= '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & ",型式１= '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & ",型式２= '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & ",型式３= '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & ",燃料= '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & ",陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",任意保険番号= '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & ",使用者コード= '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & ",車検使用者コード= '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & ",車検所有者コード= '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & ",輸送切替日= '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & ",乗車定員= '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & " AND 車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号１         = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号２         = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号３         = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m廃車日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = "" : strValSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

            strSQL = strSQL & strValSQL

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate減車
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの減車処理
    ' 備　　考  : 減車の対象になった車輌は、整理番号と無線番号がNULLになる
    '             車輌マスタについてはNOプレートがNULLになり、営業車輌マスタについては廃車日に切替日がセットされる
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  ＫＳＲ             最終無線番号の転送を追加
    '******************************************************************************
    Private Sub msubUpdate減車(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に減車する車輌で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '3'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '1'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub
    Private Sub msubUpdate代替(ByRef objUpdate As 車輌情報, ByVal pstr実行フラグ As String)

        Dim strSQL As String
        Dim strValSQL As String

        Select Case objUpdate.m車輌マスタ更新区分代替

            Case "1"

                Call msubUpdate代替1(objUpdate)


            Case "2"

                Call msubUpdate代替2(objUpdate)


            Case "3"

                Call msubUpdate代替3(objUpdate, pstr実行フラグ)


            Case "4"

                Call msubUpdate代替4(objUpdate, pstr実行フラグ)

        End Select

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate代替1
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの代替処理
    ' 備　　考  : 新・旧車輌番号が同じで、車体番号が変更になる場合の代替
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  ＫＳＲ             車輌マスタの代替元の車輌に旧車輌番号を更新しておく
    '               2010/03/24  ＫＳＲ             車輌番号が変更されない場合は最終無線番号は転送せずNULL更新を行う。既存の項目のNULL更新を止める
    '******************************************************************************
    Private Sub msubUpdate代替1(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "    年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社名 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            '        strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に車輌番号の変更なしの代替で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "' "
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "' "
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = "" : strValSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌状態 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,売却先情報":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

            strSQL = strSQL & strValSQL

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL"
            '// 2009/09/30 代替元の車輌に旧車輌番号を更新しておく
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード   = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１           = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２           = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３           = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '1'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '3'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m元車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate代替2
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの代替処理
    ' 備　　考  : 新・旧車輌番号が同じで、車体が既存の場合の代替
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  ＫＳＲ             車輌マスタの代替元の車輌に旧車輌番号を更新しておく
    '               2010/03/24  ＫＳＲ             車輌番号が変更されない場合は最終無線番号は転送せずNULL更新を行う。既存の項目のNULL更新を止める
    '******************************************************************************
    Private Sub msubUpdate代替2(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "    年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            'strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社名 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号１ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号２ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号３ & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            '        strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に車輌番号の変更なしの代替で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "' "
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "' "
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL"
            '// 2009/09/30 代替元の車輌に旧車輌番号を更新しておく
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード   = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１           = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２           = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３           = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '1'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '3'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = NULL "
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"

            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m元車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate代替3
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの代替処理
    ' 備　　考  : 新・旧車輌番号が違いで、車体が新車の場合の代替
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  ＫＳＲ             車輌マスタの代替元の車輌に旧車輌番号を更新しておく
    '               2010/03/24  ＫＳＲ             車輌番号が変更される場合は元車輌の最終無線番号に無線番号を転送しておく
    '                                              既存の項目のNULL更新を止める
    '******************************************************************************
    Private Sub msubUpdate代替3(ByRef objUpdate As 車輌情報, ByVal pstr実行フラグ As String)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then
            '// NO変更された代替先の営業車輌マスタの更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & " 車名= '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & " 年式= '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & ",エンジン型式= '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & ",車体番号= '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & ",型式= '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & ",区分= '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & ",車輌区分= '" & objUpdate.m車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & ",ファースト= '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & ",登録年月日= '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & ",車輌本体価格= '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & ",取得税= '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & ",エアコン価格= '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & ",料金メーター価格= '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & ",タコメーター価格= '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & ",その他費用= '" & objUpdate.mその他費用 & "'"
            '        strSQL = strSQL & Chr(10) & ",状態区分= '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & ",所属コード= '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & ",車輌登録所属コード= '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & ",整理番号= '" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & ",本務者コード１= '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額１= '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & ",償却利息１= '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & ",償却累計額１= '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & ",ＡＴ償却費１= '" & objUpdate.mAT償却費1 & "'"
            ''        strSQL = strSQL & Chr(10) & ",本務者コード２= '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額２= '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & ",償却利息２= '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & ",償却累計額２= '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & ",ＡＴ償却費２= '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & ",償却満額= '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & ",電話番号= '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & ",無線番号= '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & ",保険会社= '" & objUpdate.m保険会社名 & "'"
            '        strSQL = strSQL & Chr(10) & ",自動車保険満期日= '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者名漢字= '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者名カナ= '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者郵便番号１= '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者郵便番号２= '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者都道府県漢字= '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者市区郡漢字= '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者町村番地漢字= '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者号棟漢字= '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者都道府県カナ= '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者市区郡カナ= '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者町村番地カナ= '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者号棟カナ= '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",次回定期点検日= '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & ",次回車検日= '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & ",代替予定日= '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & ",営業所出庫日= '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & ",整備入庫日= '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & ",営業所入庫予定日= '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & ",整備完了日= '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & ",営業所入庫日= '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & ",廃車日= '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & ",自賠責登録番号= '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & ",自賠責保険料= '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & ",重量税= '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & ",自動車税= '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & ",自動車登録番号= '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & ",検査証有効期限= '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & ",備考= '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & ",燃費= '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & ",更新従業員コード= '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & ",更新日付時刻= SYSDATE"
            strSQL = strSQL & Chr(10) & ",交代時間= '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & ",最終無線番号= NULL "
            strSQL = strSQL & Chr(10) & ",会社コード= '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & ",車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",車輌登録会社コード= '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & ",償却日額大月= '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額小月= '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額３月= '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & ",燃料区分= '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & ",用途区分= '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額閏月= '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号地区コード= '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号１= '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号２= '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号３= '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & ",旧車体番号= '" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & ",旧車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",新車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",旧陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",新陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & ",入力状態= '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & ",型式１= '" & objUpdate.m型式1 & "'"
            '        strSQL = strSQL & Chr(10) & ",型式２= '" & objUpdate.m型式2 & "'"
            '        strSQL = strSQL & Chr(10) & ",型式３= '" & objUpdate.m型式3 & "'"
            '        strSQL = strSQL & Chr(10) & ",燃料= '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & ",陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",任意保険番号= '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & ",使用者コード= '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & ",車検使用者コード= '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & ",車検所有者コード= '" & objUpdate.m車検所有者コード & "'"
            '        strSQL = strSQL & Chr(10) & ",輸送切替日= '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & ",乗車定員= '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & " AND 車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号１         = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号２         = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号３         = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 車輌番号の変更ありで新車の場合の代替は営業車輌マスタが存在しないのでここで、営業車輌マスタは作成される
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// NO変更された代替元の営業車輌マスタの更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET "
            strSQL = strSQL & Chr(10) & "    本務者コード１ = NULL "
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL "
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m切替日 & "' "
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE "
            strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "' "
            strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m車輌番号1 & "' "
            strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m車輌番号2 & "' "
            strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m車輌番号3 & "' "
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "' "
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "' "
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に代替元で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = "" : strValSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌状態 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,売却先情報":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリサイクル料金 & "'"

            strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

            strSQL = strSQL & strValSQL

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL"
            '// 2009/09/30 代替元の車輌に旧車輌番号を更新しておく
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード   = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１           = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２           = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３           = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '1'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '3'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m元車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

        ''** Add-Start 2009/10/06 KSR ********************↓
        ''** 車輌マスタのみ更新時に営業車輌の廃車日に切替日を転送
        If pstr実行フラグ = "1" Then
            ''** 営業車輌マスタ廃車日更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET "
            strSQL = strSQL & Chr(10) & "    廃車日 = '" & objUpdate.m切替日 & "' "
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE "
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"

            ''** SQL実行
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If
        ''** Add-End   2009/10/06 KSR ********************↑

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate代替4
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの代替処理
    ' 備　　考  : 新・旧車輌番号が違いで、車体が既存の代替
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2009/09/30  ＫＳＲ             車輌マスタの代替元の車輌に旧車輌番号を更新しておく
    '               2010/03/24  ＫＳＲ             車輌番号が変更される場合は元車輌の最終無線番号に無線番号を転送しておく
    '                                              既存の項目のNULL更新を止める
    '******************************************************************************
    Private Sub msubUpdate代替4(ByRef objUpdate As 車輌情報, ByVal pstr実行フラグ As String)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then
            '// NO変更された代替先の営業車輌マスタの更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "    年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            'strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社名 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号１ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号２ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号３ & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            '        strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 車輌番号の変更ありで保留車輌からの代替の場合の代替は営業車輌マスタが存在しているのでここで、営業車輌マスタは基本的に作成されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '            strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// NO変更された代替元の営業車輌マスタの更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に代替元で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード１":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                ''            strSQL = strSQL & Chr(10) & "   ,本務者コード２":               strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
            ''        strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL"
            '// 2009/09/30 代替元の車輌に旧車輌番号を更新しておく
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード   = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１           = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２           = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３           = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '1'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '3'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = NULL "
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m元車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

        ''** Add-Start 2009/10/06 KSR ********************↓
        ''** 車輌マスタのみ更新時に営業車輌の廃車日に切替日を転送
        If pstr実行フラグ = "1" Then
            ''** 営業車輌マスタ廃車日更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET "
            strSQL = strSQL & Chr(10) & "    廃車日 = '" & objUpdate.m切替日 & "' "
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "' "
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE "
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"

            ''** SQL実行
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If
        ''** Add-End   2009/10/06 KSR ********************↑

    End Sub
    Private Sub msubUpdate営業所間(ByRef objUpdate As 車輌情報)

        Select Case objUpdate.m車輌マスタ更新区分営業移動

            Case "1"

                Call msubUpdate営業所間1(objUpdate)

            Case "2"

                Call msubUpdate営業所間2(objUpdate)

        End Select

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate営業所間1
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの営業所間移動処理
    ' 備　　考  : 移動の対象になった車輌は、整理番号と無線番号がNULLになる
    '           : 新・旧車輌番号が同じ
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  ＫＳＲ             車輌番号が変更されない場合は最終無線番号は転送せずNULL更新を行う。既存の項目のNULL更新を止める
    '******************************************************************************
    Private Sub msubUpdate営業所間1(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "    年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社名 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号１ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号２ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号３ & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に車輌番号の変更なしの営業所移動で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub
    '******************************************************************************
    ' 関 数 名  : msubUpdate営業所間2
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの営業所間移動処理
    ' 備　　考  : 移動の対象になった車輌は、整理番号と無線番号がNULLになる
    '           : 新・旧車輌番号が違う
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  ＫＳＲ             車輌番号が変更される場合は元車輌の最終無線番号に無線番号を転送しておく
    '                                              既存の項目のNULL更新を止める
    '******************************************************************************
    Private Sub msubUpdate営業所間2(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            '// NO変更された移動先の営業車輌マスタの更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "    年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社名 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 車輌番号の変更ありの場合の営業所移動は営業車輌マスタが存在しないのでここで、営業車輌マスタは作成される
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "' " '// 2010/03/26
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "' " '// 2010/03/26
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If
            '// NO変更された移動元の営業車輌マスタの更新
            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,交代時間 = NULL "
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に営業所移動で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元部署コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,新車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub
    '******************************************************************************
    ' 関 数 名  : msubUpdate会社間減車
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの会社間移動減車処理
    ' 備　　考  : 減車の対象になった車輌は、整理番号と無線番号がNULLになる
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  ＫＳＲ             最終無線番号の転送を追加
    '******************************************************************************
    Private Sub msubUpdate会社間減車(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = NULL"
            strSQL = strSQL & Chr(10) & "   ,備考     = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'" '// 2010/03/24
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then
                '// 基本的に減車する車輌で営業車輌マスタが存在しないケースはありえないのでここのINSERTは実行されることはない
                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        If objUpdate.m増車済みフラグ <> "" Then
            Exit Sub
        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = NULL "
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL "
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL "
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL "
            strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = NULL "
            '        strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '3'"
            '    strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate会社間増車
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの会社間移動増車処理
    ' 備　　考  : 増車の対象になった車輌は、整理番号と無線番号がNULLになる
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/24  ＫＳＲ             会社間移動減車された際に、最終無線番号が転送されているため、増車時にNULLにする
    '******************************************************************************
    Private Sub msubUpdate会社間増車(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        strSQL = strSQL & strValSQL

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & " 車名= '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & " 年式= '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & ",エンジン型式= '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & ",車体番号= '" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & ",型式= '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & ",区分= '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & ",車輌区分= '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",ファースト= '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & ",登録年月日= '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & ",車輌本体価格= '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & ",取得税= '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & ",エアコン価格= '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & ",料金メーター価格= '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & ",タコメーター価格= '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & ",その他費用= '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & ",状態区分= '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & ",所属コード= '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & ",車輌登録所属コード= '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & ",整理番号= '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & ",本務者コード１= '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額１= '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & ",償却利息１= '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & ",償却累計額１= '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & ",ＡＴ償却費１= '" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & ",本務者コード２= '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額２= '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & ",償却利息２= '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & ",償却累計額２= '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & ",ＡＴ償却費２= '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & ",償却満額= '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & ",電話番号= '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & ",無線番号= '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & ",保険会社= '" & objUpdate.m保険会社名 & "'"
            strSQL = strSQL & Chr(10) & ",自動車保険満期日= '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者名漢字= '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者名カナ= '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者郵便番号１= '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者郵便番号２= '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者都道府県漢字= '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者市区郡漢字= '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者町村番地漢字= '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者号棟漢字= '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者都道府県カナ= '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者市区郡カナ= '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者町村番地カナ= '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",保険申込者号棟カナ= '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & ",次回定期点検日= '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & ",次回車検日= '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & ",代替予定日= '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & ",営業所出庫日= '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & ",整備入庫日= '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & ",営業所入庫予定日= '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & ",整備完了日= '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & ",営業所入庫日= '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & ",廃車日= NULL "
            strSQL = strSQL & Chr(10) & ",自賠責登録番号= '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & ",自賠責保険料= '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & ",重量税= '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & ",自動車税= '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & ",自動車登録番号= '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & ",検査証有効期限= '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & ",備考= '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & ",燃費= '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & ",更新従業員コード= '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & ",更新日付時刻= SYSDATE"
            strSQL = strSQL & Chr(10) & ",交代時間= '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & ",最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & ",会社コード= '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & ",車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",車輌登録会社コード= '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & ",償却日額大月= '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額小月= '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額３月= '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & ",燃料区分= '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & ",用途区分= '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & ",償却日額閏月= '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号地区コード= '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号１= '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号２= '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & ",新車輌番号３= '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & ",旧車体番号= '" & objUpdate.m車体番号 & "'"
            strSQL = strSQL & Chr(10) & ",旧車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",新車種コード= '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & ",旧陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",新陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",入力状態= '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & ",型式１= '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & ",型式２= '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & ",型式３= '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & ",燃料= '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & ",陸事車輌区分= '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & ",任意保険番号= '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & ",使用者コード= '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & ",車検使用者コード= '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & ",車検所有者コード= '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & ",輸送切替日= '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & ",乗車定員= '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & " AND 車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号１         = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号２         = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & " AND 車輌番号３         = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL "
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   , NULL "
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '    strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            If objUpdate.m車輌マスタ更新区分会社移動 = "1" Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
                'strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
                'strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
                strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
                strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
                'strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
                strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                    strSQL = "" : strValSQL = ""
                    strSQL = strSQL & Chr(10) & "INSERT INTO 車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                    strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                    strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                    strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                    strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                    strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                    strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                    strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                    strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                    strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                    '                strSQL = strSQL & Chr(10) & "   ,最終無線番号":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,入力番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号地区コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                    strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                    strSQL = strSQL & Chr(10) & "   ,解体報告日付" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m解体報告日付 & "'"
                    strSQL = strSQL & Chr(10) & "   ,移動報告番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m移動報告番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                    strSQL = strSQL & Chr(10) & "   ,増車代替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m指示内容区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,切替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌状態 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,売却先情報":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                    strSQL = strSQL & Chr(10) & "   ,ナンバー色区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mナンバー色区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,メーカーコード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mメーカーコード & "'"
                    strSQL = strSQL & Chr(10) & "   ,所有区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所有区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,リース会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリース会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,初回登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m初回登録年月日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,リサイクル料金" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリサイクル料金 & "'"
                    strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                    strSQL = strSQL & strValSQL

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

            Else

                strSQL = ""
                strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
                'strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
                strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
                'strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
                '            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
                strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
                strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
                'strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
                strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                    strSQL = "" : strValSQL = ""
                    strSQL = strSQL & Chr(10) & "INSERT INTO 車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                    strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                    strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                    strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                    strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                    strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                    strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                    strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                    strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                    strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                    strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                    '                strSQL = strSQL & Chr(10) & "   ,最終無線番号":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,入力番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号地区コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                    strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                    strSQL = strSQL & Chr(10) & "   ,解体報告日付" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m解体報告日付 & "'"
                    strSQL = strSQL & Chr(10) & "   ,移動報告番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m移動報告番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                    strSQL = strSQL & Chr(10) & "   ,増車代替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m指示内容区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,切替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌状態 & "'"
                    'strSQL = strSQL & Chr(10) & "   ,売却先情報":                   strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                    strSQL = strSQL & Chr(10) & "   ,ナンバー色区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mナンバー色区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,メーカーコード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mメーカーコード & "'"
                    strSQL = strSQL & Chr(10) & "   ,所有区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所有区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,リース会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリース会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,初回登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m初回登録年月日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,リサイクル料金" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリサイクル料金 & "'"
                    strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                    strSQL = strSQL & strValSQL

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

            End If

            '        Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate社用車切替
    ' スコープ  : Private
    ' 処理内容  : 保留車輌から社用車に切り替える処理(車輌状態="2"になります)
    ' 備　　考  : 営業車輌マスタの更新は発生しません
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate社用車切替(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL "
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            'strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL "
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            'strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            'strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m廃車日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & "   ,解体報告日付" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m解体報告日付 & "'"
                strSQL = strSQL & Chr(10) & "   ,移動報告番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m移動報告番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                strSQL = strSQL & Chr(10) & "   ,増車代替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m指示内容区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,切替区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m切替区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌状態 & "'"
                strSQL = strSQL & Chr(10) & "   ,ナンバー色区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mナンバー色区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,メーカーコード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mメーカーコード & "'"
                strSQL = strSQL & Chr(10) & "   ,所有区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所有区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,リース会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリース会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,初回登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m初回登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,リサイクル料金" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mリサイクル料金 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate廃車
    ' スコープ  : Private
    ' 処理内容  : 保留車輌から廃車に切り替える処理(車輌状態="5"になります)
    ' 備　　考  : 営業車輌マスタの更新は発生しません
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate廃車(ByRef objUpdate As 車輌情報)

        Dim strSQL As String

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate売却
    ' スコープ  : Private
    ' 処理内容  : 保留車輌から売却に切り替える処理(車輌状態="4"になります)
    ' 備　　考  : 営業車輌マスタの更新は発生しません
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate売却(ByRef objUpdate As 車輌情報)

        Dim strSQL As String

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    廃車日 = '" & objUpdate.m廃車日 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & objUpdate.m売却先情報 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdate保留車切替
    ' スコープ  : Private
    ' 処理内容  : 社用車から保留車に切り替える処理(車輌状態="3"になります)
    ' 備　　考  : 営業車輌マスタの更新は発生しません
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate保留車切替(ByRef objUpdate As 車輌情報)

        Dim strSQL As String

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号地区コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = NULL"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = 車輌番号地区コード"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = 車輌番号１"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = 車輌番号２"
            strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = 車輌番号３"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = NULL"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = NULL"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = NULL"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = NULL"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '営業車輌マスタに車体番号で更新する処理を追加する必要有？

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : msubUpdateマスタメンテ
    ' スコープ  : Private
    ' 処理内容  : 車輌マスタと営業車輌マスタの更新処理
    ' 備　　考  : 車輌マスタ更新区分車輌メンテ="1"の場合は、物理的な削除処理を行います
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdateマスタメンテ(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String

        '// 車輌マスタと営業車輌マスタの物理的な削除
        If objUpdate.m車輌マスタ更新区分車輌メンテ = "1" Then

            '// 車輌マスタの削除
            If objUpdate.m処理対象フラグ = "1" Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "DELETE FROM 車輌マスタ"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// 営業車輌マスタの削除
            If objUpdate.m処理対象フラグ = "2" Then

                If objUpdate.m車輌状態 = "1" Then

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "DELETE FROM 営業車輌マスタ"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
                    strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
                    strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
                    strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

            End If

        Else
            '// 車輌マスタと営業車輌マスタの更新処理
            '// 車輌マスタの更新
            If objUpdate.m処理対象フラグ = "1" Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
                'strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
                'strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
                strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
                strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,切替区分 = '" & objUpdate.m切替区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌状態 = '" & objUpdate.m車輌状態 & "'"
                'strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
                strSQL = strSQL & Chr(10) & "WHERE"
                strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            '// 営業車輌マスタの更新
            If objUpdate.m処理対象フラグ = "2" Then

                If objUpdate.m車輌状態 = "1" Then

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
                    strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
                    strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
                    strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
                    strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
                    strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
                    strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
                    strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
                    strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,廃車日 = '" & objUpdate.m廃車日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
                    strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
                    strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
                    strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
                    strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号１ & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号２ & "'"
                    '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号３ & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
                    strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
                    strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
                    strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
                    strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
                    strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
                    strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
                    strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
                    strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
                    strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
                    strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gobjOraDatabase.ExecuteSQL(strSQL) = 0 Then

                        strSQL = "" : strValSQL = ""
                        strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                        strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                        strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                        strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                        strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                        strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                        strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                        strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                        strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                        strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                        strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                        strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                        strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                        strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                        strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社 & "'"
                        strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                        strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m廃車日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                        strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                        strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                        strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                        strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                        strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                        strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                        strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                        strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                        strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                        strSQL = strSQL & Chr(10) & "   ,旧車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,旧車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車種コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,新車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元陸事車輌区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,入力状態" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m入力状態 & "'"
                        '    strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                        strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                        strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                        strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                        strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                        strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                        strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                        strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                        strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                        strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                        strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                        strSQL = strSQL & strValSQL

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                    End If

                End If

            End If

        End If

    End Sub
    '******************************************************************************
    ' 関 数 名  : msubUpdate保留増車
    ' スコープ  : Private
    ' 処理内容  : 営業車輌マスタと車輌マスタの保留車からの増車処理
    ' 備　　考  : 増車の対象になった車輌は、それぞれのマスタにUPDATEが行われる
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   objUpdate                           　I     車輌異動テーブルより取得した値
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '
    '******************************************************************************
    Private Sub msubUpdate保留増車(ByRef objUpdate As 車輌情報)

        Dim strSQL As String
        Dim strValSQL As String
        Dim intRet As Short

        '// 営業車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "1" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 営業車輌マスタ SET"
            '        strSQL = strSQL & Chr(10) & "    車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "    年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,車体番号 = '" & objUpdate.m車体番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社名 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL "
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = NULL "
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号１ = '" & objUpdate.m旧車輌番号１ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号２ = '" & objUpdate.m旧車輌番号２ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車輌番号３ = '" & objUpdate.m旧車輌番号３ & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧車体番号 = '" & objUpdate.m元車体番号 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧車種コード = '" & objUpdate.m元車種コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新車種コード = '" & objUpdate.m車種コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分 = '" & objUpdate.m元陸事車輌区分 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            '        strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            '        strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "AND 車輌番号３ = '" & objUpdate.m車輌番号3 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            intRet = gobjOraDatabase.ExecuteSQL(strSQL)

            If intRet = 0 Then

                strSQL = "" : strValSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO 営業車輌マスタ (" : strValSQL = strValSQL & Chr(10) & "VALUES ("
                strSQL = strSQL & Chr(10) & "    車輌番号地区コード" : strValSQL = strValSQL & Chr(10) & "    '" & objUpdate.m車輌番号地区コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌番号３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号3 & "'"
                strSQL = strSQL & Chr(10) & "   ,車名" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車名 & "'"
                strSQL = strSQL & Chr(10) & "   ,年式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m年式 & "'"
                strSQL = strSQL & Chr(10) & "   ,エンジン型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエンジン型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,車体番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車体番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式 & "'"
                strSQL = strSQL & Chr(10) & "   ,区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,ファースト" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mファースト & "'"
                strSQL = strSQL & Chr(10) & "   ,登録年月日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m登録年月日 & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌本体価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌本体価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,取得税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m取得税 & "'"
                strSQL = strSQL & Chr(10) & "   ,エアコン価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mエアコン価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,料金メーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m料金メーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,タコメーター価格" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mタコメーター価格 & "'"
                strSQL = strSQL & Chr(10) & "   ,その他費用" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mその他費用 & "'"
                strSQL = strSQL & Chr(10) & "   ,状態区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m状態区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録所属コード & "'"
                strSQL = strSQL & Chr(10) & "   ,整理番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整理番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息1 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額1 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費1 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,償却残日数１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数１ & "'"
                strSQL = strSQL & Chr(10) & "   ,本務者コード２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m本務者コード2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却利息２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却利息2 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却累計額２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却累計額2 & "'"
                strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.mAT償却費2 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,償却残日数２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却残日数２ & "'"
                strSQL = strSQL & Chr(10) & "   ,償却満額" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却満額 & "'"
                strSQL = strSQL & Chr(10) & "   ,電話番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m電話番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険会社" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険会社名 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車保険満期日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車保険満期日 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者名カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号1 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者郵便番号2 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟漢字 & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者都道府県カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者市区郡カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者町村番地カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m保険申込者号棟カナ & "'"
                strSQL = strSQL & Chr(10) & "   ,次回定期点検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回定期点検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,次回車検日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m次回車検日 & "'"
                strSQL = strSQL & Chr(10) & "   ,代替予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m代替予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所出庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所出庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫予定日 & "'"
                strSQL = strSQL & Chr(10) & "   ,整備完了日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m整備完了日 & "'"
                strSQL = strSQL & Chr(10) & "   ,営業所入庫日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m営業所入庫日 & "'"
                strSQL = strSQL & Chr(10) & "   ,廃車日" : strValSQL = strValSQL & Chr(10) & "   ,NULL"
                strSQL = strSQL & Chr(10) & "   ,自賠責登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,自賠責保険料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自賠責保険料 & "'"
                strSQL = strSQL & Chr(10) & "   ,重量税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m重量税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車税" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車税 & "'"
                strSQL = strSQL & Chr(10) & "   ,自動車登録番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m自動車登録番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,検査証有効期限" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m検査証有効期限 & "'"
                strSQL = strSQL & Chr(10) & "   ,備考" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m備考 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃費" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃費 & "'"
                strSQL = strSQL & Chr(10) & "   ,更新従業員コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & gclsLoginInfo.EmployeeCode & "'"
                strSQL = strSQL & Chr(10) & "   ,更新日付時刻" : strValSQL = strValSQL & Chr(10) & "   ,SYSDATE"
                strSQL = strSQL & Chr(10) & "   ,交代時間" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m交代時間 & "'"
                strSQL = strSQL & Chr(10) & "   ,最終無線番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m最終無線番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車種コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌登録会社コード & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額大月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額大月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額小月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額小月 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額３月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額3月 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,用途区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m用途区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,償却日額閏月" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m償却日額閏月 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,新車輌番号地区コード":         strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号地区コード & "'"
                '        strSQL = strSQL & Chr(10) & "   ,新車輌番号１":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号１ & "'"
                '        strSQL = strSQL & Chr(10) & "   ,新車輌番号２":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号２ & "'"
                '        strSQL = strSQL & Chr(10) & "   ,新車輌番号３":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車輌番号３ & "'"
                '        strSQL = strSQL & Chr(10) & "   ,旧車体番号":                   strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m元車体番号 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,旧車種コード":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                '        strSQL = strSQL & Chr(10) & "   ,新車種コード":                 strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車種コード & "'"
                '        strSQL = strSQL & Chr(10) & "   ,旧陸事車輌区分":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,新陸事車輌区分":               strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                '        strSQL = strSQL & Chr(10) & "   ,入力状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                '        strSQL = strSQL & Chr(10) & "   ,変更状態":                     strValSQL = strValSQL & Chr(10) & "   ,'" & "" & "'"
                strSQL = strSQL & Chr(10) & "   ,型式１" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式1 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式２" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式2 & "'"
                strSQL = strSQL & Chr(10) & "   ,型式３" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m型式3 & "'"
                strSQL = strSQL & Chr(10) & "   ,燃料" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m燃料 & "'"
                strSQL = strSQL & Chr(10) & "   ,陸事車輌区分" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m陸事車輌区分 & "'"
                strSQL = strSQL & Chr(10) & "   ,任意保険番号" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m任意保険番号 & "'"
                strSQL = strSQL & Chr(10) & "   ,使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検使用者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検使用者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,車検所有者コード" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m車検所有者コード & "'"
                strSQL = strSQL & Chr(10) & "   ,輸送切替日" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m輸送切替日 & "'"
                strSQL = strSQL & Chr(10) & "   ,乗車定員" : strValSQL = strValSQL & Chr(10) & "   ,'" & objUpdate.m乗車定員 & "'"
                strSQL = strSQL & Chr(10) & ")" : strValSQL = strValSQL & Chr(10) & ")"

                strSQL = strSQL & strValSQL

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

        End If

        '// 車輌マスタのみの更新
        If objUpdate.m処理対象フラグ = "2" Then

            strSQL = ""
            strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ SET"
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & objUpdate.m車輌番号地区コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号１ = '" & objUpdate.m車輌番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号２ = '" & objUpdate.m車輌番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌番号３ = '" & objUpdate.m車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,車名 = '" & objUpdate.m車名 & "'"
            strSQL = strSQL & Chr(10) & "   ,年式 = '" & objUpdate.m年式 & "'"
            strSQL = strSQL & Chr(10) & "   ,エンジン型式 = '" & objUpdate.mエンジン型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式 = '" & objUpdate.m型式 & "'"
            strSQL = strSQL & Chr(10) & "   ,区分 = '" & objUpdate.m区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌区分 = '" & objUpdate.m車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,ファースト = '" & objUpdate.mファースト & "'"
            strSQL = strSQL & Chr(10) & "   ,登録年月日 = '" & objUpdate.m登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌本体価格 = '" & objUpdate.m車輌本体価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,取得税 = '" & objUpdate.m取得税 & "'"
            strSQL = strSQL & Chr(10) & "   ,エアコン価格 = '" & objUpdate.mエアコン価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,料金メーター価格 = '" & objUpdate.m料金メーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,タコメーター価格 = '" & objUpdate.mタコメーター価格 & "'"
            strSQL = strSQL & Chr(10) & "   ,その他費用 = '" & objUpdate.mその他費用 & "'"
            strSQL = strSQL & Chr(10) & "   ,状態区分 = '" & objUpdate.m状態区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,所属コード = '" & objUpdate.m所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & objUpdate.m車輌登録所属コード & "'"
            strSQL = strSQL & Chr(10) & "   ,整理番号 = '" & objUpdate.m整理番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード１ = '" & objUpdate.m本務者コード1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額１ = '" & objUpdate.m償却日額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息１ = '" & objUpdate.m償却利息1 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額１ = '" & objUpdate.m償却累計額1 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費１ = '" & objUpdate.mAT償却費1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数１ = '" & objUpdate.m償却残日数１ & "'"
            strSQL = strSQL & Chr(10) & "   ,本務者コード２ = '" & objUpdate.m本務者コード2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額２ = '" & objUpdate.m償却日額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却利息２ = '" & objUpdate.m償却利息2 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却累計額２ = '" & objUpdate.m償却累計額2 & "'"
            strSQL = strSQL & Chr(10) & "   ,ＡＴ償却費２ = '" & objUpdate.mAT償却費2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,償却残日数２ = '" & objUpdate.m償却残日数２ & "'"
            strSQL = strSQL & Chr(10) & "   ,償却満額 = '" & objUpdate.m償却満額 & "'"
            strSQL = strSQL & Chr(10) & "   ,電話番号 = '" & objUpdate.m電話番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,無線番号 = '" & objUpdate.m無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険会社 = '" & objUpdate.m保険会社 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車保険満期日 = '" & objUpdate.m自動車保険満期日 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名漢字 = '" & objUpdate.m保険申込者名漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者名カナ = '" & objUpdate.m保険申込者名カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号１ = '" & objUpdate.m保険申込者郵便番号1 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者郵便番号２ = '" & objUpdate.m保険申込者郵便番号2 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県漢字 = '" & objUpdate.m保険申込者都道府県漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡漢字 = '" & objUpdate.m保険申込者市区郡漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地漢字 = '" & objUpdate.m保険申込者町村番地漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟漢字 = '" & objUpdate.m保険申込者号棟漢字 & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者都道府県カナ = '" & objUpdate.m保険申込者都道府県カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者市区郡カナ = '" & objUpdate.m保険申込者市区郡カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者町村番地カナ = '" & objUpdate.m保険申込者町村番地カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,保険申込者号棟カナ = '" & objUpdate.m保険申込者号棟カナ & "'"
            strSQL = strSQL & Chr(10) & "   ,次回定期点検日 = '" & objUpdate.m次回定期点検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,次回車検日 = '" & objUpdate.m次回車検日 & "'"
            strSQL = strSQL & Chr(10) & "   ,代替予定日 = '" & objUpdate.m代替予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所出庫日 = '" & objUpdate.m営業所出庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備入庫日 = '" & objUpdate.m整備入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫予定日 = '" & objUpdate.m営業所入庫予定日 & "'"
            strSQL = strSQL & Chr(10) & "   ,整備完了日 = '" & objUpdate.m整備完了日 & "'"
            strSQL = strSQL & Chr(10) & "   ,営業所入庫日 = '" & objUpdate.m営業所入庫日 & "'"
            strSQL = strSQL & Chr(10) & "   ,廃車日 = NULL"
            strSQL = strSQL & Chr(10) & "   ,自賠責登録番号 = '" & objUpdate.m自賠責登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,自賠責保険料 = '" & objUpdate.m自賠責保険料 & "'"
            strSQL = strSQL & Chr(10) & "   ,重量税 = '" & objUpdate.m重量税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車税 = '" & objUpdate.m自動車税 & "'"
            strSQL = strSQL & Chr(10) & "   ,自動車登録番号 = '" & objUpdate.m自動車登録番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,検査証有効期限 = '" & objUpdate.m検査証有効期限 & "'"
            strSQL = strSQL & Chr(10) & "   ,備考 = '" & objUpdate.m備考 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃費 = '" & objUpdate.m燃費 & "'"
            strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
            strSQL = strSQL & Chr(10) & "   ,交代時間 = '" & objUpdate.m交代時間 & "'"
            strSQL = strSQL & Chr(10) & "   ,最終無線番号 = '" & objUpdate.m最終無線番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,会社コード = '" & objUpdate.m会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車種コード = '" & objUpdate.m車種コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & objUpdate.m車輌登録会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額大月 = '" & objUpdate.m償却日額大月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額小月 = '" & objUpdate.m償却日額小月 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額３月 = '" & objUpdate.m償却日額3月 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料区分 = '" & objUpdate.m燃料区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,用途区分 = '" & objUpdate.m用途区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,償却日額閏月 = '" & objUpdate.m償却日額閏月 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力番号 = '" & objUpdate.m入力番号 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧車輌番号地区コード = '" & objUpdate.m旧車輌番号地区コード & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧車輌番号１ = '" & objUpdate.m旧車輌番号1 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧車輌番号２ = '" & objUpdate.m旧車輌番号2 & "'"
            '    strSQL = strSQL & Chr(10) & "   ,旧車輌番号３ = '" & objUpdate.m旧車輌番号3 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式１ = '" & objUpdate.m型式1 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式２ = '" & objUpdate.m型式2 & "'"
            strSQL = strSQL & Chr(10) & "   ,型式３ = '" & objUpdate.m型式3 & "'"
            strSQL = strSQL & Chr(10) & "   ,燃料 = '" & objUpdate.m燃料 & "'"
            strSQL = strSQL & Chr(10) & "   ,陸事車輌区分 = '" & objUpdate.m陸事車輌区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,任意保険番号 = '" & objUpdate.m任意保険番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,使用者コード = '" & objUpdate.m使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検使用者コード = '" & objUpdate.m車検使用者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,車検所有者コード = '" & objUpdate.m車検所有者コード & "'"
            strSQL = strSQL & Chr(10) & "   ,切替日 = '" & objUpdate.m切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,輸送切替日 = '" & objUpdate.m輸送切替日 & "'"
            strSQL = strSQL & Chr(10) & "   ,乗車定員 = '" & objUpdate.m乗車定員 & "'"
            strSQL = strSQL & Chr(10) & "   ,解体報告日付 = '" & objUpdate.m解体報告日付 & "'"
            strSQL = strSQL & Chr(10) & "   ,移動報告番号 = '" & objUpdate.m移動報告番号 & "'"
            strSQL = strSQL & Chr(10) & "   ,入力状態 = '" & objUpdate.m入力状態 & "'"
            strSQL = strSQL & Chr(10) & "   ,増車代替区分 = '" & objUpdate.m指示内容区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,切替区分 = '1'"
            strSQL = strSQL & Chr(10) & "   ,車輌状態 = '1'"
            '    strSQL = strSQL & Chr(10) & "   ,売却先情報 = '" & "" & "'"
            strSQL = strSQL & Chr(10) & "   ,ナンバー色区分 = '" & objUpdate.mナンバー色区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,メーカーコード = '" & objUpdate.mメーカーコード & "'"
            strSQL = strSQL & Chr(10) & "   ,所有区分 = '" & objUpdate.m所有区分 & "'"
            strSQL = strSQL & Chr(10) & "   ,リース会社コード = '" & objUpdate.mリース会社コード & "'"
            strSQL = strSQL & Chr(10) & "   ,初回登録年月日 = '" & objUpdate.m初回登録年月日 & "'"
            strSQL = strSQL & Chr(10) & "   ,リサイクル料金 = '" & objUpdate.mリサイクル料金 & "'"
            strSQL = strSQL & Chr(10) & "WHERE"
            strSQL = strSQL & Chr(10) & "    車体番号 = '" & objUpdate.m車体番号 & "'"

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

        End If

    End Sub

    '******************************************************************************
    ' 関 数 名  : gsubUpdateNewShopCarTransfer
    ' スコープ  : Private
    ' 処理内容  : 新部署が作成された場合に、増車されている車輌の車輌マスタと営業車輌マスタを作成する
    '             為の処理
    ' 備　　考  : ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstr会社             String        　   I     今回処理を行う対象の会社コード
    '   pstr部署             String        　   I     今回処理を行う対象の部署コード
    '   pstr営業日報日       String             I     今回処理を行う対象の営業日報日(yyyymmdd形式)
    '   pstr実行フラグ       String             I     1:車輌マスタのみ更新 2:営業車輌マスタのみ更新 3:どちらも更新
    '   pstrステータス       String            I/O    どの段階まで処理がすすんでいるかをセット
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2009/10/22  ＫＳＲ             新規作成
    '               2010/05/31  ＫＳＲ             本務者履歴テーブルから参照する区分を切替区分から車輌マスタ反映区分に変更する
    '******************************************************************************
    Public Function gsubUpdateNewShopCarTransfer(ByVal pstr会社 As String, ByVal pstr部署 As String, ByVal pstr営業日報日 As String, ByVal pstr実行フラグ As String, ByRef pstrステータス As String, ByVal pstrSEQ As String) As Object

        Dim strSQL As String
        Dim objDynaset As Object
        Dim objUpdataParam As 車輌情報

        pstrステータス = "車輌異動テーブルから対象データ抽出"
        strSQL = ""
        If pstr実行フラグ = "1" Or pstr実行フラグ = "3" Then
            '// 車輌マスタの更新の終わっていない車輌異動テーブル
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.車体番号                               ,CPT.指示内容区分                           ,CPT.車輌番号地区コード                     ,CPT.車輌番号１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌番号２                             ,CPT.車輌番号３                             ,CPT.車名                                   ,CPT.年式                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.エンジン型式                           ,CPT.型式                                   ,CPT.区分                                   ,CPT.車輌区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.燃料コード                             ,CPT.ファースト                             ,CPT.登録年月日                             ,CPT.車輌本体価格                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.取得税                                 ,CPT.エアコン価格                           ,CPT.料金メーター価格                       ,CPT.タコメーター価格                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.その他費用                             ,CPT.状態区分                               ,CPT.所属コード                             ,CPT.車輌登録所属コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.整理番号                               ,CPT.本務者コード１                         ,CPT.償却日額１                             ,CPT.償却利息１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却累計額１                           ,CPT.ＡＴ償却費１                           ,CPT.償却残日数１                           ,CPT.本務者コード２                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額２                             ,CPT.償却利息２                             ,CPT.償却累計額２                           ,CPT.ＡＴ償却費２                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却残日数２                           ,CPT.償却満額                               ,CPT.電話番号                               ,CPT.無線番号                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険会社                               ,CPT.自動車保険満期日                       ,CPT.保険申込者名漢字                       ,CPT.保険申込者名カナ                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者郵便番号１                   ,CPT.保険申込者郵便番号２                   ,CPT.保険申込者都道府県漢字                 ,CPT.保険申込者市区郡漢字                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地漢字                 ,CPT.保険申込者号棟漢字                     ,CPT.保険申込者都道府県カナ                 ,CPT.保険申込者市区郡カナ                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地カナ                 ,CPT.保険申込者号棟カナ                     ,CPT.次回定期点検日                         ,CPT.次回車検日                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.代替予定日                             ,CPT.営業所出庫日                           ,CPT.整備入庫日                             ,CPT.営業所入庫予定日                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.整備完了日                             ,CPT.営業所入庫日                           ,CPT.廃車日                                 ,CPT.自賠責登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.自賠責保険料                           ,CPT.重量税                                 ,CPT.自動車税                               ,CPT.自動車登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.検査証有効期限                         ,CPT.備考                                   ,CPT.燃費                                   ,CPT.交代時間                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.最終無線番号                           ,CPT.会社コード                             ,CPT.車種コード                             ,CPT.車輌登録会社コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額大月                           ,CPT.償却日額小月                           ,CPT.償却日額３月                           ,CPT.燃料区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.用途区分                               ,CPT.償却日額閏月                           ,CPT.入力番号                               ,CPT.旧車輌番号地区コード                "
            strSQL = strSQL & Chr(10) & "   ,CPT.旧車輌番号１                           ,CPT.旧車輌番号２                           ,CPT.旧車輌番号３                           ,CPT.型式１                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.型式２                                 ,CPT.型式３                                 ,CPT.燃料                                   ,CPT.陸事車輌区分                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.任意保険番号                           ,CPT.使用者コード                           ,CPT.車検使用者コード                       ,CPT.車検所有者コード                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.切替日                                 ,CPT.輸送切替日                             ,CPT.乗車定員                               ,CPT.解体報告日付                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.移動報告番号                           ,CPT.入力状態                               ,CPT.増車代替区分                           ,CPT.切替区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌状態                               ,CPT.車輌計画処理SEQ                        ,CPT.車輌登録フラグ                         ,CPT.日報確定日時                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.売却先情報                             ,CPT.元会社コード                           ,CPT.元部署コード                           ,CPT.元営業車輌区分                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.元陸事車輌区分                         ,CPT.元切替日                               ,CPT.元車種コード                           ,CPT.元車体番号                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分増車                 ,CPT.車輌マスタ更新区分代替                 ,CPT.車輌マスタ更新区分営業移動             ,CPT.車輌マスタ更新区分会社移動          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分車輌メンテ           ,CPL.相手側車輌計画処理SEQ                  ,PT2.車輌計画処理SEQ CSEQ                   ,PT2.切替日 C切替日                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.日報確定日時 増車済みフラグ         "
            strSQL = strSQL & Chr(10) & "   ,'2' AS 処理対象フラグ " '// 1:営業車輌マスタ更新対象    2:車輌マスタ更新対象
            strSQL = strSQL & Chr(10) & "   ,CPT.ナンバー色区分 ,CPT.メーカーコード ,CPT.所有区分 "
            strSQL = strSQL & Chr(10) & "   ,CPT.リース会社コード ,CPT.初回登録年月日 ,CPT.リサイクル料金 "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    車輌異動テーブル CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌計画入力テーブル CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.車輌計画処理SEQ = CPL.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌異動テーブル PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.相手側車輌計画処理SEQ = PT2.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN 部署マスタ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.会社コード = BMM.会社コード"
            strSQL = strSQL & Chr(10) & "AND CPT.所属コード = BMM.所属コード"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.車輌登録フラグ = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.車輌マスタ日報確定日時 IS NULL"
            '// 増車、保留増車については無線番号と整理番号<>NULL を追加
            strSQL = strSQL & Chr(10) & "AND  (CPT.指示内容区分 IN ('0','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.無線番号 IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.整理番号 IS NOT NULL ) "

            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.車輌計画処理SEQ = '" & pstrSEQ & "'"
            Else
                strSQL = strSQL & Chr(10) & "AND CPT.切替日 <= ('" & pstr営業日報日 & "') "
                '// 夜間バッチ時は、全会社を対象にする
                If pstr会社 <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.会社コード = '" & gfncGetCodeToControl(pstr会社, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.所属コード = '" & gfncGetCodeToControl(pstr部署, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.営業区分 = '0'))"
                End If

            End If

        End If

        If pstr実行フラグ = "3" Then
            strSQL = strSQL & Chr(10) & "UNION ALL ( "
        End If

        If pstr実行フラグ = "2" Or pstr実行フラグ = "3" Then
            '// 営業車輌マスタの更新の終わっていない車輌異動テーブル
            strSQL = strSQL & Chr(10) & "SELECT"
            strSQL = strSQL & Chr(10) & "    CPT.車体番号                               ,CPT.指示内容区分                           ,CPT.車輌番号地区コード                     ,CPT.車輌番号１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌番号２                             ,CPT.車輌番号３                             ,CPT.車名                                   ,CPT.年式                                "
            strSQL = strSQL & Chr(10) & "   ,CPT.エンジン型式                           ,CPT.型式                                   ,CPT.区分                                   ,CPT.車輌区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.燃料コード                             ,CPT.ファースト                             ,CPT.登録年月日                             ,CPT.車輌本体価格                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.取得税                                 ,CPT.エアコン価格                           ,CPT.料金メーター価格                       ,CPT.タコメーター価格                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.その他費用                             ,CPT.状態区分                               ,CPT.所属コード                             ,CPT.車輌登録所属コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.整理番号                               ,CPT.本務者コード１                         ,CPT.償却日額１                             ,CPT.償却利息１                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却累計額１                           ,CPT.ＡＴ償却費１                           ,CPT.償却残日数１                           ,CPT.本務者コード２                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額２                             ,CPT.償却利息２                             ,CPT.償却累計額２                           ,CPT.ＡＴ償却費２                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却残日数２                           ,CPT.償却満額                               ,CPT.電話番号                               ,CPT.無線番号                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険会社                               ,CPT.自動車保険満期日                       ,CPT.保険申込者名漢字                       ,CPT.保険申込者名カナ                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者郵便番号１                   ,CPT.保険申込者郵便番号２                   ,CPT.保険申込者都道府県漢字                 ,CPT.保険申込者市区郡漢字                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地漢字                 ,CPT.保険申込者号棟漢字                     ,CPT.保険申込者都道府県カナ                 ,CPT.保険申込者市区郡カナ                "
            strSQL = strSQL & Chr(10) & "   ,CPT.保険申込者町村番地カナ                 ,CPT.保険申込者号棟カナ                     ,CPT.次回定期点検日                         ,CPT.次回車検日                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.代替予定日                             ,CPT.営業所出庫日                           ,CPT.整備入庫日                             ,CPT.営業所入庫予定日                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.整備完了日                             ,CPT.営業所入庫日                           ,CPT.廃車日                                 ,CPT.自賠責登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.自賠責保険料                           ,CPT.重量税                                 ,CPT.自動車税                               ,CPT.自動車登録番号                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.検査証有効期限                         ,CPT.備考                                   ,CPT.燃費                                   ,CPT.交代時間                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.最終無線番号                           ,CPT.会社コード                             ,CPT.車種コード                             ,CPT.車輌登録会社コード                  "
            strSQL = strSQL & Chr(10) & "   ,CPT.償却日額大月                           ,CPT.償却日額小月                           ,CPT.償却日額３月                           ,CPT.燃料区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.用途区分                               ,CPT.償却日額閏月                           ,CPT.入力番号                               ,CPT.旧車輌番号地区コード                "
            strSQL = strSQL & Chr(10) & "   ,CPT.旧車輌番号１                           ,CPT.旧車輌番号２                           ,CPT.旧車輌番号３                           ,CPT.型式１                              "
            strSQL = strSQL & Chr(10) & "   ,CPT.型式２                                 ,CPT.型式３                                 ,CPT.燃料                                   ,CPT.陸事車輌区分                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.任意保険番号                           ,CPT.使用者コード                           ,CPT.車検使用者コード                       ,CPT.車検所有者コード                    "
            strSQL = strSQL & Chr(10) & "   ,CPT.切替日                                 ,CPT.輸送切替日                             ,CPT.乗車定員                               ,CPT.解体報告日付                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.移動報告番号                           ,CPT.入力状態                               ,CPT.増車代替区分                           ,CPT.切替区分                            "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌状態                               ,CPT.車輌計画処理SEQ                        ,CPT.車輌登録フラグ                         ,CPT.日報確定日時                        "
            strSQL = strSQL & Chr(10) & "   ,CPT.売却先情報                             ,CPT.元会社コード                           ,CPT.元部署コード                           ,CPT.元営業車輌区分                      "
            strSQL = strSQL & Chr(10) & "   ,CPT.元陸事車輌区分                         ,CPT.元切替日                               ,CPT.元車種コード                           ,CPT.元車体番号                          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分増車                 ,CPT.車輌マスタ更新区分代替                 ,CPT.車輌マスタ更新区分営業移動             ,CPT.車輌マスタ更新区分会社移動          "
            strSQL = strSQL & Chr(10) & "   ,CPT.車輌マスタ更新区分車輌メンテ           ,CPL.相手側車輌計画処理SEQ                  ,PT2.車輌計画処理SEQ CSEQ                   ,PT2.切替日 C切替日                      "
            strSQL = strSQL & Chr(10) & "   ,TO_CHAR(SYSDATE + 1,'YYYYMMDD') CDATE      ,PT2.日報確定日時 増車済みフラグ         "
            strSQL = strSQL & Chr(10) & "   ,'1' AS 処理対象フラグ " '// 1:営業車輌マスタ更新対象    2:車輌マスタ更新対象
            strSQL = strSQL & Chr(10) & "   ,CPT.ナンバー色区分 ,CPT.メーカーコード ,CPT.所有区分 "
            strSQL = strSQL & Chr(10) & "   ,CPT.リース会社コード ,CPT.初回登録年月日 ,CPT.リサイクル料金 "
            strSQL = strSQL & Chr(10) & "FROM"
            strSQL = strSQL & Chr(10) & "    車輌異動テーブル CPT"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌計画入力テーブル CPL ON"
            strSQL = strSQL & Chr(10) & "    CPT.車輌計画処理SEQ = CPL.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "LEFT JOIN 車輌異動テーブル PT2 ON"
            strSQL = strSQL & Chr(10) & "    CPL.相手側車輌計画処理SEQ = PT2.車輌計画処理SEQ"
            strSQL = strSQL & Chr(10) & "INNER JOIN 部署マスタ BMM ON"
            strSQL = strSQL & Chr(10) & "    CPT.会社コード = BMM.会社コード"
            strSQL = strSQL & Chr(10) & "AND CPT.所属コード = BMM.所属コード"
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND CPT.車輌登録フラグ = '1'"
            strSQL = strSQL & Chr(10) & "AND CPT.日報確定日時 IS NULL"
            '// 増車、保留増車については無線番号と整理番号<>NULL を追加
            strSQL = strSQL & Chr(10) & "AND  (CPT.指示内容区分 IN ('0','11') "
            strSQL = strSQL & Chr(10) & "AND   CPT.無線番号 IS NOT NULL "
            strSQL = strSQL & Chr(10) & "AND   CPT.整理番号 IS NOT NULL ) "
            '// 画面から直接起動する場合は日付の条件をみずに車輌計画処理SEQでレコードを1件に特定して処理を行う
            If pstrSEQ <> "" Then
                strSQL = strSQL & Chr(10) & "AND CPT.車輌計画処理SEQ = '" & pstrSEQ & "'"
            Else
                strSQL = strSQL & Chr(10) & "AND CPT.切替日 <= ('" & pstr営業日報日 & "') "
                '// 夜間バッチ時は、全会社を対象にする
                If pstr会社 <> "" Then
                    strSQL = strSQL & Chr(10) & "AND ("
                    strSQL = strSQL & Chr(10) & "   (CPT.会社コード = '" & gfncGetCodeToControl(pstr会社, GC_LEN_COMPANY_CODE) & "'"
                    strSQL = strSQL & Chr(10) & "AND CPT.所属コード = '" & gfncGetCodeToControl(pstr部署, GC_LEN_POST_CODE) & "')"
                    strSQL = strSQL & Chr(10) & "OR (BMM.営業区分 = '0'))"
                End If
            End If
        End If

        If pstr実行フラグ = "3" Then
            strSQL = strSQL & Chr(10) & " ) "
        End If

        strSQL = strSQL & Chr(10) & "ORDER BY"
        strSQL = strSQL & Chr(10) & "    指示内容区分,車体番号 "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDynaset = gobjOraDatabase.CreateDynaset(strSQL, &H1)

        With objDynaset

            'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF = True Then
                pstrステータス = "車輌管理　日報確定該当なし"
                GoTo HONMUTUKEKOMI
            End If

            Do

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstrステータス = "車輌異動テーブル　該当SEQ：" & gfncFieldVal(.Fields("車輌計画処理SEQ").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車体番号 = gfncFieldVal(.Fields("車体番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m指示内容区分 = gfncFieldVal(.Fields("指示内容区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号地区コード = gfncFieldVal(.Fields("車輌番号地区コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号1 = gfncFieldVal(.Fields("車輌番号１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号2 = gfncFieldVal(.Fields("車輌番号２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌番号3 = gfncFieldVal(.Fields("車輌番号３").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車名 = gfncFieldVal(.Fields("車名").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m年式 = gfncFieldVal(.Fields("年式").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mエンジン型式 = gfncFieldVal(.Fields("エンジン型式").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式 = gfncFieldVal(.Fields("型式").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m区分 = gfncFieldVal(.Fields("区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌区分 = gfncFieldVal(.Fields("車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃料コード = gfncFieldVal(.Fields("燃料コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mファースト = gfncFieldVal(.Fields("ファースト").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m登録年月日 = gfncFieldVal(.Fields("登録年月日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌本体価格 = gfncFieldVal(.Fields("車輌本体価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m取得税 = gfncFieldVal(.Fields("取得税").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mエアコン価格 = gfncFieldVal(.Fields("エアコン価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m料金メーター価格 = gfncFieldVal(.Fields("料金メーター価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mタコメーター価格 = gfncFieldVal(.Fields("タコメーター価格").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mその他費用 = gfncFieldVal(.Fields("その他費用").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m状態区分 = gfncFieldVal(.Fields("状態区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m所属コード = gfncFieldVal(.Fields("所属コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌登録所属コード = gfncFieldVal(.Fields("車輌登録所属コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m整理番号 = gfncFieldVal(.Fields("整理番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m本務者コード1 = gfncFieldVal(.Fields("本務者コード１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額1 = gfncFieldVal(.Fields("償却日額１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却利息1 = gfncFieldVal(.Fields("償却利息１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却累計額1 = gfncFieldVal(.Fields("償却累計額１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT償却費1 = gfncFieldVal(.Fields("ＡＴ償却費１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却残日数1 = gfncFieldVal(.Fields("償却残日数１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m本務者コード2 = gfncFieldVal(.Fields("本務者コード２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額2 = gfncFieldVal(.Fields("償却日額２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却利息2 = gfncFieldVal(.Fields("償却利息２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却累計額2 = gfncFieldVal(.Fields("償却累計額２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mAT償却費2 = gfncFieldVal(.Fields("ＡＴ償却費２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却残日数2 = gfncFieldVal(.Fields("償却残日数２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却満額 = gfncFieldVal(.Fields("償却満額").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m電話番号 = gfncFieldVal(.Fields("電話番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m無線番号 = gfncFieldVal(.Fields("無線番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険会社 = gfncFieldVal(.Fields("保険会社").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険会社名 = mfncGetHokenName(gfncFieldVal(.Fields("保険会社").Value)) '// 2010/03/26 保険会社名の取得を追加
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自動車保険満期日 = gfncFieldVal(.Fields("自動車保険満期日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者名漢字 = gfncFieldVal(.Fields("保険申込者名漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者名カナ = gfncFieldVal(.Fields("保険申込者名カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者郵便番号1 = gfncFieldVal(.Fields("保険申込者郵便番号１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者郵便番号2 = gfncFieldVal(.Fields("保険申込者郵便番号２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者都道府県漢字 = gfncFieldVal(.Fields("保険申込者都道府県漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者市区郡漢字 = gfncFieldVal(.Fields("保険申込者市区郡漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者町村番地漢字 = gfncFieldVal(.Fields("保険申込者町村番地漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者号棟漢字 = gfncFieldVal(.Fields("保険申込者号棟漢字").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者都道府県カナ = gfncFieldVal(.Fields("保険申込者都道府県カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者市区郡カナ = gfncFieldVal(.Fields("保険申込者市区郡カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者町村番地カナ = gfncFieldVal(.Fields("保険申込者町村番地カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m保険申込者号棟カナ = gfncFieldVal(.Fields("保険申込者号棟カナ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m次回定期点検日 = gfncFieldVal(.Fields("次回定期点検日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m次回車検日 = gfncFieldVal(.Fields("次回車検日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m代替予定日 = gfncFieldVal(.Fields("代替予定日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m営業所出庫日 = gfncFieldVal(.Fields("営業所出庫日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m整備入庫日 = gfncFieldVal(.Fields("整備入庫日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m営業所入庫予定日 = gfncFieldVal(.Fields("営業所入庫予定日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m整備完了日 = gfncFieldVal(.Fields("整備完了日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m営業所入庫日 = gfncFieldVal(.Fields("営業所入庫日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m廃車日 = gfncFieldVal(.Fields("廃車日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自賠責登録番号 = gfncFieldVal(.Fields("自賠責登録番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自賠責保険料 = gfncFieldVal(.Fields("自賠責保険料").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m重量税 = gfncFieldVal(.Fields("重量税").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自動車税 = gfncFieldVal(.Fields("自動車税").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m自動車登録番号 = gfncFieldVal(.Fields("自動車登録番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m検査証有効期限 = gfncFieldVal(.Fields("検査証有効期限").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m備考 = gfncFieldVal(.Fields("備考").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃費 = gfncFieldVal(.Fields("燃費").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m交代時間 = gfncFieldVal(.Fields("交代時間").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m最終無線番号 = gfncFieldVal(.Fields("最終無線番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m会社コード = gfncFieldVal(.Fields("会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車種コード = gfncFieldVal(.Fields("車種コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌登録会社コード = gfncFieldVal(.Fields("車輌登録会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額大月 = gfncFieldVal(.Fields("償却日額大月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額小月 = gfncFieldVal(.Fields("償却日額小月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額3月 = gfncFieldVal(.Fields("償却日額３月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃料区分 = gfncFieldVal(.Fields("燃料区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m用途区分 = gfncFieldVal(.Fields("用途区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m償却日額閏月 = gfncFieldVal(.Fields("償却日額閏月").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m入力番号 = gfncFieldVal(.Fields("入力番号").Value, "1")
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号地区コード = gfncFieldVal(.Fields("旧車輌番号地区コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号1 = gfncFieldVal(.Fields("旧車輌番号１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号2 = gfncFieldVal(.Fields("旧車輌番号２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m旧車輌番号3 = gfncFieldVal(.Fields("旧車輌番号３").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式1 = gfncFieldVal(.Fields("型式１").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式2 = gfncFieldVal(.Fields("型式２").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m型式3 = gfncFieldVal(.Fields("型式３").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m燃料 = gfncFieldVal(.Fields("燃料").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m陸事車輌区分 = gfncFieldVal(.Fields("陸事車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m任意保険番号 = gfncFieldVal(.Fields("任意保険番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m使用者コード = gfncFieldVal(.Fields("使用者コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車検使用者コード = gfncFieldVal(.Fields("車検使用者コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車検所有者コード = gfncFieldVal(.Fields("車検所有者コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m切替日 = gfncFieldVal(.Fields("切替日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m輸送切替日 = gfncFieldVal(.Fields("輸送切替日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m乗車定員 = gfncFieldVal(.Fields("乗車定員").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m解体報告日付 = gfncFieldVal(.Fields("解体報告日付").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m移動報告番号 = gfncFieldVal(.Fields("移動報告番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m入力状態 = gfncFieldVal(.Fields("入力状態").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m増車代替区分 = gfncFieldVal(.Fields("増車代替区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m切替区分 = gfncFieldVal(.Fields("切替区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌状態 = gfncFieldVal(.Fields("車輌状態").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌計画処理SEQ = gfncFieldVal(.Fields("車輌計画処理SEQ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌登録フラグ = gfncFieldVal(.Fields("車輌登録フラグ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m日報確定日時 = gfncFieldVal(.Fields("日報確定日時").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m売却先情報 = gfncFieldVal(.Fields("売却先情報").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元会社コード = gfncFieldVal(.Fields("元会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元部署コード = gfncFieldVal(.Fields("元部署コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元営業車輌区分 = gfncFieldVal(.Fields("元営業車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元陸事車輌区分 = gfncFieldVal(.Fields("元陸事車輌区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元切替日 = gfncFieldVal(.Fields("元切替日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元車種コード = gfncFieldVal(.Fields("元車種コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m元車体番号 = gfncFieldVal(.Fields("元車体番号").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分増車 = gfncFieldVal(.Fields("車輌マスタ更新区分増車").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分代替 = gfncFieldVal(.Fields("車輌マスタ更新区分代替").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分営業移動 = gfncFieldVal(.Fields("車輌マスタ更新区分営業移動").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分会社移動 = gfncFieldVal(.Fields("車輌マスタ更新区分会社移動").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m車輌マスタ更新区分車輌メンテ = gfncFieldVal(.Fields("車輌マスタ更新区分車輌メンテ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m増車済みフラグ = gfncFieldVal(.Fields("増車済みフラグ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m処理対象フラグ = gfncFieldVal(.Fields("処理対象フラグ").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mナンバー色区分 = gfncFieldVal(.Fields("ナンバー色区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mメーカーコード = gfncFieldVal(.Fields("メーカーコード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m所有区分 = gfncFieldVal(.Fields("所有区分").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mリース会社コード = gfncFieldVal(.Fields("リース会社コード").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.m初回登録年月日 = gfncFieldVal(.Fields("初回登録年月日").Value)
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objUpdataParam.mリサイクル料金 = gfncFieldVal(.Fields("リサイクル料金").Value)

                Select Case objUpdataParam.m指示内容区分

                    Case "0"

                        pstrステータス = "増車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate増車(objUpdataParam)

                    Case "11"

                        pstrステータス = "保留増車　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                        Call msubUpdate保留増車(objUpdataParam)

                End Select

                '// フラグの状態で更新する日報確定日時の更新先を変更する
                If objUpdataParam.m処理対象フラグ = "1" Then

                    pstrステータス = "日報確定日時の更新　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                    '// 営業車輌マスタ
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌異動テーブル SET"
                    strSQL = strSQL & Chr(10) & "    日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌計画入力テーブル SET"
                    strSQL = strSQL & Chr(10) & "    日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                Else
                    pstrステータス = "車輌マスタ日報確定日時の更新　該当SEQ：" & objUpdataParam.m車輌計画処理SEQ
                    '// 車輌マスタ
                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌異動テーブル SET"
                    strSQL = strSQL & Chr(10) & "    車輌マスタ日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                    strSQL = ""
                    strSQL = strSQL & Chr(10) & "UPDATE 車輌計画入力テーブル SET"
                    strSQL = strSQL & Chr(10) & "    車輌マスタ日報確定日時 = TO_CHAR(SYSDATE, 'YYYYMMDD')"
                    strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                    strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                    strSQL = strSQL & Chr(10) & "WHERE"
                    strSQL = strSQL & Chr(10) & "    車輌計画処理SEQ = " & objUpdataParam.m車輌計画処理SEQ

                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gobjOraDatabase.ExecuteSQL(strSQL)

                End If

NEXT_:

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .MoveNext()

                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Loop While .EOF = False

        End With

HONMUTUKEKOMI:

        Dim objDys本務者履歴テーブル As Object
        Dim objDys車輌履歴テーブル As Object
        If pstr実行フラグ = "1" Or pstr実行フラグ = "3" Then
            '// 本務代務履歴テーブルから車輌マスタに本務者１と本務者２の情報を漬け込む

            pstrステータス = "本務者履歴テーブルから車輌マスタの本務者情報を反映："
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    HRT.車輌番号地区コード "
            strSQL = strSQL & Chr(10) & "   ,HRT.車輌番号１         "
            strSQL = strSQL & Chr(10) & "   ,HRT.車輌番号２         "
            strSQL = strSQL & Chr(10) & "   ,HRT.車輌番号３         "
            strSQL = strSQL & Chr(10) & "   ,ESM.無線番号           "
            strSQL = strSQL & Chr(10) & "   ,HRT.切替日             "
            strSQL = strSQL & Chr(10) & "   ,HRT.新本務者コード１   "
            strSQL = strSQL & Chr(10) & "   ,HRT.新本務者コード２   "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    本務者履歴テーブル HRT "
            strSQL = strSQL & Chr(10) & "   ,営業車輌マスタ     ESM "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    HRT.車輌番号地区コード = ESM.車輌番号地区コード(+) "
            strSQL = strSQL & Chr(10) & "AND HRT.車輌番号１         = ESM.車輌番号１        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.車輌番号２         = ESM.車輌番号２        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.車輌番号３         = ESM.車輌番号３        (+) "
            strSQL = strSQL & Chr(10) & "AND HRT.切替日            <= ('" & pstr営業日報日 & "') "
            strSQL = strSQL & Chr(10) & "AND NVL(HRT.車輌マスタ反映区分,'0') =  '0' " '// 2010/05/31
            '        strSQL = strSQL & Chr(10) & "AND HRT.切替区分           =  0 "
            strSQL = strSQL & Chr(10) & "AND HRT.所属コード         =  '" & gfncGetCodeToControl(pstr部署, GC_LEN_POST_CODE) & "'"
            strSQL = strSQL & Chr(10) & "ORDER BY HRT.切替日 " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys本務者履歴テーブル = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys本務者履歴テーブル

                ' 該当するデータが存在する場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        pstrステータス = "本務者付込み：車輌番号:" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "-" & gfncFieldVal(.Fields("車輌番号１").Value) & "-" & gfncFieldVal(.Fields("車輌番号２").Value) & "-" & gfncFieldVal(.Fields("車輌番号３").Value) & ""
                        ' 車輌マスタを更新
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(新本務者コード１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET 本務者コード１     = '" & gfncFieldVal(.Fields("新本務者コード１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(新本務者コード２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,本務者コード２     = '" & gfncFieldVal(.Fields("新本務者コード２").Value) & "' "
                        '// 2009/09/23 START 更新追加
                        strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号地区コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号１         = '" & gfncFieldVal(.Fields("車輌番号１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号２         = '" & gfncFieldVal(.Fields("車輌番号２").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号３         = '" & gfncFieldVal(.Fields("車輌番号３").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        '// 車輌マスタ反映区分を更新(切替区分 = 1)  2010/05/31
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE 本務者履歴テーブル SET"
                        strSQL = strSQL & Chr(10) & "   車輌マスタ反映区分  = 1 "
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号地区コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号１         = '" & gfncFieldVal(.Fields("車輌番号１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号２         = '" & gfncFieldVal(.Fields("車輌番号２").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号３         = '" & gfncFieldVal(.Fields("車輌番号３").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys本務者履歴テーブル.Fields(切替日).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 切替日             = '" & gfncFieldVal(.Fields("切替日").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys本務者履歴テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            'UPGRADE_NOTE: Object objDys本務者履歴テーブル may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDys本務者履歴テーブル = Nothing

            '// 2009/09/23 START 車輌履歴テーブルから車輌マスタを更新する処理を追加
            '----------------------------------------------------------------------
            ' 車輌履歴テーブル  データ反映処理
            '----------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    車輌番号地区コード   "
            strSQL = strSQL & Chr(10) & "   ,車輌番号１           "
            strSQL = strSQL & Chr(10) & "   ,車輌番号２           "
            strSQL = strSQL & Chr(10) & "   ,車輌番号３           "
            strSQL = strSQL & Chr(10) & "   ,切替日               "
            strSQL = strSQL & Chr(10) & "   ,新会社コード         "
            strSQL = strSQL & Chr(10) & "   ,新所属コード         "
            strSQL = strSQL & Chr(10) & "   ,新整理番号           "
            strSQL = strSQL & Chr(10) & "   ,新車輌区分           "
            strSQL = strSQL & Chr(10) & "   ,新車輌登録会社コード "
            strSQL = strSQL & Chr(10) & "   ,新車輌登録所属コード "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    車輌履歴テーブル "
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1"
            strSQL = strSQL & Chr(10) & "AND 切替日       <= ('" & pstr営業日報日 & "')"
            strSQL = strSQL & Chr(10) & "AND 切替区分      =  0 "
            strSQL = strSQL & Chr(10) & "AND 新所属コード  =  '" & gfncGetCodeToControl(pstr部署, GC_LEN_POST_CODE) & "'"
            strSQL = strSQL & Chr(10) & "ORDER BY 切替日 " '// 2010/09/24

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys車輌履歴テーブル = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDys車輌履歴テーブル

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    Do

                        '// 車輌マスタの更新(未来日付で車輌変更入力された内容を反映)
                        strSQL = ""
                        strSQL = strSQL & Chr(10) & "UPDATE 車輌マスタ "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新所属コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "SET 所属コード         = '" & gfncFieldVal(.Fields("新所属コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新会社コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,会社コード         = '" & gfncFieldVal(.Fields("新会社コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新整理番号).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,整理番号           = '" & gfncFieldVal(.Fields("新整理番号").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新車輌区分).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,車輌区分           = '" & gfncFieldVal(.Fields("新車輌区分").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新車輌登録会社コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,車輌登録会社コード = '" & gfncFieldVal(.Fields("新車輌登録会社コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(新車輌登録所属コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "   ,車輌登録所属コード = '" & gfncFieldVal(.Fields("新車輌登録所属コード").Value) & "' "
                        '// 2009/09/23 START 更新追加
                        strSQL = strSQL & Chr(10) & "   ,更新従業員コード = '" & gclsLoginInfo.EmployeeCode & "'"
                        strSQL = strSQL & Chr(10) & "   ,更新日付時刻 = SYSDATE"
                        '// 2009/09/23 END
                        strSQL = strSQL & Chr(10) & "WHERE "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号地区コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "    車輌番号地区コード = '" & gfncFieldVal(.Fields("車輌番号地区コード").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号１         = '" & gfncFieldVal(.Fields("車輌番号１").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号２).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号２         = '" & gfncFieldVal(.Fields("車輌番号２").Value) & "' "
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDys車輌履歴テーブル.Fields(車輌番号３).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strSQL = strSQL & Chr(10) & "AND 車輌番号３         = '" & gfncFieldVal(.Fields("車輌番号３").Value) & "' "

                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call gobjOraDatabase.ExecuteSQL(strSQL)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Loop While .EOF = False

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys車輌履歴テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            '// 2009/09/23 END
            Call gsubClearObject(objDynaset)
            Call gsubClearObject(objDys本務者履歴テーブル)
            Call gsubClearObject(objDys車輌履歴テーブル)
        End If

        '// 終了ログのはきだし
        Call gfncRegistTraceLog(gfncGetDBUserName, gfncGetDBPassWord, gfncGetDBTNS, GC_PROGRAM_NAME, GC_PROGRAM_ID, "正常終了", pstrステータス, "", GC_LOG_TARGET_車輌管理ログ, False)


    End Function

    '******************************************************************************
    ' 関 数 名  : mfncGetHokenName
    ' スコープ  : Private
    ' 処理内容  : 保険会社コードより保険会社名を取得する
    '             対象がない場合はから文字を返す
    ' 備　　考  :
    ' 返 り 値  : string
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstr保険会社        String        　   I    保険会社コード
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/03/26  ＫＳＲ             新規作成
    '******************************************************************************
    Public Function mfncGetHokenName(ByVal pstr保険会社 As String) As String
        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo mfncGetHokenName_Err
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Dim strSQL As String
        Dim objDynaset As Object
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDynaset As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            mfncGetHokenName = ""

            If pstr保険会社 = "" Then
                GoTo mfncGetHokenName_Exit
            End If

            strSQL = ""
            strSQL = strSQL & "SELECT MM.コード AS コード, "
            strSQL = strSQL & "       MM.名称漢字 AS 名称 "
            strSQL = strSQL & "  FROM 名称マスタ MM "
            strSQL = strSQL & " WHERE MM.識別    = '保険会社' "
            strSQL = strSQL & " AND   MM.コード  = '" & pstr保険会社 & "'"
            strSQL = strSQL & " ORDER BY MM.コード "
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDynaset = gobjOraDatabase.CreateDynaset(strSQL, &H1)
            'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDynaset.EOF Then
                GoTo mfncGetHokenName_Exit
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object objDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                mfncGetHokenName = gfncFieldVal(objDynaset.Fields("名称").Value)
            End If

            '++修正開始　2021年06月17日:MK（手）- VB→VB.NET変換
mfncGetHokenName_Exit:
            'Call gsubClearObject(objDynaset)
            'Exit Function
            '--修正開始　2021年06月17日:MK（手）- VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'mfncGetHokenName_Err:
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'Resume mfncGetHokenName_Exit
            Call gsubClearObject(objDynaset)
            Exit Function
            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncOldChangeDate
    ' スコープ  : Private
    ' 処理内容  : 引数の会社コードと所属コードと切替日で日報確定が終了されているかどうかをチェックする
    ' 備　　考  :
    ' 返 り 値  : Boolean
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名                ﾃﾞｰﾀﾀｲﾌﾟ            I/O     説 明
    '   -----------------------+-------------------+-------+-------------------------------
    '   pKaisyaCode             STRING              I       車輌の所属している会社コード
    '   pBusyoCode              STRING              I       車輌の所属している部署コード
    '   pKirikaebi              STRING              I       今回処理を行う切替日
    ' 変更履歴  :
    '   Version     日　付      氏　名        　　 修正内容
    '   -----------+-----------+------------------+--------------------------------
    '               2010/09/24  ＫＳＲ
    '******************************************************************************
    Public Function gfncOldChangeDate(ByRef pKaisyaCode As String, ByRef pBusyoCode As String, ByRef pKirikaebi As String) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ABEND
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Dim Sql_s As String
        Dim obj_Nippou As Object
        Dim strBushoname As String
        Dim strChangeday As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim Sql_s As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim obj_Nippou As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strBushoname As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strChangeday As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            gfncOldChangeDate = False

            strChangeday = "99999999"

            '// 部署名の取得
            Sql_s = ""
            Sql_s = Sql_s & "   SELECT "
            Sql_s = Sql_s & "       BSM.部署名"
            Sql_s = Sql_s & "   FROM 部署マスタ BSM"
            Sql_s = Sql_s & "   WHERE 1 = 1"
            Sql_s = Sql_s & "   AND BSM.会社コード   = '" & pKaisyaCode & "' "
            Sql_s = Sql_s & "   AND BSM.所属コード   = '" & pBusyoCode & "' "
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou = gobjOraDatabase.CreateDynaset(Sql_s, &H4)
            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If obj_Nippou.EOF Then
                strBushoname = ""
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strBushoname = gfncFieldVal(obj_Nippou.Fields("部署名").Value, "")
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou.Close()
            'UPGRADE_NOTE: Object obj_Nippou may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            obj_Nippou = Nothing

            '// 日報入力確定テーブルより、対象会社、所属、で最大営業日を取得して、引数の切替日で確定処理がおわっているかどうかチェック
            Sql_s = ""
            Sql_s = Sql_s & Chr(10) & "SELECT "
            Sql_s = Sql_s & Chr(10) & "     MAX(営業日) AS 営業日 "
            Sql_s = Sql_s & Chr(10) & "FROM 日報入力確定テーブル"
            Sql_s = Sql_s & Chr(10) & "WHERE 1 = 1"
            Sql_s = Sql_s & Chr(10) & "AND    会社コード = '" & pKaisyaCode & "' "
            Sql_s = Sql_s & Chr(10) & "AND    所属コード = '" & pBusyoCode & "' "
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou = gobjOraDatabase.CreateDynaset(Sql_s, &H4)
            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If obj_Nippou.EOF Then
                '// 日報入力確定テーブルが存在しない場合は、ノーチェックで処理を通す
                gfncOldChangeDate = True
                GoTo PROC_EXIT
            Else
                'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                strChangeday = gfncFieldVal(obj_Nippou.Fields("営業日").Value, "")
            End If

            '// 取得した切替日以前の切替日が画面に入力されている場合はエラー
            If strChangeday >= pKirikaebi Then
                '++修正開始　2021年09月05日:MK（手）- VB→VB.NET変換
                'MsgBox("既に" & strBushoname & "で" & vbCrLf & "勤務予定入力確定処理が終了している為、" & VB6.Format(CDate(VB6.Format(strChangeday, "0000/00/00")), "yyyy(ggge)/mm/dd") & "以前の切替日は入力できません。", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                MsgBox("既に" & strBushoname & "で" & vbCrLf & "勤務予定入力確定処理が終了している為、" & VB6.Format(CDate(VB6.Format(strChangeday, "0000/00/00")), "yyyy(gggee)/mm/dd") & "以前の切替日は入力できません。", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                '--修正開始　2021年09月05日:MK（手）- VB→VB.NET変換
                GoTo PROC_EXIT
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object obj_Nippou.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj_Nippou.Close()
            'UPGRADE_NOTE: Object obj_Nippou may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            obj_Nippou = Nothing

            gfncOldChangeDate = True

            ''** 終了共通処理
            '++修正開始　2021年06月17日:MK（手）- VB→VB.NET変換
            'PROC_EXIT:
            '''** 処理終了
           ' Exit Function
            '--修正開始　2021年06月17日:MK（手）- VB→VB.NET変換

            ''** 例外処理共通処理
            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ABEND:
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            ''** エラーメッセージ表示
            Call MsgBox(Err.Description, MsgBoxStyle.Critical, "gfncOldChangeDate")
            Exit Function
            ''** 終了共通処理実施
            '++修正開始　2021年06月17日:MK（手）- VB→VB.NET変換
            'Resume PROC_EXIT
            '--修正開始　2021年06月17日:MK（手）- VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
PROC_EXIT:
        '''** 処理終了
        Exit Function
    End Function

End Module
