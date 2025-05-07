Option Strict Off
Option Explicit On
Module basDeleteTblKashitsuke
    '******************************************************************************
    ' 関 数 名  : gfncRegisterTblLoanDelete
    ' スコープ  : Public
    ' 処理内容  : 貸付削除テーブル 登録
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '
    ' 変更削除  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncRegisterTblLoanDelete(ByVal pstrJyugyoinCode As String) As Boolean

        '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncRegisterTblLoanDelete"
        Dim strSQL As String
        '--修正終了　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            gfncRegisterTblLoanDelete = True

            '--------------------------------------------------------------------------
            ' 貸付削除テーブル 登録
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 貸付削除テーブル "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        会社コード       "
            strSQL = strSQL & Chr(10) & "      , 所属コード       "
            strSQL = strSQL & Chr(10) & "      , 従業員コード     "
            strSQL = strSQL & Chr(10) & "      , 仮従業員コード   "
            strSQL = strSQL & Chr(10) & "      , 更新従業員コード "
            strSQL = strSQL & Chr(10) & "      , 更新日付時刻     "
            strSQL = strSQL & Chr(10) & "      , 更新プログラムID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    会社コード       "
            strSQL = strSQL & Chr(10) & "  , 所属コード       "
            strSQL = strSQL & Chr(10) & "  , 従業員コード     "
            strSQL = strSQL & Chr(10) & "  , 仮従業員コード   "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    貸付テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' 貸付明細削除テーブル 登録
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 貸付明細削除テーブル "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        従業員コード     "
            strSQL = strSQL & Chr(10) & "      , 枝番             "
            strSQL = strSQL & Chr(10) & "      , 貸付項目コード   "
            strSQL = strSQL & Chr(10) & "      , 貸付日           "
            strSQL = strSQL & Chr(10) & "      , 免除日           "
            strSQL = strSQL & Chr(10) & "      , 貸付金額         "
            strSQL = strSQL & Chr(10) & "      , 備考             "
            strSQL = strSQL & Chr(10) & "      , 給与控除有無     "
            strSQL = strSQL & Chr(10) & "      , 更新従業員コード "
            strSQL = strSQL & Chr(10) & "      , 更新日付時刻     "
            strSQL = strSQL & Chr(10) & "      , 更新プログラムID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    従業員コード     "
            strSQL = strSQL & Chr(10) & "  , 枝番             "
            strSQL = strSQL & Chr(10) & "  , 貸付項目コード   "
            strSQL = strSQL & Chr(10) & "  , 貸付日           "
            strSQL = strSQL & Chr(10) & "  , 免除日           "
            strSQL = strSQL & Chr(10) & "  , 貸付金額         "
            strSQL = strSQL & Chr(10) & "  , 備考             "
            strSQL = strSQL & Chr(10) & "  , 給与控除有無     "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    貸付明細テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' 戻り値を設定（正常終了）
            gfncRegisterTblLoanDelete = False

            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:620dc761-0e26-4f55-86bb-2d4e9f1d9905
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:620dc761-0e26-4f55-86bb-2d4e9f1d9905
        Catch ex As Exception
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
            '--修正終了　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
        '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncDeleteTblLoan
    ' スコープ  : Public
    ' 処理内容  : 貸付テーブル 削除
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrJyugyoinCode    String            I     従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncDeleteTblLoan(ByVal pstrJyugyoinCode As String) As Boolean

        '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDeleteTblLoan"
        Dim strSQL As String
        '--修正終了　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            gfncDeleteTblLoan = True

            '--------------------------------------------------------------------------
            ' 貸付履歴テーブル 削除
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE 貸付テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' 貸付明細履歴テーブル 削除
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE 貸付明細テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrJyugyoinCode & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' 戻り値を設定（正常終了）
            gfncDeleteTblLoan = False

            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:682206e9-4f1b-4845-b18f-3c3c3057ca88
        Catch ex As Exception
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:db287213-0954-4d0f-a70e-b03753d90d75
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:db287213-0954-4d0f-a70e-b03753d90d75
            '--修正終了　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:db287213-0954-4d0f-a70e-b03753d90d75
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:db287213-0954-4d0f-a70e-b03753d90d75
        '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncRegisterTblLoanLogDmy
    ' スコープ  : Public
    ' 処理内容  : 貸付仮履歴テーブル 登録
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrJyugyoinCodeDmy String            I     仮従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncRegisterTblLoanLogDmy(ByVal pstrJyugyoinCodeDmy As String) As Boolean

        '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncRegisterTblLoanLogDmy"
        Dim strSQL As String
        '--修正終了　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            gfncRegisterTblLoanLogDmy = True

            '--------------------------------------------------------------------------
            ' 貸付履歴テーブル 登録
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 貸付仮履歴テーブル "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        会社コード       "
            strSQL = strSQL & Chr(10) & "      , 所属コード       "
            strSQL = strSQL & Chr(10) & "      , 仮従業員コード   "
            strSQL = strSQL & Chr(10) & "      , 仮従業員名漢字   "
            strSQL = strSQL & Chr(10) & "      , 振替従業員コード "
            strSQL = strSQL & Chr(10) & "      , 更新従業員コード "
            strSQL = strSQL & Chr(10) & "      , 更新日付時刻     "
            strSQL = strSQL & Chr(10) & "      , 更新プログラムID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    会社コード       "
            strSQL = strSQL & Chr(10) & "  , 所属コード       "
            strSQL = strSQL & Chr(10) & "  , 仮従業員コード   "
            strSQL = strSQL & Chr(10) & "  , 仮従業員名漢字   "
            strSQL = strSQL & Chr(10) & "  , 振替従業員コード "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    貸付仮テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    仮従業員コード = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' 貸付明細履歴テーブル 登録
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO 貸付仮明細履歴テーブル "
            strSQL = strSQL & Chr(10) & "    ( "
            strSQL = strSQL & Chr(10) & "        仮従業員コード   "
            strSQL = strSQL & Chr(10) & "      , 枝番             "
            strSQL = strSQL & Chr(10) & "      , 貸付項目コード   "
            strSQL = strSQL & Chr(10) & "      , 支払日           "
            strSQL = strSQL & Chr(10) & "      , 貸付日           "
            strSQL = strSQL & Chr(10) & "      , 免除日           "
            strSQL = strSQL & Chr(10) & "      , 貸付金額         "
            strSQL = strSQL & Chr(10) & "      , 備考             "
            strSQL = strSQL & Chr(10) & "      , 給与控除有無     "
            strSQL = strSQL & Chr(10) & "      , 更新従業員コード "
            strSQL = strSQL & Chr(10) & "      , 更新日付時刻     "
            strSQL = strSQL & Chr(10) & "      , 更新プログラムID "
            strSQL = strSQL & Chr(10) & "    ) "
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    仮従業員コード   "
            strSQL = strSQL & Chr(10) & "  , 枝番             "
            strSQL = strSQL & Chr(10) & "  , 貸付項目コード   "
            strSQL = strSQL & Chr(10) & "  , 支払日           "
            strSQL = strSQL & Chr(10) & "  , 貸付日           "
            strSQL = strSQL & Chr(10) & "  , 免除日           "
            strSQL = strSQL & Chr(10) & "  , 貸付金額         "
            strSQL = strSQL & Chr(10) & "  , 備考             "
            strSQL = strSQL & Chr(10) & "  , 給与控除有無     "
            strSQL = strSQL & Chr(10) & "  , '" & gclsLoginInfo.EmployeeCode & "'        "
            strSQL = strSQL & Chr(10) & "  , SYSDATE          "
            strSQL = strSQL & Chr(10) & "  , '" & GC_PROGRAM_ID & "'         "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    貸付仮明細テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    仮従業員コード = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' 戻り値を設定（正常終了）
            gfncRegisterTblLoanLogDmy = False

            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:db287213-0954-4d0f-a70e-b03753d90d75
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:db287213-0954-4d0f-a70e-b03753d90d75
        Catch ex As Exception
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
            '--修正終了　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
        '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncDeleteTblLoanDmy
    ' スコープ  : Public
    ' 処理内容  : 貸付仮テーブル 削除
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrJyugyoinCodeDmy String            I     仮従業員コード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/10/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncDeleteTblLoanDmy(ByVal pstrJyugyoinCodeDmy As String) As Boolean

        '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDeleteTblLoanDmy"
        Dim strSQL As String
        '--修正終了　2021年06月23:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換



            ' 戻り値を初期化（異常終了）
            gfncDeleteTblLoanDmy = True

            '--------------------------------------------------------------------------
            ' 貸付履歴テーブル 削除
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE 貸付仮テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    仮従業員コード = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '--------------------------------------------------------------------------
            ' 貸付明細履歴テーブル 削除
            '--------------------------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE 貸付仮明細テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    仮従業員コード = '" & pstrJyugyoinCodeDmy & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            ' 戻り値を設定（正常終了）
            gfncDeleteTblLoanDmy = False

            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:88ed3838-f9fd-4d54-bcfb-ba809aac10ff
        Catch ex As Exception
            '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換
            'Resume PROC_END
            '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
            'GoTo PROC_END
            GoTo PROC_FINALLY_END
            '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
            '--修正終了　2021年06月23:MK（ツール）- VB_003 VB→VB.NET変換

            '++修正開始　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月23:MK（ツール）- VB_523 VB→VB.NET変換	T:a7412466-44ee-4e22-a2a6-0d97db6d7e17
        '--修正終了　2021年06月23:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
