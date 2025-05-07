Option Strict Off
Option Explicit On

Public Module basSokujiShuseiBiCommonFunction
    Public Function isSokujiShuseiBi(ByVal pstr���ߓ��敪 As String, ByVal pstr���t��� As String) As Boolean
        Dim mstr�����C���� As String

        isSokujiShuseiBi = False
        mstr�����C���� = GetSokujiShuseiBi(pstr���ߓ��敪)

        If mstr�����C���� = "" Then

        ElseIf (pstr���t��� <= mstr�����C����) Then
            isSokujiShuseiBi = True
        End If

    End Function

    Public Function isSokujiShuseiBiBy�����C����(ByVal mstr�����C���� As String, ByVal pstr���t��� As String) As Boolean

        isSokujiShuseiBiBy�����C���� = False

        If mstr�����C���� = "" Then

        ElseIf (pstr���t��� <= mstr�����C����) Then
            isSokujiShuseiBiBy�����C���� = True
        End If

    End Function

    Public Function GetSokujiShuseiBi(ByVal pstr���ߓ��敪 As String) As String
        Dim strSQL As String
        Dim mstr�����C���� As String
        Dim objDysTemp As Object

        GetSokujiShuseiBi = ""

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "     ���ߓ� "
        strSQL = strSQL & Chr(10) & "    ,�����C����"
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    ���������C�����}�X�^ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    ���ߓ��敪      = '" & pstr���ߓ��敪 & "' "
        strSQL = strSQL & Chr(10) & "AND �ŐV�f�[�^�敪  = '1' "

        Try

            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    GetSokujiShuseiBi = CStr(gfncFieldCur(.Fields("�����C����").Value))

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module
