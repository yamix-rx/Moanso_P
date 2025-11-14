using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entCliente
    {
        // Campos que coinciden con la tabla SQL y el formulario
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        // Campo adicional del formulario (si no se guarda en BD, se usa para mostrar)
        public DateTime FechaRegistro { get; set; }
    }
}
