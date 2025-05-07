Imports System.Text.RegularExpressions

Public Class MSEDataGrid

#Region "コンストラクタ"

    Public Sub New()

        With Me

            .SuspendLayout()

            .RowTemplate.Height = 30

            .EnableHeadersVisualStyles = False

            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 30
            .ColumnHeadersDefaultCellStyle.BackColor = My.Settings.LabelColor
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            .Init(SheetMode.Display)

            .ResumeLayout()
        End With

    End Sub

#End Region

#Region "ProcessDialogKey"
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Dim key As Keys = keyData And Keys.KeyCode

        If key = Keys.Enter Then
            MyBase.OnKeyDown(New KeyEventArgs(keyData))
            Return True
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function
#End Region

#Region "ProcessDialogKey"
    Private Sub MSEDataGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim ri As Integer = MyBase.CurrentCell.RowIndex
                Dim ci As Integer = MyBase.CurrentCell.ColumnIndex
                e.SuppressKeyPress = True

                FindNextCell(Me, ri, ci + 1)  'checking from Next  
            End If
        Catch
        End Try
    End Sub
#End Region

#Region "FindNextCell"
    Sub FindNextCell(ByVal dgv As MSEDataGrid, ByVal rowindex As Integer, ByVal columnindex As Integer)
        Dim found As Boolean = False

        While dgv.RowCount > rowindex
            While dgv.Columns.Count > columnindex
                If dgv.Rows(rowindex).Cells(columnindex).Visible And Not (dgv.Rows(rowindex).Cells(columnindex).ReadOnly) Then
                    '読取専用セルのみを読み飛ばす　→　読取専用セルと非表示セルを読み飛ばす。
                    dgv.CurrentCell = dgv.Rows(rowindex).Cells(columnindex)
                    Return
                Else
                    columnindex += 1
                End If
            End While

            If dgv.RowCount = rowindex + 1 Then
                dgv.ClearSelection()
                dgv.FindForm().SelectNextControl(Me, True, True, False, False)
                dgv.FindForm().ActiveControl.Focus()
            End If

            rowindex += 1
            columnindex = 0
        End While
    End Sub
#End Region

End Class
