Imports System
Imports System.Windows.Forms

''' <summary>
''' Enterキーが押された時に、Tabキーが押されたのと同じ動作をする
''' （現在のセルを隣のセルに移動する）DataGridView
''' </summary>
Public Class DataGridViewEx
    Inherits DataGridView

    <System.Security.Permissions.UIPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, _
        Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogKey( _
            ByVal keyData As Keys) As Boolean
        'Enterキーが押された時は、Tabキーが押されたようにする
        If (keyData And Keys.KeyCode) = Keys.Enter Then
            Return Me.ProcessTabKey(keyData)
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    <System.Security.Permissions.SecurityPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, _
        Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Function ProcessDataGridViewKey( _
            ByVal e As KeyEventArgs) As Boolean
        'Enterキーが押された時は、Tabキーが押されたようにする
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessTabKey(e.KeyCode)
        End If
        Return MyBase.ProcessDataGridViewKey(e)
    End Function
End Class
