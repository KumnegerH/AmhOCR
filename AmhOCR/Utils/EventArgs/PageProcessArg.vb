Public Class PageProcessArg
    Inherits EventArgs
    Public PageNumber As Integer
    Public Sub New(ByVal pagenum As Integer)
        PageNumber = pagenum
    End Sub
End Class
