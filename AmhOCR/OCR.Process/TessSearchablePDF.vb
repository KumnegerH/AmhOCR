

'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Imports NetTesseract

Public Class TessSearchablePDF

    Public Shared Function MakeSearchablePDF(ByVal Files() As String, ByVal OutputPath As String) As String
        Dim Logout As String = ""
        Using prog As New ProgressReport

            prog.Size = New Size(364, 100)
            prog.Text = "Converting images to PDF"
            prog.lbltext = "Progress: "
            prog.StartPosition = FormStartPosition.Manual

            prog.StartPosition = FormStartPosition.CenterParent

            prog.ProgressBar1.Style = ProgressBarStyle.Marquee
            prog.UpdateProgress("Pre-Processing")

            AddHandler prog.Shown,
                New EventHandler(Async Sub(s, e)
                                     prog.UpdateProgress("Recognizing and Converting to PDF")

                                     Using TessRecog As New ReadImage(OCRsettings.Language, OCRsettings.OcrMode)
                                         Logout = Await TessRecog.GetPDF(Files, OutputPath, OCRsettings.TimeOutPDF)
                                     End Using

                                     prog.UpdateProgress("Post-Processing")
                                     prog.Close()
                                 End Sub)


            prog.ShowDialog()






        End Using

        Return Logout
    End Function




End Class
