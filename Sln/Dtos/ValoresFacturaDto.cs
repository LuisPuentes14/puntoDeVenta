
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace Proyecto_Metodologia.Dtos
{
    public class ValoresFacturaDto
    {
        public string CodigoVenta { get; set; } = string.Empty;
        public double TotalIva { get; set; } = 0;
        public double Subtotal { get; set; } = 0;
        public double TotalPagar { get; set; } = 0;
        public ClienteDto Cliente { get; set; } = new ClienteDto();
        public DataGridView DgvVentas { get; set; } = new DataGridView();
    }
}