Public Class MSEMenuButton


#Region "【列挙】 enmMenuType "

    Public Enum enmMenuType As Byte

        None = 0
        Touroku         '--- 登録
        Search          '--- 検索
        Print           '--- 帳票
        Master          '--- マスタ
        LogOut          '--- ﾛｸﾞｱｳﾄ

    End Enum

#End Region

    Private _MenuType As enmMenuType = enmMenuType.None
    Private _FormName As String = String.Empty
    Private _FormTitle As String = String.Empty

#Region "コンストラクタ"

    Public Sub New()

        With Me

            .Font = My.Settings.MenuButtonFont

            .BackColor = My.Settings.MenuButtonColor
            .ForeColor = Color.WhiteSmoke

            .FlatStyle = FlatStyle.Flat

            .ImageAlign = ContentAlignment.TopCenter
            .TextAlign = ContentAlignment.BottomCenter

            .UseVisualStyleBackColor = False

        End With


    End Sub

#Region "【Event】MSEMenuButton_Click            : Click "

    Private Sub MSEMenuButton_Click(sender As Object, e As EventArgs) Handles Me.Click

        Try
            UIFormAdmin.FormShow(Me.FormName, Me.FormTitle)

        Catch ex As Exception

            Throw

        Finally

        End Try
    End Sub

#End Region

#End Region

#Region "【Property】MenuType                   : メニュー種類 "

    Public Property MenuType() As enmMenuType
        Get
            Return _MenuType
        End Get
        Set(ByVal Value As enmMenuType)
            _MenuType = Value

            Select Case Value
                Case enmMenuType.Touroku
                    Me.Image = My.Resources.Edit

                Case enmMenuType.Search
                    Me.Image = My.Resources.Edit

                Case enmMenuType.Print
                    Me.Image = My.Resources.Edit

                Case enmMenuType.Master
                    Me.Image = My.Resources.Edit

                Case enmMenuType.LogOut
                    Me.Image = My.Resources.Edit

                Case Else
                    Me.Image = Nothing

            End Select
        End Set
    End Property


#End Region

#Region "【Property】FormName                   : 起動フォーム名 "

    Public Property FormName() As String
        Get
            Return _FormName
        End Get
        Set(ByVal Value As String)
            _FormName = Value
        End Set
    End Property


#End Region

#Region "【Property】FormTitle                  : 起動フォームタイトル "

    Public Property FormTitle() As String
        Get
            Return _FormTitle
        End Get
        Set(ByVal Value As String)
            _FormTitle = Value
        End Set
    End Property


#End Region


End Class
