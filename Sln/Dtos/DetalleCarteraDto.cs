using System;

namespace Proyecto_Metodologia.Cartera
{
    public class DetalleCarteraDto
    {
        public int IdCartera { get; set; }
        public float  MontoAbono { get; set; }
        public DateTime FechaAbono { get; set; } = DateTime.Now;
    }
}
