using iText.Html2pdf;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace GerarPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerarPDF();
        }

        private void GerarPDF()
        {
            

            var arquivo = @"C:\Users\Josué Barros\OneDrive\Área de Trabalho\testPdf" + "Contrato.pdf";

            var texto = @"Á" + 
                        "\nMão de obra especializada"+ 
                        "\n"+
                        "\nREF.: Mão de obra especializada para mudança de barrilete de local na industria Agripon."+
                        "\n"+
                        "\nApresento proposta comercial para execução de serviços conforme referência acima";
            var list = new List<Exemplo>();
            

            var data = Guid.NewGuid().ToString();
            var assina = "___________________________";

            using (PdfWriter writer = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(writer);
                var document = new Document(pdfDocument, PageSize.A4);
                document.SetFontSize(14);
                document.SetMargins(50, 50, 50, 50);
                document.SetCharacterSpacing((float)0.5);

                var timesNewRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                var parag = new Paragraph();
                parag.SetFont(timesNewRoman);
                parag.SetFontSize(30);
                parag.SetTextAlignment(TextAlignment.CENTER);
                parag.SetFontColor(ColorConstants.GRAY);
                parag.SetBackgroundColor(ColorConstants.GREEN);
                parag.Add("Title");

                document.Add(parag);
                document.Add(new Paragraph("Recibo"));
                document.Add(new Paragraph(texto));
                document.Add(new Paragraph());

                document.Add(new Paragraph(data));
                document.Add(new Paragraph(assina));
                document.Add(new Paragraph("exemplo"));

                document.Close();

                pdfDocument.Close();

                MessageBox.Show($"Arquivo Pdf gerado em {arquivo}");
            }
        }
    }
}