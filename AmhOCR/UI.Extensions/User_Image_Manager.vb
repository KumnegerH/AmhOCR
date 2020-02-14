Imports System.IO
Imports Ag = AForge.Imaging

Partial Class MainWindow

    'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2020 GPLv3

    Private UndoImageList As List(Of Image)
    Private UndoType As List(Of UndoType)
    Private UndoRotationData As List(Of Double)
    Private RedoRotationData As List(Of Double)
    Private RedoImageList As List(Of Image)
    Private RedoType As List(Of UndoType)

    ''' <summary>
    ''' Clear image from a box area drawn by user 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearImageArea(ByVal sender As Object, ByVal e As EventArgs)

        isProjectDirty = True
        Dim hocrPg = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName)

        Dim SaveName = hocrPg.imgCopyName



        Dim imgOp As Bitmap

        imgOp = New Bitmap(EditorPicBox.Image)
        UndoImageList.Add(Ag.Image.Clone(imgOp))
        btnUndo.Enabled = True
        UndoType.Add(AmhOCR.UndoType.AreaSetting)
        btnSaveImage.Enabled = True

        RedoType = New List(Of UndoType)
        btnRedo.Enabled = False
        RedoImageList = New List(Of Image)
        RedoRotationData = New List(Of Double)

        If sender.GetType.Name = "ImageEditControl" Then


            EditorPicBox.ClearBoxArea(EditorPicBox.drawingObject.BoundingBox)
            imgOp = New Bitmap(EditorPicBox.Image)
            EditorPicBox.Invalidate()

        Else

            HocrPicBox.ClearBoxArea(HocrPicBox.drawingObject.BoundingBox)
            imgOp = New Bitmap(HocrPicBox.Image)
            EditorPicBox._image = imgOp.Clone

            HocrPicBox.Invalidate()
            EditorPicBox.Invalidate()
        End If


        imgOp.Save(SaveName)
        imgOp.Dispose()
        imgOp = Nothing

    End Sub



    ''' <summary>
    ''' Crop image's box area drawn by user
    ''' </summary>
    ''' <param name="bound">A rectangular box darwn by user</param>
    Private Async Sub CropImage(ByVal bound As Rectangle)



        If isRecognizOpen = False AndAlso isBusy = False Then
            Try

                isBusy = True

                If (bound.Width * bound.Height) > 0 Then
                    Cursor = Cursors.WaitCursor
                    Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName
                    isProjectDirty = True


                    Dim imgOp = Ag.Image.Clone(EditorPicBox.Image)
                    UndoImageList.Add(Ag.Image.Clone(imgOp))
                    btnUndo.Enabled = True
                    UndoType.Add(AmhOCR.UndoType.Crop)
                    RedoType = New List(Of UndoType)

                    btnRedo.Enabled = False
                    RedoImageList = New List(Of Image)
                    RedoRotationData = New List(Of Double)

                    btnSaveImage.Enabled = True
                    Dim tsk = TaskEx.Run(
                        Sub()

                            PreProcessor.CropImage(imgOp, bound)


                        End Sub)


                    Await tsk

                    EditorPicBox.ClearImage()
                    EditorPicBox.PasteImage(imgOp, bound)

                    imgOp = EditorPicBox._image.Clone
                    imgOp.Save(SaveName)

                    imgOp.Dispose()
                    imgOp = Nothing
                    EditorPicBox.Invalidate()
                    UserSettings.SourceImagaChenged = True
                    isBusy = False
                    Cursor = Cursors.Default
                Else

                    MsgBox("image area Not Selected. Please hold CTRL And select image area to crop.")
                    isBusy = False
                End If

            Catch ex As Exception
                Cursor = Cursors.Default
                isBusy = False
            End Try

        Else
            MsgBox("Can't crop recognized Image. please reset image first")
        End If

        EditorPicBox.EndRegionEdit()

    End Sub

    ''' <summary>
    ''' Search for page boundary from image and mark with quadrilateral polygon
    ''' </summary>
    Private Sub SetGetPageBoundary()


        EditorPicBox.ZoomReset()

        EditorPicBox.drawingObject = New DrawingObject

        Dim img As Bitmap = EditorPicBox.Image.Clone

        Dim edgpts = PreProcessor.GetPageBoundary(img)
        Dim pts = MathHelp.IntPointToPoint_Array(edgpts)

        EditorPicBox.drawingObject.BoundingBox = MathHelp.PointsBound(edgpts)
        EditorPicBox.drawingObject.Points = pts.ToList

        EditorPicBox.drawingObject.type = DrawingType.Quadrilateral
        EditorPicBox.State = controlState.ObjectSelection

        img.Dispose()
        img = Nothing

        EditorPicBox.Invalidate()


    End Sub


    ''' <summary>
    ''' Save image to undo list before new edit
    ''' </summary>
    Private Sub SaveUndoPosition()


        Using imgOp = Ag.Image.Clone(EditorPicBox.Image)

            UndoImageList.Add(Ag.Image.Clone(imgOp))
            btnUndo.Enabled = True
            UndoType.Add(AmhOCR.UndoType.Crop)
            RedoType = New List(Of UndoType)

            btnRedo.Enabled = False
            RedoImageList = New List(Of Image)
            RedoRotationData = New List(Of Double)
            btnSaveImage.Enabled = True

        End Using



    End Sub

    ''' <summary>
    ''' Crop quadrilateral image and performe perspective transform 
    ''' </summary>
    Private Sub Crop_and_GetPageBoundary()

        EditorPicBox.Freez = True
        EditorPicBox.ZoomReset()

        SaveUndoPosition()


        Dim pts = MathHelp.PointToIntPoint_Array(EditorPicBox.drawingObject.Points)
        Dim Img As Bitmap = EditorPicBox.Image.Clone



        Dim imgCroped = PreProcessor.CropPageBoundary(Img, EditorPicBox.drawingObject.Points)

        If UserSettings.AnimateCroping = True Then

            AnimateCroping(pts, imgCroped.Clone)
        Else
            isBusy = False
            EditorPicBox.Freez = False
            EditorPicBox.EndRegionEdit()
            EditorPicBox.Image = imgCroped.Clone

            EditorPicBox.Invalidate()

        End If

        imgCroped.Dispose()
        imgCroped = Nothing

        Img.Dispose()
        Img = Nothing


    End Sub


    ''' <summary>
    ''' Animate image croping and perspective transform
    ''' </summary>
    ''' <param name="pts">Corner points of a quadrilateral polygon</param>
    ''' <param name="imgCroped"><Image to be croped/param>
    Private Async Sub AnimateCroping(ByVal pts As List(Of AForge.IntPoint), ByVal imgCroped As Bitmap)


        Dim Img As Bitmap = EditorPicBox.Image.Clone

        Dim BoundaryStart = EditorPicBox.drawingObject.BoundingBox

        Dim CenterPt As New PointF
        CenterPt.X += BoundaryStart.X + (BoundaryStart.Width / 2.0F)
        CenterPt.Y += BoundaryStart.Y + (BoundaryStart.Height / 2.0F)


        BoundaryStart.Width = imgCroped.Width
        BoundaryStart.Height = imgCroped.Height

        BoundaryStart.X = CenterPt.X - (BoundaryStart.Width / 2)
        BoundaryStart.Y = CenterPt.Y - (BoundaryStart.Height / 2)

        If BoundaryStart.X < 0 Then

            BoundaryStart.X = 0

        End If

        If BoundaryStart.Y < 0 Then

            BoundaryStart.Y = 0

        End If

        If BoundaryStart.Right > Img.Width Then

            BoundaryStart.X = Img.Width - BoundaryStart.Width

        End If

        If BoundaryStart.Bottom > Img.Height Then

            BoundaryStart.Y = Img.Height - BoundaryStart.Height

        End If


        EditorPicBox.InitPanPosition = EditorPicBox.ImagePointToClient(CenterPt)

        CenterPt = New PointF(Img.Width / 2.0F, Img.Height / 2.0F)

        EditorPicBox.InitPanCenter = CenterPt

        Dim DxPoi = EditorPicBox.ImagePointToClient(CenterPt)

        DxPoi.X -= EditorPicBox.InitPanPosition.X
        DxPoi.Y -= EditorPicBox.InitPanPosition.Y

        DxPoi.X /= 4
        DxPoi.Y /= 4


        Dim LeftCroperDf As Single = BoundaryStart.X / 4

        Dim RightCroperDf As Single = (Img.Width - BoundaryStart.Right) / 4

        Dim TopCroperDf As Single = BoundaryStart.Y / 4

        Dim BottomCroperDf As Single = (Img.Height - BoundaryStart.Bottom) / 4


        Dim LeftCroperRec As New RectangleF
        Dim RightCroperRec As New RectangleF


        Dim TopCroperRec As New RectangleF
        Dim BottomCroperRec As New RectangleF


        Dim ImageTrans As New Bitmap(Img.Width, Img.Height, Img.PixelFormat)
        ImageTrans = ImageUtils.CloneImageForGraphics(ImageTrans)

        Dim _zoom = EditorPicBox._zoom

        Dim _zoomDf As Double = (EditorPicBox.ClientSize.Height) / imgCroped.Height
        _zoomDf = (_zoomDf - _zoom) / 4


        Dim P1Df As New Point
        Dim P2Df As New Point
        Dim P3Df As New Point
        Dim P4Df As New Point

        P1Df.X = (BoundaryStart.X - pts(0).X) / 4
        P1Df.Y = (BoundaryStart.Y - pts(0).Y) / 4

        P2Df.X = (BoundaryStart.Right - pts(1).X) / 4
        P2Df.Y = (BoundaryStart.Y - pts(1).Y) / 4

        P3Df.X = (BoundaryStart.Right - pts(2).X) / 4
        P3Df.Y = (BoundaryStart.Bottom - pts(2).Y) / 4

        P4Df.X = (BoundaryStart.X - pts(3).X) / 4
        P4Df.Y = (BoundaryStart.Bottom - pts(3).Y) / 4





        For stp As Integer = 1 To 4

            Dim pt = pts(0)
            pt.X += P1Df.X
            pt.Y += P1Df.Y
            pts(0) = pt

            pt = pts(1)
            pt.X += P2Df.X
            pt.Y += P2Df.Y
            pts(1) = pt

            pt = pts(2)
            pt.X += P3Df.X
            pt.Y += P3Df.Y
            pts(2) = pt

            pt = pts(3)
            pt.X += P4Df.X
            pt.Y += P4Df.Y
            pts(3) = pt



            LeftCroperRec.Width = (LeftCroperDf * stp) + 1
            LeftCroperRec.Height = Img.Height
            LeftCroperRec.X = 0
            LeftCroperRec.Y = 0


            RightCroperRec.Width = (RightCroperDf * stp) + 1
            RightCroperRec.Height = Img.Height
            RightCroperRec.X = (Img.Width + 1) - RightCroperRec.Width
            RightCroperRec.Y = 0


            TopCroperRec.Width = Img.Width
            TopCroperRec.Height = (TopCroperDf * stp) + 1
            TopCroperRec.Y = 0
            TopCroperRec.X = 0

            BottomCroperRec.Width = Img.Width
            BottomCroperRec.Height = (BottomCroperDf * stp) + 1
            BottomCroperRec.Y = Img.Height - BottomCroperRec.Height
            BottomCroperRec.X = 0

            _zoom += _zoomDf

            EditorPicBox._zoom = _zoom

            Dim Delatex As New Point(stp * DxPoi.X, stp * DxPoi.Y)

            EditorPicBox.ImageCenter.X = EditorPicBox.InitPanCenter.X - (Delatex.X / _zoom)
            EditorPicBox.ImageCenter.Y = EditorPicBox.InitPanCenter.Y - (Delatex.Y / _zoom)

            Dim sdf As New AForge.Imaging.Filters.BackwardQuadrilateralTransformation()
            sdf.DestinationQuadrilateral = pts.ToList
            sdf.SourceImage = imgCroped.Clone
            Img = sdf.Apply(Img)

            Using Drawer As Bitmap = ImageTrans.Clone

                Using gr = Graphics.FromImage(Drawer)

                    gr.DrawImage(Img, New Point(0, 0))

                    gr.FillRectangle(Brushes.DimGray, LeftCroperRec)
                    gr.FillRectangle(Brushes.DimGray, RightCroperRec)
                    gr.FillRectangle(Brushes.DimGray, TopCroperRec)
                    gr.FillRectangle(Brushes.DimGray, BottomCroperRec)

                End Using

                EditorPicBox._image = Drawer.Clone

            End Using

            EditorPicBox.Invalidate()

            Await TaskEx.Delay(50)

        Next


        isBusy = False
        EditorPicBox.Freez = False
        EditorPicBox.EndRegionEdit()
        EditorPicBox.Image = imgCroped.Clone

        ImageTrans.Dispose()
        ImageTrans = Nothing

        imgCroped.Dispose()
        imgCroped = Nothing

        Img.Dispose()
        Img = Nothing

        EditorPicBox.Invalidate()


    End Sub



    ''' <summary>
    ''' correct skew angle of an image
    ''' </summary>
    Private Async Sub DeskewImage()


        If isRecognizOpen = False AndAlso isBusy = False Then



            Try
                Cursor = Cursors.WaitCursor
                isBusy = True
                isProjectDirty = True
                Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName

                Dim origImg = ImageUtils.SafeOpenImage(EditorPicBox.FileName)


                Dim imgOp = Ag.Image.Clone(EditorPicBox.Image)
                UndoImageList.Add(Ag.Image.Clone(imgOp))
                btnSaveImage.Enabled = True
                btnUndo.Enabled = True
                UndoType.Add(AmhOCR.UndoType.Rotate)
                Dim Angle = PreProcessor.skewAngle(imgOp.Clone)
                UndoRotationData.Add(Angle)

                RedoType = New List(Of UndoType)
                btnRedo.Enabled = False
                RedoImageList = New List(Of Image)
                RedoRotationData = New List(Of Double)


                Dim tsk = TaskEx.Run(Sub()
                                         PreProcessor.Rotate(imgOp, 0 - Angle)
                                         imgOp.Save(SaveName)


                                         PreProcessor.Rotate(origImg, 0 - Angle)
                                         origImg.Save(EditorPicBox.FileName)


                                     End Sub)


                Await tsk


                EditorPicBox._image = imgOp.Clone
                EditorPicBox._mainimage = origImg.Clone

                EditorPicBox.ImageAreas = New List(Of Rectangle)
                OCRTreeView.Nodes(0).Nodes.Clear()

                origImg.Dispose()
                origImg = Nothing

                imgOp.Dispose()
                imgOp = Nothing
                EditorPicBox.Invalidate()
                UserSettings.SourceImagaChenged = True
                btnResetRecog.Enabled = True
                isBusy = False
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                isBusy = False

            End Try

        Else
            MsgBox("Can't Rotate recognized Image. please reset image first")
        End If

    End Sub


    ''' <summary>
    ''' correct skew angle of an image box area selected by user
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="e"></param>
    Private Sub DeskewSelection(ByVal Sender As Object, ByVal e As EventArgs)

        isProjectDirty = True
        Dim Img As Bitmap
        Dim bbox As Rectangle

        isProjectDirty = True
        Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName

        Dim imgOp = ImageUtils.CloneImageForGraphics(EditorPicBox.Image)
        UndoImageList.Add(Ag.Image.Clone(imgOp))
        btnUndo.Enabled = True
        UndoType.Add(AmhOCR.UndoType.AreaSetting)
        btnSaveImage.Enabled = True

        RedoType = New List(Of UndoType)
        btnRedo.Enabled = False
        RedoImageList = New List(Of Image)
        RedoRotationData = New List(Of Double)

        If Sender.GetType.Name = "ImageEditControl" Then

            Img = EditorPicBox.CopyBoxImage(EditorPicBox.drawingObject.BoundingBox)
            bbox = EditorPicBox.drawingObject.BoundingBox

        Else

            Img = HocrPicBox.CopyBoxImage(HocrPicBox.drawingObject.BoundingBox)
            bbox = HocrPicBox.drawingObject.BoundingBox

        End If

        Img = PreProcessor.Deskew(Img, bbox)

        Dim srcRec As New Rectangle(0, 0, bbox.Width, bbox.Height)

        Using gr = Graphics.FromImage(imgOp)
            gr.DrawImage(Img, bbox, srcRec, GraphicsUnit.Pixel)
        End Using

        imgOp.Save(SaveName)
        imgOp.Dispose()
        imgOp = Nothing

        Using fImg = Ag.Image.FromFile(SaveName)

            EditorPicBox._image = fImg.Clone

            If Sender.GetType.Name <> "ImageEditControl" Then
                HocrPicBox._image = fImg.Clone
                HocrPicBox.Invalidate()
            End If

        End Using


        EditorPicBox.Invalidate()

        UserSettings.SourceImagaChenged = True
        btnResetRecog.Enabled = True


    End Sub


    ''' <summary>
    ''' Invert Color of an image box area selected by user
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub InvertImage(ByVal sender As Object, ByVal e As EventArgs)

        isProjectDirty = True
        Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName


        Dim imgOp As Bitmap

        imgOp = ImageUtils.CloneImageForGraphics(EditorPicBox.Image)
        UndoImageList.Add(Ag.Image.Clone(imgOp))
        btnUndo.Enabled = True
        UndoType.Add(AmhOCR.UndoType.AreaSetting)
        btnSaveImage.Enabled = True

        RedoType = New List(Of UndoType)
        btnRedo.Enabled = False
        RedoImageList = New List(Of Image)
        RedoRotationData = New List(Of Double)


        If sender.GetType.Name = "ImageEditControl" Then

            EditorPicBox.InvertBoxAreaColor(EditorPicBox.drawingObject.BoundingBox)
            imgOp = New Bitmap(EditorPicBox.Image)
            EditorPicBox.Invalidate()

        Else

            HocrPicBox.InvertBoxAreaColor(HocrPicBox.drawingObject.BoundingBox)
            imgOp = New Bitmap(HocrPicBox.Image)

            EditorPicBox._image = imgOp.Clone

            HocrPicBox.Invalidate()
            EditorPicBox.Invalidate()
        End If

        imgOp.Save(SaveName)
        imgOp.Dispose()
        imgOp = Nothing
    End Sub

    ''' <summary>
    ''' Set an initial postion of an image box area to be dragged by user
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StartImageMove(ByVal sender As Object, ByVal e As EventArgs)


        Dim imgOp As Bitmap

        If sender.GetType.Name = "ImageEditControl" Then

            imgOp = EditorPicBox.CopyBoxImage(EditorPicBox.drawingObject.BoundingBox)
            EditorPicBox.MoveInitPosition = EditorPicBox.drawingObject.BoundingBox.Location
            EditorPicBox.MoveCurrentPosition = EditorPicBox.MoveInitPosition

            EditorPicBox.imageTomove = imgOp.Clone
            EditorPicBox.State = controlState.MoveStart
            EditorPicBox.Invalidate()

        Else

            imgOp = HocrPicBox.CopyBoxImage(HocrPicBox.drawingObject.BoundingBox)
            HocrPicBox.MoveInitPosition = HocrPicBox.drawingObject.BoundingBox.Location
            EditorPicBox.MoveCurrentPosition = EditorPicBox.MoveInitPosition
            HocrPicBox.imageTomove = imgOp.Clone
            HocrPicBox.State = controlState.MoveStart
            HocrPicBox.Invalidate()
        End If


        imgOp.Dispose()
        imgOp = Nothing
    End Sub


    ''' <summary>
    ''' Shift croped image area to other postion in the same image 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ImageShift(ByVal sender As Object, ByVal e As EventArgs)

        isProjectDirty = True
        Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName


        Dim imgOp As Bitmap = EditorPicBox.Image.Clone
        UndoImageList.Add(Ag.Image.Clone(imgOp))
        btnUndo.Enabled = True
        UndoType.Add(AmhOCR.UndoType.AreaSetting)
        btnSaveImage.Enabled = True

        RedoType = New List(Of UndoType)
        btnRedo.Enabled = False
        RedoImageList = New List(Of Image)
        RedoRotationData = New List(Of Double)

        If sender.GetType.Name = "ImageEditControl" Then

            EditorPicBox.State = controlState.None
            EditorPicBox.ClearBoxArea(EditorPicBox.drawingObject.BoundingBox)
            Dim NewBox = New Rectangle(EditorPicBox.MoveInitPosition, EditorPicBox.drawingObject.BoundingBox.Size)

            EditorPicBox.PasteImage(EditorPicBox.imageTomove, NewBox)

            EditorPicBox.EndRegionEdit()
            imgOp = New Bitmap(EditorPicBox.Image)
            imgOp.Save(SaveName)

            EditorPicBox.Invalidate()

        Else

            HocrPicBox.State = controlState.None
            HocrPicBox.ClearBoxArea(HocrPicBox.drawingObject.BoundingBox)
            Dim NewBox = New Rectangle(HocrPicBox.MoveInitPosition, HocrPicBox.drawingObject.BoundingBox.Size)

            HocrPicBox.PasteImage(HocrPicBox.imageTomove, NewBox)

            HocrPicBox.EndRegionEdit()

            imgOp = New Bitmap(HocrPicBox.Image)
            imgOp.Save(SaveName)

            EditorPicBox._image = imgOp.Clone

            HocrPicBox.Invalidate()
            EditorPicBox.Invalidate()

            imgOp.Dispose()
            imgOp = Nothing

        End If



    End Sub


    ''' <summary>
    ''' Set image area to be as image only (not a text area) 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SetAsImageArea(ByVal sender As Object, ByVal e As EventArgs)

        isProjectDirty = True

        Dim HocrPg = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName)
        Dim pgIndex = HocrPages.IndexOf(HocrPg)




        If sender.GetType.Name = "ImageEditControl" Then

            If Not HocrPg.ImageBlocks.Contains(EditorPicBox.drawingObject.BoundingBox) Then
                HocrPg.ImageBlocks.Add(EditorPicBox.drawingObject.BoundingBox)
                EditorPicBox.ImageAreas = HocrPg.ImageBlocks.ToList
                'ClearImageArea(EditorPicBox, Nothing)
                EditorPicBox.Invalidate()

            End If

        Else

            If Not HocrPg.ImageBlocks.Contains(HocrPicBox.drawingObject.BoundingBox) Then

                HocrPg.ImageBlocks.Add(HocrPicBox.drawingObject.BoundingBox)
                HocrPicBox.ImageAreas = HocrPg.ImageBlocks.ToList
                ' ClearImageArea(HocrPicBox, Nothing)
                HocrPicBox.Invalidate()

            End If


        End If

    End Sub


    ''' <summary>
    ''' Rotate an image to the right or left
    ''' </summary>
    ''' <param name="direction">Direction of rotation</param>
    Private Async Sub RotateImage(ByVal direction As Boolean)


        If isRecognizOpen = False AndAlso isBusy = False Then

            Try
                isBusy = True
                Cursor = Cursors.WaitCursor
                isProjectDirty = True
                Dim SaveName = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName).imgCopyName

                Dim origImg = ImageUtils.SafeOpenImage(EditorPicBox.FileName)

                Dim imgOp = EditorPicBox.Image.Clone
                UndoImageList.Add(Ag.Image.Clone(imgOp))
                btnUndo.Enabled = True
                UndoType.Add(AmhOCR.UndoType.Rotate)
                btnSaveImage.Enabled = True

                RedoType = New List(Of UndoType)
                btnRedo.Enabled = False
                RedoImageList = New List(Of Image)
                RedoRotationData = New List(Of Double)


                Dim tsk As Task

                If direction = True Then


                    tsk = TaskEx.Run(
                        Sub()

                            PreProcessor.RotateRight(imgOp)
                            imgOp.Save(SaveName)

                            PreProcessor.RotateRight(origImg)
                            origImg.Save(EditorPicBox.FileName)

                            UndoRotationData.Add(-90)
                        End Sub)

                Else

                    tsk = TaskEx.Run(
                        Sub()

                            PreProcessor.RotateLeft(imgOp)
                            imgOp.Save(SaveName)

                            PreProcessor.RotateLeft(origImg)
                            origImg.Save(EditorPicBox.FileName)

                            UndoRotationData.Add(90)

                        End Sub)

                End If


                Await tsk

                EditorPicBox.DisposeImage()
                EditorPicBox.ResetAllState()
                EditorPicBox.Image = imgOp.Clone
                EditorPicBox.MainImage = origImg.Clone
                EditorPicBox.ImageAreas = New List(Of Rectangle)

                OCRTreeView.Nodes(0).Nodes.Clear()
                origImg.Dispose()
                origImg = Nothing

                imgOp.Dispose()
                imgOp = Nothing
                EditorPicBox.Invalidate()
                UserSettings.SourceImagaChenged = True
                Cursor = Cursors.Default
                isBusy = False
            Catch ex As Exception
                Cursor = Cursors.Default
                isBusy = False
            End Try

        Else
            MsgBox("Can't Rotate recognized Image. please reset image first")
        End If

    End Sub


    ''' <summary>
    ''' Set image correction parameters
    ''' </summary>
    Private Sub ImageSetting()


        If isRecognizOpen = False Then
            Dim hcrpag = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName)
            Dim SaveName = hcrpag.imgCopyName

            isBusy = True
            Dim Prpro As New ImageOCRsetting
            Prpro.Text += Path.GetFileName(EditorPicBox.FileName)
            Prpro.MyViewer = EditorPicBox
            UndoImageList.Add(Ag.Image.Clone(EditorPicBox.Image))
            UndoType.Add(AmhOCR.UndoType.ImageSetting)
            btnUndo.Enabled = True
            Prpro.InitializeImage(EditorPicBox.Image.Clone, hcrpag)
            btnSaveImage.Enabled = True

            RedoType = New List(Of UndoType)
            btnRedo.Enabled = False
            RedoImageList = New List(Of Image)
            RedoRotationData = New List(Of Double)

            AddHandler Prpro.FormClosed,
                    New FormClosedEventHandler(
                    Sub(s, e)
                        isBusy = False
                        ListOpenedImages.Items.Item(Prpro._MainHocrPage.PageNum).Selected = True

                        Dim imgOp = PreProcessor.ApplyCorrections(Prpro._MainImage)

                        EditorPicBox.Image = imgOp.Clone

                        imgOp.Save(SaveName)
                        imgOp.Dispose()
                        imgOp = Nothing
                        Prpro._MainImage.Dispose()
                        Prpro._MainImage = Nothing
                        EditorPicBox.Invalidate()
                    End Sub)


            Prpro.Show(Me)
            Prpro.Invalidate()


        Else
            MsgBox("Can't process recognized Image. please reset first")
        End If

    End Sub


    ''' <summary>
    ''' Save Image edit and clear undo/redo list
    ''' </summary>
    Private Sub SaveImageEdit()


        UndoRotationData = New List(Of Double)
        RedoRotationData = New List(Of Double)

        UndoType = New List(Of UndoType)
        RedoType = New List(Of UndoType)

        RedoImageList = New List(Of Image)

        If UndoImageList.Count > 1 Then
            UndoImageList.RemoveRange(1, UndoImageList.Count - 1)
            UndoType.Add(AmhOCR.UndoType.ImageSetting)
        End If


        btnSaveImage.Enabled = False

        btnUndo.Enabled = False
        btnRedo.Enabled = False

    End Sub

    ''' <summary>
    ''' Undo image editing
    ''' </summary>
    Private Sub UndoImageEdit()

        If UndoImageList.Count > 0 Then
            Dim img = New Bitmap(UndoImageList.Last)
            UndoImageList(UndoImageList.Count - 1) = EditorPicBox._image.Clone
            EditorPicBox._image = Ag.Image.Clone(img)
            EditorPicBox.Invalidate()

            If HocrPicBox.Image IsNot Nothing Then

                HocrPicBox._image = Ag.Image.Clone(img)
                HocrPicBox.Invalidate()

            End If

            img.Dispose()
            img = Nothing
            If UndoImageList.Count > 1 Then

                If UndoType(UndoType.Count - 1) = AmhOCR.UndoType.Rotate Then

                    RedoImageList.Add(UndoImageList(UndoImageList.Count - 1).Clone)

                    UndoImageList(UndoImageList.Count - 1).Dispose()
                    UndoImageList(UndoImageList.Count - 1) = Nothing
                    UndoImageList.RemoveAt(UndoImageList.Count - 1)

                    RedoType.Add(UndoType(UndoType.Count - 1))
                    UndoType.RemoveAt(UndoType.Count - 1)

                    If UndoRotationData.Count > 0 Then
                        Dim Angle = UndoRotationData.Last
                        Dim origImg = ImageUtils.SafeOpenImage(EditorPicBox.FileName)
                        If Math.Abs(Angle) = 90 Then
                            PreProcessor.RotateWithSize(origImg, Angle)
                        Else
                            PreProcessor.Rotate(origImg, Angle)
                        End If

                        origImg.Save(EditorPicBox.FileName)
                        UndoRotationData.RemoveAt(UndoRotationData.Count - 1)
                        RedoRotationData.Add(0 - Angle)

                        EditorPicBox._mainimage = origImg.Clone
                        EditorPicBox.ImageAreas = New List(Of Rectangle)
                        If HocrPicBox.Image IsNot Nothing Then
                            HocrPicBox._mainimage = origImg.Clone
                            HocrPicBox.Invalidate()
                            HocrPicBox.ImageAreas = New List(Of Rectangle)

                        End If

                        origImg.Dispose()
                        origImg = Nothing


                    End If

                Else

                    RedoImageList.Add(UndoImageList(UndoImageList.Count - 1).Clone)

                    UndoImageList(UndoImageList.Count - 1).Dispose()
                    UndoImageList(UndoImageList.Count - 1) = Nothing
                    UndoImageList.RemoveAt(UndoImageList.Count - 1)

                    RedoType.Add(UndoType(UndoType.Count - 1))
                    UndoType.RemoveAt(UndoType.Count - 1)

                End If




            End If


        End If

        If UndoImageList.Count > 1 Then
            btnUndo.Enabled = True
        Else
            btnUndo.Enabled = False
        End If

        If RedoImageList.Count > 0 Then
            btnRedo.Enabled = True
        Else
            btnRedo.Enabled = False
        End If

    End Sub

    ''' <summary>
    ''' Redo image Editing
    ''' </summary>
    Private Sub RedoImageEdit()



        If RedoImageList.Count > 0 Then
            Dim img = New Bitmap(RedoImageList.Last)
            RedoImageList(RedoImageList.Count - 1) = EditorPicBox._image.Clone
            EditorPicBox._image = Ag.Image.Clone(img)

            EditorPicBox.Invalidate()

            If HocrPicBox.Image IsNot Nothing Then
                HocrPicBox._image = Ag.Image.Clone(img)

                HocrPicBox.Invalidate()
            End If


            img.Dispose()
            img = Nothing


            If RedoType(RedoType.Count - 1) = AmhOCR.UndoType.Rotate Then

                UndoImageList.Add(RedoImageList(RedoImageList.Count - 1).Clone)

                RedoImageList(RedoImageList.Count - 1).Dispose()
                RedoImageList(RedoImageList.Count - 1) = Nothing
                RedoImageList.RemoveAt(RedoImageList.Count - 1)


                UndoType.Add(RedoType(RedoType.Count - 1))

                RedoType.RemoveAt(RedoType.Count - 1)




                If RedoRotationData.Count > 0 Then
                    Dim Angle = RedoRotationData.Last
                    Dim origImg = ImageUtils.SafeOpenImage(EditorPicBox.FileName)
                    If Math.Abs(Angle) = 90 Then
                        PreProcessor.RotateWithSize(origImg, Angle)
                    Else
                        PreProcessor.Rotate(origImg, Angle)
                    End If
                    origImg.Save(EditorPicBox.FileName)
                    RedoRotationData.RemoveAt(RedoRotationData.Count - 1)
                    UndoRotationData.Add(0 - Angle)

                    EditorPicBox._mainimage = origImg.Clone
                    EditorPicBox.ImageAreas = New List(Of Rectangle)
                    If HocrPicBox.Image IsNot Nothing Then
                        HocrPicBox._mainimage = origImg.Clone
                        HocrPicBox.Invalidate()
                        HocrPicBox.ImageAreas = New List(Of Rectangle)

                    End If

                    origImg.Dispose()
                    origImg = Nothing

                End If

            Else

                UndoImageList.Add(RedoImageList(RedoImageList.Count - 1).Clone)

                RedoImageList(RedoImageList.Count - 1).Dispose()
                RedoImageList(RedoImageList.Count - 1) = Nothing
                RedoImageList.RemoveAt(RedoImageList.Count - 1)


                UndoType.Add(RedoType(RedoType.Count - 1))

                RedoType.RemoveAt(RedoType.Count - 1)

            End If



        End If

        If UndoImageList.Count > 1 Then
            btnUndo.Enabled = True
        Else
            btnUndo.Enabled = False
        End If

        If RedoImageList.Count > 0 Then
            btnRedo.Enabled = True
        Else
            btnRedo.Enabled = False
        End If


    End Sub






End Class
