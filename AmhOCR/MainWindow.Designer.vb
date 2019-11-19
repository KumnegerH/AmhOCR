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
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolImgeListView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolZoomReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetImageBackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.CorpusPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.PosTaggerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSaveWordList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolSaveWordFrequency = New System.Windows.Forms.ToolStripMenuItem()
        Me.SentencesListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.SplitInputResultView = New System.Windows.Forms.SplitContainer()
        Me.SplitListViewImgEdit = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.ListOpenedImages = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MainWindowToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnColapsImg = New System.Windows.Forms.ToolStripButton()
        Me.btnPinimag = New System.Windows.Forms.ToolStripButton()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txtExportSize = New System.Windows.Forms.NumericUpDown()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.txtResizeInterval = New System.Windows.Forms.NumericUpDown()
        Me.btnResRight = New System.Windows.Forms.Button()
        Me.btnResLeft = New System.Windows.Forms.Button()
        Me.btnResDown = New System.Windows.Forms.Button()
        Me.btnResUp = New System.Windows.Forms.Button()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.txtPostMergeFilter = New System.Windows.Forms.NumericUpDown()
        Me.chkShowBinarize = New System.Windows.Forms.CheckBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtPreMergeFilter = New System.Windows.Forms.NumericUpDown()
        Me.chkShowRows = New System.Windows.Forms.CheckBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtBinThershold = New System.Windows.Forms.NumericUpDown()
        Me.txtExtractedBackColor = New System.Windows.Forms.NumericUpDown()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtWidthMergeSense = New System.Windows.Forms.NumericUpDown()
        Me.txtHeightMergeSense = New System.Windows.Forms.NumericUpDown()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnColapsSett = New System.Windows.Forms.ToolStripButton()
        Me.btnPinsetting = New System.Windows.Forms.ToolStripButton()
        Me.ToolsOCRProcess = New System.Windows.Forms.ToolStrip()
        Me.btnSetting = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.CmbLang = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnResetRecog = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRecognizeCurrent = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRecognizeAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolsPreProcess = New System.Windows.Forms.ToolStrip()
        Me.btnDeskew = New System.Windows.Forms.ToolStripButton()
        Me.btnRotateRight = New System.Windows.Forms.ToolStripButton()
        Me.btnRotateLeft = New System.Windows.Forms.ToolStripButton()
        Me.btnCrop = New System.Windows.Forms.ToolStripButton()
        Me.ToolsMainWindow = New System.Windows.Forms.ToolStrip()
        Me.textSelctedImage = New System.Windows.Forms.ToolStripTextBox()
        Me.btnOpenPrevious = New System.Windows.Forms.ToolStripButton()
        Me.btnOpenNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbEditMode = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.btnRedo = New System.Windows.Forms.ToolStripButton()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnHideImpt = New System.Windows.Forms.ToolStripButton()
        Me.btnResetZoom = New System.Windows.Forms.ToolStripButton()
        Me.btnTxtView = New System.Windows.Forms.ToolStripButton()
        Me.btnBackground = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.btnImgTab = New System.Windows.Forms.ToolStripButton()
        Me.btnSettTab = New System.Windows.Forms.ToolStripButton()
        Me.SplitTextResultView = New System.Windows.Forms.SplitContainer()
        Me.ViewPicBox = New AmhOCR.ImageViewControl()
        Me.txtBoxResult = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        CType(Me.SplitInputResultView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitInputResultView.Panel1.SuspendLayout()
        Me.SplitInputResultView.Panel2.SuspendLayout()
        Me.SplitInputResultView.SuspendLayout()
        CType(Me.SplitListViewImgEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitListViewImgEdit.Panel1.SuspendLayout()
        Me.SplitListViewImgEdit.Panel2.SuspendLayout()
        Me.SplitListViewImgEdit.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.MainWindowToolStrip.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.txtExportSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtResizeInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox3.SuspendLayout()
        CType(Me.txtPostMergeFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPreMergeFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBinThershold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExtractedBackColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidthMergeSense, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeightMergeSense, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolsOCRProcess.SuspendLayout()
        Me.ToolsPreProcess.SuspendLayout()
        Me.ToolsMainWindow.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.SplitTextResultView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitTextResultView.Panel1.SuspendLayout()
        Me.SplitTextResultView.Panel2.SuspendLayout()
        Me.SplitTextResultView.SuspendLayout()
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
        Me.MainWindowMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.AnalyzeToolStripMenuItem, Me.ExtendedActionToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
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
        Me.ToolImgeListView.Size = New System.Drawing.Size(261, 22)
        Me.ToolImgeListView.Text = "Image Explorer                                    "
        '
        'ToolZoomReset
        '
        Me.ToolZoomReset.Image = CType(resources.GetObject("ToolZoomReset.Image"), System.Drawing.Image)
        Me.ToolZoomReset.Name = "ToolZoomReset"
        Me.ToolZoomReset.Size = New System.Drawing.Size(261, 22)
        Me.ToolZoomReset.Text = "Zoom Reset"
        '
        'TextViewToolStripMenuItem
        '
        Me.TextViewToolStripMenuItem.Checked = True
        Me.TextViewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TextViewToolStripMenuItem.Image = CType(resources.GetObject("TextViewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.TextViewToolStripMenuItem.Name = "TextViewToolStripMenuItem"
        Me.TextViewToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.TextViewToolStripMenuItem.Text = "Text Result View"
        '
        'ResetImageBackgroundToolStripMenuItem
        '
        Me.ResetImageBackgroundToolStripMenuItem.CheckOnClick = True
        Me.ResetImageBackgroundToolStripMenuItem.Image = CType(resources.GetObject("ResetImageBackgroundToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ResetImageBackgroundToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.ResetImageBackgroundToolStripMenuItem.Name = "ResetImageBackgroundToolStripMenuItem"
        Me.ResetImageBackgroundToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.ResetImageBackgroundToolStripMenuItem.Text = "Reset Image Background"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(258, 6)
        '
        'SettingPageToolStripMenuItem
        '
        Me.SettingPageToolStripMenuItem.Enabled = False
        Me.SettingPageToolStripMenuItem.Image = CType(resources.GetObject("SettingPageToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SettingPageToolStripMenuItem.Name = "SettingPageToolStripMenuItem"
        Me.SettingPageToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.SettingPageToolStripMenuItem.Text = "Set Viewstyle"
        '
        'AnalyzeToolStripMenuItem
        '
        Me.AnalyzeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator27, Me.DeskewToolStripMenuItem, Me.ToolStripSeparator20, Me.RunOCRToolStripMenuItem, Me.RunAllToolStripMenuItem, Me.ToolStripSeparator26})
        Me.AnalyzeToolStripMenuItem.Name = "AnalyzeToolStripMenuItem"
        Me.AnalyzeToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.AnalyzeToolStripMenuItem.Text = "OCR Action"
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
        Me.ExtendedActionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CorpusPropertiesToolStripMenuItem, Me.ToolStripSeparator29, Me.PosTaggerToolStripMenuItem, Me.ToolStripSeparator30, Me.ToolSaveWordList, Me.ToolSaveWordFrequency, Me.SentencesListToolStripMenuItem, Me.GenerateOutPutToolStripMenuItem})
        Me.ExtendedActionToolStripMenuItem.Name = "ExtendedActionToolStripMenuItem"
        Me.ExtendedActionToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.ExtendedActionToolStripMenuItem.Text = "NLP Action"
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
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools  "
        '
        'btnConvertImages
        '
        Me.btnConvertImages.Name = "btnConvertImages"
        Me.btnConvertImages.Size = New System.Drawing.Size(276, 22)
        Me.btnConvertImages.Text = "Convert Images"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(273, 6)
        '
        'SplitTiffToolStripMenuItem
        '
        Me.SplitTiffToolStripMenuItem.Name = "SplitTiffToolStripMenuItem"
        Me.SplitTiffToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.SplitTiffToolStripMenuItem.Text = "Split Tiff                                                     "
        '
        'MergeTiffToolStripMenuItem
        '
        Me.MergeTiffToolStripMenuItem.Name = "MergeTiffToolStripMenuItem"
        Me.MergeTiffToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.MergeTiffToolStripMenuItem.Text = "Merge Tiff"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(273, 6)
        '
        'PDFToImageToolStripMenuItem
        '
        Me.PDFToImageToolStripMenuItem.Name = "PDFToImageToolStripMenuItem"
        Me.PDFToImageToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.PDFToImageToolStripMenuItem.Text = "PDF to Images"
        '
        'ImageToPDFToolStripMenuItem
        '
        Me.ImageToPDFToolStripMenuItem.Name = "ImageToPDFToolStripMenuItem"
        Me.ImageToPDFToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.ImageToPDFToolStripMenuItem.Text = "Images To PDF"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(273, 6)
        '
        'CombinePDFToolStripMenuItem
        '
        Me.CombinePDFToolStripMenuItem.Name = "CombinePDFToolStripMenuItem"
        Me.CombinePDFToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.CombinePDFToolStripMenuItem.Text = "Merge PDF"
        '
        'SplitPDFToolStripMenuItem
        '
        Me.SplitPDFToolStripMenuItem.Name = "SplitPDFToolStripMenuItem"
        Me.SplitPDFToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.SplitPDFToolStripMenuItem.Text = "Split PDF"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(273, 6)
        '
        'ScanDocumentToolStripMenuItem
        '
        Me.ScanDocumentToolStripMenuItem.Enabled = False
        Me.ScanDocumentToolStripMenuItem.Name = "ScanDocumentToolStripMenuItem"
        Me.ScanDocumentToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitInputResultView)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Panel1)
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
        'SplitInputResultView
        '
        Me.SplitInputResultView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitInputResultView.Location = New System.Drawing.Point(0, 0)
        Me.SplitInputResultView.Name = "SplitInputResultView"
        '
        'SplitInputResultView.Panel1
        '
        Me.SplitInputResultView.Panel1.Controls.Add(Me.SplitListViewImgEdit)
        Me.SplitInputResultView.Panel1.Controls.Add(Me.ToolStrip3)
        '
        'SplitInputResultView.Panel2
        '
        Me.SplitInputResultView.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitInputResultView.Panel2.Controls.Add(Me.SplitTextResultView)
        Me.SplitInputResultView.Panel2Collapsed = True
        Me.SplitInputResultView.Size = New System.Drawing.Size(1305, 543)
        Me.SplitInputResultView.SplitterDistance = 620
        Me.SplitInputResultView.SplitterWidth = 6
        Me.SplitInputResultView.TabIndex = 3
        '
        'SplitListViewImgEdit
        '
        Me.SplitListViewImgEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitListViewImgEdit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitListViewImgEdit.IsSplitterFixed = True
        Me.SplitListViewImgEdit.Location = New System.Drawing.Point(24, 0)
        Me.SplitListViewImgEdit.Name = "SplitListViewImgEdit"
        '
        'SplitListViewImgEdit.Panel1
        '
        Me.SplitListViewImgEdit.Panel1.Controls.Add(Me.SplitContainer5)
        '
        'SplitListViewImgEdit.Panel2
        '
        Me.SplitListViewImgEdit.Panel2.Controls.Add(Me.ToolsOCRProcess)
        Me.SplitListViewImgEdit.Panel2.Controls.Add(Me.ToolsPreProcess)
        Me.SplitListViewImgEdit.Panel2.Controls.Add(Me.ToolsMainWindow)
        Me.SplitListViewImgEdit.Size = New System.Drawing.Size(1281, 543)
        Me.SplitListViewImgEdit.SplitterDistance = 240
        Me.SplitListViewImgEdit.TabIndex = 0
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.IsSplitterFixed = True
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.ListOpenedImages)
        Me.SplitContainer5.Panel1.Controls.Add(Me.MainWindowToolStrip)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.panel3)
        Me.SplitContainer5.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer5.Panel2Collapsed = True
        Me.SplitContainer5.Size = New System.Drawing.Size(240, 543)
        Me.SplitContainer5.SplitterDistance = 115
        Me.SplitContainer5.TabIndex = 2
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
        Me.ListOpenedImages.Size = New System.Drawing.Size(240, 518)
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
        Me.MainWindowToolStrip.Size = New System.Drawing.Size(240, 25)
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
        'panel3
        '
        Me.panel3.Controls.Add(Me.groupBox2)
        Me.panel3.Controls.Add(Me.GroupBox4)
        Me.panel3.Controls.Add(Me.groupBox3)
        Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel3.Location = New System.Drawing.Point(0, 25)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(96, 75)
        Me.panel3.TabIndex = 40
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.btnExport)
        Me.groupBox2.Controls.Add(Me.txtExportSize)
        Me.groupBox2.Controls.Add(Me.txtOutput)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(0, 390)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(96, 0)
        Me.groupBox2.TabIndex = 37
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Export"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(6, 24)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(96, 13)
        Me.label12.TabIndex = 35
        Me.label12.Text = "Export Size (W/H):"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(-135, 84)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(111, 23)
        Me.btnExport.TabIndex = 22
        Me.btnExport.Text = "Export Blobs"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'txtExportSize
        '
        Me.txtExportSize.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtExportSize.Location = New System.Drawing.Point(108, 22)
        Me.txtExportSize.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtExportSize.Name = "txtExportSize"
        Me.txtExportSize.Size = New System.Drawing.Size(54, 20)
        Me.txtExportSize.TabIndex = 36
        Me.txtExportSize.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(45, 47)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(156, 20)
        Me.txtOutput.TabIndex = 24
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(6, 50)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(42, 13)
        Me.label8.TabIndex = 25
        Me.label8.Text = "Output:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.label6)
        Me.GroupBox4.Controls.Add(Me.txtResizeInterval)
        Me.GroupBox4.Controls.Add(Me.btnResRight)
        Me.GroupBox4.Controls.Add(Me.btnResLeft)
        Me.GroupBox4.Controls.Add(Me.btnResDown)
        Me.GroupBox4.Controls.Add(Me.btnResUp)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 260)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(96, 130)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Move Selected Blobs"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(6, 21)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(45, 13)
        Me.label6.TabIndex = 5
        Me.label6.Text = "Interval:"
        '
        'txtResizeInterval
        '
        Me.txtResizeInterval.Location = New System.Drawing.Point(57, 19)
        Me.txtResizeInterval.Name = "txtResizeInterval"
        Me.txtResizeInterval.Size = New System.Drawing.Size(78, 20)
        Me.txtResizeInterval.TabIndex = 4
        Me.txtResizeInterval.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnResRight
        '
        Me.btnResRight.Location = New System.Drawing.Point(137, 65)
        Me.btnResRight.Name = "btnResRight"
        Me.btnResRight.Size = New System.Drawing.Size(31, 23)
        Me.btnResRight.TabIndex = 3
        Me.btnResRight.Text = ">"
        Me.btnResRight.UseVisualStyleBackColor = True
        '
        'btnResLeft
        '
        Me.btnResLeft.Location = New System.Drawing.Point(79, 65)
        Me.btnResLeft.Name = "btnResLeft"
        Me.btnResLeft.Size = New System.Drawing.Size(31, 23)
        Me.btnResLeft.TabIndex = 2
        Me.btnResLeft.Text = "<"
        Me.btnResLeft.UseVisualStyleBackColor = True
        '
        'btnResDown
        '
        Me.btnResDown.Location = New System.Drawing.Point(108, 84)
        Me.btnResDown.Name = "btnResDown"
        Me.btnResDown.Size = New System.Drawing.Size(31, 23)
        Me.btnResDown.TabIndex = 1
        Me.btnResDown.Text = "v"
        Me.btnResDown.UseVisualStyleBackColor = True
        '
        'btnResUp
        '
        Me.btnResUp.Location = New System.Drawing.Point(108, 45)
        Me.btnResUp.Name = "btnResUp"
        Me.btnResUp.Size = New System.Drawing.Size(31, 23)
        Me.btnResUp.TabIndex = 0
        Me.btnResUp.Text = "^"
        Me.btnResUp.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label11)
        Me.groupBox3.Controls.Add(Me.txtPostMergeFilter)
        Me.groupBox3.Controls.Add(Me.chkShowBinarize)
        Me.groupBox3.Controls.Add(Me.label1)
        Me.groupBox3.Controls.Add(Me.label5)
        Me.groupBox3.Controls.Add(Me.txtPreMergeFilter)
        Me.groupBox3.Controls.Add(Me.chkShowRows)
        Me.groupBox3.Controls.Add(Me.label2)
        Me.groupBox3.Controls.Add(Me.txtBinThershold)
        Me.groupBox3.Controls.Add(Me.txtExtractedBackColor)
        Me.groupBox3.Controls.Add(Me.label3)
        Me.groupBox3.Controls.Add(Me.txtWidthMergeSense)
        Me.groupBox3.Controls.Add(Me.txtHeightMergeSense)
        Me.groupBox3.Controls.Add(Me.label9)
        Me.groupBox3.Controls.Add(Me.label4)
        Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox3.Location = New System.Drawing.Point(0, 0)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(96, 260)
        Me.groupBox3.TabIndex = 0
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "groupBox3"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.label11.Location = New System.Drawing.Point(24, 16)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(154, 13)
        Me.label11.TabIndex = 34
        Me.label11.Text = "Hover controls for tooltips"
        '
        'txtPostMergeFilter
        '
        Me.txtPostMergeFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostMergeFilter.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtPostMergeFilter.Location = New System.Drawing.Point(-6, 197)
        Me.txtPostMergeFilter.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtPostMergeFilter.Name = "txtPostMergeFilter"
        Me.txtPostMergeFilter.Size = New System.Drawing.Size(54, 20)
        Me.txtPostMergeFilter.TabIndex = 6
        Me.txtPostMergeFilter.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'chkShowBinarize
        '
        Me.chkShowBinarize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowBinarize.AutoSize = True
        Me.chkShowBinarize.Location = New System.Drawing.Point(-130, 42)
        Me.chkShowBinarize.Name = "chkShowBinarize"
        Me.chkShowBinarize.Size = New System.Drawing.Size(131, 17)
        Me.chkShowBinarize.TabIndex = 17
        Me.chkShowBinarize.Text = "Show Binarized Image"
        Me.chkShowBinarize.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(-133, 199)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(112, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Post Merge Filter Size:"
        '
        'label5
        '
        Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(-133, 89)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(114, 13)
        Me.label5.TabIndex = 16
        Me.label5.Text = "Binarization Thershold:"
        '
        'txtPreMergeFilter
        '
        Me.txtPreMergeFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPreMergeFilter.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtPreMergeFilter.Location = New System.Drawing.Point(-6, 169)
        Me.txtPreMergeFilter.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtPreMergeFilter.Name = "txtPreMergeFilter"
        Me.txtPreMergeFilter.Size = New System.Drawing.Size(54, 20)
        Me.txtPreMergeFilter.TabIndex = 8
        Me.txtPreMergeFilter.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'chkShowRows
        '
        Me.chkShowRows.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowRows.AutoSize = True
        Me.chkShowRows.Checked = True
        Me.chkShowRows.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowRows.Location = New System.Drawing.Point(-130, 65)
        Me.chkShowRows.Name = "chkShowRows"
        Me.chkShowRows.Size = New System.Drawing.Size(83, 17)
        Me.chkShowRows.TabIndex = 20
        Me.chkShowRows.Text = "Show Rows"
        Me.chkShowRows.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(-133, 171)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(107, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Pre Merge Filter Size:"
        '
        'txtBinThershold
        '
        Me.txtBinThershold.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBinThershold.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtBinThershold.Location = New System.Drawing.Point(-6, 87)
        Me.txtBinThershold.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtBinThershold.Name = "txtBinThershold"
        Me.txtBinThershold.Size = New System.Drawing.Size(54, 20)
        Me.txtBinThershold.TabIndex = 15
        Me.txtBinThershold.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'txtExtractedBackColor
        '
        Me.txtExtractedBackColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExtractedBackColor.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtExtractedBackColor.Location = New System.Drawing.Point(-6, 223)
        Me.txtExtractedBackColor.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtExtractedBackColor.Name = "txtExtractedBackColor"
        Me.txtExtractedBackColor.Size = New System.Drawing.Size(54, 20)
        Me.txtExtractedBackColor.TabIndex = 30
        '
        'label3
        '
        Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(-133, 117)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(124, 13)
        Me.label3.TabIndex = 14
        Me.label3.Text = "Height Merge Sensitivity:"
        '
        'txtWidthMergeSense
        '
        Me.txtWidthMergeSense.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWidthMergeSense.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtWidthMergeSense.Location = New System.Drawing.Point(-6, 143)
        Me.txtWidthMergeSense.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtWidthMergeSense.Name = "txtWidthMergeSense"
        Me.txtWidthMergeSense.Size = New System.Drawing.Size(54, 20)
        Me.txtWidthMergeSense.TabIndex = 11
        Me.txtWidthMergeSense.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'txtHeightMergeSense
        '
        Me.txtHeightMergeSense.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeightMergeSense.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtHeightMergeSense.Location = New System.Drawing.Point(-6, 115)
        Me.txtHeightMergeSense.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtHeightMergeSense.Name = "txtHeightMergeSense"
        Me.txtHeightMergeSense.Size = New System.Drawing.Size(54, 20)
        Me.txtHeightMergeSense.TabIndex = 13
        Me.txtHeightMergeSense.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'label9
        '
        Me.label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(-133, 225)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(110, 13)
        Me.label9.TabIndex = 29
        Me.label9.Text = "Extracted Back Color:"
        '
        'label4
        '
        Me.label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(-133, 145)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(121, 13)
        Me.label4.TabIndex = 12
        Me.label4.Text = "Width Merge Sensitivity:"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnColapsSett, Me.btnPinsetting})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(96, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnColapsSett
        '
        Me.btnColapsSett.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnColapsSett.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnColapsSett.ForeColor = System.Drawing.Color.White
        Me.btnColapsSett.Image = CType(resources.GetObject("btnColapsSett.Image"), System.Drawing.Image)
        Me.btnColapsSett.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnColapsSett.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnColapsSett.Name = "btnColapsSett"
        Me.btnColapsSett.Size = New System.Drawing.Size(23, 22)
        Me.btnColapsSett.Text = "Close"
        '
        'btnPinsetting
        '
        Me.btnPinsetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPinsetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPinsetting.ForeColor = System.Drawing.Color.White
        Me.btnPinsetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPinsetting.Name = "btnPinsetting"
        Me.btnPinsetting.Size = New System.Drawing.Size(23, 22)
        Me.btnPinsetting.Text = "Pin"
        '
        'ToolsOCRProcess
        '
        Me.ToolsOCRProcess.AllowMerge = False
        Me.ToolsOCRProcess.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolsOCRProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSetting, Me.ToolStripSeparator13, Me.CmbLang, Me.ToolStripSeparator12, Me.btnResetRecog, Me.ToolStripSeparator33, Me.btnRecognizeCurrent, Me.ToolStripSeparator11, Me.btnRecognizeAll})
        Me.ToolsOCRProcess.Location = New System.Drawing.Point(157, 59)
        Me.ToolsOCRProcess.Name = "ToolsOCRProcess"
        Me.ToolsOCRProcess.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolsOCRProcess.Size = New System.Drawing.Size(354, 25)
        Me.ToolsOCRProcess.TabIndex = 13
        Me.ToolsOCRProcess.Text = "OCR Setting"
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
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'CmbLang
        '
        Me.CmbLang.Name = "CmbLang"
        Me.CmbLang.Size = New System.Drawing.Size(130, 25)
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'btnRecognizeAll
        '
        Me.btnRecognizeAll.Image = CType(resources.GetObject("btnRecognizeAll.Image"), System.Drawing.Image)
        Me.btnRecognizeAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecognizeAll.Name = "btnRecognizeAll"
        Me.btnRecognizeAll.Size = New System.Drawing.Size(65, 22)
        Me.btnRecognizeAll.Text = "Run All"
        '
        'ToolsPreProcess
        '
        Me.ToolsPreProcess.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolsPreProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDeskew, Me.btnRotateRight, Me.btnRotateLeft, Me.btnCrop})
        Me.ToolsPreProcess.Location = New System.Drawing.Point(16, 59)
        Me.ToolsPreProcess.Name = "ToolsPreProcess"
        Me.ToolsPreProcess.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolsPreProcess.Size = New System.Drawing.Size(104, 25)
        Me.ToolsPreProcess.TabIndex = 0
        Me.ToolsPreProcess.Text = "Morphological Tools"
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
        Me.btnCrop.Image = CType(resources.GetObject("btnCrop.Image"), System.Drawing.Image)
        Me.btnCrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCrop.Name = "btnCrop"
        Me.btnCrop.Size = New System.Drawing.Size(23, 22)
        Me.btnCrop.Text = "Crop Resize"
        '
        'ToolsMainWindow
        '
        Me.ToolsMainWindow.BackColor = System.Drawing.SystemColors.Control
        Me.ToolsMainWindow.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolsMainWindow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.textSelctedImage, Me.btnOpenPrevious, Me.btnOpenNext, Me.ToolStripSeparator1, Me.cmbEditMode, Me.ToolStripSeparator17, Me.btnOpen, Me.ToolsImageOpen, Me.ToolStripSeparator14, Me.btnAppenedFile, Me.ToolStripSeparator18, Me.ToolStripButton1, Me.ToolStripSeparator19, Me.btnRedo, Me.btnUndo, Me.ToolStripSeparator9, Me.btnHideImpt, Me.btnResetZoom, Me.btnTxtView, Me.btnBackground})
        Me.ToolsMainWindow.Location = New System.Drawing.Point(16, 25)
        Me.ToolsMainWindow.Name = "ToolsMainWindow"
        Me.ToolsMainWindow.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolsMainWindow.Size = New System.Drawing.Size(636, 25)
        Me.ToolsMainWindow.TabIndex = 3
        Me.ToolsMainWindow.Text = "OCR Tools"
        '
        'textSelctedImage
        '
        Me.textSelctedImage.Name = "textSelctedImage"
        Me.textSelctedImage.Size = New System.Drawing.Size(121, 25)
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
        'cmbEditMode
        '
        Me.cmbEditMode.AutoCompleteCustomSource.AddRange(New String() {"Text", "Hocr", "TSV"})
        Me.cmbEditMode.Name = "cmbEditMode"
        Me.cmbEditMode.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
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
        'btnResetZoom
        '
        Me.btnResetZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnResetZoom.Image = CType(resources.GetObject("btnResetZoom.Image"), System.Drawing.Image)
        Me.btnResetZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnResetZoom.Name = "btnResetZoom"
        Me.btnResetZoom.Size = New System.Drawing.Size(23, 22)
        Me.btnResetZoom.Text = "Zoom Reset"
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
        'btnBackground
        '
        Me.btnBackground.CheckOnClick = True
        Me.btnBackground.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBackground.Image = CType(resources.GetObject("btnBackground.Image"), System.Drawing.Image)
        Me.btnBackground.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnBackground.Name = "btnBackground"
        Me.btnBackground.Size = New System.Drawing.Size(23, 22)
        Me.btnBackground.Text = "Reset Image Background"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImgTab, Me.btnSettTab})
        Me.ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(24, 543)
        Me.ToolStrip3.TabIndex = 0
        Me.ToolStrip3.Text = "ToolStrip3"
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
        'btnSettTab
        '
        Me.btnSettTab.AutoToolTip = False
        Me.btnSettTab.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSettTab.Font = New System.Drawing.Font("Arial Unicode MS", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettTab.ForeColor = System.Drawing.Color.White
        Me.btnSettTab.Image = CType(resources.GetObject("btnSettTab.Image"), System.Drawing.Image)
        Me.btnSettTab.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSettTab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSettTab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettTab.Name = "btnSettTab"
        Me.btnSettTab.Size = New System.Drawing.Size(23, 104)
        Me.btnSettTab.Text = "NLP Setting"
        Me.btnSettTab.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical270
        Me.btnSettTab.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'SplitTextResultView
        '
        Me.SplitTextResultView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitTextResultView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitTextResultView.Location = New System.Drawing.Point(0, 0)
        Me.SplitTextResultView.Name = "SplitTextResultView"
        Me.SplitTextResultView.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitTextResultView.Panel1
        '
        Me.SplitTextResultView.Panel1.Controls.Add(Me.ViewPicBox)
        '
        'SplitTextResultView.Panel2
        '
        Me.SplitTextResultView.Panel2.Controls.Add(Me.txtBoxResult)
        Me.SplitTextResultView.Size = New System.Drawing.Size(96, 100)
        Me.SplitTextResultView.SplitterDistance = 71
        Me.SplitTextResultView.TabIndex = 3
        '
        'ViewPicBox
        '
        Me.ViewPicBox.BackColor = System.Drawing.Color.DimGray
        Me.ViewPicBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.ViewPicBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewPicBox.HighlightedBox = New System.Drawing.Rectangle(0, 0, 0, 0)
        Me.ViewPicBox.Image = Nothing
        Me.ViewPicBox.Label = Nothing
        Me.ViewPicBox.Location = New System.Drawing.Point(0, 0)
        Me.ViewPicBox.Name = "ViewPicBox"
        Me.ViewPicBox.Size = New System.Drawing.Size(96, 71)
        Me.ViewPicBox.State = AmhOCR.controlState.None
        Me.ViewPicBox.TabIndex = 0
        Me.ViewPicBox.Zoom = 1.0!
        Me.ViewPicBox.ZoomSpeed = 0.2!
        '
        'txtBoxResult
        '
        Me.txtBoxResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBoxResult.Location = New System.Drawing.Point(0, 0)
        Me.txtBoxResult.Multiline = True
        Me.txtBoxResult.Name = "txtBoxResult"
        Me.txtBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBoxResult.Size = New System.Drawing.Size(96, 25)
        Me.txtBoxResult.TabIndex = 0
        Me.txtBoxResult.WordWrap = False
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1305, 543)
        Me.Panel1.TabIndex = 4
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
        Me.Text = "Amh፠OCR        V1.0.1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ImagelistContextMenu.ResumeLayout(False)
        Me.MainWindowMenuStrip.ResumeLayout(False)
        Me.MainWindowMenuStrip.PerformLayout()
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.MainWindowStatusStrip.ResumeLayout(False)
        Me.MainWindowStatusStrip.PerformLayout()
        Me.SplitInputResultView.Panel1.ResumeLayout(False)
        Me.SplitInputResultView.Panel1.PerformLayout()
        Me.SplitInputResultView.Panel2.ResumeLayout(False)
        CType(Me.SplitInputResultView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitInputResultView.ResumeLayout(False)
        Me.SplitListViewImgEdit.Panel1.ResumeLayout(False)
        Me.SplitListViewImgEdit.Panel2.ResumeLayout(False)
        Me.SplitListViewImgEdit.Panel2.PerformLayout()
        CType(Me.SplitListViewImgEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitListViewImgEdit.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.MainWindowToolStrip.ResumeLayout(False)
        Me.MainWindowToolStrip.PerformLayout()
        Me.panel3.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.txtExportSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtResizeInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.txtPostMergeFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPreMergeFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBinThershold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExtractedBackColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidthMergeSense, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeightMergeSense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolsOCRProcess.ResumeLayout(False)
        Me.ToolsOCRProcess.PerformLayout()
        Me.ToolsPreProcess.ResumeLayout(False)
        Me.ToolsPreProcess.PerformLayout()
        Me.ToolsMainWindow.ResumeLayout(False)
        Me.ToolsMainWindow.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.SplitTextResultView.Panel1.ResumeLayout(False)
        Me.SplitTextResultView.Panel2.ResumeLayout(False)
        Me.SplitTextResultView.Panel2.PerformLayout()
        CType(Me.SplitTextResultView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitTextResultView.ResumeLayout(False)
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
    Friend WithEvents SplitListViewImgEdit As SplitContainer
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents ListOpenedImages As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents MainWindowToolStrip As ToolStrip
    Friend WithEvents btnColapsImg As ToolStripButton
    Friend WithEvents btnPinimag As ToolStripButton
    Private WithEvents panel3 As Panel
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents label12 As Label
    Private WithEvents btnExport As Button
    Private WithEvents txtExportSize As NumericUpDown
    Private WithEvents txtOutput As TextBox
    Private WithEvents label8 As Label
    Private WithEvents GroupBox4 As GroupBox
    Private WithEvents label6 As Label
    Private WithEvents txtResizeInterval As NumericUpDown
    Private WithEvents btnResRight As Button
    Private WithEvents btnResLeft As Button
    Private WithEvents btnResDown As Button
    Private WithEvents btnResUp As Button
    Private WithEvents groupBox3 As GroupBox
    Private WithEvents label11 As Label
    Private WithEvents txtPostMergeFilter As NumericUpDown
    Private WithEvents chkShowBinarize As CheckBox
    Private WithEvents label1 As Label
    Private WithEvents label5 As Label
    Private WithEvents txtPreMergeFilter As NumericUpDown
    Private WithEvents chkShowRows As CheckBox
    Private WithEvents label2 As Label
    Private WithEvents txtBinThershold As NumericUpDown
    Private WithEvents txtExtractedBackColor As NumericUpDown
    Private WithEvents label3 As Label
    Private WithEvents txtWidthMergeSense As NumericUpDown
    Private WithEvents txtHeightMergeSense As NumericUpDown
    Private WithEvents label9 As Label
    Private WithEvents label4 As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnColapsSett As ToolStripButton
    Friend WithEvents btnPinsetting As ToolStripButton
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents btnImgTab As ToolStripButton
    Friend WithEvents btnSettTab As ToolStripButton
    Friend WithEvents SplitTextResultView As SplitContainer
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents cmbEditMode As ToolStripComboBox
    Friend WithEvents ViewPicBox As ImageViewControl
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
    Friend WithEvents ToolsOCRProcess As ToolStrip
    Friend WithEvents btnSetting As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents btnRecognizeAll As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents btnRecognizeCurrent As ToolStripButton
    Friend WithEvents ToolsPreProcess As ToolStrip
    Friend WithEvents btnDeskew As ToolStripButton
    Friend WithEvents btnRotateRight As ToolStripButton
    Friend WithEvents btnRotateLeft As ToolStripButton
    Friend WithEvents btnCrop As ToolStripButton
    Friend WithEvents DeskewToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RotateRight90ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Rotateleft90ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CropImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CmbLang As ToolStripComboBox
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
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
    Friend WithEvents btnBackground As ToolStripButton
    Friend WithEvents ResetImageBackgroundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator32 As ToolStripSeparator
    Friend WithEvents TreeContextReset As ToolStripMenuItem
    Friend WithEvents btnResetRecog As ToolStripButton
    Friend WithEvents ToolStripSeparator33 As ToolStripSeparator
End Class
