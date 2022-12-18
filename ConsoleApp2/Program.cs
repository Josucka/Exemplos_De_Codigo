using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using iText.Layout;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();

            string caminho = @"C:\Users\Josué Barros\OneDrive\Área de Trabalho\testPdf" + "Contrato.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            string dados = "";
            Paragraph paragrafo = new Paragraph(dados, new Font(Font.NORMAL, 14));
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafo.Add("Testando Primeiro PDF");

            doc.Add(paragrafo);

            doc.Close();
            Console.WriteLine("Hello World!");
        }
    }
}
