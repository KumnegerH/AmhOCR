# AmhOCR
Tesseract Powered Windows Desktop OCR Application With Multiple Pre/Post Processing GUI

AmhOCR is an Optical Character Recognition (OCR) application for Windows Desktop. It is based on the latest Tesseract's v4.0/LSTM OCR engine which supports over 100 languages. However some post-processing tools, in AmhOCR, are applicable only for Amharic language.

#### Test Screenshot: Multi column newspaper image recognition, with image area embedding, spell checking(highlighted in red) and word level text editing.

![Test_Result_news_t1](https://user-images.githubusercontent.com/57003323/69315187-ff60cf00-0c46-11ea-84f4-6267a8bcbe1b.png)

## Features:
- Support OCRing multiple image format: TIFF, JPEG, PNG, BMP and other image formats
- Import PDF as image
- Batch image import
- Flexible image view tool
- Pre-process image: de-skew, threshold and other image correction settings
- Process selected image
- Batch Process image with flexible management: pause, re-start and cancel 
- Asynchronous and multithread processing for large batch size
- View and work on the processed text with similar format and layout as source input
- Post Process OCR output: Edit text and spell check
- Multi level editing: Paragraph level and word level edit. 
- Convert OCR output: to MS word document, searchable PDF and text output
- Save and Open work as AmhOCR single file project, based on HOCR data structure
- NLP process: word list, word frequency, sentences list, word & character N-gram 
- Extension tools for multipage TIFF: Merge and split
- Extension tools for PDF: Merge, split and convert to image
- Extension tools for image: Format conversion to different image format and conversion to PDF

## Dependencies:
 - Microsoft .NET Framework 4.0  
 - GhostScriptSharp
 - AForge Imaging
 - iTextSharp
 - Microsoft.Bcl.Async
 - OpenXML SDK 2.5
 
## Building with Visual Studio:
- Visual studio 2015 and later
- Restore nuget packages

 ## License:
 - GNU GPLv3
 
