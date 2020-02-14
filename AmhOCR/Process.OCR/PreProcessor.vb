
Imports System.Drawing

Imports System.IO


'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class PreProcessor

    ''' <summary>
    ''' Correct skew angle of an image area
    ''' </summary>
    ''' <param name="imgProc">Image to be corrected</param>
    ''' <param name="Rec">Bounding box of an image area to bew deskewed</param>
    ''' <returns></returns>
    Public Shared Function Deskew(ByVal imgProc As Bitmap, ByVal Rec As Rectangle) As Image

        Return ImageUtils.Deskew(imgProc, Rec)

    End Function


    ''' <summary>
    ''' Apply Threshold,Brightness,Contrast and Gamma correction to an image
    ''' </summary>
    ''' <param name="imgProc">image to be processed</param>
    ''' <returns></returns>
    Public Overloads Shared Function ApplyCorrections(ByVal imgProc As Image) As Image


        If UserSettings.Binaries = False Then

            If UserSettings.Gray = True Then

                imgProc = ImageUtils.ConvertToGray(imgProc)

            End If


            If (UserSettings.Threshold = True) Then

                imgProc = ImageUtils.ApplyThreshold(imgProc, UserSettings.ThresholdValue)

            End If



            If UserSettings.Bright = True Then

                imgProc = ImageUtils.ApplyBrightness(imgProc, UserSettings.BrightValue)

            End If


            If UserSettings.Contrast = True Then

                imgProc = ImageUtils.ApplyContrast(imgProc, UserSettings.ContrastValue)

            End If


            If UserSettings.Gamma = True Then

                imgProc = ImageUtils.ApplyGamma(imgProc, UserSettings.GammaValue)

            End If


        Else

            imgProc = ImageUtils.ApplyLocalThresholding(imgProc)

        End If


        Return imgProc

    End Function

    Public Overloads Shared Function ApplyCorrections(ByVal imgProc As Image, ByVal pgSetting As PageSetting) As Image



        If pgSetting.Binaries = False Then



            If pgSetting.Gray = True Then

                imgProc = ImageUtils.ConvertToGray(imgProc)

            End If


            If (pgSetting.Threshold = True) Then

                imgProc = ImageUtils.ApplyThreshold(imgProc, pgSetting.ThresholdValue)

            End If



            If pgSetting.Bright = True Then

                imgProc = ImageUtils.ApplyBrightness(imgProc, pgSetting.BrightValue)

            End If


            If pgSetting.Contrast = True Then

                imgProc = ImageUtils.ApplyContrast(imgProc, pgSetting.ContrastValue)

            End If


            If pgSetting.Gamma = True Then

                imgProc = ImageUtils.ApplyGamma(imgProc, pgSetting.GammaValue)

            End If

        Else

            imgProc = ImageUtils.ApplyLocalThresholding(imgProc)

        End If


        Return imgProc

    End Function

    Public Overloads Shared Async Function AsyncApplyCorrections(ByVal imgProc As Bitmap) As Task(Of Bitmap)




        Dim tsk =
            TaskEx.Run(
            Sub()

                imgProc = ApplyCorrections(imgProc)

            End Sub)



        Await tsk


        Return imgProc

    End Function

    Public Overloads Shared Async Function AsyncApplyCorrections(ByVal imgProc As Bitmap, ByVal pgSetting As PageSetting) As Task(Of Bitmap)




        Dim tsk =
            TaskEx.Run(
            Sub()

                imgProc = ApplyCorrections(imgProc, pgSetting)

            End Sub)



        Await tsk


        Return imgProc

    End Function

    ''' <summary>
    ''' Invert image color
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <returns></returns>
    Public Overloads Shared Function Invert(ByRef imgProc As Bitmap) As Bitmap

        ImageUtils.InvertInplace(imgProc)

        Return imgProc

    End Function

    ''' <summary>
    ''' Get page boundary from an image
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <returns></returns>
    Public Overloads Shared Function GetPageBoundary(ByVal imgProc As Bitmap) As List(Of AForge.IntPoint)

        Return ImageUtils.GetPageBoundary(imgProc)

    End Function

    ''' <summary>
    ''' Crop page boundary from an image and apply perspective transformation
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <param name="pts"></param>
    ''' <returns></returns>
    Public Overloads Shared Function CropPageBoundary(ByVal imgProc As Bitmap, ByVal pts As List(Of Point)) As Bitmap



        Return ImageUtils.CropPageBoundary(imgProc, pts)


    End Function

    ''' <summary>
    ''' Invert image color
    ''' </summary>
    ''' <param name="imgProc"></param>
    Public Overloads Shared Sub InvertInplace(ByRef imgProc As Bitmap)


        ImageUtils.InvertInplace(imgProc)

    End Sub


    ''' <summary>
    ''' Get skew angle of an image
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <returns></returns>
    Public Shared Function skewAngle(ByVal imgProc As Bitmap) As Double

        Return ImageUtils.skewAngle(imgProc)

    End Function


    ''' <summary>
    ''' Rotate image keeping original image's width and height size fixed
    ''' </summary>
    ''' <param name="imgProc">image to be rotated</param>
    ''' <param name="agl">angle of rotation in degree</param>
    Public Overloads Shared Sub Rotate(ByRef imgProc As Bitmap, ByVal agl As Double)

        ImageUtils.Rotate(imgProc, agl, True)

    End Sub

    ''' <summary>
    ''' Rotate image  
    ''' </summary>
    ''' <param name="imgProc"></param>
    ''' <param name="agl"></param>
    Public Overloads Shared Sub RotateWithSize(ByRef imgProc As Bitmap, ByVal agl As Double)

        ImageUtils.Rotate(imgProc, agl)

    End Sub


    ''' <summary>
    ''' Rotate image by 90 degree
    ''' </summary>
    ''' <param name="imgProc"></param>
    Public Overloads Shared Sub RotateRight(ByRef imgProc As Bitmap)

        ImageUtils.Rotate(imgProc, 90)


    End Sub

    ''' <summary>
    ''' Rotate image by -90 degree
    ''' </summary>
    ''' <param name="imgProc"></param>
    Public Overloads Shared Sub RotateLeft(ByRef imgProc As Bitmap)

        ImageUtils.Rotate(imgProc, -90)


    End Sub

    ''' <summary>
    ''' Crop image area
    ''' </summary>
    ''' <param name="imgProc">original image</param>
    ''' <param name="Rectangle">croping bounding area  </param>
    Public Overloads Shared Sub CropImage(ByRef imgProc As Bitmap, ByVal Rectangle As Rectangle)

        ImageUtils.CropImage(imgProc, Rectangle)

    End Sub

End Class
