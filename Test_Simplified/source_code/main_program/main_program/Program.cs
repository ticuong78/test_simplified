using System;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;
using System.Net.Quic;

namespace main_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Coding\Web-Dev\Test_Simplified\sample\50\raw\history_1-copy.docx";

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, false))
            {
                if (wordDocument is null) throw new ArgumentNullException();
                MainDocumentPart? mainPart = wordDocument.MainDocumentPart;
                if(mainPart is null) throw new ArgumentNullException("Cannot find main document part!");

                Body? body = mainPart.Document.Body;

                if(body is null) throw new ArgumentNullException("Cannot find body part");

                IEnumerable<OpenXmlElement> rawOpenXmlElementList = body.Elements(); //no mention

                Process convertQuestions = new Process(rawOpenXmlElementList);

                convertQuestions.DisplayElement();

                wordDocument.Dispose();
            }
        }
    }
}
