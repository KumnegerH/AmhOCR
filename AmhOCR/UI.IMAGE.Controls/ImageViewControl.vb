


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
    Friend _mainimage As Image
    Friend ImageCenter As PointF
    Friend _zoom As Single = 1.0F
    Friend _controlState As controlState
    Friend InitPanPosition As PointF
    Friend InitPanCenter As PointF

    Friend MoveInitPosition As Point
    Friend MoveCurrentPosition As Point

    Friend imgWidth As Integer
    Friend imgHeight As Integer
    Friend _ZoomSpeed As Single = 0.2F

    Friend imageTomove As Image

    Public Event DeskewImageEvent As EventHandler
    Public Event InvertImageEvent As EventHandler
    Public Event ClearAreaEvent As EventHandler

    Public Event CropAreaEvent As EventHandler

    Public Event ResetAreaEvent As EventHandler

    Public Event ImageAreaEvent As EventHandler
    Public Event TabelAreaEvent As EventHandler

    Public Event StartImageMoveEvent As EventHandler

    Public Event ImageShiftedEvent As EventHandler

    Public Event RecognizeAs As EventHandler(Of RecognizeAreaArg)

    Public Event ImageCenterChanged As EventHandler

    Friend PreviouscontrolState As controlState = controlState.None
    Public FileName As String = ""

    Friend ResizeRecHighlighted As Boolean = False
    Friend ResizeRecType As Integer = -1

    Friend HocrActive As Boolean = False

    Friend BoxRectangle As Rectangle

    Private _highlightedbox As Rectangle
    Private lblCoordinate As ToolStripStatusLabel

    Private BoxEditContext As ContextMenuStrip

    Friend _ImageAreas As List(Of Rectangle)


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
    ''' Get and set image areas preserved by user
    ''' </summary>
    ''' <returns></returns>
    Public Property ImageAreas As List(Of Rectangle)
        Set(value As List(Of Rectangle))
            _ImageAreas = value
        End Set
        Get
            Return _ImageAreas
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

        Cursor = Cursors.Arrow
        _highlightedbox = New Rectangle
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)


        _ZoomSpeed = 0.2F

        _ImageAreas = New List(Of Rectangle)

        BoxEditContext = New ContextMenuStrip
        Dim btnrecogClip As New ToolStripMenuItem
        btnrecogClip.Text = "Recognize Block                                "
        btnrecogClip.ShortcutKeys = Keys.F6
        BoxEditContext.Items.Add(btnrecogClip)

        Dim btnrecogObj As New ToolStripMenuItem
        btnrecogObj.Text = "Recognize As"
        Dim recObjline As ToolStripMenuItem = btnrecogObj.DropDownItems.Add("Recognize as Text Line")
        Dim recObjword As ToolStripMenuItem = btnrecogObj.DropDownItems.Add("Recognize as Text Word")
        Dim recObjchar As ToolStripMenuItem = btnrecogObj.DropDownItems.Add("Recognize as Text Character")
        BoxEditContext.Items.Add(btnrecogObj)

        Dim sepa1 As New ToolStripSeparator
        BoxEditContext.Items.Add(sepa1)

        Dim btndeskewimage As New ToolStripMenuItem
        btndeskewimage.Text = "Deskew image"
        BoxEditContext.Items.Add(btndeskewimage)

        Dim btncropimage As New ToolStripMenuItem
        btncropimage.Text = "Crop Image Area"
        BoxEditContext.Items.Add(btncropimage)

        If Me.GetType.Name = "HocrEditControl" Then
            btncropimage.Enabled = False
        End If

        Dim btninvimage As New ToolStripMenuItem
        btninvimage.Text = "Invert Image Color"
        BoxEditContext.Items.Add(btninvimage)

        Dim sepa2 As New ToolStripSeparator
        BoxEditContext.Items.Add(sepa2)


        Dim btnImageMove As New ToolStripMenuItem
        btnImageMove.Text = "Move Image"
        BoxEditContext.Items.Add(btnImageMove)

        Dim btnClearImage As New ToolStripMenuItem
        btnClearImage.Text = "Clear Area"
        BoxEditContext.Items.Add(btnClearImage)

        Dim btnImageArea As New ToolStripMenuItem
        btnImageArea.Text = "Set As Background Image Area"
        BoxEditContext.Items.Add(btnImageArea)

        Dim btnTabelArea As New ToolStripMenuItem
        btnTabelArea.Text = "Set As Tabel Area"
        BoxEditContext.Items.Add(btnTabelArea)



        Dim sepa3 As New ToolStripSeparator
        BoxEditContext.Items.Add(sepa3)


        Dim btnareatype As New ToolStripMenuItem
        btnareatype.Text = "Properties"
        btnareatype.Enabled = False
        BoxEditContext.Items.Add(btnareatype)


        AddHandler btnrecogClip.Click, AddressOf RecognizeObject
        AddHandler recObjline.Click, AddressOf RecognizeObject
        AddHandler recObjword.Click, AddressOf RecognizeObject
        AddHandler recObjchar.Click, AddressOf RecognizeObject

        AddHandler btndeskewimage.Click, AddressOf DeskewImageArea
        AddHandler btninvimage.Click, AddressOf InvertAreaColor
        AddHandler btnClearImage.Click, AddressOf ClearArea
        AddHandler btncropimage.Click, AddressOf CropArea


        AddHandler btnImageMove.Click, AddressOf StartImageMove

        AddHandler btnImageArea.Click, AddressOf SetAsImageArea
        AddHandler btnTabelArea.Click, AddressOf SetAsTabelArea

    End Sub

    Private Sub RecognizeObject(ByVal sender As Object, ByVal e As EventArgs)
        Dim SegMod As New PageSegMode

        If CType(sender, ToolStripMenuItem).Text.Contains("Recognize Block") Then
            SegMod = PageSegMode.uniformblock

        ElseIf CType(sender, ToolStripMenuItem).Text.Contains("Recognize as Text Line") Then
            SegMod = PageSegMode.singleline
        ElseIf CType(sender, ToolStripMenuItem).Text.Contains("Recognize as Text Word") Then
            SegMod = PageSegMode.singleword
        ElseIf CType(sender, ToolStripMenuItem).Text.Contains("Recognize as Text Character") Then
            SegMod = PageSegMode.character
        End If

        Dim RecoArg As New RecognizeAreaArg(BoxRectangle, FileName, SegMod)
        RaiseEvent RecognizeAs(Me, RecoArg)


    End Sub

    Private Sub DeskewImageArea(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent DeskewImageEvent(Me, Nothing)

    End Sub

    Private Sub InvertAreaColor(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent InvertImageEvent(Me, Nothing)

    End Sub

    Private Sub ClearArea(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent ClearAreaEvent(Me, Nothing)

    End Sub

    Private Sub CropArea(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent CropAreaEvent(Me, Nothing)

    End Sub

    Private Sub StartImageMove(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent StartImageMoveEvent(Me, Nothing)

    End Sub
    Private Sub ResetArea(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent ResetAreaEvent(Me, Nothing)

    End Sub


    Private Sub SetAsImageArea(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent ImageAreaEvent(Me, Nothing)

    End Sub


    Private Sub SetAsTabelArea(ByVal sender As Object, ByVal e As EventArgs)

        RaiseEvent TabelAreaEvent(Me, Nothing)

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
    '''Original Image to display
    ''' </summary>
    ''' <returns></returns>
    Public Property MainImage As Image
        Set(value As Image)

            If value Is Nothing Then

                If _mainimage IsNot Nothing Then
                    _mainimage.Dispose()
                    _mainimage = Nothing

                    Exit Property
                End If


            Else

                _mainimage = value

            End If

            Invalidate()

        End Set

        Get

            Return _mainimage
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
                _ImageAreas = New List(Of Rectangle)

                BoxRectangle = Rectangle.Empty
                BoxRectangle = New Rectangle

                If _image IsNot Nothing Then

                    _image.Dispose()
                    _image = Nothing
                    Invalidate()
                End If

                Exit Property

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

            _zoom = ClientSize.Width / bound.Width

            If (_zoom * bound.Height) > ClientSize.Height Then

                _zoom = ClientSize.Height / bound.Height

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



    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)

        If State = controlState.None Then

            If Cursor <> Cursors.Default Then

                Cursor = Cursors.Default

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


    Friend Sub OnBoxRightClick(ByVal e As MouseEventArgs)


        BoxEditContext.Show(Me.PointToScreen(e.Location))

    End Sub


    Private Sub ResetState()

        Dim MousPo = Control.MousePosition
        MousPo = Me.PointToClient(MousPo)

        Cursor = Cursors.Default




    End Sub


    Public Sub CancelState()

        BoxRectangle = New Rectangle
        ResizeRecHighlighted = False
        ResizeRecType = -1
        PreviouscontrolState = controlState.None
        _controlState = controlState.None
        Cursor = Cursors.Default
        Invalidate()

    End Sub


    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)

        If _controlState = controlState.Drag Then


            _controlState = controlState.None
            PreviouscontrolState = controlState.None

            Cursor = Cursors.Default
            Invalidate()

        ElseIf _controlState = controlState.None Then

            Cursor = Cursors.Default
            Invalidate()

        ElseIf State = controlState.MoveImage Then

            State = controlState.None
            RaiseEvent ImageShiftedEvent(Me, Nothing)


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

    Friend Sub OnImageMove(ByVal e As MouseEventArgs)


        Dim MousePostion = ClientToImagePoint(e.Location)
        MoveInitPosition.X += MousePostion.X - MoveCurrentPosition.X
        MoveInitPosition.Y += MousePostion.Y - MoveCurrentPosition.Y

        MoveCurrentPosition = MousePostion

    End Sub

    Friend Sub OnBoxMouseMove(ByVal e As MouseEventArgs)


        Dim MousePostion = ClientToImagePoint(e.Location)


        If MouseButtons = MouseButtons.Left AndAlso ResizeRecHighlighted = True Then

            ResizeRectangle(MousePostion)

        Else
            Dim oldResizeRecHighlighted = ResizeRecHighlighted
            Dim oldResizeRecType = ResizeRecType
            ResizeRecType = CheckBoxResize(e.Location, BoxRectangle)

            If ResizeRecType > -1 Then

                If oldResizeRecType <> ResizeRecType Then

                    If ResizeRecType < 2 Then

                        Me.Cursor = Cursors.SizeWE

                    ElseIf ResizeRecType < 4 Then

                        Me.Cursor = Cursors.SizeNS

                    ElseIf ResizeRecType = 4 OrElse ResizeRecType = 7 Then

                        Me.Cursor = Cursors.SizeNWSE

                    ElseIf ResizeRecType = 5 OrElse ResizeRecType = 6 Then

                        Me.Cursor = Cursors.SizeNESW

                    End If

                End If



            ElseIf oldResizeRecHighlighted OrElse ResizeRecHighlighted Then

                If oldResizeRecType > -1 Then

                    Me.Cursor = Cursors.Default

                End If



            End If
        End If




    End Sub
    ''' <summary>
    ''' Resize user rectangle sides  
    ''' </summary>
    ''' <param name="loc">mouse position on image</param>
    Private Sub ResizeRectangle(ByVal loc As Point)



        If ResizeRecType = 0 Then
            ' left side

            If BoxRectangle.Right > loc.X Then

                BoxRectangle.Width -= (loc.X - BoxRectangle.X)
                BoxRectangle.X = loc.X

            Else

                BoxRectangle.X = BoxRectangle.Right
                BoxRectangle.Width = 0

            End If


        ElseIf ResizeRecType = 1 Then
            ' right side

            If BoxRectangle.X < loc.X Then

                BoxRectangle.Width += (loc.X - BoxRectangle.Right)

            Else

                BoxRectangle.Width = 0

            End If


        ElseIf ResizeRecType = 2 Then
            ' top side

            If BoxRectangle.Bottom > loc.Y Then

                BoxRectangle.Height -= (loc.Y - BoxRectangle.Y)
                BoxRectangle.Y = loc.Y

            Else

                BoxRectangle.Y = BoxRectangle.Bottom
                BoxRectangle.Height = 0

            End If



        ElseIf ResizeRecType = 3 Then
            ' bootom side
            If BoxRectangle.Top < loc.Y Then

                BoxRectangle.Height += (loc.Y - BoxRectangle.Bottom)

            Else

                BoxRectangle.Height = 0

            End If

        ElseIf ResizeRecType = 4 Then
            'left Top
            If BoxRectangle.Right > loc.X Then

                BoxRectangle.Width -= (loc.X - BoxRectangle.X)
                BoxRectangle.X = loc.X

            Else

                BoxRectangle.X = BoxRectangle.Right
                BoxRectangle.Width = 0

            End If

            If BoxRectangle.Bottom > loc.Y Then

                BoxRectangle.Height -= (loc.Y - BoxRectangle.Y)
                BoxRectangle.Y = loc.Y

            Else

                BoxRectangle.Y = BoxRectangle.Bottom
                BoxRectangle.Height = 0

            End If

        ElseIf ResizeRecType = 5 Then
            'left bottom

            If BoxRectangle.Right > loc.X Then

                BoxRectangle.Width -= (loc.X - BoxRectangle.X)
                BoxRectangle.X = loc.X

            Else

                BoxRectangle.X = BoxRectangle.Right
                BoxRectangle.Width = 0

            End If

            If BoxRectangle.Top < loc.Y Then

                BoxRectangle.Height += (loc.Y - BoxRectangle.Bottom)

            Else

                BoxRectangle.Height = 0

            End If

        ElseIf ResizeRecType = 6 Then
            ' right top

            If BoxRectangle.X < loc.X Then

                BoxRectangle.Width += (loc.X - BoxRectangle.Right)

            Else

                BoxRectangle.Width = 0

            End If

            If BoxRectangle.Bottom > loc.Y Then

                BoxRectangle.Height -= (loc.Y - BoxRectangle.Y)
                BoxRectangle.Y = loc.Y

            Else

                BoxRectangle.Y = BoxRectangle.Bottom
                BoxRectangle.Height = 0

            End If

        ElseIf ResizeRecType = 7 Then

            ' right bottom
            If BoxRectangle.X < loc.X Then

                BoxRectangle.Width += (loc.X - BoxRectangle.Right)

            Else

                BoxRectangle.Width = 0

            End If

            If BoxRectangle.Top < loc.Y Then

                BoxRectangle.Height += (loc.Y - BoxRectangle.Bottom)

            Else

                BoxRectangle.Height = 0

            End If

        End If

    End Sub


    Public Function CheckBoxResize(ByVal loc As Point, ByVal bbox As Rectangle) As Integer

        Dim ClientBBox = ImageToClientBox(bbox)
        ClientBBox.Width += 10
        ClientBBox.Height += 10
        ClientBBox.X -= 5
        ClientBBox.Y -= 5
        ResizeRecHighlighted = False

        Dim side As Integer = -1

        If ClientBBox.Contains(loc) Then

            ResizeRecHighlighted = True
            'get the nearest box side to the mouse position +-5 pixle 

            Dim leftDX As Integer = loc.X - ClientBBox.X
            Dim rightDX As Integer = ClientBBox.Right - loc.X
            Dim topDX As Integer = loc.Y - ClientBBox.Top
            Dim bottomDX As Integer = ClientBBox.Bottom - loc.Y

            If (leftDX <= rightDX AndAlso leftDX <= topDX AndAlso leftDX <= bottomDX) Then
                If leftDX < 11 Then

                    side = 0

                    If topDX <= bottomDX Then
                        If topDX < 11 Then
                            side = 4
                        End If
                    Else
                        If bottomDX < 11 Then
                            side = 5
                        End If
                    End If

                End If

            ElseIf (rightDX <= leftDX AndAlso rightDX <= topDX AndAlso rightDX <= bottomDX) Then

                If rightDX < 11 Then


                    side = 1

                    If topDX <= bottomDX Then
                        If topDX < 11 Then
                            side = 6
                        End If
                    Else
                        If bottomDX < 11 Then
                            side = 7
                        End If
                    End If

                End If

            ElseIf (topDX <= leftDX AndAlso topDX <= rightDX AndAlso topDX <= bottomDX) Then

                If topDX < 11 Then

                    side = 2

                    If leftDX <= rightDX Then
                        If leftDX < 11 Then
                            side = 4
                        End If
                    Else
                        If rightDX < 11 Then
                            side = 6
                        End If
                    End If


                End If

            ElseIf (bottomDX <= leftDX AndAlso bottomDX <= rightDX AndAlso bottomDX <= topDX) Then

                If bottomDX < 11 Then

                    side = 3

                    If leftDX <= rightDX Then
                        If leftDX < 11 Then
                            side = 5
                        End If
                    Else
                        If rightDX < 11 Then
                            side = 7
                        End If
                    End If

                End If

            End If


        End If


        Return side
    End Function


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        If (_image IsNot Nothing) Then


            e.Graphics.InterpolationMode = InterpolationMode.High




            Try

                If Me.GetType.Name = "ImageEditControl" Then
                    If HocrActive Then
                        If OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage Then
                            OnEditModePaint(e)
                        Else
                            OnOriginalPaint(e)
                        End If

                        Exit Sub

                    End If


                End If


                If OCRsettings.OCRbackgroundView = BackgroundMode.EditedImage Then

                    OnEditModePaint(e)

                ElseIf OCRsettings.OCRbackgroundView = BackgroundMode.OriginalImage Then

                    OnOriginalPaint(e)
                Else

                    OnUserAreaPaint(e)

                End If



            Catch ex As Exception

            End Try


        End If


    End Sub



    Private Sub OnEditModePaint(ByVal e As PaintEventArgs)



        Dim delatx = (ClientSize.Width / 2.0F) - (ImageCenter.X * _zoom)
        Dim deltay = (ClientSize.Height / 2.0F) - (ImageCenter.Y * _zoom)



        Dim MatrTrns As New Matrix()
        MatrTrns.Translate(delatx, deltay)
        MatrTrns.Scale(_zoom, _zoom)


        e.Graphics.Transform = MatrTrns



        e.Graphics.DrawImage(_image, 0, 0, _image.Width, _image.Height)


        If _ImageAreas IsNot Nothing Then


            If HocrActive = False Then

                Dim PaintDash As New Pen(Color.Orange)
                PaintDash.DashStyle = DashStyle.Dash

                Dim FillPaint As New Pen(Color.Orange)

                FillPaint.Color = Color.FromArgb(60, Color.Orange)


                For Each area In _ImageAreas

                    e.Graphics.DrawRectangle(PaintDash, area)
                    e.Graphics.FillRectangle(FillPaint.Brush, area)

                Next

                PaintDash.Dispose()
                PaintDash = Nothing

                FillPaint.Dispose()
                FillPaint = Nothing

            End If


        End If

        Try

            If State = controlState.MoveImage Then

                Using SemiWhite = New Pen(Color.FromArgb(125, Color.White))

                    e.Graphics.FillRectangle(SemiWhite.Brush, BoxRectangle)

                End Using

                e.Graphics.DrawImage(imageTomove, MoveInitPosition)

                Dim BoxImage = New Rectangle(MoveInitPosition, BoxRectangle.Size)
                e.Graphics.DrawRectangle(Pens.Black, BoxImage)

            End If

        Catch ex As Exception

        End Try





        If HighlightedBox.IsEmpty = False Then

            Try

                'Highlight the bounding box of selected object in the Editpicbox
                Using penHigh = New Pen(Color.LimeGreen, 2 / _zoom)

                    e.Graphics.DrawRectangle(penHigh, HighlightedBox)

                End Using


            Catch ex As Exception

            End Try


        End If


    End Sub


    Private Sub OnOriginalPaint(ByVal e As PaintEventArgs)

        If _mainimage IsNot Nothing Then
            Dim delatx = (ClientSize.Width / 2.0F) - (ImageCenter.X * _zoom)
            Dim deltay = (ClientSize.Height / 2.0F) - (ImageCenter.Y * _zoom)


            Dim MatrTrns As New Matrix()
            MatrTrns.Translate(delatx, deltay)
            MatrTrns.Scale(_zoom, _zoom)


            e.Graphics.Transform = MatrTrns



            e.Graphics.DrawImage(_mainimage, 0, 0, _mainimage.Width, _mainimage.Height)



            If _ImageAreas IsNot Nothing Then


                If HocrActive = False Then

                    Dim PaintDash As New Pen(Color.Orange)
                    PaintDash.DashStyle = DashStyle.Dash

                    Dim FillPaint As New Pen(Color.Orange)

                    FillPaint.Color = Color.FromArgb(60, Color.Orange)


                    For Each area In _ImageAreas
                        e.Graphics.DrawRectangle(PaintDash, area)
                        e.Graphics.FillRectangle(FillPaint.Brush, area)
                    Next

                    PaintDash.Dispose()
                    PaintDash = Nothing

                    FillPaint.Dispose()
                    FillPaint = Nothing

                End If


            End If


        End If







        If HighlightedBox.IsEmpty = False Then

            Try

                'Highlight the bounding box of selected object in the Editpicbox
                Using penHigh = New Pen(Color.LimeGreen, 2 / _zoom)

                    e.Graphics.DrawRectangle(penHigh, HighlightedBox)

                End Using


            Catch ex As Exception

            End Try


        End If



    End Sub


    Private Sub OnUserAreaPaint(ByVal e As PaintEventArgs)

        Dim delatx = (ClientSize.Width / 2.0F) - (ImageCenter.X * _zoom)
        Dim deltay = (ClientSize.Height / 2.0F) - (ImageCenter.Y * _zoom)


        Dim MatrTrns As New Matrix()
        MatrTrns.Translate(delatx, deltay)
        MatrTrns.Scale(_zoom, _zoom)


        e.Graphics.Transform = MatrTrns

        e.Graphics.FillRectangle(Brushes.White, 0, 0, Image.Width, Image.Height)



        If _ImageAreas IsNot Nothing Then

            Dim PaintDash As New Pen(Color.Black)
            PaintDash.DashStyle = DashStyle.Dash

            If OCRsettings.OCRbackgroundView = BackgroundMode.UserEditedImageArea Then

                If _mainimage IsNot Nothing Then

                    For Each area In _ImageAreas

                        e.Graphics.DrawImage(_image, area, area, GraphicsUnit.Pixel)
                        e.Graphics.DrawRectangle(PaintDash, area)
                    Next

                End If


            Else

                If _image IsNot Nothing Then

                    For Each area In _ImageAreas

                        e.Graphics.DrawImage(_mainimage, area, area, GraphicsUnit.Pixel)
                        e.Graphics.DrawRectangle(PaintDash, area)
                    Next

                End If

            End If




        End If

        If _ImageAreas IsNot Nothing Then

            Dim PaintDash As New Pen(Color.Black)
            PaintDash.DashStyle = DashStyle.Dash

            For Each area In _ImageAreas
                e.Graphics.DrawRectangle(PaintDash, area)
            Next

            PaintDash.Dispose()
            PaintDash = Nothing
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

        Rect.X = (Rect.X - ClientSize.Width / 2.0F) / _zoom + ImageCenter.X
        Rect.Y = (Rect.Y - ClientSize.Height / 2.0F) / _zoom + ImageCenter.Y

        Rect.Width /= _zoom
        Rect.Height /= _zoom
        Return Rect

    End Function
    Public Overloads Function ClientToImageBox(ByVal Rect As RectangleF) As RectangleF

        Rect.X = (Rect.X - ClientSize.Width / 2.0F) / _zoom + ImageCenter.X
        Rect.Y = (Rect.Y - ClientSize.Height / 2.0F) / _zoom + ImageCenter.Y

        Rect.Width /= _zoom
        Rect.Height /= _zoom

        Return Rect

    End Function


    Public Overloads Function ImageToClientBox(ByVal Rect As Rectangle) As Rectangle


        Rect.X = (Rect.X - ImageCenter.X) * _zoom + ClientSize.Width / 2.0F
        Rect.Y = (Rect.Y - ImageCenter.Y) * _zoom + ClientSize.Height / 2.0F

        Rect.Width *= _zoom
        Rect.Height *= _zoom

        Return Rect

    End Function

    Public Overloads Function ImageToClientBox(ByVal Rect As RectangleF) As RectangleF

        Rect.X = (Rect.X - ImageCenter.X) * _zoom + ClientSize.Width / 2.0F
        Rect.Y = (Rect.Y - ImageCenter.Y) * _zoom + ClientSize.Height / 2.0F

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

    Public Overloads Function CopyBoxImage(ByVal bbox As Rectangle) As Image

        Dim ImageCopy As New Bitmap(bbox.Width, bbox.Height, Imaging.PixelFormat.Format24bppRgb)
        Dim imgbox As New Rectangle(New Point(0, 0), bbox.Size)
        Using e = Graphics.FromImage(ImageCopy)

            e.DrawImage(Image, imgbox, bbox, GraphicsUnit.Pixel)

        End Using

        Return ImageCopy
    End Function

    Public Overloads Sub PasteImage(ByVal srcimg As Bitmap, ByVal bbox As Rectangle)


        Dim srcRec As New Rectangle(0, 0, bbox.Width, bbox.Height)

        Dim img = ImageUtils.CloneImageForGraphics(_image)

        Using e = Graphics.FromImage(img)

            e.DrawImage(srcimg, bbox, srcRec, GraphicsUnit.Pixel)

        End Using

        _image = img.Clone
        img.Dispose()
        img = Nothing

        Invalidate()

    End Sub

    Public Overloads Sub PasteImage(ByVal srcimg As Bitmap, ByVal srcRec As Rectangle, ByVal destRec As Rectangle)


        Dim img = ImageUtils.CloneImageForGraphics(_image)

        Using e = Graphics.FromImage(img)

            e.DrawImage(srcimg, destRec, srcRec, GraphicsUnit.Pixel)

        End Using

        _image = img.Clone
        img.Dispose()
        img = Nothing

        Invalidate()

    End Sub

    Public Overloads Function CopyBoxImage(ByVal bbox As Rectangle, ByVal imgbox As Rectangle) As Image

        Dim ImageCopy As New Bitmap(imgbox.Width, imgbox.Height, Imaging.PixelFormat.Format24bppRgb)

        Using e = Graphics.FromImage(ImageCopy)
            e.Clear(Color.White)
            e.DrawImage(Image, bbox, bbox, GraphicsUnit.Pixel)

        End Using

        Return ImageCopy
    End Function


    Public Overloads Sub InvertBoxAreaColor(ByVal bbox As Rectangle)

        Dim ImageCopy As New Bitmap(bbox.Width, bbox.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim imgbox As New Rectangle(New Point(0, 0), bbox.Size)

        Using e = Graphics.FromImage(ImageCopy)

            e.DrawImage(_image, imgbox, bbox, GraphicsUnit.Pixel)

        End Using

        ImageCopy = PreProcessor.Invert(ImageCopy)

        Dim ImagNew = ImageUtils.CloneImageForGraphics(_image)

        Using e = Graphics.FromImage(ImagNew)

            e.DrawImage(ImageCopy, bbox, imgbox, GraphicsUnit.Pixel)

        End Using

        _image = ImagNew.Clone

        ImagNew.Dispose()
        ImagNew = Nothing

        ImageCopy.Dispose()
        ImageCopy = Nothing

        Invalidate()

    End Sub

    Public Overloads Sub ClearBoxArea(ByVal rec As Rectangle)


        Dim ImageCopy = ImageUtils.CloneImageForGraphics(_image)

        Using e = Graphics.FromImage(ImageCopy)
            e.FillRectangle(Brushes.White, rec)
        End Using

        _image = ImageCopy.Clone
        ImageCopy.Dispose()
        ImageCopy = Nothing



    End Sub

    Public Overloads Sub ClearImage()

        Dim ImageCopy = ImageUtils.CloneImageForGraphics(_image)

        Using e = Graphics.FromImage(ImageCopy)
            e.Clear(Color.White)
        End Using

        _image = ImageCopy.Clone
        ImageCopy.Dispose()
        ImageCopy = Nothing



    End Sub


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ImageViewControl
        '
        Me.Name = "ImageViewControl"
        Me.ResumeLayout(False)

    End Sub

End Class
