using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Metodologia.Cartera
{
    public class CarteraDto
    {
        public string DocumentoCliente { get; set; }
        public double AbonoInicial { get; set; }
        public string IdVenta { get; set; }
        public DateTime FechaCartera { get; set; }
    }
}
