
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Imports System.Drawing.Drawing2D
Imports System.Linq

Public Class PostProcessor

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3


    ''' <summary>
    ''' Set text properties for paragraph 
    ''' </summary>
    ''' <param name="HocrPages">Pages to process</param>
    Public Shared Async Function DefineAllFormats(ByVal HocrPages As List(Of HocrPage)) As Task(Of List(Of HocrPage))

        For pgs As Integer = 0 To HocrPages.Count - 1

            Dim NewPages = HocrPages(pgs)

            Await Analyzepage(NewPages)


            HocrPages(pgs) = NewPages
        Next


        Return HocrPages

    End Function

    Public Shared Async Function Analyzepage(ByVal NewPages As HocrPage) As Task(Of HocrPage)

        Dim Tsk = TaskEx.Run(
            Sub()
                NewPages.ocrpagemargin.Top = NewPages.bbox.Height
                NewPages.ocrpagemargin.Bottom = 0

                NewPages.ocrpagemargin.Left = NewPages.bbox.Right
                NewPages.ocrpagemargin.Right = 0



                For cra As Integer = 0 To NewPages.AllocrCarea.Count - 1

                    Dim areabx = NewPages.AllocrCarea(cra)
                    If NewPages.ocrpagemargin.Top > areabx.bbox.Top Then
                        NewPages.ocrpagemargin.Top = areabx.bbox.Top
                    End If

                    If NewPages.ocrpagemargin.Bottom < areabx.bbox.Bottom Then
                        NewPages.ocrpagemargin.Bottom = areabx.bbox.Bottom
                    End If

                    If NewPages.ocrpagemargin.Left > areabx.bbox.Left Then
                        NewPages.ocrpagemargin.Left = areabx.bbox.Left
                    End If

                    If NewPages.ocrpagemargin.Right < areabx.bbox.Right Then
                        NewPages.ocrpagemargin.Right = areabx.bbox.Right
                    End If



                    For para As Integer = 0 To areabx.AllocrParas.Count - 1

                        Dim Parabx = areabx.AllocrParas(para)

                        Parabx.AreaNum = cra
                        Parabx.Font = CheckForFont(Parabx)
                        Parabx.FontSize = Parabx.Font.Size

                        Parabx = Setalignment(Parabx)
                        NewPages.AllocrCarea(cra) = areabx

                    Next



                Next


                NewPages.ocrpagemargin.Right = NewPages.bbox.Right - NewPages.ocrpagemargin.Right
                NewPages.ocrpagemargin.Bottom = NewPages.bbox.Height - NewPages.ocrpagemargin.Bottom
            End Sub)





        Await Tsk

        Return NewPages


    End Function


    ''' <summary>
    ''' Re-estimate font size  
    ''' </summary>
    ''' <param name="Parabx">Paragrah hocr</param>
    ''' <returns></returns>

    Private Shared Function CheckForFont(ByRef Parabx As HocrPar) As Font

        Dim x_size = Parabx.FontSize
        OCRsettings.SetFont(Parabx.Lang)
        Dim fn As Font = OCRsettings.ocrFont.Clone
        Dim ZallAverage As New List(Of Single)
        If String.IsNullOrEmpty(Parabx.Text) = False Then



            x_size = Parabx.AllocrLines.Max(Function(X) X.x_size)

            fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)

            Using gPatha As New GraphicsPath

                gPatha.AddString(Parabx.Text, fn.FontFamily, 0, fn.Size, New Point(0, 0), Parabx.StringFormat)

                Dim sizeTest = gPatha.GetBounds.Size
                Dim Differ = New PointF(Math.Abs(sizeTest.Width - Parabx.bbox.Width), Math.Abs(sizeTest.Height - Parabx.bbox.Height))

                Dim CheckInterval As Single = 0.1

                If Differ.X > Differ.Y Then
                    CheckInterval = Differ.Y / 20
                Else
                    CheckInterval = Differ.X / 20
                End If
                If CheckInterval > (x_size * 0.05) Then
                    CheckInterval = x_size * 0.05
                End If

                If CheckInterval > 0.0001 Then


                    If (sizeTest.Width > Parabx.bbox.Width) OrElse (sizeTest.Height > Parabx.bbox.Height) Then
                        Do While ((sizeTest.Width > Parabx.bbox.Width) OrElse (sizeTest.Height > Parabx.bbox.Height)) AndAlso (x_size > 1)

                            gPatha.Reset()
                            x_size -= CheckInterval

                            fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)
                            gPatha.AddString(Parabx.Text, fn.FontFamily, 0, fn.Size, New Point(0, 0), Parabx.StringFormat)
                            sizeTest = gPatha.GetBounds.Size

                        Loop
                    Else

                        Do While ((sizeTest.Width < Parabx.bbox.Width) AndAlso (sizeTest.Height < Parabx.bbox.Height))

                            gPatha.Reset()
                            x_size += CheckInterval

                            fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)

                            gPatha.AddString(Parabx.Text, fn.FontFamily, 0, fn.Size, New Point(0, 0), Parabx.StringFormat)
                            sizeTest = gPatha.GetBounds.Size

                        Loop

                    End If

                End If


            End Using


        End If




        Return fn

    End Function


    ''' <summary>
    ''' Check for number of column 
    ''' </summary>
    ''' <param name="HocrPages">hocr pages</param>
    Private Overloads Shared Sub CheckForColumn(ByRef HocrPages As List(Of HocrPage))


        For pgs As Integer = 0 To HocrPages.Count - 1
            Dim Hpage = HocrPages(pgs)
            CheckForColumn(Hpage)
        Next

    End Sub

    Private Overloads Shared Sub CheckForColumn(ByRef HocrPages As HocrPage)



        For ar As Integer = 0 To HocrPages.AllocrCarea.Count - 1
            Dim area = HocrPages.AllocrCarea(ar)
            For pr As Integer = 0 To area.AllocrParas.Count - 1

                Dim para = area.AllocrParas(pr)



            Next

            HocrPages.AllocrCarea(ar) = area
        Next


    End Sub

    ''' <summary>
    ''' Check for number of Tabels
    ''' </summary>
    ''' <param name="HocrPages">hocr pages</param>
    Private Shared Sub CheckForTabel(ByRef HocrPages As List(Of HocrPage))



    End Sub



    ''' <summary>
    ''' Set paragraph's horizontal alignment /word spacing and sentence position / based on hocr word box and vertical spacing /line spacing/ based on hocr line box  
    ''' </summary>
    ''' <param name="Parabx">The paragraph to be processed</param>
    Public Shared Function Setalignment(ByRef Parabx As HocrPar) As HocrPar


        CheckForAlignment(Parabx)

        If Parabx.FontSize > 0 AndAlso Parabx.Alignment = ParAlignment.Center Then



            Dim ProcesedString = ""
            Using txtBox = New TextBox

                txtBox.Size = Parabx.bbox.Size
                txtBox.Location = New Point(0, 0)
                txtBox.Font = Parabx.Font.Clone
                txtBox.Text = ""
                txtBox.WordWrap = False
                txtBox.Multiline = True
                txtBox.BorderStyle = BorderStyle.None
                txtBox.Padding = New Padding(0)
                txtBox.Margin = New Padding(0)

                Dim alalLines As New List(Of String)
                Dim ParagraX As Integer = Parabx.bbox.X
                Dim ParagraY As Integer = Parabx.bbox.Y
                Dim prssLine As String = ""
                ProcesedString += prssLine
                Dim Posi As Integer = 0
                Dim NwWordStarPo As Integer = 0
                Dim NwWordEndPo As Integer = 0
                For lin As Integer = 0 To Parabx.AllocrLines.Count - 1

                    ProcesedString = String.Join(Environment.NewLine, alalLines)
                    Dim EnTstring = ProcesedString
                    prssLine = ""

                    For WRD As Integer = 0 To Parabx.AllocrLines(lin).AllocrWords.Count - 1

                        Dim zwrd = Parabx.AllocrLines(lin).AllocrWords(WRD).Text
                        NwWordStarPo = Parabx.AllocrLines(lin).AllocrWords(WRD).bbox.X - ParagraX
                        NwWordEndPo = Parabx.AllocrLines(lin).AllocrWords(WRD).bbox.Right - ParagraX

                        txtBox.Text = prssLine + " "
                        Posi = 0
                        Posi = txtBox.GetPositionFromCharIndex(txtBox.Text.Count - 1).X

                        txtBox.Text = prssLine + " " + Parabx.AllocrLines(lin).AllocrWords(WRD).Text
                        Dim PosiEnd = txtBox.GetPositionFromCharIndex(txtBox.Text.Count - 1).X
                        Do While (NwWordStarPo > Posi) AndAlso (NwWordEndPo > PosiEnd)

                            prssLine += " "
                            txtBox.Text = prssLine + " "

                            Posi = txtBox.GetPositionFromCharIndex(txtBox.Text.Count - 1).X
                            txtBox.Text = prssLine + " " + Parabx.AllocrLines(lin).AllocrWords(WRD).Text
                            PosiEnd = txtBox.GetPositionFromCharIndex(txtBox.Text.Count - 1).X


                        Loop

                        prssLine += Parabx.AllocrLines(lin).AllocrWords(WRD).Text + " "


                    Next


                    ProcesedString += Environment.NewLine + Environment.NewLine
                    ProcesedString += " "
                    txtBox.Text = ProcesedString


                    Dim CntNe As Integer = -1
                    NwWordStarPo = Parabx.AllocrLines(lin).AllocrWords.First.bbox.Y - ParagraY
                    Posi = txtBox.GetPositionFromCharIndex(ProcesedString.Count - 1).Y
                    Do While NwWordStarPo > Posi
                        CntNe += 1
                        ProcesedString += Environment.NewLine + " "
                        txtBox.Text = ProcesedString
                        Posi = txtBox.GetPositionFromCharIndex(ProcesedString.Count - 1).Y

                    Loop

                    EnTstring = ""
                    For uiy As Integer = 0 To CntNe
                        EnTstring += Environment.NewLine

                    Next

                    EnTstring += prssLine

                    alalLines.Add(EnTstring)
                Next
                ProcesedString = String.Join(Environment.NewLine, alalLines)

                Parabx.Text = ProcesedString

            End Using



        End If
        Return Parabx
    End Function


    Public Shared Sub SetalignmentOLD(ByRef Parabx As HocrPar)


        CheckForAlignment(Parabx)

        If Parabx.FontSize > 0 AndAlso Parabx.Alignment = StringAlignment.Center Then



            Dim ProcesedString = ""
            Dim Txt = Parabx.Text.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            For lin As Integer = 0 To Txt.Count - 2

                Dim line = Txt(lin)

                Dim Orignal As String = line
                Dim Spased = line

                If (String.IsNullOrEmpty(line) = False) Then


                    Dim meser = TextRenderer.MeasureText(Spased + " ", Parabx.Font, Parabx.bbox.Size, TextFormatFlags.Default)

                    Do While (meser.Width < Parabx.bbox.Width)
                        Spased += " "
                        meser = TextRenderer.MeasureText(Spased + " ", Parabx.Font, Parabx.bbox.Size, TextFormatFlags.Default)

                    Loop

                End If

                Dim Numword = Orignal.Split(" ").Where(Function(X) X.Replace(" ", "").Length > 0)

                If Numword.Count <> 0 Then

                    Dim newStrings = Numword.ToArray
                    Dim numOfSpaces = Spased.Length
                    Spased = String.Join("", Numword)

                    numOfSpaces = numOfSpaces - Spased.Length

                    Do Until numOfSpaces <= 0

                        For iu As Integer = 0 To newStrings.Count - 2
                            Dim wrd = newStrings(iu)
                            If numOfSpaces > 0 Then
                                wrd += " "
                                newStrings(iu) = wrd
                                numOfSpaces -= 1
                            Else
                                Exit For
                            End If
                        Next

                    Loop


                    Orignal = String.Join("", newStrings)

                End If



                ProcesedString += Orignal + vbNewLine

            Next

            ProcesedString += Txt.Last
            Parabx.Text = ProcesedString

        End If

    End Sub

    ''' <summary>
    ''' This will check the alignment/ left or right or justified=default of the paragraph from input image. Not yet implemented 
    ''' </summary>
    ''' <param name="Parabx"></param>
    Private Shared Sub CheckForAlignment(ByRef Parabx As HocrPar)


        'Not yet implemented 


    End Sub


    Public Sub CheckForImage()



    End Sub

    ''' <summary>
    ''' Groups different Hocr carea /column areas/ into a column area as long as page height, if available
    ''' </summary>
    ''' <param name="pagex">Page to be simplified</param>
    Public Shared Sub SimplifyHocrPage(ByRef pagex As HocrPage)

        ' Simplify hocr structure of the page based on optimized column area


    End Sub


    ''' <summary>
    ''' Determine the maximum and average number of column in the recognized page based on the horizontal line intersection test with hocr's column area box
    ''' </summary>
    ''' <param name="pagex">The recognized page </param>
    ''' <param name="confidLevel">The confidence level,%, to filter exterme value which might occure due to noise ocr recognition error </param>
    ''' <returns>Point, x=maximum column, y average column number</returns>
    Public Shared Function ColumnTest_Horizontal(ByRef pagex As HocrPage, ByVal confidLevel As Integer) As PointF


        Dim AvrgMaxColumn As New PointF(0, 0)
        Dim pageHeight = pagex.bbox.Height - 2
        Dim pageWidth = pagex.bbox.Width

        Dim ExitDo As Boolean = False
        Dim Columns As New List(Of Integer)


        Dim FirstRec = From para In pagex.AllocrCarea
                       Select para
                       Order By para.bbox.Y Ascending, para.bbox.X Ascending


        Dim NwPosition As Integer = FirstRec.First.bbox.Y + 1


        Dim Lines(1) As Point
        Lines(0) = New Point(0, NwPosition)
        Lines(1) = New Point(pageWidth, NwPosition)

        Do



            Dim Recxs = From para In pagex.AllocrCarea
                        Where ((para.bbox.Y < NwPosition) AndAlso (para.bbox.Bottom >= NwPosition)) AndAlso (MathHelp.isIntersect(para.bbox, Lines) = True)
                        Select para.areaNum



            If Recxs.Count > 0 Then

                Columns.Add(Recxs.Count)

            End If


            NwPosition += 2


            Lines(0).Y = NwPosition
            Lines(1).Y = NwPosition



            If (NwPosition >= pageHeight) Then

                ExitDo = True

            End If


        Loop While ExitDo = False


        If Columns.Count > 0 Then
            AvrgMaxColumn = New PointF(MathHelp.MaxVal_ConfidenceLevel(95, Columns), Columns.Average)
        End If


        Return AvrgMaxColumn

    End Function

    ''' <summary>
    '''  Determine the probability of a location as being a location of column devider on the recognized page based on vertical line intersection test with hoct carea
    ''' </summary>
    ''' <param name="pagex">The recognized page</param>
    ''' <returns>list point, x=x coordinate, y=pobability of a line being a column devider location</returns>
    Public Shared Function ColumnTest_Vertical(ByRef pagex As HocrPage) As List(Of PointF)



        Dim pageHeight = pagex.bbox.Height
        Dim pageWidth = pagex.bbox.Width

        Dim ExitDo As Boolean = False
        Dim Columns As New List(Of PointF)
        Dim PrevRecogs As New List(Of Integer)

        Dim FirstRec = From para In pagex.AllocrCarea
                       Select para
                       Order By para.bbox.X Ascending


        Dim NwPosition As Integer = FirstRec.First.bbox.X

        Dim LastRec = From para In pagex.AllocrCarea
                      Select para
                      Order By para.bbox.Right Descending



        pageWidth = LastRec.First.bbox.Right
        Columns.Add(New PointF(NwPosition, 100))

        NwPosition += 2
        pageWidth += 2

        Dim Lines(1) As Point
        Lines(0) = New Point(NwPosition, 0)
        Lines(1) = New Point(NwPosition, pageHeight)

        Dim PrevCnt As Integer = -1
        Dim runnningProb As Single = 100

        Do

            Dim Recxs = From para In pagex.AllocrCarea
                        Where ((para.bbox.X < NwPosition) AndAlso (NwPosition <= para.bbox.Right))
                        Select heights = para.bbox.Height, ids = para.areaNum


            If Recxs.Count > 0 Then

                Dim listIds As New List(Of Integer)
                listIds = Recxs.Select(Function(h) h.ids).ToList

                If PrevRecogs.Where(Function(X) listIds.Contains(X)).Count < PrevRecogs.Count Then


                    Dim probab As Single = (1 - (Recxs.Select(Function(h) h.heights).Sum / pageHeight)) * 100

                    PrevCnt = 0
                    Columns.Add(New PointF(NwPosition, probab))

                    runnningProb = probab

                Else

                    If PrevCnt >= 0 Then
                        PrevCnt += 1
                    End If

                End If

                PrevRecogs = listIds.ToList
            End If


            NwPosition += 2

            Lines(0).X = NwPosition
            Lines(1).X = NwPosition



            If (NwPosition >= pageWidth) Then

                ExitDo = True

            End If


        Loop While ExitDo = False


        PrevRecogs = Nothing
        Return Columns


    End Function



End Class
