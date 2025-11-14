using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProveedor
    {
        // Patron de Diseño Singleton (opcional, pero buena práctica)
        private static readonly logProveedor _instancia = new logProveedor();
        public static logProveedor Instancia { get { return logProveedor._instancia; } }

        // Referencia a la capa de datos
        private readonly datProveedor datProveedor = new datProveedor();


        // =================================================================================
        // 1. LISTAR PROVEEDORES
        // =================================================================================
        public List<entProveedor> ListarProveedor()
        {
            try
            {
                // Solo llama a la capa de datos. Las reglas de negocio irían aquí.
                return datProveedor.ListarProveedor();
            }
            catch (Exception ex)
            {
                // Puedes registrar el error o relanzar una excepción más amigable
                throw new Exception("Error en la lógica al listar proveedores: " + ex.Message);
            }
        }

        // =================================================================================
        // 2. INSERTAR PROVEEDOR
        // =================================================================================
        public bool InsertarProveedor(entProveedor proveedor)
        {
            try
            {
                // Regla de negocio: Podrías validar que el DNI no esté vacío aquí
                if (string.IsNullOrWhiteSpace(proveedor.Nombre))
                {
                    throw new Exception("El nombre del proveedor no puede estar vacío.");
                }

                return datProveedor.InsertarProveedor(proveedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica al insertar proveedor: " + ex.Message);
            }
        }
    }
}
