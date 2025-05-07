Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basUsCommonFunction
	'******************************************************************************
	' ��ۼު�Ė�  : ���|�����Ǘ��V�X�e��
	' �t�@�C����  : UsCommonFunction.bas
	' ��    �e    : ���|�����Ǘ� ���� ���W���[��
	' ��    �l    :
	' �֐��ꗗ    : <Public>
	'               <Private>
	'
	' �ύX����    :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  �A��  �F��         �V�K�쐬
	'   02.26.00    2010/03/11  �A��  �F��         �l�j����}�X�^�̃p�[�t�F�N�g�Œ�ɂ��Ă��J������悤�ɏC���B
	'   02.32.00    2010/03/23  �A��  �F��         �r�p�k���̕s��C���B
	'   02.33.00    2010/03/24  �A��  �F��         �O��̒��������f�[�^�����݂��Ȃ��ꍇ��,
	'                                              �����ϐ��������萔�����擾�ł��Ȃ��Ȃ�s��ɑΉ��B
	'   02.33.00    2015/12/18  �j�r�q             �����������͐����C���e�[�u���̃��[�N�쐬��15�b�قǂ����邽�߁A
	'                                              �����������̐����C���e�[�u���̍X�V���E�������ς�������̂ݏ���������悤�ɏC���B
	'   02.34.00    2016/03/30  �j�r�q             �`�P�b�g���׃e�[�u������ۑ��p�̏�����ǉ�
	'                                              PopUP����p�ϐ��̒ǉ�
	'
	'******************************************************************************
	'==============================================================================
	' �`�o�h�錾
	'==============================================================================
	' �V�X�e���𗧂��グ�Ă���̌o�ߎ��Ԃ������x�Ɏ擾����i�f�o�b�O�p�j
	Private Declare Function timeGetTime Lib "winmm.dll" () As Integer
	'==============================================================================
	' �`�o�h�֐�
	'==============================================================================
	Public Const VK_SHIFT As Integer = &H10

	'==============================================================================
	' �萔
	'==============================================================================
	Private Const MC_TBL_�����e�[�u�� As String = "�����e�[�u��"

	'20160330 ADD START
	'==============================================================================
	' �ϐ�
	'==============================================================================
	'Public gclsSKP090                           As clsUnitUsPopUpInfo       'PopUP����i�`�P�b�g���ח����j 2018/08/06 SKP090���C������Ƃ��A�ʂɂ���
	'20160330 ADD END


	' ���z�L�[�̉�����Ԏ擾
	Public Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Integer) As Short

	'******************************************************************************
	' �� �� ��  : gfncUpdateTblPerfectAuto
	' �X�R�[�v  : Public
	' �������e  : �p�[�t�F�N�g�e�[�u�� �����폜
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ���@�t      ���@��        �@�@ �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2008/10/21  �A��@�F��      �@ �V�K�쐬
	'   02.26.00    2010/03/11  �A��  �F��         �l�j����}�X�^�̃p�[�t�F�N�g�Œ�ɂ��Ă��J������悤�ɏC���B
	'   02.32.00    2010/03/23  �A��  �F��         �r�p�k���̕s��C���B
	'
	'******************************************************************************
	Public Function gfncUpdateTblPerfectAuto(ByVal pstrYearMonth As String) As Boolean

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncUpdateTblPerfectAuto"
		Dim strSQL As String
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�



			' �߂�l���������i�ُ�I���j
			gfncUpdateTblPerfectAuto = True

			strSQL = ""
			strSQL = strSQL & Chr(10) & "UPDATE �p�[�t�F�N�g�e�[�u�� "
			strSQL = strSQL & Chr(10) & "SET �g�p�敪         = '0' "
			strSQL = strSQL & Chr(10) & ",   �X�V�]�ƈ��R�[�h = '" & gclsLoginInfo.EmployeeCode & "' "
			strSQL = strSQL & Chr(10) & ",   �X�V���t����     = SYSDATE "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    �g�p�敪           = '1' "
			strSQL = strSQL & Chr(10) & "AND (�����̔ԑΏۋ敪 IS NULL OR "
			strSQL = strSQL & Chr(10) & "     �����̔ԑΏۋ敪 <> 1    )  "
			strSQL = strSQL & Chr(10) & "AND (����R�[�h, ����}�R�[�h) IN "
			strSQL = strSQL & Chr(10) & "    ( "
			strSQL = strSQL & Chr(10) & "        SELECT "
			strSQL = strSQL & Chr(10) & "            PFT.����R�[�h   "
			strSQL = strSQL & Chr(10) & "           ,PFT.����}�R�[�h "
			strSQL = strSQL & Chr(10) & "        FROM "
			strSQL = strSQL & Chr(10) & "            �l�j��������}�X�^   KM  "
			strSQL = strSQL & Chr(10) & "           ,�p�[�t�F�N�g�e�[�u�� PFT "
			strSQL = strSQL & Chr(10) & "           ,( "
			strSQL = strSQL & Chr(10) & "                SELECT "
			strSQL = strSQL & Chr(10) & "                    �ڋq�R�[�h            "
			strSQL = strSQL & Chr(10) & "                   ,�ڋq�}�R�[�h          "
			strSQL = strSQL & Chr(10) & "                   ,MAX(�����N��) AS �N�� "
			strSQL = strSQL & Chr(10) & "                FROM "
			strSQL = strSQL & Chr(10) & "                    ���|�Ǘ��e�[�u�� "
			strSQL = strSQL & Chr(10) & "                WHERE "
			strSQL = strSQL & Chr(10) & "                    �����c��  = 0 "
			strSQL = strSQL & Chr(10) & "                AND �����N�� <= '" & pstrYearMonth & "' "
			strSQL = strSQL & Chr(10) & "                GROUP BY "
			strSQL = strSQL & Chr(10) & "                    �ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "                   ,�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "            ) UKT "
			strSQL = strSQL & Chr(10) & "        WHERE "
			strSQL = strSQL & Chr(10) & "            KM.����R�[�h          = PFT.����R�[�h   "
			strSQL = strSQL & Chr(10) & "        AND KM.����}�R�[�h        = PFT.����}�R�[�h "
			strSQL = strSQL & Chr(10) & "        AND KM.����R�[�h          = UKT.�ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "        AND KM.����}�R�[�h        = UKT.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "        AND KM.���p�敪            = '02' "
			strSQL = strSQL & Chr(10) & "        AND PFT.�g�p�敪           = '1' "
			strSQL = strSQL & Chr(10) & "        AND ( "
			strSQL = strSQL & Chr(10) & "                PFT.�����̔ԑΏۋ敪 IS NULL "
			strSQL = strSQL & Chr(10) & "             OR PFT.�����̔ԑΏۋ敪 <> 1    "
			strSQL = strSQL & Chr(10) & "            ) "
			strSQL = strSQL & Chr(10) & "    ) "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			strSQL = ""
			strSQL = strSQL & Chr(10) & "UPDATE �l�j����}�X�^ "
			strSQL = strSQL & Chr(10) & "SET ����������ԍ�       = NULL      "
			strSQL = strSQL & Chr(10) & ",   �p�[�t�F�N�g�g�p�敪 = 0         "
			strSQL = strSQL & Chr(10) & ",   �p�[�t�F�N�g�Œ�     = 0         "
			strSQL = strSQL & Chr(10) & ",   �X�V�]�ƈ��R�[�h     = '" & gclsLoginInfo.EmployeeCode & "' "
			strSQL = strSQL & Chr(10) & ",   �X�V���t����         = SYSDATE   "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    ����������ԍ� IS NOT NULL"
			strSQL = strSQL & Chr(10) & "AND (����R�[�h, ����}�R�[�h) IN "
			strSQL = strSQL & Chr(10) & "    ( "
			strSQL = strSQL & Chr(10) & "        SELECT "
			strSQL = strSQL & Chr(10) & "            UKT.�ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "           ,UKT.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "        FROM "
			strSQL = strSQL & Chr(10) & "            �l�j��������}�X�^ KM "
			strSQL = strSQL & Chr(10) & "           ,( "
			strSQL = strSQL & Chr(10) & "                SELECT "
			strSQL = strSQL & Chr(10) & "                    �ڋq�R�[�h            "
			strSQL = strSQL & Chr(10) & "                   ,�ڋq�}�R�[�h          "
			strSQL = strSQL & Chr(10) & "                   ,MAX(�����N��) AS �N�� "
			strSQL = strSQL & Chr(10) & "                FROM "
			strSQL = strSQL & Chr(10) & "                    ���|�Ǘ��e�[�u�� "
			strSQL = strSQL & Chr(10) & "                WHERE "
			strSQL = strSQL & Chr(10) & "                    �����c��  = 0 "
			strSQL = strSQL & Chr(10) & "                AND �����N�� <= '" & pstrYearMonth & "' "
			strSQL = strSQL & Chr(10) & "                GROUP BY "
			strSQL = strSQL & Chr(10) & "                    �ڋq�R�[�h  , "
			strSQL = strSQL & Chr(10) & "                    �ڋq�}�R�[�h  "
			strSQL = strSQL & Chr(10) & "            ) UKT  "
			strSQL = strSQL & Chr(10) & "        WHERE "
			strSQL = strSQL & Chr(10) & "            KM.����R�[�h   = UKT.�ڋq�R�[�h "
			strSQL = strSQL & Chr(10) & "        AND KM.����}�R�[�h = UKT.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "        AND KM.���p�敪     = '02' "
			strSQL = strSQL & Chr(10) & "    ) "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			' �߂�l��ݒ�i����I���j
			gfncUpdateTblPerfectAuto = False

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6760f4c8-f377-42e4-871b-2f5b58d66afc
			'PROC_END:

			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:6760f4c8-f377-42e4-871b-2f5b58d66afc
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
PROC_FINALLY_END:
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'******************************************************************************
	' �� �� ��  : gfncGetCntBlankPerfectNum
	' �X�R�[�v  : Public
	' �������e  : �p�[�t�F�N�g�ԍ��󂫌��� �擾
	' ��    �l  :
	' �� �� �l  : �p�[�t�F�N�g�ԍ��󂫌���
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'
	' �ύX����  :
	'   Version     ���@�t      ���@��        �@�@ �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/05/14  �A��@�F��      �@ �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetCntBlankPerfectNum() As Integer

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetCntBlankPerfectNum"
		Dim strSQL As String
		Dim lngRet As Integer
		Dim objDysTemp As OraDynaset
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			lngRet = 0

			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    COUNT(����������ԍ�) AS �󂫌��� "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    �p�[�t�F�N�g�e�[�u�� "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    (����������ԍ�,����ԍ�) IN "
			strSQL = strSQL & Chr(10) & "    ( "
			strSQL = strSQL & Chr(10) & "        SELECT "
			strSQL = strSQL & Chr(10) & "            ����������ԍ�, "
			strSQL = strSQL & Chr(10) & "            MAX(����ԍ�)   "
			strSQL = strSQL & Chr(10) & "        FROM "
			strSQL = strSQL & Chr(10) & "            �p�[�t�F�N�g�e�[�u�� "
			strSQL = strSQL & Chr(10) & "        WHERE "
			strSQL = strSQL & Chr(10) & "            (�����̔ԑΏۋ敪 IS NULL OR "
			strSQL = strSQL & Chr(10) & "             �����̔ԑΏۋ敪 <> 1    )  "
			strSQL = strSQL & Chr(10) & "        GROUP BY "
			strSQL = strSQL & Chr(10) & "            ����������ԍ� "
			strSQL = strSQL & Chr(10) & "        HAVING "
			strSQL = strSQL & Chr(10) & "            SUM(�g�p�敪) = 0 "
			strSQL = strSQL & Chr(10) & "    ) "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				' �Y������f�[�^�����݂���ꍇ
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .eof = False Then

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					lngRet = gfncFieldCur(.Fields("�󂫌���").Value)

				End If

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objDysTemp = Nothing

			gfncGetCntBlankPerfectNum = lngRet

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
			'PROC_END:

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:782e0461-ba6c-411e-b7c7-d5d02955b0fe
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
PROC_FINALLY_END:
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'******************************************************************************
	' �� �� ��  : gfncRegisterTblNyuukinPGWork
	' �X�R�[�v  : Public
	' �������e  : �����v���O�������[�N �o�^����
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���             �ް�����          I/O   �� ��
	'   --------------------+-----------------+-----+------------------------------
	'   pstrTableName        String            I     �v���O�������[�N��
	'   pstrMemberParentCode String            I     ����R�[�h
	'   pstrMemberBranchCode String            I     ����}�R�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncRegisterTblNyuukinPGWork(ByVal pstrTableName As String, Optional ByVal pstrMemberParentCode As String = "", Optional ByVal pstrMemberBranchCode As String = "", Optional ByVal pblnCommit As Boolean = True) As Boolean

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncRegisterTblNyuukinPGWork"
		Dim strSQL As String
		Dim lngStartTime As Integer
		Dim objDysTemp As OraDynaset
		Dim strLoginInfo As String
		Dim bln�������� As String
		Dim intFileNum As Integer
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			If gclsLoginInfo.EmployeeCode = "" Then
				strLoginInfo = "0000000"
			Else
				strLoginInfo = gclsLoginInfo.EmployeeCode
			End If

			If pstrTableName = "PG_WORK_USQ110" Then
				bln�������� = CStr(True)
			Else
				bln�������� = CStr(False)
			End If

			lngStartTime = timeGetTime()

			'//�ďo���������������̏ꍇ

			If CBool(bln��������) = True Then
				'//�����C���e�[�u���̍X�V�������ς���Ă��Ȃ����m�F 2015/12/18
				strSQL = ""
				strSQL = strSQL & Chr(10) & " SELECT "
				strSQL = strSQL & Chr(10) & "   to_char(SEI.�X�V���t����,'yyyymmddhh24miss') �X�V���t���� "
				strSQL = strSQL & Chr(10) & "   ,to_char(WK.�o�͌��X�V���t����,'yyyymmddhh24miss') �o�͌��X�V���t����    "
				strSQL = strSQL & Chr(10) & "   ,SEI.����       "
				strSQL = strSQL & Chr(10) & "   ,WK.�o�͌����� "
				strSQL = strSQL & Chr(10) & "   ,WK.�쐬���t���O   "
				strSQL = strSQL & Chr(10) & " FROM   "
				strSQL = strSQL & Chr(10) & "   ���[�N�쐬�󋵃e�[�u�� WK "
				strSQL = strSQL & Chr(10) & "   ,(SELECT "
				strSQL = strSQL & Chr(10) & "       MAX(�X�V���t����) �X�V���t����"
				strSQL = strSQL & Chr(10) & "       ,COUNT(1) ����"
				strSQL = strSQL & Chr(10) & "     FROM �����C���e�[�u��"
				strSQL = strSQL & Chr(10) & "     ) SEI"
				strSQL = strSQL & Chr(10) & " WHERE 1 = 1"
				strSQL = strSQL & Chr(10) & " AND WK.���[�N�e�[�u���� = '" & pstrTableName & "' "
				strSQL = strSQL & Chr(10) & " AND WK.�X�V�]�ƈ��R�[�h = '" & strLoginInfo & "' "

				'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

				With objDysTemp

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .eof = True Then
						'//�Y���f�[�^�Ȃ������[�N�쐬�󋵃e�[�u���ɑ}��

						strSQL = ""
						strSQL = strSQL & Chr(10) & "INSERT INTO ���[�N�쐬�󋵃e�[�u�� "
						strSQL = strSQL & Chr(10) & " ("
						strSQL = strSQL & Chr(10) & "    ���[�N�e�[�u���� "
						strSQL = strSQL & Chr(10) & "    ,�o�͌��X�V���t���� "
						strSQL = strSQL & Chr(10) & "    ,�o�͌����� "
						strSQL = strSQL & Chr(10) & "    ,�X�V���t���� "
						strSQL = strSQL & Chr(10) & "    ,�X�V�]�ƈ��R�[�h "
						strSQL = strSQL & Chr(10) & "    ,�쐬���t���O "
						strSQL = strSQL & Chr(10) & "    ,���l "
						strSQL = strSQL & Chr(10) & " ) VALUES ("
						strSQL = strSQL & Chr(10) & "'" & pstrTableName & "' "
						strSQL = strSQL & Chr(10) & "  , NULL"
						strSQL = strSQL & Chr(10) & "  , NULL"
						strSQL = strSQL & Chr(10) & "  , SYSDATE"
						strSQL = strSQL & Chr(10) & "  , '" & strLoginInfo & "' "
						strSQL = strSQL & Chr(10) & "  , 1"
						strSQL = strSQL & Chr(10) & "  , '�]�ƈ�" & strLoginInfo & "��' || " & "to_CHAR(SYSDATE,'yy/mm/dd')" & " || '�ɍ쐬' "
						strSQL = strSQL & Chr(10) & " )"
						'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call gobjOraDatabase.ExecuteSQL(strSQL)


						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf .Fields("�o�͌��X�V���t����").Value = .Fields("�X�V���t����").Value And .Fields("�o�͌�����").Value = .Fields("����").Value Then  '�ߋ��X�V���� OR �ߋ������ɍ��ق��Ȃ�

						' �߂�l��ݒ�i����I���j
						gfncRegisterTblNyuukinPGWork = False
						'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
						'GoTo PROC_END
						GoTo PROC_FINALLY_END
						'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf .Fields("�o�͌�����").Value = "1" Then  ' ���ݍ쐬������

						' �߂�l��ݒ�i����I���j
						gfncRegisterTblNyuukinPGWork = False
						'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
						'GoTo PROC_END
						GoTo PROC_FINALLY_END
						'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed

					ElseIf 1 = 1 Then  ' �ύX�L

						'//�Y���f�[�^���聨�쐬���t���O�P�ɂ��āA������X�V������ێ�����
						strSQL = ""
						strSQL = strSQL & Chr(10) & "UPDATE ���[�N�쐬�󋵃e�[�u�� "
						strSQL = strSQL & Chr(10) & "SET �쐬���t���O = 1 "
						strSQL = strSQL & Chr(10) & "  , �X�V�]�ƈ��R�[�h = '" & strLoginInfo & "' "
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						strSQL = strSQL & Chr(10) & "  , �o�͌��X�V���t���� = to_date('" & .Fields("�X�V���t����").Value & "','yyyymmddhh24miss') "
						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						strSQL = strSQL & Chr(10) & "  , �o�͌����� = " & .Fields("����").Value
						strSQL = strSQL & Chr(10) & "  , �X�V���t���� = SYSDATE "
						strSQL = strSQL & Chr(10) & "WHERE 1 = 1 "
						strSQL = strSQL & Chr(10) & "AND ���[�N�e�[�u���� = '" & pstrTableName & "' "
						strSQL = strSQL & Chr(10) & "AND �X�V�]�ƈ��R�[�h = '" & strLoginInfo & "' "
						strSQL = strSQL & Chr(10) & "AND �쐬���t���O <> 1 "
						'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call gobjOraDatabase.ExecuteSQL(strSQL)

					End If
				End With

			End If

			' �߂�l���������i�ُ�I���j
			gfncRegisterTblNyuukinPGWork = True

			'==========================================================================
			' �������̓��[�N�i�C�����f�[�^�j �쐬
			'==========================================================================
			strSQL = ""
			strSQL = strSQL & Chr(10) & "DECLARE "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "    CURSOR curSyuusei IS "
			strSQL = strSQL & Chr(10) & "    SELECT "
			strSQL = strSQL & Chr(10) & "        �ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "       ,�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "       ,�C���敪     "
			strSQL = strSQL & Chr(10) & "       ,������       "
			strSQL = strSQL & Chr(10) & "       ,���z�P       "
			strSQL = strSQL & Chr(10) & "    FROM "
			strSQL = strSQL & Chr(10) & "        �����C���e�[�u�� "

			If pstrMemberParentCode <> "" Then

				strSQL = strSQL & Chr(10) & "    WHERE "
				strSQL = strSQL & Chr(10) & "        �ڋq�R�[�h   = '" & pstrMemberParentCode & "' "

				If pstrMemberBranchCode <> "" Then

					strSQL = strSQL & Chr(10) & "    AND �ڋq�}�R�[�h = '" & pstrMemberBranchCode & "' "

				End If

			End If

			strSQL = strSQL & Chr(10) & "    ORDER BY "
			strSQL = strSQL & Chr(10) & "        ������; "
			strSQL = strSQL & Chr(10)

			strSQL = strSQL & Chr(10) & "    varShimebi VARCHAR2(8); " ' ��������
			strSQL = strSQL & Chr(10) & "    numUriage  NUMBER  (9); " ' ����z
			strSQL = strSQL & Chr(10) & "    numNyuukin NUMBER  (9); " ' �����z
			strSQL = strSQL & Chr(10) & "    numRecCnt  NUMBER  (4); " ' ����
			strSQL = strSQL & Chr(10)

			strSQL = strSQL & Chr(10) & "BEGIN "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     -- �v���O�������[�N����U�폜 "
			strSQL = strSQL & Chr(10) & "     DELETE " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "     WHERE "
			strSQL = strSQL & Chr(10) & "         �X�V�]�ƈ��R�[�h = '" & strLoginInfo & "'; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     numUriage := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     numNyuukin := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "     FOR recSyuusei IN curSyuusei LOOP "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         SELECT "
			strSQL = strSQL & Chr(10) & "             MIN(��������) "
			strSQL = strSQL & Chr(10) & "         INTO "
			strSQL = strSQL & Chr(10) & "             varShimebi "
			strSQL = strSQL & Chr(10) & "         FROM "
			strSQL = strSQL & Chr(10) & "             " & MC_TBL_�����e�[�u�� & " "
			strSQL = strSQL & Chr(10) & "         WHERE "
			strSQL = strSQL & Chr(10) & "             �ڋq�R�[�h   = recSyuusei.�ڋq�R�[�h "
			strSQL = strSQL & Chr(10) & "         AND �ڋq�}�R�[�h = recSyuusei.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "         AND ��������    >= recSyuusei.������; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         SELECT "
			strSQL = strSQL & Chr(10) & "             COUNT(*) "
			strSQL = strSQL & Chr(10) & "         INTO "
			strSQL = strSQL & Chr(10) & "             numRecCnt "
			strSQL = strSQL & Chr(10) & "         FROM "
			strSQL = strSQL & Chr(10) & "             " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "         WHERE "
			strSQL = strSQL & Chr(10) & "             �ڋq�R�[�h       = recSyuusei.�ڋq�R�[�h "
			strSQL = strSQL & Chr(10) & "         AND �ڋq�}�R�[�h     = recSyuusei.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "         AND ��������         = varShimebi "
			strSQL = strSQL & Chr(10) & "         AND �X�V�]�ƈ��R�[�h = '" & strLoginInfo & "' "
			strSQL = strSQL & Chr(10) & "             ; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         IF recSyuusei.�C���敪 = 0 THEN "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numUriage := recSyuusei.���z�P; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numNyuukin := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         ELSE "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numUriage := 0; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             numNyuukin := recSyuusei.���z�P; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         END IF; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         IF numRecCnt = 0 THEN  "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "            INSERT INTO " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "                ( "
			strSQL = strSQL & Chr(10) & "                    �ڋq�R�[�h       "
			strSQL = strSQL & Chr(10) & "                   ,�ڋq�}�R�[�h     "
			strSQL = strSQL & Chr(10) & "                   ,��������         "
			strSQL = strSQL & Chr(10) & "                   ,����C���z       "
			strSQL = strSQL & Chr(10) & "                   ,�����C���z       "
			strSQL = strSQL & Chr(10) & "                   ,�X�V�]�ƈ��R�[�h "
			strSQL = strSQL & Chr(10) & "                   ,�X�V���t����     "
			strSQL = strSQL & Chr(10) & "                ) "
			strSQL = strSQL & Chr(10) & "            VALUES "
			strSQL = strSQL & Chr(10) & "                ( "
			strSQL = strSQL & Chr(10) & "                    recSyuusei.�ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "                   ,recSyuusei.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "                   ,varShimebi              "
			strSQL = strSQL & Chr(10) & "                   ,numUriage               "
			strSQL = strSQL & Chr(10) & "                   ,numNyuukin              "
			strSQL = strSQL & Chr(10) & "                   ,'" & strLoginInfo & "'  "
			strSQL = strSQL & Chr(10) & "                   ,SYSDATE                 "
			strSQL = strSQL & Chr(10) & "                ); "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         ELSE "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "             UPDATE " & pstrTableName & " "
			strSQL = strSQL & Chr(10) & "             SET ����C���z       = ����C���z + numUriage "
			strSQL = strSQL & Chr(10) & "                ,�����C���z       = �����C���z + numNyuukin "
			strSQL = strSQL & Chr(10) & "             WHERE "
			strSQL = strSQL & Chr(10) & "                 �ڋq�R�[�h       = recSyuusei.�ڋq�R�[�h "
			strSQL = strSQL & Chr(10) & "             AND �ڋq�}�R�[�h     = recSyuusei.�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "             AND ��������         = varShimebi "
			strSQL = strSQL & Chr(10) & "             AND �X�V�]�ƈ��R�[�h = '" & strLoginInfo & "' "
			strSQL = strSQL & Chr(10) & "                 ; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "         END IF; "
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "    END LOOP; "
			strSQL = strSQL & Chr(10)

			If CBool(bln��������) = True Then
				'//�t���O�����ɖ߂�
				strSQL = strSQL & Chr(10) & "UPDATE ���[�N�쐬�󋵃e�[�u�� "
				strSQL = strSQL & Chr(10) & "SET �쐬���t���O = 0 "
				strSQL = strSQL & Chr(10) & "WHERE ���[�N�e�[�u���� = '" & pstrTableName & "' "
				strSQL = strSQL & Chr(10) & "  AND �X�V�]�ƈ��R�[�h = '" & strLoginInfo & "'; "

			End If

			'//�R�~�b�g���邩�ǂ����̑I������ǉ��BUSB01�i�����������j0�̂Ƃ��́A�R�~�b�g���Ȃ� '//2018/08/15
			If pblnCommit = True Then
				strSQL = strSQL & Chr(10) & "    COMMIT; "
			End If
			strSQL = strSQL & Chr(10)
			strSQL = strSQL & Chr(10) & "END; "

			' �f�o�b�O���[�h���P�i�f�o�b�O�j�̏ꍇ
#If DebugMode = 1 Then
		'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression DebugMode = 1 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
		
		
		intFileNum = FreeFile
		
		Open "C:\UsCommonFunction.SQL" For Output As #intFileNum
		Print #intFileNum, "--��-----------------------------------------------------------------------��--"
		Print #intFileNum, "--�� gfncRegisterTblNyuukinPGWork                                          ��--"
		Print #intFileNum, "--��-----------------------------------------------------------------------��--"
		Print #intFileNum, strSQL
		Close #intFileNum
		
#End If

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			Debug.Print(C_NAME_FUNCTION & ":" & (timeGetTime - lngStartTime) / 1000)

			' �߂�l��ݒ�i����I���j
			gfncRegisterTblNyuukinPGWork = False

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
			'PROC_END:

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:c414c5d2-2459-4e72-98da-1c6d1c6af5ed
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
PROC_FINALLY_END:
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'******************************************************************************
	' �� �� ��  : gfncUpdateTblSeikyuu_ProcessingFee
	' �X�R�[�v  : Public
	' �������e  : �����e�[�u�� �X�V(�����ϐ��������萔��)
	' ��    �l  :
	' �� �� �l  : True �i�ُ�I���j
	'             False�i����I���j
	' �� �� ��  :
	'   ���Ұ���             �ް�����          I/O   �� ��
	'   --------------------+-----------------+-----+------------------------------
	'   pstrSeikyuuShimebi   String            I     ��������
	'   pstrMemberParentCode String            I     ����R�[�h
	'   pstrMemberBranchCode String            I     ����}�R�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncUpdateTblSeikyuu_ProcessingFee(ByVal pstrSeikyuuShimebi As String, ByVal pstrMemberParentCode As String, ByVal pstrMemberBranchCode As String) As Boolean

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncUpdateTblSeikyuu_ProcessingFee"
		Dim curProcessingFee As Decimal ' �����ϐ��������萔��
		Dim objDysTemp As OraDynaset
		Dim strSQL As String
		Dim lngStartTime As Integer
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			lngStartTime = timeGetTime()

			' �߂�l���������i�ُ�I���j
			gfncUpdateTblSeikyuu_ProcessingFee = True

			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    �ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "   ,�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "   ,��������     "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    " & MC_TBL_�����e�[�u�� & " "

			If (Trim(pstrSeikyuuShimebi) <> "") Then

				strSQL = strSQL & Chr(10) & "WHERE "
				strSQL = strSQL & Chr(10) & "    ��������     = '" & pstrSeikyuuShimebi & "' "

				If (Trim(pstrMemberParentCode) <> "") Then

					strSQL = strSQL & Chr(10) & "AND �ڋq�R�[�h   = '" & pstrMemberParentCode & "' "

					If (Trim(pstrMemberBranchCode) <> "") Then

						strSQL = strSQL & Chr(10) & "AND �ڋq�}�R�[�h = '" & pstrMemberBranchCode & "' "

					End If

				End If

			End If

			strSQL = strSQL & Chr(10) & "ORDER BY "
			strSQL = strSQL & Chr(10) & "    �ڋq�R�[�h   "
			strSQL = strSQL & Chr(10) & "   ,�ڋq�}�R�[�h "
			strSQL = strSQL & Chr(10) & "   ,��������     "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Do Until .eof = True

					'------------------------------------------------------------------
					' �����ώ����萔�� �v�Z
					'------------------------------------------------------------------
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(�ڋq�}�R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(�ڋq�R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					curProcessingFee = mfncCalProcessingFee(gfncFieldVal(.Fields("��������").Value), gfncFieldVal(.Fields("�ڋq�R�[�h").Value), gfncFieldVal(.Fields("�ڋq�}�R�[�h").Value))

					'------------------------------------------------------------------
					' �����ώ����萔�� �X�V
					'------------------------------------------------------------------
					strSQL = ""
					strSQL = strSQL & Chr(10) & "UPDATE " & MC_TBL_�����e�[�u�� & " "
					strSQL = strSQL & Chr(10) & "SET �����ϐ��������萔�� = " & curProcessingFee & " "
					strSQL = strSQL & Chr(10) & "WHERE "
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(�ڋq�R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSQL = strSQL & Chr(10) & "    �ڋq�R�[�h           = '" & gfncFieldVal(.Fields("�ڋq�R�[�h").Value) & "' "
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(�ڋq�}�R�[�h).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSQL = strSQL & Chr(10) & "AND �ڋq�}�R�[�h         = '" & gfncFieldVal(.Fields("�ڋq�}�R�[�h").Value) & "' "
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(��������).Value). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					strSQL = strSQL & Chr(10) & "AND ��������             = '" & gfncFieldVal(.Fields("��������").Value) & "' "

					'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call gobjOraDatabase.ExecuteSQL(strSQL)

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call .MoveNext()

				Loop

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			Debug.Print(C_NAME_FUNCTION & ":" & (timeGetTime - lngStartTime) / 1000)

			' �߂�l��ݒ�i����I���j
			gfncUpdateTblSeikyuu_ProcessingFee = False

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
			'PROC_END:

			'Call gsubClearObject(objDysTemp)

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:21a7a4ea-980e-4a0b-9fd8-77f589d8013d
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'******************************************************************************
	' �� �� ��  : mfncCalProcessingFee
	' �X�R�[�v  : Private
	' �������e  : �����ώ����萔�� �v�Z
	' ��    �l  :
	' �� �� �l  : �����ώ����萔��
	' �� �� ��  :
	'   ���Ұ���             �ް�����          I/O   �� ��
	'   --------------------+-----------------+-----+------------------------------
	'   pstrSeikyuuShimebi   String            I     ��������
	'   pstrMemberParentCode String            I     ����R�[�h
	'   pstrMemberBranchCode String            I     ����}�R�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  �A��  �F��         �V�K�쐬
	'   02.33.00    2010/03/24  �A��  �F��         �O��̒��������f�[�^�����݂��Ȃ��ꍇ��,
	'                                              �����ϐ��������萔�����擾�ł��Ȃ��Ȃ�s��ɑΉ��B
	'
	'******************************************************************************
	Private Function mfncCalProcessingFee(ByVal pstrSeikyuuShimebi As String, ByVal pstrMemberParentCode As String, ByVal pstrMemberBranchCode As String) As Decimal

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "mfncCalProcessingFee"
		Dim curRet As Decimal
		Dim strStartDate As String ' �J�n���t
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			' �߂�l��������
			curRet = 0

			'--------------------------------------------------------------------------
			' �J�n���t �擾
			'--------------------------------------------------------------------------
			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    TO_CHAR( "
			strSQL = strSQL & Chr(10) & "        TO_DATE( "
			strSQL = strSQL & Chr(10) & "            MAX(��������) "
			strSQL = strSQL & Chr(10) & "           ,'YYYYMMDD'    "
			strSQL = strSQL & Chr(10) & "        ) + 1 "
			strSQL = strSQL & Chr(10) & "       ,'YYYYMMDD' "
			strSQL = strSQL & Chr(10) & "    ) AS �J�n�� "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    " & MC_TBL_�����e�[�u�� & " "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    �ڋq�R�[�h   = '" & pstrMemberParentCode & "' "
			strSQL = strSQL & Chr(10) & "AND �ڋq�}�R�[�h = '" & pstrMemberBranchCode & "' "
			strSQL = strSQL & Chr(10) & "AND ��������     < '" & pstrSeikyuuShimebi & "' "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				' �Y������f�[�^�����݂���ꍇ
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .eof = False Then

                    ' �J�n�����u�����N�ȊO�̏ꍇ
                    'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(objDysTemp.Fields(�J�n��)). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If gfncFieldVal(.Fields("�J�n��").Value) <> "" Then

                        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        strStartDate = gfncFieldVal(.Fields("�J�n��").Value)

                        ' �J�n�����u�����N�̏ꍇ
                    Else

                        strStartDate = "00000000"

					End If

				End If

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objDysTemp = Nothing

			'--------------------------------------------------------------------------
			' ������ �����萔�� �Z�o
			'--------------------------------------------------------------------------
			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT DISTINCT "
			strSQL = strSQL & Chr(10) & "    �����ԍ� "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    �������׃e�[�u�� "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    �ڋq�R�[�h   = '" & pstrMemberParentCode & "' "
			strSQL = strSQL & Chr(10) & "AND �ڋq�}�R�[�h = '" & pstrMemberBranchCode & "' "
			strSQL = strSQL & Chr(10) & "AND �c�Ɠ�      >= '" & strStartDate & "' "
			strSQL = strSQL & Chr(10) & "AND �c�Ɠ�      <= '" & pstrSeikyuuShimebi & "' "
			strSQL = strSQL & Chr(10) & "AND �����ԍ�    IS NOT NULL "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Do Until .eof = True

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					curRet = curRet + mfncGetProcessingFee(pstrSeikyuuShimebi, strStartDate, gfncFieldVal(.Fields("�����ԍ�").Value))

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call .MoveNext()

				Loop
			End With
			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
			'PROC_END:

			'End With

			'Call gsubClearObject(objDysTemp)

			'mfncCalProcessingFee = curRet

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a0b86ba0-31c1-41ee-9ee4-52ad1f68107f
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a2076f46-8f74-4813-91c9-5dbb043ebe18

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
PROC_FINALLY_END:

		Call gsubClearObject(objDysTemp)
		mfncCalProcessingFee = curRet
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

	End Function
	'******************************************************************************
	' �� �� ��  : mfncGetProcessingFee
	' �X�R�[�v  : Private
	' �������e  : �����ώ����萔�� �擾
	' ��    �l  :
	' �� �� �l  : �����ώ����萔��
	' �� �� ��  :
	'   ���Ұ���             �ް�����          I/O   �� ��
	'   --------------------+-----------------+-----+------------------------------
	'   pstrSeikyuuShimebi   String            I     ��������
	'   pstrStartDate        String            I     �J�n���t
	'   pstrBillNum          String            I     �����ԍ�
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.00.00    2009/08/21  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Private Function mfncGetProcessingFee(ByVal pstrSeikyuuShimebi As String, ByVal pstrStartDate As String, ByVal pstrBillNum As String) As Decimal

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "mfncGetProcessingFee"
		Dim curRet As Decimal
		Dim astrWorkDate(GC_IDX_END) As String ' �c�Ɠ��i���`���j
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'UPGRADE_WARNING: Lower bound of array astrWorkDate was changed from GC_IDX_STA to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			' �߂�l��������
			curRet = 0

			'--------------------------------------------------------------------------
			' �c�Ɠ��i���`���j�擾
			'--------------------------------------------------------------------------
			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    MIN(�c�Ɠ�)   AS WorkDateSta "
			strSQL = strSQL & Chr(10) & "   ,MAX(�c�Ɠ�)   AS WorkDateEnd "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    �����������e�[�u��"
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    �����ԍ� = " & pstrBillNum & " "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				astrWorkDate(GC_IDX_STA) = gfncFieldVal(.Fields("WorkDateSta").Value)
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				astrWorkDate(GC_IDX_END) = gfncFieldVal(.Fields("WorkDateEnd").Value)

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			objDysTemp = Nothing

			'--------------------------------------------------------------------------
			' �����ώ����萔�� �擾
			'--------------------------------------------------------------------------
			' �������� �� �c�Ɠ��i���j�̏ꍇ
			If (pstrSeikyuuShimebi >= astrWorkDate(GC_IDX_END)) Then

				'----------------------------------------------------------------------
				' �Ώې������ׂ�, ���ׂĂP���������Ɋ܂܂�Ă���ꍇ
				'----------------------------------------------------------------------
				If (astrWorkDate(GC_IDX_STA) >= pstrStartDate) Then

					strSQL = ""
					strSQL = strSQL & Chr(10) & "SELECT "
					strSQL = strSQL & Chr(10) & "    ZST.���������萔��                       "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔����                         "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔��                           "
					strSQL = strSQL & Chr(10) & "   ,TRUNC( "
					strSQL = strSQL & Chr(10) & "        SUM( "
					strSQL = strSQL & Chr(10) & "            ZSST.�斱�����z     + "
					strSQL = strSQL & Chr(10) & "            ZSST.���֋��z       + "
					strSQL = strSQL & Chr(10) & "            ZSST.�p��b�K�C�h��   "
					strSQL = strSQL & Chr(10) & "        ) * "
					strSQL = strSQL & Chr(10) & "        ZST.�����萔���� / "
					strSQL = strSQL & Chr(10) & "        100 "
					strSQL = strSQL & Chr(10) & "    )                  AS �������������萔�� "
					strSQL = strSQL & Chr(10) & "FROM "
					strSQL = strSQL & Chr(10) & "    ���������e�[�u��   ZST  "
					strSQL = strSQL & Chr(10) & "   ,�����������e�[�u�� ZSST "
					strSQL = strSQL & Chr(10) & "WHERE "
					strSQL = strSQL & Chr(10) & "    ZST.�����ԍ�  = ZSST.�����ԍ� "
					strSQL = strSQL & Chr(10) & "AND ZST.�����ԍ�  = " & pstrBillNum & " "
					strSQL = strSQL & Chr(10) & "AND ZSST.�c�Ɠ�  >= '" & pstrStartDate & "' "
					strSQL = strSQL & Chr(10) & "GROUP BY "
					strSQL = strSQL & Chr(10) & "    ZST.���������萔�� "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔����   "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔��     "

					'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

					With objDysTemp

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						curRet = gfncFieldCur(.Fields("���������萔��").Value)

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call .Close()

					End With

					'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					objDysTemp = Nothing

					'----------------------------------------------------------------------
					' �w����������ȑO�̐������ׂ����݂���ꍇ
					'----------------------------------------------------------------------
				Else

					strSQL = ""
					strSQL = strSQL & Chr(10) & " SELECT"
					strSQL = strSQL & Chr(10) & "    ZST.���������萔��                       "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔����                         "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔��                           "
					strSQL = strSQL & Chr(10) & "   ,TRUNC( "
					strSQL = strSQL & Chr(10) & "        SUM( "
					strSQL = strSQL & Chr(10) & "            ZSST.�斱�����z     + "
					strSQL = strSQL & Chr(10) & "            ZSST.���֋��z       + "
					strSQL = strSQL & Chr(10) & "            ZSST.�p��b�K�C�h��   "
					strSQL = strSQL & Chr(10) & "        ) * "
					strSQL = strSQL & Chr(10) & "        ZST.�����萔���� / "
					strSQL = strSQL & Chr(10) & "        100 "
					strSQL = strSQL & Chr(10) & "    )                  AS �������������萔�� "
					strSQL = strSQL & Chr(10) & "FROM "
					strSQL = strSQL & Chr(10) & "    ���������e�[�u��   ZST  "
					strSQL = strSQL & Chr(10) & "   ,�����������e�[�u�� ZSST "
					strSQL = strSQL & Chr(10) & "WHERE "
					strSQL = strSQL & Chr(10) & "    ZST.�����ԍ�  = ZSST.�����ԍ� "
					strSQL = strSQL & Chr(10) & "AND ZST.�����ԍ�  = " & pstrBillNum & " "
					strSQL = strSQL & Chr(10) & "AND ZSST.�c�Ɠ�  <  '" & pstrStartDate & "' "
					strSQL = strSQL & Chr(10) & "GROUP BY "
					strSQL = strSQL & Chr(10) & "    ZST.���������萔�� "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔����   "
					strSQL = strSQL & Chr(10) & "   ,ZST.�����萔��     "

					'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

					With objDysTemp

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If (gfncFieldCur(.Fields("�����萔����").Value) <> 0) Then

							'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							curRet = gfncFieldCur(.Fields("���������萔��").Value) - gfncFieldCur(.Fields("�������������萔��").Value)

						End If

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Call .Close()

					End With

					'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
					objDysTemp = Nothing

				End If

				' �������� �� �c�Ɠ��i���j�̏ꍇ
			Else

				strSQL = ""
				strSQL = strSQL & Chr(10) & "SELECT "
				strSQL = strSQL & Chr(10) & "    ZST.���������萔��                       "
				strSQL = strSQL & Chr(10) & "   ,ZST.�����萔����                         "
				strSQL = strSQL & Chr(10) & "   ,ZST.�����萔��                           "
				strSQL = strSQL & Chr(10) & "   ,TRUNC( "
				strSQL = strSQL & Chr(10) & "        SUM( "
				strSQL = strSQL & Chr(10) & "            ZSST.�斱�����z     + "
				strSQL = strSQL & Chr(10) & "            ZSST.���֋��z       + "
				strSQL = strSQL & Chr(10) & "            ZSST.�p��b�K�C�h��   "
				strSQL = strSQL & Chr(10) & "        ) * "
				strSQL = strSQL & Chr(10) & "        ZST.�����萔���� / "
				strSQL = strSQL & Chr(10) & "        100 "
				strSQL = strSQL & Chr(10) & "    )                  AS �������������萔�� "
				strSQL = strSQL & Chr(10) & "FROM "
				strSQL = strSQL & Chr(10) & "    ���������e�[�u��   ZST  "
				strSQL = strSQL & Chr(10) & "   ,�����������e�[�u�� ZSST "
				strSQL = strSQL & Chr(10) & "WHERE "
				strSQL = strSQL & Chr(10) & "    ZST.�����ԍ�  = ZSST.�����ԍ� "
				strSQL = strSQL & Chr(10) & "AND ZST.�����ԍ�  = " & pstrBillNum & " "
				strSQL = strSQL & Chr(10) & "AND ZSST.�c�Ɠ�  >= '" & pstrStartDate & "' "
				strSQL = strSQL & Chr(10) & "AND ZSST.�c�Ɠ�  <= '" & pstrSeikyuuShimebi & "' "
				strSQL = strSQL & Chr(10) & "GROUP BY "
				strSQL = strSQL & Chr(10) & "    ZST.���������萔�� "
				strSQL = strSQL & Chr(10) & "   ,ZST.�����萔����   "
				strSQL = strSQL & Chr(10) & "   ,ZST.�����萔��     "

				'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

				With objDysTemp

					' �����萔�����O�~�̏ꍇ
					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If (gfncFieldCur(.Fields("�����萔����").Value) <> 0) Then

						'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						curRet = gfncFieldCur(.Fields("�������������萔��").Value)

						' �����萔�����O�~�ȊO�̏ꍇ
					Else

						' �c�Ɠ��i���j�� �J�n���t�̏ꍇ
						If (astrWorkDate(GC_IDX_STA) >= pstrStartDate) Then

							'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							curRet = gfncFieldCur(.Fields("���������萔��").Value)

						End If

					End If

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call .Close()

				End With

				'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				objDysTemp = Nothing

			End If

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
			'PROC_END:

			'Call gsubClearObject(objDysTemp)

			' �߂�l��ݒ�
			'mfncGetProcessingFee = curRet

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a2076f46-8f74-4813-91c9-5dbb043ebe18
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		mfncGetProcessingFee = curRet
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'******************************************************************************
	' �� �� ��  : gfncGetEndMonthDate
	' �X�R�[�v  : Public
	' �������e  : �������t �擾
	' ��    �l  :
	' �� �� �l  : �������t
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrDate            String            I     ���t
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00       2008/09/24  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetEndMonthDate(ByVal pstrDate As String) As String

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetEndMonthDate"
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			gfncGetEndMonthDate = CStr(System.Date.FromOADate(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, CDate(VB6.Format(Left(pstrDate, 6), "0000\/00\/") & "01")).ToOADate - 1))

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
			'PROC_END:

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:34b2aa4b-74a8-402f-8a8e-fac6d847fb5b
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
PROC_FINALLY_END:
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function
	'******************************************************************************
	' �� �� ��  : gfncGetBankKbn
	' �X�R�[�v  : Public
	' �������e  : ��s�敪 �擾
	' ��    �l  :
	' �� �� �l  : ��s�敪
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pstrBankCode        String            I     ��s�R�[�h
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00.00    2008/09/24  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetBankKbn(ByVal pstrBankCode As String) As Short

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gfncGetBankKbn"
		Dim strSQL As String
		Dim objDysTemp As OraDynaset
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			gfncGetBankKbn = GC_BANK_KBN_MK_NORMAL

			strSQL = ""
			strSQL = strSQL & Chr(10) & "SELECT "
			strSQL = strSQL & Chr(10) & "    ��s�敪 "
			strSQL = strSQL & Chr(10) & "FROM "
			strSQL = strSQL & Chr(10) & "    ��s�}�X�^ "
			strSQL = strSQL & Chr(10) & "WHERE "
			strSQL = strSQL & Chr(10) & "    ��s�R�[�h = '" & pstrBankCode & "' "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

			With objDysTemp

				' �Y������f�[�^�����݂���ꍇ
				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.eof. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .eof = False Then

					'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					gfncGetBankKbn = CShort(gfncFieldCur(.Fields("��s�敪").Value))

				End If

				'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Call .Close()

			End With

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
			'PROC_END:

			'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			'objDysTemp = Nothing

			'Exit Function

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:f8c23857-dc36-4368-9be3-7bfcd90ffd36
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:702b7f02-6377-45af-9bd9-96b14c668846
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:702b7f02-6377-45af-9bd9-96b14c668846

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:702b7f02-6377-45af-9bd9-96b14c668846
PROC_FINALLY_END:
		objDysTemp = Nothing
		Exit Function
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:702b7f02-6377-45af-9bd9-96b14c668846
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Function

	Public Function gfncGetStrJifuriAccount(ByVal pstrGinkoCode As String, ByVal pstrShitenCode As String, ByVal pstrKozaKind As String, ByVal pstrKozaNum As String, ByVal pstrKozaName As String) As String

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		'Dim objDysTemp As Object
		Dim objDysTemp As OraDynaset
		'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
		Dim strBankName As String
		Dim strBranchName As String
		Dim strSQL As String
		Dim strRet As String

		strSQL = ""
		strSQL = strSQL & Chr(10) & "SELECT "
		strSQL = strSQL & Chr(10) & "    GM.��s������ "
		strSQL = strSQL & Chr(10) & "  , SM.�x�X������ "
		strSQL = strSQL & Chr(10) & "FROM "
		strSQL = strSQL & Chr(10) & "    ��s�}�X�^ GM "
		strSQL = strSQL & Chr(10) & "  , �x�X�}�X�^ SM "
		strSQL = strSQL & Chr(10) & "WHERE "
		strSQL = strSQL & Chr(10) & "    GM.��s�R�[�h = SM.��s�R�[�h(+) "
		strSQL = strSQL & Chr(10) & "AND GM.��s�R�[�h = '" & pstrGinkoCode & "' "
		strSQL = strSQL & Chr(10) & "AND SM.�x�X�R�[�h = '" & pstrShitenCode & "' "

		'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

		With objDysTemp

			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strBankName = gfncFieldVal(.Fields("��s������").Value)

			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			strBranchName = gfncFieldVal(.Fields("�x�X������").Value)

			'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call .Close()

		End With

		'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		objDysTemp = Nothing

		Select Case Right(strBankName, 2)
			Case "����", "�M��", "�M��", "�g��", "�_��"

				' �����Ȃ�

			Case Else

				strBankName = strBankName & "��s"

		End Select

		If strBranchName = "�{�X" Then

			' �����Ȃ�

		ElseIf Right(strBranchName, 3) = "�o����" Then

			' �����Ȃ�

		ElseIf Right(strBranchName, 3) = "�c�ƕ�" Then

			' �����Ȃ�

		Else

			strBranchName = strBranchName & "�x�X"

		End If

		strRet = ""
		strRet = strRet & strBankName & " "
		strRet = strRet & strBranchName & " "

		If pstrKozaKind <> "" Then

			If CDbl(pstrKozaKind) = 1 Then

				strRet = strRet & "���� "

			Else

				strRet = strRet & "���� "

			End If

		End If

		strRet = strRet & pstrKozaNum & "  "
		strRet = strRet & pstrKozaName

		'=Debug.Print strRet

		gfncGetStrJifuriAccount = strRet

	End Function
	'******************************************************************************
	' �� �� ��  : gfncGetGinkoKoza
	' �X�R�[�v  : Public
	' �������e  : ��s�����ݒ菈��
	' ��    �l  :
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'   ���Ұ���            �ް�����          I/O   �� ��
	'   -------------------+-----------------+-----+-------------------------------
	'   pblnFlgJifuri       Boolean           I     �����U�փt���O
	'   pstrGinkoName       String            I     ��s��
	'   pstrSitenName       String            I     �x�X��
	'   pstrYokinKind       String            I     �a�����
	'   pstrKozaNumber      String            I     �����ԍ�
	'   pstrKozaMeigi       String            I     �������`
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   02.17.00    2009/01/08  �A��  �F��         �V�K�쐬
	'
	'******************************************************************************
	Public Function gfncGetGinkoKoza(ByVal pblnFlgJifuri As Boolean, ByVal pstrGinkoName As String, ByVal pstrSitenName As String, ByVal pstrYokinKind As String, ByVal pstrKozaNumber As String, ByVal pstrKozaMeigi As String) As String

		Const C_HIDE_CHAR As String = "*"
		Const C_HIDE_CHAR_LEN As Short = 3

		Dim strRet As String

		strRet = ""
		strRet = strRet & gfncEditNameBank(pstrGinkoName)
		strRet = strRet & "  "
		strRet = strRet & gfncEditNameBankBranch(pstrSitenName)
		strRet = strRet & "  "

		If pstrYokinKind <> "" Then

			If pstrYokinKind = "1" Then

				strRet = strRet & "����"

			Else

				strRet = strRet & "����"

			End If

			strRet = strRet & " "

		End If

		' �����U�փt���O��False(���U�ȊO)�̏ꍇ
		If pblnFlgJifuri = False Then

			strRet = strRet & pstrKozaNumber
			strRet = strRet & "  "
			strRet = strRet & pstrKozaMeigi

			' �����U�փt���O��True(���U)�̏ꍇ
			' (����̌����ԍ��̈�, �A�X�^���X�N�Ō����ԍ��𕚂���)
		Else

			' �����ԍ����擾�ł��Ă���ꍇ
			If pstrKozaNumber <> "" Then

				' �����ԍ����R���ȉ��̏ꍇ
				If Len(pstrKozaNumber) <= C_HIDE_CHAR_LEN Then

					strRet = strRet & "00000**"
					strRet = strRet & "  "
					strRet = strRet & pstrKozaMeigi

					' �����ԍ����S���ȏ�̏ꍇ
				Else

					strRet = strRet & Mid(pstrKozaNumber, 1, Len(pstrKozaNumber) - C_HIDE_CHAR_LEN)
					strRet = strRet & New String(C_HIDE_CHAR, C_HIDE_CHAR_LEN)
					strRet = strRet & "  "
					strRet = strRet & pstrKozaMeigi

				End If

				' �����ԍ����擾�ł��Ă��Ȃ��ꍇ
			Else

				strRet = strRet & "  "
				strRet = strRet & pstrKozaMeigi

			End If

		End If

		gfncGetGinkoKoza = strRet

	End Function

	'******************************************************************************
	' �� �� ��  : gsubInsTicketMeisaiRireki
	' �X�R�[�v  : Public
	' �������e  : �`�P�b�g���ח����̍쐬
	' ��    �l  : bln�C���O�t���O = True�ŁA�폜�O����}��������́A
	'             �X�V������ɕK��bln�C���O�t���O = False�ō폜��f�[�^���쐬���邱��
	'             �g�p�ꏊ�cBeginTran�̒���ɕύX�O���ACommitTran�̒���ɕύX������s����
	' �� �� �l  : �Ȃ�
	' �� �� ��  :
	'
	'// bln�C���O�t���O    : true:�C���O False:�C����
	'// str�������t����    �F�쐬�L�[
	'// str�����v���O�������F�쐬�L�[
	'// str�����]�ƈ��R�[�h�F�쐬�L�[
	'// str�c�Ɠ�          �F�f�[�^�擾�L�[
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00.00    2016/03/30  �j�r�q             �V�K�쐬
	'
	'******************************************************************************
	Public Sub gsubInsTicketMeisaiRireki(ByVal bln�C���O�t���O As Boolean, ByVal str�������t���� As String, ByVal str�����v���O������ As String, ByVal str�����]�ƈ��R�[�h As String, ByVal str�c�Ɠ� As String)

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gsubInsTicketMeisaiRireki"
		Dim objDysTemp As OraDynaset
		Dim strSQL As String
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			strSQL = ""
			strSQL = strSQL & Chr(10) & " INSERT INTO �`�P�b�g���ח����e�[�u�� "
			strSQL = strSQL & Chr(10) & "   ( "
			strSQL = strSQL & Chr(10) & "     �����敪           "
			strSQL = strSQL & Chr(10) & "    ,�������t����       "
			strSQL = strSQL & Chr(10) & "    ,�����v���O����     "
			strSQL = strSQL & Chr(10) & "    ,�����]�ƈ��R�[�h   "
			strSQL = strSQL & Chr(10) & "    ,�c�Ɠ�             "
			strSQL = strSQL & Chr(10) & "    ,�s�ԍ�             "
			strSQL = strSQL & Chr(10) & "    ,������             "
			strSQL = strSQL & Chr(10) & "    ,�����R�[�h         "
			strSQL = strSQL & Chr(10) & "    ,�V�t�g�敪         "
			strSQL = strSQL & Chr(10) & "    ,�����ԍ�           "
			strSQL = strSQL & Chr(10) & "    ,����               "
			strSQL = strSQL & Chr(10) & "    ,�}��               "
			strSQL = strSQL & Chr(10) & "    ,���q�敪           "
			strSQL = strSQL & Chr(10) & "    ,�]�ƈ��R�[�h       "
			strSQL = strSQL & Chr(10) & "    ,�����敪           "
			strSQL = strSQL & Chr(10) & "    ,�����R�[�h         "
			strSQL = strSQL & Chr(10) & "    ,�����}�R�[�h       "
			strSQL = strSQL & Chr(10) & "    ,�J�[�h�ԍ�         "
			strSQL = strSQL & Chr(10) & "    ,�������z           "
			strSQL = strSQL & Chr(10) & "    ,�斱�����z         "
			strSQL = strSQL & Chr(10) & "    ,�O����旿         "
			strSQL = strSQL & Chr(10) & "    ,�p��b�K�C�h��     "
			strSQL = strSQL & Chr(10) & "    ,���֋��z           "
			strSQL = strSQL & Chr(10) & "    ,�萔��             "
			strSQL = strSQL & Chr(10) & "    ,�萔���Ŕ�         "
			strSQL = strSQL & Chr(10) & "    ,�g��Ҍ����z       "
			strSQL = strSQL & Chr(10) & "    ,�X�V�]�ƈ��R�[�h   "
			strSQL = strSQL & Chr(10) & "    ,�X�V���t����       "
			strSQL = strSQL & Chr(10) & "    ,�W�v�ς݃t���O     "
			strSQL = strSQL & Chr(10) & "    ,�X�V�[���h�o       "
			strSQL = strSQL & Chr(10) & "    ,��ЃR�[�h         "
			strSQL = strSQL & Chr(10) & "    ,�����ԍ�           "
			strSQL = strSQL & Chr(10) & "    ,������             "
			strSQL = strSQL & Chr(10) & "    ,���l               "
			strSQL = strSQL & Chr(10) & "   ) "
			strSQL = strSQL & Chr(10) & "   SELECT "
			If bln�C���O�t���O = True Then
				strSQL = strSQL & Chr(10) & " 1 AS �����敪 "
			Else
				strSQL = strSQL & Chr(10) & " 0 AS �����敪 "
			End If
			strSQL = strSQL & Chr(10) & "    , TO_DATE('" & str�������t���� & "','YYYY/MM/DD HH24:MI:SS') AS �������t���� "
			strSQL = strSQL & Chr(10) & "    , '" & str�����v���O������ & "' AS �����v���O���� "
			strSQL = strSQL & Chr(10) & "    , '" & str�����]�ƈ��R�[�h & "' AS �����]�ƈ��R�[�h "
			strSQL = strSQL & Chr(10) & "    ,�c�Ɠ�             "
			strSQL = strSQL & Chr(10) & "    ,�s�ԍ�             "
			strSQL = strSQL & Chr(10) & "    ,������             "
			strSQL = strSQL & Chr(10) & "    ,�����R�[�h         "
			strSQL = strSQL & Chr(10) & "    ,�V�t�g�敪         "
			strSQL = strSQL & Chr(10) & "    ,�����ԍ�           "
			strSQL = strSQL & Chr(10) & "    ,����               "
			strSQL = strSQL & Chr(10) & "    ,�}��               "
			strSQL = strSQL & Chr(10) & "    ,���q�敪           "
			strSQL = strSQL & Chr(10) & "    ,�]�ƈ��R�[�h       "
			strSQL = strSQL & Chr(10) & "    ,�����敪           "
			strSQL = strSQL & Chr(10) & "    ,�����R�[�h         "
			strSQL = strSQL & Chr(10) & "    ,�����}�R�[�h       "
			strSQL = strSQL & Chr(10) & "    ,�J�[�h�ԍ�         "
			strSQL = strSQL & Chr(10) & "    ,�������z           "
			strSQL = strSQL & Chr(10) & "    ,�斱�����z         "
			strSQL = strSQL & Chr(10) & "    ,�O����旿         "
			strSQL = strSQL & Chr(10) & "    ,�p��b�K�C�h��     "
			strSQL = strSQL & Chr(10) & "    ,���֋��z           "
			strSQL = strSQL & Chr(10) & "    ,�萔��             "
			strSQL = strSQL & Chr(10) & "    ,�萔���Ŕ�         "
			strSQL = strSQL & Chr(10) & "    ,�g��Ҍ����z       "
			strSQL = strSQL & Chr(10) & "    ,�X�V�]�ƈ��R�[�h   "
			strSQL = strSQL & Chr(10) & "    ,�X�V���t����       "
			strSQL = strSQL & Chr(10) & "    ,�W�v�ς݃t���O     "
			strSQL = strSQL & Chr(10) & "    ,�X�V�[���h�o       "
			strSQL = strSQL & Chr(10) & "    ,��ЃR�[�h         "
			strSQL = strSQL & Chr(10) & "    ,�����ԍ�           "
			strSQL = strSQL & Chr(10) & "    ,������             "
			strSQL = strSQL & Chr(10) & "    ,���l               "
			strSQL = strSQL & Chr(10) & "   FROM �`�P�b�g���׃e�[�u�� "
			strSQL = strSQL & Chr(10) & "   WHERE 1 = 1 "
			strSQL = strSQL & Chr(10) & "     AND �c�Ɠ� = '" & str�c�Ɠ� & "' "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)

			If bln�C���O�t���O = False Then
				'//�C����̏ꍇ�A�d�������̍폜
				gsubDelTicketMeisaiRireki((str�������t����))
			End If

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:702b7f02-6377-45af-9bd9-96b14c668846
			'PROC_END:

			'Call gsubClearObject(objDysTemp)
			'Exit Sub

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:702b7f02-6377-45af-9bd9-96b14c668846
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		Exit Sub
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub

	'******************************************************************************
	' �� �� ��  : gsubDelTicketMeisaiRireki
	' �X�R�[�v  : Public
	' �������e  : �`�P�b�g���ח����̍폜
	' ��    �l  : �C���O�E�C����ŕω����Ȃ������s�ɑ΂��āA�X�V�������폜����
	' �� �� �l  : �Ȃ�
	' �� �� ��  : str�������t����
	'
	' �ύX����  :
	'   Version     ��  �t      ��  ��             �C�����e
	'   -----------+-----------+------------------+--------------------------------
	'   01.00.00    2016/03/30  �j�r�q             �V�K�쐬
	'
	'******************************************************************************
	Public Sub gsubDelTicketMeisaiRireki(ByVal str�������t���� As String)

		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		'On Error GoTo PROC_ERROR
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Const C_NAME_FUNCTION As String = "gsubDelTicketMeisaiRireki"
		Dim objDysTemp As OraDynaset
		Dim strSQL As String
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_530 VB��VB.NET�ϊ�
		Try
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
			'Dim objDysTemp As Object
			'--�C���I���@2021�N06��03:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

			strSQL = ""
			strSQL = strSQL & Chr(10) & " DELETE FROM �`�P�b�g���ח����e�[�u�� T1   "
			strSQL = strSQL & Chr(10) & " WHERE 1 = 1   "
			strSQL = strSQL & Chr(10) & " AND TO_CHAR(�������t����,'YYYY/MM/DD HH24:MI:SS') >= '" & str�������t���� & "'   "
			strSQL = strSQL & Chr(10) & " AND (   "
			strSQL = strSQL & Chr(10) & "    T1.�������t����        "
			strSQL = strSQL & Chr(10) & "   ,T1.�����]�ƈ��R�[�h    "
			strSQL = strSQL & Chr(10) & "   ,T1.�c�Ɠ�              "
			strSQL = strSQL & Chr(10) & "   ,T1.�s�ԍ�              "
			strSQL = strSQL & Chr(10) & " ) IN    "
			strSQL = strSQL & Chr(10) & " (" '-- �����敪�E�X�V�]�ƈ��R�[�h�E�X�V���t�����E�X�V�[���h�o���������ڑS�Ă�Grop�����āA2��������́i���X�V�O�E�X�V��ɕω����������́j�𒊏o
			strSQL = strSQL & Chr(10) & "   SELECT   "
			strSQL = strSQL & Chr(10) & "        �������t����       "
			strSQL = strSQL & Chr(10) & "       ,�����]�ƈ��R�[�h   "
			strSQL = strSQL & Chr(10) & "       ,�c�Ɠ�             "
			strSQL = strSQL & Chr(10) & "       ,�s�ԍ�             "
			strSQL = strSQL & Chr(10) & "   FROM   "
			strSQL = strSQL & Chr(10) & "       �`�P�b�g���ח����e�[�u�� TMR   "
			strSQL = strSQL & Chr(10) & "   WHERE TO_CHAR(�������t����,'YYYY/MM/DD HH24:MI:SS') >= '" & str�������t���� & "'   "
			strSQL = strSQL & Chr(10) & "   GROUP BY   "
			strSQL = strSQL & Chr(10) & "        �������t����       "
			strSQL = strSQL & Chr(10) & "       ,�����]�ƈ��R�[�h   "
			strSQL = strSQL & Chr(10) & "       ,�]�ƈ��R�[�h       "
			strSQL = strSQL & Chr(10) & "       ,�c�Ɠ�             "
			strSQL = strSQL & Chr(10) & "       ,�s�ԍ�             "
			strSQL = strSQL & Chr(10) & "       ,������             "
			strSQL = strSQL & Chr(10) & "       ,�����R�[�h         "
			strSQL = strSQL & Chr(10) & "       ,�V�t�g�敪         "
			strSQL = strSQL & Chr(10) & "       ,�����ԍ�           "
			strSQL = strSQL & Chr(10) & "       ,NVL(����,0)        "
			strSQL = strSQL & Chr(10) & "       ,NVL(�}��,0)        "
			strSQL = strSQL & Chr(10) & "       ,���q�敪           "
			strSQL = strSQL & Chr(10) & "       ,�]�ƈ��R�[�h       "
			strSQL = strSQL & Chr(10) & "       ,�����敪           "
			strSQL = strSQL & Chr(10) & "       ,�����R�[�h         "
			strSQL = strSQL & Chr(10) & "       ,�����}�R�[�h       "
			strSQL = strSQL & Chr(10) & "       ,�J�[�h�ԍ�         "
			strSQL = strSQL & Chr(10) & "       ,NVL(�������z,0)       "
			strSQL = strSQL & Chr(10) & "       ,NVL(�斱�����z,0)     "
			strSQL = strSQL & Chr(10) & "       ,NVL(�O����旿,0)     "
			strSQL = strSQL & Chr(10) & "       ,NVL(�p��b�K�C�h��,0) "
			strSQL = strSQL & Chr(10) & "       ,NVL(���֋��z,0)       "
			strSQL = strSQL & Chr(10) & "       ,NVL(�萔��,0)         "
			strSQL = strSQL & Chr(10) & "       ,NVL(�萔���Ŕ�,0)     "
			strSQL = strSQL & Chr(10) & "       ,NVL(�g��Ҍ����z,0)   "
			'strSQL = strSQL & Chr(10) & "       ,�X�V�]�ƈ��R�[�h   "
			'strSQL = strSQL & Chr(10) & "       ,�X�V���t����       "
			strSQL = strSQL & Chr(10) & "       ,�W�v�ς݃t���O     "
			'strSQL = strSQL & Chr(10) & "       ,�X�V�[���h�o       "
			strSQL = strSQL & Chr(10) & "       ,��ЃR�[�h         "
			strSQL = strSQL & Chr(10) & "       ,�����ԍ�           "
			strSQL = strSQL & Chr(10) & "       ,NVL(������,0)      "
			strSQL = strSQL & Chr(10) & "       ,���l               "
			strSQL = strSQL & Chr(10) & "   HAVING COUNT(1) = 2   " '�ω����Ȃ���ΕK���Q������
			strSQL = strSQL & Chr(10) & " )    "

			'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.ExecuteSQL. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Call gobjOraDatabase.ExecuteSQL(strSQL)


			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
			'PROC_END:

			'Call gsubClearObject(objDysTemp)
			'Exit Sub

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
			'PROC_ERROR:
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:b8ea73a2-c44d-457a-8ecc-1c682123f8c8
		Catch ex As Exception
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�

			Call MsgBox(Err.Description, MsgBoxStyle.Critical, C_NAME_FUNCTION)
			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7
			'Resume PROC_END
			'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7

			'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
		End Try
		'++�C���J�n�@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7
PROC_FINALLY_END:
		Call gsubClearObject(objDysTemp)
		Exit Sub
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_523 VB��VB.NET�ϊ�	T:a1e07d84-57e7-4e0e-9611-9978e615e3e7
		'--�C���I���@2021�N06��03:MK�i�c�[���j- VB_522 VB��VB.NET�ϊ�
	End Sub

    ''' <summary>
    ''' �������̂��e�[�u���̓o�^�֐�
    ''' </summary>
    ''' <param name="strTableName"></param>
    ''' <param name="strInvoiceNo"></param>
    ''' <param name="��������A��"></param>
    ''' <param name="�łP���㍇�v"></param>
    ''' <param name="�łP�Ōv"></param>
    ''' <param name="�łQ���㍇�v"></param>
    ''' <param name="�łQ�Ōv"></param>
    ''' <param name="�s�ېŔ��㍇�v"></param>
    ''' <returns></returns>
    Public Function InsertInvoiceOther(strTableName As String,
                                  strInvoiceNo As String,
                                  ��������A�� As Int64,
                                  �łP�ŋ����v As Double, '�W���Ώ�
                                  �łP�Ōv As Double, '�W���Ŋz
                                  �łQ�ŋ����v As Double,'10���Ώ�
                                  �łQ�Ōv As Double,'10���Ŋz
                                  �s�ېŔ��㍇�v As Double '0���Ώ�
                                  ) As Boolean
        Dim strSQL As String

        Try

            '----------------------------------------------------------
            '�������̑��e�[�u�� �폜
            '----------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "DELETE " & strTableName & " "
            strSQL = strSQL & Chr(10) & "WHERE "
            strSQL = strSQL & Chr(10) & "    �����ԍ�   = '" & strInvoiceNo & "' "
            Call gobjOraDatabase.ExecuteSQL(strSQL)

            '----------------------------------------------------------
            '�������̑��e�[�u�� �o�^
            '----------------------------------------------------------
            strSQL = ""
            strSQL = strSQL & Chr(10) & "INSERT INTO " & strTableName & " "
            strSQL = strSQL & Chr(10) & "   ( "
            strSQL = strSQL & Chr(10) & "      �����ԍ�"
            strSQL = strSQL & Chr(10) & "     ,��������A��"
            strSQL = strSQL & Chr(10) & "     ,�łP���㍇�v"
            strSQL = strSQL & Chr(10) & "     ,�łP�ŗ�"
            strSQL = strSQL & Chr(10) & "     ,�łP�Ōv"
            strSQL = strSQL & Chr(10) & "     ,�łQ���㍇�v"
            strSQL = strSQL & Chr(10) & "     ,�łQ�ŗ�"
            strSQL = strSQL & Chr(10) & "     ,�łQ�Ōv"
            strSQL = strSQL & Chr(10) & "     ,�s�ېŔ��㍇�v"
            strSQL = strSQL & Chr(10) & "     ,�X�V�]�ƈ��R�[�h"
            strSQL = strSQL & Chr(10) & "     ,�X�V���t����"
            strSQL = strSQL & Chr(10) & "   ) "
            strSQL = strSQL & Chr(10) & "   VALUES "
            strSQL = strSQL & Chr(10) & "   ( "
            strSQL = strSQL & Chr(10) & "     " & strInvoiceNo
            strSQL = strSQL & Chr(10) & "     ," & ��������A��
            strSQL = strSQL & Chr(10) & "     ," & �łP�ŋ����v
            strSQL = strSQL & Chr(10) & "     ," & 8.0
            strSQL = strSQL & Chr(10) & "     ," & �łP�Ōv
            strSQL = strSQL & Chr(10) & "     ," & �łQ�ŋ����v
            strSQL = strSQL & Chr(10) & "     ," & 10.0
            strSQL = strSQL & Chr(10) & "     ," & �łQ�Ōv
            strSQL = strSQL & Chr(10) & "     ," & �s�ېŔ��㍇�v
            strSQL = strSQL & Chr(10) & "     ,'" & gclsLoginInfo.EmployeeCode & "'"
            strSQL = strSQL & Chr(10) & "     ,SYSDATE"
            strSQL = strSQL & Chr(10) & "   ) "
            Call gobjOraDatabase.ExecuteSQL(strSQL)
            Return False

        Catch ex As Exception
            Return True
        End Try
    End Function
End Module
