Imports System.Drawing.Imaging
Imports System.IO
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


    Public Shared Function SafeOpenImage(ByVal FileName As String) As Image

        Dim img As Image

        Using opnImg = AForge.Imaging.Image.FromFile(FileName)

            If Not OCRsettings.AcceptedImageFormat.Contains(opnImg.PixelFormat) Then

                img = AForge.Imaging.Image.Clone(opnImg, PixelFormat.Format24bppRgb)

            Else

                img = AForge.Imaging.Image.Clone(opnImg)

            End If

        End Using

        Return img

    End Function

    Public Shared Function CloneImageForGraphics(ByVal img As Image) As Image

        If Not OCRsettings.AcceptedImageFormat.Contains(img.PixelFormat) Then

            img = AForge.Imaging.Image.Clone(img, PixelFormat.Format24bppRgb)

        End If

        Return img

    End Function

End Class
