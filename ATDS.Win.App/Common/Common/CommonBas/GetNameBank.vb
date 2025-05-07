Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basGetNameBank
	'******************************************************************************
	' ��ۼު�Ė�  : �l�j�V�X�e������
	' �t�@�C����  : GetNameBank.bas
	' ��    �e    : ��s�}�X�^ ���� �擾 ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'                   gfncGetNameBank               (��s�}�X�^ ���� �擾)
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
	Private Const MC_TABLE_��s�}�X�^ As String = "��s�}�X�^"
	'******************************************************************************
	' �� �� ��  : gfncGetNameBank
	' �X�R�[�v  : Public
	' �������e  : ��s�}�X�^ ���� �擾
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     ��s�R�[�h
	'   pstrBankName        String            O     ��s������
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2007/02/01  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetNameBank(ByVal pstrBankCode As String, ByRef pstrBankName As String) As Boolean
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetNameBank"
		Dim objDysGK_M As OraDynaset ' ��s�}�X�^��Oradynaset
		Dim strSQL As String
'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Const C_NAME_FUNCTION As String = "gfncGetNameBank"
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		
		'++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		'Dim objDysGK_M As Object ' ��s�}�X�^��Oradynaset
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim objDysGK_M As OraDynaset ' ��s�}�X�^��Oradynaset
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		'--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	'Dim strSQL As String
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		
		' �߂�l���������i�ُ�I���j
		gfncGetNameBank = True
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    ��s������ "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "   " & MC_TABLE_��s�}�X�^ & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    ��s�R�[�h = '" & pstrBankCode & "' "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysGK_M = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDysGK_M
			
			' �Y������f�[�^�����������ꍇ
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysGK_M.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				' �߂�l��ݒ�i����I���j
				gfncGetNameBank = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysGK_M.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				pstrBankName = gfncFieldVal(.Fields("��s������").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDysGK_M.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Close()
			
		End With
		
'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:025ab725-d710-40ac-84b8-3021bd80d377
'PROC_END:
		
	'Call gsubClearObject(objDysGK_M)
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:025ab725-d710-40ac-84b8-3021bd80d377
	Catch ex As Exception
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b5b7a20d-c682-44df-aceb-5cede829d49e
	'Resume PROC_END
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b5b7a20d-c682-44df-aceb-5cede829d49e
		
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b5b7a20d-c682-44df-aceb-5cede829d49e
	PROC_FINALLY_END:
		Call gsubClearObject(objDysGK_M)
		Exit Function
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b5b7a20d-c682-44df-aceb-5cede829d49e
	'--�C���I���@2021�N06��01:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
End Module
