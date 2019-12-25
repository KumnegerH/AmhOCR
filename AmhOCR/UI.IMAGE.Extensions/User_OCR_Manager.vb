Imports System.IO
Imports Ag = AForge.Imaging

Partial Class MainWindow


    Private BatchOCRprog As BatchProgressControl


    Private Sub RecognizeApage()

        If isBusy = False Then
            If EditorPicBox.Image IsNot Nothing Then

                If File.Exists(EditorPicBox.FileName) Then
                    RecognizeFile(EditorPicBox.FileName)
                End If

            End If
        End If

    End Sub

    Private Async Sub RecognizeFile(ByVal FileName As String)


        isBusy = True

        Dim NewPages As HocrPage

        ' Check if Previousely Recognized or not
        If isRecognizOpen = False Then

            OCRsettings.PageSegMode = PageSegMode.fullauto



            Dim RecoverImageNames As New List(Of String)
            Dim RecoverImageList As New List(Of Image)

            UndoType = New List(Of UndoType)
            RedoType = New List(Of UndoType)
            RedoImageList = New List(Of Image)
            RedoRotationData = New List(Of Double)
            UndoRotationData = New List(Of Double)


            If UndoImageList.Count > 1 Then
                UndoImageList.RemoveRange(1, UndoImageList.Count - 1)
                UndoType.Add(AmhOCR.UndoType.ImageSetting)
            End If


            btnUndo.Enabled = False
            btnRedo.Enabled = False
            btnSaveImage.Enabled = False

            btnSelectionBox.Enabled = False
            Dim PageNumber As Integer = HocrPages.Where(Function(X) X.ImageName = FileName).Single.PageNum
            NewPages = HocrPages(PageNumber)
            NewPages.PageOCRsettings.Language = OCRsettings.Language




            Dim prog As New ProgressReport
            prog.Size = New Size(364, 100)
            prog.Text = "Recognizing text from image"
            prog.lbltext = "Progress:   "
            prog.UpdateProgress("Pre-Processing")
            prog.StartPosition = FormStartPosition.Manual

            Try
                prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
            Catch ex As Exception
                prog.StartPosition = FormStartPosition.CenterParent
            End Try

            prog.ProgressBar1.Style = ProgressBarStyle.Marquee
            prog.Show(Me)

            prog.UpdateProgress("Pre-Processing")
            'All image's pre-porcess setting will be applied to this image  

            Dim tessImagePath As String = NewPages.imgCopyName

            If Not File.Exists(tessImagePath) Then
                Dim MainImage As Bitmap

                MainImage = ImageUtils.SafeOpenImage(FileName)
                MainImage = PreProcessor.ApplyCorrections(MainImage, NewPages.PageOCRsettings)
                MainImage.Save(tessImagePath)
                MainImage.Dispose()
                MainImage = Nothing

            Else

                If NewPages.ImageBlocks.Count > 0 Then

                    Dim RecoverImage = ImageUtils.SafeOpenImage(tessImagePath)
                    RecoverImageList.Add(Ag.Image.Clone(RecoverImage))
                    RecoverImageNames.Add(tessImagePath)

                    Using gr = Graphics.FromImage(RecoverImage)

                        For Each area In NewPages.ImageBlocks
                            gr.FillRectangle(Brushes.White, area)
                        Next

                    End Using


                    RecoverImage.Save(tessImagePath)
                    RecoverImage.Dispose()
                    RecoverImage = Nothing


                End If

            End If







            prog.UpdateProgress("Processing")
            NewPages = Await TessRecognize.AsyncRecognize(tessImagePath, NewPages)
            NewPages.ImageName = FileName
            NewPages.PageNum = PageNumber


            prog.UpdateProgress("Post-Processing")
            NewPages = Await PostProcessor.AsyncAnalyzepage(NewPages)

            HocrPages(PageNumber) = NewPages
            ListOpenedImages.Items.Item(FilePaths.IndexOf(FileName)).Checked = True


            prog.Dispose()
            prog = Nothing
            Await TaskEx.Delay(50)

            isProjectDirty = True


            For RecImg As Integer = 0 To RecoverImageNames.Count - 1
                RecoverImageList(RecImg).Save(RecoverImageNames(RecImg))
                RecoverImageList(RecImg).Dispose()
                RecoverImageList(RecImg) = Nothing
            Next

            RecoverImageList = Nothing
            RecoverImageNames = Nothing


        Else

            NewPages = HocrPages.Where(Function(X) X.ImageName = FileName).First
        End If


        If NewPages IsNot Nothing Then

            btnSelectionBox.Enabled = True

            btnSetting.Enabled = False
            btnCrop.Enabled = False
            btnDeskew.Enabled = False
            btnRotateLeft.Enabled = False
            btnRotateRight.Enabled = False
            OptionsToolStripMenuItem.Enabled = False
            DeskewToolStripMenuItem.Enabled = False

            btnUndo.Enabled = False
            btnRedo.Enabled = False


            If Me.WindowState <> FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Maximized
            End If


            If SplitInputResultView.Panel1Collapsed = True Then
                SplitInputResultView.Panel1Collapsed = False
                If btnTxtView.Checked = True Then
                    SplitTextResultView.SplitterDistance = (3 * SplitTextResultView.Height / 4)
                    SplitTextResultView.Panel2Collapsed = False
                Else
                    SplitTextResultView.Panel2Collapsed = True
                End If

            End If




            ' If btnImgTab.Visible = False Then
            ' ColapsImg()
            'End If

            MainMenuUserEditedToolStripMenuItem.Enabled = True
            MainMenuUserOrigialToolStripMenuItem.Enabled = True

            UserAreaEditedImageToolStripMenuItem.Enabled = True
            UserAreaOriginalAreaToolStripMenuItem.Enabled = True

            btnBackground.Text = "OCR Image Background"
            ResetImageBackgroundToolStripMenuItem.Text = "OCR Background View Mode"

            txtBoxResult.Font = OCRsettings.ocrFont.Clone
            txtBoxResult.Text = NewPages.UTF8Text
            HocrPicBox.FileName = EditorPicBox.FileName


            Using imgOp = Ag.Image.FromFile(NewPages.imgCopyName)
                HocrPicBox.Image = imgOp.Clone
            End Using

            HocrPicBox.MainImage = UndoImageList(0).Clone
            HocrPicBox.HocrPage = NewPages
            HocrPicBox.ImageAreas = NewPages.ImageBlocks.ToList
            EditorPicBox.HocrActive = True
            EditorPicBox.ZoomReset()
            HocrPicBox.ZoomReset()
            EditorPicBox.Invalidate()
            HocrPicBox.Invalidate()

            HocrPicBox.Select()
            HocrPicBox.Focus()
            isRecognizOpen = False

        End If


        isBusy = False

    End Sub

    Private Sub RecognizeBatch()

        Dim Unrecognized = ListOpenedImages.Items.OfType(Of ListViewItem).Where(Function(X) X.Checked = False)

        Dim files As New List(Of String)

        For Each unRecogs In Unrecognized
            files.Add(FilePaths(ListOpenedImages.Items.IndexOf(unRecogs)))
        Next

        If files.Count > 0 Then

            isBusy = True

            BatchOCRprog = New BatchProgressControl
            BatchOCRprog.StartPosition = FormStartPosition.Manual

            Try
                BatchOCRprog.Location = Me.PointToScreen(New Point((Me.Width - BatchOCRprog.Width) / 2, Me.Height / 5))
            Catch ex As Exception
                BatchOCRprog.StartPosition = FormStartPosition.CenterParent
            End Try

            BatchOCRprog.TotalTasks = files.Count

            If BatchOCRprog.TotalTasks > OCRsettings.MaxBatch Then
                BatchOCRprog.NumberOfProcess = OCRsettings.MaxBatch
            End If

            BatchOCRprog.SetProgressBar(files.Count)



            AddHandler BatchOCRprog.Shown,
                New EventHandler(
                Async Sub(s, e)

                    BatchOCRprog.lblStage.Text = "Initializing..."
                    BatchOCRprog.Invalidate()

                    Await TaskEx.Delay(5)

                    Dim GetBatChas = GetProgresGroup(files)

                    BatchOCRprog.lblStage.Text = "Recognizing..."
                    BatchOCRprog.UpdateProgressBar(0)
                    BatchOCRprog.Invalidate()
                    Await TaskEx.Delay(5)
                    BatchOCRprog.NumberOfProcess = GetBatChas.Count

                    For gr As Integer = 1 To GetBatChas.Count
                        RecognizeStepGroups(GetBatChas(gr - 1).ToArray, gr)
                    Next

                    BatchOCRprog.Invalidate()
                    Await TaskEx.Delay(5)
                End Sub)


            BatchOCRprog.Show(Me)

            ListOpenedImages.Items.Item(FilePaths.IndexOf(files.First)).Selected = True


        End If


    End Sub


    Private Async Sub RecognizeStepGroups(ByVal FileNames() As String, ByVal batch As Integer)

        OCRsettings.PageSegMode = PageSegMode.fullauto

        Dim RecoverImageNames As New List(Of String)
        Dim RecoverImageList As New List(Of Image)

        Dim tsk = TaskEx.Run(
              Sub()



                  For Each FileName In FileNames

                      If BatchOCRprog.IsPause = True Then
                          BatchOCRprog.PausedProcess += 1
                          If (BatchOCRprog.PausedProcess) >= BatchOCRprog.NumberOfProcess Then
                              BatchOCRprog.UpdateMainStatus(True)
                          End If

                          Do While BatchOCRprog.IsPause = True



                              If (BatchOCRprog.CancelRequested = True) OrElse (CancelRequested = True) Then
                                  Exit Do
                              End If

                          Loop

                          If BatchOCRprog.PausedProcess <> 0 Then
                              BatchOCRprog.PausedProcess = 0
                              BatchOCRprog.UpdateMainStatus(False)

                          End If


                      End If



                      If (BatchOCRprog.CancelRequested = True) OrElse (CancelRequested = True) Then
                          Exit For
                      End If

                      Dim PageIndex = HocrPages.Where(Function(X) X.ImageName = FileName).Single.PageNum

                      Dim NewPages = HocrPages(PageIndex)

                      NewPages.PageOCRsettings.Language = OCRsettings.Language
                      Dim tessImagePath As String = NewPages.imgCopyName


                      If Not File.Exists(tessImagePath) Then
                          Dim MainImage As Bitmap

                          MainImage = ImageUtils.SafeOpenImage(FileName)
                          MainImage = PreProcessor.ApplyCorrections(MainImage, NewPages.PageOCRsettings)
                          MainImage.Save(tessImagePath)
                          MainImage.Dispose()
                          MainImage = Nothing

                      Else

                          If NewPages.ImageBlocks.Count > 0 Then

                              Dim RecoverImage = ImageUtils.SafeOpenImage(tessImagePath)
                              RecoverImageList.Add(Ag.Image.Clone(RecoverImage))
                              RecoverImageNames.Add(tessImagePath)

                              Using gr = Graphics.FromImage(RecoverImage)

                                  For Each area In NewPages.ImageBlocks
                                      gr.FillRectangle(Brushes.White, area)
                                  Next

                              End Using


                              RecoverImage.Save(tessImagePath)
                              RecoverImage.Dispose()
                              RecoverImage = Nothing


                          End If

                      End If




                      NewPages = TessRecognize.Recognize(tessImagePath, NewPages)
                      NewPages.ImageName = FileName

                      NewPages = PostProcessor.Analyzepage(NewPages)

                      BatchOCRprog.CompetedTasks += 1
                      BatchOCRprog.UpdateProgressBar(BatchOCRprog.CompetedTasks)
                      BatchOCRprog.UpdateProgressText(BatchOCRprog.CompetedTasks)

                      HocrPages(PageIndex) = NewPages

                      isProjectDirty = True

                  Next

              End Sub)





        Await tsk


        For RecImg As Integer = 0 To RecoverImageNames.Count - 1
            RecoverImageList(RecImg).Save(RecoverImageNames(RecImg))
            RecoverImageList(RecImg).Dispose()
            RecoverImageList(RecImg) = Nothing
        Next

        RecoverImageList = Nothing
        RecoverImageNames = Nothing

        BatchOCRprog.CompletedProcess += 1

        If BatchOCRprog.CompletedProcess = BatchOCRprog.NumberOfProcess Then
            BatchOCRprog.IsPause = False
            BatchOCRprog.CancelRequested = False
            BatchOCRprog.Close()

            For Each apage In HocrPages
                If apage.Recognized = True Then

                    Try
                        ListOpenedImages.Items.Item(FilePaths.IndexOf(apage.ImageName)).Checked = True
                    Catch ex As Exception

                    End Try
                End If
            Next



            isBusy = False


            OpenImage()


        End If


    End Sub


    Private Function GetProgresGroup(ByVal files As List(Of String)) As List(Of List(Of String))

        Dim FileGroups As New List(Of List(Of String))
        For Each file In files
            Dim NewPages As HocrPage
            If HocrPages.Where(Function(X) X.ImageName = file).Count = 0 Then
                NewPages = New HocrPage
                NewPages.ImageName = file
                NewPages.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(file))
                NewPages.PageNum = HocrPages.Count
                HocrPages.Add(NewPages)
            End If
        Next


        If files.Count > OCRsettings.MaxBatch Then

            Dim cnt As Integer = Math.Floor(files.Count / OCRsettings.MaxBatch)


            Dim ttc As Integer = 0

            For grp As Integer = 1 To OCRsettings.MaxBatch
                Dim batch As New List(Of String)
                For iu As Integer = 0 To cnt - 1

                    If ttc < files.Count Then
                        batch.Add(files(ttc))
                    End If
                    ttc += 1

                Next



                If grp = OCRsettings.MaxBatch Then
                    ' Add the Remaining files to the last batch
                    For iu As Integer = ttc To files.Count - 1 Step 1
                        batch.Add(files(iu))
                    Next
                End If

                FileGroups.Add(batch)
            Next

        Else
            FileGroups.Add(files.ToList)
        End If


        Return FileGroups

    End Function

    Private Async Sub ReRecognizeBox(ByVal sender As Object, ByVal e As RecognizeAreaArg)


        isBusy = True

        OCRsettings.PageSegMode = e.pageMode

        Dim NewPages As HocrPage

        NewPages = New HocrPage
        NewPages.ImageName = e.filename
        NewPages.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(e.filename))


        NewPages.PageOCRsettings.Language = OCRsettings.Language

        Dim prog As New ProgressReport
        prog.Size = New Size(364, 100)
        prog.Text = "Re-recognizing text from image area"
        prog.lbltext = "Progress:   "
        prog.UpdateProgress("Pre-Processing")
        prog.StartPosition = FormStartPosition.Manual

        Try
            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try

        prog.ProgressBar1.Style = ProgressBarStyle.Marquee
        prog.Show(Me)

        'All image's pre-porcess setting will be applied to this image  

        Dim tessImagePath As String = NewPages.imgCopyName
        Dim MainImage As Bitmap
        Dim RecoverImage As Bitmap
        If File.Exists(tessImagePath) Then
            RecoverImage = Ag.Image.FromFile(tessImagePath)
        Else
            RecoverImage = Ag.Image.FromFile(e.filename)
        End If
        'RecoverImage.SetResolution(NewPages.PageOCRsettings.Resolution.Width, NewPages.PageOCRsettings.Resolution.Height)
        MainImage = HocrPicBox.CopyBoxImage(e.box)

        prog.UpdateProgress("Pre-Processing")
        MainImage = Await PreProcessor.AsyncApplyCorrections(MainImage)
        MainImage.Save(tessImagePath)
        MainImage.Dispose()
        MainImage = Nothing


        prog.UpdateProgress("Processing")
        NewPages = Await TessRecognize.AsyncRecognize(tessImagePath, NewPages)


        prog.UpdateProgress("Post-Processing")
        NewPages = Await PostProcessor.AsyncAnalyzepage(NewPages)

        RecoverImage.Save(tessImagePath)
        RecoverImage.Dispose()
        RecoverImage = Nothing


        prog.Dispose()
        prog = Nothing

        isProjectDirty = True


        If NewPages IsNot Nothing Then

            HocrPicBox.ApplyBoxEdit(e.BoxAreaID, NewPages.orignalText, True)

        End If

        NewPages = Nothing
        isBusy = False
        GC.Collect()
        HocrPicBox.Invalidate()

    End Sub

    Private Async Sub RecognizeNewBox(ByVal sender As Object, ByVal e As RecognizeAreaArg)


        isBusy = True

        OCRsettings.PageSegMode = e.pageMode


        Dim NewPages As New HocrPage
        NewPages.ImageName = e.filename
        NewPages.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(e.filename))

        NewPages.PageOCRsettings.Language = OCRsettings.Language

        Dim oldPages = HocrPages.Where(Function(X) X.ImageName = e.filename).Single
        Dim PageNumber As Integer = HocrPages.IndexOf(oldPages)
        oldPages.PageOCRsettings.Language = OCRsettings.Language
        oldPages.SetSettings()

        Dim prog As New ProgressReport
        prog.Size = New Size(364, 100)
        prog.Text = "Recognizing text from Box area"
        prog.lbltext = "Progress:   "
        prog.UpdateProgress("Pre-Processing")
        prog.StartPosition = FormStartPosition.Manual

        Try
            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try

        prog.ProgressBar1.Style = ProgressBarStyle.Marquee
        prog.Show(Me)

        'All image's pre-porcess setting will be applied to this image  

        Dim tessImagePath As String = NewPages.imgCopyName
        Dim MainImage As Bitmap
        Dim RecoverImage As Bitmap

        If File.Exists(tessImagePath) Then
            RecoverImage = Ag.Image.FromFile(tessImagePath)
        Else
            RecoverImage = Ag.Image.FromFile(e.filename)
        End If

        'RecoverImage.SetResolution(NewPages.PageOCRsettings.Resolution.Width, NewPages.PageOCRsettings.Resolution.Height)

        MainImage = EditorPicBox.CopyBoxImage(e.box, New Rectangle(0, 0, RecoverImage.Width, RecoverImage.Height))


        prog.UpdateProgress("Pre-Processing")
        MainImage = Await PreProcessor.AsyncApplyCorrections(MainImage)

        MainImage.Save(tessImagePath)
        MainImage.Dispose()
        MainImage = Nothing


        prog.UpdateProgress("Processing")
        NewPages = Await TessRecognize.AsyncXMLRecognize(tessImagePath, NewPages)
        NewPages.ImageName = e.filename

        prog.UpdateProgress("Post-Processing Text")

        If NewPages IsNot Nothing Then


            If oldPages.Recognized Then

                Dim AllboxAreas = oldPages.AllocrCarea.Select(Function(X) X.bbox).ToList
                AllboxAreas.Add(e.box)

                AllboxAreas = AllboxAreas.OrderBy(Function(X) X.Y).ToList
                Dim areaIndx = AllboxAreas.IndexOf(e.box)

                Dim OLDhoxrxml = oldPages.HocrXML
                Dim OLDBody = OLDhoxrxml.Elements.Single(Function(X) X.Name.LocalName = "body")
                Dim OLDpg = OLDBody.Elements.First
                Dim CopyOLD As New XElement(OLDpg)

                OLDpg.Elements.Remove

                Dim hoxrxml = NewPages.HocrXML
                Dim Body = hoxrxml.Elements.Single(Function(X) X.Name.LocalName = "body")
                Dim pg = Body.Elements.First

                Dim cnt As Integer = 0

                For Each area In CopyOLD.Elements
                    If areaIndx > cnt Then
                        Dim XmlArea As New XElement(area)
                        OLDpg.Add(XmlArea)
                    Else
                        Exit For
                    End If
                    cnt += 1
                Next


                For Each area In pg.Elements
                    Dim XmlArea As New XElement(area)
                    OLDpg.Add(XmlArea)
                Next

                cnt = 0

                For Each area In CopyOLD.Elements
                    If areaIndx <= cnt Then
                        Dim XmlArea As New XElement(area)
                        OLDpg.Add(XmlArea)
                    End If

                    cnt += 1
                Next


            Else

                oldPages = NewPages

            End If

            oldPages.AllocrCarea = New List(Of HocrCarea)
            oldPages = Await TessRecognize.AsyncParseHocr(oldPages)

            prog.UpdateProgress("Post-Processing Text")
            oldPages = Await PostProcessor.AsyncAnalyzepage(oldPages)

            RecoverImage.Save(tessImagePath)
            RecoverImage.Dispose()
            RecoverImage = Nothing



            oldPages.PageNum = PageNumber




            isProjectDirty = True



            oldPages.Recognized = True
            HocrPages(oldPages.PageNum) = oldPages
            ListOpenedImages.Items.Item(FilePaths.IndexOf(e.filename)).Checked = True
            ListOpenedImages.Items.Item(FilePaths.IndexOf(e.filename)).Selected = True



        End If



        prog.Dispose()
        prog = Nothing


        oldPages = Nothing
        NewPages = Nothing
        isBusy = False

        OpenImage()

        GC.Collect()
    End Sub

    Private Sub RemoveHocrElement(ByVal sender As Object, ByVal e As RemoveOCRobjectArg)

        isBusy = True

        Dim obj = HocrPicBox.HotHocrObjects(e.HocrID)
        Dim EdMode = obj.EditMode

        If EdMode = ocrEditMode.WordEdit Then

            Dim oldPages = HocrPages.Where(Function(X) X.ImageName = e.filename).Single
            Dim PageNumber As Integer = HocrPages.IndexOf(oldPages)
            Dim hoxrxml = oldPages.HocrXML
            Dim Body = hoxrxml.Elements.Single(Function(X) X.Name.LocalName = "body")
            Dim pgXML = Body.Elements.First
            Dim HOCRobj = CType(obj.HocrObject, HocrWord)
            Dim ParagXML = pgXML.Elements.ElementAt(HOCRobj.AreaNum).Elements.ElementAt(HOCRobj.ParNum)
            Dim lineXML = ParagXML.Elements.ElementAt(HOCRobj.lineNum)
            Dim wordXML = lineXML.Elements.ElementAt(HOCRobj.WordNum)
            wordXML.Remove()


            oldPages.AllocrCarea(HOCRobj.AreaNum).
                     AllocrParas(HOCRobj.ParNum).
                     AllocrLines(HOCRobj.lineNum).
                     AllocrWords.RemoveAt(HOCRobj.WordNum)



            HocrPages(PageNumber) = oldPages

        ElseIf EdMode = ocrEditMode.LineEdit Then

            Dim oldPages = HocrPages.Where(Function(X) X.ImageName = e.filename).Single
            Dim PageNumber As Integer = HocrPages.IndexOf(oldPages)
            Dim hoxrxml = oldPages.HocrXML
            Dim Body = hoxrxml.Elements.Single(Function(X) X.Name.LocalName = "body")
            Dim pgXML = Body.Elements.First
            Dim HOCRobj = CType(obj.HocrObject, HocrLine)
            Dim ParagXML = pgXML.Elements.ElementAt(HOCRobj.AreaNum).Elements.ElementAt(HOCRobj.ParNum)
            Dim lineXML = ParagXML.Elements.ElementAt(HOCRobj.LineNum)
            lineXML.Remove()

            oldPages.AllocrCarea(HOCRobj.AreaNum).
                     AllocrParas(HOCRobj.ParNum).
                     AllocrLines.RemoveAt(HOCRobj.LineNum)




            HocrPages(PageNumber) = oldPages

        ElseIf EdMode = ocrEditMode.ParagraphEdit Then
            Dim HOCRobj = CType(obj.HocrObject, HocrPar)
            Dim Arrnu As Integer = HOCRobj.AreaNum
            Dim Parnu As Integer = HOCRobj.ParNum

            Dim oldPages = HocrPages.Where(Function(X) X.ImageName = e.filename).Single
            Dim PageNumber As Integer = HocrPages.IndexOf(oldPages)
            Dim hoxrxml = oldPages.HocrXML

            Dim Body = hoxrxml.Elements.Single(Function(X) X.Name.LocalName = "body").Elements.First.
                       Elements.ElementAt(Arrnu).
                       Elements.ElementAt(Parnu)




            Body.Remove()


            oldPages.AllocrCarea(HOCRobj.AreaNum).
                     AllocrParas.RemoveAt(HOCRobj.ParNum)



            HocrPages(PageNumber) = oldPages



        End If


        HocrPicBox.OCRblocks.Clear()
        HocrPicBox.HotHocrObjects.RemoveAt(e.HocrID)
        isBusy = False

        OCRTreeView.SelectedNode = Nothing
        OCRTreeView.Nodes(1).Nodes(e.HocrID).Remove()
        RefreshOCRpage(e.filename, EdMode)


    End Sub


    Private Sub RefreshOCRpage(ByVal filename As String, ByVal EdMode As ocrEditMode)

        Dim oldPages = HocrPages.Where(Function(X) X.ImageName = filename).Single
        Dim pageNumber As Integer = HocrPages.IndexOf(oldPages)

        Dim areas = oldPages.AllocrCarea
        Dim ObjCnt As Integer = 0

        Dim ParagraphIndex As Integer = 0
        Dim LineIndex As Integer = 0
        Dim WordIndex As Integer = 0

        For ar As Integer = 0 To areas.Count - 1
            Dim area = areas(ar)

            Dim Pars = area.AllocrParas


            For pr As Integer = 0 To Pars.Count - 1
                Dim ParagBoxs As New List(Of Rectangle)

                Dim Par = Pars(pr)
                Par.AreaNum = ar
                Par.ParNum = pr

                Dim lins = Par.AllocrLines

                For ln As Integer = 0 To lins.Count - 1
                    Dim wordBoxes As New List(Of Rectangle)

                    Dim lin = lins(ln)
                    lin.AreaNum = ar
                    lin.ParNum = pr
                    lin.LineNum = ln

                    Dim wrds = lin.AllocrWords

                    For wd As Integer = 0 To wrds.Count - 1

                        Dim wrd = wrds(wd)
                        wrd.AreaNum = ar
                        wrd.ParNum = pr
                        wrd.lineNum = ln
                        wrd.WordNum = wd
                        wordBoxes.Add(wrd.bbox)
                        wrds(wd) = wrd
                        If EdMode = ocrEditMode.WordEdit Then

                            Dim HotHocr = HocrPicBox.HotHocrObjects(ObjCnt)
                            HotHocr.ParagraphIndex = ParagraphIndex
                            HotHocr.LineIndex = LineIndex
                            HotHocr.WordIndex = WordIndex
                            HocrPicBox.HotHocrObjects(ObjCnt) = HotHocr

                            ObjCnt += 1
                        End If

                        WordIndex += 1
                    Next

                    Dim linbbox = lin.bbox

                    linbbox.Width = 0
                    linbbox.Height = 0


                    If wordBoxes.Count > 0 Then
                        linbbox = MathHelp.RectanglesUnion(wordBoxes)
                        ParagBoxs.Add(linbbox)
                    End If

                    lin.bbox = linbbox
                    lin.AllocrWords = wrds

                    lins(ln) = lin


                    If EdMode = ocrEditMode.LineEdit Then

                        Dim HotHocr = HocrPicBox.HotHocrObjects(ObjCnt)
                        HotHocr.ParagraphIndex = ParagraphIndex
                        HotHocr.LineIndex = LineIndex

                        HocrPicBox.HotHocrObjects(ObjCnt) = HotHocr

                        ObjCnt += 1
                    End If

                    LineIndex += 1
                Next


                Par.AllocrLines = lins

                Dim parbbox = Par.bbox

                parbbox.Width = 0
                parbbox.Height = 0


                If ParagBoxs.Count > 0 Then

                    parbbox = MathHelp.RectanglesUnion(ParagBoxs)

                End If

                Par.bbox = parbbox

                HocrPicBox.OCRblocks.Add(parbbox)

                Pars(pr) = Par

                If EdMode = ocrEditMode.ParagraphEdit Then

                    Dim HotHocr = HocrPicBox.HotHocrObjects(ObjCnt)
                    HotHocr.ParagraphIndex = ParagraphIndex
                    HotHocr.LineIndex = LineIndex
                    HocrPicBox.HotHocrObjects(ObjCnt) = HotHocr

                    ObjCnt += 1
                End If

                ParagraphIndex += 1
            Next

            area.AllocrParas = Pars

            areas(ar) = area

        Next

        oldPages.AllocrCarea = areas
        oldPages = HocrParser.UpdateWordToPage(oldPages)

        HocrPicBox._HocrPage = oldPages
        HocrPages(pageNumber) = oldPages

        txtBoxResult.Text = oldPages.UTF8Text

        HocrPicBox.Invalidate()


    End Sub

    Private Async Sub InvalidateOCRpage(ByVal filename As String)


        isBusy = True
        Dim prog As New ProgressReport
        prog.Size = New Size(364, 100)
        prog.Text = "Removing Object from OCR Page"
        prog.lbltext = "Progress:   "
        prog.UpdateProgress("Processing...")
        prog.StartPosition = FormStartPosition.Manual
        HocrPicBox.isBusy = True
        Try
            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try

        prog.ProgressBar1.Style = ProgressBarStyle.Marquee
        prog.Show(Me)

        Dim oldPages = HocrPages.Where(Function(X) X.ImageName = filename).Single
        Dim PageNumber As Integer = HocrPages.IndexOf(oldPages)
        oldPages.SetSettings()

        oldPages.AllocrCarea = New List(Of HocrCarea)
        oldPages = Await TessRecognize.AsyncParseHocr(oldPages)

        oldPages = Await PostProcessor.AsyncAnalyzepage(oldPages)
        oldPages.ImageName = filename
        oldPages.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(filename))
        oldPages.Recognized = True
        HocrPages(oldPages.PageNum) = oldPages


        isBusy = False
        prog.Dispose()
        prog = Nothing
        HocrPicBox.isBusy = False
        OpenImage()

        GC.Collect()

    End Sub






    Private Sub ResetImageRecognition()

        If ListOpenedImages.SelectedIndices.Count > 0 Then
            Dim imgMame = FilePaths(ListOpenedImages.SelectedIndices(0))
            HocrReset(imgMame)
        End If


    End Sub

    Private Sub HocrReset(ByVal imgMame As String)

        Dim imgIndex = FilePaths.IndexOf(imgMame)

        If imgIndex >= 0 Then
            If HocrPages.Any(Function(X) X.ImageName = imgMame) Then
                isRecognizOpen = False
                Dim HocrIdex = HocrPages.IndexOf(HocrPages.Single(Function(X) X.ImageName = imgMame))


                If HocrPicBox.Image IsNot Nothing Then
                    HocrPicBox.HocrActive = False
                    HocrPicBox.DisposeImage()
                    HocrPicBox.ResetAllState()
                End If

                If EditorPicBox.Image IsNot Nothing Then
                    EditorPicBox.HocrActive = False
                    EditorPicBox.DisposeImage()
                    EditorPicBox.ResetAllState()
                    EditorPicBox.Focus()
                End If

                Dim thisHocrPage = New HocrPage
                thisHocrPage.Recognized = False
                thisHocrPage.ImageName = imgMame
                thisHocrPage.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(imgMame))
                thisHocrPage.PageNum = HocrIdex
                thisHocrPage.PageOCRsettings.ResetSetting()

                If File.Exists(thisHocrPage.imgCopyName) Then
                    Try
                        File.Delete(thisHocrPage.imgCopyName)
                    Catch ex As Exception

                    End Try

                End If


                isBusy = True
                ListOpenedImages.Items(imgIndex).Selected = True
                ListOpenedImages.Items(imgIndex).Checked = False

                isBusy = False

                HocrPages(HocrIdex) = thisHocrPage
                OpenImage()

            End If


        End If

    End Sub

    Public Async Sub HocrEdited(ByVal sender As Object, ByVal e As EventArgs)
        isBusy = True
        If sender IsNot Nothing Then
            Try

                Dim pg As Integer = HocrPicBox.HocrPage.PageNum
                Dim HocrPag = HocrPages(pg)


                Dim tsk = TaskEx.Run(
                        Sub()

                            If CType(sender, Integer) = ocrEditMode.ParagraphEdit Then

                                HocrPag = HocrParser.UpdateparagraphToPage(HocrPag)

                            ElseIf CType(sender, Integer) = ocrEditMode.LineEdit Then

                                HocrPag = HocrParser.UpdateLineToPage(HocrPag)

                            ElseIf CType(sender, Integer) = ocrEditMode.WordEdit Then

                                HocrPag = HocrParser.UpdateWordToPage(HocrPag)

                            End If


                        End Sub)



                Await tsk

                isProjectDirty = True
                HocrPages(pg) = HocrPag
                txtBoxResult.Text = HocrPag.UTF8Text

            Catch ex As Exception

            End Try

        End If

        isBusy = False
    End Sub




End Class
