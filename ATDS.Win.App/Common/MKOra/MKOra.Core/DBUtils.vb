Imports Oracle.DataAccess.Types

Public Module DBUtils

    'Public Function IsDBNull(field As MKOra.Core.OraField) As Boolean
    '    Try
    '        Dim value As Object = field.Value
    '        Return False
    '    Catch ex As Exception
    '        Return True
    '    End Try
    'End Function

    'Public Function IsDBNull(field As Object) As Boolean
    '    Try
    '        If String.IsNullOrEmpty(field.Value) Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Return True
    '    End Try
    'End Function

    'Public Function IsDBNull(field As Short) As Boolean
    '    Return False
    'End Function

    'Public Function IsDBNull(field As Double) As Boolean
    '    Return False
    'End Function

    'Public Function IsDBNull(field As Date) As Boolean
    '    Return False
    'End Function

    'Public Function IsDBNull(field As String) As Boolean
    '    Return False
    'End Function
    Public Function IsDBNull(field As Object) As Boolean
        Try
            If field Is Nothing Then
                Return True
            ElseIf TypeOf field Is DBNull Then
                Return True
            End If
            If field.GetType().IsValueType Then
                Return False
            ElseIf TypeOf field Is MKOra.Core.OraField Then
                Return IsDBNull(field.Value)
            Else
                Return field Is Nothing
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function


    '関数名：日付時刻変換
    '引数  ：なし
    '型    ：String
    '返却値：日付と時刻を文字列で返す（例："98-02-07 16:03:05"）
    Public Function DateTimeConv() As String
        'DateTimeConv = VB6.Format(Today, "YY-MM-DD") & " " & VB6.Format(TimeOfDay, "HH:MM:SS")
        DateTimeConv = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Function

    Public Function GetDecimalValue(value As Object) As Decimal
        Dim strValue As String = value.ToString
        Dim pointLocation As Int16 = strValue.IndexOf(".")
        Const NumNumberAfterPoint As Int16 = 5

        If pointLocation = -1 OrElse Len(strValue) - pointLocation <= NumNumberAfterPoint Then
            Return Decimal.Parse(strValue)
        Else
            Return Decimal.Parse(strValue.Substring(0, pointLocation + NumNumberAfterPoint + 1))
        End If
    End Function
End Module
