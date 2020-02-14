Public Class RecognizeAreaArg
    Inherits EventArgs
    Public box As Rectangle
    Public filename As String
    Public BoxAreaID As Integer
    Public pageMode As PageSegMode

    Public Sub New(ByVal bbox As Rectangle, ByVal imgName As String, ByVal areaID As Integer, ByVal _PageSegMode As PageSegMode)
        box = bbox
        filename = imgName
        BoxAreaID = areaID
        pageMode = _PageSegMode
    End Sub
    Public Sub New(ByVal bbox As Rectangle, ByVal imgName As String, ByVal _PageSegMode As PageSegMode)
        box = bbox
        filename = imgName
        pageMode = _PageSegMode
    End Sub
End Class
