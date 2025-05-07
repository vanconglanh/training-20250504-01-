Option Strict Off
Option Explicit On
Module basControlHandle
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : ControlHandle.bas
    ' ��    �e    : �R���g���[�� �g�p�� ����
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gfncGetLowRank          (�ŉ��ʃ����N �擾)
    '                   gfncSetAuthorityData    (������� �ݒ�)
    '                   gsubControlHandle       (�R���g���[�� �g�p�� ����)
    '               <Private>
    '
    ' �ύX����    :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �萔
    '==============================================================================
    '----------------------------------
    ' ���䃂�[�h
    '----------------------------------
    Public Const GC_CONTROL_MODE_MENU As Short = 0
    Public Const GC_CONTROL_MODE_BUTTON As Short = 1

    '==============================================================================
    ' �\����
    '==============================================================================
    '----------------------------------
    Private Structure TAG_Authority ' �����ޔ����[�N
        '----------------------------------
        Dim mTstrPID As String
        Dim mTstrF01 As String
        Dim mTstrF02 As String
        Dim mTstrF03 As String
        Dim mTstrF04 As String
        Dim mTstrF05 As String
        Dim mTstrF06 As String
        Dim mTstrF07 As String
        Dim mTstrF08 As String
        Dim mTstrF09 As String
        Dim mTstrF10 As String
        Dim mTstrF11 As String
        Dim mTstrF12 As String
        Dim mTstrMNU As String
    End Structure

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    Private mtblAuthorityInfo() As TAG_Authority
    '******************************************************************************
    ' �� �� ��  : gfncGetLowRank
    ' �X�R�[�v  : Public
    ' �������e  : �ŉ��ʃ����N �擾
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjDB              Object            O     �f�[�^�x�[�X
    '   pstrRank            String            O     �����N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncGetLowRank(ByRef pobjDB As Object, ByRef pstrRank As String) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetLowRank"
        Dim strSQL As String
        Dim objDys�����ݒ�e�[�u�� As Object
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncGetLowRank"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDys�����ݒ�e�[�u�� As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i�ُ�I��)
            gfncGetLowRank = True

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    MAX(�����N) R "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �����ݒ�e�[�u�� "

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys�����ݒ�e�[�u�� = pobjDB.CreateDynaset(strSQL, &H4)

            With objDys�����ݒ�e�[�u��

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = False Then

                    ' �߂�l��ݒ�i����I��)
                    gfncGetLowRank = False

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    pstrRank = gfncFieldVal(.Fields("R").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                End If

            End With

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e220fc5b-af03-4f93-8443-66a8219e3950
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e220fc5b-af03-4f93-8443-66a8219e3950
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:05eed43f-a129-4098-8477-eff69af0bf68
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:05eed43f-a129-4098-8477-eff69af0bf68

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:05eed43f-a129-4098-8477-eff69af0bf68
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:05eed43f-a129-4098-8477-eff69af0bf68
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gfncSetAuthorityData
    ' �X�R�[�v  : Public
    ' �������e  : ������� �ݒ�
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pobjDB              Object            O     �f�[�^�x�[�X
    '   pstrRank            String            O     �����N
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Function gfncSetAuthorityData(ByRef pobjDB As Object, ByRef pstrRank As String) As Boolean

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncSetAuthorityData"
        Dim intIdx As Short
        Dim strSQL As String
        Dim objDys�����ݒ�e�[�u�� As Object
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncSetAuthorityData"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intIdx As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objDys�����ݒ�e�[�u�� As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            ' �߂�l���������i�ُ�I��)
            gfncSetAuthorityData = True

            strSQL = ""
            strSQL = strSQL & Chr(10) & "SELECT "
            strSQL = strSQL & Chr(10) & "    * "
            strSQL = strSQL & Chr(10) & "FROM "
            strSQL = strSQL & Chr(10) & "    �����ݒ�e�[�u�� "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �����N = '" & pstrRank & "' "

            'UPGRADE_WARNING: Couldn't resolve default property of object pobjDB.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            objDys�����ݒ�e�[�u�� = pobjDB.CreateDynaset(strSQL, &H4)

            With objDys�����ݒ�e�[�u��

                ' �Y���f�[�^��������Ȃ������ꍇ
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If .eof = True Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .Close()

                    Exit Function

                End If

                ' ������ݒ�
                'UPGRADE_WARNING: Lower bound of array mtblAuthorityInfo was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ReDim mtblAuthorityInfo(.RecordCount)

                '����ܰ��ɒl��ݒ�
                For intIdx = 1 To UBound(mtblAuthorityInfo)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrPID = gfncFieldVal(.Fields("�v���O�����h�c").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF01 = gfncFieldVal(.Fields("�e�O�P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF02 = gfncFieldVal(.Fields("�e�O�Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF03 = gfncFieldVal(.Fields("�e�O�R").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF04 = gfncFieldVal(.Fields("�e�O�S").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF05 = gfncFieldVal(.Fields("�e�O�T").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF06 = gfncFieldVal(.Fields("�e�O�U").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF07 = gfncFieldVal(.Fields("�e�O�V").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF08 = gfncFieldVal(.Fields("�e�O�W").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF09 = gfncFieldVal(.Fields("�e�O�X").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF10 = gfncFieldVal(.Fields("�e�P�O").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF11 = gfncFieldVal(.Fields("�e�P�P").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrF12 = gfncFieldVal(.Fields("�e�P�Q").Value)
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    mtblAuthorityInfo(intIdx).mTstrMNU = gfncFieldVal(.Fields("���j���[").Value)

                    'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Call .MoveNext()

                Next intIdx

                'UPGRADE_WARNING: Couldn't resolve default property of object objDys�����ݒ�e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Call .Close()

            End With

            ' �߂�l��ݒ�i����I��)
            gfncSetAuthorityData = False

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:05eed43f-a129-4098-8477-eff69af0bf68
            'PROC_END:

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:05eed43f-a129-4098-8477-eff69af0bf68
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
PROC_FINALLY_END:
        Exit Function
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
    '******************************************************************************
    ' �� �� ��  : gsubControlHandle
    ' �X�R�[�v  : Public
    ' �������e  : �R���g���[������
    ' ��    �l  :
    ' �� �� �l  : True �i�ُ�I���j
    '             False�i����I���j
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pForm               Form              I/O   ����Ώۉ��
    '   pintMode            Integer           I     ���䃂�[�h
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00       2007/08/30  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubControlHandle(ByRef pForm As System.Windows.Forms.Form, ByVal pintMode As Short)

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gsubControlHandle"
        Dim Ctl As System.Windows.Forms.Control
        Dim intIdx As Short
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gsubControlHandle"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim Ctl As System.Windows.Forms.Control
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim intIdx As Short
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            Select Case pintMode
            '--------------------------------------------------------------------------
            ' ���j���[����
            '--------------------------------------------------------------------------
                Case GC_CONTROL_MODE_MENU

                    For intIdx = LBound(mtblAuthorityInfo) To UBound(mtblAuthorityInfo)

                        For Each Ctl In pForm.Controls

                            If Trim(Mid(Ctl.Name, 4, 10)) = Trim(mtblAuthorityInfo(intIdx).mTstrPID) Then

                                If mtblAuthorityInfo(intIdx).mTstrMNU = "��" Then

                                    Ctl.Visible = True

                                Else

                                    Ctl.Visible = False

                                End If

                            End If

                        Next Ctl

                    Next intIdx

                '--------------------------------------------------------------------------
                ' �{�^������
                '--------------------------------------------------------------------------
                Case GC_CONTROL_MODE_BUTTON

                    For intIdx = LBound(mtblAuthorityInfo) To UBound(mtblAuthorityInfo)

                        If pForm.Name = Trim(mtblAuthorityInfo(intIdx).mTstrPID) Then

                            '--------------------------------------------------------------
                            '�e�O�P
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF01 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF01 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF01.Visible = True
                                pForm.Controls.Item("cmdF01").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF01 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF01 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF01.Visible = False
                                pForm.Controls.Item("cmdF01").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

                            End If
                            '--------------------------------------------------------------
                            '�e�O�Q
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF02 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF02 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF02.Visible = True
                                pForm.Controls.Item("cmdF02").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF02 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF02 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF02.Visible = False
                                pForm.Controls.Item("cmdF02").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�R
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF03 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF03 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF03.Visible = True
                                pForm.Controls.Item("cmdF03").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF03 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF03 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF03.Visible = False
                                pForm.Controls.Item("cmdF03").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�S
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF04 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF04 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF04.Visible = True
                                pForm.Controls.Item("cmdF04").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF04 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF04 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF04.Visible = False
                                pForm.Controls.Item("cmdF04").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�T
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF05 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF05 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF05.Visible = True
                                pForm.Controls.Item("cmdF05").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF05 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF05 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF05.Visible = False
                                pForm.Controls.Item("cmdF05").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�U
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF06 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF06 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF06.Visible = True
                                pForm.Controls.Item("cmdF06").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF06 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF06 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF06.Visible = cmdF06
                                pForm.Controls.Item("cmdF06").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�V
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF07 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF07 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF07.Visible = True
                                pForm.Controls.Item("cmdF07").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF07 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF07 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF07.Visible = cmdF06
                                pForm.Controls.Item("cmdF07").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�W
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF08 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF08 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF08.Visible = True
                                pForm.Controls.Item("cmdF08").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF08 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF08 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF08.Visible = cmdF06
                                pForm.Controls.Item("cmdF08").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�O�X
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF09 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF09 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF09.Visible = True
                                pForm.Controls.Item("cmdF09").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF09 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF09 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF09.Visible = False
                                pForm.Controls.Item("cmdF09").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�P�O
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF10 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF10 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF10.Visible = True
                                pForm.Controls.Item("cmdF10").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF10 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF10 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF10.Visible = False
                                pForm.Controls.Item("cmdF10").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�P�P
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF11 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF11 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF11.Visible = True
                                pForm.Controls.Item("cmdF11").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF11 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF11 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF11.Visible = False
                                pForm.Controls.Item("cmdF11").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If
                            '--------------------------------------------------------------
                            '�e�P�Q
                            '--------------------------------------------------------------
                            If mtblAuthorityInfo(intIdx).mTstrF12 = "��" Then
                                'UPGRADE_ISSUE: Control cmdF12 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF12.Visible = True
                                pForm.Controls.Item("cmdF12").Visible = True
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            ElseIf mtblAuthorityInfo(intIdx).mTstrF12 = "�s��" Then
                                'UPGRADE_ISSUE: Control cmdF129 could not be resolved because it was within the generic namespace Form. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
                                '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                                'pForm.cmdF12.Visible = False
                                pForm.Controls.Item("cmdF12").Visible = False
                                '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
                            End If

                        End If

                    Next intIdx

            End Select

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
            'PROC_END:

            'Exit Sub

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:eaa73ef7-4a79-4eca-9f65-3cf1c468b011
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8e4a0983-8acf-48ff-877f-2b91f7e110da
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8e4a0983-8acf-48ff-877f-2b91f7e110da

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8e4a0983-8acf-48ff-877f-2b91f7e110da
PROC_FINALLY_END:
        Exit Sub
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:8e4a0983-8acf-48ff-877f-2b91f7e110da
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Sub
End Module
