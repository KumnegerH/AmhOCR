
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class ImageEditControl
    Inherits ImageViewControl

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3



#Region "Members"


    Public Event BoxHighlightedEvent As EventHandler(Of BoundingBoxArg)

    Public Event SignalBusy As EventHandler

    Private BoxSelectionStPoint As Point
    Private MousePostion As Point

    Private SkipRefresh As Boolean = False



    ' Private RedoList As New List(Of EditMetadata)
    ' Private UndoList As New List(Of EditMetadata)


    Private UndoType As New List(Of Integer)
    Private RedoType As New List(Of Integer)



#End Region

#Region "Intitialize and End"


    Public Sub New()
        MyBase.New()


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
        BoxRectangle = New Rectangle
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
    ''' Ends user bound area selection and edit
    ''' </summary>
    Public Sub EndRegionEdit()

        If imageTomove IsNot Nothing Then
            imageTomove.Dispose()
            imageTomove = Nothing
        End If

        MoveCurrentPosition = New Point
        MoveInitPosition = New Point

        State = controlState.None

        ResizeRecHighlighted = False
        ResizeRecType = -1

        BoxRectangle = Rectangle.Empty
        PreviouscontrolState = controlState.None
        Cursor = Cursors.Default
        Dim Boxarg As New BoundingBoxArg(BoxRectangle)
        RaiseEvent BoxHighlightedEvent(Nothing, Boxarg)

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



        If Image Is Nothing Then
            Exit Sub
        End If



        If e.Button = MouseButtons.Left Then


            If State = controlState.ObjectSelection AndAlso
                           ResizeRecHighlighted = True Then


                State = controlState.ResizeObject


            ElseIf State = controlState.ObjectSelection Then

                If ResizeRecHighlighted = False Then

                    ' reset region edit if the previous map state is DrawRect
                    EndRegionEdit()


                End If

            ElseIf State = controlState.DrawRectStart Then

                Dim pnt = ClientToImagePoint(e.Location)
                PreviouscontrolState = controlState.None
                State = controlState.DrawRect
                BoxSelectionStPoint = pnt
                MousePostion = pnt

                BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)

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

            ElseIf State = controlState.DrawRectStart Then

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
                        State = controlState.DrawRectStart
                        Cursor = Cursors.Cross
                    End If

                End If
            End If


        End If




    End Sub




    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)


        If Image Is Nothing Then
            Exit Sub
        End If



        MyBase.OnMouseUp(e)

        If State = controlState.DrawRect Then

            ResizeRecType = -1
            ResizeRecHighlighted = False
            State = controlState.None
            Cursor = Cursors.Arrow
            PreviouscontrolState = controlState.None

            Try

                Dim pnt = ClientToImagePoint(e.Location)
                BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, pnt)

                Dim Imagebound = New Rectangle(New Point(1, 1), New Size(Image.Width - 2, Image.Height - 2))

                BoxRectangle = Rectangle.Intersect(BoxRectangle, Imagebound)

                If BoxRectangle.IsEmpty = False Then

                    State = controlState.ObjectSelection
                    Dim Highlightarg = New BoundingBoxArg(BoxRectangle)
                    RaiseEvent BoxHighlightedEvent(Nothing, Highlightarg)
                    Invalidate()

                End If

            Catch ex As Exception

                BoxRectangle = Rectangle.Empty

            End Try

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



        If State = controlState.DrawRect Then

            MyBase.OnMouseMove(e)

            MousePostion = ClientToImagePoint(e.Location)

            BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)



        ElseIf state = controlState.ObjectSelection Then

            Me.OnBoxMouseMove(e)

        ElseIf state = controlState.ResizeObject Then

            Me.OnBoxMouseMove(e)

        ElseIf state = controlState.MoveImage Then

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

        If Image Is Nothing Then
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


        If (State = controlState.DrawRect) OrElse
              (State = controlState.ObjectSelection) OrElse
                (State = controlState.ResizeObject) Then

            If (BoxRectangle.Width * BoxRectangle.Height) <> 0 Then


                Dim penRec As Pen

                If State = controlState.DrawRect Then

                    penRec = New Pen(Color.DimGray, 1 / _zoom)
                    penRec.DashStyle = DashStyle.Dash
                Else

                    If ResizeRecHighlighted Then
                        penRec = New Pen(Color.Red, 2 / _zoom)
                        penRec.DashStyle = DashStyle.Solid
                    Else
                        penRec = New Pen(Color.LimeGreen, 2 / _zoom)
                        penRec.DashStyle = DashStyle.Dash
                    End If


                End If


                e.Graphics.DrawRectangle(penRec, BoxRectangle)

                penRec.Dispose()

            End If

        ElseIf State = controlState.MoveStart OrElse
                 State = controlState.MoveImage Then

            If (BoxRectangle.Width * BoxRectangle.Height) <> 0 Then

                Dim penRec As Pen
                penRec = New Pen(Color.LimeGreen, 2 / _zoom)
                penRec.DashStyle = DashStyle.Dash

                e.Graphics.DrawRectangle(penRec, BoxRectangle)

                penRec.Dispose()

            End If

        End If









    End Sub

#End Region







End Class



