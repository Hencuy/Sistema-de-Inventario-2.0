using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic; // Agregar este namespace
using Dashboard_WPF.Views.Reportes;

public class generarPDF2
{
    public void GenerarPDF(string outputFilePath, List<ReporteInventario> reportes)
    {
        using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
        {
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            pdfDoc.Open();
            pdfDoc.Add(new Phrase(""));

            PdfPTable table = new PdfPTable(5);

            // Agregar encabezados
            table.AddCell("Código de Barra");
            table.AddCell("Nombre");
            table.AddCell("Precio de Venta");
            table.AddCell("Stock en Existencia");
            table.AddCell("Unidad");

            foreach (ReporteInventario reporte in reportes)
            {
                table.AddCell(reporte.CodigoBarra.ToString());
                table.AddCell(reporte.Nombre);
                table.AddCell(reporte.PrecioVenta.ToString());
                table.AddCell(reporte.StockExistencia.ToString());
                table.AddCell(reporte.Unidad);
            }

            pdfDoc.Add(table);
            pdfDoc.Close();
        }
        Process.Start(outputFilePath);
    }
}
