Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Oracle.ManagedDataAccess.Client
Public Class OraDynaset
    Implements IDisposable

    Private m_DataTable As DataTable
    Private m_Fields As OraFields
    Private m_RowPosition As Integer = 0
    Private m_Adapter As OracleDataAdapter
    'Private m_DataSet As DataSet
    Private m_OraDatabase As OraDatabase
    Private m_AddEditMode As Short
    'For adding new row
    Private m_NewRow As DataRow
    Private m_NewFields As OraFields
    Private m_DynOption As Integer
    Friend Sub New(ByVal dt As DataTable, ByRef adapter As OracleDataAdapter,
                    ByRef database As OraDatabase, ByVal dynOption As Integer)
        m_Adapter = adapter
        m_DataTable = dt
        m_DynOption = dynOption
        m_Fields = New OraFields(Me, dt.Columns)
        m_OraDatabase = database
        m_AddEditMode = DYNASET_UNCHANGED
        MoveFirst()
    End Sub

    'Friend Sub New(ByVal ds As DataSet, ByRef adapter As OracleDataAdapter)
    '    m_Adapter = adapter
    '    m_DataSet = ds
    '    m_DataTable = ds.Tables(0)
    '    m_Fields = New OraFields(Me, m_DataTable.Columns)
    '    MoveFirst()
    'End Sub

    Public ReadOnly Property Fields As OraFields
        Get
            Return m_Fields
        End Get
    End Property

    Public Sub Dispose() Implements System.IDisposable.Dispose
        If m_DataTable IsNot Nothing Then
            m_DataTable.Dispose()
            m_DataTable = Nothing
        End If

        GC.SuppressFinalize(Me)
    End Sub

    Public Sub MoveFirst()
        If m_AddEditMode = DYNASET_UNCHANGED Then
            m_RowPosition = 0
        Else
            Throw New Exception("Unable to Move First. DataSet is being editted")
        End If


    End Sub
    Public Sub DbMoveFirst()
        MoveFirst()
    End Sub
    Public Sub MoveNext()
        If m_AddEditMode = DYNASET_UNCHANGED Then
            m_RowPosition += 1
        Else
            Throw New Exception("Unable to Move Next. DataSet is being editted")
        End If

    End Sub
    Public Sub DbMoveNext()
        MoveNext()
    End Sub

    Public Sub MovePrevious()
        If m_AddEditMode = DYNASET_UNCHANGED Then
            'If m_RowPosition > 0 Then
            '    m_RowPosition = m_RowPosition - 1
            'End If
            m_RowPosition = m_RowPosition - 1
        Else
            Throw New Exception("Unable to Move Previous. DataSet is being editted")
        End If

    End Sub
    Public Sub DbMovePrevious()
        MovePrevious()
    End Sub
    Public ReadOnly Property EOF As Boolean
        Get
            Try
                Return m_RowPosition >= m_DataTable.Rows.Count
            Catch ex As Exception
                Return True
            End Try
        End Get
    End Property

    Public ReadOnly Property RecordCount As Integer
        Get
            Return m_DataTable.Rows.Count
        End Get
    End Property

    Public ReadOnly Property DbRecordCount As Integer
        Get
            Return RecordCount
        End Get
    End Property

    Public ReadOnly Property DataTable As DataTable
        Get
            Return m_DataTable
        End Get
    End Property


    Friend ReadOnly Property CurrentRow As DataRow
        Get
            If m_AddEditMode = DYNASET_ADD Then
                Return m_NewRow
            Else
                '++修正開始　2020年09月01:Unitec（手）- VB→VB.NET変換
                'If m_DataTable IsNot Nothing And m_DataTable.Rows.Count > 0 Then
                If m_DataTable Is Nothing Then
                    Return Nothing
                End If
                If m_DataTable IsNot Nothing And m_DataTable.Rows.Count > 0 And m_DataTable.Rows.Count > m_RowPosition Then
                    '--修正終了　2020年09月01:Unitec（手）- VB→VB.NET変換
                    Return m_DataTable.Rows(m_RowPosition)
                Else
                    Return Nothing
                End If

            End If

        End Get
    End Property
    Public Sub Close()
        Me.Dispose()
    End Sub


    Public Sub Edit()
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If
            m_AddEditMode = DYNASET_UPDATE
            Dim currentRow = m_DataTable.Rows(m_RowPosition)
            If currentRow IsNot Nothing Then
                'currentRow.BeginEdit()
                If currentRow.RowState <> DataRowState.Modified And currentRow.RowState <> DataRowState.Added Then
                    currentRow.SetModified()
                End If
            End If
        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try



    End Sub
    Public Sub DbEdit()
        Edit()
    End Sub
    Public Sub Update()
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If

            If m_AddEditMode = DYNASET_UPDATE Then
                DataTableUpdate()
            End If
            If m_AddEditMode = DYNASET_ADD Then
                DataTableInsert()
            End If
        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try

    End Sub

    Public Sub Update(Optional isUpdateExplicitly As Boolean = False,
                      Optional ByVal strTableName As String = "",
                      Optional ByVal keyColumns As List(Of String) = Nothing)
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If

            If m_AddEditMode = DYNASET_UPDATE Then
                If isUpdateExplicitly Then
                    UpdateExplicitly(strTableName, keyColumns)
                Else
                    DataTableUpdate()
                End If
            End If
            If m_AddEditMode = DYNASET_ADD Then
                DataTableInsert()
            End If
        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try

    End Sub
    ''' <summary>
    ''' Update explicitly a table with the logic primary keys ( there is no actual primary key in the oracle table )
    ''' </summary>
    ''' <param name="strTableName">Table name </param>
    ''' <param name="keyColumns">List of composite primary keys </param>

    Public Sub UpdateExplicitly(ByVal strTableName As String, ByVal keyColumns As List(Of String))

        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If

            If m_AddEditMode = DYNASET_UPDATE Then
                Try
                    If DynOption = ORADYN_READONLY Then
                        Throw New Exception("Not Allow to update data")

                    End If

                    Dim currentRow = m_DataTable.Rows(m_RowPosition)
                    If currentRow Is Nothing Then
                        'Throw exception 
                        Throw New System.Exception("No data is available to be updated.")
                    End If
                    'currentRow.AcceptChanges()
                    Dim tmpRows() As DataRow = {currentRow}

                    Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter)
                    'Dim updateCmd As OracleCommand = cmdBuilder.GetUpdateCommand()
                    'Check table name 
                    Dim databaseTableName As String

                    '--修正終了　2020年07月14:Unitec（手）- VB→VB.NET変換
                    databaseTableName = currentRow.Table.TableName
                    If strTableName IsNot Nothing Then
                        'Try to get the table name again to double check with strTableName

                        If strTableName.ToUpper() <> databaseTableName Then
                            Throw New System.Exception($"Table {strTableName} is not correct in Select command")
                        End If
                    End If

                    'Check primary key
                    If m_DataTable.PrimaryKey.Count = 0 Then

                        Dim dtKeyColumns As New List(Of DataColumn)
                        For i = 0 To keyColumns.Count - 1
                            dtKeyColumns.Add(m_DataTable.Columns(keyColumns(i)))
                        Next

                        m_DataTable.PrimaryKey = dtKeyColumns.ToArray()
                    Else
                        If m_DataTable.PrimaryKey.Count <> keyColumns.Count Then
                            Throw New System.Exception($"Table {strTableName} already has another primary keys.")
                        Else
                            For i = 0 To keyColumns.Count - 1
                                If m_DataTable.PrimaryKey(i).ColumnName <> keyColumns(i) Then
                                    Throw New System.Exception($"Table {strTableName} does not have column " + keyColumns(i))
                                End If
                            Next
                        End If
                    End If

                    m_Adapter.Update(tmpRows)
                    currentRow.AcceptChanges()
                    m_AddEditMode = DYNASET_UNCHANGED

                Catch ex As OracleException
                    m_OraDatabase.Session.KeepLastException(ex)
                    Throw
                End Try
            End If
            If m_AddEditMode = DYNASET_ADD Then
                DataTableInsert()
            End If
        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try

    End Sub
    Private Sub DataTableUpdate()
        Dim currentRow = m_DataTable.Rows(m_RowPosition)
        If currentRow Is Nothing Then
            Throw New System.Exception("No data is available to be updated.")
        End If
        If currentRow IsNot Nothing Then
            Dim hasRowId As Boolean = False
            If m_DataTable.PrimaryKey.Count = 0 Then
                For i As Integer = 0 To m_DataTable.Columns.Count - 1
                    If m_DataTable.Columns(i).ColumnName.ToUpper() = "ROWID" Then
                        hasRowId = True
                    End If
                Next i

                If hasRowId Then
                    UpdateWithRowID(Nothing)
                Else
                    UpdateWithoutKey(Nothing)
                End If
            Else
                Dim tmpRows() As DataRow = {currentRow}
                Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter) 'Note: There will be error Without OracleCommandBuilder 

                m_Adapter.Update(tmpRows)
                currentRow.AcceptChanges()
            End If
        End If
        m_AddEditMode = DYNASET_UNCHANGED
    End Sub
    Private Sub DataTableInsert()

        'If CurrentRow IsNot Nothing Then

        '    Dim tmpRows() As DataRow = {CurrentRow}

        '    Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter) 'Note: There will be error Without OracleCommandBuilder 

        '    m_Adapter.Update(tmpRows)
        '    CurrentRow.AcceptChanges()
        '    m_NewRow = Nothing
        '    m_NewFields = Nothing
        'End If
        If m_NewRow IsNot Nothing Then
            Dim hasRowId As Boolean = False
            For i As Integer = 0 To m_DataTable.Columns.Count - 1
                If m_DataTable.Columns(i).ColumnName.ToUpper() = "ROWID" Then
                    hasRowId = True
                End If
            Next i

            If hasRowId Then
                Dim selectQuery As String = m_Adapter.SelectCommand.CommandText


                'Remove ROWID
                selectQuery = selectQuery.Replace("ROWID,", "")
                Dim cmd2 As OracleCommand = New OracleCommand(selectQuery.Replace(vbCrLf, vbLf), m_Adapter.SelectCommand.Connection)

                cmd2.InitialLONGFetchSize = -1

                Dim adapter2 As OracleDataAdapter = New OracleDataAdapter(cmd2)

                adapter2.ReturnProviderSpecificTypes = True
                If m_Adapter.SelectCommand.Parameters IsNot Nothing And m_Adapter.SelectCommand.Parameters.Count > 0 Then

                    For i As Integer = 0 To m_Adapter.SelectCommand.Parameters.Count - 1
                        adapter2.SelectCommand.Parameters.Add(m_Adapter.SelectCommand.Parameters(0))
                    Next i

                End If
                adapter2.MissingSchemaAction = MissingSchemaAction.AddWithKey 'Get Primary Key from Table

                Dim dt2 As DataTable = New DataTable()
                adapter2.Fill(dt2)
                Dim row2 As DataRow = dt2.NewRow()
                'For i As Integer = 0 To m_NewRow.ItemArray.Count - 1
                For i As Integer = 0 To m_DataTable.Columns.Count - 1
                    If m_DataTable.Columns(i).ColumnName.ToUpper() <> "ROWID" Then
                        row2(m_DataTable.Columns(i).ColumnName) = m_NewRow(m_DataTable.Columns(i).ColumnName) ' Copy cell value
                    End If

                Next i


                dt2.Rows.Add(row2)
                Dim tmpRows() As DataRow = {row2}

                Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(adapter2) 'Note: There will be error Without OracleCommandBuilder 

                adapter2.Update(tmpRows)
                row2.AcceptChanges()

                'Rebuild m_Adapter, m_DataTable , m_Fields

                selectQuery = m_Adapter.SelectCommand.CommandText



                Dim cmd3 As OracleCommand = New OracleCommand(selectQuery.Replace(vbCrLf, vbLf), m_Adapter.SelectCommand.Connection)

                cmd3.InitialLONGFetchSize = -1

                Dim adapter3 As OracleDataAdapter = New OracleDataAdapter(cmd3)

                adapter3.ReturnProviderSpecificTypes = True
                If m_Adapter.SelectCommand.Parameters IsNot Nothing And m_Adapter.SelectCommand.Parameters.Count > 0 Then

                    For i As Integer = 0 To m_Adapter.SelectCommand.Parameters.Count - 1
                        adapter3.SelectCommand.Parameters.Add(m_Adapter.SelectCommand.Parameters(0))
                    Next i

                End If
                adapter3.MissingSchemaAction = MissingSchemaAction.AddWithKey 'Get Primary Key from Table

                Dim dt3 As DataTable = New DataTable()
                adapter3.Fill(dt3)
                m_DataTable = dt3
                m_Adapter = adapter3
                m_Fields = New OraFields(Me, dt3.Columns)

            Else
                m_DataTable.Rows.Add(m_NewRow)
                Dim tmpRows() As DataRow = {m_NewRow}

                Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter) 'Note: There will be error Without OracleCommandBuilder 

                m_Adapter.Update(tmpRows)
                m_NewRow.AcceptChanges()
            End If


        End If
        m_NewRow = Nothing
        m_NewFields = Nothing
        m_RowPosition = m_DataTable.Rows.Count - 1
        m_AddEditMode = DYNASET_UNCHANGED
    End Sub
    Public Sub DbUpdate()
        Update()

    End Sub


    Public Sub UpdateWithoutKey(ByVal strTableName As String, Optional ByVal checkConstraintOneRow As Boolean = True)
        'Because ODP.NET Adapter requires primary key of table to update
        'So sometime the table which has no primary key can not be updated 
        '=> This method is a way of workaround to do that 
        'Only use this method to update table which has only one row, such as SKFZ20
        'Need to check carefully before updating
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If

            Dim currentRow = m_DataTable.Rows(m_RowPosition)
            If currentRow Is Nothing Then
                'Throw exception 
                Throw New System.Exception("No data is available to be updated.")
            End If
            'currentRow.AcceptChanges()
            Dim tmpRows() As DataRow = {currentRow}

            Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter)
            'Dim updateCmd As OracleCommand = cmdBuilder.GetUpdateCommand()
            If m_DataTable.PrimaryKey.Count = 0 Then
                Dim databaseTableName As String

                '--修正終了　2020年07月14:Unitec（手）- VB→VB.NET変換
                databaseTableName = currentRow.Table.TableName
                If strTableName IsNot Nothing Then
                    'Try to get the table name again to double check with strTableName


                    If strTableName.ToUpper() <> databaseTableName Then
                        Throw New System.Exception($"Table {strTableName} is not correct in Select command")
                    End If
                End If


                If checkConstraintOneRow = True Then
                    'Need to check the whole table to make sure that the table has only one row , such as SKFZ20
                    'Dim adapter As OracleDataAdapter = New OracleDataAdapter($"SELECT * FROM {databaseTableName}", m_OraDatabase.Session.OracleConnection)
                    Dim adapter As OracleDataAdapter = New OracleDataAdapter($"SELECT COUNT(*) AS ROWCOUNT FROM {databaseTableName}", m_OraDatabase.Session.OracleConnection)
                    adapter.ReturnProviderSpecificTypes = True
                    Dim dt As DataTable = New DataTable()
                    adapter.Fill(dt)
                    'If dt Is Nothing Or dt.Rows().Count <> 1 Then
                    '    Throw New System.Exception($"Table {strTableName} must have only one row")
                    'End If
                    If dt Is Nothing Or CInt((dt.Rows(0)(0)).Value) > 1 Then
                        Throw New System.Exception($"Table {strTableName} must have only one row")
                    End If
                End If
                'm_DataTable.Columns.Add(New DataColumn("_ID_", System.Type.GetType("System.String")))
                'm_DataTable.Columns("_ID_").Unique = True => There might be column _ID_ is existing => Improve below
                'Make to make sure the column Name is not existing
                Dim dumpIdCol As String
                dumpIdCol = "ID_"
                For idx As Integer = 0 To Int32.MaxValue
                    If m_DataTable.Columns.Contains(dumpIdCol) Then
                        dumpIdCol = dumpIdCol + idx.ToString()
                    Else
                        Exit For
                    End If
                Next
                m_DataTable.Columns.Add(New DataColumn(dumpIdCol, System.Type.GetType("System.String")))
                m_DataTable.Columns(dumpIdCol).Unique = True
                m_Adapter.Update(tmpRows)
                currentRow.AcceptChanges()
            Else
                'Throw exception 
                Throw New System.Exception($"Table {strTableName} already has key { m_DataTable.PrimaryKey(0).ColumnName}")
            End If

            m_AddEditMode = DYNASET_UNCHANGED

        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try


    End Sub

    Public Sub UpdateWithRowID(ByVal strTableName As String, Optional ByVal checkConstraintOneRow As Boolean = True)
        'Because ODP.NET Adapter requires primary key of table to update
        'So sometime the table which has no primary key can not be updated 
        '=> This method is a way of workaround to do that 
        'Only use this method to update table which has only one row, such as SKFZ20
        'Need to check carefully before updating
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If

            Dim currentRow = m_DataTable.Rows(m_RowPosition)
            If currentRow Is Nothing Then
                'Throw exception 
                Throw New System.Exception("No data is available to be updated.")
            End If
            'currentRow.AcceptChanges()
            Dim tmpRows() As DataRow = {currentRow}

            Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter)

            ' m_DataTable.Columns.Add(New DataColumn("ROWID", System.Type.GetType("System.String")))
            m_DataTable.Columns("ROWID").Unique = True
            m_Adapter.Update(tmpRows)
            currentRow.AcceptChanges()


            m_AddEditMode = DYNASET_UNCHANGED

        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try


    End Sub


    Default Public ReadOnly Property Item(ByVal name As String) As OraField
        Get
            'Applied for m_oDynaset(.proItemName).Value
            If m_AddEditMode = DYNASET_ADD Then
                Return m_NewFields(name)
            Else
                Return m_Fields(name)
            End If

        End Get
    End Property
    Default Public ReadOnly Property Item(ByVal index As Integer) As OraField
        Get
            If m_AddEditMode = DYNASET_ADD Then
                Return m_NewFields(index)
            Else
                Return m_Fields(index)
            End If
        End Get
    End Property

    Public Sub DbAddNew()
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to update data")

            End If
            m_AddEditMode = DYNASET_ADD
            'Dim newRow As DataRow = m_DataTable.NewRow()
            'm_DataTable.Rows.Add(newRow) ' If the m_DataTable has Primary Key then adding new row without key data will cause error => Keep new Row in a new property m_NewRow
            m_NewRow = m_DataTable.NewRow()
            m_NewFields = New OraFields(Me, m_DataTable.Columns)
            m_RowPosition = -1 'Add Mode
        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try



    End Sub
    Public Sub AddNew()
        DbAddNew()
    End Sub
    Public Sub SetPrimaryKey(ByVal idxColumn As Integer)
        m_DataTable.Columns(idxColumn).Unique = True

        m_DataTable.PrimaryKey.Append(m_DataTable.Columns(idxColumn))
    End Sub

    Public ReadOnly Property AddEditMode As Short
        Get
            Return m_AddEditMode
        End Get
    End Property
    Public ReadOnly Property HasPrimaryKey As Boolean
        Get
            Return m_DataTable.PrimaryKey.Count > 0
        End Get
    End Property
    Public ReadOnly Property DynOption As Integer
        Get
            Return m_DynOption

        End Get

    End Property

    Public Sub MoveTo(ByVal rowIndex As Integer)
        'old oo4o => https://docs.oracle.com/cd/B13789_01/win.101/b10118/o4o00363.htm
        If m_AddEditMode = DYNASET_UNCHANGED Then
            If RecordCount = 0 Then
                m_RowPosition = -1
                Return
            End If
            If (rowIndex >= RecordCount) Then
                m_RowPosition = RecordCount - 1
            Else
                m_RowPosition = rowIndex
            End If
            If CurrentRow.RowState = DataRowState.Deleted Then
                MoveTo(rowIndex + 1) 'Follow the logic of oo4o =>  If the row has been deleted, MoveTo moves to the next valid row after the one requested.
            End If
        Else
            Throw New Exception("Unable to Move To. DataSet is being editted")
        End If

    End Sub

    Public Sub DbDelete()
        Try
            If DynOption = ORADYN_READONLY Then
                Throw New Exception("Not Allow to delete data")

            End If
            m_AddEditMode = DYNASET_DELETE
            'Delete
            Dim currentRow = m_DataTable.Rows(m_RowPosition)
            If currentRow Is Nothing Then
                Throw New System.Exception("No data is available to be deleted.")
            End If
            If currentRow IsNot Nothing Then
                If m_DataTable.PrimaryKey.Count = 0 Then

                    Dim hasRowId As Boolean = False
                    For i As Integer = 0 To m_DataTable.Columns.Count - 1
                        If m_DataTable.Columns(i).ColumnName.ToUpper() = "ROWID" Then
                            hasRowId = True
                        End If
                    Next i

                    If hasRowId Then
                        'Delete with RowID
                        Dim tmpRows() As DataRow = {currentRow}

                        Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter)

                        ' m_DataTable.Columns.Add(New DataColumn("ROWID", System.Type.GetType("System.String")))
                        m_DataTable.Columns("ROWID").Unique = True
                        tmpRows(0).Delete()
                        m_Adapter.Update(tmpRows)
                        'currentRow.AcceptChanges()
                        If m_RowPosition >= 0 Then
                            m_RowPosition = m_RowPosition - 1
                        End If

                        m_AddEditMode = DYNASET_UNCHANGED
                    Else
                        Throw New System.Exception("No key is available to be deleted.")
                    End If

                Else
                    Dim tmpRows() As DataRow = {currentRow}
                    Dim cmdBuilder As OracleCommandBuilder = New OracleCommandBuilder(m_Adapter) 'Note: There will be error Without OracleCommandBuilder 
                    tmpRows(0).Delete()
                    m_Adapter.Update(tmpRows)
                    'currentRow.AcceptChanges()
                    If m_RowPosition >= 0 Then
                        m_RowPosition = m_RowPosition - 1
                    End If

                End If

            End If
            m_AddEditMode = DYNASET_UNCHANGED

        Catch ex As OracleException
            m_OraDatabase.Session.KeepLastException(ex)
            Throw
        End Try

    End Sub


    Public Sub Delete()

        DbDelete()
    End Sub

    Public ReadOnly Property BOF As Boolean
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/serprop005.htm#OOFOL667
        Get
            If m_DataTable.Rows.Count = 0 Then
                Return True
            End If
            Return m_RowPosition < 0
        End Get
    End Property

    Public Sub MoveLast()
        If m_AddEditMode = DYNASET_UNCHANGED Then
            m_RowPosition = m_DataTable.Rows.Count - 1
        Else
            Throw New Exception("Unable to Move Last. DataSet is being editted")
        End If

    End Sub
    Public Sub DbMoveLast()
        MoveLast()

    End Sub

    Public Sub DbMoveTo(ByVal idx As Integer)
        MoveTo(idx)
    End Sub

    Public Sub MarkDelete()
        If m_RowPosition >= 0 Then
            Dim currentRow = m_DataTable.Rows(m_RowPosition)
            If currentRow.RowState <> DataRowState.Deleted Then
                currentRow.Delete()
            End If

        End If


    End Sub

    Public Function IsMarkDeleted() As Boolean
        If m_RowPosition >= 0 Then
            Dim currentRow = m_DataTable.Rows(m_RowPosition)
            If currentRow.RowState = DataRowState.Deleted Then
                Return True
            End If
            Return False
        End If
        Return False
    End Function

    Public ReadOnly Property RowPosition As Integer
        'https://docs.oracle.com/cd/E11882_01/win.112/e17727/serprop109.htm#OOFOL773
        Get
            Return m_RowPosition
        End Get
    End Property
End Class
