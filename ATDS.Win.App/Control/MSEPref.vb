Public Class MSEPref

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

    Public Sub Init()

        Dim lstPref As List(Of Combobox_Pref)

        Try
            lstPref = New List(Of Combobox_Pref)
            With lstPref
                .Add(New Combobox_Pref("", ""))
                .Add(New Combobox_Pref("01", "北海道"))
                .Add(New Combobox_Pref("02", "青森県"))
                .Add(New Combobox_Pref("03", "岩手県"))
                .Add(New Combobox_Pref("04", "宮城県"))
                .Add(New Combobox_Pref("05", "秋田県"))
                .Add(New Combobox_Pref("06", "山形県"))
                .Add(New Combobox_Pref("07", "福島県"))
                .Add(New Combobox_Pref("08", "茨城県"))
                .Add(New Combobox_Pref("09", "栃木県"))
                .Add(New Combobox_Pref("10", "群馬県"))
                .Add(New Combobox_Pref("11", "埼玉県"))
                .Add(New Combobox_Pref("12", "千葉県"))
                .Add(New Combobox_Pref("13", "東京都"))
                .Add(New Combobox_Pref("14", "神奈川県"))
                .Add(New Combobox_Pref("15", "新潟県"))
                .Add(New Combobox_Pref("16", "富山県"))
                .Add(New Combobox_Pref("17", "石川県"))
                .Add(New Combobox_Pref("18", "福井県"))
                .Add(New Combobox_Pref("19", "山梨県"))
                .Add(New Combobox_Pref("20", "長野県"))
                .Add(New Combobox_Pref("21", "岐阜県"))
                .Add(New Combobox_Pref("22", "静岡県"))
                .Add(New Combobox_Pref("23", "愛知県"))
                .Add(New Combobox_Pref("24", "三重県"))
                .Add(New Combobox_Pref("25", "滋賀県"))
                .Add(New Combobox_Pref("26", "京都府"))
                .Add(New Combobox_Pref("27", "大阪府"))
                .Add(New Combobox_Pref("28", "兵庫県"))
                .Add(New Combobox_Pref("29", "奈良県"))
                .Add(New Combobox_Pref("30", "和歌山県"))
                .Add(New Combobox_Pref("31", "鳥取県"))
                .Add(New Combobox_Pref("32", "島根県"))
                .Add(New Combobox_Pref("33", "岡山県"))
                .Add(New Combobox_Pref("34", "広島県"))
                .Add(New Combobox_Pref("35", "山口県"))
                .Add(New Combobox_Pref("36", "徳島県"))
                .Add(New Combobox_Pref("37", "香川県"))
                .Add(New Combobox_Pref("38", "愛媛県"))
                .Add(New Combobox_Pref("39", "高知県"))
                .Add(New Combobox_Pref("40", "福岡県"))
                .Add(New Combobox_Pref("41", "佐賀県"))
                .Add(New Combobox_Pref("42", "長崎県"))
                .Add(New Combobox_Pref("43", "熊本県"))
                .Add(New Combobox_Pref("44", "大分県"))
                .Add(New Combobox_Pref("45", "宮崎県"))
                .Add(New Combobox_Pref("46", "鹿児島"))
                .Add(New Combobox_Pref("47", "沖縄県"))
            End With

            With Me
                .DataSource = lstPref
                .DisplayMember = "Pref_Name"
                .ValueMember = "Pref_Code"
            End With
        Catch ex As Exception
            Throw

        Finally
            lstPref = Nothing
        End Try

    End Sub

#End Region

End Class

Public Class Combobox_Pref
    Protected _Pref_Code As String
    Protected _Pref_Name As String

    Public Sub New(ByVal strCode As String, ByVal strName As String)
        Me._Pref_Code = strCode
        Me._Pref_Name = strName
    End Sub

    Public ReadOnly Property Pref_Code() As String
        Get
            Return _Pref_Code
        End Get
    End Property

    Public ReadOnly Property Pref_Name() As String
        Get
            Return _Pref_Name
        End Get
    End Property
End Class
