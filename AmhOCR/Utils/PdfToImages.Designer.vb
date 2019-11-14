<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PdfToImages
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ouputDirTxt = New System.Windows.Forms.TextBox()
        Me.dirbtm = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.progLabl = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.checkedItem = New System.Windows.Forms.CheckedListBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Output Folder"
        '
        'ouputDirTxt
        '
        Me.ouputDirTxt.Enabled = False
        Me.ouputDirTxt.Location = New System.Drawing.Point(89, 28)
        Me.ouputDirTxt.Name = "ouputDirTxt"
        Me.ouputDirTxt.ReadOnly = True
        Me.ouputDirTxt.Size = New System.Drawing.Size(306, 20)
        Me.ouputDirTxt.TabIndex = 1
        '
        'dirbtm
        '
        Me.dirbtm.Enabled = False
        Me.dirbtm.Location = New System.Drawing.Point(401, 26)
        Me.dirbtm.Name = "dirbtm"
        Me.dirbtm.Size = New System.Drawing.Size(65, 23)
        Me.dirbtm.TabIndex = 2
        Me.dirbtm.Text = "Browse"
        Me.dirbtm.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Progress:"
        '
        'progLabl
        '
        Me.progLabl.AutoSize = True
        Me.progLabl.Location = New System.Drawing.Point(86, 68)
        Me.progLabl.Name = "progLabl"
        Me.progLabl.Size = New System.Drawing.Size(0, 13)
        Me.progLabl.TabIndex = 0
        '
        'btnImport
        '
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(191, 311)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 4
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        Me.btnImport.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 311)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(451, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 153)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(380, 140)
        Me.DataGridView1.TabIndex = 6
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'checkedItem
        '
        Me.checkedItem.FormattingEnabled = True
        Me.checkedItem.Location = New System.Drawing.Point(12, 96)
        Me.checkedItem.Name = "checkedItem"
        Me.checkedItem.Size = New System.Drawing.Size(454, 199)
        Me.checkedItem.TabIndex = 7
        '
        'PdfToImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 346)
        Me.Controls.Add(Me.checkedItem)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.dirbtm)
        Me.Controls.Add(Me.ouputDirTxt)
        Me.Controls.Add(Me.progLabl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PdfToImages"
        Me.Text = "Pdf To Images"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ouputDirTxt As TextBox
    Friend WithEvents dirbtm As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents progLabl As Label
    Friend WithEvents btnImport As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents checkedItem As CheckedListBox
End Class
