

'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

Public Class HocrPage

    Public Property Recognized As Boolean = False

    Private _ocrsettings As PageSetting

    Public Property PageOCRsettings As PageSetting

        Set(value As PageSetting)
            _ocrsettings = value
        End Set
        Get
            Return _ocrsettings

        End Get

    End Property

    Public Sub SetSettings()

        UserSettings.SourceImagaChenged = _ocrsettings.SourceImagaChenged

        UserSettings.Language = _ocrsettings.Language
        UserSettings.PageSize = _ocrsettings.PageSize
        UserSettings.Resolution = _ocrsettings.Resolution

        UserSettings.Gray = _ocrsettings.Gray

        UserSettings.Threshold = _ocrsettings.Threshold
        UserSettings.ThresholdValue = _ocrsettings.ThresholdValue

        UserSettings.Bright = _ocrsettings.Bright
        UserSettings.BrightValue = _ocrsettings.BrightValue

        UserSettings.Contrast = _ocrsettings.Contrast
        UserSettings.ContrastValue = _ocrsettings.ContrastValue


        UserSettings.Gamma = _ocrsettings.Gamma
        UserSettings.GammaValue = _ocrsettings.GammaValue

        UserSettings.Binaries = _ocrsettings.Binaries

    End Sub

    Public Property ImageBlocks As List(Of Rectangle)

    Public Property bbox As Rectangle

    Public Property ImageName As String = ""

    Public Property imgCopyName As String = ""

    Public Property isMultiColumns As Boolean = False

    Public Property PageNum As Integer = 0

    Public Property AllocrCarea As List(Of HocrCarea)

    Public Property UTF8Text As String = ""

    Public Property HocrXML As XElement

    Public Property orignalText As String = ""

    Public Property ocrpagemargin As ocrpagemargin



    Public Sub New()

        ImageName = ""

        imgCopyName = ""

        isMultiColumns = False

        PageNum = 0

        Recognized = False

        _ocrsettings = New PageSetting

        ocrpagemargin = New ocrpagemargin

        ImageBlocks = New List(Of Rectangle)

        bbox = New Rectangle

        AllocrCarea = New List(Of HocrCarea)

    End Sub

End Class
