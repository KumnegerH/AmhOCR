Public Class BoxHighlightedArg
    Inherits EventArgs
    Public box As Rectangle
    Public Sub New(ByVal bbox As Rectangle)
        box = bbox
    End Sub

End Class
