'―――――――――――――――――――――――――――――――――――――――――――――
'   クラス名　：UIProcess
'   説　　明　：ユーザーインターフェースプロセスクラス
'   名前空間　：Kumiai.UI.UIProcess
'   レイヤ　　：ユーザーインターフェースプロセスコンポーネント
'
'   Copyright(C) ATDS CO.,LTD. All right reserved.
'------------------------------------------------------------------------------------------
'<更新履歴>
'   2004.11.01  新規作成
'   2007.05.25  会社情報プロパティを追加
'―――――――――――――――――――――――――――――――――――――――――――――

'------------------------------------------------------------------------------------------
'   変数/型変換明示的宣言
'------------------------------------------------------------------------------------------
Option Explicit On 
Option Strict On

'------------------------------------------------------------------------------------------
'   デフォルトの名前空間の指定
'------------------------------------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.AppDomain
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Class UIProcess

    Private Shared _mainform As Form
    Private Shared _loginform As Form

    Private Shared _spfm As Splash
    Private Shared _menulst As ArrayList

    Private Shared _AppExecDir As String = CurrentDomain.BaseDirectory.ToString
    Private Shared _OSUser As String = System.Environment.UserName
    Private Shared _Terminal As String = System.Environment.MachineName
    'Private Shared _LoginCompany As Company
    'Private Shared _LoginUser As Staff
    Private Shared _IsLogin As Boolean = False
    Private Shared _AppMode As AppModeType = AppModeType.AppExit


#Region "【コンストラクタ】"

    Shared Sub New()

        '_LoginCompany = New Company
        '_LoginUser = New Staff

    End Sub

#End Region

#Region "【プロパティ】 (ReadOnly) ログイン画面 "

    Public Shared ReadOnly Property LoginForm() As Form
        Get
            Return _loginform
        End Get
    End Property

#End Region

#Region "【プロパティ】 (ReadOnly) MainForm "

    Shared ReadOnly Property MainForm() As Form
        Get
            Return _mainform
        End Get
    End Property
#End Region

#Region "【プロパティ】 (ReadOnly) アプリケーション実行パス "

    Public Shared ReadOnly Property AppExecDir() As String
        Get
            Return _AppExecDir
        End Get
    End Property

#End Region

#Region "【プロパティ】 (ReadOnly) Windowsユーザー "

    Public Shared ReadOnly Property OSUser() As String
        Get
            Return _OSUser
        End Get
    End Property

#End Region

#Region "【プロパティ】 (ReadOnly) 端末名 "

    Public Shared ReadOnly Property Terminal() As String
        Get
            Return _Terminal
        End Get
    End Property

#End Region

#Region "【プロパティ】 (ReadOnly) 会社情報 "

    'Public Shared ReadOnly Property LoginCompany() As Company
    '    Get
    '        Return _LoginCompany
    '    End Get
    'End Property

#End Region

#Region "【プロパティ】 (ReadOnly) アプリケーション利用者 "

    'Public Shared ReadOnly Property LoginUser() As Staff
    '    Get
    '        Return _LoginUser
    '    End Get
    'End Property

#End Region

#Region "【プロパティ】 (ReadOnly) ログイン済みであるかの検査 "

    Public Shared ReadOnly Property IsLogin() As Boolean
        Get
            Return _IsLogin
        End Get
    End Property

#End Region

#Region "【プロパティ】 アプリケーション実行モード　"

    Public Shared Property AppMode() As AppModeType
        Get
            Return _AppMode
        End Get
        Set(ByVal Value As AppModeType)
            _AppMode = Value
        End Set
    End Property
#End Region

#Region "【メソッド】 ログイン "

    'Public Shared Sub Login(ByVal LoginUser As Staff)

    '    _LoginUser = LoginUser
    '    _IsLogin = True


    'End Sub

#End Region

#Region "【メソッド】 ログアウト "

    Public Shared Sub Logout()

        'UIFormAdmin.FormsClear()

        '_LoginUser = New Staff
        _IsLogin = False
        _AppMode = AppModeType.AppLogOut

    End Sub

#End Region

#Region "【メソッド】 終了処理 "

    Public Shared Sub AppExit()

        _AppMode = AppModeType.AppExit

    End Sub

#End Region

#Region "【メソッド】- Init - プロセス準備 "

    Overloads Shared Sub Init()

        'オーバーロードメソッドへバイパス
        Init(CurrentDomain.BaseDirectory.ToString)

    End Sub

#End Region

#Region "【メソッド】- Init - プロセス準備 "

    Overloads Shared Sub Init(ByVal path As String)

        Try


            '郵便番号辞書読込
            UIProcess.SetNaviMsg("郵便番号辞書を初期化しています…")

            If File.Exists(My.Settings.Postal) = True Then
                ATDS.Common.PostalDic.CsvFile = My.Settings.Postal
            End If


        Catch ex As Exception
            MessageBox.Show("アプリケーション準備プロセスでエラーが発生しました！" & ChrW(Keys.Enter) & ex.Message, "プロセス準備", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Throw

        Finally

        End Try

    End Sub

#End Region

#Region "【メソッド】- LoginFormSecureProcess - ログインフォーム認証プロセス "

    Shared Sub LoginFormSecureProcess(Optional vUser As String = "")

        Try

            '終了モード = 終了
            AppMode = AppModeType.AppExit

            'ログインフォームの表示
            Dim frmLogin As New Login

            'ログインフォームをプロパティセット
            frmLogin.UserID = vUser
            _loginform = frmLogin

            'スプラッシュ非表示！
            _spfm.Hide()

            'ログインフォーム表示()
            Application.Run(frmLogin)

        Catch ex As Exception
            MessageBox.Show("認証プロセスでエラーが発生しました！" & ChrW(Keys.Enter) & ex.Message, "認証プロセス", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Throw
        Finally

        End Try

    End Sub

#End Region

#Region "【メソッド】- AutoLoginSecureProcess - オートログイン認証プロセス "

    Shared Sub AutoLoginSecureProcess(ByVal uid As String, ByVal pwd As String)

        Try

            LoginProcess(uid, pwd)

        Catch ex As Exception
            MessageBox.Show("認証プロセスでエラーが発生しました！" & ChrW(Keys.Enter) & ex.Message, "認証プロセス", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Throw
        Finally

        End Try

    End Sub

#End Region

#Region "【メソッド】- LoginProcess - ログインプロセス "

    Shared Function LoginProcess(ByVal uid As String, ByVal pwd As String) As Boolean

        'Try
        '    'ここはプロジェクトで異なると思う。
        '    'ここでは担当者クラスを使う。


        '    '渡されたID／パスワードで認証
        '    If Staff.IsSecure(uid, pwd) = Security.OK Then

        '        Dim cls As Staff = Staff.GetUser(uid)

        '        Login(cls)

        '        AppMode = AppModeType.AppExec

        '        Return True
        '    Else
        '        MessageBox.Show("ログインに失敗しました。" & ChrW(Keys.Enter) & "ユーザーIDとパスワードを確認してください。", "ログインプロセス", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '        Return False
        '    End If


        'Catch ex As Exception
        '    MessageBox.Show("ログインプロセスでエラーが発生しました！" & ChrW(Keys.Enter) & ex.Message, "ログインプロセス", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        '    AppMode = AppModeType.AppExit

        '    Throw
        'Finally

        'End Try

    End Function

#End Region

#Region "【メソッド】- Start - プロセス開始 "

    Shared Sub Start()

        'メインメニューオブジェクト作成
        'Dim menu As New AppMenu
        'Dim menufile As String = AppSetting.MenuDir & _LoginUser.Menu & ".xml"

        Try
            '終了モード = 終了
            AppMode = AppModeType.AppExit

            '★【2023/01/15】動的メニューは、今後実装

            ''【ログイン状況チェック】
            'If _IsLogin Then

            '    ' メニューの存在チェック
            '    If Not menu.IsMenuFile(menufile) Then
            '        MessageBox.Show("メニュー設定が存在しません", "起動プロセス", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Exit Sub
            '    End If

            '    ' メニュー読み込み
            '    If Not menu.Load(menufile) Then
            '        MessageBox.Show("メニュー設定が正しくありません", "起動プロセス", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Exit Sub
            '    End If

            'End If

            'メインフォームオブジェクト作成
            Using mainfm As New Menu

                ' メニュープロパティセット
                'mainfm.AppMenu = Menu

                _mainform = mainfm

                Application.Run(mainfm)

            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Start()", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally

        End Try

    End Sub

#End Region

#Region "【メイン】- Sub Main - "

    Shared Sub SetStart(ByVal CmdArgs() As String)

        Dim UserID As String = ""
        Dim Password As String = ""
        Dim InitArg As String = ""
        Dim ArgCount As Integer = 0
        Dim SArgCount As Integer = 0

        Try

            'スプラッシュフォームの表示
            _spfm = New Splash
            _spfm.Show()

            '---コマンドライン引数取得
            If CmdArgs.Length <> 0 Then
                For Each Arg As String In CmdArgs

                    ArgCount += 1
                    Select Case ArgCount
                        Case 1
                            For Each SArg As String In Arg.Split(CChar("/"))
                                SArgCount += 1
                                Select Case SArgCount
                                    Case 1
                                        UserID = SArg
                                    Case 2
                                        Password = SArg
                                End Select
                            Next

                        Case 2
                            InitArg = Arg

                    End Select

                Next
            End If


            '---ログインユーザー取得
            If My.Settings.LoginUserSave = True Then
                UserID = My.Settings.LoginUser
            End If

            'プロセス初期化（設定ファイルもコマンドライン引数で読み替え可能）
            If InitArg <> "" Then
                Init(InitArg)
            Else
                Init()
            End If


            '認証プロセス（コマンドライン引数があれば認証プロセスをショートカットする）
            If UserID = "" And Password = "" Then
                LoginFormSecureProcess()
            ElseIf UserID <> "" Then
                LoginFormSecureProcess(UserID)
            Else
                'オートログイン用
                AutoLoginSecureProcess(UserID, Password)
            End If


        Catch ex As Exception
            MessageBox.Show("アプリケーションを起動できませんでした。" & ChrW(Keys.Enter) & ex.Message, "Main()", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        Finally
            'スプラッシュ終了
            _spfm.Close()

        End Try


        Try
            'プロセスの実行モードがアプリケーション終了まで
            Do Until AppMode = AppModeType.AppExit
                Select Case AppMode
                    Case AppModeType.AppExec
                        'プロセス開始
                        Start()
                    Case AppModeType.AppLogOut
                        '認証プロセス
                        LoginFormSecureProcess()
                End Select
            Loop

        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "【メソッド】(Private) SetNaviMsg             : ガイドメッセージ表示 "

    Private Shared Sub SetNaviMsg(ByVal msg As String)
        _spfm.lblMsg.Text = msg
        _spfm.Refresh()
    End Sub

#End Region


End Class


#Region "【列挙型】 ExitMode "

Public Enum AppModeType As Byte
    AppExec
    AppExit
    AppLogOut
End Enum

#End Region