using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class Frmtikect : Form
    {
        private PrintDocument printDocument;

        public Frmtikect()
        {
            InitializeComponent();

            // Crear el objeto PrintDocument
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        // Evento que se dispara cuando se llama a la función de impresión
        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            // Configurar el nombre de la impresora
            //printDocument.PrinterSettings.PrinterName = "Nombre de tu impresora térmica";

            // Mostrar el cuadro de diálogo de impresión (opcional)
           // PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = printDocument;
            //if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Iniciar la impresión
                printDocument.Print();
            }
        }

        // Este es el evento donde definimos el contenido del ticket
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Definir las configuraciones básicas de la impresora térmica
            int yPos = 0;  // Posición Y inicial para imprimir
            int xPos = 0;  // Posición X inicial

            // Fuente básica para el ticket
            Font font = new Font("Arial", 12);  // Puedes ajustar la fuente según el tipo de impresora térmica
            Brush brush = Brushes.Black;

            // Texto del ticket (aquí personalizas lo que debe contener)
            string ticketContent = "Tienda XYZ\n";
            ticketContent += "-----------------------------\n";
            ticketContent += "Producto 1        $10.00\n";
            ticketContent += "Producto 2        $5.50\n";
            ticketContent += "-----------------------------\n";
            ticketContent += "Total:           $15.50\n";
            ticketContent += "Gracias por su compra!\n";

            // Dibujar el contenido en la página de impresión
            e.Graphics.DrawString(ticketContent, font, brush, xPos, yPos);

            // Para la impresora térmica, es común agregar saltos de línea para generar el formato
            yPos += 150; // Ajustar según sea necesario para el espaciado

            // Indicamos que no hay más páginas para imprimir
            e.HasMorePages = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Configurar el nombre de la impresora
            //printDocument.PrinterSettings.PrinterName = "Nombre de tu impresora térmica";

            // Mostrar el cuadro de diálogo de impresión (opcional)
            //PrintDialog printDialog = new PrintDialog();
           // printDialog.Document = printDocument;
           // if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Iniciar la impresión
                printDocument.Print();
            }
        }
    }
}