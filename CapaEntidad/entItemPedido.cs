using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entItemPedido
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; } // ✅ Correcto, coincide con la tabla DetalleVenta
        public int Cantidad { get; set; }
        public string Observacion { get; set; } // Nuevo campo para el Chifa

        // 🚨 AJUSTE NECESARIO: Descomenta y usa PrecioUnitario en lugar de Costo
        public decimal Importe { get { return PrecioUnitario * Cantidad; } } // Propiedad calculada

        // Campos adicionales para la visualización del pedido
        public string NombreProducto { get; set; } // ✅ Correcto para mostrar el nombre en el DataGridView
    }
}
