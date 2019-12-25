<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub





    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Application.EnableVisualStyles()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User OCR Objects")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recognized OCR Objects")
        Me.ImagelistContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TreeContextOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeContextOpenDetect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.TreeContextSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextSaveAsWord = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchablePDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextSaveAsText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.TreeContextReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainWindowMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegemntToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveOutPutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportTemplateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.RecentProjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolImgeListView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolZoomReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetImageBackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemEditedImageView = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemOriginalmageView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainMenuUserEditedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuUserOrigialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalyzeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeskewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeskewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotateRight90ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rotateleft90ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CropImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.RunOCRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExtendedActionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.PosTaggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSaveWordList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolSaveWordFrequency = New System.Windows.Forms.ToolStripMenuItem()
        Me.SentencesListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.CorpusPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.GenerateOutPutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateNGramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatParallelCorpusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConvertImages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.SplitTiffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MergeTiffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.PDFToImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.CombinePDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ScanDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutAmhOCRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AmhOCRHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.MainWindowStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblCoordinate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SelectNameLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.progRecognize = New System.Windows.Forms.ToolStripProgressBar()
        Me.MainSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.TabsSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.ListOpenedImages = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MainWindowToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnColapsImg = New System.Windows.Forms.ToolStripButton()
        Me.btnPinimag = New System.Windows.Forms.ToolStripButton()
        Me.OCRTreeView = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOCRobjColaps = New System.Windows.Forms.ToolStripButton()
        Me.btnOCRobjPin = New System.Windows.Forms.ToolStripButton()
        Me.SplitInputResultView = New System.Windows.Forms.SplitContainer()
        Me.ToolsMainWindow = New System.Windows.Forms.ToolStrip()
        Me.textSelctedImage = New System.Windows.Forms.ToolStripTextBox()
        Me.btnOpenPrevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOpenNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolsImageOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAppenedFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SaveAsAmhOCRProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsMSDOCFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsSearchablePDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsTextFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.btnRedo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnResetZoom = New System.Windows.Forms.ToolStripButton()
        Me.btnHideImpt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnTxtView = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBackground = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EditedImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OriginalImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.UserAreaEditedImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserAreaOriginalAreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImageEditMode = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSaveImage = New System.Windows.Forms.ToolStripButton()
        Me.OCRToolStrips = New System.Windows.Forms.ToolStrip()
        Me.CmbLang = New System.Windows.Forms.ToolStripComboBox()
        Me.btnRecognizeCurrent = New System.Windows.Forms.ToolStripButton()
        Me.btnRecognizeAll = New System.Windows.Forms.ToolStripButton()
        Me.btnResetRecog = New System.Windows.Forms.ToolStripButton()
        Me.cmbEditMode = New System.Windows.Forms.ToolStripComboBox()
        Me.btnSelectionBox = New System.Windows.Forms.ToolStripButton()
        Me.ImagesToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnboxdraw = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSetting = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDeskew = New System.Windows.Forms.ToolStripButton()
        Me.btnRotateRight = New System.Windows.Forms.ToolStripButton()
        Me.btnRotateLeft = New System.Windows.Forms.ToolStripButton()
        Me.btnCrop = New System.Windows.Forms.ToolStripButton()
        Me.SplitTextResultView = New System.Windows.Forms.SplitContainer()
        Me.txtBoxResult = New System.Windows.Forms.TextBox()
        Me.SideToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnImgTab = New System.Windows.Forms.ToolStripButton()
        Me.btnHocrtab = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip9 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton48 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton43 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbFonts = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem30 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem33 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem31 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem36 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem32 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem34 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem35 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem37 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem38 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem39 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem40 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbFontSiz = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton33 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton38 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton24 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton31 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton32 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ImagelistContextMenu.SuspendLayout()
        Me.MainWindowMenuStrip.SuspendLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.MainWindowStatusStrip.SuspendLayout()
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainSplitContainer.Panel1.SuspendLayout()
        Me.MainSplitContainer.Panel2.SuspendLayout()
        Me.MainSplitContainer.SuspendLayout()
        CType(Me.TabsSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabsSplitContainer.Panel1.SuspendLayout()
        Me.TabsSplitContainer.Panel2.SuspendLayout()
        Me.TabsSplitContainer.SuspendLayout()
        Me.MainWindowToolStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitInputResultView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitInputResultView.Panel1.SuspendLayout()
        Me.SplitInputResultView.Panel2.SuspendLayout()
        Me.SplitInputResultView.SuspendLayout()
        Me.ToolsMainWindow.SuspendLayout()
        Me.OCRToolStrips.SuspendLayout()
        Me.ImagesToolStrip.SuspendLayout()
        CType(Me.SplitTextResultView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitTextResultView.Panel2.SuspendLayout()
        Me.SplitTextResultView.SuspendLayout()
        Me.SideToolStrip.SuspendLayout()
        Me.ToolStrip9.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImagelistContextMenu
        '
        Me.ImagelistContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TreeContextOpen, Me.TreeContextOpenDetect, Me.ToolStripSeparator31, Me.TreeContextSaveAs, Me.ToolStripSeparator32, Me.TreeContextReset})
        Me.ImagelistContextMenu.Name = "ContextMenuStrip1"
        Me.ImagelistContextMenu.Size = New System.Drawing.Size(260, 104)
        Me.ImagelistContextMenu.Text = "Open"
        '
        'TreeContextOpen
        '
        Me.TreeContextOpen.Image = CType(resources.GetObject("TreeContextOpen.Image"), System.Drawing.Image)
        Me.TreeContextOpen.Name = "TreeContextOpen"
        Me.TreeContextOpen.Size = New System.Drawing.Size(259, 22)
        Me.TreeContextOpen.Text = "Open                                                    "
        '
        'TreeContextOpenDetect
        '
        Me.TreeContextOpenDetect.Image = CType(resources.GetObject("TreeContextOpenDetect.Image"), System.Drawing.Image)
        Me.TreeContextOpenDetect.Name = "TreeContextOpenDetect"
        Me.TreeContextOpenDetect.Size = New System.Drawing.Size(259, 22)
        Me.TreeContextOpenDetect.Text = "Open and Detect"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(256, 6)
        '
        'TreeContextSaveAs
        '
        Me.TreeContextSaveAs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextSaveAsWord, Me.SearchablePDFToolStripMenuItem, Me.ContextSaveAsText})
        Me.TreeContextSaveAs.Image = CType(resources.GetObject("TreeContextSaveAs.Image"), System.Drawing.Image)
        Me.TreeContextSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TreeContextSaveAs.Name = "TreeContextSaveAs"
        Me.TreeContextSaveAs.Size = New System.Drawing.Size(259, 22)
        Me.TreeContextSaveAs.Text = "Save As"
        '
        'ContextSaveAsWord
        '
        Me.ContextSaveAsWord.Name = "ContextSaveAsWord"
        Me.ContextSaveAsWord.Size = New System.Drawing.Size(257, 22)
        Me.ContextSaveAsWord.Text = "MS Word Document                         "
        '
        'SearchablePDFToolStripMenuItem
        '
        Me.SearchablePDFToolStripMenuItem.Name = "SearchablePDFToolStripMenuItem"
        Me.SearchablePDFToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.SearchablePDFToolStripMenuItem.Text = "Searchable PDF"
        '
        'ContextSaveAsText
        '
        Me.ContextSaveAsText.Name = "ContextSaveAsText"
        Me.ContextSaveAsText.Size = New System.Drawing.Size(257, 22)
        Me.ContextSaveAsText.Text = "Simple Text File"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(256, 6)
        '
        'TreeContextReset
        '
        Me.TreeContextReset.Image = CType(resources.GetObject("TreeContextReset.Image"), System.Drawing.Image)
        Me.TreeContextReset.Name = "TreeContextReset"
        Me.TreeContextReset.Size = New System.Drawing.Size(259, 22)
        Me.TreeContextReset.Text = "Reset to Default"
        '
        'MainWindowMenuStrip
        '
        Me.MainWindowMenuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.MainWindowMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.EditToolStripMenuItem, Me.AnalyzeToolStripMenuItem, Me.ExtendedActionToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MainWindowMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainWindowMenuStrip.Name = "MainWindowMenuStrip"
        Me.MainWindowMenuStrip.Size = New System.Drawing.Size(1305, 24)
        Me.MainWindowMenuStrip.TabIndex = 1
        Me.MainWindowMenuStrip.Text = "MainWindowMenuStrip "
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenProjectToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.CloseProjectToolStripMenuItem, Me.ToolStripSeparator2, Me.NewToolStripMenuItem, Me.OpenPDFToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SegemntToolStripMenuItem, Me.ToolStripSeparator3, Me.SaveOutPutToolStripMenuItem, Me.ToolStripSeparator4, Me.ExportImagesToolStripMenuItem, Me.ExportTemplateToolStripMenuItem, Me.ToolStripSeparator5, Me.PrintToolStripMenuItem, Me.ToolStripSeparator6, Me.PreferencesToolStripMenuItem, Me.ToolStripSeparator7, Me.RecentProjectsToolStripMenuItem, Me.ToolStripSeparator8, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.FileToolStripMenuItem.Text = "File "
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Image = CType(resources.GetObject("OpenProjectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Image = CType(resources.GetObject("SaveAsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveAsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save Project"
        '
        'CloseProjectToolStripMenuItem
        '
        Me.CloseProjectToolStripMenuItem.Image = CType(resources.GetObject("CloseProjectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseProjectToolStripMenuItem.Name = "CloseProjectToolStripMenuItem"
        Me.CloseProjectToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.CloseProjectToolStripMenuItem.Text = "Save Project and Close Project"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(301, 6)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.NewToolStripMenuItem.Text = "Open Image"
        '
        'OpenPDFToolStripMenuItem
        '
        Me.OpenPDFToolStripMenuItem.Name = "OpenPDFToolStripMenuItem"
        Me.OpenPDFToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.OpenPDFToolStripMenuItem.Text = "Open PDF"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Enabled = False
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.OpenToolStripMenuItem.Text = "Import Images                                                   "
        '
        'SegemntToolStripMenuItem
        '
        Me.SegemntToolStripMenuItem.Enabled = False
        Me.SegemntToolStripMenuItem.Name = "SegemntToolStripMenuItem"
        Me.SegemntToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.SegemntToolStripMenuItem.Text = "Import Template"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(301, 6)
        '
        'SaveOutPutToolStripMenuItem
        '
        Me.SaveOutPutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WordFileToolStripMenuItem, Me.SaveProjectToolStripMenuItem1, Me.SaveProjectCloseToolStripMenuItem})
        Me.SaveOutPutToolStripMenuItem.Image = CType(resources.GetObject("SaveOutPutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveOutPutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveOutPutToolStripMenuItem.Name = "SaveOutPutToolStripMenuItem"
        Me.SaveOutPutToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.SaveOutPutToolStripMenuItem.Text = "Export Output As"
        '
        'WordFileToolStripMenuItem
        '
        Me.WordFileToolStripMenuItem.Name = "WordFileToolStripMenuItem"
        Me.WordFileToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.WordFileToolStripMenuItem.Text = "Word File                    "
        '
        'SaveProjectToolStripMenuItem1
        '
        Me.SaveProjectToolStripMenuItem1.Name = "SaveProjectToolStripMenuItem1"
        Me.SaveProjectToolStripMenuItem1.Size = New System.Drawing.Size(184, 22)
        Me.SaveProjectToolStripMenuItem1.Text = "Searchable PDF"
        '
        'SaveProjectCloseToolStripMenuItem
        '
        Me.SaveProjectCloseToolStripMenuItem.Name = "SaveProjectCloseToolStripMenuItem"
        Me.SaveProjectCloseToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SaveProjectCloseToolStripMenuItem.Text = "Text File"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(301, 6)
        '
        'ExportImagesToolStripMenuItem
        '
        Me.ExportImagesToolStripMenuItem.Enabled = False
        Me.ExportImagesToolStripMenuItem.Name = "ExportImagesToolStripMenuItem"
        Me.ExportImagesToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.ExportImagesToolStripMenuItem.Text = "Export Images"
        '
        'ExportTemplateToolStripMenuItem
        '
        Me.ExportTemplateToolStripMenuItem.Enabled = False
        Me.ExportTemplateToolStripMenuItem.Name = "ExportTemplateToolStripMenuItem"
        Me.ExportTemplateToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.ExportTemplateToolStripMenuItem.Text = "Export Template"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(301, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Enabled = False
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(301, 6)
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Image = CType(resources.GetObject("PreferencesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(301, 6)
        '
        'RecentProjectsToolStripMenuItem
        '
        Me.RecentProjectsToolStripMenuItem.Name = "RecentProjectsToolStripMenuItem"
        Me.RecentProjectsToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.RecentProjectsToolStripMenuItem.Text = "Recent Projects"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(301, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.ExitToolStripMenuItem.Text = "Exit Application"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolImgeListView, Me.ToolZoomReset, Me.TextViewToolStripMenuItem, Me.ResetImageBackgroundToolStripMenuItem, Me.ToolStripSeparator28, Me.SettingPageToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ViewToolStripMenuItem.Text = "View "
        '
        'ToolImgeListView
        '
        Me.ToolImgeListView.Image = CType(resources.GetObject("ToolImgeListView.Image"), System.Drawing.Image)
        Me.ToolImgeListView.Name = "ToolImgeListView"
        Me.ToolImgeListView.Size = New System.Drawing.Size(260, 22)
        Me.ToolImgeListView.Text = "Image Explorer                                    "
        '
        'ToolZoomReset
        '
        Me.ToolZoomReset.Image = CType(resources.GetObject("ToolZoomReset.Image"), System.Drawing.Image)
        Me.ToolZoomReset.Name = "ToolZoomReset"
        Me.ToolZoomReset.Size = New System.Drawing.Size(260, 22)
        Me.ToolZoomReset.Text = "Zoom Reset"
        '
        'TextViewToolStripMenuItem
        '
        Me.TextViewToolStripMenuItem.Checked = True
        Me.TextViewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TextViewToolStripMenuItem.Image = CType(resources.GetObject("TextViewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TextViewToolStripMenuItem.Name = "TextViewToolStripMenuItem"
        Me.TextViewToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.TextViewToolStripMenuItem.Text = "Text Result View"
        '
        'ResetImageBackgroundToolStripMenuItem
        '
        Me.ResetImageBackgroundToolStripMenuItem.CheckOnClick = True
        Me.ResetImageBackgroundToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemEditedImageView, Me.MenuItemOriginalmageView, Me.ToolStripSeparator33, Me.MainMenuUserEditedToolStripMenuItem, Me.MainMenuUserOrigialToolStripMenuItem})
        Me.ResetImageBackgroundToolStripMenuItem.Image = CType(resources.GetObject("ResetImageBackgroundToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ResetImageBackgroundToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.ResetImageBackgroundToolStripMenuItem.Name = "ResetImageBackgroundToolStripMenuItem"
        Me.ResetImageBackgroundToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ResetImageBackgroundToolStripMenuItem.Text = "Image View Mode"
        '
        'MenuItemEditedImageView
        '
        Me.MenuItemEditedImageView.Checked = True
        Me.MenuItemEditedImageView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuItemEditedImageView.Name = "MenuItemEditedImageView"
        Me.MenuItemEditedImageView.Size = New System.Drawing.Size(248, 22)
        Me.MenuItemEditedImageView.Text = "Edited Image                                   "
        '
        'MenuItemOriginalmageView
        '
        Me.MenuItemOriginalmageView.Name = "MenuItemOriginalmageView"
        Me.MenuItemOriginalmageView.Size = New System.Drawing.Size(248, 22)
        Me.MenuItemOriginalmageView.Text = "Original Image"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(245, 6)
        '
        'MainMenuUserEditedToolStripMenuItem
        '
        Me.MainMenuUserEditedToolStripMenuItem.Name = "MainMenuUserEditedToolStripMenuItem"
        Me.MainMenuUserEditedToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.MainMenuUserEditedToolStripMenuItem.Text = "User Area: Edited Image"
        '
        'MainMenuUserOrigialToolStripMenuItem
        '
        Me.MainMenuUserOrigialToolStripMenuItem.Name = "MainMenuUserOrigialToolStripMenuItem"
        Me.MainMenuUserOrigialToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.MainMenuUserOrigialToolStripMenuItem.Text = "User Area: Original Image"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(257, 6)
        '
        'SettingPageToolStripMenuItem
        '
        Me.SettingPageToolStripMenuItem.Enabled = False
        Me.SettingPageToolStripMenuItem.Image = CType(resources.GetObject("SettingPageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingPageToolStripMenuItem.Name = "SettingPageToolStripMenuItem"
        Me.SettingPageToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.SettingPageToolStripMenuItem.Text = "Set Viewstyle"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.RedoToolStripMenuItem, Me.ToolStripSeparator10, Me.FindToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        Me.EditToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(286, 22)
        Me.ToolStripMenuItem3.Text = "Undo                                                             "
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Image = CType(resources.GetObject("RedoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(283, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Image = CType(resources.GetObject("FindToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'AnalyzeToolStripMenuItem
        '
        Me.AnalyzeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator27, Me.DeskewToolStripMenuItem, Me.ToolStripSeparator20, Me.RunOCRToolStripMenuItem, Me.RunAllToolStripMenuItem, Me.ToolStripSeparator26})
        Me.AnalyzeToolStripMenuItem.Name = "AnalyzeToolStripMenuItem"
        Me.AnalyzeToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.AnalyzeToolStripMenuItem.Text = "OCR Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.OptionsToolStripMenuItem.Text = "Image OCR Settings              "
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(263, 6)
        '
        'DeskewToolStripMenuItem
        '
        Me.DeskewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeskewToolStripMenuItem1, Me.RotateRight90ToolStripMenuItem, Me.Rotateleft90ToolStripMenuItem, Me.CropImageToolStripMenuItem})
        Me.DeskewToolStripMenuItem.Name = "DeskewToolStripMenuItem"
        Me.DeskewToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.DeskewToolStripMenuItem.Text = "Image Pre-Process"
        '
        'DeskewToolStripMenuItem1
        '
        Me.DeskewToolStripMenuItem1.Image = CType(resources.GetObject("DeskewToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.DeskewToolStripMenuItem1.Name = "DeskewToolStripMenuItem1"
        Me.DeskewToolStripMenuItem1.Size = New System.Drawing.Size(154, 22)
        Me.DeskewToolStripMenuItem1.Text = "Deskew"
        '
        'RotateRight90ToolStripMenuItem
        '
        Me.RotateRight90ToolStripMenuItem.Image = CType(resources.GetObject("RotateRight90ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RotateRight90ToolStripMenuItem.Name = "RotateRight90ToolStripMenuItem"
        Me.RotateRight90ToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.RotateRight90ToolStripMenuItem.Text = "Rotate Right 90"
        '
        'Rotateleft90ToolStripMenuItem
        '
        Me.Rotateleft90ToolStripMenuItem.Image = CType(resources.GetObject("Rotateleft90ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Rotateleft90ToolStripMenuItem.Name = "Rotateleft90ToolStripMenuItem"
        Me.Rotateleft90ToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.Rotateleft90ToolStripMenuItem.Text = "Rotate Left 90"
        '
        'CropImageToolStripMenuItem
        '
        Me.CropImageToolStripMenuItem.Image = CType(resources.GetObject("CropImageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CropImageToolStripMenuItem.Name = "CropImageToolStripMenuItem"
        Me.CropImageToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.CropImageToolStripMenuItem.Text = "Crop Image"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(263, 6)
        '
        'RunOCRToolStripMenuItem
        '
        Me.RunOCRToolStripMenuItem.Image = CType(resources.GetObject("RunOCRToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunOCRToolStripMenuItem.Name = "RunOCRToolStripMenuItem"
        Me.RunOCRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.RunOCRToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.RunOCRToolStripMenuItem.Text = "Run OCR"
        '
        'RunAllToolStripMenuItem
        '
        Me.RunAllToolStripMenuItem.Image = CType(resources.GetObject("RunAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RunAllToolStripMenuItem.Name = "RunAllToolStripMenuItem"
        Me.RunAllToolStripMenuItem.ShortcutKeyDisplayString = "F5"
        Me.RunAllToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RunAllToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.RunAllToolStripMenuItem.Text = "Run All                                             "
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(263, 6)
        '
        'ExtendedActionToolStripMenuItem
        '
        Me.ExtendedActionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchTextToolStripMenuItem, Me.ToolStripSeparator29, Me.PosTaggerToolStripMenuItem, Me.ToolStripSeparator30, Me.ToolSaveWordList, Me.ToolSaveWordFrequency, Me.SentencesListToolStripMenuItem, Me.ToolStripSeparator35, Me.CorpusPropertiesToolStripMenuItem, Me.ToolStripSeparator36, Me.GenerateOutPutToolStripMenuItem})
        Me.ExtendedActionToolStripMenuItem.Name = "ExtendedActionToolStripMenuItem"
        Me.ExtendedActionToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.ExtendedActionToolStripMenuItem.Text = "Text Tools"
        '
        'SearchTextToolStripMenuItem
        '
        Me.SearchTextToolStripMenuItem.Image = CType(resources.GetObject("SearchTextToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchTextToolStripMenuItem.Name = "SearchTextToolStripMenuItem"
        Me.SearchTextToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.SearchTextToolStripMenuItem.Text = "Search Text"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(277, 6)
        '
        'PosTaggerToolStripMenuItem
        '
        Me.PosTaggerToolStripMenuItem.Enabled = False
        Me.PosTaggerToolStripMenuItem.Name = "PosTaggerToolStripMenuItem"
        Me.PosTaggerToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.PosTaggerToolStripMenuItem.Text = "Pos-Tagger"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(277, 6)
        '
        'ToolSaveWordList
        '
        Me.ToolSaveWordList.Image = CType(resources.GetObject("ToolSaveWordList.Image"), System.Drawing.Image)
        Me.ToolSaveWordList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSaveWordList.Name = "ToolSaveWordList"
        Me.ToolSaveWordList.Size = New System.Drawing.Size(280, 22)
        Me.ToolSaveWordList.Text = "Save Word List"
        '
        'ToolSaveWordFrequency
        '
        Me.ToolSaveWordFrequency.Image = CType(resources.GetObject("ToolSaveWordFrequency.Image"), System.Drawing.Image)
        Me.ToolSaveWordFrequency.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSaveWordFrequency.Name = "ToolSaveWordFrequency"
        Me.ToolSaveWordFrequency.Size = New System.Drawing.Size(280, 22)
        Me.ToolSaveWordFrequency.Text = "Save Word Frequency"
        '
        'SentencesListToolStripMenuItem
        '
        Me.SentencesListToolStripMenuItem.Image = CType(resources.GetObject("SentencesListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SentencesListToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SentencesListToolStripMenuItem.Name = "SentencesListToolStripMenuItem"
        Me.SentencesListToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.SentencesListToolStripMenuItem.Text = "Save Sentences List"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(277, 6)
        '
        'CorpusPropertiesToolStripMenuItem
        '
        Me.CorpusPropertiesToolStripMenuItem.Enabled = False
        Me.CorpusPropertiesToolStripMenuItem.Image = CType(resources.GetObject("CorpusPropertiesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CorpusPropertiesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CorpusPropertiesToolStripMenuItem.Name = "CorpusPropertiesToolStripMenuItem"
        Me.CorpusPropertiesToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.CorpusPropertiesToolStripMenuItem.Text = "Text properties                                           "
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(277, 6)
        '
        'GenerateOutPutToolStripMenuItem
        '
        Me.GenerateOutPutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateNGramToolStripMenuItem, Me.CreatParallelCorpusToolStripMenuItem})
        Me.GenerateOutPutToolStripMenuItem.Enabled = False
        Me.GenerateOutPutToolStripMenuItem.Image = CType(resources.GetObject("GenerateOutPutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GenerateOutPutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GenerateOutPutToolStripMenuItem.Name = "GenerateOutPutToolStripMenuItem"
        Me.GenerateOutPutToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.GenerateOutPutToolStripMenuItem.Text = "Advanced Options"
        '
        'GenerateNGramToolStripMenuItem
        '
        Me.GenerateNGramToolStripMenuItem.Name = "GenerateNGramToolStripMenuItem"
        Me.GenerateNGramToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.GenerateNGramToolStripMenuItem.Text = "Generate N-Gram"
        '
        'CreatParallelCorpusToolStripMenuItem
        '
        Me.CreatParallelCorpusToolStripMenuItem.Name = "CreatParallelCorpusToolStripMenuItem"
        Me.CreatParallelCorpusToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.CreatParallelCorpusToolStripMenuItem.Text = "Creat Parallel corpus"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConvertImages, Me.ToolStripSeparator23, Me.SplitTiffToolStripMenuItem, Me.MergeTiffToolStripMenuItem, Me.ToolStripSeparator24, Me.PDFToImageToolStripMenuItem, Me.ImageToPDFToolStripMenuItem, Me.ToolStripSeparator22, Me.CombinePDFToolStripMenuItem, Me.SplitPDFToolStripMenuItem, Me.ToolStripSeparator25, Me.ScanDocumentToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.ToolsToolStripMenuItem.Text = "Extensions"
        '
        'btnConvertImages
        '
        Me.btnConvertImages.Name = "btnConvertImages"
        Me.btnConvertImages.Size = New System.Drawing.Size(277, 22)
        Me.btnConvertImages.Text = "Convert Images"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(274, 6)
        '
        'SplitTiffToolStripMenuItem
        '
        Me.SplitTiffToolStripMenuItem.Name = "SplitTiffToolStripMenuItem"
        Me.SplitTiffToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.SplitTiffToolStripMenuItem.Text = "Split Tiff                                                     "
        '
        'MergeTiffToolStripMenuItem
        '
        Me.MergeTiffToolStripMenuItem.Name = "MergeTiffToolStripMenuItem"
        Me.MergeTiffToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.MergeTiffToolStripMenuItem.Text = "Merge Tiff"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(274, 6)
        '
        'PDFToImageToolStripMenuItem
        '
        Me.PDFToImageToolStripMenuItem.Name = "PDFToImageToolStripMenuItem"
        Me.PDFToImageToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.PDFToImageToolStripMenuItem.Text = "PDF to Images"
        '
        'ImageToPDFToolStripMenuItem
        '
        Me.ImageToPDFToolStripMenuItem.Name = "ImageToPDFToolStripMenuItem"
        Me.ImageToPDFToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ImageToPDFToolStripMenuItem.Text = "Images To PDF"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(274, 6)
        '
        'CombinePDFToolStripMenuItem
        '
        Me.CombinePDFToolStripMenuItem.Name = "CombinePDFToolStripMenuItem"
        Me.CombinePDFToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.CombinePDFToolStripMenuItem.Text = "Merge PDF"
        '
        'SplitPDFToolStripMenuItem
        '
        Me.SplitPDFToolStripMenuItem.Name = "SplitPDFToolStripMenuItem"
        Me.SplitPDFToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.SplitPDFToolStripMenuItem.Text = "Split PDF"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(274, 6)
        '
        'ScanDocumentToolStripMenuItem
        '
        Me.ScanDocumentToolStripMenuItem.Enabled = False
        Me.ScanDocumentToolStripMenuItem.Name = "ScanDocumentToolStripMenuItem"
        Me.ScanDocumentToolStripMenuItem.Size = New System.Drawing.Size(277, 22)
        Me.ScanDocumentToolStripMenuItem.Text = "Scan Document"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutAmhOCRToolStripMenuItem, Me.AmhOCRHelpToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.HelpToolStripMenuItem.Text = "Help "
        '
        'AboutAmhOCRToolStripMenuItem
        '
        Me.AboutAmhOCRToolStripMenuItem.Image = CType(resources.GetObject("AboutAmhOCRToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutAmhOCRToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.AboutAmhOCRToolStripMenuItem.Name = "AboutAmhOCRToolStripMenuItem"
        Me.AboutAmhOCRToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.AboutAmhOCRToolStripMenuItem.Text = "About AmhOCR"
        '
        'AmhOCRHelpToolStripMenuItem
        '
        Me.AmhOCRHelpToolStripMenuItem.Name = "AmhOCRHelpToolStripMenuItem"
        Me.AmhOCRHelpToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.AmhOCRHelpToolStripMenuItem.Text = "AmhOCR Help                     "
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.MainWindowStatusStrip)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.AutoScroll = True
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.MainSplitContainer)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SideToolStrip)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1305, 543)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1305, 565)
        Me.ToolStripContainer1.TabIndex = 2
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip9)
        '
        'MainWindowStatusStrip
        '
        Me.MainWindowStatusStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.MainWindowStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblCoordinate, Me.SelectNameLbl, Me.progRecognize})
        Me.MainWindowStatusStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainWindowStatusStrip.Name = "MainWindowStatusStrip"
        Me.MainWindowStatusStrip.Size = New System.Drawing.Size(1305, 22)
        Me.MainWindowStatusStrip.TabIndex = 2
        Me.MainWindowStatusStrip.Text = "StatusStrip1"
        '
        'lblCoordinate
        '
        Me.lblCoordinate.AutoSize = False
        Me.lblCoordinate.BackColor = System.Drawing.Color.Black
        Me.lblCoordinate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblCoordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lblCoordinate.ForeColor = System.Drawing.Color.White
        Me.lblCoordinate.Name = "lblCoordinate"
        Me.lblCoordinate.Size = New System.Drawing.Size(80, 17)
        Me.lblCoordinate.Text = "000,000"
        '
        'SelectNameLbl
        '
        Me.SelectNameLbl.BackColor = System.Drawing.Color.White
        Me.SelectNameLbl.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.SelectNameLbl.Name = "SelectNameLbl"
        Me.SelectNameLbl.Size = New System.Drawing.Size(0, 17)
        '
        'progRecognize
        '
        Me.progRecognize.Name = "progRecognize"
        Me.progRecognize.Size = New System.Drawing.Size(100, 16)
        Me.progRecognize.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progRecognize.Value = 1
        Me.progRecognize.Visible = False
        '
        'MainSplitContainer
        '
        Me.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSplitContainer.IsSplitterFixed = True
        Me.MainSplitContainer.Location = New System.Drawing.Point(24, 0)
        Me.MainSplitContainer.Name = "MainSplitContainer"
        '
        'MainSplitContainer.Panel1
        '
        Me.MainSplitContainer.Panel1.Controls.Add(Me.TabsSplitContainer)
        '
        'MainSplitContainer.Panel2
        '
        Me.MainSplitContainer.Panel2.Controls.Add(Me.SplitInputResultView)
        Me.MainSplitContainer.Size = New System.Drawing.Size(1281, 543)
        Me.MainSplitContainer.SplitterDistance = 236
        Me.MainSplitContainer.TabIndex = 14
        '
        'TabsSplitContainer
        '
        Me.TabsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.TabsSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.TabsSplitContainer.Name = "TabsSplitContainer"
        '
        'TabsSplitContainer.Panel1
        '
        Me.TabsSplitContainer.Panel1.Controls.Add(Me.ListOpenedImages)
        Me.TabsSplitContainer.Panel1.Controls.Add(Me.MainWindowToolStrip)
        Me.TabsSplitContainer.Panel1Collapsed = True
        '
        'TabsSplitContainer.Panel2
        '
        Me.TabsSplitContainer.Panel2.Controls.Add(Me.OCRTreeView)
        Me.TabsSplitContainer.Panel2.Controls.Add(Me.ToolStrip1)
        Me.TabsSplitContainer.Size = New System.Drawing.Size(236, 543)
        Me.TabsSplitContainer.SplitterDistance = 211
        Me.TabsSplitContainer.TabIndex = 3
        '
        'ListOpenedImages
        '
        Me.ListOpenedImages.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.ListOpenedImages.AutoArrange = False
        Me.ListOpenedImages.BackColor = System.Drawing.Color.DimGray
        Me.ListOpenedImages.CausesValidation = False
        Me.ListOpenedImages.CheckBoxes = True
        Me.ListOpenedImages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListOpenedImages.ContextMenuStrip = Me.ImagelistContextMenu
        Me.ListOpenedImages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListOpenedImages.HideSelection = False
        Me.ListOpenedImages.Location = New System.Drawing.Point(0, 25)
        Me.ListOpenedImages.MultiSelect = False
        Me.ListOpenedImages.Name = "ListOpenedImages"
        Me.ListOpenedImages.Size = New System.Drawing.Size(211, 75)
        Me.ListOpenedImages.TabIndex = 0
        Me.ListOpenedImages.UseCompatibleStateImageBehavior = False
        '
        'MainWindowToolStrip
        '
        Me.MainWindowToolStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.MainWindowToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MainWindowToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnColapsImg, Me.btnPinimag})
        Me.MainWindowToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainWindowToolStrip.Name = "MainWindowToolStrip"
        Me.MainWindowToolStrip.Size = New System.Drawing.Size(211, 25)
        Me.MainWindowToolStrip.TabIndex = 2
        Me.MainWindowToolStrip.Text = "ToolStrip4"
        '
        'btnColapsImg
        '
        Me.btnColapsImg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnColapsImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnColapsImg.ForeColor = System.Drawing.Color.White
        Me.btnColapsImg.Image = CType(resources.GetObject("btnColapsImg.Image"), System.Drawing.Image)
        Me.btnColapsImg.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnColapsImg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnColapsImg.Name = "btnColapsImg"
        Me.btnColapsImg.Size = New System.Drawing.Size(23, 22)
        Me.btnColapsImg.Text = "Close"
        '
        'btnPinimag
        '
        Me.btnPinimag.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPinimag.CheckOnClick = True
        Me.btnPinimag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPinimag.ForeColor = System.Drawing.Color.White
        Me.btnPinimag.Image = CType(resources.GetObject("btnPinimag.Image"), System.Drawing.Image)
        Me.btnPinimag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPinimag.Name = "btnPinimag"
        Me.btnPinimag.Size = New System.Drawing.Size(23, 22)
        Me.btnPinimag.Text = "Pin"
        '
        'OCRTreeView
        '
        Me.OCRTreeView.BackColor = System.Drawing.Color.DimGray
        Me.OCRTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OCRTreeView.ForeColor = System.Drawing.Color.White
        Me.OCRTreeView.HideSelection = False
        Me.OCRTreeView.ImageIndex = 0
        Me.OCRTreeView.ImageList = Me.ImageList1
        Me.OCRTreeView.LineColor = System.Drawing.Color.White
        Me.OCRTreeView.Location = New System.Drawing.Point(0, 25)
        Me.OCRTreeView.Name = "OCRTreeView"
        TreeNode3.Name = "Node0"
        TreeNode3.Text = "User OCR Objects"
        TreeNode4.Name = "Node1"
        TreeNode4.Text = "Recognized OCR Objects"
        Me.OCRTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4})
        Me.OCRTreeView.SelectedImageIndex = 0
        Me.OCRTreeView.Size = New System.Drawing.Size(236, 518)
        Me.OCRTreeView.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "Column.png")
        Me.ImageList1.Images.SetKeyName(1, "TextBlock_16x_32.bmp")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOCRobjColaps, Me.btnOCRobjPin})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(236, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "OCRobjTools"
        '
        'btnOCRobjColaps
        '
        Me.btnOCRobjColaps.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnOCRobjColaps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOCRobjColaps.ForeColor = System.Drawing.Color.White
        Me.btnOCRobjColaps.Image = CType(resources.GetObject("btnOCRobjColaps.Image"), System.Drawing.Image)
        Me.btnOCRobjColaps.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnOCRobjColaps.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOCRobjColaps.Name = "btnOCRobjColaps"
        Me.btnOCRobjColaps.Size = New System.Drawing.Size(23, 22)
        Me.btnOCRobjColaps.Text = "Close"
        '
        'btnOCRobjPin
        '
        Me.btnOCRobjPin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnOCRobjPin.CheckOnClick = True
        Me.btnOCRobjPin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOCRobjPin.ForeColor = System.Drawing.Color.White
        Me.btnOCRobjPin.Image = CType(resources.GetObject("btnOCRobjPin.Image"), System.Drawing.Image)
        Me.btnOCRobjPin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOCRobjPin.Name = "btnOCRobjPin"
        Me.btnOCRobjPin.Size = New System.Drawing.Size(23, 22)
        Me.btnOCRobjPin.Text = "Pin"
        '
        'SplitInputResultView
        '
        Me.SplitInputResultView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitInputResultView.Location = New System.Drawing.Point(0, 0)
        Me.SplitInputResultView.Name = "SplitInputResultView"
        '
        'SplitInputResultView.Panel1
        '
        Me.SplitInputResultView.Panel1.Controls.Add(Me.ToolsMainWindow)
        Me.SplitInputResultView.Panel1.Controls.Add(Me.OCRToolStrips)
        Me.SplitInputResultView.Panel1.Controls.Add(Me.ImagesToolStrip)
        '
        'SplitInputResultView.Panel2
        '
        Me.SplitInputResultView.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitInputResultView.Panel2.Controls.Add(Me.SplitTextResultView)
        Me.SplitInputResultView.Size = New System.Drawing.Size(1041, 543)
        Me.SplitInputResultView.SplitterDistance = 771
        Me.SplitInputResultView.SplitterWidth = 6
        Me.SplitInputResultView.TabIndex = 3
        '
        'ToolsMainWindow
        '
        Me.ToolsMainWindow.BackColor = System.Drawing.SystemColors.Control
        Me.ToolsMainWindow.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolsMainWindow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.textSelctedImage, Me.btnOpenPrevious, Me.ToolStripSeparator13, Me.btnOpenNext, Me.ToolStripSeparator1, Me.btnOpen, Me.ToolsImageOpen, Me.ToolStripSeparator14, Me.btnAppenedFile, Me.ToolStripSeparator18, Me.ToolStripButton1, Me.ToolStripSeparator19, Me.btnUndo, Me.btnRedo, Me.ToolStripSeparator9, Me.btnResetZoom, Me.btnHideImpt, Me.ToolStripSeparator17, Me.btnTxtView, Me.ToolStripSeparator11, Me.btnBackground, Me.btnImageEditMode, Me.ToolStripSeparator38, Me.btnSaveImage})
        Me.ToolsMainWindow.Location = New System.Drawing.Point(12, 74)
        Me.ToolsMainWindow.Name = "ToolsMainWindow"
        Me.ToolsMainWindow.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolsMainWindow.Size = New System.Drawing.Size(489, 25)
        Me.ToolsMainWindow.TabIndex = 3
        Me.ToolsMainWindow.Text = "OCR Tools"
        '
        'textSelctedImage
        '
        Me.textSelctedImage.Name = "textSelctedImage"
        Me.textSelctedImage.Size = New System.Drawing.Size(121, 25)
        Me.textSelctedImage.Visible = False
        '
        'btnOpenPrevious
        '
        Me.btnOpenPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpenPrevious.Image = CType(resources.GetObject("btnOpenPrevious.Image"), System.Drawing.Image)
        Me.btnOpenPrevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenPrevious.Name = "btnOpenPrevious"
        Me.btnOpenPrevious.Size = New System.Drawing.Size(23, 22)
        Me.btnOpenPrevious.Text = "ToolStripButton1"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'btnOpenNext
        '
        Me.btnOpenNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpenNext.Image = CType(resources.GetObject("btnOpenNext.Image"), System.Drawing.Image)
        Me.btnOpenNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpenNext.Name = "btnOpenNext"
        Me.btnOpenNext.Size = New System.Drawing.Size(23, 22)
        Me.btnOpenNext.Text = "Open Next"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(23, 22)
        Me.btnOpen.Text = "Open Project"
        '
        'ToolsImageOpen
        '
        Me.ToolsImageOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolsImageOpen.Image = CType(resources.GetObject("ToolsImageOpen.Image"), System.Drawing.Image)
        Me.ToolsImageOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolsImageOpen.Name = "ToolsImageOpen"
        Me.ToolsImageOpen.Size = New System.Drawing.Size(23, 22)
        Me.ToolsImageOpen.Text = "Open Image"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'btnAppenedFile
        '
        Me.btnAppenedFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAppenedFile.Enabled = False
        Me.btnAppenedFile.Image = CType(resources.GetObject("btnAppenedFile.Image"), System.Drawing.Image)
        Me.btnAppenedFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAppenedFile.Name = "btnAppenedFile"
        Me.btnAppenedFile.Size = New System.Drawing.Size(23, 22)
        Me.btnAppenedFile.Text = "Appened File"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveAsAmhOCRProjectToolStripMenuItem, Me.SaveAsMSDOCFileToolStripMenuItem, Me.SaveAsSearchablePDFToolStripMenuItem, Me.SaveAsTextFileToolStripMenuItem})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'SaveAsAmhOCRProjectToolStripMenuItem
        '
        Me.SaveAsAmhOCRProjectToolStripMenuItem.Image = CType(resources.GetObject("SaveAsAmhOCRProjectToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveAsAmhOCRProjectToolStripMenuItem.Name = "SaveAsAmhOCRProjectToolStripMenuItem"
        Me.SaveAsAmhOCRProjectToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SaveAsAmhOCRProjectToolStripMenuItem.Text = "Save as AmhOCR Project"
        '
        'SaveAsMSDOCFileToolStripMenuItem
        '
        Me.SaveAsMSDOCFileToolStripMenuItem.Image = CType(resources.GetObject("SaveAsMSDOCFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveAsMSDOCFileToolStripMenuItem.Name = "SaveAsMSDOCFileToolStripMenuItem"
        Me.SaveAsMSDOCFileToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SaveAsMSDOCFileToolStripMenuItem.Text = "Save as MS word Document"
        '
        'SaveAsSearchablePDFToolStripMenuItem
        '
        Me.SaveAsSearchablePDFToolStripMenuItem.Image = CType(resources.GetObject("SaveAsSearchablePDFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveAsSearchablePDFToolStripMenuItem.Name = "SaveAsSearchablePDFToolStripMenuItem"
        Me.SaveAsSearchablePDFToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SaveAsSearchablePDFToolStripMenuItem.Text = "Save as Searchable PDF"
        '
        'SaveAsTextFileToolStripMenuItem
        '
        Me.SaveAsTextFileToolStripMenuItem.Image = CType(resources.GetObject("SaveAsTextFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveAsTextFileToolStripMenuItem.Name = "SaveAsTextFileToolStripMenuItem"
        Me.SaveAsTextFileToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SaveAsTextFileToolStripMenuItem.Text = "Save as Text File"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Enabled = False
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(23, 22)
        Me.btnUndo.Text = "Undo"
        '
        'btnRedo
        '
        Me.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRedo.Enabled = False
        Me.btnRedo.Image = CType(resources.GetObject("btnRedo.Image"), System.Drawing.Image)
        Me.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(23, 22)
        Me.btnRedo.Text = "Redo"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'btnResetZoom
        '
        Me.btnResetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnResetZoom.Image = CType(resources.GetObject("btnResetZoom.Image"), System.Drawing.Image)
        Me.btnResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResetZoom.Name = "btnResetZoom"
        Me.btnResetZoom.Size = New System.Drawing.Size(23, 22)
        Me.btnResetZoom.Text = "Zoom Reset"
        '
        'btnHideImpt
        '
        Me.btnHideImpt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHideImpt.Image = CType(resources.GetObject("btnHideImpt.Image"), System.Drawing.Image)
        Me.btnHideImpt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHideImpt.Name = "btnHideImpt"
        Me.btnHideImpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnHideImpt.Size = New System.Drawing.Size(23, 22)
        Me.btnHideImpt.Text = "Hide Tabs"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'btnTxtView
        '
        Me.btnTxtView.Checked = True
        Me.btnTxtView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnTxtView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTxtView.Image = CType(resources.GetObject("btnTxtView.Image"), System.Drawing.Image)
        Me.btnTxtView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTxtView.Name = "btnTxtView"
        Me.btnTxtView.Size = New System.Drawing.Size(23, 22)
        Me.btnTxtView.Text = "Text Result View"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'btnBackground
        '
        Me.btnBackground.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditedImageToolStripMenuItem, Me.OriginalImageToolStripMenuItem, Me.ToolStripSeparator12, Me.UserAreaEditedImageToolStripMenuItem, Me.UserAreaOriginalAreaToolStripMenuItem})
        Me.btnBackground.Image = CType(resources.GetObject("btnBackground.Image"), System.Drawing.Image)
        Me.btnBackground.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnBackground.Name = "btnBackground"
        Me.btnBackground.Size = New System.Drawing.Size(97, 22)
        Me.btnBackground.Text = "Image View"
        '
        'EditedImageToolStripMenuItem
        '
        Me.EditedImageToolStripMenuItem.Checked = True
        Me.EditedImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EditedImageToolStripMenuItem.Name = "EditedImageToolStripMenuItem"
        Me.EditedImageToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.EditedImageToolStripMenuItem.Text = "Edited Image                                     "
        '
        'OriginalImageToolStripMenuItem
        '
        Me.OriginalImageToolStripMenuItem.Name = "OriginalImageToolStripMenuItem"
        Me.OriginalImageToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.OriginalImageToolStripMenuItem.Text = "Original Image"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(251, 6)
        '
        'UserAreaEditedImageToolStripMenuItem
        '
        Me.UserAreaEditedImageToolStripMenuItem.Name = "UserAreaEditedImageToolStripMenuItem"
        Me.UserAreaEditedImageToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.UserAreaEditedImageToolStripMenuItem.Text = "User Area: Edited Image"
        '
        'UserAreaOriginalAreaToolStripMenuItem
        '
        Me.UserAreaOriginalAreaToolStripMenuItem.Name = "UserAreaOriginalAreaToolStripMenuItem"
        Me.UserAreaOriginalAreaToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.UserAreaOriginalAreaToolStripMenuItem.Text = "User Area: Original Image"
        '
        'btnImageEditMode
        '
        Me.btnImageEditMode.BackColor = System.Drawing.SystemColors.Control
        Me.btnImageEditMode.Checked = True
        Me.btnImageEditMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImageEditMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnImageEditMode.Image = CType(resources.GetObject("btnImageEditMode.Image"), System.Drawing.Image)
        Me.btnImageEditMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImageEditMode.Name = "btnImageEditMode"
        Me.btnImageEditMode.Size = New System.Drawing.Size(44, 22)
        Me.btnImageEditMode.Text = "Edited"
        Me.btnImageEditMode.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(6, 25)
        '
        'btnSaveImage
        '
        Me.btnSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveImage.Enabled = False
        Me.btnSaveImage.Image = CType(resources.GetObject("btnSaveImage.Image"), System.Drawing.Image)
        Me.btnSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveImage.Name = "btnSaveImage"
        Me.btnSaveImage.Size = New System.Drawing.Size(23, 22)
        Me.btnSaveImage.Text = "ToolStripButton2"
        '
        'OCRToolStrips
        '
        Me.OCRToolStrips.AllowMerge = False
        Me.OCRToolStrips.Dock = System.Windows.Forms.DockStyle.None
        Me.OCRToolStrips.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmbLang, Me.btnRecognizeCurrent, Me.btnRecognizeAll, Me.btnResetRecog, Me.cmbEditMode, Me.btnSelectionBox})
        Me.OCRToolStrips.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.OCRToolStrips.Location = New System.Drawing.Point(27, 149)
        Me.OCRToolStrips.Name = "OCRToolStrips"
        Me.OCRToolStrips.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.OCRToolStrips.Size = New System.Drawing.Size(482, 25)
        Me.OCRToolStrips.TabIndex = 13
        Me.OCRToolStrips.Text = "OCR Setting"
        '
        'CmbLang
        '
        Me.CmbLang.Name = "CmbLang"
        Me.CmbLang.Size = New System.Drawing.Size(130, 25)
        '
        'btnRecognizeCurrent
        '
        Me.btnRecognizeCurrent.Image = CType(resources.GetObject("btnRecognizeCurrent.Image"), System.Drawing.Image)
        Me.btnRecognizeCurrent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecognizeCurrent.Name = "btnRecognizeCurrent"
        Me.btnRecognizeCurrent.Size = New System.Drawing.Size(75, 22)
        Me.btnRecognizeCurrent.Text = "Run OCR"
        Me.btnRecognizeCurrent.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'btnRecognizeAll
        '
        Me.btnRecognizeAll.Image = CType(resources.GetObject("btnRecognizeAll.Image"), System.Drawing.Image)
        Me.btnRecognizeAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecognizeAll.Name = "btnRecognizeAll"
        Me.btnRecognizeAll.Size = New System.Drawing.Size(65, 22)
        Me.btnRecognizeAll.Text = "Run All"
        '
        'btnResetRecog
        '
        Me.btnResetRecog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnResetRecog.Enabled = False
        Me.btnResetRecog.Image = CType(resources.GetObject("btnResetRecog.Image"), System.Drawing.Image)
        Me.btnResetRecog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResetRecog.Name = "btnResetRecog"
        Me.btnResetRecog.Size = New System.Drawing.Size(23, 22)
        Me.btnResetRecog.Text = "Reset OCR for this image"
        '
        'cmbEditMode
        '
        Me.cmbEditMode.AutoCompleteCustomSource.AddRange(New String() {"Text", "Hocr", "TSV"})
        Me.cmbEditMode.Name = "cmbEditMode"
        Me.cmbEditMode.Size = New System.Drawing.Size(150, 25)
        '
        'btnSelectionBox
        '
        Me.btnSelectionBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSelectionBox.Enabled = False
        Me.btnSelectionBox.Image = CType(resources.GetObject("btnSelectionBox.Image"), System.Drawing.Image)
        Me.btnSelectionBox.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnSelectionBox.Name = "btnSelectionBox"
        Me.btnSelectionBox.Size = New System.Drawing.Size(23, 22)
        Me.btnSelectionBox.Text = "Selection Box"
        '
        'ImagesToolStrip
        '
        Me.ImagesToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.ImagesToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnboxdraw, Me.ToolStripSeparator34, Me.btnSetting, Me.ToolStripSeparator37, Me.btnDeskew, Me.btnRotateRight, Me.btnRotateLeft, Me.btnCrop})
        Me.ImagesToolStrip.Location = New System.Drawing.Point(27, 112)
        Me.ImagesToolStrip.Name = "ImagesToolStrip"
        Me.ImagesToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ImagesToolStrip.Size = New System.Drawing.Size(162, 25)
        Me.ImagesToolStrip.TabIndex = 0
        Me.ImagesToolStrip.Text = "Morphological Tools"
        '
        'btnboxdraw
        '
        Me.btnboxdraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnboxdraw.Image = CType(resources.GetObject("btnboxdraw.Image"), System.Drawing.Image)
        Me.btnboxdraw.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnboxdraw.Name = "btnboxdraw"
        Me.btnboxdraw.Size = New System.Drawing.Size(23, 22)
        Me.btnboxdraw.Text = "Draw Box"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(6, 25)
        '
        'btnSetting
        '
        Me.btnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSetting.Image = CType(resources.GetObject("btnSetting.Image"), System.Drawing.Image)
        Me.btnSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(23, 22)
        Me.btnSetting.Text = "Set Parameters"
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(6, 25)
        '
        'btnDeskew
        '
        Me.btnDeskew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeskew.Image = CType(resources.GetObject("btnDeskew.Image"), System.Drawing.Image)
        Me.btnDeskew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeskew.Name = "btnDeskew"
        Me.btnDeskew.Size = New System.Drawing.Size(23, 22)
        Me.btnDeskew.Text = "Deskew"
        '
        'btnRotateRight
        '
        Me.btnRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRotateRight.Image = CType(resources.GetObject("btnRotateRight.Image"), System.Drawing.Image)
        Me.btnRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRotateRight.Name = "btnRotateRight"
        Me.btnRotateRight.Size = New System.Drawing.Size(23, 22)
        Me.btnRotateRight.Text = "Rotate Right"
        '
        'btnRotateLeft
        '
        Me.btnRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRotateLeft.Image = CType(resources.GetObject("btnRotateLeft.Image"), System.Drawing.Image)
        Me.btnRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRotateLeft.Name = "btnRotateLeft"
        Me.btnRotateLeft.Size = New System.Drawing.Size(23, 22)
        Me.btnRotateLeft.Text = "Rotate Left"
        '
        'btnCrop
        '
        Me.btnCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCrop.Enabled = False
        Me.btnCrop.Image = CType(resources.GetObject("btnCrop.Image"), System.Drawing.Image)
        Me.btnCrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCrop.Name = "btnCrop"
        Me.btnCrop.Size = New System.Drawing.Size(23, 22)
        Me.btnCrop.Text = "Crop Resize"
        '
        'SplitTextResultView
        '
        Me.SplitTextResultView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitTextResultView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitTextResultView.Location = New System.Drawing.Point(0, 0)
        Me.SplitTextResultView.Name = "SplitTextResultView"
        Me.SplitTextResultView.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitTextResultView.Panel2
        '
        Me.SplitTextResultView.Panel2.Controls.Add(Me.txtBoxResult)
        Me.SplitTextResultView.Size = New System.Drawing.Size(264, 543)
        Me.SplitTextResultView.SplitterDistance = 514
        Me.SplitTextResultView.TabIndex = 3
        '
        'txtBoxResult
        '
        Me.txtBoxResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBoxResult.Location = New System.Drawing.Point(0, 0)
        Me.txtBoxResult.Multiline = True
        Me.txtBoxResult.Name = "txtBoxResult"
        Me.txtBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBoxResult.Size = New System.Drawing.Size(264, 25)
        Me.txtBoxResult.TabIndex = 0
        Me.txtBoxResult.WordWrap = False
        '
        'SideToolStrip
        '
        Me.SideToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.SideToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.SideToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImgTab, Me.btnHocrtab})
        Me.SideToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.SideToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.SideToolStrip.Name = "SideToolStrip"
        Me.SideToolStrip.Size = New System.Drawing.Size(24, 543)
        Me.SideToolStrip.TabIndex = 0
        Me.SideToolStrip.Text = "ToolStrip3"
        '
        'btnImgTab
        '
        Me.btnImgTab.AutoToolTip = False
        Me.btnImgTab.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImgTab.Font = New System.Drawing.Font("Arial Unicode MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImgTab.ForeColor = System.Drawing.Color.White
        Me.btnImgTab.Image = CType(resources.GetObject("btnImgTab.Image"), System.Drawing.Image)
        Me.btnImgTab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImgTab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImgTab.Name = "btnImgTab"
        Me.btnImgTab.Size = New System.Drawing.Size(23, 74)
        Me.btnImgTab.Text = "Images"
        Me.btnImgTab.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
        Me.btnImgTab.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'btnHocrtab
        '
        Me.btnHocrtab.AutoToolTip = False
        Me.btnHocrtab.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnHocrtab.Font = New System.Drawing.Font("Arial Unicode MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHocrtab.ForeColor = System.Drawing.Color.White
        Me.btnHocrtab.Image = CType(resources.GetObject("btnHocrtab.Image"), System.Drawing.Image)
        Me.btnHocrtab.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHocrtab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnHocrtab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHocrtab.Name = "btnHocrtab"
        Me.btnHocrtab.Size = New System.Drawing.Size(23, 112)
        Me.btnHocrtab.Text = "OCR Objects"
        Me.btnHocrtab.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
        Me.btnHocrtab.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'ToolStrip9
        '
        Me.ToolStrip9.AllowMerge = False
        Me.ToolStrip9.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip9.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip9.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton48, Me.ToolStripButton43, Me.ToolStripSeparator15, Me.cmbFonts, Me.cmbFontSiz, Me.ToolStripButton33, Me.ToolStripButton38, Me.ToolStripButton21, Me.ToolStripButton24, Me.ToolStripButton31, Me.ToolStripButton32, Me.ToolStripSeparator21})
        Me.ToolStrip9.Location = New System.Drawing.Point(900, 0)
        Me.ToolStrip9.Name = "ToolStrip9"
        Me.ToolStrip9.Size = New System.Drawing.Size(420, 26)
        Me.ToolStrip9.TabIndex = 12
        Me.ToolStrip9.Visible = False
        '
        'ToolStripButton48
        '
        Me.ToolStripButton48.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton48.Image = CType(resources.GetObject("ToolStripButton48.Image"), System.Drawing.Image)
        Me.ToolStripButton48.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton48.Name = "ToolStripButton48"
        Me.ToolStripButton48.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton48.Text = "Font Color"
        '
        'ToolStripButton43
        '
        Me.ToolStripButton43.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton43.Image = CType(resources.GetObject("ToolStripButton43.Image"), System.Drawing.Image)
        Me.ToolStripButton43.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton43.Name = "ToolStripButton43"
        Me.ToolStripButton43.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton43.Text = "Fill Color"
        Me.ToolStripButton43.Visible = False
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 26)
        '
        'cmbFonts
        '
        Me.cmbFonts.AutoSize = False
        Me.cmbFonts.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem30, Me.ToolStripMenuItem33, Me.ToolStripMenuItem31, Me.ToolStripMenuItem36, Me.ToolStripMenuItem32, Me.ToolStripMenuItem34, Me.ToolStripMenuItem35, Me.ToolStripMenuItem37, Me.ToolStripMenuItem38, Me.ToolStripMenuItem39, Me.ToolStripSeparator16, Me.ToolStripMenuItem40})
        Me.cmbFonts.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFonts.Name = "cmbFonts"
        Me.cmbFonts.Size = New System.Drawing.Size(150, 23)
        Me.cmbFonts.Text = "   Segoe UI"
        Me.cmbFonts.ToolTipText = "Fonts"
        '
        'ToolStripMenuItem30
        '
        Me.ToolStripMenuItem30.Checked = True
        Me.ToolStripMenuItem30.CheckOnClick = True
        Me.ToolStripMenuItem30.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem30.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem30.Name = "ToolStripMenuItem30"
        Me.ToolStripMenuItem30.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem30.Text = "Segoe UI"
        '
        'ToolStripMenuItem33
        '
        Me.ToolStripMenuItem33.CheckOnClick = True
        Me.ToolStripMenuItem33.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem33.Name = "ToolStripMenuItem33"
        Me.ToolStripMenuItem33.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem33.Text = "Times New Roman"
        '
        'ToolStripMenuItem31
        '
        Me.ToolStripMenuItem31.CheckOnClick = True
        Me.ToolStripMenuItem31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem31.Name = "ToolStripMenuItem31"
        Me.ToolStripMenuItem31.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem31.Text = "Arial"
        '
        'ToolStripMenuItem36
        '
        Me.ToolStripMenuItem36.CheckOnClick = True
        Me.ToolStripMenuItem36.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem36.Name = "ToolStripMenuItem36"
        Me.ToolStripMenuItem36.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem36.Text = "Calibri"
        '
        'ToolStripMenuItem32
        '
        Me.ToolStripMenuItem32.CheckOnClick = True
        Me.ToolStripMenuItem32.Font = New System.Drawing.Font("Agency FB", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem32.Name = "ToolStripMenuItem32"
        Me.ToolStripMenuItem32.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem32.Text = "Agency FB"
        '
        'ToolStripMenuItem34
        '
        Me.ToolStripMenuItem34.CheckOnClick = True
        Me.ToolStripMenuItem34.Font = New System.Drawing.Font("Impact", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem34.Name = "ToolStripMenuItem34"
        Me.ToolStripMenuItem34.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem34.Text = "Impact"
        '
        'ToolStripMenuItem35
        '
        Me.ToolStripMenuItem35.CheckOnClick = True
        Me.ToolStripMenuItem35.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem35.Name = "ToolStripMenuItem35"
        Me.ToolStripMenuItem35.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem35.Text = "SimSun"
        '
        'ToolStripMenuItem37
        '
        Me.ToolStripMenuItem37.CheckOnClick = True
        Me.ToolStripMenuItem37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem37.Name = "ToolStripMenuItem37"
        Me.ToolStripMenuItem37.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem37.Text = "Txt"
        '
        'ToolStripMenuItem38
        '
        Me.ToolStripMenuItem38.CheckOnClick = True
        Me.ToolStripMenuItem38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.ToolStripMenuItem38.Name = "ToolStripMenuItem38"
        Me.ToolStripMenuItem38.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem38.Text = "Technic"
        '
        'ToolStripMenuItem39
        '
        Me.ToolStripMenuItem39.CheckOnClick = True
        Me.ToolStripMenuItem39.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem39.Name = "ToolStripMenuItem39"
        Me.ToolStripMenuItem39.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem39.Text = "Cambria"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(164, 6)
        '
        'ToolStripMenuItem40
        '
        Me.ToolStripMenuItem40.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem40.Image = CType(resources.GetObject("ToolStripMenuItem40.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem40.Name = "ToolStripMenuItem40"
        Me.ToolStripMenuItem40.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem40.Text = "Use Other"
        Me.ToolStripMenuItem40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFontSiz
        '
        Me.cmbFontSiz.AutoSize = False
        Me.cmbFontSiz.Items.AddRange(New Object() {"4pt", "6pt", "8pt", "9pt", "10pt", "12pt", "14pt", "18pt", "24pt", "30pt", "36pt", "45pt", "60pt"})
        Me.cmbFontSiz.Name = "cmbFontSiz"
        Me.cmbFontSiz.Size = New System.Drawing.Size(60, 23)
        Me.cmbFontSiz.ToolTipText = "Font Size"
        '
        'ToolStripButton33
        '
        Me.ToolStripButton33.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton33.Image = CType(resources.GetObject("ToolStripButton33.Image"), System.Drawing.Image)
        Me.ToolStripButton33.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton33.Name = "ToolStripButton33"
        Me.ToolStripButton33.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton33.Text = "Bold"
        '
        'ToolStripButton38
        '
        Me.ToolStripButton38.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton38.Image = CType(resources.GetObject("ToolStripButton38.Image"), System.Drawing.Image)
        Me.ToolStripButton38.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton38.Name = "ToolStripButton38"
        Me.ToolStripButton38.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton38.Text = "Italic"
        '
        'ToolStripButton21
        '
        Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton21.Image = CType(resources.GetObject("ToolStripButton21.Image"), System.Drawing.Image)
        Me.ToolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton21.Name = "ToolStripButton21"
        Me.ToolStripButton21.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton21.Text = "Underline"
        '
        'ToolStripButton24
        '
        Me.ToolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton24.Image = CType(resources.GetObject("ToolStripButton24.Image"), System.Drawing.Image)
        Me.ToolStripButton24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton24.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton24.Name = "ToolStripButton24"
        Me.ToolStripButton24.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton24.Text = "Left"
        '
        'ToolStripButton31
        '
        Me.ToolStripButton31.Checked = True
        Me.ToolStripButton31.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton31.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton31.Image = CType(resources.GetObject("ToolStripButton31.Image"), System.Drawing.Image)
        Me.ToolStripButton31.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton31.Name = "ToolStripButton31"
        Me.ToolStripButton31.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton31.Text = "Center"
        '
        'ToolStripButton32
        '
        Me.ToolStripButton32.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton32.Image = CType(resources.GetObject("ToolStripButton32.Image"), System.Drawing.Image)
        Me.ToolStripButton32.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton32.Name = "ToolStripButton32"
        Me.ToolStripButton32.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripButton32.Text = "Right"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 26)
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 589)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.MainWindowMenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindow"
        Me.Text = "Amh፠OCR        V1.0.2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ImagelistContextMenu.ResumeLayout(False)
        Me.MainWindowMenuStrip.ResumeLayout(False)
        Me.MainWindowMenuStrip.PerformLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.MainWindowStatusStrip.ResumeLayout(False)
        Me.MainWindowStatusStrip.PerformLayout()
        Me.MainSplitContainer.Panel1.ResumeLayout(False)
        Me.MainSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainSplitContainer.ResumeLayout(False)
        Me.TabsSplitContainer.Panel1.ResumeLayout(False)
        Me.TabsSplitContainer.Panel1.PerformLayout()
        Me.TabsSplitContainer.Panel2.ResumeLayout(False)
        Me.TabsSplitContainer.Panel2.PerformLayout()
        CType(Me.TabsSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabsSplitContainer.ResumeLayout(False)
        Me.MainWindowToolStrip.ResumeLayout(False)
        Me.MainWindowToolStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitInputResultView.Panel1.ResumeLayout(False)
        Me.SplitInputResultView.Panel1.PerformLayout()
        Me.SplitInputResultView.Panel2.ResumeLayout(False)
        CType(Me.SplitInputResultView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitInputResultView.ResumeLayout(False)
        Me.ToolsMainWindow.ResumeLayout(False)
        Me.ToolsMainWindow.PerformLayout()
        Me.OCRToolStrips.ResumeLayout(False)
        Me.OCRToolStrips.PerformLayout()
        Me.ImagesToolStrip.ResumeLayout(False)
        Me.ImagesToolStrip.PerformLayout()
        Me.SplitTextResultView.Panel2.ResumeLayout(False)
        Me.SplitTextResultView.Panel2.PerformLayout()
        CType(Me.SplitTextResultView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitTextResultView.ResumeLayout(False)
        Me.SideToolStrip.ResumeLayout(False)
        Me.SideToolStrip.PerformLayout()
        Me.ToolStrip9.ResumeLayout(False)
        Me.ToolStrip9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ImagelistContextMenu As ContextMenuStrip
    Friend WithEvents TreeContextOpen As ToolStripMenuItem
    Friend WithEvents TreeContextOpenDetect As ToolStripMenuItem
    Friend WithEvents MainWindowMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SegemntToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ExportImagesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportTemplateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents PreferencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents RecentProjectsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolImgeListView As ToolStripMenuItem
    Friend WithEvents SettingPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnalyzeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunOCRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As ToolStripContainer
    Friend WithEvents MainWindowStatusStrip As StatusStrip
    Friend WithEvents lblCoordinate As ToolStripStatusLabel
    Friend WithEvents SelectNameLbl As ToolStripStatusLabel
    Friend WithEvents SplitInputResultView As SplitContainer
    Friend WithEvents ListOpenedImages As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents MainWindowToolStrip As ToolStrip
    Friend WithEvents btnColapsImg As ToolStripButton
    Friend WithEvents btnPinimag As ToolStripButton
    Friend WithEvents SideToolStrip As ToolStrip
    Friend WithEvents btnImgTab As ToolStripButton
    Friend WithEvents btnHocrtab As ToolStripButton
    Friend WithEvents SplitTextResultView As SplitContainer
    Friend WithEvents ToolsMainWindow As ToolStrip
    Friend WithEvents textSelctedImage As ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnOpen As ToolStripButton
    Friend WithEvents btnRedo As ToolStripButton
    Friend WithEvents btnUndo As ToolStripButton
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents btnAppenedFile As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents btnHideImpt As ToolStripButton
    Friend WithEvents btnResetZoom As ToolStripButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtBoxResult As TextBox
    Friend WithEvents ToolStrip9 As ToolStrip
    Friend WithEvents ToolStripButton48 As ToolStripButton
    Friend WithEvents ToolStripButton43 As ToolStripButton
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents cmbFonts As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem30 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem33 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem31 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem36 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem32 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem34 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem35 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem37 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem38 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem39 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem40 As ToolStripMenuItem
    Friend WithEvents cmbFontSiz As ToolStripComboBox
    Friend WithEvents ToolStripButton33 As ToolStripButton
    Friend WithEvents ToolStripButton38 As ToolStripButton
    Friend WithEvents ToolStripButton21 As ToolStripButton
    Friend WithEvents ToolStripButton24 As ToolStripButton
    Friend WithEvents ToolStripButton31 As ToolStripButton
    Friend WithEvents ToolStripButton32 As ToolStripButton
    Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
    Friend WithEvents progRecognize As ToolStripProgressBar
    Friend WithEvents ToolStripSeparator17 As ToolStripSeparator
    Friend WithEvents AmhOCRHelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutAmhOCRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnOpenPrevious As ToolStripButton
    Friend WithEvents btnOpenNext As ToolStripButton
    Friend WithEvents TreeContextSaveAs As ToolStripMenuItem
    Friend WithEvents OpenPDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As ToolStripSeparator
    Friend WithEvents DeskewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PDFToImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As ToolStripSeparator
    Friend WithEvents CombinePDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitPDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As ToolStripSeparator
    Friend WithEvents btnConvertImages As ToolStripMenuItem
    Friend WithEvents ScanDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitTiffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MergeTiffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator26 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator27 As ToolStripSeparator
    Friend WithEvents ToolZoomReset As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As ToolStripSeparator
    Friend WithEvents OCRToolStrips As ToolStrip
    Friend WithEvents btnRecognizeAll As ToolStripButton
    Friend WithEvents btnRecognizeCurrent As ToolStripButton
    Friend WithEvents ImagesToolStrip As ToolStrip
    Friend WithEvents btnDeskew As ToolStripButton
    Friend WithEvents btnRotateRight As ToolStripButton
    Friend WithEvents btnRotateLeft As ToolStripButton
    Friend WithEvents btnCrop As ToolStripButton
    Friend WithEvents DeskewToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RotateRight90ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Rotateleft90ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CropImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CmbLang As ToolStripComboBox
    Friend WithEvents TextViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnTxtView As ToolStripButton
    Friend WithEvents CloseProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveOutPutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
    Friend WithEvents ToolsImageOpen As ToolStripButton
    Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
    Friend WithEvents ExtendedActionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CorpusPropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateOutPutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WordFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProjectCloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolSaveWordList As ToolStripMenuItem
    Friend WithEvents ToolSaveWordFrequency As ToolStripMenuItem
    Friend WithEvents SentencesListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerateNGramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreatParallelCorpusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator29 As ToolStripSeparator
    Friend WithEvents PosTaggerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator30 As ToolStripSeparator
    Friend WithEvents ContextSaveAsWord As ToolStripMenuItem
    Friend WithEvents ContextSaveAsText As ToolStripMenuItem
    Friend WithEvents ImageToPDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchablePDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveProjectToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripDropDownButton
    Friend WithEvents SaveAsAmhOCRProjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsMSDOCFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsSearchablePDFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsTextFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetImageBackgroundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator32 As ToolStripSeparator
    Friend WithEvents TreeContextReset As ToolStripMenuItem
    Friend WithEvents btnResetRecog As ToolStripButton
    Friend WithEvents btnboxdraw As ToolStripButton
    Friend WithEvents ToolStripSeparator34 As ToolStripSeparator
    Friend WithEvents SearchTextToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator35 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator36 As ToolStripSeparator
    Friend WithEvents MainSplitContainer As SplitContainer
    Friend WithEvents TabsSplitContainer As SplitContainer
    Friend WithEvents OCRTreeView As TreeView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnOCRobjColaps As ToolStripButton
    Friend WithEvents btnOCRobjPin As ToolStripButton
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnSelectionBox As ToolStripButton
    Friend WithEvents btnSetting As ToolStripButton
    Friend WithEvents ToolStripSeparator37 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents cmbEditMode As ToolStripComboBox
    Friend WithEvents MenuItemEditedImageView As ToolStripMenuItem
    Friend WithEvents MenuItemOriginalmageView As ToolStripMenuItem
    Friend WithEvents btnBackground As ToolStripDropDownButton
    Friend WithEvents EditedImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OriginalImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents btnImageEditMode As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator33 As ToolStripSeparator
    Friend WithEvents UserAreaEditedImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserAreaOriginalAreaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainMenuUserEditedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainMenuUserOrigialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator38 As ToolStripSeparator
    Friend WithEvents btnSaveImage As ToolStripButton
End Class
