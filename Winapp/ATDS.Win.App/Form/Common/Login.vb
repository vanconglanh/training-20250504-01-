Public Class Login


#Region "【内部変数】"

    Private Const CstrRequired As String = "{0}は必須項目です。"
    Private Const CstrUser As String = "ユーザー"
    Private Const CstrPassword As String = "パスワード"

    Private _UserID As String = String.Empty

#End Region


#Region "【Property】UserID　"

    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal Value As String)
            _UserID = Value
        End Set
    End Property
#End Region

#Region "【イベント】"

#Region "【イベント】 ページロード"
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            '--- コントロールデザイン初期化
            InitDesign()

            '--- 初期化
            Init()


        Catch ex As Exception
            Throw
        End Try

    End Sub

#End Region

#Region "【イベント】 ログインボタンクリック"


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frmMenu2 As Menu

        Try

            If CheckItems() = False Then
                Return
            End If

            Me.Hide()

            'frmMenu.ShowDialog()
            frmMenu2 = New Menu
            frmMenu2.ShowDialog()

            'frmMenu.Dispose()
            frmMenu2.Dispose()

            Me.Close()

            If UIProcess.LoginProcess(Me.txtUser.Text.Trim, Me.txtPassword.Text.Trim) Then
                Me.Close()
            Else
                Me.Visible = True
                Me.txtUser.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally

        End Try

    End Sub

#End Region

#End Region

#Region "【メソッド】"

#Region "【メソッド】 項目デザイン初期化"

    Private Sub InitDesign()

        Try

            With txtUser
                .IsNeed = True
                .MsgTitle = lblUser.Text
            End With

            With lblUser
                .IsNeed = txtUser.IsNeed
            End With

            With txtPassword
                .IsNeed = True
                .MsgTitle = lblPassword.Text
            End With

            With lblPassword
                .IsNeed = txtPassword.IsNeed
            End With
        Catch ex As Exception
            Throw
        Finally

        End Try



    End Sub

#End Region

#Region "【メソッド】 項目初期化"

    Private Sub Init()

        Try
            With txtUser
                .Text = String.Empty
            End With

            With txtPassword
                .Text = String.Empty
            End With

        Catch ex As Exception
            Throw
        Finally

        End Try



    End Sub

#End Region

#Region "【メソッド】 項目チェック"

    Private Function CheckItems() As Boolean

        Try

            If txtUser.CheckValue() = False Then
                Return False
            End If

            If txtPassword.CheckValue() = False Then
                Return False
            End If

            'If String.IsNullOrEmpty(txtUser.Text) Then
            '    MessageBox.Show(String.Format(CstrRequired, CstrUser),
            '                    "エラー",
            '                    MessageBoxButtons.OK,
            '                    MessageBoxIcon.Error)

            '    Return False

            'End If

            'If String.IsNullOrEmpty(txtPassword.Text) Then
            '    MessageBox.Show(String.Format(CstrRequired, CstrPassword),
            '                    "エラー",
            '                    MessageBoxButtons.OK,
            '                    MessageBoxIcon.Error)

            '    Return False

            'End If

            Return True

        Catch ex As Exception
            Throw
        End Try

    End Function

#End Region

#End Region
End Class