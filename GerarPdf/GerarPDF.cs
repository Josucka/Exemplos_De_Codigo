using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace testGerarPDF
{
    public class GerarPDF
    {
        string url = @"EstiloPdfHtml.cshtml";
        
        public void GerarPdf(string url)
        {
            PdfWriter pdfWriter = new PdfWriter(@"C:testPdf\demo.pdf");
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document = new Document(pdfDocument);
            Paragraph paragraph = new Paragraph(url);
            document.Add(paragraph);
            document.Close();
        }
    }
}
