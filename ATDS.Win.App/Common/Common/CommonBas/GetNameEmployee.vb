Option Strict Off
Option Explicit On
Imports MKOra.Core

Module basGatNameEmployee
    '******************************************************************************
    ' �� �� ��  : gfncGetNameEmployee
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ������� �擾
    ' ��    �l  :
    ' �� �� �l  : �]�ƈ�������
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCode    String            I     �]�ƈ��R�[�h
    '   pstrEmployeeName    String            O     �]�ƈ�������
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2008/03/21  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetNameEmployee(ByVal pstrEmployeeCode As String, ByRef pstrEmployeeName As String) As Boolean

        Dim strSQL As String
        '++�C���J�n�@2021�N09��11��:MK�i��j- VB��VB.NET�ϊ�
        'Dim objDys�]�ƈ��}�X�^ As Object
        Dim objDys�]�ƈ��}�X�^ As OraDynaset
        '--�C���J�n�@2021�N09��11��:MK�i��j- VB��VB.NET�ϊ�

        ' �߂�l���������i�ُ�I���j
        gfncGetNameEmployee = True

        ' SQL�� �쐬
        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    �]�ƈ������� "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    �]�ƈ��}�X�^ "
        strSQL = strSQL & Chr(10) & "WHERE "
        strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h= '" & pstrEmployeeCode & "' "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDys�]�ƈ��}�X�^ = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        With objDys�]�ƈ��}�X�^

            '�]�ƈ��}�X�^�̒��ɓ��͂��ꂽ�����ނ��L�邩�ǂ�������
            'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF = False Then

                '�߂�l��ݒ�(����I��)
                gfncGetNameEmployee = False

                '�]�ƈ��}�X�^�ɓ��͂��ꂽ�����ނ�����ꍇ�A�Ј�����\��
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstrEmployeeName = gfncFieldVal(.Fields("�]�ƈ�������").Value)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Call .Close()

        End With

        Call gsubClearObject(objDys�]�ƈ��}�X�^)

    End Function
End Module