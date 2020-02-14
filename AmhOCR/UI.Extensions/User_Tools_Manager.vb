Imports System.IO
Imports Ag = AForge.Imaging

Partial Class MainWindow


    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2020 GPLv3


    ''' <summary>
    '''Handles Convert images to PDF
    ''' </summary>
    Private Sub ImageToPDF()

        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.ConvertImageToPDF
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Convert multiple images To PDF"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Error!")
            End If



        End If

    End Sub


    ''' <summary>
    '''Handles Split multi page Tiff image file  
    ''' </summary>
    Private Sub SplitTiff()

        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.SplitTiff
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Split Tiff Formated Image"
        If ofb.ShowDialog(Me) = DialogResult.OK Then
            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Tiff Splitting finished")
            End If

        End If

    End Sub

    ''' <summary>
    '''Handles Merge images to multi page tiff file
    ''' </summary>
    Private Sub MergeTiff()

        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.MergeTiff
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Merge multiple Tiff To Single Tiff image"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Tiff Mergging finished!")
            End If


        End If


    End Sub


    ''' <summary>
    '''Handles Split PDF into separet PDF 
    ''' </summary>
    Private Sub SplitPDF()

        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.SplitPDF
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Split Pages from a Pdf File"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("PDF Spliting finished!")
            End If



        End If


    End Sub


    ''' <summary>
    '''Handles Merge multiple PDF file into single PDF file
    ''' </summary>
    Private Sub CombinePDF()

        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.MergePDF
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Merge Pdf Files"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("PDF Merge finished!")
            End If



        End If


    End Sub


    ''' <summary>
    '''Handles Convert PDF to Image 
    ''' </summary>
    Private Sub PDFToImage()

        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.ConvertPDFtoImage
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Convert Pdf To Images"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("PDF To Image conversion finished!")
            End If



        End If

    End Sub


    ''' <summary>
    ''' Handles image convertion to a different image format
    ''' </summary>
    Private Sub ConvertImages()


        Dim ofb As New FileToolsHandler
        ofb.operation = UtilOperationType.ConvertImageToImage
        ofb.ouputDirTxt.Text = UserSettings.AmhOcrConvFolder
        ofb.Text = "Convert Images To Images"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Images To Image conversion finished!")
            End If



        End If


    End Sub

End Class
