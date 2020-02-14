Public Class TextSearchArg
    Inherits EventArgs
    Public TextToSearch As String
    Public Sub New(ByVal txt As String)
        TextToSearch = txt
    End Sub
End Class
