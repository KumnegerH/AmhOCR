Imports System.Text
Imports System.Drawing.Drawing2D
Public Class HocrPar

      'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3


    Public Property bbox As Rectangle


    Public Property ParNum As Integer = 0

    Public Property AreaNum As Integer = 0

    Public Property Lang As String = ""

    Public Property AllocrLines As List(Of HocrLine)

    Public Property StringFormat As StringFormat

    Public Property Font As Font

    Public Property FontSize As Single = 0.01

    Public Property Alignment As ParAlignment


    Public Property orignalText As String = ""

    Public Property Text As String = ""



    Public Sub New()

        Font = UserSettings.ocrFont.Clone
        bbox = New Rectangle
        AllocrLines = New List(Of HocrLine)
        StringFormat = New StringFormat
        StringFormat.Alignment = StringAlignment.Near
        StringFormat.LineAlignment = StringAlignment.Near
        StringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.NoClip

        Alignment = ParAlignment.Center
    End Sub





End Class
