
Imports System.Text
Imports System.Text.RegularExpressions

Public Class MSEEdit

    Private _ImeDisabledRegex As Regex = New Regex("^[ -~]+$")

#Region "コンストラクタ"

    Public Sub New()

        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Font = My.Settings.EditFont
        Me.BackColor = Color.White
        Me.IsNextControl = True


    End Sub

#End Region

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        Dim encode As System.Text.Encoding = System.Text.Encoding.GetEncoding("shift_JIS")

        Select Case m.Msg
            Case &H302 'WM_PASTE
                Try
                    If Me.ImeMode = ImeMode.Disable Then
                        If Not Me._ImeDisabledRegex.IsMatch(My.Computer.Clipboard.GetText()) Then
                            Return
                        End If
                    End If

                    If encode.GetByteCount(My.Computer.Clipboard.GetText()) > Me.MaxLength Then
                        Me.Text = encode.GetString(encode.GetBytes(My.Computer.Clipboard.GetText()), 0, Me.MaxLength - 1)
                        Me.Select(Me.Text.Length, 0)
                        Return
                    End If
                Catch ex As Exception
                End Try
        End Select
        MyBase.WndProc(m)
    End Sub

End Class
