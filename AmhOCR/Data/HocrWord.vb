Public Class HocrWord

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

    Public Property bbox As Rectangle

    Public Property WordNum As Integer = 0

    Public XmlElement As XElement

    Public Property lineNum As Integer = 0

    Public Property ParNum As Integer = 0

    Public Property areaNum As Integer = 0


    Public Property Lang As String = ""

    Public Property Text As String

    Public Property x_wconf As Single

    Public Property x_fsize As Single
    Public Property txtbox As Rectangle



    Public Property orignalText As String = ""
    Public Sub New()
        txtbox = New Rectangle
        bbox = New Rectangle

    End Sub

End Class
