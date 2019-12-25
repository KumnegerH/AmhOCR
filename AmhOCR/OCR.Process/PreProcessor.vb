Imports Ag = AForge.Imaging
Imports System.Drawing

Imports System.IO


'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class PreProcessor



    Public Overloads Shared Async Function Deskew(ByVal imgName As String) As Task(Of String)


        Dim outputPath = Path.Combine(OCRsettings.AmhOcrTempFolder, Path.GetFileNameWithoutExtension(imgName))

        Dim tsk = TaskEx.Run(
            Sub()

                Try

                    outputPath += ".tiff"




                    Dim imgProc = Ag.Image.FromFile(imgName)

                    Dim afrogeSkew = New Ag.DocumentSkewChecker

                    Dim deskewangle As Double = 0

                    If imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                        deskewangle = afrogeSkew.GetSkewAngle(imgProc)

                    Else
                        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
                        deskewangle = afrogeSkew.GetSkewAngle(imgProc)

                    End If

                    imgProc.Dispose()
                    imgProc = Nothing

                    If Math.Abs(deskewangle) > OCRsettings.MinimumSkewAngle Then

                        If File.Exists(outputPath) Then
                            File.Delete(outputPath)
                        End If



                        Dim rotater As New Ag.Filters.RotateBilinear(-deskewangle)
                        rotater.KeepSize = True
                        rotater.FillColor = Color.WhiteSmoke
                        Dim imOUT = Ag.Image.FromFile(imgName)
                        imOUT = rotater.Apply(imOUT)
                        imOUT.Save(outputPath, Imaging.ImageFormat.Tiff)
                        imOUT.Dispose()
                        imOUT = Nothing





                    Else

                        outputPath = imgName


                    End If





                Catch ex As Exception
                    outputPath = imgName
                End Try

            End Sub)


        Await tsk

        Return outputPath

    End Function

    Public Overloads Shared Function Deskew(ByVal imgName As String, ByVal ForceCopy As Boolean) As String

        Dim outputPath = Path.Combine(OCRsettings.AmhOcrTempFolder, Path.GetFileNameWithoutExtension(imgName))
        Try

            outputPath += ".tiff"

            Dim imgProc = Ag.Image.FromFile(imgName)

            Dim afrogeSkew = New Ag.DocumentSkewChecker

            Dim deskewangle As Double = 0

            If imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                deskewangle = afrogeSkew.GetSkewAngle(imgProc)

            Else
                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.BT709.Apply(imgProc)

                deskewangle = afrogeSkew.GetSkewAngle(imgProc)

            End If

            imgProc.Dispose()
            imgProc = Nothing

            If Math.Abs(deskewangle) > OCRsettings.MinimumSkewAngle Then

                If File.Exists(outputPath) Then
                    File.Delete(outputPath)
                End If

                Dim rotater As New Ag.Filters.RotateBilinear(-deskewangle)
                rotater.KeepSize = True
                rotater.FillColor = Color.WhiteSmoke



                Dim imOUT = Ag.Image.FromFile(imgName)
                imOUT = rotater.Apply(imOUT)
                imOUT.Save(outputPath, Imaging.ImageFormat.Tiff)


                imOUT.Dispose()
                imOUT = Nothing


            Else


                If ForceCopy = True Then
                    outputPath = Path.Combine(OCRsettings.AmhOcrTempFolder, Path.GetFileName(imgName))
                    FileIO.FileSystem.CopyFile(imgName, outputPath, True)
                Else
                    outputPath = imgName
                End If

            End If





        Catch ex As Exception
            outputPath = imgName
        End Try


        Return outputPath
    End Function

    Public Shared Function DeskewInplace(ByVal imgProc As Bitmap, ByVal Rec As Rectangle) As Image


        Dim afrogeSkew = New Ag.DocumentSkewChecker

        Dim deskewangle As Double = 0

        If imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
            deskewangle = afrogeSkew.GetSkewAngle(imgProc)
        Else
            imgProc = Ag.Filters.Grayscale.CommonAlgorithms.BT709.Apply(imgProc)
            deskewangle = afrogeSkew.GetSkewAngle(imgProc)
        End If

        Dim rotater As New Ag.Filters.RotateBilinear(-deskewangle)
        rotater.KeepSize = True
        rotater.FillColor = Color.WhiteSmoke
        If Math.Abs(deskewangle) < 45 Then
            imgProc = rotater.Apply(imgProc)
        End If

        Return imgProc
    End Function

    Public Overloads Shared Sub ConvertToGray(ByVal imgName As String)

        Dim imgProc = Ag.Image.FromFile(imgName)
        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
        imgProc.Save(imgName)


        imgProc.Dispose()
        imgProc = Nothing
    End Sub

    Public Shared Sub ConvertToGrayInplace(ByRef imgProc As Image)
        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

            imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

        End If
    End Sub

    Public Overloads Shared Function ApplyCorrections(ByVal imgProc As Image) As Image


        If OCRsettings.Binaries = False Then

            Try
                If OCRsettings.Gray = True Then

                    If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

                    End If

                End If
            Catch ex As Exception

            End Try

            Try
                If (OCRsettings.Threshold = True) Then

                    Dim Threshold As New Ag.Filters.Threshold
                    Threshold.ThresholdValue = OCRsettings.ThresholdValue

                    Threshold.ApplyInPlace(imgProc)
                End If


            Catch ex As Exception

            End Try



            Try
                If OCRsettings.Bright = True Then

                    If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                        End If

                    Else
                        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                        End If
                    End If

                    Dim filtr As New Ag.Filters.BrightnessCorrection
                    filtr.AdjustValue = OCRsettings.BrightValue
                    filtr.ApplyInPlace(imgProc)


                End If
            Catch ex As Exception

            End Try


            Try

                If OCRsettings.Contrast = True Then

                    If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                        End If

                    Else
                        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                        End If
                    End If

                    Dim filtr As New Ag.Filters.ContrastCorrection
                    filtr.Factor = OCRsettings.ContrastValue
                    filtr.ApplyInPlace(imgProc)

                End If


            Catch ex As Exception

            End Try


            Try

                If OCRsettings.Gamma = True Then

                    If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                        End If

                    Else
                        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                        End If
                    End If

                    Dim filtr As New Ag.Filters.GammaCorrection
                    filtr.Gamma = OCRsettings.GammaValue
                    filtr.ApplyInPlace(imgProc)

                End If

            Catch ex As Exception

            End Try

        Else

            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

            End If

            Dim Threshold As New Ag.Filters.BradleyLocalThresholding
            imgProc = Threshold.Apply(imgProc)

        End If


        Return imgProc

    End Function

    Public Overloads Shared Function ApplyCorrections(ByVal imgProc As Image, ByVal pgSetting As PageSetting) As Image


        If pgSetting.Binaries = False Then

            Try
                If pgSetting.Gray = True Then

                    If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

                    End If

                End If
            Catch ex As Exception

            End Try

            Try
                If (pgSetting.Threshold = True) Then

                    Dim Threshold As New Ag.Filters.Threshold
                    Threshold.ThresholdValue = pgSetting.ThresholdValue

                    Threshold.ApplyInPlace(imgProc)
                End If


            Catch ex As Exception

            End Try



            Try
                If pgSetting.Bright = True Then

                    If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                        End If

                    Else
                        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                        End If
                    End If

                    Dim filtr As New Ag.Filters.BrightnessCorrection
                    filtr.AdjustValue = pgSetting.BrightValue
                    filtr.ApplyInPlace(imgProc)


                End If
            Catch ex As Exception

            End Try


            Try

                If pgSetting.Contrast = True Then

                    If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                        End If

                    Else
                        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                        End If
                    End If

                    Dim filtr As New Ag.Filters.ContrastCorrection
                    filtr.Factor = pgSetting.ContrastValue
                    filtr.ApplyInPlace(imgProc)

                End If


            Catch ex As Exception

            End Try


            Try

                If pgSetting.Gamma = True Then

                    If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                        End If

                    Else
                        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                        End If
                    End If

                    Dim filtr As New Ag.Filters.GammaCorrection
                    filtr.Gamma = pgSetting.GammaValue
                    filtr.ApplyInPlace(imgProc)

                End If

            Catch ex As Exception

            End Try

        Else

            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

            End If

            Dim Threshold As New Ag.Filters.BradleyLocalThresholding
            imgProc = Threshold.Apply(imgProc)

        End If


        Return imgProc

    End Function
    Public Overloads Shared Async Function AsyncApplyCorrections(ByVal imgProc As Bitmap) As Task(Of Bitmap)




        Dim tsk =
            TaskEx.Run(
            Sub()


                If OCRsettings.Binaries = False Then

                    Try
                        If OCRsettings.Gray = True Then

                            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

                            End If

                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If (OCRsettings.Threshold = True) Then

                            Dim Threshold As New Ag.Filters.Threshold
                            Threshold.ThresholdValue = OCRsettings.ThresholdValue
                            Threshold.ApplyInPlace(imgProc)
                        End If


                    Catch ex As Exception

                    End Try



                    Try
                        If OCRsettings.Bright = True Then

                            If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                                If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                                End If

                            Else
                                If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                                End If
                            End If



                            Dim filtr As New Ag.Filters.BrightnessCorrection
                            filtr.AdjustValue = OCRsettings.BrightValue
                            filtr.ApplyInPlace(imgProc)


                        End If
                    Catch ex As Exception

                    End Try


                    Try

                        If OCRsettings.Contrast = True Then

                            If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                                If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                                End If

                            Else
                                If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                                End If
                            End If

                            Dim filtr As New Ag.Filters.ContrastCorrection
                            filtr.Factor = OCRsettings.ContrastValue
                            filtr.ApplyInPlace(imgProc)

                        End If


                    Catch ex As Exception

                    End Try


                    Try

                        If OCRsettings.Gamma = True Then

                            If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                                If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                                End If

                            Else
                                If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                                End If
                            End If


                            Dim filtr As New Ag.Filters.GammaCorrection
                            filtr.Gamma = OCRsettings.GammaValue
                            filtr.ApplyInPlace(imgProc)

                        End If

                    Catch ex As Exception

                    End Try



                Else

                    If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
                    End If

                    Dim Threshold As New Ag.Filters.BradleyLocalThresholding
                    Threshold.ApplyInPlace(imgProc)

                End If

            End Sub)



        Await tsk


        Return imgProc

    End Function

    Public Overloads Shared Async Function AsyncApplyCorrections(ByVal imgProc As Bitmap, ByVal pgSetting As PageSetting) As Task(Of Bitmap)




        Dim tsk =
            TaskEx.Run(
            Sub()


                If pgSetting.Binaries = False Then

                    Try
                        If pgSetting.Gray = True Then

                            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

                            End If

                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If (pgSetting.Threshold = True) Then

                            Dim Threshold As New Ag.Filters.Threshold
                            Threshold.ThresholdValue = pgSetting.ThresholdValue
                            Threshold.ApplyInPlace(imgProc)
                        End If


                    Catch ex As Exception

                    End Try



                    Try
                        If pgSetting.Bright = True Then

                            If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                                If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                                End If

                            Else
                                If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                                End If
                            End If



                            Dim filtr As New Ag.Filters.BrightnessCorrection
                            filtr.AdjustValue = pgSetting.BrightValue
                            filtr.ApplyInPlace(imgProc)


                        End If
                    Catch ex As Exception

                    End Try


                    Try

                        If pgSetting.Contrast = True Then

                            If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                                If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                                End If

                            Else
                                If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                                End If
                            End If

                            Dim filtr As New Ag.Filters.ContrastCorrection
                            filtr.Factor = pgSetting.ContrastValue
                            filtr.ApplyInPlace(imgProc)

                        End If


                    Catch ex As Exception

                    End Try


                    Try

                        If pgSetting.Gamma = True Then

                            If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                                If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
                                End If

                            Else
                                If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                                    imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
                                End If
                            End If


                            Dim filtr As New Ag.Filters.GammaCorrection
                            filtr.Gamma = pgSetting.GammaValue
                            filtr.ApplyInPlace(imgProc)

                        End If

                    Catch ex As Exception

                    End Try



                Else

                    If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
                    End If

                    Dim Threshold As New Ag.Filters.BradleyLocalThresholding
                    Threshold.ApplyInPlace(imgProc)

                End If

            End Sub)



        Await tsk


        Return imgProc

    End Function
    Public Overloads Shared Function Invert(ByRef imgProc As Bitmap) As Bitmap

        If Not OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
            End If

        End If


        Dim inverter As New Ag.Filters.Invert

        imgProc = inverter.Apply(imgProc)

        Return imgProc
    End Function

    Public Overloads Shared Sub InvertInplace(ByRef imgProc As Bitmap)


        If Not OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

            End If

        End If

        Dim inverter As New Ag.Filters.Invert
        inverter.ApplyInPlace(imgProc)

    End Sub


    Public Overloads Shared Sub BrightnessApply(ByVal imgName As String, ByVal val As Integer)



        Dim imgProc = Ag.Image.FromFile(imgName)
        Dim filtr As New Ag.Filters.BrightnessCorrection
        filtr.AdjustValue = val
        filtr.ApplyInPlace(imgProc)
        imgProc.Save(imgName)


        imgProc.Dispose()
        imgProc = Nothing


    End Sub



    Public Shared Function skewAngle(ByVal imgProc As Bitmap) As Double

        Dim afrogeSkew As New Ag.DocumentSkewChecker


        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
            imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
        End If


        Dim deskewangle = afrogeSkew.GetSkewAngle(imgProc)

        imgProc.Dispose()
        imgProc = Nothing

        Return deskewangle

    End Function

    Public Overloads Shared Sub Rotate(ByRef imgProc As Bitmap, ByVal agl As Double)

        If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
            End If

        Else
            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
            End If
        End If

        Dim rotater As New Ag.Filters.RotateBilinear(agl)
        rotater.KeepSize = True
        rotater.FillColor = Color.WhiteSmoke


        imgProc = rotater.Apply(imgProc)
    End Sub


    Public Overloads Shared Sub RotateWithSize(ByRef imgProc As Bitmap, ByVal agl As Double)

        If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
            End If

        Else
            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
            End If
        End If

        Dim rotater As New Ag.Filters.RotateBilinear(agl)
        rotater.KeepSize = False
        rotater.FillColor = Color.WhiteSmoke


        imgProc = rotater.Apply(imgProc)
    End Sub

    Public Overloads Shared Sub RotateRight(ByRef imgProc As Bitmap)

        If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
            End If

        Else
            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
            End If
        End If

        Dim rotater As New Ag.Filters.RotateBilinear(90)

        rotater.KeepSize = False
        rotater.FillColor = Color.WhiteSmoke

        imgProc = rotater.Apply(imgProc)

    End Sub


    Public Overloads Shared Sub RotateLeft(ByRef imgProc As Bitmap)

        If OCRsettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
            End If

        Else
            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
                imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)
            End If
        End If

        Dim rotater As New Ag.Filters.RotateBilinear(-90)
        rotater.KeepSize = False
        rotater.FillColor = Color.WhiteSmoke

        imgProc = rotater.Apply(imgProc)

    End Sub


    Public Overloads Shared Sub CropImage(ByRef imgProc As Bitmap, ByVal Rectangle As Rectangle)

        Dim croper As New Ag.Filters.Crop(Rectangle)
        imgProc = croper.Apply(imgProc)



    End Sub
End Class
