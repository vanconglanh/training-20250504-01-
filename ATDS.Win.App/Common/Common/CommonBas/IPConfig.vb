Option Strict Off
Option Explicit On
Module basIPConfig

    ' @(f)
    '
    ' �@�\�@�@�@: ���[�J���h�o�@�擾����
    '
    ' �Ԃ�l�@�@: ���[�J���h�o
    '
    ' �������@�@: �Ȃ�
    '
    ' �@�\�����@: �ڑ������u���[�J�� �G���A�ڑ��v�̂h�o���擾����B
    '�@�@�@�@�@   ���̐ڑ����������ꍇ��A�ڑ���񂪎擾�ł��Ȃ��ꍇ��
    '�@�@�@�@�@   �ڑ��̂h�o(0.0.0.0������)���擾����B
    '
    '�@�@�@�@�@   �ʏ�A�������݂��鎖�͖����Ǝv���邪�A
    '�@�@�@�@�@   ���݂���ꍇ�ɂ͉��ǂ���K�v����B
    '
    '�@�@�@�@�@   Win2000�AXP�ł̂ݓ��삷��B
    '�@�@�@�@�@   �ȊO�ł̓��삪�K�v�Ȃ�Ή��ǂ���K�v����B
    '
    ' ���l      : �Q�l�g�o
    '�@�@�@�@�@   http://wscript.name/index.php?Win32_NetworkAdapterConfiguration
    '
    ' �L���ҁ@�@: Maruo
    '
    ' �L�����@�@: 2006.11.22
    '
    Public Function gfncGetLocalIP() As String

        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        'On Error GoTo PROC_ERROR
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Const C_NAME_FUNCTION As String = "gfncGetLocalIP"
        Dim strComputer As String
        Dim objWMIservice As Object
        Dim colAdapters As Object
        Dim objAdapter As Object
        Dim colItems As Object
        Dim objItem As Object
        Dim strAdapterName As String
        Dim strCaption As String
        Dim colIP As New Collection
        Dim strSQL As String
        Dim strTemp As String
        Dim lngLoop As Integer
        Dim strRet As String
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
        Try
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Const C_NAME_FUNCTION As String = "gfncGetLocalIP"
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strComputer As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objWMIservice As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim colAdapters As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objAdapter As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim colItems As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim objItem As Object
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strAdapterName As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strCaption As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim colIP As New Collection
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strSQL As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strTemp As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim lngLoop As Integer
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
            'Dim strRet As String
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�

            strComputer = "."

            objWMIservice = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")

            '------------------------------
            '   �Ώ�LAN�A�_�v�^��������
            '------------------------------
            strAdapterName = "���[�J�� �G���A�ڑ�"

            '    '-----------------------------------------------------------------------------
            '    '   ExecQuery���\�b�h��Win32_NetworkAdapter�N���X����A�A�_�v�^���ōi�荞��
            '    '-----------------------------------------------------------------------------
            '    Set colAdapters = objWMIservice.ExecQuery _
            ''        ("Select * from Win32_NetworkAdapter where NetConnectionID='" & strAdapterName & "'")
            '
            '    '---------------------------------------------
            '    '   �A�_�v�^�̃I�u�W�F�N�g����Caption���擾
            '    '---------------------------------------------
            '    If Not colAdapters Is Nothing Then
            '        For Each objAdapter In colAdapters
            '            strCaption = objAdapter.Caption
            '        Next
            '    End If

            '------------------------------------------------------------------------------------
            '   ExecQuery���\�b�h��Caption�̒l��Win32_NetworkAdapter�N���X�Ɠ����A�_�v�^���擾
            '------------------------------------------------------------------------------------
            strSQL = "SELECT"
            strSQL = strSQL & " *"
            strSQL = strSQL & " FROM Win32_NetworkAdapterConfiguration"
            strSQL = strSQL & " WHERE IPEnabled = TRUE"

            If Len(strCaption) Then
                strSQL = strSQL & "   AND Caption = '" & strCaption & "'"
            End If

            'UPGRADE_WARNING: Couldn't resolve default property of object objWMIservice.ExecQuery. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            colItems = objWMIservice.ExecQuery(strSQL)

            For Each objItem In colItems

                'UPGRADE_WARNING: Couldn't resolve default property of object objItem.IPAddress. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
                If Not IsDBNull(objItem.IPAddress) Then

                    'UPGRADE_WARNING: Couldn't resolve default property of object objItem.IPAddress. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    For lngLoop = LBound(objItem.IPAddress) To UBound(objItem.IPAddress)

                        'UPGRADE_WARNING: Couldn't resolve default property of object objItem.IPAddress. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strTemp = objItem.IPAddress(lngLoop)

                        If Len(strTemp) > 0 Then

                            If strTemp <> "0.0.0.0" Then

                                colIP.Add(strTemp)

                            End If

                        End If

                    Next

                End If

            Next objItem

            'UPGRADE_WARNING: Couldn't resolve default property of object colIP(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            strRet = colIP.Item(1)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:894c99c2-ae09-4989-aca5-90b1e2e5fa9b
            'PROC_END:

            'On Error Resume Next

            'UPGRADE_NOTE: Object colAdapters may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'colAdapters = Nothing
            'UPGRADE_NOTE: Object objAdapter may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objAdapter = Nothing
            'UPGRADE_NOTE: Object colItems may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'colItems = Nothing
            'UPGRADE_NOTE: Object objItem may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'objItem = Nothing

            'gfncGetLocalIP = strRet

            'Exit Function

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
            'PROC_ERROR:
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:894c99c2-ae09-4989-aca5-90b1e2e5fa9b
        Catch ex As Exception
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

            '    Call MsgBox(Err.Description, vbCritical, C_NAME_FUNCTION)

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296
            'Resume PROC_END
            '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296

            '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
        End Try
        '++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296
PROC_FINALLY_END:
        '		On Error Resume Next
        Try
            colAdapters = Nothing
            objAdapter = Nothing
            colItems = Nothing
            objItem = Nothing
            gfncGetLocalIP = strRet
            Exit Function
        Catch ex1 As Exception
        End Try
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1cc7cda4-9e5d-4d35-a625-a3a3fd2a2296
        '--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
    End Function
End Module
