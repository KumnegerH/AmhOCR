
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class SpellCheker
    Implements IDisposable

    Public Loaded As Boolean = False
    Public UserWords() As String
    Public Words() As String
    Public chars() As String
    Public puncs() As Char
    Public nums() As String
    Public prefix() As String
    Public suffix() As String
    Public CharReplace() As String
    Public Shared NormChars() As List(Of String)
    Public Shared NormNumerics() As List(Of String)
    Public Event DicLoaded As EventHandler
    Public isloading As Boolean = False
    Public _UserPath As String = ""

    Public Lang As String = True

    Private NoData As Boolean = True

    Private SpecialCharWhiteList() As Char


    Public Sub New()

        isloading = False
        Loaded = False
        NoData = True
        NormChars = {}
        NormNumerics = {}
        Words = {}
        chars = {}
        puncs = {}
        nums = {}
        CharReplace = {}
        UserWords = {}
        prefix = {}
        suffix = {}
        SpecialCharWhiteList = {}
        Lang = ""
        _UserPath = ""
    End Sub


    Private Sub ResetSpeller()

        isloading = False
        Loaded = False
        NoData = True
        Words = {}
        chars = {}
        puncs = {}
        nums = {}
        UserWords = {}
        CharReplace = {}
        prefix = {}
        suffix = {}
        NormChars = {}
        NormNumerics = {}
        SpecialCharWhiteList = {}
        Lang = ""
        _UserPath = ""

    End Sub
    ''' <summary>
    ''' Async Initialize SymSpell cheker class
    ''' </summary>
    Public Sub InitializSpellCheck(ByVal Language As String)
        ResetSpeller()
        isloading = True
        Lang = Language

        If Lang = "amh" Then
            SpecialCharWhiteList = {"፣".First, "፤".First, "፡".First, ":".First}
        End If

        Dim _CharPath = Environment.CurrentDirectory
        _CharPath = System.IO.Path.Combine(_CharPath, "Lang.Data")
        _CharPath = System.IO.Path.Combine(_CharPath, Lang + ".alphabets")

        Dim _puncsPath = Environment.CurrentDirectory
        _puncsPath = System.IO.Path.Combine(_puncsPath, "Lang.Data")
        _puncsPath = System.IO.Path.Combine(_puncsPath, Lang + ".punctuations")

        Dim _numsPath = Environment.CurrentDirectory
        _numsPath = System.IO.Path.Combine(_numsPath, "Lang.Data")
        _numsPath = System.IO.Path.Combine(_numsPath, Lang + ".numerics")


        Dim _DictPath = Environment.CurrentDirectory
        _DictPath = System.IO.Path.Combine(_DictPath, "Lang.Data")
        _DictPath = System.IO.Path.Combine(_DictPath, Lang + ".words")

        Dim _prefixPath = Environment.CurrentDirectory
        _prefixPath = System.IO.Path.Combine(_prefixPath, "Lang.Data")
        _prefixPath = System.IO.Path.Combine(_prefixPath, Lang + ".prefixes")


        Dim _ReplaceCharPath = Environment.CurrentDirectory
        _ReplaceCharPath = System.IO.Path.Combine(_ReplaceCharPath, "Lang.Data")
        _ReplaceCharPath = System.IO.Path.Combine(_ReplaceCharPath, Lang + ".normalizers")



        _UserPath = OCRsettings.AmhOcrDataFolder
        _UserPath = System.IO.Path.Combine(_UserPath, Lang + ".userwords")


        If IO.File.Exists(_prefixPath) Then

            prefix = IO.File.ReadAllLines(_prefixPath)

        End If


        If IO.File.Exists(_DictPath) Then

            Words = IO.File.ReadAllLines(_DictPath)

        End If


        If IO.File.Exists(_numsPath) Then

            nums = IO.File.ReadAllLines(_numsPath)

        End If

        If IO.File.Exists(_ReplaceCharPath) Then

            CharReplace = IO.File.ReadAllLines(_ReplaceCharPath)

            Dim NormCheck = CharReplace.Select(Function(x) x.Split(" ").First)
            Dim NormSet = CharReplace.Select(Function(x) x.Split(" ").Last)
            'MsgBox(NormCheck.Count.ToString + "  , " + NormCheck.Count.ToString)

            Dim NormCharList As New List(Of String)
            Dim NormNumList As New List(Of String)


            Dim ReplaceCharList As New List(Of String)
            Dim ReplaceNumericsList As New List(Of String)
            For Charindx As Integer = 0 To NormCheck.Count - 1 Step 1

                If nums.Contains(NormCheck(Charindx).First) Then

                    NormNumList.Add(NormCheck(Charindx))
                    ReplaceNumericsList.Add(NormSet(Charindx))

                Else


                    NormCharList.Add(NormCheck(Charindx))
                    ReplaceCharList.Add(NormSet(Charindx))


                End If


            Next



            NormChars = {NormCharList, ReplaceCharList}


            NormNumerics = {NormNumList, ReplaceNumericsList}

        End If

        If IO.File.Exists(_UserPath) Then

            UserWords = IO.File.ReadAllLines(_UserPath)
            Words = Words.Union(UserWords).ToArray
        Else
            IO.File.Create(_UserPath)
        End If



        If IO.File.Exists(_CharPath) Then

            chars = IO.File.ReadAllLines(_CharPath)

        End If

        If IO.File.Exists(_puncsPath) Then

            Dim puncString = IO.File.ReadAllLines(_puncsPath)
            puncs = puncString.Select(Function(X) X.First).ToArray

        End If


        If Words.Count > 0 Then
            NoData = False
        End If


        Loaded = True
        isloading = False

        RaiseEvent DicLoaded(Me, Nothing)



    End Sub


    ''' <summary>
    ''' Validate if a word or sentences is correctly spelled
    ''' </summary>
    ''' <param name="word">word or sentences to be validated</param>
    ''' <returns></returns>
    Public Function isValidWord(ByVal word As String) As Boolean

        If NoData = True Then

            Return True

        Else


            'the original alphabets will be normalized to equivalent form

            If OCRsettings.NormalizeChar = True Then

                word = NormalizeCharacters(word)

            End If


            'the word will be splited into sub-words based on white space
            'empty string will be ignored  
            Dim subwords = word.Split({" "}, StringSplitOptions.RemoveEmptyEntries)

            'each sub-word will be checked
            'this function return true, only if all sub-words are valid. 

            Return (subwords.Where(Function(X) (puncs.Contains(X) OrElse isNumeric(X) OrElse ListedWord(X)) OrElse wordwithprefix(X) OrElse EndsWithPunc(X)).Count = subwords.Count)

        End If


    End Function


    ''' <summary>
    ''' Check if wordlist contrain this word
    ''' </summary>
    ''' <param name="word"></param>
    ''' <returns></returns>
    Private Function ListedWord(ByVal word As String) As Boolean

        Return Words.Contains(word)

    End Function

    ''' <summary>
    ''' Checks if the word is numeric /important for non-arabic numbers/
    ''' </summary>
    ''' <param name="word"></param>
    ''' <returns></returns>
    Private Function isNumeric(ByVal word As String) As Boolean

        Return (word.Where(Function(X) nums.Contains(X)).Count = word.Count)

    End Function


    ''' <summary>
    ''' Check if the word is valid by removing panctuation mark at start and end of the word, if there are any 
    ''' </summary>
    ''' <param name="word"></param>
    ''' <returns></returns>
    Private Function EndsWithPunc(ByVal word As String) As Boolean


        Return Words.Contains(word.Trim(puncs))

    End Function

    Private Function wordwithprefix(ByVal word As String) As Boolean


        If prefix.Contains(word.First) Then
            word = word.Remove(0, 1)
            Return Words.Contains(word)
        Else
            Return False
        End If



    End Function


    Public Function SpellApproximate(ByVal word As String) As String

        If (Loaded = True) Then


        End If

        Return word
    End Function

    Public Function RemoveSpecialCharacters(ByVal text As String) As String
        Dim txt As String = text

        If txt.Length > 0 AndAlso SpecialCharWhiteList.Count > 0 Then


            For Each Charc In SpecialCharWhiteList
                If txt.Contains(Charc) Then
                    txt = txt.Replace(Charc, "")
                End If
            Next

        End If


        Return txt
    End Function

    Public Shared Function NormalizeNumerics(ByVal txt As String) As String

        Dim Ntxt As String = txt

        If txt.Length > 0 AndAlso NormNumerics.Count > 1 Then

            If txt.Any(Function(X) NormNumerics(0).Contains(X)) Then

                Ntxt = ""

                For Each st In txt

                    Dim idx = NormNumerics(0).IndexOf(st)

                    If idx >= 0 Then

                        Ntxt = Ntxt + NormNumerics(1)(idx).ToString
                    Else

                        Ntxt = Ntxt + st.ToString
                    End If

                Next

            End If

        End If




        Return Ntxt
    End Function


    Public Shared Function NormalizeCharacters(ByVal txt As String) As String


        Dim Ntxt As String = txt

        If txt.Length > 0 AndAlso NormChars.Count > 1 Then

            If txt.Any(Function(X) NormChars(0).Contains(X)) Then

                Ntxt = ""

                For Each st In txt

                    Dim idx = NormChars(0).IndexOf(st)

                    If idx >= 0 Then
                        Ntxt = Ntxt + NormChars(1)(idx).ToString
                    Else
                        Ntxt = Ntxt + st.ToString
                    End If

                Next

            End If

        End If




        Return Ntxt
    End Function



#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            Loaded = False
            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
