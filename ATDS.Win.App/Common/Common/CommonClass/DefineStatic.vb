Option Strict Off
Option Explicit On
Imports System.Drawing

Public Class DefineStatic

    ''' <summary>
    ''' Prevent instantiation.
    ''' </summary>
    Private Sub New()

    End Sub

    Public Shared FPSPREAD_FONT As Font = New Font("ＭＳ ゴシック", 9)
    Public Shared FPSPREAD_FONT_SMALL As Font = New Font("ＭＳ ゴシック", 8)
    Public Shared FPSPREAD_FONT_PGOTHIC As Font = New Font("ＭＳ Pゴシック", 9)
    Public Shared FPSPREAD_HEADER_FONT As Font = New Font("ＭＳ ゴシック", 9)
    Public Shared STATUS_BAR_FONT As Font = New Font("ＭＳ ゴシック", 9)

    Public Shared NUMBER_DECIMAL_FONT As Font = New Font("ＭＳ ゴシック", 9, FontStyle.Underline)

    Public Shared HeaderBlueColor = ColorTranslator.FromHtml("#0082FF")
    Public Shared HeaderBlackColor = ColorTranslator.FromHtml("#7D7D7D")
    Public Shared HeaderDefaultColor = System.Drawing.ColorTranslator.FromOle(&H8000000F)
    Public Shared HeaderJIE640Color = ColorTranslator.FromHtml("#F7F3F7")

    Public Shared HeaderControlColor = SystemColors.Control
    Public Shared GridLineColor = ColorTranslator.FromHtml("#D3D3D3")
    Public Shared BlueSkyColor_SYE201 = ColorTranslator.FromHtml("#84FFFF")
    Public Shared BlueSkyColor = ColorTranslator.FromHtml("#00FFFF")
    Public Shared GridBackGroundBrownColor = ColorTranslator.FromHtml("#C6C6C6")
    Public Shared GridBackGroundBlackColor = ColorTranslator.FromHtml("#7D7D7D")
    Public Shared GridBackGroundJIE600BlackColor = ColorTranslator.FromHtml("#C6C3C6")

    Public Shared SKP090_DefaultBlueColor = ColorTranslator.FromHtml("#91DFDF")
    Public Shared SKE020_SelectedBlueColor = ColorTranslator.FromHtml("#3169c6")
    Public Shared HEQ012_SelectedBlackColor = ColorTranslator.FromHtml("#000000")

    'Status
    Public Shared CONST_COLOR_DISABLE = ColorTranslator.FromHtml("#C6C3C6")
End Class