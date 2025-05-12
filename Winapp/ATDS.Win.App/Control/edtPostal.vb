'―――――――――――――――――――――――――――――――――――――――――――――
'   クラス名　：edtPostal
'   説　　明　：郵便番号テキスト型ユーザーコントロール
'   名前空間　：Unitec.UI.Control
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


Public Class edtPostal
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

    Private Const lcAllowSpace As Boolean = False
    Private Const lcMojiSyurui As String = "9"
    Private Const lcMsgTitle As String = "郵便番号"
    Private Const lcMaxLength As Integer = 8

    '--- 例外郵便番号
    Private Const lcExceptionCode As String = "9999999"

    Private _HintText As String = ""
    Private _IsSearch_SpaceKey As Boolean = True
    Private _IsSetItem As Boolean = True
    Private _MaxLength As Integer = lcMaxLength
    Private _SetEdit_Address As edtAddress
    Private _SelectItem As Postal
    Private _Value As String = ""

    Private lIsCheckInvalid As Boolean = True
    Private lobjList() As Postal

    '--- 項目初期化用イベント
    Event SetItem_Init()

    '--- サブ項目セット用イベント
    Event SetItem_Sub()

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


#Region "【プロパティ】(ReadOnly) IsExceptionCode   : 例外郵便番号かどうか "

    <Browsable(False)>
    Public ReadOnly Property IsExceptionCode() As Boolean
        Get
            '--- 例外郵便番号かどうか
            If Me.Value = lcExceptionCode Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

#End Region

#Region "【プロパティ】(ReadOnly) IsSetItem         : 項目セットするかどうか ※外部コントロールからセットするときの制御用 "

    <Browsable(False)>
    Public ReadOnly Property IsSetItem() As Boolean
        Get
            Return _IsSetItem
        End Get
    End Property

#End Region

#Region "【プロパティ】SetEdit_Address              : 住所コントロール "

    <Browsable(False)>
    Public Property SetEdit_Address() As edtAddress
        Get
            Return _SetEdit_Address
        End Get
        Set(ByVal Value As edtAddress)
            _SetEdit_Address = Value
        End Set
    End Property

    Protected Overridable Function ShouldSerializeSetEdit_Address() As Boolean
        Return Not SetEdit_Address.Equals(Nothing)
    End Function

#End Region

#Region "【プロパティ】(ReadOnly) SelectItem        : 使用している情報 "

    <Browsable(False)>
    Public ReadOnly Property SelectItem() As Postal
        Get
            Return _SelectItem
        End Get
    End Property

#End Region

#Region "【プロパティ】Value                        : 値[ハイフンなし] "

    <Browsable(False)>
    Public Property Value() As String
        Get
            Return SetFormat(Me.Text, False)
        End Get
        Set(ByVal Value As String)
            _Value = SetFormat(Value, False)
            Me.Text = SetFormat(_Value, True)
        End Set
    End Property

#End Region

#Region "【イベント】Enter "

    Private Sub edtPostal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter

        '--- ハイフン除去
        Me.Text = SetFormat(Me.Text, False)

        '--- 入力桁数制御
        Me.MaxLength = lcMaxLength - 1

    End Sub

#End Region

#Region "【イベント】Leave "

    Private Sub edtPostal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave

        '--- 入力桁数制御
        Me.MaxLength = lcMaxLength

        '--- ハイフン付与
        Me.Text = SetFormat(Me.Text, True)

    End Sub

#End Region

#Region "【イベント】Validating "

    Private Sub edtPostal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating

        Dim blnCancel As Boolean

        Try
            If MyBase.IsCausesValidation = False Then Exit Try

            '--- 変更が無い場合は処理しない
            If Not IsNothing(_SelectItem) AndAlso
               _SelectItem.PostalString = Me.Value And Me.Value <> "" Then Exit Try

            '--- 項目設定
            If Me.Value = "" Then

                '--- 項目初期化
                Call SetItem()

            Else
                blnCancel = SearchData(Me.Value)

            End If

            '--- 前回情報を保持
            Me.LastData = Me.Value

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

    Private Sub edtPostal_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Validated
        'lIsCheckInvalid = True
    End Sub

#End Region


#Region "【メソッド】(Private) Init                      : 初期処理 "

    Private Sub Init()

        Me.AllowSpace = lcAllowSpace
        Me.HintText = _HintText
        Me.IsSearch_SpaceKey = _IsSearch_SpaceKey
        Me.MaxLength = lcMaxLength
        Me.MojiSyurui = lcMojiSyurui
        Me.MojiSyuruiMode = BaseEdit.Mode.Only
        Me.ImeMode = ImeMode.Disable
        Me.MsgTitle = lcMsgTitle

        Me.Text = ""

    End Sub

#End Region

#Region "【メソッド】GetItem                             : 項目取得 "

    Public Function GetItem() As Postal

        Dim objCls As New Postal

        Try
            If Not IsNothing(_SelectItem) Then
                objCls = _SelectItem
            End If

            Return objCls

        Catch ex As Exception
            Throw

        Finally
            objCls = Nothing

        End Try

    End Function

#End Region

#Region "【メソッド】SetItem                             : 項目セット "

    Public Overloads Sub SetItem()

        Try
            '--- 項目セット ※常に住所をクリアする
            Call SetItem(True)

        Catch ex As Exception
            Throw

        End Try

    End Sub

#End Region

#Region "【メソッド】(Private) SetItem                   : 項目セット(IsClearAddress) "

    Private Overloads Sub SetItem(ByVal vIsClearAddress As Boolean)

        Try
            '--- プロパティ 初期化
            _SelectItem = Nothing

            '--- 変数初期化
            lobjList = Nothing

            '--- 前回情報
            Me.LastData = ""

            '--- 関連コントロール初期化
            Me.Clear_SetText()

            '(住所)
            If Not IsNothing(Me.SetEdit_Address) AndAlso Me.SetEdit_Address.IsSetItem Then
                If vIsClearAddress OrElse Me.SetEdit_Address.Text = "" Then
                    _IsSetItem = False
                    Me.SetEdit_Address.Text = ""
                    Me.SetEdit_Address.SetItem()
                End If
            End If

            '--- 項目初期化イベント発生
            RaiseEvent SetItem_Init()

        Catch ex As Exception
            Throw

        Finally
            _IsSetItem = True

        End Try

    End Sub

#End Region

#Region "【メソッド】SetItem                             : 項目セット(Code) "

    Public Overloads Sub SetItem(ByVal Code As String)

        Dim objList() As Postal

        Try
            '--- 情報取得
            objList = PostalDic.SearchPostal(SetFormat(Code, False))

            '---項目初期化
            Call SetItem(False)

            '---項目セット
            Call SetItem(objList)

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

                '_SelectItem = PostalDic.SearchID(objCls.Postal)
                _SelectItem = PostalDic.SearchID(objCls.GetPostal)

                '--- 郵便番号
                'Me.Text = .Postal(True)
                Me.Text = .GetPostal(True)

                '--- 住所1
                If Not IsNothing(_SetEdit_Address) AndAlso _SetEdit_Address.IsSetItem Then
                    _IsSetItem = False
                    _SetEdit_Address.SetItem(objCls)
                End If

            End With

            '--- サブ項目設定イベント発生
            RaiseEvent SetItem_Sub()

        Catch ex As Exception
            Throw

        Finally
            _IsSetItem = True

        End Try

    End Sub

#End Region

#Region "【メソッド】SetItem                             : 項目セット(Postal) "

    Public Overloads Sub SetItem(ByVal objCls As Postal)

        Try
            With objCls

                _SelectItem = objCls

                '--- 郵便番号
                Me.Text = SetFormat(.PostalString, True)

                '--- 住所1
                If Not IsNothing(_SetEdit_Address) AndAlso _SetEdit_Address.IsSetItem Then
                    _IsSetItem = False
                    _SetEdit_Address.SetItem(objCls)
                End If

            End With

            '--- サブ項目設定イベント発生
            RaiseEvent SetItem_Sub()

        Catch ex As Exception
            Throw

        Finally
            _IsSetItem = True

        End Try

    End Sub

#End Region

#Region "【メソッド】(Private) SetItem                   : 項目セット(Postal()) "

    Private Overloads Sub SetItem(ByVal objList() As Postal)

        '--- 件数チェック
        Select Case objList.Length
            Case 0
            Case 1
                '--- 項目セット
                Call SetItem(CType(objList.GetValue(0), Postal))

            Case Else
                lobjList = objList
                '--- 検索画面呼出 ※Enterキーのみ
                If MyBase.IsEnterKey Then
                    Call ShowSearch()
                End If

        End Select

    End Sub

#End Region

#Region "【メソッド】(Protected Overrides) CheckExist    : 存在チェック "

    Protected Overrides Function CheckExist() As Boolean

        Try
            If Not lIsCheckInvalid Then Return True

            '--- 例外郵便番号の場合は、チェック不要とする
            If Me.IsExceptionCode Then Return True

            Select Case MyBase.IsCheckExist
                Case ExistCheckMode.Exist

                    If IsNothing(_SelectItem) Then
                        Return False
                    End If

                    If _SelectItem.PostalString = "" Then
                        Return False
                    End If

            End Select

            Return True

        Catch ex As Exception
            Throw

        Finally
            lIsCheckInvalid = True

        End Try

    End Function

#End Region

#Region "【メソッド】(Protected Overrides) ShowSearch    : 検索画面表示 "

    Protected Overrides Sub ShowSearch()

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

                    Call SetItem(.SelectedItem)

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

#Region "【メソッド】(Private) SearchData                : データ検索(Code) "

    Private Function SearchData(ByVal Code As String) As Boolean

        Dim blnCancel As Boolean = True
        Dim objList() As Postal


        Try
            '--- 項目初期化
            Call SetItem(False)

            '--- 情報取得
            objList = PostalDic.SearchPostal(Code)

            '--- 項目セット
            Call SetItem(objList)

            blnCancel = False

            Return blnCancel

        Catch ex As Exception
            Throw

        Finally
            objList = Nothing

        End Try

    End Function

#End Region

#Region "【メソッド】(Shared) SetFormat                  : 書式設定(Code, IsHaifun) "

    Public Shared Function SetFormat(ByVal Code As String, ByVal IsHaifun As Boolean) As String

        Dim strValue As String = Code

        If IsHaifun Then
            If Code.Length >= 3 Then
                strValue = Code.Remove(3, Code.Length - 3) & "-" & Code.Remove(0, 3)
            End If
        Else
            strValue = Code.Replace("-", "")
        End If

        Return strValue

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

End Class
