using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entDetalleReceta
    {
        public int IdInsumo { get; set; } // Clave para el descuento
        public string InsumoNombre { get; set; }
        public decimal CantidadNecesaria { get; set; } // Cantidad por UN plato
        public string UnidadMedida { get; set; }
    }
}
