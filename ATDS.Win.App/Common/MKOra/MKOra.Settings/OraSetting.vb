Public Class OraSetting
    Public ReadOnly UseSetting As Boolean
    Public ReadOnly Database As String
    Public ReadOnly UserName As String
    Public ReadOnly Password As String

    Public Sub New()

        Try
            Dim settings() As String = System.IO.File.ReadAllLines("OracleCredentialInSetting.txt")
            If settings(0) = "Yes" Then
                UseSetting = True
            End If
            Database = settings(1)
            UserName = settings(2)
            Password = settings(3)
        Catch ex As Exception

        End Try
    End Sub




End Class
