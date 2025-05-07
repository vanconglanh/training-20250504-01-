Option Strict Off
Option Explicit On
Module basDispPopUpSYQ080
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : 車輌一覧照会 ポップアップ 表示制御モジュール
    ' ファイル名  : DispPopUpSYQ080.bas
    ' 内    容    : ＭＫシステムで使用するポップアップの表示制御
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncDispPopUpSYQ080     (車輌一覧照会       ポップアップ 表示)
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00.00    2007/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    ' 車輌一覧照会 ポップアップ
    Private Const MC_POPUP_OBJECT_SYQ080 As String = "prjSYQ080.clsSYQ080"
    '******************************************************************************
    ' 関 数 名  : gfncDispPopUpSYQ080
    ' スコープ  : Public
    ' 処理内容  : 車輌一覧照会 ポップアップ 表示制御処理
    ' 備    考  :
    ' 返 り 値  : True （ポップアップで選択）
    '             False（ポップアップで未選択）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pcboCarDistrictCode ComboBox          O     車輌番号地区コードコンボ
    '   ptxtCarNo1          TextBox           O     車輌番号１テキスト
    '   ptxtCarNo2          TextBox           O     車輌番号２テキスト
    '   ptxtCarNo3          TextBox           O     車輌番号３テキスト
    '   pclsLoginInfo       clsUnitLoginInfo  I     ログイン情報
    '   pobjDatabase        String            I     ＤＢオブジェクト
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   02.00.00    2007/10/12  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncDispPopUpSYQ080(ByRef pcboCarDistrictCode As System.Windows.Forms.ComboBox, ByRef ptxtCarNo1 As System.Windows.Forms.TextBox, ByRef ptxtCarNo2 As System.Windows.Forms.TextBox, ByRef ptxtCarNo3 As System.Windows.Forms.TextBox, ByVal pclsLoginInfo As clsUnitLoginInfo, ByVal pobjDatabase As Object) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncDispPopUpSYQ080"
        Dim objSYQ080 As Object
        Dim lngRet As Integer
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            '戻り値を初期化（未選択）
            gfncDispPopUpSYQ080 = False

            '++修正開始　2021年09月11日:MK（手）- VB→VB.NET変換
            'lngRet = gfncCreateObject(objSYQ080, MC_POPUP_OBJECT_SYQ080)
            objSYQ080 = New SYQ080.clsSYQ080
            '--修正開始　2021年09月11日:MK（手）- VB→VB.NET変換

            ' 正常に運行管理得意先照会画面を生成できなかった場合
            If lngRet <> 0 Then

                Exit Function

            End If
            '++修正開始　2021年06月07日:MK（手）- VB→VB.NET変換
            objSYQ080 = New SYQ080.clsSYQ080
            '--修正開始　2021年06月07日:MK（手）- VB→VB.NET変換


            With objSYQ080

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.DBObjectSet. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .DBObjectSet(pobjDatabase)

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CompanyCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .CompanyCode = pclsLoginInfo.CompanyCode

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.PostCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .PostCode = pclsLoginInfo.PostCode

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.SystemAuthority. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .SystemAuthority = pclsLoginInfo.SystemAuthority

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.LoadForm. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .LoadForm()

                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .SelectFlg = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarDistrictCode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call gsubSetComboListIndex(pcboCarDistrictCode, .CarDistrictCode, GC_LEN_CAR_DISTRICT_CODE)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarNo1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtCarNo1.Text = .CarNo1

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarNo2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtCarNo2.Text = .CarNo2

                    'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.CarNo3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    ptxtCarNo3.Text = .CarNo3

                    Call ptxtCarNo3.Focus()

                    System.Windows.Forms.Application.DoEvents()

                    Call gsubKeyEventSet(System.Windows.Forms.Keys.Return)

                Else

                    Call ptxtCarNo3.Focus()



                End If

                ' 戻り値を設定
                'UPGRADE_WARNING: Couldn't resolve default property of object objSYQ080.SelectFlg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                gfncDispPopUpSYQ080 = .SelectFlg

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2c40788a-8b99-4149-bbb5-2c8f4be4eb15
            'PROC_END:

            'Call gsubClearObject(objSYQ080)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:2c40788a-8b99-4149-bbb5-2c8f4be4eb15
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d
PROC_FINALLY_END:
        Call gsubClearObject(objSYQ080)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:9b1b4980-1fa5-426a-9ac0-d2166591fa2d
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module

