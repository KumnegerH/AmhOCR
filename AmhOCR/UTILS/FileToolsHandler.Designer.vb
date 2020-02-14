<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileToolsHandler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileToolsHandler))
        Me.dirbtm = New System.Windows.Forms.Button()
        Me.ouputDirTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.importedItems = New System.Windows.Forms.CheckedListBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnStartUtil = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUP = New System.Windows.Forms.ToolStripButton()
        Me.btnDown = New System.Windows.Forms.ToolStripButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dirbtm
        '
        Me.dirbtm.Enabled = False
        Me.dirbtm.Location = New System.Drawing.Point(476, 320)
        Me.dirbtm.Name = "dirbtm"
        Me.dirbtm.Size = New System.Drawing.Size(53, 23)
        Me.dirbtm.TabIndex = 5
        Me.dirbtm.Text = "Browse"
        Me.dirbtm.UseVisualStyleBackColor = True
        '
        'ouputDirTxt
        '
        Me.ouputDirTxt.Enabled = False
        Me.ouputDirTxt.Location = New System.Drawing.Point(86, 322)
        Me.ouputDirTxt.Name = "ouputDirTxt"
        Me.ouputDirTxt.ReadOnly = True
        Me.ouputDirTxt.Size = New System.Drawing.Size(381, 20)
        Me.ouputDirTxt.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 325)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Output Folder"
        '
        'importedItems
        '
        Me.importedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.importedItems.FormattingEnabled = True
        Me.importedItems.Location = New System.Drawing.Point(3, 16)
        Me.importedItems.Name = "importedItems"
        Me.importedItems.Size = New System.Drawing.Size(511, 236)
        Me.importedItems.TabIndex = 8
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 360)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(514, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 9
        Me.ProgressBar1.Visible = False
        '
        'btnStartUtil
        '
        Me.btnStartUtil.Enabled = False
        Me.btnStartUtil.Location = New System.Drawing.Point(240, 360)
        Me.btnStartUtil.Name = "btnStartUtil"
        Me.btnStartUtil.Size = New System.Drawing.Size(75, 23)
        Me.btnStartUtil.TabIndex = 10
        Me.btnStartUtil.Text = "GO"
        Me.btnStartUtil.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.importedItems)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 255)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Items List"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImport, Me.btnDown, Me.ToolStripSeparator1, Me.btnUP})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(541, 25)
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(84, 22)
        Me.btnImport.Text = "Import File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnUP
        '
        Me.btnUP.Image = CType(resources.GetObject("btnUP.Image"), System.Drawing.Image)
        Me.btnUP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(134, 22)
        Me.btnUP.Text = "Move Document Up"
        Me.btnUP.Visible = False
        '
        'btnDown
        '
        Me.btnDown.Image = CType(resources.GetObject("btnDown.Image"), System.Drawing.Image)
        Me.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(150, 22)
        Me.btnDown.Text = "Move Document Down"
        Me.btnDown.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(18, 29)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 17)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Unchake All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'UtilityHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 396)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStartUtil)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.dirbtm)
        Me.Controls.Add(Me.ouputDirTxt)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UtilityHandler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiff Utility"
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dirbtm As Button
    Friend WithEvents ouputDirTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents importedItems As CheckedListBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnStartUtil As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnImport As ToolStripButton
    Friend WithEvents btnUP As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnDown As ToolStripButton
    Friend WithEvents CheckBox1 As CheckBox
End Class
