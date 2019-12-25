

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

        OCRsettings.Threshold = _ocrsettings.Threshold
        OCRsettings.ThresholdValue = _ocrsettings.ThresholdValue

        OCRsettings.Bright = _ocrsettings.Bright
        OCRsettings.BrightValue = _ocrsettings.BrightValue

        OCRsettings.Contrast = _ocrsettings.Contrast
        OCRsettings.ContrastValue = _ocrsettings.ContrastValue


        OCRsettings.Gamma = _ocrsettings.Gamma
        OCRsettings.GammaValue = _ocrsettings.GammaValue

        OCRsettings.Binaries = _ocrsettings.Binaries

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
