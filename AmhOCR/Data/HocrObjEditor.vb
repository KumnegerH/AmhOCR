'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3

Public Structure HocrObjEditor

    Public EditMode As ocrEditMode
    Public HocrObject As Object

    Public text As String

    Public isinEdit As Boolean
    Public isLocked As Boolean
    Public isDirty As Boolean
    Public Spelled As Boolean

    Public Font As Font
    Public alignment As ParAlignment
    Public bbox As Rectangle

End Structure
