Option Strict Off
Option Explicit On
Module basGetFurigana
    '******************************************************************************
    ' ��ۼު�Ė�  : �l�j�V�X�e������
    ' �t�@�C����  : GetFurigana.bas
    ' ��    �e    : �U�艼�� �擾 ���W���[��
    ' ��    �l    :
    ' �֐��ꗗ    : <Public>
    '                   gsubStartWatchInput          (���͊Ď��J�n����)
    '                   gsubEndWatchInput            (���͊Ď��I������)
    '               <Private>
    '
    ' �ύX����  :
    '   Version     ��  �t      ��  ��             �C�����e
    '   -----------+-----------+------------------+--------------------------------
    '   01.00.00    2010/08/01  �A��  �F��         �V�K�쐬
    '
    '******************************************************************************
    '==============================================================================
    ' �`�o�h�֐�
    '==============================================================================
    'Ime����
    Private Declare Function ImmGetContext Lib "imm32.dll" (ByVal hWnd As Integer) As Integer

    Private Declare Function ImmGetCompositionString Lib "imm32.dll" Alias "ImmGetCompositionStringA" (ByVal lnghImc As Integer, ByVal dw As Integer, ByVal lpv As String, ByVal dw2 As Integer) As Integer

    Private Declare Function ImmReleaseContext Lib "imm32.dll" (ByVal hWnd As Integer, ByVal lnghImc As Integer) As Integer

    Private Const GCS_COMPREADSTR As Integer = &H1
    Private Const GCS_COMPREADATTR As Integer = &H2
    Private Const GCS_COMPREADCLAUSE As Integer = &H4
    Private Const GCS_COMPSTR As Integer = &H8
    Private Const GCS_COMPATTR As Integer = &H10
    Private Const GCS_COMPCLAUSE As Integer = &H20
    Private Const GCS_CURSORPOS As Integer = &H80
    Private Const GCS_DELTASTART As Integer = &H100
    Private Const GCS_RESULTREADSTR As Integer = &H200
    Private Const GCS_RESULTREADCLAUSE As Integer = &H400
    Private Const GCS_RESULTSTR As Integer = &H800
    Private Const GCS_RESULTCLAUSE As Integer = &H1000

    '�C�x���g�����֘A
    Private Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Integer, ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
    Private Delegate Function WindowProcCallback(ByVal hWnd As IntPtr, ByVal iMsg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

    Private Const GWL_WNDPROC As Short = (-4)
    Private Const WM_IME_COMPOSITION As Integer = &H10F

    '==============================================================================
    ' �ϐ�
    '==============================================================================
    Private mstrFurigana As String
    Private mlngWindow As Integer
    Private mlnghWnd As Integer

    Public Function GetFurigana(ByVal hWnd As Integer, ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

        Dim lnghImc As Integer
        Dim lngLen As Integer
        Dim strTemp As String

        'IME�����m���ŕ��������͂��ꂽ�ꍇ
        If (uMsg = WM_IME_COMPOSITION) And ((lParam And GCS_RESULTREADSTR) <> 0) Then

            '�t���K�i���擾
            '�R���e�L�X�g�擾
            lnghImc = ImmGetContext(hWnd)

            '�o�b�t�A�m�ۂ̂��ߓ��͂������������擾
            lngLen = ImmGetCompositionString(lnghImc, GCS_RESULTREADSTR, vbNullChar, 0)

            '���͕��������o�b�t�@�m��
            strTemp = Space(lngLen + 1)

            '���͕�����擾
            Call ImmGetCompositionString(lnghImc, GCS_RESULTREADSTR, strTemp, lngLen + 1)

            '�R���e�L�X�g�J��
            Call ImmReleaseContext(hWnd, lnghImc)

            mstrFurigana = mstrFurigana & RTrim(strTemp)

        End If

        GetFurigana = CallWindowProc(mlngWindow, hWnd, uMsg, wParam, lParam)

    End Function

    Public Sub gsubStartWatchInput(ByRef pctlWatchTarget As System.Windows.Forms.Control)

        '�t���K�i�Ď��X�^�[�g

        'GetFurigana�C�x���g���o�C���h���Ă܂��B
        'UPGRADE_WARNING: Add a delegate for AddressOf GetFurigana Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E9E157F7-EF0C-4016-87B7-7D7FBBC6EE08"'
        '++�C���J�n�@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�
        'mlngWindow = SetWindowLong(pctlWatchTarget.Handle.ToInt32, GWL_WNDPROC, AddressOf GetFurigana)
        Dim wpcallback = New WindowProcCallback(AddressOf GetFurigana) 'create the new callback delegate when this form loads
        mlngWindow = SetWindowLong(pctlWatchTarget.Handle.ToInt32, GWL_WNDPROC, wpcallback)
        '--�C���I���@2021�N04��01:Onetech�i��j- VB��VB.NET�ϊ�

        '�n���h���ۑ�
        mlnghWnd = pctlWatchTarget.Handle.ToInt32

        '�ӂ肪�ȕ����񏉊���
        mstrFurigana = ""

    End Sub

    Public Sub gsubEndWatchInput(ByRef pstrFurigana As String)

        '�t���K�i�Ď��I��

        '�C�x���g�̃o���h��������
        Call SetWindowLong(mlnghWnd, GWL_WNDPROC, mlngWindow)

        pstrFurigana = mstrFurigana

    End Sub

    Public Function gfncGetFurigana(ByRef ptxtTarget As System.Windows.Forms.TextBox) As String

        Dim lngImeContext As Integer
        Dim strBuffer As New VB6.FixedLengthString(256)
        Dim strFurigana As String
        Dim lngResult As Integer

        ' ���̓R���e�L�X�g���擾
        lngImeContext = ImmGetContext(ptxtTarget.Handle.ToInt32)

        ' �ϊ�������Ɋւ�������擾
        lngResult = ImmGetCompositionString(lngImeContext, GCS_RESULTREADSTR, strBuffer.Value, Len(strBuffer.Value))

        ' ���̓R���e�L�X�g�����
        lngResult = ImmReleaseContext(ptxtTarget.Handle.ToInt32, lngImeContext)

        ' �擾���������񂩂�Null�������폜
        strFurigana = Replace(strBuffer.Value, vbNullChar, "")

        gfncGetFurigana = strFurigana

    End Function

End Module