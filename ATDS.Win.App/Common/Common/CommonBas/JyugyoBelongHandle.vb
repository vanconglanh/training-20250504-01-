Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basJyugyoBelongHandle
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : JyugyoBelongHandle.bas
    ' ��    �e    : �]�ƈ��̕t���}�X�^(�Ƒ��E��ʐ^�E�������i�E�Ƌ�)���X�V���� ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncJyugyoBelongHandle             (�]�ƈ��̕t���}�X�^�̍X�V)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/06  KSR                �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    ' �g���q
    Private Const MC_TEMP_FILE As String = ".JPG"
    Private Const MC_TEMP_BUFF_SIZE As Integer = 10240 ' �o�b�t�@�T�C�Y

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    Private mstrTempPath As String ' �e���|�����t�@�C���ւ̃p�X


    '******************************************************************************
    ' �� �� ��  : gfncJyugyoBelongHandle
    ' �X�R�[�v  : Public
    ' �������e  : �]�ƈ��̕t���}�X�^�̍X�V
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrNewEmployeeCD   String            I     �V�]�ƈ��R�[�h
    '   pstrOldEmployeeCD   String            I     ���]�ƈ��R�[�h
    '   pstrEmployeeCD      String            I/O   �X�V�]�ƈ��R�[�h
    '   pstrProgramID       String            I/O   �X�V�v���O����
    '   pblnFlgMsg          Boolean           I     ���b�Z�[�W�o�͗L��
    '                                                 True  : ���b�Z�[�W�o�͗L
    '                                                 False : ���b�Z�[�W�o�͖�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/06  KSR                �V�K�쐬
    '   01.02       2023/06/26  TSS                �]�ƈ��Ƒ��}�X�^�Ɏ������ڒǉ�
    '
    '******************************************************************************
    Public Function gfncJyugyoBelongHandle(ByRef pstrNewEmployeeCD As String, ByRef pstrOldEmployeeCD As String, ByRef pstrEmployeeCD As String, ByVal pstrProgramID As String, Optional ByVal pblnFlgMsg As Boolean = True) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Dim strSQL As String
        Dim objDysTemp As OraDynaset
        Dim lngReadPosi As Integer ' �Ǎ��݈ʒu
        Dim intFileNum As Short ' �t�@�C���ԍ�
        Dim dblReadSize As Double ' �Ǎ��񂾃f�[�^�T�C�Y
        Dim abytReadBuff() As Byte ' �Ǎ��݃o�b�t�@
        Dim lngTotalSize As Integer ' �f�[�^�̃T�C�Y
        Dim intWritePosi As Short ' ���[�v�J�E���^
        Dim intNumChunks As Short '
        Dim abytWriteBuff() As Byte ' �����݃o�b�t�@
        Dim dblWriteSize As Double ' �����ރf�[�^�T�C�Y
        Dim pstrSearchItem() As String
        Dim pstrSearchKey() As String
        Dim str��ʐ^ As String
        Dim str�ʐ^�B�e�� As String
        Dim clsSysDate As clsSystemDate
        Dim objFso As Scripting.FileSystemObject
        Const C_NAME_FUNCTION As String = "gfncJyugyoBelongHandle"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


            '�߂�l������
            gfncJyugyoBelongHandle = False


            '--------------------------------------------------------------------------
            ' �����o�ϐ� �ݒ�
            '--------------------------------------------------------------------------
            ' �V�X�e���̃e���v���[�g�t�H���_��������Ȃ��ꍇ
            If gfncGetSHFolderPath(CSIDL_TEMPLATES, mstrTempPath) <> S_OK Then

                mstrTempPath = "C:\Temp\"

                ' �f�B���N�g�������݂��Ȃ��ꍇ
                If gfncCheckFileExists(mstrTempPath) = False Then

                    ' �e���v���[�g�t�H���_���쐬
                    objFso = New Scripting.FileSystemObject

                    Call objFso.CreateFolder(mstrTempPath)

                End If

            Else

                mstrTempPath = mstrTempPath & "\"

            End If


            ' �o�^�m�F�i�]�ƈ��Ƒ��}�X�^�j
            ReDim pstrSearchItem(0) : pstrSearchItem(0) = "�]�ƈ��R�[�h"
            ReDim pstrSearchKey(0) : pstrSearchKey(0) = pstrOldEmployeeCD
            If gfncGetTableHandle("�]�ƈ��Ƒ��}�X�^", pstrSearchItem, pstrSearchKey, objDysTemp, True) = True Then
                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
            End If

            ' �]�ƈ��Ƒ��}�X�^���X�V
            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��Ƒ��}�X�^ "
                strSQL = strSQL & Chr(10) & "  ( "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h "
                strSQL = strSQL & Chr(10) & "  , �}�� "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , �Ƒ������� "
                strSQL = strSQL & Chr(10) & "  , �Ƒ����J�i "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , ���t�^ "
                strSQL = strSQL & Chr(10) & "  , ���N���� "
                strSQL = strSQL & Chr(10) & "  , �����͓� "
                strSQL = strSQL & Chr(10) & "  , ���^�}�{�敪 "
                strSQL = strSQL & Chr(10) & "  , �Еە}�{�敪 "
                strSQL = strSQL & Chr(10) & "  , �Љ�ی��F��� "
                strSQL = strSQL & Chr(10) & "  , �Љ�ی��r���� "
                strSQL = strSQL & Chr(10) & "  , �����敪 "
                strSQL = strSQL & Chr(10) & "  , �X�֔ԍ��P "
                strSQL = strSQL & Chr(10) & "  , �X�֔ԍ��Q "
                strSQL = strSQL & Chr(10) & "  , �s���{�� "
                strSQL = strSQL & Chr(10) & "  , �s��S "
                strSQL = strSQL & Chr(10) & "  , �����Ԓn "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , �X�V�]�ƈ��R�[�h "
                strSQL = strSQL & Chr(10) & "  , �X�V���t���� "

                '2023/06/26 ADD_Start
                strSQL = strSQL & Chr(10) & "  , ���� "
                '2023/06/26 ADD_End

                strSQL = strSQL & Chr(10) & "  ) "
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    '" & pstrNewEmployeeCD & "' " '�V�]�ƈ��R�[�h
                strSQL = strSQL & Chr(10) & "  , �}�� "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , �Ƒ������� "
                strSQL = strSQL & Chr(10) & "  , �Ƒ����J�i "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , ���t�^ "
                strSQL = strSQL & Chr(10) & "  , ���N���� "
                strSQL = strSQL & Chr(10) & "  , �����͓� "
                strSQL = strSQL & Chr(10) & "  , ���^�}�{�敪 "
                strSQL = strSQL & Chr(10) & "  , �Еە}�{�敪 "
                strSQL = strSQL & Chr(10) & "  , �Љ�ی��F��� "
                strSQL = strSQL & Chr(10) & "  , �Љ�ی��r���� "
                strSQL = strSQL & Chr(10) & "  , �����敪 "
                strSQL = strSQL & Chr(10) & "  , �X�֔ԍ��P "
                strSQL = strSQL & Chr(10) & "  , �X�֔ԍ��Q "
                strSQL = strSQL & Chr(10) & "  , �s���{�� "
                strSQL = strSQL & Chr(10) & "  , �s��S "
                strSQL = strSQL & Chr(10) & "  , �����Ԓn "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , '" & pstrEmployeeCD & "' " '�X�V�]�ƈ��R�[�h
                strSQL = strSQL & Chr(10) & "  , SYSDATE " '�X�V���t����

                '2023/06/26 ADD_Start
                strSQL = strSQL & Chr(10) & "  , ���� "
                '2023/06/26 ADD_End

                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��Ƒ��}�X�^ "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrOldEmployeeCD & "' " '���]�ƈ��R�[�h

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp.Close()
            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing

            ' �]�ƈ���ʐ^�}�X�^���X�V
            '''    strSQL = ""
            '''    strSQL = strSQL & Chr(10) & "INSERT INTO "
            '''    strSQL = strSQL & Chr(10) & "    �]�ƈ���ʐ^�}�X�^ "
            '''    strSQL = strSQL & Chr(10) & "  ( "
            '''    strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h "
            '''    strSQL = strSQL & Chr(10) & "  , ��ʐ^ "
            '''    strSQL = strSQL & Chr(10) & "  , �ʐ^�B�e�� "
            '''    strSQL = strSQL & Chr(10) & "  , �X�V�]�ƈ��R�[�h "
            '''    strSQL = strSQL & Chr(10) & "  , �X�V���t���� "
            '''    strSQL = strSQL & Chr(10) & "  ) "
            '''    strSQL = strSQL & Chr(10) & "SELECT "
            '''    strSQL = strSQL & Chr(10) & "     '" & pstrNewEmployeeCD & "' "                                                   '�V�]�ƈ��R�[�h
            '''    strSQL = strSQL & Chr(10) & "   , �ʐ^�B�e�� "
            '''    strSQL = strSQL & Chr(10) & "   , '" & pstrEmployeeCD & "' "                                                      '�X�V�]�ƈ��R�[�h
            '''    strSQL = strSQL & Chr(10) & "   , SYSDATE "                                                      '�X�V���t����
            '''    strSQL = strSQL & Chr(10) & "FROM "
            '''    strSQL = strSQL & Chr(10) & "    �]�ƈ���ʐ^�}�X�^ "
            '''    strSQL = strSQL & Chr(10) & "WHERE "
            '''    strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrOldEmployeeCD & "' "                                   '���]�ƈ��R�[�h
            '''
            '''    Call gobjOraDatabase.ExecuteSQL(strSQL)

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "  , ��ʐ^ "
            strSQL = strSQL & Chr(10) & "  , �ʐ^�B�e�� "
            strSQL = strSQL & Chr(10) & "  , �X�V�]�ƈ��R�[�h "
            strSQL = strSQL & Chr(10) & "  , �X�V���t���� "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �]�ƈ���ʐ^�}�X�^ "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrOldEmployeeCD & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H1)

            With objDysTemp

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .EOF = False Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    str�ʐ^�B�e�� = gfncFieldVal(.Fields("�ʐ^�B�e��").Value)


                    ' ��ʐ^�f�[�^�̃T�C�Y��0�o�C�g�̎�
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If .Fields("��ʐ^").FieldSize <> 0 Then

                        '--------------------------------------------------------------
                        ' ��ʐ^ �擾
                        '--------------------------------------------------------------
                        ' �Ǎ��݃o�b�t�@���Ē�`
                        ReDim abytReadBuff(MC_TEMP_BUFF_SIZE - 1)

                        ' �t�@�C���ԍ����擾
                        intFileNum = FreeFile()

                        ' �t�@�C�����J��
                        FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)

                        ' �Ǎ��݈ʒu��������
                        lngReadPosi = 0

                        Do

                            ' ��ʐ^�f�[�^���擾
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N06��18��:MK�i��j- VB��VB.NET�ϊ�
                            'dblReadSize = .Fields("��ʐ^").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                            dblReadSize = .Fields("��ʐ^").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, MC_TEMP_BUFF_SIZE)
                            '--�C���J�n�@2021�N06��18��:MK�i��j- VB��VB.NET�ϊ�

                            ' �Ǎ��񂾃f�[�^�T�C�Y��0�̎�
                            If dblReadSize = 0 Then

                                ' ���[�v�𔲂���
                                Exit Do

                            End If

                            ' ���ۂ̓Ǎ��݃T�C�Y�ƁC�i�[�o�b�t�@�̃T�C�Y���قȂ鎞
                            If dblReadSize < MC_TEMP_BUFF_SIZE Then

                                ' ���ۂ̓Ǎ��݃T�C�Y�ɁC�Ǎ��݃o�b�t�@���Ē�`
                                ReDim abytReadBuff(dblReadSize - 1)

                                ' �Ă� ��ʐ^�f�[�^�̎擾
                                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                '++�C���J�n�@2021�N06��18��:MK�i��j- VB��VB.NET�ϊ�
                                'dblReadSize = .Fields("��ʐ^").GetChunkByte(abytReadBuff(0), lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                                dblReadSize = .Fields("��ʐ^").GetChunkByte(abytReadBuff, lngReadPosi * MC_TEMP_BUFF_SIZE, dblReadSize)
                                '--�C���J�n�@2021�N06��18��:MK�i��j- VB��VB.NET�ϊ�
                            End If

                            ' �e���|�����t�@�C���ɏo��
                            'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                            FilePut(intFileNum, abytReadBuff)

                            ' ��ʐ^�f�[�^�̓Ǎ��݈ʒu���X�V
                            lngReadPosi = lngReadPosi + 1

                        Loop Until dblReadSize < MC_TEMP_BUFF_SIZE

                        ' �t�@�C�������
                        FileClose(intFileNum)


                        '** �X�V
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Call .AddNew()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("�]�ƈ��R�[�h").Value = pstrNewEmployeeCD
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("�ʐ^�B�e��").Value = str�ʐ^�B�e��
                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("�X�V�]�ƈ��R�[�h").Value = gclsLoginInfo.EmployeeCode

                        clsSysDate = New clsSystemDate
                        Call clsSysDate.DBObjectSet(gobjOraDatabase)
                        Call clsSysDate.GetSystemDate()

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        .Fields("�X�V���t����").Value = clsSysDate.SystemDateFormat("yyyy/mm/dd hh:mm:ss")

                        'UPGRADE_NOTE: Object clsSysDate may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                        clsSysDate = Nothing


                        '------------------------------------------------------------------
                        ' ��ʐ^�f�[�^ �o�^
                        '------------------------------------------------------------------
                        ' �t�@�C���ԍ����擾
                        intFileNum = FreeFile()

                        ' �t�@�C�����J��
                        FileOpen(intFileNum, mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE, OpenMode.Binary)

                        ' �J�����t�@�C���T�C�Y���擾
                        lngTotalSize = LOF(intFileNum)

                        ' �]���Ǎ��ގ��̃C���f�b�N�X���擾
                        intNumChunks = lngTotalSize \ MC_TEMP_BUFF_SIZE

                        ' �]���Ǎ��ނƂ���܂Ń��[�v
                        For intWritePosi = 0 To intNumChunks

                            ' �]��̃f�[�^��Ǎ��ގ�
                            If intWritePosi = intNumChunks Then

                                ' �]��̃f�[�^�T�C�Y�������݃T�C�Y�ɐݒ�
                                dblWriteSize = lngTotalSize Mod MC_TEMP_BUFF_SIZE

                            Else

                                ' �o�b�t�@�T�C�Y�������݃T�C�Y�ɐݒ�
                                dblWriteSize = MC_TEMP_BUFF_SIZE

                            End If

                            ' �����݃T�C�Y��0�̎�
                            ' (�����݃T�C�Y�Ŋ���؂��t�@�C���T�C�Y�̎�)
                            If dblWriteSize = 0 Then

                                Exit For

                            End If

                            ' �z��������݃T�C�Y�ɍĒ�`
                            ' (0�I���W���̂��� - 1)
                            ReDim abytWriteBuff(dblWriteSize - 1)

                            ' �t�@�C������f�[�^��Ǎ���
                            'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                            FileGet(intFileNum, abytWriteBuff)

                            ' �o�C�g�z��̃f�[�^���R�s�[�E�o�b�t�@��LONG RAW�^�t�B�[���h�ɒǉ�
                            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N06��18��:MK�i��j- VB��VB.NET�ϊ�
                            'Call .Fields("��ʐ^").AppendChunkByte(abytWriteBuff(0), dblWriteSize)
                            Call .Fields("��ʐ^").AppendChunkByte(abytWriteBuff, dblWriteSize)
                            '--�C���J�n�@2021�N06��18��:MK�i��j- VB��VB.NET�ϊ�

                        Next intWritePosi

                        ' �t�@�C�������
                        FileClose(intFileNum)

                        objFso = New Scripting.FileSystemObject

                        ' �t�@�C�����폜����
                        Call objFso.DeleteFile(mstrTempPath & pstrOldEmployeeCD & MC_TEMP_FILE)

                    End If

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Update()

                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .Close()
                'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                objDysTemp = Nothing

            End With


            ' �o�^�m�F�i�]�ƈ��������i�e�[�u���j
            ReDim pstrSearchItem(0) : pstrSearchItem(0) = "�]�ƈ��R�[�h"
            ReDim pstrSearchKey(0) : pstrSearchKey(0) = pstrOldEmployeeCD
            If gfncGetTableHandle("�]�ƈ��������i�e�[�u��", pstrSearchItem, pstrSearchKey, objDysTemp, True) = True Then
                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
            End If

            ' �]�ƈ��������i�e�[�u�����X�V
            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��������i�e�[�u�� "
                strSQL = strSQL & Chr(10) & "  ( "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h "
                strSQL = strSQL & Chr(10) & "  , �}�� "
                strSQL = strSQL & Chr(10) & "  , �������i�R�[�h "
                strSQL = strSQL & Chr(10) & "  , �������i�����N "
                strSQL = strSQL & Chr(10) & "  , �擾�N�� "
                strSQL = strSQL & Chr(10) & "  , �r���N�� "
                strSQL = strSQL & Chr(10) & "  , �X�V�]�ƈ��R�[�h "
                strSQL = strSQL & Chr(10) & "  , �X�V���t���� "
                strSQL = strSQL & Chr(10) & "  , �X�V�v���O���� "
                strSQL = strSQL & Chr(10) & "  , ���l "
                strSQL = strSQL & Chr(10) & "  ) "
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    '" & pstrNewEmployeeCD & "' " '�V�]�ƈ��R�[�h
                strSQL = strSQL & Chr(10) & "  , �}�� "
                strSQL = strSQL & Chr(10) & "  , �������i�R�[�h "
                strSQL = strSQL & Chr(10) & "  , �������i�����N "
                strSQL = strSQL & Chr(10) & "  , �擾�N�� "
                strSQL = strSQL & Chr(10) & "  , �r���N�� "
                strSQL = strSQL & Chr(10) & "  , '" & pstrEmployeeCD & "' " '�X�V�]�ƈ��R�[�h
                strSQL = strSQL & Chr(10) & "  , SYSDATE " '�X�V���t����
                strSQL = strSQL & Chr(10) & "  , '" & pstrProgramID & "' " '�X�V�v���O����
                strSQL = strSQL & Chr(10) & "  , ���l "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��������i�e�[�u�� "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrOldEmployeeCD & "' " '���]�ƈ��R�[�h

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp.Close()
            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing


            ' �o�^�m�F�i�Ƌ��ؗ����e�[�u���j
            ReDim pstrSearchItem(0) : pstrSearchItem(0) = "�]�ƈ��R�[�h"
            ReDim pstrSearchKey(0) : pstrSearchKey(0) = pstrOldEmployeeCD
            If gfncGetTableHandle("�Ƌ��ؗ����e�[�u��", pstrSearchItem, pstrSearchKey, objDysTemp, True) = True Then
                '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
                'GoTo PROC_END
                GoTo PROC_FINALLY_END
                '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
            End If

            ' �Ƌ��ؗ����e�[�u�����X�V
            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If objDysTemp.EOF = False Then

                strSQL = ""
                strSQL = strSQL & Chr(10) & "INSERT INTO "
                strSQL = strSQL & Chr(10) & "    �Ƌ��ؗ����e�[�u�� "
                strSQL = strSQL & Chr(10) & "  ( "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h "
                strSQL = strSQL & Chr(10) & "  , �}�� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��ؔԍ� "
                strSQL = strSQL & Chr(10) & "  , ��t��"
                strSQL = strSQL & Chr(10) & "  , ���N���� "
                strSQL = strSQL & Chr(10) & "  , �L������ "
                strSQL = strSQL & Chr(10) & "  , �������� "
                strSQL = strSQL & Chr(10) & "  , �{�Гs���{������ "
                strSQL = strSQL & Chr(10) & "  , �{�Ўs��S���� "
                strSQL = strSQL & Chr(10) & "  , �{�В����Ԓn���� "
                strSQL = strSQL & Chr(10) & "  , �{�Ѝ������� "
                strSQL = strSQL & Chr(10) & "  , �Z���s���{������ "
                strSQL = strSQL & Chr(10) & "  , �Z���s��S���� "
                strSQL = strSQL & Chr(10) & "  , �Z�������Ԓn���� "
                strSQL = strSQL & Chr(10) & "  , �Z���������� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��N���� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��N������� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��N������� "
                strSQL = strSQL & Chr(10) & "  , ��퍇�i��"
                strSQL = strSQL & Chr(10) & "  , ��^ "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , ��� "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , �� "
                strSQL = strSQL & Chr(10) & "  , ���t "
                strSQL = strSQL & Chr(10) & "  , ����� "
                strSQL = strSQL & Chr(10) & "  , ��^�� "
                strSQL = strSQL & Chr(10) & "  , ���ʓ� "
                strSQL = strSQL & Chr(10) & "  , ����� "
                strSQL = strSQL & Chr(10) & "  , ������� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏����� "
                strSQL = strSQL & Chr(10) & "  , �X�V�]�ƈ��R�[�h "
                strSQL = strSQL & Chr(10) & "  , �X�V���t���� "
                strSQL = strSQL & Chr(10) & "  , �L�������N���� "
                strSQL = strSQL & Chr(10) & "  , ���^"
                strSQL = strSQL & Chr(10) & "  , ���^�� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏������Q "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏������R "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏������S "
                strSQL = strSQL & Chr(10) & "  ) "
                strSQL = strSQL & Chr(10) & "SELECT "
                strSQL = strSQL & Chr(10) & "    '" & pstrNewEmployeeCD & "' " '�V�]�ƈ��R�[�h
                strSQL = strSQL & Chr(10) & "  , �}�� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��ؔԍ� "
                strSQL = strSQL & Chr(10) & "  , ��t��"
                strSQL = strSQL & Chr(10) & "  , ���N���� "
                strSQL = strSQL & Chr(10) & "  , �L������ "
                strSQL = strSQL & Chr(10) & "  , �������� "
                strSQL = strSQL & Chr(10) & "  , �{�Гs���{������ "
                strSQL = strSQL & Chr(10) & "  , �{�Ўs��S���� "
                strSQL = strSQL & Chr(10) & "  , �{�В����Ԓn���� "
                strSQL = strSQL & Chr(10) & "  , �{�Ѝ������� "
                strSQL = strSQL & Chr(10) & "  , �Z���s���{������ "
                strSQL = strSQL & Chr(10) & "  , �Z���s��S���� "
                strSQL = strSQL & Chr(10) & "  , �Z�������Ԓn���� "
                strSQL = strSQL & Chr(10) & "  , �Z���������� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��N���� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��N������� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��N������� "
                strSQL = strSQL & Chr(10) & "  , ��퍇�i��"
                strSQL = strSQL & Chr(10) & "  , ��^ "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , ��� "
                strSQL = strSQL & Chr(10) & "  , ���� "
                strSQL = strSQL & Chr(10) & "  , �� "
                strSQL = strSQL & Chr(10) & "  , ���t "
                strSQL = strSQL & Chr(10) & "  , ����� "
                strSQL = strSQL & Chr(10) & "  , ��^�� "
                strSQL = strSQL & Chr(10) & "  , ���ʓ� "
                strSQL = strSQL & Chr(10) & "  , ����� "
                strSQL = strSQL & Chr(10) & "  , ������� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏����� "
                strSQL = strSQL & Chr(10) & "  , '" & pstrEmployeeCD & "' " '�X�V�]�ƈ��R�[�h
                strSQL = strSQL & Chr(10) & "  , SYSDATE " '�X�V���t����
                strSQL = strSQL & Chr(10) & "  , �L�������N���� "
                strSQL = strSQL & Chr(10) & "  , ���^"
                strSQL = strSQL & Chr(10) & "  , ���^�� "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏������Q "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏������R "
                strSQL = strSQL & Chr(10) & "  , �Ƌ��̏������S "
                strSQL = strSQL & Chr(10) & "FROM "
                strSQL = strSQL & Chr(10) & "    �Ƌ��ؗ����e�[�u�� "
                strSQL = strSQL & Chr(10) & "WHERE "
                strSQL = strSQL & Chr(10) & "    �]�ƈ��R�[�h = '" & pstrOldEmployeeCD & "' " '���]�ƈ��R�[�h

                'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call gobjOraDatabase.ExecuteSQL(strSQL)

            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDysTemp.Close()
            'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            objDysTemp = Nothing


            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
            'PROC_END:

            'Call gsubClearObject(objFso)

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c3cea73f-307c-438c-8250-3587661d3764
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            gfncJyugyoBelongHandle = True

            If pblnFlgMsg Then
                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a79e565b-fe85-4319-9587-98c64152e4d6
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a79e565b-fe85-4319-9587-98c64152e4d6
            'Resume 
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a79e565b-fe85-4319-9587-98c64152e4d6
PROC_FINALLY_END:
        Call gsubClearObject(objFso)
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a79e565b-fe85-4319-9587-98c64152e4d6
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function



    '******************************************************************************
    ' �� �� ��  : gfncGetTableHandle
    ' �X�R�[�v  : Public
    ' �������e  : �e�[�u�����擾
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrSearchTable     String            I     �e�[�u����
    '   pstrSearchItem      String            I/O   ��������
    '   pstrSearchKey       String            I/O   ����
    '   pobjDysTemp         String            I/O   �I�u�W�F�N�g
    '   pblnFlgMsg          Boolean           I     ���b�Z�[�W�o�͗L��
    '                                                 True  : ���b�Z�[�W�o�͗L
    '                                                 False : ���b�Z�[�W�o�͖�
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2009/11/09  KSR                �V�K�쐬
    '
    '******************************************************************************
    '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
    'Public Function gfncGetTableHandle(ByVal pstrSearchTable As String, ByRef pstrSearchItem() As String, ByRef pstrSearchKey() As String, ByRef pobjDysTemp As Object, Optional ByVal pblnFlgMsg As Boolean = True) As Boolean
    Public Function gfncGetTableHandle(ByVal pstrSearchTable As String, ByRef pstrSearchItem() As String, ByRef pstrSearchKey() As String, ByRef pobjDysTemp As OraDynaset, Optional ByVal pblnFlgMsg As Boolean = True) As Boolean
        '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Dim strSQL As String
        Dim intWork As Short
        Const C_NAME_FUNCTION As String = "gfncGetTableHandle"
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



            '�߂�l������
            gfncGetTableHandle = False

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    * "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    " & pstrSearchTable & " "
            strSQL = strSQL & Chr(10) & "WHERE 1 = 1 "

            For intWork = 0 To UBound(pstrSearchItem)
                strSQL = strSQL & Chr(10) & "AND   " & pstrSearchItem(intWork) & " = '" & pstrSearchKey(intWork) & "' "
            Next

            'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            pobjDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H1)


            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a79e565b-fe85-4319-9587-98c64152e4d6
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a79e565b-fe85-4319-9587-98c64152e4d6
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            gfncGetTableHandle = True

            If pblnFlgMsg Then
                Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
            End If

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b09e7300-13f6-4ce4-a664-78cbb4349193
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b09e7300-13f6-4ce4-a664-78cbb4349193

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b09e7300-13f6-4ce4-a664-78cbb4349193
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b09e7300-13f6-4ce4-a664-78cbb4349193
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
