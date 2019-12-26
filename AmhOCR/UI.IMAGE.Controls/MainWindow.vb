
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




    ''' <summary>
    ''' Signals if the project data has been modifid
    ''' </summary>
    Private isProjectDirty As Boolean = False

    ''' <summary>
    ''' Flags user want to abort long async operation 
    ''' </summary>
    Public CancelRequested As Boolean = False

    ''' <summary>
    ''' Signals for main control state  
    ''' </summary>
    Public isBusy As Boolean = False

    ''' <summary>
    ''' Signals that opend image is already OCRed 
    ''' </summary>
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

    Friend HocrPicBox As HocrEditControl


#End Region


#Region "Initilize and Settings"

    Private Sub Initialize()


        OCRsettings.AcceptedImageFormat = New List(Of Imaging.PixelFormat)
        OCRsettings.ExcludedImageFormat = New List(Of Imaging.PixelFormat)

        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format16bppRgb555)
        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format16bppRgb565)
        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format24bppRgb)
        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format32bppArgb)
        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format32bppPArgb)
        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format32bppRgb)
        OCRsettings.AcceptedImageFormat.Add(PixelFormat.Format48bppRgb)




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


        FilePaths = New List(Of String)


        HocrPicBox = New HocrEditControl

        SplitInputResultView.Panel1.Controls.Add(HocrPicBox)

        HocrPicBox.Dock = DockStyle.Fill
        HocrPicBox.BackColor = Color.DimGray
        HocrPicBox.Capture = True

        EditorPicBox = New ImageEditControl

        SplitTextResultView.Panel1.Controls.Add(EditorPicBox)
        EditorPicBox.Dock = DockStyle.Fill
        EditorPicBox.BackColor = Color.DimGray




        ToolStripContainer1.TopToolStripPanel.Controls.Add(ToolsMainWindow)
        ToolStripContainer1.TopToolStripPanel.Controls.Add(ImagesToolStrip)
        ToolStripContainer1.TopToolStripPanel.Controls.Add(OCRToolStrips)

        Try

            ImagesToolStrip.Location = New Point(ToolsMainWindow.Right + 2, ToolsMainWindow.Top)
            OCRToolStrips.Location = New Point(ImagesToolStrip.Right + 2, ImagesToolStrip.Top)

        Catch ex As Exception

        End Try




        ' Set the lbl control which will be used to display the mouse coordinate over this control
        HocrPicBox.Label = lblCoordinate
        EditorPicBox.Label = lblCoordinate


        ImageList = New ImageList
        ImageList.ImageSize = New Size(132, 172)

        HocrPages = New List(Of HocrPage)




        btnImgTab.Visible = True


        cmbEditMode.Items.Clear()

        ' OCRsettings.EditMode, only two mode currently implimented

        cmbEditMode.Items.Add("Word Level Edit")
        cmbEditMode.Items.Add("Line Level Edit")
        cmbEditMode.Items.Add("Paragraph Level Edit")
        cmbEditMode.SelectedIndex = 0

        'Get languages available in tessdata path
        RefreshLanguage()

        'Initilize user perefrences
        LoadUserPreferances()


        OCRsettings.Language = OCRsettings.PrefLanguage
        OCRsettings.TimeOut = OCRsettings.PrefTimeOut
        OCRsettings.MaxBatch = OCRsettings.PrefMaxBatch
        OCRsettings.SpellErrorColor = OCRsettings.PrefSpellErrorColor
        OCRsettings.UserSpelledColor = OCRsettings.PrefUserSpelledColor
        OCRsettings.Binaries = OCRsettings.PrefBinary

        If AvailabelLangs.Contains(OCRsettings.Language) Then
            isBusy = True

            Dim langindx = AvailabelLangs.IndexOf(OCRsettings.Language)
            AvailabelLangs.RemoveAt(langindx)
            AvailabelLangs.Insert(0, OCRsettings.Language)

            CmbLang.Items.RemoveAt(langindx)
            CmbLang.Items.Insert(0, OCRsettings.Language)
            CmbLang.SelectedIndex = 0
            isBusy = False

        Else

            OCRsettings.Language = AvailabelLangs(0)
            OCRsettings.PrefLanguage = OCRsettings.Language

        End If


        If OCRsettings.Language = "amh" Then
            OCRsettings.ocrFont = OCRsettings.AmhocrFont.Clone
        Else
            OCRsettings.ocrFont = OCRsettings.DefaultocrFont.Clone
        End If




        AddHandler TreeContextOpen.Click, AddressOf OpenImage
        AddHandler TreeContextOpenDetect.Click, AddressOf OpenImageWithHocr
        AddHandler TreeContextReset.Click, AddressOf ResetImageRecognition


        AddHandler TreeContextSaveAs.DropDownOpening,
            New EventHandler(
            Sub(s, e)
                If ListOpenedImages.SelectedIndices.Count > 0 Then

                    If ListOpenedImages.Items.Item(ListOpenedImages.SelectedIndices(0)).Checked Then
                        TreeContextSaveAs.DropDownItems(0).Enabled = True
                        TreeContextSaveAs.DropDownItems(1).Enabled = True
                        TreeContextSaveAs.DropDownItems(2).Enabled = True

                    Else
                        TreeContextSaveAs.DropDownItems(0).Enabled = False
                        TreeContextSaveAs.DropDownItems(1).Enabled = False
                        TreeContextSaveAs.DropDownItems(2).Enabled = False



                    End If

                End If
            End Sub)

        AddHandler TreeContextSaveAs.DropDownItems(0).Click, AddressOf SavepageAsWord
        AddHandler TreeContextSaveAs.DropDownItems(1).Click, AddressOf SaveAsSearchablePDF
        AddHandler TreeContextSaveAs.DropDownItems(2).Click, AddressOf SavepageAsText

        ' lambda procedure, ContextMenuListView Can only be shown during recognition and processing state

        AddHandler ImagelistContextMenu.Opening,
            New CancelEventHandler(
            Sub(s, e)

                If (FilePaths.Count = 0) OrElse
                   (isBusy = True) OrElse
                   (HocrPicBox.isBusy = True) OrElse
                   ListOpenedImages.SelectedIndices.Count = 0 Then

                    e.Cancel = True
                Else

                    If HocrPages.Any(Function(X) X.ImageName = FilePaths(ListOpenedImages.SelectedIndices(0))) Then
                        TreeContextReset.Enabled = True
                    Else
                        TreeContextReset.Enabled = False

                    End If
                End If


            End Sub)




        AddHandler EditorPicBox.BoxHighlightedEvent, AddressOf OCRObjectSelection

        AddHandler EditorPicBox.RecognizeAs, AddressOf RecognizeNewBox

        AddHandler EditorPicBox.DeskewImageEvent, AddressOf DeskewSelection
        AddHandler EditorPicBox.InvertImageEvent, AddressOf InvertImage
        AddHandler EditorPicBox.ClearAreaEvent, AddressOf ClearImageArea
        AddHandler EditorPicBox.CropAreaEvent, AddressOf CropImageArea


        AddHandler EditorPicBox.StartImageMoveEvent, AddressOf StartImageMove
        AddHandler EditorPicBox.ImageShiftedEvent, AddressOf ImageShift

        AddHandler EditorPicBox.ImageAreaEvent, AddressOf SetAsImageArea
        AddHandler EditorPicBox.TabelAreaEvent, AddressOf SetAsImageArea




        AddHandler HocrPicBox.BoxHighlightedEvent, AddressOf OCRObjectSelection
        AddHandler HocrPicBox.EditModeChanged, AddressOf EditModeChanged

        AddHandler HocrPicBox.RemoveObjectEvent, AddressOf RemoveHocrElement



        AddHandler HocrPicBox.RecognizeAs, AddressOf RecognizeNewBox
        AddHandler HocrPicBox.reRecognizeArea, AddressOf ReRecognizeBox

        AddHandler HocrPicBox.HocrEdited, AddressOf HocrEdited
        AddHandler HocrPicBox.OCRObjectSet, AddressOf OCRobjectSet

        AddHandler HocrPicBox.DeskewImageEvent, AddressOf DeskewSelection
        AddHandler HocrPicBox.InvertImageEvent, AddressOf InvertImage
        AddHandler HocrPicBox.ClearAreaEvent, AddressOf ClearImageArea
        AddHandler HocrPicBox.CropAreaEvent, AddressOf CropImageArea




        AddHandler HocrPicBox.StartImageMoveEvent, AddressOf StartImageMove
        AddHandler HocrPicBox.ImageShiftedEvent, AddressOf ImageShift


        AddHandler HocrPicBox.ImageAreaEvent, AddressOf SetAsImageArea
        AddHandler HocrPicBox.TabelAreaEvent, AddressOf SetAsImageArea


        Me.Cursor = Cursors.Arrow

    End Sub


    Private Sub Creat_SavePreference()

        Dim PrefFilePath = Path.Combine(OCRsettings.AmhOcrDataFolder, "preference.amhocrsetting")

        Dim txtLines(8) As String
        txtLines.Initialize()
        txtLines(0) = OCRsettings.PrefLanguage
        txtLines(1) = OCRsettings.PrefTimeOut.ToString
        txtLines(2) = OCRsettings.PrefMaxBatch.ToString
        txtLines(3) = OCRsettings.PrefSpellErrorColor.ToArgb.ToString
        txtLines(4) = OCRsettings.PrefUserSpelledColor.ToArgb.ToString
        txtLines(5) = CInt(OCRsettings.PrefBinary).ToString
        txtLines(6) = CInt(OCRsettings.RemoveWhiteListChar).ToString
        txtLines(7) = CInt(OCRsettings.NormalizeChar).ToString
        txtLines(8) = CInt(OCRsettings.NormalizeNumerics).ToString
        Try

            File.WriteAllLines(PrefFilePath, txtLines)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadUserPreferances()

        Dim PrefFilePath = Path.Combine(OCRsettings.AmhOcrDataFolder, "preference.amhocrsetting")

        If File.Exists(PrefFilePath) = True Then

            Try

                Dim txtLines = File.ReadAllLines(PrefFilePath)

                For ln As Integer = 0 To txtLines.Count - 1 Step 1

                    If ln = 0 Then

                        Dim OldPref = OCRsettings.PrefLanguage

                        OCRsettings.PrefLanguage = txtLines(ln)

                        If Not AvailabelLangs.Contains(OCRsettings.PrefLanguage) Then
                            OCRsettings.PrefLanguage = OldPref
                        End If


                    ElseIf ln = 1 Then

                        OCRsettings.PrefTimeOut = CInt(txtLines(ln))

                    ElseIf ln = 2 Then

                        OCRsettings.PrefMaxBatch = CInt(txtLines(ln))

                    ElseIf ln = 3 Then

                        OCRsettings.PrefSpellErrorColor = Color.FromArgb(CInt(txtLines(ln)))


                    ElseIf ln = 4 Then

                        OCRsettings.PrefUserSpelledColor = Color.FromArgb(CInt(txtLines(ln)))

                    ElseIf ln = 5 Then

                        OCRsettings.PrefBinary = CInt(txtLines(ln))

                    ElseIf ln = 6 Then

                        OCRsettings.RemoveWhiteListChar = CInt(txtLines(ln))

                    ElseIf ln = 7 Then

                        OCRsettings.NormalizeChar = CInt(txtLines(ln))

                    ElseIf ln = 8 Then

                        OCRsettings.NormalizeNumerics = CInt(txtLines(ln))

                    End If

                Next

            Catch ex As Exception

            End Try


        Else

            Creat_SavePreference()

        End If


    End Sub

    Private Sub ApplyUserPreferances()

        Creat_SavePreference()

        isBusy = True
        Dim oldLag As String = CmbLang.SelectedItem

        AvailabelLangs.Remove(OCRsettings.PrefLanguage)
        AvailabelLangs.Insert(0, OCRsettings.PrefLanguage)

        CmbLang.Items.Clear()

        For Each lng In AvailabelLangs
            CmbLang.Items.Add(lng)
        Next

        CmbLang.SelectedItem = oldLag


        OCRsettings.TimeOut = OCRsettings.PrefTimeOut
        OCRsettings.MaxBatch = OCRsettings.PrefMaxBatch
        OCRsettings.SpellErrorColor = OCRsettings.PrefSpellErrorColor
        OCRsettings.UserSpelledColor = OCRsettings.PrefUserSpelledColor
        OCRsettings.Binaries = OCRsettings.PrefBinary
        OCRsettings.Language = OCRsettings.PrefLanguage

        CmbLang.SelectedIndex = 0
        Dim Reopen As Boolean = False
        isBusy = False
        If HocrPages IsNot Nothing Then

            For pg As Integer = 0 To HocrPages.Count - 1 Step 1

                Dim HocrP = HocrPages(pg)

                If HocrP.Recognized = False OrElse HocrP.AllocrCarea.Count = 0 Then

                    Dim pgSetting = HocrP.PageOCRsettings

                    If pgSetting.Binaries <> OCRsettings.Binaries Then

                        If File.Exists(HocrP.imgCopyName) Then



                            Try

                                File.Delete(HocrP.imgCopyName)

                                If Reopen = False Then
                                    If HocrP.ImageName = FilePaths(ListOpenedImages.SelectedIndices(0)) Then
                                        Reopen = True
                                    End If

                                End If


                            Catch ex As Exception

                            End Try




                        End If



                    End If


                    pgSetting.ResetSetting()

                    HocrP.PageOCRsettings = pgSetting

                    HocrPages(pg) = HocrP

                End If

            Next

        End If

        If Reopen = True Then
            OpenImage()
        End If


    End Sub

    Private Sub ResetMainWindow()



        If Directory.Exists(OCRsettings.AmhOcrTempFolder) = False Then

            Directory.CreateDirectory(OCRsettings.AmhOcrTempFolder)

        End If



        isProjectDirty = False

        FilePaths = New List(Of String)

        If HocrPicBox.Image IsNot Nothing Then

            HocrPicBox.DisposeImage()
            HocrPicBox.ResetAllState()
            HocrPicBox.CancelState()

        End If

        HocrPicBox.HocrActive = False

        If EditorPicBox.Image IsNot Nothing Then
            EditorPicBox.DisposeImage()

        End If

        EditorPicBox.HocrActive = False

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

        RedoImageList = New List(Of Image)
        UndoImageList = New List(Of Image)
        UndoType = New List(Of UndoType)
        RedoType = New List(Of UndoType)
        UndoRotationData = New List(Of Double)
        RedoRotationData = New List(Of Double)
        btnUndo.Enabled = False
        btnRedo.Enabled = False

        btnSaveImage.Enabled = False

        btnAppenedFile.Enabled = False
        btnResetRecog.Enabled = False

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()

        SplitInputResultView.Panel1Collapsed = True
        txtBoxResult.Text = ""

        OCRsettings.SetDefault()

        CmbLang.SelectedIndex = 0
        cmbEditMode.SelectedIndex = 0

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

    Public Sub EditModeChanged(ByVal sender As Object, ByVal e As EventArgs)
        If isBusy = False Then
            isBusy = True

            If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                cmbEditMode.SelectedIndex = 0
            ElseIf OCRsettings.EditMode = ocrEditMode.LineEdit Then
                cmbEditMode.SelectedIndex = 1
            Else
                cmbEditMode.SelectedIndex = 2
            End If

            HocrPicBox.SetEditorMode()
            HocrPicBox.Invalidate()
            isBusy = False
        End If

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




    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click

        If isBusy = False AndAlso HocrPicBox.isBusy = False AndAlso AvailabelLangs.Count > 0 Then




            Dim userPref As New UserPreference
            For Each lng In AvailabelLangs
                userPref.cmbLang.Items.Add(lng)
            Next

            userPref.cmbLang.SelectedIndex = AvailabelLangs.IndexOf(OCRsettings.PrefLanguage)
            userPref.numTimeout.Value = CDec(OCRsettings.PrefTimeOut / (60 * 1000))
            userPref.numThreadNumber.Value = OCRsettings.PrefMaxBatch
            userPref.lblSpellColor.BackColor = OCRsettings.PrefSpellErrorColor
            userPref.lblUserColor.BackColor = OCRsettings.PrefUserSpelledColor
            userPref.chkBinary.Checked = OCRsettings.PrefBinary
            userPref.chkWhitelisted.Checked = OCRsettings.RemoveWhiteListChar
            userPref.chkNormChar.Checked = OCRsettings.NormalizeChar
            userPref.chkNormNumerics.Checked = OCRsettings.NormalizeNumerics

            If userPref.ShowDialog(Me) = DialogResult.OK Then

                OCRsettings.PrefLanguage = userPref.cmbLang.Items(userPref.cmbLang.SelectedIndex)
                OCRsettings.PrefTimeOut = userPref.numTimeout.Value * 60 * 1000
                OCRsettings.PrefMaxBatch = CInt(userPref.numThreadNumber.Value)
                OCRsettings.PrefSpellErrorColor = userPref.lblSpellColor.BackColor
                OCRsettings.PrefUserSpelledColor = userPref.lblUserColor.BackColor
                OCRsettings.PrefBinary = userPref.chkBinary.Checked
                OCRsettings.RemoveWhiteListChar = userPref.chkWhitelisted.Checked
                OCRsettings.NormalizeChar = userPref.chkNormChar.Checked
                OCRsettings.NormalizeNumerics = userPref.chkNormNumerics.Checked
                ApplyUserPreferances()

            End If


        End If

    End Sub





#End Region


#Region "Main User interfaces"

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Application.EnableVisualStyles()
        ' InitializeComponent()

        MainSplitContainer.Panel1Collapsed = True
        SplitInputResultView.Panel1Collapsed = True
        SplitTextResultView.Panel2Collapsed = True
        Initialize()

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

                If HocrPicBox._image IsNot Nothing Then
                    HocrPicBox.DisposeImage()
                End If
            End If


        Else

            If EditorPicBox._image IsNot Nothing Then
                EditorPicBox.DisposeImage()
            End If

            If HocrPicBox._image IsNot Nothing Then
                HocrPicBox.DisposeImage()
            End If


        End If
    End Sub

    Private Sub MainWindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try
            Directory.Delete(OCRsettings.AmhOcrTempFolder, True)
        Catch ex As Exception

        End Try

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


    Private Sub ViewNextPage(ByVal sender As Object, ByVal e As EventArgs)

        Dim Searcher = CType(sender, SearcheTool)
        If (Searcher.imgs IsNot Nothing) AndAlso (Searcher.imgs.Count > 0) Then

            Dim idx = ListOpenedImages.SelectedIndices(0)
            idx += 1
            idx = idx Mod Searcher.imgs.Count
            ListOpenedImages.Items(idx).Selected = True
            EditorPicBox.Image = Searcher.imgs(idx).Clone
            ListOpenedImages.Items(idx).EnsureVisible()

            If SplitInputResultView.Panel2Collapsed = False Then
                SplitInputResultView.Panel2Collapsed = True
            End If

        End If




    End Sub


    Private Sub ViewPreviousPage(ByVal sender As Object, ByVal e As EventArgs)
        Dim Searcher = CType(sender, SearcheTool)
        If (Searcher.imgs IsNot Nothing) AndAlso (Searcher.imgs.Count > 0) Then

            Dim idx = ListOpenedImages.SelectedIndices(0)
            idx -= 1
            If idx < 0 Then
                idx += Searcher.imgs.Count
            End If

            ListOpenedImages.Items(idx).Selected = True
            EditorPicBox.Image = Searcher.imgs(idx).Clone
            ListOpenedImages.Items(idx).EnsureVisible()
            If SplitInputResultView.Panel2Collapsed = False Then
                SplitInputResultView.Panel2Collapsed = True
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


    Private Sub btnResetRecog_Click(sender As Object, e As EventArgs) Handles btnResetRecog.Click

        If isBusy = False AndAlso HocrPicBox.isBusy = False AndAlso HocrPicBox.Image IsNot Nothing Then

            If HocrPages.Any(Function(X) X.ImageName = HocrPicBox.FileName) Then

                Dim FileNmae = HocrPicBox.FileName
                If isRecognizOpen = True Then
                    Dim dlgResult = MessageBox.Show(Me,
                               "This Image is already recognized. Do you want to Reset it? ",
                               "Reset image",
                               MessageBoxButtons.YesNo)


                    If dlgResult = DialogResult.Yes Then
                        HocrReset(FileNmae)
                    End If

                    Exit Sub

                Else

                    HocrReset(FileNmae)

                End If





            End If

        End If

    End Sub


    Private Sub btnRecogCurrent_Click(sender As Object, e As EventArgs) Handles btnRecognizeCurrent.Click

        If isBusy = False Then
            RecognizeApage()
        End If


    End Sub



    Private Sub cmbEditMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEditMode.SelectedIndexChanged
        If isBusy = False Then
            If cmbEditMode.SelectedIndex = 0 Then
                OCRsettings.EditMode = ocrEditMode.WordEdit
            ElseIf cmbEditMode.SelectedIndex = 1 Then
                OCRsettings.EditMode = ocrEditMode.LineEdit
            ElseIf cmbEditMode.SelectedIndex = 2 Then
                OCRsettings.EditMode = ocrEditMode.ParagraphEdit
            End If

            If HocrPicBox IsNot Nothing Then
                HocrPicBox.SetEditorMode()
                HocrPicBox.Invalidate()
            End If

        End If

    End Sub



    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                ImageSetting()

            End If

        End If
    End Sub

    Private Sub btnSelectionBox_Click(sender As Object, e As EventArgs) Handles btnSelectionBox.Click

        If isBusy = False AndAlso HocrPicBox.isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then

                If HocrPicBox.HocrPage IsNot Nothing AndAlso
                   HocrPicBox.State = controlState.None Then


                    HocrPicBox.State = controlState.SelectionStart
                    HocrPicBox.Cursor = Cursors.Cross


                    HocrPicBox.Invalidate()

                End If



            End If


        End If

    End Sub


    Private Sub btnboxdraw_Click(sender As Object, e As EventArgs) Handles btnboxdraw.Click

        If isBusy = False AndAlso HocrPicBox.isBusy = False Then

            If HocrPicBox.HocrPage IsNot Nothing Then

                If HocrPicBox.State = controlState.ObjectSelection OrElse
                       HocrPicBox.State = controlState.MultiHocrSelection Then

                    HocrPicBox.EndRegionEdit()

                ElseIf HocrPicBox.State <> controlState.None Then
                    Exit Sub
                End If

                HocrPicBox.State = controlState.ObjectSelection

                HocrPicBox.State = controlState.DrawRectStart
                HocrPicBox.Cursor = Cursors.Cross


                HocrPicBox.Invalidate()

            ElseIf EditorPicBox.Image IsNot Nothing Then

                If EditorPicBox.State = controlState.ObjectSelection Then

                    EditorPicBox.EndRegionEdit()

                ElseIf HocrPicBox.State <> controlState.None Then
                    Exit Sub
                End If

                EditorPicBox.State = controlState.DrawRectStart
                EditorPicBox.Cursor = Cursors.Cross


                EditorPicBox.Invalidate()


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

    Private Sub CropImageArea(ByVal sender As Object, ByVal e As EventArgs)

        If sender.GetType.Name = "ImageEditControl" Then

            CropImage(EditorPicBox.BoxRectangle)

        ElseIf sender.GetType.Name = "HocrEditControl" Then

            CropImage(HocrPicBox.BoxRectangle)

        End If


    End Sub
    Private Sub btnCrop_Click(sender As Object, e As EventArgs) Handles btnCrop.Click

        If EditorPicBox.State = controlState.ObjectSelection AndAlso
                        Not EditorPicBox.BoxRectangle.IsEmpty Then


            CropImage(EditorPicBox.BoxRectangle)


        End If


    End Sub



    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        If isBusy = False Then

            If EditorPicBox.Image IsNot Nothing Then
                ImageSetting()

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
                If EditorPicBox.State = controlState.ObjectSelection AndAlso
                           Not EditorPicBox.BoxRectangle.IsEmpty Then


                    CropImage(EditorPicBox.BoxRectangle)


                End If

            End If

        End If

    End Sub


    Private Sub SplitTiffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitTiffToolStripMenuItem.Click

        If isBusy = False Then
            SplitTiff()
        End If

    End Sub

    Private Sub MergeTiffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeTiffToolStripMenuItem.Click

        If isBusy = False Then

            MergeTiff()

        End If



    End Sub



    Private Sub ImageToPDFTool_Click(sender As Object, e As EventArgs) Handles ImageToPDFToolStripMenuItem.Click

        If isBusy = False Then
            ImageToPDF()
        End If

    End Sub



    Private Sub SplitPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SplitPDFToolStripMenuItem.Click

        If isBusy = False Then

            SplitPDF()

        End If

    End Sub

    Private Sub CombinePDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CombinePDFToolStripMenuItem.Click

        If isBusy = False Then

            CombinePDF()

        End If


    End Sub



    Private Sub PDFToImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToImageToolStripMenuItem.Click


        If isBusy = False Then

            PDFToImage()

        End If





    End Sub

    Private Sub btnConvertImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnConvertImages.Click

        If isBusy = False Then

            ConvertImages()

        End If




    End Sub


    Private Sub ListOpenedImages_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListOpenedImages.ItemCheck

        If (isBusy = False) Then
            e.NewValue = e.CurrentValue
        End If

    End Sub






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


    Private Sub btnAppenedFile_Click(sender As Object, e As EventArgs) Handles btnAppenedFile.Click
        If isBusy = False Then

            If AbortAction() = True Then
                Exit Sub
            End If

            Dim filter = "Image Files (*.tif;*.tiff;*.png;*.bmp;*.jpg;*.jpeg)|*.tiff;*.tif;*.png;*.bmp;*.jpg;*.jpeg"
            AppendImageFiles(filter)

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

            SaveAllasFile()

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

    Public Sub OCRobjectSet(ByVal sender As Object, ByVal e As EventArgs)

        If HocrPicBox.HocrPage IsNot Nothing AndAlso
           HocrPicBox.HotHocrObjects IsNot Nothing AndAlso
           HocrPicBox.HotHocrObjects.Count > 0 Then

            OCRTreeView.Nodes(0).Nodes.Clear()
            OCRTreeView.Nodes(1).Nodes.Clear()

            Dim Objctcnt As Integer = 1
            For Each imgarea In HocrPicBox.ImageAreas

                OCRTreeView.Nodes(0).Nodes.Add("Image Area " + Objctcnt.ToString)
                Objctcnt += 1
            Next

            Objctcnt = 1
            Dim NodeTypeStr As String = "Word"

            If HocrPicBox.HotHocrObjects.First.EditMode = ocrEditMode.LineEdit Then
                NodeTypeStr = "Line"
            Else
                NodeTypeStr = "Paragraph"
            End If



            For Each hocrObject In HocrPicBox.HotHocrObjects

                Dim nd = OCRTreeView.Nodes(1).Nodes.Add("OCR " + NodeTypeStr + " " + Objctcnt.ToString)
                nd.ImageIndex = 1
                nd.SelectedImageIndex = 1
                Objctcnt += 1

            Next

            OCRTreeView.Nodes(0).ExpandAll()
            OCRTreeView.Nodes(1).ExpandAll()

        Else
            OCRTreeView.Nodes(0).Nodes.Clear()
            OCRTreeView.Nodes(1).Nodes.Clear()

        End If

    End Sub


    Public Sub OCRObjectSelection(ByVal sender As Object, ByVal e As BoundingBoxArg)


        If HocrPicBox.HocrPage IsNot Nothing Then

            If e IsNot Nothing Then

                If EditorPicBox.HighlightedBox <> e.box Then
                    EditorPicBox.HighlightedBox = e.box
                    EditorPicBox.Invalidate()
                End If

                If e.HocrID >= 0 Then
                    If OCRTreeView.Nodes(1).Nodes.Count > e.HocrID Then

                        If OCRTreeView.SelectedNode Is Nothing OrElse Not OCRTreeView.SelectedNode.Equals(OCRTreeView.Nodes(1).Nodes(e.HocrID)) Then
                            OCRTreeView.SelectedNode = OCRTreeView.Nodes(1).Nodes(e.HocrID)
                            OCRTreeView.SelectedNode.EnsureVisible()
                            OCRTreeView.Select()
                            OCRTreeView.Refresh()
                        End If


                    End If


                    txtBoxResult.Text = HocrPicBox.HotHocrObjects(e.HocrID).text

                Else

                    If HocrPicBox.HocrPage IsNot Nothing Then
                        txtBoxResult.Text = HocrPicBox.HocrPage.UTF8Text
                    End If

                End If

            Else
                If EditorPicBox.HighlightedBox.IsEmpty = False Then
                    EditorPicBox.HighlightedBox = New Rectangle
                    EditorPicBox.Invalidate()
                End If
                If HocrPicBox.HocrPage IsNot Nothing Then
                    txtBoxResult.Text = HocrPicBox.HocrPage.UTF8Text
                End If
            End If

        Else


            If EditorPicBox.BoxRectangle = Rectangle.Empty Then

                btnCrop.Enabled = False

            Else

                btnCrop.Enabled = True

            End If




        End If



    End Sub

    Private Sub OCRTreeView_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles OCRTreeView.AfterSelect
        If e.Node.Level = 1 Then
            If e.Action = TreeViewAction.ByMouse OrElse
               e.Action = TreeViewAction.ByKeyboard Then

                If e.Node.Parent.Index = 1 AndAlso e.Node.IsSelected = True Then
                    If HocrPicBox.SelectedHocrID <> e.Node.Index Then
                        HocrPicBox.SelectedHocrID = e.Node.Index
                        HocrPicBox.Invalidate()
                    End If
                End If
            End If


        End If
    End Sub


    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click

        If isBusy = False Then
            UndoImageEdit()
        End If


    End Sub
    Private Sub btnRedo_Click(sender As Object, e As EventArgs) Handles btnRedo.Click

        If isBusy = False Then
            RedoImageEdit()
        End If


    End Sub

    Private Sub CmbLang_Click(sender As Object, e As EventArgs) Handles CmbLang.MouseLeave


    End Sub





#End Region


#Region "UI View Control"

    Private Sub btnImgTab_Click(sender As Object, e As EventArgs) Handles btnImgTab.Click

        btnImgTabClicked()

    End Sub

    Private Sub btnHocrtab_Click(sender As Object, e As EventArgs) Handles btnHocrtab.Click

        btnhocrTabClicked()

    End Sub


    Private Sub btnBackground_Click(sender As Object, e As EventArgs) Handles btnBackground.Click

        If OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage Then

            EditedImageToolStripMenuItem.Checked = True
            OriginalImageToolStripMenuItem.Checked = False


            UserAreaEditedImageToolStripMenuItem.Checked = False
            UserAreaOriginalAreaToolStripMenuItem.Checked = False



        ElseIf OCRsettings.OCRbackgroundView = BackgroundMode.OriginalImage Then

            EditedImageToolStripMenuItem.Checked = False
            OriginalImageToolStripMenuItem.Checked = True


            UserAreaEditedImageToolStripMenuItem.Checked = False
            UserAreaOriginalAreaToolStripMenuItem.Checked = False
        ElseIf OCRsettings.OCRbackgroundView = BackgroundMode.UserEditedImageArea Then

            EditedImageToolStripMenuItem.Checked = False
            OriginalImageToolStripMenuItem.Checked = False


            UserAreaEditedImageToolStripMenuItem.Checked = True
            UserAreaOriginalAreaToolStripMenuItem.Checked = False

        Else


            EditedImageToolStripMenuItem.Checked = False
            OriginalImageToolStripMenuItem.Checked = False


            UserAreaEditedImageToolStripMenuItem.Checked = False
            UserAreaOriginalAreaToolStripMenuItem.Checked = True

        End If




    End Sub

    Private Sub ResetImageBackgroundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetImageBackgroundToolStripMenuItem.Click

        If OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage Then

            MenuItemEditedImageView.Checked = True
            MenuItemOriginalmageView.Checked = False
            MainMenuUserEditedToolStripMenuItem.Checked = False
            MainMenuUserOrigialToolStripMenuItem.Checked = False

        ElseIf OCRsettings.OCRbackgroundView = BackgroundMode.OriginalImage Then

            MenuItemEditedImageView.Checked = False
            MenuItemOriginalmageView.Checked = True
            MainMenuUserEditedToolStripMenuItem.Checked = False
            MainMenuUserOrigialToolStripMenuItem.Checked = False

        ElseIf OCRsettings.OCRbackgroundView = BackgroundMode.UserEditedImageArea Then

            MenuItemEditedImageView.Checked = False
            MenuItemOriginalmageView.Checked = False
            MainMenuUserEditedToolStripMenuItem.Checked = True
            MainMenuUserOrigialToolStripMenuItem.Checked = False


        Else

            MenuItemEditedImageView.Checked = False
            MenuItemOriginalmageView.Checked = False
            MainMenuUserEditedToolStripMenuItem.Checked = False
            MainMenuUserOrigialToolStripMenuItem.Checked = True

        End If


    End Sub



    Private Sub MenuItemEditedImageView_Click(sender As Object, e As EventArgs) Handles MenuItemEditedImageView.Click

        MenuItemEditedImageView.Checked = True
        MenuItemOriginalmageView.Checked = False


        MainMenuUserEditedToolStripMenuItem.Checked = False
        MainMenuUserOrigialToolStripMenuItem.Checked = False


        EditedImageToolStripMenuItem.Checked = True
        OriginalImageToolStripMenuItem.Checked = False

        UserAreaEditedImageToolStripMenuItem.Checked = False
        UserAreaOriginalAreaToolStripMenuItem.Checked = False

        OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage

        btnImageEditMode.Text = "Edited"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()

    End Sub




    Private Sub MenuItemOriginalmageView_Click(sender As Object, e As EventArgs) Handles MenuItemOriginalmageView.Click

        MenuItemEditedImageView.Checked = False
        MenuItemOriginalmageView.Checked = True
        MainMenuUserEditedToolStripMenuItem.Checked = False
        MainMenuUserOrigialToolStripMenuItem.Checked = False

        EditedImageToolStripMenuItem.Checked = False
        OriginalImageToolStripMenuItem.Checked = True
        UserAreaEditedImageToolStripMenuItem.Checked = False
        UserAreaOriginalAreaToolStripMenuItem.Checked = False

        OCRsettings.OCRbackgroundView = BackgroundMode.OriginalImage

        btnImageEditMode.Text = "Original"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()

    End Sub


    Private Sub MainMenuUserEditedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainMenuUserEditedToolStripMenuItem.Click

        MenuItemEditedImageView.Checked = False
        MenuItemOriginalmageView.Checked = False
        MainMenuUserEditedToolStripMenuItem.Checked = True
        MainMenuUserOrigialToolStripMenuItem.Checked = False

        EditedImageToolStripMenuItem.Checked = False
        OriginalImageToolStripMenuItem.Checked = False
        UserAreaEditedImageToolStripMenuItem.Checked = True
        UserAreaOriginalAreaToolStripMenuItem.Checked = False

        OCRsettings.OCRbackgroundView = BackgroundMode.UserEditedImageArea

        btnImageEditMode.Text = "User Image Area"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()

    End Sub

    Private Sub MainMenuUserOrigialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainMenuUserOrigialToolStripMenuItem.Click


        MenuItemEditedImageView.Checked = False
        MenuItemOriginalmageView.Checked = False
        MainMenuUserEditedToolStripMenuItem.Checked = False
        MainMenuUserOrigialToolStripMenuItem.Checked = True

        EditedImageToolStripMenuItem.Checked = False
        OriginalImageToolStripMenuItem.Checked = False
        UserAreaEditedImageToolStripMenuItem.Checked = False
        UserAreaOriginalAreaToolStripMenuItem.Checked = True

        OCRsettings.OCRbackgroundView = BackgroundMode.UserOriginalImageArea

        btnImageEditMode.Text = "User Image Area"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()

    End Sub







    Private Sub EditedImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditedImageToolStripMenuItem.Click

        MenuItemEditedImageView.Checked = True
        MenuItemOriginalmageView.Checked = False


        MainMenuUserEditedToolStripMenuItem.Checked = False
        MainMenuUserOrigialToolStripMenuItem.Checked = False


        EditedImageToolStripMenuItem.Checked = True
        OriginalImageToolStripMenuItem.Checked = False

        UserAreaEditedImageToolStripMenuItem.Checked = False
        UserAreaOriginalAreaToolStripMenuItem.Checked = False

        OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage

        btnImageEditMode.Text = "Edited"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()


    End Sub

    Private Sub OriginalImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OriginalImageToolStripMenuItem.Click

        MenuItemEditedImageView.Checked = False
        MenuItemOriginalmageView.Checked = True
        MainMenuUserEditedToolStripMenuItem.Checked = False
        MainMenuUserOrigialToolStripMenuItem.Checked = False

        EditedImageToolStripMenuItem.Checked = False
        OriginalImageToolStripMenuItem.Checked = True
        UserAreaEditedImageToolStripMenuItem.Checked = False
        UserAreaOriginalAreaToolStripMenuItem.Checked = False

        OCRsettings.OCRbackgroundView = BackgroundMode.OriginalImage

        btnImageEditMode.Text = "Original"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()

    End Sub


    Private Sub UserAreaEditedImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserAreaEditedImageToolStripMenuItem.Click

        MenuItemEditedImageView.Checked = False
        MenuItemOriginalmageView.Checked = False
        MainMenuUserEditedToolStripMenuItem.Checked = True
        MainMenuUserOrigialToolStripMenuItem.Checked = False

        EditedImageToolStripMenuItem.Checked = False
        OriginalImageToolStripMenuItem.Checked = False
        UserAreaEditedImageToolStripMenuItem.Checked = True
        UserAreaOriginalAreaToolStripMenuItem.Checked = False

        OCRsettings.OCRbackgroundView = BackgroundMode.UserEditedImageArea

        btnImageEditMode.Text = "User Image Area"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()



    End Sub

    Private Sub UserAreaOriginalAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserAreaOriginalAreaToolStripMenuItem.Click

        MenuItemEditedImageView.Checked = False
        MenuItemOriginalmageView.Checked = False
        MainMenuUserEditedToolStripMenuItem.Checked = False
        MainMenuUserOrigialToolStripMenuItem.Checked = False

        EditedImageToolStripMenuItem.Checked = False
        OriginalImageToolStripMenuItem.Checked = False
        UserAreaEditedImageToolStripMenuItem.Checked = False
        UserAreaOriginalAreaToolStripMenuItem.Checked = True

        OCRsettings.OCRbackgroundView = BackgroundMode.UserOriginalImageArea

        btnImageEditMode.Text = "User Image Area"

        EditorPicBox.Invalidate()
        HocrPicBox.Invalidate()


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


    Private Sub btnOCRobjColaps_Click(sender As Object, e As EventArgs) Handles btnOCRobjColaps.Click
        ColapsHocrTab()
    End Sub

    Private Sub btnImgTabClicked()

        Try

            btnImgTab.Visible = False
            MainSplitContainer.Panel1Collapsed = False

            If btnHocrtab.Visible = False Then
                MainSplitContainer.SplitterDistance = 470
            Else
                MainSplitContainer.SplitterDistance = 236
                If TabsSplitContainer.Panel2Collapsed = False Then
                    TabsSplitContainer.Panel2Collapsed = True
                End If

            End If

            TabsSplitContainer.Panel1Collapsed = False


        Catch ex As Exception

        End Try



        Me.Refresh()
    End Sub


    Private Sub btnhocrTabClicked()


        Try
            btnHocrtab.Visible = False
            MainSplitContainer.Panel1Collapsed = False

            If btnImgTab.Visible = False Then
                MainSplitContainer.SplitterDistance = 470
            Else
                MainSplitContainer.SplitterDistance = 236
                If TabsSplitContainer.Panel1Collapsed = False Then
                    TabsSplitContainer.Panel1Collapsed = True
                End If
            End If

            TabsSplitContainer.Panel2Collapsed = False


        Catch ex As Exception

        End Try


        Me.Refresh()
    End Sub

    Private Sub ColapsImg()

        Try
            btnPinimag.Checked = False
            If btnHocrtab.Visible = True Then
                MainSplitContainer.Panel1Collapsed = True
            Else
                MainSplitContainer.SplitterDistance = 236
            End If

            TabsSplitContainer.Panel1Collapsed = True
            btnImgTab.Visible = True

        Catch ex As Exception

        End Try

        Me.Refresh()

    End Sub

    Private Sub ColapsHocrTab()

        Try
            btnOCRobjPin.Checked = False
            If btnImgTab.Visible = True Then
                MainSplitContainer.Panel1Collapsed = True
            Else
                MainSplitContainer.SplitterDistance = 236
            End If

            TabsSplitContainer.Panel2Collapsed = True
            btnHocrtab.Visible = True

        Catch ex As Exception

        End Try

        Me.Refresh()
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

        If HocrPicBox.Image IsNot Nothing Then
            HocrPicBox.ZoomReset()
            HocrPicBox.Invalidate()
        End If
    End Sub



    Private Sub ToolZoomResetMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolZoomReset.Click
        If HocrPicBox.Image IsNot Nothing Then
            HocrPicBox.ZoomReset()
            HocrPicBox.Invalidate()
        End If

        If EditorPicBox.Image IsNot Nothing Then
            EditorPicBox.ZoomReset()
            EditorPicBox.Invalidate()
        End If
    End Sub

    Private Sub btnHideImpt_Click(sender As Object, e As EventArgs) Handles btnHideImpt.Click
        If btnImgTab.Visible = True Then
            btnImgTabClicked()
        Else
            ColapsImg()
        End If
    End Sub
















#End Region


#Region "Others"


    Private Sub SearchTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchTextToolStripMenuItem.Click

        If HocrPages IsNot Nothing AndAlso HocrPages.Count > 0 Then





            Dim search = New SearcheTool
            search.StartPosition = FormStartPosition.Manual
            search.TopMost = True
            Dim StartY = Me.Height / 4
            Dim StartX = (Me.Width - search.Width) / 2
            If StartX < 0 Then
                StartX = 0
            End If
            search.Location = New Point(StartX, StartY)


            Dim listitemlist(ListOpenedImages.Items.Count - 1) As ListViewItem
            listitemlist.Initialize()
            ListOpenedImages.Items.CopyTo(listitemlist, 0)
            ListOpenedImages.Tag = listitemlist
            ImageList = ListOpenedImages.LargeImageList
            Dim OldIndex = ListOpenedImages.SelectedIndices(0)
            Dim chekedidexIndex = ListOpenedImages.CheckedIndices.OfType(Of Integer)

            AddHandler search.FormClosed,
                New FormClosedEventHandler(
                Sub(s, arg)
                    If arg.CloseReason = CloseReason.UserClosing Then
                        ListOpenedImages.Items.Clear()
                        ListOpenedImages.LargeImageList = ImageList
                        ListOpenedImages.Items.AddRange(listitemlist)
                        ListOpenedImages.Tag = Nothing
                        ListOpenedImages.Items(OldIndex).Selected = True

                        For Each chk In chekedidexIndex
                            ListOpenedImages.Items(chk).Checked = True
                        Next

                        isBusy = False

                        OpenImage()
                        GC.Collect()
                    End If

                    isBusy = False
                End Sub)

            AddHandler search.SearchRequest, AddressOf SearchText
            AddHandler search.NextRequest, AddressOf ViewNextPage
            AddHandler search.PreviousRequest, AddressOf ViewPreviousPage

            isBusy = True
            search.Show(Me)


        End If



    End Sub


    Private Sub SearchText(ByVal sender As Object, ByVal e As TextSearchArg)

        If EditorPicBox.Image IsNot Nothing Then

            EditorPicBox.DisposeImage()
            EditorPicBox.ResetAllState()

        End If
        If SplitInputResultView.Panel2Collapsed = False Then
            SplitInputResultView.Panel2Collapsed = True
        End If


        Dim Searcher = CType(sender, SearcheTool)
        Dim NormalizedText = SpellCheker.NormalizeCharacters(e.TextToSearch)
        Dim allpages = TextProcessor.SearchText(NormalizedText, HocrPages)

        Searcher.imgs = New List(Of Image)

        Dim imgLix = New ImageList

        imgLix.ImageSize = New Size(132, 172)
        ListOpenedImages.Items.Clear()

        ListOpenedImages.LargeImageList = imgLix
        Dim allListOfpages = From page In allpages
                             Order By page.ContextHit Descending,
                                      page.LineHitNumbr Descending,
                                      page.ParagraphHitNumbr Descending,
                                      page.Words.Count Descending




        Dim BrushGol As New Pen(Color.FromArgb(125, Color.Gold))
        Dim cnt As Integer = 0
        For Each page In allListOfpages


            Using imgOp As Bitmap = New Bitmap(HocrPages(page.PageID).ImageName)


                Dim Boxd = page.Words.OrderBy(Function(X) X.bbox.Width).First.bbox

                Dim CropRectangle As New Rectangle
                Dim cropwidth As Integer = 0

                If Boxd.Width >= Boxd.Height Then

                    CropRectangle.Width = Boxd.Width * 4

                    CropRectangle.Height = (CropRectangle.Width * 172) / 132

                    CropRectangle.X = (Boxd.X + (Boxd.Width / 2)) - (CropRectangle.Width / 2)
                    CropRectangle.Y = (Boxd.Y + (Boxd.Height / 2)) - (CropRectangle.Height / 2)


                Else

                    CropRectangle.Height = Boxd.Height * 4


                    CropRectangle.Width = (CropRectangle.Height * 132) / 172
                    CropRectangle.X = (Boxd.X + (Boxd.Width / 2)) - (CropRectangle.Width / 2)
                    CropRectangle.Y = (Boxd.Y + (Boxd.Height / 2)) - (CropRectangle.Height / 2)

                End If

                Using gr = Graphics.FromImage(imgOp)
                    For Each wrds In page.Words

                        gr.FillRectangle(BrushGol.Brush, wrds.bbox)
                        gr.DrawRectangle(Pens.Red, wrds.bbox)

                    Next
                End Using


                Dim ImgCloned As New Bitmap(CropRectangle.Width, CropRectangle.Height)

                Using gr = Graphics.FromImage(ImgCloned)
                    gr.Clear(Color.Black)

                    gr.DrawImage(imgOp, New Rectangle(0, 0, CropRectangle.Width, CropRectangle.Height), CropRectangle, GraphicsUnit.Pixel)


                End Using

                imgLix.Images.Add(ImgCloned)
                ListOpenedImages.Items.Add(cnt.ToString, cnt)
                cnt += 1


                Searcher.imgs.Add(imgOp.Clone)
            End Using

            If ListOpenedImages.Items.Count > 0 Then
                ListOpenedImages.Items(0).Selected = True
                EditorPicBox.Image = Searcher.imgs(0).Clone
                ListOpenedImages.Items(0).EnsureVisible()
            End If

        Next

    End Sub

































#End Region






End Class