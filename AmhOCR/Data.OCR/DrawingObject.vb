
Public Class DrawingObject

    Friend type As DrawingType
    Friend Points As List(Of Point)
    Friend BoundingBox As Rectangle

    Friend Sub New()
        type = DrawingType.Rectangle
        Points = New List(Of Point)
        BoundingBox = New Rectangle
        BoundingBox = Rectangle.Empty
    End Sub

End Class
