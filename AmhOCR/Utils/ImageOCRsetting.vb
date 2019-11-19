
Imports System.IO
Imports AgImag = AForge.Imaging

'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class ImageOCRsetting


    Private Lock As Boolean = True

    Friend _MainImage As Image
    'Private _Image As Image
    Friend MyViewer As ImageEditControl

    Friend _MainHocrPage As HocrPage

    Private loaded As Boolean = False

    Public Sub InitializeImage(ByVal ImgEdit As Image, ByRef hocrage As HocrPage)

        _MainHocrPage = hocrage

        _MainHocrPage.SetSettings()

        _MainImage = ImgEdit
        ' _Image = _MainImage.Clone


        MyViewer.DisposeImage()
        MyViewer.ResetAllState()

        MyViewer.Image = _MainImage.Clone

    End Sub

    Private Sub ProcessImage_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        InitializeSetting()

    End Sub


    Private Sub InitializeSetting()
        Lock = True

        OCRsettings.Gray = _MainHocrPage.PageOCRsettings.Gray

        OCRsettings.Threshold = _MainHocrPage.PageOCRsettings.Threshold
        OCRsettings.ThresholdValue = _MainHocrPage.PageOCRsettings.ThresholdValue

        OCRsettings.Bright = _MainHocrPage.PageOCRsettings.Bright
        OCRsettings.BrightValue = _MainHocrPage.PageOCRsettings.BrightValue

        OCRsettings.Contrast = _MainHocrPage.PageOCRsettings.Contrast
        OCRsettings.ContrastValue = _MainHocrPage.PageOCRsettings.ContrastValue

        OCRsettings.Gamma = _MainHocrPage.PageOCRsettings.Gamma
        OCRsettings.GammaValue = _MainHocrPage.PageOCRsettings.GammaValue

        If OCRsettings.Gray = True Then
            chkGray.Checked = True
            grpBoxThreshold.Enabled = True
        Else
            chkGray.Checked = False
            grpBoxThreshold.Enabled = False

        End If



        If OCRsettings.Threshold = True Then
            TrackThresh.Enabled = True
            chkThreshold.Checked = True
        Else
            TrackThresh.Enabled = False
            chkThreshold.Checked = False

        End If


        TrackThresh.Value = OCRsettings.ThresholdValue
        lblThreshold.Text = OCRsettings.ThresholdValue

        If OCRsettings.Bright = True Then
            TrackBright.Enabled = True
            chkBright.Checked = True

        Else
            TrackBright.Enabled = False
            chkBright.Checked = False
        End If

        TrackBright.Value = OCRsettings.BrightValue
        lblBright.Text = OCRsettings.BrightValue


        If OCRsettings.Contrast = True Then
            TrackContrast.Enabled = True
            chkContrast.Checked = True
        Else
            TrackContrast.Enabled = False
            chkContrast.Checked = False

        End If

        TrackContrast.Value = OCRsettings.ContrastValue
        lblContrast.Text = OCRsettings.ContrastValue


        If OCRsettings.Gamma = True Then
            TrackGamma.Enabled = True
            chkGamma.Checked = True
        Else
            TrackGamma.Enabled = False
            chkGamma.Checked = False
        End If

        TrackGamma.Value = CInt(OCRsettings.GammaValue * 10).ToString
        lblGamma.Text = TrackGamma.Value.ToString

        Lock = False
        loaded = True
        ApplyCorrections()

    End Sub


    Private Sub chkThreshold_CheckedChanged(sender As Object, e As EventArgs) Handles chkThreshold.CheckedChanged

        If loaded = False Then
            Exit Sub
        End If

        If grpBoxThreshold.Enabled = True Then
            Lock = True
            If chkThreshold.Checked = True Then

                TrackThresh.Value = 150
                TrackThresh.Enabled = True

            Else
                TrackThresh.Enabled = False
                TrackThresh.Value = 150

            End If

            Lock = False


            If chkThreshold.Checked = True Then

                OCRsettings.Threshold = True

                OCRsettings.ThresholdValue = TrackThresh.Value
            Else

                OCRsettings.Threshold = False
                OCRsettings.ThresholdValue = 150

            End If

            ApplyCorrections()


        End If

    End Sub

    Private Sub chkBright_CheckedChanged(sender As Object, e As EventArgs) Handles chkBright.CheckedChanged

        If loaded = False Then
            Exit Sub
        End If

        Lock = True

        If chkBright.Checked = True Then
            TrackBright.Enabled = True
        Else
            TrackBright.Enabled = False
        End If

        TrackBright.Value = 0

        Lock = False

        If chkBright.Checked = True Then

            OCRsettings.Bright = True
            OCRsettings.BrightValue = TrackBright.Value

        Else

            OCRsettings.Bright = False
            OCRsettings.BrightValue = 0

        End If


        ApplyCorrections()


    End Sub

    Private Sub chkContrast_CheckedChanged(sender As Object, e As EventArgs) Handles chkContrast.CheckedChanged

        If loaded = False Then
            Exit Sub
        End If

        Lock = True
        If chkContrast.Checked = True Then
            TrackContrast.Enabled = True
        Else
            TrackContrast.Enabled = False
        End If

        TrackContrast.Value = 0
        Lock = False

        If chkContrast.Checked = True Then

            OCRsettings.Contrast = True
            OCRsettings.ContrastValue = TrackContrast.Value

        Else

            OCRsettings.Contrast = False
            OCRsettings.ContrastValue = 0

        End If


        ApplyCorrections()


    End Sub

    Private Sub chkGamma_CheckedChanged(sender As Object, e As EventArgs) Handles chkGamma.CheckedChanged

        If loaded = False Then
            Exit Sub
        End If

        Lock = True
        If chkGamma.Checked = True Then
            TrackGamma.Enabled = True
        Else
            TrackGamma.Enabled = False
        End If

        TrackGamma.Value = 10

        Lock = False

        If chkGamma.Checked = True Then

            OCRsettings.Gamma = True
            OCRsettings.GammaValue = TrackGamma.Value / 10

        Else

            OCRsettings.Gamma = False
            OCRsettings.GammaValue = 1

        End If


        ApplyCorrections()


    End Sub

    Private Sub chkGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkGray.CheckedChanged

        If loaded = False Then
            Exit Sub
        End If

        Lock = True
        If chkGray.Checked = True Then

            grpBoxThreshold.Enabled = True

        Else

            grpBoxThreshold.Enabled = False

            If chkThreshold.Checked = True Then
                chkThreshold.Checked = False
                TrackThresh.Enabled = False
                TrackThresh.Value = 150
            End If

        End If

        Lock = False

        ' _Image = _MainImage.Clone

        If chkGray.Checked = True Then

            OCRsettings.Gray = True

        Else
            OCRsettings.Threshold = False
            OCRsettings.ThresholdValue = 150
            OCRsettings.Gray = False

        End If

        ApplyCorrections()

    End Sub
    Private Sub TrackThresh_ValueChanged(sender As Object, e As EventArgs) Handles TrackThresh.ValueChanged

        If loaded = False Then
            Exit Sub
        End If


        lblThreshold.Text = TrackThresh.Value

        If TrackThresh.Enabled = True Then

            If chkThreshold.Checked = True Then

                OCRsettings.Threshold = True

                OCRsettings.ThresholdValue = TrackThresh.Value
            Else

                OCRsettings.Threshold = False
                OCRsettings.ThresholdValue = 150

            End If

            ApplyCorrections()
        End If
        lblThreshold.Refresh()



    End Sub

    Private Sub TrackBright_ValueChanged(sender As Object, e As EventArgs) Handles TrackBright.ValueChanged

        If loaded = False Then
            Exit Sub
        End If

        lblBright.Text = TrackBright.Value


        If TrackBright.Enabled = True Then

            If chkBright.Checked = True Then

                OCRsettings.Bright = True
                OCRsettings.BrightValue = TrackBright.Value

            Else

                OCRsettings.Bright = False
                OCRsettings.BrightValue = 0

            End If


            ApplyCorrections()
        End If

        lblBright.Refresh()

    End Sub

    Private Sub TrackGamma_ValueChanged(sender As Object, e As EventArgs) Handles TrackGamma.ValueChanged

        If loaded = False Then
            Exit Sub
        End If

        lblGamma.Text = (TrackGamma.Value / 10).ToString

        If TrackGamma.Enabled = True Then

            If chkGamma.Checked = True Then

                OCRsettings.Gamma = True
                OCRsettings.GammaValue = TrackGamma.Value / 10

            Else

                OCRsettings.Gamma = False
                OCRsettings.GammaValue = 1

            End If



            ApplyCorrections()
        End If

        lblGamma.Refresh()
    End Sub

    Private Sub TrackContrast_ValueChanged(sender As Object, e As EventArgs) Handles TrackContrast.ValueChanged

        If loaded = False Then
            Exit Sub
        End If

        lblContrast.Text = TrackContrast.Value

        If TrackContrast.Enabled = True Then

            If chkContrast.Checked = True Then

                OCRsettings.Contrast = True
                OCRsettings.ContrastValue = TrackContrast.Value

            Else

                OCRsettings.Contrast = False
                OCRsettings.ContrastValue = 0

            End If



            ApplyCorrections()
        End If

        lblContrast.Refresh()

    End Sub




    Private Async Sub ApplyCorrections()

        If loaded = False Then
            Exit Sub
        End If

        If Lock = False Then

            Lock = True
            Dim tsk =
                TaskEx.Run(Function() As Image


                               Dim Newimg As Image = _MainImage.Clone
                               Newimg = PreProcessor.ApplyCorrections(Newimg)

                               Return Newimg

                           End Function)



            Try

                MyViewer.UpdateImage(Await tsk)
                MyViewer.Invalidate()

            Catch ex As Exception

            End Try



            Lock = False
        End If

    End Sub



    Private Sub ProcessImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Lock = True

    End Sub

    Private Sub ProcessImage_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        Me.Focus()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        loaded = False
        Dim pageSeting = _MainHocrPage.PageOCRsettings

        pageSeting.Gray = OCRsettings.Gray
        pageSeting.Threshold = OCRsettings.Threshold
        pageSeting.Bright = OCRsettings.Bright
        pageSeting.Contrast = OCRsettings.Contrast
        pageSeting.Gamma = OCRsettings.Gamma

        pageSeting.ThresholdValue = OCRsettings.ThresholdValue
        pageSeting.BrightValue = OCRsettings.BrightValue
        pageSeting.ContrastValue = OCRsettings.ContrastValue
        pageSeting.GammaValue = OCRsettings.GammaValue

        _MainHocrPage.PageOCRsettings = pageSeting

        Me.Close()

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        loaded = False
        InitializeSetting()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Me.Close()
    End Sub
End Class