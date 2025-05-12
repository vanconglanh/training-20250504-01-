Public Class Menu

#Region "【イベント】"

#Region "【イベント】 ロード"
    Private Sub Menu2_Load(sender As Object, e As EventArgs) Handles Me.Load

        '--- コントロールデザイン初期化
        InitDesign()

        '--- 初期化
        Init()

    End Sub


#End Region

#Region "【テスト】 Menubarクリック"
    Private Sub btnMenubar_Click(sender As Object, e As EventArgs) Handles btnTest.Click, btnSyukkaKanri.Click, btnMaster.Click, btnKokyakuKanri.Click, btnKentaiKanri.Click, btnKekkaKanri.Click

        ChangeButtonBackgroundColor(CType(sender, MSEMenuBar))

    End Sub

#End Region

    'Private Sub btnTestEntry_Click(sender As Object, e As EventArgs)
    '    Dim frmEntry As New TestEntry

    '    frmEntry.Show()

    'End Sub

    'Private Sub btnTestList_Click(sender As Object, e As EventArgs)
    '    Dim frmList As New TestList

    '    frmList.Show()
    'End Sub


#End Region

#Region "【メソッド】"

#Region "【メソッド】 項目デザイン初期化"

    Private Sub InitDesign()

        Try

            With btnKokyakuKanri
                .RelationPanel = pnlKokyakuKanri
            End With

            With btnSyukkaKanri
                .RelationPanel = pnlSyukkaKanri

            End With

            With btnKentaiKanri
                .RelationPanel = pnlKentaiKanri

            End With

            With btnKekkaKanri
                .RelationPanel = pnlKekkaKanri

            End With

            With btnMaster
                .RelationPanel = pnlMaster

            End With

            With btnTest
                .RelationPanel = pnlTest
                .Visible = True
            End With

            With btnTestEntry
                .FormName = "ATDS.Win.App.MCompanyEntry"
                .FormTitle = Me.Text
            End With

            With btnTestList
                .FormName = "ATDS.Win.App.TestList"
                .FormTitle = Me.Text
            End With

            With btnHojinToroku
                .FormName = "ATDS.Win.App.HojinEntry"
                .FormTitle = Me.Text
            End With

            With btnKaiinToroku
                .FormName = "ATDS.Win.App.KaiinEntry"
                .FormTitle = Me.Text
            End With

            With btnShohinMaster
                .FormName = "ATDS.Win.App.ShohinEntry"
                .FormTitle = Me.Text
            End With

            With btnKentaiUketsuke
                .FormName = "ATDS.Win.App.KentaiUketsuke"
                .FormTitle = Me.Text
            End With

            With btnKekkaNyuryoku
                .FormName = "ATDS.Win.App.KekkaEntry"
                .FormTitle = Me.Text
            End With

        Catch ex As Exception
            Throw
        Finally

        End Try

    End Sub

#End Region

#Region "【メソッド】 項目初期化"

    Private Sub Init()

        Try
            With btnKokyakuKanri
                .IsSelect = False
            End With

            With btnSyukkaKanri
                .IsSelect = False
            End With

            With btnKentaiKanri
                .IsSelect = False
            End With

            With btnKekkaKanri
                .IsSelect = False
            End With

            With btnMaster
                .IsSelect = False
            End With

            With btnTest
                .IsSelect = False
            End With


        Catch ex As Exception
            Throw
        Finally

        End Try



    End Sub

#End Region


#Region "【メソッド】 ボタン背景色変更"
    Private Sub ChangeButtonBackgroundColor(ByVal btn As MSEMenuBar)

        Try

            btnKokyakuKanri.IsSelect = False
            btnSyukkaKanri.IsSelect = False
            btnKentaiKanri.IsSelect = False
            btnKekkaKanri.IsSelect = False
            btnMaster.IsSelect = False
            btnTest.IsSelect = False

            With btn
                .IsSelect = True
            End With

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()

    End Sub


#End Region

#End Region

End Class