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



    Public Overloads Shared Sub ConvertToGray(ByVal imgName As String)

        Dim imgProc = Ag.Image.FromFile(imgName)
        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)
        imgProc.Save(imgName)


        imgProc.Dispose()
        imgProc = Nothing
    End Sub

    Public Overloads Shared Function ApplyCorrections(ByVal imgProc As Bitmap) As Bitmap




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

                Dim filtr As New Ag.Filters.BrightnessCorrection
                filtr.AdjustValue = OCRsettings.BrightValue
                filtr.ApplyInPlace(imgProc)


            End If
        Catch ex As Exception

        End Try


        Try

            If OCRsettings.Contrast = True Then

                Dim filtr As New Ag.Filters.ContrastCorrection
                filtr.Factor = OCRsettings.ContrastValue
                filtr.ApplyInPlace(imgProc)

            End If


        Catch ex As Exception

        End Try


        Try

            If OCRsettings.Gamma = True Then

                Dim filtr As New Ag.Filters.GammaCorrection
                filtr.Gamma = OCRsettings.GammaValue
                filtr.ApplyInPlace(imgProc)

            End If

        Catch ex As Exception

        End Try

        Return imgProc
    End Function

    Public Overloads Shared Async Function AsyncApplyCorrections(ByVal imgProc As Bitmap) As Task(Of Bitmap)




        Dim tsk =
            TaskEx.Run(
            Sub()

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

                        Dim filtr As New Ag.Filters.BrightnessCorrection
                        filtr.AdjustValue = OCRsettings.BrightValue
                        filtr.ApplyInPlace(imgProc)


                    End If
                Catch ex As Exception

                End Try


                Try

                    If OCRsettings.Contrast = True Then

                        Dim filtr As New Ag.Filters.ContrastCorrection
                        filtr.Factor = OCRsettings.ContrastValue
                        filtr.ApplyInPlace(imgProc)

                    End If


                Catch ex As Exception

                End Try


                Try

                    If OCRsettings.Gamma = True Then

                        Dim filtr As New Ag.Filters.GammaCorrection
                        filtr.Gamma = OCRsettings.GammaValue
                        filtr.ApplyInPlace(imgProc)

                    End If

                Catch ex As Exception

                End Try


            End Sub)



        Await tsk

        Return imgProc
    End Function

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

        imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

        Dim deskewangle = afrogeSkew.GetSkewAngle(imgProc)

        imgProc.Dispose()
        imgProc = Nothing

        Return deskewangle
    End Function

    Public Overloads Shared Sub Rotate(ByRef imgProc As Bitmap, ByVal agl As Double)

        Dim rotater As New Ag.Filters.RotateBilinear(agl)
        rotater.KeepSize = True
        rotater.FillColor = Color.WhiteSmoke


        imgProc = rotater.Apply(imgProc)
    End Sub

    Public Overloads Shared Sub RotateRight(ByRef imgProc As Bitmap)

        Dim rotater As New Ag.Filters.RotateBilinear(90)
        rotater.KeepSize = False
        rotater.FillColor = Color.WhiteSmoke

        imgProc = rotater.Apply(imgProc)

    End Sub


    Public Overloads Shared Sub RotateLeft(ByRef imgProc As Bitmap)

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
