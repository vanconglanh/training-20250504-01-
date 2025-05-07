Option Strict Off
Option Explicit On
Module basGetSpreadText
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : GetSpreadText.bas
    ' 内    容    : スプレッドコントロール テキスト 取得 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetSpreadText            (スプレッドコントロールのテキスト 取得)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '******************************************************************************
    ' 関 数 名  : gfncGetSpreadText
    ' スコープ  : Public
    ' 処理内容  : スプレッドコントロールのテキスト 取得
    ' 備    考  : 元ネタは営業日報入力
    ' 返 り 値  : 取得したデータ
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   psprTar             vaSpread          I/O   スプレッドコントロール
    '   plngCol             Long              I/O   取得するセルの列
    '   plngRow             Long              I/O   取得するセルの行
    '   pvntConv            Variant           I/O   ブランクの場合の変換データ
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  廣井  芳明         新規作成
    '
    '******************************************************************************
    '++修正開始　2021年04月21:MK（ツール）- AxFPSpread VB→VB.NET変換
    'Public Function gfncGetSpreadText(ByRef psprTar As AxFPSpread.AxvaSpread, ByVal plngCol As Integer, ByVal plngRow As Integer, Optional ByVal pvntConv As Object = "") As Object
    Public Function gfncGetSpreadText(ByRef psprTar As Common.CustomizeFPSpread, ByVal plngCol As Integer, ByVal plngRow As Integer, Optional ByVal pvntConv As Object = "") As Object
        '--修正終了　2021年04月21:MK（ツール）- AxFPSpread VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetSpreadText"
        Dim vntTemp As Object
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '++修正開始　2021年06月05日:MK（手）- VB→VB.NET変換
            'vntTemp = System.DBNull.Value
            vntTemp = Nothing
            '--修正開始　2021年06月05日:MK（手）- VB→VB.NET変換

            Call psprTar.GetText(plngCol, plngRow, vntTemp)

            'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            vntTemp = (gfncFieldVal(vntTemp))

            If Len(vntTemp) = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object pvntConv. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                vntTemp = pvntConv
            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21123112-89c7-4897-8cf8-c974a0d11bf7
            'PROC_END:

            'UPGRADE_WARNING: Couldn't resolve default property of object vntTemp. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object gfncGetSpreadText. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'gfncGetSpreadText = vntTemp

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:21123112-89c7-4897-8cf8-c974a0d11bf7
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0
PROC_FINALLY_END:
        gfncGetSpreadText = vntTemp
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:ef2bb0a1-e9cb-4bab-8a6b-7bfde42920b0
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module

