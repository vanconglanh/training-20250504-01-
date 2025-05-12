'―――――――――――――――――――――――――――――――――――――――――――――
'   クラス名　：edtAddress
'   説　　明　：住所テキスト型ユーザーコントロール
'   名前空間　：ATDS.UI.Control
'   レイヤ　　：ユーザーインターフェースコントロール
'
'   Copyright(C) ATDS CO.,LTD. All right reserved.
'------------------------------------------------------------------------------------------
'<更新履歴>
'   2022.01.16 新規作成
'―――――――――――――――――――――――――――――――――――――――――――――

'------------------------------------------------------------------------------------------
'   変数/型変換明示的宣言
'------------------------------------------------------------------------------------------
Option Explicit On
Option Strict On

'------------------------------------------------------------------------------------------
'   デフォルトの名前空間の指定
'------------------------------------------------------------------------------------------
Imports System.ComponentModel
Imports System.Windows.Forms
Imports ATDS.Common
Imports ATDS.UI.Control


Public Class edtAddress
    Inherits ATDS.UI.Control.BaseEdit

#Region " コンポーネント デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

        '--- 初期処理
        Call Init()

    End Sub

    'Component は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' コンポーネント デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更してください。
    ' コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region


#Region "【内部変数】"

    Private Const lcAllowSpace As Boolean = True
    Private Const lcFullAddress As Boolean = True
    Private Const lcMojiSyurui As String = ""
    Private Const lcMsgTitle As String = "住所"
    Private Const lcMaxLength As Integer = 40

    Private _HintText As String = ""
    Private _IsFullAddress As Boolean = True
    Private _IsSearch_SpaceKey As Boolean = True
    Private _IsSetItem As Boolean = True
    Private _IsReplaceAddress As Boolean = True
    Private _MaxLength As Integer = lcMaxLength
    Private _SelectItem As String = ""
    Private _SetEdit_Postal As edtPostal
    Private _SetCombobox_Pref As MSEPref

    Private lIsCheckInvalid As Boolean = True
    Private lobjList() As Postal

    '--- 項目初期化用イベント
    Event SetItem_Init()

    '--- サブ項目セット用イベント
    Event SetItem_Sub(ByVal vSetType As SetItemType)


#Region "【Enum】Edit_Idx          ：Edit用Index "

    Public Enum Edit_Idx As Byte

        Address2
        Address3
        Max

    End Enum

#End Region


#End Region

#Region "【既存プロパティ規定値設定】"

#Region "【プロパティ】MaxLength   : 最大桁数 "

    <DefaultValue(lcMaxLength)>
    Public Overrides Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal Value As Integer)
            _MaxLength = Value
        End Set
    End Property

#End Region

#Region "【メソッド】ShouldSerializeAllowSpace             : スペースを許可するかどうか "

    Protected Overrides Function ShouldSerializeAllowSpace() As Boolean
        Return Not AllowSpace.Equals(lcAllowSpace)
    End Function

#End Region

#Region "【メソッド】ShouldSerializeHintText               : 補足メッセージ "

    Protected Overrides Function ShouldSerializeHintText() As Boolean
        Return Not HintText.Equals(_HintText)
    End Function

#End Region

#Region "【メソッド】ShouldSerializeIsSearch_SpaceKey      : スペースキーで検索するかどうか "

    Protected Overrides Function ShouldSerializeIsSearch_SpaceKey() As Boolean
        Return Not IsSearch_SpaceKey.Equals(_IsSearch_SpaceKey)
    End Function

#End Region

#Region "【メソッド】ShouldSerializeMojiSyurui             : 文字種類 "

    Protected Overrides Function ShouldSerializeMojiSyurui() As Boolean
        Return Not MojiSyurui.Equals(lcMojiSyurui)
    End Function

#End Region

#Region "【メソッド】ShouldSerializeMsgTitle               : メッセージボックスのタイトル "

    Protected Overrides Function ShouldSerializeMsgTitle() As Boolean
        Return Not MsgTitle.Equals(lcMsgTitle)
    End Function

#End Region

#End Region


#Region "【プロパティ】IsFullAddress                  : 住所に都道府県を含めるかどうか "

    <Browsable(False)>
    Public Property IsFullAddress() As Boolean
        Get
            Return _IsFullAddress
        End Get
        Set(ByVal Value As Boolean)
            _IsFullAddress = Value
        End Set
    End Property

    Protected Overridable Function ShouldSerializeIsFullAddress() As Boolean
        Return Not IsFullAddress.Equals(lcFullAddress)
    End Function

#End Region

#Region "【プロパティ】(ReadOnly) IsSetItem           : 項目セットするかどうか ※外部コントロールからセットするときの制御用 "

    <Browsable(False)>
    Public ReadOnly Property IsSetItem() As Boolean
        Get
            Return _IsSetItem
        End Get
    End Property

#End Region

#Region "【プロパティ】(ReadOnly) IsReplaceAddress    : 住所を置き換えるかどうか "

    <Browsable(False)>
    Public ReadOnly Property IsReplaceAddress() As Boolean
        Get
            Return _IsReplaceAddress
        End Get
    End Property

#End Region


#Region "【プロパティ】SetEdit_Postal          : 郵便番号コントロール "

    <Browsable(False)>
    Public Property SetEdit_Postal() As edtPostal
        Get
            Return _SetEdit_Postal
        End Get
        Set(ByVal Value As edtPostal)
            _SetEdit_Postal = Value
        End Set
    End Property

    Protected Overridable Function ShouldSerializeSetEdit_Postal() As Boolean
        Return Not SetEdit_Postal.Equals(Nothing)
    End Function

#End Region

#Region "【プロパティ】SetEdit_Postal          : 郵便番号コントロール "

    <Browsable(False)>
    Public Property SetCombobox_Pref() As MSEPref
        Get
            Return _SetCombobox_Pref
        End Get
        Set(ByVal Value As MSEPref)
            _SetCombobox_Pref = Value
        End Set
    End Property

    Protected Overridable Function ShouldSerializeSetCombobox_Pref() As Boolean
        Return Not SetCombobox_Pref.Equals(Nothing)
    End Function

#End Region

#Region "【プロパティ】SelectItem              : 選択されている情報 "

    <Browsable(False)>
    Public Property SelectItem() As String
        Get
            Return _SelectItem
        End Get
        Set(ByVal Value As String)
            _SelectItem = Value
        End Set
    End Property

    Protected Overridable Function ShouldSerializeSelectItem() As Boolean
        Return Not SelectItem.Equals("")
    End Function

#End Region


#Region "【イベント】Validating "

    Private Sub edtAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

        Dim blnCancel As Boolean

        Try
            If MyBase.IsCancel_Validating Then Exit Try

            If MyBase.IsCausesValidation = False Then Exit Try

            '--- 変更が無い場合は処理しない
            If Me.Text.IndexOf(_SelectItem) <> -1 AndAlso _SelectItem <> "" AndAlso Me.Text <> "" Then Exit Try

            '--- 項目設定
            If Me.Text = "" Then

                '--- 項目初期化
                Call SetItem()

            Else
                blnCancel = SearchData(Me.Text)

            End If

            '--- 前回情報を保持
            Me.LastData = Me.Text

            e.Cancel = blnCancel

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            MyBase.IsCausesValidation = True

            '--- キャンセル時にEnterKeyフラグ初期化
            If blnCancel = True Then Call MyBase.EnterKeyOff()

        End Try

    End Sub

#End Region

#Region "【イベント】Validated "

    Private Sub edtAddress_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Validated
        lIsCheckInvalid = True
    End Sub

#End Region


#Region "【メソッド】(Protected) OnSetItem_Init          : 項目初期化イベント発生 "

    Protected Sub OnSetItem_Init()

        RaiseEvent SetItem_Init()

    End Sub

#End Region

#Region "【メソッド】(Protected) OnSetItem_Sub           : サブ項目セットイベント発生(SetItemType) ※非連結項目セット用 "

    Protected Sub OnSetItem_Sub(ByVal vSetType As SetItemType)

        RaiseEvent SetItem_Sub(vSetType)

    End Sub

#End Region


#Region "【メソッド】(Private) Init                      : 初期処理 "

    Private Sub Init()

        Me.AllowSpace = lcAllowSpace
        Me.HintText = _HintText
        Me.IsSearch_SpaceKey = _IsSearch_SpaceKey
        Me.IsFullAddress = _IsFullAddress
        Me.MaxLength = lcMaxLength
        Me.MojiSyurui = lcMojiSyurui
        Me.MojiSyuruiMode = BaseEdit.Mode.Only
        Me.ImeMode = ImeMode.Hiragana
        Me.MsgTitle = lcMsgTitle
        Me.Text = ""

        Me.SetLength_Edit(Edit_Idx.Max - 1)

    End Sub

#End Region

#Region "【メソッド】GetItem                             : 項目取得 "

    Public Function GetItem() As String

        Return _SelectItem

    End Function

#End Region

#Region "【メソッド】SetItem                             : 項目セット "

    Public Overloads Sub SetItem()

        Try
            '--- プロパティ 初期化
            _SelectItem = ""

            '--- 変数初期化
            lobjList = Nothing

            '--- 前回情報
            Me.LastData = ""

            '--- 関連コントロール初期化
            Me.Clear_SetText()

            '(郵便番号)
            If Not IsNothing(Me.SetEdit_Postal) AndAlso Me.SetEdit_Postal.IsSetItem Then
                _IsSetItem = False
                Me.SetEdit_Postal.Text = ""
                Me.SetEdit_Postal.SetItem()
            End If

            '--- 項目初期化イベント発生
            Me.OnSetItem_Init()

        Catch ex As Exception
            Throw

        Finally
            _IsSetItem = True

        End Try

    End Sub

#End Region

#Region "【メソッド】SetItem                             : 項目セット(Address) "

    Public Overloads Sub SetItem(ByVal Address As String)

        Dim objList() As Postal
        Dim strMatchStr As String = ""

        Try
            '--- 情報取得
            objList = PostalDic.SearchAddress(Address, strMatchStr)

            '---項目初期化
            Call SetItem()

            '---項目セット
            Call SetItem(objList, strMatchStr)

        Catch ex As Exception
            Throw

        Finally
            objList = Nothing

        End Try

    End Sub

#End Region

#Region "【メソッド】SetItem                             : 項目セット(AddressInfo) "

    Public Overloads Sub SetItem(ByVal objCls As AddressInfo)

        Try
            With objCls

                '--- 郵便番号
                If Not IsNothing(_SetEdit_Postal) AndAlso _SetEdit_Postal.IsSetItem Then
                    _IsSetItem = False
                    _SetEdit_Postal.SetItem(objCls)
                End If

                '--- 住所 ※そのままセット
                Me.Text = .Address1

                '--- 住所2
                If Not IsNothing(Me.SetText_Edit(Edit_Idx.Address2)) Then
                    Me.SetText_Edit(Edit_Idx.Address2).Text = .Address2
                End If

                '--- 住所3
                If Not IsNothing(Me.SetText_Edit(Edit_Idx.Address3)) Then
                    Me.SetText_Edit(Edit_Idx.Address3).Text = .Address3
                End If

                _SelectItem = Me.Text

            End With

            '--- サブ項目設定イベント発生
            Me.OnSetItem_Sub(SetItemType.AddressInfo)

        Catch ex As Exception
            Throw

        Finally
            _IsSetItem = True

        End Try

    End Sub

#End Region

#Region "【メソッド】SetItem                             : 項目セット(Postal) "

    Public Overloads Sub SetItem(ByVal objCls As Postal)

        '--- 項目セット
        Call SetItem(objCls, "")

    End Sub

#End Region

#Region "【メソッド】SetItem                             : 項目セット(Postal, MatchStr) "

    Public Overloads Sub SetItem(ByVal objCls As Postal, ByVal MatchStr As String)

        Dim intIndex As Integer = 0
        Dim intNoAddressIdx As Integer = 0
        Dim strAddress As String = ""
        Dim strCheckAddress As String = ""

        Try
            _IsReplaceAddress = False

            '--- 項目初期化 ※住所が空の場合のみ
            If Me.Text = "" Then
                Call SetItem()
            End If

            With objCls

                '--- 郵便番号
                If Not IsNothing(_SetEdit_Postal) AndAlso _SetEdit_Postal.IsSetItem Then
                    _IsSetItem = False
                    _SetEdit_Postal.SetItem(objCls)
                End If

                '--- 都道府県
                If Not IsNothing(Me.SetCombobox_Pref) Then
                    Me.SetCombobox_Pref.Text = .Address1
                End If

                '--- 市区町村
                Me.Text = .Address2

                '--- 町域番地
                If Not IsNothing(Me.SetText_Edit(Edit_Idx.Address3)) Then

                    Me.SetText_Edit(Edit_Idx.Address3).Text = .Address3

                End If


                ''--- 住所 ※郵便番号側からのセットかつ住所が空の場合のみ、住所をセットする
                'If _IsSetItem AndAlso Me.Text = "" Then

                '    '--- 住所を置き換える
                '    _IsReplaceAddress = True

                '    '(検索文字列の開始位置を取得)
                '    intIndex = -1
                '    If MatchStr <> "" Then
                '        intIndex = Me.Text.IndexOf(MatchStr)
                '    End If

                '    '(住所設定) ※都道府県の有無により設定変更
                '    If _IsFullAddress Then

                '        '(住所の不要部分の開始位置を取得)
                '        intNoAddressIdx = -1
                '        intNoAddressIdx = .GetFullAddress.IndexOf("（")

                '        '(住所の不要部分があれば除去)
                '        If intNoAddressIdx <> -1 Then
                '            strAddress = .GetFullAddress.Remove(intNoAddressIdx, .GetFullAddress.Length - intNoAddressIdx)
                '        Else
                '            strAddress = .GetFullAddress
                '        End If

                '    Else
                '        '(住所の不要部分の開始位置を取得)
                '        intNoAddressIdx = -1
                '        intNoAddressIdx = .GetAddress.IndexOf("（")

                '        '(住所の不要部分があれば除去)
                '        If intNoAddressIdx <> -1 Then
                '            strAddress = .GetAddress.Remove(intNoAddressIdx, .GetAddress.Length - intNoAddressIdx)
                '        Else
                '            strAddress = .GetAddress
                '        End If

                '    End If

                '    '(セットする文字列設定) ※検索文字列のみ上書きする
                '    If intIndex <> -1 Then
                '        strAddress += MidByte(Me.Text, intIndex + LenByte(MatchStr), LenByte(Me.Text) - LenByte(MatchStr))
                '    End If

                '    '(項目セット)
                '    'Me.Text = strAddress

                '    '--- 都道府県
                '    Me.SetCombobox_Pref.SelectedText = .Address1

                '    '--- 市区町村
                '    Me.Text = .Address2

                '    '--- 町域番地
                '    If Not IsNothing(Me.SetText_Edit(Edit_Idx.Address3)) Then

                '        Me.SetText_Edit(Edit_Idx.Address3).Text = .Address3

                '    End If


                '    ''--- セットできた住所を取得 ※差分チェック用
                '    'strCheckAddress = Me.Text

                '    '    '--- 住所2
                '    '    If Not IsNothing(Me.SetText_Edit(Edit_Idx.Address2)) Then

                '    '        Me.SetText_Edit(Edit_Idx.Address2).Text = SetAddress(strAddress, strCheckAddress)

                '    '        '--- セットできた住所を取得 ※差分チェック用
                '    '        strCheckAddress += Me.SetText_Edit(Edit_Idx.Address2).Text

                '    '    End If

                '    '    '--- 住所3
                '    '    If Not IsNothing(Me.SetText_Edit(Edit_Idx.Address3)) Then
                '    '        Me.SetText_Edit(Edit_Idx.Address3).Text = SetAddress(strAddress, strCheckAddress)
                '    '    End If

                'End If

                _SelectItem = Me.Text

            End With

            '--- サブ項目設定イベント発生
            Me.OnSetItem_Sub(SetItemType.Postal)

        Catch ex As Exception
            Throw

        Finally
            _IsSetItem = True
            _IsReplaceAddress = False

        End Try

    End Sub

#End Region

#Region "【メソッド】(Private) SetItem                   : 項目セット(Postal()) "

    Private Overloads Sub SetItem(ByVal objList() As Postal, ByVal MatchStr As String)

        '--- 件数チェック
        Select Case objList.Length
            Case 0
                '--- 項目初期化
                Call SetItem()

            Case 1
                '--- 項目セット
                Call SetItem(CType(objList.GetValue(0), Postal), MatchStr)

            Case Else
                lobjList = objList
                '--- 検索画面呼出 ※Enterキーのみ
                If Me.IsEnterKey Then
                    'Call ShowSearch(MatchStr)
                End If

        End Select

    End Sub

#End Region

#Region "【メソッド】(Private) SetAddress                : 住所セット(基準の住所, 現時点でセットできている住所) ※桁オーバー用 "

    Private Function SetAddress(ByVal vBaseAddress As String, ByVal vAddress As String) As String

        Dim strAddress As String = ""
        Dim intLenB As Integer = 0
        Dim intLenB_Base As Integer = 0

        '--- 住所が一致した場合 ⇒ セット不要
        If vBaseAddress = vAddress Then Return ""

        '--- バイト数取得
        intLenB = LenByte(vAddress)
        intLenB_Base = LenByte(vBaseAddress)

        '--- 住所の差分を取得
        strAddress = MidByte(vBaseAddress, intLenB, intLenB_Base - intLenB)

        Return strAddress

    End Function

#End Region

#Region "【メソッド】(Protected Overridable) ShowSearch  : 検索画面表示 "

    Protected Overridable Overloads Sub ShowSearch(ByVal MatchStr As String)

        Dim objForm As New PostalSearch

        Try
            lIsCheckInvalid = False

            With objForm

                '--- 検索画面表示
                .DefaultList = lobjList
                .Font = Me.Font
                .StartState = PostalSearch.StartStateType.PostalMode
                .ShowDialog()

                If .IsSelected = True Then

                    Call SetItem(.SelectedItem, MatchStr)

                End If

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objForm.Dispose()
            objForm = Nothing
            lobjList = Nothing
        End Try

    End Sub

#End Region

#Region "【メソッド】(Private) SearchData                : データ検索(Address) "

    Private Function SearchData(ByVal Address As String) As Boolean

        Dim blnCancel As Boolean = True
        Dim objList() As Postal
        Dim strMatchStr As String = ""

        Try
            '--- 例外郵便番号の場合は、処理対象外とする
            If Not IsNothing(_SetEdit_Postal) AndAlso
               _SetEdit_Postal.IsExceptionCode Then Return False

            '--- 情報取得
            objList = PostalDic.SearchAddress(Address, strMatchStr)

            '--- 項目セット
            Call SetItem(objList, strMatchStr)
            blnCancel = False

            Return blnCancel

        Catch ex As Exception
            Throw

        Finally
            objList = Nothing

        End Try

    End Function

#End Region

#Region "【メソッド】SetDefaultValue_HintText            : [規定値設定]補足メッセージ "

    Protected Sub SetDefaultValue_HintText(ByVal vValue As String)
        _HintText = vValue
        Me.HintText = _HintText
    End Sub

#End Region

#Region "【メソッド】SetDefaultValue_SpaceKey            : [規定値設定]スペースキーで検索をするかどうか "

    Protected Sub SetDefaultValue_IsSearch_SpaceKey(ByVal vValue As Boolean)
        _IsSearch_SpaceKey = vValue
        Me.IsSearch_SpaceKey = _IsSearch_SpaceKey
    End Sub

#End Region


#Region "【列挙型】SetItemType                           : 項目セットタイプ "

    Public Enum SetItemType As Byte

        AddressInfo
        Postal

    End Enum

#End Region


End Class
