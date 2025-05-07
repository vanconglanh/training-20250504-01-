Public Class MSEMenuBar

    Private _IsSelect As Boolean = False
    Private _RelationPanel As Panel

#Region "コンストラクタ"

    Public Sub New()

        With Me

            .Font = My.Settings.MenuBarFont

            .BackColor = My.Settings.MenuBarColor
            .ForeColor = Color.WhiteSmoke

            .FlatStyle = FlatStyle.Flat

            .ImageAlign = ContentAlignment.MiddleCenter
            .TextAlign = ContentAlignment.MiddleRight
            .TextImageRelation = TextImageRelation.ImageBeforeText

            .UseVisualStyleBackColor = False

            .IsSelect = False

        End With


    End Sub

#End Region

#Region "【Property】IsSelect                   : 選択中フラグ(True：選択中　False：未選択） "

    Public Property IsSelect() As Boolean
        Get
            Return _IsSelect
        End Get
        Set(ByVal Value As Boolean)
            _IsSelect = Value

            If Value = True Then
                Me.BackColor = My.Settings.MenuBarColor_Select
                If IsNothing(Me.RelationPanel) = False Then
                    Me.RelationPanel.Visible = True
                End If
            Else
                Me.BackColor = My.Settings.MenuBarColor
                If IsNothing(Me.RelationPanel) = False Then
                    Me.RelationPanel.Visible = False
                End If
            End If
        End Set
    End Property


#End Region

#Region "【Property】RelationPanel                   : 関連パネル"

    Public Property RelationPanel() As Panel
        Get
            Return _RelationPanel
        End Get
        Set(ByVal Value As Panel)
            _RelationPanel = Value
        End Set
    End Property


#End Region

End Class
