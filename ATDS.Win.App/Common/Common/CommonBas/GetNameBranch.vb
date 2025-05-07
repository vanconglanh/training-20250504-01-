Option Strict Off
Option Explicit On
Module basGetNameBranch
	'******************************************************************************
	' ��ۼު�Ė�  : �l�j�V�X�e������
	' �t�@�C����  : GetMstBranch.bas
	' ��    �e    : �x�X�}�X�^ ��� �擾 ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'                   gfncGetNameBranch             (�x�X�}�X�^�擾)
	'               <Private>
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/02/01  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'==============================================================================
	' �萔
	'==============================================================================
	Private Const MC_TABLE_�x�X�}�X�^ As String = "�x�X�}�X�^"
	'******************************************************************************
	' �� �� ��  : gfncGetNameBranch
	' �X�R�[�v  : Public
	' �������e  : �x�X�}�X�^�擾
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     ��s�R�[�h
	'   pstrBranchCode      String            I     �x�X�R�[�h
	'   pstrBranckName      String            O     �x�X������
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/02/01  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetNameBranch(ByVal pstrBankCode As String, ByVal pstrBranchCode As String, ByRef pstrBranckName As String) As Boolean
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetNameBranch"
		Dim objDysST_M As Object ' �x�X�}�X�^��Oradynaset
		Dim strSQL As String
'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Const C_NAME_FUNCTION As String = "gfncGetNameBranch"
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim objDysST_M As Object ' �x�X�}�X�^��Oradynaset
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim strSQL As String
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		
		' �߂�l���������i�ُ�I���j
		gfncGetNameBranch = True
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    �x�X������ "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "   " & MC_TABLE_�x�X�}�X�^ & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    ��s�R�[�h = '" & pstrBankCode & "' "
		strSQL = strSQL & Chr(10) & "AND �x�X�R�[�h = '" & pstrBranchCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysST_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysST_M
			
			' �Y������f�[�^�����������ꍇ
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysST_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' �߂�l��ݒ�i����I���j
				gfncGetNameBranch = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysST_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				pstrBranckName = gfncFieldVal(.Fields("�x�X������").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysST_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Close()
			
		End With
		
'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:42bdf1bb-7c68-4fe3-b9d2-59662370db5e
'PROC_END:
		
	'Call gsubClearObject(objDysST_M)
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:42bdf1bb-7c68-4fe3-b9d2-59662370db5e
	Catch ex As Exception
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e57a3f43-e8d4-440e-854b-91da49f679c6
	'Resume PROC_END
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e57a3f43-e8d4-440e-854b-91da49f679c6
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e57a3f43-e8d4-440e-854b-91da49f679c6
	PROC_FINALLY_END:
		Call gsubClearObject(objDysST_M)
		Exit Function
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:e57a3f43-e8d4-440e-854b-91da49f679c6
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
End Module
