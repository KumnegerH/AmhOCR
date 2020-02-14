
Public Class User_Draw_Manager
    Inherits Control

    Private MyParent As ImageViewControl





    Public Sub New(ByVal parent As ImageViewControl)

        MyParent = parent



    End Sub

    Friend Sub WhenMouseDown(ByVal e As MouseEventArgs)

        If e.Button = MouseButtons.Right Then

            MyParent.State = controlState.None
            MyParent.Cursor = Cursors.Default
            MyParent.drawingObject = New DrawingObject

        End If


    End Sub


    Friend Sub WhenMouseUp(ByVal e As MouseEventArgs)




        If MyParent.drawingObject.type = DrawingType.Rectangle Then

            MyParent.EndRectangleDrawing()

            EndEdit()


        ElseIf MyParent.drawingObject.type = DrawingType.Quadrilateral Then

            If MyParent.drawingObject.Points.Count = 4 Then

                MyParent.State = controlState.ObjectSelection
                EndEdit()

            Else

                MyParent.drawingObject.Points.Add(MyParent.MouseLocation)

            End If

        ElseIf MyParent.drawingObject.type <> DrawingType.Brush Then

            MyParent.drawingObject.Points.Add(MyParent.MouseLocation)

            EndEdit()

        Else

            MyParent.State = controlState.None
            MyParent.EndRegionEdit()
            EndEdit()
        End If


    End Sub

    Friend Sub WhenMouseMove(ByVal e As MouseEventArgs)
        MyParent.MouseLocation = MyParent.ClientToImagePoint(e.Location)

        MyParent.OnDrawingMouseMove(e)
    End Sub


    Friend Sub WhenKeyDown(ByVal e As KeyEventArgs)

        If e.KeyCode = Keys.Escape Then

            MyParent.ResizeRecType = -1
            MyParent.ResizeRecHighlighted = False
            MyParent.State = controlState.None
            MyParent.Cursor = Cursors.Arrow
            MyParent.PreviouscontrolState = controlState.None
            MyParent.drawingObject = New DrawingObject
            MyParent.Invalidate()
            EndEdit()
        End If
    End Sub


    Private Sub EndEdit()

        MyParent = Nothing


    End Sub
End Class
