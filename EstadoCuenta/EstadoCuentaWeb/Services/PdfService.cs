using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;
using System.IO;
using EstadoCuentaWeb.Models;
using iText.IO.Font.Constants;
using iText.Kernel.Font;

public class PdfService
{
    public byte[] GenerateHistorialPdf(List<MovimientoDTO> historial)
    {
        using (var ms = new MemoryStream())
        {
            PdfWriter writer = new PdfWriter(ms);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);


            document.Add(new Paragraph("Historial de Transacciones")
                .SetFontSize(16)
                .SetFont(boldFont));

            // Crear tabla
            Table table = new Table(4);
            table.AddHeaderCell("Fecha");
            table.AddHeaderCell("Descripción");
            table.AddHeaderCell("Monto");
            table.AddHeaderCell("Tipo");

            foreach (var item in historial)
            {
                table.AddCell(item.Fecha.ToString("yyyy-MM-dd HH:mm"));
                table.AddCell(item.Descripcion);
                table.AddCell(item.Monto.ToString("C"));
                table.AddCell(item.TipoMovimiento);
            }

            document.Add(table);
            document.Close();

            return ms.ToArray();
        }
    }
}
