Public Class PdfMergedArg
    Inherits EventArgs
    Public FileName As String
    Public FileNumber As Integer
    Public Sub New(ByVal name As String, ByVal count As Integer)
        FileName = name
        FileNumber = count
    End Sub
End Class
