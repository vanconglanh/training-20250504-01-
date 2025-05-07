Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basJyugyoBelongHandle
    '******************************************************************************
    ' ﾌﾟﾛｼﾞｪｸﾄ名  : ＭＫシステム共通
    ' ファイル名  : JyugyoBelongHandle.bas
    ' 内    容    : 従業員の付属マスタ(家族・顔写真・実務資格・免許)を更新する モジュール
    ' 備    考    :
    ' 関数一覧    : <Public>
    '                   gfncJyugyoBelongHandle             (従業員の付属マスタの更新)
    '               <Private>
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/06  KSR                新規作成
    '
    '******************************************************************************
    '==============================================================================
    ' 定数
    '==============================================================================
    ' 拡張子
    Private Const MC_TEMP_FILE As String = ".JPG"
    Private Const MC_TEMP_BUFF_SIZE As Integer = 10240 ' バッファサイズ

    '==============================================================================
    ' 変数
    '==============================================================================
    Private mstrTempPath As String ' テンポラリファイルへのパス


    '******************************************************************************
    ' 関 数 名  : gfncJyugyoBelongHandle
    ' スコープ  : Public
    ' 処理内容  : 従業員の付属マスタの更新
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrNewEmployeeCD   String            I     新従業員コード
    '   pstrOldEmployeeCD   String            I     旧従業員コード
    '   pstrEmployeeCD      String            I/O   更新従業員コード
    '   pstrProgramID       String            I/O   更新プログラム
    '   pblnFlgMsg          Boolean           I     メッセージ出力有無
    '                                                 True  : メッセージ出力有
    '                                                 False : メッセージ出力無
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/06  KSR                新規作成
    '   01.02       2023/06/26  TSS                従業員家族マスタに収入項目追加
    '
    '******************************************************************************
    Public Function gfncJyugyoBelongHandle(ByRef pstrNewEmployeeCD As String, ByRef pstrOldEmployeeCD As String, ByRef pstrEmployeeCD As String, ByVal pstrProgramID As String, Optional ByVal pblnFlgMsg As Boolean = True) As Boolean

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        Dim lngReadPosi As Integer ' 読込み位置
        Dim intFileNum As Short ' ファイル番号
        Dim dblReadSize As Double ' 読込んだデータサイズ
        Dim abytReadBuff() As Byte ' 読込みバッファ
        Dim lngTotalSize As Integer ' データのサイズ
        Dim intWritePosi As Short ' ループカウンタ
        Dim intNumChunks As Short '
        Dim abytWriteBuff() As Byte ' 書込みバッファ
        Dim dblWriteSize As Double ' 書込むデータサイズ
        Dim pstrSearchItem() As String
        Dim pstrSearchKey() As String
        Dim str顔写真 As String
        Dim str写真撮影日 As String
        Dim clsSysDate As clsSystemDate
        Dim objFso As Scripting.FileSystemObject
        Const C_NAME_FUNCTION As String = "gfncJyugyoBelongHandle"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換


            '戻り値初期化
            gfncJyugyoBelongHandle = False


            '--------------------------------------------------------------------------
            ' メンバ変数 設定
            '--------------------------------------------------------------------------
            ' システムのテンプレートフォルダが見つからない場合
            If gfncGetSHFolderPath(CSIDL_TEMPLATES, mstrTempPath) <> S_OK Then

                mstrTempPath = "C:\Temp\"

                ' ディレクトリが存在しない場合
                If gfncCheckFileExists(mstrTempPath) = False Then

                    ' テンプレートフォルダを作成
                    objFso = New Scripting.FileSystemObject

                    Call objFso.CreateFolder(mstrTempPath)

                End If

            Else

                mstrTempPath = mstrTempPath & "\"

            End If


            ' 登録確認（従業員家族マスタ）
            ReDim pstrSearchItem(0) : pstrSearchItem(0) = "従業員コード"
            ReDim pstrSearchKey(0) : pstrSearchKey(0) = pstrOldEmployeeCD
            If gfncGetTableHandle("従業員家族マスタ", pstrSearchItem, pstrSearchKey, objDysTemp, True) = True Then
                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
            End If

            ' 従業員家族マスタを更新
            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO "
                strSQL = strSQL & Chr(10) & "    従業員家族マスタ "
                strSQL = strSQL & Chr(10) & "  ( "
                strSQL = strSQL & Chr(10) & "    従業員コード "
                strSQL = strSQL & Chr(10) & "  , 枝番 "
                strSQL = strSQL & Chr(10) & "  , 続柄 "
                strSQL = strSQL & Chr(10) & "  , 家族名漢字 "
                strSQL = strSQL & Chr(10) & "  , 家族名カナ "
                strSQL = strSQL & Chr(10) & "  , 性別 "
                strSQL = strSQL & Chr(10) & "  , 血液型 "
                strSQL = strSQL & Chr(10) & "  , 生年月日 "
                strSQL = strSQL & Chr(10) & "  , 婚姻届日 "
                strSQL = strSQL & Chr(10) & "  , 給与扶養区分 "
                strSQL = strSQL & Chr(10) & "  , 社保扶養区分 "
                strSQL = strSQL & Chr(10) & "  , 社会保険認定日 "
                strSQL = strSQL & Chr(10) & "  , 社会保険喪失日 "
                strSQL = strSQL & Chr(10) & "  , 同居区分 "
                strSQL = strSQL & Chr(10) & "  , 郵便番号１ "
                strSQL = strSQL & Chr(10) & "  , 郵便番号２ "
                strSQL = strSQL & Chr(10) & "  , 都道府県 "
                strSQL = strSQL & Chr(10) & "  , 市区郡 "
                strSQL = strSQL & Chr(10) & "  , 町村番地 "
                strSQL = strSQL & Chr(10) & "  , 号棟 "
                strSQL = strSQL & Chr(10) & "  , 更新従業員コード "
                strSQL = strSQL & Chr(10) & "  , 更新日付時刻 "

                '2023/06/26 ADD_Start
                strSQL = strSQL & Chr(10) & "  , 収入 "
                '2023/06/26 ADD_End

                strSQL = strSQL & Chr(10) & "  ) "
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    '" & pstrNewEmployeeCD & "' " '新従業員コード
                strSQL = strSQL & Chr(10) & "  , 枝番 "
                strSQL = strSQL & Chr(10) & "  , 続柄 "
                strSQL = strSQL & Chr(10) & "  , 家族名漢字 "
                strSQL = strSQL & Chr(10) & "  , 家族名カナ "
                strSQL = strSQL & Chr(10) & "  , 性別 "
                strSQL = strSQL & Chr(10) & "  , 血液型 "
                strSQL = strSQL & Chr(10) & "  , 生年月日 "
                strSQL = strSQL & Chr(10) & "  , 婚姻届日 "
                strSQL = strSQL & Chr(10) & "  , 給与扶養区分 "
                strSQL = strSQL & Chr(10) & "  , 社保扶養区分 "
                strSQL = strSQL & Chr(10) & "  , 社会保険認定日 "
                strSQL = strSQL & Chr(10) & "  , 社会保険喪失日 "
                strSQL = strSQL & Chr(10) & "  , 同居区分 "
                strSQL = strSQL & Chr(10) & "  , 郵便番号１ "
                strSQL = strSQL & Chr(10) & "  , 郵便番号２ "
                strSQL = strSQL & Chr(10) & "  , 都道府県 "
                strSQL = strSQL & Chr(10) & "  , 市区郡 "
                strSQL = strSQL & Chr(10) & "  , 町村番地 "
                strSQL = strSQL & Chr(10) & "  , 号棟 "
                strSQL = strSQL & Chr(10) & "  , '" & pstrEmployeeCD & "' " '更新従業員コード
                strSQL = strSQL & Chr(10) & "  , SYSDATE " '更新日付時刻

                '2023/06/26 ADD_Start
                strSQL = strSQL & Chr(10) & "  , 収入 "
                '2023/06/26 ADD_End

                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    従業員家族マスタ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrOldEmployeeCD & "' " '旧従業員コード

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp.Close()
            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing

            ' 従業員顔写真マスタを更新
            '''    strSQL = ""
            '''    strSQL = strSQL & Chr(10) & "INSERT INTO "
            '''    strSQL = strSQL & Chr(10) & "    従業員顔写真マスタ "
            '''    strSQL = strSQL & Chr(10) & "  ( "
            '''    strSQL = strSQL & Chr(10) & "    従業員コード "
            '''    strSQL = strSQL & Chr(10) & "  , 顔写真 "
            '''    strSQL = strSQL & Chr(10) & "  , 写真撮影日 "
            '''    strSQL = strSQL & Chr(10) & "  , 更新従業員コード "
            '''    strSQL = strSQL & Chr(10) & "  , 更新日付時刻 "
            '''    strSQL = strSQL & Chr(10) & "  ) "
            '''    strSQL = strSQL & Chr(10) & "SELECT "
            '''    strSQL = strSQL & Chr(10) & "     '" & pstrNewEmployeeCD & "' "                                                   '新従業員コード
            '''    strSQL = strSQL & Chr(10) & "   , 写真撮影日 "
            '''    strSQL = strSQL & Chr(10) & "   , '" & pstrEmployeeCD & "' "                                                      '更新従業員コード
            '''    strSQL = strSQL & Chr(10) & "   , SYSDATE "                                                      '更新日付時刻
            '''    strSQL = strSQL & Chr(10) & "FROM "
            '''    strSQL = strSQL & Chr(10) & "    従業員顔写真マスタ "
            '''    strSQL = strSQL & Chr(10) & "WHERE "
            '''    strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrOldEmployeeCD & "' "                                   '旧従業員コード
            '''
            '''    Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    従業員コード "
            strSQL = strSQL & Chr(10) & "  , 顔写真 "
            strSQL = strSQL & Chr(10) & "  , 写真撮影日 "
            strSQL = strSQL & Chr(10) & "  , 更新従業員コード "
            strSQL = strSQL & Chr(10) & "  , 更新日付時刻 "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    従業員顔写真マスタ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrOldEmployeeCD & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H1)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    str写真撮影日 = gfncFieldVal(.Fields("写真撮影日").Value)


                    ' 顔写真データのサイズが0バイトの時
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .Fields("顔写真").FieldSize <> 0 Then

                        '--------------------------------------------------------------
                        ' 顔写真 取得
                        '--------------------------------------------------------------
                        ' 読込みバッファを再定義
                        ReDim abytReadBuff(MC_TEMP_BUFF_SIZE - 1)

                        ' ファイル番号を取得
                        intFileNum = FreeFile()

                        ' ファイルを開く
                        FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)

                        ' 読込み位置を初期化
                        lngReadPosi = 0

                        Do

                            ' 顔写真データを取得
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                            'dblReadSize = .Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                            dblReadSize = .Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                            '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換

                            ' 読込んだデータサイズが0の時
                            If dblReadSize = 0 Then

                                ' ループを抜ける
                                Exit Do

                            End If

                            ' 実際の読込みサイズと，格納バッファのサイズが異なる時
                            If dblReadSize < MC_TEMP_BUFF_SIZE Then

                                ' 実際の読込みサイズに，読込みバッファを再定義
                                ReDim abytReadBuff(dblReadSize - 1)

                                ' 再び 顔写真データの取得
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                                'dblReadSize = .Fields("顔写真").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                                dblReadSize = .Fields("顔写真").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                                '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                            End If

                            ' テンポラリファイルに出力
                            'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                            FilePut(intFileNum, abytReadBuff)

                            ' 顔写真データの読込み位置を更新
                            lngReadPosi = lngReadPosi + 1

                        Loop Until dblReadSize < MC_TEMP_BUFF_SIZE

                        ' ファイルを閉じる
                        FileClose(intFileNum)


                        '** 更新
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .AddNew()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("従業員コード").Value = pstrNewEmployeeCD
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("写真撮影日").Value = str写真撮影日
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("更新従業員コード").Value = gclsLoginInfo.EmployeeCode

                        clsSysDate = New clsSystemDate
                        Call clsSysDate.DBObjectSet(gobjOraDatabase)
                        Call clsSysDate.GetSystemDate()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("更新日付時刻").Value = clsSysDate.SystemDateFormat("yyyy/mm/dd hh:mm:ss")

                        'UPGRADE_NOTE: Object clsSysDate may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                        clsSysDate = Nothing


                        '------------------------------------------------------------------
                        ' 顔写真データ 登録
                        '------------------------------------------------------------------
                        ' ファイル番号を取得
                        intFileNum = FreeFile()

                        ' ファイルを開く
                        FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)

                        ' 開いたファイルサイズを取得
                        lngTotalSize = LOF(intFileNum)

                        ' 余りを読込む時のインデックスを取得
                        intNumChunks = lngTotalSize \ MC_TEMP_BUFF_SIZE

                        ' 余りを読込むところまでループ
                        For intWritePosi = 0 To intNumChunks

                            ' 余りのデータを読込む時
                            If intWritePosi = intNumChunks Then

                                ' 余りのデータサイズを書込みサイズに設定
                                dblWriteSize = lngTotalSize Mod MC_TEMP_BUFF_SIZE

                            Else

                                ' バッファサイズを書込みサイズに設定
                                dblWriteSize = MC_TEMP_BUFF_SIZE

                            End If

                            ' 書込みサイズが0の時
                            ' (書込みサイズで割り切れるファイルサイズの時)
                            If dblWriteSize = 0 Then

                                Exit For

                            End If

                            ' 配列を書込みサイズに再定義
                            ' (0オリジンのため - 1)
                            ReDim abytWriteBuff(dblWriteSize - 1)

                            ' ファイルからデータを読込み
                            'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                            FileGet(intFileNum, abytWriteBuff)

                            ' バイト配列のデータをコピー・バッファのLONG RAW型フィールドに追加
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年06月18日:MK（手）- VB→VB.NET変換
                            'Call .Fields("顔写真").AppendChunkByte(abytWriteBuff(0), dblWriteSize)
                            Call .Fields("顔写真").AppendChunkByte(abytWriteBuff, dblWriteSize)
                            '--修正開始　2021年06月18日:MK（手）- VB→VB.NET変換

                        Next intWritePosi

                        ' ファイルを閉じる
                        FileClose(intFileNum)

                        objFso = New Scripting.FileSystemObject

                        ' ファイルを削除する
                        Call objFso.DeleteFile(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Update()

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .Close()
                'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                objDysTemp = Nothing

            End With


            ' 登録確認（従業員実務資格テーブル）
            ReDim pstrSearchItem(0) : pstrSearchItem(0) = "従業員コード"
            ReDim pstrSearchKey(0) : pstrSearchKey(0) = pstrOldEmployeeCD
            If gfncGetTableHandle("従業員実務資格テーブル", pstrSearchItem, pstrSearchKey, objDysTemp, True) = True Then
                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
            End If

            ' 従業員実務資格テーブルを更新
            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO "
                strSQL = strSQL & Chr(10) & "    従業員実務資格テーブル "
                strSQL = strSQL & Chr(10) & "  ( "
                strSQL = strSQL & Chr(10) & "    従業員コード "
                strSQL = strSQL & Chr(10) & "  , 枝番 "
                strSQL = strSQL & Chr(10) & "  , 実務資格コード "
                strSQL = strSQL & Chr(10) & "  , 実務資格ランク "
                strSQL = strSQL & Chr(10) & "  , 取得年月 "
                strSQL = strSQL & Chr(10) & "  , 喪失年月 "
                strSQL = strSQL & Chr(10) & "  , 更新従業員コード "
                strSQL = strSQL & Chr(10) & "  , 更新日付時刻 "
                strSQL = strSQL & Chr(10) & "  , 更新プログラム "
                strSQL = strSQL & Chr(10) & "  , 備考 "
                strSQL = strSQL & Chr(10) & "  ) "
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    '" & pstrNewEmployeeCD & "' " '新従業員コード
                strSQL = strSQL & Chr(10) & "  , 枝番 "
                strSQL = strSQL & Chr(10) & "  , 実務資格コード "
                strSQL = strSQL & Chr(10) & "  , 実務資格ランク "
                strSQL = strSQL & Chr(10) & "  , 取得年月 "
                strSQL = strSQL & Chr(10) & "  , 喪失年月 "
                strSQL = strSQL & Chr(10) & "  , '" & pstrEmployeeCD & "' " '更新従業員コード
                strSQL = strSQL & Chr(10) & "  , SYSDATE " '更新日付時刻
                strSQL = strSQL & Chr(10) & "  , '" & pstrProgramID & "' " '更新プログラム
                strSQL = strSQL & Chr(10) & "  , 備考 "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    従業員実務資格テーブル "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrOldEmployeeCD & "' " '旧従業員コード

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp.Close()
            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing


            ' 登録確認（免許証履歴テーブル）
            ReDim pstrSearchItem(0) : pstrSearchItem(0) = "従業員コード"
            ReDim pstrSearchKey(0) : pstrSearchKey(0) = pstrOldEmployeeCD
            If gfncGetTableHandle("免許証履歴テーブル", pstrSearchItem, pstrSearchKey, objDysTemp, True) = True Then
                '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
            End If

            ' 免許証履歴テーブルを更新
            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO "
                strSQL = strSQL & Chr(10) & "    免許証履歴テーブル "
                strSQL = strSQL & Chr(10) & "  ( "
                strSQL = strSQL & Chr(10) & "    従業員コード "
                strSQL = strSQL & Chr(10) & "  , 枝番 "
                strSQL = strSQL & Chr(10) & "  , 免許証番号 "
                strSQL = strSQL & Chr(10) & "  , 交付日"
                strSQL = strSQL & Chr(10) & "  , 生年月日 "
                strSQL = strSQL & Chr(10) & "  , 有効期限 "
                strSQL = strSQL & Chr(10) & "  , 氏名漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍都道府県漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍市区郡漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍町村番地漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍号棟漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所都道府県漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所市区郡漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所町村番地漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所号棟漢字 "
                strSQL = strSQL & Chr(10) & "  , 免許年月日 "
                strSQL = strSQL & Chr(10) & "  , 免許年月日一種 "
                strSQL = strSQL & Chr(10) & "  , 免許年月日二種 "
                strSQL = strSQL & Chr(10) & "  , 二種合格日"
                strSQL = strSQL & Chr(10) & "  , 大型 "
                strSQL = strSQL & Chr(10) & "  , 普通 "
                strSQL = strSQL & Chr(10) & "  , 大特 "
                strSQL = strSQL & Chr(10) & "  , 自二 "
                strSQL = strSQL & Chr(10) & "  , 小 "
                strSQL = strSQL & Chr(10) & "  , 原付 "
                strSQL = strSQL & Chr(10) & "  , けん引 "
                strSQL = strSQL & Chr(10) & "  , 大型二 "
                strSQL = strSQL & Chr(10) & "  , 普通二 "
                strSQL = strSQL & Chr(10) & "  , 大特二 "
                strSQL = strSQL & Chr(10) & "  , けん引二 "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等 "
                strSQL = strSQL & Chr(10) & "  , 更新従業員コード "
                strSQL = strSQL & Chr(10) & "  , 更新日付時刻 "
                strSQL = strSQL & Chr(10) & "  , 有効期限年月日 "
                strSQL = strSQL & Chr(10) & "  , 中型"
                strSQL = strSQL & Chr(10) & "  , 中型二 "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等２ "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等３ "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等４ "
                strSQL = strSQL & Chr(10) & "  ) "
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    '" & pstrNewEmployeeCD & "' " '新従業員コード
                strSQL = strSQL & Chr(10) & "  , 枝番 "
                strSQL = strSQL & Chr(10) & "  , 免許証番号 "
                strSQL = strSQL & Chr(10) & "  , 交付日"
                strSQL = strSQL & Chr(10) & "  , 生年月日 "
                strSQL = strSQL & Chr(10) & "  , 有効期限 "
                strSQL = strSQL & Chr(10) & "  , 氏名漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍都道府県漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍市区郡漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍町村番地漢字 "
                strSQL = strSQL & Chr(10) & "  , 本籍号棟漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所都道府県漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所市区郡漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所町村番地漢字 "
                strSQL = strSQL & Chr(10) & "  , 住所号棟漢字 "
                strSQL = strSQL & Chr(10) & "  , 免許年月日 "
                strSQL = strSQL & Chr(10) & "  , 免許年月日一種 "
                strSQL = strSQL & Chr(10) & "  , 免許年月日二種 "
                strSQL = strSQL & Chr(10) & "  , 二種合格日"
                strSQL = strSQL & Chr(10) & "  , 大型 "
                strSQL = strSQL & Chr(10) & "  , 普通 "
                strSQL = strSQL & Chr(10) & "  , 大特 "
                strSQL = strSQL & Chr(10) & "  , 自二 "
                strSQL = strSQL & Chr(10) & "  , 小 "
                strSQL = strSQL & Chr(10) & "  , 原付 "
                strSQL = strSQL & Chr(10) & "  , けん引 "
                strSQL = strSQL & Chr(10) & "  , 大型二 "
                strSQL = strSQL & Chr(10) & "  , 普通二 "
                strSQL = strSQL & Chr(10) & "  , 大特二 "
                strSQL = strSQL & Chr(10) & "  , けん引二 "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等 "
                strSQL = strSQL & Chr(10) & "  , '" & pstrEmployeeCD & "' " '更新従業員コード
                strSQL = strSQL & Chr(10) & "  , SYSDATE " '更新日付時刻
                strSQL = strSQL & Chr(10) & "  , 有効期限年月日 "
                strSQL = strSQL & Chr(10) & "  , 中型"
                strSQL = strSQL & Chr(10) & "  , 中型二 "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等２ "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等３ "
                strSQL = strSQL & Chr(10) & "  , 免許の条件等４ "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    免許証履歴テーブル "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    従業員コード = '" & pstrOldEmployeeCD & "' " '旧従業員コード

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp.Close()
            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing


            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
            'PROC_END:

            'Call gsubClearObject(objFso)

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:c3cea73f-307c-438c-8250-3587661d3764
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            gfncJyugyoBelongHandle = True

            If pblnFlgMsg Then
                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:a79e565b-fe85-4319-9587-98c64152e4d6
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:a79e565b-fe85-4319-9587-98c64152e4d6
            'Resume 
            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:a79e565b-fe85-4319-9587-98c64152e4d6
PROC_FINALLY_END:
        Call gsubClearObject(objFso)
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:a79e565b-fe85-4319-9587-98c64152e4d6
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function



    '******************************************************************************
    ' 関 数 名  : gfncGetTableHandle
    ' スコープ  : Public
    ' 処理内容  : テーブル情報取得
    ' 備    考  :
    ' 返 り 値  : True （異常終了）
    '             False（正常終了）
    ' 引 き 数  :
    '   ﾊﾟﾗﾒｰﾀ名            ﾃﾞｰﾀﾀｲﾌﾟ          I/O   説 明
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrSearchTable     String            I     テーブル名
    '   pstrSearchItem      String            I/O   条件項目
    '   pstrSearchKey       String            I/O   条件
    '   pobjDysTemp         String            I/O   オブジェクト
    '   pblnFlgMsg          Boolean           I     メッセージ出力有無
    '                                                 True  : メッセージ出力有
    '                                                 False : メッセージ出力無
    '
    ' 変更履歴  :
    '   Version     日  付      氏  名             修正内容
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/09  KSR                新規作成
    '
    '******************************************************************************
    '++修正開始　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換
    'Public Function gfncGetTableHandle(ByVal pstrSearchTable As String, ByRef pstrSearchItem() As String, ByRef pstrSearchKey() As String, ByRef pobjDysTemp As Object, Optional ByVal pblnFlgMsg As Boolean = True) As Boolean
    Public Function gfncGetTableHandle(ByVal pstrSearchTable As String, ByRef pstrSearchItem() As String, ByRef pstrSearchKey() As String, ByRef pobjDysTemp As OraDynaset, Optional ByVal pblnFlgMsg As Boolean = True) As Boolean
        '--修正終了　2021年05月27:MK（ツール）- OR_003 VB→VB.NET変換

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Dim strSQL As String
        Dim intWork As Short
        Const C_NAME_FUNCTION As String = "gfncGetTableHandle"
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換



            '戻り値初期化
            gfncGetTableHandle = False

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    * "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & pstrSearchTable & " "
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1 "

            For intWork = 0 To UBound(pstrSearchItem)
                strSQL = strSQL & Chr(10) & "AND   " & pstrSearchItem(intWork) & " = '" & pstrSearchKey(intWork) & "' "
            Next

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            pobjDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H1)


            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:a79e565b-fe85-4319-9587-98c64152e4d6
            'PROC_END:

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:a79e565b-fe85-4319-9587-98c64152e4d6
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            gfncGetTableHandle = True

            If pblnFlgMsg Then
                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            End If

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b09e7300-13f6-4ce4-a664-78cbb4349193
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b09e7300-13f6-4ce4-a664-78cbb4349193

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b09e7300-13f6-4ce4-a664-78cbb4349193
PROC_FINALLY_END:
        Exit Function
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:b09e7300-13f6-4ce4-a664-78cbb4349193
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
