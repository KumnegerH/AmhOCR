Public Class PageRecognizedArg
    Inherits EventArgs
    Public pageNumber As Integer
    Public pageFileName As String
    Public Sub New(ByVal pagenum As Integer, filename As String)
        pageNumber = pagenum
        pageFileName = filename
    End Sub
End Class
