<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BatchProgressControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchProgressControl))
        Me.btnPause = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblStage = New System.Windows.Forms.Label()
        Me.lblProg = New System.Windows.Forms.Label()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPause
        '
        Me.btnPause.Image = CType(resources.GetObject("btnPause.Image"), System.Drawing.Image)
        Me.btnPause.Location = New System.Drawing.Point(12, 16)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(19, 23)
        Me.btnPause.TabIndex = 0
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Pause_22x.png")
        Me.ImageList1.Images.SetKeyName(1, "Play_22x.png")
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(61, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(283, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'lblStage
        '
        Me.lblStage.AutoSize = True
        Me.lblStage.ForeColor = System.Drawing.Color.Navy
        Me.lblStage.Location = New System.Drawing.Point(58, 42)
        Me.lblStage.Name = "lblStage"
        Me.lblStage.Size = New System.Drawing.Size(69, 13)
        Me.lblStage.TabIndex = 2
        Me.lblStage.Text = "Recognizing:"
        '
        'lblProg
        '
        Me.lblProg.AutoSize = True
        Me.lblProg.ForeColor = System.Drawing.Color.Navy
        Me.lblProg.Location = New System.Drawing.Point(350, 21)
        Me.lblProg.Name = "lblProg"
        Me.lblProg.Size = New System.Drawing.Size(21, 13)
        Me.lblProg.TabIndex = 4
        Me.lblProg.Text = "0%"
        '
        'btnRun
        '
        Me.btnRun.Enabled = False
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.Location = New System.Drawing.Point(37, 16)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(20, 23)
        Me.btnRun.TabIndex = 0
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'BatchProgressControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 67)
        Me.Controls.Add(Me.lblProg)
        Me.Controls.Add(Me.lblStage)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnPause)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BatchProgressControl"
        Me.Text = "Batch OCR Process"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPause As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblStage As Label

    Friend WithEvents lblProg As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnRun As Button
End Class
