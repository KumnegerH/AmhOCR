
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports Ap = DocumentFormat.OpenXml.ExtendedProperties
Imports DocumentFormat.OpenXml.Wordprocessing
Imports M = DocumentFormat.OpenXml.Math
Imports Ovml = DocumentFormat.OpenXml.Vml.Office
Imports V = DocumentFormat.OpenXml.Vml
Imports Ds = DocumentFormat.OpenXml.CustomXmlDataProperties
Imports A = DocumentFormat.OpenXml.Drawing
Imports System.IO
Imports System.Xml
Imports sysDrawing = System.Drawing.Drawing2D

Public Class DocOutPut




    Public Overloads Shared Sub SingleColumnDocumentText(ByVal hocrPages As IEnumerable(Of HocrPage), ByVal FileName As String)




        Dim filePath As String = FileName
        Dim OutputText As String = ""
        For Each Page In hocrPages

            For Each carea In Page.AllocrCarea

                For Each para In carea.AllocrParas

                    OutputText += para.Text + Environment.NewLine

                Next
            Next
        Next


        File.WriteAllText(filePath, OutputText, System.Text.Encoding.UTF8)

    End Sub

    Public Overloads Shared Sub SingleColumnDocumentWord(ByVal hocrPages As IEnumerable(Of HocrPage), ByVal FileName As String)




        Dim filePath As String = FileName


        Dim wordDoc As WordprocessingDocument =
          WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document)
        Dim customFilePropPart As ExtendedFilePropertiesPart = wordDoc.AddExtendedFilePropertiesPart()
        customFilePropPart.Properties = New DocumentFormat.OpenXml.ExtendedProperties.Properties()


        Dim mainDocPart As MainDocumentPart = wordDoc.AddMainDocumentPart()

        mainDocPart.Document = New Document()
        Dim PageMargin As New ocrpagemargin
        Dim txtImgSize As New Size
        Dim body1 As Body = New Body()
        For Each Page In hocrPages
            PageMargin = MathHelp.Pixelmargin_20thmargin(Page.PageOCRsettings.Resolution, Page.ocrpagemargin)
            txtImgSize = MathHelp.PixelBoundTo_20thPoint(Page.PageOCRsettings.Resolution, Page.bbox.Size)
            For Each carea In Page.AllocrCarea

                For Each para In carea.AllocrParas

                    Dim paragraph1 As Paragraph = New Paragraph

                    Dim run1 As Run = New Run()
                    Dim fntSize = MathHelp.PixelFontSizeToDocumentFontSize(Page.PageOCRsettings.Resolution.Height, para.FontSize)
                    Dim runProperties1 As RunProperties = New RunProperties()
                    Dim runFonts1 As RunFonts = New RunFonts() With {.Ascii = para.Font.FontFamily.Name, .HighAnsi = para.Font.FontFamily.Name, .ComplexScriptTheme = ThemeFontValues.MinorHighAnsi}
                    Dim fontSize1 As FontSize = New FontSize() With {.Val = fntSize.ToString}
                    Dim fontSizeComplexScript1 As FontSizeComplexScript = New FontSizeComplexScript() With {.Val = fntSize.ToString}

                    runProperties1.Append(runFonts1)
                    runProperties1.Append(fontSize1)
                    runProperties1.Append(fontSizeComplexScript1)

                    Dim paragraphProperties1 As ParagraphProperties = New ParagraphProperties()
                    Dim justification1 As Justification = New Justification() With {.Val = JustificationValues.Both}

                    Dim paragraphMarkRunProperties1 As ParagraphMarkRunProperties = New ParagraphMarkRunProperties()
                    Dim runFonts2 As RunFonts = New RunFonts() With {.Ascii = para.Font.FontFamily.Name, .HighAnsi = para.Font.FontFamily.Name, .ComplexScriptTheme = ThemeFontValues.MinorHighAnsi}
                    Dim fontSize2 As FontSize = New FontSize() With {.Val = fntSize.ToString}
                    Dim fontSizeComplexScript12 As FontSizeComplexScript = New FontSizeComplexScript() With {.Val = fntSize.ToString}


                    paragraphMarkRunProperties1.Append(runFonts2)
                    paragraphMarkRunProperties1.Append(fontSize2)
                    paragraphMarkRunProperties1.Append(fontSizeComplexScript12)
                    paragraphProperties1.Append(justification1)
                    paragraphProperties1.Append(paragraphMarkRunProperties1)


                    Dim text1 = New Text()
                    text1.Text = para.Text


                    run1.Append(runProperties1)
                    run1.Append(text1)

                    paragraph1.Append(paragraphProperties1)
                    paragraph1.Append(run1)

                    body1.Append(paragraph1)

                Next
            Next
        Next


        Dim sectionProperties1 = New SectionProperties()

        Dim pageSize1 = New PageSize() With
        {.Width = UInt32Value.FromUInt32(CUInt(txtImgSize.Width)), .Height = UInt32Value.FromUInt32(CUInt(txtImgSize.Height))}



        ' To avoid page break due to narrow margins 

        Dim minimumMargin = PageMargin.Top

        If PageMargin.Bottom < minimumMargin Then
            minimumMargin = PageMargin.Bottom
        End If


        If PageMargin.Left < minimumMargin Then
            minimumMargin = PageMargin.Left
        End If

        If PageMargin.Right < minimumMargin Then
            minimumMargin = PageMargin.Right
        End If

        PageMargin.Top = minimumMargin
        PageMargin.Bottom = minimumMargin

        PageMargin.Left = minimumMargin
        PageMargin.Right = minimumMargin

        Dim pageMargin1 = New PageMargin() With
        {.Top = PageMargin.Top, .Right = UInt32Value.FromUInt32(CUInt(PageMargin.Right)), .Bottom = PageMargin.Bottom, .Left = UInt32Value.FromUInt32(CUInt(PageMargin.Left)), .Header = UInt32Value.FromUInt32(0UI), .Footer = UInt32Value.FromUInt32(0UI), .Gutter = UInt32Value.FromUInt32(0UI)}

        sectionProperties1.Append(pageSize1)
        sectionProperties1.Append(pageMargin1)

        body1.Append(sectionProperties1)


        mainDocPart.Document.Append(body1)


        wordDoc.Close()


    End Sub

End Class
