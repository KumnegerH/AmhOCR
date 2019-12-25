
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3


Public Class HocrLine
    Public Property bbox As Rectangle

    Public Property LineNum As Integer = 0

    Public Property ParNum As Integer = 0

    Public Property AreaNum As Integer = 0

    Public Property Lang As String = ""

    Public Property BaseLine As PointF

    Public Property x_size As Single

    Public Property x_descenders As Single

    Public Property x_ascenders As Single

    Public Property Text As String = ""

    Public Property orignalText As String = ""

    Public Property AllocrWords As List(Of HocrWord)

    Public Property txtbox As Rectangle

    Public Sub New()

        bbox = New Rectangle
        BaseLine = New PointF
        AllocrWords = New List(Of HocrWord)

    End Sub

End Class
