Imports System.Drawing.Imaging
Imports System.IO
Imports Ag = AForge.Imaging
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class ImageUtils

    ''' <summary>
    ''' Splits multipage tiff file 
    ''' </summary>
    ''' <param name="tiffname">multipage tiff filename</param>
    ''' <param name="outDirectory">output tiff directory</param>
    Public Shared Sub TiffSplit(ByVal tiffname As String, ByVal outDirectory As String)

        If Directory.Exists(outDirectory) = False Then
            Directory.CreateDirectory(outDirectory)
        End If

        Dim img = Image.FromFile(tiffname)
        Dim outname = "\" + Path.GetFileNameWithoutExtension(tiffname)
        Dim pgNum = img.GetFrameCount(FrameDimension.Page)

        If pgNum > 1 Then

            For pg As Integer = 0 To pgNum - 1
                pgNum = pg + 1
                img.SelectActiveFrame(FrameDimension.Page, pg)
                img.Save(outDirectory + outname + "_page" + (pg + 1).ToString + ".tif", ImageFormat.Tiff)
            Next

        Else

            img.Save(outDirectory + outname + ".tif", ImageFormat.Tiff)

        End If

        img.Dispose()
        img = Nothing


    End Sub



    ''' <summary>
    ''' Merge multiple tiff file into one multipage tiff file. 
    ''' </summary>
    ''' <param name="FileNames"></param>
    ''' <param name="SaveAs"></param>
    Public Shared Sub TiffMerge(FileNames() As String, ByVal SaveAs As String)

        Dim tiffFiles As New List(Of Byte())
        Dim tiffMerge As Byte() = Nothing

        For Each imgFile In FileNames
            tiffFiles.Add(File.ReadAllBytes(imgFile))
        Next

        Using msMerge = New MemoryStream
            Dim ici As ImageCodecInfo = Nothing

            For Each i As ImageCodecInfo In ImageCodecInfo.GetImageEncoders

                If (i.MimeType = "image/tiff") Then
                    ici = i
                End If
            Next


            Dim enc = Encoder.SaveFlag

            Dim ep = New EncoderParameters(1)

            Dim pages As Bitmap = Nothing
            Dim frame As Integer = 0

            For Each tiffFile In tiffFiles

                Using imageStream = New MemoryStream(tiffFile)

                    Using tiffImage = Image.FromStream(imageStream)

                        For Each guid As Guid In tiffImage.FrameDimensionsList

                            'create the frame dimension 
                            Dim dimension = New FrameDimension(guid)
                            'Gets the total number of frames in the .tiff file 
                            Dim noOfPages = tiffImage.GetFrameCount(dimension)

                            For index As Integer = 0 To noOfPages - 1

                                Dim currentFrame = New FrameDimension(guid)

                                tiffImage.SelectActiveFrame(currentFrame, index)

                                Using tempImg = New MemoryStream
                                    tiffImage.Save(tempImg, ImageFormat.Tiff)

                                    If (frame = 0) Then
                                        'save the first frame
                                        pages = Image.FromStream(tempImg)
                                        ep.Param(0) = New EncoderParameter(enc, EncoderValue.MultiFrame)
                                        pages.Save(msMerge, ici, ep)

                                    Else

                                        'save the intermediate frames
                                        ep.Param(0) = New EncoderParameter(enc, EncoderValue.FrameDimensionPage)
                                        pages.SaveAdd(Image.FromStream(tempImg), ep)

                                    End If

                                    frame += 1

                                End Using
                            Next

                        Next


                    End Using



                End Using

            Next

            If (frame > 0) Then
                'flush And close.
                ep.Param(0) = New EncoderParameter(enc, EncoderValue.Flush)
                pages.SaveAdd(ep)

            End If

            msMerge.Position = 0
            tiffMerge = msMerge.ToArray()


        End Using



        File.WriteAllBytes(SaveAs, tiffMerge)

    End Sub

    ''' <summary>
    ''' Convert image to other image format
    ''' </summary>
    ''' <param name="FileNames">Image file to be converted</param>
    ''' <param name="outDirectory">Output file directory</param>
    ''' <param name="extension">New image type extension</param>
    Public Shared Sub ConvertImages(FileNames() As String, ByVal outDirectory As String, ByVal extension As String)
        If Directory.Exists(outDirectory) = False Then
            Directory.CreateDirectory(outDirectory)
        End If

        For Each imgname In FileNames
            Dim img = Image.FromFile(imgname)
            Dim outname = "\" + Path.GetFileNameWithoutExtension(imgname)
            Dim pgNum = img.GetFrameCount(FrameDimension.Page)

            If pgNum > 1 Then

                For pg As Integer = 0 To pgNum - 1
                    pgNum = pg + 1
                    img.SelectActiveFrame(FrameDimension.Page, pg)
                    img.Save(outDirectory + outname + "_page" + (pg + 1).ToString + extension)
                Next

            Else

                img.Save(outDirectory + outname + extension)

            End If

            img.Dispose()
            img = Nothing


        Next


    End Sub

    ''' <summary>
    ''' Handles Image Open from a disk with aforge's compatiable pixle formate
    ''' </summary>
    ''' <param name="FileName">Image from name</param>
    ''' <returns></returns>
    Public Shared Function SafeOpenImage(ByVal FileName As String) As Image

        Dim img As Image

        Using opnImg = AForge.Imaging.Image.FromFile(FileName)

            If Not UserSettings.AcceptedImageFormat.Contains(opnImg.PixelFormat) Then

                img = AForge.Imaging.Image.Clone(opnImg, PixelFormat.Format24bppRgb)

            Else

                img = AForge.Imaging.Image.Clone(opnImg)

            End If

        End Using

        Return img

    End Function


    ''' <summary>
    ''' Clone image with compatiable image pixle format
    ''' </summary>
    ''' <param name="img"></param>
    ''' <returns></returns>
    Public Shared Function CloneImageForGraphics(ByVal img As Image) As Image

        If Not UserSettings.AcceptedImageFormat.Contains(img.PixelFormat) Then

            img = AForge.Imaging.Image.Clone(img, PixelFormat.Format24bppRgb)

        End If

        Return img

    End Function


    ''' <summary>
    ''' Crop image area
    ''' </summary>
    ''' <param name="imgProc">original image</param>
    ''' <param name="Rectangle">croping bounding area  </param>
    Public Overloads Shared Sub CropImage(ByRef imgProc As Bitmap, ByVal Rectangle As Rectangle)

        Dim croper As New Ag.Filters.Crop(Rectangle)
        imgProc = croper.Apply(imgProc)

    End Sub

    Public Overloads Shared Function ConvertTo24bppRgb(ByVal imgProc As Bitmap) As Bitmap


        If Not imgProc.PixelFormat.ToString.Equals("Format24bppRgb") Then
            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format24bppRgb)
        End If

        Return imgProc

    End Function

    Public Overloads Shared Function ConvertTo8bppRgb(ByVal imgProc As Bitmap) As Bitmap


        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then
            imgProc = AForge.Imaging.Image.Clone(imgProc, Imaging.PixelFormat.Format8bppIndexed)

        End If



        Return imgProc

    End Function


    Public Overloads Shared Function ConvertToGray(ByVal imgProc As Bitmap) As Bitmap


        Try
            If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

                imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

            End If


        Catch ex As Exception

        End Try




        Return imgProc


    End Function


    '' <summary>
    ''' Rotate image by -90 degree
    ''' </summary>
    ''' <param name="imgProc"></param>
    Public Overloads Shared Sub Rotate(ByRef imgProc As Bitmap, ByVal ang As Double, Optional keepsize As Boolean = False)

        If UserSettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            imgProc = ConvertTo24bppRgb(imgProc)

        Else
            imgProc = ConvertTo8bppRgb(imgProc)
        End If

        Dim rotater As New Ag.Filters.RotateBilinear(ang)
        rotater.KeepSize = keepsize
        rotater.FillColor = Color.White

        imgProc = rotater.Apply(imgProc)

    End Sub


    ''' <summary>
    ''' Get skew angle of an image
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <returns></returns>
    Public Shared Function skewAngle(ByVal imgProc As Bitmap) As Double

        Dim afrogeSkew As New Ag.DocumentSkewChecker



        imgProc = ConvertTo8bppRgb(imgProc)

        Dim deskewangle = afrogeSkew.GetSkewAngle(imgProc)

        imgProc.Dispose()
        imgProc = Nothing

        Return deskewangle

    End Function


    Public Overloads Shared Function ApplyThreshold(ByVal imgProc As Bitmap, ByVal val As Integer) As Bitmap

        Try

            Dim Threshold As New Ag.Filters.Threshold
            Threshold.ThresholdValue = val

            imgProc = Threshold.Apply(imgProc)

        Catch ex As Exception

        End Try


        Return imgProc

    End Function


    Public Overloads Shared Function ApplyContrast(ByVal imgProc As Bitmap, ByVal val As Integer) As Bitmap


        Try
            If UserSettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                imgProc = ConvertTo24bppRgb(imgProc)

            Else

                imgProc = ConvertTo8bppRgb(imgProc)

            End If

            Dim filtr As New Ag.Filters.ContrastCorrection
            filtr.Factor = val
            imgProc = filtr.Apply(imgProc)


        Catch ex As Exception

        End Try


        Return imgProc

    End Function


    Public Overloads Shared Function ApplyLocalThresholding(ByVal imgProc As Bitmap) As Bitmap

        Try

            imgProc = ConvertToGray(imgProc)


            Dim Threshold As New Ag.Filters.BradleyLocalThresholding
            imgProc = Threshold.Apply(imgProc)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return imgProc

    End Function

    Public Overloads Shared Function ApplyGamma(ByVal imgProc As Bitmap, ByVal val As Integer) As Bitmap

        Try

            If UserSettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                imgProc = ConvertTo24bppRgb(imgProc)

            Else

                imgProc = ConvertTo8bppRgb(imgProc)

            End If


            Dim filtr As New Ag.Filters.GammaCorrection
            filtr.Gamma = val

            imgProc = filtr.Apply(imgProc)

        Catch ex As Exception

        End Try


        Return imgProc

    End Function

    ''' <summary>
    ''' Apply Brightness correction
    ''' </summary>
    ''' <param name="imgName"></param>
    ''' <param name="val"></param>
    Public Overloads Shared Function ApplyBrightness(ByVal imgProc As Bitmap, ByVal val As Integer) As Bitmap

        Try

            If UserSettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

                imgProc = ConvertTo24bppRgb(imgProc)

            Else

                imgProc = ConvertTo8bppRgb(imgProc)

            End If

            Dim filtr As New Ag.Filters.BrightnessCorrection
            filtr.AdjustValue = val
            imgProc = filtr.Apply(imgProc)


        Catch ex As Exception

        End Try



        Return imgProc

    End Function





    ''' <summary>
    ''' Invert image color
    ''' </summary>
    ''' <param name="imgProc"></param>
    Public Overloads Shared Sub InvertInplace(ByRef imgProc As Bitmap)


        If Not UserSettings.AcceptedImageFormat.Contains(imgProc.PixelFormat) Then

            imgProc = ConvertTo8bppRgb(imgProc)

        End If

        Dim inverter As New Ag.Filters.Invert
        inverter.ApplyInPlace(imgProc)

    End Sub


    ''' <summary>
    ''' Crop page boundary from an image and apply perspective transformation
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <param name="pts"></param>
    ''' <returns></returns>
    Public Overloads Shared Function CropPageBoundary(ByVal imgProc As Bitmap, ByVal pts As List(Of Point)) As Bitmap

        Dim edgs As New List(Of AForge.IntPoint)

        For Each pt In pts

            edgs.Add(New AForge.IntPoint(pt.X, pt.Y))

        Next



        Dim quadFind As New AForge.Imaging.Filters.QuadrilateralTransformation
        quadFind.SourceQuadrilateral = edgs
        quadFind.UseInterpolation = True
        quadFind.AutomaticSizeCalculaton = True


        Return quadFind.Apply(imgProc)


    End Function



    ''' <summary>
    ''' Get page boundary from an image
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <returns></returns>
    Public Overloads Shared Function GetPageBoundary(ByVal imgProc As Bitmap) As List(Of AForge.IntPoint)

        Dim edgePoints As New List(Of AForge.IntPoint)

        edgePoints.Add(New AForge.IntPoint(0, 0))
        edgePoints.Add(New AForge.IntPoint(imgProc.Width, 0))
        edgePoints.Add(New AForge.IntPoint(imgProc.Width, imgProc.Height))
        edgePoints.Add(New AForge.IntPoint(0, imgProc.Height))


        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

            Dim colorFilter = New Ag.Filters.ColorFiltering

            colorFilter.Red = New AForge.IntRange(0, 64)
            colorFilter.Green = New AForge.IntRange(0, 64)
            colorFilter.Blue = New AForge.IntRange(0, 64)
            colorFilter.FillOutsideRange = False
            colorFilter.ApplyInPlace(imgProc)


            imgProc = Ag.Filters.Grayscale.CommonAlgorithms.Y.Apply(imgProc)

        End If

        Dim Statistics As New Ag.ImageStatistics(imgProc)
        Dim StdDev = Statistics.Gray.StdDev

        Dim thresholdfilter As New Ag.Filters.Threshold

        thresholdfilter.ThresholdValue = 65

        If StdDev <= 30 Then

            thresholdfilter.ThresholdValue = 40

        ElseIf StdDev <= 40 Then

            thresholdfilter.ThresholdValue = 45

        ElseIf StdDev <= 45 Then

            thresholdfilter.ThresholdValue = 50

        ElseIf StdDev <= 50 Then

            thresholdfilter.ThresholdValue = 55


        ElseIf StdDev <= 55 Then

            thresholdfilter.ThresholdValue = 60

        ElseIf StdDev <= 62.5 Then

            thresholdfilter.ThresholdValue = 65

        ElseIf StdDev <= 65 Then

            thresholdfilter.ThresholdValue = 70

        ElseIf StdDev <= 67.5 Then

            thresholdfilter.ThresholdValue = 80

        ElseIf StdDev <= 70 Then

            thresholdfilter.ThresholdValue = 90

        ElseIf StdDev <= 72.5 Then

            thresholdfilter.ThresholdValue = 100

        ElseIf StdDev <= 75 Then

            thresholdfilter.ThresholdValue = 105

        ElseIf StdDev <= 80 Then

            thresholdfilter.ThresholdValue = 110

        ElseIf StdDev <= 85 Then

            thresholdfilter.ThresholdValue = 115

        ElseIf StdDev <= 90 Then

            thresholdfilter.ThresholdValue = 120

        Else

            thresholdfilter.ThresholdValue = 130

        End If



        imgProc = thresholdfilter.Apply(imgProc)

        Dim blobfinedr As New Ag.BlobCounter
        blobfinedr.ObjectsOrder = AForge.Imaging.ObjectsOrder.Size
        blobfinedr.FilterBlobs = True
        blobfinedr.MinHeight = imgProc.Height / 4
        blobfinedr.MinWidth = imgProc.Width / 4


        blobfinedr.ProcessImage(imgProc)
        Dim blb = blobfinedr.GetObjectsInformation

        Dim blobChecker As New AForge.Math.Geometry.SimpleShapeChecker

        For cnt As Integer = 0 To blb.Count - 1

            Dim allEdgePoints = blobfinedr.GetBlobsEdgePoints(blb(cnt))

            Dim SimplifiedIntPoints As New List(Of AForge.IntPoint)

            If blobChecker.IsQuadrilateral(allEdgePoints, SimplifiedIntPoints) Then

                If SimplifiedIntPoints.Count = 4 Then

                    edgePoints = SimplifiedIntPoints.ToList

                    Exit For

                End If


            End If




        Next



        edgePoints = MathHelp.AdjustRectangleEdge(edgePoints)

        Return edgePoints

    End Function

    ''' <summary>
    ''' Correct skew angle of an image area
    ''' </summary>
    ''' <param name="imgProc">Image to be corrected</param>
    ''' <param name="Rec">Bounding box of an image area to bew deskewed</param>
    ''' <returns></returns>
    Public Shared Function Deskew(ByVal imgProc As Bitmap, ByVal Rec As Rectangle) As Image


        Dim afrogeSkew = New Ag.DocumentSkewChecker

        Dim deskewangle As Double = 0

        If Not imgProc.PixelFormat.ToString.Equals("Format8bppIndexed") Then

            imgProc = ConvertToGray(imgProc)

        End If


        deskewangle = skewAngle(imgProc)

        Dim rotater As New Ag.Filters.RotateBilinear(-deskewangle)
        rotater.KeepSize = True
        rotater.FillColor = Color.WhiteSmoke
        If Math.Abs(deskewangle) < 45 Then
            imgProc = rotater.Apply(imgProc)
        End If

        Return imgProc
    End Function



End Class
