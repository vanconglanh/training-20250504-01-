Option Strict Off
Option Explicit On
Imports MKOra.Core
Public Module basZeikinCommonFunction
    Public Sub Set税コードCombobox(ByRef pobjTarget As ComboBox, ByVal pobjDB As OraDatabase)
        Dim strSQL As String
        Dim objDysCboSet As Object ' 商品マスタのOraDynaset

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    仕入税率コード "
        strSQL = strSQL & Chr(10) & "   ,仕入税率名"
        strSQL = strSQL & Chr(10) & "   ,税率"
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    運管仕入税率マスタ"
        'strSQL = strSQL & Chr(10) & "WHERE "
        'strSQL = strSQL & Chr(10) & "    適用日付 > '" & DateTime.Today.ToString("yyyyMMdd") & "' "
        'strSQL = strSQL & Chr(10) & "ORDER BY "
        'strSQL = strSQL & Chr(10) & "    仕入税率コード "

        Try

            objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

            With objDysCboSet

                Do Until .EOF = True
                    Call pobjTarget.Items.Add(CStr(Mid(.Fields("仕入税率コード").Value &
                                                       Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) &
                                                       GC_COMBO_SPLIT &
                                                       .Fields("仕入税率名").Value & "　" &
                                                       .Fields("税率").Value) & "％")

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Loop

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Module
