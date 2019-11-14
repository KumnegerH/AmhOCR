'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Imports NetTesseract

Public Class TessRecognize

    Public Shared Event PageRecognized As EventHandler(Of PageRecognizedArg)


    Public Overloads Shared Async Function Recognize(ByVal FileName As String, ByVal RecognizedPage As HocrPage) As Task(Of HocrPage)

        RecognizedPage.Recognized = False

        Using TessRecog As New ReadImage(OCRsettings.Language, OCRsettings.OcrMode)

            Dim HOCRText = String.Empty

            Try
                'Recognize image and get hocr formated output text
                HOCRText = Await TessRecog.GetHocr(FileName, OCRsettings.TimeOut)

            Catch ex As Exception

            End Try


            If Not String.IsNullOrEmpty(HOCRText) Then
                ' convert hocr text to Linq.XElement object

                RecognizedPage.HocrXML = XElement.Parse(HOCRText)

                If RecognizedPage.HocrXML.HasElements = True Then

                    RecognizedPage = Await ParseHocr(RecognizedPage)

                End If




            End If



        End Using


        Return RecognizedPage
    End Function


    Public Overloads Shared Async Function Recognize(ByVal FileName As List(Of String), ByVal RecognizedPage As List(Of HocrPage)) As Task(Of List(Of HocrPage))



        Using TessRecog As New ReadImage(OCRsettings.Language, OCRsettings.OcrMode)

            Dim HOCRText = String.Empty

            Try
                'Recognize image and get hocr formated output text
                HOCRText = Await TessRecog.GetHocr(FileName)

            Catch ex As Exception

            End Try


            If Not String.IsNullOrEmpty(HOCRText) Then
                ' convert hocr text to Linq.XElement object

                Dim HocrXML = XElement.Parse(HOCRText)

                If HocrXML.HasElements = True Then

                    RecognizedPage = Await ParseHocr(HocrXML, RecognizedPage)

                End If



            End If


        End Using


        Return RecognizedPage
    End Function


    Public Overloads Shared Async Function ParseHocr(ByVal RecognizedPage As HocrPage) As Task(Of HocrPage)
        'Convert Linq.XElement object to Hocr objects (page, column,paragraph, line and words 
        'With bounding box And other properties  

        Dim tsk =
            TaskEx.Run(
            Sub()

                Dim hoxrxml = RecognizedPage.HocrXML

                'Validate header 
                Dim Body = hoxrxml.Elements.Where(Function(X) X.Name.LocalName = "body")

                If Body.Count > 0 Then
                    For Each MainElements In Body
                        For Each pages In MainElements.Elements
                            If pages.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_page") Then

                                RecognizedPage = HocrParser.ParsePage(pages, RecognizedPage.ImageName, RecognizedPage)
                                If String.IsNullOrEmpty(RecognizedPage.UTF8Text) = False Then
                                    RecognizedPage.Recognized = True
                                    Dim recoArg As New PageRecognizedArg(1, RecognizedPage.ImageName)
                                    RaiseEvent PageRecognized(Nothing, recoArg)
                                End If

                            End If
                        Next

                    Next



                Else
                    RecognizedPage = HocrParser.ParsePage(hoxrxml, RecognizedPage.ImageName, RecognizedPage)
                    If String.IsNullOrEmpty(RecognizedPage.UTF8Text) = False Then
                        RecognizedPage.Recognized = True
                        RecognizedPage.Recognized = True
                        Dim recoArg As New PageRecognizedArg(1, RecognizedPage.ImageName)
                        RaiseEvent PageRecognized(Nothing, recoArg)
                    End If
                End If

            End Sub)


        Await tsk

        Return RecognizedPage

    End Function

    Public Overloads Shared Async Function ParseHocr(ByVal hoxrxml As XElement, ByVal AllRecognizedPage As List(Of HocrPage)) As Task(Of List(Of HocrPage))
        'Convert Linq.XElement object to Hocr objects (page, column,paragraph, line and words 
        'With bounding box And other properties  

        Dim tsk =
            TaskEx.Run(
            Sub()

                'Validate header 
                Dim Body = hoxrxml.Elements.Where(Function(X) X.Name.LocalName = "body")
                Dim pgCnt As Integer = 0
                If Body.Count > 0 Then
                    For Each MainElements In Body
                        For Each pages In MainElements.Elements
                            Dim RecognizedPage = AllRecognizedPage(pgCnt)
                            RecognizedPage.Recognized = False
                            RecognizedPage.HocrXML = pages
                            If pages.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_page") Then

                                RecognizedPage = HocrParser.ParsePage(pages, RecognizedPage.ImageName, RecognizedPage)
                                If String.IsNullOrEmpty(RecognizedPage.UTF8Text) = False Then
                                    RecognizedPage.Recognized = True
                                    RecognizedPage.Recognized = True
                                    Dim recoArg As New PageRecognizedArg(pgCnt + 1, RecognizedPage.ImageName)
                                    RaiseEvent PageRecognized(Nothing, recoArg)
                                End If

                            End If
                            AllRecognizedPage(pgCnt) = RecognizedPage
                            pgCnt += 1
                        Next

                    Next



                Else
                    Dim RecognizedPage = AllRecognizedPage(0)
                    RecognizedPage = HocrParser.ParsePage(hoxrxml, RecognizedPage.ImageName, RecognizedPage)
                    If String.IsNullOrEmpty(RecognizedPage.UTF8Text) = False Then
                        RecognizedPage.Recognized = True
                        Dim recoArg As New PageRecognizedArg(1, RecognizedPage.ImageName)
                        RaiseEvent PageRecognized(Nothing, recoArg)
                    End If
                    AllRecognizedPage(0) = RecognizedPage
                End If

            End Sub)


        Await tsk

        Return AllRecognizedPage

    End Function

End Class
