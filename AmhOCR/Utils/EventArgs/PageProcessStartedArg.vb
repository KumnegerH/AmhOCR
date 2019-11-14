Public Class PageProcessStartedArg
    Inherits EventArgs
    Public TotalPages As Integer
    Public FileName As String
    Public Sub New(ByVal name As String, ByVal totalPage As Integer)
        TotalPages = totalPage
        FileName = name
    End Sub
End Class
