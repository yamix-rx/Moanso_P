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
        public decimal Costo { get; set; }      // Precio Unitario
        public int Cantidad { get; set; }
        public string Observacion { get; set; } // Nuevo campo para el Chifa
        public decimal Importe { get { return Costo * Cantidad; } } // Propiedad calculada
                                                                    // Campos adicionales para la visualización del pedido
        public string NombreProducto { get; set; }
    }
}
