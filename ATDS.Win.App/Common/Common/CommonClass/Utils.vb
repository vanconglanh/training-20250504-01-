Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Globalization
Imports Microsoft.VisualBasic.Compatibility
Imports System.IO

Public Module Utils

#Region "String Function"
    Public Function LenB(ByVal expression As Object, Optional encodingType As Integer = &H80) As Integer
        If expression Is Nothing Then
            Err.Raise(ERR_INVALID_ARGUMENT)
            Return Nothing
        End If
        If Not (TypeOf expression Is String) Then
            Return expression.GetLength(0)
        End If
        Dim expression2 As String = CStr(expression)
        Dim bytes() As Byte
        If (encodingType = vbUnicode) Then
            bytes = Encoding.Unicode.GetBytes(expression2)
        Else
            bytes = Encoding.Default.GetBytes(expression2)
            bytes = TruncateEndNulIByte(bytes)
        End If
        Return bytes.Length

    End Function


    Public Function GetStringByLengthByte(ByVal strInput As String, iLen As Int32) As String
        Dim i As Integer = 0
        Dim itextByteCnt As Integer = 0
        Dim strResult As String = ""
        Do While (i < strInput.Length)
            '対象となる文字列を先頭から1文字切り出し、その文字のバイト数を調べます。
            Dim tmpText As String = strInput.Substring(i, 1)
            Dim tmpTextByte() As Byte = Encoding.Unicode.GetBytes(tmpText)
            '切り出した文字を変数retに追加した際のバイト数が指定バイト数より大きければ、変数retを返します。
            If (itextByteCnt + tmpTextByte.Length > iLen) Then
                Return strResult
            Else
                strResult = strResult + tmpText
                itextByteCnt = (itextByteCnt + tmpTextByte.Length)
            End If

            i = i + 1
        Loop

        Return strResult
    End Function

    Private Function TruncateEndNulIByte(ByVal bytes As Byte()) As Byte()
        If bytes.Length > 1 AndAlso bytes(bytes.Length - 1) = 255 AndAlso bytes(bytes.Length - 2) = 253 Then
            ReDim Preserve bytes(bytes.Length - 2)
            bytes(bytes.Length - 1) = 0
        End If
        If bytes.Length > 1 AndAlso bytes(bytes.Length - 1) = 0 Then
            ReDim Preserve bytes(bytes.Length - 2)
        End If
        Return bytes
    End Function

    Public Function StrConv(ByVal strExpression As String, ByVal conversion As Integer) As String
        Try

            Select Case conversion
                Case vbUnicode
                    Return Encoding.Default.GetString(Encoding.Unicode.GetBytes(strExpression)).TrimEnd(Chr(0))
                Case vbFromUniCode
                    Dim bytes() As Byte = Encoding.Default.GetBytes(strExpression)
                    ReDim Preserve bytes(bytes.Length - 1 + bytes.Length Mod 2)
                    Return Encoding.Default.GetString(bytes)
                '++修正開始　2020年07月09:Unitec（手）- VB→VB.NET変換
                Case vbUpperCase
                    Return strExpression.Trim.ToUpper
                Case vbLowerCase
                    Return strExpression.Trim.ToLower
                Case vbProperCase
                    Return strExpression.Trim.ToUpperInvariant
                '--修正終了　2020年07月09:Unitec（手）- VB→VB.NET変換
                Case VbStrConv.Wide
                    If String.IsNullOrWhiteSpace(strExpression) Then
                        Return strExpression
                    Else

                        '++修正開始　2022年05月14日:MK（手）- VB→VB.NET変換
                        'Return Strings.StrConv(strExpression, CType(conversion, VbStrConv)) '←Error：
                        Return Strings.StrConv(strExpression, Microsoft.VisualBasic.VbStrConv.Wide)
                        '--修正開始　2022年05月14日:MK（手）- VB→VB.NET変換

                    End If
                Case Else
                    '++修正開始　2020年06月24:Unitec（手）- VB→VB.NET変換
                    'Return Microsoft.VisualBasic.Strings.StrConv(strExpression, CType(conversion, VbStrConv))
                    Return Strings.StrConv(strExpression, CType(conversion, VbStrConv)) '←Error：
                    '--修正開始　2020年06月24:Unitec（手）- VB→VB.NET変換
            End Select

        Catch ex As Exception
            Return strExpression
        End Try
    End Function

    Public Function MidB(ByVal strExpression As String, ByVal start As Integer) As String
        If strExpression Is Nothing OrElse start <= 0 Then
            Err.Raise(ERR_INVALID_ARGUMENT)
            Return Nothing
        End If
        Dim bytes() As Byte = Encoding.Default.GetBytes(strExpression)
        bytes = TruncateEndNulIByte(bytes)
        If start > bytes.Length Then
            Return String.Empty
        End If

        Dim length As Integer = bytes.Length - start + 1
        Array.Reverse(bytes)

        ReDim Preserve bytes(length - 1)
        Array.Reverse(bytes)

        Return Encoding.Default.GetString(bytes)

    End Function

    Public Function MidB(ByVal strExpression As String, ByVal start As Integer, ByVal length As Integer) As String
        If strExpression Is Nothing OrElse start <= 0 OrElse length < 0 Then
            Err.Raise(ERR_INVALID_ARGUMENT)
            Return Nothing
        End If
        Dim bytes() As Byte = Encoding.Default.GetBytes(strExpression)

        length = Math.Min(bytes.Length, length)
        Dim results(length - 1 + length Mod 2) As Byte
        For i As Integer = 0 To length - 1
            results(i) = bytes(i + start - 1)
        Next

        Return Encoding.Default.GetString(bytes)

    End Function

    Public Function MidB(ByVal array As Byte(), ByVal start As Integer, ByVal length As Integer) As String
        Dim strExpress = System.Text.Encoding.Unicode.GetString(array)
        MidB(strExpress, start, length)
    End Function

    Public Function LeftB(ByVal strExpression As String, ByVal length As Integer) As String
        If strExpression Is Nothing OrElse length < 0 Then
            Err.Raise(ERR_INVALID_ARGUMENT)
            Return Nothing
        End If
        If length > 0 AndAlso length >= LenB(strExpression) Then
            Return strExpression
        End If

        Dim bytes() As Byte = Encoding.Default.GetBytes(strExpression)
        ReDim Preserve bytes(length - 1 + length Mod 2)

        Return Encoding.Default.GetString(bytes)

    End Function
    Public Function RightB(ByVal strExpression As String, ByVal length As Integer) As String
        If strExpression Is Nothing OrElse length < 0 Then
            Err.Raise(ERR_INVALID_ARGUMENT)
            Return Nothing
        End If
        If length > 0 AndAlso length >= LenB(strExpression) Then
            Return strExpression
        End If

        Dim bytes() As Byte = Encoding.Default.GetBytes(strExpression)
        Array.Reverse(bytes)
        ReDim Preserve bytes(length - 1 + length Mod 2)
        Array.Reverse(bytes)
        Return Encoding.Default.GetString(bytes)

    End Function

    Public Function ChrB(input As Integer) As Byte
        Convert.ToByte(input)
    End Function

    Public Function FormatNothingToBlank(value As Object, format As String) As String
        If value Is Nothing OrElse value = Nothing Then
            Return ""
        Else
            VB6.Format(value, format)
        End If
    End Function

    '********************************************************************************************
    ' 関 数 名  : comLIST_GetSetectComboCode
    ' スコープ  : Public
    ' 処理内容  : コンボボックス選択位置のコードを取得する。
    ' 備    考  :
    ' 返 り 値  : String    選択位置のコード
    ' 引 き 数  :
    '     ﾊﾟﾗﾒｰﾀ名             ﾃﾞｰﾀﾀｲﾌﾟ        I/O     説 明
    '   -------------------+-----------------+-----+---------------------------------------------
    '   parm_cboCombo       ComboBox            I   コンボボックス
    '
    ' 変更履歴  :
    '     日  付      氏  名            修正内容
    '   -----------+------------------+----------------------------------------------------------
    '   2007/03/07  TSR : 奥村  進一    新規作成
    '
    '********************************************************************************************
    Public Function comLIST_GetSetectComboCode(ByVal parm_cboCombo As System.Windows.Forms.ComboBox) As String
        Dim strCode As String
        Dim intPos As Short

        '-----------------------------------
        '   初期値設定
        '-----------------------------------
        comLIST_GetSetectComboCode = ""

        '-----------------------------------
        '   コード取得
        '-----------------------------------
        strCode = parm_cboCombo.Text
        intPos = InStr(strCode, ":")
        If (intPos <= 0) Then
            Exit Function
        End If

        '-----------------------------------
        '   戻り値設定
        '-----------------------------------
        comLIST_GetSetectComboCode = Trim(Mid(strCode, 1, intPos - 1))

    End Function
#End Region

#Region "Application"
    Function PrevInstance() As Boolean
        If UBound(Diagnostics.Process.GetProcessesByName _
           (Diagnostics.Process.GetCurrentProcess.ProcessName)) _
           > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Screen"
    ''' <summary>
    ''' 利用している画面のWidth情報を取得
    ''' </summary>
    ''' <returns></returns>
    Function GetScreenWidth() As Double
        Dim screen As Rectangle
        screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds

        Return Convert.ToDouble(screen.Width)
    End Function

    ''' <summary>
    '''  利用している画面のHeight情報を取得
    ''' </summary>
    ''' <returns></returns>
    Function GetScreenHeight() As Double
        Dim screen As Rectangle
        screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds

        Return Convert.ToDouble(screen.Height)
    End Function

    ''' <summary>
    '''  利用している画面のHeight情報を取得
    ''' </summary>
    ''' <returns></returns>
    Public Sub SetStatusBarDesign(ByRef parentForm As System.Windows.Forms.Form, ByRef statusBar As System.Windows.Forms.StatusStrip)
        With statusBar.Items
            For i As Integer = 0 To statusBar.Items.Count - 1 Step 1
                CType(.Item(i), ToolStripStatusLabel).AutoSize = False
                CType(.Item(i), ToolStripStatusLabel).BorderSides = ToolStripStatusLabelBorderSides.All
                CType(.Item(i), ToolStripStatusLabel).BorderStyle = Border3DStyle.SunkenOuter
                CType(.Item(i), ToolStripStatusLabel).TextAlign = ContentAlignment.MiddleLeft
                CType(.Item(i), ToolStripStatusLabel).Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
            Next
            statusBar.AutoSize = False
            'StatusBar.BackColor = Color.Red - testing
            statusBar.Width = parentForm.Width

        End With
        If statusBar.Items.Count = 2 Then
            statusBar.Items.Item(0).Width = parentForm.Width - 140 - 30 ' 30 for resize control
            statusBar.Items.Item(1).Width = 140
            CType(statusBar.Items.Item(1), ToolStripStatusLabel).TextAlign = ContentAlignment.MiddleCenter
        ElseIf statusBar.Items.Count = 3 Then
            statusBar.Items.Item(0).Width = parentForm.Width - 280 - 30 ' 30 for resize control
            statusBar.Items.Item(1).Width = 140
            statusBar.Items.Item(2).Width = 140
            CType(statusBar.Items.Item(1), ToolStripStatusLabel).TextAlign = ContentAlignment.MiddleCenter
            CType(statusBar.Items.Item(2), ToolStripStatusLabel).TextAlign = ContentAlignment.MiddleCenter
        End If
    End Sub

    ''' <summary>
    '''  フォントを古いシステムに更新します
    ''' </summary>
    ''' <returns></returns>
    'Public Sub UpdateFont(ByRef form As System.Windows.Forms.Form)
    Public Sub UpdateFont(ByRef container As Control)
        For i As Integer = 0 To container.Controls.Count - 1
            Dim control As Control = container.Controls(i)
            If control.GetType().ToString().Contains("Label") Or control.GetType().ToString().Contains("ComboBox") Or control.GetType().ToString().Contains("Button") Or control.GetType().ToString().Contains("TextBox") Or control.GetType().ToString().Contains("RadioButton") Then
                Dim oldFontStyle = control.Font.Style
                Dim oldFontSize = control.Font.Size
                If oldFontSize = 9.75 Then
                    oldFontSize = 9 'only update 9.75 to 9
                    Dim oldUnit As GraphicsUnit = control.Font.Unit
                    control.Font = New Font("ＭＳ ゴシック", oldFontSize, oldFontStyle, oldUnit)
                End If
            Else
                'Container 
                If control.GetType().ToString().Contains("Panel") Or control.GetType().ToString().Contains("GroupBox") Or control.GetType().ToString().Contains("Tab") Or control.GetType().ToString().Contains("SplitContainer") Then
                    UpdateFont(control)
                End If
            End If

        Next
    End Sub

#End Region

#Region "Control"
    ''' <summary>
    ''' コントロールによって、プロパティ情報を設定する
    ''' </summary>
    ''' <param name="control">コントロール</param>
    ''' <param name="value">設定値</param>
    Public Sub SetValueControl(ByRef control As Control, value As String)
        Select Case control.GetType()
            Case GetType(TextBox)
                CType(control, TextBox).Text = value
            Case GetType(MKTextBox)
                CType(control, MKTextBox).Text = value
            Case GetType(ComboBox)
                CType(control, ComboBox).Text = value
        End Select
    End Sub
    ''' <summary>
    ''' コントロールによって、プロパティ情報を取得
    ''' </summary>
    ''' <param name="control">コントロール</param>　
    ''' <returns></returns>
    Public Function getValueControl(ByVal control As Control) As String
        Select Case control.GetType()
            Case GetType(TextBox)
                Return CType(control, TextBox).Text
            Case GetType(MKTextBox)
                Return CType(control, MKTextBox).Text
            Case GetType(ComboBox)
                Return CType(control, ComboBox).Text
            Case GetType(MKCombobox)
                Return CType(control, MKCombobox).Text
        End Select

        Return ""
    End Function

    ''' <summary>
    ''' コントロールによって、選択開始を設定
    ''' </summary>
    ''' <param name="control">コントロール</param>　
    Public Sub setSelectStartControl(ByRef control As Control, startIndex As Integer)
        Select Case control.GetType()
            Case GetType(TextBox)
                CType(control, TextBox).SelectionStart = startIndex
            Case GetType(MKTextBox)
                CType(control, MKTextBox).SelectionStart = startIndex
        End Select
    End Sub

    ''' <summary>
    ''' コントロールによって、選択開始を設定
    ''' </summary>
    ''' <param name="control">コントロール</param>
    Public Sub setSelectLengthControl(ByRef control As Control, selectLength As Integer)
        Select Case control.GetType()
            Case GetType(TextBox)
                CType(control, TextBox).SelectionLength = selectLength
            Case GetType(MKTextBox)
                CType(control, MKTextBox).SelectionLength = selectLength
        End Select

    End Sub

    ''' <summary>
    ''' Recursively find all child controls for a form
    ''' </summary>
    ''' <param name="StartingContainer"><c><seealso cref="System.Windows.Forms.Form">Form
    ''' </seealso></c> that is the starting container to check for children.</param>
    ''' <returns><c><seealso cref="List(Of System.Windows.Forms.Control)">List(Of Control)
    ''' </seealso></c> that contains a reference to all child controls.</returns>
    ''' <remarks>If you put this module in a separate namespace from your form, Visual Studio 
    ''' 2010 does not recognize the extension to the form.</remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function FindAllChildren(ByRef StartingContainer As System.Windows.Forms.Form) As List(Of System.Windows.Forms.Control)
        Dim Children As New List(Of System.Windows.Forms.Control)

        Dim oControl As System.Windows.Forms.Control
        For Each oControl In StartingContainer.Controls
            Children.Add(oControl)
            If oControl.HasChildren Then
                Children.AddRange(oControl.FindAllChildren())
            End If
        Next

        Return Children
    End Function
    ''' <summary>
    ''' Recursively find all child controls for a control
    ''' </summary>
    ''' <param name="StartingContainer"><c><seealso cref="System.Windows.Forms.Control">Control
    ''' </seealso></c> that is the starting container to check for children.</param>
    ''' <returns><c><seealso cref="List(Of System.Windows.Forms.Control)">List(Of Control)
    ''' </seealso></c> that contains a reference to all child controls.</returns>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Function FindAllChildren(ByRef StartingContainer As System.Windows.Forms.Control) As List(Of System.Windows.Forms.Control)
        Dim Children As New List(Of System.Windows.Forms.Control)

        If StartingContainer.HasChildren = False Then
            Return Nothing
        Else
            Dim oControl As System.Windows.Forms.Control
            For Each oControl In StartingContainer.Controls
                Children.Add(oControl)
                If oControl.HasChildren Then
                    Children.AddRange(oControl.FindAllChildren())
                End If
            Next
        End If

        Return Children
    End Function
#End Region

#Region "Database"
    Public Function GetReportConnectionString() As String
        'TODO
        '++修正開始　2021年06月28日:MK（手）- VB→VB.NET変換
        'Return "Provider=OraOLEDB.Oracle;Password=mk;Persist Security Info=True;User ID=mk;Data Source=172.16.16.15:1521/mk"
        'Return "Provider=OraOLEDB.Oracle;Password=mk;Persist Security Info=True;User ID=mk;Data Source=172.16.16.15:1521/mk"
        Return System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\reportconnection.txt")
        '--修正開始　2021年06月28日:MK（手）- VB→VB.NET変換
    End Function
#End Region

#Region "Array"

    ''' <summary>
    ''' Get index of control in array by name of control
    ''' </summary>
    ''' <param name="control"></param>
    ''' <returns></returns>
    Public Function GetIndexOfControl(ByRef control As System.Windows.Forms.Control) As Integer
        Return GetIndexOfControlInArray(control)
    End Function

    ''' <summary>
    '''  Get index of control in array by name of control
    ''' </summary>
    ''' <param name="control"></param>
    ''' <returns></returns>
    Public Function GetIndexOfControlInArray(ByVal control As System.Windows.Forms.Control) As Integer
        If control.Name.Contains("_") Then
            Return control.Name.Substring(control.Name.IndexOf("_", 1) + 1, control.Name.Length - control.Name.IndexOf("_", 1) - 1)
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' input control and return name of control array
    ''' </summary>
    ''' <param name="control"></param>
    ''' <returns></returns>
    Public Function GetNameOfArray(ByVal control As System.Windows.Forms.Control) As String
        Return If(control.Name.Contains("_"), control.Name.Substring(control.Name.IndexOf("_") + 1, control.Name.IndexOf("_", 1) - 1), control.Name)
    End Function
#End Region

#Region "DateTime"
    ''' <summary>
    ''' GetJapanDateByFormat(Microsoft.VisualBasic.Right(pstrTxtDate, 12), "(ggyy)/MM/dd").ToString("yyyy/MM/dd")
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <param name="strFormat"></param>
    ''' <param name="strFormat2"></param>
    ''' <returns></returns>
    Public Function GetJapanDateByFormat(strValue As String, strFormat As String, Optional strFormat2 As String = "") As DateTime
        Dim culture As CultureInfo = New CultureInfo("ja-JP", True)
        culture.DateTimeFormat.Calendar = New JapaneseCalendar()

        Dim result As DateTime

        Try
            result = DateTime.ParseExact(strValue, strFormat, culture)
        Catch ex As Exception
            result = DateTime.ParseExact(strValue, strFormat2, culture)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' GetDateByFormat(Microsoft.VisualBasic.Right(pstrTxtDate, 12), "(ggyy)/MM/dd").ToString("yyyy/MM/dd")
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <param name="strFormat"></param>
    ''' <returns></returns>
    Public Function GetDateByFormat(strValue As String, strFormat As String) As DateTime

        Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

        Dim result As DateTime = DateTime.ParseExact(strValue, strFormat, provider)

        Return result

    End Function

#End Region

#Region "Image"
    Public Function ImageFromFile(strImagePath As String, Optional ByVal bResize As Boolean = False, Optional ByVal intPercent As Int16 = 50) As Bitmap

        'Dim stream As New FileStream(strImagePath, FileMode.Open, FileAccess.Read)
        'Dim returnImage As Image = DirectCast(Image.FromStream(stream), Image)
        'stream.Close()

        'Return returnImage

        Dim bm As Bitmap
        Using img As Image = Image.FromFile(strImagePath)
            If bResize = False Then
                bm = New Bitmap(img)
            Else
                bm = Resize(img, intPercent, 0)
            End If
        End Using
        Return bm

    End Function

    Public Function Resize(ByVal imgSource As System.Drawing.Image, ByVal intPercent As Integer, Optional ByVal intType As Integer = 0) As Bitmap
        'resize the image by percent
        Dim intX, intY As Integer
        intX = Int(imgSource.Width / 100 * intPercent)
        intY = Int(imgSource.Height / 100 * intPercent)
        Dim bm As Drawing.Bitmap = New System.Drawing.Bitmap(intX, intY)
        Dim g As System.Drawing.Graphics = Drawing.Graphics.FromImage(bm)

        Select Case intType
            Case 0
                g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.Default
            Case 1
                g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.High
            Case 2
                g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
            Case 3
                g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        End Select

        g.DrawImage(imgSource, 0, 0, intX, intY)
        Return bm

    End Function
#End Region
End Module
