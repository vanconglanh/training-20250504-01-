Option Strict Off
Option Explicit On
Imports MKOra.Core

Friend Class clsExportDbToCsv
    Private Idx As Short ' �z��p����
    Private Jdx As Short ' �z��p����
    Private W As Object ' ���[�N�ϐ�
    Private REC As String ' ���[�N�ϐ�

    ' �n����������OO4O�I�u�W�F�N�g��
    '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
    'Private OraSession As Object
    'Private OraDatabase As Object
    'Private OraDynaset As Object
    Private OraSession As OraSession
    Private OraDatabase As OraDatabase
    Private OraDynaset As OraDynaset
    '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�

    ' �p�����[�^�ݒ�E�Q�Ɨp�ϐ�
    Private mstrDataBase As String ' �ڑ��f�[�^�x�[�X
    Private mstrUserPass As String ' ���[�U�^�p�X���[�h
    Private mstrSQL As String ' �r�p�k��
    Private mblnTitleOutPut As Boolean ' ���ڃ^�C�g���o�͗L��
    Private mstrCsvFileName As String ' �b�r�u�t�@�C����
    Private mintProcRecordCount As Integer ' ��������
    Private mintAllRecordCount As Integer ' �S����
    Private mintErrorCode As Integer ' �G���[�R�[�h

    ' �C�x���g
    Public Event Display()
    '------------------------------------------------------------
    ' �ڑ�����f�[�^�x�[�X��
    '------------------------------------------------------------
    Public WriteOnly Property DataBase() As String
        Set(ByVal Value As String)
            mstrDataBase = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' �ڑ����郆�[�U�^�p�X���[�h
    '------------------------------------------------------------
    Public WriteOnly Property UserPass() As String
        Set(ByVal Value As String)
            mstrUserPass = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' �₢���킹�r�p�k
    '------------------------------------------------------------
    Public WriteOnly Property SQL() As String
        Set(ByVal Value As String)
            mstrSQL = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' CSV�t�@�C�����i�p�X�j
    '------------------------------------------------------------
    Public WriteOnly Property CsvFileName() As String
        Set(ByVal Value As String)
            mstrCsvFileName = Value
        End Set
    End Property
    '------------------------------------------------------------
    ' �^�C�g���o�͗L��
    '------------------------------------------------------------
    Public WriteOnly Property TitleOutPut() As Boolean
        Set(ByVal Value As Boolean)
            mblnTitleOutPut = Value
        End Set
    End Property

    '------------------------------------------------------------
    ' �S����
    '------------------------------------------------------------
    Public ReadOnly Property AllRecordCount() As String
        Get
            AllRecordCount = CStr(mintAllRecordCount)
        End Get
    End Property

    '------------------------------------------------------------
    ' ��������
    '------------------------------------------------------------
    Public ReadOnly Property ProcRecordCount() As String
        Get
            ProcRecordCount = CStr(mintProcRecordCount)
        End Get
    End Property

    '------------------------------------------------------------
    ' �G���[�R�[�h
    '------------------------------------------------------------
    Public ReadOnly Property ErrorCode() As String
        Get
            ErrorCode = CStr(mintErrorCode)
        End Get
    End Property

    Public Sub Connect()
        On Error Resume Next
        ' Oracle OO4O�̃I�[�v��
        '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
        'OraSession = CreateObject("OracleInProcServer.XOraSession")
        OraSession = New OraSession()
        '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
        'UPGRADE_WARNING: Couldn't resolve default property of object OraSession.OpenDatabase. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OraDatabase = OraSession.OpenDatabase(mstrDataBase, mstrUserPass, &H0)
        ' �ǉ��e�[�u�������`�����擾(��ΑI������Ȃ��r�p�k�𔭍s)
        'UPGRADE_WARNING: Couldn't resolve default property of object OraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        OraDynaset = OraDatabase.CreateDynaset(mstrSQL, &H4)
        If Err.Number <> 0 Then
            mintErrorCode = Err.Number
            Exit Sub
        End If
        On Error GoTo 0
        ' �\������������
        'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        mintAllRecordCount = OraDynaset.RecordCount
        mintProcRecordCount = 0
    End Sub

    Public Sub Output()
        ' �b�r�u�t�@�C�����I�[�v������
        FileOpen(1, mstrCsvFileName, OpenMode.Output)

        ' ���R�[�h�o�͏���
        With OraDynaset
            ' ���ڃ^�C�g���o�͏���
            If mblnTitleOutPut Then
                REC = ""
                'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                For Jdx = 0 To .Fields.Count - 1
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.FieldName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    '++�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
                    'W = """" & .FieldName(Jdx) & """"
                    '++�C���J�n�@2021�N09��22��:MK�i��j- VB��VB.NET�ϊ�
                    'W = """" & gfncFieldVal(.Fields(Jdx).Value) & """"
                    W = """" & gfncFieldVal(.Fields(Jdx).Name) & """"
                    '--�C���J�n�@2021�N09��22��:MK�i��j- VB��VB.NET�ϊ�
                    '--�C���J�n�@2021�N09��18��:MK�i��j- VB��VB.NET�ϊ�
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    REC = REC & W
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Jdx < .Fields.Count - 1 Then
                        REC = REC & ","
                    End If
                Next
                PrintLine(1, REC)
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            While Not .EOF
                REC = ""
                'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                For Jdx = 0 To .Fields.Count - 1
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    W = .Fields(Jdx).Value
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Select Case .Fields(Jdx).Type
                        Case 10, 11, 12 ' ������
                            'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            W = """" & W & """"
                        Case 3, 4, 7 ' ���l
                            'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            W = W
                        Case 8 ' ���t
                            'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            '++�C���J�n�@2021�N09��22��:MK�i��j- VB��VB.NET�ϊ�
                            'W = """" & VB6.Format(W, "YYYY/MM/DD") & """"
                            If W Is Nothing Then
                                W = """" & "" & """"
                            Else
                                W = """" & VB6.Format(W, "YYYY/MM/DD") & """"
                            End If

                            '--�C���J�n�@2021�N09��22��:MK�i��j- VB��VB.NET�ϊ�
                    End Select
                    'UPGRADE_WARNING: Couldn't resolve default property of object W. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    REC = REC & W
                    'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If Jdx < .Fields.Count - 1 Then
                        REC = REC & ","
                    End If
                Next
                PrintLine(1, REC)
                'UPGRADE_WARNING: Couldn't resolve default property of object OraDynaset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                .MoveNext()
                mintProcRecordCount = mintProcRecordCount + 1
                RaiseEvent Display()
            End While
        End With
        FileClose()
    End Sub
End Class