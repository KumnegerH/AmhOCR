
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class ImageEditControl
    Inherits ImageViewControl

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3



#Region "Members"






    Public Event SignalBusy As EventHandler

    Private SkipRefresh As Boolean = False



    ' Private RedoList As New List(Of EditMetadata)
    ' Private UndoList As New List(Of EditMetadata)


    Private UndoType As New List(Of Integer)
    Private RedoType As New List(Of Integer)



#End Region

#Region "Intitialize and End"


    Public Sub New()

        InitializeComponent()

    End Sub




    Public Overloads Sub DisposeImage()
        MyBase.DisposeImage()



    End Sub

    Private Sub ImageEditControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        GC.Collect()
    End Sub



    ''' <summary>
    ''' Reset edit state
    ''' </summary>
    Friend Sub ResetAllState()



        State = controlState.None
        PreviouscontrolState = controlState.None
        drawingObject.BoundingBox = New Rectangle
        ResizeRecHighlighted = False
        ResizeRecType = -1

        Invalidate()

    End Sub



#End Region

#Region "Tool Handlers"

    Public Sub Undo()

    End Sub

    Public Sub Redo()

    End Sub

    Private Sub CopyImageToClipboard()

        If Image IsNot Nothing Then

            Try
                Clipboard.SetImage(CopyAllToImage)
            Catch ex As Exception

            End Try


        End If


    End Sub




    ''' <summary>
    ''' Copy Image with the recognized text
    ''' </summary>
    ''' <returns></returns>
    Public Overloads Function CopyAllToImage() As Image

        Dim ImageCopy = _image.Clone
        ' Dim lins = PostProcessor.ColumnTest_Vertical(_HocrPage)

        ' lins = lins.OrderBy(Function(X) X.Y).Reverse.ToList



        Return ImageCopy
    End Function





#End Region

#Region "Control Events"


    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)

        If Image Is Nothing OrElse Freez = True OrElse
            Not Me.ClientRectangle.Contains(e.Location) Then

            Exit Sub

        End If



        If State = controlState.Draw Then

            DrawObjectManager.WhenMouseDown(e)


        Else

            If e.Button = MouseButtons.Left Then


                If State = controlState.ObjectSelection AndAlso
                            ResizeRecHighlighted = True Then


                    State = controlState.ResizeObject


                ElseIf State = controlState.ObjectSelection Then

                    If ResizeRecHighlighted = False Then

                        ' reset region edit if the previous map state is Draw 
                        EndRegionEdit()


                    End If

                ElseIf State = controlState.DrawStart Then

                    MouseLocation = ClientToImagePoint(e.Location)

                    Me.StartNewDrawing()

                    DrawObjectManager = New User_Draw_Manager(Me)

                ElseIf State = controlState.MoveStart Then
                    Dim pnt = ClientToImagePoint(e.Location)
                    MoveCurrentPosition = pnt
                    State = controlState.MoveImage
                    Cursor = Cursors.Hand

                Else
                    'Pass the event to the base class
                    MyBase.OnMouseDown(e)
                End If



            ElseIf e.Button = MouseButtons.Right Then

                If State = controlState.ObjectSelection Then

                    MyBase.OnBoxRightClick(e)

                ElseIf State = controlState.DrawStart Then

                    State = controlState.None
                    Cursor = Cursors.Default

                End If


            End If


            If HocrActive = False Then

                If Me.Focused = False Then

                    Me.Focus()

                End If


                Invalidate()


            End If


        End If






    End Sub


    Protected Overrides Sub OnPreviewKeyDown(ByVal e As PreviewKeyDownEventArgs)
        If Image Is Nothing Then
            Exit Sub
        End If

        MyBase.OnPreviewKeyDown(e)




    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        If Image Is Nothing Then
            Exit Sub
        End If

        If HocrActive = False Then


            If Me.ClientRectangle.
                    Contains(Me.PointToClient(Control.MousePosition)) Then

                If State = controlState.None Then
                    If e.Modifiers = Keys.Control Then
                        drawingObject = New DrawingObject
                        drawingObject.type = DrawingType.Rectangle
                        State = controlState.DrawStart
                        Cursor = Cursors.Cross
                        Invalidate()

                    End If

                End If
            End If


            If State = controlState.Draw Then

                DrawObjectManager.WhenKeyDown(e)

            End If

        End If


    End Sub




    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)


        If Image Is Nothing OrElse Freez = True Then
            Exit Sub
        End If

        MyBase.OnMouseUp(e)

        MouseLocation = ClientToImagePoint(e.Location)

        If State = controlState.Draw Then

            DrawObjectManager.WhenMouseUp(e)

            If drawingObject.type = DrawingType.Rectangle Then
                If Not drawingObject.BoundingBox.IsEmpty Then

                    State = controlState.ObjectSelection

                    Dim Highlightarg = New BoundingBoxArg(drawingObject.BoundingBox)

                    OnBoxHighlighted(Highlightarg)

                End If
            End If


        ElseIf State = controlState.ResizeObject Then

            State = controlState.ObjectSelection


        End If

    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)

        MyBase.OnMouseEnter(e)

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)


        If Image Is Nothing Then
            Exit Sub
        End If




        If State = controlState.Draw Then


            DrawObjectManager.WhenMouseMove(e)

        ElseIf State = controlState.ObjectSelection Then

            Me.OnBoxMouseMove(e)

        ElseIf State = controlState.ResizeObject Then

            Me.OnBoxMouseMove(e)

        ElseIf State = controlState.MoveImage Then

            Me.OnImageMove(e)

        Else

            MyBase.OnMouseMove(e)

        End If

        Invalidate()


        SkipRefresh = False





    End Sub


    Protected Overrides Sub OnMouseDoubleClick(ByVal e As MouseEventArgs)

        If Image Is Nothing Then
            Exit Sub
        End If

        MyBase.OnMouseDoubleClick(e)

    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)

        If Image Is Nothing OrElse Freez = True Then
            Exit Sub
        End If

        MyBase.OnMouseWheel(e)


    End Sub

    ''' <summary>
    ''' Paints recognized paragraphs and their boxs one the original image
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)


        If Image Is Nothing Then
            Exit Sub
        End If

        MyBase.OnPaint(e)

        If (State <> controlState.None AndAlso State <> controlState.Drag) Then
            OnDrawResizePaint(e)
        End If





    End Sub

#End Region







End Class



