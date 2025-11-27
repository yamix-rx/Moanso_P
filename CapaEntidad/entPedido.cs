using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPedido
    {
        public int IdDetalleVenta { get; set; }
        public int IdProducto { get; set; }
        public string Plato { get; set; }
        public int Cantidad { get; set; } // Cantidad de platos pedidos (crítico para el cálculo)
        public int IdVenta { get; set; } // Identificador de la venta (para cambiar el estado)
        public string Estado { get; set; }
    }
}
