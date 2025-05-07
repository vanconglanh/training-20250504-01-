Imports System.AppDomain
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Public Class UIFormAdmin




#Region "【メソッド】FormShow   : フォーム表示 "

    Shared Function FormShow(ByVal FormName As String, ByVal FormTitle As String) As Boolean

        Dim tp As Type
        Dim fm As Form
        Dim fms As Form
        Dim idx As Integer = 0
        Dim tpg As New TabPage

        If FormName = "" Then Return True

        'For Each fms In _forms
        '    If fms.GetType.FullName = pgname And
        '           fms.Text = pgTitle Then
        '        If fms Is Nothing Then Exit For
        '        If fms.Visible = True Then
        '            _tab.SelectedIndex = idx
        '            _formindex = idx
        '            '--- 子フォーム設定(表示/リサイズ)
        '            fms.Activate()
        '            'UIProcess.MainForm.InitChildFormSize(fms)
        '            Return False
        '        End If
        '    End If
        '    idx += 1
        'Next

        ''--- タブページ15以上あげさせない！
        'If _tab.TabPages.Count >= 15 Then
        '    MessageBox.Show("これ以上画面を開けません。", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        'End If


        Cursor.Current = Cursors.WaitCursor

        tp = Type.GetType(FormName)

        fm = Activator.CreateInstance(tp)
        fm.Text = FormTitle

        '_forms.Add(fm)

        fm.FormBorderStyle = FormBorderStyle.Sizable
        fm.ControlBox = True
        fm.WindowState = FormWindowState.Normal
        fm.StartPosition = FormStartPosition.CenterScreen

        fm.Show()

        fm = Nothing
        tpg = Nothing

        Return True

    End Function
#End Region

End Class
