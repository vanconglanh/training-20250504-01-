Option Strict Off
Option Explicit On

Public Module basSokujiShuseiBiCommonFunction
    Public Function isSokujiShuseiBi(ByVal pstr’÷‚ß“ú‹æ•ª As String, ByVal pstr“ú•t‰æ–Ê As String) As Boolean
        Dim mstr‘¦C³“ú As String

        isSokujiShuseiBi = False
        mstr‘¦C³“ú = GetSokujiShuseiBi(pstr’÷‚ß“ú‹æ•ª)

        If mstr‘¦C³“ú = "" Then

        ElseIf (pstr“ú•t‰æ–Ê <= mstr‘¦C³“ú) Then
            isSokujiShuseiBi = True
        End If

    End Function

    Public Function isSokujiShuseiBiBy‘¦C³“ú(ByVal mstr‘¦C³“ú As String, ByVal pstr“ú•t‰æ–Ê As String) As Boolean

        isSokujiShuseiBiBy‘¦C³“ú = False

        If mstr‘¦C³“ú = "" Then

        ElseIf (pstr“ú•t‰æ–Ê <= mstr‘¦C³“ú) Then
            isSokujiShuseiBiBy‘¦C³“ú = True
        End If

    End Function

    Public Function GetSokujiShuseiBi(ByVal pstr’÷‚ß“ú‹æ•ª As String) As String
        Dim strSQL As String
        Dim mstr‘¦C³“ú As String
        Dim objDysTemp As Object

        GetSokujiShuseiBi = ""

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "     ’÷‚ß“ú "
        strSQL = strSQL & Chr(10) & "    ,‘¦C³“ú"
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    ’÷“ú‘¦C³“úƒ}ƒXƒ^ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    ’÷‚ß“ú‹æ•ª      = '" & pstr’÷‚ß“ú‹æ•ª & "' "
        strSQL = strSQL & Chr(10) & "AND ÅVƒf[ƒ^‹æ•ª  = '1' "

        Try

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    GetSokujiShuseiBi = CStr(gfncFieldCur(.Fields("‘¦C³“ú").Value))

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module
