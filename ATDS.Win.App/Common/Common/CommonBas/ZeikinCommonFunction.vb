Option Strict Off
Option Explicit On
Imports MKOra.Core
Public Module basZeikinCommonFunction
    Public Sub Set�ŃR�[�hCombobox(ByRef pobjTarget As ComboBox, ByVal pobjDB As OraDatabase)
        Dim strSQL As String
        Dim objDysCboSet As Object ' ���i�}�X�^��OraDynaset

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    �d���ŗ��R�[�h "
        strSQL = strSQL & Chr(10) & "   ,�d���ŗ���"
        strSQL = strSQL & Chr(10) & "   ,�ŗ�"
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    �^�ǎd���ŗ��}�X�^"
        'strSQL = strSQL & Chr(10) & "WHERE "
        'strSQL = strSQL & Chr(10) & "    �K�p���t > '" & DateTime.Today.ToString("yyyyMMdd") & "' "
        'strSQL = strSQL & Chr(10) & "ORDER BY "
        'strSQL = strSQL & Chr(10) & "    �d���ŗ��R�[�h "

        Try

            objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

            With objDysCboSet

                Do Until .EOF = True
                    Call pobjTarget.Items.Add(CStr(Mid(.Fields("�d���ŗ��R�[�h").Value &
                                                       Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) &
                                                       GC_COMBO_SPLIT &
                                                       .Fields("�d���ŗ���").Value & "�@" &
                                                       .Fields("�ŗ�").Value) & "��")

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
