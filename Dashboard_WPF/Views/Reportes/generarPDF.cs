using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Diagnostics;

public class generarPDF
{
    public void GenerarPDF(string outputFilePath, string valor1, string valor2, string valor3, string valor4, string valor5, string valor6, string valor7, string valor8, string valor9, string valor10, string valor11)
    {
        string htmlContent = Dashboard_WPF.Properties.Resources.plantilla;

        MessageBox.Show(htmlContent);

        htmlContent = htmlContent.Replace("@p1", valor1 + "%");
        htmlContent = htmlContent.Replace("@p2", valor2);
        htmlContent = htmlContent.Replace("@p3", valor3);
        htmlContent = htmlContent.Replace("@p4", valor4);
        htmlContent = htmlContent.Replace("@p5", valor5);
        htmlContent = htmlContent.Replace("@p6", valor6);
        htmlContent = htmlContent.Replace("@p7", valor7);
        htmlContent = htmlContent.Replace("@p8", valor8);
        htmlContent = htmlContent.Replace("@p9", valor9);
        htmlContent = htmlContent.Replace("@pe", valor10);
        htmlContent = htmlContent.Replace("@pi", valor11);

        using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
        {
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            pdfDoc.Open();
            pdfDoc.Add(new Phrase(""));
            using (StringReader sr = new StringReader(htmlContent))
            {
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            }
            pdfDoc.Close();
        }
    }
}
