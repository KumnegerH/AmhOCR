
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class ImageEditControl
    Inherits ImageViewControl

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3



#Region "Members"

    Public Event BoxHighlightedEvent As EventHandler(Of BoxHighlightedArg)
    Public Event HocrEdited As EventHandler

    Public Event SignalBusy As EventHandler

    Public Event EditModeChanged As EventHandler

    Private _HocrPage As HocrPage

    Private OCRblocks As List(Of Rectangle)

    Private HotHocrObjects As List(Of HocrObjEditor)

    Private BoxSelectionStPoint As Point
    Private MousePostion As Point
    Friend BoxRectangle As Rectangle

    Private _isBusy As Boolean = False
    Private SkipRefresh As Boolean = False

    Private HocrSelected As Boolean = False
    Private _selectedhocrID As Integer = -1


    Private HocrHighlighted As Boolean = False
    Private HighlightedHocrID As Integer = -1
    Private PageHighlighted As Boolean = False



    Private PageHighlightedID As Integer = -1

    Private ContextParaId As Integer = -1


    Private GroupSelectionList As List(Of Integer)



    Public EditorTextBox As TextBox

    Private MenuStripHocrOptions As ContextMenuStrip


    Private MenuStripGeneralOptions As ContextMenuStrip



    ' Private RedoList As New List(Of EditMetadata)
    ' Private UndoList As New List(Of EditMetadata)


    Private UndoType As New List(Of Integer)
    Private RedoType As New List(Of Integer)

    Private EditContext As ToolStripMenuItem
    Private LockContext As ToolStripMenuItem
    Private ViewsContext As ToolStripMenuItem
    Private AlignmentContext As ToolStripMenuItem

    ' A main class to Spell check
    Friend SpellCheker As SpellCheker

    Private EditConfirmation As Boolean = False
    Private _Freez As Boolean = False


#End Region

#Region "Intitialize and End"


    Public Sub New()
        MyBase.New()

        SpellCheker = New SpellCheker
        SetContextMenuStripHocrOptions()

        '   Me.ContextMenuStrip  = MenuStripHocrOptions

    End Sub


    Private Sub SetContextMenuStripHocrOptions()

        MenuStripGeneralOptions = New ContextMenuStrip

        MenuStripHocrOptions = New ContextMenuStrip

        EditContext = New ToolStripMenuItem
        EditContext.Text = "Edit Paragraph          "
        EditContext.ShowShortcutKeys = True
        EditContext.ShortcutKeys = Keys.Control Or Keys.Shift Or Keys.E


        MenuStripHocrOptions.Items.Add(EditContext)


        LockContext = New ToolStripMenuItem


        LockContext.Text = "Lock as varified"

        LockContext.Checked = False
        LockContext.CheckOnClick = False

        MenuStripHocrOptions.Items.Add(LockContext)


        Dim resetPara As New ToolStripMenuItem
        resetPara.Text = "Reset Text"
        MenuStripHocrOptions.Items.Add(resetPara)


        Dim SepaContext1 As New ToolStripSeparator
        MenuStripHocrOptions.Items.Add(SepaContext1)




        Dim ParagimgContext = MenuStripHocrOptions.Items.Add("Copy area as image  ")

        MenuStripHocrOptions.Items.Add("Copy original image area  ")

        Dim CopyAreaContext = MenuStripHocrOptions.Items.Add("Copy area text    ")


        Dim PasteAdv = MenuStripHocrOptions.Items.Add("Paste text from Clipboard   ")
        PasteAdv.Enabled = False

        Dim RemoveAdv = MenuStripHocrOptions.Items.Add("Remove This box ")
        RemoveAdv.Enabled = False


        Dim SepaContext As New ToolStripSeparator
        MenuStripHocrOptions.Items.Add(SepaContext)

        AlignmentContext = New ToolStripMenuItem
        AlignmentContext.Text = "Alignment"
        Dim left As ToolStripMenuItem = AlignmentContext.DropDownItems.Add("Left       ")
        Dim right As ToolStripMenuItem = AlignmentContext.DropDownItems.Add("right       ")
        Dim center As ToolStripMenuItem = AlignmentContext.DropDownItems.Add("Center       ")
        Dim both As ToolStripMenuItem = AlignmentContext.DropDownItems.Add("Justified       ")

        left.Enabled = False
        right.Enabled = False
        center.Enabled = False
        both.Enabled = False

        MenuStripHocrOptions.Items.Add(AlignmentContext)

        ViewsContext = New ToolStripMenuItem

        ViewsContext.Text = "Box View Mode            "


        GroupSelectionList = New List(Of Integer)

        Dim BoxsC As ToolStripMenuItem = ViewsContext.DropDownItems.Add("View Character  Box    ")
        BoxsC.Enabled = False
        Dim BoxsW As ToolStripMenuItem = ViewsContext.DropDownItems.Add("View Word Box  ")

        Dim BoxsL As ToolStripMenuItem = ViewsContext.DropDownItems.Add("View Line Box  ")
        BoxsL.Enabled = False
        Dim BoxsS As ToolStripMenuItem = ViewsContext.DropDownItems.Add("View Sentence Box")
        BoxsS.Enabled = False
        Dim BoxsP As ToolStripMenuItem = ViewsContext.DropDownItems.Add("View Pragraph Box")

        Dim BoxsColmn As ToolStripMenuItem = ViewsContext.DropDownItems.Add("View Column Box")
        BoxsColmn.Enabled = False

        Dim CopyAllText As ToolStripMenuItem = New ToolStripMenuItem("Copy all as text                ")
        CopyAllText.ShowShortcutKeys = True
        CopyAllText.ShortcutKeys = Keys.Control Or Keys.C


        Dim CopyAllImage As ToolStripMenuItem = New ToolStripMenuItem("Copy all as image")
        CopyAllImage.ShowShortcutKeys = True
        CopyAllImage.ShortcutKeys = Keys.Control Or Keys.ShiftKey Or Keys.C

        Dim ExportPage As ToolStripMenuItem = New ToolStripMenuItem("Export Page")
        ExportPage.ShowShortcutKeys = True
        ExportPage.ShortcutKeys = Keys.Control Or Keys.ShiftKey Or Keys.E



        Dim PageProperty As ToolStripMenuItem = New ToolStripMenuItem("Page Property")
        PageProperty.ShowShortcutKeys = True
        PageProperty.ShortcutKeys = Keys.Control Or Keys.ShiftKey Or Keys.P


        MenuStripGeneralOptions.Items.Add(CopyAllText)
        MenuStripGeneralOptions.Items.Add(CopyAllImage)

        Dim SepaContext3 As New ToolStripSeparator
        MenuStripGeneralOptions.Items.Add(SepaContext3)

        MenuStripGeneralOptions.Items.Add(ViewsContext)

        Dim SepaContext4 As New ToolStripSeparator
        MenuStripGeneralOptions.Items.Add(SepaContext4)

        MenuStripGeneralOptions.Items.Add(ExportPage)
        MenuStripGeneralOptions.Items.Add(PageProperty)

        AddHandler CopyAllImage.Click, AddressOf CopyImageToClipboard
        AddHandler EditContext.Click, AddressOf SetEditBox
        AddHandler CopyAreaContext.Click, AddressOf CopyText
        AddHandler CopyAllText.Click, AddressOf AllTextCopy
        AddHandler LockContext.Click, AddressOf LockParagraph
        AddHandler resetPara.Click, AddressOf ResetParagraph
        AddHandler ParagimgContext.Click, AddressOf CopyasImage



        AddHandler ViewsContext.DropDownOpening,
            New EventHandler(
            Sub(s, e)
                If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                    BoxsW.Checked = True
                    BoxsP.Checked = False
                Else
                    BoxsP.Checked = True
                    BoxsW.Checked = False
                End If
            End Sub)


        AddHandler BoxsW.Click, AddressOf SetWordEditMode
        AddHandler BoxsP.Click, AddressOf SetParagraphEditMode



    End Sub

    ''' <summary>
    ''' Initilize SpellCheker dictionary
    ''' </summary>
    Friend Async Sub InitializSpeller()

        Dim task = TaskEx.Run(
            Sub()
                SpellCheker = New SpellCheker
                AddHandler SpellCheker.DicLoaded, AddressOf CheckSpeller
                SpellCheker.InitializSpellCheck()
            End Sub)


        Await task



    End Sub

    Private Sub CheckSpeller()

        'Spell Check and flag each hocrword object in hocrpage
        Try
            If SpellCheker.Loaded = True Then

                If HocrPage IsNot Nothing AndAlso HotHocrObjects IsNot Nothing Then
                    If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                        For parcnt As Integer = 0 To HotHocrObjects.Count - 1
                            Dim parag = HotHocrObjects(parcnt)
                            parag.Spelled = False
                            If SpellCheker.isValidWord(parag.text) Then
                                parag.Spelled = True

                            End If

                            HotHocrObjects(parcnt) = parag

                        Next

                        Invalidate()
                    End If

                End If

            Else
                If SpellCheker.isloading = False Then
                    InitializSpeller()
                End If
            End If

        Catch ex As Exception

        End Try




    End Sub


    Public Async Sub SetEditorMode()
        isBusy = True
        Me.Cursor = Cursors.WaitCursor
        Dim tsk = TaskEx.Run(
            Sub()
                If HocrPage IsNot Nothing Then

                    HotHocrObjects = New List(Of HocrObjEditor)
                    OCRblocks = New List(Of Rectangle)
                    Me.Invalidate()

                    If OCRsettings.EditMode = ocrEditMode.WordEdit Then

                        Dim areas = _HocrPage.AllocrCarea
                        For ar As Integer = 0 To areas.Count - 1

                            Dim Pars = areas(ar).AllocrParas
                            For pr As Integer = 0 To Pars.Count - 1
                                OCRblocks.Add(Pars(pr).bbox)
                                Dim lins = Pars(pr).AllocrLines
                                For ln As Integer = 0 To lins.Count - 1

                                    Dim words = lins(ln).AllocrWords
                                    For wd As Integer = 0 To words.Count - 1

                                        Dim HocrParEditor As New HocrObjEditor
                                        HocrParEditor.EditMode = ocrEditMode.WordEdit

                                        HocrParEditor.HocrObject = words(wd)
                                        HocrParEditor.text = words(wd).Text

                                        HocrParEditor.isDirty = False
                                        HocrParEditor.isLocked = False
                                        HocrParEditor.isinEdit = False

                                        HocrParEditor.Spelled = True

                                        HocrParEditor.alignment = Pars(pr).Alignment
                                        HocrParEditor.Font = Pars(pr).Font

                                        If words(wd).txtbox.IsEmpty Then

                                            words(wd).txtbox = words(wd).bbox

                                            'correction is needed for bbox, due to font's internal inherent metrics, such as linespace,ascent and descent

                                            Using txtboxtest As New GraphicsPath

                                                Dim txtbox = words(wd).txtbox

                                                txtboxtest.AddString(words(wd).Text, Pars(pr).Font.FontFamily, 0, Pars(pr).Font.Size, New Point(0, 0), Pars(pr).StringFormat)

                                                Dim txtBound = txtboxtest.GetBounds

                                                txtbox.X -= txtBound.X
                                                txtbox.Y -= txtBound.Y

                                                words(wd).txtbox = txtbox

                                            End Using



                                        End If


                                        HocrParEditor.bbox = words(wd).txtbox

                                        If HotHocrObjects IsNot Nothing Then
                                            HotHocrObjects.Add(HocrParEditor)
                                        End If



                                    Next

                                Next

                            Next

                        Next

                        CheckSpeller()
                    Else


                        Dim areas = _HocrPage.AllocrCarea

                        For ar As Integer = 0 To areas.Count - 1

                            Dim Pars = areas(ar).AllocrParas
                            For pr As Integer = 0 To Pars.Count - 1

                                OCRblocks.Add(Pars(pr).bbox)

                                Dim HocrParEditor As New HocrObjEditor
                                HocrParEditor.EditMode = ocrEditMode.ParagraphEdit

                                HocrParEditor.HocrObject = Pars(pr)
                                HocrParEditor.text = Pars(pr).Text

                                HocrParEditor.isDirty = False
                                HocrParEditor.isLocked = False
                                HocrParEditor.isinEdit = False

                                HocrParEditor.Spelled = True
                                HocrParEditor.Font = Pars(pr).Font
                                HocrParEditor.alignment = Pars(pr).Alignment
                                HocrParEditor.bbox = Pars(pr).bbox

                                If HotHocrObjects IsNot Nothing Then
                                    HotHocrObjects.Add(HocrParEditor)
                                End If


                            Next

                        Next

                    End If

                End If

            End Sub)




        Try

            Await tsk

        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Arrow
        Me.Invalidate()

        isBusy = False
    End Sub







    Public Overloads Sub DisposeImage()
        MyBase.DisposeImage()

        If HocrPage IsNot Nothing Then
            HocrPage = Nothing
            Invalidate()
        End If

    End Sub

    Private Sub ImageEditControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        GC.Collect()
    End Sub



    ''' <summary>
    ''' Reset edit state
    ''' </summary>
    Friend Sub ResetAllState()
        EndBoxEdit()

        PageHighlighted = False
        HocrHighlighted = False


        PageHighlightedID = -1

        HighlightedHocrID = -1

        Freez = False

        GroupSelectionList.Clear()
        HocrSelected = False
        HocrHighlighted = False

        SelectedHocrID = -1
        HotHocrObjects = Nothing
        EditorTextBox = Nothing
        OCRblocks = Nothing
        State = controlState.None
        PreviouscontrolState = controlState.None
        BoxRectangle = New Rectangle

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


    Private Sub CopyText()

        Try
            If ContextParaId >= 0 Then
                Clipboard.Clear()
                Clipboard.SetText(HotHocrObjects(ContextParaId).text)


            End If
        Catch ex As Exception

        End Try


    End Sub


    Private Sub CopyasImage()

        Try
            If ContextParaId >= 0 Then
                If Image IsNot Nothing Then

                    Try
                        Clipboard.SetImage(CopyAllToImage(ContextParaId))
                    Catch ex As Exception

                    End Try


                End If

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub AllTextCopy()

        If isBusy = False Then
            If HocrPage IsNot Nothing Then
                If String.IsNullOrEmpty(HocrPage.UTF8Text) = False Then
                    Clipboard.Clear()
                    Clipboard.SetText(HocrPage.UTF8Text)
                End If
            End If

        End If

    End Sub

    Private Sub ResetParagraph()

        Try
            If ContextParaId >= 0 Then
                Dim HotParagraph = HotHocrObjects(ContextParaId)
                HotParagraph.text = HotParagraph.HocrObject.orignalText

                If OCRsettings.EditMode = ocrEditMode.ParagraphEdit Then
                    HotParagraph.alignment = HotParagraph.HocrObject.Alignment
                    HotParagraph.Font = HotParagraph.HocrObject.Font.Clone
                ElseIf OCRsettings.EditMode = ocrEditMode.WordEdit Then
                    HotParagraph.Spelled = SpellCheker.isValidWord(HotParagraph.text)
                End If

                HotParagraph.isDirty = False
                HotParagraph.isinEdit = False
                HotParagraph.isLocked = False

                HotHocrObjects(ContextParaId) = HotParagraph
                Invalidate()

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LockParagraph()

        Try
            If ContextParaId >= 0 Then

                Dim HotParagraph = HotHocrObjects(ContextParaId)

                If LockContext.Checked = True Then

                    HotParagraph.isLocked = False

                Else

                    HotParagraph.isLocked = True

                End If

                HotHocrObjects(ContextParaId) = HotParagraph

            End If
        Catch ex As Exception

        End Try


    End Sub


    ''' <summary>
    ''' Copy Image with the recognized text
    ''' </summary>
    ''' <returns></returns>
    Public Overloads Function CopyAllToImage() As Image

        Dim ImageCopy = _image.Clone
        ' Dim lins = PostProcessor.ColumnTest_Vertical(_HocrPage)

        ' lins = lins.OrderBy(Function(X) X.Y).Reverse.ToList

        Using e = Graphics.FromImage(ImageCopy)

            e.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            e.TextContrast = 4

            If HotHocrObjects IsNot Nothing AndAlso isBusy = False Then

                Dim DifStringFormat As New StringFormat
                DifStringFormat.Alignment = StringAlignment.Near
                DifStringFormat.LineAlignment = StringAlignment.Near
                DifStringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.NoClip

                For pr As Integer = 0 To OCRblocks.Count - 1 Step 1
                    e.FillRectangle(Brushes.White, OCRblocks(pr))
                Next

                For pr As Integer = 0 To HotHocrObjects.Count - 1 Step 1

                    Dim parag = HotHocrObjects(pr)

                    If HotHocrObjects(pr).Spelled = True Then
                        e.DrawString(parag.text, HotHocrObjects(pr).Font, Brushes.Black, parag.bbox.Location, DifStringFormat)

                    Else

                        e.DrawString(parag.text, HotHocrObjects(pr).Font, Brushes.Red, parag.bbox.Location, DifStringFormat)
                    End If

                Next



                DifStringFormat.Dispose()
                DifStringFormat = Nothing


            End If


        End Using

        Return ImageCopy
    End Function


    Public Overloads Function CopyAllToImage(ByVal paraid As Integer) As Image

        Dim ImageCopy As New Bitmap(HotHocrObjects(paraid).bbox.Width, HotHocrObjects(paraid).bbox.Height)

        Using e = Graphics.FromImage(ImageCopy)

            Dim PenLin As New Pen(Color.Red, 2)
            e.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            e.TextContrast = 4

            If HotHocrObjects IsNot Nothing Then

                Dim parag = HotHocrObjects(paraid)

                e.Clear(Color.White)
                e.DrawString(parag.text, parag.Font, Brushes.Black, New Point(0, 0))

            End If


        End Using

        Return ImageCopy
    End Function


    Public Overloads Function CopyPragaImagOrignal(ByVal paraid As Integer) As Image

        Dim ImageCopy As New Bitmap(HotHocrObjects(paraid).bbox.Width, HotHocrObjects(paraid).bbox.Height)

        Using e = Graphics.FromImage(ImageCopy)
            Dim PenLin As New Pen(Color.Red, 2)
            e.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            e.TextContrast = 4

            If HotHocrObjects IsNot Nothing Then

                Dim parag = HotHocrObjects(paraid)

                e.FillRectangle(Brushes.White, parag.bbox)
                e.DrawString(parag.text, parag.Font, Brushes.Black, New Point(0, 0))

            End If


        End Using

        Return ImageCopy
    End Function



#End Region

#Region "Control Events"


    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)

        MyBase.OnMouseDown(e)

        If HocrPage Is Nothing Then

            If e.Button = MouseButtons.Left Then

                If ModifierKeys = Keys.Control Then
                    Dim pnt = ClientToImagePoint(e.Location)
                    PreviouscontrolState = controlState.None
                    State = controlState.DrawRect
                    BoxSelectionStPoint = pnt
                    MousePostion = pnt

                    BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)

                End If

            End If

            Exit Sub
        End If

        If Freez = True Then

            EndBoxEdit()
            HighlightedHocrID = -1
            HocrHighlighted = False

        End If


        If Freez = False Then



            Dim pnt = ClientToImagePoint(e.Location)



            If e.Button = MouseButtons.Right Then

                If CheckHighlightedObject(pnt) Then

                    If HocrHighlighted = False Then

                        HighlightedHocrID = -1
                        GroupSelectionList.Clear()
                        HocrSelected = False
                        SelectedHocrID = -1

                        MenuStripGeneralOptions.Show(Me.PointToScreen(e.Location))
                        State = controlState.None
                    Else
                        GroupSelectionList.Clear()

                        If HotHocrObjects(HighlightedHocrID).isLocked = False Then
                            For Each stripi In MenuStripHocrOptions.Items
                                stripi.Enabled = True
                            Next
                            LockContext.Checked = False
                            LockContext.Text = "Lock as varified   "
                        Else
                            For Each stripi In MenuStripHocrOptions.Items
                                stripi.Enabled = False
                            Next
                            LockContext.Enabled = True
                            LockContext.Checked = True
                            LockContext.Text = "UnLock Paragraph "

                        End If

                        ContextParaId = HighlightedHocrID
                        MenuStripHocrOptions.Show(Me.PointToScreen(e.Location))
                        State = controlState.None
                    End If

                Else
                    GroupSelectionList.Clear()
                    HocrSelected = False
                    SelectedHocrID = -1
                    HighlightedHocrID = -1
                    MenuStripGeneralOptions.Show(Me.PointToScreen(e.Location))
                    State = controlState.None
                End If

            ElseIf e.Button = MouseButtons.Left Then

                CheckHighlightedObject(pnt)

                If HocrHighlighted = True Then

                    HocrSelected = True
                    SelectedHocrID = HighlightedHocrID

                    If ModifierKeys = Keys.Control Then
                        If GroupSelectionList.Contains(SelectedHocrID) = False Then
                            GroupSelectionList.Add(SelectedHocrID)

                        End If
                    Else
                        GroupSelectionList.Clear()
                        GroupSelectionList.Add(SelectedHocrID)

                    End If

                Else

                    GroupSelectionList.Clear()
                    HocrSelected = False
                    SelectedHocrID = -1
                    HighlightedHocrID = -1

                End If


            End If




        End If

        Invalidate()

    End Sub



    Protected Overrides Sub OnPreviewKeyDown(ByVal e As PreviewKeyDownEventArgs)
        MyBase.OnPreviewKeyDown(e)

        If HocrPage Is Nothing Then
            Exit Sub
        End If


        If e.KeyCode = Keys.Delete Then

            If HocrSelected = True Then
                If (Freez = False) AndAlso SelectedHocrID >= 0 Then

                    HotHocrObjects.RemoveAt(SelectedHocrID)

                    HocrSelected = False
                    SelectedHocrID = -1
                    HocrHighlighted = False
                    HighlightedHocrID = -1


                    Invalidate()
                End If


            End If
        ElseIf e.KeyCode = Keys.Escape Then
            State = controlState.None
            If Freez = True Then
                EndBoxEdit()
                HocrSelected = False
                SelectedHocrID = -1
                HocrHighlighted = False
                HighlightedHocrID = -1
                Freez = False
                Invalidate()
            End If
        End If



    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)

    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)

        If State = controlState.DrawRect Then

            Dim pnt = ClientToImagePoint(e.Location)
            BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, pnt)
            PreviouscontrolState = controlState.DrawRect
            State = controlState.None
            Invalidate()
        End If
    End Sub


    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)



        MyBase.OnMouseMove(e)



        SkipRefresh = False

        If (HocrPage Is Nothing) OrElse (HotHocrObjects Is Nothing) OrElse (Freez = True) Then

            If (HocrPage Is Nothing) Then
                If State = controlState.DrawRect Then

                    MousePostion = ClientToImagePoint(e.Location)

                    BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)
                    Invalidate()
                End If

            End If


            Exit Sub
        End If


        MousePostion = ClientToImagePoint(e.Location)

        If State = controlState.None Then

            If Freez = True Then
                RefreshEditBox()
            End If

            If CheckHighlightedObject(MousePostion) Then

                If SkipRefresh = False Then
                    Invalidate()
                End If

            End If

        ElseIf State = controlState.Drag Then
            ' Invalidate()

        End If


    End Sub

    Protected Overrides Sub OnMouseDoubleClick(ByVal e As MouseEventArgs)

        MyBase.OnMouseDoubleClick(e)

        HocrSelected = False

        If Freez = False Then
            SetEditBox()
        End If

    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)

        If Freez = True Then

            ' There is a filcker that need to be handeled inorder to impliment zoom while text editing 

            'MyBase.OnMouseWheel(e)
            'RefreshEditBox()
            'SetEditerFont()
            'Invalidate()

            Exit Sub
        Else
            MyBase.OnMouseWheel(e)
        End If



    End Sub

    ''' <summary>
    ''' Paints recognized paragraphs and their boxs one the original image
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)


        MyBase.OnPaint(e)




        If HocrPage Is Nothing OrElse HotHocrObjects Is Nothing Then

            If (State = controlState.DrawRect) OrElse (PreviouscontrolState = controlState.DrawRect) Then

                If (BoxRectangle.Width * BoxRectangle.Height) <> 0 Then
                    Dim penRec As Pen
                    If State = controlState.DrawRect Then
                        penRec = New Pen(Color.DimGray, 1 / _zoom)
                    Else
                        penRec = New Pen(Color.LimeGreen, 2 / _zoom)
                    End If

                    penRec.DashStyle = DashStyle.Dash
                    e.Graphics.DrawRectangle(penRec, BoxRectangle)
                End If

            End If



            Exit Sub

        End If

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.TextContrast = 4

        If OCRsettings.ResetBackground Then

            If HocrPage IsNot Nothing Then
                e.Graphics.FillRectangle(Brushes.White, HocrPage.bbox)
            End If


        End If


        Dim DifStringFormat As New StringFormat
        DifStringFormat.Alignment = StringAlignment.Near
        DifStringFormat.LineAlignment = StringAlignment.Near
        DifStringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.NoClip

        Dim penselected = New Pen(Color.LimeGreen, 2 / _zoom)
        Dim penHighlit = New Pen(Color.Red, 2 / _zoom)

        For pr As Integer = 0 To OCRblocks.Count - 1 Step 1
            e.Graphics.FillRectangle(Brushes.White, OCRblocks(pr))
        Next

        Dim pathGr As New GraphicsPath

        For pr As Integer = 0 To HotHocrObjects.Count - 1 Step 1

            If HotHocrObjects(pr).isinEdit = False Then


                Dim parag = HotHocrObjects(pr)

                If HotHocrObjects(pr).Spelled = True Then
                    e.Graphics.DrawString(parag.text, HotHocrObjects(pr).Font, Brushes.Black, parag.bbox.Location, DifStringFormat)
                Else

                    e.Graphics.DrawString(parag.text, HotHocrObjects(pr).Font, Brushes.Red, parag.bbox.Location, DifStringFormat)
                End If

                If (pr = HighlightedHocrID) Then

                    e.Graphics.DrawRectangle(penHighlit, parag.HocrObject.bbox)

                End If

                If (pr = SelectedHocrID) Then
                    e.Graphics.DrawRectangle(penselected, parag.HocrObject.bbox)
                End If


            End If


        Next





        pathGr.Dispose()
        penselected.Dispose()
        penHighlit.Dispose()


    End Sub



#End Region





    ''' <summary>
    ''' Get and Set extracted/OCR/ image data
    ''' </summary>
    ''' <returns></returns>
    Public Property HocrPage As HocrPage

        Set(value As HocrPage)

            If value Is Nothing Then
                EndBoxEdit()
                _HocrPage = Nothing
                OCRblocks = Nothing
                HotHocrObjects = Nothing
                ResetAllState()
                Exit Property
            End If

            State = controlState.None
            HocrHighlighted = False
            HocrSelected = False
            SelectedHocrID = -1

            ContextParaId = -1

            _HocrPage = value



            'OCRsettings.MaximumColumn_Num = PostProcessor.ColumnTest_Horizontal(_HocrPage, OCRsettings.ColumnRecog_ConfidenceLvl).X

            SetEditorMode()







        End Set

        Get

            Return _HocrPage

        End Get

    End Property

    ''' <summary>
    '''  Freez The picture box zoom during text edting
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Property Freez As Boolean
        Set(value As Boolean)
            _Freez = value
        End Set
        Get
            Return _Freez
        End Get
    End Property





    ''' <summary>
    ''' Check if the mouse is over a paragraph
    ''' </summary>
    ''' <param name="pnt">Mouse Location</param>
    Private Function CheckHighlightedObject(ByVal pnt As Point) As Boolean

        Dim PrevObjectHighlighted = HocrHighlighted
        Dim PrevHighlightedHocrID = HighlightedHocrID


        PageHighlighted = False
        HocrHighlighted = False


        PageHighlightedID = -1
        HighlightedHocrID = -1


        If HocrPage.bbox.Contains(pnt) Then

            PageHighlighted = True
            isParagraphHighlighted(pnt)

            If HocrHighlighted Then

                If (PrevHighlightedHocrID = HighlightedHocrID) Then
                    SkipRefresh = True
                End If

            End If


        End If


        Return HocrHighlighted OrElse PrevObjectHighlighted

    End Function


    Private Sub isParagraphHighlighted(ByVal pnt As Point)

        HocrHighlighted = False
        For ar As Integer = 0 To HotHocrObjects.Count - 1

            If HocrHighlighted = False Then

                Dim BoxREC As Rectangle = HotHocrObjects(ar).HocrObject.bbox

                If BoxREC.Contains(pnt) Then
                    HocrHighlighted = True
                    HighlightedHocrID = ar
                    Exit For
                End If


            End If


        Next



    End Sub




    ''' <summary>
    ''' Resize editor textbox based on current zoom level and center position
    ''' </summary>
    Private Sub RefreshEditBox()

        If EditorTextBox IsNot Nothing Then

            Dim bbox As Rectangle = HotHocrObjects(CType(EditorTextBox.Tag, Integer)).HocrObject.bbox
            EditorTextBox.Size = ImageToClientBox(New Rectangle(New Point(0, 0), bbox.Size)).Size
            EditorTextBox.Location = ImagePointToClient(bbox.Location)

        End If

    End Sub




    Friend Property isBusy As Integer
        Set(value As Integer)
            _isBusy = value
            RaiseEvent SignalBusy(Me, Nothing)
        End Set
        Get
            Return _isBusy
        End Get
    End Property



    ''' <summary>
    ''' When hocr object is selected and SelectedHocrID is set, in the original imageviewer control,
    ''' the selected object's bounding box will be highlighted by raisinig BoxHighlightedEvent
    ''' </summary>
    ''' <returns></returns>
    Private Property SelectedHocrID As Integer

        Set(value As Integer)
            _selectedhocrID = value
            If _selectedhocrID >= 0 Then
                Try
                    Dim hdler = New BoxHighlightedArg(HotHocrObjects(_selectedhocrID).HocrObject.bbox)
                    RaiseEvent BoxHighlightedEvent(Nothing, hdler)
                Catch ex As Exception

                    RaiseEvent BoxHighlightedEvent(Nothing, Nothing)
                End Try
            Else

                RaiseEvent BoxHighlightedEvent(Nothing, Nothing)
            End If

        End Set
        Get
            Return _selectedhocrID
        End Get

    End Property



    ''' <summary>
    ''' Set the current highlighted paragraph to an edit state
    ''' </summary>
    Private Sub SetEditBox()


        Try

            EndBoxEdit()

            If HocrHighlighted Then
                Dim HotParagraph = HotHocrObjects(HighlightedHocrID)

                If (HotParagraph.isLocked = False) AndAlso (String.IsNullOrEmpty(HotParagraph.text) = False) Then
                    Freez = True

                    EditorTextBox = New TextBox
                    EditorTextBox.Visible = False


                    EditConfirmation = True
                    EditorTextBox.Size = HotParagraph.HocrObject.bbox.Size
                    EditorTextBox.Font = HotParagraph.Font.Clone
                    EditorTextBox.Text = HotParagraph.text
                    HotParagraph.isinEdit = True
                    HotHocrObjects(HighlightedHocrID) = HotParagraph

                    EditorTextBox.BorderStyle = BorderStyle.FixedSingle

                    EditorTextBox.Parent = Me
                    EditorTextBox.Padding = New Padding(0)
                    EditorTextBox.Margin = New Padding(0)
                    EditorTextBox.Tag = HighlightedHocrID
                    EditorTextBox.ScrollBars = RichTextBoxScrollBars.None
                    EditorTextBox.WordWrap = False
                    EditorTextBox.Multiline = True
                    RefreshEditBox()
                    SetEditerFont()

                    EditorTextBox.Visible = True
                    EditorTextBox.BringToFront()
                    EditorTextBox.Refresh()

                    EditorTextBox.Focus()

                    HocrHighlighted = False
                    HocrSelected = False
                    HighlightedHocrID = -1
                    SelectedHocrID = -1
                    GroupSelectionList.Clear()
                    If HotParagraph.Spelled = False Then
                        EditorTextBox.ForeColor = Color.Red
                    Else
                        EditorTextBox.ForeColor = Color.Black
                    End If

                    AddHandler EditorTextBox.PreviewKeyDown, AddressOf OnEditerPreviewKeyDown

                    If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                        EditorTextBox.Multiline = False
                        AddHandler EditorTextBox.TextChanged, AddressOf onTextChangs
                        AddHandler EditorTextBox.MouseLeave, AddressOf onTextChangs

                    End If



                    Invalidate()

                End If


            End If



        Catch ex As Exception

        End Try


    End Sub

    Private Async Sub onTextChangs(ByVal sender As Object, ByVal e As EventArgs)


        If EditorTextBox IsNot Nothing Then
            If SpellCheker.Loaded = True Then

                Dim task = TaskEx.Run(
                    Sub()
                        If SpellCheker.isValidWord(EditorTextBox.Text) Then
                            EditorTextBox.ForeColor = Color.Black
                        Else
                            EditorTextBox.ForeColor = Color.Red
                        End If

                    End Sub)

                Await task
            End If

        End If

    End Sub

    Private Sub OnEditerPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)

        If e.KeyCode = Keys.Escape Then
            EditConfirmation = False
            EndBoxEdit()

        End If

    End Sub

    ''' <summary>
    ''' Reset previous edit state
    ''' </summary>
    Private Sub EndBoxEdit()

        If EditorTextBox IsNot Nothing Then

            RemoveHandler EditorTextBox.PreviewKeyDown, AddressOf OnEditerPreviewKeyDown
            RemoveHandler EditorTextBox.TextChanged, AddressOf onTextChangs
            RemoveHandler EditorTextBox.MouseLeave, AddressOf onTextChangs
            HighlightedHocrID = CType(EditorTextBox.Tag, Integer)

            Dim HotParagraph = HotHocrObjects(HighlightedHocrID)
            If EditConfirmation = True Then
                HotParagraph.text = EditorTextBox.Text
                If HotParagraph.text = HotParagraph.HocrObject.Text Then
                    HotParagraph.isDirty = False
                Else
                    HotParagraph.isDirty = True
                End If

                If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                    HotParagraph.Spelled = SpellCheker.isValidWord(HotParagraph.text)
                End If
            End If

            If HotParagraph.isDirty = True Then
                If HotParagraph.EditMode = ocrEditMode.WordEdit Then

                    Dim wordHocr As HocrWord = HotParagraph.HocrObject
                    wordHocr.Text = HotParagraph.text

                    _HocrPage.AllocrCarea(wordHocr.areaNum).AllocrParas(wordHocr.ParNum) _
                    .AllocrLines(wordHocr.lineNum).AllocrWords(wordHocr.WordNum) = wordHocr


                    RaiseEvent HocrEdited(ocrEditMode.WordEdit, Nothing)

                ElseIf HotParagraph.EditMode = ocrEditMode.ParagraphEdit Then

                    Dim ParHocr As HocrPar = HotParagraph.HocrObject
                    ParHocr.Text = HotParagraph.text
                    _HocrPage.AllocrCarea(ParHocr.AreaNum).AllocrParas(ParHocr.ParaNum) = ParHocr

                    RaiseEvent HocrEdited(ocrEditMode.ParagraphEdit, Nothing)

                End If
            End If



            HotParagraph.isinEdit = False
            HotHocrObjects(HighlightedHocrID) = HotParagraph
            EditorTextBox.Visible = False
            EditorTextBox = Nothing
            HighlightedHocrID = -1
        End If

        Freez = False

    End Sub

    ''' <summary>
    ''' Set the font size of editor textbox based on the current zoom level  
    ''' </summary>
    Private Sub SetEditerFont()

        Dim fn As New Font(EditorTextBox.Font, EditorTextBox.Font.Style)
        Dim x_size As Single = EditorTextBox.Size.Height / EditorTextBox.Lines.Count


        fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)

        Dim meser = TextRenderer.MeasureText(EditorTextBox.Text, fn, EditorTextBox.Size, TextFormatFlags.TextBoxControl)
        Dim trialCntMax As Integer = 0

        If (meser.Height > EditorTextBox.Size.Height) Then
            Do While (((meser.Height > EditorTextBox.Size.Height)) AndAlso (x_size > 1)) AndAlso (trialCntMax < 10000)

                x_size -= 0.1
                fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)
                meser = TextRenderer.MeasureText(EditorTextBox.Text, fn, EditorTextBox.Size, TextFormatFlags.TextBoxControl)

                trialCntMax += 1
            Loop
        Else

            Do While ((meser.Height < EditorTextBox.Size.Height)) AndAlso (trialCntMax < 10000)

                x_size += 0.1
                fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)
                meser = TextRenderer.MeasureText(EditorTextBox.Text, fn, EditorTextBox.Size, TextFormatFlags.TextBoxControl)

                trialCntMax += 1
            Loop

        End If



        EditorTextBox.Font = fn

    End Sub



    Private Sub SetWordEditMode(ByVal sender As Object, ByVal e As EventArgs)
        If isBusy = False Then
            OCRsettings.EditMode = ocrEditMode.WordEdit
            RaiseEvent EditModeChanged(Me, Nothing)
        End If

    End Sub


    Private Sub SetParagraphEditMode(ByVal sender As Object, ByVal e As EventArgs)
        If isBusy = False Then
            OCRsettings.EditMode = ocrEditMode.ParagraphEdit
            RaiseEvent EditModeChanged(Me, Nothing)
        End If

    End Sub

End Class



