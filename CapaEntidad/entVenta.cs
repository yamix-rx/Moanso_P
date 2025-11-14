using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entVenta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; } // Necesario para FK
        public int IdUsuario { get; set; } // 🚨 NUEVO: Requerido por la tabla Venta
        public DateTime FechaVenta { get; set; }
        public string TipoComprobante { get; set; } // 🚨 NUEVO: Requerido por la tabla Venta
        public string TipoVenta { get; set; }
        public decimal TotalPagar { get; set; }
        public string Estado { get; set; } // 🚨 NUEVO: Requerido por la tabla Venta (e.g., "Registrado")

        // El detalle de la venta (lista de productos)
        public List<entItemPedido> DetalleVenta { get; set; }
    }
}
