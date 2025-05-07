Option Strict Off
Option Explicit On
Module basDispPopUpUNQ090
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : 支店名称検索 ポップアップ 表示制御モジュール
    ' ファイル名  : DispPopUpUNQ090.bas
    ' 内    容    : ＭＫシステムで使用するポップアップの表示制御
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncDispPopUpUNQ090     (支店名称検索       ポップアップ 表示)
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
    ' 支店名称検索 ポップアップ
    Private Const MC_POPUP_OBJECT_UNQ090 As String = "prjUNQ090.clsUNQ090"
    '******************************************************************************
    ' 関 数 名  : gfncDispPopUpUNQ090
    ' スコープ  : Public
    ' 処理内容  : 支店名称検索 ポップアップ 表示制御処理
    ' 備    考  :
    ' 返 り 値  : True （ポップアップで選択）
    '             False（ポップアップで未選択）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   --------------------+-----------------+-----+------------------------------
    '   ptxtBankCode         TextBox           O     銀行コードテキスト
    '   ptxtBranchCode       TextBox           O     支店コードテキスト
    '   pobjDatabase         String            I     ＤＢオブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/01/15  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncDispPopUpUNQ090(ByRef ptxtBankCode As System.Windows.Forms.TextBox, ByRef ptxtBranchCode As System.Windows.Forms.TextBox, ByRef pobjDatabase As Object) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDispPopUpUNQ090"
        Dim objUNQ090 As Object
        Dim lngRet As Integer
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncDispPopUpUNQ090"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objUNQ090 As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim lngRet As Integer
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（未選択）
            gfncDispPopUpUNQ090 = False

            lngRet = gfncCreateObject(objUNQ090, MC_POPUP_OBJECT_UNQ090)

            ' 正常にオブジェクトを生成できなかった場合
            If lngRet <> 0 Then

                Exit Function

            End If

            '++修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
            objUNQ090 = New UNQ090.clsUNQ090
            '--修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
            With objUNQ090

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.BankCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .BankCode = ptxtBankCode.Text

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    If Len(ptxtBankCode.Text) = 0 Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.BankCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ptxtBankCode.Text = .BankCode

                        Call ptxtBankCode.Focus()

                        System.Windows.Forms.Application.DoEvents()

                        Call gsubKeyEventSet(System.Windows.Forms.Keys.Tab)

                        System.Windows.Forms.Application.DoEvents()

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.BranchCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtBranchCode.Text = .BranchCode

                    Call ptxtBranchCode.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Tab)

                    System.Windows.Forms.Application.DoEvents()

                Else

                    Call ptxtBranchCode.Focus()

                End If

                ' 戻り値を設定
                'UPGRADE_WARNING: Couldn't resolve default property of object objUNQ090.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpUNQ090 = .SelectFlg

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:71e482f5-5f05-4e77-92bb-71951d0d9546
            'PROC_END:

            'Call gsubClearObject(objUNQ090)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:71e482f5-5f05-4e77-92bb-71951d0d9546
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:cd244e48-b1e7-43cf-a229-028ca902d9d9
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:cd244e48-b1e7-43cf-a229-028ca902d9d9

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:cd244e48-b1e7-43cf-a229-028ca902d9d9
PROC_FINALLY_END:
        Call gsubClearObject(objUNQ090)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:cd244e48-b1e7-43cf-a229-028ca902d9d9
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module

