Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basGetRengeNyukoSyuko
    '******************************************************************************
    ' 関 数 名  : gsubGetRengeNyukoSyuko
    ' スコープ  : Private
    ' 処理内容  : 入出庫範囲時刻  取得
    ' 備    考  :
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEigyobiSta      String            I     営業日（自）
    '   pstrEigyobiEnd      String            I     営業日（至）
    '   pstrSyukkoDate      String            O     出庫日時
    '   pstrNyukkoDate      String            O     入庫日時
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/11/04  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubGetRengeNyukoSyuko(ByVal pstrEigyobiSta As String, ByVal pstrEigyobiEnd As String, ByRef pstrSyukkoDate As String, ByRef pstrNyukkoDate As String)

        Dim strSQL As String
        '++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
        'Dim objDysTemp As Object
        Dim objDysTemp As OraDynaset
        '--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    MIN(出庫日時) AS 出庫日時 "
        strSQL = strSQL & Chr(10) & "  , MAX(入庫日時) AS 入庫日時 "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    ( "
        strSQL = strSQL & Chr(10) & "        SELECT "
        strSQL = strSQL & Chr(10) & "            ENT.営業日 || ENT.出庫時刻 || '00' AS 出庫日時 "
        strSQL = strSQL & Chr(10) & "          , ( "
        strSQL = strSQL & Chr(10) & "                CASE "
        strSQL = strSQL & Chr(10) & "                WHEN ENT.出庫時刻 > ENT.入庫時刻 THEN "
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                    TO_CHAR(TO_DATE(ENT.営業日) + 1,'yyyymmdd') || "
        strSQL = strSQL & Chr(10) & "                    ENT.入庫時刻                                || "
        strSQL = strSQL & Chr(10) & "                    '00'                                           "
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                ELSE"
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                    ENT.営業日   || "
        strSQL = strSQL & Chr(10) & "                    ENT.入庫時刻 || "
        strSQL = strSQL & Chr(10) & "                    '00'            "
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                END"
        strSQL = strSQL & Chr(10) & "            )                          AS 入庫日時 "
        strSQL = strSQL & Chr(10) & "        FROM "
        strSQL = strSQL & Chr(10) & "            営業日報テーブル ENT "
        strSQL = strSQL & Chr(10) & "          , 会社マスタ       KSM "
        strSQL = strSQL & Chr(10) & "        WHERE "
        strSQL = strSQL & Chr(10) & "            ENT.営業日     >= '" & pstrEigyobiSta & "' "
        strSQL = strSQL & Chr(10) & "        AND ENT.営業日     <= '" & pstrEigyobiEnd & "' "
        strSQL = strSQL & Chr(10) & "        AND ENT.入庫時刻   IS NOT NULL "
        strSQL = strSQL & Chr(10) & "        AND ENT.出庫時刻   IS NOT NULL "
        strSQL = strSQL & Chr(10) & "        AND ENT.会社コード  = KSM.会社コード(+) "
        strSQL = strSQL & Chr(10) & "        AND KSM.タクポ利用会社コード IS NOT NULL "
        strSQL = strSQL & Chr(10) & "    ) "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pstrSyukkoDate = gfncFieldVal(objDysTemp.Fields("出庫日時").Value)
        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pstrNyukkoDate = gfncFieldVal(objDysTemp.Fields("入庫日時").Value)

        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call objDysTemp.Close()

        'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        objDysTemp = Nothing

    End Sub
End Module
