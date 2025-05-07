Option Strict Off
Option Explicit On
Module basControlHandle
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : ControlHandle.bas
    ' 内    容    : コントロール 使用可否 制御
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncGetLowRank          (最下位ランク 取得)
    '                   gfncSetAuthorityData    (権限情報 設定)
    '                   gsubControlHandle       (コントロール 使用可否 制御)
    '               <Private>
    '
    ' 変更履歴    :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    '----------------------------------
    ' 制御モード
    '----------------------------------
    Public Const GC_CONTROL_MODE_MENU As Short = 0
    Public Const GC_CONTROL_MODE_BUTTON As Short = 1

    '==============================================================================
    ' 構造体
    '==============================================================================
    '----------------------------------
    Private Structure TAG_Authority ' 権限退避ワーク
        '----------------------------------
        Dim mTstrPID As String
        Dim mTstrF01 As String
        Dim mTstrF02 As String
        Dim mTstrF03 As String
        Dim mTstrF04 As String
        Dim mTstrF05 As String
        Dim mTstrF06 As String
        Dim mTstrF07 As String
        Dim mTstrF08 As String
        Dim mTstrF09 As String
        Dim mTstrF10 As String
        Dim mTstrF11 As String
        Dim mTstrF12 As String
        Dim mTstrMNU As String
    End Structure

    '==============================================================================
    ' 変数
    '==============================================================================
    Private mtblAuthorityInfo() As TAG_Authority
    '******************************************************************************
    ' 関 数 名  : gfncGetLowRank
    ' スコープ  : Public
    ' 処理内容  : 最下位ランク 取得
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjDB              Object            O     データベース
    '   pstrRank            String            O     ランク
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncGetLowRank(ByRef pobjDB As Object, ByRef pstrRank As String) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetLowRank"
        Dim strSQL As String
        Dim objDys権限設定テーブル As Object
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncGetLowRank"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDys権限設定テーブル As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（異常終了)
            gfncGetLowRank = True

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    MAX(ランク) R "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    権限設定テーブル "

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys権限設定テーブル = pobjDB.CreateDynaset(strSQL, &H4)

            With objDys権限設定テーブル

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' 戻り値を設定（正常終了)
                    gfncGetLowRank = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pstrRank = gfncFieldVal(.Fields("R").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End If

            End With

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e220fc5b-af03-4f93-8443-66a8219e3950
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:e220fc5b-af03-4f93-8443-66a8219e3950
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:05eed43f-a129-4098-8477-eff69af0bf68
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:05eed43f-a129-4098-8477-eff69af0bf68

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:05eed43f-a129-4098-8477-eff69af0bf68
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:05eed43f-a129-4098-8477-eff69af0bf68
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gfncSetAuthorityData
    ' スコープ  : Public
    ' 処理内容  : 権限情報 設定
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjDB              Object            O     データベース
    '   pstrRank            String            O     ランク
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Function gfncSetAuthorityData(ByRef pobjDB As Object, ByRef pstrRank As String) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncSetAuthorityData"
        Dim intIdx As Short
        Dim strSQL As String
        Dim objDys権限設定テーブル As Object
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncSetAuthorityData"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intIdx As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objDys権限設定テーブル As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            ' 戻り値を初期化（異常終了)
            gfncSetAuthorityData = True

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    * "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    権限設定テーブル "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    ランク = '" & pstrRank & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys権限設定テーブル = pobjDB.CreateDynaset(strSQL, &H4)

            With objDys権限設定テーブル

                ' 該当データが見つからなかった場合
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                    Exit Function

                End If

                ' 件数を設定
                'UPGRADE_WARNING: Lower bound of array mtblAuthorityInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReDim mtblAuthorityInfo(.RecordCount)

                '権限ﾜｰｸに値を設定
                For intIdx = 1 To UBound(mtblAuthorityInfo)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrPID = gfncFieldVal(.Fields("プログラムＩＤ").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF01 = gfncFieldVal(.Fields("Ｆ０１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF02 = gfncFieldVal(.Fields("Ｆ０２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF03 = gfncFieldVal(.Fields("Ｆ０３").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF04 = gfncFieldVal(.Fields("Ｆ０４").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF05 = gfncFieldVal(.Fields("Ｆ０５").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF06 = gfncFieldVal(.Fields("Ｆ０６").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF07 = gfncFieldVal(.Fields("Ｆ０７").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF08 = gfncFieldVal(.Fields("Ｆ０８").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF09 = gfncFieldVal(.Fields("Ｆ０９").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF10 = gfncFieldVal(.Fields("Ｆ１０").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF11 = gfncFieldVal(.Fields("Ｆ１１").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF12 = gfncFieldVal(.Fields("Ｆ１２").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrMNU = gfncFieldVal(.Fields("メニュー").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Next intIdx

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys権限設定テーブル.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            ' 戻り値を設定（正常終了)
            gfncSetAuthorityData = False

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:05eed43f-a129-4098-8477-eff69af0bf68
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:05eed43f-a129-4098-8477-eff69af0bf68
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
    '******************************************************************************
    ' 関 数 名  : gsubControlHandle
    ' スコープ  : Public
    ' 処理内容  : コントロール制御
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pForm               Form              I/O   制御対象画面
    '   pintMode            Integer           I     制御モード
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  廣井  芳明         新規作成
    '
    '******************************************************************************
    Public Sub gsubControlHandle(ByRef pForm As System.Windows.Forms.Form, ByVal pintMode As Short)

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gsubControlHandle"
        Dim Ctl As System.Windows.Forms.Control
        Dim intIdx As Short
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gsubControlHandle"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim Ctl As System.Windows.Forms.Control
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim intIdx As Short
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            Select Case pintMode
            '--------------------------------------------------------------------------
            ' メニュー制御
            '--------------------------------------------------------------------------
                Case GC_CONTROL_MODE_MENU

                    For intIdx = LBound(mtblAuthorityInfo) To UBound(mtblAuthorityInfo)

                        For Each Ctl In pForm.Controls

                            If Trim(Mid(Ctl.Name, 4, 10)) = Trim(mtblAuthorityInfo(intIdx).mTstrPID) Then

                                If mtblAuthorityInfo(intIdx).mTstrMNU = "可" Then

                                    Ctl.Visible = True

                                Else

                                    Ctl.Visible = False

                                End If

                            End If

                        Next Ctl

                    Next intIdx

                '--------------------------------------------------------------------------
                ' ボタン制御
                '--------------------------------------------------------------------------
                Case GC_CONTROL_MODE_BUTTON

                    For intIdx = LBound(mtblAuthorityInfo) To UBound(mtblAuthorityInfo)

                        If pForm.Name = Trim(mtblAuthorityInfo(intIdx).mTstrPID) Then

                            '--------------------------------------------------------------
                            'Ｆ０１
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF01 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF01 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF01.Visible = True
                                pForm.Controls.Item("cmdF01").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF01 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF01 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF01.Visible = False
                                pForm.Controls.Item("cmdF01").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換

                            End If
                            '--------------------------------------------------------------
                            'Ｆ０２
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF02 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF02 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF02.Visible = True
                                pForm.Controls.Item("cmdF02").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF02 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF02 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF02.Visible = False
                                pForm.Controls.Item("cmdF02").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０３
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF03 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF03 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF03.Visible = True
                                pForm.Controls.Item("cmdF03").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF03 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF03 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF03.Visible = False
                                pForm.Controls.Item("cmdF03").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０４
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF04 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF04 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF04.Visible = True
                                pForm.Controls.Item("cmdF04").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF04 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF04 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF04.Visible = False
                                pForm.Controls.Item("cmdF04").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０５
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF05 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF05 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF05.Visible = True
                                pForm.Controls.Item("cmdF05").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF05 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF05 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF05.Visible = False
                                pForm.Controls.Item("cmdF05").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０６
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF06 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF06 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF06.Visible = True
                                pForm.Controls.Item("cmdF06").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF06 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF06 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF06.Visible = cmdF06
                                pForm.Controls.Item("cmdF06").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０７
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF07 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF07 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF07.Visible = True
                                pForm.Controls.Item("cmdF07").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF07 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF07 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF07.Visible = cmdF06
                                pForm.Controls.Item("cmdF07").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０８
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF08 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF08 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF08.Visible = True
                                pForm.Controls.Item("cmdF08").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF08 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF08 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF08.Visible = cmdF06
                                pForm.Controls.Item("cmdF08").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ０９
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF09 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF09 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF09.Visible = True
                                pForm.Controls.Item("cmdF09").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF09 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF09 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF09.Visible = False
                                pForm.Controls.Item("cmdF09").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ１０
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF10 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF10 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF10.Visible = True
                                pForm.Controls.Item("cmdF10").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF10 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF10 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF10.Visible = False
                                pForm.Controls.Item("cmdF10").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ１１
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF11 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF11 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF11.Visible = True
                                pForm.Controls.Item("cmdF11").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF11 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF11 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF11.Visible = False
                                pForm.Controls.Item("cmdF11").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If
                            '--------------------------------------------------------------
                            'Ｆ１２
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF12 = "可" Then
                                'UPGRADE_ISSUE: Control cmdF12 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF12.Visible = True
                                pForm.Controls.Item("cmdF12").Visible = True
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF12 = "不可" Then
                                'UPGRADE_ISSUE: Control cmdF129 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++修正開始　2021年04月01:Onetech（手）- VB→VB.NET変換
                                'pForm.cmdF12.Visible = False
                                pForm.Controls.Item("cmdF12").Visible = False
                                '--修正終了　2021年04月01:Onetech（手）- VB→VB.NET変換
                            End If

                        End If

                    Next intIdx

            End Select

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
            'PROC_END:

            'Exit Sub

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8e4a0983-8acf-48ff-877f-2b91f7e110da
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8e4a0983-8acf-48ff-877f-2b91f7e110da

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8e4a0983-8acf-48ff-877f-2b91f7e110da
PROC_FINALLY_END:
        Exit Sub
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:8e4a0983-8acf-48ff-877f-2b91f7e110da
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Sub
End Module
