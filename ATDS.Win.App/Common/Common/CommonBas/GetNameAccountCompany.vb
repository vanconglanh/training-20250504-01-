Option Strict Off
Option Explicit On
Module basGetNameAccountCompany
	'******************************************************************************
	' �� �� ��  : gfncGetNameAccountCompany
	' �X�R�[�v  : Public
	' �������e  : �U�����Ж� �擾
	' ��    �l  :
	' �� �� �l  : �U�����Ж�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrCompanyCode     String            I     ��ЃR�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetNameAccountCompany(ByVal pstrCompanyCode As String) As String
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetNameAccountCompany"
		Dim strSQL As String
		Dim objDys��Ѓ}�X�^ As Object
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		
		' �߂�l��������
		gfncGetNameAccountCompany = GC_DEF_�^��_�������`
		
		' SQL�� �쐬
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    �U���於�` "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    ��Ѓ}�X�^ "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    ��ЃR�[�h= '" & pstrCompanyCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDys��Ѓ}�X�^ = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDys��Ѓ}�X�^
			
			' �Y������f�[�^�����݂���ꍇ
			'UPGRADE_WARNING: Couldn't resolve default property of object objDys��Ѓ}�X�^.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' �߂�l��ݒ�
				'UPGRADE_WARNING: Couldn't resolve default property of object objDys��Ѓ}�X�^.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				gfncGetNameAccountCompany = gfncFieldVal(.Fields("�U���於�`").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDys��Ѓ}�X�^.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Close()
			
		End With
		
'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1814c2b4-43e2-45b8-b151-78a992010f34
'PROC_END:
		
	'Call gsubClearObject(objDys��Ѓ}�X�^)
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:1814c2b4-43e2-45b8-b151-78a992010f34
	Catch ex As Exception
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4e040c9a-e7e2-4175-a187-851572b12a3a
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4e040c9a-e7e2-4175-a187-851572b12a3a
		'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4e040c9a-e7e2-4175-a187-851572b12a3a
	PROC_FINALLY_END:
		Call gsubClearObject(objDys��Ѓ}�X�^)
		Exit Function
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:4e040c9a-e7e2-4175-a187-851572b12a3a
	'--�C���I���@2021�N06��20:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
End Module
