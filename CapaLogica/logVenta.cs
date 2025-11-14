using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logVenta
    {
        private datVenta Datos = new datVenta();

        // Método para registrar la venta en el archivo TXT
        // 🚨 MÉTODO ACTUALIZADO: Ahora recibe solo la entidad Venta
        public bool RegistrarVenta(entVenta venta)
        {
            // Validación de Negocio: Verificar que haya ítems
            if (venta.DetalleVenta == null || venta.DetalleVenta.Count == 0)
            {
                throw new Exception("El pedido debe contener al menos un plato o bebida.");
            }

            // Validación de Negocio: IdCliente debe ser válido
            if (venta.IdCliente <= 0)
            {
                throw new Exception("Debe seleccionar un cliente válido (IdCliente faltante).");
            }

            // Llamada al método que ahora guarda en SQL
            return Datos.RegistrarVenta(venta);
        }

        // Método para listar las ventas, llamando al parser de TXT
        public DataTable ListarVentasRegistradas()
        {
            // Llama al método de datVenta que lee y parsea el TXT a un DataTable
            return Datos.ListarVentasRegistradas();
        }

        // 🚨 NUEVO MÉTODO AGREGADO: Anular Venta
        /// <summary>
        /// Llama a la capa de acceso a datos para eliminar un bloque de venta del archivo TXT.
        /// </summary>
        /// <param name="idVenta">El ID de venta (simulado) a anular.</param>
        public void AnularVenta(int idVenta)
        {
            if (idVenta <= 0)
            {
                throw new Exception("El ID de venta para anular debe ser un número positivo válido.");
            }

            // Llama al método de datVenta que elimina el bloque de texto
            Datos.AnularVenta(idVenta);
        }
    }
}
