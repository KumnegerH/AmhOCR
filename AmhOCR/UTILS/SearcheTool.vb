

Public Class SearcheTool


    Public Event SearchRequest As EventHandler(Of TextSearchArg)
    Public Event NextRequest As EventHandler
    Public Event PreviousRequest As EventHandler
    Public imgs As List(Of Image)
    Private txt As String = String.Empty

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click


        Dim newtxt = txtSearch.Text.Trim(" ")

        If newtxt <> txt Then

            txt = newtxt
            Dim arg As New TextSearchArg(txt)
            RaiseEvent SearchRequest(Me, arg)

        End If




    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click


        If Not String.IsNullOrEmpty(txt) Then
            RaiseEvent NextRequest(Me, Nothing)
        End If


    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click


        If Not String.IsNullOrEmpty(txt) Then
            RaiseEvent PreviousRequest(Me, Nothing)
        End If


    End Sub
End Class