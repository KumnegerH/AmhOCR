<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImageOCRsetting
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkADthreshold = New System.Windows.Forms.CheckBox()
        Me.chkGray = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.TrackThresh = New System.Windows.Forms.TrackBar()
        Me.lblThreshold = New System.Windows.Forms.Label()
        Me.grpBoxThreshold = New System.Windows.Forms.GroupBox()
        Me.chkThreshold = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TrackBright = New System.Windows.Forms.TrackBar()
        Me.chkBright = New System.Windows.Forms.CheckBox()
        Me.lblBright = New System.Windows.Forms.Label()
        Me.lblGamma = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TrackGamma = New System.Windows.Forms.TrackBar()
        Me.chkGamma = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TrackContrast = New System.Windows.Forms.TrackBar()
        Me.chkContrast = New System.Windows.Forms.CheckBox()
        Me.lblContrast = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TrackThresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBoxThreshold.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TrackBright, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TrackGamma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.TrackContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkADthreshold)
        Me.GroupBox1.Controls.Add(Me.chkGray)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 47)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Color Options"
        '
        'chkADthreshold
        '
        Me.chkADthreshold.AutoSize = True
        Me.chkADthreshold.Location = New System.Drawing.Point(292, 19)
        Me.chkADthreshold.Name = "chkADthreshold"
        Me.chkADthreshold.Size = New System.Drawing.Size(118, 17)
        Me.chkADthreshold.TabIndex = 0
        Me.chkADthreshold.Text = "Adaptive Threshold"
        Me.chkADthreshold.UseVisualStyleBackColor = True
        '
        'chkGray
        '
        Me.chkGray.AutoSize = True
        Me.chkGray.Location = New System.Drawing.Point(6, 19)
        Me.chkGray.Name = "chkGray"
        Me.chkGray.Size = New System.Drawing.Size(78, 17)
        Me.chkGray.TabIndex = 0
        Me.chkGray.Text = "Gray Scale"
        Me.chkGray.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(349, 276)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 1
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(171, 276)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Apply and Save "
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TrackThresh
        '
        Me.TrackThresh.AutoSize = False
        Me.TrackThresh.Enabled = False
        Me.TrackThresh.LargeChange = 10
        Me.TrackThresh.Location = New System.Drawing.Point(2, 31)
        Me.TrackThresh.Maximum = 254
        Me.TrackThresh.Minimum = 1
        Me.TrackThresh.Name = "TrackThresh"
        Me.TrackThresh.Size = New System.Drawing.Size(178, 36)
        Me.TrackThresh.TabIndex = 1
        Me.TrackThresh.TickFrequency = 10
        Me.TrackThresh.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.TrackThresh.Value = 125
        '
        'lblThreshold
        '
        Me.lblThreshold.AutoSize = True
        Me.lblThreshold.Location = New System.Drawing.Point(178, 43)
        Me.lblThreshold.Name = "lblThreshold"
        Me.lblThreshold.Size = New System.Drawing.Size(25, 13)
        Me.lblThreshold.TabIndex = 2
        Me.lblThreshold.Text = "254"
        '
        'grpBoxThreshold
        '
        Me.grpBoxThreshold.BackColor = System.Drawing.SystemColors.Control
        Me.grpBoxThreshold.Controls.Add(Me.TrackThresh)
        Me.grpBoxThreshold.Controls.Add(Me.chkThreshold)
        Me.grpBoxThreshold.Controls.Add(Me.lblThreshold)
        Me.grpBoxThreshold.Enabled = False
        Me.grpBoxThreshold.Location = New System.Drawing.Point(6, 19)
        Me.grpBoxThreshold.Name = "grpBoxThreshold"
        Me.grpBoxThreshold.Size = New System.Drawing.Size(210, 72)
        Me.grpBoxThreshold.TabIndex = 3
        Me.grpBoxThreshold.TabStop = False
        '
        'chkThreshold
        '
        Me.chkThreshold.AutoSize = True
        Me.chkThreshold.Location = New System.Drawing.Point(6, 8)
        Me.chkThreshold.Name = "chkThreshold"
        Me.chkThreshold.Size = New System.Drawing.Size(98, 17)
        Me.chkThreshold.TabIndex = 0
        Me.chkThreshold.Text = "Threshold Filetr"
        Me.chkThreshold.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.TrackBright)
        Me.GroupBox3.Controls.Add(Me.chkBright)
        Me.GroupBox3.Controls.Add(Me.lblBright)
        Me.GroupBox3.Location = New System.Drawing.Point(222, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 72)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'TrackBright
        '
        Me.TrackBright.AutoSize = False
        Me.TrackBright.Enabled = False
        Me.TrackBright.LargeChange = 10
        Me.TrackBright.Location = New System.Drawing.Point(1, 29)
        Me.TrackBright.Maximum = 255
        Me.TrackBright.Minimum = -255
        Me.TrackBright.Name = "TrackBright"
        Me.TrackBright.Size = New System.Drawing.Size(170, 35)
        Me.TrackBright.TabIndex = 1
        Me.TrackBright.TickFrequency = 10
        Me.TrackBright.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'chkBright
        '
        Me.chkBright.AutoSize = True
        Me.chkBright.Location = New System.Drawing.Point(6, 8)
        Me.chkBright.Name = "chkBright"
        Me.chkBright.Size = New System.Drawing.Size(126, 17)
        Me.chkBright.TabIndex = 0
        Me.chkBright.Text = "Brightness Correction"
        Me.chkBright.UseVisualStyleBackColor = True
        '
        'lblBright
        '
        Me.lblBright.AutoSize = True
        Me.lblBright.Location = New System.Drawing.Point(168, 43)
        Me.lblBright.Name = "lblBright"
        Me.lblBright.Size = New System.Drawing.Size(13, 13)
        Me.lblBright.TabIndex = 2
        Me.lblBright.Text = "0"
        '
        'lblGamma
        '
        Me.lblGamma.AutoSize = True
        Me.lblGamma.Location = New System.Drawing.Point(166, 44)
        Me.lblGamma.Name = "lblGamma"
        Me.lblGamma.Size = New System.Drawing.Size(22, 13)
        Me.lblGamma.TabIndex = 2
        Me.lblGamma.Text = "2.5"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.TrackGamma)
        Me.GroupBox4.Controls.Add(Me.chkGamma)
        Me.GroupBox4.Controls.Add(Me.lblGamma)
        Me.GroupBox4.Location = New System.Drawing.Point(228, 97)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(194, 74)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'TrackGamma
        '
        Me.TrackGamma.AutoSize = False
        Me.TrackGamma.Enabled = False
        Me.TrackGamma.Location = New System.Drawing.Point(6, 32)
        Me.TrackGamma.Maximum = 50
        Me.TrackGamma.Name = "TrackGamma"
        Me.TrackGamma.Size = New System.Drawing.Size(163, 37)
        Me.TrackGamma.TabIndex = 1
        Me.TrackGamma.TickFrequency = 5
        Me.TrackGamma.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.TrackGamma.Value = 10
        '
        'chkGamma
        '
        Me.chkGamma.AutoSize = True
        Me.chkGamma.Location = New System.Drawing.Point(6, 14)
        Me.chkGamma.Name = "chkGamma"
        Me.chkGamma.Size = New System.Drawing.Size(113, 17)
        Me.chkGamma.TabIndex = 0
        Me.chkGamma.Text = "Gamma Correction"
        Me.chkGamma.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.TrackContrast)
        Me.GroupBox5.Controls.Add(Me.chkContrast)
        Me.GroupBox5.Controls.Add(Me.lblContrast)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 97)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(210, 74)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'TrackContrast
        '
        Me.TrackContrast.AutoSize = False
        Me.TrackContrast.Enabled = False
        Me.TrackContrast.Location = New System.Drawing.Point(2, 32)
        Me.TrackContrast.Maximum = 127
        Me.TrackContrast.Minimum = -127
        Me.TrackContrast.Name = "TrackContrast"
        Me.TrackContrast.Size = New System.Drawing.Size(178, 31)
        Me.TrackContrast.TabIndex = 1
        Me.TrackContrast.TickFrequency = 10
        Me.TrackContrast.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'chkContrast
        '
        Me.chkContrast.AutoSize = True
        Me.chkContrast.Location = New System.Drawing.Point(6, 9)
        Me.chkContrast.Name = "chkContrast"
        Me.chkContrast.Size = New System.Drawing.Size(116, 17)
        Me.chkContrast.TabIndex = 0
        Me.chkContrast.Text = "Contrast Correction"
        Me.chkContrast.UseVisualStyleBackColor = True
        '
        'lblContrast
        '
        Me.lblContrast.AutoSize = True
        Me.lblContrast.Location = New System.Drawing.Point(186, 44)
        Me.lblContrast.Name = "lblContrast"
        Me.lblContrast.Size = New System.Drawing.Size(13, 13)
        Me.lblContrast.TabIndex = 2
        Me.lblContrast.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(431, 251)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pre-Process Image Setting /will be applied only during recognition/"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GroupBox3)
        Me.GroupBox7.Controls.Add(Me.GroupBox5)
        Me.GroupBox7.Controls.Add(Me.grpBoxThreshold)
        Me.GroupBox7.Controls.Add(Me.GroupBox4)
        Me.GroupBox7.Location = New System.Drawing.Point(0, 72)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(431, 186)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Enhance Image"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(10, 276)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Cancel"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'ImageOCRsetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(438, 323)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImageOCRsetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image OCR Setting:   "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TrackThresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBoxThreshold.ResumeLayout(False)
        Me.grpBoxThreshold.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TrackBright, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TrackGamma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.TrackContrast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkGray As CheckBox
    Friend WithEvents btnReset As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents TrackThresh As TrackBar
    Friend WithEvents lblThreshold As Label
    Friend WithEvents grpBoxThreshold As GroupBox
    Friend WithEvents chkThreshold As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TrackBright As TrackBar
    Friend WithEvents chkBright As CheckBox
    Friend WithEvents lblGamma As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TrackGamma As TrackBar
    Friend WithEvents chkGamma As CheckBox
    Friend WithEvents lblBright As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TrackContrast As TrackBar
    Friend WithEvents chkContrast As CheckBox
    Friend WithEvents lblContrast As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnApply As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents chkADthreshold As CheckBox
End Class
