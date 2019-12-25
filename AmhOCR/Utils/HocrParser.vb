
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Imports System.Text
Imports System.Linq
Public Class HocrParser

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3


    ' used to send info for lower level parser
    Private Shared CurrentPageBox As Rectangle

    Public Shared Function ParsePage(ByVal Hocrxml As XElement, ByVal imgName As String, ByVal newOCRpage As HocrPage) As HocrPage



        If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_page") Then

            If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "title" AndAlso String.IsNullOrEmpty(X.Value) = False) Then

                Dim box = ParseBBox(Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)

                box.Width = box.Width - box.X
                box.Height = box.Height - box.Y
                newOCRpage.bbox = box
                CurrentPageBox = box

                Dim XPage As New XElement(Hocrxml)
                XPage.RemoveNodes()

                For Each tgs In Hocrxml.Elements


                    If tgs.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_carea") Then

                        Dim newocrCarea As New HocrCarea
                        newocrCarea.areaNum = newOCRpage.AllocrCarea.Count
                        Dim Xnode As New XElement(tgs)
                        newocrCarea = ParseArea(Xnode, newocrCarea)

                        If newocrCarea IsNot Nothing AndAlso newocrCarea.AllocrParas.Count > 0 Then
                            newOCRpage.AllocrCarea.Add(newocrCarea)

                            XPage.Add(Xnode)
                        End If

                    End If

                Next

                newOCRpage.HocrXML.Elements.
                                Single(Function(X) X.Name.LocalName = "body").
                                RemoveNodes()

                newOCRpage.HocrXML.Elements.
                                 Single(Function(X) X.Name.LocalName = "body").
                                 Add(XPage)


                newOCRpage.UTF8Text = ""

                newOCRpage = UpdateparagraphToPage(newOCRpage)

                newOCRpage.orignalText = newOCRpage.UTF8Text


            Else

                newOCRpage = Nothing

            End If

        Else

            newOCRpage = Nothing

        End If

        Return newOCRpage

    End Function



    Private Shared Function ParseArea(ByRef Hocrxml As XElement, ByRef newocrCarea As HocrCarea) As HocrCarea

        Dim Xarea As XElement
        Xarea = New XElement(Hocrxml)
        Xarea.RemoveNodes()


        If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_carea") Then

            If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "title" AndAlso String.IsNullOrEmpty(X.Value) = False) Then

                Dim Box = ParseBBox(Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)
                Box.Width = Box.Width - Box.X
                Box.Height = Box.Height - Box.Y
                newocrCarea.bbox = Box

                For Each tgs In Hocrxml.Elements

                    If tgs.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_par") Then
                        Dim newpara As New HocrPar
                        newpara.AreaNum = newocrCarea.areaNum
                        newpara.ParNum = newocrCarea.AllocrParas.Count
                        Dim Xnode As New XElement(tgs)
                        newpara = ParsePara(Xnode, newpara)

                        If newpara IsNot Nothing AndAlso newpara.AllocrLines.Count > 0 Then
                            newocrCarea.AllocrParas.Add(newpara)

                            Xarea.Add(Xnode)
                        End If


                    End If



                Next



            Else

                newocrCarea = Nothing
            End If

        Else
            newocrCarea = Nothing
        End If

        Hocrxml = New XElement(Xarea)
        Return newocrCarea
    End Function


    Private Shared Function ParsePara(ByRef Hocrxml As XElement, ByRef newocrPar As HocrPar) As HocrPar

        Dim XPara As XElement
        XPara = New XElement(Hocrxml)
        XPara.RemoveNodes()

        If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocr_par") Then

            If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "title" AndAlso String.IsNullOrEmpty(X.Value) = False) Then

                Dim box = ParseBBox(Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)

                box.Width = box.Width - box.X
                box.Height = box.Height - box.Y
                newocrPar.bbox = box

                If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "lang" AndAlso String.IsNullOrEmpty(X.Value) = False) Then
                    newocrPar.Lang = Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "lang").First.Value
                End If

                For Each tgs In Hocrxml.Elements

                    If tgs.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso (X.Value = "ocr_line" OrElse X.Value = "ocr_header" OrElse X.Value = "ocr_textfloat" OrElse X.Value = "ocr_caption")) Then
                        Dim newLine As New HocrLine
                        newLine.areaNum = newocrPar.AreaNum
                        newLine.ParNum = newocrPar.ParNum
                        newLine.LineNum = newocrPar.AllocrLines.Count

                        Dim Xnode As New XElement(tgs)
                        newLine = ParseLine(Xnode, newocrPar.Lang, newLine)

                        If newLine IsNot Nothing AndAlso newLine.AllocrWords.Count > 0 Then
                            newocrPar.AllocrLines.Add(newLine)
                            XPara.Add(Xnode)
                        End If


                    End If



                Next

                newocrPar.Text = String.Join(Environment.NewLine, newocrPar.AllocrLines.Select(Of String)(Function(X) X.Text))
                newocrPar.orignalText = newocrPar.Text

            Else

                newocrPar = Nothing
            End If

        Else

            newocrPar = Nothing
        End If

        Hocrxml = New XElement(XPara)
        Return newocrPar


    End Function


    Private Shared Function ParseLine(ByRef Hocrxml As XElement, ByVal lng As String, ByRef newocrLine As HocrLine) As HocrLine


        Dim Xline As XElement
        Xline = New XElement(Hocrxml)
        Xline.RemoveNodes()

        If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "title" AndAlso String.IsNullOrEmpty(X.Value) = False) Then

            Dim box = ParseBBox(Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)

            box.Width = box.Width - box.X
            box.Height = box.Height - box.Y
            newocrLine.bbox = box

            newocrLine.BaseLine = ParseBaseLine(Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)
            newocrLine.x_size = ParseParameter("x_size", Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)
            newocrLine.x_descenders = ParseParameter("x_descenders", Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)
            newocrLine.x_ascenders = ParseParameter("x_ascenders", Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)


            For Each tgs In Hocrxml.Elements

                If tgs.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocrx_word") Then

                    Dim Xnode As New XElement(tgs)
                    Dim newword = ParseWord(Xnode, lng)

                    If (newword IsNot Nothing) AndAlso (Not String.IsNullOrEmpty(newword.Text)) Then
                        newword.areaNum = newocrLine.areaNum
                        newword.ParNum = newocrLine.ParNum
                        newword.lineNum = newocrLine.LineNum
                        newword.WordNum = newocrLine.AllocrWords.Count
                        newocrLine.AllocrWords.Add(newword)

                        Xline.Add(Xnode)
                    End If

                End If



            Next

            newocrLine.Text = String.Join(" ", newocrLine.AllocrWords.Select(Of String)(Function(X) X.Text))
            newocrLine.orignalText = newocrLine.Text
        Else

            newocrLine = Nothing
        End If


        Hocrxml = New XElement(Xline)

        Return newocrLine


    End Function




    Private Shared Function ParseWord(ByVal Hocrxml As XElement, ByVal lng As String) As HocrWord


        Dim newocrWord As New HocrWord

        If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "class" AndAlso X.Value = "ocrx_word") Then

            If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "title" AndAlso String.IsNullOrEmpty(X.Value) = False) Then

                Dim box = ParseBBox(Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)

                box.Width = box.Width - box.X
                box.Height = box.Height - box.Y

                newocrWord.bbox = box
                newocrWord.Text = Hocrxml.Value
                newocrWord.orignalText = newocrWord.Text
                newocrWord.XmlElement = Hocrxml
                newocrWord.x_wconf = ParseParameter("x_wconf", Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)
                newocrWord.x_fsize = ParseParameter("x_fsize", Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "title").First.Value)
                newocrWord.Lang = lng

                If Hocrxml.Attributes.Any(Function(X) X.Name.LocalName = "lang" AndAlso String.IsNullOrEmpty(X.Value) = False) Then
                    newocrWord.Lang = Hocrxml.Attributes.Where(Function(X) X.Name.LocalName = "lang").First.Value
                End If

            Else

                newocrWord = Nothing
            End If

        Else
            newocrWord = Nothing
        End If


        Return newocrWord


    End Function

    Private Shared Function ParseBBox(ByVal bboxstrg As String) As Rectangle

        Dim NewRectangle As Rectangle
        Dim Index = bboxstrg.IndexOf("bbox")

        If Index >= 0 Then

            bboxstrg = bboxstrg.Substring(Index)

            bboxstrg = bboxstrg.Replace("bbox", "")
            bboxstrg = bboxstrg.Replace(";", " ")
            Dim splts = bboxstrg.Split(" ")

            Dim cnt As Integer = 0

            NewRectangle = New Rectangle

            For Each Subsplit In splts

                If String.IsNullOrEmpty(Subsplit) = False AndAlso IsNumeric(Subsplit) = True Then

                    If cnt = 0 Then

                        NewRectangle.X = CInt(Subsplit)

                    ElseIf cnt = 1 Then

                        NewRectangle.Y = CInt(Subsplit)

                    ElseIf cnt = 2 Then

                        NewRectangle.Width = CInt(Subsplit)

                    ElseIf cnt = 3 Then

                        NewRectangle.Height = CInt(Subsplit)
                        cnt += 1
                        Exit For

                    End If

                    cnt += 1

                End If

            Next

            If cnt <> 4 Then

                NewRectangle = Nothing

            End If

        End If



        Return NewRectangle

    End Function


    Private Shared Function ParseBaseLine(ByVal Basestrg As String) As PointF

        Dim NewPointF As PointF
        Dim Index = Basestrg.IndexOf("baseline")

        If Index >= 0 Then

            Basestrg = Basestrg.Substring(Index)

            Basestrg = Basestrg.Replace("baseline", "")
            Basestrg = Basestrg.Replace(";", " ")
            Dim splts = Basestrg.Split(" ")

            Dim cnt As Integer = 0

            NewPointF = New PointF

            For Each Subsplit In splts

                If String.IsNullOrEmpty(Subsplit) = False AndAlso IsNumeric(Subsplit) = True Then

                    If cnt = 0 Then

                        NewPointF.X = CSng(Subsplit)

                    ElseIf cnt = 1 Then

                        NewPointF.Y = CSng(Subsplit)

                        cnt += 1
                        Exit For

                    End If

                    cnt += 1

                End If

            Next

            If cnt <> 2 Then

                NewPointF = Nothing

            End If

        End If



        Return NewPointF

    End Function


    Private Shared Function ParseParameter(ByVal paramName As String, ByVal paramString As String) As Single
        Dim value As Single = 0
        Dim Index = paramString.IndexOf(paramName)

        If Index >= 0 Then

            paramString = paramString.Substring(Index)

            paramString = paramString.Replace(paramName, "")
            paramString = paramString.Replace(";", " ")
            Dim splts = paramString.Split(" ")

            For Each Subsplit In splts

                If String.IsNullOrEmpty(Subsplit) = False AndAlso IsNumeric(Subsplit) = True Then
                    value = CSng(Subsplit)
                    Exit For
                End If

            Next

        End If



        Return value

    End Function

    Public Shared Function UpdateWordToLine(ByVal line As HocrLine) As HocrLine

        For cnt As Integer = 0 To line.AllocrWords.Count - 1
            Dim wrd = line.AllocrWords(cnt).XmlElement
            wrd.Value = line.AllocrWords(cnt).Text
            line.AllocrWords(cnt).XmlElement = wrd
        Next

        line.Text = String.Join(" ", line.AllocrWords.Select(Function(X) X.Text))

        Return line
    End Function

    Public Shared Function UpdateLineToParagraph(ByVal Para As HocrPar) As HocrPar

        Dim Lines = Para.AllocrLines.Select(Function(Y) Y.Text)

        Para.Text = String.Join(Environment.NewLine, Lines)

        Return Para

    End Function


    Public Shared Function UpdateWordToParagraph(ByVal Para As HocrPar) As HocrPar

        Dim Lines = Para.AllocrLines.Select(Function(Y) UpdateWordToLine(Y).Text)

        Para.Text = String.Join(Environment.NewLine, Lines)

        Return Para

    End Function


    Public Shared Function UpdateWordToPage(ByVal Page As HocrPage) As HocrPage

        Dim UTF8Text As String = ""

        For Each area In Page.AllocrCarea

            For Each Para In area.AllocrParas

                UTF8Text += Environment.NewLine

                Para = UpdateWordToParagraph(Para)
                Para = PostProcessor.Setalignment(Para)
                UTF8Text += Para.Text

                UTF8Text += Environment.NewLine

            Next

        Next

        Page.UTF8Text = UTF8Text

        Return Page

    End Function


    Public Shared Function UpdateLineToPage(ByVal Page As HocrPage) As HocrPage

        Dim UTF8Text As String = ""

        For Each area In Page.AllocrCarea

            For Each Para In area.AllocrParas

                UTF8Text += Environment.NewLine

                Para = UpdateLineToParagraph(Para)
                Para = PostProcessor.Setalignment(Para)
                UTF8Text += Para.Text

                UTF8Text += Environment.NewLine
            Next

        Next

        Page.UTF8Text = UTF8Text

        Return Page

    End Function

    Public Shared Function UpdateparagraphToPage(ByVal Page As HocrPage) As HocrPage




        Dim Parags = Page.AllocrCarea.Select(
            Function(X)
                Return String.Join(Environment.NewLine, X.AllocrParas.Select(Of String)(Function(Y) Y.Text))
            End Function)


        Page.UTF8Text = String.Join(Environment.NewLine, Parags)



        Return Page

    End Function

End Class


