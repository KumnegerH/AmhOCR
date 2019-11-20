
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

Imports GhostscriptSharp
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel

Public Class PdfToImages

    Public AllFileCopy As List(Of String)
    Public convertPath As String = ""
    Public justWait As Boolean = True


    Private NumberOfPage = 1
    Private AllFiles As List(Of String)
    Private lbltext = "Total Number of Pages Converted: "


    Private Sub PdfToImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ouputDirTxt.Text = OCRsettings.AmhOcrTempFolder

        ' checkedItem.Items.Clear()

    End Sub

    Public Sub UpdateLoading(ByVal LoadImg As String, ByVal Prog As Integer)

        progLabl.Text = LoadImg + ": " + Prog.ToString + "/of" + NumberOfPage.ToString
        ProgressBar1.Value = Prog
    End Sub



    Public Async Function readGhost(ByVal fileNames As String()) As Task(Of Boolean)

        Dim cnt As Integer = 1
        Dim succsses As Boolean = False
        ProgressBar1.Style = ProgressBarStyle.Marquee
        checkedItem.Focus()
        checkedItem.Capture = True


        progLabl.Text = lbltext + "0"
        Dim OutputFormat As String = ""




        Try


            AllFiles = New List(Of String)
            AllFileCopy = New List(Of String)

            convertPath = ouputDirTxt.Text

            If Not Directory.Exists(convertPath) Then
                Directory.CreateDirectory(convertPath)
            End If


            ProgressBar1.Style = ProgressBarStyle.Blocks
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = fileNames.Count



            Using BackgroundWorker1 = New BackgroundWorker

                BackgroundWorker1.WorkerSupportsCancellation = True

                AddHandler BackgroundWorker1.DoWork,
                    New DoWorkEventHandler(
                    Sub(s, e)

                        Dim fileName As String = e.Argument

                        Dim stei = New GhostscriptSettings
                        stei.Device = OCRsettings.imgFormat
                        If OCRsettings.isCustomePage = True Then
                            stei.Size.Manual = OCRsettings.PageSize
                        Else
                            stei.Size.Native = OCRsettings.NativePage
                        End If

                        stei.Resolution = OCRsettings.Resolution

                        Dim cleanName = Path.GetFileNameWithoutExtension(fileName)
                        cleanName = convertPath + "\" + cleanName + "_page_%d.jpeg"

                        GhostscriptWrapper.GenerateOutput(fileName, cleanName, stei)

                    End Sub)






                Dim cntTotalPage As Integer = 0
                For Each fileName In fileNames


                    Using pdfRead As New iTextSharp.text.pdf.PdfReader(fileName)
                        NumberOfPage = pdfRead.NumberOfPages
                    End Using

                    ProgressBar1.Value = 0
                    ProgressBar1.Maximum = NumberOfPage

                    Dim cleanName = Path.GetFileNameWithoutExtension(fileName)

                    For pg As Integer = 1 To NumberOfPage

                        AllFiles.Add(convertPath + "\" + cleanName + "_page_" + pg.ToString + ".jpeg")
                    Next

                    BackgroundWorker1.RunWorkerAsync(fileName)

                    Do While BackgroundWorker1.IsBusy

                        Dim files = Directory.GetFiles(convertPath).OrderBy(Function(X) X)

                        For Each file In files
                            If AllFiles.Contains(file) Then

                                If AllFileCopy.Contains(file) = False Then
                                    AllFileCopy.Add(file)

                                    Name = Path.GetFileName(file)
                                    Dim item = checkedItem.Items.Add(Name, True)

                                    checkedItem.TopIndex = checkedItem.Items.Count - 1
                                    checkedItem.SelectedItem = item
                                End If

                            End If


                        Next

                        UpdateLoading(fileName, (AllFileCopy.Count - cntTotalPage))
                        Me.Invalidate()
                        Await TaskEx.Delay(20)

                    Loop

                    cnt += 1
                    cntTotalPage += NumberOfPage
                Next


            End Using

            succsses = True

        Catch ex As Exception

            succsses = False
        Finally

        End Try


        Return succsses
    End Function




    Public Function GetFiles() As List(Of String)
        Dim ReturnNames = AllFileCopy.ToList

        justWait = False

        Return ReturnNames

    End Function




    Private Sub PdfToImages_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


    End Sub

    Private Sub PdfToImages_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If justWait = True Then
                e.Cancel = True
                Beep()

            End If
        End If

    End Sub

    Private Sub dirbtm_Click(sender As Object, e As EventArgs) Handles dirbtm.Click
        Using fldr = New FolderBrowserDialog
            fldr.ShowNewFolderButton = True
            fldr.Description = "Select Output folder"
            fldr.SelectedPath = OCRsettings.AmhOcrConvFolder
            If fldr.ShowDialog(Me) = DialogResult.OK Then
                ouputDirTxt.Text = fldr.SelectedPath
            End If

        End Using
    End Sub
End Class