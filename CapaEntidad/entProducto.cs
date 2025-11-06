using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProducto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public string Tipo { get; set; } // "Plato" o "Bebida"
        public int Stock { get; set; }
    }
}
