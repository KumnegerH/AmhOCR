

'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Imports NetTesseract
Imports GhostscriptSharp.Settings

Public Class PageSetting

    Public Property Language As String

    Public Property Resolution As Size

    Public Property PageSize As Size

    Public Property OcrMode As OcrModel

    Public Property imgFormat As GhostscriptDevices

    Public Property isCustomePage As Boolean

    Public Property NativePage As GhostscriptPageSizes

    Public Property PageSegMode As PageSegMode


    Public Property SourceImagaChenged As Boolean = False

    Public Property Binaries As Boolean = False

    Public Property Gray As Boolean = False

    Public Property Threshold As Boolean = False

    Public Property Bright As Boolean = False

    Public Property Contrast As Boolean = False

    Public Property Gamma As Boolean = False


    Public Property ThresholdValue As Integer = 150

    Public Property BrightValue As Integer = 0

    Public Property ContrastValue As Integer = 0

    Public Property GammaValue As Single = 1

    Public Sub New()

        SourceImagaChenged = False

        PageSegMode = UserSettings.PageSegMode
        NativePage = UserSettings.NativePage
        PageSize = UserSettings.PageSize
        isCustomePage = UserSettings.isCustomePage
        imgFormat = UserSettings.imgFormat
        OcrMode = UserSettings.OcrMode
        Language = UserSettings.Language
        Resolution = UserSettings.Resolution

        Gray = UserSettings.Gray
        Binaries = UserSettings.Binaries

        Threshold = UserSettings.Threshold
        ThresholdValue = UserSettings.ThresholdValue

        Gamma = UserSettings.Gamma
        GammaValue = UserSettings.GammaValue

        Bright = UserSettings.Bright
        BrightValue = UserSettings.BrightValue

        Contrast = UserSettings.Contrast
        ContrastValue = UserSettings.ContrastValue

    End Sub


    Public Sub ResetSetting()

        Language = UserSettings.Language
        Binaries = UserSettings.Binaries



    End Sub


End Class
