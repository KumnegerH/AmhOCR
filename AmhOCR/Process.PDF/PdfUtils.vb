﻿
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Imports GhostscriptSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class PdfUtils

    Public Shared Event PageProcessStartedArg As EventHandler(Of PageProcessStartedArg)
    Public Shared Event PageProcessed As EventHandler(Of PageProcessArg)

    Public Shared Event PdfFileMergeStarted As EventHandler(Of PdfMergeStartedArg)
    Public Shared Event PdfFileMerged As EventHandler(Of PdfMergedArg)
    ''' <summary>
    ''' Merge multiple PDF file in to one
    ''' </summary>
    ''' <param name="PdfToMerge">File name list </param>
    ''' <param name="OutPutFile">output PDF file name</param>
    Public Overloads Shared Sub MergePDFfiles(ByVal PdfToMerge() As String, ByVal OutPutFile As String)


        Dim Zdocument As Document = Nothing
        Dim ZpdfCopy As PdfCopy = Nothing

        'Event will be raised to notify the start of page split and the total file to be Merged
        Dim startArg As New PdfMergeStartedArg(PdfToMerge.Count)
        RaiseEvent PdfFileMergeStarted(Nothing, startArg)



        Dim cnt As Integer = 0
        For Each pdffile In PdfToMerge

            Dim reader As PdfReader = Nothing
            reader = New PdfReader(pdffile)
            If cnt = 0 Then
                Zdocument = New Document(reader.GetPageSizeWithRotation(1))

                ZpdfCopy = New PdfCopy(Zdocument,
                              New System.IO.FileStream(OutPutFile, System.IO.FileMode.Create))

                Zdocument.Open()
            End If


            ZpdfCopy.AddDocument(reader)

            reader.Close()

            reader.Dispose()
            reader = Nothing

            cnt += 1

            Dim mergeArg As New PdfMergedArg(pdffile, cnt)
            RaiseEvent PdfFileMerged(Nothing, mergeArg)

        Next

        Zdocument.Close()


        Zdocument.Dispose()
        Zdocument = Nothing

    End Sub

    ''' <summary>
    ''' Split a single or a range of PDF page and create new    
    ''' </summary>
    ''' <param name="PdfToSplit">pdf file to split</param>
    ''' <param name="OutPutFile">output pdf file name</param>
    ''' <param name="pgs">list of page numbers to split from the main PDF</param>
    Public Overloads Shared Sub SplitPDFPages(ByVal PdfToSplit As String, ByVal OutPutFile As String, ByVal pgs() As Integer)



        Try

            Dim pdfReader As PdfReader = Nothing
            Dim document As Document = Nothing
            Dim pdfCopy As PdfCopy = Nothing
            Dim pdfimportedPage As PdfImportedPage = Nothing

            'Event will be raised to notify the start of page split and the total pages to be splited
            Dim startArg As New PageProcessStartedArg(PdfToSplit, pgs.Count)
            RaiseEvent PageProcessStartedArg(Nothing, startArg)


            pdfReader = New PdfReader(PdfToSplit)

            document = New Document(pdfReader.GetPageSizeWithRotation(pgs(0)))

            pdfCopy = New PdfCopy(document,
                      New System.IO.FileStream(OutPutFile, System.IO.FileMode.Create))

            document.Open()

            For Each page In pgs
                pdfimportedPage = pdfCopy.GetImportedPage(pdfReader, page)
                pdfCopy.AddPage(pdfimportedPage)


                Dim splitArg As New PageProcessArg(page)
                RaiseEvent PageProcessed(Nothing, splitArg)

            Next

            document.Close()
            pdfReader.Close()

            pdfReader.Dispose()
            pdfReader = Nothing

            document.Dispose()
            document = Nothing


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    ''' <summary>
    ''' Get the number of page in a pdf file
    ''' </summary>
    ''' <param name="Pdffile">pdf file name</param>
    ''' <returns></returns>
    Public Overloads Shared Async Function GetPDFPageNumbers(ByVal Pdffile As String) As Task(Of Integer)
        Dim NumberOfPages As Integer = -1

        Dim tsk = TaskEx.Run(
            Sub()
                Dim reader As PdfReader = Nothing
                reader = New PdfReader(Pdffile)

                NumberOfPages = reader.NumberOfPages
                reader.Close()
                reader.Dispose()
                reader = Nothing

            End Sub)



        Await tsk

        Return NumberOfPages

    End Function


    ''' <summary>
    ''' Convert multiple images files to a single multipage PDF
    ''' </summary>
    ''' <param name="imgFiles">list of image file names</param>
    ''' <param name="pdfFile">output pdf file name</param>
    Public Overloads Shared Sub ImagesToPdf(ByVal imgFiles() As String, pdfFile As String)


        Try

            Using ms = New MemoryStream()

                Dim startArg As New PageProcessStartedArg(pdfFile, imgFiles.Count)
                RaiseEvent PageProcessStartedArg(Nothing, startArg)

                Dim document = New Document()
                Dim writer = PdfWriter.GetInstance(document, ms)
                writer.CompressionLevel = 100
                writer.SetFullCompression()

                document.Open()

                Dim pgCnt As Integer = 1
                For Each imgFile In imgFiles

                    Dim pageSize As Rectangle = Nothing

                    Using img = New Bitmap(imgFile)
                        Dim pntSize = MathHelp.PixelBoundToPointBound(img.Size, New Size(UserSettings.PrefResolution.Width, UserSettings.PrefResolution.Height))
                        pageSize = New Rectangle(0, 0, pntSize.Width, pntSize.Height)
                    End Using

                    document.SetPageSize(pageSize)
                    document.NewPage()

                    Dim Image = iTextSharp.text.Image.GetInstance(imgFile)
                    Image.ScaleToFit(pageSize)
                    Image.SetDpi(UserSettings.PrefResolution.Width, UserSettings.PrefResolution.Height)

                    Image.Alignment = 1
                    document.Add(Image)

                    Dim splitArg As New PageProcessArg(pgCnt)
                    RaiseEvent PageProcessed(Nothing, splitArg)
                    pgCnt += 1
                Next

                document.Close()

                File.WriteAllBytes(pdfFile, ms.ToArray())

            End Using


        Catch ex As Exception

        End Try


    End Sub


    ''' <summary>
    ''' Convert recognized image to a PDF file
    ''' </summary>
    ''' <param name="hocrPages">list of recognized image's HOCR data</param>
    ''' <param name="SaveAsName">output pdf file name</param>
    Public Overloads Shared Sub HocrsToPDF(ByVal hocrPages As IEnumerable(Of HocrPage), ByVal SaveAsName As String)


        Dim document As Document = Nothing
        Dim pdWrite As PdfWriter = Nothing

        Dim startArg As New PageProcessStartedArg(SaveAsName, hocrPages.Count)
        RaiseEvent PageProcessStartedArg(Nothing, startArg)
        Dim pgCnt As Integer = 0
        For Each page In hocrPages

            If document Is Nothing Then
                document = New Document()
                pdWrite = PdfWriter.GetInstance(document, New FileStream(SaveAsName, FileMode.Create, FileAccess.ReadWrite))
                document.Open()
            End If

            Dim DocSize = MathHelp.PixelBoundToPointBound(page.bbox.Size, page.PageOCRsettings.Resolution)
            Dim PageBounde As New Rectangle(DocSize.Width, DocSize.Height)

            document.SetPageSize(PageBounde)
            document.SetMargins(0, 0, 0, 0)
            document.NewPage()


            Dim Content = pdWrite.DirectContent
            Content.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_INVISIBLE)

            Dim areas = page.AllocrCarea
            For ar As Integer = 0 To areas.Count - 1

                Dim Pars = areas(ar).AllocrParas
                For pr As Integer = 0 To Pars.Count - 1

                    Dim fntbase = FontFactory.GetFont(Pars(pr).Font.FontFamily.Name, BaseFont.IDENTITY_H, False).BaseFont

                    Dim lins = Pars(pr).AllocrLines
                    For ln As Integer = 0 To lins.Count - 1

                        Dim words = lins(ln).AllocrWords
                        For wd As Integer = 0 To words.Count - 1

                            Dim WordBound = MathHelp.PixelBoundToPointBound(words(wd).bbox, page.PageOCRsettings.Resolution)
                            Content.BeginText()
                            Content.SetFontAndSize(fntbase, words(wd).x_fsize)
                            Content.SetTextMatrix(WordBound.X, PageBounde.Height - WordBound.Bottom)
                            Content.ShowText(words(wd).Text)
                            Content.EndText()

                        Next

                    Next

                Next

            Next

            Dim Image = iTextSharp.text.Image.GetInstance(page.imgCopyName)
            Image.ScaleToFit(PageBounde)
            Image.SetDpi(page.PageOCRsettings.Resolution.Width, page.PageOCRsettings.Resolution.Height)
            Image.Alignment = 1

            document.Add(Image)

            pgCnt += 1

            Dim splitArg As New PageProcessArg(pgCnt)
            RaiseEvent PageProcessed(Nothing, splitArg)

        Next

        document.Close()

        document.Dispose()
        document = Nothing


    End Sub

    ''' <summary>
    ''' Set font in itext library format
    ''' </summary>
    ''' <param name="fontName">font family name</param>
    ''' <param name="fontfile">font file name</param>
    Public Shared Sub SetitextFont(ByVal fontName As String, ByVal fontfile As String)

        If Not FontFactory.IsRegistered(fontName) Then
            FontFactory.Register(fontfile)
        End If

    End Sub


    ''' <summary>
    ''' Handles pdf to image conversion
    ''' </summary>
    ''' <param name="pdfFileName">pdf file name</param>
    ''' <param name="imgDirectory">image saving directory</param>
    Public Overloads Shared Sub PdfPagesToImages(ByVal pdfFileName As String, imgDirectory As String)


        Dim stei = New GhostscriptSettings
        stei.Device = UserSettings.imgFormat
        If UserSettings.isCustomePage = True Then
            stei.Size.Manual = UserSettings.PageSize
        Else
            stei.Size.Native = UserSettings.NativePage
        End If

        stei.Resolution = UserSettings.Resolution

        Dim cleanName = Path.GetFileNameWithoutExtension(pdfFileName)
        cleanName = Path.Combine(imgDirectory, cleanName + "_page_%d.jpeg")

        GhostscriptWrapper.GenerateOutput(pdfFileName, cleanName, stei)


    End Sub


End Class
