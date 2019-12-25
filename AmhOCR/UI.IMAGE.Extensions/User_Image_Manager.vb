Imports System.IO
Imports Ag = AForge.Imaging

Partial Class MainWindow

    Private UndoImageList As List(Of Image)
    Private UndoType As List(Of UndoType)
    Private UndoRotationData As List(Of Double)
    Private RedoRotationData As List(Of Double)
    Private RedoImageList As List(Of Image)
    Private RedoType As List(Of UndoType)


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


            EditorPicBox.ClearBoxArea(EditorPicBox.BoxRectangle)
            imgOp = New Bitmap(EditorPicBox.Image)
            EditorPicBox.Invalidate()

        Else

            HocrPicBox.ClearBoxArea(HocrPicBox.BoxRectangle)
            imgOp = New Bitmap(HocrPicBox.Image)
            EditorPicBox._image = imgOp.Clone

            HocrPicBox.Invalidate()
            EditorPicBox.Invalidate()
        End If


        imgOp.Save(SaveName)
        imgOp.Dispose()
        imgOp = Nothing

    End Sub


    Private Async Sub CropImage(ByVal bound As Rectangle)



        If isRecognizOpen = False Then
            Try



                If (bound.Width * bound.Height) > 0 Then

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
                    OCRsettings.SourceImagaChenged = True

                Else
                    MsgBox("image area Not Selected. Please hold CTRL And select image area to crop.")
                End If

            Catch ex As Exception

            End Try

        Else
            MsgBox("Can't crop recognized Image. please reset image first")
        End If

        EditorPicBox.EndRegionEdit()

    End Sub

    Private Async Sub DeskewImage()


        If isRecognizOpen = False Then



            Try
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
                OCRsettings.SourceImagaChenged = True
                btnResetRecog.Enabled = True
            Catch ex As Exception

            End Try

        Else
            MsgBox("Can't Rotate recognized Image. please reset image first")
        End If

    End Sub

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

            Img = EditorPicBox.CopyBoxImage(EditorPicBox.BoxRectangle)
            bbox = EditorPicBox.BoxRectangle

        Else

            Img = HocrPicBox.CopyBoxImage(HocrPicBox.BoxRectangle)
            bbox = HocrPicBox.BoxRectangle

        End If

        Img = PreProcessor.DeskewInplace(Img, bbox)

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

        OCRsettings.SourceImagaChenged = True
        btnResetRecog.Enabled = True


    End Sub

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

            EditorPicBox.InvertBoxAreaColor(EditorPicBox.BoxRectangle)
            imgOp = New Bitmap(EditorPicBox.Image)
            EditorPicBox.Invalidate()

        Else

            HocrPicBox.InvertBoxAreaColor(HocrPicBox.BoxRectangle)
            imgOp = New Bitmap(HocrPicBox.Image)

            EditorPicBox._image = imgOp.Clone

            HocrPicBox.Invalidate()
            EditorPicBox.Invalidate()
        End If

        imgOp.Save(SaveName)
        imgOp.Dispose()
        imgOp = Nothing
    End Sub


    Private Sub StartImageMove(ByVal sender As Object, ByVal e As EventArgs)


        Dim imgOp As Bitmap

        If sender.GetType.Name = "ImageEditControl" Then

            imgOp = EditorPicBox.CopyBoxImage(EditorPicBox.BoxRectangle)
            EditorPicBox.MoveInitPosition = EditorPicBox.BoxRectangle.Location
            EditorPicBox.MoveCurrentPosition = EditorPicBox.MoveInitPosition

            EditorPicBox.imageTomove = imgOp.Clone
            EditorPicBox.State = controlState.MoveStart
            EditorPicBox.Invalidate()

        Else

            imgOp = HocrPicBox.CopyBoxImage(HocrPicBox.BoxRectangle)
            HocrPicBox.MoveInitPosition = HocrPicBox.BoxRectangle.Location
            EditorPicBox.MoveCurrentPosition = EditorPicBox.MoveInitPosition
            HocrPicBox.imageTomove = imgOp.Clone
            HocrPicBox.State = controlState.MoveStart
            HocrPicBox.Invalidate()
        End If


        imgOp.Dispose()
        imgOp = Nothing
    End Sub

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
            EditorPicBox.ClearBoxArea(EditorPicBox.BoxRectangle)
            Dim NewBox = New Rectangle(EditorPicBox.MoveInitPosition, EditorPicBox.BoxRectangle.Size)

            EditorPicBox.PasteImage(EditorPicBox.imageTomove, NewBox)

            EditorPicBox.EndRegionEdit()
            imgOp = New Bitmap(EditorPicBox.Image)
            imgOp.Save(SaveName)

            EditorPicBox.Invalidate()

        Else

            HocrPicBox.State = controlState.None
            HocrPicBox.ClearBoxArea(HocrPicBox.BoxRectangle)
            Dim NewBox = New Rectangle(HocrPicBox.MoveInitPosition, HocrPicBox.BoxRectangle.Size)

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

    Private Sub SetAsImageArea(ByVal sender As Object, ByVal e As EventArgs)

        isProjectDirty = True

        Dim HocrPg = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName)
        Dim pgIndex = HocrPages.IndexOf(HocrPg)




        If sender.GetType.Name = "ImageEditControl" Then

            If Not HocrPg.ImageBlocks.Contains(EditorPicBox.BoxRectangle) Then
                HocrPg.ImageBlocks.Add(EditorPicBox.BoxRectangle)
                EditorPicBox.ImageAreas = HocrPg.ImageBlocks.ToList
                'ClearImageArea(EditorPicBox, Nothing)
                EditorPicBox.Invalidate()

            End If

        Else

            If Not HocrPg.ImageBlocks.Contains(HocrPicBox.BoxRectangle) Then

                HocrPg.ImageBlocks.Add(HocrPicBox.BoxRectangle)
                HocrPicBox.ImageAreas = HocrPg.ImageBlocks.ToList
                ' ClearImageArea(HocrPicBox, Nothing)
                HocrPicBox.Invalidate()

            End If


        End If

    End Sub

    Private Async Sub RotateImage(ByVal direction As Boolean)


        If isRecognizOpen = False Then

            Try


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
                OCRsettings.SourceImagaChenged = True

            Catch ex As Exception

            End Try

        Else
            MsgBox("Can't Rotate recognized Image. please reset image first")
        End If

    End Sub


    Private Sub ImageSetting()


        If isRecognizOpen = False Then
            Dim hcrpag = HocrPages.Single(Function(X) X.ImageName = EditorPicBox.FileName)
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

                        EditorPicBox.Image = PreProcessor.ApplyCorrections(Prpro._MainImage).Clone


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


    Private Sub btnSaveImage_Click(sender As Object, e As EventArgs) Handles btnSaveImage.Click

        SaveImageEdit()


    End Sub

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
