Option Strict Off
Option Explicit On
Module basTraceLog
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : TraceLog.cls
    ' 内    容    : トレースログ　モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncRegistTraceLog       (ログ出力処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/07/01  ＫＳＲ             新規作成
    '
    '******************************************************************************

    '==============================================================================
    ' 定数
    '==============================================================================
    Public Const GC_LOG_TARGET_システムログ As String = "ＭＫシステムログテーブル"
    Public Const GC_LOG_TARGET_車輌管理ログ As String = "ＭＫ車輌管理ログテーブル"
    Public Const GC_LOG_TARGET_総務人事ログ As String = "ＭＫ総務人事ログテーブル"

    '******************************************************************************
    ' 関 数 名  : gfncRegistTraceLog
    ' スコープ  : Public
    ' 処理内容  : ログ出力処理
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   strDbUserName       String            I     データベース接続情報
    '   strDbPassword       String            I     データベース接続情報
    '   strDbTns            String            I     データベース接続情報
    '   strProgram          String            I     プログラム名
    '   strId               String            I     プログラムＩＤ
    '   strStatus           String            I     ログステータス
    '   strProcessStatus    String            I     処理ステータス
    '   strDescription      String            I     ログ詳細
    '   strLogTarget        String            I     対象ログテーブル
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/07/21  KSR                新規作成
    '
    '******************************************************************************
    Public Function gfncRegistTraceLog(ByVal strDbUserName As String, ByVal strDbPassword As String, ByVal strDbTns As String, ByVal strProgram As String, ByVal strId As String, ByVal strStatus As String, ByVal strProcessStatus As String, ByVal strDescription As String, ByVal strLogTarget As String, Optional ByVal blnWithTrans As Boolean = True) As Boolean
        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncRegistTraceLog"
        Dim strSQL As String
        Dim objLogSession As Object
        Dim blnLogTrans As Boolean
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncRegistTraceLog"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            gfncRegistTraceLog = False

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objLogSession As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim blnLogTrans As Boolean
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            If blnWithTrans = True Then
                'ログ登録用セッション
                Call gfncDBConnect(objLogSession, gobjOraDatabase, strDbUserName, strDbPassword, strDbTns)

                'UPGRADE_WARNING: Couldn't resolve default property of object objLogSession.BeginTrans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call objLogSession.BeginTrans()
                blnLogTrans = True
            End If

            Select Case strLogTarget

                Case GC_LOG_TARGET_システムログ

                    strSQL = ""
                    strSQL = strSQL & "INSERT INTO ＭＫシステムログテーブル ( "
                    strSQL = strSQL & "    ログSEQ "
                    strSQL = strSQL & "   ,サブメニュー名 "
                    strSQL = strSQL & "   ,プログラムID "
                    strSQL = strSQL & "   ,状態 "
                    strSQL = strSQL & "   ,処理ステータス "
                    strSQL = strSQL & "   ,ログ内容 "
                    strSQL = strSQL & "   ,更新従業員コード "
                    strSQL = strSQL & "   ,更新日付時刻 "
                    strSQL = strSQL & "   ,端末ID "
                    strSQL = strSQL & "   ,IPアドレス "
                    strSQL = strSQL & ") VALUES ( "
                    strSQL = strSQL & "    SEQ_ＭＫシステムログテーブル.NEXTVAL "
                    strSQL = strSQL & "   ,'" & strProgram & "' "
                    strSQL = strSQL & "   ,'" & strId & "' "
                    strSQL = strSQL & "   ,'" & strStatus & "' "
                    strSQL = strSQL & "   ,'" & strProcessStatus & "' "
                    strSQL = strSQL & "   ,'" & strDescription & "' "
                    strSQL = strSQL & "   ,'" & gclsLoginInfo.EmployeeCode & "' "
                    strSQL = strSQL & "   ,SYSDATE "
                    strSQL = strSQL & "   ,'" & gfncGetComputerName() & "' "
                    strSQL = strSQL & "   ,'" & gfncGetIpAddress() & "' "
                    strSQL = strSQL & ") "

                Case GC_LOG_TARGET_車輌管理ログ

                    strSQL = ""
                    strSQL = strSQL & "INSERT INTO ＭＫ車輌管理ログテーブル ( "
                    strSQL = strSQL & "    ログSEQ "
                    strSQL = strSQL & "   ,サブメニュー名 "
                    strSQL = strSQL & "   ,プログラムID "
                    strSQL = strSQL & "   ,状態 "
                    strSQL = strSQL & "   ,処理ステータス "
                    strSQL = strSQL & "   ,ログ内容 "
                    strSQL = strSQL & "   ,更新従業員コード "
                    strSQL = strSQL & "   ,更新日付時刻 "
                    strSQL = strSQL & "   ,端末ID "
                    strSQL = strSQL & "   ,IPアドレス "
                    strSQL = strSQL & ") VALUES ( "
                    strSQL = strSQL & "    SEQ_ＭＫ車輌管理ログテーブル.NEXTVAL "
                    strSQL = strSQL & "   ,'" & strProgram & "' "
                    strSQL = strSQL & "   ,'" & strId & "' "
                    strSQL = strSQL & "   ,'" & strStatus & "' "
                    strSQL = strSQL & "   ,'" & strProcessStatus & "' "
                    strSQL = strSQL & "   ,'" & strDescription & "' "
                    strSQL = strSQL & "   ,'" & gclsLoginInfo.EmployeeCode & "' "
                    strSQL = strSQL & "   ,SYSDATE "
                    strSQL = strSQL & "   ,'" & gfncGetComputerName() & "' "
                    strSQL = strSQL & "   ,'" & gfncGetIpAddress() & "' "
                    strSQL = strSQL & ") "

                Case GC_LOG_TARGET_総務人事ログ

                    strSQL = ""
                    strSQL = strSQL & "INSERT INTO ＭＫ総務人事ログテーブル ( "
                    strSQL = strSQL & "    ログSEQ "
                    strSQL = strSQL & "   ,サブメニュー名 "
                    strSQL = strSQL & "   ,プログラムID "
                    strSQL = strSQL & "   ,状態 "
                    strSQL = strSQL & "   ,処理ステータス "
                    strSQL = strSQL & "   ,ログ内容 "
                    strSQL = strSQL & "   ,更新従業員コード "
                    strSQL = strSQL & "   ,更新日付時刻 "
                    strSQL = strSQL & "   ,端末ID "
                    strSQL = strSQL & "   ,IPアドレス "
                    strSQL = strSQL & ") VALUES ( "
                    strSQL = strSQL & "    SEQ_ＭＫ総務人事ログテーブル.NEXTVAL "
                    strSQL = strSQL & "   ,'" & strProgram & "' "
                    strSQL = strSQL & "   ,'" & strId & "' "
                    strSQL = strSQL & "   ,'" & strStatus & "' "
                    strSQL = strSQL & "   ,'" & strProcessStatus & "' "
                    strSQL = strSQL & "   ,'" & strDescription & "' "
                    strSQL = strSQL & "   ,'" & gclsLoginInfo.EmployeeCode & "' "
                    strSQL = strSQL & "   ,SYSDATE "
                    strSQL = strSQL & "   ,'" & gfncGetComputerName() & "' "
                    strSQL = strSQL & "   ,'" & gfncGetIpAddress() & "' "
                    strSQL = strSQL & ") "

            End Select

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            If blnWithTrans = True Then
                'UPGRADE_WARNING: Couldn't resolve default property of object objLogSession.CommitTrans. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call objLogSession.CommitTrans()
                blnLogTrans = False
            End If

            gfncRegistTraceLog = True

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ed78775-84d9-414c-a9b7-acb3fdb3b056
            'PROC_END:

            'On Error Resume Next

            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            'If blnWithTrans = True Then
            ' トランザクション中のエラー発生時
            'If blnLogTrans = True Then

            ' トランザクションを終了し, 変更内容をキャンセル
            'UPGRADE_WARNING: Couldn't resolve default property of object objLogSession.Rollback. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'Call objLogSession.Rollback()

            'End If
            'UPGRADE_NOTE: Object objLogSession may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objLogSession = Nothing
            'End If

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:7ed78775-84d9-414c-a9b7-acb3fdb3b056
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f1055231-7a75-4e64-8245-2f59cb440363
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f1055231-7a75-4e64-8245-2f59cb440363

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f1055231-7a75-4e64-8245-2f59cb440363
PROC_FINALLY_END:
        '		On Error Resume Next
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex1 As Exception
        End Try
        Try
            If blnWithTrans = True Then
                Try
                    If blnLogTrans = True Then
                        Call objLogSession.Rollback()
                    End If
                Catch ex1 As Exception
                End Try
                objLogSession = Nothing
            End If
        Catch ex1 As Exception
        End Try
        Try
            Exit Function
        Catch ex1 As Exception
        End Try
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f1055231-7a75-4e64-8245-2f59cb440363
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
