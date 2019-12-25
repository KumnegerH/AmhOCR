Imports System.IO
Imports Ag = AForge.Imaging

Partial Class MainWindow


    ''' <summary>
    ''' Open listview's selected image in imageviewcontrol
    ''' </summary>
    Private Sub OpenImage()


        If isBusy = False AndAlso HocrPicBox.isBusy = False Then

            If (ListOpenedImages.SelectedIndices.Count > 0) Then

                Dim indx = ListOpenedImages.SelectedIndices(0)
                Dim FileName = FilePaths(indx)

                UndoType = New List(Of UndoType)
                RedoType = New List(Of UndoType)
                UndoImageList = New List(Of Image)
                RedoImageList = New List(Of Image)
                UndoRotationData = New List(Of Double)
                RedoRotationData = New List(Of Double)
                btnUndo.Enabled = False
                btnRedo.Enabled = False

                btnSaveImage.Enabled = False


                btnCrop.Enabled = False
                btnSelectionBox.Enabled = False

                btnSetting.Enabled = True
                btnDeskew.Enabled = True
                btnRotateLeft.Enabled = True
                btnRotateRight.Enabled = True
                OptionsToolStripMenuItem.Enabled = True
                DeskewToolStripMenuItem.Enabled = True


                MainMenuUserEditedToolStripMenuItem.Enabled = False
                MainMenuUserOrigialToolStripMenuItem.Enabled = False

                UserAreaEditedImageToolStripMenuItem.Enabled = False
                UserAreaOriginalAreaToolStripMenuItem.Enabled = False

                btnSelectionBox.Enabled = False

                If HocrPicBox.MainImage IsNot Nothing Then
                    HocrPicBox.MainImage.Dispose()
                    HocrPicBox.MainImage = Nothing



                End If

                If HocrPicBox.Image IsNot Nothing Then
                    HocrPicBox.ImageAreas = New List(Of Rectangle)
                    HocrPicBox.DisposeImage()
                    HocrPicBox.ResetAllState()
                    HocrPicBox.CancelState()
                    HocrPicBox.HocrActive = False
                End If

                If EditorPicBox.MainImage IsNot Nothing Then

                    EditorPicBox.MainImage.Dispose()
                    EditorPicBox.MainImage = Nothing
                End If

                If EditorPicBox.Image IsNot Nothing Then
                    EditorPicBox.ImageAreas = New List(Of Rectangle)
                    EditorPicBox.HocrActive = False
                    EditorPicBox.DisposeImage()
                    EditorPicBox.CancelState()


                End If


                txtBoxResult.Text = ""
                Dim thisHocrPage As HocrPage

                If HocrPages.Where(Function(X) X.ImageName = FileName).Count = 0 Then

                    thisHocrPage = New HocrPage
                    thisHocrPage.ImageName = FileName
                    thisHocrPage.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(FileName))
                    thisHocrPage.PageNum = HocrPages.Count
                    HocrPages.Add(thisHocrPage)
                End If



                thisHocrPage = HocrPages.Single(Function(X) X.ImageName = FileName)



                CmbLang.SelectedIndex = AvailabelLangs.IndexOf(OCRsettings.Language)

                thisHocrPage.SetSettings()

                Using imgOp = ImageUtils.SafeOpenImage(thisHocrPage.ImageName)

                    UndoImageList.Add(imgOp.Clone)
                    UndoType.Add(AmhOCR.UndoType.ImageSetting)

                    If Not File.Exists(thisHocrPage.imgCopyName) Then
                        Dim cpyImg As Bitmap = imgOp.Clone
                        Dim resol = thisHocrPage.PageOCRsettings.Resolution

                        cpyImg.SetResolution(resol.Width, resol.Height)

                        PreProcessor.ApplyCorrections(cpyImg).Save(thisHocrPage.imgCopyName)

                        cpyImg.Dispose()
                        cpyImg = Nothing

                    End If

                End Using



                Dim openImageName = thisHocrPage.imgCopyName




                isRecognizOpen = False
                btnResetRecog.Enabled = False


                Using imgOp = Ag.Image.FromFile(openImageName)

                    OCRsettings.Resolution = New Size(imgOp.HorizontalResolution, imgOp.VerticalResolution)
                    OCRsettings.PageSize = New Size(imgOp.Width, imgOp.Height)


                    EditorPicBox.Image = imgOp.Clone
                    EditorPicBox.MainImage = UndoImageList(0).Clone
                    EditorPicBox.FileName = FileName
                    EditorPicBox.ImageAreas = thisHocrPage.ImageBlocks.ToList

                    textSelctedImage.Text = ListOpenedImages.Items.Item(ListOpenedImages.SelectedIndices(0)).Text
                    SelectNameLbl.Text = FileName
                    SelectNameLbl.Text = "Image " + (ListOpenedImages.SelectedIndices(0) + 1).ToString + " Of " + TotalImagesCnt.ToString + "  " + FileName

                    ListOpenedImages.SelectedItems(0).EnsureVisible()

                    isBusy = True

                    CmbLang.SelectedIndex = AvailabelLangs.IndexOf(OCRsettings.Language)

                    isBusy = False

                    If thisHocrPage.Recognized Then



                        btnBackground.Text = "OCR Image Background"
                        ResetImageBackgroundToolStripMenuItem.Text = "OCR Background View Mode"


                        btnResetRecog.Enabled = True
                        isRecognizOpen = True
                        RecognizeApage()

                    Else


                        btnBackground.Text = "Image View"
                        ResetImageBackgroundToolStripMenuItem.Text = "Image View Mode"
                        If OCRsettings.OCRbackgroundView = BackgroundMode.UserEditedImageArea OrElse
                           OCRsettings.OCRbackgroundView = BackgroundMode.UserOriginalImageArea Then

                            OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage
                            btnImageEditMode.Text = "Edited"
                        End If

                        EditorPicBox.Focus()

                        If thisHocrPage.ImageName <> thisHocrPage.imgCopyName Then
                            btnResetRecog.Enabled = True
                        End If

                        If SplitInputResultView.Panel1Collapsed = False Then
                            SplitInputResultView.Panel1Collapsed = True
                        End If
                        If SplitTextResultView.Panel2Collapsed = False Then
                            SplitTextResultView.Panel2Collapsed = True
                        End If

                    End If


                End Using


                EditorPicBox.Invalidate()

            End If
        Else
            Beep()
        End If


    End Sub



    Private Sub OpenAllFiles(ByVal filter As String)



        Using ofd As New OpenFileDialog

            ofd.Filter = filter
            ofd.Title = "Open File"
            ofd.Multiselect = True
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            ofd.CheckFileExists = True
            ofd.CheckPathExists = True

            If ofd.ShowDialog = DialogResult.OK Then

                ResetMainWindow()

                OCRsettings.ProjectFile = ""


                Dim ApprovedFiles As New List(Of String)

                ApprovedFiles = ofd.FileNames.ToList

                If ApprovedFiles.Count > 0 Then
                    isBusy = True

                    If ApprovedFiles.First.ToLower.EndsWith(".pdf") Then

                        OpenMultiplePdfs(ApprovedFiles.ToArray)

                    Else

                        OpenImagesFromDialog(ApprovedFiles.ToArray, False)

                    End If

                End If

            End If

        End Using





    End Sub



    Private Sub OpenProject()



        Using ofb As New OpenFileDialog



            ofb.Filter = "AmhOCR (*.AmhOCR)|*.amhocr"
            ofb.Title = "Open Project"

            ofb.InitialDirectory = OCRsettings.ProjectMainFolder
            ofb.CheckPathExists = True
            ofb.Multiselect = False

            If ofb.ShowDialog = DialogResult.OK Then

                isBusy = True
                Dim prog As New ProgressReport
                prog.Size = New Size(364, 100)
                prog.Text = "Open Project"
                prog.lbltext = ""

                prog.StartPosition = FormStartPosition.Manual

                Try
                    prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
                Catch ex As Exception
                    prog.StartPosition = FormStartPosition.CenterParent
                End Try

                prog.ProgressBar1.Style = ProgressBarStyle.Blocks
                prog.ProgressBar1.Value = 0

                Dim entries As New List(Of String)
                Dim cnt As Integer = 0

                prog.UpdateProgress("Reading Archive File")
                prog.Text = "Reading Archive File"

                Dim extractedimages As New List(Of String)

                OCRsettings.ProjectTempFolder = Path.Combine(OCRsettings.AmhOcrTempFolder, Guid.NewGuid.ToString)
                If Directory.Exists(OCRsettings.ProjectTempFolder) = False Then
                    Directory.CreateDirectory(OCRsettings.ProjectTempFolder)
                End If

                AddHandler prog.Shown,
                            New EventHandler(
                            Async Sub(s, e)

                                Using ZipFile = New Ionic.Zip.ZipFile

                                    ZipFile.Initialize(ofb.FileName)
                                    prog.ProgressBar1.Value = 0
                                    prog.ProgressBar1.Maximum = ZipFile.Entries.Count


                                    AddHandler ZipFile.ExtractProgress,
                                    New EventHandler(Of Ionic.Zip.ExtractProgressEventArgs)(
                                     Sub(zip, arg)

                                         If arg.EventType = Ionic.Zip.ZipProgressEventType.Extracting_AfterExtractEntry Then
                                             prog.UpdateProgress(cnt)
                                             prog.UpdateProgress(arg.CurrentEntry.FileName)


                                             If Not arg.CurrentEntry.FileName.EndsWith(".hocr") Then
                                                 extractedimages.Add(Path.Combine(arg.ExtractLocation, arg.CurrentEntry.FileName))

                                             End If

                                             cnt += 1
                                         End If
                                     End Sub)

                                    Dim tskExtract =
                                    TaskEx.Run(
                                    Sub()
                                        ZipFile.ExtractAll(OCRsettings.ProjectTempFolder)
                                    End Sub)

                                    cnt = 0
                                    Await tskExtract

                                    prog.DialogResult = DialogResult.OK

                                End Using



                            End Sub)


                If prog.ShowDialog(Me) = DialogResult.OK Then
                    If extractedimages.Count > 0 Then

                        ResetMainWindow()
                        isBusy = True

                        OCRsettings.ProjectFile = ofb.FileName
                        OpenMultipleImages(extractedimages.ToArray, True)

                    End If

                End If



            End If



        End Using

        isBusy = False

    End Sub


    Private Sub AppendImageFiles(ByVal filter As String)



        Using ofd As New OpenFileDialog

            ofd.Filter = filter
            ofd.Title = "Open File"
            ofd.Multiselect = True
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            ofd.CheckFileExists = True
            ofd.CheckPathExists = True

            If ofd.ShowDialog = DialogResult.OK Then



                Dim ApprovedFiles As New List(Of String)
                For Each file In ofd.FileNames

                    If Not FilePaths.Contains(file) AndAlso Not file.Contains(OCRsettings.AmhOcrTempFolder) Then

                        Dim cleanfileName = Path.GetFileName(file)

                        If Not FilePaths.Any(Function(n) Path.GetFileName(n) = cleanfileName) Then

                            ApprovedFiles.Add(file)

                        End If

                    End If
                Next


                If ApprovedFiles.Count > 0 Then
                    isBusy = True

                    If ApprovedFiles.First.EndsWith(".pdf") Then

                        OpenMultiplePdfs(ApprovedFiles.ToArray)

                    Else

                        AppendMultipleImages(ApprovedFiles.ToArray)

                    End If

                End If


            End If

        End Using





    End Sub











    Private Sub SavepageAsWord(ByVal sender As Object, ByVal e As EventArgs)

        If HocrPages IsNot Nothing AndAlso isBusy = False Then

            Try
                Dim indx = ListOpenedImages.SelectedIndices(0)
                Dim FileName = FilePaths(indx)
                SaveAllasWord(FileName)
            Catch ex As Exception

            End Try


        End If

    End Sub



    Private Sub SaveAsSearchablePDF(ByVal sender As Object, ByVal e As EventArgs)

        If HocrPages IsNot Nothing AndAlso isBusy = False Then


            Try
                Dim indx = ListOpenedImages.SelectedIndices(0)
                Dim FileName = FilePaths(indx)
                hocrToSearchablePDF(FileName)
            Catch ex As Exception

            End Try

        End If


    End Sub



    Private Sub hocrToSearchablePDF(Optional ImageName As String = "")
        If HocrPages IsNot Nothing Then
            If (HocrPages.Count > 0) AndAlso (HocrPages.Where(Function(X) X.Recognized = True).Count > 0) Then
                Using ofd As New SaveFileDialog

                    ofd.Filter = "Searchable PDF File (*.PDF)|*.pdf"
                    ofd.Title = "Save OCR Output as Searchable PDF"
                    ofd.InitialDirectory = OCRsettings.ProjectMainFolder
                    ofd.CheckPathExists = True
                    ofd.OverwritePrompt = True
                    If ofd.ShowDialog = DialogResult.OK Then
                        isBusy = True
                        Dim recognizedHocr As IEnumerable(Of HocrPage)
                        If Not String.IsNullOrEmpty(ImageName) Then
                            recognizedHocr = HocrPages.Where(Function(X) X.ImageName = ImageName AndAlso X.Recognized = True)
                        Else
                            recognizedHocr = HocrPages.Where(Function(X) X.Recognized = True)
                        End If

                        If recognizedHocr.Count > 0 Then
                            UtilityHandler.HocrToPDFTask(recognizedHocr, ofd.FileName)
                        End If

                        isBusy = False

                    End If
                End Using


            End If

        End If

        isBusy = False

    End Sub



    Private Sub SavepageAsText(ByVal sender As Object, ByVal e As EventArgs)

        If HocrPages IsNot Nothing AndAlso isBusy = False Then


            Try
                Dim indx = ListOpenedImages.SelectedIndices(0)
                Dim FileName = FilePaths(indx)
                SaveAllasText(FileName)
            Catch ex As Exception

            End Try

        End If

    End Sub


    Private Sub SaveAllasFile()
        If FilePaths.Count > 0 Then
            Dim Filter = "AmhOCR (*.amhocr)|*.amhocr"

            If HocrPages IsNot Nothing AndAlso HocrPages.Any(Function(X) X.Recognized) Then
                Filter += "|Word File (*.docx)|*.docx"
                Filter += "|Searchable PDF (*.PDF)|*.pdf"
                Filter += "|Text File (*.txt)|*.txt"

            End If


            Using sdb As New SaveFileDialog

                sdb.Filter = Filter
                sdb.Title = "Save Project"
                sdb.CheckPathExists = True
                sdb.OverwritePrompt = True

                If Not String.IsNullOrEmpty(OCRsettings.ProjectFile) Then

                    sdb.InitialDirectory = Path.GetDirectoryName(OCRsettings.ProjectFile)
                    sdb.FileName = Path.GetFileName(OCRsettings.ProjectFile)
                Else
                    sdb.FileName = "NewProject.amhocr"
                    sdb.InitialDirectory = OCRsettings.ProjectMainFolder
                End If

                If sdb.ShowDialog = DialogResult.OK Then

                    If sdb.FileName.EndsWith(".amhocr") Then

                        ProjectSaver(sdb.FileName)

                    ElseIf sdb.FileName.EndsWith(".docx") Then


                        Dim recognizedHocr = HocrPages.Where(Function(X) X.Recognized = True)

                        If recognizedHocr.Count > 0 Then
                            DocOutPut.SingleColumnDocumentWord(recognizedHocr, sdb.FileName)
                        End If

                    ElseIf sdb.FileName.EndsWith(".txt") Then


                        Dim recognizedHocr = HocrPages.Where(Function(X) X.Recognized = True)

                        If recognizedHocr.Count > 0 Then
                            DocOutPut.SingleColumnDocumentText(recognizedHocr, sdb.FileName)
                        End If
                    ElseIf sdb.FileName.EndsWith(".pdf") Then

                        Dim recognizedHocr = HocrPages.Where(Function(X) X.Recognized = True)

                        If recognizedHocr.Count > 0 Then
                            UtilityHandler.HocrToPDFTask(recognizedHocr, sdb.FileName)
                        End If
                    End If


                End If


            End Using

        End If
    End Sub


    Private Sub SaveAllasText(Optional ImageName As String = "")
        If HocrPages IsNot Nothing Then
            If (HocrPages.Count > 0) AndAlso (HocrPages.Where(Function(X) X.Recognized = True).Count > 0) Then
                Using ofd As New SaveFileDialog

                    ofd.Filter = "Text File (*.txt)|*.txt"
                    ofd.Title = "Save OCR Output"
                    ofd.InitialDirectory = OCRsettings.ProjectMainFolder
                    ofd.CheckPathExists = True
                    ofd.OverwritePrompt = True
                    If ofd.ShowDialog = DialogResult.OK Then
                        isBusy = True
                        Dim recognizedHocr As IEnumerable(Of HocrPage)
                        If Not String.IsNullOrEmpty(ImageName) Then
                            recognizedHocr = HocrPages.Where(Function(X) X.ImageName = ImageName AndAlso X.Recognized = True)
                        Else
                            recognizedHocr = HocrPages.Where(Function(X) X.Recognized = True)
                        End If

                        If recognizedHocr.Count > 0 Then
                            DocOutPut.SingleColumnDocumentText(recognizedHocr, ofd.FileName)
                        End If

                        isBusy = False

                    End If
                End Using


            End If

        End If

        isBusy = False
    End Sub



    Private Sub SaveAllasWord(Optional ImageName As String = "")
        If HocrPages IsNot Nothing Then
            If (HocrPages.Count > 0) AndAlso (HocrPages.Where(Function(X) X.Recognized = True).Count > 0) Then
                Using ofd As New SaveFileDialog

                    ofd.Filter = "Word File (*.Docx)|*.Docx"
                    ofd.Title = "Save OCR Output"
                    ofd.InitialDirectory = OCRsettings.ProjectMainFolder
                    ofd.CheckPathExists = True
                    ofd.OverwritePrompt = True
                    If ofd.ShowDialog = DialogResult.OK Then
                        isBusy = True
                        Dim recognizedHocr As IEnumerable(Of HocrPage)
                        If Not String.IsNullOrEmpty(ImageName) Then
                            recognizedHocr = HocrPages.Where(Function(X) X.ImageName = ImageName AndAlso X.Recognized = True)
                        Else
                            recognizedHocr = HocrPages.Where(Function(X) X.Recognized = True)
                        End If
                        If recognizedHocr.Count > 0 Then
                            DocOutPut.SingleColumnDocumentWord(recognizedHocr, ofd.FileName)
                        End If



                    End If
                End Using


            End If

        End If

        isBusy = False
    End Sub



    Private Sub SaveProject(Optional close As Boolean = False)

        If (HocrPages IsNot Nothing) AndAlso (FilePaths.Count > 0) Then
            Using sdb As New SaveFileDialog
                sdb.Filter = "AmhOCR (*.amhocr)|*.amhocr"
                sdb.Title = "Save Project"
                sdb.CheckPathExists = True
                sdb.OverwritePrompt = True

                If Not String.IsNullOrEmpty(OCRsettings.ProjectFile) Then

                    sdb.InitialDirectory = Path.GetDirectoryName(OCRsettings.ProjectFile)
                    sdb.FileName = Path.GetFileName(OCRsettings.ProjectFile)
                Else
                    sdb.FileName = "NewProject.amhocr"
                    sdb.InitialDirectory = OCRsettings.ProjectMainFolder
                End If

                If sdb.ShowDialog = DialogResult.OK Then
                    ProjectSaver(sdb.FileName)
                End If

            End Using

        End If


        If close = True Then
            ResetMainWindow()
        End If

    End Sub



    Private Sub ProjectSaver(ByVal FileName As String)


        If isBusy = False Then

            isBusy = True
            Dim prog As New ProgressReport
            prog.Size = New Size(364, 100)
            prog.lbltext = ""
            prog.ProgressBar1.Style = ProgressBarStyle.Blocks

            prog.StartPosition = FormStartPosition.Manual

            Try
                prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
            Catch ex As Exception
                prog.StartPosition = FormStartPosition.CenterParent
            End Try



            Dim entries As New List(Of String)
            Dim cnt As Integer = 0


            AddHandler prog.Shown,
                            New EventHandler(
                            Async Sub(s, e)

                                Using ZipFile = New Ionic.Zip.ZipFile

                                    AddHandler ZipFile.AddProgress,
                                    New EventHandler(Of Ionic.Zip.AddProgressEventArgs)(
                                     Sub(zip, arg)
                                         If arg.EventType = Ionic.Zip.ZipProgressEventType.Adding_AfterAddEntry Then
                                             prog.UpdateProgress(cnt)
                                             prog.UpdateProgress(entries(cnt))
                                             cnt += 1
                                         End If
                                     End Sub)


                                    AddHandler ZipFile.SaveProgress,
                                    New EventHandler(Of Ionic.Zip.SaveProgressEventArgs)(
                                     Sub(zip, arg)
                                         If arg.EventType = Ionic.Zip.ZipProgressEventType.Saving_AfterWriteEntry Then
                                             prog.UpdateProgress(cnt)
                                             prog.UpdateProgress(entries(cnt))
                                             cnt += 1
                                         End If
                                     End Sub)


                                    Dim tsk =
                                    TaskEx.Run(
                                    Sub()

                                        For Each mainfile In FilePaths


                                            If HocrPages.Where(Function(X) X.ImageName = mainfile).Count > 0 Then
                                                Dim mypage = HocrPages.Where(Function(X) X.ImageName = mainfile).Single

                                                If mypage.Recognized = True Then

                                                    Dim hocrFile = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileNameWithoutExtension(mypage.imgCopyName) + ".hocr")
                                                    mypage.HocrXML.Save(hocrFile)
                                                    entries.Add(Path.GetFileName(hocrFile))
                                                Else
                                                    If File.Exists(mypage.imgCopyName) = False Then
                                                        FileIO.FileSystem.CopyFile(mainfile, mypage.imgCopyName)
                                                    End If
                                                End If


                                            Else

                                                Dim imgCopy = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(mainfile))

                                                If File.Exists(imgCopy) = False Then
                                                    FileIO.FileSystem.CopyFile(mainfile, imgCopy)
                                                End If

                                            End If

                                            entries.Add(Path.GetFileName(mainfile))

                                            cnt += 1
                                            prog.UpdateProgress(cnt)
                                            prog.UpdateProgress(entries.Last)


                                        Next


                                    End Sub)


                                    prog.Text = "Adding File To Archive"
                                    cnt = 0
                                    prog.ProgressBar1.Value = 0
                                    prog.ProgressBar1.Maximum = FilePaths.Count + 1

                                    Await tsk





                                    Dim tskAdd =
                                    TaskEx.Run(
                                    Sub()
                                        ZipFile.AddDirectory(OCRsettings.ProjectTempFolder)
                                    End Sub)

                                    prog.Text = "Compressing Files"
                                    cnt = 0
                                    prog.ProgressBar1.Value = 0
                                    prog.ProgressBar1.Maximum = entries.Count

                                    Await tskAdd





                                    Dim tskSave =
                                        TaskEx.Run(
                                        Sub()
                                            ZipFile.Save(FileName)
                                        End Sub)


                                    prog.Text = "Saving File"
                                    cnt = 0
                                    prog.ProgressBar1.Value = 0
                                    prog.ProgressBar1.Maximum = entries.Count


                                    Await tskSave

                                    prog.DialogResult = DialogResult.OK

                                End Using



                            End Sub)

            OCRsettings.ProjectFile = ""
            prog.ShowDialog(Me)
            OCRsettings.ProjectFile = FileName
            isProjectDirty = False


            isBusy = False
        End If


    End Sub



    Private Sub SaveProjectWordList()
        If HocrPages.Where(Function(X) X.Recognized = True).Count > 0 Then

            Using sfb As New SaveFileDialog
                sfb.Filter = "Text (*.txt)|*.txt"
                sfb.Title = "Save Word List"
                sfb.InitialDirectory = OCRsettings.ProjectMainFolder
                sfb.CheckPathExists = True
                If sfb.ShowDialog = DialogResult.OK Then
                    Dim WordList = TextProcessor.GetWordList(HocrPicBox.SpellCheker, HocrPages)
                    File.WriteAllText(sfb.FileName, WordList)

                End If

            End Using
        End If
    End Sub

    Private Sub SaveProjectWordFrequency()

        If HocrPages.Where(Function(X) X.Recognized = True).Count > 0 Then

            Using sfb As New SaveFileDialog
                sfb.Filter = "Text (*.txt)|*.txt"
                sfb.Title = "Save Word Frequency"
                sfb.InitialDirectory = OCRsettings.ProjectMainFolder
                sfb.CheckPathExists = True
                If sfb.ShowDialog = DialogResult.OK Then
                    Dim WordFrequency = TextProcessor.GetWordFrequency(HocrPicBox.SpellCheker, HocrPages)
                    File.WriteAllText(sfb.FileName, WordFrequency)
                End If

            End Using
        End If
    End Sub


    Private Sub SaveProjectSentencesList()

        If HocrPages.Where(Function(X) X.Recognized = True).Count > 0 Then

            Using sfb As New SaveFileDialog
                sfb.Filter = "Text (*.txt)|*.txt"
                sfb.Title = "Save Sentences List"
                sfb.InitialDirectory = OCRsettings.ProjectMainFolder
                sfb.CheckPathExists = True
                If sfb.ShowDialog = DialogResult.OK Then
                    Dim SentencesList = TextProcessor.GetSentencesList(HocrPicBox.SpellCheker, HocrPages)
                    File.WriteAllText(sfb.FileName, SentencesList)
                End If

            End Using
        End If
    End Sub













    Private Sub OpenImageWithHocr()

        OpenImage()


        If isRecognizOpen = False Then
            RecognizeApage()
        End If


    End Sub


    Private Sub OpenMultipleImages(ByVal FileNames() As String, ByVal projectopen As Boolean)

        OCRsettings.ProjectCopyFileFolder = Path.Combine(OCRsettings.AmhOcrTempFolder, Guid.NewGuid.ToString)

        If Directory.Exists(OCRsettings.ProjectCopyFileFolder) = False Then
            Directory.CreateDirectory(OCRsettings.ProjectCopyFileFolder)
        End If

        ImageList = New ImageList
        ImageList.ImageSize = New Size(132, 172)

        textSelctedImage.Text = ""
        SelectNameLbl.Text = ""

        If btnImgTab.Visible = True Then
            btnImgTab.PerformClick()
            Me.Invalidate()
        End If

        ListOpenedImages.LargeImageList = ImageList

        Dim prog As New ProgressReport
        prog.Size = New Size(364, 100)

        prog.StartPosition = FormStartPosition.Manual

        prog.SetProgres(FileNames.Count)

        ' Depending on the size of label string, this window will be resized

        Try
            Dim sizerr = prog.Label1.CreateGraphics.MeasureString("Loading " + Path.GetFileName(FileNames.First), prog.Label1.Font)

            If sizerr.Width + 20 > prog.Width Then

                prog.Width = sizerr.Width + 30
                prog.ProgressBar1.Width = sizerr.Width - 10

            End If

            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))

        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try


        AddHandler prog.Shown,
                New EventHandler(
                 Async Sub(s, arg)

                     TotalImagesCnt = 0

                     For Each imgname In FileNames

                         Dim prjCopyName = OCRsettings.ProjectCopyFileFolder
                         prjCopyName = IO.Path.Combine(prjCopyName, Path.GetFileName(imgname))

                         Using origImg As Bitmap = New Bitmap(imgname)

                             Dim imgOp = Ag.Image.Clone(origImg)

                             '300dpi default resolution to get good ocr output

                             imgOp.SetResolution(300, 300)
                             imgOp.Save(prjCopyName)
                             FilePaths.Add(prjCopyName)

                             ImageList.Images.Add(imgOp.Clone)

                             Dim itm = ListOpenedImages.Items.Add(Path.GetFileName(prjCopyName), TotalImagesCnt)
                             itm.EnsureVisible()
                             itm.ForeColor = Color.White
                             prog.Text = "Loading image " + TotalImagesCnt.ToString + " out of " + FileNames.Count.ToString
                             prog.UpdateProgress(Path.GetFileName(prjCopyName), TotalImagesCnt)

                             If projectopen = True Then

                                 If HocrPages.Where(Function(X) X.ImageName = prjCopyName).Count = 0 Then


                                     Dim hocrfile = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileNameWithoutExtension(prjCopyName) + ".hocr")

                                     If File.Exists(hocrfile) Then
                                         prog.UpdateProgress(Path.GetFileName(hocrfile))

                                         Dim thisHocrPage As HocrPage
                                         thisHocrPage = New HocrPage
                                         thisHocrPage.PageOCRsettings.Resolution = New Size(imgOp.HorizontalResolution, imgOp.VerticalResolution)

                                         thisHocrPage.PageOCRsettings.PageSize = New Size(imgOp.Width, imgOp.Height)
                                         thisHocrPage.HocrXML = XElement.Parse(File.ReadAllText(hocrfile))
                                         thisHocrPage = Await TessRecognize.AsyncParseHocr(thisHocrPage)
                                         thisHocrPage = Await PostProcessor.AsyncAnalyzepage(thisHocrPage)
                                         thisHocrPage.PageNum = HocrPages.Count
                                         thisHocrPage.ImageName = prjCopyName
                                         thisHocrPage.imgCopyName = prjCopyName

                                         If thisHocrPage.AllocrCarea.Count > 0 _
                                             AndAlso thisHocrPage.AllocrCarea.First.AllocrParas.Count > 0 Then
                                             Dim Lang = thisHocrPage.AllocrCarea.First.AllocrParas.First.Lang
                                             thisHocrPage.PageOCRsettings.Language = Lang
                                         End If

                                         itm.Checked = True
                                         HocrPages.Add(thisHocrPage)

                                     End If


                                 End If

                             End If


                             TotalImagesCnt += 1

                             imgOp.Dispose()
                             imgOp = Nothing

                         End Using


                         Await TaskEx.Delay(5)

                     Next

                     prog.Close()

                 End Sub)


        prog.ShowDialog(Me)

        prog.Dispose()
        prog = Nothing


        If ListOpenedImages.Items.Count > 0 Then
            btnAppenedFile.Enabled = True
        Else
            btnAppenedFile.Enabled = False
        End If

        isBusy = False

        If ListOpenedImages.Items.Count > 0 Then

            ListOpenedImages.Items.Item(0).Selected = True
            ListOpenedImages.Items.Item(0).Focused = True
            ListOpenedImages.Items.Item(0).EnsureVisible()

            ' for all file imported, this folder will be used to store copy of them  
            ' They will be deleted, along with other temp files in OCRsettings.AmhOcrTempFolder, when application exit
            If projectopen = False Then
                OCRsettings.ProjectTempFolder = Path.Combine(OCRsettings.AmhOcrTempFolder, Guid.NewGuid.ToString)
                If Directory.Exists(OCRsettings.ProjectTempFolder) = False Then
                    Directory.CreateDirectory(OCRsettings.ProjectTempFolder)
                End If
                isProjectDirty = True
            End If


            OpenImage()

        End If
    End Sub


    Private Sub OpenImagesFromDialog(ByVal Originalnames() As String, ByVal projectopen As Boolean)


        OCRsettings.ProjectCopyFileFolder = Path.Combine(OCRsettings.AmhOcrTempFolder, Guid.NewGuid.ToString)

        If Directory.Exists(OCRsettings.ProjectCopyFileFolder) = False Then
            Directory.CreateDirectory(OCRsettings.ProjectCopyFileFolder)
        End If





        TotalImagesCnt = 0
        ImageList = New ImageList
        ImageList.ImageSize = New Size(132, 172)

        textSelctedImage.Text = ""
        SelectNameLbl.Text = ""

        If btnImgTab.Visible = True Then
            btnImgTab.PerformClick()
            Me.Invalidate()
        End If

        ListOpenedImages.LargeImageList = ImageList

        Dim prog As New ProgressReport
        prog.Size = New Size(364, 100)

        prog.StartPosition = FormStartPosition.Manual

        prog.SetProgres(Originalnames.Count)

        ' Depending on the size of label string, this window will be resized

        Try
            Dim sizerr = prog.Label1.CreateGraphics.MeasureString("Loading " + Path.GetFileName(Originalnames.First), prog.Label1.Font)

            If sizerr.Width + 20 > prog.Width Then

                prog.Width = sizerr.Width + 30
                prog.ProgressBar1.Width = sizerr.Width - 10

            End If

            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))

        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try


        AddHandler prog.Shown,
                New EventHandler(
                 Async Sub(s, arg)

                     TotalImagesCnt = 0

                     For Each mainimg In Originalnames

                         Dim prjCopyName = OCRsettings.ProjectCopyFileFolder
                         prjCopyName = IO.Path.Combine(prjCopyName, Path.GetFileName(mainimg))

                         Using origImg As Bitmap = New Bitmap(mainimg)

                             Dim imgOp = Ag.Image.Clone(origImg)

                             '300dpi default resolution to get good ocr output

                             imgOp.SetResolution(300, 300)
                             imgOp.Save(prjCopyName)
                             FilePaths.Add(prjCopyName)

                             ImageList.Images.Add(imgOp.Clone)

                             Dim itm = ListOpenedImages.Items.Add(Path.GetFileName(prjCopyName), TotalImagesCnt)
                             itm.EnsureVisible()
                             itm.ForeColor = Color.White
                             prog.Text = "Loading image " + TotalImagesCnt.ToString + " out of " + Originalnames.Count.ToString
                             prog.UpdateProgress(Path.GetFileName(prjCopyName), TotalImagesCnt)

                             TotalImagesCnt += 1
                             imgOp.Dispose()
                             imgOp = Nothing
                         End Using


                         Await TaskEx.Delay(5)

                     Next

                     prog.Close()

                 End Sub)


        prog.ShowDialog(Me)

        prog.Dispose()
        prog = Nothing


        If ListOpenedImages.Items.Count > 0 Then
            btnAppenedFile.Enabled = True
        Else
            btnAppenedFile.Enabled = False
        End If

        isBusy = False

        If ListOpenedImages.Items.Count > 0 Then

            ListOpenedImages.Items.Item(0).Selected = True
            ListOpenedImages.Items.Item(0).Focused = True
            ListOpenedImages.Items.Item(0).EnsureVisible()

            OCRsettings.ProjectTempFolder = Path.Combine(OCRsettings.AmhOcrTempFolder, Guid.NewGuid.ToString)

            If Directory.Exists(OCRsettings.ProjectTempFolder) = False Then
                Directory.CreateDirectory(OCRsettings.ProjectTempFolder)
            End If

            isProjectDirty = True



            OpenImage()

        End If
    End Sub

    Private Sub AppendMultipleImages(ByVal FileNames() As String)

        ImageList = ListOpenedImages.LargeImageList
        If btnImgTab.Visible = True Then
            btnImgTab.PerformClick()
            Me.Invalidate()
        End If

        Dim prog As New ProgressReport
        prog.Size = New Size(364, 100)

        prog.StartPosition = FormStartPosition.Manual

        prog.SetProgres(FileNames.Count)

        ' Depending on the size of label string, this window will be resized

        Try
            Dim sizerr = prog.Label1.CreateGraphics.MeasureString("Appending " + Path.GetFileName(FileNames.First), prog.Label1.Font)

            If sizerr.Width + 20 > prog.Width Then

                prog.Width = sizerr.Width + 30
                prog.ProgressBar1.Width = sizerr.Width - 10

            End If

            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))

        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try

        Dim appendCnt As Integer = 0
        AddHandler prog.Shown,
                New EventHandler(
                 Async Sub(s, arg)

                     TotalImagesCnt = ListOpenedImages.Items.Count

                     For Each imgname In FileNames

                         If Not FilePaths.Contains(imgname) Then

                             Dim prjCopyName = OCRsettings.ProjectCopyFileFolder
                             prjCopyName = IO.Path.Combine(prjCopyName, Path.GetFileName(imgname))

                             Using origImg As Bitmap = New Bitmap(imgname)

                                 Dim imgOp = Ag.Image.Clone(origImg)

                                 '300dpi default resolution to get good ocr output

                                 imgOp.SetResolution(300, 300)
                                 imgOp.Save(prjCopyName)
                                 FilePaths.Add(prjCopyName)

                                 ImageList.Images.Add(imgOp.Clone)

                                 Dim itm = ListOpenedImages.Items.Add(Path.GetFileName(prjCopyName), ImageList.Images.Count - 1)
                                 itm.EnsureVisible()
                                 itm.ForeColor = Color.White
                                 prog.Text = "Appending image " + appendCnt.ToString + " out of " + FileNames.Count.ToString
                                 prog.UpdateProgress(Path.GetFileName(prjCopyName), appendCnt)

                                 TotalImagesCnt += 1
                                 appendCnt += 1

                                 imgOp.Dispose()
                                 imgOp = Nothing

                             End Using


                             Await TaskEx.Delay(5)


                         End If

                     Next

                     prog.Close()

                 End Sub)


        prog.ShowDialog(Me)

        prog.Dispose()
        prog = Nothing


        If appendCnt > 0 Then
            btnAppenedFile.Enabled = True
            btnResetRecog.Enabled = False
            ListOpenedImages.Items.Item(TotalImagesCnt - appendCnt).Selected = True
            ListOpenedImages.Items.Item(TotalImagesCnt - appendCnt).Focused = True
            ListOpenedImages.Items.Item(TotalImagesCnt - appendCnt).EnsureVisible()

            isProjectDirty = True
            isBusy = False
            OpenImage()

        End If

        isBusy = False

    End Sub


    Private Sub OpenMultiplePdfs(ByVal FileNames() As String)



        Dim Pdf2imgFiles As New List(Of String)

        Try



            Pdf2imgFiles = readGhost(FileNames)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Pdf2imgFiles.Count > 0 Then

            OCRsettings.ProjectTempFolder = Path.GetDirectoryName(Pdf2imgFiles.First)
            OpenMultipleImages(Pdf2imgFiles.ToArray, False)

        Else

            isBusy = False

        End If

    End Sub

    Private Function readGhost(ByVal fileNames As String()) As List(Of String)
        Dim AllFileCopy As New List(Of String)

        Try

            Using ProgrImpor = New PdfToImages

                ProgrImpor.StartPosition = FormStartPosition.Manual

                Try
                    ProgrImpor.Location = Me.PointToScreen(New Point((Me.Width - ProgrImpor.Width) / 2, Me.Height / 6))
                Catch ex As Exception
                    ProgrImpor.StartPosition = FormStartPosition.CenterParent
                End Try

                ProgrImpor.ProgressBar1.Value = 0
                ProgrImpor.ProgressBar1.Maximum = fileNames.Count
                ProgrImpor.dirbtm.Enabled = True
                For Each file In fileNames
                    ProgrImpor.checkedItem.Items.Add(file, True)
                Next
                ProgrImpor.justWait = False
                ProgrImpor.lblprogIndicator.Text = "Number of PDF File to Import: " + fileNames.Count.ToString

                ProgrImpor.ouputDirTxt.Text =
                    Path.Combine(OCRsettings.AmhOcrConvFolder,
                                 Path.GetFileNameWithoutExtension(fileNames.First))


                AddHandler ProgrImpor.btnImport.Click,
                    New EventHandler(
                   Async Sub(s, e)

                       If ProgrImpor.checkedItem.CheckedIndices.Count > 0 Then
                           ProgrImpor.justWait = True
                           ProgrImpor.lblprogIndicator.Text = "Progress: "

                           Dim checkedFiles As New List(Of String)

                           For Each idx As Integer In ProgrImpor.checkedItem.CheckedIndices
                               checkedFiles.Add(fileNames(idx))
                           Next

                           ProgrImpor.checkedItem.Items.Clear()

                           ProgrImpor.btnImport.Enabled = False
                           ProgrImpor.btnImport.Visible = False
                           ProgrImpor.ProgressBar1.Visible = True
                           ProgrImpor.Invalidate()
                           If (Await ProgrImpor.readGhost(checkedFiles.ToArray)) = True Then

                               ProgrImpor.ProgressBar1.Visible = False

                               ProgrImpor.progLabl.Text = "Completed"
                               AllFileCopy = ProgrImpor.GetFiles()
                               ProgrImpor.Close()
                           End If

                       End If

                   End Sub)


                ProgrImpor.ShowDialog(Me)






            End Using

        Catch ex As Exception
            MsgBox(ex)
            AllFileCopy.Clear()
        End Try




        Return AllFileCopy

    End Function



End Class
