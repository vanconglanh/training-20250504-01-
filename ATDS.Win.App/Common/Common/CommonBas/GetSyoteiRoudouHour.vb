Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basGetSyoteiRoudouHour
	'******************************************************************************
	' �� �� ��  : gFNC_GET_SyoteiRoudouHour
	' �X�R�[�v  : Public
	' �������e  : ����J�����Ԏ擾
	' ��    �l  :
	' �� �� �l  :
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2019/10/03  �j�r�q        �@�@ �V�K�쐬
	'
	'******************************************************************************
	Public Function gFNC_GET_SyoteiRoudouHour(ByVal pstr�N���� As String, ByVal pstr�����R�[�h As String, ByVal pstr�t�@�[�X�g As String, ByVal pstr�V�t�g�敪 As String) As Decimal
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gFNC_GET_SyoteiRoudouHour"
		Dim CurRet As Decimal
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		Dim strYear As String '//2019/10/03
		Dim strMonth As String '//2019/10/03
'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Const C_NAME_FUNCTION As String = "gFNC_GET_SyoteiRoudouHour"
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim CurRet As Decimal
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim strSQL As String
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		'++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		'Dim objDysTemp As Object
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim objDysTemp As OraDynaset
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		'--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim strYear As String '//2019/10/03
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim strMonth As String '//2019/10/03
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		strYear = gfncGetFiscalYear(pstr�N����)
		strMonth = Right(gfncGetFiscalYearMonth(pstr�N����), 2)
		
		CurRet = 0
		
		' SQL�� �쐬
		strSQL = strSQL & vbCrLf & "select "
		strSQL = strSQL & vbCrLf & "��J������" & strMonth & "�� AS ����J������"
		strSQL = strSQL & vbCrLf & "from �K����x�����}�X�^"
		strSQL = strSQL & vbCrLf & "WHERE 1 = 1"
		strSQL = strSQL & vbCrLf & "AND �N�x = " & strYear
		strSQL = strSQL & vbCrLf & "AND �����R�[�h = '" & pstr�����R�[�h & "'"
		strSQL = strSQL & vbCrLf & "AND �t�@�[�X�g = '" & pstr�t�@�[�X�g & "'"
		strSQL = strSQL & vbCrLf & "AND �V�t�g�敪 = '" & pstr�V�t�g�敪 & "'"
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysTemp
			
			' �Y������f�[�^�����݂��Ȃ��ꍇ
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .EOF = True Then
				
				CurRet = 0
				
				' �Y������f�[�^�����݂���ꍇ
			Else
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CurRet = gfncFieldCur(.Fields("����J������").Value)
				
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ed36c9b6-ba66-4974-b0d1-594a2e56e801
'PROC_END:
		
	'gFNC_GET_SyoteiRoudouHour = CurRet
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:ed36c9b6-ba66-4974-b0d1-594a2e56e801
	Catch ex As Exception
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:583b106a-3339-40d9-ae0b-1aef6edaad54
	'Resume PROC_END
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:583b106a-3339-40d9-ae0b-1aef6edaad54
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:583b106a-3339-40d9-ae0b-1aef6edaad54
	PROC_FINALLY_END:
		gFNC_GET_SyoteiRoudouHour = CurRet
		Exit Function
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:583b106a-3339-40d9-ae0b-1aef6edaad54
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
End Module
