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

        public bool RegistrarVenta(entVenta venta, entCliente cliente)
        {
            // Validación de Negocio: Verificar que haya ítems
            if (venta.DetalleVenta == null || venta.DetalleVenta.Count == 0)
            {
                throw new Exception("El pedido debe contener al menos un plato o bebida.");
            }
            // Validación de Negocio: Verificar datos mínimos del cliente
            if (string.IsNullOrWhiteSpace(cliente.DNI) || string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new Exception("Debe ingresar el nombre y DNI del cliente.");
            }

            return Datos.RegistrarVenta(venta, cliente);
        }

        public DataTable ListarVentasRegistradas()
        {
            return Datos.ListarVentasRegistradas();
        }
    }
}
