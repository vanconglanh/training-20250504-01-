Option Strict Off
Option Explicit On
Imports MKOra.Core
Module basGetRengeNyukoSyuko
    '******************************************************************************
    ' �� �� ��  : gsubGetRengeNyukoSyuko
    ' �X�R�[�v  : Private
    ' �������e  : ���o�ɔ͈͎���  �擾
    ' ��    �l  :
    ' �� �� �l  : �Ȃ�
    ' �� �� ��  :
    '   ���Ұ���            �ް�����          I/O   �� ��
    '   -------------------+-----------------+-----+-------------------------------
    '   pstrEigyobiSta      String            I     �c�Ɠ��i���j
    '   pstrEigyobiEnd      String            I     �c�Ɠ��i���j
    '   pstrSyukkoDate      String            O     �o�ɓ���
    '   pstrNyukkoDate      String            O     ���ɓ���
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/11/04  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    Public Sub gsubGetRengeNyukoSyuko(ByVal pstrEigyobiSta As String, ByVal pstrEigyobiEnd As String, ByRef pstrSyukkoDate As String, ByRef pstrNyukkoDate As String)

        Dim strSQL As String
        '++�C���J�n�@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�
        'Dim objDysTemp As Object
        Dim objDysTemp As OraDynaset
        '--�C���I���@2021�N05��27:MK�i�c�[���j- OR_003 VB��VB.NET�ϊ�

        strSQL = ""
        strSQL = strSQL & Chr(10) & "SELECT "
        strSQL = strSQL & Chr(10) & "    MIN(�o�ɓ���) AS �o�ɓ��� "
        strSQL = strSQL & Chr(10) & "  , MAX(���ɓ���) AS ���ɓ��� "
        strSQL = strSQL & Chr(10) & "FROM "
        strSQL = strSQL & Chr(10) & "    ( "
        strSQL = strSQL & Chr(10) & "        SELECT "
        strSQL = strSQL & Chr(10) & "            ENT.�c�Ɠ� || ENT.�o�Ɏ��� || '00' AS �o�ɓ��� "
        strSQL = strSQL & Chr(10) & "          , ( "
        strSQL = strSQL & Chr(10) & "                CASE "
        strSQL = strSQL & Chr(10) & "                WHEN ENT.�o�Ɏ��� > ENT.���Ɏ��� THEN "
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                    TO_CHAR(TO_DATE(ENT.�c�Ɠ�) + 1,'yyyymmdd') || "
        strSQL = strSQL & Chr(10) & "                    ENT.���Ɏ���                                || "
        strSQL = strSQL & Chr(10) & "                    '00'                                           "
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                ELSE"
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                    ENT.�c�Ɠ�   || "
        strSQL = strSQL & Chr(10) & "                    ENT.���Ɏ��� || "
        strSQL = strSQL & Chr(10) & "                    '00'            "
        strSQL = strSQL & Chr(10)
        strSQL = strSQL & Chr(10) & "                END"
        strSQL = strSQL & Chr(10) & "            )                          AS ���ɓ��� "
        strSQL = strSQL & Chr(10) & "        FROM "
        strSQL = strSQL & Chr(10) & "            �c�Ɠ���e�[�u�� ENT "
        strSQL = strSQL & Chr(10) & "          , ��Ѓ}�X�^       KSM "
        strSQL = strSQL & Chr(10) & "        WHERE "
        strSQL = strSQL & Chr(10) & "            ENT.�c�Ɠ�     >= '" & pstrEigyobiSta & "' "
        strSQL = strSQL & Chr(10) & "        AND ENT.�c�Ɠ�     <= '" & pstrEigyobiEnd & "' "
        strSQL = strSQL & Chr(10) & "        AND ENT.���Ɏ���   IS NOT NULL "
        strSQL = strSQL & Chr(10) & "        AND ENT.�o�Ɏ���   IS NOT NULL "
        strSQL = strSQL & Chr(10) & "        AND ENT.��ЃR�[�h  = KSM.��ЃR�[�h(+) "
        strSQL = strSQL & Chr(10) & "        AND KSM.�^�N�|���p��ЃR�[�h IS NOT NULL "
        strSQL = strSQL & Chr(10) & "    ) "

        'UPGRADE_WARNING: Couldn't resolve default property of object gobjOraDatabase.CreateDynaset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        objDysTemp = gobjOraDatabase.CreateDynaset(strSQL, &H4)

        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pstrSyukkoDate = gfncFieldVal(objDysTemp.Fields("�o�ɓ���").Value)
        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: Couldn't resolve default property of object gfncFieldVal(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        pstrNyukkoDate = gfncFieldVal(objDysTemp.Fields("���ɓ���").Value)

        'UPGRADE_WARNING: Couldn't resolve default property of object objDysTemp.Close. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Call objDysTemp.Close()

        'UPGRADE_NOTE: Object objDysTemp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        objDysTemp = Nothing

    End Sub
End Module
