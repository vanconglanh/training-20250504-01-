Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basLogin
	
	'++�C���J�n�@2021�N05��31:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
	'Public gobjOraSession As Object ' Oracle
	Public gobjOraSession As OraSession ' Oracle
	'--�C���I���@2021�N05��31:MK�i�c�[���j- OR_005 VB��VB.NET�ϊ�
	'++�C���J�n�@2021�N05��31:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
	'Public gobjOraDatabase As Object ' Oracle
	Public gobjOraDatabase As OraDatabase ' Oracle
	'--�C���I���@2021�N05��31:MK�i�c�[���j- OR_002 VB��VB.NET�ϊ�
	Public gvntLoginDate As Object ' ���O�C�����t
	Public gstrCompanyCode As String ' ��ЃR�[�h
	Public gstrPostCode As String ' �����R�[�h
	Public gstrEmployeeCode As String ' �]�ƈ��R�[�h
	Public gstrEmployeeName As String ' �]�ƈ���
	Public gintSystemAuthority As Short ' �V�X�e������
	Public gstrRank As String ' �����N
	Public gintOfficialPosition As Short ' ��E��
	Public gintOkCancel As Short
End Module
