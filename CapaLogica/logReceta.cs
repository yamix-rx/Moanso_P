using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logReceta
    {
        private static readonly logReceta _instancia = new logReceta();
        public static logReceta Instancia { get { return _instancia; } }

        private datReceta dat = new datReceta();

        public List<entDetalleReceta> ListarDetallesReceta(int idProducto)
        {
            return dat.ListarDetallesReceta(idProducto);
        }
    }
}
