Imports MKOra.Core

Public Class ReportUtils


    'Public Shared Function GetReportData(ByVal gobjOraDatabase As MKOra.Core.OraDatabase, strSQL As String) As DataTable
    '    'Get data
    '    Dim dt As DataTable = gobjOraDatabase.CreateDynaset(strSQL, &H4).DataTable
    '    Dim dtCloned As DataTable = dt.Clone

    '    'Convert OracleType -> String
    '    For icol As Integer = 0 To dt.Columns.Count - 1
    '        dtCloned.Columns(icol).DataType = GetType(String)
    '    Next

    '    'Copy to to new datatable
    '    For Each row As DataRow In dt.Rows
    '        dtCloned.ImportRow(row)
    '    Next


    '    'Change null value to Nothing
    '    For rowIndex As Integer = dtCloned.Rows.Count - 1 To 0 Step -1
    '        For colIndex As Integer = dtCloned.Columns.Count - 1 To 0 Step -1
    '            'first row -> reset readonly properties = false
    '            If rowIndex = dtCloned.Rows.Count - 1 Then dtCloned.Columns(colIndex).ReadOnly = False

    '            'Set 'null' to nothing
    '            If String.IsNullOrEmpty(dtCloned(rowIndex)(colIndex)) OrElse "null".Equals(dtCloned(rowIndex)(colIndex)) Then
    '                Try
    '                    'If dt.Columns(colIndex).DataType.Name = "OracleDecimal" Then
    '                    '    dtCloned(rowIndex)(colIndex) = System.DBNull.Value
    '                    'Else
    '                    '    dtCloned(rowIndex)(colIndex) = Nothing
    '                    'End If
    '                    dtCloned(rowIndex)(colIndex) = System.DBNull.Value
    '                Catch ex As Exception
    '                    Throw ex
    '                End Try
    '            End If
    '        Next
    '    Next

    '    'Change String -> Number or Date type
    '    Dim dtResult As DataTable = dtCloned.Clone
    '    For icol As Integer = 0 To dt.Columns.Count - 1
    '        If dt.Columns(icol).DataType.Name = "OracleDecimal" Then
    '            dtResult.Columns(icol).DataType = GetType(Decimal)
    '        ElseIf dt.Columns(icol).DataType.Name = "OracleDate" Then
    '            dtResult.Columns(icol).DataType = GetType(Date)
    '        End If
    '    Next

    '    'show result
    '    For rowIndex As Integer = 0 To dtCloned.Rows.Count - 1
    '        Dim dr As DataRow = dtResult.NewRow
    '        For colIndex As Integer = 0 To dtCloned.Columns.Count - 1
    '            If dtCloned(rowIndex)(colIndex) Is System.DBNull.Value Then
    '                dr(colIndex) = System.DBNull.Value
    '            Else
    '                If dt.Columns(colIndex).DataType.Name = "OracleDecimal" Then

    '                    dr(colIndex) = Decimal.Parse(dtCloned(rowIndex)(colIndex))
    '                Else
    '                    dr(colIndex) = dtCloned(rowIndex)(colIndex)
    '                End If
    '            End If

    '        Next
    '        dtResult.Rows.Add(dr)
    '    Next

    '    'For Each row As DataRow In dtCloned.Rows
    '    '    dtResult.ImportRow(row)
    '    'Next

    '    Return dtResult
    'End Function


    Public Shared Function GetReportData(ByVal gobjOraDatabase As MKOra.Core.OraDatabase, strSQL As String) As DataTable
        'Get data
        Dim dt As DataTable = gobjOraDatabase.CreateDynaset(strSQL, &H4).DataTable
        Dim dtCloned As DataTable = dt.Clone

        'Convert OracleType -> String
        For icol As Integer = 0 To dt.Columns.Count - 1
            If dt.Columns(icol).DataType.Name = "OracleDecimal" Then
                dtCloned.Columns(icol).DataType = GetType(Decimal)
            ElseIf dt.Columns(icol).DataType.Name = "OracleDate" Then
                dtCloned.Columns(icol).DataType = GetType(Date)
            Else
                dtCloned.Columns(icol).DataType = GetType(String)
            End If
            dtCloned.Columns(icol).ReadOnly = False
        Next

        'show result
        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            Dim dr As DataRow = dtCloned.NewRow
            For colIndex As Integer = 0 To dt.Columns.Count - 1
                If dt(rowIndex)(colIndex).IsNull = True Then
                    dr(colIndex) = System.DBNull.Value
                Else
                    If dt.Columns(colIndex).DataType.Name = "OracleDecimal" Then
                        dr(colIndex) = DBUtils.GetDecimalValue(dt(rowIndex)(colIndex))
                    ElseIf dt.Columns(colIndex).DataType.Name = "OracleDate" Then
                        dr(colIndex) = DateTime.Parse(dt(rowIndex)(colIndex).Value)
                    Else
                        dr(colIndex) = dt(rowIndex)(colIndex).Value
                    End If
                End If

            Next
            dtCloned.Rows.Add(dr)
        Next

        Return dtCloned
    End Function
End Class
