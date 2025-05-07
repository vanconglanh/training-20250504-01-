Option Strict Off
Option Explicit On
Imports MKOra.Core

Friend Class clsExportDbToCsv
    Private Idx As Short ' 配列用数字
    Private Jdx As Short ' 配列用数字
    Private W As Object ' ワーク変数
    Private REC As String ' ワーク変数

    ' ＯｒａｃｌｅOO4Oオブジェクト名
    '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
    'Private OraSession As Object
    'Private OraDatabase As Object
    'Private OraDynaset As Object
    Private OraSession As OraSession
    Private OraDatabase As OraDatabase
    Private OraDynaset As OraDynaset
    '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換

    ' パラメータ設定・参照用変数
    Private mstrDataBase As String ' 接続データベース
    Private mstrUserPass As String ' ユーザ／パスワード
    Private mstrSQL As String ' ＳＱＬ文
    Private mblnTitleOutPut As Boolean ' 項目タイトル出力有無
    Private mstrCsvFileName As String ' ＣＳＶファイル名
    Private mintProcRecordCount As Integer ' 処理件数
    Private mintAllRecordCount As Integer ' 全件数
    Private mintErrorCode As Integer ' エラーコード

    ' イベント
    Public Event Display()
    '------------------------------------------------------------
    ' 接続するデータベース名
    '------------------------------------------------------------
    Public WriteOnly Property DataBase() As String
        Set(ByVal Value As String)
            mstrDataBase = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' 接続するユーザ／パスワード
    '------------------------------------------------------------
    Public WriteOnly Property UserPass() As String
        Set(ByVal Value As String)
            mstrUserPass = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' 問い合わせＳＱＬ
    '------------------------------------------------------------
    Public WriteOnly Property SQL() As String
        Set(ByVal Value As String)
            mstrSQL = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' CSVファイル名（パス）
    '------------------------------------------------------------
    Public WriteOnly Property CsvFileName() As String
        Set(ByVal Value As String)
            mstrCsvFileName = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' タイトル出力有無
    '------------------------------------------------------------
    Public WriteOnly Property TitleOutPut() As Boolean
        Set(ByVal Value As Boolean)
            mblnTitleOutPut = Value
        End Set
    End Property

    '------------------------------------------------------------
    ' 全件数
    '------------------------------------------------------------
    Public ReadOnly Property AllRecordCount() As String
        Get
            AllRecordCount = CStr(mintAllRecordCount)
        End Get
    End Property

    '------------------------------------------------------------
    ' 処理件数
    '------------------------------------------------------------
    Public ReadOnly Property ProcRecordCount() As String
        Get
            ProcRecordCount = CStr(mintProcRecordCount)
        End Get
    End Property

    '------------------------------------------------------------
    ' エラーコード
    '------------------------------------------------------------
    Public ReadOnly Property ErrorCode() As String
        Get
            ErrorCode = CStr(mintErrorCode)
        End Get
    End Property

    Public Sub Connect()
        On Error Resume Next
        ' Oracle OO4Oのオープン
        '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
        'OraSession = CreateObject("OracleInProcServer.XOraSession")
        OraSession = New OraSession()
        '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
        'UPGRADE_WARNING: Couldn't resolve default property of object OraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OraDatabase = OraSession.OpenDatabase(mstrDataBase, mstrUserPass, &H0)
        ' 追加テーブルから定義だけ取得(絶対選択されないＳＱＬを発行)
        'UPGRADE_WARNING: Couldn't resolve default property of object OraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OraDynaset = OraDatabase.CreateDynaset(mstrSQL, &H4)
        If Err.Number <> 0 Then
            mintErrorCode = Err.Number
            Exit Sub
        End If
        On Error GoTo 0
        ' 表示件数初期化
        'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        mintAllRecordCount = OraDynaset.RecordCount
        mintProcRecordCount = 0
    End Sub

    Public Sub Output()
        ' ＣＳＶファイルをオープンする
        FileOpen(1, mstrCsvFileName, OpenMode.Output)

        ' レコード出力処理
        With OraDynaset
            ' 項目タイトル出力処理
            If mblnTitleOutPut Then
                REC = ""
                'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                For Jdx = 0 To .Fields.Count - 1
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
                    'W = """" & .FieldName(Jdx) & """"
                    '++修正開始　2021年09月22日:MK（手）- VB→VB.NET変換
                    'W = """" & gfncFieldVal(.Fields(Jdx).Value) & """"
                    W = """" & gfncFieldVal(.Fields(Jdx).Name) & """"
                    '--修正開始　2021年09月22日:MK（手）- VB→VB.NET変換
                    '--修正開始　2021年09月18日:MK（手）- VB→VB.NET変換
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    REC = REC & W
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Jdx < .Fields.Count - 1 Then
                        REC = REC & ","
                    End If
                Next
                PrintLine(1, REC)
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            While Not .EOF
                REC = ""
                'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                For Jdx = 0 To .Fields.Count - 1
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    W = .Fields(Jdx).Value
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Select Case .Fields(Jdx).Type
                        Case 10, 11, 12 ' 文字列
                            'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            W = """" & W & """"
                        Case 3, 4, 7 ' 数値
                            'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            W = W
                        Case 8 ' 日付
                            'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++修正開始　2021年09月22日:MK（手）- VB→VB.NET変換
                            'W = """" & VB6.Format(W, "YYYY/MM/DD") & """"
                            If W Is Nothing Then
                                W = """" & "" & """"
                            Else
                                W = """" & VB6.Format(W, "YYYY/MM/DD") & """"
                            End If

                            '--修正開始　2021年09月22日:MK（手）- VB→VB.NET変換
                    End Select
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    REC = REC & W
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Jdx < .Fields.Count - 1 Then
                        REC = REC & ","
                    End If
                Next
                PrintLine(1, REC)
                'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .MoveNext()
                mintProcRecordCount = mintProcRecordCount + 1
                RaiseEvent Display()
            End While
        End With
        FileClose()
    End Sub
End Class