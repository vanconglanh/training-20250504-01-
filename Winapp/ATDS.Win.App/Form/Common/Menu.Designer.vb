<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.imgTitle = New System.Windows.Forms.PictureBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.pnlMaster = New System.Windows.Forms.Panel()
        Me.pnlTest = New System.Windows.Forms.Panel()
        Me.pnlMenu1 = New System.Windows.Forms.Panel()
        Me.pnlKokyakuKanri = New System.Windows.Forms.Panel()
        Me.pnlSyukkaKanri = New System.Windows.Forms.Panel()
        Me.pnlKentaiKanri = New System.Windows.Forms.Panel()
        Me.pnlKekkaKanri = New System.Windows.Forms.Panel()
        Me.btnShohinMaster = New ATDS.Win.App.MSEMenuButton()
        Me.btnTestList = New ATDS.Win.App.MSEMenuButton()
        Me.btnTestEntry = New ATDS.Win.App.MSEMenuButton()
        Me.btnKaiinToroku = New ATDS.Win.App.MSEMenuButton()
        Me.btnHojinToroku = New ATDS.Win.App.MSEMenuButton()
        Me.btnKentaiUketsuke = New ATDS.Win.App.MSEMenuButton()
        Me.btnKekkaNyuryoku = New ATDS.Win.App.MSEMenuButton()
        Me.btnLogout = New ATDS.Win.App.MSEMenuButton()
        Me.btnTest = New ATDS.Win.App.MSEMenuBar()
        Me.btnMaster = New ATDS.Win.App.MSEMenuBar()
        Me.btnKekkaKanri = New ATDS.Win.App.MSEMenuBar()
        Me.btnKentaiKanri = New ATDS.Win.App.MSEMenuBar()
        Me.btnSyukkaKanri = New ATDS.Win.App.MSEMenuBar()
        Me.btnKokyakuKanri = New ATDS.Win.App.MSEMenuBar()
        Me.btnChumonMeisaiEntry = New ATDS.Win.App.MSEMenuButton()
        Me.btnChumonMeisaiSearch = New ATDS.Win.App.MSEMenuButton()
        Me.btnChumonEntry = New ATDS.Win.App.MSEMenuButton()
        Me.btnChumonSearch = New ATDS.Win.App.MSEMenuButton()

        Me.pnlHeader.SuspendLayout()
        CType(Me.imgTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMaster.SuspendLayout()
        Me.pnlTest.SuspendLayout()
        Me.pnlMenu1.SuspendLayout()
        Me.pnlKokyakuKanri.SuspendLayout()
        Me.pnlKentaiKanri.SuspendLayout()
        Me.pnlKekkaKanri.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.imgTitle)
        Me.pnlHeader.Controls.Add(Me.txtUser)
        Me.pnlHeader.Controls.Add(Me.btnLogout)
        resources.ApplyResources(Me.pnlHeader, "pnlHeader")
        Me.pnlHeader.Name = "pnlHeader"
        '
        'imgTitle
        '
        resources.ApplyResources(Me.imgTitle, "imgTitle")
        Me.imgTitle.Image = Global.ATDS.Win.App.My.Resources.Resources.yoko
        Me.imgTitle.Name = "imgTitle"
        Me.imgTitle.TabStop = False
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.White
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtUser, "txtUser")
        Me.txtUser.Name = "txtUser"
        '
        'pnlMaster
        '
        Me.pnlMaster.BackColor = System.Drawing.Color.White
        Me.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMaster.Controls.Add(Me.btnShohinMaster)
        Me.pnlMaster.Controls.Add(Me.btnChumonMeisaiEntry)
        Me.pnlMaster.Controls.Add(Me.btnChumonMeisaiSearch)
        Me.pnlMaster.Controls.Add(Me.btnChumonEntry)
        Me.pnlMaster.Controls.Add(Me.btnChumonSearch)

        resources.ApplyResources(Me.pnlMaster, "pnlMaster")
        Me.pnlMaster.Name = "pnlMaster"
        '
        'pnlTest
        '
        Me.pnlTest.BackColor = System.Drawing.Color.White
        Me.pnlTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTest.Controls.Add(Me.btnTestList)
        Me.pnlTest.Controls.Add(Me.btnTestEntry)
        resources.ApplyResources(Me.pnlTest, "pnlTest")
        Me.pnlTest.Name = "pnlTest"
        '
        'pnlMenu1
        '
        Me.pnlMenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.pnlMenu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMenu1.Controls.Add(Me.btnTest)
        Me.pnlMenu1.Controls.Add(Me.btnMaster)
        Me.pnlMenu1.Controls.Add(Me.btnKekkaKanri)
        Me.pnlMenu1.Controls.Add(Me.btnKentaiKanri)
        Me.pnlMenu1.Controls.Add(Me.btnSyukkaKanri)
        Me.pnlMenu1.Controls.Add(Me.btnKokyakuKanri)
        resources.ApplyResources(Me.pnlMenu1, "pnlMenu1")
        Me.pnlMenu1.Name = "pnlMenu1"
        '
        'pnlKokyakuKanri
        '
        Me.pnlKokyakuKanri.BackColor = System.Drawing.Color.White
        Me.pnlKokyakuKanri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlKokyakuKanri.Controls.Add(Me.btnKaiinToroku)
        Me.pnlKokyakuKanri.Controls.Add(Me.btnHojinToroku)
        resources.ApplyResources(Me.pnlKokyakuKanri, "pnlKokyakuKanri")
        Me.pnlKokyakuKanri.Name = "pnlKokyakuKanri"
        '
        'pnlSyukkaKanri
        '
        Me.pnlSyukkaKanri.BackColor = System.Drawing.Color.White
        Me.pnlSyukkaKanri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.pnlSyukkaKanri, "pnlSyukkaKanri")
        Me.pnlSyukkaKanri.Name = "pnlSyukkaKanri"
        '
        'pnlKentaiKanri
        '
        Me.pnlKentaiKanri.BackColor = System.Drawing.Color.White
        Me.pnlKentaiKanri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlKentaiKanri.Controls.Add(Me.btnKentaiUketsuke)
        resources.ApplyResources(Me.pnlKentaiKanri, "pnlKentaiKanri")
        Me.pnlKentaiKanri.Name = "pnlKentaiKanri"
        '
        'pnlKekkaKanri
        '
        Me.pnlKekkaKanri.BackColor = System.Drawing.Color.White
        Me.pnlKekkaKanri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlKekkaKanri.Controls.Add(Me.btnKekkaNyuryoku)
        resources.ApplyResources(Me.pnlKekkaKanri, "pnlKekkaKanri")
        Me.pnlKekkaKanri.Name = "pnlKekkaKanri"
        '
        'btnChumonMeisaiEntry
        '
        Me.btnChumonMeisaiEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnChumonMeisaiEntry.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnChumonMeisaiEntry, "btnChumonMeisaiEntry")
        Me.btnChumonMeisaiEntry.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnChumonMeisaiEntry.FormName = "ATDS.Win.App.ChumonMeisaiEntry"
        Me.btnChumonMeisaiEntry.FormTitle = "ChumonMeisaiEntry"
        Me.btnChumonMeisaiEntry.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.None
        Me.btnChumonMeisaiEntry.Name = "btnChumonMeisaiEntry"
        Me.btnChumonMeisaiEntry.UseVisualStyleBackColor = False
        '
        'btnChumonMeisaiList
        '
        Me.btnChumonMeisaiSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnChumonMeisaiSearch, "btnChumonMeisaiSearch")
        Me.btnChumonMeisaiSearch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnChumonMeisaiSearch.FormName = "ATDS.Win.App.ChumonMeisaiSearch"
        Me.btnChumonMeisaiSearch.FormTitle = "ChumonMeisai Search"
        Me.btnChumonMeisaiSearch.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.None
        Me.btnChumonMeisaiSearch.Name = "btnChumonMeisaiSearch"
        Me.btnChumonMeisaiSearch.UseVisualStyleBackColor = False
        '
        'btnChumonEntry
        '
        Me.btnChumonEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnChumonEntry.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnChumonEntry, "btnChumonEntry")
        Me.btnChumonEntry.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnChumonEntry.FormName = "ATDS.Win.App.ChumonEntry"
        Me.btnChumonEntry.FormTitle = "ChumonEntry"
        Me.btnChumonEntry.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.None
        Me.btnChumonEntry.Name = "btnChumonEntry"
        Me.btnChumonEntry.UseVisualStyleBackColor = False
        '
        'btnChumonList
        '
        Me.btnChumonSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnChumonSearch, "btnChumonSearch")
        Me.btnChumonSearch.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnChumonSearch.FormName = "ATDS.Win.App.ChumonSearch"
        Me.btnChumonSearch.FormTitle = "Chumon Search"
        Me.btnChumonSearch.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.None
        Me.btnChumonSearch.Name = "btnChumonSearch"
        Me.btnChumonSearch.UseVisualStyleBackColor = False
        '
        'btnShohinMaster
        '
        Me.btnShohinMaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnShohinMaster, "btnShohinMaster")
        Me.btnShohinMaster.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnShohinMaster.FormName = ""
        Me.btnShohinMaster.FormTitle = ""
        Me.btnShohinMaster.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.None
        Me.btnShohinMaster.Name = "btnShohinMaster"
        Me.btnShohinMaster.UseVisualStyleBackColor = False
        '
        'btnTestList
        '
        Me.btnTestList.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnTestList, "btnTestList")
        Me.btnTestList.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnTestList.FormName = ""
        Me.btnTestList.FormTitle = ""
        Me.btnTestList.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.Touroku
        Me.btnTestList.Name = "btnTestList"
        Me.btnTestList.UseVisualStyleBackColor = False
        '
        'btnTestEntry
        '
        Me.btnTestEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnTestEntry, "btnTestEntry")
        Me.btnTestEntry.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnTestEntry.FormName = ""
        Me.btnTestEntry.FormTitle = ""
        Me.btnTestEntry.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.Touroku
        Me.btnTestEntry.Name = "btnTestEntry"
        Me.btnTestEntry.UseVisualStyleBackColor = False
        '
        'btnKaiinToroku
        '
        Me.btnKaiinToroku.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnKaiinToroku, "btnKaiinToroku")
        Me.btnKaiinToroku.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKaiinToroku.FormName = ""
        Me.btnKaiinToroku.FormTitle = ""
        Me.btnKaiinToroku.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.Touroku
        Me.btnKaiinToroku.Name = "btnKaiinToroku"
        Me.btnKaiinToroku.UseVisualStyleBackColor = False
        '
        'btnHojinToroku
        '
        Me.btnHojinToroku.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnHojinToroku.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnHojinToroku, "btnHojinToroku")
        Me.btnHojinToroku.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnHojinToroku.FormName = ""
        Me.btnHojinToroku.FormTitle = ""
        Me.btnHojinToroku.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.Touroku
        Me.btnHojinToroku.Name = "btnHojinToroku"
        Me.btnHojinToroku.UseVisualStyleBackColor = False
        '
        'btnKentaiUketsuke
        '
        Me.btnKentaiUketsuke.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnKentaiUketsuke, "btnKentaiUketsuke")
        Me.btnKentaiUketsuke.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKentaiUketsuke.FormName = ""
        Me.btnKentaiUketsuke.FormTitle = ""
        Me.btnKentaiUketsuke.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.Search
        Me.btnKentaiUketsuke.Name = "btnKentaiUketsuke"
        Me.btnKentaiUketsuke.UseVisualStyleBackColor = False
        '
        'btnKekkaNyuryoku
        '
        Me.btnKekkaNyuryoku.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(63, Byte), Integer))
        resources.ApplyResources(Me.btnKekkaNyuryoku, "btnKekkaNyuryoku")
        Me.btnKekkaNyuryoku.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKekkaNyuryoku.FormName = ""
        Me.btnKekkaNyuryoku.FormTitle = ""
        Me.btnKekkaNyuryoku.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.Touroku
        Me.btnKekkaNyuryoku.Name = "btnKekkaNyuryoku"
        Me.btnKekkaNyuryoku.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnLogout, "btnLogout")
        Me.btnLogout.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnLogout.FormName = ""
        Me.btnLogout.FormTitle = ""
        Me.btnLogout.MenuType = ATDS.Win.App.MSEMenuButton.enmMenuType.None
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnTest
        '
        Me.btnTest.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnTest.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnTest, "btnTest")
        Me.btnTest.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnTest.IsSelect = False
        Me.btnTest.Name = "btnTest"
        Me.btnTest.RelationPanel = Nothing
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnMaster
        '
        Me.btnMaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnMaster.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnMaster, "btnMaster")
        Me.btnMaster.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnMaster.IsSelect = False
        Me.btnMaster.Name = "btnMaster"
        Me.btnMaster.RelationPanel = Nothing
        Me.btnMaster.UseVisualStyleBackColor = True
        '
        'btnKekkaKanri
        '
        Me.btnKekkaKanri.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnKekkaKanri.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnKekkaKanri, "btnKekkaKanri")
        Me.btnKekkaKanri.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKekkaKanri.IsSelect = False
        Me.btnKekkaKanri.Name = "btnKekkaKanri"
        Me.btnKekkaKanri.RelationPanel = Nothing
        Me.btnKekkaKanri.UseVisualStyleBackColor = True
        '
        'btnKentaiKanri
        '
        Me.btnKentaiKanri.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnKentaiKanri.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnKentaiKanri, "btnKentaiKanri")
        Me.btnKentaiKanri.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKentaiKanri.IsSelect = False
        Me.btnKentaiKanri.Name = "btnKentaiKanri"
        Me.btnKentaiKanri.RelationPanel = Nothing
        Me.btnKentaiKanri.UseVisualStyleBackColor = True
        '
        'btnSyukkaKanri
        '
        Me.btnSyukkaKanri.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnSyukkaKanri.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnSyukkaKanri, "btnSyukkaKanri")
        Me.btnSyukkaKanri.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnSyukkaKanri.IsSelect = False
        Me.btnSyukkaKanri.Name = "btnSyukkaKanri"
        Me.btnSyukkaKanri.RelationPanel = Nothing
        Me.btnSyukkaKanri.UseVisualStyleBackColor = True
        '
        'btnKokyakuKanri
        '
        Me.btnKokyakuKanri.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.btnKokyakuKanri.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.btnKokyakuKanri, "btnKokyakuKanri")
        Me.btnKokyakuKanri.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKokyakuKanri.IsSelect = False
        Me.btnKokyakuKanri.Name = "btnKokyakuKanri"
        Me.btnKokyakuKanri.RelationPanel = Nothing
        Me.btnKokyakuKanri.UseVisualStyleBackColor = True
        '
        'Menu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMaster)
        Me.Controls.Add(Me.pnlSyukkaKanri)
        Me.Controls.Add(Me.pnlTest)
        Me.Controls.Add(Me.pnlKokyakuKanri)
        Me.Controls.Add(Me.pnlKentaiKanri)
        Me.Controls.Add(Me.pnlKekkaKanri)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlMenu1)
        Me.Name = "Menu"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.imgTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMaster.ResumeLayout(False)
        Me.pnlTest.ResumeLayout(False)
        Me.pnlMenu1.ResumeLayout(False)
        Me.pnlKokyakuKanri.ResumeLayout(False)
        Me.pnlKentaiKanri.ResumeLayout(False)
        Me.pnlKekkaKanri.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents imgTitle As PictureBox
    Friend WithEvents pnlMenu1 As Panel
    Friend WithEvents pnlKokyakuKanri As Panel
    Friend WithEvents pnlSyukkaKanri As Panel
    Friend WithEvents pnlKentaiKanri As Panel
    Friend WithEvents pnlKekkaKanri As Panel
    Friend WithEvents pnlMaster As Panel
    Friend WithEvents pnlTest As Panel
    Friend WithEvents txtUser As TextBox
    Friend WithEvents btnKokyakuKanri As MSEMenuBar
    Friend WithEvents btnMaster As MSEMenuBar
    Friend WithEvents btnKekkaKanri As MSEMenuBar
    Friend WithEvents btnKentaiKanri As MSEMenuBar
    Friend WithEvents btnSyukkaKanri As MSEMenuBar
    Friend WithEvents btnTest As MSEMenuBar
    Friend WithEvents btnLogout As MSEMenuButton
    Friend WithEvents btnHojinToroku As MSEMenuButton
    Friend WithEvents btnKaiinToroku As MSEMenuButton
    Friend WithEvents btnShohinMaster As MSEMenuButton
    Friend WithEvents btnKekkaNyuryoku As MSEMenuButton
    Friend WithEvents btnKentaiUketsuke As MSEMenuButton
    Friend WithEvents btnTestList As MSEMenuButton
    Friend WithEvents btnTestEntry As MSEMenuButton
        Friend WithEvents btnChumonMeisaiEntry As MSEMenuButton
        Friend WithEvents btnChumonMeisaiSearch As MSEMenuButton
        Friend WithEvents btnChumonEntry As MSEMenuButton
        Friend WithEvents btnChumonSearch As MSEMenuButton

End Class