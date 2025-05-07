Option Strict Off
Option Explicit On
Module basDispPopUpUNQ080
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : 銀行名称検索 ポップアップ 表示制御モジュール
    ' ファイル名  : DispPopUpUNQ080.bas
    ' 内    容    : ＭＫシステムで使用するポップアップの表示制御
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncDispPopUpUNQ080     (銀行名称検索       ポップアップ 表示)
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/01/15  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    ' 銀行名称検索 ポップアップ
    Private Const MC_POPUP_OBJECT_UNQ080 As String = "prjUNQ080.clsUNQ080"
    '******************************************************************************
    ' 関 数 名  : gfncDispPopUpUNQ080
    ' スコープ  : Public
    ' 処理内容  : 銀行名称検索 ポップアップ 表示制御処理
    ' 備    考  :
    ' 返 り 値  : True （ポップアップで選択）
    '             False（ポップアップで未選択）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   --------------------+-----------------+-----+------------------------------
    '   ptxtBankCode         TextBox           O     銀行コードテキスト
    '   pobjDatabase         String            I     ＤＢオブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/01/15  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncDispPopUpUNQ080(ByRef ptxtBankCode As System.Windows.Forms.TextBox, ByRef pobjDatabase As Object) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDispPopUpUNQ080"
        Dim objUNQ080 As Object
        Dim lngRet As Integer
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            ' 戻り値を初期化（未選択）
            gfncDispPopUpUNQ080 = False

            lngRet = gfncCreateObject(objUNQ080, MC_POPUP_OBJECT_UNQ080)

            ' 正常にオブジェクトを生成できなかった場合
            If lngRet <> 0 Then

                Exit Function

            End If

            '++修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
            objUNQ080 = New UNQ080.clsUNQ080
            '--修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
            With objUNQ080

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.BankCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtBankCode.Text = .BankCode

                    Call ptxtBankCode.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Return)

                Else

                    Call ptxtBankCode.Focus()

                End If

                ' 戻り値を設定
                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpUNQ080 = .SelectFlg

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:635cb6e5-978f-4398-863b-f6ed621235c2
            'PROC_END:

            'Call gsubClearObject(objUNQ080)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:635cb6e5-978f-4398-863b-f6ed621235c2
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:63cd01bf-eb1d-4968-a99e-63eb546b255d
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:63cd01bf-eb1d-4968-a99e-63eb546b255d

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:63cd01bf-eb1d-4968-a99e-63eb546b255d
PROC_FINALLY_END:
        Call gsubClearObject(objUNQ080)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:63cd01bf-eb1d-4968-a99e-63eb546b255d
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module

