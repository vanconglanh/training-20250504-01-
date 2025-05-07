Option Strict Off
Option Explicit On
Module basNumberHandle
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : NumberHandle.bas
    ' ��    �e    : �]�ƈ��R�[�h�̍̔� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncNumberHandle             (�]�ƈ��R�[�h�i�Ј��j�����̔ԏ���)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/10/27  KSR                �V�K�쐬
    '
    '******************************************************************************


    '******************************************************************************
    ' �� �� ��  : gfncNumberHandle
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��R�[�h�i�Ј��j�����̔ԏ���
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEmployeeCD      String            I/O   �̔ԏ]�ƈ��R�[�h
    '   pstrKana            String            I/O   �]�ƈ����J�i
    '   pstrCompanyCD       String            I     ��ЃR�[�h
    '   pblnFlgMsg          Boolean           I     ���b�Z�[�W�o�͗L��
    '                                                 True  : ���b�Z�[�W�o�͗L
    '                                                 False : ���b�Z�[�W�o�͖�
    '   pblnFlgPointer      Boolean           I     �}�E�X�|�C���^����L��
    '                                                 True  : �}�E�X�|�C���^����L
    '                                                 False : �}�E�X�|�C���^���䖳
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/10/27  �j�r�q             �V�K�쐬�i�c�Ə����W���[�����ڍs�j
    '
    '******************************************************************************
    Public Function gfncNumberHandle(ByRef pstrEmployeeCD As String, ByRef pstrKana As String, ByVal pstrCompanyCD As String, Optional ByVal pblnFlgMsg As Boolean = True, Optional ByVal pblnFlgPointer As Boolean = True) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Dim strSQL As String
        Dim objDysJ As Object '�]�ƈ��}�X�^��OraDynaset
        Dim objDysM As Object '�}�X�^��OraDynaset
        Dim intIndx As Short
        Dim str�ޔ��R�[�h As String
        Dim strW�]�ƈ��R�[�h As String
        Dim str�]�ƈ��R�[�h�擪���� As String
        Dim intMode As Short
        Const C_NAME_FUNCTION As String = "gfncNumberHandle"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDysJ As Object '�]�ƈ��}�X�^��OraDynaset
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDysM As Object '�}�X�^��OraDynaset
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intIndx As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim str�ޔ��R�[�h As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strW�]�ƈ��R�[�h As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim str�]�ƈ��R�[�h�擪���� As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intMode As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncNumberHandle"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '�߂�l������
            gfncNumberHandle = False

            '�Ђ炪�Ȃ��J�i�ɕϊ�
            pstrKana = StrConv(RTrim(pstrKana), VbStrConv.Katakana)
            '�S�p�����𔼊p�ɕϊ�
            pstrKana = StrConv(pstrKana, VbStrConv.Narrow)

            '�̔ԕ��@�̔���i�G���P�C�̍̔ԁ@OR�@�G���P�C�ȊO�̍̔ԁj
            strSQL = ""
            strSQL = "SELECT �Ј��]�ƈ��R�[�h�擪����"
            strSQL = strSQL & " FROM ��Ѓ}�X�^"
            strSQL = strSQL & " WHERE ��ЃR�[�h = '" & RTrim(pstrCompanyCD) & "'"
            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysM = gobjOraDatabase.CreateDynaset(strSQL, &H1)

            With objDysM

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = True Then
                    '�G���P�C�̍̔�
                    intMode = 0
                    str�]�ƈ��R�[�h�擪���� = ""
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Trim(gfncFieldVal(.Fields("�Ј��]�ƈ��R�[�h�擪����").Value)) = "" Then
                        '�G���P�C�̍̔�
                        intMode = 0
                        str�]�ƈ��R�[�h�擪���� = ""
                    Else
                        '�G���P�C�ȊO�̍̔�
                        intMode = 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        str�]�ƈ��R�[�h�擪���� = RTrim(gfncFieldVal(.Fields("�Ј��]�ƈ��R�[�h�擪����").Value))
                    End If
                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .Close()
            End With

            'UPGRADE_NOTE: Object objDysM may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysM = Nothing

            Select Case intMode
            '�G���P�C�̍̔�
                Case 0
                    '�]�ƈ��R�[�h�̔ԃe�[�u��������̓J�i(�擪�ꕶ����)�ŏ����擾
                    strSQL = "SELECT *"
                    strSQL = strSQL & " FROM �]�ƈ��R�[�h�̔ԃe�[�u��"
                    strSQL = strSQL & " WHERE �]�ƈ����J�i = '" & Mid(pstrKana, 1, 1) & "'"
                    strSQL = strSQL & " ORDER BY �̔Ԕԍ�"
                    'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    objDysM = gobjOraDatabase.CreateDynaset(strSQL, &H1)

                    '���͂��ꂽ�����ނ��L�邩�ǂ�������
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If objDysM.EOF Then
                        gfncNumberHandle = True
                        If pblnFlgMsg Then
                            '�װү���ނ�\�����܂�
                            MsgBox("�]�ƈ��R�[�h�̔Ԃɏ]�ƈ��J�i���o�^����Ă��Ȃ����߁A�̔Ԃł��܂���B", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                        End If
                        If pblnFlgPointer Then
                            '�����v�߲�����������܂��B
                            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        End If
                        Exit Function
                    Else
                        'ٰ�߇@�J�n
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Do Until objDysM.EOF
                            'ܰ��̏����ݒ�
                            pstrEmployeeCD = ""
                            str�ޔ��R�[�h = ""

                            '�u�]�ƈ��}�X�^�v�Ɓu�]�ƈ��ٓ��e�[�u���v����̔ԃR�[�h�Ŏg�p�Ϗ����擾(�擪3���Ŏ擾)
                            strSQL = "SELECT SUBSTR(�]�ƈ��R�[�h,4,4) �g�p�σR�[�h"
                            strSQL = strSQL & " FROM �]�ƈ��}�X�^"
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            strSQL = strSQL & " WHERE SUBSTR(�]�ƈ��R�[�h,1,3) = '" & gfncFieldVal(objDysM.Fields("�̔ԃR�[�h").Value) & "'"

                            strSQL = strSQL & "UNION "

                            strSQL = strSQL & "SELECT SUBSTR(�V�]�ƈ��R�[�h,4,4) �g�p�σR�[�h"
                            strSQL = strSQL & " FROM �]�ƈ��ٓ��e�[�u��"
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            strSQL = strSQL & " WHERE SUBSTR(�V�]�ƈ��R�[�h,1,3) = '" & gfncFieldVal(objDysM.Fields("�̔ԃR�[�h").Value) & "'"
                            strSQL = strSQL & "   AND SUBSTR(�V�]�ƈ��R�[�h,4,4) >= '0001'"
                            strSQL = strSQL & "   AND SUBSTR(�V�]�ƈ��R�[�h,4,4) <= '9999'"
                            strSQL = strSQL & "   AND �ٓ���� = 4"
                            strSQL = strSQL & "   AND ����T�C�� = 0"

                            strSQL = strSQL & " ORDER BY �g�p�σR�[�h"

                            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            objDysJ = gobjOraDatabase.CreateDynaset(strSQL, &H1)

                            '���͂��ꂽ�����ނ��L�邩�ǂ�������
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            If objDysJ.EOF Then
                                '"0001"��ݒ�
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                pstrEmployeeCD = gfncFieldVal(objDysM.Fields("�̔ԃR�[�h").Value) & "0001"

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysJ.Close()
                                'ٰ�߇@�𔲂���
                                Exit Do

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysJ.Fields(�g�p�σR�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            ElseIf "0001" < gfncFieldVal(objDysJ.Fields("�g�p�σR�[�h").Value) Then
                                '"0001"��ݒ�
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                pstrEmployeeCD = gfncFieldVal(objDysM.Fields("�̔ԃR�[�h").Value) & "0001"

                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysJ.Close()
                                'ٰ�߇@�𔲂���
                                Exit Do

                            Else
                                'ٰ�߇A�J�n
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                Do Until objDysJ.EOF
                                    '�ޔ��ނ�ܰ��ɑޔ�
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    str�ޔ��R�[�h = gfncFieldVal(objDysJ.Fields("�g�p�σR�[�h").Value)

                                    '����ں��ނ�READ
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    objDysJ.MoveNext()
                                    '�ް��������ꍇ
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    If objDysJ.EOF Then
                                        If str�ޔ��R�[�h = "9999" Then
                                            'ٰ�߇A�𔲂���
                                            Exit Do
                                        Else
                                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            pstrEmployeeCD = gfncFieldVal(objDysM.Fields("�̔ԃR�[�h").Value) & VB6.Format(CInt(str�ޔ��R�[�h) + 1, "0000")
                                            'ٰ�߇A�𔲂���
                                            Exit Do
                                        End If
                                    Else
                                        '(�g�p�� - �ޔ��R�[�h) >= 2(���ފԂɋ󂫂�����) �Ȃ� �ޔ��R�[�h + 1 ��ݒ�
                                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                        If (gfncFieldCur(objDysJ.Fields("�g�p�σR�[�h").Value) - CInt(str�ޔ��R�[�h)) >= 2 Then
                                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                            pstrEmployeeCD = gfncFieldVal(objDysM.Fields("�̔ԃR�[�h").Value) & VB6.Format(CInt(str�ޔ��R�[�h) + 1, "0000")
                                            'ٰ�߇A�𔲂���
                                            Exit Do
                                        End If
                                    End If
                                Loop

                                '�̔Ԃ��ꂽ�ꍇ�͏����𔲂���B
                                If pstrEmployeeCD = "" Then
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    objDysM.MoveNext()
                                Else
                                    'ٰ�߇@�𔲂���
                                    Exit Do
                                End If
                            End If
                        Loop
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        objDysM.Close()
                    End If

                    '�]�ƈ��R�[�h���ݒ肳��Ȃ������ꍇ��ү����
                    If pstrEmployeeCD = "" Then
                        gfncNumberHandle = True
                        If pblnFlgMsg Then
                            '�װү���ނ�\�����܂�
                            MsgBox("�󂫔ԍ�������܂���B", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                        End If
                        If pblnFlgPointer Then
                            '�����v�߲�����������܂��B
                            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                        End If
                        Exit Function
                    End If

                '�G���P�C�ȊO�̍̔�
                Case 1
                    '            '۸޲ݕ�����ܰ��̐擪�Q����������
                    '            Select Case pstrCompanyCD
                    '                '���É�
                    '                Case "270"
                    '                    strW�]�ƈ��R�[�h = "81"
                    '                '�_��
                    '                Case "280"
                    '                    strW�]�ƈ��R�[�h = "80"
                    '                '���
                    '                Case "99011", "99021"
                    '                    strW�]�ƈ��R�[�h = "33"
                    '                '�O�a
                    '                Case "910"
                    '                    strW�]�ƈ��R�[�h = "76"
                    '                '��
                    '                Case "920"
                    '                    strW�]�ƈ��R�[�h = "75"
                    '                Case Else
                    '                    gfncNumberHandle = True
                    '                    If pblnFlgMsg Then
                    '                        '�װү���ނ�\�����܂�
                    '                        MsgBox "���Q�������ݒ肳��Ă��܂���B", _
                    ''                               vbOKOnly + vbCritical, GC_ERR_TITLE
                    '                    End If
                    '                    If pblnFlgPointer Then
                    '                        '�����v�߲�����������܂��B
                    '                        Screen.MousePointer = vbDefault
                    '                    End If
                    '                    Exit Function
                    '            End Select

                    strW�]�ƈ��R�[�h = str�]�ƈ��R�[�h�擪����

                    '���Ͷł̐擪������ܰ��̂R���ڂ�����
                    Select Case Mid(pstrKana, 1, 1)
                        Case "�", "�", "�", "�", "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "0"
                        Case "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "1"
                        Case "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "2"
                        Case "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "3"
                        Case "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "4"
                        Case "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "5"
                        Case "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "6"
                        Case "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "7"
                        Case "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "8"
                        Case "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "9"
                        Case Else
                            gfncNumberHandle = True
                            If pblnFlgMsg Then
                                '�װү���ނ�\�����܂�
                                MsgBox("�擪�ɍ̔ԏo���Ȃ����������͂���Ă��܂��B", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                            End If
                            If pblnFlgPointer Then
                                '�����v�߲�����������܂��B
                                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            End If
                            Exit Function
                    End Select

                    '���Ͷł̐擪������ܰ��̂S���ڂ�����
                    Select Case Mid(pstrKana, 1, 1)
                        Case "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "0"
                        Case "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "2"
                        Case "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "4"
                        Case "�", "�", "�", "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "6"
                        Case "�", "�", "�", "�", "�", "�", "�", "�", "�"
                            strW�]�ƈ��R�[�h = strW�]�ƈ��R�[�h & "8"
                        Case Else
                            gfncNumberHandle = True
                            If pblnFlgMsg Then
                                '�װү���ނ�\�����܂�
                                MsgBox("�擪�ɍ̔ԏo���Ȃ����������͂���Ă��܂��B", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GC_ERR_TITLE)
                            End If
                            If pblnFlgPointer Then
                                '�����v�߲�����������܂��B
                                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                            End If
                            Exit Function
                    End Select

                    'ܰ��̂R���ڂłQ��̍̔Ԃ��s��(ٰ�߇@)
                    For intIndx = 1 To 2
                        'ܰ��̏����ݒ�
                        pstrEmployeeCD = ""
                        str�ޔ��R�[�h = ""

                        '�u�]�ƈ��}�X�^�v�Ɓu�]�ƈ��ٓ��e�[�u���v����̔ԃR�[�h�Ŏg�p�Ϗ����擾(�擪4���Ŏ擾)
                        strSQL = "SELECT SUBSTR(�]�ƈ��R�[�h,5,3) �g�p�σR�[�h"
                        strSQL = strSQL & " FROM �]�ƈ��}�X�^"
                        strSQL = strSQL & " WHERE SUBSTR(�]�ƈ��R�[�h,1,4) = '" & strW�]�ƈ��R�[�h & "'"

                        strSQL = strSQL & "UNION "

                        strSQL = strSQL & "SELECT SUBSTR(�V�]�ƈ��R�[�h,5,3) �g�p�σR�[�h"
                        strSQL = strSQL & " FROM �]�ƈ��ٓ��e�[�u��"
                        strSQL = strSQL & " WHERE SUBSTR(�V�]�ƈ��R�[�h,1,4) = '" & strW�]�ƈ��R�[�h & "'"
                        strSQL = strSQL & "   AND SUBSTR(�V�]�ƈ��R�[�h,5,3) >= '001'"
                        strSQL = strSQL & "   AND SUBSTR(�V�]�ƈ��R�[�h,5,3) <= '999'"
                        strSQL = strSQL & "   AND �ٓ���� = 4"
                        strSQL = strSQL & "   AND ����T�C�� = 0"

                        strSQL = strSQL & " ORDER BY �g�p�σR�[�h"
                        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        objDysJ = gobjOraDatabase.CreateDynaset(strSQL, &H1)

                        '���͂��ꂽ�����ނ��L�邩�ǂ�������
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If objDysJ.EOF Then
                            '"001"��ݒ�
                            pstrEmployeeCD = strW�]�ƈ��R�[�h & "001"

                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            objDysJ.Close()
                            'ٰ�߇@�𔲂���
                            Exit For
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysJ.Fields(�g�p�σR�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ElseIf "001" < gfncFieldVal(objDysJ.Fields("�g�p�σR�[�h").Value) Then
                            '"001"��ݒ�
                            pstrEmployeeCD = strW�]�ƈ��R�[�h & "001"

                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            objDysJ.Close()
                            'ٰ�߇@�𔲂���
                            Exit For

                        Else
                            'ٰ�߇A�J�n
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Do Until objDysJ.EOF
                                '�ޔ��ނ�ܰ��ɑޔ�
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                str�ޔ��R�[�h = gfncFieldVal(objDysJ.Fields("�g�p�σR�[�h").Value)

                                '����ں��ނ�READ
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysJ.MoveNext()
                                '�ް��������ꍇ
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                If objDysJ.EOF Then
                                    If str�ޔ��R�[�h = "999" Then
                                        'ٰ�߇A�𔲂���
                                        Exit Do
                                    Else
                                        pstrEmployeeCD = strW�]�ƈ��R�[�h & VB6.Format(CInt(str�ޔ��R�[�h) + 1, "000")
                                        'ٰ�߇A�𔲂���
                                        Exit Do
                                    End If
                                Else
                                    '(�g�p�� - �ޔ��R�[�h) >= 2(���ފԂɋ󂫂�����) �Ȃ� �ޔ��R�[�h + 1 ��ݒ�
                                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysJ.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    If (gfncFieldCur(objDysJ.Fields("�g�p�σR�[�h").Value) - CInt(str�ޔ��R�[�h)) >= 2 Then
                                        pstrEmployeeCD = strW�]�ƈ��R�[�h & VB6.Format(CInt(str�ޔ��R�[�h) + 1, "000")
                                        'ٰ�߇A�𔲂���
                                        Exit Do
                                    End If
                                End If
                            Loop

                            '�̔Ԃ��ꂽ�ꍇ�͏����𔲂���B
                            If pstrEmployeeCD = "" Then
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysM.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                objDysM.MoveNext()
                            Else
                                'ٰ�߇@�𔲂���
                                Exit For
                            End If
                        End If

                        'ܰ����ı��߁i�Q��ڂ̍̔Ԃׁ̈j
                        strW�]�ƈ��R�[�h = CStr(CDbl(strW�]�ƈ��R�[�h) + 1)
                    Next intIndx
            End Select

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b08e273c-96f6-470f-9fb3-c89c38430582
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b08e273c-96f6-470f-9fb3-c89c38430582
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            gfncNumberHandle = True

            If pblnFlgMsg Then
                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f29a0e70-3beb-49d9-898e-3df428644792
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f29a0e70-3beb-49d9-898e-3df428644792
            'Resume 
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f29a0e70-3beb-49d9-898e-3df428644792
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f29a0e70-3beb-49d9-898e-3df428644792
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
