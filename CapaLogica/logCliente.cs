using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCliente
    {
        private datCliente Datos = new datCliente();

        public List<entCliente> ListarCliente()
        {
            return Datos.ListarCliente();
        }

        public bool InsertarCliente(entCliente cliente)
        {
            // Validación de DNI (Ejemplo de regla de negocio: DNI no debe estar vacío)
            if (string.IsNullOrWhiteSpace(cliente.DNI))
            {
                throw new Exception("El DNI es un campo obligatorio para registrar.");
            }
            return Datos.InsertarCliente(cliente);
        }

        public bool ActualizarCliente(entCliente cliente)
        {
            if (cliente.IdCliente <= 0)
            {
                throw new Exception("Debe seleccionar un cliente válido para editar.");
            }
            if (string.IsNullOrWhiteSpace(cliente.DNI))
            {
                throw new Exception("El DNI no puede estar vacío al editar.");
            }
            return Datos.ActualizarCliente(cliente);
        }

        public bool EliminarCliente(entCliente cliente)
        {
            if (cliente.IdCliente <= 0)
            {
                throw new Exception("Debe seleccionar un cliente válido para eliminar.");
            }
            return Datos.EliminarCliente(cliente);
        }

        // 🚨 NUEVO MÉTODO: Lógica de búsqueda
        public entCliente BuscarCliente(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new Exception("Debe ingresar un DNI para buscar al cliente.");
            }

            // Llama al método de acceso a datos
            return Datos.BuscarClientePorDNI(dni);
        }
    }
}
