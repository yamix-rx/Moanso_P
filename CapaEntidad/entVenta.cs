using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entVenta
    {
        // Campos que corresponden a la tabla Venta
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; } // Id del Mozo/Empleado
        public DateTime FechaVenta { get; set; }
        public string TipoComprobante { get; set; } // Ej: "Ticket", "Factura"
        public string TipoVenta { get; set; } // Ej: "Salón", "Llevar", "Delivery"
        public decimal TotalPagar { get; set; }
        public string Estado { get; set; } // Ej: "Registrada", "Anulada"

        // La lista de productos (el detalle) es clave para la transacción
        public List<entItemPedido> DetalleVenta { get; set; }
    }
}
