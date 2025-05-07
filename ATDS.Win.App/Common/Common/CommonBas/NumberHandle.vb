Option Strict Off
Option Explicit On
Module basNumberHandle
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : NumberHandle.bas
    ' 内    容    : 従業員コードの採番 モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncNumberHandle             (従業員コード（社員）自動採番処理)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/10/27  KSR                新規作成
    '
    '******************************************************************************


    '******************************************************************************
    ' 関 数 名  : gfncNumberHandle
    ' スコープ  : Public
    ' 処理内容  : 従業員コード（社員）自動採番処理
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCD      String            I/O   採番従業員コード
    '   pstrKana            String            I/O   従業員名カナ
    '   pstrCompanyCD       String            I     会社コード
    '   pblnFlgMsg          Boolean           I     メッセージ出力有無
    '                                                 True  : メッセージ出力有
    '                                                 False : メッセージ出力無
    '   pblnFlgPointer      Boolean           I     マウスポインタ制御有無
    '                                                 True  : マウスポインタ制御有
    '                                                 False : マウスポインタ制御無
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/10/27  ＫＳＲ             新規作成（営業所モジュールより移行）
    '
    '******************************************************************************
    Public Function gfncNumberHandle(ByRef pstrEmployeeCD As String, ByRef pstrKana As String, ByVal pstrCompanyCD As String, Optional ByVal pblnFlgMsg As Boolean = True, Optional ByVal pblnFlgPointer As Boolean = True) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Dim strSQL As String
        Dim objDysJ As Object '従業員マスタのOraDynaset
        Dim objDysM As Object 'マスタのOraDynaset
        Dim intIndx As Short
        Dim str退避コード As String
        Dim strW従業員コード As String
        Dim str従業員コード先頭文字 As String
        Dim intMode As Short
        Const C_NAME_FUNCTION As String = "gfncNumberHandle"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDysJ As Object '従業員マスタのOraDynaset
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDysM As Object 'マスタのOraDynaset
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intIndx As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim str退避コード As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strW従業員コード As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim str従業員コード先頭文字 As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intMode As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncNumberHandle"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '戻り値初期化
            gfncNumberHandle = False

            'ひらがなをカナに変換
            pstrKana = StrConv(RTrim(pstrKana), VbStrConv.Katakana)
            '全角文字を半角に変換
            pstrKana = StrConv(pstrKana, VbStrConv.Narrow)

            '採番方法の判定（エムケイの採番　OR　エムケイ以外の採番）
            strSQL = ""
            strSQL = "SELECT 社員従業員コード先頭文字"
            strSQL = strSQL & " FROM 会社マスタ"
            strSQL = strSQL & " WHERE 会社コード = '" & RTrim(pstrCompanyCD) & "'"
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysM = gobjOraDatabase.CreateDynaset(strSQL, &H1)

            With objDysM

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then
                    'エムケイの採番
                    intMode = 0
                    str従業員コード先頭文字 = ""
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Trim(gfncFieldVal(.Fields("社員従業員コード先頭文字").Value)) = "" Then
                        'エムケイの採番
                        intMode = 0
                        str従業員コード先頭文字 = ""
                    Else
                        'エムケイ以外の採番
                        intMode = 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        str従業員コード先頭文字 = RTrim(gfncFieldVal(.Fields("社員従業員コード先頭文字").Value))
                    End If
                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .Close()
            End With

            'UPGRADE_NOTE: Object objDysM may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysM = Nothing

            Select Case intMode
            'エムケイの採番
                Case 0
                    '従業員コード採番テーブルから入力カナ(先頭一文字目)で情報を取得
                    strSQL = "SELECT *"
                    strSQL = strSQL & " FROM 従業員コード採番テーブル"
                    strSQL = strSQL & " WHERE 従業員名カナ = '" & Mid(pstrKana, 1, 1) & "'"
                    strSQL = strSQL & " ORDER BY 採番番号"
                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    objDysM = gobjOraDatabase.CreateDynaset(strSQL, &H1)

                    '入力されたｷｰｺｰﾄﾞが有るかどうか判定
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If objDysM.EOF Then
                        gfncNumberHandle = True
                        If pblnFlgMsg Then
                            'ｴﾗｰﾒｯｾｰｼﾞを表示します
                            MsgBox("従業員コード採番に従業員カナが登録されていないため、採番できません。", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                        End If
                        If pblnFlgPointer Then
                            '砂時計ﾎﾟｲﾝﾀを解除します。
                            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        End If
                        Exit Function
                    Else
                        'ﾙｰﾌﾟ①開始
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Do Until objDysM.EOF
                            'ﾜｰｸの初期設定
                            pstrEmployeeCD = ""
                            str退避コード = ""

                            '「従業員マスタ」と「従業員異動テーブル」から採番コードで使用済情報を取得(先頭3桁で取得)
                            strSQL = "SELECT SUBSTR(従業員コード,4,4) 使用済コード"
                            strSQL = strSQL & " FROM 従業員マスタ"
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            strSQL = strSQL & " WHERE SUBSTR(従業員コード,1,3) = '" & gfncFieldVal(objDysM.Fields("採番コード").Value) & "'"

                            strSQL = strSQL & "UNION "

                            strSQL = strSQL & "SELECT SUBSTR(新従業員コード,4,4) 使用済コード"
                            strSQL = strSQL & " FROM 従業員異動テーブル"
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            strSQL = strSQL & " WHERE SUBSTR(新従業員コード,1,3) = '" & gfncFieldVal(objDysM.Fields("採番コード").Value) & "'"
                            strSQL = strSQL & "   AND SUBSTR(新従業員コード,4,4) >= '0001'"
                            strSQL = strSQL & "   AND SUBSTR(新従業員コード,4,4) <= '9999'"
                            strSQL = strSQL & "   AND 異動種別 = 4"
                            strSQL = strSQL & "   AND 取消サイン = 0"

                            strSQL = strSQL & " ORDER BY 使用済コード"

                            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            objDysJ = gobjOraDatabase.CreateDynaset(strSQL, &H1)

                            '入力されたｷｰｺｰﾄﾞが有るかどうか判定
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            If objDysJ.EOF Then
                                '"0001"を設定
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                pstrEmployeeCD = gfncFieldVal(objDysM.Fields("採番コード").Value) & "0001"

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysJ.Close()
                                'ﾙｰﾌﾟ①を抜ける
                                Exit Do

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysJ.Fields(使用済コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            ElseIf "0001" < gfncFieldVal(objDysJ.Fields("使用済コード").Value) Then
                                '"0001"を設定
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                pstrEmployeeCD = gfncFieldVal(objDysM.Fields("採番コード").Value) & "0001"

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysJ.Close()
                                'ﾙｰﾌﾟ①を抜ける
                                Exit Do

                            Else
                                'ﾙｰﾌﾟ②開始
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                Do Until objDysJ.EOF
                                    '退避ｺｰﾄﾞをﾜｰｸに退避
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    str退避コード = gfncFieldVal(objDysJ.Fields("使用済コード").Value)

                                    '次のﾚｺｰﾄﾞをREAD
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    objDysJ.MoveNext()
                                    'ﾃﾞｰﾀが無い場合
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    If objDysJ.EOF Then
                                        If str退避コード = "9999" Then
                                            'ﾙｰﾌﾟ②を抜ける
                                            Exit Do
                                        Else
                                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            pstrEmployeeCD = gfncFieldVal(objDysM.Fields("採番コード").Value) & VB6.Format(CInt(str退避コード) + 1, "0000")
                                            'ﾙｰﾌﾟ②を抜ける
                                            Exit Do
                                        End If
                                    Else
                                        '(使用済 - 退避コード) >= 2(ｺｰﾄﾞ間に空きがある) なら 退避コード + 1 を設定
                                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                        If (gfncFieldCur(objDysJ.Fields("使用済コード").Value) - CInt(str退避コード)) >= 2 Then
                                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            pstrEmployeeCD = gfncFieldVal(objDysM.Fields("採番コード").Value) & VB6.Format(CInt(str退避コード) + 1, "0000")
                                            'ﾙｰﾌﾟ②を抜ける
                                            Exit Do
                                        End If
                                    End If
                                Loop

                                '採番された場合は処理を抜ける。
                                If pstrEmployeeCD = "" Then
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    objDysM.MoveNext()
                                Else
                                    'ﾙｰﾌﾟ①を抜ける
                                    Exit Do
                                End If
                            End If
                        Loop
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        objDysM.Close()
                    End If

                    '従業員コードが設定されなかった場合はﾒｯｾｰｼﾞ
                    If pstrEmployeeCD = "" Then
                        gfncNumberHandle = True
                        If pblnFlgMsg Then
                            'ｴﾗｰﾒｯｾｰｼﾞを表示します
                            MsgBox("空き番号がありません。", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                        End If
                        If pblnFlgPointer Then
                            '砂時計ﾎﾟｲﾝﾀを解除します。
                            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        End If
                        Exit Function
                    End If

                'エムケイ以外の採番
                Case 1
                    '            'ﾛｸﾞｲﾝ部署でﾜｰｸの先頭２文字を決定
                    '            Select Case pstrCompanyCD
                    '                '名古屋
                    '                Case "270"
                    '                    strW従業員コード = "81"
                    '                '神戸
                    '                Case "280"
                    '                    strW従業員コード = "80"
                    '                '大阪
                    '                Case "99011", "99021"
                    '                    strW従業員コード = "33"
                    '                '三和
                    '                Case "910"
                    '                    strW従業員コード = "76"
                    '                '駒
                    '                Case "920"
                    '                    strW従業員コード = "75"
                    '                Case Else
                    '                    gfncNumberHandle = True
                    '                    If pblnFlgMsg Then
                    '                        'ｴﾗｰﾒｯｾｰｼﾞを表示します
                    '                        MsgBox "頭２文字が設定されていません。", _
                    ''                               vbOKOnly + vbCritical, GC_ERR_TITLE
                    '                    End If
                    '                    If pblnFlgPointer Then
                    '                        '砂時計ﾎﾟｲﾝﾀを解除します。
                    '                        Screen.MousePointer = vbDefault
                    '                    End If
                    '                    Exit Function
                    '            End Select

                    strW従業員コード = str従業員コード先頭文字

                    '入力ｶﾅの先頭文字でﾜｰｸの３桁目を決定
                    Select Case Mid(pstrKana, 1, 1)
                        Case "ｱ", "ｧ", "ｲ", "ｨ", "ｳ", "ｩ", "ｴ", "ｪ", "ｵ", "ｫ"
                            strW従業員コード = strW従業員コード & "0"
                        Case "ｶ", "ｷ", "ｸ", "ｹ", "ｺ"
                            strW従業員コード = strW従業員コード & "1"
                        Case "ｻ", "ｼ", "ｽ", "ｾ", "ｿ"
                            strW従業員コード = strW従業員コード & "2"
                        Case "ﾀ", "ﾁ", "ﾂ", "ｯ", "ﾃ", "ﾄ"
                            strW従業員コード = strW従業員コード & "3"
                        Case "ﾅ", "ﾆ", "ﾇ", "ﾈ", "ﾉ"
                            strW従業員コード = strW従業員コード & "4"
                        Case "ﾊ", "ﾋ", "ﾌ", "ﾍ", "ﾎ"
                            strW従業員コード = strW従業員コード & "5"
                        Case "ﾏ", "ﾐ", "ﾑ", "ﾒ", "ﾓ"
                            strW従業員コード = strW従業員コード & "6"
                        Case "ﾔ", "ｬ", "ﾕ", "ｭ", "ﾖ", "ｮ"
                            strW従業員コード = strW従業員コード & "7"
                        Case "ﾗ", "ﾘ", "ﾙ", "ﾚ", "ﾛ"
                            strW従業員コード = strW従業員コード & "8"
                        Case "ﾜ", "ｦ", "ﾝ"
                            strW従業員コード = strW従業員コード & "9"
                        Case Else
                            gfncNumberHandle = True
                            If pblnFlgMsg Then
                                'ｴﾗｰﾒｯｾｰｼﾞを表示します
                                MsgBox("先頭に採番出来ない文字が入力されています。", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                            End If
                            If pblnFlgPointer Then
                                '砂時計ﾎﾟｲﾝﾀを解除します。
                                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            End If
                            Exit Function
                    End Select

                    '入力ｶﾅの先頭文字でﾜｰｸの４桁目を決定
                    Select Case Mid(pstrKana, 1, 1)
                        Case "ｱ", "ｧ", "ｶ", "ｻ", "ﾀ", "ﾅ", "ﾊ", "ﾏ", "ﾔ", "ｬ", "ﾗ", "ﾜ"
                            strW従業員コード = strW従業員コード & "0"
                        Case "ｲ", "ｨ", "ｷ", "ｼ", "ﾁ", "ﾆ", "ﾋ", "ﾐ", "ﾕ", "ｭ", "ﾘ", "ｦ"
                            strW従業員コード = strW従業員コード & "2"
                        Case "ｳ", "ｩ", "ｸ", "ｽ", "ﾂ", "ｯ", "ﾇ", "ﾌ", "ﾑ", "ﾖ", "ｮ", "ﾙ", "ﾝ"
                            strW従業員コード = strW従業員コード & "4"
                        Case "ｴ", "ｪ", "ｹ", "ｾ", "ﾃ", "ﾈ", "ﾍ", "ﾒ", "ﾚ"
                            strW従業員コード = strW従業員コード & "6"
                        Case "ｵ", "ｫ", "ｺ", "ｿ", "ﾄ", "ﾉ", "ﾎ", "ﾓ", "ﾛ"
                            strW従業員コード = strW従業員コード & "8"
                        Case Else
                            gfncNumberHandle = True
                            If pblnFlgMsg Then
                                'ｴﾗｰﾒｯｾｰｼﾞを表示します
                                MsgBox("先頭に採番出来ない文字が入力されています。", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                            End If
                            If pblnFlgPointer Then
                                '砂時計ﾎﾟｲﾝﾀを解除します。
                                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            End If
                            Exit Function
                    End Select

                    'ﾜｰｸの３桁目で２回の採番を行う(ﾙｰﾌﾟ①)
                    For intIndx = 1 To 2
                        'ﾜｰｸの初期設定
                        pstrEmployeeCD = ""
                        str退避コード = ""

                        '「従業員マスタ」と「従業員異動テーブル」から採番コードで使用済情報を取得(先頭4桁で取得)
                        strSQL = "SELECT SUBSTR(従業員コード,5,3) 使用済コード"
                        strSQL = strSQL & " FROM 従業員マスタ"
                        strSQL = strSQL & " WHERE SUBSTR(従業員コード,1,4) = '" & strW従業員コード & "'"

                        strSQL = strSQL & "UNION "

                        strSQL = strSQL & "SELECT SUBSTR(新従業員コード,5,3) 使用済コード"
                        strSQL = strSQL & " FROM 従業員異動テーブル"
                        strSQL = strSQL & " WHERE SUBSTR(新従業員コード,1,4) = '" & strW従業員コード & "'"
                        strSQL = strSQL & "   AND SUBSTR(新従業員コード,5,3) >= '001'"
                        strSQL = strSQL & "   AND SUBSTR(新従業員コード,5,3) <= '999'"
                        strSQL = strSQL & "   AND 異動種別 = 4"
                        strSQL = strSQL & "   AND 取消サイン = 0"

                        strSQL = strSQL & " ORDER BY 使用済コード"
                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        objDysJ = gobjOraDatabase.CreateDynaset(strSQL, &H1)

                        '入力されたｷｰｺｰﾄﾞが有るかどうか判定
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If objDysJ.EOF Then
                            '"001"を設定
                            pstrEmployeeCD = strW従業員コード & "001"

                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            objDysJ.Close()
                            'ﾙｰﾌﾟ①を抜ける
                            Exit For
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysJ.Fields(使用済コード).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ElseIf "001" < gfncFieldVal(objDysJ.Fields("使用済コード").Value) Then
                            '"001"を設定
                            pstrEmployeeCD = strW従業員コード & "001"

                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            objDysJ.Close()
                            'ﾙｰﾌﾟ①を抜ける
                            Exit For

                        Else
                            'ﾙｰﾌﾟ②開始
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Do Until objDysJ.EOF
                                '退避ｺｰﾄﾞをﾜｰｸに退避
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                str退避コード = gfncFieldVal(objDysJ.Fields("使用済コード").Value)

                                '次のﾚｺｰﾄﾞをREAD
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysJ.MoveNext()
                                'ﾃﾞｰﾀが無い場合
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                If objDysJ.EOF Then
                                    If str退避コード = "999" Then
                                        'ﾙｰﾌﾟ②を抜ける
                                        Exit Do
                                    Else
                                        pstrEmployeeCD = strW従業員コード & VB6.Format(CInt(str退避コード) + 1, "000")
                                        'ﾙｰﾌﾟ②を抜ける
                                        Exit Do
                                    End If
                                Else
                                    '(使用済 - 退避コード) >= 2(ｺｰﾄﾞ間に空きがある) なら 退避コード + 1 を設定
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    If (gfncFieldCur(objDysJ.Fields("使用済コード").Value) - CInt(str退避コード)) >= 2 Then
                                        pstrEmployeeCD = strW従業員コード & VB6.Format(CInt(str退避コード) + 1, "000")
                                        'ﾙｰﾌﾟ②を抜ける
                                        Exit Do
                                    End If
                                End If
                            Loop

                            '採番された場合は処理を抜ける。
                            If pstrEmployeeCD = "" Then
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysM.MoveNext()
                            Else
                                'ﾙｰﾌﾟ①を抜ける
                                Exit For
                            End If
                        End If

                        'ﾜｰｸをｶｳﾝﾄｱｯﾌﾟ（２回目の採番の為）
                        strW従業員コード = CStr(CDbl(strW従業員コード) + 1)
                    Next intIndx
            End Select

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b08e273c-96f6-470f-9fb3-c89c38430582
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b08e273c-96f6-470f-9fb3-c89c38430582
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            gfncNumberHandle = True

            If pblnFlgMsg Then
                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f29a0e70-3beb-49d9-898e-3df428644792
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f29a0e70-3beb-49d9-898e-3df428644792
            'Resume 
            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f29a0e70-3beb-49d9-898e-3df428644792
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:f29a0e70-3beb-49d9-898e-3df428644792
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
