

Public Class MathHelp

    ''' <summary>
    ''' Check for intersection of a polylines with a rectangle
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="pts">Vertexes of the polylines</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As Rectangle, ByVal pts() As Point) As Boolean
        Dim no As Boolean = False

        For uiy As Integer = 1 To pts.Count - 1 Step 1
            Dim pt1 = pts(uiy - 1)
            Dim pt2 = pts(uiy)
            If isIntersect(Rect, pt1, pt2) Then
                no = True
                Exit For
            End If
        Next

        Return no
    End Function

    ''' <summary>
    ''' Check for intersection of a polylines with a rectangle
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="pts">Vertexes of the polylines</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As RectangleF, ByVal pts() As Point) As Boolean
        Dim no As Boolean = False

        For uiy As Integer = 1 To pts.Count - 1 Step 1
            Dim pt1 = pts(uiy - 1)
            Dim pt2 = pts(uiy)
            If isIntersect(Rect, pt1, pt2) Then
                no = True
                Exit For
            End If
        Next

        Return no
    End Function

    ''' <summary>
    ''' Check for intersection of a polylines with a rectangle
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="pts">Vertexes of the polylines</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As RectangleF, ByVal pts() As PointF) As Boolean
        Dim no As Boolean = False

        For uiy As Integer = 1 To pts.Count - 1 Step 1
            Dim pt1 = pts(uiy - 1)
            Dim pt2 = pts(uiy)
            If isIntersect(Rect, pt1, pt2) Then
                no = True
                Exit For
            End If
        Next

        Return no
    End Function

    ''' <summary>
    ''' Check for intersection of a polylines with a rectangle
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="pts">Vertexes of the polylines</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As Rectangle, ByVal pts As IEnumerable(Of Point)) As Boolean
        Dim no As Boolean = False

        For uiy As Integer = 1 To pts.Count - 1 Step 1
            Dim pt1 = pts(uiy - 1)
            Dim pt2 = pts(uiy)
            If isIntersect(Rect, pt1, pt2) Then
                no = True
                Exit For
            End If
        Next

        Return no
    End Function


    ''' <summary>
    ''' Check for intersection of a polylines with a rectangle
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="pts">Vertexes of the polylines</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As RectangleF, ByVal pts As IEnumerable(Of Point)) As Boolean
        Dim no As Boolean = False

        For uiy As Integer = 1 To pts.Count - 1 Step 1
            Dim pt1 = pts(uiy - 1)
            Dim pt2 = pts(uiy)

            If isIntersect(Rect, pt1, pt2) Then
                no = True
                Exit For
            End If
        Next

        Return no
    End Function

    ''' <summary>
    ''' Check for intersection of a polylines with a rectangle
    ''' </summary>
    ''' <param name="Rect"></param>
    ''' <param name="pts">Vertexes of the polylines</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As RectangleF, ByVal pts As IEnumerable(Of PointF)) As Boolean
        Dim no As Boolean = False

        For uiy As Integer = 1 To pts.Count - 1 Step 1
            Dim pt1 = pts(uiy - 1)
            Dim pt2 = pts(uiy)

            If isIntersect(Rect, pt1, pt2) Then
                no = True
                Exit For
            End If
        Next

        Return no
    End Function

    ''' <summary>
    ''' Convert Rectangle F to Rectangle
    ''' </summary>
    ''' <param name="RecF"></param>
    ''' <returns></returns>
    Public Shared Function RectangelFtoRectangel(ByVal RecF As RectangleF) As Rectangle
        Dim Rec As New Rectangle
        Rec.X = RecF.X
        Rec.Y = RecF.Y
        Rec.Width = RecF.Width
        Rec.Height = RecF.Height

        Return Rec

    End Function

    ''' <summary>
    ''' Check for intersection of a line with a rectangle
    ''' </summary>
    ''' <param name="Rect">The rectangle</param>
    ''' <param name="pt1">Point 1 of the line</param>
    ''' <param name="pt2">Point 2 of the line</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As RectangleF, ByVal pt1 As Point, ByVal pt2 As Point) As Boolean
        Dim no As Boolean = False

        Dim PTR1 = New Point(Rect.X, Rect.Top)
        Dim PTR2 = New Point(Rect.Right, Rect.Top)
        Dim PTR3 = New Point(Rect.Right, Rect.Bottom)
        Dim PTR4 = New Point(Rect.X, Rect.Bottom)
        Dim ua As Double = 0
        Dim ub As Double = 0
        Dim dem As Double = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

        If dem <> 0 Then
            ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
            ua /= dem

            ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
            ub /= dem
            If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                no = True
            End If

        End If


        If no = False Then
            PTR1 = PTR2
            PTR2 = PTR3
            dem = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

            If dem <> 0 Then
                ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
                ua /= dem

                ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
                ub /= dem
                If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                    no = True
                End If

            End If
        End If

        If no = False Then
            PTR1 = PTR2
            PTR2 = PTR4
            dem = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

            If dem <> 0 Then
                ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
                ua /= dem

                ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
                ub /= dem
                If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                    no = True
                End If
            End If
        End If


        If no = False Then
            PTR1 = PTR2
            PTR2 = New Point(Rect.X, Rect.Top)
            dem = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

            If dem <> 0 Then
                ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
                ua /= dem

                ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
                ub /= dem
                If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                    no = True
                End If

            End If
        End If



        Return no
    End Function

    ''' <summary>
    ''' Check for intersection of a line with a rectangle
    ''' </summary>
    ''' <param name="Rect">The rectangle</param>
    ''' <param name="pt1">Point 1 of the line</param>
    ''' <param name="pt2">Point 2 of the line</param>
    ''' <returns></returns>
    Public Overloads Shared Function isIntersect(ByVal Rect As RectangleF, ByVal pt1 As PointF, ByVal pt2 As PointF) As Boolean
        Dim no As Boolean = False

        Dim PTR1 = New PointF(Rect.X, Rect.Top)
        Dim PTR2 = New PointF(Rect.Right, Rect.Top)
        Dim PTR3 = New PointF(Rect.Right, Rect.Bottom)
        Dim PTR4 = New PointF(Rect.X, Rect.Bottom)
        Dim ua As Double = 0
        Dim ub As Double = 0
        Dim dem As Double = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

        If dem <> 0 Then
            ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
            ua /= dem

            ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
            ub /= dem
            If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                no = True
            End If

        End If


        If no = False Then
            PTR1 = PTR2
            PTR2 = PTR3
            dem = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

            If dem <> 0 Then
                ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
                ua /= dem

                ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
                ub /= dem
                If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                    no = True
                End If

            End If
        End If

        If no = False Then
            PTR1 = PTR2
            PTR2 = PTR4
            dem = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

            If dem <> 0 Then
                ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
                ua /= dem

                ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
                ub /= dem
                If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                    no = True
                End If
            End If
        End If


        If no = False Then
            PTR1 = PTR2
            PTR2 = New Point(Rect.X, Rect.Top)
            dem = (((pt2.Y - pt1.Y) * (PTR2.X - PTR1.X)) - ((pt2.X - pt1.X) * (PTR2.Y - PTR1.Y)))

            If dem <> 0 Then
                ua = ((pt2.X - pt1.X) * (PTR1.Y - pt1.Y)) - ((pt2.Y - pt1.Y) * (PTR1.X - pt1.X))
                ua /= dem

                ub = ((PTR2.X - PTR1.X) * (PTR1.Y - pt1.Y)) - ((PTR2.Y - PTR1.Y) * (PTR1.X - pt1.X))
                ub /= dem
                If ((ua >= 0) AndAlso (ua <= 1)) AndAlso ((ub >= 0) AndAlso (ub <= 1)) Then
                    no = True
                End If

            End If
        End If



        Return no
    End Function


    ''' <summary>
    ''' Calculated Unit Vector
    ''' </summary>
    ''' <param name="pt"></param>
    ''' <returns></returns>
    Public Overloads Shared Function Normalize(ByVal pt As Point) As Point
        Dim mag As Double = Math.Sqrt(Math.Pow(pt.X, 2) + Math.Pow(pt.Y, 2))
        pt.X = pt.X / mag
        pt.Y = pt.Y / mag
        Return pt
    End Function

    ''' <summary>
    ''' Calculated Unit Vector
    ''' </summary>
    ''' <param name="pt"></param>
    ''' <returns></returns>
    Public Overloads Shared Function Normalize(ByVal pt As PointF) As PointF
        Dim mag As Double = Math.Sqrt(Math.Pow(pt.X, 2) + Math.Pow(pt.Y, 2))
        pt.X = pt.X / mag
        pt.Y = pt.Y / mag
        Return pt
    End Function

    ''' <summary>
    ''' Calculated Dot Product
    ''' </summary>
    ''' <param name="pt1">Point 1 Of Vector 1 </param>
    ''' <param name="pt2">Point 2 Of Vector 1 </param>
    ''' <param name="pt3">Point 1 Of Vector 2 </param>
    ''' <param name="pt4">Point 2 Of Vector 2 </param>
    ''' <returns></returns>
    Public Overloads Shared Function Dot(ByVal pt1 As Point, ByVal pt2 As Point, ByVal pt3 As Point, ByVal pt4 As Point) As Boolean

        Dim no As Boolean = False
        pt2.X = pt2.X - pt1.X
        pt2.Y = pt2.Y - pt1.Y

        pt4.X = pt4.X - pt3.X
        pt4.Y = pt4.Y - pt3.Y
        pt2 = Normalize(pt2)
        pt4 = Normalize(pt4)
        If ((pt2.X * pt4.X) + (pt2.Y * pt4.Y)) <> 1 Then
            no = True
        End If

        Return no
    End Function
    ''' <summary>
    ''' Calculated Dot Product
    ''' </summary>
    ''' <param name="pt1">Point 1 Of Vector 1 </param>
    ''' <param name="pt2">Point 2 Of Vector 1 </param>
    ''' <param name="pt3">Point 1 Of Vector 2 </param>
    ''' <param name="pt4">Point 2 Of Vector 2 </param>
    ''' <returns></returns>
    Public Overloads Shared Function Dot(ByVal pt1 As PointF, ByVal pt2 As PointF, ByVal pt3 As PointF, ByVal pt4 As PointF) As Boolean

        Dim no As Boolean = False
        pt2.X = pt2.X - pt1.X
        pt2.Y = pt2.Y - pt1.Y

        pt4.X = pt4.X - pt3.X
        pt4.Y = pt4.Y - pt3.Y
        pt2 = Normalize(pt2)
        pt4 = Normalize(pt4)
        If ((pt2.X * pt4.X) + (pt2.Y * pt4.Y)) <> 1 Then
            no = True
        End If

        Return no

    End Function


    ''' <summary>
    '''Statsticaly calculate the maximum value of an array, given some confidence level
    ''' </summary>
    ''' <param name="level">Level, %, in which all samples are equal or less than the statstical max </param>
    ''' <param name="values">Input array of samples (values) </param>
    ''' <returns></returns>
    Public Overloads Shared Function MaxVal_ConfidenceLevel(ByVal level As Integer, ByVal values As List(Of Integer)) As Integer

        Dim AmntCnt = Math.Ceiling(values.Count * level / 100)

        If AmntCnt >= values.Count Then
            AmntCnt = values.Count - 1
        End If

        Return values.OrderBy(Function(X) X).ElementAt(AmntCnt)

    End Function


    ''' <summary>
    '''Statsticaly calculate the maximum value of an array, given some confidence level
    ''' </summary>
    ''' <param name="level">Level, %, in which all samples are equal or less than the statsticala max </param>
    ''' <param name="values">Input array of samples (values) </param>
    ''' <returns></returns>
    Public Overloads Shared Function MaxVal_ConfidenceLevel(ByVal level As Integer, ByVal values As List(Of Single)) As Single
        Dim AmntCnt = Math.Ceiling(values.Count * level / 100)

        If AmntCnt >= values.Count Then
            AmntCnt = values.Count - 1
        End If

        Return values.OrderBy(Function(X) X).ElementAt(AmntCnt)
    End Function

    ''' <summary>
    '''Statsticaly calculate the maximum value of an array, given some confidence level
    ''' </summary>
    ''' <param name="level">Level, %, in which all samples are equal or less than the statsticala max </param>
    ''' <param name="values">Input array of samples (values) </param>
    ''' <returns></returns>
    Public Overloads Shared Function MaxVal_ConfidenceLevel(ByVal level As Integer, ByVal values As List(Of Double)) As Double

        Dim AmntCnt = Math.Ceiling(values.Count * level / 100)

        If AmntCnt >= values.Count Then
            AmntCnt = values.Count - 1
        End If

        Return values.OrderBy(Function(X) X).ElementAt(AmntCnt)
    End Function

    ''' <summary>
    ''' Convert input pixel size to 20th Point, OpenXML DOC standard
    ''' </summary>
    ''' <param name="reso">density of pixel per inche</param>
    ''' <param name="size">pixel size to convert</param>
    ''' <returns></returns>
    Public Overloads Shared Function PixelBoundTo_20thPoint(ByVal reso As Size, ByVal size As Size) As Size
        Dim newsize As New Size
        newsize.Width = (size.Width / reso.Width) * 72 * 20
        newsize.Height = (size.Height / reso.Height) * 72 * 20
        Return newsize
    End Function

    ''' <summary>
    ''' Convert input pixel size to 20th Point, OpenXML DOC standard
    ''' </summary>
    ''' <param name="dpx">Horizontal density of pixel per inche</param>
    ''' <param name="dpy">Vertical desnity of pixels per inche</param>
    ''' <param name="size"></param>
    ''' <returns></returns>
    Public Overloads Shared Function PixelBoundTo_20thPoint(ByVal dpx As Integer, ByVal dpy As Integer, ByVal size As Size) As Size
        Dim newsize As New Size
        newsize.Width = (size.Width / dpx) * 72 * 20
        newsize.Height = (size.Height / dpy) * 72 * 20
        Return newsize
    End Function

    ''' <summary>
    ''' Convert input pixel size to EMU point, OpenXML DOC standard 
    ''' </summary>
    ''' <param name="dpi">density of pixel per inche</param>
    ''' <param name="size">pixel size to convert</param>
    ''' <returns></returns>
    Public Overloads Shared Function PixelBoundTo_EMU(ByVal dpi As Integer, ByVal size As Size) As Size
        Dim newsize As New Size
        newsize.Width = (size.Width / dpi) * 914400
        newsize.Height = (size.Height / dpi) * 914400
        Return newsize
    End Function


    ''' <summary>
    ''' Convert pixel margin 20th point margin, OpenXML DOC standard
    ''' </summary>
    ''' <param name="dpx">x resolution dpi</param>
    ''' <param name="dpy">y resolution dpi</param>
    ''' <param name="margin"></param>
    ''' <returns></returns>
    Public Overloads Shared Function Pixelmargin_20thmargin(ByVal dpx As Integer, ByVal dpy As Integer, ByVal margin As ocrpagemargin) As ocrpagemargin
        Dim newsize As New ocrpagemargin
        newsize.Top = (margin.Top / dpy) * 72 * 20
        newsize.Bottom = (margin.Bottom / dpy) * 72 * 20

        newsize.Left = (margin.Left / dpx) * 72 * 20
        newsize.Right = (margin.Right / dpx) * 72 * 20
        Return newsize
    End Function


    Public Overloads Shared Function PixelBoundToPointBound(ByVal rect As Size, ByVal dpi As Size) As SizeF
        Dim newound As New SizeF


        newound.Width = (rect.Width / dpi.Width) * 72
        newound.Height = (rect.Height / dpi.Height) * 72
        Return newound
    End Function
    Public Overloads Shared Function PixelBoundToPointBound(ByVal rect As Rectangle, ByVal dpi As Size) As RectangleF
        Dim newound As New Rectangle
        newound.X = (rect.X / dpi.Width) * 72
        newound.Y = (rect.Y / dpi.Height) * 72
        newound.Width = (rect.Width / dpi.Width) * 72
        newound.Height = (rect.Height / dpi.Height) * 72
        Return newound
    End Function
    Public Overloads Shared Function Pixelmargin_20thmargin(ByVal reso As Size, ByVal margin As ocrpagemargin) As ocrpagemargin
        Dim newsize As New ocrpagemargin
        newsize.Top = (margin.Top / reso.Height) * 72 * 20
        newsize.Bottom = (margin.Bottom / reso.Height) * 72 * 20

        newsize.Left = (margin.Left / reso.Width) * 72 * 20
        newsize.Right = (margin.Right / reso.Width) * 72 * 20
        Return newsize
    End Function

    ''' <summary>
    ''' Convert input pixel size to EMU point, OpenXML DOC standard 
    ''' </summary>
    ''' <param name="dpx">Horizontal density of pixel per inche</param>
    ''' <param name="dpy">Vertical desnity of pixels per inche</param>
    ''' <param name="size"></param>
    ''' <returns></returns>
    Public Overloads Shared Function PixelBoundTo_EMU(ByVal dpx As Integer, ByVal dpy As Integer, ByVal size As Size) As Size
        Dim newsize As New Size
        newsize.Width = (size.Width / dpx) * 914400
        newsize.Height = (size.Height / dpy) * 914400
        Return newsize
    End Function

    Public Overloads Shared Function PixelFontSizeToDocumentFontSize(ByVal dpi As Integer, ByVal fntsize As Single) As Single
        Dim newsize As New Single
        newsize = (fntsize / dpi) * 72 * 2

        Return newsize
    End Function
    Public Overloads Shared Function PixelFontSizeToDocumentFontSize(ByVal dpi As Integer, ByVal fntsize As Integer) As Single
        Dim newsize As New Single
        newsize = (fntsize / dpi) * 72 * 2

        Return newsize
    End Function


    Public Overloads Shared Function GetBoundingRectangle(ByVal p1 As Point, ByVal p2 As Point) As Rectangle
        Dim BoundingRec As New Rectangle
        If p1.X >= p2.X Then
            BoundingRec.Width = p1.X - p2.X
            BoundingRec.X = p2.X
        Else
            BoundingRec.Width = p2.X - p1.X
            BoundingRec.X = p1.X
        End If

        If p1.Y >= p2.Y Then
            BoundingRec.Height = p1.Y - p2.Y
            BoundingRec.Y = p2.Y
        Else
            BoundingRec.Height = p2.Y - p1.Y
            BoundingRec.Y = p1.Y
        End If

        Return BoundingRec
    End Function

    Public Overloads Shared Function GetLength(ByVal pts As List(Of Point)) As Single

        Dim leng As Single = 0

        Try
            For iu As Integer = 1 To pts.Count - 1 Step 1
                leng += CSng(Math.Sqrt(Math.Pow(pts(iu - 1).X - pts(iu).X, 2) + Math.Pow(pts(iu - 1).Y - pts(iu).Y, 2)))
            Next
        Catch ex As Exception
            leng = -1
        End Try


        Return leng

    End Function

    Public Overloads Shared Function GetLength(ByVal pts() As Point) As Single

        Dim leng As Single = 0

        Try
            For iu As Integer = 1 To pts.Count - 1 Step 1
                leng += CSng(Math.Sqrt(Math.Pow(pts(iu - 1).X - pts(iu).X, 2) + Math.Pow(pts(iu - 1).Y - pts(iu).Y, 2)))
            Next
        Catch ex As Exception
            leng = -1
        End Try


        Return leng

    End Function

    Public Overloads Shared Function PointF2Point(ByVal pointf As PointF) As Point
        Return New Point(CInt(pointf.X), CInt(pointf.Y))

    End Function
    Public Overloads Shared Function PointF2Point(ByVal pointf() As PointF) As Point()
        Dim cnt As Integer = pointf.Count - 1
        Dim points(cnt) As Point

        If cnt >= 0 Then
            points.Initialize()
            For iuyr As Integer = 0 To cnt Step 1
                points(iuyr) = New Point(CInt(pointf(iuyr).X), CInt(pointf(iuyr).Y))
            Next
        End If




        Return points
    End Function

    Public Overloads Shared Function PointF2Point(ByVal pointf As List(Of PointF)) As List(Of Point)

        Dim cnt As Integer = pointf.Count - 1
        Dim points As New List(Of Point)

        If cnt >= 0 Then

            For iuyr As Integer = 0 To cnt Step 1
                points.Add(New Point(CInt(pointf(iuyr).X), CInt(pointf(iuyr).Y)))
            Next
        End If


        Return points

    End Function


    Public Overloads Shared Function DivideTimeSpan(ByVal span As TimeSpan, ByVal devider As Integer) As TimeSpan
        Return TimeSpan.FromTicks(span.Ticks / devider)
    End Function

    Public Overloads Shared Function MultiplyTimeSpan(ByVal span As TimeSpan, ByVal devider As Integer) As TimeSpan
        Return TimeSpan.FromTicks(span.Ticks * devider)
    End Function

    Public Overloads Shared Function TimeSpanString(ByVal span As TimeSpan) As String

        Dim time As String = ""
        If span.TotalSeconds >= 1 Then

            If span.Days > 0 Then
                time = span.Days.ToString + " Days "
            End If

            If span.Hours > 0 Then
                time += span.Hours.ToString + " Hours "
            End If

            If span.Minutes > 0 Then
                time += span.Minutes.ToString + " Minutes "
            End If

            If span.Seconds > 0 Then
                time += span.Seconds.ToString + " Seconds "
            End If
        Else
            If span.Milliseconds > 0 Then
                time += span.Milliseconds.ToString + "Milliseconds"
            End If
        End If



        Return time
    End Function

End Class
