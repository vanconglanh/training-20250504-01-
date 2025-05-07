Option Strict Off
Option Explicit On
Module basGetDriveFreeSpace
	'******************************************************************************
	' ��ۼު�Ė�  : �l�j�V�X�e������
	' �t�@�C����  : GetDriveFreeSpace.bas
	' ��    �e    : �h���C�u�󂫗̈� �擾 ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'                   gfncGetDriveFreeSpace        (�h���C�u�󂫗̈� �擾)
	'               <Private>
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00       2008/09/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : gfncGetDriveFreeSpace
	' �X�R�[�v  : Public
	' �������e  : �h���C�u�󂫗̈� �擾
	' ��    �l  :
	' �� �� �l  : �h���C�u�󂫗̈�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrDrvPath         String            I     �h���C�u�p�X
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00       2008/09/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetDriveFreeSpace(ByVal pstrDrvPath As String) As Decimal
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetDriveFreeSpace"
		Dim objFso As Object
		Dim objDrive As Object
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		
		gfncGetDriveFreeSpace = 0
		
		objFso = CreateObject("Scripting.FileSystemObject")
		'UPGRADE_WARNING: Couldn't resolve default property of object objFso.GetDriveName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object objFso.GetDrive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDrive = objFso.GetDrive(objFso.GetDriveName(pstrDrvPath))
		
		'UPGRADE_WARNING: Couldn't resolve default property of object objDrive.FreeSpace. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		gfncGetDriveFreeSpace = CDec(FormatNumber(objDrive.FreeSpace, 0))
		
'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c14e8343-3226-49a4-8b54-6be5f69eca95
'PROC_END:
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c14e8343-3226-49a4-8b54-6be5f69eca95
	Catch ex As Exception
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
	PROC_FINALLY_END:
		Exit Function
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:14dee9a2-1b3a-4020-9554-c290d7d531fb
	'--�C���I���@2021�N06��13:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
End Module
