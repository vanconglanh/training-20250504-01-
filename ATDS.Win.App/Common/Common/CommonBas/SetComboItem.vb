Option Strict Off
Option Explicit On
Module basSetComboItem
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : SetComboItem.bas
    ' 内    容    : コンボボックス アイテム 設定 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gsubSetComboItem             (コンボボックス アイテム 設定)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.01.00    2008/05/21  廣井  芳明         振込先会社コード(運管)の追加
    '   02.02.00    2009/12/10  廣井  芳明         自家用車種コードの追加
    '   02.03.00    2010/06/21  廣井  芳明         指導監督分類の追加
    '   02.04.00    2017/01/23　ＫＳＲ             ファーストの桁を定数から取得
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Public Const GC_CBOID_所属コード As Short = 1 ' 所属コード(全件)
    Public Const GC_CBOID_勤怠コード As Short = 2 ' 勤怠区分(全件)
    Public Const GC_CBOID_充填所コード As Short = 3 ' 充填所コード
    Public Const GC_CBOID_皆勤区分 As Short = 4 ' 皆勤区分
    Public Const GC_CBOID_出欠区分 As Short = 5 ' 出欠区分
    Public Const GC_CBOID_分類 As Short = 6 ' 分類
    Public Const GC_CBOID_勤務区分 As Short = 7 ' 勤務区分
    Public Const GC_CBOID_車輌区分 As Short = 8 ' 車輌区分
    Public Const GC_CBOID_ファースト As Short = 9 ' ファースト
    Public Const GC_CBOID_状態区分 As Short = 10 ' 状態区分
    Public Const GC_CBOID_車輌番号地区コード As Short = 11 ' 車輌番号地区コード
    Public Const GC_CBOID_長欠種別 As Short = 12 ' 長欠種別
    Public Const GC_CBOID_長欠者集会 As Short = 13 ' 長欠者集会
    Public Const GC_CBOID_病院コード As Short = 14 ' 病院コード
    Public Const GC_CBOID_都道府県 As Short = 15 ' 都道府県
    Public Const GC_CBOID_未収区分 As Short = 16 ' 未収区分
    Public Const GC_CBOID_乗務区分 As Short = 17 ' 乗務区分
    Public Const GC_CBOID_銀行コード As Short = 18 ' 銀行コード
    Public Const GC_CBOID_振分区分 As Short = 19 ' 振分区分
    Public Const GC_CBOID_入力区分 As Short = 20 ' 入力区分
    Public Const GC_CBOID_手数料率設定先 As Short = 21 ' 手数料率設定先
    Public Const GC_CBOID_性別 As Short = 22 ' 性別
    Public Const GC_CBOID_血液型 As Short = 23 ' 血液型
    Public Const GC_CBOID_有無区分 As Short = 24 ' 有無区分
    Public Const GC_CBOID_卒業区分 As Short = 25 ' 卒業区分
    Public Const GC_CBOID_マイカー通勤区分 As Short = 26 ' マイカー通勤区分
    Public Const GC_CBOID_役職位 As Short = 27 ' 役職位
    Public Const GC_CBOID_教習区分 As Short = 29 ' 教習区分
    Public Const GC_CBOID_長欠区分 As Short = 30 ' 長欠区分
    Public Const GC_CBOID_税区分 As Short = 31 ' 税区分
    Public Const GC_CBOID_本務代務区分 As Short = 32 ' 本務代務区分
    Public Const GC_CBOID_システム権限 As Short = 35 ' システム権限
    Public Const GC_CBOID_長欠勤怠コード As Short = 36 ' 長欠勤怠コード
    Public Const GC_CBOID_退職コード As Short = 37 ' 退職コード
    Public Const GC_CBOID_扶養義務区分 As Short = 38 ' 扶養義務区分
    Public Const GC_CBOID_同居区分 As Short = 39 ' 同居区分
    Public Const GC_CBOID_講義コード As Short = 40 ' 講義コード
    Public Const GC_CBOID_曜日 As Short = 44 ' 曜日
    Public Const GC_CBOID_計算区分 As Short = 45 ' 計算区分
    Public Const GC_CBOID_丸め単位 As Short = 46 ' 丸め区分
    Public Const GC_CBOID_ZD種別_全て As Short = 61 ' ＺＤ種別(全て)
    Public Const GC_CBOID_ZDSDマスタ_事故 As Short = 62 ' ＺＤＳＤマスタ(事故)
    Public Const GC_CBOID_ZD種別 As Short = 63 ' ＺＤ種別
    Public Const GC_CBOID_ZDSDマスタ_処分 As Short = 64 ' ＺＤＳＤマスタ(処分)
    Public Const GC_CBOID_ZDSDマスタ_増点 As Short = 66 ' ＺＤＳＤマスタ(増点)
    Public Const GC_CBOID_交通違反マスタ As Short = 67 ' 交通違反マスタ
    Public Const GC_CBOID_違反苦情分類マスタ As Short = 68 ' 違反苦情分類マスタ
    Public Const GC_CBOID_報告書区別 As Short = 71 ' 報告書区分
    '==    女性セミをコンボから除くため追加　2013/09/25
    Public Const GC_CBOID_ファースト_2 As Short = 72 ' ファースト_使用有無
    Public Const GC_CBOID_種類コード As Short = 101 ' 種類コード
    Public Const GC_CBOID_状況コード As Short = 102 ' 状況コード
    Public Const GC_CBOID_入社区分 As Short = 104 ' 入社区分
    Public Const GC_CBOID_特別手当区分 As Short = 105 ' 特別手当区分
    Public Const GC_CBOID_SD出勤区分 As Short = 106 ' ＳＤ出勤区分
    Public Const GC_CBOID_チェック分類 As Short = 107 ' チェック分類
    Public Const GC_CBOID_車輌保険徴収区分 As Short = 120 ' 車輌保険徴収区分
    Public Const GC_CBOID_勤怠コード_略称 As Short = 122 ' 勤怠区分(略称)
    Public Const GC_CBOID_勤務班時間マスタ As Short = 199 ' 勤務班時間マスタ
    Public Const GC_CBOID_手数料計算区分 As Short = 200 ' 手数料計算区分
    Public Const GC_CBOID_ハイヤーチェック As Short = 201 ' ハイヤーチェック
    Public Const GC_CBOID_勤次郎部門コード As Short = 285 ' 勤次郎部門コード
    Public Const GC_CBOID_会社コード As Short = 286 ' 会社コード(全件)
    Public Const GC_CBOID_所属コード_営業所 As Short = 287 ' 所属コード(営業所名)
    Public Const GC_CBOID_所属コード_運管 As Short = 288 ' 所属コード(運管)
    Public Const GC_CBOID_ハイヤー区分 As Short = 290 ' ハイヤー区分
    Public Const GC_CBOID_契約形態 As Short = 291 ' 契約形態
    Public Const GC_CBOID_売上振分区分 As Short = 292 ' 売上振分
    Public Const GC_CBOID_売上区分 As Short = 293 ' 売上区分
    Public Const GC_CBOID_税対象 As Short = 295 ' 税対象
    Public Const GC_CBOID_税通知 As Short = 296 ' 税通知
    Public Const GC_CBOID_運管勤怠コード As Short = 297 ' 運管勤怠コード
    Public Const GC_CBOID_商品大分類コード As Short = 298 ' 商品大分類コード
    Public Const GC_CBOID_会社コード_運管 As Short = 299 ' 会社コード(運管)
    Public Const GC_CBOID_会社コード_タクシー As Short = 300 ' 会社コード(タクシー)
    Public Const GC_CBOID_勤次郎会社コード As Short = 301 ' 勤次郎会社コード
    Public Const GC_CBOID_所属コード_営業所_略称 As Short = 302 ' 所属コード(営業所・略称)
    Public Const GC_CBOID_会社コード_従業員 As Short = 303 ' 会社コード(従業員管理)
    Public Const GC_CBOID_振込先会社コード_運管 As Short = 304 ' 振込先会社コード(運管)
    Public Const GC_CBOID_燃料区分 As Short = 305 ' 燃料区分
    Public Const GC_CBOID_会社コード_シャトル As Short = 306 ' 会社コード(シャトル)
    Public Const GC_CBOID_詳細状況コード As Short = 307 ' 詳細状況コード
    Public Const GC_CBOID_未収区分_MKクレジット As Short = 308 ' 未収区分(エムケイクレジット)
    Public Const GC_CBOID_MK区分 As Short = 309 ' ＭＫ区分
    Public Const GC_CBOID_会社コード_ZDSD As Short = 310 ' 会社コード(ＺＤＳＤ)
    Public Const GC_CBOID_ZD種別_営業所 As Short = 311 ' ＺＤ種別(営業所)
    Public Const GC_CBOID_用途区分 As Short = 312 ' 用途区分
    Public Const GC_CBOID_サイズ区分 As Short = 313 ' サイズ区分
    Public Const GC_CBOID_請求締日 As Short = 314 ' 請求締日
    Public Const GC_CBOID_会社コード_乗務員台帳 As Short = 315 ' 会社コード(乗務員台帳)
    Public Const GC_CBOID_タクシーハイヤー区分 As Short = 316 ' タクシーハイヤー区分
    Public Const GC_CBOID_貸付項目コード As Short = 317 ' 貸付項目コード
    Public Const GC_CBOID_仮コード区分 As Short = 318 ' 仮コード区分
    Public Const GC_CBOID_会社コード_セミハイヤ As Short = 319 ' 会社コード(ｾﾐﾊｲﾔ)
    Public Const GC_CBOID_指導場所コード As Short = 320 ' 指導場所コード
    Public Const GC_CBOID_自家用車種コード As Short = 321 ' 自家用車種コード
    Public Const GC_CBOID_指導監督分類 As Short = 322 ' 指導監督分類
    Public Const GC_CBOID_指導監督分類_全集以外 As Short = 323 ' 指導監督分類(全集以外)
    Public Const GC_CBOID_指導監督分類_全集再教習以外 As Short = 324 ' 指導監督分類(全集再教習以外)
    Public Const GC_CBOID_特殊勤務パターン As Short = 325 ' 特殊勤務パターン(2014/01/27)
    Public Const GC_CBOID_法休管理区分 As Short = 326 ' 法休管理区分 2018/02
    Public Const GC_CBOID_半休区分 As Short = 327 ' 半休区分 2019/07/22
    Public Const GC_CBOID_運管勤怠コード_警備 As Short = 328 ' 半休区分 2019/07/22
    '******************************************************************************
    ' 関 数 名  : gsubSetComboItem
    ' スコープ  :
    ' 処理内容  : コンボボックスにアイテムを設定
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTarget          ComboBox          O     設定対象
    '   plngItemNo          Long              I     アイテムNo.
    '   pobjDB              Object            O     データベースオブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.01.00    2008/05/21  廣井  芳明         振込先会社コード(運管)の追加
    '   02.02.00    2009/12/10  廣井  芳明         自家用車種コードの追加
    '   02.03.00    2010/06/21  廣井  芳明         指導監督分類の追加
    '
    '******************************************************************************
    Public Sub gsubSetComboItem(ByRef pobjTarget As Object, ByVal plngItemNo As Integer, ByRef pobjDB As Object)

        Dim strSQL As String
        Dim objDysCboSet As Object

        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
        'Call pobjTarget.Clear()
        Call pobjTarget.Items.Clear()
        pobjTarget.Text = String.Empty
        '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

        Select Case plngItemNo
            '--------------------------------------------------------------------------
            ' 所属コード(全件)
            '--------------------------------------------------------------------------
            Case GC_CBOID_所属コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    所属コード "
                strSQL = strSQL & Chr(10) & "   ,部署名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    部署マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    会社コード <> '" & GC_DEF_観バス_会社 & "' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    所属コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("所属コード").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("部署名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 所属（運行管理）
                '--------------------------------------------------------------------------
            Case GC_CBOID_所属コード_運管

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    所属コード "
                strSQL = strSQL & Chr(10) & "   ,部署名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    部署マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                ' 区分４(運行管理（派遣）部署)が０以外
                strSQL = strSQL & Chr(10) & "    NVL(区分４,0) <> 0 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    所属コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("所属コード").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("部署名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 所属(営業所名 略称)
                '--------------------------------------------------------------------------
            Case GC_CBOID_所属コード_営業所_略称

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    所属コード "
                strSQL = strSQL & Chr(10) & "   ,部署名略称 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    部署マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    会社コード IS NOT NULL "
                strSQL = strSQL & Chr(10) & "AND 営業区分 = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    所属コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("所属コード").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("部署名略称").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 所属コード(営業所)
                '--------------------------------------------------------------------------
            Case GC_CBOID_所属コード_営業所

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    所属コード "
                strSQL = strSQL & Chr(10) & "   ,部署名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    部署マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    営業区分 = '1' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    所属コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("所属コード").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("部署名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 勤怠区分(全件)
                '--------------------------------------------------------------------------
            Case GC_CBOID_勤怠コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    勤怠コード "
                strSQL = strSQL & Chr(10) & "   ,勤怠名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    勤怠マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    勤怠コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("勤怠コード").Value & Space(GC_LEN_WORK_KBN), 1, GC_LEN_WORK_KBN) & GC_COMBO_SPLIT & .Fields("勤怠名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 充填所
                '--------------------------------------------------------------------------
            Case GC_CBOID_充填所コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    充填所コード "
                strSQL = strSQL & Chr(10) & "   ,名称         "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ＬＰＧ充填所マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    充填所コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("充填所コード").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("名称").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 皆勤区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_皆勤区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "対象外")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "対象")
                '--------------------------------------------------------------------------
                ' 法休管理区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_法休管理区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "対象外")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "対象")

                '--------------------------------------------------------------------------
                ' 半休区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_半休区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "なし")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "半休扱い")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("9" & GC_COMBO_SPLIT & "元半休扱い")

                '--------------------------------------------------------------------------
                ' 出欠区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_出欠区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "出勤")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "休み")

                '--------------------------------------------------------------------------
                ' 分類
                '--------------------------------------------------------------------------
            Case GC_CBOID_分類

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0 " & GC_COMBO_SPLIT & "出勤")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1 " & GC_COMBO_SPLIT & "公休")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2 " & GC_COMBO_SPLIT & "欠勤")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3 " & GC_COMBO_SPLIT & "慶弔")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4 " & GC_COMBO_SPLIT & "遅刻")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5 " & GC_COMBO_SPLIT & "早退")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6 " & GC_COMBO_SPLIT & "長欠")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7 " & GC_COMBO_SPLIT & "有休")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8 " & GC_COMBO_SPLIT & "公出")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("51" & GC_COMBO_SPLIT & "有給予約")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("52" & GC_COMBO_SPLIT & "公出予約")

                '--------------------------------------------------------------------------
                ' 勤務区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_勤務区分

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    コード   "
                strSQL = strSQL & Chr(10) & "   ,名称漢字 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    名称マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    識別 = '勤務区分' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(名称漢字).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(gfncFieldVal(.Fields("コード").Value) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("名称漢字").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 車輌区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_車輌区分

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    車輌区分                      "
                strSQL = strSQL & Chr(10) & "  , MIN(車輌区分名) AS 車輌区分名 "
                strSQL = strSQL & Chr(10) & "FROM  "
                strSQL = strSQL & Chr(10) & "    車輌区分マスタ "
                strSQL = strSQL & Chr(10) & "GROUP BY "
                strSQL = strSQL & Chr(10) & "    車輌区分   "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    車輌区分   "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("車輌区分").Value & Space(GC_LEN_CAR_KBN), 1, GC_LEN_CAR_KBN) & GC_COMBO_SPLIT & .Fields("車輌区分名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ファースト
                '--------------------------------------------------------------------------
            Case GC_CBOID_ファースト

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
                strSQL = strSQL & Chr(10) & "    ファースト   "
                strSQL = strSQL & Chr(10) & "   ,ファースト名 "
                strSQL = strSQL & Chr(10) & "FROM  "
                strSQL = strSQL & Chr(10) & "    ファーストマスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ファースト "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("ファースト").Value & Space(GC_LEN_FIRST_KBN), 1, GC_LEN_FIRST_KBN) & GC_COMBO_SPLIT & .Fields("ファースト名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With


                '-------------------------------------------------------------------------------
                ' ファースト 使用有無区分追加　 女性セミをコンボから除くため追加　2013/09/25
                '-------------------------------------------------------------------------------
            Case GC_CBOID_ファースト_2

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
                strSQL = strSQL & Chr(10) & "    ファースト   "
                strSQL = strSQL & Chr(10) & "   ,ファースト名 "
                strSQL = strSQL & Chr(10) & "FROM  "
                strSQL = strSQL & Chr(10) & "    ファーストマスタ "
                strSQL = strSQL & Chr(10) & "WHERE  "
                strSQL = strSQL & Chr(10) & "    稼働台数表示有無区分 = 1  "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ファースト "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("ファースト").Value & Space(GC_LEN_FIRST_KBN), 1, GC_LEN_FIRST_KBN) & GC_COMBO_SPLIT & .Fields("ファースト名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With



                '--------------------------------------------------------------------------
                ' 状態区分（車輌状態）
                '--------------------------------------------------------------------------
            Case GC_CBOID_状態区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "稼動可能")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "修理中")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "完了")

                '--------------------------------------------------------------------------
                ' 車輌番号地区コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_車輌番号地区コード

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    車輌番号地区コード "
                strSQL = strSQL & "   ,車輌番号地区名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    車輌番号地区マスタ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    車輌番号地区コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("車輌番号地区コード").Value & Space(GC_LEN_CAR_DISTRICT_CODE), 1, GC_LEN_CAR_DISTRICT_CODE) & GC_COMBO_SPLIT & .Fields("車輌番号地区名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 長欠種別
                '--------------------------------------------------------------------------
            Case GC_CBOID_長欠種別

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "公傷")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "私傷")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "免停")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "その他")

                '--------------------------------------------------------------------------
                ' 長欠者集会
                '--------------------------------------------------------------------------
            Case GC_CBOID_長欠者集会

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "出席")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "欠席")

                '--------------------------------------------------------------------------
                ' 病院コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_病院コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    病院コード "
                strSQL = strSQL & Chr(10) & "   ,病院名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    病院マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    病院コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("病院コード").Value & Space(GC_LEN_HOSPITAL_CODE), 1, GC_LEN_HOSPITAL_CODE) & GC_COMBO_SPLIT & .Fields("病院名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 都道府県
                '--------------------------------------------------------------------------
            Case GC_CBOID_都道府県

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    名称漢字 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    名称マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    識別      = '都道府県' "
                strSQL = strSQL & Chr(10) & "AND 名称漢字 IS NOT NULL   "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(.Fields("名称漢字").Value)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 未収区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_未収区分

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    未収区分   "
                strSQL = strSQL & Chr(10) & "   ,未収区分名 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    未収区分マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(未収区分) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("未収区分").Value & Space(GC_LEN_MISYUU_KBN), 1, GC_LEN_MISYUU_KBN) & GC_COMBO_SPLIT & .Fields("未収区分名").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 未収区分(エムケイクレジット)
                '--------------------------------------------------------------------------
            Case GC_CBOID_未収区分_MKクレジット

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    未収区分   "
                strSQL = strSQL & Chr(10) & "   ,未収区分名 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    未収区分マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                ' 振分区分が０(チケット)
                strSQL = strSQL & Chr(10) & "    振分区分       = " & CStr(GC_KBN_振分_チケット) & " "
                ' 手数料率設定先が０(ＭＫ会員)
                strSQL = strSQL & Chr(10) & "AND 手数料率設定先 = " & CStr(GC_手数料率設定先_MK会員) & " "
                ' リスト集計区分が３(エムケイクレジット)
                strSQL = strSQL & Chr(10) & "AND リスト集計区分 = 3 "
                ' 未収コード区分が１(入力可)
                strSQL = strSQL & Chr(10) & "AND 未収コード区分 = " & CStr(GC_KBN_未収コード_入力可) & " "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(未収区分) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("未収区分").Value & Space(GC_LEN_MISYUU_KBN), 1, GC_LEN_MISYUU_KBN) & GC_COMBO_SPLIT & .Fields("未収区分名").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 乗務区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_乗務区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "本務")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "代務")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "休車")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "教習")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "その他")

                '--------------------------------------------------------------------------
                ' 銀行
                '--------------------------------------------------------------------------
            Case GC_CBOID_銀行コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    銀行コード "
                strSQL = strSQL & Chr(10) & "   ,銀行名漢字 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    銀行マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    銀行コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("銀行コード").Value & Space(GC_LEN_BANK_CODE), 1, GC_LEN_BANK_CODE) & GC_COMBO_SPLIT & .Fields("銀行名漢字").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 振分区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_振分区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "チケット")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "金券")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "高速代")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "割引回数券")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "身障者割引券")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5" & GC_COMBO_SPLIT & "障害者乗車券")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "他社員")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "その他")

                '--------------------------------------------------------------------------
                ' 入力区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_入力区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "入力不可")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "入力可")

                '--------------------------------------------------------------------------
                ' 手数料率設定先
                '--------------------------------------------------------------------------
            Case GC_CBOID_手数料率設定先

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "ＭＫ会員マスタ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "従業員マスタ")

                '--------------------------------------------------------------------------
                ' 性別
                '--------------------------------------------------------------------------
            Case GC_CBOID_性別

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_性別_男) & GC_COMBO_SPLIT & "男")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_性別_女) & GC_COMBO_SPLIT & "女")

                '--------------------------------------------------------------------------
                ' 血液型
                '--------------------------------------------------------------------------
            Case GC_CBOID_血液型

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "Ａ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "Ｂ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "Ｏ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "AB")

                '--------------------------------------------------------------------------
                ' 経験、雇用保険徴収、班長手当区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_有無区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "無し")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "有り")

                '--------------------------------------------------------------------------
                ' 卒業区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_卒業区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "卒業")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "中退")

                '--------------------------------------------------------------------------
                ' マイカー通勤区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_マイカー通勤区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "しない")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "する")

                '--------------------------------------------------------------------------
                ' 役職位
                '--------------------------------------------------------------------------
            Case GC_CBOID_役職位

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    コード   "
                strSQL = strSQL & Chr(10) & "   ,名称漢字 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    名称マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    識別 = '役職位' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("コード").Value & Space(GC_LEN_OFFICIAL_POSITION), 1, GC_LEN_OFFICIAL_POSITION) & GC_COMBO_SPLIT & .Fields("名称漢字").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 教習区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_教習区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "対象外")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "養成・教習")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "教習")

                '--------------------------------------------------------------------------
                ' 長欠区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_長欠区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "通常勤務")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "長欠中")

                '--------------------------------------------------------------------------
                ' 税区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_税区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "甲欄")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "乙欄")

                '--------------------------------------------------------------------------
                ' 本務代務区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_本務代務区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "本務")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "代務")

                '--------------------------------------------------------------------------
                ' システム権限
                '--------------------------------------------------------------------------
            Case GC_CBOID_システム権限

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "ユーザー")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "管理者")

                '--------------------------------------------------------------------------
                ' 勤怠区分（長欠勤怠コード）
                '--------------------------------------------------------------------------
            Case GC_CBOID_長欠勤怠コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    勤怠コード "
                strSQL = strSQL & Chr(10) & "   ,勤怠名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    勤怠マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    分類 = 6 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    勤怠コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("勤怠コード").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("勤怠名").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 退職コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_退職コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    退職コード "
                strSQL = strSQL & Chr(10) & "   ,退職理由   "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    退職理由マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    退職コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("退職コード").Value & Space(GC_LEN_RESIGNATION_CODE), 1, GC_LEN_RESIGNATION_CODE) & GC_COMBO_SPLIT & .Fields("退職理由").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 扶養義務区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_扶養義務区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "有")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "無")

                '--------------------------------------------------------------------------
                ' 同居区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_同居区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_同別居_同居) & GC_COMBO_SPLIT & "同居")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_同別居_別居) & GC_COMBO_SPLIT & "別居")

                '--------------------------------------------------------------------------
                ' 講義コード（全て）
                '--------------------------------------------------------------------------
            Case GC_CBOID_講義コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    講義コード "
                strSQL = strSQL & Chr(10) & "   ,講義名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    講義マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    講義コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("講義コード").Value & Space(3), 1, 3) & GC_COMBO_SPLIT & .Fields("講義名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 曜日
                '--------------------------------------------------------------------------
            Case GC_CBOID_曜日

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "日")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "月")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "火")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "水")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5" & GC_COMBO_SPLIT & "木")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "金")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "土")

                '--------------------------------------------------------------------------
                ' 計算区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_計算区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "切捨て")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "切上げ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "四捨五入")

                '--------------------------------------------------------------------------
                ' 丸め単位
                '--------------------------------------------------------------------------
            Case GC_CBOID_丸め単位

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "一円単位")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "十円単位")

                '--------------------------------------------------------------------------
                ' ＺＤ種別（全て）
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZD種別_全て

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "苦情")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "交通違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "社内ルール違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "事故")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "身だしなみ違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5" & GC_COMBO_SPLIT & "増点")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&観光ルール違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "外商部ミスレポート")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "その他")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("9" & GC_COMBO_SPLIT & "処分")

                '--------------------------------------------------------------------------
                ' ＺＤＳＤマスタ（増点）
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZDSDマスタ_増点

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    内容区分 "
                strSQL = strSQL & Chr(10) & "   ,内容     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ＺＤＳＤマスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ＺＤ種別 = 5 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    内容区分 "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("内容区分").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("内容").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ＺＤＳＤマスタ（事故）
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZDSDマスタ_事故

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    内容区分 "
                strSQL = strSQL & Chr(10) & "   ,内容     "
                strSQL = strSQL & Chr(10) & "   ,点数     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ＺＤＳＤマスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ＺＤ種別 = 3 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    内容区分 "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("内容区分").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & Mid(.Fields("内容").Value & Space(20), 1, 20) & GC_COMBO_SPLIT & VB6.Format(.Fields("点数").Value, "#0")))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ＺＤ種別（苦情、交通違反、社内違反）
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZD種別

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "苦情")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "交通違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "社内ルール違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "身だしなみ違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&観光ルール違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "外商部ミスレポート")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "その他")

                '--------------------------------------------------------------------------
                ' 報告書区別
                '--------------------------------------------------------------------------
            Case GC_CBOID_報告書区別

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("01" & GC_COMBO_SPLIT & "社内ルール・交通ルール・マナー違反報告書")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("02" & GC_COMBO_SPLIT & "苦情発生報告書")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("03" & GC_COMBO_SPLIT & "お礼状報告書")

                '--------------------------------------------------------------------------
                ' 種類コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_種類コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    種類コード "
                strSQL = strSQL & Chr(10) & "   ,種類名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    種類マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    種類コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("種類コード").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("種類名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 状況コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_状況コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    状況コード "
                strSQL = strSQL & Chr(10) & "   ,状況名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    状況マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    状況コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("状況コード").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("状況名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 入社区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_入社区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "新規入社")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "再 入 社")

                '--------------------------------------------------------------------------
                ' 特別手当区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_特別手当区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_特別手当支給_なし) & GC_COMBO_SPLIT & "支給なし")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_特別手当支給_あり) & GC_COMBO_SPLIT & "支給あり")

                '--------------------------------------------------------------------------
                ' ＳＤ出勤区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_SD出勤区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "対象外")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "対象")

                '--------------------------------------------------------------------------
                ' 分類
                '--------------------------------------------------------------------------
            Case GC_CBOID_チェック分類

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    コード   "
                strSQL = strSQL & Chr(10) & "   ,名称漢字 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    名称マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    識別 = 'チェック分類' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(名称漢字).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(gfncFieldVal(.Fields("コード").Value) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("名称漢字").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 車輌保険徴収区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_車輌保険徴収区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "通常")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "3ヶ月4倍")

                '--------------------------------------------------------------------------
                ' 勤怠区分(略称)
                '--------------------------------------------------------------------------
            Case GC_CBOID_勤怠コード_略称

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    勤怠コード "
                strSQL = strSQL & Chr(10) & "  , 勤怠略称１ "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    勤怠マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    勤怠コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(勤怠略称１).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("勤怠コード").Value) & Space(GC_LEN_WORK_KBN), 1, GC_LEN_WORK_KBN) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("勤怠略称１").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 勤務班時間マスタ
                '--------------------------------------------------------------------------
            Case GC_CBOID_勤務班時間マスタ

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    勤務班時間コード                  "
                strSQL = strSQL & Chr(10) & "  , MAX(勤務班時間名) AS 勤務班時間名 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    勤務班時間マスタ "
                strSQL = strSQL & Chr(10) & "GROUP BY "
                strSQL = strSQL & Chr(10) & "    勤務班時間コード "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    勤務班時間コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(勤務班時間名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(gfncFieldVal(.Fields("勤務班時間コード").Value) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("勤務班時間名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 手数料計算区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_手数料計算区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "通常")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "税込")

                '--------------------------------------------------------------------------
                ' ハイヤーチェック
                '--------------------------------------------------------------------------
            Case GC_CBOID_ハイヤーチェック

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "チェックなし")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "チェックあり")

                '--------------------------------------------------------------------------
                ' 勤次郎部門コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_勤次郎部門コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    部門コード１ || "
                strSQL = strSQL & Chr(10) & "    部門コード２ || "
                strSQL = strSQL & Chr(10) & "    部門コード３ AS 部門コード "
                strSQL = strSQL & Chr(10) & "   ,部門名１     || "
                strSQL = strSQL & Chr(10) & "    部門名２     || "
                strSQL = strSQL & Chr(10) & "    部門名３     AS 部門名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    勤次郎部門マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    部門コード１ "
                strSQL = strSQL & Chr(10) & "   ,部門コード２ "
                strSQL = strSQL & Chr(10) & "   ,部門コード３ "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("部門コード").Value & Space(GC_LEN_KINJIRO_BUMON_ALL), 1, GC_LEN_KINJIRO_BUMON_ALL) & GC_COMBO_SPLIT & Trim(.Fields("部門名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 契約形態
                '--------------------------------------------------------------------------
            Case GC_CBOID_契約形態

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    契約形態   "
                strSQL = strSQL & Chr(10) & "   ,契約形態名 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    契約形態マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    契約形態 "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("契約形態").Value & Space(GC_LEN_CONTRACT_TYPE), 1, GC_LEN_CONTRACT_TYPE) & GC_COMBO_SPLIT & .Fields("契約形態名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 売上振分
                '--------------------------------------------------------------------------
            Case GC_CBOID_売上振分区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_売上振分_売上 & GC_COMBO_SPLIT & "売上")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_売上振分_立替付帯分 & GC_COMBO_SPLIT & "立替(付帯分)")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_売上振分_立替 & GC_COMBO_SPLIT & "立替")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_売上振分_その他 & GC_COMBO_SPLIT & "その他")
                '++修正開始　2023年09月12日:MK（手）- VB→VB.NET変換
                Call pobjTarget.Items.Add(GC_KBN_売上振分_仕入 & GC_COMBO_SPLIT & "仕入")
                Call pobjTarget.Items.Add(GC_KBN_売上振分_仕入付帯分 & GC_COMBO_SPLIT & "仕入付帯分")
                '--修正開始　2023年09月12日:MK（手）- VB→VB.NET変換

                '--------------------------------------------------------------------------
                ' 売上区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_売上区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_売上_事後 & GC_COMBO_SPLIT & "事後")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_売上_事前 & GC_COMBO_SPLIT & "事前")

                '--------------------------------------------------------------------------
                ' 税対象
                '--------------------------------------------------------------------------
            Case GC_CBOID_税対象

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "対象外")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "対象")

                '--------------------------------------------------------------------------
                ' 税通知
                '--------------------------------------------------------------------------
            Case GC_CBOID_税通知

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "外税")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "内税")

                '--------------------------------------------------------------------------
                ' 運管勤怠コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_運管勤怠コード, GC_CBOID_運管勤怠コード_警備

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    勤怠コード "
                strSQL = strSQL & Chr(10) & "   ,勤怠略称   "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    運管勤怠マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                If plngItemNo = GC_CBOID_運管勤怠コード Then
                    strSQL = strSQL & Chr(10) & "    運管区分 = 1 "
                ElseIf plngItemNo = GC_CBOID_運管勤怠コード_警備 Then '2023/03/06 警備追加
                    strSQL = strSQL & Chr(10) & "    警備区分 = 1 "
                End If
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    勤怠コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("勤怠コード").Value & Space(GC_LEN_WORK_KBN), 1, GC_LEN_WORK_KBN) & GC_COMBO_SPLIT & .Fields("勤怠略称").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 商品大分類
                '--------------------------------------------------------------------------
            Case GC_CBOID_商品大分類コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    商品大分類コード "
                strSQL = strSQL & Chr(10) & "   ,商品大分類名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    商品大分類マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    商品区分 = '2' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    商品大分類コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("商品大分類コード").Value & Space(GC_LEN_COMMODITY_BIG_GROUP), 1, GC_LEN_COMMODITY_BIG_GROUP) & GC_COMBO_SPLIT & .Fields("商品大分類名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（全て）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    会社コード "
                strSQL = strSQL & "   ,会社名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    会社マスタ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（運行管理）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_運管

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    会社コード "
                strSQL = strSQL & Chr(10) & "   ,会社名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    会社マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    区分１ = " & GC_FLG_ON & " "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("会社コード").Value & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & .Fields("会社名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（タクシー）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_タクシー

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    会社コード "
                strSQL = strSQL & Chr(10) & "   ,会社名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    会社マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    区分２ = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        '++修正開始　2021年05月30日:MK（手）- VB→VB.NET変換
                        'Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))
                        '--修正開始　2021年05月30日:MK（手）- VB→VB.NET変換

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（乗務員台帳）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_乗務員台帳

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    会社コード "
                strSQL = strSQL & Chr(10) & "   ,会社名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    会社マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    区分９ = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（従業員）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_従業員

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    会社コード "
                strSQL = strSQL & Chr(10) & "   ,会社名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    会社マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    区分４ = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（勤次郎）
                '--------------------------------------------------------------------------
            Case GC_CBOID_勤次郎会社コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    会社コード "
                strSQL = strSQL & Chr(10) & "   ,会社名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    勤次郎会社マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（ＺＤＳＤ管理）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_ZDSD

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    会社コード "
                strSQL = strSQL & "   ,会社名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    会社マスタ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    区分５ = 1 "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 振込先会社コード（運管）
                '--------------------------------------------------------------------------
            Case GC_CBOID_振込先会社コード_運管

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    会社コード "
                strSQL = strSQL & Chr(10) & "   ,振込先名義 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    会社マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    振込先名義 IS NOT NULL "
                ' 運行管理部有無フラグが(1：有)の会社
                strSQL = strSQL & Chr(10) & "AND 区分１ = '1' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(振込先名義).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("振込先名義").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 会社（シャトル）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_シャトル

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    会社コード "
                strSQL = strSQL & "   ,会社名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    会社マスタ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    区分３ = 1 "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 詳細状況コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_詳細状況コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    詳細状況コード "
                strSQL = strSQL & Chr(10) & "   ,詳細状況名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    詳細状況マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    詳細状況コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        pobjTarget.Items.Add(CStr(Mid(.Fields("詳細状況コード").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("詳細状況名").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ＭＫ区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_MK区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "ＭＫ以外")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "ＭＫ")

                '--------------------------------------------------------------------------
                ' 交通違反マスタ
                '--------------------------------------------------------------------------
            Case GC_CBOID_交通違反マスタ

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    交通違反コード "
                strSQL = strSQL & Chr(10) & "   ,交通違反名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    交通違反マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    交通違反名カナ, "
                strSQL = strSQL & Chr(10) & "    交通違反コード  "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("交通違反コード").Value & Space(3), 1, 3) & GC_COMBO_SPLIT & .Fields("交通違反名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ＺＤＳＤマスタ（処分）
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZDSDマスタ_処分

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    内容区分 "
                strSQL = strSQL & Chr(10) & "   ,内容     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ＺＤＳＤマスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ＺＤ種別 = 9 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    内容区分 "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("内容区分").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("内容").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ＺＤ種別（営業所）
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZD種別_営業所

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年09月25日:MK（手）- VB→VB.NET変換
                'Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&観光ルール違反")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "外商部ミスレポート")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "苦情")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "交通違反")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "社内ルール違反")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "身だしなみ違反")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "その他")

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "苦情")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "交通違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "社内ルール違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "身だしなみ違反")
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&観光ルール違反")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "外商部ミスレポート")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "その他")
                '--修正開始　2021年09月25日:MK（手）- VB→VB.NET変換

                '--------------------------------------------------------------------------
                ' 違反苦情分類マスタ
                '--------------------------------------------------------------------------
            Case GC_CBOID_違反苦情分類マスタ

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    分類コード "
                strSQL = strSQL & Chr(10) & "   ,分類名     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    違反苦情分類マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    分類コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("分類コード").Value & Space(3), 1, 3) & GC_COMBO_SPLIT & .Fields("分類名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 用途区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_用途区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Taxi) & GC_COMBO_SPLIT & "タクシー")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Hire) & GC_COMBO_SPLIT & "ハイヤー")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Jumbo) & GC_COMBO_SPLIT & "ジャンボ")

                '--------------------------------------------------------------------------
                ' サイズ区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_サイズ区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_SIZE_SML) & GC_COMBO_SPLIT & "小型")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_SIZE_MID) & GC_COMBO_SPLIT & "中型")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_SIZE_LAR) & GC_COMBO_SPLIT & "大型")

                '--------------------------------------------------------------------------
                ' 請求締日
                '--------------------------------------------------------------------------
            Case GC_CBOID_請求締日

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    締日 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    締日管理マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    締日 "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("締日").Value & Space(GC_LEN_CLAIM_CLOSING_DAY), 1, GC_LEN_CLAIM_CLOSING_DAY)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' タクシーハイヤー区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_タクシーハイヤー区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Taxi) & GC_COMBO_SPLIT & "タクシー")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Hire) & GC_COMBO_SPLIT & "ハイヤー")

                '--------------------------------------------------------------------------
                ' 貸付項目コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_貸付項目コード

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
                strSQL = strSQL & Chr(10) & "    貸付項目コード "
                strSQL = strSQL & Chr(10) & "   ,貸付項目名 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    貸付項目マスタ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    貸付項目コード "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("貸付項目コード").Value & Space(GC_LEN_KASHITUKE_KOUMOKU_CODE), 1, GC_LEN_KASHITUKE_KOUMOKU_CODE) & GC_COMBO_SPLIT & .Fields("貸付項目名").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 仮コード区分
                '--------------------------------------------------------------------------
            Case GC_CBOID_仮コード区分

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_本コード) & GC_COMBO_SPLIT & "本コード")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_仮コード) & GC_COMBO_SPLIT & "仮コード")

                '--------------------------------------------------------------------------
                ' 会社（ｾﾐﾊｲﾔ）
                '--------------------------------------------------------------------------
            Case GC_CBOID_会社コード_セミハイヤ

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    会社コード "
                strSQL = strSQL & "   ,会社名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    会社マスタ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    NVL(区分１２,0) = 1 "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(会社コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(会社名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("会社コード").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("会社名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 指導場所コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_指導場所コード

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    指導場所コード "
                strSQL = strSQL & "   ,指導場所名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    教習指導場所マスタ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(指導場所コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(指導場所名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("指導場所コード").Value) & Space(GC_LEN_SITE_CODE), 1, GC_LEN_SITE_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("指導場所名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 自家用車種コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_自家用車種コード

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    車種コード "
                strSQL = strSQL & "   ,車種名     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    自家用車種マスタ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(車種コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(車種名).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("車種コード").Value) & Space(3), 1, 3) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("車種名").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 自家用車種コード
                '--------------------------------------------------------------------------
            Case GC_CBOID_指導監督分類, GC_CBOID_指導監督分類_全集以外, GC_CBOID_指導監督分類_全集再教習以外

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    コード   "
                strSQL = strSQL & "   ,名称漢字 "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    名称マスタ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    識別 = '指導監督分類' "

                Select Case plngItemNo
                    Case GC_CBOID_指導監督分類

                        strSQL = strSQL & "AND BITAND(係数１,BIN_TO_NUM(0,0,1)) <> 0 "

                    Case GC_CBOID_指導監督分類_全集以外

                        strSQL = strSQL & "AND BITAND(係数１,BIN_TO_NUM(0,1,0)) <> 0 "

                    Case GC_CBOID_指導監督分類_全集再教習以外

                        strSQL = strSQL & "AND BITAND(係数１,BIN_TO_NUM(1,0,0)) <> 0 "

                    Case Else

                        ' 処理なし

                End Select

                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(コード) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(名称漢字).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("コード").Value) & Space(GC_LEN_SHIDO_KANTOKU_BUNRUI), 1, GC_LEN_SHIDO_KANTOKU_BUNRUI) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("名称漢字").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With
                '--------------------------------------------------------------------------
                ' 特殊勤務パターン(2014/01/27)
                '--------------------------------------------------------------------------
            Case GC_CBOID_特殊勤務パターン

                '// 初期値に空白行を追加
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++修正開始　2021年05月30:MK（手）- VB→VB.NET変換
                'Call pobjTarget.Items.Add("")
                Call pobjTarget.Items.Add("")
                '--修正開始　2021年05月30:MK（手）- VB→VB.NET変換

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "     コード "
                strSQL = strSQL & Chr(10) & "    ,名称漢字 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    名称マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    識別      = '特殊勤務パターン' "
                strSQL = strSQL & Chr(10) & "AND 名称漢字 IS NOT NULL   "
                strSQL = strSQL & Chr(10) & "ORDER BY コード   "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("コード").Value & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & .Fields("名称漢字").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' 上記以外
                '--------------------------------------------------------------------------
            Case Else

                ' 処理なし

        End Select

        Call gsubClearObject(objDysCboSet)

    End Sub
End Module