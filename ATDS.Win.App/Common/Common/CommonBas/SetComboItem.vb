Option Strict Off
Option Explicit On
Module basSetComboItem
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : SetComboItem.bas
    ' ��    �e    : �R���{�{�b�N�X �A�C�e�� �ݒ� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gsubSetComboItem             (�R���{�{�b�N�X �A�C�e�� �ݒ�)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.01.00    2008/05/21  �A��  �F��         �U�����ЃR�[�h(�^��)�̒ǉ�
    '   02.02.00    2009/12/10  �A��  �F��         ���Ɨp�Ԏ�R�[�h�̒ǉ�
    '   02.03.00    2010/06/21  �A��  �F��         �w���ē��ނ̒ǉ�
    '   02.04.00    2017/01/23�@�j�r�q             �t�@�[�X�g�̌���萔����擾
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    Public Const GC_CBOID_�����R�[�h As Short = 1 ' �����R�[�h(�S��)
    Public Const GC_CBOID_�ΑӃR�[�h As Short = 2 ' �ΑӋ敪(�S��)
    Public Const GC_CBOID_�[�U���R�[�h As Short = 3 ' �[�U���R�[�h
    Public Const GC_CBOID_�F�΋敪 As Short = 4 ' �F�΋敪
    Public Const GC_CBOID_�o���敪 As Short = 5 ' �o���敪
    Public Const GC_CBOID_���� As Short = 6 ' ����
    Public Const GC_CBOID_�Ζ��敪 As Short = 7 ' �Ζ��敪
    Public Const GC_CBOID_���q�敪 As Short = 8 ' ���q�敪
    Public Const GC_CBOID_�t�@�[�X�g As Short = 9 ' �t�@�[�X�g
    Public Const GC_CBOID_��ԋ敪 As Short = 10 ' ��ԋ敪
    Public Const GC_CBOID_���q�ԍ��n��R�[�h As Short = 11 ' ���q�ԍ��n��R�[�h
    Public Const GC_CBOID_������� As Short = 12 ' �������
    Public Const GC_CBOID_�����ҏW�� As Short = 13 ' �����ҏW��
    Public Const GC_CBOID_�a�@�R�[�h As Short = 14 ' �a�@�R�[�h
    Public Const GC_CBOID_�s���{�� As Short = 15 ' �s���{��
    Public Const GC_CBOID_�����敪 As Short = 16 ' �����敪
    Public Const GC_CBOID_�斱�敪 As Short = 17 ' �斱�敪
    Public Const GC_CBOID_��s�R�[�h As Short = 18 ' ��s�R�[�h
    Public Const GC_CBOID_�U���敪 As Short = 19 ' �U���敪
    Public Const GC_CBOID_���͋敪 As Short = 20 ' ���͋敪
    Public Const GC_CBOID_�萔�����ݒ�� As Short = 21 ' �萔�����ݒ��
    Public Const GC_CBOID_���� As Short = 22 ' ����
    Public Const GC_CBOID_���t�^ As Short = 23 ' ���t�^
    Public Const GC_CBOID_�L���敪 As Short = 24 ' �L���敪
    Public Const GC_CBOID_���Ƌ敪 As Short = 25 ' ���Ƌ敪
    Public Const GC_CBOID_�}�C�J�[�ʋ΋敪 As Short = 26 ' �}�C�J�[�ʋ΋敪
    Public Const GC_CBOID_��E�� As Short = 27 ' ��E��
    Public Const GC_CBOID_���K�敪 As Short = 29 ' ���K�敪
    Public Const GC_CBOID_�����敪 As Short = 30 ' �����敪
    Public Const GC_CBOID_�ŋ敪 As Short = 31 ' �ŋ敪
    Public Const GC_CBOID_�{���㖱�敪 As Short = 32 ' �{���㖱�敪
    Public Const GC_CBOID_�V�X�e������ As Short = 35 ' �V�X�e������
    Public Const GC_CBOID_�����ΑӃR�[�h As Short = 36 ' �����ΑӃR�[�h
    Public Const GC_CBOID_�ސE�R�[�h As Short = 37 ' �ސE�R�[�h
    Public Const GC_CBOID_�}�{�`���敪 As Short = 38 ' �}�{�`���敪
    Public Const GC_CBOID_�����敪 As Short = 39 ' �����敪
    Public Const GC_CBOID_�u�`�R�[�h As Short = 40 ' �u�`�R�[�h
    Public Const GC_CBOID_�j�� As Short = 44 ' �j��
    Public Const GC_CBOID_�v�Z�敪 As Short = 45 ' �v�Z�敪
    Public Const GC_CBOID_�ۂߒP�� As Short = 46 ' �ۂߋ敪
    Public Const GC_CBOID_ZD���_�S�� As Short = 61 ' �y�c���(�S��)
    Public Const GC_CBOID_ZDSD�}�X�^_���� As Short = 62 ' �y�c�r�c�}�X�^(����)
    Public Const GC_CBOID_ZD��� As Short = 63 ' �y�c���
    Public Const GC_CBOID_ZDSD�}�X�^_���� As Short = 64 ' �y�c�r�c�}�X�^(����)
    Public Const GC_CBOID_ZDSD�}�X�^_���_ As Short = 66 ' �y�c�r�c�}�X�^(���_)
    Public Const GC_CBOID_��ʈᔽ�}�X�^ As Short = 67 ' ��ʈᔽ�}�X�^
    Public Const GC_CBOID_�ᔽ���ރ}�X�^ As Short = 68 ' �ᔽ���ރ}�X�^
    Public Const GC_CBOID_�񍐏���� As Short = 71 ' �񍐏��敪
    '==    �����Z�~���R���{���珜�����ߒǉ��@2013/09/25
    Public Const GC_CBOID_�t�@�[�X�g_2 As Short = 72 ' �t�@�[�X�g_�g�p�L��
    Public Const GC_CBOID_��ރR�[�h As Short = 101 ' ��ރR�[�h
    Public Const GC_CBOID_�󋵃R�[�h As Short = 102 ' �󋵃R�[�h
    Public Const GC_CBOID_���Ћ敪 As Short = 104 ' ���Ћ敪
    Public Const GC_CBOID_���ʎ蓖�敪 As Short = 105 ' ���ʎ蓖�敪
    Public Const GC_CBOID_SD�o�΋敪 As Short = 106 ' �r�c�o�΋敪
    Public Const GC_CBOID_�`�F�b�N���� As Short = 107 ' �`�F�b�N����
    Public Const GC_CBOID_���q�ی������敪 As Short = 120 ' ���q�ی������敪
    Public Const GC_CBOID_�ΑӃR�[�h_���� As Short = 122 ' �ΑӋ敪(����)
    Public Const GC_CBOID_�Ζ��ǎ��ԃ}�X�^ As Short = 199 ' �Ζ��ǎ��ԃ}�X�^
    Public Const GC_CBOID_�萔���v�Z�敪 As Short = 200 ' �萔���v�Z�敪
    Public Const GC_CBOID_�n�C���[�`�F�b�N As Short = 201 ' �n�C���[�`�F�b�N
    Public Const GC_CBOID_�Ύ��Y����R�[�h As Short = 285 ' �Ύ��Y����R�[�h
    Public Const GC_CBOID_��ЃR�[�h As Short = 286 ' ��ЃR�[�h(�S��)
    Public Const GC_CBOID_�����R�[�h_�c�Ə� As Short = 287 ' �����R�[�h(�c�Ə���)
    Public Const GC_CBOID_�����R�[�h_�^�� As Short = 288 ' �����R�[�h(�^��)
    Public Const GC_CBOID_�n�C���[�敪 As Short = 290 ' �n�C���[�敪
    Public Const GC_CBOID_�_��`�� As Short = 291 ' �_��`��
    Public Const GC_CBOID_����U���敪 As Short = 292 ' ����U��
    Public Const GC_CBOID_����敪 As Short = 293 ' ����敪
    Public Const GC_CBOID_�őΏ� As Short = 295 ' �őΏ�
    Public Const GC_CBOID_�Œʒm As Short = 296 ' �Œʒm
    Public Const GC_CBOID_�^�ǋΑӃR�[�h As Short = 297 ' �^�ǋΑӃR�[�h
    Public Const GC_CBOID_���i�啪�ރR�[�h As Short = 298 ' ���i�啪�ރR�[�h
    Public Const GC_CBOID_��ЃR�[�h_�^�� As Short = 299 ' ��ЃR�[�h(�^��)
    Public Const GC_CBOID_��ЃR�[�h_�^�N�V�[ As Short = 300 ' ��ЃR�[�h(�^�N�V�[)
    Public Const GC_CBOID_�Ύ��Y��ЃR�[�h As Short = 301 ' �Ύ��Y��ЃR�[�h
    Public Const GC_CBOID_�����R�[�h_�c�Ə�_���� As Short = 302 ' �����R�[�h(�c�Ə��E����)
    Public Const GC_CBOID_��ЃR�[�h_�]�ƈ� As Short = 303 ' ��ЃR�[�h(�]�ƈ��Ǘ�)
    Public Const GC_CBOID_�U�����ЃR�[�h_�^�� As Short = 304 ' �U�����ЃR�[�h(�^��)
    Public Const GC_CBOID_�R���敪 As Short = 305 ' �R���敪
    Public Const GC_CBOID_��ЃR�[�h_�V���g�� As Short = 306 ' ��ЃR�[�h(�V���g��)
    Public Const GC_CBOID_�ڍ׏󋵃R�[�h As Short = 307 ' �ڍ׏󋵃R�[�h
    Public Const GC_CBOID_�����敪_MK�N���W�b�g As Short = 308 ' �����敪(�G���P�C�N���W�b�g)
    Public Const GC_CBOID_MK�敪 As Short = 309 ' �l�j�敪
    Public Const GC_CBOID_��ЃR�[�h_ZDSD As Short = 310 ' ��ЃR�[�h(�y�c�r�c)
    Public Const GC_CBOID_ZD���_�c�Ə� As Short = 311 ' �y�c���(�c�Ə�)
    Public Const GC_CBOID_�p�r�敪 As Short = 312 ' �p�r�敪
    Public Const GC_CBOID_�T�C�Y�敪 As Short = 313 ' �T�C�Y�敪
    Public Const GC_CBOID_�������� As Short = 314 ' ��������
    Public Const GC_CBOID_��ЃR�[�h_�斱���䒠 As Short = 315 ' ��ЃR�[�h(�斱���䒠)
    Public Const GC_CBOID_�^�N�V�[�n�C���[�敪 As Short = 316 ' �^�N�V�[�n�C���[�敪
    Public Const GC_CBOID_�ݕt���ڃR�[�h As Short = 317 ' �ݕt���ڃR�[�h
    Public Const GC_CBOID_���R�[�h�敪 As Short = 318 ' ���R�[�h�敪
    Public Const GC_CBOID_��ЃR�[�h_�Z�~�n�C�� As Short = 319 ' ��ЃR�[�h(��ʲ�)
    Public Const GC_CBOID_�w���ꏊ�R�[�h As Short = 320 ' �w���ꏊ�R�[�h
    Public Const GC_CBOID_���Ɨp�Ԏ�R�[�h As Short = 321 ' ���Ɨp�Ԏ�R�[�h
    Public Const GC_CBOID_�w���ē��� As Short = 322 ' �w���ē���
    Public Const GC_CBOID_�w���ē���_�S�W�ȊO As Short = 323 ' �w���ē���(�S�W�ȊO)
    Public Const GC_CBOID_�w���ē���_�S�W�ċ��K�ȊO As Short = 324 ' �w���ē���(�S�W�ċ��K�ȊO)
    Public Const GC_CBOID_����Ζ��p�^�[�� As Short = 325 ' ����Ζ��p�^�[��(2014/01/27)
    Public Const GC_CBOID_�@�x�Ǘ��敪 As Short = 326 ' �@�x�Ǘ��敪 2018/02
    Public Const GC_CBOID_���x�敪 As Short = 327 ' ���x�敪 2019/07/22
    Public Const GC_CBOID_�^�ǋΑӃR�[�h_�x�� As Short = 328 ' ���x�敪 2019/07/22
    '******************************************************************************
    ' �� �� ��  : gsubSetComboItem
    ' �X�R�[�v  :
    ' �������e  : �R���{�{�b�N�X�ɃA�C�e����ݒ�
    ' ��    �l  :
    ' �� �� �l  :
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjTarget          ComboBox          O     �ݒ�Ώ�
    '   plngItemNo          Long              I     �A�C�e��No.
    '   pobjDB              Object            O     �f�[�^�x�[�X�I�u�W�F�N�g
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   02.01.00    2008/05/21  �A��  �F��         �U�����ЃR�[�h(�^��)�̒ǉ�
    '   02.02.00    2009/12/10  �A��  �F��         ���Ɨp�Ԏ�R�[�h�̒ǉ�
    '   02.03.00    2010/06/21  �A��  �F��         �w���ē��ނ̒ǉ�
    '
    '******************************************************************************
    Public Sub gsubSetComboItem(ByRef pobjTarget As Object, ByVal plngItemNo As Integer, ByRef pobjDB As Object)

        Dim strSQL As String
        Dim objDysCboSet As Object

        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.Clear. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
        'Call pobjTarget.Clear()
        Call pobjTarget.Items.Clear()
        pobjTarget.Text = String.Empty
        '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

        Select Case plngItemNo
            '--------------------------------------------------------------------------
            ' �����R�[�h(�S��)
            '--------------------------------------------------------------------------
            Case GC_CBOID_�����R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "
                strSQL = strSQL & Chr(10) & "   ,������     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h <> '" & GC_DEF_�σo�X_��� & "' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�����R�[�h").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("������").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �����i�^�s�Ǘ��j
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����R�[�h_�^��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "
                strSQL = strSQL & Chr(10) & "   ,������     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                ' �敪�S(�^�s�Ǘ��i�h���j����)���O�ȊO
                strSQL = strSQL & Chr(10) & "    NVL(�敪�S,0) <> 0 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�����R�[�h").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("������").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ����(�c�Ə��� ����)
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����R�[�h_�c�Ə�_����

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "
                strSQL = strSQL & Chr(10) & "   ,���������� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h IS NOT NULL "
                strSQL = strSQL & Chr(10) & "AND �c�Ƌ敪 = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�����R�[�h").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("����������").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �����R�[�h(�c�Ə�)
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����R�[�h_�c�Ə�

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "
                strSQL = strSQL & Chr(10) & "   ,������     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �c�Ƌ敪 = '1' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �����R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�����R�[�h").Value & Space(GC_LEN_POST_CODE), 1, GC_LEN_POST_CODE) & GC_COMBO_SPLIT & .Fields("������").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �ΑӋ敪(�S��)
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ΑӃR�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,�ΑӖ�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ΑӃ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�ΑӃR�[�h").Value & Space(GC_LEN_WORK_KBN), 1, GC_LEN_WORK_KBN) & GC_COMBO_SPLIT & .Fields("�ΑӖ�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �[�U��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�[�U���R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �[�U���R�[�h "
                strSQL = strSQL & Chr(10) & "   ,����         "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �k�o�f�[�U���}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �[�U���R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�[�U���R�[�h").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("����").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �F�΋敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�F�΋敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ΏۊO")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�Ώ�")
                '--------------------------------------------------------------------------
                ' �@�x�Ǘ��敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�@�x�Ǘ��敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ΏۊO")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�Ώ�")

                '--------------------------------------------------------------------------
                ' ���x�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���x�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�Ȃ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "���x����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("9" & GC_COMBO_SPLIT & "�����x����")

                '--------------------------------------------------------------------------
                ' �o���敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�o���敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�o��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�x��")

                '--------------------------------------------------------------------------
                ' ����
                '--------------------------------------------------------------------------
            Case GC_CBOID_����

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0 " & GC_COMBO_SPLIT & "�o��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1 " & GC_COMBO_SPLIT & "���x")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2 " & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3 " & GC_COMBO_SPLIT & "�c��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4 " & GC_COMBO_SPLIT & "�x��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5 " & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6 " & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7 " & GC_COMBO_SPLIT & "�L�x")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8 " & GC_COMBO_SPLIT & "���o")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("51" & GC_COMBO_SPLIT & "�L���\��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("52" & GC_COMBO_SPLIT & "���o�\��")

                '--------------------------------------------------------------------------
                ' �Ζ��敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�Ζ��敪

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �R�[�h   "
                strSQL = strSQL & Chr(10) & "   ,���̊��� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ���� = '�Ζ��敪' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(�R�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(���̊���).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(gfncFieldVal(.Fields("�R�[�h").Value) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("���̊���").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���q�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���q�敪

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���q�敪                      "
                strSQL = strSQL & Chr(10) & "  , MIN(���q�敪��) AS ���q�敪�� "
                strSQL = strSQL & Chr(10) & "FROM  "
                strSQL = strSQL & Chr(10) & "    ���q�敪�}�X�^ "
                strSQL = strSQL & Chr(10) & "GROUP BY "
                strSQL = strSQL & Chr(10) & "    ���q�敪   "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���q�敪   "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���q�敪").Value & Space(GC_LEN_CAR_KBN), 1, GC_LEN_CAR_KBN) & GC_COMBO_SPLIT & .Fields("���q�敪��").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �t�@�[�X�g
                '--------------------------------------------------------------------------
            Case GC_CBOID_�t�@�[�X�g

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
                strSQL = strSQL & Chr(10) & "    �t�@�[�X�g   "
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g�� "
                strSQL = strSQL & Chr(10) & "FROM  "
                strSQL = strSQL & Chr(10) & "    �t�@�[�X�g�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �t�@�[�X�g "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�t�@�[�X�g").Value & Space(GC_LEN_FIRST_KBN), 1, GC_LEN_FIRST_KBN) & GC_COMBO_SPLIT & .Fields("�t�@�[�X�g��").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With


                '-------------------------------------------------------------------------------
                ' �t�@�[�X�g �g�p�L���敪�ǉ��@ �����Z�~���R���{���珜�����ߒǉ��@2013/09/25
                '-------------------------------------------------------------------------------
            Case GC_CBOID_�t�@�[�X�g_2

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
                strSQL = strSQL & Chr(10) & "    �t�@�[�X�g   "
                strSQL = strSQL & Chr(10) & "   ,�t�@�[�X�g�� "
                strSQL = strSQL & Chr(10) & "FROM  "
                strSQL = strSQL & Chr(10) & "    �t�@�[�X�g�}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE  "
                strSQL = strSQL & Chr(10) & "    �ғ��䐔�\���L���敪 = 1  "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �t�@�[�X�g "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�t�@�[�X�g").Value & Space(GC_LEN_FIRST_KBN), 1, GC_LEN_FIRST_KBN) & GC_COMBO_SPLIT & .Fields("�t�@�[�X�g��").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With



                '--------------------------------------------------------------------------
                ' ��ԋ敪�i���q��ԁj
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ԋ敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ғ��\")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�C����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' ���q�ԍ��n��R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_���q�ԍ��n��R�[�h

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    ���q�ԍ��n��R�[�h "
                strSQL = strSQL & "   ,���q�ԍ��n�於     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ���q�ԍ��n��}�X�^ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    ���q�ԍ��n��R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���q�ԍ��n��R�[�h").Value & Space(GC_LEN_CAR_DISTRICT_CODE), 1, GC_LEN_CAR_DISTRICT_CODE) & GC_COMBO_SPLIT & .Fields("���q�ԍ��n�於").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �������
                '--------------------------------------------------------------------------
            Case GC_CBOID_�������

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�ƒ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "���̑�")

                '--------------------------------------------------------------------------
                ' �����ҏW��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����ҏW��

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�o��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' �a�@�R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�a�@�R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �a�@�R�[�h "
                strSQL = strSQL & Chr(10) & "   ,�a�@��     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �a�@�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �a�@�R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�a�@�R�[�h").Value & Space(GC_LEN_HOSPITAL_CODE), 1, GC_LEN_HOSPITAL_CODE) & GC_COMBO_SPLIT & .Fields("�a�@��").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �s���{��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�s���{��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���̊��� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ����      = '�s���{��' "
                strSQL = strSQL & Chr(10) & "AND ���̊��� IS NOT NULL   "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(.Fields("���̊���").Value)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �����敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����敪

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �����敪   "
                strSQL = strSQL & Chr(10) & "   ,�����敪�� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����敪�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(�����敪) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�����敪").Value & Space(GC_LEN_MISYUU_KBN), 1, GC_LEN_MISYUU_KBN) & GC_COMBO_SPLIT & .Fields("�����敪��").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �����敪(�G���P�C�N���W�b�g)
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����敪_MK�N���W�b�g

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �����敪   "
                strSQL = strSQL & Chr(10) & "   ,�����敪�� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����敪�}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                ' �U���敪���O(�`�P�b�g)
                strSQL = strSQL & Chr(10) & "    �U���敪       = " & CStr(GC_KBN_�U��_�`�P�b�g) & " "
                ' �萔�����ݒ�悪�O(�l�j���)
                strSQL = strSQL & Chr(10) & "AND �萔�����ݒ�� = " & CStr(GC_�萔�����ݒ��_MK���) & " "
                ' ���X�g�W�v�敪���R(�G���P�C�N���W�b�g)
                strSQL = strSQL & Chr(10) & "AND ���X�g�W�v�敪 = 3 "
                ' �����R�[�h�敪���P(���͉�)
                strSQL = strSQL & Chr(10) & "AND �����R�[�h�敪 = " & CStr(GC_KBN_�����R�[�h_���͉�) & " "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(�����敪) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�����敪").Value & Space(GC_LEN_MISYUU_KBN), 1, GC_LEN_MISYUU_KBN) & GC_COMBO_SPLIT & .Fields("�����敪��").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �斱�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�斱�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�{��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�㖱")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�x��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "���K")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "���̑�")

                '--------------------------------------------------------------------------
                ' ��s
                '--------------------------------------------------------------------------
            Case GC_CBOID_��s�R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��s�R�[�h "
                strSQL = strSQL & Chr(10) & "   ,��s������ "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��s�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ��s�R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("��s�R�[�h").Value & Space(GC_LEN_BANK_CODE), 1, GC_LEN_BANK_CODE) & GC_COMBO_SPLIT & .Fields("��s������").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �U���敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�U���敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�`�P�b�g")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "������")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "�����񐔌�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "�g��Ҋ�����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5" & GC_COMBO_SPLIT & "��Q�ҏ�Ԍ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "���Ј�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "���̑�")

                '--------------------------------------------------------------------------
                ' ���͋敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���͋敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���͕s��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "���͉�")

                '--------------------------------------------------------------------------
                ' �萔�����ݒ��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�萔�����ݒ��

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�l�j����}�X�^")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�]�ƈ��}�X�^")

                '--------------------------------------------------------------------------
                ' ����
                '--------------------------------------------------------------------------
            Case GC_CBOID_����

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_����_�j) & GC_COMBO_SPLIT & "�j")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_����_��) & GC_COMBO_SPLIT & "��")

                '--------------------------------------------------------------------------
                ' ���t�^
                '--------------------------------------------------------------------------
            Case GC_CBOID_���t�^

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�`")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�a")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�n")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "AB")

                '--------------------------------------------------------------------------
                ' �o���A�ٗp�ی������A�ǒ��蓖�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�L���敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�L��")

                '--------------------------------------------------------------------------
                ' ���Ƌ敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���Ƌ敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' �}�C�J�[�ʋ΋敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�}�C�J�[�ʋ΋敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���Ȃ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' ��E��
                '--------------------------------------------------------------------------
            Case GC_CBOID_��E��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �R�[�h   "
                strSQL = strSQL & Chr(10) & "   ,���̊��� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ���� = '��E��' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(�R�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�R�[�h").Value & Space(GC_LEN_OFFICIAL_POSITION), 1, GC_LEN_OFFICIAL_POSITION) & GC_COMBO_SPLIT & .Fields("���̊���").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���K�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���K�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ΏۊO")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�{���E���K")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "���K")

                '--------------------------------------------------------------------------
                ' �����敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ʏ�Ζ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "������")

                '--------------------------------------------------------------------------
                ' �ŋ敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ŋ敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�b��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' �{���㖱�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�{���㖱�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�{��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�㖱")

                '--------------------------------------------------------------------------
                ' �V�X�e������
                '--------------------------------------------------------------------------
            Case GC_CBOID_�V�X�e������

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���[�U�[")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�Ǘ���")

                '--------------------------------------------------------------------------
                ' �ΑӋ敪�i�����ΑӃR�[�h�j
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����ΑӃR�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,�ΑӖ�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ΑӃ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ���� = 6 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�ΑӃR�[�h").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("�ΑӖ�").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �ސE�R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ސE�R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �ސE�R�[�h "
                strSQL = strSQL & Chr(10) & "   ,�ސE���R   "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ސE���R�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ސE�R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�ސE�R�[�h").Value & Space(GC_LEN_RESIGNATION_CODE), 1, GC_LEN_RESIGNATION_CODE) & GC_COMBO_SPLIT & .Fields("�ސE���R").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �}�{�`���敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�}�{�`���敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�L")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��")

                '--------------------------------------------------------------------------
                ' �����敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�����敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_���ʋ�_����) & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_���ʋ�_�ʋ�) & GC_COMBO_SPLIT & "�ʋ�")

                '--------------------------------------------------------------------------
                ' �u�`�R�[�h�i�S�āj
                '--------------------------------------------------------------------------
            Case GC_CBOID_�u�`�R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �u�`�R�[�h "
                strSQL = strSQL & Chr(10) & "   ,�u�`��     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �u�`�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �u�`�R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�u�`�R�[�h").Value & Space(3), 1, 3) & GC_COMBO_SPLIT & .Fields("�u�`��").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �j��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�j��

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5" & GC_COMBO_SPLIT & "��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "�y")

                '--------------------------------------------------------------------------
                ' �v�Z�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�v�Z�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�؎̂�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�؏グ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�l�̌ܓ�")

                '--------------------------------------------------------------------------
                ' �ۂߒP��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ۂߒP��

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��~�P��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�\�~�P��")

                '--------------------------------------------------------------------------
                ' �y�c��ʁi�S�āj
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZD���_�S��

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��ʈᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�Г����[���ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "�g�����Ȃ݈ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("5" & GC_COMBO_SPLIT & "���_")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&�ό����[���ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "�O�����~�X���|�[�g")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "���̑�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("9" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' �y�c�r�c�}�X�^�i���_�j
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZDSD�}�X�^_���_

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���e�敪 "
                strSQL = strSQL & Chr(10) & "   ,���e     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �y�c�r�c�}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �y�c��� = 5 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���e�敪 "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���e�敪").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("���e").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �y�c�r�c�}�X�^�i���́j
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZDSD�}�X�^_����

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���e�敪 "
                strSQL = strSQL & Chr(10) & "   ,���e     "
                strSQL = strSQL & Chr(10) & "   ,�_��     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �y�c�r�c�}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �y�c��� = 3 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���e�敪 "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���e�敪").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & Mid(.Fields("���e").Value & Space(20), 1, 20) & GC_COMBO_SPLIT & VB6.Format(.Fields("�_��").Value, "#0")))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �y�c��ʁi���A��ʈᔽ�A�Г��ᔽ�j
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZD���

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��ʈᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�Г����[���ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "�g�����Ȃ݈ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&�ό����[���ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "�O�����~�X���|�[�g")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "���̑�")

                '--------------------------------------------------------------------------
                ' �񍐏����
                '--------------------------------------------------------------------------
            Case GC_CBOID_�񍐏����

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("01" & GC_COMBO_SPLIT & "�Г����[���E��ʃ��[���E�}�i�[�ᔽ�񍐏�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("02" & GC_COMBO_SPLIT & "�����񍐏�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("03" & GC_COMBO_SPLIT & "�����񍐏�")

                '--------------------------------------------------------------------------
                ' ��ރR�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ރR�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ރR�[�h "
                strSQL = strSQL & Chr(10) & "   ,��ޖ�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��ރ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ��ރR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("��ރR�[�h").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("��ޖ�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �󋵃R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�󋵃R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �󋵃R�[�h "
                strSQL = strSQL & Chr(10) & "   ,�󋵖�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �󋵃}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �󋵃R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�󋵃R�[�h").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("�󋵖�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���Ћ敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���Ћ敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�V�K����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�� �� ��")

                '--------------------------------------------------------------------------
                ' ���ʎ蓖�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���ʎ蓖�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_���ʎ蓖�x��_�Ȃ�) & GC_COMBO_SPLIT & "�x���Ȃ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_���ʎ蓖�x��_����) & GC_COMBO_SPLIT & "�x������")

                '--------------------------------------------------------------------------
                ' �r�c�o�΋敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_SD�o�΋敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ΏۊO")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�Ώ�")

                '--------------------------------------------------------------------------
                ' ����
                '--------------------------------------------------------------------------
            Case GC_CBOID_�`�F�b�N����

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �R�[�h   "
                strSQL = strSQL & Chr(10) & "   ,���̊��� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ���� = '�`�F�b�N����' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(�R�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(���̊���).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(gfncFieldVal(.Fields("�R�[�h").Value) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("���̊���").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���q�ی������敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���q�ی������敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ʏ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "3����4�{")

                '--------------------------------------------------------------------------
                ' �ΑӋ敪(����)
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ΑӃR�[�h_����

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "
                strSQL = strSQL & Chr(10) & "  , �Αӗ��̂P "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ΑӃ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(�Αӗ��̂P).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("�ΑӃR�[�h").Value) & Space(GC_LEN_WORK_KBN), 1, GC_LEN_WORK_KBN) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("�Αӗ��̂P").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �Ζ��ǎ��ԃ}�X�^
                '--------------------------------------------------------------------------
            Case GC_CBOID_�Ζ��ǎ��ԃ}�X�^

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �Ζ��ǎ��ԃR�[�h                  "
                strSQL = strSQL & Chr(10) & "  , MAX(�Ζ��ǎ��Ԗ�) AS �Ζ��ǎ��Ԗ� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �Ζ��ǎ��ԃ}�X�^ "
                strSQL = strSQL & Chr(10) & "GROUP BY "
                strSQL = strSQL & Chr(10) & "    �Ζ��ǎ��ԃR�[�h "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �Ζ��ǎ��ԃR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(�Ζ��ǎ��Ԗ�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(gfncFieldVal(.Fields("�Ζ��ǎ��ԃR�[�h").Value) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("�Ζ��ǎ��Ԗ�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �萔���v�Z�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�萔���v�Z�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ʏ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�ō�")

                '--------------------------------------------------------------------------
                ' �n�C���[�`�F�b�N
                '--------------------------------------------------------------------------
            Case GC_CBOID_�n�C���[�`�F�b�N

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�`�F�b�N�Ȃ�")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�`�F�b�N����")

                '--------------------------------------------------------------------------
                ' �Ύ��Y����R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�Ύ��Y����R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ����R�[�h�P || "
                strSQL = strSQL & Chr(10) & "    ����R�[�h�Q || "
                strSQL = strSQL & Chr(10) & "    ����R�[�h�R AS ����R�[�h "
                strSQL = strSQL & Chr(10) & "   ,���喼�P     || "
                strSQL = strSQL & Chr(10) & "    ���喼�Q     || "
                strSQL = strSQL & Chr(10) & "    ���喼�R     AS ���喼     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �Ύ��Y����}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ����R�[�h�P "
                strSQL = strSQL & Chr(10) & "   ,����R�[�h�Q "
                strSQL = strSQL & Chr(10) & "   ,����R�[�h�R "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("����R�[�h").Value & Space(GC_LEN_KINJIRO_BUMON_ALL), 1, GC_LEN_KINJIRO_BUMON_ALL) & GC_COMBO_SPLIT & Trim(.Fields("���喼").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �_��`��
                '--------------------------------------------------------------------------
            Case GC_CBOID_�_��`��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �_��`��   "
                strSQL = strSQL & Chr(10) & "   ,�_��`�Ԗ� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �_��`�ԃ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �_��`�� "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�_��`��").Value & Space(GC_LEN_CONTRACT_TYPE), 1, GC_LEN_CONTRACT_TYPE) & GC_COMBO_SPLIT & .Fields("�_��`�Ԗ�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ����U��
                '--------------------------------------------------------------------------
            Case GC_CBOID_����U���敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_����U��_���� & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_����U��_���֕t�ѕ� & GC_COMBO_SPLIT & "����(�t�ѕ�)")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_����U��_���� & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_����U��_���̑� & GC_COMBO_SPLIT & "���̑�")
                '++�C���J�n�@2023�N09��12��:MK�i��j- VB��VB.NET�ϊ�
                Call pobjTarget.Items.Add(GC_KBN_����U��_�d�� & GC_COMBO_SPLIT & "�d��")
                Call pobjTarget.Items.Add(GC_KBN_����U��_�d���t�ѕ� & GC_COMBO_SPLIT & "�d���t�ѕ�")
                '--�C���J�n�@2023�N09��12��:MK�i��j- VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                ' ����敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_����敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_����_���� & GC_COMBO_SPLIT & "����")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(GC_KBN_����_���O & GC_COMBO_SPLIT & "���O")

                '--------------------------------------------------------------------------
                ' �őΏ�
                '--------------------------------------------------------------------------
            Case GC_CBOID_�őΏ�

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�ΏۊO")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�Ώ�")

                '--------------------------------------------------------------------------
                ' �Œʒm
                '--------------------------------------------------------------------------
            Case GC_CBOID_�Œʒm

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�O��")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("3" & GC_COMBO_SPLIT & "����")

                '--------------------------------------------------------------------------
                ' �^�ǋΑӃR�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�^�ǋΑӃR�[�h, GC_CBOID_�^�ǋΑӃR�[�h_�x��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,�Αӗ���   "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �^�ǋΑӃ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                If plngItemNo = GC_CBOID_�^�ǋΑӃR�[�h Then
                    strSQL = strSQL & Chr(10) & "    �^�ǋ敪 = 1 "
                ElseIf plngItemNo = GC_CBOID_�^�ǋΑӃR�[�h_�x�� Then '2023/03/06 �x���ǉ�
                    strSQL = strSQL & Chr(10) & "    �x���敪 = 1 "
                End If
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ΑӃR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�ΑӃR�[�h").Value & Space(GC_LEN_WORK_KBN), 1, GC_LEN_WORK_KBN) & GC_COMBO_SPLIT & .Fields("�Αӗ���").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���i�啪��
                '--------------------------------------------------------------------------
            Case GC_CBOID_���i�啪�ރR�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���i�啪�ރR�[�h "
                strSQL = strSQL & Chr(10) & "   ,���i�啪�ޖ�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ���i�啪�ރ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ���i�敪 = '2' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���i�啪�ރR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���i�啪�ރR�[�h").Value & Space(GC_LEN_COMMODITY_BIG_GROUP), 1, GC_LEN_COMMODITY_BIG_GROUP) & GC_COMBO_SPLIT & .Fields("���i�啪�ޖ�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�S�āj
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    ��ЃR�[�h "
                strSQL = strSQL & "   ,��Ж�     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ��Ѓ}�X�^ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�^�s�Ǘ��j
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_�^��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,��Ж�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��Ѓ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �敪�P = " & GC_FLG_ON & " "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("��ЃR�[�h").Value & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & .Fields("��Ж�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�^�N�V�[�j
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_�^�N�V�[

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,��Ж�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��Ѓ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �敪�Q = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        '++�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�
                        'Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))
                        '--�C���J�n�@2021�N05��30��:MK�i��j- VB��VB.NET�ϊ�

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�斱���䒠�j
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_�斱���䒠

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,��Ж�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��Ѓ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �敪�X = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�]�ƈ��j
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_�]�ƈ�

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,��Ж�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��Ѓ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �敪�S = 1 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�Ύ��Y�j
                '--------------------------------------------------------------------------
            Case GC_CBOID_�Ύ��Y��ЃR�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,��Ж�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �Ύ��Y��Ѓ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�y�c�r�c�Ǘ��j
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_ZDSD

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    ��ЃR�[�h "
                strSQL = strSQL & "   ,��Ж�     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ��Ѓ}�X�^ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    �敪�T = 1 "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �U�����ЃR�[�h�i�^�ǁj
                '--------------------------------------------------------------------------
            Case GC_CBOID_�U�����ЃR�[�h_�^��

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ЃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,�U���於�` "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��Ѓ}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �U���於�` IS NOT NULL "
                ' �^�s�Ǘ����L���t���O��(1�F�L)�̉��
                strSQL = strSQL & Chr(10) & "AND �敪�P = '1' "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(�U���於�`).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("�U���於�`").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��Ёi�V���g���j
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_�V���g��

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    ��ЃR�[�h "
                strSQL = strSQL & "   ,��Ж�     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ��Ѓ}�X�^ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    �敪�R = 1 "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �ڍ׏󋵃R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ڍ׏󋵃R�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    �ڍ׏󋵃R�[�h "
                strSQL = strSQL & Chr(10) & "   ,�ڍ׏󋵖�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ڍ׏󋵃}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ڍ׏󋵃R�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        pobjTarget.Items.Add(CStr(Mid(.Fields("�ڍ׏󋵃R�[�h").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("�ڍ׏󋵖�").Value))
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �l�j�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_MK�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "�l�j�ȊO")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "�l�j")

                '--------------------------------------------------------------------------
                ' ��ʈᔽ�}�X�^
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ʈᔽ�}�X�^

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ��ʈᔽ�R�[�h "
                strSQL = strSQL & Chr(10) & "   ,��ʈᔽ��     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ��ʈᔽ�}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ��ʈᔽ���J�i, "
                strSQL = strSQL & Chr(10) & "    ��ʈᔽ�R�[�h  "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("��ʈᔽ�R�[�h").Value & Space(3), 1, 3) & GC_COMBO_SPLIT & .Fields("��ʈᔽ��").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �y�c�r�c�}�X�^�i�����j
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZDSD�}�X�^_����

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���e�敪 "
                strSQL = strSQL & Chr(10) & "   ,���e     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �y�c�r�c�}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �y�c��� = 9 "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���e�敪 "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���e�敪").Value & Space(2), 1, 2) & GC_COMBO_SPLIT & .Fields("���e").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �y�c��ʁi�c�Ə��j
                '--------------------------------------------------------------------------
            Case GC_CBOID_ZD���_�c�Ə�

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N09��25��:MK�i��j- VB��VB.NET�ϊ�
                'Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&�ό����[���ᔽ")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "�O�����~�X���|�[�g")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��ʈᔽ")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�Г����[���ᔽ")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "�g�����Ȃ݈ᔽ")
                ''UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "���̑�")

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("0" & GC_COMBO_SPLIT & "���")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("1" & GC_COMBO_SPLIT & "��ʈᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("2" & GC_COMBO_SPLIT & "�Г����[���ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("4" & GC_COMBO_SPLIT & "�g�����Ȃ݈ᔽ")
                Call pobjTarget.Items.Add("6" & GC_COMBO_SPLIT & "GPS&�ό����[���ᔽ")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("7" & GC_COMBO_SPLIT & "�O�����~�X���|�[�g")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add("8" & GC_COMBO_SPLIT & "���̑�")
                '--�C���J�n�@2021�N09��25��:MK�i��j- VB��VB.NET�ϊ�

                '--------------------------------------------------------------------------
                ' �ᔽ���ރ}�X�^
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ᔽ���ރ}�X�^

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���ރR�[�h "
                strSQL = strSQL & Chr(10) & "   ,���ޖ�     "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ᔽ���ރ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���ރR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("���ރR�[�h").Value & Space(3), 1, 3) & GC_COMBO_SPLIT & .Fields("���ޖ�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �p�r�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�p�r�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Taxi) & GC_COMBO_SPLIT & "�^�N�V�[")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Hire) & GC_COMBO_SPLIT & "�n�C���[")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Jumbo) & GC_COMBO_SPLIT & "�W�����{")

                '--------------------------------------------------------------------------
                ' �T�C�Y�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�T�C�Y�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_SIZE_SML) & GC_COMBO_SPLIT & "���^")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_SIZE_MID) & GC_COMBO_SPLIT & "���^")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_SIZE_LAR) & GC_COMBO_SPLIT & "��^")

                '--------------------------------------------------------------------------
                ' ��������
                '--------------------------------------------------------------------------
            Case GC_CBOID_��������

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    ���� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �����Ǘ��}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    ���� "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("����").Value & Space(GC_LEN_CLAIM_CLOSING_DAY), 1, GC_LEN_CLAIM_CLOSING_DAY)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �^�N�V�[�n�C���[�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_�^�N�V�[�n�C���[�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Taxi) & GC_COMBO_SPLIT & "�^�N�V�[")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(basCommonConst.genYoto.Hire) & GC_COMBO_SPLIT & "�n�C���[")

                '--------------------------------------------------------------------------
                ' �ݕt���ڃR�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�ݕt���ڃR�[�h

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
                strSQL = strSQL & Chr(10) & "    �ݕt���ڃR�[�h "
                strSQL = strSQL & Chr(10) & "   ,�ݕt���ږ� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �ݕt���ڃ}�X�^ "
                strSQL = strSQL & Chr(10) & "ORDER BY "
                strSQL = strSQL & Chr(10) & "    �ݕt���ڃR�[�h "

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = gobjOraDatabase.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�ݕt���ڃR�[�h").Value & Space(GC_LEN_KASHITUKE_KOUMOKU_CODE), 1, GC_LEN_KASHITUKE_KOUMOKU_CODE) & GC_COMBO_SPLIT & .Fields("�ݕt���ږ�").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���R�[�h�敪
                '--------------------------------------------------------------------------
            Case GC_CBOID_���R�[�h�敪

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_�{�R�[�h) & GC_COMBO_SPLIT & "�{�R�[�h")
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call pobjTarget.Items.Add(CStr(GC_KBN_���R�[�h) & GC_COMBO_SPLIT & "���R�[�h")

                '--------------------------------------------------------------------------
                ' ��Ёi��ʲԁj
                '--------------------------------------------------------------------------
            Case GC_CBOID_��ЃR�[�h_�Z�~�n�C��

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    ��ЃR�[�h "
                strSQL = strSQL & "   ,��Ж�     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ��Ѓ}�X�^ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    NVL(�敪�P�Q,0) = 1 "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(��ЃR�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(��Ж�).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("��ЃR�[�h").Value) & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("��Ж�").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' �w���ꏊ�R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�w���ꏊ�R�[�h

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    �w���ꏊ�R�[�h "
                strSQL = strSQL & "   ,�w���ꏊ��     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ���K�w���ꏊ�}�X�^ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(�w���ꏊ�R�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(�w���ꏊ��).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("�w���ꏊ�R�[�h").Value) & Space(GC_LEN_SITE_CODE), 1, GC_LEN_SITE_CODE) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("�w���ꏊ��").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���Ɨp�Ԏ�R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_���Ɨp�Ԏ�R�[�h

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    �Ԏ�R�[�h "
                strSQL = strSQL & "   ,�Ԏ햼     "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ���Ɨp�Ԏ�}�X�^ "
                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(�Ԏ�R�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(�Ԏ햼).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("�Ԏ�R�[�h").Value) & Space(3), 1, 3) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("�Ԏ햼").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ���Ɨp�Ԏ�R�[�h
                '--------------------------------------------------------------------------
            Case GC_CBOID_�w���ē���, GC_CBOID_�w���ē���_�S�W�ȊO, GC_CBOID_�w���ē���_�S�W�ċ��K�ȊO

                strSQL = ""
                strSQL = strSQL & "SELECT "
                strSQL = strSQL & "    �R�[�h   "
                strSQL = strSQL & "   ,���̊��� "
                strSQL = strSQL & "FROM "
                strSQL = strSQL & "    ���̃}�X�^ "
                strSQL = strSQL & "WHERE "
                strSQL = strSQL & "    ���� = '�w���ē���' "

                Select Case plngItemNo
                    Case GC_CBOID_�w���ē���

                        strSQL = strSQL & "AND BITAND(�W���P,BIN_TO_NUM(0,0,1)) <> 0 "

                    Case GC_CBOID_�w���ē���_�S�W�ȊO

                        strSQL = strSQL & "AND BITAND(�W���P,BIN_TO_NUM(0,1,0)) <> 0 "

                    Case GC_CBOID_�w���ē���_�S�W�ċ��K�ȊO

                        strSQL = strSQL & "AND BITAND(�W���P,BIN_TO_NUM(1,0,0)) <> 0 "

                    Case Else

                        ' �����Ȃ�

                End Select

                strSQL = strSQL & "ORDER BY "
                strSQL = strSQL & "    TO_NUMBER(�R�[�h) "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysCboSet.Fields(���̊���).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(gfncFieldVal(.Fields("�R�[�h").Value) & Space(GC_LEN_SHIDO_KANTOKU_BUNRUI), 1, GC_LEN_SHIDO_KANTOKU_BUNRUI) & GC_COMBO_SPLIT & gfncFieldVal(.Fields("���̊���").Value)))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With
                '--------------------------------------------------------------------------
                ' ����Ζ��p�^�[��(2014/01/27)
                '--------------------------------------------------------------------------
            Case GC_CBOID_����Ζ��p�^�[��

                '// �����l�ɋ󔒍s��ǉ�
                'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '++�C���J�n�@2021�N05��30:MK�i��j- VB��VB.NET�ϊ�
                'Call pobjTarget.Items.Add("")
                Call pobjTarget.Items.Add("")
                '--�C���J�n�@2021�N05��30:MK�i��j- VB��VB.NET�ϊ�

                strSQL = ""
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "     �R�[�h "
                strSQL = strSQL & Chr(10) & "    ,���̊��� "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    ���̃}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    ����      = '����Ζ��p�^�[��' "
                strSQL = strSQL & Chr(10) & "AND ���̊��� IS NOT NULL   "
                strSQL = strSQL & Chr(10) & "ORDER BY �R�[�h   "

                'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objDysCboSet = pobjDB.CreateDynaset(strSQL, &H4)

                With objDysCboSet

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Do Until .EOF = True

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object pobjTarget.AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call pobjTarget.Items.Add(CStr(Mid(.Fields("�R�[�h").Value & Space(GC_LEN_COMPANY_CODE), 1, GC_LEN_COMPANY_CODE) & GC_COMBO_SPLIT & .Fields("���̊���").Value))

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .MoveNext()

                    Loop

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysCboSet.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End With

                '--------------------------------------------------------------------------
                ' ��L�ȊO
                '--------------------------------------------------------------------------
            Case Else

                ' �����Ȃ�

        End Select

        Call gsubClearObject(objDysCboSet)

    End Sub
End Module