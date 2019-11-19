'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

Public Class BatchProgressControl

    Public IsPause As Boolean = False
    Public CancelRequested As Boolean = False
    Public CompetedTasks As Integer = 0
    Public TotalTasks As Integer = 0
    Public CompletedProcess As Integer = 0
    Public PausedProcess As Integer = 0

    Public NumberOfProcess As Integer = 1

    Private lblImageInprocess As String = ""
    Private LapTime As Date

    Private TotalRunTime As TimeSpan

    Private Sub BatchProgressControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub



    Public Sub SetProgressBar(ByVal maxVal As Integer)

        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = maxVal
    End Sub



    Public Overloads Sub UpdateSubProgress(ByVal stage As String)

        If IsPause = False AndAlso CancelRequested = False Then
            lblStage.Text = stage + "  " + lblImageInprocess
        End If

    End Sub



    Private PauseMainString As String = String.Empty
    Private Delegate Sub DelegateUpdateMainStatus(ByVal Pause As Boolean)
    Public Overloads Sub UpdateMainStatus(ByVal Pause As Boolean)
        If Me.InvokeRequired Then
            Dim delg As New DelegateUpdateMainStatus(AddressOf UpdateMainStatus)
            Me.Invoke(delg, Pause)
        Else
            If Pause = True Then
                lblStage.ForeColor = Color.Red
                lblProg.ForeColor = Color.Red
                lblStage.Text = "Process Paused"

                PauseMainString = Me.Text

                Me.Text = "Process Paused completing " + CompetedTasks.ToString + " of " + TotalTasks.ToString
            Else
                lblStage.ForeColor = Color.Navy
                lblProg.ForeColor = Color.Navy
                If Not String.IsNullOrEmpty(PauseMainString) Then
                    Me.Text = PauseMainString
                End If

                PauseMainString = String.Empty
            End If
        End If


    End Sub


    Public Overloads Sub UpdateImageProgress(ByVal imagename As String)
        lblImageInprocess = imagename
    End Sub



    Private Delegate Sub DelegateUpdateProgressBar(ByVal prg As Integer)
    Public Overloads Sub UpdateProgressBar(ByVal prg As Integer)


        If Me.InvokeRequired Then

            Dim delg As New DelegateUpdateProgressBar(AddressOf UpdateProgressBar)
            Me.Invoke(delg, prg)

        Else

            ProgressBar1.Value = prg
            lblProg.Text = Math.Floor(prg * 100 / TotalTasks).ToString + "%"

            If prg > 0 Then

                Dim Duration = Now - LapTime
                TotalRunTime += Duration
                Duration = MathHelp.DivideTimeSpan(TotalRunTime, CompetedTasks)
                Duration = MathHelp.MultiplyTimeSpan(Duration, TotalTasks - CompetedTasks)
                Me.Text = "Time Left: " + MathHelp.TimeSpanString(Duration)
                LapTime = Now
            Else

                LapTime = Now
                Me.Text = "Estimating Time Left..."

            End If
        End If
    End Sub

    Private Delegate Sub DelegateUpdateProgressText(ByVal prg As String)
    Public Overloads Sub UpdateProgressText(ByVal prg As String)
        If lblStage.InvokeRequired Then
            Dim delg As New DelegateUpdateProgressText(AddressOf UpdateProgressText)
            lblStage.Invoke(delg, prg)
        Else
            If IsPause = False AndAlso CancelRequested = False Then
                lblStage.Text = "Processed images... " + prg.ToString + " out of " + TotalTasks.ToString + " Images"
            End If
        End If


    End Sub



    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

        If CancelRequested = False Then

            lblStage.Text = "Please wait while Re-starting operation"

            btnRun.Enabled = False
            btnPause.Enabled = True
            IsPause = False
        End If



    End Sub


    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If CancelRequested = False Then
            PausedProcess = CompletedProcess
            IsPause = True

            lblProg.ForeColor = Color.Red
            lblStage.Text = "Please wait while pausing running operations."

            btnPause.Enabled = False
            btnRun.Enabled = True

        End If

    End Sub

    Private Sub BatchProgressControl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If CompletedProcess <> NumberOfProcess Then
                If CancelRequested = False Then
                    lblStage.Text = "Processes are running. Please wait while canceling"

                    Me.Cursor = Cursors.WaitCursor
                    CancelRequested = True
                    e.Cancel = True
                ElseIf CompletedProcess < NumberOfProcess Then
                    e.Cancel = True
                End If
            End If



        End If


    End Sub
End Class