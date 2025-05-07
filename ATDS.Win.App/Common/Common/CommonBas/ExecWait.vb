Option Strict Off
Option Explicit On
Module basExecWait
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : ExecWait.bas
    ' 内    容    : 外部プログラム 起動 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncExecWait                 (外部プログラム起動処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    Private Const PROCESS_QUERY_INFORMATION As Integer = &H400

    '==============================================================================
    ' ＡＰＩ関数
    '==============================================================================
    ' 既存プロセスオブジェクトのハンドル取得
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer

    ' 既存プロセスオブジェクトのハンドル開放
    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer

    ' プロセスの終了ステータス取得
    Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As Integer, ByRef lpExitCode As Integer) As Integer

    ' 実行停止
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    '******************************************************************************
    ' 関 数 名  : gfncExecWait
    ' スコープ  :
    ' 処理内容  : 外部プログラム起動処理
    ' 備    考  :
    ' 返 り 値  :
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrPathName        String            I     実行ファイルへのパス
    '   pintStyle           String            I     実行時の表示スタイル
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncExecWait(ByVal pstrPathName As String, ByVal pintStyle As Short) As Boolean

        Dim lngPID As Integer ' プロセスID
        Dim lngPrcHdl As Integer ' プロセスハンドル
        Dim lngEndCd As Integer ' 終了コード
        Dim lngRet As Integer ' 戻り値

        ' 復帰情報設定(異常終了)
        gfncExecWait = False

        '--------------------------------------------------------------------------
        ' 処理起動
        '--------------------------------------------------------------------------

        '++修正開始　2022年01月15日:MK（手）- VB→VB.NET変換
        Dim intExe As Int16 = pstrPathName.IndexOf(".exe")
        If intExe > 0 Then
            Dim strFilePath As String = "C:\"
            Try
                Dim intLastPath As Int16 = InStrRev(pstrPathName, "\", intExe)
                '++修正開始　2022年01月24日:MK（手）- VB→VB.NET変換
                'strFilePath = pstrPathName.Substring(0, intLastPath)
                '--修正開始　2022年01月24日:MK（手）- VB→VB.NET変換
            Catch ex As Exception

            End Try

            If Not IO.Directory.Exists(strFilePath) Then
                Throw New Exception("パスが見つかりません。")
            End If
        End If
        '--修正開始　2022年01月15日:MK（手）- VB→VB.NET変換
        lngPID = Shell(pstrPathName, pintStyle)
        ' 外部実行形式の起動に失敗した時
        If lngPID = 0 Then

            ' 終了
            Exit Function

        End If

        lngPrcHdl = OpenProcess(PROCESS_QUERY_INFORMATION, True, lngPID)

        '--------------------------------------------------------------------------
        ' 停止待ち
        '--------------------------------------------------------------------------
        Do

            lngRet = GetExitCodeProcess(lngPrcHdl, lngEndCd)

            Debug.Print("lngEndCd : " & lngEndCd)

            '        If lngEndCd <> 259 Then

            Exit Do

            '        End If

            Call Sleep(100)

            System.Windows.Forms.Application.DoEvents()

        Loop While lngEndCd

        CloseHandle(lngPrcHdl)

        ' 正常終了
        gfncExecWait = True

    End Function
End Module