
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Public Class HocrEditControl
    Inherits ImageViewControl

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3



#Region "Members"



    Public Event BoxHighlightedEvent As EventHandler(Of BoundingBoxArg)

    Public Event reRecognizeArea As EventHandler(Of RecognizeAreaArg)

    Public Event RemoveObjectEvent As EventHandler(Of RemoveOCRobjectArg)

    Public Event OCRObjectSet As EventHandler

    Public Event HocrEdited As EventHandler

    Public Event SignalBusy As EventHandler

    Public Event EditModeChanged As EventHandler



    Friend _HocrPage As HocrPage

    Friend OCRblocks As List(Of Rectangle)

    Friend HotHocrObjects As List(Of HocrObjEditor)

    Private BoxSelectionStPoint As Point
    Private MousePostion As Point


    Private _isBusy As Boolean = False
    Private SkipRefresh As Boolean = False

    Private MultiSelect As Boolean = False

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

    Private IgnoreContext As ToolStripMenuItem
    Private EditContext As ToolStripMenuItem
    Private LockContext As ToolStripMenuItem
    Private ViewsContext As ToolStripMenuItem
    Private AlignmentContext As ToolStripMenuItem
    Private AnnotationContext As ToolStripMenuItem
    ' A main class to Spell check
    Friend SpellCheker As SpellCheker

    Private EditConfirmation As Boolean = False
    Private _Freez As Boolean = False

    Private RecognizeArea As ToolStripItem
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


        Dim resetPara As New ToolStripMenuItem
        resetPara.Text = "Reset Text"
        MenuStripHocrOptions.Items.Add(resetPara)


        Dim SepaContext1 As New ToolStripSeparator
        MenuStripHocrOptions.Items.Add(SepaContext1)



        ''''''AnnotationContext

        AnnotationContext = New ToolStripMenuItem
        AnnotationContext.Text = "Annotation Indexing "
        AnnotationContext.Enabled = False
        Dim cat As ToolStripMenuItem = AnnotationContext.DropDownItems.Add("Category            ")
        cat.DropDownItems.Add("Social and cultural          ")
        cat.DropDownItems.Add("Politics")
        cat.DropDownItems.Add("Sport")
        cat.DropDownItems.Add("Entertainment")
        cat.DropDownItems.Add("History")
        cat.DropDownItems.Add("Local")
        cat.DropDownItems.Add("Global")
        cat.DropDownItems.Add("Others")


        Dim catSepa As New ToolStripSeparator
        AnnotationContext.DropDownItems.Add(catSepa)

        AnnotationContext.DropDownItems.Add("Main Title ")
        AnnotationContext.DropDownItems.Add("Key-Word ")

        Dim catSepa2 As New ToolStripSeparator
        AnnotationContext.DropDownItems.Add(catSepa2)

        AnnotationContext.DropDownItems.Add("Advanced Options")


        ' MenuStripHocrOptions.Items.Add(AnnotationContext)
        ' Dim SepaContext2 As New ToolStripSeparator
        ' MenuStripHocrOptions.Items.Add(SepaContext2)


        ''''''




        IgnoreContext = New ToolStripMenuItem
        IgnoreContext.Text = "Ignore Spell Error"
        MenuStripHocrOptions.Items.Add(IgnoreContext)


        LockContext = New ToolStripMenuItem
        LockContext.Text = "Lock as varified"

        LockContext.Checked = False
        LockContext.CheckOnClick = False

        MenuStripHocrOptions.Items.Add(LockContext)


        Dim SepaContext3 As New ToolStripSeparator
        MenuStripHocrOptions.Items.Add(SepaContext3)


        RecognizeArea = MenuStripHocrOptions.Items.Add("Re-Recognize area  ")

        MenuStripHocrOptions.Items.Add("Copy original image area  ")

        Dim CopyAreaContext = MenuStripHocrOptions.Items.Add("Copy area text    ")


        Dim PasteAdv = MenuStripHocrOptions.Items.Add("Paste text from Clipboard   ")
        PasteAdv.Enabled = False

        Dim SepaRemvContext As New ToolStripSeparator
        MenuStripHocrOptions.Items.Add(SepaRemvContext)

        Dim RemoveAdv = MenuStripHocrOptions.Items.Add("Remove This Object ")
        RemoveAdv.Enabled = True


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

        Dim SepaContext4 As New ToolStripSeparator
        MenuStripGeneralOptions.Items.Add(SepaContext4)

        MenuStripGeneralOptions.Items.Add(ViewsContext)

        Dim SepaContext5 As New ToolStripSeparator
        MenuStripGeneralOptions.Items.Add(SepaContext5)

        MenuStripGeneralOptions.Items.Add(ExportPage)
        MenuStripGeneralOptions.Items.Add(PageProperty)

        AddHandler CopyAllImage.Click, AddressOf CopyImageToClipboard
        AddHandler EditContext.Click, AddressOf SetEditBox
        AddHandler CopyAreaContext.Click, AddressOf CopyText
        AddHandler CopyAllText.Click, AddressOf AllTextCopy
        AddHandler LockContext.Click, AddressOf SetAsVarified
        AddHandler resetPara.Click, AddressOf ResetParagraph

        RecognizeArea.Enabled = False

        'AddHandler RecognizeArea.Click, AddressOf RecognizeImageArea

        AddHandler IgnoreContext.Click, AddressOf ignoreWordSpell
        AddHandler RemoveAdv.Click, AddressOf RemoveOCRObjects

        AddHandler ViewsContext.DropDownOpening,
            New EventHandler(
            Sub(s, e)
                If OCRsettings.EditMode = ocrEditMode.WordEdit Then
                    BoxsW.Checked = True
                    BoxsL.Checked = False
                    BoxsP.Checked = False

                ElseIf OCRsettings.EditMode = ocrEditMode.LineEdit Then
                    BoxsW.Checked = False
                    BoxsL.Checked = True
                    BoxsP.Checked = False

                ElseIf OCRsettings.EditMode = ocrEditMode.ParagraphEdit Then
                    BoxsW.Checked = False
                    BoxsL.Checked = False
                    BoxsP.Checked = True

                End If
            End Sub)


        AddHandler BoxsW.Click, AddressOf SetWordEditMode
        AddHandler BoxsP.Click, AddressOf SetParagraphEditMode
        AddHandler BoxsL.Click, AddressOf SetLineEditMode


    End Sub

    ''' <summary>
    ''' Initilize SpellCheker dictionary
    ''' </summary>
    Friend Async Sub InitializSpeller(ByVal Language As String)

        Dim task = TaskEx.Run(
            Sub()
                SpellCheker = New SpellCheker
                AddHandler SpellCheker.DicLoaded, AddressOf CheckSpeller
                SpellCheker.InitializSpellCheck(Language)

            End Sub)


        Await task



    End Sub

    Private Sub CheckSpeller()

        'Spell Check and flag each hocrword object in hocrpage
        If HocrPage IsNot Nothing AndAlso HotHocrObjects IsNot Nothing Then

            Try
                If SpellCheker.Loaded = True AndAlso HocrPage.PageOCRsettings.Language = SpellCheker.Lang Then

                    If OCRsettings.EditMode = ocrEditMode.WordEdit Then

                        For parcnt As Integer = 0 To HotHocrObjects.Count - 1 Step 1
                            Dim parag = HotHocrObjects(parcnt)

                            If OCRsettings.RemoveWhiteListChar Then
                                parag.text = SpellCheker.RemoveSpecialCharacters(parag.text)
                            End If

                            If parag.HocrObject.SpellChecked = False Then



                                parag.Spelled = False

                                If SpellCheker.isValidWord(parag.text) Then

                                    parag.Spelled = True
                                    Dim hocrword As HocrWord = parag.HocrObject
                                    hocrword.SpellChecked = True
                                    parag.HocrObject = hocrword


                                End If
                            Else
                                parag.Spelled = True
                            End If

                            If SpellCheker.UserWords.Count > 0 AndAlso parag.Spelled = True AndAlso parag.isUserText = False Then
                                Dim txt = parag.text.Trim(" ")
                                txt = SpellCheker.NormalizeText(txt)
                                If SpellCheker.UserWords.Contains(txt) Then
                                    parag.isUserText = True
                                End If

                            End If

                            HotHocrObjects(parcnt) = parag

                        Next

                        Invalidate()
                    End If

                Else
                    If SpellCheker.isloading = False Then
                        InitializSpeller(HocrPage.PageOCRsettings.Language)
                    End If
                End If

            Catch ex As Exception

            End Try


        End If





    End Sub


    Public Async Sub SetEditorMode()
        SelectedHocrID = -1
        HocrSelected = False
        HocrHighlighted = False
        HighlightedHocrID = -1
        PreviouscontrolState = controlState.None
        State = controlState.None
        isBusy = True

        Me.Cursor = Cursors.WaitCursor
        Dim tsk = TaskEx.Run(
            Sub()
                If HocrPage IsNot Nothing Then

                    HotHocrObjects = New List(Of HocrObjEditor)
                    OCRblocks = New List(Of Rectangle)
                    Me.Invalidate()

                    Dim ParagraphIndex As Integer = 0
                    Dim LineIndex As Integer = 0
                    Dim WordIndex As Integer = 0

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

                                        HocrParEditor.ParagraphIndex = ParagraphIndex
                                        HocrParEditor.LineIndex = LineIndex
                                        HocrParEditor.WordIndex = WordIndex

                                        HocrParEditor.Spelled = True
                                        HocrParEditor.isUserText = False
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


                                        WordIndex += 1
                                    Next


                                    LineIndex += 1
                                Next


                                ParagraphIndex += 1
                            Next

                        Next

                        CheckSpeller()

                    ElseIf OCRsettings.EditMode = ocrEditMode.LineEdit Then


                        Dim areas = _HocrPage.AllocrCarea

                        For ar As Integer = 0 To areas.Count - 1

                            Dim Pars = areas(ar).AllocrParas
                            For pr As Integer = 0 To Pars.Count - 1
                                OCRblocks.Add(Pars(pr).bbox)
                                Dim lins = Pars(pr).AllocrLines

                                For ln As Integer = 0 To lins.Count - 1


                                    Dim HocrParEditor As New HocrObjEditor
                                    HocrParEditor.EditMode = ocrEditMode.LineEdit

                                    HocrParEditor.HocrObject = lins(ln)
                                    HocrParEditor.text = lins(ln).Text


                                    HocrParEditor.isDirty = False
                                    HocrParEditor.isLocked = False
                                    HocrParEditor.isinEdit = False

                                    HocrParEditor.ParagraphIndex = ParagraphIndex
                                    HocrParEditor.LineIndex = LineIndex



                                    HocrParEditor.Spelled = True
                                    HocrParEditor.isUserText = False
                                    HocrParEditor.alignment = Pars(pr).Alignment
                                    HocrParEditor.Font = Pars(pr).Font

                                    If lins(ln).txtbox.IsEmpty Then

                                        lins(ln).txtbox = lins(ln).bbox

                                        'correction is needed for bbox, due to font's internal inherent metrics, such as linespace,ascent and descent

                                        Using txtboxtest As New GraphicsPath

                                            Dim txtbox = lins(ln).txtbox

                                            txtboxtest.AddString(lins(ln).Text, Pars(pr).Font.FontFamily, 0, Pars(pr).Font.Size, New Point(0, 0), Pars(pr).StringFormat)

                                            Dim txtBound = txtboxtest.GetBounds

                                            txtbox.X -= txtBound.X
                                            txtbox.Y -= txtBound.Y

                                            lins(ln).txtbox = txtbox

                                        End Using



                                    End If


                                    HocrParEditor.bbox = lins(ln).txtbox

                                    If HotHocrObjects IsNot Nothing Then
                                        HotHocrObjects.Add(HocrParEditor)
                                    End If



                                    LineIndex += 1
                                Next


                                ParagraphIndex += 1
                            Next

                        Next

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

                                HocrParEditor.ParagraphIndex = ParagraphIndex

                                HocrParEditor.Spelled = True
                                HocrParEditor.Font = Pars(pr).Font
                                HocrParEditor.alignment = Pars(pr).Alignment
                                HocrParEditor.bbox = Pars(pr).bbox

                                If HotHocrObjects IsNot Nothing Then
                                    HotHocrObjects.Add(HocrParEditor)
                                End If

                                ParagraphIndex += 1
                            Next

                        Next

                    End If

                End If

            End Sub)




        Try


            Await tsk

            RaiseEvent OCRObjectSet(Me, Nothing)

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
        BoxRectangle = New Rectangle
        ResizeRecHighlighted = False
        ResizeRecType = -1
        MultiSelect = False
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




    Private Sub RecognizeImageArea()

        Try
            If ContextParaId >= 0 Then
                If HotHocrObjects IsNot Nothing Then
                    Dim pageSeg As New PageSegMode
                    If HotHocrObjects(ContextParaId).EditMode = ocrEditMode.WordEdit Then
                        pageSeg = PageSegMode.singleword
                    ElseIf HotHocrObjects(ContextParaId).EditMode = ocrEditMode.LineEdit Then
                        pageSeg = PageSegMode.singleline
                    ElseIf HotHocrObjects(ContextParaId).EditMode = ocrEditMode.ParagraphEdit Then
                        pageSeg = PageSegMode.column

                    End If


                    Dim Boxarg As New RecognizeAreaArg(HotHocrObjects(ContextParaId).bbox, FileName, ContextParaId, pageSeg)
                    RaiseEvent reRecognizeArea(Me, Boxarg)


                End If

            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub RemoveOCRObjects()

        If SelectedHocrID >= 0 AndAlso isBusy = False Then

            Dim ocrRmvArg As New RemoveOCRobjectArg(FileName, SelectedHocrID)

            RaiseEvent RemoveObjectEvent(Me, ocrRmvArg)
            GroupSelectionList.Clear()
            ResizeRecType = -1
            ResizeRecHighlighted = False
            State = controlState.None
            PreviouscontrolState = controlState.None
            BoxRectangle = Rectangle.Empty
            HocrSelected = False
            HocrHighlighted = False
            HighlightedHocrID = -1
            SelectedHocrID = -1
            Cursor = Cursors.Default
        End If


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
                ElseIf OCRsettings.EditMode = ocrEditMode.LineEdit Then

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

    Private Sub SetAsVarified()

        Try
            If ContextParaId >= 0 Then

                Dim HotParagraph = HotHocrObjects(ContextParaId)

                If HotParagraph.EditMode = ocrEditMode.ParagraphEdit OrElse
                   HotParagraph.EditMode = ocrEditMode.LineEdit Then

                    If LockContext.Checked = True Then

                        HotParagraph.isLocked = False

                    Else

                        HotParagraph.isLocked = True

                    End If

                Else
                    If HotParagraph.Spelled = False Then

                        Dim txt = HotParagraph.text.Trim(" ".ToArray)
                        txt = SpellCheker.NormalizeText(txt)
                        If txt.Length > 0 Then
                            Dim wrds = txt.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                            wrds = wrds.Where(Function(X) Not SpellCheker.UserWords.Contains(X)).ToArray

                            If wrds.Count > 0 Then
                                SpellCheker.UserWords = SpellCheker.UserWords.Union(wrds).ToArray
                                SpellCheker.Words = SpellCheker.Words.Union(wrds).ToArray
                                IO.File.AppendAllLines(SpellCheker._UserPath, wrds)
                                Dim ocrword As HocrWord = HotParagraph.HocrObject
                                ocrword.SpellChecked = True
                                HotParagraph.HocrObject = ocrword
                                HotParagraph.Spelled = True
                                HotParagraph.isUserText = True
                            End If

                        End If

                    Else
                        Dim txt = HotParagraph.text.Trim(" ")
                        txt = SpellCheker.NormalizeText(txt)
                        If SpellCheker.UserWords.Contains(txt) AndAlso Not String.IsNullOrEmpty(SpellCheker._UserPath) Then

                            Try

                                Dim Userwrds = SpellCheker.UserWords.ToList
                                Userwrds.Remove(txt)
                                SpellCheker.UserWords = Userwrds.ToArray
                                IO.File.WriteAllLines(SpellCheker._UserPath, SpellCheker.UserWords)
                                Userwrds = SpellCheker.Words.ToList
                                Userwrds.Remove(txt)
                                SpellCheker.Words = Userwrds.ToArray
                                HotParagraph.isUserText = False
                                HotParagraph.Spelled = False
                                Dim ocrword As HocrWord = HotParagraph.HocrObject
                                ocrword.SpellChecked = False
                                HotParagraph.HocrObject = ocrword

                            Catch ex As Exception

                            End Try

                        End If

                    End If




                End If


                HotHocrObjects(ContextParaId) = HotParagraph
                Invalidate()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ignoreWordSpell()

        Try
            If ContextParaId >= 0 Then

                Dim HotParagraph = HotHocrObjects(ContextParaId)

                If HotParagraph.Spelled = False Then

                    Dim txt = HotParagraph.text.Trim(" ".ToArray)

                    If txt.Length > 0 Then
                        Dim wrds = txt.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                        wrds = wrds.Where(Function(X) Not SpellCheker.Words.Contains(X)).ToArray

                        If wrds.Count > 0 Then

                            SpellCheker.Words = SpellCheker.Words.Union(wrds).ToArray

                        End If

                    End If
                End If


                Dim ocrword As HocrWord = HotParagraph.HocrObject
                ocrword.SpellChecked = True
                HotParagraph.HocrObject = ocrword
                HotParagraph.Spelled = True
                HotHocrObjects(ContextParaId) = HotParagraph
                Invalidate()
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


        If Freez = True Then

            EndBoxEdit()
            HighlightedHocrID = -1
            HocrHighlighted = False

        End If


        If Image Is Nothing OrElse isBusy = True OrElse HocrPage Is Nothing Then
            Exit Sub
        End If



        Dim pnt = ClientToImagePoint(e.Location)



        If e.Button = MouseButtons.Right Then

            If State = controlState.None OrElse
                State = controlState.HocrSelection Then

                CheckHighlightedObject(pnt)

                If HocrHighlighted = True Then

                    HocrSelected = True
                    SelectedHocrID = HighlightedHocrID
                    OnHocrBoxRightClick(e.Location)

                Else

                    OnControlRightClick(e.Location)

                End If



            ElseIf State = controlState.MultiHocrSelection Then




            ElseIf State = controlState.ObjectSelection Then


                MyBase.OnBoxRightClick(e)

            ElseIf State = controlState.DrawRectStart Then

                State = controlState.None
                Cursor = Cursors.Default

            ElseIf State = controlState.SelectionStart Then

                State = controlState.None
                Cursor = Cursors.Default

            End If


        ElseIf e.Button = MouseButtons.Left Then

            If (State = controlState.HocrSelection OrElse
                    State = controlState.ObjectSelection) AndAlso
                    ResizeRecHighlighted = True Then


                If State = controlState.HocrSelection Then

                    State = controlState.ResizeHocr

                Else

                    State = controlState.ResizeObject

                End If


            ElseIf State = controlState.DrawRectStart Then

                MultiSelect = False
                State = controlState.DrawRect
                BoxSelectionStPoint = pnt
                MousePostion = pnt

                BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)


            ElseIf State = controlState.SelectionStart Then

                MultiSelect = True
                State = controlState.DrawRect
                BoxSelectionStPoint = pnt
                MousePostion = pnt

                BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)

            ElseIf State = controlState.MoveStart Then

                MoveCurrentPosition = pnt
                State = controlState.MoveImage
                Cursor = Cursors.Hand
            Else


                ' Checks if current mouse pointer is above hocr object
                CheckHighlightedObject(pnt)

                If HocrHighlighted = True Then


                    If State = controlState.None Then

                        HocrSelected = True

                        SelectedHocrID = HighlightedHocrID

                        GroupSelectionList.Clear()
                        GroupSelectionList.Add(SelectedHocrID)

                        BoxRectangle = HotHocrObjects(SelectedHocrID).HocrObject.bbox
                        State = controlState.HocrSelection

                    ElseIf State = controlState.HocrSelection OrElse
                       State = controlState.MultiHocrSelection Then


                        HocrSelected = True
                        SelectedHocrID = HighlightedHocrID

                        If ModifierKeys = Keys.Control Then

                            If GroupSelectionList.Contains(SelectedHocrID) = False Then

                                GroupSelectionList.Add(SelectedHocrID)

                                State = controlState.MultiHocrSelection

                            End If

                        Else

                            GroupSelectionList.Clear()
                            GroupSelectionList.Add(SelectedHocrID)

                            BoxRectangle = HotHocrObjects(SelectedHocrID).HocrObject.bbox
                            State = controlState.HocrSelection




                        End If





                    ElseIf State = controlState.ObjectSelection Then

                        If ResizeRecHighlighted = False Then

                            State = controlState.None

                            EndRegionEdit()

                        End If


                    End If

                Else

                    GroupSelectionList.Clear()
                    HighlightedHocrID = -1

                    If State = controlState.ObjectSelection Then

                        If ResizeRecHighlighted = False Then

                            State = controlState.None

                            EndRegionEdit()

                        End If


                    Else

                        HocrSelected = False
                        SelectedHocrID = -1

                        State = controlState.None
                    End If



                End If


            End If



        End If


        If Me.Focused = False Then
            Me.Focus()
        End If

        Invalidate()

    End Sub




    ''' <summary>
    ''' Handels rightclick event on hocr object
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub OnHocrBoxRightClick(ByVal e As Point)

        GroupSelectionList.Clear()
        LockContext.Enabled = True

        If HotHocrObjects(HighlightedHocrID).EditMode = ocrEditMode.ParagraphEdit OrElse
           HotHocrObjects(HighlightedHocrID).EditMode = ocrEditMode.LineEdit Then

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
            IgnoreContext.Enabled = False
        Else

            If Not MenuStripHocrOptions.Items.Item(0).Enabled Then
                For Each stripi In MenuStripHocrOptions.Items
                    stripi.Enabled = True
                Next
            End If

            LockContext.Text = "Add to User Dictionary   "

            If HotHocrObjects(HighlightedHocrID).Spelled Then
                LockContext.Checked = True
                If HotHocrObjects(HighlightedHocrID).isUserText = True Then
                    LockContext.Text = "Remove From User Dictionary   "
                Else
                    LockContext.Enabled = False
                End If

            End If

        End If

        RecognizeArea.Enabled = True
        ContextParaId = HighlightedHocrID
        SelectedHocrID = HighlightedHocrID
        MenuStripHocrOptions.Show(Me.PointToScreen(e))
        State = controlState.None


    End Sub


    ''' <summary>
    ''' Handels Rightclick event on areas other than hocr object
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub OnControlRightClick(ByVal e As Point)

        HighlightedHocrID = -1
        GroupSelectionList.Clear()
        HocrSelected = False
        SelectedHocrID = -1

        RecognizeArea.Enabled = False
        MenuStripGeneralOptions.Show(Me.PointToScreen(e))
        State = controlState.None

    End Sub


    ' Set Check and Set User resized rectangular box
    Private Sub SetResizedBox()

        Dim Imagebound = New Rectangle(New Point(1, 1), New Size(Image.Width - 2, Image.Height - 2))

        BoxRectangle = Rectangle.Intersect(BoxRectangle, Imagebound)


        If BoxRectangle.IsEmpty = False Then

            Dim Highlightarg = New BoundingBoxArg(BoxRectangle, _HocrID:=SelectedHocrID)
            RaiseEvent BoxHighlightedEvent(Nothing, Highlightarg)

        Else

            State = controlState.None
            EndRegionEdit()
        End If



    End Sub


    '  Set User resized Hocr bounding box
    Private Sub SetResizedHocrBox()

        Dim HotHocr = HotHocrObjects(SelectedHocrID)
        HotHocr.bbox = BoxRectangle
        HotHocr.HocrObject.bbox = BoxRectangle

        Dim BlkREC As New Rectangle
        BlkREC = OCRblocks(HotHocr.ParagraphIndex)
        BlkREC = Rectangle.Union(BoxRectangle, BlkREC)
        OCRblocks(HotHocr.ParagraphIndex) = BlkREC

        If HotHocr.EditMode = ocrEditMode.LineEdit OrElse
                   HotHocr.EditMode = ocrEditMode.WordEdit Then

            ' HotHocr.HocrObject.txtbox = Rectangle.Empty

            'correction is needed for bbox, due to font's internal inherent metrics, such as linespace,ascent and descent
            Dim DifStringFormat As New StringFormat
            DifStringFormat.Alignment = StringAlignment.Near
            DifStringFormat.LineAlignment = StringAlignment.Near
            DifStringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.NoClip

            Using txtboxtest As New GraphicsPath

                Dim txtbox As Rectangle = HotHocr.HocrObject.bbox

                txtboxtest.AddString(HotHocr.text, HotHocr.Font.FontFamily, 0, HotHocr.Font.Size, New Point(0, 0), DifStringFormat)

                Dim txtBound = txtboxtest.GetBounds

                txtbox.X -= txtBound.X
                txtbox.Y -= txtBound.Y

                HotHocr.HocrObject.txtbox = txtbox

            End Using


            HotHocr.bbox = HotHocr.HocrObject.txtbox


            DifStringFormat.Dispose()
            DifStringFormat = Nothing
        End If

        HocrPage.AllocrCarea(HotHocr.HocrObject.AreaNum).
                 AllocrParas(HotHocr.HocrObject.ParNum).bbox = BlkREC

        HotHocrObjects(SelectedHocrID) = HotHocr



    End Sub


    Protected Overrides Sub OnPreviewKeyDown(ByVal e As PreviewKeyDownEventArgs)

        If Image Is Nothing OrElse HocrPage Is Nothing Then
            Exit Sub
        End If


        If e.KeyCode = Keys.Escape Then
            State = controlState.None
            If Freez = True Then
                EndBoxEdit()
                HocrSelected = False
                SelectedHocrID = -1
                HocrHighlighted = False
                HighlightedHocrID = -1
                PreviouscontrolState = controlState.None
                ResizeRecHighlighted = False
                ResizeRecType = -1
                GroupSelectionList.Clear()
                Freez = False
                Invalidate()
            End If
        End If



    End Sub

    Friend Sub DeleteObjectCall()

        If HocrSelected = True Then
            If (Freez = False) AndAlso SelectedHocrID >= 0 Then
                RemoveOCRObjects()

            End If

        End If

    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If Image Is Nothing Then
            Exit Sub
        End If




        If isBusy Then

            e.SuppressKeyPress = True

        Else

            If Me.ClientRectangle.
                    Contains(Me.PointToClient(Control.MousePosition)) Then

                If State = controlState.None Then


                    If e.Modifiers = Keys.Control Then

                        State = controlState.DrawRectStart
                        Cursor = Cursors.Cross
                    End If

                ElseIf State = controlState.HocrSelection Then

                    If e.KeyCode = Keys.Delete Then

                        DeleteObjectCall()

                    End If

                End If


            End If





        End If



    End Sub
    Protected Overrides Sub OnKeyUp(ByVal e As KeyEventArgs)

        If Image Is Nothing Then
            Exit Sub
        End If

        If e.KeyCode = Keys.ControlKey AndAlso State = controlState.None Then
            Cursor = Cursors.Default
        End If


    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)

        If Image Is Nothing OrElse Freez = True Then
            Exit Sub
        End If



        MyBase.OnMouseUp(e)

        If State = controlState.DrawRect Then

            State = controlState.None
            Cursor = Cursors.Arrow
            PreviouscontrolState = controlState.None
            ResizeRecType = -1
            ResizeRecHighlighted = False


            Dim pnt = ClientToImagePoint(e.Location)
            BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, pnt)

            Dim Imagebound = New Rectangle(New Point(1, 1), New Size(Image.Width - 2, Image.Height - 2))

            BoxRectangle = Rectangle.Intersect(BoxRectangle, Imagebound)


            If BoxRectangle.IsEmpty = False AndAlso
               (BoxRectangle.Width * BoxRectangle.Height) > 10 Then

                If MultiSelect = True Then

                    Dim FullIntersectionOnly As Boolean = False

                    If BoxSelectionStPoint.Y > pnt.Y Then
                        FullIntersectionOnly = True
                    End If

                    SetMultiSelect(BoxRectangle, FullIntersectionOnly)


                Else

                    State = controlState.ObjectSelection

                    Dim Highlightarg = New BoundingBoxArg(BoxRectangle)
                    RaiseEvent BoxHighlightedEvent(Nothing, Highlightarg)


                End If

            Else
                BoxRectangle = Rectangle.Empty
                MultiSelect = False
            End If



        ElseIf State = controlState.HocrSelection OrElse
              State = controlState.ObjectSelection Then


            If BoxRectangle.IsEmpty = False Then

                SetResizedBox()

            Else
                State = controlState.None
                EndRegionEdit()
            End If


        ElseIf (State = controlState.ResizeHocr) Then

            SetResizedBox()

            SetResizedHocrBox()

            State = controlState.HocrSelection

        ElseIf (State = controlState.ResizeObject) Then

            State = controlState.ObjectSelection
            SetResizedBox()

        ElseIf State = controlState.MoveImage Then
            ' imageTomove.Dispose()
            '  imageTomove = Nothing
            'MoveInitPosition = New Point
            ' State = controlState.None
            'Cursor = Cursors.Default
            'EndRegionEdit()
        End If

        Invalidate()

    End Sub


    Private Sub SetMultiSelect(ByVal box As Rectangle, ByVal FullIntersectionOnly As Boolean)


        BoxRectangle = Rectangle.Empty
        GroupSelectionList.Clear()

        HocrSelected = False
        MultiSelect = False
        SelectedHocrID = -1



        For obj As Integer = 0 To HotHocrObjects.Count - 1

            Try

                If FullIntersectionOnly = True Then

                    If box.Contains(HotHocrObjects(obj).HocrObject.bbox) Then

                        GroupSelectionList.Add(obj)

                    End If

                Else

                    If box.IntersectsWith(HotHocrObjects(obj).HocrObject.bbox) Then

                        GroupSelectionList.Add(obj)

                    End If

                End If

            Catch ex As Exception

            End Try




        Next

        If GroupSelectionList.Count = 1 Then
            HocrSelected = True

            HighlightedHocrID = GroupSelectionList.First
            SelectedHocrID = HighlightedHocrID

            BoxRectangle = HotHocrObjects(SelectedHocrID).HocrObject.bbox
            State = controlState.HocrSelection

        ElseIf GroupSelectionList.Count > 1 Then

            HocrSelected = True

            State = controlState.MultiHocrSelection

            SelectedHocrID = GroupSelectionList.Last
            HighlightedHocrID = SelectedHocrID

        End If




    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)

        MyBase.OnMouseEnter(e)

    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)




        If (Image Is Nothing) OrElse (HocrPage Is Nothing) Then
            Exit Sub
        End If



        If isBusy = False Then

            MousePostion = ClientToImagePoint(e.Location)


            CheckHighlightedObject(MousePostion)


            If State = controlState.None Then

                If (Control.MouseButtons = MouseButtons.Left) Then
                    PreviouscontrolState = controlState.None
                    _controlState = controlState.Drag

                    InitPanPosition = e.Location
                    InitPanCenter = ImageCenter

                End If



            ElseIf State = controlState.HocrSelection OrElse
                   State = controlState.ObjectSelection Then

                HocrHighlighted = False
                HighlightedHocrID = -1

                Me.OnBoxMouseMove(e)

            ElseIf State = controlState.ResizeHocr OrElse
                   State = controlState.ResizeObject Then

                HocrHighlighted = False
                HighlightedHocrID = -1


                Me.OnBoxMouseMove(e)

            ElseIf State = controlState.Drag Then

                HocrHighlighted = False
                HighlightedHocrID = -1

                If Cursor <> Cursors.SizeAll Then
                    Cursor = Cursors.SizeAll
                End If

                Dim delta = New PointF(InitPanPosition.X - e.X, InitPanPosition.Y - e.Y)

                ImageCenter.X = InitPanCenter.X + (delta.X / _zoom)
                ImageCenter.Y = InitPanCenter.Y + (delta.Y / _zoom)

            ElseIf State = controlState.DrawRect Then

                HocrHighlighted = False
                HighlightedHocrID = -1

                MousePostion = ClientToImagePoint(e.Location)

                BoxRectangle = MathHelp.GetBoundingRectangle(BoxSelectionStPoint, MousePostion)

            ElseIf state = controlState.MoveImage Then

                Me.OnImageMove(e)

            End If



            Invalidate()

        End If




    End Sub



    ''' <summary>
    ''' Check if the mouse is over a paragraph
    ''' </summary>
    ''' <param name="pnt">Mouse Location</param>
    Private Function CheckHighlightedObject(ByVal pnt As Point) As Boolean

        Dim PrevObjectHighlighted = HocrHighlighted
        Dim PrevHighlightedHocrID = HighlightedHocrID


        PageHighlighted = False
        HocrHighlighted = False

        SkipRefresh = False

        PageHighlightedID = -1
        HighlightedHocrID = -1


        If HocrPage.bbox.Contains(pnt) Then

            PageHighlighted = True
            isParagraphHighlighted(pnt)

            If HocrHighlighted Then

                If (PrevHighlightedHocrID = HighlightedHocrID) Then
                    ' chek if this object is the same as the previouse highlited object
                    ' avoids unecessary invalidation during mouse move event  
                    SkipRefresh = True
                End If

            End If


        End If


        Return HocrHighlighted OrElse PrevObjectHighlighted

    End Function


    Protected Overrides Sub OnMouseDoubleClick(ByVal e As MouseEventArgs)

        If Image Is Nothing Then
            Exit Sub
        End If

        MyBase.OnMouseDoubleClick(e)

        HocrSelected = False

        If Freez = False Then
            SetEditBox()
        End If

    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)

        If Image Is Nothing Then
            Exit Sub
        End If

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


        If Image Is Nothing Then
            Exit Sub
        End If


        If HocrPage IsNot Nothing Then


            If OCRsettings.ResetBackground Then

                Dim delatx = (ClientSize.Width / 2.0F) - (ImageCenter.X * _zoom)
                Dim deltay = (ClientSize.Height / 2.0F) - (ImageCenter.Y * _zoom)


                Dim MatrTrns As New Matrix()
                MatrTrns.Translate(delatx, deltay)
                MatrTrns.Scale(_zoom, _zoom)


                e.Graphics.Transform = MatrTrns

                e.Graphics.FillRectangle(Brushes.White, HocrPage.bbox)

            Else

                MyBase.OnPaint(e)

            End If


            OnHocrPaint(e)

        End If










    End Sub

    Private Sub OnHocrPaint(ByVal e As PaintEventArgs)

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.TextContrast = 4




        Dim DifStringFormat As New StringFormat
        DifStringFormat.Alignment = StringAlignment.Near
        DifStringFormat.LineAlignment = StringAlignment.Near
        DifStringFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.NoClip

        Dim penselected = New Pen(Color.LimeGreen, 2 / _zoom)
        Dim penHighlit = New Pen(Color.Red, 2 / _zoom)

        Dim userSpellBrush As New Pen(OCRsettings.UserSpelledColor, 1)
        Dim errorBrush As New Pen(OCRsettings.SpellErrorColor, 1)

        For pr As Integer = 0 To OCRblocks.Count - 1 Step 1

            e.Graphics.FillRectangle(Brushes.White, OCRblocks(pr))

        Next

        Dim pathGr As New GraphicsPath

        For pr As Integer = 0 To HotHocrObjects.Count - 1 Step 1

            If HotHocrObjects(pr).isinEdit = False Then


                Dim parag = HotHocrObjects(pr)

                ' If Not String.IsNullOrWhiteSpace(parag.text) Then
                ' e.Graphics.FillRectangle(Brushes.White, parag.HocrObject.bbox)
                'End If

                If HotHocrObjects(pr).Spelled = True Then
                    If HotHocrObjects(pr).isUserText Then

                        e.Graphics.DrawString(parag.text, HotHocrObjects(pr).Font, userSpellBrush.Brush, parag.bbox.Location, DifStringFormat)
                    Else
                        e.Graphics.DrawString(parag.text, HotHocrObjects(pr).Font, Brushes.Black, parag.bbox.Location, DifStringFormat)
                    End If


                Else

                    e.Graphics.DrawString(parag.text, HotHocrObjects(pr).Font, errorBrush.Brush, parag.bbox.Location, DifStringFormat)
                End If

                If (pr = HighlightedHocrID) Then

                    e.Graphics.DrawRectangle(penHighlit, parag.HocrObject.bbox)

                End If

                If (pr = SelectedHocrID OrElse GroupSelectionList.Contains(pr)) Then
                    e.Graphics.DrawRectangle(penselected, parag.HocrObject.bbox)
                End If


            End If


        Next


        If (State = controlState.DrawRect) OrElse
            (State = controlState.HocrSelection) OrElse
              (State = controlState.ObjectSelection) OrElse
               (State = controlState.ResizeHocr) OrElse
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
                HocrActive = False
                ResetAllState()
                RaiseEvent OCRObjectSet(Me, Nothing)
                Exit Property
            End If

            State = controlState.None
            PreviouscontrolState = controlState.None



            ContextParaId = -1

            MultiSelect = False

            HocrHighlighted = False
            HocrSelected = False
            ResizeRecHighlighted = False

            ResizeRecType = -1
            HighlightedHocrID = -1
            SelectedHocrID = -1


            _HocrPage = value

            HocrActive = True

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
    Friend Property SelectedHocrID As Integer

        Set(value As Integer)
            _selectedhocrID = value

            If _selectedhocrID < 0 Then

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

            MousePostion = ClientToImagePoint(Me.PointToClient(Control.MousePosition))
            CheckHighlightedObject(MousePostion)

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
                    SetEditerFont(HotParagraph.bbox)

                    EditorTextBox.Visible = True
                    EditorTextBox.BringToFront()
                    EditorTextBox.Refresh()

                    EditorTextBox.Focus()

                    State = controlState.None
                    EndRegionEdit()

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

                    If OCRsettings.EditMode = ocrEditMode.LineEdit OrElse
                        OCRsettings.EditMode = ocrEditMode.WordEdit Then
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
    ''' Ends user bound area selection and edit
    ''' </summary>
    Public Sub EndRegionEdit()

        If imageTomove IsNot Nothing Then
            imageTomove.Dispose()
            imageTomove = Nothing
        End If

        MoveCurrentPosition = New Point
        MoveInitPosition = New Point


        ResizeRecType = -1
        ResizeRecHighlighted = False
        State = controlState.None
        PreviouscontrolState = controlState.None
        BoxRectangle = Rectangle.Empty
        Cursor = Cursors.Default
        Dim Boxarg As New BoundingBoxArg(BoxRectangle)
        RaiseEvent BoxHighlightedEvent(Nothing, Boxarg)


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

            ApplyBoxEdit(HighlightedHocrID, EditorTextBox.Text, EditConfirmation)

            EditorTextBox.Visible = False
            EditorTextBox = Nothing
            HighlightedHocrID = -1
            Invalidate()
        End If

        Freez = False

    End Sub

    Friend Sub ApplyBoxEdit(ByVal HocrID As Integer, ByVal text As String, ByVal confirm As Boolean)
        HighlightedHocrID = HocrID
        Dim HotParagraph = HotHocrObjects(HighlightedHocrID)
        If confirm = True Then
            HotParagraph.text = text
            If HotParagraph.text = HotParagraph.HocrObject.Text Then
                HotParagraph.isDirty = False
            Else
                HotParagraph.isDirty = True
            End If


        End If

        If HotParagraph.isDirty = True Then
            If HotParagraph.EditMode = ocrEditMode.WordEdit Then

                Dim wordHocr As HocrWord = HotParagraph.HocrObject
                wordHocr.Text = HotParagraph.text

                _HocrPage.AllocrCarea(wordHocr.areaNum).AllocrParas(wordHocr.ParNum) _
                .AllocrLines(wordHocr.lineNum).AllocrWords(wordHocr.WordNum) = wordHocr


                RaiseEvent HocrEdited(ocrEditMode.WordEdit, Nothing)

            ElseIf HotParagraph.EditMode = ocrEditMode.LineEdit Then

                Dim ParHocr As HocrLine = HotParagraph.HocrObject
                ParHocr.Text = HotParagraph.text
                _HocrPage.AllocrCarea(ParHocr.areaNum).
                          AllocrParas(ParHocr.ParNum).
                          AllocrLines(ParHocr.LineNum) = ParHocr

                RaiseEvent HocrEdited(ocrEditMode.LineEdit, Nothing)

            ElseIf HotParagraph.EditMode = ocrEditMode.ParagraphEdit Then

                Dim ParHocr As HocrPar = HotParagraph.HocrObject
                ParHocr.Text = HotParagraph.text
                _HocrPage.AllocrCarea(ParHocr.AreaNum).AllocrParas(ParHocr.ParNum) = ParHocr

                RaiseEvent HocrEdited(ocrEditMode.ParagraphEdit, Nothing)

            End If
        End If

        If OCRsettings.EditMode = ocrEditMode.WordEdit Then
            HotParagraph.Spelled = SpellCheker.isValidWord(HotParagraph.text)
            HotParagraph.isUserText = False

            If SpellCheker.UserWords.Count > 0 AndAlso HotParagraph.Spelled = True Then
                Dim txt = HotParagraph.text.Trim(" ")
                txt = SpellCheker.NormalizeText(txt)
                If SpellCheker.UserWords.Contains(txt) Then
                    HotParagraph.isUserText = True
                End If

            End If

        End If

        HotParagraph.isinEdit = False
        HotHocrObjects(HighlightedHocrID) = HotParagraph

        HighlightedHocrID = -1
    End Sub

    ''' <summary>
    ''' Set the font size of editor textbox based on the current zoom level  
    ''' </summary>
    Private Sub SetEditerFont(ByVal bbox As Rectangle)




        Dim x_size As Single = EditorTextBox.Font.Size * ((EditorTextBox.ClientSize.Height * 0.9) / bbox.Height)

        Dim fn = New Font(OCRsettings.ocrFont.FontFamily, x_size, FontStyle.Regular, GraphicsUnit.Pixel)

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

    Private Sub SetLineEditMode(ByVal sender As Object, ByVal e As EventArgs)
        If isBusy = False Then
            OCRsettings.EditMode = ocrEditMode.LineEdit
            RaiseEvent EditModeChanged(Me, Nothing)
        End If

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'HocrEditControl
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.Name = "HocrEditControl"
        Me.ResumeLayout(False)

    End Sub
End Class



