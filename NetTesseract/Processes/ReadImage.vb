
'Copyright ©  Kumneger Hussien, kumneger.h@gmail.com, 2019 GPLv3


Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text

Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.ComponentModel
''' <summary>
''' Service to read texts from image through tessercat engine.
''' </summary>
''' 
Public Class ReadImage
    Implements IDisposable

    Private _lang As String
    Private _tessPath As String
    Private _OcrModel As String
    Private _dataPath As String

    Public Event WriteOutput(ByVal arg As ProcessFlowArg)


    ''' <summary>
    ''' Start Service for tesseract Operation
    ''' </summary>
    ''' <param name="lang">language to extract</param>
    ''' <param name="OcrModel">Tesseract Model to use, LSTM or Legacy</param>
    Public Sub New(ByVal lang As String, OcrModel As String)

        _tessPath = Environment.CurrentDirectory
        _lang = lang
        _OcrModel = OcrModel

        _tessPath = Path.Combine(_tessPath, "Tesseract")
        _dataPath = Path.Combine(_tessPath, "tessdata")

        Environment.SetEnvironmentVariable("TESSDATA_PREFIX", _dataPath)

        If Environment.Is64BitOperatingSystem Then
            _tessPath = Path.Combine(_tessPath, "x64")
        Else
            _tessPath = Path.Combine(_tessPath, "x86")
        End If


        _tessPath = Path.Combine(_tessPath, "tesseract.exe")
    End Sub



    Public outputtext As String = ""

    Public Function GetText(ByVal imagesFile As String) As String


        Dim output As String = String.Empty
        If String.IsNullOrEmpty(imagesFile) = False Then

            Dim trashpath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString)
            Directory.CreateDirectory(trashpath)
            Dim trashimp = Path.Combine(trashpath, Guid.NewGuid.ToString)
            Dim trashOutputfile = Path.Combine(trashpath, Guid.NewGuid.ToString)
            Dim trashdebugfile = Path.Combine(trashpath, Guid.NewGuid.ToString)

            Try

                Dim filed = File.CreateText(trashimp)
                filed.WriteLine(imagesFile)
                filed.Close()
                Dim info = New ProcessStartInfo

                With info
                    .FileName = _tessPath
                    '.Arguments = $"{tempInputfile} {tempOutputfile} -l {_lang} -c {"tessedit_create_hocr=1"} -c {"paragraph_debug_level=1"} -c debug_file={trashdebugfile} "
                    .Arguments = $" {trashimp} {trashOutputfile} -l {_lang}"
                    .RedirectStandardError = True
                    .RedirectStandardOutput = True
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .ErrorDialog = False
                End With

                Using ps = Process.Start(info)

                    ps.BeginErrorReadLine()
                    ps.BeginOutputReadLine()
                    ps.EnableRaisingEvents = True
                    ps.WaitForExit(50000)
                    ps.Refresh()

                    If File.Exists(trashOutputfile + ".txt") Then
                        output = File.ReadAllText(trashOutputfile + ".txt")
                    End If


                End Using
            Finally

                Directory.Delete(trashpath, True)

            End Try



        End If

        GC.Collect()
        Return output

    End Function

    Public Overloads Async Function GetHocr(ByVal imagesFile As String, ByVal timeout As Integer) As Task(Of String)


        Dim output As String = String.Empty
        If String.IsNullOrEmpty(imagesFile) = False Then

            Dim trashpath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString)
            Directory.CreateDirectory(trashpath)
            Dim trashinput = Path.Combine(trashpath, Guid.NewGuid.ToString)
            Dim trashOutput = Path.Combine(trashpath, Guid.NewGuid.ToString)
            Dim trashdebugfile = Path.Combine(trashpath, Guid.NewGuid.ToString) + ".log"

            Try

                Dim filed = File.CreateText(trashinput)
                filed.WriteLine(imagesFile)
                filed.Close()
                Dim info = New ProcessStartInfo

                With info
                    .FileName = _tessPath
                    '.Arguments = $"{tempInputfile} {tempOutputfile} -l {_lang} -c {"tessedit_create_hocr=1"} -c {"paragraph_debug_level=1"} -c debug_file={trashdebugfile} -c {"tessedit_parallelize=1"}"
                    .Arguments = $" {trashinput} {trashOutput} -l {_lang} -c {"tessedit_create_hocr=1"} -c {"tessedit_page_number=0"} -c {"hocr_font_info=1"}"
                    .RedirectStandardError = True
                    .RedirectStandardOutput = True
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .ErrorDialog = False
                End With

                Using ps = Process.Start(info)

                    ps.EnableRaisingEvents = True

                    Dim tsk = TaskEx.Run(Function() As Boolean
                                             Return ps.WaitForExit(timeout)
                                         End Function)


                    If Await tsk Then
                        If File.Exists(trashOutput + ".hocr") Then

                            output = File.ReadAllText(trashOutput + ".hocr")

                        End If
                    End If


                End Using


            Finally

                Directory.Delete(trashpath, True)

            End Try



        End If

        GC.Collect()
        Return output

    End Function




    Public Overloads Async Function GetHocr(ByVal imagesFiles As List(Of String)) As Task(Of String)


        Dim output As String = String.Empty

        If imagesFiles.Count > 0 Then

            Dim trashpath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString)
            Directory.CreateDirectory(trashpath)
            Dim trashinput = Path.Combine(trashpath, Guid.NewGuid.ToString)
            Dim trashOutput = Path.Combine(trashpath, Guid.NewGuid.ToString)
            Dim trashdebugfile = Path.Combine(trashpath, Guid.NewGuid.ToString) + ".log"

            Try

                Dim filed = File.CreateText(trashinput)
                For Each file In imagesFiles
                    filed.WriteLine(file)
                Next

                filed.Close()
                Dim info = New ProcessStartInfo

                With info
                    .FileName = _tessPath
                    '.Arguments = $"{tempInputfile} {tempOutputfile} -l {_lang} -c {"tessedit_create_hocr=1"} -c {"paragraph_debug_level=1"} -c debug_file={trashdebugfile} -c {"tessedit_parallelize=1"}"
                    .Arguments = $" {trashinput} {trashOutput} -l {_lang} -c {"tessedit_create_hocr=1"} -c {"hocr_font_info=1"} "
                    .RedirectStandardError = True
                    .RedirectStandardOutput = True
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .ErrorDialog = False
                End With

                Using ps = Process.Start(info)

                    ps.EnableRaisingEvents = True

                    Dim tsk = TaskEx.Run(Sub()
                                             ps.WaitForExit()
                                         End Sub)


                    Await tsk

                    If File.Exists(trashOutput + ".hocr") Then

                        output = File.ReadAllText(trashOutput + ".hocr")

                    End If

                End Using


            Finally

                Directory.Delete(trashpath, True)

            End Try




        End If

        GC.Collect()
        Return output

    End Function


    Public Overloads Async Function GetPDF(ByVal imagesFile() As String, ByVal OutputFile As String, ByVal timeout As Integer) As Task(Of String)


        Dim output As String = String.Empty
        If imagesFile.Count > 0 Then

            Dim trashpath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString)
            Directory.CreateDirectory(trashpath)
            Dim trashinput = Path.Combine(trashpath, Guid.NewGuid.ToString)
            OutputFile = Path.Combine(Path.GetDirectoryName(OutputFile), Path.GetFileNameWithoutExtension(OutputFile))

            Dim debugfile = OutputFile + ".log"

            Try

                Dim filed = File.CreateText(trashinput)
                For Each file In imagesFile
                    filed.WriteLine(file)
                Next

                filed.Close()
                Dim info = New ProcessStartInfo

                With info
                    .FileName = _tessPath
                    '.Arguments = $"{tempInputfile} {tempOutputfile} -l {_lang} -c {"tessedit_create_hocr=1"} -c {"paragraph_debug_level=1"} -c debug_file={trashdebugfile} -c {"tessedit_parallelize=1"}"
                    .Arguments = $" {trashinput} {OutputFile} -l {_lang} -c {"tessedit_create_pdf=1"} -c debug_file={debugfile} "
                    .RedirectStandardError = True
                    .RedirectStandardOutput = True
                    .CreateNoWindow = True
                    .UseShellExecute = False
                    .ErrorDialog = False
                End With

                Using ps = Process.Start(info)

                    ps.EnableRaisingEvents = True

                    Dim tsk = TaskEx.Run(Function() As Boolean
                                             Return ps.WaitForExit(timeout)
                                         End Function)


                    If Await tsk Then
                        If File.Exists(OutputFile + ".pdf") Then

                            output = "Output Saved @:   " + OutputFile + ".pdf"

                        End If
                    End If


                End Using


            Finally

                Directory.Delete(trashpath, True)

            End Try



        End If

        GC.Collect()
        Return output

    End Function



#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If


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

Public Class ProcessFlowArg
    Inherits EventArgs
    Public output As String
    Public Sub New(ByVal txt As String)
        output = txt
    End Sub

End Class