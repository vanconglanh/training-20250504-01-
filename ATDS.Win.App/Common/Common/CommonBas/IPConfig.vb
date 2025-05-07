Option Strict Off
Option Explicit On
Module basIPConfig

    ' @(f)
    '
    ' 機能　　　: ローカルＩＰ　取得処理
    '
    ' 返り値　　: ローカルＩＰ
    '
    ' 引き数　　: なし
    '
    ' 機能説明　: 接続名が「ローカル エリア接続」のＩＰを取得する。
    '　　　　　   その接続名が無い場合や、接続情報が取得できない場合は
    '　　　　　   接続可のＩＰ(0.0.0.0を除く)を取得する。
    '
    '　　　　　   通常、複数存在する事は無いと思われるが、
    '　　　　　   存在する場合には改良する必要あり。
    '
    '　　　　　   Win2000、XPでのみ動作する。
    '　　　　　   以外での動作が必要ならば改良する必要あり。
    '
    ' 備考      : 参考ＨＰ
    '　　　　　   http://wscript.name/index.php?Win32_NetworkAdapterConfiguration
    '
    ' 記入者　　: Maruo
    '
    ' 記入日　　: 2006.11.22
    '
    Public Function gfncGetLocalIP() As String

        '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        'On Error GoTo PROC_ERROR
        '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Const C_NAME_FUNCTION As String = "gfncGetLocalIP"
        Dim strComputer As String
        Dim objWMIservice As Object
        Dim colAdapters As Object
        Dim objAdapter As Object
        Dim colItems As Object
        Dim objItem As Object
        Dim strAdapterName As String
        Dim strCaption As String
        Dim colIP As New Collection
        Dim strSQL As String
        Dim strTemp As String
        Dim lngLoop As Integer
        Dim strRet As String
        '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
        Try
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Const C_NAME_FUNCTION As String = "gfncGetLocalIP"
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strComputer As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objWMIservice As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim colAdapters As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objAdapter As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim colItems As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim objItem As Object
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strAdapterName As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strCaption As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim colIP As New Collection
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strSQL As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strTemp As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim lngLoop As Integer
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            '++修正開始　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換
            'Dim strRet As String
            '--修正終了　2021年06月01:MK（ツール）- VB_530 VB→VB.NET変換

            strComputer = "."

            objWMIservice = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")

            '------------------------------
            '   対象LANアダプタ名を検索
            '------------------------------
            strAdapterName = "ローカル エリア接続"

            '    '-----------------------------------------------------------------------------
            '    '   ExecQueryメソッドでWin32_NetworkAdapterクラスから、アダプタ名で絞り込み
            '    '-----------------------------------------------------------------------------
            '    Set colAdapters = objWMIservice.ExecQuery _
            ''        ("Select * from Win32_NetworkAdapter where NetConnectionID='" & strAdapterName & "'")
            '
            '    '---------------------------------------------
            '    '   アダプタのオブジェクトからCaptionを取得
            '    '---------------------------------------------
            '    If Not colAdapters Is Nothing Then
            '        For Each objAdapter In colAdapters
            '            strCaption = objAdapter.Caption
            '        Next
            '    End If

            '------------------------------------------------------------------------------------
            '   ExecQueryメソッドでCaptionの値がWin32_NetworkAdapterクラスと同じアダプタを取得
            '------------------------------------------------------------------------------------
            strSQL = "SELECT"
            strSQL = strSQL & " *"
            strSQL = strSQL & " FROM Win32_NetworkAdapterConfiguration"
            strSQL = strSQL & " WHERE IPEnabled = TRUE"

            If Len(strCaption) Then
                strSQL = strSQL & "   AND Caption = '" & strCaption & "'"
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objWMIservice.ExecQuery. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            colItems = objWMIservice.ExecQuery(strSQL)

            For Each objItem In colItems

                'UPGRADE_WARNING: Couldn't resolve default property of object objItem.IPAddress. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If Not IsDBNull(objItem.IPAddress) Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objItem.IPAddress. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    For lngLoop = LBound(objItem.IPAddress) To UBound(objItem.IPAddress)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objItem.IPAddress. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strTemp = objItem.IPAddress(lngLoop)

                        If Len(strTemp) > 0 Then

                            If strTemp <> "0.0.0.0" Then

                                colIP.Add(strTemp)

                            End If

                        End If

                    Next

                End If

            Next objItem

            'UPGRADE_WARNING: Couldn't resolve default property of object colIP(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            strRet = colIP.Item(1)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:894c99c2-ae09-4989-aca5-90b1e2e5fa9b
            'PROC_END:

            'On Error Resume Next

            'UPGRADE_NOTE: Object colAdapters may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'colAdapters = Nothing
            'UPGRADE_NOTE: Object objAdapter may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objAdapter = Nothing
            'UPGRADE_NOTE: Object colItems may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'colItems = Nothing
            'UPGRADE_NOTE: Object objItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objItem = Nothing

            'gfncGetLocalIP = strRet

            'Exit Function

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
            'PROC_ERROR:
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:894c99c2-ae09-4989-aca5-90b1e2e5fa9b
        Catch ex As Exception
            '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換

            '    Call MsgBox(Err.Description, vbCritical, C_NAME_FUNCTION)

            '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296
            'Resume PROC_END
            '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296

            '++修正開始　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
        End Try
        '++修正開始　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296
PROC_FINALLY_END:
        '		On Error Resume Next
        Try
            colAdapters = Nothing
            objAdapter = Nothing
            colItems = Nothing
            objItem = Nothing
            gfncGetLocalIP = strRet
            Exit Function
        Catch ex1 As Exception
        End Try
        '--修正終了　2021年06月01:MK（ツール）- VB_523 VB→VB.NET変換	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296
        '--修正終了　2021年06月01:MK（ツール）- VB_522 VB→VB.NET変換
    End Function
End Module
