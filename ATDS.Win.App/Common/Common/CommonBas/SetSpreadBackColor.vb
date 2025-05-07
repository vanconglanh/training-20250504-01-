Option Strict Off
Option Explicit On
Module basSetSpreadBackColor
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetSpreadText.bas
    ' 内    容    : スプレッドコントロール テキスト 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gsubSetSpreadBackColor       (スプレッド背景色  設定)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/09  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : gsubSetSpreadBackColor
    ' スコープ  : Public
    ' 処理内容  : スプレッド背景色  設定
    ' 備    考  : スプレッドシートの背景色を設定
    ' 返 り 値  : なし
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   psprTar             vaSpread          I     設定対象
    '   plngRow             Long              I     行
    '   plngBgColor         Long              I     背景色
    '   plngFrColor         Long              I     文字色
    '   plngCol             Long              I     列（自）
    '   plngCol2            Long              I     列（至）
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2008/04/21  廣井  芳明         新規作成
    '
    '******************************************************************************
    '++修正開始　2021年05月07:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Sub gsubSetSpreadBackColor(ByRef psprTar As AxFPSpread.AxvaSpread, ByVal plngRow As Integer, ByVal plngBgColor As Integer, ByVal plngFrColor As Integer, Optional ByVal plngCol As Integer = -1, Optional ByVal plngCol2 As Integer = -1)
    Public Sub gsubSetSpreadBackColor(ByRef psprTar As Common.CustomizeFPSpread, ByVal plngRow As Integer, ByVal plngBgColor As Integer, ByVal plngFrColor As Integer, Optional ByVal plngCol As Integer = -1, Optional ByVal plngCol2 As Integer = -1)
        '--修正終了　2021年05月07:MK（ツール）- AxFPSpread VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubSetSpreadBackColor"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gsubSetSpreadBackColor"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            With psprTar

                .BlockMode = True

                .Row = plngRow
                .Row2 = plngRow

                If plngCol = -1 Then

                    '++修正開始　2021年06月12日:MK（手）- VB→VB.NET変換
                    '.Col = 1
                    '.Col2 = .MaxCols
                    .Col = 0
                    .Col2 = .MaxCols - 1
                    '--修正開始　2021年06月12日:MK（手）- VB→VB.NET変換

                Else

                    .Col = plngCol

                    If plngCol2 = -1 Then

                        .Col2 = plngCol

                    Else

                        .Col2 = plngCol2

                    End If

                End If

                '++修正開始　2021年07月13日:MK（手）- VB→VB.NET変換
                '.BackColor = System.Drawing.ColorTranslator.FromOle(plngBgColor)
                '.ForeColor = System.Drawing.ColorTranslator.FromOle(plngFrColor)
                .ActiveSheet.Cells(.Row, .Col, .Row2, .Col2).BackColor = System.Drawing.ColorTranslator.FromOle(plngBgColor)
                .ActiveSheet.Cells(.Row, .Col, .Row2, .Col2).ForeColor = System.Drawing.ColorTranslator.FromOle(plngFrColor)

                '--修正開始　2021年07月13日:MK（手）- VB→VB.NET変換
                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                '.CellBorderColor = System.Drawing.Color.Black
                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                .BlockMode = False

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6be398dc-ef91-4ae1-8c00-f235a42e3554
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:6be398dc-ef91-4ae1-8c00-f235a42e3554
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:37d833b1-5e14-47af-9968-d4477a597083
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:37d833b1-5e14-47af-9968-d4477a597083

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:37d833b1-5e14-47af-9968-d4477a597083
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:37d833b1-5e14-47af-9968-d4477a597083
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
End Module

