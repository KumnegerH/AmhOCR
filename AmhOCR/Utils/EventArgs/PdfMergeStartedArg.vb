Public Class PdfMergeStartedArg
    Inherits EventArgs
    Public TotalPDFtoMerge As Integer
    Public Sub New(ByVal pdfs As Integer)
        TotalPDFtoMerge = pdfs
    End Sub
End Class
