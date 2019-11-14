

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

        OCRsettings.SourceImagaChenged = _ocrsettings.SourceImagaChenged

        OCRsettings.Language = _ocrsettings.Language
        OCRsettings.PageSize = _ocrsettings.PageSize
        OCRsettings.Resolution = _ocrsettings.Resolution

        OCRsettings.Gray = _ocrsettings.Gray

        OCRsettings.Threshold = OCRsettings.Threshold
        OCRsettings.ThresholdValue = OCRsettings.ThresholdValue

        OCRsettings.Bright = OCRsettings.Bright
        OCRsettings.BrightValue = OCRsettings.BrightValue

        OCRsettings.Contrast = OCRsettings.Contrast
        OCRsettings.ContrastValue = OCRsettings.ContrastValue


        OCRsettings.Gamma = OCRsettings.Gamma
        OCRsettings.GammaValue = OCRsettings.GammaValue


    End Sub

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
        _ocrsettings = New PageSetting
        ocrpagemargin = New ocrpagemargin
        bbox = New Rectangle
        AllocrCarea = New List(Of HocrCarea)

    End Sub

End Class
