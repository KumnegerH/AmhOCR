Public Class BoundingBoxArg
    Inherits EventArgs
    Public box As Rectangle
    Public Hocredit As Boolean
    Public isReset As Boolean
    Public HocrID As Integer
    Public Sub New(ByVal bbox As Rectangle, Optional edit As Boolean = False, Optional reset As Boolean = False, Optional _HocrID As Integer = -1)
        box = bbox
        Hocredit = edit
        isReset = reset
        HocrID = _HocrID
    End Sub

End Class
