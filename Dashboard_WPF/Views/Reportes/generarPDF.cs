using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic; // Agregar este namespace
using Dashboard_WPF.Views.Reportes;

public class generarPDF
{
    public void GenerarPDF(string outputFilePath, List<VentaDetalle> ventas)
    {
        string htmlContent = Dashboard_WPF.Properties.Resources.plantilla;

        // Reemplazar el contenido en el HTML con los datos de ventas
        htmlContent = htmlContent.Replace("@p1", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p2", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p3", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p4", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p5", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p6", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p7", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p8", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@p9", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@pe", ""); // Puedes dejar esto en blanco
        htmlContent = htmlContent.Replace("@pi", ""); // Puedes dejar esto en blanco

        using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
        {
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

            pdfDoc.Open();
            pdfDoc.Add(new Phrase(""));

            // Crear una tabla para mostrar los datos de ventas
            PdfPTable table = new PdfPTable(6); // 6 columnas para ID Venta, Fecha de Compra, Hora de Compra, Total en Ventas, Costo en Ventas, Ganancias

            // Agregar encabezados
            table.AddCell("ID Venta");
            table.AddCell("Fecha de Compra");
            table.AddCell("Hora de Compra");
            table.AddCell("Total en Ventas");
            table.AddCell("Costo en Ventas");
            table.AddCell("Ganancias");

            foreach (VentaDetalle venta in ventas)
            {
                // Agregar datos de ventas a la tabla
                table.AddCell(venta.IDVenta);
                table.AddCell(venta.FechaCompra);
                table.AddCell(venta.HoraCompra);
                table.AddCell(venta.TotalEnVentas.ToString());
                table.AddCell(venta.CostoEnVentas.ToString());
                table.AddCell(venta.Ganancias.ToString());
            }

            pdfDoc.Add(table);
            pdfDoc.Close();
        }
        Process.Start(outputFilePath);
    }
}
