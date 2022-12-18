using AspNetCore;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGerarPDF
{
    public class GerarPDF
    {
        
        public void GerarPdf(string caminho)
        {
            PdfWriter pdfWriter = new PdfWriter(@"C:\\Users\\Josué Barros\\OneDrive\\Área de Trabalho\\testPdf\demo.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph(caminho);
            document.Add(paragraph);
            document.Close();
        }
    }
}
