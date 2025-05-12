
Public Class MailMgr


    'Public Async Sub SendMail_(ByVal vstrToName As String, ByVal vstrToAddress As String, Optional ByVal vstrTitle As String = "", Optional ByVal vstrHonbun As String = "")

    '    Dim clsMailMgr As ATDS.Mail.MailMgr

    '    Try
    '        clsMailMgr = New ATDS.Mail.MailMgr
    '        Call clsMailMgr.SendMail("株式会社リプロセル 臨床検査室", vstrToName, vstrToAddress, vstrTitle, vstrHonbun)

    '    Catch ex As Exception
    '        Throw
    '    End Try

    'End Sub

    Public Async Sub SendMail(ByVal vstrToName As String, ByVal vstrToAddress As String, Optional ByVal vstrTitle As String = "", Optional ByVal vstrHonbun As String = "")

        Dim MailHost = "smtp.gmail.com"
        Dim MailPort = 587

        '社内検証用
        Dim UserName = "well.mill.ATDS@gmail.com"
        Dim PassWord = "qfuwncsvlbxbpodm１１１１１"

        Dim msg = New MimeKit.MimeMessage()

        '社内検証用
        msg.From.Add(New MimeKit.MailboxAddress("株式会社リプロセル 臨床検査室", "vanconglanh@gmail.com")) '送信元メールアドレス

        msg.To.Add(New MimeKit.MailboxAddress(vstrToName, vstrToAddress)) '送信先メールアドレス

        ' msg.Cc.Add() 'Cc用
        ' msg.Bcc.Add() 'Bcc用
        msg.Subject = vstrTitle 'タイトル

        Dim text = New MimeKit.TextPart(MimeKit.Text.TextFormat.Plain)

        text.Text = vstrHonbun ' 本文
        msg.Body = text

        Using client = New MailKit.Net.Smtp.SmtpClient()
            Try
                'Console.WriteLine("メール送信 start")

                Await client.ConnectAsync(MailHost, MailPort)       '接続
                Await client.AuthenticateAsync(UserName, PassWord)  '認証
                Await client.SendAsync(msg) '送信
                Await client.DisconnectAsync(True) '切断

                'Console.WriteLine("メール送信 end")

            Catch ex As Exception
                Throw
            End Try
        End Using

    End Sub


    Public Sub SendMail_Shuka(ByVal vstrToName As String, ByVal vstrToAddress As String,
                              ByVal vstrChumonNo As String, ByVal vstrShohinName As String, ByVal vintSuryo As Integer)

        Dim strTitle As String = String.Empty
        Dim strHonbun As String = String.Empty

        Try
            strTitle = "【ウェルミル】検査キット発送のお知らせ"

            strHonbun = vstrToName & "　様" & vbCrLf & vbCrLf
            strHonbun = strHonbun & "この度は ウェルミル をご利用いただき、誠にありがとうございます。" & vbCrLf
            strHonbun = strHonbun & "以下のご注文に関しまして、検査キットを発送いたしましたので、お知らせいたします。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf
            strHonbun = strHonbun & "【ご注文内容】" & vbCrLf
            strHonbun = strHonbun & "　注文番号：" & vstrChumonNo & vbCrLf
            strHonbun = strHonbun & "　品名：" & vstrShohinName & vbCrLf
            strHonbun = strHonbun & "　数量：" & vintSuryo & vbCrLf
            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "検査キットが到着しましたら、同封の手順を参照のうえ、ご対応よろしくお願いいたします。" & vbCrLf
            strHonbun = strHonbun & "検査キット発送後のマイページ情報の修正は反映されません。修正が必要な場合はお手数ですが" & vbCrLf
            strHonbun = strHonbun & "下記お問い合わせフォームからお願いいたします。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "※発送状況によっては、修正をお受けできない場合があります。ご了承ください。" & vbCrLf
            strHonbun = strHonbun & "※このメールは送信専用です。こちらのアドレスにご返信いただいても確認できませんので、" & vbCrLf
            strHonbun = strHonbun & "ご注意ください。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "その他ご不明点に関しましても、ウェルミル専用サイトのお問い合わせフォームから" & vbCrLf
            strHonbun = strHonbun & "ご相談いただけます。" & vbCrLf
            strHonbun = strHonbun & "https://www.well-mill.com/contact" & vbCrLf & vbCrLf & vbCrLf

            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf
            strHonbun = strHonbun & "株式会社リプロセル 臨床検査室" & vbCrLf
            strHonbun = strHonbun & "〒222-0033　神奈川県横浜市港北区新横浜3-8-11" & vbCrLf
            strHonbun = strHonbun & "0120-825-828" & vbCrLf
            strHonbun = strHonbun & "（平日　9:00～18:00 土日祝日休み）" & vbCrLf
            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf

            Call SendMail(vstrToName, vstrToAddress, strTitle, strHonbun)
        Catch ex As Exception
            Throw

        End Try

    End Sub

    Public Sub SendMail_Kentai_Uketsuke(ByVal vstrToName As String, ByVal vstrToAddress As String,
                             ByVal vstrKentaiID As String)

        Dim strTitle As String = String.Empty
        Dim strHonbun As String = String.Empty

        Try
            strTitle = "【ウェルミル】検体受付のお知らせ"

            strHonbun = vstrToName & "　様" & vbCrLf & vbCrLf
            strHonbun = strHonbun & "この度は ウェルミル をご利用いただき、誠にありがとうございます。" & vbCrLf
            strHonbun = strHonbun & "お客様の検体を受付いたしましたので、お知らせいたします。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf
            strHonbun = strHonbun & "　検体ID：" & vstrKentaiID & vbCrLf
            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "検査完了まで、しばらくお待ちください。" & vbCrLf & vbCrLf & vbCrLf

            strHonbun = strHonbun & "※このメールは送信専用です。こちらのアドレスにご返信いただいても確認できませんので、" & vbCrLf
            strHonbun = strHonbun & "ご注意ください。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "その他ご不明点に関しましても、ウェルミル専用サイトのお問い合わせフォームから" & vbCrLf
            strHonbun = strHonbun & "ご相談いただけます。" & vbCrLf
            strHonbun = strHonbun & "https://www.well-mill.com/contact" & vbCrLf & vbCrLf & vbCrLf

            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf
            strHonbun = strHonbun & "株式会社リプロセル 臨床検査室" & vbCrLf
            strHonbun = strHonbun & "〒222-0033　神奈川県横浜市港北区新横浜3-8-11" & vbCrLf
            strHonbun = strHonbun & "0120-825-828" & vbCrLf
            strHonbun = strHonbun & "（平日　9:00～18:00 土日祝日休み）" & vbCrLf
            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf

            Call SendMail(vstrToName, vstrToAddress, strTitle, strHonbun)
        Catch ex As Exception
            Throw

        End Try

    End Sub

    Public Sub SendMail_Kensa_Kanryo(ByVal vstrToName As String, ByVal vstrToAddress As String,
                          ByVal vstrKentaiID As String, ByVal vstrURL As String)

        Dim strTitle As String = String.Empty
        Dim strHonbun As String = String.Empty

        Try
            strTitle = "【ウェルミル】検査完了のお知らせ"

            strHonbun = vstrToName & "　様" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "この度は ウェルミル をご利用いただき、誠にありがとうございます。" & vbCrLf
            strHonbun = strHonbun & "お客様の検査が完了し、結果を反映いたしましたので、お知らせいたします。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf
            strHonbun = strHonbun & "　検体ID：" & vstrKentaiID & vbCrLf
            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "マイページよりログインいただき、結果についてご確認ください。" & vbCrLf
            strHonbun = strHonbun & vstrURL & vbCrLf & vbCrLf & vbCrLf

            strHonbun = strHonbun & "※このメールは送信専用です。こちらのアドレスにご返信いただいても確認できませんので、" & vbCrLf
            strHonbun = strHonbun & "ご注意ください。" & vbCrLf & vbCrLf

            strHonbun = strHonbun & "その他ご不明点に関しましても、ウェルミル専用サイトのお問い合わせフォームから" & vbCrLf
            strHonbun = strHonbun & "ご相談いただけます。" & vbCrLf
            strHonbun = strHonbun & "https://www.well-mill.com/contact" & vbCrLf & vbCrLf & vbCrLf

            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf
            strHonbun = strHonbun & "株式会社リプロセル 臨床検査室" & vbCrLf
            strHonbun = strHonbun & "〒222-0033　神奈川県横浜市港北区新横浜3-8-11" & vbCrLf
            strHonbun = strHonbun & "0120-825-828" & vbCrLf
            strHonbun = strHonbun & "（平日　9:00～18:00 土日祝日休み）" & vbCrLf
            strHonbun = strHonbun & "--------------------------------------------------" & vbCrLf

            Call SendMail(vstrToName, vstrToAddress, strTitle, strHonbun)

        Catch ex As Exception
            Throw

        End Try

    End Sub
End Class
