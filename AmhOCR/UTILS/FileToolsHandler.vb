


'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

Imports System.IO

Public Class FileToolsHandler

    Public operation As UtilOperationType
    Private OutputFiletr As String
    Private IsBusy As Boolean = False
    Private ProgramAction As Boolean = False

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim filter As String = ""

        Using ofb = New OpenFileDialog
            ofb.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            ofb.Multiselect = True

            If (operation = UtilOperationType.SplitTiff) OrElse (operation = UtilOperationType.MergeTiff) Then

                filter = "Tiff Files|*.tiff;*.tif"
                OutputFiletr = filter

                If operation = UtilOperationType.SplitTiff Then
                    ofb.Multiselect = False
                End If

            ElseIf (operation = UtilOperationType.SplitPDF) OrElse (operation = UtilOperationType.MergePDF) Then

                filter = "PDF Files|*.Pdf"
                OutputFiletr = filter

                If operation = UtilOperationType.SplitPDF Then
                    ofb.Multiselect = False
                End If

            ElseIf (operation = UtilOperationType.ConvertPDFtoImage) Then

                filter = "PDF Files|*.Pdf"

                OutputFiletr = "Tiff File (*.tif;*.tiff)|*.tiff;*.tif|"
                OutputFiletr += "PNG File (*.png)|*.png|"
                OutputFiletr += "BMP File (*.bmp)|*.bmp|"
                OutputFiletr += "JPEG File (*.jpeg;*.jpg)|*.jpeg;*.jpg|"
                OutputFiletr += "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg"

            ElseIf (operation = UtilOperationType.ConvertImageToPDF) Then

                filter = "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg|"
                filter += "Tiff File (*.tif;*.tiff)|*.tiff;*.tif|"
                filter += "PNG File (*.png)|*.png|"
                filter += "BMP File (*.bmp)|*.bmp|"
                filter += "JPEG File (*.jpeg;*.jpg)|*.jpeg;*.jpg"


                OutputFiletr = "PDF Files|*.Pdf"

            ElseIf (operation = UtilOperationType.ConvertImageToImage) Then
                filter = "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg|"
                filter += "Tiff File (*.tif;*.tiff)|*.tiff;*.tif|"
                filter += "PNG File (*.png)|*.png|"
                filter += "BMP File (*.bmp)|*.bmp|"
                filter += "JPEG File (*.jpeg;*.jpg)|*.jpeg;*.jpg "


                OutputFiletr = "Tiff File (*.tif;*.tiff)|*.tiff;*.tif|"
                OutputFiletr += "PNG File (*.png)|*.png|"
                OutputFiletr += "BMP File (*.bmp)|*.bmp|"
                OutputFiletr += "JPEG File (*.jpeg;*.jpg)|*.jpeg;*.jpg|"
                OutputFiletr += "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg"

            End If

            ofb.Filter = filter


            If ofb.ShowDialog = DialogResult.OK Then


                If ofb.FileNames.Count > 0 Then

                    ProgramAction = True
                    btnImport.Enabled = False
                    importedItems.Items.Clear()

                    If operation = UtilOperationType.SplitPDF Then

                        SetPDFSplit(ofb.FileName)

                    Else

                        CheckBox1.Enabled = True
                        dirbtm.Enabled = True
                        btnStartUtil.Enabled = True

                        For Each file In ofb.FileNames

                            importedItems.Items.Add(file, True)

                        Next


                        importedItems.SelectedIndex = 0


                        If operation = UtilOperationType.MergePDF OrElse operation = UtilOperationType.MergeTiff Then
                            btnImport.Visible = False
                            btnDown.Visible = True
                            btnUP.Visible = True

                        End If
                        ProgramAction = False
                    End If


                End If


            End If

        End Using



    End Sub

    Private Async Sub SetPDFSplit(ByVal pdffile As String)

        Me.Text = "Getting Page Number Info. Please wait..."
        Me.UseWaitCursor = True


        importedItems.Tag = pdffile

        Dim Pages = Await PdfUtils.GetPDFPageNumbers(pdffile)

        Dim FileName = Path.GetFileNameWithoutExtension(pdffile)

        For page As Integer = 1 To Pages

            importedItems.Items.Add(FileName + "_" + "Page_" + page.ToString, True)

        Next

        importedItems.SelectedIndex = 0
        dirbtm.Enabled = True
        btnStartUtil.Enabled = True
        CheckBox1.Enabled = True
        Me.UseWaitCursor = False

        Me.Text = "Split Pages from a Pdf File"
        ProgramAction = False
    End Sub


    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        If (importedItems.SelectedIndex > 0) Then
            ProgramAction = True
            Dim idx As Integer = importedItems.SelectedIndex

            Dim name = importedItems.GetItemText(importedItems.Items(idx))

            importedItems.Items.RemoveAt(idx)
            importedItems.Items.Insert(idx - 1, name)
            importedItems.SetItemChecked(idx - 1, True)
            importedItems.SelectedIndex = idx - 1
            ProgramAction = False
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If (importedItems.SelectedIndex >= 0) AndAlso ((importedItems.Items.Count - 1) > importedItems.SelectedIndex) Then
            ProgramAction = True
            Dim idx As Integer = importedItems.SelectedIndex

            Dim name = importedItems.GetItemText(importedItems.Items(idx))

            importedItems.Items.RemoveAt(idx)
            importedItems.Items.Insert(idx + 1, name)
            importedItems.SetItemChecked(idx + 1, True)
            importedItems.SelectedIndex = idx + 1
            ProgramAction = False
        End If
    End Sub

    Private Sub btnStartUtil_Click(sender As Object, e As EventArgs) Handles btnStartUtil.Click


        If importedItems.CheckedItems.Count > 0 Then

            Dim Files As New List(Of String)
            Dim Indexs As New List(Of Integer)
            For itm As Integer = 0 To importedItems.Items.Count - 1

                If importedItems.GetItemChecked(itm) = True Then
                    Indexs.Add(itm)
                    Files.Add(importedItems.GetItemText(importedItems.Items(itm)))
                End If


            Next


            HandleOperation(Files.ToArray, Indexs.ToArray)



        Else
            MsgBox("There is no selcted Items. Please select/import items to handle")
        End If


    End Sub


    Private Sub HandleOperation(ByVal files() As String, ByVal Indexs() As Integer)


        If operation = UtilOperationType.SplitTiff Then

            Dim tsk = TaskEx.Run(Sub()
                                     ImageUtils.TiffSplit(files.First, ouputDirTxt.Text)
                                 End Sub)


            Try

                dirbtm.Enabled = False
                btnStartUtil.Visible = False
                ProgressBar1.Visible = True

                HandleTask(tsk)
            Catch ex As Exception

            End Try




        ElseIf operation = UtilOperationType.MergeTiff Then

            Dim OutputName = GetSaveasName()

            If String.IsNullOrEmpty(OutputName) = False Then



                Dim tsk = TaskEx.Run(Sub()
                                         ImageUtils.TiffMerge(files, OutputName)
                                     End Sub)


                Try
                    dirbtm.Enabled = False
                    btnStartUtil.Visible = False
                    ProgressBar1.Visible = True

                    HandleTask(tsk)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else


                MsgBox("Output File name should be set")


            End If


        ElseIf operation = UtilOperationType.SplitPDF Then
            Dim OutputName = GetSaveasName()

            If String.IsNullOrEmpty(OutputName) = False Then

                dirbtm.Enabled = False
                btnStartUtil.Visible = False
                ProgressBar1.Visible = True

                Me.Hide()
                IsBusy = True

                For pg As Integer = 0 To Indexs.Count - 1
                    Indexs(pg) += 1
                Next

                Dim FileName As String = importedItems.Tag

                Try
                    SplitDeductPDFTask(FileName, OutputName, Indexs)
                Catch ex As Exception
                    MyReport = ex.Message
                End Try

                IsBusy = False
                TaskFinished()
            Else


                MsgBox("Output File name should be set")
            End If

        ElseIf operation = UtilOperationType.MergePDF Then

            Dim OutputName = GetSaveasName()

            If String.IsNullOrEmpty(OutputName) = False Then
                dirbtm.Enabled = False
                btnStartUtil.Visible = False
                ProgressBar1.Visible = True

                Me.Hide()
                IsBusy = True
                Try
                    PdfMergeTask(files, OutputName)
                Catch ex As Exception
                    MyReport = ex.Message
                End Try

                IsBusy = False
                TaskFinished()

            Else

                MsgBox("Output File name should be set")
            End If


        ElseIf operation = UtilOperationType.ConvertPDFtoImage Then
            dirbtm.Enabled = False
            btnStartUtil.Visible = False
            ProgressBar1.Visible = True

            Me.Hide()
            IsBusy = True
            Try
                PdfToImageTask(files)
            Catch ex As Exception
                MyReport = ex.Message
            End Try

            IsBusy = False
            TaskFinished()

        ElseIf operation = UtilOperationType.ConvertImageToPDF Then


            Dim OutputName = GetSaveasName()

            If String.IsNullOrEmpty(OutputName) = False Then

                dirbtm.Enabled = False
                btnStartUtil.Visible = False
                ProgressBar1.Visible = True

                Me.Hide()
                IsBusy = True

                Try
                    ImageToPDFTask(files, OutputName)
                Catch ex As Exception
                    MyReport = ex.Message
                End Try



                IsBusy = False
                TaskFinished()

                'If False Then
                '    Dim tsk = TaskEx.Run(
                '                    Function() As String
                '                    Return TessSearchablePDF.MakeSearchablePDF(files, OutputName)
                '                    End Function)

                '    HandleTask(tsk)
                'End If

            Else

                MsgBox("Output File name should be set")
            End If



        ElseIf operation = UtilOperationType.ConvertImageToImage Then

            Dim OutputName = GetSaveasName()

            If String.IsNullOrEmpty(OutputName) = False Then
                dirbtm.Enabled = False
                btnStartUtil.Visible = False
                ProgressBar1.Visible = True


                OutputName = Path.GetExtension(OutputName)

                Dim tsk =
                    TaskEx.Run(
                    Sub()
                        ImageUtils.ConvertImages(files, ouputDirTxt.Text, OutputName)
                    End Sub)



                HandleTask(tsk)

            Else

                MsgBox("Output File name should be set")
            End If


        End If






    End Sub

    Private Function GetSaveasName() As String


        Dim Name As String = ""
        Using ofb = New SaveFileDialog
            ofb.OverwritePrompt = True
            ofb.InitialDirectory = ouputDirTxt.Text
            ofb.Filter = OutputFiletr

            If ofb.ShowDialog = DialogResult.OK Then
                Name = ofb.FileName
            End If

        End Using


        Return Name

    End Function

    Private Overloads Async Sub HandleTask(ByVal tsk As Task)
        IsBusy = True
        Await tsk

        If tsk.Exception IsNot Nothing Then
            MyReport = tsk.Exception.Message
        End If
        IsBusy = False
        TaskFinished()
    End Sub

    Private Overloads Async Sub HandleTask(ByVal tsk As Task(Of String))
        IsBusy = True
        Dim Out = Await tsk

        If tsk.Exception IsNot Nothing Then
            MyReport = tsk.Exception.Message
        Else
            MyReport = Out
        End If
        IsBusy = False
        TaskFinished()
    End Sub


    Public MyReport As String = String.Empty
    Private Sub TaskFinished()
        IsBusy = False
        Me.DialogResult = DialogResult.OK
    End Sub



    Private Sub UtilityHandler_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If IsBusy = True Then

            If e.CloseReason = CloseReason.UserClosing Then
                e.Cancel = True
                Beep()
            End If

        End If
    End Sub



    Private Sub UtilityHandler_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub dirbtm_Click(sender As Object, e As EventArgs) Handles dirbtm.Click

        Using fldr = New FolderBrowserDialog
            fldr.ShowNewFolderButton = True
            fldr.Description = "Select Output folder"
            fldr.SelectedPath = UserSettings.AmhOcrConvFolder

            If fldr.ShowDialog(Me) = DialogResult.OK Then
                ouputDirTxt.Text = fldr.SelectedPath
            End If

        End Using


    End Sub




    Private Sub PdfToImageTask(ByVal FileNames() As String)


        Dim AllFileCopy As New List(Of String)

        Using ProgrImpor = New PdfToImages
            ' ProgrImpor.Size = New Size(364, 100)
            ProgrImpor.StartPosition = FormStartPosition.CenterParent

            ProgrImpor.btnImport.Enabled = False
            ProgrImpor.btnImport.Visible = False
            ProgrImpor.ProgressBar1.Visible = True
            ProgrImpor.ouputDirTxt.Text = ouputDirTxt.Text
            ProgrImpor.ProgressBar1.Value = 0
            ProgrImpor.ProgressBar1.Maximum = FileNames.Count
            '  ProgrImpor.TopMost = True

            AddHandler ProgrImpor.Shown,
                New EventHandler(
                Async Sub()
                    If (Await ProgrImpor.readGhost(FileNames)) = True Then

                        ProgrImpor.ProgressBar1.Visible = False

                        ProgrImpor.progLabl.Text = "Completed"
                        AllFileCopy = ProgrImpor.GetFiles()
                        ProgrImpor.Close()

                    End If
                End Sub)


            ProgrImpor.ShowDialog(Me)





        End Using

    End Sub



    Private Sub PdfMergeTask(ByVal FileNames() As String, ByVal output As String)


        Dim AllFileCopy As New List(Of String)

        Using MeregProgr = New ProgressReport
            ' MeregProgr.Size = New Size(364, 100)

            MeregProgr.StartPosition = FormStartPosition.CenterParent
            MeregProgr.ProgressBar1.Style = ProgressBarStyle.Blocks
            MeregProgr.ProgressBar1.Value = 0
            MeregProgr.ProgressBar1.Maximum = FileNames.Count

            MeregProgr.Text = "PDF Merge"
            MeregProgr.lbltext = "Merging: "
            AddHandler PdfUtils.PdfFileMergeStarted,
            New EventHandler(Of PdfMergeStartedArg)(
            Sub(s, e)
                MeregProgr.UpdateProgress("Merge Started")
            End Sub)

            AddHandler PdfUtils.PdfFileMerged,
            New EventHandler(Of PdfMergedArg)(
            Sub(s, e)
                MeregProgr.UpdateProgress(Path.GetFileName(e.FileName))
                MeregProgr.UpdateProgress(e.FileNumber)

            End Sub)


            AddHandler MeregProgr.Shown,
                New EventHandler(
                Async Sub()
                    Dim tsk =
                    TaskEx.Run(
                    Sub()
                        PdfUtils.MergePDFfiles(FileNames, output)
                    End Sub)

                    Await tsk
                    MeregProgr.DialogResult = DialogResult.OK
                End Sub)


            If MeregProgr.ShowDialog(Me) = DialogResult.OK Then
                MyReport = "PDF Saved @ " + output
            End If





        End Using

    End Sub


    Private Sub SplitDeductPDFTask(ByVal FileName As String, ByVal output As String, ByVal PageNumbers() As Integer)


        Dim AllFileCopy As New List(Of String)

        Using SplitProgr = New ProgressReport
            ' MeregProgr.Size = New Size(364, 100)

            SplitProgr.StartPosition = FormStartPosition.CenterParent
            SplitProgr.ProgressBar1.Style = ProgressBarStyle.Blocks
            SplitProgr.ProgressBar1.Value = 0
            SplitProgr.ProgressBar1.Maximum = PageNumbers.Count

            SplitProgr.Text = "Split Pdf Pages and Save"
            SplitProgr.lbltext = "Spliting and Saving: "

            Dim PageNamer As String = Path.GetFileNameWithoutExtension(FileName) + "_Page_"


            AddHandler PdfUtils.PageProcessStartedArg,
            New EventHandler(Of PageProcessStartedArg)(
            Sub(s, e)
                SplitProgr.UpdateProgress("Spliting Started")
            End Sub)


            Dim cnt As Integer = 0
            AddHandler PdfUtils.PageProcessed,
            New EventHandler(Of PageProcessArg)(
            Sub(s, e)
                cnt += 1
                SplitProgr.UpdateProgress(cnt)
                SplitProgr.UpdateProgress(PageNamer + e.PageNumber.ToString)

            End Sub)


            AddHandler SplitProgr.Shown,
                New EventHandler(
                Async Sub()
                    Dim tsk =
                    TaskEx.Run(
                    Sub()
                        PdfUtils.SplitPDFPages(FileName, output, PageNumbers)
                    End Sub)

                    Await tsk
                    SplitProgr.DialogResult = DialogResult.OK
                End Sub)


            If SplitProgr.ShowDialog(Me) = DialogResult.OK Then
                MyReport = "PDF Saved @ " + FileName
            End If





        End Using

    End Sub

    Private Sub ImageToPDFTask(ByVal FileNames() As String, ByVal output As String)


        Dim AllFileCopy As New List(Of String)

        Using imgTopdfProgr = New ProgressReport

            imgTopdfProgr.StartPosition = FormStartPosition.CenterParent
            imgTopdfProgr.ProgressBar1.Style = ProgressBarStyle.Blocks
            imgTopdfProgr.ProgressBar1.Value = 0
            imgTopdfProgr.ProgressBar1.Maximum = FileNames.Count

            imgTopdfProgr.Text = "Convert Image to Pdf"
            imgTopdfProgr.lbltext = ""

            Dim TotalPages As Integer = FileNames.Count


            AddHandler PdfUtils.PageProcessStartedArg,
            New EventHandler(Of PageProcessStartedArg)(
            Sub(s, e)
                imgTopdfProgr.UpdateProgress("Conversion started...")
            End Sub)


            AddHandler PdfUtils.PageProcessed,
            New EventHandler(Of PageProcessArg)(
            Sub(s, e)

                imgTopdfProgr.UpdateProgress(e.PageNumber)
                Dim PageNamer = Path.GetFileNameWithoutExtension(FileNames(e.PageNumber - 1))
                imgTopdfProgr.UpdateProgress("Inserting... " + PageNamer + " to page " + e.PageNumber.ToString)
                imgTopdfProgr.UpdateFormText("Convert Image to Pdf: " + Math.Round(e.PageNumber * 100 / TotalPages, 0).ToString + "%")
            End Sub)


            AddHandler imgTopdfProgr.Shown,
                New EventHandler(
                Async Sub()
                    Dim tsk =
                    TaskEx.Run(
                    Sub()
                        PdfUtils.ImagesToPdf(FileNames, output)
                    End Sub)

                    Await tsk
                    imgTopdfProgr.DialogResult = DialogResult.OK
                End Sub)


            If imgTopdfProgr.ShowDialog(Me) = DialogResult.OK Then
                MyReport = "PDF Saved @ " + output
            End If





        End Using

    End Sub

    Public Shared Sub HocrToPDFTask(ByVal hocrFiles As IEnumerable(Of HocrPage), ByVal output As String)


        Dim AllFileCopy As New List(Of String)

        Using hocrTopdfProgr = New ProgressReport

            hocrTopdfProgr.StartPosition = FormStartPosition.CenterParent
            hocrTopdfProgr.ProgressBar1.Style = ProgressBarStyle.Blocks
            hocrTopdfProgr.ProgressBar1.Value = 0
            hocrTopdfProgr.ProgressBar1.Maximum = hocrFiles.Count

            hocrTopdfProgr.Text = "Convert Hocr to Searchable Pdf"
            hocrTopdfProgr.lbltext = ""

            Dim TotalPages As Integer = hocrFiles.Count


            AddHandler PdfUtils.PageProcessStartedArg,
            New EventHandler(Of PageProcessStartedArg)(
            Sub(s, e)
                hocrTopdfProgr.UpdateProgress("Conversion started...")
            End Sub)


            AddHandler PdfUtils.PageProcessed,
            New EventHandler(Of PageProcessArg)(
            Sub(s, e)

                hocrTopdfProgr.UpdateProgress(e.PageNumber)
                Dim PageNamer = Path.GetFileNameWithoutExtension(hocrFiles(e.PageNumber - 1).ImageName)
                hocrTopdfProgr.UpdateProgress("Converting... " + PageNamer + ": Page " + e.PageNumber.ToString + "/" + TotalPages.ToString)
                hocrTopdfProgr.UpdateFormText("Converting Recognized Image to Searchable Pdf: " + Math.Round(e.PageNumber * 100 / TotalPages, 0).ToString + "%")
            End Sub)


            AddHandler hocrTopdfProgr.Shown,
                New EventHandler(
                Async Sub()
                    Dim tsk =
                    TaskEx.Run(
                    Sub()
                        PdfUtils.HocrsToPDF(hocrFiles, output)
                    End Sub)

                    Await tsk
                    hocrTopdfProgr.DialogResult = DialogResult.OK
                End Sub)

            hocrTopdfProgr.ShowDialog()






        End Using

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged


        Try

            If CheckBox1.Checked = True Then
                CheckBox1.Text = "UnCheck All"

                If importedItems.CheckedItems.Count <> importedItems.Items.Count Then

                    For itm As Integer = 0 To importedItems.Items.Count - 1

                        If Not importedItems.CheckedIndices.Contains(itm) Then
                            importedItems.SetItemChecked(itm, True)
                        End If

                    Next

                End If


            Else
                If importedItems.CheckedItems.Count > 0 Then
                    For Each itm In importedItems.CheckedIndices
                        importedItems.SetItemChecked(itm, False)
                    Next
                End If
                CheckBox1.Text = "Check All"
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub importedItems_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles importedItems.ItemCheck

        If ProgramAction = True Then
            ProgramAction = False


            If SelectedIndex >= 0 Then
                If e.Index <> SelectedIndex Then
                    Dim ischeck As Boolean = True
                    If e.NewValue = CheckState.Unchecked Then
                        ischeck = False
                    End If

                    Dim steper As Integer = 1
                    If e.Index > SelectedIndex Then
                        steper = -1
                    End If

                    For itm As Integer = e.Index To SelectedIndex Step steper
                        importedItems.SetItemChecked(itm, ischeck)
                    Next
                End If
            End If


        End If


    End Sub

    Private SelectedIndex As Integer = -1
    Private Sub importedItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles importedItems.SelectedIndexChanged

        If ProgramAction = False Then
            SelectedIndex = importedItems.SelectedIndex
        End If


    End Sub

    Private Sub importedItems_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles importedItems.PreviewKeyDown

        If e.Control OrElse e.Shift Then
            ProgramAction = True
        End If



    End Sub

    Private Sub importedItems_KeyUp(sender As Object, e As KeyEventArgs) Handles importedItems.KeyUp
        ProgramAction = False
    End Sub
End Class