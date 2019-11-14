


Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class ImageViewControl
    Inherits UserControl

    ' This Is inspired by Pavel Torgashov, p_torgashov@ukr.net 2015 GPL3
    ' This version differs: 
    '     - the original version was written in c#
    '     - simplified paint method using graphic transform and  
    '     - while zooming; zoom center is the current mouse position rather than image center postion  
    '     - added additional events, members and functions to fit this project
    Friend _image As Image
    Friend ImageCenter As PointF
    Friend _zoom As Single = 1.0F
    Friend _controlState As controlState
    Friend InitPanPosition As PointF
    Friend InitPanCenter As PointF
    Friend imgWidth As Integer
    Friend imgHeight As Integer
    Friend _ZoomSpeed As Single = 0.2F
    Public Event ImageCenterChanged As EventHandler
    Private lblCoordinate As ToolStripStatusLabel
    Friend PreviouscontrolState As controlState = controlState.None
    Public FileName As String = ""


    Private _highlightedbox As Rectangle

    ''' <summary>
    ''' Get rectangular box from external user and draw each time in the image during control's paint event
    ''' </summary>
    ''' <returns></returns>
    Public Property HighlightedBox As Rectangle
        Set(value As Rectangle)
            _highlightedbox = value
        End Set
        Get
            Return _highlightedbox
        End Get
    End Property



    ''' <summary>
    ''' Get or set the current user interaction state of the control
    ''' </summary>
    ''' <returns></returns>
    Public Property State As controlState
        Set(value As controlState)
            _controlState = value
        End Set
        Get
            Return _controlState
        End Get
    End Property



    ''' <summary>
    '''  Controls zoom speed/log scale/ 
    ''' </summary>
    ''' <returns></returns>
    Public Property ZoomSpeed As Single

        Set(value As Single)

            _ZoomSpeed = value

        End Set

        Get

            Return _ZoomSpeed

        End Get

    End Property



    Public Sub New()

        _highlightedbox = New Rectangle
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)


        _ZoomSpeed = 0.2F

    End Sub

    Public Overloads Sub DisposeImage()

        If _image IsNot Nothing Then
            _image.Dispose()
            _image = Nothing
            _highlightedbox = New Rectangle
            _controlState = controlState.None
            _zoom = 1

            Invalidate()
        End If

    End Sub



    ''' <summary>
    ''' Display mouse position 
    ''' </summary>
    ''' <returns></returns>
    Public Property Label As ToolStripStatusLabel
        Set(value As ToolStripStatusLabel)
            lblCoordinate = value
        End Set
        Get
            Return lblCoordinate
        End Get
    End Property





    ''' <summary>
    '''Image to display
    ''' </summary>
    ''' <returns></returns>
    Public Property Image As Image
        Set(value As Image)


            _controlState = controlState.None
            imgWidth = 0
            imgHeight = 0
            ImageCenter = New PointF(0, 0)
            Cursor = Cursors.Default
            _zoom = 1
            _highlightedbox = New Rectangle

            If value Is Nothing Then

                If _image IsNot Nothing Then
                    _image.Dispose()
                    _image = Nothing
                    Invalidate()
                    Exit Property
                End If


            Else

                _image = value
                imgWidth = _image.Width
                imgHeight = _image.Height

            End If




            ZoomReset()

        End Set

        Get

            Return _image
        End Get

    End Property

    Public Sub UpdateImage(ByVal newImage As Image)

        If _image IsNot Nothing Then
            If _image.Size = newImage.Size Then
                _image = newImage
            End If

        End If

    End Sub

    ''' <summary>
    ''' Reset image to fit control's client size
    ''' </summary>
    Public Sub ZoomReset()

        If (_image IsNot Nothing) Then

            ImageCenter = New PointF(imgWidth / 2.0F, imgHeight / 2.0F)
            _zoom = ClientSize.Width / imgWidth
            If (_zoom * imgHeight) > ClientSize.Height Then

                _zoom = ClientSize.Height / imgHeight

            End If

            Invalidate()

        End If




    End Sub


    ''' <summary>
    ''' Zoom to Rectangular area
    ''' </summary>
    Public Overloads Sub ZoomToBound(ByVal bound As Rectangle)

        If (_image IsNot Nothing) Then

            ImageCenter = New PointF(bound.X + (bound.Width / 2.0), bound.Y + (bound.Height / 2.0))

            If ((bound.Width * _zoom) >= ClientSize.Width) AndAlso ((bound.Height * _zoom) >= ClientSize.Height) Then
                If (bound.Width * _zoom) >= (bound.Height * _zoom) Then
                    _zoom = ClientSize.Width / (bound.Width)
                Else
                    _zoom = ClientSize.Height / (bound.Height)
                End If

            ElseIf ((bound.Width * _zoom) >= ClientSize.Width) Then
                _zoom = ClientSize.Width / (bound.Width)

            ElseIf ((bound.Height * _zoom) >= ClientSize.Height) Then
                _zoom = ClientSize.Height / (bound.Height)
            Else
                If (bound.Width) >= (bound.Height) Then
                    _zoom = ClientSize.Width / (bound.Width)
                Else
                    _zoom = ClientSize.Height / (bound.Height)
                End If
            End If

            Invalidate()

        End If




    End Sub


    Public Overloads Sub ZoomToBound(ByVal bound As Rectangle, ByVal YPosition As Integer)

        If (_image IsNot Nothing) Then

            ImageCenter = New PointF(bound.X + (bound.Width / 2.0), bound.Y + (bound.Height / 2.0))

            If ((bound.Width * _zoom) >= ClientSize.Width) AndAlso ((bound.Height * _zoom) >= ClientSize.Height) Then
                If (bound.Width * _zoom) >= (bound.Height * _zoom) Then
                    _zoom = ClientSize.Width / (bound.Width * 1.05)
                Else
                    _zoom = ClientSize.Height / (bound.Height * 1.05)
                End If

            ElseIf ((bound.Width * _zoom) >= ClientSize.Width) Then
                _zoom = ClientSize.Width / (bound.Width * 1.05)

            ElseIf ((bound.Height * _zoom) >= ClientSize.Height) Then
                _zoom = ClientSize.Height / (bound.Height * 1.05)
            End If

            Invalidate()

        End If




    End Sub


    ''' <summary>
    ''' Current Zoom Level
    ''' </summary>
    ''' <returns></returns>
    Public Property Zoom As Single
        Set(value As Single)
            If (Math.Abs(value) <= Single.Epsilon) Then
                Throw New Exception("Zoom must be more then 0")

            End If
            _zoom = value
            Invalidate()
        End Set
        Get
            Return _zoom
        End Get
    End Property


    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)


        If _image IsNot Nothing Then

            If (e.Delta > 0) Then

                If (_controlState <> controlState.Drag) Then
                    If ((imgWidth * _zoom) < (Me.Width * 10)) OrElse ((imgHeight * _zoom) < (Me.Height * 10)) Then
                        Dim poin = ClientToImagePoint(e.Location)

                        InitPanPosition = New Point(poin.X, poin.Y)


                        _zoom = CSng(Math.Exp(Math.Log(_zoom) + _ZoomSpeed))

                        InitPanCenter = ImageCenter
                        InitPanPosition = ImagePointToClient(InitPanPosition)

                        Dim deltax = e.X - InitPanPosition.X
                        Dim deltay = e.Y - InitPanPosition.Y
                        ImageCenter = New PointF(InitPanCenter.X - deltax / _zoom, InitPanCenter.Y - deltay / _zoom)

                        Invalidate()
                    End If

                End If

            ElseIf (e.Delta < 0) Then


                If (_controlState <> controlState.Drag) Then
                    If ((imgWidth * _zoom) > (Me.Width / 4)) OrElse ((imgHeight * _zoom) > (Me.Height / 4)) Then
                        Dim poin = ClientToImagePoint(e.Location)

                        InitPanPosition = New Point(poin.X, poin.Y)

                        _zoom = Math.Exp(Math.Log(_zoom) - _ZoomSpeed)
                        InitPanCenter = ImageCenter
                        InitPanPosition = ImagePointToClient(InitPanPosition)

                        Dim deltax = e.X - InitPanPosition.X
                        Dim deltay = e.Y - InitPanPosition.Y
                        ImageCenter = New PointF(InitPanCenter.X - deltax / _zoom, InitPanCenter.Y - deltay / _zoom)

                        Invalidate()



                    End If
                End If
            End If


        End If



    End Sub






    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)

        If (_controlState = controlState.None) Then

            If (e.Button = MouseButtons.Left) Then
                PreviouscontrolState = controlState.None
                _controlState = controlState.Drag

                InitPanPosition = e.Location
                InitPanCenter = ImageCenter

            End If


        End If










    End Sub





    Private Sub ResetState()

        Dim MousPo = Control.MousePosition
        MousPo = Me.PointToClient(MousPo)

        Cursor = Cursors.Default




    End Sub


    Public Sub CancelState()

        _controlState = controlState.None
        Cursor = Cursors.Default
        Invalidate()

    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)

        If Me.Focused = False Then
            Me.Focus()
        End If

    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)

        If _controlState = controlState.Drag Then

            _controlState = PreviouscontrolState
            _controlState = controlState.None
            Cursor = Cursors.Default

            Invalidate()

        ElseIf _controlState = controlState.None Then

            Cursor = Cursors.Default
            Invalidate()

        End If


    End Sub




    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)


        If (_controlState = controlState.Drag) Then
            If Cursor <> Cursors.SizeAll Then
                Cursor = Cursors.SizeAll
            End If

            Dim delta = New PointF(InitPanPosition.X - e.X, InitPanPosition.Y - e.Y)

            ImageCenter.X = InitPanCenter.X + (delta.X / _zoom)
            ImageCenter.Y = InitPanCenter.Y + (delta.Y / _zoom)

            Invalidate()

        End If


        If lblCoordinate IsNot Nothing Then
            If _image IsNot Nothing Then
                Dim Location = ClientToImagePoint(e.Location)

                lblCoordinate.Text = Math.Round(Location.X, 0).ToString + "," + Math.Round(Location.Y, 0).ToString
                lblCoordinate.Invalidate()

            Else
                lblCoordinate.Text = e.X.ToString + "," + e.Y.ToString
                lblCoordinate.Invalidate()
            End If

        End If



    End Sub





    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        If (_image IsNot Nothing) Then

            Try

                e.Graphics.InterpolationMode = InterpolationMode.High

                Dim delatx = (ClientSize.Width / 2.0F) - (ImageCenter.X * _zoom)
                Dim deltay = (ClientSize.Height / 2.0F) - (ImageCenter.Y * _zoom)


                Dim MatrTrns As New Matrix()
                MatrTrns.Translate(delatx, deltay)
                MatrTrns.Scale(_zoom, _zoom)


                e.Graphics.Transform = MatrTrns



                e.Graphics.DrawImage(Image, 0, 0, Image.Width, Image.Height)


                If HighlightedBox.IsEmpty = False Then

                    'Highlight the bounding box of selected object in the Editpicbox
                    Using penHigh = New Pen(Color.LimeGreen, 2 / _zoom)

                        e.Graphics.DrawRectangle(penHigh, HighlightedBox)

                    End Using

                End If

            Catch ex As Exception

            End Try






        End If


    End Sub



    Public Overloads Function ClientToImagePoint(ByVal point As PointF) As PointF

        Dim deltax = (point.X - ClientSize.Width / 2.0F) / _zoom + ImageCenter.X
        Dim deltay = (point.Y - ClientSize.Height / 2.0F) / _zoom + ImageCenter.Y
        Return New PointF(CSng(deltax), CSng(deltay))

    End Function


    Public Overloads Function ClientToImagePoint(ByVal point As Point) As Point

        Dim deltax = (point.X - ClientSize.Width / 2.0F) / _zoom + ImageCenter.X
        Dim deltay = (point.Y - ClientSize.Height / 2.0F) / _zoom + ImageCenter.Y
        Return New Point(CInt(deltax), CInt(deltay))

    End Function

    Public Overloads Function ImagePointToClient(ByVal point As PointF) As Point

        Dim deltax = (point.X - ImageCenter.X) * _zoom + ClientSize.Width / 2.0F
        Dim deltay = (point.Y - ImageCenter.Y) * _zoom + ClientSize.Height / 2.0F
        Return New Point(CInt(deltax), CInt(deltay))


    End Function

    Public Overloads Function ImagePointToClient(ByVal point As Point) As Point

        Dim deltax = (point.X - ImageCenter.X) * _zoom + ClientSize.Width / 2.0F
        Dim deltay = (point.Y - ImageCenter.Y) * _zoom + ClientSize.Height / 2.0F
        Return New Point(CInt(deltax), CInt(deltay))


    End Function


    Public Overloads Function ClientToImageBox(ByVal Rect As Rectangle) As Rectangle

        Dim deltax = -ImageCenter.X * _zoom + ClientSize.Width / 2.0F
        Dim deltay = -ImageCenter.Y * _zoom + ClientSize.Height / 2.0F


        Dim MatrTrns As New Matrix()
        MatrTrns.Translate(deltax, deltay)
        Rect.X -= deltax
        Rect.Y -= deltay
        Rect.Width /= _zoom
        Rect.Height /= _zoom
        Return Rect

    End Function
    Public Overloads Function ClientToImageBox(ByVal Rect As RectangleF) As RectangleF

        Dim deltax = -ImageCenter.X * _zoom + ClientSize.Width / 2.0F
        Dim deltay = -ImageCenter.Y * _zoom + ClientSize.Height / 2.0F


        Dim MatrTrns As New Matrix()
        MatrTrns.Translate(deltax, deltay)
        Rect.X -= deltax
        Rect.Y -= deltay
        Rect.Width /= _zoom
        Rect.Height /= _zoom
        Return Rect

    End Function


    Public Overloads Function ImageToClientBox(ByVal Rect As Rectangle) As Rectangle

        Dim deltax = -ImageCenter.X * _zoom + ClientSize.Width / 2.0F
        Dim deltay = -ImageCenter.Y * _zoom + ClientSize.Height / 2.0F


        Dim MatrTrns As New Matrix()
        MatrTrns.Translate(deltax, deltay)
        Rect.X += deltax
        Rect.Y += deltay
        Rect.Width *= _zoom
        Rect.Height *= _zoom

        Return Rect

    End Function

    Public Overloads Function ImageToClientBox(ByVal Rect As RectangleF) As RectangleF

        Dim deltax = -ImageCenter.X * _zoom + ClientSize.Width / 2.0F
        Dim deltay = -ImageCenter.Y * _zoom + ClientSize.Height / 2.0F

        Dim MatrTrns As New Matrix()
        MatrTrns.Translate(deltax, deltay)
        Rect.X += deltax
        Rect.Y += deltay
        Rect.Width *= _zoom
        Rect.Height *= _zoom
        Return Rect

    End Function





    Friend Sub CenterImage(ByVal e As Point)

        InitPanCenter = ImageCenter
        InitPanPosition = ImagePointToClient(e)

        Dim deltax = (Me.ClientSize.Width / 2) - InitPanPosition.X
        Dim deltay = (Me.ClientSize.Height / 2) - InitPanPosition.Y
        ImageCenter = New PointF(InitPanCenter.X - deltax / _zoom, InitPanCenter.Y - deltay / _zoom)

    End Sub



    Public ReadOnly Property GetScreenshot() As Image
        Get
            Dim img = New Bitmap(ClientSize.Width, ClientSize.Height)

            Using gr = Graphics.FromImage(img)
                OnPaint(New PaintEventArgs(gr, ClientRectangle))
            End Using

            Return img
        End Get

    End Property


End Class
