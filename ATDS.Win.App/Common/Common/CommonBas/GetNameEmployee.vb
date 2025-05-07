Option Strict Off
Option Explicit On
Imports MKOra.Core

Module basGatNameEmployee
    '******************************************************************************
    ' 関 数 名  : gfncGetNameEmployee
    ' スコープ  : Public
    ' 処理内容  : 従業員名漢字 取得
    ' 備    考  :
    ' 返 り 値  : 従業員名漢字
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     従業員コード
    '   pstrEmployeeName    String            O     従業員名漢字
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/03/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetNameEmployee(ByVal pstrEmployeeCode As String, ByRef pstrEmployeeName As String) As Boolean

        Dim strSQL As String
        '++修正開始　2021年09月11日:MK（手）- VB→VB.NET変換
        'Dim objDys従業員マスタ As Object
        Dim objDys従業員マスタ As OraDynaset
        '--修正開始　2021年09月11日:MK（手）- VB→VB.NET変換

        ' 戻り値を初期化（異常終了）
        gfncGetNameEmployee = True

        ' SQL文 作成
        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    従業員名漢字 "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    従業員マスタ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    従業員コード= '" & pstrEmployeeCode & "' "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDys従業員マスタ = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        With objDys従業員マスタ

            '従業員マスタの中に入力されたｷｰｺｰﾄﾞが有るかどうか判定
            'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF = False Then

                '戻り値を設定(正常終了)
                gfncGetNameEmployee = False

                '従業員マスタに入力されたｷｰｺｰﾄﾞがある場合、社員情報を表示
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstrEmployeeName = gfncFieldVal(.Fields("従業員名漢字").Value)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .Close()

        End With

        Call gsubClearObject(objDys従業員マスタ)

    End Function
End Module