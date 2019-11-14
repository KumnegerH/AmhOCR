'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class ProgressReport


    Public lbltext As String = "Loading: "



    Private Delegate Sub DelegateUpdateFormTextByVal(ByVal Formtxt As String)


    Public Sub UpdateFormText(ByVal Formtxt As String)

        If Me.InvokeRequired Then
            Dim delg As New DelegateUpdateFormTextByVal(AddressOf UpdateFormText)
            Me.Invoke(delg, Formtxt)
        Else
            Me.Text = Formtxt
        End If

    End Sub


    Public Sub SetProgres(ByVal totProg As Integer)

        ProgressBar1.Value = 0
        ProgressBar1.Maximum = totProg

    End Sub

    Public Overloads Sub UpdateProgress(ByVal LoadImg As String, ByVal Prog As Integer)

        Label1.Text = lbltext + LoadImg
        ProgressBar1.Value = Prog
    End Sub

    Private Delegate Sub UpdateProgressString(ByVal LoadImg As String)
    Public Overloads Sub UpdateProgress(ByVal LoadImg As String)

        If Label1.InvokeRequired Then
            Dim delg As New UpdateProgressString(AddressOf UpdateProgress)
            Label1.Invoke(delg, LoadImg)
        Else
            Label1.Text = lbltext + LoadImg
        End If
    End Sub

    Private Delegate Sub UpdateProgressInteger(ByVal prg As Integer)
    Public Overloads Sub UpdateProgress(ByVal prg As Integer)
        If ProgressBar1.InvokeRequired Then
            Dim delg As New UpdateProgressInteger(AddressOf UpdateProgress)
            ProgressBar1.Invoke(delg, prg)
        Else
            ProgressBar1.Value = prg
        End If

    End Sub

End Class