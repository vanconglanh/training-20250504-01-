Option Strict Off
Option Explicit On
Module basGetEmployeeInfo
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetEmployeeInfo.bas
    ' 内    容    : 従業員マスタ 情報 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetEmployeeInfo          (従業員情報取得)
    '               <Private>
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetEmployeeInfo(ByVal pstrEmployeeCode As String, ByRef pclsLoginInfo As clsUnitLoginInfo, Optional ByRef pstrPassWord As String = "") As Boolean

        Dim strSQL As String
        Dim objDys従業員マスタ As Object

        ' 初期値を設定(異常終了)
        gfncGetEmployeeInfo = True

        ' SQL文 作成
        strSQL = "Select "
        strSQL = strSQL & "  従業員マスタ.所属コード,   "
        strSQL = strSQL & "  従業員マスタ.従業員コード, "
        strSQL = strSQL & "  従業員マスタ.従業員名漢字, "
        strSQL = strSQL & "  従業員マスタ.パスワード,   "
        strSQL = strSQL & "  従業員マスタ.役職位コード, "
        strSQL = strSQL & "  従業員マスタ.会社コード, "
        strSQL = strSQL & "  名称マスタ.係数１, "
        strSQL = strSQL & "  NVL(従業員マスタ.退社予定日,'99999999') 退社予定日, "
        strSQL = strSQL & "  部署マスタ.システム権限,"
        strSQL = strSQL & "  従業員マスタ.ランク, "
        strSQL = strSQL & "  TO_CHAR(SYSDATE,'YYYYMMDD')  システム日付 "

        strSQL = strSQL & " From "
        strSQL = strSQL & "  従業員マスタ, "
        strSQL = strSQL & "  部署マスタ, "
        strSQL = strSQL & "  名称マスタ "
        strSQL = strSQL & " Where 従業員マスタ.従業員コード = '" & pstrEmployeeCode & "'"
        strSQL = strSQL & "   And 従業員マスタ.所属コード = 部署マスタ.所属コード(+)"
        strSQL = strSQL & "   And 従業員マスタ.会社コード = 部署マスタ.会社コード(+)"
        strSQL = strSQL & "   And 従業員マスタ.役職位コード = 名称マスタ.コード(+)"
        strSQL = strSQL & "   And '役職位' = 名称マスタ.識別(+)"

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDys従業員マスタ = gobjOraDatabase.CreateDynaset(strSQL, &H1)

        With objDys従業員マスタ

            'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF Then

                'エラーメッセージ表示
                Call MsgBox(GC_ERR_MSG_0003, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                Exit Function

            Else

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .Fields("退社予定日").Value < VB6.Format(Now, "YYYYMMDD") Then

                    'エラーメッセージ表示
                    Call MsgBox(GC_ERR_MSG_9001, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.LoginDate = gfncFieldVal(.Fields("システム日付").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstrPassWord = gfncFieldVal(.Fields("パスワード").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.CompanyCode = gfncFieldVal(.Fields("会社コード").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.PostCode = gfncFieldVal(.Fields("所属コード").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.SystemAuthority = gfncFieldCur(.Fields("システム権限").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncFieldCur(.Fields("係数１").Value) <> 0 Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pclsLoginInfo.SystemAuthority = gfncFieldCur(.Fields("係数１").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.Rank = gfncFieldVal(.Fields("ランク").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.EmployeeName = gfncFieldVal(.Fields("従業員名漢字").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys従業員マスタ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.OfficialPosition = gfncFieldCur(.Fields("役職位コード").Value)

            End If

        End With

        ' 初期値を設定(正常終了)
        gfncGetEmployeeInfo = False

    End Function

    ''''Public Function gfncGetEmployeeName(ByVal pstrEmployeeCode As String, _
    '''''                                    ByRef pstrEmployeeName As String) As Boolean
    ''''
    ''''    Dim strSQL                              As String
    ''''    Dim objDys従業員マスタ                  As Object
    ''''
    ''''    '戻り値を初期化(異常終了)
    ''''    gfncGetEmployeeName = True
    ''''
    ''''    ' SQL文 作成
    ''''    strSQL = "SELECT "
    ''''    strSQL = strSQL & "  従業員マスタ.従業員名漢字, "
    ''''    strSQL = strSQL & "  従業員マスタ.所属コード, "
    ''''    strSQL = strSQL & "  部署マスタ.部署名 "
    ''''    strSQL = strSQL & " FROM "
    ''''    strSQL = strSQL & "  従業員マスタ, "
    ''''    strSQL = strSQL & "  部署マスタ "
    ''''    strSQL = strSQL & " WHERE "
    '''''TSL YOSHI 2007.05.01 会社コード付加対応 INSERT START
    ''''    strSQL = strSQL & "  従業員マスタ.会社コード = 部署マスタ.会社コード(+) AND "
    '''''TSL YOSHI 2007.05.01 会社コード付加対応 INSERT END
    ''''    strSQL = strSQL & "  従業員マスタ.所属コード = 部署マスタ.所属コード(+) AND "
    ''''    strSQL = strSQL & "  従業員マスタ.従業員コード= '" & pstrEmployeeCode & "' "
    ''''
    ''''    Set objDys従業員マスタ = gobjOraDatabase.CreateDynaset(strSQL, &H1&)
    ''''
    ''''    With objDys従業員マスタ
    ''''
    ''''        '従業員マスタの中に入力されたｷｰｺｰﾄﾞが有るかどうか判定
    ''''        If .eof = False Then
    ''''
    ''''            '戻り値を設定(正常終了)
    ''''            gfncGetEmployeeName = False
    ''''
    ''''            '従業員マスタに入力されたｷｰｺｰﾄﾞがある場合、社員情報を表示
    ''''            pstrEmployeeName = gfncFieldVal(.Fields("従業員名漢字").Value)
    ''''
    ''''        End If
    ''''
    ''''        .Close
    ''''
    ''''    End With
    ''''
    ''''End Function
End Module