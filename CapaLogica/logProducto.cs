using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProducto
    {
        private datProducto Datos = new datProducto();

        public List<entProducto> ListarProductos()
        {
            // Aquí puedes agregar lógica de filtrado o negocio si fuera necesario
            return Datos.ListarProductos();
        }
    }
}
