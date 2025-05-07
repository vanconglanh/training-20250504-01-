Option Strict Off
Option Explicit On
Module basGetEmployeeInfo
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetEmployeeInfo.bas
    ' ��    �e    : �]�ƈ��}�X�^ ��� �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetEmployeeInfo          (�]�ƈ����擾)
    '               <Private>
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/02/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetEmployeeInfo(ByVal pstrEmployeeCode As String, ByRef pclsLoginInfo As clsUnitLoginInfo, Optional ByRef pstrPassWord As String = "") As Boolean

        Dim strSQL As String
        Dim objDys�]�ƈ��}�X�^ As Object

        ' �����l��ݒ�(�ُ�I��)
        gfncGetEmployeeInfo = True

        ' SQL�� �쐬
        strSQL = "Select "
        strSQL = strSQL & "  �]�ƈ��}�X�^.�����R�[�h,   "
        strSQL = strSQL & "  �]�ƈ��}�X�^.�]�ƈ��R�[�h, "
        strSQL = strSQL & "  �]�ƈ��}�X�^.�]�ƈ�������, "
        strSQL = strSQL & "  �]�ƈ��}�X�^.�p�X���[�h,   "
        strSQL = strSQL & "  �]�ƈ��}�X�^.��E�ʃR�[�h, "
        strSQL = strSQL & "  �]�ƈ��}�X�^.��ЃR�[�h, "
        strSQL = strSQL & "  ���̃}�X�^.�W���P, "
        strSQL = strSQL & "  NVL(�]�ƈ��}�X�^.�ގЗ\���,'99999999') �ގЗ\���, "
        strSQL = strSQL & "  �����}�X�^.�V�X�e������,"
        strSQL = strSQL & "  �]�ƈ��}�X�^.�����N, "
        strSQL = strSQL & "  TO_CHAR(SYSDATE,'YYYYMMDD')  �V�X�e�����t "

        strSQL = strSQL & " From "
        strSQL = strSQL & "  �]�ƈ��}�X�^, "
        strSQL = strSQL & "  �����}�X�^, "
        strSQL = strSQL & "  ���̃}�X�^ "
        strSQL = strSQL & " Where �]�ƈ��}�X�^.�]�ƈ��R�[�h = '" & pstrEmployeeCode & "'"
        strSQL = strSQL & "   And �]�ƈ��}�X�^.�����R�[�h = �����}�X�^.�����R�[�h(+)"
        strSQL = strSQL & "   And �]�ƈ��}�X�^.��ЃR�[�h = �����}�X�^.��ЃR�[�h(+)"
        strSQL = strSQL & "   And �]�ƈ��}�X�^.��E�ʃR�[�h = ���̃}�X�^.�R�[�h(+)"
        strSQL = strSQL & "   And '��E��' = ���̃}�X�^.����(+)"

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDys�]�ƈ��}�X�^ = gobjOraDatabase.CreateDynaset(strSQL, &H1)

        With objDys�]�ƈ��}�X�^

            'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If .EOF Then

                '�G���[���b�Z�[�W�\��
                Call MsgBox(GC_ERR_MSG_0003, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                Exit Function

            Else

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .Fields("�ގЗ\���").Value < VB6.Format(Now, "YYYYMMDD") Then

                    '�G���[���b�Z�[�W�\��
                    Call MsgBox(GC_ERR_MSG_9001, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)

                    Exit Function

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.LoginDate = gfncFieldVal(.Fields("�V�X�e�����t").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pstrPassWord = gfncFieldVal(.Fields("�p�X���[�h").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.CompanyCode = gfncFieldVal(.Fields("��ЃR�[�h").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.PostCode = gfncFieldVal(.Fields("�����R�[�h").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.SystemAuthority = gfncFieldCur(.Fields("�V�X�e������").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If gfncFieldCur(.Fields("�W���P").Value) <> 0 Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pclsLoginInfo.SystemAuthority = gfncFieldCur(.Fields("�W���P").Value)

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.Rank = gfncFieldVal(.Fields("�����N").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.EmployeeName = gfncFieldVal(.Fields("�]�ƈ�������").Value)

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�]�ƈ��}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                pclsLoginInfo.OfficialPosition = gfncFieldCur(.Fields("��E�ʃR�[�h").Value)

            End If

        End With

        ' �����l��ݒ�(����I��)
        gfncGetEmployeeInfo = False

    End Function

    ''''Public Function gfncGetEmployeeName(ByVal pstrEmployeeCode As String, _
    '''''                                    ByRef pstrEmployeeName As String) As Boolean
    ''''
    ''''    Dim strSQL                              As String
    ''''    Dim objDys�]�ƈ��}�X�^                  As Object
    ''''
    ''''    '�߂�l��������(�ُ�I��)
    ''''    gfncGetEmployeeName = True
    ''''
    ''''    ' SQL�� �쐬
    ''''    strSQL = "SELECT "
    ''''    strSQL = strSQL & "  �]�ƈ��}�X�^.�]�ƈ�������, "
    ''''    strSQL = strSQL & "  �]�ƈ��}�X�^.�����R�[�h, "
    ''''    strSQL = strSQL & "  �����}�X�^.������ "
    ''''    strSQL = strSQL & " FROM "
    ''''    strSQL = strSQL & "  �]�ƈ��}�X�^, "
    ''''    strSQL = strSQL & "  �����}�X�^ "
    ''''    strSQL = strSQL & " WHERE "
    '''''TSL YOSHI 2007.05.01 ��ЃR�[�h�t���Ή� INSERT START
    ''''    strSQL = strSQL & "  �]�ƈ��}�X�^.��ЃR�[�h = �����}�X�^.��ЃR�[�h(+) AND "
    '''''TSL YOSHI 2007.05.01 ��ЃR�[�h�t���Ή� INSERT END
    ''''    strSQL = strSQL & "  �]�ƈ��}�X�^.�����R�[�h = �����}�X�^.�����R�[�h(+) AND "
    ''''    strSQL = strSQL & "  �]�ƈ��}�X�^.�]�ƈ��R�[�h= '" & pstrEmployeeCode & "' "
    ''''
    ''''    Set objDys�]�ƈ��}�X�^ = gobjOraDatabase.CreateDynaset(strSQL, &H1&)
    ''''
    ''''    With objDys�]�ƈ��}�X�^
    ''''
    ''''        '�]�ƈ��}�X�^�̒��ɓ��͂��ꂽ�����ނ��L�邩�ǂ�������
    ''''        If .eof = False Then
    ''''
    ''''            '�߂�l��ݒ�(����I��)
    ''''            gfncGetEmployeeName = False
    ''''
    ''''            '�]�ƈ��}�X�^�ɓ��͂��ꂽ�����ނ�����ꍇ�A�Ј�����\��
    ''''            pstrEmployeeName = gfncFieldVal(.Fields("�]�ƈ�������").Value)
    ''''
    ''''        End If
    ''''
    ''''        .Close
    ''''
    ''''    End With
    ''''
    ''''End Function
End Module