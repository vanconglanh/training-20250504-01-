Imports MES.Business

Public Class MSEComboBoxNameKbn

#Region "【Enum】"
    Public  Enum NAME_KBN
        URIAGE_TYPE = 1
    End Enum
#End Region

#Region "【Privateプロパティ】"
    ' Private _business As New NameKbnBusiness
    Private _items As List(Of ComboboxNameKbnItem)
#End Region

#Region "コンストラクタ"
    Public Sub New()
        Try
            With Me
                .Font = My.Settings.EditFont
                .BackColor = Color.White
                .IsNextControl = True
                .IsSelectOnly = True
            End With


        Catch ex As Exception
            Throw

        Finally

        End Try
    End Sub
#End Region

#Region "【メソッド】 Init"
    ' Public Sub Init(ByVal vintNameKbn As Integer, ByVal Optional VboolEmptyItemFlg As Boolean = False)

    '     Dim lst As List(Of UIEntry.NameKbnInfo)

    '     Try
    '         '--- Init
    '         Me._items = New List(Of ComboboxNameKbnItem)

    '         '--- Get data from DB
    '         lst = _business.GetList(vintNameKbn)
    '         '--- Get items list
    '         For Each row As UIEntry.NameKbnInfo In lst
    '             Me._items.Add(New ComboboxNameKbnItem(row.NameId, row.Name))
    '         Next

    '         If VboolEmptyItemFlg Then
    '             Me._items.Insert(0, New ComboboxNameKbnItem(-1, ""))
    '         End If

    '         With Me
    '             .DataSource = Me._items
    '             .DisplayMember = "Name"
    '             .ValueMember = "Code"
    '         End With
    '     Catch ex As Exception
    '         Throw
    '     End Try
    ' End Sub
#End Region

#Region "CloneDataSource"
    Public Function CloneDataSource() As List(Of ComboboxNameKbnItem)
        Return Me._items.ToList()
    End Function
#End Region

#Region "SetDataSource"
    Public Sub SetDataSource(ByVal items As List(Of ComboboxNameKbnItem))
        With Me
            .DataSource = items
            .DisplayMember = "Name"
            .ValueMember = "Code"
        End With
    End Sub
#End Region

End Class

Public Class ComboboxNameKbnItem
    Protected _Code As Integer
    Protected _Name As String

    Public Sub New(ByVal strCode As Integer, ByVal strName As String)
        Me._Code = strCode
        Me._Name = strName
    End Sub

    Public ReadOnly Property Code() As Integer
        Get
            Return _Code
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
End Class
