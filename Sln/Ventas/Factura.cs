
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Proyecto_Metodologia.Ventas
{
    public class Factura
    {
        public void PrintDocument_PrintPageCustom(object sender, PrintPageEventArgs e, string codVenta, DataGridView dgvVentas)
        {
            // Posición inicial para imprimir
            int yPosition = 20; // Se inicia con un margen superior
            int xPosition = 10; // Margen izquierdo

            // Fuente y pincel para el texto con tamaños reducidos
            Font font = new Font("Arial", 8); // Tamaño más pequeño para los datos
            Font fontBold = new Font("Arial", 10, FontStyle.Bold); // Tamaño reducido para títulos
            Brush brush = Brushes.Black;

            // Definir altura de línea y ancho de columna
            int lineHeight = (int)font.GetHeight(e.Graphics) + 2; // Ajuste de espaciado
            int codeWidth = 40;   // Ancho de la columna Código
            int nameWidth = 120;  // Ancho de la columna Nombre del Artículo
            int qtyWidth = 40;    // Ancho de la columna Cantidad
                                  //   int priceWidth = 60;  // Ancho de la columna Valor
            int spacing = 5;      // Espaciado entre columnas

            // Obtener el número de factura desde txtCodVentas
            string numeroFactura = string.IsNullOrEmpty(codVenta) ? "N/A" : codVenta;

            // ENCABEZADO DEL TICKET
            e.Graphics.DrawString("SUPERMERCADO HÉCTOR", fontBold, brush, xPosition, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString("NIT: 12345678-9", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString($"Factura No: {numeroFactura}", font, brush, xPosition, yPosition);
            yPosition += lineHeight * 2; // Espaciado extra antes de los productos

            // LÍNEA SEPARADORA
            e.Graphics.DrawString("-----------------------------------------------", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // ENCABEZADO DE COLUMNAS
            int currentX = xPosition;
            e.Graphics.DrawString("Cod", fontBold, brush, currentX, yPosition);
            currentX += codeWidth + spacing;

            e.Graphics.DrawString("Artículo", fontBold, brush, currentX, yPosition);
            currentX += nameWidth + spacing;

            e.Graphics.DrawString("Cant", fontBold, brush, currentX, yPosition);
            currentX += qtyWidth + spacing;

            e.Graphics.DrawString("Precio", fontBold, brush, currentX, yPosition);

            yPosition += lineHeight;

            // LÍNEA SEPARADORA
            e.Graphics.DrawString("-----------------------------------------------", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // IMPRESIÓN DE DATOS
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la fila vacía

                currentX = xPosition; // Reiniciar posición X por cada fila

                string codigo = row.Cells[0].Value?.ToString() ?? "";
                string articulo = row.Cells[1].Value?.ToString() ?? "";
                string cantidad = row.Cells[2].Value?.ToString() ?? "";
                string valor = row.Cells[3].Value?.ToString() ?? "";

                // Imprimir cada celda en su respectiva columna
                e.Graphics.DrawString(codigo, font, brush, currentX, yPosition);
                currentX += codeWidth + spacing;

                e.Graphics.DrawString(articulo, font, brush, currentX, yPosition);
                currentX += nameWidth + spacing;

                e.Graphics.DrawString(cantidad, font, brush, currentX, yPosition);
                currentX += qtyWidth + spacing;

                e.Graphics.DrawString(valor, font, brush, currentX, yPosition);

                yPosition += lineHeight; // Mover a la siguiente línea
            }

            // LÍNEA SEPARADORA FINAL
            yPosition += lineHeight;
            e.Graphics.DrawString("-----------------------------------------------", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // MENSAJE DE AGRADECIMIENTO
            e.Graphics.DrawString("¡Gracias por su compra!", fontBold, brush, xPosition, yPosition);
            yPosition += lineHeight * 2; // Espaciado extra

            // MENSAJE DE DESARROLLADOR
            e.Graphics.DrawString("Software desarrollado por SERVISISTEMAS", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // Indicar que no hay más páginas para imprimir
            e.HasMorePages = false;
        }


        public void ImprimirFactura(PrintDocument printDocument)
        {
            DialogResult result = MessageBox.Show("¿Desea imprimir?", "Éxito", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            // Verificar si el usuario presionó 'OK' (Enter) o 'Cancel' (Escape)
            if (result == DialogResult.OK)
            {
                // Aquí agregas el código para realizar la acción de impresión

                // Crear una nueva instancia de PrintDocument
                PrintDocument printDoc = new PrintDocument();

                // Asegurarse de que la impresora se ha configurado correctamente con el nombre correcto
                printDoc.PrinterSettings.PrinterName = "POS-80"; // Usar el nombre exacto de la impresora

                // Verificar si la impresora está disponible
                if (string.IsNullOrEmpty(printDoc.PrinterSettings.PrinterName) || !printDoc.PrinterSettings.IsValid)
                {
                    MessageBox.Show("No se puede encontrar la impresora POS-80.");
                    return;
                }

                // Establecer el contenido a imprimir, en este caso, el texto del TextBox
                printDoc.PrintPage += (sender1, args) =>
                {
                    // Obtener el texto del TextBox
                    //string textoAImprimir = "hola";
                    printDocument.Print();


                    // Verificar si el texto es nulo o vacío antes de intentar imprimir
                    // if (string.IsNullOrEmpty(textoAImprimir))


                    // Especificamos la fuente y el color
                    Font font = new Font("Arial", 12);
                    Brush brush = Brushes.Black;

                    // Dibujar el texto en la página de impresión
                    // args.Graphics.DrawString(textoAImprimir, font, brush, 100, 100);  // Ajusta las coordenadas según sea necesario
                };

                // Imprimir el documento
                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al imprimir: {ex.Message}");
                }
            }
            else if (result == DialogResult.Cancel)
            {
                // Si se presionó Escape, no se realiza ninguna acción
                //MessageBox.Show("La impresión ha sido cancelada.");
            }
        }
    }
}
