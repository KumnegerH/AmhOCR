<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserPreference
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numTimeout = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numThreadNumber = New System.Windows.Forms.NumericUpDown()
        Me.cmbLang = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmhfont = New System.Windows.Forms.TextBox()
        Me.btnAmhFont = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDefaultfont = New System.Windows.Forms.TextBox()
        Me.btnDefaultFont = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblSpellColor = New System.Windows.Forms.Label()
        Me.lblUserColor = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numDPX = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numDPY = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbPage = New System.Windows.Forms.ComboBox()
        Me.txtProjFolder = New System.Windows.Forms.TextBox()
        Me.btnBrowseProjFold = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnBrowseDataFold = New System.Windows.Forms.Button()
        Me.txtDataFolder = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnBrowseConvFold = New System.Windows.Forms.Button()
        Me.txtConvFolder = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbPageSegmentation = New System.Windows.Forms.ComboBox()
        Me.cmbEngine = New System.Windows.Forms.ComboBox()
        Me.btnErrorColorChange = New System.Windows.Forms.Button()
        Me.btnUserColorChange = New System.Windows.Forms.Button()
        Me.GroupBox6.SuspendLayout()
        CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numThreadNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numDPX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDPY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmbEngine)
        Me.GroupBox6.Controls.Add(Me.cmbPageSegmentation)
        Me.GroupBox6.Controls.Add(Me.cmbLang)
        Me.GroupBox6.Controls.Add(Me.numThreadNumber)
        Me.GroupBox6.Controls.Add(Me.numTimeout)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(449, 122)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Tesseract Setting"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Default Language"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Page Segmentation"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Engine Mode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Process TimeOut, min"
        '
        'numTimeout
        '
        Me.numTimeout.Location = New System.Drawing.Point(118, 88)
        Me.numTimeout.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTimeout.Name = "numTimeout"
        Me.numTimeout.Size = New System.Drawing.Size(87, 20)
        Me.numTimeout.TabIndex = 2
        Me.numTimeout.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Batch Process threads"
        '
        'numThreadNumber
        '
        Me.numThreadNumber.Location = New System.Drawing.Point(355, 88)
        Me.numThreadNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numThreadNumber.Name = "numThreadNumber"
        Me.numThreadNumber.Size = New System.Drawing.Size(79, 20)
        Me.numThreadNumber.TabIndex = 3
        Me.numThreadNumber.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'cmbLang
        '
        Me.cmbLang.FormattingEnabled = True
        Me.cmbLang.Location = New System.Drawing.Point(328, 17)
        Me.cmbLang.Name = "cmbLang"
        Me.cmbLang.Size = New System.Drawing.Size(106, 21)
        Me.cmbLang.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUserColor)
        Me.GroupBox1.Controls.Add(Me.lblSpellColor)
        Me.GroupBox1.Controls.Add(Me.btnDefaultFont)
        Me.GroupBox1.Controls.Add(Me.btnUserColorChange)
        Me.GroupBox1.Controls.Add(Me.btnErrorColorChange)
        Me.GroupBox1.Controls.Add(Me.btnAmhFont)
        Me.GroupBox1.Controls.Add(Me.txtDefaultfont)
        Me.GroupBox1.Controls.Add(Me.txtAmhfont)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 123)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Font Settings"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Default Font"
        '
        'txtAmhfont
        '
        Me.txtAmhfont.Enabled = False
        Me.txtAmhfont.Location = New System.Drawing.Point(79, 54)
        Me.txtAmhfont.Name = "txtAmhfont"
        Me.txtAmhfont.Size = New System.Drawing.Size(265, 20)
        Me.txtAmhfont.TabIndex = 1
        Me.txtAmhfont.Text = "Power Geez Unicode1"
        '
        'btnAmhFont
        '
        Me.btnAmhFont.Enabled = False
        Me.btnAmhFont.Location = New System.Drawing.Point(362, 52)
        Me.btnAmhFont.Name = "btnAmhFont"
        Me.btnAmhFont.Size = New System.Drawing.Size(75, 23)
        Me.btnAmhFont.TabIndex = 2
        Me.btnAmhFont.Text = "Change"
        Me.btnAmhFont.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Amharic Font"
        '
        'txtDefaultfont
        '
        Me.txtDefaultfont.Enabled = False
        Me.txtDefaultfont.Location = New System.Drawing.Point(79, 90)
        Me.txtDefaultfont.Name = "txtDefaultfont"
        Me.txtDefaultfont.Size = New System.Drawing.Size(265, 20)
        Me.txtDefaultfont.TabIndex = 1
        Me.txtDefaultfont.Text = "Times New Roman"
        '
        'btnDefaultFont
        '
        Me.btnDefaultFont.Enabled = False
        Me.btnDefaultFont.Location = New System.Drawing.Point(362, 88)
        Me.btnDefaultFont.Name = "btnDefaultFont"
        Me.btnDefaultFont.Size = New System.Drawing.Size(75, 23)
        Me.btnDefaultFont.TabIndex = 2
        Me.btnDefaultFont.Text = "Change"
        Me.btnDefaultFont.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Spell Error Color"
        '
        'lblSpellColor
        '
        Me.lblSpellColor.BackColor = System.Drawing.Color.Red
        Me.lblSpellColor.Location = New System.Drawing.Point(94, 21)
        Me.lblSpellColor.Name = "lblSpellColor"
        Me.lblSpellColor.Size = New System.Drawing.Size(30, 19)
        Me.lblSpellColor.TabIndex = 3
        '
        'lblUserColor
        '
        Me.lblUserColor.BackColor = System.Drawing.Color.Black
        Me.lblUserColor.Location = New System.Drawing.Point(315, 21)
        Me.lblUserColor.Name = "lblUserColor"
        Me.lblUserColor.Size = New System.Drawing.Size(29, 19)
        Me.lblUserColor.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(224, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "User Spell  Color"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtConvFolder)
        Me.GroupBox2.Controls.Add(Me.txtDataFolder)
        Me.GroupBox2.Controls.Add(Me.txtProjFolder)
        Me.GroupBox2.Controls.Add(Me.cmbPage)
        Me.GroupBox2.Controls.Add(Me.btnBrowseConvFold)
        Me.GroupBox2.Controls.Add(Me.btnBrowseDataFold)
        Me.GroupBox2.Controls.Add(Me.btnBrowseProjFold)
        Me.GroupBox2.Controls.Add(Me.numDPY)
        Me.GroupBox2.Controls.Add(Me.numDPX)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 155)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Preferences"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Page Resolution:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(97, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "dpx"
        '
        'numDPX
        '
        Me.numDPX.Enabled = False
        Me.numDPX.Location = New System.Drawing.Point(127, 26)
        Me.numDPX.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numDPX.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numDPX.Name = "numDPX"
        Me.numDPX.Size = New System.Drawing.Size(44, 20)
        Me.numDPX.TabIndex = 1
        Me.numDPX.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(181, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "dpy"
        '
        'numDPY
        '
        Me.numDPY.Enabled = False
        Me.numDPY.Location = New System.Drawing.Point(205, 26)
        Me.numDPY.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numDPY.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numDPY.Name = "numDPY"
        Me.numDPY.Size = New System.Drawing.Size(44, 20)
        Me.numDPY.TabIndex = 1
        Me.numDPY.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(267, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Page Size:"
        '
        'cmbPage
        '
        Me.cmbPage.Enabled = False
        Me.cmbPage.FormattingEnabled = True
        Me.cmbPage.Location = New System.Drawing.Point(331, 25)
        Me.cmbPage.Name = "cmbPage"
        Me.cmbPage.Size = New System.Drawing.Size(103, 21)
        Me.cmbPage.TabIndex = 2
        Me.cmbPage.Text = "A4"
        '
        'txtProjFolder
        '
        Me.txtProjFolder.Enabled = False
        Me.txtProjFolder.Location = New System.Drawing.Point(100, 61)
        Me.txtProjFolder.Name = "txtProjFolder"
        Me.txtProjFolder.Size = New System.Drawing.Size(244, 20)
        Me.txtProjFolder.TabIndex = 3
        Me.txtProjFolder.Text = "C:\AmhOCR\Projects"
        '
        'btnBrowseProjFold
        '
        Me.btnBrowseProjFold.Enabled = False
        Me.btnBrowseProjFold.Location = New System.Drawing.Point(359, 59)
        Me.btnBrowseProjFold.Name = "btnBrowseProjFold"
        Me.btnBrowseProjFold.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseProjFold.TabIndex = 2
        Me.btnBrowseProjFold.Text = "Browse"
        Me.btnBrowseProjFold.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Project Folder:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Data Folder:"
        '
        'btnBrowseDataFold
        '
        Me.btnBrowseDataFold.Enabled = False
        Me.btnBrowseDataFold.Location = New System.Drawing.Point(359, 87)
        Me.btnBrowseDataFold.Name = "btnBrowseDataFold"
        Me.btnBrowseDataFold.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDataFold.TabIndex = 2
        Me.btnBrowseDataFold.Text = "Browse"
        Me.btnBrowseDataFold.UseVisualStyleBackColor = True
        '
        'txtDataFolder
        '
        Me.txtDataFolder.Enabled = False
        Me.txtDataFolder.Location = New System.Drawing.Point(100, 89)
        Me.txtDataFolder.Name = "txtDataFolder"
        Me.txtDataFolder.Size = New System.Drawing.Size(244, 20)
        Me.txtDataFolder.TabIndex = 3
        Me.txtDataFolder.Text = "C:\AmhOCR\Data"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Conversion Folder"
        '
        'btnBrowseConvFold
        '
        Me.btnBrowseConvFold.Enabled = False
        Me.btnBrowseConvFold.Location = New System.Drawing.Point(359, 118)
        Me.btnBrowseConvFold.Name = "btnBrowseConvFold"
        Me.btnBrowseConvFold.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseConvFold.TabIndex = 2
        Me.btnBrowseConvFold.Text = "Browse"
        Me.btnBrowseConvFold.UseVisualStyleBackColor = True
        '
        'txtConvFolder
        '
        Me.txtConvFolder.Enabled = False
        Me.txtConvFolder.Location = New System.Drawing.Point(100, 120)
        Me.txtConvFolder.Name = "txtConvFolder"
        Me.txtConvFolder.Size = New System.Drawing.Size(244, 20)
        Me.txtConvFolder.TabIndex = 3
        Me.txtConvFolder.Text = "C:\AmhOCR\Converts"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(465, 455)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(457, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General Setting"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(163, 468)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(106, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save and Close"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbPageSegmentation
        '
        Me.cmbPageSegmentation.Enabled = False
        Me.cmbPageSegmentation.FormattingEnabled = True
        Me.cmbPageSegmentation.Location = New System.Drawing.Point(118, 51)
        Me.cmbPageSegmentation.Name = "cmbPageSegmentation"
        Me.cmbPageSegmentation.Size = New System.Drawing.Size(316, 21)
        Me.cmbPageSegmentation.TabIndex = 5
        Me.cmbPageSegmentation.Text = "Auto"
        '
        'cmbEngine
        '
        Me.cmbEngine.Enabled = False
        Me.cmbEngine.FormattingEnabled = True
        Me.cmbEngine.Location = New System.Drawing.Point(118, 19)
        Me.cmbEngine.Name = "cmbEngine"
        Me.cmbEngine.Size = New System.Drawing.Size(87, 21)
        Me.cmbEngine.TabIndex = 6
        Me.cmbEngine.Text = "LSTM"
        '
        'btnErrorColorChange
        '
        Me.btnErrorColorChange.Location = New System.Drawing.Point(130, 19)
        Me.btnErrorColorChange.Name = "btnErrorColorChange"
        Me.btnErrorColorChange.Size = New System.Drawing.Size(75, 23)
        Me.btnErrorColorChange.TabIndex = 2
        Me.btnErrorColorChange.Text = "Change"
        Me.btnErrorColorChange.UseVisualStyleBackColor = True
        '
        'btnUserColorChange
        '
        Me.btnUserColorChange.Location = New System.Drawing.Point(362, 18)
        Me.btnUserColorChange.Name = "btnUserColorChange"
        Me.btnUserColorChange.Size = New System.Drawing.Size(75, 23)
        Me.btnUserColorChange.TabIndex = 2
        Me.btnUserColorChange.Text = "Change"
        Me.btnUserColorChange.UseVisualStyleBackColor = True
        '
        'UserPreference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 503)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserPreference"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Preference"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.numTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numThreadNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numDPX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDPY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbLang As ComboBox
    Friend WithEvents numThreadNumber As NumericUpDown
    Friend WithEvents numTimeout As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAmhFont As Button
    Friend WithEvents txtAmhfont As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnDefaultFont As Button
    Friend WithEvents txtDefaultfont As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblUserColor As Label
    Friend WithEvents lblSpellColor As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents numDPY As NumericUpDown
    Friend WithEvents numDPX As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbPage As ComboBox
    Friend WithEvents txtConvFolder As TextBox
    Friend WithEvents txtDataFolder As TextBox
    Friend WithEvents txtProjFolder As TextBox
    Friend WithEvents btnBrowseConvFold As Button
    Friend WithEvents btnBrowseDataFold As Button
    Friend WithEvents btnBrowseProjFold As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbEngine As ComboBox
    Friend WithEvents cmbPageSegmentation As ComboBox
    Friend WithEvents btnUserColorChange As Button
    Friend WithEvents btnErrorColorChange As Button
End Class
