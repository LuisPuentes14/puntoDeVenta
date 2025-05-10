
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System;
using Proyecto_Metodologia.Comercio;
using System.Linq;
using Proyecto_Metodologia.Dtos;
using System.Globalization;
using DocumentFormat.OpenXml.Spreadsheet;
using Font = System.Drawing.Font;

namespace Proyecto_Metodologia.Ventas
{
    public class Factura
    {
        private ComercioRepository _comercio = new ComercioRepository();

        public void PrintDocument_PrintPageCustom(object sender, PrintPageEventArgs e, string codVenta, string totalIva, string TotalVenta, ClienteDto cliente, DataGridView dgvVentas)
        {
            // Configuración inicial
            int marginLeft = 7;
            int marginTop = 10;
            int spacing = 5;

            // Tamaños de columna ajustados (deben sumar aprox 300 para un papel tamaño ticket)
            const int codeWidth = 40;
            const int nameWidth = 100;
            const int qtyWidth = 30;
            const int priceUnitWidth = 50;
            const int totalWidth = 50;

            // Fuentes
            Font font = new Font("Arial", 7);
            Font fontBold = new Font("Arial", 9, FontStyle.Bold);
            Brush brush = Brushes.Black;

            int lineHeight = (int)font.GetHeight(e.Graphics) + 2;
            int yPosition = marginTop;

            // Datos generales
            string numeroFactura = string.IsNullOrEmpty(codVenta) ? "N/A" : codVenta;

            // Obtener ancho de página imprimible
            float pageWidth = e.PageBounds.Width;

            var ArrayDatos = _comercio.obtenerDatosComercio();

            foreach (var (linea, index) in ArrayDatos.Select((linea, index) => (linea, index)))
            {
                Font fuenteActual = index == 0 ? fontBold : font;
                SizeF textoSize = e.Graphics.MeasureString(linea, fuenteActual);
                float xCentered = (pageWidth - textoSize.Width) / 2;
                e.Graphics.DrawString(linea, fuenteActual, brush, xCentered, yPosition);
                yPosition += lineHeight;
            }
            yPosition += lineHeight; // espacio extra antes del separador

            e.Graphics.DrawString($"Doc cliente: {cliente.Documento}", font, brush, marginLeft, yPosition); yPosition += lineHeight;
            e.Graphics.DrawString($"Nombre: {cliente.Nombre} {cliente.Apellido}", font, brush, marginLeft, yPosition); yPosition += lineHeight;
            e.Graphics.DrawString($"Correo:  {cliente.Correo}", font, brush, marginLeft, yPosition); yPosition += lineHeight;
            e.Graphics.DrawString($"Telefono: {cliente.Telefono}", font, brush, marginLeft, yPosition); yPosition += lineHeight * 2;

            // Separador
            e.Graphics.DrawString(new string('-', 80), font, brush, marginLeft, yPosition); yPosition += lineHeight;

            // Columnas
            int currentX = marginLeft;
            e.Graphics.DrawString("Cod", fontBold, brush, currentX, yPosition); currentX += codeWidth + spacing;
            e.Graphics.DrawString("Artículo", fontBold, brush, currentX, yPosition); currentX += nameWidth + spacing;
            e.Graphics.DrawString("Cant", fontBold, brush, currentX, yPosition); currentX += qtyWidth + spacing;
            e.Graphics.DrawString("P.Unit", fontBold, brush, currentX, yPosition); currentX += priceUnitWidth + spacing;
            e.Graphics.DrawString("Total", fontBold, brush, currentX, yPosition);
            yPosition += lineHeight;

            // Separador
            e.Graphics.DrawString(new string('-', 80), font, brush, marginLeft, yPosition); yPosition += lineHeight;

            // Filas del DataGridView
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.IsNewRow) continue;

                string codigo = double.Parse(row.Cells[0].Value?.ToString() ?? "").ToString("N0", new CultureInfo("es-CO"));
                string articulo = row.Cells[1].Value?.ToString() ?? "";
                string cantidad = row.Cells[2].Value?.ToString() ?? "";
                string precioUnit = double.Parse(row.Cells[3].Value?.ToString() ?? "").ToString("N0", new CultureInfo("es-CO"));
                string total = double.Parse(row.Cells[4].Value?.ToString() ?? "").ToString("N0", new CultureInfo("es-CO"));

                // Medir cuántas líneas ocupa el nombre del artículo
                SizeF sizeArticulo = e.Graphics.MeasureString(articulo, font, nameWidth);
                int lineasArticulo = (int)Math.Ceiling(sizeArticulo.Height / lineHeight);
                int alturaFila = lineHeight * Math.Max(1, lineasArticulo);

                currentX = marginLeft;
                e.Graphics.DrawString(codigo, font, brush, currentX, yPosition);
                currentX += codeWidth + spacing;

                RectangleF rectArticulo = new RectangleF(currentX, yPosition, nameWidth, alturaFila);
                StringFormat format = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
                e.Graphics.DrawString(articulo, font, brush, rectArticulo, format);
                currentX += nameWidth + spacing;

                e.Graphics.DrawString(cantidad, font, brush, currentX, yPosition);
                currentX += qtyWidth + spacing;

                e.Graphics.DrawString(precioUnit, font, brush, currentX, yPosition);
                currentX += priceUnitWidth + spacing;

                e.Graphics.DrawString(total, font, brush, currentX, yPosition);

                yPosition += alturaFila;
            }

            // Separador final
            yPosition += lineHeight;

            // IVA alineado a la derecha
            string textoIva = $"IVA: {double.Parse(totalIva).ToString("N0", new CultureInfo("es-CO"))}";
            SizeF sizeIva = e.Graphics.MeasureString(textoIva, font);
            float xIva = pageWidth - sizeIva.Width - marginLeft;
            e.Graphics.DrawString(textoIva, font, brush, xIva, yPosition);
            yPosition += lineHeight;

            // TOTAL alineado a la derecha con fuente bold
            string textoTotal = $"TOTAL: {double.Parse(TotalVenta).ToString("N0", new CultureInfo("es-CO"))}";
            SizeF sizeTotal = e.Graphics.MeasureString(textoTotal, fontBold);
            float xTotal = pageWidth - sizeTotal.Width - marginLeft;
            e.Graphics.DrawString(textoTotal, fontBold, brush, xTotal, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString(new string('-', 80), font, brush, marginLeft, yPosition); yPosition += lineHeight;

            // Mensajes finales
            e.Graphics.DrawString("¡Gracias por su compra!", fontBold, brush, marginLeft, yPosition); yPosition += lineHeight * 2;
            e.Graphics.DrawString("Software desarrollado por SERVISISTEMAS", font, brush, marginLeft, yPosition);

            e.HasMorePages = false;
        }

        public void ImprimirFactura(string codVenta, string totalIva, string totalPagar, ClienteDto cliente, DataGridView dgvVentas)
        {
            DialogResult result = MessageBox.Show("¿Desea imprimir?", "Éxito", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = "POS-80";

                if (string.IsNullOrEmpty(printDoc.PrinterSettings.PrinterName) || !printDoc.PrinterSettings.IsValid)
                {
                    MessageBox.Show("No se puede encontrar la impresora POS-80.");
                    return;
                }

                // Asociar el método de impresión correctamente
                printDoc.PrintPage += (sender, e) =>
                {
                    PrintDocument_PrintPageCustom(sender, e, codVenta, totalIva, totalPagar, cliente, dgvVentas);
                };

                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al imprimir: {ex.Message}");
                }
            }
        }
    }
}
