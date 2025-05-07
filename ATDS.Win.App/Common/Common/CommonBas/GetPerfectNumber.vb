Option Strict Off
Option Explicit On
Module basGetPerfectNumber
	'******************************************************************************
	' ��ۼު�Ė�  : �l�j�V�X�e������
	' �t�@�C����  : GetPerfectNumber.bas
	' ��    �e    : �p�[�t�F�N�g�ԍ� �擾 ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'                   gfncGetPerfectNumber         (�p�[�t�F�N�g�ԍ��擾)
	'               <Private>
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	'******************************************************************************
	' �� �� ��  : gfncGetPerfectNumber
	' �X�R�[�v  : Public
	' �������e  : �p�[�t�F�N�g�ԍ��擾
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrTableName       String            I     �e�[�u����
	'   pstrPerfectNumber   String            O     �p�[�t�F�N�g�ԍ�
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/04/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetPerfectNumber(ByVal pstrTableName As String, ByRef pstrPerfectNumber As String) As Boolean
		
	'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'On Error GoTo PROC_ERROR
'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetPerfectNumber"
		Dim strSQL As String
		Dim objDys�p�[�t�F�N�g�e�[�u�� As Object
'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
	Try
	'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		
		
		' �߂�l���������i�ُ�I���j
		gfncGetPerfectNumber = True
		
		pstrPerfectNumber = ""
		
		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    ����������ԍ� "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    " & pstrTableName & " "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    (����������ԍ�,����ԍ�) IN "
		strSQL = strSQL & Chr(10) & "    ( "
		strSQL = strSQL & Chr(10) & "        SELECT "
		strSQL = strSQL & Chr(10) & "            ����������ԍ�, "
		strSQL = strSQL & Chr(10) & "            MAX(����ԍ�)   "
		strSQL = strSQL & Chr(10) & "        FROM "
		strSQL = strSQL & Chr(10) & "            " & pstrTableName & " "
		strSQL = strSQL & Chr(10) & "        WHERE "
		strSQL = strSQL & Chr(10) & "            (�����̔ԑΏۋ敪 IS NULL OR "
		strSQL = strSQL & Chr(10) & "             �����̔ԑΏۋ敪 <> 1    )  "
		strSQL = strSQL & Chr(10) & "        GROUP BY "
		strSQL = strSQL & Chr(10) & "            ����������ԍ� "
		strSQL = strSQL & Chr(10) & "        HAVING "
		strSQL = strSQL & Chr(10) & "            SUM(�g�p�敪) = 0 "
		strSQL = strSQL & Chr(10) & "    ) "
		strSQL = strSQL & Chr(10) & "ORDER BY "
		strSQL = strSQL & Chr(10) & "    ����������ԍ� "
		
		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDys�p�[�t�F�N�g�e�[�u�� = gobjOraDatabase.CreateDynaset(strSQL, &H4)
		
		With objDys�p�[�t�F�N�g�e�[�u��
			
			' �Y������f�[�^�����݂���ꍇ
			'UPGRADE_WARNING: Couldn't resolve default property of object objDys�p�[�t�F�N�g�e�[�u��.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If .eof = False Then
				
				'�߂�l��ݒ�i����I���j
				gfncGetPerfectNumber = False
				
				'UPGRADE_WARNING: Couldn't resolve default property of object objDys�p�[�t�F�N�g�e�[�u��.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				pstrPerfectNumber = gfncFieldVal(.Fields("����������ԍ�").Value)
				
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object objDys�p�[�t�F�N�g�e�[�u��.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()
			
		End With
		
'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:84504f24-bf06-482b-b54c-f196d8c493f4
'PROC_END:
		
	'Call gsubClearObject(objDys�p�[�t�F�N�g�e�[�u��)
		
	'Exit Function
		
	'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	'PROC_ERROR:
'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:84504f24-bf06-482b-b54c-f196d8c493f4
	Catch ex As Exception
	'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		
		Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
		
		'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		'Resume PROC_END
	'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:651abb5f-fd2d-42cb-b076-30cd857464dc
	'GoTo PROC_END
	GoTo PROC_FINALLY_END
	'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:651abb5f-fd2d-42cb-b076-30cd857464dc
		'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_003 VB��VB.NET�ϊ�
		
	'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
	'++�C���J�n�@2021�N06��05:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:651abb5f-fd2d-42cb-b076-30cd857464dc
	PROC_FINALLY_END:
		Call gsubClearObject(objDys�p�[�t�F�N�g�e�[�u��)
		Exit Function
	'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:651abb5f-fd2d-42cb-b076-30cd857464dc
	'--�C���I���@2021�N06��05:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
End Module
