Imports System.IO
Imports System.Net.Mail

Public Class MKSendMail

    Dim smtp As SmtpClient
    Public [From] As MailAddress
    Public [To] As New MailAddressCollection
    Public Server As MailAddress
    Public Subject As String
    Public Body As String
    Public Sub New(strSMTP As String, strUser As String, mstrPassword As String)

        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

        smtp = New SmtpClient
        smtp.UseDefaultCredentials = False
        smtp.Credentials = New Net.NetworkCredential(strUser, mstrPassword)
        smtp.Port = 587
        'smtp.EnableSsl = False'2024/02/06 サーバー変更
        smtp.EnableSsl = True
        smtp.Host = strSMTP
    End Sub
    Public Function SendMail(strLogFilePath As String) As String
        Try
            LogFile.WriteText(strLogFilePath, BuildLogString(True, smtp.Host, [From].Address, [To].ToString, Subject), System.Text.Encoding.GetEncoding("shift-jis"))
            Dim eMail As New MailMessage()

            eMail = New MailMessage()
            eMail.From = [From]
            For Each item In [To]
                eMail.To.Add(item)
            Next
            eMail.Subject = Subject
            eMail.IsBodyHtml = False
            eMail.Body = Body

            smtp.Send(eMail)

            LogFile.WriteText(strLogFilePath, BuildLogString(False, smtp.Host, [From].Address, [To].ToString, Subject), System.Text.Encoding.GetEncoding("shift-jis"))

        Catch ex As Exception
            Return ex.Message
        End Try

        Return String.Empty

    End Function

    Public Function SendMail(strLogFilePath As String, strTo As String, strFrom As String, strSubject As String, strBody As String, strFilePath As String) As String
        Try
            LogFile.WriteText(strLogFilePath, BuildLogString(True, smtp.Host, strFrom, strTo, strSubject), System.Text.Encoding.GetEncoding("shift-jis"))
            Dim eMail As New MailMessage()

            eMail = New MailMessage()
            eMail.From = New MailAddress(strFrom)
            eMail.To.Add(strTo)
            eMail.Subject = strSubject
            eMail.IsBodyHtml = False
            eMail.Body = strBody

            smtp.Send(eMail)

            LogFile.WriteText(strLogFilePath, BuildLogString(False, smtp.Host, strFrom, strTo, strSubject), System.Text.Encoding.GetEncoding("shift-jis"))

        Catch ex As Exception
            Return ex.Message
        End Try

        Return String.Empty

    End Function

    Private Function BuildLogString(bStartSend As Boolean, strSMTP As String, strFrom As String, strTo As String, strSubject As String) As String
        Dim strLogString As String = ""
        If bStartSend Then
            strLogString += "送信開始"
        Else
            strLogString += "送信完了"
        End If

        strLogString += " " + strSMTP
        strLogString += " " + strFrom
        strLogString += " " + strTo
        strLogString += " " + strSubject

        Return strLogString

    End Function
End Class
