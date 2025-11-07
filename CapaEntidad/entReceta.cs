using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entReceta
    {
        public int IdReceta { get; set; }
        public int IdProducto { get; set; }
        public int IdInsumo { get; set; }
        public decimal CantidadNecesaria { get; set; }

       
        public string NombreProducto { get; set; }
        public string NombreInsumo { get; set; }
    }
}
