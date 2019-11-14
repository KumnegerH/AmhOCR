
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3
Public Class SpellCheker
    Implements IDisposable

    Public Loaded As Boolean = False
    Public Words() As String
    Public chars() As String
    Public puncs() As Char
    Public nums() As String
    Public Event DicLoaded As EventHandler
    Public isloading As Boolean = False


    Public Sub New()

        isloading = False
        Loaded = False

        Words = {""}
        chars = {""}
        puncs = {}
        nums = {""}

    End Sub


    ''' <summary>
    ''' Async Initialize SymSpell cheker class
    ''' </summary>
    Public Sub InitializSpellCheck()

        isloading = True
        Loaded = False

        Dim _CharPath = Environment.CurrentDirectory
        _CharPath = System.IO.Path.Combine(_CharPath, "Lang.Data")
        _CharPath = System.IO.Path.Combine(_CharPath, OCRsettings.Language + ".alphabets")

        Dim _puncsPath = Environment.CurrentDirectory
        _puncsPath = System.IO.Path.Combine(_puncsPath, "Lang.Data")
        _puncsPath = System.IO.Path.Combine(_puncsPath, OCRsettings.Language + ".punctuations")

        Dim _numsPath = Environment.CurrentDirectory
        _numsPath = System.IO.Path.Combine(_numsPath, "Lang.Data")
        _numsPath = System.IO.Path.Combine(_numsPath, OCRsettings.Language + ".numerics")


        Dim _DictPath = Environment.CurrentDirectory
        _DictPath = System.IO.Path.Combine(_DictPath, "Lang.Data")
        _DictPath = System.IO.Path.Combine(_DictPath, OCRsettings.Language + ".words")


        If IO.File.Exists(_DictPath) Then

            Dim wordsFile = IO.File.ReadAllText(_DictPath)
            Words = wordsFile.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)



            If IO.File.Exists(_CharPath) Then

                Dim charsFile = IO.File.ReadAllText(_CharPath)
                chars = charsFile.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            End If

            If IO.File.Exists(_puncsPath) Then

                Dim puncsFile = IO.File.ReadAllText(_puncsPath)
                Dim puncString = puncsFile.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                Words = Words.Concat(puncString.AsEnumerable).ToArray
                puncs = puncString.Select(Function(X) X.First).ToArray

            End If

            If IO.File.Exists(_numsPath) Then

                Dim numaFile = IO.File.ReadAllText(_numsPath)
                nums = numaFile.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            End If

        End If






        If Words.Count > 0 Then
            Loaded = True
        End If

        isloading = False

        If Loaded = True Then
            RaiseEvent DicLoaded(Me, Nothing)
        End If



    End Sub


    ''' <summary>
    ''' Validate if a word or sentences is correctly spelled
    ''' </summary>
    ''' <param name="word">word or sentences to be validated</param>
    ''' <returns></returns>
    Public Function isValidWord(ByVal word As String) As Boolean

        'the word will be splited into sub-words based on white space
        'empty string will be ignored  
        Dim subwords = word.Split({" "}, StringSplitOptions.RemoveEmptyEntries)


        'each sub-word will be checked
        'this function return true, only if all sub-words are valid. 

        Return (subwords.Where(Function(X) (ListedWord(X) OrElse isNumeric(X) OrElse EndsWithPunc(X))).Count = subwords.Count)

    End Function

    ''' <summary>
    ''' Remove White Space at the begening and end of a word
    ''' </summary>
    ''' <param name="word"></param>
    ''' <returns></returns>
    Private Function CleanWhiteSpace(ByVal word As String) As String

        Return word.TrimStart({" ".First}).TrimEnd({" ".First})

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


        Return Words.Contains(word.TrimStart(puncs).TrimEnd(puncs))

    End Function


    Public Function SpellApproximate(ByVal word As String) As String

        If (Loaded = True) Then


        End If

        Return word
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
