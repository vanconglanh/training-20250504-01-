Imports System.IO
Imports System.Text

Public Class LogFile
    Public Shared Sub WriteText(strFilePath As String, strtext As String)
        If File.Exists(strFilePath) Then
            File.AppendAllText(strFilePath, String.Format("{0:yyyy/MM/dd HH:mm:ss} - {1}{2}", Date.Now, strtext, Environment.NewLine))
        Else
            Using fs As IO.FileStream = IO.File.Create(strFilePath)
                File.AppendAllText(strFilePath, String.Format("{0:yyyy/MM/dd HH:mm:ss} - {1}{2}", Date.Now, strtext, Environment.NewLine))
            End Using
        End If
    End Sub

    Public Shared Sub WriteText(strFilePath As String, strtext As String, encoding As Encoding)
        Try
            If File.Exists(strFilePath) Then
                File.AppendAllText(strFilePath, String.Format("{0:yyyy/MM/dd HH:mm:ss}  {1}{2}", Date.Now, strtext, Environment.NewLine), encoding)
            Else
                Using fs As IO.FileStream = IO.File.Create(strFilePath)
                    File.AppendAllText(strFilePath, String.Format("{0:yyyy/MM/dd HH:mm:ss}  {1}{2}", Date.Now, strtext, Environment.NewLine), encoding)
                End Using
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
