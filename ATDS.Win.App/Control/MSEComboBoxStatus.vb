Imports MES.Business

Public Class MSEComboBoxStatus

#Region "コンストラクタ"
    Public Sub New()
        Try
            With Me
                .Font = My.Settings.EditFont
                .BackColor = Color.White
                .IsNextControl = True
                .IsSelectOnly = True
            End With


        Catch ex As Exception
            Throw

        Finally

        End Try
    End Sub
#End Region

#Region "【メソッド】 Init"
    Public Sub Init()

        Dim lst As List(Of ComboboxStatusItem)

        Try
            lst = New List(Of ComboboxStatusItem)
            With lst
                .Add(New ComboboxStatusItem(0, "未"))
                .Add(New ComboboxStatusItem(1, "待機"))
                .Add(New ComboboxStatusItem(2, "梱包中"))
                .Add(New ComboboxStatusItem(3, "発送済み"))
                .Add(New ComboboxStatusItem(4, "情報登録済み"))
                .Add(New ComboboxStatusItem(5, "検体受付済み"))
                .Add(New ComboboxStatusItem(6, "ラベル未発行"))
                .Add(New ComboboxStatusItem(7, "検査中"))
                .Add(New ComboboxStatusItem(8, "未報告"))
                .Add(New ComboboxStatusItem(9, "検査報告完了"))
                .Add(New ComboboxStatusItem(10, "売上計上済み"))
                .Add(New ComboboxStatusItem(11, "結果なし売上"))
                .Add(New ComboboxStatusItem(12, "売上計上なし"))
            End With

            With Me
                .DataSource = lst
                .DisplayMember = "Name"
                .ValueMember = "Code"
            End With
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

End Class

Public Class ComboboxStatusItem
    Protected _Code As Integer
    Protected _Name As String

    Public Sub New(ByVal strCode As Integer, ByVal strName As String)
        Me._Code = strCode
        Me._Name = strName
    End Sub

    Public ReadOnly Property Code() As Integer
        Get
            Return _Code
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
End Class
