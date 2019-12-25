Public Class RemoveOCRobjectArg
    Inherits EventArgs
    Public filename As String
    Public HocrID As Integer
    Public Sub New(ByVal _filename As String, ByVal _HocrID As Integer)
        filename = _filename
        HocrID = _HocrID
    End Sub
End Class
