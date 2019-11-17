
Imports System
Imports System.IO
Imports System.Linq
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.Threading
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports GhostscriptSharp
Imports NetTesseract
Imports Ag = AForge.Imaging
Imports Ionic.Zlib
Public Class MainWindow

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3



#Region "members"



    Private isProjectDirty As Boolean = False

    Public CancelRequested As Boolean = False

    Public isBusy As Boolean = False

    Private isRecognizOpen As Boolean = False


    Private _Language As String = "amh"

    Private TotalImagesCnt As Integer = -1


    'Template images of opened file, used for listview large icone dispaly
    Public ImageList As ImageList

    'Holds opened file names
    Private FilePaths As List(Of String)

    'Languages avilable in tessdata path
    Private AvailabelLangs As List(Of String)

    'Recognized pages in Hocr format/a standardized xml style ocr output/
    Public HocrPages As List(Of HocrPage)



    'Recognized image editor control
    Friend EditorPicBox As ImageEditControl
#End Region


#Region "User interfaces"


    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Application.EnableVisualStyles()

        Initialize()

    End Sub


    Private Sub Initialize()

        'if AmhOcrTempFolder exits, it will be deleted along with sub folders and files
        Try
            If Directory.Exists(OCRsettings.AmhOcrTempFolder) Then
                Directory.Delete(OCRsettings.AmhOcrTempFolder, True)
            End If
        Catch ex As Exception

        End Try

        If Directory.Exists(OCRsettings.AmhOcrConvFolder) = False Then
            Directory.CreateDirectory(OCRsettings.AmhOcrConvFolder)
        End If




        If Directory.Exists(OCRsettings.ProjectMainFolder) = False Then
            Directory.CreateDirectory(OCRsettings.ProjectMainFolder)
        End If


        If Directory.Exists(OCRsettings.AmhOcrTempFolder) = False Then
            Directory.CreateDirectory(OCRsettings.AmhOcrTempFolder)
        End If

        If Directory.Exists(OCRsettings.AmhOcrDataFolder) = False Then
            Directory.CreateDirectory(OCRsettings.AmhOcrDataFolder)
        End If




        Dim otherfontfile = Path.Combine(Environment.CurrentDirectory, "Fonts\times.ttf")
        Dim amhfontfile = Path.Combine(Environment.CurrentDirectory, "Fonts\PGUNICODE1.TTF")

        PdfUtils.SetitextFont("Times New Roman", otherfontfile)
        PdfUtils.SetitextFont("Power Geez Unicode1", amhfontfile)


        Dim Instfont As New System.Drawing.Text.InstalledFontCollection

        If Not Instfont.Families.Any(Function(X) X.Name = "Power Geez Unicode1") Then

            Dim prvfont As New System.Drawing.Text.PrivateFontCollection

            If Not prvfont.Families.Any(Function(X) X.Name = "Power Geez Unicode1") Then
                prvfont.AddFontFile(amhfontfile)
            End If

            Dim fmly = prvfont.Families.Where(Function(X) X.Name = "Power Geez Unicode1").First
            OCRsettings.AmhocrFont = New Font(fmly, 11, FontStyle.Regular)
        Else
            OCRsettings.AmhocrFont = New Font("Power Geez Unicode1", 11, FontStyle.Regular)
        End If



        If Not Instfont.Families.Any(Function(X) X.Name = "Times New Roman") Then

            Dim prvfont As New System.Drawing.Text.PrivateFontCollection

            If Not prvfont.Families.Any(Function(X) X.Name = "Times New Roman") Then
                prvfont.AddFontFile(amhfontfile)
            End If

            Dim fmly = prvfont.Families.Where(Function(X) X.Name = "Times New Roman").First
            OCRsettings.DefaultocrFont = New Font(fmly, 11, FontStyle.Regular)
        Else
            OCRsettings.DefaultocrFont = New Font("Times New Roman", 11, FontStyle.Regular)
        End If

        OCRsettings.tesspath = IO.Path.Combine(Environment.CurrentDirectory, "Tesseract\tessdata\")
        OCRsettings.ocrFont = OCRsettings.AmhocrFont.Clone




        FilePaths = New List(Of String)
        EditorPicBox = New ImageEditControl

        SplitListViewImgEdit.Panel2.Controls.Add(EditorPicBox)

        EditorPicBox.Dock = DockStyle.Fill
        EditorPicBox.BackColor = Color.DimGray

        ToolStripContainer1.TopToolStripPanel.Controls.Add(ToolsMainWindow)
        ToolStripContainer1.TopToolStripPanel.Controls.Add(ToolsPreProcess)
        ToolStripContainer1.TopToolStripPanel.Controls.Add(ToolsOCRProcess)

        Try

            ToolsPreProcess.Location = New Point(ToolsMainWindow.Right + 5, ToolsMainWindow.Top)
            ToolsOCRProcess.Location = New Point(ToolsPreProcess.Right + 5, ToolsPreProcess.Top)

        Catch ex As Exception

        End Try




        ' Set the lbl control which will be used to display the mouse coordinate over this control
        EditorPicBox.Label = lblCoordinate
        ViewPicBox.Label = lblCoordinate


        ImageList = New ImageList
        ImageList.ImageSize = New Size(132, 172)

        HocrPages = New List(Of HocrPage)

        txtBoxResult.Font = OCRsettings.ocrFont.Clone



        btnImgTab.Visible = True
        SplitListViewImgEdit.Panel1Collapsed = True

        cmbEditMode.Items.Clear()

        ' OCRsettings.EditMode, only two mode currently implimented

        cmbEditMode.Items.Add("Word Level Edit")
        cmbEditMode.Items.Add("Paragraph Level Edit")
        cmbEditMode.SelectedIndex = 0

        'Get lnaguages available in tessdata path
        RefreshLanguage()


        AddHandler ContextMenuListView.Items(0).Click, AddressOf OpenImage
        AddHandler ContextMenuListView.Items(1).Click, AddressOf OpenImageWithHocr

        Dim SaveAsContext As ToolStripMenuItem = ContextMenuListView.Items(2)

        AddHandler SaveAsContext.DropDownOpening,
            New EventHandler(
            Sub(s, e)
                If ListOpenedImages.SelectedIndices.Count > 0 Then

                    If ListOpenedImages.Items.Item(ListOpenedImages.SelectedIndices(0)).Checked Then
                        SaveAsContext.DropDownItems(0).Enabled = True
                        SaveAsContext.DropDownItems(1).Enabled = True
                        SaveAsContext.DropDownItems(2).Enabled = True
                    Else
                        SaveAsContext.DropDownItems(0).Enabled = False
                        SaveAsContext.DropDownItems(1).Enabled = False
                        SaveAsContext.DropDownItems(2).Enabled = False
                    End If

                End If

            End Sub)

        AddHandler SaveAsContext.DropDownItems(0).Click, AddressOf SavepageAsWord
        AddHandler SaveAsContext.DropDownItems(1).Click, AddressOf SaveAsSearchablePDF
        AddHandler SaveAsContext.DropDownItems(2).Click, AddressOf SavepageAsText

        ' lambda procedure, ContextMenuListView Can only be shown during recognition and processing state

        AddHandler ContextMenuListView.Opening,
            New CancelEventHandler(Sub(s, e)
                                       If (FilePaths.Count = 0) OrElse (isBusy = True) OrElse
                                       (SplitListViewImgEdit.Panel1Collapsed = True) Then

                                           e.Cancel = True

                                       End If


                                   End Sub)



        AddHandler EditorPicBox.BoxHighlightedEvent, AddressOf RefreshPicViewBox
        AddHandler EditorPicBox.HocrEdited, AddressOf HocrEdited
        AddHandler EditorPicBox.EditModeChanged, AddressOf EditModeChanged

        Me.Cursor = Cursors.Arrow

    End Sub







    Private Sub CmbLang_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CmbLang.SelectedIndexChanged
        If (AvailabelLangs.Count > 0) AndAlso (isBusy = False) Then

            If AvailabelLangs.Contains(CmbLang.SelectedItem) Then
                _Language = CmbLang.SelectedItem
                OCRsettings.Language = _Language
                If _Language.Contains("amh") Then
                    OCRsettings.ocrFont = OCRsettings.AmhocrFont.Clone
                Else
                    OCRsettings.ocrFont = OCRsettings.DefaultocrFont.Clone
                End If

            End If

        End If

    End Sub


    Private Sub RunAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunAllToolStripMenuItem.Click
        If isBusy = False Then
            RecognizeBatch()
        End If
    End Sub

    Private Sub btnRecognizeAll_Click(sender As Object, e As EventArgs) Handles btnRecognizeAll.Click
        If isBusy = False Then
            RecognizeBatch()
        End If
    End Sub


    Private Sub RunOCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunOCRToolStripMenuItem.Click
        If isBusy = False Then
            RecognizeApage()
        End If
    End Sub

    Private Sub btnRecogCurrent_Click(sender As Object, e As EventArgs) Handles btnRecognizeCurrent.Click
        If isBusy = False Then
            RecognizeApage()
        End If


    End Sub


    Private Sub btnOpenNext_Click(sender As Object, e As EventArgs) Handles btnOpenNext.Click
        If ListOpenedImages.SelectedIndices.Count > 0 Then
            If ListOpenedImages.Items.Count > 1 Then
                Dim MdNext = (ListOpenedImages.SelectedIndices(0) + 1) Mod ListOpenedImages.Items.Count
                ListOpenedImages.Items.Item(MdNext).Selected = True
                ListOpenedImages.Items.Item(MdNext).Focused = True
                ListOpenedImages.Items.Item(MdNext).EnsureVisible()
                OpenImage()

            End If


        End If
    End Sub

    Private Sub btnOpenPrevious_Click(sender As Object, e As EventArgs) Handles btnOpenPrevious.Click
        If ListOpenedImages.SelectedIndices.Count > 0 Then
            If ListOpenedImages.Items.Count > 1 Then
                Dim MdNext = (ListOpenedImages.SelectedIndices(0) - 1)
                If MdNext < 0 Then
                    MdNext += ListOpenedImages.Items.Count
                End If

                ListOpenedImages.Items.Item(MdNext).Selected = True
                ListOpenedImages.Items.Item(MdNext).Focused = True
                ListOpenedImages.Items.Item(MdNext).EnsureVisible()
                OpenImage()

            End If


        End If
    End Sub



    Private Sub cmbOutput_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEditMode.SelectedIndexChanged
        If isBusy = False Then
            If cmbEditMode.SelectedIndex = 0 Then
                OCRsettings.EditMode = ocrEditMode.WordEdit
            ElseIf cmbEditMode.SelectedIndex = 1 Then
                OCRsettings.EditMode = ocrEditMode.ParagraphEdit

            End If
            EditorPicBox.SetEditorMode()
            EditorPicBox.Invalidate()
        End If

    End Sub

    Private Sub btnImgTab_Click(sender As Object, e As EventArgs) Handles btnImgTab.Click

        btnImgTabClicked()

    End Sub



    Private Sub Background_CheckedChanged(sender As Object, e As EventArgs) Handles btnBackground.CheckedChanged, ResetImageBackgroundToolStripMenuItem.CheckedChanged

        If OCRsettings.ResetBackground = True Then
            If btnBackground.Checked = False OrElse ResetImageBackgroundToolStripMenuItem.Checked = False Then
                OCRsettings.ResetBackground = False
                btnBackground.Checked = False
                ResetImageBackgroundToolStripMenuItem.Checked = False
                EditorPicBox.Invalidate()
            End If
        Else
            If btnBackground.Checked = True OrElse ResetImageBackgroundToolStripMenuItem.Checked = True Then
                OCRsettings.ResetBackground = True
                btnBackground.Checked = True
                ResetImageBackgroundToolStripMenuItem.Checked = True
                EditorPicBox.Invalidate()
            End If
        End If

    End Sub
    Private Sub textView_Click(sender As Object, e As EventArgs) Handles TextViewToolStripMenuItem.Click, btnTxtView.Click

        btnTxtView.Checked = Not btnTxtView.Checked
        TextViewToolStripMenuItem.Checked = btnTxtView.Checked
        If btnTxtView.Checked = True Then
            If SplitTextResultView.Panel2Collapsed = True Then
                SplitTextResultView.SplitterDistance = (3 * SplitTextResultView.Height / 4)
                SplitTextResultView.Panel2Collapsed = False
            End If

        Else

            If SplitTextResultView.Panel2Collapsed = False Then
                SplitTextResultView.Panel2Collapsed = True
            End If

        End If

    End Sub

    Private Sub btnColapsImg_Click(sender As Object, e As EventArgs) Handles btnColapsImg.Click
        ColapsImg()
    End Sub

    Private Sub btnImgTabClicked()

        If btnSettTab.Visible = True Then
            btnImgTab.Visible = False
            SplitListViewImgEdit.SplitterDistance = 240
            SplitListViewImgEdit.Panel1Collapsed = False
            SplitContainer5.Panel1Collapsed = False
            SplitContainer5.Panel2Collapsed = True
        Else
            SplitContainer5.Panel1Collapsed = False
            SplitListViewImgEdit.SplitterDistance = 500

            btnImgTab.Visible = False

        End If
    End Sub

    Private Sub ColapsImg()
        btnPinimag.Checked = False
        If btnSettTab.Visible = True Then

            btnImgTab.Visible = True
            SplitListViewImgEdit.Panel1Collapsed = True
        Else
            SplitContainer5.Panel1Collapsed = True
            SplitListViewImgEdit.SplitterDistance = 240

            btnImgTab.Visible = True

        End If
    End Sub






    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                ApplySetting()

            End If

        End If
    End Sub


    Private Sub btnDeskew_Click(sender As Object, e As EventArgs) Handles btnDeskew.Click

        If isBusy = False Then
            If EditorPicBox.Image IsNot Nothing Then

                DeskewImage()

            End If

        End If
    End Sub


    Private Sub btnRotateRight_Click(sender As Object, e As EventArgs) Handles btnRotateRight.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                RotateImage(True)

            End If

        End If
    End Sub

    Private Sub btnRotateLeft_Click(sender As Object, e As EventArgs) Handles btnRotateLeft.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                RotateImage(False)

            End If

        End If
    End Sub

    Private Sub btnCrop_Click(sender As Object, e As EventArgs) Handles btnCrop.Click


        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                CropImage()

            End If

        End If
    End Sub



    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                ApplySetting()

            End If

        End If
    End Sub

    Private Sub DeskewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeskewToolStripMenuItem1.Click

        If isBusy = False Then
            If EditorPicBox.Image IsNot Nothing Then

                DeskewImage()

            End If

        End If

    End Sub

    Private Sub RotateRight90ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RotateRight90ToolStripMenuItem.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                RotateImage(True)

            End If

        End If
    End Sub

    Private Sub Rotateleft90ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Rotateleft90ToolStripMenuItem.Click

        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                RotateImage(False)

            End If

        End If

    End Sub

    Private Sub CropImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CropImageToolStripMenuItem.Click

        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                RotateImage(False)

            End If

        End If

    End Sub




    Private Sub ImageToPDFTool_Click(sender As Object, e As EventArgs) Handles ImageToPDFToolStripMenuItem.Click

        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.ConvertImageToPDF
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Convert multiple images To PDF"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Error!")
            End If



        End If

    End Sub
    Private Sub SplitTiffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitTiffToolStripMenuItem.Click
        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.SplitTiff
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Split Tiff Formated Image"
        If ofb.ShowDialog(Me) = DialogResult.OK Then
            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Tiff Splitting finished")
            End If

        End If
    End Sub

    Private Sub MergeTiffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeTiffToolStripMenuItem.Click
        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.MergeTiff
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Merge multiple Tiff To Single Tiff image"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Tiff Mergging finished!")
            End If



        End If
    End Sub


    Private Sub SplitPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitPDFToolStripMenuItem.Click
        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.SplitPDF
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Split Pages from a Pdf File"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("PDF Spliting finished!")
            End If



        End If
    End Sub

    Private Sub CombinePDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CombinePDFToolStripMenuItem.Click
        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.MergePDF
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Merge Pdf Files"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("PDF Merge finished!")
            End If



        End If

    End Sub



    Private Sub PDFToImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToImageToolStripMenuItem.Click

        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.ConvertPDFtoImage
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Convert Pdf To Images"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("PDF To Image conversion finished!")
            End If



        End If


    End Sub

    Private Sub btnConvertImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnConvertImages.Click

        Dim ofb As New UtilityHandler
        ofb.operation = UtilOperationType.ConvertImageToImage
        ofb.ouputDirTxt.Text = OCRsettings.AmhOcrConvFolder
        ofb.Text = "Convert Images To Images"

        If ofb.ShowDialog(Me) = DialogResult.OK Then

            If String.IsNullOrEmpty(ofb.MyReport) = False Then
                MsgBox(ofb.MyReport)
            Else
                MsgBox("Images To Image conversion finished!")
            End If



        End If


    End Sub


    Private Sub ListOpenedImages_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListOpenedImages.ItemCheck

        If (isBusy = False) Then
            e.NewValue = e.CurrentValue
        End If

    End Sub

    Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then

            If isBusy = True Then

                CancelRequested = True
                e.Cancel = True
                Beep()

            Else

                If AbortAction() = True Then
                    Exit Sub
                End If

                If EditorPicBox._image IsNot Nothing Then
                    EditorPicBox.DisposeImage()
                End If

                If ViewPicBox._image IsNot Nothing Then
                    ViewPicBox.DisposeImage()
                End If
            End If


        Else

            If EditorPicBox._image IsNot Nothing Then
                EditorPicBox.DisposeImage()
            End If

            If ViewPicBox._image IsNot Nothing Then
                ViewPicBox.DisposeImage()
            End If


        End If
    End Sub

    Private Function AbortAction() As Boolean

        Dim abort As Boolean = False
        If isProjectDirty = True Then

            Dim dlgResult = MessageBox.Show(Me,
                                            "Project Is Not saved. Do you want To save And close?",
                                            "Save And Close Project",
                                            MessageBoxButtons.YesNoCancel)


            If dlgResult = DialogResult.Yes Then
                SaveProject(True)
            ElseIf dlgResult = DialogResult.Cancel Then
                abort = True
            End If

        End If

        Return abort
    End Function


    Private Sub ToolSaveWordList_Click(sender As Object, e As EventArgs) Handles ToolSaveWordList.Click

        If (isBusy = False And HocrPages IsNot Nothing AndAlso HocrPages.Count > 0) Then
            SaveProjectWordList()

        End If
    End Sub
    Private Sub ToolSaveWordFrequency_Click(sender As Object, e As EventArgs) Handles ToolSaveWordFrequency.Click

        If (isBusy = False And HocrPages IsNot Nothing AndAlso HocrPages.Count > 0) Then
            SaveProjectWordFrequency()

        End If


    End Sub

    Private Sub SentencesListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SentencesListToolStripMenuItem.Click
        If (isBusy = False And HocrPages IsNot Nothing AndAlso HocrPages.Count > 0) Then
            SaveProjectSentencesList()
        End If
    End Sub


    Private Sub ToolsImageOpen_Click(sender As Object, e As EventArgs) Handles ToolsImageOpen.Click
        If isBusy = False Then

            If AbortAction() = True Then
                Exit Sub
            End If

            Dim filter = "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg|PDF Files (*.pdf)|*.pdf"
            OpenAllFiles(filter)

        End If
    End Sub





    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click

        If isBusy = False Then
            If FilePaths.Count = 0 Then
                OpenProject()
            Else
                If AbortAction() = True Then
                    Exit Sub
                End If

                ResetMainWindow()
                OpenProject()

            End If
        End If

    End Sub
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If isBusy = False Then
            If FilePaths.Count = 0 Then
                OpenProject()
            Else
                If AbortAction() = True Then
                    Exit Sub
                End If
                ResetMainWindow()
                OpenProject()

            End If
        End If

    End Sub


    Private Sub OpenPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenPDFToolStripMenuItem.Click
        If isBusy = False Then

            If AbortAction() = True Then
                Exit Sub
            End If

            Dim filter = "PDF Files (*.pdf)|*.pdf| Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg"
            OpenAllFiles(filter)


        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If isBusy = False Then

            If AbortAction() = True Then
                Exit Sub
            End If

            Dim filter = "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg"
            OpenAllFiles(filter)

        End If
    End Sub


    Private Sub CloseProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseProjectToolStripMenuItem.Click
        If isBusy = False Then

            If isProjectDirty = True Then
                SaveProject(True)
            Else
                ResetMainWindow()
            End If

        End If
    End Sub

    Private Sub SaveAsAmhOCRProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsAmhOCRProjectToolStripMenuItem.Click
        If isBusy = False Then

            SaveProject()

        End If
    End Sub

    Private Sub SaveAsMSDOCFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsMSDOCFileToolStripMenuItem.Click
        If isBusy = False Then

            SaveAllasWord()

        End If
    End Sub

    Private Sub SaveAsSearchablePDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsSearchablePDFToolStripMenuItem.Click
        If isBusy = False Then

            hocrToSearchablePDF()

        End If
    End Sub

    Private Sub SaveAsTextFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsTextFileToolStripMenuItem.Click
        If isBusy = False Then
            SaveAllasText()

        End If
    End Sub


    Private Sub WordFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordFileToolStripMenuItem.Click
        If isBusy = False Then

            SaveAllasWord()

        End If
    End Sub
    Private Sub SearchablePDFToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveProjectToolStripMenuItem1.Click

        If isBusy = False Then

            hocrToSearchablePDF()

        End If
    End Sub
    Private Sub TextFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProjectCloseToolStripMenuItem.Click
        If isBusy = False Then
            SaveAllasText()

        End If
    End Sub


    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If isBusy = False Then

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


        End If


    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        If isBusy = False Then

            If AbortAction() = True Then
                Exit Sub
            End If

            Me.Close()
        End If

    End Sub


    Private Sub btnHideImpt_Click(sender As Object, e As EventArgs) Handles btnHideImpt.Click
        If btnImgTab.Visible = True Then
            btnImgTabClicked()
        Else
            ColapsImg()
        End If
    End Sub


    Private Sub ToolImgeListView_Click(sender As Object, e As EventArgs) Handles ToolImgeListView.Click

        If btnImgTab.Visible = True Then
            btnImgTabClicked()
        Else
            ColapsImg()
        End If



    End Sub



    Private Sub btnResetZoom_Click(sender As Object, e As EventArgs) Handles btnResetZoom.Click
        If EditorPicBox.Image IsNot Nothing Then
            EditorPicBox.ZoomReset()
            EditorPicBox.Invalidate()
        End If

        If ViewPicBox.Image IsNot Nothing Then
            ViewPicBox.ZoomReset()
            ViewPicBox.Invalidate()
        End If
    End Sub



    Private Sub ToolZoomResetMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolZoomReset.Click
        If EditorPicBox.Image IsNot Nothing Then
            EditorPicBox.ZoomReset()
            EditorPicBox.Invalidate()
        End If

        If ViewPicBox.Image IsNot Nothing Then
            ViewPicBox.ZoomReset()
            ViewPicBox.Invalidate()
        End If
    End Sub

    Private Sub MainWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try
            Directory.Delete(OCRsettings.AmhOcrTempFolder, True)
        Catch ex As Exception

        End Try

    End Sub



    Private Sub AboutAmhOCRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutAmhOCRToolStripMenuItem.Click
        If isBusy = False Then

            Dim aboutPage As New AboutPage

            aboutPage.StartPosition = FormStartPosition.Manual

            Try
                aboutPage.Location = Me.PointToScreen(New Point((Me.Width - aboutPage.Width) / 2, Me.Height / 5))
            Catch ex As Exception
                aboutPage.StartPosition = FormStartPosition.CenterParent
            End Try

            aboutPage.ShowDialog(Me)
        End If



    End Sub



#End Region




#Region "Main Parts"


    Private Sub ResetMainWindow()


        If Directory.Exists(OCRsettings.AmhOcrTempFolder) = False Then
            Directory.CreateDirectory(OCRsettings.AmhOcrTempFolder)
        End If

        isProjectDirty = False

        FilePaths = New List(Of String)

        If EditorPicBox.Image IsNot Nothing Then

            EditorPicBox.DisposeImage()
            EditorPicBox.ResetAllState()

        End If

        If ViewPicBox.Image IsNot Nothing Then
            ViewPicBox.DisposeImage()
        End If

        If HocrPages IsNot Nothing Then
            HocrPages = Nothing
            HocrPages = New List(Of HocrPage)
        End If


        If ListOpenedImages.Items.Count > 0 Then

            ListOpenedImages.Items.Clear()

        End If

        If ImageList IsNot Nothing Then
            ImageList.Dispose()
            ImageList = Nothing
        End If


        EditorPicBox.Invalidate()
        ViewPicBox.Invalidate()

        SplitInputResultView.Panel2Collapsed = True
        txtBoxResult.Text = ""

        OCRsettings.SetDefault()

        CmbLang.SelectedIndex = 0
        cmbEditMode.SelectedIndex = 0

    End Sub

    Public Sub EditModeChanged(ByVal sender As Object, ByVal e As EventArgs)
        If isBusy = False Then
            isBusy = True
            If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                cmbEditMode.SelectedIndex = 0
            Else
                cmbEditMode.SelectedIndex = 1
            End If
            EditorPicBox.SetEditorMode()
            EditorPicBox.Invalidate()
            isBusy = False
        End If

    End Sub
    Public Async Sub HocrEdited(ByVal sender As Object, ByVal e As EventArgs)
        isBusy = True
        If sender IsNot Nothing Then
            If EditorPicBox.HocrPage IsNot Nothing Then
                Try

                    Dim pg As Integer = EditorPicBox.HocrPage.PageNum
                    Dim HocrPag = HocrPages(pg)


                    Dim tsk = TaskEx.Run(
                        Sub()

                            If CType(sender, Integer) = ocrEditMode.WordEdit Then

                                HocrPag = HocrParser.UpdateWordToPage(HocrPag)

                            ElseIf CType(sender, Integer) = ocrEditMode.ParagraphEdit Then

                                HocrPag = HocrParser.UpdateparagraphToPage(HocrPag)

                            End If


                        End Sub)



                    Await tsk

                    isProjectDirty = True
                    HocrPages(pg) = HocrPag
                    txtBoxResult.Text = HocrPag.UTF8Text

                Catch ex As Exception

                End Try


            End If

        End If

        isBusy = False
    End Sub

    Public Sub RefreshPicViewBox(ByVal sender As Object, ByVal e As BoxHighlightedArg)

        If e IsNot Nothing Then

            If ViewPicBox.HighlightedBox <> e.box Then
                ViewPicBox.HighlightedBox = e.box
                ViewPicBox.Invalidate()
            End If
        Else
            If ViewPicBox.HighlightedBox.IsEmpty = False Then
                ViewPicBox.HighlightedBox = New Rectangle
                ViewPicBox.Invalidate()
            End If

        End If

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
                    Dim WordList = NLPaction.GetWordList(EditorPicBox.SpellCheker, HocrPages)
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
                    Dim WordFrequency = NLPaction.GetWordFrequency(EditorPicBox.SpellCheker, HocrPages)
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
                    Dim SentencesList = NLPaction.GetSentencesList(EditorPicBox.SpellCheker, HocrPages)
                    File.WriteAllText(sfb.FileName, SentencesList)
                End If

            End Using
        End If
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



    Public Sub RefreshLanguage()


        CmbLang.Items.Clear()

        AvailabelLangs = New List(Of String)
        Dim Files = Directory.GetFiles(OCRsettings.tesspath).OrderBy(Function(X) X)
        For Each file In Files
            Dim langname = Path.GetFileName(file)

            If langname.EndsWith(".traineddata") Then
                langname = langname.Replace(".traineddata", "")
                AvailabelLangs.Add(langname)
                CmbLang.Items.Add(langname)

            End If

        Next

        isBusy = True
        CmbLang.SelectedIndex = 0
        isBusy = False

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

                isBusy = True



                If ofd.FileNames.First.EndsWith(".pdf") Then

                    OpenMultiplePdfs(ofd.FileNames)

                Else

                    OpenMultipleImages(ofd.FileNames, False)

                End If

            End If

        End Using





    End Sub


    ''' <summary>
    ''' Open listview's selected image in imageviewcontrol
    ''' </summary>
    Private Sub OpenImage()


        If isBusy = False AndAlso EditorPicBox.isBusy = False Then

            If (ListOpenedImages.SelectedIndices.Count > 0) Then

                Dim indx = ListOpenedImages.SelectedIndices(0)
                Dim FileName = FilePaths(indx)

                If EditorPicBox.Image IsNot Nothing Then

                    EditorPicBox.DisposeImage()
                    EditorPicBox.ResetAllState()

                End If

                If ViewPicBox.Image IsNot Nothing Then

                    ViewPicBox.DisposeImage()

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




                Dim openImageName = FileName

                If File.Exists(thisHocrPage.imgCopyName) Then
                    openImageName = thisHocrPage.imgCopyName
                End If

                isRecognizOpen = False

                Using imgOp = Ag.Image.FromFile(openImageName)
                    imgOp.SetResolution(300, 300)

                    OCRsettings.Resolution = New Size(imgOp.HorizontalResolution, imgOp.VerticalResolution)
                    OCRsettings.PageSize = New Size(imgOp.Width, imgOp.Height)
                    thisHocrPage.SetSettings()

                    EditorPicBox.Image = imgOp.Clone
                    EditorPicBox.FileName = FileName

                    textSelctedImage.Text = ListOpenedImages.Items.Item(ListOpenedImages.SelectedIndices(0)).Text
                    SelectNameLbl.Text = FileName
                    SelectNameLbl.Text = "Image " + (ListOpenedImages.SelectedIndices(0) + 1).ToString + " Of " + TotalImagesCnt.ToString + "  " + FileName

                    ListOpenedImages.SelectedItems(0).EnsureVisible()

                    isBusy = True

                    CmbLang.SelectedIndex = AvailabelLangs.IndexOf(OCRsettings.Language)

                    isBusy = False

                    If thisHocrPage.Recognized Then
                        isRecognizOpen = True
                        RecognizeApage()
                    Else
                        SplitInputResultView.Panel2Collapsed = True
                    End If


                End Using


                EditorPicBox.Invalidate()

            End If
        End If


    End Sub


    Private Sub OpenImageWithHocr()

        OpenImage()


        If isRecognizOpen = False Then
            RecognizeApage()
        End If


    End Sub

    Private BatchOCRprog As BatchProgressControl
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



    Private Async Sub RecognizeFiles(ByVal FileNames() As String)

        CancelRequested = False

        isBusy = True


        Dim prog As New BatchProgressControl

        prog.Text = "Recognizing text from image"

        prog.StartPosition = FormStartPosition.Manual

        Try
            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try

        prog.ProgressBar1.Style = ProgressBarStyle.Blocks
        prog.ProgressBar1.Value = 0
        prog.ProgressBar1.Maximum = (FileNames.Count * 3)

        prog.Show(Me)
        prog.Invalidate()


        Await TaskEx.Delay(20)

        Dim prgCnt As Integer = 0
        Dim imgCnt As Integer = 0
        For Each FileName In FileNames

            If prog.IsPause = True Then
                prog.UpdateMainStatus(True)
                prog.Text = "Process Paused Recognizing Image " +
                    imgCnt.ToString + " out Of " + FileNames.Count.ToString

                prog.Invalidate()

                Do While prog.IsPause = True

                    Await TaskEx.Delay(10)

                    If (prog.CancelRequested = True) OrElse (CancelRequested = True) Then
                        Exit Do
                    End If

                Loop
                prog.lblStage.ForeColor = Color.Navy
                prog.lblProg.ForeColor = Color.Navy
                prog.Invalidate()
            End If



            If (prog.CancelRequested = True) OrElse (CancelRequested = True) Then
                Exit For
            End If



            Dim imgidx = FilePaths.IndexOf(FileName)
            ListOpenedImages.Items.Item(imgidx).Selected = True



            imgCnt += 1
            prgCnt += 1

            prog.Cursor = Cursors.Arrow
            prog.Text = "Recognizing: Image " + imgCnt.ToString + " of " + FileNames.Count.ToString
            prog.UpdateImageProgress(Path.GetFileName(FileName))


            prog.UpdateProgressBar(prgCnt)
            prog.UpdateSubProgress("Pre-Processing")

            Dim NewPages As HocrPage
            If HocrPages.Where(Function(X) X.ImageName = FileName).Count = 0 Then
                NewPages = New HocrPage
                NewPages.ImageName = FileName
                NewPages.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(FileName))
                NewPages.PageNum = HocrPages.Count
                HocrPages.Add(NewPages)
            End If

            NewPages = HocrPages.Where(Function(X) X.ImageName = FileName).Single
            NewPages.PageOCRsettings.Language = OCRsettings.Language
            Dim PageNumber As Integer = HocrPages.IndexOf(NewPages)


            'All image's pre-porcess setting will be applied to this image  


            Dim tessImagePath As String = NewPages.imgCopyName
            Dim MainImage As Bitmap

            If File.Exists(tessImagePath) Then
                MainImage = Ag.Image.FromFile(tessImagePath)
            Else
                MainImage = Ag.Image.FromFile(FileName)
            End If

            Dim RecoverImage As Bitmap = Ag.Image.Clone(MainImage)

            MainImage = Await PreProcessor.AsyncApplayCorrections(MainImage)
            MainImage.Save(tessImagePath)
            MainImage.Dispose()
            MainImage = Nothing


            prgCnt += 1
            prog.UpdateSubProgress("Processing")
            prog.UpdateProgressBar(prgCnt)

            Await TaskEx.Delay(10)

            NewPages = Await TessRecognize.Recognize(tessImagePath, NewPages)
            NewPages.ImageName = FileName
            NewPages.PageNum = PageNumber

            prgCnt += 1
            prog.UpdateSubProgress("Post-Processing")
            prog.UpdateProgressBar(prgCnt)
            NewPages = Await PostProcessor.Analyzepage(NewPages)


            RecoverImage.Save(tessImagePath)
            RecoverImage.Dispose()
            RecoverImage = Nothing

            HocrPages(NewPages.PageNum) = NewPages

            ListOpenedImages.Items.Item(imgidx).Checked = True

            isBusy = False
            OpenImage()
            Await TaskEx.Delay(5)
            isBusy = True
            isProjectDirty = True
        Next


        prog.Close()
        prog.Dispose()
        prog = Nothing

        If CancelRequested = True Then
            CancelRequested = False
            isBusy = False
            Me.Close()
        End If


        isBusy = False



    End Sub


    Private Async Sub RecognizeFileGroups(ByVal FileNames() As String)

        CancelRequested = False

        isBusy = True


        Dim prog As New BatchProgressControl

        prog.Text = "Recognizing text from batch of image"

        prog.StartPosition = FormStartPosition.Manual

        Try
            prog.Location = Me.PointToScreen(New Point((Me.Width - prog.Width) / 2, Me.Height / 5))
        Catch ex As Exception
            prog.StartPosition = FormStartPosition.CenterParent
        End Try

        prog.ProgressBar1.Style = ProgressBarStyle.Blocks
        prog.ProgressBar1.Value = 0
        prog.ProgressBar1.Maximum = (FileNames.Count * 3)

        prog.Show(Me)

        prog.Invalidate()


        Await TaskEx.Delay(20)

        Dim prgCnt As Integer = 0
        Dim imgCnt As Integer = 0




        Dim imgidx = FilePaths.IndexOf(FileNames.First)
        ListOpenedImages.Items.Item(imgidx).Selected = True






        prog.Cursor = Cursors.Arrow
        prog.Text = "Recognizing: Image From " +
            FilePaths.IndexOf(FileNames.First).ToString +
            " to " + FilePaths.IndexOf(FileNames.Last).ToString



        prog.UpdateSubProgress("Pre-Processing")

        Await TaskEx.Delay(5)
        Dim ProcessImageList As New List(Of String)
        Dim ProcessHocrsPages As New List(Of HocrPage)
        Dim pageNembers As New List(Of Integer)
        For Each FileName In FileNames
            Dim NewPages As HocrPage
            If HocrPages.Where(Function(X) X.ImageName = FileName).Count = 0 Then
                NewPages = New HocrPage
                NewPages.ImageName = FileName
                NewPages.imgCopyName = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileName(FileName))
                NewPages.PageNum = HocrPages.Count

                HocrPages.Add(NewPages)

            Else
                NewPages = HocrPages.Where(Function(X) X.ImageName = FileName).Single
            End If

            NewPages.PageOCRsettings.Language = OCRsettings.Language

            Dim tessImagePath As String = NewPages.imgCopyName
            If Not File.Exists(tessImagePath) Then

                Dim MainImage = Ag.Image.FromFile(FileName)
                NewPages.PageOCRsettings.PageSize = New Size(MainImage.Width, MainImage.Height)

                MainImage.Save(tessImagePath)
                MainImage.Dispose()
                MainImage = Nothing

            End If

            ProcessImageList.Add(tessImagePath)
            ProcessHocrsPages.Add(NewPages)
            pageNembers.Add(NewPages.PageNum)


            prgCnt += 1
            prog.UpdateProgressBar(prgCnt)
            Await TaskEx.Delay(5)
        Next







        prgCnt = 0
        prog.UpdateSubProgress("Processing")
        prog.UpdateProgressBar(prgCnt)

        Await TaskEx.Delay(10)
        prog.ProgressBar1.Style = ProgressBarStyle.Marquee
        ProcessHocrsPages = Await TessRecognize.Recognize(ProcessImageList, ProcessHocrsPages)


        prog.ProgressBar1.Style = ProgressBarStyle.Blocks
        prgCnt = 1
        prog.UpdateSubProgress("Post-Processing")
        prog.UpdateProgressBar(prgCnt)


        Await TaskEx.Delay(5)

        For page As Integer = 0 To ProcessHocrsPages.Count - 1
            Dim processPage = ProcessHocrsPages(page)
            Dim NewPages = HocrPages(pageNembers(page))
            NewPages = Await PostProcessor.Analyzepage(processPage)
            NewPages.PageNum = pageNembers(page)
            HocrPages(NewPages.PageNum) = NewPages
            If NewPages.Recognized = True Then
                ListOpenedImages.Items.Item(FilePaths.IndexOf(NewPages.ImageName)).Checked = True
            End If
            prog.UpdateProgressBar(page)
            Await TaskEx.Delay(5)
        Next




        ProcessHocrsPages = Nothing

        isProjectDirty = True

        prog.Close()
        prog.Dispose()
        prog = Nothing

        isBusy = False
        OpenImage()


    End Sub



    Private Async Sub RecognizeStepGroups(ByVal FileNames() As String, ByVal batch As Integer)

        Dim tsk = TaskEx.Run(
            Async Function() As Task(Of Boolean)

                For Each FileName In FileNames

                    If BatchOCRprog.IsPause = True Then

                        If (BatchOCRprog.CompletedProcess + 1) = BatchOCRprog.NumberOfProcess Then
                            BatchOCRprog.UpdateMainStatus(True)
                        End If

                        Do While BatchOCRprog.IsPause = True

                            Await TaskEx.Delay(5)

                            If (BatchOCRprog.CancelRequested = True) OrElse (CancelRequested = True) Then
                                Exit Do
                            End If

                        Loop

                        BatchOCRprog.UpdateMainStatus(False)

                    End If



                    If (BatchOCRprog.CancelRequested = True) OrElse (CancelRequested = True) Then
                        Exit For
                    End If


                    Dim NewPages = HocrPages.Where(Function(X) X.ImageName = FileName).Single
                    NewPages.PageOCRsettings.Language = OCRsettings.Language
                    Dim tessImagePath As String = NewPages.imgCopyName
                    Dim MainImage As Bitmap

                    If File.Exists(tessImagePath) Then
                        MainImage = Ag.Image.FromFile(tessImagePath)
                    Else
                        MainImage = Ag.Image.FromFile(FileName)
                    End If

                    Dim RecoverImage As Bitmap = Ag.Image.Clone(MainImage)



                    MainImage = Await PreProcessor.AsyncApplayCorrections(MainImage)
                    MainImage.Save(tessImagePath)
                    MainImage.Dispose()
                    MainImage = Nothing

                    NewPages = Await TessRecognize.Recognize(tessImagePath, NewPages)
                    NewPages.ImageName = FileName

                    NewPages = Await PostProcessor.Analyzepage(NewPages)
                    RecoverImage.Save(tessImagePath)
                    RecoverImage.Dispose()
                    RecoverImage = Nothing


                    BatchOCRprog.CompetedTasks += 1
                    BatchOCRprog.UpdateProgressBar(BatchOCRprog.CompetedTasks)
                    BatchOCRprog.UpdateProgressText(BatchOCRprog.CompetedTasks)

                    HocrPages(NewPages.PageNum) = NewPages

                    isProjectDirty = True

                Next


                Return True
            End Function)





        Await tsk

        BatchOCRprog.CompletedProcess += 1

        If BatchOCRprog.CompletedProcess = BatchOCRprog.NumberOfProcess Then

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

            NewPages = HocrPages.Where(Function(X) X.ImageName = FileName).Single
            NewPages.PageOCRsettings.Language = OCRsettings.Language

            Dim PageNumber As Integer = HocrPages.IndexOf(NewPages)


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

            'All image's pre-porcess setting will be applied to this image  

            Dim tessImagePath As String = NewPages.imgCopyName
            Dim MainImage As Bitmap

            If File.Exists(tessImagePath) Then
                MainImage = Ag.Image.FromFile(tessImagePath)
            Else
                MainImage = Ag.Image.FromFile(FileName)
            End If

            Dim RecoverImage As Bitmap = Ag.Image.Clone(MainImage)
            RecoverImage.SetResolution(NewPages.PageOCRsettings.Resolution.Width, NewPages.PageOCRsettings.Resolution.Height)
            prog.UpdateProgress("Pre-Processing")
            MainImage = Await PreProcessor.AsyncApplayCorrections(MainImage)
            MainImage.Save(tessImagePath)
            MainImage.Dispose()
            MainImage = Nothing


            prog.UpdateProgress("Processing")
            NewPages = Await TessRecognize.Recognize(tessImagePath, NewPages)
            NewPages.ImageName = FileName
            NewPages.PageNum = PageNumber


            prog.UpdateProgress("Post-Processing")
            NewPages = Await PostProcessor.Analyzepage(NewPages)

            RecoverImage.Save(tessImagePath)
            RecoverImage.Dispose()
            RecoverImage = Nothing

            HocrPages(NewPages.PageNum) = NewPages
            ListOpenedImages.Items.Item(FilePaths.IndexOf(FileName)).Checked = True


            prog.Dispose()
            prog = Nothing
            Await TaskEx.Delay(300)

            isProjectDirty = True
        Else

            NewPages = HocrPages.Where(Function(X) X.ImageName = FileName).First
        End If


        If NewPages IsNot Nothing Then

            If Me.WindowState <> FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Maximized
            End If


            If SplitInputResultView.Panel2Collapsed = True Then
                SplitInputResultView.Panel2Collapsed = False
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



            txtBoxResult.Font = OCRsettings.ocrFont.Clone
            txtBoxResult.Text = NewPages.UTF8Text

            ViewPicBox.Image = EditorPicBox.Image.Clone

            EditorPicBox.HocrPage = NewPages

            EditorPicBox.ZoomReset()
            ViewPicBox.ZoomReset()
            EditorPicBox.Invalidate()
            ViewPicBox.Invalidate()
            EditorPicBox.Select()
            EditorPicBox.Focus()

        End If


        isBusy = False

    End Sub


    Private Sub OpenMultipleImages(ByVal FileNames() As String, ByVal projectopen As Boolean)




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

                         Using imgOp As Bitmap = New Bitmap(imgname)

                             imgOp.SetResolution(300, 300)

                             FilePaths.Add(imgname)

                             ImageList.Images.Add(imgOp.Clone)

                             Dim itm = ListOpenedImages.Items.Add(Path.GetFileName(imgname), TotalImagesCnt)
                             itm.EnsureVisible()
                             itm.ForeColor = Color.White
                             prog.Text = "Loading image " + TotalImagesCnt.ToString + " out of " + FileNames.Count.ToString
                             prog.UpdateProgress(Path.GetFileName(imgname), TotalImagesCnt)

                             If projectopen = True Then

                                 If HocrPages.Where(Function(X) X.ImageName = imgname).Count = 0 Then


                                     Dim hocrfile = Path.Combine(OCRsettings.ProjectTempFolder, Path.GetFileNameWithoutExtension(imgname) + ".hocr")

                                     If File.Exists(hocrfile) Then
                                         prog.UpdateProgress(Path.GetFileName(hocrfile))

                                         Dim thisHocrPage As HocrPage
                                         thisHocrPage = New HocrPage
                                         thisHocrPage.PageOCRsettings.Resolution = New Size(imgOp.HorizontalResolution, imgOp.VerticalResolution)

                                         thisHocrPage.PageOCRsettings.PageSize = New Size(imgOp.Width, imgOp.Height)
                                         thisHocrPage.HocrXML = XElement.Parse(File.ReadAllText(hocrfile))
                                         thisHocrPage = Await TessRecognize.ParseHocr(thisHocrPage)
                                         thisHocrPage = Await PostProcessor.Analyzepage(thisHocrPage)
                                         thisHocrPage.PageNum = HocrPages.Count
                                         thisHocrPage.ImageName = imgname
                                         thisHocrPage.imgCopyName = imgname

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

    Private Async Sub OpenMultiplePdfs(ByVal FileNames() As String)



        Dim Pdf2imgFiles As New List(Of String)

        Try



            Pdf2imgFiles = Await readGhost(FileNames)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        If Pdf2imgFiles.Count > 0 Then

            OCRsettings.ProjectTempFolder = Path.GetDirectoryName(Pdf2imgFiles.First)
            OpenMultipleImages(Pdf2imgFiles.ToArray, True)


        End If

    End Sub

    Private Async Function readGhost(ByVal fileNames As String()) As Task(Of List(Of String))
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
                ProgrImpor.TopMost = True

                ProgrImpor.Show(Me)


                If (Await ProgrImpor.readGhost(fileNames)) = True Then

                    ProgrImpor.ProgressBar1.Visible = False

                    ProgrImpor.progLabl.Text = "Completed"
                    AllFileCopy = ProgrImpor.GetFiles()
                    ProgrImpor.Close()
                End If


            End Using

        Catch ex As Exception
            MsgBox(ex)
            AllFileCopy.Clear()
        End Try




        Return AllFileCopy
    End Function


    Private Async Sub CropImage()


        If isRecognizOpen = False Then
            Try

                Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName
                isProjectDirty = True
                If (EditorPicBox.State = controlState.None) AndAlso
                    (EditorPicBox.PreviouscontrolState = controlState.DrawRect) AndAlso
                    ((EditorPicBox.BoxRectangle.Width * EditorPicBox.BoxRectangle.Height) <> 0) Then

                    Dim imgOp As Bitmap = EditorPicBox.Image.Clone


                    Dim tsk = TaskEx.Run(
                        Sub()

                            PreProcessor.CropImage(imgOp, EditorPicBox.BoxRectangle)
                            imgOp.Save(SaveName)

                        End Sub)


                    Await tsk

                    EditorPicBox.DisposeImage()
                    EditorPicBox.ResetAllState()
                    EditorPicBox.Image = imgOp.Clone
                    imgOp.Dispose()
                    imgOp = Nothing
                    EditorPicBox.Invalidate()
                    OCRsettings.SourceImagaChenged = True
                Else
                    MsgBox("image area Not Selected. Please hold CTRL And select image area to crop.")
                End If

            Catch ex As Exception

            End Try

        Else
            MsgBox("Can't crop recognized Image. please reset image first")
        End If

    End Sub


    Private Async Sub DeskewImage()


        If isRecognizOpen = False Then



            Try
                isProjectDirty = True
                Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName

                Dim imgOp As Bitmap = EditorPicBox.Image.Clone
                Dim Angle = PreProcessor.skewAngle(imgOp.Clone)

                Dim tsk = TaskEx.Run(Sub()
                                         PreProcessor.Rotate(imgOp, 0 - Angle)
                                         imgOp.Save(SaveName)
                                     End Sub)


                Await tsk

                EditorPicBox.DisposeImage()
                EditorPicBox.ResetAllState()
                EditorPicBox.Image = imgOp.Clone
                imgOp.Dispose()
                imgOp = Nothing
                EditorPicBox.Invalidate()
                OCRsettings.SourceImagaChenged = True

            Catch ex As Exception

            End Try

        Else
            MsgBox("Can't Rotate recognized Image. please reset image first")
        End If

    End Sub



    Private Async Sub RotateImage(ByVal direction As Boolean)


        If isRecognizOpen = False Then

            Try


                isProjectDirty = True
                Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName
                Dim imgOp As Bitmap = EditorPicBox.Image.Clone


                Dim tsk As Task


                If direction = True Then


                    tsk = TaskEx.Run(
                        Sub()

                            PreProcessor.RotateRight(imgOp)
                            imgOp.Save(SaveName)

                        End Sub)

                Else

                    tsk = TaskEx.Run(
                        Sub()

                            PreProcessor.RotateLeft(imgOp)
                            imgOp.Save(SaveName)

                        End Sub)

                End If


                Await tsk

                EditorPicBox.DisposeImage()
                EditorPicBox.ResetAllState()
                EditorPicBox.Image = imgOp.Clone

                imgOp.Dispose()
                imgOp = Nothing
                EditorPicBox.Invalidate()
                OCRsettings.SourceImagaChenged = True

            Catch ex As Exception

            End Try

        Else
            MsgBox("Can't Rotate recognized Image. please reset image first")
        End If

    End Sub


    Private Sub ApplySetting()


        If isRecognizOpen = False Then
            isBusy = True
            Dim Prpro As New ImageOCRsetting
            Prpro.Text += Path.GetFileName(EditorPicBox.FileName)
            Prpro.txtLang.Text = CmbLang.Text
            Prpro.MyViewer = EditorPicBox
            Prpro.InitializeImage(EditorPicBox.Image.Clone, HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName))

            AddHandler Prpro.FormClosed,
                New FormClosedEventHandler(
                Sub(s, e)
                    isBusy = False
                    ListOpenedImages.Items.Item(Prpro._MainHocrPage.PageNum).Selected = True
                    EditorPicBox.Image = Prpro._MainImage.Clone
                    Prpro._MainImage.Dispose()
                    Prpro._MainImage = Nothing
                    EditorPicBox.Invalidate()
                End Sub)


            Prpro.Show(Me)
            Prpro.Invalidate()

        Else
            MsgBox("Can't process recognized Image. please reset first")
        End If

    End Sub





















































#End Region




End Class